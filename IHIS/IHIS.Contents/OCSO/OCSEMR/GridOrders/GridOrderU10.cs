using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.Framework;
using IHIS.OCS;

namespace GridOrders
{
    public class GridOrderU10 : UserControl
    {

        #region AutogenCode
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private IHIS.Framework.XFlatRadioButton rbtSyouhin;
        private IHIS.Framework.XTextBox txtSearch;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XFlatRadioButton rbtGenericSearch;
        private IHIS.Framework.XDictComboBox cboSearchCondition;
        private IHIS.Framework.XComboBox cboQueryCon;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XButton btnExpandSearch;
        private IHIS.Framework.XRadioButton rbnOftenOrder;
        private IHIS.Framework.XPanel pnlOrderDetail;
        private PictureBox pbxIsBgtDrg;
        private IHIS.Framework.XButton btnBroughtDrg;
        private IHIS.Framework.XButton btnNalsu;
        private IHIS.Framework.XButton btnJungsiDrug;
        private IHIS.Framework.XButton btnSetOrder;
        private IHIS.Framework.XButton btnDoOrder;
        private IHIS.Framework.XButton btnExtend;
        private IHIS.Framework.XDisplayBox dbxBogyongName;
        private IHIS.Framework.XFindBox fbxBogyongCode;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XComboBox cboNalsu;
        private IHIS.Framework.XLabel lblNalsu;
        private IHIS.Framework.XLabel lblInOut;
        private IHIS.Framework.XCheckBox cbxEmergency;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XCheckBox cbxWonyoiOrderYN;
        private XTabControl tabSangyongOrder;
        private XEditGrid grdSangyongOrder;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell126;
        private XPanel pnlRightBottom;
        private XDictComboBox cboInputGubun;
        private XButton btnSelect;
        private XButton btnNewSelect;
        private XLabel lblInputGubun;
        private XEditGrid grdOrder;
        private XEditGridCell xEditGridCell351;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
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
        private XEditGridCell xEditGridCell374;
        private XEditGridCell xEditGridCell375;
        private XEditGridCell xEditGridCell376;
        private XEditGridCell xEditGridCell377;
        private XEditGridCell xEditGridCell378;
        private XEditGridCell xEditGridCell379;
        private XEditGridCell xEditGridCell380;
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
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell102;
        private XEditGridCell xEditGridCell103;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell106;
        private XEditGridCell xEditGridCell107;
        private XEditGridCell xEditGridCell108;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell121;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XEditGridCell xEditGridCell122;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XEditGridCell xEditGridCell123;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
        private XTabControl tabGroup;
        private ImageList imageList1;
        private ImageList imageListMixGroup;
        private ImageList imageListPopupMenu;
        private ImageList imageListInfo;
        private MultiLayout layGroupTab;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayout layDrugTree;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayout layPreview;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayout laySaveLayout;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
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
        private MultiLayoutItem multiLayoutItem311;
        private MultiLayoutItem multiLayoutItem312;
        private MultiLayoutItem multiLayoutItem313;
        private MultiLayoutItem multiLayoutItem314;
        private MultiLayoutItem multiLayoutItem315;
        private MultiLayoutItem multiLayoutItem316;
        private MultiLayoutItem multiLayoutItem317;
        private MultiLayoutItem multiLayoutItem318;
        private MultiLayoutItem multiLayoutItem319;
        private MultiLayoutItem multiLayoutItem320;
        private MultiLayoutItem multiLayoutItem321;
        private MultiLayoutItem multiLayoutItem322;
        private MultiLayoutItem multiLayoutItem323;
        private MultiLayoutItem multiLayoutItem324;
        private MultiLayout layDeletedData;
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
        private ToolTip toolTip1;
        private Panel pnlStatus;
        private Label lbStatus;
        private XProgressBar pgbProgress;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridOrderU10));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.grdOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell351 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell374 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell375 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell376 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell377 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell378 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell379 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell380 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.tabGroup = new IHIS.Framework.XTabControl();
            this.pnlOrderDetail = new IHIS.Framework.XPanel();
            this.pbxIsBgtDrg = new System.Windows.Forms.PictureBox();
            this.btnBroughtDrg = new IHIS.Framework.XButton();
            this.btnNalsu = new IHIS.Framework.XButton();
            this.btnJungsiDrug = new IHIS.Framework.XButton();
            this.btnSetOrder = new IHIS.Framework.XButton();
            this.btnDoOrder = new IHIS.Framework.XButton();
            this.btnExtend = new IHIS.Framework.XButton();
            this.dbxBogyongName = new IHIS.Framework.XDisplayBox();
            this.fbxBogyongCode = new IHIS.Framework.XFindBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.cboNalsu = new IHIS.Framework.XComboBox();
            this.lblNalsu = new IHIS.Framework.XLabel();
            this.lblInOut = new IHIS.Framework.XLabel();
            this.cbxEmergency = new IHIS.Framework.XCheckBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cbxWonyoiOrderYN = new IHIS.Framework.XCheckBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.rbtSyouhin = new IHIS.Framework.XFlatRadioButton();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.rbtGenericSearch = new IHIS.Framework.XFlatRadioButton();
            this.cboSearchCondition = new IHIS.Framework.XDictComboBox();
            this.cboQueryCon = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnExpandSearch = new IHIS.Framework.XButton();
            this.rbnOftenOrder = new IHIS.Framework.XRadioButton();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.grdSangyongOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.tabSangyongOrder = new IHIS.Framework.XTabControl();
            this.pnlRightBottom = new IHIS.Framework.XPanel();
            this.cboInputGubun = new IHIS.Framework.XDictComboBox();
            this.btnSelect = new IHIS.Framework.XButton();
            this.btnNewSelect = new IHIS.Framework.XButton();
            this.lblInputGubun = new IHIS.Framework.XLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.imageListPopupMenu = new System.Windows.Forms.ImageList(this.components);
            this.imageListInfo = new System.Windows.Forms.ImageList(this.components);
            this.layGroupTab = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.layDrugTree = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.layPreview = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.laySaveLayout = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem311 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem312 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem313 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem314 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem315 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem316 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem317 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem318 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem319 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem320 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem321 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem322 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem323 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem324 = new IHIS.Framework.MultiLayoutItem();
            this.layDeletedData = new IHIS.Framework.MultiLayout();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.pnlOrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIsBgtDrg)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangyongOrder)).BeginInit();
            this.pnlRightBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDrugTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySaveLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDeletedData)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(937, 373);
            this.splitContainer1.SplitterDistance = 572;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlStatus);
            this.splitContainer2.Panel1.Controls.Add(this.grdOrder);
            this.splitContainer2.Panel1.Controls.Add(this.tabGroup);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pnlOrderDetail);
            this.splitContainer2.Size = new System.Drawing.Size(572, 373);
            this.splitContainer2.SplitterDistance = 301;
            this.splitContainer2.TabIndex = 0;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlStatus.BackgroundImage")));
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.lbStatus);
            this.pnlStatus.Controls.Add(this.pgbProgress);
            this.pnlStatus.Location = new System.Drawing.Point(8, 119);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(557, 62);
            this.pnlStatus.TabIndex = 121;
            this.pnlStatus.Visible = false;
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbStatus.Location = new System.Drawing.Point(417, 16);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(123, 29);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pgbProgress
            // 
            this.pgbProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pgbProgress.Location = new System.Drawing.Point(9, 16);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(446, 29);
            this.pgbProgress.TabIndex = 0;
            // 
            // grdOrder
            // 
            this.grdOrder.AddedHeaderLine = 1;
            this.grdOrder.ApplyPaintEventToAllColumn = true;
            this.grdOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell351,
            this.xEditGridCell34,
            this.xEditGridCell35,
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
            this.xEditGridCell374,
            this.xEditGridCell375,
            this.xEditGridCell376,
            this.xEditGridCell377,
            this.xEditGridCell378,
            this.xEditGridCell379,
            this.xEditGridCell380,
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
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell73,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell119,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell123});
            this.grdOrder.ColPerLine = 40;
            this.grdOrder.Cols = 41;
            this.grdOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrder.EnableMultiSelection = true;
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 2;
            this.grdOrder.HeaderHeights.Add(37);
            this.grdOrder.HeaderHeights.Add(0);
            this.grdOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdOrder.Location = new System.Drawing.Point(0, 29);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.QuerySQL = resources.GetString("grdOrder.QuerySQL");
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.RowResizable = true;
            this.grdOrder.Rows = 3;
            this.grdOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrder.SelectionModeChangeable = true;
            this.grdOrder.ShowNumberAtRowHeader = false;
            this.grdOrder.Size = new System.Drawing.Size(572, 272);
            this.grdOrder.TabIndex = 119;
            this.grdOrder.TogglingRowSelection = true;
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrder_GridColumnProtectModify);
            this.grdOrder.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOrder_GridFindClick);
            this.grdOrder.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOrder_ItemValueChanging);
            this.grdOrder.GridReservedMemoButtonClick += new IHIS.Framework.GridReservedMemoButtonClickEventHandler(this.grdOrder_GridReservedMemoButtonClick);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSangyongOrder_GridCellPainting);
            this.grdOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOrder_GridColumnChanged);
            this.grdOrder.Click += new System.EventHandler(this.grdOrder_Click);
            this.grdOrder.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOrder_DragDrop);
            this.grdOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOrder_DragEnter);
            this.grdOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOrder_GiveFeedback);
            this.grdOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOrder_MouseDown);
            // 
            // xEditGridCell351
            // 
            this.xEditGridCell351.CellName = "pkocskey";
            this.xEditGridCell351.Col = -1;
            this.xEditGridCell351.ExecuteQuery = null;
            this.xEditGridCell351.HeaderText = "pkocskey";
            this.xEditGridCell351.IsVisible = false;
            this.xEditGridCell351.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "memb";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderText = "memb";
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "yaksok_code";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderText = "yaksok_code";
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell358
            // 
            this.xEditGridCell358.CellName = "bunho";
            this.xEditGridCell358.Col = -1;
            this.xEditGridCell358.ExecuteQuery = null;
            this.xEditGridCell358.HeaderText = "bunho";
            this.xEditGridCell358.IsVisible = false;
            this.xEditGridCell358.Row = -1;
            // 
            // xEditGridCell359
            // 
            this.xEditGridCell359.CellName = "in_out_key";
            this.xEditGridCell359.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell359.Col = -1;
            this.xEditGridCell359.ExecuteQuery = null;
            this.xEditGridCell359.HeaderText = "in_out_key";
            this.xEditGridCell359.IsVisible = false;
            this.xEditGridCell359.Row = -1;
            // 
            // xEditGridCell360
            // 
            this.xEditGridCell360.CellName = "order_date";
            this.xEditGridCell360.Col = -1;
            this.xEditGridCell360.ExecuteQuery = null;
            this.xEditGridCell360.HeaderText = "order_date";
            this.xEditGridCell360.IsVisible = false;
            this.xEditGridCell360.Row = -1;
            // 
            // xEditGridCell361
            // 
            this.xEditGridCell361.CellName = "order_time";
            this.xEditGridCell361.Col = -1;
            this.xEditGridCell361.ExecuteQuery = null;
            this.xEditGridCell361.HeaderText = "order_time";
            this.xEditGridCell361.IsVisible = false;
            this.xEditGridCell361.Row = -1;
            // 
            // xEditGridCell362
            // 
            this.xEditGridCell362.CellName = "gwa";
            this.xEditGridCell362.Col = -1;
            this.xEditGridCell362.ExecuteQuery = null;
            this.xEditGridCell362.HeaderText = "gwa";
            this.xEditGridCell362.IsVisible = false;
            this.xEditGridCell362.Row = -1;
            // 
            // xEditGridCell363
            // 
            this.xEditGridCell363.CellName = "doctor";
            this.xEditGridCell363.Col = -1;
            this.xEditGridCell363.ExecuteQuery = null;
            this.xEditGridCell363.HeaderText = "doctor";
            this.xEditGridCell363.IsVisible = false;
            this.xEditGridCell363.Row = -1;
            // 
            // xEditGridCell364
            // 
            this.xEditGridCell364.CellName = "resident";
            this.xEditGridCell364.Col = -1;
            this.xEditGridCell364.ExecuteQuery = null;
            this.xEditGridCell364.HeaderText = "resident";
            this.xEditGridCell364.IsVisible = false;
            this.xEditGridCell364.Row = -1;
            // 
            // xEditGridCell365
            // 
            this.xEditGridCell365.CellName = "naewon_type";
            this.xEditGridCell365.Col = -1;
            this.xEditGridCell365.ExecuteQuery = null;
            this.xEditGridCell365.HeaderText = "naewon_type";
            this.xEditGridCell365.IsVisible = false;
            this.xEditGridCell365.Row = -1;
            // 
            // xEditGridCell366
            // 
            this.xEditGridCell366.CellName = "input_id";
            this.xEditGridCell366.Col = -1;
            this.xEditGridCell366.ExecuteQuery = null;
            this.xEditGridCell366.HeaderText = "input_id";
            this.xEditGridCell366.IsVisible = false;
            this.xEditGridCell366.Row = -1;
            // 
            // xEditGridCell367
            // 
            this.xEditGridCell367.CellName = "input_part";
            this.xEditGridCell367.Col = -1;
            this.xEditGridCell367.ExecuteQuery = null;
            this.xEditGridCell367.HeaderText = "input_part";
            this.xEditGridCell367.IsVisible = false;
            this.xEditGridCell367.Row = -1;
            // 
            // xEditGridCell368
            // 
            this.xEditGridCell368.CellName = "input_gwa";
            this.xEditGridCell368.Col = -1;
            this.xEditGridCell368.ExecuteQuery = null;
            this.xEditGridCell368.HeaderText = "input_gwa";
            this.xEditGridCell368.IsVisible = false;
            this.xEditGridCell368.Row = -1;
            // 
            // xEditGridCell369
            // 
            this.xEditGridCell369.CellName = "input_doctor";
            this.xEditGridCell369.Col = -1;
            this.xEditGridCell369.ExecuteQuery = null;
            this.xEditGridCell369.HeaderText = "input_doctor";
            this.xEditGridCell369.IsVisible = false;
            this.xEditGridCell369.Row = -1;
            // 
            // xEditGridCell370
            // 
            this.xEditGridCell370.CellName = "input_gubun";
            this.xEditGridCell370.Col = -1;
            this.xEditGridCell370.ExecuteQuery = null;
            this.xEditGridCell370.HeaderText = "input_gubun";
            this.xEditGridCell370.IsVisible = false;
            this.xEditGridCell370.Row = -1;
            // 
            // xEditGridCell371
            // 
            this.xEditGridCell371.CellName = "input_gubun_name";
            this.xEditGridCell371.CellWidth = 30;
            this.xEditGridCell371.Col = 2;
            this.xEditGridCell371.ExecuteQuery = null;
            this.xEditGridCell371.HeaderText = "区分";
            this.xEditGridCell371.IsReadOnly = true;
            this.xEditGridCell371.IsUpdatable = false;
            this.xEditGridCell371.IsUpdCol = false;
            this.xEditGridCell371.RowSpan = 2;
            // 
            // xEditGridCell372
            // 
            this.xEditGridCell372.CellName = "group_ser";
            this.xEditGridCell372.CellWidth = 27;
            this.xEditGridCell372.Col = 3;
            this.xEditGridCell372.ExecuteQuery = null;
            this.xEditGridCell372.HeaderText = "G\r\nR";
            this.xEditGridCell372.RowSpan = 2;
            this.xEditGridCell372.SuppressRepeating = true;
            // 
            // xEditGridCell373
            // 
            this.xEditGridCell373.CellName = "input_tab";
            this.xEditGridCell373.Col = -1;
            this.xEditGridCell373.ExecuteQuery = null;
            this.xEditGridCell373.HeaderText = "input_tab";
            this.xEditGridCell373.IsVisible = false;
            this.xEditGridCell373.Row = -1;
            // 
            // xEditGridCell374
            // 
            this.xEditGridCell374.CellName = "input_tab_name";
            this.xEditGridCell374.Col = -1;
            this.xEditGridCell374.ExecuteQuery = null;
            this.xEditGridCell374.HeaderText = "input_tab_name";
            this.xEditGridCell374.IsReadOnly = true;
            this.xEditGridCell374.IsUpdatable = false;
            this.xEditGridCell374.IsUpdCol = false;
            this.xEditGridCell374.IsVisible = false;
            this.xEditGridCell374.Row = -1;
            // 
            // xEditGridCell375
            // 
            this.xEditGridCell375.CellName = "order_gubun";
            this.xEditGridCell375.Col = -1;
            this.xEditGridCell375.ExecuteQuery = null;
            this.xEditGridCell375.HeaderText = "order_gubun";
            this.xEditGridCell375.IsVisible = false;
            this.xEditGridCell375.Row = -1;
            // 
            // xEditGridCell376
            // 
            this.xEditGridCell376.CellName = "order_gubun_name";
            this.xEditGridCell376.CellWidth = 45;
            this.xEditGridCell376.Col = 6;
            this.xEditGridCell376.ExecuteQuery = null;
            this.xEditGridCell376.HeaderText = "オーダ\r\n区分";
            this.xEditGridCell376.IsReadOnly = true;
            this.xEditGridCell376.IsUpdatable = false;
            this.xEditGridCell376.IsUpdCol = false;
            this.xEditGridCell376.RowSpan = 2;
            this.xEditGridCell376.SuppressRepeating = true;
            this.xEditGridCell376.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell377
            // 
            this.xEditGridCell377.CellName = "group_yn";
            this.xEditGridCell377.Col = -1;
            this.xEditGridCell377.ExecuteQuery = null;
            this.xEditGridCell377.HeaderText = "group_yn";
            this.xEditGridCell377.IsVisible = false;
            this.xEditGridCell377.Row = -1;
            // 
            // xEditGridCell378
            // 
            this.xEditGridCell378.CellName = "seq";
            this.xEditGridCell378.Col = -1;
            this.xEditGridCell378.ExecuteQuery = null;
            this.xEditGridCell378.HeaderText = "seq";
            this.xEditGridCell378.IsVisible = false;
            this.xEditGridCell378.Row = -1;
            // 
            // xEditGridCell379
            // 
            this.xEditGridCell379.CellName = "slip_code";
            this.xEditGridCell379.Col = -1;
            this.xEditGridCell379.ExecuteQuery = null;
            this.xEditGridCell379.HeaderText = "slip_code";
            this.xEditGridCell379.IsVisible = false;
            this.xEditGridCell379.Row = -1;
            // 
            // xEditGridCell380
            // 
            this.xEditGridCell380.AutoTabDataSelected = true;
            this.xEditGridCell380.CellName = "hangmog_code";
            this.xEditGridCell380.CellWidth = 70;
            this.xEditGridCell380.Col = 7;
            this.xEditGridCell380.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell380.ExecuteQuery = null;
            this.xEditGridCell380.HeaderText = "オーダコード";
            this.xEditGridCell380.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell380.IsNotNull = true;
            this.xEditGridCell380.IsUpdatable = false;
            this.xEditGridCell380.RowSpan = 2;
            this.xEditGridCell380.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell384
            // 
            this.xEditGridCell384.CellName = "hangmog_name";
            this.xEditGridCell384.CellWidth = 200;
            this.xEditGridCell384.Col = 8;
            this.xEditGridCell384.ExecuteQuery = null;
            this.xEditGridCell384.HeaderText = "オーダ名";
            this.xEditGridCell384.IsNotNull = true;
            this.xEditGridCell384.IsReadOnly = true;
            this.xEditGridCell384.IsUpdatable = false;
            this.xEditGridCell384.IsUpdCol = false;
            this.xEditGridCell384.RowSpan = 2;
            // 
            // xEditGridCell385
            // 
            this.xEditGridCell385.CellName = "specimen_code";
            this.xEditGridCell385.CellWidth = 54;
            this.xEditGridCell385.Col = -1;
            this.xEditGridCell385.ExecuteQuery = null;
            this.xEditGridCell385.HeaderText = "検体";
            this.xEditGridCell385.IsVisible = false;
            this.xEditGridCell385.Row = -1;
            // 
            // xEditGridCell386
            // 
            this.xEditGridCell386.CellName = "specimen_name";
            this.xEditGridCell386.CellWidth = 52;
            this.xEditGridCell386.Col = -1;
            this.xEditGridCell386.ExecuteQuery = null;
            this.xEditGridCell386.HeaderText = "検体名";
            this.xEditGridCell386.IsReadOnly = true;
            this.xEditGridCell386.IsUpdatable = false;
            this.xEditGridCell386.IsUpdCol = false;
            this.xEditGridCell386.IsVisible = false;
            this.xEditGridCell386.Row = -1;
            // 
            // xEditGridCell387
            // 
            this.xEditGridCell387.CellName = "suryang";
            this.xEditGridCell387.CellWidth = 40;
            this.xEditGridCell387.Col = 13;
            this.xEditGridCell387.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell387.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell387.ExecuteQuery = null;
            this.xEditGridCell387.HeaderText = "数量";
            this.xEditGridCell387.IsNotNull = true;
            this.xEditGridCell387.MaxDropDownItems = 9;
            this.xEditGridCell387.RowSpan = 2;
            this.xEditGridCell387.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell388
            // 
            this.xEditGridCell388.CellName = "sunab_suryang";
            this.xEditGridCell388.Col = -1;
            this.xEditGridCell388.ExecuteQuery = null;
            this.xEditGridCell388.HeaderText = "sunab_suryang";
            this.xEditGridCell388.IsVisible = false;
            this.xEditGridCell388.Row = -1;
            // 
            // xEditGridCell389
            // 
            this.xEditGridCell389.CellName = "subul_suryang";
            this.xEditGridCell389.Col = -1;
            this.xEditGridCell389.ExecuteQuery = null;
            this.xEditGridCell389.HeaderText = "subul_suryang";
            this.xEditGridCell389.IsVisible = false;
            this.xEditGridCell389.Row = -1;
            // 
            // xEditGridCell390
            // 
            this.xEditGridCell390.CellName = "ord_danui";
            this.xEditGridCell390.Col = -1;
            this.xEditGridCell390.ExecuteQuery = null;
            this.xEditGridCell390.HeaderText = "ord_danui";
            this.xEditGridCell390.IsVisible = false;
            this.xEditGridCell390.Row = -1;
            // 
            // xEditGridCell391
            // 
            this.xEditGridCell391.AutoTabDataSelected = true;
            this.xEditGridCell391.CellName = "ord_danui_name";
            this.xEditGridCell391.CellWidth = 62;
            this.xEditGridCell391.Col = 14;
            this.xEditGridCell391.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell391.ExecuteQuery = null;
            this.xEditGridCell391.HeaderText = "単位";
            this.xEditGridCell391.IsUpdCol = false;
            this.xEditGridCell391.RowSpan = 2;
            // 
            // xEditGridCell392
            // 
            this.xEditGridCell392.CellName = "dv_time";
            this.xEditGridCell392.CellWidth = 18;
            this.xEditGridCell392.Col = 15;
            this.xEditGridCell392.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell392.ExecuteQuery = null;
            this.xEditGridCell392.HeaderText = "DV類型";
            this.xEditGridCell392.Row = 1;
            this.xEditGridCell392.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell393
            // 
            this.xEditGridCell393.CellName = "dv";
            this.xEditGridCell393.CellWidth = 32;
            this.xEditGridCell393.Col = 16;
            this.xEditGridCell393.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell393.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell393.ExecuteQuery = null;
            this.xEditGridCell393.HeaderText = "回数";
            this.xEditGridCell393.Row = 1;
            this.xEditGridCell393.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell394
            // 
            this.xEditGridCell394.CellName = "dv_1";
            this.xEditGridCell394.CellWidth = 38;
            this.xEditGridCell394.Col = 17;
            this.xEditGridCell394.ExecuteQuery = null;
            this.xEditGridCell394.HeaderText = "dv_1";
            this.xEditGridCell394.IsReadOnly = true;
            this.xEditGridCell394.Row = 1;
            this.xEditGridCell394.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell395
            // 
            this.xEditGridCell395.CellName = "dv_2";
            this.xEditGridCell395.CellWidth = 30;
            this.xEditGridCell395.Col = 18;
            this.xEditGridCell395.ExecuteQuery = null;
            this.xEditGridCell395.HeaderText = "dv_2";
            this.xEditGridCell395.IsReadOnly = true;
            this.xEditGridCell395.Row = 1;
            this.xEditGridCell395.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell396
            // 
            this.xEditGridCell396.CellName = "dv_3";
            this.xEditGridCell396.CellWidth = 30;
            this.xEditGridCell396.Col = 19;
            this.xEditGridCell396.ExecuteQuery = null;
            this.xEditGridCell396.HeaderText = "dv_3";
            this.xEditGridCell396.IsReadOnly = true;
            this.xEditGridCell396.Row = 1;
            this.xEditGridCell396.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell397
            // 
            this.xEditGridCell397.CellName = "dv_4";
            this.xEditGridCell397.CellWidth = 30;
            this.xEditGridCell397.Col = 20;
            this.xEditGridCell397.ExecuteQuery = null;
            this.xEditGridCell397.HeaderText = "dv_4";
            this.xEditGridCell397.IsReadOnly = true;
            this.xEditGridCell397.Row = 1;
            this.xEditGridCell397.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell398
            // 
            this.xEditGridCell398.CellName = "nalsu";
            this.xEditGridCell398.CellWidth = 33;
            this.xEditGridCell398.Col = -1;
            this.xEditGridCell398.ExecuteQuery = null;
            this.xEditGridCell398.HeaderText = "日数";
            this.xEditGridCell398.IsNotNull = true;
            this.xEditGridCell398.IsVisible = false;
            this.xEditGridCell398.Row = -1;
            // 
            // xEditGridCell399
            // 
            this.xEditGridCell399.CellName = "sunab_nalsu";
            this.xEditGridCell399.Col = -1;
            this.xEditGridCell399.ExecuteQuery = null;
            this.xEditGridCell399.HeaderText = "sunab_nalsu";
            this.xEditGridCell399.IsVisible = false;
            this.xEditGridCell399.Row = -1;
            // 
            // xEditGridCell400
            // 
            this.xEditGridCell400.CellName = "jusa";
            this.xEditGridCell400.CellWidth = 38;
            this.xEditGridCell400.Col = -1;
            this.xEditGridCell400.ExecuteQuery = null;
            this.xEditGridCell400.HeaderText = "注射";
            this.xEditGridCell400.IsVisible = false;
            this.xEditGridCell400.Row = -1;
            // 
            // xEditGridCell401
            // 
            this.xEditGridCell401.CellName = "jusa_name";
            this.xEditGridCell401.Col = -1;
            this.xEditGridCell401.ExecuteQuery = null;
            this.xEditGridCell401.HeaderText = "注射名";
            this.xEditGridCell401.IsReadOnly = true;
            this.xEditGridCell401.IsUpdatable = false;
            this.xEditGridCell401.IsUpdCol = false;
            this.xEditGridCell401.IsVisible = false;
            this.xEditGridCell401.Row = -1;
            // 
            // xEditGridCell402
            // 
            this.xEditGridCell402.CellName = "jusa_spd_gubun";
            this.xEditGridCell402.CellWidth = 39;
            this.xEditGridCell402.Col = -1;
            this.xEditGridCell402.ExecuteQuery = null;
            this.xEditGridCell402.HeaderText = "ml\r\nhr";
            this.xEditGridCell402.IsVisible = false;
            this.xEditGridCell402.Row = -1;
            // 
            // xEditGridCell403
            // 
            this.xEditGridCell403.CellName = "bogyong_code";
            this.xEditGridCell403.CellWidth = 54;
            this.xEditGridCell403.Col = -1;
            this.xEditGridCell403.ExecuteQuery = null;
            this.xEditGridCell403.HeaderText = "用法";
            this.xEditGridCell403.IsVisible = false;
            this.xEditGridCell403.Row = -1;
            // 
            // xEditGridCell404
            // 
            this.xEditGridCell404.CellName = "bogyong_name";
            this.xEditGridCell404.CellWidth = 109;
            this.xEditGridCell404.Col = -1;
            this.xEditGridCell404.ExecuteQuery = null;
            this.xEditGridCell404.HeaderText = "用法";
            this.xEditGridCell404.IsReadOnly = true;
            this.xEditGridCell404.IsVisible = false;
            this.xEditGridCell404.Row = -1;
            // 
            // xEditGridCell405
            // 
            this.xEditGridCell405.CellName = "emergency";
            this.xEditGridCell405.CellWidth = 26;
            this.xEditGridCell405.Col = -1;
            this.xEditGridCell405.ExecuteQuery = null;
            this.xEditGridCell405.HeaderText = "緊\r\n急";
            this.xEditGridCell405.IsVisible = false;
            this.xEditGridCell405.Row = -1;
            // 
            // xEditGridCell406
            // 
            this.xEditGridCell406.CellName = "jaeryo_jundal_yn";
            this.xEditGridCell406.Col = -1;
            this.xEditGridCell406.ExecuteQuery = null;
            this.xEditGridCell406.HeaderText = "jaeryo_jundal_yn";
            this.xEditGridCell406.IsVisible = false;
            this.xEditGridCell406.Row = -1;
            // 
            // xEditGridCell407
            // 
            this.xEditGridCell407.CellName = "jundal_table";
            this.xEditGridCell407.Col = -1;
            this.xEditGridCell407.ExecuteQuery = null;
            this.xEditGridCell407.HeaderText = "jundal_table";
            this.xEditGridCell407.IsVisible = false;
            this.xEditGridCell407.Row = -1;
            // 
            // xEditGridCell408
            // 
            this.xEditGridCell408.AutoTabDataSelected = true;
            this.xEditGridCell408.CellName = "jundal_part";
            this.xEditGridCell408.CellWidth = 41;
            this.xEditGridCell408.Col = 31;
            this.xEditGridCell408.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell408.ExecuteQuery = null;
            this.xEditGridCell408.HeaderText = "行為\r\n部署";
            this.xEditGridCell408.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell408.RowSpan = 2;
            // 
            // xEditGridCell409
            // 
            this.xEditGridCell409.CellName = "move_part";
            this.xEditGridCell409.Col = -1;
            this.xEditGridCell409.ExecuteQuery = null;
            this.xEditGridCell409.HeaderText = "move_part";
            this.xEditGridCell409.IsVisible = false;
            this.xEditGridCell409.Row = -1;
            // 
            // xEditGridCell410
            // 
            this.xEditGridCell410.CellName = "portable_yn";
            this.xEditGridCell410.Col = -1;
            this.xEditGridCell410.ExecuteQuery = null;
            this.xEditGridCell410.HeaderText = "移動\r\n撮影";
            this.xEditGridCell410.IsVisible = false;
            this.xEditGridCell410.Row = -1;
            // 
            // xEditGridCell411
            // 
            this.xEditGridCell411.CellName = "powder_yn";
            this.xEditGridCell411.CellWidth = 25;
            this.xEditGridCell411.Col = 30;
            this.xEditGridCell411.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell411.ExecuteQuery = null;
            this.xEditGridCell411.HeaderText = "粉\r\n砕";
            this.xEditGridCell411.RowSpan = 2;
            // 
            // xEditGridCell412
            // 
            this.xEditGridCell412.CellName = "hubal_change_yn";
            this.xEditGridCell412.CellWidth = 30;
            this.xEditGridCell412.Col = 9;
            this.xEditGridCell412.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell412.ExecuteQuery = null;
            this.xEditGridCell412.HeaderText = "後発\r\n不可";
            this.xEditGridCell412.RowSpan = 2;
            // 
            // xEditGridCell413
            // 
            this.xEditGridCell413.CellName = "pharmacy";
            this.xEditGridCell413.CellWidth = 25;
            this.xEditGridCell413.Col = 28;
            this.xEditGridCell413.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell413.ExecuteQuery = null;
            this.xEditGridCell413.HeaderText = "簡\r\n易";
            this.xEditGridCell413.RowSpan = 2;
            // 
            // xEditGridCell414
            // 
            this.xEditGridCell414.CellName = "drg_pack_yn";
            this.xEditGridCell414.CellWidth = 25;
            this.xEditGridCell414.Col = 25;
            this.xEditGridCell414.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell414.ExecuteQuery = null;
            this.xEditGridCell414.HeaderText = "一\r\n包";
            this.xEditGridCell414.RowSpan = 2;
            // 
            // xEditGridCell415
            // 
            this.xEditGridCell415.CellName = "muhyo";
            this.xEditGridCell415.CellWidth = 25;
            this.xEditGridCell415.Col = 26;
            this.xEditGridCell415.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell415.ExecuteQuery = null;
            this.xEditGridCell415.HeaderText = "無\r\n効";
            this.xEditGridCell415.RowSpan = 2;
            // 
            // xEditGridCell416
            // 
            this.xEditGridCell416.CellName = "prn_yn";
            this.xEditGridCell416.CellWidth = 29;
            this.xEditGridCell416.Col = -1;
            this.xEditGridCell416.ExecuteQuery = null;
            this.xEditGridCell416.HeaderText = "P\r\nR\r\nN";
            this.xEditGridCell416.IsVisible = false;
            this.xEditGridCell416.Row = -1;
            // 
            // xEditGridCell417
            // 
            this.xEditGridCell417.CellName = "toiwon_drg_yn";
            this.xEditGridCell417.CellWidth = 25;
            this.xEditGridCell417.Col = 29;
            this.xEditGridCell417.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell417.ExecuteQuery = null;
            this.xEditGridCell417.HeaderText = "退\r\n/\r\n外";
            this.xEditGridCell417.RowSpan = 2;
            // 
            // xEditGridCell418
            // 
            this.xEditGridCell418.CellName = "prn_nurse";
            this.xEditGridCell418.Col = -1;
            this.xEditGridCell418.ExecuteQuery = null;
            this.xEditGridCell418.HeaderText = "prn_nurse";
            this.xEditGridCell418.IsVisible = false;
            this.xEditGridCell418.Row = -1;
            // 
            // xEditGridCell419
            // 
            this.xEditGridCell419.CellName = "append_yn";
            this.xEditGridCell419.Col = -1;
            this.xEditGridCell419.ExecuteQuery = null;
            this.xEditGridCell419.HeaderText = "append_yn";
            this.xEditGridCell419.IsVisible = false;
            this.xEditGridCell419.Row = -1;
            // 
            // xEditGridCell420
            // 
            this.xEditGridCell420.CellLen = 2000;
            this.xEditGridCell420.CellName = "order_remark";
            this.xEditGridCell420.CellWidth = 60;
            this.xEditGridCell420.Col = 11;
            this.xEditGridCell420.DisplayMemoText = true;
            this.xEditGridCell420.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell420.ExecuteQuery = null;
            this.xEditGridCell420.HeaderText = "コメント";
            this.xEditGridCell420.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell420.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell420.ReservedMemoFileName = "C:\\IHIS\\OCSA\\OCS.Lib.CommonForms.dll";
            this.xEditGridCell420.RowSpan = 2;
            this.xEditGridCell420.ShowReservedMemoButton = true;
            // 
            // xEditGridCell421
            // 
            this.xEditGridCell421.CellLen = 2000;
            this.xEditGridCell421.CellName = "nurse_remark";
            this.xEditGridCell421.CellWidth = 60;
            this.xEditGridCell421.Col = 34;
            this.xEditGridCell421.DisplayMemoText = true;
            this.xEditGridCell421.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell421.ExecuteQuery = null;
            this.xEditGridCell421.HeaderText = "看護\r\nComment";
            this.xEditGridCell421.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell421.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.xEditGridCell421.ReservedMemoFileName = "C:\\IHIS\\OCSA\\OCS.Lib.CommonForms.dll";
            this.xEditGridCell421.RowSpan = 2;
            this.xEditGridCell421.ShowReservedMemoButton = true;
            // 
            // xEditGridCell422
            // 
            this.xEditGridCell422.CellName = "mix_group";
            this.xEditGridCell422.Col = -1;
            this.xEditGridCell422.ExecuteQuery = null;
            this.xEditGridCell422.HeaderText = "mix_group";
            this.xEditGridCell422.IsVisible = false;
            this.xEditGridCell422.Row = -1;
            // 
            // xEditGridCell423
            // 
            this.xEditGridCell423.CellName = "amt";
            this.xEditGridCell423.Col = -1;
            this.xEditGridCell423.ExecuteQuery = null;
            this.xEditGridCell423.HeaderText = "金額";
            this.xEditGridCell423.IsVisible = false;
            this.xEditGridCell423.Row = -1;
            // 
            // xEditGridCell424
            // 
            this.xEditGridCell424.CellName = "pay";
            this.xEditGridCell424.CellWidth = 51;
            this.xEditGridCell424.Col = -1;
            this.xEditGridCell424.ExecuteQuery = null;
            this.xEditGridCell424.HeaderText = "請求\r\n区分";
            this.xEditGridCell424.IsVisible = false;
            this.xEditGridCell424.Row = -1;
            // 
            // xEditGridCell425
            // 
            this.xEditGridCell425.CellName = "wonyoi_order_yn";
            this.xEditGridCell425.CellWidth = 29;
            this.xEditGridCell425.Col = -1;
            this.xEditGridCell425.ExecuteQuery = null;
            this.xEditGridCell425.HeaderText = "院\r\n外";
            this.xEditGridCell425.IsVisible = false;
            this.xEditGridCell425.Row = -1;
            // 
            // xEditGridCell426
            // 
            this.xEditGridCell426.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell426.CellWidth = 31;
            this.xEditGridCell426.Col = -1;
            this.xEditGridCell426.ExecuteQuery = null;
            this.xEditGridCell426.HeaderText = "施行";
            this.xEditGridCell426.IsVisible = false;
            this.xEditGridCell426.Row = -1;
            // 
            // xEditGridCell427
            // 
            this.xEditGridCell427.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell427.CellWidth = 38;
            this.xEditGridCell427.Col = -1;
            this.xEditGridCell427.ExecuteQuery = null;
            this.xEditGridCell427.HeaderText = "結果";
            this.xEditGridCell427.IsVisible = false;
            this.xEditGridCell427.Row = -1;
            // 
            // xEditGridCell428
            // 
            this.xEditGridCell428.CellName = "bom_occur_yn";
            this.xEditGridCell428.Col = -1;
            this.xEditGridCell428.ExecuteQuery = null;
            this.xEditGridCell428.HeaderText = "bom_occur_yn";
            this.xEditGridCell428.IsVisible = false;
            this.xEditGridCell428.Row = -1;
            // 
            // xEditGridCell429
            // 
            this.xEditGridCell429.CellName = "bom_source_key";
            this.xEditGridCell429.Col = -1;
            this.xEditGridCell429.ExecuteQuery = null;
            this.xEditGridCell429.HeaderText = "bom_source_key";
            this.xEditGridCell429.IsVisible = false;
            this.xEditGridCell429.Row = -1;
            // 
            // xEditGridCell430
            // 
            this.xEditGridCell430.CellName = "display_yn";
            this.xEditGridCell430.Col = -1;
            this.xEditGridCell430.ExecuteQuery = null;
            this.xEditGridCell430.HeaderText = "display_yn";
            this.xEditGridCell430.IsVisible = false;
            this.xEditGridCell430.Row = -1;
            // 
            // xEditGridCell431
            // 
            this.xEditGridCell431.CellName = "sunab_yn";
            this.xEditGridCell431.Col = -1;
            this.xEditGridCell431.ExecuteQuery = null;
            this.xEditGridCell431.HeaderText = "sunab_yn";
            this.xEditGridCell431.IsVisible = false;
            this.xEditGridCell431.Row = -1;
            // 
            // xEditGridCell432
            // 
            this.xEditGridCell432.CellName = "sunab_date";
            this.xEditGridCell432.Col = -1;
            this.xEditGridCell432.ExecuteQuery = null;
            this.xEditGridCell432.HeaderText = "sunab_date";
            this.xEditGridCell432.IsVisible = false;
            this.xEditGridCell432.Row = -1;
            // 
            // xEditGridCell433
            // 
            this.xEditGridCell433.CellName = "sunab_time";
            this.xEditGridCell433.Col = -1;
            this.xEditGridCell433.ExecuteQuery = null;
            this.xEditGridCell433.HeaderText = "sunab_time";
            this.xEditGridCell433.IsVisible = false;
            this.xEditGridCell433.Row = -1;
            // 
            // xEditGridCell434
            // 
            this.xEditGridCell434.CellName = "hope_date";
            this.xEditGridCell434.Col = 12;
            this.xEditGridCell434.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell434.ExecuteQuery = null;
            this.xEditGridCell434.HeaderText = "希望日";
            this.xEditGridCell434.RowSpan = 2;
            // 
            // xEditGridCell435
            // 
            this.xEditGridCell435.CellName = "hope_time";
            this.xEditGridCell435.Col = -1;
            this.xEditGridCell435.ExecuteQuery = null;
            this.xEditGridCell435.HeaderText = "hope_time";
            this.xEditGridCell435.IsVisible = false;
            this.xEditGridCell435.Row = -1;
            // 
            // xEditGridCell436
            // 
            this.xEditGridCell436.CellName = "nurse_confirm_user";
            this.xEditGridCell436.Col = -1;
            this.xEditGridCell436.ExecuteQuery = null;
            this.xEditGridCell436.HeaderText = "nurse_confirm_user";
            this.xEditGridCell436.IsVisible = false;
            this.xEditGridCell436.Row = -1;
            // 
            // xEditGridCell437
            // 
            this.xEditGridCell437.CellName = "nurse_confirm_date";
            this.xEditGridCell437.Col = -1;
            this.xEditGridCell437.ExecuteQuery = null;
            this.xEditGridCell437.HeaderText = "nurse_confirm_date";
            this.xEditGridCell437.IsVisible = false;
            this.xEditGridCell437.Row = -1;
            // 
            // xEditGridCell438
            // 
            this.xEditGridCell438.CellName = "nurse_confirm_time";
            this.xEditGridCell438.Col = -1;
            this.xEditGridCell438.ExecuteQuery = null;
            this.xEditGridCell438.HeaderText = "nurse_confirm_time";
            this.xEditGridCell438.IsVisible = false;
            this.xEditGridCell438.Row = -1;
            // 
            // xEditGridCell439
            // 
            this.xEditGridCell439.CellName = "nurse_pickup_user";
            this.xEditGridCell439.Col = -1;
            this.xEditGridCell439.ExecuteQuery = null;
            this.xEditGridCell439.HeaderText = "nurse_pickup_user";
            this.xEditGridCell439.IsVisible = false;
            this.xEditGridCell439.Row = -1;
            // 
            // xEditGridCell440
            // 
            this.xEditGridCell440.CellName = "nurse_pickup_date";
            this.xEditGridCell440.Col = -1;
            this.xEditGridCell440.ExecuteQuery = null;
            this.xEditGridCell440.HeaderText = "nurse_pickup_date";
            this.xEditGridCell440.IsVisible = false;
            this.xEditGridCell440.Row = -1;
            // 
            // xEditGridCell441
            // 
            this.xEditGridCell441.CellName = "nurse_pickup_time";
            this.xEditGridCell441.Col = -1;
            this.xEditGridCell441.ExecuteQuery = null;
            this.xEditGridCell441.HeaderText = "nurse_pickup_time";
            this.xEditGridCell441.IsVisible = false;
            this.xEditGridCell441.Row = -1;
            // 
            // xEditGridCell442
            // 
            this.xEditGridCell442.CellName = "nurse_hold_user";
            this.xEditGridCell442.Col = -1;
            this.xEditGridCell442.ExecuteQuery = null;
            this.xEditGridCell442.HeaderText = "nurse_hold_user";
            this.xEditGridCell442.IsVisible = false;
            this.xEditGridCell442.Row = -1;
            // 
            // xEditGridCell443
            // 
            this.xEditGridCell443.CellName = "nurse_hold_date";
            this.xEditGridCell443.Col = -1;
            this.xEditGridCell443.ExecuteQuery = null;
            this.xEditGridCell443.HeaderText = "nurse_hold_date";
            this.xEditGridCell443.IsVisible = false;
            this.xEditGridCell443.Row = -1;
            // 
            // xEditGridCell444
            // 
            this.xEditGridCell444.CellName = "nurse_hold_time";
            this.xEditGridCell444.Col = -1;
            this.xEditGridCell444.ExecuteQuery = null;
            this.xEditGridCell444.HeaderText = "nurse_hold_time";
            this.xEditGridCell444.IsVisible = false;
            this.xEditGridCell444.Row = -1;
            // 
            // xEditGridCell445
            // 
            this.xEditGridCell445.CellName = "reser_date";
            this.xEditGridCell445.Col = -1;
            this.xEditGridCell445.ExecuteQuery = null;
            this.xEditGridCell445.HeaderText = "reser_date";
            this.xEditGridCell445.IsVisible = false;
            this.xEditGridCell445.Row = -1;
            // 
            // xEditGridCell446
            // 
            this.xEditGridCell446.CellName = "reser_time";
            this.xEditGridCell446.Col = -1;
            this.xEditGridCell446.ExecuteQuery = null;
            this.xEditGridCell446.HeaderText = "reser_time";
            this.xEditGridCell446.IsVisible = false;
            this.xEditGridCell446.Row = -1;
            // 
            // xEditGridCell447
            // 
            this.xEditGridCell447.CellName = "jubsu_date";
            this.xEditGridCell447.Col = -1;
            this.xEditGridCell447.ExecuteQuery = null;
            this.xEditGridCell447.HeaderText = "jubsu_date";
            this.xEditGridCell447.IsVisible = false;
            this.xEditGridCell447.Row = -1;
            // 
            // xEditGridCell448
            // 
            this.xEditGridCell448.CellName = "jubsu_time";
            this.xEditGridCell448.Col = -1;
            this.xEditGridCell448.ExecuteQuery = null;
            this.xEditGridCell448.HeaderText = "jubsu_time";
            this.xEditGridCell448.IsVisible = false;
            this.xEditGridCell448.Row = -1;
            // 
            // xEditGridCell449
            // 
            this.xEditGridCell449.CellName = "acting_date";
            this.xEditGridCell449.Col = -1;
            this.xEditGridCell449.ExecuteQuery = null;
            this.xEditGridCell449.HeaderText = "acting_date";
            this.xEditGridCell449.IsVisible = false;
            this.xEditGridCell449.Row = -1;
            // 
            // xEditGridCell450
            // 
            this.xEditGridCell450.CellName = "acting_time";
            this.xEditGridCell450.Col = -1;
            this.xEditGridCell450.ExecuteQuery = null;
            this.xEditGridCell450.HeaderText = "acting_time";
            this.xEditGridCell450.IsVisible = false;
            this.xEditGridCell450.Row = -1;
            // 
            // xEditGridCell451
            // 
            this.xEditGridCell451.CellName = "acting_day";
            this.xEditGridCell451.Col = -1;
            this.xEditGridCell451.ExecuteQuery = null;
            this.xEditGridCell451.HeaderText = "acting_day";
            this.xEditGridCell451.IsVisible = false;
            this.xEditGridCell451.Row = -1;
            // 
            // xEditGridCell452
            // 
            this.xEditGridCell452.CellName = "result_date";
            this.xEditGridCell452.Col = -1;
            this.xEditGridCell452.ExecuteQuery = null;
            this.xEditGridCell452.HeaderText = "result_date";
            this.xEditGridCell452.IsVisible = false;
            this.xEditGridCell452.Row = -1;
            // 
            // xEditGridCell453
            // 
            this.xEditGridCell453.CellName = "dc_gubun";
            this.xEditGridCell453.CellWidth = 35;
            this.xEditGridCell453.Col = 1;
            this.xEditGridCell453.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell453.ExecuteQuery = null;
            this.xEditGridCell453.HeaderText = "返却\r\n指示";
            this.xEditGridCell453.IsReadOnly = true;
            this.xEditGridCell453.RowSpan = 2;
            // 
            // xEditGridCell454
            // 
            this.xEditGridCell454.CellName = "dc_yn";
            this.xEditGridCell454.Col = -1;
            this.xEditGridCell454.ExecuteQuery = null;
            this.xEditGridCell454.HeaderText = "dc_yn";
            this.xEditGridCell454.IsVisible = false;
            this.xEditGridCell454.Row = -1;
            // 
            // xEditGridCell455
            // 
            this.xEditGridCell455.CellName = "bannab_yn";
            this.xEditGridCell455.Col = -1;
            this.xEditGridCell455.ExecuteQuery = null;
            this.xEditGridCell455.HeaderText = "bannab_yn";
            this.xEditGridCell455.IsVisible = false;
            this.xEditGridCell455.Row = -1;
            // 
            // xEditGridCell456
            // 
            this.xEditGridCell456.CellName = "bannab_confirm";
            this.xEditGridCell456.Col = -1;
            this.xEditGridCell456.ExecuteQuery = null;
            this.xEditGridCell456.HeaderText = "bannab_confirm";
            this.xEditGridCell456.IsVisible = false;
            this.xEditGridCell456.Row = -1;
            // 
            // xEditGridCell457
            // 
            this.xEditGridCell457.CellName = "source_ord_key";
            this.xEditGridCell457.Col = -1;
            this.xEditGridCell457.ExecuteQuery = null;
            this.xEditGridCell457.HeaderText = "source_ord_key";
            this.xEditGridCell457.IsVisible = false;
            this.xEditGridCell457.Row = -1;
            // 
            // xEditGridCell458
            // 
            this.xEditGridCell458.CellName = "ocs_flag";
            this.xEditGridCell458.Col = -1;
            this.xEditGridCell458.ExecuteQuery = null;
            this.xEditGridCell458.HeaderText = "ocs_flag";
            this.xEditGridCell458.IsVisible = false;
            this.xEditGridCell458.Row = -1;
            // 
            // xEditGridCell459
            // 
            this.xEditGridCell459.CellName = "sg_code";
            this.xEditGridCell459.Col = -1;
            this.xEditGridCell459.ExecuteQuery = null;
            this.xEditGridCell459.HeaderText = "sg_code";
            this.xEditGridCell459.IsVisible = false;
            this.xEditGridCell459.Row = -1;
            // 
            // xEditGridCell460
            // 
            this.xEditGridCell460.CellName = "sg_ymd";
            this.xEditGridCell460.Col = -1;
            this.xEditGridCell460.ExecuteQuery = null;
            this.xEditGridCell460.HeaderText = "sg_ymd";
            this.xEditGridCell460.IsVisible = false;
            this.xEditGridCell460.Row = -1;
            // 
            // xEditGridCell461
            // 
            this.xEditGridCell461.CellName = "io_gubun";
            this.xEditGridCell461.Col = -1;
            this.xEditGridCell461.ExecuteQuery = null;
            this.xEditGridCell461.HeaderText = "io_gubun";
            this.xEditGridCell461.IsVisible = false;
            this.xEditGridCell461.Row = -1;
            // 
            // xEditGridCell464
            // 
            this.xEditGridCell464.CellName = "after_act_yn";
            this.xEditGridCell464.Col = -1;
            this.xEditGridCell464.ExecuteQuery = null;
            this.xEditGridCell464.HeaderText = "after_act_yn";
            this.xEditGridCell464.IsVisible = false;
            this.xEditGridCell464.Row = -1;
            // 
            // xEditGridCell465
            // 
            this.xEditGridCell465.CellName = "bichi_yn";
            this.xEditGridCell465.CellWidth = 25;
            this.xEditGridCell465.Col = 27;
            this.xEditGridCell465.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell465.ExecuteQuery = null;
            this.xEditGridCell465.HeaderText = "配\r\n置";
            this.xEditGridCell465.RowSpan = 2;
            // 
            // xEditGridCell466
            // 
            this.xEditGridCell466.CellName = "drg_bunho";
            this.xEditGridCell466.Col = -1;
            this.xEditGridCell466.ExecuteQuery = null;
            this.xEditGridCell466.HeaderText = "drg_bunho";
            this.xEditGridCell466.IsVisible = false;
            this.xEditGridCell466.Row = -1;
            // 
            // xEditGridCell467
            // 
            this.xEditGridCell467.CellName = "sub_susul";
            this.xEditGridCell467.Col = -1;
            this.xEditGridCell467.ExecuteQuery = null;
            this.xEditGridCell467.HeaderText = "sub_susul";
            this.xEditGridCell467.IsVisible = false;
            this.xEditGridCell467.Row = -1;
            // 
            // xEditGridCell468
            // 
            this.xEditGridCell468.CellName = "print_yn";
            this.xEditGridCell468.Col = -1;
            this.xEditGridCell468.ExecuteQuery = null;
            this.xEditGridCell468.HeaderText = "print_yn";
            this.xEditGridCell468.IsVisible = false;
            this.xEditGridCell468.Row = -1;
            // 
            // xEditGridCell469
            // 
            this.xEditGridCell469.CellName = "chisik";
            this.xEditGridCell469.Col = -1;
            this.xEditGridCell469.ExecuteQuery = null;
            this.xEditGridCell469.HeaderText = "chisik";
            this.xEditGridCell469.IsVisible = false;
            this.xEditGridCell469.Row = -1;
            // 
            // xEditGridCell470
            // 
            this.xEditGridCell470.CellName = "sanmo_fkinp1001";
            this.xEditGridCell470.Col = -1;
            this.xEditGridCell470.ExecuteQuery = null;
            this.xEditGridCell470.HeaderText = "sanmo_fkinp1001";
            this.xEditGridCell470.IsVisible = false;
            this.xEditGridCell470.Row = -1;
            // 
            // xEditGridCell471
            // 
            this.xEditGridCell471.CellName = "tel_yn";
            this.xEditGridCell471.Col = -1;
            this.xEditGridCell471.ExecuteQuery = null;
            this.xEditGridCell471.HeaderText = "TEL";
            this.xEditGridCell471.IsVisible = false;
            this.xEditGridCell471.Row = -1;
            // 
            // xEditGridCell472
            // 
            this.xEditGridCell472.CellName = "order_gubun_bas";
            this.xEditGridCell472.Col = -1;
            this.xEditGridCell472.ExecuteQuery = null;
            this.xEditGridCell472.HeaderText = "order_gubun_bas";
            this.xEditGridCell472.IsVisible = false;
            this.xEditGridCell472.Row = -1;
            // 
            // xEditGridCell473
            // 
            this.xEditGridCell473.CellName = "input_control";
            this.xEditGridCell473.Col = -1;
            this.xEditGridCell473.ExecuteQuery = null;
            this.xEditGridCell473.HeaderText = "input_control";
            this.xEditGridCell473.IsVisible = false;
            this.xEditGridCell473.Row = -1;
            // 
            // xEditGridCell474
            // 
            this.xEditGridCell474.CellName = "suga_yn";
            this.xEditGridCell474.Col = -1;
            this.xEditGridCell474.ExecuteQuery = null;
            this.xEditGridCell474.HeaderText = "suga_yn";
            this.xEditGridCell474.IsVisible = false;
            this.xEditGridCell474.Row = -1;
            // 
            // xEditGridCell475
            // 
            this.xEditGridCell475.CellName = "jaeryo_yn";
            this.xEditGridCell475.Col = -1;
            this.xEditGridCell475.ExecuteQuery = null;
            this.xEditGridCell475.HeaderText = "jaeryo_yn";
            this.xEditGridCell475.IsVisible = false;
            this.xEditGridCell475.Row = -1;
            // 
            // xEditGridCell476
            // 
            this.xEditGridCell476.CellName = "wonyoi_check";
            this.xEditGridCell476.Col = -1;
            this.xEditGridCell476.ExecuteQuery = null;
            this.xEditGridCell476.HeaderText = "wonyoi_check";
            this.xEditGridCell476.IsVisible = false;
            this.xEditGridCell476.Row = -1;
            // 
            // xEditGridCell477
            // 
            this.xEditGridCell477.CellName = "emergency_check";
            this.xEditGridCell477.Col = -1;
            this.xEditGridCell477.ExecuteQuery = null;
            this.xEditGridCell477.HeaderText = "emergency_check";
            this.xEditGridCell477.IsVisible = false;
            this.xEditGridCell477.Row = -1;
            // 
            // xEditGridCell478
            // 
            this.xEditGridCell478.CellName = "specimen_check";
            this.xEditGridCell478.Col = -1;
            this.xEditGridCell478.ExecuteQuery = null;
            this.xEditGridCell478.HeaderText = "specimen_check";
            this.xEditGridCell478.IsVisible = false;
            this.xEditGridCell478.Row = -1;
            // 
            // xEditGridCell479
            // 
            this.xEditGridCell479.CellName = "portable_check";
            this.xEditGridCell479.Col = -1;
            this.xEditGridCell479.ExecuteQuery = null;
            this.xEditGridCell479.HeaderText = "portable_check";
            this.xEditGridCell479.IsVisible = false;
            this.xEditGridCell479.Row = -1;
            // 
            // xEditGridCell480
            // 
            this.xEditGridCell480.CellName = "bulyong_check";
            this.xEditGridCell480.Col = -1;
            this.xEditGridCell480.ExecuteQuery = null;
            this.xEditGridCell480.HeaderText = "bulyong_check";
            this.xEditGridCell480.IsVisible = false;
            this.xEditGridCell480.Row = -1;
            // 
            // xEditGridCell481
            // 
            this.xEditGridCell481.CellName = "sunab_check";
            this.xEditGridCell481.Col = -1;
            this.xEditGridCell481.ExecuteQuery = null;
            this.xEditGridCell481.HeaderText = "sunab_check";
            this.xEditGridCell481.IsVisible = false;
            this.xEditGridCell481.Row = -1;
            // 
            // xEditGridCell482
            // 
            this.xEditGridCell482.CellName = "dc_check";
            this.xEditGridCell482.Col = -1;
            this.xEditGridCell482.ExecuteQuery = null;
            this.xEditGridCell482.HeaderText = "dc_check";
            this.xEditGridCell482.IsVisible = false;
            this.xEditGridCell482.Row = -1;
            // 
            // xEditGridCell483
            // 
            this.xEditGridCell483.CellName = "dc_gubun_check";
            this.xEditGridCell483.Col = -1;
            this.xEditGridCell483.ExecuteQuery = null;
            this.xEditGridCell483.HeaderText = "dc_gubun_check";
            this.xEditGridCell483.IsVisible = false;
            this.xEditGridCell483.Row = -1;
            // 
            // xEditGridCell484
            // 
            this.xEditGridCell484.CellName = "confirm_check";
            this.xEditGridCell484.Col = -1;
            this.xEditGridCell484.ExecuteQuery = null;
            this.xEditGridCell484.HeaderText = "confirm_check";
            this.xEditGridCell484.IsVisible = false;
            this.xEditGridCell484.Row = -1;
            // 
            // xEditGridCell485
            // 
            this.xEditGridCell485.CellName = "reser_yn_check";
            this.xEditGridCell485.Col = -1;
            this.xEditGridCell485.ExecuteQuery = null;
            this.xEditGridCell485.HeaderText = "reser_yn_out";
            this.xEditGridCell485.IsVisible = false;
            this.xEditGridCell485.Row = -1;
            // 
            // xEditGridCell486
            // 
            this.xEditGridCell486.CellName = "chisik_check";
            this.xEditGridCell486.Col = -1;
            this.xEditGridCell486.ExecuteQuery = null;
            this.xEditGridCell486.HeaderText = "chisik_check";
            this.xEditGridCell486.IsVisible = false;
            this.xEditGridCell486.Row = -1;
            // 
            // xEditGridCell487
            // 
            this.xEditGridCell487.CellName = "nday_yn";
            this.xEditGridCell487.Col = -1;
            this.xEditGridCell487.ExecuteQuery = null;
            this.xEditGridCell487.HeaderText = "nday_yn";
            this.xEditGridCell487.IsVisible = false;
            this.xEditGridCell487.Row = -1;
            // 
            // xEditGridCell488
            // 
            this.xEditGridCell488.CellName = "default_jaeryo_jundal_yn";
            this.xEditGridCell488.Col = -1;
            this.xEditGridCell488.ExecuteQuery = null;
            this.xEditGridCell488.HeaderText = "default_jaeryo_jundal_yn";
            this.xEditGridCell488.IsVisible = false;
            this.xEditGridCell488.Row = -1;
            // 
            // xEditGridCell489
            // 
            this.xEditGridCell489.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell489.Col = -1;
            this.xEditGridCell489.ExecuteQuery = null;
            this.xEditGridCell489.HeaderText = "default_wonyoi_order_yn";
            this.xEditGridCell489.IsVisible = false;
            this.xEditGridCell489.Row = -1;
            // 
            // xEditGridCell490
            // 
            this.xEditGridCell490.CellName = "specific_comments";
            this.xEditGridCell490.Col = -1;
            this.xEditGridCell490.ExecuteQuery = null;
            this.xEditGridCell490.HeaderText = "specific_comments";
            this.xEditGridCell490.IsVisible = false;
            this.xEditGridCell490.Row = -1;
            // 
            // xEditGridCell491
            // 
            this.xEditGridCell491.CellName = "specific_comment_name";
            this.xEditGridCell491.Col = -1;
            this.xEditGridCell491.ExecuteQuery = null;
            this.xEditGridCell491.HeaderText = "specific_comment_name";
            this.xEditGridCell491.IsVisible = false;
            this.xEditGridCell491.Row = -1;
            // 
            // xEditGridCell492
            // 
            this.xEditGridCell492.CellName = "specific_comment_sys_id";
            this.xEditGridCell492.Col = -1;
            this.xEditGridCell492.ExecuteQuery = null;
            this.xEditGridCell492.HeaderText = "specific_comment_sys_id";
            this.xEditGridCell492.IsVisible = false;
            this.xEditGridCell492.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "specific_comment_pgm_id";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderText = "specific_comment_pgm_id";
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "specific_comment_not_null";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderText = "specific_comment_not_null";
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "specific_comment_table_id";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderText = "specific_comment_table_id";
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "specific_comment_col_id";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderText = "specific_comment_col_id";
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "donbog_yn";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderText = "donbog_yn";
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "order_gubun_bas_name";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderText = "order_gubun_bas_name";
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "act_doctor";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderText = "act_doctor";
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "act_buseo";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderText = "act_buseo";
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "act_gwa";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderText = "act_gwa";
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "home_care_yn";
            this.xEditGridCell48.CellWidth = 29;
            this.xEditGridCell48.Col = 35;
            this.xEditGridCell48.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderText = "在\r\n宅";
            this.xEditGridCell48.RowSpan = 2;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "regular_yn";
            this.xEditGridCell49.CellWidth = 24;
            this.xEditGridCell49.Col = 4;
            this.xEditGridCell49.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderText = "定\r\n時";
            this.xEditGridCell49.RowSpan = 2;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "sort_fkocskey";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderText = "sort_fkocskey";
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "jubsu_no";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "ref_fkocs2003";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderText = "ref_fkocs2003";
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "jaewonil";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderText = "jaewonil";
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "app_yn";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderText = "app_yn";
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "order_end_yn";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderText = "order_end_yn";
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "nday_occur_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderText = "nday_occur_yn";
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "bun_code";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderText = "bun_code";
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "cp_code";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            this.xEditGridCell62.HeaderText = "cp_code";
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "cp_path_code";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            this.xEditGridCell63.HeaderText = "cp_path_code";
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "memb_gubun";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            this.xEditGridCell64.HeaderText = "memb_gubun";
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "wonnae_drg_yn";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            this.xEditGridCell73.HeaderText = "wonnae_drg_yn";
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "hubal_change_check";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            this.xEditGridCell75.HeaderText = "hubal_change_check";
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "drg_pack_check";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            this.xEditGridCell76.HeaderText = "drg_pack_check";
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "pharmacy_check";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            this.xEditGridCell77.HeaderText = "pharmacy_check";
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "powder_check";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            this.xEditGridCell78.HeaderText = "powder_check";
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "imsi_drug_yn";
            this.xEditGridCell79.CellWidth = 24;
            this.xEditGridCell79.Col = 5;
            this.xEditGridCell79.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell79.ExecuteQuery = null;
            this.xEditGridCell79.HeaderText = "臨\r\n時";
            this.xEditGridCell79.RowSpan = 2;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "jundal_table_out";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "jundal_part_out";
            this.xEditGridCell86.CellWidth = 60;
            this.xEditGridCell86.Col = 32;
            this.xEditGridCell86.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.HeaderText = "外来\r\n行為部署";
            this.xEditGridCell86.RowSpan = 2;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "jundal_table_inp";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "jundal_part_inp";
            this.xEditGridCell88.CellWidth = 60;
            this.xEditGridCell88.Col = 33;
            this.xEditGridCell88.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell88.ExecuteQuery = null;
            this.xEditGridCell88.HeaderText = "入院\r\n行為部署";
            this.xEditGridCell88.RowSpan = 2;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "move_part_out";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "move_part_inp";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "limit_nalsu";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.ExecuteQuery = null;
            this.xEditGridCell94.HeaderText = "制限日数";
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellLen = 1;
            this.xEditGridCell95.CellName = "general_disp_yn";
            this.xEditGridCell95.CellWidth = 45;
            this.xEditGridCell95.Col = 10;
            this.xEditGridCell95.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell95.ExecuteQuery = null;
            this.xEditGridCell95.HeaderText = "一般名\n  表示";
            this.xEditGridCell95.RowSpan = 2;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "dv_5";
            this.xEditGridCell100.CellWidth = 30;
            this.xEditGridCell100.Col = 21;
            this.xEditGridCell100.ExecuteQuery = null;
            this.xEditGridCell100.HeaderText = "dv_5";
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.Row = 1;
            this.xEditGridCell100.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "dv_6";
            this.xEditGridCell101.CellWidth = 30;
            this.xEditGridCell101.Col = 22;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.HeaderText = "dv_6";
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.Row = 1;
            this.xEditGridCell101.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "dv_7";
            this.xEditGridCell102.CellWidth = 30;
            this.xEditGridCell102.Col = 23;
            this.xEditGridCell102.ExecuteQuery = null;
            this.xEditGridCell102.HeaderText = "dv_7";
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.Row = 1;
            this.xEditGridCell102.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "dv_8";
            this.xEditGridCell103.CellWidth = 30;
            this.xEditGridCell103.Col = 24;
            this.xEditGridCell103.ExecuteQuery = null;
            this.xEditGridCell103.HeaderText = "dv_8";
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.Row = 1;
            this.xEditGridCell103.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "bogyong_code_sub";
            this.xEditGridCell104.CellWidth = 35;
            this.xEditGridCell104.Col = 36;
            this.xEditGridCell104.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell104.ExecuteQuery = null;
            this.xEditGridCell104.HeaderText = "部位\r\nコード";
            this.xEditGridCell104.RowSpan = 2;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "bogyong_name_sub";
            this.xEditGridCell105.Col = 37;
            this.xEditGridCell105.ExecuteQuery = null;
            this.xEditGridCell105.HeaderText = "部位名称";
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.RowSpan = 2;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "limit_suryang";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.ExecuteQuery = null;
            this.xEditGridCell106.HeaderText = "limit_suryang";
            this.xEditGridCell106.IsReadOnly = true;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "pkocs1024";
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            this.xEditGridCell107.HeaderText = "pkocs1024";
            this.xEditGridCell107.IsReadOnly = true;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "brought_drg_yn";
            this.xEditGridCell108.CellWidth = 25;
            this.xEditGridCell108.Col = 38;
            this.xEditGridCell108.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell108.ExecuteQuery = null;
            this.xEditGridCell108.HeaderText = "持\r\n参";
            this.xEditGridCell108.RowSpan = 2;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "jundal_part_name";
            this.xEditGridCell119.CellWidth = 43;
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.ExecuteQuery = null;
            this.xEditGridCell119.HeaderText = "部署名";
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "instead_yn";
            this.xEditGridCell121.CellWidth = 25;
            this.xEditGridCell121.Col = 39;
            this.xEditGridCell121.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell121.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell121.ExecuteQuery = null;
            this.xEditGridCell121.HeaderText = "代";
            this.xEditGridCell121.IsReadOnly = true;
            this.xEditGridCell121.RowSpan = 2;
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "代";
            this.xComboItem3.ValueItem = "Y";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "-";
            this.xComboItem4.ValueItem = "N";
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "approve_yn";
            this.xEditGridCell122.CellWidth = 25;
            this.xEditGridCell122.Col = 40;
            this.xEditGridCell122.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6});
            this.xEditGridCell122.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell122.ExecuteQuery = null;
            this.xEditGridCell122.HeaderText = "承";
            this.xEditGridCell122.IsReadOnly = true;
            this.xEditGridCell122.RowSpan = 2;
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "承";
            this.xComboItem5.ValueItem = "Y";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "-";
            this.xComboItem6.ValueItem = "N";
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "postapprove_yn";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.ExecuteQuery = null;
            this.xEditGridCell123.IsReadOnly = true;
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 15;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 18;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 17;
            this.xGridHeader2.ColSpan = 8;
            this.xGridHeader2.HeaderText = "不均等分割";
            this.xGridHeader2.HeaderWidth = 38;
            // 
            // tabGroup
            // 
            this.tabGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabGroup.IDEPixelArea = true;
            this.tabGroup.IDEPixelBorder = false;
            this.tabGroup.Location = new System.Drawing.Point(0, 0);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Size = new System.Drawing.Size(572, 29);
            this.tabGroup.TabIndex = 118;
            this.tabGroup.ClosePressed += new System.EventHandler(this.tabGroup_ClosePressed);
            this.tabGroup.SelectionChanging += new System.EventHandler(this.tabGroup_SelectionChanging);
            this.tabGroup.SelectionChanged += new System.EventHandler(this.tabGroup_SelectionChanged);
            // 
            // pnlOrderDetail
            // 
            this.pnlOrderDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlOrderDetail.BackgroundImage")));
            this.pnlOrderDetail.Controls.Add(this.pbxIsBgtDrg);
            this.pnlOrderDetail.Controls.Add(this.btnBroughtDrg);
            this.pnlOrderDetail.Controls.Add(this.btnNalsu);
            this.pnlOrderDetail.Controls.Add(this.btnJungsiDrug);
            this.pnlOrderDetail.Controls.Add(this.btnSetOrder);
            this.pnlOrderDetail.Controls.Add(this.btnDoOrder);
            this.pnlOrderDetail.Controls.Add(this.btnExtend);
            this.pnlOrderDetail.Controls.Add(this.dbxBogyongName);
            this.pnlOrderDetail.Controls.Add(this.fbxBogyongCode);
            this.pnlOrderDetail.Controls.Add(this.xLabel8);
            this.pnlOrderDetail.Controls.Add(this.cboNalsu);
            this.pnlOrderDetail.Controls.Add(this.lblNalsu);
            this.pnlOrderDetail.Controls.Add(this.lblInOut);
            this.pnlOrderDetail.Controls.Add(this.cbxEmergency);
            this.pnlOrderDetail.Controls.Add(this.xLabel3);
            this.pnlOrderDetail.Controls.Add(this.cbxWonyoiOrderYN);
            this.pnlOrderDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOrderDetail.DrawBorder = true;
            this.pnlOrderDetail.Location = new System.Drawing.Point(0, 2);
            this.pnlOrderDetail.Name = "pnlOrderDetail";
            this.pnlOrderDetail.Padding = new System.Windows.Forms.Padding(3);
            this.pnlOrderDetail.Size = new System.Drawing.Size(572, 66);
            this.pnlOrderDetail.TabIndex = 17;
            // 
            // pbxIsBgtDrg
            // 
            this.pbxIsBgtDrg.Image = ((System.Drawing.Image)(resources.GetObject("pbxIsBgtDrg.Image")));
            this.pbxIsBgtDrg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbxIsBgtDrg.Location = new System.Drawing.Point(385, 7);
            this.pbxIsBgtDrg.Name = "pbxIsBgtDrg";
            this.pbxIsBgtDrg.Size = new System.Drawing.Size(16, 17);
            this.pbxIsBgtDrg.TabIndex = 104;
            this.pbxIsBgtDrg.TabStop = false;
            this.pbxIsBgtDrg.Visible = false;
            // 
            // btnBroughtDrg
            // 
            this.btnBroughtDrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBroughtDrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBroughtDrg.ImageIndex = 7;
            this.btnBroughtDrg.Location = new System.Drawing.Point(385, 2);
            this.btnBroughtDrg.Name = "btnBroughtDrg";
            this.btnBroughtDrg.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnBroughtDrg.Size = new System.Drawing.Size(63, 27);
            this.btnBroughtDrg.TabIndex = 99;
            this.btnBroughtDrg.Text = "持参薬";
            this.btnBroughtDrg.Click += new System.EventHandler(this.btnBroughtDrg_Click);
            // 
            // btnNalsu
            // 
            this.btnNalsu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNalsu.Image = ((System.Drawing.Image)(resources.GetObject("btnNalsu.Image")));
            this.btnNalsu.Location = new System.Drawing.Point(152, 28);
            this.btnNalsu.Name = "btnNalsu";
            this.btnNalsu.Size = new System.Drawing.Size(96, 27);
            this.btnNalsu.TabIndex = 98;
            this.btnNalsu.Text = "日数選択";
            this.btnNalsu.Visible = false;
            this.btnNalsu.Click += new System.EventHandler(this.btnNalsu_Click);
            // 
            // btnJungsiDrug
            // 
            this.btnJungsiDrug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJungsiDrug.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnJungsiDrug.ImageIndex = 7;
            this.btnJungsiDrug.Location = new System.Drawing.Point(385, 30);
            this.btnJungsiDrug.Name = "btnJungsiDrug";
            this.btnJungsiDrug.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnJungsiDrug.Size = new System.Drawing.Size(63, 27);
            this.btnJungsiDrug.TabIndex = 97;
            this.btnJungsiDrug.Text = "定時薬";
            this.btnJungsiDrug.Click += new System.EventHandler(this.btnJungsiDrug_Click);
            // 
            // btnSetOrder
            // 
            this.btnSetOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSetOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnSetOrder.Image")));
            this.btnSetOrder.Location = new System.Drawing.Point(454, 30);
            this.btnSetOrder.Name = "btnSetOrder";
            this.btnSetOrder.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnSetOrder.Size = new System.Drawing.Size(82, 27);
            this.btnSetOrder.TabIndex = 96;
            this.btnSetOrder.Text = "セットオーダ";
            this.btnSetOrder.Click += new System.EventHandler(this.btnSetOrder_Click);
            // 
            // btnDoOrder
            // 
            this.btnDoOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDoOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDoOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnDoOrder.Image")));
            this.btnDoOrder.Location = new System.Drawing.Point(454, 2);
            this.btnDoOrder.Name = "btnDoOrder";
            this.btnDoOrder.Size = new System.Drawing.Size(82, 27);
            this.btnDoOrder.TabIndex = 95;
            this.btnDoOrder.Text = "Doオーダ";
            this.btnDoOrder.Click += new System.EventHandler(this.btnDoOrder_Click);
            // 
            // btnExtend
            // 
            this.btnExtend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExtend.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExtend.ImageIndex = 3;
            this.btnExtend.Location = new System.Drawing.Point(542, 3);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(25, 58);
            this.btnExtend.TabIndex = 92;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // dbxBogyongName
            // 
            this.dbxBogyongName.AllowDrop = true;
            this.dbxBogyongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dbxBogyongName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dbxBogyongName.Location = new System.Drawing.Point(152, 7);
            this.dbxBogyongName.Name = "dbxBogyongName";
            this.dbxBogyongName.Size = new System.Drawing.Size(96, 20);
            this.dbxBogyongName.TabIndex = 91;
            this.dbxBogyongName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxBogyongCode
            // 
            this.fbxBogyongCode.AutoTabDataSelected = true;
            this.fbxBogyongCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fbxBogyongCode.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fbxBogyongCode.Location = new System.Drawing.Point(79, 6);
            this.fbxBogyongCode.MaxLength = 10;
            this.fbxBogyongCode.Name = "fbxBogyongCode";
            this.fbxBogyongCode.Size = new System.Drawing.Size(67, 20);
            this.fbxBogyongCode.TabIndex = 90;
            this.fbxBogyongCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxBogyongCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBogyongCode_FindClick);
            this.fbxBogyongCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBogyongCode_DataValidating);
            // 
            // xLabel8
            // 
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.xLabel8.Location = new System.Drawing.Point(7, 6);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(68, 19);
            this.xLabel8.TabIndex = 89;
            this.xLabel8.Text = "服用コード";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel8.Click += new System.EventHandler(this.xLabel8_Click);
            // 
            // cboNalsu
            // 
            this.cboNalsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboNalsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cboNalsu.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.cboNalsu.Location = new System.Drawing.Point(311, 8);
            this.cboNalsu.MaxDropDownItems = 12;
            this.cboNalsu.Name = "cboNalsu";
            this.cboNalsu.Size = new System.Drawing.Size(67, 21);
            this.cboNalsu.TabIndex = 87;
            // 
            // lblNalsu
            // 
            this.lblNalsu.EdgeRounding = false;
            this.lblNalsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNalsu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNalsu.Location = new System.Drawing.Point(259, 8);
            this.lblNalsu.Name = "lblNalsu";
            this.lblNalsu.Size = new System.Drawing.Size(46, 19);
            this.lblNalsu.TabIndex = 88;
            this.lblNalsu.Text = "日数";
            this.lblNalsu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInOut
            // 
            this.lblInOut.BackColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lblInOut.EdgeRounding = false;
            this.lblInOut.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblInOut.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.lblInOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblInOut.Location = new System.Drawing.Point(259, 35);
            this.lblInOut.Name = "lblInOut";
            this.lblInOut.Size = new System.Drawing.Size(46, 19);
            this.lblInOut.TabIndex = 80;
            this.lblInOut.Text = "院外";
            this.lblInOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxEmergency
            // 
            this.cbxEmergency.AutoSize = true;
            this.cbxEmergency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cbxEmergency.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxEmergency.Location = new System.Drawing.Point(81, 39);
            this.cbxEmergency.Name = "cbxEmergency";
            this.cbxEmergency.Size = new System.Drawing.Size(12, 11);
            this.cbxEmergency.TabIndex = 79;
            this.cbxEmergency.UseVisualStyleBackColor = false;
            this.cbxEmergency.CheckedChanged += new System.EventHandler(this.cbxEmergency_CheckedChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.xLabel3.Location = new System.Drawing.Point(7, 34);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(68, 19);
            this.xLabel3.TabIndex = 78;
            this.xLabel3.Text = "緊急";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxWonyoiOrderYN
            // 
            this.cbxWonyoiOrderYN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cbxWonyoiOrderYN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxWonyoiOrderYN.Location = new System.Drawing.Point(311, 41);
            this.cbxWonyoiOrderYN.Name = "cbxWonyoiOrderYN";
            this.cbxWonyoiOrderYN.Size = new System.Drawing.Size(12, 11);
            this.cbxWonyoiOrderYN.TabIndex = 70;
            this.cbxWonyoiOrderYN.UseVisualStyleBackColor = false;
            this.cbxWonyoiOrderYN.CheckedChanged += new System.EventHandler(this.cbxWonyoiOrderYN_CheckedChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.rbtSyouhin);
            this.splitContainer3.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer3.Panel1.Controls.Add(this.xLabel5);
            this.splitContainer3.Panel1.Controls.Add(this.rbtGenericSearch);
            this.splitContainer3.Panel1.Controls.Add(this.cboSearchCondition);
            this.splitContainer3.Panel1.Controls.Add(this.cboQueryCon);
            this.splitContainer3.Panel1.Controls.Add(this.xLabel1);
            this.splitContainer3.Panel1.Controls.Add(this.btnExpandSearch);
            this.splitContainer3.Panel1.Controls.Add(this.rbnOftenOrder);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(361, 373);
            this.splitContainer3.SplitterDistance = 84;
            this.splitContainer3.TabIndex = 0;
            // 
            // rbtSyouhin
            // 
            this.rbtSyouhin.AutoSize = true;
            this.rbtSyouhin.Checked = true;
            this.rbtSyouhin.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.rbtSyouhin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtSyouhin.Location = new System.Drawing.Point(189, 63);
            this.rbtSyouhin.Name = "rbtSyouhin";
            this.rbtSyouhin.Size = new System.Drawing.Size(82, 16);
            this.rbtSyouhin.TabIndex = 152;
            this.rbtSyouhin.TabStop = true;
            this.rbtSyouhin.Text = "商品名検索";
            this.rbtSyouhin.UseVisualStyleBackColor = true;
            this.rbtSyouhin.CheckedChanged += new System.EventHandler(this.rbtSyouhin_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.EnterKeyToTab = false;
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtSearch.Location = new System.Drawing.Point(64, 59);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(112, 20);
            this.txtSearch.TabIndex = 151;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // xLabel5
            // 
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.xLabel5.Location = new System.Drawing.Point(7, 59);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(51, 20);
            this.xLabel5.TabIndex = 150;
            this.xLabel5.Text = "検索語";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtGenericSearch
            // 
            this.rbtGenericSearch.AutoSize = true;
            this.rbtGenericSearch.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.rbtGenericSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtGenericSearch.Location = new System.Drawing.Point(276, 63);
            this.rbtGenericSearch.Name = "rbtGenericSearch";
            this.rbtGenericSearch.Size = new System.Drawing.Size(82, 16);
            this.rbtGenericSearch.TabIndex = 153;
            this.rbtGenericSearch.Text = "一般名検索";
            this.rbtGenericSearch.UseVisualStyleBackColor = true;
            // 
            // cboSearchCondition
            // 
            this.cboSearchCondition.ExecuteQuery = null;
            this.cboSearchCondition.Location = new System.Drawing.Point(186, 33);
            this.cboSearchCondition.Name = "cboSearchCondition";
            this.cboSearchCondition.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSearchCondition.ParamList")));
            this.cboSearchCondition.Size = new System.Drawing.Size(165, 21);
            this.cboSearchCondition.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSearchCondition.TabIndex = 149;
            this.cboSearchCondition.SelectedValueChanged += new System.EventHandler(this.cboSearchCondition_SelectedValueChanged);
            // 
            // cboQueryCon
            // 
            this.cboQueryCon.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboQueryCon.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.cboQueryCon.Location = new System.Drawing.Point(60, 33);
            this.cboQueryCon.Name = "cboQueryCon";
            this.cboQueryCon.Size = new System.Drawing.Size(116, 20);
            this.cboQueryCon.TabIndex = 148;
            this.cboQueryCon.SelectedValueChanged += new System.EventHandler(this.cboQueryCon_SelectedValueChanged);
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "全体";
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "院内採用薬";
            this.xComboItem2.ValueItem = "Y";
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.xLabel1.Location = new System.Drawing.Point(6, 33);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(51, 26);
            this.xLabel1.TabIndex = 147;
            this.xLabel1.Text = "院内採用";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExpandSearch
            // 
            this.btnExpandSearch.Location = new System.Drawing.Point(8, 4);
            this.btnExpandSearch.Name = "btnExpandSearch";
            this.btnExpandSearch.Size = new System.Drawing.Size(27, 27);
            this.btnExpandSearch.TabIndex = 146;
            this.btnExpandSearch.Click += new System.EventHandler(this.btnExpandSearch_Click);
            // 
            // rbnOftenOrder
            // 
            this.rbnOftenOrder.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnOftenOrder.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnOftenOrder.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
            this.rbnOftenOrder.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnOftenOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnOftenOrder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbnOftenOrder.Location = new System.Drawing.Point(41, 4);
            this.rbnOftenOrder.Name = "rbnOftenOrder";
            this.rbnOftenOrder.Size = new System.Drawing.Size(310, 25);
            this.rbnOftenOrder.TabIndex = 144;
            this.rbnOftenOrder.TabStop = true;
            this.rbnOftenOrder.Text = "常用オーダ";
            this.rbnOftenOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnOftenOrder.UseVisualStyleBackColor = false;
            this.rbnOftenOrder.CheckedChanged += new System.EventHandler(this.OrderRadio_CheckedChanged);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.grdSangyongOrder);
            this.splitContainer4.Panel1.Controls.Add(this.tabSangyongOrder);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.pnlRightBottom);
            this.splitContainer4.Size = new System.Drawing.Size(361, 285);
            this.splitContainer4.SplitterDistance = 244;
            this.splitContainer4.TabIndex = 0;
            // 
            // grdSangyongOrder
            // 
            this.grdSangyongOrder.ApplyPaintEventToAllColumn = true;
            this.grdSangyongOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell83,
            this.xEditGridCell126});
            this.grdSangyongOrder.ColPerLine = 2;
            this.grdSangyongOrder.Cols = 3;
            this.grdSangyongOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSangyongOrder.ExecuteQuery = null;
            this.grdSangyongOrder.FixedCols = 1;
            this.grdSangyongOrder.FixedRows = 1;
            this.grdSangyongOrder.HeaderHeights.Add(28);
            this.grdSangyongOrder.Location = new System.Drawing.Point(0, 34);
            this.grdSangyongOrder.Name = "grdSangyongOrder";
            this.grdSangyongOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSangyongOrder.ParamList")));
            this.grdSangyongOrder.QuerySQL = resources.GetString("grdSangyongOrder.QuerySQL");
            this.grdSangyongOrder.RowHeaderVisible = true;
            this.grdSangyongOrder.Rows = 2;
            this.grdSangyongOrder.Size = new System.Drawing.Size(361, 210);
            this.grdSangyongOrder.TabIndex = 133;
            this.grdSangyongOrder.ToolTipActive = true;
            this.grdSangyongOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSangyongOrder_GridCellPainting);
            this.grdSangyongOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSangyongOrder_QueryStarting);
            this.grdSangyongOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdSangyongOrder_DragEnter);
            this.grdSangyongOrder.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdSangyongOrder_GiveFeedback);
            this.grdSangyongOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdSangyongOrder_MouseDown);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "slip_code";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "slip_name";
            this.xEditGridCell19.CellWidth = 62;
            this.xEditGridCell19.Col = 1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderText = "区分";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.SuppressRepeating = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.IsNotNull = true;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 319;
            this.xEditGridCell21.Col = 2;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderText = "オーダ名";
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "seq";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "hosp_code";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "memb";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "memb_gubun";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "wonnae_drg_yn";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "trial_flg";
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            // 
            // tabSangyongOrder
            // 
            this.tabSangyongOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabSangyongOrder.IDEPixelArea = true;
            this.tabSangyongOrder.IDEPixelBorder = false;
            this.tabSangyongOrder.Location = new System.Drawing.Point(0, 0);
            this.tabSangyongOrder.Name = "tabSangyongOrder";
            this.tabSangyongOrder.Size = new System.Drawing.Size(361, 34);
            this.tabSangyongOrder.TabIndex = 132;
            // 
            // pnlRightBottom
            // 
            this.pnlRightBottom.Controls.Add(this.cboInputGubun);
            this.pnlRightBottom.Controls.Add(this.btnSelect);
            this.pnlRightBottom.Controls.Add(this.btnNewSelect);
            this.pnlRightBottom.Controls.Add(this.lblInputGubun);
            this.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightBottom.Location = new System.Drawing.Point(0, 0);
            this.pnlRightBottom.Name = "pnlRightBottom";
            this.pnlRightBottom.Size = new System.Drawing.Size(361, 37);
            this.pnlRightBottom.TabIndex = 2;
            // 
            // cboInputGubun
            // 
            this.cboInputGubun.BackColor = IHIS.Framework.XColor.XCalendarSelectedDateBackColor;
            this.cboInputGubun.ExecuteQuery = null;
            this.cboInputGubun.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboInputGubun.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.cboInputGubun.Location = new System.Drawing.Point(50, 6);
            this.cboInputGubun.Name = "cboInputGubun";
            this.cboInputGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboInputGubun.ParamList")));
            this.cboInputGubun.Size = new System.Drawing.Size(89, 27);
            this.cboInputGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboInputGubun.TabIndex = 104;
            this.cboInputGubun.UserSQL = resources.GetString("cboInputGubun.UserSQL");
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelect.ImageIndex = 10;
            this.btnSelect.Location = new System.Drawing.Point(284, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(74, 29);
            this.btnSelect.TabIndex = 96;
            this.btnSelect.Text = "追 加";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnNewSelect
            // 
            this.btnNewSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNewSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnNewSelect.Image")));
            this.btnNewSelect.Location = new System.Drawing.Point(145, 5);
            this.btnNewSelect.Name = "btnNewSelect";
            this.btnNewSelect.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnNewSelect.Size = new System.Drawing.Size(133, 29);
            this.btnNewSelect.TabIndex = 95;
            this.btnNewSelect.Text = "新規グループで追加";
            this.btnNewSelect.Click += new System.EventHandler(this.btnNewSelect_Click);
            // 
            // lblInputGubun
            // 
            this.lblInputGubun.BackColor = IHIS.Framework.XColor.XCalendarFullHolidayTextColor;
            this.lblInputGubun.EdgeRounding = false;
            this.lblInputGubun.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblInputGubun.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblInputGubun.Location = new System.Drawing.Point(3, 6);
            this.lblInputGubun.Name = "lblInputGubun";
            this.lblInputGubun.Size = new System.Drawing.Size(46, 27);
            this.lblInputGubun.TabIndex = 78;
            this.lblInputGubun.Text = "処方";
            this.lblInputGubun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
            // imageListPopupMenu
            // 
            this.imageListPopupMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPopupMenu.ImageStream")));
            this.imageListPopupMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPopupMenu.Images.SetKeyName(0, "YESUP1.ICO");
            this.imageListPopupMenu.Images.SetKeyName(1, "YESEN1.ICO");
            this.imageListPopupMenu.Images.SetKeyName(2, "복사.gif");
            this.imageListPopupMenu.Images.SetKeyName(3, "붙여넣기.gif");
            this.imageListPopupMenu.Images.SetKeyName(4, "삭제.gif");
            this.imageListPopupMenu.Images.SetKeyName(5, "+.gif");
            this.imageListPopupMenu.Images.SetKeyName(6, "_.gif");
            this.imageListPopupMenu.Images.SetKeyName(7, "행추가.gif");
            // 
            // imageListInfo
            // 
            this.imageListInfo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListInfo.ImageStream")));
            this.imageListInfo.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListInfo.Images.SetKeyName(0, "");
            this.imageListInfo.Images.SetKeyName(1, "");
            this.imageListInfo.Images.SetKeyName(2, "");
            this.imageListInfo.Images.SetKeyName(3, "");
            this.imageListInfo.Images.SetKeyName(4, "닫힌폴더.gif");
            this.imageListInfo.Images.SetKeyName(5, "열린폴더.gif");
            this.imageListInfo.Images.SetKeyName(6, "뒤로.gif");
            this.imageListInfo.Images.SetKeyName(7, "앞으로.gif");
            this.imageListInfo.Images.SetKeyName(8, "신규.gif");
            // 
            // layGroupTab
            // 
            this.layGroupTab.ExecuteQuery = null;
            this.layGroupTab.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layGroupTab.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGroupTab.ParamList")));
            this.layGroupTab.QuerySQL = resources.GetString("layGroupTab.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pk_in_out_key";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "order_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "group_ser";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "bogyong_code";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "bogyong_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "nalsu";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "emergency";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "wonyoi_order_yn";
            // 
            // layDrugTree
            // 
            this.layDrugTree.ExecuteQuery = null;
            this.layDrugTree.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12});
            this.layDrugTree.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDrugTree.ParamList")));
            this.layDrugTree.QuerySQL = resources.GetString("layDrugTree.QuerySQL");
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "code";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "code_name";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "code1";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "code_name1";
            // 
            // layPreview
            // 
            this.layPreview.ExecuteQuery = null;
            this.layPreview.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem34,
            this.multiLayoutItem35});
            this.layPreview.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPreview.ParamList")));
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "group_ser";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "order_gubun";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "hangmog_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "suryang";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "hoisu";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "dc_gubun";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "nalsu";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "order_data_yn";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "row_num";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "danui";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "donbog_yn";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "hoisu_name";
            // 
            // laySaveLayout
            // 
            this.laySaveLayout.CallerID = '3';
            this.laySaveLayout.ExecuteQuery = null;
            this.laySaveLayout.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
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
            this.multiLayoutItem311,
            this.multiLayoutItem312,
            this.multiLayoutItem313,
            this.multiLayoutItem314,
            this.multiLayoutItem315,
            this.multiLayoutItem316,
            this.multiLayoutItem317,
            this.multiLayoutItem318,
            this.multiLayoutItem319,
            this.multiLayoutItem320,
            this.multiLayoutItem321,
            this.multiLayoutItem322,
            this.multiLayoutItem323,
            this.multiLayoutItem324});
            this.laySaveLayout.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySaveLayout.ParamList")));
            this.laySaveLayout.UseDefaultTransaction = false;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "in_out_key";
            this.multiLayoutItem21.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem21.IsUpdItem = true;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "pkocskey";
            this.multiLayoutItem22.IsUpdItem = true;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "bunho";
            this.multiLayoutItem23.IsUpdItem = true;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "order_date";
            this.multiLayoutItem24.IsUpdItem = true;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "gwa";
            this.multiLayoutItem25.IsUpdItem = true;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "doctor";
            this.multiLayoutItem26.IsUpdItem = true;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "resident";
            this.multiLayoutItem27.IsUpdItem = true;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "naewon_type";
            this.multiLayoutItem28.IsUpdItem = true;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "jubsu_no";
            this.multiLayoutItem29.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem29.IsUpdItem = true;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "input_id";
            this.multiLayoutItem32.IsUpdItem = true;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "input_part";
            this.multiLayoutItem33.IsUpdItem = true;
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "input_gwa";
            this.multiLayoutItem36.IsUpdItem = true;
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "input_doctor";
            this.multiLayoutItem37.IsUpdItem = true;
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "input_gubun";
            this.multiLayoutItem38.IsUpdItem = true;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "input_gubun_name";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "group_ser";
            this.multiLayoutItem40.IsUpdItem = true;
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "input_tab";
            this.multiLayoutItem41.IsUpdItem = true;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "input_tab_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "order_gubun";
            this.multiLayoutItem43.IsUpdItem = true;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "order_gubun_name";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "group_yn";
            this.multiLayoutItem45.IsUpdItem = true;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "seq";
            this.multiLayoutItem46.IsUpdItem = true;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "slip_code";
            this.multiLayoutItem47.IsUpdItem = true;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "hangmog_code";
            this.multiLayoutItem48.IsUpdItem = true;
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "hangmog_name";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "specimen_code";
            this.multiLayoutItem50.IsUpdItem = true;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "specimen_name";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "suryang";
            this.multiLayoutItem52.IsUpdItem = true;
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "sunab_suryang";
            this.multiLayoutItem53.IsUpdItem = true;
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "subul_suryang";
            this.multiLayoutItem54.IsUpdItem = true;
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "ord_danui";
            this.multiLayoutItem55.IsUpdItem = true;
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "ord_danui_name";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "dv_time";
            this.multiLayoutItem57.IsUpdItem = true;
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "dv";
            this.multiLayoutItem58.IsUpdItem = true;
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "dv_1";
            this.multiLayoutItem59.IsUpdItem = true;
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "dv_2";
            this.multiLayoutItem60.IsUpdItem = true;
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "dv_3";
            this.multiLayoutItem61.IsUpdItem = true;
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "dv_4";
            this.multiLayoutItem62.IsUpdItem = true;
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "nalsu";
            this.multiLayoutItem63.IsUpdItem = true;
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "sunab_nalsu";
            this.multiLayoutItem64.IsUpdItem = true;
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "jusa";
            this.multiLayoutItem65.IsUpdItem = true;
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "jusa_name";
            this.multiLayoutItem66.IsUpdItem = true;
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "jusa_spd_gubun";
            this.multiLayoutItem67.IsUpdItem = true;
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "bogyong_code";
            this.multiLayoutItem68.IsUpdItem = true;
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "bogyong_name";
            this.multiLayoutItem69.IsUpdItem = true;
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "emergency";
            this.multiLayoutItem70.IsUpdItem = true;
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem71.IsUpdItem = true;
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "jundal_table";
            this.multiLayoutItem72.IsUpdItem = true;
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "jundal_part";
            this.multiLayoutItem73.IsUpdItem = true;
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "move_part";
            this.multiLayoutItem74.IsUpdItem = true;
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "portable_yn";
            this.multiLayoutItem75.IsUpdItem = true;
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "powder_yn";
            this.multiLayoutItem76.IsUpdItem = true;
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "hubal_change_yn";
            this.multiLayoutItem77.IsUpdItem = true;
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "pharmacy";
            this.multiLayoutItem78.IsUpdItem = true;
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "drg_pack_yn";
            this.multiLayoutItem79.IsUpdItem = true;
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "muhyo";
            this.multiLayoutItem80.IsUpdItem = true;
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "prn_yn";
            this.multiLayoutItem81.IsUpdItem = true;
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "toiwon_drg_yn";
            this.multiLayoutItem82.IsUpdItem = true;
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "prn_nurse";
            this.multiLayoutItem83.IsUpdItem = true;
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "append_yn";
            this.multiLayoutItem84.IsUpdItem = true;
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "order_remark";
            this.multiLayoutItem85.IsUpdItem = true;
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "nurse_remark";
            this.multiLayoutItem86.IsUpdItem = true;
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "comment";
            this.multiLayoutItem87.IsUpdItem = true;
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "mix_group";
            this.multiLayoutItem88.IsUpdItem = true;
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "amt";
            this.multiLayoutItem89.IsUpdItem = true;
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "pay";
            this.multiLayoutItem90.IsUpdItem = true;
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "wonyoi_order_yn";
            this.multiLayoutItem91.IsUpdItem = true;
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem92.IsUpdItem = true;
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem93.IsUpdItem = true;
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "bom_occur_yn";
            this.multiLayoutItem94.IsUpdItem = true;
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "bom_source_key";
            this.multiLayoutItem95.IsUpdItem = true;
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "display_yn";
            this.multiLayoutItem96.IsUpdItem = true;
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "sunab_yn";
            this.multiLayoutItem97.IsUpdItem = true;
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "sunab_date";
            this.multiLayoutItem98.IsUpdItem = true;
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "sunab_time";
            this.multiLayoutItem99.IsUpdItem = true;
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "hope_date";
            this.multiLayoutItem100.IsUpdItem = true;
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "hope_time";
            this.multiLayoutItem101.IsUpdItem = true;
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "nurse_confirm_user";
            this.multiLayoutItem102.IsUpdItem = true;
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "nurse_confirm_date";
            this.multiLayoutItem103.IsUpdItem = true;
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "nurse_confirm_time";
            this.multiLayoutItem104.IsUpdItem = true;
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "nurse_pickup_user";
            this.multiLayoutItem105.IsUpdItem = true;
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "nurse_pickup_date";
            this.multiLayoutItem106.IsUpdItem = true;
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "nurse_pickup_time";
            this.multiLayoutItem107.IsUpdItem = true;
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "nurse_hold_user";
            this.multiLayoutItem108.IsUpdItem = true;
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "nurse_hold_date";
            this.multiLayoutItem109.IsUpdItem = true;
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "nurse_hold_time";
            this.multiLayoutItem110.IsUpdItem = true;
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "reser_date";
            this.multiLayoutItem111.IsUpdItem = true;
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "reser_time";
            this.multiLayoutItem112.IsUpdItem = true;
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "jubsu_date";
            this.multiLayoutItem113.IsUpdItem = true;
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "jubsu_time";
            this.multiLayoutItem114.IsUpdItem = true;
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "acting_date";
            this.multiLayoutItem115.IsUpdItem = true;
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "acting_time";
            this.multiLayoutItem116.IsUpdItem = true;
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "acting_day";
            this.multiLayoutItem117.IsUpdItem = true;
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "result_date";
            this.multiLayoutItem118.IsUpdItem = true;
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "dc_gubun";
            this.multiLayoutItem119.IsUpdItem = true;
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "dc_yn";
            this.multiLayoutItem120.IsUpdItem = true;
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "bannab_yn";
            this.multiLayoutItem121.IsUpdItem = true;
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "bannab_confirm";
            this.multiLayoutItem122.IsUpdItem = true;
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "source_ord_key";
            this.multiLayoutItem123.IsUpdItem = true;
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "ocs_flag";
            this.multiLayoutItem124.IsUpdItem = true;
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "sg_code";
            this.multiLayoutItem125.IsUpdItem = true;
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "sg_ymd";
            this.multiLayoutItem126.IsUpdItem = true;
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "io_gubun";
            this.multiLayoutItem127.IsUpdItem = true;
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "after_act_yn";
            this.multiLayoutItem128.IsUpdItem = true;
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "bichi_yn";
            this.multiLayoutItem129.IsUpdItem = true;
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "drg_bunho";
            this.multiLayoutItem130.IsUpdItem = true;
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "sub_susul";
            this.multiLayoutItem131.IsUpdItem = true;
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "print_yn";
            this.multiLayoutItem132.IsUpdItem = true;
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "chisik";
            this.multiLayoutItem133.IsUpdItem = true;
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "tel_yn";
            this.multiLayoutItem134.IsUpdItem = true;
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "order_gubun_bas";
            this.multiLayoutItem135.IsUpdItem = true;
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "input_control";
            this.multiLayoutItem136.IsUpdItem = true;
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "suga_yn";
            this.multiLayoutItem137.IsUpdItem = true;
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "jaeryo_yn";
            this.multiLayoutItem138.IsUpdItem = true;
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "wonyoi_check";
            this.multiLayoutItem139.IsUpdItem = true;
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "emergency_check";
            this.multiLayoutItem140.IsUpdItem = true;
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "specimen_check";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "portable_check";
            this.multiLayoutItem142.IsUpdItem = true;
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "bulyong_check";
            this.multiLayoutItem143.IsUpdItem = true;
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "sunab_check";
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "dc_check";
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "dc_gubun_check";
            this.multiLayoutItem146.IsUpdItem = true;
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "confirm_check";
            this.multiLayoutItem147.IsUpdItem = true;
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "reser_yn_check";
            this.multiLayoutItem148.IsUpdItem = true;
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "chisik_check";
            this.multiLayoutItem149.IsUpdItem = true;
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "nday_yn";
            this.multiLayoutItem150.IsUpdItem = true;
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem151.IsUpdItem = true;
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem152.IsUpdItem = true;
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "specific_comment";
            this.multiLayoutItem153.IsUpdItem = true;
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "specific_comment_name";
            this.multiLayoutItem154.IsUpdItem = true;
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "specific_comment_sys_id";
            this.multiLayoutItem155.IsUpdItem = true;
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem156.IsUpdItem = true;
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "specific_comment_not_null";
            this.multiLayoutItem157.IsUpdItem = true;
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "specific_comment_table_id";
            this.multiLayoutItem158.IsUpdItem = true;
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "specific_comment_col_id";
            this.multiLayoutItem159.IsUpdItem = true;
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "donbog_yn";
            this.multiLayoutItem160.IsUpdItem = true;
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "order_gubun_bas_name";
            this.multiLayoutItem161.IsUpdItem = true;
            // 
            // multiLayoutItem311
            // 
            this.multiLayoutItem311.DataName = "act_doctor";
            this.multiLayoutItem311.IsUpdItem = true;
            // 
            // multiLayoutItem312
            // 
            this.multiLayoutItem312.DataName = "act_buseo";
            this.multiLayoutItem312.IsUpdItem = true;
            // 
            // multiLayoutItem313
            // 
            this.multiLayoutItem313.DataName = "act_gwa";
            this.multiLayoutItem313.IsUpdItem = true;
            // 
            // multiLayoutItem314
            // 
            this.multiLayoutItem314.DataName = "home_care_yn";
            this.multiLayoutItem314.IsUpdItem = true;
            // 
            // multiLayoutItem315
            // 
            this.multiLayoutItem315.DataName = "regular_yn";
            this.multiLayoutItem315.IsUpdItem = true;
            // 
            // multiLayoutItem316
            // 
            this.multiLayoutItem316.DataName = "sort_fkocskey";
            this.multiLayoutItem316.IsUpdItem = true;
            // 
            // multiLayoutItem317
            // 
            this.multiLayoutItem317.DataName = "child_yn";
            this.multiLayoutItem317.IsUpdItem = true;
            // 
            // multiLayoutItem318
            // 
            this.multiLayoutItem318.DataName = "child_exist_yn";
            this.multiLayoutItem318.IsUpdItem = true;
            // 
            // multiLayoutItem319
            // 
            this.multiLayoutItem319.DataName = "dv_5";
            this.multiLayoutItem319.IsUpdItem = true;
            // 
            // multiLayoutItem320
            // 
            this.multiLayoutItem320.DataName = "dv_6";
            this.multiLayoutItem320.IsUpdItem = true;
            // 
            // multiLayoutItem321
            // 
            this.multiLayoutItem321.DataName = "dv_7";
            this.multiLayoutItem321.IsUpdItem = true;
            // 
            // multiLayoutItem322
            // 
            this.multiLayoutItem322.DataName = "dv_8";
            this.multiLayoutItem322.IsUpdItem = true;
            // 
            // multiLayoutItem323
            // 
            this.multiLayoutItem323.DataName = "bogyong_code_sub";
            this.multiLayoutItem323.IsUpdItem = true;
            // 
            // multiLayoutItem324
            // 
            this.multiLayoutItem324.DataName = "bogyong_name_sub";
            this.multiLayoutItem324.IsUpdItem = true;
            // 
            // layDeletedData
            // 
            this.layDeletedData.CallerID = '2';
            this.layDeletedData.ExecuteQuery = null;
            this.layDeletedData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem309});
            this.layDeletedData.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDeletedData.ParamList")));
            this.layDeletedData.UseDefaultTransaction = false;
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "in_out_key";
            this.multiLayoutItem162.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem162.IsUpdItem = true;
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "pkocskey";
            this.multiLayoutItem163.IsUpdItem = true;
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "bunho";
            this.multiLayoutItem164.IsUpdItem = true;
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "order_date";
            this.multiLayoutItem165.IsUpdItem = true;
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "gwa";
            this.multiLayoutItem166.IsUpdItem = true;
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "doctor";
            this.multiLayoutItem167.IsUpdItem = true;
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "resident";
            this.multiLayoutItem168.IsUpdItem = true;
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "naewon_type";
            this.multiLayoutItem169.IsUpdItem = true;
            // 
            // multiLayoutItem170
            // 
            this.multiLayoutItem170.DataName = "jubsu_no";
            this.multiLayoutItem170.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem170.IsUpdItem = true;
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "input_id";
            this.multiLayoutItem171.IsUpdItem = true;
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "input_part";
            this.multiLayoutItem172.IsUpdItem = true;
            // 
            // multiLayoutItem173
            // 
            this.multiLayoutItem173.DataName = "input_gwa";
            this.multiLayoutItem173.IsUpdItem = true;
            // 
            // multiLayoutItem174
            // 
            this.multiLayoutItem174.DataName = "input_doctor";
            this.multiLayoutItem174.IsUpdItem = true;
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "input_gubun";
            this.multiLayoutItem175.IsUpdItem = true;
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "input_gubun_name";
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "group_ser";
            this.multiLayoutItem177.IsUpdItem = true;
            // 
            // multiLayoutItem178
            // 
            this.multiLayoutItem178.DataName = "input_tab";
            this.multiLayoutItem178.IsUpdItem = true;
            // 
            // multiLayoutItem179
            // 
            this.multiLayoutItem179.DataName = "input_tab_name";
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "order_gubun";
            this.multiLayoutItem180.IsUpdItem = true;
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "order_gubun_name";
            // 
            // multiLayoutItem182
            // 
            this.multiLayoutItem182.DataName = "group_yn";
            this.multiLayoutItem182.IsUpdItem = true;
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "seq";
            this.multiLayoutItem183.IsUpdItem = true;
            // 
            // multiLayoutItem184
            // 
            this.multiLayoutItem184.DataName = "slip_code";
            this.multiLayoutItem184.IsUpdItem = true;
            // 
            // multiLayoutItem185
            // 
            this.multiLayoutItem185.DataName = "hangmog_code";
            this.multiLayoutItem185.IsUpdItem = true;
            // 
            // multiLayoutItem186
            // 
            this.multiLayoutItem186.DataName = "hangmog_name";
            // 
            // multiLayoutItem187
            // 
            this.multiLayoutItem187.DataName = "specimen_code";
            this.multiLayoutItem187.IsUpdItem = true;
            // 
            // multiLayoutItem188
            // 
            this.multiLayoutItem188.DataName = "specimen_name";
            // 
            // multiLayoutItem189
            // 
            this.multiLayoutItem189.DataName = "suryang";
            this.multiLayoutItem189.IsUpdItem = true;
            // 
            // multiLayoutItem190
            // 
            this.multiLayoutItem190.DataName = "sunab_suryang";
            this.multiLayoutItem190.IsUpdItem = true;
            // 
            // multiLayoutItem191
            // 
            this.multiLayoutItem191.DataName = "subul_suryang";
            this.multiLayoutItem191.IsUpdItem = true;
            // 
            // multiLayoutItem192
            // 
            this.multiLayoutItem192.DataName = "ord_danui";
            this.multiLayoutItem192.IsUpdItem = true;
            // 
            // multiLayoutItem193
            // 
            this.multiLayoutItem193.DataName = "ord_danui_name";
            // 
            // multiLayoutItem194
            // 
            this.multiLayoutItem194.DataName = "dv_time";
            this.multiLayoutItem194.IsUpdItem = true;
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "dv";
            this.multiLayoutItem195.IsUpdItem = true;
            // 
            // multiLayoutItem196
            // 
            this.multiLayoutItem196.DataName = "dv_1";
            this.multiLayoutItem196.IsUpdItem = true;
            // 
            // multiLayoutItem197
            // 
            this.multiLayoutItem197.DataName = "dv_2";
            this.multiLayoutItem197.IsUpdItem = true;
            // 
            // multiLayoutItem198
            // 
            this.multiLayoutItem198.DataName = "dv_3";
            this.multiLayoutItem198.IsUpdItem = true;
            // 
            // multiLayoutItem199
            // 
            this.multiLayoutItem199.DataName = "dv_4";
            this.multiLayoutItem199.IsUpdItem = true;
            // 
            // multiLayoutItem200
            // 
            this.multiLayoutItem200.DataName = "nalsu";
            this.multiLayoutItem200.IsUpdItem = true;
            // 
            // multiLayoutItem201
            // 
            this.multiLayoutItem201.DataName = "sunab_nalsu";
            this.multiLayoutItem201.IsUpdItem = true;
            // 
            // multiLayoutItem202
            // 
            this.multiLayoutItem202.DataName = "jusa";
            this.multiLayoutItem202.IsUpdItem = true;
            // 
            // multiLayoutItem203
            // 
            this.multiLayoutItem203.DataName = "jusa_name";
            this.multiLayoutItem203.IsUpdItem = true;
            // 
            // multiLayoutItem204
            // 
            this.multiLayoutItem204.DataName = "jusa_spd_gubun";
            this.multiLayoutItem204.IsUpdItem = true;
            // 
            // multiLayoutItem205
            // 
            this.multiLayoutItem205.DataName = "bogyong_code";
            this.multiLayoutItem205.IsUpdItem = true;
            // 
            // multiLayoutItem206
            // 
            this.multiLayoutItem206.DataName = "bogyong_name";
            this.multiLayoutItem206.IsUpdItem = true;
            // 
            // multiLayoutItem207
            // 
            this.multiLayoutItem207.DataName = "emergency";
            this.multiLayoutItem207.IsUpdItem = true;
            // 
            // multiLayoutItem208
            // 
            this.multiLayoutItem208.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem208.IsUpdItem = true;
            // 
            // multiLayoutItem209
            // 
            this.multiLayoutItem209.DataName = "jundal_table";
            this.multiLayoutItem209.IsUpdItem = true;
            // 
            // multiLayoutItem210
            // 
            this.multiLayoutItem210.DataName = "jundal_part";
            this.multiLayoutItem210.IsUpdItem = true;
            // 
            // multiLayoutItem211
            // 
            this.multiLayoutItem211.DataName = "move_part";
            this.multiLayoutItem211.IsUpdItem = true;
            // 
            // multiLayoutItem212
            // 
            this.multiLayoutItem212.DataName = "portable_yn";
            this.multiLayoutItem212.IsUpdItem = true;
            // 
            // multiLayoutItem213
            // 
            this.multiLayoutItem213.DataName = "powder_yn";
            this.multiLayoutItem213.IsUpdItem = true;
            // 
            // multiLayoutItem214
            // 
            this.multiLayoutItem214.DataName = "hubal_change_yn";
            this.multiLayoutItem214.IsUpdItem = true;
            // 
            // multiLayoutItem215
            // 
            this.multiLayoutItem215.DataName = "pharmacy";
            this.multiLayoutItem215.IsUpdItem = true;
            // 
            // multiLayoutItem216
            // 
            this.multiLayoutItem216.DataName = "drg_pack_yn";
            this.multiLayoutItem216.IsUpdItem = true;
            // 
            // multiLayoutItem217
            // 
            this.multiLayoutItem217.DataName = "muhyo";
            this.multiLayoutItem217.IsUpdItem = true;
            // 
            // multiLayoutItem218
            // 
            this.multiLayoutItem218.DataName = "prn_yn";
            this.multiLayoutItem218.IsUpdItem = true;
            // 
            // multiLayoutItem219
            // 
            this.multiLayoutItem219.DataName = "toiwon_drg_yn";
            this.multiLayoutItem219.IsUpdItem = true;
            // 
            // multiLayoutItem220
            // 
            this.multiLayoutItem220.DataName = "prn_nurse";
            this.multiLayoutItem220.IsUpdItem = true;
            // 
            // multiLayoutItem221
            // 
            this.multiLayoutItem221.DataName = "append_yn";
            this.multiLayoutItem221.IsUpdItem = true;
            // 
            // multiLayoutItem222
            // 
            this.multiLayoutItem222.DataName = "order_remark";
            this.multiLayoutItem222.IsUpdItem = true;
            // 
            // multiLayoutItem223
            // 
            this.multiLayoutItem223.DataName = "nurse_remark";
            this.multiLayoutItem223.IsUpdItem = true;
            // 
            // multiLayoutItem224
            // 
            this.multiLayoutItem224.DataName = "comment";
            this.multiLayoutItem224.IsUpdItem = true;
            // 
            // multiLayoutItem225
            // 
            this.multiLayoutItem225.DataName = "mix_group";
            this.multiLayoutItem225.IsUpdItem = true;
            // 
            // multiLayoutItem226
            // 
            this.multiLayoutItem226.DataName = "amt";
            this.multiLayoutItem226.IsUpdItem = true;
            // 
            // multiLayoutItem227
            // 
            this.multiLayoutItem227.DataName = "pay";
            this.multiLayoutItem227.IsUpdItem = true;
            // 
            // multiLayoutItem228
            // 
            this.multiLayoutItem228.DataName = "wonyoi_order_yn";
            this.multiLayoutItem228.IsUpdItem = true;
            // 
            // multiLayoutItem229
            // 
            this.multiLayoutItem229.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem229.IsUpdItem = true;
            // 
            // multiLayoutItem230
            // 
            this.multiLayoutItem230.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem230.IsUpdItem = true;
            // 
            // multiLayoutItem231
            // 
            this.multiLayoutItem231.DataName = "bom_occur_yn";
            this.multiLayoutItem231.IsUpdItem = true;
            // 
            // multiLayoutItem232
            // 
            this.multiLayoutItem232.DataName = "bom_source_key";
            this.multiLayoutItem232.IsUpdItem = true;
            // 
            // multiLayoutItem233
            // 
            this.multiLayoutItem233.DataName = "display_yn";
            this.multiLayoutItem233.IsUpdItem = true;
            // 
            // multiLayoutItem234
            // 
            this.multiLayoutItem234.DataName = "sunab_yn";
            this.multiLayoutItem234.IsUpdItem = true;
            // 
            // multiLayoutItem235
            // 
            this.multiLayoutItem235.DataName = "sunab_date";
            this.multiLayoutItem235.IsUpdItem = true;
            // 
            // multiLayoutItem236
            // 
            this.multiLayoutItem236.DataName = "sunab_time";
            this.multiLayoutItem236.IsUpdItem = true;
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "hope_date";
            this.multiLayoutItem237.IsUpdItem = true;
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "hope_time";
            this.multiLayoutItem238.IsUpdItem = true;
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "nurse_confirm_user";
            this.multiLayoutItem239.IsUpdItem = true;
            // 
            // multiLayoutItem240
            // 
            this.multiLayoutItem240.DataName = "nurse_confirm_date";
            this.multiLayoutItem240.IsUpdItem = true;
            // 
            // multiLayoutItem241
            // 
            this.multiLayoutItem241.DataName = "nurse_confirm_time";
            this.multiLayoutItem241.IsUpdItem = true;
            // 
            // multiLayoutItem242
            // 
            this.multiLayoutItem242.DataName = "nurse_pickup_user";
            this.multiLayoutItem242.IsUpdItem = true;
            // 
            // multiLayoutItem243
            // 
            this.multiLayoutItem243.DataName = "nurse_pickup_date";
            this.multiLayoutItem243.IsUpdItem = true;
            // 
            // multiLayoutItem244
            // 
            this.multiLayoutItem244.DataName = "nurse_pickup_time";
            this.multiLayoutItem244.IsUpdItem = true;
            // 
            // multiLayoutItem245
            // 
            this.multiLayoutItem245.DataName = "nurse_hold_user";
            this.multiLayoutItem245.IsUpdItem = true;
            // 
            // multiLayoutItem246
            // 
            this.multiLayoutItem246.DataName = "nurse_hold_date";
            this.multiLayoutItem246.IsUpdItem = true;
            // 
            // multiLayoutItem247
            // 
            this.multiLayoutItem247.DataName = "nurse_hold_time";
            this.multiLayoutItem247.IsUpdItem = true;
            // 
            // multiLayoutItem248
            // 
            this.multiLayoutItem248.DataName = "reser_date";
            this.multiLayoutItem248.IsUpdItem = true;
            // 
            // multiLayoutItem249
            // 
            this.multiLayoutItem249.DataName = "reser_time";
            this.multiLayoutItem249.IsUpdItem = true;
            // 
            // multiLayoutItem250
            // 
            this.multiLayoutItem250.DataName = "jubsu_date";
            this.multiLayoutItem250.IsUpdItem = true;
            // 
            // multiLayoutItem251
            // 
            this.multiLayoutItem251.DataName = "jubsu_time";
            this.multiLayoutItem251.IsUpdItem = true;
            // 
            // multiLayoutItem252
            // 
            this.multiLayoutItem252.DataName = "acting_date";
            this.multiLayoutItem252.IsUpdItem = true;
            // 
            // multiLayoutItem253
            // 
            this.multiLayoutItem253.DataName = "acting_time";
            this.multiLayoutItem253.IsUpdItem = true;
            // 
            // multiLayoutItem254
            // 
            this.multiLayoutItem254.DataName = "acting_day";
            this.multiLayoutItem254.IsUpdItem = true;
            // 
            // multiLayoutItem255
            // 
            this.multiLayoutItem255.DataName = "result_date";
            this.multiLayoutItem255.IsUpdItem = true;
            // 
            // multiLayoutItem256
            // 
            this.multiLayoutItem256.DataName = "dc_gubun";
            this.multiLayoutItem256.IsUpdItem = true;
            // 
            // multiLayoutItem257
            // 
            this.multiLayoutItem257.DataName = "dc_yn";
            this.multiLayoutItem257.IsUpdItem = true;
            // 
            // multiLayoutItem258
            // 
            this.multiLayoutItem258.DataName = "bannab_yn";
            this.multiLayoutItem258.IsUpdItem = true;
            // 
            // multiLayoutItem259
            // 
            this.multiLayoutItem259.DataName = "bannab_confirm";
            this.multiLayoutItem259.IsUpdItem = true;
            // 
            // multiLayoutItem260
            // 
            this.multiLayoutItem260.DataName = "source_ord_key";
            this.multiLayoutItem260.IsUpdItem = true;
            // 
            // multiLayoutItem261
            // 
            this.multiLayoutItem261.DataName = "ocs_flag";
            this.multiLayoutItem261.IsUpdItem = true;
            // 
            // multiLayoutItem262
            // 
            this.multiLayoutItem262.DataName = "sg_code";
            this.multiLayoutItem262.IsUpdItem = true;
            // 
            // multiLayoutItem263
            // 
            this.multiLayoutItem263.DataName = "sg_ymd";
            this.multiLayoutItem263.IsUpdItem = true;
            // 
            // multiLayoutItem264
            // 
            this.multiLayoutItem264.DataName = "io_gubun";
            this.multiLayoutItem264.IsUpdItem = true;
            // 
            // multiLayoutItem265
            // 
            this.multiLayoutItem265.DataName = "after_act_yn";
            this.multiLayoutItem265.IsUpdItem = true;
            // 
            // multiLayoutItem266
            // 
            this.multiLayoutItem266.DataName = "bichi_yn";
            this.multiLayoutItem266.IsUpdItem = true;
            // 
            // multiLayoutItem267
            // 
            this.multiLayoutItem267.DataName = "drg_bunho";
            this.multiLayoutItem267.IsUpdItem = true;
            // 
            // multiLayoutItem268
            // 
            this.multiLayoutItem268.DataName = "sub_susul";
            this.multiLayoutItem268.IsUpdItem = true;
            // 
            // multiLayoutItem269
            // 
            this.multiLayoutItem269.DataName = "print_yn";
            this.multiLayoutItem269.IsUpdItem = true;
            // 
            // multiLayoutItem270
            // 
            this.multiLayoutItem270.DataName = "chisik";
            this.multiLayoutItem270.IsUpdItem = true;
            // 
            // multiLayoutItem271
            // 
            this.multiLayoutItem271.DataName = "tel_yn";
            this.multiLayoutItem271.IsUpdItem = true;
            // 
            // multiLayoutItem272
            // 
            this.multiLayoutItem272.DataName = "order_gubun_bas";
            this.multiLayoutItem272.IsUpdItem = true;
            // 
            // multiLayoutItem273
            // 
            this.multiLayoutItem273.DataName = "input_control";
            this.multiLayoutItem273.IsUpdItem = true;
            // 
            // multiLayoutItem274
            // 
            this.multiLayoutItem274.DataName = "suga_yn";
            this.multiLayoutItem274.IsUpdItem = true;
            // 
            // multiLayoutItem275
            // 
            this.multiLayoutItem275.DataName = "jaeryo_yn";
            this.multiLayoutItem275.IsUpdItem = true;
            // 
            // multiLayoutItem276
            // 
            this.multiLayoutItem276.DataName = "wonyoi_check";
            this.multiLayoutItem276.IsUpdItem = true;
            // 
            // multiLayoutItem277
            // 
            this.multiLayoutItem277.DataName = "emergency_check";
            this.multiLayoutItem277.IsUpdItem = true;
            // 
            // multiLayoutItem278
            // 
            this.multiLayoutItem278.DataName = "specimen_check";
            // 
            // multiLayoutItem279
            // 
            this.multiLayoutItem279.DataName = "portable_check";
            this.multiLayoutItem279.IsUpdItem = true;
            // 
            // multiLayoutItem280
            // 
            this.multiLayoutItem280.DataName = "bulyong_check";
            this.multiLayoutItem280.IsUpdItem = true;
            // 
            // multiLayoutItem281
            // 
            this.multiLayoutItem281.DataName = "sunab_check";
            // 
            // multiLayoutItem282
            // 
            this.multiLayoutItem282.DataName = "dc_check";
            // 
            // multiLayoutItem283
            // 
            this.multiLayoutItem283.DataName = "dc_gubun_check";
            this.multiLayoutItem283.IsUpdItem = true;
            // 
            // multiLayoutItem284
            // 
            this.multiLayoutItem284.DataName = "confirm_check";
            this.multiLayoutItem284.IsUpdItem = true;
            // 
            // multiLayoutItem285
            // 
            this.multiLayoutItem285.DataName = "reser_yn_check";
            this.multiLayoutItem285.IsUpdItem = true;
            // 
            // multiLayoutItem286
            // 
            this.multiLayoutItem286.DataName = "chisik_check";
            this.multiLayoutItem286.IsUpdItem = true;
            // 
            // multiLayoutItem287
            // 
            this.multiLayoutItem287.DataName = "nday_yn";
            this.multiLayoutItem287.IsUpdItem = true;
            // 
            // multiLayoutItem288
            // 
            this.multiLayoutItem288.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem288.IsUpdItem = true;
            // 
            // multiLayoutItem289
            // 
            this.multiLayoutItem289.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem289.IsUpdItem = true;
            // 
            // multiLayoutItem290
            // 
            this.multiLayoutItem290.DataName = "specific_comment";
            this.multiLayoutItem290.IsUpdItem = true;
            // 
            // multiLayoutItem291
            // 
            this.multiLayoutItem291.DataName = "specific_comment_name";
            this.multiLayoutItem291.IsUpdItem = true;
            // 
            // multiLayoutItem292
            // 
            this.multiLayoutItem292.DataName = "specific_comment_sys_id";
            this.multiLayoutItem292.IsUpdItem = true;
            // 
            // multiLayoutItem293
            // 
            this.multiLayoutItem293.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem293.IsUpdItem = true;
            // 
            // multiLayoutItem294
            // 
            this.multiLayoutItem294.DataName = "specific_comment_not_null";
            this.multiLayoutItem294.IsUpdItem = true;
            // 
            // multiLayoutItem295
            // 
            this.multiLayoutItem295.DataName = "specific_comment_table_id";
            this.multiLayoutItem295.IsUpdItem = true;
            // 
            // multiLayoutItem296
            // 
            this.multiLayoutItem296.DataName = "specific_comment_col_id";
            this.multiLayoutItem296.IsUpdItem = true;
            // 
            // multiLayoutItem297
            // 
            this.multiLayoutItem297.DataName = "donbog_yn";
            this.multiLayoutItem297.IsUpdItem = true;
            // 
            // multiLayoutItem298
            // 
            this.multiLayoutItem298.DataName = "order_gubun_bas_name";
            this.multiLayoutItem298.IsUpdItem = true;
            // 
            // multiLayoutItem299
            // 
            this.multiLayoutItem299.DataName = "act_doctor";
            this.multiLayoutItem299.IsUpdItem = true;
            // 
            // multiLayoutItem300
            // 
            this.multiLayoutItem300.DataName = "act_buseo";
            this.multiLayoutItem300.IsUpdItem = true;
            // 
            // multiLayoutItem301
            // 
            this.multiLayoutItem301.DataName = "act_gwa";
            this.multiLayoutItem301.IsUpdItem = true;
            // 
            // multiLayoutItem302
            // 
            this.multiLayoutItem302.DataName = "home_care_yn";
            this.multiLayoutItem302.IsUpdItem = true;
            // 
            // multiLayoutItem303
            // 
            this.multiLayoutItem303.DataName = "regular_yn";
            this.multiLayoutItem303.IsUpdItem = true;
            // 
            // multiLayoutItem304
            // 
            this.multiLayoutItem304.DataName = "sort_fkocskey";
            this.multiLayoutItem304.IsUpdItem = true;
            // 
            // multiLayoutItem305
            // 
            this.multiLayoutItem305.DataName = "child_yn";
            this.multiLayoutItem305.IsUpdItem = true;
            // 
            // multiLayoutItem306
            // 
            this.multiLayoutItem306.DataName = "child_exist_yn";
            this.multiLayoutItem306.IsUpdItem = true;
            // 
            // multiLayoutItem307
            // 
            this.multiLayoutItem307.DataName = "dummy";
            // 
            // multiLayoutItem308
            // 
            this.multiLayoutItem308.DataName = "bogyong_code_sub";
            this.multiLayoutItem308.IsUpdItem = true;
            // 
            // multiLayoutItem309
            // 
            this.multiLayoutItem309.DataName = "bogyong_name_sub";
            this.multiLayoutItem309.IsUpdItem = true;
            // 
            // GridOrderU10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(937, 373);
            this.Name = "GridOrderU10";
            this.Size = new System.Drawing.Size(937, 373);
            this.Load += new System.EventHandler(this.GridOrderU10_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.pnlOrderDetail.ResumeLayout(false);
            this.pnlOrderDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIsBgtDrg)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSangyongOrder)).EndInit();
            this.pnlRightBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layGroupTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDrugTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySaveLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDeletedData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #endregion

        #region 2. Form변수를 정의한다

        private string mbxMsg = "", mbxCap = "";

        //insert by jc [一般名検索機能追加] 2012/11/01
        private string mGenericSearchYN = "N";

        private const string EMERGENCY_GWA = "04";
        private const string CREATE_DO = "OCS1003P02";

        //不均等処方
        private ArrayList mUnEvenList = null;

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
        private int OrderExtendWidth = 1081;
        private int OrderNormalWidth = 872;
        private bool mIsExtended = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 조회부분 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int OrderMinWidth = 618;
        private bool mIsSearchExtended = false;

        private int PreviewHangmogMaxWidth = 315;
        private int PreviewHangmogNormalWidth = 179;

        //private int SearchHangmogNameNormalWidth = 304;
        private int SearchHangmogNameNormalWidth = 180;
        //private int SearchHangmogNameMaxWidth = 443;
        private int SearchHangmogNameMaxWidth = 300;

        private int DrgHangmogNameNormalWidth = 152;
        private int DrgHangmogNameMaxWidth = 294;

        private int SangYongHangmogNormalWidth = 305;
        private int SangYongHangmogMaxWidth = 441;

        ///////////// Order 기본값 /////////////////////////////////////////////////////////////////////////
        private const string INPUTTAB = "01"; // 내복약 (01) 
        private string IOEGUBUN = "O";     // 입외구분(외래)
        private string mInputGubun = "D0";    // 입력구분(의사처방)
        private string mInputGubunName = "";  // 입력구분명
        private string mInputPart = "";      // 입력파트
        private string mCallerSysID = "";
        private string mCallerScreenID = "";

        private bool mPostApproveYN = false;

        //insert by jc [OCS1003P01のデータウインドウから選択された際、自動ポイント移動に必要な変数]
        private int mCurrentRowNum = -1;
        private XDataWindow mCurrentDataWindow;
        private string mCurrentColName = "";

        //一般名関連
        private string mGeneral_disp_yn = "";


        //공통
        private XEditGrid mSelectedGRD = null;

        private string mOrderDate = "";
        //private MultiLayout mOrderLayout;
        private OrderVariables.OrderMode mOrderMode;
        //입원외래 order
        private string mPkInOutKey = "";
        //private string mOrderGubun = "C"; // 오더구분 (내복약)
        // 셋트오더 관련 _ 키
        private string mMemb = "";
        private string mYaksokCode = "";  // 셋트이면 약속코드, Cp 이면 Cp Code 가 들어감.
        // CP관련 키
        private string mMembGubun = "";
        private string mCpCode = "";
        private string mJaewonil = "";
        private string mCpPathCode = "";
        private string mCpMasterkey = "";

        // 환자정보관련

        private bool mDoctorLogin = false;

        // 오더 정보 관련
        private DataTable mInDataRow;
        //private DataTable mOutDataRow;

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
        //private bool mIsDrag = false;
        //private int  mDragX = 0;
        //private int  mDragY = 0;
        //private int  mDownY = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////Popup Menu ////////////////////////////////////////////////////////////////////////////
        private IHIS.X.Magic.Menus.PopupMenu popupOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 처방Grid용
        //private IHIS.X.Magic.Menus.PopupMenu popupOftenUsedMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 상용처방Grid용
        private IHIS.X.Magic.Menus.PopupMenu popupYaksokOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 약속처방Grid용
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //private Hashtable mHtControl = null;        // Control과 연결할 HashTable

        //private bool mIsSuccessBtnList = true;      // 버튼리스트 로직 콜해서 성공여부를 가지고 있는다(PerformClick의 Return값이 없어서)

        //private string mPk_Naewon = ""; // 내원/재원환자List에서 환자 선택한 내원/재원Key

        //private DataTable mDtOrderGubun;

        // 저장을 하기 위한 Layout
        private Hashtable mSaveLayout;

        // Screen Open check
        //private bool mScreenOpen = true;

        // 신규 탭 페이지 
        private IHIS.X.Magic.Controls.TabPage tpgNew = new IHIS.X.Magic.Controls.TabPage();

        // 임시 컬럼
        string mTemp = "";

        // 포커스를 위한 로우 번호
        private int mFocusRow = -1;

        // 원내 원외 디폴트 체크 
        private string mDefaultWonyoiOrder = "Y";

        #endregion

        #region 3. Properties, fields - Cloud updated

        /// <summary>
        /// OCS0103U13CboListResult
        /// </summary>
        private OCS0103U13CboListResult _cboListItems;
        /// <summary>
        /// OCS0103U13FormLoadResult
        /// </summary>
        private OCS0103U10FormLoadResult _formResult;
        /// <summary>
        /// cbo Search condition
        /// </summary>
        private IList<object[]> _cboSearchCondLstItem;
        /// <summary>
        /// layDrugTree cache key
        /// </summary>
        private const string CACHE_LAY_DRUG_TREE = "OCS0103U10.Cache.LayDrugTree";
        /// <summary>
        /// Cbo input gubun cache key
        /// </summary>
        private const string CACHE_CBO_INPUT_GUBUN = "OCS0103U10.Cache.Cbo.InputGubun";
        /// <summary>
        /// Cbo search condition cache key
        /// </summary>
        private const string CACHE_CBO_SEARCH_CONDITION = "OCS0103U10.Cache.Cbo.SearchCondition";

        /// <summary>
        /// Combobox datasources
        /// </summary>
        private DataTable _dvTimeCbo = new DataTable();
        private DataTable _suryangCbo = new DataTable();
        private DataTable _dvCbo = new DataTable();
        private DataTable _nalsuCbo = new DataTable();

        #endregion

        #region Contructor
        public GridOrderU10()
        {
            InitializeComponent();
        }

        private void GridOrderU10_Load(object sender, EventArgs e)
        {
            InitItemsControl();
        }

        private void InitItemsControl()
        {
            // grdOrder
            this.grdOrder.ParamList = new List<string>(new string[]
                {
                    "f_memb",
                    "f_yaksok_code",
                    "f_fk_in_out_key",
                    "f_input_tab",
                    "f_input_gubun",
                });
            this.grdOrder.ExecuteQuery = GetGrdOrder;

            // grdSangyongOrder
            this.grdSangyongOrder.ParamList = new List<string>(new string[]
                {
                    "f_user",
                    "f_io_gubun",
                    "f_order_gubun",
                    "f_order_date",
                    "f_search_word",
                    "f_wonnae_drg_yn",
                });
            this.grdSangyongOrder.ExecuteQuery = GetGrdSangyongOrder;

        }

        #endregion

        #region Field & Properties

        #endregion

        #region Event

        #region OrderRadio_CheckedChanged

        private void OrderRadio_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;
            //insert by jc
            string searchVoc = this.txtSearch.GetDataValue();
            string wonnaeDrgYn = this.cboQueryCon.GetDataValue();

            if (control.Checked)
            {
                /*control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;*/
                control.ImageIndex = 0;

                // 선택된것에 따른 화면 조정
                switch (control.Name)
                {
                    case "rbnSearchOrder":   // 오더검색
                        /*this.pnlSearchTool.Visible = true;
                        this.pnlSearchOrder.Visible = true;
                        this.pnlSangyong.Visible = false;
                        this.pnlDrug.Visible = false;
                        this.pnlPreview.Visible = false;
                        if (this.IOEGUBUN == "O")
                            this.grbGeneric.Enabled = true;
                        else
                            this.grbGeneric.Enabled = false;
                        //this.rbtSyouhin.Enabled = true;
                        this.grdSearchOrder.Reset();

                        PostCallHelper.PostCall(new PostMethod(PostRadioCheckedChanged));

                        //insert by jc TABが変わる際に検索語が既にあった場合はその検索語で検索する。
                        if (searchVoc != "")
                        {
                            if (this.rbnSearchOrder.Checked)
                                this.LoadSearchOrderInfo(searchVoc, this.dpkOrder_Date.GetDataValue(), INPUTTAB, wonnaeDrgYn);
                        }*/
                        break;

                    case "rbnOftenOrder":    // 상용오더
                        /*this.pnlSearchTool.Visible = true;
                        this.pnlSearchOrder.Visible = false;
                        this.pnlSangyong.Visible = true;
                        this.pnlDrug.Visible = false;
                        this.pnlPreview.Visible = false;
                        this.rbtSyouhin.Checked = true;
                        this.grbGeneric.Enabled = false;
                        PostCallHelper.PostCall(new PostMethod(PostRadioCheckedChanged));*/
                        this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());

                        break;

                    case "rbnDrgOrder":       // 효능별
                        /*this.pnlSearchTool.Visible = true;
                        this.pnlSearchOrder.Visible = false;
                        this.pnlSangyong.Visible = false;
                        this.pnlDrug.Visible = true;
                        this.pnlPreview.Visible = false;
                        this.rbtSyouhin.Checked = true;
                        this.grbGeneric.Enabled = false;
                        this.grdDrgOrder.Reset();
                        PostCallHelper.PostCall(new PostMethod(PostRadioCheckedChanged));
                        //insert by jc TABが変わる際に検索語が既にあった場合はその検索語で検索する。
                        if (searchVoc != "")
                        {
                            if (this.rbnDrgOrder.Checked)
                                this.LoadDrgOrder("2", "%", wonnaeDrgYn, this.txtSearch.GetDataValue());
                        }*/

                        break;

                    case "rbnOrderStatus":
                        /*this.pnlSearchTool.Visible = false;
                        this.pnlSearchOrder.Visible = false;
                        this.pnlSangyong.Visible = false;
                        this.pnlDrug.Visible = false;
                        this.pnlPreview.Visible = true;
                        this.rbtSyouhin.Checked = true;
                        this.grbGeneric.Enabled = false;
                        this.MakePreviewStatus();*/
                        break;
                }
            }
            else
            {
                /*control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;*/
                control.ImageIndex = 1;
            }
        }

        #endregion

        private void tabSangyongOrder_SelectionChanged(object sender, EventArgs e)
        {
            XTabControl control = sender as XTabControl;
            //string memb = "";
            //Hashtable tabInfo;

            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);
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

        private void grdSangyongOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdSangyongOrder_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;
            //int applyRow = -1;

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
                grid.DoDragDrop("SangYong" + "|" + rowNumber.ToString(CultureInfo.InvariantCulture), DragDropEffects.Move);
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                if (rowNumber < 0) return;

                if (this.grdSangyongOrder.CurrentRowNumber != rowNumber)
                {
                    this.grdSangyongOrder.SetFocusToItem(rowNumber, 0);
                }

                //this.popupOftenUsedMenu.TrackPopup(grid.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void grdSangyongOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(IOEGUBUN, grid, e);
        }

        private void grdSangyongOrder_QueryStarting(object sender, CancelEventArgs e)
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
            this.grdSangyongOrder.SetBindVarValue("f_order_gubun", ((Hashtable)this.tabSangyongOrder.SelectedTab.Tag)["order_gubun"].ToString());
            /*this.grdSangyongOrder.SetBindVarValue("f_order_date", this.dpkOrder_Date.GetDataValue());*/
            this.grdSangyongOrder.SetBindVarValue("f_wonnae_drg_yn", this.cboQueryCon.GetDataValue());
        }

        private void grdOrder_Click(object sender, EventArgs e)
        {
            // 포커스가 왔을때 아무것도 입력이 되어 있지 않다면 
            // 신규로우를 하나 자동으로 생성한다.
            if (this.tabGroup.SelectedTab != null)
            {
                /*DataRow[] dr = this.grdOrder.LayoutTable.Select("group_ser=" + ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString());
                if (dr.Length <= 0)
                {
                    this.btnList.PerformClick(FunctionType.Insert);
                }*/
            }
        }

        private void grdOrder_DragDrop(object sender, DragEventArgs e)
        {
            string data = e.Data.GetData("System.String").ToString();
            string gubun = data.Split('|')[0];
            string sourceRow = data.Split('|')[1];
            string hangmogCode = "";

            int rowNumber = grdOrder.GetHitRowNumber(e.Y);

            if (TypeCheck.IsInt(sourceRow) == false)
            {
                return;
            }

            if (this.tabGroup.SelectedTab == null)
            {
                /*this.btnList.PerformClick(FunctionType.Process);*/
            }

            switch (gubun)
            {
                case "Search":

                    hangmogCode = this.mSelectedGRD.GetItemString(int.Parse(sourceRow), "hangmog_code");

                    this.ApplySangOrderInfo(hangmogCode, rowNumber, false, mGenericSearchYN);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;

                case "SangYong":

                    hangmogCode = this.grdSangyongOrder.GetItemString(int.Parse(sourceRow), "hangmog_code");

                    this.ApplySangOrderInfo(hangmogCode, rowNumber, false, mGenericSearchYN);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;
            }
        }

        private void grdOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시	
        }

        private void grdOrder_MouseDown(object sender, MouseEventArgs e)
        {
            int columnNumber = -1;
            string columnName = "";
            int curRowIndex = -1;
            XEditGrid grd = sender as XEditGrid;
            this.mUnEvenList = new ArrayList();
            ArrayList aSourceList = new ArrayList();

            curRowIndex = grd.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                this.grdOrder.SetFocusToItem(curRowIndex, "hangmog_name");
                popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
            }
            if (e.Button == MouseButtons.Left && e.Clicks == 1 && curRowIndex >= 0 && grd.GetItemString(curRowIndex, "dv_time") == "/")
            {
                if (grd.CurrentColName == "dv_1" ||
                    grd.CurrentColName == "dv_2" ||
                    grd.CurrentColName == "dv_3" ||
                    grd.CurrentColName == "dv_4" ||
                    grd.CurrentColName == "dv_5" ||
                    grd.CurrentColName == "dv_6" ||
                    grd.CurrentColName == "dv_7" ||
                    grd.CurrentColName == "dv_8")
                {
                    int dv = int.Parse(grd.GetItemString(curRowIndex, "dv"));
                    if (dv > 8)
                    {
                        this.grdOrder.SetItemValue(curRowIndex, "dv", 8);
                        dv = int.Parse(grd.GetItemString(curRowIndex, "dv"));
                    }
                    if (grd.GetItemString(curRowIndex, "bogyong_code") != "" && dv > 0)
                    {
                        for (int i = 0; i < dv - 1; i++)
                        {
                            this.grdOrder.AutoSizeColumn(i + 18, 30); // dv_2
                            //this.grdOrder.AutoSizeColumn(17, 30); // dv_2
                            //this.grdOrder.AutoSizeColumn(18, 30); // dv_3
                            //this.grdOrder.AutoSizeColumn(19, 30); // dv_4
                            //this.grdOrder.AutoSizeColumn(20, 30); // dv_5
                            //this.grdOrder.AutoSizeColumn(21, 30); // dv_6
                            //this.grdOrder.AutoSizeColumn(22, 30); // dv_7
                            //this.grdOrder.AutoSizeColumn(23, 30); // dv_8
                        }
                        this.grdOrder.Refresh();

                        if ((grd.GetItemString(curRowIndex, "sunab_yn") != "Y" || grd.GetItemString(curRowIndex, "sunab_date") == ""))
                        {
                            for (int i = 0; i < dv; i++)
                            {
                                columnNumber = (i + 1);
                                columnName = "dv_" + columnNumber.ToString();
                                aSourceList.Add(grd.GetItemString(curRowIndex, columnName));
                            }
                            this.mUnEvenList = this.mCommonForms.FormUnevenPrescribe(grd);
                        }
                        else
                            return;
                    }
                    else
                        XMessageBox.Show("服用コードの入力してください。");

                    if (this.mUnEvenList != null)
                    {
                        if (this.mUnEvenList.Count > 0)
                        {
                            for (int i = 0; i < this.mUnEvenList.Count - 1; i++) //最後の行に数量が入ってるために（-1）する。
                            {
                                columnNumber = (i + 1);
                                columnName = "dv_" + columnNumber.ToString();
                                grd.SetItemValue(grd.CurrentRowNumber, columnName, this.mUnEvenList[i].ToString());
                            }
                            //数量
                            grd.SetItemValue(grd.CurrentRowNumber, "suryang", this.mUnEvenList[8].ToString());

                        }
                    }
                }
            }
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
                        this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);   // 이전값으로 되돌린다.
                        return;
                    }

                    this.mHangmogInfo.Parameter.Clear();
                    this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
                    this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
                    this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
                    this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
                    this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
                    this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

                    if (this.mOrderMode == OrderVariables.OrderMode.InpOrder)
                        this.mHangmogInfo.Parameter.Ho_dong = this.mPatientInfo.GetPatientInfo["ho_dong"].ToString();

                    this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = this.cbxWonyoiOrderYN.GetDataValue();

                    if (this.mGeneral_disp_yn == "Y" && this.mOrderBiz.IsGeneralYN(hangmog_code) != "")
                        this.mHangmogInfo.Parameter.GenericSearchYN = "Y";
                    else
                        this.mHangmogInfo.Parameter.GenericSearchYN = this.mGenericSearchYN;

                    if (this.rbtGenericSearch.Checked == true || this.mHangmogInfo.Parameter.GenericSearchYN == "Y")
                        this.mHangmogInfo.Parameter.Generic_name = this.mOrderBiz.IsGeneralYN(hangmog_code);

                    if (this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
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
                    loadExtraInfo.LayoutItems.Add("bogyong_code", DataType.String);
                    loadExtraInfo.LayoutItems.Add("dv", DataType.String);
                    loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
                    loadExtraInfo.LayoutItems.Add("wonyoi_order_yn", DataType.String);
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
                    // 복용코드
                    if (groupInfo.Contains("bogyong_code"))
                    {
                        loadExtraInfo.SetItemValue(0, "bogyong_code", groupInfo["bogyong_code"].ToString());
                    }
                    // DV
                    if (groupInfo.Contains("dv"))
                    {
                        loadExtraInfo.SetItemValue(0, "dv", groupInfo["dv"].ToString());
                    }
                    // Emergency
                    if (groupInfo.Contains("emergency"))
                    {
                        loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
                    }
                    // 원외처방여부
                    if (groupInfo.Contains("wonyoi_order_yn"))
                    {
                        loadExtraInfo.SetItemValue(0, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());
                    }

                    #endregion

                    if (this.mHangmogInfo.LoadHangmogInfo(HangmogInfo.ExecutiveMode.CodeInput, loadExtraInfo) == false)
                    {
                        this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);
                        //this.grdOrder.SetItemValue(e.RowNumber, "hangmog_name", "");
                        this.OpenScreen_OCS0103Q00(e.ChangeValue.ToString(), true);
                        return;
                    }

                    this.ApplyDefaultOrderInfo(HangmogInfo.ExecutiveMode.CodeInput, this.mHangmogInfo.GetHangmogInfo, grid, e.RowNumber, true);

                    //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
                    this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

                    this.DisplayMixGroup(this.grdOrder);

                    this.SetOrderImage(this.grdOrder);

                    this.mFocusRow = e.RowNumber;

                    PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));

                    #endregion

                    break;

                case "ord_danui":

                    string code = "";
                    string codename = "";

                    if (e.ChangeValue.ToString() == "")
                    {
                        this.mOrderBiz.GetDefaultOrdDanui(grid.GetItemString(e.RowNumber, "hangmog_code"), ref code, ref codename);

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
                        //insert by jc MIXされたオーダは行為部署変更が不可能にする。MIX解除してからやり直すようにMSG表示。
                        string current_mix_group = grid.GetItemString(e.RowNumber, "mix_group");
                        if (current_mix_group != "")
                        {
                            XMessageBox.Show("MIXされたオーダです。変更する場合はMIXを解除してからやり直してください。");
                            this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);
                            return;
                        }

                        /*//if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), this.dpkOrder_Date.GetDataValue().ToString()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part", movePart);
                        }*/
                    }
                    else if (e.ColName == "jundal_part_out")
                    {
                        /*//if (this.mOrderBiz.GetJundaTable("O", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable("O", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), this.dpkOrder_Date.GetDataValue().ToString()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_out", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_out", movePart);
                        }*/
                    }
                    else if (e.ColName == "jundal_part_inp")
                    {
                        /*//if (this.mOrderBiz.GetJundaTable("I", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable("I", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), this.dpkOrder_Date.GetDataValue().ToString()).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_inp", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_inp", movePart);
                        }*/
                    }

                    break;
                //inser by jc [一般名に変更できる項目であれば一般名に変更する。] 2012/11/01

                //case "general_disp_yn":
                //    if (grid.GetItemString(e.RowNumber, "general_disp_yn") == "Y")
                //    {
                //        string generic_name = mHangmogInfo.GetGenericName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                //        if (generic_name != "")
                //        {
                //            grid.SetItemValue(e.RowNumber, "hangmog_name", generic_name);
                //        }
                //    }
                //    else
                //    {
                //        string hangmog_name = mHangmogInfo.GetHangmogName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                //        if (hangmog_name != "")
                //        {
                //            grid.SetItemValue(e.RowNumber, "hangmog_name", hangmog_name);
                //        }
                //    }
                //    break;

                //case "hubal_change_yn":
                //    if (grid.GetItemString(e.RowNumber, "hubal_change_yn") == "Y")
                //    {
                //        grid.SetItemValue(e.RowNumber, "general_disp_yn", "N");

                //        string hangmog_name = mHangmogInfo.GetHangmogName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                //        if (hangmog_name != "")
                //        {
                //            grid.SetItemValue(e.RowNumber, "hangmog_name", hangmog_name);
                //        }
                //    }
                //    break;
                case "dv":
                    if (e.DataRow["donbog_yn"].ToString() == "Y")
                    {
                        Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                        if (tabInfo.Contains("dv"))
                            tabInfo.Remove("dv");

                        tabInfo.Add("dv", e.ChangeValue.ToString());

                    }
                    break;

            }

            //this.ReGroupingMix(0, this.grdOrder.RowCount - 1, false);

            this.SetMixOrderValue(grid, e.RowNumber, e.ColName, e.ChangeValue.ToString());

            this.MakePreviewStatus();
        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (e.ColName == "powder_yn")
            {

            }
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
                    //!this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay))
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
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                        e.Protect = true;
                    break;
                case "dv_2":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 2)
                            e.Protect = true;
                    }
                    break;
                case "dv_3":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 3)
                            e.Protect = true;
                    }
                    break;
                case "dv_4":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 4)
                            e.Protect = true;
                    }
                    break;

                //2012/12/10
                case "dv_5":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 5)
                            e.Protect = true;
                    }
                    break;
                case "dv_6":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 6)
                            e.Protect = true;
                    }
                    break;
                case "dv_7":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 7)
                            e.Protect = true;
                    }
                    break;
                case "dv_8":
                    if (this.IsOutDrugGroup(grd.GetItemString(e.RowNumber, "group_ser")) || grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt(dv) == false)
                        e.Protect = true;
                    else
                    {
                        if (int.Parse(dv) < 8)
                            e.Protect = true;
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

                    /*if (this.dpkOrder_Date.GetDataValue() == "")
                    {
                        return;
                    }*/

                    this.OpenScreen_OCS0103Q00(grid.GetItemString(e.RowNumber, e.ColName), true); // 화면오픈

                    break;

                case "ord_danui_name":  // 오더단위

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part": // 전달파트

                    // 외래 전달 파트 
                    if (this.IOEGUBUN == "O")
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    // 입원 전달파트 
                    else
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "jundal_part_out": // 전달파트 외래

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part_inp": // 전달파트 입원

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "bogyong_code_sub":

                    e.Cancel = false;

                    //if (grid.GetItemString(e.RowNumber, "hangmog_code") != "" && grid.GetItemString(e.RowNumber, "input_control") == "A")
                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "")
                    {
                        this.OpenScreen_CHT0117Q00(grid.GetItemString(e.RowNumber, "order_gubun_bas"));
                    }
                    break;
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
                    //loadParams.Add("remark_info", this.grdOrder.GetItemString(e.RowNumber, "order_remark")); // 

                    grd.SetReservedMemoControlLoadParam(e.ColName, loadParams);

                    break;
            }
        }

        private void grdOrder_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName != "suryang")
            {
                XEditGrid grid = sender as XEditGrid;
                string changeValue = e.ChangeValue.ToString();
                switch (e.ColName)
                {
                    case "general_disp_yn":
                        if (changeValue == "Y")
                        {
                            string generic_name = mHangmogInfo.GetGenericName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                            if (generic_name != "")
                            {
                                grid.SetItemValue(e.RowNumber, "hangmog_name", generic_name);
                            }
                        }
                        else
                        {
                            string hangmog_name = mHangmogInfo.GetHangmogName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                            if (hangmog_name != "")
                            {
                                grid.SetItemValue(e.RowNumber, "hangmog_name", hangmog_name);
                            }
                        }
                        break;

                    case "hubal_change_yn":
                        if (changeValue == "Y")
                        {
                            grid.SetItemValue(e.RowNumber, "general_disp_yn", "N");

                            string hangmog_name = mHangmogInfo.GetHangmogName(grid.GetItemString(e.RowNumber, "hangmog_code"));

                            if (hangmog_name != "")
                            {
                                grid.SetItemValue(e.RowNumber, "hangmog_name", hangmog_name);
                            }
                        }
                        break;
                }
            }
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

        private void cboQueryCon_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
            this.Search_text();
            if (this.rbnOftenOrder.Checked == true)
                this.grdSangyongOrder.QueryLayout(true);
        }

        private void cboSearchCondition_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
            this.Search_text();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Search_text();
            }
        }

        private void rbtSyouhin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtGenericSearch.Checked == true)
                mGenericSearchYN = "Y";
            else
                mGenericSearchYN = "N";

            this.txtSearch.Focus();
            this.Search_text();
        }

        private void btnNewSelect_Click(object sender, EventArgs e)
        {
            /*this.btnList.PerformClick(FunctionType.Process);*/

            this.btnSelect.PerformClick();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            XGrid grid = null;
            int applyRow = -1;

            if (this.tabGroup.SelectedTab == null)
            {
                /*this.btnList.PerformClick(FunctionType.Process);*/
            }

            // 현재 선택된 그리드의 항목코드 셋팅
            if (rbnOftenOrder.Checked == true)
            {
                grid = this.grdSangyongOrder as XGrid;
            }


            if (grid == null)
                return;

            if (grid.RowCount <= 0 ||
                grid.CurrentRowNumber < 0) return;

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

            if (emptyNewCell != null)
                applyRow = emptyNewCell.Row;
            else
            {
                applyRow = this.grdOrder.InsertRow(-1);
                this.GridInitValueSetting(grdOrder, applyRow);
                //this.grdOrder.AcceptData();
            }

            //this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), applyRow, false);
            //this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), this.grdOrder.CurrentRowNumber, false);
            // modify by jc [一般名検索追加]
            this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), this.grdOrder.CurrentRowNumber, false, this.mGenericSearchYN);

            PostCallHelper.PostCall(new PostMethodInt(this.PostOrderInsert), applyRow);

            //this.MakePreviewStatus();
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

                    this.DisplayOrderGridGroupInfo((Hashtable)(tpg.Tag));

                    //Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                    //if (groupInfo.Contains("wonyoi_order_yn") && groupInfo["wonyoi_order_yn"].ToString() == "Y")
                    //{
                    //    this.mDefaultWonyoiOrder = "Y";
                    //    this.btnChangeWonyoi.Text = "院内に変更";
                    //    this.dbxWonyoiOrderYN.SetDataValue("【院外処方】");
                    //}
                    //else
                    //{
                    //    this.mDefaultWonyoiOrder = "N";
                    //    this.btnChangeWonyoi.Text = "院外に変更";
                    //    this.dbxWonyoiOrderYN.SetDataValue("【院内処方】");
                    //}

                    // 해당 그룹의 젤 마지막 로우로 포커스 이동
                    //PostCallHelper.PostCall(new PostMethodInt(this.PostTabSelection), this.mOrderFunc.GetLastRow(this.grdOrder.LayoutTable, ((Hashtable)tpg.Tag)["group_ser"].ToString()));
                }
                else
                {
                    tpg.ImageIndex = 1;
                }
            }

            //this.setFocusGotoColumn();
        }

        private void tabGroup_SelectionChanging(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null)
                return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (groupInfo.Contains("nalsu") && groupInfo["nalsu"].ToString() != this.cboNalsu.GetDataValue())
            {
                this.cboNalsu.AcceptData();
            }

            if (groupInfo.Contains("bogyong_code") && groupInfo["bogyong_code"].ToString() != this.fbxBogyongCode.GetDataValue())
            {
                this.fbxBogyongCode.AcceptData();
            }

            if (groupInfo.Contains("emergency") && groupInfo["emergency"].ToString() != this.cbxEmergency.GetDataValue())
            {
                this.cbxEmergency.AcceptData();
            }

            if (groupInfo.Contains("wonyoi_order_yn") && groupInfo["wonyoi_order_yn"].ToString() != this.cbxWonyoiOrderYN.GetDataValue())
            {
                this.cbxWonyoiOrderYN.AcceptData();
            }
        }

        private void cbxWonyoiOrderYN_CheckedChanged(object sender, EventArgs e)
        {
            //院内､院外処方同時防止機能
            if (this.tabGroup.TabCount > 1)
            {
                string firstGroupWonyoi_Yn = "";

                for (int i = 0; i < this.tabGroup.TabCount; i++)
                {
                    if (this.tabGroup.SelectedIndex != i)
                    {
                        firstGroupWonyoi_Yn = ((Hashtable)this.tabGroup.TabPages[i].Tag)["wonyoi_order_yn"].ToString();
                        break;
                    }
                }

                if (firstGroupWonyoi_Yn != this.cbxWonyoiOrderYN.GetDataValue())
                {
                    if (XMessageBox.Show(XMsg.GetMsg("M036"), XMsg.GetField("F001"), MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        //if (this.cbxWonyoiOrderYN.GetDataValue() == "Y")
                        //    this.cbxWonyoiOrderYN.SetDataValue("N");
                        //else
                        //    this.cbxWonyoiOrderYN.SetDataValue("Y");
                        if (this.tabGroup.SelectedTab == null) return;
                        this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "wonyoi_order_yn", this.cbxWonyoiOrderYN.GetDataValue(), "", "", "");
                    }
                    else
                        //this.btnChangeWonyoi.PerformClick();

                        return;
                }
            }
            if (this.tabGroup.SelectedTab == null) return;

            this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "wonyoi_order_yn", this.cbxWonyoiOrderYN.GetDataValue(), "", "", "");
        }

        private void tabGroup_ClosePressed(object sender, EventArgs e)
        {
            IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;

            this.DeleteCurrentGroupTab(control.SelectedTab);
        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCS1003Q09(false);
        }

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCS0301Q09();
        }

        private void btnJungsiDrug_Click(object sender, EventArgs e)
        {
            OpenScreen_OCS1023U00(this.mPatientInfo.GetPatientInfo["bunho"].ToString(), this.mPatientInfo.GetPatientInfo["gwa"].ToString());
        }

        private void btnBroughtDrg_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.mPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("gwa", this.mPatientInfo.GetPatientInfo["gwa"].ToString());
            param.Add("auto_close_yn", "Y");
            param.Add("input_tab", INPUTTAB);
            param.Add("mode", "select");

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS1024U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void btnNalsu_Click(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null) return;
            if (!this.IsSelectedRowForNalsu()) return;
            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 현재 그리드에 해당 그룹의 오더가 없는경우 
            // 즉 빈 그룹인경우 오더를 입력하라는 메세지
            if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, groupInfo["group_ser"].ToString()))
            {
                //오더코드를 먼저 입력해 주세요.
                MessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));
                return;
            }
            if (!this.IsSelectedDiffHopeDate())
            {
                //選択したオーダの中希望日が異なるオーダが存在します。
                MessageBox.Show(XMsg.GetMsg("M014"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));
                return;
            }

            // 먼저 주사방법이 결정되어야 한다.
            if (this.fbxBogyongCode.GetDataValue() == "")
            {
                // 먼저 주사방법을 입력해 주세요.
                MessageBox.Show(XMsg.GetMsg("M005"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));
                return;
            }
            OrderVariables.Objects objects = new OrderVariables.Objects(this.grdOrder, this.grdOrder.CurrentRowNumber, this.grdOrder.GetItemString(0, "order_date")
                                                                      , 1, this.grdOrder.GetItemString(0, "jundal_table")
                                                                      , this.grdOrder.GetItemString(0, "order_gubun_bas")
                                                                      , this.grdOrder.GetItemString(0, "home_care_yn"));

            PostCallHelper.PostCall(new PostMethodObject(PostNalsuValidating), objects);
            PostCallHelper.PostCall(new PostMethod(PostNalsuValidating));
        }

        private void fbxBogyongCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (this.tabGroup.SelectedTab == null)
            {
                // 현재 선택된 그룹이 없는경우.
                // 그룹을 만들어버리자.

                /*this.btnList.PerformClick(FunctionType.Process);*/
            }

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (e.DataValue == "")
            {
                this.dbxBogyongName.SetDataValue("");

                this.ApplyGroupInfo("", "", "", this.cboNalsu.GetDataValue(), this.cbxEmergency.GetDataValue()
                                   , this.cbxWonyoiOrderYN.GetDataValue(), "", "");

                XMessageBox.Show("");
                //this.SetMsg("");

                // 외용 내복에 따른 그룹항목 visible Setting 
                this.SetGroupControlVisible(groupInfo["group_ser"].ToString());
                return;
            }

            string bogyongname = "";
            int dv = 0;
            string donbogyn = "";

            if (this.mOrderBiz.GetBogyongInfo(e.DataValue, ref bogyongname, ref dv, ref donbogyn) == false)
            {
                //복용코드가 정확하지 않습니다.
                MessageBox.Show(XMsg.GetMsg("M003"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                /*this.SetMsg(XMsg.GetMsg("M003"), MsgType.Error);*/

                e.Cancel = true;
            }
            else
            {
                this.dbxBogyongName.SetDataValue(bogyongname);

                this.ApplyGroupInfo(e.DataValue, bogyongname, dv.ToString(), this.cboNalsu.GetDataValue()
                                   , this.cbxEmergency.GetDataValue(), this.cbxWonyoiOrderYN.GetDataValue(), donbogyn, "");

                /*this.SetMsg("");*/



                // 외용 내복에 따른 그룹항목 visible Setting 
                this.SetGroupControlVisible(groupInfo["group_ser"].ToString());

                PostCallHelper.PostCall(new PostMethod(PostBogyongCodeValidating));
            }
        }

        private void fbxBogyongCode_FindClick(object sender, CancelEventArgs e)
        {
            this.OPEN_DRG0208Q00();
        }

        private void xLabel8_Click(object sender, EventArgs e)
        {
            this.OPEN_DRG0208Q00();
        }

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

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (this.mIsExtended)
            {
                /*this.pnlOrderInfo.Size = new Size(this.OrderNormalWidth, this.pnlOrderInfo.Size.Height);
                this.btnExtend.ImageIndex = 3;*/
                this.mIsExtended = false;
            }
            else
            {
                /*this.pnlOrderInfo.Size = new Size(this.OrderExtendWidth, this.pnlOrderInfo.Size.Height);
                this.btnExtend.ImageIndex = 4;*/
                this.mIsExtended = true;
            }
            this.grdOrder.Refresh();
        }

        private void btnExpandSearch_Click(object sender, EventArgs e)
        {
            if (this.mIsSearchExtended == false)
            {
                this.btnExpandSearch.ImageIndex = 3;
                /*this.pnlOrderInfo.Size = new Size(this.OrderMinWidth, this.pnlOrderInfo.Size.Height);

                this.grdDrgOrder.AutoSizeColumn(1, this.DrgHangmogNameMaxWidth);
                this.grdSearchOrder.AutoSizeColumn(1, this.SearchHangmogNameMaxWidth);
                this.grdSearchOrder.AutoSizeColumn(2, this.SearchHangmogNameMaxWidth);*/
                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogMaxWidth);
                /*this.grdPreview.AutoSizeColumn(1, this.PreviewHangmogMaxWidth);*/

                this.mIsSearchExtended = true;
            }
            else
            {
                this.btnExpandSearch.ImageIndex = 4;
                /*this.pnlOrderInfo.Size = new Size(this.OrderNormalWidth, this.pnlOrderInfo.Size.Height);

                this.grdDrgOrder.AutoSizeColumn(1, this.DrgHangmogNameNormalWidth);
                this.grdSearchOrder.AutoSizeColumn(1, this.SearchHangmogNameNormalWidth);
                this.grdSearchOrder.AutoSizeColumn(2, this.SearchHangmogNameNormalWidth);*/
                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogNormalWidth);
                /*this.grdPreview.AutoSizeColumn(1, this.PreviewHangmogNormalWidth);*/

                this.mIsSearchExtended = false;
            }
        }

        #endregion

        #region Method
        private void PostLoad()
        {
            //MessageBox.Show("PostLoad Start");

            /// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

            /*if (this.OpenParam != null) // 다른 화면에서 콜되는 경우
            {*/
                //this.btnList.PerformClick(FunctionType.Query);

                this.MakeGroupTabInfo(IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);
            /*}*/

            if (this.grdOrder.RowCount > 0)
            {
                /*this.btnList.PerformClick(FunctionType.Process);*/
            }


            // 오더가 있는경우는 디폴트가 오더 상황
            // 없는 경우는 디폴트가 오더검색
            //DataRow[] dr = grdOrder.LayoutTable.Select("input_gubun = '" + mInputGubun + "'");

            //if (this.grdOrder.RowCount > 0)
            //if (dr.Length > 0)
            //{
            //    if (this.rbnOrderStatus.Checked == false)
            //    {
            //        this.rbnOrderStatus.Checked = true;
            //    }
            //}
            //else
            //{
            //    if (this.rbnSearchOrder.Checked == false)
            //    {
            //        this.rbnSearchOrder.Checked = true;
            //    }
            //}
            this.txtSearch.Focus();
            this.setFocusGotoColumn();
        }

        private void setFocusGotoColumn()
        {
            //insert by jc [OCS1003P01のデータウインドーウで選択されたROWがあった場合の処理]
            //位置検索はすべてhangmog_codeで検索する
            //不均等オーダ、コメントのROWにもOrderBizで該当するHangmog_codeを入れているので検索可能である。
            //カーソルのコントロールの際にはgrdOrder, grdPreviewのグリドを同時に動かす。
            //pkocskeyは使えない。なぜかというとpkocskeyは保存される際、トリガーによって与えられるので保存されてない状態では使えないのだ
            //bogyong_code_ynは服用コードであるROWだけがYである。OrderBizで設定。

            int currentRow = -1;
            int currentPreviewRow = -1;
            if (mCurrentRowNum > 0)
            {
                //[OCS1003P01のデータウインドウで選択されたcolumnのデータ取得]
                string currentData = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, this.mCurrentColName);

                //[OCS1003P01のデータウインドウで選択されたgroup_ser取得]
                string currentGroupSer = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "group_ser_num");

                //[該当するGROUPTABに移動]
                this.SelectGroupTab(currentGroupSer);
                //[OCS1003P01のデータウインドウで選択されたデータの位置検索]
                if (this.mCurrentColName == "hangmog_name"
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_detail")
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_info"))
                {
                    //[OCS1003P01のデータウインドウで選択されたhangmog_name取得]
                    string currentHangmogCode = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "hangmog_code");

                    //オーダ登録グリドから検索
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.GetItemString(i, "hangmog_code") == currentHangmogCode && this.grdOrder.GetItemString(i, "group_ser") == currentGroupSer)
                        {
                            currentRow = i;
                            break;
                        }
                    }
                    /*//オーダプリヴューグリドから検索
                    if (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "input_tab") == "01"
                        || this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "input_tab") == "03")
                    {
                        for (int j = 0; j < this.grdPreview.RowCount; j++)
                        {
                            if (this.grdPreview.GetItemString(j, "row_num") == currentRow.ToString())
                            {
                                currentPreviewRow = j;
                                break;
                            }
                        }
                    }*/
                }

                //フォーカス設定
                switch (this.mCurrentColName)
                {
                    case "hangmog_name":
                        /*if (currentPreviewRow >= 0)
                            this.grdPreview.SetFocusToItem(currentPreviewRow, "hangmog_name", true);*/
                        this.grdOrder.SetFocusToItem(currentRow, "hangmog_code", true);
                        break;
                    case "order_detail":
                        if (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "Y")
                        {
                            this.cboNalsu.Focus();
                        }
                        else
                        {
                            /*if (currentPreviewRow >= 0)
                                this.grdPreview.SetFocusToItem(currentPreviewRow, "suryang", true);*/
                            this.grdOrder.SetFocusToItem(currentRow, "suryang", true);
                        }
                        break;
                    case "order_info":
                        //コメント
                        if (currentData.Substring(0, 1) == "└")
                        {
                            /*if (currentPreviewRow >= 0)
                                this.grdPreview.SetFocusToItem(currentPreviewRow, "hangmog_name", true);*/
                            this.grdOrder.SetFocusToItem(currentRow, "order_remark", true);
                        }
                        //不均等オーダ
                        else if (currentData.Substring(1, 1) == "※")
                        {
                            /*if (currentPreviewRow >= 0)
                                this.grdPreview.SetFocusToItem(currentPreviewRow, "hangmog_name", true);*/
                            this.grdOrder.SetFocusToItem(currentRow, "dv_1", true);
                        }
                        //希望日
                        else if (currentData.Substring(1, 1) == "希")
                        {
                            /*if (currentPreviewRow >= 0)
                                this.grdPreview.SetFocusToItem(currentPreviewRow, "hangmog_name", true);*/
                            this.grdOrder.SetFocusToItem(currentRow, "hope_date", true);
                        }
                        //服用コード
                        else
                            this.fbxBogyongCode.Focus();
                        break;
                }
            }
        }

        #region GetGrdOrder
        /// <summary>
        /// GetGrdOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOrder(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U13GrdOrderListArgs args = new OCS0103U13GrdOrderListArgs();
            args.FkInOutKey = bvc["fk_in_out_key"].VarValue;
            args.InputTab = bvc["input_tab"].VarValue;
            args.YaksokCode = bvc["yaksok_code"].VarValue;
            args.OrderMode = ((int)this.mOrderMode).ToString();
            args.InputGubun = bvc["input_gubun"].VarValue;
            args.Memb = bvc["memb"].VarValue;
            OCS0103U13GrdOrderListResult res = CloudService.Instance.Submit<OCS0103U13GrdOrderListResult,
                OCS0103U13GrdOrderListArgs>(args);

            // UT
            //OCS0103U13GrdOrderListArgs args = new OCS0103U13GrdOrderListArgs();
            //args.FkInOutKey = "001";
            //args.InputTab = "04";
            //args.YaksokCode = "04/10010/1/204";
            //args.OrderMode = "1";
            //args.InputGubun = "1";
            //args.Memb = "10010";
            //OCS0103U13GrdOrderListResult res = CloudService.Instance.Submit<OCS0103U13GrdOrderListResult,
            //    OCS0103U13GrdOrderListArgs>(args);

            if (null != res)
            {
                foreach (OCS0103U13GrdOrderListInfo item in res.GrdOrderListItem)
                {
                    lObj.Add(new object[]
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
                        //item.SunabCheck2,
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
                        //item.OrderByKey,
                        //item.RowState,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdSangyongOrder
        /// <summary>
        /// GetGrdSangyongOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
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

        #region GetSearchWordForSpecimen
        /// <summary>
        /// GetSearchWordForSpecimen
        /// </summary>
        /// <param name="aSearchWord"></param>
        /// <returns></returns>
        private string GetSearchWordForSpecimen(string aSearchWord)
        {
            string searchWord = string.Empty;

            OCS0103U13FnAdmConvertKanaFullArgs fnArg = new OCS0103U13FnAdmConvertKanaFullArgs();
            fnArg.SearchWord = aSearchWord;
            OCS0103U13FnAdmConvertKanaFullResult fnRes = CloudService.Instance.Submit<OCS0103U13FnAdmConvertKanaFullResult,
                OCS0103U13FnAdmConvertKanaFullArgs>(fnArg);

            if (null != fnRes)
            {
                searchWord = fnRes.Result;
            }

            return searchWord;
        }
        #endregion

        private void Search_text()
        {
            if (this.cboSearchCondition.SelectedValue != null)
            {
                string searchText = this.txtSearch.GetDataValue();

                if (searchText == "" && this.rbnOftenOrder.Checked)
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
                    }
                }
                PostCallHelper.PostCall(new PostMethod(PostSearchValidating));
            }
        }
        private void LoadOftenUseOrder(string aMembGubun, string aMemb, string aOrderGubun, string aWonnaeDrgYn, string aSearchWord)
        {
            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);
            //insert by jc [検索条件追加] 2012/10/15
            //DataTable dtSangyongData = this.mOrderBiz.LoadOftenUsedInfo(aMembGubun, aMemb, aOrderGubun, aWonnaeDrgYn, TypeCheck.NVL(aSearchWord, "%").ToString(), this.cboSearchCondition.SelectedValue.ToString());

            //if (dtSangyongData != null && dtSangyongData.Rows.Count > 0)
            //{
            //    this.grdSangyongOrder.ImportRowRange(dtSangyongData, 0);
            //    this.grdSangyongOrder.ResetUpdate();
            //    this.grdSangyongOrder.DisplayData();
            //}
        }

        private void PostSearchValidating()
        {
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

        private void ApplySangOrderInfo(string aHangmogCode, int aApplyRow, bool aIsApplyCurrentRow, string aGenericSearchYN)
        {
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;
            this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = this.cbxWonyoiOrderYN.GetDataValue();

            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder)
                this.mHangmogInfo.Parameter.Ho_dong = this.mPatientInfo.GetPatientInfo["ho_dong"].ToString();

            if (this.mGeneral_disp_yn == "Y" && this.mOrderBiz.IsGeneralYN(aHangmogCode) != "")
                this.mHangmogInfo.Parameter.GenericSearchYN = "Y";
            else
                this.mHangmogInfo.Parameter.GenericSearchYN = this.mGenericSearchYN;

            if (this.rbtGenericSearch.Checked == true || this.mHangmogInfo.Parameter.GenericSearchYN == "Y")
                this.mHangmogInfo.Parameter.Generic_name = this.mOrderBiz.IsGeneralYN(aHangmogCode);

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
            //insert by jc [一般名検索追加] 2012/11/01
            loadExtraInfo.LayoutItems.Add("hangmog_name", DataType.String);
            loadExtraInfo.LayoutItems.Add("group_ser", DataType.String);
            loadExtraInfo.LayoutItems.Add("bogyong_code", DataType.String);
            loadExtraInfo.LayoutItems.Add("dv", DataType.String);
            loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
            loadExtraInfo.LayoutItems.Add("wonyoi_order_yn", DataType.String);

            loadExtraInfo.InitializeLayoutTable();

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            loadExtraInfo.InsertRow(-1);

            // 항목정보
            loadExtraInfo.SetItemValue(0, "hangmog_code", aHangmogCode);
            // 그룹정보 로드
            // 그룹시리얼
            if (groupInfo.Contains("group_ser"))
            {
                loadExtraInfo.SetItemValue(0, "group_ser", groupInfo["group_ser"].ToString());
            }
            // 복용코드
            if (groupInfo.Contains("bogyong_code"))
            {
                loadExtraInfo.SetItemValue(0, "bogyong_code", groupInfo["bogyong_code"].ToString());
            }
            // DV
            if (groupInfo.Contains("dv"))
            {
                //グループが違う場合もあるのでdvを受け継がない。
                //if (groupInfo["dv"].ToString() == "")
                //    loadExtraInfo.SetItemValue(0, "dv", this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "dv"));
                //else
                if (groupInfo["dv"].ToString() != "")
                    loadExtraInfo.SetItemValue(0, "dv", groupInfo["dv"].ToString());
            }
            else
            {
                if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, groupInfo["group_ser"].ToString()) == false)
                {
                    loadExtraInfo.SetItemValue(0, "dv", this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "dv"));
                }
            }
            // Emergency
            if (groupInfo.Contains("emergency"))
            {
                loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
            }
            // 원외처방여부
            if (groupInfo.Contains("wonyoi_order_yn"))
            {
                loadExtraInfo.SetItemValue(0, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());
            }

            #endregion

            if (this.mHangmogInfo.LoadHangmogInfo(HangmogInfo.ExecutiveMode.CodeInput, loadExtraInfo) == false)
            {
                return;
            }

            this.ApplyDefaultOrderInfo(HangmogInfo.ExecutiveMode.CodeInput, this.mHangmogInfo.GetHangmogInfo, this.grdOrder, aApplyRow, aIsApplyCurrentRow);

            // 이거 다 해놓고
            // 그룹이벤트를 다시 태워야 하네...
            //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            this.DisplayMixGroup(this.grdOrder);

            this.SetOrderImage(this.grdOrder);

            PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyDefaultOrderInfo(IHIS.OCS.HangmogInfo.ExecutiveMode aExecutivemode, MultiLayout aSourceLayout, XEditGrid aDestGrid, int aRowNumber, bool aIsCallCodeInput)
        {
            //string ordergubunname = "";  // 헤더를 붙인 오더구분을 넣는다.
            int currRow = aRowNumber;
            int startRow = aRowNumber;
            Hashtable groupInfo = null;

            if (this.tabGroup.SelectedTab == null)
                /*this.btnList.PerformClick(FunctionType.Process);*/

                groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (aSourceLayout.RowCount <= 0) return;

            // 그리드 상에서 직접 입력할때와 뭔가를 통해 입력할때...
            // 어디다 집어 넣어야 할지에 대한 헷갈림...
            // 직접 넣을 때는 현재 로우에 무조건 넣어야 하는데...
            // 근데... 뭔가를 통해서 넣을때는 현재 로우에 데이터가 있으면 안되거덩...
            // 그래서 저 컬럼을 두고 aIsCallCodeInput 이 true이면 무조건 현재 로우에 넣는거야...
            // 그거는 그리드에서 컬럼 체인지 탈때만...
            if (aIsCallCodeInput == false)
            {
                XCell newCell = this.mOrderFunc.GetEmptyNewRow(aDestGrid);

                if (newCell != null)
                {
                    currRow = newCell.Row;
                    startRow = newCell.Row;
                }
                else
                {
                    this.OrderGridCreateNewRow(-1);
                    currRow = this.grdOrder.CurrentRowNumber;
                    startRow = this.grdOrder.CurrentRowNumber;
                }
            }
            else
            {
                currRow = aRowNumber;
                startRow = aRowNumber;
            }

            for (int i = 0; i < aSourceLayout.RowCount; i++)
            {

                if (i != 0)
                {
                    this.OrderGridCreateNewRow(-1);
                    currRow = this.grdOrder.CurrentRowNumber;
                }

                if (IsExistDifferntDrugGroup(groupInfo["group_ser"].ToString(), aSourceLayout.GetItemString(i, "order_gubun_bas")) == true)
                {
                    //같은그룹에 외용약과 내복약은 혼재할 수 없습니다.
                    MessageBox.Show(XMsg.GetMsg("M009"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.grdOrder.DeleteRow(this.grdOrder.CurrentRowNumber);
                    return;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                {
                    return;
                }

                if (this.fbxBogyongCode.GetDataValue() == "" && aSourceLayout.LayoutTable.Columns.Contains("default_bogyong_code") && aSourceLayout.GetItemString(i, "default_bogyong_code") != "")
                {
                    this.fbxBogyongCode.SetEditValue(aSourceLayout.GetItemString(i, "default_bogyong_code"));
                    this.fbxBogyongCode.AcceptData();

                    groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
                }

                foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                {
                    if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        this.grdOrder.LayoutTable.Rows[currRow][cl.ColumnName] = aSourceLayout.LayoutTable.Rows[i][cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (aSourceLayout.GetItemString(i, "order_gubun").Length < 2)
                    this.grdOrder.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, currRow) + aSourceLayout.GetItemString(i, "order_gubun");
                else
                    this.grdOrder.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, currRow) + aSourceLayout.GetItemString(i, "order_gubun").Substring(1, 1);

                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
                {
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_table_out"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_table_inp"] = aSourceLayout.GetItemString(i, "jundal_table_inp");
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_part_out"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    this.grdOrder.LayoutTable.Rows[currRow]["jundal_part_inp"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                    this.grdOrder.LayoutTable.Rows[currRow]["move_part_out"] = aSourceLayout.GetItemString(i, "move_part");
                    this.grdOrder.LayoutTable.Rows[currRow]["move_part_inp"] = aSourceLayout.GetItemString(i, "move_part");
                }
                else
                {
                    // 외용이냐 내복이냐에 따라 일수표시에 대산 부분이 visible Setting 
                    // 현재 화면이 외래 모드인경우만 인서트     
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    else
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_inp");

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    else
                        this.grdOrder.LayoutTable.Rows[currRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                }

                if (this.grdOrder.LayoutTable.Rows[currRow]["order_gubun"].ToString().Substring(1, 1) == "C")
                {
                    if (groupInfo.Contains("donbog_yn") && groupInfo["donbog_yn"].ToString() == "Y")
                    {
                        this.grdOrder.LayoutTable.Rows[currRow]["dv_time"] = "*";
                    }
                    else
                    {
                        this.grdOrder.LayoutTable.Rows[currRow]["dv_time"] = "/";
                    }
                }
                else
                {
                    this.grdOrder.LayoutTable.Rows[currRow]["dv_time"] = "*";
                }


                //this.grdOrder.LayoutTable.Rows[currRow]["hope_date"] = this.GetNextDrugSyohoubi();

                this.grdOrder.DisplayData();

                if (this.tabGroup.SelectedTab.Tag != null)
                    this.ApplyGroupInfoToRow(groupInfo, currRow);

                this.mFocusRow = currRow;
            }

            this.mHangmogInfo.SetAlignMixGroup(this.grdOrder, startRow, currRow);

            this.grdOrder.DisplayData();

            // 외용, 내복에 따른 변경부분셋팅
            /*this.SetGroupControlVisible(groupInfo["group_ser"].ToString());*/
        }

        private void OrderGridCreateNewRow(int aRowNumber)
        {
            this.grdOrder.InsertRow(aRowNumber);

            // 그룹 기준 셋팅
            this.GridInitValueSetting(this.grdOrder, this.grdOrder.CurrentRowNumber);
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


            /*aGrid.SetItemValue(aRowNumber, "order_date", this.dpkOrder_Date.GetDataValue());*/
            aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);

            aGrid.SetItemValue(aRowNumber, "input_gubun", this.mInputGubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun_name", this.mInputGubunName);

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



                // 입력구분
                aGrid.SetItemValue(aRowNumber, "input_id", UserInfo.UserID);
                //aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);

                //aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                //aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);

                //aGrid.SetItemValue(aRowNumber, "order_date", this.dpkOrder_Date.GetDataValue());
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

            // nday occur yn   n데이 오더 발생여부
            aGrid.SetItemValue(aRowNumber, "nday_occur_yn", "N");
        }

        private void DisplayOrderGridGroupInfo(Hashtable aGroupInfo)
        {
            // 오더그리드의 오더항목 visible setting 
            this.mOrderFunc.SetGridRowVisibleByGroupSer(this.grdOrder, aGroupInfo["group_ser"].ToString(), this.mInputGubun);
            //this.mOrderFunc.SetGridRowVisibleByGroupSer(this.grdOrder, (Hashtable)this.tabGroup.SelectedTab.Tag, this.mInputGubun);

            // 그룹항목셋팅
            this.SetGroupControl(aGroupInfo);

            /*// 외용 내복에 따른 그룹항목 visible Setting 
            this.SetGroupControlVisible(aGroupInfo["group_ser"].ToString());

            // 그룹항목에 대하여 프로텍트 여부 
            this.ProtectGroupControl(aGroupInfo["group_ser"].ToString());

            // dc 구분관련 보일것인가 말것인가..
            this.ShowDcGubun(this.grdOrder, (aGroupInfo["group_ser"].ToString()));*/
        }

        /// <summary>
        /// 그룹탭 선택시 그룹관련 정보들 셋팅
        /// </summary>
        /// <param name="aGroupInfo">그룹정보</param>
        private void SetGroupControl(Hashtable aGroupInfo)
        {
            // 복용코드
            this.fbxBogyongCode.SetDataValue(aGroupInfo["bogyong_code"].ToString());
            // 복용명칭
            this.dbxBogyongName.SetDataValue(aGroupInfo["bogyong_name"].ToString());
            // 날수
            this.cboNalsu.SetDataValue(aGroupInfo["nalsu"].ToString());
            /*this.cbxEmergency.CheckedChanged -= new EventHandler(cbxEmergency_CheckedChanged);
            // 긴급여부
            this.cbxEmergency.SetDataValue(aGroupInfo["emergency"].ToString());
            this.cbxEmergency.CheckedChanged += new EventHandler(cbxEmergency_CheckedChanged);
            this.cbxWonyoiOrderYN.CheckedChanged -= new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
            // 원외오더
            this.cbxWonyoiOrderYN.SetDataValue(aGroupInfo["wonyoi_order_yn"].ToString());
            this.cbxWonyoiOrderYN.CheckedChanged += new EventHandler(cbxWonyoiOrderYN_CheckedChanged);*/
        }

        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        /// 
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

        private void SetOrderImage(XEditGrid aGrid)
        {

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (aGrid.GetItemString(i, "general_disp_yn") == "Y")
                {
                    //aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = "医師オーダ" + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
                    aGrid[i, "hangmog_name"].ToolTipText = "商品名：" + mHangmogInfo.GetHangmogName(aGrid.GetItemString(i, "hangmog_code"));
                }
            }

            // 의사가 입력하는 경우는 스킵
            if (this.mInputGubun.Substring(0, 1) == "D") return;

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                // 의사 오더인경우
                if (aGrid.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                {
                    /*aGrid[i + aGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[8];*/
                    aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = "医師オーダ" + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
                }

            }
        }

        private void PostOrderInsert()
        {
            int focusRow = -1;
            if (this.mFocusRow < 0)
                focusRow = this.grdOrder.RowCount - 1;
            else
                focusRow = mFocusRow;

            this.MakePreviewStatus();
            //this.grdOrder.SetFocusToItem(mFocusRow, "suryang", false);
        }

        private void PostOrderInsert(int aFocusRow)
        {
            int focusRow = -1;
            if (aFocusRow < 0)
                focusRow = this.grdOrder.RowCount - 1;
            else
                focusRow = aFocusRow;

            if (focusRow < 0) return;

            this.MakePreviewStatus();

            //this.grdOrder.SetFocusToItem(focusRow, "hangmog_code", false);
            this.grdOrder.SetFocusToItem(focusRow, "suryang", true);

            //insert by jc [オーダ登録時自動的に選択されるように（施行済み、希望日設定済みオーダは例外とする）]
            //for (int i = 0; i < this.grdOrder.RowCount; i++)
            //{
            //    if (this.grdOrder.GetItemString(i, "hope_date") == "" && this.grdOrder.GetItemString(i, "ocs_flag") != "3")
            //    {
            //        this.grdOrder.SelectRow(i);
            //    }
            //}
        }

        private void MakePreviewStatus()
        {
            /*if (this.pnlPreview.Visible == true)
            {
                this.layPreview.Reset();

                //modify by jc 2012/02/17 [既存ではINPUTGUBUNの値がなければOrderBizでデフォルト値としてD0を入れていたので
                //D0以外はPREVIEWのGRIDでオーダが見えなかったのでINPUTGUBNをパラメターとして入力してINPUTGUBUN別にPREVIEWが見えるように修正]
                //this.mOrderBiz.SetPreviewOrderData(INPUTTAB, this.grdOrder, this.layPreview);
                this.mOrderBiz.SetPreviewOrderData(this.IOEGUBUN, this.mInputGubun, INPUTTAB, this.grdOrder, this.layPreview);

                this.grdPreview.Reset();
                foreach (DataRow dr in this.layPreview.LayoutTable.Rows)
                {
                    this.grdPreview.LayoutTable.ImportRow(dr);
                }
                this.grdPreview.DisplayData();

                this.pnlPreview.Visible = true;
            }*/
        }

        private bool IsExistDifferntDrugGroup(string aGroupSer, string aOrderGubunBas)
        {
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.GetItemString(i, "order_gubun_bas") != "" &&
                    aOrderGubunBas != this.grdOrder.GetItemString(i, "order_gubun_bas") &&
                    aGroupSer == this.grdOrder.GetItemString(i, "group_ser"))
                {
                    if (i == this.grdOrder.CurrentRowNumber && this.grdOrder.GetItemString(i, "hangmog_code") == "")
                        continue;

                    return true;
                }
            }

            return false;
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

            if (aExistGroupInfo.Contains("bogyong_code"))
            {
                bogyongCode = aExistGroupInfo["bogyong_code"].ToString();
            }
            if (aExistGroupInfo.Contains("bogyong_name"))
            {
                bogyongName = aExistGroupInfo["bogyong_name"].ToString();
            }
            if (aExistGroupInfo.Contains("dv"))
            {
                dv = aExistGroupInfo["dv"].ToString();
            }
            if (aExistGroupInfo.Contains("nalsu"))
            {
                nalsu = aExistGroupInfo["nalsu"].ToString();
            }
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            {
                wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            }
            if (aExistGroupInfo.Contains("donbog_yn"))
            {
                donbog_yn = aExistGroupInfo["donbog_yn"].ToString();
            }

            // 접수하기 전의 오더만 가능
            // 주사방법을 기준으로 변경 가능한것만 그룹정보 업데이트 한다.
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, aSetRowNumber, "bogyong_code", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
            {
                // 복용코드
                if (this.grdOrder.GetItemString(aSetRowNumber, "bogyong_code") != bogyongCode)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "bogyong_code", bogyongCode);
                }

                // 복용법 명칭
                if (this.grdOrder.GetItemString(aSetRowNumber, "bogyong_name") != bogyongName)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "bogyong_name", bogyongName);
                }

                // DV
                if (this.IsOutDrugGroup(aExistGroupInfo["group_ser"].ToString()) == false)
                {
                    if (dv != "" && this.grdOrder.GetItemString(aSetRowNumber, "dv") != dv)
                    {
                        this.grdOrder.SetItemValue(aSetRowNumber, "dv", dv);
                    }
                }

                // 날수
                if (this.grdOrder.GetItemString(aSetRowNumber, "nalsu") != nalsu)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "nalsu", nalsu);
                }

                // 날수 셋팅에 따른 Nday_YN 설정.
                if (this.IOEGUBUN == "O")
                {
                    if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                    {
                        this.grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "Y");
                    }
                    else
                    {
                        this.grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "N");
                    }
                }
                // 긴급
                if (this.grdOrder.GetItemString(aSetRowNumber, "emergency") != emergency)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "emergency", emergency);
                }

                // 원외여부
                if (this.grdOrder.GetItemString(aSetRowNumber, "wonyoi_order_yn") != wonyoi_order_yn)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "wonyoi_order_yn", wonyoi_order_yn);
                }

                // 돈복여부
                if (this.grdOrder.GetItemString(aSetRowNumber, "donbog_yn") != donbog_yn)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "donbog_yn", donbog_yn);
                }
            }

            this.MakePreviewStatus();
        }

        private bool IsOutDrugGroup(string aGroupSer)
        {
            DataRow[] rows = this.grdOrder.LayoutTable.Select("group_ser=" + aGroupSer);

            if (rows.Length <= 0) return false;

            foreach (DataRow dr in rows)
            {
                if (dr["order_gubun"].ToString() != "" && dr["order_gubun"].ToString().Substring(1, 1) == "D")
                {
                    return true;
                }
            }

            return false;
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

        private void SetMixOrderValue(XEditGrid aGrid, int aSourceRowNum, string aColName, string aValue)
        {
            // Mix시 동기화가 필요한 컬럼
            if (aColName != "dv" &&
                aColName != "dv_time" &&
                aColName != "bogyong_code" &&
                aColName != "jusa" &&
                aColName != "jusa_spd_gubun" &&
                aColName != "nalsu" &&
                aColName != "emergency" &&
                aColName != "home_care_yn") return;

            if (this.tabGroup.SelectedTab == null) return;

            // 내복약이고 돈복인경우는 DV 횟수는 동기화 하지 않는다.
            //if (aColName == "dv" &&
            //    aGrid.GetItemString(aSourceRowNum, "order_gubun").PadLeft(2, '0').Substring(1, 1) == "C" &&
            //    aGrid.GetItemString(aSourceRowNum, "donbog_yn") == "Y")
            //{
            //    return;
            //}


            // Mix 기준
            string input_gubun = "", order_gubun = "", group_ser = "", mix_group = "", hope_date = "";

            if (aGrid.CellInfos.Contains("input_gubun")) input_gubun = aGrid.GetItemString(aSourceRowNum, "input_gubun").Trim();
            order_gubun = aGrid.GetItemString(aSourceRowNum, "order_gubun").Trim();
            group_ser = aGrid.GetItemString(aSourceRowNum, "group_ser").Trim();
            mix_group = aGrid.GetItemString(aSourceRowNum, "mix_group").Trim();
            if (aGrid.CellInfos.Contains("hope_date")) hope_date = aGrid.GetItemString(aSourceRowNum, "hope_date").Trim();

            string basic_order_gubun_bas = aGrid.GetItemString(aSourceRowNum, "order_gubun_bas");

            // 해당  항목의 값을 Setting 한다.
            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (aSourceRowNum != i &&
                    (!aGrid.CellInfos.Contains("input_gubun") || aGrid.GetItemString(i, "input_gubun").Trim() == input_gubun) &&
                    aGrid.GetItemString(i, "order_gubun").Trim() == order_gubun &&
                    aGrid.GetItemString(i, "group_ser").Trim() == group_ser &&
                    aGrid.GetItemString(i, "mix_group").Trim() == mix_group &&
                    (!aGrid.CellInfos.Contains("hope_date") || aGrid.GetItemString(i, "hope_date").Trim() == hope_date))
                {
                    // 수정가능여부 Check
                    if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                        this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    {
                        GridColumnProtectModifyEventArgs me = new GridColumnProtectModifyEventArgs(aColName, aSourceRowNum, aGrid.LayoutTable.Rows[aSourceRowNum], false);
                        grdOrder_GridColumnProtectModify(aGrid, me);

                        if (me.Protect) continue;
                    }

                    // 동일 오더인 경우는 기준 오더를 기준으로 데이타를 맞춘다 
                    if (aGrid.GetItemString(i, "order_gubun_bas").Trim() == basic_order_gubun_bas.ToString().Trim())
                    {
                        // N-day관련해서 주사인 경우에는 nalsu는 맞추지 않는다.
                        if (aColName == "nalsu" && this.mOrderBiz.IsDrugJusaCode(aGrid.GetItemString(i, "order_gubun_bas")) && aGrid.GetItemString(i, "home_care_yn") != "Y")
                            continue;

                        aGrid.SetItemValue(i, aColName, aValue);

                        switch (aColName)
                        {
                            case "dv":
                                //내복약인 경우 용법처리
                                if (this.mOrderBiz.IsDrugMediCode(aGrid.GetItemString(i, "order_gubun_bas")))
                                {
                                    aGrid.SetItemValue(i, "bogyong_code", aGrid.GetItemString(aSourceRowNum, "bogyong_code").Trim());
                                    if (aGrid.CellInfos.Contains("bogyong_name")) aGrid.SetItemValue(i, "bogyong_name", aGrid.GetItemString(aSourceRowNum, "bogyong_name").Trim());
                                }

                                break;

                            case "bogyong_code":
                                if (aGrid.CellInfos.Contains("bogyong_name")) aGrid.SetItemValue(i, "bogyong_name", aGrid.GetItemString(aSourceRowNum, "bogyong_name").Trim());

                                //내복약인 경우 DV 처리
                                if (this.mOrderBiz.IsDrugMediCode(aGrid.GetItemString(i, "order_gubun_bas")))
                                {
                                    aGrid.SetItemValue(i, "dv_time", aGrid.GetItemString(aSourceRowNum, "dv_time").Trim());
                                    aGrid.SetItemValue(i, "dv", aGrid.GetItemString(aSourceRowNum, "dv").Trim());
                                    aGrid.SetItemValue(i, "donbog_yn", aGrid.GetItemString(aSourceRowNum, "donbog_yn").Trim());
                                    //돈복인 경우 nalsu도 조정한다.
                                    if (aGrid.GetItemString(aSourceRowNum, "donbog_yn").Trim() == "Y")
                                        aGrid.SetItemValue(i, "nalsu", aGrid.GetItemString(aSourceRowNum, "nalsu").Trim());
                                }

                                break;

                            case "jusa":
                                if (aGrid.CellInfos.Contains("jusa_name")) aGrid.SetItemValue(i, "jusa_name", aGrid.GetItemString(aSourceRowNum, "jusa_name").Trim());
                                break;

                            //case "home_care_yn":

                            //    if (aValue.ToString() == "Y")
                            //    {
                            //        aGrid.SetItemValue(i, "jundal_part", "HOM");
                            //        if (aGrid.LayoutTable.Columns.Contains("jundal_part_name"))
                            //            aGrid.SetItemValue(i, "jundal_part_name", "HOM");
                            //    }
                            //    else
                            //    {
                            //        //aGrid.SetItemValue(i, "nalsu", 1);
                            //        // 날수는 왜 1로 바꿀까....
                            //        this.mOrderBiz.SetOrderGubunDefaultInfo("O", aGrid, i, aGrid.GetItemString(i, "order_gubun").Trim().PadRight(2).Substring(1, 1), this.cbxWonyoiOrderYN.GetDataValue(),"");
                            //    }
                            //    break;
                        }

                        //횟수 및 용법이 변경되는 경우 불균등 dv 수량을 Reset한다.
                        if (aColName == "dv" || aColName == "bogyong_code")
                        {
                            aGrid.SetItemValue(i, "dv_1", "");
                            aGrid.SetItemValue(i, "dv_2", "");
                            aGrid.SetItemValue(i, "dv_3", "");
                            aGrid.SetItemValue(i, "dv_4", "");

                            //2012/12/10
                            aGrid.SetItemValue(i, "dv_5", "");
                            aGrid.SetItemValue(i, "dv_6", "");
                            aGrid.SetItemValue(i, "dv_7", "");
                            aGrid.SetItemValue(i, "dv_8", "");
                        }
                    }

                }
            }
        }

        private void OpenScreen_CHT0117Q00(string aOrderGubun)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("order_gubun", aOrderGubun);

            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0117Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

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

        private void setSelectExistEmptyGroup()
        {
            //string emptyGroupSer = "";

            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                Hashtable groupInfo = tpg.Tag as Hashtable;

                if (this.grdOrder.RowCount > 0)
                {
                    DataRow[] dr = grdOrder.LayoutTable.Select("group_ser=" + groupInfo["group_ser"].ToString());
                    if (dr.Length <= 0)
                        this.tabGroup.SelectedTab = tpg;
                    else if (dr.Length == 1 && dr[0]["hangmog_code"].ToString() == "")
                        this.tabGroup.SelectedTab = tpg;
                }
            }
        }

        private void MakeNewOrderGroup(bool aIsShowFindDlg)
        {
            if (this.IsExistEmptyGroup())
            {
                this.setSelectExistEmptyGroup();
                return;
            }

            IHIS.X.Magic.Controls.TabPage tpg = new IHIS.X.Magic.Controls.TabPage();

            int groupSer = 1;
            if (mPatientInfo.GetPatientInfo != null)
            {
                if (this.IOEGUBUN == "O")
                    //groupSer = (this.mHangmogInfo.GetMaxGroupSer(this.grdOrder) + 1);
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mPatientInfo.GetPatientInfo["naewon_key"].ToString(), "OCS1003"));
                else
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mPatientInfo.GetPatientInfo["naewon_key"].ToString(), "OCS2003"));
            }
            if (groupSer == 1 || groupSer == 200)
                groupSer = 101;

            //tpg.Title = System.Resources.groupSer1 + groupSer.ToString() + System.Resources.groupSer2;
            tpg.Title = groupSer.ToString() + " グループ";
            Hashtable groupInfo = new Hashtable();

            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", tpg.Title);
            groupInfo.Add("bogyong_code", "");
            groupInfo.Add("bogyong_name", "");
            groupInfo.Add("emergency", "N");
            groupInfo.Add("nalsu", "0");
            //groupInfo.Add("dv", "1");
            //if (this.IOEGUBUN == "O")
            //    groupInfo.Add("wonyoi_order_yn", "Y");
            //else
            //    groupInfo.Add("wonyoi_order_yn", "N");
            //同じ院外オーダフラグを受け継ぐ
            if (grdOrder.GetItemString(0, "wonyoi_order_yn") != "")
                groupInfo.Add("wonyoi_order_yn", grdOrder.GetItemString(0, "wonyoi_order_yn").ToString());
            else
                groupInfo.Add("wonyoi_order_yn", this.mDefaultWonyoiOrder);



            tpg.Tag = groupInfo;
            /*tpg.ImageList = this.ImageList;
            tpg.ImageIndex = 1;*/

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

            // 초기값 셋팅
            this.cboNalsu.SetEditValue(""); // 날수는 1로 기본셋팅
            this.cboNalsu.AcceptData();

            // 원외설정
            this.cbxWonyoiOrderYN.CheckedChanged -= new EventHandler(cbxWonyoiOrderYN_CheckedChanged);
            //if (this.IOEGUBUN == "O")
            //    this.cbxWonyoiOrderYN.SetDataValue("Y");
            //else
            //    this.cbxWonyoiOrderYN.SetDataValue("N");

            //同じ院外オーダフラグを受け継ぐ
            if (grdOrder.GetItemString(0, "wonyoi_order_yn") != "")
                this.cbxWonyoiOrderYN.SetDataValue(grdOrder.GetItemString(0, "wonyoi_order_yn").ToString());
            else
                this.cbxWonyoiOrderYN.SetDataValue(this.mDefaultWonyoiOrder);


            this.cbxWonyoiOrderYN.CheckedChanged += new EventHandler(cbxWonyoiOrderYN_CheckedChanged);

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
                /*this.btnList.PerformClick(FunctionType.Process);*/
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

                //string curNalsu = "";
                //string curBogyonog_code = "";
                //string curEmegency = "";
                //string curHopeDate = "";
                //string curWonyoiOrderYN = "";

                bool isExist = false;

                foreach (DataRow dr in this.grdOrder.LayoutTable.Rows)
                {
                    // 의사인경우는 넘어온 input_gubun 과 일치하는 입력구분만 보여주고
                    // 의사 이외의 경우는 의사 오더 및 자신의 입력구분에 해당하는 오더를 전부 보여준다.
                    //if (     (this.mInputGubun.Substring(0, 1) == "D" && dr["input_gubun"].ToString() == this.mInputGubun)
                    //      || (this.mInputGubun.Substring(0, 1) != "D" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D"))
                    //   )

                    // input_gubunに合うgroup_serタブを作る
                    //if (dr["input_gubun"].ToString() == this.mInputGubun)
                    //{
                    if ((UserInfo.UserGubun == UserType.Doctor && dr["input_gubun"].ToString() == this.mInputGubun)
                       || (UserInfo.UserGubun != UserType.Doctor && UserInfo.Gwa != "CK" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D"))
                       || (UserInfo.Gwa == "CK" && (dr["input_gubun"].ToString().Substring(0, 1) == "D" || dr["input_gubun"].ToString() == UserInfo.Gwa))
                      )
                    {


                        if (curGroupSer != dr["group_ser"].ToString())
                        //if (   curNalsu         != dr["nalsu"].ToString()
                        //    || curBogyonog_code != dr["bogyong_code"].ToString()
                        //    || curEmegency      != dr["emergency"].ToString()
                        //    || curWonyoiOrderYN != dr["wonyoi_order_yn"].ToString()
                        //    )
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

                                ldTab.Title = dr["group_ser"].ToString() + " グループ : " + dr["bogyong_name"].ToString();
                                //ldTab.Title = Resources.groupSer1 + dr["group_ser"].ToString() + " グループ : " + dr["bogyong_name"].ToString();
                                //ldTab.Title = dr["group_ser"].ToString() + " グループ";
                                /*ldTab.ImageList = this.ImageList;
                                ldTab.ImageIndex = 1;*/

                                groupInfo = new Hashtable();
                                groupInfo.Add("group_ser", dr["group_ser"]);
                                groupInfo.Add("group_name", "Nhóm" + dr["group_ser"].ToString() + " グループ : " + dr["bogyong_name"].ToString());
                                //groupInfo.Add("group_name", Resources.groupSer1 + dr["group_ser"].ToString() + " グループ : " + dr["bogyong_name"].ToString());
                                //groupInfo.Add("group_name", dr["group_ser"].ToString() + " グループ");
                                groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                                groupInfo.Add("bogyong_name", dr["bogyong_name"].ToString());
                                groupInfo.Add("emergency", dr["emergency"].ToString());
                                groupInfo.Add("nalsu", dr["nalsu"].ToString());
                                groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                                groupInfo.Add("dv", dr["dv"].ToString());
                                groupInfo.Add("donbog_yn", dr["donbog_yn"].ToString());

                                ldTab.Tag = groupInfo;

                                this.tabGroup.TabPages.Add(ldTab);

                                curGroupSer = dr["group_ser"].ToString();
                                //curNalsu         = dr["nalsu"].ToString();
                                //curBogyonog_code = dr["bogyong_code"].ToString();
                                //curEmegency      = dr["emergency"].ToString();
                                //curHopeDate      = dr["hope_date"].ToString();
                                //curWonyoiOrderYN = dr["wonyoi_order_yn"].ToString();


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
                    /*this.btnList.PerformClick(FunctionType.Process);*/
                }
            }
        }

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

            if (aExistGroupInfo.Contains("bogyong_code"))
            {
                bogyongCode = aExistGroupInfo["bogyong_code"].ToString();
            }
            if (aExistGroupInfo.Contains("bogyong_name"))
            {
                bogyongName = aExistGroupInfo["bogyong_name"].ToString();
            }
            if (aExistGroupInfo.Contains("dv"))
            {
                dv = aExistGroupInfo["dv"].ToString();
            }
            if (aExistGroupInfo.Contains("nalsu"))
            {
                nalsu = aExistGroupInfo["nalsu"].ToString();
            }
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            {
                wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            }
            if (aExistGroupInfo.Contains("donbog_yn"))
            {
                donbogyn = aExistGroupInfo["donbog_yn"].ToString();
            }
            if (aExistGroupInfo.Contains("order_remark"))
            {
                orderRemark = aExistGroupInfo["order_remark"].ToString();
            }

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
            //insert by jc 下のaDvがNULLではない場合はGRIDの値を適用するが、それを防ぐため
            if (aDv == "0")
                aDv = "";

            // 탭인포에 적용
            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
            string nalsu = aNalsu;

            this.tabGroup.SelectedTab.Title = tabInfo["group_ser"].ToString() + "グループ";
            //this.tabGroup.SelectedTab.Title = Resources.groupSer1 + tabInfo["group_ser"].ToString() + Resources.groupSer2;

            if (aBogyongCode != "")
            {
                this.tabGroup.SelectedTab.Title += ":" + aBogyongName;
            }

            if (tabInfo.Contains("bogyong_code"))
                tabInfo.Remove("bogyong_code");
            tabInfo.Add("bogyong_code", aBogyongCode);

            if (tabInfo.Contains("bogyong_name"))
                tabInfo.Remove("bogyong_name");
            tabInfo.Add("bogyong_name", aBogyongName);

            if (tabInfo.Contains("donbog_yn"))
                tabInfo.Remove("donbog_yn");
            tabInfo.Add("donbog_yn", aDonbogYN);

            if (tabInfo.Contains("donbog_yn") && tabInfo["donbog_yn"].ToString() == "Y")
            {
                if (tabInfo.Contains("nalsu") && tabInfo["nalsu"].ToString() != "1")
                {
                    this.mbxMsg = XMsg.GetMsg("M008"); //돈복오더는 일수는 1이고 횟수로 조정합니다.

                    MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (tabInfo.Contains("nalsu"))
                    tabInfo.Remove("nalsu");
                tabInfo.Add("nalsu", "1");

                this.cboNalsu.SetDataValue("1");

                nalsu = "1";
            }
            else
            {
                if (tabInfo.Contains("nalsu"))
                    tabInfo.Remove("nalsu");
                tabInfo.Add("nalsu", aNalsu);
            }

            if (tabInfo.Contains("dv"))
                tabInfo.Remove("dv");
            tabInfo.Add("dv", aDv);

            if (tabInfo.Contains("emergency"))
                tabInfo.Remove("emergency");
            tabInfo.Add("emergency", aEmergency);

            if (tabInfo.Contains("wonyoi_order_yn"))
                tabInfo.Remove("wonyoi_order_yn");
            tabInfo.Add("wonyoi_order_yn", aWonyoiOrderYN);



            // 오더에 적용
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                // 같은 그룹의 오더들은 변경해준다.
                // 복용코드
                // 날수
                // 긴급
                // 원외여부
                if (this.grdOrder.GetItemString(i, "group_ser") == tabInfo["group_ser"].ToString())
                {
                    // 접수하기 전의 오더만 가능
                    // 주사방법을 기준으로 변경 가능한것만 그룹정보 업데이트 한다.
                    if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                        this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                        this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, i, "bogyong_code", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
                    {
                        // 복용코드
                        if (this.grdOrder.GetItemString(i, "bogyong_code") != aBogyongCode)
                        {
                            this.grdOrder.SetItemValue(i, "bogyong_code", aBogyongCode);
                        }

                        // 복용법 명칭
                        if (this.grdOrder.GetItemString(i, "bogyong_name") != aBogyongName)
                        {
                            this.grdOrder.SetItemValue(i, "bogyong_name", aBogyongName);
                        }

                        // DV
                        if (this.IsOutDrugGroup(tabInfo["group_ser"].ToString()) == false)
                        {
                            if (aDv != "" && this.grdOrder.GetItemString(i, "dv") != aDv)
                            {
                                this.grdOrder.SetItemValue(i, "dv", aDv);
                            }
                        }

                        // 날수
                        if (this.grdOrder.GetItemString(i, "nalsu") != nalsu)
                        {
                            this.grdOrder.SetItemValue(i, "nalsu", nalsu);
                        }

                        // 날수 셋팅에 따른 Nday YN 설정
                        if (this.IOEGUBUN == "O")
                        {

                            if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                            {
                                this.grdOrder.SetItemValue(i, "nday_yn", "Y");
                            }
                            else
                            {
                                this.grdOrder.SetItemValue(i, "nday_yn", "N");
                            }
                        }
                        // 긴급
                        if (this.grdOrder.GetItemString(i, "emergency") != aEmergency)
                        {
                            this.grdOrder.SetItemValue(i, "emergency", aEmergency);
                        }

                        // 원외여부
                        if (this.grdOrder.GetItemString(i, "wonyoi_order_yn") != aWonyoiOrderYN)
                        {
                            this.grdOrder.SetItemValue(i, "wonyoi_order_yn", aWonyoiOrderYN);
                        }

                        // 오더 리마크의 경우는 없는 경우만 넣어준다
                        if (this.grdOrder.GetItemString(i, "order_remark") == "")
                        {
                            this.grdOrder.SetItemValue(i, "order_remark", aOrderRemark);
                        }

                        // 돈복여부
                        if (this.grdOrder.GetItemString(i, "donbog_yn") != aDonbogYN)
                        {
                            this.grdOrder.SetItemValue(i, "donbog_yn", aDonbogYN);
                        }

                        // 돈복인 경우는 dv_time 을 전부 "*" 로 설정
                        if (aDonbogYN == "Y")
                        {
                            //if (this.grdOrder.GetItemValue(i, "dv_time").ToString() == "/")
                            //既に設定されている値があれば「1」に変更させない。
                            if (this.grdOrder.GetItemValue(i, "dv_time").ToString() == "/" && int.Parse(this.grdOrder.GetItemValue(i, "dv").ToString()) < 1)
                                this.grdOrder.SetItemValue(i, "dv", 1);
                            this.grdOrder.SetItemValue(i, "dv_time", "*");
                        }
                        else
                        {
                            if (this.grdOrder.GetItemString(i, "order_gubun_bas") == "C")
                            {
                                this.grdOrder.SetItemValue(i, "dv_time", "/");
                            }
                            else
                            {
                                this.grdOrder.SetItemValue(i, "dv_time", "*");
                            }
                        }
                    }
                }
            }

            this.MakePreviewStatus();
        }

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

            /*openParams.Add("naewon_date", this.dpkOrder_Date.GetDataValue());*/
            openParams.Add("input_gubun", this.mInputGubun);
            //openParams.Add("tel_yn"     , "N"); // 간호 입력분은 뺀다 
            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다

            openParams.Add("auto_close", aIsAutoClose);
            openParams.Add("input_tab", INPUTTAB);
            openParams.Add("io_gubun", this.IOEGUBUN);

            openParams.Add("childYN", "N");
            openParams.Add("patient_info", this.mPatientInfo);

            //전처방조회 화면 Open
            //XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q00", ScreenOpenStyle.ResponseSizable, openParams);
            try
            {
                XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q09", ScreenOpenStyle.ResponseSizable, openParams);
            }
            catch
            {

            }
        }

        private void PostNalsuValidating()
        {
            // 에러로 취소시 날수는 1로 원상복귀
            this.cboNalsu.SetEditValue("1");
            this.cboNalsu.AcceptData();
        }

        private void OpenScreen_OCS0301Q09()
        {
            /*string naewon_date = this.dpkOrder_Date.GetDataValue().PadRight(10).Substring(0, 10).Replace("-", "/");*/

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("input_tab", INPUTTAB);
            openParams.Add("input_gubun", this.mInputGubun);

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

        private void OpenScreen_OCS1023U00(string aBunho, string aGwa)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("gwa", aGwa);
            param.Add("auto_close_yn", "Y");
            param.Add("input_tab", INPUTTAB);

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1023U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private bool IsSelectedRowForNalsu()
        {
            int selectRow = 0;
            if (this.grdOrder.RowCount > 0)
            {
                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    if (this.grdOrder.IsSelectedRow(i))
                    {
                        if (this.grdOrder.GetItemString(i, "jundal_part") == "HOM")
                        {
                            MessageBox.Show("[行為部署]が[HOM]の場合は希望日の設定が不可能です。", XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            selectRow++;
                            return true;
                        }
                    }
                }

                if (selectRow <= 0)
                {
                    XMessageBox.Show("オーダが選択されていません。一つ以上のオーダを選択してください。", "確認");
                    this.cboNalsu.SetDataValue("1");
                    return false;
                }
            }
            return true;
        }

        private bool IsSelectedDiffHopeDate()
        {
            ArrayList HopeDateList = new ArrayList();
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i))
                {
                    HopeDateList.Add(this.grdOrder.GetItemString(i, "hope_date"));
                }
            }

            for (int j = 0; j < HopeDateList.Count; j++)
            {
                for (int k = j; k < HopeDateList.Count; k++)
                {
                    if (HopeDateList[j].ToString() != HopeDateList[k].ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void OPEN_DRG0208Q00()
        {
            if (this.tabGroup.SelectedTab == null) return;

            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, tabInfo["group_ser"].ToString()))
            {
                MessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsOutDrugGroup(tabInfo["group_ser"].ToString()))
                this.OpenScreen_OCS0208Q01("", this.fbxBogyongCode.GetDataValue(), "");
            else
                this.OpenScreen_OCS0208Q00();
        }

        private void PostEmergencyCheckedChangeFail(string aOrgCheckedValue)
        {
            this.cbxEmergency.CheckedChanged -= new EventHandler(cbxEmergency_CheckedChanged);

            this.cbxEmergency.SetDataValue(aOrgCheckedValue);

            this.cbxEmergency.CheckedChanged += new EventHandler(cbxEmergency_CheckedChanged);
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

            // 2012/12/10
            openParams.Add("dv_6", "");
            openParams.Add("dv_7", "");
            openParams.Add("dv_8", "");
            openParams.Add("order_remark", "");
            openParams.Add("bogyong_code", "");
            openParams.Add("io_gubun", this.IOEGUBUN);
            openParams.Add("inputgubun", this.mInputGubun);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS0208Q01(string aOrderRemark, string aBogyongCode, string aHangmogCode)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("order_remark", aOrderRemark);

            openParams.Add("bogyong_code", aBogyongCode);
            openParams.Add("hangmog_code", aHangmogCode);
            openParams.Add("io_gubun", this.IOEGUBUN);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void PostBogyongCodeValidating()
        {
            this.cboNalsu.Focus();
        }

        private void SetGroupControlVisible(string aGroupSer)
        {
            if (this.IsOutDrugGroup(aGroupSer))
            {
                this.lblNalsu.Visible = false;
                this.cboNalsu.Visible = false;
                if (this.cboNalsu.GetDataValue() != "1")
                {
                    this.cboNalsu.SetEditValue("1");
                    this.cboNalsu.AcceptData();
                }
            }
            else if (this.IsDonbokGroup(aGroupSer))
            {
                this.lblNalsu.Visible = false;
                this.cboNalsu.Visible = false;
                if (this.cboNalsu.GetDataValue() != "1")
                {
                    this.cboNalsu.SetEditValue("1");
                    this.cboNalsu.AcceptData();
                }
            }
            else
            {
                this.lblNalsu.Visible = true;
                this.cboNalsu.Visible = true;
            }
        }

        private void PostNalsuValidating(object aParam)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                OrderVariables.Objects objects = (OrderVariables.Objects)aParam;

                XEditGrid grd = (XEditGrid)objects.obj1;
                int row = (int)objects.obj2;
                int source_last_row = row;                 // Nday처리할 원데이타의 Row(Mix도 있을수 있으므로 Mix된 Last)
                string naewon_date = (string)objects.obj3;

                int nalsu = int.Parse(objects.obj4.ToString());
                string jundal_table = (string)objects.obj5;
                string order_gubun_bas = (string)objects.obj6;
                string hame_care_yn = (string)objects.obj7;

                if (this.tabGroup.SelectedTab == null ||
                    this.mOrderFunc.IsEmptyGroup(this.grdOrder, ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString()))
                {
                    return;
                }

                // 기준데이터를 셀렉트 한다
                // N데이를 풀 기준은 현재 그리드에 보이는 데이터를 기준으로 N데이 푼다.
                MultiLayout layGijunData = this.grdOrder.CloneToLayout();
                MultiLayout mixInfo = new MultiLayout();
                mixInfo.LayoutItems.Add("org_mix", DataType.String);
                mixInfo.LayoutItems.Add("cnv_mix", DataType.String);
                mixInfo.InitializeLayoutTable();

                //insert by jc

                ArrayList selectedIndex = new ArrayList();

                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    if (this.grdOrder.IsSelectedRow(i))
                    {
                        selectedIndex.Add(i);
                    }
                }


                if (selectedIndex.Count > 0)
                {
                    foreach (int rows in selectedIndex)
                    {
                        if (this.grdOrder.IsVisibleRow(rows) &&
                            this.grdOrder.GetItemString(rows, "input_gubun") == this.mInputGubun)
                        {
                            layGijunData.LayoutTable.ImportRow(this.grdOrder.LayoutTable.Rows[rows]);

                            if (this.grdOrder.GetItemString(rows, "mix_group") != "")
                            {
                                DataRow[] dr = mixInfo.LayoutTable.Select("org_mix='" + this.grdOrder.GetItemString(rows, "mix_group") + "'");

                                if (dr.Length <= 0)
                                {
                                    int rowNum = mixInfo.InsertRow(-1);
                                    mixInfo.SetItemValue(rowNum, "org_mix", this.grdOrder.GetItemString(rows, "mix_group"));
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.IsVisibleRow(i) &&
                            this.grdOrder.GetItemString(i, "input_gubun") == this.mInputGubun)
                        {
                            layGijunData.LayoutTable.ImportRow(this.grdOrder.LayoutTable.Rows[i]);

                            if (this.grdOrder.GetItemString(i, "mix_group") != "")
                            {
                                DataRow[] dr = mixInfo.LayoutTable.Select("org_mix='" + this.grdOrder.GetItemString(i, "mix_group") + "'");

                                if (dr.Length <= 0)
                                {
                                    int rowNum = mixInfo.InsertRow(-1);
                                    mixInfo.SetItemValue(rowNum, "org_mix", this.grdOrder.GetItemString(i, "mix_group"));
                                }
                            }
                        }
                    }
                }
                if (layGijunData.RowCount <= 0)
                {
                    MessageBox.Show(XMsg.GetMsg("M0113"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (grd == null || this.mOrderFunc.IsEmptyGroup(grd, ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString())) return;

                // N day 예약일자를 받는다

                // 기존에선택된데이타 선택된것으로 달력표시시에는
                // this.mGetSelectDate.AddInputDate 사용
                //insert by jc

                //FormGetSelectHopeDateに渡す日付の重複除去用変数
                ArrayList insertDateTime = new ArrayList();

                if (selectedIndex.Count > 0)
                {
                    foreach (int rows in selectedIndex)
                    {
                        if (this.grdOrder.GetItemString(rows, "hope_date") != "" && !insertDateTime.Contains(this.grdOrder.GetItemValue(rows, "hope_date")))
                        {
                            this.mCommonForms.AddInputDate(this.grdOrder.GetItemString(rows, "hope_date"));
                            insertDateTime.Add(this.grdOrder.GetItemValue(rows, "hope_date"));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.GetItemString(i, "hope_date") != "" && !insertDateTime.Contains(this.grdOrder.GetItemValue(i, "hope_date")))
                        {
                            this.mCommonForms.AddInputDate(this.grdOrder.GetItemString(i, "hope_date"));
                            insertDateTime.Add(this.grdOrder.GetItemValue(i, "hope_date"));
                        }
                    }
                }

                insertDateTime.Clear();

                //insert by jc
                //[カレンダーOPEN]
                MultiLayout receiveDate = null;

                //insert by jc [入院オーダ時は休日選択可能にさせる] 2012/05/11
                if (IOEGUBUN == "I")
                    receiveDate = this.mCommonForms.SelectHopeDate(this, naewon_date, nalsu, jundal_table, IOEGUBUN);
                else
                    receiveDate = this.mCommonForms.SelectHopeDate(this, naewon_date, nalsu, jundal_table);

                // 그룹의 일수를 1로 다시 변경한다.
                this.cboNalsu.SetDataValue("1");

                // 화면 Clear
                grd.AcceptData();
                this.Parent.Refresh();

                if (receiveDate == null || receiveDate.RowCount == 0) return;

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                this.InitStatusBar(receiveDate.RowCount);
                this.SetVisibleStatusBar(true);

                // DataTable 데이타를 담는다(해당 Row와 동일 Mix인 데이타)
                MultiLayout lay = this.mOrderFunc.CloneDataLayoutMIO(grd);

                for (int i = 0; i < receiveDate.RowCount; i++)
                {
                    this.SetStatusBar(i + 1);
                    // Mix 그룹 리셋
                    for (int k = 0; k < mixInfo.RowCount; k++)
                    {
                        mixInfo.SetItemValue(k, "cnv_mix", "");
                    }

                    //modify by jc [修正不可能ない状態のROWには希望日をいれずに飛ばす] 2012/05/02
                    if (i == 0 && this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IOEGUBUN, this.grdOrder, this.grdOrder.CurrentRowNumber, "jusa", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay)) // 초기 1회는 현재 화면의 데이터 즉 기준데이터를 가지고 희망일자만 셋팅하면 된다.
                    {
                        if (selectedIndex.Count > 0)
                        {
                            foreach (int rows in selectedIndex)
                            {
                                if (this.grdOrder.GetItemString(rows, "group_ser") == ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString()
                                    && this.grdOrder.GetItemString(rows, "input_gubun") == this.mInputGubun)
                                {
                                    this.grdOrder.SetItemValue(rows, "hope_date", receiveDate.GetItemString(i, "day"));
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < this.grdOrder.RowCount; j++)
                            {
                                if (this.grdOrder.GetItemString(j, "group_ser") == ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString() &&
                                    this.grdOrder.GetItemString(j, "input_gubun") == this.mInputGubun)
                                {
                                    this.grdOrder.SetItemValue(j, "hope_date", receiveDate.GetItemString(i, "day"));
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in layGijunData.LayoutTable.Rows)
                        {
                            string cnvMix = "";
                            if (dr["mix_group"].ToString() != "")
                            {
                                cnvMix = this.GetConvertMixInfo(mixInfo, dr["mix_group"].ToString());

                                if (cnvMix == "")
                                {
                                    cnvMix = this.GetMixGroup(this.grdOrder);
                                    this.SetConvertMixInfo(mixInfo, dr["mix_group"].ToString(), cnvMix);
                                }
                            }
                            int currentRow = this.grdOrder.RowCount;
                            this.grdOrder.InsertRow(currentRow);
                            foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                            {
                                switch (cl.ColumnName)
                                {
                                    case "pkocskey": break;
                                    case "seq": break;
                                    case "muhyo": break;
                                    case "dc_yn": break;
                                    case "bannab_yn": break;
                                    case "bannab_confirm": break;
                                    case "ocs_flag": break;
                                    case "sg_ymd": break;
                                    case "after_act_yn": break;


                                    case "hope_date":
                                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cl.ColumnName, receiveDate.GetItemString(i, "day"));
                                        break;

                                    case "mix_group":
                                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cl.ColumnName, cnvMix);
                                        break;

                                    default:
                                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, cl.ColumnName, dr[cl.ColumnName]);
                                        break;
                                }
                            }
                        }
                    }
                }
                this.grdOrder.DisplayData();
                this.DisplayMixGroup(this.grdOrder);
                this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            }
            finally
            {
                this.SetVisibleStatusBar(false);
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.MakePreviewStatus();
            }
        }

        private void SetStatusBar(int aCurrentValue)
        {
            this.pgbProgress.Value = aCurrentValue;
            this.pgbProgress.Refresh();

            this.lbStatus.Text = aCurrentValue.ToString() + "/" + this.pgbProgress.Maximum.ToString();
            this.lbStatus.Refresh();
        }

        private void SetVisibleStatusBar(bool aIsVisible)
        {
            this.pnlStatus.Visible = aIsVisible;
        }

        private string GetConvertMixInfo(MultiLayout aLay, string aMix)
        {
            for (int i = 0; i < aLay.RowCount; i++)
            {
                if (aLay.GetItemString(i, "org_mix") == aMix)
                {
                    return aLay.GetItemString(i, "cnv_mix");
                }
            }

            return "";
        }

        private void InitStatusBar(int aMaxValue)
        {
            this.pgbProgress.Minimum = 0;
            this.pgbProgress.Maximum = aMaxValue;

            this.lbStatus.Text = "";
        }

        private string GetMixGroup(XEditGrid grd)
        {
            int mix = -999;

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetItemString(i, "mix_group") != "")
                {
                    if (grd.GetItemInt(i, "mix_group") > mix)
                    {
                        mix = grd.GetItemInt(i, "mix_group");
                    }
                }
            }

            if (mix == -999) return "1";
            else return (mix + 1).ToString();
        }

        private void SetConvertMixInfo(MultiLayout aLay, string aMix, string aCnvMix)
        {
            for (int i = 0; i < aLay.RowCount; i++)
            {
                if (aLay.GetItemString(i, "org_mix") == aMix)
                {
                    aLay.SetItemValue(i, "cnv_mix", aCnvMix);
                }
            }
        }

        private bool IsDonbokGroup(string aGroupSer)
        {
            //Hashtable groupInfo;

            //foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            //{
            //    groupInfo = tpg.Tag as Hashtable;

            //    if (groupInfo["group_ser"].ToString() == aGroupSer)
            //    {
            //        if (groupInfo.Contains("donbog_yn"))
            //        {
            //            if (groupInfo["donbog_yn"].ToString() == "Y")
            //                return true;
            //        }
            //    }
            //}


            DataRow[] rows = this.grdOrder.LayoutTable.Select("group_ser=" + aGroupSer);

            if (rows.Length <= 0) return false;

            foreach (DataRow dr in rows)
            {
                if (dr["order_gubun"].ToString() != "" && dr["donbog_yn"].ToString() == "Y")
                {
                    return true;
                }
            }


            return false;
        }

        #endregion

    }
}
