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
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.NURO.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Orca;
using IHIS.CloudConnector.Contracts.Results.Orca;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Net.Sockets;
using ORCA;
using IHIS.CloudConnector.Contracts.Arguments.NURO;
using IHIS.CloudConnector.Contracts.Models.NURO;
using IHIS.CloudConnector.Contracts.Results.NURO;
using IHIS.CloudConnector.DataAccess;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;
using IHIS.CloudConnector.DataAccess.AdoNet;
using System.Configuration;
using Newtonsoft.Json;

namespace IHIS.NURO
{
    /// <summary>
    /// ORDERTRANS에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class ORDERTRANS : IHIS.Framework.XScreen
    {
        #region Enum

        /// <summary>
        /// Indicates which types of transfer.
        /// </summary>
        public enum TransferType
        {
            Order,
            Disease,
            Retransfer,
            Cancel
        }

        #endregion

        #region Auto-gen code

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XDatePicker dtpJunsongDate;
        private IHIS.Framework.MultiLayout layOrderInfo;
        private IHIS.Framework.XPanel pnlProgressBar;
        private IHIS.Framework.XProgressBar pgbProgress;
        private System.Windows.Forms.Label lbTransHangmog;
        private System.Windows.Forms.Label lbTransCnt;
        private XDisplayBox dbxSuname;
        private XFindBox fbxBunho;
        private XLabel xLabel3;
        private SingleLayout layOut0101;
        private SingleLayoutItem singleLayoutItem1;
        private ToolTip toolTip1;
        private XPanel pnlGrid;
        private XLabel lbSelectAll;
        private XPanel pnlOrder;
        private XPanel pnlSiksa;
        private XPanel pnlJungwa;
        private XEditGrid grdJungwa;
        private XEditGridCell xEditGridCell106;
        private XEditGridCell xEditGridCell66;
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
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell103;
        private XEditGrid grdSiksa;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell65;
        private XGridHeader xGridHeader2;
        private XEditGrid grdOCS1003;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell102;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell133;
        private XEditGridCell xEditGridCell146;
        private XEditGridCell xEditGridCell147;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell149;
        private XEditGridCell xEditGridCell97;
        private XGridHeader xGridHeader1;
        private XPanel pnlWoichul;
        private XEditGrid grdWoichul;
        private XEditGridCell xEditGridCell120;
        private XEditGridCell xEditGridCell122;
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell124;
        private XEditGridCell xEditGridCell125;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell118;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell127;
        private XGridHeader xGridHeader3;
        private XGridHeader xGridHeader4;
        private XGridHeader xGridHeader5;
        private XFindWorker fwkFind;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private SingleLayout layCommon;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell78;
        private XButton btnCompar;
        private XButton btnSend;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell128;
        private XPanel xPanel5;
        private XPanel xPanel11;
        private XLabel xLabel9;
        private XPanel xPanel9;
        private XPanel pnlInfo;
        private XPanel pnlBunho;
        private XEditGrid grdGongbi;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell74;
        private XEditGrid grdComment;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell58;
        private XTabControl tabDataInfo;
        private XPanel xPanel10;
        private XDisplayBox dbxGwa_name;
        private XLabel xLabel8;
        private XDisplayBox dbxDoctor;
        private XLabel xLabel7;
        private XLabel xLabel6;
        private XLabel xLabel2;
        private XLabel xLabel5;
        private XDisplayBox dbxHoken_Name;
        private XFindBox fbxHoken;
        private XPanel xPanel2;
        private XPanel xPanel6;
        private XEditGrid grdOutList;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell121;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell81;
        private XEditGrid grdInpList;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell130;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell84;
        private XTabControl tabDataGubun;
        private XPanel xPanel4;
        private XRadioButton rbnTrans;
        private XRadioButton rbnMiTrans;
        private XPanel xPanel7;
        private XRadioButton rbnInData;
        private XRadioButton rbnOutData;
        private XComboBox cboSangCode;
        private XPanel pnlSang;
        private XEditGrid grdOutSang;
        private XEditGridCell xEditGridCell131;
        private XEditGridCell xEditGridCell132;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell144;
        private XEditGridCell xEditGridCell145;
        private XEditGridCell xEditGridCell150;
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
        private XEditGridCell xEditGridCell162;
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
        private XGridHeader xGridHeader6;
        private XEditGridCell xEditGridCell181;
        private XEditGridCell xEditGridCell182;
        private XEditGridCell xEditGridCell183;
        private XEditGridCell xEditGridCell184;
        private XEditGridCell xEditGridCell185;
        private XEditGridCell xEditGridCell186;
        private MultiLayout layRequisInfo;
        private XEditGridCell xEditGridCell187;
        private XLabel xLabel4;
        private XEditGridCell xEditGridCell188;
        private XEditGridCell xEditGridCell189;
        private XEditGridCell xEditGridCell191;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell190;
        private XEditGridCell xEditGridCell192;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell193;
        private XEditGridCell xEditGridCell194;
        private XEditGridCell xEditGridCell195;
        private XEditGridCell xEditGridCell196;
        private XEditGridCell xEditGridCell197;
        private XEditGridCell xEditGridCell198;
        private XEditGridCell xEditGridCell199;
        private XEditGridCell xEditGridCell200;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XFindWorker fwkGongbi;
        private FindColumnInfo findColumnInfo5;
        private FindColumnInfo findColumnInfo6;
        private FindColumnInfo findColumnInfo7;
        private XEditGridCell xEditGridCell202;
        private XEditGridCell xEditGridCell201;
        private XEditGridCell xEditGridCell203;
        private XEditGridCell xEditGridCell204;
        private XDatePicker dtpGijunDate;
        private XLabel xLabel10;
        private XEditGridCell xEditGridCell205;
        private XEditGridCell xEditGridCell206;
        private XEditGridCell xEditGridCell207;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private XEditGridCell xEditGridCell208;
        private XTextBox txtGongbi_yn;
        private XEditGridCell xEditGridCell209;
        private XDisplayBox dbxChojae_Name;
        private XDisplayBox dbxSanjung_Name;
        private XPanel pnlHoken;
        private XEditGrid grdHoken;
        private XEditGridCell xEditGridCell210;
        private XEditGridCell xEditGridCell211;
        private XEditGridCell xEditGridCell212;
        private XEditGridCell xEditGridCell213;
        private XEditGridCell xEditGridCell214;
        private XEditGridCell xEditGridCell215;
        private XDisplayBox dbxGongbi_Name1;
        private XLabel xLabel11;
        private XDisplayBox dbxGongbi_Name4;
        private XDisplayBox dbxGongbi_Name3;
        private XDisplayBox dbxGongbi_Name2;
        private XEditGridCell xEditGridCell216;
        private XEditGridCell xEditGridCell217;
        private XEditGridCell xEditGridCell218;
        private XEditGridCell xEditGridCell219;
        private XEditGridCell xEditGridCell220;
        private XEditGridCell xEditGridCell221;
        private XEditGridCell xEditGridCell222;
        private XEditGridCell xEditGridCell223;
        private XButton btnPrint;
        private XEditGridCell xEditGridCell224;
        private XEditGridCell xEditGridCell225;
        private XEditGridCell xEditGridCell226;
        private XEditGridCell xEditGridCell227;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell228;
        private XButton btnSiksaTest;
        private XDatePicker dtpFromdate;
        private XDatePicker dtpTodate;
        private XComboBox cboTosik;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XComboBox cboFromsik;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XComboItem xComboItem7;
        private XComboItem xComboItem8;
        private XLabel lblHlep2;
        private XLabel lblHlep4;
        private XLabel lblHlep5;
        private XLabel lblHlep3;
        private XLabel lblHlep1;
        private XPanel pnlHelp;
        private XButton btnHelp;
        private XEditGrid grdINP2004;
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
        private XEditGridCell xEditGridCell243;
        private XEditGridCell xEditGridCell244;
        private XGridHeader xGridHeader7;
        private XGridHeader xGridHeader8;
        private XEditGridCell xEditGridCell245;
        private XEditGridCell xEditGridCell246;
        private XButton btnForcedEnd;
        private XEditGridCell xEditGridCell248;
        private XEditGridCell xEditGridCell249;
        private XEditGridCell xEditGridCell250;
        private XEditGridCell xEditGridCell251;
        private XButton btnSangSendAll;
        private XEditGridCell xEditGridCell247;
        private XEditGridCell xEditGridCell252;
        private XEditGridCell xEditGridCell253;
        private XEditGridCell xEditGridCell254;
        private XEditGridCell xEditGridCell255;
        private IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ORDERTRANS));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dtpGijunDate = new IHIS.Framework.XDatePicker();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.dtpJunsongDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.fwkFind = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.pnlGrid = new IHIS.Framework.XPanel();
            this.pnlHelp = new IHIS.Framework.XPanel();
            this.lblHlep2 = new IHIS.Framework.XLabel();
            this.lblHlep4 = new IHIS.Framework.XLabel();
            this.lblHlep3 = new IHIS.Framework.XLabel();
            this.lblHlep5 = new IHIS.Framework.XLabel();
            this.lblHlep1 = new IHIS.Framework.XLabel();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.grdOCS1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell249 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell226 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell228 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell251 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell207 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell247 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell252 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell253 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell254 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.grdINP2004 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell229 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell230 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell231 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell232 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell233 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell234 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell235 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell237 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell239 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell241 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell243 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell236 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell238 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell240 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell242 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell244 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell245 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell246 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader7 = new IHIS.Framework.XGridHeader();
            this.xGridHeader8 = new IHIS.Framework.XGridHeader();
            this.pnlWoichul = new IHIS.Framework.XPanel();
            this.grdWoichul = new IHIS.Framework.XEditGrid();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell192 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.xGridHeader4 = new IHIS.Framework.XGridHeader();
            this.xGridHeader5 = new IHIS.Framework.XGridHeader();
            this.pnlSiksa = new IHIS.Framework.XPanel();
            this.grdSiksa = new IHIS.Framework.XEditGrid();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.pnlJungwa = new IHIS.Framework.XPanel();
            this.grdJungwa = new IHIS.Framework.XEditGrid();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.lbSelectAll = new IHIS.Framework.XLabel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.pnlHoken = new IHIS.Framework.XPanel();
            this.grdHoken = new IHIS.Framework.XEditGrid();
            this.xEditGridCell210 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell211 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell212 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell213 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell215 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell214 = new IHIS.Framework.XEditGridCell();
            this.pnlInfo = new IHIS.Framework.XPanel();
            this.pnlBunho = new IHIS.Framework.XPanel();
            this.grdGongbi = new IHIS.Framework.XEditGrid();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell202 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell205 = new IHIS.Framework.XEditGridCell();
            this.grdComment = new IHIS.Framework.XEditGrid();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.tabDataInfo = new IHIS.Framework.XTabControl();
            this.xPanel10 = new IHIS.Framework.XPanel();
            this.btnPrint = new IHIS.Framework.XButton();
            this.dbxGongbi_Name4 = new IHIS.Framework.XDisplayBox();
            this.dbxGongbi_Name3 = new IHIS.Framework.XDisplayBox();
            this.dbxGongbi_Name2 = new IHIS.Framework.XDisplayBox();
            this.dbxGongbi_Name1 = new IHIS.Framework.XDisplayBox();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.dbxSanjung_Name = new IHIS.Framework.XDisplayBox();
            this.dbxChojae_Name = new IHIS.Framework.XDisplayBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.dbxGwa_name = new IHIS.Framework.XDisplayBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.dbxDoctor = new IHIS.Framework.XDisplayBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.dbxHoken_Name = new IHIS.Framework.XDisplayBox();
            this.fbxHoken = new IHIS.Framework.XFindBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.grdOutList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell248 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell250 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell227 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell208 = new IHIS.Framework.XEditGridCell();
            this.txtGongbi_yn = new IHIS.Framework.XTextBox();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell183 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell184 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell189 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell193 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell194 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell195 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell216 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell217 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell218 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell219 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell200 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell204 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell224 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell225 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell255 = new IHIS.Framework.XEditGridCell();
            this.grdInpList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell201 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell209 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell187 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell185 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell186 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell196 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell197 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell198 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell199 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell220 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell221 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell222 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell223 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell191 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell188 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell190 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell203 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell182 = new IHIS.Framework.XEditGridCell();
            this.tabDataGubun = new IHIS.Framework.XTabControl();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.rbnTrans = new IHIS.Framework.XRadioButton();
            this.rbnMiTrans = new IHIS.Framework.XRadioButton();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.rbnInData = new IHIS.Framework.XRadioButton();
            this.rbnOutData = new IHIS.Framework.XRadioButton();
            this.xPanel11 = new IHIS.Framework.XPanel();
            this.btnHelp = new IHIS.Framework.XButton();
            this.pnlSang = new IHIS.Framework.XPanel();
            this.grdOutSang = new IHIS.Framework.XEditGrid();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
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
            this.xGridHeader6 = new IHIS.Framework.XGridHeader();
            this.cboSangCode = new IHIS.Framework.XComboBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.fwkGongbi = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo7 = new IHIS.Framework.FindColumnInfo();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layOrderInfo = new IHIS.Framework.MultiLayout();
            this.pnlProgressBar = new IHIS.Framework.XPanel();
            this.lbTransCnt = new System.Windows.Forms.Label();
            this.lbTransHangmog = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.layOut0101 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCompar = new IHIS.Framework.XButton();
            this.btnSend = new IHIS.Framework.XButton();
            this.btnSiksaTest = new IHIS.Framework.XButton();
            this.dtpFromdate = new IHIS.Framework.XDatePicker();
            this.dtpTodate = new IHIS.Framework.XDatePicker();
            this.cboTosik = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.cboFromsik = new IHIS.Framework.XComboBox();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.btnForcedEnd = new IHIS.Framework.XButton();
            this.btnSangSendAll = new IHIS.Framework.XButton();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.layRequisInfo = new IHIS.Framework.MultiLayout();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell206 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2004)).BeginInit();
            this.pnlWoichul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWoichul)).BeginInit();
            this.pnlSiksa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSiksa)).BeginInit();
            this.pnlJungwa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJungwa)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel9.SuspendLayout();
            this.pnlHoken.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHoken)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.pnlBunho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGongbi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).BeginInit();
            this.xPanel10.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInpList)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel7.SuspendLayout();
            this.xPanel11.SuspendLayout();
            this.pnlSang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutSang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderInfo)).BeginInit();
            this.pnlProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layRequisInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "처방.ico");
            this.ImageList.Images.SetKeyName(4, "식이관리.ico");
            this.ImageList.Images.SetKeyName(5, "닫기.gif");
            this.ImageList.Images.SetKeyName(6, "타과의뢰.ico");
            this.ImageList.Images.SetKeyName(7, "재진예약.gif");
            this.ImageList.Images.SetKeyName(8, "약국정보관리.ico");
            this.ImageList.Images.SetKeyName(9, "WTRS.ico");
            this.ImageList.Images.SetKeyName(10, "공비등록.gif");
            this.ImageList.Images.SetKeyName(11, "특이사항입력.gif");
            this.ImageList.Images.SetKeyName(12, "참조.ico");
            this.ImageList.Images.SetKeyName(13, "재전송.gif");
            this.ImageList.Images.SetKeyName(14, "건진운영관리.ico");
            this.ImageList.Images.SetKeyName(15, "iro.png");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dtpGijunDate);
            this.xPanel1.Controls.Add(this.xLabel10);
            this.xPanel1.Controls.Add(this.dtpJunsongDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.dbxSuname);
            this.xPanel1.Controls.Add(this.fbxBunho);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Name = "xPanel1";
            // 
            // dtpGijunDate
            // 
            resources.ApplyResources(this.dtpGijunDate, "dtpGijunDate");
            this.dtpGijunDate.IsJapanYearType = true;
            this.dtpGijunDate.IsVietnameseYearType = false;
            this.dtpGijunDate.Name = "dtpGijunDate";
            this.dtpGijunDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpGijunDate_DataValidating);
            // 
            // xLabel10
            // 
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.Name = "xLabel10";
            // 
            // dtpJunsongDate
            // 
            resources.ApplyResources(this.dtpJunsongDate, "dtpJunsongDate");
            this.dtpJunsongDate.IsJapanYearType = true;
            this.dtpJunsongDate.IsVietnameseYearType = false;
            this.dtpJunsongDate.Name = "dtpJunsongDate";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Name = "xLabel1";
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            // 
            // fbxBunho
            // 
            resources.ApplyResources(this.fbxBunho, "fbxBunho");
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunho_DataValidating);
            this.fbxBunho.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunho_FindClick);
            // 
            // xLabel3
            // 
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // fwkFind
            // 
            this.fwkFind.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkFind.ExecuteQuery = null;
            this.fwkFind.FormText = "保険種別照会";
            this.fwkFind.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkFind.ParamList")));
            this.fwkFind.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkFind.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "gubun";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "gubun_name";
            this.findColumnInfo2.ColWidth = 150;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.pnlGrid);
            this.xPanel3.Controls.Add(this.xPanel5);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.pnlHelp);
            this.pnlGrid.Controls.Add(this.pnlOrder);
            this.pnlGrid.Controls.Add(this.pnlWoichul);
            this.pnlGrid.Controls.Add(this.pnlSiksa);
            this.pnlGrid.Controls.Add(this.pnlJungwa);
            this.pnlGrid.Controls.Add(this.lbSelectAll);
            resources.ApplyResources(this.pnlGrid, "pnlGrid");
            this.pnlGrid.Name = "pnlGrid";
            // 
            // pnlHelp
            // 
            this.pnlHelp.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.pnlHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHelp.Controls.Add(this.lblHlep2);
            this.pnlHelp.Controls.Add(this.lblHlep4);
            this.pnlHelp.Controls.Add(this.lblHlep3);
            this.pnlHelp.Controls.Add(this.lblHlep5);
            this.pnlHelp.Controls.Add(this.lblHlep1);
            resources.ApplyResources(this.pnlHelp, "pnlHelp");
            this.pnlHelp.Name = "pnlHelp";
            // 
            // lblHlep2
            // 
            this.lblHlep2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.SkyBlue);
            this.lblHlep2.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            resources.ApplyResources(this.lblHlep2, "lblHlep2");
            this.lblHlep2.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Blue);
            this.lblHlep2.Name = "lblHlep2";
            // 
            // lblHlep4
            // 
            this.lblHlep4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.DarkGray);
            this.lblHlep4.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            resources.ApplyResources(this.lblHlep4, "lblHlep4");
            this.lblHlep4.Name = "lblHlep4";
            // 
            // lblHlep3
            // 
            this.lblHlep3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.GreenYellow);
            this.lblHlep3.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            resources.ApplyResources(this.lblHlep3, "lblHlep3");
            this.lblHlep3.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Green);
            this.lblHlep3.Name = "lblHlep3";
            // 
            // lblHlep5
            // 
            this.lblHlep5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Pink);
            this.lblHlep5.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            resources.ApplyResources(this.lblHlep5, "lblHlep5");
            this.lblHlep5.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.lblHlep5.Name = "lblHlep5";
            // 
            // lblHlep1
            // 
            this.lblHlep1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            this.lblHlep1.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            resources.ApplyResources(this.lblHlep1, "lblHlep1");
            this.lblHlep1.Name = "lblHlep1";
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.grdOCS1003);
            this.pnlOrder.Controls.Add(this.grdINP2004);
            resources.ApplyResources(this.pnlOrder, "pnlOrder");
            this.pnlOrder.Name = "pnlOrder";
            // 
            // grdOCS1003
            // 
            this.grdOCS1003.AddedHeaderLine = 1;
            this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell63,
            this.xEditGridCell61,
            this.xEditGridCell19,
            this.xEditGridCell249,
            this.xEditGridCell102,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell134,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell135,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell136,
            this.xEditGridCell28,
            this.xEditGridCell9,
            this.xEditGridCell137,
            this.xEditGridCell29,
            this.xEditGridCell32,
            this.xEditGridCell45,
            this.xEditGridCell30,
            this.xEditGridCell140,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell11,
            this.xEditGridCell31,
            this.xEditGridCell133,
            this.xEditGridCell146,
            this.xEditGridCell147,
            this.xEditGridCell148,
            this.xEditGridCell10,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell149,
            this.xEditGridCell97,
            this.xEditGridCell68,
            this.xEditGridCell226,
            this.xEditGridCell228,
            this.xEditGridCell251,
            this.xEditGridCell207,
            this.xEditGridCell247,
            this.xEditGridCell252,
            this.xEditGridCell253,
            this.xEditGridCell254});
            this.grdOCS1003.ColPerLine = 23;
            this.grdOCS1003.Cols = 24;
            resources.ApplyResources(this.grdOCS1003, "grdOCS1003");
            this.grdOCS1003.ExecuteQuery = null;
            this.grdOCS1003.FixedCols = 1;
            this.grdOCS1003.FixedRows = 2;
            this.grdOCS1003.HeaderHeights.Add(0);
            this.grdOCS1003.HeaderHeights.Add(43);
            this.grdOCS1003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS1003.Name = "grdOCS1003";
            this.grdOCS1003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS1003.ParamList")));
            this.grdOCS1003.ReadOnly = true;
            this.grdOCS1003.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdOCS1003.RowHeaderVisible = true;
            this.grdOCS1003.Rows = 3;
            this.grdOCS1003.RowStateCheckOnPaint = false;
            this.grdOCS1003.ToolTipActive = true;
            this.grdOCS1003.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS1003_GridColumnChanged);
            this.grdOCS1003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1003_QueryEnd);
            this.grdOCS1003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdEdit_MouseDown);
            this.grdOCS1003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1003_RowFocusChanged);
            this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
            this.grdOCS1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grid_QueryStarting);
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "pk1001";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "pkocs";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "group_ser";
            this.xEditGridCell19.CellWidth = 32;
            this.xEditGridCell19.Col = 7;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell249
            // 
            this.xEditGridCell249.CellName = "group_out1001";
            this.xEditGridCell249.Col = -1;
            this.xEditGridCell249.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell249, "xEditGridCell249");
            this.xEditGridCell249.IsVisible = false;
            this.xEditGridCell249.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "order_gubun_name";
            this.xEditGridCell102.CellWidth = 121;
            this.xEditGridCell102.Col = 5;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell102.SuppressRepeating = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.ApplyPaintingEvent = true;
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.CellWidth = 74;
            this.xEditGridCell20.Col = 8;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 74;
            this.xEditGridCell21.Col = 9;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "specimen_code";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsReadOnly = true;
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "specimen_name";
            this.xEditGridCell22.CellWidth = 68;
            this.xEditGridCell22.Col = 18;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "suryang";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell23.CellWidth = 55;
            this.xEditGridCell23.Col = 10;
            this.xEditGridCell23.DecimalDigits = 3;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "ord_danui";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "ord_danui_name";
            this.xEditGridCell24.CellWidth = 56;
            this.xEditGridCell24.Col = 11;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.RowSpan = 2;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "dv_time";
            this.xEditGridCell25.CellWidth = 59;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "dv";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell26.CellWidth = 40;
            this.xEditGridCell26.Col = 13;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "nalsu";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell27.CellWidth = 120;
            this.xEditGridCell27.Col = 14;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "jusa";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsReadOnly = true;
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "jusa_name";
            this.xEditGridCell28.CellWidth = 62;
            this.xEditGridCell28.Col = 15;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.RowSpan = 2;
            this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "jusa_spd_name";
            this.xEditGridCell9.CellWidth = 92;
            this.xEditGridCell9.Col = 17;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "bogyong_code";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsReadOnly = true;
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "bogyong_name";
            this.xEditGridCell29.CellWidth = 82;
            this.xEditGridCell29.Col = 16;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.RowSpan = 2;
            this.xEditGridCell29.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 70;
            this.xEditGridCell32.Col = 20;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jundal_part";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "wonyoi_order_yn";
            this.xEditGridCell30.CellWidth = 66;
            this.xEditGridCell30.Col = 21;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell140.CellWidth = 120;
            this.xEditGridCell140.Col = 19;
            this.xEditGridCell140.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell140.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsReadOnly = true;
            this.xEditGridCell140.IsUpdatable = false;
            this.xEditGridCell140.RowSpan = 2;
            this.xEditGridCell140.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "ocs_flag";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "order_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "bunho";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "order_date";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell48.CellWidth = 102;
            this.xEditGridCell48.Col = 2;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsJapanYearType = true;
            this.xEditGridCell48.RowSpan = 2;
            this.xEditGridCell48.SuppressRepeating = true;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "gwa";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "doctor";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "seq";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "fkocs1003";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "sub_susul";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "acting_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 97;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsJapanYearType = true;
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "hope_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.CellWidth = 101;
            this.xEditGridCell31.Col = 3;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsJapanYearType = true;
            this.xEditGridCell31.RowSpan = 2;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "sunab_date";
            this.xEditGridCell133.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell133.CellWidth = 100;
            this.xEditGridCell133.Col = -1;
            this.xEditGridCell133.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsJapanYearType = true;
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "home_care_yn";
            this.xEditGridCell146.CellWidth = 93;
            this.xEditGridCell146.Col = 22;
            this.xEditGridCell146.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.RowSpan = 2;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "regular_yn";
            this.xEditGridCell147.CellWidth = 145;
            this.xEditGridCell147.Col = 23;
            this.xEditGridCell147.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.RowSpan = 2;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "hubal_change_yn";
            this.xEditGridCell148.Col = 12;
            this.xEditGridCell148.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.Row = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bun_code";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "input_control";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "order_gubun_bas";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "acting_yn";
            this.xEditGridCell149.CellWidth = 33;
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell97.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell97.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.AlterateRowImageIndex = 0;
            this.xEditGridCell97.CellName = "select";
            this.xEditGridCell97.CellWidth = 78;
            this.xEditGridCell97.Col = 1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsUpdatable = false;
            this.xEditGridCell97.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell97.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.RowImageIndex = 0;
            this.xEditGridCell97.RowSpan = 2;
            this.xEditGridCell97.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "send_yn";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell226
            // 
            this.xEditGridCell226.CellName = "if_flag";
            this.xEditGridCell226.Col = -1;
            this.xEditGridCell226.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell226, "xEditGridCell226");
            this.xEditGridCell226.IsVisible = false;
            this.xEditGridCell226.Row = -1;
            // 
            // xEditGridCell228
            // 
            this.xEditGridCell228.CellName = "fkifs1004";
            this.xEditGridCell228.Col = -1;
            this.xEditGridCell228.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell228, "xEditGridCell228");
            this.xEditGridCell228.IsVisible = false;
            this.xEditGridCell228.Row = -1;
            // 
            // xEditGridCell251
            // 
            this.xEditGridCell251.CellName = "naewon_yn";
            this.xEditGridCell251.Col = -1;
            this.xEditGridCell251.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell251, "xEditGridCell251");
            this.xEditGridCell251.IsVisible = false;
            this.xEditGridCell251.Row = -1;
            // 
            // xEditGridCell207
            // 
            this.xEditGridCell207.CellName = "order_by_key";
            this.xEditGridCell207.Col = -1;
            this.xEditGridCell207.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell207, "xEditGridCell207");
            this.xEditGridCell207.IsVisible = false;
            this.xEditGridCell207.Row = -1;
            // 
            // xEditGridCell247
            // 
            this.xEditGridCell247.CellName = "trial_flg";
            this.xEditGridCell247.CellWidth = 32;
            this.xEditGridCell247.Col = 6;
            this.xEditGridCell247.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell247.ExecuteQuery = null;
            this.xEditGridCell247.Row = 1;
            // 
            // xEditGridCell252
            // 
            this.xEditGridCell252.CellName = "cls_code";
            this.xEditGridCell252.Col = -1;
            this.xEditGridCell252.ExecuteQuery = null;
            this.xEditGridCell252.IsVisible = false;
            this.xEditGridCell252.Row = -1;
            // 
            // xEditGridCell253
            // 
            this.xEditGridCell253.CellName = "sg_code";
            this.xEditGridCell253.Col = -1;
            this.xEditGridCell253.ExecuteQuery = null;
            this.xEditGridCell253.IsVisible = false;
            this.xEditGridCell253.Row = -1;
            // 
            // xEditGridCell254
            // 
            this.xEditGridCell254.CellName = "order_status";
            this.xEditGridCell254.Col = -1;
            this.xEditGridCell254.ExecuteQuery = null;
            this.xEditGridCell254.IsVisible = false;
            this.xEditGridCell254.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 12;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // grdINP2004
            // 
            this.grdINP2004.AddedHeaderLine = 1;
            this.grdINP2004.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell229,
            this.xEditGridCell230,
            this.xEditGridCell231,
            this.xEditGridCell232,
            this.xEditGridCell233,
            this.xEditGridCell234,
            this.xEditGridCell235,
            this.xEditGridCell237,
            this.xEditGridCell239,
            this.xEditGridCell241,
            this.xEditGridCell243,
            this.xEditGridCell236,
            this.xEditGridCell238,
            this.xEditGridCell240,
            this.xEditGridCell242,
            this.xEditGridCell244,
            this.xEditGridCell245,
            this.xEditGridCell246});
            this.grdINP2004.ColPerLine = 14;
            this.grdINP2004.Cols = 15;
            this.grdINP2004.ExecuteQuery = null;
            this.grdINP2004.FixedCols = 1;
            this.grdINP2004.FixedRows = 2;
            this.grdINP2004.HeaderHeights.Add(21);
            this.grdINP2004.HeaderHeights.Add(21);
            this.grdINP2004.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader7,
            this.xGridHeader8});
            resources.ApplyResources(this.grdINP2004, "grdINP2004");
            this.grdINP2004.Name = "grdINP2004";
            this.grdINP2004.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdINP2004.ParamList")));
            this.grdINP2004.QuerySQL = "SELECT A.BUNHO BUNHO";
            this.grdINP2004.RowHeaderVisible = true;
            this.grdINP2004.Rows = 3;
            this.grdINP2004.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP2004_QueryStarting);
            // 
            // xEditGridCell229
            // 
            this.xEditGridCell229.CellName = "bunho";
            this.xEditGridCell229.Col = 1;
            this.xEditGridCell229.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell229, "xEditGridCell229");
            this.xEditGridCell229.RowSpan = 2;
            // 
            // xEditGridCell230
            // 
            this.xEditGridCell230.CellName = "suname";
            this.xEditGridCell230.Col = 2;
            this.xEditGridCell230.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell230, "xEditGridCell230");
            this.xEditGridCell230.RowSpan = 2;
            // 
            // xEditGridCell231
            // 
            this.xEditGridCell231.CellName = "ipwon_date";
            this.xEditGridCell231.Col = 3;
            this.xEditGridCell231.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell231, "xEditGridCell231");
            this.xEditGridCell231.RowSpan = 2;
            // 
            // xEditGridCell232
            // 
            this.xEditGridCell232.CellName = "data_date";
            this.xEditGridCell232.Col = 4;
            this.xEditGridCell232.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell232, "xEditGridCell232");
            this.xEditGridCell232.RowSpan = 2;
            // 
            // xEditGridCell233
            // 
            this.xEditGridCell233.CellName = "fkinp1001";
            this.xEditGridCell233.Col = -1;
            this.xEditGridCell233.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell233, "xEditGridCell233");
            this.xEditGridCell233.IsVisible = false;
            this.xEditGridCell233.Row = -1;
            // 
            // xEditGridCell234
            // 
            this.xEditGridCell234.CellName = "fkinp1002";
            this.xEditGridCell234.Col = -1;
            this.xEditGridCell234.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell234, "xEditGridCell234");
            this.xEditGridCell234.IsVisible = false;
            this.xEditGridCell234.Row = -1;
            // 
            // xEditGridCell235
            // 
            this.xEditGridCell235.CellName = "from_gwa";
            this.xEditGridCell235.CellWidth = 50;
            this.xEditGridCell235.Col = 5;
            this.xEditGridCell235.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell235, "xEditGridCell235");
            this.xEditGridCell235.Row = 1;
            // 
            // xEditGridCell237
            // 
            this.xEditGridCell237.CellName = "from_doctor";
            this.xEditGridCell237.CellWidth = 55;
            this.xEditGridCell237.Col = 6;
            this.xEditGridCell237.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell237, "xEditGridCell237");
            this.xEditGridCell237.Row = 1;
            // 
            // xEditGridCell239
            // 
            this.xEditGridCell239.CellName = "from_ho_dong";
            this.xEditGridCell239.Col = 7;
            this.xEditGridCell239.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell239, "xEditGridCell239");
            this.xEditGridCell239.Row = 1;
            // 
            // xEditGridCell241
            // 
            this.xEditGridCell241.CellName = "from_ho_code";
            this.xEditGridCell241.Col = 8;
            this.xEditGridCell241.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell241, "xEditGridCell241");
            this.xEditGridCell241.Row = 1;
            // 
            // xEditGridCell243
            // 
            this.xEditGridCell243.CellName = "from_bed_no";
            this.xEditGridCell243.Col = 9;
            this.xEditGridCell243.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell243, "xEditGridCell243");
            this.xEditGridCell243.Row = 1;
            // 
            // xEditGridCell236
            // 
            this.xEditGridCell236.CellName = "to_gwa";
            this.xEditGridCell236.CellWidth = 55;
            this.xEditGridCell236.Col = 10;
            this.xEditGridCell236.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell236, "xEditGridCell236");
            this.xEditGridCell236.Row = 1;
            // 
            // xEditGridCell238
            // 
            this.xEditGridCell238.CellName = "to_doctor";
            this.xEditGridCell238.Col = 11;
            this.xEditGridCell238.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell238, "xEditGridCell238");
            this.xEditGridCell238.Row = 1;
            // 
            // xEditGridCell240
            // 
            this.xEditGridCell240.CellName = "to_ho_dong";
            this.xEditGridCell240.Col = 12;
            this.xEditGridCell240.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell240, "xEditGridCell240");
            this.xEditGridCell240.Row = 1;
            // 
            // xEditGridCell242
            // 
            this.xEditGridCell242.CellName = "to_ho_code";
            this.xEditGridCell242.Col = 13;
            this.xEditGridCell242.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell242, "xEditGridCell242");
            this.xEditGridCell242.Row = 1;
            // 
            // xEditGridCell244
            // 
            this.xEditGridCell244.CellName = "to_bed_no";
            this.xEditGridCell244.Col = 14;
            this.xEditGridCell244.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell244, "xEditGridCell244");
            this.xEditGridCell244.Row = 1;
            // 
            // xEditGridCell245
            // 
            this.xEditGridCell245.CellName = "send_yn";
            this.xEditGridCell245.Col = -1;
            this.xEditGridCell245.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell245, "xEditGridCell245");
            this.xEditGridCell245.IsVisible = false;
            this.xEditGridCell245.Row = -1;
            // 
            // xEditGridCell246
            // 
            this.xEditGridCell246.CellName = "if_flag";
            this.xEditGridCell246.Col = -1;
            this.xEditGridCell246.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell246, "xEditGridCell246");
            this.xEditGridCell246.IsVisible = false;
            this.xEditGridCell246.Row = -1;
            // 
            // xGridHeader7
            // 
            this.xGridHeader7.Col = 5;
            this.xGridHeader7.ColSpan = 5;
            resources.ApplyResources(this.xGridHeader7, "xGridHeader7");
            this.xGridHeader7.HeaderWidth = 50;
            // 
            // xGridHeader8
            // 
            this.xGridHeader8.Col = 10;
            this.xGridHeader8.ColSpan = 5;
            resources.ApplyResources(this.xGridHeader8, "xGridHeader8");
            this.xGridHeader8.HeaderWidth = 55;
            // 
            // pnlWoichul
            // 
            this.pnlWoichul.Controls.Add(this.grdWoichul);
            resources.ApplyResources(this.pnlWoichul, "pnlWoichul");
            this.pnlWoichul.Name = "pnlWoichul";
            // 
            // grdWoichul
            // 
            this.grdWoichul.AddedHeaderLine = 1;
            this.grdWoichul.CallerID = '3';
            this.grdWoichul.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell77,
            this.xEditGridCell62,
            this.xEditGridCell120,
            this.xEditGridCell122,
            this.xEditGridCell123,
            this.xEditGridCell124,
            this.xEditGridCell125,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell98,
            this.xEditGridCell105,
            this.xEditGridCell118,
            this.xEditGridCell14,
            this.xEditGridCell127,
            this.xEditGridCell82,
            this.xEditGridCell192});
            this.grdWoichul.ColPerLine = 10;
            this.grdWoichul.Cols = 11;
            resources.ApplyResources(this.grdWoichul, "grdWoichul");
            this.grdWoichul.ExecuteQuery = null;
            this.grdWoichul.FixedCols = 1;
            this.grdWoichul.FixedRows = 2;
            this.grdWoichul.HeaderHeights.Add(35);
            this.grdWoichul.HeaderHeights.Add(0);
            this.grdWoichul.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader3,
            this.xGridHeader4,
            this.xGridHeader5});
            this.grdWoichul.Name = "grdWoichul";
            this.grdWoichul.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdWoichul.ParamList")));
            this.grdWoichul.QuerySQL = "SELECT A.FKINP1001                                                       FKINP100" +
                "1";
            this.grdWoichul.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdWoichul.RowHeaderVisible = true;
            this.grdWoichul.Rows = 3;
            this.grdWoichul.RowStateCheckOnPaint = false;
            this.grdWoichul.ToolTipActive = true;
            this.grdWoichul.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdWoichul_GridColumnChanged);
            this.grdWoichul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdEdit_MouseDown);
            this.grdWoichul.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdWoichul_GridColumnProtectModify);
            this.grdWoichul.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grid_QueryStarting);
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "pk1001";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "pkocs";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "bunho";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsReadOnly = true;
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "out_date";
            this.xEditGridCell122.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell122.CellWidth = 135;
            this.xEditGridCell122.Col = 2;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsJapanYearType = true;
            this.xEditGridCell122.IsReadOnly = true;
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.Row = 1;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "out_time";
            this.xEditGridCell123.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell123.CellWidth = 60;
            this.xEditGridCell123.Col = 3;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsReadOnly = true;
            this.xEditGridCell123.IsUpdatable = false;
            this.xEditGridCell123.Mask = "HH:MI";
            this.xEditGridCell123.Row = 1;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "in_date";
            this.xEditGridCell124.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell124.CellWidth = 135;
            this.xEditGridCell124.Col = 4;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsJapanYearType = true;
            this.xEditGridCell124.IsReadOnly = true;
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.Row = 1;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "in_time";
            this.xEditGridCell125.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell125.CellWidth = 60;
            this.xEditGridCell125.Col = 5;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsReadOnly = true;
            this.xEditGridCell125.IsUpdatable = false;
            this.xEditGridCell125.Mask = "HH:MI";
            this.xEditGridCell125.Row = 1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "true_date";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell99.CellWidth = 135;
            this.xEditGridCell99.Col = 6;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsJapanYearType = true;
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.Row = 1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "true_time";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell100.CellWidth = 60;
            this.xEditGridCell100.Col = 7;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.Mask = "HH:MI";
            this.xEditGridCell100.Row = 1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "object";
            this.xEditGridCell98.CellWidth = 130;
            this.xEditGridCell98.Col = 8;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsUpdatable = false;
            this.xEditGridCell98.RowSpan = 2;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "start_date";
            this.xEditGridCell105.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell105.CellWidth = 135;
            this.xEditGridCell105.Col = 9;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsJapanYearType = true;
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsUpdatable = false;
            this.xEditGridCell105.RowSpan = 2;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "end_date";
            this.xEditGridCell118.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell118.CellWidth = 135;
            this.xEditGridCell118.Col = 10;
            this.xEditGridCell118.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsJapanYearType = true;
            this.xEditGridCell118.RowSpan = 2;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "acting_yn";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell127.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell127.CellName = "select";
            this.xEditGridCell127.CellWidth = 35;
            this.xEditGridCell127.Col = 1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsReadOnly = true;
            this.xEditGridCell127.IsUpdatable = false;
            this.xEditGridCell127.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell127.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell127.RowSpan = 2;
            this.xEditGridCell127.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "send_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell192
            // 
            this.xEditGridCell192.CellName = "seq";
            this.xEditGridCell192.Col = -1;
            this.xEditGridCell192.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell192, "xEditGridCell192");
            this.xEditGridCell192.IsVisible = false;
            this.xEditGridCell192.Row = -1;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 2;
            this.xGridHeader3.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            this.xGridHeader3.HeaderWidth = 100;
            // 
            // xGridHeader4
            // 
            this.xGridHeader4.Col = 4;
            this.xGridHeader4.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader4, "xGridHeader4");
            this.xGridHeader4.HeaderWidth = 100;
            // 
            // xGridHeader5
            // 
            this.xGridHeader5.Col = 6;
            this.xGridHeader5.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader5, "xGridHeader5");
            this.xGridHeader5.HeaderWidth = 100;
            // 
            // pnlSiksa
            // 
            this.pnlSiksa.Controls.Add(this.grdSiksa);
            resources.ApplyResources(this.pnlSiksa, "pnlSiksa");
            this.pnlSiksa.Name = "pnlSiksa";
            // 
            // grdSiksa
            // 
            this.grdSiksa.AddedHeaderLine = 1;
            this.grdSiksa.CallerID = '2';
            this.grdSiksa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell85,
            this.xEditGridCell93,
            this.xEditGridCell86,
            this.xEditGridCell18,
            this.xEditGridCell88,
            this.xEditGridCell52,
            this.xEditGridCell89,
            this.xEditGridCell64,
            this.xEditGridCell94,
            this.xEditGridCell17,
            this.xEditGridCell90,
            this.xEditGridCell119,
            this.xEditGridCell92,
            this.xEditGridCell15,
            this.xEditGridCell65,
            this.xEditGridCell91});
            this.grdSiksa.ColPerLine = 7;
            this.grdSiksa.Cols = 8;
            resources.ApplyResources(this.grdSiksa, "grdSiksa");
            this.grdSiksa.ExecuteQuery = null;
            this.grdSiksa.FixedCols = 1;
            this.grdSiksa.FixedRows = 2;
            this.grdSiksa.HeaderHeights.Add(33);
            this.grdSiksa.HeaderHeights.Add(0);
            this.grdSiksa.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdSiksa.Name = "grdSiksa";
            this.grdSiksa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSiksa.ParamList")));
            this.grdSiksa.QuerySQL = " SELECT A.FKINP1001";
            this.grdSiksa.ReadOnly = true;
            this.grdSiksa.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdSiksa.RowHeaderVisible = true;
            this.grdSiksa.Rows = 3;
            this.grdSiksa.RowStateCheckOnPaint = false;
            this.grdSiksa.ToolTipActive = true;
            this.grdSiksa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdEdit_MouseDown);
            this.grdSiksa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grid_QueryStarting);
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "pk1001";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "pkocs";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "bunho";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "input_gubun";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "direct_gubun";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "ki_gubun";
            this.xEditGridCell18.CellWidth = 88;
            this.xEditGridCell18.Col = 2;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.RowSpan = 2;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "direct_code";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "nut_gubun";
            this.xEditGridCell52.CellWidth = 209;
            this.xEditGridCell52.Col = 3;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.Row = 1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "direct_cont1";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "nut_gubun_name";
            this.xEditGridCell64.CellWidth = 265;
            this.xEditGridCell64.Col = 4;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.Row = 1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "order_date";
            this.xEditGridCell94.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "start_date";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell17.CellWidth = 120;
            this.xEditGridCell17.Col = 5;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsJapanYearType = true;
            this.xEditGridCell17.RowSpan = 2;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "end_date";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell90.CellWidth = 120;
            this.xEditGridCell90.Col = 6;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsJapanYearType = true;
            this.xEditGridCell90.RowSpan = 2;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "sunab_date";
            this.xEditGridCell119.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell119.CellWidth = 120;
            this.xEditGridCell119.Col = 7;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsJapanYearType = true;
            this.xEditGridCell119.RowSpan = 2;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "seq";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "acting_yn";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell65.AlterateRowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell65.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell65.CellName = "select";
            this.xEditGridCell65.CellWidth = 35;
            this.xEditGridCell65.Col = 1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell65.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell65.RowSpan = 2;
            this.xEditGridCell65.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "send_yn";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 3;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 104;
            // 
            // pnlJungwa
            // 
            this.pnlJungwa.Controls.Add(this.grdJungwa);
            resources.ApplyResources(this.pnlJungwa, "pnlJungwa");
            this.pnlJungwa.Name = "pnlJungwa";
            // 
            // grdJungwa
            // 
            this.grdJungwa.CallerID = '4';
            this.grdJungwa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell78,
            this.xEditGridCell106,
            this.xEditGridCell128,
            this.xEditGridCell66,
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
            this.xEditGridCell96,
            this.xEditGridCell16,
            this.xEditGridCell103,
            this.xEditGridCell83});
            this.grdJungwa.ColPerLine = 13;
            this.grdJungwa.Cols = 14;
            resources.ApplyResources(this.grdJungwa, "grdJungwa");
            this.grdJungwa.ExecuteQuery = null;
            this.grdJungwa.FixedCols = 1;
            this.grdJungwa.FixedRows = 1;
            this.grdJungwa.HeaderHeights.Add(33);
            this.grdJungwa.Name = "grdJungwa";
            this.grdJungwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdJungwa.ParamList")));
            this.grdJungwa.ReadOnly = true;
            this.grdJungwa.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdJungwa.RowHeaderVisible = true;
            this.grdJungwa.Rows = 2;
            this.grdJungwa.RowStateCheckOnPaint = false;
            this.grdJungwa.ToolTipActive = true;
            this.grdJungwa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdEdit_MouseDown);
            this.grdJungwa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grid_QueryStarting);
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "pk1001";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "pkocs";
            this.xEditGridCell106.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell106.CellWidth = 41;
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "bunho";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "order_date";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell66.CellWidth = 110;
            this.xEditGridCell66.Col = 2;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsJapanYearType = true;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "from_gwa";
            this.xEditGridCell107.CellWidth = 90;
            this.xEditGridCell107.Col = 12;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "to_gwa";
            this.xEditGridCell108.CellWidth = 90;
            this.xEditGridCell108.Col = 7;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "from_doctor";
            this.xEditGridCell109.CellWidth = 115;
            this.xEditGridCell109.Col = 13;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "to_doctor";
            this.xEditGridCell110.CellWidth = 115;
            this.xEditGridCell110.Col = 8;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "from_ho_dong";
            this.xEditGridCell111.Col = 9;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "to_ho_dong";
            this.xEditGridCell112.Col = 4;
            this.xEditGridCell112.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "from_ho_code";
            this.xEditGridCell113.Col = 10;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "to_ho_code";
            this.xEditGridCell114.Col = 5;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "seq";
            this.xEditGridCell115.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "trans_time";
            this.xEditGridCell116.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell116.CellWidth = 60;
            this.xEditGridCell116.Col = 3;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.Mask = "HH:MI";
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "from_bed_no";
            this.xEditGridCell117.CellWidth = 60;
            this.xEditGridCell117.Col = 11;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "to_bed_no";
            this.xEditGridCell96.CellWidth = 60;
            this.xEditGridCell96.Col = 6;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "acting_yn";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell103.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell103.CellName = "select";
            this.xEditGridCell103.CellWidth = 35;
            this.xEditGridCell103.Col = 1;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell103.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell103.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "send_yn";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // lbSelectAll
            // 
            this.lbSelectAll.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.lbSelectAll, "lbSelectAll");
            this.lbSelectAll.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lbSelectAll.ImageList = this.ImageList;
            this.lbSelectAll.Name = "lbSelectAll";
            this.lbSelectAll.Tag = "N";
            this.lbSelectAll.Click += new System.EventHandler(this.lbSelectAll_Click);
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.xPanel9);
            this.xPanel5.Controls.Add(this.xPanel2);
            this.xPanel5.Controls.Add(this.xPanel11);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Name = "xPanel5";
            // 
            // xPanel9
            // 
            this.xPanel9.Controls.Add(this.pnlHoken);
            this.xPanel9.Controls.Add(this.pnlInfo);
            this.xPanel9.Controls.Add(this.xPanel10);
            resources.ApplyResources(this.xPanel9, "xPanel9");
            this.xPanel9.Name = "xPanel9";
            // 
            // pnlHoken
            // 
            this.pnlHoken.Controls.Add(this.grdHoken);
            resources.ApplyResources(this.pnlHoken, "pnlHoken");
            this.pnlHoken.Name = "pnlHoken";
            // 
            // grdHoken
            // 
            this.grdHoken.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell210,
            this.xEditGridCell211,
            this.xEditGridCell212,
            this.xEditGridCell213,
            this.xEditGridCell215,
            this.xEditGridCell214});
            this.grdHoken.ColPerLine = 6;
            this.grdHoken.Cols = 6;
            resources.ApplyResources(this.grdHoken, "grdHoken");
            this.grdHoken.ExecuteQuery = null;
            this.grdHoken.FixedRows = 1;
            this.grdHoken.HeaderHeights.Add(21);
            this.grdHoken.Name = "grdHoken";
            this.grdHoken.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdHoken.ParamList")));
            this.grdHoken.QuerySQL = " SELECT A.GUBUN";
            this.grdHoken.Rows = 2;
            this.grdHoken.RowStateCheckOnPaint = false;
            this.grdHoken.ToolTipActive = true;
            this.grdHoken.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdHoken_ItemValueChanging);
            this.grdHoken.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHoken_QueryStarting);
            // 
            // xEditGridCell210
            // 
            this.xEditGridCell210.CellName = "gubun";
            this.xEditGridCell210.CellWidth = 35;
            this.xEditGridCell210.Col = 1;
            this.xEditGridCell210.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell210, "xEditGridCell210");
            this.xEditGridCell210.IsUpdatable = false;
            // 
            // xEditGridCell211
            // 
            this.xEditGridCell211.CellName = "gubun_name";
            this.xEditGridCell211.CellWidth = 106;
            this.xEditGridCell211.Col = 2;
            this.xEditGridCell211.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell211, "xEditGridCell211");
            this.xEditGridCell211.IsUpdatable = false;
            // 
            // xEditGridCell212
            // 
            this.xEditGridCell212.CellName = "start_date";
            this.xEditGridCell212.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell212.CellWidth = 95;
            this.xEditGridCell212.Col = 4;
            this.xEditGridCell212.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell212, "xEditGridCell212");
            this.xEditGridCell212.IsJapanYearType = true;
            this.xEditGridCell212.IsUpdatable = false;
            // 
            // xEditGridCell213
            // 
            this.xEditGridCell213.CellName = "end_date";
            this.xEditGridCell213.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell213.CellWidth = 105;
            this.xEditGridCell213.Col = 5;
            this.xEditGridCell213.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell213, "xEditGridCell213");
            this.xEditGridCell213.IsJapanYearType = true;
            this.xEditGridCell213.IsUpdatable = false;
            // 
            // xEditGridCell215
            // 
            this.xEditGridCell215.CellName = "johap";
            this.xEditGridCell215.CellWidth = 136;
            this.xEditGridCell215.Col = 3;
            this.xEditGridCell215.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell215, "xEditGridCell215");
            // 
            // xEditGridCell214
            // 
            this.xEditGridCell214.CellName = "select";
            this.xEditGridCell214.CellWidth = 57;
            this.xEditGridCell214.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell214.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell214, "xEditGridCell214");
            this.xEditGridCell214.IsReadOnly = true;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.pnlBunho);
            this.pnlInfo.Controls.Add(this.tabDataInfo);
            resources.ApplyResources(this.pnlInfo, "pnlInfo");
            this.pnlInfo.Name = "pnlInfo";
            // 
            // pnlBunho
            // 
            this.pnlBunho.Controls.Add(this.grdGongbi);
            this.pnlBunho.Controls.Add(this.grdComment);
            resources.ApplyResources(this.pnlBunho, "pnlBunho");
            this.pnlBunho.Name = "pnlBunho";
            // 
            // grdGongbi
            // 
            this.grdGongbi.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell73,
            this.xEditGridCell74,
            this.xEditGridCell72,
            this.xEditGridCell202,
            this.xEditGridCell205});
            this.grdGongbi.ColPerLine = 7;
            this.grdGongbi.Cols = 7;
            resources.ApplyResources(this.grdGongbi, "grdGongbi");
            this.grdGongbi.ExecuteQuery = null;
            this.grdGongbi.FixedRows = 1;
            this.grdGongbi.HeaderHeights.Add(20);
            this.grdGongbi.Name = "grdGongbi";
            this.grdGongbi.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdGongbi.ParamList")));
            this.grdGongbi.ReadOnly = true;
            this.grdGongbi.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdGongbi.Rows = 2;
            this.grdGongbi.RowStateCheckOnPaint = false;
            this.grdGongbi.ToolTipActive = true;
            this.grdGongbi.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGongbi_QueryStarting);
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "gongbi_code";
            this.xEditGridCell69.CellWidth = 94;
            this.xEditGridCell69.Col = 2;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsUpdatable = false;
            this.xEditGridCell69.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "gongbi_name";
            this.xEditGridCell70.CellWidth = 129;
            this.xEditGridCell70.Col = 3;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsUpdatable = false;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "last_check_date";
            this.xEditGridCell71.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell71.CellWidth = 147;
            this.xEditGridCell71.Col = 4;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsJapanYearType = true;
            this.xEditGridCell71.IsUpdatable = false;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "budamja_bunho";
            this.xEditGridCell73.CellWidth = 103;
            this.xEditGridCell73.Col = 5;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "sugubja_bunho";
            this.xEditGridCell74.CellWidth = 117;
            this.xEditGridCell74.Col = 6;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsUpdatable = false;
            this.xEditGridCell74.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "select";
            this.xEditGridCell72.CellWidth = 55;
            this.xEditGridCell72.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            // 
            // xEditGridCell202
            // 
            this.xEditGridCell202.CellName = "priority";
            this.xEditGridCell202.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell202.CellWidth = 60;
            this.xEditGridCell202.Col = 1;
            this.xEditGridCell202.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell202, "xEditGridCell202");
            this.xEditGridCell202.IsUpdatable = false;
            this.xEditGridCell202.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell205
            // 
            this.xEditGridCell205.CellName = "if_valid_yn";
            this.xEditGridCell205.Col = -1;
            this.xEditGridCell205.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell205, "xEditGridCell205");
            this.xEditGridCell205.IsUpdatable = false;
            this.xEditGridCell205.IsVisible = false;
            this.xEditGridCell205.Row = -1;
            // 
            // grdComment
            // 
            this.grdComment.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58});
            this.grdComment.ColPerLine = 1;
            this.grdComment.Cols = 2;
            this.grdComment.ControlBinding = true;
            resources.ApplyResources(this.grdComment, "grdComment");
            this.grdComment.ExecuteQuery = null;
            this.grdComment.FixedCols = 1;
            this.grdComment.FixedRows = 1;
            this.grdComment.HeaderHeights.Add(21);
            this.grdComment.Name = "grdComment";
            this.grdComment.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdComment.ParamList")));
            this.grdComment.QuerySQL = "SELECT A.BUNHO, A.SER, A.COMMENTS\r\n  FROM OUT0106 A\r\n WHERE A.HOSP_CODE = :f_hosp" +
                "_code\r\n   AND A.BUNHO     = :f_bunho";
            this.grdComment.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdComment.RowHeaderVisible = true;
            this.grdComment.Rows = 2;
            this.grdComment.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdComment_QueryStarting);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "bunho";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "ser";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "comment";
            this.xEditGridCell58.CellWidth = 418;
            this.xEditGridCell58.Col = 1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsReadOnly = true;
            this.xEditGridCell58.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabDataInfo
            // 
            resources.ApplyResources(this.tabDataInfo, "tabDataInfo");
            this.tabDataInfo.IDEPixelArea = true;
            this.tabDataInfo.IDEPixelBorder = false;
            this.tabDataInfo.Name = "tabDataInfo";
            this.tabDataInfo.ShowArrows = false;
            this.tabDataInfo.ShowClose = false;
            // 
            // xPanel10
            // 
            this.xPanel10.Controls.Add(this.btnPrint);
            this.xPanel10.Controls.Add(this.dbxGongbi_Name4);
            this.xPanel10.Controls.Add(this.dbxGongbi_Name3);
            this.xPanel10.Controls.Add(this.dbxGongbi_Name2);
            this.xPanel10.Controls.Add(this.dbxGongbi_Name1);
            this.xPanel10.Controls.Add(this.xLabel11);
            this.xPanel10.Controls.Add(this.dbxSanjung_Name);
            this.xPanel10.Controls.Add(this.dbxChojae_Name);
            this.xPanel10.Controls.Add(this.xLabel4);
            this.xPanel10.Controls.Add(this.dbxGwa_name);
            this.xPanel10.Controls.Add(this.xLabel8);
            this.xPanel10.Controls.Add(this.dbxDoctor);
            this.xPanel10.Controls.Add(this.xLabel7);
            this.xPanel10.Controls.Add(this.xLabel6);
            this.xPanel10.Controls.Add(this.xLabel2);
            this.xPanel10.Controls.Add(this.xLabel5);
            this.xPanel10.Controls.Add(this.dbxHoken_Name);
            this.xPanel10.Controls.Add(this.fbxHoken);
            resources.ApplyResources(this.xPanel10, "xPanel10");
            this.xPanel10.DrawBorder = true;
            this.xPanel10.Name = "xPanel10";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dbxGongbi_Name4
            // 
            resources.ApplyResources(this.dbxGongbi_Name4, "dbxGongbi_Name4");
            this.dbxGongbi_Name4.Name = "dbxGongbi_Name4";
            // 
            // dbxGongbi_Name3
            // 
            resources.ApplyResources(this.dbxGongbi_Name3, "dbxGongbi_Name3");
            this.dbxGongbi_Name3.Name = "dbxGongbi_Name3";
            // 
            // dbxGongbi_Name2
            // 
            resources.ApplyResources(this.dbxGongbi_Name2, "dbxGongbi_Name2");
            this.dbxGongbi_Name2.Name = "dbxGongbi_Name2";
            // 
            // dbxGongbi_Name1
            // 
            resources.ApplyResources(this.dbxGongbi_Name1, "dbxGongbi_Name1");
            this.dbxGongbi_Name1.Name = "dbxGongbi_Name1";
            // 
            // xLabel11
            // 
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Name = "xLabel11";
            // 
            // dbxSanjung_Name
            // 
            resources.ApplyResources(this.dbxSanjung_Name, "dbxSanjung_Name");
            this.dbxSanjung_Name.Name = "dbxSanjung_Name";
            // 
            // dbxChojae_Name
            // 
            resources.ApplyResources(this.dbxChojae_Name, "dbxChojae_Name");
            this.dbxChojae_Name.Name = "dbxChojae_Name";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // dbxGwa_name
            // 
            resources.ApplyResources(this.dbxGwa_name, "dbxGwa_name");
            this.dbxGwa_name.Name = "dbxGwa_name";
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // dbxDoctor
            // 
            resources.ApplyResources(this.dbxDoctor, "dbxDoctor");
            this.dbxDoctor.Name = "dbxDoctor";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // dbxHoken_Name
            // 
            resources.ApplyResources(this.dbxHoken_Name, "dbxHoken_Name");
            this.dbxHoken_Name.Name = "dbxHoken_Name";
            // 
            // fbxHoken
            // 
            this.fbxHoken.EnableEdit = false;
            this.fbxHoken.FindWorker = this.fwkFind;
            resources.ApplyResources(this.fbxHoken, "fbxHoken");
            this.fbxHoken.Name = "fbxHoken";
            this.fbxHoken.Protect = true;
            this.fbxHoken.ReadOnly = true;
            this.fbxHoken.TabStop = false;
            this.fbxHoken.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHoken_DataValidating);
            this.fbxHoken.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxHoken_FindClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xPanel6);
            this.xPanel2.Controls.Add(this.tabDataGubun);
            this.xPanel2.Controls.Add(this.xPanel4);
            this.xPanel2.Controls.Add(this.xPanel7);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.grdOutList);
            this.xPanel6.Controls.Add(this.grdInpList);
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Name = "xPanel6";
            // 
            // grdOutList
            // 
            this.grdOutList.ApplyPaintEventToAllColumn = true;
            this.grdOutList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell87,
            this.xEditGridCell1,
            this.xEditGridCell95,
            this.xEditGridCell75,
            this.xEditGridCell3,
            this.xEditGridCell7,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell36,
            this.xEditGridCell46,
            this.xEditGridCell248,
            this.xEditGridCell250,
            this.xEditGridCell227,
            this.xEditGridCell51,
            this.xEditGridCell255,
            this.xEditGridCell2,
            this.xEditGridCell6,
            this.xEditGridCell121,
            this.xEditGridCell181,
            this.xEditGridCell208,
            this.xEditGridCell39,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell81,
            this.xEditGridCell183,
            this.xEditGridCell184,
            this.xEditGridCell189,
            this.xEditGridCell67,
            this.xEditGridCell35,
            this.xEditGridCell193,
            this.xEditGridCell194,
            this.xEditGridCell195,
            this.xEditGridCell216,
            this.xEditGridCell217,
            this.xEditGridCell218,
            this.xEditGridCell219,
            this.xEditGridCell200,
            this.xEditGridCell204,
            this.xEditGridCell224,
            this.xEditGridCell225});
            this.grdOutList.ColPerLine = 8;
            this.grdOutList.Cols = 9;
            this.grdOutList.ControlBinding = true;
            resources.ApplyResources(this.grdOutList, "grdOutList");
            this.grdOutList.ExecuteQuery = null;
            this.grdOutList.FixedCols = 1;
            this.grdOutList.FixedRows = 1;
            this.grdOutList.HeaderHeights.Add(28);
            this.grdOutList.Name = "grdOutList";
            this.grdOutList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOutList.ParamList")));
            this.grdOutList.ReadOnly = true;
            this.grdOutList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdOutList.RowHeaderVisible = true;
            this.grdOutList.Rows = 2;
            this.grdOutList.RowStateCheckOnPaint = false;
            this.grdOutList.ToolTipActive = true;
            this.grdOutList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdList_MouseDown);
            this.grdOutList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
            this.grdOutList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOutList_GridCellPainting);
            this.grdOutList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "pk1001";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 93;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "suname";
            this.xEditGridCell95.CellWidth = 75;
            this.xEditGridCell95.Col = 3;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "acting_date";
            this.xEditGridCell75.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell75.CellWidth = 95;
            this.xEditGridCell75.Col = 4;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsJapanYearType = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "gwa";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.BindControl = this.dbxGwa_name;
            this.xEditGridCell7.CellName = "gwa_name";
            this.xEditGridCell7.CellWidth = 230;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "doctor";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.dbxDoctor;
            this.xEditGridCell8.CellName = "doctor_name";
            this.xEditGridCell8.CellWidth = 102;
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.BindControl = this.fbxHoken;
            this.xEditGridCell36.CellName = "gubun";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.BindControl = this.dbxHoken_Name;
            this.xEditGridCell46.CellName = "gubun_name";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell248
            // 
            this.xEditGridCell248.CellName = "sended_yn";
            this.xEditGridCell248.Col = -1;
            this.xEditGridCell248.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell248, "xEditGridCell248");
            this.xEditGridCell248.IsVisible = false;
            this.xEditGridCell248.Row = -1;
            // 
            // xEditGridCell250
            // 
            this.xEditGridCell250.CellName = "naewon_yn";
            this.xEditGridCell250.Col = -1;
            this.xEditGridCell250.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell250, "xEditGridCell250");
            this.xEditGridCell250.IsVisible = false;
            this.xEditGridCell250.Row = -1;
            // 
            // xEditGridCell227
            // 
            this.xEditGridCell227.CellName = "order_by_key";
            this.xEditGridCell227.Col = -1;
            this.xEditGridCell227.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell227, "xEditGridCell227");
            this.xEditGridCell227.IsVisible = false;
            this.xEditGridCell227.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.BindControl = this.dbxChojae_Name;
            this.xEditGridCell51.CellName = "chojae_name";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "naewon_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 87;
            this.xEditGridCell2.Col = 7;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsJapanYearType = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "jubsu_time";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell6.CellWidth = 113;
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.Mask = "HH:MI";
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "order_date";
            this.xEditGridCell121.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell121.Col = -1;
            this.xEditGridCell121.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell181.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell181.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell181.AlterateRowImageIndex = 0;
            this.xEditGridCell181.CellName = "select";
            this.xEditGridCell181.CellWidth = 56;
            this.xEditGridCell181.Col = 1;
            this.xEditGridCell181.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell181, "xEditGridCell181");
            this.xEditGridCell181.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell181.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell181.RowImageIndex = 0;
            this.xEditGridCell181.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell208
            // 
            this.xEditGridCell208.BindControl = this.txtGongbi_yn;
            this.xEditGridCell208.CellName = "gongbi_yn";
            this.xEditGridCell208.Col = -1;
            this.xEditGridCell208.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell208, "xEditGridCell208");
            this.xEditGridCell208.IsVisible = false;
            this.xEditGridCell208.Row = -1;
            // 
            // txtGongbi_yn
            // 
            resources.ApplyResources(this.txtGongbi_yn, "txtGongbi_yn");
            this.txtGongbi_yn.Name = "txtGongbi_yn";
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "chojae";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "reser_yn";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "jubsu_gubun";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "pkout";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell183
            // 
            this.xEditGridCell183.CellName = "gubun_old";
            this.xEditGridCell183.Col = -1;
            this.xEditGridCell183.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell183, "xEditGridCell183");
            this.xEditGridCell183.IsVisible = false;
            this.xEditGridCell183.Row = -1;
            // 
            // xEditGridCell184
            // 
            this.xEditGridCell184.CellName = "chojae_old";
            this.xEditGridCell184.Col = -1;
            this.xEditGridCell184.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell184, "xEditGridCell184");
            this.xEditGridCell184.IsVisible = false;
            this.xEditGridCell184.Row = -1;
            // 
            // xEditGridCell189
            // 
            this.xEditGridCell189.CellName = "sanjung_gubun";
            this.xEditGridCell189.Col = -1;
            this.xEditGridCell189.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell189, "xEditGridCell189");
            this.xEditGridCell189.IsVisible = false;
            this.xEditGridCell189.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.BindControl = this.dbxSanjung_Name;
            this.xEditGridCell67.CellName = "sanjung_gubun_name";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "gongbi_code1";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell193
            // 
            this.xEditGridCell193.CellName = "gongbi_code2";
            this.xEditGridCell193.Col = -1;
            this.xEditGridCell193.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell193, "xEditGridCell193");
            this.xEditGridCell193.IsVisible = false;
            this.xEditGridCell193.Row = -1;
            // 
            // xEditGridCell194
            // 
            this.xEditGridCell194.CellName = "gongbi_code3";
            this.xEditGridCell194.Col = -1;
            this.xEditGridCell194.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell194, "xEditGridCell194");
            this.xEditGridCell194.IsVisible = false;
            this.xEditGridCell194.Row = -1;
            // 
            // xEditGridCell195
            // 
            this.xEditGridCell195.CellName = "gongbi_code4";
            this.xEditGridCell195.Col = -1;
            this.xEditGridCell195.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell195, "xEditGridCell195");
            this.xEditGridCell195.IsVisible = false;
            this.xEditGridCell195.Row = -1;
            // 
            // xEditGridCell216
            // 
            this.xEditGridCell216.BindControl = this.dbxGongbi_Name1;
            this.xEditGridCell216.CellName = "gongbi_code1_name";
            this.xEditGridCell216.Col = -1;
            this.xEditGridCell216.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell216, "xEditGridCell216");
            this.xEditGridCell216.IsVisible = false;
            this.xEditGridCell216.Row = -1;
            // 
            // xEditGridCell217
            // 
            this.xEditGridCell217.BindControl = this.dbxGongbi_Name2;
            this.xEditGridCell217.CellName = "gongbi_code2_name";
            this.xEditGridCell217.Col = -1;
            this.xEditGridCell217.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell217, "xEditGridCell217");
            this.xEditGridCell217.IsVisible = false;
            this.xEditGridCell217.Row = -1;
            // 
            // xEditGridCell218
            // 
            this.xEditGridCell218.BindControl = this.dbxGongbi_Name3;
            this.xEditGridCell218.CellName = "gongbi_code3_name";
            this.xEditGridCell218.Col = -1;
            this.xEditGridCell218.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell218, "xEditGridCell218");
            this.xEditGridCell218.IsVisible = false;
            this.xEditGridCell218.Row = -1;
            // 
            // xEditGridCell219
            // 
            this.xEditGridCell219.BindControl = this.dbxGongbi_Name4;
            this.xEditGridCell219.CellName = "gongbi_code4_name";
            this.xEditGridCell219.Col = -1;
            this.xEditGridCell219.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell219, "xEditGridCell219");
            this.xEditGridCell219.IsVisible = false;
            this.xEditGridCell219.Row = -1;
            // 
            // xEditGridCell200
            // 
            this.xEditGridCell200.CellName = "sunab_yn";
            this.xEditGridCell200.Col = -1;
            this.xEditGridCell200.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell200, "xEditGridCell200");
            this.xEditGridCell200.IsVisible = false;
            this.xEditGridCell200.Row = -1;
            // 
            // xEditGridCell204
            // 
            this.xEditGridCell204.CellName = "if_valid_yn";
            this.xEditGridCell204.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell204.Col = -1;
            this.xEditGridCell204.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell204, "xEditGridCell204");
            this.xEditGridCell204.IsVisible = false;
            this.xEditGridCell204.Row = -1;
            // 
            // xEditGridCell224
            // 
            this.xEditGridCell224.CellName = "naewon_type";
            this.xEditGridCell224.Col = -1;
            this.xEditGridCell224.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell224, "xEditGridCell224");
            this.xEditGridCell224.IsVisible = false;
            this.xEditGridCell224.Row = -1;
            // 
            // xEditGridCell225
            // 
            this.xEditGridCell225.CellName = "jubsu_no";
            this.xEditGridCell225.Col = -1;
            this.xEditGridCell225.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell225, "xEditGridCell225");
            this.xEditGridCell225.IsVisible = false;
            this.xEditGridCell225.Row = -1;
            // 
            // xEditGridCell255
            // 
            this.xEditGridCell255.CellName = "pkout1001";
            this.xEditGridCell255.Col = -1;
            this.xEditGridCell255.ExecuteQuery = null;
            this.xEditGridCell255.IsVisible = false;
            this.xEditGridCell255.Row = -1;
            // 
            // grdInpList
            // 
            this.grdInpList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell101,
            this.xEditGridCell126,
            this.xEditGridCell142,
            this.xEditGridCell104,
            this.xEditGridCell201,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell129,
            this.xEditGridCell130,
            this.xEditGridCell37,
            this.xEditGridCell59,
            this.xEditGridCell209,
            this.xEditGridCell38,
            this.xEditGridCell60,
            this.xEditGridCell42,
            this.xEditGridCell76,
            this.xEditGridCell187,
            this.xEditGridCell185,
            this.xEditGridCell186,
            this.xEditGridCell196,
            this.xEditGridCell197,
            this.xEditGridCell198,
            this.xEditGridCell199,
            this.xEditGridCell220,
            this.xEditGridCell221,
            this.xEditGridCell222,
            this.xEditGridCell223,
            this.xEditGridCell84,
            this.xEditGridCell191,
            this.xEditGridCell188,
            this.xEditGridCell190,
            this.xEditGridCell203,
            this.xEditGridCell182});
            this.grdInpList.ColPerLine = 8;
            this.grdInpList.Cols = 9;
            this.grdInpList.ControlBinding = true;
            resources.ApplyResources(this.grdInpList, "grdInpList");
            this.grdInpList.ExecuteQuery = null;
            this.grdInpList.FixedCols = 1;
            this.grdInpList.FixedRows = 1;
            this.grdInpList.HeaderHeights.Add(28);
            this.grdInpList.Name = "grdInpList";
            this.grdInpList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdInpList.ParamList")));
            this.grdInpList.ReadOnly = true;
            this.grdInpList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdInpList.RowHeaderVisible = true;
            this.grdInpList.Rows = 2;
            this.grdInpList.RowStateCheckOnPaint = false;
            this.grdInpList.ToolTipActive = true;
            this.grdInpList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdList_MouseDown);
            this.grdInpList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
            this.grdInpList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "pk1001";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "bunho";
            this.xEditGridCell126.Col = 2;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "suname";
            this.xEditGridCell142.CellWidth = 100;
            this.xEditGridCell142.Col = 3;
            this.xEditGridCell142.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ipwon_date";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell104.CellWidth = 95;
            this.xEditGridCell104.Col = 6;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsJapanYearType = true;
            // 
            // xEditGridCell201
            // 
            this.xEditGridCell201.CellName = "ipwon_time";
            this.xEditGridCell201.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell201.CellWidth = 55;
            this.xEditGridCell201.Col = 7;
            this.xEditGridCell201.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell201, "xEditGridCell201");
            this.xEditGridCell201.Mask = "HH:MI";
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "gwa";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "doctor";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.BindControl = this.dbxGwa_name;
            this.xEditGridCell129.CellName = "gwa_name";
            this.xEditGridCell129.CellWidth = 70;
            this.xEditGridCell129.Col = 4;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.BindControl = this.dbxDoctor;
            this.xEditGridCell130.CellName = "doctor_name";
            this.xEditGridCell130.Col = 5;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.BindControl = this.fbxHoken;
            this.xEditGridCell37.CellName = "gubun";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.BindControl = this.dbxHoken_Name;
            this.xEditGridCell59.CellName = "gubun_name";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell209
            // 
            this.xEditGridCell209.BindControl = this.txtGongbi_yn;
            this.xEditGridCell209.CellName = "gongbi_yn";
            this.xEditGridCell209.Col = -1;
            this.xEditGridCell209.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell209, "xEditGridCell209");
            this.xEditGridCell209.IsVisible = false;
            this.xEditGridCell209.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "chojae";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.BindControl = this.dbxChojae_Name;
            this.xEditGridCell60.CellName = "chojae_name";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "pkinp1002";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "acting_date";
            this.xEditGridCell76.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell76.CellWidth = 95;
            this.xEditGridCell76.Col = 8;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsJapanYearType = true;
            // 
            // xEditGridCell187
            // 
            this.xEditGridCell187.CellName = "order_date";
            this.xEditGridCell187.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell187.Col = -1;
            this.xEditGridCell187.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell187, "xEditGridCell187");
            this.xEditGridCell187.IsVisible = false;
            this.xEditGridCell187.Row = -1;
            // 
            // xEditGridCell185
            // 
            this.xEditGridCell185.CellName = "gubun_old";
            this.xEditGridCell185.Col = -1;
            this.xEditGridCell185.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell185, "xEditGridCell185");
            this.xEditGridCell185.IsVisible = false;
            this.xEditGridCell185.Row = -1;
            // 
            // xEditGridCell186
            // 
            this.xEditGridCell186.CellName = "chojae_old";
            this.xEditGridCell186.Col = -1;
            this.xEditGridCell186.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell186, "xEditGridCell186");
            this.xEditGridCell186.IsVisible = false;
            this.xEditGridCell186.Row = -1;
            // 
            // xEditGridCell196
            // 
            this.xEditGridCell196.CellName = "gongbi_code1";
            this.xEditGridCell196.Col = -1;
            this.xEditGridCell196.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell196, "xEditGridCell196");
            this.xEditGridCell196.IsVisible = false;
            this.xEditGridCell196.Row = -1;
            // 
            // xEditGridCell197
            // 
            this.xEditGridCell197.CellName = "gongbi_code2";
            this.xEditGridCell197.Col = -1;
            this.xEditGridCell197.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell197, "xEditGridCell197");
            this.xEditGridCell197.IsVisible = false;
            this.xEditGridCell197.Row = -1;
            // 
            // xEditGridCell198
            // 
            this.xEditGridCell198.CellName = "gongbi_code3";
            this.xEditGridCell198.Col = -1;
            this.xEditGridCell198.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell198, "xEditGridCell198");
            this.xEditGridCell198.IsVisible = false;
            this.xEditGridCell198.Row = -1;
            // 
            // xEditGridCell199
            // 
            this.xEditGridCell199.CellName = "gongbi_code4";
            this.xEditGridCell199.Col = -1;
            this.xEditGridCell199.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell199, "xEditGridCell199");
            this.xEditGridCell199.IsVisible = false;
            this.xEditGridCell199.Row = -1;
            // 
            // xEditGridCell220
            // 
            this.xEditGridCell220.CellName = "gongbi_code1_name";
            this.xEditGridCell220.Col = -1;
            this.xEditGridCell220.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell220, "xEditGridCell220");
            this.xEditGridCell220.IsVisible = false;
            this.xEditGridCell220.Row = -1;
            // 
            // xEditGridCell221
            // 
            this.xEditGridCell221.CellName = "gongbi_code2_name";
            this.xEditGridCell221.Col = -1;
            this.xEditGridCell221.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell221, "xEditGridCell221");
            this.xEditGridCell221.IsVisible = false;
            this.xEditGridCell221.Row = -1;
            // 
            // xEditGridCell222
            // 
            this.xEditGridCell222.CellName = "gongbi_code3_name";
            this.xEditGridCell222.Col = -1;
            this.xEditGridCell222.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell222, "xEditGridCell222");
            this.xEditGridCell222.IsVisible = false;
            this.xEditGridCell222.Row = -1;
            // 
            // xEditGridCell223
            // 
            this.xEditGridCell223.CellName = "gongbi_code4_name";
            this.xEditGridCell223.Col = -1;
            this.xEditGridCell223.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell223, "xEditGridCell223");
            this.xEditGridCell223.IsVisible = false;
            this.xEditGridCell223.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "pkout";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell191
            // 
            this.xEditGridCell191.CellName = "send_date";
            this.xEditGridCell191.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell191.Col = -1;
            this.xEditGridCell191.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell191, "xEditGridCell191");
            this.xEditGridCell191.IsVisible = false;
            this.xEditGridCell191.Row = -1;
            // 
            // xEditGridCell188
            // 
            this.xEditGridCell188.CellName = "sanjung_gubun";
            this.xEditGridCell188.Col = -1;
            this.xEditGridCell188.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell188, "xEditGridCell188");
            this.xEditGridCell188.IsReadOnly = true;
            this.xEditGridCell188.IsVisible = false;
            this.xEditGridCell188.Row = -1;
            // 
            // xEditGridCell190
            // 
            this.xEditGridCell190.BindControl = this.dbxSanjung_Name;
            this.xEditGridCell190.CellName = "sanjung_gubun_name";
            this.xEditGridCell190.Col = -1;
            this.xEditGridCell190.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell190, "xEditGridCell190");
            this.xEditGridCell190.IsVisible = false;
            this.xEditGridCell190.Row = -1;
            // 
            // xEditGridCell203
            // 
            this.xEditGridCell203.CellName = "if_valid_yn";
            this.xEditGridCell203.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell203.Col = -1;
            this.xEditGridCell203.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell203, "xEditGridCell203");
            this.xEditGridCell203.IsVisible = false;
            this.xEditGridCell203.Row = -1;
            // 
            // xEditGridCell182
            // 
            this.xEditGridCell182.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell182.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell182.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell182.AlterateRowImageIndex = 0;
            this.xEditGridCell182.CellName = "select";
            this.xEditGridCell182.CellWidth = 30;
            this.xEditGridCell182.Col = 1;
            this.xEditGridCell182.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell182, "xEditGridCell182");
            this.xEditGridCell182.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell182.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell182.RowImageIndex = 0;
            this.xEditGridCell182.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // tabDataGubun
            // 
            resources.ApplyResources(this.tabDataGubun, "tabDataGubun");
            this.tabDataGubun.IDEPixelArea = true;
            this.tabDataGubun.IDEPixelBorder = false;
            this.tabDataGubun.Name = "tabDataGubun";
            this.tabDataGubun.ShowArrows = false;
            this.tabDataGubun.ShowClose = false;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.rbnTrans);
            this.xPanel4.Controls.Add(this.rbnMiTrans);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // rbnTrans
            // 
            resources.ApplyResources(this.rbnTrans, "rbnTrans");
            this.rbnTrans.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnTrans.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnTrans.ImageList = this.ImageList;
            this.rbnTrans.Name = "rbnTrans";
            this.rbnTrans.UseVisualStyleBackColor = false;
            this.rbnTrans.CheckedChanged += new System.EventHandler(this.RadioTrans_CheckedChanged);
            // 
            // rbnMiTrans
            // 
            resources.ApplyResources(this.rbnMiTrans, "rbnMiTrans");
            this.rbnMiTrans.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbnMiTrans.Checked = true;
            this.rbnMiTrans.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbnMiTrans.ImageList = this.ImageList;
            this.rbnMiTrans.Name = "rbnMiTrans";
            this.rbnMiTrans.TabStop = true;
            this.rbnMiTrans.UseVisualStyleBackColor = false;
            this.rbnMiTrans.CheckedChanged += new System.EventHandler(this.RadioTrans_CheckedChanged);
            // 
            // xPanel7
            // 
            this.xPanel7.Controls.Add(this.rbnInData);
            this.xPanel7.Controls.Add(this.rbnOutData);
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.Name = "xPanel7";
            // 
            // rbnInData
            // 
            resources.ApplyResources(this.rbnInData, "rbnInData");
            this.rbnInData.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnInData.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnInData.ImageList = this.ImageList;
            this.rbnInData.Name = "rbnInData";
            this.rbnInData.Tag = "I";
            this.rbnInData.UseVisualStyleBackColor = false;
            this.rbnInData.CheckedChanged += new System.EventHandler(this.rbnDataGubun_CheckedChanged);
            // 
            // rbnOutData
            // 
            resources.ApplyResources(this.rbnOutData, "rbnOutData");
            this.rbnOutData.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbnOutData.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbnOutData.ImageList = this.ImageList;
            this.rbnOutData.Name = "rbnOutData";
            this.rbnOutData.TabStop = true;
            this.rbnOutData.Tag = "O";
            this.rbnOutData.UseVisualStyleBackColor = false;
            this.rbnOutData.CheckedChanged += new System.EventHandler(this.rbnDataGubun_CheckedChanged);
            // 
            // xPanel11
            // 
            this.xPanel11.Controls.Add(this.btnHelp);
            this.xPanel11.Controls.Add(this.pnlSang);
            this.xPanel11.Controls.Add(this.cboSangCode);
            this.xPanel11.Controls.Add(this.xLabel9);
            resources.ApplyResources(this.xPanel11, "xPanel11");
            this.xPanel11.DrawBorder = true;
            this.xPanel11.Name = "xPanel11";
            // 
            // btnHelp
            // 
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.ImageIndex = 15;
            this.btnHelp.ImageList = this.ImageList;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // pnlSang
            // 
            this.pnlSang.Controls.Add(this.grdOutSang);
            resources.ApplyResources(this.pnlSang, "pnlSang");
            this.pnlSang.Name = "pnlSang";
            // 
            // grdOutSang
            // 
            this.grdOutSang.AddedHeaderLine = 1;
            this.grdOutSang.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell131,
            this.xEditGridCell132,
            this.xEditGridCell138,
            this.xEditGridCell139,
            this.xEditGridCell141,
            this.xEditGridCell143,
            this.xEditGridCell144,
            this.xEditGridCell145,
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
            this.xEditGridCell171,
            this.xEditGridCell172,
            this.xEditGridCell173,
            this.xEditGridCell174,
            this.xEditGridCell175,
            this.xEditGridCell176,
            this.xEditGridCell177,
            this.xEditGridCell178,
            this.xEditGridCell179,
            this.xEditGridCell180});
            this.grdOutSang.ColPerLine = 8;
            this.grdOutSang.Cols = 8;
            resources.ApplyResources(this.grdOutSang, "grdOutSang");
            this.grdOutSang.ExecuteQuery = null;
            this.grdOutSang.FixedRows = 2;
            this.grdOutSang.HeaderHeights.Add(21);
            this.grdOutSang.HeaderHeights.Add(0);
            this.grdOutSang.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader6});
            this.grdOutSang.Name = "grdOutSang";
            this.grdOutSang.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOutSang.ParamList")));
            this.grdOutSang.QuerySQL = "    SELECT A.BUNHO             ";
            this.grdOutSang.Rows = 3;
            this.grdOutSang.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOutSang_QueryStarting);
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "bunho";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "gwa";
            this.xEditGridCell132.CellWidth = 100;
            this.xEditGridCell132.Col = 3;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsReadOnly = true;
            this.xEditGridCell132.Row = 1;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "gwa_name";
            this.xEditGridCell138.CellWidth = 100;
            this.xEditGridCell138.Col = 4;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsReadOnly = true;
            this.xEditGridCell138.Row = 1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "io_gubun";
            this.xEditGridCell139.Col = -1;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.IsVisible = false;
            this.xEditGridCell139.Row = -1;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "pk_seq";
            this.xEditGridCell141.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell141.Col = -1;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsVisible = false;
            this.xEditGridCell141.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "ser";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellLen = 7;
            this.xEditGridCell144.CellName = "sang_code";
            this.xEditGridCell144.CellWidth = 100;
            this.xEditGridCell144.Col = 1;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsReadOnly = true;
            this.xEditGridCell144.RowSpan = 2;
            this.xEditGridCell144.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellLen = 200;
            this.xEditGridCell145.CellName = "dis_sang_name";
            this.xEditGridCell145.CellWidth = 400;
            this.xEditGridCell145.Col = 2;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsReadOnly = true;
            this.xEditGridCell145.RowSpan = 2;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellLen = 200;
            this.xEditGridCell150.CellName = "sang_name";
            this.xEditGridCell150.Col = -1;
            this.xEditGridCell150.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell150, "xEditGridCell150");
            this.xEditGridCell150.IsVisible = false;
            this.xEditGridCell150.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellLen = 4;
            this.xEditGridCell151.CellName = "pre_modifier1";
            this.xEditGridCell151.Col = -1;
            this.xEditGridCell151.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell151, "xEditGridCell151");
            this.xEditGridCell151.IsVisible = false;
            this.xEditGridCell151.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellLen = 4;
            this.xEditGridCell152.CellName = "pre_modifier2";
            this.xEditGridCell152.Col = -1;
            this.xEditGridCell152.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell152, "xEditGridCell152");
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellLen = 4;
            this.xEditGridCell153.CellName = "pre_modifier3";
            this.xEditGridCell153.Col = -1;
            this.xEditGridCell153.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell153, "xEditGridCell153");
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellLen = 4;
            this.xEditGridCell154.CellName = "pre_modifier4";
            this.xEditGridCell154.Col = -1;
            this.xEditGridCell154.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell154, "xEditGridCell154");
            this.xEditGridCell154.IsVisible = false;
            this.xEditGridCell154.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellLen = 4;
            this.xEditGridCell155.CellName = "pre_modifier5";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell155, "xEditGridCell155");
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellLen = 4;
            this.xEditGridCell156.CellName = "pre_modifier6";
            this.xEditGridCell156.Col = -1;
            this.xEditGridCell156.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell156, "xEditGridCell156");
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellLen = 4;
            this.xEditGridCell157.CellName = "pre_modifier7";
            this.xEditGridCell157.Col = -1;
            this.xEditGridCell157.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell157, "xEditGridCell157");
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellLen = 4;
            this.xEditGridCell158.CellName = "pre_modifier8";
            this.xEditGridCell158.Col = -1;
            this.xEditGridCell158.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell158, "xEditGridCell158");
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellLen = 4;
            this.xEditGridCell159.CellName = "pre_modifier9";
            this.xEditGridCell159.Col = -1;
            this.xEditGridCell159.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell159, "xEditGridCell159");
            this.xEditGridCell159.IsVisible = false;
            this.xEditGridCell159.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellLen = 4;
            this.xEditGridCell160.CellName = "pre_modifier10";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell160, "xEditGridCell160");
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellLen = 500;
            this.xEditGridCell161.CellName = "pre_modifier_name";
            this.xEditGridCell161.Col = -1;
            this.xEditGridCell161.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell161, "xEditGridCell161");
            this.xEditGridCell161.IsVisible = false;
            this.xEditGridCell161.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellLen = 4;
            this.xEditGridCell162.CellName = "post_modifier1";
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell162, "xEditGridCell162");
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellLen = 4;
            this.xEditGridCell163.CellName = "post_modifier2";
            this.xEditGridCell163.Col = -1;
            this.xEditGridCell163.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell163, "xEditGridCell163");
            this.xEditGridCell163.IsVisible = false;
            this.xEditGridCell163.Row = -1;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellLen = 4;
            this.xEditGridCell164.CellName = "post_modifier3";
            this.xEditGridCell164.Col = -1;
            this.xEditGridCell164.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell164, "xEditGridCell164");
            this.xEditGridCell164.IsVisible = false;
            this.xEditGridCell164.Row = -1;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.CellLen = 4;
            this.xEditGridCell165.CellName = "post_modifier4";
            this.xEditGridCell165.Col = -1;
            this.xEditGridCell165.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell165, "xEditGridCell165");
            this.xEditGridCell165.IsVisible = false;
            this.xEditGridCell165.Row = -1;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellLen = 4;
            this.xEditGridCell166.CellName = "post_modifier5";
            this.xEditGridCell166.Col = -1;
            this.xEditGridCell166.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell166, "xEditGridCell166");
            this.xEditGridCell166.IsVisible = false;
            this.xEditGridCell166.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellLen = 4;
            this.xEditGridCell167.CellName = "post_modifier6";
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell167, "xEditGridCell167");
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellLen = 4;
            this.xEditGridCell168.CellName = "post_modifier7";
            this.xEditGridCell168.Col = -1;
            this.xEditGridCell168.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell168, "xEditGridCell168");
            this.xEditGridCell168.IsVisible = false;
            this.xEditGridCell168.Row = -1;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellLen = 4;
            this.xEditGridCell169.CellName = "post_modifier8";
            this.xEditGridCell169.Col = -1;
            this.xEditGridCell169.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell169, "xEditGridCell169");
            this.xEditGridCell169.IsVisible = false;
            this.xEditGridCell169.Row = -1;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellLen = 4;
            this.xEditGridCell171.CellName = "post_modifier9";
            this.xEditGridCell171.Col = -1;
            this.xEditGridCell171.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell171, "xEditGridCell171");
            this.xEditGridCell171.IsVisible = false;
            this.xEditGridCell171.Row = -1;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellLen = 4;
            this.xEditGridCell172.CellName = "post_modifier10";
            this.xEditGridCell172.Col = -1;
            this.xEditGridCell172.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell172, "xEditGridCell172");
            this.xEditGridCell172.IsVisible = false;
            this.xEditGridCell172.Row = -1;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.CellLen = 500;
            this.xEditGridCell173.CellName = "post_modifier_name";
            this.xEditGridCell173.Col = -1;
            this.xEditGridCell173.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell173, "xEditGridCell173");
            this.xEditGridCell173.IsVisible = false;
            this.xEditGridCell173.Row = -1;
            // 
            // xEditGridCell174
            // 
            this.xEditGridCell174.CellName = "sang_start_date";
            this.xEditGridCell174.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell174.CellWidth = 100;
            this.xEditGridCell174.Col = 5;
            this.xEditGridCell174.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell174, "xEditGridCell174");
            this.xEditGridCell174.IsJapanYearType = true;
            this.xEditGridCell174.IsReadOnly = true;
            this.xEditGridCell174.RowSpan = 2;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellName = "sang_start_date_jp";
            this.xEditGridCell175.Col = -1;
            this.xEditGridCell175.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell175, "xEditGridCell175");
            this.xEditGridCell175.IsVisible = false;
            this.xEditGridCell175.Row = -1;
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.CellName = "sang_end_date";
            this.xEditGridCell176.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell176.CellWidth = 100;
            this.xEditGridCell176.Col = 6;
            this.xEditGridCell176.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell176, "xEditGridCell176");
            this.xEditGridCell176.IsJapanYearType = true;
            this.xEditGridCell176.IsReadOnly = true;
            this.xEditGridCell176.RowSpan = 2;
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellName = "sang_end_date_jp";
            this.xEditGridCell177.Col = -1;
            this.xEditGridCell177.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell177, "xEditGridCell177");
            this.xEditGridCell177.IsVisible = false;
            this.xEditGridCell177.Row = -1;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellName = "sang_end_sayu";
            this.xEditGridCell178.CellWidth = 100;
            this.xEditGridCell178.Col = -1;
            this.xEditGridCell178.ExecuteQuery = null;
            this.xEditGridCell178.IsVisible = false;
            this.xEditGridCell178.Row = -1;
            // 
            // xEditGridCell179
            // 
            this.xEditGridCell179.CellName = "sang_end_sayu_name";
            this.xEditGridCell179.Col = 7;
            this.xEditGridCell179.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell179, "xEditGridCell179");
            this.xEditGridCell179.IsReadOnly = true;
            this.xEditGridCell179.RowSpan = 2;
            this.xEditGridCell179.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellName = "ju_sang_yn";
            this.xEditGridCell180.CellWidth = 30;
            this.xEditGridCell180.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell180.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell180, "xEditGridCell180");
            this.xEditGridCell180.IsReadOnly = true;
            this.xEditGridCell180.RowSpan = 2;
            // 
            // xGridHeader6
            // 
            this.xGridHeader6.Col = 3;
            this.xGridHeader6.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader6, "xGridHeader6");
            // 
            // cboSangCode
            // 
            resources.ApplyResources(this.cboSangCode, "cboSangCode");
            this.cboSangCode.DropDownWidth = 956;
            this.cboSangCode.Name = "cboSangCode";
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Name = "xLabel9";
            // 
            // fwkGongbi
            // 
            this.fwkGongbi.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4,
            this.findColumnInfo5,
            this.findColumnInfo6,
            this.findColumnInfo7});
            this.fwkGongbi.ExecuteQuery = null;
            this.fwkGongbi.FormText = "公費情報照会";
            this.fwkGongbi.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkGongbi.ParamList")));
            this.fwkGongbi.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkGongbi.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "gubun";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "gubun_name";
            this.findColumnInfo4.ColWidth = 150;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "last_check_date";
            this.findColumnInfo5.ColWidth = 0;
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            this.findColumnInfo5.IsVisible = false;
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "budamja";
            this.findColumnInfo6.ColWidth = 0;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            this.findColumnInfo6.IsVisible = false;
            // 
            // findColumnInfo7
            // 
            this.findColumnInfo7.ColName = "sugubja";
            this.findColumnInfo7.ColWidth = 0;
            resources.ApplyResources(this.findColumnInfo7, "findColumnInfo7");
            this.findColumnInfo7.IsVisible = false;
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resources.BUTTON_DO, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layOrderInfo
            // 
            this.layOrderInfo.ExecuteQuery = null;
            this.layOrderInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderInfo.ParamList")));
            // 
            // pnlProgressBar
            // 
            resources.ApplyResources(this.pnlProgressBar, "pnlProgressBar");
            this.pnlProgressBar.Controls.Add(this.lbTransCnt);
            this.pnlProgressBar.Controls.Add(this.lbTransHangmog);
            this.pnlProgressBar.Controls.Add(this.pgbProgress);
            this.pnlProgressBar.Name = "pnlProgressBar";
            // 
            // lbTransCnt
            // 
            this.lbTransCnt.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lbTransCnt, "lbTransCnt");
            this.lbTransCnt.Name = "lbTransCnt";
            // 
            // lbTransHangmog
            // 
            this.lbTransHangmog.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lbTransHangmog, "lbTransHangmog");
            this.lbTransHangmog.Name = "lbTransHangmog";
            // 
            // pgbProgress
            // 
            resources.ApplyResources(this.pgbProgress, "pgbProgress");
            this.pgbProgress.Name = "pgbProgress";
            // 
            // layOut0101
            // 
            this.layOut0101.ExecuteQuery = null;
            this.layOut0101.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layOut0101.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOut0101.ParamList")));
            this.layOut0101.QuerySQL = "SELECT A.SUNAME";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // btnCompar
            // 
            resources.ApplyResources(this.btnCompar, "btnCompar");
            this.btnCompar.ImageIndex = 12;
            this.btnCompar.ImageList = this.ImageList;
            this.btnCompar.Name = "btnCompar";
            this.btnCompar.Click += new System.EventHandler(this.btnCompar_Click);
            // 
            // btnSend
            // 
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.ImageIndex = 13;
            this.btnSend.ImageList = this.ImageList;
            this.btnSend.Name = "btnSend";
            this.btnSend.Click += new System.EventHandler(this.btnReSend_Click);
            // 
            // btnSiksaTest
            // 
            resources.ApplyResources(this.btnSiksaTest, "btnSiksaTest");
            this.btnSiksaTest.Name = "btnSiksaTest";
            this.btnSiksaTest.Click += new System.EventHandler(this.btnSiksaTest_Click);
            // 
            // dtpFromdate
            // 
            resources.ApplyResources(this.dtpFromdate, "dtpFromdate");
            this.dtpFromdate.IsVietnameseYearType = false;
            this.dtpFromdate.Name = "dtpFromdate";
            // 
            // dtpTodate
            // 
            resources.ApplyResources(this.dtpTodate, "dtpTodate");
            this.dtpTodate.IsVietnameseYearType = false;
            this.dtpTodate.Name = "dtpTodate";
            // 
            // cboTosik
            // 
            resources.ApplyResources(this.cboTosik, "cboTosik");
            this.cboTosik.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem4});
            this.cboTosik.Name = "cboTosik";
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "0";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "2";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "3";
            // 
            // cboFromsik
            // 
            resources.ApplyResources(this.cboFromsik, "cboFromsik");
            this.cboFromsik.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7,
            this.xComboItem8});
            this.cboFromsik.Name = "cboFromsik";
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "0";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "1";
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "2";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "3";
            // 
            // btnForcedEnd
            // 
            resources.ApplyResources(this.btnForcedEnd, "btnForcedEnd");
            this.btnForcedEnd.ImageIndex = 2;
            this.btnForcedEnd.ImageList = this.ImageList;
            this.btnForcedEnd.Name = "btnForcedEnd";
            this.btnForcedEnd.Click += new System.EventHandler(this.btnForcedEnd_Click);
            // 
            // btnSangSendAll
            // 
            resources.ApplyResources(this.btnSangSendAll, "btnSangSendAll");
            this.btnSangSendAll.Name = "btnSangSendAll";
            this.btnSangSendAll.Click += new System.EventHandler(this.btnSangSendAll_Click);
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4});
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.dbxHoken_Name;
            this.singleLayoutItem2.DataName = "gubun_name";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "if_valid_yn";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "gongbi_yn";
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellLen = 4;
            this.xEditGridCell170.CellName = "post_modifier8";
            this.xEditGridCell170.Col = -1;
            this.xEditGridCell170.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell170, "xEditGridCell170");
            this.xEditGridCell170.IsVisible = false;
            this.xEditGridCell170.Row = -1;
            // 
            // layRequisInfo
            // 
            this.layRequisInfo.ExecuteQuery = null;
            this.layRequisInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layRequisInfo.ParamList")));
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ExecuteQuery = null;
            // 
            // xEditGridCell206
            // 
            this.xEditGridCell206.CellName = "if_valid_yn";
            this.xEditGridCell206.Col = -1;
            this.xEditGridCell206.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell206, "xEditGridCell206");
            this.xEditGridCell206.IsVisible = false;
            this.xEditGridCell206.Row = -1;
            // 
            // ORDERTRANS
            // 
            this.Controls.Add(this.btnSangSendAll);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnForcedEnd);
            this.Controls.Add(this.cboFromsik);
            this.Controls.Add(this.cboTosik);
            this.Controls.Add(this.dtpTodate);
            this.Controls.Add(this.dtpFromdate);
            this.Controls.Add(this.btnSiksaTest);
            this.Controls.Add(this.txtGongbi_yn);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCompar);
            this.Controls.Add(this.pnlProgressBar);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            resources.ApplyResources(this, "$this");
            this.Name = "ORDERTRANS";
            this.Load += new System.EventHandler(this.ORDERTRANS_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.ORDERTRANS_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlHelp.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2004)).EndInit();
            this.pnlWoichul.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWoichul)).EndInit();
            this.pnlSiksa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSiksa)).EndInit();
            this.pnlJungwa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdJungwa)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel9.ResumeLayout(false);
            this.pnlHoken.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHoken)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlBunho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGongbi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).EndInit();
            this.xPanel10.ResumeLayout(false);
            this.xPanel10.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOutList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInpList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            this.xPanel11.ResumeLayout(false);
            this.pnlSang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOutSang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderInfo)).EndInit();
            this.pnlProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layRequisInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
        #endregion

        #endregion

        #region Constant

        private const int MAX_DISEASE_ITEM = 50;
        private const int MAX_ORDER_ITEM = 20;
        private const string DEFAULT_CLAIM_CLS_CODE = "999";
        private const string DEFAULT_CLAIM_INS_CODE = "XX";
        // https://sofiamedix.atlassian.net/browse/MED-6360
        // changed default insurance code from 999999 to 9999
        // private const string DEFAULT_CLAIM_INS_NUMBER = "999999";
        private const string DEFAULT_CLAIM_INS_NUMBER = "9999";

        #endregion

        #region Fields

    // 라디오 버튼 컬러
        private XColor mSelectedBackColor   = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor   = new XColor(Color.FromName("ActiveCaptionText"));
        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        // 파라미터
        //private string mBunho      = "";
        //private string mNaewonDate = "";
        private string mIOGubun = "";

        // 오더 상태에 따른 색 변화
        // 결과 입력 완료
        private XColor mResultForeColor  = new XColor(Color.DeepPink);
        private XColor mResultBackColor  = new XColor(Color.SkyBlue);
        // 액팅완료
        private XColor mActingBackColor  = new XColor(Color.SkyBlue);
        private XColor mActingForeColor  = new XColor(Color.Blue);
        // 예약완료
        private XColor mReserForeColor   = new XColor(Color.Green);

        private string mMsg = "";
        private string mCap = "";
        private string mSend_YN = "N";

        // 커런트 그리드
        private XEditGrid mCurrentGrid = null;
        // 커런트 리스트 그리드
        private XEditGrid mCurrentListGrid = null;

        // 그리드 선택 카운터 
        private int mActCount = 0;
        private int mMaxWidth = 1117;
        private int mMaxGongbi = 5;
        private string IF_VALID_YN = "";
        private bool hoken_valid_yn = false;
        private List<string> _sendList = new List<string>();

        #endregion

        #region Constructor
        /// <summary>
        /// ORDERTRANS
        /// </summary>
        public ORDERTRANS()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            //
             if (NetInfo.Language == IHIS.Framework.LangMode.Vi)
            {
                xEditGridCell75.IsJapanYearType = false;
				dtpGijunDate.IsJapanYearType = false;
                dtpJunsongDate.IsJapanYearType = false;
                xEditGridCell31.IsJapanYearType = false;
                xEditGridCell48.IsJapanYearType = false;
            }
            // updated by Cloud
            InitializeCloud();
        }
        #endregion

        #region Events

        private void ORDERTRANS_Load(object sender, System.EventArgs e)
        {
            if (this.Opener != null &&
                this.Opener is XScreen &&
                this.OpenParam != null)
            {
                if (this.OpenParam.Contains("io_gubun"))
                {
                    this.mIOGubun = this.OpenParam["io_gubun"].ToString();

                    if (this.mIOGubun == "")
                    {
                        this.mIOGubun = "O"; // 없으면 외래가 기본임.
                    }
                }
                if (this.OpenParam.Contains("naewon_date"))
                {
                    string naewon_date = this.OpenParam["naewon_date"].ToString();

                    if (naewon_date == "")
                    {
                        naewon_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
                    }
                    //this.dtpGijunDate.SetDataValue(naewon_date);
                }
                if (this.OpenParam.Contains("bunho"))
                {
                    string bunho = this.OpenParam["bunho"].ToString();

                    this.fbxBunho.SetDataValue(bunho);
                    //PostCallHelper.PostCall(new PostMethod(PostBunhoValidating));
                    //this.fbxBunho.AcceptData();
                }
            }
            else
            {
                if (EnvironInfo.CurrSystemID == "NURI" ||
                    EnvironInfo.CurrSystemID == "INPS" ||
                    EnvironInfo.CurrSystemID == "OCSI")
                {
                    this.mIOGubun = "I";
                }
                else
                {
                    this.mIOGubun = "O";
                }
            }
            this.InitScreen();
        }

        private void ORDERTRANS_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 
            int width = 0;
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            if (rc.Width - 30 > mMaxWidth)
                width = mMaxWidth;
            else
                width = rc.Width - 30;

            this.ParentForm.Size = new System.Drawing.Size(width, rc.Height - 105);



        }

        private void fbxBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.IF_VALID_YN = "";

            if (e.DataValue != "")
            {
                string bunho = e.DataValue;
                bunho = BizCodeHelper.GetStandardBunHo(bunho);
                fbxBunho.SetDataValue(bunho);
                PostCallHelper.PostCall(new PostMethod(PostBunhoValidating));


                //환자상병정보클리어
                this.grdOutSang.Reset();
                this.cboSangCode.ComboItems.Clear();
                this.cboSangCode.RefreshComboItems();

                //상병정보표시처리
                this.MakeSangCombo();
            }
            else
            {
                this.dbxSuname.SetDataValue("");
                ClearInputControl();

                //환자상병정보클리어
                this.grdOutSang.Reset();
                this.cboSangCode.ComboItems.Clear();
                this.cboSangCode.RefreshComboItems();

                //기준일자클리어
                this.dtpGijunDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            }
        }

        private void fbxBunho_FindClick(object sender, CancelEventArgs e)
        {
            this.OpenScreen_OUT0101Q01();
        }

        // 전송, 미전송 버튼클릭이벤트처리
        private void RadioTrans_CheckedChanged(object sender, System.EventArgs e)
        {
            XRadioButton button = sender as XRadioButton;
            string str = tabDataGubun.SelectedTab.Tag.ToString();

            if (button.Checked == true)
            {
                button.ImageIndex = 0;
                button.BackColor = this.mSelectedBackColor;
                button.ForeColor = this.mSelectedForeColor;
                // 미전송버튼클릭시 셋팅
                if (this.rbnMiTrans.Checked == true)
                {
                    this.mSend_YN = "N";
                    this.btnCompar.Visible = false;
                    this.btnSend.Visible = false;
                    this.btnForcedEnd.Visible = true;
                    //this.dtpJunsongDate.ReadOnly = false;
                    //this.lbSelectAll.Visible = false;//테스트
                    //        this.btnList.Container.Components.Count

                    this.btnList.FunctionItems.Add(FunctionType.Process, Shortcut.F12, Resources.BT_Tranfer, -1, "");
                    this.btnList.InitializeButtons();
                    this.btnList.Refresh();
                    this.lblHlep1.Text = Resources.lbUnexecute;
                }
                else
                {
                    this.mSend_YN = "Y";
                    this.btnSend.Visible = true;
                    this.btnForcedEnd.Visible = false;
                    //this.lbSelectAll.Visible = true;//테스트

                    if (str == "0")
                    {
                        this.btnCompar.Visible = false; //true;
                    }
                    //this.dtpJunsongDate.ReadOnly = true;

                    this.btnList.FunctionItems.Add(FunctionType.Process, Shortcut.F12, Resources.BT_Cancel, -1, "");
                    this.btnList.InitializeButtons();
                    this.btnList.Refresh();

                    this.lblHlep1.Text = Resources.lbNottranse;
                    //btnList.FunctionItems.
                }
                if (this.mIOGubun == "O")
                {
                    this.grdOutList.Visible = true;
                    this.grdInpList.Visible = false;
                    this.mCurrentListGrid = this.grdOutList;
                }
                else
                {
                    this.grdInpList.Visible = true;
                    this.grdOutList.Visible = false;
                    this.mCurrentListGrid = this.grdInpList;
                }
                this.ClearInputControl();
                this.btnList.PerformClick(FunctionType.Query);
            }
            else
            {
                button.ImageIndex = 1;
                button.BackColor = this.mUnSelectedBackColor;
                button.ForeColor = this.mUnSelectedForeColor;
            }
        }

        // 입원,외래 버튼클릭이벤트처리
        private void rbnDataGubun_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton button = sender as XRadioButton;

            if (button.Checked == true)
            {
                button.ImageIndex = 0;
                button.BackColor = this.mSelectedBackColor;
                button.ForeColor = this.mSelectedForeColor;

                // 디자이너에서 속성의 Tag 값 
                this.mIOGubun = button.Tag.ToString();

                if (this.mIOGubun == "O")
                {
                    this.grdOutList.Visible = true;
                    this.grdInpList.Visible = false;
                    this.mCurrentListGrid = this.grdOutList;
                }
                else
                {
                    this.grdInpList.Visible = true;
                    this.grdOutList.Visible = false;
                    this.mCurrentListGrid = this.grdInpList;
                }
                //탭페이지 생성
                this.MakeDataGubunTabPages();
                //환자정보 탭페이지 생성
                this.MakeDateInfoTabPages();
            }
            else
            {
                button.ImageIndex = 1;
                button.BackColor = this.mUnSelectedBackColor;
                button.ForeColor = this.mUnSelectedForeColor;
            }
        }

        private void tabDataGubun_SelectionChanged(object sender, EventArgs e)
        {
            bool val = false;
            IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;
            //전체선택라벨초기화
            this.InitializeAllSelectLabel();
            ////테이블 클리어
            //this.ClearOrderBack();

            foreach (IHIS.X.Magic.Controls.TabPage tpg in control.TabPages)
            {
                if (control.SelectedTab == tpg)
                {
                    switch (tpg.Tag.ToString())
                    {
                        case "0": // 오더 탭
                            this.pnlOrder.Visible = true;
                            this.pnlSiksa.Visible = false;
                            this.pnlWoichul.Visible = false;
                            this.pnlJungwa.Visible = false;
                            this.mCurrentGrid = this.grdOCS1003;
                            val = true;
                            break;
                        case "1": // 식사 탭
                            this.pnlSiksa.Visible = true;
                            this.pnlOrder.Visible = false;
                            this.pnlWoichul.Visible = false;
                            this.pnlJungwa.Visible = false;
                            this.mCurrentGrid = this.grdSiksa;
                            val = true;
                            break;
                        case "2": // 외출외박
                            this.pnlWoichul.Visible = true;
                            this.pnlOrder.Visible = false;
                            this.pnlSiksa.Visible = false;
                            this.pnlJungwa.Visible = false;
                            this.mCurrentGrid = this.grdWoichul;
                            val = true;
                            break;
                        case "3": //전과,전실
                            this.pnlJungwa.Visible = true;
                            this.pnlOrder.Visible = false;
                            this.pnlSiksa.Visible = false;
                            this.pnlWoichul.Visible = false;
                            this.mCurrentGrid = this.grdJungwa;
                            val = true;
                            break;
                        default:
                            break;
                    }
                    if (val == true)
                    {
                        // 레이아웃 셋팅
                        this.layOrderInfo = this.mCurrentGrid.CloneToLayout();
                        this.btnList.PerformClick(FunctionType.Query);
                    }

                    if ((tpg.Tag.ToString() == "0") && (this.mSend_YN == "Y"))
                    {
                        this.btnCompar.Visible = false; //true;
                    }
                    else
                    {
                        this.btnCompar.Visible = false;
                    }
                }
            }
        }

        private void tabDataInfo_SelectionChanged(object sender, EventArgs e)
        {
            IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;

            foreach (IHIS.X.Magic.Controls.TabPage tpg in control.TabPages)
            {
                if (control.SelectedTab == tpg)
                {
                    switch (tpg.Tag.ToString())
                    {
                        case "1": // 공비정보 탭
                            this.grdGongbi.Visible = true;
                            this.grdComment.Visible = false;
                            break;
                        case "2": // 환자특기사항 탭
                            this.grdComment.Visible = true;
                            this.grdGongbi.Visible = false;
                            break;
                    }
                }
            }
        }

        private void lbSelectAll_Click(object sender, System.EventArgs e)
        {
            XLabel control = sender as XLabel;

            int current = this.mCurrentListGrid.CurrentRowNumber;

            if ((current < 0) || (this.mCurrentListGrid.GetItemString(current, "select") != "Y"))
                return;

            if (control.Tag.ToString() == "Y")
            {
                control.Tag = "N";
                control.ImageIndex = 1;
            }
            else
            {
                control.Tag = "Y";
                control.ImageIndex = 0;
            }
            for (int i = 0; i < this.mCurrentGrid.RowCount; i++)
            {
                if (this.mCurrentGrid.GetItemString(i, "select") != "X")
                {
                    //this.ClickCurrentOrder(i);
                    if (control.Tag.ToString() == "Y")
                    {
                        this.mCurrentGrid.SetItemValue(i, "select", "N");
                        this.mCurrentGrid[i, "select"].Image = ImageList.Images[1];
                        this.AddOrderBackTable(i);
                    }
                    else
                    {
                        this.mCurrentGrid.SetItemValue(i, "select", "Y");
                        this.mCurrentGrid[i, "select"].Image = ImageList.Images[0];
                        this.DeleteOrderBackTable(i);
                    }
                }
            }
        }

        private bool CheckSelectBunho()
        {
             for (int i = 0 ; i < mCurrentListGrid.RowCount ; i ++)
             {
                 if (mCurrentListGrid.GetItemString(i, "select") == "Y")
                     return true;

             }
            return false;
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.GridListSelectionChanged();

                    // https://sofiamedix.atlassian.net/browse/MED-6785
                    //환자상병정보클리어
                    this.grdOutSang.Reset();
                    this.cboSangCode.ComboItems.Clear();
                    this.cboSangCode.RefreshComboItems();

                    //상병정보표시처리
                    this.MakeSangCombo();

                    break;
                case FunctionType.Process:
                    this.AcceptData();
                    e.IsBaseCall = false;
                    //this.btnList.Enabled = false;

                    // https://sofiamedix.atlassian.net/browse/MED-10487
                    if (!String.IsNullOrEmpty(UserInfo.MisaIp))
                    {
                        if (!rbnMiTrans.Checked) return;
                    }

                    if (!CheckSelectBunho())
                    {
                        XMessageBox.Show(Resources.MSG_NOTICE, Resources.MSG_NOTICE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    bool terminated = false;
                    bool process = false;
                    Service.WriteLog("OrcaIp: " + UserInfo.OrcaIp + "------MisaIp " + UserInfo.MisaIp);
                    if (!String.IsNullOrEmpty(UserInfo.OrcaIp))
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-13718
                        //process = ProcessTrans(out terminated);
                        if (rbnMiTrans.Checked)
                        {
                            this.DoTransfer(TransferType.Order);
                        }
                        else
                        {
                            // https://sofiamedix.atlassian.net/browse/MED-13998
                            if (!this.IsCancelOrder())
                            {
                                XMessageBox.Show(Resources.MSG_CANCEL_ORDER_ERR, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            this.DoTransfer(TransferType.Cancel);
                        }

                        btnList.PerformClick(FunctionType.Query);

                        return;
                    }
                    else if(!String.IsNullOrEmpty(UserInfo.MisaIp))
                    {
                        process = ProcessTransMisa(out terminated);
                    }

                    if (!terminated)
                    {
                        if (process == true)
                        {
                            XMessageBox.Show(Resources.MSG_TRANS_SUCCESS, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnList.PerformClick(FunctionType.Query);
                        }
                        else
                        {
                            XMessageBox.Show(Resources.MSG_TRANS_FAIL, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    break;
            }
        }

        private void grdOCS1003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            //switch (e.ColName)
            //{
            //    case "hangmog_code":
            //        if (this.mSend_YN == "N")
            //        {
            //            if (grd.GetItemString(e.RowNumber, "jundal_part") == "PA" ||
            //                grd.GetItemString(e.RowNumber, "jundal_part") == "HOM" ||
            //                grd.GetItemString(e.RowNumber, "acting_date") != "") // Acting인 경우 (수납가능)
            //            {
            //                e.ForeColor = Color.Blue;    // 파랑색
            //                e.BackColor = Color.SkyBlue; // 하늘색
            //            }
            //            //if (grd.GetItemString(e.RowNumber, "result_date") != "") // 결과입력된 경우
            //            //{
            //            //    e.ForeColor = Color.DeepPink;  // 보라색
            //            //    e.BackColor = Color.SkyBlue;   // 하늘색
            //            //}
            //            //else if (grd.GetItemString(e.RowNumber, "ocs_flag").Trim() == "2") // 예약인 경우
            //            //{
            //            //    e.ForeColor = Color.Green;   // 녹색
            //            //}
            //            // 입원이 아닌 경우는 수납체크함
            //            //if (grd.GetItemString(e.RowNumber, "ocs_flag").Trim() == "0") // 전달이 아닌경우
            //            //{

            //            //}
            //            //else
            //            //{
            //            //    e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, IHIS.Framework.XEditGrid.DefaultFont.Size, FontStyle.Bold);
            //            //}
            //        }
            //        else
            //        {
            //            switch (grd.GetItemString(e.RowNumber, "if_flag"))
            //            {
            //                case "10":　//未転送
            //                    e.ForeColor = Color.Black;
            //                    e.BackColor = Color.Transparent;
            //                    break;

            //                case "20": //転送成功
            //                    e.ForeColor = Color.Green;
            //                    e.BackColor = Color.GreenYellow;
            //                    break;

            //                //case "21": //転送失敗
            //                //    e.ForeColor = Color.Red;    
            //                //    e.BackColor = Color.Pink;
            //                //    break;

            //                case "30": //会計済み
            //                    e.ForeColor = Color.Black;
            //                    e.BackColor = Color.DarkGray;
            //                    break;

            //                case "":
            //                    e.ForeColor = Color.Black;
            //                    e.BackColor = Color.DarkGray;
            //                    break;
            //            }
            //            //grd[e.RowNumber, e.ColName].SelectedForeColor = new XColor(e.ForeColor);
            //            //grd[e.RowNumber, e.ColName].SelectedBackColor = new XColor(e.BackColor);
            //        }
            //        break;
            //}

            // https://sofiamedix.atlassian.net/browse/MED-13718
            if (rbnMiTrans.Checked)
            {
                string actingDate = grd.GetItemString(e.RowNumber, "acting_date");
                // https://sofiamedix.atlassian.net/browse/MED-13960
                // if (!TypeCheck.IsNull(actingDate))
                if (TypeCheck.IsNull(actingDate))
                {
                    e.ForeColor = Color.Black;
                    e.BackColor = Color.Transparent;
                }
                else
                {
                    e.ForeColor = Color.Blue;    // 파랑색
                    e.BackColor = Color.SkyBlue; // 하늘색
                }
            }
            else
            {
                string orderStatus = grd.GetItemString(e.RowNumber, "order_status");
                switch (orderStatus)
                {
                    case "10":
                        e.ForeColor = Color.Black;
                        e.BackColor = Color.Transparent;
                        break;
                    case "20":
                        e.ForeColor = Color.Green;
                        e.BackColor = Color.GreenYellow;
                        break;
                    case "21":
                        e.ForeColor = Color.Red;
                        e.BackColor = Color.Pink;
                        break;
                    case "30":
                        e.ForeColor = Color.Black;
                        e.BackColor = Color.DarkGray;
                        break;
                    default:
                        break;
                }
            }

            //if (grd.GetItemString(e.RowNumber, "if_flag") == "21")
            //{
            //    e.ForeColor = Color.Red;
            //    e.BackColor = Color.Pink;
            //    //grd[e.RowNumber, e.ColName].SelectedForeColor = new XColor(Color.Red);
            //    //grd[e.RowNumber, e.ColName].SelectedBackColor = new XColor(Color.Pink);
            //}

            if (grd.CellInfos.Contains("trial_flg"))
            {
                if (grd.GetItemString(e.RowNumber, "trial_flg") == "Y")
                {
                    e.BackColor = Color.Plum;
                }
            }
            
        }

        private void grdList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            this.hoken_valid_yn = false;

            if (e.CurrentRow >= 0)
            {
                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();

                inputList.Add(EnvironInfo.HospCode);
                inputList.Add(mCurrentListGrid.GetItemValue(e.CurrentRow, "acting_date"));
                inputList.Add(mCurrentListGrid.GetItemValue(e.CurrentRow, "doctor"));
                inputList.Add(this.fbxBunho.GetDataValue().ToString());

                if (mSend_YN == "N")
                {
                    //if (Service.ExecuteProcedure("PR_OUT_CHECK_ORDER_END", inputList, outputList))
                    //{
                    //    if (outputList[0].ToString() != "E")
                    //    {
                    //        XMessageBox.Show("診療がまだ終了されておりません。診療終了状況を確認してください。", "診療終了確認", MessageBoxIcon.Information);
                    //    }
                    //}
                    //else
                    //{
                    //    XMessageBox.Show("診療終了情報取得に問題がありました。" + Service.ErrFullMsg, "診療終了確認エラー", MessageBoxIcon.Warning);
                    //}

                    // updated by Cloud
                    ORDERTRANSExecPrOutCheckOrderEndArgs args = new ORDERTRANSExecPrOutCheckOrderEndArgs();
                    args.HospCode = UserInfo.HospCode;
                    args.ActingDate = mCurrentListGrid.GetItemValue(e.CurrentRow, "acting_date").ToString();
                    args.Doctor = mCurrentListGrid.GetItemValue(e.CurrentRow, "doctor").ToString();
                    args.Bunho = this.fbxBunho.GetDataValue().ToString();
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, ORDERTRANSExecPrOutCheckOrderEndArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (res.Result == false)
                        {
                            XMessageBox.Show(Resources.MSG_2 + Service.ErrFullMsg, Resources.CAP_2, MessageBoxIcon.Warning);
                        }
                        else if (res.Msg != "E")
                        {
                            XMessageBox.Show(Resources.MSG_3, Resources.CAP_3, MessageBoxIcon.Information);
                        }
                    }
                }

                //그리드에디터데이터출력
                this.GridSelectChanged();
                //공비정보표시처리
                //this.DisplayGongbiInfo(e.CurrentRow);
                //입원인경우 보험정보/백데이터 클리어
                if (this.mIOGubun == "I")
                {
                    DisplayHokenInfo(e.CurrentRow);
                    this.layOrderInfo.Reset();
                }
                //전송일자를실행일자로설정
                if (this.mCurrentListGrid.GetItemString(e.CurrentRow, "select") == "Y")
                {
                    this.dtpJunsongDate.SetDataValue(this.mCurrentListGrid.GetItemString(e.CurrentRow, "acting_date"));
                }


                //환자특기사항취득
                this.grdComment.QueryLayout(true);

                //접수정보.공비정보 변경불가설정
                this.grdGongbi.ReadOnly = true;
                //this.cboSanjung_Name.Protect = true;
                //this.cboChojae_Name.Protect = true;
                this.fbxHoken.Protect = true;
                this.DisplayPaInfoHoken();
                this.grdHoken.ReadOnly = true;

                this.mCurrentGrid.SetFocusToItem(this.mCurrentGrid.CurrentRowNumber, "hangmog_code");
            }
        }

        private void grdGongbi_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "select")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    this.AddGongbiCode(e.RowNumber, this.grdGongbi.GetItemString(e.RowNumber, "gongbi_code"));
                }
                else
                {
                    this.DelGongbiCode(e.RowNumber, this.grdGongbi.GetItemString(e.RowNumber, "gongbi_code"));
                }
            }
            this.grdGongbi.AcceptData();
        }

        private void grid_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            //커런트그리드에디터리스트
            XEditGrid grdList = this.mCurrentListGrid;
            string tap = this.tabDataGubun.SelectedTab.Tag.ToString();

            if (grdList == null)
            {
                return;
            }
            grd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grd.SetBindVarValue("f_bunho", grdList.GetItemString(grdList.CurrentRowNumber, "bunho"));
            grd.SetBindVarValue("f_pk1001", grdList.GetItemString(grdList.CurrentRowNumber, "pk1001"));
            grd.SetBindVarValue("f_send_yn", this.mSend_YN);
            grd.SetBindVarValue("f_acting_date", grdList.GetItemString(grdList.CurrentRowNumber, "acting_date"));
            //grd.SetBindVarValue("f_order_date", grdList.GetItemString(grdList.CurrentRowNumber, "order_date"));
            grd.SetBindVarValue("f_gwa", grdList.GetItemString(grdList.CurrentRowNumber, "gwa"));
            grd.SetBindVarValue("f_doctor", grdList.GetItemString(grdList.CurrentRowNumber, "doctor"));
            //grd.SetBindVarValue("f_gubun", grdList.GetItemString(grdList.CurrentRowNumber, "gubun"));
        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            grd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grd.SetBindVarValue("f_io_gubun", this.mIOGubun.ToString());
            grd.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
            grd.SetBindVarValue("f_send_yn", this.mSend_YN);
            grd.SetBindVarValue("f_acting_date", this.dtpJunsongDate.GetDataValue());
        }

        private void grdOCS1003_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (e.CurrentRow >= 0)
            {
                DisplaySpecialColHeader(grd, e.CurrentRow);
            }
        }

        private void grdOutList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;
            XEditGrid grid = sender as XEditGrid;
            // 예약환자인경우
            if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
            {
                e.BackColor = Color.LightGreen;
            }
            if ((grid.GetItemString(e.RowNumber, "sunab_yn") == "Y") && (this.mSend_YN == "N"))
            {
                e.BackColor = Color.LightPink;
            }
        }

        private void fbxHoken_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox findBox = (XFindBox)sender;
            //커런트 그리드리스트 취득
            XEditGrid grdList = this.mCurrentListGrid;

//            this.fwkFind.InputSQL = @" SELECT A.GUBUN
//                                              , FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, :f_acting_date)  GUBUN_NAME
//                                         FROM OUT0102 A
//                                        WHERE A.HOSP_CODE = :f_hosp_code
//                                          AND A.BUNHO     = :f_bunho 
//                                          --AND TO_DATE(:f_acting_date) BETWEEN A.START_DATE AND A.END_DATE 
//                                          AND A.START_DATE = (SELECT MAX(Z.START_DATE) 
//                                                                  FROM OUT0102 Z
//                                                                  WHERE Z.HOSP_CODE   = A.HOSP_CODE
//                                                                  AND Z.BUNHO = A.BUNHO
//                                                                    AND Z.GUBUN = A.GUBUN
//                                                                  AND TO_DATE(:f_acting_date) BETWEEN Z.START_DATE AND NVL(Z.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))) ";
            this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkFind.SetBindVarValue("f_bunho", grdList.GetItemString(grdList.CurrentRowNumber, "bunho"));
            this.fwkFind.SetBindVarValue("f_acting_date", grdList.GetItemString(grdList.CurrentRowNumber, "acting_date"));
            // updated by Cloud
            this.fwkFind.ExecuteQuery = GetFbxHoken;
        }

        private void fbxHoken_DataValidating(object sender, DataValidatingEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            //커런트 그리드리스트 취득
            XEditGrid grdList = this.mCurrentListGrid;

            if (e.DataValue == "")
            {
                this.dbxHoken_Name.SetEditValue("");
                this.dbxHoken_Name.AcceptData();
                grdList.SetItemValue(grdList.CurrentRowNumber, "gubun_name", "");
                return;
            }
            switch (control.Name)
            {
                case "fbxHoken":
                    #region deleted by Cloud
//                    this.layCommon.QuerySQL = @" SELECT A.GUBUN_NAME, NVL(B.IF_VALID_YN,'Y'), NVL(A.GONGBI_YN,'Y')
//                                                   FROM BAS0210 A, OUT0102 B
//                                                  WHERE A.HOSP_CODE   = :f_hosp_code 
//                                                    AND A.GUBUN       = :f_gubun
//                                                    AND TO_DATE(:f_acting_date) BETWEEN A.START_DATE
//                                                            AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
//                                                    AND A.HOSP_CODE   = B.HOSP_CODE
//                                                    AND B.BUNHO       = :f_bunho  
//                                                    AND B.GUBUN       = A.GUBUN
//                                                    --AND TRUNC(SYSDATE) BETWEEN B.START_DATE
//                                                    --      AND NVL(B.END_DATE, TO_DATE('99981231', 'YYYYMMDD')) 
//                                                    AND B.START_DATE  = (SELECT MAX(Z.START_DATE) 
//                                                                             FROM OUT0102 Z
//                                                                            WHERE Z.HOSP_CODE   = B.HOSP_CODE
//                                                                            AND Z.BUNHO = B.BUNHO
//                                                                              AND Z.GUBUN = B.GUBUN
//                                                                            AND TO_DATE(:f_acting_date) BETWEEN Z.START_DATE AND NVL(Z.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))) ";
                    #endregion

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layCommon.SetBindVarValue("f_gubun", e.DataValue);
                    this.layCommon.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
                    this.layCommon.SetBindVarValue("f_acting_date", this.dtpJunsongDate.GetDataValue().ToString());
                    this.layCommon.ExecuteQuery = GetLayCommon;
                    //if (this.layCommon.QueryLayout())
                    //{
                    //    if (this.layCommon.GetItemValue("if_valid_yn").ToString() == "N")
                    //    {
                    //        this.hoken_valid_yn = true;
                    //    }
                    //    else
                    //    {
                    //        this.hoken_valid_yn = false;
                    //    }
                    //    grdList.SetItemValue(grdList.CurrentRowNumber, "gubun_name", this.layCommon.GetItemValue("gubun_name").ToString());
                    //    this.txtGongbi_yn.SetEditValue(this.layCommon.GetItemValue("gongbi_yn").ToString());
                    //    this.txtGongbi_yn.AcceptData();
                    //}
                    //else
                    //{
                    //    string mMsg = NetInfo.Language == LangMode.Ko ?
                    //                 "환자보험이유효하지않습니다.보험정보를 확인하여주십시요" :
                    //                 "患者保険が有効ではありません。保険情報を確認してください。";
                    //    string mCap = NetInfo.Language == LangMode.Ko ? "확인" : "確認";
                    //    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    //보험종별클리어처리
                    //    PostCallHelper.PostCall(new PostMethodObject(Post_DataValidating), false);
                    //    this.fbxHoken.Focus();
                    //    return;
                    //}

                    // Updated by Cloud
                    ORDERTRANSLayCommonArgs args = new ORDERTRANSLayCommonArgs();
                    args.ActingDate = this.dtpJunsongDate.GetDataValue().ToString();
                    args.Bunho = this.fbxBunho.GetDataValue();
                    args.Gubun = e.DataValue;
                    args.HospCode = UserInfo.HospCode;
                    ORDERTRANSLayCommonResult res = CloudService.Instance.Submit<ORDERTRANSLayCommonResult, ORDERTRANSLayCommonArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.LayCommonItem.Count > 0)
                    {
                        this.hoken_valid_yn = res.LayCommonItem[0].IfValidYn == "N";
                        grdList.SetItemValue(grdList.CurrentRowNumber, "gubun_name", res.LayCommonItem[0].GubunName);
                        this.txtGongbi_yn.SetEditValue(res.LayCommonItem[0].GongbiYn);
                        this.txtGongbi_yn.AcceptData();
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_001, Resources.CAP_001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //보험종별클리어처리
                        PostCallHelper.PostCall(new PostMethodObject(Post_DataValidating), false);
                        this.fbxHoken.Focus();
                        return;
                    }
                    break;
            }
        }

        private void grdComment_QueryStarting(object sender, CancelEventArgs e)
        {
            //커런트 그리드리스트 취득
            XEditGrid grdList = this.mCurrentListGrid;
            this.grdComment.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdComment.SetBindVarValue("f_bunho", grdList.GetItemString(grdList.CurrentRowNumber, "bunho"));
        }

        private void grdOutSang_QueryStarting(object sender, CancelEventArgs e)
        {
            //커런트 그리드리스트 취득
            XEditGrid grdList = this.mCurrentListGrid;
            this.grdOutSang.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOutSang.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
            //this.grdOutSang.SetBindVarValue("f_gwa", grdList.GetItemString(grdList.CurrentRowNumber, "gwa"));
            this.grdOutSang.SetBindVarValue("f_gijun_date", grdList.GetItemString(grdList.CurrentRowNumber, "order_date"));
            this.grdOutSang.SetBindVarValue("f_io_gubun", this.mIOGubun.ToString());
        }

        private void grdGongbi_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = this.mCurrentListGrid;

            string InputSQL = "";

            // updated by Cloud
            InputSQL = SetUserSQL();
            this.grdGongbi.ExecuteQuery = GetGrdGongbi;
            this.grdGongbi.SetBindVarValue("f_send_yn", this.mSend_YN);
            this.grdGongbi.SetBindVarValue("f_io_gubun", this.mIOGubun);

            if (InputSQL == "")
            {
                return;
            }
            //this.grdGongbi.QuerySQL = InputSQL;
            this.grdGongbi.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdGongbi.SetBindVarValue("f_bunho", grd.GetItemString(grd.CurrentRowNumber, "bunho"));
            if (this.mIOGubun == "O")
            {
                this.grdGongbi.SetBindVarValue("f_out1001", grd.GetItemString(grd.CurrentRowNumber, "pk1001"));
            }
            else
            {
                this.grdGongbi.SetBindVarValue("f_pkinp1002", grd.GetItemString(grd.CurrentRowNumber, "pkinp1002"));
                this.grdGongbi.SetBindVarValue("f_pkout", grd.GetItemString(grd.CurrentRowNumber, "pkout"));
            }
        }

        private void btnCompar_Click(object sender, EventArgs e)
        {
            IHIS.Framework.IXScreen aScreen;
            aScreen = XScreen.FindScreen("NURO", "ORCAORDER");

            if (aScreen == null)
            {
                string bunho = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "bunho");
                if (bunho != "")
                {
                    //string naewon_date = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "naewon_date");
                    string pk1001 = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "pk1001");
                    string JunsongDate = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "acting_date");
                    string IOGubun = this.mIOGubun;
                    string gwa = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "gwa");
                    string doctor = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "doctor");
                    CommonItemCollection openParams = new CommonItemCollection();

                    openParams.Add("bunho", bunho);
                    openParams.Add("pk1001", pk1001);
                    openParams.Add("JunsongDate", JunsongDate);
                    openParams.Add("gwa_name", this.dbxGwa_name.GetDataValue());
                    openParams.Add("gwa", gwa);
                    openParams.Add("doctor", doctor);
                    openParams.Add("IOGubun", IOGubun);       //외래/입원구분
                    openParams.Add("gubun", this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "gubun"));       //보험
                    openParams.Add("gongbi_code1", this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "gongbi_code1"));
                    openParams.Add("gongbi_code2", this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "gongbi_code2"));
                    openParams.Add("gongbi_code3", this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "gongbi_code3"));
                    openParams.Add("gongbi_code4", this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "gongbi_code4"));
                    string tap = this.tabDataGubun.SelectedTab.Tag.ToString();
                    openParams.Add("oder_gubun", tap);        //오더/식사/외박/전가・전동・전실구분

                    XScreen.OpenScreenWithParam(this, "NURO", "ORCAORDER", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);
                }
                else
                {
                    string mMsg = Resources.MSG_4;
                    string mCap = Resources.CAP_4;
                    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }
        }

        private void grdList_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grdList = sender as XEditGrid;
            int rowNumber = -1;
            string select_yn = "";
            Image Images = null;

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowNumber = grdList.GetHitRowNumber(e.Y);

                if (rowNumber < 0) return;

                if (grdList.CurrentColName == "select")
                {
                    if (grdList.GetItemString(rowNumber, "select") == "Y")
                    {
                        select_yn = "N";
                        Images = this.ImageList.Images[1];
                    }
                    else
                    {
                        select_yn = "Y";
                        Images = this.ImageList.Images[0];
                        //전송날짜셋팅 - 현재의 시간 그대로 가져 가기로 함
                        //this.dtpJunsongDate.SetDataValue(grdList.GetItemString(rowNumber, "acting_date"));
                    }
                    grdList[rowNumber, "select"].Image = Images;
                    grdList.SetItemValue(rowNumber, "select", select_yn);


                    //if ((Int32.Parse(grdList.GetItemString(rowNumber, "if_valid_yn")) != 0) && (select_yn == "Y"))
                    //{
                    //    this.hoken_valid_yn = true;
                    //    grdList.SetItemValue(rowNumber, "if_valid_yn", Int32.Parse("0"));
                    //}
                    for (int i = 0; i < this.mCurrentGrid.RowCount; i++)
                    {
                        if (this.mCurrentGrid.GetItemString(i, "select") != "X")
                        {
                            //if (this.mSend_YN != "Y")
                            //{
                            this.mCurrentGrid.SetItemValue(i, "select", select_yn);
                            this.mCurrentGrid[i, "select"].Image = Images;
                            if (select_yn == "Y")
                            {
                                this.AddOrderBackTable(i);
                            }
                            else
                            {
                                this.DeleteOrderBackTable(i);
                            }
                            /*
                            }
                            else
                            {
                                if (select_yn == "N")
                                {
                                    this.mCurrentGrid.SetItemValue(i, "select", "Y");
                                    this.mCurrentGrid[i, "select"].Image = this.ImageList.Images[0];
                                    this.DeleteOrderBackTable(i);
                                }
                            }*/
                        }
                    }
                }
                //if ((this.mSend_YN == "Y")||(this.mIOGubun !="O"))
                //{
                DataRow[] dtRow = this.mCurrentListGrid.LayoutTable.Select("select =" + "'Y'");
                if (dtRow.Length > 0)
                {
                    for (int i = 0; i < this.mCurrentListGrid.RowCount; i++)
                    {
                        if ((this.mCurrentListGrid.GetItemString(i, "select") == "Y") && (i != rowNumber))
                        {
                            this.mCurrentListGrid.SetItemValue(i, "select", "N");
                            this.mCurrentListGrid[i, "select"].Image = this.ImageList.Images[1];
                        }
                    }
                }
                //}
            }
            //보험정보,초재진,산정구분
            if (this.mSend_YN == "N")
            {
                if (this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "select") == "Y")
                {
                    this.grdGongbi.ReadOnly = false;
                    //this.fbxHoken.Protect = false;
                    this.grdHoken.ReadOnly = false;
                }
                else
                {
                    this.grdGongbi.ReadOnly = true;
                    //this.fbxHoken.Protect = true;
                    this.grdHoken.ReadOnly = true;
                }
            }
        }

        private void grdEdit_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            int rowNumber = -1;

            if (this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "select") != "Y")
            {
                return;
            }
            if (this.mSend_YN == "Y")
            {
                return;
            }

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowNumber = grd.GetHitRowNumber(e.Y);

                if (rowNumber < 0) return;
                if (grd.CurrentColName == "select")
                {
                    if (grd.GetItemString(rowNumber, "select") == "X")
                    {
                        return;
                    }
                    this.ClickCurrentOrder(rowNumber);
                }
            }
        }

        private void btnReSend_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //MakeIFS1004("ORDER", this.tab

            //    if (layOrderInfo.RowCount <= 0)
            //    {
            //        XMessageBox.Show(Resources.MSG_5, Resources.CAP_5, MessageBoxIcon.Warning);
            //        return;
            //    }


            //    string pkout1003 = this.layOrderInfo.GetItemString(mCurrentListGrid.CurrentRowNumber, "pk1001");
            //    int retVal = MakeIFS1004("ORDER", mIOGubun, pkout1003, "R");

            //    if (retVal > 0)
            //    {
            //        if (OrderTrans(pkout1003, "R"))
            //        {
            //            XMessageBox.Show(Resources.MSG_6, Resources.CAP_6, MessageBoxIcon.Information);
            //            btnList.PerformClick(FunctionType.Query);
            //        }
            //    }
            //    else
            //    {

            //    }

            //    //if (this.ProcessOrderSend())
            //    //{
            //    //    this.mCap = NetInfo.Language == LangMode.Ko ? "재전송 완료"
            //    //                                                : "再転送完了";
            //    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "정상적으로 재전송 되었습니다."
            //    //                                                : "正常的に再転送されました。";
            //    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //}
            //    //else
            //    //{
            //    //    this.mCap = NetInfo.Language == LangMode.Ko ? "재전송 실패"
            //    //                                                : "再転送失敗";
            //    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "오더 재전송에 문제가 발생하였습니다."
            //    //                                                : "オーダ再転送に問題が発生しました。";
            //    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    //https://sofiamedix.atlassian.net/browse/MED-10610
            //    //XMessageBox.Show(ex.Message, Resources.CAP_5, MessageBoxIcon.Exclamation);
            //    btnList.PerformClick(FunctionType.Query);
            //}

            // https://sofiamedix.atlassian.net/browse/MED-13718
            this.DoTransfer(TransferType.Retransfer);
            btnList.PerformClick(FunctionType.Query);
        }

        private void dtpGijunDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != "")
            {
                this.PostBunhoValidating();
            }
        }

        private void grdWoichul_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "end_date")
            {
                for (int i = 0; i < this.layOrderInfo.RowCount; i++)
                {
                    if ((this.layOrderInfo.GetItemString(i, "pk1001") == e.DataRow["pk1001"].ToString()) &&
                        (this.layOrderInfo.GetItemString(i, "out_date") == e.DataRow["out_date"].ToString()))
                    {
                        this.layOrderInfo.SetItemValue(i, "end_date", e.ChangeValue);
                        return;
                    }
                }
            }
        }

        private void grdWoichul_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "end_date")
            {
                if (this.rbnTrans.Checked)
                {
                    e.Protect = true;
                }
                else
                {
                    if (e.DataRow["select"].ToString() == "Y")
                    {
                        e.Protect = false;
                    }
                    else
                    {
                        e.Protect = true;
                    }
                }
            }
        }

        private void grdHoken_QueryStarting(object sender, CancelEventArgs e)
        {
            //커런트 그리드리스트 취득
            XEditGrid grdList = this.mCurrentListGrid;
            this.grdHoken.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdHoken.SetBindVarValue("f_bunho", grdList.GetItemString(grdList.CurrentRowNumber, "bunho"));
            this.grdHoken.SetBindVarValue("f_acting_date", grdList.GetItemString(grdList.CurrentRowNumber, "acting_date"));
            this.grdHoken.SetBindVarValue("f_gubun", grdList.GetItemString(grdList.CurrentRowNumber, "gubun"));
            this.grdHoken.SetBindVarValue("f_send_yn", this.mSend_YN);

        }

        private void grdHoken_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "select")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    this.fbxHoken.SetEditValue(this.grdHoken.GetItemString(e.RowNumber, "gubun"));
                    this.fbxHoken.AcceptData();

                    for (int i = 0; i < this.grdHoken.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            this.grdHoken.SetItemValue(i, "select", "N");
                        }
                    }
                }
                else
                {
                    this.fbxHoken.SetEditValue("");
                    this.fbxHoken.AcceptData();
                }
            }
            this.grdHoken.AcceptData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int current = this.mCurrentListGrid.CurrentRowNumber;

            if ((current < 0) || (this.fbxBunho.GetDataValue() == ""))
            {
                return;
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("naewon_date", this.mCurrentListGrid.GetItemString(current, "naewon_date"));
            openParams.Add("bunho", this.fbxBunho.GetDataValue());
            openParams.Add("gwa", this.mCurrentListGrid.GetItemString(current, "gwa"));
            openParams.Add("doctor", this.mCurrentListGrid.GetItemString(current, "doctor"));
            if (this.mIOGubun == "O")
            {
                openParams.Add("naewon_type", this.mCurrentListGrid.GetItemString(current, "naewon_type"));
                openParams.Add("jubsu_no", this.mCurrentListGrid.GetItemString(current, "jubsu_no"));
            }
            else
            {
                openParams.Add("naewon_type", "");
                openParams.Add("jubsu_no", "");
            }
            //openParams.Add("jubsu_no", "");
            openParams.Add("input_gubun", "D%");
            openParams.Add("jubsu_key", this.mCurrentListGrid.GetItemString(current, "pk1001"));

            openParams.Add("bacode_flg", true);

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003R00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void grdOCS1003_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //再転送の対象データ（if_flag = 10, 20)がない場合、再転送ボタンをオフにする。
            //DataRow[] dw = mCurrentGrid.LayoutTable.Select("if_flag = '10' OR if_flag = '21' ");
            DataRow[] dw = mCurrentGrid.LayoutTable.Select("order_status = '10' OR order_status = '21' ");

            if (dw.Length > 0)
            {
                btnSend.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
            }
        }

        private void btnSiksaTest_Click(object sender, EventArgs e)
        {
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();


            string bunho = this.mCurrentListGrid.GetItemString(mCurrentListGrid.CurrentRowNumber, "bunho");

            if (TypeCheck.IsNull(bunho))
            {
                XMessageBox.Show(Resources.MSG_7);
                return;
            }

            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
            inputList.Add("I_BUNHO", bunho);
            inputList.Add("I_FROM_DATE", dtpFromdate.GetDataValue().Replace("-", "/"));
            inputList.Add("I_FROM_SIK", cboFromsik.GetDataValue());
            inputList.Add("I_TO_DATE", dtpTodate.GetDataValue().Replace("-", "/"));
            inputList.Add("I_TO_SIK", cboTosik.GetDataValue());

            outputList.Add("O_PKIFS3021", "");
            try
            {
                //Service.BeginTransaction();

                #region deleted by Cloud
                //if (Service.ExecuteProcedure("PR_IFS_SIKSA_INPUT_TEST", inputList, outputList))
                //{
                //    IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
                //    string msgText = "00241" + outputList["O_PKIFS3021"].ToString();
                //    int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
                //    if (ret == -1)
                //    {
                //        throw new Exception("外泊転送する途中問題が発生しました。電文：" + msgText);
                //    }
                //    else
                //    {
                //        XMessageBox.Show("転送成功", "成功", MessageBoxIcon.Information);
                //    }
                //}
                #endregion

                //Service.CommitTransaction();

                // updated by Cloud
                ORDERTRANSPrIfsSiksaInputTestArgs args = new ORDERTRANSPrIfsSiksaInputTestArgs();
                args.HospCode = UserInfo.HospCode;
                args.Bunho = bunho;
                args.FromDate = dtpFromdate.GetDataValue().Replace("-", "/");
                args.FromSik = cboFromsik.GetDataValue();
                args.ToDate = dtpTodate.GetDataValue().Replace("-", "/");
                args.ToSik = cboTosik.GetDataValue();
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, ORDERTRANSPrIfsSiksaInputTestArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                {
                    IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
                    string msgText = "00241" + res.Msg;
                    int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
                    if (ret == -1)
                    {
                        throw new Exception(Resources.EXP_1 + msgText);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_8, Resources.CAP_8, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                //Service.RollbackTransaction();
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.CAP_EXP, MessageBoxIcon.Exclamation);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = !pnlHelp.Visible;
        }

        private void grdINP2004_QueryStarting(object sender, CancelEventArgs e)
        {
            grdINP2004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdINP2004.SetBindVarValue("f_bunho", this.mCurrentListGrid.GetItemString(mCurrentListGrid.CurrentRowNumber, "bunho"));
            grdINP2004.SetBindVarValue("f_send_yn", this.mSend_YN);
            grdINP2004.SetBindVarValue("f_acting_date", this.mCurrentListGrid.GetItemString(mCurrentListGrid.CurrentRowNumber, "acting_date"));
            grdINP2004.SetBindVarValue("f_sunab_date", dtpJunsongDate.GetDataValue());
            grdINP2004.SetBindVarValue("f_fkinp1001", this.mCurrentListGrid.GetItemString(mCurrentListGrid.CurrentRowNumber, "pk1001"));
        }

        private bool CheckSelectForcedTermination()
        {
            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                if (grdOCS1003.GetItemString(i, "select") == "Y" || grdOCS1003.GetItemString(i , "acting_date") != null)     
                    return true;
            }
            return false;
        }

        private void btnForcedEnd_Click(object sender, EventArgs e)
        {
            //https://sofiamedix.atlassian.net/browse/MED-10484
            //AccountForcedEnd();
            this.AcceptData();  

            if (!rbnMiTrans.Checked) return;

            if (!CheckSelectBunho())
            {
                XMessageBox.Show(Resources.MSG_NOTICE, Resources.MSG_NOTICE_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TypeCheck.IsNull(grdOCS1003.GetItemString(grdOCS1003.CurrentRowNumber, "acting_date")))
            {
                XMessageBox.Show(Resources.MSG_FORCED_TERMINATION, Resources.MSG_FORCED_TERMINATION_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (CheckSelectForcedTermination())
                {
                    bool selectedOrder = false;
                    // Get list params request
                    List<ORCATransferOrdersLstSgCodeInfo> sgCodeList = new List<ORCATransferOrdersLstSgCodeInfo>();
                    List<NuroORDERTRANSUpdateOCS1003Info> dataList = new List<NuroORDERTRANSUpdateOCS1003Info>();
                    for (int i = 0; i < grdOCS1003.RowCount; i++)
                    {
                        // Skip records which is not selected
                        if (grdOCS1003.GetItemString(i, "select") != "Y") continue;

                        ORCATransferOrdersLstSgCodeInfo item = new ORCATransferOrdersLstSgCodeInfo();
                        item.HangmogCode = grdOCS1003.GetItemString(i, "hangmog_code");
                        item.HangmogName = grdOCS1003.GetItemString(i, "hangmog_name");
                        item.SgCode = grdOCS1003.GetItemString(i, "sg_code");
                        sgCodeList.Add(item);

                        // Only updates orders which is executed!
                        if (!TypeCheck.IsNull(grdOCS1003.GetItemString(i, "acting_date")))
                        {
                            NuroORDERTRANSUpdateOCS1003Info updItem = new NuroORDERTRANSUpdateOCS1003Info();
                            updItem.Pkocs1003 = grdOCS1003.GetItemString(i, "pkocs");
                            updItem.SunabDate = dtpJunsongDate.GetDataValue().ToString().Replace("-", "/");
                            dataList.Add(updItem);
                        }
                        if (!selectedOrder) selectedOrder = true;

                    }
                    if (!selectedOrder)
                    {
                        // 選択されてるオーダがありません。一つ以上選択してください。
                        XMessageBox.Show(Resources.MSG_21, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    NuroORDERTRANSUpdateOCS1003Args updArgs = new NuroORDERTRANSUpdateOCS1003Args();
                    updArgs.Pkout1001 = grdOutList.GetItemString(grdOutList.CurrentRowNumber, "pk1001");
                    updArgs.Bunho = fbxBunho.GetDataValue();
                    updArgs.OcsUpdItem = dataList;
                    UpdateResult updRes = CloudService.Instance.Submit<UpdateResult, NuroORDERTRANSUpdateOCS1003Args>(updArgs);

                    if (updRes.ExecutionStatus == ExecutionStatus.Success && updRes.Result == true)
                    {
                        XMessageBox.Show(Resources.MSG_SUCCESS, Resources.MSG_CAP, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnList.PerformClick(FunctionType.Query);
                        return;
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_FAIL, Resources.MSG_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch
            {

            }                                    
        }

        private void btnSangSendAll_Click(object sender, EventArgs e)
        {
//            string strSql = @" SELECT IFS_KEY
//                                 FROM IFS5011
//                                WHERE HOSP_CODE = :f_hosp_code
//                                  AND IF_FLAG = 'N'";

//            BindVarCollection bindVar = new BindVarCollection();

//            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);

//            DataTable sangSendTable = Service.ExecuteDataTable(strSql, bindVar);

//            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
//            string msgText;

//            for (int i = 0; i < sangSendTable.Rows.Count; i++)
//            {
//                msgText = "00181" + sangSendTable.Rows[i]["IFS_KEY"].ToString();
//                int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
//                if (ret == -1)
//                {
//                    throw new Exception("傷病名を転送する途中問題が発生しました。電文：" + msgText);
//                }
//            }

            //// updated by Cloud
            //ORDERTRANSSangSendAllArgs args = new ORDERTRANSSangSendAllArgs();
            //args.HospCode = UserInfo.HospCode;
            //ORDERTRANSSangSendAllResult res = CloudService.Instance.Submit<ORDERTRANSSangSendAllResult, ORDERTRANSSangSendAllArgs>(args);

            //IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            //string msgText;
            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    foreach (ORDERTRANSSangSendAllInfo item in res.SangInfoItem)
            //    {
            //        msgText = "00181" + item.IfsKey;
            //        int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            //        if (ret == -1)
            //        {
            //            throw new Exception(Resources.EXP_2 + msgText);
            //        }
            //    }
            //}

            // https://sofiamedix.atlassian.net/browse/MED-13718
            this.DoTransfer(TransferType.Disease);
            btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region Methods(private)

        private void InitScreen()
        {
            XRadioButton checkedControl;
            // 전송일자 오늘로 셋팅
            if (this.dtpJunsongDate.GetDataValue() == "")
                this.dtpJunsongDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            // 기준일자 오늘로 셋팅
            if (this.dtpGijunDate.GetDataValue() == "")
                this.dtpGijunDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            // 입원 외래 구분에 따른 라디오 버튼 셋팅
            if (this.mIOGubun == "O")
            {
                this.rbnOutData.Checked = true;
                this.rbnInData.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
                this.rbnInData.ImageIndex = 1;
                this.grdInpList.Visible = false;
                checkedControl = this.rbnOutData;
                this.mCurrentListGrid = this.grdOutList;
                this.xLabel6.Text = Resources.xLabel6_Text;
                this.xLabel10.Visible = false;
                this.dtpGijunDate.Visible = false;
            }
            else
            {
                this.rbnInData.Checked = true;
                this.rbnOutData.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
                this.rbnOutData.ImageIndex = 1;
                this.grdOutList.Visible = false;
                checkedControl = this.rbnInData;
                this.mCurrentListGrid = this.grdInpList;
                this.xLabel6.Text = Resources.xLabel6_2;
                this.xLabel10.Visible = true;
                this.dtpGijunDate.Visible = true;
            }
            // 디폴트 미전송 체크
            this.rbnMiTrans.Checked = true;
            //초재진
            //this.MakeChojaeCombo();
            // 백데이터셋팅
            this.layRequisInfo = this.mCurrentListGrid.CloneToLayout();
        }

        private void ClearInputControl()
        {
            //외/입정보클리어
            this.mCurrentListGrid.Reset();
            //오더정보클리어
            this.mCurrentGrid.Reset();
            //환자특기사항클리어
            this.grdComment.Reset();
            //환자공비정보클리어
            this.grdGongbi.Reset();
            //전송일자클리어
            //this.dtpJunsongDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            ////기준일자클리어
            //this.dtpGijunDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.grdHoken.Reset();
        }

        private void InitializeAllSelectLabel()
        {
            //전송완료버튼클릭시
            //if (this.mSend_YN == "Y")
            //{
            //    this.lbSelectAll.Tag = "Y";
            //    this.lbSelectAll.ImageIndex = 0;
            //}//미전송완료버튼클릭시
            //else
            //{
            this.lbSelectAll.Tag = "N";
            this.lbSelectAll.ImageIndex = 1;
            //if (this.mSend_YN == "Y")
            //{
            //    this.lbSelectAll.Click -= new System.EventHandler(this.lbSelectAll_Click);
            //}
            //else
            //{
            //    this.lbSelectAll.Click += new System.EventHandler(this.lbSelectAll_Click);
            //}

            //}
        }

        public override void OnReceiveBunHo(XPatientInfo info)
        {
            this.fbxBunho.SetDataValue(info.BunHo);
            PostCallHelper.PostCall(new PostMethod(PostBunhoValidating));
            base.OnReceiveBunHo(info);
        }

        private void PostBunhoValidating()
        {
            //오더백데이터 클리어
            this.ClearOrderBack();
            //환자정보처리
            this.SetSelectedPatientInfo();
            // 환자오더정보처리
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void SetSelectedPatientInfo()
        {
            // XDisplayBox 데이터삭제
            this.dbxSuname.ResetText();
            // LayoutIt11ems 데이터삭제
            this.layOut0101.LayoutItems.Clear();
            this.layOut0101.LayoutItems.Add("SUNAME");
            this.layOut0101.LayoutItems.Add("SUNAME2");
            this.layOut0101.LayoutItems.Add("BIRTH");
            this.layOut0101.LayoutItems.Add("TEL");
            this.layOut0101.LayoutItems.Add("SEX");
            this.layOut0101.LayoutItems.Add("AGE");
            this.layOut0101.LayoutItems.Add("IF_VALID_YN");
            // 바인트변수설정
            this.layOut0101.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layOut0101.SetBindVarValue("f_bunho", fbxBunho.GetDataValue().ToString());
            // 환자정보데이터 취득
            if (this.layOut0101.QueryLayout())
            {
                string str = "  " + this.layOut0101.GetItemValue("SUNAME").ToString() + "  [ " +
                                    this.layOut0101.GetItemValue("SUNAME2").ToString() + " ]  " +
                                    this.layOut0101.GetItemValue("SEX").ToString() + "  / " +
                                    this.layOut0101.GetItemValue("AGE").ToString() + " " + Resources.txtAge;// "才";
                this.dbxSuname.SetEditValue(str);
                this.IF_VALID_YN = this.layOut0101.GetItemValue("IF_VALID_YN").ToString();
            }
        }

        private void OpenScreen_OUT0101Q01()
        {
            CommonItemCollection param = new CommonItemCollection();
            XScreen.OpenScreenWithParam(this, "NURI", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "OUT0101":
                    if (commandParam != null)
                    {
                        this.fbxBunho.Focus();
                        this.fbxBunho.SetEditValue(((MultiLayout)commandParam[0]).GetItemString(0, "bunho"));
                        this.dbxSuname.SetEditValue(((MultiLayout)commandParam[0]).GetItemString(0, "suname"));
                        this.fbxBunho.AcceptData();
                    }
                    break;
            }
            return base.Command(command, commandParam);
        }

        //오더관련탭페이지 구성
        private void MakeDataGubunTabPages()
        {
            // 기존 탭 클리어
            try
            {
                this.tabDataGubun.TabPages.Clear();
            }
            catch
            {
                this.tabDataGubun.Refresh();
            }

            this.tabDataGubun.SelectionChanged -= new EventHandler(tabDataGubun_SelectionChanged);

            IHIS.X.Magic.Controls.TabPage tpg;

            // 오더 탭페이지 생성
            tpg = new IHIS.X.Magic.Controls.TabPage(Resources.Tab_order);
            tpg.ImageList = this.ImageList;
            tpg.ImageIndex = 3;
            tpg.Tag = "0";
            this.tabDataGubun.TabPages.Add(tpg);
            this.mCurrentGrid = this.grdOCS1003; //디폴트 오더탭설정

            // 레이아웃 셋팅
            this.layOrderInfo = this.mCurrentGrid.CloneToLayout();
            
            if (this.mIOGubun != "O")
            {
                // 식사 탭페이지 생성
                tpg = new IHIS.X.Magic.Controls.TabPage(Resources.TAB_1);
                tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 4;
                tpg.Tag = "1";
                this.tabDataGubun.TabPages.Add(tpg);
                // 외출,외박 탭페이지 생성
                tpg = new IHIS.X.Magic.Controls.TabPage(Resources.TAB_2);
                tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 5;
                tpg.Tag = "2";
                this.tabDataGubun.TabPages.Add(tpg);
                //전과, 전실 탭페이지 생성
                tpg = new IHIS.X.Magic.Controls.TabPage(Resources.TAB_3);
                tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 6;
                tpg.Tag = "3";
                this.tabDataGubun.TabPages.Add(tpg);
            }
            this.tabDataGubun.SelectedTab = this.tabDataGubun.TabPages[0];
            this.tabDataGubun.SelectionChanged += new EventHandler(tabDataGubun_SelectionChanged);
            this.tabDataGubun_SelectionChanged(this.tabDataGubun, new EventArgs());
        }

        //환자정보관련탭페이지 구성
        private void MakeDateInfoTabPages()
        {
            try
            {
                this.tabDataInfo.TabPages.Clear();
            }
            catch
            {
                this.tabDataInfo.Refresh();
            }

            this.tabDataInfo.SelectionChanged -= new EventHandler(tabDataInfo_SelectionChanged);

            IHIS.X.Magic.Controls.TabPage tpg;
            // 공비 탭페이지 생성
            tpg = new IHIS.X.Magic.Controls.TabPage(Resources.TAB_4);
            tpg.ImageList = this.ImageList;
            tpg.ImageIndex = 10;
            tpg.Tag = "1";
            this.tabDataInfo.TabPages.Add(tpg);
            // 특기사항 탭페이지 생성
            tpg = new IHIS.X.Magic.Controls.TabPage(Resources.TAB_5);
            tpg.ImageList = this.ImageList;
            tpg.ImageIndex = 11;
            tpg.Tag = "2";
            this.tabDataInfo.TabPages.Add(tpg);

            this.tabDataInfo.SelectedTab = this.tabDataInfo.TabPages[0];
            this.tabDataInfo.SelectionChanged += new EventHandler(tabDataInfo_SelectionChanged);
            this.tabDataInfo_SelectionChanged(this.tabDataInfo, new EventArgs());
        }

        private void SettingDefaultImageGrid()
        {
            XEditGrid grd = this.mCurrentGrid;

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetItemString(i, "acting_yn") == "Y")
                {
                    if (this.IsExistOrderBack(grd.GetItemString(i, "pkocs"), grd.GetItemString(i, "bunho")))
                    {
                        grd[i, "select"].Image = this.ImageList.Images[0];
                        grd.SetItemValue(i, "select", "Y");
                    }
                    else
                    {
                        if (grd.GetItemString(i, "select") == "N")
                        {
                            grd[i, "select"].Image = this.ImageList.Images[1];
                        }
                        else 
                        {
                            grd[i, "select"].Image = this.ImageList.Images[0];
                        }
                    }
                    this.mActCount++;
                }
                else
                {
                    if (this.mSend_YN == "N")
                    {
                        grd.SetItemValue(i, "select", "X");
                        grd[i, "select"].Image = this.ImageList.Images[2];
                    }

                }
                if (this.mSend_YN == "N")
                {
                    if (grd.GetItemString(i, "naewon_yn") != "E")
                    {
                        grd.SetItemValue(i, "select", "X");
                        grd[i, "select"].Image = this.ImageList.Images[3];
                    }
                }
            }
            this.checkSelectAll();
        }

        private bool IsValidTransDate()
        {
            if (this.fbxBunho.GetDataValue() == "")
            {
                this.mMsg = Resources.MAG_9;
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxIcon.Warning);
                return false;
            }
            DataRow[] dtRowData = this.mCurrentListGrid.LayoutTable.Select("select =" + "'Y'");
            if (dtRowData.Length <= 0) 
            {
                this.mMsg = Resources.MSG_9;
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxIcon.Warning);
                return false;
            }

            
            if (this.mSend_YN == "N")
            {
                /*
                if (this.IF_VALID_YN != "Y")
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "ORCA시스템에 등록되어있지않는 환자입니다. 환자등록하여주십시요." :
                                                                  "ORCAシステムに登録されてない患者です。患者登録を行ってください。";
                    string mCap = NetInfo.Language == LangMode.Ko ? "ORCA환자정보확인" : "`ORCA患者情報確認";
                    XMessageBox.Show(this.mMsg, mCap, MessageBoxIcon.Warning);
                    return false;
                }
                 */
                this.layRequisInfo.Reset();
                /*
                for (int i = 0; i < dtRowData.Length; i++)
                {   
                    if (dtRowData[i]["gubun"].ToString() == "")
                    {
                        int cnt = i + 1;
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "선택[ " + cnt.ToString() + " ]유효한보혐이 없습니다. 환자보험을 확인하여주십시요." :
                                                                      "選択[ " + cnt.ToString() + " ]有効な保険情報がありません。患者保険を確認してください。";
                        this.mCap = NetInfo.Language == LangMode.Ko ? "보험확인" : "保険確認";
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (dtRowData[i]["gongbi_yn"].ToString() == "C")
                    {
                        if ((dtRowData[i]["gongbi_code1"].ToString() == "") &&
                            (dtRowData[i]["gongbi_code2"].ToString() == "") &&
                            (dtRowData[i]["gongbi_code3"].ToString() == "") &&
                            (dtRowData[i]["gongbi_code4"].ToString() == ""))
                        {
                            int cnt = i + 1;
                            this.mMsg = NetInfo.Language == LangMode.Ko ? "선택[ " + cnt.ToString() + " ]공비단독의 공비가 선택되지 않았습니다. 환자공비를 확인하여주십시요." :
                                                                          "選択[ " + cnt.ToString() + " ]公費単独の公費が選択されておりません。患者公費を確認してください。";
                            string mCap = NetInfo.Language == LangMode.Ko ? "공비확인" : "公費確認";
                            XMessageBox.Show(this.mMsg, mCap, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else if (dtRowData[i]["gongbi_yn"].ToString() == "N")
                    {
                        if ((dtRowData[i]["gongbi_code1"].ToString() != "") ||
                            (dtRowData[i]["gongbi_code2"].ToString() != "") ||
                            (dtRowData[i]["gongbi_code3"].ToString() != "") ||
                            (dtRowData[i]["gongbi_code4"].ToString() != ""))
                        {
                            int cnt = i + 1;
                            this.mMsg = NetInfo.Language == LangMode.Ko ? "선택[ " + cnt.ToString() + " ][ " + dtRowData[i]["gubun_name"].ToString() + " ]보험은 공비선택이 불가능합니다. 공비정보를 확인하여주십시요." :
                                                                      "選択[ " + cnt.ToString() + " ][ " + dtRowData[i]["gubun_name"].ToString() + " ]保険は公費選択が不可能です。公費情報を確認してください。";
                        string mCap = NetInfo.Language == LangMode.Ko ? "공비확인" : "公費確認";
                        XMessageBox.Show(this.mMsg, mCap, MessageBoxIcon.Warning);
                        return false;
                        }                    
                    }
                    if ((dtRowData[i]["if_valid_yn"].ToString() != "0") || (this.hoken_valid_yn == true))
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "ORCA환자보험정보와일치하지않습니다.환자보험을갱신하여주십시요." :
                                                                      "ORCA患者保険情報と一致しません。ORCAにて患者保険更新を行ってください。";
                        string mCap = NetInfo.Language == LangMode.Ko ? "ORCA환자보험정보확인" : "ORCA患者保険確認";
                        XMessageBox.Show(this.mMsg, mCap, MessageBoxIcon.Warning);
                        return false;
                    }

                    //백데이터 외/입원정보추가
                    this.layRequisInfo.LayoutTable.ImportRow(dtRowData[i]);
                }

                */
                //실행일자체크
                dtRowData = this.layRequisInfo.LayoutTable.Select("acting_date < '" + this.dtpJunsongDate.GetDataValue().ToString() + "' and select = 'Y'");
                if (dtRowData.Length > 0)
                {
                    this.mMsg = Resources.MSG_10;
                    DialogResult result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                    {
                        return false;
                    }
                }
            }
            else
            {
                //백데이터클리어
                this.layRequisInfo.Reset();
                //백데이터 외/입원정보추가
                this.layRequisInfo.LayoutTable.ImportRow(dtRowData[0]);            
            }
            return true;
        }

        //
        // 공비코드추가
        //
        private void AddGongbiCode(int nCnt, string aGongbiCode)
        {
            int current = this.mCurrentListGrid.CurrentRowNumber;
            DataRow[] dtRow = this.grdGongbi.LayoutTable.Select("select =" + "'Y'");
            int cnt = dtRow.Length + 1;
            //공비순위셋팅
            this.grdGongbi.SetItemValue(nCnt, "priority", cnt);
            //공비데이터셋팅
            this.mCurrentListGrid.SetItemValue(current, "gongbi_code" + cnt.ToString(), aGongbiCode);
            //공비명셋팅
            switch(cnt.ToString())
            {
                case "1":
                    this.dbxGongbi_Name1.SetDataValue(this.grdGongbi.GetItemValue(nCnt, "gongbi_name"));
                    break;
                case "2":
                    this.dbxGongbi_Name2.SetDataValue(this.grdGongbi.GetItemValue(nCnt, "gongbi_name"));
                    break;
                case "3":
                    this.dbxGongbi_Name3.SetDataValue(this.grdGongbi.GetItemValue(nCnt, "gongbi_name"));
                    break;
                case "4":
                    this.dbxGongbi_Name4.SetDataValue(this.grdGongbi.GetItemValue(nCnt, "gongbi_name"));
                    break;            
            }

            int valid = Int32.Parse(this.mCurrentListGrid.GetItemString(current, "if_valid_yn"));
            //공비valid값체크
            if (this.grdGongbi.GetItemString(nCnt, "if_valid_yn") == "N")
            {
                valid++;
                this.mCurrentListGrid.SetItemValue(current, "if_valid_yn", valid);
            }
        }

        //
        // 공비코드삭제
        //
        private void DelGongbiCode(int nCnt, string aGongbiCode)
        {
            int current = this.mCurrentListGrid.CurrentRowNumber;
            int cnt = nCnt + 1;
            //공비코드클리어
            this.mCurrentListGrid.SetItemValue(current, "gongbi_code" + cnt.ToString(), "");
            //공비명셋팅
            switch (cnt.ToString())
            {
                case "1":
                    this.dbxGongbi_Name1.SetDataValue("");
                    break;
                case "2":
                    this.dbxGongbi_Name2.SetDataValue("");
                    break;
                case "3":
                    this.dbxGongbi_Name3.SetDataValue("");
                    break;
                case "4":
                    this.dbxGongbi_Name4.SetDataValue("");
                    break;
            }
            //순위체크
            string str = this.grdGongbi.GetItemString(nCnt, "priority");
            //삭제공비보다작은순위가있는지검색
            DataRow[] dtRow = this.grdGongbi.LayoutTable.Select("priority > " + Int32.Parse(str));
            if (dtRow.Length > 0)
            {
                for (int i = 0; i < this.grdGongbi.RowCount; i++)
                {
                    if (this.grdGongbi.GetItemString(i, "priority") == "")
                    {
                        continue;
                    }
                    int nPrior = Int32.Parse(this.grdGongbi.GetItemString(i, "priority"));
                    if (nPrior > Int32.Parse(str))
                    {
                        int num = nPrior - 1;
                        this.grdGongbi.SetItemValue(i, "priority", num);
                        this.mCurrentListGrid.SetItemValue(current, "gongbi_code" + nPrior.ToString(), "");
                        this.mCurrentListGrid.SetItemValue(current, "gongbi_code" + num.ToString(),
                                                           this.grdGongbi.GetItemString(i, "gongbi_code"));
                    }
                }
            }
            //공비valid값체크
            int valid = Int32.Parse(this.mCurrentListGrid.GetItemString(current, "if_valid_yn"));
            if (this.grdGongbi.GetItemString(nCnt, "if_valid_yn") == "N")
            {
                valid--;
                if (valid < 0)
                {
                    valid = 0;
                }
                this.mCurrentListGrid.SetItemValue(current, "if_valid_yn", valid);
            }
            //공비순위클리어
            this.grdGongbi.SetItemValue(nCnt, "priority", DBNull.Value);
        }

        //공비코드체크
        private int IsCheckedGongbiCode(string aGongbiCode)
        {
            for (int i = 1; i < this.mMaxGongbi; i++)
            {
                string colName = "gongbi_code" + i.ToString();
                if (this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, colName) == aGongbiCode)
                {
                    return i;
                }
            }
            return -1;
        }

        //공비정보표시
        private void DisplayGongbiInfo(int aRowNumber)
        {
            //공비정보표시
            if (!this.grdGongbi.QueryLayout(true))
            {
                return;
            }
            if (this.mSend_YN != "N")
            {
                return;
            }
            //공비정보클리어
            for (int j = 0; j < this.grdGongbi.RowCount; j++)
            {
                this.grdGongbi.SetItemValue(j, "select", "N");
                this.grdGongbi.SetItemValue(j, "priority", DBNull.Value);
            }
            int valid = Int32.Parse(this.mCurrentListGrid.GetItemString(aRowNumber, "if_valid_yn"));

            for (int i = 1; i < this.mMaxGongbi; i++)
            {
                string str = this.mCurrentListGrid.GetItemString(aRowNumber, "gongbi_code" + i.ToString());
                if (str == "")
                {
                    continue;
                }
                for (int j = 0; j < this.grdGongbi.RowCount; j++)
                {
                    if (str == this.grdGongbi.GetItemString(j, "gongbi_code"))
                    {
                        this.grdGongbi.SetItemValue(j, "priority", i);
                        this.grdGongbi.SetItemValue(j, "select", "Y");
                        if (this.grdGongbi.GetItemString(j, "if_valid_yn") == "N")
                        {
                            valid++;
                        }
                    }
                }
            }
            this.mCurrentListGrid.SetItemValue(aRowNumber, "if_valid_yn", valid.ToString());
        }

        //보험정보표시
        private void DisplayHokenInfo(int aRowNumber)
        {
            string gubun_old = this.mCurrentListGrid.GetItemString(aRowNumber, "gubun_old");
            string gubun = this.mCurrentListGrid.GetItemString(aRowNumber, "gubun");

            if (gubun != gubun_old)
            {
                this.mCurrentListGrid.SetItemValue(aRowNumber, "gubun", gubun_old);
            }
        }

        private void GridListSelectionChanged()
        {
            if (this.fbxBunho.GetDataValue() == "")
            {
                return;
            }
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            string str = tabDataGubun.SelectedTab.Tag.ToString();
            //커런트 그리드리스트 취득
            XEditGrid grdList = this.mCurrentListGrid;
            //커런트 그리드 취득
            XEditGrid grdEdit = this.mCurrentGrid;
            //취득그리드 체크
            if ((grdList == null) || (grdEdit == null))
            {
                return;
            }
            //그리드 리셋
            this.ClearOrderBack();
            //그리드 데이터 클리어
            this.ClearInputControl();
            //전체선택라벨초기화
            this.InitializeAllSelectLabel();

            // deleted by Cloud
            //// 데이터 쿼리 취득
            //string OcsQuery = this.SelectListQuerySQL(str);
            //if (OcsQuery != "")
            //{
            //    grdList.QuerySQL = OcsQuery;
            //    if (grdList.QueryLayout(true))
            //    {
            //        //리스트 디폴트 이미지 셋팅
            //        this.SetOutListImage();
            //    }
            //}

            // updated by Cloud
            grdList.ParamList = new List<string>(new string[]
                {
                    "f_acting_date",
                    "f_bunho",
                    "f_doctor",
                    "f_gwa",
                    "f_hosp_code",
                    "f_io_gubun",
                    "f_m_send_yn",
                    "f_order_date",
                    "f_pk1001",
                    "f_send_yn",
                    "f_str",
                });
            // Binding collections
            grdList.SetBindVarValue("f_io_gubun", mIOGubun);
            grdList.SetBindVarValue("f_m_send_yn", mSend_YN);
            grdList.SetBindVarValue("f_str", str);

            SelectListQuerySQL(str, grdList);
            if (grdList.QueryLayout(true))
            {
                //리스트 디폴트 이미지 셋팅
                this.SetOutListImage();
            }

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void GridSelectChanged()
        {
            
            XEditGrid grdEdit = this.mCurrentGrid;
            if (grdEdit == null)
            {
                return;
            }
            // 카운트 초기화
            this.mActCount = 0;

            // updated by Cloud
            grdEdit.ParamList = new List<string>(new string[]
                {
                    "f_acting_date",
                    "f_bunho",
                    "f_doctor",
                    "f_gwa",
                    "f_hosp_code",
                    "f_io_gubun",
                    "f_order_date",
                    "f_pk1001",
                    "f_send_yn",
                });

            if (grdEdit.Name.Equals("grdOCS1003"))
            {
                //string QuerySQL = "";
                if (this.mIOGubun == "O")
                {
                    // ORDERTRANSGrdEditRequest
                    #region deleted by Cloud
                    // 외래오더취득 SQL문
//                    QuerySQL = @"SELECT   A.FKOUT1003                                                pk1001
//                                        , A.PKOCS1003                                                PKOCS
//                                        , A.GROUP_SER                                                GROUP_SER
//                                        , A.GROUP_SER||A.FKOUT1001                                   GROUP_OUT1001
//                                        , NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME
//                                        , A.HANGMOG_CODE                                             HANGMOG_CODE 
//                                        , B.HANGMOG_NAME                                             HANGMOG_NAME
//                                        , A.SPECIMEN_CODE                                            SPECIMEN_CODE
//                                        , D.SPECIMEN_NAME                                            SPECIMEN_NAME
//                                        , A.SURYANG                                                  SURYANG
//                                        , A.ORD_DANUI                                                ORD_DANUI
//                                        , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME
//                                        , A.DV_TIME                                                  DV_TIME 
//                                        , A.DV                                                       DV
//                                        , A.NALSU                                                    NALSU
//                                        , A.JUSA                                                     JUSA
//                                        , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME
//                                        , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', A.JUSA_SPD_GUBUN)  JUSA_SPD_NAME
//                                        , A.BOGYONG_CODE                                             BOGYONG_CODE
//                                        --, CASE WHEN B.ORDER_GUBUN IN ('C','D') THEN FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE) 
//                                        --     ELSE A.BOGYONG_CODE
//                                        --END BOGYONG_NAME
//                                        , FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
//                                        , NVL(A.EMERGENCY, 'N')                                      EMERGENCY
//                                        , A.JUNDAL_PART                                              JUNDAL_PART 
//                                        , A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN
//                                        , NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN
//                                        , A.OCS_FLAG                                                 OCS_FLAG
//                                        , A.ORDER_GUBUN                                              ORDER_GUBUN
//                                        , A.BUNHO                                                    BUNHO
//                                        , A.ORDER_DATE                                               ORDER_DATE
//                                        , A.GWA                                                      GWA
//                                        , A.DOCTOR                                                   DOCTOR
//                                        , A.SEQ                                                      SEQ
//                                        , A.SOURCE_FKOCS1003                                         FKOCS003
//                                        , A.SUB_SUSUL                                                SUB_SUSUL
//                                        , CASE WHEN A.JUNDAL_PART  IN ('HOM','PA') THEN NULL
//                                               ELSE A.ACTING_DATE                                              
//                                          END ACTING_DATE
//                                        , CASE WHEN A.JUNDAL_PART  IN ('HOM','PA') THEN NULL    
//                                               ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))    
//                                          END HOPE_DATE
//                                        , A.SUNAB_DATE                                               SUNAB_DATE
//                                        , NVL(A.HOME_CARE_YN , 'N')                                  HOME_CARE_YN
//                                        , NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN 
//                                        , A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN
//                                        , E.BUN_CODE                                                 BUN_CODE
//                                        , B.INPUT_CONTROL                                            INPUT_CONTROL 
//                                        , B.ORDER_GUBUN                                              ORDER_GUBUN_BAS 
//                                        , CASE WHEN A.JUNDAL_PART in ('HOM', 'PA') THEN 'Y'
//                                               WHEN A.ACTING_DATE IS NOT NULL THEN 'Y'
//                                               ELSE  'N'
//                                          END ACTING_YN
//                                        , :f_send_yn                                                 SELECT_YN
//                                        , A.IF_DATA_SEND_YN                                          SEND_YN
//                                        , F.IF_FLAG                                                  IF_FLAG
//                                        , F.FKIFS1004                                                FKIFS1004
//                                        , AA.NAEWON_YN                                               NAEWON_YN
//                                        --, TRIM(LPAD(TO_CHAR(C.SORT_KEY), 2, '0'))
//                                        --  || TRIM(TO_CHAR(A.SEQ, '00000000000')) || TRIM(TO_CHAR(NVL(A.BOM_SOURCE_KEY, A.PKOCS1003), '00000000000'))
//                                        --  || CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9'
//                                        --         ELSE '0'
//                                        --     END
//                                        --  || TRIM(TO_CHAR(A.PKOCS1003, '00000000000'))   ORDER_BY_KEY 
//                                        , TRIM(LPAD(TO_CHAR(C.SORT_KEY), 2, '0'))
//                                          || TRIM(TO_CHAR(A.GROUP_SER, '0000000000'))
//                                          || TRIM(TO_CHAR(AA.PKOUT1001, '0000000000'))
//                                          || TRIM(TO_CHAR(NVL(A.BOM_SOURCE_KEY, A.PKOCS1003), '00000000000'))
//                                          || CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9'
//                                                 ELSE '0'
//                                             END 
//                                          || TRIM(TO_CHAR(A.SEQ, '00000000000')) 
//                                          || TRIM(TO_CHAR(A.PKOCS1003, '00000000000'))   ORDER_BY_KEY 
//                                   FROM  OCS1003 A
//                                       , OUT1001 AA
//                                       , (
//                                          SELECT A.*
//                                            FROM OCS0103 A
//                                           WHERE A.HOSP_CODE           = :f_hosp_code
//                                             AND A.START_DATE          = (SELECT MAX(Z.START_DATE)
//                                                                            FROM OCS0103 Z
//                                                                           WHERE Z.HOSP_CODE       = A.HOSP_CODE
//                                                                             AND Z.HANGMOG_CODE    = A.HANGMOG_CODE
//                                                                             AND Z.START_DATE      <= :f_acting_date
//                                                                             AND (   Z.END_DATE    IS NULL
//                                                                                  OR Z.END_DATE    >= :f_acting_date 
//                                                                                 )
//                                                                          )
//                                             AND (   A.END_DATE    IS NULL
//                                                  OR A.END_DATE    >= :f_acting_date  
//                                                 )
//                                         )       B
//                                       , OCS0132 C             
//                                       , OCS0116 D
//                                       , (
//                                          SELECT A.*
//                                            FROM BAS0310 A
//                                           WHERE A.HOSP_CODE           = :f_hosp_code
//                                             AND A.SG_YMD              = (SELECT MAX(Z.SG_YMD)
//                                                                            FROM BAS0310 Z
//                                                                           WHERE Z.HOSP_CODE       = A.HOSP_CODE
//                                                                             AND Z.SG_CODE         = A.SG_CODE
//                                                                             AND Z.SG_YMD          <= :f_acting_date 
//                                                                             AND (   Z.BULYONG_YMD IS NULL
//                                                                                  OR Z.BULYONG_YMD >= :f_acting_date  
//                                                                                 )
//                                                                          )
//                                             AND (   A.BULYONG_YMD IS NULL
//                                                  OR A.BULYONG_YMD >= :f_acting_date  
//                                                 )
//                                         )       E
//                                        , (SELECT X.HOSP_CODE, X.FKOCS1003, X.FKOUT1003, X.IF_FLAG, X.FKIFS1004
//                                            FROM IFS2011 X  
//                                           WHERE X.HOSP_CODE = :f_hosp_code
//                                             AND X.FKOUT1003 = :f_pk1001
//                                             AND X.PKIFS2011 IN (SELECT MAX(Z.PKIFS2011) PKIFS2011
//                                                                   FROM IFS2011 Z
//                                                                  WHERE Z.HOSP_CODE = X.HOSP_CODE
//                                                                    AND Z.BUNHO = X.BUNHO
//                                                                  GROUP BY  Z.FKOCS1003, Z.HOSP_CODE, Z.FKOUT1003)) F
//                                  WHERE A.HOSP_CODE        = :f_hosp_code
//                                    AND A.BUNHO            LIKE :f_bunho
//                                    AND (A.FKOUT1003 IS NULL OR A.FKOUT1003 = :f_pk1001)
//                                    --
//                                    AND NVL(A.IF_DATA_SEND_YN, 'N')  = :f_send_yn
//                                    -- ACTING_DATE
//                                    AND (   NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, ORDER_DATE)))  = :f_acting_date 
//                                         OR (    A.ORDER_DATE   = :f_acting_date 
//                                             AND A.JUNDAL_PART IN ('HOM', 'PA')
//                                             --AND A.ACTING_DATE  IS NULL
//                                            )
//                                        )                                    
//                                    -- MASTER
//                                    AND A.BUNHO                          = :f_bunho
//                                    AND NVL(A.ACTING_DATE, A.ORDER_DATE) = :f_acting_date 
//                                    AND A.GWA                            = :f_gwa
//                                    AND A.DOCTOR                         = :f_doctor
//                                    --AND AA.GUBUN                      (+)= :f_gubun
//                                    --AND AA.CHOJAE                        = :f_chojae 
//                                    /*
//                                    ( 
//                                          (
//                                            'N' = 'Y'
//                                            AND
//                                            A.FKOUT1003 = '237465'
//                                          )
//                                          OR
//                                          (
//                                            'N' != 'Y'
//                                            AND A.FKOUT1001        = '237465'
//                                            AND A.BUNHO            = '000000100'
//                                            AND A.ORDER_DATE       = '2012/11/08'
//                                            AND NVL(A.IF_DATA_SEND_YN, 'N' ) = 'N'
//                                            AND A.GWA              = '01'
//                                            AND A.DOCTOR           = '0110001'
//                                            AND NVL(A.SUNAB_YN, 'N')  = 'N'
//                                          )
//                                        )
//                                    */
//                                    -- ???
//                                    AND A.NALSU            >= 0
//                                    
//                                                                        --AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
//                                    AND NVL(A.DC_YN,'N')   = 'N'
//                                    AND NVL(A.MUHYO,'N')   = 'N'
//                                    --
//                                    AND AA.PKOUT1001    (+)= A.FKOUT1001
//                                    -- AND AA.NAEWON_YN    (+)= 'E'                                    
//                                    -- HANGMOG_CODE
//                                    AND B.HOSP_CODE        = A.HOSP_CODE
//                                    AND B.HANGMOG_CODE     = A.HANGMOG_CODE
//                                    -- ORDER_GUBUN
//                                    AND C.HOSP_CODE        (+)= A.HOSP_CODE
//                                    AND C.CODE_TYPE        (+)= 'ORDER_GUBUN_BAS'
//                                    AND C.CODE             (+)= SUBSTR(A.ORDER_GUBUN, 2, 1)
//                                    -- ??
//                                    AND D.HOSP_CODE        (+)= A.HOSP_CODE
//                                    AND D.SPECIMEN_CODE    (+)= A.SPECIMEN_CODE
//                                    -- ??
//                                    AND E.HOSP_CODE        = B.HOSP_CODE
//                                    AND E.SG_CODE          = B.SG_CODE
//
//                                    AND F.HOSP_CODE        (+)= A.HOSP_CODE
//                                    AND F.FKOUT1003        (+)= A.FKOUT1003
//                                    AND F.FKOCS1003        (+)= A.PKOCS1003
//                                  ORDER BY ORDER_BY_KEY";
                    #endregion

                    grdEdit.ExecuteQuery = GetGrdEdit;
                }
                else
                {
                    //ORDERTRANSGrdEditIGubunRequest
                    #region deleted by Cloud
//                    QuerySQL = @"SELECT   :f_pk1001                                                    pk1001
//                                          , A.PKOCS2003                                                PKOCS 
//                                          , A.GROUP_SER                                                GROUP_SER
//                                          , NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME
//                                          , A.HANGMOG_CODE                                             HANGMOG_CODE 
//                                          , B.HANGMOG_NAME                                             HANGMOG_NAME  
//                                          , A.SPECIMEN_CODE                                            SPECIMEN_CODE
//                                          , D.SPECIMEN_NAME                                            SPECIMEN_NAME
//                                          , A.SURYANG                                                  SURYANG
//                                          , A.ORD_DANUI                                                ORD_DANUI
//                                          , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME
//                                          , A.DV_TIME                                                  DV_TIME 
//                                          , A.DV                                                       DV
//                                          , A.NALSU                                                    NALSU
//                                          , A.JUSA                                                     JUSA
//                                          , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME
//                                          , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', A.JUSA_SPD_GUBUN)  JUSA_SPD_NAME
//                                          , A.BOGYONG_CODE                                             BOGYONG_CODE
//                                          --, CASE WHEN B.ORDER_GUBUN IN ('C','D') THEN FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE) 
//                                          --       ELSE A.BOGYONG_CODE
//                                          --  END BOGYONG_NAME
//                                          , FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
//                                          , NVL(A.EMERGENCY, 'N')                                      EMERGENCY                                
//                                          , A.JUNDAL_PART                                              JUNDAL_PART 
//                                          , A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN
//                                          , ''                                                         DANGIL_GUMSA_ORDER_YN
//                                          , A.OCS_FLAG                                                 OCS_FLAG
//                                          , A.ORDER_GUBUN                                              ORDER_GUBUN
//                                          , A.BUNHO                                                    BUNHO
//                                          , A.ORDER_DATE                                               ORDER_DATE
//                                          , A.INPUT_GWA                                                GWA
//                                          , A.INPUT_DOCTOR                                             DOCTOR
//                                          , A.SEQ                                                      SEQ
//                                          , A.PKOCS2003                                                PKOCS1003
//                                          , A.SUB_SUSUL                                                SUB_SUSUL
//                                          , A.ACTING_DATE                                              ACTING_DATE
//                                          , CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN NULL    
//                                               ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))    
//                                            END HOPE_DATE
//                                          , A.SUNAB_DATE                                               SUNAB_DATE
//                                          , 'N'                                                        HOME_CARE_YN
//                                          , NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN 
//                                          , A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN
//                                          , E.BUN_CODE                                                 BUN_CODE
//                                          , B.INPUT_CONTROL                                            INPUT_CONTROL  
//                                          , B.ORDER_GUBUN                                              ORDER_GUBUN_BAS 
//                                          , CASE WHEN A.JUNDAL_PART in ('HOM') THEN 'Y'
//                                                 WHEN A.ACTING_DATE IS NOT NULL THEN 'Y'
//                                                 ELSE  'N'
//                                            END ACTING_YN 
//                                          , :f_send_yn                                                 SELECT_YN   
//                                          , A.IF_DATA_SEND_YN                                          SEND_YN    
//                                          --, TRIM(LPAD(TO_CHAR(C.SORT_KEY), 2, '0'))
//                                          --|| TRIM(TO_CHAR(A.SEQ, '00000000000')) || TRIM(TO_CHAR(NVL(A.BOM_SOURCE_KEY, A.PKOCS2003), '00000000000'))
//                                          --|| CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9'
//                                          --       ELSE '0'
//                                          --   END 
//                                          --|| TRIM(TO_CHAR(A.PKOCS2003, '00000000000'))   ORDER_BY_KEY  
//
//                                         , TRIM(LPAD(TO_CHAR(C.SORT_KEY), 2, '0'))
//                                          || TRIM(TO_CHAR(A.GROUP_SER, '0000000000'))
//                                          || TRIM(TO_CHAR(NVL(A.BOM_SOURCE_KEY, A.PKOCS2003), '00000000000'))
//                                          || CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9'
//                                                 ELSE '0'
//                                             END 
//                                          || TRIM(TO_CHAR(A.SEQ, '00000000000')) 
//                                          || TRIM(TO_CHAR(A.PKOCS2003, '00000000000'))   ORDER_BY_KEY 
//                                    FROM  OCS2003 A
//                                         ,OCS0103 B
//                                         ,OCS0132 C
//                                         ,OCS0116 D
//                                         ,BAS0310 E
//                                    WHERE A.HOSP_CODE        = :f_hosp_code
//                                    AND ( 
//                                          (
//                                            :f_send_yn = 'Y'
//                                            AND
//                                            A.FKINP3010 = :f_pk1001
//                                          )
//                                          OR
//                                          (
//                                            :f_send_yn != 'Y'
//                                            AND A.FKINP1001        = :f_pk1001
//                                            AND A.BUNHO            = :f_bunho
//                                            AND A.ORDER_DATE       = :f_order_date
//                                            AND NVL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn
//                                            AND A.INPUT_GWA        = :f_gwa
//                                            AND A.INPUT_DOCTOR     = :f_doctor
//                                          )
//                                        )
//                                      AND A.NALSU            >= 0
//                                      --AND NVL(A.DC_YN,'N')   = 'N'
//                                      AND ( (SUBSTR(A.ORDER_GUBUN, 2, 1)   NOT IN  ('C','D')
//                                               AND NVL(A.DC_YN,'N')   = 'N')
//                                            OR 
//                                            (SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('C','D')))
//                                      AND NVL(A.MUHYO,'N')   = 'N'     
//                                      AND NVL(A.NDAY_YN,'N') = 'N'
//                                      AND B.HOSP_CODE(+)     = A.HOSP_CODE
//                                      AND B.HANGMOG_CODE(+)  = A.HANGMOG_CODE
//                                      AND A.ORDER_DATE BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
//                                      AND C.HOSP_CODE(+)     = A.HOSP_CODE
//                                      AND C.CODE     (+)     = SUBSTR(A.ORDER_GUBUN, 2, 1)
//                                      AND C.CODE_TYPE(+)     = 'ORDER_GUBUN_BAS'
//                                      AND D.HOSP_CODE(+)     = A.HOSP_CODE
//                                      AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
//                                      AND E.HOSP_CODE(+)     = B.HOSP_CODE
//                                      AND E.SG_CODE(+)       = B.SG_CODE
//                                      AND A.ORDER_DATE BETWEEN E.SG_YMD AND NVL(E.BULYONG_YMD, '9998/12/31')
//                                    --ORDER BY NVL(A.ACTING_DATE,NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),A.GROUP_SER, A.SEQ 
//                                      ORDER BY ORDER_BY_KEY ";
                    #endregion

                    grdEdit.ExecuteQuery = GetGrdEditIGubun;
                }
                //grdEdit.QuerySQL = QuerySQL;
            }

            //SQL문체크
            //if (grdEdit.QuerySQL != "")
            //{
            //    if (grdEdit.QueryLayout(false))
            //    {
            //        //그리트디폴트이미지셋팅
            //        this.SettingDefaultImageGrid();
            //    }
            //}

            if (grdEdit.QueryLayout(true))
            {
                //그리트디폴트이미지셋팅
                this.SettingDefaultImageGrid();
            }
        }

        #region deleted by Cloud
//        private string SelectListQuerySQL(string str)
//        {
//            string QuerySQL = "";
//            switch (str)
//            {
//                case "0":
//                    if (this.mIOGubun == "O")  //외래오더
//                    {
//                        if (this.mSend_YN == "N")　//未転送
//                        {
//                            // ORDERTRANSGrdListNonSendYnRequest
//                            #region deleted by Cloud
////                            QuerySQL = @"SELECT  ''                                                  fkout1001
////                                        , A.BUNHO                                                    BUNHO
////                                        , F.SUNAME                                                   SUNAME
////                                        , NVL(A.ACTING_DATE, A.ORDER_DATE)                           ACTING_DATE
////                                        --, A.ORDER_DATE                                             ORDER_DATE
////                                        , A.GWA                                                      GWA
////                                        , FN_BAS_LOAD_GWA_NAME(A.GWA, TRUNC(SYSDATE))                GWA_NAME
////                                        , A.DOCTOR                                                   DOCTOR
////                                        , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, TRUNC(SYSDATE))          DOCTOR_NAME
////                                        , NVL(MAX(AA.GUBUN), '##')                                   GUBUN
////                                        , FN_BAS_LOAD_GUBUN_NAME(NVL(MAX(AA.GUBUN), '##') , TRUNC(SYSDATE)) GUBUN_NAME
////                                        , DECODE(TRIM(MAX(A.IF_DATA_SEND_DATE)), NULL, 'N', 'Y')       SENDED_YN
////                                        --, AA.CHOJAE                                                  CHOJAE
////                                        , MAX(AA.NAEWON_YN)                                            NAEWON_YN
////                                        -- SORT
////                                        , TO_CHAR(NVL(A.ACTING_DATE, A.ORDER_DATE), 'YYYYMMDD')
////                                          || A.GWA
////                                          || A.DOCTOR                                                 
////                                          --|| AA.GUBUN                                                
////                                          --|| AA.CHOJAE                                               
////                                                                                                     ORDER_BY_KEY 
////                                   FROM  OCS1003 A
////                                       , OUT1001 AA
////                                       , (
////                                          SELECT A.*
////                                            FROM OCS0103 A
////                                           WHERE A.HOSP_CODE           = :f_hosp_code
////                                             AND A.START_DATE          = (SELECT MAX(Z.START_DATE)
////                                                                            FROM OCS0103 Z
////                                                                           WHERE Z.HOSP_CODE       = A.HOSP_CODE
////                                                                             AND Z.HANGMOG_CODE    = A.HANGMOG_CODE
////                                                                             AND Z.START_DATE      <= :f_acting_date
////                                                                             AND (   Z.END_DATE    IS NULL
////                                                                                  OR Z.END_DATE    >= :f_acting_date 
////                                                                                 )
////                                                                          )
////                                             AND (   A.END_DATE    IS NULL
////                                                  OR A.END_DATE    >= :f_acting_date 
////                                                 )
////                                         )       B
////                                       , OCS0132 C             
////                                       , OCS0116 D
////                                       , (
////                                          SELECT A.*
////                                            FROM BAS0310 A
////                                           WHERE A.HOSP_CODE           = 'K01'
////                                             AND A.SG_YMD              = (SELECT MAX(Z.SG_YMD)
////                                                                            FROM BAS0310 Z
////                                                                           WHERE Z.HOSP_CODE       = A.HOSP_CODE
////                                                                             AND Z.SG_CODE         = A.SG_CODE
////                                                                             AND Z.SG_YMD          <= :f_acting_date
////                                                                             AND (   Z.BULYONG_YMD IS NULL
////                                                                                  OR Z.BULYONG_YMD >= :f_acting_date 
////                                                                                 )
////                                                                          )
////                                             AND (   A.BULYONG_YMD IS NULL
////                                                  OR A.BULYONG_YMD >= :f_acting_date 
////                                                 )
////                                         )       E
////                                       , OUT0101 F 
////                                  WHERE A.HOSP_CODE        = :f_hosp_code
////                                    AND A.BUNHO            LIKE :f_bunho
////                                    --
////                                    AND NVL(A.IF_DATA_SEND_YN, 'N')  = 'N'
////                                    -- ACTING_DATE
////                                    AND (   NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, ORDER_DATE)))  <= :f_acting_date
////                                         OR (    A.ORDER_DATE   <= :f_acting_date
////                                             AND A.JUNDAL_PART IN ('HOM', 'PA')
////                                             --AND A.ACTING_DATE  IS NULL
////                                            )
////                                        )                                    
////                                    -- MASTER
////                                    /*
////                                    AND ( 
////                                          (
////                                            'N' = 'Y'
////                                            AND
////                                            A.FKOUT1003 = '237465'
////                                          )
////                                          OR
////                                          (
////                                            'N' != 'Y'
////                                            AND A.FKOUT1001        = '237465'
////                                            AND A.BUNHO            = '000000100'
////                                            AND A.ORDER_DATE       = '2012/11/08'
////                                            AND NVL(A.IF_DATA_SEND_YN, 'N' ) = 'N'
////                                            AND A.GWA              = '01'
////                                            AND A.DOCTOR           = '0110001'
////                                            AND NVL(A.SUNAB_YN, 'N')  = 'N'
////                                          )
////                                        )
////                                    */
////                                    -- ???
////                                    AND A.NALSU            >= 0
////                                    --AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
////                                    AND NVL(A.DC_YN,'N')   = 'N'
////                                    AND NVL(A.MUHYO,'N')   = 'N'
////                                    --
////                                    AND AA.PKOUT1001       = A.FKOUT1001 
////                                    -- AND AA.NAEWON_YN       = 'E'                                    
////                                    -- HANGMOG_CODE
////                                    AND B.HOSP_CODE        = A.HOSP_CODE
////                                    AND B.HANGMOG_CODE     = A.HANGMOG_CODE
////                                    -- ORDER_GUBUN
////                                    AND C.HOSP_CODE        (+)= A.HOSP_CODE
////                                    AND C.CODE_TYPE        (+)= 'ORDER_GUBUN_BAS'
////                                    AND C.CODE             (+)= SUBSTR(A.ORDER_GUBUN, 2, 1)
////                                    -- GUMSA
////                                    AND D.HOSP_CODE        (+)= A.HOSP_CODE
////                                    AND D.SPECIMEN_CODE    (+)= A.SPECIMEN_CODE
////                                    -- JUMSU
////                                    AND E.HOSP_CODE        = B.HOSP_CODE
////                                    AND E.SG_CODE          = B.SG_CODE
////                                    -- HWANJA NAME
////                                    AND F.HOSP_CODE           = A.HOSP_CODE
////                                    AND F.BUNHO               = A.BUNHO
////                                  GROUP BY
////                                          A.BUNHO
////                                        , F.SUNAME                                                    
////                                        , NVL(A.ACTING_DATE, A.ORDER_DATE)                           
////                                        --, A.ORDER_DATE                                               
////                                        , A.GWA   
////                                        , A.DOCTOR                                         
////                                        --, AA.GUBUN                                                   
////                                        --, AA.CHOJAE                                                  
////                                        -- SORT
////                                        , TO_CHAR(NVL(A.ACTING_DATE, A.ORDER_DATE), 'YYYYMMDD')
////                                          || A.GWA
////                                          || A.DOCTOR                                                 
////                                          --|| AA.GUBUN                                                
////                                          --|| AA.CHOJAE                                                
////                                  ORDER BY ORDER_BY_KEY DESC";
//                            #endregion
//                        }
//                        else //転送済み
//                        {
//                            // ORDERTRANSGrdListSendYnRequest
//                            #region deleted by Cloud
////                            QuerySQL = @"SELECT A.PKOUT1003                                                 FKOUT1001 
////                                            , A.BUNHO                                                       BUNHO
////                                            , C.SUNAME                                                      SUNAME        
////                                            , A.ACTING_DATE                                                 ACTING_DATE
////                                            , A.GWA                                                         GWA
////                                            , FN_BAS_LOAD_GWA_NAME ( A.GWA, A.ACTING_DATE )                 GWA_NAME
////                                            , A.DOCTOR                                                      DOCTOR
////                                            , FN_BAS_LOAD_DOCTOR_NAME ( A.DOCTOR, A.ACTING_DATE)            DOCTOR_NAME                            
////                                            , A.GUBUN                                                       GUBUN
////                                            , ''                                                            GUBUN_NAME
////                                            --, D.GUBUN_NAME                                                  GUBUN_NAME
////                                            , TO_CHAR(A.ACTING_DATE, 'YYYYMMDD')
////                                          || A.GWA
////                                          || A.DOCTOR                                                 
////                                          || A.GUBUN                                                ORDER_BY_KEY
////                                    FROM OUT1003 A
////                                       , OUT1001 B
////                                       , OUT0101 C
////                                       --, BAS0210 D
////                                     WHERE A.HOSP_CODE = :f_hosp_code 
////                                       AND A.BUNHO     = :f_bunho
////                                       AND B.HOSP_CODE(+) = A.HOSP_CODE
////                                       AND B.BUNHO(+)     = A.BUNHO
////                                       AND B.PKOUT1001(+) = A.FKOUT1001
////                                       AND C.HOSP_CODE = A.HOSP_CODE
////                                       AND C.BUNHO     = A.BUNHO
////                                       --AND D.HOSP_CODE = A.HOSP_CODE
////                                       --AND D.GUBUN     = A.GUBUN
////                                       --AND NVL(B.NAEWON_DATE, A.ACTING_DATE) BETWEEN D.START_DATE
////                                       --                  AND NVL(D.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
////                                       AND EXISTS (SELECT 'Y' FROM OCS1003 Z WHERE Z.HOSP_CODE = A.HOSP_CODE
////                                                                               AND Z.BUNHO     = A.BUNHO
////                                                                               AND Z.FKOUT1003 = A.PKOUT1003
////                                                                               AND Z.IF_DATA_SEND_YN = 'Y')
////                                    ORDER BY ORDER_BY_KEY DESC";
//                            #endregion
//                        }
//                    }
//                    else  //입원오더
//                    {
//                        // ORDERTRANSGrdListRequest
//                        #region deleted by Cloud
////                        if (this.mSend_YN == "N")
////                        {
////                            QuerySQL = @"SELECT DISTINCT A.FKINP1001                                    FKINP1001
////                                              , A.BUNHO                                                   BUNHO 
////                                              , C.SUNAME                                                  SUNAME
////                                              , B.IPWON_DATE                                              IPWON_DATE
////                                              , B.IPWON_TIME                                              IPWON_TIME
////                                              , A.INPUT_GWA                                               GWA
////                                              , A.INPUT_DOCTOR                                            DOCTOR
////                                              , FN_BAS_LOAD_GWA_NAME ( A.INPUT_GWA, A.ORDER_DATE )        GWA_NAME 
////                                              , FN_BAS_LOAD_DOCTOR_NAME ( A.INPUT_DOCTOR, A.ORDER_DATE)   DOCTOR_NAME 
////                                              , D.GUBUN
////                                              --, FN_BAS_LOAD_GUBUN_NAME(D.GUBUN, TRUNC(SYSDATE))         GUBUN_NAME
////                                              , E.GUBUN_NAME                                              GUBUN_NAME 
////                                              , NVL(E.GONGBI_YN,'Y')                                      GONGBI_YN
////                                              , B.CHOJAE
////                                              , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE )                CHOJAE_NAME                                            
////                                              , D.PKINP1002 
////                                              , MAX(NVL(A.ACTING_DATE, A.ORDER_DATE))                     ACTING_DATE 
////                                              , MAX(NVL(A.ACTING_DATE, A.ORDER_DATE))                     ORDER_DATE
////                                              , D.GUBUN                                                   GUBUN_OLD
////                                              , B.CHOJAE                                                  CHOJAE_OLD
////                                              , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 1)   GONGBI_CODE1
////                                              , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 2)   GONGBI_CODE2
////                                              , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 3)   GONGBI_CODE3
////                                              , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 4)   GONGBI_CODE4
////                                              , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 1), A.ORDER_DATE) GONGBI_CODE1_NAME
////                                              , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 2), A.ORDER_DATE) GONGBI_CODE2_NAME
////                                              , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 3), A.ORDER_DATE) GONGBI_CODE3_NAME
////                                              , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.ORDER_DATE, 4), A.ORDER_DATE) GONGBI_CODE4_NAME
////                                              , A.FKINP3010                                               PKOUT   
////                                              , A.IF_DATA_SEND_DATE                                       SEND_DATE 
////                                              , '1'                                                       SANJUNG_GUBUN
////                                              --, '1'                                                     SANJUNG_GUBUN_OLD
////                                              , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1' )      SANJUNG_GUBUN_NAME
////                                              , DECODE(FN_OUT_LOAD_JUBSU_GUBUN_VALID(A.BUNHO, D.GUBUN, MAX(NVL(A.ACTING_DATE, A.ORDER_DATE))),'N','1',0)    IF_VALID_YN
////                                     FROM OCS2003 A
////                                        , INP1001 B
////                                        , OUT0101 C
////                                        , INP1002 D
////                                        , BAS0210 E
////                                     WHERE A.HOSP_CODE   = :f_hosp_code 
////                                       AND A.BUNHO       = :f_bunho
////                                       --AND NVL(A.ACTING_DATE, A.ORDER_DATE) = :f_order_date 
////                                       AND NVL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn
////                                       AND NVL(A.NDAY_YN,'N') = 'N' 
////                                       AND A.NALSU            >= 0
////                                       AND NVL(A.DC_YN,'N')   = 'N'
////                                       AND B.HOSP_CODE   = A.HOSP_CODE
////                                       AND B.BUNHO       = A.BUNHO
////                                       AND B.PKINP1001   = A.FKINP1001
////                                       AND C.HOSP_CODE   = A.HOSP_CODE
////                                       AND C.BUNHO       = A.BUNHO
////                                       AND D.HOSP_CODE   = A.HOSP_CODE
////                                       AND D.BUNHO       = A.BUNHO
////                                       AND D.FKINP1001   = A.FKINP1001
////                                       AND E.HOSP_CODE   = D.HOSP_CODE
////                                       AND E.GUBUN       = D.GUBUN
////                                       AND B.IPWON_DATE BETWEEN E.START_DATE
////                                                         AND NVL(E.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
////                                   GROUP BY  DECODE(:f_send_yn, 'Y', A.FKINP3010, A.FKINP1001) 
////                                            , A.BUNHO                                                    
////                                            , C.SUNAME                                                  
////                                            , B.IPWON_DATE  
////                                            , B.IPWON_TIME                                            
////                                            , A.INPUT_GWA                                               
////                                            , A.INPUT_DOCTOR                                            
////                                            , FN_BAS_LOAD_GWA_NAME ( A.INPUT_GWA, A.ORDER_DATE )         
////                                            , FN_BAS_LOAD_DOCTOR_NAME ( A.INPUT_DOCTOR, A.ORDER_DATE)    
////                                            , D.GUBUN
////                                            , FN_BAS_LOAD_GUBUN_NAME(D.GUBUN, TRUNC(SYSDATE))           
////                                            , B.CHOJAE
////                                            , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE )                                                            
////                                            , D.PKINP1002
////                                            , A.FKINP3010
////                                            , A.ORDER_DATE
////                                            , A.IF_DATA_SEND_DATE
////                                            , A.FKINP1001
////                                            , A.ACTING_DATE
////                                            , E.GUBUN_NAME
////                                            , NVL(E.GONGBI_YN,'Y')
////                                       ORDER BY ACTING_DATE DESC ";
////                        }
////                        else
////                        {
////                            QuerySQL = @" SELECT DISTINCT  A.PKINP3010
////                                                , A.BUNHO                                                   BUNHO 
////                                                , C.SUNAME                                                  SUNAME
////                                                , B.IPWON_DATE                                              IPWON_DATE
////                                                , B.IPWON_TIME                                              IPWON_TIME
////                                                , A.GWA                                                     GWA
////                                                , A.DOCTOR                                                  DOCTOR
////                                                , FN_BAS_LOAD_GWA_NAME (A.GWA, A.ACTING_DATE)               GWA_NAME 
////                                                , FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, A.ACTING_DATE)         DOCTOR_NAME 
////                                                , D.GUBUN                                                   GUBUN
////                                                --, FN_BAS_LOAD_GUBUN_NAME(D.GUBUN, A.ACTING_DATE)            GUBUN_NAME
////                                                , E.GUBUN_NAME                                              GUBUN_NAME 
////                                                , NVL(E.GONGBI_YN,'Y')                                      GONGBI_YN
////                                                , B.CHOJAE
////                                                , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE )                CHOJAE_NAME                                            
////                                                , D.PKINP1002                                               
////                                                , A.ACTING_DATE                                             ACTING_DATE 
////                                                , A.ACTING_DATE                                             ORDER_DATE    
////                                                , D.GUBUN                                                   GUBUN_OLD
////                                                , B.CHOJAE                                                  CHOJAE_OLD
////                                                , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 1)   GONGBI_CODE1        
////                                                , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 2)   GONGBI_CODE2        
////                                                , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 3)   GONGBI_CODE3        
////                                                , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 4)   GONGBI_CODE4
////                                                , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 1), A.ACTING_DATE) GONGBI_CODE1_NAME
////                                                , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 2), A.ACTING_DATE) GONGBI_CODE2_NAME
////                                                , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 3), A.ACTING_DATE) GONGBI_CODE3_NAME
////                                                , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 4), A.ACTING_DATE) GONGBI_CODE4_NAME
////                                                , A.PKINP3010                                               PKOUT
////                                                , ''                                                        SEND_DATE 
////                                                , '1'                                                       SANJUNG_GUBUN
////                                                --, '1'                                                     SANJUNG_GUBUN_OLD
////                                                , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1' )      SANJUNG_GUBUN_NAME  
////                                                , 0                                                         IF_VALID_YN  
////                                           FROM INP3010 A
////                                              , INP1001 B
////                                              , OUT0101 C
////                                              , INP1002 D
////                                              , BAS0210 E
////                                          WHERE A.HOSP_CODE   = :f_hosp_code 
////                                            AND A.BUNHO       = :f_bunho 
////                                            AND B.HOSP_CODE   = A.HOSP_CODE
////                                            AND B.BUNHO       = A.BUNHO                                         
////                                            AND B.PKINP1001   = A.FKINP1001  
////                                            AND C.HOSP_CODE   = A.HOSP_CODE
////                                            AND C.BUNHO       = A.BUNHO
////                                            AND D.HOSP_CODE   = A.HOSP_CODE
////                                            AND D.BUNHO       = A.BUNHO
////                                            AND D.FKINP1001   = A.FKINP1001
////                                            AND E.HOSP_CODE   = D.HOSP_CODE
////                                            AND E.GUBUN       = D.GUBUN
////                                            AND B.IPWON_DATE BETWEEN E.START_DATE
////                                                              AND NVL(E.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
////                                        ORDER BY A.ACTING_DATE DESC";
////                        }
//                        #endregion
//                    }
//                    break;
//                case "1": //식사
//                    #region deleted by Cloud
////                    QuerySQL = @"SELECT DISTINCT A.FKINP1001                                         FKINP1001
////                                               , A.BUNHO                                             BUNHO
////                                               , E.SUNAME                                            SUNAME
////                                               , D.IPWON_DATE                                        IPWON_DATE
////                                               , D.IPWON_TIME                                        IPWON_TIME
////                                               , D.GWA                                               GWA
////                                               , D.DOCTOR                                            DOCTOR  
////                                               , FN_BAS_LOAD_GWA_NAME (D.GWA, D.IPWON_DATE )         GWA_NAME         
////                                               , FN_BAS_LOAD_DOCTOR_NAME (D.DOCTOR, D.IPWON_DATE)    DOCTOR_NAME 
////                                               , F.GUBUN
////                                               --, FN_BAS_LOAD_GUBUN_NAME(F.GUBUN, TRUNC(SYSDATE))  GUBUN_NAME
////                                               , G.GUBUN_NAME                                       GUBUN_NAME 
////                                               , NVL(G.GONGBI_YN,'Y')                               GONGBI_YN
////                                               , D.CHOJAE
////                                               , FN_BAS_LOAD_CODE_NAME('CHOJAE', D.CHOJAE )         CHOJAE_NAME                                            
////                                               , F.PKINP1002
////                                               , CASE WHEN C.ACTING_DATE IS NULL THEN A.ACT_DATE
////                                                 ELSE C.ACTING_DATE
////                                                 END ACTING_DATE
////                                               , ''                                                   ORDER_DATE
////                                               , F.GUBUN                                              GUBUN_OLD
////                                               , D.CHOJAE                                             CHOJAE_OLD
////                                               --, FN_OUT_LOAD_JUBSU_GONGBI_CODE('I', 'N', A.FKINP1001, A.ORDER_DATE, 1)   GONGBI_CODE1
////                                               --, FN_OUT_LOAD_JUBSU_GONGBI_CODE('I', 'N', A.FKINP1001, A.ORDER_DATE, 2)   GONGBI_CODE2
////                                               --, FN_OUT_LOAD_JUBSU_GONGBI_CODE('I', 'N', A.FKINP1001, A.ORDER_DATE, 3)   GONGBI_CODE3
////                                               --, FN_OUT_LOAD_JUBSU_GONGBI_CODE('I', 'N', A.FKINP1001, A.ORDER_DATE, 4)   GONGBI_CODE4
////                                               , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 1)   GONGBI_CODE1
////                                               , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 2)   GONGBI_CODE2
////                                               , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 3)   GONGBI_CODE3
////                                               , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 4)   GONGBI_CODE4
////                                              , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 1), ACTING_DATE) GONGBI_CODE1_NAME
////                                              , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 2), ACTING_DATE) GONGBI_CODE2_NAME
////                                              , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 3), ACTING_DATE) GONGBI_CODE3_NAME
////                                              , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 4), ACTING_DATE) GONGBI_CODE4_NAME
////                                               , ''                                                    PKOUT  
////                                               , ''                                                    SEND_DATE 
////                                               , '1'                                                   SANJUNG_GUBUN
////                                               --, '1'                                                   SANJUNG_GUBUN_OLD
////                                               , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1' )          SANJUNG_GUBUN_NAME
////                                               , DECODE(FN_OUT_LOAD_JUBSU_GUBUN_VALID(A.BUNHO, F.GUBUN, ACTING_DATE),'N','1',0)    IF_VALID_YN
////                                 FROM OCS2015 A
////                                    , OCS2005 B
////                                    , OCS2206 C
////                                    , INP1001 D
////                                    , OUT0101 E
////                                    , INP1002 F
////                                    , BAS0210 G 
////                                WHERE A.HOSP_CODE  = :f_hosp_code
////                                  AND A.BUNHO  LIKE :f_bunho || '%'
////                                  --AND A.DIRECT_GUBUN = '02'   
////                                  AND TO_DATE(:f_acting_date) >= A.DRT_DATE
////                                  AND B.HOSP_CODE   = A.HOSP_CODE
////                                  AND B.BUNHO       = A.BUNHO
////                                  AND B.FKINP1001   = A.FKINP1001
////                                  AND B.ORDER_DATE  = A.ORDER_DATE
////                                  AND B.INPUT_GUBUN = A.INPUT_GUBUN
////                                  AND B.PK_SEQ = A.PK_SEQ
////                                  AND B.DIRECT_GUBUN = '02'
////                                  AND SUBSTR(B.DIRECT_CODE,4,1) != '4'
////                                  AND SUBSTR(B.DIRECT_CODE,3,1) != '2'                            
////                                  AND C.HOSP_CODE(+) = A.HOSP_CODE
////                                  AND C.FKINP1001(+) = A.FKINP1001
////                                  AND C.FKOCS2015_SEQ(+) = A.PKOCS2015
////                                  AND CASE WHEN C.ACTING_DATE IS NOT NULL THEN 'Y'
////                                           ELSE 'N'
////                                      END = :f_send_yn
////                                  AND D.HOSP_CODE   = A.HOSP_CODE
////                                  AND D.BUNHO       = A.BUNHO
////                                  AND D.PKINP1001   = A.FKINP1001
////                                  AND E.HOSP_CODE   = A.HOSP_CODE
////                                  AND E.BUNHO       = A.BUNHO
////                                  AND F.HOSP_CODE   = A.HOSP_CODE
////                                  AND F.BUNHO       = A.BUNHO
////                                  AND F.FKINP1001   = A.FKINP1001
////                                  AND G.HOSP_CODE   = F.HOSP_CODE
////                                  AND G.GUBUN       = F.GUBUN
////                                  AND D.IPWON_DATE BETWEEN G.START_DATE
////                                                  AND NVL(G.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
////                                  --AND TO_DATE('2011/04/26') BETWEEN E.GUBUN_IPWON_DATE AND NVL(E.GUBUN_TOIWON_DATE, '9998/12/31')
////                                  GROUP BY  A.FKINP1001
////                                            , A.BUNHO
////                                            , E.SUNAME
////                                            , D.IPWON_DATE
////                                            , D.IPWON_TIME
////                                            , D.GWA
////                                            , D.DOCTOR
////                                            , F.GUBUN
////                                            , D.CHOJAE
////                                            , F.PKINP1002
////                                            , A.ORDER_DATE
////                                            , A.ACT_DATE
////                                            , C.ACTING_DATE
////                                            , A.PKOCS2015
////                                            , E.IF_VALID_YN
////                                            , G.GUBUN_NAME
////                                            , NVL(G.GONGBI_YN,'Y')
////                                ORDER BY D.IPWON_DATE , ACTING_DATE DESC ";
////                    break;
//                    #endregion
//                case "2": //외박처리 SQL문
//                    #region deleted by Cloud
////                    QuerySQL = @"SELECT DISTINCT A.FKINP1001                                   FKINP1001
////                                        , A.BUNHO                                              BUNHO
////                                        , C.SUNAME                                             SUNAME
////                                        , B.IPWON_DATE                                         IPWON_DATE
////                                        , B.IPWON_TIME                                         IPWON_TIME
////                                        , B.GWA                                                GWA
////                                        , B.DOCTOR                                             DOCTOR
////                                        , FN_BAS_LOAD_GWA_NAME (B.GWA, B.IPWON_DATE )          GWA_NAME         
////                                        , FN_BAS_LOAD_DOCTOR_NAME ( B.DOCTOR, B.IPWON_DATE)    DOCTOR_NAME 
////                                        , D.GUBUN
////                                        --, FN_BAS_LOAD_GUBUN_NAME(D.GUBUN, TRUNC(SYSDATE))      GUBUN_NAME
////                                        , E.GUBUN_NAME                                         GUBUN_NAME 
////                                        , NVL(E.GONGBI_YN,'Y')                                 GONGBI_YN
////                                        , B.CHOJAE
////                                        , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE )           CHOJAE_NAME                                            
////                                        , D.PKINP1002  
////                                        , A.OUT_DATE                                           ACTING_DATE
////                                        , A.OUT_DATE                                           ORDER_DATE 
////                                        , D.GUBUN                                              GUBUN_OLD
////                                        , B.CHOJAE                                             CHOJAE_OLD
////                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 1)   GONGBI_CODE1
////                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 2)   GONGBI_CODE2
////                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 3)   GONGBI_CODE3
////                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 4)   GONGBI_CODE4
////                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 1), A.OUT_DATE) GONGBI_CODE1_NAME
////                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 2), A.OUT_DATE) GONGBI_CODE2_NAME
////                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 3), A.OUT_DATE) GONGBI_CODE3_NAME
////                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 4), A.OUT_DATE) GONGBI_CODE4_NAME
////                                        , A.FKINP1001                                          PKOUT  
////                                        , A.IF_DATA_SEND_DATE                                  SEND_DATE 
////                                        , '1'                                                  SANJUNG_GUBUN
////                                        --, '1'                                                  SANJUNG_GUBUN_OLD
////                                        , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1' )          SANJUNG_GUBUN_NAME
////                                        , DECODE(FN_OUT_LOAD_JUBSU_GUBUN_VALID(A.BUNHO, D.GUBUN, A.OUT_DATE),'N','1',0)    IF_VALID_YN
////                                   FROM NUR1014 A
////                                      , INP1001 B
////                                      , OUT0101 C
////                                      , INP1002 D
////                                      , BAS0210 E
////                                  WHERE A.HOSP_CODE  = :f_hosp_code
////                                    AND A.BUNHO  LIKE :f_bunho || '%'   
////                                    --AND TO_DATE(:f_acting_date) BETWEEN  A.OUT_DATE and NVL(A.IN_HOPE_DATE,'9998/12/31')
////                                    AND A.WOICHUL_WOIBAK_GUBUN       = '02'
////                                    AND NVL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn
////                                    AND A.IN_TRUE_DATE IS NOT NULL
////                                    AND B.HOSP_CODE   = A.HOSP_CODE
////                                    AND B.BUNHO       = A.BUNHO
////                                    AND B.PKINP1001   = A.FKINP1001
////                                    AND C.HOSP_CODE   = A.HOSP_CODE
////                                    AND C.BUNHO       = A.BUNHO
////                                    AND D.HOSP_CODE   = A.HOSP_CODE
////                                    AND D.BUNHO       = A.BUNHO
////                                    AND D.FKINP1001   = A.FKINP1001
////                                    AND E.HOSP_CODE   = D.HOSP_CODE
////                                    AND E.GUBUN       = D.GUBUN
////                                    AND B.IPWON_DATE BETWEEN E.START_DATE
////                                                      AND NVL(E.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
////                                    --AND TO_DATE(:f_order_date) BETWEEN D.GUBUN_IPWON_DATE AND NVL(D.GUBUN_TOIWON_DATE, '9998/12/31')
////                                    ORDER BY B.IPWON_DATE ";
//                //                    break;
//                    #endregion
//                case "3":  //전과,전실처리 SQL문
//                    #region deleted by Cloud
////                    QuerySQL = @"SELECT DISTINCT  A.FKINP1001                                  FKINP1001
////                                        , A.BUNHO                                              BUNHO
////                                        , C.SUNAME                                             SUNAME
////                                        , B.IPWON_DATE                                         IPWON_DATE
////                                        , B.IPWON_TIME                                         IPWON_TIME
////                                        , B.GWA                                                GWA
////                                        , B.DOCTOR                                             DOCTOR
////                                        , FN_BAS_LOAD_GWA_NAME (B.GWA, B.IPWON_DATE )          GWA_NAME         
////                                        , FN_BAS_LOAD_DOCTOR_NAME ( B.DOCTOR, B.IPWON_DATE)    DOCTOR_NAME 
////                                        , D.GUBUN
////                                        --, FN_BAS_LOAD_GUBUN_NAME(D.GUBUN, TRUNC(SYSDATE))      GUBUN_NAME
////                                        , E.GUBUN_NAME                                         GUBUN_NAME 
////                                        , NVL(E.GONGBI_YN,'Y')                                 GONGBI_YN
////                                        , B.CHOJAE
////                                        , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE )           CHOJAE_NAME                                            
////                                        , D.PKINP1002                                          
////                                        --, NVL(MAX(A.ACTING_DATE), A.ORDER_DATE)                     ACTING_DATE 
////                                        , A.START_DATE                                         ACTING_DATE 
////                                        , A.START_DATE                                         ORDER_DATE  
////                                        , D.GUBUN                                              GUBUN_OLD
////                                        , B.CHOJAE                                             CHOJAE_OLD
////                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 1)   GONGBI_CODE1
////                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 2)   GONGBI_CODE2
////                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 3)   GONGBI_CODE3
////                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 4)   GONGBI_CODE4
////                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 1), A.START_DATE) GONGBI_CODE1_NAME
////                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 2), A.START_DATE) GONGBI_CODE2_NAME
////                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 3), A.START_DATE) GONGBI_CODE3_NAME
////                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 4), A.START_DATE) GONGBI_CODE4_NAME
////
////                                        , ''                                                   PKOUT
////                                        --, FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 1)   GONGBI_CODE_OLD1
////                                        --, FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 2)   GONGBI_CODE_OLD2
////                                        --, FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 3)   GONGBI_CODE_OLD3
////                                        --, FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 4)   GONGBI_CODE_OLD4
////                                        , A.IF_DATA_SEND_DATE                                  SEND_DATE
////                                        , '1'                                                  SANJUNG_GUBUN
////                                        --, '1'                                                  SANJUNG_GUBUN_OLD
////                                        , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1' )          SANJUNG_GUBUN_NAME   
////                                        , DECODE(FN_OUT_LOAD_JUBSU_GUBUN_VALID(A.BUNHO, D.GUBUN, A.START_DATE),'N','1',0)    IF_VALID_YN
////                                  FROM INP2004 A
////                                     , INP1001 B
////                                     , OUT0101 C
////                                     , INP1002 D
////                                     , BAS0210 E
////                                 WHERE A.HOSP_CODE   = :f_hosp_code
////                                   AND A.BUNHO  LIKE :f_bunho || '%'   
////                                   --AND TO_DATE(:f_acting_date) BETWEEN  A.START_DATE and NVL(A.TONGGYE_DATE,'9998/12/31')
////                                   AND NVL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn
////                                   AND A.TRANS_CNT != 1 
////                                   AND B.HOSP_CODE = A.HOSP_CODE    
////                                   AND B.BUNHO     = A.BUNHO
////                                   AND B.PKINP1001 = A.FKINP1001
////                                   AND C.HOSP_CODE = A.HOSP_CODE
////                                   AND C.BUNHO     = A.BUNHO
////                                   AND D.HOSP_CODE = A.HOSP_CODE
////                                   AND D.BUNHO     = A.BUNHO
////                                   AND D.FKINP1001 = A.FKINP1001
////                                   AND TO_DATE(:f_acting_date) BETWEEN D.GUBUN_IPWON_DATE AND NVL(D.GUBUN_TOIWON_DATE, '9998/12/31')
////                                   AND ( A.FROM_GWA != A.TO_GWA
////                                         OR 
////                                         A.FROM_DOCTOR != A.TO_DOCTOR
////                                         OR
////                                         A.FROM_HO_DONG1 != A.TO_HO_DONG1
////                                         OR 
////                                         A.FROM_HO_CODE1 != A.TO_HO_CODE1
////                                       )
////                                    AND A.HOSP_CODE   = E.HOSP_CODE
////                                    AND E.GUBUN       = D.GUBUN
////                                    AND B.IPWON_DATE BETWEEN E.START_DATE
////                                                      AND NVL(E.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
////                                   ORDER BY B.IPWON_DATE, A.START_DATE DESC ";
//                //                    break;
//                    #endregion
//                default:
//                    break;
//            }
//            return QuerySQL;
//        }
        #endregion

        // updated by Cloud
        private void SelectListQuerySQL(string str, XEditGrid grdList)
        {
            switch (str)
            {
                case "0":
                    if (this.mIOGubun == "O")
                    {
                        if (this.mSend_YN == "N")
                        {
                            grdList.ExecuteQuery = GetGrdListNonSendYn;
                        }
                        else
                        {
                            grdList.ExecuteQuery = GetGrdListSendYn;
                        }
                    }
                    else
                    {
                        grdList.ExecuteQuery = GetGrdList;
                    }
                    break;
                case "1":
                case "2":
                case "3":
                    grdList.ExecuteQuery = GetGrdList;
                    break;
                default:
                    break;
            }
        }

        public void DisplaySpecialColHeader(XGrid aGrd, int aRow)
        {
            if (aGrd == null || aRow < 0) return;

            try
            {
                // 수량 필드 처리
                if (aGrd.CellInfos.Contains("suryang") && aGrd[0, aGrd.CellInfos["suryang"].Col] != null)
                {
                    // 산소가산인 경우 => 분당주입량
                    if (aGrd.CellInfos.Contains("bun_code") && aGrd.GetItemString(aRow, "bun_code") == "T2")
                    {
                        aGrd[0, aGrd.CellInfos["suryang"].Col].Value = Resources.CELL_1;
                    }
                    // InputControl(시간분입력) => 시간
                    else if (aGrd.CellInfos.Contains("input_control") && aGrd.GetItemString(aRow, "input_control") == "3")
                    {
                        aGrd[0, aGrd.CellInfos["suryang"].Col].Value = Resources.CELL_2;
                    }
                    else
                    {
                        aGrd[0, aGrd.CellInfos["suryang"].Col].Value = Resources.CELL_3;
                    }
                }

                // 회수 필드 처리
                if (aGrd.CellInfos.Contains("dv"))
                {
                    if (aGrd[0, aGrd.CellInfos["dv"].Col] != null) aGrd[0, aGrd.CellInfos["dv"].Col].Value = Resources.H_TEXT_2;
                    for (int i = 0; i < aGrd.HeaderInfos.Count; i++) // Add Header에도 표시
                    {
                        if (aGrd.HeaderInfos[i].HeaderText == Resources.H_TEXT_1 ||aGrd.HeaderInfos[i].HeaderText == Resources.H_TEXT_2)
                        {
                            aGrd[0, aGrd.HeaderInfos[i].Col].Value = Resources.H_TEXT_2;
                            break;
                        }
                    }
                }

                // 날수 처리
                if (aGrd.CellInfos.Contains("nalsu") && aGrd[0, aGrd.CellInfos["nalsu"].Col] != null)
                {
                    // 산소가산인 경우 => 분당주입량
                    if (aGrd.CellInfos.Contains("bun_code") && aGrd.GetItemString(aRow, "bun_code") == "T2")
                    {
                        aGrd[0, aGrd.CellInfos["nalsu"].Col].Value = Resources.CELL_5;
                    }
                    // InputControl(시간분입력) => 분
                    else if (aGrd.CellInfos.Contains("input_control") && aGrd.GetItemString(aRow, "input_control") == "3") // 시간분입력
                    {
                        aGrd[0, aGrd.CellInfos["nalsu"].Col].Value = Resources.CELL_7;
                    }
                    else
                    {
                        aGrd[0, aGrd.CellInfos["nalsu"].Col].Value = Resources.CELL_8;
                    }
                }
                if (aGrd.CellInfos.Contains("bogyong_name") && aGrd[0, aGrd.CellInfos["bogyong_name"].Col] != null)
                {
                    if (aGrd.CellInfos.Contains("input_control") && aGrd.GetItemString(aRow, "input_control") == "2") // 주사약
                    {
                        aGrd[0, aGrd.CellInfos["bogyong_name"].Col].Value = Resources.CELL_9;
                    }
                    else if (aGrd.CellInfos.Contains("input_control") && aGrd.GetItemString(aRow, "input_control") == "A") // 처치
                    {
                        aGrd[0, aGrd.CellInfos["bogyong_name"].Col].Value = Resources.CELL_10;
                    }
                    else
                    {
                        aGrd[0, aGrd.CellInfos["bogyong_name"].Col].Value =Resources.CELL_11;
                    }
                }
            }
            catch { }
        }

        private void Post_DataValidating(object isSUCESS)
        {
            if (((bool)isSUCESS) == false)
            {
                this.fbxHoken.SetDataValue("");
                this.mCurrentListGrid.SetItemValue(this.mCurrentListGrid.CurrentRowNumber, "gubun", "");
            }
        }

        private void ClearOrderBack()
        {
            this.layOrderInfo.Reset();
            this.layRequisInfo.Reset();
        }

        private void ClickCurrentOrder(int aRowNumber)
        {
            //group_out1001
            string select_yn = "";
            Image Images = null;
            if (this.mCurrentGrid.GetItemString(aRowNumber, "select") == "Y")
            {
                select_yn = "N";
                Images = ImageList.Images[1];
            }
            else
            {
                select_yn = "Y";
                Images = ImageList.Images[0];

            }

            for (int i = 0; i < this.mCurrentGrid.RowCount; i++)
            {

                if (this.mCurrentGrid.GetItemString(aRowNumber, "group_out1001") == this.mCurrentGrid.GetItemString(i, "group_out1001"))
                {
                    //string Original = this.mCurrentGrid.GetItemString(i, "select", DataBufferType.OriginalBuffer);

                    if (this.mCurrentGrid.GetItemString(i, "select") == "X")
                    {
                        continue;
                    }

                    this.mCurrentGrid.SetItemValue(i, "select", select_yn);
                    this.mCurrentGrid[i, "select"].Image = Images;
                    if (select_yn == "N")
                    {
                        this.DeleteOrderBackTable(i);
                    }
                    else
                    {
                        this.AddOrderBackTable(i);
                    }
                    string Current = this.mCurrentGrid.GetItemString(i, "select", DataBufferType.CurrentBuffer);

                    //if (Original != Current)
                    //{
                    //    this.AddOrderBackTable(i);
                    //}
                    //else
                    //{
                    //    this.DeleteOrderBackTable(i);
                    //}
                }
            }           

            //if (this.mCurrentGrid.GetItemString(aRowNumber, "select") == "Y")
            //{
            //    this.mCurrentGrid.SetItemValue(aRowNumber, "select", "N");
            //    this.mCurrentGrid[aRowNumber, "select"].Image = ImageList.Images[1];
            //    this.DeleteOrderBackTable(aRowNumber);
            //}
            //else
            //{
            //    this.mCurrentGrid.SetItemValue(aRowNumber, "select", "Y");
            //    this.mCurrentGrid[aRowNumber, "select"].Image = ImageList.Images[0];
            //    this.AddOrderBackTable(aRowNumber);
            //}
            //string Original = this.mCurrentGrid.GetItemString(aRowNumber, "select", DataBufferType.OriginalBuffer);
            //string Current = this.mCurrentGrid.GetItemString(aRowNumber, "select", DataBufferType.CurrentBuffer);DataBufferType
            //if (Original != Current)
            //{
            //    this.AddOrderBackTable(aRowNumber);
            //}
            //else
            //{
            //    this.DeleteOrderBackTable(aRowNumber);
            //}
            this.checkSelectAll();
        }

        private void checkSelectAll()
        {
            XEditGrid grd = this.mCurrentListGrid;
            Image Images = null;

            //DataRow[] dtRow = this.layOrderInfo.LayoutTable.Select("pk1001 =" + grd.GetItemString(grd.CurrentRowNumber, "pk1001"));

            DataRow[] dtRow = this.layOrderInfo.LayoutTable.Select("bunho ='" + grd.GetItemString(grd.CurrentRowNumber, "bunho") + "' and acting_date ='" + grd.GetItemString(grd.CurrentRowNumber, "acting_date") + "' ");

            if ((dtRow.Length == this.mActCount) && (this.mActCount != 0))
            {
                this.lbSelectAll.Tag = "Y";
                this.lbSelectAll.ImageIndex = 0;
                Images = ImageList.Images[0];
            }
            else
            {
                this.lbSelectAll.Tag = "N";
                this.lbSelectAll.ImageIndex = 1;
                Images = ImageList.Images[1];
            }
        }

        private void AddOrderBackTable(int aCurrentRowNumber)
        {
            if (this.IsExistOrderBack(this.mCurrentGrid.GetItemString(aCurrentRowNumber, "pkocs"),
                                      this.mCurrentGrid.GetItemString(aCurrentRowNumber, "bunho")))
            {
                return;
            }
            this.layOrderInfo.LayoutTable.ImportRow(this.mCurrentGrid.LayoutTable.Rows[aCurrentRowNumber]);
        }

        private void DeleteOrderBackTable(int aCurrentRowNumber)
        {
            int existRowNumber = this.GetExistOrderBackRowNumber(this.mCurrentGrid.GetItemString(aCurrentRowNumber, "pkocs"),
                                                                 this.mCurrentGrid.GetItemString(aCurrentRowNumber, "bunho"));

            if (existRowNumber >= 0)
            {
                this.layOrderInfo.DeleteRow(existRowNumber);
            }
        }

        private bool IsExistOrderBack(string aPkKey, string aBunho)
        {
            for (int i = 0; i < this.layOrderInfo.RowCount; i++)
            {
                if (this.layOrderInfo.GetItemString(i, "bunho") == aBunho &&
                    this.layOrderInfo.GetItemString(i, "pkocs") == aPkKey)
                {
                    return true;
                }
            }
            return false;
        }

        private int GetExistOrderBackRowNumber(string aPkKey, string aBunho)
        {
            for (int i = 0; i < this.layOrderInfo.RowCount; i++)
            {
                if (this.layOrderInfo.GetItemString(i, "bunho") == aBunho &&
                    this.layOrderInfo.GetItemString(i, "pkocs") == aPkKey)
                {
                    return i;
                }
            }
            return -1;
        }

        private void MakeSangCombo()
        {
            string sangName = "";
            string sangCode = "";
            this.cboSangCode.DataSource = null;
            this.cboSangCode.ComboItems.Clear();
            //상병정보취득
            if (this.grdOutSang.QueryLayout(true))
            {
                for (int i = 0; i < this.grdOutSang.RowCount; i++)
                {
                    sangName = this.grdOutSang.GetItemString(i, "dis_sang_name") + " - " +
                               this.grdOutSang.GetItemString(i, "gwa_name") + " [ " +
                               this.grdOutSang.GetItemString(i, "sang_start_date_jp") + " ] ～ [ " +
                               this.grdOutSang.GetItemString(i, "sang_end_date_jp") + " ] " +
                               this.grdOutSang.GetItemString(i, "sang_end_sayu_name");
                    sangCode = i.ToString();

                    if (this.grdOutSang.GetItemString(i, "ju_sang_yn") == "Y")
                    {
                        this.cboSangCode.ComboItems.Add(sangCode, "(主) " + sangName);
                    }
                    else
                    {
                        this.cboSangCode.ComboItems.Add(sangCode, " 　  " + sangName);
                    }
                }
                this.cboSangCode.DataSource = this.cboSangCode.ComboItems;
                this.cboSangCode.ValueMember = "ValueItem";
                this.cboSangCode.DisplayMember = "DisplayItem";
                this.cboSangCode.SelectedIndex = 0;
                //this.cboSangCode.SelectedIndex = this.cboSangCode.ComboItems.Count - 1;
            }
        }

        #region unused code
//        private void MakeChojaeCombo()
//        {
//            string UserSQL = @"SELECT CODE, CODE_NAME
//                                 FROM BAS0102
//                                WHERE HOSP_CODE = :f_hosp_code
//                                  AND CODE_TYPE = :f_code_type ";
//            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();
//            layoutCombo.Reset();
//            layoutCombo.LayoutItems.Clear();
//            layoutCombo.LayoutItems.Add("code", DataType.String);
//            layoutCombo.LayoutItems.Add("code_name", DataType.String);
//            layoutCombo.InitializeLayoutTable();
//            layoutCombo.QuerySQL = UserSQL;
//            layoutCombo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//            layoutCombo.SetBindVarValue("f_code_type", "CHOJAE");

//            //if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
//            //{
//            //    this.cboChojae_Name.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
//            //}

//            //layoutCombo.SetBindVarValue("f_code_type", "JINCHAL_SANJUNG_GUBUN");

//            //if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
//            //{
//            //    this.cboSanjung_Name.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
//            //}
//        }
        #endregion

        private void SetOutListImage()
        {
            for (int i = 0; i < this.mCurrentListGrid.RowCount; i++)
            {
                this.mCurrentListGrid[i, "select"].Image = this.ImageList.Images[1];
                this.mCurrentListGrid.SetItemValue(i, "select", "N");

                if (this.mIOGubun =="O")
                {
                    // 예약환자
                    if (this.mCurrentListGrid.GetItemString(i, "reser_yn") == "Y")
                    {
                        this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[7];
                        this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].ToolTipText = this.mCurrentListGrid[i + this.grdOutList.HeaderHeights.Count, 0].ToolTipText + "/予約患者";
                    }
                    switch (this.mCurrentListGrid.GetItemString(i, "jubsu_gubun"))
                    {
                        case "07":    // 약만의 환자
                            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[8];
                            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].ToolTipText = this.mCurrentListGrid[i + this.grdOutList.HeaderHeights.Count, 0].ToolTipText + "/投薬受付";
                            break;
                        case "14":    // 긴급환자
                            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[9];
                            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].ToolTipText = this.mCurrentListGrid[i + this.grdOutList.HeaderHeights.Count, 0].ToolTipText + "/緊急";
                            break;
                        case "11":    // 건강검진
                            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[14];
                            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].ToolTipText = this.mCurrentListGrid[i + this.grdOutList.HeaderHeights.Count, 0].ToolTipText + "/`健康診断";
                            break;

                    }
                }
            }
        }

        private bool ProcessOrderSend()
        {
            ArrayList listDateArry = new ArrayList();
            bool value = false;
            //string mmsg = "";
            string mcag = "";

            //if (this.mSend_YN == "N")
            //{
            mcag = Resources.MSG_10;
            //}
            //else
            //{
            //    mcag = NetInfo.Language == LangMode.Ko ? "오더재전송처리" : "オーダ再転送処理";
            //}
            try
            {
                this.AcceptData();
                this.mCap = mcag;
                // 전송데이터체크               
                if (IsValidTransDate() == false)
                {
                    return false;
                } 

                string date = this.dtpJunsongDate.GetDataValue();

                this.mMsg = Resources.MSG_11 + date + Resources.MSG_12 + mcag + Resources.MSG_13;

                DialogResult result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return false;
                }
                //this.InitStatusBar(this.layOrderInfo.RowCount);
                //this.SetVisibleStatusBar(true);
                //this.SetStatusBar(0);

                //Service.BeginTransaction();
                string tap = this.tabDataGubun.SelectedTab.Tag.ToString();
                if (this.mSend_YN == "N")
                {
                    if ((this.layRequisInfo.RowCount > 0) && (this.ProcessRequisInfo() == false))
                    //if (this.ProcessRequisInfo() == false)
                    {
                        throw new Exception();
                    }
                }
                switch (tap)
                {
                    case "0"://오더데이터처리
                        value = ProcessOrderTrans(ref listDateArry);
                        break;
                    case "1"://식사데이터처리
                        value = ProcessSiksaTrans(ref listDateArry);
                        break;
                    case "2"://외박데이터처리
                        value = ProcessWoichulTrans(ref listDateArry);
                        break;
                    case "3"://전과전실데이터처리
                        value = ProcessJungwaTrans(ref listDateArry);
                        break;
                }
                if (value == false)
                {
                    throw new Exception();
                }

                //for (int i = 0; i < listDateArry.Count; i++)
                //{
                //    //this.SetStatusBar(i);
                //    IHIS.Framework.tcpHelper Helper = new tcpHelper();
                //    if (Helper.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), listDateArry[i].ToString()) == -1)
                //    {
                //        this.mMsg = NetInfo.Language == LangMode.Ko ? mcag + "가실패하였습니다." : mcag + "が失敗しました。";
                //        throw new Exception();
                //    }
                //}
                //Service.CommitTransaction();
            }
            catch
            {
                //Service.RollbackTransaction();
                this.mCap = mcag;
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //this.SetVisibleStatusBar(false);
            }

            //this.mMsg = NetInfo.Language == LangMode.Ko ? mcag + "가정상종료되었습니다." : mcag + "が正常に終了しました。";
            //this.mCap = mcag;
            //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool ProcessOrderCancel()
        {
            ArrayList listDateArry = new ArrayList();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            //int sang_cnt = 0;
            int order_cnt = 0;

            string mcag = Resources.MSG_14;
            try
            {
                this.AcceptData();
                this.mCap = mcag;
                // 전송데이터체크
                
                if (IsValidTransDate() == false)
                {
                    return false;
                }
                

                //DataRow[] dtRow = this.mCurrentListGrid.LayoutTable.Select("select =" + "'Y'");
                //DataRow[] dtcanRow = this.layOrderInfo.LayoutTable.Select("select =" + "'N'");
                ////if ((dtRow.Length <=0) || ((this.layOrderInfo.RowCount != 0) && (dtcanRow.Length <=0)))
                //if (((dtRow.Length <= 0) || (this.layOrderInfo.RowCount <= 0)) && (this.mCurrentGrid.RowCount > 0))
                //{
                //   this.mMsg = NetInfo.Language == LangMode.Ko ? "선택된 데이터가 없습니다." : "選択されたデータがありません。";
                //   this.mCap = mcag;
                //   XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //   return false;
                //}

                if ((this.layOrderInfo.RowCount <= 0) && (this.mCurrentGrid.RowCount > 0))
                {
                    this.mMsg = Resources.MSG_9;
                    this.mCap = mcag;
                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                this.mMsg = mcag + Resources.MSG_13;

                DialogResult result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return false;
                }
                string tap = this.tabDataGubun.SelectedTab.Tag.ToString();

                //this.InitStatusBar(this.layOrderInfo.RowCount);
                //this.SetVisibleStatusBar(true);
                //this.SetStatusBar(0);
                              

                if (this.layOrderInfo.RowCount > 0)
                {
                    if (tap == "0")      //오더처리
                    {

                        Service.BeginTransaction();

                        //string pkout1003 = layRequisInfo.GetItemString(0, "pkout");
                        string pkout1003 = mCurrentGrid.GetItemString(0, "pk1001");
                        //sang_cnt = MakeIFS1004("SANG", mIOGubun, pkout1003, "N");

                        order_cnt = MakeIFS1004("ORDER", mIOGubun, pkout1003, "N");


                        Service.CommitTransaction();


                        //if (sang_cnt > 0)
                        //{
                        //    SangTrans(pkout1003);
                        //}

                        if (order_cnt > 0)
                        {
                            //오더 취소 전문
                            OrderTrans(pkout1003, "N");
                        }

                    }
                    /*
                    else
                    {
                        for (int i = 0; i < this.layOrderInfo.RowCount; i++)
                        {
                            //this.SetStatusBar(i);
                            inputList.Clear();
                            outputList.Clear();
                            inputList.Add(tap); //I_WORK_GUBUN('1': 식사, '2': 전과전실, '3': 외출외박 )
                            inputList.Add(this.layRequisInfo.GetItemValue(0, "pk1001"));     //I_FKINP1001 
                            inputList.Add(this.layRequisInfo.GetItemValue(0, "order_date")); //I_ORDER_DATE('1':식사인경우만 의미있음) 

                            if (tap == "1")      //식사
                            {
                                inputList.Add(this.layOrderInfo.GetItemString(i, "input_gubun"));         //I_INPUT_GUBUN('1':식사인경우만 의미있음)
                                inputList.Add(this.layOrderInfo.GetItemString(i, "seq"));                 //I_FK_SEQ     ('1':식사인경우 FKOCS2005_SEQ)
                                inputList.Add(this.layOrderInfo.GetItemString(i, "sunab_date"));          //I_ACTING_DATE('1':식사인경우 ACTING_DATE)
                                inputList.Add("");                                                        //I_OUT_TIME   ('1':식사인경우 NULL)
                            }
                            else if (tap == "2") //외박
                            {
                                inputList.Add("");
                                inputList.Add(this.layOrderInfo.GetItemString(i, "seq"));                 //I_FK_SEQ     ('2':외출외박인경우 0)
                                inputList.Add(this.layOrderInfo.GetItemString(i, "out_date"));            //I_ACTING_DATE('2':외출외박 OUT_DATE)
                                inputList.Add(this.layOrderInfo.GetItemString(i, "out_time"));            //I_OUT_TIME   ('2':외출외박인경우 OUT_TIME) 
                            }
                            else if (tap == "3") //전과전실
                            {
                                inputList.Add("");
                                inputList.Add(this.layOrderInfo.GetItemString(i, "seq"));                 //I_FK_SEQ      ('3': 전과전실인경우 TRANS_CNT)
                                inputList.Add(this.layOrderInfo.GetItemString(i, "order_date"));          //I_ACTING_DATE ('3'전과전실인경우 의미없음)
                                inputList.Add("");                                                        //I_OUT_TIME    ('3':전과전실인경우 NULL)  
                            }
                            inputList.Add(UserInfo.UserID);  //유저ID
                            if (ProcedureCallFunc("PR_OIF_CANCEL_ETC_TRANS", inputList) == false)
                            {
                                throw new Exception();
                            }
                        }
                    }
                     */
                }
                
                /*
                else
                {
                    if ((tap == "0") && (this.mIOGubun == "O"))  //오더처리(상담만의환자:외래환자)
                    {
                        inputList.Clear();
                        outputList.Clear();
                        inputList.Add(this.mIOGubun.ToString());
                        inputList.Add(this.layRequisInfo.GetItemString(0, "pkout"));
                        inputList.Add(0);
                        inputList.Add(UserInfo.UserID);
                        if (ProcedureCallFunc("PR_OIF_CANCEL_TRANS", inputList) == false)
                        {
                            throw new Exception();
                        }
                    }
                }
                */


                XMessageBox.Show(Resources.MSG_15, Resources.CAP_15, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                Service.RollbackTransaction();
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.CAP_EXP_2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //this.SetVisibleStatusBar(false);
            }
            //this.mMsg = NetInfo.Language == LangMode.Ko ? mcag + "가정상종료되었습니다." : mcag + "が正常に終了しました。";
            //this.mCap = mcag;
            //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool ProcessRequisInfo()
        {
            string UserSQL = "";
            string UpDataSQL = "";

            if (this.mIOGubun == "O")
            {
                UserSQL = @" UPDATE OUT1001
                                SET GUBUN      = :f_gubun,
                                    CHOJAE     = :f_chojae,
                                    SANJUNG_GUBUN = :f_sanjung_gubun --, 
                                    --UPD_FLG    = :f_update_flg  
                              WHERE HOSP_CODE  = :f_hosp_code
                                AND PKOUT1001  = :f_pk1001";
            } 
            else 
            {
                UserSQL = @" UPDATE INP1001
                                SET CHOJAE     = :f_chojae
                                    --SANJUNG_GUBUN = :f_sanjung_gubun   
                              WHERE HOSP_CODE  = :f_hosp_code
                                AND PKINP1001  = :f_pk1001";

                UpDataSQL = @" UPDATE INP1002
                                 SET GUBUN      = :f_gubun
                               WHERE HOSP_CODE  = :f_hosp_code
                                 AND FKINP1001  = :f_pk1001 
                                 AND PKINP1002  = :f_pkinp1002";
            }
            BindVarCollection item = new BindVarCollection();
            //접수데이터갱신
            for (int i = 0; i < this.layRequisInfo.RowCount; i++)
            {
                item.Clear();
                item.Add("f_hosp_code", EnvironInfo.HospCode);
                item.Add("f_pk1001", this.layRequisInfo.GetItemString(i, "pk1001"));
                item.Add("f_gubun", this.layRequisInfo.GetItemString(i, "gubun"));
                item.Add("f_chojae", this.layRequisInfo.GetItemString(i, "chojae"));
                item.Add("f_sanjung_gubun", this.layRequisInfo.GetItemString(i, "sanjung_gubun"));
                if (this.mIOGubun == "I")
                {
                    item.Add("f_pkinp1002", this.layRequisInfo.GetItemString(i, "pkinp1002"));
                }
                if (ExecuteNonQuery(UserSQL, item) == false)
                {
                    return false;
                }
                //입원시보험갱신
                if (this.mIOGubun == "I")
                {
                    if (ExecuteNonQuery(UpDataSQL, item) == false)
                    {
                        return false;
                    }
                }
                // 공비처리
                if (SetProcessGongbi(i) == false)
                {
                    return false;
                }
            }
            //OUT1003_TEMP 등록
            /*
            if (SetProcessOut1003() == false)
            {
                return false;
            }
             */
            return true;
        }

        private bool ExecuteNonQuery(string cmdText, BindVarCollection bindVals)
        {
            if (Service.ExecuteNonQuery(cmdText, bindVals) == false)
            {
                this.mMsg = Service.ErrFullMsg.ToString();
                return false;
            }
            return true;
        }

        private bool SetProcessGongbi(int cnt)
        {
            string QuerySQL = "";
            string DeleteSQL = "";
            string CheckSQL = "";
            object retVal = null;

            BindVarCollection item = new BindVarCollection();
            if (this.mIOGubun == "O")
            {
                CheckSQL = @"SELECT 'Y'
                               FROM DUAL
                              WHERE EXISTS( SELECT 'X' FROM OUT1002 
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND FKOUT1001  = :f_pk1001) ";
                DeleteSQL = @" DELETE OUT1002
                                WHERE HOSP_CODE  = :f_hosp_code
                                  AND FKOUT1001  = :f_pk1001 ";

                QuerySQL = @"INSERT INTO OUT1002
                                  ( SYS_DATE      , SYS_ID        , UPD_DATE  , UPD_ID
                                  , HOSP_CODE     , FKOUT1001     , BUNHO     , GONGBI_CODE
                                  , PRIORITY)
                             VALUES
                                  ( SYSDATE       , :f_sys_id     , SYSDATE   , :f_sys_id
                                  , :f_hosp_code  , :f_pk1001     , :f_bunho  , :f_gongbi_code
                                  , :f_priority) ";
            }
            else
            {
                CheckSQL = @"SELECT 'Y'
                               FROM DUAL
                              WHERE EXISTS( SELECT 'X' FROM INP1008 
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND FKINP1002  = :f_pkinp1002) ";
                DeleteSQL = @" DELETE INP1008
                                WHERE HOSP_CODE  = :f_hosp_code
                                  AND FKINP1002  = :f_pkinp1002 ";

                QuerySQL = @"INSERT INTO INP1008
                                  ( SYS_DATE      , SYS_ID        , UPD_DATE  , UPD_ID
                                  , HOSP_CODE     , FKINP1002     , BUNHO     , GONGBI_CODE 
                                  , PRIORITY )
                             VALUES 
                                  ( SYSDATE       , :f_sys_id     , SYSDATE   , :f_sys_id
                                  , :f_hosp_code  , :f_pkinp1002  , :f_bunho  , :f_gongbi_code
                                  , :f_priority) ";
            }
            item.Clear();
            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_pk1001", this.layRequisInfo.GetItemString(cnt, "pk1001"));
            if (this.mIOGubun == "I")
            {
                item.Add("f_pkinp1002", this.layRequisInfo.GetItemString(cnt, "pkinp1002"));
            }
            //접수시공비체크
            retVal = Service.ExecuteScalar(CheckSQL, item);
            if (Service.ErrCode != 0)
            {
                this.mMsg = Service.ErrFullMsg.ToString();
                return false;
            }
            if ((retVal != null) && (retVal.ToString().Equals("Y")))
            {
                //접수공비삭제
                if (ExecuteNonQuery(DeleteSQL, item) == false)
                {
                    return false;
                }
            }
            //접수공비등록
            for (int j = 1; j < mMaxGongbi; j++)
            {
                string gongbi_code = "";
                gongbi_code = this.layRequisInfo.GetItemString(cnt, "gongbi_code" + j.ToString());

                if (gongbi_code != "")
                {
                    item.Clear();
                    item.Add("f_hosp_code", EnvironInfo.HospCode);
                    item.Add("f_sys_id", UserInfo.UserID);
                    item.Add("f_pk1001", this.layRequisInfo.GetItemString(cnt, "pk1001"));
                    item.Add("f_bunho", this.layRequisInfo.GetItemString(cnt, "bunho"));
                    item.Add("f_gongbi_code", gongbi_code);
                    item.Add("f_priority", j.ToString());
                    if (this.mIOGubun == "I")
                    {
                        item.Add("f_pkinp1002", this.layRequisInfo.GetItemString(cnt, "pkinp1002"));
                    }
                    if (ExecuteNonQuery(QuerySQL, item) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool SetProcessOut1003()
        {
            BindVarCollection item = new BindVarCollection();
            
            string QuerySQL = @" INSERT INTO OUT1003_TEMP
                                        ( FKOUT1001,    GWA,        DOCTOR  )
                                 VALUES ( :f_pk1001,    :f_gwa,     :f_doctor ) ";

            for (int i = 0; i < this.layRequisInfo.RowCount; i++)
            {
                item.Clear();
                item.Add("f_pk1001", this.layRequisInfo.GetItemString(i, "pk1001"));
                item.Add("f_gwa", this.layRequisInfo.GetItemString(i, "gwa"));
                item.Add("f_doctor", this.layRequisInfo.GetItemString(i, "doctor"));
                // OUT1003_TEMP 登録
                if (ExecuteNonQuery(QuerySQL, item) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void SakuraIpwonInput(string proc_gubun)
        {
            /*
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(proc_gubun);
            inputList.Add(this.layRequisInfo.GetItemValue(0, "bunho"));
            inputList.Add(this.dtpIpwonDate.GetDataValue());
            inputList.Add(this.dtpIpwonDate.GetDataValue());
            inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "pkinp1001"));
            inputList.Add(this.mPKINP1002);
            //inputList.Add(System.Guid.NewGuid().ToString());
            //inputList.Add(System.Guid.NewGuid().ToString());
            //inputList.Add(System.Guid.NewGuid().ToString());
            //inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "doctor").Substring(2));
            inputList.Add(UserInfo.UserID);
            inputList.Add("2"); //入院：１、転入：２、退院：４
            inputList.Add(""); //退院区分

            if (!Service.ExecuteProcedure("PR_IFS_MAKE_IPWON_HISTORY", inputList, outputList))
            {
                this.mMsg = "SAKURAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg;
                this.mCap = "処理失敗";

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (outputList[1].ToString() != "0")
                {
                    this.mMsg = "SAKURAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg;
                    this.mCap = "処理失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
                string msgText = "00201" + outputList[0].ToString();

                //XMessageBox.Show(msgText);

                int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);

                if (ret == -1)
                {
                    this.mMsg = "SAKURAへのデータ転送に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg;
                    this.mCap = "転送失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.mMsg = "SAKURAへのデータ転送が完了しました。";
                this.mCap = "転送完了";
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             */

        }

        private bool ProcessJungwaTrans(ref ArrayList listDateArry)
        {
            //XEditGrid GridList = this.mCurrentListGrid as XEditGrid;

            if (this.mSend_YN == "N")  //전과전실오더전송처리
            {
                SakuraIpwonInput("I");
            }
            else
            {
                SakuraIpwonInput("D");
            }
            /*
            ArrayList inputList = new ArrayList();
            if (this.mSend_YN == "N")  //전과전실오더전송처리
            {
                for (int i = 0; i < this.layOrderInfo.RowCount; i++)
                {
                    inputList.Clear();
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "bunho"));         //환자번호
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "acting_date"));   //기준일자
                    inputList.Add(this.layOrderInfo.GetItemString(i, "pk1001"));        //FKIN1001
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "pkinp1002"));     //FKIN1002
                    inputList.Add(this.layOrderInfo.GetItemString(i, "seq"));           //전과횟수
                    inputList.Add(System.Guid.NewGuid().ToString());                    //환자정보모듈UID
                    inputList.Add(System.Guid.NewGuid().ToString());                    //환자보험정보모듈UID
                    inputList.Add(System.Guid.NewGuid().ToString());                    //예약정보모듈UID
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "doctor"));        //의사
                    inputList.Add(UserInfo.UserID);                                     //작성자
                    if (SendProcedureCallFunc("PR_OIF_MAKE_MOVE_GWA_BED", inputList, ref listDateArry) == false)
                    {
                        return false;
                    }
                }
            }
            else //전과전실오더재전송처리
            {
                inputList.Clear();
                inputList.Add(this.layRequisInfo.GetItemValue(0, "bunho"));         //환자번호
                inputList.Add(this.layRequisInfo.GetItemValue(0, "acting_date"));   //기준일자
                inputList.Add(this.layRequisInfo.GetItemValue(0, "pk1001"));        //FKIN1001
                inputList.Add(this.layRequisInfo.GetItemValue(0, "pkinp1002"));     //FKIN1002
                inputList.Add("0");                                                 //전과횟수
                inputList.Add(System.Guid.NewGuid().ToString());                    //환자정보모듈UID
                inputList.Add(System.Guid.NewGuid().ToString());                    //환자보험정보모듈UID
                inputList.Add(System.Guid.NewGuid().ToString());                    //예약정보모듈UID
                inputList.Add(this.layRequisInfo.GetItemValue(0, "doctor"));        //의사
                inputList.Add(UserInfo.UserID);                                     //작성자
                if (SendProcedureCallFunc("PR_OIF_MAKE_MOVE_GWA_BED", inputList, ref listDateArry) == false)
                {
                    return false;
                }
            }

            */
            return true;
        }

        private bool ProcessSiksaTrans(ref ArrayList listDateArry)
        {
            BindVarCollection item = new BindVarCollection();
            ArrayList inputList = new ArrayList();

            if (this.mSend_YN == "N")  //식사오더전송처리
            {
                for (int i = 0; i < this.layOrderInfo.RowCount; i++)
                {
                    inputList.Clear();
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "bunho"));     //환자번호
                    inputList.Add(this.dtpJunsongDate.GetDataValue());              //전송일자
                    inputList.Add(this.layOrderInfo.GetItemString(i, "pk1001"));    //FKIN1001
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "pkinp1002")); //FKIN1002
                    inputList.Add(this.layOrderInfo.GetItemString(i, "seq"));       //식사횟수
                    inputList.Add(System.Guid.NewGuid().ToString());                //환자정보모듈UID
                    inputList.Add(System.Guid.NewGuid().ToString());                //환자보험정보모듈UID
                    inputList.Add(System.Guid.NewGuid().ToString());                //예약정보모듈UID
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "doctor"));    //의사
                    inputList.Add(UserInfo.UserID);                                 //작성자
                    // 식사프로시저처리함수
                    if (SendProcedureCallFunc("PR_OIF_MAKE_MEAL_OUT", inputList, ref listDateArry) == false)
                    {
                        return false;
                    }
                    if (this.mSend_YN == "N")
                    {
                        string cmdTex = @"INSERT INTO OCS2206 
                                         ( SYS_DATE             , SYS_ID            , UPD_DATE          , UPD_ID
                                         , HOSP_CODE            , BUNHO             , FKINP1001         , ORDER_DATE
                                         , INPUT_GUBUN          , FKOCS2015_SEQ     , ACTING_DATE       , SEQ
                                         , VALID)
                                VALUES
                                         ( SYSDATE              , :f_sys_id         , SYSDATE           , :f_sys_id
                                         , :f_hosp_code         , :f_bunho           , :f_pk1001         , :f_order_date
                                         , :f_input_gubun       , :f_trans_cnt       , :f_acting_date      
                                         ,(SELECT NVL(MAX(SEQ), 0) + 1 NEW_SEQ
                                             FROM OCS2206 
                                            WHERE FKINP1001 = :f_pk1001
                                              AND FKOCS2015_SEQ = :f_trans_cnt)
                                         , 'Y')";
                        item.Clear();
                        item.Add("f_hosp_code", EnvironInfo.HospCode);
                        item.Add("f_bunho", this.layOrderInfo.GetItemString(i, "bunho"));
                        item.Add("f_trans_cnt", this.layOrderInfo.GetItemString(i, "seq"));
                        item.Add("f_sys_id", UserInfo.UserID);
                        item.Add("f_pk1001", this.layOrderInfo.GetItemString(i, "pk1001"));
                        item.Add("f_input_gubun", this.layOrderInfo.GetItemString(i, "input_gubun"));
                        //item.Add("f_acting_date", this.layOrderInfo.GetItemString(i, "acting_date"));
                        item.Add("f_acting_date", this.dtpJunsongDate.GetDataValue());
                        item.Add("f_order_date", this.layOrderInfo.GetItemString(i, "order_date"));
                        if (ExecuteNonQuery(cmdTex, item) == false)
                        {
                            return false;
                        }
                    }
                }
            }
            else //식사오더재전송처리
            {
                inputList.Clear();
                inputList.Add(this.layRequisInfo.GetItemValue(0, "bunho"));     //환자번호
                inputList.Add(this.dtpJunsongDate.GetDataValue());              //전송일자
                inputList.Add(this.layRequisInfo.GetItemValue(0, "pk1001"));    //FKIN1001
                inputList.Add(this.layRequisInfo.GetItemValue(0, "pkinp1002")); //FKIN1002
                inputList.Add("0");                                             //식사횟수
                inputList.Add(System.Guid.NewGuid().ToString());                //환자정보모듈UID
                inputList.Add(System.Guid.NewGuid().ToString());                //환자보험정보모듈UID
                inputList.Add(System.Guid.NewGuid().ToString());                //예약정보모듈UID
                inputList.Add(this.layRequisInfo.GetItemValue(0, "doctor"));    //의사
                inputList.Add(UserInfo.UserID);                                 //작성자
                // 식사프로시저처리함수
                if (SendProcedureCallFunc("PR_OIF_MAKE_MEAL_OUT", inputList, ref listDateArry) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool ProcessWoichulTrans(ref ArrayList listDateArry)
        {
            string QuerySQL = "";
            //XEditGrid GridList = this.mCurrentListGrid as XEditGrid;
            BindVarCollection item = new BindVarCollection();
            ArrayList inputList = new ArrayList();

            if (this.mSend_YN == "N")  //외박데이터전송처리
            {
                QuerySQL = @" UPDATE NUR1014
                             SET SUNAB_OUT_DATE = :f_start_date, 
                                 SUNAB_IN_DATE  = :f_end_date
                           WHERE HOSP_CODE = :f_hosp_code
                             AND FKINP1001 = :f_pk1001
                             AND OUT_DATE  = :f_out_date";
                for (int i = 0; i < this.layOrderInfo.RowCount; i++)
                {
                    item.Clear();
                    item.Add("f_hosp_code", EnvironInfo.HospCode);
                    item.Add("f_pk1001", this.layOrderInfo.GetItemString(i, "pk1001"));
                    //item.Add("f_start_date", GridList.GetItemString(GridList.CurrentRowNumber, "order_date"));
                    item.Add("f_start_date", this.layRequisInfo.GetItemValue(0, "order_date").ToString());
                    item.Add("f_end_date", this.layOrderInfo.GetItemString(i, "end_date"));
                    item.Add("f_out_date", this.layOrderInfo.GetItemString(i, "out_date"));
                    if (ExecuteNonQuery(QuerySQL, item) == false)
                    {
                        return false;
                    }
                    inputList.Clear();
                    inputList.Add(this.layOrderInfo.GetItemString(i, "bunho"));             //환자번호
                    inputList.Add(this.layOrderInfo.GetItemString(i, "out_date"));          //외박개시일
                    inputList.Add(this.layOrderInfo.GetItemString(i, "out_time"));          //외박개시시간
                    inputList.Add(this.layOrderInfo.GetItemString(i, "pk1001"));            //FKIN1001
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "pkinp1002").ToString());//FKIN1002
                    inputList.Add(this.dtpJunsongDate.GetDataValue());                      //전송일
                    inputList.Add(System.Guid.NewGuid().ToString());                        //환자정보모듈UID
                    inputList.Add(System.Guid.NewGuid().ToString());                        //환자보험정보모듈UID
                    inputList.Add(System.Guid.NewGuid().ToString());                        //예약정보모듈UID
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "doctor").ToString()); //의사
                    inputList.Add(UserInfo.UserID);                                         //작성자
                    //외박처리
                    if (SendProcedureCallFunc("PR_OIF_MAKE_WOIBAK_INPUT", inputList, ref listDateArry) == false)
                    {
                        return false;
                    }
                    //귀원처리
                    if (SendProcedureCallFunc("PR_OIF_MAKE_RETURN_INPUT", inputList, ref listDateArry) == false)
                    {
                        return false;
                    }
                }
            }
            else  //외박데이터재전송처리
            {
                inputList.Clear();
                inputList.Add(this.layRequisInfo.GetItemValue(0, "bunho"));         //환자번호
                inputList.Add(this.layRequisInfo.GetItemValue(0, "acting_date"));   //외박개시일
                inputList.Add("");                                                  //외박개시시간
                inputList.Add(this.layRequisInfo.GetItemValue(0, "pk1001"));        //FKIN1001
                inputList.Add(this.layRequisInfo.GetItemValue(0, "pkinp1002"));     //FKIN1002
                inputList.Add(this.dtpJunsongDate.GetDataValue());                  //전송일
                inputList.Add(System.Guid.NewGuid().ToString());                    //환자정보모듈UID
                inputList.Add(System.Guid.NewGuid().ToString());                    //환자보험정보모듈UID
                inputList.Add(System.Guid.NewGuid().ToString());                    //예약정보모듈UID
                inputList.Add(this.layRequisInfo.GetItemValue(0, "doctor"));        //의사
                inputList.Add(UserInfo.UserID);                                     //작성자
                //외박처리
                if (SendProcedureCallFunc("PR_OIF_MAKE_WOIBAK_INPUT", inputList, ref listDateArry) == false)
                {
                    return false;
                }
                //귀원처리
                if (SendProcedureCallFunc("PR_OIF_MAKE_RETURN_INPUT", inputList, ref listDateArry) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool SendProcedureCallFunc(string Procedure, ArrayList inputList, ref ArrayList listDateArry)
        {
            ArrayList outputList = new ArrayList();

            if (Service.ExecuteProcedure(Procedure, inputList, outputList) == false)
            {
                this.mMsg = Service.ErrFullMsg.ToString();
                return false;
            }
            if (outputList[1].ToString() != "0")
            {
                if (outputList[1].ToString() == "20OVER")
                {
                    if (Procedure == "PR_OIF_MAKE_ORDER_DATA_INP")
                    {
                        this.mMsg = Resources.MSG_16;
                        return false;
                    }
                    else
                    {
                        this.mMsg = Resources.MSG_17;
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if ((outputList[1].ToString() == "OIF INSURE MASTER ERROR") ||
                        (outputList[1].ToString() == "OIF GONGBI MASTER ERROR"))
                    {
                        this.mMsg =  Resources.MSG_18;
                    }
                    else
                    {
                        this.mMsg = outputList[1].ToString();
                    }
                    return false;
                }
            }
            //OIF1101 키셋팅
            listDateArry.Add(outputList[0]);
            return true;
        }

        private bool ProcedureCallFunc(string Procedure, ArrayList inputList)
        {
            ArrayList outputList = new ArrayList();

            if (Service.ExecuteProcedure(Procedure, inputList, outputList) == false)
            {
                this.mMsg = Service.ErrFullMsg.ToString();
                return false;
            }
            if (outputList[0].ToString() != "0")
            {
                this.mMsg = outputList[0].ToString();
                return false;
            }
            return true;
        }

        private bool SangTrans(string fkout1003)
        {
            DataTable send_list = new DataTable();

            BindVarCollection item = new BindVarCollection();
            string QuerySQL = "";

            item.Clear();
            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_fkout1003", fkout1003);

            QuerySQL = @"SELECT PKIFS1011
                                           FROM IFS1011
                                          WHERE HOSP_CODE = :f_hosp_code
                                            AND FKOUT1003 = :f_fkout1003
                                            AND IF_FLAG   = '10'";

            send_list = Service.ExecuteDataTable(QuerySQL, item);

            if (TypeCheck.IsNull(send_list) && send_list.Rows.Count == 0)
            {
                throw new Exception(Resources.EXP_3);
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            for (int i = 0; i < send_list.Rows.Count; i++)
            {
                msgText = "00181" + send_list.Rows[i]["PKIFS1011"].ToString();
                int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
                if (ret == -1)
                {
                    throw new Exception(Resources.EXP_2 + msgText);
                }
            }
            return true;
        }

        private bool OrderTrans(string fkout1003, string trans_gubun)
        {
            DataTable send_list = new DataTable();

            BindVarCollection item = new BindVarCollection();
            string QuerySQL = "";

            item.Clear();
            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_fkout1003", fkout1003);

            QuerySQL = @"SELECT PKIFS1004
                                           FROM IFS1004
                                          WHERE HOSP_CODE = :f_hosp_code
                                            AND FKOUT1003 = :f_fkout1003
                         ";

            switch (trans_gubun)
            {

                case "Y":   //trans, retrans = 10
                case "R":
                    QuerySQL = QuerySQL + " AND IF_FLAG = '10' ";
                    break;
                
                case "N":   //cancel = 20
                    QuerySQL = QuerySQL + " AND IF_FLAG = '20' ";   
                    break;
            }

            send_list = Service.ExecuteDataTable(QuerySQL, item);

            if (TypeCheck.IsNull(send_list) || send_list.Rows.Count == 0)
            {
                throw new Exception(Resources.EXP_3);
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            for (int i = 0; i < send_list.Rows.Count; i++)
            {
                msgText = "00121" + send_list.Rows[i]["PKIFS1004"].ToString();
                int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
                if (ret == -1)
                {
                    throw new Exception(Resources.EXP_4　+ msgText);
                }
                Service.debugFileWrite("[ORDER SEND Call] " + msgText);                
            }
            return true;
        }

        private int MakeIFS1004(string transGubun, string io_gubun, string pkout1003, string trans_yn)
        {
            //IFS1004テータ作成

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            int retVal = -1;
            string procedureName = "";

            inputList.Clear();
            outputList.Clear();

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(io_gubun);
            inputList.Add(pkout1003);
            inputList.Add(trans_yn);

            switch (transGubun)
            {
                case "SANG":
                    procedureName = "PR_IFS_OUTSANG_TRANS";
                    break;

                case  "ORDER":
                    procedureName = "PR_IFS_ORDER_PROC_MAIN";
                    break;
            }

            bool ret = Service.ExecuteProcedure(procedureName, inputList, outputList);

            if (TypeCheck.IsNull(outputList[1]) || outputList[1].ToString() != "1")
            {
                throw new Exception(outputList[2].ToString());
            }

            if(TypeCheck.IsInt(outputList[0]))
            {
                retVal = Int32.Parse(outputList[0].ToString());
            }

            return retVal;
        }

        private bool AccountComplete()
        {
            string QuerySQL = "";
            //string proced = "";
            XEditGrid GridList = this.mCurrentListGrid as XEditGrid;
            BindVarCollection item = new BindVarCollection();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            string pkout1003 = "0";

            inputList.Clear();
            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(this.fbxBunho.GetDataValue()); //환자번호
            inputList.Add(GridList.GetItemDateTime(GridList.CurrentRowNumber, "acting_date"));
            inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "gubun")); //보험
            inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "gwa"));//과
            inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "doctor"));//의사
            //inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "chojae"));//초재진 여부
            inputList.Add("4");//초재진 여부

            try
            {
                Service.BeginTransaction();
                //オーダ転送対象データ作成　-　//OUT1003作成
                int sang_cnt = -1;
                int order_cnt = -1;

                bool value = Service.ExecuteProcedure("PR_IFS_OUT_ORDER_MASTER_INSERT", inputList, outputList);

                if (value == false || TypeCheck.IsNull(outputList[0]) || outputList[0].ToString().Equals("-1"))
                {
                    throw new Exception(Resources.EXP_5); // 1
                }
                else
                {
                    pkout1003 = outputList[0].ToString();

                    //OCS1003に転送情報Update
                    QuerySQL = @"UPDATE OCS1003
                                        SET SUNAB_YN          = 'Y'
                                          , SUNAB_DATE        = :f_sunab_date
                                          , SUNAB_TIME        = TO_CHAR(SYSDATE, 'HH24MI')
                                          , IF_DATA_SEND_YN   = 'Y'
                                          , IF_DATA_SEND_DATE = TRUNC(SYSDATE)
                                          , FKOUT1003         = :f_fkout1003
                                      WHERE HOSP_CODE         = :f_hosp_code
                                        AND PKOCS1003         = :f_pkocs1003";

                    for (int i = 0; i < grdOCS1003.RowCount; i++)
                    {
                        if (grdOCS1003.GetItemString(i, "select") == "Y")
                        {
                            item.Clear();
                            item.Add("f_fkout1003", pkout1003);
                            item.Add("f_hosp_code", EnvironInfo.HospCode);
                            item.Add("f_pkocs1003", grdOCS1003.GetItemString(i, "pkocs"));
                            item.Add("f_sunab_date", dtpJunsongDate.GetDataValue().ToString().Replace("-", "/"));

                            if (!Service.ExecuteNonQuery(QuerySQL, item))
                            {
                                throw new Exception(Resources.EXP_6); // 2
                            }
                        }

                    }

                    sang_cnt = MakeIFS1004("SANG", mIOGubun, pkout1003, "Y");

                    //オーダ転送デーだ作成
                    order_cnt = MakeIFS1004("ORDER", mIOGubun, pkout1003, "Y");
                }

                Service.CommitTransaction();

                //オーダ SOCKET 転送
                if (sang_cnt > 0)
                {
                    SangTrans(pkout1003);
                }
                if (order_cnt > 0)
                {
                    OrderTrans(pkout1003, "Y");
                }
            }
            catch (Exception ex)
            {
                Service.RollbackTransaction();
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.CAP_9, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            XMessageBox.Show(Resources.MSG_19, Resources.CAP_19, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool ProcessOrderTrans(ref ArrayList listDateArry)
        {
            if (this.mSend_YN == "N")  //오더데이터전송처리
            {                
                if (this.mIOGubun == "O")//外来オーダ転送
                {
                    if (grdOutList.GetItemString(grdOutList.CurrentRowNumber, "sended_yn") == "Y")
                    {
                        //DialogResult dr = MessageBox.Show("既に会計したオーダです。再転送しますか？", "オーダ転送", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                        //if ( dr == DialogResult.No)
                        //{
                            AccountForcedEnd();
                            return true;
                        //}
                        //else if (dr == DialogResult.Cancel)
                        //{
                        //    return true;
                        //}
                    }
                    
                    return AccountComplete();
                }

                else //入院オーダ転送
                {
                    //入院オーダ転送ロジック
                    return true;
                }
                #region ORCA Ver
                /*
                QuerySQL = @" INSERT INTO OCS_TEMP
                             (  BUNHO, IO_GUBUN, PK_OCS_KEY  )
                      VALUES (  :f_bunho, :io_gubun, :pk_ocs ) ";

                for (int i = 0; i < this.layOrderInfo.RowCount; i++)
                {
                    item.Clear();
                    item.Add("pk_ocs", this.layOrderInfo.GetItemString(i, "pkocs"));
                    item.Add("f_bunho", this.layOrderInfo.GetItemString(i, "bunho"));
                    item.Add("io_gubun", this.mIOGubun.ToString());
                    if (ExecuteNonQuery(QuerySQL, item) == false)
                    {
                        return false;
                    }
                }
                inputList.Clear();
                inputList.Add(this.mIOGubun.ToString());
                inputList.Add(this.dtpJunsongDate.GetDataValue());
                inputList.Add(UserInfo.UserID);
                if (ProcedureCallFunc("PR_OUT_MAKE_KAIKEI_MASTER", inputList) == false)
                {
                    return false;
                }
                QuerySQL = @"SELECT DISTINCT PKOUT1003 FROM OUT1003_TEMP ";

                DataTable date = new DataTable();

                date = Service.ExecuteDataTable(QuerySQL);
                if (date == null)
                {
                    this.mMsg = Service.ErrFullMsg.ToString();
                    return false;
                }
                if (date.Rows.Count < 1)
                {
                    return true;
                }
                foreach (DataRow dtRow in date.Rows)
                {
                    inputList.Clear();
                    inputList.Add(dtRow["PKOUT1003"]);
                    inputList.Add(UserInfo.UserID);

                    if (this.mIOGubun == "O")
                    {
                        proced = "PR_OUT_CREATE_OUT2001_TEMP";
                    }
                    else
                    {
                        proced = "PR_OUT_CREATE_INP2001_TEMP";
                    }
                    if (ProcedureCallFunc(proced, inputList) == false)
                    {
                        return false;
                    }
                    inputList.Clear();
                    inputList.Add(this.fbxBunho.GetDataValue());
                    inputList.Add(this.dtpJunsongDate.GetDataValue());
                    inputList.Add(dtRow["PKOUT1003"]);
                    inputList.Add(System.Guid.NewGuid().ToString());    //환자UID
                    inputList.Add(System.Guid.NewGuid().ToString());    //보험UID
                    inputList.Add(System.Guid.NewGuid().ToString());    //오더UID
                    inputList.Add(System.Guid.NewGuid().ToString());    //상병UID
                    inputList.Add(this.layRequisInfo.GetItemValue(0, "doctor").ToString());
                    inputList.Add(UserInfo.UserID);
                    if (this.mIOGubun == "O")
                    {
                        proced = "PR_OIF_MAKE_ORDER_DATA_OUT";
                    }
                    else
                    {
                        proced = "PR_OIF_MAKE_ORDER_DATA_INP";
                    }
                    if (SendProcedureCallFunc(proced, inputList, ref listDateArry) == false)
                    {
                        return false;
                    }
                }
                 */

                #endregion
            }
            //else //오더데이터재전송처리
            //{   
            //    pkout1003 = "";

            //    pkout1003 = grdOutList.GetItemString(grdOutList.CurrentRowNumber, "pk1001");
                
            //    return OrderTrans(pkout1003);
            //}
            return true;
        }

        private string SetUserSQL()
        {
            string UserSQL = "";

            if (this.mIOGubun == "O")　   //외래
            {
                if (this.mSend_YN == "N") //미전송
                {
                    UserSQL = @"SELECT A.GONGBI_CODE
                                     --, FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, TRUNC(SYSDATE))   GONGBI_NAME
                                     , B.GONGBI_NAME
                                     , A.LAST_CHECK_DATE
                                     , A.BUDAMJA_BUNHO
                                     , A.SUGUBJA_BUNHO
                                     , DECODE(B.GONGBI_CODE, null, 'N', 'Y')    SELECT_YN 
                                     , C.PRIORITY
                                     , NVL(A.IF_VALID_YN, 'Y')
                                  FROM  OUT0105 A
                                       ,BAS0212 B 
                                       ,OUT1002 C
                                 WHERE A.HOSP_CODE      = :f_hosp_code
                                   AND A.BUNHO          = :f_bunho
                                   AND TRUNC(SYSDATE)   BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31')
                                   AND B.HOSP_CODE      = A.HOSP_CODE
                                   AND B.GONGBI_CODE    = A.GONGBI_CODE
                                   AND TRUNC(SYSDATE)   BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                                   AND C.HOSP_CODE(+)   = A.HOSP_CODE
                                   AND C.BUNHO(+)       = A.BUNHO
                                   AND C.GONGBI_CODE(+) = A.GONGBI_CODE
                                   AND C.FKOUT1001(+)   = :f_out1001
                                   ORDER BY SELECT_YN DESC, A.GONGBI_CODE";
                }
                else                     //전송후
                {
                    UserSQL = @"SELECT A.GONGBI_CODE
                                     , FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, TRUNC(SYSDATE))   GONGBI_NAME
                                     , C.LAST_CHECK_DATE
                                     , C.BUDAMJA_BUNHO
                                     , C.SUGUBJA_BUNHO
                                     , 'Y'
                                     , A.PRIORITY
                                     , NVL(C.IF_VALID_YN, 'Y')
                                  FROM  OUT1007 A
                                       ,OUT1003 B
                                       ,OUT0105 C
                                WHERE A.HOSP_CODE(+)   = :f_hosp_code
                                  AND A.FKOUT1003(+)   = :f_out1001
                                  AND A.FKOUT1003      = B.PKOUT1003
                                  AND B.BUNHO          = :f_bunho
                                  AND B.BUNHO          = C.BUNHO
                                  AND A.GONGBI_CODE    = C.GONGBI_CODE
                                  AND TRUNC(SYSDATE) BETWEEN C.START_DATE AND NVL(C.END_DATE, '9998/12/31')
                                  ORDER BY A.GONGBI_CODE";
                }
            }
            else                        //입원
            {
                if (this.mSend_YN == "N") //미전송
                {
                    UserSQL = @"SELECT A.GONGBI_CODE
                                     --, FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, TRUNC(SYSDATE))   GONGBI_NAME
                                     , B.GONGBI_NAME
                                     , A.LAST_CHECK_DATE
                                     , A.BUDAMJA_BUNHO
                                     , A.SUGUBJA_BUNHO
                                     , DECODE(B.GONGBI_CODE, null, 'N', 'Y')    SELECT_YN 
                                     , C.PRIORITY
                                     , NVL(A.IF_VALID_YN, 'Y')
                                  FROM  OUT0105 A
                                       ,BAS0212 B                      
                                       ,INP1008 C
                                 WHERE A.HOSP_CODE      = :f_hosp_code
                                   AND A.BUNHO          = :f_bunho
                                   AND TRUNC(SYSDATE)   BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31')
                                   AND B.HOSP_CODE      = A.HOSP_CODE
                                   AND B.GONGBI_CODE    = A.GONGBI_CODE
                                   AND TRUNC(SYSDATE)   BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                                   AND C.HOSP_CODE(+)   = A.HOSP_CODE
                                   AND C.BUNHO(+)       = A.BUNHO
                                   AND C.GONGBI_CODE(+) = A.GONGBI_CODE 
                                   AND C.FKINP1002(+)   = :f_pkinp1002
                                 ORDER BY A.GONGBI_CODE ";
                }
                else
                {
                    UserSQL = @"SELECT A.GONGBI_CODE
                                     , FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, TRUNC(SYSDATE))   GONGBI_NAME
                                     , C.LAST_CHECK_DATE
                                     , C.BUDAMJA_BUNHO
                                     , C.SUGUBJA_BUNHO
                                     , 'Y'    SELECT_YN 
                                     , A.PRIORITY
                                     , NVL(C.IF_VALID_YN, 'Y')
                                  FROM  INP3018 A
                                       ,INP3010 B
                                       ,OUT0105 C
                                 WHERE B.HOSP_CODE      = :f_hosp_code
                                   AND B.PKINP3010      = :f_pkout
                                   AND A.HOSP_CODE(+)   = B.HOSP_CODE
                                   AND A.FKINP3010(+)   = B.PKINP3010
                                   AND C.HOSP_CODE      = B.HOSP_CODE
                                   AND C.BUNHO          = B.BUNHO
                                   AND C.GONGBI_CODE    = A.GONGBI_CODE
                                   AND TRUNC(SYSDATE) BETWEEN C.START_DATE AND NVL(C.END_DATE, '9998/12/31')
                                 ORDER BY A.GONGBI_CODE ";                
                }
            }
            return UserSQL;
        }

        private void DisplayPaInfoHoken()
        {
            this.grdHoken.QueryLayout(true);
        }

        private void AccountForcedEnd()
        {
            XEditGrid GridList = this.mCurrentListGrid as XEditGrid;
            BindVarCollection item = new BindVarCollection();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            string pkout1003 = "0";

            //if (XMessageBox.Show("会計システムに転送せず会計済み処理しますか？", "会計処理", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //{
            //    return;
            //}


            if (this.mSend_YN == "N")  //오더데이터전송처리
            {
                if (this.mIOGubun == "O")//外来オーダ転送
                {
                    inputList.Clear();
                    inputList.Add(EnvironInfo.HospCode);
                    inputList.Add(this.fbxBunho.GetDataValue()); //환자번호
                    inputList.Add(GridList.GetItemDateTime(GridList.CurrentRowNumber, "acting_date"));
                    inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "gubun")); //보험
                    inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "gwa"));//과
                    inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "doctor"));//의사
                    //inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "chojae"));//초재진 여부
                    inputList.Add("4");//초재진 여부



                    Service.BeginTransaction();

                    try
                    {
                        bool value = Service.ExecuteProcedure("PR_IFS_OUT_ORDER_MASTER_INSERT", inputList, outputList);

                        if (value == false || TypeCheck.IsNull(outputList[0]) || outputList[0].ToString().Equals("-1"))
                        {
                            throw new Exception(Resources.EXP_5);
                        }
                        else
                        {

                            pkout1003 = outputList[0].ToString();

                            string QuerySQL = @"UPDATE OCS1003
                                        SET SUNAB_YN          = 'Y'
                                          , SUNAB_DATE        = :f_sunab_date
                                          , SUNAB_TIME        = TO_CHAR(SYSDATE, 'HH24MI')
                                          , IF_DATA_SEND_YN   = 'Y'
                                          , IF_DATA_SEND_DATE = TRUNC(SYSDATE)
                                          , FKOUT1003         = :f_fkout1003
                                      WHERE HOSP_CODE         = :f_hosp_code
                                        AND PKOCS1003         = :f_pkocs1003";

                            for (int i = 0; i < grdOCS1003.RowCount; i++)
                            {
                                if (grdOCS1003.GetItemString(i, "select") == "Y")
                                {
                                    item.Clear();
                                    item.Add("f_fkout1003", pkout1003);
                                    item.Add("f_hosp_code", EnvironInfo.HospCode);
                                    item.Add("f_pkocs1003", grdOCS1003.GetItemString(i, "pkocs"));
                                    item.Add("f_sunab_date", dtpJunsongDate.GetDataValue().ToString().Replace("-", "/"));

                                    if (!Service.ExecuteNonQuery(QuerySQL, item))
                                    {
                                        throw new Exception(Resources.EXP_6);
                                    }
                                }
                            }
                        }
                        Service.CommitTransaction();
                        XMessageBox.Show(Resources.MSG_20, Resources.CAP_20, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnList.PerformClick(FunctionType.Query);
                    }

                    catch (Exception ex)
                    {
                        Service.RollbackTransaction();
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(ex.Message, Resources.CAP_9, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 2015.11.03 Cloud updated
        /// </summary>
        /// <returns></returns>
        private bool ProcessTrans(out bool terminated)
        {
            bool process = false;
            terminated = false;

            try
            {
                // Create mml header
                HeaderInfo header = new HeaderInfo();
                // Create mml detail
                DetailInfo detail = new DetailInfo();
                detail.HiModuleItem = new HealthInsuranceModuleItem();
                detail.RdModuleItem = new List<RegisteredDiagnosisModuleItem>();
                detail.ClaimModuleItem = new ClaimModuleItem();

                // User variables
                string countryType = "";
                string healthInsuranceId = "";
                string encounterDate = "";
                bool selectedOrder = false;
                List<string> errMsgList = new List<string>();

                // Get list params request
                List<ORCATransferOrdersLstSgCodeInfo> sgCodeList = new List<ORCATransferOrdersLstSgCodeInfo>();
                List<NuroORDERTRANSUpdateOCS1003Info> dataList = new List<NuroORDERTRANSUpdateOCS1003Info>();
                for (int i = 0; i < grdOCS1003.RowCount; i++)
                {
                    // Skip records which is not selected
                    if (grdOCS1003.GetItemString(i, "select") != "Y") continue;

                    ORCATransferOrdersLstSgCodeInfo item = new ORCATransferOrdersLstSgCodeInfo();
                    item.HangmogCode = grdOCS1003.GetItemString(i, "hangmog_code");
                    item.HangmogName = grdOCS1003.GetItemString(i, "hangmog_name");
                    item.SgCode = grdOCS1003.GetItemString(i, "sg_code");
                    sgCodeList.Add(item);

                    // Only updates orders which is executed!
                    if (!TypeCheck.IsNull(grdOCS1003.GetItemString(i, "acting_date")))
                    {
                        NuroORDERTRANSUpdateOCS1003Info updItem = new NuroORDERTRANSUpdateOCS1003Info();
                        updItem.Pkocs1003 = grdOCS1003.GetItemString(i, "pkocs");
                        updItem.SunabDate = dtpJunsongDate.GetDataValue().ToString().Replace("-", "/");
                        dataList.Add(updItem);
                    }

                    // 2016.01.13 MED-6821
                    if (!selectedOrder) selectedOrder = true;
                }

                // 2016.01.13 MED-6821
                // No orders selected?
                if (!selectedOrder)
                {
                    // 選択されてるオーダがありません。一つ以上選択してください。
                    XMessageBox.Show(Resources.MSG_21, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    terminated = true;
                    goto END;
                }

                // Load base info
                ORCATransferOrdersArgs args = new ORCATransferOrdersArgs();
                args.Bunho = fbxBunho.GetDataValue();
                args.HospCode = UserInfo.HospCode;
                args.Pkout1001 = grdOutList.GetItemString(grdOutList.CurrentRowNumber, "pk1001");
                args.SgCodeItem = sgCodeList;
                ORCATransferOrdersResult res = CloudService.Instance.Submit<ORCATransferOrdersResult, ORCATransferOrdersArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    // Get Health insurance docID
                    healthInsuranceId = System.Guid.NewGuid().ToString();

                    #region Errors check

                    foreach (ORCATransferOrdersErrMsgInfo item in res.ErrMsgItem)
                    {
                        string err = "";

                        // 2016.01.13 MED-6821
                        //  Check status of all orders per each examination
                        // Message 部門でオーダが実施完了されてません。オーダを実施してください。
                        if (item.ErrCode == "2")
                        {
                            // Terminates and exits TRANS process
                            XMessageBox.Show(Resources.MSG_22, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            terminated = true;
                            goto END;
                        }

                        // Changed from error message to warning message
                        // Removed class_code empty check
                        // https://nextop-asia.atlassian.net/browse/MED-5955
                        if (item.ErrCode == "0")
                        {
                            //err = string.Format(Resources.MSG_CHECK_TRANS_001, item.HangmogName, item.HangmogCode);
                            err = string.Format(Resources.MSG_WARN_TRANS_001, item.HangmogName, item.HangmogCode);
                        }
                        //else if (item.ErrCode == "1")
                        //{
                        //    err = string.Format(Resources.MSG_CHECK_TRANS_002, item.HangmogName, item.HangmogCode);
                        //}

                        if (!TypeCheck.IsNull(err) && !errMsgList.Contains(err))
                        {
                            errMsgList.Add(err);
                        }
                    }

                    // HangmogCode does not exist in ORCA server?
                    if (errMsgList.Count > 0)
                    {
                        // ORCAにおいて、 HANGMOG_NAME [HANGMOG_CODE] が存在していません。作業が続きますか。？
                        string errMsg = string.Join(Environment.NewLine, errMsgList.ToArray());
                        if (XMessageBox.Show(errMsg, Resources.CAP_TRANS, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            // Terminates and exits TRANS process
                            terminated = true;
                            goto END;
                        }
                    }

                    #endregion

                    #region Mml Header

                    Service.WriteLog("============================================================");
                    Service.WriteLog("HEADER MODULE LOGGING START...");
                    if (res.HeaderItem != null)
                    {
                        header.CreateDate = DateTime.Parse(res.HeaderItem.SysDate);
                        header.Version = "2.3";
                        header.FacilityId = UserInfo.HospCode;
                        header.HospName = res.HeaderItem.HospName;
                        header.FacilityCode = res.HeaderItem.FacilityCode;
                        header.HospAddress = res.HeaderItem.HospAddress;
                        header.HospZipCode = res.HeaderItem.HospZipcode;
                        header.CreatorText = res.HeaderItem.CreatorText;
                        header.Bunho = fbxBunho.GetDataValue();
                        header.DepartmentCode = res.HeaderItem.DeparmentCode;

                        // Get country type
                        countryType = res.HeaderItem.CountryType;

                        Service.WriteLog("CREATE DATE       :" + header.CreateDate);
                        Service.WriteLog("FACILITY ID       :" + header.FacilityId);
                        Service.WriteLog("HOSPITAL NAME     :" + header.HospName);
                        Service.WriteLog("FACILITY CODE     :" + header.FacilityCode);
                        Service.WriteLog("HOSPITAL ADDRESS  :" + header.HospAddress);
                        Service.WriteLog("HOSPITAL ZIPCODE  :" + header.HospZipCode);
                        Service.WriteLog("CREATOR TEXT      :" + header.CreatorText);
                        Service.WriteLog("BUNHO             :" + header.Bunho);
                        Service.WriteLog("============================================================");
                    }
                    Service.WriteLog("HEADER MODULE LOGGING END.");

                    #endregion

                    #region HealthInsurance module

                    Service.WriteLog("HEALTH INSURANCE MODULE LOGGING START...");
                    if (res.HealthInsItem.Count > 0)
                    {
                        string insCode = "";
                        string insNumber = "";
                        string insStartDt = "";
                        string insEndDt = "";
                        DateTime dt;
                        int value;

                        // Set PublicHealthInsurance items
                        detail.HiModuleItem.PublicHeathInsuranceItem = new List<PublicHeathInsuranceItemInfo>();
                        foreach (ORCATransferOrdersHealthInsuranceInfo item in res.HealthInsItem)
                        {
                            PublicHeathInsuranceItemInfo pHiItem = new PublicHeathInsuranceItemInfo();

                            // Retrieves data for Company Insurance
                            if (!TypeCheck.IsNull(item.InsuranceCode)) insCode = item.InsuranceCode;
                            if (!TypeCheck.IsNull(item.InsuranceNumber)) insNumber = item.InsuranceNumber.Trim();
                            if (!TypeCheck.IsNull(item.InsuranceStartDate)) insStartDt = item.InsuranceStartDate;
                            if (!TypeCheck.IsNull(item.InsuranceEndDate)) insEndDt = item.InsuranceEndDate;
                            // Retrieves data for RegisterDiagnosis module
                            if (!TypeCheck.IsNull(item.EncounterDate)) encounterDate = item.EncounterDate;

                            // Set PublicHealthInsurance data
                            if (Int32.TryParse(item.PriorityNumber, out value) == true)
                            {
                                pHiItem.PriorityNumber = value;
                            }
                            pHiItem.ProviderName = item.ProviderName;
                            if (DateTime.TryParse(item.PublicStartDate, out dt) == true)
                            {
                                pHiItem.StartDate = dt;
                            }
                            if (DateTime.TryParse(item.PublicEndDate, out dt) == true)
                            {
                                pHiItem.EndDate = dt;
                            }

                            detail.HiModuleItem.PublicHeathInsuranceItem.Add(pHiItem);
                        }

                        // Set CompanyHealthInsurance item
                        detail.HiModuleItem.CountryType = countryType;
                        detail.HiModuleItem.DocId = healthInsuranceId;
                        detail.HiModuleItem.InsuranceCode = TypeCheck.IsNull(insCode) ? DEFAULT_CLAIM_INS_CODE : insCode;
                        detail.HiModuleItem.InsuranceNumber = TypeCheck.IsNull(insCode) ? DEFAULT_CLAIM_INS_NUMBER : insNumber;
                        if (DateTime.TryParse(insStartDt, out dt) == true)
                        {
                            detail.HiModuleItem.StartDate = dt;
                        }
                        if (DateTime.TryParse(insEndDt, out dt) == true)
                        {
                            detail.HiModuleItem.EndDate = dt;
                        }

                        Service.WriteLog("INSURANCE CODE            : " + detail.HiModuleItem.InsuranceCode);
                        Service.WriteLog("INSURANCE NUMBER          : " + detail.HiModuleItem.InsuranceNumber);
                        Service.WriteLog("COUNTRY TYPE              : " + detail.HiModuleItem.CountryType);
                        Service.WriteLog("DOCID                     : " + detail.HiModuleItem.DocId);
                        Service.WriteLog("INSURANCE START DATE      : " + detail.HiModuleItem.StartDate);
                        Service.WriteLog("INSURANCE END DATE        : " + detail.HiModuleItem.EndDate);
                        Service.WriteLog("============================================================");
                    }
                    Service.WriteLog("HEALTH INSURANCE MODULE LOGGING END.");

                    #endregion

                    #region RegisterDiagnosis module

                    Service.WriteLog("REGISTER DIAGNOSIS MODULE LOGGING START...");

                    string diagNosisCode = "";
                    int maxRowCnt = 0;
                    foreach (ORCATransferOrdersDiseaseInfo item in res.DiseaseItem)
                    {
                        if (diagNosisCode != item.DiagnosisCode)
                        {
                            // Maximum of 50 diseases
                            if (maxRowCnt > MAX_DISEASE_ITEM) break;

                            DateTime dt;

                            RegisteredDiagnosisModuleItem rdModuleItem = new RegisteredDiagnosisModuleItem();
                            rdModuleItem.DiagnosisCode = item.DiagnosisCode;
                            rdModuleItem.DiagnosisSystem = item.DiagnosisSystem;
                            //rdModuleItem.DiagnosisCategory = item.DiagnosisCategory; // Diagnosis
                            //rdModuleItem.MmlTableId = item.MmlTableId; // MML0012
                            // https://nextop-asia.atlassian.net/browse/MED-5924
                            rdModuleItem.JusangYn = item.JusangYn;

                            if (DateTime.TryParse(item.DiagnosisStartDate, out dt))
                            {
                                rdModuleItem.DiagnosisStartDate = dt;
                            }
                            if (DateTime.TryParse(item.DiagnosisEndDate, out dt))
                            {
                                rdModuleItem.DiagnosisEndDate = dt;
                            }
                            if (DateTime.TryParse(encounterDate, out dt))
                            {
                                rdModuleItem.EncounterDate = dt;
                            }

                            detail.RdModuleItem.Add(rdModuleItem);
                            maxRowCnt++;

                            Service.WriteLog("DIAGNOSIS_CODE        : " + rdModuleItem.DiagnosisCode);
                            Service.WriteLog("DIAGNOSIS_SYSTEM      : " + rdModuleItem.DiagnosisSystem);
                            Service.WriteLog("JUSANG_YN             : " + rdModuleItem.JusangYn);
                            Service.WriteLog("DIAGNOSIS_START_DATE  : " + rdModuleItem.DiagnosisStartDate);
                            Service.WriteLog("DIAGNOSIS_END_DATE    : " + rdModuleItem.DiagnosisEndDate);
                            Service.WriteLog("ENCOUNTER_DATE        : " + rdModuleItem.EncounterDate);
                            Service.WriteLog("============================================================");
                        }

                        diagNosisCode = item.DiagnosisCode;
                    }
                    Service.WriteLog("REGISTER DIAGNOSIS MODULE LOGGING END.");

                    #endregion

                    #region Claim module

                    Service.WriteLog("CLAIM MODULE LOGGING START...");

                    {
                        DateTime dt;
                        int i;
                        maxRowCnt = 0;
                        string doctorId = "";
                        string performTime = "";
                        string gwaName = "";
                        string classTime = "";
                        bool ioFlg = false;
                        List<BundleItemInfo> bundleListItem = new List<BundleItemInfo>();

                        // Set Examination fee info
                        foreach (ORCATransferOrdersClaimExaminationFeeInfo item in res.ClaimExamItem)
                        {
                            // Maximum of 20 orders
                            if (maxRowCnt > MAX_ORDER_ITEM) break;

                            // Get common info.
                            if (!TypeCheck.IsNull(item.ClsTime)) classTime = item.ClsTime;
                            ioFlg = item.IoFlag;

                            BundleItemInfo bItem = new BundleItemInfo();
                            // https://nextop-asia.atlassian.net/browse/MED-5929
                            bItem.ClassCode = TypeCheck.IsNull(item.ClsCode) ? DEFAULT_CLAIM_CLS_CODE : item.ClsCode;
                            if (Int32.TryParse(item.BundleNumber, out i))
                            {
                                bItem.BundleNumber = i;
                            }
                            bItem.HangmogCode = item.HangmogCode;

                            bundleListItem.Add(bItem);
                            maxRowCnt++;

                            Service.WriteLog("EXAMINATION_FEE.CLASS_CODE        :" + bItem.ClassCode);
                            Service.WriteLog("EXAMINATION_FEE.BUNDLE_NUMBER     :" + bItem.BundleNumber);
                            Service.WriteLog("EXAMINATION_FEE.HANGMOG_CODE      :" + bItem.HangmogCode);
                            Service.WriteLog("============================================================");
                        }

                        // Set Orders fee info
                        bool isActDtEmpty = false;
                        foreach (ORCATransferOrdersClaimOrdersFeeInfo item in res.ClaimOrdersItem)
                        {
                            // Maximum of 20 orders
                            if (maxRowCnt > MAX_ORDER_ITEM) break;

                            // 2016.01.13 MED-6821 Removed
                            //// Acting date checking
                            //if (TypeCheck.IsNull(item.ActingDate))
                            //{
                            //    isActDtEmpty = true;
                            //    // Skips record which contains empty acting_date
                            //    continue;
                            //}

                            // Get common info.
                            if (!TypeCheck.IsNull(item.DoctorId)) doctorId = item.DoctorId;
                            if (!TypeCheck.IsNull(item.DoctorId)) performTime = item.PerformTime;
                            if (!TypeCheck.IsNull(item.DoctorId)) gwaName = item.GwaName;

                            BundleItemInfo bItem = new BundleItemInfo();
                            // https://nextop-asia.atlassian.net/browse/MED-5929
                            bItem.ClassCode = TypeCheck.IsNull(item.ClsCode) ? DEFAULT_CLAIM_CLS_CODE : item.ClsCode;
                            if (Int32.TryParse(item.BundleNumber, out i))
                            {
                                bItem.BundleNumber = i;
                            }
                            bItem.HangmogCode = item.HangmogCode;
                            bItem.NumberCode = item.NumberCode;
                            bItem.Number = item.Numb;

                            bundleListItem.Add(bItem);
                            maxRowCnt++;

                            Service.WriteLog("ORDERS_FEE.CLASS_CODE        :" + bItem.ClassCode);
                            Service.WriteLog("ORDERS_FEE.BUNDLE_NUMBER     :" + bItem.BundleNumber);
                            Service.WriteLog("ORDERS_FEE.HANGMOG_CODE      :" + bItem.HangmogCode);
                            Service.WriteLog("ORDERS_FEE.NUMBER            :" + bItem.Number);
                            Service.WriteLog("============================================================");
                        }

                        // 2016.01.13 MED-6821 Removed
                        //// 未完了オーダーが残っています。作業が続きますか。？
                        //// https://nextop-asia.atlassian.net/browse/MED-5924
                        //if ((isActDtEmpty == true && XMessageBox.Show(Resources.MSG_ACTING_DATE_WARN, Resources.CAP_TRANS, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        //    /*|| bundleListItem.Count == 0*/)
                        //{
                        //    terminated = true;
                        //    return false;
                        //}

                        detail.ClaimModuleItem.BundleListItem = bundleListItem;

                        // Common info
                        detail.ClaimModuleItem.DoctorId = doctorId;
                        if (DateTime.TryParse(performTime, out dt) == true)
                        {
                            detail.ClaimModuleItem.PerformTime = dt;
                        }
                        detail.ClaimModuleItem.UidCode = healthInsuranceId;
                        detail.ClaimModuleItem.AdmitFlg = ioFlg;
                        detail.ClaimModuleItem.TimeClass = classTime;
                        detail.ClaimModuleItem.GwaName = gwaName;

                        Service.WriteLog("DETAIL.DOCTOR_ID     :" + detail.ClaimModuleItem.DoctorId);
                        Service.WriteLog("DETAIL.PERFORM_TIME  :" + detail.ClaimModuleItem.PerformTime);
                        Service.WriteLog("DETAIL.UID_CODE      :" + detail.ClaimModuleItem.UidCode);
                        Service.WriteLog("DETAIL.ADMIT_FLG     :" + detail.ClaimModuleItem.AdmitFlg);
                        Service.WriteLog("DETAIL.TIME_CLASS    :" + detail.ClaimModuleItem.TimeClass);
                        Service.WriteLog("DETAIL.GWA_NAME      :" + detail.ClaimModuleItem.GwaName);
                        Service.WriteLog("============================================================");
                    }

                    Service.WriteLog("CLAIM MODULE LOGGING END.");

                    #endregion

                    #region  Create claim.xml

                    Service.WriteLog("SEND CLAIM LOGGING START...");

                    OrdersInfo ordersInfo = new OrdersInfo(header, detail);
                    ORCAServices os = new ORCAServices(ordersInfo);

                    // Path to save mml
                    string fullPath = Path.Combine(EnvironInfo.ORCAserverInfo.TempFolder, string.Format(EnvironInfo.ORCAserverInfo.TempFileName, DateTime.Now.Ticks.ToString()));

                    // Folder is exist?
                    if (!Directory.Exists(EnvironInfo.ORCAserverInfo.TempFolder))
                    {
                        Directory.CreateDirectory(EnvironInfo.ORCAserverInfo.TempFolder);
                    }

                    if (dataList.Count == 0)
                    {
                        goto END;
                    }

                    // Save and send mml
                    if (os.SaveMmlOrders(fullPath))
                    {
                        // Send to ORCA server
                        Service.WriteLog("ORCA_IP   : " + UserInfo.OrcaIp);
                        Service.WriteLog("ORCA_PORT : " + EnvironInfo.ORCAserverInfo.OrderPort);
                        Service.WriteLog("CLAIM     : " + fullPath);

                        if (os.SendTCP(fullPath, UserInfo.OrcaIp, Int32.Parse(EnvironInfo.ORCAserverInfo.OrderPort)))
                        {
                            // Update OCS1003
                            // Fix bug https://nextop-asia.atlassian.net/browse/MED-5413

                            NuroORDERTRANSUpdateOCS1003Args updArgs = new NuroORDERTRANSUpdateOCS1003Args();
                            updArgs.Pkout1001 = grdOutList.GetItemString(grdOutList.CurrentRowNumber, "pk1001");
                            updArgs.Bunho = fbxBunho.GetDataValue();
                            updArgs.OcsUpdItem = dataList;
                            UpdateResult updRes = CloudService.Instance.Submit<UpdateResult, NuroORDERTRANSUpdateOCS1003Args>(updArgs);

                            if (updRes.ExecutionStatus == ExecutionStatus.Success && updRes.Result == true)
                            {
                                process = true;
                                Service.WriteLog("UPDATE OCS1003 SUCCEEDED!");
                                Service.WriteLog("PKOUT1001: " + updArgs.Pkout1001);
                            }
                            else
                            {
                                Service.WriteLog("UPDATE OCS1003 FAILED!");
                            }
                        }
                    }

                    Service.WriteLog("SEND CLAIM LOGGING END.");
                    Service.WriteLog("============================================================");

                    #endregion
                }

            END: ;
            }
            catch (Exception ex)
            {
                Service.WriteLog("TRANSFER ERROR!");
                Service.WriteLog(ex.Message);
            }

            return process;
        }

        private bool ProcessTransMisa(out bool terminated)
        {
            terminated = false;
            try
            {
                IMisaOrderDao misaOrderDao = DataAccess.Misa.MisaOrderDao;
                string bunho = fbxBunho.GetDataValue();
                int index = 0;
                for (int i = 0; i < bunho.Length; i++)
                {
                    if (bunho[i] != '0')
                    {
                        index = i;
                        break;
                    }
                }
                string bunhoNew = bunho.Substring(index, bunho.Length - index);
                Guid bunhoId = misaOrderDao.GetAccountId(bunhoNew);
                if (bunhoId == Guid.Empty)
                {
                    Service.WriteLog("ERROR Misa: Could not find bunhoId " + bunhoNew);
                    return false;
                }

                string doctor = grdOutList.GetItemString(grdOutList.CurrentRowNumber, "doctor");
                Guid doctorId = misaOrderDao.GetAccountId(doctor.Substring(2, doctor.Length - 2));
                if (doctorId == Guid.Empty)
                {
                    Service.WriteLog("ERROR Misa: Could not find doctorId " + doctor.Substring(2, doctor.Length - 2));
                    return false;
                }

                //Guid branhId = misaOrderDao.GetBrandId();
                //if (branhId == Guid.Empty)
                //{
                //    Service.WriteLog("ERROR Misa: Could not find branhId ");
                //    return false;
                //}

                List<HangmogInfo> lstHangmog = GetLstHangmog(bunho);
                List<SangCodeInfo> lstSangCode = GetLstSangCode();

                OrderTransMisaArgs args = new OrderTransMisaArgs();
                args.Bunho = fbxBunho.GetDataValue();
                args.HopsCode = UserInfo.HospCode;
                args.Pkout1001 = grdOutList.GetItemString(grdOutList.CurrentRowNumber, "pk1001");

                OrderTransMisaResult result = CloudService.Instance.Submit<OrderTransMisaResult, OrderTransMisaArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success)
                {

                    ISaOrderDao saOrderDao = DataAccess.Misa.SaOrderDao;
                    DbConnection connection = Db.CreateConnection(saOrderDao);
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        SaOrder saOrder = new SaOrder();
                        Guid guid;
                        if (String.IsNullOrEmpty(result.Johap))
                        {
                            saOrder.Refno = "ĐH" + result.Refno;
                            saOrder.Status = 0;
                            saOrder.Reftype = 3520;
                            saOrder.Accountobjectname = result.Suname;
                            saOrder.Accountobjectaddress = string.Format("{0} {1} {2}", result.ZipCode1, result.ZipCode2, result.Address1);
                            saOrder.Employeeid = doctorId;
                            saOrder.Iscalculatedcost = false;
                            saOrder.Exchangerate = 1;
                            saOrder.Totalamountoc = 0;
                            saOrder.Totalamount = 0;
                            saOrder.Totaldiscountamountoc = 0;
                            saOrder.Totaldiscountamount = 0;
                            saOrder.Totalvatamountoc = 0;
                            saOrder.Totalvatamount = 0;
                            saOrder.Accountobjectid = bunhoId;
                            saOrder.Branchid = new Guid(result.ReceptRefId);
                            saOrder.Currencyid = "VND";
                            saOrder.Paymenttermid = null;
                            guid = saOrderDao.Insert(trans, saOrder);
                        }
                        else
                        {
                            guid = new Guid(result.Pkout1001Ext);
                        }


                        ISaOrderDetailDao saOrderDetailDao = DataAccess.Misa.SaOrderDetailDao;
                        List<SaOrderDetail> lst = new List<SaOrderDetail>();
                        decimal totalAmount = 0;
                        foreach (HangmogInfo item in lstHangmog)
                        {
                            SaOrderDetail detail = new SaOrderDetail();
                            detail.Refid = guid;
                            detail.Description = item.HangmogName;
                            detail.Quantity = item.Suryang * item.Dv * item.Nalsu;
                            detail.Mainquantity = item.Suryang * item.Dv * item.Nalsu;
                            detail.Mainconvertrate = 1;
                            detail.Inventoryitemid = item.InventoryItemId;
                            detail.Unitid = item.UnitId;
                            detail.Unitprice = item.SalePrice1;
                            detail.Amount = item.SalePrice1 * item.Suryang * item.Dv * item.Nalsu;
                            detail.Amountoc = item.SalePrice1 * item.Suryang * item.Dv * item.Nalsu;
                            totalAmount += detail.Amount;
                            lst.Add(detail);
                        }

                        foreach (SangCodeInfo item in lstSangCode)
                        {
                            SaOrderDetail detail = new SaOrderDetail();
                            detail.Refid = guid;
                            detail.Description = item.SangCodeName;
                            detail.Quantity = 1;
                            detail.Mainquantity = 1;
                            detail.Mainconvertrate = 1;
                            detail.Inventoryitemid = item.InventoryItemId;
                            detail.Amount = 0;
                            detail.Amountoc = 0;

                            lst.Add(detail);
                        }

                        saOrderDetailDao.Insert(trans, lst, guid);
                        saOrder.Refid = guid;
                        saOrder.Totalamount = totalAmount;
                        saOrder.Totalamountoc = totalAmount;
                        saOrderDao.Update(trans, saOrder);

                        if (!TranferOrder(bunho, grdOutList.GetItemString(grdOutList.CurrentRowNumber, "pk1001")))
                        {
                            trans.Rollback();
                            return false;
                        }
                        else
                        {
                            trans.Commit();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.ToString());
                return false;
            }
        }

        private List<HangmogInfo> GetLstHangmog(string bunho)
        {
            List<HangmogInfo> lstHangmog = new List<HangmogInfo>();
            ORDERTRANSMisaGetHangmogArgs hangmogArg = new ORDERTRANSMisaGetHangmogArgs();
            hangmogArg.Bunho = bunho;
            hangmogArg.Pkout1001 = grdOutList.GetItemString(grdOutList.CurrentRowNumber, "pk1001");
            ORDERTRANSMisaGetHangmogResult hangmogResult = CloudService.Instance.Submit<ORDERTRANSMisaGetHangmogResult, ORDERTRANSMisaGetHangmogArgs>(hangmogArg);
            if (hangmogResult.ExecutionStatus == ExecutionStatus.Success)
            {
                IMisaOrderDao misaOrderDao = DataAccess.Misa.MisaOrderDao;
                foreach (ORDERTRANSMisaGetHangmogInfo item in hangmogResult.Lst)
                {
                    HangmogInfo hangmog = new HangmogInfo();
                    MisaOrder misaOrder = misaOrderDao.GetMisaOrder(item.HangmogCode);
                    if (misaOrder != null)
                    {
                        hangmog.InventoryItemId = misaOrder.InventoryItemId;
                        hangmog.UnitId = misaOrder.UnitId;
                        hangmog.SalePrice1 = misaOrder.SalePrice1;
                        hangmog.HangmogName = misaOrder.InventoryItemName;
                        hangmog.Suryang = Convert.ToDecimal(item.Suryang);
                        hangmog.Dv = Convert.ToDecimal(item.Dv);
                        hangmog.Nalsu = Convert.ToDecimal(item.Nalsu);
                        lstHangmog.Add(hangmog);
                    }
                    else
                    {
                        Service.WriteLog("ERROR Misa: Could not find hangmog_code " + item.HangmogCode);
                    }
                }
            }
            return lstHangmog;
        }
        private List<SangCodeInfo> GetLstSangCode()
        {
            List<SangCodeInfo> lstSangCode = new List<SangCodeInfo>();
            IMisaOrderDao misaOrderDao = DataAccess.Misa.MisaOrderDao;
            for (int i = 0; i < grdOutSang.RowCount; i++)
            {
                SangCodeInfo sangCode = new SangCodeInfo();
                MisaOrder misaOrder = misaOrderDao.GetMisaOrder("ICD-10/" + grdOutSang.GetItemString(i, "sang_code"));
                if (misaOrder != null)
                {
                    sangCode.InventoryItemId = misaOrder.InventoryItemId;
                    sangCode.SangCodeName = misaOrder.InventoryItemName;
                    lstSangCode.Add(sangCode);
                }
                else
                {
                    Service.WriteLog("ERROR Misa: Could not find sang_code " + "ICD-10/" + grdOutSang.GetItemString(i, "sang_code"));
                }
            }
            return lstSangCode;
        }

        private bool TranferOrder(string bunho, string pkout1001)
        {
            List<ORDERTRANSMisaTranferInfo> dataList = new List<ORDERTRANSMisaTranferInfo>();
            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                ORDERTRANSMisaTranferInfo updItem = new ORDERTRANSMisaTranferInfo();
                updItem.Pkocs1003 = grdOCS1003.GetItemString(i, "pkocs");
                updItem.SunabDate = dtpJunsongDate.GetDataValue().ToString().Replace("-", "/");
                dataList.Add(updItem);
            }
            ORDERTRANSMisaTranferArgs args = new ORDERTRANSMisaTranferArgs();
            args.Bunho = bunho;
            args.Pkout1001 = pkout1001;
            args.Lst = dataList;
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, ORDERTRANSMisaTranferArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return true;
            }
            else
                return false;
        }

        #endregion

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            // grdHoken
            grdHoken.ParamList = new List<string>(new string[]
                {
                    "f_acting_date",
                    "f_gubun",
                    "f_hosp_code",
                    "f_bunho",
                    "f_send_yn",
                });
            grdHoken.ExecuteQuery = GetGrdHoken;

            // grdINP2004
            grdINP2004.ParamList = new List<string>(new string[]
                {
                    "f_hosp_code",
                    "f_bunho",
                    "f_send_yn",
                    "f_acting_date",
                    "f_sunab_date",
                    "f_fkinp1001",
                });
            grdINP2004.ExecuteQuery = GetGrdINP2004;

            // grdOutSang
            grdOutSang.ParamList = new List<string>(new string[]
                {
                    "f_hosp_code",
                    "f_bunho",
                    "f_io_gubun",
                    "f_gijun_date",
                });
            grdOutSang.ExecuteQuery = GetGrdOutSang;

            // grdSiksa
            grdSiksa.ParamList = new List<string>(new string[]
                {
                    "f_send_yn",
                    "f_hosp_code",
                    "f_bunho",
                    "f_pk1001",
                    "f_acting_date",
                });
            grdSiksa.ExecuteQuery = GetGrdSiksa;

            // grdWoichul
            grdWoichul.ParamList = new List<string>(new string[]
                {
                    "f_send_yn",
                    "f_hosp_code",
                    "f_bunho",
                    "f_pk1001",
                    "f_order_date",
                });
            grdWoichul.ExecuteQuery = GetGrdWoichul;

            // layOut0101
            layOut0101.ParamList = new List<string>(new string[]
                {
                    "f_hosp_code",
                    "f_bunho",
                });
            layOut0101.ExecuteQuery = GetLayOut0101;

            // fwkFind
            fwkFind.ParamList = new List<string>(new string[]
                {
                    "f_acting_date",
                    "f_bunho",
                    "f_hosp_code",
                });

            // grdGongbi
            grdGongbi.ParamList = new List<string>(new string[]
                {
                    "f_io_gubun",
                    "f_send_yn",
                    "f_hosp_code",
                    "f_bunho",
                    "f_out1001",
                    "f_pkinp1002",
                    "f_pkout",
                });
            grdGongbi.ExecuteQuery = GetGrdGongbi;

            // grdComments
            grdComment.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_hosp_code",
                });
            grdComment.ExecuteQuery = GetGrdComment;
        }
        #endregion

        #region GetGrdHoken
        /// <summary>
        /// GetGrdHoken
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdHoken(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdHokenArgs args = new ORDERTRANSGrdHokenArgs();
            args.ActingDate             = bvc["f_acting_date"].VarValue;
            args.Bunho                  = bvc["f_bunho"].VarValue;
            args.Gubun                  = bvc["f_gubun"].VarValue;
            args.HospCode               = bvc["f_hosp_code"].VarValue;
            args.SendYn                 = bvc["f_send_yn"].VarValue;
            ORDERTRANSGrdHokenResult res = CloudService.Instance.Submit<ORDERTRANSGrdHokenResult, ORDERTRANSGrdHokenArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdHokenItem.ForEach(delegate(ORDERTRANSGrdHokenInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Gubun,
                        item.GubunName,
                        item.StartDate,
                        item.EndDate,
                        item.Johap,
                        item.SelectYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdINP2004
        /// <summary>
        /// GetGrdINP2004
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdINP2004(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdINP2004Args args   = new ORDERTRANSGrdINP2004Args();
            args.ActingDate                 = bvc["f_acting_date"].VarValue;
            args.Bunho                      = bvc["f_bunho"].VarValue;
            args.Fkinp1001                  = bvc["f_fkinp1001"].VarValue;
            args.HospCode                   = bvc["f_hosp_code"].VarValue;
            args.SendYn                     = bvc["f_send_yn"].VarValue;
            args.SunabDate                  = bvc["f_sunab_date"].VarValue;
            ORDERTRANSGrdINP2004Result res  = CloudService.Instance.Submit<ORDERTRANSGrdINP2004Result, ORDERTRANSGrdINP2004Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdInp2004Item.ForEach(delegate(ORDERTRANSGrdINP2004Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.Suname,
                        item.IpwonDate,
                        item.DataDate,
                        item.Fkinp1001,
                        item.Pkinp1002,
                        item.FromGwa,
                        item.ToGwa,
                        item.FromDoctor,
                        item.ToDoctor,
                        item.FromHoDong1,
                        item.ToHoDong1,
                        item.FromHoCode1,
                        item.ToHoCode1,
                        item.FromBedNo,
                        item.ToBedNo,
                        item.SendYn,
                        item.IfFlag,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdOutSang
        /// <summary>
        /// GetGrdOutSang
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOutSang(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdOutSangArgs args   = new ORDERTRANSGrdOutSangArgs();
            args.Bunho                      = bvc["f_bunho"].VarValue;
            args.GijunDate                  = bvc["f_gijun_date"].VarValue;
            args.HospCode                   = bvc["f_hosp_code"].VarValue;
            args.IoGubun                    = bvc["f_io_gubun"].VarValue;
            ORDERTRANSGrdOutSangResult res  = CloudService.Instance.Submit<ORDERTRANSGrdOutSangResult, ORDERTRANSGrdOutSangArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdOutSangItem.ForEach(delegate(ORDERTRANSGrdOutSangInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.Gwa,
                        item.GwaName,
                        item.IoGubun,
                        item.PkSeq,
                        item.Ser,
                        item.SangCode,
                        item.PreName,
                        item.SangName,
                        item.PreModifier1,
                        item.PreModifier2,
                        item.PreModifier3,
                        item.PreModifier4,
                        item.PreModifier5,
                        item.PreModifier6,
                        item.PreModifier7,
                        item.PreModifier8,
                        item.PreModifier9,
                        item.PreModifier10,
                        item.PreModifierName,
                        item.PostModifier1,
                        item.PostModifier2,
                        item.PostModifier3,
                        item.PostModifier4,
                        item.PostModifier5,
                        item.PostModifier6,
                        item.PostModifier7,
                        item.PostModifier8,
                        item.PostModifier9,
                        item.PostModifier10,
                        item.PostModifierName,
                        item.SangStartDate,
                        item.SangStartDateJp,
                        item.SangEndDate,
                        item.SangEndDateJp,
                        item.SangEndSayu,
                        item.SangEndSayuName,
                        item.JuSangYn,
                        item.ContKey,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdSiksa
        /// <summary>
        /// GetGrdSiksa
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdSiksa(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdSiksaArgs args     = new ORDERTRANSGrdSiksaArgs();
            args.ActingDate                 = bvc["f_acting_date"].VarValue;
            args.Bunho                      = bvc["f_bunho"].VarValue;
            args.HospCode                   = bvc["f_hosp_code"].VarValue;
            args.Pk1001                     = bvc["f_pk1001"].VarValue;
            args.SendYn                     = bvc["f_send_yn"].VarValue;
            ORDERTRANSGrdSiksaResult res = CloudService.Instance.Submit<ORDERTRANSGrdSiksaResult, ORDERTRANSGrdSiksaArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdSiksaItem.ForEach(delegate(ORDERTRANSGrdSiksaInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Fkinp1001,
                        item.Pkocs2015,
                        item.Bunho,
                        item.InputGubun,
                        item.DirectGubun,
                        item.NurGrName,
                        item.DirectCode,
                        item.NurMdName,
                        item.DirectCont1,
                        item.NurSoName,
                        item.OrderDate,
                        item.DrtFromDate,
                        item.DrtToDate,
                        item.ActDate,
                        item.PkSeq,
                        item.ActingYn,
                        item.SelectYn,
                        item.SendYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdWoichul
        /// <summary>
        /// GetGrdWoichul
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdWoichul(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdWoichulArgs args   = new ORDERTRANSGrdWoichulArgs();
            args.Bunho                      = bvc["f_bunho"].VarValue;
            args.HospCode                   = bvc["f_hosp_code"].VarValue;
            args.OrderDate                  = bvc["f_order_date"].VarValue;
            args.Pk1001                     = bvc["f_pk1001"].VarValue;
            args.SendYn                     = bvc["f_send_yn"].VarValue;
            ORDERTRANSGrdWoichulResult res = CloudService.Instance.Submit<ORDERTRANSGrdWoichulResult, ORDERTRANSGrdWoichulArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdWoiChulItem.ForEach(delegate(ORDERTRANSGrdWoichulInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Fkinp1001,
                        item.FkOutDate,
                        item.Bunho,
                        item.OutDate,
                        item.OutTime,
                        item.InHopeDate,
                        item.InHopeTime,
                        item.InTrueDate,
                        item.InTrueTime,
                        item.OutObjectText,
                        item.StartDate,
                        item.EndDate,
                        item.ActingYn,
                        item.SelectYn,
                        item.SendYn,
                        item.Seq,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayOut0101
        /// <summary>
        /// GetLayOut0101
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayOut0101(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSLayOut0101Args args = new ORDERTRANSLayOut0101Args();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.HospCode = bvc["f_hosp_code"].VarValue;
            ORDERTRANSLayOut0101Result res = CloudService.Instance.Submit<ORDERTRANSLayOut0101Result, ORDERTRANSLayOut0101Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayOut0101Item.ForEach(delegate(ORDERTRANSLayOut0101Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.Suname,
                        item.Suname2,
                        item.Birth,
                        item.Tel,
                        item.Sex,
                        item.Age,
                        item.IfValidYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdEdit
        /// <summary>
        /// GetGrdEdit
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdEdit(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdEditArgs args  = new ORDERTRANSGrdEditArgs();
            args.ActingDate             = bvc["f_acting_date"].VarValue;
            args.Bunho                  = bvc["f_bunho"].VarValue;
            args.Doctor                 = bvc["f_doctor"].VarValue;
            args.Gwa                    = bvc["f_gwa"].VarValue;
            args.HospCode               = bvc["f_hosp_code"].VarValue;
            args.IoGubun                = bvc["f_io_gubun"].VarValue;
            args.OrderDate              = bvc["f_order_date"].VarValue;
            args.Pk1001                 = bvc["f_pk1001"].VarValue;
            args.SendYn                 = bvc["f_send_yn"].VarValue;
            ORDERTRANSGrdEditResult res = CloudService.Instance.Submit<ORDERTRANSGrdEditResult, ORDERTRANSGrdEditArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdEditItem.ForEach(delegate(ORDERTRANSGrdEditInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Pk1001,
                        item.Pkocs,
                        item.GroupSer,
                        item.GroupOut1001,
                        item.OrderGubunName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.Suryang,
                        item.OrdDanui,
                        item.OrdDanuiName,
                        item.DvTime,
                        item.Dv,
                        item.Nalsu,
                        item.Jusa,
                        item.JusaName,
                        item.JusaSpdName,
                        item.BogyongCode,
                        item.BogyongColName,
                        item.Emergency,
                        item.JundalPart,
                        item.WonyoiOrderYn,
                        item.DangilGumsaOrderYn,
                        item.OcsFlag,
                        item.OrderGubun,
                        item.Bunho,
                        item.OrderDate,
                        item.Gwa,
                        item.Doctor,
                        item.Seq,
                        item.Fkocs003,
                        item.SubSusul,
                        item.ActingDate,
                        item.HopeDate,
                        item.SunabDate,
                        item.HomeCareYn,
                        item.RegularYn,
                        item.HubalChangeYn,
                        item.BunCode,
                        item.InputControl,
                        item.OrderGubunBas,
                        item.ActingYn,
                        item.SelectYn,
                        item.SendYn,
                        item.IfFlag,
                        item.Fkifs1004,
                        item.NaewonYn,
                        item.OrderByKey,
                        item.TrialFlg,
                        item.ClsCode,
                        item.SgCode,
                        // https://sofiamedix.atlassian.net/browse/MED-13718
                        item.OrderStatus,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdEditIGubun
        /// <summary>
        /// GetGrdEditIGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdEditIGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdEditIGubunArgs args    = new ORDERTRANSGrdEditIGubunArgs();
            args.Bunho                          = bvc["f_bunho"].VarValue;
            args.Doctor                         = bvc["f_doctor"].VarValue;
            args.Gwa                            = bvc["f_gwa"].VarValue;
            args.HospCode                       = bvc["f_hosp_code"].VarValue;
            args.OrderDate                      = bvc["f_order_date"].VarValue;
            args.Pk1001                         = bvc["f_pk1001"].VarValue;
            args.SendYn                         = bvc["f_send_yn"].VarValue;
            ORDERTRANSGrdEditIGubunResult res   = CloudService.Instance.Submit<ORDERTRANSGrdEditIGubunResult, ORDERTRANSGrdEditIGubunArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdEditIgubunItem.ForEach(delegate(ORDERTRANSGrdEditIGubunInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Pk1001,
                        item.Pkocs,
                        item.GroupSer,
                        item.OrderGubunName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.Suryang,
                        item.OrdDanui,
                        item.OrdDanuiName,
                        item.DvTime,
                        item.Dv,
                        item.Nalsu,
                        item.Jusa,
                        item.JusaName,
                        item.JusaSpdName,
                        item.BogyongCode,
                        item.OcsBogyongColName,
                        item.Emergency,
                        item.JundalPart,
                        item.WonyoiOrderYn,
                        item.DangilGumsaOrderYn,
                        item.OcsFlag,
                        item.OrderGubun,
                        item.Bunho,
                        item.OrderDate,
                        item.Gwa,
                        item.Doctor,
                        item.Seq,
                        item.Pkocs1003,
                        item.SubSusul,
                        item.ActingDate,
                        item.HopeDate,
                        item.SunabDate,
                        item.HomeCareYn,
                        item.RegularYn,
                        item.HubalChangeYn,
                        item.BunCode,
                        item.InputControl,
                        item.OrderGubunBas,
                        item.ActingYn,
                        item.SelectYn,
                        item.SendYn,
                        item.OrderByKey,
                        item.TrialFlg,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdListNonSendYn
        /// <summary>
        /// GetGrdListNonSendYn
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdListNonSendYn(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdListNonSendYnArgs args = new ORDERTRANSGrdListNonSendYnArgs();
            args.ActingDate     = bvc["f_acting_date"].VarValue;
            args.Bunho          = bvc["f_bunho"].VarValue;
            args.HospCode       = bvc["f_hosp_code"].VarValue;
            ORDERTRANSGrdListNonSendYnResult res = CloudService.Instance.Submit<ORDERTRANSGrdListNonSendYnResult, ORDERTRANSGrdListNonSendYnArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdListNonSendItem.ForEach(delegate(ORDERTRANSGrdListNonSendYnInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Fkout1001,
                        item.Bunho,
                        item.Suname,
                        item.ActingDate,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.Gubun,
                        item.GubunName,
                        item.SendedYn,
                        item.NaewonYn,
                        item.OrderByKey,
                        item.ChojaeName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdListSendYn
        /// <summary>
        /// GetGrdListSendYn
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdListSendYn(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdListSendYnArgs args = new ORDERTRANSGrdListSendYnArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.HospCode = bvc["f_hosp_code"].VarValue;
            ORDERTRANSGrdListSendYnResult res = CloudService.Instance.Submit<ORDERTRANSGrdListSendYnResult, ORDERTRANSGrdListSendYnArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdListSendItem.ForEach(delegate(ORDERTRANSGrdListSendYnInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Fkout1001,
                        item.Bunho,
                        item.Suname,
                        item.ActingDate,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.Gubun,
                        item.GubunName,
                        "", // SendedYn
                        "", // NaewonYn
                        item.OrderByKey,
                        "", // ChojaeName
                        // https://sofiamedix.atlassian.net/browse/MED-10487
                        item.Pkout1001,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdList
        /// <summary>
        /// GetGrdList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdListArgs args  = new ORDERTRANSGrdListArgs();
            args.ActingDate             = bvc["f_acting_date"].VarValue;
            args.Bunho                  = bvc["f_bunho"].VarValue;
            args.Doctor                 = bvc["f_doctor"].VarValue;
            args.Gwa                    = bvc["f_gwa"].VarValue;
            args.HospCode               = bvc["f_hosp_code"].VarValue;
            args.IoGubun                = bvc["f_io_gubun"].VarValue;
            args.MSendYn                = bvc["f_m_send_yn"].VarValue;
            args.OrderDate              = bvc["f_order_date"].VarValue;
            args.Pk1001                 = bvc["f_pk1001"].VarValue;
            args.SendYn                 = bvc["f_send_yn"].VarValue;
            args.Str                    = bvc["f_str"].VarValue;
            ORDERTRANSGrdListResult res = CloudService.Instance.Submit<ORDERTRANSGrdListResult, ORDERTRANSGrdListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdItem.ForEach(delegate(ORDERTRANSGrdListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Fkinp1001,
                        item.Bunho,
                        item.Suname,
                        item.IpwonDate,
                        item.IpwonTime,
                        item.Gwa,
                        item.Doctor,
                        item.GwaName,
                        item.DoctorName,
                        item.Gubun,
                        item.GubunName,
                        item.GongbiYn,
                        item.Chojae,
                        item.ChojaeName,
                        item.Pkinp1002,
                        item.ActingDate,
                        item.OrderDate,
                        item.GubunOld,
                        item.ChojaeOld,
                        item.GongbiCode1,
                        item.GongbiCode2,
                        item.GongbiCode3,
                        item.GongbiCode4,
                        item.GongbiCode1Name,
                        item.GongbiCode2Name,
                        item.GongbiCode3Name,
                        item.GongbiCode4Name,
                        item.Pkout,
                        item.SendDate,
                        item.SanjungGubun,
                        item.SanjungGubunName,
                        item.IfValidYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetFbxHoken
        /// <summary>
        /// GetFbxHoken
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFbxHoken(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSFwkFindArgs args = new ORDERTRANSFwkFindArgs();
            args.ActingDate = bvc["f_acting_date"].VarValue;
            args.Bunho = bvc["f_bunho"].VarValue;
            args.HospCode = bvc["f_hosp_code"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, ORDERTRANSFwkFindArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayCommon
        /// <summary>
        /// GetLayCommon
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayCommon(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSLayCommonArgs args = new ORDERTRANSLayCommonArgs();
            args.ActingDate = bvc["f_acting_date"].VarValue;
            args.Bunho = bvc["f_bunho"].VarValue;
            args.Gubun = bvc["f_gubun"].VarValue;
            args.HospCode = bvc["f_hosp_code"].VarValue;
            ORDERTRANSLayCommonResult res = CloudService.Instance.Submit<ORDERTRANSLayCommonResult, ORDERTRANSLayCommonArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayCommonItem.ForEach(delegate(ORDERTRANSLayCommonInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.GubunName,
                        item.IfValidYn,
                        item.GongbiYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdGongbi
        /// <summary>
        /// GetGrdGongbi
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdGongbi(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdGongbiListArgs args    = new ORDERTRANSGrdGongbiListArgs();
            args.Bunho                          = bvc["f_bunho"].VarValue;
            args.HospCode                       = bvc["f_hosp_code"].VarValue;
            args.IoGubun                        = bvc["f_io_gubun"].VarValue;
            args.Out1001                        = bvc["f_out1001"].VarValue;
            args.Pkinp1002                      = bvc["f_pkinp1002"].VarValue;
            args.Pkout                          = bvc["f_pkout"].VarValue;
            args.SendYn                         = bvc["f_send_yn"].VarValue;
            ORDERTRANSGrdGongbiListResult res = CloudService.Instance.Submit<ORDERTRANSGrdGongbiListResult, ORDERTRANSGrdGongbiListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdGongbiItem.ForEach(delegate(ORDERTRANSGrdGongbiListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.GongbiCode,
                        item.GongbiName,
                        item.LastCheckDate,
                        item.BudamjaBunho,
                        item.SugubjaBunho,
                        item.SelectYn,
                        item.Priority,
                        item.IfValidYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdComment
        /// <summary>
        /// GetGrdComment
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdComment(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ORDERTRANSGrdCommentsArgs args = new ORDERTRANSGrdCommentsArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.HospCode = bvc["f_hosp_code"].VarValue;
            ORDERTRANSGrdCommentsResult res = CloudService.Instance.Submit<ORDERTRANSGrdCommentsResult, ORDERTRANSGrdCommentsArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdCommentsItem.ForEach(delegate(ORDERTRANSGrdCommentsInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.Ser,
                        item.Comments,
                    });
                });
            }

            return lObj;
        }
        #endregion

        private void grdOCS1003_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        #endregion

        #region Transfer orders using API

        /// <summary>
        /// To implement https://sofiamedix.atlassian.net/browse/MED-13718
        /// </summary>
        /// <param name="type"></param>
        private void DoTransfer(TransferType type)
        {
            // Gets data to transfer
            List<ORDERTRANSAPIHangmogInfo> hangmogItems = this.GetListHangmogTrans();
            string bunho = fbxBunho.GetDataValue();
            string pkout1001 = "";
            string performDate = dtpJunsongDate.GetDataValue();
            int row_number = 0;
            // Get pkOut1001

            //https://sofiamedix.atlassian.net/browse/MED-16704
            for (int i = 0; i < grdOutList.RowCount; i++)
            {
                if (grdOutList.GetItemString(i, "select") == "Y")
                {
                    row_number = i;
                }
            }
            if (rbnMiTrans.Checked)
            {
                pkout1001 = this.grdOutList.GetItemString(row_number, "pk1001");
            }
            else
            {
                pkout1001 = this.grdOutList.GetItemString(row_number, "pkout1001");
            }

            // Validation
            if (hangmogItems.Count == 0)
            {
                // 選択されてるオーダがありません。一つ以上選択してください。
                XMessageBox.Show(Resources.MSG_21, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Service.StartWriteLog();
            Service.WriteLog("[ORCA_IP]:" + UserInfo.OrcaIp);
            Service.WriteLog("[ORCA_PORT]:" + UserInfo.OrcaPort);
            Service.WriteLog("[ORCA_USER]:" + UserInfo.OrcaUser);
            Service.WriteLog("[ORCA_PASSWORD]:" + UserInfo.OrcaPassword);
            Service.EndWriteLog();

            switch (type)
            {
                case TransferType.Cancel:
                    this.Cancel(bunho, pkout1001, performDate, hangmogItems);
                    break;
                case TransferType.Disease:
                    this.TransferDisease(bunho, pkout1001, performDate);
                    break;
                case TransferType.Order:
                    this.TransferOrders(bunho, pkout1001, performDate, hangmogItems);
                    break;
                case TransferType.Retransfer:
                    this.ReTransfer(bunho, pkout1001, performDate, hangmogItems);
                    break;
                default:
                    break;
            }
            }

        /// <summary>
        /// 1. Validate
        /// 2. Call API to synchronize orders/disease name to ORCA
        /// 3. Mapping fields
        /// 3.1. Get examination information
        /// 3.2 Get company insurance
        /// 3.3 Get public insurance
        /// 3.4 Get disease name
        /// </summary>
        /// <param name="bunho"></param>
        /// <param name="pkout1001"></param>
        /// <param name="performDate"></param>
        private void TransferDisease(string bunho, string pkout1001, string performDate)
        {
            string msg = "";

            Service.StartWriteLog();
            Service.WriteLog("[ORDERTRANS::SEND DISEASE PROCESS...]");

            ORDERTRANSAPITransferOrdersArgs args = new ORDERTRANSAPITransferOrdersArgs();
            args.Bunho = bunho;
            args.PerformDate = performDate;
            args.Pkout1001 = pkout1001;
            args.Action = IHIS.CloudConnector.Messaging.TransferType.SEND_DISEASE_ONLY;
            args.HangmogItem = new List<ORDERTRANSAPIHangmogInfo>();
            ORDERTRANSAPITransferOrdersResult res = CloudService.Instance.Submit<ORDERTRANSAPITransferOrdersResult, ORDERTRANSAPITransferOrdersArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                Service.WriteLog("[ERROR CODE]:" + res.MsgItem.ErrCode);
                Service.WriteLog("[API RESULT]:" + res.MsgItem.ApiResult);
                Service.WriteLog("[DISEASE RESULT]:" + res.MsgItem.DiseaseResult);
                Service.WriteLog("[MEDICAL RESULT]:" + res.MsgItem.MedicalResult);
                Service.EndWriteLog();

                if (!TypeCheck.IsNull(res.MsgItem.ErrCode))
                {
                    this.ShowValidationMsg(res.MsgItem.ErrCode);
                    return;
                }

                if (res.MsgItem.ApiResult == "00" || res.MsgItem.ApiResult == "20")
                {
                    if (res.MsgItem.DiseaseResult != "01"
                        && res.MsgItem.DiseaseResult != "02"
                        && res.MsgItem.DiseaseResult != "11"
                        && res.MsgItem.DiseaseResult != "12"
                        && res.MsgItem.DiseaseResult != "13")
                    {
                        // Transfer success.
                        XMessageBox.Show(Resources.MSG_TRANS_SUCCESS, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Transfer success, but Disease error.
                        msg = this.GetDiseaseErrMsg(res.MsgItem.DiseaseResult);
                        XMessageBox.Show(msg, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }

                // Other API errors
                this.ShowApiErrMessage(res.MsgItem.ApiResult);
            }
            else
            {
                XMessageBox.Show(Resources.MSG_TRANS_FAIL, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 2. Call API to synchronize orders/disease name to ORCA
        /// 3. Mapping fields
        /// 3.1. Get examination information
        /// 3.2 Get company insurance
        /// 3.3 Get public insurance
        /// 3.5.3. Generate for medical information
        /// </summary>
        /// <param name="bunho"></param>
        /// <param name="pkout1001"></param>
        /// <param name="performDate"></param>
        private void ReTransfer(string bunho, string pkout1001, string performDate, List<ORDERTRANSAPIHangmogInfo> hangmogItems)
        {
            string msg = "";

            Service.StartWriteLog();
            Service.WriteLog("[ORDERTRANS::RE-TRANSFER PROCESS...]");

            ORDERTRANSAPITransferOrdersArgs args = new ORDERTRANSAPITransferOrdersArgs();
            args.Bunho = bunho;
            args.PerformDate = performDate;
            args.Pkout1001 = pkout1001;
            args.HangmogItem = hangmogItems;
            args.Action = IHIS.CloudConnector.Messaging.TransferType.RETRANSFER_ORDER;
            ORDERTRANSAPITransferOrdersResult res = CloudService.Instance.Submit<ORDERTRANSAPITransferOrdersResult, ORDERTRANSAPITransferOrdersArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                Service.WriteLog("[ERROR CODE]:" + res.MsgItem.ErrCode);
                Service.WriteLog("[API RESULT]:" + res.MsgItem.ApiResult);
                Service.WriteLog("[DISEASE RESULT]:" + res.MsgItem.DiseaseResult);
                Service.WriteLog("[MEDICAL RESULT]:" + res.MsgItem.MedicalResult);
                Service.EndWriteLog();

                if (!TypeCheck.IsNull(res.MsgItem.ErrCode))
                {
                    this.ShowValidationMsg(res.MsgItem.ErrCode);
                    return;
                }

                // Trans success? (sending data to ORCA success)
                if (res.MsgItem.ApiResult == "00" || res.MsgItem.ApiResult == "21")
                {
                    if (res.MsgItem.MedicalResult != "01"
                        && res.MsgItem.MedicalResult != "03"
                        && res.MsgItem.MedicalResult != "10")
                    {
                        // Transfer success, both orders, medicals and diseases.
                        XMessageBox.Show(Resources.MSG_TRANS_SUCCESS, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // https://sofiamedix.atlassian.net/browse/MED-16489
                        if (this.HaoriClinic)
                        {
                            this.OpenHaoriForms(res);
                        }
                    }
                    else
                    {
                        // Transfer success, but medical failed.
                        msg = GetMedicalErrMsg(res.MsgItem.MedicalResult);
                        XMessageBox.Show(msg, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }

                // Other API errors
                this.ShowApiErrMessage(res.MsgItem.ApiResult);
            }
            else
            {
                XMessageBox.Show(Resources.MSG_TRANS_FAIL, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 2. Call API to synchronize orders/disease name to ORCA
        /// 3. Mapping fields
        /// 3.1. Get examination information
        /// 3.2 Get company insurance
        /// 3.3 Get public insurance
        /// 3.4. Get disease name
        /// </summary>
        /// <param name="bunho"></param>
        /// <param name="pkout1001"></param>
        /// <param name="performDate"></param>
        /// <param name="hangmogItems"></param>
        private void Cancel(string bunho, string pkout1001, string performDate, List<ORDERTRANSAPIHangmogInfo> hangmogItems)
        {
            string msg = "";

            Service.StartWriteLog();
            Service.WriteLog("[ORDERTRANS::CANCEL PROCESS...]");

            ORDERTRANSAPITransferOrdersArgs args = new ORDERTRANSAPITransferOrdersArgs();
            args.Bunho = bunho;
            args.PerformDate = performDate;
            args.Pkout1001 = pkout1001;
            args.Action = IHIS.CloudConnector.Messaging.TransferType.CANCEL_ORDER;
            args.HangmogItem = hangmogItems;
            ORDERTRANSAPITransferOrdersResult res = CloudService.Instance.Submit<ORDERTRANSAPITransferOrdersResult, ORDERTRANSAPITransferOrdersArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                Service.WriteLog("[ERROR CODE]:" + res.MsgItem.ErrCode);
                Service.WriteLog("[API RESULT]:" + res.MsgItem.ApiResult);
                Service.WriteLog("[DISEASE RESULT]:" + res.MsgItem.DiseaseResult);
                Service.WriteLog("[MEDICAL RESULT]:" + res.MsgItem.MedicalResult);
                Service.EndWriteLog();

                if (!TypeCheck.IsNull(res.MsgItem.ErrCode))
                {
                    this.ShowValidationMsg(res.MsgItem.ErrCode);
                    return;
                }

                // Trans success? (sending data to ORCA success)
                if (res.MsgItem.ApiResult == "00" || res.MsgItem.ApiResult == "21")
                {
                    // Medical success?
                    if (res.MsgItem.MedicalResult != "01"
                        && res.MsgItem.MedicalResult != "03"
                        && res.MsgItem.MedicalResult != "10")
                    {
                        // Disease success?
                        if (res.MsgItem.DiseaseResult != "01"
                        && res.MsgItem.DiseaseResult != "02"
                        && res.MsgItem.DiseaseResult != "11"
                        && res.MsgItem.DiseaseResult != "12"
                        && res.MsgItem.DiseaseResult != "13")
                        {
                            // Transfer success, both orders, medicals and diseases.
                            XMessageBox.Show(Resources.MSG_TRANS_SUCCESS, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            // Transfer success, but disease failed.
                            msg = Resources.MSG_TRANS_SUCCESS + Environment.NewLine;
                            msg += this.GetDiseaseErrMsg(res.MsgItem.DiseaseResult);
                            XMessageBox.Show(msg, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Transfer success, but medical failed.
                        msg = GetMedicalErrMsg(res.MsgItem.MedicalResult);
                        XMessageBox.Show(msg, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }

                // Other API errors
                this.ShowApiErrMessage(res.MsgItem.ApiResult);
            }
            else
            {
                XMessageBox.Show(Resources.MSG_TRANS_FAIL, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Same to Cancel function.
        /// </summary>
        /// <param name="bunho"></param>
        /// <param name="pkout1001"></param>
        /// <param name="performDate"></param>
        /// <param name="hangmogItems"></param>
        private void TransferOrders(string bunho, string pkout1001, string performDate, List<ORDERTRANSAPIHangmogInfo> hangmogItems)
        {
            string msg = "";

            Service.StartWriteLog();
            Service.WriteLog("[ORDERTRANS::TRANSFER ORDERS PROCESS...]");

            ORDERTRANSAPITransferOrdersArgs args = new ORDERTRANSAPITransferOrdersArgs();
            args.Bunho = bunho;
            args.HangmogItem = hangmogItems;
            args.PerformDate = performDate;
            args.Pkout1001 = pkout1001;
            args.Action = IHIS.CloudConnector.Messaging.TransferType.SEND_ORDER_DISEASE;
            ORDERTRANSAPITransferOrdersResult res = CloudService.Instance.Submit<ORDERTRANSAPITransferOrdersResult, ORDERTRANSAPITransferOrdersArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                Service.WriteLog("[ERROR CODE]:" + res.MsgItem.ErrCode);
                Service.WriteLog("[API RESULT]:" + res.MsgItem.ApiResult);
                Service.WriteLog("[DISEASE RESULT]:" + res.MsgItem.DiseaseResult);
                Service.WriteLog("[MEDICAL RESULT]:" + res.MsgItem.MedicalResult);
                Service.EndWriteLog();

                if (!TypeCheck.IsNull(res.MsgItem.ErrCode))
                {
                    this.ShowValidationMsg(res.MsgItem.ErrCode);
                    return;
                }

                // ORCAにおいて、 HANGMOG_NAME [HANGMOG_CODE] が存在していません。
                if (res.HangmogErrItem.Count > 0)
                {
                    res.HangmogErrItem.ForEach(delegate(ORDERTRANSAPIHangmogInfo item)
                    {
                        msg += string.Format(Resources.MSG_CHECK_TRANS_001, item.HangmogCode, item.HangmogName) + Environment.NewLine;
                    });

                    XMessageBox.Show(msg, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // No order was transfer?
                    if (res.HangmogErrItem.Count == hangmogItems.Count)
                    {
                        return;
                    }
                }

                // Trans success? (sending data to ORCA success)
                if (res.MsgItem.ApiResult == "00" || res.MsgItem.ApiResult == "21")
                {
                    // Medical success?
                    if (res.MsgItem.MedicalResult != "01"
                        && res.MsgItem.MedicalResult != "03"
                        && res.MsgItem.MedicalResult != "10")
                    {
                        // Disease success?
                        if (res.MsgItem.DiseaseResult != "01"
                        && res.MsgItem.DiseaseResult != "02"
                        && res.MsgItem.DiseaseResult != "11"
                        && res.MsgItem.DiseaseResult != "12"
                        && res.MsgItem.DiseaseResult != "13")
                        {
                            // Transfer success, both orders, medicals and diseases.
                            XMessageBox.Show(Resources.MSG_TRANS_SUCCESS, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // https://sofiamedix.atlassian.net/browse/MED-16489
                            if (this.HaoriClinic)
                            {
                                this.OpenHaoriForms(res);
                            }

                            return;
                        }
                        else
                        {
                            // Transfer success, but disease failed.
                            msg = Resources.MSG_TRANS_SUCCESS + Environment.NewLine;
                            msg += this.GetDiseaseErrMsg(res.MsgItem.DiseaseResult);
                            XMessageBox.Show(msg, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Transfer success, but medical failed.
                        msg = GetMedicalErrMsg(res.MsgItem.MedicalResult);
                        XMessageBox.Show(msg, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }

                // Other API errors
                this.ShowApiErrMessage(res.MsgItem.ApiResult);
            }
            else
            {
                XMessageBox.Show(Resources.MSG_TRANS_FAIL, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowApiErrMessage(string msgCode)
        {
            if (!TypeCheck.IsNull(msgCode))
            {
                // Transfer failed. Calling API error.
                string msg = GetTransErrMsg(msgCode);
                XMessageBox.Show(msg, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Transfer failed. Connection to ORCA error.
                XMessageBox.Show(Resources.MSG_TRANS_FAIL, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ORDERTRANSAPIHangmogInfo> GetListHangmogTrans()
        {
            List<ORDERTRANSAPIHangmogInfo> lstData = new List<ORDERTRANSAPIHangmogInfo>();
            string pkOcs1003 = "";
            string hangmogCode = "";
            string hangmogName = "";
            string select = "";

            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                pkOcs1003 = grdOCS1003.GetItemString(i, "pkocs");
                hangmogCode = grdOCS1003.GetItemString(i, "hangmog_code");
                hangmogName = grdOCS1003.GetItemString(i, "hangmog_name");
                select = grdOCS1003.GetItemString(i, "select");

                if (select == "Y")
                {
                    lstData.Add(new ORDERTRANSAPIHangmogInfo(hangmogCode, hangmogName, pkOcs1003));
                }
            }

            return lstData;
        }

        private void ShowValidationMsg(string errCode)
        {
            switch (errCode)
            {
                case "01":
                    // Acting date is NULL
                    // 部門でオーダが実施完了されてません。オーダを実施してください。
                    XMessageBox.Show(Resources.MSG_22, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "02":
                    // Invalid URL
                    XMessageBox.Show(Resources.MSG_INVALID_URL, Resources.CAP_TRANS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }

        private string GetTransErrMsg(string apiResult)
        {
            return "ORCA: " + XMsg.GetMsg(apiResult);
        }

        private string GetMedicalErrMsg(string medicalResult)
        {
            string msg = "";

            switch (medicalResult)
            {
                case "01":
                    msg = Resources.MEDICAL_ERR_01;
                    break;
                case "03":
                    msg = Resources.MEDICAL_ERR_03;
                    break;
                case "10":
                    msg = Resources.MEDICAL_ERR_10;
                    break;
                default:
                    break;
            }

            return msg;
        }

        private string GetDiseaseErrMsg(string diseaseResult)
        {
            string msg = "";

            switch (diseaseResult)
            {
                case "01":
                    msg = Resources.DISEASE_ERR_01;
                    break;
                case "02":
                    msg = Resources.DISEASE_ERR_02;
                    break;
                case "11":
                    msg = Resources.DISEASE_ERR_11;
                    break;
                case "12":
                    msg = Resources.DISEASE_ERR_12;
                    break;
                case "13":
                    msg = Resources.DISEASE_ERR_13;
                    break;
                default:
                    break;
            }

            return msg;
        }

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-13998
        /// </summary>
        /// <returns></returns>
        private bool IsCancelOrder()
        {
            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                string select = grdOCS1003.GetItemString(i, "select");
                string status = grdOCS1003.GetItemString(i, "order_status");

                if (select == "Y" && status != "20")
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region https://sofiamedix.atlassian.net/browse/MED-16489

        /// <summary>
        /// Y: using Haori, otherwise N
        /// </summary>
        //private string _ifHaoriYn = ConfigurationManager.AppSettings["IfHaoriYn"];
        /// <summary>
        /// 10.1.40.107
        /// </summary>
        private string _haoriHost = ConfigurationManager.AppSettings["HaoriHost"];
        /// <summary>
        /// 4567
        /// </summary>
        private string _haoriPort = ConfigurationManager.AppSettings["HaoriPort"];
        /// <summary>
        /// TRUE if using Haori, otherwise FALSE
        /// </summary>
        public bool HaoriClinic
        {
            get { return ConfigurationManager.AppSettings["HaoriClinic"] == UserInfo.HospCode; }
        }

        private void OpenHaoriForms(ORDERTRANSAPITransferOrdersResult transferResult)
        {
            string url = "http://{0}:{1}/medical_exam/new?patient_id={2}&perform_date={3}&department_code={4}&physician_code={5}&off_time={6}&doctors_fee={7}&combination_number={8}&orca_uid&medical_information={9}";
            string host = _haoriHost;
            string port = _haoriPort;
            string patientId = fbxBunho.GetDataValue();
            string performDate = dtpJunsongDate.GetDataValue();
            string deptCode = transferResult.DeptCode;
            string physicianCode = transferResult.PhysicianCode;
            string offTime = "0";
            string doctorFee = transferResult.DoctorFee;
            string combinationNumber = transferResult.InsuranceCombinationNumber;
            string medicalInfo = this.Base64Encode(JsonConvert.SerializeObject(transferResult.MedicalInfoItem));

            url = string.Format(url,
                host,
                port,
                patientId,
                performDate,
                deptCode,
                physicianCode,
                offTime,
                doctorFee,
                combinationNumber,
                medicalInfo);

            // Test data
            //string url = @"http://10.1.40.107:4567/medical_exam/new?patient_id=000000004&perform_date=2017-03-02&department_code=01&physician_code=10001&off_time=0&doctors_fee=01&combination_number=0001&orca_uid&medical_information=W3sibWVkaWNhbF9jbGFzcyI6IjEzMCIsIm1lZGljYWxfY2xhc3NfbmFtZSI6IuWGjeiouuaWmeaWmSIsIm1lZGljYWxfY2xhc3NfbnVtYmVyIjoiMyIsICJtZWRpY2F0aW9uX2luZm8iOlt7Im1lZGljYXRpb25fY29kZSI6IjExMjAwNzQxMSIsICJtZWRpY2F0aW9uX25hbWUiOiLlho3oqLoiLCAibnVtYmVyIjoiMSJ9LCB7Im1lZGljYXRpb25fY29kZSI6IjExMjAwNzQxMiIsICJtZWRpY2F0aW9uX25hbWUiOiLlho3oqLroqLoiLCAibnVtYmVyIjoiMiJ9LCB7Im1lZGljYXRpb25fY29kZSI6IjExMjAwNzQxMyIsICJtZWRpY2F0aW9uX25hbWUiOiLlho3oqLroqLroqLoiLCAibnVtYmVyIjoiMyJ9XX1d";
            Service.WriteLog("Haori url: " + url);

            FormHaori frm = new FormHaori(url);
            frm.ShowDialog();
        }

        private string Base64Encode(string plainText)
        {
            string base64Str = "";

            try
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                base64Str = Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);
            }

            return base64Str;
        }

        #endregion
    }


    public class HangmogInfo
    {
        public Guid InventoryItemId;
        public string HangmogName;
        public decimal Suryang;
        public decimal Dv;
        public decimal Nalsu;
        public Guid UnitId;
        public decimal SalePrice1;
    }

    public class SangCodeInfo
    {
        public Guid InventoryItemId;
        public string SangCodeName;
    }
}