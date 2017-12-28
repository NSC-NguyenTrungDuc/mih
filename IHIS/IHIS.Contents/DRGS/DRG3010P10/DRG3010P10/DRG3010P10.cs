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
    /// <summary>)
    /// DRG3010P10에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG3010P10 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XTabControl tabControl;
        private IHIS.X.Magic.Controls.TabPage tabPage1;
        private IHIS.Framework.XPanel xPanel8;
        private IHIS.Framework.XEditGrid grdMiMagamOrder;
        private IHIS.Framework.XEditGrid grdMiMagamJUSAOrder;
        private IHIS.Framework.XPanel xPanel7;
        private IHIS.Framework.XEditGrid grdPaQuery;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XButton btnCommentForm;
        private IHIS.Framework.XButton btnMagam;
        private IHIS.Framework.XButton btnAllUnCheck;
        private IHIS.Framework.XButton btnAllCheck;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
        private IHIS.Framework.XPanel xPanel10;
        private IHIS.Framework.XEditGrid grdMagamJUSAOrder;
        private IHIS.Framework.XPanel xPanel9;
        private IHIS.Framework.XEditGrid grdMagamPaQuery;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XButton btnLable;
        private IHIS.Framework.XButton btnComment;
        private IHIS.Framework.XButtonList btnListMagam;
        private IHIS.Framework.XButton btnPrint;
        private IHIS.Framework.XButton btnRangeCancel;
        private IHIS.Framework.XButton btnNumberCancel;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XEditGridCell xEditGridCell315;
        private IHIS.Framework.XEditGridCell xEditGridCell319;
        private IHIS.Framework.XEditGridCell xEditGridCell317;
        private IHIS.Framework.XEditGridCell xEditGridCell321;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
        private IHIS.Framework.XEditGridCell xEditGridCell90;
        private IHIS.Framework.XEditGridCell xEditGridCell91;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell96;
        private IHIS.Framework.XEditGridCell xEditGridCell97;
        private IHIS.Framework.XEditGridCell xEditGridCell98;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell316;
        private IHIS.Framework.XEditGridCell xEditGridCell320;
        private IHIS.Framework.XEditGridCell xEditGridCell318;
        private IHIS.Framework.XEditGridCell xEditGridCell322;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell332;
        private IHIS.Framework.XEditGridCell xEditGridCell57;
        private IHIS.Framework.XEditGridCell xEditGridCell101;
        private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XEditGridCell xEditGridCell103;
        private IHIS.Framework.XEditGridCell xEditGridCell104;
        private IHIS.Framework.XEditGridCell xEditGridCell105;
        private IHIS.Framework.XEditGridCell xEditGridCell106;
        private IHIS.Framework.XEditGridCell xEditGridCell107;
        private IHIS.Framework.XEditGridCell xEditGridCell108;
        private IHIS.Framework.XEditGridCell xEditGridCell109;
        private IHIS.Framework.XEditGridCell xEditGridCell110;
        private IHIS.Framework.XEditGridCell xEditGridCell111;
        private IHIS.Framework.XEditGridCell xEditGridCell112;
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
        private IHIS.Framework.XEditGridCell xEditGridCell124;
        private IHIS.Framework.XEditGridCell xEditGridCell125;
        private IHIS.Framework.XEditGridCell xEditGridCell128;
        private IHIS.Framework.XEditGridCell xEditGridCell130;
        private IHIS.Framework.XEditGridCell xEditGridCell257;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XButtonList btnListMimagam;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGrid grdDrgBunhoList;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.MultiLayout layOrderPrint;
        private IHIS.Framework.MultiLayout layJusaLable;
        private IHIS.Framework.MultiLayout layJusaOrderPrint;
        private IHIS.Framework.MultiLayout layOrderJungbo;
        private IHIS.Framework.MultiLayout layOrderBarcode;
        private IHIS.Framework.MultiLayout layAntiData;
        private IHIS.Framework.XButton xButton2;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XButton btnHopeTimeMake;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XEditGridCell xEditGridCell333;
        private IHIS.Framework.XEditGridCell xEditGridCell334;
        private IHIS.Framework.XEditGridCell xEditGridCell335;
        private IHIS.X.Magic.Controls.TabPage tabPage5;
        private IHIS.Framework.XPanel xPanel16;
        private IHIS.Framework.XLabel lbBoryuColor;
        private System.Windows.Forms.ImageList imageListMenu;
        private IHIS.Framework.XEditGridCell xEditGridCell409;
        private IHIS.Framework.XEditGridCell xEditGridCell410;
        private IHIS.Framework.XEditGridCell xEditGridCell411;
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
        private MultiLayoutItem multiLayoutItem165;
        private MultiLayoutItem multiLayoutItem166;
        private MultiLayoutItem multiLayoutItem167;
        private MultiLayoutItem multiLayoutItem168;
        private MultiLayoutItem multiLayoutItem169;
        private MultiLayoutItem multiLayoutItem170;
        private MultiLayoutItem multiLayoutItem171;
        private XEditGridCell xEditGridCell5;
        private ImageList imageListMixGroup;
        private XEditGridCell xEditGridCell132;
        private XEditGridCell xEditGridCell133;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell144;
        private XEditGridCell xEditGridCell145;
        private XEditGridCell xEditGridCell146;
        private XEditGridCell xEditGridCell147;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell152;
        private XEditGridCell xEditGridCell153;
        private XEditGridCell xEditGridCell154;
        private XEditGridCell xEditGridCell158;
        private XEditGridCell xEditGridCell159;
        private XEditGridCell xEditGridCell160;
        private XEditGridCell xEditGridCell161;
        private XEditGridCell xEditGridCell162;
        private XEditGridCell xEditGridCell163;
        private XEditGridCell xEditGridCell164;
        private XEditGridCell xEditGridCell165;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
        private XComboBox cbxGubun;
        private XComboItem xComboItem14;
        private XComboItem xComboItem15;
        private XEditGridCell xEditGridCell166;
        private XGridHeader xGridHeader3;
        private XEditGridCell xEditGridCell167;
        private XComboItem xComboItem16;
        private XComboItem xComboItem17;
        private XEditGridCell xEditGridCell168;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell169;
        private XEditGridCell xEditGridCell173;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
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
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem60;
        private XDictComboBox cbxBuseo;
        private XLabel xLabel7;
        private XLabel xLabel2;
        private XLabel xLabel3;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XEditGridCell xEditGridCell170;
        private XEditGridCell xEditGridCell174;
        private XEditGridCell xEditGridCell175;
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
        private XEditGridCell xEditGridCell258;
        private XEditGridCell xEditGridCell131;
        private XEditGridCell xEditGridCell149;
        private XEditGridCell xEditGridCell150;
        private XEditGridCell xEditGridCell151;
        private XEditGridCell xEditGridCell155;
        private XEditGridCell xEditGridCell156;
        private XEditGridCell xEditGridCell157;
        private XPanel xPanel5;
        private XEditGridCell xEditGridCell176;
        private XEditGridCell xEditGridCell177;
        private XLabel xLabel4;
        private XDictComboBox cbxActor;
        private Panel pnlStatus;
        private Label lbStatus;
        private XProgressBar pgbProgress;
        private XLabel xLabel5;
        private XDatePicker dtpJubsuDate;
        private XCheckBox cbxATCYN;
        private MultiLayout mlayConstantInfo;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem42;
        private XPanel xPanel6;
        private XPanel xPanel12;
        //private XDataWindow dw_Anti;
        //private XDataWindow dw_print;
        //private XDataWindow dw_jusa;
        //private XDataWindow dw_lable;
        private XPanel xPanel2;
        private XButton btnAtcTrans;
        private XLabel lbCycleMagamDate;
        private XLabel lbCycleOrdDate;
        private XPanel xPanel17;
        private XPanel xPanel18;
        private XEditGrid grdPaDcQuery;
        private XEditGridCell xEditGridCell171;
        private XEditGridCell xEditGridCell172;
        private XEditGridCell xEditGridCell178;
        private XEditGridCell xEditGridCell179;
        private XEditGridCell xEditGridCell180;
        private XEditGridCell xEditGridCell181;
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
        private XPanel xPanel19;
        private XEditGrid grdDcOrder;
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
        private XGridHeader xGridHeader4;
        private XEditGrid grdJusaDcOrder;
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
        private XEditGridCell xEditGridCell259;
        private XEditGridCell xEditGridCell260;
        private XEditGridCell xEditGridCell261;
        private XEditGridCell xEditGridCell262;
        private XEditGridCell xEditGridCell263;
        private XEditGridCell xEditGridCell264;
        private XEditGridCell xEditGridCell265;
        private XGridHeader xGridHeader5;
        private XButtonList btnListDc;
        private XButton btnDcRePrint;
        private XComboItem xComboItem11;
        private XComboItem xComboItem12;
        private XEditGridCell xEditGridCell182;
        private XEditGridCell xEditGridCell266;
        private XEditGridCell xEditGridCell267;
        private XLabel lbQueryBase;
        private XDatePicker dtpFromDate;
        private XDatePicker dtpToDate;
        private XLabel xLabel14;
        private XGridHeader xGridHeader6;
        private XEditGridCell xEditGridCell268;
        private XEditGridCell xEditGridCell269;
        private XButton btnPrintAdmMedi;
        private XEditGridCell xEditGridCell270;
        private XCheckBox cbxJusaLabelYN;
        private System.ComponentModel.IContainer components;

        public DRG3010P10()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

            this.Height = rc.Height - 125;
            
            if(rc.Width < 1280)
            {
                this.Width = rc.Width;
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

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010P10));
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.dtpJubsuDate = new IHIS.Framework.XDatePicker();
            this.cbxBuseo = new IHIS.Framework.XDictComboBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.cbxGubun = new IHIS.Framework.XComboBox();
            this.xComboItem14 = new IHIS.Framework.XComboItem();
            this.xComboItem15 = new IHIS.Framework.XComboItem();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.tabControl = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.grdPaQuery = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell332 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell409 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell410 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell165 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell173 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell270 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell177 = new IHIS.Framework.XEditGridCell();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.grdMiMagamOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell315 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell319 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell317 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell321 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell334 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell335 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell268 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.grdMiMagamJUSAOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell316 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell320 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell318 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell322 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell333 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnCommentForm = new IHIS.Framework.XButton();
            this.cbxJusaLabelYN = new IHIS.Framework.XCheckBox();
            this.cbxATCYN = new IHIS.Framework.XCheckBox();
            this.btnListMimagam = new IHIS.Framework.XButtonList();
            this.btnMagam = new IHIS.Framework.XButton();
            this.btnAllUnCheck = new IHIS.Framework.XButton();
            this.btnAllCheck = new IHIS.Framework.XButton();
            this.btnHopeTimeMake = new IHIS.Framework.XButton();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel12 = new IHIS.Framework.XPanel();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.grdMagamPaQuery = new IHIS.Framework.XEditGrid();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xComboItem16 = new IHIS.Framework.XComboItem();
            this.xComboItem17 = new IHIS.Framework.XComboItem();
            this.xPanel10 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
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
            this.xEditGridCell258 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell269 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader6 = new IHIS.Framework.XGridHeader();
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
            this.xEditGridCell257 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell160 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.grdDrgBunhoList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell176 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell174 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell175 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell411 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell168 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell169 = new IHIS.Framework.XEditGridCell();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnPrintAdmMedi = new IHIS.Framework.XButton();
            this.btnAtcTrans = new IHIS.Framework.XButton();
            this.btnLable = new IHIS.Framework.XButton();
            this.btnComment = new IHIS.Framework.XButton();
            this.btnListMagam = new IHIS.Framework.XButtonList();
            this.btnPrint = new IHIS.Framework.XButton();
            this.btnRangeCancel = new IHIS.Framework.XButton();
            this.btnNumberCancel = new IHIS.Framework.XButton();
            this.xButton2 = new IHIS.Framework.XButton();
            this.tabPage5 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel17 = new IHIS.Framework.XPanel();
            this.xPanel18 = new IHIS.Framework.XPanel();
            this.grdPaDcQuery = new IHIS.Framework.XEditGrid();
            this.xEditGridCell171 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell172 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell178 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell179 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
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
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xComboItem12 = new IHIS.Framework.XComboItem();
            this.xEditGridCell193 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell194 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell195 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell267 = new IHIS.Framework.XEditGridCell();
            this.xPanel19 = new IHIS.Framework.XPanel();
            this.grdDcOrder = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell182 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader4 = new IHIS.Framework.XGridHeader();
            this.grdJusaDcOrder = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell259 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell260 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell261 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell262 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell263 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell264 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell265 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell266 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader5 = new IHIS.Framework.XGridHeader();
            this.xPanel16 = new IHIS.Framework.XPanel();
            this.btnDcRePrint = new IHIS.Framework.XButton();
            this.btnListDc = new IHIS.Framework.XButtonList();
            this.lbQueryBase = new IHIS.Framework.XLabel();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.lbCycleMagamDate = new IHIS.Framework.XLabel();
            this.lbCycleOrdDate = new IHIS.Framework.XLabel();
            this.layOrderPrint = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
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
            this.layJusaLable = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.layJusaOrderPrint = new IHIS.Framework.MultiLayout();
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
            this.layOrderJungbo = new IHIS.Framework.MultiLayout();
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
            this.layOrderBarcode = new IHIS.Framework.MultiLayout();
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
            this.layAntiData = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem165 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem166 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem167 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem168 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem169 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem170 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem171 = new IHIS.Framework.MultiLayoutItem();
            this.lbBoryuColor = new IHIS.Framework.XLabel();
            this.imageListMenu = new System.Windows.Forms.ImageList(this.components);
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.mlayConstantInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel2 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.xPanel7.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaQuery)).BeginInit();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamJUSAOrder)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnListMimagam)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.xPanel12.SuspendLayout();
            this.xPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamPaQuery)).BeginInit();
            this.xPanel10.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamJUSAOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrgBunhoList)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnListMagam)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.xPanel17.SuspendLayout();
            this.xPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaDcQuery)).BeginInit();
            this.xPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJusaDcOrder)).BeginInit();
            this.xPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnListDc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaLable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAntiData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).BeginInit();
            this.xPanel2.SuspendLayout();
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
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "");
            this.ImageList.Images.SetKeyName(9, "");
            this.ImageList.Images.SetKeyName(10, "");
            this.ImageList.Images.SetKeyName(11, "1378574239_25466.ico");
            this.ImageList.Images.SetKeyName(12, "1378574249_25467.ico");
            this.ImageList.Images.SetKeyName(13, "저장.gif");
            this.ImageList.Images.SetKeyName(14, "그린볼.gif");
            this.ImageList.Images.SetKeyName(15, "블루볼.gif");
            this.ImageList.Images.SetKeyName(16, "핑크볼.gif");
            this.ImageList.Images.SetKeyName(17, "04.gif");
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Name = "xLabel5";
            // 
            // dtpJubsuDate
            // 
            resources.ApplyResources(this.dtpJubsuDate, "dtpJubsuDate");
            this.dtpJubsuDate.IsVietnameseYearType = false;
            this.dtpJubsuDate.Name = "dtpJubsuDate";
            this.dtpJubsuDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJubsuDate_DataValidating);
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
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Name = "xLabel7";
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
            // cbxGubun
            // 
            resources.ApplyResources(this.cbxGubun, "cbxGubun");
            this.cbxGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem14,
            this.xComboItem15});
            this.cbxGubun.Name = "cbxGubun";
            this.cbxGubun.SelectionChangeCommitted += new System.EventHandler(this.cbxGubun_SelectionChangeCommitted);
            // 
            // xComboItem14
            // 
            resources.ApplyResources(this.xComboItem14, "xComboItem14");
            this.xComboItem14.ValueItem = "1";
            // 
            // xComboItem15
            // 
            resources.ApplyResources(this.xComboItem15, "xComboItem15");
            this.xComboItem15.ValueItem = "2";
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.tabControl);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.IDEPixelArea = true;
            this.tabControl.IDEPixelBorder = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedTab = this.tabPage1;
            this.tabControl.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage5});
            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.xPanel6);
            this.tabPage1.Controls.Add(this.xPanel1);
            this.tabPage1.ImageIndex = 14;
            this.tabPage1.ImageList = this.ImageList;
            this.tabPage1.Name = "tabPage1";
            // 
            // xPanel6
            // 
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Controls.Add(this.xPanel7);
            this.xPanel6.Controls.Add(this.xPanel8);
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Name = "xPanel6";
            // 
            // xPanel7
            // 
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.Controls.Add(this.pnlStatus);
            this.xPanel7.Controls.Add(this.grdPaQuery);
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Name = "xPanel7";
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
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell21,
            this.xEditGridCell332,
            this.xEditGridCell170,
            this.xEditGridCell10,
            this.xEditGridCell31,
            this.xEditGridCell83,
            this.xEditGridCell87,
            this.xEditGridCell409,
            this.xEditGridCell5,
            this.xEditGridCell410,
            this.xEditGridCell165,
            this.xEditGridCell62,
            this.xEditGridCell173,
            this.xEditGridCell270,
            this.xEditGridCell177});
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
            this.grdPaQuery.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPaQuery.TabStop = false;
            this.grdPaQuery.ToolTipActive = true;
            this.grdPaQuery.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdPaQuery_ItemValueChanging);
            this.grdPaQuery.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaQuery_RowFocusChanged);
            this.grdPaQuery.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPaQuery_GridCellPainting);
            this.grdPaQuery.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaQuery_QueryStarting);
            this.grdPaQuery.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPaQuery_QueryEnd);
            this.grdPaQuery.Click += new System.EventHandler(this.grdPaQuery_Click);
            this.grdPaQuery.DoubleClick += new System.EventHandler(this.grdPaQuery_DoubleClick);
            this.grdPaQuery.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPaQuery_MouseDown);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 70;
            this.xEditGridCell1.Col = 8;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.SuppressRepeating = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.CellWidth = 85;
            this.xEditGridCell2.Col = 9;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.SuppressRepeating = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "sex";
            this.xEditGridCell3.CellWidth = 30;
            this.xEditGridCell3.Col = 11;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "age";
            this.xEditGridCell4.CellWidth = 28;
            this.xEditGridCell4.Col = 12;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "resident";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "doctor_name";
            this.xEditGridCell7.Col = 10;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "magam_yn";
            this.xEditGridCell21.CellWidth = 25;
            this.xEditGridCell21.Col = 1;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell21.EnableSort = true;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellName = "ho_dong_name";
            this.xEditGridCell170.CellWidth = 42;
            this.xEditGridCell170.Col = 6;
            this.xEditGridCell170.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell170, "xEditGridCell170");
            this.xEditGridCell170.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "append_yn";
            this.xEditGridCell10.CellWidth = 30;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "juninp_yn";
            this.xEditGridCell31.CellWidth = 28;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "hope_date";
            this.xEditGridCell83.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell83.Col = 4;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsReadOnly = true;
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
            this.xEditGridCell409.IsUpdatable = false;
            this.xEditGridCell409.IsUpdCol = false;
            this.xEditGridCell409.IsVisible = false;
            this.xEditGridCell409.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "toiwon_yn";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell410
            // 
            this.xEditGridCell410.CellName = "gwa";
            this.xEditGridCell410.Col = -1;
            this.xEditGridCell410.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell410, "xEditGridCell410");
            this.xEditGridCell410.IsVisible = false;
            this.xEditGridCell410.Row = -1;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.CellName = "magam_bunryu";
            this.xEditGridCell165.CellWidth = 30;
            this.xEditGridCell165.Col = 2;
            this.xEditGridCell165.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6});
            this.xEditGridCell165.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell165.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell165, "xEditGridCell165");
            this.xEditGridCell165.IsReadOnly = true;
            this.xEditGridCell165.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "1";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "2";
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "order_date";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell62.Col = 3;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.CellName = "ho_code";
            this.xEditGridCell173.CellWidth = 32;
            this.xEditGridCell173.Col = 7;
            this.xEditGridCell173.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell173, "xEditGridCell173");
            this.xEditGridCell173.IsReadOnly = true;
            // 
            // xEditGridCell270
            // 
            this.xEditGridCell270.CellName = "act_buseo";
            this.xEditGridCell270.Col = -1;
            this.xEditGridCell270.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell270, "xEditGridCell270");
            this.xEditGridCell270.IsVisible = false;
            this.xEditGridCell270.Row = -1;
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellName = "jubsu_date";
            this.xEditGridCell177.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell177.Col = 5;
            this.xEditGridCell177.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell177.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell177, "xEditGridCell177");
            this.xEditGridCell177.IsReadOnly = true;
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
            this.xEditGridCell18,
            this.xEditGridCell70,
            this.xEditGridCell19,
            this.xEditGridCell65,
            this.xEditGridCell38,
            this.xEditGridCell64,
            this.xEditGridCell60,
            this.xEditGridCell20,
            this.xEditGridCell39,
            this.xEditGridCell69,
            this.xEditGridCell58,
            this.xEditGridCell68,
            this.xEditGridCell66,
            this.xEditGridCell71,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell17,
            this.xEditGridCell59,
            this.xEditGridCell67,
            this.xEditGridCell72,
            this.xEditGridCell74,
            this.xEditGridCell73,
            this.xEditGridCell315,
            this.xEditGridCell319,
            this.xEditGridCell317,
            this.xEditGridCell61,
            this.xEditGridCell321,
            this.xEditGridCell334,
            this.xEditGridCell335,
            this.xEditGridCell134,
            this.xEditGridCell135,
            this.xEditGridCell140,
            this.xEditGridCell162,
            this.xEditGridCell268});
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
            this.grdMiMagamOrder.TabStop = false;
            this.grdMiMagamOrder.ToolTipActive = true;
            this.grdMiMagamOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMiMagamOrder_GridCellPainting);
            this.grdMiMagamOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPackPowder_GridColumnChanged);
            this.grdMiMagamOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMiMagamOrder_QueryStarting);
            this.grdMiMagamOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMiMagamOrder_QueryEnd);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "order_date";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell18.CellWidth = 77;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.SuppressRepeating = true;
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
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "jaeryo_code";
            this.xEditGridCell19.CellWidth = 77;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "jaeryo_name";
            this.xEditGridCell65.CellWidth = 265;
            this.xEditGridCell65.Col = 2;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsUpdCol = false;
            this.xEditGridCell65.RowSpan = 2;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "ord_suryang";
            this.xEditGridCell38.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell38.CellWidth = 30;
            this.xEditGridCell38.Col = 3;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdCol = false;
            this.xEditGridCell38.RowSpan = 2;
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
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "dv";
            this.xEditGridCell60.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell60.CellWidth = 22;
            this.xEditGridCell60.Col = 5;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsUpdCol = false;
            this.xEditGridCell60.Row = 1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "nalsu";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.CellWidth = 22;
            this.xEditGridCell20.Col = 7;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.RowSpan = 2;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "order_danui";
            this.xEditGridCell39.CellWidth = 50;
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdCol = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "danui_name";
            this.xEditGridCell69.CellWidth = 51;
            this.xEditGridCell69.Col = 6;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsUpdCol = false;
            this.xEditGridCell69.RowSpan = 2;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "bogyong_code";
            this.xEditGridCell58.CellWidth = 197;
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsReadOnly = true;
            this.xEditGridCell58.IsUpdCol = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "bogyong_name";
            this.xEditGridCell68.CellWidth = 115;
            this.xEditGridCell68.Col = 8;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.IsUpdCol = false;
            this.xEditGridCell68.RowSpan = 2;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "powder_yn";
            this.xEditGridCell66.CellWidth = 22;
            this.xEditGridCell66.Col = 10;
            this.xEditGridCell66.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsUpdCol = false;
            this.xEditGridCell66.RowSpan = 2;
            this.xEditGridCell66.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellLen = 100;
            this.xEditGridCell71.CellName = "remark";
            this.xEditGridCell71.CellWidth = 45;
            this.xEditGridCell71.Col = 12;
            this.xEditGridCell71.DisplayMemoText = true;
            this.xEditGridCell71.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsReadOnly = true;
            this.xEditGridCell71.IsUpdCol = false;
            this.xEditGridCell71.RowSpan = 2;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "dv_1";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "dv_2";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "dv_3";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "dv_4";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "dv_5";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsReadOnly = true;
            this.xEditGridCell59.IsUpdCol = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "hubal_change_yn";
            this.xEditGridCell67.CellWidth = 21;
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsUpdCol = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            this.xEditGridCell67.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "pharmacy";
            this.xEditGridCell72.CellWidth = 30;
            this.xEditGridCell72.Col = 11;
            this.xEditGridCell72.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            this.xEditGridCell72.IsUpdCol = false;
            this.xEditGridCell72.RowSpan = 2;
            this.xEditGridCell72.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "drg_pack_yn";
            this.xEditGridCell74.CellWidth = 21;
            this.xEditGridCell74.Col = 9;
            this.xEditGridCell74.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsUpdCol = false;
            this.xEditGridCell74.RowSpan = 2;
            this.xEditGridCell74.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "jusa";
            this.xEditGridCell73.CellWidth = 43;
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsReadOnly = true;
            this.xEditGridCell73.IsUpdCol = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            this.xEditGridCell73.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "append_yn";
            this.xEditGridCell61.CellWidth = 21;
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsUpdatable = false;
            this.xEditGridCell61.IsUpdCol = false;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
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
            this.xEditGridCell134.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            // xEditGridCell268
            // 
            this.xEditGridCell268.CellName = "brought_drg_yn";
            this.xEditGridCell268.Col = -1;
            this.xEditGridCell268.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell268, "xEditGridCell268");
            this.xEditGridCell268.IsReadOnly = true;
            this.xEditGridCell268.IsVisible = false;
            this.xEditGridCell268.Row = -1;
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
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
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
            this.xEditGridCell100,
            this.xEditGridCell99,
            this.xEditGridCell316,
            this.xEditGridCell320,
            this.xEditGridCell318,
            this.xEditGridCell37,
            this.xEditGridCell322,
            this.xEditGridCell88,
            this.xEditGridCell333,
            this.xEditGridCell132,
            this.xEditGridCell133,
            this.xEditGridCell139,
            this.xEditGridCell163});
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
            this.grdMiMagamJUSAOrder.TabStop = false;
            this.grdMiMagamJUSAOrder.ToolTipActive = true;
            this.grdMiMagamJUSAOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMiMagamJUSAOrder_GridCellPainting);
            this.grdMiMagamJUSAOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMiMagamOrder_QueryStarting);
            this.grdMiMagamJUSAOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMiMagamJUSAOrder_QueryEnd);
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "order_date";
            this.xEditGridCell75.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell75.CellWidth = 77;
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsReadOnly = true;
            this.xEditGridCell75.IsUpdCol = false;
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            this.xEditGridCell75.SuppressRepeating = true;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "mix_group";
            this.xEditGridCell76.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell76.CellWidth = 20;
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsReadOnly = true;
            this.xEditGridCell76.IsUpdCol = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            this.xEditGridCell76.SuppressRepeating = true;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "jaeryo_code";
            this.xEditGridCell77.CellWidth = 77;
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsReadOnly = true;
            this.xEditGridCell77.IsUpdCol = false;
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            this.xEditGridCell77.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "jaeryo_name";
            this.xEditGridCell78.CellWidth = 300;
            this.xEditGridCell78.Col = 2;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsReadOnly = true;
            this.xEditGridCell78.IsUpdCol = false;
            this.xEditGridCell78.RowSpan = 2;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "ord_suryang";
            this.xEditGridCell79.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell79.CellWidth = 40;
            this.xEditGridCell79.Col = 3;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsReadOnly = true;
            this.xEditGridCell79.IsUpdCol = false;
            this.xEditGridCell79.RowSpan = 2;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "dv_time";
            this.xEditGridCell80.CellWidth = 20;
            this.xEditGridCell80.Col = 4;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsReadOnly = true;
            this.xEditGridCell80.IsUpdCol = false;
            this.xEditGridCell80.Row = 1;
            this.xEditGridCell80.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "dv";
            this.xEditGridCell81.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell81.CellWidth = 22;
            this.xEditGridCell81.Col = 5;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.IsUpdCol = false;
            this.xEditGridCell81.Row = 1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "nalsu";
            this.xEditGridCell82.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell82.CellWidth = 22;
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.IsUpdCol = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "order_danui";
            this.xEditGridCell84.CellWidth = 50;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsReadOnly = true;
            this.xEditGridCell84.IsUpdCol = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "danui_name";
            this.xEditGridCell85.CellWidth = 65;
            this.xEditGridCell85.Col = 6;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsUpdCol = false;
            this.xEditGridCell85.RowSpan = 2;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "bogyong_code";
            this.xEditGridCell86.CellWidth = 197;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.IsUpdCol = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "bogyong_name";
            this.xEditGridCell89.CellWidth = 50;
            this.xEditGridCell89.Col = 8;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.RowSpan = 2;
            this.xEditGridCell89.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "powder_yn";
            this.xEditGridCell90.CellWidth = 19;
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.IsUpdCol = false;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            this.xEditGridCell90.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellLen = 100;
            this.xEditGridCell91.CellName = "remark";
            this.xEditGridCell91.CellWidth = 50;
            this.xEditGridCell91.Col = 9;
            this.xEditGridCell91.DisplayMemoText = true;
            this.xEditGridCell91.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsUpdCol = false;
            this.xEditGridCell91.RowSpan = 2;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "dv_1";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsUpdCol = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "dv_2";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsUpdCol = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "dv_3";
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
            this.xEditGridCell95.CellName = "dv_4";
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
            this.xEditGridCell96.CellName = "dv_5";
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.IsUpdCol = false;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "hubal_change_yn";
            this.xEditGridCell97.CellWidth = 19;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsUpdCol = false;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            this.xEditGridCell97.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "pharmacy";
            this.xEditGridCell98.CellWidth = 30;
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsUpdCol = false;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            this.xEditGridCell98.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "drg_pack_yn";
            this.xEditGridCell100.CellWidth = 19;
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            this.xEditGridCell100.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "jusa";
            this.xEditGridCell99.CellWidth = 97;
            this.xEditGridCell99.Col = 7;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsUpdCol = false;
            this.xEditGridCell99.RowSpan = 2;
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
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "append_yn";
            this.xEditGridCell37.CellWidth = 19;
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
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
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "hope_date";
            this.xEditGridCell88.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsUpdCol = false;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
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
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "group_ser";
            this.xEditGridCell132.CellWidth = 25;
            this.xEditGridCell132.Col = 1;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsReadOnly = true;
            this.xEditGridCell132.IsUpdatable = false;
            this.xEditGridCell132.IsUpdCol = false;
            this.xEditGridCell132.RowSpan = 2;
            this.xEditGridCell132.SuppressRepeating = true;
            this.xEditGridCell132.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "dc_yn";
            this.xEditGridCell133.Col = -1;
            this.xEditGridCell133.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsUpdCol = false;
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "order_gubun";
            this.xEditGridCell139.Col = -1;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.IsUpdCol = false;
            this.xEditGridCell139.IsVisible = false;
            this.xEditGridCell139.Row = -1;
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
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 20;
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.btnCommentForm);
            this.xPanel1.Controls.Add(this.cbxJusaLabelYN);
            this.xPanel1.Controls.Add(this.cbxATCYN);
            this.xPanel1.Controls.Add(this.btnListMimagam);
            this.xPanel1.Controls.Add(this.btnMagam);
            this.xPanel1.Controls.Add(this.btnAllUnCheck);
            this.xPanel1.Controls.Add(this.btnAllCheck);
            this.xPanel1.Controls.Add(this.btnHopeTimeMake);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnCommentForm
            // 
            resources.ApplyResources(this.btnCommentForm, "btnCommentForm");
            this.btnCommentForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.btnCommentForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCommentForm.ImageIndex = 13;
            this.btnCommentForm.ImageList = this.ImageList;
            this.btnCommentForm.Name = "btnCommentForm";
            this.btnCommentForm.Click += new System.EventHandler(this.btnCommentForm_Click);
            // 
            // cbxJusaLabelYN
            // 
            resources.ApplyResources(this.cbxJusaLabelYN, "cbxJusaLabelYN");
            this.cbxJusaLabelYN.CheckedText = "注LABEL印刷";
            this.cbxJusaLabelYN.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.cbxJusaLabelYN.Name = "cbxJusaLabelYN";
            this.cbxJusaLabelYN.TabStop = false;
            this.cbxJusaLabelYN.UnCheckedText = "注LABEL未印刷";
            this.cbxJusaLabelYN.UseVisualStyleBackColor = false;
            // 
            // cbxATCYN
            // 
            resources.ApplyResources(this.cbxATCYN, "cbxATCYN");
            this.cbxATCYN.CheckedText = "ATC転送中";
            this.cbxATCYN.Name = "cbxATCYN";
            this.cbxATCYN.TabStop = false;
            this.cbxATCYN.UnCheckedText = "ATC未転送";
            this.cbxATCYN.UseVisualStyleBackColor = false;
            // 
            // btnListMimagam
            // 
            resources.ApplyResources(this.btnListMimagam, "btnListMimagam");
            this.btnListMimagam.IsVisiblePreview = false;
            this.btnListMimagam.IsVisibleReset = false;
            this.btnListMimagam.Name = "btnListMimagam";
            this.btnListMimagam.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnListMimagam.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnListMimagam_ButtonClick);
            // 
            // btnMagam
            // 
            resources.ApplyResources(this.btnMagam, "btnMagam");
            this.btnMagam.ImageIndex = 4;
            this.btnMagam.ImageList = this.ImageList;
            this.btnMagam.Name = "btnMagam";
            this.btnMagam.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnMagam.Click += new System.EventHandler(this.btnMagam_Click);
            // 
            // btnAllUnCheck
            // 
            resources.ApplyResources(this.btnAllUnCheck, "btnAllUnCheck");
            this.btnAllUnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllUnCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllUnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllUnCheck.Image")));
            this.btnAllUnCheck.Name = "btnAllUnCheck";
            this.btnAllUnCheck.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnAllUnCheck.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // btnAllCheck
            // 
            resources.ApplyResources(this.btnAllCheck, "btnAllCheck");
            this.btnAllCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllCheck.Image")));
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnAllCheck.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnHopeTimeMake
            // 
            resources.ApplyResources(this.btnHopeTimeMake, "btnHopeTimeMake");
            this.btnHopeTimeMake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.btnHopeTimeMake.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHopeTimeMake.ImageIndex = 7;
            this.btnHopeTimeMake.ImageList = this.ImageList;
            this.btnHopeTimeMake.Name = "btnHopeTimeMake";
            this.btnHopeTimeMake.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnHopeTimeMake.Click += new System.EventHandler(this.btnHopeTimeMake_Click);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.xPanel12);
            this.tabPage2.Controls.Add(this.xPanel4);
            this.tabPage2.ImageIndex = 15;
            this.tabPage2.ImageList = this.ImageList;
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            // 
            // xPanel12
            // 
            resources.ApplyResources(this.xPanel12, "xPanel12");
            this.xPanel12.Controls.Add(this.xPanel9);
            this.xPanel12.Controls.Add(this.xPanel10);
            this.xPanel12.DrawBorder = true;
            this.xPanel12.Name = "xPanel12";
            // 
            // xPanel9
            // 
            resources.ApplyResources(this.xPanel9, "xPanel9");
            this.xPanel9.Controls.Add(this.grdMagamPaQuery);
            this.xPanel9.DrawBorder = true;
            this.xPanel9.Name = "xPanel9";
            // 
            // grdMagamPaQuery
            // 
            resources.ApplyResources(this.grdMagamPaQuery, "grdMagamPaQuery");
            this.grdMagamPaQuery.ApplyPaintEventToAllColumn = true;
            this.grdMagamPaQuery.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell167});
            this.grdMagamPaQuery.ColPerLine = 6;
            this.grdMagamPaQuery.ColResizable = true;
            this.grdMagamPaQuery.Cols = 7;
            this.grdMagamPaQuery.ExecuteQuery = null;
            this.grdMagamPaQuery.FixedCols = 1;
            this.grdMagamPaQuery.FixedRows = 1;
            this.grdMagamPaQuery.HeaderHeights.Add(39);
            this.grdMagamPaQuery.Name = "grdMagamPaQuery";
            this.grdMagamPaQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMagamPaQuery.ParamList")));
            this.grdMagamPaQuery.QuerySQL = resources.GetString("grdMagamPaQuery.QuerySQL");
            this.grdMagamPaQuery.RowHeaderVisible = true;
            this.grdMagamPaQuery.Rows = 2;
            this.grdMagamPaQuery.TabStop = false;
            this.grdMagamPaQuery.ToolTipActive = true;
            this.grdMagamPaQuery.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMagamPaQuery_RowFocusChanged);
            this.grdMagamPaQuery.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMagamPaQuery_QueryStarting);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "magam_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.CellWidth = 92;
            this.xEditGridCell22.Col = 2;
            this.xEditGridCell22.EnableSort = true;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "magam_ser";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell23.CellWidth = 32;
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "magam_time";
            this.xEditGridCell24.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell24.CellWidth = 54;
            this.xEditGridCell24.Col = 3;
            this.xEditGridCell24.EnableSort = true;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.Mask = "HH:MI";
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "magam_gubun";
            this.xEditGridCell25.CellWidth = 1;
            this.xEditGridCell25.Col = 4;
            this.xEditGridCell25.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell25.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell25.EnableSort = true;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "11";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "21";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "12";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "22";
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell26.CellName = "magam_cancel";
            this.xEditGridCell26.CellWidth = 30;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.EnableSort = true;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell26.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "acting_flag";
            this.xEditGridCell28.CellWidth = 123;
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell29.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell29.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell29.CellName = "min_drg_bunho";
            this.xEditGridCell29.CellWidth = 40;
            this.xEditGridCell29.Col = 5;
            this.xEditGridCell29.EnableSort = true;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell30.AlterateRowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell30.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell30.CellName = "max_drg_bunho";
            this.xEditGridCell30.CellWidth = 40;
            this.xEditGridCell30.Col = 6;
            this.xEditGridCell30.EnableSort = true;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.RowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "magam_bunryu";
            this.xEditGridCell167.CellWidth = 56;
            this.xEditGridCell167.Col = 1;
            this.xEditGridCell167.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem16,
            this.xComboItem17});
            this.xEditGridCell167.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell167.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell167, "xEditGridCell167");
            this.xEditGridCell167.IsReadOnly = true;
            // 
            // xComboItem16
            // 
            resources.ApplyResources(this.xComboItem16, "xComboItem16");
            this.xComboItem16.ValueItem = "1";
            // 
            // xComboItem17
            // 
            resources.ApplyResources(this.xComboItem17, "xComboItem17");
            this.xComboItem17.ValueItem = "2";
            // 
            // xPanel10
            // 
            resources.ApplyResources(this.xPanel10, "xPanel10");
            this.xPanel10.Controls.Add(this.xPanel5);
            this.xPanel10.Controls.Add(this.grdDrgBunhoList);
            this.xPanel10.DrawBorder = true;
            this.xPanel10.Name = "xPanel10";
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.grdMagamOrder);
            this.xPanel5.Controls.Add(this.grdMagamJUSAOrder);
            this.xPanel5.Name = "xPanel5";
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
            this.xEditGridCell258,
            this.xEditGridCell131,
            this.xEditGridCell149,
            this.xEditGridCell150,
            this.xEditGridCell151,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell157,
            this.xEditGridCell269});
            this.grdMagamOrder.ColPerLine = 12;
            this.grdMagamOrder.Cols = 13;
            this.grdMagamOrder.ControlBinding = true;
            this.grdMagamOrder.ExecuteQuery = null;
            this.grdMagamOrder.FixedCols = 1;
            this.grdMagamOrder.FixedRows = 2;
            this.grdMagamOrder.HeaderHeights.Add(39);
            this.grdMagamOrder.HeaderHeights.Add(0);
            this.grdMagamOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader6});
            this.grdMagamOrder.Name = "grdMagamOrder";
            this.grdMagamOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMagamOrder.ParamList")));
            this.grdMagamOrder.QuerySQL = resources.GetString("grdMagamOrder.QuerySQL");
            this.grdMagamOrder.RowHeaderVisible = true;
            this.grdMagamOrder.Rows = 3;
            this.grdMagamOrder.TabStop = false;
            this.grdMagamOrder.ToolTipActive = true;
            this.grdMagamOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMagamOrder_GridCellPainting);
            this.grdMagamOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPackPowder_GridColumnChanged);
            this.grdMagamOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMagamOrder_QueryStarting);
            this.grdMagamOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamOrder_QueryEnd);
            this.grdMagamOrder.DoubleClick += new System.EventHandler(this.grdMagamOrder_DoubleClick);
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
            this.xEditGridCell27.SuppressRepeating = true;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "group_ser";
            this.xEditGridCell32.CellWidth = 25;
            this.xEditGridCell32.Col = 1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.SuppressRepeating = true;
            this.xEditGridCell32.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.xEditGridCell34.CellWidth = 245;
            this.xEditGridCell34.Col = 2;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "ord_suryang";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell35.CellWidth = 58;
            this.xEditGridCell35.Col = 3;
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
            this.xEditGridCell36.Col = 4;
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
            this.xEditGridCell40.Col = 5;
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
            this.xEditGridCell41.CellWidth = 38;
            this.xEditGridCell41.Col = 7;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "order_danui";
            this.xEditGridCell42.CellWidth = 50;
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
            this.xEditGridCell43.CellWidth = 50;
            this.xEditGridCell43.Col = 6;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsUpdCol = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "bogyong_code";
            this.xEditGridCell44.CellWidth = 197;
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
            this.xEditGridCell45.CellWidth = 120;
            this.xEditGridCell45.Col = 8;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsUpdCol = false;
            this.xEditGridCell45.SuppressRepeating = true;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "powder_yn";
            this.xEditGridCell46.CellWidth = 46;
            this.xEditGridCell46.Col = 10;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellLen = 100;
            this.xEditGridCell47.CellName = "remark";
            this.xEditGridCell47.CellWidth = 50;
            this.xEditGridCell47.Col = 12;
            this.xEditGridCell47.DisplayMemoText = true;
            this.xEditGridCell47.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsUpdCol = false;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "dv_1";
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
            this.xEditGridCell53.CellWidth = 25;
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
            this.xEditGridCell54.CellWidth = 53;
            this.xEditGridCell54.Col = 11;
            this.xEditGridCell54.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "drg_pack_yn";
            this.xEditGridCell55.CellWidth = 39;
            this.xEditGridCell55.Col = 9;
            this.xEditGridCell55.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "jusa";
            this.xEditGridCell56.CellWidth = 43;
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
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            this.xEditGridCell123.SuppressRepeating = true;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "drg_bunho";
            this.xEditGridCell126.CellWidth = 40;
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            this.xEditGridCell126.SuppressRepeating = true;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "jubsu_date";
            this.xEditGridCell127.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "bunho";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            this.xEditGridCell129.SuppressRepeating = true;
            // 
            // xEditGridCell258
            // 
            this.xEditGridCell258.CellName = "ho_dong";
            this.xEditGridCell258.CellWidth = 30;
            this.xEditGridCell258.Col = -1;
            this.xEditGridCell258.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell258, "xEditGridCell258");
            this.xEditGridCell258.IsVisible = false;
            this.xEditGridCell258.Row = -1;
            this.xEditGridCell258.SuppressRepeating = true;
            this.xEditGridCell258.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "bannab_yn";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsUpdCol = false;
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "source_fkocs2003";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsUpdCol = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellName = "fkocs2003";
            this.xEditGridCell150.Col = -1;
            this.xEditGridCell150.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell150, "xEditGridCell150");
            this.xEditGridCell150.IsUpdCol = false;
            this.xEditGridCell150.IsVisible = false;
            this.xEditGridCell150.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "hope_date";
            this.xEditGridCell151.Col = -1;
            this.xEditGridCell151.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell151, "xEditGridCell151");
            this.xEditGridCell151.IsUpdCol = false;
            this.xEditGridCell151.IsVisible = false;
            this.xEditGridCell151.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "dc_yn";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell155, "xEditGridCell155");
            this.xEditGridCell155.IsUpdCol = false;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "order_gubun";
            this.xEditGridCell156.Col = -1;
            this.xEditGridCell156.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell156, "xEditGridCell156");
            this.xEditGridCell156.IsUpdCol = false;
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "mix_group";
            this.xEditGridCell157.CellWidth = 20;
            this.xEditGridCell157.Col = -1;
            this.xEditGridCell157.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell157, "xEditGridCell157");
            this.xEditGridCell157.IsUpdCol = false;
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xEditGridCell269
            // 
            this.xEditGridCell269.CellName = "brought_drg_yn";
            this.xEditGridCell269.Col = -1;
            this.xEditGridCell269.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell269, "xEditGridCell269");
            this.xEditGridCell269.IsReadOnly = true;
            this.xEditGridCell269.IsVisible = false;
            this.xEditGridCell269.Row = -1;
            // 
            // xGridHeader6
            // 
            this.xGridHeader6.Col = 4;
            this.xGridHeader6.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader6, "xGridHeader6");
            this.xGridHeader6.HeaderWidth = 22;
            // 
            // grdMagamJUSAOrder
            // 
            this.grdMagamJUSAOrder.AddedHeaderLine = 1;
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
            this.xEditGridCell257,
            this.xEditGridCell144,
            this.xEditGridCell136,
            this.xEditGridCell137,
            this.xEditGridCell145,
            this.xEditGridCell161,
            this.xEditGridCell158,
            this.xEditGridCell159,
            this.xEditGridCell160});
            this.grdMagamJUSAOrder.ColPerLine = 9;
            this.grdMagamJUSAOrder.Cols = 10;
            this.grdMagamJUSAOrder.ControlBinding = true;
            this.grdMagamJUSAOrder.ExecuteQuery = null;
            this.grdMagamJUSAOrder.FixedCols = 1;
            this.grdMagamJUSAOrder.FixedRows = 2;
            this.grdMagamJUSAOrder.HeaderHeights.Add(39);
            this.grdMagamJUSAOrder.HeaderHeights.Add(0);
            this.grdMagamJUSAOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader3});
            this.grdMagamJUSAOrder.Name = "grdMagamJUSAOrder";
            this.grdMagamJUSAOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMagamJUSAOrder.ParamList")));
            this.grdMagamJUSAOrder.QuerySQL = resources.GetString("grdMagamJUSAOrder.QuerySQL");
            this.grdMagamJUSAOrder.RowHeaderVisible = true;
            this.grdMagamJUSAOrder.Rows = 3;
            this.grdMagamJUSAOrder.TabStop = false;
            this.grdMagamJUSAOrder.ToolTipActive = true;
            this.grdMagamJUSAOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMagamJUSAOrder_GridCellPainting);
            this.grdMagamJUSAOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMagamOrder_QueryStarting);
            this.grdMagamJUSAOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamJUSAOrder_QueryEnd);
            this.grdMagamJUSAOrder.DoubleClick += new System.EventHandler(this.grdMagamJUSAOrder_DoubleClick);
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
            this.xEditGridCell101.CellName = "mix_group";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.CellWidth = 20;
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
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
            this.xEditGridCell103.CellWidth = 295;
            this.xEditGridCell103.Col = 2;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.IsUpdCol = false;
            this.xEditGridCell103.RowSpan = 2;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ord_suryang";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell104.CellWidth = 40;
            this.xEditGridCell104.Col = 3;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsReadOnly = true;
            this.xEditGridCell104.IsUpdCol = false;
            this.xEditGridCell104.RowSpan = 2;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "dv_time";
            this.xEditGridCell105.CellWidth = 22;
            this.xEditGridCell105.Col = 4;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsUpdCol = false;
            this.xEditGridCell105.Row = 1;
            this.xEditGridCell105.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "dv";
            this.xEditGridCell106.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell106.CellWidth = 22;
            this.xEditGridCell106.Col = 5;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsReadOnly = true;
            this.xEditGridCell106.IsUpdCol = false;
            this.xEditGridCell106.Row = 1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "nalsu";
            this.xEditGridCell107.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell107.CellWidth = 22;
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsReadOnly = true;
            this.xEditGridCell107.IsUpdCol = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "order_danui";
            this.xEditGridCell108.CellWidth = 50;
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
            this.xEditGridCell109.Col = 6;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsReadOnly = true;
            this.xEditGridCell109.IsUpdCol = false;
            this.xEditGridCell109.RowSpan = 2;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "bogyong_code";
            this.xEditGridCell110.CellWidth = 197;
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
            this.xEditGridCell111.CellWidth = 50;
            this.xEditGridCell111.Col = 8;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsUpdCol = false;
            this.xEditGridCell111.RowSpan = 2;
            this.xEditGridCell111.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "powder_yn";
            this.xEditGridCell112.CellWidth = 25;
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
            this.xEditGridCell113.CellWidth = 78;
            this.xEditGridCell113.Col = 9;
            this.xEditGridCell113.DisplayMemoText = true;
            this.xEditGridCell113.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsReadOnly = true;
            this.xEditGridCell113.IsUpdCol = false;
            this.xEditGridCell113.RowSpan = 2;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "dv_1";
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
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            this.xEditGridCell119.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "pharmacy";
            this.xEditGridCell120.CellWidth = 30;
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
            this.xEditGridCell121.CellWidth = 25;
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
            this.xEditGridCell122.CellWidth = 95;
            this.xEditGridCell122.Col = 7;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsReadOnly = true;
            this.xEditGridCell122.RowSpan = 2;
            this.xEditGridCell122.SuppressRepeating = true;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "suname";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            this.xEditGridCell124.SuppressRepeating = true;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "drg_bunho";
            this.xEditGridCell125.CellWidth = 40;
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            this.xEditGridCell125.SuppressRepeating = true;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "jubsu_date";
            this.xEditGridCell128.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "bunho";
            this.xEditGridCell130.CellWidth = 75;
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            this.xEditGridCell130.SuppressRepeating = true;
            // 
            // xEditGridCell257
            // 
            this.xEditGridCell257.CellName = "ho_dong";
            this.xEditGridCell257.CellWidth = 29;
            this.xEditGridCell257.Col = -1;
            this.xEditGridCell257.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell257, "xEditGridCell257");
            this.xEditGridCell257.IsVisible = false;
            this.xEditGridCell257.Row = -1;
            this.xEditGridCell257.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "hope_date";
            this.xEditGridCell144.Col = -1;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsUpdCol = false;
            this.xEditGridCell144.IsVisible = false;
            this.xEditGridCell144.Row = -1;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "group_ser";
            this.xEditGridCell136.CellWidth = 25;
            this.xEditGridCell136.Col = 1;
            this.xEditGridCell136.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsReadOnly = true;
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsUpdCol = false;
            this.xEditGridCell136.RowSpan = 2;
            this.xEditGridCell136.SuppressRepeating = true;
            this.xEditGridCell136.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "dc_yn";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsUpdCol = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "order_gubun";
            this.xEditGridCell145.Col = -1;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsUpdCol = false;
            this.xEditGridCell145.IsVisible = false;
            this.xEditGridCell145.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellName = "query_seq";
            this.xEditGridCell161.Col = -1;
            this.xEditGridCell161.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell161, "xEditGridCell161");
            this.xEditGridCell161.IsUpdCol = false;
            this.xEditGridCell161.IsVisible = false;
            this.xEditGridCell161.Row = -1;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellName = "bannab_yn";
            this.xEditGridCell158.Col = -1;
            this.xEditGridCell158.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell158, "xEditGridCell158");
            this.xEditGridCell158.IsUpdCol = false;
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellName = "source_fkocs2003";
            this.xEditGridCell159.Col = -1;
            this.xEditGridCell159.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell159, "xEditGridCell159");
            this.xEditGridCell159.IsUpdCol = false;
            this.xEditGridCell159.IsVisible = false;
            this.xEditGridCell159.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "fkocs2003";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell160, "xEditGridCell160");
            this.xEditGridCell160.IsUpdCol = false;
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 4;
            this.xGridHeader3.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            this.xGridHeader3.HeaderWidth = 22;
            // 
            // grdDrgBunhoList
            // 
            resources.ApplyResources(this.grdDrgBunhoList, "grdDrgBunhoList");
            this.grdDrgBunhoList.ApplyPaintEventToAllColumn = true;
            this.grdDrgBunhoList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell176,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell11,
            this.xEditGridCell16,
            this.xEditGridCell174,
            this.xEditGridCell175,
            this.xEditGridCell12,
            this.xEditGridCell411,
            this.xEditGridCell168,
            this.xEditGridCell63,
            this.xEditGridCell169});
            this.grdDrgBunhoList.ColPerLine = 7;
            this.grdDrgBunhoList.Cols = 7;
            this.grdDrgBunhoList.ExecuteQuery = null;
            this.grdDrgBunhoList.FixedRows = 1;
            this.grdDrgBunhoList.HeaderHeights.Add(39);
            this.grdDrgBunhoList.Name = "grdDrgBunhoList";
            this.grdDrgBunhoList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrgBunhoList.ParamList")));
            this.grdDrgBunhoList.QuerySQL = resources.GetString("grdDrgBunhoList.QuerySQL");
            this.grdDrgBunhoList.Rows = 2;
            this.grdDrgBunhoList.TabStop = false;
            this.grdDrgBunhoList.ToolTipActive = true;
            this.grdDrgBunhoList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdDrgBunhoList_RowFocusChanged);
            this.grdDrgBunhoList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDrgBunhoList_GridCellPainting);
            this.grdDrgBunhoList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrgBunhoList_QueryStarting);
            this.grdDrgBunhoList.DoubleClick += new System.EventHandler(this.grdDrgBunhoList_DoubleClick);
            this.grdDrgBunhoList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdDrgBunhoList_MouseDown);
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.CellName = "order_date";
            this.xEditGridCell176.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell176.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell176, "xEditGridCell176");
            this.xEditGridCell176.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jubsu_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell9.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell9.CellName = "drg_bunho";
            this.xEditGridCell9.CellWidth = 68;
            this.xEditGridCell9.Col = 4;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bunho";
            this.xEditGridCell11.CellWidth = 69;
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.SuppressRepeating = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "ho_dong";
            this.xEditGridCell16.CellWidth = 40;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell174
            // 
            this.xEditGridCell174.CellName = "ho_dong_name";
            this.xEditGridCell174.CellWidth = 50;
            this.xEditGridCell174.Col = 2;
            this.xEditGridCell174.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell174, "xEditGridCell174");
            this.xEditGridCell174.IsReadOnly = true;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellName = "ho_code";
            this.xEditGridCell175.CellWidth = 76;
            this.xEditGridCell175.Col = 3;
            this.xEditGridCell175.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell175, "xEditGridCell175");
            this.xEditGridCell175.IsReadOnly = true;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "suname";
            this.xEditGridCell12.Col = 6;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.SuppressRepeating = true;
            // 
            // xEditGridCell411
            // 
            this.xEditGridCell411.CellName = "fkinp1001";
            this.xEditGridCell411.Col = -1;
            this.xEditGridCell411.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell411, "xEditGridCell411");
            this.xEditGridCell411.IsUpdatable = false;
            this.xEditGridCell411.IsUpdCol = false;
            this.xEditGridCell411.IsVisible = false;
            this.xEditGridCell411.Row = -1;
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellName = "hope_date";
            this.xEditGridCell168.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell168.Col = 1;
            this.xEditGridCell168.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell168, "xEditGridCell168");
            this.xEditGridCell168.IsReadOnly = true;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "mix_date";
            this.xEditGridCell63.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellName = "magam_bunryu";
            this.xEditGridCell169.Col = -1;
            this.xEditGridCell169.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell169, "xEditGridCell169");
            this.xEditGridCell169.IsVisible = false;
            this.xEditGridCell169.Row = -1;
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.btnPrintAdmMedi);
            this.xPanel4.Controls.Add(this.btnAtcTrans);
            this.xPanel4.Controls.Add(this.btnLable);
            this.xPanel4.Controls.Add(this.btnComment);
            this.xPanel4.Controls.Add(this.btnListMagam);
            this.xPanel4.Controls.Add(this.btnPrint);
            this.xPanel4.Controls.Add(this.btnRangeCancel);
            this.xPanel4.Controls.Add(this.btnNumberCancel);
            this.xPanel4.Controls.Add(this.xButton2);
            this.xPanel4.Name = "xPanel4";
            // 
            // btnPrintAdmMedi
            // 
            resources.ApplyResources(this.btnPrintAdmMedi, "btnPrintAdmMedi");
            this.btnPrintAdmMedi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintAdmMedi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintAdmMedi.ImageIndex = 1;
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
            // btnLable
            // 
            resources.ApplyResources(this.btnLable, "btnLable");
            this.btnLable.ImageIndex = 1;
            this.btnLable.ImageList = this.ImageList;
            this.btnLable.Name = "btnLable";
            this.btnLable.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnLable.Click += new System.EventHandler(this.btnLable_Click);
            // 
            // btnComment
            // 
            resources.ApplyResources(this.btnComment, "btnComment");
            this.btnComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.btnComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnComment.ImageIndex = 13;
            this.btnComment.ImageList = this.ImageList;
            this.btnComment.Name = "btnComment";
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // btnListMagam
            // 
            resources.ApplyResources(this.btnListMagam, "btnListMagam");
            this.btnListMagam.IsVisiblePreview = false;
            this.btnListMagam.IsVisibleReset = false;
            this.btnListMagam.Name = "btnListMagam";
            this.btnListMagam.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnListMagam.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnListMagam_ButtonClick);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ImageIndex = 1;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRangeCancel
            // 
            resources.ApplyResources(this.btnRangeCancel, "btnRangeCancel");
            this.btnRangeCancel.ImageIndex = 4;
            this.btnRangeCancel.ImageList = this.ImageList;
            this.btnRangeCancel.Name = "btnRangeCancel";
            this.btnRangeCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRangeCancel.Click += new System.EventHandler(this.btnRangeCancel_Click);
            // 
            // btnNumberCancel
            // 
            resources.ApplyResources(this.btnNumberCancel, "btnNumberCancel");
            this.btnNumberCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.btnNumberCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNumberCancel.ImageIndex = 4;
            this.btnNumberCancel.ImageList = this.ImageList;
            this.btnNumberCancel.Name = "btnNumberCancel";
            this.btnNumberCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnNumberCancel.Click += new System.EventHandler(this.btnNumberCancel_Click);
            // 
            // xButton2
            // 
            resources.ApplyResources(this.xButton2, "xButton2");
            this.xButton2.ImageIndex = 6;
            this.xButton2.ImageList = this.ImageList;
            this.xButton2.Name = "xButton2";
            this.xButton2.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xButton2.Click += new System.EventHandler(this.xButton2_Click);
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Controls.Add(this.xPanel17);
            this.tabPage5.Controls.Add(this.xPanel16);
            this.tabPage5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage5.ImageIndex = 16;
            this.tabPage5.ImageList = this.ImageList;
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            // 
            // xPanel17
            // 
            resources.ApplyResources(this.xPanel17, "xPanel17");
            this.xPanel17.Controls.Add(this.xPanel18);
            this.xPanel17.Controls.Add(this.xPanel19);
            this.xPanel17.DrawBorder = true;
            this.xPanel17.Name = "xPanel17";
            // 
            // xPanel18
            // 
            resources.ApplyResources(this.xPanel18, "xPanel18");
            this.xPanel18.Controls.Add(this.grdPaDcQuery);
            this.xPanel18.DrawBorder = true;
            this.xPanel18.Name = "xPanel18";
            // 
            // grdPaDcQuery
            // 
            resources.ApplyResources(this.grdPaDcQuery, "grdPaDcQuery");
            this.grdPaDcQuery.ApplyPaintEventToAllColumn = true;
            this.grdPaDcQuery.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell171,
            this.xEditGridCell172,
            this.xEditGridCell178,
            this.xEditGridCell179,
            this.xEditGridCell180,
            this.xEditGridCell181,
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
            this.xEditGridCell267});
            this.grdPaDcQuery.ColPerLine = 12;
            this.grdPaDcQuery.Cols = 13;
            this.grdPaDcQuery.ExecuteQuery = null;
            this.grdPaDcQuery.FixedCols = 1;
            this.grdPaDcQuery.FixedRows = 1;
            this.grdPaDcQuery.HeaderHeights.Add(37);
            this.grdPaDcQuery.Name = "grdPaDcQuery";
            this.grdPaDcQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaDcQuery.ParamList")));
            this.grdPaDcQuery.QuerySQL = resources.GetString("grdPaDcQuery.QuerySQL");
            this.grdPaDcQuery.RowHeaderVisible = true;
            this.grdPaDcQuery.Rows = 2;
            this.grdPaDcQuery.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPaDcQuery.TabStop = false;
            this.grdPaDcQuery.ToolTipActive = true;
            this.grdPaDcQuery.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaDcQuery_RowFocusChanged);
            this.grdPaDcQuery.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaDcQuery_QueryStarting);
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellName = "bunho";
            this.xEditGridCell171.CellWidth = 70;
            this.xEditGridCell171.Col = 8;
            this.xEditGridCell171.EnableSort = true;
            this.xEditGridCell171.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell171, "xEditGridCell171");
            this.xEditGridCell171.IsReadOnly = true;
            this.xEditGridCell171.SuppressRepeating = true;
            this.xEditGridCell171.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellName = "suname";
            this.xEditGridCell172.Col = 9;
            this.xEditGridCell172.EnableSort = true;
            this.xEditGridCell172.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell172, "xEditGridCell172");
            this.xEditGridCell172.IsReadOnly = true;
            this.xEditGridCell172.SuppressRepeating = true;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellName = "sex";
            this.xEditGridCell178.CellWidth = 28;
            this.xEditGridCell178.Col = 12;
            this.xEditGridCell178.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell178, "xEditGridCell178");
            this.xEditGridCell178.IsReadOnly = true;
            this.xEditGridCell178.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell179
            // 
            this.xEditGridCell179.CellName = "age";
            this.xEditGridCell179.CellWidth = 32;
            this.xEditGridCell179.Col = 11;
            this.xEditGridCell179.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell179, "xEditGridCell179");
            this.xEditGridCell179.IsReadOnly = true;
            this.xEditGridCell179.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellName = "resident";
            this.xEditGridCell180.Col = -1;
            this.xEditGridCell180.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell180, "xEditGridCell180");
            this.xEditGridCell180.IsReadOnly = true;
            this.xEditGridCell180.IsVisible = false;
            this.xEditGridCell180.Row = -1;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.CellName = "doctor_name";
            this.xEditGridCell181.Col = 10;
            this.xEditGridCell181.EnableSort = true;
            this.xEditGridCell181.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell181, "xEditGridCell181");
            this.xEditGridCell181.IsReadOnly = true;
            // 
            // xEditGridCell183
            // 
            this.xEditGridCell183.CellName = "ho_dong";
            this.xEditGridCell183.CellWidth = 32;
            this.xEditGridCell183.Col = -1;
            this.xEditGridCell183.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell183, "xEditGridCell183");
            this.xEditGridCell183.IsReadOnly = true;
            this.xEditGridCell183.IsUpdatable = false;
            this.xEditGridCell183.IsUpdCol = false;
            this.xEditGridCell183.IsVisible = false;
            this.xEditGridCell183.Row = -1;
            this.xEditGridCell183.SuppressRepeating = true;
            // 
            // xEditGridCell184
            // 
            this.xEditGridCell184.CellName = "ho_dong_name";
            this.xEditGridCell184.CellWidth = 40;
            this.xEditGridCell184.Col = 5;
            this.xEditGridCell184.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell184, "xEditGridCell184");
            this.xEditGridCell184.IsReadOnly = true;
            // 
            // xEditGridCell185
            // 
            this.xEditGridCell185.CellName = "append_yn";
            this.xEditGridCell185.CellWidth = 30;
            this.xEditGridCell185.Col = -1;
            this.xEditGridCell185.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell185, "xEditGridCell185");
            this.xEditGridCell185.IsReadOnly = true;
            this.xEditGridCell185.IsVisible = false;
            this.xEditGridCell185.Row = -1;
            // 
            // xEditGridCell186
            // 
            this.xEditGridCell186.CellName = "juninp_yn";
            this.xEditGridCell186.CellWidth = 28;
            this.xEditGridCell186.Col = -1;
            this.xEditGridCell186.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell186, "xEditGridCell186");
            this.xEditGridCell186.IsReadOnly = true;
            this.xEditGridCell186.IsUpdatable = false;
            this.xEditGridCell186.IsUpdCol = false;
            this.xEditGridCell186.IsVisible = false;
            this.xEditGridCell186.Row = -1;
            // 
            // xEditGridCell187
            // 
            this.xEditGridCell187.CellName = "hope_date";
            this.xEditGridCell187.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell187.Col = 3;
            this.xEditGridCell187.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell187, "xEditGridCell187");
            this.xEditGridCell187.IsReadOnly = true;
            // 
            // xEditGridCell188
            // 
            this.xEditGridCell188.CellName = "hope_time";
            this.xEditGridCell188.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell188.CellWidth = 35;
            this.xEditGridCell188.Col = -1;
            this.xEditGridCell188.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell188, "xEditGridCell188");
            this.xEditGridCell188.IsReadOnly = true;
            this.xEditGridCell188.IsVisible = false;
            this.xEditGridCell188.Mask = "HH:MI";
            this.xEditGridCell188.Row = -1;
            // 
            // xEditGridCell189
            // 
            this.xEditGridCell189.CellName = "fkinp1001";
            this.xEditGridCell189.Col = -1;
            this.xEditGridCell189.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell189, "xEditGridCell189");
            this.xEditGridCell189.IsUpdatable = false;
            this.xEditGridCell189.IsUpdCol = false;
            this.xEditGridCell189.IsVisible = false;
            this.xEditGridCell189.Row = -1;
            // 
            // xEditGridCell190
            // 
            this.xEditGridCell190.CellName = "toiwon_yn";
            this.xEditGridCell190.Col = -1;
            this.xEditGridCell190.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell190, "xEditGridCell190");
            this.xEditGridCell190.IsVisible = false;
            this.xEditGridCell190.Row = -1;
            // 
            // xEditGridCell191
            // 
            this.xEditGridCell191.CellName = "gwa";
            this.xEditGridCell191.Col = -1;
            this.xEditGridCell191.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell191, "xEditGridCell191");
            this.xEditGridCell191.IsVisible = false;
            this.xEditGridCell191.Row = -1;
            // 
            // xEditGridCell192
            // 
            this.xEditGridCell192.CellName = "magam_bunryu";
            this.xEditGridCell192.CellWidth = 30;
            this.xEditGridCell192.Col = 1;
            this.xEditGridCell192.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem11,
            this.xComboItem12});
            this.xEditGridCell192.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell192.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell192, "xEditGridCell192");
            this.xEditGridCell192.IsReadOnly = true;
            this.xEditGridCell192.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem11
            // 
            resources.ApplyResources(this.xComboItem11, "xComboItem11");
            this.xComboItem11.ValueItem = "1";
            // 
            // xComboItem12
            // 
            resources.ApplyResources(this.xComboItem12, "xComboItem12");
            this.xComboItem12.ValueItem = "2";
            // 
            // xEditGridCell193
            // 
            this.xEditGridCell193.CellName = "order_date";
            this.xEditGridCell193.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell193.Col = 2;
            this.xEditGridCell193.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell193, "xEditGridCell193");
            this.xEditGridCell193.IsReadOnly = true;
            // 
            // xEditGridCell194
            // 
            this.xEditGridCell194.CellName = "ho_code";
            this.xEditGridCell194.CellWidth = 35;
            this.xEditGridCell194.Col = 6;
            this.xEditGridCell194.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell194, "xEditGridCell194");
            this.xEditGridCell194.IsReadOnly = true;
            this.xEditGridCell194.SuppressRepeating = true;
            // 
            // xEditGridCell195
            // 
            this.xEditGridCell195.CellName = "jubsu_date";
            this.xEditGridCell195.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell195.Col = 4;
            this.xEditGridCell195.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell195, "xEditGridCell195");
            this.xEditGridCell195.IsReadOnly = true;
            // 
            // xEditGridCell267
            // 
            this.xEditGridCell267.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell267.CellName = "drg_bunho";
            this.xEditGridCell267.CellWidth = 40;
            this.xEditGridCell267.Col = 7;
            this.xEditGridCell267.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell267, "xEditGridCell267");
            this.xEditGridCell267.IsReadOnly = true;
            this.xEditGridCell267.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell267.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel19
            // 
            resources.ApplyResources(this.xPanel19, "xPanel19");
            this.xPanel19.Controls.Add(this.grdDcOrder);
            this.xPanel19.Controls.Add(this.grdJusaDcOrder);
            this.xPanel19.DrawBorder = true;
            this.xPanel19.Name = "xPanel19";
            // 
            // grdDcOrder
            // 
            this.grdDcOrder.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdDcOrder, "grdDcOrder");
            this.grdDcOrder.ApplyPaintEventToAllColumn = true;
            this.grdDcOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell182});
            this.grdDcOrder.ColPerLine = 13;
            this.grdDcOrder.Cols = 14;
            this.grdDcOrder.ExecuteQuery = null;
            this.grdDcOrder.FixedCols = 1;
            this.grdDcOrder.FixedRows = 2;
            this.grdDcOrder.HeaderHeights.Add(39);
            this.grdDcOrder.HeaderHeights.Add(-1);
            this.grdDcOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader4});
            this.grdDcOrder.Name = "grdDcOrder";
            this.grdDcOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDcOrder.ParamList")));
            this.grdDcOrder.QuerySQL = resources.GetString("grdDcOrder.QuerySQL");
            this.grdDcOrder.RowHeaderVisible = true;
            this.grdDcOrder.Rows = 3;
            this.grdDcOrder.TabStop = false;
            this.grdDcOrder.ToolTipActive = true;
            this.grdDcOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDcOrder_GridCellPainting);
            this.grdDcOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDcOrder_QueryStarting);
            this.grdDcOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdDcOrder_QueryEnd);
            // 
            // xEditGridCell196
            // 
            this.xEditGridCell196.CellName = "order_date";
            this.xEditGridCell196.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell196.CellWidth = 77;
            this.xEditGridCell196.Col = -1;
            this.xEditGridCell196.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell196, "xEditGridCell196");
            this.xEditGridCell196.IsReadOnly = true;
            this.xEditGridCell196.IsUpdCol = false;
            this.xEditGridCell196.IsVisible = false;
            this.xEditGridCell196.Row = -1;
            this.xEditGridCell196.SuppressRepeating = true;
            // 
            // xEditGridCell197
            // 
            this.xEditGridCell197.CellName = "mix_group";
            this.xEditGridCell197.CellWidth = 20;
            this.xEditGridCell197.Col = -1;
            this.xEditGridCell197.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell197, "xEditGridCell197");
            this.xEditGridCell197.IsReadOnly = true;
            this.xEditGridCell197.IsUpdCol = false;
            this.xEditGridCell197.IsVisible = false;
            this.xEditGridCell197.Row = -1;
            this.xEditGridCell197.SuppressRepeating = true;
            // 
            // xEditGridCell198
            // 
            this.xEditGridCell198.CellName = "jaeryo_code";
            this.xEditGridCell198.CellWidth = 77;
            this.xEditGridCell198.Col = -1;
            this.xEditGridCell198.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell198, "xEditGridCell198");
            this.xEditGridCell198.IsReadOnly = true;
            this.xEditGridCell198.IsUpdCol = false;
            this.xEditGridCell198.IsVisible = false;
            this.xEditGridCell198.Row = -1;
            this.xEditGridCell198.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell199
            // 
            this.xEditGridCell199.CellName = "jaeryo_name";
            this.xEditGridCell199.CellWidth = 225;
            this.xEditGridCell199.Col = 3;
            this.xEditGridCell199.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell199, "xEditGridCell199");
            this.xEditGridCell199.IsReadOnly = true;
            this.xEditGridCell199.IsUpdCol = false;
            this.xEditGridCell199.RowSpan = 2;
            // 
            // xEditGridCell200
            // 
            this.xEditGridCell200.CellName = "ord_suryang";
            this.xEditGridCell200.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell200.CellWidth = 30;
            this.xEditGridCell200.Col = 4;
            this.xEditGridCell200.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell200, "xEditGridCell200");
            this.xEditGridCell200.IsReadOnly = true;
            this.xEditGridCell200.IsUpdCol = false;
            this.xEditGridCell200.RowSpan = 2;
            // 
            // xEditGridCell201
            // 
            this.xEditGridCell201.CellName = "dv_time";
            this.xEditGridCell201.CellWidth = 20;
            this.xEditGridCell201.Col = 5;
            this.xEditGridCell201.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell201, "xEditGridCell201");
            this.xEditGridCell201.IsReadOnly = true;
            this.xEditGridCell201.IsUpdCol = false;
            this.xEditGridCell201.Row = 1;
            this.xEditGridCell201.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell202
            // 
            this.xEditGridCell202.CellName = "dv";
            this.xEditGridCell202.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell202.CellWidth = 22;
            this.xEditGridCell202.Col = 6;
            this.xEditGridCell202.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell202, "xEditGridCell202");
            this.xEditGridCell202.IsReadOnly = true;
            this.xEditGridCell202.IsUpdCol = false;
            this.xEditGridCell202.Row = 1;
            // 
            // xEditGridCell203
            // 
            this.xEditGridCell203.CellName = "nalsu";
            this.xEditGridCell203.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell203.CellWidth = 22;
            this.xEditGridCell203.Col = 8;
            this.xEditGridCell203.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell203, "xEditGridCell203");
            this.xEditGridCell203.IsReadOnly = true;
            this.xEditGridCell203.IsUpdCol = false;
            this.xEditGridCell203.RowSpan = 2;
            // 
            // xEditGridCell204
            // 
            this.xEditGridCell204.CellName = "order_danui";
            this.xEditGridCell204.CellWidth = 50;
            this.xEditGridCell204.Col = -1;
            this.xEditGridCell204.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell204, "xEditGridCell204");
            this.xEditGridCell204.IsReadOnly = true;
            this.xEditGridCell204.IsUpdCol = false;
            this.xEditGridCell204.IsVisible = false;
            this.xEditGridCell204.Row = -1;
            // 
            // xEditGridCell205
            // 
            this.xEditGridCell205.CellName = "danui_name";
            this.xEditGridCell205.CellWidth = 45;
            this.xEditGridCell205.Col = 7;
            this.xEditGridCell205.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell205, "xEditGridCell205");
            this.xEditGridCell205.IsReadOnly = true;
            this.xEditGridCell205.IsUpdCol = false;
            this.xEditGridCell205.RowSpan = 2;
            // 
            // xEditGridCell206
            // 
            this.xEditGridCell206.CellName = "bogyong_code";
            this.xEditGridCell206.CellWidth = 197;
            this.xEditGridCell206.Col = -1;
            this.xEditGridCell206.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell206, "xEditGridCell206");
            this.xEditGridCell206.IsReadOnly = true;
            this.xEditGridCell206.IsUpdCol = false;
            this.xEditGridCell206.IsVisible = false;
            this.xEditGridCell206.Row = -1;
            // 
            // xEditGridCell207
            // 
            this.xEditGridCell207.CellName = "bogyong_name";
            this.xEditGridCell207.CellWidth = 110;
            this.xEditGridCell207.Col = 9;
            this.xEditGridCell207.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell207, "xEditGridCell207");
            this.xEditGridCell207.IsReadOnly = true;
            this.xEditGridCell207.IsUpdCol = false;
            this.xEditGridCell207.RowSpan = 2;
            // 
            // xEditGridCell208
            // 
            this.xEditGridCell208.CellName = "powder_yn";
            this.xEditGridCell208.CellWidth = 22;
            this.xEditGridCell208.Col = 11;
            this.xEditGridCell208.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell208.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell208, "xEditGridCell208");
            this.xEditGridCell208.IsReadOnly = true;
            this.xEditGridCell208.IsUpdCol = false;
            this.xEditGridCell208.RowSpan = 2;
            this.xEditGridCell208.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell209
            // 
            this.xEditGridCell209.CellLen = 100;
            this.xEditGridCell209.CellName = "remark";
            this.xEditGridCell209.CellWidth = 43;
            this.xEditGridCell209.Col = 13;
            this.xEditGridCell209.DisplayMemoText = true;
            this.xEditGridCell209.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell209.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell209, "xEditGridCell209");
            this.xEditGridCell209.IsReadOnly = true;
            this.xEditGridCell209.IsUpdCol = false;
            this.xEditGridCell209.RowSpan = 2;
            // 
            // xEditGridCell210
            // 
            this.xEditGridCell210.CellName = "dv_1";
            this.xEditGridCell210.Col = -1;
            this.xEditGridCell210.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell210, "xEditGridCell210");
            this.xEditGridCell210.IsReadOnly = true;
            this.xEditGridCell210.IsUpdCol = false;
            this.xEditGridCell210.IsVisible = false;
            this.xEditGridCell210.Row = -1;
            // 
            // xEditGridCell211
            // 
            this.xEditGridCell211.CellName = "dv_2";
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
            this.xEditGridCell212.CellName = "dv_3";
            this.xEditGridCell212.Col = -1;
            this.xEditGridCell212.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell212, "xEditGridCell212");
            this.xEditGridCell212.IsReadOnly = true;
            this.xEditGridCell212.IsUpdCol = false;
            this.xEditGridCell212.IsVisible = false;
            this.xEditGridCell212.Row = -1;
            // 
            // xEditGridCell213
            // 
            this.xEditGridCell213.CellName = "dv_4";
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
            this.xEditGridCell214.CellName = "dv_5";
            this.xEditGridCell214.Col = -1;
            this.xEditGridCell214.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell214, "xEditGridCell214");
            this.xEditGridCell214.IsReadOnly = true;
            this.xEditGridCell214.IsUpdCol = false;
            this.xEditGridCell214.IsVisible = false;
            this.xEditGridCell214.Row = -1;
            // 
            // xEditGridCell215
            // 
            this.xEditGridCell215.CellName = "hubal_change_yn";
            this.xEditGridCell215.CellWidth = 21;
            this.xEditGridCell215.Col = -1;
            this.xEditGridCell215.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell215, "xEditGridCell215");
            this.xEditGridCell215.IsReadOnly = true;
            this.xEditGridCell215.IsUpdCol = false;
            this.xEditGridCell215.IsVisible = false;
            this.xEditGridCell215.Row = -1;
            this.xEditGridCell215.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell216
            // 
            this.xEditGridCell216.CellName = "pharmacy";
            this.xEditGridCell216.CellWidth = 30;
            this.xEditGridCell216.Col = 12;
            this.xEditGridCell216.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell216.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell216, "xEditGridCell216");
            this.xEditGridCell216.IsReadOnly = true;
            this.xEditGridCell216.IsUpdCol = false;
            this.xEditGridCell216.RowSpan = 2;
            this.xEditGridCell216.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell217
            // 
            this.xEditGridCell217.CellName = "drg_pack_yn";
            this.xEditGridCell217.CellWidth = 21;
            this.xEditGridCell217.Col = 10;
            this.xEditGridCell217.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell217.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell217, "xEditGridCell217");
            this.xEditGridCell217.IsReadOnly = true;
            this.xEditGridCell217.IsUpdCol = false;
            this.xEditGridCell217.RowSpan = 2;
            this.xEditGridCell217.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell218
            // 
            this.xEditGridCell218.CellName = "jusa";
            this.xEditGridCell218.CellWidth = 43;
            this.xEditGridCell218.Col = -1;
            this.xEditGridCell218.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell218, "xEditGridCell218");
            this.xEditGridCell218.IsReadOnly = true;
            this.xEditGridCell218.IsUpdCol = false;
            this.xEditGridCell218.IsVisible = false;
            this.xEditGridCell218.Row = -1;
            this.xEditGridCell218.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell219
            // 
            this.xEditGridCell219.CellName = "suname";
            this.xEditGridCell219.Col = -1;
            this.xEditGridCell219.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell219, "xEditGridCell219");
            this.xEditGridCell219.IsUpdCol = false;
            this.xEditGridCell219.IsVisible = false;
            this.xEditGridCell219.Row = -1;
            // 
            // xEditGridCell220
            // 
            this.xEditGridCell220.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell220.CellName = "drg_bunho";
            this.xEditGridCell220.CellWidth = 40;
            this.xEditGridCell220.Col = 1;
            this.xEditGridCell220.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell220, "xEditGridCell220");
            this.xEditGridCell220.IsReadOnly = true;
            this.xEditGridCell220.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell220.RowSpan = 2;
            this.xEditGridCell220.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell221
            // 
            this.xEditGridCell221.CellName = "fkocs2003";
            this.xEditGridCell221.Col = -1;
            this.xEditGridCell221.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell221, "xEditGridCell221");
            this.xEditGridCell221.IsVisible = false;
            this.xEditGridCell221.Row = -1;
            // 
            // xEditGridCell222
            // 
            this.xEditGridCell222.CellName = "append_yn";
            this.xEditGridCell222.CellWidth = 21;
            this.xEditGridCell222.Col = -1;
            this.xEditGridCell222.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell222, "xEditGridCell222");
            this.xEditGridCell222.IsReadOnly = true;
            this.xEditGridCell222.IsUpdatable = false;
            this.xEditGridCell222.IsUpdCol = false;
            this.xEditGridCell222.IsVisible = false;
            this.xEditGridCell222.Row = -1;
            // 
            // xEditGridCell223
            // 
            this.xEditGridCell223.CellName = "re_use_yn";
            this.xEditGridCell223.Col = -1;
            this.xEditGridCell223.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell223, "xEditGridCell223");
            this.xEditGridCell223.IsVisible = false;
            this.xEditGridCell223.Row = -1;
            // 
            // xEditGridCell224
            // 
            this.xEditGridCell224.CellName = "hope_date";
            this.xEditGridCell224.Col = -1;
            this.xEditGridCell224.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell224, "xEditGridCell224");
            this.xEditGridCell224.IsUpdCol = false;
            this.xEditGridCell224.IsVisible = false;
            this.xEditGridCell224.Row = -1;
            // 
            // xEditGridCell225
            // 
            this.xEditGridCell225.CellName = "hope_time";
            this.xEditGridCell225.Col = -1;
            this.xEditGridCell225.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell225, "xEditGridCell225");
            this.xEditGridCell225.IsUpdCol = false;
            this.xEditGridCell225.IsVisible = false;
            this.xEditGridCell225.Row = -1;
            // 
            // xEditGridCell226
            // 
            this.xEditGridCell226.CellName = "group_ser";
            this.xEditGridCell226.CellWidth = 26;
            this.xEditGridCell226.Col = 2;
            this.xEditGridCell226.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell226, "xEditGridCell226");
            this.xEditGridCell226.IsReadOnly = true;
            this.xEditGridCell226.IsUpdatable = false;
            this.xEditGridCell226.IsUpdCol = false;
            this.xEditGridCell226.RowSpan = 2;
            this.xEditGridCell226.SuppressRepeating = true;
            this.xEditGridCell226.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell227
            // 
            this.xEditGridCell227.CellName = "dc_yn";
            this.xEditGridCell227.Col = -1;
            this.xEditGridCell227.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell227, "xEditGridCell227");
            this.xEditGridCell227.IsUpdCol = false;
            this.xEditGridCell227.IsVisible = false;
            this.xEditGridCell227.Row = -1;
            // 
            // xEditGridCell228
            // 
            this.xEditGridCell228.CellName = "order_gubun";
            this.xEditGridCell228.Col = -1;
            this.xEditGridCell228.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell228, "xEditGridCell228");
            this.xEditGridCell228.IsUpdCol = false;
            this.xEditGridCell228.IsVisible = false;
            this.xEditGridCell228.Row = -1;
            // 
            // xEditGridCell229
            // 
            this.xEditGridCell229.CellName = "if_input_control";
            this.xEditGridCell229.Col = -1;
            this.xEditGridCell229.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell229, "xEditGridCell229");
            this.xEditGridCell229.IsVisible = false;
            this.xEditGridCell229.Row = -1;
            // 
            // xEditGridCell182
            // 
            this.xEditGridCell182.CellName = "bannab_yn";
            this.xEditGridCell182.Col = -1;
            this.xEditGridCell182.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell182, "xEditGridCell182");
            this.xEditGridCell182.IsReadOnly = true;
            this.xEditGridCell182.IsVisible = false;
            this.xEditGridCell182.Row = -1;
            // 
            // xGridHeader4
            // 
            this.xGridHeader4.Col = 5;
            this.xGridHeader4.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader4, "xGridHeader4");
            this.xGridHeader4.HeaderWidth = 20;
            // 
            // grdJusaDcOrder
            // 
            this.grdJusaDcOrder.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdJusaDcOrder, "grdJusaDcOrder");
            this.grdJusaDcOrder.ApplyPaintEventToAllColumn = true;
            this.grdJusaDcOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell259,
            this.xEditGridCell260,
            this.xEditGridCell261,
            this.xEditGridCell262,
            this.xEditGridCell263,
            this.xEditGridCell264,
            this.xEditGridCell265,
            this.xEditGridCell266});
            this.grdJusaDcOrder.ColPerLine = 10;
            this.grdJusaDcOrder.Cols = 11;
            this.grdJusaDcOrder.ControlBinding = true;
            this.grdJusaDcOrder.ExecuteQuery = null;
            this.grdJusaDcOrder.FixedCols = 1;
            this.grdJusaDcOrder.FixedRows = 2;
            this.grdJusaDcOrder.HeaderHeights.Add(37);
            this.grdJusaDcOrder.HeaderHeights.Add(-1);
            this.grdJusaDcOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader5});
            this.grdJusaDcOrder.Name = "grdJusaDcOrder";
            this.grdJusaDcOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdJusaDcOrder.ParamList")));
            this.grdJusaDcOrder.QuerySQL = resources.GetString("grdJusaDcOrder.QuerySQL");
            this.grdJusaDcOrder.RowHeaderVisible = true;
            this.grdJusaDcOrder.Rows = 3;
            this.grdJusaDcOrder.TabStop = false;
            this.grdJusaDcOrder.ToolTipActive = true;
            this.grdJusaDcOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdJusaDcOrder_GridCellPainting);
            this.grdJusaDcOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdJusaDcOrder_QueryStarting);
            this.grdJusaDcOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdJusaDcOrder_QueryEnd);
            // 
            // xEditGridCell230
            // 
            this.xEditGridCell230.CellName = "order_date";
            this.xEditGridCell230.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell230.CellWidth = 77;
            this.xEditGridCell230.Col = -1;
            this.xEditGridCell230.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell230, "xEditGridCell230");
            this.xEditGridCell230.IsReadOnly = true;
            this.xEditGridCell230.IsUpdCol = false;
            this.xEditGridCell230.IsVisible = false;
            this.xEditGridCell230.Row = -1;
            this.xEditGridCell230.SuppressRepeating = true;
            // 
            // xEditGridCell231
            // 
            this.xEditGridCell231.CellName = "mix_group";
            this.xEditGridCell231.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell231.CellWidth = 20;
            this.xEditGridCell231.Col = -1;
            this.xEditGridCell231.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell231, "xEditGridCell231");
            this.xEditGridCell231.IsReadOnly = true;
            this.xEditGridCell231.IsUpdCol = false;
            this.xEditGridCell231.IsVisible = false;
            this.xEditGridCell231.Row = -1;
            this.xEditGridCell231.SuppressRepeating = true;
            // 
            // xEditGridCell232
            // 
            this.xEditGridCell232.CellName = "jaeryo_code";
            this.xEditGridCell232.CellWidth = 77;
            this.xEditGridCell232.Col = -1;
            this.xEditGridCell232.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell232, "xEditGridCell232");
            this.xEditGridCell232.IsReadOnly = true;
            this.xEditGridCell232.IsUpdCol = false;
            this.xEditGridCell232.IsVisible = false;
            this.xEditGridCell232.Row = -1;
            this.xEditGridCell232.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell233
            // 
            this.xEditGridCell233.CellName = "jaeryo_name";
            this.xEditGridCell233.CellWidth = 260;
            this.xEditGridCell233.Col = 3;
            this.xEditGridCell233.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell233, "xEditGridCell233");
            this.xEditGridCell233.IsReadOnly = true;
            this.xEditGridCell233.IsUpdCol = false;
            // 
            // xEditGridCell234
            // 
            this.xEditGridCell234.CellName = "ord_suryang";
            this.xEditGridCell234.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell234.CellWidth = 40;
            this.xEditGridCell234.Col = 4;
            this.xEditGridCell234.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell234, "xEditGridCell234");
            this.xEditGridCell234.IsReadOnly = true;
            this.xEditGridCell234.IsUpdCol = false;
            this.xEditGridCell234.RowSpan = 2;
            // 
            // xEditGridCell235
            // 
            this.xEditGridCell235.CellName = "dv_time";
            this.xEditGridCell235.CellWidth = 20;
            this.xEditGridCell235.Col = 5;
            this.xEditGridCell235.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell235, "xEditGridCell235");
            this.xEditGridCell235.IsReadOnly = true;
            this.xEditGridCell235.IsUpdCol = false;
            this.xEditGridCell235.Row = 1;
            this.xEditGridCell235.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell236
            // 
            this.xEditGridCell236.CellName = "dv";
            this.xEditGridCell236.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell236.CellWidth = 22;
            this.xEditGridCell236.Col = 6;
            this.xEditGridCell236.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell236, "xEditGridCell236");
            this.xEditGridCell236.IsReadOnly = true;
            this.xEditGridCell236.IsUpdCol = false;
            this.xEditGridCell236.Row = 1;
            // 
            // xEditGridCell237
            // 
            this.xEditGridCell237.CellName = "nalsu";
            this.xEditGridCell237.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell237.CellWidth = 22;
            this.xEditGridCell237.Col = -1;
            this.xEditGridCell237.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell237, "xEditGridCell237");
            this.xEditGridCell237.IsReadOnly = true;
            this.xEditGridCell237.IsUpdCol = false;
            this.xEditGridCell237.IsVisible = false;
            this.xEditGridCell237.Row = -1;
            // 
            // xEditGridCell238
            // 
            this.xEditGridCell238.CellName = "order_danui";
            this.xEditGridCell238.CellWidth = 50;
            this.xEditGridCell238.Col = -1;
            this.xEditGridCell238.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell238, "xEditGridCell238");
            this.xEditGridCell238.IsReadOnly = true;
            this.xEditGridCell238.IsUpdCol = false;
            this.xEditGridCell238.IsVisible = false;
            this.xEditGridCell238.Row = -1;
            // 
            // xEditGridCell239
            // 
            this.xEditGridCell239.CellName = "danui_name";
            this.xEditGridCell239.CellWidth = 50;
            this.xEditGridCell239.Col = 7;
            this.xEditGridCell239.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell239, "xEditGridCell239");
            this.xEditGridCell239.IsReadOnly = true;
            this.xEditGridCell239.IsUpdCol = false;
            this.xEditGridCell239.RowSpan = 2;
            // 
            // xEditGridCell240
            // 
            this.xEditGridCell240.CellName = "bogyong_code";
            this.xEditGridCell240.CellWidth = 197;
            this.xEditGridCell240.Col = -1;
            this.xEditGridCell240.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell240, "xEditGridCell240");
            this.xEditGridCell240.IsReadOnly = true;
            this.xEditGridCell240.IsUpdCol = false;
            this.xEditGridCell240.IsVisible = false;
            this.xEditGridCell240.Row = -1;
            // 
            // xEditGridCell241
            // 
            this.xEditGridCell241.CellName = "bogyong_name";
            this.xEditGridCell241.CellWidth = 50;
            this.xEditGridCell241.Col = 9;
            this.xEditGridCell241.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell241, "xEditGridCell241");
            this.xEditGridCell241.IsReadOnly = true;
            this.xEditGridCell241.IsUpdCol = false;
            this.xEditGridCell241.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell242
            // 
            this.xEditGridCell242.CellName = "powder_yn";
            this.xEditGridCell242.CellWidth = 19;
            this.xEditGridCell242.Col = -1;
            this.xEditGridCell242.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell242, "xEditGridCell242");
            this.xEditGridCell242.IsReadOnly = true;
            this.xEditGridCell242.IsUpdCol = false;
            this.xEditGridCell242.IsVisible = false;
            this.xEditGridCell242.Row = -1;
            this.xEditGridCell242.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell243
            // 
            this.xEditGridCell243.CellLen = 100;
            this.xEditGridCell243.CellName = "remark";
            this.xEditGridCell243.CellWidth = 45;
            this.xEditGridCell243.Col = 10;
            this.xEditGridCell243.DisplayMemoText = true;
            this.xEditGridCell243.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell243.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell243, "xEditGridCell243");
            this.xEditGridCell243.IsUpdCol = false;
            // 
            // xEditGridCell244
            // 
            this.xEditGridCell244.CellName = "dv_1";
            this.xEditGridCell244.Col = -1;
            this.xEditGridCell244.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell244, "xEditGridCell244");
            this.xEditGridCell244.IsReadOnly = true;
            this.xEditGridCell244.IsUpdCol = false;
            this.xEditGridCell244.IsVisible = false;
            this.xEditGridCell244.Row = -1;
            // 
            // xEditGridCell245
            // 
            this.xEditGridCell245.CellName = "dv_2";
            this.xEditGridCell245.Col = -1;
            this.xEditGridCell245.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell245, "xEditGridCell245");
            this.xEditGridCell245.IsReadOnly = true;
            this.xEditGridCell245.IsUpdCol = false;
            this.xEditGridCell245.IsVisible = false;
            this.xEditGridCell245.Row = -1;
            // 
            // xEditGridCell246
            // 
            this.xEditGridCell246.CellName = "dv_3";
            this.xEditGridCell246.Col = -1;
            this.xEditGridCell246.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell246, "xEditGridCell246");
            this.xEditGridCell246.IsReadOnly = true;
            this.xEditGridCell246.IsUpdCol = false;
            this.xEditGridCell246.IsVisible = false;
            this.xEditGridCell246.Row = -1;
            // 
            // xEditGridCell247
            // 
            this.xEditGridCell247.CellName = "dv_4";
            this.xEditGridCell247.Col = -1;
            this.xEditGridCell247.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell247, "xEditGridCell247");
            this.xEditGridCell247.IsReadOnly = true;
            this.xEditGridCell247.IsUpdCol = false;
            this.xEditGridCell247.IsVisible = false;
            this.xEditGridCell247.Row = -1;
            // 
            // xEditGridCell248
            // 
            this.xEditGridCell248.CellName = "dv_5";
            this.xEditGridCell248.Col = -1;
            this.xEditGridCell248.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell248, "xEditGridCell248");
            this.xEditGridCell248.IsReadOnly = true;
            this.xEditGridCell248.IsUpdCol = false;
            this.xEditGridCell248.IsVisible = false;
            this.xEditGridCell248.Row = -1;
            // 
            // xEditGridCell249
            // 
            this.xEditGridCell249.CellName = "hubal_change_yn";
            this.xEditGridCell249.CellWidth = 19;
            this.xEditGridCell249.Col = -1;
            this.xEditGridCell249.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell249, "xEditGridCell249");
            this.xEditGridCell249.IsReadOnly = true;
            this.xEditGridCell249.IsUpdCol = false;
            this.xEditGridCell249.IsVisible = false;
            this.xEditGridCell249.Row = -1;
            this.xEditGridCell249.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell250
            // 
            this.xEditGridCell250.CellName = "pharmacy";
            this.xEditGridCell250.CellWidth = 30;
            this.xEditGridCell250.Col = -1;
            this.xEditGridCell250.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell250, "xEditGridCell250");
            this.xEditGridCell250.IsReadOnly = true;
            this.xEditGridCell250.IsUpdCol = false;
            this.xEditGridCell250.IsVisible = false;
            this.xEditGridCell250.Row = -1;
            this.xEditGridCell250.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell251
            // 
            this.xEditGridCell251.CellName = "drg_pack_yn";
            this.xEditGridCell251.CellWidth = 19;
            this.xEditGridCell251.Col = -1;
            this.xEditGridCell251.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell251, "xEditGridCell251");
            this.xEditGridCell251.IsReadOnly = true;
            this.xEditGridCell251.IsUpdCol = false;
            this.xEditGridCell251.IsVisible = false;
            this.xEditGridCell251.Row = -1;
            this.xEditGridCell251.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell252
            // 
            this.xEditGridCell252.CellName = "jusa";
            this.xEditGridCell252.CellWidth = 103;
            this.xEditGridCell252.Col = 8;
            this.xEditGridCell252.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell252, "xEditGridCell252");
            this.xEditGridCell252.IsReadOnly = true;
            this.xEditGridCell252.IsUpdCol = false;
            // 
            // xEditGridCell253
            // 
            this.xEditGridCell253.CellName = "suname";
            this.xEditGridCell253.CellWidth = 32;
            this.xEditGridCell253.Col = -1;
            this.xEditGridCell253.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell253, "xEditGridCell253");
            this.xEditGridCell253.IsUpdCol = false;
            this.xEditGridCell253.IsVisible = false;
            this.xEditGridCell253.Row = -1;
            // 
            // xEditGridCell254
            // 
            this.xEditGridCell254.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell254.CellName = "drg_bunho";
            this.xEditGridCell254.CellWidth = 40;
            this.xEditGridCell254.Col = 1;
            this.xEditGridCell254.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell254, "xEditGridCell254");
            this.xEditGridCell254.IsReadOnly = true;
            this.xEditGridCell254.IsUpdCol = false;
            this.xEditGridCell254.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // xEditGridCell255
            // 
            this.xEditGridCell255.CellName = "fkocs2003";
            this.xEditGridCell255.Col = -1;
            this.xEditGridCell255.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell255, "xEditGridCell255");
            this.xEditGridCell255.IsVisible = false;
            this.xEditGridCell255.Row = -1;
            // 
            // xEditGridCell256
            // 
            this.xEditGridCell256.CellName = "append_yn";
            this.xEditGridCell256.CellWidth = 19;
            this.xEditGridCell256.Col = -1;
            this.xEditGridCell256.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell256, "xEditGridCell256");
            this.xEditGridCell256.IsReadOnly = true;
            this.xEditGridCell256.IsUpdatable = false;
            this.xEditGridCell256.IsUpdCol = false;
            this.xEditGridCell256.IsVisible = false;
            this.xEditGridCell256.Row = -1;
            // 
            // xEditGridCell259
            // 
            this.xEditGridCell259.CellName = "re_use_yn";
            this.xEditGridCell259.CellWidth = 24;
            this.xEditGridCell259.Col = -1;
            this.xEditGridCell259.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell259, "xEditGridCell259");
            this.xEditGridCell259.IsVisible = false;
            this.xEditGridCell259.Row = -1;
            // 
            // xEditGridCell260
            // 
            this.xEditGridCell260.CellName = "hope_date";
            this.xEditGridCell260.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell260.Col = -1;
            this.xEditGridCell260.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell260, "xEditGridCell260");
            this.xEditGridCell260.IsUpdCol = false;
            this.xEditGridCell260.IsVisible = false;
            this.xEditGridCell260.Row = -1;
            // 
            // xEditGridCell261
            // 
            this.xEditGridCell261.CellName = "hope_time";
            this.xEditGridCell261.Col = -1;
            this.xEditGridCell261.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell261, "xEditGridCell261");
            this.xEditGridCell261.IsUpdCol = false;
            this.xEditGridCell261.IsVisible = false;
            this.xEditGridCell261.Row = -1;
            // 
            // xEditGridCell262
            // 
            this.xEditGridCell262.CellName = "group_ser";
            this.xEditGridCell262.CellWidth = 26;
            this.xEditGridCell262.Col = 2;
            this.xEditGridCell262.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell262, "xEditGridCell262");
            this.xEditGridCell262.IsReadOnly = true;
            this.xEditGridCell262.IsUpdatable = false;
            this.xEditGridCell262.IsUpdCol = false;
            this.xEditGridCell262.SuppressRepeating = true;
            this.xEditGridCell262.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell263
            // 
            this.xEditGridCell263.CellName = "dc_yn";
            this.xEditGridCell263.Col = -1;
            this.xEditGridCell263.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell263, "xEditGridCell263");
            this.xEditGridCell263.IsUpdCol = false;
            this.xEditGridCell263.IsVisible = false;
            this.xEditGridCell263.Row = -1;
            // 
            // xEditGridCell264
            // 
            this.xEditGridCell264.CellName = "order_gubun";
            this.xEditGridCell264.Col = -1;
            this.xEditGridCell264.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell264, "xEditGridCell264");
            this.xEditGridCell264.IsUpdCol = false;
            this.xEditGridCell264.IsVisible = false;
            this.xEditGridCell264.Row = -1;
            // 
            // xEditGridCell265
            // 
            this.xEditGridCell265.CellName = "if_input_control";
            this.xEditGridCell265.Col = -1;
            this.xEditGridCell265.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell265, "xEditGridCell265");
            this.xEditGridCell265.IsReadOnly = true;
            this.xEditGridCell265.IsUpdatable = false;
            this.xEditGridCell265.IsUpdCol = false;
            this.xEditGridCell265.IsVisible = false;
            this.xEditGridCell265.Row = -1;
            // 
            // xEditGridCell266
            // 
            this.xEditGridCell266.CellName = "bannab_yn";
            this.xEditGridCell266.Col = -1;
            this.xEditGridCell266.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell266, "xEditGridCell266");
            this.xEditGridCell266.IsReadOnly = true;
            this.xEditGridCell266.IsVisible = false;
            this.xEditGridCell266.Row = -1;
            // 
            // xGridHeader5
            // 
            this.xGridHeader5.Col = 5;
            this.xGridHeader5.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader5, "xGridHeader5");
            this.xGridHeader5.HeaderWidth = 20;
            // 
            // xPanel16
            // 
            resources.ApplyResources(this.xPanel16, "xPanel16");
            this.xPanel16.Controls.Add(this.btnDcRePrint);
            this.xPanel16.Controls.Add(this.btnListDc);
            this.xPanel16.DrawBorder = true;
            this.xPanel16.Name = "xPanel16";
            // 
            // btnDcRePrint
            // 
            resources.ApplyResources(this.btnDcRePrint, "btnDcRePrint");
            this.btnDcRePrint.ImageIndex = 1;
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
            this.btnListDc.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnListDc_ButtonClick);
            // 
            // lbQueryBase
            // 
            resources.ApplyResources(this.lbQueryBase, "lbQueryBase");
            this.lbQueryBase.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbQueryBase.EdgeRounding = false;
            this.lbQueryBase.Name = "lbQueryBase";
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpMi_DataValidating);
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpMi_DataValidating);
            // 
            // xLabel14
            // 
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel14.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel14.Name = "xLabel14";
            // 
            // lbCycleMagamDate
            // 
            resources.ApplyResources(this.lbCycleMagamDate, "lbCycleMagamDate");
            this.lbCycleMagamDate.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbCycleMagamDate.EdgeRounding = false;
            this.lbCycleMagamDate.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.OrangeRed);
            this.lbCycleMagamDate.Name = "lbCycleMagamDate";
            // 
            // lbCycleOrdDate
            // 
            resources.ApplyResources(this.lbCycleOrdDate, "lbCycleOrdDate");
            this.lbCycleOrdDate.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbCycleOrdDate.EdgeRounding = false;
            this.lbCycleOrdDate.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Blue);
            this.lbCycleOrdDate.Name = "lbCycleOrdDate";
            // 
            // layOrderPrint
            // 
            this.layOrderPrint.ExecuteQuery = null;
            this.layOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
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
            this.multiLayoutItem304});
            this.layOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderPrint.ParamList")));
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "bunho";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "drg_bunho";
            this.multiLayoutItem66.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "naewon_date";
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "group_ser";
            this.multiLayoutItem172.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem173
            // 
            this.multiLayoutItem173.DataName = "jubsu_date";
            // 
            // multiLayoutItem174
            // 
            this.multiLayoutItem174.DataName = "hope_date";
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "order_date";
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "jaeryo_code";
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "nalsu";
            this.multiLayoutItem177.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem178
            // 
            this.multiLayoutItem178.DataName = "divide";
            // 
            // multiLayoutItem179
            // 
            this.multiLayoutItem179.DataName = "ord_surang";
            this.multiLayoutItem179.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "order_suryang";
            this.multiLayoutItem180.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "order_danui";
            // 
            // multiLayoutItem182
            // 
            this.multiLayoutItem182.DataName = "subul_danui";
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "group_yn";
            // 
            // multiLayoutItem184
            // 
            this.multiLayoutItem184.DataName = "jaeryo_gubun";
            // 
            // multiLayoutItem185
            // 
            this.multiLayoutItem185.DataName = "bogyong_code";
            // 
            // multiLayoutItem186
            // 
            this.multiLayoutItem186.DataName = "bogyong_name";
            // 
            // multiLayoutItem187
            // 
            this.multiLayoutItem187.DataName = "caution_name";
            // 
            // multiLayoutItem188
            // 
            this.multiLayoutItem188.DataName = "caution_code";
            // 
            // multiLayoutItem189
            // 
            this.multiLayoutItem189.DataName = "mix_yn";
            // 
            // multiLayoutItem190
            // 
            this.multiLayoutItem190.DataName = "atc_yn";
            // 
            // multiLayoutItem191
            // 
            this.multiLayoutItem191.DataName = "dv";
            this.multiLayoutItem191.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem192
            // 
            this.multiLayoutItem192.DataName = "dv_time";
            // 
            // multiLayoutItem193
            // 
            this.multiLayoutItem193.DataName = "dc_yn";
            // 
            // multiLayoutItem194
            // 
            this.multiLayoutItem194.DataName = "bannab_yn";
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "source_fkocs1003";
            this.multiLayoutItem195.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem196
            // 
            this.multiLayoutItem196.DataName = "fkocs1003";
            this.multiLayoutItem196.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem197
            // 
            this.multiLayoutItem197.DataName = "sunab_date";
            // 
            // multiLayoutItem198
            // 
            this.multiLayoutItem198.DataName = "pattern";
            // 
            // multiLayoutItem199
            // 
            this.multiLayoutItem199.DataName = "jaeryo_name";
            // 
            // multiLayoutItem200
            // 
            this.multiLayoutItem200.DataName = "sunab_nalsu";
            this.multiLayoutItem200.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem201
            // 
            this.multiLayoutItem201.DataName = "wonyoi_yn";
            // 
            // multiLayoutItem202
            // 
            this.multiLayoutItem202.DataName = "order_remark";
            // 
            // multiLayoutItem203
            // 
            this.multiLayoutItem203.DataName = "act_date";
            // 
            // multiLayoutItem272
            // 
            this.multiLayoutItem272.DataName = "mayak";
            // 
            // multiLayoutItem273
            // 
            this.multiLayoutItem273.DataName = "tpn_joje_gubun";
            // 
            // multiLayoutItem274
            // 
            this.multiLayoutItem274.DataName = "ui_jusa_yn";
            // 
            // multiLayoutItem275
            // 
            this.multiLayoutItem275.DataName = "subul_suryang";
            this.multiLayoutItem275.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem276
            // 
            this.multiLayoutItem276.DataName = "serial_v";
            // 
            // multiLayoutItem277
            // 
            this.multiLayoutItem277.DataName = "gwa_name";
            // 
            // multiLayoutItem278
            // 
            this.multiLayoutItem278.DataName = "doctor_name";
            // 
            // multiLayoutItem279
            // 
            this.multiLayoutItem279.DataName = "suname";
            // 
            // multiLayoutItem280
            // 
            this.multiLayoutItem280.DataName = "suname2";
            // 
            // multiLayoutItem281
            // 
            this.multiLayoutItem281.DataName = "birth";
            // 
            // multiLayoutItem282
            // 
            this.multiLayoutItem282.DataName = "age";
            // 
            // multiLayoutItem283
            // 
            this.multiLayoutItem283.DataName = "other_gwa";
            // 
            // multiLayoutItem284
            // 
            this.multiLayoutItem284.DataName = "do_order";
            // 
            // multiLayoutItem285
            // 
            this.multiLayoutItem285.DataName = "gubun_name";
            // 
            // multiLayoutItem286
            // 
            this.multiLayoutItem286.DataName = "powder_yn";
            // 
            // multiLayoutItem287
            // 
            this.multiLayoutItem287.DataName = "line";
            this.multiLayoutItem287.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem288
            // 
            this.multiLayoutItem288.DataName = "kyukyeok";
            // 
            // multiLayoutItem289
            // 
            this.multiLayoutItem289.DataName = "licenes";
            // 
            // multiLayoutItem290
            // 
            this.multiLayoutItem290.DataName = "bunryu1";
            // 
            // multiLayoutItem291
            // 
            this.multiLayoutItem291.DataName = "ho_dong";
            // 
            // multiLayoutItem292
            // 
            this.multiLayoutItem292.DataName = "ho_code";
            // 
            // multiLayoutItem293
            // 
            this.multiLayoutItem293.DataName = "title";
            // 
            // multiLayoutItem294
            // 
            this.multiLayoutItem294.DataName = "donbok";
            // 
            // multiLayoutItem295
            // 
            this.multiLayoutItem295.DataName = "tusuk";
            // 
            // multiLayoutItem296
            // 
            this.multiLayoutItem296.DataName = "magam_gubun";
            // 
            // multiLayoutItem297
            // 
            this.multiLayoutItem297.DataName = "text_color";
            // 
            // multiLayoutItem298
            // 
            this.multiLayoutItem298.DataName = "changgo";
            // 
            // multiLayoutItem299
            // 
            this.multiLayoutItem299.DataName = "from_order_date";
            // 
            // multiLayoutItem300
            // 
            this.multiLayoutItem300.DataName = "to_order_date";
            // 
            // multiLayoutItem301
            // 
            this.multiLayoutItem301.DataName = "data_gubun";
            // 
            // multiLayoutItem302
            // 
            this.multiLayoutItem302.DataName = "print_gubun";
            // 
            // multiLayoutItem303
            // 
            this.multiLayoutItem303.DataName = "hodong_ord_name";
            // 
            // multiLayoutItem304
            // 
            this.multiLayoutItem304.DataName = "max_bannab_yn";
            // 
            // layJusaLable
            // 
            this.layJusaLable.ExecuteQuery = null;
            this.layJusaLable.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem60});
            this.layJusaLable.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJusaLable.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "suname";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "suname2";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "birth";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "age";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "drg_bunho";
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
            this.multiLayoutItem9.DataName = "magam_gubun";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "gwa_name";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "doctor_name";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "jubsu_date";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "serial_v";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "resident_name";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jusa";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "jaeryo_name";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "bogyong_name";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "ord_surang";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "order_danui";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "dv";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "subul_surang";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "subul_danui";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "order_remark";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "rp_barcode";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "order_date";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "hope_date";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "order_suryang";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "rp2";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "data_gubun";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "line";
            // 
            // layJusaOrderPrint
            // 
            this.layJusaOrderPrint.ExecuteQuery = null;
            this.layJusaOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem239});
            this.layJusaOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJusaOrderPrint.ParamList")));
            // 
            // multiLayoutItem204
            // 
            this.multiLayoutItem204.DataName = "bunho";
            // 
            // multiLayoutItem205
            // 
            this.multiLayoutItem205.DataName = "suname";
            // 
            // multiLayoutItem206
            // 
            this.multiLayoutItem206.DataName = "suname2";
            // 
            // multiLayoutItem207
            // 
            this.multiLayoutItem207.DataName = "birth";
            // 
            // multiLayoutItem208
            // 
            this.multiLayoutItem208.DataName = "age";
            // 
            // multiLayoutItem209
            // 
            this.multiLayoutItem209.DataName = "drg_bunho";
            // 
            // multiLayoutItem210
            // 
            this.multiLayoutItem210.DataName = "ho_dong";
            // 
            // multiLayoutItem211
            // 
            this.multiLayoutItem211.DataName = "ho_code";
            // 
            // multiLayoutItem212
            // 
            this.multiLayoutItem212.DataName = "magam_gubun";
            // 
            // multiLayoutItem213
            // 
            this.multiLayoutItem213.DataName = "gwa_name";
            // 
            // multiLayoutItem214
            // 
            this.multiLayoutItem214.DataName = "doctor_name";
            // 
            // multiLayoutItem215
            // 
            this.multiLayoutItem215.DataName = "jubsu_date";
            // 
            // multiLayoutItem216
            // 
            this.multiLayoutItem216.DataName = "serial_v";
            // 
            // multiLayoutItem217
            // 
            this.multiLayoutItem217.DataName = "resident_name";
            // 
            // multiLayoutItem218
            // 
            this.multiLayoutItem218.DataName = "jusa";
            // 
            // multiLayoutItem219
            // 
            this.multiLayoutItem219.DataName = "jaeryo_name";
            // 
            // multiLayoutItem220
            // 
            this.multiLayoutItem220.DataName = "bogyong_name";
            // 
            // multiLayoutItem221
            // 
            this.multiLayoutItem221.DataName = "ord_surang";
            // 
            // multiLayoutItem222
            // 
            this.multiLayoutItem222.DataName = "order_danui";
            // 
            // multiLayoutItem223
            // 
            this.multiLayoutItem223.DataName = "dv";
            // 
            // multiLayoutItem224
            // 
            this.multiLayoutItem224.DataName = "subul_surang";
            // 
            // multiLayoutItem225
            // 
            this.multiLayoutItem225.DataName = "subul_danui";
            // 
            // multiLayoutItem226
            // 
            this.multiLayoutItem226.DataName = "order_remark";
            // 
            // multiLayoutItem227
            // 
            this.multiLayoutItem227.DataName = "rp_barcode";
            // 
            // multiLayoutItem228
            // 
            this.multiLayoutItem228.DataName = "order_date";
            // 
            // multiLayoutItem229
            // 
            this.multiLayoutItem229.DataName = "order_suryang";
            // 
            // multiLayoutItem230
            // 
            this.multiLayoutItem230.DataName = "jusa_nalsu";
            // 
            // multiLayoutItem231
            // 
            this.multiLayoutItem231.DataName = "data_gubun";
            // 
            // multiLayoutItem232
            // 
            this.multiLayoutItem232.DataName = "barcode";
            // 
            // multiLayoutItem233
            // 
            this.multiLayoutItem233.DataName = "print_gubun";
            // 
            // multiLayoutItem234
            // 
            this.multiLayoutItem234.DataName = "hodong_ord_name";
            // 
            // multiLayoutItem235
            // 
            this.multiLayoutItem235.DataName = "sort_key";
            // 
            // multiLayoutItem236
            // 
            this.multiLayoutItem236.DataName = "max_bannab_yn";
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "bannab_yn";
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "fkocs2003";
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "hope_date";
            // 
            // layOrderJungbo
            // 
            this.layOrderJungbo.ExecuteQuery = null;
            this.layOrderJungbo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem83});
            this.layOrderJungbo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderJungbo.ParamList")));
            this.layOrderJungbo.QuerySQL = resources.GetString("layOrderJungbo.QuerySQL");
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "text_1";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "text_2";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "text_3";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "comments";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "bunho_comments";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "bar_drg_bunho";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "bar_rp_bunho";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "cpl_1";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "cpl_2";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "cpl_3";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "danui_1";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "danui_2";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "danui_3";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "hl_1";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "hl_2";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "hl_3";
            // 
            // layOrderBarcode
            // 
            this.layOrderBarcode.ExecuteQuery = null;
            this.layOrderBarcode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem99});
            this.layOrderBarcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderBarcode.ParamList")));
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "text_1";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "text_2";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "text_3";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "comments";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "bunho_comments";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "bar_drg_bunho";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "bar_rp_bunho";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "cpl_1";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "cpl_2";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "cpl_3";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "danui_1";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "danui_2";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "danui_3";
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "hl_1";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "hl_2";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "hl_3";
            // 
            // layAntiData
            // 
            this.layAntiData.ExecuteQuery = null;
            this.layAntiData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem165,
            this.multiLayoutItem166,
            this.multiLayoutItem167,
            this.multiLayoutItem168,
            this.multiLayoutItem169,
            this.multiLayoutItem170,
            this.multiLayoutItem171});
            this.layAntiData.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layAntiData.ParamList")));
            this.layAntiData.QuerySQL = resources.GetString("layAntiData.QuerySQL");
            this.layAntiData.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layAntiData_QueryEnd);
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "fkocs";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "in_out_gubun";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "order_date";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "bunho";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "gwa";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "doctor";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "ho_dong";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "ipwon_date";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "jubsu_date";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "v1";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "v2";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "v3";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "v4";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "v5";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "v6";
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "v7";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "v8";
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "v9";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "check01";
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "check02";
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "check03";
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "check04";
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "check05";
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "check06";
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "check07";
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "check08";
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "check09";
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "check10";
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "check11";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "check12";
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "check13";
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "check14";
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "check15";
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "check16";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "check17";
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "check18";
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "check19";
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "check20";
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "check21";
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "check22";
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "check23";
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "check24";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "check25";
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "check26";
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "check27";
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "check28";
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "check29";
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "check30";
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "check31";
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "check32";
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "check33";
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "check34";
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "check35";
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "check36";
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "check37";
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "check38";
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "check39";
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "check40";
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "check41";
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "check42";
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "check43";
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "check44";
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "check45";
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "check46";
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "check47";
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "check48";
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "check49";
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "check50";
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "suname";
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "suname2";
            // 
            // multiLayoutItem170
            // 
            this.multiLayoutItem170.DataName = "gwa_name";
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "doctor_name";
            // 
            // lbBoryuColor
            // 
            resources.ApplyResources(this.lbBoryuColor, "lbBoryuColor");
            this.lbBoryuColor.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.lbBoryuColor.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            this.lbBoryuColor.Name = "lbBoryuColor";
            // 
            // imageListMenu
            // 
            this.imageListMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMenu.ImageStream")));
            this.imageListMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMenu.Images.SetKeyName(0, "");
            this.imageListMenu.Images.SetKeyName(1, "");
            this.imageListMenu.Images.SetKeyName(2, "");
            this.imageListMenu.Images.SetKeyName(3, "");
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
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "group_ser";
            this.xEditGridCell138.Col = 14;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "hope_date";
            this.xEditGridCell141.Col = -1;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsUpdCol = false;
            this.xEditGridCell141.IsVisible = false;
            this.xEditGridCell141.Row = -1;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "group_ser";
            this.xEditGridCell142.Col = -1;
            this.xEditGridCell142.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsUpdCol = false;
            this.xEditGridCell142.IsVisible = false;
            this.xEditGridCell142.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "group_ser";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsUpdCol = false;
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "source_fkocs2003";
            this.xEditGridCell146.Col = -1;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsUpdCol = false;
            this.xEditGridCell146.IsVisible = false;
            this.xEditGridCell146.Row = -1;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "fkocs2003";
            this.xEditGridCell147.Col = -1;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsUpdCol = false;
            this.xEditGridCell147.IsVisible = false;
            this.xEditGridCell147.Row = -1;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "group_ser";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsUpdCol = false;
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "group_ser";
            this.xEditGridCell152.Col = -1;
            this.xEditGridCell152.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell152, "xEditGridCell152");
            this.xEditGridCell152.IsUpdCol = false;
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "group_ser";
            this.xEditGridCell153.Col = -1;
            this.xEditGridCell153.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell153, "xEditGridCell153");
            this.xEditGridCell153.IsUpdCol = false;
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellName = "group_ser";
            this.xEditGridCell154.Col = -1;
            this.xEditGridCell154.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell154, "xEditGridCell154");
            this.xEditGridCell154.IsUpdCol = false;
            this.xEditGridCell154.IsVisible = false;
            this.xEditGridCell154.Row = -1;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellName = "group_ser";
            this.xEditGridCell164.Col = 15;
            this.xEditGridCell164.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell164, "xEditGridCell164");
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellName = "magam_bunryu";
            this.xEditGridCell166.Col = 7;
            this.xEditGridCell166.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell166.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell166, "xEditGridCell166");
            this.xEditGridCell166.IsReadOnly = true;
            // 
            // mlayConstantInfo
            // 
            this.mlayConstantInfo.ExecuteQuery = null;
            this.mlayConstantInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem42});
            this.mlayConstantInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayConstantInfo.ParamList")));
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "code";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "code_name";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "code_value";
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.lbCycleMagamDate);
            this.xPanel2.Controls.Add(this.lbQueryBase);
            this.xPanel2.Controls.Add(this.lbCycleOrdDate);
            this.xPanel2.Controls.Add(this.dtpFromDate);
            this.xPanel2.Controls.Add(this.dtpToDate);
            this.xPanel2.Controls.Add(this.xLabel14);
            this.xPanel2.Controls.Add(this.dtpJubsuDate);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.cbxBuseo);
            this.xPanel2.Controls.Add(this.xLabel7);
            this.xPanel2.Controls.Add(this.cbxActor);
            this.xPanel2.Controls.Add(this.cbxGubun);
            this.xPanel2.Controls.Add(this.paBox);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // DRG3010P10
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Name = "DRG3010P10";
            this.Load += new System.EventHandler(this.DRG3010P10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaQuery)).EndInit();
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamJUSAOrder)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnListMimagam)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.xPanel12.ResumeLayout(false);
            this.xPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamPaQuery)).EndInit();
            this.xPanel10.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamJUSAOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrgBunhoList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnListMagam)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.xPanel17.ResumeLayout(false);
            this.xPanel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaDcQuery)).EndInit();
            this.xPanel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJusaDcOrder)).EndInit();
            this.xPanel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnListDc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaLable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAntiData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region
        //팝업메뉴 코드 관리
        IHIS.X.Magic.Menus.PopupMenu popMenu = new IHIS.X.Magic.Menus.PopupMenu();
        private ArrayList jobCodeList = new ArrayList();
        private string selectBunho = null;
        private string selectFkinp1001 = null;

        private string cycleOrdDate = null;
        private string cycleMagamDate = null;
        #endregion

        #region OnLoad
        private void DRG3010P10_Load(object sender, EventArgs e)
        {
            //base.OnLoad(e);

            // 未締切
            this.dtpJubsuDate.SetDataValue(EnvironInfo.GetSysDate());
            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());

            this.cbxBuseo.SelectedIndex = 0;
            this.cbxGubun.SelectedIndex = 0;

            this.cbxActor.SetDataValue(UserInfo.UserID); // 実施者に 現在ログインしている IDを セットする｡

            // 締切済
            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());

            //this.cbxBuseoMagam.SelectedIndex = 0;
            //this.cbxGubunMagam.SelectedIndex = 0;

            //// 返却
            //this.dtpDcFromDate.SetDataValue(EnvironInfo.GetSysDate());
            //this.dtpDcToDate.SetDataValue(EnvironInfo.GetSysDate());
            
            //this.cbxBuseoDc.SelectedIndex = 0;
            //this.cbxGubunDc.SelectedIndex = 0;

            this.tabControl.SelectedIndex = 0;
            this.tabControl.Refresh();

            //this.MiMagamQuery();
            this.btnListMimagam.PerformClick(FunctionType.Query);

            //BoryuQuery();

            // 팝업메뉴 구성
            this.jobCodeList.Add(new JobItem(0, "病棟患者管理"));
            this.jobCodeList.Add(new JobItem(1, "オーダ情報照会"));
            this.jobCodeList.Add(new JobItem(2, "治療計画管理"));
            this.jobCodeList.Add(new JobItem(3, "病棟移動履歴照会"));

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }
        #endregion

        #region PostLoad()
        private void PostLoad()
        {
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
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("chkATC_yn")) chkATC_yn = mlayConstantInfo.GetItemString(i, "code_value");

                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("chkJusaLabel")) chkJusaLabel = mlayConstantInfo.GetItemString(i, "code_value");
                }
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

        #region 미 마감환자 리스트
        private void MiMagamQuery()
        {
            grdMiMagamOrder.Reset();
            grdMiMagamJUSAOrder.Reset();

            //string magam_bunryu = "1";
            string magam_gubun = "N";

            //if (rbxBunryu1.Checked) magam_bunryu = "1";//내복, 외용
            //if (rbxBunryu2.Checked) magam_bunryu = "2";//주사

            //grdPaQuery.SetBindVarValue("f_magam_bunryu", magam_bunryu);
            grdPaQuery.SetBindVarValue("f_magam_bunryu", cbxGubun.GetDataValue());
            grdPaQuery.SetBindVarValue("f_magam_gubun", magam_gubun);

            grdMiMagamOrder.Reset();
            grdMiMagamJUSAOrder.Reset();
            if (!grdPaQuery.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }
        #endregion

        #region 마감환자 리스트
        private void MagamQuery()
        {
            grdMagamOrder.Reset();
            grdMagamJUSAOrder.Reset();
            grdDrgBunhoList.Reset();

            //string magam_bunryu = "1";

            //if (rbxBunryu1.Checked) magam_bunryu = "1";//내복, 외용
            //if (rbxBunryu2.Checked) magam_bunryu = "2";//주사

            //grdMagamPaQuery.SetBindVarValue("f_magam_gubun", magam_bunryu);
            grdMagamPaQuery.SetBindVarValue("f_magam_gubun", this.cbxGubun.GetDataValue());
            if (!grdMagamPaQuery.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }
        #endregion

        #region 보류
        /*
        private void BoryuQuery()
        {
            grdBoryuNeabok.Reset();
            grdBoryuJusa.Reset();

            //string magam_bunryu = "1";
            string magam_gubun = "N";

            //if (rbxBunryu1.Checked) magam_bunryu = "1";//내복, 외용
            //if (rbxBunryu2.Checked) magam_bunryu = "2";//주사

            if (rbxMagamGubun1.Checked) magam_gubun = "N"; //정규
            if (rbxMagamGubun2.Checked) magam_gubun = "Y"; //추가

            //grdBoryuPa.SetBindVarValue("f_magam_bunryu", magam_bunryu);
            grdBoryuPa.SetBindVarValue("f_magam_bunryu", cboGubun.GetDataValue());
            grdBoryuPa.SetBindVarValue("f_magam_gubun", magam_gubun);

            if (!grdBoryuPa.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            if (grdBoryuPa.RowCount > 0)
            {
                this.tabPage4.TitleTextColor = System.Drawing.Color.Red;
            }
            else
                this.tabPage4.TitleTextColor = System.Drawing.Color.Black;

        }
         */
        #endregion

        //private void btnAllCheck_Click(object sender, System.EventArgs e)
        //{
        //    for (int i = 0; i < grdPaQuery.RowCount; i++)
        //    {
        //        grdPaQuery.SetItemValue(i, "magam_yn", "Y");
        //    }
        //    grdPaQuery.AcceptData();
        //}

        //private void btnAllUnCheck_Click(object sender, System.EventArgs e)
        //{
        //    for (int i = 0; i < grdPaQuery.RowCount; i++)
        //    {
        //        grdPaQuery.SetItemValue(i, "magam_yn", "N");
        //    }
        //    grdPaQuery.AcceptData();
        //}

        private void grdPaQuery_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            //if (grdPaQuery.GetItemString(e.RowNumber, "append_yn") == "Y")
            if (e.DataRow["append_yn"].ToString() == "Y")
                e.ForeColor = Color.Brown;

            if (e.DataRow["juninp_yn"].ToString() == "Y")
                e.ForeColor = XColor.ErrMsgForeColor.Color;
        }

        #region [grdPaQuery_ItemValueChanging]
        private void grdPaQuery_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "magam_yn")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    this.grdPaQuery.SetItemValue(e.RowNumber, "jubsu_date", this.dtpJubsuDate.GetDataValue());

                    // 払出済処方確認
                    if (this.grdPaQuery.GetItemString(e.RowNumber, "act_buseo") == "PA") XMessageBox.Show(Resources.XMessageBox, Resources.XMessageBox_Caption, MessageBoxIcon.Information);
                }
                else
                {
                    this.grdPaQuery.SetItemValue(e.RowNumber, "jubsu_date", "");
                }
            }
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

        #region [dtpMi_DataValidating 未締切の検索日付変更]
        private void dtpMi_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.queryProcess();
        }
        #endregion

        //private void grdPaQuery_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        //{
        //    if (e.ColName == "jubsu_date")
        //    {
        //        this.jubsuDate = this.grdPaQuery.GetItemString(e.RowNumber, e.ColName);

        //        for (int i = 0; i < this.grdPaQuery.RowCount; i++)
        //        {
        //            if (this.grdPaQuery.GetItemString(i, "magam_yn") == "Y")
        //            {
        //                this.grdPaQuery.SetItemValue(i, "jubsu_date", jubsuDate);
        //            }
        //        }
        //    }
        //}

        private void rbxBunryu1_CheckedChanged(object sender, System.EventArgs e)
        {
            ////paBox.Reset();
            //if (tabControl.SelectedIndex == 0)
            //    lbDate.Text = "入力日";

            //MiMagamQuery();
            //MagamQuery();
        }

        private void grdPaQuery_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            string magam_bunryu = "1", magam_gubun = "N";

            ////내복, 외용
            //if (rbxBunryu1.Checked)
            if (grdPaQuery.GetItemString(e.CurrentRow, "magam_bunryu") == "1")
            {
                magam_bunryu = "1";
                grdMiMagamOrder.Visible = true;
                grdMiMagamJUSAOrder.Visible = false;

                magam_gubun = grdPaQuery.GetItemString(e.CurrentRow, "append_yn");

                grdMiMagamOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);
                grdMiMagamOrder.SetBindVarValue("f_magam_gubun", magam_gubun);

                if (!grdMiMagamOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            //주사
            //if (rbxBunryu2.Checked)
            if (grdPaQuery.GetItemString(e.CurrentRow, "magam_bunryu") == "2")
            {
                magam_bunryu = "2";
                grdMiMagamOrder.Visible = false;
                grdMiMagamJUSAOrder.Visible = true;

                magam_gubun = grdPaQuery.GetItemString(e.CurrentRow, "append_yn");

                grdMiMagamJUSAOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);
                grdMiMagamJUSAOrder.SetBindVarValue("f_magam_gubun", magam_gubun);

                if (!grdMiMagamJUSAOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private void grdMagamPaQuery_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            string magam_bunryu = "1";

            string magam_gubun = "";
            magam_gubun = grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "magam_gubun");

            //내복, 외용
            if ((magam_gubun == "11") || (magam_gubun == "21"))
            {
                CurrMQLayout = grdMagamOrder;
                magam_bunryu = "1";
                grdMagamOrder.Visible = true;
                grdMagamJUSAOrder.Visible = false;
                //btnLable.Visible = false;
            }

            //주사
            if ((magam_gubun == "12") || (magam_gubun == "22"))
            {
                CurrMQLayout = grdMagamJUSAOrder;
                magam_bunryu = "2";
                grdMagamOrder.Visible = false;
                grdMagamJUSAOrder.Visible = true;
                //btnLable.Visible = true;
            }

            grdDrgBunhoList.SetBindVarValue("f_magam_bunryu", magam_bunryu);
            if (!grdDrgBunhoList.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }

        #region [tabControl_SelectionChanged]
        private void tabControl_SelectionChanged(object sender, System.EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
               // this.paBox.Reset();
                this.paBox.Enabled = true;
                this.lbQueryBase.Text = "希望日付";
                this.dtpJubsuDate.Enabled = true;
                this.cbxActor.Enabled = true;
                this.MiMagamQuery();
            }

            if (tabControl.SelectedIndex == 1)
            {
               // this.paBox.Reset();
                this.lbQueryBase.Text = "受付日付";
                this.dtpJubsuDate.Enabled = false;
                this.cbxActor.Enabled = false;
                this.MagamQuery();
            }

            if (tabControl.SelectedIndex == 2)
            {
                //this.paBox.Reset();
                this.lbQueryBase.Text = "受付日付";
                this.dtpJubsuDate.Enabled = false;
                this.cbxActor.Enabled = false;
                this.DcQuery();
            }
        }
        #endregion

        private void grdPaQuery_DoubleClick(object sender, System.EventArgs e)
        {
            //paBox.SetPatientID(grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho"));
        }

        private void grdMagamOrder_DoubleClick(object sender, System.EventArgs e)
        {
            //paBox.SetPatientID(grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "bunho"));
        }

        private void grdMagamJUSAOrder_DoubleClick(object sender, System.EventArgs e)
        {
            //paBox.SetPatientID(grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "bunho"));
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

        #region 처방상태에 따른 각 필드 색상 표현 (ColumnColorForOrderState)
        /// <summary>
        /// 처방상태에 따른 각 필드 색상 표현
        /// </summary>
        /// <param name="aIOEGubun"> string 외래입원응급구분 </param>
        /// <param name="aGrd"> XGrid Grid </param>
        /// <param name="aRow"> int Row </param>
        /// <returns> void </returns>
        public void ColumnColorForOrderState(string aIOEGubun, XGrid aGrd, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (aGrd == null || e.RowNumber < 0) return;

            // 항목코드와 항목명의 색상의 변화
            // 항목명
            // 수납된경우(외래),간호확인(입원) :: 항목명의 바탕색이 하늘색으로 변함
            // 항목코드
            // Acting 된경우 (OCS_FLAG = '3')  :: 항목 글자색이 파랑색 , 항목 바탕색이 하늘색
            // 결과 입력된경우 (ResultDate)    :: 항목 글자색이 보라색 , 항목 바탕색이 하늘색
            // RESER 된경우 (OCS_FLAG = '2' )  :: 항목 글자색이 녹색
            // OCS_FLAG '0'이 아닌 경우 전달이 된경우는 글자 두께를 두껍게한다 
            // 그 외는 기본색 (글자색은 검정, 바탕색은 흰색)

            if (aGrd.GetRowState(e.RowNumber) != DataRowState.Added)
            {
                switch (e.ColName)
                {
                    case "order_gubun_name": // 처방구분명은 입력하는 필드가 아님..
                        break;
                    case "hangmog_code": // 항목코드
                        if (!TypeCheck.IsNull(aGrd.LayoutTable.Rows[e.RowNumber]["result_date"])) // 결과입력된 경우
                        {
                            e.ForeColor = Color.DeepPink;  // 보라색
                            e.BackColor = Color.SkyBlue; // 하늘색
                        }
                        else if (aGrd.LayoutTable.Rows[e.RowNumber]["ocs_flag"].ToString().Trim() == "3") // Acting인 경우
                        {
                            e.ForeColor = Color.Blue;    // 파랑색
                            e.BackColor = Color.SkyBlue; // 하늘색
                        }
                        else if (aGrd.LayoutTable.Rows[e.RowNumber]["ocs_flag"].ToString().Trim() == "2") // 예약인 경우
                        {
                            e.ForeColor = Color.Green;   // 녹색
                        }

                        // 입원이 아닌 경우는 수납체크함
                        if (aGrd.LayoutTable.Rows[e.RowNumber]["ocs_flag"].ToString().Trim() == "0" &&
                            ((aIOEGubun != "I" && aGrd.LayoutTable.Rows[e.RowNumber]["sunab_check"].ToString().Trim() == "N") ||
                            (aIOEGubun == "I" && true)) &&
                            aGrd.LayoutTable.Rows[e.RowNumber]["dc_check"].ToString().Trim() == "N") // 전달이 아닌경우
                        {

                        }
                        else
                        {
                            e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, IHIS.Framework.XEditGrid.DefaultFont.Size, FontStyle.Bold);
                        }

                        break;

                    case "hangmog_name": // 항목코드
                        // BackColor 지정
                        // 입원이 아닌 경우 수납이 된 경우, 입원이면서 간호확인 된 경우
                        if ((aIOEGubun != "I" && aGrd.LayoutTable.Rows[e.RowNumber]["sunab_check"].ToString().Trim() == "Y") ||
                            (aIOEGubun == "I" && aGrd.LayoutTable.Rows[e.RowNumber]["confirm_check"].ToString().Trim() == "Y"))
                        {
                            e.BackColor = Color.SkyBlue; // 하늘색
                        }

                        break;
                }
            }

            // Dc/반납 데이타 ForeColor = Rad 색상 표시 , Dc 원데이타는 항목과 항목명망 중간에 빨강색 라인표시
            if (!TypeCheck.IsNull(aGrd.LayoutTable.Rows[e.RowNumber]["nalsu"]) &&
                int.Parse(TypeCheck.NVL(aGrd.LayoutTable.Rows[e.RowNumber]["nalsu"], 0).ToString()) < 0)
            {
                e.ForeColor = Color.Red;
            }
            else if (aGrd.LayoutTable.Rows[e.RowNumber]["dc_yn"].ToString().Trim() == "Y")
            {
                switch (e.ColName)
                {
                    case "hangmog_code":
                    case "hangmog_name": // 항목코드
                        e.DrawMiddleLine = true;
                        e.MiddleLineColor = Color.Red;
                        break;
                }
            }
        }
        #endregion

        private void grdDrgBunhoList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            string magam_bunryu = this.grdMagamPaQuery.GetItemString(this.grdMagamPaQuery.CurrentRowNumber, "magam_bunryu");

            if (magam_bunryu == "1")
            //if (rbxBunryu1.Checked)
            {
                if (!grdMagamOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            else
            {
                if (!grdMagamJUSAOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private void grdDrgBunhoList_DoubleClick(object sender, System.EventArgs e)
        {
            //paBox.SetPatientID(grdDrgBunhoList.GetItemString(grdDrgBunhoList.CurrentRowNumber, "bunho"));
        }

        private void btnBoryu_Click(object sender, System.EventArgs e)
        {
            if (XMessageBox.Show(Resources.DRG3010P10_btnBoryu_msg, Resources.DRG3010P10_btnBoryu_caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //if (rbxBunryu1.Checked)
                if (grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "magam_bunryu") == "1")
                {
                    for (int i = 0; i < grdMiMagamOrder.RowCount; i++)
                    {
                        grdMiMagamOrder.SetItemValue(i, "re_use_yn", "Y");
                    }
                    BoRyuMethod("grdMiMagamOrder");

                }
                else
                {
                    for (int i = 0; i < grdMiMagamJUSAOrder.RowCount; i++)
                    {
                        grdMiMagamJUSAOrder.SetItemValue(i, "re_use_yn", "Y");
                    }
                    BoRyuMethod("grdMiMagamJUSAOrder");
                }

                //BoryuQuery();

                MiMagamQuery();
            }
        }

        /// <summary>
        /// dsvBoRyu Service Conversion
        /// </summary>
        /// <param name="kbn"></param>
        /// <returns>io_err</returns>
        private void BoRyuMethod(string kbn)
        {
            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            object retVal = null;
            bindVars.Add("q_user_id", UserInfo.UserID);
            try
            {
                Service.BeginTransaction();
                if (kbn.Equals("grdMiMagamOrder"))
                {
                    for (int i = 0; i < grdMiMagamOrder.RowCount; i++)
                    {
                        cmdText = string.Empty;
                        bindVars.Clear();
                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                        bindVars.Add("f_fkocs2003", grdMiMagamOrder.GetItemString(i, "fkocs2003"));
                        bindVars.Add("f_re_use_yn", grdMiMagamOrder.GetItemString(i, "re_use_yn"));
                        bindVars.Add("f_user_id", UserInfo.UserID);
                        cmdText = @"SELECT NVL(B.TOIWON_GOJI_YN,'N') TOIWON_GOJI_YN
                                  FROM INP1001 B
                                     , OCS2003 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.PKOCS2003 = :f_fkocs2003
                                   AND A.FKINP1001 = B.PKINP1001";
                        retVal = Service.ExecuteScalar(cmdText, bindVars);
                        if (!TypeCheck.IsNull(retVal) && retVal.Equals("Y"))
                        {
                            XMessageBox.Show(Service.ExecuteScalar("SELECT FN_ADM_MSG(909) FROM DUAL").ToString(), "エラー", MessageBoxIcon.Warning);
                            return;
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
                                     WHERE HOSP_CODE = :f_hosp_code
                                       AND FKOCS2003 = :f_fkocs2003";
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
                else if (kbn.Equals("grdMiMagamJUSAOrder"))
                {
                    for (int i = 0; i < grdMiMagamJUSAOrder.RowCount; i++)
                    {
                        cmdText = string.Empty;
                        bindVars.Clear();
                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                        bindVars.Add("f_fkocs2003", grdMiMagamJUSAOrder.GetItemString(i, "fkocs2003"));
                        bindVars.Add("f_re_use_yn", grdMiMagamJUSAOrder.GetItemString(i, "re_use_yn"));
                        bindVars.Add("f_user_id", UserInfo.UserID);
                        cmdText = @"SELECT NVL(B.TOIWON_GOJI_YN,'N') TOIWON_GOJI_YN
                                  FROM INP1001 B
                                     , OCS2003 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.PKOCS2003 = :f_fkocs2003
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
                                     WHERE HOSP_CODE = :f_hosp_code
                                       AND FKOCS2003 = :f_fkocs2003";
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
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(xe.Message);
                return;
            }
            Service.CommitTransaction();
        }

        private void btnCommentForm_Click(object sender, System.EventArgs e)
        {
            string bunho = grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho");
            if (bunho == "")
            {
                MessageBox.Show(Resources.btnCommentForm_Click_msg);
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("in_out_gubun", "I");
            openParams.Add("bunho", bunho);
            openParams.Add("from_date", dtpFromDate.GetDataValue());
            openParams.Add("to_date", dtpToDate.GetDataValue());

            XScreen.OpenScreenWithParam(this, "DRGS", "DRG9040U01", ScreenOpenStyle.PopUpFixed, openParams);
        }

        private void btnComment_Click(object sender, System.EventArgs e)
        {
            //string bunho = "";

            //if (rbxBunryu1.Checked)
            //{
            //    if (grdMagamOrder.CurrentRowNumber < 0) return;
            //    bunho = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "bunho");
            //}
            ////주사
            //if (rbxBunryu2.Checked)
            //{
            //    if (grdMagamJUSAOrder.CurrentRowNumber < 0) return;
            //    bunho = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "bunho");
            //}

            //if (bunho == "")
            //{
            //    MessageBox.Show("患者番号を入力してください。");
            //}

            //CommonItemCollection openParams = new CommonItemCollection();
            //openParams.Add("in_out_gubun", "I");
            //openParams.Add("bunho", bunho);
            //openParams.Add("from_date", dtpFromDate.GetDataValue());
            //openParams.Add("to_date", dtpToDate.GetDataValue());

            //XScreen.OpenScreenWithParam(this, "DRGS", "DRG9040U01", ScreenOpenStyle.PopUpFixed, openParams);
        }

        private void btnRangeCancel_Click(object sender, System.EventArgs e)
        {
            if (XMessageBox.Show(Resources.btnRangeCancel_Click_msg, Resources.btnRangeCancel_Click_caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();
                inputList.Add(grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "magam_date"));
                inputList.Add(grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "magam_gubun"));
                inputList.Add(grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "magam_ser"));
                inputList.Add("%");
                inputList.Add("PA");
                inputList.Add("PA");
                if (!Service.ExecuteProcedure("PR_DRG_INP_MAGAM_CANCEL", inputList, outputList))
                {
                    XMessageBox.Show(outputList[0].ToString(), "PR_DRG_INP_MAGAM_CANCEL", MessageBoxIcon.Hand);
                }
            }

            MagamQuery();
        }

        #region [btnNumberCancel_Click 投薬番号別取消]
        private void btnNumberCancel_Click(object sender, System.EventArgs e)
        {
            if (this.grdMagamPaQuery.RowCount < 1) return;

            if (grdDrgBunhoList.GetItemString(grdDrgBunhoList.CurrentRowNumber, "mix_date") != "")
            {
                XMessageBox.Show(Resources._btnNumberCancel_Click_msg,Resources.caption_name, MessageBoxIcon.Information);
                return;
            }

            string drg_bunho = "", jubsu_date = "";

            string magam_gubun = "";
            magam_gubun = grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "magam_gubun");

            //내복, 외용
            if ((magam_gubun == "11") || (magam_gubun == "21"))
            {
                if (grdMagamOrder.CurrentRowNumber < 0) return;

                jubsu_date = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "drg_bunho");
            }
            //주사
            if ((magam_gubun == "12") || (magam_gubun == "22"))
            {
                if (grdMagamJUSAOrder.CurrentRowNumber < 0) return;
                jubsu_date = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "drg_bunho");
            }

            if (XMessageBox.Show(Resources.btnRangeCancel_Click_msg, Resources.btnRangeCancel_Click_caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();
                inputList.Add(jubsu_date);
                inputList.Add(drg_bunho);
                inputList.Add(this.cbxActor.GetDataValue());

                if (!Service.ExecuteProcedure("PR_DRG_INP_DRG_BUNHO_CANCEL", inputList, outputList))
                {
                    XMessageBox.Show(outputList[0].ToString());
                }
                else
                {
                    if (outputList[0].ToString() == "1")
                    {
                        XMessageBox.Show(Resources.XMessageBox1, Resources.caption_name, MessageBoxIcon.Warning);
                        return;
                    }

                    if (outputList[0].ToString() == "X")
                    {
                        XMessageBox.Show(Resources.XMessageBox2, Resources.caption_name, MessageBoxIcon.Warning);
                        return;
                    }

                    if (outputList[0].ToString() == "Y")
                    {
                        XMessageBox.Show(Resources.XMessageBox3, Resources.caption_name, MessageBoxIcon.Warning);
                        return;
                    }

                    #region [3点チェックデータ削除処理]
                    // 注射の場合
                    if ((magam_gubun == "12") || (magam_gubun == "22"))
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
                }
            }

            this.MagamQuery();
        }
        #endregion

        #region [処方箋再印刷]
        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            string drg_bunho = "";
            string jubsu_date = "";
            string magam_gubun = "";

            magam_gubun = grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "magam_gubun");

            //내복, 외용
            if ((magam_gubun == "11") || (magam_gubun == "21"))
            {
                if (grdMagamOrder.CurrentRowNumber < 0) return;
                jubsu_date = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "drg_bunho");
            }
            //주사
            if ((magam_gubun == "12") || (magam_gubun == "22"))
            {
                if (grdMagamJUSAOrder.CurrentRowNumber < 0) return;
                jubsu_date = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "drg_bunho");
            }

            // 처방전 출력
            DrgPrint(jubsu_date, drg_bunho, magam_gubun, "R");
        }
        #endregion


        /// <summary>
        /// 처방전 출력
        /// 11 : 내복 정규
        /// 12 : 내복 임시
        /// 21 : 주사 정규
        /// 22 : 주사 임시
        /// 31 : 퇴원
        /// er : 응급마감
        /// </summary>
        /// <param name="ar_JubsuDate"></param>
        /// <param name="ar_DrgBunho"></param>
        /// <param name="ar_MagamGubun"></param>

        private void DrgPrint(string ar_JubsuDate, string ar_DrgBunho, string ar_MagamGubun, string ar_Print_Gubun)
        {
            //int row;

            //내복, 외용
            if ((ar_MagamGubun == "11") || (ar_MagamGubun == "21"))
            {
                #region 약국용 처방전
                //A4 用　d_drg3010_1（dw_1　＋　dw_2）
                //dw_print.DataWindowObject = "d_drg3010_1";
     //           dw_print.DataWindowObject = "d_drg3010_order";

      //          dw_print.Reset();

                // 오다 내역 조회
                if (DsvOrderPrint(ar_JubsuDate, ar_DrgBunho, ar_Print_Gubun))
                {
                    //dw_print.FillChildData("dw_1", layOrderPrint.LayoutTable);
      //              dw_print.FillData(layOrderPrint.LayoutTable);
                }

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
                //}
                //else
                //{
                //    return;
                //}

                #endregion

                #region 병동용 처방전
                //// A4 用　d_drg3010_1_ho_dong（dw_1　＋　dw_2）
                ////dw_print.DataWindowObject = "d_drg3010_1_ho_dong";

                //dw_print.DataWindowObject = "d_drg3010_order_ho_dong";

                //dw_print.Reset();

                //dw_print.FillData(layOrderPrint.LayoutTable);

                ////dw_print.FillChildData("dw_1", layOrderPrint.LayoutTable);

                //// comment 조회
                ////if (DsvOrderBarcode(ar_JubsuDate, ar_DrgBunho))
                ////{
                ////    dw_print.FillChildData("dw_2", layOrderBarcode.LayoutTable);
                ////}

                ////dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);

                //dw_print.AcceptText();
                //if (dw_print.RowCount > 0)
                //    dw_print.Print();
                #endregion

                //#region 향균의뢰서 출력
                //if (DsvDrg1000Load(ar_JubsuDate, ar_DrgBunho) != "")
                //{
                //    dw_Anti.Reset();
                //    layAntiData.SetBindVarValue("f_fkocs", DsvDrg1000Load(ar_JubsuDate, ar_DrgBunho));
                //    if (layAntiData.QueryLayout(false))
                //    {
                //        dw_Anti.FillData(layAntiData.LayoutTable);
                //        dw_Anti.Print();
                //    }
                //    else
                //        XMessageBox.Show(Service.ErrFullMsg);
                //}
                //#endregion

                return;
            }


            //주사
            if ((ar_MagamGubun == "12") || (ar_MagamGubun == "22"))
            {
                #region 약국용 처방전
                //A4 用　d_drg3010_4（dw_1　＋　dw_2）
                //dw_jusa.DataWindowObject = "d_drg3010_4";
    //            dw_jusa.DataWindowObject = "d_drg3010_jusa";

    //            dw_jusa.Reset();

                // 오다 내역 조회
                if (DsvJusaOrderPrint(ar_JubsuDate, ar_DrgBunho, ar_Print_Gubun))
                {
                    //dw_jusa.FillChildData("dw_1", layJusaOrderPrint.LayoutTable);
  //                  dw_jusa.FillData(layJusaOrderPrint.LayoutTable);
                }
                //// comment 조회
                //if (DsvOrderJungbo(ar_JubsuDate, ar_DrgBunho))
                //{
                //    dw_jusa.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                //}

                //if (layOrderJungbo.RowCount < 1)
                //{
                //    row = layOrderJungbo.InsertRow(0);
                //    layOrderJungbo.SetItemValue(row, "bar_drg_bunho", ar_JubsuDate.Replace("/", "") + ar_DrgBunho);
                //    dw_jusa.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                //}

   //             dw_jusa.AcceptText();
                //if (dw_jusa.RowCount > 0)
                //{
                //    dw_jusa.Print();
                //}
                else
                    return;
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

                //#region 향균의뢰서 출력
                //if (DsvDrg1000Load(ar_JubsuDate, ar_DrgBunho) != "")
                //{
                //    dw_Anti.Reset();
                //    layAntiData.SetBindVarValue("f_fkocs", DsvDrg1000Load(ar_JubsuDate, ar_DrgBunho));
                //    if (layAntiData.QueryLayout(false))
                //    {
                //        dw_Anti.FillData(layAntiData.LayoutTable);
                //        dw_Anti.Print();
                //    }
                //    else
                //        XMessageBox.Show(Service.ErrFullMsg);
                //}
                //#endregion
                return;
            }
        }

        #region [-- DsvOrderPrint --]
        /// <summary>
        /// dsvOrderPrint Service Conversion PC: DRGPRINT, WT: E
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
            string o_hope_date = string.Empty;
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

            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);

            /* DRGPRINT_I_ORD_PRN_CUR */
            cmdText = @"SELECT DISTINCT
                               A.BUNHO                                             BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))                         DRG_BUNHO
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )    ORDER_DATE_TEXT
                              ,A.JUBSU_DATE                                        JUBSU_DATE
                              ,A.HOPE_DATE                                         HOPE_DATE
                              ,A.ORDER_DATE                                        ORDER_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M') SERIAL_V
                              ,E.SERIAL_V                                          SERIAL_TEXT
                              ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)           GWA_NAME
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
                         WHERE A.HOSP_CODE          = :f_hosp_code
                           AND A.JUBSU_DATE         = :f_jubsu_date
                           AND A.DRG_BUNHO          = :f_drg_bunho
                           AND A.BUNRYU1            <> '4'
                           --AND NVL(A.DC_YN,'N')     = 'N'
                           --AND NVL(A.BANNAB_YN,'N') = 'N'
                           AND B.HOSP_CODE       (+)= A.HOSP_CODE
                           AND B.JAERYO_CODE     (+)= A.JAERYO_CODE
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
                    o_hope_date = resTable.Rows[i]["hope_date"].ToString();
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

                    /* DRGPRINT_I_ORD_PRN_SERIAL */
                    cmdText = @"SELECT DISTINCT
                                       A.BUNHO                                                                                 BUNHO
                                      ,A.DRG_BUNHO                                                                             DRG_BUNHO
                                      ,A.GROUP_SER                                                                             GROUP_SER
                                      ,TO_CHAR(A.JUBSU_DATE,'yyyy/MM/dd')                                                      JUBSU_DATE
                                      ,TO_CHAR(G.HOPE_DATE, 'yyyy/MM/dd')                                                      HOPE_DATE
                                      ,TO_CHAR(A.ORDER_DATE,'yyyy/MM/dd')                                                      ORDER_DATE
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
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                    SUNAB_DATE
                                      ,B.PATTERN                                                                               PATTERN
                                      ,F.HANGMOG_NAME                                                                          JAERYO_NAME
                                      ,0                                                                                       SUNAB_NALSU
                                      ,NVL(D.WONYOI_ORDER_YN,'N')                                                              WONYOI_YN
                                      ,F.HANGMOG_NAME || ' : ' ||  TRIM(D.ORDER_REMARK)                                        ORDER_REMARK
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                    ACT_DATE
                                      ,NVL(C.MIX_YN_INP,'N')                                                                   UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                         SUBUL_SURYANG
                                      ,'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M')     SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                               GWA_NAME
                                      --,FN_OCS_LOAD_ORDER_DOCTOR_NAME(A.FKOCS2003)                                            DOCTOR_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(G.RESIDENT, G.ORDER_DATE)                                       DOCTOR_NAME
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA)                             OTHER_GWA
                                      --,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE )                                         HOPE_DATE
                                      ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I')                                        POWDER_YN
                                      ,NVL(E.SERIAL_V, 1)                                                                      LINE
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)                                       ORD_DANUI2
                                      ,SUBSTRB(TRIM(A.BUNRYU1),1,1)                                                            BUNRYU1
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)                          HO_DONG
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)                          HO_CODE              
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                   DONBOK
                                      --,FN_AKU_LOAD_TUSUK_YOIL(A.BUNHO, A.ORDER_DATE)                                           TUSUK
                                      ,''                                                                                       TUSUK
                                      ,DECODE(G.TOIWON_DRG_YN, '1', 'OT', G.MAGAM_GUBUN)                                       MAGAM_GUBUN
                                      ,C.TEXT_COLOR                                                                            TEXT_COLOR
                                      ,C.CHANGGO1                                                                              CHANGGO
                                      --,'( ' || TO_CHAR(A.ORDER_DATE,'MM/DD')                                                   FROM_ORDER_DATE
                                      --,TO_CHAR(A.ORDER_DATE + A.NALSU - 1, 'MM/DD') || ' )'                                    TO_ORDER_DATE
                                      ,'( ' || TO_CHAR(G.HOPE_DATE,'MM/DD')                                                   FROM_ORDER_DATE
                                      ,TO_CHAR(G.HOPE_DATE + A.NALSU - 1, 'MM/DD') || ' )'                                    TO_ORDER_DATE
                                      ,'A'                                                                                     DATA_GUBUN
                                      ,NVL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                   HODONG_ORD_NAME
                                      ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.HOSP_CODE  = :f_hosp_code
                                           AND Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND X.HOSP_CODE  = Y.HOSP_CODE
                                           AND Y.FKOCS2003  = X.FKOCS2003
                                           AND Y.FKOCS2003  = E.FKOCS2003)                                                     MAX_BANNAB_YN
                                  FROM OCS0103 F
                                      ,DRG2035 E
                                      ,OCS2003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG3011 A
                                      ,DRG3010 G
                                 WHERE A.HOSP_CODE        = :f_hosp_code
                                   AND A.JUBSU_DATE       = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.DRG_BUNHO        = :f_drg_bunho
                                   AND B.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                                   AND C.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND C.JAERYO_CODE   (+)= A.JAERYO_CODE
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
                                   AND D.ORDER_DATE       BETWEEN   F.START_DATE AND NVL(F.END_DATE, '9998/12/31')
                                 ORDER BY A.DRG_BUNHO, 'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M'), A.FKOCS2003";

                    dtSerial = Service.ExecuteDataTable(cmdText, bindVars);
                    for (int j = 0; j < dtSerial.Rows.Count; j++)
                    {
                        o_bunho = dtSerial.Rows[j]["bunho"].ToString();
                        o_drg_bunho = dtSerial.Rows[j]["drg_bunho"].ToString();
                        o_group_ser = dtSerial.Rows[j]["group_ser"].ToString();
                        o_jubsu_date = dtSerial.Rows[j]["jubsu_date"].ToString();
                        o_hope_date = dtSerial.Rows[j]["hope_date"].ToString();
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
                        //o_hope_date = dtSerial.Rows[j]["hope_date"].ToString();
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
                        layOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
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
                        //layOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
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

                        cmdText = @"SELECT DISTINCT
                                       A.BUNHO                                                                                 BUNHO
                                      ,A.DRG_BUNHO                                                                             DRG_BUNHO
                                      ,A.GROUP_SER                                                                             GROUP_SER
                                      ,TO_CHAR(A.JUBSU_DATE,'yyyy/MM/dd')                                                      JUBSU_DATE
                                      ,TO_CHAR(A.HOPE_DATE,'yyyy/MM/dd')                                                       HOPE_DATE
                                      ,TO_CHAR(A.ORDER_DATE,'yyyy/MM/dd')                                                      ORDER_DATE
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
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                                          ACT_DATE
                                      ,NVL(C.MIX_YN_INP,'N')                                                                   UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                         SUBUL_SURYANG
                                      ,'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(:f_serial_v),'00'))||DECODE(A.MIX_GROUP,NULL,'',' M')    SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                               GWA_NAME
                                      ,FN_OCS_LOAD_ORDER_DOCTOR_NAME(A.FKOCS2003)                                              DOCTOR_NAME
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA)                             OTHER_GWA
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE )                                         HOPE_DATE
                                      ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I')                                        POWDER_YN
                                      ,NVL(:f_serial_v,'1')                                                                   LINE
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)                                       ORD_DANUI2
                                      ,SUBSTRB(TRIM(A.BUNRYU1),1,1)                                                            BUNRYU1
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)                          HO_DONG
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)                          HO_CODE
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                   DONBOK
                                      --,FN_AKU_LOAD_TUSUK_YOIL(A.BUNHO, A.ORDER_DATE)                                           TUSUK
                                      ,''                                                                                     TUSUK
                                      ,DECODE(A.TOIWON_DRG_YN, '1', 'OT', A.MAGAM_GUBUN)                                       MAGAM_GUBUN
                                      ,C.TEXT_COLOR                                                                            TEXT_COLOR
                                      ,C.CHANGGO1                                                                              CHANGGO
                                      ,'( ' || TO_CHAR(A.HOPE_DATE,'MM/DD')                                                   FROM_ORDER_DATE
                                      ,TO_CHAR(A.HOPE_DATE + A.NALSU - 1, 'MM/DD') || ' )'                                    TO_ORDER_DATE
                                      ,'A'                                                                                     DATA_GUBUN
                                      ,NVL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                   HODONG_ORD_NAME
                                      --,'Y'
                                      ,NVL(A.BANNAB_YN,'N')                                                                    MAX_BANNAB_YN
                                  FROM OCS0103 F
                                      ,OCS2003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG3010 A
                                 WHERE A.HOSP_CODE        = :f_hosp_code
                                   AND A.SOURCE_FKOCS2003 = :f_fkocs2003
                                   AND B.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                                   AND C.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND C.JAERYO_CODE   (+)= A.JAERYO_CODE
                                   AND D.HOSP_CODE        = A.HOSP_CODE
                                   AND D.PKOCS2003        = A.FKOCS2003
                                   AND F.HOSP_CODE        = D.HOSP_CODE
                                   AND F.HANGMOG_CODE     = D.HANGMOG_CODE
                                   AND D.ORDER_DATE       BETWEEN   F.START_DATE AND NVL(F.END_DATE, '9998/12/31')
                                 ORDER BY A.FKOCS2003";

                        dtBannab = Service.ExecuteDataTable(cmdText, bindVars);
                        for (int t = 0; t < dtBannab.Rows.Count; t++)
                        {
                            o_bunho = dtBannab.Rows[t]["bunho"].ToString();
                            o_drg_bunho = dtBannab.Rows[t]["drg_bunho"].ToString();
                            o_group_ser = dtBannab.Rows[t]["group_ser"].ToString();
                            o_jubsu_date = dtBannab.Rows[t]["jubsu_date"].ToString();
                            o_hope_date = dtBannab.Rows[t]["hope_date"].ToString();
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
                            layOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
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
                                      ,TO_CHAR(A.JUBSU_DATE,'yyyy/MM/dd')                                                     JUBSU_DATE
                                      ,TO_CHAR(G.HOPE_DATE,'yyyy/MM/dd')                                                      HOPE_DATE
                                      ,TO_CHAR(A.ORDER_DATE,'yyyy/MM/dd')                                                     ORDER_DATE
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
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                   SUNAB_DATE
                                      ,B.PATTERN                                                                              PATTERN
                                      ,F.HANGMOG_NAME                                                                         JAERYO_NAME
                                      ,0                                                                                      SUNAB_NALSU
                                      ,NVL(D.WONYOI_ORDER_YN,'N')                                                             WONYOI_YN
                                      ,F.HANGMOG_NAME || ' : ' || TRIM(D.ORDER_REMARK)                                        ORDER_REMARK
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                   ACT_DATE
                                      ,NVL(C.MIX_YN_INP,'N')                                                                  UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                        SUBUL_SURYANG
                                      ,'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M')    SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                              GWA_NAME
                                      ,FN_OCS_LOAD_ORDER_DOCTOR_NAME(A.FKOCS2003)                                             DOCTOR_NAME
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA)                            OTHER_GWA
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE )                                        HOPE_DATE
                                      ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I')                                       POWDER_YN
                                      ,NVL(E.SERIAL_V, 1)                                                                     LINE
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)                                      ORD_DANUI2
                                      ,SUBSTRB(TRIM(A.BUNRYU1),1,1)                                                           BUNRYU1
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)                         HO_CODE
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)                         HO_DONG
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                  DONBOK
                                      --,FN_AKU_LOAD_TUSUK_YOIL(A.BUNHO, A.ORDER_DATE)                                          TUSUK
                                      ,''                                                                                     TUSUK
                                      ,DECODE(G.TOIWON_DRG_YN, '1', 'OT', G.MAGAM_GUBUN)                                      MAGAM_GUBUN
                                      ,C.TEXT_COLOR                                                                           TEXT_COLOR
                                      ,C.CHANGGO1                                                                             CHANGGO
                                      ,'( ' || TO_CHAR(G.HOPE_DATE,'MM/DD')                                                  FROM_ORDER_DATE
                                      ,TO_CHAR(G.HOPE_DATE + A.NALSU - 1, 'MM/DD') || ' )'                                   TO_ORDER_DATE
                                      ,'B'                                                                                    DATA_GUBUN
                                      ,NVL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                  HODONG_ORD_NAME
                                      ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.HOSP_CODE  = :f_hosp_code 
                                           AND Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND X.HOSP_CODE  = Y.HOSP_CODE
                                           AND Y.FKOCS2003  = X.FKOCS2003
                                           AND Y.FKOCS2003  = E.FKOCS2003)                                                     MAX_BANNAB_YN
                                  FROM OCS0103 F
                                      ,DRG2035 E
                                      ,OCS2003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG3011 A
                                      ,DRG3010 G
                                 WHERE A.HOSP_CODE        = :f_hosp_code
                                   AND A.JUBSU_DATE       = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.DRG_BUNHO        = :f_drg_bunho
                                   AND B.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                                   AND C.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND C.JAERYO_CODE   (+)= A.JAERYO_CODE
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
                                   AND D.ORDER_DATE       BETWEEN   F.START_DATE AND NVL(F.END_DATE, '9998/12/31')
                                 ORDER BY A.DRG_BUNHO, 'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M'), A.FKOCS2003";

                    dtRemark = Service.ExecuteDataTable(cmdText, bindVars);
                    
                    for (int k = 0; k < dtRemark.Rows.Count; k++)
                    {
                        o_bunho = dtRemark.Rows[k]["bunho"].ToString();
                        o_drg_bunho = dtRemark.Rows[k]["drg_bunho"].ToString();
                        o_group_ser = dtRemark.Rows[k]["group_ser"].ToString();
                        o_jubsu_date = dtRemark.Rows[k]["jubsu_date"].ToString();
                        o_hope_date = dtRemark.Rows[k]["hope_date"].ToString();
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
                        layOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
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
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
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
            layJusaOrderPrint.Reset();

            string o_print_gubun = string.Empty;
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
            string o_bannab_yn = string.Empty;
            string o_max_bannab_yn = string.Empty;
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
                              ,TO_CHAR(A.HOPE_DATE, 'yyyy/MM/dd')                  HOPE_DATE
                              ,TO_CHAR(A.ORDER_DATE,'yyyy/MM/dd')                  ORDER_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M') SERIAL_V
                              ,E.SERIAL_V                                          SERIAL_TEXT
                              ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)           GWA_NAME
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
                          FROM DRG2035 E
                              ,OUT0101 D
                              ,DRG0120 C
                              ,INV0110 B
                              ,DRG3010 A
                         WHERE A.HOSP_CODE          = :f_hosp_code
                           AND A.JUBSU_DATE         = :f_jubsu_date
                           AND A.DRG_BUNHO          = :f_drg_bunho
                           AND A.BUNRYU1            IN ('4')
                           --AND NVL(A.DC_YN,'N')     = 'N'
                           --AND NVL(A.BANNAB_YN,'N') = 'N'
                           AND B.HOSP_CODE          (+)= A.HOSP_CODE
                           AND B.JAERYO_CODE        (+)= A.JAERYO_CODE
                           AND C.HOSP_CODE          (+)= A.HOSP_CODE
                           AND C.BOGYONG_CODE       (+)= A.BOGYONG_CODE
                           AND D.HOSP_CODE          = A.HOSP_CODE
                           AND D.BUNHO              = A.BUNHO
                           AND E.HOSP_CODE          = A.HOSP_CODE
                           AND E.JUBSU_DATE         = A.JUBSU_DATE
                           AND E.DRG_BUNHO          = A.DRG_BUNHO
                           AND E.FKOCS2003          = A.FKOCS2003
                         ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
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
                                         WHERE Y.HOSP_CODE  = :f_hosp_code
                                           AND Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND X.HOSP_CODE  = Y.HOSP_CODE
                                           AND Y.FKOCS2003  = X.FKOCS2003)              MAX_BANNAB_YN
                                  ,A.BANNAB_YN                                          BANNAB_YN
                                  ,A.FKOCS2003                                          FKOCS2003
                              FROM DRG2035 E
                                  ,INV0110 D
                                  ,OCS2003 C
                                  ,OCS0103 B
                                  ,DRG3010 A
                             WHERE A.HOSP_CODE          = :f_hosp_code
                               AND A.JUBSU_DATE         = :f_jubsu_date
                               AND A.DRG_BUNHO          = :f_drg_bunho
                               AND A.BUNRYU1            IN ('4')
                               --AND NVL(A.DC_YN,'N')     = 'N'
                               --AND NVL(A.BANNAB_YN,'N') = 'N'
                               AND B.HOSP_CODE          = C.HOSP_CODE
                               AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                               AND A.HOSP_CODE          = D.HOSP_CODE(+)
                               AND A.JAERYO_CODE        = D.JAERYO_CODE(+)
                               AND E.HOSP_CODE          = A.HOSP_CODE
                               AND E.JUBSU_DATE         = A.JUBSU_DATE
                               AND E.DRG_BUNHO          = A.DRG_BUNHO
                               AND E.FKOCS2003          = A.FKOCS2003
                               AND C.HOSP_CODE          = A.HOSP_CODE
                               AND C.PKOCS2003          = A.FKOCS2003
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
                        layJusaOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);


                        //반납건 추가 조회
                        bindVars.Remove("f_serial_v");
                        bindVars.Add("f_serial_v", o_serial_text);
                        bindVars.Add("f_fkocs2003", o_fkocs2003);

                        cmdText = @"SELECT A.JAERYO_CODE                                JAERYO_CODE
                                  ,A.NALSU                                              NALSU
                                  ,A.DIVIDE                                             DIVIDE
                                  ,A.ORDER_SURYANG                                      ORDER_SURYANG
                                  ,A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                  ,CASE WHEN A.NALSU < 0 THEN '-'||CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN '0'||ROUND(A.ORD_SURYANG,2) ELSE ''||ROUND(A.ORD_SURYANG,2) END
                                                           ELSE ''||CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN '0'||ROUND(A.ORD_SURYANG,2) ELSE ''||ROUND(A.ORD_SURYANG,2) END
                                                           END                                                                 ORD_SURYANG
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
                             WHERE A.HOSP_CODE          = :f_hosp_code
                               AND A.SOURCE_FKOCS2003   = :f_fkocs2003
                               AND B.HOSP_CODE          = C.HOSP_CODE
                               AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                               AND A.HOSP_CODE          = D.HOSP_CODE(+)
                               AND A.JAERYO_CODE        = D.JAERYO_CODE(+)
                               AND C.HOSP_CODE          = A.HOSP_CODE
                               AND C.PKOCS2003          = A.FKOCS2003
                               AND C.ORDER_DATE         BETWEEN   B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
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
                            layJusaOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
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
                                  ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.HOSP_CODE  = :f_hosp_code
                                           AND Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND X.HOSP_CODE  = Y.HOSP_CODE
                                           AND Y.FKOCS2003  = X.FKOCS2003)              MAX_BANNAB_YN
                                  ,A.BANNAB_YN                                          BANNAB_YN
                                  ,A.FKOCS2003                                          FKOCS2003
                              FROM DRG2035 E
                                  ,INV0110 D
                                  ,OCS2003 C
                                  ,OCS0103 B
                                  ,DRG3010 A
                             WHERE A.HOSP_CODE          = :f_hosp_code
                               AND A.JUBSU_DATE         = :f_jubsu_date
                               AND A.DRG_BUNHO          = :f_drg_bunho
                               AND A.BUNRYU1            IN ('4')
                               --AND NVL(A.DC_YN,'N')     = 'N'
                               --AND NVL(A.BANNAB_YN,'N') = 'N'
                               AND TRIM(C.ORDER_REMARK) IS NOT NULL   -- COMMENT 조회
                               AND B.HOSP_CODE          = C.HOSP_CODE
                               AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                               AND C.ORDER_DATE         BETWEEN   B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                               AND A.HOSP_CODE          = D.HOSP_CODE(+)
                               AND A.JAERYO_CODE        = D.JAERYO_CODE(+)
                               AND E.HOSP_CODE          = A.HOSP_CODE
                               AND E.JUBSU_DATE         = A.JUBSU_DATE
                               AND E.DRG_BUNHO          = A.DRG_BUNHO
                               AND C.HOSP_CODE          = A.HOSP_CODE
                               AND C.PKOCS2003          = A.FKOCS2003
                               AND E.FKOCS2003          = A.FKOCS2003
                               AND E.SERIAL_V           = :f_serial_text
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
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
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
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
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
                         WHERE A.HOSP_CODE      = :f_hosp_code
                           AND A.JUBSU_DATE     = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.DRG_BUNHO      = :f_drg_bunho
                           AND B.HOSP_CODE      = A.HOSP_CODE
                           AND B.FKOCS          = A.FKOCS2003
                           AND C.HOSP_CODE   (+)= A.HOSP_CODE
                           AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                           AND D.HOSP_CODE   (+)= A.HOSP_CODE
                           AND D.FKOCS2003   (+)= A.FKOCS2003
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
                         WHERE A.HOSP_CODE       = :f_hosp_code
                           AND A.JUBSU_DATE      = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.DRG_BUNHO       = :f_drg_bunho
                           AND C.HOSP_CODE    (+)= A.HOSP_CODE
                           AND C.JAERYO_CODE  (+)= A.JAERYO_CODE
                           AND NVL(C.CHKD,'N')   = 'Y'
                           AND D.HOSP_CODE    (+)= A.HOSP_CODE
                           AND D.FKOCS2003    (+)= A.FKOCS2003
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
                         WHERE A.HOSP_CODE     = :f_hosp_code
                           AND A.JUBSU_DATE    = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.DRG_BUNHO     = :f_drg_bunho
                           AND B.HOSP_CODE     = A.HOSP_CODE
                           AND B.JUBSU_DATE    = A.JUBSU_DATE
                           AND B.DRG_BUNHO     = A.DRG_BUNHO
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
                         WHERE A.HOSP_CODE     = :f_hosp_code
                           AND A.JUBSU_DATE    = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.DRG_BUNHO     = :f_drg_bunho
                           AND B.HOSP_CODE   (+)= A.HOSP_CODE
                           AND B.BUNHO       (+)= A.BUNHO
                           AND B.ORDER_REMARK IS NOT NULL
                         ORDER BY 1, 2";

            try
            {
                resTable = Service.ExecuteDataTable(cmdText, bindVars);

                if (TypeCheck.IsNull(resTable) || resTable.Rows.Count == 0)
                {
                    /* fetch된 data가 없을 경우는 바코드를 위해서 */
                    retVal = Service.ExecuteScalar(@"SELECT DISTINCT '*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'
                                                   FROM DRG3010 A
                                                  WHERE A.HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()
                                                    AND A.JUBSU_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                                    AND A.DRG_BUNHO   = :f_drg_bunho", bindVars);
                    if (retVal == null)
                    {
                        XMessageBox.Show(Service.ErrFullMsg + "\n\r" + Resources.XMessageBox4);
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
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
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
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            DataTable resTable = new DataTable();
            DataTable dtResult = new DataTable();

            cmdText = @"SELECT DISTINCT
                               '*' || TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO) || '*'                          BAR_DRG_BUNHO
                              ,'*' || TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO) || TO_CHAR(A.GROUP_SER) || '*'  BAR_RP_BUNHO
                              ,'Rp. ' || TO_CHAR(A.GROUP_SER)                                                                  SER
                              ,A.BUNHO                                                                                         BUNHO
                          FROM DRG3011 A
                         WHERE A.HOSP_CODE    = :f_hosp_code
                           AND A.JUBSU_DATE   = :f_jubsu_date
                           AND A.DRG_BUNHO    = :f_drg_bunho
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

        #region [-- DsvDRG1000Load --]
        /// <summary>
        /// dsvDRG1000Load Service Conversion PC: DRGPRINT WT: C
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns>FKOCS</returns>
        private string DsvDrg1000Load(string jubsuDate, string drgBunho)
        {
            string fkOcs = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            string cmdText = @"SELECT B.FKOCS
                                 FROM DRG1000 B
                                     ,DRG2010 A
                                WHERE A.HOSP_CODE  = :f_hosp_code
                                  AND A.JUBSU_DATE = :f_jubsu_date
                                  AND A.DRG_BUNHO  = :f_drg_bunho
                                  AND B.HOSP_CODE  = A.HOSP_CODE
                                  AND B.FKOCS      = A.FKOCS1003
                               UNION
                               SELECT B.FKOCS
                                 FROM DRG1000 B
                                     ,DRG3010 A
                                WHERE A.HOSP_CODE  = :f_hosp_code
                                  AND A.JUBSU_DATE = :f_jubsu_date 
                                  AND A.DRG_BUNHO  = :f_drg_bunho
                                  AND B.HOSP_CODE  = A.HOSP_CODE 
                                  AND B.FKOCS      = A.FKOCS2003";
            if (!TypeCheck.IsNull(Service.ExecuteScalar(cmdText, bindVars)))
            {
                fkOcs = Service.ExecuteScalar(cmdText, bindVars).ToString();
            }
            return fkOcs;
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
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);

            layJusaLable.Reset();
                        
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
                         WHERE A.HOSP_CODE          = :f_hosp_code
                           AND A.JUBSU_DATE         = :f_jubsu_date
                           AND A.DRG_BUNHO          = :f_drg_bunho
                           AND A.BUNRYU1            = '4'
                           AND NVL(A.DC_YN,'N')     = 'N'
                           AND NVL(A.BANNAB_YN,'N') = 'N'
                           AND B.HOSP_CODE       (+)= A.HOSP_CODE 
                           AND B.JAERYO_CODE     (+)= A.JAERYO_CODE
                           AND C.HOSP_CODE       (+)= A.HOSP_CODE 
                           AND C.BOGYONG_CODE    (+)= A.BOGYONG_CODE
                           AND D.HOSP_CODE          = A.HOSP_CODE 
                           AND D.BUNHO              = A.BUNHO
                           AND E.HOSP_CODE          = A.HOSP_CODE 
                           AND E.JUBSU_DATE         = A.JUBSU_DATE
                           AND E.DRG_BUNHO          = A.DRG_BUNHO
                           AND E.FKOCS2003          = A.FKOCS2003
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
                            o_line = (rowNum+1).ToString();

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

                    //dw_lable.Reset();
                    //dw_lable.FillData(layJusaLable.LayoutTable);

                    //SetPrint(dw_lable, true);

                    //if (dw_lable.RowCount > 0) dw_lable.Print();
                
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
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
                XMessageBox.Show(Resources.XMessageBox5, Resources.caption_name, MessageBoxIcon.Error);
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
                XMessageBox.Show(Resources.XMessageBox6, Resources.caption_name, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region [-- dsvBoryu --]
        /// <summary>
        /// dsvBoryu Service Conversion PC:DRG3010P10, WT:D
        /// </summary>
        /// <param name="fkocs2003"></param>
        /// <param name="reUseYn"></param>
        /// <returns></returns>
        private bool dsvBoryu(string fkocs2003, string reUseYn)
        {
            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            inputList.Add(UserInfo.UserID);
            inputList.Add(fkocs2003);
            inputList.Add(reUseYn);

            cmdText = @"SELECT NVL(B.TOIWON_GOJI_YN,'N') TOIWON_GOJI_YN
                          FROM INP1001 B
                             , OCS2003 A
                         WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                           AND A.PKOCS2003 = '" + fkocs2003 + @"'
                           AND A.FKINP1001 = B.PKINP1001";
            object retVal = Service.ExecuteScalar(cmdText);
            if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
            {
                XMessageBox.Show(Service.ExecuteScalar("SELECT FN_ADM_MSG(909) FROM DUAL").ToString());
                return false;
            }
            else
            {
                cmdText = @"UPDATE DRG3010
                               SET RE_USE_YN = '" + reUseYn + @"'
                             WHERE HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                               AND FKOCS2003 = '" + fkocs2003 + "'";
                if (!Service.ExecuteNonQuery(cmdText))
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

        #region SetPrint
        private string SetPrint(XDataWindow dw_print, bool lable_yn)
        {
            string print_name = IHIS.Framework.PrintHelper.GetDefaultPrinterName();

            if (lable_yn)
            {
                foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    //if (s.IndexOf("Microsoft XPS Document Writer") >= 0)
                    if (s.IndexOf("JUSA_LABEL") >= 0 || s.IndexOf("jusa_label") >= 0)
                    //if (s.IndexOf("SATO") >= 0)
                    {
                        print_name = s;
                    }
                }
            }
            else
            {
                print_name = IHIS.Framework.PrintHelper.GetDefaultPrinterName();
            }

            dw_print.PrintProperties.PrinterName = print_name;

            return print_name;
        }
        #endregion

        private void btnLable_Click(object sender, System.EventArgs e)
        {
            //주사

            if (grdMagamJUSAOrder.CurrentRowNumber < 0) return;
            string jubsu_date = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "jubsu_date");
            string drg_bunho = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "drg_bunho");


            #region 주사라벨

            DsvJusaLabel(jubsu_date, drg_bunho);

            //string origin_print = SetPrint(dw_lable, false);
            //string print_name = SetPrint(dw_lable, true);

            //// lable print set
            //try
            //{
            //    if (print_name != "")
            //        IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name);

            //    // 오다 내역 조회
            //    DsvJusaLabel(jubsu_date, drg_bunho);
            //    // 기본프린터 set
            //}
            //catch
            //{ }
            //finally
            //{
            //    if (origin_print != "")
            //        IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
            //}
            #endregion
        }

        #region [締切ボタンクリック]
        private void btnMagam_Click(object sender, System.EventArgs e)
        {
            if(this.grdPaQuery.RowCount < 1) return;

            if (XMessageBox.Show(Resources.XMessageBox8, Resources.XMessageBox8_caption, MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            else
            {
                // 마감후 미마감환자리스트가 재조회 되기 전에는 처방전출력버튼(btnMagam)을 누르지 못하도록 한다.
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                this.btnMagam.Enabled = false;
                this.grdPaQuery.ReadOnly = true;

                // 締切処理 Main
                this.MagamMain();

                this.btnMagam.Enabled = true;
                this.grdPaQuery.ReadOnly = false;
                Cursor.Current = System.Windows.Forms.Cursors.Arrow;
            }
        }
        #endregion

        #region [締切処理 Main]
        private void MagamMain()
        {
            DataRow[] dtRow = null;
 
            // 薬締切
            dtRow = this.grdPaQuery.LayoutTable.Select("magam_yn =" + "'Y' AND magam_bunryu =" + "'1'");
            if (dtRow.Length > 0)
            {
                this.Magam(dtRow.Length);
            }

            // 注射締切
            dtRow = this.grdPaQuery.LayoutTable.Select("magam_yn =" + "'Y' AND magam_bunryu =" + "'2'");
            if (dtRow.Length > 0)
            {
                this.MagamJusa(dtRow.Length);
            }

            // Status BAR Not Visible
            this.SetVisibleStatusBar(false);

            this.MiMagamQuery();
        }
        #endregion

        #region [薬締切処理]
        private void Magam(int rowCheckCnt)
        {
            //if (!this.dtpJubsuDate.GetDataValue().Equals(this.cycleMagamDate))
            //{
            //    XMessageBox.Show("定期処方締切日付ではありません。", "締切日付確認", MessageBoxIcon.Warning);
            //    return;
            //}

            string magam_ser = "0";

            string magam_gubun = "11";
            int chkRow = 0;

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            this.InitStatusBar(rowCheckCnt);
            this.SetVisibleStatusBar(true);

            for (int i = 0; i < this.grdPaQuery.RowCount; i++)
            {
                if (grdPaQuery.GetItemString(i, "magam_bunryu")=="2")
                {
                    continue;
                }
                if (grdPaQuery.GetItemString(i, "magam_yn") == "Y")
                {
                    if (grdPaQuery.GetItemString(i, "append_yn") == "N")
                    {
                        chkRow++;

                        this.SetStatusBar(chkRow);
                        this.grdPaQuery.SetFocusToItem(i, 1);


                        #region [PR_DRG_LOAD_BONGTU_SER]
                        if (magam_ser == "0")  
                        {
                            inputList.Clear();
                            outputList.Clear();

                            inputList.Add(this.grdPaQuery.GetItemString(i, "jubsu_date"));
                            inputList.Add(magam_gubun);
                            inputList.Add("%");
                            inputList.Add("PA");
                            inputList.Add(this.cbxActor.GetDataValue());
                            if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))
                            {
                                magam_ser = outputList[0].ToString();
                            }
                        }
                        #endregion [END PR_DRG_LOAD_BONGTU_SER]


                        #region [PR_DRG_INP_MAGAM_PROC]
                        inputList.Clear();
                        outputList.Clear();

                        inputList.Add(EnvironInfo.CurrSystemID);
                        inputList.Add(this.grdPaQuery.GetItemString(i, "jubsu_date"));
                        inputList.Add(this.grdPaQuery.GetItemString(i, "order_date"));
                        inputList.Add(this.grdPaQuery.GetItemString(i, "hope_date"));
                        inputList.Add(magam_gubun);
                        inputList.Add(magam_ser);
                        inputList.Add(this.grdPaQuery.GetItemString(i, "bunho"));
                        inputList.Add(this.grdPaQuery.GetItemString(i, "resident"));
                        inputList.Add(this.cbxActor.GetDataValue());

                        if (Service.ExecuteProcedure("PR_DRG_INP_MAGAM_PROC", inputList, outputList))
                        {
                            if (outputList[0].ToString() != "0")
                            {
                                string drg_bunho = outputList[0].ToString();

                                //처방전 출력
                                this.DrgPrint(this.grdPaQuery.GetItemString(i, "jubsu_date"), drg_bunho, magam_gubun, "");

                                // ATC装置I/Fデータ転送Process
                                if (this.cbxATCYN.Checked && (magam_gubun == "11" || magam_gubun == "21"))
                                {
                                    bool value = this.procAtcInterface(this.grdPaQuery.GetItemString(i, "jubsu_date"), drg_bunho, this.grdPaQuery.GetItemString(i, "bunho"), this.grdPaQuery.GetItemString(i, "fkinp1001"));

                                    if (value == false)
                                    {
                                        throw new Exception();
                                    }
                                }
                            }
                        }
                        else
                        {
                            XMessageBox.Show(Service.ErrFullMsg);
                        }
                        #endregion [END PR_DRG_INP_MAGAM_PROC]
                    }

                    #region [OLD VERSION]
                    //if (grdPaQuery.GetItemString(i, "append_yn") == "N")
                    //{
                    //    chkRow++;

                    //    this.SetStatusBar(chkRow);
                    //    this.grdPaQuery.SetFocusToItem(i, 1);

                    //    magam_gubun = "11"; // 정규
                    //    if (magam_ser_11 == "0")
                    //    {
                    //        /* dsvLoadMagamSer PC: DRG3010p10 WT: 3 */
                    //        inputList.Clear();
                    //        inputList.Add(this.grdPaQuery.GetItemString(i, "jubsu_date"));
                    //        inputList.Add(magam_gubun);
                    //        inputList.Add("%");
                    //        inputList.Add("PA");
                    //        inputList.Add(this.cbxActor.GetDataValue());
                    //        if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))
                    //        {
                    //            magam_ser_11 = outputList[0].ToString();
                    //            magam_ser = magam_ser_11;
                    //        }
                    //    }
                    //}

                    ///* dsvMagam */
                    //inputList.Clear();
                    //outputList.Clear();
                    //inputList.Add(this.grdPaQuery.GetItemString(i, "jubsu_date"));
                    //inputList.Add(this.grdPaQuery.GetItemString(i, "hope_date"));
                    //inputList.Add(this.grdPaQuery.GetItemString(i, "hope_time"));
                    //inputList.Add(magam_gubun);
                    //inputList.Add(magam_ser);
                    //inputList.Add(this.grdPaQuery.GetItemString(i, "bunho"));
                    //inputList.Add(this.grdPaQuery.GetItemString(i, "ho_dong"));
                    //inputList.Add(this.grdPaQuery.GetItemString(i, "gwa"));
                    //inputList.Add(this.grdPaQuery.GetItemString(i, "resident"));
                    //inputList.Add(this.cbxActor.GetDataValue());

                    //// sleep
                    //System.Threading.Thread.Sleep(1);

                    ////마감
                    //if (Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_INP_NEW", inputList, outputList))
                    //{
                    //    if (outputList[0].ToString() != "0")
                    //    {
                    //        string drg_bunho = outputList[0].ToString();

                    //        //처방전 출력
                    //        this.DrgPrint(this.grdPaQuery.GetItemString(i, "jubsu_date"), outputList[0].ToString(), magam_gubun, "");

                    //        // ATC装置I/Fデータ転送Process
                    //        if (this.cbxATCYN.Checked && (magam_gubun == "11" || magam_gubun == "21"))
                    //        {
                    //            bool value = this.procAtcInterface(this.grdPaQuery.GetItemString(i, "jubsu_date"), drg_bunho, this.grdPaQuery.GetItemString(i, "bunho"), this.grdPaQuery.GetItemString(i, "fkinp1001"));

                    //            if (value == false)
                    //            {
                    //                throw new Exception();
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    XMessageBox.Show(Service.ErrFullMsg);
                    //    //XMessageBox.Show(outputList[1].ToString(), 2);
                    //}
                    #endregion [OLD VERSION]
                }
            }

            // 定期処方締切処理
            if (chkRow != 0)
            {
                inputList.Clear();
                inputList.Add(this.cbxActor.GetDataValue());
                inputList.Add(EnvironInfo.HospCode);
                inputList.Add(this.cbxBuseo.GetDataValue());
                inputList.Add(this.cycleMagamDate);
                inputList.Add("Y");

                if (Service.ExecuteProcedure("PR_DRG_INP_MAGAM", inputList, outputList))
                {
                    if (TypeCheck.IsNull(outputList[0].ToString()) || outputList[0].ToString() != "1")
                    {
                        XMessageBox.Show(Resources.XMessageBox9, Resources.XMessageBox9_caption, MessageBoxIcon.Error);
                    }
                }
            }

            // 미마감 환자 정보 조회
            //MiMagamQuery();
        }
        #endregion

        #region [注射締切処理]
        private void MagamJusa(int rowCheckCnt)
        {
            // 정규: 12,  임시 22
            string magam_gubun;
            string magam_ser = "0";
            // 마지막 마감체크 row 값
            int row, lastRow, chkRow;

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            DataTable resTable = new DataTable();

            string jubsuDate = this.dtpJubsuDate.GetDataValue();

            #region 정규마감
            // 정규: 12,  임시 22
            magam_gubun = "12";
            // 마지막 마감체크 row 값
            row = 0;
            lastRow = 0;
            chkRow = 0;            

            row = grdPaQuery.RowCount;

            for (int a = 0; a < row; a++)
            {
                if ((grdPaQuery.GetItemString(a, "magam_yn") == "Y") &&
                    (grdPaQuery.GetItemString(a, "append_yn") == "N") &&
                    (grdPaQuery.GetItemString(a, "magam_bunryu") == "2"))
                {
                    lastRow++;
                }
            }

            this.InitStatusBar(rowCheckCnt);
            this.SetVisibleStatusBar(true);

            /* dsvMagamJusa PC:DRG3010P10, WT:C */
            for (int i = 0; i < row; i++)
            {
                if ((grdPaQuery.GetItemString(i, "magam_yn") == "Y") && (grdPaQuery.GetItemString(i, "append_yn") == "N"))
                {
                    chkRow++;

                    this.SetStatusBar(chkRow);
                    this.grdPaQuery.SetFocusToItem(i, 1);

                    #region [PR_DRG_LOAD_BONGTU_SER]
                    if (magam_ser == "0")
                    {
                        inputList.Clear();
                        outputList.Clear();

                        inputList.Add(this.grdPaQuery.GetItemString(i, "jubsu_date"));
                        inputList.Add(magam_gubun);
                        inputList.Add("%");
                        inputList.Add("PA");
                        inputList.Add(this.cbxActor.GetDataValue());
                        if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))
                        {
                            magam_ser = outputList[0].ToString();
                        }
                    }
                    #endregion [END PR_DRG_LOAD_BONGTU_SER]

                    #region [PR_DRG_INP_MAGAM_PROC]
                    inputList.Clear();
                    outputList.Clear();

                    inputList.Add(EnvironInfo.CurrSystemID);
                    inputList.Add(this.grdPaQuery.GetItemString(i, "jubsu_date"));
                    inputList.Add(this.grdPaQuery.GetItemString(i, "order_date"));
                    inputList.Add(this.grdPaQuery.GetItemString(i, "hope_date"));
                    inputList.Add(magam_gubun);
                    inputList.Add(magam_ser);
                    inputList.Add(this.grdPaQuery.GetItemString(i, "bunho"));
                    inputList.Add(this.grdPaQuery.GetItemString(i, "resident"));
                    inputList.Add(this.cbxActor.GetDataValue());

                    if (Service.ExecuteProcedure("PR_DRG_INP_MAGAM_PROC", inputList, outputList))
                    {
                        string drg_bunho = outputList[0].ToString();

                        //처방전
                        DrgPrint(jubsuDate, drg_bunho, magam_gubun, "");

                        if (this.cbxJusaLabelYN.Checked)
                        {
                            //주사라벨
                            DsvJusaLabel(jubsuDate, drg_bunho);
                        }

                        #region [OLD VERSION] 
                        //                        // 마지막일때 처방전을 출력한다.
//                        if (chkRow == lastRow)
//                        {
//                            cmdText = @"SELECT NVL(MIN(B.DRG_BUNHO),0) MIN_DRG_BUNHO
//                                             , NVL(MAX(B.DRG_BUNHO),0) MAX_DRG_BUNHO             
//                                          FROM DRG3020 A,
//                                               DRG3010 B
//                                         WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
//                                           AND A.MAGAM_DATE    = '" + jubsuDate + @"'
//                                           AND A.MAGAM_SER     = '" + magam_ser + @"'
//                                           AND A.MAGAM_GUBUN   = '" + magam_gubun + @"'
//                                           AND B.DRG_BUNHO     > 8000
//                                           AND B.HOSP_CODE     = A.HOSP_CODE
//                                           AND B.JUBSU_DATE    = A.MAGAM_DATE
//                                           AND B.MAGAM_GUBUN   = A.MAGAM_GUBUN
//                                           AND B.MAGAM_SER     = A.MAGAM_SER";
//                            resTable = Service.ExecuteDataTable(cmdText);

//                            int min_drg_bunho = int.Parse(resTable.Rows[0]["min_drg_bunho"].ToString());
//                            int max_drg_bunho = int.Parse(resTable.Rows[0]["max_drg_bunho"].ToString()) + 1;

//                            for (int c = min_drg_bunho; c < max_drg_bunho; c++)
//                            {
//                                //처방전 출력
//                                if (c > 0)
//                                {
//                                    //처방전
//                                    DrgPrint(jubsuDate, c.ToString(), magam_gubun, "");
//                                    //주사라벨
//                                    DsvJusaLabel(jubsuDate, c.ToString());
//                                }
//                            }
                        //                        }
                        #endregion [OLD VERSION]
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg, 2);
                    }
                    #endregion [END PR_DRG_INP_MAGAM_PROC]
                }
            }
            #endregion

            // 定期処方締切処理
            if (chkRow != 0)
            {
                inputList.Clear();
                inputList.Add(this.cbxActor.GetDataValue());
                inputList.Add(EnvironInfo.HospCode);
                inputList.Add(this.cbxBuseo.GetDataValue());
                inputList.Add(this.cycleMagamDate);
                inputList.Add("Y");

                if (Service.ExecuteProcedure("PR_DRG_INP_MAGAM", inputList, outputList))
                {
                    if (TypeCheck.IsNull(outputList[0].ToString()) || outputList[0].ToString() != "1")
                    {
                        XMessageBox.Show(Resources.XMessageBox9, Resources.XMessageBox9_caption, MessageBoxIcon.Error);
                    }
                }
            }

            #region 추가마감
