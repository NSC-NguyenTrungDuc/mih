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

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG5100P01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG2010R00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
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
        private IHIS.Framework.XEditGridCell xEditGridCell57;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell62;
        private IHIS.Framework.XEditGridCell xEditGridCell63;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
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
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
        private IHIS.Framework.XEditGridCell xEditGridCell101;
        private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XEditGridCell xEditGridCell103;
        private IHIS.Framework.XEditGridCell xEditGridCell104;
        private IHIS.Framework.XEditGridCell xEditGridCell105;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
 //       private IHIS.Framework.XDataWindow dw1;
        private IHIS.Framework.MultiLayout layLabel;
        private IHIS.Framework.MultiLayout layOrder;
        private IHIS.Framework.XEditGrid grdOrderList;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell98;
        private IHIS.Framework.XEditGridCell xEditGridCell106;
        private IHIS.Framework.XEditGridCell xEditGridCell107;
        private IHIS.Framework.XEditGridCell xEditGridCell108;
        private IHIS.Framework.MultiLayout layOrderJungbo;
        private IHIS.Framework.MultiLayout layOrderPrint;
        private System.Windows.Forms.Timer timer1;
        private IHIS.Framework.MultiLayout layNebokLabel;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
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
        private MultiLayoutItem multiLayoutItem283;
        private MultiLayoutItem multiLayoutItem284;
        private MultiLayoutItem multiLayoutItem285;
        private MultiLayoutItem multiLayoutItem286;
        private MultiLayoutItem multiLayoutItem287;
        private MultiLayoutItem multiLayoutItem288;
        private MultiLayoutItem multiLayoutItem289;
        private MultiLayoutItem multiLayoutItem290;
        private Splitter splitter2;
        private Splitter splitter1;
        private ToolTip toolTip;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell110;
        private XEditGridCell xEditGridCell111;
        private ImageList imageListMixGroup;
        private MultiLayout layAutoJubsu;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private System.ComponentModel.IContainer components = null;

        public DRG2010R00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("[" + ex.Message + "] [" + ex.StackTrace + "]");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG2010R00));
            this.pnlFill = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOrderList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
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
            this.layLabel = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
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
            this.layOrder = new IHIS.Framework.MultiLayout();
            this.layOrderPrint = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem283 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem284 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem285 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem286 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem287 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem288 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem289 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem290 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.layOrderJungbo = new IHIS.Framework.MultiLayout();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.layNebokLabel = new IHIS.Framework.MultiLayout();
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.layAutoJubsu = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.pnlFill.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNebokLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAutoJubsu)).BeginInit();
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
            this.ImageList.Images.SetKeyName(9, "팝업창.gif");
            this.ImageList.Images.SetKeyName(10, "autoSizeHeight.gif");
            this.ImageList.Images.SetKeyName(11, "autoSizeHeight2.gif");
            this.ImageList.Images.SetKeyName(12, "YESEN1.ICO");
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.xPanel2);
            this.pnlFill.Controls.Add(this.splitter2);
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Name = "pnlFill";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdOrderList);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOrderList
            // 
            this.grdOrderList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell61,
            this.xEditGridCell17,
            this.xEditGridCell89,
            this.xEditGridCell62,
            this.xEditGridCell90,
            this.xEditGridCell63,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell60,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell38,
            this.xEditGridCell37,
            this.xEditGridCell64,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell39,
            this.xEditGridCell65,
            this.xEditGridCell12,
            this.xEditGridCell14,
            this.xEditGridCell36,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell59,
            this.xEditGridCell66,
            this.xEditGridCell71,
            this.xEditGridCell73,
            this.xEditGridCell72,
            this.xEditGridCell82,
            this.xEditGridCell98,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell28,
            this.xEditGridCell110,
            this.xEditGridCell111});
            this.grdOrderList.ColPerLine = 16;
            this.grdOrderList.Cols = 17;
            this.grdOrderList.ControlBinding = true;
            resources.ApplyResources(this.grdOrderList, "grdOrderList");
            this.grdOrderList.ExecuteQuery = null;
            this.grdOrderList.FixedCols = 1;
            this.grdOrderList.FixedRows = 1;
            this.grdOrderList.HeaderHeights.Add(34);
            this.grdOrderList.Name = "grdOrderList";
            this.grdOrderList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderList.ParamList")));
            this.grdOrderList.QuerySQL = resources.GetString("grdOrderList.QuerySQL");
            this.grdOrderList.RowHeaderVisible = true;
            this.grdOrderList.Rows = 2;
            this.grdOrderList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderList_QueryStarting);
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "bunho";
            this.xEditGridCell83.CellWidth = 25;
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            this.xEditGridCell83.IsReadOnly = true;
            this.xEditGridCell83.IsUpdCol = false;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "drg_bunho";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            this.xEditGridCell84.IsReadOnly = true;
            this.xEditGridCell84.IsUpdCol = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "naewon_date";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsUpdCol = false;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "group_ser";
            this.xEditGridCell86.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell86.CellWidth = 22;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.IsUpdCol = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "jubsu_date";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.IsReadOnly = true;
            this.xEditGridCell87.IsUpdCol = false;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "order_date";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            this.xEditGridCell88.IsReadOnly = true;
            this.xEditGridCell88.IsUpdCol = false;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.ApplyPaintingEvent = true;
            this.xEditGridCell61.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell61.CellName = "jaeryo_code";
            this.xEditGridCell61.CellWidth = 74;
            this.xEditGridCell61.Col = 2;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsUpdCol = false;
            this.xEditGridCell61.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.ApplyPaintingEvent = true;
            this.xEditGridCell17.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell17.CellName = "nalsu";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.CellWidth = 30;
            this.xEditGridCell17.Col = 7;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "divide";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.ApplyPaintingEvent = true;
            this.xEditGridCell62.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell62.CellName = "ord_suryang";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell62.CellWidth = 48;
            this.xEditGridCell62.Col = 4;
            this.xEditGridCell62.DecimalDigits = 3;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.IsUpdCol = false;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "order_suryang";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.IsUpdCol = false;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.ApplyPaintingEvent = true;
            this.xEditGridCell63.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell63.CellName = "order_danui";
            this.xEditGridCell63.Col = 8;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            this.xEditGridCell63.IsUpdCol = false;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "subul_danui";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.IsReadOnly = true;
            this.xEditGridCell91.IsUpdCol = false;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "group_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsUpdCol = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "jaeryo_gubun";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsUpdCol = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.ApplyPaintingEvent = true;
            this.xEditGridCell60.CellName = "bogyong_code";
            this.xEditGridCell60.CellWidth = 65;
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsUpdCol = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "bogyong_name";
            this.xEditGridCell94.CellWidth = 95;
            this.xEditGridCell94.Col = 9;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdCol = false;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "caution_name";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.IsUpdCol = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "caution_code";
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.ExecuteQuery = null;
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.IsUpdCol = false;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "mix_yn";
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsUpdCol = false;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.ApplyPaintingEvent = true;
            this.xEditGridCell38.CellLen = 35;
            this.xEditGridCell38.CellName = "atc_yn";
            this.xEditGridCell38.CellWidth = 28;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdCol = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.ApplyPaintingEvent = true;
            this.xEditGridCell37.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell37.CellName = "dv";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell37.CellWidth = 30;
            this.xEditGridCell37.Col = 6;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.ApplyPaintingEvent = true;
            this.xEditGridCell64.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell64.CellName = "dv_time";
            this.xEditGridCell64.CellWidth = 25;
            this.xEditGridCell64.Col = 5;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsReadOnly = true;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "dc_yn";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsUpdCol = false;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "bannab_yn";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "source_fkocs1003";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "fkocs1003";
            this.xEditGridCell102.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.ExecuteQuery = null;
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "fkout1001";
            this.xEditGridCell103.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.IsUpdCol = false;
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "sunab_date";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            this.xEditGridCell104.IsReadOnly = true;
            this.xEditGridCell104.IsUpdCol = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "pattern";
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.ExecuteQuery = null;
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsUpdCol = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.ApplyPaintingEvent = true;
            this.xEditGridCell39.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell39.CellName = "jaeryo_name";
            this.xEditGridCell39.CellWidth = 324;
            this.xEditGridCell39.Col = 3;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdCol = false;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellLen = 35;
            this.xEditGridCell65.CellName = "sunab_nalsu";
            this.xEditGridCell65.CellWidth = 35;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsUpdCol = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "wonyoi_yn";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 4000;
            this.xEditGridCell14.CellName = "ord_remark";
            this.xEditGridCell14.CellWidth = 35;
            this.xEditGridCell14.Col = 14;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "act_date";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "mayak";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdCol = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "tpn_joje_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "ui_jusa_yn";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsUpdCol = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "subul_suryang";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.IsUpdCol = false;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.ApplyPaintingEvent = true;
            this.xEditGridCell59.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell59.CellName = "serial_v";
            this.xEditGridCell59.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell59.CellWidth = 25;
            this.xEditGridCell59.Col = 1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.SuppressRepeating = true;
            this.xEditGridCell59.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.ApplyPaintingEvent = true;
            this.xEditGridCell66.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell66.CellName = "powder_yn";
            this.xEditGridCell66.CellWidth = 22;
            this.xEditGridCell66.Col = 10;
            this.xEditGridCell66.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.IsUpdCol = false;
            this.xEditGridCell66.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell71.CellName = "gyunbon_yn";
            this.xEditGridCell71.CellWidth = 25;
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            this.xEditGridCell71.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "print_yn";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.IsUpdCol = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "old_gyunbon_yn";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            this.xEditGridCell72.IsUpdatable = false;
            this.xEditGridCell72.IsUpdCol = false;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "order_remark";
            this.xEditGridCell82.CellWidth = 43;
            this.xEditGridCell82.Col = 15;
            this.xEditGridCell82.DisplayMemoText = true;
            this.xEditGridCell82.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsUpdCol = false;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "drg_remark";
            this.xEditGridCell98.CellWidth = 43;
            this.xEditGridCell98.Col = 16;
            this.xEditGridCell98.DisplayMemoText = true;
            this.xEditGridCell98.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsUpdCol = false;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "hubal_change_yn";
            this.xEditGridCell106.CellWidth = 22;
            this.xEditGridCell106.Col = 13;
            this.xEditGridCell106.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsUpdCol = false;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "pharmacy";
            this.xEditGridCell107.CellWidth = 25;
            this.xEditGridCell107.Col = 11;
            this.xEditGridCell107.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsUpdCol = false;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "drg_pack_yn";
            this.xEditGridCell108.CellWidth = 22;
            this.xEditGridCell108.Col = 12;
            this.xEditGridCell108.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsUpdCol = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "mix_group";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "hope_date";
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            this.xEditGridCell110.IsUpdCol = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "order_gubun";
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.ExecuteQuery = null;
            this.xEditGridCell111.IsUpdCol = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // splitter2
            // 
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "order_remark";
            this.xEditGridCell79.CellWidth = 45;
            this.xEditGridCell79.Col = 14;
            this.xEditGridCell79.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsUpdCol = false;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "jaeryo_comments";
            this.xEditGridCell77.CellWidth = 45;
            this.xEditGridCell77.Col = 15;
            this.xEditGridCell77.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsUpdCol = false;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "bohum";
            this.xEditGridCell75.CellWidth = 30;
            this.xEditGridCell75.Col = 11;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsUpdCol = false;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "huntak";
            this.xEditGridCell76.CellWidth = 30;
            this.xEditGridCell76.Col = 12;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsUpdCol = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "serial_v";
            this.xEditGridCell10.CellWidth = 35;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.RowSpan = 2;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bogyong_code";
            this.xEditGridCell11.CellWidth = 64;
            this.xEditGridCell11.Col = 9;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 35;
            this.xEditGridCell13.CellName = "atc_yn";
            this.xEditGridCell13.CellWidth = 38;
            this.xEditGridCell13.Col = 4;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "dv_time";
            this.xEditGridCell15.CellWidth = 30;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.Row = 1;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "dv";
            this.xEditGridCell16.CellWidth = 30;
            this.xEditGridCell16.Col = 6;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.Row = 1;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellLen = 35;
            this.xEditGridCell18.CellName = "sunab_nalsu";
            this.xEditGridCell18.CellWidth = 39;
            this.xEditGridCell18.Col = 12;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.RowSpan = 2;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 35;
            this.xEditGridCell19.CellName = "atc_yn";
            this.xEditGridCell19.CellWidth = 30;
            this.xEditGridCell19.Col = 11;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "powder_yn";
            this.xEditGridCell24.CellWidth = 30;
            this.xEditGridCell24.Col = 10;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "jaeryo_name";
            this.xEditGridCell20.CellWidth = 222;
            this.xEditGridCell20.Col = 3;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.RowSpan = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "照 会", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.F1, "再発行", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "閉じる", -1, "")});
            this.btnList.ImageList = this.ImageList;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "wonyoi_yn";
            this.xEditGridCell9.CellWidth = 44;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.Row = 1;
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "order_danui";
            this.xEditGridCell23.Col = 11;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.Row = 1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "bunho";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "order_suryang";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "subul_danui";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "group_yn";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jaeryo_gubun";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "bogyong_name";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "caution_name";
            this.xEditGridCell47.Col = 10;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.Row = 1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "caution_code";
            this.xEditGridCell48.Col = 11;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.Row = 1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "mix_yn";
            this.xEditGridCell49.Col = 13;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.Row = 1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "atc_yn";
            this.xEditGridCell50.Col = 14;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.Row = 1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "remark";
            this.xEditGridCell51.Col = 15;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.Row = 1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "dc_yn";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "bannab_yn";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "source_fkocs1003";
            this.xEditGridCell54.Col = 16;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.Row = 1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "fkocs1003";
            this.xEditGridCell55.Col = 17;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.Row = 1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "fkout1001";
            this.xEditGridCell56.Col = 18;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.Row = 1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "sunab_date";
            this.xEditGridCell57.Col = 19;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.Row = 1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "pattern";
            this.xEditGridCell58.Col = 20;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.Row = 1;
            // 
            // layLabel
            // 
            this.layLabel.ExecuteQuery = null;
            this.layLabel.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
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
            this.multiLayoutItem40});
            this.layLabel.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layLabel.ParamList")));
            this.layLabel.QuerySQL = resources.GetString("layLabel.QuerySQL");
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "order_date";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "kyukyeok";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "kyukyeok1";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "drg_bunho";
            this.multiLayoutItem24.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "bunho";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "dv";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "drg_grp";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "suname";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "gwa_name";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "bogyong_code";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "bogyong_name";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "nalsu";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "bunryu1";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "caution_name";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "jaeryo_name";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "gyunbon_yn";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "kind";
            this.multiLayoutItem37.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "serial_v";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "hope";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "donbok";
            // 
            // layOrder
            // 
            this.layOrder.ExecuteQuery = null;
            this.layOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrder.ParamList")));
            // 
            // layOrderPrint
            // 
            this.layOrderPrint.ExecuteQuery = null;
            this.layOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem283,
            this.multiLayoutItem284,
            this.multiLayoutItem285,
            this.multiLayoutItem286,
            this.multiLayoutItem287,
            this.multiLayoutItem288,
            this.multiLayoutItem289,
            this.multiLayoutItem290});
            this.layOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderPrint.ParamList")));
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "bunho";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "drg_bunho";
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "naewon_date";
            this.multiLayoutItem119.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "group_ser";
            this.multiLayoutItem120.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "jubsu_date";
            this.multiLayoutItem121.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "order_date";
            this.multiLayoutItem122.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "jaeryo_code";
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "nalsu";
            this.multiLayoutItem124.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "divide";
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "ord_surang";
            this.multiLayoutItem126.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "order_suryang";
            this.multiLayoutItem127.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "order_danui";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "subul_danui";
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "group_yn";
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "jaeryo_gubun";
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "bogyong_code";
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "bogyong_name";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "caution_name";
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "caution_code";
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "mix_yn";
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "atc_yn";
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "dv";
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "dv_time";
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "dc_yn";
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "bannab_yn";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "source_fkocs1003";
            this.multiLayoutItem142.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "fkocs1003";
            this.multiLayoutItem143.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "sunab_date";
            this.multiLayoutItem144.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "pattern";
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "jaeryo_name";
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "sunab_nalsu";
            this.multiLayoutItem147.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "wonyoi_yn";
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "order_remark";
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "act_date";
            this.multiLayoutItem150.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "mayak";
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "tpn_joje_gubun";
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "ui_jusa_yn";
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "subul_suryang";
            this.multiLayoutItem154.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "serial_v";
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "gwa_name";
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "doctor_name";
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "suname";
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "suname2";
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "birth";
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "sex_age";
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "other_gwa";
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "do_order";
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "hope_nm";
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "powder_yn";
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "rowno";
            this.multiLayoutItem166.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "kyukyeok";
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "licenes";
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "bunryu1";
            // 
            // multiLayoutItem170
            // 
            this.multiLayoutItem170.DataName = "mix_group";
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "donbok_yn";
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "tusuk";
            // 
            // multiLayoutItem173
            // 
            this.multiLayoutItem173.DataName = "bigo";
            // 
            // multiLayoutItem174
            // 
            this.multiLayoutItem174.DataName = "text_color";
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "changgo";
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "gubun_name";
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "johap";
            // 
            // multiLayoutItem178
            // 
            this.multiLayoutItem178.DataName = "gaein";
            // 
            // multiLayoutItem179
            // 
            this.multiLayoutItem179.DataName = "gaein_no";
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "bonin_gubun";
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "bon_rate";
            // 
            // multiLayoutItem182
            // 
            this.multiLayoutItem182.DataName = "budamja_bunho1";
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "sugubja_bunho1";
            // 
            // multiLayoutItem184
            // 
            this.multiLayoutItem184.DataName = "budamja_bunho2";
            // 
            // multiLayoutItem185
            // 
            this.multiLayoutItem185.DataName = "sugubja_bunho2";
            // 
            // multiLayoutItem186
            // 
            this.multiLayoutItem186.DataName = "sunwon_gubun";
            // 
            // multiLayoutItem187
            // 
            this.multiLayoutItem187.DataName = "noin_rate_name";
            // 
            // multiLayoutItem188
            // 
            this.multiLayoutItem188.DataName = "user_id";
            // 
            // multiLayoutItem283
            // 
            this.multiLayoutItem283.DataName = "data_gubun";
            // 
            // multiLayoutItem284
            // 
            this.multiLayoutItem284.DataName = "mayak_license";
            // 
            // multiLayoutItem285
            // 
            this.multiLayoutItem285.DataName = "mayak_doctor";
            // 
            // multiLayoutItem286
            // 
            this.multiLayoutItem286.DataName = "mayak_address1";
            // 
            // multiLayoutItem287
            // 
            this.multiLayoutItem287.DataName = "mayak_address2";
            // 
            // multiLayoutItem288
            // 
            this.multiLayoutItem288.DataName = "gigan_date";
            // 
            // multiLayoutItem289
            // 
            this.multiLayoutItem289.DataName = "hubal_change_yn";
            // 
            // multiLayoutItem290
            // 
            this.multiLayoutItem290.DataName = "hubal_all_yn";
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "gyunbon_yn";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // layOrderJungbo
            // 
            this.layOrderJungbo.ExecuteQuery = null;
            this.layOrderJungbo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem116});
            this.layOrderJungbo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderJungbo.ParamList")));
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "text_1";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "text_2";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "text_3";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "comments";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "bunho_comments";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "bar_drg_bunho";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "bar_rp_bunho";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "cpl_1";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "cpl_2";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "cpl_3";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "danui_1";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "danui_2";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "danui_3";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "hl_1";
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "hl_2";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "hl_3";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // layNebokLabel
            // 
            this.layNebokLabel.ExecuteQuery = null;
            this.layNebokLabel.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem210});
            this.layNebokLabel.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layNebokLabel.ParamList")));
            this.layNebokLabel.QuerySQL = resources.GetString("layNebokLabel.QuerySQL");
            // 
            // multiLayoutItem189
            // 
            this.multiLayoutItem189.DataName = "bunho";
            // 
            // multiLayoutItem190
            // 
            this.multiLayoutItem190.DataName = "gwa_name";
            // 
            // multiLayoutItem191
            // 
            this.multiLayoutItem191.DataName = "doctor_name";
            // 
            // multiLayoutItem192
            // 
            this.multiLayoutItem192.DataName = "suname";
            // 
            // multiLayoutItem193
            // 
            this.multiLayoutItem193.DataName = "suname2";
            // 
            // multiLayoutItem194
            // 
            this.multiLayoutItem194.DataName = "age";
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "sex";
            // 
            // multiLayoutItem196
            // 
            this.multiLayoutItem196.DataName = "birth";
            // 
            // multiLayoutItem197
            // 
            this.multiLayoutItem197.DataName = "drg_bunho";
            // 
            // multiLayoutItem198
            // 
            this.multiLayoutItem198.DataName = "rp_bunho";
            // 
            // multiLayoutItem199
            // 
            this.multiLayoutItem199.DataName = "jubsu_date";
            // 
            // multiLayoutItem200
            // 
            this.multiLayoutItem200.DataName = "jusa_gubun";
            // 
            // multiLayoutItem201
            // 
            this.multiLayoutItem201.DataName = "jusa_spd_gubun";
            // 
            // multiLayoutItem202
            // 
            this.multiLayoutItem202.DataName = "ord_surang";
            // 
            // multiLayoutItem203
            // 
            this.multiLayoutItem203.DataName = "ord_danui";
            // 
            // multiLayoutItem204
            // 
            this.multiLayoutItem204.DataName = "dv_time";
            // 
            // multiLayoutItem205
            // 
            this.multiLayoutItem205.DataName = "dv";
            // 
            // multiLayoutItem206
            // 
            this.multiLayoutItem206.DataName = "bogyong_code";
            // 
            // multiLayoutItem207
            // 
            this.multiLayoutItem207.DataName = "subul_surang";
            // 
            // multiLayoutItem208
            // 
            this.multiLayoutItem208.DataName = "subul_danui";
            // 
            // multiLayoutItem209
            // 
            this.multiLayoutItem209.DataName = "jaeryo_name";
            // 
            // multiLayoutItem210
            // 
            this.multiLayoutItem210.DataName = "nalsu_cnt";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
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
            // layAutoJubsu
            // 
            this.layAutoJubsu.ExecuteQuery = null;
            this.layAutoJubsu.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14});
            this.layAutoJubsu.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layAutoJubsu.ParamList")));
            this.layAutoJubsu.QuerySQL = resources.GetString("layAutoJubsu.QuerySQL");
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "bunho";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "order_date";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "drg_bunho";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "suname";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "boryu_yn";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "order_remark";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "drg_remark";
            // 
            // DRG2010R00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlBottom);
            this.Name = "DRG2010R00";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.DRG2010R00_Load);
            this.pnlFill.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNebokLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAutoJubsu)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Common Method Variable

        private void MasterServerCall()
        {
            grdOrderList.ReadOnly = false;
            this.grdOrderList.Reset();

            SingleLayout layCommon = new SingleLayout();
            layCommon.LayoutItems.Clear();
            layCommon.LayoutItems.Add("DRG_BUNHO");
            layCommon.LayoutItems.Add("ORDER_DATE");
            layCommon.LayoutItems.Add("JUBSU_DATE");

          
            layCommon.QuerySQL = @"SELECT DISTINCT A.DRG_BUNHO 
                                    ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD') ORDER_DATE
                                    ,TO_CHAR(B.JUBSU_DATE,'YYYY/MM/DD') JUBSU_DATE
                                    FROM OCS1003 A, DRG2010 B
                                   WHERE A.FKOUT1001 = :f_pkout1001
                                  AND B.FKOCS1003 = A.PKOCS1003";
            
            layCommon.SetBindVarValue("f_pkout1001", this.pkout1001);

            if (layCommon.QueryLayout())
            {
               
                Hashtable inputList = new Hashtable();
                string jubsu = layCommon.GetItemValue("JUBSU_DATE").ToString();
                inputList.Add("I_SYS_DATE", EnvironInfo.GetSysDate().ToShortDateString());
                inputList.Add("I_USER_ID", UserInfo.UserID);
                inputList.Add("I_ORDER_DATE", layCommon.GetItemValue("ORDER_DATE").ToString());
                inputList.Add("I_JUBSU_DATE", layCommon.GetItemValue("JUBSU_DATE").ToString());
                inputList.Add("I_DRG_BUNHO", layCommon.GetItemValue("DRG_BUNHO").ToString());
                inputList.Add("I_WONYOI_ORDER_YN", "N");
                inputList.Add("I_JUBSU_YN", "Y");
                inputList.Add("I_GYUNBON_YN", "");

                Hashtable outputList = new Hashtable();
                if (!Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_OUT", inputList, outputList))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }

                this.grdOrderList.QueryLayout(false);
                /*
                inputList.Remove("I_JUBSU_YN");
                inputList.Add("I_JUBSU_YN", "N");

                if (!Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_OUT", inputList, outputList))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }
                 */
        }
        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion

        #region btnList_ButtonClick
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    MasterServerCall();
                    break;
                case FunctionType.Print://처방전출력
                    e.IsBaseCall = false;
                    if (grdOrderList.RowCount == 0) return;
                    // 처방전 출력
                    QueryWonnae01("R");
                    break;
            }            
        }
        #endregion

        #region 처방전 출력
        private void QueryWonnae01(string replay)
        {
            int row;
            string order_date = "";
            string bunho = "";
   //         dw1.Reset();
   //         dw1.DataWindowObject = "d_won_order";
            layOrderPrint.Reset();
            layOrderJungbo.Reset();
            /*
            SingleLayout layCommon = new SingleLayout();

            layCommon.LayoutItems.Add("DRG_BUNHO");
            layCommon.LayoutItems.Add("ORDER_DATE");

            
           //layCommon.QuerySQL = @"SELECT DISTINCT B.DRG_BUNHO , TO_CHAR(B.ORDER_DATE,'YYYY/MM/DD')
           //                         FROM OUT1001 A, DRG2010 B
           //                        WHERE A.PKOUT1001 = :f_pkout1001
           //                        AND A.BUNHO = B.BUNHO
           //                        AND A.NAEWON_DATE = B.ORDER_DATE ";


           
             
            layCommon.QuerySQL = @"SELECT DISTINCT A.DRG_BUNHO , TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')
                                    FROM OCS1003 A
                                   WHERE A.FKOUT1001 = :f_pkout1001";
            
            */
            SingleLayout layCommon = new SingleLayout();
            layCommon.LayoutItems.Clear();
            layCommon.LayoutItems.Add("DRG_BUNHO");
            layCommon.LayoutItems.Add("ORDER_DATE");
            layCommon.LayoutItems.Add("JUBSU_DATE");


            layCommon.QuerySQL = @"SELECT DISTINCT A.DRG_BUNHO 
                                    ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD') ORDER_DATE
                                    ,TO_CHAR(B.JUBSU_DATE,'YYYY/MM/DD') JUBSU_DATE
                                    FROM OCS1003 A, DRG2010 B
                                   WHERE A.FKOUT1001 = :f_pkout1001
                                  AND B.FKOCS1003 = A.PKOCS1003";

            layCommon.SetBindVarValue("f_pkout1001", this.pkout1001);

            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            if (layCommon.QueryLayout())
            {
                order_date = layCommon.GetItemValue("ORDER_DATE").ToString();
                bunho = layCommon.GetItemValue("DRG_BUNHO").ToString();
                inputList.Add("I_SYS_DATE", EnvironInfo.GetSysDate().ToShortDateString());
                inputList.Add("I_USER_ID", UserInfo.UserID);
                inputList.Add("I_ORDER_DATE", layCommon.GetItemValue("ORDER_DATE").ToString());
                inputList.Add("I_JUBSU_DATE", layCommon.GetItemValue("JUBSU_DATE").ToString());
                inputList.Add("I_DRG_BUNHO", layCommon.GetItemValue("DRG_BUNHO").ToString());
                inputList.Add("I_WONYOI_ORDER_YN", "N");
                inputList.Add("I_JUBSU_YN", "N");
                inputList.Add("I_GYUNBON_YN", "");

                // 처방 내용
                if (DsvOrderPrint(order_date, bunho))
                {
                    row = layOrderPrint.RowCount;
     //               dw1.FillData(layOrderPrint.LayoutTable);
                }
            }

  //          dw1.AcceptText();
  //          dw1.Print();

            if (!Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_OUT", inputList, outputList))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            
        }
        #endregion


        #region [-- DsvOrderPrint --]
        /// <summary>
        /// dsvOrderPrint Service Conversion PC:DRGWONNEA, WT:4 OUTPUT: layOrderPrint
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns></returns>
        private bool DsvOrderPrint(string jubsuDate, string drgBunho)
        {
            string o_bunho = string.Empty;
            string o_drg_bunho = string.Empty;
            string o_naewon_date = string.Empty;
            string o_group_ser = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_order_date = string.Empty;
            string o_jaeryo_code = string.Empty;
            string o_nalsu = string.Empty;
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
            string o_source_fkocs1003 = string.Empty;
            string o_fkocs1003 = string.Empty;
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
            string o_hope_nm = string.Empty;
            string o_powder_yn = string.Empty;
            string o_line = string.Empty;
            string o_serial_cnt = string.Empty;
            string o_kyukyeok = string.Empty;
            string o_licenes = string.Empty;
            string o_bunryu1 = string.Empty;
            string o_mix_group = string.Empty;
            string o_donbok = string.Empty;
            string o_tusuk = string.Empty;
            string o_bigo = string.Empty;
            string o_key = string.Empty;
            string o_text_color = string.Empty;

            string o_gubun_name = string.Empty;
            string o_johap = string.Empty;
            string o_gaein = string.Empty;
            string o_gaein_no = string.Empty;
            string o_bonin_gubun = string.Empty;
            string o_bon_rate = string.Empty;
            string o_budamja_bunho1 = string.Empty;
            string o_sugubja_bunho1 = string.Empty;
            string o_budamja_bunho2 = string.Empty;
            string o_sugubja_bunho2 = string.Empty;
            string o_sunwon_gubun = string.Empty;
            string o_noin_rate_name = string.Empty;
            string o_err = string.Empty;

            string o_changgo = string.Empty;
            string o_serial_text = string.Empty;
            string o_data_gubun = string.Empty;

            string o_mayak_license = string.Empty;
            string o_mayak_doctor = string.Empty;
            string o_mayak_address1 = string.Empty;
            string o_mayak_address2 = string.Empty;

            string o_jigan_date = string.Empty;
            string o_hubal_change_yn = string.Empty;
            string o_hubal_all_yn = string.Empty;

            string t_bogyong_name = string.Empty;
            string t_order_remark = string.Empty;
            int o_row = 0;

            string q_user_id = UserInfo.UserID;

            string cmdText = "";
            object retVal = null;
            int rowNum = 0;

            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            DataTable dtTables = new DataTable();
            DataTable dtSerial = new DataTable();
            DataTable dtRemark = new DataTable();

            int r_rec_cnt = 0;

            try
            {
                cmdText = @"SELECT MIN(FKOCS1003) FKOCS1003
                              FROM DRG2010 A
                             WHERE A.ORDER_DATE       = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO        = :f_drg_bunho
                               AND A.SOURCE_FKOCS1003 IS NULL
                               AND NVL(A.DC_YN,'N')           = 'N'
                               AND NVL(A.BANNAB_YN,'N')       = 'N'
                               AND A.JUNDAL_PART              = 'PA'";

                retVal = Service.ExecuteScalar(cmdText, bindVars);
                if (!TypeCheck.IsNull(retVal))
                {
                    o_fkocs1003 = retVal.ToString();
                }

                inputList.Add(o_fkocs1003);

                if (Service.ExecuteProcedure("PR_OUT_LOAD_CHEBANG_PRINT", inputList, outputList))
                {
                    o_gubun_name = outputList[0].ToString();
                    o_johap = outputList[1].ToString();
                    o_gaein = outputList[2].ToString();
                    o_gaein_no = outputList[3].ToString();
                    o_bonin_gubun = outputList[4].ToString();
                    o_bon_rate = outputList[5].ToString();
                    o_budamja_bunho1 = outputList[6].ToString();
                    o_sugubja_bunho1 = outputList[7].ToString();
                    o_budamja_bunho2 = outputList[8].ToString();
                    o_sugubja_bunho2 = outputList[9].ToString();
                    o_sunwon_gubun = outputList[10].ToString();
                    o_noin_rate_name = outputList[11].ToString();
                    o_err = outputList[12].ToString();
                }

                /* 마약정보 Load */
                inputList.Clear();
                outputList.Clear();
                inputList.Add("O");
                inputList.Add(jubsuDate);
                inputList.Add(drgBunho);

                if (Service.ExecuteProcedure("PR_DRG_LOAD_MAKAY_JUNGBO", inputList, outputList))
                {
                    o_mayak_doctor = outputList[0].ToString();
                    o_mayak_license = outputList[1].ToString();
                    o_mayak_address1 = outputList[2].ToString();
                    o_mayak_address2 = outputList[3].ToString();
                }

                /* DRGWONNEA_O_WN_CUR */
                cmdText = @"SELECT DISTINCT
                                   A.BUNHO                                                                        BUNHO
                                  ,LTRIM(TO_CHAR(A.DRG_BUNHO))                                                    DRG_BUNHO
                                  ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.NAEWON_DATE )                              NAEWON_DATE
                                  ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                                             JUBSU_DATE
                                  ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE)                                ORDER_DATE
                                  ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M')                             SERIAL_V
                                  ,E.SERIAL_V                                                                     SERIAL_TEXT
                                  ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                      GWA_NAME
                                  ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                DOCTOR_NAME
                                  ,F.SUNAME                                                                       SUNAME
                                  ,F.SUNAME2                                                                      SUNAME2
                                  ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH )                                    BIRTH
                                  ,F.SEX                                                                          SEX_AGE
                                  ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.NAEWON_DATE, A.GWA)                   OTHER_GWA
                                  ,FN_DRG_DO_ORDER(A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, 'O', A.DRG_BUNHO)     DO_ORDER    
                                  ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.NAEWON_DATE + 3 )                          GIGAM_DATE
                              FROM OUT0101 F
                                  ,DRG2030 E
                                  ,OCS1003 D
                                  ,INV0110 C
                                  ,DRG0120 B
                                  ,DRG2010 A
                             WHERE A.ORDER_DATE               = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO                = :f_drg_bunho
                               AND A.SOURCE_FKOCS1003         IS NULL
                               AND NVL(A.DC_YN,'N')           = 'N'
                               AND NVL(A.BANNAB_YN,'N')       = 'N'
                               AND NVL(A.WONYOI_ORDER_YN,'N') = 'N'
                               AND A.JUNDAL_PART   = 'PA'
                               AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                               AND C.JAERYO_CODE   (+)= A.JAERYO_CODE
                               AND D.PKOCS1003     = A.FKOCS1003
                               AND E.JUBSU_DATE    = A.ORDER_DATE
                               AND E.DRG_BUNHO     = A.DRG_BUNHO
                               AND E.FKOCS1003     = A.FKOCS1003
                               AND F.BUNHO         = A.BUNHO
                             ORDER BY 6";
                dtTables = Service.ExecuteDataTable(cmdText, bindVars);

                //mins 추가 아오!!!!
                int line_cnt = 0;
                line_cnt = dtTables.Rows.Count;

                for (int i = 0; i < dtTables.Rows.Count; i++)
                {
                    o_bunho = dtTables.Rows[i]["bunho"].ToString();
                    o_drg_bunho = dtTables.Rows[i]["drg_bunho"].ToString();
                    o_naewon_date = dtTables.Rows[i]["naewon_date"].ToString();
                    o_jubsu_date = dtTables.Rows[i]["jubsu_date"].ToString();
                    o_order_date = dtTables.Rows[i]["order_date"].ToString();
                    o_serial_v = dtTables.Rows[i]["serial_v"].ToString();
                    o_serial_text = dtTables.Rows[i]["serial_text"].ToString();
                    o_gwa_name = dtTables.Rows[i]["gwa_name"].ToString();
                    o_doctor_name = dtTables.Rows[i]["doctor_name"].ToString();
                    o_suname = dtTables.Rows[i]["suname"].ToString();
                    o_suname2 = dtTables.Rows[i]["suname2"].ToString();
                    o_birth = dtTables.Rows[i]["birth"].ToString();
                    o_age_sex = dtTables.Rows[i]["sex_age"].ToString();
                    o_other_gwa = dtTables.Rows[i]["other_gwa"].ToString();
                    o_do_order = dtTables.Rows[i]["do_order"].ToString();
                    o_jigan_date = dtTables.Rows[i]["gigam_date"].ToString();

                    bindVars.Remove("o_serial_text");
                    bindVars.Add("o_serial_text", o_serial_text);

                    /* DRG5100P01_WN_SERIAL_QRY */
                    // 이흥도 약 오더, 수불 단위 변경
                    cmdText = @"SELECT DISTINCT
                                       A.GROUP_SER                                                                                      GROUP_SER
                                      ,A.JAERYO_CODE                                                                                    JAERYO_CODE
                                      ,DECODE(A.BUNRYU1,'6',0,DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DV,A.NALSU))        NALSU
                                      ,A.DIVIDE                                                                                         DIVIDE
                                      ,A.ORD_SURYANG                                                                                    DRG_ORDER_SURYANG
                                      ,A.ORDER_SURYANG                                                                                  ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                                  DRG_ORDER_DANUI
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI)                                                SUBUL_DANUI
                                      ,A.GROUP_YN                                                                                       GROUP_YN
                                      ,A.JAERYO_GUBUN                                                                                   JAERYO_GUBUN
                                      ,A.BOGYONG_CODE                                                                                   BOGYONG_CODE
                                      ,TRIM(DECODE(A.BUNRYU1,'4', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O'),
                                                             '6', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O') ))
                                       ||' '|| TRIM(B.BOGYONG_NAME) || FN_DRG_LOAD_RP_TEXT('O', E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V)
                                       ||' '||FN_DRG_LOAD_DRG0120_PATTERN('O', A.FKOCS1003)                                             BOGYONG_NAME
                                      ,''                                                                                               CAUTION_NAME
                                      ,A.CAUTION_CODE                                                                                   CAUTION_CODE
                                      ,DECODE(A.MIX_GROUP,NULL,'N','Y')                                                                 MIX_YN
                                      ,E.ATC_YN                                                                                         ATC_YN
                                      ,A.DV                                                                                             DV
                                      ,A.DV_TIME                                                                                        DV_TIME
                                      ,A.DC_YN                                                                                          DC_YN
                                      ,A.BANNAB_YN                                                                                      BANNAB_YN
                                      ,A.SOURCE_FKOCS1003                                                                               SOURCE_FKOCS1003
                                      ,A.FKOCS1003                                                                                      FKOCS1003
                                      ,TO_CHAR(A.SUNAB_DATE,'YYYY/MM/DD')                                                               SUNAB_DATE
                                      ,B.PATTERN                                                                                        PATTERN
                                      ,C.JAERYO_NAME                                                                                    JAERYO_NAME
                                      ,NVL(A.SUNAB_NALSU,0)                                                                             SUNAB_NALSU
                                      ,NVL(A.WONYOI_ORDER_YN,'N')                                                                       WONYOI_YN
                                      ,TO_CHAR(A.ACT_DATE,'YYYY/MM/DD')                                                                 ACT_DATE
                                      ,A.BUNRYU2                                                                                        MAYAK
                                      ,A.TPN_JOJE_GUBUN                                                                                 TPN_JOJE_GUBUN
                                      ,NVL(C.MIX_YN_INP,'N')                                                                            UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                                  SUBUL_SURYANG
                                      ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M')                                               SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                                        GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                                  DOCTOR_NAME
                                      ,F.SUNAME                                                                                         SUNAME
                                      ,F.SUNAME2                                                                                        SUNAME2
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH )                                                      BIRTH
                                      ,F.SEX                                                                                            SEX_AGE
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.NAEWON_DATE, A.GWA)                                     OTHER_GWA
                                      ,FN_DRG_DO_ORDER(A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, 'O', A.DRG_BUNHO)                       DO_ORDER
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('5', D.HOPE_DATE )                                                  HOPE_DATE
                                      ,FN_DRG_POWDER_YN(E.JUBSU_DATE, E.DRG_BUNHO, 'O')                                                 POWDER_YN
                                      ,E.SERIAL_V                                                                                       LINE
                                      ,TRIM(C.KYUKYEOK)                                                                                 KYUKYEOK
                                      ,DECODE(FN_DRG_MAYAK_CHK(A.JUBSU_DATE, A.DRG_BUNHO, 'O'), 'Y',
                                              SUBSTRB(TRIM(FN_DRG_DOCTOR_LICENSE(A.DOCTOR, TRUNC(SYSDATE),'Y')),1,20))                  LICENSE
                                      ,A.MIX_GROUP                                                                                      MIX_GROUP
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                            DONBOK
                                      ,FN_AKU_LOAD_TUSUK_YOIL(A.BUNHO, A.ORDER_DATE)                                                    TUSUK
                                      ,FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ,'2')                          CAUTION_NM
                                      ,FN_OCS_LOAD_ORDER_SORT('O', D.INPUT_GUBUN, D.ORDER_GUBUN, D.GROUP_SER,
                                                                   D.MIX_GROUP,   D.SEQ,         D.PKOCS1003)                           ORDER_SORT
                                      ,C.TEXT_COLOR                                                                                     TEXT_COLOR
                                      ,C.CHANGGO1                                                                                       CHANGGO
                                      ,A.HUBAL_CHANGE_YN                                                                                HUBAL_CHANGE_YN
                                      ,FN_DRG_LOAD_HUBAL_ALL(A.ORDER_DATE, A.DRG_BUNHO)                                                 HUBAL_ALL_YN
                                  FROM OUT0101 F
                                      ,DRG2030 E
                                      ,OCS1003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG2010 A
                                 WHERE A.ORDER_DATE               = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.DRG_BUNHO                = :f_drg_bunho
                                   AND A.SOURCE_FKOCS1003         IS NULL
                                   AND NVL(A.DC_YN,'N')           = 'N'
                                   AND NVL(A.BANNAB_YN,'N')       = 'N'
                                   AND A.JUNDAL_PART              = 'PA'
                                   AND B.BOGYONG_CODE          (+)= A.BOGYONG_CODE
                                   AND C.JAERYO_CODE           (+)= A.JAERYO_CODE
                                   AND D.PKOCS1003                = A.FKOCS1003
                                   AND E.JUBSU_DATE               = A.ORDER_DATE
                                   AND E.DRG_BUNHO                = A.DRG_BUNHO
                                   AND E.FKOCS1003                = A.FKOCS1003
                                   AND E.SERIAL_V                 = :o_serial_text
                                   AND F.BUNHO                    = A.BUNHO
                                 ORDER BY E.SERIAL_V, A.MIX_GROUP, A.FKOCS1003";
                    dtSerial = Service.ExecuteDataTable(cmdText, bindVars);

                    //mins 추가 아오!!!
                    line_cnt += dtSerial.Rows.Count;

                    for (int j = 0; j < dtSerial.Rows.Count; j++)
                    {
                        o_group_ser = dtSerial.Rows[j]["group_ser"].ToString();
                        o_jaeryo_code = dtSerial.Rows[j]["jaeryo_code"].ToString();
                        o_nalsu = dtSerial.Rows[j]["nalsu"].ToString();
                        o_divide = dtSerial.Rows[j]["divide"].ToString();
                        o_ord_suryang = dtSerial.Rows[j]["drg_order_suryang"].ToString();
                        o_order_suryang = dtSerial.Rows[j]["order_suryang"].ToString();
                        o_order_danui = dtSerial.Rows[j]["drg_order_danui"].ToString();
                        o_subul_danui = dtSerial.Rows[j]["subul_danui"].ToString();
                        o_group_yn = dtSerial.Rows[j]["group_yn"].ToString();
                        o_jaeryo_gubun = dtSerial.Rows[j]["jaeryo_gubun"].ToString();
                        o_bogyong_code = dtSerial.Rows[j]["bogyong_code"].ToString();
                        o_bogyong_name = dtSerial.Rows[j]["bogyong_name"].ToString();
                        o_caution_name = dtSerial.Rows[j]["caution_name"].ToString();
                        o_caution_code = dtSerial.Rows[j]["caution_code"].ToString();
                        o_mix_yn = dtSerial.Rows[j]["mix_yn"].ToString();
                        o_atc_yn = dtSerial.Rows[j]["atc_yn"].ToString();
                        o_dv = dtSerial.Rows[j]["dv"].ToString();
                        o_dv_time = dtSerial.Rows[j]["dv_time"].ToString();
                        o_dc_yn = dtSerial.Rows[j]["dc_yn"].ToString();
                        o_bannab_yn = dtSerial.Rows[j]["bannab_yn"].ToString();
                        o_source_fkocs1003 = dtSerial.Rows[j]["source_fkocs1003"].ToString();
                        o_fkocs1003 = dtSerial.Rows[j]["fkocs1003"].ToString();
                        o_sunab_date = dtSerial.Rows[j]["sunab_date"].ToString();
                        o_pattern = dtSerial.Rows[j]["pattern"].ToString();
                        o_jaeryo_name = dtSerial.Rows[j]["jaeryo_name"].ToString();
                        o_sunab_nalsu = dtSerial.Rows[j]["sunab_nalsu"].ToString();
                        o_wonyoi_yn = dtSerial.Rows[j]["wonyoi_yn"].ToString();
                        o_act_date = dtSerial.Rows[j]["act_date"].ToString();
                        o_mayak = dtSerial.Rows[j]["mayak"].ToString();
                        o_tpn_joje_gubun = dtSerial.Rows[j]["tpn_joje_gubun"].ToString();
                        o_ui_jusa_yn = dtSerial.Rows[j]["ui_jusa_yn"].ToString();
                        o_subul_suryang = dtSerial.Rows[j]["subul_suryang"].ToString();
                        o_serial_v = dtSerial.Rows[j]["serial_v"].ToString();
                        o_gwa_name = dtSerial.Rows[j]["gwa_name"].ToString();
                        o_doctor_name = dtSerial.Rows[j]["doctor_name"].ToString();
                        o_suname = dtSerial.Rows[j]["suname"].ToString();
                        o_suname2 = dtSerial.Rows[j]["suname2"].ToString();
                        o_birth = dtSerial.Rows[j]["birth"].ToString();
                        o_age_sex = dtSerial.Rows[j]["sex_age"].ToString();
                        o_other_gwa = dtSerial.Rows[j]["other_gwa"].ToString();
                        o_do_order = dtSerial.Rows[j]["do_order"].ToString();
                        o_hope_nm = dtSerial.Rows[j]["hope_date"].ToString();
                        o_powder_yn = dtSerial.Rows[j]["powder_yn"].ToString();
                        o_serial_cnt = dtSerial.Rows[j]["line"].ToString();
                        o_kyukyeok = dtSerial.Rows[j]["kyukyeok"].ToString();
                        o_licenes = dtSerial.Rows[j]["license"].ToString();
                        o_mix_group = dtSerial.Rows[j]["mix_group"].ToString();
                        o_donbok = dtSerial.Rows[j]["donbok"].ToString();
                        o_tusuk = dtSerial.Rows[j]["tusuk"].ToString();
                        o_bigo = dtSerial.Rows[j]["caution_nm"].ToString();
                        o_key = dtSerial.Rows[j]["order_sort"].ToString();
                        o_text_color = dtSerial.Rows[j]["text_color"].ToString();
                        o_changgo = dtSerial.Rows[j]["changgo"].ToString();
                        o_hubal_change_yn = dtSerial.Rows[j]["hubal_change_yn"].ToString();
                        o_hubal_all_yn = dtSerial.Rows[j]["hubal_all_yn"].ToString();

                        /* layOrderPrint 에 로우 추가 */
                        rowNum = layOrderPrint.InsertRow(-1);
                        r_rec_cnt++;

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
                        layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs1003);
                        layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs1003);
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
                        layOrderPrint.SetItemValue(rowNum, "sex_age", o_age_sex);
                        layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                        layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                        layOrderPrint.SetItemValue(rowNum, "hope_nm", o_hope_nm);
                        layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                        layOrderPrint.SetItemValue(rowNum, "rowno", o_line);
                        layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                        layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                        layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                        layOrderPrint.SetItemValue(rowNum, "mix_group", o_mix_group);
                        layOrderPrint.SetItemValue(rowNum, "donbok_yn", o_donbok);
                        layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                        layOrderPrint.SetItemValue(rowNum, "bigo", o_bigo);
                        layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                        layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                        layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                        layOrderPrint.SetItemValue(rowNum, "johap", o_johap);
                        layOrderPrint.SetItemValue(rowNum, "gaein", o_gaein);
                        layOrderPrint.SetItemValue(rowNum, "gaein_no", o_gaein_no);
                        layOrderPrint.SetItemValue(rowNum, "bonin_gubun", o_bonin_gubun);
                        layOrderPrint.SetItemValue(rowNum, "bon_rate", o_bon_rate);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho1", o_budamja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho1", o_sugubja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho2", o_budamja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho2", o_sugubja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sunwon_gubun", o_sunwon_gubun);
                        layOrderPrint.SetItemValue(rowNum, "noin_rate_name", o_noin_rate_name);
                        layOrderPrint.SetItemValue(rowNum, "user_id", q_user_id);
                        layOrderPrint.SetItemValue(rowNum, "data_gubun", "A");
                        layOrderPrint.SetItemValue(rowNum, "mayak_license", o_mayak_license);
                        layOrderPrint.SetItemValue(rowNum, "mayak_doctor", o_mayak_doctor);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address1", o_mayak_address1);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address2", o_mayak_address2);
                        layOrderPrint.SetItemValue(rowNum, "gigan_date", o_jigan_date);
                        layOrderPrint.SetItemValue(rowNum, "hubal_change_yn", o_hubal_change_yn);
                        layOrderPrint.SetItemValue(rowNum, "hubal_all_yn", o_hubal_all_yn);
                    }


                    /********** modify kimminsoo ***************
                     * 이거 여기 왜 들어갔는지 이해 안감
                     * 약국 다시 첨부터 짜는게 속 편함
                     * *****************************************/
                    /* row insert */
                    bindVars.Remove("o_bogyong_name");
                    bindVars.Add("o_bogyong_name", JapanTextHelper.Half2Full(o_bogyong_name));
                    /* Insert Row 계산*/
                    o_row = 0;
                    cmdText = "SELECT TRUNC(length(NVL(:o_bogyong_name,' ')) / 60) CNT FROM DUAL";
                    retVal = Service.ExecuteScalar(cmdText, bindVars);
                    if (!TypeCheck.IsNull(retVal))
                    {
                        o_row = Convert.ToInt32(retVal);
                    }

                    for (int b = 0; b <= o_row; b++)
                    {
                        t_bogyong_name = string.Empty;
                        BindVarCollection bindName = new BindVarCollection();
                        bindName.Add("o_bogyong_name", JapanTextHelper.Half2Full(o_bogyong_name));
                        bindName.Add("b", b.ToString());
                        cmdText = "SELECT SUBSTR(:o_bogyong_name, (:b * 60) + 1, 60) FROM DUAL";
                        retVal = Service.ExecuteScalar(cmdText, bindName);
                        if (!TypeCheck.IsNull(retVal))
                        {
                            t_bogyong_name = retVal.ToString();
                        }

                        /* layOrderPrint 에 로우 추가 */
                        rowNum = layOrderPrint.InsertRow(-1);
                        r_rec_cnt++;

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
                        layOrderPrint.SetItemValue(rowNum, "bogyong_name", t_bogyong_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_name", o_caution_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_code", o_caution_code);
                        layOrderPrint.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                        layOrderPrint.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                        layOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                        layOrderPrint.SetItemValue(rowNum, "dv_time", o_dv_time);
                        layOrderPrint.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                        layOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                        layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs1003);
                        layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs1003);
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
                        layOrderPrint.SetItemValue(rowNum, "sex_age", o_age_sex);
                        layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                        layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                        layOrderPrint.SetItemValue(rowNum, "hope_nm", o_hope_nm);
                        layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                        layOrderPrint.SetItemValue(rowNum, "rowno", o_line);
                        layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                        layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                        layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                        layOrderPrint.SetItemValue(rowNum, "mix_group", o_mix_group);
                        layOrderPrint.SetItemValue(rowNum, "donbok_yn", o_donbok);
                        layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                        layOrderPrint.SetItemValue(rowNum, "bigo", o_bigo);
                        layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                        layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                        layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                        layOrderPrint.SetItemValue(rowNum, "johap", o_johap);
                        layOrderPrint.SetItemValue(rowNum, "gaein", o_gaein);
                        layOrderPrint.SetItemValue(rowNum, "gaein_no", o_gaein_no);
                        layOrderPrint.SetItemValue(rowNum, "bonin_gubun", o_bonin_gubun);
                        layOrderPrint.SetItemValue(rowNum, "bon_rate", o_bon_rate);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho1", o_budamja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho1", o_sugubja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho2", o_budamja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho2", o_sugubja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sunwon_gubun", o_sunwon_gubun);
                        layOrderPrint.SetItemValue(rowNum, "noin_rate_name", o_noin_rate_name);
                        layOrderPrint.SetItemValue(rowNum, "user_id", q_user_id);
                        layOrderPrint.SetItemValue(rowNum, "data_gubun", "B");
                        layOrderPrint.SetItemValue(rowNum, "mayak_license", o_mayak_license);
                        layOrderPrint.SetItemValue(rowNum, "mayak_doctor", o_mayak_doctor);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address1", o_mayak_address1);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address2", o_mayak_address2);
                        layOrderPrint.SetItemValue(rowNum, "gigan_date", o_jigan_date);
                        layOrderPrint.SetItemValue(rowNum, "hubal_change_yn", o_hubal_change_yn);
                        layOrderPrint.SetItemValue(rowNum, "hubal_all_yn", o_hubal_all_yn);
                    }
                    /********** modify kimminsoo ***************
                     * 이거 여기 왜 들어갔는지 이해 안감
                     * 약국 다시 첨부터 짜는게 속 편함
                     * *****************************************/

                    /* DRGWONNEA_WN_REMARK_QRY */
                    // 이흥도 오더, 수불단위 변경
                    #region 약 처방전에서 주사 콘멘트 안나오게..
