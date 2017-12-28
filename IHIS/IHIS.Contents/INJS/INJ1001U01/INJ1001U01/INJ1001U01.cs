#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Models.Injs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.Framework;
using IHIS.INJS.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.CloudConnector.Contracts.Results.System;
using ComboListItemInfo = IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Arguments.System;

#endregion

namespace IHIS.INJS
{
    /// <summary>
    /// INJ1001U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class INJ1001U01 : IHIS.Framework.XScreen
    {

        #region [DynService Control]

        private IHIS.Framework.SingleLayout mLayCommon = new SingleLayout();

        #endregion

        #region 자동생성

        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDatePicker dtpQueryDate;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Panel pnlFillCenter;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XMstGrid grdDetail;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
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
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XGridCell xGridCell1;
        private IHIS.Framework.XGridCell xGridCell2;
        private IHIS.Framework.XPanel pnlLeft;
        private IHIS.Framework.XPanel pnlFillInBottom;
        private IHIS.Framework.XPanel pnlFillInTop;
        private IHIS.Framework.XPatientBox patInfo;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XButton btnReLabel;
//        private IHIS.Framework.XDataWindow dw1;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XButton btnReser;
        private IHIS.Framework.XBuseoCombo xBuseoCombo1;
        private IHIS.Framework.XLabel lbBuseo;
        private IHIS.Framework.XDatePicker dtpActingDate;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel lbSuname;
        private IHIS.Framework.XLabel lbSex;
        private IHIS.Framework.XLabel lbAge;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel lbAddress;
        private System.Windows.Forms.Button btnTodayOrder;
        private System.Windows.Forms.Button btnPostOrder;
        private System.Windows.Forms.Button btnPreOrder;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButton btnReInjActScrip;
 //       private IHIS.Framework.XDataWindow dw_jusa_lable;
        private IHIS.Framework.MultiLayout layLableNew;
 //       private IHIS.Framework.XDataWindow xDataWindow1;
        private IHIS.Framework.MultiLayout layOrderPrint;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private MultiLayout layTemp;
  //      private XDataWindow dw_jusa;
        private XRichTextBox txtSilsiRemark;
        private XLabel xLabel7;
        private XEditGridCell xEditGridCell66;
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
        private MultiLayoutItem multiLayoutItem48;
        private ImageList imageListMixGroup;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private MultiLayout layReserDate;
        private MultiLayoutItem multiLayoutItem15;
        private PictureBox pbxReserDate;
        private XLabel xLabel8;
        private PictureBox pbxCPL;
        private Button btnCPL;
        private SingleLayout layCPLOrderYN;
        private SingleLayoutItem singleLayoutItem1;
        private XGridHeader xGridHeader2;
        private XEditGrid grdNUR1016;
        private XEditGridCell xEditGridCell20;
        private Timer timer1;
        private XEditGridCell xEditGridCell70;
        private XPanel xPanel10;
        private XPanel pnlDetailFill;
        private XPanel pnlDetailTop;
        private XPanel pnlDetailInfo;
        private XPanel pnlDetailDate;
        private XEditGrid grdOCS1003;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XGridHeader xGridHeader1;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell78;
        private XEditGrid grdSang;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
        private XRadioButton rbtDone;
        private XRadioButton rbtWait;
        private XEditGridCell xEditGridCell86;
        private XPanel xPanel4;
        private XLabel lblTitle;
        private XEditGridCell xEditGridCell87;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XButton btnAllergy;
        private XButton btnPrintSetup;
        private PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private SingleLayout layPrintName;
        private SingleLayoutItem singleLayoutItem2;
        private XPanel pnlSang;
        private XLabel xLabel3;
        private XPanel pnlPaInfo;
        private XPanel pnlAllergy;
        private XPanel xPanel6;
        private XEditGrid grdNUR1017;
        private XEditGridCell xEditGridCell88;
        private XButton btnGamyum;
        private XLabel xLabel9;
        private XLabel xLabel10;
        private XEditGridCell xEditGridCell89;
        private XButton btnClear;
        private XDisplayBox dbxActor_name;
        private XFindBox fbxActor;
        private XLabel xLabel13;
        private XFindWorker fwkActor;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private SingleLayout layCommon;
        private XTextBox txtTimeInterval;
        private XTextBox tbxTimer;
        private XDictComboBox cboTime;
        private XLabel xLabel14;
        private XLabel lbTime;
        private XButton btnUseTimeChk;
        private XButton btnChkAllJubsu;
        private XButton btnInjActScrip;
        private XButton btnLabel;
        private MultiLayout mlayConstantInfo;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
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
        private XButton btnCmtClear;
        private XDisplayBox dboxCmt;
        private XFindBox fbxCmt;
        private XLabel xLabel2;
        private XFindWorker fwkCmt;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private XPanel pnlOUT0106;
        private XEditGrid grdOUT0106;
        private XEditGridCell xEditGridCell69;
        private XButton btnOUt0106;
        private XLabel xLabel12;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell92;
        private System.ComponentModel.IContainer components = null;
        private DateTime currentDate;
        private XButton btnFindUser;
        private XDisplayBox dbxUserName;
        private XDisplayBox dbxUserId;
        private bool isFirstLoad = true;

        #endregion

        public INJ1001U01()
        {
            try
            {            
                // 이 호출은 Windows Form 디자이너에 필요합니다.       
                GetDataScreen();
                InitializeComponent();
                SetGridColumnWidth();
                //MED-11557
                ApplyMultiResolution();
                
                currentDate = EnvironInfo.GetSysDate();
                GetDataScreenOpenFirst();
                Init();
                BindExecuteQueryMethod();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\nInner exception:\r\n" + ex.InnerException.Message);
                throw;
            }
        }

        private void SetGridColumnWidth()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
                
                xEditGridCell87.CellWidth = 58;
                xEditGridCell91.CellWidth = 70;


                xEditGridCell23.CellWidth = 58;
                xEditGridCell60.CellWidth = 56;
                xEditGridCell16.CellWidth = 40;
                xEditGridCell14.CellWidth = 40;
                xEditGridCell22.CellWidth = 96;
                xEditGridCell2.CellWidth = 150;

                ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            }
        }

        private void ApplyMultiResolution()
        {
            int width = SystemInformation.VirtualScreen.Width;
            int height = SystemInformation.VirtualScreen.Height;

            if (width == 1600 && height == 900)
            {
                this.Width = 1242;
                this.Height = 680;
            }
            else if (width == 1440 && height == 900)
            {
                this.Width = 1242;
                this.Height = 680;
            }
            else if (width == 1366 && height == 768)
            {
                this.Width = 1242;
                this.Height = 580;
            }
            else if (width == 1280 && height == 1024)
            {
                this.xLabel13.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                fbxActor.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                dbxActor_name.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                btnClear.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                btnCmtClear.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                this.Width = 1222;
                this.Height = 680;
                btnChkAllJubsu.Location = new Point(829, 2);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INJ1001U01));
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpQueryDate = new IHIS.Framework.XDatePicker();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.pnlFillCenter = new System.Windows.Forms.Panel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnCmtClear = new IHIS.Framework.XButton();
            this.dboxCmt = new IHIS.Framework.XDisplayBox();
            this.txtSilsiRemark = new IHIS.Framework.XRichTextBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.fbxCmt = new IHIS.Framework.XFindBox();
            this.fwkCmt = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.grdNUR1016 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.grdDetail = new IHIS.Framework.XMstGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.txtTimeInterval = new IHIS.Framework.XTextBox();
            this.tbxTimer = new IHIS.Framework.XTextBox();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.lbTime = new IHIS.Framework.XLabel();
            this.lblTitle = new IHIS.Framework.XLabel();
            this.rbtDone = new IHIS.Framework.XRadioButton();
            this.rbtWait = new IHIS.Framework.XRadioButton();
            this.lbBuseo = new IHIS.Framework.XLabel();
            this.xBuseoCombo1 = new IHIS.Framework.XBuseoCombo();
            this.dtpActingDate = new IHIS.Framework.XDatePicker();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlFillInBottom = new IHIS.Framework.XPanel();
            this.xPanel10 = new IHIS.Framework.XPanel();
            this.pnlDetailFill = new IHIS.Framework.XPanel();
            this.pnlDetailTop = new IHIS.Framework.XPanel();
            this.pnlDetailDate = new IHIS.Framework.XPanel();
            this.grdOCS1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.pnlDetailInfo = new IHIS.Framework.XPanel();
            this.pnlPaInfo = new IHIS.Framework.XPanel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.grdNUR1017 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.btnGamyum = new IHIS.Framework.XButton();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.pnlAllergy = new IHIS.Framework.XPanel();
            this.pnlOUT0106 = new IHIS.Framework.XPanel();
            this.grdOUT0106 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.btnOUt0106 = new IHIS.Framework.XButton();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.btnAllergy = new IHIS.Framework.XButton();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.pnlSang = new IHIS.Framework.XPanel();
            this.grdSang = new IHIS.Framework.XEditGrid();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pbxReserDate = new System.Windows.Forms.PictureBox();
            this.pbxCPL = new System.Windows.Forms.PictureBox();
            this.btnCPL = new System.Windows.Forms.Button();
            this.btnTodayOrder = new System.Windows.Forms.Button();
            this.btnPostOrder = new System.Windows.Forms.Button();
            this.btnPreOrder = new System.Windows.Forms.Button();
            this.fwkActor = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.pnlFillInTop = new IHIS.Framework.XPanel();
            this.btnFindUser = new IHIS.Framework.XButton();
            this.dbxUserName = new IHIS.Framework.XDisplayBox();
            this.dbxUserId = new IHIS.Framework.XDisplayBox();
            this.btnClear = new IHIS.Framework.XButton();
            this.dbxActor_name = new IHIS.Framework.XDisplayBox();
            this.fbxActor = new IHIS.Framework.XFindBox();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.patInfo = new IHIS.Framework.XPatientBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.lbAddress = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.lbAge = new IHIS.Framework.XLabel();
            this.lbSex = new IHIS.Framework.XLabel();
            this.lbSuname = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnLabel = new IHIS.Framework.XButton();
            this.btnChkAllJubsu = new IHIS.Framework.XButton();
            this.btnUseTimeChk = new IHIS.Framework.XButton();
            this.btnPrintSetup = new IHIS.Framework.XButton();
            this.btnReInjActScrip = new IHIS.Framework.XButton();
            this.btnReser = new IHIS.Framework.XButton();
            this.btnReLabel = new IHIS.Framework.XButton();
            this.btnInjActScrip = new IHIS.Framework.XButton();
            this.layLableNew = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.layOrderPrint = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.layTemp = new IHIS.Framework.MultiLayout();
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
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.layReserDate = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.layCPLOrderYN = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.layPrintName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.mlayConstantInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.pnlFillCenter.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1016)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xBuseoCombo1)).BeginInit();
            this.pnlFillInBottom.SuspendLayout();
            this.xPanel10.SuspendLayout();
            this.pnlDetailFill.SuspendLayout();
            this.pnlDetailTop.SuspendLayout();
            this.pnlDetailDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
            this.pnlDetailInfo.SuspendLayout();
            this.pnlPaInfo.SuspendLayout();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1017)).BeginInit();
            this.pnlAllergy.SuspendLayout();
            this.pnlOUT0106.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0106)).BeginInit();
            this.pnlSang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSang)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReserDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCPL)).BeginInit();
            this.pnlFillInTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patInfo)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layLableNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserDate)).BeginInit();
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
            this.ImageList.Images.SetKeyName(6, "항암요법.gif");
            this.ImageList.Images.SetKeyName(7, "핑크볼.gif");
            this.ImageList.Images.SetKeyName(8, "채열실.ico");
            this.ImageList.Images.SetKeyName(9, "RR401.ico");
            this.ImageList.Images.SetKeyName(10, "작성.gif");
            this.ImageList.Images.SetKeyName(11, "임상연구.gif");
            this.ImageList.Images.SetKeyName(12, "조회.gif");
            this.ImageList.Images.SetKeyName(13, "적용.gif");
            this.ImageList.Images.SetKeyName(14, "삭제.gif");
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // dtpQueryDate
            // 
            resources.ApplyResources(this.dtpQueryDate, "dtpQueryDate");
            this.dtpQueryDate.IsVietnameseYearType = false;
            this.dtpQueryDate.Name = "dtpQueryDate";
            this.dtpQueryDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ApplyPaintEventToAllColumn = true;
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell91,
            this.xEditGridCell87,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell65,
            this.xEditGridCell78});
            this.grdMaster.ColPerLine = 4;
            this.grdMaster.Cols = 5;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(39);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMaster_GridCellPainting);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            this.grdMaster.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMaster_QueryEnd);
            this.grdMaster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdMaster_MouseDown);
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "trial_patient_yn";
            this.xEditGridCell91.CellWidth = 86;
            this.xEditGridCell91.Col = 1;
            this.xEditGridCell91.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsReadOnly = true;
            this.xEditGridCell91.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "reser_gubun";
            this.xEditGridCell87.CellWidth = 22;
            this.xEditGridCell87.Col = 2;
            this.xEditGridCell87.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell87.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsReadOnly = true;
            this.xEditGridCell87.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "1";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "2";
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 79;
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.CellWidth = 98;
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "order_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "reser_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "jubsu_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "gwa";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "gwa_name";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "doctor";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "doctor_name";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "jundal_part";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "acting_flag";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "chkb";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "bed";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 1;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 0;
            // 
            // pnlFillCenter
            // 
            resources.ApplyResources(this.pnlFillCenter, "pnlFillCenter");
            this.pnlFillCenter.Controls.Add(this.xPanel4);
            this.pnlFillCenter.Name = "pnlFillCenter";
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.btnCmtClear);
            this.xPanel4.Controls.Add(this.dboxCmt);
            this.xPanel4.Controls.Add(this.txtSilsiRemark);
            this.xPanel4.Controls.Add(this.xLabel7);
            this.xPanel4.Controls.Add(this.xLabel2);
            this.xPanel4.Controls.Add(this.fbxCmt);
            this.xPanel4.Name = "xPanel4";
            // 
            // btnCmtClear
            // 
            resources.ApplyResources(this.btnCmtClear, "btnCmtClear");
            this.btnCmtClear.ImageIndex = 14;
            this.btnCmtClear.ImageList = this.ImageList;
            this.btnCmtClear.Name = "btnCmtClear";
            this.btnCmtClear.Click += new System.EventHandler(this.btnCmtClear_Click);
            // 
            // dboxCmt
            // 
            resources.ApplyResources(this.dboxCmt, "dboxCmt");
            this.dboxCmt.EdgeRounding = false;
            this.dboxCmt.Name = "dboxCmt";
            // 
            // txtSilsiRemark
            // 
            resources.ApplyResources(this.txtSilsiRemark, "txtSilsiRemark");
            this.txtSilsiRemark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSilsiRemark.EnterKeyToTab = false;
            this.txtSilsiRemark.Name = "txtSilsiRemark";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // fbxCmt
            // 
            resources.ApplyResources(this.fbxCmt, "fbxCmt");
            this.fbxCmt.FindWorker = this.fwkCmt;
            this.fbxCmt.Name = "fbxCmt";
            this.fbxCmt.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxCmt_FindClick);
            this.fbxCmt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxCmt_DataValidating);
            // 
            // fwkCmt
            // 
            this.fwkCmt.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCmt.ExecuteQuery = null;
            this.fwkCmt.FormText = global::IHIS.INJS.Properties.Resources.fwkCmtText;
            this.fwkCmt.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCmt.ParamList")));
            this.fwkCmt.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCmt.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 140;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // grdNUR1016
            // 
            resources.ApplyResources(this.grdNUR1016, "grdNUR1016");
            this.grdNUR1016.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell20});
            this.grdNUR1016.ColPerLine = 1;
            this.grdNUR1016.Cols = 2;
            this.grdNUR1016.ExecuteQuery = null;
            this.grdNUR1016.FixedCols = 1;
            this.grdNUR1016.FixedRows = 1;
            this.grdNUR1016.HeaderHeights.Add(21);
            this.grdNUR1016.Name = "grdNUR1016";
            this.grdNUR1016.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNUR1016.ParamList")));
            this.grdNUR1016.ReadOnly = true;
            this.grdNUR1016.RowHeaderVisible = true;
            this.grdNUR1016.Rows = 2;
            this.grdNUR1016.ToolTipActive = true;
            this.grdNUR1016.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1016_QueryStarting);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "allergy_info";
            this.xEditGridCell20.CellWidth = 168;
            this.xEditGridCell20.Col = 1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            // 
            // xGridCell1
            // 
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            // 
            // xGridCell2
            // 
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell12,
            this.xEditGridCell30,
            this.xEditGridCell19,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell9,
            this.xEditGridCell34,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell21,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell18,
            this.xEditGridCell23,
            this.xEditGridCell43,
            this.xEditGridCell13,
            this.xEditGridCell44,
            this.xEditGridCell24,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell22,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell14,
            this.xEditGridCell59,
            this.xEditGridCell17,
            this.xEditGridCell60,
            this.xEditGridCell16,
            this.xEditGridCell15,
            this.xEditGridCell61,
            this.xEditGridCell64,
            this.xEditGridCell74,
            this.xEditGridCell76,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell86});
            this.grdDetail.ColPerLine = 13;
            this.grdDetail.Cols = 14;
            this.grdDetail.ControlBinding = true;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdDetail_GridColumnProtectModify);
            this.grdDetail.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdDetail_ItemValueChanging);
            this.grdDetail.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdDetail_RowFocusChanged);
            this.grdDetail.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDetail_GridCellPainting);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            this.grdDetail.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdDetail_QueryEnd);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell8.ApplyPaintingEvent = true;
            this.xEditGridCell8.CellName = "group_ser";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 30;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.SuppressRepeating = true;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell27.CellName = "pkinj1002";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell28.CellName = "fkinj1001";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell29.CellName = "fkocs1003";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.ApplyPaintingEvent = true;
            this.xEditGridCell12.CellName = "hangmog_name";
            this.xEditGridCell12.CellWidth = 249;
            this.xEditGridCell12.Col = 4;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell30.CellName = "seq";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell19.ApplyPaintingEvent = true;
            this.xEditGridCell19.CellName = "tonggye_code";
            this.xEditGridCell19.CellWidth = 110;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell31.CellName = "magam_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell32.CellName = "magam_jangso";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell33.CellName = "magam_ser";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell9.ApplyPaintingEvent = true;
            this.xEditGridCell9.CellName = "reser_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.CellWidth = 75;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.EnableSort = true;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell34.CellName = "reser_time";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell10.ApplyPaintingEvent = true;
            this.xEditGridCell10.CellName = "jubsu_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.CellWidth = 73;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.ApplyPaintingEvent = true;
            this.xEditGridCell11.CellName = "hangmog_code";
            this.xEditGridCell11.CellWidth = 70;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.EnableSort = true;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell35.CellName = "jusa_buui";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell36.CellName = "acting_jangso";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.ApplyPaintingEvent = true;
            this.xEditGridCell37.CellName = "acting_date";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell37.CellWidth = 94;
            this.xEditGridCell37.Col = 13;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell37.EnableSort = true;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell38.CellName = "acting_time";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell39.CellName = "company_code";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell40.CellName = "lot_no";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell21.ApplyPaintingEvent = true;
            this.xEditGridCell21.CellName = "chasu_code";
            this.xEditGridCell21.CellWidth = 25;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell41.CellName = "pw_result";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell42.CellName = "cs_result";
            this.xEditGridCell42.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            this.xEditGridCell42.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell18.ApplyPaintingEvent = true;
            this.xEditGridCell18.CellName = "ast";
            this.xEditGridCell18.CellWidth = 27;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.ApplyPaintingEvent = true;
            this.xEditGridCell23.CellName = "acting_flag";
            this.xEditGridCell23.CellWidth = 30;
            this.xEditGridCell23.Col = 1;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell43.CellName = "sunab_date";
            this.xEditGridCell43.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            this.xEditGridCell43.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell13.ApplyPaintingEvent = true;
            this.xEditGridCell13.CellName = "sunab_suryang";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell13.CellWidth = 28;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell44.CellName = "fkout1001";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            this.xEditGridCell44.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell24.ApplyPaintingEvent = true;
            this.xEditGridCell24.CellName = "cancer_yn";
            this.xEditGridCell24.CellWidth = 50;
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell45.CellName = "bunho";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            this.xEditGridCell45.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "remark_chk";
            this.xEditGridCell46.CellWidth = 34;
            this.xEditGridCell46.Col = 11;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.IsUpdCol = false;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell47.CellName = "dc_yn";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell48.CellName = "jusa_tong_cnt";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            this.xEditGridCell48.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell49.CellName = "other_buseo_yn";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            this.xEditGridCell49.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell50.CellName = "jujongja";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            this.xEditGridCell50.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.ApplyPaintingEvent = true;
            this.xEditGridCell22.CellName = "jujongja_name";
            this.xEditGridCell22.CellWidth = 82;
            this.xEditGridCell22.Col = 12;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell51.CellName = "yebang_jujong_chk";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            this.xEditGridCell51.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell52.CellName = "actday_chk";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            this.xEditGridCell52.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell53.CellName = "gwa";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell54.CellName = "bannab_yn";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            this.xEditGridCell54.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell55.CellName = "skin_yn";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsReadOnly = true;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            this.xEditGridCell55.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell56.CellName = "chunggu_date";
            this.xEditGridCell56.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell57.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell57.ApplyPaintingEvent = true;
            this.xEditGridCell57.CellName = "order_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.CellWidth = 75;
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.EnableSort = true;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            this.xEditGridCell57.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell58.CellName = "doctor";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsReadOnly = true;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            this.xEditGridCell58.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell14.ApplyPaintingEvent = true;
            this.xEditGridCell14.CellName = "ord_danui";
            this.xEditGridCell14.CellWidth = 35;
            this.xEditGridCell14.Col = 8;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell59.CellName = "hope_date_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsReadOnly = true;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            this.xEditGridCell59.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.ApplyPaintingEvent = true;
            this.xEditGridCell17.CellName = "bogyong_code";
            this.xEditGridCell17.CellWidth = 70;
            this.xEditGridCell17.Col = 10;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.ApplyPaintingEvent = true;
            this.xEditGridCell60.CellName = "suryang";
            this.xEditGridCell60.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell60.CellWidth = 35;
            this.xEditGridCell60.Col = 5;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.ApplyPaintingEvent = true;
            this.xEditGridCell16.CellName = "dv";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.CellWidth = 35;
            this.xEditGridCell16.Col = 7;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.ApplyPaintingEvent = true;
            this.xEditGridCell15.CellName = "dv_time";
            this.xEditGridCell15.CellWidth = 35;
            this.xEditGridCell15.Col = 6;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell61.CellName = "slip_code";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            this.xEditGridCell61.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.ApplyPaintingEvent = true;
            this.xEditGridCell64.CellName = "jusa_yn";
            this.xEditGridCell64.CellWidth = 22;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.ApplyPaintingEvent = true;
            this.xEditGridCell74.CellLen = 25;
            this.xEditGridCell74.CellName = "mix_group";
            this.xEditGridCell74.CellWidth = 27;
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsReadOnly = true;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            this.xEditGridCell74.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "old_acting_flag";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsUpdatable = false;
            this.xEditGridCell76.IsUpdCol = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.BindControl = this.txtSilsiRemark;
            this.xEditGridCell66.CellLen = 200;
            this.xEditGridCell66.CellName = "silsi_remark";
            this.xEditGridCell66.CellWidth = 60;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "hope_date";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "order_gubun";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell86.CellName = "tonggye_code_name";
            this.xEditGridCell86.CellWidth = 153;
            this.xEditGridCell86.Col = 9;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.SuppressRepeating = true;
            // 
            // pnlLeft
            // 
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Controls.Add(this.xPanel2);
            this.pnlLeft.Controls.Add(this.xPanel3);
            this.pnlLeft.DrawBorder = true;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.grdMaster);
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.txtTimeInterval);
            this.xPanel3.Controls.Add(this.tbxTimer);
            this.xPanel3.Controls.Add(this.cboTime);
            this.xPanel3.Controls.Add(this.xLabel14);
            this.xPanel3.Controls.Add(this.lbTime);
            this.xPanel3.Controls.Add(this.lblTitle);
            this.xPanel3.Controls.Add(this.rbtDone);
            this.xPanel3.Controls.Add(this.rbtWait);
            this.xPanel3.Controls.Add(this.lbBuseo);
            this.xPanel3.Controls.Add(this.xBuseoCombo1);
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Controls.Add(this.dtpQueryDate);
            this.xPanel3.Name = "xPanel3";
            // 
            // txtTimeInterval
            // 
            resources.ApplyResources(this.txtTimeInterval, "txtTimeInterval");
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.txtTimeInterval.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtTimeInterval_DataValidating);
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
            this.cboTime.SelectionChangeCommitted += new System.EventHandler(this.cboTime_SelectionChangeCommitted);
            // 
            // xLabel14
            // 
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel14.Name = "xLabel14";
            // 
            // lbTime
            // 
            resources.ApplyResources(this.lbTime, "lbTime");
            this.lbTime.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbTime.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lbTime.Name = "lbTime";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblTitle.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Teal);
            this.lblTitle.Name = "lblTitle";
            // 
            // rbtDone
            // 
            resources.ApplyResources(this.rbtDone, "rbtDone");
            this.rbtDone.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightPink);
            this.rbtDone.ImageList = this.ImageList;
            this.rbtDone.Name = "rbtDone";
            this.rbtDone.UseVisualStyleBackColor = false;
            this.rbtDone.CheckedChanged += new System.EventHandler(this.rdoCheckedChanged);
            // 
            // rbtWait
            // 
            resources.ApplyResources(this.rbtWait, "rbtWait");
            this.rbtWait.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))));
            this.rbtWait.Checked = true;
            this.rbtWait.ImageList = this.ImageList;
            this.rbtWait.Name = "rbtWait";
            this.rbtWait.TabStop = true;
            this.rbtWait.UseVisualStyleBackColor = false;
            this.rbtWait.CheckedChanged += new System.EventHandler(this.rdoCheckedChanged);
            // 
            // lbBuseo
            // 
            resources.ApplyResources(this.lbBuseo, "lbBuseo");
            this.lbBuseo.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbBuseo.Name = "lbBuseo";
            // 
            // xBuseoCombo1
            // 
            resources.ApplyResources(this.xBuseoCombo1, "xBuseoCombo1");
            this.xBuseoCombo1.Name = "xBuseoCombo1";
            this.xBuseoCombo1.SelectedIndexChanged += new System.EventHandler(this.xBuseoCombo1_SelectedIndexChanged);
            // 
            // dtpActingDate
            // 
            resources.ApplyResources(this.dtpActingDate, "dtpActingDate");
            this.dtpActingDate.IsVietnameseYearType = false;
            this.dtpActingDate.Name = "dtpActingDate";
            this.dtpActingDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpActingDate_DataValidating);
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // pnlFillInBottom
            // 
            resources.ApplyResources(this.pnlFillInBottom, "pnlFillInBottom");
            this.pnlFillInBottom.Controls.Add(this.xPanel10);
            this.pnlFillInBottom.Controls.Add(this.xPanel1);
            this.pnlFillInBottom.Controls.Add(this.pnlFillCenter);
            this.pnlFillInBottom.DrawBorder = true;
            this.pnlFillInBottom.Name = "pnlFillInBottom";
            // 
            // xPanel10
            // 
            resources.ApplyResources(this.xPanel10, "xPanel10");
            this.xPanel10.Controls.Add(this.pnlDetailFill);
            this.xPanel10.Controls.Add(this.pnlDetailTop);
            this.xPanel10.Name = "xPanel10";
            // 
            // pnlDetailFill
            // 
            resources.ApplyResources(this.pnlDetailFill, "pnlDetailFill");
            this.pnlDetailFill.Controls.Add(this.grdDetail);
            this.pnlDetailFill.Name = "pnlDetailFill";
            // 
            // pnlDetailTop
            // 
            resources.ApplyResources(this.pnlDetailTop, "pnlDetailTop");
            this.pnlDetailTop.Controls.Add(this.pnlDetailDate);
            this.pnlDetailTop.Controls.Add(this.pnlDetailInfo);
            this.pnlDetailTop.Name = "pnlDetailTop";
            // 
            // pnlDetailDate
            // 
            resources.ApplyResources(this.pnlDetailDate, "pnlDetailDate");
            this.pnlDetailDate.Controls.Add(this.grdOCS1003);
            this.pnlDetailDate.Name = "pnlDetailDate";
            // 
            // grdOCS1003
            // 
            resources.ApplyResources(this.grdOCS1003, "grdOCS1003");
            this.grdOCS1003.ApplyPaintEventToAllColumn = true;
            this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell75,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell92});
            this.grdOCS1003.ColPerLine = 5;
            this.grdOCS1003.Cols = 6;
            this.grdOCS1003.ExecuteQuery = null;
            this.grdOCS1003.FixedCols = 1;
            this.grdOCS1003.FixedRows = 1;
            this.grdOCS1003.HeaderHeights.Add(21);
            this.grdOCS1003.Name = "grdOCS1003";
            this.grdOCS1003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS1003.ParamList")));
            this.grdOCS1003.RowHeaderVisible = true;
            this.grdOCS1003.Rows = 2;
            this.grdOCS1003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1003.ToolTipActive = true;
            this.grdOCS1003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1003_RowFocusChanged);
            this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
            this.grdOCS1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1003_QueryStarting);
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "reser_date";
            this.xEditGridCell71.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell71.CellWidth = 91;
            this.xEditGridCell71.Col = 2;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsReadOnly = true;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "order_date";
            this.xEditGridCell72.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell72.CellWidth = 96;
            this.xEditGridCell72.Col = 1;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "acting_date";
            this.xEditGridCell73.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell73.CellWidth = 92;
            this.xEditGridCell73.Col = 3;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsReadOnly = true;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "gwa";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsReadOnly = true;
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "gwa_name";
            this.xEditGridCell79.CellWidth = 69;
            this.xEditGridCell79.Col = 4;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsReadOnly = true;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "doctor";
            this.xEditGridCell80.CellWidth = 180;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsReadOnly = true;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "doctor_name";
            this.xEditGridCell81.CellWidth = 111;
            this.xEditGridCell81.Col = 5;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "if_data_send_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // pnlDetailInfo
            // 
            resources.ApplyResources(this.pnlDetailInfo, "pnlDetailInfo");
            this.pnlDetailInfo.Controls.Add(this.pnlPaInfo);
            this.pnlDetailInfo.Controls.Add(this.pnlSang);
            this.pnlDetailInfo.Name = "pnlDetailInfo";
            // 
            // pnlPaInfo
            // 
            resources.ApplyResources(this.pnlPaInfo, "pnlPaInfo");
            this.pnlPaInfo.Controls.Add(this.xPanel6);
            this.pnlPaInfo.Controls.Add(this.pnlAllergy);
            this.pnlPaInfo.Name = "pnlPaInfo";
            // 
            // xPanel6
            // 
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Controls.Add(this.grdNUR1017);
            this.xPanel6.Controls.Add(this.btnGamyum);
            this.xPanel6.Controls.Add(this.xLabel10);
            this.xPanel6.Name = "xPanel6";
            // 
            // grdNUR1017
            // 
            resources.ApplyResources(this.grdNUR1017, "grdNUR1017");
            this.grdNUR1017.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell88,
            this.xEditGridCell89});
            this.grdNUR1017.ColPerLine = 2;
            this.grdNUR1017.Cols = 3;
            this.grdNUR1017.ExecuteQuery = null;
            this.grdNUR1017.FixedCols = 1;
            this.grdNUR1017.FixedRows = 1;
            this.grdNUR1017.HeaderHeights.Add(21);
            this.grdNUR1017.Name = "grdNUR1017";
            this.grdNUR1017.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNUR1017.ParamList")));
            this.grdNUR1017.ReadOnly = true;
            this.grdNUR1017.RowHeaderVisible = true;
            this.grdNUR1017.Rows = 2;
            this.grdNUR1017.ToolTipActive = true;
            this.grdNUR1017.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1017_QueryStarting);
            this.grdNUR1017.PreEndInitializing += new System.EventHandler(this.grdNUR1017_PreEndInitializing);
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "infe_jearyo";
            this.xEditGridCell88.CellWidth = 136;
            this.xEditGridCell88.Col = 1;
            this.xEditGridCell88.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsReadOnly = true;
            this.xEditGridCell88.IsUpdatable = false;
            this.xEditGridCell88.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "infe_code";
            this.xEditGridCell89.CellWidth = 286;
            this.xEditGridCell89.Col = 2;
            this.xEditGridCell89.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.MaxDropDownItems = 10;
            this.xEditGridCell89.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // btnGamyum
            // 
            resources.ApplyResources(this.btnGamyum, "btnGamyum");
            this.btnGamyum.ImageIndex = 11;
            this.btnGamyum.ImageList = this.ImageList;
            this.btnGamyum.Name = "btnGamyum";
            this.btnGamyum.Click += new System.EventHandler(this.btnGamyum_Click);
            // 
            // xLabel10
            // 
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel10.Name = "xLabel10";
            // 
            // pnlAllergy
            // 
            resources.ApplyResources(this.pnlAllergy, "pnlAllergy");
            this.pnlAllergy.Controls.Add(this.grdNUR1016);
            this.pnlAllergy.Controls.Add(this.pnlOUT0106);
            this.pnlAllergy.Controls.Add(this.btnAllergy);
            this.pnlAllergy.Controls.Add(this.xLabel9);
            this.pnlAllergy.Name = "pnlAllergy";
            // 
            // pnlOUT0106
            // 
            resources.ApplyResources(this.pnlOUT0106, "pnlOUT0106");
            this.pnlOUT0106.Controls.Add(this.grdOUT0106);
            this.pnlOUT0106.Controls.Add(this.btnOUt0106);
            this.pnlOUT0106.Controls.Add(this.xLabel12);
            this.pnlOUT0106.Name = "pnlOUT0106";
            // 
            // grdOUT0106
            // 
            resources.ApplyResources(this.grdOUT0106, "grdOUT0106");
            this.grdOUT0106.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell69});
            this.grdOUT0106.ColPerLine = 1;
            this.grdOUT0106.Cols = 2;
            this.grdOUT0106.ExecuteQuery = null;
            this.grdOUT0106.FixedCols = 1;
            this.grdOUT0106.FixedRows = 1;
            this.grdOUT0106.HeaderHeights.Add(20);
            this.grdOUT0106.Name = "grdOUT0106";
            this.grdOUT0106.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT0106.ParamList")));
            this.grdOUT0106.ReadOnly = true;
            this.grdOUT0106.RowHeaderVisible = true;
            this.grdOUT0106.Rows = 2;
            this.grdOUT0106.ToolTipActive = true;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "comments";
            this.xEditGridCell69.CellWidth = 174;
            this.xEditGridCell69.Col = 1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsUpdatable = false;
            // 
            // btnOUt0106
            // 
            resources.ApplyResources(this.btnOUt0106, "btnOUt0106");
            this.btnOUt0106.ImageIndex = 10;
            this.btnOUt0106.ImageList = this.ImageList;
            this.btnOUt0106.Name = "btnOUt0106";
            this.btnOUt0106.Click += new System.EventHandler(this.btnOUt0106_Click);
            // 
            // xLabel12
            // 
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel12.Name = "xLabel12";
            // 
            // btnAllergy
            // 
            resources.ApplyResources(this.btnAllergy, "btnAllergy");
            this.btnAllergy.ImageIndex = 9;
            this.btnAllergy.ImageList = this.ImageList;
            this.btnAllergy.Name = "btnAllergy";
            this.btnAllergy.Click += new System.EventHandler(this.btnAllergy_Click);
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel9.Name = "xLabel9";
            // 
            // pnlSang
            // 
            resources.ApplyResources(this.pnlSang, "pnlSang");
            this.pnlSang.Controls.Add(this.grdSang);
            this.pnlSang.Controls.Add(this.xLabel3);
            this.pnlSang.Name = "pnlSang";
            // 
            // grdSang
            // 
            resources.ApplyResources(this.grdSang, "grdSang");
            this.grdSang.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85});
            this.grdSang.ColPerLine = 3;
            this.grdSang.Cols = 4;
            this.grdSang.ExecuteQuery = null;
            this.grdSang.FixedCols = 1;
            this.grdSang.FixedRows = 1;
            this.grdSang.HeaderHeights.Add(21);
            this.grdSang.Name = "grdSang";
            this.grdSang.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSang.ParamList")));
            this.grdSang.RowHeaderVisible = true;
            this.grdSang.Rows = 2;
            this.grdSang.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSang_QueryStarting);
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "pk_seq";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.IsUpdatable = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "sang_name";
            this.xEditGridCell83.CellWidth = 295;
            this.xEditGridCell83.Col = 2;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsReadOnly = true;
            this.xEditGridCell83.IsUpdatable = false;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "ju_sang_yn";
            this.xEditGridCell84.CellWidth = 37;
            this.xEditGridCell84.Col = 1;
            this.xEditGridCell84.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsReadOnly = true;
            this.xEditGridCell84.IsUpdatable = false;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "sang_start_date";
            this.xEditGridCell85.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell85.CellWidth = 81;
            this.xEditGridCell85.Col = 3;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsUpdatable = false;
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel3.Name = "xLabel3";
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.pbxReserDate);
            this.xPanel1.Controls.Add(this.pbxCPL);
            this.xPanel1.Controls.Add(this.btnCPL);
            this.xPanel1.Controls.Add(this.btnTodayOrder);
            this.xPanel1.Controls.Add(this.btnPostOrder);
            this.xPanel1.Controls.Add(this.btnPreOrder);
            this.xPanel1.Controls.Add(this.dtpActingDate);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Name = "xPanel1";
            // 
            // pbxReserDate
            // 
            resources.ApplyResources(this.pbxReserDate, "pbxReserDate");
            this.pbxReserDate.BackColor = System.Drawing.Color.LightBlue;
            this.pbxReserDate.Name = "pbxReserDate";
            this.pbxReserDate.TabStop = false;
            // 
            // pbxCPL
            // 
            resources.ApplyResources(this.pbxCPL, "pbxCPL");
            this.pbxCPL.BackColor = System.Drawing.Color.LightBlue;
            this.pbxCPL.Name = "pbxCPL";
            this.pbxCPL.TabStop = false;
            // 
            // btnCPL
            // 
            resources.ApplyResources(this.btnCPL, "btnCPL");
            this.btnCPL.BackColor = System.Drawing.Color.LightBlue;
            this.btnCPL.ImageList = this.ImageList;
            this.btnCPL.Name = "btnCPL";
            this.btnCPL.UseVisualStyleBackColor = false;
            this.btnCPL.Click += new System.EventHandler(this.btnCPL_Click);
            // 
            // btnTodayOrder
            // 
            resources.ApplyResources(this.btnTodayOrder, "btnTodayOrder");
            this.btnTodayOrder.BackColor = System.Drawing.Color.LightBlue;
            this.btnTodayOrder.ImageList = this.ImageList;
            this.btnTodayOrder.Name = "btnTodayOrder";
            this.btnTodayOrder.UseVisualStyleBackColor = false;
            this.btnTodayOrder.Click += new System.EventHandler(this.btnTodayOrder_Click);
            // 
            // btnPostOrder
            // 
            resources.ApplyResources(this.btnPostOrder, "btnPostOrder");
            this.btnPostOrder.BackColor = System.Drawing.Color.LightBlue;
            this.btnPostOrder.ImageList = this.ImageList;
            this.btnPostOrder.Name = "btnPostOrder";
            this.btnPostOrder.UseVisualStyleBackColor = false;
            this.btnPostOrder.Click += new System.EventHandler(this.btnPostOrder_Click);
            // 
            // btnPreOrder
            // 
            resources.ApplyResources(this.btnPreOrder, "btnPreOrder");
            this.btnPreOrder.BackColor = System.Drawing.Color.LightBlue;
            this.btnPreOrder.ImageList = this.ImageList;
            this.btnPreOrder.Name = "btnPreOrder";
            this.btnPreOrder.UseVisualStyleBackColor = false;
            this.btnPreOrder.Click += new System.EventHandler(this.btnPreOrder_Click);
            // 
            // fwkActor
            // 
            this.fwkActor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkActor.ExecuteQuery = null;
            this.fwkActor.FormText = global::IHIS.INJS.Properties.Resources.fwkCmtText;
            this.fwkActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkActor.ParamList")));
            this.fwkActor.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkActor.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "user_id";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "user_name";
            this.findColumnInfo4.ColWidth = 140;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // pnlFillInTop
            // 
            resources.ApplyResources(this.pnlFillInTop, "pnlFillInTop");
            this.pnlFillInTop.Controls.Add(this.btnFindUser);
            this.pnlFillInTop.Controls.Add(this.dbxUserName);
            this.pnlFillInTop.Controls.Add(this.dbxUserId);
            this.pnlFillInTop.Controls.Add(this.btnClear);
            this.pnlFillInTop.Controls.Add(this.dbxActor_name);
            this.pnlFillInTop.Controls.Add(this.fbxActor);
            this.pnlFillInTop.Controls.Add(this.xLabel13);
            this.pnlFillInTop.Controls.Add(this.patInfo);
            this.pnlFillInTop.Controls.Add(this.xLabel8);
            this.pnlFillInTop.Controls.Add(this.lbAddress);
            this.pnlFillInTop.Controls.Add(this.xLabel6);
            this.pnlFillInTop.Controls.Add(this.xLabel5);
            this.pnlFillInTop.Controls.Add(this.lbAge);
            this.pnlFillInTop.Controls.Add(this.lbSex);
            this.pnlFillInTop.Controls.Add(this.lbSuname);
            this.pnlFillInTop.DrawBorder = true;
            this.pnlFillInTop.Name = "pnlFillInTop";
            // 
            // btnFindUser
            // 
            resources.ApplyResources(this.btnFindUser, "btnFindUser");
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // dbxUserName
            // 
            resources.ApplyResources(this.dbxUserName, "dbxUserName");
            this.dbxUserName.Name = "dbxUserName";
            // 
            // dbxUserId
            // 
            resources.ApplyResources(this.dbxUserId, "dbxUserId");
            this.dbxUserId.Name = "dbxUserId";
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.ImageIndex = 14;
            this.btnClear.ImageList = this.ImageList;
            this.btnClear.Name = "btnClear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dbxActor_name
            // 
            resources.ApplyResources(this.dbxActor_name, "dbxActor_name");
            this.dbxActor_name.EdgeRounding = false;
            this.dbxActor_name.Name = "dbxActor_name";
            // 
            // fbxActor
            // 
            resources.ApplyResources(this.fbxActor, "fbxActor");
            this.fbxActor.FindWorker = this.fwkActor;
            this.fbxActor.Name = "fbxActor";
            this.fbxActor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxActor_FindClick);
            this.fbxActor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxActor_DataValidating);
            // 
            // xLabel13
            // 
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel13.Name = "xLabel13";
            // 
            // patInfo
            // 
            resources.ApplyResources(this.patInfo, "patInfo");
            this.patInfo.Name = "patInfo";
            this.patInfo.PatientSelected += new System.EventHandler(this.patInfo_PatientSelected);
            this.patInfo.PatientSelectionFailed += new System.EventHandler(this.patInfo_PatientSelectionFailed);
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel8.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Desktop);
            this.xLabel8.Name = "xLabel8";
            // 
            // lbAddress
            // 
            resources.ApplyResources(this.lbAddress, "lbAddress");
            this.lbAddress.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbAddress.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Desktop);
            this.lbAddress.Name = "lbAddress";
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel6.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Desktop);
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel5.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Desktop);
            this.xLabel5.Name = "xLabel5";
            // 
            // lbAge
            // 
            resources.ApplyResources(this.lbAge, "lbAge");
            this.lbAge.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbAge.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Desktop);
            this.lbAge.Name = "lbAge";
            // 
            // lbSex
            // 
            resources.ApplyResources(this.lbSex, "lbSex");
            this.lbSex.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbSex.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Desktop);
            this.lbSex.Name = "lbSex";
            // 
            // lbSuname
            // 
            resources.ApplyResources(this.lbSuname, "lbSuname");
            this.lbSuname.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbSuname.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Desktop);
            this.lbSuname.Name = "lbSuname";
            // 
            // pnlBottom
            // 
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Controls.Add(this.btnLabel);
            this.pnlBottom.Controls.Add(this.btnChkAllJubsu);
            this.pnlBottom.Controls.Add(this.btnUseTimeChk);
            this.pnlBottom.Controls.Add(this.btnPrintSetup);
            this.pnlBottom.Controls.Add(this.btnReInjActScrip);
            this.pnlBottom.Controls.Add(this.btnReser);
            this.pnlBottom.Controls.Add(this.btnReLabel);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Controls.Add(this.btnInjActScrip);
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnLabel
            // 
            resources.ApplyResources(this.btnLabel, "btnLabel");
            this.btnLabel.ImageIndex = 5;
            this.btnLabel.ImageList = this.ImageList;
            this.btnLabel.Name = "btnLabel";
            this.btnLabel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnLabel.Click += new System.EventHandler(this.btnLabel_Click);
            // 
            // btnChkAllJubsu
            // 
            resources.ApplyResources(this.btnChkAllJubsu, "btnChkAllJubsu");
            this.btnChkAllJubsu.ImageIndex = 3;
            this.btnChkAllJubsu.ImageList = this.ImageList;
            this.btnChkAllJubsu.Name = "btnChkAllJubsu";
            this.btnChkAllJubsu.Click += new System.EventHandler(this.btnChkAllJubsu_Click);
            // 
            // btnUseTimeChk
            // 
            resources.ApplyResources(this.btnUseTimeChk, "btnUseTimeChk");
            this.btnUseTimeChk.ImageIndex = 3;
            this.btnUseTimeChk.ImageList = this.ImageList;
            this.btnUseTimeChk.Name = "btnUseTimeChk";
            this.btnUseTimeChk.Click += new System.EventHandler(this.btnUseTimeChk_Click);
            // 
            // btnPrintSetup
            // 
            resources.ApplyResources(this.btnPrintSetup, "btnPrintSetup");
            this.btnPrintSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSetup.Image")));
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // btnReInjActScrip
            // 
            resources.ApplyResources(this.btnReInjActScrip, "btnReInjActScrip");
            this.btnReInjActScrip.ImageIndex = 0;
            this.btnReInjActScrip.ImageList = this.ImageList;
            this.btnReInjActScrip.Name = "btnReInjActScrip";
            this.btnReInjActScrip.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnReInjActScrip.Click += new System.EventHandler(this.btnReInjActScrip_Click);
            // 
            // btnReser
            // 
            resources.ApplyResources(this.btnReser, "btnReser");
            this.btnReser.ImageIndex = 1;
            this.btnReser.ImageList = this.ImageList;
            this.btnReser.Name = "btnReser";
            this.btnReser.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReser.Click += new System.EventHandler(this.btnReser_Click);
            // 
            // btnReLabel
            // 
            resources.ApplyResources(this.btnReLabel, "btnReLabel");
            this.btnReLabel.ImageIndex = 0;
            this.btnReLabel.ImageList = this.ImageList;
            this.btnReLabel.Name = "btnReLabel";
            this.btnReLabel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnReLabel.Click += new System.EventHandler(this.btnReLabel_Click);
            // 
            // btnInjActScrip
            // 
            resources.ApplyResources(this.btnInjActScrip, "btnInjActScrip");
            this.btnInjActScrip.ImageIndex = 3;
            this.btnInjActScrip.ImageList = this.ImageList;
            this.btnInjActScrip.Name = "btnInjActScrip";
            this.btnInjActScrip.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnInjActScrip.Click += new System.EventHandler(this.btnInjActScrip_Click);
            // 
            // layLableNew
            // 
            this.layLableNew.ExecuteQuery = null;
            this.layLableNew.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem48});
            this.layLableNew.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layLableNew.ParamList")));
            this.layLableNew.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layLableNew_QueryEnd);
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
            this.multiLayoutItem4.DataName = "age";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "sex";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "order_date";
            this.multiLayoutItem6.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "cnt";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "order_suryang";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "order_danui";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "bogyong_name";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "jusa";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "jaeryo_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "order_remark";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "data_gubun";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "mix_yn";
            // 
            // layOrderPrint
            // 
            this.layOrderPrint.ExecuteQuery = null;
            this.layOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem20,
            this.multiLayoutItem21,
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
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54});
            this.layOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderPrint.ParamList")));
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "serial_v";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "bunho";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "suname";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "suname2";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "age";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "sex";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "order_date";
            this.multiLayoutItem40.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "jubsu_date";
            this.multiLayoutItem41.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "dv";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "order_suryang";
            this.multiLayoutItem43.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "order_danui";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "bogyong_name";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "jusa";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "jaeryo_name";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "order_remark";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "data_gubun";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "birth";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "doctor_name";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "gwa_name";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "order_remark_temp";
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "jujongja";
            this.xEditGridCell77.Col = 16;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            // 
            // layTemp
            // 
            this.layTemp.ExecuteQuery = null;
            this.layTemp.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem73});
            this.layTemp.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTemp.ParamList")));
            this.layTemp.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layTemp_QueryEnd);
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "serial_v";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "bunho";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "suname";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "suname2";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "age";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "sex";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "order_date";
            this.multiLayoutItem61.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "jubsu_date";
            this.multiLayoutItem62.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "dv";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "order_suryang";
            this.multiLayoutItem64.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "order_danui";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "bogyong_name";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "jusa";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "jaeryo_name";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "order_remark";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "data_gubun";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "birth";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "doctor_name";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "gwa_name";
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
            // layReserDate
            // 
            this.layReserDate.ExecuteQuery = null;
            this.layReserDate.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem15});
            this.layReserDate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserDate.ParamList")));
            this.layReserDate.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layReserDate_QueryStarting);
            this.layReserDate.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layReserDate_QueryEnd);
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "reser_date";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Date;
            // 
            // layCPLOrderYN
            // 
            this.layCPLOrderYN.ExecuteQuery = null;
            this.layCPLOrderYN.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layCPLOrderYN.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCPLOrderYN.ParamList")));
            this.layCPLOrderYN.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCPLOrderYN_QueryStarting);
            this.layCPLOrderYN.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layCPLOrderYN_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "cpl_order_yn";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "doctor";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 1;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
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
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // mlayConstantInfo
            // 
            this.mlayConstantInfo.ExecuteQuery = null;
            this.mlayConstantInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem16,
            this.multiLayoutItem17});
            this.mlayConstantInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayConstantInfo.ParamList")));
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "code";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "code_name";
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "trial_patient";
            this.xEditGridCell90.Col = 1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // INJ1001U01
            // 
            resources.ApplyResources(this, "$this");
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlFillInBottom);
            this.Controls.Add(this.pnlFillInTop);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Name = "INJ1001U01";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.INJ1001U01_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.pnlFillCenter.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1016)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xBuseoCombo1)).EndInit();
            this.pnlFillInBottom.ResumeLayout(false);
            this.xPanel10.ResumeLayout(false);
            this.pnlDetailFill.ResumeLayout(false);
            this.pnlDetailTop.ResumeLayout(false);
            this.pnlDetailDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
            this.pnlDetailInfo.ResumeLayout(false);
            this.pnlPaInfo.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1017)).EndInit();
            this.pnlAllergy.ResumeLayout(false);
            this.pnlOUT0106.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0106)).EndInit();
            this.pnlSang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSang)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReserDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCPL)).EndInit();
            this.pnlFillInTop.ResumeLayout(false);
            this.pnlFillInTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patInfo)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layLableNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Common Method, Variable

        // 1.예약일자가 당일보다 작은거
        [Browsable(false), DataBindable]
        public string OrderGunBun
        {
            get { return mOrderGunBun; }
        }

        // 전달파트가 점적실인 경우IR 이고 그외는 IRH 
        [Browsable(false), DataBindable]
        public string JundalPart
        {
            get { return mJundalPart; }
        }

        private string mOrderGunBun = "1";
        private string mJundalPart = string.Empty;
        private string mGwa, mDoctor;

        private DataTable itemTable = new DataTable("lable");

        #endregion

        #region 사용자 전역변수

        private string mPreOrderYn = "N", mPostOrderYn = "N"; //미래오더와 과거오더 유무확인 플래그
        private bool mOnReceiveBunho = false;
        private string mReceivedBunho = "";
        private string mReceivedDate = "";

        private int QueryTime;
        private int TimeVal;

        // 注射実施箋出力可否 
        private string injScripPrnYN = "";

        // ラベル出力可否 
        private string labelPrnYN = "";

        // 自動照会使用可否フラグ
        private string useTimeChkYN = "";

        // 受付チェックボックス一括適用フラグ
        private string chkAllJubsuYN = "";

        #endregion

        #region [환자정보 Reques/Receive Event]

        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                mOnReceiveBunho = true;
                mReceivedBunho = info.BunHo;
                mReceivedDate = info.SuName;
                this.dtpQueryDate.DataValidating -=
                    new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);
                this.dtpQueryDate.SetDataValue(mReceivedDate);
                this.dtpQueryDate.DataValidating +=
                    new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);
                if (this.rbtWait.Checked)
                {
                    xButtonList1_ButtonClick(null, new ButtonClickEventArgs(FunctionType.Query, false, false));
                }
                else
                {
                    this.rbtWait.Checked = true;
                }

            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(patInfo.BunHo))
            {
                return new XPatientInfo(patInfo.BunHo, "", "", "", this.ScreenName);
            }
            return null;
        }

        #endregion

        #region OnLoad

        private string mHospCode = "";

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);

            //tungtx added 2015/07/16
            //this.pnlBottom.Controls.Remove(this.dw_jusa_lable);
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INJ1001U01));
            ////this.dw_jusa_lable = new IHIS.Framework.XDataWindow();
            //resources.ApplyResources(this.dw_jusa_lable, "dw_jusa_lable");
            //this.dw_jusa_lable.DataWindowObject = "d_inj_jusa_lable";
            //this.dw_jusa_lable.LibraryList = "\\INJS\\injs.inj1001u01.pbd";
            //this.dw_jusa_lable.Name = "dw_jusa_lable";
            //this.pnlBottom.Controls.Add(this.dw_jusa_lable);


            mHospCode = EnvironInfo.HospCode;
            //this.grdDetail.SavePerformer = new XSavePerformer(this);

            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            if (this.Opener is IHIS.Framework.MdiForm &&
                (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable ||
                 this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            {
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);
            }

            this.xBuseoCombo1.SelectedIndexChanged -= new System.EventHandler(this.xBuseoCombo1_SelectedIndexChanged);
            this.dtpQueryDate.DataValidating -=
                new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);

            xBuseoCombo1.ComboItems.Add("IR", "IR");
            xBuseoCombo1.AcceptData();
            xBuseoCombo1.RefreshComboItems();
            this.dtpQueryDate.SetDataValue(currentDate.ToString("yyyy/MM/dd"));
            dtpActingDate.SetDataValue(currentDate);
            this.lblTitle.Text = Resources.lblTitleText;
            this.lblTitle.ForeColor = new XColor(Color.Teal);
            dtpQueryDate.Focus();
            itemTable.Columns.Add("fkinj1001", typeof(string));
            itemTable.Columns.Add("group_ser", typeof(string));
            itemTable.Columns.Add("mix_group", typeof(string));
            itemTable.Columns.Add("hope_date", typeof(string));
            itemTable.Columns.Add("order_date", typeof(string));
            itemTable.Columns.Add("order_gubun", typeof(string));
            itemTable.Columns.Add("bunho", typeof(string));
            itemTable.Columns.Add("gwa", typeof(string));
            itemTable.Columns.Add("doctor", typeof(string));

            if (EnvironInfo.CurrSystemID == "INJS")
            {
                xBuseoCombo1.SelectedValue = "IR";
                mJundalPart = "IR";
            }
            else
            {
                xBuseoCombo1.SelectedValue = "IR";
                mJundalPart = "IR";
            }
            xBuseoCombo1.AcceptData();

            this.mReceivedBunho = "";

            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("bunho"))
                {
                    this.mReceivedBunho = this.OpenParam["bunho"].ToString();
                }
                if (this.OpenParam.Contains("order_date"))
                {
                    this.mReceivedDate = this.OpenParam["order_date"].ToString();
                    this.dtpQueryDate.SetDataValue(mReceivedDate);
                }
                this.mOnReceiveBunho = true;
            }

            this.xBuseoCombo1.SelectedIndexChanged += new System.EventHandler(this.xBuseoCombo1_SelectedIndexChanged);
            this.dtpQueryDate.DataValidating +=
                new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);

            // タイマー設定
            this.setTimer();

            PostCallHelper.PostCall(new PostMethod(PostLoad));

            this.btnList.PerformClick(FunctionType.Query);

            // MED-14588
            this.SetDefaultDoctor();
        }

        #endregion

        #region [PostLoad]

        private string btn_autoQuery_yn = null;
        private string btn_injPrint_yn = null;
        private string btn_labelPrint_yn = null;
        private void PostLoad()
        {
            try
            {

                //TODO: INJ1001U01MlayConstantInfoRequest
                // 注射画面コントロールデータ照会
                //            this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME
                //                                            FROM INJ0102
                //                                           WHERE HOSP_CODE = :f_hosp_code
                //                                             AND CODE_TYPE = 'INJ_CONSTANT'
                //                                        ORDER BY CODE";

                this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                if (mlayConstantInfo.QueryLayout(true))
                {
                    for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                    {
                        if (this.mlayConstantInfo.GetItemString(i, "code").Equals("btn_autoQuery_yn"))
                            btn_autoQuery_yn = mlayConstantInfo.GetItemString(i, "code_name");

                        if (this.mlayConstantInfo.GetItemString(i, "code").Equals("btn_injPrint_yn"))
                            btn_injPrint_yn = mlayConstantInfo.GetItemString(i, "code_name");

                        if (this.mlayConstantInfo.GetItemString(i, "code").Equals("btn_labelPrint_yn"))
                            btn_labelPrint_yn = mlayConstantInfo.GetItemString(i, "code_name");
                    }
                }

                // ボタン設定

                // 自動照会
                if (btn_autoQuery_yn.Equals("Y"))
                {
                    this.useTimeChkYN = "Y";
                    this.btnUseTimeChk.ImageIndex = 3;

                    this.timer1.Start();
                    this.cboTime.Enabled = true;
                }
                else
                {
                    this.useTimeChkYN = "N";
                    this.btnUseTimeChk.ImageIndex = 2;

                    this.cboTime.Enabled = false;
                    this.timer1.Stop();
                }

                // 注射実施箋出力
                if (btn_injPrint_yn.Equals("Y"))
                {
                    this.injScripPrnYN = "Y";
                    this.btnInjActScrip.ImageIndex = 3;
                }
                else
                {
                    this.injScripPrnYN = "N";
                    this.btnInjActScrip.ImageIndex = 2;
                }

                // ラベル出力
                if (btn_labelPrint_yn.Equals("Y"))
                {
                    this.labelPrnYN = "Y";
                    this.btnLabel.ImageIndex = 3;
                }
                else
                {
                    this.labelPrnYN = "N";
                    this.btnLabel.ImageIndex = 2;
                }

                // 実施者に 現在ログインしている IDを セットする｡
                this.fbxActor.SetDataValue(UserInfo.UserID);
                this.dbxActor_name.SetDataValue(UserInfo.UserName);
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception on method PostLoad()" + ex.StackTrace);
            }
        }

        #endregion


        #region xButtonList1_ButtonClick

        private string mMsg = "";
        private string mCap = "";
        private bool mIsSaveSuccess = true;

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                //case FunctionType.Update:
                case FunctionType.Process:
                    e.IsBaseCall = false;
                    mIsSaveSuccess = false;

                    if (this.grdDetail.RowCount < 1) return;

                    // 未投与の場合
                    if (this.rbtWait.Checked)
                    {
                        for (int i = 0; i < this.grdDetail.RowCount; i++)
                        {
                            if (this.grdDetail.GetItemValue(i, "acting_flag").ToString() == "Y")
                            {
                                if (!this.checkActor(i))
                                {
                                    XMessageBox.Show(Resources.XMessageBox1, Resources.Caption1,
                                        MessageBoxIcon.Information);
                                    this.fbxActor.Focus();
                                    return;
                                }

                                if (!this.checkDate(i))
                                {
                                    return;
                                }
                            }
                        }
                    }

                    if (this.rbtDone.Checked)
                    {
                        foreach (DataRow dtRow in grdOCS1003.LayoutTable.Rows)
                        {
                            // 会計未処理のみ
                            if (dtRow["if_data_send_yn"].ToString() == "Y")
                            {
                                XMessageBox.Show(Resources.XMessageBox2, "", MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    this.grdDetailPreSaveLayout();

                    // 2015.04.27 deleted by AnhNV
                    // Connect to cloud: save grdDetail
                    //UpdateResult updateResult = GridDeatil_SaveLayout();
                    //if (updateResult != null && updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result)
                    //{
                    //    this.grdDetailSaveEnd();
                    //    this.mMsg = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox2_Ko
                    //        : Resources.XMessageBox2_JP;
                    //    this.mCap = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox3_Ko
                    //        : Resources.XMessageBox3_JP;
                    //    //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    mIsSaveSuccess = true;
                    //}
                    //else
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox4_Ko
                    //        : Resources.XMessageBox4_JP;
                    //    this.mMsg += "\r\n" + Service.ErrFullMsg;
                    //    this.mCap = NetInfo.Language == LangMode.Ko
                    //        ? Resources.XMessageBox5_Ko
                    //        : Resources.XMessageBox5_Jp;
                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    // 2015.04.27 Added by AnhNV
                    //https://sofiamedix.atlassian.net/browse/MED-11180 Manage injection order
                    if (!IHIS.Framework.Utilities.CheckInventory(grdDetail.LayoutTable))
                    {
                        return;
                    }

                    List<INJ1001U01SaveLayoutInfo> lstData = GetListDataForSaveLayout();

                    if (lstData.Count > 0)
                    {
                        INJ1001U01SaveLayoutArgs args = new INJ1001U01SaveLayoutArgs();
                        //args.UpdId = fbxActor.GetDataValue().ToString();
                        args.UpdId = dbxUserId.GetDataValue();
                        args.UserId = UserInfo.UserID;
                        args.SaveLayoutItem = lstData;
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, INJ1001U01SaveLayoutArgs>(args);

                        if (res.ExecutionStatus == ExecutionStatus.Success)
                        {
                            if (!TypeCheck.IsNull(res.Msg))
                            {
                                XMessageBox.Show(Resources.XMessageBox13 + res.Msg + Resources.XMessageBox12, Resources.Caption4, MessageBoxIcon.Warning);
                            }

                            if (res.Result)
                            {
                                this.grdDetailSaveEnd();
                                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox2_Ko : Resources.XMessageBox2_JP;
                                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox3_Ko : Resources.XMessageBox3_JP;
                                //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                mIsSaveSuccess = true;
                            }
                            else
                            {
                                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox4_Ko : Resources.XMessageBox4_JP;
                                this.mMsg += "\r\n" + Service.ErrFullMsg;
                                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox5_Ko : Resources.XMessageBox5_Jp;
                                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox4_Ko : Resources.XMessageBox4_JP;
                            this.mMsg += "\r\n" + Service.ErrFullMsg;
                            this.mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox5_Ko : Resources.XMessageBox5_Jp;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.clearDetailScreen();

                    this.grdMaster.QueryLayout(true);

                    if (this.mOnReceiveBunho)
                    {
                        grdMaster.SetFocusToItem(mReceiveBunhoRowNum, "bunho");

                        /*modify by CloudVersion team on 07-12-2015
                         *Bug MED-5868
                         * mReceiveBunhoRowNum = current row number of grdMaster
                         * mReceivedBunho = current patient ID
                         * => change logic: mReceiveBunhoRowNum to mReceivedBunho
                         */
                        //this.patInfo.SetPatientID(mReceiveBunhoRowNum.ToString());
                        this.patInfo.SetPatientID(mReceivedBunho.ToString());

                        mOnReceiveBunho = false;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 오더 코멘트 처리

        // order_comment
        private void Comment_MSG(bool dis_flag)
        {
            string remark = string.Empty;
            string reser_date = string.Empty;
            string curr_date = string.Empty;
            string msg = string.Empty;

            curr_date = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "reser_date").ToString().Trim();

            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                remark = grdDetail.GetItemString(i, "remark_chk").Trim();
                reser_date = grdDetail.GetItemString(i, "reser_date").ToString().Trim();

                if ((remark.Length > 0) && (reser_date == curr_date))
                {
                    msg += "・ " + remark + "\r\n";
                }
            }

            if (msg.Length > 0)
            {
                //txtOrdRemark.Text = msg;
                if (dis_flag)
                {
                    XMessageBox.Show(msg, Resources.XMessageBox6);
                }
            }
            else
            {
                //txtOrdRemark.Text = string.Empty;
            }
        }

        #endregion

        #region grdDetail 선택환자의 오더 묶음

        private void grdDetail_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            //hsyhsy
            //처방은 당일 시행 오더와 과거, 미래 오더는 별도의 색으로 구분하여 표시한다.
            DateTime ot = DateTime.Parse(e.DataRow["reser_date"].ToString());
            DateTime queryDate = DateTime.Parse(this.dtpQueryDate.GetDataValue());
            if (ot.CompareTo(queryDate) == 0)
            {
                e.BackColor = Color.White;
            }
            else
            {
                e.BackColor = XColor.XLabelGradientEndColor.Color;
            }

            if (e.RowNumber < 1) return;
        }

        private void grdDetail_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {

            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                if (e.RowNumber == i)
                {
                    this.grdDetail.SetItemValue(i, "acting_flag", e.ChangeValue.ToString());
                    this.grdDetail.SetItemValue(i, "jubsu_date",
                        (e.ChangeValue.ToString() == "Y" ? this.dtpActingDate.GetDataValue() : ""));
                    //this.grdDetail.SetItemValue(i, "old_acting_flag", this.grdDetail.GetItemString(i, "jubsu_date"));
                    this.grdDetail.SetItemValue(i, "acting_date",
                        (e.ChangeValue.ToString() == "Y" ? this.dtpActingDate.GetDataValue() : ""));
                    //this.grdDetail.SetItemValue(i, "jujongja", (e.ChangeValue.ToString() == "Y" ? this.fbxActor.GetDataValue().ToString() : ""));
                    //this.grdDetail.SetItemValue(i, "jujongja_name", (e.ChangeValue.ToString() == "Y" ? this.dbxActor_name.GetDataValue().ToString() : ""));

                    this.grdDetail.SetItemValue(i, "jujongja", (e.ChangeValue.ToString() == "Y" ? this.dbxUserId.GetDataValue().ToString() : ""));
                    this.grdDetail.SetItemValue(i, "jujongja_name", (e.ChangeValue.ToString() == "Y" ? this.dbxUserName.GetDataValue().ToString() : ""));

                    continue;
                }

                if (e.DataRow["mix_group"].ToString() == "")
                    continue;

                if (e.DataRow["group_ser"].ToString() == this.grdDetail.GetItemString(i, "group_ser") &&
                    e.DataRow["mix_group"].ToString() == this.grdDetail.GetItemString(i, "mix_group") &&
                    e.DataRow["hope_date"].ToString() == this.grdDetail.GetItemString(i, "hope_date") &&
                    e.DataRow["order_date"].ToString() == this.grdDetail.GetItemString(i, "order_date") &&
                    e.DataRow["order_gubun"].ToString().Trim().PadRight(2).Substring(1, 1) ==
                    this.grdDetail.GetItemString(i, "order_gubun").Trim().PadRight(2).Substring(1, 1))
                {
                    this.grdDetail.SetItemValue(i, "acting_flag", e.ChangeValue.ToString());
                    this.grdDetail.SetItemValue(i, "jubsu_date",
                        (e.ChangeValue.ToString() == "Y" ? this.dtpActingDate.GetDataValue() : ""));
                    //this.grdDetail.SetItemValue(i, "old_acting_flag", this.grdDetail.GetItemString(i, "jubsu_date"));
                    this.grdDetail.SetItemValue(i, "acting_date", (e.ChangeValue.ToString() == "Y" ? this.dtpActingDate.GetDataValue() : ""));
                    //this.grdDetail.SetItemValue(i, "jujongja", (e.ChangeValue.ToString() == "Y" ? this.fbxActor.GetDataValue().ToString() : ""));
                    //this.grdDetail.SetItemValue(i, "jujongja_name", (e.ChangeValue.ToString() == "Y" ? this.dbxActor_name.GetDataValue().ToString() : ""));

                    // https://sofiamedix.atlassian.net/browse/MED-14735
                    this.grdDetail.SetItemValue(i, "jujongja", (e.ChangeValue.ToString() == "Y" ? this.dbxUserId.GetDataValue().ToString() : ""));
                    this.grdDetail.SetItemValue(i, "jujongja_name", (e.ChangeValue.ToString() == "Y" ? this.dbxUserName.GetDataValue().ToString() : ""));
                }
            }

            itemTable.Rows.Clear();
        }

        private void grdDetail_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            //hsyhsy
            switch (e.ColName)
            {
                case "acting_flag":
                    //if (e.DataRow["acting_flag"].ToString() == "Y")
                    //{
                    //    if (e.DataRow["sunab_date"].ToString() != "")
                    //    {
                    //        e.Protect = true;
                    //        XMessageBox.Show(Resources.XMessageBox2, "", MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    //						DateTime ot = DateTime.Parse(e.DataRow["reser_date"].ToString());
                    //    //						if (mToDay.CompareTo(ot) != 0)
                    //    //						{
                    //    //							e.Protect = true;
                    //    //							string msg = (NetInfo.Language == LangMode.Ko ? "예약일자를 확인하시기 바랍니다." : 
                    //    //								"予約日付 ご確認くださいい");
                    //    //							XMessageBox.Show(msg);
                    //    //							return;;
                    //    //						}
                    //}
                    break;

                case "acting_date": // 投与済TABでは変更不可能
                    if (this.rbtDone.Checked) e.Protect = true;
                    return;

                default:
                    break;
            }

            e.Protect = false;
        }

        private void grdDetailQuery(string bunho, string reser_date, string gwa, string doctor, string acting_date)
        {
            //dsvDetail.ClearInLayout();


            if (!grdDetail.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }


        }

        private void grdDetail_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.layCPLOrderYN.QueryLayout();

            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);

            if (this.rbtWait.Checked) //선택한 버튼이 미투여버튼일 때. 2011.12.15
            {
                this.AutoCheck(); //자동 실시 체크 추가 2011.12.07 woo
                this.InputActingDate();
            }


            if (!_GroupedLoad)
            {
                _GroupedLoad = true;
                if (!this.grdNUR1016.QueryLayout(false))
                {
                    //XMessageBox.Show(Service.ErrFullMsg);
                }
                if (!this.grdNUR1017.QueryLayout(false))
                {
                    //XMessageBox.Show(Service.ErrFullMsg);
                }
                if (!this.grdOUT0106.QueryLayout(false))
                {
                    //XMessageBox.Show(Service.ErrFullMsg);
                }
            }
            _GroupedLoad = false;
        }

        private void AutoCheck()
        {
            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                //조회된 로우를 돌면서
                //if (this.dtpQueryDate.GetDataValue().Equals(this.grdDetail.GetItemValue(i, "reser_date").ToString()))
                //{//조회 날짜와 예약날짜가 같으면
                this.grdDetail.SetItemValue(i, "acting_flag", "Y"); //실시에 자동체크

                // https://sofiamedix.atlassian.net/browse/MED-14735
                //this.grdDetail.SetItemValue(i, "jujongja", this.fbxActor.GetDataValue()); //실시자 이름을 넣는다.
                //this.grdDetail.SetItemValue(i, "jujongja_name", this.dbxActor_name.GetDataValue().ToString());
                this.grdDetail.SetItemValue(i, "jujongja", this.dbxUserId.GetDataValue()); //실시자 이름을 넣는다.
                this.grdDetail.SetItemValue(i, "jujongja_name", this.dbxUserName.GetDataValue().ToString());

                this.grdDetail.SetItemValue(i, "acting_date", this.dtpActingDate.GetDataValue());
                // }
            }

            // GRIDのFONT色を元に戻す。
            //this.grdDetail.ResetUpdate();
        }

        //20120314 woo
        private void InputActingDate()
        {
            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                this.grdDetail.SetItemValue(i, "acting_date", this.dtpActingDate.GetDataValue().ToString());
            }
        }

        private void grdDetail_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdSang.QueryLayout(true);

            if (this.grdDetail.RowCount < 1) return;

            // 未投与の場合
            //if (this.rdoWait.Checked)
            //{
            //    this.AutoInputInfo(this.fbxActor.GetDataValue(), this.dbxActor_name.GetDataValue());
            //}

            // 投与済の場合
            if (this.rbtDone.Checked)
            {
                this.fbxActor.SetDataValue(this.grdDetail.GetItemString(e.CurrentRow, "jujongja"));
                this.dbxActor_name.SetDataValue(this.grdDetail.GetItemString(e.CurrentRow, "jujongja_name"));

                // MED-14588
                this.dbxUserId.SetDataValue(this.grdDetail.GetItemString(e.CurrentRow, "jujongja"));
                this.dbxUserName.SetDataValue(this.grdDetail.GetItemString(e.CurrentRow, "jujongja_name"));
            }
        }

        #region grdDetailPreSaveLayout

        private void grdDetailPreSaveLayout()
        {
            //hsyhsy
            string fkinj1001 = String.Empty;
            string groupSer = String.Empty;
            string mixGroup = String.Empty;
            string hopeDate = String.Empty;
            string orderDate = String.Empty;
            string orderGubun = String.Empty;
            string doctor = string.Empty;
            string gwa = string.Empty;

            bool isExist = false;
            DataRow dtRow = null;


            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                if (this.grdDetail.GetRowState(i) == DataRowState.Modified)
                {

                    //액팅된 건수를 데이타 테이블에 담아 dsvSave_ServiceEnd에서 건수 만큼 라벨출력한다.
                    if (grdDetail.GetItemValue(i, "acting_flag").ToString().Trim() == "Y")
                    {
                        doctor = this.grdDetail.GetItemString(i, "doctor").Trim();

                        //주석 20120302 woo
                        //grdDetail.SetItemValue(i, "acting_date", dtpActingDate.GetDataValue());
                        //grdDetail.SetItemValue(i, "jujongja", txtConfirmUser.GetDataValue());

                        fkinj1001 = this.grdDetail.GetItemString(i, "fkinj1001").Trim();
                        groupSer = this.grdDetail.GetItemString(i, "group_ser").Trim();
                        mixGroup = this.grdDetail.GetItemString(i, "mix_group").Trim();
                        hopeDate = this.grdDetail.GetItemString(i, "hope_date").Trim();
                        orderDate = this.grdDetail.GetItemString(i, "order_date").Trim();
                        orderGubun = this.grdDetail.GetItemString(i, "order_gubun").Trim();
                        gwa = this.grdDetail.GetItemString(i, "gwa").Trim();


                        isExist = false;
                        // 그룹mix가 ""이면 단일 그룹으로 본다
                        if (mixGroup != "")
                        {
                            if (itemTable.Rows.Count > 0)
                            {
                                // 중복rp,mix구분은 한건만 저장한다.
                                foreach (DataRow row in this.itemTable.Rows)
                                {
                                    if (row["mix_group"].ToString() == "")
                                        continue;

                                    if ((row["group_ser"].ToString() == groupSer) &&
                                        (row["mix_group"].ToString() == mixGroup) &&
                                        (row["hope_date"].ToString() == hopeDate) &&
                                        (row["order_date"].ToString() == orderDate) &&
                                        (row["order_gubun"].ToString().Trim().PadRight(2).Substring(1, 1) ==
                                         orderGubun.Trim().PadRight(2).Substring(1, 1)))
                                    {
                                        isExist = true;
                                        break;
                                    }
                                }
                            }
                        }

                        //데이타 설정
                        if (!isExist)
                        {
                            dtRow = itemTable.NewRow();
                            dtRow["fkinj1001"] = fkinj1001;
                            dtRow["group_ser"] = groupSer;
                            dtRow["mix_group"] = mixGroup;
                            dtRow["hope_date"] = hopeDate;
                            dtRow["order_date"] = orderDate;
                            dtRow["order_gubun"] = orderGubun;
                            dtRow["gwa"] = gwa;
                            dtRow["doctor"] = doctor;
                            itemTable.Rows.Add(dtRow);
                            itemTable.AcceptChanges();
                        }
                    }
                    else // 取消の場合実施記録を消す。
                    {
                        this.grdDetail.SetItemValue(i, "silsi_remark", "");
                    }
                }
            }
        }

        #endregion

        #region grdDetailSaveEnd

        private void grdDetailSaveEnd()
        {
            if (this.rbtWait.Checked)
            {
                string mGroupSer = String.Empty;
                string mMixGroup = String.Empty;
                foreach (DataRow row in this.itemTable.Rows)
                {
                    _LayLableNewBc.Clear();
                    _LayLableNewBc.Add("f_hosp_code", this.mHospCode);
                    _LayLableNewBc.Add("f_bunho", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "bunho"));
                    _LayLableNewBc.Add("f_jubsu_date", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "jubsu_date"));
                    _LayLableNewBc.Add("f_gwa", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "gwa"));
                    _LayLableNewBc.Add("f_doctor", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "doctor"));
                    _LayLableNewBc.Add("f_group_ser", row["group_ser"].ToString());
                    _LayLableNewBc.Add("f_mix_group", row["mix_group"].ToString());
                    _LayLableNewBc.Add("f_fkinj1001", row["fkinj1001"].ToString());
                    _LayLableNewBc.Add("f_hosp_code", this.mHospCode);

                    //layLableNew.SetBindVarValue("f_hosp_code", this.mHospCode);
                    //layLableNew.SetBindVarValue("f_bunho", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "bunho"));
                    //layLableNew.SetBindVarValue("f_jubsu_date", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "jubsu_date"));
                    //layLableNew.SetBindVarValue("f_gwa", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "gwa"));
                    //layLableNew.SetBindVarValue("f_doctor",grdMaster.GetItemString(grdMaster.CurrentRowNumber, "doctor"));
                    //layLableNew.SetBindVarValue("f_group_ser", row["group_ser"].ToString());
                    //layLableNew.SetBindVarValue("f_mix_group", row["mix_group"].ToString());
                    //layLableNew.SetBindVarValue("f_fkinj1001", row["fkinj1001"].ToString());
                    //layLableNew.SetBindVarValue("f_hosp_code", this.mHospCode);

                    // ラベル出力ボタンがチェックされている場合、自動出力する。
                    if (this.labelPrnYN.Equals("Y")) this.prtLabel();
                }

                // 注射実施箋出力ボタンがチェックされている場合、自動出力する。
                if (this.injScripPrnYN.Equals("Y")) this.prtInjActScrip();
            }
            clearDetailScreen(); //디테일 화면 클리어
            this.grdMaster.QueryLayout(false); //마스터 조회
        }

        #endregion

        #endregion

        #region 조회일자

        private void dtpQueryDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region Patient Box

        private void patInfo_PatientSelected(object sender, System.EventArgs e)
        {
            //
            if (patInfo.Tag == null) patInfo.Tag = "";
            //if(patInfo.Tag.ToString() == patInfo.BunHo ) return;
            /* 같은환자를 두번째 직접 입력으로 검색할 때
             * 태그가 남아있어서 리턴이되어버린다. 어쩔 것인가?? 2011.12.10 woo*/

            //this.fbxActor.ResetText();
            //this.dbxActor_name.ResetText();

            patInfo.Tag = patInfo.BunHo;

            lbSuname.Text = patInfo.SuName;
            lbSex.Text = patInfo.Sex;
            lbAge.Text = patInfo.YearAge.ToString();
            lbAddress.Text = patInfo.Address1 + patInfo.Address2;
            if (isFirstLoad)
            {
                GetDataScreenOpenSecond();
                //isFirstLoad = false;
            }
            this.grdOCS1003.QueryLayout(false); //해당환자의 예약날짜별 과별 의사별 묶음 woo
            //this.grdSilsiRemark.QueryLayout(false);

            if (!_GroupedLoad)
            {
                _GroupedLoad = true;
                this.grdNUR1016.QueryLayout(false); //해당 환자 알레르기 내용 woo
                this.grdNUR1017.QueryLayout(false); //해당 환자 감염증 내용 
                this.grdOUT0106.QueryLayout(false); //해당 환자의 특기사항 내용 woo 
            }
            _GroupedLoad = false;

            //해당환자의 미래예약이 있나 확인
            this.layReserDate.SetBindVarValue("f_bunho", patInfo.BunHo);
            this.layReserDate.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
            this.layReserDate.SetBindVarValue("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");
            this.layReserDate.QueryLayout(false);

            this.fbxActor.Focus();
        }

        //환자번호를 잘못입력했거나 널값인 경우 추가 2011.12.12 woo
        private void patInfo_PatientSelectionFailed(object sender, EventArgs e)
        {
            clearDetailScreen();
        }

        #endregion

        #region 화면 클리어 2011.12.12 woo

        private void clearDetailScreen()
        {
            this.patInfo.Reset();
            this.grdDetail.Reset();
            this.grdNUR1016.Reset();
            this.grdNUR1017.Reset();
            this.grdOUT0106.Reset();
            this.grdOCS1003.Reset();
            this.grdSang.Reset();
            this.pbxReserDate.Visible = false;
            this.pbxCPL.Visible = false;
            this.btnCPL.Visible = false;
            this.dtpActingDate.SetDataValue(currentDate); //오늘 날짜로 변경

            //this.fbxActor.ResetData();
            //this.fbxActor.Focus();
        }

        #endregion

        #region grdMaster 관련

        #region grdMaster_GridCellPainting

        private void grdMaster_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            //항암
            if (e.DataRow["chkb"].ToString() == "Y")
            {
                e.ForeColor = XColor.ErrMsgForeColor.Color;
                grdMaster[e.RowNumber + 2, 0].ToolTipText = "抗癌";
                grdMaster[e.RowNumber + 2, 0].Image = this.ImageList.Images[6];
            }

            //당일오더면
            if (e.DataRow["reser_gubun"].ToString() == "1")
            {
                if (e.ColName == "reser_gubun")
                    e.ForeColor = Color.Blue;
            }

            //예약오더면
            if (e.DataRow["reser_gubun"].ToString() == "2")
            {
                e.BackColor = Color.LightGreen;
            }
            //trial patient
            if (e.DataRow["trial_patient_yn"].ToString() == "Y")
            {
                grdMaster[e.RowNumber + 1, 1].ToolTipText = Resources.SMS_TRIAL;
            }
            //Don't show tooltip values "N" in Xcell
            if (e.DataRow["trial_patient_yn"].ToString() == "N")
            {
                grdMaster[e.RowNumber + 1, 1].ToolTipText = " ";
            }

        }

        #endregion

        #region grdMaster_QueryStarting

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMaster.ParamList = new List<string>(new String[] { "f_reser_date", "f_acting_flag", "f_gwa" });

            this.grdMaster.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdMaster.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
            this.grdMaster.SetBindVarValue("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");
            this.grdMaster.SetBindVarValue("f_gwa", xBuseoCombo1.GetDataValue());
        }

        #endregion

        #region grdMaster_QueryEnd

        private int mReceiveBunhoRowNum = -1;

        
        private void grdMaster_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                //InjsINJ1001U01ChkbStateRequest
                string cmdText = @"SELECT DISTINCT 
                                      NVL(C.CHKB,'N')
                                  FROM INV0110 C
                                      ,INJ1001 B
                                      ,INJ1002 A
                                 WHERE A.HOSP_CODE             = :f_hosp_code
                                   AND B.HOSP_CODE             = A.HOSP_CODE
                                   AND B.HOSP_CODE             = A.HOSP_CODE
                                   AND A.RESER_DATE            = TO_DATE(:f_reser_date,'YYYY/MM/DD')
                                   AND NVL(A.ACTING_FLAG, 'N') = :f_acting_flag
                                   AND B.BUNHO                 = :f_bunho
                                   AND B.PKINJ1001             = A.FKINJ1001
                                   AND B.DOCTOR                = :f_doctor
                                   AND C.JAERYO_CODE           = A.HANGMOG_CODE
                                   AND NVL(C.CHKB,'N')         = 'Y' ";

                object chkb = null;
                BindVarCollection bc = new BindVarCollection();
                bc.Add("f_hosp_code", this.mHospCode);
                bc.Add("f_reser_date", this.dtpQueryDate.GetDataValue());
                bc.Add("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");

                _InjsINJ1001U01ChkbStateArgs.ActingFlag = bc["f_acting_flag"].VarValue;
                _InjsINJ1001U01ChkbStateArgs.ReserDate = bc["f_reser_date"].VarValue;

                mReceiveBunhoRowNum = -1;

                for (int i = 0; i < this.grdMaster.RowCount; i++)
                {
                    bc.Add("f_bunho", this.grdMaster.GetItemString(i, "bunho"));
                    bc.Add("f_doctor", this.grdMaster.GetItemString(i, "doctor"));

                    _InjsINJ1001U01ChkbStateArgs.Bunho = bc["f_bunho"].VarValue;
                    _InjsINJ1001U01ChkbStateArgs.Doctor = bc["f_doctor"].VarValue;

                    //chkb = Service.ExecuteScalar(cmdText, bc);
                    _InjsINJ1001U01ChkbStateResult =
                        CloudService.Instance.Submit<InjsINJ1001U01ChkbStateResult, InjsINJ1001U01ChkbStateArgs>(_InjsINJ1001U01ChkbStateArgs);
                    if (_InjsINJ1001U01ChkbStateResult != null)
                    {
                        chkb = _InjsINJ1001U01ChkbStateResult.Result;
                    }

                    if (!TypeCheck.IsNull(chkb))
                    {
                        this.grdMaster.SetItemValue(i, "chkb", chkb.ToString());
                    }

                    if (this.mOnReceiveBunho)
                    {
                        if (this.mReceiveBunhoRowNum == -1)
                        {
                            if (this.mReceivedBunho == this.grdMaster.GetItemString(i, "bunho"))
                            {
                                mReceiveBunhoRowNum = i;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region grdMaster_MouseDown (2011.12.09 woo)

        /* 기존에는 rowFocusChanged 였는데 그렇게하면 처리도중에 자동조회로 환자 목록이 조회되고 
         * rowFocusChanged 를 타 상세내용이 조회될 수 있기때문에 클릭시로 조회타게 변경*/

        private void grdMaster_MouseDown(object sender, MouseEventArgs e)
        {

            //if (e.Button == MouseButtons.Left)
            //{
            //    int row = this.grdMaster.GetHitRowNumber(e.Y);  //좌표값을 그리드 로우값으로 변환

            //    if (row < 0) //클릭한 곳이 그리드의 공백이라면 리턴리턴~
            //        return;

            //    this.pbxReserDate.Visible = false;
            //    this.pbxCPL.Visible = false;
            //    this.btnCPL.Visible = false;
            //    this.patInfo.Reset();
            //    this.patInfo.Tag = null;

            //    //this.fbxActor.ResetText();
            //    //this.dbxActor_name.ResetText();
            //    // 왼쪽의 그리드의 환자를 클릭했을 경우에는 버튼 조작 가능하게 한다.
            //    //this.btnTodayOrder.Enabled = true;
            //    //this.btnPreOrder.Enabled = true;
            //    //this.btnPostOrder.Enabled = true;
            //    //this.pbxReserDate.Enabled = true;
            //    this.dtpActingDate.SetDataValue(EnvironInfo.GetSysDate());  //오늘 날짜로 변경

            //    readOCS1003(row);
            //    this.fbxActor.Focus();
            //}

        }

        #endregion


        #endregion

        #region SetPrint

        private string SetPrint(XDataWindow dw_print, bool lable_yn)
        {
            string print_name = "";

            if (lable_yn)
            {
                //foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                //{
                //    if (s == "OneNote 2007")
                //    {
                //        print_name = "OneNote 2007";
                //        break;
                //    }
                //    else
                //    {
                //        if (s.IndexOf("OneNote") >= 0)
                //            print_name = s;
                //    }
                //}

                //if (print_name.IndexOf("OneNote") < 0)
                //{
                //    MessageBox.Show("ラベルプリンタの設定がされていません。");
                //    //dw_print.PrintDialog(true);
                //}

                foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    //if (s == "EPSON TM-C100")
                    //{
                    //    print_name = "EPSON TM-C100";
                    //    break;
                    //}
                    //else
                    //{
                    //    if (s.IndexOf("TM") >= 0)
                    //        print_name = s;
                    //}
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

                if (print_name.IndexOf("TM") < 0)
                {
                    //XMessageBox.Show("ラベルプリンタの設定がされていません。", "確認", MessageBoxIcon.Information);
                    dw_print.PrintDialog(true);
                }


                //}

                //if ( print_name.IndexOf("SATO") < 0 )
                //{
                //    MessageBox.Show("ラベルプリンタの設定がされていません。");
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

        #region [btnReInjActScrip_Click 注射実施箋ボタンクリック]

        private void btnReInjActScrip_Click(object sender, EventArgs e)
        {
            if (this.grdDetail.RowCount > 0) this.prtInjActScrip();
            else return;
        }

        #endregion

        #region [prtInjActScrip 注射実施箋]

        private void prtInjActScrip()
        {
            // Updated by Cloud
            try
            {
                layTemp.ParamList = new List<string>(new string[]
                                                     {
                                                         "f_bunho",
                                                         "f_jubsu_date",
                                                         "f_doctor",
                                                         "f_hosp_code",
                                                         "f_reser_date",
                                                     });
                layTemp.SetBindVarValue("f_bunho", this.patInfo.BunHo);
                layTemp.SetBindVarValue("f_jubsu_date", this.dtpActingDate.GetDataValue());
                layTemp.SetBindVarValue("f_doctor",
                    this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "doctor"));
                layTemp.SetBindVarValue("f_hosp_code", this.mHospCode);
                layTemp.SetBindVarValue("f_reser_date",
                    this.grdDetail.GetItemValue(this.grdDetail.CurrentRowNumber, "reser_date").ToString());

                layTemp.ExecuteQuery = GetLayTemp;

                layTemp.QueryLayout(true);
            }
            catch
            {

            }

        }

        #endregion

        #region btnLabel_Click

        private void btnReLabel_Click(object sender, System.EventArgs e)
        {
            this.prtLabel();
        }

        private void prtLabel()
        {
            //layLableNew.SetBindVarValue("f_bunho", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho"));
            //layLableNew.SetBindVarValue("f_jubsu_date", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "jubsu_date"));
            //layLableNew.SetBindVarValue("f_gwa", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "gwa"));
            //layLableNew.SetBindVarValue("f_doctor", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "doctor"));
            //layLableNew.SetBindVarValue("f_group_ser", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "group_ser"));
            //layLableNew.SetBindVarValue("f_mix_group", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "mix_group"));
            //layLableNew.SetBindVarValue("f_fkinj1001", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "fkinj1001"));
            //layLableNew.SetBindVarValue("f_hosp_code", this.mHospCode);

            _LayLableNewBc.Clear();
            _LayLableNewBc.Add("f_bunho", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho"));
            _LayLableNewBc.Add("f_jubsu_date", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "jubsu_date"));
            _LayLableNewBc.Add("f_gwa", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "gwa"));
            _LayLableNewBc.Add("f_doctor", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "doctor"));
            _LayLableNewBc.Add("f_group_ser", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "group_ser"));
            _LayLableNewBc.Add("f_mix_group", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "mix_group"));
            _LayLableNewBc.Add("f_fkinj1001", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "fkinj1001"));
            _LayLableNewBc.Add("f_hosp_code", this.mHospCode);


            layLableNew.QueryLayout(true);
        }

        #endregion

        #region 예약변경 버튼 클릭

        private void btnReser_Click(object sender, System.EventArgs e)
        {
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("INJS", "INJ1002U01");

            if (aScreen == null)
            {
                string bunho = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho");
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);
                openParams.Add("queryDate", this.dtpQueryDate.GetDataValue());
                openParams.Add("gwa", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "gwa"));
                openParams.Add("doctor", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "doctor"));
                this.timer1.Stop();
                XScreen.OpenScreenWithParam(this, "INJS", "INJ1002U01", ScreenOpenStyle.ResponseFixed,
                    ScreenAlignment.ScreenMiddleCenter, openParams);

                if (this.useTimeChkYN.Equals("Y")) this.timer1.Start();
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }

            this.grdMaster.QueryLayout(true);

            this.patInfo.SetPatientID("");
            //this.grdOCS1003.QueryLayout(false); //예약변경 창 닫고 해당환자에 해당하는 오더목록 재조회
            //this.layReserDate.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            //this.layReserDate.SetBindVarValue("f_acting_flag", this.rdoWait.Checked ? "N" : "Y");
            //this.layReserDate.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
            //this.layReserDate.QueryLayout(false);
        }

        #endregion

        #region btnPreOrder

        private void btnPreOrder_Click(object sender, System.EventArgs e)
        {
            string bunho, reser_date; //, order_date;

            if (mPreOrderYn == "Y")
            {
                mPreOrderYn = "N";
                btnPreOrder.ImageIndex = 2;
            }
            else
            {
                mPreOrderYn = "Y";
                btnPreOrder.ImageIndex = 3;
            }

            bunho = patInfo.BunHo;
            reser_date = this.dtpQueryDate.GetDataValue();

            this.grdOCS1003.QueryLayout(false); //2011.12.14 woo

        }

        #endregion

        #region btnPostOrder

        private void btnPostOrder_Click(object sender, System.EventArgs e)
        {
            string bunho, reser_date; //, order_date;
            int row;
            if (mPostOrderYn == "Y")
            {
                mPostOrderYn = "N";
                btnPostOrder.ImageIndex = 2;
            }
            else
            {
                mPostOrderYn = "Y";
                btnPostOrder.ImageIndex = 3;
            }
            row = grdMaster.CurrentRowNumber;
            bunho = patInfo.BunHo;
            /* 직접 번호를 입력해서 환자의 오더 검색 시 옆의 그리드의 예약날짜를 받아오기때문에 
             * 그리드가 없으면 널값이 들어가 조회날짜를 받아오게 일단 변경. 2011.12.10 woo*/
            //reser_date = this.dtpQueryDate.GetDataValue();
            reser_date = grdMaster.GetItemString(row, "reser_date");
            //order_date  = grdMaster.GetItemString(row, "order_date");
            //grdDetailQuery(bunho, reser_date, order_date, mGwa, mDoctor);
            this.grdOCS1003.QueryLayout(false); //2011.12.14 woo
            //grdDetailQuery(bunho, reser_date, mGwa, mDoctor);
            //grdOCS1003.ExecuteQuery = QueryGrdOCS1003;
        }

        #endregion

        #region btnTodayOrder_Click

        private void btnTodayOrder_Click(object sender, System.EventArgs e)
        {
            string bunho, reser_date; //, order_date;

            mPostOrderYn = "N";
            btnPostOrder.ImageIndex = 2;

            mPreOrderYn = "N";
            btnPreOrder.ImageIndex = 2;

            bunho = patInfo.BunHo;
            reser_date = this.dtpQueryDate.GetDataValue();

            this.grdOCS1003.QueryLayout(false); //2011.12.14 woo

        }

        #endregion

        #region layLableNew_QueryEnd
        /// <summary>
        /// TODO: Print datawindow after saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void layLableNew_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                if (layLableNew.RowCount > 0)
                {
                    int cnt = layLableNew.GetItemInt(0, "cnt");

                    #region 주사라벨

                    //tungtx added 2015/07/16
                    //this.pnlBottom.Controls.Remove(this.dw_jusa_lable);
                    //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INJ1001U01));
                    ////this.dw_jusa_lable = new IHIS.Framework.XDataWindow();
                    //resources.ApplyResources(this.dw_jusa_lable, "dw_jusa_lable");
                    //this.dw_jusa_lable.DataWindowObject = "d_inj_jusa_lable";
                    //this.dw_jusa_lable.LibraryList = "\\INJS\\injs.inj1001u01.pbd";
                    //this.dw_jusa_lable.Name = "dw_jusa_lable";
                    //this.pnlBottom.Controls.Add(this.dw_jusa_lable);

                    //dw_jusa_lable.SetRedrawOff();
                    //dw_jusa_lable.Reset();
                    //dw_jusa_lable.FillData(layLableNew.LayoutTable);
                    //dw_jusa_lable.SetRedrawOn();
                    //dw_jusa_lable.Visible = false;
                    //dw_jusa_lable.Refresh();
                    

                    try
                    {
                        //string origin_print = SetPrint(dw1, false);
                        //string print_name = SetPrint(dw1, true);

                        //바코드프린터명 가져오기
         //               if (dw_jusa_lable.RowCount <= 0)
                            this.layPrintName.QueryLayout();
                        string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

                        // lable print set
                        try
                        {
                            //if (print_name != "")
                            //    IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name);

                            //for (int i = 0; i < cnt; i++)
                            //{
                            //    dw_jusa_lable.Print();
                            //}
                            //// 기본프린터 set
                            ////if (origin_print != "")
                            //// 기본프린터 set　수정 2012.01.11 woo
                            //IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
                            //if (origin_print != "")
                            //{
                            //    if (origin_print != this.dw_jusa_lable.PrintProperties.PrinterName)
                            //        IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
                            //}


 //                           dw_jusa_lable.PrintProperties.PrinterName = printSetName;

                            //for (int i = 0; i < cnt; i++)
                            //{
                            //    dw_jusa_lable.Print();
                            //}

                        }
                        catch
                        {
                        }
                    }
                    catch
                    {
                    }

                    #endregion
                }
            }
        }

        #endregion

        #region layTemp_QueryEnd

        private void layTemp_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                //string tRemark = "";
                //layOrderPrint.Reset();

                //int rowNum = -1;
                //for (int i = 0; i < layTemp.RowCount; i++)
                //{
                //    rowNum = layOrderPrint.InsertRow(-1);

                //    for (int k = 0; k < layTemp.LayoutTable.Columns.Count; k++)
                //    {
                //        if (layTemp.GetItemString(i, "order_remark_temp") != "")
                //        {
                //            if (tRemark == "")
                //                tRemark = "@ " + layTemp.GetItemString(i, "order_remark_temp");
                //            else
                //                tRemark += tRemark + ", " + layTemp.GetItemString(i, "order_remark_temp");
                //        }

                //        if (layTemp.LayoutTable.Columns[k].ColumnName == "order_remark_temp")
                //            continue;

                //        layOrderPrint.SetItemValue(rowNum, layTemp.LayoutTable.Columns[k].ColumnName, layTemp.GetItemString(i, layTemp.LayoutTable.Columns[k].ColumnName));
                //    }

                //    if (tRemark != "")
                //    {
                //        rowNum = layOrderPrint.InsertRow(-1);
                //        for (int k = 0; k < layTemp.LayoutTable.Columns.Count; k++)
                //        {
                //            if (layTemp.LayoutTable.Columns[k].ColumnName == "order_remark_temp")
                //                continue;

                //            layOrderPrint.SetItemValue(rowNum, layTemp.LayoutTable.Columns[k].ColumnName, layTemp.GetItemString(i, layTemp.LayoutTable.Columns[k].ColumnName));
                //        }

                //        layOrderPrint.SetItemValue(rowNum, "order_remark", tRemark);
                //        layOrderPrint.SetItemValue(rowNum, "data_gubun", "B");

                //    }
                //}

                //if (layOrderPrint.RowCount > 0)
                //{
                //    #region 주사 처방전
                //    dw_jusa.Reset();
                //    dw_jusa.FillData(layOrderPrint.LayoutTable);
                //    dw_jusa.Refresh();

                //    dw_jusa.Print();
                //    #endregion
                //}

   //             dw_jusa.Reset();
                //dw_jusa.FillData(layOrderPrint.LayoutTable);
   //             dw_jusa.FillData(layTemp.LayoutTable);
  //              dw_jusa.Refresh();

   //             dw_jusa.Print();
            }
        }

        #endregion

        //#region 注射実施箋出力
        //private void xButton1_Click(object sender, System.EventArgs e)
        //{
        //    layTemp.SetBindVarValue("f_bunho", this.patInfo.BunHo);
        //    layTemp.SetBindVarValue("f_jubsu_date", this.dtpQueryDate.GetDataValue());
        //    layTemp.SetBindVarValue("f_doctor", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "doctor"));
        //    layTemp.SetBindVarValue("f_hosp_code", this.mHospCode);
        //    layTemp.SetBindVarValue("f_reser_date", this.grdDetail.GetItemValue(this.grdDetail.CurrentRowNumber, "reser_date").ToString());

        //    layTemp.QueryLayout(true);
        //}
        //#endregion

        #region 진료과 콤보 선택

        private void xBuseoCombo1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            xButtonList1_ButtonClick(null, new ButtonClickEventArgs(FunctionType.Query, false, false));
        }

        #endregion

        #region QueryStarting End Evnet


        #region 미래오더 조회 부분

        private void layReserDate_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layReserDate.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void layReserDate_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layReserDate.RowCount > 0)
                this.pbxReserDate.Visible = true;
            else
                this.pbxReserDate.Visible = false;
        }

        #endregion

        #region 검체오더조회 부분

        private void layCPLOrderYN_QueryStarting(object sender, CancelEventArgs e)
        {
            layCPLOrderYN.ParamList = new List<string>(new string[] { "f_hosp_code", "f_bunho", "f_date" });

            this.layCPLOrderYN.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layCPLOrderYN.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            this.layCPLOrderYN.SetBindVarValue("f_date", this.dtpQueryDate.GetDataValue());
        }

        private void layCPLOrderYN_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layCPLOrderYN.GetItemValue("cpl_order_yn").ToString() == "Y")
            {
                this.pbxCPL.Visible = true;
                this.btnCPL.Visible = true;

            }
            else
            {
                this.pbxCPL.Visible = false;
                this.btnCPL.Visible = false;
            }
        }

        #endregion

        #region 환자알레르기 특기사항 상벼 QueryStarting (2011.12.08 woo)

        private void grdNUR1016_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR1016.ParamList = new List<string>(new String[] { "f_bunho", "f_query_date", "f_hosp_code" });

            this.grdNUR1016.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdNUR1016.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            this.grdNUR1016.SetBindVarValue("f_query_date", this.dtpQueryDate.GetDataValue());
        }

        private void grdOUT0106_QueryStarting(object sender, CancelEventArgs e)
        {

            this.grdOUT0106.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdOUT0106.SetBindVarValue("f_bunho", this.patInfo.BunHo);
        }

        private void grdNUR1017_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR1017.ParamList = new List<string>(new String[] { "f_bunho", "f_query_date", "f_hosp_code" });

            this.grdNUR1017.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdNUR1017.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            this.grdNUR1017.SetBindVarValue("f_query_date", this.dtpQueryDate.GetDataValue());
        }

        private void grdSang_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSang.ParamList = new List<string>(new String[] { "f_bunho", "f_gwa", "f_reser_date", "f_hosp_code" });

            this.grdSang.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdSang.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            this.grdSang.SetBindVarValue("f_gwa", this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa"));
            this.grdSang.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
        }

        #endregion


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
                                aGrd.GetItemValue(i, "order_date").ToString().Trim() ==
                                aGrd.GetItemValue(j, "order_date").ToString().Trim() &&
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

        #region 화면관련

        private void INJ1001U01_Closing(object sender, CancelEventArgs e)
        {
            if (!mIsSaveSuccess)
            {
                e.Cancel = true;
            }
            mIsSaveSuccess = true;
        }

        #endregion

        #region 채혈있음 버튼 처리

        private void btnCPL_Click(object sender, EventArgs e)
        {
            IXScreen aScreen = XScreen.FindScreen("CPLS", "CPL2010U00");

            if (aScreen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", this.patInfo.BunHo);
                openParams.Add("order_date", this.dtpQueryDate.GetDataValue());
                // openParams.Add("jubsuja_id", this.txtConfirmUser.GetDataValue());
                XScreen.OpenScreenWithParam(this, "CPLS", "CPL2010U00", ScreenOpenStyle.PopUpFixed,
                    ScreenAlignment.ParentTopLeft, openParams);
            }
            else
            {
                aScreen.Activate();
                XPatientInfo paInfo = new XPatientInfo(this.patInfo.BunHo, this.dtpQueryDate.GetDataValue(), "", "", "",
                    PatientPKGubun.Out, this.ScreenName);
                XScreen.SendPatientInfo(paInfo);

            }

        }

        #endregion

        #region [一括受付ボタン関連]

        private void btnChkAllJubsu_Click(object sender, EventArgs e)
        {
            if (this.chkAllJubsuYN.Equals("Y"))
            {
                this.btnChkAllJubsu.ImageIndex = 2;
                this.chkAllJubsuYN = "N";

                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    //조회된 로우를 돌면서~
                    if (this.grdDetail.GetItemString(i, "acting_flag").Equals("N"))
                        continue; //원래 미실시로되어있는애들은 건너뛰고~
                    this.grdDetail.SetItemValue(i, "acting_flag", "N"); //실시 체크해제
                }
            }
            else
            {
                this.btnChkAllJubsu.ImageIndex = 3;
                this.chkAllJubsuYN = "Y";

                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    //조회된 로우를 돌면서
                    if (this.grdDetail.GetItemString(i, "acting_flag").Equals("Y"))
                        continue; //실행되어있던 애들은 건너뛰고~
                    this.grdDetail.SetItemValue(i, "acting_flag", "Y"); //실시에 체크
                }
            }
        }

        private void reset_BtnChkAllJubsu()
        {
            this.btnChkAllJubsu.ImageIndex = 3;
            this.chkAllJubsuYN = "Y";
        }

        #endregion

        #region 타이머 관련 (2011.12.08 woo)

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = (this.QueryTime / 1000).ToString();
            this.QueryTime = this.QueryTime - 1000;

            if (QueryTime == 0)
            {
                this.grdMaster.QueryLayout(false);

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
                this.btnUseTimeChk.ImageIndex = 3;
                this.useTimeChkYN = "Y";

                this.timer1.Start();
                this.cboTime.Enabled = true;
                this.tbxTimer.SetDataValue("Y");
                this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
                this.txtTimeInterval.AcceptData();
            }
            else
            {
                this.btnUseTimeChk.ImageIndex = 2;
                this.useTimeChkYN = "N";

                this.cboTime.Enabled = false;
                this.timer1.Stop();
            }
        }

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

        #region grdOCS1003 (해당환자 오더 목록 관련) 2011.12.15 woo

        private void grdOCS1003_QueryStarting(object sender, CancelEventArgs e) //2011.12.14 woo
        {
            this.grdOCS1003.ParamList = new List<string>(new String[] { "f_post_order_yn", "f_pre_order_yn", "f_reser_date", "f_bunho", "f_acting_flag", "f_order_date", "f_reser_date" });

            this.grdOCS1003.SetBindVarValue("f_post_order_yn", mPostOrderYn);
            this.grdOCS1003.SetBindVarValue("f_pre_order_yn", mPreOrderYn);
            this.grdOCS1003.SetBindVarValue("f_reser_date", this.dtpQueryDate.GetDataValue());
            this.grdOCS1003.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            this.grdOCS1003.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdOCS1003.SetBindVarValue("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");

            this.grdOCS1003.SetBindVarValue("f_order_date",
                this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "order_date"));
            //this.grdOCS1003.SetBindVarValue("f_reser_date",
            //    this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "reser_date"));
        }

        private void grdOCS1003_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //tuning performance by gathering request
            

            this.grdDetail.QueryLayout(false);
        }

        private void grdOCS1003_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            DateTime ot = DateTime.Parse(e.DataRow["reser_date"].ToString());
            DateTime queryDate = DateTime.Parse(this.dtpQueryDate.GetDataValue());
            if (ot.CompareTo(queryDate) == 0)
            {
                //e.BackColor = XColor.XListViewHeaderBackColor.Color;
                e.BackColor = Color.White;
            }
            else
            {
                e.BackColor = XColor.XLabelGradientEndColor.Color;
            }

            if (e.RowNumber < 1) return;
        }


        #endregion

        #region rdoCheckedChanged(투여 미투여 버튼 관련) 2011.12.15 woo

        private void rdoCheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rButton = sender as XRadioButton;

            //체크됐을 때만 로직타도록 수정
            if (!rButton.Checked)
                return;

            if (rButton.Name == this.rbtWait.Name)
            {
                this.rbtWait.ImageIndex = 3;
                this.rbtDone.ImageIndex = 2;
                this.lblTitle.Text = Resources.lblTitleText;
                this.lblTitle.ForeColor = new XColor(Color.Teal);
                //this.btnReInjActScrip.Visible = false;
                this.btnReLabel.Visible = false;

                //this.btnInjActScrip.Visible = true;
                this.btnLabel.Visible = true;

                // 実施者選択
                this.fbxActor.Enabled = true;

                // https://sofiamedix.atlassian.net/browse/MED-14735
                this.btnFindUser.Enabled = true;

                // 実施者に 現在ログインしている IDを セットする｡
                this.fbxActor.SetDataValue(UserInfo.UserID);
                this.dbxActor_name.SetDataValue(UserInfo.UserName);

                // 実施日選択カレンダー
                this.dtpActingDate.Enabled = true;

                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.BrtWait, -1, ""));
                this.btnList.InitializeButtons();
                this.btnList.Refresh();
            }
            else
            {
                this.rbtWait.ImageIndex = 2;
                this.rbtDone.ImageIndex = 3;
                this.lblTitle.Text = Resources.lblTitle;
                this.lblTitle.ForeColor = new XColor(Color.Crimson);
                //this.btnReInjActScrip.Visible = true;
                this.btnReLabel.Visible = true;

                //this.btnInjActScrip.Visible = false;
                this.btnLabel.Visible = false;

                // 実施日選択カレンダー
                this.fbxActor.Enabled = false;

                // https://sofiamedix.atlassian.net/browse/MED-14735
                this.btnFindUser.Enabled = false;

                // 実施日選択カレンダー
                this.dtpActingDate.Enabled = false;

                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.BrtDone, -1, ""));
                this.btnList.InitializeButtons();
                this.btnList.Refresh();
            }

            // 注射実施記録の初期化
            this.btnCmtClear_Click(sender, e);

            // 一括受付ボタン初期化
            this.reset_BtnChkAllJubsu();

            this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region [dtpActingDate_DataValidating 実施日付チェック]

        private void dtpActingDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (this.grdDetail.RowCount < 1) return;

            if (this.rbtWait.Checked)
            {
                string order =
                    this.grdDetail.GetItemDateTime(this.grdDetail.CurrentRowNumber, "order_date").ToString("yyyy/MM/dd");
                string acting = e.DataValue;
                DateTime order_date = DateTime.Parse(order);
                DateTime acting_date = DateTime.Parse(acting);
                //if (order_date > acting_date)
                //{
                //    XMessageBox.Show("オーダー日より先に日では実施できません。", "日付", MessageBoxIcon.Error);
                //    e.Cancel = true;
                //    this.dtpActingDate.SetDataValue(EnvironInfo.GetSysDate());
                //    return;
                //}

                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    this.grdDetail.SetItemValue(i, "acting_date", this.dtpActingDate.GetDataValue().ToString());
                }
            }
        }

        #endregion

        #region [btnPrintSetup_Click 注射ラベルプリンタ設定クリック]

        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            this.SetPrint();
        }

        #endregion

        #region 바코드 프린터 설정

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


                //                string cmdText = @" DECLARE 
                //    
                //                                        T_TRM_ID VARCHAR2(8) := ''; 
                //
                //                                    BEGIN
                //                                        UPDATE ADM3300
                //                                           SET USER_ID         = :q_user_id
                //                                             , UP_TIME         = SYSDATE
                //                                             , B_PRINT_NAME    = :f_b_print_name
                //                                         WHERE HOSP_CODE       = :f_hosp_code 
                //                                           AND IP_ADDR         = :f_ip_addr;
                //                                           
                //                                              
                //                                           IF SQL%NOTFOUND THEN       
                //                                             
                //                                             SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
                //                                               INTO T_TRM_ID
                //                                               FROM ADM3300
                //                                              WHERE HOSP_CODE = :f_hosp_code;
                //                                              
                //                                             INSERT INTO ADM3300
                //                                                  ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
                //                                                    USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
                //                                                VALUES 
                //                                                  ( T_TRM_ID, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
                //                                                    NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name);       
                //                                                    
                //                                           END IF; 
                //
                //                                    END;";

                //BindVarCollection _BtnPrintSetupBc = new BindVarCollection();
                _BtnPrintSetupBc.Clear();
                _BtnPrintSetupBc.Add("q_user_id", UserInfo.UserID);
                _BtnPrintSetupBc.Add("f_b_print_name", PrinterName);
                _BtnPrintSetupBc.Add("f_hosp_code", this.mHospCode);
                _BtnPrintSetupBc.Add("f_ip_addr", Service.ClientIP.ToString());
                _InjsINJ1001U01SettingPrintArgs.BPrintName = _BtnPrintSetupBc["f_b_print_name"].VarValue;
                _InjsINJ1001U01SettingPrintArgs.IpAddr = _BtnPrintSetupBc["f_ip_addr"].VarValue;
                _InjsINJ1001U01SettingPrintArgs.UserId = _BtnPrintSetupBc["q_user_id"].VarValue;
                _InjsINJ1001U01SettingPrintResult =
                    CloudService.Instance.Submit<InjsINJ1001U01SettingPrintResult, InjsINJ1001U01SettingPrintArgs>(
                        _InjsINJ1001U01SettingPrintArgs);

                if (_InjsINJ1001U01SettingPrintResult != null && _InjsINJ1001U01SettingPrintResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (!_InjsINJ1001U01SettingPrintResult.Result)
                    {
                        XMessageBox.Show(Resources.XMessageBox8 + Service.ErrFullMsg, Resources.Caption4,
                            MessageBoxIcon.Warning);
                    }
                }






                //if (!Service.ExecuteNonQuery(cmdText, bc))
                //{
                //    XMessageBox.Show(Resources.XMessageBox8 + Service.ErrFullMsg, Resources.Caption4,
                //        MessageBoxIcon.Warning);
                //}
            }
        }

        #endregion

        #region [btnAllergy_Click アレルギーボタンクリック]

        private void btnAllergy_Click(object sender, EventArgs e)
        {
            if (this.patInfo.BunHo == "")
                return;
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("NURI", "NUR1016U00");

            if (aScreen == null)
            {
                string bunho = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho");
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);
                this.timer1.Stop();
                XScreen.OpenScreenWithParam(this, "NURI", "NUR1016U00", ScreenOpenStyle.ResponseFixed,
                    ScreenAlignment.ScreenMiddleCenter, openParams);

                if (useTimeChkYN.Equals("Y"))
                {
                    this.timer1.Start();
                }

            }
            else
            {
                ((XScreen)aScreen).Activate();
                XPatientInfo paInfo = new XPatientInfo(this.patInfo.BunHo, "", "", "", "", PatientPKGubun.Out,
                    this.ScreenName);
                XScreen.SendPatientInfo(paInfo);
            }


            this.grdNUR1016.QueryLayout(false); //예약변경 창 닫고 해당환자에 해당하는 오더목록 재조회


        }

        #endregion

        private void layPrintName_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPrintName.ParamList = new List<string>(new String[] { "f_hosp_code", "f_ip_addr" });

            this.layPrintName.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layPrintName.SetBindVarValue("f_ip_addr", Service.ClientIP.ToString());
        }

        #region [btnGamyum_Click 感染症ボタンクリック]

        private void btnGamyum_Click(object sender, EventArgs e)
        {
            if (this.patInfo.BunHo == "")
                return;
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("NURI", "NUR1017U00");

            if (aScreen == null)
            {
                string bunho = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho");
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);
                this.timer1.Stop();
                XScreen.OpenScreenWithParam(this, "NURI", "NUR1017U00", ScreenOpenStyle.ResponseFixed,
                    ScreenAlignment.ScreenMiddleCenter, openParams);
                if (useTimeChkYN.Equals("Y"))
                {
                    this.timer1.Start();
                }

            }
            else
            {
                ((XScreen)aScreen).Activate();
                XPatientInfo paInfo = new XPatientInfo(this.patInfo.BunHo, "", "", "", "", PatientPKGubun.Out,
                    this.ScreenName);
                XScreen.SendPatientInfo(paInfo);
            }


            _GroupedLoad = false;
            this.grdNUR1017.QueryLayout(false); //예약변경 창 닫고 해당환자에 해당하는 오더목록 재조회

        }

        #endregion

        #region [btnOUt0106_Click 特記事項ボタンクリック]

        private void btnOUt0106_Click(object sender, EventArgs e)
        {
            if (this.patInfo.BunHo == "")
                return;
            IHIS.Framework.IXScreen aScreen;

            aScreen = XScreen.FindScreen("NURO", "OUT0106U00");

            if (aScreen == null)
            {
                string bunho = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "bunho");
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);
                this.timer1.Stop();
                XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", ScreenOpenStyle.ResponseFixed,
                    ScreenAlignment.ScreenMiddleCenter, openParams);

                if (useTimeChkYN.Equals("Y"))
                {
                    this.timer1.Start();
                }

            }
            else
            {
                ((XScreen)aScreen).Activate();
                XPatientInfo paInfo = new XPatientInfo(this.patInfo.BunHo, "", "", "", "", PatientPKGubun.Out,
                    this.ScreenName);
                XScreen.SendPatientInfo(paInfo);
            }

            _GroupedLoad = false;
            this.grdOUT0106.QueryLayout(false); //예약변경 창 닫고 해당환자에 해당하는 오더목록 재조회
            this._INJ1001U01Grouped2Result = null;
        }

        #endregion

        #region checkDate

        private bool checkDate(int row)
        {
            if (TypeCheck.IsNull(this.grdDetail.GetItemString(row, "reser_date")) ||
                TypeCheck.IsNull(this.grdDetail.GetItemString(row, "acting_date")))
                return false;

            string reser = this.grdDetail.GetItemString(row, "reser_date");
            string acting = this.grdDetail.GetItemString(row, "acting_date");
            DateTime reser_date = DateTime.Parse(reser);
            DateTime acting_date = DateTime.Parse(acting);
            reser = reser_date.ToString().Substring(0, 10);
            acting = acting_date.ToString().Substring(0, 10);
            if (reser_date > acting_date)
            {
                this.mCap = Resources.mCap;
                this.mMsg = Resources.XMessageBox9 + reser + Resources.XMessageBox10 + acting + Resources.XMessageBox11;
                if (XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                    DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            return true;
        }

        #endregion

        #region [btnInjActScrip_Click 注射実施せん出力ボタン]

        private void btnInjActScrip_Click(object sender, EventArgs e)
        {
            // 出力可否 injScripPrnYN

            if (this.injScripPrnYN.Equals("N"))
            {
                this.btnInjActScrip.ImageIndex = 3;
                this.injScripPrnYN = "Y";
            }
            else
            {
                this.btnInjActScrip.ImageIndex = 2;
                this.injScripPrnYN = "N";
            }
        }

        #endregion

        #region [btnLabel_Click 注射ラベル印刷ボタン]

        private void btnLabel_Click(object sender, EventArgs e)
        {
            // ラベル出力可否 labelPrnYN
            //MED-10170
            if (this.labelPrnYN.Equals("N"))
            {
                this.btnLabel.ImageIndex = 3;
                this.labelPrnYN = "Y";
            }
            else
            {
                this.btnLabel.ImageIndex = 2;
                this.labelPrnYN = "N";
            }
          
        }

        #endregion

        #region [fbxCmt 注射実施記録関連]

        private void fbxCmt_FindClick(object sender, CancelEventArgs e)
        {
            this.fwkCmt.FormText = Resources.fwkCmtFormText;
            this.fwkCmt.ColInfos[0].HeaderText = Resources.fwkCmtHeader1;
            this.fwkCmt.ColInfos[0].ColWidth = 100;
            this.fwkCmt.ColInfos[1].HeaderText = Resources.fwkCmtHeader2;
            this.fwkCmt.ColInfos[1].ColWidth = 300;

            this.fwkCmt.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fbxCmt_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string code = this.fbxCmt.GetDataValue();

            if (code.Trim() == "")
            {
                this.dboxCmt.Text = "";
                this.fbxCmt.Focus();
                return;
            }

            this.layCommon.Reset();

            //            this.layCommon.QuerySQL = @"SELECT CODE_NAME
            //                                          FROM INJ0102
            //                                         WHERE HOSP_CODE = :f_hosp_code 
            //                                           AND CODE_TYPE = 'INJ_COMMENT'
            //                                           AND CODE      = :f_code
            //                                         ORDER BY CODE ";



            this.layCommon.LayoutItems.Clear();
            this.layCommon.LayoutItems.Add("code_name");

            this.layCommon.ParamList = new List<string>(new String[] { "f_code" });
            this.layCommon.ExecuteQuery = QueryLayCommon;

            this.layCommon.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layCommon.SetBindVarValue("f_code", code);

            this.layCommon.QueryLayout();

            if (!TypeCheck.IsNull(this.layCommon.GetItemValue("code_name")))
            {
                this.dboxCmt.SetDataValue(this.layCommon.GetItemValue("code_name").ToString());

                this.AutoInputCmt(code, this.layCommon.GetItemValue("code_name").ToString());
            }
            else this.btnCmtClear_Click(sender, e);
        }

        private void AutoInputCmt(string code, string codeName)
        {
            this.txtSilsiRemark.Text = this.txtSilsiRemark.Text
                                       + codeName + "\r\n";

            this.txtSilsiRemark.AcceptData();
        }

        private void btnCmtClear_Click(object sender, EventArgs e)
        {
            this.fbxCmt.Clear();
            this.dboxCmt.Text = "";

            this.txtSilsiRemark.Text = "";
        }

        #endregion

        #region [fbxActor 実施者関連]

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.fbxActor.Clear();
            this.dbxActor_name.Text = "";

            this.AutoInputInfo("", "");
        }

        private void fbxActor_FindClick(object sender, CancelEventArgs e)
        {
            this.fwkActor.FormText = Resources.FormText;
            this.fwkActor.ColInfos[0].HeaderText = Resources.HeaderText1;
            this.fwkActor.ColInfos[0].ColWidth = 150;
            this.fwkActor.ColInfos[1].HeaderText = Resources.HeaderText2;
            this.fwkActor.ColInfos[1].ColWidth = 150;

            this.fwkActor.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fbxActor_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string user_id = this.fbxActor.GetDataValue();

            if (user_id.Trim() == "")
            {
                this.dbxActor_name.Text = "";
                this.fbxActor.Focus();
                return;
            }

            this.layCommon.Reset();

            //            this.layCommon.QuerySQL = @"SELECT USER_NM
            //                                          FROM ADM3200
            //                                         WHERE HOSP_CODE   = :f_hosp_code
            //                                           --AND USER_GROUP  = 'NUR'
            //                                           AND USER_ID     = :f_user_id";

            this.layCommon.LayoutItems.Clear();
            this.layCommon.LayoutItems.Add("user_name");

            layCommon.ParamList = new List<string>(new String[] { "f_user_id", "f_hosp_code" });
            this.layCommon.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layCommon.SetBindVarValue("f_user_id", user_id);

            layCommon.ExecuteQuery = fbxActor_ExecuteValidating;
            this.layCommon.QueryLayout();

            if (!TypeCheck.IsNull(this.layCommon.GetItemValue("user_name")))
            {
                this.dbxActor_name.SetDataValue(this.layCommon.GetItemValue("user_name").ToString());

                this.AutoInputInfo(user_id, this.layCommon.GetItemValue("user_name").ToString());
            }
            else this.btnClear_Click(sender, e);
        }

        private void AutoInputInfo(string actorCode, string actorName)
        {
            for (int i = 0; i < this.grdDetail.RowCount; i++)
            {
                if (this.grdDetail.GetItemValue(i, "acting_flag").ToString() != "Y")
                    continue;
                this.grdDetail.SetItemValue(i, "jujongja", actorCode);
                this.grdDetail.SetItemValue(i, "jujongja_name", actorName);
            }
        }

        private bool checkActor(int row)
        {
            bool rtnVal = true;

            string actYn = this.grdDetail.GetItemString(row, "acting_flag");

            string actorCode = null;

            if (actYn.Equals("Y"))
            {
                actorCode = this.grdDetail.GetItemString(row, "jujongja");

                if (TypeCheck.IsNull(actorCode) || actorCode.Equals(""))
                    rtnVal = false;
            }

            return rtnVal;
        }

        #endregion

        // 2015.04.27 deleted by AnhNV
        #region XSavePerformer

        //        private class XSavePerformer : ISavePerformer
        //        {
        //            private INJ1001U01 parent;

        //            private InjsINJ1001U01OrderDateListArgs _InjsINJ1001U01OrderDateListArgs = new InjsINJ1001U01OrderDateListArgs();
        //            private InjsINJ1001U01OrderDateListResult _InjsINJ1001U01OrderDateListResult;

        //            public XSavePerformer(INJ1001U01 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
        //                item.BindVarList.Add("f_upd_id", parent.fbxActor.GetDataValue().ToString());

        ////                string cmdText = @"SELECT NVL(B.ORDER_DATE, TRUNC(SYSDATE))     ORDER_DATE
        ////                                     FROM INJ1002 A, INJ1001 B
        ////                                    WHERE A.HOSP_CODE  = :f_hosp_code
        ////                                      AND B.HOSP_CODE  = A.HOSP_CODE
        ////                                      AND A.PKINJ1002  = :f_pkinj1002
        ////                                      AND A.FKINJ1001  = B.PKINJ1001";
        //                _InjsINJ1001U01OrderDateListArgs.Pkinj1002 = item.BindVarList["f_pkinj1002"].VarValue;
        //                _InjsINJ1001U01OrderDateListResult =
        //                    CloudService.Instance.Submit<InjsINJ1001U01OrderDateListResult, InjsINJ1001U01OrderDateListArgs>(
        //                        _InjsINJ1001U01OrderDateListArgs);

        //                if (_InjsINJ1001U01UpdateResult == null)
        //                    return false;
        //                DataTable dt = new DataTable();
        //                dt.Columns.Add("order_date", typeof (string));
        //                foreach (string oItem in _InjsINJ1001U01OrderDateListResult.OrderDate)
        //                {
        //                    DataRow dr = dt.NewRow();
        //                    dr["order_date"] = oItem;
        //                    dt.Rows.Add(dr);
        //                }

        //                string temp1 = "";
        //                string temp2 = "";

        //                //DataTable dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

        //                if (dt.Rows.Count > 0)
        //                {
        //                    if (!TypeCheck.IsNull(dt.Rows[0]["order_date"]))
        //                    {
        //                        for (int i = 0; i < dt.Rows.Count; i++)
        //                        {
        //                            temp1 = dt.Rows[i]["order_date"].ToString()
        //                                .Substring(0, 10)
        //                                .Replace("/", "")
        //                                .Replace("-", "");
        //                            temp2 = item.BindVarList["f_acting_date"].VarValue.Replace("/", "").Replace("-", "");
        //                            if (temp2 == "")
        //                                temp2 = "30001231";

        //                            if (Convert.ToInt32(temp1) > Convert.ToInt32(temp2))
        //                            {
        //                                XMessageBox.Show(
        //                                    Resources.XMessageBox13 + item.BindVarList["hangmog_name"].VarValue +
        //                                    Resources.XMessageBox12, Resources.Caption4, MessageBoxIcon.Warning);
        //                                return false;
        //                            }
        //                        }
        //                    }
        //                }
        //                //TODO: InjsINJ1001U01UpdateRequest
        ////                cmdText = @"UPDATE INJ1002
        ////                               SET 
        ////                                   -- JUSA_YN       = :f_jusa_yn,
        ////                                   ACTING_FLAG   = :f_acting_flag
        ////                                 , ACTING_DATE   = DECODE(:f_acting_flag, 'Y', :f_acting_date, NULL)
        ////                                 , JUBSU_DATE    = DECODE(:f_acting_flag, 'Y', :f_acting_date, NULL)
        ////                                 , ACTING_TIME   = DECODE(:f_acting_flag, 'Y', TO_CHAR(SYSDATE, 'HH24MI'), NULL)
        ////                                 , ACTING_JANGSO = 'IR'
        ////                                 , TONGGYE_CODE  = :f_tonggye_code
        ////                                 , MIX_GROUP     = :f_mix_group
        ////                                 , UPD_ID        = NVL(:f_jujongja, :f_upd_id)
        ////                                 , UPD_DATE      = SYSDATE
        ////                                 , JUJONGJA      = DECODE(:f_acting_flag, 'Y', :f_jujongja, NULL)
        ////                                 , SILSI_REMARK  = :f_silsi_remark
        ////                             WHERE HOSP_CODE     = :f_hosp_code
        ////                               AND PKINJ1002     = :f_pkinj1002";

        ////                return Service.ExecuteNonQuery(cmdText, item.BindVarList);


        //                _InjsINJ1001U01UpdateArgs.ActingDate = item.BindVarList["f_acting_date"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.ActingFlag = item.BindVarList["f_acting_flag"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.Jujongja = item.BindVarList["f_jujongja"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.MixGroup = item.BindVarList["f_mix_group"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.Pkinj1002 = item.BindVarList["f_pkinj1002"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.SilsiRemark = item.BindVarList["f_silsi_remark"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.TonggyeCode = item.BindVarList["f_tonggye_code"].VarValue;
        //                _InjsINJ1001U01UpdateArgs.UpdId = item.BindVarList["f_upd_id"].VarValue;
        //                _InjsINJ1001U01UpdateResult =
        //                    CloudService.Instance.Submit<UpdateResult, InjsINJ1001U01UpdateArgs>(
        //                        _InjsINJ1001U01UpdateArgs);

        //                if(_InjsINJ1001U01UpdateResult == null)
        //                    return false;
        //                else
        //                {
        //                    return _InjsINJ1001U01UpdateResult.Result;
        //                }
        //            }
        //        }

        #endregion

        private void grdMaster_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            int row = this.grdMaster.CurrentRowNumber;

            if (row < 0) //클릭한 곳이 그리드의 공백이라면 리턴리턴~
                return;

            this.pbxReserDate.Visible = false;
            this.pbxCPL.Visible = false;
            this.btnCPL.Visible = false;
            this.patInfo.Reset();
            this.patInfo.Tag = null;
            
            //MED-9244
            //this.dtpActingDate.SetDataValue(EnvironInfo.GetSysDate()); //오늘 날짜로 변경
            this.dtpActingDate.SetDataValue(this.currentDate); //오늘 날짜로 변경
            //GetDateScreenOpen();
            this.patInfo.SetPatientID(this.grdMaster.GetItemString(row, "bunho").ToString());

            this.fbxActor.Focus();

            
            //MED-9244 duplicate request, just query only when users focus row, not first time
            if (!isFirstLoad)
            {
                this.grdOCS1003.QueryLayout(false);
                this.grdNUR1016.QueryLayout(false);
                this.grdOUT0106.QueryLayout(false);
                this.grdNUR1017.QueryLayout(false); 
            }
            isFirstLoad = false;
        }

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = new XEditGrid();
            grd = this.grdOCS1003;
            int currRow = grd.CurrentRowNumber;

            this.grdDetail.ParamList = new List<string>(new String[] { "f_bunho", "f_reser_date", "f_acting_date", "f_gwa", "f_doctor", "f_acting_flag" });

            this.grdDetail.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            this.grdDetail.SetBindVarValue("f_reser_date", grd.GetItemString(currRow, "reser_date"));
            this.grdDetail.SetBindVarValue("f_acting_date", grd.GetItemString(currRow, "acting_date"));
            this.grdDetail.SetBindVarValue("f_gwa", grd.GetItemString(currRow, "gwa"));
            this.grdDetail.SetBindVarValue("f_doctor", grd.GetItemString(currRow, "doctor"));
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_acting_flag", this.rbtWait.Checked ? "N" : "Y");
        }

        #region DzungTA modify
        private INJ1001U01Grouped2Args _INJ1001U01Grouped2Args = new INJ1001U01Grouped2Args();
        private INJ1001U01Grouped2Result _INJ1001U01Grouped2Result;
        private InjsINJ1001U01DetailListArgs _InjsINJ1001U01DetailListArgs = new InjsINJ1001U01DetailListArgs();
        private InjsINJ1001U01DetailListResult _InjsINJ1001U01DetailListResult;
        private InjsINJ1001U01ScheduleArgs _InjsINJ1001U01ScheduleArgs = new InjsINJ1001U01ScheduleArgs();
        private InjsINJ1001U01ScheduleResult _InjsINJ1001U01ScheduleResult;
        private INJ0102CodeNameListArgs _INJ0102CodeNameListArgs = new INJ0102CodeNameListArgs();
        private INJ0102CodeNameListResult _INJ0102CodeNameListResult;
        private INJ1001U01GrdSangArgs _INJ1001U01GrdSangArgs = new INJ1001U01GrdSangArgs();
        private INJ1001U01GrdSangResult _INJ1001U01GrdSangResult;
        private INJ1001U01XEditGridCell88Args _INJ1001U01XEditGridCell88Args = new INJ1001U01XEditGridCell88Args();
        private INJ1001U01XEditGridCell88Result _INJ1001U01XEditGridCell88Result;
        private INJ1001U01XEditGridCell89Args _INJ1001U01XEditGridCell89Args = new INJ1001U01XEditGridCell89Args();
        private INJ1001U01XEditGridCell89Result _inj1001U01XEditGridCell89Result;
        private InjsINJ1001U01AllergyListArgs _InjsINJ1001U01AllergyListArgs = new InjsINJ1001U01AllergyListArgs();
        private InjsINJ1001U01AllergyListResult _InjsINJ1001U01AllergyListResult;
        private InjsINJ1001U01CommentListArgs _InjsINJ1001U01CommentListArgs = new InjsINJ1001U01CommentListArgs();
        private InjsINJ1001U01CommentListResult _InjsINJ1001U01CommentListResult;
        private InjsINJ1001U01CplOrderStatusArgs _InjsINJ1001U01CplOrderStatusArgs =
            new InjsINJ1001U01CplOrderStatusArgs();
        private InjsINJ1001U01CplOrderStatusResult _InjsINJ1001U01CplOrderStatusResult;
        private InjsINJ1001U01InfectionListArgs _InjsINJ1001U01InfectionListArgs = new InjsINJ1001U01InfectionListArgs();
        private InjsINJ1001U01InfectionListResult _InjsINJ1001U01InfectionListResult;
        private InjsINJ1001U01LabelNewListArgs _InjsINJ1001U01LabelNewListArgs = new InjsINJ1001U01LabelNewListArgs();
        private InjsINJ1001U01LabelNewListResult _InjsINJ1001U01LabelNewListResult;
        private InjsINJ1001U01PrintNameListArgs _InjsINJ1001U01PrintNameListArgs = new InjsINJ1001U01PrintNameListArgs();
        private InjsINJ1001U01PrintNameListResult _InjsINJ1001U01PrintNameListResult;
        private InjsINJ1001U01ReserDateListArgs _InjsINJ1001U01ReserDateListArgs = new InjsINJ1001U01ReserDateListArgs();
        private InjsINJ1001U01ReserDateListResult _InjsINJ1001U01ReserDateListResult;
        private InjsINJ1001U01SettingPrintArgs _InjsINJ1001U01SettingPrintArgs = new InjsINJ1001U01SettingPrintArgs();
        private InjsINJ1001U01SettingPrintResult _InjsINJ1001U01SettingPrintResult;
        private static InjsINJ1001U01UpdateArgs _InjsINJ1001U01UpdateArgs = new InjsINJ1001U01UpdateArgs();
        private static UpdateResult _InjsINJ1001U01UpdateResult;
        private INJ1001U01CboTimeArgs _INJ1001U01CboTimeArgs = new INJ1001U01CboTimeArgs();
        private INJ1001U01CboTimeResult _INJ1001U01CboTimeResult;
        private INJ1001U01ComboListSortKeyArgs _INJ1001U01ComboListSortKeyArgs = new INJ1001U01ComboListSortKeyArgs();
        private ComboListByCodeTypeResult _INJ1001U01ComboListSortKeyResult;
        private INJ1001U01MlayConstantInfoArgs _INJ1001U01MlayConstantInfoArgs = new INJ1001U01MlayConstantInfoArgs();
        private INJ1001U01MlayConstantInfoResult _INJ1001U01MlayConstantInfoResult;


        private InjsINJ1001U01MasterListArgs _InjsINJ1001U01MasterListArgs = new InjsINJ1001U01MasterListArgs();
        private InjsINJ1001U01MasterListResult _InjsINJ1001U01MasterListResult;
        private InjsINJ1001U01ChkbStateArgs _InjsINJ1001U01ChkbStateArgs = new InjsINJ1001U01ChkbStateArgs();
        private InjsINJ1001U01ChkbStateResult _InjsINJ1001U01ChkbStateResult;

        BindVarCollection _GrdDetailBc = new BindVarCollection();
        BindVarCollection _LayLableNewBc = new BindVarCollection();
        BindVarCollection _BtnPrintSetupBc = new BindVarCollection();

        private bool _GroupedLoad = false; // grouped requests load flag for controls grdOUT0106, grdNUR1016, grd1017; default each control will load data separately


        /// <summary>
        /// Bind query method to control's ExecuteQuery delegates.
        /// </summary>
        private void BindExecuteQueryMethod()
        {
            grdOCS1003.ExecuteQuery = QueryGrdOCS1003;
            grdSang.ExecuteQuery = QueryGrdSang;
            fwkCmt.ExecuteQuery = QueryFwkCmt;
            grdNUR1016.ExecuteQuery = QueryGrdNUR1016;
            grdDetail.ExecuteQuery = QueryGrdDetail;
            cboTime.ExecuteQuery = QueryCboTime;
            cboTime.SetDictDDLB();
            grdNUR1017.ExecuteQuery = QueryGrdNUR1017;
            grdOUT0106.ExecuteQuery = QueryGrdOUT0106;
            layLableNew.ExecuteQuery = QueryLayLableNew;
            layReserDate.ExecuteQuery = QueryLayReserDate;
            layCPLOrderYN.ExecuteQuery = QuerylayCPLOrderYN;
            layPrintName.ExecuteQuery = QueryLayPrintName;
            mlayConstantInfo.ExecuteQuery = QueryMLayConstantInfo;
            //layCommon.ExecuteQuery = QueryLayCommon;
            grdMaster.ExecuteQuery = QueryGrdMaster;
            fwkActor.ExecuteQuery = fbxActor_ExecuteQuery;
        }

        private IList<object[]> QueryGrdMaster(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01MasterListArgs.ActingFlag = varlist["f_acting_flag"].VarValue;
                _InjsINJ1001U01MasterListArgs.Gwa = varlist["f_gwa"].VarValue;
                _InjsINJ1001U01MasterListArgs.ReserDate = varlist["f_reser_date"].VarValue;
                _InjsINJ1001U01MasterListResult = CloudService.Instance.Submit<InjsINJ1001U01MasterListResult, InjsINJ1001U01MasterListArgs>(_InjsINJ1001U01MasterListArgs);

                if (_InjsINJ1001U01MasterListResult != null)
                {
                    foreach (IHIS.CloudConnector.Contracts.Models.Injs.InjsINJ1001U01MasterListItemInfo item in _InjsINJ1001U01MasterListResult.MasterListItem)
                    {
                        object[] objects =
                    {
                        item.TrialYn,
                        item.ReserGubun ,
                        item.Bunho ,
                        item.Suname,
                        item.OrderDate ,
                        item.ReserDate
                        
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryGrdMaster" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryLayCommon(BindVarCollection varlist)
        {
            IList<object[]> lObj = new List<object[]>();

            INJ0102CodeNameListArgs args = new INJ0102CodeNameListArgs();
            args.Code = varlist["f_code"].VarValue;
            args.CodeType = "INJ_COMMENT";
            INJ0102CodeNameListResult res = CloudService.Instance.Submit<INJ0102CodeNameListResult, INJ0102CodeNameListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.CodeNameList.ForEach(delegate(DataStringListItemInfo item)
                {
                    lObj.Add(new object[] { item.DataValue });
                });
            }

            return lObj;
        }

        private IList<object[]> QueryMLayConstantInfo(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                //_INJ1001U01MlayConstantInfoResult = CacheService.Instance.Get<INJ1001U01MlayConstantInfoArgs, INJ1001U01MlayConstantInfoResult>("INJ1001U01MlayConstantInfo", _INJ1001U01MlayConstantInfoArgs);
                //_INJ1001U01MlayConstantInfoResult =
                //    CloudService.Instance.Submit<INJ1001U01MlayConstantInfoResult, INJ1001U01MlayConstantInfoArgs>(
                //        _INJ1001U01MlayConstantInfoArgs);
                _INJ1001U01MlayConstantInfoResult = CacheService.Instance.Get<INJ1001U01MlayConstantInfoArgs, INJ1001U01MlayConstantInfoResult>(_INJ1001U01MlayConstantInfoArgs);

                if (_INJ1001U01MlayConstantInfoResult != null)
                {
                    foreach (ComboListItemInfo item in _INJ1001U01MlayConstantInfoResult.Item)
                    {
                        object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryMLayConstantInfo" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryLayPrintName(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01PrintNameListArgs.IpAddr = this.layPrintName.BindVarList["f_ip_addr"].VarValue;
                //_InjsINJ1001U01PrintNameListResult = CloudService.Instance.Submit<InjsINJ1001U01PrintNameListResult, InjsINJ1001U01PrintNameListArgs>(_InjsINJ1001U01PrintNameListArgs);

                //_InjsINJ1001U01PrintNameListResult = CacheService.Instance.Get<InjsINJ1001U01PrintNameListArgs, InjsINJ1001U01PrintNameListResult>("InjsINJ1001U01PrintNameList", _InjsINJ1001U01PrintNameListArgs);
                _InjsINJ1001U01PrintNameListResult = CacheService.Instance.Get<InjsINJ1001U01PrintNameListArgs, InjsINJ1001U01PrintNameListResult>(_InjsINJ1001U01PrintNameListArgs);
                if (_InjsINJ1001U01PrintNameListResult != null)
                {
                    foreach (string item in _InjsINJ1001U01PrintNameListResult.PrintNameList)
                    {
                        object[] objects =
                    {
                        item
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryLayPrintName" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QuerylayCPLOrderYN(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01CplOrderStatusArgs.Bunho = this.layCPLOrderYN.BindVarList["f_bunho"].VarValue;
                _InjsINJ1001U01CplOrderStatusArgs.Date = this.layCPLOrderYN.BindVarList["f_date"].VarValue;
                _InjsINJ1001U01CplOrderStatusArgs.Gubun = "O";
                _InjsINJ1001U01CplOrderStatusArgs.JundalPart = "CPL";
                _InjsINJ1001U01CplOrderStatusResult =
                    CloudService.Instance.Submit<InjsINJ1001U01CplOrderStatusResult, InjsINJ1001U01CplOrderStatusArgs>(
                        _InjsINJ1001U01CplOrderStatusArgs);
                if (_InjsINJ1001U01CplOrderStatusResult != null)
                {
                    object[] objects =
                {
                    _InjsINJ1001U01CplOrderStatusResult.Result
                };
                    res.Add(objects);
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QuerylayCPLOrderYN" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryLayReserDate(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01ReserDateListArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
                _InjsINJ1001U01ReserDateListArgs.Bunho = patInfo.BunHo;
                _InjsINJ1001U01ReserDateListArgs.Doctor = "";
                _InjsINJ1001U01ReserDateListArgs.ReserDate = this.dtpQueryDate.GetDataValue();
                _InjsINJ1001U01ReserDateListResult =
                    CloudService.Instance.Submit<InjsINJ1001U01ReserDateListResult, InjsINJ1001U01ReserDateListArgs>(
                        _InjsINJ1001U01ReserDateListArgs);
                if (_InjsINJ1001U01ReserDateListResult != null)
                {
                    //foreach (string item in _InjsINJ1001U01ReserDateListResult.ReserDate)
                    //{
                    //    object[] objects =
                    //{
                    //    item
                    //};
                    //    res.Add(objects);
                    //}

                    // AnhNV hot fixed
                    _InjsINJ1001U01ReserDateListResult.ReserDate.ForEach(delegate(DataStringListItemInfo item)
                    {
                        res.Add(new object[] { item.DataValue });
                    });
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryLayReserDate" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryXEditGridCell77(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            return res;
        }

        private IList<object[]> QueryLayLableNew(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _InjsINJ1001U01LabelNewListArgs.Doctor = _LayLableNewBc["f_doctor"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.Bunho = _LayLableNewBc["f_bunho"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.Fkinj1001 = _LayLableNewBc["f_fkinj1001"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.GroupSer = _LayLableNewBc["f_group_ser"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.Gwa = _LayLableNewBc["f_gwa"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.JubsuDate = _LayLableNewBc["f_jubsu_date"].VarValue;
                _InjsINJ1001U01LabelNewListArgs.MixGroup = _LayLableNewBc["f_mix_group"].VarValue;
                _InjsINJ1001U01LabelNewListResult =
                    CloudService.Instance.Submit<InjsINJ1001U01LabelNewListResult, InjsINJ1001U01LabelNewListArgs>(
                        _InjsINJ1001U01LabelNewListArgs);
                if (_InjsINJ1001U01LabelNewListResult != null)
                {
                    foreach (InjsINJ1001U01LabelNewListItemInfo item in _InjsINJ1001U01LabelNewListResult.LabelNewListItem)
                    {
                        object[] objects =
                    {
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.Age,
                        item.Sex,
                        item.JubsuDate,
                        item.Cnt,
                        item.Suryang,
                        item.DanuiName,
                        item.BogyongName,
                        item.JusaName,
                        item.JaeryoName,
                        item.OrderRemark,
                        item.DataGubun,
                        item.MixYn
                        
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryLayLableNew" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryGrdOUT0106(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                if (_GroupedLoad)
                {
                    _INJ1001U01Grouped2Args.ActingDate = "";
                    _INJ1001U01Grouped2Args.ActingFlag = "";
                    _INJ1001U01Grouped2Args.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue; //this.grdNUR1016.BindVarList["f_query_date"].VarValue;
                    _INJ1001U01Grouped2Args.CommtGubun = "B";
                    _INJ1001U01Grouped2Args.Doctor = "";
                    _INJ1001U01Grouped2Args.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
                    _INJ1001U01Grouped2Args.OrderDate = "";
                    _INJ1001U01Grouped2Args.PostOrderYn = "";
                    _INJ1001U01Grouped2Args.PreOrderYn = "";
                    _INJ1001U01Grouped2Args.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
                    _INJ1001U01Grouped2Args.ReserDate = "";

                    if (_INJ1001U01Grouped2Result == null)
                    {
                        _INJ1001U01Grouped2Result =
                            CloudService.Instance.Submit<INJ1001U01Grouped2Result, INJ1001U01Grouped2Args>(
                                _INJ1001U01Grouped2Args);
                    }
                    if (_INJ1001U01Grouped2Result != null)
                    {
                        foreach (DataStringListItemInfo item in _INJ1001U01Grouped2Result.GrdOut0106ListItem)
                        {
                            object[] objects =
                            {
                                item.DataValue
                            };
                            res.Add(objects);
                        }
                    }
                }
                else
                {
                    _InjsINJ1001U01CommentListArgs.Bunho = this.patInfo.BunHo;
                    _InjsINJ1001U01CommentListArgs.CommtGubun = "B";
                    _InjsINJ1001U01CommentListResult =
                        CloudService.Instance.Submit<InjsINJ1001U01CommentListResult, InjsINJ1001U01CommentListArgs>(
                            _InjsINJ1001U01CommentListArgs);
                    if (_InjsINJ1001U01CommentListResult != null)
                    {
                        foreach (DataStringListItemInfo item in _InjsINJ1001U01CommentListResult.CommentList)
                        {
                            object[] objects =
                            {
                                item.DataValue
                            };
                            res.Add(objects);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryGrdOUT0106" + ex.Message);
                throw;
            }
            return res;
        }

        private IList<object[]> QueryXEditGridCell89(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _inj1001U01XEditGridCell89Result = CacheService.Instance.Get<INJ1001U01XEditGridCell89Args, INJ1001U01XEditGridCell89Result>(
                            _INJ1001U01XEditGridCell89Args);
                if (_inj1001U01XEditGridCell89Result != null)
                {
                    foreach (INJ1001U01XEditGridCell89ItemInfo item in _inj1001U01XEditGridCell89Result.XeditGridCell89Item)
                    {
                        object[] objects =
                    {
                        item.Code,
                        item.CodeName,
                        item.SortKey
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryXEditGridCell89" + ex.Message);
                throw;
            }

            return res;
        }

        private IList<object[]> QueryXEditGridCell88(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                _INJ1001U01XEditGridCell88Result = CacheService.Instance.Get<INJ1001U01XEditGridCell88Args, INJ1001U01XEditGridCell88Result>(
                           _INJ1001U01XEditGridCell88Args);
                if (_INJ1001U01XEditGridCell88Result != null)
                {
                    foreach (ComboListItemInfo item in _INJ1001U01XEditGridCell88Result.XeditGridCell88Item)
                    {
                        object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryXEditGridCell88" + ex.Message);
                throw;
            }

            return res;
        }

        private IList<object[]> QueryGrdNUR1017(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                if (_GroupedLoad)
                {
                    _INJ1001U01Grouped2Args.ActingDate = "";
                    _INJ1001U01Grouped2Args.ActingFlag = "";
                    _INJ1001U01Grouped2Args.Bunho = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
                    _INJ1001U01Grouped2Args.CommtGubun = "B";
                    _INJ1001U01Grouped2Args.Doctor = "";
                    _INJ1001U01Grouped2Args.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
                    _INJ1001U01Grouped2Args.OrderDate = "";
                    _INJ1001U01Grouped2Args.PostOrderYn = "";
                    _INJ1001U01Grouped2Args.PreOrderYn = "";
                    _INJ1001U01Grouped2Args.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
                    _INJ1001U01Grouped2Args.ReserDate = "";

                    if (_INJ1001U01Grouped2Result == null)
                    {
                        _INJ1001U01Grouped2Result =
                            CloudService.Instance.Submit<INJ1001U01Grouped2Result, INJ1001U01Grouped2Args>(
                                _INJ1001U01Grouped2Args);
                    }
                    if (_INJ1001U01Grouped2Result != null)
                    {
                        foreach (InjsINJ1001U01InfectionListItemInfo item in _INJ1001U01Grouped2Result.GrdNur1017ListItem)
                        {
                            object[] objects =
                            {
                                item.InfeJaeryo,
                                item.InfeCode,
                            };
                            res.Add(objects);
                        }
                    }
                }
                else
                {
                    _InjsINJ1001U01InfectionListArgs.Bunho = this.grdNUR1017.BindVarList["f_bunho"].VarValue;
                    _InjsINJ1001U01InfectionListArgs.QueryDate = this.grdNUR1017.BindVarList["f_query_date"].VarValue;
                    _InjsINJ1001U01InfectionListResult = CloudService.Instance
                        .Submit<InjsINJ1001U01InfectionListResult, InjsINJ1001U01InfectionListArgs>(
                            _InjsINJ1001U01InfectionListArgs);
                    if (_InjsINJ1001U01InfectionListResult != null)
                    {
                        foreach (
                            InjsINJ1001U01InfectionListItemInfo item in
                                _InjsINJ1001U01InfectionListResult.InfectionListItem)
                        {
                            object[] objects =
                            {
                                item.InfeJaeryo,
                                item.InfeCode,
                            };
                            res.Add(objects);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryGrdNUR1017" + ex.Message);
                throw;
            }

            return res;
        }

        private IList<object[]> QueryCboTime(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                //_INJ1001U01CboTimeResult = CacheService.Instance.Get<INJ1001U01CboTimeArgs, INJ1001U01CboTimeResult>("INJ1001U01CboTimeResult", _INJ1001U01CboTimeArgs);
                //_INJ1001U01CboTimeResult = CacheService.Instance.Get<INJ1001U01CboTimeArgs, INJ1001U01CboTimeResult>(_INJ1001U01CboTimeArgs);
                _INJ1001U01CboTimeResult = CloudService.Instance.Submit<INJ1001U01CboTimeResult, INJ1001U01CboTimeArgs>(_INJ1001U01CboTimeArgs);
                if (_INJ1001U01CboTimeResult != null)
                {
                    foreach (ComboListItemInfo item in _INJ1001U01CboTimeResult.GrdOcs1003Item)
                    {
                        object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                        res.Add(objects);
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryCboTime" + ex.Message);
                throw;
            }
            return res;
        }


        private IList<object[]> QueryGrdDetail(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();

            _InjsINJ1001U01DetailListArgs.ActingDate = this.grdDetail.BindVarList["f_acting_date"].VarValue;
            _InjsINJ1001U01DetailListArgs.ActingFlag = this.grdDetail.BindVarList["f_acting_flag"].VarValue;
            _InjsINJ1001U01DetailListArgs.Bunho = this.grdDetail.BindVarList["f_bunho"].VarValue;
            _InjsINJ1001U01DetailListArgs.Doctor = this.grdDetail.BindVarList["f_doctor"].VarValue;
            _InjsINJ1001U01DetailListArgs.Gwa = this.grdDetail.BindVarList["f_gwa"].VarValue;
            _InjsINJ1001U01DetailListArgs.ReserDate = this.grdDetail.BindVarList["f_reser_date"].VarValue;
            _InjsINJ1001U01DetailListResult = null;

            if (_InjsINJ1001U01DetailListResult == null)
            {
                _InjsINJ1001U01DetailListResult = CloudService.Instance.Submit<InjsINJ1001U01DetailListResult, InjsINJ1001U01DetailListArgs>(
                            _InjsINJ1001U01DetailListArgs);
            }
            if (_InjsINJ1001U01DetailListResult != null)
            {
                foreach (InjsINJ1001U01DetailListItemInfo item in _InjsINJ1001U01DetailListResult.DetailListItem)
                {
                    object[] objects =
                    {
                        item.GroupSer,
                        item.Pkinj1002,
                        item.Fkinj1001,
                        item.Fkocs1003,
                        item.HangmogName,
                        item.Seq,
                        item.TonggyeCode,
                        item.MagamDate,
                        item.MagamJangso,
                        item.MagamSer,
                        item.ReserDateChar,
                        item.ReserTime,
                        item.JubsuDateChar,
                        item.HangmogCode,
                        item.JusaBuui,
                        item.ActingJangso,
                        item.ActingDateChar,
                        item.ActingTime,
                        item.CompanyCode,
                        item.LotNo,
                        item.ChasuCode,
                        item.PwResult,
                        item.CsResult,
                        item.Ast,
                        item.ActingFlag,
                        item.SunabDateChar,
                        item.SunabSuryang,
                        item.Fkout1001,
                        item.CancerYn,
                        item.Bunho,
                        item.RemarkChk,
                        item.DcYn,
                        item.JusaTongCnt,
                        item.OtherBuseoYn,
                        item.Jujongja,
                        item.JujongjaName,
                        item.YebangJujongChk,
                        item.ActdayChk,
                        item.Gwa,
                        item.BannabYn,
                        item.SkinYn,
                        item.ChungguDate,
                        item.OrderDate,
                        item.Doctor,
                        item.DanuiName,
                        item.HopeDateYn,
                        item.BogyongCode,
                        item.Suryang,
                        item.Dv,
                        item.DvTime,
                        item.SlipCode,
                        item.JusaYn,
                        item.MixGroup,
                        item.OldActingFlag,
                        item.SilsiRemark,
                        item.HopeDate,
                        item.OrderGubun,
                        item.TonggyeCodeName,
                        item.Key,
                    };
                    res.Add(objects);
                }
            }

            return res;
        }

        private IList<object[]> QueryGrdNUR1016(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            try
            {
                if (_GroupedLoad)
                {
                    _INJ1001U01Grouped2Args.ActingDate = "";
                    _INJ1001U01Grouped2Args.ActingFlag = "";
                    _INJ1001U01Grouped2Args.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue;
                    _INJ1001U01Grouped2Args.CommtGubun = "B";
                    _INJ1001U01Grouped2Args.Doctor = "";
                    _INJ1001U01Grouped2Args.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
                    _INJ1001U01Grouped2Args.OrderDate = "";
                    _INJ1001U01Grouped2Args.PostOrderYn = "";
                    _INJ1001U01Grouped2Args.PreOrderYn = "";
                    _INJ1001U01Grouped2Args.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
                    _INJ1001U01Grouped2Args.ReserDate = "";

                    if (_INJ1001U01Grouped2Result == null)
                    {
                        _INJ1001U01Grouped2Result =
                            CloudService.Instance.Submit<INJ1001U01Grouped2Result, INJ1001U01Grouped2Args>(
                                _INJ1001U01Grouped2Args);
                    }
                    if (_INJ1001U01Grouped2Result != null)
                    {
                        foreach (DataStringListItemInfo item in _INJ1001U01Grouped2Result.GrdNur1016ListItem)
                        {
                            object[] objects =
                        {
                            item.DataValue
                        };
                            //res.Add(objects);
                        }
                    }

                    //_InjsINJ1001U01AllergyListArgs.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue;
                    //_InjsINJ1001U01AllergyListArgs.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
                    //_InjsINJ1001U01AllergyListResult =
                    //    CloudService.Instance.Submit<InjsINJ1001U01AllergyListResult, InjsINJ1001U01AllergyListArgs>(
                    //        _InjsINJ1001U01AllergyListArgs);

                    //if (_InjsINJ1001U01AllergyListResult != null)
                    //{
                    //    foreach (DataStringListItemInfo item in _InjsINJ1001U01AllergyListResult.AllergyInfo)
                    //    {
                    //        object[] objects =
                    //    {
                    //        item.DataValue
                    //    };
                    //        res.Add(objects);
                    //    }
                    //}

                    res = (List<object[]>)querygrdNUR1016();
                }
                else
                {
                    _InjsINJ1001U01AllergyListArgs.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue;
                    _InjsINJ1001U01AllergyListArgs.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
                    _InjsINJ1001U01AllergyListResult =
                        CloudService.Instance.Submit<InjsINJ1001U01AllergyListResult, InjsINJ1001U01AllergyListArgs>(
                            _InjsINJ1001U01AllergyListArgs);

                    if (_InjsINJ1001U01AllergyListResult != null)
                    {
                        foreach (DataStringListItemInfo item in _InjsINJ1001U01AllergyListResult.AllergyInfo)
                        {
                            object[] objects =
                        {
                            item.DataValue
                        };
                            res.Add(objects);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("QueryGrdNUR1016" + ex.Message);
                throw;
            }

            return res;
        }

        private IList<object[]> QueryFwkCmt(BindVarCollection varlist)
        {
            List<object[]> lObj = new List<object[]>();

            INJ1001U01ComboListSortKeyArgs args = new INJ1001U01ComboListSortKeyArgs();
            args.CodeType = "INJ_COMMENT";
            // 2015.07.30 AnhNV fixed bug MED-2205
            //ComboResult res = CacheService.Instance.Get<INJ1001U01ComboListSortKeyArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_INJS_INJ1001U01_COMBO_LIST_SORT_KEY,
            //    args, delegate(ComboResult r) { return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0; });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, INJ1001U01ComboListSortKeyArgs>(args);
            ComboResult res = CacheService.Instance.Get<INJ1001U01ComboListSortKeyArgs, ComboResult>(args, delegate(ComboResult r)
            {
                return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            });

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }

        private IList<object[]> QueryGrdOCS1003(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();            
            _InjsINJ1001U01ScheduleArgs.ActingFlag = varlist["f_acting_flag"].VarValue;
            _InjsINJ1001U01ScheduleArgs.Bunho = varlist["f_bunho"].VarValue;
            _InjsINJ1001U01ScheduleArgs.OrderDate = varlist["f_order_date"].VarValue;
            _InjsINJ1001U01ScheduleArgs.PostOrderYn = varlist["f_post_order_yn"].VarValue;
            _InjsINJ1001U01ScheduleArgs.PreOrderYn = varlist["f_pre_order_yn"].VarValue;
            _InjsINJ1001U01ScheduleArgs.ReserDate = varlist["f_reser_date"].VarValue;
            _InjsINJ1001U01ScheduleResult = null;

            if (_InjsINJ1001U01ScheduleResult == null)
            {
                _InjsINJ1001U01ScheduleResult = CloudService.Instance.Submit<InjsINJ1001U01ScheduleResult, InjsINJ1001U01ScheduleArgs>(_InjsINJ1001U01ScheduleArgs);
            }
            if (_InjsINJ1001U01ScheduleResult != null)
            {
                foreach (InjsINJ1001U01ScheduleItemInfo item in _InjsINJ1001U01ScheduleResult.ScheduleItem)
                {
                    object[] objects =
                    {
                        item.ReserDate,
                        item.OrderDate,
                        item.ActingDate,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.IfDataSendYn
                    };
                    res.Add(objects);
                }
            }

            return res;
        }

        private IList<object[]> QueryGrdSang(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();

            _INJ1001U01GrdSangArgs.Bunho = this.grdSang.BindVarList["f_bunho"].VarValue;
            _INJ1001U01GrdSangArgs.Gwa = this.grdSang.BindVarList["f_gwa"].VarValue;
            _INJ1001U01GrdSangArgs.HospCode = this.grdSang.BindVarList["f_hosp_code"].VarValue;
            _INJ1001U01GrdSangArgs.ReserDate = this.grdSang.BindVarList["f_reser_date"].VarValue;
            _INJ1001U01GrdSangResult = null;

            if (_INJ1001U01GrdSangResult == null)
            {
                _INJ1001U01GrdSangResult = CloudService.Instance.Submit<INJ1001U01GrdSangResult, INJ1001U01GrdSangArgs>(_INJ1001U01GrdSangArgs);
            }
            if (_INJ1001U01GrdSangResult != null)
            {
                foreach (INJ1001U01GrdSangItemInfo item in _INJ1001U01GrdSangResult.ScheduleItem)
                {
                    object[] objects =
                    {
                        item.PkSeq,
                        item.SangName,
                        item.JuSangYn,
                        item.SangStartDate
                    };
                    res.Add(objects);
                }
            }

            return res;
        }

        #endregion

        #region save Grid Detail

        private UpdateResult GridDeatil_SaveLayout()
        {
            List<InjsINJ1001U01DetailListItemInfo> lstItemInfo = new List<InjsINJ1001U01DetailListItemInfo>();
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                InjsINJ1001U01DetailListItemInfo info = new InjsINJ1001U01DetailListItemInfo();
                info.ActingFlag = grdDetail.GetItemString(i, "acting_flag");
                info.ActingDateChar = grdDetail.GetItemString(i, "acting_date");
                info.ActingJangso = "IR";
                info.TonggyeCode = grdDetail.GetItemString(i, "tonggye_code");
                info.MixGroup = grdDetail.GetItemString(i, "mix_group");
                info.Jujongja = grdDetail.GetItemString(i, "jujongja");
                info.SilsiRemark = grdDetail.GetItemString(i, "silsi_remark");
                info.Pkinj1002 = grdDetail.GetItemString(i, "pkinj1002");

                lstItemInfo.Add(info);

            }
            INJ1001U01GridDetailSaveLayoutArgs args = new INJ1001U01GridDetailSaveLayoutArgs();
            args.UserId = UserInfo.UserID;
            // https://sofiamedix.atlassian.net/browse/MED-14735
            //args.UpdId = this.fbxActor.GetDataValue();
            args.UpdId = this.dbxUserId.GetDataValue();
            args.ItemInfo = lstItemInfo;

            return CloudService.Instance.Submit<UpdateResult, INJ1001U01GridDetailSaveLayoutArgs>(args);

        }
        #endregion

        /// <summary>
        /// grdNUR1017_PreEndInitializing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdNUR1017_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell88.ExecuteQuery = QueryXEditGridCell88;
            xEditGridCell89.ExecuteQuery = QueryXEditGridCell89;
        }

        private IList<object[]> querygrdNUR1016()
        {
            List<object[]> res = new List<object[]>();

            _InjsINJ1001U01AllergyListArgs.Bunho = this.grdNUR1016.BindVarList["f_bunho"].VarValue;
            _InjsINJ1001U01AllergyListArgs.QueryDate = this.grdNUR1016.BindVarList["f_query_date"].VarValue;
            _InjsINJ1001U01AllergyListResult =
                CloudService.Instance.Submit<InjsINJ1001U01AllergyListResult, InjsINJ1001U01AllergyListArgs>(
                    _InjsINJ1001U01AllergyListArgs);

            if (_InjsINJ1001U01AllergyListResult != null)
            {
                foreach (DataStringListItemInfo item in _InjsINJ1001U01AllergyListResult.AllergyInfo)
                {
                    object[] objects =
                        {
                            item.DataValue
                        };
                    res.Add(objects);
                }
            }

            return res;
        }

        #region fbxActor

        /// <summary>
        /// fbxActor_ExecuteQuery
        /// </summary>
        /// <param name="bindVarCollection"></param>
        /// <returns></returns>
        private IList<object[]> fbxActor_ExecuteQuery(BindVarCollection bindVarCollection)
        {
            IList<object[]> listObject = new List<object[]>();
            InjsINJ1001U01ActorListArgs args = new InjsINJ1001U01ActorListArgs();
            InjsINJ1001U01ActorListResult result =
                CloudService.Instance.Submit<InjsINJ1001U01ActorListResult, InjsINJ1001U01ActorListArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<InjsINJ1001U01ActorListItemInfo> lstActorListItemInfo = result.ActorListItem;
                if (lstActorListItemInfo != null && lstActorListItemInfo.Count > 0)
                {
                    foreach (InjsINJ1001U01ActorListItemInfo info in lstActorListItemInfo)
                    {
                        listObject.Add(new object[]
                        {
                            info.UserId,
                            info.UserNm,
                            info.DeptCode
                        });
                    }
                }
            }
            return listObject;
        }

        /// <summary>
        /// fbxActor_ExecuteValidating
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> fbxActor_ExecuteValidating(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            INJ1001U01LayCommonArgs vINJ1001U01LayCommonArgs = new INJ1001U01LayCommonArgs();
            vINJ1001U01LayCommonArgs.UserId = bc["f_user_id"].VarValue;
            vINJ1001U01LayCommonArgs.HospCode = bc["f_hosp_code"].VarValue;
            INJ1001U01LayCommonResult result = CloudService.Instance.Submit<INJ1001U01LayCommonResult, INJ1001U01LayCommonArgs>(vINJ1001U01LayCommonArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.UserNm)
                {
                    object[] objects =
                    {
                        item.DataValue
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion

        #region Cloud updated

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<INJ1001U01SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<INJ1001U01SaveLayoutInfo> lstData = new List<INJ1001U01SaveLayoutInfo>();

            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged) continue;

                INJ1001U01SaveLayoutInfo item = new INJ1001U01SaveLayoutInfo();

                item.ActingDate = grdDetail.GetItemString(i, "acting_date");
                item.ActingFlag = grdDetail.GetItemString(i, "acting_flag");
                item.HangmogName = grdDetail.GetItemString(i, "hangmog_name");
                item.Jujongja = grdDetail.GetItemString(i, "jujongja");
                item.MixGroup = grdDetail.GetItemString(i, "mix_group");
                item.Pkinj1002 = grdDetail.GetItemString(i, "pkinj1002");
                item.SilsiRemark = grdDetail.GetItemString(i, "silsi_remark");
                item.TonggyeCode = grdDetail.GetItemString(i, "tonggye_code");
                item.HangmogCode = grdDetail.GetItemString(i, "hangmog_code");
                item.Fkocs1003 = grdDetail.GetItemString(i, "fkocs1003");
                item.Suryang = grdDetail.GetItemString(i, "suryang");
                item.Dv = grdDetail.GetItemString(i, "dv");
                item.Nalsu = "1";
                item.RowState = grdDetail.GetRowState(i).ToString();

                lstData.Add(item);
            }

            return lstData;
        }
        #endregion

        #region GetLayTemp
        /// <summary>
        /// GetLayTemp
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayTemp(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            InjsINJ1001U01TempListArgs args = new InjsINJ1001U01TempListArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.Doctor = bvc["f_doctor"].VarValue;
            args.JubsuDate = bvc["f_jubsu_date"].VarValue;
            args.ReserDate = bvc["f_reser_date"].VarValue;
            InjsINJ1001U01TempListResult res = CloudService.Instance.Submit<InjsINJ1001U01TempListResult, InjsINJ1001U01TempListArgs>(args);

            if (res != null && res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.TempListItem.ForEach(delegate(InjsINJ1001U01TempListItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.SerialV,
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.Age,
                        item.Sex,
                        item.OrderDate,
                        item.JubsuDate,
                        item.Cnt,
                        item.Suryang,
                        item.DanuiName,
                        item.BogyongName,
                        item.JusaName,
                        item.JaeryoName,
                        item.OrderRemark,
                        item.DataGubun,
                        item.Birth,
                        item.DoctorName,
                        item.GwaName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region Cache init data
        //Request for all initialize data and cache if needed
        private void GetDataScreenOpenFirst()
        {
            INJ1001U01CompositeFirstArgs compositeArgs = new INJ1001U01CompositeFirstArgs();

            //1
            compositeArgs.CboTimeParam = new INJ1001U01CboTimeArgs();

            //2
            compositeArgs.GrdMasterParam = new InjsINJ1001U01MasterListArgs();
            compositeArgs.GrdMasterParam.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
            compositeArgs.GrdMasterParam.Gwa = "IR";
            compositeArgs.GrdMasterParam.ReserDate = this.currentDate.ToString("yyyy/MM/dd");
            //3
            compositeArgs.PatientInfo = GenPatientInfo();

            INJ1001U01CompositeFirstResult compositeResult = CloudService.Instance.Submit<INJ1001U01CompositeFirstResult, INJ1001U01CompositeFirstArgs>(compositeArgs, true, CallbackINJ1001U01CompositeFirst);
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackINJ1001U01CompositeFirst(INJ1001U01CompositeFirstArgs args, INJ1001U01CompositeFirstResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();

            cacheSession.Add(args.CboTimeParam, new KeyValuePair<int, object>(1, result.CboTimeList));
            cacheSession.Add(args.GrdMasterParam, new KeyValuePair<int, object>(1, result.GrdMasterList));
            if (result.GrdMasterList.MasterListItem.Count > 0)
            {
                GetPatientByCodeArgs patient = new GetPatientByCodeArgs();
                patient.PatientCode = result.GrdMasterList.MasterListItem[0].Bunho;               
                cacheSession.Add(patient, new KeyValuePair<int, object>(1, result.PatientInfo));
            }
            cacheData.Add(CachePolicy.ONCE, cacheSession);

            return cacheData;
        }
        private GetPatientByCodeArgs GenPatientInfo()
        {
            //2
            GetPatientByCodeArgs patient = new GetPatientByCodeArgs();
            patient.PatientCode = "";
            return patient;
        }
        //private void GetDateScreenOpen()
        //{
        //    INJ1001U01CompositeSecondArgs compositeArgs = new INJ1001U01CompositeSecondArgs();
        //    compositeArgs.PatientInfo = GenPatientInfo();
        //    compositeArgs.Schedule = GenSchedule();
        //    INJ1001U01CompositeSecondResult compositeResult = CloudService.Instance.Submit<INJ1001U01CompositeSecondResult, INJ1001U01CompositeSecondArgs>(compositeArgs, true, CallbackINJ1001U01Composite);
        //}

        //private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackINJ1001U01Composite(INJ1001U01CompositeSecondArgs args, INJ1001U01CompositeSecondResult result)
        //{
        //    Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
        //    Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();

        //    cacheSession.Add(args.Schedule, new KeyValuePair<int, object>(1, result.Schedule));
        //    cacheSession.Add(args.PatientInfo, new KeyValuePair<int, object>(1, result.PatientInfo));
        //    cacheData.Add(CachePolicy.ONCE, cacheSession);

        //    return cacheData;
        //}
        private void GetDataScreen()
        {
            INJ1001U01CompositeLoadDataArgs compositeArgs = new INJ1001U01CompositeLoadDataArgs();
            compositeArgs.Buseo = GenBuseo();
            compositeArgs.GrdCell88 = GenGrdCell88();
            compositeArgs.GrdCell89 = GenGrdCell89();
            compositeArgs.InfoSysDate = GenInfoSysDate();
            INJ1001U01CompositeLoadDataResult compositeResult = CloudService.Instance.Submit<INJ1001U01CompositeLoadDataResult, INJ1001U01CompositeLoadDataArgs>(compositeArgs, false, CallbackINJ1001U01CompositeLoadData);
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackINJ1001U01CompositeLoadData(INJ1001U01CompositeLoadDataArgs args, INJ1001U01CompositeLoadDataResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();

            cacheSession.Add(args.Buseo, new KeyValuePair<int, object>(1, result.Buseo));
            cacheSession.Add(args.GrdCell88, new KeyValuePair<int, object>(1, result.GrdCell88));
            cacheSession.Add(args.GrdCell89, new KeyValuePair<int, object>(1, result.GrdCell89));
            cacheSession.Add(args.InfoSysDate, new KeyValuePair<int, object>(1, result.Result));
            cacheData.Add(CachePolicy.ONCE, cacheSession);

            return cacheData;
        }
        private BuseoListArgs GenBuseo()
        {
            BuseoListArgs buseoList = new BuseoListArgs();
            buseoList.BuseoGubun = "1";
            return buseoList;
        }
        private INJ1001U01XEditGridCell88Args GenGrdCell88()
        {
            INJ1001U01XEditGridCell88Args gridCell88 = new INJ1001U01XEditGridCell88Args();
            return gridCell88;
        }
        private INJ1001U01XEditGridCell89Args GenGrdCell89()
        {
            INJ1001U01XEditGridCell89Args gridCell89 = new INJ1001U01XEditGridCell89Args();
            return gridCell89;
        }
        private FormEnvironInfoSysDateArgs GenInfoSysDate()
        {
            FormEnvironInfoSysDateArgs infoSysDate = new FormEnvironInfoSysDateArgs();
            return infoSysDate;
        }        

        private void GetDataScreenOpenSecond()
        {
            INJ1001U01CompositeSecondArgs compositeArgs = new INJ1001U01CompositeSecondArgs();
            compositeArgs.Schedule = GenSchedule();          
            compositeArgs.GrdDetail = GenDetailArgs();
            compositeArgs.GrdSang = GenGrdSangArgs();
            compositeArgs.CplOrder = GenCplOrderArgs();
            compositeArgs.Grouped = GenGroupedArgs();
            compositeArgs.Allergy = GenAllergyArgs();
            compositeArgs.ReserDate = GenReserDateArgs();
            compositeArgs.ChkbState = GenChkbStateList();
            compositeArgs.ConsInfo = GenConsInfo();
           // compositeArgs.PatientInfo = GenPatientInfo();
            INJ1001U01CompositeSecondResult compositeResult = CloudService.Instance.Submit<INJ1001U01CompositeSecondResult, INJ1001U01CompositeSecondArgs>(compositeArgs, true, CallbackINJ1001U01CompositeSecond);
        }
        private InjsINJ1001U01ScheduleArgs GenSchedule()
        { 
            //1
            InjsINJ1001U01ScheduleArgs schedule = new InjsINJ1001U01ScheduleArgs();
            schedule.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
            schedule.Bunho = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "bunho").ToString();
            schedule.OrderDate = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "order_date").ToString();
            schedule.PostOrderYn = "N";
            schedule.PreOrderYn = "N";
            schedule.ReserDate = this.dtpQueryDate.GetDataValue();         

            return schedule;
        }    

        private INJ1001U01MlayConstantInfoArgs GenConsInfo()
        {
            //3
            INJ1001U01MlayConstantInfoArgs ConstantInfo = new INJ1001U01MlayConstantInfoArgs();
            return ConstantInfo;
        }

        private List<InjsINJ1001U01ChkbStateArgs> GenChkbStateList()
        {
            //4
            List<InjsINJ1001U01ChkbStateArgs> chkbStateList = new List<InjsINJ1001U01ChkbStateArgs>();
            for (int i = 0; i < this.grdMaster.RowCount; i++)
            {
                InjsINJ1001U01ChkbStateArgs cbkbStateArgs = new InjsINJ1001U01ChkbStateArgs();
                cbkbStateArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
                cbkbStateArgs.ReserDate = dtpQueryDate.GetDataValue();
                cbkbStateArgs.Bunho = this.grdMaster.GetItemString(i, "bunho");
                cbkbStateArgs.Doctor = this.grdMaster.GetItemString(i, "doctor");
                chkbStateList.Add(cbkbStateArgs);
            }

            return chkbStateList;
        }

        private InjsINJ1001U01ReserDateListArgs GenReserDateArgs()
        {
            //5
            InjsINJ1001U01ReserDateListArgs reserDateArgs = new InjsINJ1001U01ReserDateListArgs();
            reserDateArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";
            reserDateArgs.Bunho = patInfo.BunHo;
            reserDateArgs.Doctor = "";
            reserDateArgs.ReserDate = this.dtpQueryDate.GetDataValue();

            return reserDateArgs;
        }

        private InjsINJ1001U01AllergyListArgs GenAllergyArgs()
        {
            //6
            InjsINJ1001U01AllergyListArgs allergyArgs = new InjsINJ1001U01AllergyListArgs();
            allergyArgs.Bunho = patInfo.BunHo;
            allergyArgs.QueryDate = dtpQueryDate.GetDataValue();

            return allergyArgs;
        }

        private INJ1001U01Grouped2Args GenGroupedArgs()
        {
            //7
            //INJ1001U01Grouped2Args groupedArgs = new INJ1001U01Grouped2Args();
            //groupedArgs.ActingDate = "";
            //groupedArgs.ActingFlag = "";
            //groupedArgs.Bunho = this.patInfo.BunHo;
            //groupedArgs.CommtGubun = "B";
            //groupedArgs.Doctor = "";
            //groupedArgs.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
            //groupedArgs.OrderDate = "";
            //groupedArgs.PostOrderYn = "";
            //groupedArgs.PreOrderYn = "";
            //groupedArgs.QueryDate = this.dtpQueryDate.GetDataValue();
            //groupedArgs.ReserDate = "";

            INJ1001U01Grouped2Args groupedArgs = new INJ1001U01Grouped2Args();
            groupedArgs.ActingDate = "";
            groupedArgs.ActingFlag = "";
            groupedArgs.Bunho = this.patInfo.BunHo;
            groupedArgs.CommtGubun = "B";
            groupedArgs.Doctor = "";
            groupedArgs.Gwa = "";
            groupedArgs.OrderDate = "";
            groupedArgs.PostOrderYn = "";
            groupedArgs.PreOrderYn = "";
            groupedArgs.QueryDate = this.dtpQueryDate.GetDataValue();
            groupedArgs.ReserDate = "";
            return groupedArgs;
        }

        private InjsINJ1001U01CplOrderStatusArgs GenCplOrderArgs()
        {
            //8
            InjsINJ1001U01CplOrderStatusArgs cplOrderArgs = new InjsINJ1001U01CplOrderStatusArgs();
            cplOrderArgs.Bunho = this.patInfo.BunHo;
            cplOrderArgs.Date = this.dtpQueryDate.GetDataValue();
            cplOrderArgs.Gubun = "O";
            cplOrderArgs.JundalPart = "CPL";

            return cplOrderArgs;
        }

        private INJ1001U01GrdSangArgs GenGrdSangArgs()
        {
            //9
            //INJ1001U01GrdSangArgs grdSangArgs = new INJ1001U01GrdSangArgs();
            //grdSangArgs.Bunho = this.patInfo.BunHo;
            //grdSangArgs.Gwa = this.grdOCS1003.GetItemString(this.grdOCS1003.CurrentRowNumber, "gwa");
            //grdSangArgs.ReserDate = this.dtpQueryDate.GetDataValue();
            //grdSangArgs.HospCode = UserInfo.HospCode;
            INJ1001U01GrdSangArgs grdSangArgs = new INJ1001U01GrdSangArgs();
            grdSangArgs.Bunho = this.patInfo.BunHo;
            grdSangArgs.Gwa = "";
            grdSangArgs.ReserDate = this.dtpQueryDate.GetDataValue();
            grdSangArgs.HospCode = UserInfo.HospCode;

            return grdSangArgs;
        }

        private InjsINJ1001U01DetailListArgs GenDetailArgs()
        {
            //10
            InjsINJ1001U01DetailListArgs detailArgs = new InjsINJ1001U01DetailListArgs();
            //XEditGrid grd = new XEditGrid();
            //grd = this.grdOCS1003;
            //int currRow = grd.CurrentRowNumber;
            //detailArgs.Bunho = this.patInfo.BunHo;
            //detailArgs.ReserDate = grd.GetItemString(currRow, "reser_date");
            //detailArgs.ActingDate = grd.GetItemString(currRow, "acting_date");
            //detailArgs.Gwa = grd.GetItemString(currRow, "gwa");
            //detailArgs.Doctor = grd.GetItemString(currRow, "doctor");
            //detailArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";           
            detailArgs.Bunho = this.patInfo.BunHo;
            detailArgs.ReserDate = "";
            detailArgs.ActingDate = "";
            detailArgs.Gwa = "";
            detailArgs.Doctor = "";
            detailArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";

            return detailArgs;
        }

        private Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackINJ1001U01CompositeSecond(INJ1001U01CompositeSecondArgs args, INJ1001U01CompositeSecondResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();
            cacheSession.Add(args.Schedule, new KeyValuePair<int, object>(1, result.Schedule));
            //cacheSession.Add(args.PatientInfo, new KeyValuePair<int, object>(1, result.PatientInfo));
            if (result.Schedule.ScheduleItem.Count > 0)
            {
                InjsINJ1001U01DetailListArgs detailArgs = new InjsINJ1001U01DetailListArgs();
                detailArgs.Bunho = this.patInfo.BunHo;
                detailArgs.ReserDate = result.Schedule.ScheduleItem[0].ReserDate; //grd.GetItemString(currRow, "reser_date");
                detailArgs.ActingDate = result.Schedule.ScheduleItem[0].ActingDate; //grd.GetItemString(currRow, "acting_date");
                detailArgs.Gwa = result.Schedule.ScheduleItem[0].Gwa; //grd.GetItemString(currRow, "gwa");
                detailArgs.Doctor = result.Schedule.ScheduleItem[0].Doctor; //grd.GetItemString(currRow, "doctor");
                detailArgs.ActingFlag = this.rbtWait.Checked ? "N" : "Y";

                cacheSession.Add(detailArgs, new KeyValuePair<int, object>(1, result.GrdDetail));

                INJ1001U01GrdSangArgs grdSangArgs = new INJ1001U01GrdSangArgs();
                grdSangArgs.Bunho = this.patInfo.BunHo;
                grdSangArgs.Gwa = result.Schedule.ScheduleItem[0].Gwa;
                grdSangArgs.ReserDate = this.dtpQueryDate.GetDataValue();
                grdSangArgs.HospCode = UserInfo.HospCode;
                cacheSession.Add(grdSangArgs, new KeyValuePair<int, object>(1, result.GrdSang));

                INJ1001U01Grouped2Args groupedArgs = new INJ1001U01Grouped2Args();
                groupedArgs.ActingDate = "";
                groupedArgs.ActingFlag = "";
                groupedArgs.Bunho = this.patInfo.BunHo;
                groupedArgs.CommtGubun = "B";
                groupedArgs.Doctor = "";
                groupedArgs.Gwa = result.Schedule.ScheduleItem[0].Gwa;
                groupedArgs.OrderDate = "";
                groupedArgs.PostOrderYn = "";
                groupedArgs.PreOrderYn = "";
                groupedArgs.QueryDate = this.dtpQueryDate.GetDataValue();
                groupedArgs.ReserDate = "";
                cacheSession.Add(groupedArgs, new KeyValuePair<int, object>(1, result.Grouped));
            }
            
            cacheSession.Add(args.CplOrder, new KeyValuePair<int, object>(1, result.CplOrder));
            
            cacheSession.Add(args.Allergy, new KeyValuePair<int, object>(2, result.Allergy)); //allergy call 2 times
            cacheSession.Add(args.ReserDate, new KeyValuePair<int, object>(1, result.ReserDate));
            for (int i = 0; i < result.ChkbState.Count; i++)
            {
                if (cacheSession.ContainsKey(args.ChkbState[i]))
                {
                    KeyValuePair<int, object> kp;
                    cacheSession.TryGetValue(args.ChkbState[i], out kp);
                    cacheSession.Remove(args.ChkbState[i]);
                    cacheSession.Add(args.ChkbState[i], new KeyValuePair<int, object>(kp.Key + 1, result.ChkbState[i]));
                }
                else
                    cacheSession.Add(args.ChkbState[i], new KeyValuePair<int, object>(1, result.ChkbState[i]));
            }
            cacheSession.Add(args.ConsInfo, new KeyValuePair<int, object>(1, result.ConsInfo));
            cacheData.Add(CachePolicy.ONCE, cacheSession);

            return cacheData;
        } 
        #endregion

        #endregion

        private void Init()
        {
            //this.dw_jusa.DataWindowObject = "";
            //this.dw_jusa.DataWindowObject = global::IHIS.INJS.Properties.Resources.dw_jusaDataWindowObject;
            //this.dw_jusa.LibraryList = global::IHIS.INJS.Properties.Resources.dw_jusaLibraryList;
            //this.dw_jusa.Name = global::IHIS.INJS.Properties.Resources.dw_jusaName;
            //this.dw_jusa_lable.DataWindowObject = "";
            //this.dw_jusa_lable.DataWindowObject = global::IHIS.INJS.Properties.Resources.dw_jusa_lableDataWindowObject;
            //this.dw_jusa_lable.LibraryList = global::IHIS.INJS.Properties.Resources.dw_jusa_lableLibraryList;
            //this.dw_jusa_lable.Name = global::IHIS.INJS.Properties.Resources.dw_jusa_lableName;
            //this.xDataWindow1.DataWindowObject = "";
            //this.xDataWindow1.DataWindowObject = global::IHIS.INJS.Properties.Resources.xDataWindow1DataWindowObject;
            //this.xDataWindow1.LibraryList = global::IHIS.INJS.Properties.Resources.xDataWindow1LibraryList;
            //this.xDataWindow1.Name = global::IHIS.INJS.Properties.Resources.xDataWindow1Name;
            //this.dw1.DataWindowObject = "";
            //this.dw1.DataWindowObject = global::IHIS.INJS.Properties.Resources.dw1DataWindowObject;
            //this.dw1.LibraryList = global::IHIS.INJS.Properties.Resources.dw1LibraryList;
            //this.dw1.Name = global::IHIS.INJS.Properties.Resources.dw1Name;
            //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.BrtWait, -1, ""));
            //this.btnList.InitializeButtons();
            //this.btnList.Refresh();
            //this.dw_jusa_lable.Visible = false;
        }

        #region MED-14588

        private void SetDefaultDoctor()
        {
            this.dbxUserId.SetDataValue(UserInfo.UserID);
            this.dbxUserName.SetDataValue(UserInfo.UserName);
            this.AutoInputInfo(UserInfo.UserID, UserInfo.UserName);
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("user_id", dbxUserId.GetDataValue());
            param.Add("user_name", dbxUserName.GetDataValue());
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM104Q", ScreenOpenStyle.PopupSingleFixed, param);
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "ADM104Q":

                    string userId = "";
                    string userName = "";

                    if (commandParam != null && commandParam.Contains("user_id"))
                    {
                        userId = commandParam["user_id"].ToString();
                        this.dbxUserId.SetDataValue(userId);
                        this.fbxActor.SetDataValue(userId);
                    }

                    if (commandParam != null && commandParam.Contains("user_name"))
                    {
                        userName = commandParam["user_name"].ToString();
                        this.dbxUserName.SetDataValue(userName);
                        this.dbxActor_name.SetDataValue(userName);
                    }

                    this.AutoInputInfo(userId, userName);
                    break;

                default:
                    break;
            }

            return base.Command(command, commandParam);
        }

        #endregion
    }
}