//            // 정규: 12,  임시 22
//            magam_gubun = "22";
//            magam_ser = "0";
//            // 마지막 마감체크 row 값
//            row = 0;
//            lastRow = 0;
//            chkRow = 0;

//            /* dsvLoadMagamSer */
//            inputList.Clear();
//            outputList.Clear();
//            inputList.Add(jubsu_date);
//            inputList.Add(magam_gubun);  // 주사약 마감구분은 임시마감으로 셋팅
//            inputList.Add("%");
//            inputList.Add("PA");

//            if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))
//            {
//                magam_ser = outputList[0].ToString();
//            }

//            row = grdPaQuery.RowCount;

//            for (int a = 0; a < row; a++)
//                if ((grdPaQuery.GetItemString(a, "magam_yn") == "Y") &&
//                    (grdPaQuery.GetItemString(a, "append_yn") == "Y") &&
//                    (grdPaQuery.GetItemString(a, "magam_bunryu") == "2"))
//                    lastRow++;

//            for (int i = 0; i < row; i++)
//            {
//                if (grdPaQuery.GetItemString(i, "magam_bunryu") == "1")
//                {
//                    continue;
//                }
//                if ((grdPaQuery.GetItemString(i, "magam_yn") == "Y") && (grdPaQuery.GetItemString(i, "append_yn") == "Y"))
//                {
//                    chkRow++;
//                    inputList.Clear();
//                    outputList.Clear();
//                    inputList.Add(jubsu_date);
//                    inputList.Add(grdPaQuery.GetItemString(i, "hope_date"));
//                    inputList.Add(grdPaQuery.GetItemString(i, "hope_time"));
//                    inputList.Add(magam_gubun);
//                    inputList.Add(magam_ser);
//                    inputList.Add("PA");
//                    inputList.Add(grdPaQuery.GetItemString(i, "bunho"));
//                    inputList.Add(grdPaQuery.GetItemString(i, "ho_dong"));
//                    inputList.Add(grdPaQuery.GetItemString(i, "resident"));
//                    inputList.Add(UserInfo.UserID);