#if USE_JUSA_COMMEND
                    cmdText = @"SELECT DISTINCT
                                       A.GROUP_SER                                                                                    GROUP_SER
                                      ,A.JAERYO_CODE                                                                                  JAERYO_CODE
                                      ,DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DV,A.NALSU)                              NALSU
                                      ,A.DIVIDE                                                                                       DIVIDE
                                      ,A.ORD_SURYANG                                                                                  DRG_ORDER_SURYANG
                                      ,A.ORDER_SURYANG                                                                                ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                                DRG_ORDER_DANUI
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI',  A.SUBUL_DANUI )                                            SUBUL_DANUI
                                      ,A.GROUP_YN                                                                                     GROUP_YN
                                      ,A.JAERYO_GUBUN                                                                                 JAERYO_GUBUN
                                      ,A.BOGYONG_CODE                                                                                 BOGYONG_CODE
                                      ,TRIM(DECODE(A.BUNRYU1,'4', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O'),
                                                             '6', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O') ))
                                       ||' '|| TRIM(B.BOGYONG_NAME) ||' '||FN_DRG_LOAD_DRG0120_PATTERN('O', A.FKOCS1003)              BOGYONG_NAME
                                      ,''                                                                                             CAUTION_NAME
                                      ,A.CAUTION_CODE                                                                                 CAUTION_CODE
                                      ,DECODE(A.MIX_GROUP,NULL,'N','Y')                                                               MIX_YN
                                      ,E.ATC_YN                                                                                       ATC_YN
                                      ,A.DV                                                                                           DV
                                      ,A.DV_TIME                                                                                      DV_TIME
                                      ,A.DC_YN                                                                                        DC_YN
                                      ,A.BANNAB_YN                                                                                    BANNAB_YN
                                      ,A.SOURCE_FKOCS1003                                                                             SOURCE_FKOCS1003
                                      ,A.FKOCS1003                                                                                    FKOCS1003
                                      ,TO_CHAR(A.SUNAB_DATE,'YYYY/MM/DD')                                                             SUNAB_DATE
                                      ,B.PATTERN                                                                                      PATTERN
                                      ,C.JAERYO_NAME                                                                                  JAERYO_NAME
                                      ,NVL(A.SUNAB_NALSU,0)                                                                           SUNAB_NALSU
                                      ,NVL(A.WONYOI_ORDER_YN,'N')                                                                     WONYOI_YN
                                      ,C.JAERYO_NAME || ' : '|| TRIM(DECODE(A.BUNRYU1,'6','', D.ORDER_REMARK||' ')
                                       || FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA_GUBUN))                                                ORDER_REMARK
                                      ,TO_CHAR(A.ACT_DATE,'YYYY/MM/DD')                                                               ACT_DATE
                                      ,A.BUNRYU2                                                                                      MAYAK
                                      ,A.TPN_JOJE_GUBUN                                                                               TPN_JOJE_GUBUN
                                      ,NVL(C.MIX_YN_INP,'N')                                                                          UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                                SUBUL_SURYANG
                                      ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M')                                             SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                                      GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                                DOCTOR_NAME
                                      ,F.SUNAME                                                                                       SUNAME
                                      ,F.SUNAME2                                                                                      SUNAME2
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH )                                                    BIRTH
                                      ,F.SEX                                                                                          SEX_AGE
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.NAEWON_DATE, A.GWA)                                   OTHER_GWA
                                      ,FN_DRG_DO_ORDER(A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, 'O', A.DRG_BUNHO)                     DO_ORDER
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('5', D.HOPE_DATE )                                                HOPE_DATE
                                      ,FN_DRG_POWDER_YN(E.JUBSU_DATE, E.DRG_BUNHO, 'O')                                               POWDER_YN
                                      ,E.SERIAL_V                                                                                     LINE
                                      ,TRIM(C.KYUKYEOK)                                                                               KYUKYEOK
                                      ,DECODE(FN_DRG_MAYAK_CHK(A.JUBSU_DATE, A.DRG_BUNHO, 'O'), 'Y',
                                              SUBSTRB(TRIM(FN_DRG_DOCTOR_LICENSE(A.DOCTOR, TRUNC(SYSDATE),'Y')),1,20))                LICENSE
                                      ,A.MIX_GROUP                                                                                    MIX_GROUP
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                          DONBOK
                                      ,FN_AKU_LOAD_TUSUK_YOIL(A.BUNHO, A.ORDER_DATE)                                                  TUSUK
                                      ,FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ,'2')                        CAUTION_NM
                                      ,FN_OCS_LOAD_ORDER_SORT('O', D.INPUT_GUBUN, D.ORDER_GUBUN, D.GROUP_SER,
                                                                   D.MIX_GROUP,   D.SEQ,         D.PKOCS1003)                         ORDER_SORT
                                      ,C.TEXT_COLOR                                                                                   TEXT_COLOR
                                      ,C.CHANGGO1                                                                                     CHANGGO
                                      ,A.HUBAL_CHANGE_YN                                                                              HUBAL_CHANGE_YN
                                      ,FN_DRG_LOAD_HUBAL_ALL(A.ORDER_DATE, A.DRG_BUNHO)                                               HUBAL_ALL_YN
                                      ,'C' DATA_GUBUN
                                  FROM OUT0101 F
                                      ,DRG2030 E
                                      ,OCS1003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG2010 A
                                 WHERE A.ORDER_DATE               = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.DRG_BUNHO                = :f_drg_bunho
                                   AND A.SOURCE_FKOCS1003         IS NULL
                                   AND NVL(A.DC_YN,'N')           = 'N'
                                   AND NVL(A.BANNAB_YN,'N')       = 'N'
                                   AND A.JUNDAL_PART              = 'PA'
                                   AND B.BOGYONG_CODE          (+)= A.BOGYONG_CODE
                                   AND C.JAERYO_CODE           (+)= A.JAERYO_CODE
                                   AND D.PKOCS1003                = A.FKOCS1003
                                   AND TRIM(DECODE(A.BUNRYU1,'6','', D.ORDER_REMARK||' ')|| FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA_GUBUN))|| FN_DRG_LOAD_DRG0120_PATTERN('O', A.FKOCS1003) IS NOT NULL
                                   AND E.JUBSU_DATE               = A.ORDER_DATE
                                   AND E.DRG_BUNHO                = A.DRG_BUNHO
                                   AND E.FKOCS1003                = A.FKOCS1003
                                   AND E.SERIAL_V                 = :o_serial_text
                                   AND F.BUNHO                    = A.BUNHO
                                 ORDER BY 45, 48, 22";

                    //                                 UNION ALL
                    //                                SELECT DISTINCT
                    //                                       A.GROUP_SER                                                                                    GROUP_SER
                    //                                      ,A.JAERYO_CODE                                                                                  JAERYO_CODE
                    //                                      ,DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DV,A.NALSU)                              NALSU
                    //                                      ,A.DIVIDE                                                                                       DIVIDE
                    //                                      ,A.ORD_SURYANG                                                                                  DRG_ORDER_SURYANG
                    //                                      ,A.ORDER_SURYANG                                                                                ORDER_SURYANG
                    //                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                                DRG_ORDER_DANUI
                    //                                      ,A.SUBUL_DANUI                                                                                  SUBUL_DANUI
                    //                                      ,A.GROUP_YN                                                                                     GROUP_YN
                    //                                      ,A.JAERYO_GUBUN                                                                                 JAERYO_GUBUN
                    //                                      ,A.BOGYONG_CODE                                                                                 BOGYONG_CODE
                    //                                      ,TRIM(DECODE(A.BUNRYU1,'4', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O'),
                    //                                                             '6', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O') ))
                    //                                       ||' '|| TRIM(B.BOGYONG_NAME) ||' '||FN_DRG_LOAD_DRG0120_PATTERN('O', A.FKOCS1003)              BOGYONG_NAME
                    //                                      ,''                                                                                             CAUTION_NAME
                    //                                      ,A.CAUTION_CODE                                                                                 CAUTION_CODE
                    //                                      ,A.MIX_YN                                                                                       MIX_YN
                    //                                      ,E.ATC_YN                                                                                       ATC_YN
                    //                                      ,A.DV                                                                                           DV
                    //                                      ,A.DV_TIME                                                                                      DV_TIME
                    //                                      ,A.DC_YN                                                                                        DC_YN
                    //                                      ,A.BANNAB_YN                                                                                    BANNAB_YN
                    //                                      ,A.SOURCE_FKOCS1003                                                                             SOURCE_FKOCS1003
                    //                                      ,A.FKOCS1003                                                                                    FKOCS1003
                    //                                      ,TO_CHAR(A.SUNAB_DATE,'YYYY/MM/DD')                                                             SUNAB_DATE
                    //                                      ,B.PATTERN                                                                                      PATTERN
                    //                                      ,C.JAERYO_NAME                                                                                  JAERYO_NAME
                    //                                      ,NVL(A.SUNAB_NALSU,0)                                                                           SUNAB_NALSU
                    //                                      ,NVL(A.WONYOI_ORDER_YN,'N')                                                                     WONYOI_YN
                    //                                      ,''                                                                                             ORDER_REMARK
                    //                                      ,TO_CHAR(A.ACT_DATE,'YYYY/MM/DD')                                                               ACT_DATE
                    //                                      ,A.BUNRYU2                                                                                      MAYAK
                    //                                      ,A.TPN_JOJE_GUBUN                                                                               TPN_JOJE_GUBUN
                    //                                      ,NVL(C.MIX_YN_INP,'N')                                                                          UI_JUSA_YN
                    //                                      ,A.SUBUL_SURYANG                                                                                SUBUL_SURYANG
                    //                                      ,'Rp.'||E.SERIAL_V                                                                              SERIAL_V
                    //                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                                      GWA_NAME
                    //                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                                DOCTOR_NAME
                    //                                      ,F.SUNAME                                                                                       SUNAME
                    //                                      ,F.SUNAME2                                                                                      SUNAME2
                    //                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH )                                                    BIRTH
                    //                                      ,F.SEX                                                                                          SEX_AGE
                    //                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.NAEWON_DATE, A.GWA)                                   OTHER_GWA
                    //                                      ,FN_DRG_DO_ORDER(A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, 'O', A.DRG_BUNHO)                     DO_ORDER
                    //                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('5', D.HOPE_DATE )                                                HOPE_DATE
                    //                                      ,FN_DRG_POWDER_YN(E.JUBSU_DATE, E.DRG_BUNHO, 'O')                                               POWDER_YN
                    //                                      ,E.SERIAL_V                                                                                     LINE
                    //                                      ,TRIM(C.KYUKYEOK)                                                                               KYUKYEOK
                    //                                      ,DECODE(FN_DRG_MAYAK_CHK(A.JUBSU_DATE, A.DRG_BUNHO, 'O'), 'Y',
                    //                                              SUBSTRB(TRIM(FN_DRG_DOCTOR_LICENSE(A.DOCTOR, TRUNC(SYSDATE),'Y')),1,20))                LICENSE
                    //                                      ,A.MIX_GROUP                                                                                    MIX_GROUP
                    //                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                          DONBOK
                    //                                      ,FN_AKU_LOAD_TUSUK_YOIL(A.BUNHO, A.ORDER_DATE)                                                  TUSUK
                    //                                      ,FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ,'2')                        CAUTION_NM
                    //                                      ,FN_OCS_LOAD_ORDER_SORT('O', D.INPUT_GUBUN, D.ORDER_GUBUN, D.GROUP_SER,
                    //                                                                   D.MIX_GROUP,   D.SEQ,         D.PKOCS1003)                         ORDER_SORT
                    //                                      ,C.TEXT_COLOR                                                                                   TEXT_COLOR
                    //                                      ,C.CHANGGO1                                                                                     CHANGGO
                    //                                      ,A.HUBAL_CHANGE_YN                                                                              HUBAL_CHANGE_YN
                    //                                      ,FN_DRG_LOAD_HUBAL_ALL(A.ORDER_DATE, A.DRG_BUNHO)                                               HUBAL_ALL_YN
                    //                                      ,'X' DATA_GUBUN
                    //                                  FROM OUT0101 F
                    //                                      ,DRG2030 E
                    //                                      ,OCS1003 D
                    //                                      ,INV0110 C
                    //                                      ,DRG0120 B
                    //                                      ,DRG2010 A
                    //                                 WHERE A.ORDER_DATE               = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                    //                                   AND A.DRG_BUNHO                = :f_drg_bunho
                    //                                   AND A.SOURCE_FKOCS1003         IS NULL
                    //                                   AND NVL(A.DC_YN,'N')           = 'N'
                    //                                   AND NVL(A.BANNAB_YN,'N')       = 'N'
                    //                                   AND A.JUNDAL_PART              = 'PA'
                    //                                   AND B.BOGYONG_CODE          (+)= A.BOGYONG_CODE
                    //                                   AND C.JAERYO_CODE           (+)= A.JAERYO_CODE
                    //                                   AND D.PKOCS1003                = A.FKOCS1003
                    //                                   AND E.SERIAL_V                 = (SELECT MAX(SERIAL_V) FROM DRG2030 WHERE JUBSU_DATE = A.ORDER_DATE AND DRG_BUNHO = A.DRG_BUNHO)
                    //                                   AND E.JUBSU_DATE               = A.ORDER_DATE
                    //                                   AND E.DRG_BUNHO                = A.DRG_BUNHO
                    //                                   AND E.FKOCS1003                = A.FKOCS1003
                    //                                   AND F.BUNHO                    = A.BUNHO
                    dtRemark = Service.ExecuteDataTable(cmdText, bindVars);

                    //mins 추가 아오!!!
                    line_cnt += dtRemark.Rows.Count;

                    for (int k = 0; k < dtRemark.Rows.Count; k++)
                    {
                        o_group_ser = dtRemark.Rows[k]["group_ser"].ToString();
                        o_jaeryo_code = dtRemark.Rows[k]["jaeryo_code"].ToString();
                        o_nalsu = dtRemark.Rows[k]["nalsu"].ToString();
                        o_divide = dtRemark.Rows[k]["divide"].ToString();
                        o_ord_suryang = dtRemark.Rows[k]["drg_order_suryang"].ToString();
                        o_order_suryang = dtRemark.Rows[k]["order_suryang"].ToString();
                        o_order_danui = dtRemark.Rows[k]["drg_order_danui"].ToString();
                        o_subul_danui = dtRemark.Rows[k]["subul_danui"].ToString();
                        o_group_yn = dtRemark.Rows[k]["group_yn"].ToString();
                        o_jaeryo_gubun = dtRemark.Rows[k]["jaeryo_gubun"].ToString();
                        o_bogyong_code = dtRemark.Rows[k]["bogyong_code"].ToString();
                        o_bogyong_name = dtRemark.Rows[k]["bogyong_name"].ToString();
                        o_caution_name = dtRemark.Rows[k]["caution_name"].ToString();
                        o_caution_code = dtRemark.Rows[k]["caution_code"].ToString();
                        o_mix_yn = dtRemark.Rows[k]["mix_yn"].ToString();
                        o_atc_yn = dtRemark.Rows[k]["atc_yn"].ToString();
                        o_dv = dtRemark.Rows[k]["dv"].ToString();
                        o_dv_time = dtRemark.Rows[k]["dv_time"].ToString();
                        o_dc_yn = dtRemark.Rows[k]["dc_yn"].ToString();
                        o_bannab_yn = dtRemark.Rows[k]["bannab_yn"].ToString();
                        o_source_fkocs1003 = dtRemark.Rows[k]["source_fkocs1003"].ToString();
                        o_fkocs1003 = dtRemark.Rows[k]["fkocs1003"].ToString();
                        o_sunab_date = dtRemark.Rows[k]["sunab_date"].ToString();
                        o_pattern = dtRemark.Rows[k]["pattern"].ToString();
                        o_jaeryo_name = dtRemark.Rows[k]["jaeryo_name"].ToString();
                        o_sunab_nalsu = dtRemark.Rows[k]["sunab_nalsu"].ToString();
                        o_wonyoi_yn = dtRemark.Rows[k]["wonyoi_yn"].ToString();
                        o_order_remark = dtRemark.Rows[k]["order_remark"].ToString();
                        o_act_date = dtRemark.Rows[k]["act_date"].ToString();
                        o_mayak = dtRemark.Rows[k]["mayak"].ToString();
                        o_tpn_joje_gubun = dtRemark.Rows[k]["tpn_joje_gubun"].ToString();
                        o_ui_jusa_yn = dtRemark.Rows[k]["ui_jusa_yn"].ToString();
                        o_subul_suryang = dtRemark.Rows[k]["subul_suryang"].ToString();
                        o_serial_v = dtRemark.Rows[k]["serial_v"].ToString();
                        o_gwa_name = dtRemark.Rows[k]["gwa_name"].ToString();
                        o_doctor_name = dtRemark.Rows[k]["doctor_name"].ToString();
                        o_suname = dtRemark.Rows[k]["suname"].ToString();
                        o_suname2 = dtRemark.Rows[k]["suname2"].ToString();
                        o_birth = dtRemark.Rows[k]["birth"].ToString();
                        o_age_sex = dtRemark.Rows[k]["sex_age"].ToString();
                        o_other_gwa = dtRemark.Rows[k]["other_gwa"].ToString();
                        o_do_order = dtRemark.Rows[k]["do_order"].ToString();
                        o_hope_nm = dtRemark.Rows[k]["hope_date"].ToString();
                        o_powder_yn = dtRemark.Rows[k]["powder_yn"].ToString();
                        o_serial_cnt = dtRemark.Rows[k]["line"].ToString();
                        o_kyukyeok = dtRemark.Rows[k]["kyukyeok"].ToString();
                        o_licenes = dtRemark.Rows[k]["license"].ToString();
                        o_mix_group = dtRemark.Rows[k]["mix_group"].ToString();
                        o_donbok = dtRemark.Rows[k]["donbok"].ToString();
                        o_tusuk = dtRemark.Rows[k]["tusuk"].ToString();
                        o_bigo = dtRemark.Rows[k]["caution_nm"].ToString();
                        o_key = dtRemark.Rows[k]["order_sort"].ToString();
                        o_text_color = dtRemark.Rows[k]["text_color"].ToString();
                        o_changgo = dtRemark.Rows[k]["changgo"].ToString();
                        o_hubal_change_yn = dtRemark.Rows[k]["hubal_change_yn"].ToString();
                        o_hubal_all_yn = dtRemark.Rows[k]["hubal_all_yn"].ToString();
                        o_data_gubun = dtRemark.Rows[k]["data_gubun"].ToString();

                        /* layOrderPrint 에 새로운 로우 추가 */
                        rowNum = layOrderPrint.InsertRow(-1);
                        r_rec_cnt++;

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
                        layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs1003);
                        layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs1003);
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
                        layOrderPrint.SetItemValue(rowNum, "serial_v", "Comment");
                        layOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                        layOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                        layOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                        layOrderPrint.SetItemValue(rowNum, "sex_age", o_age_sex);
                        layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                        layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                        layOrderPrint.SetItemValue(rowNum, "hope_nm", o_hope_nm);
                        layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                        layOrderPrint.SetItemValue(rowNum, "rowno", o_line);
                        layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                        layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                        layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                        layOrderPrint.SetItemValue(rowNum, "mix_group", o_mix_group);
                        layOrderPrint.SetItemValue(rowNum, "donbok_yn", o_donbok);
                        layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                        layOrderPrint.SetItemValue(rowNum, "bigo", o_bigo);
                        layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                        layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                        layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                        layOrderPrint.SetItemValue(rowNum, "johap", o_johap);
                        layOrderPrint.SetItemValue(rowNum, "gaein", o_gaein);
                        layOrderPrint.SetItemValue(rowNum, "gaein_no", o_gaein_no);
                        layOrderPrint.SetItemValue(rowNum, "bonin_gubun", o_bonin_gubun);
                        layOrderPrint.SetItemValue(rowNum, "bon_rate", o_bon_rate);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho1", o_budamja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho1", o_sugubja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho2", o_budamja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho2", o_sugubja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sunwon_gubun", o_sunwon_gubun);
                        layOrderPrint.SetItemValue(rowNum, "noin_rate_name", o_noin_rate_name);
                        layOrderPrint.SetItemValue(rowNum, "user_id", q_user_id);
                        layOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                        layOrderPrint.SetItemValue(rowNum, "mayak_license", o_mayak_license);
                        layOrderPrint.SetItemValue(rowNum, "mayak_doctor", o_mayak_doctor);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address1", o_mayak_address1);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address2", o_mayak_address2);
                        layOrderPrint.SetItemValue(rowNum, "gigan_date", o_jigan_date);
                        layOrderPrint.SetItemValue(rowNum, "hubal_change_yn", o_hubal_change_yn);
                        layOrderPrint.SetItemValue(rowNum, "hubal_all_yn", o_hubal_all_yn);

                        /* 커멘트 개행 */
                        if (o_data_gubun == "C")
                        {
                            BindVarCollection bindGubun = new BindVarCollection();
                            bindGubun.Add("o_order_remark", JapanTextHelper.Half2Full(o_order_remark));
                            cmdText = "SELECT TRUNC(length(NVL(:o_order_remark,' ')) / 102)  CNT FROM DUAL";
                            retVal = Service.ExecuteScalar(cmdText, bindGubun);
                            o_row = 0;
                            if (!TypeCheck.IsNull(retVal))
                            {
                                o_row = Convert.ToInt32(retVal);
                                for (int b = 1; b <= o_row; b++)
                                {
                                    cmdText = "SELECT SUBSTR(:o_order_remark, (:b * 102) + 1, 102) FROM DUAL";
                                    bindGubun.Clear();
                                    bindGubun.Add("o_order_remark", JapanTextHelper.Half2Full(o_order_remark));
                                    bindGubun.Add("b", b.ToString());
                                    retVal = Service.ExecuteScalar(cmdText, bindGubun);
                                    if (!TypeCheck.IsNull(retVal))
                                    {
                                        t_order_remark = retVal.ToString();
                                    }

                                    /* row 추가 */
                                    rowNum = layOrderPrint.InsertRow(-1);

                                    r_rec_cnt++;

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
                                    layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs1003);
                                    layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs1003);
                                    layOrderPrint.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                                    layOrderPrint.SetItemValue(rowNum, "pattern", o_pattern);
                                    layOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                                    layOrderPrint.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                                    layOrderPrint.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                                    layOrderPrint.SetItemValue(rowNum, "order_remark", t_order_remark);
                                    layOrderPrint.SetItemValue(rowNum, "act_date", o_act_date);
                                    layOrderPrint.SetItemValue(rowNum, "mayak", o_mayak);
                                    layOrderPrint.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                                    layOrderPrint.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                                    layOrderPrint.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                                    layOrderPrint.SetItemValue(rowNum, "serial_v", "Comment");
                                    layOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                                    layOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                                    layOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                                    layOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                                    layOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                                    layOrderPrint.SetItemValue(rowNum, "sex_age", o_age_sex);
                                    layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                                    layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                                    layOrderPrint.SetItemValue(rowNum, "hope_nm", o_hope_nm);
                                    layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                                    layOrderPrint.SetItemValue(rowNum, "rowno", o_line);
                                    layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                                    layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                                    layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                                    layOrderPrint.SetItemValue(rowNum, "mix_group", o_mix_group);
                                    layOrderPrint.SetItemValue(rowNum, "donbok_yn", o_donbok);
                                    layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                                    layOrderPrint.SetItemValue(rowNum, "bigo", o_bigo);
                                    layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                                    layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                                    layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                                    layOrderPrint.SetItemValue(rowNum, "johap", o_johap);
                                    layOrderPrint.SetItemValue(rowNum, "gaein", o_gaein);
                                    layOrderPrint.SetItemValue(rowNum, "gaein_no", o_gaein_no);
                                    layOrderPrint.SetItemValue(rowNum, "bonin_gubun", o_bonin_gubun);
                                    layOrderPrint.SetItemValue(rowNum, "bon_rate", o_bon_rate);
                                    layOrderPrint.SetItemValue(rowNum, "budamja_bunho1", o_budamja_bunho1);
                                    layOrderPrint.SetItemValue(rowNum, "sugubja_bunho1", o_sugubja_bunho1);
                                    layOrderPrint.SetItemValue(rowNum, "budamja_bunho2", o_budamja_bunho2);
                                    layOrderPrint.SetItemValue(rowNum, "sugubja_bunho2", o_sugubja_bunho2);
                                    layOrderPrint.SetItemValue(rowNum, "sunwon_gubun", o_sunwon_gubun);
                                    layOrderPrint.SetItemValue(rowNum, "noin_rate_name", o_noin_rate_name);
                                    layOrderPrint.SetItemValue(rowNum, "user_id", q_user_id);
                                    layOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                                    layOrderPrint.SetItemValue(rowNum, "mayak_license", o_mayak_license);
                                    layOrderPrint.SetItemValue(rowNum, "mayak_doctor", o_mayak_doctor);
                                    layOrderPrint.SetItemValue(rowNum, "mayak_address1", o_mayak_address1);
                                    layOrderPrint.SetItemValue(rowNum, "mayak_address2", o_mayak_address2);
                                    layOrderPrint.SetItemValue(rowNum, "gigan_date", o_jigan_date);
                                    layOrderPrint.SetItemValue(rowNum, "hubal_change_yn", o_hubal_change_yn);
                                    layOrderPrint.SetItemValue(rowNum, "hubal_all_yn", o_hubal_all_yn);
                                }
                            }
                        }
                    }
                    /* DRGWONNEA_WN_REMARK_QRY */
