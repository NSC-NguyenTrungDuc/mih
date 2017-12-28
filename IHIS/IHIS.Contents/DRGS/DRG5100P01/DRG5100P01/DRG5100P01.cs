#region 사용 NameSpace 지정

using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Drgs;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.DRGS.Properties;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using System.Text.RegularExpressions;

#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG5100P01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG5100P01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel PnlLeft;
        private IHIS.Framework.XFlatRadioButton rbx1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XPanel pnlFillDown;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGrid grdPaid;
        private IHIS.Framework.XPanel pnlLeftInTop;
        private IHIS.Framework.XFlatRadioButton rbx2;
        private IHIS.Framework.XPanel pnlFillInTop;
        private IHIS.Framework.XPatientBox paid;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
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
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XButton btnBoryu;
        private IHIS.Framework.XButton btnScreenLock;
 //       private IHIS.Framework.XDataWindow dw1;
        private IHIS.Framework.MultiLayout layLabel;
        private System.Windows.Forms.Panel pnlFillIn1;
        private System.Windows.Forms.Panel pnlFillIn2;
        private System.Windows.Forms.Panel pnlFillIn3;
        private IHIS.Framework.MultiLayout layOrder;
        private IHIS.Framework.XTextBox txtBogyongName;
        private IHIS.Framework.XTextBox txtCautionName;
        private IHIS.Framework.XTextBox txtOrderRemark;
        private IHIS.Framework.XMstGrid grdOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XEditGrid grdOrderList;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XButton btnBoryuDel;
        private IHIS.Framework.XCheckBox cbxATCYN;
        private IHIS.Framework.XFlatRadioButton rbx3;
        private IHIS.Framework.XDWWorker xdwWorker1;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private System.Windows.Forms.GroupBox groupBox1;
        private IHIS.Framework.XFlatRadioButton xrbOrder;
        private IHIS.Framework.XFlatRadioButton xrbJubsu;
        private IHIS.Framework.XDisplayBox dbxSuname2;
        private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XLabel xLabel26;
        private IHIS.Framework.XDisplayBox dbxAge;
        private IHIS.Framework.XDisplayBox dbxGwa;
        private IHIS.Framework.XDisplayBox dbxSex;
        private IHIS.Framework.XLabel xLabel29;
        private IHIS.Framework.XDisplayBox dbxDoctor;
        private IHIS.Framework.XLabel xLabel36;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private System.Windows.Forms.GroupBox groupBox2;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XButton btnATC;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XButton btnEndDrg;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell98;
        private IHIS.Framework.XEditGridCell xEditGridCell106;
        private IHIS.Framework.XEditGridCell xEditGridCell107;
        private IHIS.Framework.XEditGridCell xEditGridCell108;
        private IHIS.Framework.MultiLayout layOrderJungbo;
        private IHIS.Framework.MultiLayout layOrderPrint;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XFlatLabel xFlatLabel1;
        private IHIS.Framework.XBuseoCombo xBuseoCombo;
        private IHIS.Framework.XCheckBox chbDataInterface;
        private System.Windows.Forms.Button button1;
 //       private IHIS.Framework.XDataWindow dw_Anti;
        private IHIS.Framework.MultiLayout layAntiData;
        private IHIS.Framework.XDatePicker dtpFromDate;
        private IHIS.Framework.XEditGridCell xEditGridCell109;
        private IHIS.Framework.XDatePicker dtpToDate;
        private IHIS.Framework.XFlatLabel xFlatLabel2;
        private IHIS.Framework.XFlatLabel xFlatLabel3;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnAutoStop;
        private System.Windows.Forms.Timer timer1;
        private IHIS.Framework.XLabel lbTime;
        private IHIS.Framework.XButton btnBatPrint;
        private IHIS.Framework.XButton btnLable;
        private IHIS.Framework.MultiLayout layNebokLabel;
 //       private IHIS.Framework.XDataWindow dw_lable;
        private IHIS.Framework.XTextBox tbxTimer;
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
        private XLabel lbSuname;
        private Splitter splitter2;
        private Splitter splitter1;
        private XButton btnExpand;
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
        private XCheckBox cbxAutoJubsu;
        private XTextBox txtTimeInterval;
        private XLabel xLabel6;
        private XDictComboBox cboTime;
        private MultiLayout layBongtuLabel;
        private XButton btnBongtuLabePrt;
 //       private XDataWindow dw2;
        private XEditGridCell xEditGridCell112;
        private MultiLayout layBongtuInfo;
        private XButton btnPrintSetup;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintDialog printDialog1;
        private SingleLayout layPrintName;
        private SingleLayoutItem singleLayoutItem2;
        private XButton btnPrescripPrt;
        private XButton btnPrescripRePrt;
        private XButton btnUpdateComment;
        private XButton btnUseTimeChk;
        private XEditGridCell xEditGridCell113;
        private XEditGridCell xEditGridCell114;
        private XEditGridCell xEditGridCell115;
        private XButton btnProcess;
        private XButton btnQuery;
        private MultiLayout mlayConstantInfo;
        private XEditGridCell xEditGridCell116;
        private XButton btnGeneric;
        private XEditGridCell xEditGridCell117;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private XEditGridCell xEditGridCell118;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem19;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell120;
        private Panel panel1;
        private System.ComponentModel.IContainer components = null;
        string o_hosp_name = string.Empty;
        string o_jaedan_name = string.Empty;
        string hosp_address1 = string.Empty;
        string _tel = string.Empty;
        string _address = string.Empty;
        string _address1 = string.Empty;

        public DRG5100P01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            try
            {
                InitializeComponent();
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                Size = new System.Drawing.Size(rc.Width - 45, rc.Height - 135);

                //MED-12656
                if (NetInfo.Language == LangMode.Jr)
                {
                    this.dtpFromDate.IsJapanYearType = true;
                    this.dtpToDate.IsJapanYearType = true;
                }

                GetDataScreenOpen();
                Point x = xButtonList1.Location;
                grdOrderList.ExecuteQuery = grdOrderList_getData;
                if (CheckAct())
                {
                    cbxATCYN.Visible = true;
                    btnATC.Visible = true;
                }
                else
                {
                    cbxATCYN.Visible = false;
                    btnATC.Visible = false;
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show("[" + ex.Message + "] [" + ex.StackTrace + "]");
            }

            if (NetInfo.Language == LangMode.Vi)
            {
    //            this.dw1.LibraryList = "DRGS\\drgs.drg5100p01_vn.pbd";
            }

            //https://sofiamedix.atlassian.net/browse/MED-15053
            if (NetInfo.Language == LangMode.Jr)
            {
                SetSizeForColumn();
            }
        }

        private void SetSizeForColumn()
        {
            grdPaid.AutoSizeColumn(xEditGridCell109.Col, 35);
            grdPaid.AutoSizeColumn(xEditGridCell2.Col, 71);
            grdPaid.AutoSizeColumn(xEditGridCell22.Col, 88);
            grdPaid.AutoSizeColumn(xEditGridCell25.Col, 28);
            grdPaid.AutoSizeColumn(xEditGridCell78.Col, 20);
            grdPaid.AutoSizeColumn(xEditGridCell80.Col, 20);

            grdOrder.AutoSizeColumn(xEditGridCell1.Col, 20);
            grdOrder.AutoSizeColumn(xEditGridCell3.Col, 38);
            grdOrder.AutoSizeColumn(xEditGridCell4.Col, 100);
            grdOrder.AutoSizeColumn(xEditGridCell5.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell30.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell31.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell117.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell6.Col, 43);
            grdOrder.AutoSizeColumn(xEditGridCell8.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell7.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell74.Col, 60);
            grdOrder.AutoSizeColumn(xEditGridCell81.Col, 60);
            grdOrder.AutoSizeColumn(xEditGridCell21.Col, 33);

            grdOrderList.AutoSizeColumn(xEditGridCell59.Col, 25);
            grdOrderList.AutoSizeColumn(xEditGridCell112.Col, 24);
            grdOrderList.AutoSizeColumn(xEditGridCell61.Col, 74);
            grdOrderList.AutoSizeColumn(xEditGridCell39.Col, 265);
            grdOrderList.AutoSizeColumn(xEditGridCell62.Col, 48);
            grdOrderList.AutoSizeColumn(xEditGridCell64.Col, 25);
            grdOrderList.AutoSizeColumn(xEditGridCell37.Col, 30);
            grdOrderList.AutoSizeColumn(xEditGridCell17.Col, 30);
            grdOrderList.AutoSizeColumn(xEditGridCell63.Col, 29);
            grdOrderList.AutoSizeColumn(xEditGridCell94.Col, 117);
            grdOrderList.AutoSizeColumn(xEditGridCell108.Col, 22);
            grdOrderList.AutoSizeColumn(xEditGridCell66.Col, 22);
            grdOrderList.AutoSizeColumn(xEditGridCell107.Col, 25);
            grdOrderList.AutoSizeColumn(xEditGridCell106.Col, 22);
            grdOrderList.AutoSizeColumn(xEditGridCell14.Col, 26);
            grdOrderList.AutoSizeColumn(xEditGridCell82.Col, 26);
            grdOrderList.AutoSizeColumn(xEditGridCell98.Col, 25);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG5100P01));
            this.PnlLeft = new IHIS.Framework.XPanel();
            this.btnExpand = new IHIS.Framework.XButton();
            this.grdPaid = new IHIS.Framework.XEditGrid();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.pnlLeftInTop = new IHIS.Framework.XPanel();
            this.lbSuname = new IHIS.Framework.XLabel();
            this.xBuseoCombo = new IHIS.Framework.XBuseoCombo();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEndDrg = new IHIS.Framework.XButton();
            this.rbx1 = new IHIS.Framework.XFlatRadioButton();
            this.btnLable = new IHIS.Framework.XButton();
            this.rbx2 = new IHIS.Framework.XFlatRadioButton();
            this.cbxAutoJubsu = new IHIS.Framework.XCheckBox();
            this.rbx3 = new IHIS.Framework.XFlatRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.lbTime = new IHIS.Framework.XLabel();
            this.btnAutoStop = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.txtTimeInterval = new IHIS.Framework.XTextBox();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.tbxTimer = new IHIS.Framework.XTextBox();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.xrbOrder = new IHIS.Framework.XFlatRadioButton();
            this.xrbJubsu = new IHIS.Framework.XFlatRadioButton();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.cbxATCYN = new IHIS.Framework.XCheckBox();
            this.btnBatPrint = new IHIS.Framework.XButton();
            this.btnPrintSetup = new IHIS.Framework.XButton();
            this.paid = new IHIS.Framework.XPatientBox();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnGeneric = new IHIS.Framework.XButton();
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
            this.txtBogyongName = new IHIS.Framework.XTextBox();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.txtCautionName = new IHIS.Framework.XTextBox();
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
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.txtOrderRemark = new IHIS.Framework.XTextBox();
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
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.grdOrder = new IHIS.Framework.XMstGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.chbDataInterface = new IHIS.Framework.XCheckBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.pnlFillDown = new IHIS.Framework.XPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlFillIn1 = new System.Windows.Forms.Panel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pnlFillIn2 = new System.Windows.Forms.Panel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.pnlFillIn3 = new System.Windows.Forms.Panel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlFillInTop = new IHIS.Framework.XPanel();
            this.dbxSuname2 = new IHIS.Framework.XDisplayBox();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.dbxAge = new IHIS.Framework.XDisplayBox();
            this.dbxGwa = new IHIS.Framework.XDisplayBox();
            this.dbxSex = new IHIS.Framework.XDisplayBox();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.dbxDoctor = new IHIS.Framework.XDisplayBox();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.btnATC = new IHIS.Framework.XButton();
            this.btnBongtuLabePrt = new IHIS.Framework.XButton();
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
            this.btnQuery = new IHIS.Framework.XButton();
            this.btnProcess = new IHIS.Framework.XButton();
            this.btnUseTimeChk = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.btnUpdateComment = new IHIS.Framework.XButton();
            this.btnPrescripRePrt = new IHIS.Framework.XButton();
            this.btnPrescripPrt = new IHIS.Framework.XButton();
            this.btnScreenLock = new IHIS.Framework.XButton();
            this.btnBoryuDel = new IHIS.Framework.XButton();
            this.btnBoryu = new IHIS.Framework.XButton();
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
            this.xdwWorker1 = new IHIS.Framework.XDWWorker();
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
            this.layAntiData = new IHIS.Framework.MultiLayout();
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
            this.layBongtuLabel = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.layBongtuInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.layPrintName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.mlayConstantInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.PnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaid)).BeginInit();
            this.pnlLeftInTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xBuseoCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.pnlFillDown.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFillIn1.SuspendLayout();
            this.pnlFillIn2.SuspendLayout();
            this.pnlFillIn3.SuspendLayout();
            this.pnlFillInTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAntiData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNebokLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAutoJubsu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBongtuLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBongtuInfo)).BeginInit();
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
            this.ImageList.Images.SetKeyName(13, "icon.png");
            this.ImageList.Images.SetKeyName(14, "조회.gif");
            // 
            // PnlLeft
            // 
            resources.ApplyResources(this.PnlLeft, "PnlLeft");
            this.PnlLeft.Controls.Add(this.btnExpand);
            this.PnlLeft.Controls.Add(this.grdPaid);
            this.PnlLeft.Controls.Add(this.pnlLeftInTop);
            this.PnlLeft.DrawBorder = true;
            this.PnlLeft.Name = "PnlLeft";
            this.toolTip.SetToolTip(this.PnlLeft, resources.GetString("PnlLeft.ToolTip"));
            // 
            // btnExpand
            // 
            resources.ApplyResources(this.btnExpand, "btnExpand");
            this.btnExpand.ImageIndex = 11;
            this.btnExpand.ImageList = this.ImageList;
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip.SetToolTip(this.btnExpand, resources.GetString("btnExpand.ToolTip"));
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // grdPaid
            // 
            resources.ApplyResources(this.grdPaid, "grdPaid");
            this.grdPaid.ApplyPaintEventToAllColumn = true;
            this.grdPaid.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell119,
            this.xEditGridCell2,
            this.xEditGridCell26,
            this.xEditGridCell109,
            this.xEditGridCell22,
            this.xEditGridCell25,
            this.xEditGridCell78,
            this.xEditGridCell80});
            this.grdPaid.ColPerLine = 8;
            this.grdPaid.ColResizable = true;
            this.grdPaid.Cols = 9;
            this.grdPaid.ExecuteQuery = null;
            this.grdPaid.FixedCols = 1;
            this.grdPaid.FixedRows = 1;
            this.grdPaid.HeaderHeights.Add(41);
            this.grdPaid.ImageList = this.ImageList;
            this.grdPaid.Name = "grdPaid";
            this.grdPaid.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaid.ParamList")));
            this.grdPaid.ResizableAtOnlyHeader = false;
            this.grdPaid.RowHeaderVisible = true;
            this.grdPaid.Rows = 2;
            this.grdPaid.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.toolTip.SetToolTip(this.grdPaid, resources.GetString("grdPaid.ToolTip"));
            this.grdPaid.ToolTipActive = true;
            this.grdPaid.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaid_RowFocusChanged);
            this.grdPaid.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPaid_GridCellPainting);
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "trial_yn";
            this.xEditGridCell119.CellWidth = 96;
            this.xEditGridCell119.Col = 2;
            this.xEditGridCell119.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "order_date";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell26.CellWidth = 1;
            this.xEditGridCell26.Col = 1;
            this.xEditGridCell26.EnableSort = true;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.SuppressRepeating = true;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "drg_bunho";
            this.xEditGridCell109.CellWidth = 71;
            this.xEditGridCell109.Col = 3;
            this.xEditGridCell109.EnableSort = true;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsReadOnly = true;
            this.xEditGridCell109.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "suname";
            this.xEditGridCell22.CellWidth = 88;
            this.xEditGridCell22.Col = 5;
            this.xEditGridCell22.EnableSort = true;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell25.CellName = "boryu_yn";
            this.xEditGridCell25.CellWidth = 41;
            this.xEditGridCell25.Col = 6;
            this.xEditGridCell25.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3});
            this.xEditGridCell25.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.ImageList = this.ImageList;
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ImageIndex = 1;
            this.xComboItem3.ValueItem = "Y";
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "order_remark";
            this.xEditGridCell78.CellWidth = 54;
            this.xEditGridCell78.Col = 7;
            this.xEditGridCell78.DisplayMemoText = true;
            this.xEditGridCell78.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsReadOnly = true;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "drg_remark";
            this.xEditGridCell80.CellWidth = 60;
            this.xEditGridCell80.Col = 8;
            this.xEditGridCell80.DisplayMemoText = true;
            this.xEditGridCell80.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsReadOnly = true;
            // 
            // pnlLeftInTop
            // 
            resources.ApplyResources(this.pnlLeftInTop, "pnlLeftInTop");
            this.pnlLeftInTop.Controls.Add(this.lbSuname);
            this.pnlLeftInTop.Controls.Add(this.xBuseoCombo);
            this.pnlLeftInTop.Controls.Add(this.xFlatLabel1);
            this.pnlLeftInTop.Controls.Add(this.paBox);
            this.pnlLeftInTop.Controls.Add(this.groupBox2);
            this.pnlLeftInTop.Controls.Add(this.groupBox1);
            this.pnlLeftInTop.Controls.Add(this.cbxATCYN);
            this.pnlLeftInTop.DrawBorder = true;
            this.pnlLeftInTop.Name = "pnlLeftInTop";
            this.toolTip.SetToolTip(this.pnlLeftInTop, resources.GetString("pnlLeftInTop.ToolTip"));
            // 
            // lbSuname
            // 
            resources.ApplyResources(this.lbSuname, "lbSuname");
            this.lbSuname.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbSuname.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.lbSuname.Name = "lbSuname";
            this.toolTip.SetToolTip(this.lbSuname, resources.GetString("lbSuname.ToolTip"));
            // 
            // xBuseoCombo
            // 
            resources.ApplyResources(this.xBuseoCombo, "xBuseoCombo");
            this.xBuseoCombo.IsAppendAll = true;
            this.xBuseoCombo.Name = "xBuseoCombo";
            this.xBuseoCombo.TabStop = false;
            this.toolTip.SetToolTip(this.xBuseoCombo, resources.GetString("xBuseoCombo.ToolTip"));
            this.xBuseoCombo.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xBuseoCombo_DataValidating);
            // 
            // xFlatLabel1
            // 
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.toolTip.SetToolTip(this.xFlatLabel1, resources.GetString("xFlatLabel1.ToolTip"));
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.toolTip.SetToolTip(this.paBox, resources.GetString("paBox.ToolTip"));
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btnEndDrg);
            this.groupBox2.Controls.Add(this.rbx1);
            this.groupBox2.Controls.Add(this.btnLable);
            this.groupBox2.Controls.Add(this.rbx2);
            this.groupBox2.Controls.Add(this.cbxAutoJubsu);
            this.groupBox2.Controls.Add(this.rbx3);
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // btnEndDrg
            // 
            resources.ApplyResources(this.btnEndDrg, "btnEndDrg");
            this.btnEndDrg.ImageIndex = 2;
            this.btnEndDrg.ImageList = this.ImageList;
            this.btnEndDrg.Name = "btnEndDrg";
            this.btnEndDrg.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip.SetToolTip(this.btnEndDrg, resources.GetString("btnEndDrg.ToolTip"));
            this.btnEndDrg.Click += new System.EventHandler(this.xButton1_Click_1);
            // 
            // rbx1
            // 
            resources.ApplyResources(this.rbx1, "rbx1");
            this.rbx1.Checked = true;
            this.rbx1.CheckedValue = "1";
            this.rbx1.Name = "rbx1";
            this.rbx1.TabStop = true;
            this.toolTip.SetToolTip(this.rbx1, resources.GetString("rbx1.ToolTip"));
            this.rbx1.UseVisualStyleBackColor = false;
            this.rbx1.Click += new System.EventHandler(this.rbx1_Click);
            // 
            // btnLable
            // 
            resources.ApplyResources(this.btnLable, "btnLable");
            this.btnLable.ImageIndex = 6;
            this.btnLable.ImageList = this.ImageList;
            this.btnLable.Name = "btnLable";
            this.toolTip.SetToolTip(this.btnLable, resources.GetString("btnLable.ToolTip"));
            this.btnLable.Click += new System.EventHandler(this.btnLable_Click);
            // 
            // rbx2
            // 
            resources.ApplyResources(this.rbx2, "rbx2");
            this.rbx2.CheckedValue = "2";
            this.rbx2.Name = "rbx2";
            this.toolTip.SetToolTip(this.rbx2, resources.GetString("rbx2.ToolTip"));
            this.rbx2.UseVisualStyleBackColor = false;
            this.rbx2.Click += new System.EventHandler(this.rbx2_Click);
            // 
            // cbxAutoJubsu
            // 
            resources.ApplyResources(this.cbxAutoJubsu, "cbxAutoJubsu");
            this.cbxAutoJubsu.Name = "cbxAutoJubsu";
            this.toolTip.SetToolTip(this.cbxAutoJubsu, resources.GetString("cbxAutoJubsu.ToolTip"));
            this.cbxAutoJubsu.UseVisualStyleBackColor = false;
            // 
            // rbx3
            // 
            resources.ApplyResources(this.rbx3, "rbx3");
            this.rbx3.CheckedValue = "3";
            this.rbx3.Name = "rbx3";
            this.toolTip.SetToolTip(this.rbx3, resources.GetString("rbx3.ToolTip"));
            this.rbx3.UseVisualStyleBackColor = false;
            this.rbx3.Click += new System.EventHandler(this.rbx3_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.cboTime);
            this.groupBox1.Controls.Add(this.xLabel6);
            this.groupBox1.Controls.Add(this.lbTime);
            this.groupBox1.Controls.Add(this.btnAutoStop);
            this.groupBox1.Controls.Add(this.btnAuto);
            this.groupBox1.Controls.Add(this.txtTimeInterval);
            this.groupBox1.Controls.Add(this.xFlatLabel3);
            this.groupBox1.Controls.Add(this.tbxTimer);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.xrbOrder);
            this.groupBox1.Controls.Add(this.xrbJubsu);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.xFlatLabel2);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // cboTime
            // 
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.ExecuteQuery = null;
            this.cboTime.Name = "cboTime";
            this.cboTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTime.ParamList")));
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cboTime, resources.GetString("cboTime.ToolTip"));
            this.cboTime.SelectionChangeCommitted += new System.EventHandler(this.cboTime_SelectionChangeCommitted);
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel6.Name = "xLabel6";
            this.toolTip.SetToolTip(this.xLabel6, resources.GetString("xLabel6.ToolTip"));
            // 
            // lbTime
            // 
            resources.ApplyResources(this.lbTime, "lbTime");
            this.lbTime.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbTime.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lbTime.Name = "lbTime";
            this.toolTip.SetToolTip(this.lbTime, resources.GetString("lbTime.ToolTip"));
            // 
            // btnAutoStop
            // 
            resources.ApplyResources(this.btnAutoStop, "btnAutoStop");
            this.btnAutoStop.BackColor = System.Drawing.Color.LightGray;
            this.btnAutoStop.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnAutoStop.ImageList = this.ImageList;
            this.btnAutoStop.Name = "btnAutoStop";
            this.toolTip.SetToolTip(this.btnAutoStop, resources.GetString("btnAutoStop.ToolTip"));
            this.btnAutoStop.UseVisualStyleBackColor = false;
            this.btnAutoStop.Click += new System.EventHandler(this.btnAutoStop_Click);
            // 
            // btnAuto
            // 
            resources.ApplyResources(this.btnAuto, "btnAuto");
            this.btnAuto.BackColor = System.Drawing.Color.LightGray;
            this.btnAuto.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnAuto.ImageList = this.ImageList;
            this.btnAuto.Name = "btnAuto";
            this.toolTip.SetToolTip(this.btnAuto, resources.GetString("btnAuto.ToolTip"));
            this.btnAuto.UseVisualStyleBackColor = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // txtTimeInterval
            // 
            resources.ApplyResources(this.txtTimeInterval, "txtTimeInterval");
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.toolTip.SetToolTip(this.txtTimeInterval, resources.GetString("txtTimeInterval.ToolTip"));
            this.txtTimeInterval.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtTimeInterval_DataValidating);
            // 
            // xFlatLabel3
            // 
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.Name = "xFlatLabel3";
            this.toolTip.SetToolTip(this.xFlatLabel3, resources.GetString("xFlatLabel3.ToolTip"));
            // 
            // tbxTimer
            // 
            resources.ApplyResources(this.tbxTimer, "tbxTimer");
            this.tbxTimer.Name = "tbxTimer";
            this.toolTip.SetToolTip(this.tbxTimer, resources.GetString("tbxTimer.ToolTip"));
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.toolTip.SetToolTip(this.dtpToDate, resources.GetString("dtpToDate.ToolTip"));
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // xrbOrder
            // 
            resources.ApplyResources(this.xrbOrder, "xrbOrder");
            this.xrbOrder.Checked = true;
            this.xrbOrder.CheckedText = global::IHIS.DRGS.Properties.Resources.xrbOrderChecked;
            this.xrbOrder.CheckedValue = "2";
            this.xrbOrder.Name = "xrbOrder";
            this.xrbOrder.TabStop = true;
            this.toolTip.SetToolTip(this.xrbOrder, resources.GetString("xrbOrder.ToolTip"));
            this.xrbOrder.UseVisualStyleBackColor = false;
            this.xrbOrder.Click += new System.EventHandler(this.xrbOrder_Click);
            // 
            // xrbJubsu
            // 
            resources.ApplyResources(this.xrbJubsu, "xrbJubsu");
            this.xrbJubsu.CheckedText = global::IHIS.DRGS.Properties.Resources.xrbJubsuChecked;
            this.xrbJubsu.CheckedValue = "2";
            this.xrbJubsu.Name = "xrbJubsu";
            this.toolTip.SetToolTip(this.xrbJubsu, resources.GetString("xrbJubsu.ToolTip"));
            this.xrbJubsu.UseVisualStyleBackColor = false;
            this.xrbJubsu.Click += new System.EventHandler(this.xrbOrder_Click);
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.toolTip.SetToolTip(this.dtpFromDate, resources.GetString("dtpFromDate.ToolTip"));
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpOrderDate_DataValidating);
            // 
            // xFlatLabel2
            // 
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.Name = "xFlatLabel2";
            this.toolTip.SetToolTip(this.xFlatLabel2, resources.GetString("xFlatLabel2.ToolTip"));
            // 
            // cbxATCYN
            // 
            resources.ApplyResources(this.cbxATCYN, "cbxATCYN");
            this.cbxATCYN.CheckedText = global::IHIS.DRGS.Properties.Resources.cbxATCYNText;
            this.cbxATCYN.Name = "cbxATCYN";
            this.toolTip.SetToolTip(this.cbxATCYN, resources.GetString("cbxATCYN.ToolTip"));
            this.cbxATCYN.UnCheckedText = global::IHIS.DRGS.Properties.Resources.cbxATCYNUnChecked;
            this.cbxATCYN.UseVisualStyleBackColor = false;
            // 
            // btnBatPrint
            // 
            resources.ApplyResources(this.btnBatPrint, "btnBatPrint");
            this.btnBatPrint.ImageIndex = 6;
            this.btnBatPrint.ImageList = this.ImageList;
            this.btnBatPrint.Name = "btnBatPrint";
            this.toolTip.SetToolTip(this.btnBatPrint, resources.GetString("btnBatPrint.ToolTip"));
            this.btnBatPrint.Click += new System.EventHandler(this.btnBatPrint_Click);
            // 
            // btnPrintSetup
            // 
            resources.ApplyResources(this.btnPrintSetup, "btnPrintSetup");
            this.btnPrintSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSetup.Image")));
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.toolTip.SetToolTip(this.btnPrintSetup, resources.GetString("btnPrintSetup.ToolTip"));
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // paid
            // 
            resources.ApplyResources(this.paid, "paid");
            this.paid.Name = "paid";
            this.toolTip.SetToolTip(this.paid, resources.GetString("paid.ToolTip"));
            this.paid.PatientSelected += new System.EventHandler(this.paid_PatientSelected);
            // 
            // pnlFill
            // 
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.Controls.Add(this.xPanel2);
            this.pnlFill.Controls.Add(this.splitter2);
            this.pnlFill.Controls.Add(this.xPanel1);
            this.pnlFill.Controls.Add(this.pnlFillDown);
            this.pnlFill.Controls.Add(this.pnlFillInTop);
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Name = "pnlFill";
            this.toolTip.SetToolTip(this.pnlFill, resources.GetString("pnlFill.ToolTip"));
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.btnGeneric);
            this.xPanel2.Controls.Add(this.grdOrderList);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            this.toolTip.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // btnGeneric
            // 
            resources.ApplyResources(this.btnGeneric, "btnGeneric");
            this.btnGeneric.ImageIndex = 11;
            this.btnGeneric.ImageList = this.ImageList;
            this.btnGeneric.Name = "btnGeneric";
            this.btnGeneric.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip.SetToolTip(this.btnGeneric, resources.GetString("btnGeneric.ToolTip"));
            this.btnGeneric.Click += new System.EventHandler(this.btnGeneric_Click);
            // 
            // grdOrderList
            // 
            resources.ApplyResources(this.grdOrderList, "grdOrderList");
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
            this.xEditGridCell116,
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
            this.xEditGridCell111,
            this.xEditGridCell118,
            this.xEditGridCell112});
            this.grdOrderList.ColPerLine = 18;
            this.grdOrderList.Cols = 19;
            this.grdOrderList.ControlBinding = true;
            this.grdOrderList.ExecuteQuery = null;
            this.grdOrderList.FixedCols = 1;
            this.grdOrderList.FixedRows = 1;
            this.grdOrderList.HeaderHeights.Add(36);
            this.grdOrderList.MasterLayout = this.grdOrder;
            this.grdOrderList.Name = "grdOrderList";
            this.grdOrderList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderList.ParamList")));
            this.grdOrderList.QuerySQL = resources.GetString("grdOrderList.QuerySQL");
            this.grdOrderList.RowHeaderVisible = true;
            this.grdOrderList.Rows = 2;
            this.toolTip.SetToolTip(this.grdOrderList, resources.GetString("grdOrderList.ToolTip"));
            this.grdOrderList.ToolTipActive = true;
            this.grdOrderList.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrderList_GridColumnProtectModify);
            this.grdOrderList.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOrderList_ItemValueChanging);
            this.grdOrderList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrderList_GridCellPainting);
            this.grdOrderList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPackPowder_GridColumnChanged);
            this.grdOrderList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderList_QueryStarting);
            this.grdOrderList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOrderList_QueryEnd);
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "bunho";
            this.xEditGridCell83.CellWidth = 25;
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
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
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
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
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
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
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
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
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
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
            this.xEditGridCell61.Col = 3;
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
            this.xEditGridCell17.CellWidth = 48;
            this.xEditGridCell17.Col = 9;
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
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
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
            this.xEditGridCell62.CellWidth = 54;
            this.xEditGridCell62.Col = 6;
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
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
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
            this.xEditGridCell63.CellWidth = 42;
            this.xEditGridCell63.Col = 10;
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
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
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
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
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
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
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
            this.xEditGridCell94.BindControl = this.txtBogyongName;
            this.xEditGridCell94.CellName = "bogyong_name";
            this.xEditGridCell94.CellWidth = 117;
            this.xEditGridCell94.Col = 11;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdCol = false;
            // 
            // txtBogyongName
            // 
            resources.ApplyResources(this.txtBogyongName, "txtBogyongName");
            this.txtBogyongName.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtBogyongName.Name = "txtBogyongName";
            this.txtBogyongName.Protect = true;
            this.txtBogyongName.ReadOnly = true;
            this.txtBogyongName.TabStop = false;
            this.toolTip.SetToolTip(this.txtBogyongName, resources.GetString("txtBogyongName.ToolTip"));
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.BindControl = this.txtCautionName;
            this.xEditGridCell95.CellName = "caution_name";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.IsUpdCol = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // txtCautionName
            // 
            resources.ApplyResources(this.txtCautionName, "txtCautionName");
            this.txtCautionName.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtCautionName.Name = "txtCautionName";
            this.txtCautionName.Protect = true;
            this.txtCautionName.ReadOnly = true;
            this.txtCautionName.TabStop = false;
            this.toolTip.SetToolTip(this.txtCautionName, resources.GetString("txtCautionName.ToolTip"));
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "caution_code";
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
            this.xEditGridCell97.CellName = "mix_yn";
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
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
            this.xEditGridCell37.CellWidth = 105;
            this.xEditGridCell37.Col = 8;
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
            this.xEditGridCell64.CellWidth = 31;
            this.xEditGridCell64.Col = 7;
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
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
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
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
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
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
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
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
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
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
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
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
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
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
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
            this.xEditGridCell39.CellWidth = 265;
            this.xEditGridCell39.Col = 4;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdCol = false;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "generic_name";
            this.xEditGridCell116.CellWidth = 1;
            this.xEditGridCell116.Col = 5;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsReadOnly = true;
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
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.BindControl = this.txtOrderRemark;
            this.xEditGridCell14.CellLen = 4000;
            this.xEditGridCell14.CellName = "ord_remark";
            this.xEditGridCell14.CellWidth = 55;
            this.xEditGridCell14.Col = 16;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // txtOrderRemark
            // 
            resources.ApplyResources(this.txtOrderRemark, "txtOrderRemark");
            this.txtOrderRemark.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtOrderRemark.Name = "txtOrderRemark";
            this.txtOrderRemark.Protect = true;
            this.txtOrderRemark.ReadOnly = true;
            this.txtOrderRemark.TabStop = false;
            this.toolTip.SetToolTip(this.txtOrderRemark, resources.GetString("txtOrderRemark.ToolTip"));
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "act_date";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
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
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
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
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
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
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
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
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
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
            this.xEditGridCell59.IsReadOnly = true;
            this.xEditGridCell59.SuppressRepeating = true;
            this.xEditGridCell59.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.ApplyPaintingEvent = true;
            this.xEditGridCell66.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell66.CellName = "powder_yn";
            this.xEditGridCell66.CellWidth = 62;
            this.xEditGridCell66.Col = 13;
            this.xEditGridCell66.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
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
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
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
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsUpdatable = false;
            this.xEditGridCell72.IsUpdCol = false;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "order_remark";
            this.xEditGridCell82.CellWidth = 58;
            this.xEditGridCell82.Col = 17;
            this.xEditGridCell82.DisplayMemoText = true;
            this.xEditGridCell82.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.IsUpdCol = false;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "drg_remark";
            this.xEditGridCell98.CellWidth = 59;
            this.xEditGridCell98.Col = 18;
            this.xEditGridCell98.DisplayMemoText = true;
            this.xEditGridCell98.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsUpdCol = false;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "hubal_change_yn";
            this.xEditGridCell106.CellWidth = 58;
            this.xEditGridCell106.Col = 15;
            this.xEditGridCell106.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsReadOnly = true;
            this.xEditGridCell106.IsUpdCol = false;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "pharmacy";
            this.xEditGridCell107.CellWidth = 55;
            this.xEditGridCell107.Col = 14;
            this.xEditGridCell107.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsReadOnly = true;
            this.xEditGridCell107.IsUpdCol = false;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "drg_pack_yn";
            this.xEditGridCell108.CellWidth = 62;
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
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "hope_date";
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsUpdCol = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "order_gubun";
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsUpdCol = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "bunryu1";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "bongtu_check";
            this.xEditGridCell112.CellWidth = 24;
            this.xEditGridCell112.Col = 2;
            this.xEditGridCell112.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell112.ExecuteQuery = null;
            this.xEditGridCell112.HeaderImage = global::IHIS.DRGS.Properties.Resources.출력;
            this.xEditGridCell112.HeaderImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsReadOnly = true;
            this.xEditGridCell112.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdOrder
            // 
            resources.ApplyResources(this.grdOrder, "grdOrder");
            this.grdOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell117,
            this.xEditGridCell6,
            this.xEditGridCell32,
            this.xEditGridCell5,
            this.xEditGridCell33,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell21,
            this.xEditGridCell7,
            this.xEditGridCell34,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell74,
            this.xEditGridCell81,
            this.xEditGridCell1,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell120});
            this.grdOrder.ColPerLine = 13;
            this.grdOrder.Cols = 14;
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 1;
            this.grdOrder.HeaderHeights.Add(29);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.Rows = 2;
            this.toolTip.SetToolTip(this.grdOrder, resources.GetString("grdOrder.ToolTip"));
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrder_GridColumnProtectModify);
            this.grdOrder.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOrder_ItemValueChanging);
            this.grdOrder.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOrder_SaveEnd);
            this.grdOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrder_RowFocusChanged);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.ApplyPaintingEvent = true;
            this.xEditGridCell3.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell3.CellName = "drg_bunho";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 101;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "bunho";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.ApplyPaintingEvent = true;
            this.xEditGridCell30.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell30.CellName = "order_date";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell30.Col = 5;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.ApplyPaintingEvent = true;
            this.xEditGridCell31.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell31.CellName = "jubsu_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.CellWidth = 100;
            this.xEditGridCell31.Col = 6;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "drg_jubsu_date";
            this.xEditGridCell117.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell117.Col = 7;
            this.xEditGridCell117.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.ApplyPaintingEvent = true;
            this.xEditGridCell6.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell6.CellName = "jubsu_time";
            this.xEditGridCell6.CellWidth = 83;
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.Mask = "##:##";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "doctor";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ApplyPaintingEvent = true;
            this.xEditGridCell5.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell5.CellLen = 30;
            this.xEditGridCell5.CellName = "doctor_name";
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "gwa";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.ApplyPaintingEvent = true;
            this.xEditGridCell4.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "buseo_name";
            this.xEditGridCell4.CellWidth = 100;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.ApplyPaintingEvent = true;
            this.xEditGridCell8.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell8.CellName = "act_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.CellWidth = 95;
            this.xEditGridCell8.Col = 9;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsUpdCol = false;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.ApplyPaintingEvent = true;
            this.xEditGridCell21.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell21.CellName = "act_yn";
            this.xEditGridCell21.CellWidth = 50;
            this.xEditGridCell21.Col = 13;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ApplyPaintingEvent = true;
            this.xEditGridCell7.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell7.CellName = "sunab_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = 10;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "chulgo_date";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell69.ApplyPaintingEvent = true;
            this.xEditGridCell69.CellName = "boryu_yn";
            this.xEditGridCell69.CellWidth = 36;
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsUpdCol = false;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            this.xEditGridCell69.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "chulgo_buseo";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.ApplyPaintingEvent = true;
            this.xEditGridCell74.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell74.CellName = "order_remark";
            this.xEditGridCell74.CellWidth = 60;
            this.xEditGridCell74.Col = 11;
            this.xEditGridCell74.DisplayMemoText = true;
            this.xEditGridCell74.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsReadOnly = true;
            this.xEditGridCell74.IsUpdCol = false;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.ApplyPaintingEvent = true;
            this.xEditGridCell81.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell81.CellName = "drg_remark";
            this.xEditGridCell81.CellWidth = 83;
            this.xEditGridCell81.Col = 12;
            this.xEditGridCell81.DisplayMemoText = true;
            this.xEditGridCell81.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.IsUpdCol = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.ApplyPaintingEvent = true;
            this.xEditGridCell1.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell1.CellName = "wonyoi_yn";
            this.xEditGridCell1.CellWidth = 33;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "fkout1001";
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "fkocs1003";
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "naewon_yn";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "if_data_send_yn";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel5.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.xLabel5.Name = "xLabel5";
            this.toolTip.SetToolTip(this.xLabel5, resources.GetString("xLabel5.ToolTip"));
            // 
            // splitter2
            // 
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            this.toolTip.SetToolTip(this.splitter2, resources.GetString("splitter2.ToolTip"));
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.grdOrder);
            this.xPanel1.Controls.Add(this.button1);
            this.xPanel1.Controls.Add(this.chbDataInterface);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            this.toolTip.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.toolTip.SetToolTip(this.button1, resources.GetString("button1.ToolTip"));
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chbDataInterface
            // 
            resources.ApplyResources(this.chbDataInterface, "chbDataInterface");
            this.chbDataInterface.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.chbDataInterface.Name = "chbDataInterface";
            this.toolTip.SetToolTip(this.chbDataInterface, resources.GetString("chbDataInterface.ToolTip"));
            this.chbDataInterface.UseVisualStyleBackColor = false;
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.xLabel2.Name = "xLabel2";
            this.toolTip.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // pnlFillDown
            // 
            resources.ApplyResources(this.pnlFillDown, "pnlFillDown");
            this.pnlFillDown.Controls.Add(this.panel1);
            this.pnlFillDown.Controls.Add(this.pnlFillIn3);
            this.pnlFillDown.DrawBorder = true;
            this.pnlFillDown.Name = "pnlFillDown";
            this.toolTip.SetToolTip(this.pnlFillDown, resources.GetString("pnlFillDown.ToolTip"));
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.pnlFillIn1);
            this.panel1.Controls.Add(this.pnlFillIn2);
            this.panel1.Name = "panel1";
            this.toolTip.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // pnlFillIn1
            // 
            resources.ApplyResources(this.pnlFillIn1, "pnlFillIn1");
            this.pnlFillIn1.Controls.Add(this.txtBogyongName);
            this.pnlFillIn1.Controls.Add(this.xLabel1);
            this.pnlFillIn1.Name = "pnlFillIn1";
            this.toolTip.SetToolTip(this.pnlFillIn1, resources.GetString("pnlFillIn1.ToolTip"));
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            this.toolTip.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // pnlFillIn2
            // 
            resources.ApplyResources(this.pnlFillIn2, "pnlFillIn2");
            this.pnlFillIn2.Controls.Add(this.txtCautionName);
            this.pnlFillIn2.Controls.Add(this.xLabel3);
            this.pnlFillIn2.Name = "pnlFillIn2";
            this.toolTip.SetToolTip(this.pnlFillIn2, resources.GetString("pnlFillIn2.ToolTip"));
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            this.toolTip.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // pnlFillIn3
            // 
            resources.ApplyResources(this.pnlFillIn3, "pnlFillIn3");
            this.pnlFillIn3.Controls.Add(this.txtOrderRemark);
            this.pnlFillIn3.Controls.Add(this.xLabel4);
            this.pnlFillIn3.Name = "pnlFillIn3";
            this.toolTip.SetToolTip(this.pnlFillIn3, resources.GetString("pnlFillIn3.ToolTip"));
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            this.toolTip.SetToolTip(this.xLabel4, resources.GetString("xLabel4.ToolTip"));
            // 
            // pnlFillInTop
            // 
            resources.ApplyResources(this.pnlFillInTop, "pnlFillInTop");
            this.pnlFillInTop.Controls.Add(this.dbxSuname2);
            this.pnlFillInTop.Controls.Add(this.dbxSuname);
            this.pnlFillInTop.Controls.Add(this.xLabel26);
            this.pnlFillInTop.Controls.Add(this.dbxAge);
            this.pnlFillInTop.Controls.Add(this.dbxGwa);
            this.pnlFillInTop.Controls.Add(this.dbxSex);
            this.pnlFillInTop.Controls.Add(this.xLabel29);
            this.pnlFillInTop.Controls.Add(this.dbxDoctor);
            this.pnlFillInTop.Controls.Add(this.xLabel36);
            this.pnlFillInTop.Controls.Add(this.paid);
            this.pnlFillInTop.DrawBorder = true;
            this.pnlFillInTop.Name = "pnlFillInTop";
            this.toolTip.SetToolTip(this.pnlFillInTop, resources.GetString("pnlFillInTop.ToolTip"));
            // 
            // dbxSuname2
            // 
            resources.ApplyResources(this.dbxSuname2, "dbxSuname2");
            this.dbxSuname2.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.dbxSuname2.Name = "dbxSuname2";
            this.toolTip.SetToolTip(this.dbxSuname2, resources.GetString("dbxSuname2.ToolTip"));
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.dbxSuname.Name = "dbxSuname";
            this.toolTip.SetToolTip(this.dbxSuname, resources.GetString("dbxSuname.ToolTip"));
            // 
            // xLabel26
            // 
            resources.ApplyResources(this.xLabel26, "xLabel26");
            this.xLabel26.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel26.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.xLabel26.Name = "xLabel26";
            this.toolTip.SetToolTip(this.xLabel26, resources.GetString("xLabel26.ToolTip"));
            // 
            // dbxAge
            // 
            resources.ApplyResources(this.dbxAge, "dbxAge");
            this.dbxAge.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.dbxAge.Name = "dbxAge";
            this.toolTip.SetToolTip(this.dbxAge, resources.GetString("dbxAge.ToolTip"));
            // 
            // dbxGwa
            // 
            resources.ApplyResources(this.dbxGwa, "dbxGwa");
            this.dbxGwa.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.dbxGwa.Name = "dbxGwa";
            this.toolTip.SetToolTip(this.dbxGwa, resources.GetString("dbxGwa.ToolTip"));
            // 
            // dbxSex
            // 
            resources.ApplyResources(this.dbxSex, "dbxSex");
            this.dbxSex.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.dbxSex.Name = "dbxSex";
            this.toolTip.SetToolTip(this.dbxSex, resources.GetString("dbxSex.ToolTip"));
            // 
            // xLabel29
            // 
            resources.ApplyResources(this.xLabel29, "xLabel29");
            this.xLabel29.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel29.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.xLabel29.Name = "xLabel29";
            this.toolTip.SetToolTip(this.xLabel29, resources.GetString("xLabel29.ToolTip"));
            // 
            // dbxDoctor
            // 
            resources.ApplyResources(this.dbxDoctor, "dbxDoctor");
            this.dbxDoctor.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.dbxDoctor.Name = "dbxDoctor";
            this.toolTip.SetToolTip(this.dbxDoctor, resources.GetString("dbxDoctor.ToolTip"));
            // 
            // xLabel36
            // 
            resources.ApplyResources(this.xLabel36, "xLabel36");
            this.xLabel36.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel36.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.xLabel36.Name = "xLabel36";
            this.toolTip.SetToolTip(this.xLabel36, resources.GetString("xLabel36.ToolTip"));
            // 
            // btnATC
            // 
            resources.ApplyResources(this.btnATC, "btnATC");
            this.btnATC.Image = global::IHIS.DRGS.Properties.Resources.검사예약_1;
            this.btnATC.Name = "btnATC";
            this.btnATC.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.toolTip.SetToolTip(this.btnATC, resources.GetString("btnATC.ToolTip"));
            this.btnATC.Click += new System.EventHandler(this.btnATC_Click);
            // 
            // btnBongtuLabePrt
            // 
            resources.ApplyResources(this.btnBongtuLabePrt, "btnBongtuLabePrt");
            this.btnBongtuLabePrt.ImageIndex = 5;
            this.btnBongtuLabePrt.ImageList = this.ImageList;
            this.btnBongtuLabePrt.Name = "btnBongtuLabePrt";
            this.toolTip.SetToolTip(this.btnBongtuLabePrt, resources.GetString("btnBongtuLabePrt.ToolTip"));
            this.btnBongtuLabePrt.Click += new System.EventHandler(this.btnBongtuLabePrt_Click);
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
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Controls.Add(this.btnATC);
            this.pnlBottom.Controls.Add(this.btnQuery);
            this.pnlBottom.Controls.Add(this.btnProcess);
            this.pnlBottom.Controls.Add(this.btnUseTimeChk);
            this.pnlBottom.Controls.Add(this.xButtonList1);
            this.pnlBottom.Controls.Add(this.btnUpdateComment);
            this.pnlBottom.Controls.Add(this.btnPrescripRePrt);
            this.pnlBottom.Controls.Add(this.btnPrescripPrt);
            this.pnlBottom.Controls.Add(this.btnBatPrint);
            this.pnlBottom.Controls.Add(this.btnBongtuLabePrt);
            this.pnlBottom.Controls.Add(this.btnScreenLock);
            this.pnlBottom.Controls.Add(this.btnPrintSetup);
            this.pnlBottom.Controls.Add(this.btnBoryuDel);
            this.pnlBottom.Controls.Add(this.btnBoryu);
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Name = "pnlBottom";
            this.toolTip.SetToolTip(this.pnlBottom, resources.GetString("pnlBottom.ToolTip"));
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.ImageIndex = 14;
            this.btnQuery.ImageList = this.ImageList;
            this.btnQuery.Name = "btnQuery";
            this.toolTip.SetToolTip(this.btnQuery, resources.GetString("btnQuery.ToolTip"));
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnProcess
            // 
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.ImageIndex = 6;
            this.btnProcess.ImageList = this.ImageList;
            this.btnProcess.Name = "btnProcess";
            this.toolTip.SetToolTip(this.btnProcess, resources.GetString("btnProcess.ToolTip"));
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnUseTimeChk
            // 
            resources.ApplyResources(this.btnUseTimeChk, "btnUseTimeChk");
            this.btnUseTimeChk.ImageIndex = 0;
            this.btnUseTimeChk.ImageList = this.ImageList;
            this.btnUseTimeChk.Name = "btnUseTimeChk";
            this.toolTip.SetToolTip(this.btnUseTimeChk, resources.GetString("btnUseTimeChk.ToolTip"));
            this.btnUseTimeChk.Click += new System.EventHandler(this.btnUseTimeChk_Click);
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.DRGS.Properties.Resources.btnClose, -1, global::IHIS.DRGS.Properties.Resources.layBongtuLabel3)});
            this.xButtonList1.ImageList = this.ImageList;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.toolTip.SetToolTip(this.xButtonList1, resources.GetString("xButtonList1.ToolTip"));
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // btnUpdateComment
            // 
            resources.ApplyResources(this.btnUpdateComment, "btnUpdateComment");
            this.btnUpdateComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnUpdateComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdateComment.ImageIndex = 7;
            this.btnUpdateComment.ImageList = this.ImageList;
            this.btnUpdateComment.Name = "btnUpdateComment";
            this.toolTip.SetToolTip(this.btnUpdateComment, resources.GetString("btnUpdateComment.ToolTip"));
            this.btnUpdateComment.Click += new System.EventHandler(this.btnUpdateComment_Click);
            // 
            // btnPrescripRePrt
            // 
            resources.ApplyResources(this.btnPrescripRePrt, "btnPrescripRePrt");
            this.btnPrescripRePrt.ImageIndex = 5;
            this.btnPrescripRePrt.ImageList = this.ImageList;
            this.btnPrescripRePrt.Name = "btnPrescripRePrt";
            this.toolTip.SetToolTip(this.btnPrescripRePrt, resources.GetString("btnPrescripRePrt.ToolTip"));
            this.btnPrescripRePrt.Click += new System.EventHandler(this.btnPrescripRePrt_Click);
            // 
            // btnPrescripPrt
            // 
            resources.ApplyResources(this.btnPrescripPrt, "btnPrescripPrt");
            this.btnPrescripPrt.ImageIndex = 12;
            this.btnPrescripPrt.ImageList = this.ImageList;
            this.btnPrescripPrt.Name = "btnPrescripPrt";
            this.toolTip.SetToolTip(this.btnPrescripPrt, resources.GetString("btnPrescripPrt.ToolTip"));
            this.btnPrescripPrt.Click += new System.EventHandler(this.btnPrescripPrt_Click);
            // 
            // btnScreenLock
            // 
            resources.ApplyResources(this.btnScreenLock, "btnScreenLock");
            this.btnScreenLock.ImageIndex = 2;
            this.btnScreenLock.ImageList = this.ImageList;
            this.btnScreenLock.Name = "btnScreenLock";
            this.toolTip.SetToolTip(this.btnScreenLock, resources.GetString("btnScreenLock.ToolTip"));
            // 
            // btnBoryuDel
            // 
            resources.ApplyResources(this.btnBoryuDel, "btnBoryuDel");
            this.btnBoryuDel.ImageIndex = 4;
            this.btnBoryuDel.ImageList = this.ImageList;
            this.btnBoryuDel.Name = "btnBoryuDel";
            this.toolTip.SetToolTip(this.btnBoryuDel, resources.GetString("btnBoryuDel.ToolTip"));
            this.btnBoryuDel.Click += new System.EventHandler(this.btnBoryuDel_Click);
            // 
            // btnBoryu
            // 
            resources.ApplyResources(this.btnBoryu, "btnBoryu");
            this.btnBoryu.ImageIndex = 3;
            this.btnBoryu.ImageList = this.ImageList;
            this.btnBoryu.Name = "btnBoryu";
            this.toolTip.SetToolTip(this.btnBoryu, resources.GetString("btnBoryu.ToolTip"));
            this.btnBoryu.Click += new System.EventHandler(this.btnBoryu_Click);
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
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "order_suryang";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "subul_danui";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "group_yn";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jaeryo_gubun";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "bogyong_name";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "caution_name";
            this.xEditGridCell47.Col = 10;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.Row = 1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "caution_code";
            this.xEditGridCell48.Col = 11;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.Row = 1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "mix_yn";
            this.xEditGridCell49.Col = 13;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.Row = 1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "atc_yn";
            this.xEditGridCell50.Col = 14;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.Row = 1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "remark";
            this.xEditGridCell51.Col = 15;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.Row = 1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "dc_yn";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "bannab_yn";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "source_fkocs1003";
            this.xEditGridCell54.Col = 16;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.Row = 1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "fkocs1003";
            this.xEditGridCell55.Col = 17;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.Row = 1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "fkout1001";
            this.xEditGridCell56.Col = 18;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.Row = 1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "sunab_date";
            this.xEditGridCell57.Col = 19;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.Row = 1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "pattern";
            this.xEditGridCell58.Col = 20;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
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
            this.layLabel.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layLabel_QueryStarting);
            this.layLabel.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layLabel_QueryEnd);
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
            // xdwWorker1
            // 
            this.xdwWorker1.DataWindowObject = "d_order";
            this.xdwWorker1.IsLandScape = false;
            this.xdwWorker1.IsPreviewStatusPopup = true;
            this.xdwWorker1.LibraryList = "DRGS\\drgs.drg5100p01.pbd";
            this.xdwWorker1.PaperSize = IHIS.Framework.DataWindowPaperSize.A4;
            this.xdwWorker1.SourceTable = this.layOrder.LayoutTable;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "gyunbon_yn";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
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
            // layAntiData
            // 
            this.layAntiData.ExecuteQuery = null;
            this.layAntiData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem282});
            this.layAntiData.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layAntiData.ParamList")));
            this.layAntiData.QuerySQL = resources.GetString("layAntiData.QuerySQL");
            this.layAntiData.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layAntiData_QueryEnd);
            // 
            // multiLayoutItem211
            // 
            this.multiLayoutItem211.DataName = "fkocs";
            // 
            // multiLayoutItem212
            // 
            this.multiLayoutItem212.DataName = "in_out_gubun";
            // 
            // multiLayoutItem213
            // 
            this.multiLayoutItem213.DataName = "order_date";
            // 
            // multiLayoutItem214
            // 
            this.multiLayoutItem214.DataName = "bunho";
            // 
            // multiLayoutItem215
            // 
            this.multiLayoutItem215.DataName = "gwa";
            // 
            // multiLayoutItem216
            // 
            this.multiLayoutItem216.DataName = "doctor";
            // 
            // multiLayoutItem217
            // 
            this.multiLayoutItem217.DataName = "ho_dong";
            // 
            // multiLayoutItem218
            // 
            this.multiLayoutItem218.DataName = "ipwon_date";
            // 
            // multiLayoutItem219
            // 
            this.multiLayoutItem219.DataName = "jubsu_date";
            // 
            // multiLayoutItem220
            // 
            this.multiLayoutItem220.DataName = "v1";
            // 
            // multiLayoutItem221
            // 
            this.multiLayoutItem221.DataName = "v2";
            // 
            // multiLayoutItem222
            // 
            this.multiLayoutItem222.DataName = "v3";
            // 
            // multiLayoutItem223
            // 
            this.multiLayoutItem223.DataName = "v4";
            // 
            // multiLayoutItem224
            // 
            this.multiLayoutItem224.DataName = "v5";
            // 
            // multiLayoutItem225
            // 
            this.multiLayoutItem225.DataName = "v6";
            // 
            // multiLayoutItem226
            // 
            this.multiLayoutItem226.DataName = "v7";
            // 
            // multiLayoutItem227
            // 
            this.multiLayoutItem227.DataName = "v8";
            // 
            // multiLayoutItem228
            // 
            this.multiLayoutItem228.DataName = "v9";
            // 
            // multiLayoutItem229
            // 
            this.multiLayoutItem229.DataName = "check01";
            // 
            // multiLayoutItem230
            // 
            this.multiLayoutItem230.DataName = "check02";
            // 
            // multiLayoutItem231
            // 
            this.multiLayoutItem231.DataName = "check03";
            // 
            // multiLayoutItem232
            // 
            this.multiLayoutItem232.DataName = "check04";
            // 
            // multiLayoutItem233
            // 
            this.multiLayoutItem233.DataName = "check05";
            // 
            // multiLayoutItem234
            // 
            this.multiLayoutItem234.DataName = "check06";
            // 
            // multiLayoutItem235
            // 
            this.multiLayoutItem235.DataName = "check07";
            // 
            // multiLayoutItem236
            // 
            this.multiLayoutItem236.DataName = "check08";
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "check09";
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "check10";
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "check11";
            // 
            // multiLayoutItem240
            // 
            this.multiLayoutItem240.DataName = "check12";
            // 
            // multiLayoutItem241
            // 
            this.multiLayoutItem241.DataName = "check13";
            // 
            // multiLayoutItem242
            // 
            this.multiLayoutItem242.DataName = "check14";
            // 
            // multiLayoutItem243
            // 
            this.multiLayoutItem243.DataName = "check15";
            // 
            // multiLayoutItem244
            // 
            this.multiLayoutItem244.DataName = "check16";
            // 
            // multiLayoutItem245
            // 
            this.multiLayoutItem245.DataName = "check17";
            // 
            // multiLayoutItem246
            // 
            this.multiLayoutItem246.DataName = "check18";
            // 
            // multiLayoutItem247
            // 
            this.multiLayoutItem247.DataName = "check19";
            // 
            // multiLayoutItem248
            // 
            this.multiLayoutItem248.DataName = "check20";
            // 
            // multiLayoutItem249
            // 
            this.multiLayoutItem249.DataName = "check21";
            // 
            // multiLayoutItem250
            // 
            this.multiLayoutItem250.DataName = "check22";
            // 
            // multiLayoutItem251
            // 
            this.multiLayoutItem251.DataName = "check23";
            // 
            // multiLayoutItem252
            // 
            this.multiLayoutItem252.DataName = "check24";
            // 
            // multiLayoutItem253
            // 
            this.multiLayoutItem253.DataName = "check25";
            // 
            // multiLayoutItem254
            // 
            this.multiLayoutItem254.DataName = "check26";
            // 
            // multiLayoutItem255
            // 
            this.multiLayoutItem255.DataName = "check27";
            // 
            // multiLayoutItem256
            // 
            this.multiLayoutItem256.DataName = "check28";
            // 
            // multiLayoutItem257
            // 
            this.multiLayoutItem257.DataName = "check29";
            // 
            // multiLayoutItem258
            // 
            this.multiLayoutItem258.DataName = "check30";
            // 
            // multiLayoutItem259
            // 
            this.multiLayoutItem259.DataName = "check31";
            // 
            // multiLayoutItem260
            // 
            this.multiLayoutItem260.DataName = "check32";
            // 
            // multiLayoutItem261
            // 
            this.multiLayoutItem261.DataName = "check33";
            // 
            // multiLayoutItem262
            // 
            this.multiLayoutItem262.DataName = "check34";
            // 
            // multiLayoutItem263
            // 
            this.multiLayoutItem263.DataName = "check35";
            // 
            // multiLayoutItem264
            // 
            this.multiLayoutItem264.DataName = "check36";
            // 
            // multiLayoutItem265
            // 
            this.multiLayoutItem265.DataName = "check37";
            // 
            // multiLayoutItem266
            // 
            this.multiLayoutItem266.DataName = "check38";
            // 
            // multiLayoutItem267
            // 
            this.multiLayoutItem267.DataName = "check39";
            // 
            // multiLayoutItem268
            // 
            this.multiLayoutItem268.DataName = "check40";
            // 
            // multiLayoutItem269
            // 
            this.multiLayoutItem269.DataName = "check41";
            // 
            // multiLayoutItem270
            // 
            this.multiLayoutItem270.DataName = "check42";
            // 
            // multiLayoutItem271
            // 
            this.multiLayoutItem271.DataName = "check43";
            // 
            // multiLayoutItem272
            // 
            this.multiLayoutItem272.DataName = "check44";
            // 
            // multiLayoutItem273
            // 
            this.multiLayoutItem273.DataName = "check45";
            // 
            // multiLayoutItem274
            // 
            this.multiLayoutItem274.DataName = "check46";
            // 
            // multiLayoutItem275
            // 
            this.multiLayoutItem275.DataName = "check47";
            // 
            // multiLayoutItem276
            // 
            this.multiLayoutItem276.DataName = "check48";
            // 
            // multiLayoutItem277
            // 
            this.multiLayoutItem277.DataName = "check49";
            // 
            // multiLayoutItem278
            // 
            this.multiLayoutItem278.DataName = "check50";
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
            this.multiLayoutItem281.DataName = "gwa_name";
            // 
            // multiLayoutItem282
            // 
            this.multiLayoutItem282.DataName = "doctor_name";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.layNebokLabel.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNebokLabel_QueryStarting);
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
            this.toolTip.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
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
            // layBongtuLabel
            // 
            this.layBongtuLabel.ExecuteQuery = null;
            this.layBongtuLabel.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48});
            this.layBongtuLabel.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBongtuLabel.ParamList")));
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "bunho";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "suname";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "drg_bunho";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "act_date";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "jaeryo_name";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "bogyong_name";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "nalsu";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "suryang";
            // 
            // layBongtuInfo
            // 
            this.layBongtuInfo.ExecuteQuery = null;
            this.layBongtuInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem19});
            this.layBongtuInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBongtuInfo.ParamList")));
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "jubsu_date_wareki";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "act_date_wareki";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "donbok_yn";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "pattern";
            // 
            // layPrintName
            // 
            this.layPrintName.ExecuteQuery = null;
            this.layPrintName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layPrintName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPrintName.ParamList")));
            this.layPrintName.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPrintName_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "print_name";
            // 
            // mlayConstantInfo
            // 
            this.mlayConstantInfo.ExecuteQuery = null;
            this.mlayConstantInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem4,
            this.multiLayoutItem15,
            this.multiLayoutItem42});
            this.mlayConstantInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayConstantInfo.ParamList")));
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "code";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "code_name";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "code_value";
            // 
            // DRG5100P01
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.PnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Name = "DRG5100P01";
            this.PrintWorker = this.xdwWorker1;
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.PnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaid)).EndInit();
            this.pnlLeftInTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xBuseoCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.pnlFillDown.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlFillIn1.ResumeLayout(false);
            this.pnlFillIn1.PerformLayout();
            this.pnlFillIn2.ResumeLayout(false);
            this.pnlFillIn2.PerformLayout();
            this.pnlFillIn3.ResumeLayout(false);
            this.pnlFillIn3.PerformLayout();
            this.pnlFillInTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAntiData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNebokLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAutoJubsu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBongtuLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBongtuInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Common Method Variable

        private int QueryTime;
        private int TimeVal;

        //private string soundFileName = @"C:\IHIS\bin\drg.WAV";

        private bool mIsPatient = false;

        // 処方箋出力可否 
        private string prescripPrnYN = "";
        // 自動照会使用可否 
        private string useTimeChkYN = "";
        private int grdOrderList_count;
        private string patient_name = "";

        // Key cache
        private const string CACHE_DRG5100P01_COMBO_LIST_ITEM_KEYS = "Nuro.Drg5100p01.comboList";
        private const string CACHE_DRG5100P01_DRG_CONSTANT_KEYS = "Nuro.Drg5100p01.Constant";
        DrgsDRG5100P01DsvOrderPrintResult dsvOrderPrintResult;

        private void MasterServerCall()
        {
            //2015/08/31
            if (!rbx3.Checked)
            {
                this.btnProcess.Enabled = true;
            }

            btnBoryu.Enabled = false;
            btnBoryuDel.Enabled = false;

            grdOrder.ReadOnly = false;
            grdOrderList.ReadOnly = false;

            /* string gubun = string.Empty;
            if (rbx1.Checked) gubun = "1";
            if (rbx2.Checked) gubun = "2";
            if (rbx3.Checked) gubun = "3";*/

            this.grdOrder.Reset();
            this.grdOrderList.Reset();
            /*

                        grdPaid.QuerySQL = (xrbOrder.Checked ? grdPaidOrder : grdPaidJubsu);
                        grdPaid.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        grdPaid.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
                        grdPaid.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
                        grdPaid.SetBindVarValue("f_gubun", gubun);
                        grdPaid.SetBindVarValue("f_wonyoi_yn", (gubun == "3" ? "Y" : "N"));
                        grdPaid.SetBindVarValue("f_bunho", paBox.BunHo);
                        grdPaid.SetBindVarValue("f_gwa", xBuseoCombo.GetDataValue());
            */

            // Cloud server
            grdPaid.ExecuteQuery = grdPaid_getData;
            if (!grdPaid.QueryLayout(false)) SetMsg(Service.ErrMsg, MsgType.Error);
        }

        private void OrderServerCall(string aBunho)
        {
            /*grdOrder.QuerySQL = (xrbOrder.Checked ? grdOrderOrder : grdOrderJubsu);

            string gubun = string.Empty;
            if (rbx1.Checked) gubun = "1";
            if (rbx2.Checked) gubun = "2";
            if (rbx3.Checked) gubun = "3";

            grdOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdOrder.SetBindVarValue("f_drg_bunho", grdPaid.GetItemString(grdPaid.CurrentRowNumber, "drg_bunho"));
            grdOrder.SetBindVarValue("f_order_date", grdPaid.GetItemString(grdPaid.CurrentRowNumber, "order_date"));
            grdOrder.SetBindVarValue("f_gubun", gubun);*/

            grdOrder.ExecuteQuery = grdOrder_getData;
            if (!grdOrder.QueryLayout(false)) SetMsg(Service.ErrMsg, MsgType.Error);
        }

        #endregion

        #region OnLoad

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cboTime.ExecuteQuery = cboTime_getData;
            cboTime.SetDictDDLB();

            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());

            if (TypeCheck.IsInt(txtTimeInterval.Text))
            {
                QueryTime = int.Parse(txtTimeInterval.GetDataValue());
                TimeVal = int.Parse(txtTimeInterval.GetDataValue());
            }

            //xButtonList1.PerformClick(FunctionType.Query);
            // 画面データ照会
            this.MasterServerCall();
            this.QueryTime = TimeVal;
            ///////////////////////////

            if (EnvironInfo.CurrSystemID != "DRGS")
            {
                btnEndDrg.Enabled = false;
                btnBatPrint.Visible = false;

                chbDataInterface.Checked = false;
                chbDataInterface.Enabled = false;

                //btnAuto.Enabled = false;
                QueryTime = TimeVal;
                //timer1.Start();
            }

            //2011.9.17 yklee 간호 이외에는 btnEndDrg를 비활성, 간호에서만 활성
            if (EnvironInfo.CurrSystemID == "NURO")
            {
                btnEndDrg.Enabled = true;
            }
            else
            {
                btnEndDrg.Enabled = false;
            }

            if (EnvironInfo.CurrSystemID == "AKUS")
            {
                xBuseoCombo.SetDataValue("05");
                //xBuseoCombo.Enabled = false;

                //btnAutoStop.Enabled = false;
                btnBatPrint.Visible = true;

                QueryTime = TimeVal;
                timer1.Stop();
            }

            string tipText = XMsg.GetField("F002"); // 오더일보기
            this.toolTip.SetToolTip((Control)btnExpand, tipText);

            //string tipText2 = XMsg.GetField("F002"); // 오더일보기
            string btnGenericText = Resources.btnGenericText;
            this.toolTip.SetToolTip((Control)btnGeneric, btnGenericText);

            this.cboTime.SelectedIndex = 0;
            this.timer1.Start();
            this.cboTime.Enabled = true;
            this.tbxTimer.SetDataValue("Y");
            this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            this.txtTimeInterval.AcceptData();

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        #endregion

        private void PostLoad()
        {
            string btn_autoQuery_yn = null;
            string btn_prescripPnt_yn = null;

            // 注射画面コントロールデータ照会
            /*this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                                            FROM INV0102
                                           WHERE HOSP_CODE = :f_hosp_code
                                             AND CODE_TYPE = 'DRG_CONSTANT'
                                        ORDER BY CODE";

            this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);*/

            mlayConstantInfo.ExecuteQuery = layConstantInfo_getData;
            if (mlayConstantInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoQuery_yn"))
                        btn_autoQuery_yn = mlayConstantInfo.GetItemString(i, "code_value");

                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_prescripPnt_yn"))
                        btn_prescripPnt_yn = mlayConstantInfo.GetItemString(i, "code_value");
                }
            }

            // ボタン設定

            // 自動照会
            if ("Y".Equals(btn_autoQuery_yn))
            {
                this.useTimeChkYN = "Y";
                this.btnUseTimeChk.ImageIndex = 0;

                this.timer1.Start();
                this.cboTime.Enabled = true;
            }
            else
            {
                this.useTimeChkYN = "N";
                this.btnUseTimeChk.ImageIndex = 12;

                this.cboTime.Enabled = false;
                this.timer1.Stop();
            }

            // 注射実施箋出力
            if ("Y".Equals(btn_prescripPnt_yn))
            {
                this.prescripPrnYN = "Y";
                this.btnPrescripPrt.ImageIndex = 0;
            }
            else
            {
                this.prescripPrnYN = "N";
                this.btnPrescripPrt.ImageIndex = 12;
            }
        }

        #region xButtonList1_ButtonClick

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.MasterServerCall();
            this.QueryTime = TimeVal;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (rbx3.Checked) return;

            if (this.rbx1.Checked && this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("N"))
                return;

            if (this.rbx2.Checked && this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("Y"))
                return;

            //if (!LockChk()) return;

            if (grdOrder.RowCount == 0) return;

            string act_yn = "N";
            string jubsu_time = "";

            //보류이면
            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "boryu_yn") == "Y")
            {
                if (
                    XMessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F001"), MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            // TODO comment : use cloud service
            /*Hashtable inputList = new Hashtable();
            inputList.Add("I_SYS_DATE", EnvironInfo.GetSysDate().ToShortDateString());
            inputList.Add("I_USER_ID", UserInfo.UserID);
            inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));

            if (rbx1.Checked)
            {
                inputList.Add("I_JUBSU_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_jubsu_date"));
                inputList.Add("I_JUBSU_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jubsu_time"));
            }
            else
            {
                inputList.Add("I_JUBSU_DATE", null);
                inputList.Add("I_JUBSU_TIME", null);
            }

            inputList.Add("I_DRG_BUNHO", grdOrder.GetItemValue(grdOrder.CurrentRowNumber, "drg_bunho"));
            inputList.Add("I_WONYOI_ORDER_YN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "wonyoi_yn"));
            inputList.Add("I_JUBSU_YN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn"));
            inputList.Add("I_GYUNBON_YN", "");

            Hashtable outputList = new Hashtable();

            if (!Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_OUT", inputList, outputList))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }*/

            // Connect cloud
            if (this.rbx2.Checked)
            {
                foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                {
                    // Skip un-modified rows
                    if (dtRow.RowState != DataRowState.Modified) continue;

                    // 会計未処理のみ
                    if (dtRow["if_data_send_yn"].ToString() == "Y")
                    {
                        XMessageBox.Show(Resources.XMessageBox2, "", MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            DrgsDRG5100P01MakeBongtuOutArgs makeBongtuOutArgs = new DrgsDRG5100P01MakeBongtuOutArgs();
            //fix bug MED-6121
            makeBongtuOutArgs.ISysDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
            makeBongtuOutArgs.IUserId = UserInfo.UserID;
            makeBongtuOutArgs.IOrderDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
            if (rbx1.Checked)
            {
                makeBongtuOutArgs.IJubsuDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_jubsu_date");
                makeBongtuOutArgs.IJubsuTime = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jubsu_time");
            }
            makeBongtuOutArgs.IDrgBunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho");
            makeBongtuOutArgs.IWonyoiOrderYn = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "wonyoi_yn");
            makeBongtuOutArgs.IJubsuYn = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn");
            makeBongtuOutArgs.IGyunbonYn = "";
            DrgsDRG5100P01MakeBongtuOutResult makeBongtuOutResult =
                CloudService.Instance.Submit<DrgsDRG5100P01MakeBongtuOutResult, DrgsDRG5100P01MakeBongtuOutArgs>(
                    makeBongtuOutArgs);
            if (makeBongtuOutResult == null || makeBongtuOutResult.Result == false)
            {
                XMessageBox.Show(Service.ErrFullMsg + " Execute Error(Data does not changed)");
                return;
            }

            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                act_yn = grdOrder.GetItemString(i, "act_yn");
                // jubsu_time = grdOrder.GetItemString(i, "jubsu_time");

                if ((act_yn == "Y") /* && (jubsu_time.Trim() == "")*/)
                {
                    // 処方箋チェックされている場合、出力する。
                    if (this.prescripPrnYN.Equals("Y")) this.QueryWonnae01("A");

                    // ATC装置I/Fデータ転送Process
                    if (this.cbxATCYN.Checked)
                    {
                        bool value = this.procAtcInterface();

                        if (value == false)
                        {
                            throw new Exception();
                        }
                    }

                    // 복약지도문 전송
                    //if (chbDataInterface.Checked) DsvAtcSend("O");
                }
            }

            if (!grdOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            this.MasterServerCall();
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Close:
                    break;
        }
        }

        #endregion

        #region grdPaid

        private void grdPaid_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            QueryTime = TimeVal;

            if (!TypeCheck.IsNull(paid.BunHo)) paid.Reset();
            mIsPatient = true;
            paid.SetPatientID(grdPaid.GetItemString(e.CurrentRow, "bunho"));
            //
            OrderServerCall(grdPaid.GetItemString(e.CurrentRow, "bunho"));
            mIsPatient = false;

            if (rbx1.Checked)
            {
                if (grdPaid.GetItemString(e.CurrentRow, "boryu_yn") == "Y")
                {
                    btnBoryuDel.Enabled = true;
                    btnBoryu.Enabled = false;
                }
                else
                {
                    btnBoryuDel.Enabled = false;
                    btnBoryu.Enabled = true;
                }
            }
            if (rbx3.Checked)
            {
                patient_name = grdPaid.GetItemString(e.CurrentRow, "suname");
            }
        }

        #endregion

        #region Patient

        private void paid_PatientSelected(object sender, System.EventArgs e)
        {
            //
            dbxSuname.Text = paid.SuName;
            dbxSuname2.Text = paid.SuName2;
            dbxAge.Text = paid.YearAge.ToString();
            dbxSex.Text = paid.Sex;

            // grdMaster_RowFocusChanged call 하면 return 한다.
            if (mIsPatient) return;
            OrderServerCall(paid.BunHo);
        }

        #endregion

        #region Radio Button

        private void rbx1_Click(object sender, System.EventArgs e)
        {
            this.btnProcess.Text = Resources.btnProcessText;

            rbx1.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            rbx2.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            rbx3.ForeColor = IHIS.Framework.XColor.NormalForeColor;

            MasterServerCall();
            QueryTime = TimeVal;

            // 封筒ラベル出力COLUMN
            this.xEditGridCell112.IsReadOnly = true;

            // 処方箋出力ボタン
            this.btnPrescripPrt.Visible = true;
            // 封筒ラベル出力ボタン
            this.btnBongtuLabePrt.Visible = false;
            // 処方箋再出力ボタン
            this.btnPrescripRePrt.Visible = false;
            // ATC転送ボタン
            //this.btnATC.Visible = false;
        }

        private void rbx2_Click(object sender, System.EventArgs e)
        {
            this.btnProcess.Text = Resources.btnProcessText2;

            rbx1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            rbx2.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            rbx3.ForeColor = IHIS.Framework.XColor.NormalForeColor;

            MasterServerCall();
            QueryTime = TimeVal;

            // 封筒ラベル出力COLUMN
            this.xEditGridCell112.IsReadOnly = false;

            // 処方箋出力ボタン
            this.btnPrescripPrt.Visible = false;
            // 封筒ラベル出力ボタン
            this.btnBongtuLabePrt.Visible = true;
            // 処方箋再出力ボタン
            this.btnPrescripRePrt.Visible = true;
            // ATC転送ボタン
            //this.btnATC.Visible = true;
        }

        private void rbx3_Click(object sender, System.EventArgs e)
        {
            this.btnProcess.Text = Resources.btnProcessText;
            this.btnProcess.Enabled = false;

            rbx1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            rbx2.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            rbx3.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;

            // 封筒ラベル出力COLUMN
            this.xEditGridCell112.IsReadOnly = true;
            if (NetInfo.Language == LangMode.Vi)
            {
                // 処方箋出力ボタン
                this.btnPrescripPrt.Visible = false;
                // 封筒ラベル出力ボタン
                this.btnBongtuLabePrt.Visible = true;
                // 処方箋再出力ボタン
                this.btnPrescripRePrt.Visible = true;
            }
            else
            {
                // 処方箋出力ボタン
                this.btnPrescripPrt.Visible = false;
                // 封筒ラベル出力ボタン
                this.btnBongtuLabePrt.Visible = false;

                // https://sofiamedix.atlassian.net/browse/MED-15410
                // 処方箋再出力ボタン
                this.btnPrescripRePrt.Visible = true;
            }
            MasterServerCall();
            QueryTime = TimeVal;
        }

        #endregion

        #region dtpOrderDate

        private void dtpOrderDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            MasterServerCall();
            QueryTime = TimeVal;
        }

        #endregion

        #region grdOrder

        private void grdOrder_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            //			e.BackColor =  (e.DataRow["boryu_yn"].ToString() == "Y" ? XColor.XListViewHeaderBackColor.Color : XColor.XGridRowBackColor.Color);
            //
            //			if (e.ColName == "boryu_yn")
            //				e.ForeColor =  (e.DataRow["boryu_yn"].ToString() == "Y" ? XColor.ErrMsgForeColor.Color : XColor.NormalForeColor.Color);

            if (this.rbx1.Checked && (!e.DataRow["naewon_yn"].ToString().Equals("E")))
            {
                e.BackColor = Color.LightPink;
            }
        }

        private void grdOrder_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            switch (e.ColName)
            {
                case "act_yn":
                    //if ((e.DataRow["wonyoi_yn"].ToString() == "Y") || (e.DataRow["act_date"].ToString() != "") || (e.DataRow["sunab_date"].ToString() != ""))
                    // 1.院外の場合､  2.実施された場合､  3.診療終了&&未受付の場合  は受付チェックボックスにチェックｶﾞ出来ない｡
                    if ((e.DataRow["wonyoi_yn"].ToString() == "Y") || (e.DataRow["act_date"].ToString() != "") ||
                        ((!e.DataRow["naewon_yn"].ToString().Equals("E")) && this.rbx1.Checked))
                    {
                        e.Protect = true;
                        return;
                    }
                    e.Protect = false;
                    break;

                default:
                    break;
            }

            // 受付の場合、非活性化する（受付日、受付時間）
            if (this.rbx2.Checked && e.ColName == "drg_jubsu_date") e.Protect = true;

            if (this.rbx2.Checked && e.ColName == "jubsu_time") e.Protect = true;
        }

        private void grdOrder_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            if (e.ColName == "act_yn")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    this.grdOrder.SetItemValue(e.RowNumber, "chulgo_buseo", IHIS.Framework.UserInfo.BuseoCode);

                    if (this.rbx1.Checked) //未受付画面のみ設定
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "drg_jubsu_date", EnvironInfo.GetSysDate());
                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_time",
                            EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    }

                    this.grdOrder.SetItemValue(e.RowNumber, "act_yn", e.ChangeValue.ToString());
                }
                else
                {
                    this.grdOrder.SetItemValue(e.RowNumber, "chulgo_buseo", "");

                    if (this.rbx1.Checked) //未受付画面のみ設定
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "drg_jubsu_date", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_time", "");
                    }

                    this.grdOrder.SetItemValue(e.RowNumber, "act_yn", e.ChangeValue.ToString());
                }
            }
        }

        #endregion

        #region  grdOrderList

        private void grdOrderList_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            // DC 인경우 빨간 줄을 끈다
            if (e.DataRow["dc_yn"].ToString() == "Y")
            {
                switch (e.ColName)
                {
                    case "serial_v":
                    case "jaeryo_code":
                    case "jaeryo_name":
                    case "ord_suryang":
                    case "dv_time":
                    case "dv":
                    case "bogyong_code":
                    case "nalsu":
                    case "order_danui":
                    case "powder_yn":
                    case "atc_yn":
                        e.DrawMiddleLine = true;
                        e.MiddleLineColor = Color.Red;
                        break;
                    default:
                        break;
                }
            }

            // 마약인경우 빨간색으로 표현한다
            if (e.DataRow["mayak"].ToString() == "1")
            {
                e.ForeColor = Color.Red;
            }
        }

        private void grdOrderList_GridColumnProtectModify(object sender,
            IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            switch (e.ColName)
            {
                case "serial_v":
                case "gyunbon_yn":
                    if (rbx2.Checked || rbx3.Checked)
                    {
                        e.Protect = true;
                        return;
                    }
                    if (e.DataRow["wonyoi_yn"].ToString() == "Y")
                    {
                        e.Protect = true;
                        return;
                    }
                    e.Protect = false;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Button

        private void btnBoryu_Click(object sender, System.EventArgs e)
        {
            //if (!LockChk()) return;
            string check = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "boryu_yn");
            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "boryu_yn") == "Y")
            {
                grdOrder.SetItemValue(grdOrder.CurrentRowNumber, "boryu_yn", "N");

                if (DsvBoRyu(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "gwa"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "doctor"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"),
                    "N")) SetMsg(Service.ErrMsg, MsgType.Error);
            }
            else
            {
                grdOrder.SetItemValue(grdOrder.CurrentRowNumber, "boryu_yn", "Y");

                if (DsvBoRyu(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "gwa"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "doctor"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"),
                    "Y")) SetMsg(Service.ErrMsg, MsgType.Error);
            }

            if (!grdPaid.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        private void btnBoryuDel_Click(object sender, System.EventArgs e)
        {
            //if (!LockChk()) return;

            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "boryu_yn") == "Y")
            {
                grdOrder.SetItemValue(grdOrder.CurrentRowNumber, "boryu_yn", "N");

                if (DsvBoRyu(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "gwa"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "doctor"),
                    grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"),
                    "N")) SetMsg(Service.ErrMsg, MsgType.Error);

                if (!grdPaid.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            else
            {
                return;
            }
        }

        #region [-- DsvBoRyu --]

        /// <summary>
        /// dsvBoRuy Service Conversion PC:DRG5100P01, WT:C
        /// </summary>
        /// <param name="drgBunho"></param>
        /// <param name="bunho"></param>
        /// <param name="gwa"></param>
        /// <param name="doctor"></param>
        /// <param name="orderDate"></param>
        /// <param name="boryuYn"></param>
        /// <returns></returns>
        private bool DsvBoRyu(string drgBunho, string bunho, string gwa, string doctor, string orderDate, string boryuYn)
        {
            // TODO comment: use connect to cloud
            /*string cmdText = @"BEGIN
                                   UPDATE DRG2010
                                      SET BORYU_YN    = :f_boryu_yn
                                    WHERE HOSP_CODE   = :f_hosp_code
                                      AND DRG_BUNHO   = :f_drg_bunho
                                      AND GWA         = :f_gwa
                                      AND DOCTOR      = :f_doctor
                                      AND BUNHO       = :f_bunho
                                      AND NAEWON_DATE = TO_DATE(:f_order_date, 'YYYY/MM/DD');
                                     
                                   
                                   UPDATE OCS5010
                                      SET UPD_ID       = :q_user_id
                                         ,UPD_DATE     = SYSDATE
                                         ,CONFIRM_YN   = :f_boryu_yn
                                         ,RESULT_DATE  = TO_DATE(:f_order_date, 'YYYY/MM/DD')
                                    WHERE HOSP_CODE    = :f_hosp_code
                                      AND DOCTOR       = :f_doctor
                                      AND BUNHO        = :f_bunho
                                      AND JUNDAL_TABLE = 'DRG';
                                       
                                   IF SQL%NOTFOUND THEN
                                   INSERT INTO OCS5010(SYS_DATE             
                                                      ,SYS_ID              
                                                      ,UPD_DATE
                                                      ,DOCTOR
                                                      ,BUNHO
                                                      ,JUNDAL_TABLE
                                                      ,RESULT_DATE
                                                      ,CONFIRM_YN
                                                      ,HOSP_CODE)
                                                VALUES(SYSDATE
                                                      ,:q_user_id
                                                      ,SYSDATE
                                                      ,:f_doctor
                                                      ,:f_bunho
                                                      ,'DRG'
                                                      ,TO_DATE(:f_order_date, 'YYYY/MM/DD')
                                                      ,:f_boryu_yn
                                                      ,:f_hosp_code);
                                   END IF;
                               END;";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("q_user_id", UserInfo.UserID);
            bindVars.Add("f_boryu_yn", boryuYn);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_gwa", gwa);
            bindVars.Add("f_doctor", doctor);
            bindVars.Add("f_bunho", bunho);
            bindVars.Add("f_order_date", orderDate);*/

            DrgsDRG5100P01CheckDsvBoRyuArgs checkDsvBoRyuArgs = new DrgsDRG5100P01CheckDsvBoRyuArgs();
            checkDsvBoRyuArgs.UserId = UserInfo.UserID;
            checkDsvBoRyuArgs.BoryuYn = boryuYn;
            checkDsvBoRyuArgs.DrgBunho = drgBunho;
            checkDsvBoRyuArgs.Gwa = gwa;
            checkDsvBoRyuArgs.Doctor = doctor;
            checkDsvBoRyuArgs.Bunho = bunho;
            checkDsvBoRyuArgs.OrderDate = orderDate;

            try
            {
                UpdateResult updateResult =
                    CloudService.Instance.Submit<UpdateResult, DrgsDRG5100P01CheckDsvBoRyuArgs>(checkDsvBoRyuArgs);
                if (updateResult == null || updateResult.Result == false)
                {
                    XMessageBox.Show("DrgsDRG5100P01CheckDsvBoRyu: " + Resources.MSG_Execute_Error);
                    return false;
                }

                /*Service.BeginTransaction();
                if (!Service.ExecuteNonQuery(cmdText, bindVars)) throw new Exception(Service.ErrFullMsg);*/
            }
            catch (Exception xe)
            {
                //                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }
            //            Service.CommitTransaction();
            return true;
        }

        #endregion

        //private void btnScreenLock_Click(object sender, System.EventArgs e)
        //{
        //    if (!LockChk()) return;

        //    XScreen.LockupScreen();
        //}

        #endregion

        #region dsvSave

        private void grdOrder_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            string drgBunho = string.Empty;
            string orderDate = string.Empty;

            if (e.IsSuccess == true)
            {
                if (!grdOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
                MasterServerCall();
            }
        }

        #endregion

        #region dsvLabel

        private void layLabel_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            if (e.IsSuccess == true)
            {
                if (layLabel.RowCount > 0)
                {
                    PrintForm form = new PrintForm(layLabel.LayoutTable);
                    form.ShowDialog();
                    form.Dispose();
                }
            }
        }

        #endregion

        #region dsvOrderPrint

        private const int pageMaxLine = 42; // 한페이지 Max Row 수

        private void dsvOrderPrint_ServiceEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
        }

        #endregion

        private void grdOrderList_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            string finds = string.Empty;
            DataRow[] jupsurows = null;

            if (e.ColName == "gyunbon_yn")
            {
                finds = "serial_v = '" + e.DataRow["serial_v"].ToString() + "' ";

                jupsurows = grdOrderList.LayoutTable.Select(finds);
                if (jupsurows.Length > 0)
                {
                    foreach (DataRow jr in jupsurows)
                    {
                        jr["gyunbon_yn"] = e.ChangeValue.ToString();
                    }
                }

                grdOrderList.AcceptData();
                grdOrderList.DisplayData();
            }

            // 封筒ラベル出力のため、同じRPはチェックされる。
            if (e.ColName == "bongtu_check")
            {
                string serial_v = this.grdOrderList.GetItemString(e.RowNumber, "serial_v");

                for (int i = 0; i < grdOrderList.RowCount; i++)
                {
                    if (this.grdOrderList.GetItemString(i, "serial_v").Equals(serial_v))
                        this.grdOrderList.SetItemValue(i, "bongtu_check", e.ChangeValue.ToString());
                }
            }
        }

        private void xrbOrder_Click(object sender, System.EventArgs e)
        {
            MasterServerCall();
            QueryTime = TimeVal;
        }

        #region [旧 AtcSend]

        #endregion

        private void grdOrder_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (grdOrder.GetItemString(e.CurrentRow, "wonyoi_yn") == "Y")
            {
            }
            else
            {
                if (grdOrder.GetItemString(e.CurrentRow, "act_date") != "")
                {
                    btnATC.Enabled = true;
                }
            }

            //
            dbxDoctor.Text = grdOrder.GetItemString(e.CurrentRow, "doctor_name");
            dbxGwa.Text = grdOrder.GetItemString(e.CurrentRow, "buseo_name");
        }

        private void xButton1_Click(object sender, System.EventArgs e)
        {
            //if (!LockChk()) return;

            if (paid.BunHo == "")
            {
                MessageBox.Show(Resources.MessageBox1);
            }

            if (grdPaid.RowCount > 0)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", paid.BunHo);

                XScreen.OpenScreenWithParam(this, "DRGS", "DRG9040U00", ScreenOpenStyle.PopUpFixed, openParams);
            }
            else
            {
                XMessageBox.Show(Resources.MessageBox2, "Error");
            }
        }

        #region 처방전 출력

        private void UpdateDataWindowLanguage()
        {

       //     dw1.Modify(string.Format("t_hospital_name.text='{0}'", UserInfo.HospName));

            string bogyong_code = layOrderPrint.GetItemString(0, "bogyong_code");
       //     dw1.Modify(string.Format("t_order_no.text='{0}'", bogyong_code));

            string suname = layOrderPrint.GetItemString(0, "suname");
      //      dw1.Modify(string.Format("t_patient_name.text='{0}'", suname));

            string birth = layOrderPrint.GetItemString(0, "birth");
            string[] separators = { "-", "/"};
            if (!String.IsNullOrEmpty(birth))
            {
                string[] words = birth.Split(separators, StringSplitOptions.RemoveEmptyEntries);
   //             dw1.Modify(string.Format("t_birth_year.text='{0}'", words[0]));
            }
   //         dw1.Modify(string.Format("t_address.text='{0}'", ""));


            string sex_age = layOrderPrint.GetItemString(0, "sex_age");
            string sexValue = "Nam";
            if (sex_age == "F") sexValue = "Nữ";
   //         dw1.Modify(string.Format("t_sex.text='{0}'", sexValue));


   //         dw1.Modify(string.Format("t_main_sick.text='{0}'", ""));
   //         dw1.Modify(string.Format("t_insurance.text='{0}'", ""));
   //         dw1.Modify(string.Format("t_sub_sick.text='{0}'", ""));

  //          dw1.Modify(string.Format("t_doctor_comment.text='{0}'", ""));

            string t_date_signature = string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
    //        dw1.Modify(string.Format("t_date_signature.text='{0}'", t_date_signature));

            string doctor_name = layOrderPrint.GetItemString(0, "doctor_name");
  //          dw1.Modify(string.Format("t_lable_doctor.text='{0}'", doctor_name));
        }

        private void QueryWonnae01(string replay)
        {
            int row;

   //         dw1.Reset();
            //2011.10.05 yklee 
            //dw1.DataWindowObject = "d_drg2010_1";
     //       dw1.DataWindowObject = "d_won_order";
            layOrderPrint.Reset();
            layOrderJungbo.Reset();

            // 처방 내용
            string order_date = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
            string drg_bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho");
            bool orderPrint = DsvOrderPrint(order_date, drg_bunho);
            if (orderPrint)
            {
                row = layOrderPrint.RowCount;
                //2011.10.05 yklee
     //           dw1.FillData(layOrderPrint.LayoutTable);
                //dw1.FillData(layOrderPrint.LayoutTable);
            }

            //         코멘트 내용
            if (DsvOrderJungbo(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"),
                grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho")))
            {
                row = layOrderJungbo.RowCount;
                //dw1.FillChildData("dw_2", layOrderJungbo.LayoutTable);
            }

            if (NetInfo.Language == LangMode.Vi)
            {
                UpdateDataWindowLanguage();
            }
            else
            {
                // https://sofiamedix.atlassian.net/browse/MED-13442
                //dw1.Modify("t_47.text='" + UserInfo.HospCode + "'");
                //dw1.Modify("t_47.text='" + o_hosp_name + "'");
                //dw1.Modify("t_27.text='" + o_jaedan_name + "'");
                //dw1.Modify("t_54.text='" + hosp_address1 + "'");
               
            }

    //        dw1.AcceptText();

            try
            {
                // https://sofiamedix.atlassian.net/browse/MED-15410
                //dw1.Print();
                this.PrintHtmlTemplate();
            }
            catch
            {
            }

            // 향균의뢰서 출력
            /*
            if (!TypeCheck.IsNull(DsvDRG1000Load()))
            {
                dw_Anti.Reset();
                layAntiData.SetBindVarValue("f_fkocs", DsvDRG1000Load().ToString());
                if (layAntiData.QueryLayout(false))
                {
                    dw_Anti.FillData(layAntiData.LayoutTable);
                    dw_Anti.Print();
                }
            }
             */
        }

        #endregion

        #region DataValidating

        private void dtpToDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            MasterServerCall();
            QueryTime = TimeVal;
        }

        private void xBuseoCombo_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            MasterServerCall();
            QueryTime = TimeVal;
        }

        #endregion

        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            lbSuname.Text = paBox.SuName;
            MasterServerCall();
            QueryTime = TimeVal;
        }

        #region Timer

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            lbTime.Text = (QueryTime / 1000).ToString();
            QueryTime = QueryTime - 1000;

            if (QueryTime == 0)
            {
                //xrbOrder.Checked = true;
                //rbx1.Checked = true;
                //dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
                //dtpToDate.SetDataValue(EnvironInfo.GetSysDate());
                paBox.SetPatientID(string.Empty);

                MasterServerCall();

                //if (grdPaid.RowCount > 0)
                //{
                //    try
                //    {
                //        //파일이 있으면 파일 Play
                //        if (this.soundFileName != "")
                //            Kernel32.PlaySound(this.soundFileName, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                //        else  //없으면 기본 Sound
                //            IHIS.Framework.Kernel32.Nofify();
                //    }
                //    catch { }
                //}
                timer1.Stop();

                if (this.prescripPrnYN.Equals("Y") && cbxAutoJubsu.Checked == true)
                {
                    BindVarCollection bindVar = new BindVarCollection();


                    //약국 업무 시간 체크
                    /*string strCmd = @"SELECT FN_DRG_LOAD_CHECK_DRG_TIME(TRUNC(SYSDATE), '" +
                                    EnvironInfo.GetSysDateTime().ToString("HH24MI") + "') FROM DUAL";
                    object ret = Service.ExecuteScalar(strCmd);*/
                    DrgsDRG5100P01GetTimerArgs drg5100P01GetTimerArgs = new DrgsDRG5100P01GetTimerArgs();
                    drg5100P01GetTimerArgs.CurrentDate = EnvironInfo.GetSysDateTime().ToString("HH24MI");
                    DrgsDRG5100P01GetTimerResult timerResult =
                        CloudService.Instance.Submit<DrgsDRG5100P01GetTimerResult, DrgsDRG5100P01GetTimerArgs>(
                            drg5100P01GetTimerArgs);

                    //약국 시스템 && 업무시간 아니면.끝
                    //if ((EnvironInfo.CurrSystemName == "DRGS") && (ret.ToString() == "N"))
                    //    return;

                    this.xButtonList1.PerformClick(FunctionType.Preview);
                }

                timer1.Start();


                QueryTime = TimeVal;
            }
        }

        private void btnAuto_Click(object sender, System.EventArgs e)
        {
            timer1.Start();

            this.tbxTimer.SetDataValue("Y");
            //btnAuto.Enabled = false;
            //btnAutoStop.Enabled = true;
            btnAuto.ImageIndex = 0;
            btnAutoStop.ImageIndex = 12;
        }

        private void btnAutoStop_Click(object sender, System.EventArgs e)
        {
            timer1.Stop();

            this.tbxTimer.SetDataValue("N");
            //btnAuto.Enabled = true;
            //btnAutoStop.Enabled = false;
            btnAuto.ImageIndex = 12;
            btnAutoStop.ImageIndex = 0;
        }

        #endregion

        private void dsvOrder_ServiceEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            // 자동체크
            if (grdOrder.RowCount != 1) return;

            string act_yn = grdOrder.GetItemString(0, "act_yn");
            string jubsu_time = grdOrder.GetItemString(0, "jubsu_time");

            if ((act_yn == "N") && (jubsu_time == ""))
            {
                grdOrder.SetItemValue(0, "act_yn", "Y");
                grdOrder.AcceptData();
            }
        }

        #region 각 버튼클릭 이벤트

        private void btnBatPrint_Click(object sender, System.EventArgs e)
        {
            FrmBatJubsu dlg = new FrmBatJubsu();
            dlg.ShowDialog();
        }

        private void btnLable_Click(object sender, System.EventArgs e)
        {
            LablePrint(grdOrder.CurrentRowNumber);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            btnATC.Enabled = true;
        }

        private void btnAnti_Click(object sender, System.EventArgs e)
        {
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("DRGS", "DRG1000U01");

            if (aScreen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", grdPaid.GetItemString(grdPaid.CurrentRowNumber, "bunho"));

                XScreen.OpenScreenWithParam(this, "DRGS", "DRG1000U01", ScreenOpenStyle.ResponseSizable,
                    ScreenAlignment.ScreenMiddleCenter, openParams);
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }
        }

        private void xButton1_Click_1(object sender, System.EventArgs e)
        {
            LockForm dlg = new LockForm();
            dlg.ShowDialog();
        }

        private void btnBohoum_Click(object sender, System.EventArgs e)
        {
            if (grdPaid.RowCount > 0)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", grdPaid.GetItemString(grdPaid.CurrentRowNumber, "bunho"));
                openParams.Add("query_date", grdPaid.GetItemString(grdPaid.CurrentRowNumber, "jubsu_date"));
                XScreen.OpenScreenWithParam(this, "OUTS", "OUT0102Q00", ScreenOpenStyle.PopUpFixed, openParams);
            }
            else
            {
                XMessageBox.Show(Resources.MessageBox2, "Error");
            }
        }

        #endregion

        private void LablePrint(int row)
        {
            //string print_name = SetPrint(dw_lable, true);
            //string origin_print = SetPrint(dw_lable, false);
            //dw_lable.Reset();
            layNebokLabel.Reset();

            // Connect cloud
            layNebokLabel.ExecuteQuery = layNebokLabel_getData;
            // Order            
            //if (layNebokLabel.QueryLayout(false))
            //{
            //    dw_lable.FillData(layNebokLabel.LayoutTable);
            //}

            //dw_lable.AcceptText();
            //try
            //{
            //    if (print_name != "")
            //        IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name);

            //    if (dw_lable.RowCount > 0) dw_lable.Print();

            //    // 기본프린터 set
            //    if (origin_print != "")
            //        IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
            //}
            //catch
            //{
            //}
        }

        private void layAntiData_QueryEnd(object sender, QueryEndEventArgs e)
        {

            // TODO comment because method QueryWonnae01 not use layAntiData
            /*string cmdText = @"SELECT FN_BAS_LOAD_GWA_NAME(B.GWA, B.ORDER_DATE)       GWA_NAME
                                    , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, B.ORDER_DATE) DOCTOR_NAME
                                 FROM OCS1003 B
                                    , DRG1000 A
                                WHERE A.HOSP_CODE    = :f_hosp_code
                                  AND A.FKOCS        = :f_fkocs
                                  AND A.IN_OUT_GUBUN = 'O'
                                  AND B.HOSP_CODE    = A.HOSP_CODE
                                  AND B.PKOCS1003    = A.FKOCS
                               UNION
                               SELECT FN_BAS_LOAD_GWA_NAME(B.INPUT_GWA, B.ORDER_DATE)       GWA_NAME
                                    , FN_BAS_LOAD_DOCTOR_NAME(B.INPUT_DOCTOR, B.ORDER_DATE) DOCTOR_NAME
                                 FROM OCS2003 B
                                    , DRG1000 A
                                WHERE A.HOSP_CODE    = :f_hosp_code
                                  AND A.FKOCS        = :f_fkocs
                                  AND A.IN_OUT_GUBUN = 'I'
                                  AND B.HOSP_CODE    = A.HOSP_CODE
                                  AND B.PKOCS2003    = A.FKOCS";
            BindVarCollection bindVars = new BindVarCollection();
            DataTable resTable = new DataTable();
            for (int i = 0; i < layAntiData.RowCount; i++)
            {
                bindVars.Clear();
                resTable.Clear();
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVars.Add("f_fkocs", layAntiData.GetItemString(i, "fkocs"));

                resTable = Service.ExecuteDataTable(cmdText, bindVars);

                if (resTable.Rows.Count > 0)
                {
                    layAntiData.SetItemValue(i, "gwa_name", resTable.Rows[0]["gwa_name"].ToString());
                    layAntiData.SetItemValue(i, "doctor_name", resTable.Rows[0]["doctor_name"].ToString());
                }
            }*/
        }

        #region SetPrint

        private string SetPrint(XDataWindow dw_print, bool lable_yn)
        {
            string print_name = "";

            if (lable_yn)
            {
                foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    if (s == "SATO")
                    {
                        print_name = "SATO";
                        break;
                    }
                    else
                    {
                        if (s.IndexOf("SATO") >= 0)
                            print_name = s;
                    }
                }

                if (print_name.IndexOf("SATO") < 0)
                {
                    MessageBox.Show(Resources.MessageBox4);
                    //dw_print.PrintDialog(true);
                }
            }
            else
            {
                print_name = dw_print.PrintProperties.PrinterName;
            }

            return print_name;
        }

        #endregion

        /*
        #region DRG5100P01_Activated (화면이 활성화 될때 timer구동 상태이면 timer를 start시킨다.)
        private void DRG5100P01_Enter(object sender, System.EventArgs e)
        {
            if (this.tbxTimer.GetDataValue().ToString() == "Y")
                this.timer1.Start();
        }
        #endregion

        #region DRG5100P01_Leave (화면이 비활성화 될때 timer를 stop시킨다.)
        private void DRG5100P01_Leave(object sender, System.EventArgs e)
        {
            this.timer1.Stop();
        }
        #endregion
        */

        #region 각 그리드/레이아웃에 바인드변수 설정

        private void layLabel_QueryStarting(object sender, CancelEventArgs e)
        {
            // TODO Not use
            //            layLabel.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //            layLabel.SetBindVarValue("f_jubsu_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
            //            layLabel.SetBindVarValue("f_drg_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"));
        }

        private void layNebokLabel_QueryStarting(object sender, CancelEventArgs e)
        {
            // TODO not use
            //            layNebokLabel.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //            layNebokLabel.SetBindVarValue("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
            //            layNebokLabel.SetBindVarValue("f_drg_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"));
            //            layNebokLabel.SetBindVarValue("f_jubsu_date",
            //                grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jubsu_date"));
        }

        #endregion

        #region [-- DsvJubsuChk --]

        /// <summary>
        /// dsvJubsuChk Service Conversion PC:DRG5100P01, WT:M
        /// </summary>
        /// <returns></returns>
        private object DsvJubsuChk()
        {
            object jubsuCheck = "";
            /*string cmdText = @"SELECT 'Y'
                                 FROM DUAL
                                WHERE EXISTS ( SELECT 'X'
                                                 FROM DRG2010 A
                                                WHERE A.HOSP_CODE                = :f_hosp_code
                                                  AND A.ORDER_DATE               = TO_DATE(:f_order_date,'YYYY/MM/DD')
                                                  AND A.DRG_BUNHO                = :f_drg_bunho
                                                  AND NVL(A.DC_YN,'N')           = 'N'
                                                  AND A.SOURCE_FKOCS1003        IS NULL
                                                  AND NVL(A.WONYOI_ORDER_YN,'N') = 'N'
                                                  AND A.JUBSU_ILSI              IS NULL )";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
            bindVars.Add("f_drg_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"));
            jubsuCheck = Service.ExecuteScalar(cmdText, bindVars);*/

            // Connect cloud
            DrgsDRG5100P01CheckJubsuArgs drg5100P01CheckJubsuArgs = new DrgsDRG5100P01CheckJubsuArgs();
            drg5100P01CheckJubsuArgs.OrderDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
            drg5100P01CheckJubsuArgs.DrgBunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho");
            DrgsDRG5100P01CheckJubsuResult checkJubsuResult =
                CloudService.Instance.Submit<DrgsDRG5100P01CheckJubsuResult, DrgsDRG5100P01CheckJubsuArgs>(
                    drg5100P01CheckJubsuArgs);
            if (checkJubsuResult != null)
            {
                jubsuCheck = checkJubsuResult.Result;
            }
            return jubsuCheck;
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
            /*-----------------------Add address and tel-------------------------*/
            string o_address = string.Empty;
            string o_tel = string.Empty;
            /*-------------------------------------------------------------------*/
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

            /*BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            DataTable dtTables = new DataTable();
            DataTable dtSerial = new DataTable();
            DataTable dtRemark = new DataTable();*/

            int r_rec_cnt = 0;
            int line_cnt = 0;
            

            try
            {
                // Connect cloud
                if (rbx1.Checked || rbx2.Checked)
                {
                    dsvOrderPrintResult = orderPrint_getData("O", jubsuDate, drgBunho);
                }
                else
                {
                    dsvOrderPrintResult = orderPrint_getData("I", jubsuDate, drgBunho);
                }

                o_hosp_name = dsvOrderPrintResult.HospName;
                o_jaedan_name = dsvOrderPrintResult.JaedanName;
                hosp_address1 = dsvOrderPrintResult.HospAddress1;

                if (dsvOrderPrintResult == null)
                {
                    return false;
                }
                // FKOCS1003
                if (!string.IsNullOrEmpty(dsvOrderPrintResult.RetVal))
                {
                    o_fkocs1003 = dsvOrderPrintResult.RetVal;
                    

                }

                // PR_OUT_LOAD_CHEBANG_PRINT
                DrgsDRG5100P01LoadChebangPrintInfo chebangPrintInfo = dsvOrderPrintResult.ChebangPrintItem;
                if (chebangPrintInfo != null)
                {
                    o_gubun_name = chebangPrintInfo.OGubunName;
                    o_johap = chebangPrintInfo.OJohap;
                    o_gaein = chebangPrintInfo.OGaein;
                    o_gaein_no = chebangPrintInfo.OGaeinNo;
                    o_bonin_gubun = chebangPrintInfo.OBoninGubun;
                    o_bon_rate = chebangPrintInfo.OBonRate;
                    o_budamja_bunho1 = chebangPrintInfo.OBudamjaBunho1;
                    o_sugubja_bunho1 = chebangPrintInfo.OSugubjaBunho1;
                    o_budamja_bunho2 = chebangPrintInfo.OBudamjaBunho2;
                    o_sugubja_bunho2 = chebangPrintInfo.OSugubjaBunho2;
                    o_sunwon_gubun = chebangPrintInfo.OSunwonGubun;
                    o_noin_rate_name = chebangPrintInfo.ONoinRateName;
                    o_err = chebangPrintInfo.OErr;
                }

                /* 마약정보 Load */
                // PR_DRG_LOAD_MAKAY_JUNGBO
                DrgsDRG5100P01LoadMakayJungboInfo loadMakayJungboInfo = dsvOrderPrintResult.MakayJungbo;
                if (loadMakayJungboInfo != null)
                {
                    o_mayak_doctor = loadMakayJungboInfo.OMayakDoctor;
                    o_mayak_license = loadMakayJungboInfo.OMayakLicense;
                    o_mayak_address1 = loadMakayJungboInfo.OMayakAddress1;
                    o_mayak_address2 = loadMakayJungboInfo.OMayakAddress2;
                }

                /* DRG5100P01_WN_SERIAL_QRY: Create Dictionary<o_serial_text, List<DrgsDRG5100P01WnSerialQryListItemInfo>> */
                Dictionary<string, List<DrgsDRG5100P01WnSerialQryListItemInfo>> dictSerialText =
                    new Dictionary<string, List<DrgsDRG5100P01WnSerialQryListItemInfo>>();
                List<DrgsDRG5100P01WnSerialQryListItemInfo> lstWnSerialQryListItemInfos =
                    dsvOrderPrintResult.WnSerialItem;
                if (lstWnSerialQryListItemInfos != null && lstWnSerialQryListItemInfos.Count > 0)
                {
                    foreach (DrgsDRG5100P01WnSerialQryListItemInfo itemInfo in lstWnSerialQryListItemInfos)
                    {
                        List<DrgsDRG5100P01WnSerialQryListItemInfo> lstTemp = null;
                        if (dictSerialText.ContainsKey(itemInfo.OSerialText))
                        {
                            lstTemp = dictSerialText[itemInfo.OSerialText];
                            lstTemp.Add(itemInfo);
                        }
                        else
                        {
                            lstTemp = new List<DrgsDRG5100P01WnSerialQryListItemInfo>();
                            lstTemp.Add(itemInfo);
                            dictSerialText.Add(itemInfo.OSerialText, lstTemp);
                        }
                    }
                }

                /* DRGWONNEA_O_WN_CUR */
                List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> lstDrgwonneaOWnCurListInfo =
                    dsvOrderPrintResult.DrgwonneaOwnCur;
                if (lstDrgwonneaOWnCurListInfo != null && lstDrgwonneaOWnCurListInfo.Count > 0)
                {
                    //mins 추가 아오!!!!
                    line_cnt = lstDrgwonneaOWnCurListInfo.Count;
                    // dtTables
                    foreach (DrgsDRG5100P01DrgwonneaOWnCurListInfo oWnCurListInfo in lstDrgwonneaOWnCurListInfo)
                    {
                        o_suname = oWnCurListInfo.Suname;
                        o_suname2 = oWnCurListInfo.Suname2;
                        o_birth = oWnCurListInfo.Birth;
                        o_age_sex = oWnCurListInfo.SexAge;
                        o_other_gwa = oWnCurListInfo.OtherGwa;
                        o_do_order = oWnCurListInfo.DoOrder;
                        o_jigan_date = oWnCurListInfo.GigamDate;
                        o_bunho = oWnCurListInfo.Bunho;
                        o_drg_bunho = oWnCurListInfo.DrgBunho;
                        o_naewon_date = oWnCurListInfo.NaewonDate;
                        o_jubsu_date = oWnCurListInfo.JubsuDate;
                        o_order_date = oWnCurListInfo.OrderDate;
                        o_serial_v = oWnCurListInfo.SerialV;
                        o_serial_text = oWnCurListInfo.SerialText;
                        o_gwa_name = oWnCurListInfo.GwaName;
                        o_doctor_name = oWnCurListInfo.DoctorName;
                        o_address = oWnCurListInfo.Address;
                        o_tel = oWnCurListInfo.Tel;


                        /* DRG5100P01_WN_SERIAL_QRY */
                        // 이흥도 약 오더, 수불 단위 변경
                        if (dictSerialText.ContainsKey(o_serial_text))
                        {
                            List<DrgsDRG5100P01WnSerialQryListItemInfo> lstWnSerialQryListItemInfo =
                                dictSerialText[o_serial_text];
                            //mins
                            line_cnt += lstWnSerialQryListItemInfo.Count;

                            // dtSerial
                            foreach (
                                DrgsDRG5100P01WnSerialQryListItemInfo wnSerialQryListItemInfo in
                                    lstWnSerialQryListItemInfo)
                            {
                                o_group_ser = wnSerialQryListItemInfo.GroupSer;
                                o_jaeryo_code = wnSerialQryListItemInfo.JaeryoCode;
                                o_nalsu = wnSerialQryListItemInfo.Nalsu;
                                o_divide = wnSerialQryListItemInfo.Divide;
                                o_ord_suryang = wnSerialQryListItemInfo.DrgOrderSuryang;
                                o_order_suryang = wnSerialQryListItemInfo.OrderSuryang;
                                o_order_danui = wnSerialQryListItemInfo.DrgOrderDanui;
                                o_subul_danui = wnSerialQryListItemInfo.SubulDanui;
                                o_group_yn = wnSerialQryListItemInfo.GroupYn;
                                o_jaeryo_gubun = wnSerialQryListItemInfo.JaeryoGubun;
                                o_bogyong_code = wnSerialQryListItemInfo.BogyongCode;
                                o_bogyong_name = wnSerialQryListItemInfo.BogyongName;
                                o_caution_name = wnSerialQryListItemInfo.CautionName;
                                o_caution_code = wnSerialQryListItemInfo.CautionCode;
                                o_mix_yn = wnSerialQryListItemInfo.MixYn;
                                o_atc_yn = wnSerialQryListItemInfo.AtcYn;
                                o_dv = wnSerialQryListItemInfo.Dv;
                                o_dv_time = wnSerialQryListItemInfo.DvTime;
                                o_dc_yn = wnSerialQryListItemInfo.DcYn;
                                o_bannab_yn = wnSerialQryListItemInfo.BannabYn;
                                o_source_fkocs1003 = wnSerialQryListItemInfo.SourceFkocs1003;
                                o_fkocs1003 = wnSerialQryListItemInfo.Fkocs1003;
                                o_sunab_date = wnSerialQryListItemInfo.SunabDate;
                                o_pattern = wnSerialQryListItemInfo.Pattern;
                                o_jaeryo_name = wnSerialQryListItemInfo.JaeryoName;
                                o_sunab_nalsu = wnSerialQryListItemInfo.SunabNalsu;
                                o_wonyoi_yn = wnSerialQryListItemInfo.WonyoiYn;
                                o_act_date = wnSerialQryListItemInfo.ActDate;
                                o_mayak = wnSerialQryListItemInfo.Mayak;
                                o_tpn_joje_gubun = wnSerialQryListItemInfo.TpnJojeGubun;
                                o_ui_jusa_yn = wnSerialQryListItemInfo.UiJusaYn;
                                o_subul_suryang = wnSerialQryListItemInfo.SubulSuryang;
                                o_serial_v = wnSerialQryListItemInfo.SerialV;
                                o_gwa_name = wnSerialQryListItemInfo.GwaName;
                                o_doctor_name = wnSerialQryListItemInfo.DoctorName;
                                o_suname = wnSerialQryListItemInfo.Suname;
                                o_suname2 = wnSerialQryListItemInfo.Suname2;
                                o_birth = wnSerialQryListItemInfo.Birth;
                                o_age_sex = wnSerialQryListItemInfo.SexAge;
                                o_other_gwa = wnSerialQryListItemInfo.OtherGwa;
                                o_do_order = wnSerialQryListItemInfo.DoOrder;
                                o_hope_nm = wnSerialQryListItemInfo.HopeDate;
                                o_powder_yn = wnSerialQryListItemInfo.PowderYn;
                                o_serial_cnt = wnSerialQryListItemInfo.Line;
                                o_kyukyeok = wnSerialQryListItemInfo.Kyukyeok;
                                o_licenes = wnSerialQryListItemInfo.License;
                                o_mix_group = wnSerialQryListItemInfo.MixGroup;
                                o_donbok = wnSerialQryListItemInfo.Donbok;
                                o_tusuk = wnSerialQryListItemInfo.Tusuk;
                                o_bigo = wnSerialQryListItemInfo.CautionNm;
                                o_key = wnSerialQryListItemInfo.OrderSort;
                                o_text_color = wnSerialQryListItemInfo.TextColor;
                                o_changgo = wnSerialQryListItemInfo.Changgo;
                                o_hubal_change_yn = wnSerialQryListItemInfo.HubalChangeYn;
                                o_hubal_all_yn = wnSerialQryListItemInfo.HubalAllYn;

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
                        }
                        if(NetInfo.Language == LangMode.Vi) continue;

                        /*Fix bug MED-7718*/
                        /*-------------Print address and tel---------------------*/
                        this._tel = o_tel;
                        this._address1 = o_address;

                        string temp = Regex.Replace(o_address, @"\t", "\\\\t");

                        //dw1.Modify("t_53.text='" + temp + "'");
                        //dw1.AcceptText();
                        //dw1.Modify("t_52.text='" + o_tel + "'");
                        //dw1.AcceptText();
                        /*------------------------------------*/
                        /********** modify kimminsoo ***************
                            * 이거 여기 왜 들어갔는지 이해 안감
                            * 약국 다시 첨부터 짜는게 속 편함
                            * *****************************************/
                        /* row insert */
                        //                        BindVarCollection bindVars = new BindVarCollection();
                        //                        bindVars.Remove("o_bogyong_name");
                        //                        bindVars.Add("o_bogyong_name", JapanTextHelper.Half2Full(o_bogyong_name));
                        //                        cmdText = "SELECT TRUNC(length(NVL(:o_bogyong_name,' ')) / 60) CNT FROM DUAL";
                        //                        retVal = Service.ExecuteScalar(cmdText, bindVars);
                        /* Insert Row 계산*/

                        if (!string.IsNullOrEmpty(o_bogyong_name))
                        {
                            float length = o_bogyong_name.Length / 60;
                            retVal = Math.Truncate(length);
                        }
                        o_row = 0;
                        if (!TypeCheck.IsNull(retVal))
                        {
                            o_row = Convert.ToInt32(retVal);
                        }

                        //2015/09/25
                        int lengthRemain = o_bogyong_name.Length;

                        for (int b = 0; b <= o_row; b++)
                        {
                            t_bogyong_name = string.Empty;
                            //                            BindVarCollection bindName = new BindVarCollection();
                            //                            bindName.Add("o_bogyong_name", JapanTextHelper.Half2Full(o_bogyong_name));
                            //                            bindName.Add("b", b.ToString());
                            //                            cmdText = "SELECT SUBSTR(:o_bogyong_name, (:b * 60) + 1, 60) FROM DUAL";
                            //                            retVal = Service.ExecuteScalar(cmdText, bindName);
                            retVal = null;
                            if (!string.IsNullOrEmpty(o_bogyong_name))
                            {
                                //retVal = o_bogyong_name.Substring((b * 60) + 1, 60);
                                int startPoint = (b * 60) + 1;
                                retVal = o_bogyong_name.Substring(startPoint, lengthRemain < 60 ? o_bogyong_name.Length - startPoint : 60 - 1);
                                lengthRemain -= 60;
                            }
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
                    }
                }
                if (NetInfo.Language == LangMode.Vi) return true;


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
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
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

            /*string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_jubsu_date", orderDate);
            bindVars.Add("f_drg_bunho", drgBunho);

            DataTable dtPrinco = new DataTable();
            DataTable dtJungbo = new DataTable();*/

            List<DrgsDRG5100P01OrderJungboInfo> lstOrderJungboInfos = new List<DrgsDRG5100P01OrderJungboInfo>();
            try
            {
                // Connect to cloud
                DrgsDRG5100P01DsvOrderJungboResult dsvOrderJungboResult = dsvOrderJungbo_getData(orderDate, drgBunho);
                if (dsvOrderJungboResult == null)
                {
                    XMessageBox.Show("DrgsDRG5100P01DsvOrderJungbo: " + Resources.MSG_Execute_Error);
                    return false;
                }
                lstOrderJungboInfos = dsvOrderJungboResult.OrderJungboItem;


                if (TypeCheck.IsNull(lstOrderJungboInfos) || lstOrderJungboInfos.Count < 1)
                {
                    o_bar_drg_bunho = dsvOrderJungboResult.BarDrgBunho;

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

                foreach (DrgsDRG5100P01OrderJungboInfo orderJungboInfo in lstOrderJungboInfos)
                {
                    o_seq_1 = orderJungboInfo.Seq1;
                    o_seq_2 = orderJungboInfo.Seq2;
                    o_text_1 = orderJungboInfo.Text1;
                    o_text_2 = orderJungboInfo.Text2;
                    o_text_3 = orderJungboInfo.Text3;
                    o_comments = orderJungboInfo.Remark;
                    o_bar_drg_bunho = orderJungboInfo.BarDrgBunho;
                    o_bunho = orderJungboInfo.Bunho;

                    DrgsDRG5100P01JungboInfo jungboInfo = orderJungboInfo.JungboInfo;
                    if (jungboInfo != null)
                    {
                        o_cpl_1 = jungboInfo.Height;
                        o_danui_1 = jungboInfo.Cm;
                        o_cpl_2 = jungboInfo.Weight;
                        o_danui_2 = jungboInfo.Kg;
                        o_cpl_3 = jungboInfo.CplResult;
                        o_comments = jungboInfo.Comments;
                        o_row = int.Parse(jungboInfo.Cnt);
                    }
                    for (int b = 0; b <= o_row; b++)
                    {
                        //MED-3314 -- 
                        int startIndex = b * 80 + 1;
                        if (o_comments != string.Empty && o_comments.Length > 80)
                        {
                            t_comments = o_comments.Substring(startIndex, 80);
                        }

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

                /* cmdText = @"SELECT '1'                SEQ_1
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
                             WHERE A.HOSP_CODE      = :f_hosp_code
                               AND A.ORDER_DATE     = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO      = :f_drg_bunho
                               AND B.HOSP_CODE      = A.HOSP_CODE
                               AND B.FKOCS          = A.FKOCS1003
                               AND C.HOSP_CODE   (+)= A.HOSP_CODE
                               AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                               AND D.HOSP_CODE   (+)= A.HOSP_CODE
                               AND D.FKOCS1003   (+)= A.FKOCS1003
                               AND B.ORDER_REMARK   IS NOT NULL
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
                             WHERE A.HOSP_CODE      = :f_hosp_code
                               AND A.ORDER_DATE     = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO      = :f_drg_bunho
                               AND C.HOSP_CODE   (+)= A.HOSP_CODE
                               AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                               AND NVL(C.CHKD,'N')  = 'Y'
                               AND D.HOSP_CODE   (+)= A.HOSP_CODE
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
                             WHERE A.HOSP_CODE   = :f_hosp_code
                               AND A.ORDER_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO   = :f_drg_bunho
                               AND B.HOSP_CODE   = A.HOSP_CODE
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
                             WHERE A.HOSP_CODE     = :f_hosp_code
                               AND A.ORDER_DATE    = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO     = :f_drg_bunho
                               AND B.HOSP_CODE  (+)= A.HOSP_CODE
                               AND B.BUNHO      (+)= A.BUNHO
                               AND B.ORDER_REMARK IS NOT NULL
                             ORDER BY 1, 2";

                dtPrinco = Service.ExecuteDataTable(cmdText, bindVars);

                if (TypeCheck.IsNull(dtPrinco) || dtPrinco.Rows.Count < 1)
                {
                    cmdText = @"SELECT DISTINCT '*'||TO_CHAR(A.ORDER_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'
                                  FROM DRG2010 A
                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                   AND A.ORDER_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
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
                }*/
            }
            catch (Exception xe)
            {
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }
            return true;
        }

        #endregion

        #region [-- DsvDRG1000Load --}

        #endregion

        #region [-- DsvAtcSend --]

        #endregion

        #region 오더리스트 조회 바인드변수 셋팅

        private void grdOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            string gubun = string.Empty;
            if (rbx1.Checked) gubun = "1";
            if (rbx2.Checked) gubun = "2";
            if (rbx3.Checked) gubun = "3";

            grdOrderList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdOrderList.SetBindVarValue("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
            grdOrderList.SetBindVarValue("f_drg_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"));
            grdOrderList.SetBindVarValue("f_wonyoi_yn", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "wonyoi_yn"));
            grdOrderList.SetBindVarValue("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
            grdOrderList.SetBindVarValue("f_gubun", gubun);
        }

        #endregion

        #region 환자리스트 그리드 확장/축소

        private void btnExpand_Click(object sender, EventArgs e)
        {
            string tipText = "";
            if (grdPaid.CellInfos["order_date"].CellWidth > 1)
            {
                grdPaid.CellInfos["order_date"].CellWidth = 1;
                grdPaid.AutoSizeColumn(1, 1);
                btnExpand.ImageIndex = 11;
                tipText = XMsg.GetField("F002"); // 오더일보기
                this.toolTip.SetToolTip((Control)sender, tipText);
                grdPaid.Refresh();
            }
            else
            {
                grdPaid.CellInfos["order_date"].CellWidth = 80;
                grdPaid.AutoSizeColumn(1, 80);
                btnExpand.ImageIndex = 10;
                tipText = XMsg.GetField("F003"); // 오더일안보기
                this.toolTip.SetToolTip((Control)sender, tipText);
                grdPaid.Refresh();
            }
        }

        #endregion

        #region ｢btnGeneric_Click｣ オーダリストの一般名表示/非表示

        private void btnGeneric_Click(object sender, EventArgs e)
        {
            string tipText = "";
            if (grdOrderList.CellInfos["generic_name"].CellWidth > 1)
            {
                grdOrderList.CellInfos["generic_name"].CellWidth = 1;
                grdOrderList.AutoSizeColumn(5, 1);
                btnGeneric.ImageIndex = 11;
                //tipText = XMsg.GetField("F002"); // 오더일보기
                tipText = Resources.btnGenericText;
                this.toolTip.SetToolTip((Control)sender, tipText);
                grdOrderList.Refresh();
            }
            else
            {
                grdOrderList.CellInfos["generic_name"].CellWidth = 265;
                grdOrderList.AutoSizeColumn(5, 265);
                btnGeneric.ImageIndex = 10;
                //tipText = XMsg.GetField("F003"); // 오더일안보기
                tipText = "一般名非表示";
                this.toolTip.SetToolTip((Control)sender, tipText);
                grdOrderList.Refresh();
            }
        }

        #endregion

        #region 믹스표시 하기

        private void grdOrderList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.DiaplayMixGroup(grdOrderList);
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
                    if (aGrd.GetItemString(i, "dc_yn") == "Y") continue;

                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) &&
                        aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() ==
                                aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() ==
                                aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "hope_date").ToString().Trim() ==
                                aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1))
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image =
                                        this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image =
                                        this.imageListMixGroup.Images[imageCnt];
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

        private void txtTimeInterval_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsInt(e.DataValue))
            {
                QueryTime = int.Parse(e.DataValue);
                TimeVal = int.Parse(e.DataValue);


                lbTime.Text = (QueryTime / 1000).ToString();
                //lbTime.Text = TimeVal.ToString();
                //lbTime.Text = time.Minute + ":" + time.Second;

                if (tbxTimer.GetDataValue() == "Y")
                {
                    timer1.Stop();
                    timer1.Start();
                }
            }
            else
            {
                PostCallHelper.PostCall(new PostMethod(PostTimerValidating));
            }
        }

        private void PostTimerValidating()
        {
            txtTimeInterval.SetDataValue(TimeVal.ToString());
        }

        #region [cboTime_SelectionChangeCommitted] 自動照会コンボボックスSELECTED

        private void cboTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            timer1.Stop();
            //this.timer1.Interval = Int32.Parse(this.cboTime.GetDataValue());
            this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            this.txtTimeInterval.AcceptData();

            timer1.Start();
        }

        #endregion

        #region [prtBongtuLabel] 封筒ラベル情報セット

        private void btnBongtuLabePrt_Click(object sender, EventArgs e)
        {
            // オーダリスト
            for (int i = 0; i < this.grdOrderList.RowCount; i++)
            {
                string prtYn = this.grdOrderList.GetItemString(i, "bongtu_check");
                string beforeSerial = this.grdOrderList.GetItemString(i - 1, "serial_v");
                string afterSerial = this.grdOrderList.GetItemString(i, "serial_v");

                if (prtYn.Equals("Y") && !beforeSerial.Equals(afterSerial)) this.prtBongtuLabel(i);
            }
        }

        private void prtBongtuLabel(int prtRp)
        {
     //       dw1.Reset();
     //       dw1.DataWindowObject = "d_drg2010_bongtu_label";

            layBongtuLabel.Reset();

            int grdPaidRow = this.grdPaid.CurrentRowNumber;
            int grdOrderRow = this.grdOrder.CurrentRowNumber;
            int grdOrderListRow = prtRp;

            if (TypeCheck.IsNull(grdPaidRow) || TypeCheck.IsNull(grdOrderRow) || TypeCheck.IsNull(grdOrderListRow))
                return;

            string bunho = this.grdPaid.GetItemString(grdPaidRow, "bunho");
            string suname = this.grdPaid.GetItemString(grdPaidRow, "suname");
            string drg_bunho = this.grdPaid.GetItemString(grdPaidRow, "drg_bunho");

            string selectedRp = this.grdOrderList.GetItemString(grdOrderListRow, "serial_v");

            int insertRow = 0;

            // Connect cloud get data for layBongtuInfo
            Hashtable hashtable = createHashtableFkocs1003(prtRp);

            for (int i = 0; i < this.grdOrderList.RowCount; i++)
            {
                string serial_v = this.grdOrderList.GetItemString(i, "serial_v");

                string jojae_date = null;
                //                string jubsu_date = this.grdOrderList.GetItemString(i, "jubsu_date");
                //                string act_date = this.grdOrderList.GetItemString(i, "act_date");
                string jubsu_date_wareki = null;
                string act_date_wareki = null;
                string pattern = null;
                string jaeryo_name = this.grdOrderList.GetItemString(i, "jaeryo_name");
                //                string bogyong_code = this.grdOrderList.GetItemString(i, "bogyong_code");
                string bogyong_name = this.grdOrderList.GetItemString(i, "bogyong_name");
                string nalsu = this.grdOrderList.GetItemString(i, "nalsu");
                string donbok_yn = null;

                // 封筒情報取得
                /*this.layBongtuInfo.QuerySQL =
                    @"SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1', SUBSTR(:f_jubsu_date, 0, 10)) JUBSU_DATE_WAREKI
                                                     , FN_BAS_TO_JAPAN_DATE_CONVERT('1', SUBSTR(:f_act_date, 0, 10)) ACT_DATE_WAREKI
                                                     --, DECODE(FN_DRG_LOAD_DONBOK_YN(:f_bogyong_code), 'Y', '回分', '日分') DONBOK_YN
                                                     , NVL(FN_DRG_LOAD_DONBOK_YN(:f_bogyong_code), 'N')                      DONBOK_YN
                                                     , FN_DRG_LOAD_DRG0120_PATTERN('O', :f_fkocs1003)                        PATTERN
                                                  FROM DUAL";

                this.layBongtuInfo.SetBindVarValue("f_jubsu_date", jubsu_date);
                this.layBongtuInfo.SetBindVarValue("f_act_date", act_date);
                this.layBongtuInfo.SetBindVarValue("f_bogyong_code", bogyong_code);
                this.layBongtuInfo.SetBindVarValue("f_fkocs1003", this.grdOrderList.GetItemString(i, "fkocs1003"));

                if (this.layBongtuInfo.QueryLayout(true))
                if (layBongtuInfo.RowCount > 0)
                {
                    jubsu_date_wareki = layBongtuInfo.GetItemString(0, "jubsu_date_wareki");
                    act_date_wareki = layBongtuInfo.GetItemString(0, "act_date_wareki");
                    donbok_yn = layBongtuInfo.GetItemString(0, "donbok_yn");
                    pattern = layBongtuInfo.GetItemString(0, "pattern");
                }*/

                if (hashtable.Count > 0)
                {
                    DrgsDRG5100P01LayBongtuInfo bongtuInfo = (DrgsDRG5100P01LayBongtuInfo)hashtable["fkocs1003"];
                    jubsu_date_wareki = bongtuInfo.JubsuDateWareki;
                    act_date_wareki = bongtuInfo.ActDateWareki;
                    donbok_yn = bongtuInfo.DonbokYn;
                    pattern = bongtuInfo.Pattern;
                }

                string bunryu1 = this.grdOrderList.GetItemString(i, "bunryu1");
                string suryang = this.grdOrderList.GetItemString(i, "ord_suryang");
                string dv = this.grdOrderList.GetItemString(i, "dv");
                string danui = this.grdOrderList.GetItemString(i, "order_danui");

                // 一回服用量
                string dosage = "";

                // 一回服用量 : 外用は「空白」
                if (bunryu1.Contains("6"))
                {
                    nalsu = ""; //外用の場合、表示無
                    dosage = "";
                }
                else
                {
                    // PATTERNがあれば、「空白」
                    if (TypeCheck.IsNull(pattern))
                    {
                        // 一回服用量 : 内服は　→　頓服は「オーダ数量」、頓服ではないと「一回量」
                        if (donbok_yn.Equals("Y"))
                        {
                            nalsu = dv + "回分";
                            dosage = suryang + danui;
                        }
                        else
                        {
                            nalsu = nalsu + "日分";
                            //dosage = ((double)(double.Parse(suryang) / double.Parse(dv))).ToString() + danui;
                            //MED-6718 modified on 18.01.2016
                            dosage = ((double)(double.Parse(suryang) / double.Parse(dv))).ToString("0.0") + danui;
                        }
                    }
                    else dosage = "";
                }

                //if(donbok_yn.Equals("Y")) nalsu = dv + "回分";
                //else nalsu = nalsu + "日分";

                // 調剤日セット
                if (TypeCheck.IsNull(act_date_wareki)) jojae_date = jubsu_date_wareki;
                else jojae_date = act_date_wareki;

                if (serial_v.Equals(selectedRp))
                {
                    this.layBongtuLabel.InsertRow(i);

                    this.layBongtuLabel.SetItemValue(insertRow, "bunho", bunho);
                    this.layBongtuLabel.SetItemValue(insertRow, "suname", suname + Resources.layBongtuLabel3);
                    this.layBongtuLabel.SetItemValue(insertRow, "drg_bunho", Resources.layBongtuLabel1 + drg_bunho);
                    this.layBongtuLabel.SetItemValue(insertRow, "act_date", Resources.layBongtuLabel2 + jojae_date);
                    this.layBongtuLabel.SetItemValue(insertRow, "jaeryo_name", jaeryo_name);
                    this.layBongtuLabel.SetItemValue(insertRow, "bogyong_name", bogyong_name);
                    this.layBongtuLabel.SetItemValue(insertRow, "nalsu", nalsu);
                    this.layBongtuLabel.SetItemValue(insertRow, "suryang", dosage);
                    //this.layBongtuLabel.SetItemValue(insertRow, "donbok_yn", donbok_yn);

                    insertRow = insertRow + 1;
                }
            }

 //           dw1.FillData(layBongtuLabel.LayoutTable);

  //          dw1.AcceptText();

            //바코드프린터명 가져오기
            layPrintName.ExecuteQuery = layPrintName_getData;
            this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

  //          dw1.PrintProperties.PrinterName = printSetName;
            //try
            //{
            //    dw1.Print();
            //}
            //catch
            //{
            //}
        }

        #endregion

        #region 바코드 프린터 설정

        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            this.SetPrint();
        }

        private void SetPrint()
        {
            //Open the PrintDialog
            this.printDialog1.Document = this.printDocument1;
            DialogResult dr = this.printDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //Get the Copy times
                int nCopy = this.printDocument1.PrinterSettings.Copies;
                //Get the number of Start Page
                int sPage = this.printDocument1.PrinterSettings.FromPage;
                //Get the number of End Page
                int ePage = this.printDocument1.PrinterSettings.ToPage;
                //Get the printer name
                string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                /*string cmdText = @" DECLARE 
    
                                        T_TRM_ID VARCHAR2(8) := ''; 

                                    BEGIN
                                        UPDATE ADM3300
                                           SET USER_ID         = :q_user_id
                                             , UP_TIME         = SYSDATE
                                             , B_PRINT_NAME    = :f_b_print_name
                                         WHERE HOSP_CODE       = :f_hosp_code 
                                           AND IP_ADDR         = :f_ip_addr;
                                           
                                              
                                           IF SQL%NOTFOUND THEN       
                                             
                                             SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
                                               INTO T_TRM_ID
                                               FROM ADM3300
                                              WHERE HOSP_CODE = :f_hosp_code;
                                              
                                             INSERT INTO ADM3300
                                                  ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
                                                    USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
                                                VALUES 
                                                  ( T_TRM_ID, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
                                                    NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name);       
                                                    
                                           END IF; 

                                    END;";

                BindVarCollection bc = new BindVarCollection();
                bc.Add("q_user_id", UserInfo.UserID);
                bc.Add("f_b_print_name", PrinterName);
                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_ip_addr", NetInfo.ClientIP.ToString());
                if (!Service.ExecuteNonQuery(cmdText, bc))
*/
                CPL2010U00SetPrintArgs drg5100P01SetPrintArgs = new CPL2010U00SetPrintArgs();
                drg5100P01SetPrintArgs.BPrintName = PrinterName;
                drg5100P01SetPrintArgs.IpAddr = NetInfo.ClientIP;
                drg5100P01SetPrintArgs.UserId = UserInfo.UserID;
                UpdateResult updateResult =
                    CloudService.Instance.Submit<UpdateResult, CPL2010U00SetPrintArgs>(drg5100P01SetPrintArgs);

                if (updateResult == null || updateResult.Result == false)
                {
                    XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.Caption2,
                        MessageBoxIcon.Warning);
                }
            }
        }


        private void layPrintName_QueryStarting(object sender, CancelEventArgs e)
        {
            // TODO comment: User connect cloud
            /*this.layPrintName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layPrintName.SetBindVarValue("f_ip_addr", NetInfo.ClientIP.ToString());*/
        }

        #endregion

        private void btnPrescripPrt_Click(object sender, EventArgs e)
        {
            // 処方箋出力可否 prescripPrnYN

            if (this.prescripPrnYN.Equals("N"))
            {
                this.btnPrescripPrt.ImageIndex = 0;
                this.prescripPrnYN = "Y";
            }
            else
            {
                this.btnPrescripPrt.ImageIndex = 12;
                this.prescripPrnYN = "N";
            }
        }

        private void btnUseTimeChk_Click(object sender, EventArgs e)
        {
            // 自動照会使用可否 useTimeChkYN 

            if (this.useTimeChkYN.Equals("N"))
            {
                this.btnUseTimeChk.ImageIndex = 0;
                this.useTimeChkYN = "Y";

                this.timer1.Start();
                this.cboTime.Enabled = true;
                this.tbxTimer.SetDataValue("Y");
                this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
                this.txtTimeInterval.AcceptData();
            }
            else
            {
                this.btnUseTimeChk.ImageIndex = 12;
                this.useTimeChkYN = "N";

                this.cboTime.Enabled = false;
                this.timer1.Stop();
            }
        }

        private void btnPrescripRePrt_Click(object sender, EventArgs e)
        {
            //https://sofiamedix.atlassian.net/browse/MED-14269
            if (rbx3.Checked)
            {
                GetDataToPrint();
                return;
            }
            //if (!LockChk()) return;

            if (grdOrderList.RowCount == 0) return;

            // 미접수건이 있는 지 체크(jubsu_check = "Y" --> 미접수)
            if (!TypeCheck.IsNull(DsvJubsuChk()))
            {
                if (DsvJubsuChk().ToString() == "Y")
                {
                    string msg = (NetInfo.Language == LangMode.Ko
                        ? Resources.MessageBox3_Ko
                        : Resources.MessageBox3_JP);
                    XMessageBox.Show(msg, Resources.Caption1);
                    return;
                }
            }

            // 처방전 출력
            QueryWonnae01("R");
        }
        //https://sofiamedix.atlassian.net/browse/MED-14269
        private void GetDataToPrint()
        {
            int row;
   //         dw1.Reset();
   //         dw1.DataWindowObject = "d_won_order";
            layOrderPrint.Reset();

            string order_date = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
            string drg_bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho");
            bool orderPrint = DsvOrderPrint(order_date, drg_bunho);
            SetdataLayPrint();
            if (grdOrderList_count > 0)
            {
                row = layOrderPrint.RowCount;
                //2011.10.05 yklee
      //          dw1.FillData(layOrderPrint.LayoutTable);
                //dw1.FillData(layOrderPrint.LayoutTable);
            }

            if (NetInfo.Language == LangMode.Vi)
            {
                UpdateDataWindowLanguage();
            }
            else
            {
                // https://sofiamedix.atlassian.net/browse/MED-13442
                //dw1.Modify("t_47.text='" + UserInfo.HospCode + "'");
                //dw1.Modify("t_47.text='" + o_hosp_name + "'");
                //dw1.Modify("t_27.text='" + o_jaedan_name + "'");
                //dw1.Modify("t_54.text='" + hosp_address1 + "'");

            }

   //         dw1.AcceptText();

            try
            {
                // https://sofiamedix.atlassian.net/browse/MED-15410
                //dw1.Print();
                this.PrintHtmlTemplate();
            }
            catch
            {
            }
        }
        //https://sofiamedix.atlassian.net/browse/MED-14269
        private void SetdataLayPrint()
        {
            //int rownum1 = 0;

            //for (int i = 0; i < grdOrderList_count; i++)
            //{
            //    rownum1 = layOrderPrint.InsertRow(-1);
            //    layOrderPrint.SetItemValue(rownum1, "order_danui", grdOrderList.GetItemString(i, "order_danui"));
            //    layOrderPrint.SetItemValue(rownum1, "jaeryo_name", grdOrderList.GetItemString(i, "jaeryo_name"));
            //    layOrderPrint.SetItemValue(rownum1, "ord_surang", grdOrderList.GetItemString(i, "ord_suryang"));
            //    layOrderPrint.SetItemValue(rownum1, "bogyong_name", grdOrderList.GetItemString(i, "bogyong_name"));
            //    layOrderPrint.SetItemValue(rownum1, "bogyong_code", grdOrderList.GetItemString(i, "bogyong_code"));
            //    //layOrderPrint.SetItemValue(rownum1, "suname", patient_name);
            //    layOrderPrint.SetItemValue(rownum1, "suname2", "");
            //    layOrderPrint.SetItemValue(rownum1, "mayak_address1", paBox.Address1);
            //    layOrderPrint.SetItemValue(rownum1, "mayak_address2", paBox.Address2);
            //    //layOrderPrint.SetItemValue(rownum1, "bunho", paBox.BunHo);

            //    // https://sofiamedix.atlassian.net/browse/MED-15410
            //    XPatientBox paBox = new XPatientBox();
            //    string bunho = grdPaid.GetItemString(grdPaid.CurrentRowNumber, "bunho");
            //    paBox.SetPatientID(bunho);

            //    layOrderPrint.SetItemValue(rownum1, "bunho", paBox.BunHo);
            //    layOrderPrint.SetItemValue(rownum1, "suname", paBox.SuName);
            //    layOrderPrint.SetItemValue(rownum1, "suname2", paBox.SuName2);
            //}

            // https://sofiamedix.atlassian.net/browse/MED-15410
            int rownum1 = 0;
            XPatientBox paBox = new XPatientBox();
            string bunho = grdPaid.GetItemString(grdPaid.CurrentRowNumber, "bunho");
            paBox.SetPatientID(bunho);

            for (int i = 0; i < grdOrderList.RowCount; i++)
            {
                rownum1 = layOrderPrint.InsertRow(-1);

                layOrderPrint.SetItemValue(rownum1, "order_danui", grdOrderList.GetItemString(i, "order_danui"));
                layOrderPrint.SetItemValue(rownum1, "jaeryo_name", grdOrderList.GetItemString(i, "jaeryo_name"));
                layOrderPrint.SetItemValue(rownum1, "ord_surang", grdOrderList.GetItemString(i, "ord_suryang"));
                layOrderPrint.SetItemValue(rownum1, "bogyong_name", grdOrderList.GetItemString(i, "bogyong_name"));
                layOrderPrint.SetItemValue(rownum1, "bogyong_code", grdOrderList.GetItemString(i, "bogyong_code"));
                layOrderPrint.SetItemValue(rownum1, "nalsu", grdOrderList.GetItemString(i, "nalsu"));
                layOrderPrint.SetItemValue(rownum1, "serial_v", "Rp." + (i + 1).ToString() + grdOrderList.GetItemString(i, "mix_group"));
                layOrderPrint.SetItemValue(rownum1, "mayak_address1", paBox.Address1);
                layOrderPrint.SetItemValue(rownum1, "mayak_address2", paBox.Address2);
                layOrderPrint.SetItemValue(rownum1, "bunho", paBox.BunHo);
                layOrderPrint.SetItemValue(rownum1, "suname", paBox.SuName);
                layOrderPrint.SetItemValue(rownum1, "suname2", paBox.SuName2);
                layOrderPrint.SetItemValue(rownum1, "birth", paBox.Birth);
                layOrderPrint.SetItemValue(rownum1, "sex_age", paBox.Sex);
            }
        }

        private void btnUpdateComment_Click(object sender, EventArgs e)
        {
            //if (rbx3.Checked) return;
            //if (!LockChk()) return;
            if (grdOrder.RowCount == 0) return;

            if (paid.BunHo == "")
            {
                MessageBox.Show(Resources.MessageBox1);
            }

            if (grdPaid.RowCount > 0)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("in_out_gubun", "O");
                openParams.Add("bunho", paid.BunHo);
                openParams.Add("from_date", dtpFromDate.GetDataValue());
                openParams.Add("to_date", dtpToDate.GetDataValue());

                XScreen.OpenScreenWithParam(this, "DRGS", "DRG9040U01", ScreenOpenStyle.PopUpFixed, openParams);
            }
            else
            {
                XMessageBox.Show(Resources.MessageBox2, "Error");
            }
        }

        #region [ATC I/F]

        private void btnATC_Click(object sender, System.EventArgs e)
        {
            bool value = this.procAtcInterface();

            if (value == false)
            {
                throw new Exception();
            }

            //AtcSend();
        }

        private bool procAtcInterface()
        {
            /*ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            BindVarCollection item = new BindVarCollection();
            string pkdrg4010 = "0";

            //１．中間テーブルデータ生成（DRG4010）
            inputList.Clear();
            inputList.Add(EnvironInfo.HospCode); //病院コード
            inputList.Add(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date")); //受付日付
            inputList.Add(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "drg_bunho")); //投薬番号

            //if (rbx1.Checked) inputList.Add("0"); //データ区分
            //if (rbx2.Checked) inputList.Add("2"); //データ区分

            inputList.Add("0"); //データ区分

            inputList.Add("O");//入外区分
            inputList.Add(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"));//患者番号
            inputList.Add(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "fkout1001"));//FKOUT1001*/

            string pkdrg4010 = "0";
            try
            {
                // Connect to Cloud
                string jubsuDate = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date");
                string drgBunho = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "drg_bunho");
                string dataDubun = "0";
                string IoGubun = "O";
                string bunnho = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho");
                string fkout1001 = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "fkout1001");
                string send_yn = "Y";
                DrgsDRG5100P01ProcAtcInterfaceResult procAtcInterfaceResult =
                    procAtcInterface_getDataFromCloud(jubsuDate, drgBunho, dataDubun, IoGubun, bunnho, fkout1001,
                        send_yn);
                if (procAtcInterfaceResult == null)
                {
                    throw new Exception();
                }

                pkdrg4010 = procAtcInterfaceResult.Pkdrg4010;
                string rtnIfsCnt = procAtcInterfaceResult.RtnIfsCnt;

                /*Service.BeginTransaction();

                // IFSテーブル作成リターン値
                int rtnIfsCnt = -1;

                bool value = Service.ExecuteProcedure("PR_IFS_DRG_MASTER_INSERT", inputList, outputList);

                if (value == false || TypeCheck.IsNull(outputList[0]) || outputList[0].ToString().Equals("-1"))
                {
                    throw new Exception(Resources.Exception);
                }
                else
                {
                    pkdrg4010 = outputList[0].ToString();

                    //OCS1003に転送情報Update
                    string QuerySQL = @"UPDATE DRG2010 A
                                           SET A.FKDRG4010    = :f_pkdrg4010
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.JUBSU_DATE   = :f_jubsu_date
                                           AND A.DRG_BUNHO    = :f_drg_bunho
                                           AND A.BUNHO        = :f_bunho";

                    item.Clear();
                    item.Add("f_pkdrg4010", pkdrg4010);
                    item.Add("f_hosp_code", EnvironInfo.HospCode);
                    item.Add("f_jubsu_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    item.Add("f_drg_bunho", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "drg_bunho"));
                    item.Add("f_bunho", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"));
                    //item.Add("f_fkocs1003", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "fkocs1003"));

                    if (!Service.ExecuteNonQuery(QuerySQL, item))
                    {
                        throw new Exception(Resources.Exception2);
                    }

                    //２．I/Fテーブルデータ生成（IFS7010 ~ 7107）
                    rtnIfsCnt = makeIFSTBL("O", pkdrg4010, "Y");
                }
                Service.CommitTransaction();*/

                //３．ATC装置にFILE転送
                if (!string.IsNullOrEmpty(rtnIfsCnt) && Int32.Parse(rtnIfsCnt) > 0)
                {
                    //DRG_PROC_MAIN
                    if (atcTrans(pkdrg4010))
                    {
                        XMessageBox.Show(Resources.XMessageBox6, Resources.XMessageBox7, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                //                Service.RollbackTransaction();
                XMessageBox.Show(ex.Message, Resources.Caption3, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // TODO comment: group in method procAtcInterface
        /*private int makeIFSTBL(string io_gubun, string pkdrg4010, string send_yn)
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
        }*/

        private bool atcTrans(string pkdrg4010)
        {
            if (TypeCheck.IsNull(pkdrg4010))
            {
                throw new Exception(Resources.Exception3);
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            msgText = "97101" + pkdrg4010;
            int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            if (ret == -1)
            {
                throw new Exception(Resources.Exception4 + msgText);
            }
            return true;
        }

        #endregion

        #region [一包化、粉砕変更]

        private void grdPackPowder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grd = (XEditGrid)sender;

            BindVarCollection bindVals = new BindVarCollection();

            string cmdText = "";

            string fkocs = grd.GetItemString(e.RowNumber, "fkocs1003");

            switch (e.ColName)
            {
                case "drg_pack_yn":

                    /*string drg_pack_yn = grd.GetItemString(e.RowNumber, "drg_pack_yn");

                    bindVals.Clear();
                    bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
                    bindVals.Add("f_fkocs1003", fkocs);

                    bindVals.Add("f_drg_pack_yn", drg_pack_yn);

                    cmdText = @"UPDATE DRG2010 A
                           SET A.DRG_PACK_YN = :f_drg_pack_yn
                         WHERE A.HOSP_CODE   = :f_hosp_code
                           AND A.FKOCS1003   = :f_fkocs1003
                       ";

                    if (!Service.ExecuteNonQuery(cmdText, bindVals))
                    {
                        throw new Exception(Service.ErrFullMsg);
                    }*/

                    DrgsDRG5100P01UpdateDrgPackYNInDRG2010Args args = new DrgsDRG5100P01UpdateDrgPackYNInDRG2010Args();
                    args.DrgPackYn = grd.GetItemString(e.RowNumber, "drg_pack_yn");
                    args.Fkocs1003 = fkocs;
                    UpdateResult updateResult =
                        CloudService.Instance.Submit<UpdateResult, DrgsDRG5100P01UpdateDrgPackYNInDRG2010Args>(args);
                    if (updateResult == null || updateResult.Result == false)
                    {
                        throw new Exception(Resources.MSG_UpdateDrgPackYN_error);
                    }
                    break;

                case "powder_yn":

                    /* string powder_yn = grd.GetItemString(e.RowNumber, "powder_yn");

                     bindVals.Clear();
                     bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
                     bindVals.Add("f_fkocs1003", fkocs);

                     bindVals.Add("f_powder_yn", powder_yn);

                     cmdText = @"UPDATE DRG2010 A
                            SET A.POWDER_YN   = :f_powder_yn
                          WHERE A.HOSP_CODE   = :f_hosp_code
                            AND A.FKOCS1003   = :f_fkocs1003
                        ";

                     if (!Service.ExecuteNonQuery(cmdText, bindVals))
                     {
                         throw new Exception(Service.ErrFullMsg);
                     }*/

                    DrgsDRG5100P01UpdatePowderYNArgs drg5100P01UpdatePowderYnArgs = new DrgsDRG5100P01UpdatePowderYNArgs();
                    drg5100P01UpdatePowderYnArgs.PowderYn = grd.GetItemString(e.RowNumber, "powder_yn");
                    drg5100P01UpdatePowderYnArgs.Fkocs1003 = fkocs;
                    UpdateResult UpdatePowderYN =
                        CloudService.Instance.Submit<UpdateResult, DrgsDRG5100P01UpdatePowderYNArgs>(
                            drg5100P01UpdatePowderYnArgs);
                    if (UpdatePowderYN == null || UpdatePowderYN.Result == false)
                    {
                        throw new Exception(Resources.MSG_UpdatePowderYN_error);
                    }

                    break;
            }
        }

        #endregion

        #region Connect cloud

        private IList<object[]> grdPaid_getData(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            string fromDate = dtpFromDate.GetDataValue();
            string toDate = dtpToDate.GetDataValue();
            string gwa = xBuseoCombo.GetDataValue();
            string bunho = paBox.BunHo;

            DrgsDRG5100P01GridPaidListArgs gridPaidListArgs = new DrgsDRG5100P01GridPaidListArgs();
            gridPaidListArgs.FromDate = fromDate;
            gridPaidListArgs.ToDate = toDate;
            gridPaidListArgs.Gwa = gwa;
            string gubun = string.Empty;
            if (rbx1.Checked) gubun = "1";
            if (rbx2.Checked) gubun = "2";
            if (rbx3.Checked) gubun = "3";
            gridPaidListArgs.Gubun = gubun;
            gridPaidListArgs.WonyoiYn = (gubun == "3" ? "Y" : "N");
            gridPaidListArgs.Bunho = bunho;
            if (xrbOrder.Checked)
            {
                gridPaidListArgs.XrbOrderValue = true;
            }
            else
            {
                gridPaidListArgs.XrbOrderValue = false;
            }
            DrgsDRG5100P01GridPaidListResult gridPaidListResult =
                CloudService.Instance.Submit<DrgsDRG5100P01GridPaidListResult, DrgsDRG5100P01GridPaidListArgs>(
                    gridPaidListArgs);
            if (gridPaidListResult != null)
            {
                List<DrgsDRG5100P01GridPaidListItemInfo> listItemInfos = gridPaidListResult.PaidOrderList;
                if (listItemInfos != null && listItemInfos.Count > 0)
                {
                    foreach (DrgsDRG5100P01GridPaidListItemInfo itemInfo in listItemInfos)
                    {
                        lstObject.Add(new object[]
                        {
                            itemInfo.TrialYn,
                            itemInfo.Bunho,
                            itemInfo.OrderDate,
                            itemInfo.DrgBunho,
                            itemInfo.Suname,
                            itemInfo.BoryuYn,
                            itemInfo.OrderRemark,
                            itemInfo.DrgRemark
                        });
                    }
                }
            }
            return lstObject;
        }

        private IList<object[]> grdOrder_getData(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            DrgsDRG5100P01OrderOrderListArgs orderOrderListArgs = new DrgsDRG5100P01OrderOrderListArgs();
            string gubun = string.Empty;
            if (rbx1.Checked) gubun = "1";
            if (rbx2.Checked) gubun = "2";
            if (rbx3.Checked) gubun = "3";
            orderOrderListArgs.Gubun = gubun;
            orderOrderListArgs.DrgBunho = grdPaid.GetItemString(grdPaid.CurrentRowNumber, "drg_bunho");
            orderOrderListArgs.OrderDate = grdPaid.GetItemString(grdPaid.CurrentRowNumber, "order_date");

            DrgsDRG5100P01OrderOrderListResult orderListResult =
                CloudService.Instance.Submit<DrgsDRG5100P01OrderOrderListResult, DrgsDRG5100P01OrderOrderListArgs>(
                    orderOrderListArgs);
            if (orderListResult != null)
            {
                List<DrgsDRG5100P01OrderOrderListItemInfo> listItemInfos = orderListResult.OrderOrderList;
                if (listItemInfos != null && listItemInfos.Count > 0)
                {
                    foreach (DrgsDRG5100P01OrderOrderListItemInfo itemInfo in listItemInfos)
                    {
                        lstObject.Add(new object[]
                        {
                            itemInfo.DrgBunho,
                            itemInfo.Bunho,
                            itemInfo.OrderDate,
                            itemInfo.JubsuDate,
                            itemInfo.DrgJubsuDate,
                            itemInfo.JubsuTime,
                            itemInfo.Doctor,
                            itemInfo.DoctorName,
                            itemInfo.Gwa,
                            itemInfo.BuseoName,
                            itemInfo.ActDate,
                            itemInfo.ActYn,
                            itemInfo.SunabDate,
                            itemInfo.ChulgoDate,
                            itemInfo.BoryuYn,
                            itemInfo.ChulgoBuseo,
                            itemInfo.OrderRemark,
                            itemInfo.DrgRemark,
                            itemInfo.WonyoiOrderYn,
                            itemInfo.Fkout1001,
                            itemInfo.Fkocs1003,
                            itemInfo.NaewonYn,
                            itemInfo.IfDataSendYn
                        });
                    }
                }
            }
            return lstObject;
        }

        private IList<object[]> layConstantInfo_getData(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            DrgsDRG5100P01ConstantInfoArgs p01ConstantInfoArgs = new DrgsDRG5100P01ConstantInfoArgs();
            p01ConstantInfoArgs.CodeType = "DRG_CONSTANT";
            DrgsDRG5100P01ConstantInfoResult drg5100P01ConstantInfoResult =
                CacheService.Instance.Get<DrgsDRG5100P01ConstantInfoArgs, DrgsDRG5100P01ConstantInfoResult>(p01ConstantInfoArgs);
            if (drg5100P01ConstantInfoResult != null)
            {
                List<DrgsDRG5100P01ConstantInfo> lstDrg5100P01ConstantInfos =
                    drg5100P01ConstantInfoResult.ConstantInfoList;
                if (lstDrg5100P01ConstantInfos != null && lstDrg5100P01ConstantInfos.Count > 0)
                {
                    foreach (DrgsDRG5100P01ConstantInfo info in lstDrg5100P01ConstantInfos)
                    {
                        lstObject.Add(new object[]
                        {
                            info.Code,
                            info.CodeName,
                            info.CodeValue
                        });
                    }
                }
            }
            return lstObject;
        }

        private DrgsDRG5100P01ProcAtcInterfaceResult procAtcInterface_getDataFromCloud(string aJubsuDate,
            string aDrgBunho, string aDataDubun, string aIoGubun, string aBunho, string aFkout1001, string aSendYn)
        {
            DrgsDRG5100P01ProcAtcInterfaceArgs procAtcInterfaceArgs = new DrgsDRG5100P01ProcAtcInterfaceArgs();
            procAtcInterfaceArgs.JubsuDate = aJubsuDate;
            procAtcInterfaceArgs.DrgBunho = aDrgBunho;
            procAtcInterfaceArgs.DataDubun = aDataDubun;
            procAtcInterfaceArgs.IoGubun = aIoGubun;
            procAtcInterfaceArgs.Bunho = aBunho;
            procAtcInterfaceArgs.Fkout1001 = aFkout1001;
            procAtcInterfaceArgs.SendYn = aSendYn;

            return
                CloudService.Instance.Submit<DrgsDRG5100P01ProcAtcInterfaceResult, DrgsDRG5100P01ProcAtcInterfaceArgs>(
                    procAtcInterfaceArgs);
        }

        private DrgsDRG5100P01DsvOrderJungboResult dsvOrderJungbo_getData(string aJubsuDate, string aDrgBunho)
        {

            DrgsDRG5100P01DsvOrderJungboArgs drg5100P01DsvOrderJungboArgs = new DrgsDRG5100P01DsvOrderJungboArgs();
            drg5100P01DsvOrderJungboArgs.JubsuDate = aJubsuDate;
            drg5100P01DsvOrderJungboArgs.DrgBunho = aDrgBunho;

            return
                CloudService.Instance.Submit<DrgsDRG5100P01DsvOrderJungboResult, DrgsDRG5100P01DsvOrderJungboArgs>(
                    drg5100P01DsvOrderJungboArgs);
        }

        private IList<object[]> grdOrderList_getData(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            DrgsDRG5100P01OrderListArgs drg5100P01OrderListArgs = new DrgsDRG5100P01OrderListArgs();
            drg5100P01OrderListArgs.DrgBunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho");
            drg5100P01OrderListArgs.OrderDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
            drg5100P01OrderListArgs.WonyoiYn = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "wonyoi_yn");
            drg5100P01OrderListArgs.Bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho");
            string gubun = string.Empty;
            if (rbx1.Checked) gubun = "1";
            if (rbx2.Checked) gubun = "2";
            if (rbx3.Checked) gubun = "3";
            drg5100P01OrderListArgs.Gubun = gubun;

            DrgsDRG5100P01OrderListResult drg5100P01OrderListResult =
                CloudService.Instance.Submit<DrgsDRG5100P01OrderListResult, DrgsDRG5100P01OrderListArgs>(
                    drg5100P01OrderListArgs);
            if (drg5100P01OrderListResult != null)
            {
                List<DrgsDRG5100P01OrderListItemInfo> lstDrg5100P01OrderListItemInfos =
                    drg5100P01OrderListResult.OrderList;
                if (lstDrg5100P01OrderListItemInfos != null && lstDrg5100P01OrderListItemInfos.Count > 0)
                {
                    foreach (DrgsDRG5100P01OrderListItemInfo itemInfo in lstDrg5100P01OrderListItemInfos)
                    {
                        lstObject.Add(new object[]
                        {
                            itemInfo.Bunho,
                            itemInfo.DrgBunho,
                            itemInfo.NaewonDate,
                            itemInfo.GroupSer,
                            itemInfo.JubsuDate,
                            itemInfo.OrderDate,
                            itemInfo.JaeryoCode,
                            itemInfo.Nalsu,
                            itemInfo.Divide,
                            itemInfo.OrdSuryang,
                            itemInfo.OrderSuryang,
                            itemInfo.OrderDanui,
                            itemInfo.SubulDanui,
                            itemInfo.GroupYn,
                            itemInfo.JaeryoGubun,
                            itemInfo.BogyongCode,
                            itemInfo.BogyongName,
                            itemInfo.CautionName,
                            itemInfo.CautionCode,
                            itemInfo.MixYn,
                            itemInfo.AtcYn,
                            itemInfo.Dv,
                            itemInfo.DvTime,
                            itemInfo.DcYn,
                            itemInfo.BannabYn,
                            itemInfo.SourceFkocs1003,
                            itemInfo.Fkocs1003,
                            itemInfo.Fkout1001,
                            itemInfo.SunabDate,
                            itemInfo.Pattern,
                            itemInfo.JaeryoName,
                            itemInfo.GenericName,
                            itemInfo.SunabNalsu,
                            itemInfo.WonyoiYn,
                            itemInfo.Remark,
                            itemInfo.ActDate,
                            itemInfo.Mayak,
                            itemInfo.TpnJojeGubun,
                            itemInfo.UiJusaYn,
                            itemInfo.SubulSuryang,
                            itemInfo.SerialV,
                            itemInfo.PowderYn,
                            itemInfo.GyunbonYn,
                            itemInfo.PrintYn,
                            itemInfo.OldGyunbonYn,
                            itemInfo.OrderRemark,
                            itemInfo.DrgRemark,
                            itemInfo.HubakChangeYn,
                            itemInfo.Pharmacy,
                            itemInfo.DrgPackYn,
                            itemInfo.MixGroup,
                            itemInfo.HopeDate,
                            itemInfo.OrderGubun,
                            itemInfo.Bunryu1
                        });
                    }
                }
            }
            grdOrderList_count = lstObject.Count;
            return lstObject;
            
        }

        private Hashtable createHashtableFkocs1003(int prtRp)
        {
            Hashtable hashtable = new Hashtable();
            List<DrgsDRG5100P01LayBongtuInfo> lstBongtuInfos = layBongtu_getData(prtRp);
            if (lstBongtuInfos != null && lstBongtuInfos.Count > 0)
            {
                foreach (DrgsDRG5100P01LayBongtuInfo bongtuInfo in lstBongtuInfos)
                {
                    hashtable.Add("fkocs1003", bongtuInfo);
                }
            }
            return hashtable;
        }

        private List<DrgsDRG5100P01LayBongtuInfo> layBongtu_getData(int prtRp)
        {
            //            IList<object[]> listObject = new List<object[]>();
            // Create param
            List<DrgsDRG5100P01OrderListItemInfo> lstDrg5100P01Order = new List<DrgsDRG5100P01OrderListItemInfo>();
            for (int i = 0; i < grdOrderList.RowCount; i++)
            {
                if (i == prtRp)
                {
                    DrgsDRG5100P01OrderListItemInfo itemInfo = new DrgsDRG5100P01OrderListItemInfo();
                    itemInfo.JubsuDate = grdOrderList.GetItemString(i, "jubsu_date");
                    itemInfo.ActDate = grdOrderList.GetItemString(i, "act_date");
                    itemInfo.BogyongCode = grdOrderList.GetItemString(i, "bogyong_code");
                    itemInfo.Fkocs1003 = grdOrderList.GetItemString(i, "fkocs1003");
                    lstDrg5100P01Order.Add(itemInfo);
                }
            }
            if (lstDrg5100P01Order.Count < 0)
            {
                return null;
            }
            // Connect cloud
            DrgsDRG5100P01LayBongtuArgs drg5100P01LayBongtuArgs = new DrgsDRG5100P01LayBongtuArgs();
            drg5100P01LayBongtuArgs.GridOrderItem = lstDrg5100P01Order;
            DrgsDRG5100P01LayBongtuResult drg5100P01LayBongtuResult =
                CloudService.Instance.Submit<DrgsDRG5100P01LayBongtuResult, DrgsDRG5100P01LayBongtuArgs>(
                    drg5100P01LayBongtuArgs);
            if (drg5100P01LayBongtuResult == null || drg5100P01LayBongtuResult.ExecutionStatus != ExecutionStatus.Success)
            {
                return null;
                //                List<DrgsDRG5100P01LayBongtuInfo> layBongtuInfos = drg5100P01LayBongtuResult.LayBongtuItem;
                //                if (layBongtuInfos != null && layBongtuInfos.Count > 0)
                //                {
                //                    foreach (DrgsDRG5100P01LayBongtuInfo bongtuInfo in layBongtuInfos)
                //                    {
                //                        listObject.Add(new object[]
                //                        {
                //                            bongtuInfo.Fkocs1003,
                //                            bongtuInfo.JubsuDateWareki,
                //                            bongtuInfo.ActDateWareki,
                //                            bongtuInfo.DonbokYn,
                //                            bongtuInfo.Pattern
                //                        });
                //                    }
                //                }
            }

            return drg5100P01LayBongtuResult.LayBongtuItem; ;
        }

        private IList<object[]> cboTime_getData(BindVarCollection varCollection)
        {
            IList<object[]> lstData = new List<object[]>();
            NuroComboTimeArgs args = new NuroComboTimeArgs();
            args.CodeType = "NUR2001U04_TIMER";
            ComboListItemResult comboListItemResult =
                CacheService.Instance.Get<NuroComboTimeArgs, ComboListItemResult>(args);
            if (comboListItemResult != null)
            {
                List<ComboListItemInfo> lstComboDept = comboListItemResult.ListItemInfos;
                if (lstComboDept != null && lstComboDept.Count > 0)
                {
                    foreach (ComboListItemInfo comboListItemInfo in lstComboDept)
                    {
                        object[] obj = { comboListItemInfo.Code, comboListItemInfo.CodeName };
                        lstData.Add(obj);
                    }
                }
            }

            return lstData;
        }

        private IList<object[]> layNebokLabel_getData(BindVarCollection collection)
        {
            IList<object[]> lstResult = new List<object[]>();
            DrgsDRG5100P01NebokLabelListArgs checkJubsuArgs = new DrgsDRG5100P01NebokLabelListArgs();
            checkJubsuArgs.Bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho");
            checkJubsuArgs.DrgBunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho");
            checkJubsuArgs.JubsuDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jubsu_date");
            DrgsDRG5100P01NebokLabelListResult drg5100P01NebokLabelListResult =
                CloudService.Instance.Submit<DrgsDRG5100P01NebokLabelListResult, DrgsDRG5100P01NebokLabelListArgs>(
                    checkJubsuArgs);
            if (drg5100P01NebokLabelListResult == null)
            {
                return lstResult;
            }
            List<DrgsDRG5100P01NebokLabelListItemInfo> lstNebokLabelListItemInfos =
                drg5100P01NebokLabelListResult.NebokLabelList;
            if (lstNebokLabelListItemInfos != null && lstNebokLabelListItemInfos.Count > 0)
            {
                foreach (DrgsDRG5100P01NebokLabelListItemInfo itemInfo in lstNebokLabelListItemInfos)
                {
                    lstResult.Add(new object[]
                    {
                        itemInfo.Bunho,
                        itemInfo.GwaName,
                        itemInfo.DoctorName,
                        itemInfo.Suname,
                        itemInfo.Suname2,
                        itemInfo.Age,
                        itemInfo.Sex,
                        itemInfo.Birth,
                        itemInfo.DrgBunho,
                        itemInfo.RpBunho,
                        itemInfo.ReserDate,
                        itemInfo.JusaGubun,
                        itemInfo.JusaSpdGubun,
                        itemInfo.Suryang,
                        itemInfo.OrdDanui,
                        itemInfo.DvTime,
                        itemInfo.Dv,
                        itemInfo.BogyongCode,
                        itemInfo.SubulSuryang,
                        itemInfo.SubulDanui,
                        itemInfo.JaeryoName,
                        itemInfo.NalsuCnt
                    });
                }
            }
            return lstResult;
        }

        private IList<object[]> layPrintName_getData(BindVarCollection varCollection)
        {
            List<object[]> listObject = new List<object[]>();
            DrgsDRG5100P01PrintNameArgs args = new DrgsDRG5100P01PrintNameArgs();
            args.IpAddr = NetInfo.ClientIP;
            DrgsDRG5100P01PrintNameResult drg5100P01PrintNameResult =
                CloudService.Instance.Submit<DrgsDRG5100P01PrintNameResult, DrgsDRG5100P01PrintNameArgs>(args);
            if (drg5100P01PrintNameResult != null)
            {
                List<DrgsDRG5100P01PrintNameInfo> lstDrg5100P01PrintNameInfo = drg5100P01PrintNameResult.PrintNameList;
                if (lstDrg5100P01PrintNameInfo != null && lstDrg5100P01PrintNameInfo.Count > 0)
                {
                    foreach (DrgsDRG5100P01PrintNameInfo info in lstDrg5100P01PrintNameInfo)
                    {
                        listObject.Add(new object[]
                        {
                            info.BPrintName
                        });
                    }
                }
            }
            return listObject;
        }

        private DrgsDRG5100P01DsvOrderPrintResult orderPrint_getData(string aGobun, string aJubsuDate, string aDrgBunho)
        {
            DrgsDRG5100P01DsvOrderPrintArgs drg5100P01DsvOrderPrintArgs = new DrgsDRG5100P01DsvOrderPrintArgs();
            drg5100P01DsvOrderPrintArgs.IoGobun = aGobun;
            drg5100P01DsvOrderPrintArgs.JubsuDate = aJubsuDate;
            drg5100P01DsvOrderPrintArgs.DrgBunho = aDrgBunho;
            return
                CloudService.Instance.Submit<DrgsDRG5100P01DsvOrderPrintResult, DrgsDRG5100P01DsvOrderPrintArgs>(
                    drg5100P01DsvOrderPrintArgs);
        }

        private bool CheckAct()
        {
            DRG5100P01CheckActArgs args = new DRG5100P01CheckActArgs();
            DRG5100P01CheckActResult result = CloudService.Instance.Submit<DRG5100P01CheckActResult, DRG5100P01CheckActArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.Code == "Y")
                    return true;
            }
            return false;
        }
        #endregion

        private void grdPaid_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            //Trial patient
            if (e.DataRow["trial_yn"].ToString() == "Y")
            {
                grdPaid[e.RowNumber + 1, 2].ToolTipText = Resources.SMS_TRIAL;
            }
            if (e.DataRow["trial_yn"].ToString() == "N")
            {
                grdPaid[e.RowNumber + 1, 2].ToolTipText = " ";
            }
        }

        private void GetDataScreenOpen()
        {
            OpenScreenDRG5100P01CompositeArgs compositeArg = new OpenScreenDRG5100P01CompositeArgs();
            //========
            DRG5100P01CheckActArgs checkActArgs = new DRG5100P01CheckActArgs();
            compositeArg.CheckAct.Add(checkActArgs);
            //========
            FormEnvironInfoSysDateArgs sysDateArgs = new FormEnvironInfoSysDateArgs();
            compositeArg.SysDate.Add(sysDateArgs);
            //========
            DrgsDRG5100P01GridPaidListArgs paidListArgs = new DrgsDRG5100P01GridPaidListArgs();
            string fromDate = dtpFromDate.GetDataValue();
            string toDate = dtpToDate.GetDataValue();
            string gwa = xBuseoCombo.GetDataValue();
            string bunho = paBox.BunHo;
            paidListArgs.FromDate = fromDate;
            paidListArgs.ToDate = toDate;
            paidListArgs.Gwa = gwa;
            string gubun = string.Empty;
            if (rbx1.Checked) gubun = "1";
            if (rbx2.Checked) gubun = "2";
            if (rbx3.Checked) gubun = "3";
            paidListArgs.Gubun = gubun;
            paidListArgs.WonyoiYn = (gubun == "3" ? "Y" : "N");
            paidListArgs.Bunho = bunho;
            if (xrbOrder.Checked)
            {
                paidListArgs.XrbOrderValue = true;
            }
            else
            {
                paidListArgs.XrbOrderValue = false;
            }
            compositeArg.PaidList.Add(paidListArgs);
            //=======

            GetPatientByCodeArgs patientByCodeArgs = new GetPatientByCodeArgs();
            patientByCodeArgs.PatientCode = bunho;
            compositeArg.PatientBycode.Add(patientByCodeArgs);
            //=======
            OpenScreenDRG5100P01CompositeResult compositeResult = CloudService.Instance.Submit<OpenScreenDRG5100P01CompositeResult, OpenScreenDRG5100P01CompositeArgs>(compositeArg, true, CallbackP01Composite);
        
        }
        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackP01Composite(OpenScreenDRG5100P01CompositeArgs args, OpenScreenDRG5100P01CompositeResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();
            for (int i = 0; i < result.CheckAct.Count; i++)
            {
                cacheOne.Add(args.CheckAct[i], new KeyValuePair<int, object>(1, result.CheckAct[i]));
            }
            for (int i = 0; i < result.SysDate.Count; i++)
            {
                cacheOne.Add(args.SysDate[i], new KeyValuePair<int, object>(2, result.SysDate[i]));
            }
            for (int i = 0; i < result.PaidList.Count; i++)
            {
                cacheOne.Add(args.PaidList[i], new KeyValuePair<int, object>(1, result.PaidList[i]));
            }
            for (int i = 0; i < result.PatientBycode.Count; i++)
            {
                cacheOne.Add(args.PatientBycode[i], new KeyValuePair<int, object>(1, result.PatientBycode[i]));
            }

            cacheData.Add(CachePolicy.ONCE, cacheOne);

            return cacheData;
        }

        #region https://sofiamedix.atlassian.net/browse/MED-15410

        private void PrintHtmlTemplate()
        {
            string jsData = "";
            FormDrugPrescription.HospitalType hospType;

            // In-hospital
            if (rbx1.Checked || rbx2.Checked)
            {
                hospType = FormDrugPrescription.HospitalType.InHospital;
                jsData = (NetInfo.Language == LangMode.Jr) ? Helpers.SerializeObject(this.GetInHospitalData()) : Helpers.SerializeObject(this.GetViHospitalData("N"));
            }
            else
            {
                // Out-hospital
                hospType = FormDrugPrescription.HospitalType.OutHospital;
                jsData = (NetInfo.Language == LangMode.Jr) ? Helpers.SerializeObject(this.GetOutHospitalData()) : Helpers.SerializeObject(this.GetViHospitalData("Y"));
            }

            // Save content html
            string url = this.SaveContentHtml();

            // Navigates to print form
            //https://sofiamedix.atlassian.net/browse/MED-15577
            string bunho = layOrderPrint.GetItemString(0, "bunho");
            string fkout_1001 = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "fkout1001");
            FormDrugPrescription frm = new FormDrugPrescription(url, jsData, hospType, this, bunho, fkout_1001);//Hospital_Prescription_VN.html
            frm.Show(this);
        }

        /// <summary>
        /// Splits a string without delimiter. And return a specify letter.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetLetterInStrByIdx(string str, int index)
        {
            string letter = string.Empty;

            if (TypeCheck.IsNull(str))
            {
                return letter;
            }

            char[] letters = str.ToCharArray();

            try
            {
                letter = letters[index].ToString();
            }
            catch
            {
                letter = string.Empty;
            }
            finally { }

            return letter;
        }

        /// <summary>
        /// Data for in-hospital template
        /// </summary>
        /// <returns></returns>
        public DrugPrescriptionIn GetInHospitalData()
        {
            DrugPrescriptionIn data = new DrugPrescriptionIn();
            string budamjaBunho1 = layOrderPrint.GetItemString(0, "budamja_bunho1");
            string sugubjaBunho1 = layOrderPrint.GetItemString(0, "sugubja_bunho1");
            string budamjaBunho2 = layOrderPrint.GetItemString(0, "budamja_bunho2");
            string sugubjaBunho2 = layOrderPrint.GetItemString(0, "sugubja_bunho2");
            string johap = layOrderPrint.GetItemString(0, "johap");

            data.Address = this._address1;
            data.Address1 = this.hosp_address1;
            data.Birth = layOrderPrint.GetItemString(0, "birth");
            data.BoninGubunOval = layOrderPrint.GetItemString(0, "bonin_gubun");
            data.BudamjaBunho11 = this.GetLetterInStrByIdx(budamjaBunho1, 0);
            data.BudamjaBunho12 = this.GetLetterInStrByIdx(budamjaBunho1, 1);
            data.BudamjaBunho13 = this.GetLetterInStrByIdx(budamjaBunho1, 2);
            data.BudamjaBunho14 = this.GetLetterInStrByIdx(budamjaBunho1, 3);
            data.BudamjaBunho15 = this.GetLetterInStrByIdx(budamjaBunho1, 4);
            data.BudamjaBunho16 = this.GetLetterInStrByIdx(budamjaBunho1, 5);
            data.BudamjaBunho17 = this.GetLetterInStrByIdx(budamjaBunho1, 6);
            data.BudamjaBunho18 = this.GetLetterInStrByIdx(budamjaBunho1, 7);
            data.BudamjaBunho21 = this.GetLetterInStrByIdx(budamjaBunho2, 0);
            data.BudamjaBunho22 = this.GetLetterInStrByIdx(budamjaBunho2, 1);
            data.BudamjaBunho23 = this.GetLetterInStrByIdx(budamjaBunho2, 2);
            data.BudamjaBunho24 = this.GetLetterInStrByIdx(budamjaBunho2, 3);
            data.BudamjaBunho25 = this.GetLetterInStrByIdx(budamjaBunho2, 4);
            data.BudamjaBunho26 = this.GetLetterInStrByIdx(budamjaBunho2, 5);
            data.BudamjaBunho27 = this.GetLetterInStrByIdx(budamjaBunho2, 6);
            data.BudamjaBunho28 = this.GetLetterInStrByIdx(budamjaBunho2, 7);
            data.CautionName = layOrderPrint.GetItemString(0, "caution_name");
            data.DoctorCode = UserInfo.UserID;
            data.DoctorName = layOrderPrint.GetItemString(0, "doctor_name");
            data.DrugBunho = layOrderPrint.GetItemString(0, "drg_bunho");
            data.ExaminationDate = Utilities.GetDateByLangMode(layOrderPrint.GetItemString(0, "naewon_date"), LangMode.Jr);
            data.Gaein = layOrderPrint.GetItemString(0, "gaein");
            data.GaeinNo = layOrderPrint.GetItemString(0, "gaein_no");
            data.GigamDate = layOrderPrint.GetItemString(0, "gigan_date");
            data.GubunName = layOrderPrint.GetItemString(0, "gubun_name");
            data.GwaName = layOrderPrint.GetItemString(0, "gwa_name");
            data.JeadanName = this.o_jaedan_name;
            data.Johap1 = this.GetLetterInStrByIdx(johap, 0);
            data.Johap2 = this.GetLetterInStrByIdx(johap, 1);
            data.Johap3 = this.GetLetterInStrByIdx(johap, 2);
            data.Johap4 = this.GetLetterInStrByIdx(johap, 3);
            data.Johap5 = this.GetLetterInStrByIdx(johap, 4);
            data.Johap6 = this.GetLetterInStrByIdx(johap, 5);
            data.Johap7 = this.GetLetterInStrByIdx(johap, 6);
            data.Johap8 = this.GetLetterInStrByIdx(johap, 7);
            data.MayakAddress1 = layOrderPrint.GetItemString(0, "mayak_address1");
            data.MayakAddress2 = layOrderPrint.GetItemString(0, "mayak_address2");
            data.MayakDoctor = layOrderPrint.GetItemString(0, "mayak_doctor");
            data.NameKana = layOrderPrint.GetItemString(0, "suname2");
            data.NameKanji = layOrderPrint.GetItemString(0, "suname") + ((NetInfo.Language == LangMode.Jr) ? "  様" : "");
            data.PageNumber = "1"; // TODO
            data.PageTotal = "1"; // TODO
            data.PatientCode = layOrderPrint.GetItemString(0, "bunho");
            data.PresDetail = this.GetListDrugDetailIn("N");
            data.Sex = layOrderPrint.GetItemString(0, "sex_age");
            data.SugubjaBunho11 = this.GetLetterInStrByIdx(sugubjaBunho1, 0);
            data.SugubjaBunho12 = this.GetLetterInStrByIdx(sugubjaBunho1, 1);
            data.SugubjaBunho13 = this.GetLetterInStrByIdx(sugubjaBunho1, 2);
            data.SugubjaBunho14 = this.GetLetterInStrByIdx(sugubjaBunho1, 3);
            data.SugubjaBunho15 = this.GetLetterInStrByIdx(sugubjaBunho1, 4);
            data.SugubjaBunho16 = this.GetLetterInStrByIdx(sugubjaBunho1, 5);
            data.SugubjaBunho17 = this.GetLetterInStrByIdx(sugubjaBunho1, 6);
            data.SugubjaBunho21 = this.GetLetterInStrByIdx(sugubjaBunho2, 0);
            data.SugubjaBunho22 = this.GetLetterInStrByIdx(sugubjaBunho2, 1);
            data.SugubjaBunho23 = this.GetLetterInStrByIdx(sugubjaBunho2, 2);
            data.SugubjaBunho24 = this.GetLetterInStrByIdx(sugubjaBunho2, 3);
            data.SugubjaBunho25 = this.GetLetterInStrByIdx(sugubjaBunho2, 4);
            data.SugubjaBunho26 = this.GetLetterInStrByIdx(sugubjaBunho2, 5);
            data.SugubjaBunho27 = this.GetLetterInStrByIdx(sugubjaBunho2, 6);
            data.SunwonGubunOval = layOrderPrint.GetItemString(0, "sunwon_gubun");
            data.Tel = this._tel;
            data.YoyangName = this.o_hosp_name;

            return data;
        }

        /// <summary>
        /// Data for in-hospital template
        /// </summary>
        /// <returns></returns>
        private DrugPrescriptionOut GetOutHospitalData()
        {
            DrugPrescriptionOut data = new DrugPrescriptionOut();
            string budamjaBunho1 = layOrderPrint.GetItemString(0, "budamja_bunho1");
            string sugubjaBunho1 = layOrderPrint.GetItemString(0, "sugubja_bunho1");
            string budamjaBunho2 = layOrderPrint.GetItemString(0, "budamja_bunho2");
            string sugubjaBunho2 = layOrderPrint.GetItemString(0, "sugubja_bunho2");
            string johap = layOrderPrint.GetItemString(0, "johap");

            data.Address = this._address1;
            data.Address1 = this.hosp_address1;
            data.Birth = layOrderPrint.GetItemString(0, "birth");
            data.BoninGubunOval = layOrderPrint.GetItemString(0, "bonin_gubun");
            data.BudamjaBunho11 = this.GetLetterInStrByIdx(budamjaBunho1, 0);
            data.BudamjaBunho12 = this.GetLetterInStrByIdx(budamjaBunho1, 1);
            data.BudamjaBunho13 = this.GetLetterInStrByIdx(budamjaBunho1, 2);
            data.BudamjaBunho14 = this.GetLetterInStrByIdx(budamjaBunho1, 3);
            data.BudamjaBunho15 = this.GetLetterInStrByIdx(budamjaBunho1, 4);
            data.BudamjaBunho16 = this.GetLetterInStrByIdx(budamjaBunho1, 5);
            data.BudamjaBunho17 = this.GetLetterInStrByIdx(budamjaBunho1, 6);
            data.BudamjaBunho18 = this.GetLetterInStrByIdx(budamjaBunho1, 7);
            data.BudamjaBunho21 = this.GetLetterInStrByIdx(budamjaBunho2, 0);
            data.BudamjaBunho22 = this.GetLetterInStrByIdx(budamjaBunho2, 1);
            data.BudamjaBunho23 = this.GetLetterInStrByIdx(budamjaBunho2, 2);
            data.BudamjaBunho24 = this.GetLetterInStrByIdx(budamjaBunho2, 3);
            data.BudamjaBunho25 = this.GetLetterInStrByIdx(budamjaBunho2, 4);
            data.BudamjaBunho26 = this.GetLetterInStrByIdx(budamjaBunho2, 5);
            data.BudamjaBunho27 = this.GetLetterInStrByIdx(budamjaBunho2, 6);
            data.BudamjaBunho28 = this.GetLetterInStrByIdx(budamjaBunho2, 7);
            data.DoctorName = layOrderPrint.GetItemString(0, "doctor_name");
            data.Gaein = layOrderPrint.GetItemString(0, "gaein");
            data.GaeinNo = layOrderPrint.GetItemString(0, "gaein_no");
            data.JeadanName = this.o_jaedan_name;
            data.Johap1 = this.GetLetterInStrByIdx(johap, 0);
            data.Johap2 = this.GetLetterInStrByIdx(johap, 1);
            data.Johap3 = this.GetLetterInStrByIdx(johap, 2);
            data.Johap4 = this.GetLetterInStrByIdx(johap, 3);
            data.Johap5 = this.GetLetterInStrByIdx(johap, 4);
            data.Johap6 = this.GetLetterInStrByIdx(johap, 5);
            data.Johap7 = this.GetLetterInStrByIdx(johap, 6);
            data.Johap8 = this.GetLetterInStrByIdx(johap, 7);
            data.NameKana = layOrderPrint.GetItemString(0, "suname2");
            data.NameKanji = layOrderPrint.GetItemString(0, "suname") + ((NetInfo.Language == LangMode.Jr) ? "  様" : "");
            //data.PageNumber = "1"; // TODO
            //data.PageTotal = "1"; // TODO
            //data.PresDetail = this.GetListDrugDetailIn("Y");GetListDrugDetailOut
            data.PresDetail = this.GetListDrugDetailOut();
            data.Sex = layOrderPrint.GetItemString(0, "sex_age");
            data.SugubjaBunho11 = this.GetLetterInStrByIdx(sugubjaBunho1, 0);
            data.SugubjaBunho12 = this.GetLetterInStrByIdx(sugubjaBunho1, 1);
            data.SugubjaBunho13 = this.GetLetterInStrByIdx(sugubjaBunho1, 2);
            data.SugubjaBunho14 = this.GetLetterInStrByIdx(sugubjaBunho1, 3);
            data.SugubjaBunho15 = this.GetLetterInStrByIdx(sugubjaBunho1, 4);
            data.SugubjaBunho16 = this.GetLetterInStrByIdx(sugubjaBunho1, 5);
            data.SugubjaBunho17 = this.GetLetterInStrByIdx(sugubjaBunho1, 6);
            data.SugubjaBunho21 = this.GetLetterInStrByIdx(sugubjaBunho2, 0);
            data.SugubjaBunho22 = this.GetLetterInStrByIdx(sugubjaBunho2, 1);
            data.SugubjaBunho23 = this.GetLetterInStrByIdx(sugubjaBunho2, 2);
            data.SugubjaBunho24 = this.GetLetterInStrByIdx(sugubjaBunho2, 3);
            data.SugubjaBunho25 = this.GetLetterInStrByIdx(sugubjaBunho2, 4);
            data.SugubjaBunho26 = this.GetLetterInStrByIdx(sugubjaBunho2, 5);
            data.SugubjaBunho27 = this.GetLetterInStrByIdx(sugubjaBunho2, 6);
            data.Tel = this._tel;
            data.YoyangName = this.o_hosp_name;

            return data;
        }

        private List<DrugPrescriptionDetail> GetListDrugDetailIn(string wonyoiYn)
        {
            List<DrugPrescriptionDetail> lstData = new List<DrugPrescriptionDetail>();
            DataRow[] rows = layOrderPrint.LayoutTable.Select("bunho <> ''", "serial_v, fkocs1003 asc");
            string tempSerialV = null;
            string tempFkocs = null;

            for (int i = 0; i < rows.Length; i++)
            {
                // if (rows[i]["wonyoi_yn"].ToString() != wonyoiYn) continue;

                DrugPrescriptionDetail item = new DrugPrescriptionDetail();
                item.BogyongName = rows[i]["bogyong_name"].ToString();
                item.Nalsu = rows[i]["nalsu"].ToString();
                if (tempSerialV != rows[i]["serial_v"].ToString())
                {
                    item.SerialV = rows[i]["serial_v"].ToString();
                }
                else
                {
                    item.SerialV = null;
                }
                item.DonbokYn = rows[i]["donbok_yn"].ToString();
                item.DataGubun = rows[i]["data_gubun"].ToString();
                item.JaeryoName = rows[i]["jaeryo_name"].ToString();
                item.OrderDanui = rows[i]["order_danui"].ToString();
                item.OrderSuryang = rows[i]["ord_surang"].ToString();

                // End of one data block?
                if ((tempSerialV != null && tempSerialV != rows[i]["serial_v"].ToString()) || i == rows.Length - 1)
                {
                    // Data from previous row
                    if (i > 0)
                    {
                        DrugPrescriptionDetail lastBlockItem = new DrugPrescriptionDetail();
                        lastBlockItem.DataBlockEnd = "Y";
                        lastBlockItem.BogyongName = rows[i - 1]["bogyong_name"].ToString();
                        lastBlockItem.Nalsu = rows[i - 1]["nalsu"].ToString();
                        lastBlockItem.DonbokYn = rows[i - 1]["donbok_yn"].ToString();
                        lstData.Add(lastBlockItem);

                        // End of all data
                        if (i == rows.Length - 1)
                        {
                            break;
                        }
                    }
                }

                // Group same orders
                if (tempFkocs == rows[i]["fkocs1003"].ToString()) continue;

                lstData.Add(item);
                tempSerialV = rows[i]["serial_v"].ToString();
                tempFkocs = rows[i]["fkocs1003"].ToString();
            }

            // Insert page break
            DrugPrescriptionDetail pbItem = new DrugPrescriptionDetail();
            pbItem.DetailEnd = "Y";
            lstData.Add(pbItem);

            lstData.TrimExcess();
            return lstData;
        }

        private List<DrugPrescriptionDetail> GetListDrugDetailOut()
        {
            List<DrugPrescriptionDetail> lstData = new List<DrugPrescriptionDetail>();
            string tempGroupser = null;

            DataRow[] rows = grdOrderList.LayoutTable.Select("", "group_ser asc");
            int serial = 1;

            for (int i = 0; i <= rows.Length; i++)
            {
                DrugPrescriptionDetail item = new DrugPrescriptionDetail();

                // End of one data block?
                if (i == rows.Length || (tempGroupser != null && tempGroupser != rows[i]["group_ser"].ToString()))
                {
                    // Data from previous row
                    if (i > 0)
                    {
                        DrugPrescriptionDetail lastBlockItem = new DrugPrescriptionDetail();
                        lastBlockItem.DataBlockEnd = "Y";
                        lastBlockItem.BogyongName = rows[i - 1]["bogyong_name"].ToString();
                        lastBlockItem.Nalsu = rows[i - 1]["nalsu"].ToString();
                        //lastBlockItem.DonbokYn = rows[i - 1]["donbok_yn"].ToString();
                        item.DonbokYn = "N";
                        lstData.Add(lastBlockItem);

                        // End of all data
                        if (i == rows.Length)
                        {
                            break;
                        }
                    }
                }

                item.BogyongName = rows[i]["bogyong_name"].ToString();
                item.Nalsu = rows[i]["nalsu"].ToString();
                if (tempGroupser != rows[i]["group_ser"].ToString())
                {
                    item.SerialV = "Rp." + serial.ToString() + rows[i]["mix_group"].ToString();
                    serial++;
                }
                else
                {
                    item.SerialV = null;
                }
                //item.DonbokYn = rows[i]["donbok_yn"].ToString();
                //item.DataGubun = rows[i]["data_gubun"].ToString();
                item.DonbokYn = "N";
                item.DataGubun = "A";
                item.JaeryoName = rows[i]["jaeryo_name"].ToString();
                item.OrderDanui = rows[i]["order_danui"].ToString();
                item.OrderSuryang = rows[i]["ord_suryang"].ToString();

                // Group same orders
                //if (tempFkocs == rows[i]["fkocs1003"].ToString()) continue;

                lstData.Add(item);
                tempGroupser = rows[i]["group_ser"].ToString();
            }

            // Insert page break
            DrugPrescriptionDetail pbItem = new DrugPrescriptionDetail();
            pbItem.DetailEnd = "Y";
            lstData.Add(pbItem);

            lstData.TrimExcess();
            return lstData;

            //DataRow[] rows = layOrderPrint.LayoutTable.Select("bunho <> ''", "serial_v, fkocs1003 asc");
            //string tempSerialV = null;
            //string tempFkocs = null;

            //for (int i = 0; i < rows.Length; i++)
            //{
            //    // if (rows[i]["wonyoi_yn"].ToString() != wonyoiYn) continue;

            //    DrugPrescriptionDetail item = new DrugPrescriptionDetail();
            //    item.BogyongName = rows[i]["bogyong_name"].ToString();
            //    item.Nalsu = rows[i]["nalsu"].ToString();
            //    if (tempSerialV != rows[i]["serial_v"].ToString())
            //    {
            //        item.SerialV = rows[i]["serial_v"].ToString();
            //    }
            //    else
            //    {
            //        item.SerialV = null;
            //    }
            //    item.DonbokYn = rows[i]["donbok_yn"].ToString();
            //    item.DataGubun = rows[i]["data_gubun"].ToString();
            //    item.JaeryoName = rows[i]["jaeryo_name"].ToString();
            //    item.OrderDanui = rows[i]["order_danui"].ToString();
            //    item.OrderSuryang = rows[i]["ord_surang"].ToString();

            //    // End of one data block?
            //    if ((tempSerialV != null && tempSerialV != rows[i]["serial_v"].ToString()) || i == rows.Length - 1)
            //    {
            //        // Data from previous row
            //        if (i > 0)
            //        {
            //            DrugPrescriptionDetail lastBlockItem = new DrugPrescriptionDetail();
            //            lastBlockItem.DataBlockEnd = "Y";
            //            lastBlockItem.BogyongName = rows[i - 1]["bogyong_name"].ToString();
            //            lastBlockItem.Nalsu = rows[i - 1]["nalsu"].ToString();
            //            lastBlockItem.DonbokYn = rows[i - 1]["donbok_yn"].ToString();
            //            lstData.Add(lastBlockItem);

            //            // End of all data
            //            if (i == rows.Length - 1)
            //            {
            //                break;
            //            }
            //        }
            //    }

            //    // Group same orders
            //    if (tempFkocs == rows[i]["fkocs1003"].ToString()) continue;

            //    lstData.Add(item);
            //    tempSerialV = rows[i]["serial_v"].ToString();
            //    tempFkocs = rows[i]["fkocs1003"].ToString();
            //}

            //// Insert page break
            //DrugPrescriptionDetail pbItem = new DrugPrescriptionDetail();
            //pbItem.DetailEnd = "Y";
            //lstData.Add(pbItem);

            //lstData.TrimExcess();
            //return lstData;
        }

        /// <summary>
        /// Data for Vi, En hospital
        /// </summary>
        /// <param name="wonyoiYn">N: In-hospital, Y: Out-hospital</param>
        /// <returns></returns>
        private DrugPrescriptionVi GetViHospitalData(string wonyoiYn)
        {
            string mainDisease;
            string extraDisease;
            DateTime currentDt = EnvironInfo.GetSysDate();
            XPatientBox paBox = new XPatientBox();

            this.GetDisease(out mainDisease, out extraDisease);
            paBox.SetPatientID(grdPaid.GetItemString(grdPaid.CurrentRowNumber, "bunho"), UserInfo.HospCode);

            DrugPrescriptionVi data = new DrugPrescriptionVi();
            data.BirthYear = paBox.Birth.Substring(0, 4);
            data.CurrentDate = currentDt.Day.ToString();
            data.CurrentMonth = currentDt.Month.ToString();
            data.CurrentYear = currentDt.Year.ToString();
            data.DoctorName = layOrderPrint.GetItemString(0, "doctor_name");
            data.ExtraDiseas = mainDisease;
            data.Gender = layOrderPrint.GetItemString(0, "sex_age") == "F" ? "Nữ" : "Nam";
            data.HospName = UserInfo.HospName;
            data.Johap = layOrderPrint.GetItemString(0, "johap");
            data.MainDisease = extraDisease;
            data.PatientAddress = paBox.Address1 + paBox.Address2;
            data.PatientName = layOrderPrint.GetItemString(0, "suname2");
            //data.PrescriptionNo = layOrderPrint.GetItemString(0, "bogyong_code");
            data.PrescriptionNo = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "fkout1001");
            data.PresDetail = new List<DrugPrescriptionViDetail>();

            for (int i = 0; i < layOrderPrint.RowCount; i++)
            {
                //if (layOrderPrint.GetItemString(i, "wonyoi_yn") != wonyoiYn) continue;

                DrugPrescriptionViDetail item = new DrugPrescriptionViDetail();
                item.DrugNo = (i + 1).ToString();
                item.BogyongName = layOrderPrint.GetItemString(i, "bogyong_name");
                item.JaeryoName = layOrderPrint.GetItemString(i, "jaeryo_name");
                item.OrderDanui = layOrderPrint.GetItemString(i, "order_danui");
                item.Quantity = layOrderPrint.GetItemString(i, "ord_surang");
                data.PresDetail.Add(item);
            }

            return data;
        }

        private void GetDisease(out string mainDisease, out string extraDisease)
        {
            mainDisease = "";
            extraDisease = "";
            List<string> mainList = new List<string>();
            List<string> extraList = new List<string>();

            DRG5100P01GetDiseaseArgs args = new DRG5100P01GetDiseaseArgs();
            args.Bunho = grdPaid.GetItemString(grdPaid.CurrentRowNumber, "bunho");
            args.Gwa = "01";
            args.HospCode = UserInfo.HospCode;
            args.NaewonDate = this.GetListNaewonDate();
            DRG5100P01GetDiseaseResult res = CloudService.Instance.Submit<DRG5100P01GetDiseaseResult, DRG5100P01GetDiseaseArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.SangItem.ForEach(delegate(DRG5100P01GetDiseaseInfo item)
                {
                    if (item.JusangYn == "Y")
                    {
                        // item.MainDisease is SANG_CODE
                        // item.ExtraDisease is SANG_NAME
                        if (!mainList.Contains(item.ExtraDisease)) mainList.Add(item.ExtraDisease);
                    }
                    else
                    {
                        if (!extraList.Contains(item.ExtraDisease)) extraList.Add(item.ExtraDisease);
                    }
                });
            }

            mainDisease = string.Join(",", mainList.ToArray());
            extraDisease = string.Join(",", extraList.ToArray());
        }

        private List<DataStringListItemInfo> GetListNaewonDate()
        {
            List<DataStringListItemInfo> lstNaewonDt = new List<DataStringListItemInfo>();

            for (int i = 0; i < grdOrderList.RowCount; i++)
            {
                DataStringListItemInfo item = new DataStringListItemInfo();
                item.DataValue = grdOrderList.GetItemString(0, "naewon_date");
                lstNaewonDt.Add(item);
            }

            return lstNaewonDt;
        }

        private string SaveContentHtml()
        {
            string savePath = string.Empty;

            OCS2015U00GetHtmlContentArgs args = new OCS2015U00GetHtmlContentArgs();
            args.FormatType = "HTML";
            args.TplType = "PRESCRIPTION";
            OCS2015U00GetHtmlContentResult res = CloudService.Instance.Submit<OCS2015U00GetHtmlContentResult, OCS2015U00GetHtmlContentArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                savePath = String.Format("file:///{0}/DRGS/{1}_{2}{3}", Application.StartupPath.Replace("\\", @"/"), "DRG5100P01", NetInfo.Language == LangMode.Jr ? "JP" : "VN", ".html");
                Helpers.SaveFileHtml(savePath, res.PrintContent);
            }

            return savePath;
        }

        #endregion
    }
}