//                    //마감
//                    if (Service.ExecuteProcedure("PR_DRG_MAGAM_INJ_NEW", inputList, outputList))
//                    {
//                        // 마지막일때 처방전을 출력한다.
//                        if (chkRow == lastRow)
//                        {
//                            cmdText = @"SELECT NVL(MIN(B.DRG_BUNHO),0) MIN_DRG_BUNHO
//                                             , NVL(MAX(B.DRG_BUNHO),0) MAX_DRG_BUNHO             
//                                          FROM DRG3020 A,
//                                               DRG3010 B
//                                         WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
//                                           AND A.MAGAM_DATE    = '" + jubsu_date + @"'
//                                           AND A.MAGAM_SER     = '" + magam_ser + @"'
//                                           AND A.MAGAM_GUBUN   = '" + magam_gubun + @"'
//                                           AND B.DRG_BUNHO     > 8000
//                                           AND B.HOSP_CODE     = A.HOSP_CODE
//                                           AND B.JUBSU_DATE    = A.MAGAM_DATE
//                                           AND B.MAGAM_GUBUN   = A.MAGAM_GUBUN
//                                           AND B.MAGAM_SER     = A.MAGAM_SER";
//                            resTable = Service.ExecuteDataTable(cmdText);

//                            int min_drg_bunho = int.Parse(resTable.Rows[0]["min_drg_bunho"].ToString());
//                            int max_drg_bunho = int.Parse(resTable.Rows[0]["max_drg_bunho"].ToString()) + 1;

