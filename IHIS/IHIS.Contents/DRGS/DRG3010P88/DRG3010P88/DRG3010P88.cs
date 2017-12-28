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
using IHIS.Framework;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG3010P88에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG3010P88 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XTabControl xTabControl1;
        private IHIS.X.Magic.Controls.TabPage tabPage1;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel7;
        private IHIS.Framework.XPanel xPanel8;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell62;
        private IHIS.Framework.XEditGridCell xEditGridCell63;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XPanel xPanel9;
        private IHIS.Framework.XPanel xPanel10;
        private IHIS.Framework.XButton btnAllUnCheck;
        private IHIS.Framework.XButton btnAllCheck;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGrid grdPaQuery;
        private IHIS.Framework.XDictComboBox cboHoDong;
        private IHIS.Framework.XDatePicker dtpFromDate;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGrid grdMiMagamOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
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
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
        private IHIS.Framework.XEditGrid grdMiMagamJUSAOrder;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XButton btnMagam;
        private IHIS.Framework.XEditGrid grdMagamPaQuery;
        private IHIS.Framework.XLabel lbDate;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
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
        private IHIS.Framework.XEditGrid grdMagamOrder;
        private IHIS.Framework.XEditGrid grdMagamJUSAOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell123;
        private IHIS.Framework.XEditGridCell xEditGridCell124;
        private IHIS.Framework.XEditGridCell xEditGridCell125;
        private IHIS.Framework.XEditGridCell xEditGridCell126;
        private IHIS.Framework.XButton xButton4;
        private IHIS.Framework.XButtonList xButtonList2;
        private IHIS.Framework.XButton btnPrint;
        private IHIS.Framework.XEditGridCell xEditGridCell127;
        private IHIS.Framework.XEditGridCell xEditGridCell128;
 //       private IHIS.Framework.XDataWindow dw_print;
        private IHIS.Framework.XEditGridCell xEditGridCell129;
        private IHIS.Framework.XEditGridCell xEditGridCell130;
        private IHIS.Framework.MultiLayout layOrderJungbo;
        private IHIS.Framework.XDatePicker dtpToDate;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XRadioButton rbxBunryu2;
        private IHIS.Framework.XRadioButton rbxBunryu1;
        private IHIS.Framework.XPanel xPanel5;
  //      private IHIS.Framework.XDataWindow dw_jusa;
        private IHIS.Framework.XRadioButton rbxMagamGubun2;
        private IHIS.Framework.XRadioButton rbxMagamGubun1;
        private IHIS.Framework.XPanel xPanel6;
        private IHIS.Framework.XEditGridCell xEditGridCell131;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XComboItem xComboItem6;
        private IHIS.Framework.XComboItem xComboItem7;
        private IHIS.Framework.XComboItem xComboItem8;
        private IHIS.Framework.XComboItem xComboItem9;
        private IHIS.Framework.XComboItem xComboItem10;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell132;
        private IHIS.Framework.XEditGridCell xEditGridCell133;
        private IHIS.Framework.XEditGridCell xEditGridCell134;
        private IHIS.Framework.XEditGridCell xEditGridCell135;
        private IHIS.Framework.MultiLayout layOrderBarcode;
 //       private IHIS.Framework.XDataWindow dw_lable;
        private IHIS.Framework.MultiLayout layJusaLable;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.MultiLayout layOrderPrint;
        private IHIS.Framework.MultiLayout layJusaOrderPrint;
        private System.Windows.Forms.Button button1;
        private IHIS.Framework.XCheckBox chkPrint;
        private System.Windows.Forms.Timer timer1;
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
        private XEditGridCell xEditGridCell24;
        private ImageList imageListMixGroup;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell144;
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
        private MultiLayoutItem multiLayoutItem189;
        private MultiLayoutItem multiLayoutItem190;
        private MultiLayoutItem multiLayoutItem191;
        private MultiLayoutItem multiLayoutItem192;
        private MultiLayoutItem multiLayoutItem193;
        private MultiLayoutItem multiLayoutItem194;
        private XButton btnLable;
        private System.ComponentModel.IContainer components;

        public DRG3010P88()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010P88));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbxMagamGubun2 = new IHIS.Framework.XRadioButton();
            this.rbxMagamGubun1 = new IHIS.Framework.XRadioButton();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.rbxBunryu2 = new IHIS.Framework.XRadioButton();
            this.rbxBunryu1 = new IHIS.Framework.XRadioButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.cboHoDong = new IHIS.Framework.XDictComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.lbDate = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xTabControl1 = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel8 = new IHIS.Framework.XPanel();
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
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
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
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.grdPaQuery = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.chkPrint = new IHIS.Framework.XCheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.btnMagam = new IHIS.Framework.XButton();
            this.btnAllUnCheck = new IHIS.Framework.XButton();
            this.btnAllCheck = new IHIS.Framework.XButton();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel10 = new IHIS.Framework.XPanel();
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
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
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
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.grdMagamPaQuery = new IHIS.Framework.XEditGrid();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnLable = new IHIS.Framework.XButton();
            this.xButtonList2 = new IHIS.Framework.XButtonList();
            this.btnPrint = new IHIS.Framework.XButton();
            this.xButton4 = new IHIS.Framework.XButton();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.layJusaOrderPrint = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem189 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem190 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem191 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem192 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem193 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem194 = new IHIS.Framework.MultiLayoutItem();
            this.layOrderPrint = new IHIS.Framework.MultiLayout();
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
            this.layOrderJungbo = new IHIS.Framework.MultiLayout();
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
            this.layOrderBarcode = new IHIS.Framework.MultiLayout();
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
            this.layJusaLable = new IHIS.Framework.MultiLayout();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel6.SuspendLayout();
            this.xPanel5.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamJUSAOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamOrder)).BeginInit();
            this.xPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaQuery)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.xPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamJUSAOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).BeginInit();
            this.xPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamPaQuery)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaLable)).BeginInit();
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
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.paBox);
            this.xPanel2.Controls.Add(this.xPanel6);
            this.xPanel2.Controls.Add(this.xPanel5);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.dtpToDate);
            this.xPanel2.Controls.Add(this.cboHoDong);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.dtpFromDate);
            this.xPanel2.Controls.Add(this.lbDate);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.xPatientBox1_PatientSelected);
            // 
            // xPanel6
            // 
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Controls.Add(this.rbxMagamGubun2);
            this.xPanel6.Controls.Add(this.rbxMagamGubun1);
            this.xPanel6.Name = "xPanel6";
            // 
            // rbxMagamGubun2
            // 
            resources.ApplyResources(this.rbxMagamGubun2, "rbxMagamGubun2");
            this.rbxMagamGubun2.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Brown);
            this.rbxMagamGubun2.Name = "rbxMagamGubun2";
            this.rbxMagamGubun2.UseVisualStyleBackColor = false;
            this.rbxMagamGubun2.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbxMagamGubun1
            // 
            resources.ApplyResources(this.rbxMagamGubun1, "rbxMagamGubun1");
            this.rbxMagamGubun1.Checked = true;
            this.rbxMagamGubun1.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Brown);
            this.rbxMagamGubun1.Name = "rbxMagamGubun1";
            this.rbxMagamGubun1.TabStop = true;
            this.rbxMagamGubun1.UseVisualStyleBackColor = false;
            this.rbxMagamGubun1.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.rbxBunryu2);
            this.xPanel5.Controls.Add(this.rbxBunryu1);
            this.xPanel5.Name = "xPanel5";
            // 
            // rbxBunryu2
            // 
            resources.ApplyResources(this.rbxBunryu2, "rbxBunryu2");
            this.rbxBunryu2.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.rbxBunryu2.Name = "rbxBunryu2";
            this.rbxBunryu2.UseVisualStyleBackColor = false;
            this.rbxBunryu2.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbxBunryu1
            // 
            resources.ApplyResources(this.rbxBunryu1, "rbxBunryu1");
            this.rbxBunryu1.Checked = true;
            this.rbxBunryu1.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.rbxBunryu1.Name = "rbxBunryu1";
            this.rbxBunryu1.TabStop = true;
            this.rbxBunryu1.UseVisualStyleBackColor = false;
            this.rbxBunryu1.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            // 
            // cboHoDong
            // 
            resources.ApplyResources(this.cboHoDong, "cboHoDong");
            this.cboHoDong.ExecuteQuery = null;
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboHoDong.ParamList")));
            this.cboHoDong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoDong.UserSQL = "SELECT \'%\', \'全体\' FROM DUAL\r\nUNION \r\nSELECT GWA, GWA_NAME\r\n  FROM BAS0260\r\n WHERE " +
    "BUSEO_GUBUN = \'2\'\r\n   AND GWA_NAME IS NOT NULL\r\n--UNION \r\n--SELECT \'NRO\', \'外来救急\'" +
    " FROM DUAL";
            this.cboHoDong.SelectedIndexChanged += new System.EventHandler(this.cboHoDong_SelectedIndexChanged);
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel3.Name = "xLabel3";
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // lbDate
            // 
            resources.ApplyResources(this.lbDate, "lbDate");
            this.lbDate.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbDate.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.lbDate.Name = "lbDate";
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.xTabControl1);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // xTabControl1
            // 
            resources.ApplyResources(this.xTabControl1, "xTabControl1");
            this.xTabControl1.IDEPixelArea = true;
            this.xTabControl1.IDEPixelBorder = false;
            this.xTabControl1.Name = "xTabControl1";
            this.xTabControl1.SelectedIndex = 0;
            this.xTabControl1.SelectedTab = this.tabPage1;
            this.xTabControl1.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.xTabControl1.SelectionChanged += new System.EventHandler(this.xTabControl1_SelectionChanged);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.xPanel8);
            this.tabPage1.Controls.Add(this.xPanel7);
            this.tabPage1.Controls.Add(this.xPanel1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.ImageList = this.ImageList;
            this.tabPage1.Name = "tabPage1";
            // 
            // xPanel8
            // 
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.Controls.Add(this.grdMiMagamJUSAOrder);
            this.xPanel8.Controls.Add(this.grdMiMagamOrder);
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Name = "xPanel8";
            // 
            // grdMiMagamJUSAOrder
            // 
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
            this.xEditGridCell24,
            this.xEditGridCell99,
            this.xEditGridCell137,
            this.xEditGridCell138,
            this.xEditGridCell139,
            this.xEditGridCell140});
            this.grdMiMagamJUSAOrder.ColPerLine = 13;
            this.grdMiMagamJUSAOrder.ColResizable = true;
            this.grdMiMagamJUSAOrder.Cols = 14;
            this.grdMiMagamJUSAOrder.ControlBinding = true;
            this.grdMiMagamJUSAOrder.ExecuteQuery = null;
            this.grdMiMagamJUSAOrder.FixedCols = 1;
            this.grdMiMagamJUSAOrder.FixedRows = 1;
            this.grdMiMagamJUSAOrder.HeaderHeights.Add(41);
            this.grdMiMagamJUSAOrder.Name = "grdMiMagamJUSAOrder";
            this.grdMiMagamJUSAOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMiMagamJUSAOrder.ParamList")));
            this.grdMiMagamJUSAOrder.QuerySQL = resources.GetString("grdMiMagamJUSAOrder.QuerySQL");
            this.grdMiMagamJUSAOrder.ReadOnly = true;
            this.grdMiMagamJUSAOrder.RowHeaderVisible = true;
            this.grdMiMagamJUSAOrder.Rows = 2;
            this.grdMiMagamJUSAOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMiMagamJUSAOrder_QueryStarting);
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
            this.xEditGridCell76.Col = 1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsReadOnly = true;
            this.xEditGridCell76.IsUpdCol = false;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "jaeryo_code";
            this.xEditGridCell77.CellWidth = 77;
            this.xEditGridCell77.Col = 2;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsReadOnly = true;
            this.xEditGridCell77.IsUpdCol = false;
            this.xEditGridCell77.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "jaeryo_name";
            this.xEditGridCell78.CellWidth = 206;
            this.xEditGridCell78.Col = 3;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsReadOnly = true;
            this.xEditGridCell78.IsUpdCol = false;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "ord_suryang";
            this.xEditGridCell79.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell79.CellWidth = 40;
            this.xEditGridCell79.Col = 4;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsReadOnly = true;
            this.xEditGridCell79.IsUpdCol = false;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "dv_time";
            this.xEditGridCell80.CellWidth = 22;
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
            this.xEditGridCell81.CellName = "dv";
            this.xEditGridCell81.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell81.CellWidth = 22;
            this.xEditGridCell81.Col = 5;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.IsUpdCol = false;
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
            this.xEditGridCell85.CellWidth = 49;
            this.xEditGridCell85.Col = 6;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsUpdCol = false;
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
            this.xEditGridCell89.CellWidth = 72;
            this.xEditGridCell89.Col = 7;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "powder_yn";
            this.xEditGridCell90.CellWidth = 25;
            this.xEditGridCell90.Col = 9;
            this.xEditGridCell90.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "remark";
            this.xEditGridCell91.CellWidth = 135;
            this.xEditGridCell91.Col = 13;
            this.xEditGridCell91.DisplayMemoText = true;
            this.xEditGridCell91.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsReadOnly = true;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "dv_1";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsReadOnly = true;
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
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "hubal_change_yn";
            this.xEditGridCell97.CellWidth = 25;
            this.xEditGridCell97.Col = 12;
            this.xEditGridCell97.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "pharmacy";
            this.xEditGridCell98.CellWidth = 30;
            this.xEditGridCell98.Col = 10;
            this.xEditGridCell98.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "drg_pack_yn";
            this.xEditGridCell100.CellWidth = 25;
            this.xEditGridCell100.Col = 11;
            this.xEditGridCell100.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "jusa";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "jusa_name";
            this.xEditGridCell99.CellWidth = 106;
            this.xEditGridCell99.Col = 8;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsReadOnly = true;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "dc_yn";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "group_ser";
            this.xEditGridCell138.Col = -1;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsVisible = false;
            this.xEditGridCell138.Row = -1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "hope_date";
            this.xEditGridCell139.Col = -1;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.IsVisible = false;
            this.xEditGridCell139.Row = -1;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "order_gubun";
            this.xEditGridCell140.Col = -1;
            this.xEditGridCell140.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsVisible = false;
            this.xEditGridCell140.Row = -1;
            // 
            // grdMiMagamOrder
            // 
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
            this.xEditGridCell73});
            this.grdMiMagamOrder.ColPerLine = 13;
            this.grdMiMagamOrder.ColResizable = true;
            this.grdMiMagamOrder.Cols = 14;
            this.grdMiMagamOrder.ControlBinding = true;
            this.grdMiMagamOrder.ExecuteQuery = null;
            this.grdMiMagamOrder.FixedCols = 1;
            this.grdMiMagamOrder.FixedRows = 1;
            this.grdMiMagamOrder.HeaderHeights.Add(41);
            this.grdMiMagamOrder.Name = "grdMiMagamOrder";
            this.grdMiMagamOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMiMagamOrder.ParamList")));
            this.grdMiMagamOrder.QuerySQL = resources.GetString("grdMiMagamOrder.QuerySQL");
            this.grdMiMagamOrder.ReadOnly = true;
            this.grdMiMagamOrder.RowHeaderVisible = true;
            this.grdMiMagamOrder.Rows = 2;
            this.grdMiMagamOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMiMagamOrder_QueryStarting);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "order_date";
            this.xEditGridCell18.CellWidth = 77;
            this.xEditGridCell18.Col = 1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.SuppressRepeating = true;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "group_ser";
            this.xEditGridCell70.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell70.CellWidth = 20;
            this.xEditGridCell70.Col = 2;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsReadOnly = true;
            this.xEditGridCell70.IsUpdCol = false;
            this.xEditGridCell70.SuppressRepeating = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "jaeryo_code";
            this.xEditGridCell19.CellWidth = 77;
            this.xEditGridCell19.Col = 3;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "jaeryo_name";
            this.xEditGridCell65.CellWidth = 203;
            this.xEditGridCell65.Col = 4;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsUpdCol = false;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "ord_suryang";
            this.xEditGridCell38.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell38.CellWidth = 40;
            this.xEditGridCell38.Col = 5;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdCol = false;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "dv_time";
            this.xEditGridCell64.CellWidth = 22;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsReadOnly = true;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            this.xEditGridCell64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "dv";
            this.xEditGridCell60.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell60.CellWidth = 22;
            this.xEditGridCell60.Col = 6;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsUpdCol = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "nalsu";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.CellWidth = 22;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
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
            this.xEditGridCell69.CellWidth = 49;
            this.xEditGridCell69.Col = 7;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsUpdCol = false;
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
            this.xEditGridCell68.CellWidth = 127;
            this.xEditGridCell68.Col = 8;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.IsUpdCol = false;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "powder_yn";
            this.xEditGridCell66.CellWidth = 25;
            this.xEditGridCell66.Col = 9;
            this.xEditGridCell66.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "remark";
            this.xEditGridCell71.CellWidth = 153;
            this.xEditGridCell71.Col = 13;
            this.xEditGridCell71.DisplayMemoText = true;
            this.xEditGridCell71.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "dv_1";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
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
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "hubal_change_yn";
            this.xEditGridCell67.CellWidth = 25;
            this.xEditGridCell67.Col = 12;
            this.xEditGridCell67.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "pharmacy";
            this.xEditGridCell72.CellWidth = 30;
            this.xEditGridCell72.Col = 10;
            this.xEditGridCell72.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            this.xEditGridCell72.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "drg_pack_yn";
            this.xEditGridCell74.CellWidth = 25;
            this.xEditGridCell74.Col = 11;
            this.xEditGridCell74.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsReadOnly = true;
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
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            this.xEditGridCell73.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel7
            // 
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.Controls.Add(this.grdPaQuery);
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Name = "xPanel7";
            // 
            // grdPaQuery
            // 
            resources.ApplyResources(this.grdPaQuery, "grdPaQuery");
            this.grdPaQuery.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell8,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell131,
            this.xEditGridCell23,
            this.xEditGridCell21});
            this.grdPaQuery.ColPerLine = 8;
            this.grdPaQuery.Cols = 9;
            this.grdPaQuery.ExecuteQuery = null;
            this.grdPaQuery.FixedCols = 1;
            this.grdPaQuery.FixedRows = 1;
            this.grdPaQuery.HeaderHeights.Add(41);
            this.grdPaQuery.Name = "grdPaQuery";
            this.grdPaQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaQuery.ParamList")));
            this.grdPaQuery.QuerySQL = resources.GetString("grdPaQuery.QuerySQL");
            this.grdPaQuery.RowHeaderVisible = true;
            this.grdPaQuery.Rows = 2;
            this.grdPaQuery.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaQuery_RowFocusChanged);
            this.grdPaQuery.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaQuery_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 75;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.CellWidth = 85;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "sex";
            this.xEditGridCell3.CellWidth = 20;
            this.xEditGridCell3.Col = 7;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "age";
            this.xEditGridCell4.CellWidth = 30;
            this.xEditGridCell4.Col = 8;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ho_dong";
            this.xEditGridCell5.CellWidth = 40;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.SuppressRepeating = true;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "ho_dong_name";
            this.xEditGridCell8.CellWidth = 40;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
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
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "magam_gubun";
            this.xEditGridCell131.CellWidth = 40;
            this.xEditGridCell131.Col = 4;
            this.xEditGridCell131.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7,
            this.xComboItem8,
            this.xComboItem9,
            this.xComboItem10});
            this.xEditGridCell131.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell131.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsReadOnly = true;
            this.xEditGridCell131.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "11";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "12";
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "21";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "22";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "31";
            // 
            // xComboItem10
            // 
            resources.ApplyResources(this.xComboItem10, "xComboItem10");
            this.xComboItem10.ValueItem = "ER";
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "ho_dong1";
            this.xEditGridCell23.CellWidth = 34;
            this.xEditGridCell23.Col = 1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "magam_yn";
            this.xEditGridCell21.CellWidth = 30;
            this.xEditGridCell21.Col = 5;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.chkPrint);
            this.xPanel1.Controls.Add(this.button1);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Controls.Add(this.btnMagam);
            this.xPanel1.Controls.Add(this.btnAllUnCheck);
            this.xPanel1.Controls.Add(this.btnAllCheck);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // chkPrint
            // 
            resources.ApplyResources(this.chkPrint, "chkPrint");
            this.chkPrint.CheckedText = "自動出力";
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.UnCheckedText = "選択出力";
            this.chkPrint.UseVisualStyleBackColor = false;
            this.chkPrint.CheckedChanged += new System.EventHandler(this.chkPrint_CheckedChanged);
            this.chkPrint.Click += new System.EventHandler(this.chkPrint_CheckedChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // btnMagam
            // 
            resources.ApplyResources(this.btnMagam, "btnMagam");
            this.btnMagam.ImageIndex = 3;
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
            this.btnAllUnCheck.Click += new System.EventHandler(this.btnAllUnCheck_Click);
            // 
            // btnAllCheck
            // 
            resources.ApplyResources(this.btnAllCheck, "btnAllCheck");
            this.btnAllCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllCheck.Image")));
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.xPanel10);
            this.tabPage2.Controls.Add(this.xPanel9);
            this.tabPage2.Controls.Add(this.xPanel4);
            this.tabPage2.ImageIndex = 3;
            this.tabPage2.ImageList = this.ImageList;
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            // 
            // xPanel10
            // 
            resources.ApplyResources(this.xPanel10, "xPanel10");
            this.xPanel10.Controls.Add(this.grdMagamJUSAOrder);
            this.xPanel10.Controls.Add(this.grdMagamOrder);
            this.xPanel10.DrawBorder = true;
            this.xPanel10.Name = "xPanel10";
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
            this.xEditGridCell144,
            this.xEditGridCell26,
            this.xEditGridCell28,
            this.xEditGridCell30,
            this.xEditGridCell136,
            this.xEditGridCell141,
            this.xEditGridCell142,
            this.xEditGridCell143});
            this.grdMagamJUSAOrder.ColPerLine = 11;
            this.grdMagamJUSAOrder.ColResizable = true;
            this.grdMagamJUSAOrder.Cols = 12;
            this.grdMagamJUSAOrder.ControlBinding = true;
            this.grdMagamJUSAOrder.ExecuteQuery = null;
            this.grdMagamJUSAOrder.FixedCols = 1;
            this.grdMagamJUSAOrder.FixedRows = 1;
            this.grdMagamJUSAOrder.HeaderHeights.Add(41);
            this.grdMagamJUSAOrder.Name = "grdMagamJUSAOrder";
            this.grdMagamJUSAOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMagamJUSAOrder.ParamList")));
            this.grdMagamJUSAOrder.QuerySQL = resources.GetString("grdMagamJUSAOrder.QuerySQL");
            this.grdMagamJUSAOrder.ReadOnly = true;
            this.grdMagamJUSAOrder.RowHeaderVisible = true;
            this.grdMagamJUSAOrder.Rows = 2;
            this.grdMagamJUSAOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMagamJUSAOrder_GridCellPainting);
            this.grdMagamJUSAOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMagamJUSAOrder_QueryStarting);
            this.grdMagamJUSAOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamJUSAOrder_QueryEnd);
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
            this.xEditGridCell101.Col = 1;
            this.xEditGridCell101.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsUpdCol = false;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "jaeryo_code";
            this.xEditGridCell102.CellWidth = 77;
            this.xEditGridCell102.Col = 2;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdCol = false;
            this.xEditGridCell102.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "jaeryo_name";
            this.xEditGridCell103.CellWidth = 203;
            this.xEditGridCell103.Col = 3;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.IsUpdCol = false;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ord_suryang";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell104.CellWidth = 40;
            this.xEditGridCell104.Col = 4;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsReadOnly = true;
            this.xEditGridCell104.IsUpdCol = false;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "dv_time";
            this.xEditGridCell105.CellWidth = 22;
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
            this.xEditGridCell106.Col = 5;
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
            this.xEditGridCell111.CellWidth = 72;
            this.xEditGridCell111.Col = 7;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsUpdCol = false;
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
            this.xEditGridCell113.CellName = "remark";
            this.xEditGridCell113.CellWidth = 123;
            this.xEditGridCell113.Col = 11;
            this.xEditGridCell113.DisplayMemoText = true;
            this.xEditGridCell113.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsReadOnly = true;
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
            this.xEditGridCell119.Col = 10;
            this.xEditGridCell119.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "pharmacy";
            this.xEditGridCell120.CellWidth = 30;
            this.xEditGridCell120.Col = 9;
            this.xEditGridCell120.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsReadOnly = true;
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
            this.xEditGridCell122.CellWidth = 79;
            this.xEditGridCell122.Col = 8;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsReadOnly = true;
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
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "jusa_name";
            this.xEditGridCell144.Col = -1;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsVisible = false;
            this.xEditGridCell144.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "dc_yn";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "group_ser";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "hope_date";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "order_gubun";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "source_fkocs2003";
            this.xEditGridCell141.Col = -1;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsVisible = false;
            this.xEditGridCell141.Row = -1;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "fkocs2003";
            this.xEditGridCell142.Col = -1;
            this.xEditGridCell142.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsVisible = false;
            this.xEditGridCell142.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "bannab_yn";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // grdMagamOrder
            // 
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
            this.xEditGridCell129});
            this.grdMagamOrder.ColPerLine = 16;
            this.grdMagamOrder.ColResizable = true;
            this.grdMagamOrder.Cols = 17;
            this.grdMagamOrder.ControlBinding = true;
            this.grdMagamOrder.ExecuteQuery = null;
            this.grdMagamOrder.FixedCols = 1;
            this.grdMagamOrder.FixedRows = 1;
            this.grdMagamOrder.HeaderHeights.Add(41);
            this.grdMagamOrder.Name = "grdMagamOrder";
            this.grdMagamOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMagamOrder.ParamList")));
            this.grdMagamOrder.ReadOnly = true;
            this.grdMagamOrder.RowHeaderVisible = true;
            this.grdMagamOrder.Rows = 2;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "order_date";
            this.xEditGridCell27.CellWidth = 77;
            this.xEditGridCell27.Col = 3;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdCol = false;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "group_ser";
            this.xEditGridCell32.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell32.CellWidth = 20;
            this.xEditGridCell32.Col = 4;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdCol = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "jaeryo_code";
            this.xEditGridCell33.CellWidth = 77;
            this.xEditGridCell33.Col = 5;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jaeryo_name";
            this.xEditGridCell34.CellWidth = 203;
            this.xEditGridCell34.Col = 6;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "ord_suryang";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell35.CellWidth = 40;
            this.xEditGridCell35.Col = 7;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdCol = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "dv_time";
            this.xEditGridCell36.CellWidth = 22;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "dv";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.CellWidth = 22;
            this.xEditGridCell40.Col = 8;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdCol = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "nalsu";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell41.CellWidth = 22;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
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
            this.xEditGridCell43.CellWidth = 49;
            this.xEditGridCell43.Col = 9;
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
            this.xEditGridCell45.CellWidth = 127;
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
            this.xEditGridCell46.Col = 11;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "remark";
            this.xEditGridCell47.CellWidth = 153;
            this.xEditGridCell47.Col = 15;
            this.xEditGridCell47.DisplayMemoText = true;
            this.xEditGridCell47.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
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
            this.xEditGridCell53.Col = 14;
            this.xEditGridCell53.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pharmacy";
            this.xEditGridCell54.CellWidth = 30;
            this.xEditGridCell54.Col = 12;
            this.xEditGridCell54.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "drg_pack_yn";
            this.xEditGridCell55.CellWidth = 25;
            this.xEditGridCell55.Col = 13;
            this.xEditGridCell55.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsReadOnly = true;
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
            this.xEditGridCell123.Col = 2;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.SuppressRepeating = true;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "drg_bunho";
            this.xEditGridCell126.CellWidth = 40;
            this.xEditGridCell126.Col = 1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.SuppressRepeating = true;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "jubsu_date";
            this.xEditGridCell127.Col = 16;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "bunho";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
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
            this.xEditGridCell29,
            this.xEditGridCell9,
            this.xEditGridCell132,
            this.xEditGridCell25,
            this.xEditGridCell133,
            this.xEditGridCell134,
            this.xEditGridCell135});
            this.grdMagamPaQuery.ColPerLine = 5;
            this.grdMagamPaQuery.Cols = 6;
            this.grdMagamPaQuery.ExecuteQuery = null;
            this.grdMagamPaQuery.FixedCols = 1;
            this.grdMagamPaQuery.FixedRows = 1;
            this.grdMagamPaQuery.HeaderHeights.Add(41);
            this.grdMagamPaQuery.Name = "grdMagamPaQuery";
            this.grdMagamPaQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMagamPaQuery.ParamList")));
            this.grdMagamPaQuery.QuerySQL = resources.GetString("grdMagamPaQuery.QuerySQL");
            this.grdMagamPaQuery.ReadOnly = true;
            this.grdMagamPaQuery.RowHeaderVisible = true;
            this.grdMagamPaQuery.Rows = 2;
            this.grdMagamPaQuery.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMagamPaQuery_RowFocusChanged);
            this.grdMagamPaQuery.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMagamPaQuery_QueryStarting);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "jubsu_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.Col = 1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.SuppressRepeating = true;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell29.CellName = "drg_bunho";
            this.xEditGridCell29.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell29.CellWidth = 45;
            this.xEditGridCell29.Col = 2;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "bunho";
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "suname";
            this.xEditGridCell132.Col = 4;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "magma_gubun";
            this.xEditGridCell25.CellWidth = 83;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "gwa";
            this.xEditGridCell133.Col = -1;
            this.xEditGridCell133.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "doctor";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "doctor_name";
            this.xEditGridCell135.Col = 5;
            this.xEditGridCell135.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.btnLable);
            this.xPanel4.Controls.Add(this.xButtonList2);
            this.xPanel4.Controls.Add(this.btnPrint);
            this.xPanel4.Controls.Add(this.xButton4);
            this.xPanel4.Name = "xPanel4";
            // 
            // btnLable
            // 
            resources.ApplyResources(this.btnLable, "btnLable");
            this.btnLable.ImageIndex = 2;
            this.btnLable.ImageList = this.ImageList;
            this.btnLable.Name = "btnLable";
            this.btnLable.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnLable.Click += new System.EventHandler(this.btnLable_Click);
            // 
            // xButtonList2
            // 
            resources.ApplyResources(this.xButtonList2, "xButtonList2");
            this.xButtonList2.IsVisiblePreview = false;
            this.xButtonList2.IsVisibleReset = false;
            this.xButtonList2.Name = "xButtonList2";
            this.xButtonList2.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList2.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList2_ButtonClick);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ImageIndex = 2;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // xButton4
            // 
            resources.ApplyResources(this.xButton4, "xButton4");
            this.xButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.xButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xButton4.ImageIndex = 1;
            this.xButton4.ImageList = this.ImageList;
            this.xButton4.Name = "xButton4";
            this.xButton4.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xButton4.Click += new System.EventHandler(this.xButton4_Click);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "ho_dong";
            this.xEditGridCell12.CellWidth = 40;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.SuppressRepeating = true;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "hsy_bunho";
            this.xEditGridCell83.CellWidth = 72;
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsReadOnly = true;
            this.xEditGridCell83.IsUpdCol = false;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            this.xEditGridCell83.SuppressRepeating = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell10.CellName = "drg_bunho";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.CellWidth = 40;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell10.SuppressRepeating = true;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "jubsu_date";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsReadOnly = true;
            this.xEditGridCell87.IsUpdCol = false;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "order_date";
            this.xEditGridCell88.CellWidth = 75;
            this.xEditGridCell88.Col = 1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsReadOnly = true;
            this.xEditGridCell88.IsUpdCol = false;
            this.xEditGridCell88.SuppressRepeating = true;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "jaeryo_code";
            this.xEditGridCell61.CellWidth = 79;
            this.xEditGridCell61.Col = 4;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsUpdCol = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "nalsu";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.CellWidth = 22;
            this.xEditGridCell11.Col = 9;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "ord_suryang";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell62.CellWidth = 34;
            this.xEditGridCell62.Col = 6;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.IsUpdCol = false;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "order_danui";
            this.xEditGridCell63.CellWidth = 50;
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            this.xEditGridCell63.IsUpdCol = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "dv";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell37.CellWidth = 22;
            this.xEditGridCell37.Col = 8;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdCol = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "group_ser";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.CellWidth = 18;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "fkocs2003";
            this.xEditGridCell31.Col = 1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            // 
            // layJusaOrderPrint
            // 
            this.layJusaOrderPrint.ExecuteQuery = null;
            this.layJusaOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem189,
            this.multiLayoutItem190,
            this.multiLayoutItem191,
            this.multiLayoutItem192,
            this.multiLayoutItem193,
            this.multiLayoutItem194});
            this.layJusaOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJusaOrderPrint.ParamList")));
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "bunho";
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "suname";
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "suname2";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "birth";
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "age";
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "drg_bunho";
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "ho_dong";
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "ho_code";
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "magam_gubun";
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "gwa_name";
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "doctor_name";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "jubsu_date";
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "serial_v";
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "resident_name";
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "jusa";
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "jaeryo_name";
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "bogyong_name";
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "ord_surang";
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "order_danui";
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "dv";
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "subul_surang";
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "subul_danui";
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "order_remark";
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "rp_barcode";
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "order_date";
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "order_suryang";
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "jusa_nalsu";
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "data_gubun";
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "barcode";
            // 
            // multiLayoutItem189
            // 
            this.multiLayoutItem189.DataName = "print_gubun";
            // 
            // multiLayoutItem190
            // 
            this.multiLayoutItem190.DataName = "hodong_ord_name";
            // 
            // multiLayoutItem191
            // 
            this.multiLayoutItem191.DataName = "sort_key";
            // 
            // multiLayoutItem192
            // 
            this.multiLayoutItem192.DataName = "max_bannab_yn";
            // 
            // multiLayoutItem193
            // 
            this.multiLayoutItem193.DataName = "bannab_yn";
            // 
            // multiLayoutItem194
            // 
            this.multiLayoutItem194.DataName = "fkocs2003";
            // 
            // layOrderPrint
            // 
            this.layOrderPrint.ExecuteQuery = null;
            this.layOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem66});
            this.layOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderPrint.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "drg_bunho";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "naewon_date";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "group_ser";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "jubsu_date";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "order_date";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "jaeryo_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "nalsu";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "divide";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "ord_surang";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "order_suryang";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "order_danui";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "subul_danui";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "group_yn";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jaeryo_gubun";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "bogyong_code";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "bogyong_name";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "caution_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "caution_code";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "mix_yn";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "atc_yn";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "dv";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "dv_time";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "dc_yn";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "bannab_yn";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "source_fkocs1003";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "fkocs1003";
            this.multiLayoutItem27.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "sunab_date";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "pattern";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "jaeryo_name";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "sunab_nalsu";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "wonyoi_yn";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "order_remark";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "act_date";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "mayak";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "tpn_joje_gubun";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "ui_jusa_yn";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "subul_suryang";
            this.multiLayoutItem38.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "serial_v";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "gwa_name";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "doctor_name";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "suname";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "suname2";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "birth";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "age";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "other_gwa";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "do_order";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "gubun_name";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "hope_date";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "powder_yn";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "line";
            this.multiLayoutItem51.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "kyukyeok";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "licenes";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "bunryu1";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "ho_dong";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "ho_code";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "title";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "donbok";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "tusuk";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "magam_gubun";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "text_color";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "changgo";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "from_order_date";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "to_order_date";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "data_gubun";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "print_gubun";
            // 
            // layOrderJungbo
            // 
            this.layOrderJungbo.ExecuteQuery = null;
            this.layOrderJungbo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem114});
            this.layOrderJungbo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderJungbo.ParamList")));
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "text_1";
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "text_2";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "text_3";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "comments";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "bunho_comments";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "bar_drg_bunho";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "bar_rp_bunho";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "cpl_1";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "cpl_2";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "cpl_3";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "danui_1";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "danui_2";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "danui_3";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "hl_1";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "hl_2";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "hl_3";
            // 
            // layOrderBarcode
            // 
            this.layOrderBarcode.ExecuteQuery = null;
            this.layOrderBarcode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem130});
            this.layOrderBarcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderBarcode.ParamList")));
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "text_1";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "text_2";
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "text_3";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "comments";
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "bunho_comments";
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "bar_drg_bunho";
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "bar_rp_bunho";
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "cpl_1";
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "cpl_2";
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "cpl_3";
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "danui_1";
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "danui_2";
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "danui_3";
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "hl_1";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "hl_2";
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "hl_3";
            // 
            // layJusaLable
            // 
            this.layJusaLable.ExecuteQuery = null;
            this.layJusaLable.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem188});
            this.layJusaLable.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJusaLable.ParamList")));
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "bunho";
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "suname";
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "suname2";
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "birth";
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "age";
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "drg_bunho";
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "ho_dong";
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "ho_code";
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "magam_gubun";
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "gwa_name";
            // 
            // multiLayoutItem170
            // 
            this.multiLayoutItem170.DataName = "doctor_name";
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "jubsu_date";
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "serial_v";
            // 
            // multiLayoutItem173
            // 
            this.multiLayoutItem173.DataName = "resident_name";
            // 
            // multiLayoutItem174
            // 
            this.multiLayoutItem174.DataName = "jusa";
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "jaeryo_name";
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "bogyong_name";
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "ord_surang";
            // 
            // multiLayoutItem178
            // 
            this.multiLayoutItem178.DataName = "order_danui";
            // 
            // multiLayoutItem179
            // 
            this.multiLayoutItem179.DataName = "dv";
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "subul_surang";
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "subul_danui";
            // 
            // multiLayoutItem182
            // 
            this.multiLayoutItem182.DataName = "order_remark";
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "rp_barcode";
            // 
            // multiLayoutItem184
            // 
            this.multiLayoutItem184.DataName = "order_date";
            // 
            // multiLayoutItem185
            // 
            this.multiLayoutItem185.DataName = "order_suryang";
            // 
            // multiLayoutItem186
            // 
            this.multiLayoutItem186.DataName = "rp2";
            // 
            // multiLayoutItem187
            // 
            this.multiLayoutItem187.DataName = "data_gubun";
            // 
            // multiLayoutItem188
            // 
            this.multiLayoutItem188.DataName = "line";
            this.multiLayoutItem188.DataType = IHIS.Framework.DataType.Number;
            // 
            // timer1
            // 
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // DRG3010P88
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Name = "DRG3010P88";
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamJUSAOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamOrder)).EndInit();
            this.xPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaQuery)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.xPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamJUSAOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).EndInit();
            this.xPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamPaQuery)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaLable)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Common Properties
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
            dtpToDate.SetDataValue(EnvironInfo.GetSysDate());

            lbDate.Text = "オーダ日";
            dtpToDate.Visible = false;
            xLabel1.Visible = false;

            if (this.OpenParam != null)
            {
                try
                {
                    if (this.OpenParam.Contains("order_date"))
                    {
                        dtpFromDate.SetDataValue(this.OpenParam["order_date"].ToString());
                    }
                    if(this.OpenParam.Contains("bunho"))
                    {
                        paBox.SetPatientID(this.OpenParam["bunho"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message);
                }
                finally
                {
                }
            }

            

//            if (this.OpenParam != null)
//            {
//                try
//                {
//                    string cmdStr = @"SELECT 'Y'  FROM DRG9043
//                    WHERE TO_CHAR(SYSDATE,'YYYYMMDDHH24MI') BETWEEN TO_CHAR(START_DATE,'YYYYMMDD') || START_TIME
//                              AND TO_CHAR(NVL(END_DATE,SYSDATE),'YYYYMMDD') || NVL(END_TIME,'9999')
//                      AND CANCEL_DATE IS NULL
//                      AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()";
//                    object retVal = Service.ExecuteScalar(cmdStr);

//                    if (!TypeCheck.IsNull(retVal) && retVal.ToString() == "Y")
//                    {


//                        ArrayList inputList = new ArrayList();
//                        ArrayList outputList = new ArrayList();

//                        inputList.Add(this.OpenParam["bunho"].ToString());
//                        inputList.Add(this.OpenParam["order_date"].ToString());  //I_FROM_DATE
//                        inputList.Add(this.OpenParam["order_date"].ToString());    //I_TO_DATE
//                        inputList.Add("");   //I_GWA
//                        inputList.Add("");   //I_DOCTOR
//                        inputList.Add("Y");   //I_JUSA_YN
//                        inputList.Add(this.OpenParam["ho_dong"].ToString());  //I_CHULGO_BUSEO
//                        inputList.Add(UserInfo.UserID);        //I_MAGAM_USER
//                        inputList.Add("N");     //I_JUNINP_YN 

//                        // 마감
//                        if (Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_INP_HO_DONG", inputList, outputList))
//                        {
//                            // 처방전 출력
//                            DrgPrint(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), outputList[0].ToString(), "");
//                        }
//                        else
//                        {
//                            MessageBox.Show(Service.ErrFullMsg);
//                        }
//                    }
//                }
//                finally
//                {
//                    PostCallHelper.PostCall(new PostMethod(SetClose));
//                }
//            }

            


            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }
        #endregion

        #region SetClose
        private void SetClose()
        {
            this.Close();
        }
        #endregion

        private void PostLoad()
        {

            // 응급, 외래 에서 선택 하면 적용
            if (EnvironInfo.CurrSystemID == "NURO" || EnvironInfo.CurrSystemID == "NURE")
            {
                xButton4.Visible = false;
                btnMagam.Visible = false;
                btnAllCheck.Visible = false;
                btnAllUnCheck.Visible = false;
                chkPrint.Visible = false;
                xTabControl1.TabPages.Remove(xTabControl1.TabPages[0]);
                //cboHoDong.SetDataValue(TypeCheck.NVL("NRO", "T").ToString());
                cboHoDong.SelectedIndex = 0;

            }
            else
            {
                //cboHoDong.SetDataValue(TypeCheck.NVL(UserInfo.HoDong, "T").ToString());
                //xTabControl1.SelectedIndex = 0;
                cboHoDong.SelectedIndex = 0;
                MiMagamQuery();
            }

            
        }

        private void btnMiMagamQuery_Click(object sender, System.EventArgs e)
        {
            MiMagamQuery();
        }

        private void MiMagamQuery()
        {
            grdMiMagamOrder.Reset();
            grdMiMagamJUSAOrder.Reset();

            //string magam_bunryu = "1", magam_gubun = "N";

            //if (rbxBunryu1.Checked) magam_bunryu = "1";//내복, 외용
            //if (rbxBunryu2.Checked) magam_bunryu = "2";//주사

            //if (rbxMagamGubun1.Checked) magam_gubun = "N"; //정규
            //if (rbxMagamGubun2.Checked) magam_gubun = "Y"; //추가

            //dsvMiMagamPa.SetInValue("magam_bunryu", magam_bunryu);
            //dsvMiMagamPa.SetInValue("magam_gubun", magam_gubun);

            grdMiMagamOrder.Reset();
            grdMiMagamJUSAOrder.Reset();

            grdPaQuery.QueryLayout(false);
        }

        private void MagamQuery()
        {
            grdMagamOrder.Reset();
            grdMagamJUSAOrder.Reset();

            //string magam_bunryu = "1";

            //if (rbxBunryu1.Checked) magam_bunryu = "1";//내복, 외용
            //if (rbxBunryu2.Checked) magam_bunryu = "2";//주사

            // 응급, 외래 에서 선택 하면 적용
            if (EnvironInfo.CurrSystemID == "NURO" || EnvironInfo.CurrSystemID == "NURE")
            {
                if (paBox.BunHo == "")
                {
                    XMessageBox.Show("患者番号はを入力してください。", "お知らせ", MessageBoxIcon.Warning);
                    return;
                }
            }

            //dsvMagamPaQuery.SetInValue("magam_gubun", magam_bunryu);
            grdMagamPaQuery.QueryLayout(false);
        }

        private void grdPaQuery_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            grdMiMagamOrder.Visible = false;
            grdMiMagamJUSAOrder.Visible = true;

            grdMiMagamJUSAOrder.QueryLayout(false);
        }

        private void btnAllCheck_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < grdPaQuery.RowCount; i++)
            {
                grdPaQuery.SetItemValue(i, "magam_yn", "Y");
            }
            grdPaQuery.AcceptData();
        }

        private void btnAllUnCheck_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < grdPaQuery.RowCount; i++)
            {
                grdPaQuery.SetItemValue(i, "magam_yn", "N");
            }
            grdPaQuery.AcceptData();
        }

        private void CheckedChanged(object sender, System.EventArgs e)
        {
            MiMagamQuery();
            MagamQuery();
        }

        private void btnCommentForm_Click(object sender, System.EventArgs e)
        {
            string bunho = grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho");
            if (bunho == "")
            {
                MessageBox.Show("患者番号を入力してください。");
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", bunho);

            XScreen.OpenScreenWithParam(this, "DRGS", "DRG9040U01", ScreenOpenStyle.PopUpFixed, openParams);
        }


        #region MagaMain
        private void btnMagam_Click(object sender, System.EventArgs e)
        {
            btnMagam.Enabled = false;
            
            Magam();
            MiMagamQuery();
            
            btnMagam.Enabled = true;

        }

        private void Magam()
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            for (int i = 0; i < grdPaQuery.RowCount; i++)
            {
                if (grdPaQuery.GetItemString(i, "magam_yn") == "Y")
                {
                    inputList.Clear();
                    outputList.Clear();

                    inputList.Add(grdPaQuery.GetItemString(i, "bunho"));   //I_BUNHO
                    inputList.Add(dtpFromDate.GetDataValue().Replace("-", "/"));   //I_FROM_DATE
                    inputList.Add(dtpFromDate.GetDataValue().Replace("-", "/"));   //I_TO_DATE
                    inputList.Add("");          //I_GWA
                    inputList.Add(grdPaQuery.GetItemString(i, "doctor"));   //I_DOCTOR
                    inputList.Add("Y");     //I_JUSA_YN
                    inputList.Add(grdPaQuery.GetItemString(i, "ho_dong1"));  //I_CHULGO_BUSEO
                    inputList.Add(UserInfo.UserID);        //I_MAGAM_USER
                    inputList.Add("N");     //I_JUNINP_YN 

                    //마감
                    if (Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_INP_HO_DONG", inputList, outputList))
                    {
                        //처방전 출력
                        DrgPrint(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), outputList[0].ToString(), "");
                    }
                    else
                    {
                        MessageBox.Show(Service.ErrFullMsg);
                    }
                }
            }
        }

        private void xTabControl1_SelectionChanged(object sender, System.EventArgs e)
        {
            if (xTabControl1.SelectedIndex == 0)
            {
                lbDate.Text = "オーダ日";
                dtpToDate.Visible = false;
                xLabel1.Visible = false;
                dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
                dtpToDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(6));


                MiMagamQuery();
            }
            if (xTabControl1.SelectedIndex == 1)
            {
                lbDate.Text = "締切日付";
                dtpToDate.Visible = false;
                xLabel1.Visible = false;
                dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());

                MagamQuery();
            }
        }
        #endregion

        private void grdMagamPaQuery_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            grdMagamOrder.Visible = false;
            grdMagamJUSAOrder.Visible = true;

            grdMagamJUSAOrder.QueryLayout(false);
        }

        private void xButton4_Click(object sender, System.EventArgs e)
        {
            string drg_bunho = "", jubsu_date = "";

            if (grdMagamPaQuery.CurrentRowNumber < 0) return;
            jubsu_date = grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "jubsu_date");
            drg_bunho = grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "drg_bunho");

            if (XMessageBox.Show("締切取消し実行を続きますか。", "締切取消し", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();
                inputList.Add(jubsu_date);
                inputList.Add(drg_bunho);
                inputList.Add(UserInfo.UserID);

                if (!Service.ExecuteProcedure("PR_DRG_INP_DRG_BUNHO_CANCEL", inputList, outputList))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                }
            }

            MagamQuery();
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    MiMagamQuery();
                    break;
            }
        }

        private void xButtonList2_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    MagamQuery();
                    break;
            }
        }

        /// <summary>
        /// 처방전 출력
        /// 
        /// </summary>
        /// <param name="ar_JubsuDate"></param>
        /// <param name="ar_DrgBunho"></param>
        /// <param name="ar_MagamGubun"></param>
        private void DrgPrint(string ar_JubsuDate, string ar_DrgBunho, string ar_PrintGubun)
        {
            int row;

            //주사
            #region 약국용
   //         dw_print.DataWindowObject = "d_drg3010_4";

   //         dw_print.Reset();

            // 오다 내역 조회
            if (DsvJusaOrderPrint(ar_JubsuDate, ar_DrgBunho, ar_PrintGubun))
            {
                if (layJusaOrderPrint.RowCount > 0)
     //               dw_print.FillChildData("dw_1", layJusaOrderPrint.LayoutTable);
    //            else
                    return;
            }
            // comment 조회
            if (DsvOrderJungbo(ar_JubsuDate, ar_DrgBunho))
            {
  //              dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);
            }

            if (layOrderJungbo.RowCount < 1)
            {
                row = layOrderJungbo.InsertRow(0);
                layOrderJungbo.SetItemValue(row, "bar_drg_bunho", ar_JubsuDate.Replace("/", "") + ar_DrgBunho);
  //              dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);
            }

    //        dw_print.AcceptText();
            //if (dw_print.RowCount > 0)
            //    dw_print.Print();
            //else
            //    return;
            #endregion

            #region 병동용
            //dw_jusa.DataWindowObject = "d_drg3010_jusa_ho_dong_all";

            //dw_jusa.Reset();

            //// 오다 내역 조회
            //dw_jusa.FillData(layJusaOrderPrint.LayoutTable);

            //dw_jusa.AcceptText();
            //if (dw_jusa.RowCount > 0)
            //    dw_jusa.Print();
            //else
            //    return;
            #endregion

            if (ar_PrintGubun != "R")
            {
                #region 주사라벨


                DsvJusaLabel(ar_JubsuDate, ar_DrgBunho);

                //string origin_print = SetPrint(dw_lable, false);
                //string print_name = SetPrint(dw_lable, true);

                //// lable print set
                //try
                //{
                //    if (print_name != "")
                //        IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name);

                //    // print label
                //    DsvJusaLabel(ar_JubsuDate, ar_DrgBunho);


                //}
                //catch
                //{ }
                //finally
                //{
                //    // 기본프린터 set
                //    if (origin_print != "")
                //        IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
                //}
                #endregion
            }
        }

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
                              ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                  JUBSU_DATE
                              ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                  ORDER_DATE
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
                         WHERE A.JUBSU_DATE            = :f_jubsu_date
                           AND A.DRG_BUNHO             = :f_drg_bunho
                           AND A.BUNRYU1               IN ('4')
                           --AND NVL(A.DC_YN,'N')      = 'N'
                           --AND NVL(A.BANNAB_YN,'N')  = 'N'
                           AND B.JAERYO_CODE        (+)= A.JAERYO_CODE
                           AND C.BOGYONG_CODE       (+)= A.BOGYONG_CODE
                           AND D.BUNHO                 = A.BUNHO
                           AND E.JUBSU_DATE            = A.JUBSU_DATE
                           AND E.DRG_BUNHO             = A.DRG_BUNHO
                           AND E.FKOCS2003             = A.FKOCS2003
                         ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')";
            BindVarCollection bindVars = new BindVarCollection();
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
                                  ,FN_DRG_LOAD_NALSU_CNT(A.BUNHO, A.ORDER_DATE, 'I', A.JAERYO_CODE)                               JUSA_NALSU
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
                               AND A.BUNRYU1            IN ('4')
                               -- AND NVL(A.DC_YN,'N')     = 'N'
                               -- AND NVL(A.BANNAB_YN,'N') = 'N'
                               AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                               AND A.JAERYO_CODE        = D.JAERYO_CODE(+)
                               AND E.JUBSU_DATE         = A.JUBSU_DATE
                               AND E.DRG_BUNHO          = A.DRG_BUNHO
                               AND E.FKOCS2003          = A.FKOCS2003
                               AND C.PKOCS2003          = A.FKOCS2003
                               AND E.SERIAL_V           = :f_serial_text
                               AND A.ORDER_DATE BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
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

                        //반납건 추가 조회
                        bindVars.Remove("f_serial_v");
                        bindVars.Add("f_serial_v", o_serial_text);
                        bindVars.Add("f_fkocs2003", o_fkocs2003);

                        cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
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
                                  ,FN_DRG_LOAD_NALSU_CNT(A.BUNHO, A.ORDER_DATE, 'I', A.JAERYO_CODE)                               JUSA_NALSU
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
                               AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                               AND A.JAERYO_CODE        = D.JAERYO_CODE(+)
                               AND C.PKOCS2003          = A.FKOCS2003
                               AND A.ORDER_DATE BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
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
                               AND A.BUNRYU1            IN ('4')
                               AND NVL(A.DC_YN,'N')     = 'N'
                               AND NVL(A.BANNAB_YN,'N') = 'N'
                               AND TRIM(C.ORDER_REMARK) IS NOT NULL   -- COMMENT 조회
                               AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                               AND A.JAERYO_CODE        = D.JAERYO_CODE(+)
                               AND E.JUBSU_DATE         = A.JUBSU_DATE
                               AND E.DRG_BUNHO          = A.DRG_BUNHO
                               AND C.PKOCS2003          = A.FKOCS2003
                               AND E.FKOCS2003          = A.FKOCS2003
                               AND E.SERIAL_V           = :f_serial_text
                               AND A.ORDER_DATE BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
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
                XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
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
                         WHERE A.JUBSU_DATE     = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.DRG_BUNHO      = :f_drg_bunho
                           AND B.FKOCS          = A.FKOCS2003
                           AND C.JAERYO_CODE (+)= A.JAERYO_CODE
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
                         WHERE A.JUBSU_DATE     = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.DRG_BUNHO      = :f_drg_bunho
                           AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                           AND NVL(C.CHKD,'N')  = 'Y'
                           AND D.FKOCS2003(+)   = A.FKOCS2003
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
                         WHERE A.JUBSU_DATE    = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.DRG_BUNHO     = :f_drg_bunho
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
                         WHERE A.JUBSU_DATE    = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.DRG_BUNHO     = :f_drg_bunho
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
                                                  WHERE A.JUBSU_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                                    AND A.DRG_BUNHO   = :f_drg_bunho", bindVars);
                    if (retVal == null)
                    {
                        XMessageBox.Show(Service.ErrFullMsg + "\n\r" + "データがありません。");
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
            string o_hope_date = string.Empty;
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
            
            layJusaLable.Reset();

            /* DRGPRINT_I_JUSA_LABLE_CUR */
            cmdText = @"SELECT A.BUNHO                                             BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))                         DRG_BUNHO
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )    ORDER_DATE_TEXT
                              ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                  JUBSU_DATE
                              ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                  ORDER_DATE
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
                         WHERE A.JUBSU_DATE            = :f_jubsu_date
                           AND A.DRG_BUNHO             = :f_drg_bunho
                           AND A.BUNRYU1               = '4'
                           AND NVL(A.DC_YN,'N')        = 'N'
                           AND NVL(A.BANNAB_YN,'N')    = 'N'
                           AND B.JAERYO_CODE        (+)= A.JAERYO_CODE
                           AND C.BOGYONG_CODE       (+)= A.BOGYONG_CODE
                           AND D.BUNHO                 = A.BUNHO
                           AND E.JUBSU_DATE            = A.JUBSU_DATE
                           AND E.DRG_BUNHO             = A.DRG_BUNHO
                           AND E.FKOCS2003             = A.FKOCS2003
                         GROUP BY A.BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )
                              ,A.JUBSU_DATE
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
                                      AND A.DIVIDE            >= :k 
                                      AND A.BUNRYU1            IN ('4')
                                      AND NVL(A.DC_YN,'N')     = 'N'
                                      AND NVL(A.BANNAB_YN,'N') = 'N'
                                      AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                                      AND C.PKOCS2003          = A.FKOCS2003
                                      AND E.JUBSU_DATE         = A.JUBSU_DATE
                                      AND E.DRG_BUNHO          = A.DRG_BUNHO
                                      AND E.FKOCS2003          = A.FKOCS2003
                                      AND E.SERIAL_V           = :f_serial_text
                                      AND A.ORDER_DATE BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
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
                            layJusaLable.SetItemValue(rowNum, "age", o_age);
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
                            layJusaLable.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                            layJusaLable.SetItemValue(rowNum, "rp2", o_rp2);
                            layJusaLable.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                            layJusaLable.SetItemValue(rowNum, "line", o_line);
                        }
                    }

  //                  dw_lable.Reset();
   //                 dw_lable.FillData(layJusaLable.LayoutTable);

  //                  SetPrint(dw_lable, true);

                    //if (dw_lable.RowCount > 0)
                    //    dw_lable.Print();
                
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

        #region SetPrint
        private string SetPrint(XDataWindow dw_print, bool lable_yn)
        {
            string print_name = IHIS.Framework.PrintHelper.GetDefaultPrinterName();

            if (lable_yn)
            {
                foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    if (s.IndexOf("SATO") >= 0)
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

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            string drg_bunho = "", jubsu_date = "";

            if (grdMagamJUSAOrder.CurrentRowNumber < 0) return;
            jubsu_date = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "jubsu_date");
            drg_bunho = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "drg_bunho");

            DrgPrint(jubsu_date, drg_bunho, "R");
        }

        private void xButton1_Click(object sender, System.EventArgs e)
        {
            string bunho = "";

            if (rbxBunryu1.Checked)
            {
                if (grdMagamOrder.CurrentRowNumber < 0) return;
                bunho = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "bunho");
            }
            //주사
            if (rbxBunryu2.Checked)
            {
                if (grdMagamJUSAOrder.CurrentRowNumber < 0) return;
                bunho = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "bunho");
            }

            if (bunho == "")
            {
                MessageBox.Show("患者番号を入力してください。");
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", bunho);

            XScreen.OpenScreenWithParam(this, "DRGS", "DRG9040U01", ScreenOpenStyle.PopUpFixed, openParams);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            grdMagamJUSAOrder.QueryLayout(false);

        }

        private void dtpFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (xTabControl1.SelectedIndex == 0)
            {
                lbDate.Text = "オーダ日";
                dtpToDate.Visible = false;
                xLabel1.Visible = false;

                MiMagamQuery();
            }
            if (xTabControl1.SelectedIndex == 1)
            {
                lbDate.Text = "締切日付";
                dtpToDate.Visible = false;
                xLabel1.Visible = false;

                MagamQuery();
            }
        }

        private void xButton2_Click(object sender, System.EventArgs e)
        {
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("DRGS", "DRG3010P89");

            if (aScreen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("order_date", grdMiMagamJUSAOrder.GetItemString(grdMiMagamJUSAOrder.CurrentRowNumber, "order_date"));
                openParams.Add("bunho", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho"));
                openParams.Add("doctor", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "doctor"));
                openParams.Add("ho_dong", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "ho_dong"));

                XScreen.OpenScreenWithParam(this, "DRGS", "DRG3010P89", ScreenOpenStyle.ResponseSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("DRGS", "DRG3010P89");

            if (aScreen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("order_date", grdMiMagamJUSAOrder.GetItemString(grdMiMagamJUSAOrder.CurrentRowNumber, "order_date"));
                openParams.Add("bunho", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho"));
                openParams.Add("doctor", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "doctor"));
                openParams.Add("ho_dong", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "ho_dong"));

                XScreen.OpenScreenWithParam(this, "DRGS", "DRG3010P89", ScreenOpenStyle.ResponseSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }
        }

        private void xPatientBox1_PatientSelected(object sender, System.EventArgs e)
        {
            MagamQuery();

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            MiMagamQuery();

            for (int i = 0; i < grdPaQuery.RowCount; i++)
            {
                grdPaQuery.SetItemValue(i, "magam_yn", "Y");
            }
            grdPaQuery.AcceptData();

            Magam();
        }

        private void chkPrint_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkPrint.GetDataValue() == "Y")
                timer1.Start();
            else
                timer1.Stop();
        }

        #region 각 그리드에 바인드변수 설정
        private void grdPaQuery_QueryStarting(object sender, CancelEventArgs e)
        {
            try
            {
                grdPaQuery.SetBindVarValue("f_bunho", paBox.BunHo);
                grdPaQuery.SetBindVarValue("f_ho_dong", cboHoDong.GetDataValue());
                grdPaQuery.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue().ToString().Replace("/", "").Replace("-", "").Substring(0, 8));
                grdPaQuery.SetBindVarValue("f_hosp_code", mHospCode);
            }
            catch { }
        }

        private void grdMiMagamJUSAOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMiMagamJUSAOrder.SetBindVarValue("f_bunho", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber,"bunho"));
            grdMiMagamJUSAOrder.SetBindVarValue("f_ho_dong", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "ho_dong1"));
            grdMiMagamJUSAOrder.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue().ToString().Replace("/", "").Replace("-", "").Substring(0, 8));
            grdMiMagamJUSAOrder.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdMagamJUSAOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMagamJUSAOrder.SetBindVarValue("f_jubsu_date", grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "jubsu_date"));
            grdMagamJUSAOrder.SetBindVarValue("f_drg_bunho", grdMagamPaQuery.GetItemString(grdMagamPaQuery.CurrentRowNumber, "drg_bunho"));
            grdMagamJUSAOrder.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdMagamPaQuery_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMagamPaQuery.SetBindVarValue("f_magam_date", dtpFromDate.GetDataValue().Replace("/", "").Replace("-", ""));
            grdMagamPaQuery.SetBindVarValue("f_bunho", paBox.BunHo);
            grdMagamPaQuery.SetBindVarValue("f_ho_dong", cboHoDong.GetDataValue());
            grdMagamPaQuery.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdMiMagamOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMiMagamOrder.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue().Replace("-", "").Replace("/", ""));
            grdMiMagamOrder.SetBindVarValue("f_bunho", paBox.BunHo);
            grdMiMagamOrder.SetBindVarValue("f_ho_dong", cboHoDong.GetDataValue());
            grdMiMagamOrder.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        private void cboHoDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xTabControl1.SelectedIndex == 0)
            {
                //lbDate.Text = "オーダ日";
                //dtpToDate.Visible = false;
                //xLabel1.Visible = false;

                MiMagamQuery();
            }
            if (xTabControl1.SelectedIndex == 1)
            {
                //lbDate.Text = "締切日付";
                //dtpToDate.Visible = false;
                //xLabel1.Visible = false;

                MagamQuery();
            }
        }

        #region 그리드 믹스 표시
        private void grdMiMagamJUSAOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);
        }

        private void grdMagamJUSAOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);
        }
        #endregion

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

        #region 반납건 표시
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

        #region Command 간호 확인시 자동 처방전 뽑기

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "nurse_confirm": /* 간호확인시 주사 처방전 뽑아야할 경우 */

                    string cmdStr = @"SELECT 'Y'  FROM DRG9043
                    WHERE TO_CHAR(SYSDATE,'YYYYMMDDHH24MISS') BETWEEN TO_CHAR(START_DATE,'YYYYMMDD') || START_TIME
                              AND TO_CHAR(NVL(END_DATE,SYSDATE),'YYYYMMDD') || NVL(END_TIME,'9999')
                      AND CANCEL_DATE IS NULL
                      AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()";
                    object retVal = Service.ExecuteScalar(cmdStr);

                    if (!TypeCheck.IsNull(retVal) && retVal.ToString() == "Y")
                    {
                        ArrayList inputList = new ArrayList();
                        ArrayList outputList = new ArrayList();

                        if (commandParam.Contains("bunho"))
                        {
                            inputList.Add(commandParam["bunho"].ToString());
                        }
                        else
                        {
                            return null;
                        }

                        if (commandParam.Contains("order_date"))
                        {
                            inputList.Add(commandParam["order_date"].ToString());  //I_FROM_DATE
                            inputList.Add(commandParam["order_date"].ToString());    //I_TO_DATE
                            inputList.Add("");   //I_GWA
                            inputList.Add("");   //I_DOCTOR
                            inputList.Add("Y");   //I_JUSA_YN
                        }
                        else
                        {
                            return null;
                        }

                        if (commandParam.Contains("ho_dong"))
                        {
                            inputList.Add(commandParam["ho_dong"].ToString());  //I_CHULGO_BUSEO
                            inputList.Add(UserInfo.UserID);        //I_MAGAM_USER
                            inputList.Add("N");     //I_JUNINP_YN 
                        }
                        else
                        {
                            return null;
                        }

                        // 마감
                        if (Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_INP_HO_DONG", inputList, outputList))
                        {
                            // 처방전 출력
                            DrgPrint(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), outputList[0].ToString(), "");
                        }
                        else
                        {
                            MessageBox.Show(Service.ErrFullMsg);
                        }
                    }

                    break;

                default:
                    break;
            }

            return base.Command(command, commandParam);
        }

        #endregion

        #region 라벨 재출력
        private void btnLable_Click(object sender, EventArgs e)
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
        #endregion

    }
}


