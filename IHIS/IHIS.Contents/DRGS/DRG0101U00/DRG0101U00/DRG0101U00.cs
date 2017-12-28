#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;


using System.Xml;
using System.IO;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Threading;
using System.Runtime.InteropServices;

#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG0101U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG0101U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XButtonList xButtonList1;
        private System.Windows.Forms.Panel pnlKind;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XLabel xLabel11;
        private IHIS.Framework.XLabel xLabel14;
        private IHIS.Framework.XLabel xLabel23;
        private IHIS.Framework.XLabel xLabel24;
        private IHIS.Framework.XLabel xLabel26;
        private IHIS.Framework.XLabel xLabel27;
        private IHIS.Framework.XLabel xLabel28;
        private IHIS.Framework.XLabel xLabel29;
        private IHIS.Framework.XLabel xLabel30;
        private IHIS.Framework.XLabel xLabel34;
        private IHIS.Framework.XLabel xLabel38;
        private IHIS.Framework.XLabel xLabel44;
        private IHIS.Framework.XLabel xLabel45;
        private IHIS.Framework.XLabel xLabel46;
        private IHIS.Framework.XLabel xLabel47;
        private IHIS.Framework.XLabel xLabel54;
        private IHIS.Framework.XLabel xLabel40;
        private IHIS.Framework.XFindBox fbxJaeryo;
        private IHIS.Framework.XLabel label4;
        private IHIS.Framework.XLabel xLabel60;
        private IHIS.Framework.XLabel xLabel61;
        private IHIS.Framework.XLabel xLabel62;
        private IHIS.Framework.XLabel xLabel64;
        private IHIS.Framework.XEditGridCell sungbun_code;
        private IHIS.Framework.XEditGridCell jnaeryo_code;
        private IHIS.Framework.XEditGridCell jnaeryo_name;
        private IHIS.Framework.XFindBox fbxSmall;
        private IHIS.Framework.XTextBox txtJaeryoEname;
        private IHIS.Framework.XTextBox txtJaeryoName;
        private IHIS.Framework.XTextBox txtSungBunName;
        private IHIS.Framework.XTextBox txtJaeryoCode;
        private IHIS.Framework.XTextBox txtSungBunCode;
        private IHIS.Framework.XFindBox fbxSubulQcodeEr;
        private IHIS.Framework.XFindBox fbxSubulQcodeInp;
        private IHIS.Framework.XFindBox fbxSubulQcodeOut;
        private IHIS.Framework.XFindBox fbxCustomerCode;
        private IHIS.Framework.XFlatRadioButton rbxLabelN;
        private IHIS.Framework.XFlatRadioButton rbxLabelY;
        private IHIS.Framework.XFlatRadioButton rbxMixN;
        private IHIS.Framework.XFlatRadioButton rbxMixY;
        private IHIS.Framework.XFlatRadioButton rbxInpN;
        private IHIS.Framework.XFlatRadioButton rbxInpY;
        private IHIS.Framework.XFlatRadioButton rbxOutN;
        private IHIS.Framework.XFlatRadioButton rbxOutY;
        private IHIS.Framework.XFindBox fbxCautionCode;
        private IHIS.Framework.XFindBox fbxDrgType;
        private IHIS.Framework.XDictComboBox dcbBunryu9;
        private IHIS.Framework.XFindBox fbxSubulBuseo;
        private IHIS.Framework.XFindBox fbxBaljuBuseo;
        private IHIS.Framework.XFindBox fbxSubulDanui;
        private IHIS.Framework.XFindBox fbxBaljuDanui;
        private IHIS.Framework.XDatePicker dtpJukyongDate;
        private IHIS.Framework.XFindBox fbxBulyongCode;
        private IHIS.Framework.XFindWorker fwkCommon;
        private IHIS.Framework.XMstGrid grdInv0110;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XDisplayBox dbxSmall;
        private IHIS.Framework.XDisplayBox dbxDrgType;
        private IHIS.Framework.XDisplayBox dbxCautionCode;
        private IHIS.Framework.XDisplayBox dbxCustomerName;
        private IHIS.Framework.XDisplayBox dbxSubulQcodeOut;
        private IHIS.Framework.XDisplayBox dbxSubulQcodeEr;
        private IHIS.Framework.XDisplayBox dbxBulyongCode;
        private IHIS.Framework.XDisplayBox dbxSubulQcodeInp;
        private IHIS.Framework.MultiLayout layDetail;
        private IHIS.Framework.XFlatRadioButton rbxSugbJaeryoN;
        private IHIS.Framework.XFlatRadioButton rbxSugbJaeryoY;
        private IHIS.Framework.XGroupBox gbxSugbJaeryo;
        private IHIS.Framework.XGroupBox gbxLabel;
        private IHIS.Framework.XGroupBox gbxMix;
        private IHIS.Framework.XGroupBox gbxInp;
        private IHIS.Framework.XGroupBox gbxOut;
        private IHIS.Framework.XTextBox txtChangeQtyl;
        private IHIS.Framework.XTextBox txtHamryang;
        private IHIS.Framework.XTextBox txtKyukyeok;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDisplayBox dbxBunryu1;
        private IHIS.Framework.XFindBox fbxBunryu1;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XDisplayBox dbxBunryu2;
        private IHIS.Framework.XFindBox fbxBunryu2;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XDisplayBox dbxBunryu3;
        private IHIS.Framework.XFindBox fbxBunryu3;
        private IHIS.Framework.XLabel xLabel9;
        private IHIS.Framework.XDisplayBox dbxBunryu4;
        private IHIS.Framework.XFindBox fbxBunryu4;
        private IHIS.Framework.XLabel xLabel10;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XLabel xLabel12;
        private IHIS.Framework.XLabel xLabel15;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XLabel xLabel16;
        private IHIS.Framework.XDisplayBox dbxSubulDanui;
        private IHIS.Framework.XDisplayBox dbxBaljuDanui;
        private IHIS.Framework.XFindBox fbxCompanyName;
        private IHIS.Framework.XDisplayBox dbxCompanyName;
        private IHIS.Framework.XEditMask txtDanga;
        private IHIS.Framework.XEditMask txtGijunDanga;
        private IHIS.Framework.XFindWorker fwkJaeryo;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private IHIS.Framework.XDictComboBox cboBunryu;
        private IHIS.Framework.XLabel xLabel17;
        private IHIS.Framework.XTextBox txtRemark;
        private IHIS.Framework.XLabel xLabel18;
        private IHIS.Framework.XTextBox dbxJaeryo;
        private IHIS.Framework.XComboBox cbxBulyong;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XLabel xLabel19;
        private IHIS.Framework.XFindBox fbxOrderDanui;
        private IHIS.Framework.XDisplayBox dbxOrderDanui;
        private IHIS.Framework.XLabel xLabel20;
        private IHIS.Framework.XDisplayBox dbxLabelDanui;
        private IHIS.Framework.XFindBox fbxLabelDanui;
        private IHIS.Framework.XLabel xLabel22;
        private IHIS.Framework.XDisplayBox dbxLabelDanui2;
        private IHIS.Framework.XFindBox fbxLabelDanui2;
        private IHIS.Framework.XLabel xLabel25;
        private IHIS.Framework.XLabel xLabel21;
        private IHIS.Framework.XEditMask emDrgTrunc;
        private IHIS.Framework.XLabel xLabel31;
        private IHIS.Framework.XDictComboBox dcxBunryu5;
        private IHIS.Framework.XDictComboBox dcxBunryu6;
        private IHIS.Framework.XDictComboBox dcxBunryu7;
        private IHIS.Framework.XDictComboBox dcxBunryu8;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XLabel xLabel32;
        private IHIS.Framework.XLabel xLabel33;
        private IHIS.Framework.XCheckBox cbxB;
        private IHIS.Framework.XCheckBox cbxA;
        private IHIS.Framework.XCheckBox cbx8;
        private IHIS.Framework.XCheckBox cbx7;
        private IHIS.Framework.XCheckBox cbx9;
        private IHIS.Framework.XCheckBox cbxC;
        private IHIS.Framework.XCheckBox cbx6;
        private IHIS.Framework.XCheckBox cbx5;
        private IHIS.Framework.XCheckBox cbx4;
        private IHIS.Framework.XCheckBox cbx3;
        private IHIS.Framework.XCheckBox cbx2;
        private IHIS.Framework.XCheckBox cbx1;
        private IHIS.Framework.XDatePicker dpxYuhyyo;
        private IHIS.Framework.XTextBox txtDrgComment;
        private IHIS.Framework.XLabel xLabel35;
        private IHIS.Framework.XTextBox txtChanggo;
        private IHIS.Framework.XCheckBox cbxD;
        private IHIS.Framework.XTextBox txtYongRyang;
        private IHIS.Framework.XLabel xLabel36;
        private IHIS.Framework.MultiLayout layExcel;
        private IHIS.Framework.XLabel xLabel37;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XComboItem xComboItem6;
        private IHIS.Framework.XComboItem xComboItem7;
        private IHIS.Framework.XComboItem xComboItem8;
        private IHIS.Framework.XComboItem xComboItem9;
        private IHIS.Framework.XDictComboBox dcbColorText;
        private IHIS.Framework.XLabel xLabel13;
        private IHIS.Framework.XLabel xLabel39;
        private IHIS.Framework.XTextBox txtManageNo;
        private IHIS.Framework.XLabel xLabel41;
        private IHIS.Framework.XDisplayBox dbxSmall1;
        private IHIS.Framework.XFindBox fbxSmall1;
        private IHIS.Framework.XMstGrid grdOCS0103;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XFindWorker fdwOCS0102;
        private IHIS.Framework.FindColumnInfo findColumnInfo5;
        private IHIS.Framework.FindColumnInfo findColumnInfo6;
        private IHIS.Framework.XDictComboBox SLIP_CODE;
        private IHIS.Framework.XButton xButton1;
        private IHIS.Framework.XLabel xLabel43;
        private IHIS.Framework.XButton btnDRG0112U00;
        private IHIS.Framework.XButton btnOCS0103U00;
        private IHIS.Framework.XButton btnBAS0310U00;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
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
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XEditGridCell xEditGridCell103;
        private IHIS.Framework.XEditGridCell xEditGridCell104;
        private IHIS.Framework.XEditGridCell xEditGridCell105;
        private IHIS.Framework.XEditGridCell xEditGridCell109;
        private IHIS.Framework.XEditGridCell xEditGridCell112;
        private IHIS.Framework.XEditGridCell xEditGridCell113;
        private IHIS.Framework.XTextBox txtActJaeryoName;
        private IHIS.Framework.XLabel xLabel48;
        private IHIS.Framework.XDatePicker emBulyongDate;
        private IHIS.Framework.XLabel xLabel42;
        private IHIS.Framework.XDictComboBox dcxDrgJibgyeGubun;
        private IHIS.Framework.XFlatLabel fblText;
        private IHIS.Framework.XDisplayBox xDisplayBox1;
        private IHIS.Framework.XButton btnQueryIns;
        private IHIS.Framework.XButton btnQuery;
        private IHIS.Framework.FindColumnInfo findColumnInfo7;
        private IHIS.Framework.XCheckBox chkE;
        private IHIS.Framework.XCheckBox chkF;
        private IHIS.Framework.XCheckBox chkToijangYn;
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
        private XButton xButton2;
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
        private MultiLayoutItem multiLayoutItem310;
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
        private MultiLayoutItem multiLayoutItem325;
        private MultiLayoutItem multiLayoutItem326;
        private MultiLayoutItem multiLayoutItem327;
        private MultiLayoutItem multiLayoutItem328;
        private MultiLayoutItem multiLayoutItem329;
        private MultiLayoutItem multiLayoutItem330;
        private MultiLayoutItem multiLayoutItem331;
        private MultiLayoutItem multiLayoutItem332;
        private MultiLayoutItem multiLayoutItem333;
        private MultiLayoutItem multiLayoutItem334;
        private MultiLayoutItem multiLayoutItem335;
        private MultiLayoutItem multiLayoutItem336;
        private MultiLayoutItem multiLayoutItem337;
        private MultiLayoutItem multiLayoutItem338;
        private MultiLayoutItem multiLayoutItem339;
        private MultiLayoutItem multiLayoutItem340;
        private MultiLayoutItem multiLayoutItem341;
        private MultiLayoutItem multiLayoutItem342;
        private MultiLayoutItem multiLayoutItem343;
        private MultiLayoutItem multiLayoutItem344;
        private MultiLayoutItem multiLayoutItem345;
        private MultiLayoutItem multiLayoutItem346;
        private MultiLayoutItem multiLayoutItem347;
        private MultiLayoutItem multiLayoutItem348;
        private MultiLayoutItem multiLayoutItem349;
        private MultiLayoutItem multiLayoutItem350;
        private MultiLayoutItem multiLayoutItem351;
        private MultiLayoutItem multiLayoutItem352;
        private MultiLayoutItem multiLayoutItem353;
        private MultiLayoutItem multiLayoutItem354;
        private MultiLayoutItem multiLayoutItem355;
        private MultiLayoutItem multiLayoutItem356;
        private MultiLayoutItem multiLayoutItem357;
        private MultiLayoutItem multiLayoutItem358;
        private MultiLayoutItem multiLayoutItem359;
        private MultiLayoutItem multiLayoutItem360;
        private MultiLayoutItem multiLayoutItem361;
        private MultiLayoutItem multiLayoutItem362;
        private MultiLayoutItem multiLayoutItem363;
        private MultiLayoutItem multiLayoutItem364;
        private MultiLayoutItem multiLayoutItem365;
        private MultiLayoutItem multiLayoutItem366;
        private MultiLayoutItem multiLayoutItem367;
        private MultiLayoutItem multiLayoutItem368;
        private MultiLayoutItem multiLayoutItem369;
        private MultiLayoutItem multiLayoutItem370;
        private MultiLayoutItem multiLayoutItem371;
        private MultiLayoutItem multiLayoutItem372;
        private MultiLayoutItem multiLayoutItem373;
        private MultiLayoutItem multiLayoutItem374;
        private MultiLayoutItem multiLayoutItem375;
        private MultiLayoutItem multiLayoutItem376;
        private MultiLayoutItem multiLayoutItem377;
        private MultiLayoutItem multiLayoutItem378;
        private MultiLayoutItem multiLayoutItem379;
        private MultiLayoutItem multiLayoutItem380;
        private MultiLayoutItem multiLayoutItem381;
        private MultiLayoutItem multiLayoutItem382;
        private MultiLayoutItem multiLayoutItem383;
        private MultiLayoutItem multiLayoutItem384;
        private MultiLayoutItem multiLayoutItem385;
        private MultiLayoutItem multiLayoutItem386;
        private MultiLayoutItem multiLayoutItem387;
        private MultiLayoutItem multiLayoutItem388;
        private MultiLayoutItem multiLayoutItem389;
        private MultiLayoutItem multiLayoutItem390;
        private MultiLayoutItem multiLayoutItem391;
        private MultiLayoutItem multiLayoutItem392;
        private MultiLayoutItem multiLayoutItem393;
        private MultiLayoutItem multiLayoutItem394;
        private MultiLayoutItem multiLayoutItem395;
        private MultiLayoutItem multiLayoutItem396;
        private MultiLayoutItem multiLayoutItem397;
        private MultiLayoutItem multiLayoutItem398;
        private MultiLayoutItem multiLayoutItem399;
        private MultiLayoutItem multiLayoutItem400;
        private MultiLayoutItem multiLayoutItem401;
        private MultiLayoutItem multiLayoutItem402;
        private MultiLayoutItem multiLayoutItem403;
        private MultiLayoutItem multiLayoutItem404;
        private MultiLayoutItem multiLayoutItem405;
        private MultiLayoutItem multiLayoutItem406;
        private MultiLayoutItem multiLayoutItem407;
        private MultiLayoutItem multiLayoutItem408;
        private MultiLayoutItem multiLayoutItem409;
        private MultiLayoutItem multiLayoutItem410;
        private MultiLayoutItem multiLayoutItem411;
        private MultiLayoutItem multiLayoutItem412;
        private MultiLayoutItem multiLayoutItem413;
        private MultiLayoutItem multiLayoutItem414;
        private MultiLayoutItem multiLayoutItem415;
        private MultiLayoutItem multiLayoutItem416;
        private MultiLayoutItem multiLayoutItem417;
        private MultiLayoutItem multiLayoutItem418;
        private MultiLayoutItem multiLayoutItem419;
        private MultiLayoutItem multiLayoutItem420;
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
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DRG0101U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.layDetail.SavePerformer = new XSavePerformer(this);
            this.grdInv0110.SavePerformer = layDetail.SavePerformer;

            this.SaveLayoutList.Add(this.layDetail);
            this.SaveLayoutList.Add(this.grdInv0110);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG0101U00));
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdInv0110 = new IHIS.Framework.XMstGrid();
            this.sungbun_code = new IHIS.Framework.XEditGridCell();
            this.jnaeryo_code = new IHIS.Framework.XEditGridCell();
            this.jnaeryo_name = new IHIS.Framework.XEditGridCell();
            this.pnlKind = new System.Windows.Forms.Panel();
            this.btnQuery = new IHIS.Framework.XButton();
            this.btnQueryIns = new IHIS.Framework.XButton();
            this.xLabel43 = new IHIS.Framework.XLabel();
            this.cbxBulyong = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.dbxJaeryo = new IHIS.Framework.XTextBox();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.cboBunryu = new IHIS.Framework.XDictComboBox();
            this.fbxJaeryo = new IHIS.Framework.XFindBox();
            this.fwkJaeryo = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo7 = new IHIS.Framework.FindColumnInfo();
            this.xLabel40 = new IHIS.Framework.XLabel();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.fbxSubulDanui = new IHIS.Framework.XFindBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxSubulQcodeInp = new IHIS.Framework.XDisplayBox();
            this.dbxBulyongCode = new IHIS.Framework.XDisplayBox();
            this.dbxSubulQcodeEr = new IHIS.Framework.XDisplayBox();
            this.dbxSubulQcodeOut = new IHIS.Framework.XDisplayBox();
            this.dbxCustomerName = new IHIS.Framework.XDisplayBox();
            this.gbxSugbJaeryo = new IHIS.Framework.XGroupBox();
            this.rbxSugbJaeryoN = new IHIS.Framework.XFlatRadioButton();
            this.rbxSugbJaeryoY = new IHIS.Framework.XFlatRadioButton();
            this.fbxBaljuDanui = new IHIS.Framework.XFindBox();
            this.fbxBaljuBuseo = new IHIS.Framework.XFindBox();
            this.fbxSubulBuseo = new IHIS.Framework.XFindBox();
            this.txtChangeQtyl = new IHIS.Framework.XTextBox();
            this.dtpJukyongDate = new IHIS.Framework.XDatePicker();
            this.fbxBulyongCode = new IHIS.Framework.XFindBox();
            this.fbxSubulQcodeEr = new IHIS.Framework.XFindBox();
            this.fbxSubulQcodeInp = new IHIS.Framework.XFindBox();
            this.fbxSubulQcodeOut = new IHIS.Framework.XFindBox();
            this.fbxCustomerCode = new IHIS.Framework.XFindBox();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel45 = new IHIS.Framework.XLabel();
            this.xLabel44 = new IHIS.Framework.XLabel();
            this.xLabel38 = new IHIS.Framework.XLabel();
            this.xLabel46 = new IHIS.Framework.XLabel();
            this.xLabel47 = new IHIS.Framework.XLabel();
            this.xLabel34 = new IHIS.Framework.XLabel();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.xLabel64 = new IHIS.Framework.XLabel();
            this.dbxBunryu4 = new IHIS.Framework.XDisplayBox();
            this.fbxBunryu4 = new IHIS.Framework.XFindBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.dbxBunryu3 = new IHIS.Framework.XDisplayBox();
            this.fbxBunryu3 = new IHIS.Framework.XFindBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.dbxBunryu2 = new IHIS.Framework.XDisplayBox();
            this.fbxBunryu2 = new IHIS.Framework.XFindBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.dbxBunryu1 = new IHIS.Framework.XDisplayBox();
            this.fbxBunryu1 = new IHIS.Framework.XFindBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.dbxCautionCode = new IHIS.Framework.XDisplayBox();
            this.dbxDrgType = new IHIS.Framework.XDisplayBox();
            this.dbxSmall = new IHIS.Framework.XDisplayBox();
            this.label4 = new IHIS.Framework.XLabel();
            this.fbxCautionCode = new IHIS.Framework.XFindBox();
            this.fbxDrgType = new IHIS.Framework.XFindBox();
            this.fbxSmall = new IHIS.Framework.XFindBox();
            this.dcbBunryu9 = new IHIS.Framework.XDictComboBox();
            this.txtKyukyeok = new IHIS.Framework.XTextBox();
            this.txtHamryang = new IHIS.Framework.XTextBox();
            this.txtJaeryoEname = new IHIS.Framework.XTextBox();
            this.txtJaeryoName = new IHIS.Framework.XTextBox();
            this.txtSungBunName = new IHIS.Framework.XTextBox();
            this.txtJaeryoCode = new IHIS.Framework.XTextBox();
            this.txtSungBunCode = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel30 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel54 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.gbxInp = new IHIS.Framework.XGroupBox();
            this.rbxInpN = new IHIS.Framework.XFlatRadioButton();
            this.rbxInpY = new IHIS.Framework.XFlatRadioButton();
            this.gbxOut = new IHIS.Framework.XGroupBox();
            this.rbxOutN = new IHIS.Framework.XFlatRadioButton();
            this.rbxOutY = new IHIS.Framework.XFlatRadioButton();
            this.xLabel60 = new IHIS.Framework.XLabel();
            this.xLabel61 = new IHIS.Framework.XLabel();
            this.xLabel62 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.gbxLabel = new IHIS.Framework.XGroupBox();
            this.rbxLabelN = new IHIS.Framework.XFlatRadioButton();
            this.rbxLabelY = new IHIS.Framework.XFlatRadioButton();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.gbxMix = new IHIS.Framework.XGroupBox();
            this.rbxMixN = new IHIS.Framework.XFlatRadioButton();
            this.rbxMixY = new IHIS.Framework.XFlatRadioButton();
            this.txtChanggo = new IHIS.Framework.XTextBox();
            this.txtManageNo = new IHIS.Framework.XTextBox();
            this.fbxSmall1 = new IHIS.Framework.XFindBox();
            this.dcxBunryu5 = new IHIS.Framework.XDictComboBox();
            this.dcxBunryu7 = new IHIS.Framework.XDictComboBox();
            this.dcxBunryu8 = new IHIS.Framework.XDictComboBox();
            this.dcxBunryu6 = new IHIS.Framework.XDictComboBox();
            this.cbx1 = new IHIS.Framework.XCheckBox();
            this.cbx2 = new IHIS.Framework.XCheckBox();
            this.cbx3 = new IHIS.Framework.XCheckBox();
            this.cbx4 = new IHIS.Framework.XCheckBox();
            this.cbx5 = new IHIS.Framework.XCheckBox();
            this.cbx6 = new IHIS.Framework.XCheckBox();
            this.cbx7 = new IHIS.Framework.XCheckBox();
            this.cbx8 = new IHIS.Framework.XCheckBox();
            this.cbx9 = new IHIS.Framework.XCheckBox();
            this.cbxA = new IHIS.Framework.XCheckBox();
            this.cbxB = new IHIS.Framework.XCheckBox();
            this.cbxC = new IHIS.Framework.XCheckBox();
            this.dcbColorText = new IHIS.Framework.XDictComboBox();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.cbxD = new IHIS.Framework.XCheckBox();
            this.dpxYuhyyo = new IHIS.Framework.XDatePicker();
            this.fbxCompanyName = new IHIS.Framework.XFindBox();
            this.dcxDrgJibgyeGubun = new IHIS.Framework.XDictComboBox();
            this.chkToijangYn = new IHIS.Framework.XCheckBox();
            this.chkE = new IHIS.Framework.XCheckBox();
            this.chkF = new IHIS.Framework.XCheckBox();
            this.txtRemark = new IHIS.Framework.XTextBox();
            this.txtDrgComment = new IHIS.Framework.XTextBox();
            this.layDetail = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem310 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem325 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem326 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem327 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem328 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem329 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem330 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem331 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem332 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem333 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem334 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem335 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem336 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem337 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem338 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem339 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem340 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem341 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem342 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem343 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem344 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem345 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem346 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem347 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem348 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem349 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem350 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem351 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem352 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem353 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem354 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem355 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem356 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem357 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem358 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem359 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem360 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem361 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem362 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem363 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem364 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem365 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem366 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem367 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem368 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem369 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem370 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem371 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem372 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem373 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem374 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem375 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem376 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem377 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem378 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem379 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem380 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem381 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem382 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem383 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem384 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem385 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem386 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem387 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem388 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem389 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem390 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem391 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem392 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem393 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem394 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem395 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem396 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem397 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem398 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem399 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem400 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem401 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem402 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem403 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem404 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem405 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem406 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem407 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem408 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem409 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem410 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem411 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem412 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem413 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem414 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem415 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem416 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem417 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem418 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem419 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem420 = new IHIS.Framework.MultiLayoutItem();
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
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOCS0103 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.btnBAS0310U00 = new IHIS.Framework.XButton();
            this.btnOCS0103U00 = new IHIS.Framework.XButton();
            this.btnDRG0112U00 = new IHIS.Framework.XButton();
            this.SLIP_CODE = new IHIS.Framework.XDictComboBox();
            this.xButton1 = new IHIS.Framework.XButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xButton2 = new IHIS.Framework.XButton();
            this.xDisplayBox1 = new IHIS.Framework.XDisplayBox();
            this.fblText = new IHIS.Framework.XFlatLabel();
            this.xLabel42 = new IHIS.Framework.XLabel();
            this.emBulyongDate = new IHIS.Framework.XDatePicker();
            this.xLabel48 = new IHIS.Framework.XLabel();
            this.txtActJaeryoName = new IHIS.Framework.XTextBox();
            this.dbxSmall1 = new IHIS.Framework.XDisplayBox();
            this.xLabel41 = new IHIS.Framework.XLabel();
            this.xLabel37 = new IHIS.Framework.XLabel();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.txtYongRyang = new IHIS.Framework.XTextBox();
            this.xLabel35 = new IHIS.Framework.XLabel();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.xLabel32 = new IHIS.Framework.XLabel();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.dbxLabelDanui2 = new IHIS.Framework.XDisplayBox();
            this.fbxLabelDanui2 = new IHIS.Framework.XFindBox();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.emDrgTrunc = new IHIS.Framework.XEditMask();
            this.dbxLabelDanui = new IHIS.Framework.XDisplayBox();
            this.fbxLabelDanui = new IHIS.Framework.XFindBox();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.dbxOrderDanui = new IHIS.Framework.XDisplayBox();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.fbxOrderDanui = new IHIS.Framework.XFindBox();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.txtGijunDanga = new IHIS.Framework.XEditMask();
            this.txtDanga = new IHIS.Framework.XEditMask();
            this.dbxCompanyName = new IHIS.Framework.XDisplayBox();
            this.dbxBaljuDanui = new IHIS.Framework.XDisplayBox();
            this.dbxSubulDanui = new IHIS.Framework.XDisplayBox();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel39 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layExcel = new IHIS.Framework.MultiLayout();
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
            this.fdwOCS0102 = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInv0110)).BeginInit();
            this.pnlKind.SuspendLayout();
            this.gbxSugbJaeryo.SuspendLayout();
            this.gbxInp.SuspendLayout();
            this.gbxOut.SuspendLayout();
            this.gbxLabel.SuspendLayout();
            this.gbxMix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layDetail)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "EXCEL", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.Location = new System.Drawing.Point(619, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(487, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdInv0110
            // 
            this.grdInv0110.CallerID = 'D';
            this.grdInv0110.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.sungbun_code,
            this.jnaeryo_code,
            this.jnaeryo_name});
            this.grdInv0110.ColPerLine = 2;
            this.grdInv0110.ColResizable = true;
            this.grdInv0110.Cols = 3;
            this.grdInv0110.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInv0110.FixedCols = 1;
            this.grdInv0110.FixedRows = 1;
            this.grdInv0110.HeaderHeights.Add(24);
            this.grdInv0110.Location = new System.Drawing.Point(2, 84);
            this.grdInv0110.Name = "grdInv0110";
            this.grdInv0110.QuerySQL = resources.GetString("grdInv0110.QuerySQL");
            this.grdInv0110.RowHeaderVisible = true;
            this.grdInv0110.Rows = 2;
            this.grdInv0110.Size = new System.Drawing.Size(433, 684);
            this.grdInv0110.TabIndex = 1;
            this.grdInv0110.ToolTipActive = true;
            this.grdInv0110.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdInv0110_QueryEnd);
            this.grdInv0110.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdInv0110_RowFocusChanged);
            this.grdInv0110.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdInv0110_QueryStarting);
            // 
            // sungbun_code
            // 
            this.sungbun_code.CellName = "sungbun_code";
            this.sungbun_code.CellWidth = 42;
            this.sungbun_code.Col = -1;
            this.sungbun_code.HeaderText = "成分コード";
            this.sungbun_code.IsUpdatable = false;
            this.sungbun_code.IsUpdCol = false;
            this.sungbun_code.IsVisible = false;
            this.sungbun_code.Row = -1;
            // 
            // jnaeryo_code
            // 
            this.jnaeryo_code.CellName = "jaeryo_code";
            this.jnaeryo_code.CellWidth = 95;
            this.jnaeryo_code.Col = 1;
            this.jnaeryo_code.EnableSort = true;
            this.jnaeryo_code.HeaderText = "薬品コード";
            this.jnaeryo_code.IsReadOnly = true;
            // 
            // jnaeryo_name
            // 
            this.jnaeryo_name.CellLen = 100;
            this.jnaeryo_name.CellName = "jaeryo_name";
            this.jnaeryo_name.CellWidth = 292;
            this.jnaeryo_name.Col = 2;
            this.jnaeryo_name.EnableSort = true;
            this.jnaeryo_name.HeaderText = "薬品名";
            this.jnaeryo_name.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.jnaeryo_name.IsUpdatable = false;
            this.jnaeryo_name.IsUpdCol = false;
            // 
            // pnlKind
            // 
            this.pnlKind.Controls.Add(this.btnQuery);
            this.pnlKind.Controls.Add(this.btnQueryIns);
            this.pnlKind.Controls.Add(this.xLabel43);
            this.pnlKind.Controls.Add(this.cbxBulyong);
            this.pnlKind.Controls.Add(this.dbxJaeryo);
            this.pnlKind.Controls.Add(this.xLabel17);
            this.pnlKind.Controls.Add(this.cboBunryu);
            this.pnlKind.Controls.Add(this.fbxJaeryo);
            this.pnlKind.Controls.Add(this.xLabel40);
            this.pnlKind.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKind.Location = new System.Drawing.Point(2, 2);
            this.pnlKind.Name = "pnlKind";
            this.pnlKind.Size = new System.Drawing.Size(433, 82);
            this.pnlKind.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(222, 52);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnQuery.Size = new System.Drawing.Size(209, 26);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "照会";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnQueryIns
            // 
            this.btnQueryIns.Location = new System.Drawing.Point(5, 52);
            this.btnQueryIns.Name = "btnQueryIns";
            this.btnQueryIns.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnQueryIns.Size = new System.Drawing.Size(209, 26);
            this.btnQueryIns.TabIndex = 157;
            this.btnQueryIns.Text = "照会条件入力";
            this.btnQueryIns.Click += new System.EventHandler(this.btnQueryIns_Click);
            // 
            // xLabel43
            // 
            this.xLabel43.Location = new System.Drawing.Point(222, 28);
            this.xLabel43.Name = "xLabel43";
            this.xLabel43.Size = new System.Drawing.Size(75, 20);
            this.xLabel43.TabIndex = 156;
            this.xLabel43.Text = "使用可否";
            this.xLabel43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxBulyong
            // 
            this.cbxBulyong.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cbxBulyong.Location = new System.Drawing.Point(298, 27);
            this.cbxBulyong.Name = "cbxBulyong";
            this.cbxBulyong.Size = new System.Drawing.Size(130, 21);
            this.cbxBulyong.TabIndex = 4;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "全体";
            this.xComboItem1.ValueItem = "1";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "採用";
            this.xComboItem2.ValueItem = "2";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "不採用";
            this.xComboItem3.ValueItem = "3";
            // 
            // dbxJaeryo
            // 
            this.dbxJaeryo.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.dbxJaeryo.Location = new System.Drawing.Point(178, 4);
            this.dbxJaeryo.Name = "dbxJaeryo";
            this.dbxJaeryo.Size = new System.Drawing.Size(250, 20);
            this.dbxJaeryo.TabIndex = 2;
            // 
            // xLabel17
            // 
            this.xLabel17.Location = new System.Drawing.Point(5, 28);
            this.xLabel17.Name = "xLabel17";
            this.xLabel17.Size = new System.Drawing.Size(75, 20);
            this.xLabel17.TabIndex = 80;
            this.xLabel17.Text = "薬品大分類";
            this.xLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBunryu
            // 
            this.cboBunryu.ItemHeight = 13;
            this.cboBunryu.Location = new System.Drawing.Point(82, 27);
            this.cboBunryu.MaxDropDownItems = 30;
            this.cboBunryu.Name = "cboBunryu";
            this.cboBunryu.Size = new System.Drawing.Size(130, 21);
            this.cboBunryu.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboBunryu.TabIndex = 3;
            // 
            // fbxJaeryo
            // 
            this.fbxJaeryo.FindWorker = this.fwkJaeryo;
            this.fbxJaeryo.Location = new System.Drawing.Point(82, 4);
            this.fbxJaeryo.Name = "fbxJaeryo";
            this.fbxJaeryo.Size = new System.Drawing.Size(94, 20);
            this.fbxJaeryo.TabIndex = 1;
            this.fbxJaeryo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fbxJaeryo_KeyDown);
            this.fbxJaeryo.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJaeryo_DataValidating);
            // 
            // fwkJaeryo
            // 
            this.fwkJaeryo.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4,
            this.findColumnInfo7});
            this.fwkJaeryo.FormText = "薬品コード";
            this.fwkJaeryo.InputSQL = resources.GetString("fwkJaeryo.InputSQL");
            this.fwkJaeryo.IsSetControlText = true;
            this.fwkJaeryo.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkJaeryo.ServerFilter = true;
            this.fwkJaeryo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkJaeryo_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "jaeryo_code";
            this.findColumnInfo3.ColWidth = 98;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo3.HeaderText = "薬品コード";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "jaeryo_name";
            this.findColumnInfo4.ColWidth = 194;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo4.HeaderText = "薬品";
            // 
            // findColumnInfo7
            // 
            this.findColumnInfo7.ColName = "bulyong_date";
            this.findColumnInfo7.HeaderText = "不用日付";
            // 
            // xLabel40
            // 
            this.xLabel40.Location = new System.Drawing.Point(5, 4);
            this.xLabel40.Name = "xLabel40";
            this.xLabel40.Size = new System.Drawing.Size(75, 20);
            this.xLabel40.TabIndex = 9;
            this.xLabel40.Text = "薬品コード";
            this.xLabel40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "jaeryo_code";
            this.findColumnInfo1.ColWidth = 98;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "薬品コード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "jaeryo_name";
            this.findColumnInfo2.ColWidth = 194;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "薬品";
            // 
            // fbxSubulDanui
            // 
            this.fbxSubulDanui.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxSubulDanui.FindWorker = this.fwkCommon;
            this.fbxSubulDanui.Location = new System.Drawing.Point(108, 480);
            this.fbxSubulDanui.Name = "fbxSubulDanui";
            this.fbxSubulDanui.Size = new System.Drawing.Size(56, 20);
            this.fbxSubulDanui.TabIndex = 27;
            this.fbxSubulDanui.Enter += new System.EventHandler(this.fbxSubulDanui_Enter);
            this.fbxSubulDanui.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSubulDanui_DataValidating);
            this.fbxSubulDanui.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSubulDanui_FindClick);
            // 
            // xLabel2
            // 
            this.xLabel2.Location = new System.Drawing.Point(12, 588);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(94, 20);
            this.xLabel2.TabIndex = 100;
            this.xLabel2.Text = "不採用事由";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxSubulQcodeInp
            // 
            this.dbxSubulQcodeInp.Location = new System.Drawing.Point(552, 478);
            this.dbxSubulQcodeInp.Name = "dbxSubulQcodeInp";
            this.dbxSubulQcodeInp.Size = new System.Drawing.Size(104, 19);
            this.dbxSubulQcodeInp.TabIndex = 99;
            // 
            // dbxBulyongCode
            // 
            this.dbxBulyongCode.Location = new System.Drawing.Point(180, 588);
            this.dbxBulyongCode.Name = "dbxBulyongCode";
            this.dbxBulyongCode.Size = new System.Drawing.Size(480, 20);
            this.dbxBulyongCode.TabIndex = 98;
            // 
            // dbxSubulQcodeEr
            // 
            this.dbxSubulQcodeEr.Location = new System.Drawing.Point(552, 502);
            this.dbxSubulQcodeEr.Name = "dbxSubulQcodeEr";
            this.dbxSubulQcodeEr.Size = new System.Drawing.Size(104, 19);
            this.dbxSubulQcodeEr.TabIndex = 97;
            // 
            // dbxSubulQcodeOut
            // 
            this.dbxSubulQcodeOut.Location = new System.Drawing.Point(552, 454);
            this.dbxSubulQcodeOut.Name = "dbxSubulQcodeOut";
            this.dbxSubulQcodeOut.Size = new System.Drawing.Size(104, 19);
            this.dbxSubulQcodeOut.TabIndex = 96;
            // 
            // dbxCustomerName
            // 
            this.dbxCustomerName.Location = new System.Drawing.Point(354, 456);
            this.dbxCustomerName.Name = "dbxCustomerName";
            this.dbxCustomerName.Size = new System.Drawing.Size(120, 20);
            this.dbxCustomerName.TabIndex = 95;
            // 
            // gbxSugbJaeryo
            // 
            this.gbxSugbJaeryo.Controls.Add(this.rbxSugbJaeryoN);
            this.gbxSugbJaeryo.Controls.Add(this.rbxSugbJaeryoY);
            this.gbxSugbJaeryo.Location = new System.Drawing.Point(108, 500);
            this.gbxSugbJaeryo.Name = "gbxSugbJaeryo";
            this.gbxSugbJaeryo.Protect = true;
            this.gbxSugbJaeryo.Size = new System.Drawing.Size(100, 26);
            this.gbxSugbJaeryo.TabIndex = 29;
            this.gbxSugbJaeryo.TabStop = false;
            // 
            // rbxSugbJaeryoN
            // 
            this.rbxSugbJaeryoN.Location = new System.Drawing.Point(61, 7);
            this.rbxSugbJaeryoN.Name = "rbxSugbJaeryoN";
            this.rbxSugbJaeryoN.Size = new System.Drawing.Size(26, 16);
            this.rbxSugbJaeryoN.TabIndex = 1;
            this.rbxSugbJaeryoN.Text = "N";
            this.rbxSugbJaeryoN.UseVisualStyleBackColor = false;
            // 
            // rbxSugbJaeryoY
            // 
            this.rbxSugbJaeryoY.Location = new System.Drawing.Point(15, 7);
            this.rbxSugbJaeryoY.Name = "rbxSugbJaeryoY";
            this.rbxSugbJaeryoY.Size = new System.Drawing.Size(26, 16);
            this.rbxSugbJaeryoY.TabIndex = 0;
            this.rbxSugbJaeryoY.Text = "Y";
            this.rbxSugbJaeryoY.UseVisualStyleBackColor = false;
            // 
            // fbxBaljuDanui
            // 
            this.fbxBaljuDanui.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxBaljuDanui.FindWorker = this.fwkCommon;
            this.fbxBaljuDanui.Location = new System.Drawing.Point(225, 480);
            this.fbxBaljuDanui.Name = "fbxBaljuDanui";
            this.fbxBaljuDanui.Size = new System.Drawing.Size(56, 20);
            this.fbxBaljuDanui.TabIndex = 28;
            this.fbxBaljuDanui.Enter += new System.EventHandler(this.fbxBaljuDanui_Enter);
            this.fbxBaljuDanui.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBaljuDanui_DataValidating);
            this.fbxBaljuDanui.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBaljuDanui_FindClick);
            // 
            // fbxBaljuBuseo
            // 
            this.fbxBaljuBuseo.FindWorker = this.fwkCommon;
            this.fbxBaljuBuseo.Location = new System.Drawing.Point(406, 504);
            this.fbxBaljuBuseo.Name = "fbxBaljuBuseo";
            this.fbxBaljuBuseo.Size = new System.Drawing.Size(68, 20);
            this.fbxBaljuBuseo.TabIndex = 26;
            this.fbxBaljuBuseo.Enter += new System.EventHandler(this.fbxBaljuBuseo_Enter);
            this.fbxBaljuBuseo.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBaljuBuseo_FindClick);
            // 
            // fbxSubulBuseo
            // 
            this.fbxSubulBuseo.FindWorker = this.fwkCommon;
            this.fbxSubulBuseo.Location = new System.Drawing.Point(406, 480);
            this.fbxSubulBuseo.Name = "fbxSubulBuseo";
            this.fbxSubulBuseo.Size = new System.Drawing.Size(68, 20);
            this.fbxSubulBuseo.TabIndex = 25;
            this.fbxSubulBuseo.Enter += new System.EventHandler(this.fbxSubulBuseo_Enter);
            this.fbxSubulBuseo.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSubulBuseo_FindClick);
            // 
            // txtChangeQtyl
            // 
            this.txtChangeQtyl.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.txtChangeQtyl.Location = new System.Drawing.Point(274, 504);
            this.txtChangeQtyl.Name = "txtChangeQtyl";
            this.txtChangeQtyl.Size = new System.Drawing.Size(66, 20);
            this.txtChangeQtyl.TabIndex = 30;
            // 
            // dtpJukyongDate
            // 
            this.dtpJukyongDate.Location = new System.Drawing.Point(562, 564);
            this.dtpJukyongDate.Name = "dtpJukyongDate";
            this.dtpJukyongDate.Size = new System.Drawing.Size(98, 20);
            this.dtpJukyongDate.TabIndex = 31;
            this.dtpJukyongDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fbxBulyongCode
            // 
            this.fbxBulyongCode.FindWorker = this.fwkCommon;
            this.fbxBulyongCode.Location = new System.Drawing.Point(108, 588);
            this.fbxBulyongCode.Name = "fbxBulyongCode";
            this.fbxBulyongCode.Size = new System.Drawing.Size(70, 20);
            this.fbxBulyongCode.TabIndex = 32;
            this.fbxBulyongCode.Enter += new System.EventHandler(this.fbxBulyongCode_Enter);
            this.fbxBulyongCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBulyongCode_DataValidating);
            this.fbxBulyongCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBulyongCode_FindClick);
            // 
            // fbxSubulQcodeEr
            // 
            this.fbxSubulQcodeEr.FindWorker = this.fwkCommon;
            this.fbxSubulQcodeEr.Location = new System.Drawing.Point(514, 502);
            this.fbxSubulQcodeEr.Name = "fbxSubulQcodeEr";
            this.fbxSubulQcodeEr.Size = new System.Drawing.Size(36, 20);
            this.fbxSubulQcodeEr.TabIndex = 22;
            this.fbxSubulQcodeEr.Enter += new System.EventHandler(this.fbxSubulQcodeEr_Enter);
            this.fbxSubulQcodeEr.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSubulQcodeEr_DataValidating);
            this.fbxSubulQcodeEr.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSubulQcodeEr_FindClick);
            // 
            // fbxSubulQcodeInp
            // 
            this.fbxSubulQcodeInp.FindWorker = this.fwkCommon;
            this.fbxSubulQcodeInp.Location = new System.Drawing.Point(514, 478);
            this.fbxSubulQcodeInp.Name = "fbxSubulQcodeInp";
            this.fbxSubulQcodeInp.Size = new System.Drawing.Size(36, 20);
            this.fbxSubulQcodeInp.TabIndex = 21;
            this.fbxSubulQcodeInp.Enter += new System.EventHandler(this.fbxSubulQcodeInp_Enter);
            this.fbxSubulQcodeInp.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSubulQcodeInp_DataValidating);
            this.fbxSubulQcodeInp.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSubulQcodeInp_FindClick);
            // 
            // fbxSubulQcodeOut
            // 
            this.fbxSubulQcodeOut.FindWorker = this.fwkCommon;
            this.fbxSubulQcodeOut.Location = new System.Drawing.Point(514, 454);
            this.fbxSubulQcodeOut.Name = "fbxSubulQcodeOut";
            this.fbxSubulQcodeOut.Size = new System.Drawing.Size(36, 20);
            this.fbxSubulQcodeOut.TabIndex = 20;
            this.fbxSubulQcodeOut.Enter += new System.EventHandler(this.fbxSubulQcodeOut_Enter);
            this.fbxSubulQcodeOut.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSubulQcodeOut_DataValidating);
            this.fbxSubulQcodeOut.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSubulQcodeOut_FindClick);
            // 
            // fbxCustomerCode
            // 
            this.fbxCustomerCode.FindWorker = this.fwkCommon;
            this.fbxCustomerCode.Location = new System.Drawing.Point(292, 456);
            this.fbxCustomerCode.Name = "fbxCustomerCode";
            this.fbxCustomerCode.Size = new System.Drawing.Size(60, 20);
            this.fbxCustomerCode.TabIndex = 24;
            this.fbxCustomerCode.Enter += new System.EventHandler(this.fbxCustomerCode_Enter);
            this.fbxCustomerCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxCustomerCode_DataValidating);
            this.fbxCustomerCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCustomerCode_FindClick);
            // 
            // xLabel23
            // 
            this.xLabel23.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel23.Location = new System.Drawing.Point(480, 502);
            this.xLabel23.Name = "xLabel23";
            this.xLabel23.Size = new System.Drawing.Size(34, 19);
            this.xLabel23.TabIndex = 19;
            this.xLabel23.Text = "応急";
            this.xLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel24
            // 
            this.xLabel24.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel24.Location = new System.Drawing.Point(480, 478);
            this.xLabel24.Name = "xLabel24";
            this.xLabel24.Size = new System.Drawing.Size(34, 19);
            this.xLabel24.TabIndex = 18;
            this.xLabel24.Text = "入院";
            this.xLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel45
            // 
            this.xLabel45.Location = new System.Drawing.Point(466, 564);
            this.xLabel45.Name = "xLabel45";
            this.xLabel45.Size = new System.Drawing.Size(94, 20);
            this.xLabel45.TabIndex = 50;
            this.xLabel45.Text = "採用日付";
            this.xLabel45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel44
            // 
            this.xLabel44.Location = new System.Drawing.Point(12, 456);
            this.xLabel44.Name = "xLabel44";
            this.xLabel44.Size = new System.Drawing.Size(94, 20);
            this.xLabel44.TabIndex = 43;
            this.xLabel44.Text = "標準小売価";
            this.xLabel44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel38
            // 
            this.xLabel38.Location = new System.Drawing.Point(12, 564);
            this.xLabel38.Name = "xLabel38";
            this.xLabel38.Size = new System.Drawing.Size(94, 20);
            this.xLabel38.TabIndex = 40;
            this.xLabel38.Text = "不用日付";
            this.xLabel38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel46
            // 
            this.xLabel46.Location = new System.Drawing.Point(210, 456);
            this.xLabel46.Name = "xLabel46";
            this.xLabel46.Size = new System.Drawing.Size(80, 20);
            this.xLabel46.TabIndex = 49;
            this.xLabel46.Text = "取引業体";
            this.xLabel46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel47
            // 
            this.xLabel47.Location = new System.Drawing.Point(210, 432);
            this.xLabel47.Name = "xLabel47";
            this.xLabel47.Size = new System.Drawing.Size(80, 20);
            this.xLabel47.TabIndex = 48;
            this.xLabel47.Text = "製造会社";
            this.xLabel47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel34
            // 
            this.xLabel34.Location = new System.Drawing.Point(12, 504);
            this.xLabel34.Name = "xLabel34";
            this.xLabel34.Size = new System.Drawing.Size(94, 20);
            this.xLabel34.TabIndex = 32;
            this.xLabel34.Text = "需給計画可否";
            this.xLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel27
            // 
            this.xLabel27.Location = new System.Drawing.Point(210, 504);
            this.xLabel27.Name = "xLabel27";
            this.xLabel27.Size = new System.Drawing.Size(62, 20);
            this.xLabel27.TabIndex = 27;
            this.xLabel27.Text = "換算数量";
            this.xLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel28
            // 
            this.xLabel28.Location = new System.Drawing.Point(12, 480);
            this.xLabel28.Name = "xLabel28";
            this.xLabel28.Size = new System.Drawing.Size(94, 20);
            this.xLabel28.TabIndex = 26;
            this.xLabel28.Text = "受払/発注単位";
            this.xLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel29
            // 
            this.xLabel29.Location = new System.Drawing.Point(342, 480);
            this.xLabel29.Name = "xLabel29";
            this.xLabel29.Size = new System.Drawing.Size(62, 20);
            this.xLabel29.TabIndex = 25;
            this.xLabel29.Text = "受払部署";
            this.xLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel64
            // 
            this.xLabel64.Location = new System.Drawing.Point(12, 432);
            this.xLabel64.Name = "xLabel64";
            this.xLabel64.Size = new System.Drawing.Size(94, 20);
            this.xLabel64.TabIndex = 41;
            this.xLabel64.Text = "単価";
            this.xLabel64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBunryu4
            // 
            this.dbxBunryu4.Location = new System.Drawing.Point(492, 220);
            this.dbxBunryu4.Name = "dbxBunryu4";
            this.dbxBunryu4.Size = new System.Drawing.Size(168, 20);
            this.dbxBunryu4.TabIndex = 90;
            // 
            // fbxBunryu4
            // 
            this.fbxBunryu4.AutoTabDataSelected = true;
            this.fbxBunryu4.FindWorker = this.fwkCommon;
            this.fbxBunryu4.Location = new System.Drawing.Point(438, 220);
            this.fbxBunryu4.MaxLength = 2;
            this.fbxBunryu4.Name = "fbxBunryu4";
            this.fbxBunryu4.Size = new System.Drawing.Size(52, 20);
            this.fbxBunryu4.TabIndex = 13;
            this.fbxBunryu4.Enter += new System.EventHandler(this.fbxBunryu4_Enter);
            this.fbxBunryu4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunryu4_DataValidating);
            this.fbxBunryu4.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunryu4_FindClick);
            // 
            // xLabel10
            // 
            this.xLabel10.Location = new System.Drawing.Point(328, 220);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(108, 20);
            this.xLabel10.TabIndex = 88;
            this.xLabel10.Text = "経口/外用剤細分";
            this.xLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBunryu3
            // 
            this.dbxBunryu3.Location = new System.Drawing.Point(154, 220);
            this.dbxBunryu3.Name = "dbxBunryu3";
            this.dbxBunryu3.Size = new System.Drawing.Size(170, 20);
            this.dbxBunryu3.TabIndex = 87;
            // 
            // fbxBunryu3
            // 
            this.fbxBunryu3.AutoTabDataSelected = true;
            this.fbxBunryu3.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxBunryu3.FindWorker = this.fwkCommon;
            this.fbxBunryu3.Location = new System.Drawing.Point(108, 220);
            this.fbxBunryu3.MaxLength = 2;
            this.fbxBunryu3.Name = "fbxBunryu3";
            this.fbxBunryu3.Size = new System.Drawing.Size(44, 20);
            this.fbxBunryu3.TabIndex = 12;
            this.fbxBunryu3.Enter += new System.EventHandler(this.fbxBunryu3_Enter);
            this.fbxBunryu3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunryu3_DataValidating);
            this.fbxBunryu3.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunryu3_FindClick);
            // 
            // xLabel9
            // 
            this.xLabel9.Location = new System.Drawing.Point(12, 220);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(94, 20);
            this.xLabel9.TabIndex = 85;
            this.xLabel9.Text = "注射剤成分類";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBunryu2
            // 
            this.dbxBunryu2.Location = new System.Drawing.Point(492, 196);
            this.dbxBunryu2.Name = "dbxBunryu2";
            this.dbxBunryu2.Size = new System.Drawing.Size(168, 20);
            this.dbxBunryu2.TabIndex = 84;
            // 
            // fbxBunryu2
            // 
            this.fbxBunryu2.AutoTabDataSelected = true;
            this.fbxBunryu2.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxBunryu2.FindWorker = this.fwkCommon;
            this.fbxBunryu2.Location = new System.Drawing.Point(438, 196);
            this.fbxBunryu2.MaxLength = 2;
            this.fbxBunryu2.Name = "fbxBunryu2";
            this.fbxBunryu2.Size = new System.Drawing.Size(52, 20);
            this.fbxBunryu2.TabIndex = 11;
            this.fbxBunryu2.Enter += new System.EventHandler(this.fbxBunryu2_Enter);
            this.fbxBunryu2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunryu2_DataValidating);
            this.fbxBunryu2.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunryu2_FindClick);
            // 
            // xLabel6
            // 
            this.xLabel6.Location = new System.Drawing.Point(328, 196);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(108, 20);
            this.xLabel6.TabIndex = 82;
            this.xLabel6.Text = "薬品中分類";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBunryu1
            // 
            this.dbxBunryu1.Location = new System.Drawing.Point(154, 196);
            this.dbxBunryu1.Name = "dbxBunryu1";
            this.dbxBunryu1.Size = new System.Drawing.Size(170, 20);
            this.dbxBunryu1.TabIndex = 81;
            // 
            // fbxBunryu1
            // 
            this.fbxBunryu1.AutoTabDataSelected = true;
            this.fbxBunryu1.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxBunryu1.FindWorker = this.fwkCommon;
            this.fbxBunryu1.Location = new System.Drawing.Point(108, 196);
            this.fbxBunryu1.MaxLength = 2;
            this.fbxBunryu1.Name = "fbxBunryu1";
            this.fbxBunryu1.Size = new System.Drawing.Size(44, 20);
            this.fbxBunryu1.TabIndex = 10;
            this.fbxBunryu1.Enter += new System.EventHandler(this.fbxBunryu1_Enter);
            this.fbxBunryu1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunryu1_DataValidating);
            this.fbxBunryu1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunryu1_FindClick);
            // 
            // xLabel4
            // 
            this.xLabel4.Location = new System.Drawing.Point(12, 196);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(94, 20);
            this.xLabel4.TabIndex = 79;
            this.xLabel4.Text = "薬品大分類";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxCautionCode
            // 
            this.dbxCautionCode.Location = new System.Drawing.Point(190, 244);
            this.dbxCautionCode.Name = "dbxCautionCode";
            this.dbxCautionCode.Size = new System.Drawing.Size(470, 20);
            this.dbxCautionCode.TabIndex = 77;
            // 
            // dbxDrgType
            // 
            this.dbxDrgType.Location = new System.Drawing.Point(542, 148);
            this.dbxDrgType.Name = "dbxDrgType";
            this.dbxDrgType.Size = new System.Drawing.Size(118, 20);
            this.dbxDrgType.TabIndex = 76;
            // 
            // dbxSmall
            // 
            this.dbxSmall.Location = new System.Drawing.Point(192, 172);
            this.dbxSmall.Name = "dbxSmall";
            this.dbxSmall.Size = new System.Drawing.Size(144, 20);
            this.dbxSmall.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.label4.EdgeRounding = false;
            this.label4.Location = new System.Drawing.Point(184, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 19);
            this.label4.TabIndex = 74;
            this.label4.Text = "/";
            // 
            // fbxCautionCode
            // 
            this.fbxCautionCode.FindWorker = this.fwkCommon;
            this.fbxCautionCode.Location = new System.Drawing.Point(108, 244);
            this.fbxCautionCode.Name = "fbxCautionCode";
            this.fbxCautionCode.Size = new System.Drawing.Size(79, 20);
            this.fbxCautionCode.TabIndex = 14;
            this.fbxCautionCode.Enter += new System.EventHandler(this.fbxCautionCode_Enter);
            this.fbxCautionCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxCautionCode_DataValidating);
            this.fbxCautionCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCautionCode_FindClick);
            // 
            // fbxDrgType
            // 
            this.fbxDrgType.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxDrgType.FindWorker = this.fwkCommon;
            this.fbxDrgType.Location = new System.Drawing.Point(484, 148);
            this.fbxDrgType.Name = "fbxDrgType";
            this.fbxDrgType.Size = new System.Drawing.Size(56, 20);
            this.fbxDrgType.TabIndex = 8;
            this.fbxDrgType.Enter += new System.EventHandler(this.fbxDrgType_Enter);
            this.fbxDrgType.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDrgType_DataValidating);
            this.fbxDrgType.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDrgType_FindClick);
            // 
            // fbxSmall
            // 
            this.fbxSmall.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxSmall.Location = new System.Drawing.Point(108, 172);
            this.fbxSmall.Name = "fbxSmall";
            this.fbxSmall.Size = new System.Drawing.Size(82, 20);
            this.fbxSmall.TabIndex = 9;
            this.fbxSmall.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSmall_DataValidating_1);
            this.fbxSmall.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSmall_FindClick);
            // 
            // dcbBunryu9
            // 
            this.dcbBunryu9.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.dcbBunryu9.ItemHeight = 13;
            this.dcbBunryu9.Location = new System.Drawing.Point(108, 148);
            this.dcbBunryu9.MaxDropDownItems = 30;
            this.dcbBunryu9.Name = "dcbBunryu9";
            this.dcbBunryu9.Size = new System.Drawing.Size(312, 21);
            this.dcbBunryu9.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.dcbBunryu9.TabIndex = 7;
            // 
            // txtKyukyeok
            // 
            this.txtKyukyeok.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.txtKyukyeok.Location = new System.Drawing.Point(200, 124);
            this.txtKyukyeok.Name = "txtKyukyeok";
            this.txtKyukyeok.Size = new System.Drawing.Size(72, 20);
            this.txtKyukyeok.TabIndex = 6;
            // 
            // txtHamryang
            // 
            this.txtHamryang.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.txtHamryang.Location = new System.Drawing.Point(108, 124);
            this.txtHamryang.Name = "txtHamryang";
            this.txtHamryang.Size = new System.Drawing.Size(72, 20);
            this.txtHamryang.TabIndex = 5;
            // 
            // txtJaeryoEname
            // 
            this.txtJaeryoEname.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtJaeryoEname.Location = new System.Drawing.Point(200, 78);
            this.txtJaeryoEname.Name = "txtJaeryoEname";
            this.txtJaeryoEname.Size = new System.Drawing.Size(460, 20);
            this.txtJaeryoEname.TabIndex = 4;
            // 
            // txtJaeryoName
            // 
            this.txtJaeryoName.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtJaeryoName.Location = new System.Drawing.Point(200, 56);
            this.txtJaeryoName.Name = "txtJaeryoName";
            this.txtJaeryoName.Size = new System.Drawing.Size(460, 20);
            this.txtJaeryoName.TabIndex = 3;
            // 
            // txtSungBunName
            // 
            this.txtSungBunName.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtSungBunName.Location = new System.Drawing.Point(200, 34);
            this.txtSungBunName.Name = "txtSungBunName";
            this.txtSungBunName.Size = new System.Drawing.Size(460, 20);
            this.txtSungBunName.TabIndex = 1;
            // 
            // txtJaeryoCode
            // 
            this.txtJaeryoCode.Location = new System.Drawing.Point(108, 56);
            this.txtJaeryoCode.Name = "txtJaeryoCode";
            this.txtJaeryoCode.Size = new System.Drawing.Size(90, 20);
            this.txtJaeryoCode.TabIndex = 2;
            // 
            // txtSungBunCode
            // 
            this.txtSungBunCode.Location = new System.Drawing.Point(108, 34);
            this.txtSungBunCode.Name = "txtSungBunCode";
            this.txtSungBunCode.Size = new System.Drawing.Size(90, 20);
            this.txtSungBunCode.TabIndex = 0;
            // 
            // xLabel3
            // 
            this.xLabel3.Location = new System.Drawing.Point(422, 148);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(60, 20);
            this.xLabel3.TabIndex = 3;
            this.xLabel3.Text = "剤型";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel7.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xLabel7.Location = new System.Drawing.Point(160, 78);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(36, 20);
            this.xLabel7.TabIndex = 11;
            this.xLabel7.Text = "(カナ)";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel5
            // 
            this.xLabel5.Location = new System.Drawing.Point(12, 148);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(94, 20);
            this.xLabel5.TabIndex = 5;
            this.xLabel5.Text = "保管方法";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel26
            // 
            this.xLabel26.Location = new System.Drawing.Point(12, 124);
            this.xLabel26.Name = "xLabel26";
            this.xLabel26.Size = new System.Drawing.Size(94, 20);
            this.xLabel26.TabIndex = 28;
            this.xLabel26.Text = "含量/規格";
            this.xLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel30
            // 
            this.xLabel30.Location = new System.Drawing.Point(12, 172);
            this.xLabel30.Name = "xLabel30";
            this.xLabel30.Size = new System.Drawing.Size(94, 20);
            this.xLabel30.TabIndex = 24;
            this.xLabel30.Text = "効能別分類";
            this.xLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel8
            // 
            this.xLabel8.Location = new System.Drawing.Point(12, 56);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(94, 20);
            this.xLabel8.TabIndex = 10;
            this.xLabel8.Text = "薬品コード";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel54
            // 
            this.xLabel54.Location = new System.Drawing.Point(12, 244);
            this.xLabel54.Name = "xLabel54";
            this.xLabel54.Size = new System.Drawing.Size(94, 20);
            this.xLabel54.TabIndex = 53;
            this.xLabel54.Text = "注意事項";
            this.xLabel54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(12, 34);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(94, 20);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "成分コード";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxInp
            // 
            this.gbxInp.Controls.Add(this.rbxInpN);
            this.gbxInp.Controls.Add(this.rbxInpY);
            this.gbxInp.Location = new System.Drawing.Point(72, 60);
            this.gbxInp.Name = "gbxInp";
            this.gbxInp.Protect = true;
            this.gbxInp.Size = new System.Drawing.Size(70, 26);
            this.gbxInp.TabIndex = 71;
            this.gbxInp.TabStop = false;
            // 
            // rbxInpN
            // 
            this.rbxInpN.Location = new System.Drawing.Point(38, 7);
            this.rbxInpN.Name = "rbxInpN";
            this.rbxInpN.Size = new System.Drawing.Size(26, 16);
            this.rbxInpN.TabIndex = 1;
            this.rbxInpN.Text = "N";
            this.rbxInpN.UseVisualStyleBackColor = false;
            // 
            // rbxInpY
            // 
            this.rbxInpY.Location = new System.Drawing.Point(6, 7);
            this.rbxInpY.Name = "rbxInpY";
            this.rbxInpY.Size = new System.Drawing.Size(26, 16);
            this.rbxInpY.TabIndex = 0;
            this.rbxInpY.Text = "Y";
            this.rbxInpY.UseVisualStyleBackColor = false;
            // 
            // gbxOut
            // 
            this.gbxOut.Controls.Add(this.rbxOutN);
            this.gbxOut.Controls.Add(this.rbxOutY);
            this.gbxOut.Location = new System.Drawing.Point(72, 32);
            this.gbxOut.Name = "gbxOut";
            this.gbxOut.Protect = true;
            this.gbxOut.Size = new System.Drawing.Size(70, 26);
            this.gbxOut.TabIndex = 1;
            this.gbxOut.TabStop = false;
            // 
            // rbxOutN
            // 
            this.rbxOutN.Location = new System.Drawing.Point(38, 8);
            this.rbxOutN.Name = "rbxOutN";
            this.rbxOutN.Size = new System.Drawing.Size(26, 16);
            this.rbxOutN.TabIndex = 1;
            this.rbxOutN.Text = "N";
            this.rbxOutN.UseVisualStyleBackColor = false;
            // 
            // rbxOutY
            // 
            this.rbxOutY.Location = new System.Drawing.Point(8, 8);
            this.rbxOutY.Name = "rbxOutY";
            this.rbxOutY.Size = new System.Drawing.Size(26, 16);
            this.rbxOutY.TabIndex = 0;
            this.rbxOutY.Text = "Y";
            this.rbxOutY.UseVisualStyleBackColor = false;
            // 
            // xLabel60
            // 
            this.xLabel60.Location = new System.Drawing.Point(20, 64);
            this.xLabel60.Name = "xLabel60";
            this.xLabel60.Size = new System.Drawing.Size(52, 20);
            this.xLabel60.TabIndex = 58;
            this.xLabel60.Text = "入院";
            this.xLabel60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel61
            // 
            this.xLabel61.Location = new System.Drawing.Point(16, 36);
            this.xLabel61.Name = "xLabel61";
            this.xLabel61.Size = new System.Drawing.Size(56, 20);
            this.xLabel61.TabIndex = 0;
            this.xLabel61.Text = "外来";
            this.xLabel61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel62
            // 
            this.xLabel62.Location = new System.Drawing.Point(16, 8);
            this.xLabel62.Name = "xLabel62";
            this.xLabel62.Size = new System.Drawing.Size(96, 20);
            this.xLabel62.TabIndex = 56;
            this.xLabel62.Text = "A T C";
            this.xLabel62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel11
            // 
            this.xLabel11.Location = new System.Drawing.Point(12, 120);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(96, 20);
            this.xLabel11.TabIndex = 7;
            this.xLabel11.Text = "ラベル印刷";
            this.xLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxLabel
            // 
            this.gbxLabel.Controls.Add(this.rbxLabelN);
            this.gbxLabel.Controls.Add(this.rbxLabelY);
            this.gbxLabel.Location = new System.Drawing.Point(104, 116);
            this.gbxLabel.Name = "gbxLabel";
            this.gbxLabel.Protect = true;
            this.gbxLabel.Size = new System.Drawing.Size(72, 26);
            this.gbxLabel.TabIndex = 74;
            this.gbxLabel.TabStop = false;
            // 
            // rbxLabelN
            // 
            this.rbxLabelN.Location = new System.Drawing.Point(38, 7);
            this.rbxLabelN.Name = "rbxLabelN";
            this.rbxLabelN.Size = new System.Drawing.Size(26, 16);
            this.rbxLabelN.TabIndex = 1;
            this.rbxLabelN.Text = "N";
            this.rbxLabelN.UseVisualStyleBackColor = false;
            // 
            // rbxLabelY
            // 
            this.rbxLabelY.Location = new System.Drawing.Point(6, 7);
            this.rbxLabelY.Name = "rbxLabelY";
            this.rbxLabelY.Size = new System.Drawing.Size(26, 16);
            this.rbxLabelY.TabIndex = 0;
            this.rbxLabelY.Text = "Y";
            this.rbxLabelY.UseVisualStyleBackColor = false;
            // 
            // xLabel14
            // 
            this.xLabel14.Location = new System.Drawing.Point(12, 96);
            this.xLabel14.Name = "xLabel14";
            this.xLabel14.Size = new System.Drawing.Size(96, 20);
            this.xLabel14.TabIndex = 16;
            this.xLabel14.Text = "単独可否";
            this.xLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxMix
            // 
            this.gbxMix.Controls.Add(this.rbxMixN);
            this.gbxMix.Controls.Add(this.rbxMixY);
            this.gbxMix.Location = new System.Drawing.Point(104, 92);
            this.gbxMix.Name = "gbxMix";
            this.gbxMix.Protect = true;
            this.gbxMix.Size = new System.Drawing.Size(70, 26);
            this.gbxMix.TabIndex = 72;
            this.gbxMix.TabStop = false;
            // 
            // rbxMixN
            // 
            this.rbxMixN.CheckedValue = "N";
            this.rbxMixN.Location = new System.Drawing.Point(38, 6);
            this.rbxMixN.Name = "rbxMixN";
            this.rbxMixN.Size = new System.Drawing.Size(26, 16);
            this.rbxMixN.TabIndex = 1;
            this.rbxMixN.Text = "N";
            this.rbxMixN.UseVisualStyleBackColor = false;
            // 
            // rbxMixY
            // 
            this.rbxMixY.Location = new System.Drawing.Point(6, 6);
            this.rbxMixY.Name = "rbxMixY";
            this.rbxMixY.Size = new System.Drawing.Size(26, 16);
            this.rbxMixY.TabIndex = 0;
            this.rbxMixY.Text = "Y";
            this.rbxMixY.UseVisualStyleBackColor = false;
            // 
            // txtChanggo
            // 
            this.txtChanggo.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.txtChanggo.Location = new System.Drawing.Point(484, 124);
            this.txtChanggo.Name = "txtChanggo";
            this.txtChanggo.Size = new System.Drawing.Size(176, 20);
            this.txtChanggo.TabIndex = 144;
            // 
            // txtManageNo
            // 
            this.txtManageNo.Location = new System.Drawing.Point(524, 4);
            this.txtManageNo.Name = "txtManageNo";
            this.txtManageNo.Size = new System.Drawing.Size(136, 20);
            this.txtManageNo.TabIndex = 152;
            // 
            // fbxSmall1
            // 
            this.fbxSmall1.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxSmall1.Location = new System.Drawing.Point(338, 172);
            this.fbxSmall1.Name = "fbxSmall1";
            this.fbxSmall1.Size = new System.Drawing.Size(82, 20);
            this.fbxSmall1.TabIndex = 154;
            this.fbxSmall1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSmall1_DataValidating);
            this.fbxSmall1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSmall1_FindClick);
            // 
            // dcxBunryu5
            // 
            this.dcxBunryu5.Location = new System.Drawing.Point(12, 268);
            this.dcxBunryu5.Name = "dcxBunryu5";
            this.dcxBunryu5.Size = new System.Drawing.Size(112, 21);
            this.dcxBunryu5.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.dcxBunryu5.TabIndex = 124;
            this.dcxBunryu5.MouseEnter += new System.EventHandler(this.dcxBunryu5_DDLBSetting);
            this.dcxBunryu5.DDLBSetting += new System.EventHandler(this.dcxBunryu5_DDLBSetting);
            // 
            // dcxBunryu7
            // 
            this.dcxBunryu7.Location = new System.Drawing.Point(126, 268);
            this.dcxBunryu7.Name = "dcxBunryu7";
            this.dcxBunryu7.Size = new System.Drawing.Size(112, 21);
            this.dcxBunryu7.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.dcxBunryu7.TabIndex = 126;
            this.dcxBunryu7.MouseEnter += new System.EventHandler(this.dcxBunryu7_DDLBSetting);
            this.dcxBunryu7.DDLBSetting += new System.EventHandler(this.dcxBunryu7_DDLBSetting);
            // 
            // dcxBunryu8
            // 
            this.dcxBunryu8.Location = new System.Drawing.Point(240, 268);
            this.dcxBunryu8.Name = "dcxBunryu8";
            this.dcxBunryu8.Size = new System.Drawing.Size(112, 21);
            this.dcxBunryu8.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.dcxBunryu8.TabIndex = 127;
            this.dcxBunryu8.MouseEnter += new System.EventHandler(this.dcxBunryu8_DDLBSetting);
            this.dcxBunryu8.DDLBSetting += new System.EventHandler(this.dcxBunryu8_DDLBSetting);
            // 
            // dcxBunryu6
            // 
            this.dcxBunryu6.Location = new System.Drawing.Point(354, 268);
            this.dcxBunryu6.Name = "dcxBunryu6";
            this.dcxBunryu6.Size = new System.Drawing.Size(112, 21);
            this.dcxBunryu6.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.dcxBunryu6.TabIndex = 125;
            this.dcxBunryu6.MouseEnter += new System.EventHandler(this.dcxBunryu6_DDLBSetting);
            this.dcxBunryu6.DDLBSetting += new System.EventHandler(this.dcxBunryu6_DDLBSetting);
            // 
            // cbx1
            // 
            this.cbx1.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbx1.Location = new System.Drawing.Point(20, 322);
            this.cbx1.Name = "cbx1";
            this.cbx1.Size = new System.Drawing.Size(102, 20);
            this.cbx1.TabIndex = 129;
            this.cbx1.Text = "粉砕";
            this.cbx1.UseVisualStyleBackColor = false;
            // 
            // cbx2
            // 
            this.cbx2.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbx2.Location = new System.Drawing.Point(124, 322);
            this.cbx2.Name = "cbx2";
            this.cbx2.Size = new System.Drawing.Size(102, 20);
            this.cbx2.TabIndex = 130;
            this.cbx2.Text = "簡易懸濁";
            this.cbx2.UseVisualStyleBackColor = false;
            // 
            // cbx3
            // 
            this.cbx3.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbx3.Location = new System.Drawing.Point(232, 322);
            this.cbx3.Name = "cbx3";
            this.cbx3.Size = new System.Drawing.Size(102, 20);
            this.cbx3.TabIndex = 131;
            this.cbx3.Text = "一包化";
            this.cbx3.UseVisualStyleBackColor = false;
            // 
            // cbx4
            // 
            this.cbx4.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbx4.Location = new System.Drawing.Point(340, 322);
            this.cbx4.Name = "cbx4";
            this.cbx4.Size = new System.Drawing.Size(102, 20);
            this.cbx4.TabIndex = 132;
            this.cbx4.Text = "混合";
            this.cbx4.UseVisualStyleBackColor = false;
            // 
            // cbx5
            // 
            this.cbx5.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbx5.Location = new System.Drawing.Point(448, 322);
            this.cbx5.Name = "cbx5";
            this.cbx5.Size = new System.Drawing.Size(102, 20);
            this.cbx5.TabIndex = 133;
            this.cbx5.Text = "MIX";
            this.cbx5.UseVisualStyleBackColor = false;
            // 
            // cbx6
            // 
            this.cbx6.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbx6.Location = new System.Drawing.Point(20, 346);
            this.cbx6.Name = "cbx6";
            this.cbx6.Size = new System.Drawing.Size(102, 20);
            this.cbx6.TabIndex = 134;
            this.cbx6.Text = "在庫僅少";
            this.cbx6.UseVisualStyleBackColor = false;
            // 
            // cbx7
            // 
            this.cbx7.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbx7.Location = new System.Drawing.Point(124, 346);
            this.cbx7.Name = "cbx7";
            this.cbx7.Size = new System.Drawing.Size(102, 20);
            this.cbx7.TabIndex = 137;
            this.cbx7.Text = "事前準備";
            this.cbx7.UseVisualStyleBackColor = false;
            // 
            // cbx8
            // 
            this.cbx8.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbx8.Location = new System.Drawing.Point(232, 346);
            this.cbx8.Name = "cbx8";
            this.cbx8.Size = new System.Drawing.Size(102, 20);
            this.cbx8.TabIndex = 138;
            this.cbx8.Text = "調剤薬局購入";
            this.cbx8.UseVisualStyleBackColor = false;
            // 
            // cbx9
            // 
            this.cbx9.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbx9.Location = new System.Drawing.Point(340, 347);
            this.cbx9.Name = "cbx9";
            this.cbx9.Size = new System.Drawing.Size(102, 20);
            this.cbx9.TabIndex = 136;
            this.cbx9.Text = "化学療法剤";
            this.cbx9.UseVisualStyleBackColor = false;
            // 
            // cbxA
            // 
            this.cbxA.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbxA.Location = new System.Drawing.Point(448, 346);
            this.cbxA.Name = "cbxA";
            this.cbxA.Size = new System.Drawing.Size(102, 20);
            this.cbxA.TabIndex = 139;
            this.cbxA.Text = "レジメ管理";
            this.cbxA.UseVisualStyleBackColor = false;
            // 
            // cbxB
            // 
            this.cbxB.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbxB.Location = new System.Drawing.Point(554, 322);
            this.cbxB.Name = "cbxB";
            this.cbxB.Size = new System.Drawing.Size(102, 20);
            this.cbxB.TabIndex = 140;
            this.cbxB.Text = "抗がん剤";
            this.cbxB.UseVisualStyleBackColor = false;
            // 
            // cbxC
            // 
            this.cbxC.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.cbxC.Location = new System.Drawing.Point(554, 346);
            this.cbxC.Name = "cbxC";
            this.cbxC.Size = new System.Drawing.Size(102, 20);
            this.cbxC.TabIndex = 135;
            this.cbxC.Text = "受注発注";
            this.cbxC.UseVisualStyleBackColor = false;
            // 
            // dcbColorText
            // 
            this.dcbColorText.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem4,
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7,
            this.xComboItem8,
            this.xComboItem9});
            this.dcbColorText.Location = new System.Drawing.Point(354, 292);
            this.dcbColorText.Name = "dcbColorText";
            this.dcbColorText.Size = new System.Drawing.Size(112, 21);
            this.dcbColorText.TabIndex = 150;
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "Normal";
            this.xComboItem4.ValueItem = "33554432";
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "Red";
            this.xComboItem5.ValueItem = "255";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "Blue";
            this.xComboItem6.ValueItem = "16711680";
            // 
            // xComboItem7
            // 
            this.xComboItem7.DisplayItem = "Green";
            this.xComboItem7.ValueItem = "32768";
            // 
            // xComboItem8
            // 
            this.xComboItem8.DisplayItem = "Yellow";
            this.xComboItem8.ValueItem = "65535";
            // 
            // xComboItem9
            // 
            this.xComboItem9.DisplayItem = "Maroon";
            this.xComboItem9.ValueItem = "128";
            // 
            // cbxD
            // 
            this.cbxD.Location = new System.Drawing.Point(124, 691);
            this.cbxD.Name = "cbxD";
            this.cbxD.Size = new System.Drawing.Size(276, 20);
            this.cbxD.TabIndex = 146;
            this.cbxD.Text = "チェックされると処方箋に表示される。";
            this.cbxD.UseVisualStyleBackColor = false;
            // 
            // dpxYuhyyo
            // 
            this.dpxYuhyyo.Location = new System.Drawing.Point(538, 292);
            this.dpxYuhyyo.Name = "dpxYuhyyo";
            this.dpxYuhyyo.Size = new System.Drawing.Size(96, 20);
            this.dpxYuhyyo.TabIndex = 128;
            this.dpxYuhyyo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fbxCompanyName
            // 
            this.fbxCompanyName.FindWorker = this.fwkCommon;
            this.fbxCompanyName.Location = new System.Drawing.Point(292, 432);
            this.fbxCompanyName.Name = "fbxCompanyName";
            this.fbxCompanyName.Size = new System.Drawing.Size(60, 20);
            this.fbxCompanyName.TabIndex = 23;
            this.fbxCompanyName.Enter += new System.EventHandler(this.fbxCompanyName_Enter);
            this.fbxCompanyName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxCompanyName_DataValidating);
            this.fbxCompanyName.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCompanyName_FindClick);
            // 
            // dcxDrgJibgyeGubun
            // 
            this.dcxDrgJibgyeGubun.Location = new System.Drawing.Point(538, 268);
            this.dcxDrgJibgyeGubun.Name = "dcxDrgJibgyeGubun";
            this.dcxDrgJibgyeGubun.Size = new System.Drawing.Size(120, 21);
            this.dcxDrgJibgyeGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.dcxDrgJibgyeGubun.TabIndex = 161;
            this.dcxDrgJibgyeGubun.UserSQL = "SELECT CODE, CODE_NAME FROM INV0102 WHERE CODE_TYPE = \'UJ\' AND HOSP_CODE = \'XXX\'";
            // 
            // chkToijangYn
            // 
            this.chkToijangYn.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.chkToijangYn.Location = new System.Drawing.Point(20, 368);
            this.chkToijangYn.Name = "chkToijangYn";
            this.chkToijangYn.Size = new System.Drawing.Size(104, 24);
            this.chkToijangYn.TabIndex = 165;
            this.chkToijangYn.Text = "後発不可";
            this.chkToijangYn.UseVisualStyleBackColor = false;
            // 
            // chkE
            // 
            this.chkE.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.chkE.Location = new System.Drawing.Point(124, 368);
            this.chkE.Name = "chkE";
            this.chkE.Size = new System.Drawing.Size(104, 24);
            this.chkE.TabIndex = 166;
            this.chkE.Text = "抗凝固剤";
            this.chkE.UseVisualStyleBackColor = false;
            // 
            // chkF
            // 
            this.chkF.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.chkF.Location = new System.Drawing.Point(232, 368);
            this.chkF.Name = "chkF";
            this.chkF.Size = new System.Drawing.Size(104, 24);
            this.chkF.TabIndex = 167;
            this.chkF.Text = "ハイリスク薬";
            this.chkF.UseVisualStyleBackColor = false;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(12, 645);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(648, 32);
            this.txtRemark.TabIndex = 110;
            // 
            // txtDrgComment
            // 
            this.txtDrgComment.Location = new System.Drawing.Point(12, 713);
            this.txtDrgComment.Multiline = true;
            this.txtDrgComment.Name = "txtDrgComment";
            this.txtDrgComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDrgComment.Size = new System.Drawing.Size(648, 47);
            this.txtDrgComment.TabIndex = 142;
            // 
            // layDetail
            // 
            this.layDetail.CallerID = 'S';
            this.layDetail.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem309,
            this.multiLayoutItem310,
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
            this.multiLayoutItem324,
            this.multiLayoutItem325,
            this.multiLayoutItem326,
            this.multiLayoutItem327,
            this.multiLayoutItem328,
            this.multiLayoutItem329,
            this.multiLayoutItem330,
            this.multiLayoutItem331,
            this.multiLayoutItem332,
            this.multiLayoutItem333,
            this.multiLayoutItem334,
            this.multiLayoutItem335,
            this.multiLayoutItem336,
            this.multiLayoutItem337,
            this.multiLayoutItem338,
            this.multiLayoutItem339,
            this.multiLayoutItem340,
            this.multiLayoutItem341,
            this.multiLayoutItem342,
            this.multiLayoutItem343,
            this.multiLayoutItem344,
            this.multiLayoutItem345,
            this.multiLayoutItem346,
            this.multiLayoutItem347,
            this.multiLayoutItem348,
            this.multiLayoutItem349,
            this.multiLayoutItem350,
            this.multiLayoutItem351,
            this.multiLayoutItem352,
            this.multiLayoutItem353,
            this.multiLayoutItem354,
            this.multiLayoutItem355,
            this.multiLayoutItem356,
            this.multiLayoutItem357,
            this.multiLayoutItem358,
            this.multiLayoutItem359,
            this.multiLayoutItem360,
            this.multiLayoutItem361,
            this.multiLayoutItem362,
            this.multiLayoutItem363,
            this.multiLayoutItem364,
            this.multiLayoutItem365,
            this.multiLayoutItem366,
            this.multiLayoutItem367,
            this.multiLayoutItem368,
            this.multiLayoutItem369,
            this.multiLayoutItem370,
            this.multiLayoutItem371,
            this.multiLayoutItem372,
            this.multiLayoutItem373,
            this.multiLayoutItem374,
            this.multiLayoutItem375,
            this.multiLayoutItem376,
            this.multiLayoutItem377,
            this.multiLayoutItem378,
            this.multiLayoutItem379,
            this.multiLayoutItem380,
            this.multiLayoutItem381,
            this.multiLayoutItem382,
            this.multiLayoutItem383,
            this.multiLayoutItem384,
            this.multiLayoutItem385,
            this.multiLayoutItem386,
            this.multiLayoutItem387,
            this.multiLayoutItem388,
            this.multiLayoutItem389,
            this.multiLayoutItem390,
            this.multiLayoutItem391,
            this.multiLayoutItem392,
            this.multiLayoutItem393,
            this.multiLayoutItem394,
            this.multiLayoutItem395,
            this.multiLayoutItem396,
            this.multiLayoutItem397,
            this.multiLayoutItem398,
            this.multiLayoutItem399,
            this.multiLayoutItem400,
            this.multiLayoutItem401,
            this.multiLayoutItem402,
            this.multiLayoutItem403,
            this.multiLayoutItem404,
            this.multiLayoutItem405,
            this.multiLayoutItem406,
            this.multiLayoutItem407,
            this.multiLayoutItem408,
            this.multiLayoutItem409,
            this.multiLayoutItem410,
            this.multiLayoutItem411,
            this.multiLayoutItem412,
            this.multiLayoutItem413,
            this.multiLayoutItem414,
            this.multiLayoutItem415,
            this.multiLayoutItem416,
            this.multiLayoutItem417,
            this.multiLayoutItem418,
            this.multiLayoutItem419,
            this.multiLayoutItem420,
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
            this.multiLayoutItem448});
            this.layDetail.QuerySQL = resources.GetString("layDetail.QuerySQL");
            this.layDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDetail_QueryStarting);
            this.layDetail.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layDetail_QueryEnd);
            this.layDetail.PreSaveLayout += new IHIS.Framework.MultiRecordEventHandler(this.layDetail_PreSaveLayout);
            // 
            // multiLayoutItem255
            // 
            this.multiLayoutItem255.DataName = "lead_time";
            this.multiLayoutItem255.IsUpdItem = true;
            // 
            // multiLayoutItem256
            // 
            this.multiLayoutItem256.DataName = "avg_qty_d";
            this.multiLayoutItem256.IsUpdItem = true;
            // 
            // multiLayoutItem257
            // 
            this.multiLayoutItem257.DataName = "avg_qty_w";
            this.multiLayoutItem257.IsUpdItem = true;
            // 
            // multiLayoutItem258
            // 
            this.multiLayoutItem258.DataName = "avg_qty_m";
            this.multiLayoutItem258.IsUpdItem = true;
            // 
            // multiLayoutItem259
            // 
            this.multiLayoutItem259.DataName = "max_qty_d";
            this.multiLayoutItem259.IsUpdItem = true;
            // 
            // multiLayoutItem260
            // 
            this.multiLayoutItem260.DataName = "max_qty_w";
            this.multiLayoutItem260.IsUpdItem = true;
            // 
            // multiLayoutItem261
            // 
            this.multiLayoutItem261.DataName = "max_qty_m";
            this.multiLayoutItem261.IsUpdItem = true;
            // 
            // multiLayoutItem262
            // 
            this.multiLayoutItem262.DataName = "hamryang";
            this.multiLayoutItem262.IsUpdItem = true;
            // 
            // multiLayoutItem263
            // 
            this.multiLayoutItem263.DataName = "jeje_gijun_qty";
            this.multiLayoutItem263.IsUpdItem = true;
            // 
            // multiLayoutItem264
            // 
            this.multiLayoutItem264.DataName = "mix_yn";
            this.multiLayoutItem264.IsUpdItem = true;
            // 
            // multiLayoutItem265
            // 
            this.multiLayoutItem265.DataName = "mix_yn_inp";
            this.multiLayoutItem265.IsUpdItem = true;
            // 
            // multiLayoutItem266
            // 
            this.multiLayoutItem266.DataName = "atc_yn";
            this.multiLayoutItem266.IsUpdItem = true;
            // 
            // multiLayoutItem267
            // 
            this.multiLayoutItem267.DataName = "atc_yn_inp";
            this.multiLayoutItem267.IsUpdItem = true;
            // 
            // multiLayoutItem268
            // 
            this.multiLayoutItem268.DataName = "atc_code";
            this.multiLayoutItem268.IsUpdItem = true;
            // 
            // multiLayoutItem269
            // 
            this.multiLayoutItem269.DataName = "bogyong_code";
            this.multiLayoutItem269.IsUpdItem = true;
            // 
            // multiLayoutItem270
            // 
            this.multiLayoutItem270.DataName = "hyoneung_code";
            this.multiLayoutItem270.IsUpdItem = true;
            // 
            // multiLayoutItem271
            // 
            this.multiLayoutItem271.DataName = "caution_code";
            this.multiLayoutItem271.IsUpdItem = true;
            // 
            // multiLayoutItem272
            // 
            this.multiLayoutItem272.DataName = "main_use_gwa1";
            this.multiLayoutItem272.IsUpdItem = true;
            // 
            // multiLayoutItem273
            // 
            this.multiLayoutItem273.DataName = "main_use_gwa2";
            this.multiLayoutItem273.IsUpdItem = true;
            // 
            // multiLayoutItem274
            // 
            this.multiLayoutItem274.DataName = "main_use_gwa3";
            this.multiLayoutItem274.IsUpdItem = true;
            // 
            // multiLayoutItem275
            // 
            this.multiLayoutItem275.DataName = "main_use_gwa4";
            this.multiLayoutItem275.IsUpdItem = true;
            // 
            // multiLayoutItem276
            // 
            this.multiLayoutItem276.DataName = "main_use_gwa5";
            this.multiLayoutItem276.IsUpdItem = true;
            // 
            // multiLayoutItem277
            // 
            this.multiLayoutItem277.DataName = "bulyong_to_date";
            this.multiLayoutItem277.IsUpdItem = true;
            // 
            // multiLayoutItem278
            // 
            this.multiLayoutItem278.DataName = "sugb_jaeryo_yn";
            this.multiLayoutItem278.IsUpdItem = true;
            // 
            // multiLayoutItem279
            // 
            this.multiLayoutItem279.DataName = "gijun_amt";
            this.multiLayoutItem279.IsUpdItem = true;
            // 
            // multiLayoutItem280
            // 
            this.multiLayoutItem280.DataName = "gijun_assure_amt";
            this.multiLayoutItem280.IsUpdItem = true;
            // 
            // multiLayoutItem281
            // 
            this.multiLayoutItem281.DataName = "bungi_acct";
            this.multiLayoutItem281.IsUpdItem = true;
            // 
            // multiLayoutItem282
            // 
            this.multiLayoutItem282.DataName = "old_manage_no";
            this.multiLayoutItem282.IsUpdItem = true;
            // 
            // multiLayoutItem283
            // 
            this.multiLayoutItem283.DataName = "manage_no1";
            this.multiLayoutItem283.IsUpdItem = true;
            // 
            // multiLayoutItem284
            // 
            this.multiLayoutItem284.DataName = "manage_no2";
            this.multiLayoutItem284.IsUpdItem = true;
            // 
            // multiLayoutItem285
            // 
            this.multiLayoutItem285.DataName = "manage_no3";
            this.multiLayoutItem285.IsUpdItem = true;
            // 
            // multiLayoutItem286
            // 
            this.multiLayoutItem286.DataName = "manage_no4";
            this.multiLayoutItem286.IsUpdItem = true;
            // 
            // multiLayoutItem287
            // 
            this.multiLayoutItem287.DataName = "changgo1";
            this.multiLayoutItem287.IsUpdItem = true;
            // 
            // multiLayoutItem288
            // 
            this.multiLayoutItem288.DataName = "changgo2";
            this.multiLayoutItem288.IsUpdItem = true;
            // 
            // multiLayoutItem289
            // 
            this.multiLayoutItem289.DataName = "changgo3";
            this.multiLayoutItem289.IsUpdItem = true;
            // 
            // multiLayoutItem290
            // 
            this.multiLayoutItem290.DataName = "danga";
            this.multiLayoutItem290.IsUpdItem = true;
            // 
            // multiLayoutItem291
            // 
            this.multiLayoutItem291.DataName = "jukjung_qty";
            this.multiLayoutItem291.IsUpdItem = true;
            // 
            // multiLayoutItem292
            // 
            this.multiLayoutItem292.DataName = "order_danui";
            this.multiLayoutItem292.IsUpdItem = true;
            // 
            // multiLayoutItem293
            // 
            this.multiLayoutItem293.DataName = "gijun_danga";
            this.multiLayoutItem293.IsUpdItem = true;
            // 
            // multiLayoutItem294
            // 
            this.multiLayoutItem294.DataName = "gijun_kyukyeok";
            this.multiLayoutItem294.IsUpdItem = true;
            // 
            // multiLayoutItem295
            // 
            this.multiLayoutItem295.DataName = "bunryu9";
            this.multiLayoutItem295.IsUpdItem = true;
            // 
            // multiLayoutItem296
            // 
            this.multiLayoutItem296.DataName = "customer_code2";
            this.multiLayoutItem296.IsUpdItem = true;
            // 
            // multiLayoutItem297
            // 
            this.multiLayoutItem297.DataName = "sungbun_code";
            this.multiLayoutItem297.IsUpdItem = true;
            // 
            // multiLayoutItem298
            // 
            this.multiLayoutItem298.DataName = "bogyong_code1";
            this.multiLayoutItem298.IsUpdItem = true;
            // 
            // multiLayoutItem299
            // 
            this.multiLayoutItem299.DataName = "bogyong_code2";
            this.multiLayoutItem299.IsUpdItem = true;
            // 
            // multiLayoutItem300
            // 
            this.multiLayoutItem300.DataName = "bogyong_code3";
            this.multiLayoutItem300.IsUpdItem = true;
            // 
            // multiLayoutItem301
            // 
            this.multiLayoutItem301.DataName = "bogyong_code4";
            this.multiLayoutItem301.IsUpdItem = true;
            // 
            // multiLayoutItem302
            // 
            this.multiLayoutItem302.DataName = "drg_max_dv";
            this.multiLayoutItem302.IsUpdItem = true;
            // 
            // multiLayoutItem303
            // 
            this.multiLayoutItem303.DataName = "drg_max_suryang";
            this.multiLayoutItem303.IsUpdItem = true;
            // 
            // multiLayoutItem304
            // 
            this.multiLayoutItem304.DataName = "balju_bulyong_date";
            this.multiLayoutItem304.IsUpdItem = true;
            // 
            // multiLayoutItem305
            // 
            this.multiLayoutItem305.DataName = "use_yn";
            this.multiLayoutItem305.IsUpdItem = true;
            // 
            // multiLayoutItem306
            // 
            this.multiLayoutItem306.DataName = "remark";
            this.multiLayoutItem306.IsUpdItem = true;
            // 
            // multiLayoutItem307
            // 
            this.multiLayoutItem307.DataName = "sort_key";
            this.multiLayoutItem307.IsUpdItem = true;
            // 
            // multiLayoutItem308
            // 
            this.multiLayoutItem308.DataName = "weight";
            this.multiLayoutItem308.IsUpdItem = true;
            // 
            // multiLayoutItem309
            // 
            this.multiLayoutItem309.DataName = "ipchal_type";
            this.multiLayoutItem309.IsUpdItem = true;
            // 
            // multiLayoutItem310
            // 
            this.multiLayoutItem310.DataName = "laundry_danga";
            this.multiLayoutItem310.IsUpdItem = true;
            // 
            // multiLayoutItem311
            // 
            this.multiLayoutItem311.DataName = "rack_no";
            this.multiLayoutItem311.IsUpdItem = true;
            // 
            // multiLayoutItem312
            // 
            this.multiLayoutItem312.DataName = "path_bmp";
            this.multiLayoutItem312.IsUpdItem = true;
            // 
            // multiLayoutItem313
            // 
            this.multiLayoutItem313.DataName = "start_date";
            this.multiLayoutItem313.IsUpdItem = true;
            // 
            // multiLayoutItem314
            // 
            this.multiLayoutItem314.DataName = "end_date";
            this.multiLayoutItem314.IsUpdItem = true;
            // 
            // multiLayoutItem315
            // 
            this.multiLayoutItem315.DataName = "label_yn";
            this.multiLayoutItem315.IsUpdItem = true;
            // 
            // multiLayoutItem316
            // 
            this.multiLayoutItem316.DataName = "sys_date";
            this.multiLayoutItem316.IsUpdItem = true;
            // 
            // multiLayoutItem317
            // 
            this.multiLayoutItem317.DataName = "user_id";
            this.multiLayoutItem317.IsUpdItem = true;
            // 
            // multiLayoutItem318
            // 
            this.multiLayoutItem318.DataName = "upd_date";
            this.multiLayoutItem318.IsUpdItem = true;
            // 
            // multiLayoutItem319
            // 
            this.multiLayoutItem319.DataName = "jaeryo_code";
            this.multiLayoutItem319.IsUpdItem = true;
            // 
            // multiLayoutItem320
            // 
            this.multiLayoutItem320.DataName = "manage_no";
            this.multiLayoutItem320.IsUpdItem = true;
            // 
            // multiLayoutItem321
            // 
            this.multiLayoutItem321.DataName = "small_code";
            this.multiLayoutItem321.IsUpdItem = true;
            // 
            // multiLayoutItem322
            // 
            this.multiLayoutItem322.DataName = "jaeryo_name";
            this.multiLayoutItem322.IsUpdItem = true;
            // 
            // multiLayoutItem323
            // 
            this.multiLayoutItem323.DataName = "jaeryo_e_name";
            this.multiLayoutItem323.IsUpdItem = true;
            // 
            // multiLayoutItem324
            // 
            this.multiLayoutItem324.DataName = "jaeryo_name_inx";
            this.multiLayoutItem324.IsUpdItem = true;
            // 
            // multiLayoutItem325
            // 
            this.multiLayoutItem325.DataName = "bunryu_bunho1";
            this.multiLayoutItem325.IsUpdItem = true;
            // 
            // multiLayoutItem326
            // 
            this.multiLayoutItem326.DataName = "bunryu_bunho2";
            this.multiLayoutItem326.IsUpdItem = true;
            // 
            // multiLayoutItem327
            // 
            this.multiLayoutItem327.DataName = "kyukyeok";
            this.multiLayoutItem327.IsUpdItem = true;
            // 
            // multiLayoutItem328
            // 
            this.multiLayoutItem328.DataName = "pris_name";
            this.multiLayoutItem328.IsUpdItem = true;
            // 
            // multiLayoutItem329
            // 
            this.multiLayoutItem329.DataName = "manage_name";
            this.multiLayoutItem329.IsUpdItem = true;
            // 
            // multiLayoutItem330
            // 
            this.multiLayoutItem330.DataName = "sungbun_name";
            this.multiLayoutItem330.IsUpdItem = true;
            // 
            // multiLayoutItem331
            // 
            this.multiLayoutItem331.DataName = "jaeryo_gubun";
            this.multiLayoutItem331.IsUpdItem = true;
            // 
            // multiLayoutItem332
            // 
            this.multiLayoutItem332.DataName = "jaeryo_grade";
            this.multiLayoutItem332.IsUpdItem = true;
            // 
            // multiLayoutItem333
            // 
            this.multiLayoutItem333.DataName = "acct_id";
            this.multiLayoutItem333.IsUpdItem = true;
            // 
            // multiLayoutItem334
            // 
            this.multiLayoutItem334.DataName = "bunryu1";
            this.multiLayoutItem334.IsUpdItem = true;
            // 
            // multiLayoutItem335
            // 
            this.multiLayoutItem335.DataName = "bunryu2";
            this.multiLayoutItem335.IsUpdItem = true;
            // 
            // multiLayoutItem336
            // 
            this.multiLayoutItem336.DataName = "bunryu3";
            this.multiLayoutItem336.IsUpdItem = true;
            // 
            // multiLayoutItem337
            // 
            this.multiLayoutItem337.DataName = "bunryu4";
            this.multiLayoutItem337.IsUpdItem = true;
            // 
            // multiLayoutItem338
            // 
            this.multiLayoutItem338.DataName = "bunryu5";
            this.multiLayoutItem338.IsUpdItem = true;
            // 
            // multiLayoutItem339
            // 
            this.multiLayoutItem339.DataName = "bunryu6";
            this.multiLayoutItem339.IsUpdItem = true;
            // 
            // multiLayoutItem340
            // 
            this.multiLayoutItem340.DataName = "bunryu7";
            this.multiLayoutItem340.IsUpdItem = true;
            // 
            // multiLayoutItem341
            // 
            this.multiLayoutItem341.DataName = "bunryu8";
            this.multiLayoutItem341.IsUpdItem = true;
            // 
            // multiLayoutItem342
            // 
            this.multiLayoutItem342.DataName = "jukyong_date";
            this.multiLayoutItem342.IsUpdItem = true;
            // 
            // multiLayoutItem343
            // 
            this.multiLayoutItem343.DataName = "drg_type";
            this.multiLayoutItem343.IsUpdItem = true;
            // 
            // multiLayoutItem344
            // 
            this.multiLayoutItem344.DataName = "storage_yn";
            this.multiLayoutItem344.IsUpdItem = true;
            // 
            // multiLayoutItem345
            // 
            this.multiLayoutItem345.DataName = "ice_yn";
            this.multiLayoutItem345.IsUpdItem = true;
            // 
            // multiLayoutItem346
            // 
            this.multiLayoutItem346.DataName = "bannab_yn";
            this.multiLayoutItem346.IsUpdItem = true;
            // 
            // multiLayoutItem347
            // 
            this.multiLayoutItem347.DataName = "company_code";
            this.multiLayoutItem347.IsUpdItem = true;
            // 
            // multiLayoutItem348
            // 
            this.multiLayoutItem348.DataName = "customer_code";
            this.multiLayoutItem348.IsUpdItem = true;
            // 
            // multiLayoutItem349
            // 
            this.multiLayoutItem349.DataName = "yuhyo_yn";
            this.multiLayoutItem349.IsUpdItem = true;
            // 
            // multiLayoutItem350
            // 
            this.multiLayoutItem350.DataName = "yuhyo_month";
            this.multiLayoutItem350.IsUpdItem = true;
            // 
            // multiLayoutItem351
            // 
            this.multiLayoutItem351.DataName = "yuhyo_to_date";
            this.multiLayoutItem351.IsUpdItem = true;
            // 
            // multiLayoutItem352
            // 
            this.multiLayoutItem352.DataName = "suib_yn";
            this.multiLayoutItem352.IsUpdItem = true;
            // 
            // multiLayoutItem353
            // 
            this.multiLayoutItem353.DataName = "suib_customer";
            this.multiLayoutItem353.IsUpdItem = true;
            // 
            // multiLayoutItem354
            // 
            this.multiLayoutItem354.DataName = "yunhap_join_yn";
            this.multiLayoutItem354.IsUpdItem = true;
            // 
            // multiLayoutItem355
            // 
            this.multiLayoutItem355.DataName = "yunhap_code";
            this.multiLayoutItem355.IsUpdItem = true;
            // 
            // multiLayoutItem356
            // 
            this.multiLayoutItem356.DataName = "bulyong_code";
            this.multiLayoutItem356.IsUpdItem = true;
            // 
            // multiLayoutItem357
            // 
            this.multiLayoutItem357.DataName = "bulyong_date";
            this.multiLayoutItem357.IsUpdItem = true;
            // 
            // multiLayoutItem358
            // 
            this.multiLayoutItem358.DataName = "subul_qcode_out";
            this.multiLayoutItem358.IsUpdItem = true;
            // 
            // multiLayoutItem359
            // 
            this.multiLayoutItem359.DataName = "subul_qcode_inp";
            this.multiLayoutItem359.IsUpdItem = true;
            // 
            // multiLayoutItem360
            // 
            this.multiLayoutItem360.DataName = "subul_qcode_er";
            this.multiLayoutItem360.IsUpdItem = true;
            // 
            // multiLayoutItem361
            // 
            this.multiLayoutItem361.DataName = "danga_yn";
            this.multiLayoutItem361.IsUpdItem = true;
            // 
            // multiLayoutItem362
            // 
            this.multiLayoutItem362.DataName = "from_danga_date";
            this.multiLayoutItem362.IsUpdItem = true;
            // 
            // multiLayoutItem363
            // 
            this.multiLayoutItem363.DataName = "to_danga_date";
            this.multiLayoutItem363.IsUpdItem = true;
            // 
            // multiLayoutItem364
            // 
            this.multiLayoutItem364.DataName = "subul_danui";
            this.multiLayoutItem364.IsUpdItem = true;
            // 
            // multiLayoutItem365
            // 
            this.multiLayoutItem365.DataName = "balju_danui";
            this.multiLayoutItem365.IsUpdItem = true;
            // 
            // multiLayoutItem366
            // 
            this.multiLayoutItem366.DataName = "order_subul_danui";
            this.multiLayoutItem366.IsUpdItem = true;
            // 
            // multiLayoutItem367
            // 
            this.multiLayoutItem367.DataName = "subul_buseo";
            this.multiLayoutItem367.IsUpdItem = true;
            // 
            // multiLayoutItem368
            // 
            this.multiLayoutItem368.DataName = "balju_buseo";
            this.multiLayoutItem368.IsUpdItem = true;
            // 
            // multiLayoutItem369
            // 
            this.multiLayoutItem369.DataName = "change_qtyl";
            this.multiLayoutItem369.IsUpdItem = true;
            // 
            // multiLayoutItem370
            // 
            this.multiLayoutItem370.DataName = "change_qtyo";
            this.multiLayoutItem370.IsUpdItem = true;
            // 
            // multiLayoutItem371
            // 
            this.multiLayoutItem371.DataName = "jaego_qty";
            this.multiLayoutItem371.IsUpdItem = true;
            // 
            // multiLayoutItem372
            // 
            this.multiLayoutItem372.DataName = "jaego_amt";
            this.multiLayoutItem372.IsUpdItem = true;
            // 
            // multiLayoutItem373
            // 
            this.multiLayoutItem373.DataName = "last_ibgo_danga";
            this.multiLayoutItem373.IsUpdItem = true;
            // 
            // multiLayoutItem374
            // 
            this.multiLayoutItem374.DataName = "last_ibgo_date";
            this.multiLayoutItem374.IsUpdItem = true;
            // 
            // multiLayoutItem375
            // 
            this.multiLayoutItem375.DataName = "last_chulgo_date";
            this.multiLayoutItem375.IsUpdItem = true;
            // 
            // multiLayoutItem376
            // 
            this.multiLayoutItem376.DataName = "bunryu_bunho3";
            this.multiLayoutItem376.IsUpdItem = true;
            // 
            // multiLayoutItem377
            // 
            this.multiLayoutItem377.DataName = "bunryu_bunho4";
            this.multiLayoutItem377.IsUpdItem = true;
            // 
            // multiLayoutItem378
            // 
            this.multiLayoutItem378.DataName = "rack_no2";
            this.multiLayoutItem378.IsUpdItem = true;
            // 
            // multiLayoutItem379
            // 
            this.multiLayoutItem379.DataName = "hamryang_danui";
            this.multiLayoutItem379.IsUpdItem = true;
            // 
            // multiLayoutItem380
            // 
            this.multiLayoutItem380.DataName = "limit_dv";
            this.multiLayoutItem380.IsUpdItem = true;
            // 
            // multiLayoutItem381
            // 
            this.multiLayoutItem381.DataName = "toijang_yn";
            this.multiLayoutItem381.IsUpdItem = true;
            // 
            // multiLayoutItem382
            // 
            this.multiLayoutItem382.DataName = "bunryu_bunho5";
            this.multiLayoutItem382.IsUpdItem = true;
            // 
            // multiLayoutItem383
            // 
            this.multiLayoutItem383.DataName = "delivery_gubun";
            this.multiLayoutItem383.IsUpdItem = true;
            // 
            // multiLayoutItem384
            // 
            this.multiLayoutItem384.DataName = "tb_yn";
            this.multiLayoutItem384.IsUpdItem = true;
            // 
            // multiLayoutItem385
            // 
            this.multiLayoutItem385.DataName = "skin_test_yn";
            this.multiLayoutItem385.IsUpdItem = true;
            // 
            // multiLayoutItem386
            // 
            this.multiLayoutItem386.DataName = "ir_jundal_yn";
            this.multiLayoutItem386.IsUpdItem = true;
            // 
            // multiLayoutItem387
            // 
            this.multiLayoutItem387.DataName = "jusa";
            this.multiLayoutItem387.IsUpdItem = true;
            // 
            // multiLayoutItem388
            // 
            this.multiLayoutItem388.DataName = "change_qtyp";
            this.multiLayoutItem388.IsUpdItem = true;
            // 
            // multiLayoutItem389
            // 
            this.multiLayoutItem389.DataName = "main_sungbun_code";
            this.multiLayoutItem389.IsUpdItem = true;
            // 
            // multiLayoutItem390
            // 
            this.multiLayoutItem390.DataName = "jibgye_yn";
            this.multiLayoutItem390.IsUpdItem = true;
            // 
            // multiLayoutItem391
            // 
            this.multiLayoutItem391.DataName = "bugase_yul";
            this.multiLayoutItem391.IsUpdItem = true;
            // 
            // multiLayoutItem392
            // 
            this.multiLayoutItem392.DataName = "company_name";
            this.multiLayoutItem392.IsUpdItem = true;
            // 
            // multiLayoutItem393
            // 
            this.multiLayoutItem393.DataName = "model_name";
            this.multiLayoutItem393.IsUpdItem = true;
            // 
            // multiLayoutItem394
            // 
            this.multiLayoutItem394.DataName = "first_ibgo_date";
            this.multiLayoutItem394.IsUpdItem = true;
            // 
            // multiLayoutItem395
            // 
            this.multiLayoutItem395.DataName = "ip_addr";
            this.multiLayoutItem395.IsUpdItem = true;
            // 
            // multiLayoutItem396
            // 
            this.multiLayoutItem396.DataName = "re_use_yn";
            this.multiLayoutItem396.IsUpdItem = true;
            // 
            // multiLayoutItem397
            // 
            this.multiLayoutItem397.DataName = "min_chunggu_qty";
            this.multiLayoutItem397.IsUpdItem = true;
            // 
            // multiLayoutItem398
            // 
            this.multiLayoutItem398.DataName = "customer_code3";
            this.multiLayoutItem398.IsUpdItem = true;
            // 
            // multiLayoutItem399
            // 
            this.multiLayoutItem399.DataName = "sutak_yn";
            this.multiLayoutItem399.IsUpdItem = true;
            // 
            // multiLayoutItem400
            // 
            this.multiLayoutItem400.DataName = "curency";
            this.multiLayoutItem400.IsUpdItem = true;
            // 
            // multiLayoutItem401
            // 
            this.multiLayoutItem401.DataName = "set_code";
            this.multiLayoutItem401.IsUpdItem = true;
            // 
            // multiLayoutItem402
            // 
            this.multiLayoutItem402.DataName = "customer_danga";
            this.multiLayoutItem402.IsUpdItem = true;
            // 
            // multiLayoutItem403
            // 
            this.multiLayoutItem403.DataName = "min_balju_qty";
            this.multiLayoutItem403.IsUpdItem = true;
            // 
            // multiLayoutItem404
            // 
            this.multiLayoutItem404.DataName = "label_danui";
            this.multiLayoutItem404.IsUpdItem = true;
            // 
            // multiLayoutItem405
            // 
            this.multiLayoutItem405.DataName = "drg_trunc";
            this.multiLayoutItem405.IsUpdItem = true;
            // 
            // multiLayoutItem406
            // 
            this.multiLayoutItem406.DataName = "label_danui2";
            this.multiLayoutItem406.IsUpdItem = true;
            // 
            // multiLayoutItem407
            // 
            this.multiLayoutItem407.DataName = "small_code_name";
            this.multiLayoutItem407.IsUpdItem = true;
            // 
            // multiLayoutItem408
            // 
            this.multiLayoutItem408.DataName = "drg_type_name";
            this.multiLayoutItem408.IsUpdItem = true;
            // 
            // multiLayoutItem409
            // 
            this.multiLayoutItem409.DataName = "caution_code_name";
            this.multiLayoutItem409.IsUpdItem = true;
            // 
            // multiLayoutItem410
            // 
            this.multiLayoutItem410.DataName = "subul_qcode_out_name";
            this.multiLayoutItem410.IsUpdItem = true;
            // 
            // multiLayoutItem411
            // 
            this.multiLayoutItem411.DataName = "subul_qcode_inp_name";
            this.multiLayoutItem411.IsUpdItem = true;
            // 
            // multiLayoutItem412
            // 
            this.multiLayoutItem412.DataName = "subul_qcode_er_name";
            this.multiLayoutItem412.IsUpdItem = true;
            // 
            // multiLayoutItem413
            // 
            this.multiLayoutItem413.DataName = "customer_code_name";
            this.multiLayoutItem413.IsUpdItem = true;
            // 
            // multiLayoutItem414
            // 
            this.multiLayoutItem414.DataName = "bulyong_code_name";
            this.multiLayoutItem414.IsUpdItem = true;
            // 
            // multiLayoutItem415
            // 
            this.multiLayoutItem415.DataName = "bunryu1_name";
            this.multiLayoutItem415.IsUpdItem = true;
            // 
            // multiLayoutItem416
            // 
            this.multiLayoutItem416.DataName = "bunryu2_name";
            this.multiLayoutItem416.IsUpdItem = true;
            // 
            // multiLayoutItem417
            // 
            this.multiLayoutItem417.DataName = "bunryu3_name";
            this.multiLayoutItem417.IsUpdItem = true;
            // 
            // multiLayoutItem418
            // 
            this.multiLayoutItem418.DataName = "bunryu4_name";
            this.multiLayoutItem418.IsUpdItem = true;
            // 
            // multiLayoutItem419
            // 
            this.multiLayoutItem419.DataName = "company_code_name";
            this.multiLayoutItem419.IsUpdItem = true;
            // 
            // multiLayoutItem420
            // 
            this.multiLayoutItem420.DataName = "subuldanui_name";
            this.multiLayoutItem420.IsUpdItem = true;
            // 
            // multiLayoutItem421
            // 
            this.multiLayoutItem421.DataName = "baljudanui_name";
            this.multiLayoutItem421.IsUpdItem = true;
            // 
            // multiLayoutItem422
            // 
            this.multiLayoutItem422.DataName = "orderdanui_name";
            this.multiLayoutItem422.IsUpdItem = true;
            // 
            // multiLayoutItem423
            // 
            this.multiLayoutItem423.DataName = "labeldanui_name";
            this.multiLayoutItem423.IsUpdItem = true;
            // 
            // multiLayoutItem424
            // 
            this.multiLayoutItem424.DataName = "labeldanui2_name";
            this.multiLayoutItem424.IsUpdItem = true;
            // 
            // multiLayoutItem425
            // 
            this.multiLayoutItem425.DataName = "chk1";
            this.multiLayoutItem425.IsUpdItem = true;
            // 
            // multiLayoutItem426
            // 
            this.multiLayoutItem426.DataName = "chk2";
            this.multiLayoutItem426.IsUpdItem = true;
            // 
            // multiLayoutItem427
            // 
            this.multiLayoutItem427.DataName = "chk3";
            this.multiLayoutItem427.IsUpdItem = true;
            // 
            // multiLayoutItem428
            // 
            this.multiLayoutItem428.DataName = "chk4";
            this.multiLayoutItem428.IsUpdItem = true;
            // 
            // multiLayoutItem429
            // 
            this.multiLayoutItem429.DataName = "chk5";
            this.multiLayoutItem429.IsUpdItem = true;
            // 
            // multiLayoutItem430
            // 
            this.multiLayoutItem430.DataName = "chk6";
            this.multiLayoutItem430.IsUpdItem = true;
            // 
            // multiLayoutItem431
            // 
            this.multiLayoutItem431.DataName = "chk7";
            this.multiLayoutItem431.IsUpdItem = true;
            // 
            // multiLayoutItem432
            // 
            this.multiLayoutItem432.DataName = "chk8";
            this.multiLayoutItem432.IsUpdItem = true;
            // 
            // multiLayoutItem433
            // 
            this.multiLayoutItem433.DataName = "chk9";
            this.multiLayoutItem433.IsUpdItem = true;
            // 
            // multiLayoutItem434
            // 
            this.multiLayoutItem434.DataName = "chkA";
            this.multiLayoutItem434.IsUpdItem = true;
            // 
            // multiLayoutItem435
            // 
            this.multiLayoutItem435.DataName = "chkB";
            this.multiLayoutItem435.IsUpdItem = true;
            // 
            // multiLayoutItem436
            // 
            this.multiLayoutItem436.DataName = "chkC";
            this.multiLayoutItem436.IsUpdItem = true;
            // 
            // multiLayoutItem437
            // 
            this.multiLayoutItem437.DataName = "chkD";
            this.multiLayoutItem437.IsUpdItem = true;
            // 
            // multiLayoutItem438
            // 
            this.multiLayoutItem438.DataName = "DrgComment";
            this.multiLayoutItem438.IsUpdItem = true;
            // 
            // multiLayoutItem439
            // 
            this.multiLayoutItem439.DataName = "YongRyang";
            this.multiLayoutItem439.IsUpdItem = true;
            // 
            // multiLayoutItem440
            // 
            this.multiLayoutItem440.DataName = "ColorText";
            this.multiLayoutItem440.IsUpdItem = true;
            // 
            // multiLayoutItem441
            // 
            this.multiLayoutItem441.DataName = "small_code1";
            this.multiLayoutItem441.IsUpdItem = true;
            // 
            // multiLayoutItem442
            // 
            this.multiLayoutItem442.DataName = "small_code_name1";
            this.multiLayoutItem442.IsUpdItem = true;
            // 
            // multiLayoutItem443
            // 
            this.multiLayoutItem443.DataName = "act_jaeryo_name";
            this.multiLayoutItem443.IsUpdItem = true;
            // 
            // multiLayoutItem444
            // 
            this.multiLayoutItem444.DataName = "small_code_middle_name";
            this.multiLayoutItem444.IsUpdItem = true;
            // 
            // multiLayoutItem445
            // 
            this.multiLayoutItem445.DataName = "drug_price_code";
            this.multiLayoutItem445.IsUpdItem = true;
            // 
            // multiLayoutItem446
            // 
            this.multiLayoutItem446.DataName = "drg_jibgye_gubun";
            this.multiLayoutItem446.IsUpdItem = true;
            // 
            // multiLayoutItem447
            // 
            this.multiLayoutItem447.DataName = "chkE";
            this.multiLayoutItem447.IsUpdItem = true;
            // 
            // multiLayoutItem448
            // 
            this.multiLayoutItem448.DataName = "chkF";
            this.multiLayoutItem448.IsUpdItem = true;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdInv0110);
            this.xPanel1.Controls.Add(this.pnlKind);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel1.Size = new System.Drawing.Size(439, 772);
            this.xPanel1.TabIndex = 4;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdOCS0103);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Controls.Add(this.btnBAS0310U00);
            this.xPanel2.Controls.Add(this.btnOCS0103U00);
            this.xPanel2.Controls.Add(this.btnDRG0112U00);
            this.xPanel2.Controls.Add(this.SLIP_CODE);
            this.xPanel2.Controls.Add(this.xButton1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 777);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1108, 36);
            this.xPanel2.TabIndex = 5;
            // 
            // grdOCS0103
            // 
            this.grdOCS0103.ApplyPaintEventToAllColumn = true;
            this.grdOCS0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
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
            this.xEditGridCell76,
            this.xEditGridCell78,
            this.xEditGridCell77,
            this.xEditGridCell79,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell109,
            this.xEditGridCell112,
            this.xEditGridCell113});
            this.grdOCS0103.ColPerLine = 28;
            this.grdOCS0103.ColResizable = true;
            this.grdOCS0103.Cols = 28;
            this.grdOCS0103.ControlBinding = true;
            this.grdOCS0103.FixedRows = 1;
            this.grdOCS0103.FocusColumnName = "hangmog_code";
            this.grdOCS0103.HeaderHeights.Add(20);
            this.grdOCS0103.Location = new System.Drawing.Point(128, 60);
            this.grdOCS0103.Name = "grdOCS0103";
            this.grdOCS0103.QuerySQL = resources.GetString("grdOCS0103.QuerySQL");
            this.grdOCS0103.ReadOnly = true;
            this.grdOCS0103.Rows = 2;
            this.grdOCS0103.Size = new System.Drawing.Size(140, 124);
            this.grdOCS0103.TabIndex = 7;
            this.grdOCS0103.ToolTipActive = true;
            this.grdOCS0103.Visible = false;
            this.grdOCS0103.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0103_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "hangmog_code";
            this.xEditGridCell1.CellWidth = 74;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.HeaderText = "項目コード";
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell1.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "hangmog_name";
            this.xEditGridCell2.CellWidth = 221;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.HeaderText = "画面名";
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "slip_code";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "オーダ伝票";
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "slip_name";
            this.xEditGridCell81.Col = 2;
            this.xEditGridCell81.HeaderText = "オーダ伝票名";
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "order_gubun_name";
            this.xEditGridCell82.Col = 3;
            this.xEditGridCell82.HeaderText = "オーダ区分";
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "input_control_name";
            this.xEditGridCell83.Col = 4;
            this.xEditGridCell83.HeaderText = "入力制御";
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "ord_danui_name";
            this.xEditGridCell84.Col = 5;
            this.xEditGridCell84.HeaderText = "オーダ単位";
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "display_yn";
            this.xEditGridCell85.Col = 6;
            this.xEditGridCell85.HeaderText = "Displya YN";
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "default_suryang";
            this.xEditGridCell86.Col = 7;
            this.xEditGridCell86.HeaderText = "基本数量";
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "dv_time";
            this.xEditGridCell87.Col = 8;
            this.xEditGridCell87.HeaderText = "Dv Time";
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "bogyong_name";
            this.xEditGridCell88.Col = 9;
            this.xEditGridCell88.HeaderText = "基本服用法";
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "limit_nalsu";
            this.xEditGridCell89.Col = 10;
            this.xEditGridCell89.HeaderText = "制限日数";
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "wonyoi_order_yn";
            this.xEditGridCell90.Col = 11;
            this.xEditGridCell90.HeaderText = "院内/院外区分";
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "jundal_table_out_name";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.HeaderText = "伝達TABLE(外来)";
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "jundal_part_out_name";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.HeaderText = "伝達パート(外来)";
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "jundal_table_inp_name";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.HeaderText = "伝達TABLE(入院)";
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "jundal_part_inp_name";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.HeaderText = "伝達パート(入院)";
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "sg_code";
            this.xEditGridCell91.Col = 12;
            this.xEditGridCell91.HeaderText = "点数コード";
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "sg_name";
            this.xEditGridCell92.Col = 13;
            this.xEditGridCell92.HeaderText = "点数名";
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "sunab_danui_name";
            this.xEditGridCell93.Col = 14;
            this.xEditGridCell93.HeaderText = "収納単位";
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "bulyong_ymd";
            this.xEditGridCell94.Col = 15;
            this.xEditGridCell94.HeaderText = "点数不用日";
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "toijang_yn";
            this.xEditGridCell95.Col = 16;
            this.xEditGridCell95.HeaderText = "後発医薬品可否";
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "jaeryo_code";
            this.xEditGridCell96.Col = 17;
            this.xEditGridCell96.HeaderText = "材料コード";
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "jaeryo_name";
            this.xEditGridCell97.Col = 18;
            this.xEditGridCell97.HeaderText = "材料名";
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "subul_danui_name";
            this.xEditGridCell98.Col = 19;
            this.xEditGridCell98.HeaderText = "在庫単位";
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "bulyong_date";
            this.xEditGridCell99.Col = 20;
            this.xEditGridCell99.HeaderText = "材料不用日";
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "bannab_yn";
            this.xEditGridCell102.Col = 23;
            this.xEditGridCell102.HeaderText = "返納YN可否";
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "muhyo_yn";
            this.xEditGridCell103.Col = 24;
            this.xEditGridCell103.HeaderText = "無効オーダ可否";
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ment";
            this.xEditGridCell104.Col = 25;
            this.xEditGridCell104.HeaderText = "参考事項";
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "sys_date";
            this.xEditGridCell105.Col = 26;
            this.xEditGridCell105.HeaderText = "登録日付";
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "create_user_nm";
            this.xEditGridCell109.Col = 27;
            this.xEditGridCell109.HeaderText = "登録者";
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "upd_date";
            this.xEditGridCell112.Col = 28;
            this.xEditGridCell112.HeaderText = "最終修正日";
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "user_nm";
            this.xEditGridCell113.Col = 29;
            this.xEditGridCell113.HeaderText = "最終修正者";
            // 
            // btnBAS0310U00
            // 
            this.btnBAS0310U00.Location = new System.Drawing.Point(224, 4);
            this.btnBAS0310U00.Name = "btnBAS0310U00";
            this.btnBAS0310U00.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnBAS0310U00.Size = new System.Drawing.Size(112, 28);
            this.btnBAS0310U00.TabIndex = 158;
            this.btnBAS0310U00.Text = "点数マスター管理";
            this.btnBAS0310U00.Click += new System.EventHandler(this.btnBAS0310U00_Click);
            // 
            // btnOCS0103U00
            // 
            this.btnOCS0103U00.Location = new System.Drawing.Point(112, 4);
            this.btnOCS0103U00.Name = "btnOCS0103U00";
            this.btnOCS0103U00.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnOCS0103U00.Size = new System.Drawing.Size(112, 28);
            this.btnOCS0103U00.TabIndex = 157;
            this.btnOCS0103U00.Text = "項目コ-ド管理";
            this.btnOCS0103U00.Click += new System.EventHandler(this.btnOCS0103U00_Click);
            // 
            // btnDRG0112U00
            // 
            this.btnDRG0112U00.Location = new System.Drawing.Point(0, 4);
            this.btnDRG0112U00.Name = "btnDRG0112U00";
            this.btnDRG0112U00.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDRG0112U00.Size = new System.Drawing.Size(112, 28);
            this.btnDRG0112U00.TabIndex = 156;
            this.btnDRG0112U00.Text = "薬品名称管理";
            this.btnDRG0112U00.Click += new System.EventHandler(this.btnDRG0112U00_Click);
            // 
            // SLIP_CODE
            // 
            this.SLIP_CODE.Location = new System.Drawing.Point(452, 8);
            this.SLIP_CODE.Name = "SLIP_CODE";
            this.SLIP_CODE.Size = new System.Drawing.Size(140, 21);
            this.SLIP_CODE.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.SLIP_CODE.TabIndex = 125;
            // 
            // xButton1
            // 
            this.xButton1.Location = new System.Drawing.Point(336, 4);
            this.xButton1.Name = "xButton1";
            this.xButton1.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.xButton1.Size = new System.Drawing.Size(112, 28);
            this.xButton1.TabIndex = 126;
            this.xButton1.Text = "オ―ダコードExcel";
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xButton2);
            this.xPanel3.Controls.Add(this.chkF);
            this.xPanel3.Controls.Add(this.chkE);
            this.xPanel3.Controls.Add(this.chkToijangYn);
            this.xPanel3.Controls.Add(this.cbxC);
            this.xPanel3.Controls.Add(this.cbxA);
            this.xPanel3.Controls.Add(this.cbx9);
            this.xPanel3.Controls.Add(this.cbx8);
            this.xPanel3.Controls.Add(this.cbx7);
            this.xPanel3.Controls.Add(this.cbx6);
            this.xPanel3.Controls.Add(this.cbxB);
            this.xPanel3.Controls.Add(this.cbx5);
            this.xPanel3.Controls.Add(this.cbx4);
            this.xPanel3.Controls.Add(this.cbx3);
            this.xPanel3.Controls.Add(this.cbx2);
            this.xPanel3.Controls.Add(this.cbx1);
            this.xPanel3.Controls.Add(this.xDisplayBox1);
            this.xPanel3.Controls.Add(this.fblText);
            this.xPanel3.Controls.Add(this.dcxDrgJibgyeGubun);
            this.xPanel3.Controls.Add(this.xLabel42);
            this.xPanel3.Controls.Add(this.emBulyongDate);
            this.xPanel3.Controls.Add(this.xLabel48);
            this.xPanel3.Controls.Add(this.txtActJaeryoName);
            this.xPanel3.Controls.Add(this.dbxSmall1);
            this.xPanel3.Controls.Add(this.fbxSmall1);
            this.xPanel3.Controls.Add(this.xLabel41);
            this.xPanel3.Controls.Add(this.txtManageNo);
            this.xPanel3.Controls.Add(this.dcbColorText);
            this.xPanel3.Controls.Add(this.xLabel37);
            this.xPanel3.Controls.Add(this.xLabel36);
            this.xPanel3.Controls.Add(this.txtYongRyang);
            this.xPanel3.Controls.Add(this.cbxD);
            this.xPanel3.Controls.Add(this.xLabel35);
            this.xPanel3.Controls.Add(this.txtChanggo);
            this.xPanel3.Controls.Add(this.xLabel33);
            this.xPanel3.Controls.Add(this.txtDrgComment);
            this.xPanel3.Controls.Add(this.xLabel32);
            this.xPanel3.Controls.Add(this.dpxYuhyyo);
            this.xPanel3.Controls.Add(this.dcxBunryu8);
            this.xPanel3.Controls.Add(this.dcxBunryu7);
            this.xPanel3.Controls.Add(this.dcxBunryu6);
            this.xPanel3.Controls.Add(this.dcxBunryu5);
            this.xPanel3.Controls.Add(this.xLabel31);
            this.xPanel3.Controls.Add(this.xLabel25);
            this.xPanel3.Controls.Add(this.dbxLabelDanui2);
            this.xPanel3.Controls.Add(this.fbxLabelDanui2);
            this.xPanel3.Controls.Add(this.xLabel22);
            this.xPanel3.Controls.Add(this.xLabel21);
            this.xPanel3.Controls.Add(this.emDrgTrunc);
            this.xPanel3.Controls.Add(this.dbxLabelDanui);
            this.xPanel3.Controls.Add(this.fbxLabelDanui);
            this.xPanel3.Controls.Add(this.xLabel20);
            this.xPanel3.Controls.Add(this.dbxOrderDanui);
            this.xPanel3.Controls.Add(this.xLabel19);
            this.xPanel3.Controls.Add(this.fbxOrderDanui);
            this.xPanel3.Controls.Add(this.txtRemark);
            this.xPanel3.Controls.Add(this.xLabel18);
            this.xPanel3.Controls.Add(this.txtGijunDanga);
            this.xPanel3.Controls.Add(this.txtDanga);
            this.xPanel3.Controls.Add(this.dbxCompanyName);
            this.xPanel3.Controls.Add(this.fbxCompanyName);
            this.xPanel3.Controls.Add(this.dbxBaljuDanui);
            this.xPanel3.Controls.Add(this.dbxSubulDanui);
            this.xPanel3.Controls.Add(this.xLabel16);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Controls.Add(this.xLabel15);
            this.xPanel3.Controls.Add(this.xLabel12);
            this.xPanel3.Controls.Add(this.dbxBunryu4);
            this.xPanel3.Controls.Add(this.fbxBunryu4);
            this.xPanel3.Controls.Add(this.xLabel10);
            this.xPanel3.Controls.Add(this.dbxBunryu3);
            this.xPanel3.Controls.Add(this.fbxBunryu3);
            this.xPanel3.Controls.Add(this.xLabel9);
            this.xPanel3.Controls.Add(this.dbxBunryu2);
            this.xPanel3.Controls.Add(this.fbxBunryu2);
            this.xPanel3.Controls.Add(this.xLabel6);
            this.xPanel3.Controls.Add(this.dbxBunryu1);
            this.xPanel3.Controls.Add(this.fbxBunryu1);
            this.xPanel3.Controls.Add(this.xLabel4);
            this.xPanel3.Controls.Add(this.dbxCautionCode);
            this.xPanel3.Controls.Add(this.dbxDrgType);
            this.xPanel3.Controls.Add(this.dbxSmall);
            this.xPanel3.Controls.Add(this.label4);
            this.xPanel3.Controls.Add(this.fbxCautionCode);
            this.xPanel3.Controls.Add(this.fbxDrgType);
            this.xPanel3.Controls.Add(this.fbxSmall);
            this.xPanel3.Controls.Add(this.dcbBunryu9);
            this.xPanel3.Controls.Add(this.txtKyukyeok);
            this.xPanel3.Controls.Add(this.txtHamryang);
            this.xPanel3.Controls.Add(this.txtJaeryoEname);
            this.xPanel3.Controls.Add(this.txtJaeryoName);
            this.xPanel3.Controls.Add(this.txtSungBunName);
            this.xPanel3.Controls.Add(this.txtJaeryoCode);
            this.xPanel3.Controls.Add(this.txtSungBunCode);
            this.xPanel3.Controls.Add(this.xLabel3);
            this.xPanel3.Controls.Add(this.xLabel7);
            this.xPanel3.Controls.Add(this.xLabel5);
            this.xPanel3.Controls.Add(this.xLabel26);
            this.xPanel3.Controls.Add(this.xLabel30);
            this.xPanel3.Controls.Add(this.xLabel8);
            this.xPanel3.Controls.Add(this.xLabel54);
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Controls.Add(this.fbxSubulQcodeInp);
            this.xPanel3.Controls.Add(this.fbxSubulQcodeOut);
            this.xPanel3.Controls.Add(this.fbxCustomerCode);
            this.xPanel3.Controls.Add(this.xLabel23);
            this.xPanel3.Controls.Add(this.xLabel24);
            this.xPanel3.Controls.Add(this.xLabel13);
            this.xPanel3.Controls.Add(this.xLabel45);
            this.xPanel3.Controls.Add(this.xLabel44);
            this.xPanel3.Controls.Add(this.xLabel38);
            this.xPanel3.Controls.Add(this.xLabel46);
            this.xPanel3.Controls.Add(this.xLabel47);
            this.xPanel3.Controls.Add(this.xLabel34);
            this.xPanel3.Controls.Add(this.xLabel27);
            this.xPanel3.Controls.Add(this.xLabel28);
            this.xPanel3.Controls.Add(this.xLabel29);
            this.xPanel3.Controls.Add(this.xLabel64);
            this.xPanel3.Controls.Add(this.fbxSubulDanui);
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Controls.Add(this.dbxSubulQcodeInp);
            this.xPanel3.Controls.Add(this.dbxBulyongCode);
            this.xPanel3.Controls.Add(this.dbxSubulQcodeEr);
            this.xPanel3.Controls.Add(this.dbxSubulQcodeOut);
            this.xPanel3.Controls.Add(this.dbxCustomerName);
            this.xPanel3.Controls.Add(this.gbxSugbJaeryo);
            this.xPanel3.Controls.Add(this.fbxBaljuDanui);
            this.xPanel3.Controls.Add(this.fbxBaljuBuseo);
            this.xPanel3.Controls.Add(this.fbxSubulBuseo);
            this.xPanel3.Controls.Add(this.txtChangeQtyl);
            this.xPanel3.Controls.Add(this.dtpJukyongDate);
            this.xPanel3.Controls.Add(this.fbxBulyongCode);
            this.xPanel3.Controls.Add(this.fbxSubulQcodeEr);
            this.xPanel3.Controls.Add(this.xLabel39);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(444, 5);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(669, 772);
            this.xPanel3.TabIndex = 6;
            // 
            // xButton2
            // 
            this.xButton2.Location = new System.Drawing.Point(0, 0);
            this.xButton2.Name = "xButton2";
            this.xButton2.Size = new System.Drawing.Size(0, 0);
            this.xButton2.TabIndex = 0;
            // 
            // xDisplayBox1
            // 
            this.xDisplayBox1.BackColor = IHIS.Framework.XColor.MenuGradientStartColor;
            this.xDisplayBox1.Location = new System.Drawing.Point(14, 318);
            this.xDisplayBox1.Name = "xDisplayBox1";
            this.xDisplayBox1.Size = new System.Drawing.Size(646, 76);
            this.xDisplayBox1.TabIndex = 164;
            // 
            // fblText
            // 
            this.fblText.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.fblText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fblText.Location = new System.Drawing.Point(638, 292);
            this.fblText.Name = "fblText";
            this.fblText.Size = new System.Drawing.Size(28, 20);
            this.fblText.TabIndex = 162;
            this.fblText.Text = "まで";
            // 
            // xLabel42
            // 
            this.xLabel42.Location = new System.Drawing.Point(468, 268);
            this.xLabel42.Name = "xLabel42";
            this.xLabel42.Size = new System.Drawing.Size(68, 20);
            this.xLabel42.TabIndex = 160;
            this.xLabel42.Text = "薬剤集計";
            this.xLabel42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emBulyongDate
            // 
            this.emBulyongDate.Location = new System.Drawing.Point(108, 564);
            this.emBulyongDate.Name = "emBulyongDate";
            this.emBulyongDate.Size = new System.Drawing.Size(100, 20);
            this.emBulyongDate.TabIndex = 159;
            this.emBulyongDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel48
            // 
            this.xLabel48.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel48.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xLabel48.Location = new System.Drawing.Point(66, 100);
            this.xLabel48.Name = "xLabel48";
            this.xLabel48.Size = new System.Drawing.Size(130, 20);
            this.xLabel48.TabIndex = 158;
            this.xLabel48.Text = "(注射実施箋名)";
            this.xLabel48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtActJaeryoName
            // 
            this.txtActJaeryoName.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtActJaeryoName.Location = new System.Drawing.Point(200, 100);
            this.txtActJaeryoName.Name = "txtActJaeryoName";
            this.txtActJaeryoName.Size = new System.Drawing.Size(460, 20);
            this.txtActJaeryoName.TabIndex = 157;
            // 
            // dbxSmall1
            // 
            this.dbxSmall1.Location = new System.Drawing.Point(422, 172);
            this.dbxSmall1.Name = "dbxSmall1";
            this.dbxSmall1.Size = new System.Drawing.Size(238, 20);
            this.dbxSmall1.TabIndex = 155;
            // 
            // xLabel41
            // 
            this.xLabel41.Location = new System.Drawing.Point(420, 4);
            this.xLabel41.Name = "xLabel41";
            this.xLabel41.Size = new System.Drawing.Size(102, 20);
            this.xLabel41.TabIndex = 153;
            this.xLabel41.Text = "薬価基準コード";
            this.xLabel41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel37
            // 
            this.xLabel37.Location = new System.Drawing.Point(240, 292);
            this.xLabel37.Name = "xLabel37";
            this.xLabel37.Size = new System.Drawing.Size(112, 20);
            this.xLabel37.TabIndex = 149;
            this.xLabel37.Text = "Color設定";
            this.xLabel37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel36
            // 
            this.xLabel36.Location = new System.Drawing.Point(276, 124);
            this.xLabel36.Name = "xLabel36";
            this.xLabel36.Size = new System.Drawing.Size(60, 20);
            this.xLabel36.TabIndex = 148;
            this.xLabel36.Text = "用量";
            this.xLabel36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtYongRyang
            // 
            this.txtYongRyang.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.txtYongRyang.Location = new System.Drawing.Point(338, 124);
            this.txtYongRyang.Name = "txtYongRyang";
            this.txtYongRyang.Size = new System.Drawing.Size(82, 20);
            this.txtYongRyang.TabIndex = 147;
            // 
            // xLabel35
            // 
            this.xLabel35.Location = new System.Drawing.Point(422, 124);
            this.xLabel35.Name = "xLabel35";
            this.xLabel35.Size = new System.Drawing.Size(60, 20);
            this.xLabel35.TabIndex = 145;
            this.xLabel35.Text = "配置場所";
            this.xLabel35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel33
            // 
            this.xLabel33.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel33.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xLabel33.Location = new System.Drawing.Point(2, 691);
            this.xLabel33.Name = "xLabel33";
            this.xLabel33.Size = new System.Drawing.Size(120, 20);
            this.xLabel33.TabIndex = 143;
            this.xLabel33.Text = "● 薬剤共通コメント";
            // 
            // xLabel32
            // 
            this.xLabel32.Location = new System.Drawing.Point(468, 292);
            this.xLabel32.Name = "xLabel32";
            this.xLabel32.Size = new System.Drawing.Size(68, 20);
            this.xLabel32.TabIndex = 141;
            this.xLabel32.Text = "設定期間";
            this.xLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel31
            // 
            this.xLabel31.Location = new System.Drawing.Point(342, 504);
            this.xLabel31.Name = "xLabel31";
            this.xLabel31.Size = new System.Drawing.Size(62, 20);
            this.xLabel31.TabIndex = 123;
            this.xLabel31.Text = "発注部署";
            this.xLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel25
            // 
            this.xLabel25.Location = new System.Drawing.Point(758, 148);
            this.xLabel25.Name = "xLabel25";
            this.xLabel25.Size = new System.Drawing.Size(176, 20);
            this.xLabel25.TabIndex = 122;
            this.xLabel25.Text = "ラベル  =>";
            this.xLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel25.Visible = false;
            // 
            // dbxLabelDanui2
            // 
            this.dbxLabelDanui2.Location = new System.Drawing.Point(828, 176);
            this.dbxLabelDanui2.Name = "dbxLabelDanui2";
            this.dbxLabelDanui2.Size = new System.Drawing.Size(52, 20);
            this.dbxLabelDanui2.TabIndex = 121;
            this.dbxLabelDanui2.Visible = false;
            // 
            // fbxLabelDanui2
            // 
            this.fbxLabelDanui2.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxLabelDanui2.FindWorker = this.fwkCommon;
            this.fbxLabelDanui2.Location = new System.Drawing.Point(780, 176);
            this.fbxLabelDanui2.Name = "fbxLabelDanui2";
            this.fbxLabelDanui2.Size = new System.Drawing.Size(48, 20);
            this.fbxLabelDanui2.TabIndex = 120;
            this.fbxLabelDanui2.Visible = false;
            this.fbxLabelDanui2.Enter += new System.EventHandler(this.fbxLabelDanui2_Enter);
            this.fbxLabelDanui2.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxLabelDanui2_FindClick);
            // 
            // xLabel22
            // 
            this.xLabel22.Location = new System.Drawing.Point(762, 176);
            this.xLabel22.Name = "xLabel22";
            this.xLabel22.Size = new System.Drawing.Size(80, 19);
            this.xLabel22.TabIndex = 119;
            this.xLabel22.Text = "ラベル単位1";
            this.xLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel22.Visible = false;
            // 
            // xLabel21
            // 
            this.xLabel21.Location = new System.Drawing.Point(758, 128);
            this.xLabel21.Name = "xLabel21";
            this.xLabel21.Size = new System.Drawing.Size(120, 19);
            this.xLabel21.TabIndex = 118;
            this.xLabel21.Text = "オーダ箋数量切捨";
            this.xLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel21.Visible = false;
            // 
            // emDrgTrunc
            // 
            this.emDrgTrunc.Location = new System.Drawing.Point(816, 128);
            this.emDrgTrunc.Name = "emDrgTrunc";
            this.emDrgTrunc.Size = new System.Drawing.Size(36, 20);
            this.emDrgTrunc.TabIndex = 117;
            this.emDrgTrunc.Visible = false;
            // 
            // dbxLabelDanui
            // 
            this.dbxLabelDanui.Location = new System.Drawing.Point(824, 204);
            this.dbxLabelDanui.Name = "dbxLabelDanui";
            this.dbxLabelDanui.Size = new System.Drawing.Size(52, 20);
            this.dbxLabelDanui.TabIndex = 116;
            this.dbxLabelDanui.Visible = false;
            // 
            // fbxLabelDanui
            // 
            this.fbxLabelDanui.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxLabelDanui.FindWorker = this.fwkCommon;
            this.fbxLabelDanui.Location = new System.Drawing.Point(776, 204);
            this.fbxLabelDanui.Name = "fbxLabelDanui";
            this.fbxLabelDanui.Size = new System.Drawing.Size(48, 20);
            this.fbxLabelDanui.TabIndex = 115;
            this.fbxLabelDanui.Visible = false;
            this.fbxLabelDanui.Enter += new System.EventHandler(this.fbxLabelDanui_Enter);
            this.fbxLabelDanui.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxLabelDanui_FindClick);
            // 
            // xLabel20
            // 
            this.xLabel20.Location = new System.Drawing.Point(766, 204);
            this.xLabel20.Name = "xLabel20";
            this.xLabel20.Size = new System.Drawing.Size(72, 19);
            this.xLabel20.TabIndex = 114;
            this.xLabel20.Text = "ラベル単位2";
            this.xLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel20.Visible = false;
            // 
            // dbxOrderDanui
            // 
            this.dbxOrderDanui.Location = new System.Drawing.Point(852, 100);
            this.dbxOrderDanui.Name = "dbxOrderDanui";
            this.dbxOrderDanui.Size = new System.Drawing.Size(52, 20);
            this.dbxOrderDanui.TabIndex = 113;
            this.dbxOrderDanui.Visible = false;
            // 
            // xLabel19
            // 
            this.xLabel19.Location = new System.Drawing.Point(762, 100);
            this.xLabel19.Name = "xLabel19";
            this.xLabel19.Size = new System.Drawing.Size(104, 19);
            this.xLabel19.TabIndex = 111;
            this.xLabel19.Text = "ATC オーダ単位";
            this.xLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel19.Visible = false;
            // 
            // fbxOrderDanui
            // 
            this.fbxOrderDanui.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.fbxOrderDanui.EnableEdit = false;
            this.fbxOrderDanui.FindWorker = this.fwkCommon;
            this.fbxOrderDanui.Location = new System.Drawing.Point(804, 100);
            this.fbxOrderDanui.Name = "fbxOrderDanui";
            this.fbxOrderDanui.ReadOnly = true;
            this.fbxOrderDanui.Size = new System.Drawing.Size(48, 20);
            this.fbxOrderDanui.TabIndex = 112;
            this.fbxOrderDanui.TabStop = false;
            this.fbxOrderDanui.Visible = false;
            this.fbxOrderDanui.Enter += new System.EventHandler(this.fbxOrderDanui_Enter);
            this.fbxOrderDanui.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxOrderDanui_FindClick);
            // 
            // xLabel18
            // 
            this.xLabel18.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel18.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xLabel18.Location = new System.Drawing.Point(2, 623);
            this.xLabel18.Name = "xLabel18";
            this.xLabel18.Size = new System.Drawing.Size(120, 20);
            this.xLabel18.TabIndex = 108;
            this.xLabel18.Text = "● 備考";
            // 
            // txtGijunDanga
            // 
            this.txtGijunDanga.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.txtGijunDanga.DecimalDigits = 2;
            this.txtGijunDanga.EditMaskType = IHIS.Framework.MaskType.Decimal;
            this.txtGijunDanga.Location = new System.Drawing.Point(108, 456);
            this.txtGijunDanga.Name = "txtGijunDanga";
            this.txtGijunDanga.Size = new System.Drawing.Size(100, 20);
            this.txtGijunDanga.TabIndex = 18;
            this.txtGijunDanga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDanga
            // 
            this.txtDanga.BackColor = IHIS.Framework.XColor.XCalendarDateBackColor;
            this.txtDanga.DecimalDigits = 2;
            this.txtDanga.EditMaskType = IHIS.Framework.MaskType.Decimal;
            this.txtDanga.Location = new System.Drawing.Point(108, 432);
            this.txtDanga.Name = "txtDanga";
            this.txtDanga.Size = new System.Drawing.Size(100, 20);
            this.txtDanga.TabIndex = 15;
            this.txtDanga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dbxCompanyName
            // 
            this.dbxCompanyName.Location = new System.Drawing.Point(354, 432);
            this.dbxCompanyName.Name = "dbxCompanyName";
            this.dbxCompanyName.Size = new System.Drawing.Size(120, 20);
            this.dbxCompanyName.TabIndex = 107;
            // 
            // dbxBaljuDanui
            // 
            this.dbxBaljuDanui.Location = new System.Drawing.Point(282, 480);
            this.dbxBaljuDanui.Name = "dbxBaljuDanui";
            this.dbxBaljuDanui.Size = new System.Drawing.Size(58, 20);
            this.dbxBaljuDanui.TabIndex = 105;
            // 
            // dbxSubulDanui
            // 
            this.dbxSubulDanui.Location = new System.Drawing.Point(165, 480);
            this.dbxSubulDanui.Name = "dbxSubulDanui";
            this.dbxSubulDanui.Size = new System.Drawing.Size(58, 20);
            this.dbxSubulDanui.TabIndex = 104;
            // 
            // xLabel16
            // 
            this.xLabel16.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel16.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xLabel16.Location = new System.Drawing.Point(2, 540);
            this.xLabel16.Name = "xLabel16";
            this.xLabel16.Size = new System.Drawing.Size(120, 20);
            this.xLabel16.TabIndex = 102;
            this.xLabel16.Text = "● 使用情報";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.gbxMix);
            this.xPanel4.Controls.Add(this.xLabel11);
            this.xPanel4.Controls.Add(this.gbxLabel);
            this.xPanel4.Controls.Add(this.xLabel14);
            this.xPanel4.Controls.Add(this.xLabel60);
            this.xPanel4.Controls.Add(this.xLabel61);
            this.xPanel4.Controls.Add(this.xLabel62);
            this.xPanel4.Controls.Add(this.gbxInp);
            this.xPanel4.Controls.Add(this.gbxOut);
            this.xPanel4.Location = new System.Drawing.Point(766, 244);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(176, 216);
            this.xPanel4.TabIndex = 101;
            this.xPanel4.Visible = false;
            // 
            // xLabel15
            // 
            this.xLabel15.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel15.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xLabel15.Location = new System.Drawing.Point(2, 410);
            this.xLabel15.Name = "xLabel15";
            this.xLabel15.Size = new System.Drawing.Size(120, 20);
            this.xLabel15.TabIndex = 93;
            this.xLabel15.Text = "● 在庫情報";
            // 
            // xLabel12
            // 
            this.xLabel12.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel12.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xLabel12.Location = new System.Drawing.Point(2, 10);
            this.xLabel12.Name = "xLabel12";
            this.xLabel12.Size = new System.Drawing.Size(120, 20);
            this.xLabel12.TabIndex = 91;
            this.xLabel12.Text = "● 医薬品情報";
            // 
            // xLabel13
            // 
            this.xLabel13.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel13.Location = new System.Drawing.Point(480, 454);
            this.xLabel13.Name = "xLabel13";
            this.xLabel13.Size = new System.Drawing.Size(34, 19);
            this.xLabel13.TabIndex = 17;
            this.xLabel13.Text = "外来";
            this.xLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel39
            // 
            this.xLabel39.Location = new System.Drawing.Point(478, 428);
            this.xLabel39.Name = "xLabel39";
            this.xLabel39.Size = new System.Drawing.Size(182, 100);
            this.xLabel39.TabIndex = 151;
            this.xLabel39.Text = "適用数量";
            this.xLabel39.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(444, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 772);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // layExcel
            // 
            this.layExcel.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem254});
            this.layExcel.QuerySQL = resources.GetString("layExcel.QuerySQL");
            this.layExcel.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layExcel_QueryStarting);
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "薬品大分類名";
            // 
            // multiLayoutItem196
            // 
            this.multiLayoutItem196.DataName = "薬品コード";
            // 
            // multiLayoutItem197
            // 
            this.multiLayoutItem197.DataName = "薬価基準コード";
            // 
            // multiLayoutItem198
            // 
            this.multiLayoutItem198.DataName = "薬品名";
            // 
            // multiLayoutItem199
            // 
            this.multiLayoutItem199.DataName = "薬品名(カナ)";
            // 
            // multiLayoutItem200
            // 
            this.multiLayoutItem200.DataName = "注射実施箋薬品名";
            // 
            // multiLayoutItem201
            // 
            this.multiLayoutItem201.DataName = "成分コード";
            // 
            // multiLayoutItem202
            // 
            this.multiLayoutItem202.DataName = "成分名";
            // 
            // multiLayoutItem203
            // 
            this.multiLayoutItem203.DataName = "含量";
            // 
            // multiLayoutItem204
            // 
            this.multiLayoutItem204.DataName = "規格";
            // 
            // multiLayoutItem205
            // 
            this.multiLayoutItem205.DataName = "用量";
            // 
            // multiLayoutItem206
            // 
            this.multiLayoutItem206.DataName = "配置場所";
            // 
            // multiLayoutItem207
            // 
            this.multiLayoutItem207.DataName = "保管方法";
            // 
            // multiLayoutItem208
            // 
            this.multiLayoutItem208.DataName = "剤型";
            // 
            // multiLayoutItem209
            // 
            this.multiLayoutItem209.DataName = "効能別分類";
            // 
            // multiLayoutItem210
            // 
            this.multiLayoutItem210.DataName = "薬品中分類";
            // 
            // multiLayoutItem211
            // 
            this.multiLayoutItem211.DataName = "注射剤成分類";
            // 
            // multiLayoutItem212
            // 
            this.multiLayoutItem212.DataName = "経口/外用剤細分";
            // 
            // multiLayoutItem213
            // 
            this.multiLayoutItem213.DataName = "注意事項";
            // 
            // multiLayoutItem214
            // 
            this.multiLayoutItem214.DataName = "大分類";
            // 
            // multiLayoutItem215
            // 
            this.multiLayoutItem215.DataName = "通常外請求";
            // 
            // multiLayoutItem216
            // 
            this.multiLayoutItem216.DataName = "取り扱い区分";
            // 
            // multiLayoutItem217
            // 
            this.multiLayoutItem217.DataName = "薬剤採用区分";
            // 
            // multiLayoutItem218
            // 
            this.multiLayoutItem218.DataName = "薬剤集計区分";
            // 
            // multiLayoutItem219
            // 
            this.multiLayoutItem219.DataName = "設定期間";
            // 
            // multiLayoutItem220
            // 
            this.multiLayoutItem220.DataName = "Color設定";
            // 
            // multiLayoutItem221
            // 
            this.multiLayoutItem221.DataName = "粉砕可否";
            // 
            // multiLayoutItem222
            // 
            this.multiLayoutItem222.DataName = "簡易懸濁可否";
            // 
            // multiLayoutItem223
            // 
            this.multiLayoutItem223.DataName = "一包化可否";
            // 
            // multiLayoutItem224
            // 
            this.multiLayoutItem224.DataName = "混合可否";
            // 
            // multiLayoutItem225
            // 
            this.multiLayoutItem225.DataName = "MIX可否";
            // 
            // multiLayoutItem226
            // 
            this.multiLayoutItem226.DataName = "在庫僅少可否";
            // 
            // multiLayoutItem227
            // 
            this.multiLayoutItem227.DataName = "事前準備可否";
            // 
            // multiLayoutItem228
            // 
            this.multiLayoutItem228.DataName = "調剤薬局購入可否";
            // 
            // multiLayoutItem229
            // 
            this.multiLayoutItem229.DataName = "化学療法可否";
            // 
            // multiLayoutItem230
            // 
            this.multiLayoutItem230.DataName = "レジメ管可否";
            // 
            // multiLayoutItem231
            // 
            this.multiLayoutItem231.DataName = "抗がん剤可否";
            // 
            // multiLayoutItem232
            // 
            this.multiLayoutItem232.DataName = "受注発注可否";
            // 
            // multiLayoutItem233
            // 
            this.multiLayoutItem233.DataName = "後発不可";
            // 
            // multiLayoutItem234
            // 
            this.multiLayoutItem234.DataName = "抗凝固剤";
            // 
            // multiLayoutItem235
            // 
            this.multiLayoutItem235.DataName = "ハイリスク";
            // 
            // multiLayoutItem236
            // 
            this.multiLayoutItem236.DataName = "単価";
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "標準小売価";
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "製造会社";
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "取引業体";
            // 
            // multiLayoutItem240
            // 
            this.multiLayoutItem240.DataName = "受払単位";
            // 
            // multiLayoutItem241
            // 
            this.multiLayoutItem241.DataName = "発注単位";
            // 
            // multiLayoutItem242
            // 
            this.multiLayoutItem242.DataName = "換算数量";
            // 
            // multiLayoutItem243
            // 
            this.multiLayoutItem243.DataName = "受払部署";
            // 
            // multiLayoutItem244
            // 
            this.multiLayoutItem244.DataName = "発注部署";
            // 
            // multiLayoutItem245
            // 
            this.multiLayoutItem245.DataName = "需給計画可否";
            // 
            // multiLayoutItem246
            // 
            this.multiLayoutItem246.DataName = "適用数量(外来)";
            // 
            // multiLayoutItem247
            // 
            this.multiLayoutItem247.DataName = "適用数量(入院)";
            // 
            // multiLayoutItem248
            // 
            this.multiLayoutItem248.DataName = "適用数量(救急)";
            // 
            // multiLayoutItem249
            // 
            this.multiLayoutItem249.DataName = "不用日付";
            // 
            // multiLayoutItem250
            // 
            this.multiLayoutItem250.DataName = "不採用事由";
            // 
            // multiLayoutItem251
            // 
            this.multiLayoutItem251.DataName = "備考";
            // 
            // multiLayoutItem252
            // 
            this.multiLayoutItem252.DataName = "コメント処方箋表示";
            // 
            // multiLayoutItem253
            // 
            this.multiLayoutItem253.DataName = "薬剤共通コメント";
            // 
            // multiLayoutItem254
            // 
            this.multiLayoutItem254.DataName = "採用日付";
            // 
            // fdwOCS0102
            // 
            this.fdwOCS0102.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6});
            this.fdwOCS0102.FormText = "オ―ダ伝票コード";
            this.fdwOCS0102.SearchImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "slip_code";
            this.findColumnInfo5.HeaderText = "オ―ダ伝票";
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "slip_name";
            this.findColumnInfo6.ColWidth = 401;
            this.findColumnInfo6.HeaderText = "オ―ダ伝票名";
            // 
            // DRG0101U00
            // 
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Name = "DRG0101U00";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1118, 818);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInv0110)).EndInit();
            this.pnlKind.ResumeLayout(false);
            this.pnlKind.PerformLayout();
            this.gbxSugbJaeryo.ResumeLayout(false);
            this.gbxInp.ResumeLayout(false);
            this.gbxOut.ResumeLayout(false);
            this.gbxLabel.ResumeLayout(false);
            this.gbxMix.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layDetail)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layExcel)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cboBunryu.SelectedIndex = 0;
            cbxBulyong.SelectedIndex = 1;
            SLIP_CODE.SelectedIndex = 0;
            ComboBoxUserQuery();

            if (this.OpenParam != null)
            {
                this.fbxJaeryo.SetDataValue(this.OpenParam["jaeryo_code"].ToString());

                mReset();
                grdInv0110.QueryLayout(false);
            }
        }

        #region 각 콤보박스 사용자 쿼리 셋팅
        private void ComboBoxUserQuery()
        {
            this.dcxBunryu5.UserSQL = "SELECT CODE, CODE_NAME FROM INV0102 WHERE CODE_TYPE = \'A01\' AND CODE2 = \'A\' AND H" +
                "OSP_CODE = \'" + EnvironInfo.HospCode + "\'";
            this.dcxBunryu7.UserSQL = "SELECT CODE, CODE_NAME FROM INV0102 WHERE CODE_TYPE = \'A03\' AND CODE2 = \'A\' AND H" +
                "OSP_CODE = \'" + EnvironInfo.HospCode + "\'";
            this.dcxBunryu8.UserSQL = "SELECT CODE, CODE_NAME FROM INV0102 WHERE CODE_TYPE = \'A04\' AND CODE2 = \'A\' AND H" +
                "OSP_CODE = \'" + EnvironInfo.HospCode + "\'";
            this.dcxBunryu6.UserSQL = "SELECT CODE, CODE_NAME FROM INV0102 WHERE CODE_TYPE = \'A02\' AND CODE2 = \'A\' AND H" +
                "OSP_CODE = \'" + EnvironInfo.HospCode + "\'";
            this.dcbBunryu9.UserSQL = "SELECT CODE, CODE_NAME FROM INV0102 WHERE CODE_TYPE = \'UI\'  AND CODE2 = \'A\' AND HO" +
                "SP_CODE = \'" + EnvironInfo.HospCode + "\'";
            this.cboBunryu.UserSQL = "SELECT \'%\' , \'ALL\' FROM DUAL UNION SELECT CODE,CODE_NAME FROM INV0102 WHERE CODE_" +
                "TYPE = \'UA\'  AND CODE2 = \'A\' AND HOSP_CODE = \'" + EnvironInfo.HospCode + "\'";
            this.SLIP_CODE.UserSQL = "SELECT \'%\'\r\n     , \'全体\'\r\n  FROM DUAL\r\n UNION ALL\r\nSELECT SLIP_CODE\r\n     , SLIP_N" +
                "AME \r\n  FROM OCS0102 \r\n WHERE SLIP_CODE LIKE \'P%\' \r\n    OR SLIP_CODE LIKE \'J%\'\r\n" +
                "   AND HOSP_CODE = \'" + EnvironInfo.HospCode + "\' \r\n ORDER BY 1";
        }
        #endregion

        #region 벨리데이션 MakeValService
        //각각의 컨트롤(파인드박스)에 맞는 벨리데이션 서비스로 셋팅
        private bool MakeValService(XFindBox aCtl)
        {
            bool result = true;
            string cmdText = string.Empty;

            switch (aCtl.Name)
            {
                case "fbxJaeryo":
                    cmdText = "SELECT JAERYO_NAME FROM INV0110 WHERE JAERYO_CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxJaeryo.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxDrgType":
                    cmdText = "SELECT CODE_NAME FROM INV0102 WHERE CODE_TYPE = '06' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxDrgType.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxCautionCode":
                    cmdText = "SELECT CAUTION_NAME FROM DRG0130 WHERE CAUTION_CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxCautionCode.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;

                case "fbxCompanyName":
                    cmdText = "SELECT CUSTOMER_NAME FROM INV0111 WHERE END_DATE  IS NULL AND CUSTOMER_CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxCompanyName.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;

                case "fbxCustomerCode":
                    cmdText = "SELECT CUSTOMER_NAME FROM INV0111 WHERE  END_DATE  IS NULL AND CUSTOMER_CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxCustomerName.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxSubulQcodeOut":
                    cmdText = "SELECT CODE_NAME FROM BAS0102 WHERE CODE_TYPE = 'SUBUL_CONV_CODE' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxSubulQcodeOut.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxSubulQcodeInp":
                    cmdText = "SELECT CODE_NAME FROM BAS0102 WHERE CODE_TYPE = 'SUBUL_CONV_CODE' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxSubulQcodeInp.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxSubulQcodeEr":
                    cmdText = "SELECT CODE_NAME FROM BAS0102 WHERE CODE_TYPE = 'SUBUL_CONV_CODE' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxSubulQcodeEr.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxSubulBuseo":
                    cmdText = "SELECT BUSEO_NAME FROM BAS0260 WHERE BUSEO_CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    //this.vsvCommon.OutputLayoutItems.Add("fbxSubulBuseo", IHIS.Framework.DataType.String, false, this.fbxSubulBuseo, "", "");
                    break;
                case "fbxBaljuBuseo":
                    cmdText = "SELECT BUSEO_NAME FROM BAS0260 WHERE BUSEO_CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    //this.vsvCommon.OutputLayoutItems.Add("fbxBaljuBuseo", IHIS.Framework.DataType.String, false, this.fbxBaljuBuseo, "", "");
                    break;

                case "fbxSubulDanui":
                    cmdText = "SELECT CODE_NAME FROM OCS0132 WHERE CODE_TYPE = 'ORD_DANUI' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxSubulDanui.SetDataValue(Service.ExecuteScalar(cmdText));
                    result = true;
                    break;
                case "fbxBaljuDanui":
                    cmdText = "SELECT CODE_NAME FROM OCS0132 WHERE CODE_TYPE = 'ORD_DANUI' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxBaljuDanui.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;

                case "fbxBulyongCode":
                    cmdText = "SELECT CODE_NAME FROM INV0102 WHERE CODE_TYPE = '10' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxBulyongCode.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;

                case "fbxBunryu1":
                    cmdText = "SELECT CODE_NAME FROM INV0102 WHERE CODE_TYPE = 'UA' AND CODE2 = 'A' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxBunryu1.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxBunryu2":
                    cmdText = "SELECT CODE_NAME FROM INV0102 WHERE CODE_TYPE = 'UB' AND CODE2 = 'A' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxBunryu2.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxBunryu3":
                    cmdText = "SELECT CODE_NAME FROM INV0102 WHERE CODE_TYPE = 'UC' AND CODE2 = 'A' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxBunryu3.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxBunryu4":
                    cmdText = "SELECT CODE_NAME FROM INV0102 WHERE CODE_TYPE = 'UD' AND CODE2 = 'A' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxBunryu4.SetDataValue(Service.ExecuteScalar(cmdText));
                    break;
                case "fbxLabelDanui":
                    cmdText = "SELECT CODE_NAME FROM OCS0132 WHERE CODE_TYPE = 'ORD_DANUI' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxLabelDanui.SetDataValue(Service.ExecuteScalar(cmdText));
                    result = true;
                    break;
                case "fbxLabelDanui2":
                    cmdText = "SELECT CODE_NAME FROM OCS0132 WHERE CODE_TYPE = 'ORD_DANUI' AND CODE = '" + aCtl.GetDataValue() + "' AND HOSP_CODE = '" + EnvironInfo.HospCode + "'";
                    dbxLabelDanui.SetDataValue(Service.ExecuteScalar(cmdText));
                    result = true;
                    break;
                default:
                    break;
            }

            return result;

        }
        #endregion

        #region FindBox Enter Event
        private void fbxDrgType_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxDrgType);
        }

        private void fbxCautionCode_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxCautionCode);
        }

        private void fbxCompanyName_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxCompanyName);
        }

        private void fbxCustomerCode_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxCustomerCode);
        }

        private void fbxSubulBuseo_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxSubulBuseo);
        }

        private void fbxSubulDanui_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxSubulDanui);
        }

        private void fbxBaljuBuseo_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxBaljuBuseo);
        }

        private void fbxBaljuDanui_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxBaljuDanui);
        }

        private void fbxSubulQcodeOut_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxSubulQcodeOut);
        }

        private void fbxSubulQcodeInp_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxSubulQcodeInp);
        }

        private void fbxSubulQcodeEr_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxSubulQcodeEr);
        }

        private void fbxBulyongCode_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxBulyongCode);
        }

        private void fbxBunryu1_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxBunryu1);
        }

        private void fbxBunryu2_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxBunryu2);
        }

        private void fbxBunryu3_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxBunryu3);
        }
        private void fbxBunryu4_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxBunryu4);
        }

        private void fbxOrderDanui_Enter(object sender, System.EventArgs e)
        {
            //MakeValService(fbxOrderDanui);		
        }

        private void fbxLabelDanui_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxLabelDanui);
        }


        private void fbxLabelDanui2_Enter(object sender, System.EventArgs e)
        {
            MakeValService(fbxLabelDanui2);
        }

        #endregion

        #region 벨리데이팅
        private void fbxSmall_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxSmall.ResetData();
            else MakeValService(fbxSmall);
        }

        private void fbxDrgType_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxDrgType.ResetData();
            else MakeValService(fbxDrgType);
        }

        private void fbxCautionCode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxCautionCode.ResetData();
            else MakeValService(fbxCautionCode);
        }

        private void fbxCompanyName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxCompanyName.ResetData();
            else MakeValService(fbxCompanyName);
        }

        private void fbxCustomerCode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxCustomerName.ResetData();
            else MakeValService(fbxCustomerCode);
        }

        private void fbxSubulQcodeOut_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxSubulQcodeOut.ResetData();
            else MakeValService(fbxSubulQcodeOut);
        }

        private void fbxSubulQcodeInp_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxSubulQcodeInp.ResetData();
            else MakeValService(fbxSubulQcodeInp);
        }

        private void fbxSubulQcodeEr_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxSubulQcodeEr.ResetData();
            else MakeValService(fbxSubulQcodeEr);
        }

        private void fbxBulyongCode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "")
            {
                dbxBulyongCode.ResetData();
                fbxBulyongCode.ResetData();
            }
            else MakeValService(fbxBulyongCode);
        }

        private void fbxBunryu1_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxBunryu1.ResetData();
            else MakeValService(fbxBunryu1);
        }

        private void fbxBunryu2_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxBunryu2.ResetData();
            else MakeValService(fbxBunryu2);
        }

        private void fbxBunryu3_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxBunryu3.ResetData();
            else MakeValService(fbxBunryu3);
        }

        private void fbxBunryu4_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxBunryu4.ResetData();
            else MakeValService(fbxBunryu4);
        }

        private void fbxSmall_DataValidating_1(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxSmall.ResetData();
            else MakeValService(fbxSmall);
        }

        private void fbxSmall1_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxSmall1.ResetData();
            else MakeValService(fbxSmall1);
        }

        private void fbxSubulDanui_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxSubulDanui.ResetData();
            else MakeValService(fbxSubulDanui);
        }

        private void fbxBaljuDanui_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue.ToString() == "") dbxBaljuDanui.ResetData();
            else MakeValService(fbxBaljuDanui);
        }
        #endregion

        #region MakeFindWorker
        //각각의 컨트롤(파인드박스)에 적합한 파인드 워커로 셋팅
        private bool MakeFindWorker(string aCtrName)
        {
            bool result = false;
            switch (aCtrName)
            {
                case "fbxJaeryo":
                    this.fwkCommon.FormText = "薬品コード";
                    this.fwkCommon.InputSQL = @"SELECT JAERYO_CODE, JAERYO_NAME
                                                  FROM INV0110
                                                 WHERE (JAERYO_CODE LIKE  :f_jaeryo_code||'%'
                                                    OR JAERYO_NAME  LIKE  '%'||:f_jaeryo_name||'%')
                                                   AND JAERYO_GUBUN = 'A'       
                                                 ORDER BY 2";
                    this.fwkCommon.ColInfos[0].HeaderText = "薬品コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "薬品名";
                    result = true;
                    break;
                case "fbxDrgType":
                    this.fwkCommon.FormText = "剤型";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM INV0102
                                                 WHERE CODE_TYPE = '06'
                                                   AND (CODE      LIKE :f_code      ||'%'
                                                    OR  CODE_NAME LIKE :f_code_name ||'%')
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "剤型コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "剤型名";
                    result = true;
                    break;
                case "fbxCautionCode":
                    this.fwkCommon.FormText = "注意事項";
                    this.fwkCommon.InputSQL = @"SELECT CAUTION_CODE, CAUTION_NAME
                                                  FROM DRG0130
                                                 WHERE (CAUTION_CODE LIKE :f_caution_code||'%'
                                                    OR CAUTION_NAME  LIKE :f_caution_name||'%')
                                                 ORDER BY CAUTION_CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "コード名";
                    result = true;
                    break;
                case "fbxCompanyName":
                    this.fwkCommon.FormText = "製造会社";
                    this.fwkCommon.InputSQL = @"SELECT CUSTOMER_CODE, CUSTOMER_NAME
                                                  FROM INV0111
                                                 WHERE END_DATE   IS NULL
                                                 ORDER BY CUSTOMER_CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "製造会社";
                    this.fwkCommon.ColInfos[1].HeaderText = "製造会社名";
                    result = true;
                    break;
                case "fbxCustomerCode":
                    this.fwkCommon.FormText = "取引業体";
                    this.fwkCommon.InputSQL = @"SELECT CUSTOMER_CODE, CUSTOMER_NAME
                                                  FROM INV0111
                                                 WHERE END_DATE   IS NULL
                                                 ORDER BY CUSTOMER_CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "取引業体";
                    this.fwkCommon.ColInfos[1].HeaderText = "取引業体名";
                    result = true;
                    break;

                case "fbxSubulQcodeOut":
                    this.fwkCommon.FormText = "適用数量";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM BAS0102
                                                 WHERE CODE_TYPE = 'SUBUL_CONV_CODE'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;
                case "fbxSubulQcodeInp":
                    this.fwkCommon.FormText = "適用数量";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM BAS0102
                                                 WHERE CODE_TYPE = 'SUBUL_CONV_CODE'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;
                case "fbxSubulQcodeEr":
                    this.fwkCommon.FormText = "適用数量";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM BAS0102
                                                 WHERE CODE_TYPE = 'SUBUL_CONV_CODE'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;

                case "fbxSubulBuseo":
                    this.fwkCommon.FormText = "受払部署";
                    this.fwkCommon.InputSQL = @"SELECT BUSEO_CODE, BUSEO_NAME
                                                  FROM BAS0260
                                                 WHERE (BUSEO_CODE LIKE :f_buseo     ||'%'
                                                    OR BUSEO_NAME  LIKE :f_buseo_name||'%')
                                                 ORDER BY BUSEO_CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;
                case "fbxBaljuBuseo":
                    this.fwkCommon.FormText = "発注部署";
                    this.fwkCommon.InputSQL = @"SELECT BUSEO_CODE, BUSEO_NAME
                                                  FROM BAS0260
                                                 WHERE (BUSEO_CODE LIKE :f_buseo     ||'%'
                                                    OR BUSEO_NAME  LIKE :f_buseo_name||'%')
                                                 ORDER BY BUSEO_CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;
                case "fbxSubulDanui":
                    this.fwkCommon.FormText = "受払単位";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM OCS0132
                                                 WHERE CODE_TYPE = 'ORD_DANUI'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;
                case "fbxBaljuDanui":
                    this.fwkCommon.FormText = "発注単位";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM OCS0132
                                                 WHERE CODE_TYPE = 'ORD_DANUI'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;

                case "fbxBulyongCode":
                    this.fwkCommon.FormText = "不用コード";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM INV0102
                                                 WHERE CODE_TYPE = '10'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;

                case "fbxBunryu1":
                    this.fwkCommon.FormText = "薬品分類1";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM INV0102
                                                 WHERE CODE_TYPE = 'UA'
                                                   AND (CODE LIKE :f_code||'%'
                                                    OR  CODE_NAME  LIKE :f_code_name||'%')
                                                   AND CODE2     = 'A'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "類型";
                    this.fwkCommon.ColInfos[1].HeaderText = "類型名";
                    result = true;
                    break;

                case "fbxBunryu2":
                    this.fwkCommon.FormText = "薬品分類2";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM INV0102
                                                 WHERE CODE_TYPE = 'UB'
                                                   AND (CODE LIKE :f_code||'%'
                                                    OR  CODE_NAME  LIKE :f_code_name||'%')
                                                   AND CODE2     = 'A'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "類型";
                    this.fwkCommon.ColInfos[1].HeaderText = "類型名";
                    result = true;
                    break;

                case "fbxBunryu3":
                    this.fwkCommon.FormText = "薬品分類3";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM INV0102
                                                 WHERE CODE_TYPE = 'UC'
                                                   AND (CODE LIKE :f_code||'%'
                                                    OR  CODE_NAME  LIKE :f_code_name||'%')
                                                   AND CODE2     = 'A'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "類型";
                    this.fwkCommon.ColInfos[1].HeaderText = "類型名";
                    result = true;
                    break;

                case "fbxBunryu4":
                    this.fwkCommon.FormText = "薬品分類4";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM INV0102
                                                 WHERE CODE_TYPE = 'UD'
                                                   AND (CODE LIKE :f_code||'%'
                                                    OR  CODE_NAME  LIKE :f_code_name||'%')
                                                   AND CODE2     = 'A'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "類型";
                    this.fwkCommon.ColInfos[1].HeaderText = "類型名";
                    result = true;
                    break;

                case "fbxOrderDanui":
                    this.fwkCommon.FormText = "ATCオーダ単位";
                    this.fwkCommon.InputSQL = @"SELECT A.CODE, A.CODE_NAME 
                                                  FROM OCS0132 A, OCS0110 B , OCS0103 C
                                                 WHERE A.CODE_TYPE    = 'ORD_DANUI' 
                                                   AND C.JAERYO_CODE  = '" + txtJaeryoCode.GetDataValue() + @"'
                                                   AND A.CODE         = B.ORD_DANUI        
                                                   AND C.HANGMOG_CODE = B.HANGMOG_CODE
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;
                case "fbxLabelDanui":
                    this.fwkCommon.FormText = "ラベル単位";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM OCS0132
                                                 WHERE CODE_TYPE = 'ORD_DANUI'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;
                case "fbxLabelDanui2":
                    this.fwkCommon.FormText = "ラベル単位1";
                    this.fwkCommon.InputSQL = @"SELECT CODE, CODE_NAME
                                                  FROM OCS0132
                                                 WHERE CODE_TYPE = 'ORD_DANUI'
                                                 ORDER BY CODE";
                    this.fwkCommon.ColInfos[0].HeaderText = "コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "名称";
                    result = true;
                    break;
                default:
                    XMessageBox.Show("컨트롤을 찾을 수 없음", "에러");
                    result = false;
                    break;
            }
            return result;
        }
        #endregion

        #region 파인드 컨트롤 클릭이벤트들
        // 각각의 파인드 박스 컨트롤의 버튼이 클릭될때 그 컨트롤에 맞게 워커를 셋팅해 주어야 함
        private void fbxDrgType_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxDrgType.Name);
        }

        private void fbxCautionCode_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxCautionCode.Name);
        }

        private void fbxSmall_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Findsmall dlg = new Findsmall(dbxSmall, fbxSmall.GetDataValue().PadRight(3, ' '));
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fbxSmall.SetEditValue(dlg.GetCode);
                dbxSmall.SetEditValue(dlg.GetMiddleName);
                txtSungBunCode.SetEditValue(dlg.GetCode);
                txtSungBunName.SetEditValue(dlg.GetName);
            }
            dlg.Dispose();
        }


        private void fbxCompanyName_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxCompanyName.Name);
        }

        private void fbxCustomerCode_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxCustomerCode.Name);
        }

        private void fbxSubulBuseo_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxSubulBuseo.Name);
        }

        private void fbxBaljuBuseo_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxBaljuBuseo.Name);
        }

        private void fbxSubulDanui_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxSubulDanui.Name);
        }

        private void fbxBaljuDanui_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxBaljuDanui.Name);
        }

        private void fbxSubulQcodeOut_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxSubulQcodeOut.Name);
        }

        private void fbxSubulQcodeInp_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxSubulQcodeInp.Name);
        }

        private void fbxSubulQcodeEr_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxSubulQcodeEr.Name);
        }

        private void fbxBulyongCode_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxBulyongCode.Name);
        }

        private void fbxBunryu1_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxBunryu1.Name);
        }

        private void fbxBunryu2_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxBunryu2.Name);
        }

        private void fbxBunryu3_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxBunryu3.Name);
        }

        private void fbxBunryu4_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxBunryu4.Name);
        }
        private void fbxOrderDanui_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxOrderDanui.Name);
        }
        private void fbxLabelDanui_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxLabelDanui.Name);
        }

        private void fbxLabelDanui2_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(fbxLabelDanui2.Name);
        }


        #endregion

        private void setControl()
        {
            txtSungBunCode.SetEditValue(layDetail.GetItemString(0, "sungbun_code"));
            txtSungBunName.SetEditValue(layDetail.GetItemString(0, "sungbun_name"));
            txtJaeryoCode.SetEditValue(layDetail.GetItemString(0, "jaeryo_code"));
            txtJaeryoName.SetEditValue(layDetail.GetItemString(0, "jaeryo_name"));
            txtJaeryoEname.SetEditValue(layDetail.GetItemString(0, "jaeryo_e_name"));
            fbxSmall.SetDataValue(layDetail.GetItemString(0, "small_code"));
            dcbBunryu9.SetEditValue(layDetail.GetItemString(0, "bunryu9"));
            txtHamryang.SetEditValue(layDetail.GetItemString(0, "hamryang"));
            txtKyukyeok.SetEditValue(layDetail.GetItemString(0, "kyukyeok"));
            fbxDrgType.SetEditValue(layDetail.GetItemString(0, "drg_type"));
            fbxCautionCode.SetEditValue(layDetail.GetItemString(0, "caution_code"));
            txtDanga.SetDataValue(layDetail.GetItemString(0, "danga"));
            fbxCompanyName.SetEditValue(layDetail.GetItemString(0, "company_name"));
            fbxCustomerCode.SetEditValue(layDetail.GetItemString(0, "customer_code"));
            fbxSubulQcodeOut.SetEditValue(layDetail.GetItemString(0, "subul_qcode_out"));
            fbxSubulQcodeInp.SetEditValue(layDetail.GetItemString(0, "subul_qcode_inp"));
            fbxSubulQcodeEr.SetEditValue(layDetail.GetItemString(0, "subul_qcode_er"));
            fbxSubulBuseo.SetEditValue(layDetail.GetItemString(0, "subul_buseo"));
            fbxBaljuBuseo.SetEditValue(layDetail.GetItemString(0, "balju_buseo"));
            fbxSubulDanui.SetEditValue(layDetail.GetItemString(0, "subul_danui"));
            fbxBaljuDanui.SetEditValue(layDetail.GetItemString(0, "balju_danui"));
            emBulyongDate.SetEditValue(layDetail.GetItemString(0, "bulyong_date"));
            fbxBulyongCode.SetEditValue(layDetail.GetItemString(0, "bulyong_code"));
            dtpJukyongDate.SetEditValue(layDetail.GetItemString(0, "jukyong_date"));
            fbxBunryu1.SetEditValue(layDetail.GetItemString(0, "bunryu1"));
            fbxBunryu2.SetEditValue(layDetail.GetItemString(0, "bunryu2"));
            fbxBunryu3.SetEditValue(layDetail.GetItemString(0, "bunryu3"));
            fbxBunryu4.SetEditValue(layDetail.GetItemString(0, "bunryu4"));
            txtGijunDanga.SetEditValue(layDetail.GetItemString(0, "gijun_danga"));
            txtChangeQtyl.SetEditValue(layDetail.GetItemString(0, "change_qtyl"));
            txtRemark.SetEditValue(layDetail.GetItemString(0, "remark"));
            fbxOrderDanui.SetEditValue(layDetail.GetItemString(0, "order_danui"));
            fbxLabelDanui.SetEditValue(layDetail.GetItemString(0, "label_danui"));
            emDrgTrunc.SetEditValue(layDetail.GetItemValue(0, "drg_trunc"));
            fbxLabelDanui2.SetEditValue(layDetail.GetItemString(0, "label_danui2"));

            // display
            dbxSmall.SetEditValue(layDetail.GetItemString(0, "small_code_middle_name"));
            dbxDrgType.SetEditValue(layDetail.GetItemString(0, "drg_type_name"));
            dbxCautionCode.SetEditValue(layDetail.GetItemString(0, "caution_code_name"));
            dbxSubulQcodeOut.SetEditValue(layDetail.GetItemString(0, "subul_qcode_out_name"));
            dbxSubulQcodeInp.SetEditValue(layDetail.GetItemString(0, "subul_qcode_inp_name"));
            dbxSubulQcodeEr.SetEditValue(layDetail.GetItemString(0, "subul_qcode_er_name"));
            dbxCustomerName.SetEditValue(layDetail.GetItemString(0, "customer_code_name"));
            dbxCompanyName.SetEditValue(layDetail.GetItemString(0, "company_code_name"));

            dbxBulyongCode.SetEditValue(layDetail.GetItemString(0, "bulyong_code_name"));
            dbxBunryu1.SetEditValue(layDetail.GetItemString(0, "bunryu1_name"));
            dbxBunryu2.SetEditValue(layDetail.GetItemString(0, "bunryu2_name"));
            dbxBunryu3.SetEditValue(layDetail.GetItemString(0, "bunryu3_name"));
            dbxBunryu4.SetEditValue(layDetail.GetItemString(0, "bunryu4_name"));
            dbxSubulDanui.SetEditValue(layDetail.GetItemString(0, "subuldanui_name"));
            dbxBaljuDanui.SetEditValue(layDetail.GetItemString(0, "baljudanui_name"));
            dbxOrderDanui.SetEditValue(layDetail.GetItemString(0, "orderdanui_name"));
            dbxLabelDanui.SetEditValue(layDetail.GetItemString(0, "labeldanui_name"));
            dbxLabelDanui2.SetEditValue(layDetail.GetItemString(0, "labeldanui2_name"));

            SetRadioSet(gbxMix, layDetail.GetItemString(0, "mix_yn"));
            SetRadioSet(gbxLabel, layDetail.GetItemString(0, "label_yn"));
            SetRadioSet(gbxOut, layDetail.GetItemString(0, "atc_yn"));
            SetRadioSet(gbxInp, layDetail.GetItemString(0, "atc_yn_inp"));
            SetRadioSet(gbxSugbJaeryo, layDetail.GetItemString(0, "sugb_jaeryo_yn"));


            dcxBunryu5.SetEditValue(layDetail.GetItemString(0, "bunryu5"));
            dcxBunryu6.SetEditValue(layDetail.GetItemString(0, "bunryu6"));
            dcxBunryu7.SetEditValue(layDetail.GetItemString(0, "bunryu7"));
            dcxBunryu8.SetEditValue(layDetail.GetItemString(0, "bunryu8"));
            txtChanggo.SetEditValue(layDetail.GetItemString(0, "changgo1"));
            dpxYuhyyo.SetEditValue(layDetail.GetItemString(0, "yuhyo_to_date"));

            cbx1.SetEditValue(layDetail.GetItemString(0, "chk1"));
            cbx2.SetEditValue(layDetail.GetItemString(0, "chk2"));
            cbx3.SetEditValue(layDetail.GetItemString(0, "chk3"));
            cbx4.SetEditValue(layDetail.GetItemString(0, "chk4"));
            cbx5.SetEditValue(layDetail.GetItemString(0, "chk5"));
            cbx6.SetEditValue(layDetail.GetItemString(0, "chk6"));
            cbx7.SetEditValue(layDetail.GetItemString(0, "chk7"));
            cbx8.SetEditValue(layDetail.GetItemString(0, "chk8"));
            cbx9.SetEditValue(layDetail.GetItemString(0, "chk9"));
            cbxA.SetEditValue(layDetail.GetItemString(0, "chkA"));
            cbxB.SetEditValue(layDetail.GetItemString(0, "chkB"));
            cbxC.SetEditValue(layDetail.GetItemString(0, "chkC"));
            cbxD.SetEditValue(layDetail.GetItemString(0, "chkD"));
            chkToijangYn.SetEditValue(layDetail.GetItemString(0, "toijang_yn"));
            chkE.SetEditValue(layDetail.GetItemString(0, "chkE"));
            chkF.SetEditValue(layDetail.GetItemString(0, "chkF"));
            txtDrgComment.SetEditValue(layDetail.GetItemString(0, "DrgComment"));
            txtYongRyang.SetEditValue(layDetail.GetItemString(0, "YongRyang"));
            dcbColorText.SetEditValue(layDetail.GetItemString(0, "ColorText"));
            txtManageNo.SetEditValue(layDetail.GetItemString(0, "drug_price_code"));
            fbxSmall1.SetDataValue(layDetail.GetItemString(0, "small_code1"));
            dbxSmall1.SetEditValue(layDetail.GetItemString(0, "small_code_name1"));
            txtActJaeryoName.SetEditValue(layDetail.GetItemString(0, "act_jaeryo_name"));
            dcxDrgJibgyeGubun.SetDataValue(layDetail.GetItemString(0, "drg_jibgye_gubun"));

        }

        #region 조회후 컨트럴에 set한다
        private void layDetail_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            if (e.IsSuccess == true)
            {
                if (layDetail.RowCount > 0)
                {
                    setControl();
                }
            }
            else
            {
                this.SetMsg(Service.ErrMsg, MsgType.Error);
            }
        }
        #endregion

        #region Function
        private void SetRadioSet(IHIS.Framework.XGroupBox gb, string data)
        {
            foreach (Control con in gb.Controls)
            {
                if (con is XFlatRadioButton)
                {
                    if (data == ((XFlatRadioButton)con).Text)
                        ((XFlatRadioButton)con).Checked = true;
                    else
                        ((XFlatRadioButton)con).Checked = false;
                }
            }
        }

        private string GetRadioSet(IHIS.Framework.XGroupBox gb)
        {
            string rtnData = string.Empty;
            foreach (Control con in gb.Controls)
            {
                if ((con is XFlatRadioButton) && (((XFlatRadioButton)con).Checked))
                {
                    rtnData = ((XFlatRadioButton)con).Text;
                }
            }
            return rtnData;
        }
        #endregion

        #region Grid
        private void grdInv0110_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (e.CurrentRow >= 0)
            {
                layDetail.Reset();
                mReset();
                layDetail.QueryLayout(false);
            }
        }
        #endregion

        #region 저장 시작 시점
        private void layDetail_PreSaveLayout(object sender, IHIS.Framework.MultiRecordEventArgs e)
        {
        }
        #endregion

        private void mReset()
        {
            foreach (Control cont in xPanel3.Controls)
            {
                if (cont is IDataControl)
                {
                    if (((IDataControl)cont).ApplyLayoutContainerReset)
                        ((IDataControl)cont).ResetData();
                }
                else if (cont is IMultiSaveLayout)
                {
                    if (((IMultiSaveLayout)cont).ApplyLayoutContainerReset)
                        ((IMultiSaveLayout)cont).Reset();
                }
                else if (cont is IMultiQueryLayout)
                {
                    if (((IMultiQueryLayout)cont).ApplyLayoutContainerReset)
                        ((IMultiQueryLayout)cont).Reset();
                }
                else if (cont is IUserObject)
                {
                    if (((IUserObject)cont).ApplyLayoutContainerReset)
                        ((IUserObject)cont).Reset();
                }
            }

        }

        #region ButtonList
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Delete:
                    if (XMessageBox.Show("選択した項目を削除します。", "お知らせ", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1
                        , MessageBoxIcon.Information) == DialogResult.No)
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        return;
                    }
                    if (!this.grdInv0110.SaveLayout()) XMessageBox.Show(Service.ErrFullMsg);
                    break;
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdInv0110.QueryLayout(true);
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    if (txtJaeryoCode.GetDataValue().Equals(""))
                    {
                        XMessageBox.Show("薬品コードは必須入力項目です。");
                        txtJaeryoCode.Focus();
                        return;
                    }
                    if (dtpJukyongDate.GetDataValue().Equals(""))
                    {
                        dtpJukyongDate.SetDataValue(EnvironInfo.GetSysDate().ToShortDateString());
                    }
                    this.PreSave();
                    if (!this.layDetail.SaveLayout()) XMessageBox.Show(Service.ErrFullMsg);
                    break;
                case FunctionType.Process:
                    layExcel.Reset();
                    layExcel.QueryLayout(true);
                    break;
                default:
                    break;
            }
        }

        private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    if (!e.IsSuccess)
                        this.SetMsg(Service.ErrMsg, MsgType.Error);
                    break;
                case FunctionType.Delete:
                    this.grdInv0110.SaveLayout();
                    break;
                case FunctionType.Process:
                    if (!e.IsSuccess)
                        this.SetMsg(Service.ErrMsg, MsgType.Error);
                    break;
                case FunctionType.Print:
                    if (!e.IsSuccess)
                        this.SetMsg(Service.ErrMsg, MsgType.Error);
                    break;

                default:
                    break;
            }
        }
        #endregion

        private void grdInv0110_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            if (e.IsSuccess != true)
            {
                layDetail.Reset();
                setControl();
            }
            else
            {
                if (this.grdInv0110.RowCount == 0)
                {
                    this.mReset();
                }
            }
        }

        private void layExcel_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            if (e.IsSuccess == true)
            {
                ExportSub(true, false, false);
            }
        }

        private void grdOCS0103_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            if (e.IsSuccess == true)
            {
                grdOCS0103.Export(true);
            }

        }

        private string[] excelmap = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
										"AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ",
										"BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ",
										"CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ",
										"DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ",
										"EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ",
										"FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ",
										"GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ",
										"HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ",
										"IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ"
									};
        private string GetExcelIndexToLetter(int i)
        {
            return excelmap[i];
        }

        #region ShowErrMsg
        protected void ShowErrMsg(string msg)
        {
            if (msg == "") return;

            XMessageBox.Show(msg);

        }
        #endregion

        protected virtual void ExportSub(bool isSaveFile, bool runExcel, bool onlyDisplayedColumn)
        {

            ProgressForm progress = new ProgressForm(100);

            string msg = "";
            try
            {
                string fileName = "";
                ArrayList excelProcList = new ArrayList();
                //파일을 Save하면 파일명칭지정하는 Dialog Show
                if (isSaveFile)
                {
                    //Excel.ExcelApp를 사용하면 Interop.Excel등 다른 dll참조해야하고, 또한
                    //Excel을 띄우게 되므로 html형식으로 Excel파일을 만듦
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.Filter = "Excel files (*.xls)|*.xls";
                    dlg.FilterIndex = 1;
                    dlg.RestoreDirectory = true;
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;

                    fileName = dlg.FileName;
                }
                else
                {
                    //미지정이면 현재 Drive에 Temp Dir에 현재시간.xls 파일로 생성
                    string path = Application.StartupPath.Substring(0, 1) + ":\\Temp";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    fileName = path + "\\" + DateTime.Now.ToString("HHmmss") + ".xls";
                }

                progress.Show();

                //GabageCollector를 쓰면 Excel이 죽지 않는 경우가 발생
                //기존에 떠있는 Excel 검색하여 저장후 새로 생긴 Excel Kill
                foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                    excelProcList.Add(proc.Id);


                progress.SetProgressValue(10);

                Excel.ApplicationClass excelApp = new Excel.ApplicationClass();
                if (excelApp == null)
                {
                    msg = (NetInfo.Language == LangMode.Ko ? "Excel파일을 생성하지 못했습니다."
                        : "Excelファイルの生成できませんでした。");
                    ShowErrMsg(msg);
                    return;
                }

                excelApp.Visible = false;

                //2005.11.22 onlyDisplayedColumn 속성 반영 (true이면 컬럼List중에서 visible한 컬럼만 SET 
                //				int colCount = layExcel.LayoutTable.Columns.Count;
                int colCount = layExcel.LayoutTable.Columns.Count;
                ArrayList dispColList = new ArrayList();

                //				if (onlyDisplayedColumn)
                //				{
                //					foreach (XGridCell info in this.CellInfos)
                //						if (info.IsVisible)
                //							dispColList.Add(info.CellName);
                //					//컬럼의 갯수는 보여지는 컬럼의 갯수
                //					colCount = dispColList.Count;
                //				}
                //				else  //DataTable에 있는 모든 컬럼을 dispColList에 SET
                //				{
                //					foreach (DataColumn dtCol in layExcel.LayoutTable.Columns)
                //						dispColList.Add(dtCol.ColumnName);
                //				}
                if (colCount == 0) return;

                foreach (DataColumn dtCol in layExcel.LayoutTable.Columns)
                    dispColList.Add(dtCol.ColumnName);

                Excel.Workbook theWorkBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet theWorkSheet = (Excel.Worksheet)theWorkBook.Worksheets[1];
                int rowCount = layExcel.LayoutTable.Rows.Count;
                int colIndex = 0;
                int rowIndex = 0;
                Excel.Range theRange = theWorkSheet.Cells.get_Range(GetExcelIndexToLetter(0) + "1", GetExcelIndexToLetter(colCount - 1) + (rowCount + 1).ToString());

                //Header 포함 Row의 갯수 + 1
                object[,] dataArray = new object[rowCount + 1, colCount];

                progress.SetProgressValue(20);

                //Header 설정 (있으면 설정, 없으면 컬럼명으로 설정)
                //Date,DataTime형 컬럼 List Date형이면 Y, DateTime형이면 T
                Hashtable dateColunmList = new Hashtable();
                ArrayList colNameList = new ArrayList();  //컬럼명 SET
                XGridCell cellInfo = null;
                object data = DBNull.Value;
                string colName = "";

                //foreach (DataColumn dtCol in this.LayoutTable.Columns)
                foreach (string columnName in dispColList)
                {
                    cellInfo = null;
                    if (cellInfo == null)
                    {
                        dataArray[0, colIndex] = columnName;
                        if (layExcel.LayoutTable.Columns[columnName].DataType == typeof(DateTime))
                            dateColunmList.Add(columnName, "T");
                    }
                    else
                    {
                        if (cellInfo.HeaderText != "")
                            dataArray[0, colIndex] = cellInfo.HeaderText;
                        else
                            dataArray[0, colIndex] = columnName;

                        //Date형,DateTime형 컬럼 SET
                        if (cellInfo.CellType == XCellDataType.Date)
                            dateColunmList.Add(columnName, "Y");
                        else if (cellInfo.CellType == XCellDataType.DateTime)
                            dateColunmList.Add(columnName, "T");
                    }
                    colIndex++;
                    //컬럼명 List에 Add
                    colNameList.Add(columnName);
                }

                //Data 설정
                foreach (DataRow dtRow in layExcel.LayoutTable.Rows)
                {
                    rowIndex++;

                    for (int i = 0; i < colCount; i++)
                    {
                        colName = colNameList[i].ToString();
                        data = dtRow[i];
                        if (dateColunmList.Contains(colName))
                        {
                            if (dateColunmList[colName].ToString() == "Y") //Date형 YYYYMMDD형 -> YYYY/MM/DD형으로
                            {
                                try
                                {
                                    if (data == DBNull.Value)
                                        dataArray[rowIndex, i] = string.Empty;
                                    else
                                    {
                                        //Date형은 YYYY/MM/DD로 관리함
                                        if (TypeCheck.IsDateTime(data))
                                            dataArray[rowIndex, i] = data;
                                        else  //YYYYMMDD 형
                                            dataArray[rowIndex, i] = data.ToString().Substring(0, 4) + "/" + data.ToString().Substring(4, 2) + "/" + data.ToString().Substring(6, 2);
                                    }
                                }
                                catch
                                {
                                    dataArray[rowIndex, i] = string.Empty;
                                }
                            }
                            else //DateTime형 YYYY/MM/DD HH:MI:SS
                            {
                                try
                                {
                                    if (data == DBNull.Value)
                                        dataArray[rowIndex, i] = string.Empty;
                                    else
                                        dataArray[rowIndex, i] = ((DateTime)data).ToString("yyyy/MM/dd HH:mm:ss");
                                }
                                catch
                                {
                                    dataArray[rowIndex, i] = string.Empty;
                                }
                            }
                        }
                        else
                        {
                            dataArray[rowIndex, i] = data.ToString();
                        }

                    }
                }

                progress.SetProgressValue(50);

                //Range Data Set
                theRange.Value = dataArray;

                progress.SetProgressValue(80);

                //SaveAs File
                theWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                //저장후 Excel Process 종료
                excelApp.Quit();

                //excelApp에 의해 생성된 Process Kill
                Process[] excelProcess = Process.GetProcessesByName("EXCEL");
                for (int i = 0; i < excelProcess.Length; i++)
                {
                    if (!excelProcList.Contains(excelProcess[i].Id))
                        excelProcess[i].Kill();
                }

                progress.SetProgressValue(100);

                //Excel Run
                try
                {
                    if (runExcel)
                    {
                        //Dir명이 Space가 들어가 있는 경우에 대비하여 arguments를 전달시에 양쪽을 ""로 묶음
                        Process.Start("EXCEL.exe", "\"" + fileName + "\"");
                    }
                }
                catch { }
            }
            catch (Exception e)
            {
                msg = (NetInfo.Language == LangMode.Ko ? "Excel파일 생성실패. 에러[" + e.Message + "]"
                    : "Excelファイルの生成失敗。 エラ?[" + e.Message + "]");
                ShowErrMsg(msg);
            }
            finally
            {
                if (progress != null)
                    progress.Close();
            }
        }

        private void fbxSmall1_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Findsmall dlg = new Findsmall(dbxSmall1, fbxSmall1.GetDataValue().PadRight(3, ' '));
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fbxSmall1.SetEditValue(dlg.GetCode);
                dbxSmall1.SetEditValue(dlg.GetMiddleName);
            }
            dlg.Dispose();
        }

        private void xButton1_Click(object sender, System.EventArgs e)
        {
            grdOCS0103.SetBindVarValue("f_hangmog_name_inx", "");
            if (!grdOCS0103.QueryLayout(true)) XMessageBox.Show(Service.ErrFullMsg);
        }

        private void btnDRG0112U00_Click(object sender, System.EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("jaeryo_code", grdInv0110.GetItemString(grdInv0110.CurrentRowNumber, "jaeryo_code"));

            XScreen.OpenScreenWithParam(this, "DRGS", "DRG0112U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void btnOCS0103U00_Click(object sender, System.EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("hangmog_code", grdInv0110.GetItemString(grdInv0110.CurrentRowNumber, "jaeryo_code"));

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void btnBAS0310U00_Click(object sender, System.EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("hangmog_code", grdInv0110.GetItemString(grdInv0110.CurrentRowNumber, "jaeryo_code"));

            XScreen.OpenScreenWithParam(this, "BASS", "BAS0310U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        #region 조회 버튼
        private void btnQuery_Click(object sender, System.EventArgs e)
        {
            xButtonList1_ButtonClick(sender, new ButtonClickEventArgs(FunctionType.Query, true, true));
        }
        #endregion

        #region 조회조건 입력
        private void btnQueryIns_Click(object sender, System.EventArgs e)
        {
            this.fbxJaeryo.SetEditValue("");
            this.dbxJaeryo.SetEditValue("");
            this.cboBunryu.SetEditValue("%");
            this.cbxBulyong.SetEditValue("2");

            mReset();
            this.grdInv0110.Reset();
            this.grdInv0110.InsertRow(1, false);
        }
        #endregion

        #region 재료 find에서 enter키를 누를 때 해당 명칭이 find창으로 옮겨가도록 한다.
        private void fbxJaeryo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Tab || e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                string name = string.Empty;
                object retVal = null;
                string cmdText = @"SELECT A.JAERYO_NAME
                                     FROM INV0110 A
                                    WHERE A.JAERYO_GUBUN = 'A' AND A.JAERYO_CODE = '" + fbxJaeryo.GetDataValue() + "'";
                retVal = Service.ExecuteScalar(cmdText);

                if (!TypeCheck.IsNull(retVal))
                {
                    dbxJaeryo.SetDataValue(retVal.ToString());
                }
                else
                {
                    this.fbxJaeryo.PopupFindDlg();
                }
            }
        }
        #endregion

        #region 각 그리드/레이아웃/FWK/DCX 에 바인드변수 설정
        private void grdInv0110_QueryStarting(object sender, CancelEventArgs e)
        {
            grdInv0110.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdInv0110.SetBindVarValue("f_jaeryo_code", fbxJaeryo.GetDataValue());
            grdInv0110.SetBindVarValue("f_jaeryo_name", dbxJaeryo.GetDataValue());
            grdInv0110.SetBindVarValue("f_bunryu", cboBunryu.GetDataValue());
            grdInv0110.SetBindVarValue("f_bulyong_tp", cbxBulyong.GetDataValue());
            grdInv0110.SetBindVarValue("f_sungbun_code", txtSungBunCode.GetDataValue());
            grdInv0110.SetBindVarValue("f_sungbun_name", txtSungBunName.GetDataValue());
            grdInv0110.SetBindVarValue("f_jaeryo_e_name", txtJaeryoEname.GetDataValue());
            grdInv0110.SetBindVarValue("f_changgo1", txtChanggo.GetDataValue());
            grdInv0110.SetBindVarValue("f_drug_price_code", txtManageNo.GetDataValue());
            grdInv0110.SetBindVarValue("f_bunryu9", dcbBunryu9.GetDataValue());
            grdInv0110.SetBindVarValue("f_drg_type", fbxDrgType.GetDataValue());
            grdInv0110.SetBindVarValue("f_small_code", fbxSmall.GetDataValue());
            grdInv0110.SetBindVarValue("f_bunryu3", fbxBunryu3.GetDataValue());
            grdInv0110.SetBindVarValue("f_small_code1", fbxSmall1.GetDataValue());
            grdInv0110.SetBindVarValue("f_bunryu2", fbxBunryu2.GetDataValue());
            grdInv0110.SetBindVarValue("f_bunryu4", fbxBunryu4.GetDataValue());
            grdInv0110.SetBindVarValue("f_caution_code", fbxCautionCode.GetDataValue());
            grdInv0110.SetBindVarValue("f_bunryu5", dcxBunryu5.GetDataValue());
            grdInv0110.SetBindVarValue("f_bunryu7", dcxBunryu7.GetDataValue());
            grdInv0110.SetBindVarValue("f_bunryu8", dcxBunryu8.GetDataValue());
            grdInv0110.SetBindVarValue("f_bunryu6", dcxBunryu6.GetDataValue());
            grdInv0110.SetBindVarValue("f_yuhyo_to_dt", dpxYuhyyo.GetDataValue());
            grdInv0110.SetBindVarValue("f_company_name", fbxCompanyName.GetDataValue());
            grdInv0110.SetBindVarValue("f_chk1", cbx1.GetDataValue());
            grdInv0110.SetBindVarValue("f_chk2", cbx2.GetDataValue());
            grdInv0110.SetBindVarValue("f_chk3", cbx3.GetDataValue());
            grdInv0110.SetBindVarValue("f_chk4", cbx4.GetDataValue());
            grdInv0110.SetBindVarValue("f_chk5", cbx5.GetDataValue());
            grdInv0110.SetBindVarValue("f_chk6", cbx6.GetDataValue());
            grdInv0110.SetBindVarValue("f_chk7", cbx7.GetDataValue());
            grdInv0110.SetBindVarValue("f_chk8", cbx8.GetDataValue());
            grdInv0110.SetBindVarValue("f_chk9", cbx9.GetDataValue());
            grdInv0110.SetBindVarValue("f_chka", cbxA.GetDataValue());
            grdInv0110.SetBindVarValue("f_chkb", cbxB.GetDataValue());
            grdInv0110.SetBindVarValue("f_chkc", cbxC.GetDataValue());
            grdInv0110.SetBindVarValue("f_chkd", cbxD.GetDataValue());
            grdInv0110.SetBindVarValue("f_chke", chkE.GetDataValue());
            grdInv0110.SetBindVarValue("f_chkf", chkF.GetDataValue());
            grdInv0110.SetBindVarValue("f_toijang_yn", chkToijangYn.GetDataValue());
            grdInv0110.SetBindVarValue("f_text_color", dcbColorText.GetDataValue());
            grdInv0110.SetBindVarValue("f_customer_code", fbxCustomerCode.GetDataValue());
            grdInv0110.SetBindVarValue("f_subul_qcode_out", fbxSubulQcodeOut.GetDataValue());
            grdInv0110.SetBindVarValue("f_subul_qcode_inp", fbxSubulQcodeInp.GetDataValue());
            grdInv0110.SetBindVarValue("f_subul_qcode_er", fbxSubulQcodeEr.GetDataValue());
            grdInv0110.SetBindVarValue("f_bulyong_code", fbxBulyongCode.GetDataValue());
            grdInv0110.SetBindVarValue("f_remark", txtRemark.GetDataValue());
            grdInv0110.SetBindVarValue("f_drg_comment", txtDrgComment.GetDataValue());
            grdInv0110.SetBindVarValue("f_drg_jibgye_gubun", dcxDrgJibgyeGubun.GetDataValue());
            grdInv0110.SetBindVarValue("f_jukyong_date", dtpJukyongDate.GetDataValue());
        }

        private void layDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            layDetail.SetBindVarValue("f_jaeryo_code", grdInv0110.GetItemString(grdInv0110.CurrentRowNumber, "jaeryo_code"));
            layDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdOCS0103_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0103.SetBindVarValue("f_slip_code", SLIP_CODE.GetDataValue());
            grdOCS0103.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layExcel_QueryStarting(object sender, CancelEventArgs e)
        {
            layExcel.SetBindVarValue("f_jaeryo_code", cboBunryu.GetDataValue());
            layExcel.SetBindVarValue("f_bulyong_tp", cbxBulyong.GetDataValue());
            layExcel.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fwkJaeryo_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkJaeryo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void dcxBunryu5_DDLBSetting(object sender, EventArgs e)
        {
            dcxBunryu5.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void dcxBunryu7_DDLBSetting(object sender, EventArgs e)
        {
            dcxBunryu7.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void dcxBunryu8_DDLBSetting(object sender, EventArgs e)
        {
            dcxBunryu8.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void dcxBunryu6_DDLBSetting(object sender, EventArgs e)
        {
            dcxBunryu6.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        private void fbxJaeryo_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string cmdText = "SELECT JAERYO_NAME " +
                               "FROM INV0110 " +
                              "WHERE JAERYO_GUBUN IN ( 'A' , 'C') " +
                                "AND JAERYO_CODE = '" + e.DataValue + "' " +
                                "AND HOSP_CODE   = '" + EnvironInfo.HospCode + "'";
            dbxJaeryo.SetDataValue(Service.ExecuteScalar(cmdText));

            if (dbxJaeryo.GetDataValue() != null)
            {
                this.grdInv0110.QueryLayout(false);
            }
            else
            {
                this.Reset();
            }
        }

        #region [ Custom Method ]
        #region PreSave()
        /// <summary>
        /// layDetail's PreSaveLayout Event
        /// </summary>
        private void PreSave()
        {
            int row;

            if (layDetail.RowCount > 0)
            {
                row = 0;
            }
            else
            {
                layDetail.Reset();
                row = layDetail.InsertRow(-1);
            }

            layDetail.SetItemValue(row, "lead_time", "");
            layDetail.SetItemValue(row, "avg_qty_d", "");
            layDetail.SetItemValue(row, "avg_qty_w", "");
            layDetail.SetItemValue(row, "avg_qty_m", "");
            layDetail.SetItemValue(row, "max_qty_d", "");
            layDetail.SetItemValue(row, "max_qty_w", "");
            layDetail.SetItemValue(row, "max_qty_m", "");
            layDetail.SetItemValue(row, "hamryang", txtHamryang.GetDataValue());
            layDetail.SetItemValue(row, "jeje_gijun_qty", "");
            layDetail.SetItemValue(row, "mix_yn", GetRadioSet(gbxMix));
            layDetail.SetItemValue(row, "mix_yn_inp", GetRadioSet(gbxInp));
            layDetail.SetItemValue(row, "atc_yn", GetRadioSet(gbxOut));
            layDetail.SetItemValue(row, "atc_yn_inp", GetRadioSet(gbxInp));
            layDetail.SetItemValue(row, "atc_code", "");
            layDetail.SetItemValue(row, "bogyong_code", "");
            layDetail.SetItemValue(row, "hyoneung_code", "");
            layDetail.SetItemValue(row, "caution_code", this.fbxCautionCode.GetDataValue());
            layDetail.SetItemValue(row, "main_use_gwa1", "");
            layDetail.SetItemValue(row, "main_use_gwa2", "");
            layDetail.SetItemValue(row, "main_use_gwa3", "");
            layDetail.SetItemValue(row, "main_use_gwa4", "");
            layDetail.SetItemValue(row, "main_use_gwa5", "");
            layDetail.SetItemValue(row, "bulyong_to_date", emBulyongDate.GetDataValue());
            layDetail.SetItemValue(row, "sugb_jaeryo_yn", GetRadioSet(gbxSugbJaeryo));
            layDetail.SetItemValue(row, "gijun_amt", "");
            layDetail.SetItemValue(row, "gijun_assure_amt", "");
            layDetail.SetItemValue(row, "bungi_acct", "");
            layDetail.SetItemValue(row, "old_manage_no", "");
            layDetail.SetItemValue(row, "manage_no1", "");
            layDetail.SetItemValue(row, "manage_no2", "");
            layDetail.SetItemValue(row, "manage_no3", "");
            layDetail.SetItemValue(row, "manage_no4", "");
            layDetail.SetItemValue(row, "changgo1", txtChanggo.GetDataValue());
            layDetail.SetItemValue(row, "changgo2", "");
            layDetail.SetItemValue(row, "changgo3", "");
            layDetail.SetItemValue(row, "danga", this.txtDanga.GetDataValue());
            layDetail.SetItemValue(row, "jukjung_qty", "");
            layDetail.SetItemValue(row, "order_danui", this.fbxOrderDanui.GetDataValue());
            layDetail.SetItemValue(row, "gijun_danga", txtGijunDanga.GetDataValue());
            layDetail.SetItemValue(row, "gijun_kyukyeok", "");
            layDetail.SetItemValue(row, "bunryu9", dcbBunryu9.GetDataValue());
            layDetail.SetItemValue(row, "customer_code2", "");
            layDetail.SetItemValue(row, "sungbun_code", txtSungBunCode.GetDataValue());
            layDetail.SetItemValue(row, "bogyong_code1", "");
            layDetail.SetItemValue(row, "bogyong_code2", "");
            layDetail.SetItemValue(row, "bogyong_code3", "");
            layDetail.SetItemValue(row, "bogyong_code4", "");
            layDetail.SetItemValue(row, "drg_max_dv", "");
            layDetail.SetItemValue(row, "drg_max_suryang", "");
            layDetail.SetItemValue(row, "balju_bulyong_date", "");
            layDetail.SetItemValue(row, "use_yn", "");
            layDetail.SetItemValue(row, "remark", txtRemark.GetDataValue());
            layDetail.SetItemValue(row, "sort_key", "");
            layDetail.SetItemValue(row, "weight", "");
            layDetail.SetItemValue(row, "ipchal_type", "");
            layDetail.SetItemValue(row, "laundry_danga", "");
            layDetail.SetItemValue(row, "rack_no", "");
            layDetail.SetItemValue(row, "path_bmp", "");
            layDetail.SetItemValue(row, "start_date", "");
            layDetail.SetItemValue(row, "end_date", "");
            layDetail.SetItemValue(row, "label_yn", GetRadioSet(gbxLabel));
            layDetail.SetItemValue(row, "sys_date", "");
            layDetail.SetItemValue(row, "user_id", UserInfo.UserID);
            layDetail.SetItemValue(row, "upd_date", IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/mm/dd"));
            layDetail.SetItemValue(row, "jaeryo_code", this.txtJaeryoCode.GetDataValue());
            layDetail.SetItemValue(row, "manage_no", txtManageNo.GetDataValue());
            layDetail.SetItemValue(row, "small_code", fbxSmall.GetDataValue());
            layDetail.SetItemValue(row, "jaeryo_name", this.txtJaeryoName.GetDataValue());
            layDetail.SetItemValue(row, "jaeryo_e_name", this.txtJaeryoEname.GetDataValue());
            layDetail.SetItemValue(row, "jaeryo_name_inx", "");
            layDetail.SetItemValue(row, "bunryu_bunho1", "");
            layDetail.SetItemValue(row, "bunryu_bunho2", "");
            layDetail.SetItemValue(row, "kyukyeok", txtKyukyeok.GetDataValue());
            layDetail.SetItemValue(row, "pris_name", "");
            layDetail.SetItemValue(row, "manage_name", "");
            layDetail.SetItemValue(row, "sungbun_name", txtSungBunName.GetDataValue());
            layDetail.SetItemValue(row, "jaeryo_gubun", "");
            layDetail.SetItemValue(row, "jaeryo_grade", "");
            layDetail.SetItemValue(row, "acct_id", "");
            layDetail.SetItemValue(row, "bunryu1", fbxBunryu1.GetDataValue());
            layDetail.SetItemValue(row, "bunryu2", fbxBunryu2.GetDataValue());
            layDetail.SetItemValue(row, "bunryu3", fbxBunryu3.GetDataValue());
            layDetail.SetItemValue(row, "bunryu4", fbxBunryu4.GetDataValue());
            layDetail.SetItemValue(row, "bunryu5", dcxBunryu5.GetDataValue());
            layDetail.SetItemValue(row, "bunryu6", dcxBunryu6.GetDataValue());
            layDetail.SetItemValue(row, "bunryu7", dcxBunryu7.GetDataValue());
            layDetail.SetItemValue(row, "bunryu8", dcxBunryu8.GetDataValue());
            layDetail.SetItemValue(row, "jukyong_date", dtpJukyongDate.GetDataValue());
            layDetail.SetItemValue(row, "drg_type", this.fbxDrgType.GetDataValue());
            layDetail.SetItemValue(row, "storage_yn", "");
            layDetail.SetItemValue(row, "ice_yn", "");
            layDetail.SetItemValue(row, "bannab_yn", "");
            layDetail.SetItemValue(row, "company_code", "");
            layDetail.SetItemValue(row, "customer_code", this.fbxCustomerCode.GetDataValue());
            layDetail.SetItemValue(row, "yuhyo_yn", "");
            layDetail.SetItemValue(row, "yuhyo_month", "");
            layDetail.SetItemValue(row, "yuhyo_to_date", dpxYuhyyo.GetDataValue());
            layDetail.SetItemValue(row, "suib_yn", "");
            layDetail.SetItemValue(row, "suib_customer", "");
            layDetail.SetItemValue(row, "yunhap_join_yn", "");
            layDetail.SetItemValue(row, "yunhap_code", "");
            layDetail.SetItemValue(row, "bulyong_code", this.fbxBulyongCode.GetDataValue());
            layDetail.SetItemValue(row, "bulyong_date", "");
            layDetail.SetItemValue(row, "subul_qcode_out", fbxSubulQcodeOut.GetDataValue());
            layDetail.SetItemValue(row, "subul_qcode_inp", fbxSubulQcodeInp.GetDataValue());
            layDetail.SetItemValue(row, "subul_qcode_er", fbxSubulQcodeEr.GetDataValue());
            layDetail.SetItemValue(row, "danga_yn", "");
            layDetail.SetItemValue(row, "from_danga_date", "");
            layDetail.SetItemValue(row, "to_danga_date", "");
            layDetail.SetItemValue(row, "subul_danui", fbxSubulDanui.GetDataValue());
            layDetail.SetItemValue(row, "balju_danui", fbxBaljuDanui.GetDataValue());
            layDetail.SetItemValue(row, "order_subul_danui", "");
            layDetail.SetItemValue(row, "subul_buseo", fbxSubulBuseo.GetDataValue());
            layDetail.SetItemValue(row, "balju_buseo", fbxBaljuBuseo.GetDataValue());
            layDetail.SetItemValue(row, "change_qtyl", txtChangeQtyl.GetDataValue());
            layDetail.SetItemValue(row, "change_qtyo", "");
            layDetail.SetItemValue(row, "jaego_qty", "");
            layDetail.SetItemValue(row, "jaego_amt", "");
            layDetail.SetItemValue(row, "last_ibgo_danga", "");
            layDetail.SetItemValue(row, "last_ibgo_date", "");
            layDetail.SetItemValue(row, "last_chulgo_date", "");
            layDetail.SetItemValue(row, "bunryu_bunho3", "");
            layDetail.SetItemValue(row, "bunryu_bunho4", "");
            layDetail.SetItemValue(row, "rack_no2", "");
            layDetail.SetItemValue(row, "hamryang_danui", "");
            layDetail.SetItemValue(row, "limit_dv", "");
            layDetail.SetItemValue(row, "toijang_yn", chkToijangYn.GetDataValue());
            layDetail.SetItemValue(row, "bunryu_bunho5", "");
            layDetail.SetItemValue(row, "delivery_gubun", "");
            layDetail.SetItemValue(row, "tb_yn", "");
            layDetail.SetItemValue(row, "skin_test_yn", "");
            layDetail.SetItemValue(row, "ir_jundal_yn", "");
            layDetail.SetItemValue(row, "jusa", "");
            layDetail.SetItemValue(row, "change_qtyp", "");
            layDetail.SetItemValue(row, "main_sungbun_code", "");
            layDetail.SetItemValue(row, "jibgye_yn", "");
            layDetail.SetItemValue(row, "bugase_yul", "");
            layDetail.SetItemValue(row, "company_name", fbxCompanyName.GetDataValue());
            layDetail.SetItemValue(row, "model_name", "");
            layDetail.SetItemValue(row, "first_ibgo_date", "");
            layDetail.SetItemValue(row, "ip_addr", "");
            layDetail.SetItemValue(row, "re_use_yn", "");
            layDetail.SetItemValue(row, "min_chunggu_qty", "");
            layDetail.SetItemValue(row, "customer_code3", "");
            layDetail.SetItemValue(row, "sutak_yn", "");
            layDetail.SetItemValue(row, "curency", "");
            layDetail.SetItemValue(row, "set_code", "");
            layDetail.SetItemValue(row, "customer_danga", "");
            layDetail.SetItemValue(row, "min_balju_qty", "");
            layDetail.SetItemValue(row, "label_danui", this.fbxLabelDanui.GetDataValue());
            layDetail.SetItemValue(row, "drg_trunc", this.emDrgTrunc.GetDataValue());
            layDetail.SetItemValue(row, "label_danui2", this.fbxLabelDanui2.GetDataValue());

            layDetail.SetItemValue(row, "chk1", this.cbx1.GetDataValue());
            layDetail.SetItemValue(row, "chk2", this.cbx2.GetDataValue());
            layDetail.SetItemValue(row, "chk3", this.cbx3.GetDataValue());
            layDetail.SetItemValue(row, "chk4", this.cbx4.GetDataValue());
            layDetail.SetItemValue(row, "chk5", this.cbx5.GetDataValue());
            layDetail.SetItemValue(row, "chk6", this.cbx6.GetDataValue());
            layDetail.SetItemValue(row, "chk7", this.cbx7.GetDataValue());
            layDetail.SetItemValue(row, "chk8", this.cbx8.GetDataValue());
            layDetail.SetItemValue(row, "chk9", this.cbx9.GetDataValue());
            layDetail.SetItemValue(row, "chkA", this.cbxA.GetDataValue());
            layDetail.SetItemValue(row, "chkB", this.cbxB.GetDataValue());
            layDetail.SetItemValue(row, "chkC", this.cbxC.GetDataValue());
            layDetail.SetItemValue(row, "chkD", this.cbxD.GetDataValue());
            layDetail.SetItemValue(row, "chkE", this.chkE.GetDataValue());
            layDetail.SetItemValue(row, "chkF", this.chkF.GetDataValue());
            layDetail.SetItemValue(row, "DrgComment", this.txtDrgComment.GetDataValue());
            layDetail.SetItemValue(row, "YongRyang", this.txtYongRyang.GetDataValue());
            layDetail.SetItemValue(row, "ColorText", this.dcbColorText.GetDataValue());
            layDetail.SetItemValue(row, "small_code1", fbxSmall1.GetDataValue());
            layDetail.SetItemValue(row, "act_jaeryo_name", this.txtActJaeryoName.GetDataValue());
            layDetail.SetItemValue(row, "drg_jibgye_gubun", this.dcxDrgJibgyeGubun.GetDataValue());
            layDetail.AcceptData();
        }
        #endregion
        #endregion

        #region [ XSavePerformer ]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private DRG0101U00 parent = null;
            public XSavePerformer(DRG0101U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 q_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case 'S':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO INV0110( LEAD_TIME                     
                                                               , AVG_QTY_D                     
                                                               , AVG_QTY_W                     
                                                               , AVG_QTY_M                     
                                                               , MAX_QTY_D                     
                                                               , MAX_QTY_W                     
                                                               , MAX_QTY_M                     
                                                               , HAMRYANG                      
                                                               , JEJE_GIJUN_QTY                
                                                               , MIX_YN                        
                                                               , MIX_YN_INP                    
                                                               , ATC_YN                        
                                                               , ATC_YN_INP                    
                                                               , ATC_CODE                      
                                                               , BOGYONG_CODE                  
                                                               , HYONEUNG_CODE                 
                                                               , CAUTION_CODE                  
                                                               , MAIN_USE_GWA1                 
                                                               , MAIN_USE_GWA2                 
                                                               , MAIN_USE_GWA3                 
                                                               , MAIN_USE_GWA4                 
                                                               , MAIN_USE_GWA5                 
                                                               , BULYONG_TO_DATE               
                                                               , SUGB_JAERYO_YN                
                                                               , GIJUN_AMT                     
                                                               , GIJUN_ASSURE_AMT              
                                                               , BUNGI_ACCT                    
                                                               , OLD_MANAGE_NO                 
                                                               , MANAGE_NO1                    
                                                               , MANAGE_NO2                    
                                                               , MANAGE_NO3                    
                                                               , MANAGE_NO4                    
                                                               , CHANGGO1                      
                                                               , CHANGGO2                      
                                                               , CHANGGO3                      
                                                               , DANGA                         
                                                               , JUKJUNG_QTY                   
                                                               , ORDER_DANUI                   
                                                               , GIJUN_DANGA                   
                                                               , GIJUN_KYUKYEOK                
                                                               , BUNRYU9                       
                                                               , CUSTOMER_CODE2                
                                                               , SUNGBUN_CODE                  
                                                               , BOGYONG_CODE1                 
                                                               , BOGYONG_CODE2                 
                                                               , BOGYONG_CODE3                 
                                                               , BOGYONG_CODE4                 
                                                               , DRG_MAX_DV                    
                                                               , DRG_MAX_SURYANG               
                                                               , BALJU_BULYONG_DATE            
                                                               , USE_YN                        
                                                               , REMARK                        
                                                               , SORT_KEY                      
                                                               , WEIGHT                        
                                                               , IPCHAL_TYPE                   
                                                               , LAUNDRY_DANGA                 
                                                               , RACK_NO                       
                                                               , PATH_BMP                      
                                                               , START_DATE                    
                                                               , END_DATE                      
                                                               , LABEL_YN                      
                                                               , SYS_DATE                      
                                                               , SYS_ID                       
                                                               , UPD_DATE                      
                                                               , JAERYO_CODE                   
                                                               , MANAGE_NO                     
                                                               , SMALL_CODE                    
                                                               , JAERYO_NAME                   
                                                               , JAERYO_E_NAME                 
                                                               , JAERYO_NAME_INX               
                                                               , BUNRYU_BUNHO1                 
                                                               , BUNRYU_BUNHO2                 
                                                               , KYUKYEOK                      
                                                               , PRIS_NAME                     
                                                               , MANAGE_NAME                   
                                                               , SUNGBUN_NAME                  
                                                               , JAERYO_GUBUN                  
                                                               , JAERYO_GRADE                  
                                                               , ACCT_ID                       
                                                               , BUNRYU1                       
                                                               , BUNRYU2                       
                                                               , BUNRYU3                       
                                                               , BUNRYU4                       
                                                               , BUNRYU5                       
                                                               , BUNRYU6                       
                                                               , BUNRYU7                       
                                                               , BUNRYU8                       
                                                               , JUKYONG_DATE                  
                                                               , DRG_TYPE                      
                                                               , STORAGE_YN                    
                                                               , ICE_YN                        
                                                               , BANNAB_YN                     
                                                               , COMPANY_CODE                  
                                                               , CUSTOMER_CODE                 
                                                               , YUHYO_YN                      
                                                               , YUHYO_MONTH                   
                                                               , YUHYO_TO_DATE                 
                                                               , SUIB_YN                       
                                                               , SUIB_CUSTOMER                 
                                                               , YUNHAP_JOIN_YN                
                                                               , YUNHAP_CODE                   
                                                               , BULYONG_CODE                  
                                                               , BULYONG_DATE                  
                                                               , SUBUL_QCODE_OUT               
                                                               , SUBUL_QCODE_INP               
                                                               , SUBUL_QCODE_ER                
                                                               , DANGA_YN                      
                                                               , FROM_DANGA_DATE               
                                                               , TO_DANGA_DATE                 
                                                               , SUBUL_DANUI                   
                                                               , BALJU_DANUI                   
                                                               , ORDER_SUBUL_DANUI             
                                                               , SUBUL_BUSEO                   
                                                               , BALJU_BUSEO                   
                                                               , CHANGE_QTYL                   
                                                               , CHANGE_QTYO                   
                                                               , JAEGO_QTY                     
                                                               , JAEGO_AMT                     
                                                               , LAST_IBGO_DANGA               
                                                               , LAST_IBGO_DATE                
                                                               , LAST_CHULGO_DATE              
                                                               , BUNRYU_BUNHO3                 
                                                               , BUNRYU_BUNHO4                 
                                                               , RACK_NO2                      
                                                               , HAMRYANG_DANUI                
                                                               , LIMIT_DV                      
                                                               , TOIJANG_YN                    
                                                               , BUNRYU_BUNHO5                 
                                                               , DELIVERY_GUBUN                
                                                               , TB_YN                         
                                                               , SKIN_TEST_YN                  
                                                               , IR_JUNDAL_YN                  
                                                               , JUSA                          
                                                               , CHANGE_QTYP                   
                                                               , MAIN_SUNGBUN_CODE             
                                                               , JIBGYE_YN                     
                                                               , BUGASE_YUL                    
                                                               , COMPANY_NAME                  
                                                               , MODEL_NAME                    
                                                               , FIRST_IBGO_DATE               
                                                               , IP_ADDR                       
                                                               , RE_USE_YN                     
                                                               , MIN_CHUNGGU_QTY               
                                                               , CUSTOMER_CODE3                
                                                               , SUTAK_YN                      
                                                               , CURENCY                       
                                                               , SET_CODE                      
                                                               , CUSTOMER_DANGA                
                                                               , MIN_BALJU_QTY     
                                                               , LABEL_DANUI            
                                                               , DRG_TRUNC                
                                                               , LABEL_DANUI2            
                                                               , CHK1,CHK2,CHK3,CHK4,CHK5,CHK6
                                                               , CHK7,CHK8,CHK9,CHKA,CHKB,CHKC,CHKD
                                                               , CHKE,CHKF
                                                               , DRG_COMMENT
                                                               , YONGRYANG
                                                               , TEXT_COLOR
                                                               , SMALL_CODE1
                                                               , ACT_JAERYO_NAME
                                                               , DRG_JIBGYE_GUBUN
                                                               , HOSP_CODE
                                            )VALUES (
                                                                 :f_lead_time                                
                                                               , :f_avg_qty_d                                
                                                               , :f_avg_qty_w                                
                                                               , :f_avg_qty_m                                
                                                               , :f_max_qty_d                                
                                                               , :f_max_qty_w                                
                                                               , :f_max_qty_m                                
                                                               , :f_hamryang                                 
                                                               , :f_jeje_gijun_qty                           
                                                               , :f_mix_yn                                   
                                                               , :f_mix_yn_inp                               
                                                               , :f_atc_yn                                   
                                                               , :f_atc_yn_inp                               
                                                               , :f_atc_code                                 
                                                               , :f_bogyong_code                             
                                                               , :f_hyoneung_code                            
                                                               , :f_caution_code                             
                                                               , :f_main_use_gwa1                            
                                                               , :f_main_use_gwa2                            
                                                               , :f_main_use_gwa3                            
                                                               , :f_main_use_gwa4                            
                                                               , :f_main_use_gwa5                            
                                                               , TO_DATE(:f_bulyong_to_date, 'YYYY/MM/DD')   
                                                               , :f_sugb_jaeryo_yn                           
                                                               , :f_gijun_amt                                
                                                               , :f_gijun_assure_amt                         
                                                               , :f_bungi_acct                               
                                                               , :f_old_manage_no                            
                                                               , :f_manage_no1                               
                                                               , :f_manage_no2                               
                                                               , :f_manage_no3                               
                                                               , :f_manage_no4                               
                                                               , :f_changgo1                                 
                                                               , :f_changgo2                                 
                                                               , :f_changgo3                                 
                                                               , :f_danga                                    
                                                               , :f_jukjung_qty                              
                                                               , :f_order_danui                              
                                                               , :f_gijun_danga                              
                                                               , :f_gijun_kyukyeok                           
                                                               , :f_bunryu9                                  
                                                               , :f_customer_code2                           
                                                               , :f_sungbun_code                             
                                                               , :f_bogyong_code1                            
                                                               , :f_bogyong_code2                            
                                                               , :f_bogyong_code3                            
                                                               , :f_bogyong_code4                            
                                                               , :f_drg_max_dv                               
                                                               , :f_drg_max_suryang                          
                                                               , TO_DATE(:f_balju_bulyong_date, 'YYYY/MM/DD')
                                                               , :f_use_yn                                   
                                                               , :f_remark                                   
                                                               , :f_sort_key                                 
                                                               , :f_weight                                   
                                                               , :f_ipchal_type                              
                                                               , :f_laundry_danga                            
                                                               , :f_rack_no                                  
                                                               , :f_path_bmp                                 
                                                               , TO_DATE(:f_start_date, 'YYYY/MM/DD')        
                                                               , TO_DATE(:f_end_date, 'YYYY/MM/DD')          
                                                               , :f_label_yn                                 
                                                               , TO_DATE(:f_sys_date, 'YYYY/MM/DD')          
                                                               , :f_user_id
                                                               , SYSDATE
                                                               , :f_jaeryo_code                              
                                                               , :f_manage_no                                
                                                               , :f_small_code                               
                                                               , :f_jaeryo_name                              
                                                               , :f_jaeryo_e_name                            
                                                               , :f_jaeryo_name_inx                          
                                                               , :f_bunryu_bunho1                            
                                                               , :f_bunryu_bunho2                            
                                                               , :f_kyukyeok                                 
                                                               , :f_pris_name                                
                                                               , :f_manage_name                              
                                                               , :f_sungbun_name                             
                                                               , NVL(:f_jaeryo_gubun, 'A')
                                                               , :f_jaeryo_grade                             
                                                               , :f_acct_id                                  
                                                               , :f_bunryu1                                  
                                                               , :f_bunryu2                                  
                                                               , :f_bunryu3                                  
                                                               , :f_bunryu4                                  
                                                               , :f_bunryu5                                  
                                                               , :f_bunryu6                                  
                                                               , :f_bunryu7                                  
                                                               , :f_bunryu8                                  
                                                               , NVL(TO_DATE(:f_jukyong_date, 'YYYY/MM/DD'),TRUNC(SYSDATE))
                                                               , :f_drg_type                                 
                                                               , :f_storage_yn                               
                                                               , :f_ice_yn                                   
                                                               , :f_bannab_yn                                
                                                               , :f_company_code                             
                                                               , :f_customer_code                            
                                                               , :f_yuhyo_yn                                 
                                                               , :f_yuhyo_month                              
                                                               , TO_DATE(:f_yuhyo_to_date, 'YYYY/MM/DD')     
                                                               , :f_suib_yn                                  
                                                               , :f_suib_customer                            
                                                               , :f_yunhap_join_yn                           
                                                               , :f_yunhap_code                              
                                                               , :f_bulyong_code                             
                                                               , TO_DATE(:f_bulyong_date, 'YYYY/MM/DD')      
                                                               , :f_subul_qcode_out                          
                                                               , :f_subul_qcode_inp                          
                                                               , :f_subul_qcode_er                           
                                                               , :f_danga_yn                                 
                                                               , TO_DATE(:f_from_danga_date, 'YYYY/MM/DD')   
                                                               , TO_DATE(:f_to_danga_date, 'YYYY/MM/DD')     
                                                               , :f_subul_danui                              
                                                               , :f_balju_danui                              
                                                               , :f_order_subul_danui                        
                                                               , :f_subul_buseo                              
                                                               , :f_balju_buseo                              
                                                               , :f_change_qtyl                              
                                                               , :f_change_qtyo                              
                                                               , :f_jaego_qty                                
                                                               , :f_jaego_amt                                
                                                               , :f_last_ibgo_danga                          
                                                               , TO_DATE(:f_last_ibgo_date, 'YYYY/MM/DD')    
                                                               , TO_DATE(:f_last_chulgo_date, 'YYYY/MM/DD')  
                                                               , :f_bunryu_bunho3                            
                                                               , :f_bunryu_bunho4                            
                                                               , :f_rack_no2                                 
                                                               , :f_hamryang_danui                           
                                                               , :f_limit_dv                                 
                                                               , :f_toijang_yn                               
                                                               , :f_bunryu_bunho5                            
                                                               , :f_delivery_gubun                           
                                                               , :f_tb_yn                                    
                                                               , :f_skin_test_yn                             
                                                               , :f_ir_jundal_yn                             
                                                               , :f_jusa                                     
                                                               , :f_change_qtyp                              
                                                               , :f_main_sungbun_code                        
                                                               , :f_jibgye_yn                                
                                                               , :f_bugase_yul                               
                                                               , :f_company_name                             
                                                               , :f_model_name                               
                                                               , TO_DATE(:f_first_ibgo_date, 'YYYY/MM/DD')   
                                                               , :f_ip_addr                                  
                                                               , :f_re_use_yn                                
                                                               , :f_min_chunggu_qty                          
                                                               , :f_customer_code3                           
                                                               , :f_sutak_yn                                 
                                                               , :f_curency                                  
                                                               , :f_set_code                                 
                                                               , :f_customer_danga                           
                                                               , :f_min_balju_qty     
                                                               , :f_label_danui        
                                                               , :f_drg_trunc          
                                                               , :f_label_danui2                           
                                                               , :f_chk1,:f_chk2,:f_chk3,:f_chk4,:f_chk5,:f_chk6              
                                                               , :f_chk7,:f_chk8,:f_chk9,:f_chkA,:f_chkB,:f_chkC,:f_chkD
                                                               , :f_chkE,:f_chkF
                                                               , :f_DrgComment                                  
                                                               , :f_yongryang                                  
                                                               , :f_text_color   
                                                               , :f_small_code1  
                                                               , :f_act_jaeryo_name
                                                               , :f_drg_jibgye_gubun
                                                               , :f_hosp_code
                                            )";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"BEGIN
                                                UPDATE INV0110 SET    
                                                   LEAD_TIME          = :f_lead_time           
                                                  ,AVG_QTY_D          = nvl(:f_avg_qty_d     , NULL)                           
                                                  ,AVG_QTY_W          = nvl(:f_avg_qty_w     , NULL)                           
                                                  ,AVG_QTY_M          = nvl(:f_avg_qty_m     , NULL)                           
                                                  ,MAX_QTY_D          = nvl(:f_max_qty_d     , NULL)                           
                                                  ,MAX_QTY_W          = nvl(:f_max_qty_w     , NULL)                           
                                                  ,MAX_QTY_M          = nvl(:f_max_qty_m     , NULL)                           
                                                  ,HAMRYANG           = :f_hamryang      
                                                  ,JEJE_GIJUN_QTY     = nvl(:f_jeje_gijun_qty, NULL)                           
                                                  ,MIX_YN             = :f_mix_yn                                   
                                                  ,MIX_YN_INP         = :f_mix_yn_inp                               
                                                  ,ATC_YN             = :f_atc_yn                                   
                                                  ,ATC_YN_INP         = :f_atc_yn_inp                               
                                                  ,ATC_CODE           = :f_atc_code                                 
                                                  ,BOGYONG_CODE       = :f_bogyong_code                             
                                                  ,HYONEUNG_CODE      = :f_hyoneung_code                            
                                                  ,CAUTION_CODE       = :f_caution_code                             
                                                  ,MAIN_USE_GWA1      = :f_main_use_gwa1                            
                                                  ,MAIN_USE_GWA2      = :f_main_use_gwa2                            
                                                  ,MAIN_USE_GWA3      = :f_main_use_gwa3                            
                                                  ,MAIN_USE_GWA4      = :f_main_use_gwa4                            
                                                  ,MAIN_USE_GWA5      = :f_main_use_gwa5
                                                  ,SUGB_JAERYO_YN     = :f_sugb_jaeryo_yn                           
                                                  ,GIJUN_AMT          = nvl(:f_gijun_amt, null)
                                                  ,GIJUN_ASSURE_AMT   = nvl(:f_gijun_assure_amt, null)                     
                                                  ,BUNGI_ACCT         = :f_bungi_acct                               
                                                  ,OLD_MANAGE_NO      = :f_old_manage_no                            
                                                  ,MANAGE_NO1         = :f_manage_no1                               
                                                  ,MANAGE_NO2         = :f_manage_no2                               
                                                  ,MANAGE_NO3         = :f_manage_no3                               
                                                  ,MANAGE_NO4         = :f_manage_no4                               
                                                  ,CHANGGO1           = :f_changgo1                                 
                                                  ,CHANGGO2           = :f_changgo2                                 
                                                  ,CHANGGO3           = :f_changgo3                                 
                                                  ,DANGA              = nvl(:f_danga       ,null)                              
                                                  ,JUKJUNG_QTY        = nvl(:f_jukjung_qty ,null)                             
                                                  ,ORDER_DANUI        = :f_order_danui                              
                                                  ,GIJUN_DANGA        = nvl(:f_gijun_danga, null)
                                                  ,GIJUN_KYUKYEOK     = :f_gijun_kyukyeok                           
                                                  ,BUNRYU9            = :f_bunryu9                                  
                                                  ,CUSTOMER_CODE2     = :f_customer_code2                           
                                                  ,SUNGBUN_CODE       = :f_sungbun_code                             
                                                  ,BOGYONG_CODE1      = :f_bogyong_code1                            
                                                  ,BOGYONG_CODE2      = :f_bogyong_code2                            
                                                  ,BOGYONG_CODE3      = :f_bogyong_code3                            
                                                  ,BOGYONG_CODE4      = :f_bogyong_code4                            
                                                  ,DRG_MAX_DV         = nvl(:f_drg_max_dv      ,null)                         
                                                  ,DRG_MAX_SURYANG    = nvl(:f_drg_max_suryang ,null)
                                                  ,USE_YN             = :f_use_yn                                   
                                                  ,REMARK             = :f_remark                                   
                                                  ,SORT_KEY           = nvl(:f_sort_key  , null)                               
                                                  ,WEIGHT             = nvl(:f_weight    , null)                               
                                                  ,IPCHAL_TYPE        = :f_ipchal_type                              
                                                  ,LAUNDRY_DANGA      = nvl(:f_laundry_danga, null)                            
                                                  ,RACK_NO            = :f_rack_no                                  
                                                  ,PATH_BMP           = :f_path_bmp
                                                  ,LABEL_YN           = :f_label_yn
                                                  ,UPD_ID             = :f_user_id
                                                  ,UPD_DATE           = SYSDATE
                                                  ,JAERYO_CODE        = :f_jaeryo_code                              
                                                  ,MANAGE_NO          = :f_manage_no                                
                                                  ,SMALL_CODE         = :f_small_code                               
                                                  ,JAERYO_NAME        = :f_jaeryo_name                              
                                                  ,JAERYO_E_NAME      = :f_jaeryo_e_name                            
                                                  ,JAERYO_NAME_INX    = :f_jaeryo_name_inx                          
                                                  ,BUNRYU_BUNHO1      = :f_bunryu_bunho1                            
                                                  ,BUNRYU_BUNHO2      = :f_bunryu_bunho2                            
                                                  ,KYUKYEOK           = :f_kyukyeok                                 
                                                  ,PRIS_NAME          = :f_pris_name                                
                                                  ,MANAGE_NAME        = :f_manage_name                              
                                                  ,SUNGBUN_NAME       = :f_sungbun_name                             
                                                  ,JAERYO_GUBUN       = NVL(:f_jaeryo_gubun, 'A')                             
                                                  ,JAERYO_GRADE       = :f_jaeryo_grade                             
                                                  ,ACCT_ID            = :f_acct_id                                  
                                                  ,BUNRYU1            = :f_bunryu1                                  
                                                  ,BUNRYU2            = :f_bunryu2                                  
                                                  ,BUNRYU3            = :f_bunryu3                                  
                                                  ,BUNRYU4            = :f_bunryu4                                  
                                                  ,BUNRYU5            = :f_bunryu5                                  
                                                  ,BUNRYU6            = :f_bunryu6                                  
                                                  ,BUNRYU7            = :f_bunryu7                                  
                                                  ,BUNRYU8            = :f_bunryu8                                  
                                                  ,JUKYONG_DATE       = TO_DATE(:f_jukyong_date, 'YYYY/MM/DD')
                                                  ,DRG_TYPE           = :f_drg_type                                 
                                                  ,STORAGE_YN         = :f_storage_yn                               
                                                  ,ICE_YN             = :f_ice_yn                                   
                                                  ,BANNAB_YN          = :f_bannab_yn                                
                                                  ,COMPANY_CODE       = :f_company_code                             
                                                  ,CUSTOMER_CODE      = :f_customer_code                            
                                                  ,YUHYO_YN           = :f_yuhyo_yn                                 
                                                  ,YUHYO_MONTH        = nvl(:f_yuhyo_month, null)                              
                                                  ,YUHYO_TO_DATE      = TO_DATE(:f_yuhyo_to_date, 'YYYY/MM/DD')     
                                                  ,SUIB_YN            = :f_suib_yn                                  
                                                  ,SUIB_CUSTOMER      = :f_suib_customer                            
                                                  ,YUNHAP_JOIN_YN     = :f_yunhap_join_yn                           
                                                  ,YUNHAP_CODE        = :f_yunhap_code                              
                                                  ,BULYONG_CODE       = :f_bulyong_code                             
                                                  ,BULYONG_DATE       = TO_DATE(:f_bulyong_to_date, 'YYYY/MM/DD')
                                                  ,SUBUL_QCODE_OUT    = :f_subul_qcode_out                          
                                                  ,SUBUL_QCODE_INP    = :f_subul_qcode_inp                          
                                                  ,SUBUL_QCODE_ER     = :f_subul_qcode_er                           
                                                  ,DANGA_YN           = :f_danga_yn
                                                  ,SUBUL_DANUI        = :f_subul_danui                              
                                                  ,BALJU_DANUI        = :f_balju_danui                              
                                                  ,ORDER_SUBUL_DANUI  = :f_order_subul_danui                        
                                                  ,SUBUL_BUSEO        = :f_subul_buseo                              
                                                  ,BALJU_BUSEO        = :f_balju_buseo                              
                                                  ,CHANGE_QTYL        = nvl(:f_change_qtyl   ,null)                           
                                                  ,CHANGE_QTYO        = nvl(:f_change_qtyo   ,null)                           
                                                  ,JAEGO_QTY          = nvl(:f_jaego_qty     ,null)                           
                                                  ,JAEGO_AMT          = nvl(:f_jaego_amt     ,null)                           
                                                  ,LAST_IBGO_DANGA    = nvl(:f_last_ibgo_danga  ,null)
                                                  ,BUNRYU_BUNHO3      = :f_bunryu_bunho3                            
                                                  ,BUNRYU_BUNHO4      = :f_bunryu_bunho4                            
                                                  ,RACK_NO2           = :f_rack_no2                                 
                                                  ,HAMRYANG_DANUI     = :f_hamryang_danui                           
                                                  ,LIMIT_DV           = nvl(:f_limit_dv, null)                                 
                                                  ,TOIJANG_YN         = :f_toijang_yn                               
                                                  ,BUNRYU_BUNHO5      = :f_bunryu_bunho5                            
                                                  ,DELIVERY_GUBUN     = :f_delivery_gubun                           
                                                  ,TB_YN              = :f_tb_yn                                    
                                                  ,SKIN_TEST_YN       = :f_skin_test_yn                             
                                                  ,IR_JUNDAL_YN       = :f_ir_jundal_yn                             
                                                  ,JUSA               = :f_jusa                                     
                                                  ,CHANGE_QTYP        = nvl(:f_change_qtyp,null)                              
                                                  ,MAIN_SUNGBUN_CODE  = :f_main_sungbun_code                        
                                                  ,JIBGYE_YN          = :f_jibgye_yn                                
                                                  ,BUGASE_YUL         = nvl(:f_bugase_yul, null)                               
                                                  ,COMPANY_NAME       = :f_company_name                             
                                                  ,MODEL_NAME         = :f_model_name
                                                  ,IP_ADDR            = :f_ip_addr                                  
                                                  ,RE_USE_YN          = :f_re_use_yn                                
                                                  ,MIN_CHUNGGU_QTY    = nvl(:f_min_chunggu_qty, null)                          
                                                  ,CUSTOMER_CODE3     = :f_customer_code3                           
                                                  ,SUTAK_YN           = :f_sutak_yn                                 
                                                  ,CURENCY            = :f_curency                                  
                                                  ,SET_CODE           = :f_set_code                                 
                                                  ,CUSTOMER_DANGA     = nvl(:f_customer_danga , null)                          
                                                  ,MIN_BALJU_QTY      = nvl(:f_min_balju_qty  , null)     
                                                  ,LABEL_DANUI        = :f_label_danui
                                                  ,DRG_TRUNC          = :f_drg_trunc
                                                  ,LABEL_DANUI2       = :f_label_danui2
                                                  ,CHK1               = :f_chk1                     
                                                  ,CHK2               = :f_chk2                     
                                                  ,CHK3               = :f_chk3                     
                                                  ,CHK4               = :f_chk4                     
                                                  ,CHK5               = :f_chk5                     
                                                  ,CHK6               = :f_chk6                     
                                                  ,CHK7               = :f_chk7                     
                                                  ,CHK8               = :f_chk8                     
                                                  ,CHK9               = :f_chk9                     
                                                  ,CHKA               = :f_chkA                     
                                                  ,CHKB               = :f_chkB                     
                                                  ,CHKC               = :f_chkC                     
                                                  ,CHKD               = :f_chkD    
                                                  ,CHKE               = :f_chkE
                                                  ,CHKF               = :f_chkF                 
                                                  ,DRG_COMMENT        = :f_DrgComment               
                                                  ,YONGRYANG          = :f_yongryang               
                                                  ,TEXT_COLOR         = :f_text_color  
                                                  ,SMALL_CODE1        = :f_small_code1 
                                                  ,ACT_JAERYO_NAME    = :f_act_jaeryo_name   
                                                  ,DRG_JIBGYE_GUBUN   = :f_drg_jibgye_gubun 
                                                WHERE  JAERYO_CODE    = :f_jaeryo_code  ;
                                              IF SQL%NOTFOUND THEN
                                                 INSERT INTO INV0110 (
                                                   LEAD_TIME                     
                                                  ,AVG_QTY_D                     
                                                  ,AVG_QTY_W                     
                                                  ,AVG_QTY_M                     
                                                  ,MAX_QTY_D                     
                                                  ,MAX_QTY_W                     
                                                  ,MAX_QTY_M                     
                                                  ,HAMRYANG                      
                                                  ,JEJE_GIJUN_QTY                
                                                  ,MIX_YN                        
                                                  ,MIX_YN_INP                    
                                                  ,ATC_YN                        
                                                  ,ATC_YN_INP                    
                                                  ,ATC_CODE                      
                                                  ,BOGYONG_CODE                  
                                                  ,HYONEUNG_CODE                 
                                                  ,CAUTION_CODE                  
                                                  ,MAIN_USE_GWA1                 
                                                  ,MAIN_USE_GWA2                 
                                                  ,MAIN_USE_GWA3                 
                                                  ,MAIN_USE_GWA4                 
                                                  ,MAIN_USE_GWA5                 
                                                  ,BULYONG_TO_DATE               
                                                  ,SUGB_JAERYO_YN                
                                                  ,GIJUN_AMT                     
                                                  ,GIJUN_ASSURE_AMT              
                                                  ,BUNGI_ACCT                    
                                                  ,OLD_MANAGE_NO                 
                                                  ,MANAGE_NO1                    
                                                  ,MANAGE_NO2                    
                                                  ,MANAGE_NO3                    
                                                  ,MANAGE_NO4                    
                                                  ,CHANGGO1                      
                                                  ,CHANGGO2                      
                                                  ,CHANGGO3                      
                                                  ,DANGA                         
                                                  ,JUKJUNG_QTY                   
                                                  ,ORDER_DANUI                   
                                                  ,GIJUN_DANGA                   
                                                  ,GIJUN_KYUKYEOK                
                                                  ,BUNRYU9                       
                                                  ,CUSTOMER_CODE2                
                                                  ,SUNGBUN_CODE                  
                                                  ,BOGYONG_CODE1                 
                                                  ,BOGYONG_CODE2                 
                                                  ,BOGYONG_CODE3                 
                                                  ,BOGYONG_CODE4                 
                                                  ,DRG_MAX_DV                    
                                                  ,DRG_MAX_SURYANG               
                                                  ,BALJU_BULYONG_DATE            
                                                  ,USE_YN                        
                                                  ,REMARK                        
                                                  ,SORT_KEY                      
                                                  ,WEIGHT                        
                                                  ,IPCHAL_TYPE                   
                                                  ,LAUNDRY_DANGA                 
                                                  ,RACK_NO                       
                                                  ,PATH_BMP                      
                                                  ,START_DATE                    
                                                  ,END_DATE                      
                                                  ,LABEL_YN                      
                                                  ,SYS_DATE                      
                                                  ,SYS_ID                       
                                                  ,UPD_DATE                      
                                                  ,JAERYO_CODE                   
                                                  ,MANAGE_NO                     
                                                  ,SMALL_CODE                    
                                                  ,JAERYO_NAME                   
                                                  ,JAERYO_E_NAME                 
                                                  ,JAERYO_NAME_INX               
                                                  ,BUNRYU_BUNHO1                 
                                                  ,BUNRYU_BUNHO2                 
                                                  ,KYUKYEOK                      
                                                  ,PRIS_NAME                     
                                                  ,MANAGE_NAME                   
                                                  ,SUNGBUN_NAME                  
                                                  ,JAERYO_GUBUN                  
                                                  ,JAERYO_GRADE                  
                                                  ,ACCT_ID                       
                                                  ,BUNRYU1                       
                                                  ,BUNRYU2                       
                                                  ,BUNRYU3                       
                                                  ,BUNRYU4                       
                                                  ,BUNRYU5                       
                                                  ,BUNRYU6                       
                                                  ,BUNRYU7                       
                                                  ,JUKYONG_DATE                  
                                                  ,DRG_TYPE                      
                                                  ,STORAGE_YN                    
                                                  ,ICE_YN                        
                                                  ,BANNAB_YN                     
                                                  ,COMPANY_CODE                  
                                                  ,CUSTOMER_CODE                 
                                                  ,YUHYO_YN                      
                                                  ,YUHYO_MONTH                   
                                                  ,YUHYO_TO_DATE                 
                                                  ,SUIB_YN                       
                                                  ,SUIB_CUSTOMER                 
                                                  ,YUNHAP_JOIN_YN                
                                                  ,YUNHAP_CODE                   
                                                  ,BULYONG_CODE                  
                                                  ,BULYONG_DATE                  
                                                  ,SUBUL_QCODE_OUT               
                                                  ,SUBUL_QCODE_INP               
                                                  ,SUBUL_QCODE_ER                
                                                  ,DANGA_YN                      
                                                  ,FROM_DANGA_DATE               
                                                  ,TO_DANGA_DATE                 
                                                  ,SUBUL_DANUI                   
                                                  ,BALJU_DANUI                   
                                                  ,ORDER_SUBUL_DANUI             
                                                  ,SUBUL_BUSEO                   
                                                  ,BALJU_BUSEO                   
                                                  ,CHANGE_QTYL                   
                                                  ,CHANGE_QTYO                   
                                                  ,JAEGO_QTY                     
                                                  ,JAEGO_AMT                     
                                                  ,LAST_IBGO_DANGA               
                                                  ,LAST_IBGO_DATE                
                                                  ,LAST_CHULGO_DATE              
                                                  ,BUNRYU_BUNHO3                 
                                                  ,BUNRYU_BUNHO4                 
                                                  ,RACK_NO2                      
                                                  ,HAMRYANG_DANUI                
                                                  ,LIMIT_DV                      
                                                  ,TOIJANG_YN                    
                                                  ,BUNRYU_BUNHO5                 
                                                  ,DELIVERY_GUBUN                
                                                  ,TB_YN                         
                                                  ,SKIN_TEST_YN                  
                                                  ,IR_JUNDAL_YN                  
                                                  ,JUSA                          
                                                  ,CHANGE_QTYP                   
                                                  ,MAIN_SUNGBUN_CODE             
                                                  ,JIBGYE_YN                     
                                                  ,BUGASE_YUL                    
                                                  ,COMPANY_NAME                  
                                                  ,MODEL_NAME                    
                                                  ,FIRST_IBGO_DATE               
                                                  ,IP_ADDR                       
                                                  ,RE_USE_YN                     
                                                  ,MIN_CHUNGGU_QTY               
                                                  ,CUSTOMER_CODE3                
                                                  ,SUTAK_YN                      
                                                  ,CURENCY                       
                                                  ,SET_CODE                      
                                                  ,CUSTOMER_DANGA                
                                                  ,MIN_BALJU_QTY          
                                                  ,LABEL_DANUI           
                                                  ,DRG_TRUNC            
                                                  ,LABEL_DANUI2      
                                                  ,CHK1,CHK2,CHK3,CHK4,CHK5,CHK6
                                                  ,CHK7,CHK8,CHK9,CHKA,CHKB,CHKC,CHKD
                                                  ,CHKE,CHKF
                                                  ,DRG_COMMENT
                                                  ,YONGRYANG
                                                  ,TEXT_COLOR
                                                  ,SMALL_CODE1
                                                  ,ACT_JAERYO_NAME
                                                  ,DRG_JIBGYE_GUBUN
                                                  ,HOSP_CODE
                                                )VALUES (
                                                    :f_lead_time                                
                                                  , :f_avg_qty_d                                
                                                  , :f_avg_qty_w                                
                                                  , :f_avg_qty_m                                
                                                  , :f_max_qty_d                                
                                                  , :f_max_qty_w                                
                                                  , :f_max_qty_m                                
                                                  , :f_hamryang                                 
                                                  , :f_jeje_gijun_qty                           
                                                  , :f_mix_yn                                   
                                                  , :f_mix_yn_inp                               
                                                  , :f_atc_yn                                   
                                                  , :f_atc_yn_inp                               
                                                  , :f_atc_code                                 
                                                  , :f_bogyong_code                             
                                                  , :f_hyoneung_code                            
                                                  , :f_caution_code                             
                                                  , :f_main_use_gwa1                            
                                                  , :f_main_use_gwa2                            
                                                  , :f_main_use_gwa3                            
                                                  , :f_main_use_gwa4                            
                                                  , :f_main_use_gwa5                            
                                                  , TO_DATE(:f_bulyong_to_date, 'YYYY/MM/DD')   
                                                  , :f_sugb_jaeryo_yn                           
                                                  , :f_gijun_amt                                
                                                  , :f_gijun_assure_amt                         
                                                  , :f_bungi_acct                               
                                                  , :f_old_manage_no                            
                                                  , :f_manage_no1                               
                                                  , :f_manage_no2                               
                                                  , :f_manage_no3                               
                                                  , :f_manage_no4                               
                                                  , :f_changgo1                                 
                                                  , :f_changgo2                                 
                                                  , :f_changgo3                                 
                                                  , :f_danga                                    
                                                  , :f_jukjung_qty                              
                                                  , :f_order_danui                              
                                                  , :f_gijun_danga                              
                                                  , :f_gijun_kyukyeok                           
                                                  , :f_bunryu9                                  
                                                  , :f_customer_code2                           
                                                  , :f_sungbun_code                             
                                                  , :f_bogyong_code1                            
                                                  , :f_bogyong_code2                            
                                                  , :f_bogyong_code3                            
                                                  , :f_bogyong_code4                            
                                                  , :f_drg_max_dv                               
                                                  , :f_drg_max_suryang                          
                                                  , TO_DATE(:f_balju_bulyong_date, 'YYYY/MM/DD')
                                                  , :f_use_yn                                   
                                                  , :f_remark                                   
                                                  , :f_sort_key                                 
                                                  , :f_weight                                   
                                                  , :f_ipchal_type                              
                                                  , :f_laundry_danga                            
                                                  , :f_rack_no                                  
                                                  , :f_path_bmp                                 
                                                  , TO_DATE(:f_start_date, 'YYYY/MM/DD')        
                                                  , TO_DATE(:f_end_date, 'YYYY/MM/DD')          
                                                  , :f_label_yn                                 
                                                  , TO_DATE(:f_sys_date, 'YYYY/MM/DD')          
                                                  , :f_user_id
                                                  , SYSDATE
                                                  , :f_jaeryo_code                              
                                                  , :f_manage_no                                
                                                  , :f_small_code                               
                                                  , :f_jaeryo_name                              
                                                  , :f_jaeryo_e_name                            
                                                  , :f_jaeryo_name_inx                          
                                                  , :f_bunryu_bunho1                            
                                                  , :f_bunryu_bunho2                            
                                                  , :f_kyukyeok                                 
                                                  , :f_pris_name                                
                                                  , :f_manage_name                              
                                                  , :f_sungbun_name                             
                                                  , NVL(:f_jaeryo_gubun, 'A')
                                                  , :f_jaeryo_grade                             
                                                  , :f_acct_id                                  
                                                  , :f_bunryu1                                  
                                                  , :f_bunryu2                                  
                                                  , :f_bunryu3                                  
                                                  , :f_bunryu4                                  
                                                  , :f_bunryu5                                  
                                                  , :f_bunryu6                                  
                                                  , :f_bunryu7                                  
                                                  , NVL(TO_DATE(:f_jukyong_date, 'YYYY/MM/DD'),TRUNC(SYSDATE))   
                                                  , :f_drg_type                                 
                                                  , :f_storage_yn                               
                                                  , :f_ice_yn                                   
                                                  , :f_bannab_yn                                
                                                  , :f_company_code                             
                                                  , :f_customer_code                            
                                                  , :f_yuhyo_yn                                 
                                                  , :f_yuhyo_month                              
                                                  , TO_DATE(:f_yuhyo_to_date, 'YYYY/MM/DD')     
                                                  , :f_suib_yn                                  
                                                  , :f_suib_customer                            
                                                  , :f_yunhap_join_yn                           
                                                  , :f_yunhap_code                              
                                                  , :f_bulyong_code                             
                                                  , TO_DATE(:f_bulyong_date, 'YYYY/MM/DD')      
                                                  , :f_subul_qcode_out                          
                                                  , :f_subul_qcode_inp                          
                                                  , :f_subul_qcode_er                           
                                                  , :f_danga_yn                                 
                                                  , TO_DATE(:f_from_danga_date, 'YYYY/MM/DD')   
                                                  , TO_DATE(:f_to_danga_date, 'YYYY/MM/DD')     
                                                  , :f_subul_danui                              
                                                  , :f_balju_danui                              
                                                  , :f_order_subul_danui                        
                                                  , :f_subul_buseo                              
                                                  , :f_balju_buseo                              
                                                  , :f_change_qtyl                              
                                                  , :f_change_qtyo                              
                                                  , :f_jaego_qty                                
                                                  , :f_jaego_amt                                
                                                  , :f_last_ibgo_danga                          
                                                  , TO_DATE(:f_last_ibgo_date, 'YYYY/MM/DD')    
                                                  , TO_DATE(:f_last_chulgo_date, 'YYYY/MM/DD')  
                                                  , :f_bunryu_bunho3                            
                                                  , :f_bunryu_bunho4                            
                                                  , :f_rack_no2                                 
                                                  , :f_hamryang_danui                           
                                                  , :f_limit_dv                                 
                                                  , :f_toijang_yn                               
                                                  , :f_bunryu_bunho5                            
                                                  , :f_delivery_gubun                           
                                                  , :f_tb_yn                                    
                                                  , :f_skin_test_yn                             
                                                  , :f_ir_jundal_yn                             
                                                  , :f_jusa                                     
                                                  , :f_change_qtyp                              
                                                  , :f_main_sungbun_code                        
                                                  , :f_jibgye_yn                                
                                                  , :f_bugase_yul                               
                                                  , :f_company_name                             
                                                  , :f_model_name                               
                                                  , TO_DATE(:f_first_ibgo_date, 'YYYY/MM/DD')   
                                                  , :f_ip_addr                                  
                                                  , :f_re_use_yn                                
                                                  , :f_min_chunggu_qty                          
                                                  , :f_customer_code3                           
                                                  , :f_sutak_yn                                 
                                                  , :f_curency                                  
                                                  , :f_set_code                                 
                                                  , :f_customer_danga                           
                                                  , :f_min_balju_qty    
                                                  , :f_label_danui    
                                                  , :f_drg_trunc                    
                                                  , :f_label_danui2    
                                                  ,:f_chk1,:f_chk2,:f_chk3,:f_chk4,:f_chk5,:f_chk6
                                                  ,:f_chk7,:f_chk8,:f_chk9,:f_chkA,:f_chkB,:f_chkC,:f_chkD
                                                  ,:f_chkE,:f_chkF
                                                  ,:f_DrgComment
                                                  ,:f_yongryang
                                                  ,:f_text_color
                                                  ,:f_small_code1
                                                  ,:f_act_jaeryo_name
                                                  ,:f_drg_jibgye_gubun
                                                  ,:f_hosp_code
                                                );
                                              END IF;
                                            END;";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE INV0110
                                             WHERE JAERYO_CODE    = :f_jaeryo_code
                                               AND HOSP_CODE      = :f_hosp_code";
                                break;
                        }
                        break;

                    case 'D':
                        cmdText = @"DELETE INV0110
                                     WHERE JAERYO_CODE    = :f_jaeryo_code
                                       AND HOSP_CODE      = :f_hosp_code";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
    }

    #region
    /*
	 
	new IHIS.Framework.MultiLayoutItem("材料コード"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("管理番号"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("小分類コード"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("材料コード名"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("品目名_ローマ字"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("材料コード＋管理番号＋材料コード名"   , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("物品分類１"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("物品分類２"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("規格"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("代表名"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("管理名"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("成分名"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("品目区分"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("品目グレード"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("アカウント科目"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("分類１"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("分類２"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("分類３"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("分類４"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("分類５"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("分類６"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("分類７"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("分類８"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("適用日付"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("剤形"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("保存品可否"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("冷蔵可否"            , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("返納可否"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("会社コード"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("取引先コード"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("有効期間可否"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("有効期間月数"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("有効期間_TO"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("輸入可否"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("輸入会社"  　, IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("連合会JOIN可否"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("連合会コード"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("不用処理根拠コード"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("不用日付"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("受払適用数量コード_外来"   , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("受払適用数量コード_入院"   , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("受払適用数量コード_至急"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("単価契約可否"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("単価適用日_FROM"   , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("単価契約終了日"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("受払単位"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("発注単位"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("処方受払単位" , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("受払_払出部署"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("発注購買部署"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("受払換算数量"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("処方受払換算数量"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("在庫数量"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("在庫金額"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("最終入庫単価"   , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("最終入庫日付"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("最終払出日付"  , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("入庫までの所要時間"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("日平均数量"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("週平均数量"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("月平均数量"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("日最大量"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("週最大量"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("月最大量"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("合量"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("製剤基準数量"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("MIX可否"            , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("MIX可否_入院"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("ATC可否"            , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("ATC可否_入院"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("ATCコード"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("服用コード0"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("効能コード"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("注意事項コード"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("主使用部署１"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("主使用部署２"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("主使用部署３"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("主使用部署４"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("主使用部署５"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("不用終了日付"   , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("受給計画可否"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("入札時提示基準価"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("連合会協約価"  , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("代替アカウント"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("旧管理コード"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("管理番号１"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("管理番号２"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("管理番号３"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("管理番号４"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("保管倉庫２"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("保管倉庫３"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("単価"             , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("適正在庫数量"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("処方単位"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("基準単価"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("基準規格"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("分類９"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("取引先コード２"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("成分コード"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("服用コード1"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("服用コード2"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("服用コード3"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("服用コード4"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("一日最大投薬回数"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("一日最大投薬数量"   , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("発注不用日", IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("使用可否"            , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("摘要"            , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("出力順番"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("体重"            , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("入出タイプ"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("洗濯単価"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("rack番号"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("写真保存位置"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("スタート日付"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("エンド日付"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("ラベル出力可否"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("物品分類３"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("物品分類４"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("物品位置"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("合量単位"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("制限DV"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("後発医薬品可否"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("物品分類５"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("DELIVERY区分"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("結核薬可否"             , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("スキンテスト可否"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("注射室伝達薬"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("注射区分"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("点数金額換算数量"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("主成分コード" , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("配置集計可否"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("付加税率"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("会社名"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("モデル名"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("単価適用日付"   , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("IPアドレス"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("再使用可否"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("最小請求単位数量"   , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("取引先コード３"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("受託可否"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("通貨"           , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("SETコード"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("取引先単価"    , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("最小発注数量"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("ラベル単位"       , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("四捨五入"         , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("ラベル単位２"      , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("材料状態"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("一般区分"     , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("粉砕"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("簡易懸濁"              , IHIS.Framework.DataType.String, false, true, FC.Framework.EncodingType.Default),
	new IHIS.Framework.MultiLayoutItem("一包化"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("混合"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("MIX"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("在庫僅少薬"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("事前準備薬"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("調剤薬局購入薬"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("化学療法剤"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("レジメ管理薬"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("抗がん剤"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("受注発注薬"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("薬局コメント"        , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("保管倉庫１"          , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("処方箋"              , IHIS.Framework.DataType.String, false, true),
	new IHIS.Framework.MultiLayoutItem("容量"         , IHIS.Framework.DataType.String, false, true)
                     
	 * */
    #endregion
}