//                            for (int c = min_drg_bunho; c < max_drg_bunho; c++)
//                            {
//                                //처방전 출력
//                                if (c > 0)
//                                {
//                                    //처방전
//                                    DrgPrint(jubsu_date, c.ToString(), magam_gubun, "");
//                                    //주사라벨
//                                    DsvJusaLabel(jubsu_date, c.ToString());
//                                }
//                            }
//                        }

//                    }
//                    else
//                    {
//                        XMessageBox.Show(Service.ErrFullMsg, 2);
//                    }
//                }
//            }

            #endregion

            // 미마감 환자 정보 조회
            //MiMagamQuery();
        }
        #endregion

        //private void grdBoryuPa_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        //{
        //    /* dsvBoryOrder PC:DRG3010P10, WT:9 */
        //    string magam_bunryu = "1", magam_gubun = "N";

        //    magam_gubun = cboMagam.GetDataValue();

        //    //내복, 외용
        //    //if (rbxBunryu1.Checked)
        //    if (grdBoryuPa.GetItemString(e.CurrentRow, "magam_bunryu")=="1")
        //    {
        //        magam_bunryu = "1";
        //        grdBoryuNeabok.Visible = true;
        //        grdBoryuJusa.Visible = false;

        //        grdBoryuNeabok.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
        //        grdBoryuNeabok.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
        //        grdBoryuNeabok.SetBindVarValue("f_bunho", grdBoryuPa.GetItemString(e.CurrentRow,"bunho"));
        //        grdBoryuNeabok.SetBindVarValue("f_doctor", grdBoryuPa.GetItemString(e.CurrentRow,"doctor"));
        //        grdBoryuNeabok.SetBindVarValue("f_magam_bunryu", magam_bunryu);
        //        grdBoryuNeabok.SetBindVarValue("f_magam_gubun", magam_gubun);
        //        if (!grdBoryuNeabok.QueryLayout(false))
        //        {
        //            XMessageBox.Show(Service.ErrFullMsg);
        //        }
        //    }
        //    else 
        //    //주사
        //    //if (rbxBunryu2.Checked)
        //    {
        //        magam_bunryu = "2";
        //        grdBoryuJusa.Visible = true;
        //        grdBoryuNeabok.Visible = false;

        //        grdBoryuJusa.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
        //        grdBoryuJusa.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
        //        grdBoryuJusa.SetBindVarValue("f_bunho", grdBoryuPa.GetItemString(e.CurrentRow, "bunho"));
        //        grdBoryuJusa.SetBindVarValue("f_doctor", grdBoryuPa.GetItemString(e.CurrentRow, "doctor"));
        //        grdBoryuJusa.SetBindVarValue("f_magam_bunryu", magam_bunryu);
        //        grdBoryuJusa.SetBindVarValue("f_magam_gubun", magam_gubun);
        //        if (!grdBoryuJusa.QueryLayout(false))
        //        {
        //            XMessageBox.Show(Service.ErrFullMsg);
        //        }
        //    }
        //}

        //private void grdBoryuPa_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
        //{
        //    if (XMessageBox.Show("保留取消実行を続きますか。", "保留", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        //if (rbxBunryu1.Checked)
        //        if (grdBoryuPa.GetItemString(grdBoryuPa.CurrentRowNumber, "magam_bunryu") == "1")
        //        {
        //            try
        //            {
        //                Service.BeginTransaction();
        //                for (int i = 0; i < grdBoryuNeabok.RowCount; i++)
        //                {
        //                    grdBoryuNeabok.SetItemValue(i, "re_use_yn", "N");
        //                    if (!dsvBoryu(grdBoryuNeabok.GetItemString(i, "fkocs2003"), grdBoryuNeabok.GetItemString(i, "re_use_yn")))
        //                    {
        //                        throw new Exception(Service.ErrFullMsg);
        //                    }
        //                }
        //            }
        //            catch (Exception xe)
        //            {
        //                Service.RollbackTransaction();
        //                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            try
        //            {
        //                Service.BeginTransaction();
        //                for (int i = 0; i < grdBoryuJusa.RowCount; i++)
        //                {
        //                    grdBoryuJusa.SetItemValue(i, "re_use_yn", "N");
        //                    if (!dsvBoryu(grdBoryuJusa.GetItemString(i, "fkocs2003"), grdBoryuJusa.GetItemString(i, "re_use_yn")))
        //                    {
        //                        throw new Exception(Service.ErrFullMsg);
        //                    }
        //                }
        //            }
        //            catch (Exception xe)
        //            {
        //                Service.RollbackTransaction();
        //                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
        //                return;
        //            }
        //        }

        //        Service.CommitTransaction();
        //        BoryuQuery();
        //    }
        //}

        private void xButton2_Click(object sender, System.EventArgs e)
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            #region 보류
            if (XMessageBox.Show("保留実行を続きますか。", Resources.DRG3010P10_btnBoryu_caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string cmdText = string.Empty;
                BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVars.Add("f_jubsu_date", grdDrgBunhoList.GetItemString(grdDrgBunhoList.CurrentRowNumber, "jubsu_date"));
                bindVars.Add("f_drg_bunho", grdDrgBunhoList.GetItemString(grdDrgBunhoList.CurrentRowNumber, "drg_bunho"));
                object fkocs2003;

                cmdText = @"SELECT FKOCS2003
                              FROM DRG3010
                             WHERE HOSP_CODE  = :f_hosp_code
                               AND JUBSU_DATE = :f_jubsu_date
                               AND DRG_BUNHO  = :f_drg_bunho";
                fkocs2003 = Service.ExecuteScalar(cmdText, bindVars);

                if (!TypeCheck.IsNull(fkocs2003))
                {
                    bindVars.Add("f_fkocs2003", fkocs2003.ToString());

                    inputList.Add(UserInfo.UserID);
                    inputList.Add(fkocs2003.ToString());
                    inputList.Add("Y");

                    cmdText = @"SELECT NVL(B.TOIWON_GOJI_YN,'N') TOIWON_GOJI_YN
                                  FROM INP1001 B
                                     , OCS2003 A
                                 WHERE HOSP_CODE  = :f_hosp_code
                                   AND A.PKOCS2003 = :f_fkocs2003
                                   AND A.FKINP1001 = B.PKINP1001";
                    if (Service.ExecuteScalar(cmdText, bindVars).ToString().Equals("Y"))
                    {
                        XMessageBox.Show(Service.ExecuteScalar("SELECT FN_ADM_MSG(999) FROM DUAL").ToString());
                        return;
                    }
                    else
                    {
                        try
                        {
                            Service.BeginTransaction();
                            cmdText = @"UPDATE DRG3010
                                           SET RE_USE_YN  = 'Y'
                                         WHERE HOSP_CODE  = :f_hosp_code
                                           AND FKOCS2003  = :f_fkocs2003";
                            if (!Service.ExecuteNonQuery(cmdText, bindVars))
                            {
                                throw new Exception(Service.ErrFullMsg);
                            }

                            if (!Service.ExecuteProcedure("PR_DRG_MAKE_DRG3060", inputList, outputList))
                            {
                                throw new Exception(outputList[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Service.RollbackTransaction();
							//https://sofiamedix.atlassian.net/browse/MED-10610
                            //XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
                            return;
                        }
                        Service.CommitTransaction();
                    }
                }
            }
            else
                return;
            #endregion

            #region 마감취소
            string drg_bunho = "", jubsu_date = "";

            string magam_gubun = "";
            magam_gubun = grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "magam_gubun");

            //내복, 외용
            if ((magam_gubun == "11") || (magam_gubun == "21"))
            {
                if (grdMagamOrder.CurrentRowNumber < 0) return;

                jubsu_date = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "drg_bunho");
            }
            //주사
            if ((magam_gubun == "12") || (magam_gubun == "22"))
            {
                if (grdMagamJUSAOrder.CurrentRowNumber < 0) return;
                jubsu_date = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "drg_bunho");
            }

            inputList.Clear();
            inputList.Add(jubsu_date);
            inputList.Add(drg_bunho);
            inputList.Add(UserInfo.UserID);
            if (!Service.ExecuteProcedure("PR_DRG_INP_DRG_BUNHO_CANCEL", inputList, outputList))
            {
                XMessageBox.Show(Service.ErrFullMsg, "1");
            }

            MagamQuery();

            //BoryuQuery();
            #endregion
        }

        private void grdDrgBunhoList_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            // 出庫日付の表示
            if ((grdDrgBunhoList.GetItemString(e.RowNumber, "mix_date") != "") &&
                (grdDrgBunhoList.GetItemString(e.RowNumber, "magam_bunryu") == "2"))
                e.BackColor = Color.Khaki;
        }

        private void btnHopeTimeMake_Click(object sender, System.EventArgs e)
        {
            if (grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho") == "")
            {
                MessageBox.Show(Resources.btnCommentForm_Click_msg);
            }

            //외래과 접수 선택
            FrmHopeTime dlg = new FrmHopeTime(grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho"));
            dlg.ShowDialog();
        }

        //private void dsvBoRyu_ServiceEnd(object sender, IHIS.Framework.ServiceEndArgs e)
        //{
        //    if (grdBoryuPa.RowCount > 0)
        //    {
        //        this.tabPage4.TitleTextColor = System.Drawing.Color.Red;
        //    }
        //    else
        //        this.tabPage4.TitleTextColor = System.Drawing.Color.Black;
        //}

        //private void button2_Click(object sender, System.EventArgs e)
        //{
        //    if (grdBoryuPa.RowCount > 0)
        //    {
        //        this.tabPage4.TitleTextColor = System.Drawing.Color.Red;
        //    }
        //    else
        //        this.tabPage4.TitleTextColor = System.Drawing.Color.Black;
        //}

        #region 정규마감이 진행중일 때는 체크를 하지 못하도록 막는다.
        private void grdPaQuery_Click(object sender, System.EventArgs e)
        {
            if (this.grdPaQuery.ReadOnly == true)
            {
                string mbxMsg = "";

                mbxMsg = NetInfo.Language == LangMode.Jr ? "処方箋出力中です。" :
                    "처방전 출력중입니다.";

                XMessageBox.Show(mbxMsg);
            }
        }
        #endregion

        #region JobItem Class
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

        #region OnPopMenuClick
        private void OnPopMenuClick(object sender, EventArgs e)
        {
            //Tag에 저장된 JobItem Get
            JobItem item = (JobItem)((IHIS.X.Magic.Menus.MenuCommand)sender).Tag;

            CommonItemCollection openParams = new CommonItemCollection();

            switch (item.Code.ToString())
            {
                case "0": //"병동환자관리"
                    openParams.Add("bunho", selectBunho);
                    XScreen.OpenScreenWithParam(this, "NURI", "NUR1001U00", ScreenOpenStyle.ResponseSizable, openParams);
                    break;
                case "1": //"오더정보조회"
                    openParams.Add("bunho", selectBunho);
                    XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q05", ScreenOpenStyle.PopUpSizable, openParams);
                    break;
                case "2": //"치료계획관리"
                    openParams.Add("bunho", selectBunho);
                    openParams.Add("fkinp1001", selectFkinp1001);
                    XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.ResponseSizable, openParams);
                    break;
                case "3": //"병동이동이력조회"
                    openParams.Add("bunho", selectBunho);
                    XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R07", ScreenOpenStyle.ResponseSizable, openParams);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region MenuClick    popup 메뉴 이벤트
        private void MenuClick(XEditGrid currentGrd, int X, int Y)
        {
            if (currentGrd.CurrentRowNumber < 0)
            {
                selectBunho = null;
                selectFkinp1001 = null;
            }
            else
            {
                selectBunho = currentGrd.GetItemString(currentGrd.CurrentRowNumber, "bunho");
                selectFkinp1001 = currentGrd.GetItemString(currentGrd.CurrentRowNumber, "fkinp1001");
            }

            Y = 70 + Y;
            if (currentGrd.Equals(grdDrgBunhoList))
                X = 260 + X;
            else
                X = 20 + X;

            // 메뉴 초기화
            popMenu.MenuCommands.Clear();

            //PopupMenu 메뉴구성 //tag에 code저장
            IHIS.X.Magic.Menus.MenuCommand menuCmd = null;

            foreach (JobItem item in jobCodeList)
            {
                //PopupMenu구성, Tag에 JobItem 보관
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand(item.CodeName, (Image)imageListMenu.Images[item.Code], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = item;

                popMenu.MenuCommands.Add(menuCmd);
            }

            popMenu.TrackPopup(this.PointToScreen(new Point(X, Y)));
        }
        #endregion

        #region 마우스 오른버튼 클릭시 popup menu call
        private void grdPaQuery_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if ((e.Button == MouseButtons.Right))
            //    MenuClick(grdPaQuery, e.X, e.Y);
        }
        private void grdDrgBunhoList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if ((e.Button == MouseButtons.Right))
            //    MenuClick(grdDrgBunhoList, e.X, e.Y);
        }
        //private void grdBoryuPa_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if ((e.Button == MouseButtons.Right))
        //        MenuClick(grdBoryuPa, e.X, e.Y);
        //}
        #endregion

        #region 퇴원예고/퇴원고지 이미지 표지
        private void imageDisplay(XEditGrid arGrd)
        {
            for (int i = 0; i <= arGrd.RowCount; i++)
            {
                /* 퇴원예고/퇴원고지 이미지 표시 */
                if (arGrd.GetItemString(i, "toiwon_yn") == "Y")
                {
                    arGrd[i + arGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[9];
                    arGrd[i + arGrd.HeaderHeights.Count, 0].ToolTipText = "退院予告";
                }
            }
        }
        #endregion

        #region 각 그리드/레이아웃 바인드 변수 설정
        private void grdPaQuery_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPaQuery.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPaQuery.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdPaQuery.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            //this.grdPaQuery.SetBindVarValue("f_hope_date", cycleOrdDate);
            this.grdPaQuery.SetBindVarValue("f_ho_dong", cbxBuseo.GetDataValue());
            this.grdPaQuery.SetBindVarValue("f_bunho", paBox.BunHo);
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
        }

        #region 그리드 이미지 셋팅
        private void SetGrdHeaderImage(XEditGrid grid)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                // 払出済환자.
                if (grid.Name == "grdPaQuery" && grid.GetItemString(i, "act_buseo") == "PA")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[17];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "払出済";
                }
            }
        }
        #endregion

        private void grdMagamPaQuery_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMagamPaQuery.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdMagamPaQuery.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdMagamPaQuery.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.grdMagamPaQuery.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
            this.grdMagamPaQuery.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        //private void grdBoryuPa_QueryStarting(object sender, CancelEventArgs e)
        //{
        //    grdBoryuPa.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
        //    grdBoryuPa.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
        //    grdBoryuPa.SetBindVarValue("f_ho_dong", cbxBuseo.GetDataValue());
        //    grdBoryuPa.SetBindVarValue("f_bunho", paBox.BunHo);
        //}

        private void grdMiMagamOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            //if (rbxBunryu1.Checked)
            if (grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "magam_bunryu")=="1")
            {
                this.grdMiMagamOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdMiMagamOrder.SetBindVarValue("f_order_date", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "order_date"));
                this.grdMiMagamOrder.SetBindVarValue("f_hope_date", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "hope_date"));
                //this.grdMiMagamOrder.SetBindVarValue("f_hope_time", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "hope_time"));
                this.grdMiMagamOrder.SetBindVarValue("f_bunho", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho"));
                this.grdMiMagamOrder.SetBindVarValue("f_ho_dong", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "ho_dong"));
                this.grdMiMagamOrder.SetBindVarValue("f_doctor", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "resident"));
            }
            else
            {
                this.grdMiMagamJUSAOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdMiMagamJUSAOrder.SetBindVarValue("f_order_date", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "order_date"));
                this.grdMiMagamJUSAOrder.SetBindVarValue("f_hope_date", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "hope_date"));
                //this.grdMiMagamJUSAOrder.SetBindVarValue("f_hope_time", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "hope_time"));
                this.grdMiMagamJUSAOrder.SetBindVarValue("f_bunho", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho"));
                this.grdMiMagamJUSAOrder.SetBindVarValue("f_ho_dong", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "ho_dong"));
                this.grdMiMagamJUSAOrder.SetBindVarValue("f_doctor", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "resident"));
            }
        }

        private void grdMagamOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            //if (rbxBunryu1.Checked)
            string magam_bunryu = this.grdMagamPaQuery.GetItemString(this.grdMagamPaQuery.CurrentRowNumber, "magam_bunryu");

            if (magam_bunryu == "1")
            {
                grdMagamOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                grdMagamOrder.SetBindVarValue("f_jubsu_date", grdDrgBunhoList.GetItemString(grdDrgBunhoList.CurrentRowNumber, "jubsu_date"));
                grdMagamOrder.SetBindVarValue("f_drg_bunho", grdDrgBunhoList.GetItemString(grdDrgBunhoList.CurrentRowNumber, "drg_bunho"));
            }
            else
            {
                grdMagamJUSAOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                grdMagamJUSAOrder.SetBindVarValue("f_jubsu_date", grdDrgBunhoList.GetItemString(grdDrgBunhoList.CurrentRowNumber, "jubsu_date"));
                grdMagamJUSAOrder.SetBindVarValue("f_drg_bunho", grdDrgBunhoList.GetItemString(grdDrgBunhoList.CurrentRowNumber, "drg_bunho"));
            }
        }

        private void grdDrgBunhoList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDrgBunhoList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDrgBunhoList.SetBindVarValue("f_magam_date", this.grdMagamPaQuery.GetItemString(this.grdMagamPaQuery.CurrentRowNumber, "magam_date"));
            this.grdDrgBunhoList.SetBindVarValue("f_magam_ser", this.grdMagamPaQuery.GetItemString(this.grdMagamPaQuery.CurrentRowNumber, "magam_ser"));
            this.grdDrgBunhoList.SetBindVarValue("f_magam_gubun", this.grdMagamPaQuery.GetItemString(this.grdMagamPaQuery.CurrentRowNumber, "magam_gubun"));
            this.grdDrgBunhoList.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
        }
        #endregion

        

        #region layAntiData QueryEnd Event
        // 추가컬럼 값입력
        private void layAntiData_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess == false) return;

            string o_fkocs = string.Empty;
            string o_in_out_gubun = string.Empty;
            string o_order_date = string.Empty;
            string o_bunho = string.Empty;
            string o_gwa = string.Empty;
            string o_doctor = string.Empty;
            string o_ho_dong = string.Empty;
            string o_ipwon_date = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_gwa_name = string.Empty;
            string o_doctor_name = string.Empty;

            string cmdText = @"SELECT B.PKOCS1003                                           PKOCS
                                     ,'O'                                                   IN_OUT_GUBUN
                                     ,B.NAEWON_DATE                                         ORDER_DATE
                                     ,B.BUNHO                                               BUNHO
                                     ,B.GWA                                                 GWA
                                     ,B.DOCTOR                                              DOCTOR
                                     ,NULL                                                  HO_DONG
                                     ,NULL                                                  IPWON_DATE
                                     ,TRUNC(SYSDATE)                                        JUBSU_DATE
                                     ,FN_BAS_LOAD_GWA_NAME(B.GWA, B.NAEWON_DATE)            GWA_NAME
                                     ,FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, B.NAEWON_DATE)      DOCTOR_NAME
                                 FROM OCS1003 B
                                     ,DRG1000 A
                                WHERE A.HOSP_CODE    = :f_hosp_code
                                  AND A.FKOCS        = :f_fkocs
                                  AND A.IN_OUT_GUBUN = 'O'
                                  AND B.HOSP_CODE    = A.HOSP_CODE
                                  AND B.PKOCS1003    = A.FKOCS
                               UNION
                               SELECT B.PKOCS2003                                           PKOCS
                                     ,'I'                                                   IN_OUT_GUBUN
                                     ,B.ORDER_DATE                                          ORDER_DATE
                                     ,B.BUNHO                                               BUNHO
                                     ,B.INPUT_GWA                                           GWA
                                     ,B.INPUT_DOCTOR                                        DOCTOR
                                     ,C.HO_DONG1                                            HO_DONG
                                     ,C.IPWON_DATE                                          IPWON_DATE
                                     ,TRUNC(SYSDATE)                                        JUBSU_DATE
                                     ,FN_BAS_LOAD_GWA_NAME(B.INPUT_GWA, B.ORDER_DATE)       GWA_NAME
                                     ,FN_BAS_LOAD_DOCTOR_NAME(B.INPUT_DOCTOR, B.ORDER_DATE) DOCTOR_NAME
                                 FROM VW_OCS_INP1001_01 C
                                     ,OCS2003 B
                                     ,DRG1000 A
                                WHERE A.HOSP_CODE    = :f_hosp_code
                                  AND A.FKOCS        = :f_fkocs
                                  AND A.IN_OUT_GUBUN = 'I'
                                  AND B.HOSP_CODE    = A.HOSP_CODE
                                  AND B.PKOCS2003    = A.FKOCS
                                  AND C.HOSP_CODE    = A.HOSP_CODE
                                  AND C.PKINP1001    = B.FKINP1001";
            BindVarCollection bindVars = new BindVarCollection();
            DataTable resTable = new DataTable();
            for (int i = 0; i < layAntiData.RowCount; i++)
            {
                bindVars.Clear();
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVars.Add("f_fkocs", layAntiData.GetItemString(i, "fkocs"));

                resTable = Service.ExecuteDataTable(cmdText, bindVars);

                if (resTable.Rows.Count > 0)
                {
                    layAntiData.SetItemValue(i, "fkocs", resTable.Rows[i]["pkocs"].ToString());
                    layAntiData.SetItemValue(i, "in_out_gubun", resTable.Rows[i]["in_out_gubun"].ToString());
                    layAntiData.SetItemValue(i, "order_date", resTable.Rows[i]["dates"].ToString());
                    layAntiData.SetItemValue(i, "bunho", resTable.Rows[i]["bunho"].ToString());
                    layAntiData.SetItemValue(i, "gwa", resTable.Rows[i]["gwa"].ToString());
                    layAntiData.SetItemValue(i, "doctor", resTable.Rows[i]["doctor"].ToString());
                    layAntiData.SetItemValue(i, "ho_dong", resTable.Rows[i]["ho_dong"].ToString());
                    layAntiData.SetItemValue(i, "ipwon_date", resTable.Rows[i]["ipwon_date"].ToString());
                    layAntiData.SetItemValue(i, "jubsu_date", resTable.Rows[i]["jubsu_date"].ToString());
                    layAntiData.SetItemValue(i, "gwa_name", resTable.Rows[i]["gwa_name"].ToString());
                    layAntiData.SetItemValue(i, "doctor_name", resTable.Rows[i]["doctor_name"].ToString());
                }
                else if (Service.ErrCode != 0)
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }
            }
        }
        #endregion

        #region 반납그리드 표시
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
        }

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
        }
        #endregion

        #region 그리드 믹스 표시
        private void grdMagamOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);
        }

        private void grdMiMagamJUSAOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);
        }

        private void grdMiMagamOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);
        }

        private void grdMagamJUSAOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);
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
                    if (aGrd.GetItemString(i, "dc_yn") == "Y")
                    {
                        aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;
                        continue;
                    }
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

        #endregion


        #region 조회조건 변경시 재조회
        private void dtp_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.queryProcess();
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            this.queryProcess();
        }

        private void queryProcess()
        {
            if (tabControl.SelectedIndex == 0) this.MiMagamQuery();

            if (tabControl.SelectedIndex == 1) this.MagamQuery();
            
            if (tabControl.SelectedIndex == 2) this.DcQuery();
        }
        #endregion

        private void grdMiMagamJUSAOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            //if (!TypeCheck.IsNull(grdMiMagamJUSAOrder.GetItemString(e.RowNumber, "mix_group").Trim()))
            //{
            //    if (grdMiMagamJUSAOrder.GetItemString(e.RowNumber, "if_input_control") == "P"
            //        || grdMiMagamJUSAOrder.GetItemString(e.RowNumber, "if_input_control") == "B")
            //    {
            //        if (grdMiMagamJUSAOrder.GetItemString(e.RowNumber, "if_input_control") == "B")
            //        {
            //            for (int i = 0; i < e.RowNumber; i++)
            //            {
            //                // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
            //                if (grdMiMagamJUSAOrder.GetItemValue(i, "group_ser").ToString().Trim() == grdMiMagamJUSAOrder.GetItemValue(e.RowNumber, "group_ser").ToString().Trim() &&
            //                    grdMiMagamJUSAOrder.GetItemValue(i, "mix_group").ToString().Trim() == grdMiMagamJUSAOrder.GetItemValue(e.RowNumber, "mix_group").ToString().Trim() &&
            //                    grdMiMagamJUSAOrder.GetItemValue(i, "hope_date").ToString().Trim() == grdMiMagamJUSAOrder.GetItemValue(e.RowNumber, "hope_date").ToString().Trim() &&
            //                    grdMiMagamJUSAOrder.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
            //                    grdMiMagamJUSAOrder.GetItemValue(e.RowNumber, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) &&
            //                    (grdMiMagamJUSAOrder.GetItemString(e.RowNumber, "if_input_control") == "P"
            //                    || grdMiMagamJUSAOrder.GetItemString(e.RowNumber, "if_input_control") == "B"))
            //                {
            //                    return;
            //                }
            //            }
            //        }
            //        if (e.ColName == "jaeryo_code" || e.ColName == "jaeryo_name")
            //        {
            //            e.ForeColor = Color.Red;
            //            e.Font = new Font(e.Font, FontStyle.Bold);
            //        }
            //    }
            //}
        }

        #region [ComboBox Event]
        private void cbxGubun_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.queryProcess();
        }

        private void cbxBuseoMagam_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.queryProcess();
        }

        private void cbxBuseo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.queryProcess();

            this.setCycleDate();
        }
        #endregion

        #region [setCycleDate 締切基準情報取得]
        private void setCycleDate()
        {
            // 定期処方周期日付、定期処方締切日付取得   A棟は除外
            BindVarCollection bindVars = new BindVarCollection();

            bindVars.Clear();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_magam_date", this.dtpJubsuDate.GetDataValue());
            bindVars.Add("f_ho_dong", this.cbxBuseo.GetDataValue());

            object retVal = Service.ExecuteScalar(@"SELECT FN_DRG_GET_CYCLE_ORD_DATE(:f_hosp_code, :f_magam_date, :f_ho_dong) FROM DUAL", bindVars);
            if (retVal == null)
            {
                XMessageBox.Show("定期処方周期日付取得に失敗しました。", "基準情報取得失敗", MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.cycleOrdDate = retVal.ToString().Substring(0,10);
                this.lbCycleOrdDate.Text = cycleOrdDate;
            }

            retVal = Service.ExecuteScalar(@"SELECT FN_DRG_GET_CYCLE_MAGAM_DATE(:f_hosp_code, :f_magam_date, :f_ho_dong) FROM DUAL", bindVars);
            if (retVal == null)
            {
                XMessageBox.Show("定期処方締切日付取得に失敗しました。", "基準情報取得失敗", MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.cycleMagamDate = retVal.ToString().Substring(0, 10);
                this.lbCycleMagamDate.Text = cycleMagamDate;
            }
        }
        #endregion

        #region [btnList_ButtonClick]
        private void btnListMimagam_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    //this.MagamQuery();
                    this.MiMagamQuery();
                    break;
            }
        }

        private void btnListMagam_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.MagamQuery();
                    break;
            }
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
                    throw new Exception("転送マスタ（DRG4010）作成に問題が発生しました。");
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
                        throw new Exception(Resources.exception_name4);
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
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, "ATC情報転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                throw new Exception(Resources.exception_name1);
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            msgText = "97101" + pkdrg4010;
            int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            if (ret == -1)
            {
                throw new Exception(Resources.exception_name2 + msgText);
            }
            return true;
        }
        #endregion

        #region [btnAtcTrans_Click ATC再転送]
        private void btnAtcTrans_Click(object sender, EventArgs e)
        {
            if (this.grdDrgBunhoList.RowCount < 1) return;

            if (this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "magam_bunryu").Equals("2")) return;

            bool value = this.procAtcInterface(this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "jubsu_date")
                                             , this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "drg_bunho")
                                             , this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "bunho")
                                             , this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "fkinp1001"));

            if (value == false)
            {
                throw new Exception();
            }
        }
        #endregion

        #region [GRID EVENT 取消/返却GRID EVENT] 
        private void grdPaDcQuery_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPaDcQuery.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPaDcQuery.SetBindVarValue("f_bunho", paBox.BunHo);
            this.grdPaDcQuery.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdPaDcQuery.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.grdPaDcQuery.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
        }

        private void grdPaDcQuery_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            string magam_bunryu = "1", magam_gubun = "N";

            ////내복, 외용
            //if (rbxBunryu1.Checked)
            if (this.grdPaDcQuery.GetItemString(e.CurrentRow, "magam_bunryu") == "1")
            {
                magam_bunryu = "1";
                this.grdDcOrder.Visible = true;
                this.grdJusaDcOrder.Visible = false;

                magam_gubun = this.grdPaDcQuery.GetItemString(e.CurrentRow, "append_yn");

                this.grdDcOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);
                this.grdDcOrder.SetBindVarValue("f_magam_gubun", magam_gubun);

                if (!this.grdDcOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            //주사
            //if (rbxBunryu2.Checked)
            if (grdPaDcQuery.GetItemString(e.CurrentRow, "magam_bunryu") == "2")
            {
                magam_bunryu = "2";
                this.grdDcOrder.Visible = false;
                this.grdJusaDcOrder.Visible = true;

                magam_gubun = this.grdPaDcQuery.GetItemString(e.CurrentRow, "append_yn");

                this.grdJusaDcOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);
                this.grdJusaDcOrder.SetBindVarValue("f_magam_gubun", magam_gubun);

                if (!this.grdJusaDcOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private void grdDcOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            if (this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "magam_bunryu") == "1")
            {
                this.grdDcOrder.SetBindVarValue("f_jubsu_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "jubsu_date"));
                this.grdDcOrder.SetBindVarValue("f_drg_bunho", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "drg_bunho"));

                this.grdDcOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdDcOrder.SetBindVarValue("f_order_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "order_date"));
                this.grdDcOrder.SetBindVarValue("f_hope_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "hope_date"));
                //this.grdDcOrder.SetBindVarValue("f_hope_time", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "hope_time"));
                this.grdDcOrder.SetBindVarValue("f_bunho", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "bunho"));
                this.grdDcOrder.SetBindVarValue("f_ho_dong", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "ho_dong"));
                this.grdDcOrder.SetBindVarValue("f_doctor", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "resident"));
            }
            else
            {
                this.grdJusaDcOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdJusaDcOrder.SetBindVarValue("f_order_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "order_date"));
                this.grdJusaDcOrder.SetBindVarValue("f_hope_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "hope_date"));
                //this.grdJusaDcOrder.SetBindVarValue("f_hope_time", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "hope_time"));
                this.grdJusaDcOrder.SetBindVarValue("f_bunho", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "bunho"));
                this.grdJusaDcOrder.SetBindVarValue("f_ho_dong", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "ho_dong"));
                this.grdJusaDcOrder.SetBindVarValue("f_doctor", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "resident"));
            }
        }

        private void grdDcOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);
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
        }

        private void grdJusaDcOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            if (this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "magam_bunryu") == "1")
            {
                this.grdDcOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdDcOrder.SetBindVarValue("f_order_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "order_date"));
                this.grdDcOrder.SetBindVarValue("f_hope_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "hope_date"));
                //this.grdDcOrder.SetBindVarValue("f_hope_time", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "hope_time"));
                this.grdDcOrder.SetBindVarValue("f_bunho", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "bunho"));
                this.grdDcOrder.SetBindVarValue("f_ho_dong", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "ho_dong"));
                this.grdDcOrder.SetBindVarValue("f_doctor", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "resident"));
            }
            else
            {
                this.grdJusaDcOrder.SetBindVarValue("f_jubsu_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "jubsu_date"));
                this.grdJusaDcOrder.SetBindVarValue("f_drg_bunho", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "drg_bunho"));

                this.grdJusaDcOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdJusaDcOrder.SetBindVarValue("f_order_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "order_date"));
                this.grdJusaDcOrder.SetBindVarValue("f_hope_date", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "hope_date"));
                //this.grdJusaDcOrder.SetBindVarValue("f_hope_time", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "hope_time"));
                this.grdJusaDcOrder.SetBindVarValue("f_bunho", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "bunho"));
                this.grdJusaDcOrder.SetBindVarValue("f_ho_dong", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "ho_dong"));
                this.grdJusaDcOrder.SetBindVarValue("f_doctor", this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "resident"));
            }
        }

        private void grdJusaDcOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);
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

            if (!TypeCheck.IsNull(grdJusaDcOrder.GetItemString(e.RowNumber, "mix_group").Trim()))
            {
                if (grdJusaDcOrder.GetItemString(e.RowNumber, "if_input_control") == "P"
                    || grdJusaDcOrder.GetItemString(e.RowNumber, "if_input_control") == "B")
                {
                    if (grdJusaDcOrder.GetItemString(e.RowNumber, "if_input_control") == "B")
                    {
                        for (int i = 0; i < e.RowNumber; i++)
                        {
                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (grdJusaDcOrder.GetItemValue(i, "group_ser").ToString().Trim() == grdJusaDcOrder.GetItemValue(e.RowNumber, "group_ser").ToString().Trim() &&
                                grdJusaDcOrder.GetItemValue(i, "mix_group").ToString().Trim() == grdJusaDcOrder.GetItemValue(e.RowNumber, "mix_group").ToString().Trim() &&
                                grdJusaDcOrder.GetItemValue(i, "hope_date").ToString().Trim() == grdJusaDcOrder.GetItemValue(e.RowNumber, "hope_date").ToString().Trim() &&
                                grdJusaDcOrder.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                grdJusaDcOrder.GetItemValue(e.RowNumber, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) &&
                                (grdJusaDcOrder.GetItemString(e.RowNumber, "if_input_control") == "P"
                                || grdJusaDcOrder.GetItemString(e.RowNumber, "if_input_control") == "B"))
                            {
                                return;
                            }
                        }
                    }
                    if (e.ColName == "jaeryo_code" || e.ColName == "jaeryo_name")
                    {
                        e.ForeColor = Color.Red;
                        e.Font = new Font(e.Font, FontStyle.Bold);
                    }
                }
            }
        }
        #endregion

        #region [btnListDc_ButtonClick 取消/返却リスト]
        private void btnListDc_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.DcQuery();
                    break;
            }
        }

        private void DcQuery()
        {
            this.grdDcOrder.Reset();
            this.grdJusaDcOrder.Reset();

            string magam_gubun = "N";

            this.grdPaDcQuery.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdPaDcQuery.SetBindVarValue("f_magam_bunryu", this.cbxGubun.GetDataValue());
            this.grdPaDcQuery.SetBindVarValue("f_magam_gubun", magam_gubun);

            this.grdDcOrder.Reset();
            this.grdJusaDcOrder.Reset();
            if (!this.grdPaDcQuery.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }
        #endregion

        #region [取消/返却リスト検索EVENT]
        private void cbxBuseoDc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.queryProcess();
        }

        private void cbxGubunDc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.queryProcess();
        }

        private void dtpDc_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.queryProcess();
        }
        #endregion

        #region [btnDcRePrint_Click 取消/返却リスト処方箋再印刷]
        private void btnDcRePrint_Click(object sender, EventArgs e)
        {
            string drg_bunho = "";
            string jubsu_date = "";
            string magam_gubun = "";

            string gubun = this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "magam_bunryu");

            //내복, 외용
            if ((gubun == "1"))
            {
                if (this.grdDcOrder.CurrentRowNumber < 0) return;
                jubsu_date = this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "jubsu_date");
                drg_bunho = this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "drg_bunho");

                magam_gubun = "11";
            }
            //주사
            if ((gubun == "2"))
            {
                if (this.grdJusaDcOrder.CurrentRowNumber < 0) return;
                jubsu_date = this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "jubsu_date");
                drg_bunho = this.grdPaDcQuery.GetItemString(this.grdPaDcQuery.CurrentRowNumber, "drg_bunho");

                magam_gubun = "12";
            }

            // 처방전 출력
            DrgPrint(jubsu_date, drg_bunho, magam_gubun, "R");
        }
        #endregion

        private void grdMiMagamOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["brought_drg_yn"].ToString() == "Y")
                e.BackColor = Color.LightBlue;
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
            item.Add("f_jubsu_date", this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "jubsu_date"));
            item.Add("f_drg_bunho", this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "drg_bunho"));
            item.Add("f_bunho", this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "bunho"));

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
            item.Add("f_jubsu_date", this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "jubsu_date"));
            item.Add("f_drg_bunho", this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "drg_bunho"));
            item.Add("f_bunho", this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "bunho"));

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
            string jubsuDate = this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "jubsu_date");
            string drgBunho = this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "drg_bunho");
            string bunho = this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "bunho");

            string fkinp1001 = this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "fkinp1001");

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
                        throw new Exception(Resources.exception_name3);
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
                            throw new Exception(Resources.exception_name4);
                        }

                        //２．I/Fテーブルデータ生成（IFS7301, IFS7302）
                        rtnIfsCnt = this.makeIFSTBL("I", pkdrg5010, "Y", "D");
                    }
                    Service.CommitTransaction();

                    //３．じほうにFILE転送
                    if (rtnIfsCnt == 0)
                    {
                        if (this.atcTrans(pkdrg5010, "D"))
                            XMessageBox.Show(Resources.XMessageBox10, Resources.XMessageBox_caption10, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Service.RollbackTransaction();
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, Resources.XMessageBox11, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        throw new Exception("転送マスタ（DRG5030）作成に問題が発生しました。");
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
                            throw new Exception(Resources.exception_name4);
                        }

                        //２．I/Fテーブルデータ生成（IFS7303, IFS7304）
                        rtnIfsCnt = this.makeIFSTBL("I", pkdrg5030, "Y", "I");
                    }
                    Service.CommitTransaction();

                    //３．じほうにFILE転送
                    if (rtnIfsCnt == 0)
                    {
                        if (this.atcTrans(pkdrg5030, "I"))
                            XMessageBox.Show(Resources.XMessageBox10, Resources.XMessageBox_caption10, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Service.RollbackTransaction();
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, Resources.XMessageBox11, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #endregion

            return true;
        }

        private int makeIFSTBL(string io_gubun, string pkdrg, string send_yn, string gubun)
        {
            string jubsuDate = this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "jubsu_date");
            string drgBunho = this.grdDrgBunhoList.GetItemString(this.grdDrgBunhoList.CurrentRowNumber, "drg_bunho");

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
                    throw new Exception(Resources.Exception5);
                }
                else retVal = Int32.Parse(outputList["O_ERR"].ToString());
            }

            if (gubun.Equals("I")) //INJ
            {
                bool ret = Service.ExecuteProcedure("PR_JIH_INJ_IFS_PROC", inputList, outputList);

                if (ret == false || TypeCheck.IsNull(outputList["O_ERR"]) || outputList["O_ERR"].ToString() == "1")
                {
                    throw new Exception(Resources.Exception6);
                }
                else retVal = Int32.Parse(outputList["O_ERR"].ToString());
            }

            return retVal;
        }

        private bool atcTrans(string pkdrg, string gubun)
        {
            if (TypeCheck.IsNull(pkdrg))
            {
                throw new Exception(Resources.exception_name1);
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
                throw new Exception(Resources.Exception7 + msgText);
            }
            return true;
        }
        #endregion

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
            for (int i = 0; i < this.grdPaQuery.RowCount; i++)
            {
                this.grdPaQuery.SetItemValue(i, "magam_yn", "N");
                // 締切日付セット
                this.grdPaQuery.SetItemValue(i, "jubsu_date", "");
            }
        }
        #endregion

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