#endif
                    #endregion
                }

                

                /* DRGWONNEA_O_WN_CUR */
                //bindVars.Clear();
                /************ MINS 수정 ***********
                 * 이것도 지금 이런식으로 하면 안됨.. 에혀.. 진짜!!
                 ***********************************/
                //bindVars.Add("r_rec_cnt", r_rec_cnt.ToString());
                //bindVars.Add("r_rec_cnt", line_cnt.ToString());

                /************ MINS 수정 ***********
                 * 16라인 기준인데 안맞음.. 멀 기준으로 한건지?
                 ***********************************/
                //bindVars.Add("RowCnt", "16");
                //bindVars.Add("RowCnt", "19");
                //cmdText = @"SELECT DECODE(:RowCnt - mod(:r_rec_cnt, :RowCnt)
                //                                         ,:RowCnt, 0 + TRUNC(:r_rec_cnt / :RowCnt)
                //                                         ,:RowCnt - mod(:r_rec_cnt, :RowCnt) + TRUNC(:r_rec_cnt / :RowCnt) ) CNT
                //                              FROM DUAL";
                //retVal = Service.ExecuteScalar(cmdText, bindVars);
                //int insertRow = 0;
                //if (!TypeCheck.IsNull(retVal))
                //{
                //    insertRow = int.Parse(retVal.ToString());
                //}

                int default_line_cnt = 17;
                int order_line_cnt = line_cnt;
                int blank_cnt = 0;

                if ((order_line_cnt % default_line_cnt) == 0) blank_cnt = 0;
                else
                    blank_cnt = default_line_cnt - (order_line_cnt % default_line_cnt);
                int blankRow = 0;

                Service.debugFileWrite("ttttt ---> " + blank_cnt.ToString());
                for (int k = 1; k <= blank_cnt; k++)
                {
                    /************ MINS 수정 ***********
                    * 무엇을 위한 공백 추가인지? 한참 찾았음.. 
                    * 이상해서 수정함..
                    * 또 이상해서 또 수정함.. ㅉㅉ
                    ***********************************/
                    blankRow = layOrderPrint.InsertRow(-1);
                    layOrderPrint.SetItemValue(blankRow, "bunho", "");
                    layOrderPrint.SetItemValue(blankRow, "drg_bunho", "");
                    layOrderPrint.SetItemValue(blankRow, "naewon_date", "");
                    layOrderPrint.SetItemValue(blankRow, "group_ser", "");
                    layOrderPrint.SetItemValue(blankRow, "jubsu_date", "");
                    layOrderPrint.SetItemValue(blankRow, "order_date", "");
                    layOrderPrint.SetItemValue(blankRow, "jaeryo_code", "");
                    layOrderPrint.SetItemValue(blankRow, "nalsu", "");
                    layOrderPrint.SetItemValue(blankRow, "divide", "");
                    layOrderPrint.SetItemValue(blankRow, "ord_surang", "");
                    layOrderPrint.SetItemValue(blankRow, "order_suryang", "");
                    layOrderPrint.SetItemValue(blankRow, "order_danui", "");
                    layOrderPrint.SetItemValue(blankRow, "subul_danui", "");
                    layOrderPrint.SetItemValue(blankRow, "group_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "jaeryo_gubun", "");
                    layOrderPrint.SetItemValue(blankRow, "bogyong_code", "");
                    layOrderPrint.SetItemValue(blankRow, "bogyong_name", "");
                    layOrderPrint.SetItemValue(blankRow, "caution_name", "");
                    layOrderPrint.SetItemValue(blankRow, "caution_code", "");
                    layOrderPrint.SetItemValue(blankRow, "mix_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "atc_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "dv", "");
                    layOrderPrint.SetItemValue(blankRow, "dv_time", "");
                    layOrderPrint.SetItemValue(blankRow, "dc_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "bannab_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "source_fkocs1003", "");
                    layOrderPrint.SetItemValue(blankRow, "fkocs1003", "");
                    layOrderPrint.SetItemValue(blankRow, "sunab_date", "");
                    layOrderPrint.SetItemValue(blankRow, "pattern", "");
                    if (k == 1) layOrderPrint.SetItemValue(blankRow, "jaeryo_name", "ZZ");
                    else layOrderPrint.SetItemValue(blankRow, "jaeryo_name", "");
                    layOrderPrint.SetItemValue(blankRow, "sunab_nalsu", "");
                    layOrderPrint.SetItemValue(blankRow, "wonyoi_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "order_remark", "");
                    layOrderPrint.SetItemValue(blankRow, "act_date", "");
                    layOrderPrint.SetItemValue(blankRow, "mayak", "");
                    layOrderPrint.SetItemValue(blankRow, "tpn_joje_gubun", "");
                    layOrderPrint.SetItemValue(blankRow, "ui_jusa_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "subul_suryang", "");
                    layOrderPrint.SetItemValue(blankRow, "serial_v", "ZZ");
                    layOrderPrint.SetItemValue(blankRow, "gwa_name", "");
                    layOrderPrint.SetItemValue(blankRow, "doctor_name", "");
                    layOrderPrint.SetItemValue(blankRow, "suname", "");
                    layOrderPrint.SetItemValue(blankRow, "suname2", "");
                    layOrderPrint.SetItemValue(blankRow, "birth", "");
                    layOrderPrint.SetItemValue(blankRow, "sex_age", "");
                    layOrderPrint.SetItemValue(blankRow, "other_gwa", "");
                    layOrderPrint.SetItemValue(blankRow, "do_order", "");
                    layOrderPrint.SetItemValue(blankRow, "hope_nm", "");
                    layOrderPrint.SetItemValue(blankRow, "powder_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "rowno", o_line);
                    layOrderPrint.SetItemValue(blankRow, "kyukyeok", "");
                    layOrderPrint.SetItemValue(blankRow, "licenes", "");
                    layOrderPrint.SetItemValue(blankRow, "bunryu1", "");
                    layOrderPrint.SetItemValue(blankRow, "mix_group", "");
                    layOrderPrint.SetItemValue(blankRow, "donbok_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "tusuk", "");
                    layOrderPrint.SetItemValue(blankRow, "bigo", "");
                    layOrderPrint.SetItemValue(blankRow, "text_color", "");
                    layOrderPrint.SetItemValue(blankRow, "changgo", "");
                    layOrderPrint.SetItemValue(blankRow, "gubun_name", "");
                    layOrderPrint.SetItemValue(blankRow, "johap", "");
                    layOrderPrint.SetItemValue(blankRow, "gaein", "");
                    layOrderPrint.SetItemValue(blankRow, "gaein_no", "");
                    layOrderPrint.SetItemValue(blankRow, "bonin_gubun", "");
                    layOrderPrint.SetItemValue(blankRow, "bon_rate", "");
                    layOrderPrint.SetItemValue(blankRow, "budamja_bunho1", "");
                    layOrderPrint.SetItemValue(blankRow, "sugubja_bunho1", "");
                    layOrderPrint.SetItemValue(blankRow, "budamja_bunho2", "");
                    layOrderPrint.SetItemValue(blankRow, "sugubja_bunho2", "");
                    layOrderPrint.SetItemValue(blankRow, "sunwon_gubun", "");
                    layOrderPrint.SetItemValue(blankRow, "noin_rate_name", "");
                    layOrderPrint.SetItemValue(blankRow, "user_id", "");
                    if (k == 1) layOrderPrint.SetItemValue(blankRow, "data_gubun", "D");
                    else layOrderPrint.SetItemValue(blankRow, "data_gubun", "");
                    layOrderPrint.SetItemValue(blankRow, "mayak_license", o_mayak_license);
                    layOrderPrint.SetItemValue(blankRow, "mayak_doctor", o_mayak_doctor);
                    layOrderPrint.SetItemValue(blankRow, "mayak_address1", o_mayak_address1);
                    layOrderPrint.SetItemValue(blankRow, "mayak_address2", o_mayak_address2);
                    layOrderPrint.SetItemValue(blankRow, "gigan_date", o_jigan_date);
                    layOrderPrint.SetItemValue(blankRow, "hubal_change_yn", "");
                    layOrderPrint.SetItemValue(blankRow, "hubal_all_yn", o_hubal_all_yn);
                }

                
            }
            catch (Exception xe)
            {
                //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #region [-- DsvOrderJungbo --]
        /// <summary>
        /// dsvOrderJungbo Service Conversion PC:DRGPRINCOM, WT:6 OUTPUT:layOrderJungbo
        /// </summary>
        /// <param name="orderDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns></returns>
        private bool DsvOrderJungbo(string orderDate, string drgBunho)
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
            string o_bunho = string.Empty;
            string o_hl_1 = string.Empty;
            string o_hl_2 = string.Empty;
            string o_hl_3 = string.Empty;
            int o_row = 0;

            string t_comments = string.Empty;
            int rowNum = 0;

            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", orderDate);
            bindVars.Add("f_drg_bunho", drgBunho);

            DataTable dtPrinco = new DataTable();
            DataTable dtJungbo = new DataTable();

            try
            {
                cmdText = @"SELECT '1'                SEQ_1
                                  ,D.SERIAL_V         SEQ_2
                                  ,C.JAERYO_NAME      TEXT_1
                                  ,''                 TEXT_2
                                  ,''                 TEXT_3
                                  ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ')     REMARK
                                  ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'   BAR_DRG_BUNHO
                                  ,A.BUNHO            BUNHO
                              FROM DRG2030 D
                                  ,INV0110 C
                                  ,DRG9042 B
                                  ,DRG2010 A
                             WHERE A.ORDER_DATE     = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO      = :f_drg_bunho
                               AND B.FKOCS          = A.FKOCS1003
                               AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                               AND D.FKOCS1003   (+)= A.FKOCS1003
                               AND B.ORDER_REMARK IS NOT NULL
                            UNION ALL
                            SELECT DISTINCT '1'       SEQ_1
                                  ,''                 SEQ_2
                                  ,C.JAERYO_NAME      TEXT_1
                                  ,''                 TEXT_2
                                  ,''                 TEXT_3
                                  ,'[' || FN_ADM_MSG(4111) || ']' || REPLACE(REPLACE(C.DRG_COMMENT,CHR(13)||CHR(10),' '),CHR(10),' ') REMARK
                                  ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'   BAR_DRG_BUNHO
                                  ,A.BUNHO            BUNHO
                              FROM DRG2030 D
                                  ,INV0110 C
                                  ,DRG2010 A
                             WHERE A.ORDER_DATE     = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO      = :f_drg_bunho
                               AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                               AND NVL(C.CHKD,'N')  = 'Y'
                               AND D.FKOCS1003   (+)= A.FKOCS1003
                            UNION ALL
                            SELECT DISTINCT
                                   '2'                SEQ_1
                                  ,''                 SEQ_2
                                  ,'##'               TEXT_1
                                  ,''                 TEXT_2
                                  ,''                 TEXT_3
                                  ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ') REMARK
                                  ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'   BAR_DRG_BUNHO
                                  ,A.BUNHO            BUNHO
                              FROM DRG9040 B
                                  ,DRG2010 A
                             WHERE A.ORDER_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO   = :f_drg_bunho
                               AND B.ORDER_DATE  = A.ORDER_DATE
                               AND B.DRG_BUNHO   = A.DRG_BUNHO
                               AND B.ORDER_REMARK IS NOT NULL
                            UNION ALL
                            SELECT DISTINCT
                                   '3'                SEQ_1
                                  ,''                 SEQ_2
                                  ,DECODE(B.BUNHO,NULL,'','$$')  TEXT_1
                                  ,''                 TEXT_2
                                  ,''                 TEXT_3
                                  ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ') REMARK
                                  ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'   BAR_DRG_BUNHO
                                  ,A.BUNHO            BUNHO
                              FROM DRG9041 B
                                  ,DRG2010 A
                             WHERE A.ORDER_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO   = :f_drg_bunho
                               AND B.BUNHO    (+)= A.BUNHO
                               AND B.ORDER_REMARK IS NOT NULL
                             ORDER BY 1, 2";

                dtPrinco = Service.ExecuteDataTable(cmdText, bindVars);

                if (TypeCheck.IsNull(dtPrinco) || dtPrinco.Rows.Count < 1)
                {
                    cmdText = @"SELECT DISTINCT '*'||TO_CHAR(A.ORDER_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'
                                  FROM DRG2010 A
                                 WHERE A.ORDER_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.DRG_BUNHO   = :f_drg_bunho";
                    o_bar_drg_bunho = Service.ExecuteScalar(cmdText, bindVars).ToString();

                    rowNum = layOrderJungbo.InsertRow(-1);

                    layOrderJungbo.SetItemValue(rowNum, "text_1", "");
                    layOrderJungbo.SetItemValue(rowNum, "text_2", "");
                    layOrderJungbo.SetItemValue(rowNum, "text_3", "");
                    layOrderJungbo.SetItemValue(rowNum, "comments", "");
                    layOrderJungbo.SetItemValue(rowNum, "bunho_comments", "");
                    layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                    layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", "");
                    layOrderJungbo.SetItemValue(rowNum, "cpl_1", "");
                    layOrderJungbo.SetItemValue(rowNum, "cpl_2", "");
                    layOrderJungbo.SetItemValue(rowNum, "cpl_3", "");
                    layOrderJungbo.SetItemValue(rowNum, "danui_1", "");
                    layOrderJungbo.SetItemValue(rowNum, "danui_2", "");
                    layOrderJungbo.SetItemValue(rowNum, "danui_3", "");
                    layOrderJungbo.SetItemValue(rowNum, "hl_1", "");
                    layOrderJungbo.SetItemValue(rowNum, "hl_2", "");
                    layOrderJungbo.SetItemValue(rowNum, "hl_3", "");

                    return true;
                }

                for (int i = 0; i < dtPrinco.Rows.Count; i++)
                {
                    o_seq_1 = dtPrinco.Rows[i]["seq_1"].ToString();
                    o_seq_2 = dtPrinco.Rows[i]["seq_2"].ToString();
                    o_text_1 = dtPrinco.Rows[i]["text_1"].ToString();
                    o_text_2 = dtPrinco.Rows[i]["text_2"].ToString();
                    o_text_3 = dtPrinco.Rows[i]["text_3"].ToString();
                    o_comments = dtPrinco.Rows[i]["remark"].ToString();
                    o_bar_drg_bunho = dtPrinco.Rows[i]["bar_drg_bunho"].ToString();
                    o_bunho = dtPrinco.Rows[i]["bunho"].ToString();

                    bindVars.Remove("f_bunho");
                    bindVars.Remove("f_comments");
                    bindVars.Add("f_bunho", o_bunho);
                    bindVars.Add("f_comments", o_comments);

                    cmdText = @"SELECT NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('H', :f_bunho), 0) HEIGHT
                                     , 'Cm'                                             CM
                                     , NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('W', :f_bunho), 0) WEIGHT
                                     , 'Kg'                                             KG
                                     , FN_CPL_HANGMOG_RESULT(:f_bunho, '00077')         CPL_RESULT
                                     , FN_ADM_CONVERT_KATAKANA_FULL(:f_comments)        COMMENTS
                                     , TRUNC(LENGTH(NVL(:f_comments,' ')) / 80)         CNT
                                  FROM DUAL";
                    dtJungbo = Service.ExecuteDataTable(cmdText, bindVars);
                    if (dtJungbo.Rows.Count > 0)
                    {
                        o_cpl_1 = dtJungbo.Rows[0]["height"].ToString();
                        o_danui_1 = dtJungbo.Rows[0]["cm"].ToString();
                        o_cpl_2 = dtJungbo.Rows[0]["weight"].ToString();
                        o_danui_2 = dtJungbo.Rows[0]["kg"].ToString();
                        o_cpl_3 = dtJungbo.Rows[0]["cpl_result"].ToString();
                        o_comments = dtJungbo.Rows[0]["comments"].ToString();
                        o_row = int.Parse(dtJungbo.Rows[0]["cnt"].ToString());
                    }

                    for (int b = 0; b <= o_row; b++)
                    {
                        cmdText = @"SELECT '    ' || SUBSTR('" + o_comments + "', " + b + @" * 80 + 1, 80) FROM DUAL";
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
            catch (Exception xe)
            {
                //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #region 오더리스트 조회 바인드변수 셋팅
        private void grdOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrderList.SetBindVarValue("f_pkout1001", this.pkout1001);
        }
        #endregion

        private string pkout1001 = "";
        private void DRG2010R00_Load(object sender, EventArgs e)
        {
            // DataWindow Preview설정
   //         this.dw1.Modify("DataWindow.Print.Preview=Yes");
   //         this.dw1.Modify("DataWindow.Print.Preview.Zoom= 100");

            //TEST
            //this.pkout1001 = "171673";

            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("pkout1001"))
                {
                    this.pkout1001 = this.OpenParam["pkout1001"].ToString();
                    this.ParentForm.WindowState = FormWindowState.Minimized;
                    PostCallHelper.PostCall(new PostMethod(this.AutoCloseRoutine));
                }
            }
        }
        private void AutoCloseRoutine()
        {
            this.btnList.PerformClick(FunctionType.Query);
            this.btnList.PerformClick(FunctionType.Print);
            this.btnList.PerformClick(FunctionType.Close);
        }

    }
}

