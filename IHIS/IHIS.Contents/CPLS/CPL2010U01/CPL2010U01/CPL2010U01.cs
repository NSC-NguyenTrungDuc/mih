#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using IHIS.CPLS.Properties;
using IHIS.Framework;
using Microsoft.Win32;
#endregion

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL2010U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL2010U01 : IHIS.Framework.XScreen
    {
        #region 자동생성

        private IHIS.Framework.XFindWorker fwkHodong;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.SingleLayout vsvHodong;
		private IHIS.Framework.MultiLayout layTube;
        private IHIS.Framework.MultiLayout layBarcode;
		private IHIS.Framework.SingleLayout layPrintName;
		private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private IHIS.Framework.MultiLayout layBarcodeOne;
        private IHIS.Framework.MultiLayout layUpdateTube;
		private IHIS.Framework.MultiLayout laySpecimenSer;
        private IHIS.Framework.MultiLayout layGumsaMark;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private MultiLayout layBarcode2;
        private MultiLayout layBarcodeTemp;
        private MultiLayout layBarcodeTemp2;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
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
        private MultiLayoutItem multiLayoutItem95;
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
        private XPanel xPanel2;
        private XPanel pnlMain;
        private XPanel xPanel3;
        private XDisplayBox dbxPaComment;
        private XLabel xLabel4;
        private XDisplayBox dbxJu;
        private XLabel xLabel1;
        private XPanel xPanel8;
        private XButton btnAllCheck;
        private XButton btnGumJubsu;
        private XButton btnSpecimenList;
        private XButton btnAllUnCheck;
        private XButton btnPrintSetup;
        private XButton btnChangeTime;
        private XButton btnBarcode;
        private XButtonList btnList;
 //       private XDataWindow dwBarcode;
        private XButton btnAllPrintLabel;
        private XPanel pnlLeft;
        private XPanel xPanel1;
        private RadioButton rbxJubsu;
        private RadioButton rbxMijubsu;
        private XMstGrid grdPa;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XPanel pnlPaInfo;
        private XButton btnCancleLabel;
        private XCheckBox cbxReser;
        private XTextBox txtBunho;
        private XLabel xLabel2;
        private Label label1;
        private XDatePicker dtpToOrderDate;
        private XLabel xLabel7;
        private XDatePicker dtpFromOrderDate;
        private XLabel xLabel3;
        private XPatientBox paBox;
        private XPanel pnlOrder;
        private XMstGrid grdSpecimen;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell50;
        private XPanel xPanel7;
        private XEditGrid grdTube;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XDictComboBox cbxBuseo;
        private XEditGridCell xEditGridCell52;
        private Panel pnlStatus;
        private Label lbStatus;
        private XProgressBar pgbProgress;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XDictComboBox cbxActor;
        private XPanel xPanel4;
        private XMstGrid grdPaList;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XTextBox txtTimeInterval;
        private XTextBox tbxTimer;
        private XDictComboBox cboTime;
        private XLabel xLabel8;
        private XLabel lbTime;
        private XButton btnUseAlarmChk;
        private XButton btnUseTimeChk;
        private Timer timer1;
        private MultiLayout mlayConstantInfo;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private XEditGridCell xEditGridCell44;
        private XPictureBox pbxJusa;
        private XButton btnAllCancelLabel;
   //     private XDataWindow dwOrderPrint;
        private XButton btnOrderPrint;
        private MultiLayout layOrderPrint;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell55;
        private System.ComponentModel.IContainer components;
        #endregion 

        public CPL2010U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010U01));
            this.fwkHodong = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.vsvHodong = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layTube = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcode = new IHIS.Framework.MultiLayout();
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
            this.layPrintName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.layBarcodeOne = new IHIS.Framework.MultiLayout();
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
            this.layUpdateTube = new IHIS.Framework.MultiLayout();
            this.laySpecimenSer = new IHIS.Framework.MultiLayout();
            this.layGumsaMark = new IHIS.Framework.MultiLayout();
            this.layBarcode2 = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcodeTemp = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcodeTemp2 = new IHIS.Framework.MultiLayout();
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
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.pnlMain = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.grdSpecimen = new IHIS.Framework.XMstGrid();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.dbxJu = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.grdPa = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.grdTube = new IHIS.Framework.XEditGrid();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.pnlPaInfo = new IHIS.Framework.XPanel();
            this.pbxJusa = new IHIS.Framework.XPictureBox();
            this.btnAllCheck = new IHIS.Framework.XButton();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.btnCancleLabel = new IHIS.Framework.XButton();
            this.btnAllUnCheck = new IHIS.Framework.XButton();
            this.txtBunho = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdPaList = new IHIS.Framework.XMstGrid();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtTimeInterval = new IHIS.Framework.XTextBox();
            this.tbxTimer = new IHIS.Framework.XTextBox();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.lbTime = new IHIS.Framework.XLabel();
            this.dtpToOrderDate = new IHIS.Framework.XDatePicker();
            this.dtpFromOrderDate = new IHIS.Framework.XDatePicker();
            this.rbxJubsu = new System.Windows.Forms.RadioButton();
            this.cbxBuseo = new IHIS.Framework.XDictComboBox();
            this.cbxReser = new IHIS.Framework.XCheckBox();
            this.rbxMijubsu = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dbxPaComment = new IHIS.Framework.XDisplayBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btnOrderPrint = new IHIS.Framework.XButton();
            this.btnAllCancelLabel = new IHIS.Framework.XButton();
            this.btnGumJubsu = new IHIS.Framework.XButton();
            this.btnUseAlarmChk = new IHIS.Framework.XButton();
            this.btnUseTimeChk = new IHIS.Framework.XButton();
            this.btnSpecimenList = new IHIS.Framework.XButton();
            this.btnPrintSetup = new IHIS.Framework.XButton();
            this.btnChangeTime = new IHIS.Framework.XButton();
            this.btnBarcode = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.btnAllPrintLabel = new IHIS.Framework.XButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mlayConstantInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.layOrderPrint = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.layTube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layUpdateTube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySpecimenSer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGumsaMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp2)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.xPanel7.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecimen)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTube)).BeginInit();
            this.pnlPaInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxJusa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "검사예약.gif");
            this.ImageList.Images.SetKeyName(3, "12.gif");
            this.ImageList.Images.SetKeyName(4, "13.gif");
            this.ImageList.Images.SetKeyName(5, "aquapuls.gif");
            // 
            // fwkHodong
            // 
            this.fwkHodong.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkHodong.ExecuteQuery = null;
            this.fwkHodong.FormText = global::IHIS.CPLS.Properties.Resources.FWKHODONG_FORMTEXT;
            this.fwkHodong.InputSQL = resources.GetString("fwkHodong.InputSQL");
            this.fwkHodong.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkHodong.ParamList")));
            this.fwkHodong.ServerFilter = true;
            this.fwkHodong.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkHodong_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.ColWidth = 115;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 329;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // vsvHodong
            // 
            this.vsvHodong.ExecuteQuery = null;
            this.vsvHodong.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.vsvHodong.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvHodong.ParamList")));
            this.vsvHodong.QuerySQL = resources.GetString("vsvHodong.QuerySQL");
            this.vsvHodong.QueryStarting += new System.ComponentModel.CancelEventHandler(this.vsvHodong_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "hodong_name";
            // 
            // layTube
            // 
            this.layTube.ExecuteQuery = null;
            this.layTube.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57});
            this.layTube.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTube.ParamList")));
            this.layTube.QuerySQL = resources.GetString("layTube.QuerySQL");
            this.layTube.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTube_QueryStarting);
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "tube_code";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "tube_name";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "cnt";
            // 
            // layBarcode
            // 
            this.layBarcode.ExecuteQuery = null;
            this.layBarcode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem94});
            this.layBarcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcode.ParamList")));
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "jundal_gubun";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "specimen_code";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "specimen_name";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "tube_code";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "tube_name";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "in_out_gubun";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "specimen_ser";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "bunho";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "suname";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "gwa_name";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "danger_yn";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "jangbi_code";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "jangbi_name";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "tube_max_amt";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "tube_numbering";
            // 
            // layPrintName
            // 
            this.layPrintName.ExecuteQuery = null;
            this.layPrintName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layPrintName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPrintName.ParamList")));
            this.layPrintName.QuerySQL = "SELECT B_PRINT_NAME\r\n  FROM ADM3300\r\n WHERE HOSP_CODE  = :f_hosp_code\r\n   AND IP_" +
    "ADDR    = :f_ip_addr\r\n";
            this.layPrintName.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPrintName_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "print_name";
            // 
            // layBarcodeOne
            // 
            this.layBarcodeOne.ExecuteQuery = null;
            this.layBarcodeOne.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem75});
            this.layBarcodeOne.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeOne.ParamList")));
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "jundal_gubun";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "specimen_code";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "specimen_name";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "tube_code";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "tube_name";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "in_out_gubun";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "specimen_ser";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "bunho";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "suname";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "gwa_name";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "danger_yn";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "jangbi_code";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "jangbi_name";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "tube_max_amt";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "tube_numbering";
            // 
            // layUpdateTube
            // 
            this.layUpdateTube.ExecuteQuery = null;
            this.layUpdateTube.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layUpdateTube.ParamList")));
            // 
            // laySpecimenSer
            // 
            this.laySpecimenSer.ExecuteQuery = null;
            this.laySpecimenSer.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySpecimenSer.ParamList")));
            // 
            // layGumsaMark
            // 
            this.layGumsaMark.ExecuteQuery = null;
            this.layGumsaMark.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGumsaMark.ParamList")));
            // 
            // layBarcode2
            // 
            this.layBarcode2.ExecuteQuery = null;
            this.layBarcode2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem95});
            this.layBarcode2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcode2.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "jundal_gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "specimen_code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "specimen_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "tube_code";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "tube_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "in_out_gubun";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "specimen_ser";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "bunho";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "suname";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "gwa_name";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "danger_yn";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "jangbi_code";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jangbi_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "tube_count";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "tube_max_amt";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "tube_numbering";
            // 
            // layBarcodeTemp
            // 
            this.layBarcodeTemp.ExecuteQuery = null;
            this.layBarcodeTemp.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem96});
            this.layBarcodeTemp.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeTemp.ParamList")));
            this.layBarcodeTemp.QuerySQL = resources.GetString("layBarcodeTemp.QuerySQL");
            this.layBarcodeTemp.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBarcodeTemp_QueryStarting);
            this.layBarcodeTemp.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layBarcodeTemp_QueryEnd);
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "jundal_gubun";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "specimen_code";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "specimen_name";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "tube_code";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "tube_name";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "in_out_gubun";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "specimen_ser";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "bunho";
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
            this.multiLayoutItem30.DataName = "danger_yn";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "jangbi_code";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "jangbi_name";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "tube_count";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "tube_max_amt";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "tube_numbering";
            // 
            // layBarcodeTemp2
            // 
            this.layBarcodeTemp2.ExecuteQuery = null;
            this.layBarcodeTemp2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem115});
            this.layBarcodeTemp2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeTemp2.ParamList")));
            this.layBarcodeTemp2.QuerySQL = resources.GetString("layBarcodeTemp2.QuerySQL");
            this.layBarcodeTemp2.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBarcodeTemp2_QueryStarting);
            this.layBarcodeTemp2.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layBarcodeTemp2_QueryEnd);
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "jundal_gubun";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "specimen_code";
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "specimen_name";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "tube_code";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "tube_name";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "in_out_gubun";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "specimen_ser";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "bunho";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "suname";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "gwa_name";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "danger_yn";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "jangbi_code";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "jangbi_name";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "tube_count";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "tube_max_amt";
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "tube_numbering";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.pnlMain);
            this.xPanel2.Controls.Add(this.pnlLeft);
            this.xPanel2.Controls.Add(this.xPanel3);
            this.xPanel2.Controls.Add(this.xPanel8);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.xPanel4);
            this.pnlMain.Controls.Add(this.pnlPaInfo);
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xPanel7);
            this.xPanel4.Controls.Add(this.pnlOrder);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // xPanel7
            // 
            this.xPanel7.Controls.Add(this.pnlStatus);
            this.xPanel7.Controls.Add(this.grdSpecimen);
            resources.ApplyResources(this.xPanel7, "xPanel7");
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
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lbStatus, "lbStatus");
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Name = "lbStatus";
            // 
            // pgbProgress
            // 
            resources.ApplyResources(this.pgbProgress, "pgbProgress");
            this.pgbProgress.Name = "pgbProgress";
            // 
            // grdSpecimen
            // 
            this.grdSpecimen.ApplyPaintEventToAllColumn = true;
            this.grdSpecimen.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell25,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell35,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell40,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell53,
            this.xEditGridCell36,
            this.xEditGridCell47,
            this.xEditGridCell50});
            this.grdSpecimen.ColPerLine = 11;
            this.grdSpecimen.ColResizable = true;
            this.grdSpecimen.Cols = 12;
            this.grdSpecimen.ControlBinding = true;
            resources.ApplyResources(this.grdSpecimen, "grdSpecimen");
            this.grdSpecimen.ExecuteQuery = null;
            this.grdSpecimen.FixedCols = 1;
            this.grdSpecimen.FixedRows = 1;
            this.grdSpecimen.HeaderHeights.Add(31);
            this.grdSpecimen.Name = "grdSpecimen";
            this.grdSpecimen.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSpecimen.ParamList")));
            this.grdSpecimen.RowHeaderVisible = true;
            this.grdSpecimen.Rows = 2;
            this.grdSpecimen.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdSpecimen.ToolTipActive = true;
            this.grdSpecimen.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdSpecimen_PreSaveLayout);
            this.grdSpecimen.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdSpecimen_GridColumnProtectModify);
            this.grdSpecimen.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdSpecimen_ItemValueChanging);
            this.grdSpecimen.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdSpecimen_RowFocusChanged);
            this.grdSpecimen.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSpecimen_GridCellPainting);
            this.grdSpecimen.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSpecimen_QueryStarting);
            this.grdSpecimen.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdSpecimen_QueryEnd);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "pkcpl2010";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sunab_yn";
            this.xEditGridCell7.CellWidth = 30;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jubsu_flag";
            this.xEditGridCell8.CellWidth = 31;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "slip_name";
            this.xEditGridCell9.CellWidth = 125;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.SuppressRepeating = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "hangmog_code";
            this.xEditGridCell10.CellWidth = 72;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "gumsa_name";
            this.xEditGridCell11.CellWidth = 219;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "specimen_code";
            this.xEditGridCell12.CellWidth = 32;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "specimen_name";
            this.xEditGridCell13.Col = 5;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "emergency";
            this.xEditGridCell14.CellWidth = 37;
            this.xEditGridCell14.Col = 7;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "tube_code";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "tube_name";
            this.xEditGridCell15.CellWidth = 100;
            this.xEditGridCell15.Col = 8;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdCol = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "specimen_ser";
            this.xEditGridCell16.CellWidth = 85;
            this.xEditGridCell16.Col = 10;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.BindControl = this.dbxJu;
            this.xEditGridCell26.CellName = "doc_comment";
            this.xEditGridCell26.CellWidth = 30;
            this.xEditGridCell26.Col = 11;
            this.xEditGridCell26.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            // 
            // dbxJu
            // 
            resources.ApplyResources(this.dbxJu, "dbxJu");
            this.dbxJu.Name = "dbxJu";
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "fkocs2003";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "group_gubun";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "part_jubsu_flag";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "gum_jubsu_flag";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "dummy";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "modify_yn";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "modify_yn_1";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jundal_gubun";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "jubsuja";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "order_date";
            this.xEditGridCell38.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "bunho";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "jubsu_date";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.IsUpdCol = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "jubsu_time";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.IsUpdCol = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "order_time";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.IsUpdCol = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "spcial_name";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.IsUpdCol = false;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "group_hangmog";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.IsUpdCol = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "barcode_name";
            this.xEditGridCell53.Col = 6;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.IsUpdCol = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "uitak_code";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "middle_result";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "print_yn";
            this.xEditGridCell50.CellWidth = 22;
            this.xEditGridCell50.Col = 9;
            this.xEditGridCell50.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdCol = false;
            // 
            // pnlOrder
            // 
            this.pnlOrder.BackColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.pnlOrder.Controls.Add(this.grdPa);
            this.pnlOrder.Controls.Add(this.grdTube);
            resources.ApplyResources(this.pnlOrder, "pnlOrder");
            this.pnlOrder.DrawBorder = true;
            this.pnlOrder.Name = "pnlOrder";
            // 
            // grdPa
            // 
            this.grdPa.ApplyPaintEventToAllColumn = true;
            this.grdPa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell43,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell5,
            this.xEditGridCell20,
            this.xEditGridCell3,
            this.xEditGridCell22,
            this.xEditGridCell54,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell55});
            this.grdPa.ColPerLine = 7;
            this.grdPa.ColResizable = true;
            this.grdPa.Cols = 8;
            this.grdPa.ControlBinding = true;
            resources.ApplyResources(this.grdPa, "grdPa");
            this.grdPa.ExecuteQuery = null;
            this.grdPa.FixedCols = 1;
            this.grdPa.FixedRows = 1;
            this.grdPa.HeaderHeights.Add(27);
            this.grdPa.Name = "grdPa";
            this.grdPa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPa.ParamList")));
            this.grdPa.RowHeaderVisible = true;
            this.grdPa.Rows = 2;
            this.grdPa.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPa.ToolTipActive = true;
            this.grdPa.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPa_RowFocusChanged);
            this.grdPa.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPa_GridCellPainting);
            this.grdPa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPa_QueryStarting);
            this.grdPa.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPa_QueryEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 71;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 50;
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.CellWidth = 79;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellLen = 50;
            this.xEditGridCell43.CellName = "gwa_name";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gwa";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 50;
            this.xEditGridCell6.CellName = "doctor_name";
            this.xEditGridCell6.CellWidth = 78;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "doctor";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "order_date";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell20.CellWidth = 100;
            this.xEditGridCell20.Col = 2;
            this.xEditGridCell20.EnableSort = true;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "order_time";
            this.xEditGridCell3.CellWidth = 45;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.Mask = "##:##";
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "jubsu_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.CellWidth = 100;
            this.xEditGridCell22.Col = 4;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "jubsu_time";
            this.xEditGridCell54.CellWidth = 45;
            this.xEditGridCell54.Col = 5;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.Mask = "##:##";
            this.xEditGridCell54.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "reser_date";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell48.CellWidth = 100;
            this.xEditGridCell48.Col = 6;
            this.xEditGridCell48.EnableSort = true;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 50;
            this.xEditGridCell49.CellName = "jubsuja_name";
            this.xEditGridCell49.CellWidth = 78;
            this.xEditGridCell49.Col = 7;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsReadOnly = true;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "group_ser";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // grdTube
            // 
            this.grdTube.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell52});
            this.grdTube.ColPerLine = 4;
            this.grdTube.ColResizable = true;
            this.grdTube.Cols = 5;
            resources.ApplyResources(this.grdTube, "grdTube");
            this.grdTube.ExecuteQuery = null;
            this.grdTube.FixedCols = 1;
            this.grdTube.FixedRows = 1;
            this.grdTube.HeaderHeights.Add(21);
            this.grdTube.Name = "grdTube";
            this.grdTube.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdTube.ParamList")));
            this.grdTube.QuerySQL = resources.GetString("grdTube.QuerySQL");
            this.grdTube.RowHeaderVisible = true;
            this.grdTube.Rows = 2;
            this.grdTube.RowStateCheckOnPaint = false;
            this.grdTube.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdTube_GridColumnProtectModify);
            this.grdTube.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdTube_ItemValueChanging);
            this.grdTube.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdTube_QueryStarting);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "tube_code";
            this.xEditGridCell17.CellWidth = 47;
            this.xEditGridCell17.Col = 1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "tube_name";
            this.xEditGridCell18.CellWidth = 150;
            this.xEditGridCell18.Col = 2;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "cnt";
            this.xEditGridCell19.CellWidth = 41;
            this.xEditGridCell19.Col = 3;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "print_yn";
            this.xEditGridCell52.CellWidth = 33;
            this.xEditGridCell52.Col = 4;
            this.xEditGridCell52.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            // 
            // pnlPaInfo
            // 
            this.pnlPaInfo.Controls.Add(this.pbxJusa);
            this.pnlPaInfo.Controls.Add(this.btnAllCheck);
            this.pnlPaInfo.Controls.Add(this.cbxActor);
            this.pnlPaInfo.Controls.Add(this.btnCancleLabel);
            this.pnlPaInfo.Controls.Add(this.btnAllUnCheck);
            this.pnlPaInfo.Controls.Add(this.txtBunho);
            this.pnlPaInfo.Controls.Add(this.xLabel2);
            this.pnlPaInfo.Controls.Add(this.xLabel3);
            this.pnlPaInfo.Controls.Add(this.paBox);
            resources.ApplyResources(this.pnlPaInfo, "pnlPaInfo");
            this.pnlPaInfo.DrawBorder = true;
            this.pnlPaInfo.Name = "pnlPaInfo";
            // 
            // pbxJusa
            // 
            this.pbxJusa.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            resources.ApplyResources(this.pbxJusa, "pbxJusa");
            this.pbxJusa.Name = "pbxJusa";
            this.pbxJusa.Protect = false;
            this.pbxJusa.TabStop = false;
            // 
            // btnAllCheck
            // 
            resources.ApplyResources(this.btnAllCheck, "btnAllCheck");
            this.btnAllCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllCheck.Image")));
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // cbxActor
            // 
            this.cbxActor.ExecuteQuery = null;
            resources.ApplyResources(this.cbxActor, "cbxActor");
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxActor.ParamList")));
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxActor.UserSQL = resources.GetString("cbxActor.UserSQL");
            // 
            // btnCancleLabel
            // 
            this.btnCancleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnCancleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancleLabel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancleLabel.Image")));
            resources.ApplyResources(this.btnCancleLabel, "btnCancleLabel");
            this.btnCancleLabel.Name = "btnCancleLabel";
            this.btnCancleLabel.Click += new System.EventHandler(this.btnCancleLabel_Click);
            // 
            // btnAllUnCheck
            // 
            resources.ApplyResources(this.btnAllUnCheck, "btnAllUnCheck");
            this.btnAllUnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllUnCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllUnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllUnCheck.Image")));
            this.btnAllUnCheck.Name = "btnAllUnCheck";
            this.btnAllUnCheck.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnAllUnCheck.Click += new System.EventHandler(this.btnAllUnCheck_Click);
            // 
            // txtBunho
            // 
            resources.ApplyResources(this.txtBunho, "txtBunho");
            this.txtBunho.Name = "txtBunho";
            this.txtBunho.ReadOnly = true;
            this.txtBunho.TabStop = false;
            this.txtBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtBunho_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // paBox
            // 
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdPaList);
            this.pnlLeft.Controls.Add(this.xPanel1);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
            // 
            // grdPaList
            // 
            this.grdPaList.ApplyPaintEventToAllColumn = true;
            this.grdPaList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell64,
            this.xEditGridCell44,
            this.xEditGridCell51,
            this.xEditGridCell21,
            this.xEditGridCell62,
            this.xEditGridCell23,
            this.xEditGridCell24});
            this.grdPaList.ColPerLine = 6;
            this.grdPaList.ColResizable = true;
            this.grdPaList.Cols = 7;
            this.grdPaList.ControlBinding = true;
            resources.ApplyResources(this.grdPaList, "grdPaList");
            this.grdPaList.ExecuteQuery = null;
            this.grdPaList.FixedCols = 1;
            this.grdPaList.FixedRows = 1;
            this.grdPaList.HeaderHeights.Add(27);
            this.grdPaList.Name = "grdPaList";
            this.grdPaList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaList.ParamList")));
            this.grdPaList.RowHeaderVisible = true;
            this.grdPaList.Rows = 2;
            this.grdPaList.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPaList.ToolTipActive = true;
            this.grdPaList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaList_RowFocusChanged);
            this.grdPaList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPaList_GridCellPainting);
            this.grdPaList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaList_QueryStarting);
            this.grdPaList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPaList_QueryEnd);
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "bunho";
            this.xEditGridCell59.CellWidth = 70;
            this.xEditGridCell59.Col = 3;
            this.xEditGridCell59.EnableSort = true;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsReadOnly = true;
            this.xEditGridCell59.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "suname";
            this.xEditGridCell60.Col = 4;
            this.xEditGridCell60.EnableSort = true;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "gwa_name";
            this.xEditGridCell64.CellWidth = 75;
            this.xEditGridCell64.Col = 5;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsReadOnly = true;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "doctor";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "doctor_name";
            this.xEditGridCell51.Col = 6;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "ho_dong";
            this.xEditGridCell21.CellWidth = 46;
            this.xEditGridCell21.Col = 1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "ho_code";
            this.xEditGridCell62.CellWidth = 38;
            this.xEditGridCell62.Col = 2;
            this.xEditGridCell62.EnableSort = true;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "reser_yn";
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
            this.xEditGridCell24.CellName = "emergency_yn";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.txtTimeInterval);
            this.xPanel1.Controls.Add(this.tbxTimer);
            this.xPanel1.Controls.Add(this.cboTime);
            this.xPanel1.Controls.Add(this.xLabel8);
            this.xPanel1.Controls.Add(this.lbTime);
            this.xPanel1.Controls.Add(this.dtpToOrderDate);
            this.xPanel1.Controls.Add(this.dtpFromOrderDate);
            this.xPanel1.Controls.Add(this.rbxJubsu);
            this.xPanel1.Controls.Add(this.cbxBuseo);
            this.xPanel1.Controls.Add(this.cbxReser);
            this.xPanel1.Controls.Add(this.rbxMijubsu);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Controls.Add(this.xLabel7);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
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
            this.cboTime.ExecuteQuery = null;
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.Name = "cboTime";
            this.cboTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTime.ParamList")));
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTime.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
    ")\r\n   AND CODE_TYPE = \'NUR2001U04_TIMER\'\r\n ORDER BY TO_NUMBER(CODE)";
            this.cboTime.SelectionChangeCommitted += new System.EventHandler(this.cboTime_SelectionChangeCommitted);
            // 
            // xLabel8
            // 
            this.xLabel8.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // lbTime
            // 
            this.lbTime.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.lbTime, "lbTime");
            this.lbTime.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lbTime.Name = "lbTime";
            // 
            // dtpToOrderDate
            // 
            this.dtpToOrderDate.IsVietnameseYearType = false;
            resources.ApplyResources(this.dtpToOrderDate, "dtpToOrderDate");
            this.dtpToOrderDate.Name = "dtpToOrderDate";
            this.dtpToOrderDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToOrderDate_DataValidating);
            // 
            // dtpFromOrderDate
            // 
            this.dtpFromOrderDate.IsVietnameseYearType = false;
            resources.ApplyResources(this.dtpFromOrderDate, "dtpFromOrderDate");
            this.dtpFromOrderDate.Name = "dtpFromOrderDate";
            this.dtpFromOrderDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromOrderDate_DataValidating);
            // 
            // rbxJubsu
            // 
            resources.ApplyResources(this.rbxJubsu, "rbxJubsu");
            this.rbxJubsu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rbxJubsu.ImageList = this.ImageList;
            this.rbxJubsu.Name = "rbxJubsu";
            this.rbxJubsu.UseVisualStyleBackColor = false;
            this.rbxJubsu.CheckedChanged += new System.EventHandler(this.rbxJubsu_CheckedChanged);
            // 
            // cbxBuseo
            // 
            this.cbxBuseo.ExecuteQuery = null;
            resources.ApplyResources(this.cbxBuseo, "cbxBuseo");
            this.cbxBuseo.Name = "cbxBuseo";
            this.cbxBuseo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxBuseo.ParamList")));
            this.cbxBuseo.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxBuseo.UserSQL = resources.GetString("cbxBuseo.UserSQL");
            this.cbxBuseo.SelectedIndexChanged += new System.EventHandler(this.cbxBuseo_SelectedIndexChanged);
            this.cbxBuseo.SelectionChangeCommitted += new System.EventHandler(this.cbxBuseo_SelectionChangeCommitted);
            // 
            // cbxReser
            // 
            resources.ApplyResources(this.cbxReser, "cbxReser");
            this.cbxReser.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.DarkBlue);
            this.cbxReser.Name = "cbxReser";
            this.cbxReser.UseVisualStyleBackColor = false;
            this.cbxReser.CheckedChanged += new System.EventHandler(this.cbxReser_CheckedChanged);
            // 
            // rbxMijubsu
            // 
            resources.ApplyResources(this.rbxMijubsu, "rbxMijubsu");
            this.rbxMijubsu.BackColor = System.Drawing.Color.Pink;
            this.rbxMijubsu.Checked = true;
            this.rbxMijubsu.ImageList = this.ImageList;
            this.rbxMijubsu.Name = "rbxMijubsu";
            this.rbxMijubsu.TabStop = true;
            this.rbxMijubsu.UseVisualStyleBackColor = false;
            this.rbxMijubsu.CheckedChanged += new System.EventHandler(this.rbxMijubsu_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.dbxPaComment);
            this.xPanel3.Controls.Add(this.xLabel4);
            this.xPanel3.Controls.Add(this.dbxJu);
            this.xPanel3.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // dbxPaComment
            // 
            resources.ApplyResources(this.dbxPaComment, "dbxPaComment");
            this.dbxPaComment.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.dbxPaComment.Name = "dbxPaComment";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.btnOrderPrint);
            this.xPanel8.Controls.Add(this.btnAllCancelLabel);
            this.xPanel8.Controls.Add(this.btnGumJubsu);
            this.xPanel8.Controls.Add(this.btnUseAlarmChk);
            this.xPanel8.Controls.Add(this.btnUseTimeChk);
            this.xPanel8.Controls.Add(this.btnSpecimenList);
            this.xPanel8.Controls.Add(this.btnPrintSetup);
            this.xPanel8.Controls.Add(this.btnChangeTime);
            this.xPanel8.Controls.Add(this.btnBarcode);
            this.xPanel8.Controls.Add(this.btnList);
            this.xPanel8.Controls.Add(this.btnAllPrintLabel);
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Name = "xPanel8";
            // 
            // btnOrderPrint
            // 
            resources.ApplyResources(this.btnOrderPrint, "btnOrderPrint");
            this.btnOrderPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderPrint.Image")));
            this.btnOrderPrint.Name = "btnOrderPrint";
            this.btnOrderPrint.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnOrderPrint.Click += new System.EventHandler(this.btnOrderPrint_Click);
            // 
            // btnAllCancelLabel
            // 
            this.btnAllCancelLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            resources.ApplyResources(this.btnAllCancelLabel, "btnAllCancelLabel");
            this.btnAllCancelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllCancelLabel.Image = ((System.Drawing.Image)(resources.GetObject("btnAllCancelLabel.Image")));
            this.btnAllCancelLabel.Name = "btnAllCancelLabel";
            this.btnAllCancelLabel.Click += new System.EventHandler(this.btnAllCancelLabel_Click);
            // 
            // btnGumJubsu
            // 
            this.btnGumJubsu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            resources.ApplyResources(this.btnGumJubsu, "btnGumJubsu");
            this.btnGumJubsu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGumJubsu.Image = ((System.Drawing.Image)(resources.GetObject("btnGumJubsu.Image")));
            this.btnGumJubsu.Name = "btnGumJubsu";
            this.btnGumJubsu.Click += new System.EventHandler(this.btnGumJubsu_Click);
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
            // btnSpecimenList
            // 
            this.btnSpecimenList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            resources.ApplyResources(this.btnSpecimenList, "btnSpecimenList");
            this.btnSpecimenList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSpecimenList.Image = ((System.Drawing.Image)(resources.GetObject("btnSpecimenList.Image")));
            this.btnSpecimenList.Name = "btnSpecimenList";
            this.btnSpecimenList.Click += new System.EventHandler(this.btnSpecimenList_Click);
            // 
            // btnPrintSetup
            // 
            this.btnPrintSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            resources.ApplyResources(this.btnPrintSetup, "btnPrintSetup");
            this.btnPrintSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSetup.Image")));
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // btnChangeTime
            // 
            this.btnChangeTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            resources.ApplyResources(this.btnChangeTime, "btnChangeTime");
            this.btnChangeTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChangeTime.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeTime.Image")));
            this.btnChangeTime.Name = "btnChangeTime";
            this.btnChangeTime.Click += new System.EventHandler(this.btnChangeTime_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            resources.ApplyResources(this.btnBarcode, "btnBarcode");
            this.btnBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcode.Image")));
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // btnAllPrintLabel
            // 
            this.btnAllPrintLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            resources.ApplyResources(this.btnAllPrintLabel, "btnAllPrintLabel");
            this.btnAllPrintLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllPrintLabel.Image = ((System.Drawing.Image)(resources.GetObject("btnAllPrintLabel.Image")));
            this.btnAllPrintLabel.Name = "btnAllPrintLabel";
            this.btnAllPrintLabel.Click += new System.EventHandler(this.btnAllPrintLabel_Click);
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
            this.multiLayoutItem37,
            this.multiLayoutItem42,
            this.multiLayoutItem43});
            this.mlayConstantInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayConstantInfo.ParamList")));
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "code";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "code_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "code_value";
            // 
            // layOrderPrint
            // 
            this.layOrderPrint.ExecuteQuery = null;
            this.layOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52});
            this.layOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderPrint.ParamList")));
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "cnt";
            this.multiLayoutItem44.IsUpdItem = true;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "order_date";
            this.multiLayoutItem45.IsUpdItem = true;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "order_time";
            this.multiLayoutItem46.IsUpdItem = true;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "bunho";
            this.multiLayoutItem47.IsUpdItem = true;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "suname";
            this.multiLayoutItem48.IsUpdItem = true;
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "suname2";
            this.multiLayoutItem49.IsUpdItem = true;
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "hangmog_code";
            this.multiLayoutItem50.IsUpdItem = true;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "hangmog_name";
            this.multiLayoutItem51.IsUpdItem = true;
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "tube_name";
            this.multiLayoutItem52.IsUpdItem = true;
            // 
            // CPL2010U01
            // 
            this.Controls.Add(this.xPanel2);
            this.Name = "CPL2010U01";
            resources.ApplyResources(this, "$this");
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CPL2010U01_Closing);
            this.UserChanged += new System.EventHandler(this.CPL2010U01_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CPL2010U01_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.layTube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layUpdateTube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySpecimenSer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGumsaMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp2)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecimen)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTube)).EndInit();
            this.pnlPaInfo.ResumeLayout(false);
            this.pnlPaInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxJusa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region Screen 변수

        private int QueryTime;
        private int TimeVal;

        // 自動照会使用可否フラグ
        private string useTimeChkYN = "Y";

        // 受付チェックボックス一括適用フラグ
        private string chkAllJubsuYN = "Y";


        // 患者有AlarmファイルPATH
        private string alarmFilePath_CPL = "";
        private string alarmFilePath_CPL_EM = "";
        private string useAlarmChkYN = "";

        #endregion
	
		#region OnLoad

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(this.Width, rc.Height - 105);

            this.grdSpecimen.SavePerformer = new XSavePerformer(this);

            this.dtpFromOrderDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpToOrderDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpFromOrderDate.Focus();

            if (this.cbxBuseo.ComboItems.Count > 0)
            {
                this.cbxBuseo.SelectedIndex = 0;
                this.cbxBuseo.AcceptData();
            }

			if (this.OpenParam != null ) 
			{
                //this.fbxHoDong.SetEditValue(this.OpenParam["hodong"].ToString());
                //this.fbxHoDong.AcceptData();
                this.cbxBuseo.SetEditValue(this.OpenParam["hodong"].ToString());
                this.cbxBuseo.AcceptData();
                this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());

			}

            this.btnList.PerformClick(FunctionType.Query);

            // タイマー設定
            this.setTimer();

            PostCallHelper.PostCall(new PostMethod(PostLoad));
		}
		#endregion

        private void PostLoad()
        {
            string btn_autoQuery_yn = null;
            string btn_autoAlarm_yn = null;

            // 注射画面コントロールデータ照会
            this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                                                 FROM CPL0109
                                                WHERE HOSP_CODE = :f_hosp_code
                                                  AND CODE_TYPE = 'CPL_CONSTANT'
                                                ORDER BY CODE";

            this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (this.mlayConstantInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoQuery_yn")) btn_autoQuery_yn = this.mlayConstantInfo.GetItemString(i, "code_value");
                }

                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoAlarm_yn"))
                    {
                        btn_autoAlarm_yn = mlayConstantInfo.GetItemString(i, "code_value");

                        // AlarmファイルPATH取得
                        this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                                                 FROM CPL0109
                                                WHERE HOSP_CODE = 'K01'
                                                  AND CODE_TYPE = 'CPL_ALARM'
                                                ORDER BY CODE";

                        this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                        if (this.mlayConstantInfo.QueryLayout(true))
                        {
                            for (int k = 0; k < this.mlayConstantInfo.RowCount; k++)
                            {
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("CPL")) this.alarmFilePath_CPL = this.mlayConstantInfo.GetItemString(k, "code_value");
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("CPL_EM")) this.alarmFilePath_CPL_EM = this.mlayConstantInfo.GetItemString(k, "code_value");
                            }
                        }
                    }
                }
            }

            // 自動照会
            if (btn_autoQuery_yn.Equals("Y"))
            {
                this.useTimeChkYN = "Y";
                this.btnUseTimeChk.ImageIndex = 1;

                this.timer1.Start();
                this.cboTime.Enabled = true;
            }
            else
            {
                this.useTimeChkYN = "N";
                this.btnUseTimeChk.ImageIndex = 0;

                this.cboTime.Enabled = false;
                this.timer1.Stop();
            }

            // 患者有Alarm
            if (btn_autoAlarm_yn.Equals("Y"))
            {
                this.useAlarmChkYN = "Y";
                this.btnUseAlarmChk.ImageIndex = 1;
            }
            else
            {
                this.useAlarmChkYN = "N";
                this.btnUseAlarmChk.ImageIndex = 0;
            }

            // 実施者に 現在ログインしている IDを セットする｡
            this.cbxActor.SetDataValue(UserInfo.UserID);
        }

		#region fields
        //private string mQryFlag = "1"; // base
		private int mSeconds = 0;      // 로보 바코드 일괄 출력시 2초당 한번씩 출력하기 위해
		#endregion

        #region  병동코드 벨리데이션
        private void vsvHodong_PreServiceCall(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			//this.vsvHodong.SetBindVarValue("f_code",this.fbxHoDong.GetDataValue());
            this.vsvHodong.SetBindVarValue("f_code", this.cbxBuseo.GetDataValue());
		}
		#endregion	

        #region grdPa_GridCellPainting
        private void grdPa_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if ( this.grdPa.GetItemString(e.RowNumber,"jubsu_date").Length > 0 )
				e.BackColor = Color.White;
			else
				e.BackColor = Color.LightYellow;
		}
		#endregion

        #region [MakeJubsu チェック入力]
        private void MakeJubsu()
		{
			for( int i = 0 ; i < this.grdSpecimen.RowCount; i++ )
			{
				this.grdSpecimen.SetItemValue(i,"jubsu_flag","Y");
			}
		}
		#endregion

        #region [MakeMiJubsu チェック解除 ]
        private void MakeMiJubsu()
        {
            for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            {
                this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
            }
        }
        #endregion

		#region dtpFromOrderDate_DataValidating
		private void dtpFromOrderDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            //if (this.cbxBuseo.GetDataValue().Length == 0)
            //{
                this.grdPaList.QueryLayout(false);
            //}
		}
		#endregion

		#region dtpToOrderDate_DataValidating
		private void dtpToOrderDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            //if (this.cbxBuseo.GetDataValue().Length == 0)
            //{
                this.grdPaList.QueryLayout(false);
            //}
		}
		#endregion

		#region	grdPa_RowFocusChanged
		private void grdPa_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            //this.txtBunho.Text = "";
            //this.txtBunho.Text = this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "bunho");
            //this.paBox.SetPatientID(this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "bunho"));

            string jubsuja = this.grdPa.GetItemString(e.CurrentRow, "jubsuja_name");
            if (jubsuja.Equals(""))
                // 実施者に 現在ログインしている IDを セットする｡
                this.cbxActor.SetDataValue(UserInfo.UserID);
            else
                // 採血者をセットする。
                this.cbxActor.Text = this.grdPa.GetItemString(e.CurrentRow, "jubsuja_name");

            this.grdSpecimen.QueryLayout(false);

            if (this.rbxJubsu.Checked == true)
            {
                this.MakeJubsu();
                this.grdTube.SetBindVarValue("f_jubsu_date", this.grdSpecimen.GetItemString(0, "jubsu_date"));
                this.grdTube.SetBindVarValue("f_jubsu_time", this.grdSpecimen.GetItemString(0, "jubsu_time"));
                this.grdTube.SetBindVarValue("f_reser_date", this.grdPa.GetItemString(grdPa.CurrentRowNumber, "reser_date"));

                this.layTube.SetBindVarValue("f_jubsu_date", this.grdSpecimen.GetItemString(0, "jubsu_date"));
                this.layTube.SetBindVarValue("f_jubsu_time", this.grdSpecimen.GetItemString(0, "jubsu_time"));
                this.layTube.SetBindVarValue("f_reser_date", this.grdPa.GetItemString(grdPa.CurrentRowNumber, "reser_date"));

                this.grdTube.QueryLayout(false);
            }
		}
		#endregion

		#region 바코드출력 클릭
		private void btnBarcode_Click(object sender, System.EventArgs e)
		{
            //this.SetPrintBacode();
            if (rbxJubsu.Checked)
            {
                DataRow[] dtRowData = this.grdSpecimen.LayoutTable.Select("print_yn =" + "'Y'");

                if (dtRowData.Length <= 0)
                {
                    string msg = Resources.MSG001_MSG;
                    string mcap = Resources.MSG001_CAP;
                    XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                    return;
                }
                SetPrintBacode();
            }
            else
            {
                return;
            }
		}
		#endregion

		#region 바코드 프린터 설정
		private void SetPrint()
		{
			//Open the PrintDialog
			 this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

            if (printSetName == "")
            {
                this.printDialog1.Document = this.printDocument1;
            }
            else
            {
                this.printDialog1.PrinterSettings.PrinterName = printSetName;
            }
			DialogResult dr = this.printDialog1.ShowDialog();
			if(dr == DialogResult.OK)
			{
				//Get the Copy times
				int nCopy = this.printDocument1.PrinterSettings.Copies;
				//Get the number of Start Page
				int sPage = this.printDocument1.PrinterSettings.FromPage;
				//Get the number of End Page
				int ePage = this.printDocument1.PrinterSettings.ToPage;
				//Get the printer name
                string PrinterName = this.printDialog1.PrinterSettings.PrinterName;

                string cmdText = @" DECLARE 
    
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
                bc.Add("f_ip_addr", Service.ClientIP.ToString());

                if (!Service.ExecuteNonQuery(cmdText, bc))
                {
                    XMessageBox.Show(Resources.MSG002_MSG + Service.ErrFullMsg, Resources.MSG002_CAP, MessageBoxIcon.Warning);
                }
			}
		}
		#endregion


		#region 프린터 설정 과 바코드 출력 재출력시
		private void SetPrintBacode()
		{
			//바코드프린터명 가져오기
            this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

			if ( this.grdSpecimen.RowCount < 1 ) return;

	//		dwBarcode.Reset();
			layBarcode.Reset();

			ArrayList SpecimenSerArr = new ArrayList();
            //string pre_specimen_ser = "";

			for (int i=0; i < grdSpecimen.RowCount; i++)
			{
                if (grdSpecimen.GetItemString(i, "print_yn") == "Y")
                {
                    if (!SpecimenSerArr.Contains(grdSpecimen.GetItemString(i, "specimen_ser")))
                    {
                        SpecimenSerArr.Add(grdSpecimen.GetItemString(i, "specimen_ser"));
                    }
                }
			}

			if ( SpecimenSerArr.Count > 0 )
			{
                SpecimenSerArr.Sort();

				for ( int i=0; i < SpecimenSerArr.Count; i++ )
                {
                    //소스상으로는 제대로 보여지나 프린트시 순서 바뀌는 경우가 있음.
                    //프린터 스풀의 문제인건지??
					string specimen_ser = SpecimenSerArr[i].ToString();
                    this.layBarcodeTemp2.SetBindVarValue("f_specimen_ser", specimen_ser);
                    this.layBarcodeTemp2.QueryLayout(true);

					if (layBarcode2.RowCount > 0)
					{
						//바코드를 한껀씩 보냄 여러껀 보낼때 밀림

                        for (int j = 0; j < this.layBarcode2.RowCount; j++)
						{
        //                    dwBarcode.Reset();
                            layBarcodeOne.Reset();

							int rowNum = layBarcodeOne.InsertRow(0);
                            layBarcodeOne.SetItemValue(rowNum, "jundal_gubun", this.layBarcode2.GetItemString(j, "jundal_gubun"));
                            layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcode2.GetItemString(j, "jundal_gubun_name"));
                            layBarcodeOne.SetItemValue(rowNum, "specimen_code", this.layBarcode2.GetItemString(j, "specimen_code"));
                            layBarcodeOne.SetItemValue(rowNum, "specimen_name", this.layBarcode2.GetItemString(j, "specimen_name"));
                            layBarcodeOne.SetItemValue(rowNum, "tube_code", this.layBarcode2.GetItemString(j, "tube_code"));
                            layBarcodeOne.SetItemValue(rowNum, "tube_name", this.layBarcode2.GetItemString(j, "tube_name"));
                            layBarcodeOne.SetItemValue(rowNum, "specimen_ser", this.layBarcode2.GetItemString(j, "specimen_ser"));
                            layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode2.GetItemString(j, "bunho"));
                            layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode2.GetItemString(j, "suname"));
                            layBarcodeOne.SetItemValue(rowNum, "gwa_name", this.layBarcode2.GetItemString(j, "gwa_name"));
                            layBarcodeOne.SetItemValue(rowNum, "danger_yn", this.layBarcode2.GetItemString(j, "danger_yn"));
                            layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcode2.GetItemString(j, "specimen_ser_ba"));
                            layBarcodeOne.SetItemValue(rowNum, "jangbi_code", this.layBarcode2.GetItemString(j, "jangbi_code"));
                            layBarcodeOne.SetItemValue(rowNum, "jangbi_name", this.layBarcode2.GetItemString(j, "jangbi_name"));
                            layBarcodeOne.SetItemValue(rowNum, "in_out_gubun", this.layBarcode2.GetItemString(j, "in_out_gubun"));
                            layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re", this.layBarcode2.GetItemString(j, "gumsa_name_re"));
                            layBarcodeOne.SetItemValue(rowNum, "tube_max_amt", this.layBarcode2.GetItemString(j, "tube_max_amt"));
                            layBarcodeOne.SetItemValue(rowNum, "tube_numbering", this.layBarcode2.GetItemString(j, "tube_numbering"));	
					
			//				dwBarcode.FillData(layBarcodeOne.LayoutTable);
			//				dwBarcode.PrintProperties.PrinterName = printSetName;
							try
							{
			//					dwBarcode.Print();
							}
							catch{}
                         }
                        //foreach (DataRow row in this.layBarcode2.LayoutTable.Rows)
                        //{
                        //    dwBarcode.Reset();
                        //    layBarcodeOne.Reset();
                        //    this.layBarcodeOne.LayoutTable.ImportRow(row);

                        //    dwBarcode.FillData(layBarcodeOne.LayoutTable);
                        //    dwBarcode.PrintProperties.PrinterName = printSetName;
                        //    try
                        //    {
                        //        dwBarcode.Print();
                        //    }
                        //    catch { }
                        //}
						
					}
				}
			}
			else
			{
                string specimen_ser = grdSpecimen.GetItemString(grdSpecimen.CurrentRowNumber, "specimen_ser");
                this.layBarcodeTemp2.SetBindVarValue("f_specimen_ser", specimen_ser);
                this.layBarcodeTemp2.QueryLayout(true);

				if (layBarcode2.RowCount > 0)
				{
					//바코드를 한껀씩 보냄 여러껀 보낼때 밀림
					for (int j=0 ; j<this.layBarcode2.RowCount; j++)
					{
			//			dwBarcode.Reset();
						layBarcodeOne.Reset();

                        int rowNum = layBarcodeOne.InsertRow(0);
                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun", this.layBarcode2.GetItemString(j, "jundal_gubun"));
                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcode2.GetItemString(j, "jundal_gubun_name"));
                        layBarcodeOne.SetItemValue(rowNum, "specimen_code", this.layBarcode2.GetItemString(j, "specimen_code"));
                        layBarcodeOne.SetItemValue(rowNum, "specimen_name", this.layBarcode2.GetItemString(j, "specimen_name"));
                        layBarcodeOne.SetItemValue(rowNum, "tube_code", this.layBarcode2.GetItemString(j, "tube_code"));
                        layBarcodeOne.SetItemValue(rowNum, "tube_name", this.layBarcode2.GetItemString(j, "tube_name"));
                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser", this.layBarcode2.GetItemString(j, "specimen_ser"));
                        layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode2.GetItemString(j, "bunho"));
                        layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode2.GetItemString(j, "suname"));
                        layBarcodeOne.SetItemValue(rowNum, "gwa_name", this.layBarcode2.GetItemString(j, "gwa_name"));
                        layBarcodeOne.SetItemValue(rowNum, "danger_yn", this.layBarcode2.GetItemString(j, "danger_yn"));
                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcode2.GetItemString(j, "specimen_ser_ba"));
                        layBarcodeOne.SetItemValue(rowNum, "jangbi_code", this.layBarcode2.GetItemString(j, "jangbi_code"));
                        layBarcodeOne.SetItemValue(rowNum, "jangbi_name", this.layBarcode2.GetItemString(j, "jangbi_name"));
                        layBarcodeOne.SetItemValue(rowNum, "in_out_gubun", this.layBarcode2.GetItemString(j, "in_out_gubun"));
                        layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re", this.layBarcode2.GetItemString(j, "gumsa_name_re"));
                        layBarcodeOne.SetItemValue(rowNum, "tube_max_amt", this.layBarcode2.GetItemString(j, "tube_max_amt"));
                        layBarcodeOne.SetItemValue(rowNum, "tube_numbering", this.layBarcode2.GetItemString(j, "tube_numbering"));	
					
			//			dwBarcode.FillData(layBarcodeOne.LayoutTable);
			//			dwBarcode.PrintProperties.PrinterName = printSetName;
						try
						{
			//				dwBarcode.Print();
						}
						catch{}
					}

                    //foreach (DataRow row in this.layBarcode2.LayoutTable.Rows)
                    //{
                    //    dwBarcode.Reset();
                    //    layBarcodeOne.Reset();
                    //    this.layBarcodeOne.LayoutTable.ImportRow(row);

                    //    dwBarcode.FillData(layBarcodeOne.LayoutTable);
                    //    dwBarcode.PrintProperties.PrinterName = printSetName;
                    //    try
                    //    {
                    //        dwBarcode.Print();
                    //    }
                    //    catch { }
                    //}
				}
			}
		}
		#endregion

		#region 프린터 설정 과 바코드 출력 저장 후 출력시
		private void SetPrintBacode2()
		{
			//바코드프린터명 가져오기
            this.layPrintName.QueryLayout();

			string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

			//if ( this.grdSpecimen.RowCount < 1 ) return;

	//		dwBarcode.Reset();
			layBarcode.Reset();

			this.layBarcodeTemp.SetBindVarValue("f_jubsu_date", o_jubsu_date);
            //this.layBarcodeTemp.SetBindVarValue("f_bunho", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "bunho"));
            this.layBarcodeTemp.SetBindVarValue("f_bunho", this.txtBunho.GetDataValue());

            this.layBarcodeTemp.QueryLayout(true);
			
            if (layBarcode.RowCount > 0)
			{
				//한껀씩 출력

				for (int j=0 ; j<this.layBarcode.RowCount; j++)
				{
		//			dwBarcode.Reset();
					layBarcodeOne.Reset();

					int rowNum = layBarcodeOne.InsertRow(0);
                    layBarcodeOne.SetItemValue(rowNum, "jundal_gubun", this.layBarcode.GetItemString(j, "jundal_gubun"));
                    layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcode.GetItemString(j, "jundal_gubun_name"));
                    layBarcodeOne.SetItemValue(rowNum, "specimen_code", this.layBarcode.GetItemString(j, "specimen_code"));
                    layBarcodeOne.SetItemValue(rowNum, "specimen_name", this.layBarcode.GetItemString(j, "specimen_name"));
                    layBarcodeOne.SetItemValue(rowNum, "tube_code", this.layBarcode.GetItemString(j, "tube_code"));
                    layBarcodeOne.SetItemValue(rowNum, "tube_name", this.layBarcode.GetItemString(j, "tube_name"));
                    layBarcodeOne.SetItemValue(rowNum, "specimen_ser", this.layBarcode.GetItemString(j, "specimen_ser"));
                    layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode.GetItemString(j, "bunho"));
                    layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode.GetItemString(j, "suname"));
                    layBarcodeOne.SetItemValue(rowNum, "gwa_name", this.layBarcode.GetItemString(j, "gwa_name"));
                    layBarcodeOne.SetItemValue(rowNum, "danger_yn", this.layBarcode.GetItemString(j, "danger_yn"));
                    layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcode.GetItemString(j, "specimen_ser_ba"));
                    layBarcodeOne.SetItemValue(rowNum, "jangbi_code", this.layBarcode.GetItemString(j, "jangbi_code"));
                    layBarcodeOne.SetItemValue(rowNum, "jangbi_name", this.layBarcode.GetItemString(j, "jangbi_name"));
                    layBarcodeOne.SetItemValue(rowNum, "in_out_gubun", this.layBarcode.GetItemString(j, "in_out_gubun"));
                    layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re", this.layBarcode.GetItemString(j, "gumsa_name_re"));
                    layBarcodeOne.SetItemValue(rowNum, "tube_max_amt", this.layBarcode.GetItemString(j, "tube_max_amt"));
                    layBarcodeOne.SetItemValue(rowNum, "tube_numbering", this.layBarcode.GetItemString(j, "tube_numbering"));	
				
		//			dwBarcode.FillData(layBarcodeOne.LayoutTable);
		//			dwBarcode.PrintProperties.PrinterName = printSetName;
					try
					{
		//				dwBarcode.Print();
					}
					catch{}
				}

                //foreach (DataRow row in this.layBarcode.LayoutTable.Rows)
                //{
                //    dwBarcode.Reset();
                //    layBarcodeOne.Reset();
                //    this.layBarcodeOne.LayoutTable.ImportRow(row);

                //    dwBarcode.FillData(layBarcodeOne.LayoutTable);
                //    dwBarcode.PrintProperties.PrinterName = printSetName;
                //    try
                //    {
                //        dwBarcode.Print();
                //    }
                //    catch { }
                //}
			}
			
		}
		#endregion

		#region paBox_PatientSelected
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
            this.txtBunho.SetDataValue(this.paBox.BunHo);
            //QueryGrdPa2();
		}
		#endregion

		#region btnChangeTime_Click
		private void btnChangeTime_Click(object sender, System.EventArgs e)
		{
			if ( this.grdSpecimen.RowCount > 0 )
			{
				CHANGETIME dlg = new CHANGETIME(this.grdPa.GetItemString(this.grdPa.CurrentRowNumber,"order_date"),
					this.grdPa.GetItemString(this.grdPa.CurrentRowNumber,"bunho"),
					this.grdPa.GetItemString(this.grdPa.CurrentRowNumber,"gwa"),
					//this.grdPa.GetItemString(this.grdPa.CurrentRowNumber,"gubun"),
					this.grdPa.GetItemString(this.grdPa.CurrentRowNumber,"doctor")
					//this.grdPa.GetItemString(this.grdPa.CurrentRowNumber,"in_out_gubun")
                    );
				dlg.ShowDialog();
				if ( dlg.DialogResult == DialogResult.OK)
				{
					this.grdSpecimen.QueryLayout(false);
				}
			}
			else
			{
				string msg = Resources.MSG003_MSG;
				XMessageBox.Show(msg);
			}
		}
		#endregion

		#region paBox_PatientSelectionFailed
		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			this.txtBunho.SetDataValue(this.paBox.BunHo);
            this.paBox.Reset();
		}
		#endregion

		#region 버튼리스트 작업 수행 전
		private string mReserDate;
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch ( e.Func )
			{
				case FunctionType.Update:
					if ( this.grdSpecimen.RowCount == 0 )
					{
						string msg = Resources.MSG004_MSG;
						XMessageBox.Show(msg);
						e.IsBaseCall = false;
                        e.IsSuccess = false;
                        return;
					}
					else
					{
                        if (this.rbxMijubsu.Checked && this.cbxActor.GetDataValue().Length == 0)
						{
							string msg = Resources.MSG005_MSG;
							XMessageBox.Show(msg);
                            this.cbxActor.Focus();
							e.IsBaseCall = false;
                            e.IsSuccess = false;
                            return;
						}
					}
					mReserDate = grdPa.GetItemString(grdPa.CurrentRowNumber,"reser_date");
                    e.IsBaseCall = false;

                    if (GrdSpecimenSave())
                    {
                        e.IsSuccess = true;
                        this.PrintLabel();

                        txtBunho.Clear();
                        paBox.Reset();

                        grdTube.Reset();

                        this.grdPaList.QueryLayout(false);
                    }
                    else
                        e.IsSuccess = false;              

					break;

				case FunctionType.Query:
					//if ( this.fbxHoDong.GetDataValue().Length == 0 )
                    if (this.cbxBuseo.GetDataValue().Length == 0)
					{
						e.IsBaseCall = false;
						string msg = Resources.MSG006_MSG;
						XMessageBox.Show(msg);
                        this.cbxBuseo.Focus();
					}
					
					e.IsBaseCall = false;
                    e.IsSuccess = true;

                    this.grdPaList.QueryLayout(false);
					break;
				default:
					break;
			}
		}

        private bool GrdSpecimenSave()
        {
            jubsu_cnt = 0;
            cancel_cnt = 0;
            o_jubsu_date = "";
            o_jubsu_time = "";
            o_flag = "";
            //t_jubsu_gubun = "";

            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            this.btnList.Enabled = false;
            try
            {
                Service.BeginTransaction();

                if (this.grdSpecimen.SaveLayout())
                {
                    if (jubsu_cnt > 0)
                    {
                        //inputList.Add(this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "order_date"));
                        //inputList.Add(this.txtBunho.GetDataValue());
                        //inputList.Add(this.dbxJubsujaName.GetDataValue());
                        //inputList.Add("Y");
                        ////inputList.Add(t_jubsu_gubun);// null
                        //inputList.Add(DBNull.Value);// 

                        inputList.Add("I_ORDER_DATE", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "order_date"));
                        inputList.Add("I_BUNHO", this.txtBunho.GetDataValue());
                        //inputList.Add("I_JUBSUJA", this.cbxActor.GetDataValue());
                        inputList.Add("I_JUBSUJA", this.cbxActor.GetDataValue());
                        inputList.Add("I_JUBSU_FLAG", "Y");
                        inputList.Add("I_JUBSU_GUBUN", DBNull.Value);// null
                        inputList.Add("I_JUBSU_DATE", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jubsu_date"));
                        inputList.Add("I_JUBSU_TIME", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jubsu_time"));

                        if (Service.ExecuteProcedure("PR_CPL_MAKE_SPECIMEN_SER", inputList, outputList))
                        {
                            if (outputList.Count > 0)
                            {
                                if (outputList["IO_FLAG"].ToString() == "N")
                                {
                                    //mErrMsg = "患者情報がありません。オーダを確認してください。";
                                    mErrMsg = Resources.MSG001_ERR_MSG;
                                    throw new Exception();
                                }
                            }

                            o_jubsu_date = this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jubsu_date");
                            o_jubsu_time = this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jubsu_time");
                            //o_flag = outputList[2].ToString();
                        }
                        else
                            throw new Exception();
                    }
                }
                else
                    throw new Exception();

                Service.CommitTransaction();
            }
            catch
            {
                Service.RollbackTransaction();
                XMessageBox.Show(Resources.MSG002_ERR_MSG + mErrMsg, Resources.MSG002_ERR_CAP, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //this.SetVisibleStatusBar(false);
                this.btnList.Enabled = true;
            }

            return true;
        }
		#endregion

		#region 버튼리스트 작업 수행 후
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch ( e.Func )
			{
				case FunctionType.Update:
					if ( e.IsSuccess == true )
					{
                        this.grdPaList.QueryLayout(false);

                        if (o_flag != "N")
						{
							this.grdTube.SetBindVarValue("f_jubsu_date", o_jubsu_date);
                            this.grdTube.SetBindVarValue("f_jubsu_time", o_jubsu_time);
                            this.grdTube.SetBindVarValue("f_reser_date", mReserDate);

                            this.layTube.SetBindVarValue("f_jubsu_date", o_jubsu_date);
                            this.layTube.SetBindVarValue("f_jubsu_time", o_jubsu_time);
                            this.layTube.SetBindVarValue("f_reser_date", mReserDate);

                            this.grdTube.QueryLayout(false);
						}

						// 바코드 출력
						if (rbxMijubsu.Checked)
						{
							SetPrintBacode2();
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 미채혈 라디오 클릭
		private void rbxMijubsu_CheckedChanged(object sender, System.EventArgs e)
		{
			//this.dsvPa.SetInValue("jubsu_yn","N");
            if (this.rbxMijubsu.Checked == true)
            {
                this.rbxMijubsu.ImageIndex = 1;
                this.rbxJubsu.ImageIndex = 0;
                this.grdTube.Reset();

                this.xEditGridCell22.IsReadOnly = false;  //受付日付
                this.xEditGridCell54.IsReadOnly = false;  //受付時間

                this.cbxActor.Enabled = true;

                this.btnAllPrintLabel.Visible = true;
                this.btnAllCancelLabel.Visible = false;

                this.rbxMijubsu.BackColor = Color.Pink;
                this.rbxJubsu.BackColor = Color.WhiteSmoke;

                this.grdPaList.QueryLayout(false);
            }
            else 
            {
                this.xEditGridCell22.IsReadOnly = true;  //受付日付
                this.xEditGridCell54.IsReadOnly = true;  //受付時間

                this.rbxMijubsu.BackColor = Color.WhiteSmoke;
                this.rbxJubsu.BackColor = Color.Pink;
            }
		}
		#endregion

		#region 채혈 라디오 클릭
		private void rbxJubsu_CheckedChanged(object sender, System.EventArgs e)
		{
			//this.dsvPa.SetInValue("jubsu_yn","Y"); 쿼리 스타트 이벤트에서 넣어주고 있음
			if ( this.rbxJubsu.Checked == true )
			{
				this.rbxMijubsu.ImageIndex = 0;
                this.rbxJubsu.ImageIndex = 1;

                this.cbxActor.Enabled = false;

                this.btnAllCancelLabel.Visible = true;
                this.btnAllPrintLabel.Visible = false;

                this.grdPaList.QueryLayout(false);
			}
        }
        #endregion

        #region [btnAllPrintLabel_Click ラベル一括発行]
        private void btnAllPrintLabel_Click(object sender, System.EventArgs e)
		{
            // 採血済ＴＡＢは実施無
            if (this.rbxJubsu.Checked) return;

            if (this.grdPaList.RowCount < 1) return;

            if (this.cbxActor.GetDataValue().Length > 0)
			{
                if (XMessageBox.Show(Resources.MSG007_MSG, Resources.MSG007_CAP, MessageBoxButtons.YesNo) == DialogResult.No) return;

                this.InitStatusBar(this.grdPaList.RowCount);
                this.SetVisibleStatusBar(true);

                for (int k = 0; k < this.grdPaList.RowCount; k++)
                {
                    this.SetStatusBar(k + 1);

                    this.grdPaList.SetFocusToItem(k, 1);

                    //this.grdTube.Reset();

                    for (int i = 0; i < this.grdPa.RowCount; i++)
                    {
                        //접수
                        this.grdPa.SetFocusToItem(i, 1);
                        this.MakeJubsu();

                        this.GrdSpecimenSave();

                        if (!TypeCheck.IsNull(Service.ErrFullMsg) || !TypeCheck.IsNull(mErrMsg))
                        {
                            XMessageBox.Show(i.ToString() + "[" + Service.ErrFullMsg + ", " + mErrMsg + "]");
                            break;
                        }

                        ////용기
                        //mReserDate = grdPa.GetItemString(grdPa.CurrentRowNumber, "reser_date");

                        //this.grdTube.SetBindVarValue("f_jubsu_date", this.o_jubsu_date);
                        //this.grdTube.SetBindVarValue("f_jubsu_time", this.o_jubsu_time);
                        //this.grdTube.SetBindVarValue("f_reser_date", mReserDate);

                        //this.layTube.SetBindVarValue("f_jubsu_date", this.o_jubsu_date);
                        //this.layTube.SetBindVarValue("f_jubsu_time", this.o_jubsu_time);
                        //this.layTube.SetBindVarValue("f_reser_date", mReserDate);

                        //this.grdTube.QueryLayout(false);


                        // 바코드 출력
                        this.PrintLabel();

                        // 바코드 일괄 출력시 2초당 한번씩 출력하기 위해
                        //mSeconds = 0;
                        //while (mSeconds < 1000000000)
                        //{
                        //    if (mSeconds % 100000000 == 0)
                        //    {
                        //        int rowno = grdPa.CurrentRowNumber + 1;
                        //        this.SetMsg(rowno.ToString() + ". " + grdPa.GetItemString(grdPa.CurrentRowNumber, "suname") + "[" + grdPa.GetItemString(grdPa.CurrentRowNumber, "bunho") + "] : " + mSeconds.ToString().Substring(0, 1));
                        //    }
                        //    mSeconds++;
                        //}
                    }
                }

                this.SetVisibleStatusBar(false);

                // 再照会
                this.grdPaList.QueryLayout(false);
			}
			else
			{
				string msg = (Resources.MSG005_MSG);
				XMessageBox.Show(msg);
                this.cbxActor.Focus();
			}
		}
		#endregion

        #region [btnAllCancelLabel_Click ラベル一括取消]
        private void btnAllCancelLabel_Click(object sender, EventArgs e)
        {
            // 未採血ＴＡＢは実施無
            if (this.rbxMijubsu.Checked) return;

            if (this.grdPaList.RowCount < 1) return;

            if (XMessageBox.Show(Resources.MSG008_MSG, Resources.MSG008_CAP, MessageBoxButtons.YesNo) == DialogResult.No) return;

            this.InitStatusBar(this.grdPaList.RowCount);
            this.SetVisibleStatusBar(true);

            for (int k = 0; k < this.grdPaList.RowCount; k++)
            {
                this.SetStatusBar(k + 1);

                this.grdPaList.SetFocusToItem(k, 1);

                for (int i = 0; i < this.grdPa.RowCount; i++)
                {
                    // チェック解除
                    this.grdPa.SetFocusToItem(i, 1);
                    this.MakeMiJubsu();

                    this.GrdSpecimenSave();

                    if (!TypeCheck.IsNull(Service.ErrFullMsg) || !TypeCheck.IsNull(mErrMsg))
                    {
                        XMessageBox.Show(i.ToString() + "[" + Service.ErrFullMsg + ", " + mErrMsg + "]");
                        break;
                    }
                }
            }

            this.SetVisibleStatusBar(false);

            // 再照会
            this.grdPaList.QueryLayout(false);
        }
        #endregion

        #region [PrintLabel 바코드프린터]
        private void PrintLabel()
        {
            //바코드프린터명 가져오기
            this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

            if (this.grdSpecimen.RowCount < 1) return;

            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

    //        dwBarcode.Reset();
            layBarcode.Reset();
            this.layBarcodeTemp.SetBindVarValue("f_jubsu_date", this.o_jubsu_date);
            this.layBarcodeTemp.SetBindVarValue("f_bunho", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "bunho"));
            this.layBarcodeTemp.QueryLayout(true);
            if (layBarcode.RowCount > 0)
            {
                for (int j = 0; j < this.layBarcode.RowCount; j++)
                {
                    //this.SetStatusBar(j);
      //              dwBarcode.Reset();
                    layBarcodeOne.Reset();

                    int rowNum = layBarcodeOne.InsertRow(0);
                    layBarcodeOne.SetItemValue(rowNum, "jundal_gubun", this.layBarcode.GetItemString(j, "jundal_gubun"));
                    layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcode.GetItemString(j, "jundal_gubun_name"));
                    layBarcodeOne.SetItemValue(rowNum, "specimen_code", this.layBarcode.GetItemString(j, "specimen_code"));
                    layBarcodeOne.SetItemValue(rowNum, "specimen_name", this.layBarcode.GetItemString(j, "specimen_name"));
                    layBarcodeOne.SetItemValue(rowNum, "tube_code", this.layBarcode.GetItemString(j, "tube_code"));
                    layBarcodeOne.SetItemValue(rowNum, "tube_name", this.layBarcode.GetItemString(j, "tube_name"));
                    layBarcodeOne.SetItemValue(rowNum, "specimen_ser", this.layBarcode.GetItemString(j, "specimen_ser"));
                    layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode.GetItemString(j, "bunho"));
                    layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode.GetItemString(j, "suname"));
                    layBarcodeOne.SetItemValue(rowNum, "gwa_name", this.layBarcode.GetItemString(j, "gwa_name"));
                    layBarcodeOne.SetItemValue(rowNum, "danger_yn", this.layBarcode.GetItemString(j, "danger_yn"));
                    layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcode.GetItemString(j, "specimen_ser_ba"));
                    layBarcodeOne.SetItemValue(rowNum, "jangbi_code", this.layBarcode.GetItemString(j, "jangbi_code"));
                    layBarcodeOne.SetItemValue(rowNum, "jangbi_name", this.layBarcode.GetItemString(j, "jangbi_name"));
                    layBarcodeOne.SetItemValue(rowNum, "in_out_gubun", this.layBarcode.GetItemString(j, "in_out_gubun"));
                    layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re", this.layBarcode.GetItemString(j, "gumsa_name_re"));
                    layBarcodeOne.SetItemValue(rowNum, "tube_max_amt", this.layBarcode.GetItemString(j, "tube_max_amt"));
                    layBarcodeOne.SetItemValue(rowNum, "tube_numbering", this.layBarcode.GetItemString(j, "tube_numbering"));

             //       dwBarcode.FillData(layBarcodeOne.LayoutTable);
            //        dwBarcode.PrintProperties.PrinterName = printSetName;
                    try
                    {
            //            dwBarcode.Print();
                    }
                    catch { }

                    #region [PART JUBSU Process 2013/08/01 by P.w.j]
                    /* パート受付まで処理するLogic
                    //   PART JUBSU
                    string strCMD = @"SELECT 'Y'
                                    FROM DUAL
                                   WHERE EXISTS (SELECT NULL
                                                   FROM CPL0109
                                                  WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                                    AND CODE_TYPE = '20'
                                                    AND CODE ='" + this.layBarcodeOne.GetItemString(0, "specimen_code") + "')";

                    object retVal = Service.ExecuteScalar(strCMD);

                    if (TypeCheck.IsNull(retVal))
                    {

                        inputList.Clear();
                        outputList.Clear();

                        inputList.Add("I_SPECIMEN_SER", this.layBarcode.GetItemString(j, "specimen_ser"));
                        inputList.Add("I_JUNDAL_GUBUN", this.layBarcode.GetItemString(j, "jundal_gubun"));
                        inputList.Add("I_PART_JUBSU_DATE", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jubsu_date"));
                        inputList.Add("I_PART_JUBSU_TIME", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jubsu_time"));
                        inputList.Add("I_PART_JUBSUJA", this.cbxActor.GetDataValue());
                        inputList.Add("I_USER_ID", this.cbxActor.GetDataValue());

                        if (!Service.ExecuteProcedure("PR_CPL_PART_JUBSU", inputList, outputList))
                        {
                            XMessageBox.Show("受付処理中にエラー発生しました。\r\nPR_CPL_PART_JUBSU エラー\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                            throw new Exception();
                        }
                    }
                     * */
                    #endregion [PART JUBSU Process 2013/08/01 by P.w.j]
                }

                //foreach (DataRow row in this.layBarcode.LayoutTable.Rows)
                //{
                //    dwBarcode.Reset();
                //    layBarcodeOne.Reset();
                //    this.layBarcodeOne.LayoutTable.ImportRow(row);

                //    dwBarcode.FillData(layBarcodeOne.LayoutTable);
                //    dwBarcode.PrintProperties.PrinterName = printSetName;
                //    try
                //    {
                //        dwBarcode.Print();
                //    }
                //    catch { }
                //}
            }
        }
        #endregion

        #region 용기 카운트
        private void CountTube()
		{
			string grd_cnt = "";
			string grd_tube_code = "";
			string lay_cnt = "";
			string lay_tube_code = "";
			string lay_tube_name = "";
			int tot_cnt = 0;

			this.layTube.QueryLayout(true);

			int grd_row_cnt = this.grdTube.RowCount;
			for(int i=0; i<this.layTube.RowCount; i++)
			{
				for(int j=0; j<grd_row_cnt; j++)
				{
					grd_cnt = this.grdTube.GetItemString(j,"cnt");
					grd_tube_code = this.grdTube.GetItemString(j,"tube_code");
					lay_cnt = this.layTube.GetItemString(i,"cnt");
					lay_tube_code = this.layTube.GetItemString(i,"tube_code");
					lay_tube_name = this.layTube.GetItemString(i,"tube_name");

					if(grd_tube_code == lay_tube_code)
					{
						tot_cnt = int.Parse(grd_cnt) + int.Parse(lay_cnt);
						this.grdTube.SetItemValue(j,"cnt",tot_cnt.ToString());
					}
					else
					{
						this.grdTube.InsertRow();
						this.grdTube.SetItemValue(this.grdTube.CurrentRowNumber,"tube_code",lay_tube_code);
						this.grdTube.SetItemValue(this.grdTube.CurrentRowNumber,"tube_name",lay_tube_name);
						this.grdTube.SetItemValue(this.grdTube.CurrentRowNumber,"cnt",lay_cnt);
					}
				}
			}
			this.grdTube.AcceptData();
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
				this.paBox.Focus();
				this.paBox.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.paBox.BunHo))
			{
				return new XPatientInfo(this.paBox.BunHo, "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion 

		#region 유저체인지
		private void CPL2010U01_UserChanged(object sender, System.EventArgs e)
		{
			this.OnLoad(e);
		}
		#endregion

		#region 스크린오픈
		private void CPL2010U01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// 이전 스크린의 등록번호를 가져온다
			XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

			if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
			{
				// 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
				patientInfo = XScreen.GetOtherScreenBunHo(this, true);
			}

			if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
			{
				this.paBox.Focus();
				this.paBox.SetPatientID(patientInfo.BunHo);
			} 
		}
		#endregion

        private void btnPrintSetup_Click(object sender, System.EventArgs e)
        {
            this.SetPrint();
        }

        #region [btnAllCheck/ btnAllUnCheck]
        private void btnAllCheck_Click(object sender, System.EventArgs e)
		{
			for ( int i = 0 ; i < this.grdSpecimen.RowCount; i++ )
				this.grdSpecimen.SetItemValue(i,"jubsu_flag","Y");
		}

		private void btnAllUnCheck_Click(object sender, System.EventArgs e)
		{
			string hangmog_code  = string.Empty;
			string group_hangmog = string.Empty;
			string part_yn = string.Empty;

			for ( int i = 0 ; i < this.grdSpecimen.RowCount; i++ )
			{
				hangmog_code  = this.grdSpecimen.GetItemString(i,"hangmog_code");
				group_hangmog = this.grdSpecimen.GetItemString(i,"group_hangmog");
				part_yn       = this.grdSpecimen.GetItemString(i,"part_jubsu_flag");

				if (part_yn != "Y" )
				{
					if ( groupPartYn(group_hangmog) )
					{
						this.grdSpecimen.SetItemValue(i,"jubsu_flag","N");
					}
				}
			}
        }
        #endregion

        private bool groupPartYn(string aGroup_hangmog)
		{
			string group_hangmog = string.Empty;
			string part_yn = string.Empty;

			for ( int i = 0 ; i < this.grdSpecimen.RowCount; i++ )
			{
				group_hangmog = this.grdSpecimen.GetItemString(i,"group_hangmog");
				part_yn       = this.grdSpecimen.GetItemString(i,"part_jubsu_flag");
				if (group_hangmog == aGroup_hangmog)
				{
					//그룹 항목중 하나라도 파트접수가 되면 취소 안됨
					if (part_yn == "Y" ) return false;
				}
			}

			return true;
		}

		#region 검체그리드 프로텍티드
		private void grdSpecimen_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			if ( e.ColName == "jubsu_flag" )
			{
				string hangmog_code  = this.grdSpecimen.GetItemString(e.RowNumber,"hangmog_code");
				string group_hangmog = this.grdSpecimen.GetItemString(e.RowNumber,"group_hangmog");
				//string part_yn = this.grdSpecimen.GetItemString(e.RowNumber,"part_jubsu_flag");
				//string gum_jubsu_yn = grdSpecimen.GetItemString(e.RowNumber,"gum_jubsu_flag").Trim();

				if ( hangmog_code == group_hangmog )
				{
					e.Protect = false;
				}
				else
				{
					e.Protect = true;
				}

                //if ( part_yn == "Y" || gum_jubsu_yn == "Y" )
                //    e.Protect = true;
            }
            else if (e.ColName == "print_yn")
            {
                if (this.rbxJubsu.Checked)
                    e.Protect = false;
                else if (this.rbxMijubsu.Checked)
                    e.Protect = true;
            }
		}
		#endregion

		#region 검체 발행 체크/언체크 이벤트
		private void grdSpecimen_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
		{
            string middle_result = this.grdSpecimen.GetItemString(e.RowNumber, "middle_result");

            if (this.rbxJubsu.Checked == true)
            {
                // 検査時間の間をおいて検査する項目なので一緒にチェックされない様に
                if (middle_result != "Y")
                {
                    if (e.ColName == "jubsu_flag")
                    {
                        //string hangmog_code = this.grdSpecimen.GetItemString(e.RowNumber, "hangmog_code");
                        //string group_hangmog = this.grdSpecimen.GetItemString(e.RowNumber,"group_hangmog");
                        string specimen_ser = this.grdSpecimen.GetItemString(e.RowNumber, "specimen_ser");

                        for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                        {
                            //if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "fkocs1003") == fkocs1003))
                            if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "specimen_ser") == specimen_ser))
                            {
                                if (e.ChangeValue.ToString() == "Y")
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
                                }
                                else
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
                                }
                            }
                        }
                        //if ( hangmog_code == group_hangmog )
                        //{
                        //    for ( int i = 0; i < this.grdSpecimen.RowCount; i++ )
                        //    {
                        //        if ( (i != e.RowNumber ) && (this.grdSpecimen.GetItemString(i,"group_hangmog") == hangmog_code) )
                        //        {
                        //            if ( e.ChangeValue.ToString() == "Y" )
                        //                this.grdSpecimen.SetItemValue(i,"jubsu_flag","Y");
                        //            else
                        //                this.grdSpecimen.SetItemValue(i,"jubsu_flag","N");
                        //        }
                        //    }
                        //}
                    }
                }

                //if ( e.ColName == "print_yn" )
                //{
                //    string specimen_ser  = this.grdSpecimen.GetItemString(e.RowNumber,"specimen_ser");

                //    for ( int i = 0; i < this.grdSpecimen.RowCount; i++ )
                //    {
                //        if ( (i != e.RowNumber ) && (this.grdSpecimen.GetItemString(i,"specimen_ser") == specimen_ser) )
                //        {
                //            this.grdSpecimen.SetItemValue(i,"print_yn",e.ChangeValue.ToString());
                //        }
                //    }
                //}

                if (e.ColName == "print_yn")
                {
                    string specimen_ser = this.grdSpecimen.GetItemString(e.RowNumber, "specimen_ser");
                    string tube_name = this.grdSpecimen.GetItemString(e.RowNumber, "tube_name");

                    if (tube_name != "")
                    {
                        for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                        {
                            if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "specimen_ser") == specimen_ser))
                            {
                                this.grdSpecimen.SetItemValue(i, "print_yn", e.ChangeValue.ToString());
                            }
                        }

                        for (int i = 0; i < this.grdTube.RowCount; i++)
                        {
                            if (grdTube.GetItemString(i, "tube_name") == tube_name)
                                grdTube.SetItemValue(i, "print_yn", e.ChangeValue.ToString());
                        }
                    }
                }
            }

            if (this.rbxMijubsu.Checked == true)
            {
                if (e.ColName == "jubsu_flag")
                {
                    //string hangmog_code = this.grdSpecimen.GetItemString(e.RowNumber, "hangmog_code");
                    //string group_hangmog = this.grdSpecimen.GetItemString(e.RowNumber,"group_hangmog");
                    string uitak_code = this.grdSpecimen.GetItemString(e.RowNumber, "uitak_code");
                    string tube_code = this.grdSpecimen.GetItemString(e.RowNumber, "tube_code");
                    

                    // 検査時間の間をおいて検査する項目なので一緒にチェックされない様に
                    if (middle_result != "Y")
                    {
                        for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                        {
                            //if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "fkocs1003") == fkocs1003))
                            if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "uitak_code") == uitak_code) && (this.grdSpecimen.GetItemString(i, "tube_code") == tube_code))
                            {
                                if (e.ChangeValue.ToString() == "Y")
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
                                }
                                else
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
                                }
                            }
                        }
                    }
                }
            }
		}
		#endregion

		#region 예약된 건만 조회 로직
		private void cbxReser_CheckedChanged(object sender, System.EventArgs e)
		{
			this.btnList.PerformClick(FunctionType.Query);
		}
		#endregion

		#region 검체 채취 리스트 팝업
		private void btnSpecimenList_Click(object sender, System.EventArgs e)
		{
			string ho_dong = "";

			//if ( !TypeCheck.IsNull(fbxHoDong.GetDataValue()) )
            if (!TypeCheck.IsNull(this.cbxBuseo.GetDataValue()))
			{
				//ho_dong = fbxHoDong.GetDataValue();
                ho_dong = this.cbxBuseo.GetDataValue();
			}
			
			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add( "ho_dong", ho_dong);
            openParams.Add("from_date", dtpFromOrderDate.GetDataValue());
            openParams.Add("to_date", dtpToOrderDate.GetDataValue());

			
			XScreen.OpenScreenWithParam(this, "CPLS", "CPL2010R01", IHIS.Framework.ScreenOpenStyle.ResponseSizable, ScreenAlignment.ScreenMiddleCenter,  openParams); 
		}
		#endregion

		#region 채혈 실시 화면 팝업
		private void btnGumJubsu_Click(object sender, System.EventArgs e)
		{
			CommonItemCollection openParams  = new CommonItemCollection();
            openParams.Add("ho_dong", this.cbxBuseo.SelectedIndex.ToString());
			//openParams.Add( "bunho", bunho);
            openParams.Add("dtpFromDate", this.dtpFromOrderDate.GetDataValue());
            openParams.Add("dtpToDate", this.dtpToOrderDate.GetDataValue());
            openParams.Add("actor", this.cbxActor.GetDataValue());
			
			XScreen.OpenScreenWithParam(this, "CPLS", "CPL2010U02", IHIS.Framework.ScreenOpenStyle.ResponseSizable, ScreenAlignment.ScreenMiddleCenter,  openParams); 
		}
		#endregion

		#region 일괄접수 버튼 클릭 이벤트로 태우기
		private void btnAllTest_Click(object sender, System.EventArgs e)
		{
            //if ( grdPa.RowCount == 0 || rbxJubsu.Checked == true ) return;

            //string msg = (NetInfo.Language == LangMode.Ko ? "모든 환자를 일괄접수하시겠습니까?"
            //    : "全患者を一括受付しますか。");
            //string cap = (NetInfo.Language == LangMode.Ko ? "확인"
            //    : "確認");
            //if ( MessageBox.Show(msg,cap,MessageBoxButtons.YesNo) == DialogResult.Yes )
            //{
            //    btnAllCheck_Click(null,null);

            //    btnList.PerformClick(FunctionType.Update);

            //    btnAllTest_Click(null, null);
            //}
		}
		#endregion

        //#region 그리드 더블 클릭(인쇄 자동체크,언체크)
        //private void grdSpecimen_DoubleClick(object sender, System.EventArgs e)
        //{
        //    bool is_checked = false;
        //    for ( int i = 0 ; i < grdSpecimen.RowCount; i++ )
        //    {
        //        if ( grdSpecimen.GetItemString(i,"print_yn") == "Y" )
        //        {
        //            is_checked = true;
        //            break;
        //        }
        //    }

        //    if ( is_checked )
        //    {
        //        for ( int i = 0; i < grdSpecimen.RowCount; i++ )
        //        {
        //            grdSpecimen.SetItemValue(i,"print_yn","N");
        //        }
        //    }
        //    else
        //    {
        //        for ( int i = 0; i < grdSpecimen.RowCount; i++ )
        //        {
        //            grdSpecimen.SetItemValue(i,"print_yn","Y");
        //        }
        //    }
        //}
        //#endregion

		#region 취소라벨 조회
		private void btnCancleLabel_Click(object sender, System.EventArgs e)
		{
            //XScreen.OpenScreen(this, "CPLS", "CPLCANCLELABEL", IHIS.Framework.ScreenOpenStyle.ResponseSizable, ScreenAlignment.ScreenMiddleCenter);
            XScreen.OpenScreen(this, "CPLCANCLELABEL", IHIS.Framework.ScreenOpenStyle.ResponseSizable, ScreenAlignment.ScreenMiddleCenter); 
		}
		#endregion

        private void fbxHoDong_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //vsvHodong.QueryLayout();

            //if (vsvHodong.GetItemValue("hodong_name").ToString() == "")
            //{
            //    e.Cancel = true;
            //    return;
            //}

            this.grdPaList.QueryLayout(false);
        }

        private void vsvHodong_QueryStarting(object sender, CancelEventArgs e)
        {
            this.vsvHodong.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.vsvHodong.SetBindVarValue("f_code", this.fbxHoDong.GetDataValue());
            this.vsvHodong.SetBindVarValue("f_code", this.cbxBuseo.GetDataValue());
        }

        private void layPrintName_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPrintName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layPrintName.SetBindVarValue("f_ip_addr", Service.ClientIP.ToString());
        }

        private void layBarcodeTemp2_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBarcodeTemp2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layBarcodeTemp2_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                this.layBarcode2.Reset();
                int t_tube_count = 0;
                int rowNum = 0;
                
                for (int i = 0; i < layBarcodeTemp2.RowCount; i++)
                {
                    t_tube_count = layBarcodeTemp2.GetItemInt(i, "tube_count");

                    for (int j = 0; j < t_tube_count; j++)
                    {
                        rowNum = this.layBarcode2.InsertRow(j-1);

                        this.layBarcode2.SetItemValue(rowNum, "jundal_gubun", this.layBarcodeTemp2.GetItemString(i, "jundal_gubun"));
                        this.layBarcode2.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcodeTemp2.GetItemString(i, "jundal_gubun_name"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_code", this.layBarcodeTemp2.GetItemString(i, "specimen_code"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_name", this.layBarcodeTemp2.GetItemString(i, "specimen_name"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_code", this.layBarcodeTemp2.GetItemString(i, "tube_code"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_name", this.layBarcodeTemp2.GetItemString(i, "tube_name"));
                        this.layBarcode2.SetItemValue(rowNum, "in_out_gubun", this.layBarcodeTemp2.GetItemString(i, "in_out_gubun"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_ser", this.layBarcodeTemp2.GetItemString(i, "specimen_ser"));
                        this.layBarcode2.SetItemValue(rowNum, "bunho", this.layBarcodeTemp2.GetItemString(i, "bunho"));
                        this.layBarcode2.SetItemValue(rowNum, "suname", this.layBarcodeTemp2.GetItemString(i, "suname"));
                        this.layBarcode2.SetItemValue(rowNum, "gwa_name", this.layBarcodeTemp2.GetItemString(i, "gwa_name"));
                        this.layBarcode2.SetItemValue(rowNum, "danger_yn", this.layBarcodeTemp2.GetItemString(i, "danger_yn"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcodeTemp2.GetItemString(i, "specimen_ser_ba"));
                        this.layBarcode2.SetItemValue(rowNum, "jangbi_code", this.layBarcodeTemp2.GetItemString(i, "jangbi_code"));
                        this.layBarcode2.SetItemValue(rowNum, "jangbi_name", this.layBarcodeTemp2.GetItemString(i, "jangbi_name"));
                        this.layBarcode2.SetItemValue(rowNum, "gumsa_name_re", this.layBarcodeTemp2.GetItemString(i, "gumsa_name_re"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_max_amt", this.layBarcodeTemp2.GetItemString(i, "tube_max_amt"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_numbering", this.layBarcodeTemp2.GetItemString(i, "tube_numbering"));
                    }
                }

                //foreach (DataRow row in this.layBarcodeTemp2.LayoutTable.Rows)
                //{
                //    t_tube_count = 0;

                //    if (!TypeCheck.IsNull(row["tube_count"]))
                //        t_tube_count = Convert.ToInt32(row["tube_count"]);

                //    for (int j = 0; j < t_tube_count; j++)
                //    {
                //        this.layBarcode2.LayoutTable.ImportRow(row);
                //    }
                //}

            }

        }

        private void layBarcodeTemp_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBarcodeTemp.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.layBarcodeTemp.SetBindVarValue("f_bunho", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "bunho"));
            this.layBarcodeTemp.SetBindVarValue("f_bunho", this.txtBunho.GetDataValue());
        }

        private void layBarcodeTemp_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                this.layBarcode.Reset();
                int t_tube_count = 0;
                int rowNum = 0;
                for (int i = 0; i < layBarcodeTemp.RowCount; i++)
                {
                    t_tube_count = layBarcodeTemp.GetItemInt(i, "tube_count");

                    for (int j = 0; j < t_tube_count; j++)
                    {
                        rowNum = this.layBarcode.InsertRow(j-1);

                        this.layBarcode.SetItemValue(rowNum, "jundal_gubun", this.layBarcodeTemp.GetItemString(i, "jundal_gubun"));
                        this.layBarcode.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcodeTemp.GetItemString(i, "jundal_gubun_name"));
                        this.layBarcode.SetItemValue(rowNum, "specimen_code", this.layBarcodeTemp.GetItemString(i, "specimen_code"));
                        this.layBarcode.SetItemValue(rowNum, "specimen_name", this.layBarcodeTemp.GetItemString(i, "specimen_name"));
                        this.layBarcode.SetItemValue(rowNum, "tube_code", this.layBarcodeTemp.GetItemString(i, "tube_code"));
                        this.layBarcode.SetItemValue(rowNum, "tube_name", this.layBarcodeTemp.GetItemString(i, "tube_name"));
                        this.layBarcode.SetItemValue(rowNum, "in_out_gubun", this.layBarcodeTemp.GetItemString(i, "in_out_gubun"));
                        this.layBarcode.SetItemValue(rowNum, "specimen_ser", this.layBarcodeTemp.GetItemString(i, "specimen_ser"));
                        this.layBarcode.SetItemValue(rowNum, "bunho", this.layBarcodeTemp.GetItemString(i, "bunho"));
                        this.layBarcode.SetItemValue(rowNum, "suname", this.layBarcodeTemp.GetItemString(i, "suname"));
                        this.layBarcode.SetItemValue(rowNum, "gwa_name", this.layBarcodeTemp.GetItemString(i, "gwa_name"));
                        this.layBarcode.SetItemValue(rowNum, "danger_yn", this.layBarcodeTemp.GetItemString(i, "danger_yn"));
                        this.layBarcode.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcodeTemp.GetItemString(i, "specimen_ser_ba"));
                        this.layBarcode.SetItemValue(rowNum, "jangbi_code", this.layBarcodeTemp.GetItemString(i, "jangbi_code"));
                        this.layBarcode.SetItemValue(rowNum, "jangbi_name", this.layBarcodeTemp.GetItemString(i, "jangbi_name"));
                        this.layBarcode.SetItemValue(rowNum, "gumsa_name_re", this.layBarcodeTemp.GetItemString(i, "gumsa_name_re"));
                        this.layBarcode.SetItemValue(rowNum, "tube_max_amt", this.layBarcodeTemp.GetItemString(i, "tube_max_amt"));
                        this.layBarcode.SetItemValue(rowNum, "tube_numbering", this.layBarcodeTemp.GetItemString(i, "tube_numbering"));
                    }
                }

                //foreach (DataRow row in this.layBarcodeTemp.LayoutTable.Rows)
                //{
                //    t_tube_count = 0;

                //    if (!TypeCheck.IsNull(row["tube_count"]))
                //        t_tube_count = Convert.ToInt32(row["tube_count"]);

                //    for (int j = 0; j < t_tube_count; j++)
                //    {
                //        this.layBarcode.LayoutTable.ImportRow(row);
                //    }
                //}

                string cmdText = @" UPDATE CPL2010
                                   SET DUMMY = NULL
                                 WHERE HOSP_CODE     = :f_hosp_code 
                                   AND JUBSU_DATE    = to_date(:f_jubsu_date,'YYYY/MM/DD')
                                   AND BUNHO         = :f_bunho
                                   AND DUMMY         = 'Y'";

                BindVarCollection bc = new BindVarCollection();
                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_bunho", this.txtBunho.GetDataValue());
                bc.Add("f_jubsu_date", this.o_jubsu_date);

                Service.ExecuteNonQuery(cmdText, bc);
            }

        }

        private void grdTube_QueryStarting(object sender, CancelEventArgs e)
        {
            if (rbxJubsu.Checked == true)
            {
                grdTube.QuerySQL = @"SELECT X.TUBE_CODE,
                                           X.TUBE_NAME,
                                           SUM(X.TUBE_COUNT)   CNT
                                      FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,
                                                        MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE))            TUBE_NAME,
                                                        FN_CPL_TUBE_COUNT(A.SPECIMEN_SER)               TUBE_COUNT,
                                                        A.HOSP_CODE 
                                                   FROM CPL0101 B,
                                                        CPL2010 A
                                                  WHERE A.HOSP_CODE     = :f_hosp_code
                                                    AND B.HOSP_CODE     = A.HOSP_CODE 
                                                    --AND A.JUBSU_DATE    = to_date(:f_jubsu_date,'YYYY/MM/DD')
                                                    --AND A.JUBSU_TIME    = :f_jubsu_time
                                                    AND A.ORDER_DATE    = to_date(:f_order_date,'YYYY/MM/DD')
                                                    AND A.ORDER_TIME    = :f_order_time
                                                    AND A.BUNHO         = :f_bunho
                                                    AND A.JUBSU_DATE    IS NOT NULL
                                                    AND B.HANGMOG_CODE  = A.HANGMOG_CODE
                                                    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
                                                    AND B.EMERGENCY     = A.EMERGENCY
                                                  GROUP BY A.HOSP_CODE,
                                                        --A.JUNDAL_GUBUN,
                                                        A.SPECIMEN_CODE,
                                                        A.TUBE_CODE,
                                                        A.IN_OUT_GUBUN,
                                                        A.SPECIMEN_SER,
                                                        A.GWA,
                                                        A.BUNHO      ) X
                                     WHERE X.HOSP_CODE = :f_hosp_code
                                     GROUP BY X.TUBE_CODE, X.TUBE_NAME
                                     ORDER BY 1";

                //this.grdTube.SetBindVarValue("f_jubsu_date", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "jubsu_date"));
                //this.grdTube.SetBindVarValue("f_jubsu_time", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "jubsu_time"));
            }
            else if (rbxMijubsu.Checked == true)
            {
                grdTube.QuerySQL = @"SELECT X.TUBE_CODE,
                                           X.TUBE_NAME,
                                           SUM(X.TUBE_COUNT)   CNT
                                      FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,
                                                        MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE))            TUBE_NAME,
                                                        1                                                  TUBE_COUNT,
                                                        A.HOSP_CODE 
                                                   FROM CPL0101 B,
                                                        CPL2010 A
                                                  WHERE A.HOSP_CODE     = :f_hosp_code
                                                    AND B.HOSP_CODE     = A.HOSP_CODE 
                                                    AND A.ORDER_DATE    = to_date(:f_order_date,'YYYY/MM/DD')
                                                    AND A.ORDER_TIME    = :f_order_time
                                                    AND A.BUNHO         = :f_bunho
                                                    AND A.JUBSU_DATE    IS NULL
                                                    AND B.HANGMOG_CODE  = A.HANGMOG_CODE
                                                    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
                                                    AND B.EMERGENCY     = A.EMERGENCY
                                                  GROUP BY A.HOSP_CODE,
                                                        --A.JUNDAL_GUBUN,
                                                        A.SPECIMEN_CODE,
                                                        A.TUBE_CODE,
                                                        A.IN_OUT_GUBUN,
                                                        --A.SPECIMEN_SER,
                                                        A.GWA,
                                                        A.BUNHO      ) X
                                     WHERE X.HOSP_CODE = :f_hosp_code
                                     GROUP BY X.TUBE_CODE, X.TUBE_NAME
                                     ORDER BY 1";
            }
            this.grdTube.SetBindVarValue("f_order_date", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "order_date"));
            this.grdTube.SetBindVarValue("f_order_time", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "order_time"));
            this.grdTube.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdTube.SetBindVarValue("f_bunho", this.txtBunho.GetDataValue());
            /*
            this.grdTube.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdTube.SetBindVarValue("f_jubsu_date", EnvironInfo.HospCode);
            //this.grdTube.SetBindVarValue("f_jubsu_time", EnvironInfo.HospCode);
            this.grdTube.SetBindVarValue("f_bunho", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "bunho"));
            //this.grdTube.SetBindVarValue("f_reser_date", EnvironInfo.HospCode);
            this.grdTube.SetBindVarValue("f_reser_yn", cbxReser.GetDataValue());*/

        }

        private void layTube_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layTube.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdTube.SetBindVarValue("f_jubsu_date", EnvironInfo.HospCode);
            //this.grdTube.SetBindVarValue("f_jubsu_time", EnvironInfo.HospCode);
            this.layTube.SetBindVarValue("f_bunho", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "bunho"));
            //this.grdTube.SetBindVarValue("f_reser_date", EnvironInfo.HospCode);
            this.layTube.SetBindVarValue("f_reser_yn", cbxReser.GetDataValue());
        }

        #region XSavePerformer

        private int jubsu_cnt = 0;
        private int cancel_cnt = 0;
        private string o_jubsu_date = "";
        private string o_jubsu_time = "";
        private string o_flag = "";
        //private string t_jubsu_gubun = "";
        private string mErrMsg = "";

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private CPL2010U01 parent = null;

            public XSavePerformer(CPL2010U01 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                string t_in_out_gubun = "";
                string t_fkocs = "";
                parent.mErrMsg = "";

                Hashtable inputList = new Hashtable();
                Hashtable outputList = new Hashtable();

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Modified:

                        cmdText = @"SELECT IN_OUT_GUBUN
                                         , NVL(FKOCS1003,FKOCS2003) FKOCS
                                      FROM CPL2010
                                     WHERE HOSP_CODE = :f_hosp_code
                                       AND PKCPL2010 = :f_pkcpl2010";

                        DataTable dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

                        if (Service.ErrCode != 0)
                        {
                            return false;
                        }

                        if (!TypeCheck.IsNull(dt))
                        {
                            t_in_out_gubun = dt.Rows[0]["in_out_gubun"].ToString();
                            t_fkocs = dt.Rows[0]["fkocs"].ToString();
                        }

                        if (item.BindVarList["f_jubsu_flag"].VarValue == "Y")
                        {   

                            parent.jubsu_cnt++;

                            cmdText = @"UPDATE CPL2010
                                           SET UPD_ID    = :q_user_id
                                             , UPD_DATE  = SYSDATE
                                             , DUMMY     = 'Y'
                                         WHERE HOSP_CODE = :f_hosp_code
                                           AND PKCPL2010 = :f_pkcpl2010";

                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    return false;
                            }

                        }
                        #region [PART JUBSU Cancel Process 2013/08/01 by P.w.j]
                        /*
                        else if (item.BindVarList["f_jubsu_flag"].VarValue == "N")
                        {
                            //parent.SetStatusBar(parent.cancel_cnt);

                            cmdText = @"  SELECT 'Y'
                                            FROM DUAL
                                           WHERE EXISTS ( SELECT 'X'
                                                            FROM CPL2010
                                                           WHERE HOSP_CODE = :f_hosp_code 
                                                             AND PKCPL2010 = :f_pkcpl2010
                                                             AND SPECIMEN_SER IS NOT NULL)";

                            object o_flag2 = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if (!TypeCheck.IsNull(o_flag2))
                            {

                                if (o_flag2.ToString() == "Y")
                                {
                                    //                                    cmdText = @"SELECT 'N'
                                    //                                                    FROM DUAL
                                    //                                                   WHERE EXISTS ( SELECT 'X'
                                    //                                                                    FROM CPL2010
                                    //                                                                   WHERE HOSP_CODE = :f_hosp_code 
                                    //                                                                     AND PKCPL2010 = :f_pkcpl2010
                                    //                                                                     AND PART_JUBSU_DATE IS NOT NULL)";

                                    //                                    object flag = Service.ExecuteScalar(cmdText, item.BindVarList);

                                    //                                    if (!TypeCheck.IsNull(flag))
                                    //                                    {
                                    //                                        parent.o_flag = flag.ToString();

                                    //                                        if (parent.o_flag == "N")
                                    //                                        {
                                    //                                            parent.mErrMsg = "既に検査室で受付されています。取消できません。";
                                    //                                            return false;
                                    //                                        }
                                    //                                    }

                                    //                                    cmdText = @"UPDATE CPL2010
                                    //                                                   SET UPD_ID    = :q_user_id
                                    //                                                     , UPD_DATE  = SYSDATE
                                    //                                                     , DUMMY     = 'N'
                                    //                                                 WHERE HOSP_CODE = :f_hosp_code 
                                    //                                                   AND PKCPL2010 = :f_pkcpl2010";

                                    //                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    //                                    {
                                    //                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    //                                            return false;
                                    //                                    }

                                    parent.cancel_cnt++;

                                    cmdText = @"UPDATE CPL2010
                                               SET UPD_ID    = :q_user_id
                                                 , UPD_DATE  = SYSDATE
                                                 , DUMMY     = 'N'
                                             WHERE HOSP_CODE = :f_hosp_code 
                                               AND PKCPL2010 = :f_pkcpl2010";

                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                        {
                                            parent.mErrMsg = "保存処理中にエラーが発生しました。\r\n" + Service.ErrFullMsg;
                                            return false;
                                        }
                                    }

                                    inputList.Clear();

                                    inputList.Add("I_ORDER_DATE", item.BindVarList["f_order_date"].VarValue);
                                    inputList.Add("I_BUNHO", item.BindVarList["f_bunho"].VarValue);
                                    inputList.Add("I_JUBSUJA", UserInfo.UserID);
                                    inputList.Add("I_JUBSU_FLAG", "N");
                                    inputList.Add("I_JUBSU_GUBUN", DBNull.Value);// null
                                    inputList.Add("I_JUBSU_DATE", DBNull.Value);
                                    inputList.Add("I_JUBSU_TIME", DBNull.Value);

                                    if (!Service.ExecuteProcedure("PR_CPL_MAKE_SPECIMEN_SER", inputList, outputList))
                                    {
                                        parent.mErrMsg = "[PR_CPL_MAKE_SPECIMEN_SER]処理に失敗しました。" + Service.ErrFullMsg;
                                        return false;
                                    }

                                    if (outputList.Count > 0)
                                    {
                                        if (outputList["IO_FLAG"].ToString() == "N")
                                        {
                                            parent.mErrMsg = "既に検査室で受付されています。取消できません。";
                                            return false;
                                        }
                                    }

                                    //parent.o_jubsu_date = "";
                                    //parent.o_jubsu_time = "";

                                    cmdText = @"UPDATE CPL2010
                                                   SET UPD_ID    = :q_user_id
                                                     , UPD_DATE  = SYSDATE
                                                     , DUMMY     = NULL
                                                 WHERE HOSP_CODE = :f_hosp_code 
                                                   AND PKCPL2010 = :f_pkcpl2010";

                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                        {
                                            parent.mErrMsg = "保存処理中にエラーが発生しました。\r\n" + Service.ErrFullMsg;
                                            return false;
                                        }
                                    }

                                    if (outputList["IO_FLAG"].ToString() == "N")
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                         * */
                        #endregion [PART JUBSU Process]
                        else if (item.BindVarList["f_jubsu_flag"].VarValue == "N")
                        {
                            //parent.SetStatusBar(parent.cancel_cnt);

                            cmdText = @"  SELECT 'Y'
                                            FROM DUAL
                                           WHERE EXISTS ( SELECT 'X'
                                                            FROM CPL2010
                                                           WHERE HOSP_CODE = :f_hosp_code 
                                                             AND PKCPL2010 = :f_pkcpl2010
                                                             AND SPECIMEN_SER IS NOT NULL)";

                            object o_flag2 = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if (!TypeCheck.IsNull(o_flag2))
                            {
                                if (o_flag2.ToString() == "Y")
                                {
                                    parent.cancel_cnt++;


                                    cmdText = @"SELECT 'N'
                                                    FROM DUAL
                                                   WHERE EXISTS ( SELECT 'X'
                                                                    FROM CPL2010
                                                                   WHERE HOSP_CODE = :f_hosp_code 
                                                                     AND PKCPL2010 = :f_pkcpl2010
                                                                     AND PART_JUBSU_DATE IS NOT NULL)";

                                    object flag = Service.ExecuteScalar(cmdText, item.BindVarList);

                                    if (!TypeCheck.IsNull(flag))
                                    {
                                        parent.o_flag = flag.ToString();

                                        if (parent.o_flag == "N")
                                        {
                                            parent.mErrMsg = Resources.MSG003_ERR_MSG;
                                            return false;
                                        }
                                    }

                                    cmdText = @"UPDATE CPL2010
                                                   SET UPD_ID    = :q_user_id
                                                     , UPD_DATE  = SYSDATE
                                                     , DUMMY     = 'N'
                                                 WHERE HOSP_CODE = :f_hosp_code 
                                                   AND PKCPL2010 = :f_pkcpl2010";

                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                            return false;
                                    }

                                    inputList.Clear();

                                    inputList.Add("I_ORDER_DATE", item.BindVarList["f_order_date"].VarValue);
                                    inputList.Add("I_BUNHO", item.BindVarList["f_bunho"].VarValue);
                                    inputList.Add("I_JUBSUJA", UserInfo.UserID);
                                    inputList.Add("I_JUBSU_FLAG", "N");
                                    inputList.Add("I_JUBSU_GUBUN", DBNull.Value);
                                    inputList.Add("I_JUBSU_DATE", DBNull.Value);
                                    inputList.Add("I_JUBSU_TIME", DBNull.Value);

                                    if (!Service.ExecuteProcedure("PR_CPL_MAKE_SPECIMEN_SER", inputList, outputList))
                                    {
                                        parent.mErrMsg = Resources.MSG003_ERR_MSG;
                                        return false;
                                    }

                                    if (outputList.Count > 0)
                                    {
                                        if (outputList["IO_FLAG"].ToString() == "N")
                                        {
                                            parent.mErrMsg = Resources.MSG003_ERR_MSG;
                                            return false;
                                        }
                                    }

                                    parent.o_jubsu_date = "";
                                    parent.o_jubsu_time = "";

                                    cmdText = @"UPDATE CPL2010
                                                   SET UPD_ID    = :q_user_id
                                                     , UPD_DATE  = SYSDATE
                                                     , DUMMY     = NULL
                                                 WHERE HOSP_CODE = :f_hosp_code 
                                                   AND PKCPL2010 = :f_pkcpl2010";

                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                            return false;
                                    }

                                    if (outputList["IO_FLAG"].ToString() == "N")
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                        break;
                }
                return true;
            }
        }
        #endregion

        private void fwkHodong_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkHodong.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdSpecimen_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if (e.RowState == DataRowState.Modified)
                this.grdSpecimen.SetItemValue(e.RowNumber, "jubsuja", this.cbxActor.GetDataValue());
        }

        private void cbxBuseo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.grdPaList.QueryLayout(false);
        }

        private void cbxBuseo_SelectedIndexChanged(object sender, EventArgs e)
        {
//            this.cbxActor.ResetData();

//            // 病棟によって実施者をセットする｡
//            this.cbxActor.UserSQL = @"SELECT '' USER_ID
//                                           , '' USER_NM
//                                        FROM DUAL
//                                      UNION
//                                      SELECT A.USER_ID
//                                           , A.USER_NM
//                                        FROM ADM3200 A
//                                       WHERE A.HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()
//                                         AND A.DEPT_CODE   = '" + this.cbxBuseo.GetDataValue() + @"'
//                                    ORDER BY USER_ID NULLS FIRST";

//            this.cbxActor.SetDictDDLB();
        }

        private void grdSpecimen_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (this.grdSpecimen.RowCount > 0)
            {
                this.grdTube.QueryLayout(false);
            }
        }

        private void grdTube_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            grdTube.ResetUpdate();
            if (e.ColName == "print_yn")
            {
                for (int i = 0; i < grdSpecimen.RowCount; i++)
                {
                    if (grdTube.GetItemString(grdTube.CurrentRowNumber, "tube_name") == grdSpecimen.GetItemString(i, "tube_name"))
                    {
                        grdSpecimen.SetItemValue(i, "print_yn", e.ChangeValue);
                    }
                }
            }
        }

        private void grdTube_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "print_yn")
            {
                if (this.rbxJubsu.Checked)
                    e.Protect = false;
                else if (this.rbxMijubsu.Checked)
                    e.Protect = true;
            }
        }

        private void grdPaList_QueryStarting(object sender, CancelEventArgs e)
        {
            if (this.rbxMijubsu.Checked == true)
            {
                this.grdPaList.QuerySQL = @"/* grd PaList Before Print Label */
                                            SELECT A.BUNHO                                                          BUNHO
                                                 , MAX(A.SUNAME)                                                    SUNAME
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA,A.ORDER_DATE)                         GWA_NAME
                                                 , MAX(A.DOCTOR)
                                                 , A.DOCTOR_NAME                                                    DOCTOR_NAME
                                                 , FN_BAS_LOAD_GWA_NAME(B.TO_HO_DONG1, A.ORDER_DATE)                HO_DONG
                                                 , B.TO_HO_CODE1                                                    HO_CODE
                                                 , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN, A.FKOCS1003, A.FKOCS2003, A.RESER_DATE) RESER_YN
                                                 , NVL(C.EMERGENCY, 'N')                                            EMERGENCY_YN
                                              FROM OCS2003 C
                                                 , VW_OCS_INP2004 B
                                                 , CPL2010 A
                                             WHERE A.HOSP_CODE     = :f_hosp_code
                                               --AND NVL(A.RESER_DATE, A.ORDER_DATE) between TO_DATE(:f_from_date) and TO_DATE(:f_to_date)
                                               AND (  (:f_reser_yn = 'N' AND ( NVL(A.RESER_DATE, A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')))
                                                                          --OR A.RESER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')))
                                                 OR (:f_reser_yn = 'Y' AND A.RESER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')) )
                                               AND A.JUBSU_DATE IS NULL
                                               AND A.IN_OUT_GUBUN  = 'I'
                                               AND B.HOSP_CODE     = A.HOSP_CODE
                                               AND B.BUNHO         = A.BUNHO
                                               AND B.JAEWON_DATE   = TRUNC(SYSDATE)
                                               AND B.TO_HO_DONG1   LIKE :f_ho_dong
                                               AND C.HOSP_CODE     = A.HOSP_CODE
                                               AND C.PKOCS2003     = A.FKOCS2003
                                               AND C.DC_YN = 'N' 
                                               AND C.NALSU > 0
                                          GROUP BY FN_BAS_LOAD_GWA_NAME(B.TO_HO_DONG1, A.ORDER_DATE)
                                                 , B.TO_HO_CODE1
                                                 , A.BUNHO
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA,A.ORDER_DATE)
                                                 , A.DOCTOR_NAME
                                                 , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN, A.FKOCS1003, A.FKOCS2003, A.RESER_DATE)
                                                 , NVL(C.EMERGENCY, 'N')
                                          ORDER BY FN_SCH_RESER_YN1(A.IN_OUT_GUBUN, A.FKOCS1003, A.FKOCS2003, A.RESER_DATE)
                                                 , FN_BAS_LOAD_GWA_NAME(B.TO_HO_DONG1, A.ORDER_DATE)
                                                 , B.TO_HO_CODE1
                                                 , A.BUNHO
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA,A.ORDER_DATE)
                                                 , A.DOCTOR_NAME";
            }
            else
            {
                this.grdPaList.QuerySQL = @"/* grd PaList After Print Label */
                                            SELECT A.BUNHO                                                          BUNHO
                                                 , MAX(A.SUNAME)                                                    SUNAME
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                        GWA_NAME
                                                 , MAX(A.DOCTOR)
                                                 , A.DOCTOR_NAME                                                    DOCTOR_NAME
                                                 , FN_BAS_LOAD_GWA_NAME(B.TO_HO_DONG1, A.ORDER_DATE)                HO_DONG
                                                 , B.TO_HO_CODE1                                                    HO_CODE
                                                 , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN, A.FKOCS1003, A.FKOCS2003, A.RESER_DATE) RESER_YN
                                                 , NVL(C.EMERGENCY, 'N')                                            EMERGENCY_YN
                                              FROM OCS2003 C
                                                 , VW_OCS_INP2004 B
                                                 , CPL2010 A
                                             WHERE A.HOSP_CODE     = :f_hosp_code
                                               --AND NVL(A.RESER_DATE, A.ORDER_DATE) between TO_DATE(:f_from_date) and TO_DATE(:f_to_date)
                                               AND (  (:f_reser_yn = 'N' AND ( NVL(A.RESER_DATE, A.ORDER_DATE) BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')))
                                                                          --OR A.RESER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')))
                                                 OR (:f_reser_yn = 'Y' AND A.RESER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')) )
                                               AND A.JUBSU_DATE IS NOT NULL
                                               AND A.IN_OUT_GUBUN  = 'I'
                                               AND B.HOSP_CODE     = A.HOSP_CODE
                                               AND B.BUNHO         = A.BUNHO
                                               AND B.JAEWON_DATE   = TRUNC(SYSDATE)
                                               AND B.TO_HO_DONG1   LIKE :f_ho_dong
                                               AND C.HOSP_CODE     = A.HOSP_CODE
                                               AND C.PKOCS2003     = A.FKOCS2003
                                               AND C.DC_YN = 'N' 
                                               AND C.NALSU > 0
                                          GROUP BY FN_BAS_LOAD_GWA_NAME(B.TO_HO_DONG1, A.ORDER_DATE)
                                                 , B.TO_HO_CODE1
                                                 , A.BUNHO
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)
                                                 , A.DOCTOR_NAME
                                                 , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN, A.FKOCS1003, A.FKOCS2003, A.RESER_DATE)
                                                 , NVL(C.EMERGENCY, 'N')
                                          ORDER BY FN_SCH_RESER_YN1(A.IN_OUT_GUBUN, A.FKOCS1003, A.FKOCS2003, A.RESER_DATE)
                                                 , FN_BAS_LOAD_GWA_NAME(B.TO_HO_DONG1, A.ORDER_DATE)
                                                 , B.TO_HO_CODE1
                                                 , A.BUNHO
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA,A.ORDER_DATE)
                                                 , A.DOCTOR_NAME";
            }

            this.grdPaList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPaList.SetBindVarValue("f_from_date", this.dtpFromOrderDate.GetDataValue());
            this.grdPaList.SetBindVarValue("f_to_date", this.dtpToOrderDate.GetDataValue());
            this.grdPaList.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
            this.grdPaList.SetBindVarValue("f_reser_yn", this.cbxReser.GetDataValue());
        }

        private void grdPaList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (this.grdPaList.RowCount > 0) this.setBunho(this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "bunho"));
        }

        private void setBunho(string bunho)
        {
            this.txtBunho.SetEditValue(bunho);
            this.txtBunho.AcceptData();
        }

        private void grdPaList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.setGrdHeaderImage(this.grdPaList);

            this.QueryTime = TimeVal;

            if (this.grdPaList.RowCount > 0)
            {
                // 画面のALARMが活性の場合
                if (this.rbxMijubsu.Checked && this.useAlarmChkYN.Equals("Y"))
                {
                    for (int i = 0; i < grdPaList.RowCount; i++)
                    {
                        // 予約患者の場合は音無
                        if (this.grdPaList.GetItemString(i, "reser_yn").Equals("N"))
                        {
                            // 一般、緊急の音をセットする。
                            if (this.grdPaList.GetItemString(i, "emergency_yn").Equals("Y")) this.playAlarm("CPL_EM");
                            else this.playAlarm("CPL");
                        }
                    }
                }
            }
            else
            {
                this.txtBunho.SetEditValue("");
                this.txtBunho.AcceptData();
            }
        }

        #region [playAlarm] 撮影区分別にAlarmを設定
        private void playAlarm(string part)
        {
            try
            {
                if (part.Equals("CPL"))
                    Kernel32.PlaySound(this.alarmFilePath_CPL, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else if (part.Equals("CPL_EM"))
                    Kernel32.PlaySound(this.alarmFilePath_CPL_EM, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else
                    IHIS.Framework.Kernel32.Nofify();
            }
            catch { }
        }
        #endregion

        #region 환자 그리드 이미지 셋팅
        private void setGrdHeaderImage(XEditGrid grid)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                // 입원 예약환자.
                if (grid.Name == "grdPaList" && grid.GetItemString(i, "reser_yn") == "Y")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "予約オーダ";
                }

                // 緊急オーダ
                if (grid.Name == "grdPaList" && grid.GetItemString(i, "emergency_yn") == "Y")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[4];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "緊急処方";
                }

                //// 医師メモ
                //if (grid.Name == "grdSpecimen" && grid.GetItemString(i, "doc_comment").Length > 0)
                //{
                //    this.pbxJusa.Visible = true;
                //}

            //    /*
            //     GRIDのHEADを2行にした場合、ROWのイメージは　「＊２」にセットする。　                 
            //     */

            //    // 至急オーダ
            //    if (grid.Name == "grdOrder" && grid.GetItemString(i, "dangil_gumsa_result_yn") == "Y")
            //    {
            //        grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[19];
            //        grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].ToolTipText = grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].ToolTipText + "至急処方";
            //    }

            //    // PORTABLEオーダ
            //    if (grid.Name == "grdOrder" && grid.GetItemString(i, "portable_yn") == "Y")
            //    {
            //        grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[20];
            //        grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].ToolTipText = grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].ToolTipText + "移動撮影";
            //    }
            }
        }
        #endregion

        private void grdPaList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            this.setGrdBackColor(sender, e);
        }

        #region grid backColor setting
        private void setGrdBackColor(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.Name == "grdPaList")
            {
                if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
                {
                    e.BackColor = (XColor.XMatrixColHeaderBackColor).Color;
                }

                // 緊急オーダは「Color.Pink」セット
                if (grid.GetItemString(e.RowNumber, "emergency_yn") == "Y")
                {
                    e.BackColor = Color.Pink;
                }
            }

            //if (grid.Name == "grdOrder")
            //{
            //    // 緊急オーダは「Color.Pink」セット
            //    if (grid.GetItemString(e.RowNumber, "emergency") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
            //    {
            //        e.BackColor = Color.Pink;
            //    }

            //    // 至急オーダは「Color.MistyRose」セット
            //    if (grid.GetItemString(e.RowNumber, "dangil_gumsa_result_yn") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
            //    {
            //        e.BackColor = Color.MistyRose;
            //    }

            //    // 受付処理オーダの項目文字色セット
            //    if (grid.GetItemString(e.RowNumber, "jubsu_yn") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
            //    {
            //        e.ForeColor = Color.ForestGreen;
            //    }

            //    // 実施処理オーダの項目文字色セット
            //    if (grid.GetItemString(e.RowNumber, "act_yn") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
            //    {
            //        e.ForeColor = Color.Blue;
            //    }

            //    // I/F転送可否取得後、項目文字色セット
            //    string if_data_send_yn = this.chkIfSendYN(this.grdOrder.CurrentRowNumber);

            //    if (if_data_send_yn == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
            //    {
            //        e.ForeColor = Color.Red;
            //    }
            //}
        }
        #endregion

        private void grdPa_QueryStarting(object sender, CancelEventArgs e)
        {
            if (this.rbxMijubsu.Checked == true)
            {
                this.grdPa.QuerySQL = @"SELECT /* grdpa Before Print Lable */
                                           DISTINCT
                                           A.BUNHO                              BUNHO
                                         , A.SUNAME                             SUNAME
                                         , FN_BAS_LOAD_GWA_NAME(A.GWA,A.ORDER_DATE)  GWA_NAME
                                         , A.GWA                                GWA
                                         , A.DOCTOR_NAME                        DOCTOR_NAME
                                         , A.DOCTOR                             DOCTOR
                                         , A.ORDER_DATE                         ORDER_DATE
                                         , A.ORDER_TIME                         ORDER_TIME
                                         , A.JUBSU_DATE                         JUBSU_DATE
                                         , A.JUBSU_TIME                         JUBSU_TIME
                                         , A.RESER_DATE                         RESER_DATE
                                         , ''                                   JUBSUJA_NAME
                                         , A.GROUP_SER
                                         --, NVL(B.EMERGENCY, 'N')                EMERGENCY_YN
                                         , TO_CHAR(A.RESER_DATE, 'YYYY/MM/DD')||RPAD(C.TO_HO_DONG1,4,'0')||RPAD(C.TO_HO_CODE1,4,'0')||
                                           RPAD(A.BUNHO,9,'0')||TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')||RPAD(A.ORDER_TIME,4,'0')   KEY
                                      FROM VW_OCS_INP2004 C
                                         , OCS2003 B
                                         , CPL2010 A
                                     WHERE A.HOSP_CODE     = :f_hosp_code
                                       AND A.Bunho         = :f_bunho
                                       AND (  (:f_reser_yn = 'N' AND A.RESER_DATE IS NULL AND ( A.ORDER_DATE BETWEEN :f_from_date AND :f_to_date))
                                           OR (:f_reser_yn = 'Y' AND A.RESER_DATE BETWEEN :f_from_date AND :f_to_date) )
                                       AND A.JUBSU_DATE IS NULL
                                       AND A.IN_OUT_GUBUN  = 'I'
                                       AND A.DOCTOR        = :f_doctor
                                       AND B.HOSP_CODE     = A.HOSP_CODE
                                       AND B.PKOCS2003     = A.FKOCS2003
                                       AND (:f_emergency_yn = 'N' AND NVL(B.EMERGENCY, 'N') = 'N'
                                         OR :f_emergency_yn = 'Y' AND NVL(B.EMERGENCY, 'N') = 'Y')
                                       AND B.DC_YN = 'N' 
                                       AND B.NALSU > 0
                                       AND C.HOSP_CODE     = A.HOSP_CODE
                                       AND C.BUNHO         = A.BUNHO
                                       AND C.JAEWON_DATE   = TRUNC(SYSDATE)
                                     ORDER BY A.ORDER_DATE DESC, A.ORDER_TIME DESC";
            }
            else
            {
                this.grdPa.QuerySQL = @"SELECT /* grdpa After Print Lable */
                                           DISTINCT
                                           A.BUNHO                              BUNHO
                                         , A.SUNAME                             SUNAME
                                         , FN_BAS_LOAD_GWA_NAME(A.GWA,A.ORDER_DATE)  GWA_NAME
                                         , A.GWA                                GWA
                                         , A.DOCTOR_NAME                        DOCTOR_NAME
                                         , A.DOCTOR                             DOCTOR
                                         , A.ORDER_DATE                         ORDER_DATE
                                         , A.ORDER_TIME                         ORDER_TIME
                                         , A.JUBSU_DATE                         JUBSU_DATE
                                         , A.JUBSU_TIME                         JUBSU_TIME
                                         , A.RESER_DATE                         RESER_DATE
                                         , FN_ADM_LOAD_USER_NM(A.JUBSUJA, A.JUBSU_DATE) JUBSUJA_NAME
                                         , A.GROUP_SER
                                         , TO_CHAR(A.RESER_DATE, 'YYYY/MM/DD')||RPAD(C.TO_HO_DONG1,4,'0')||RPAD(C.TO_HO_CODE1,4,'0')||
                                           RPAD(A.BUNHO,9,'0')||TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')||RPAD(A.ORDER_TIME,4,'0')   KEY
                                      FROM VW_OCS_INP2004 C
                                         , OCS2003 B
                                         , CPL2010 A
                                     WHERE A.HOSP_CODE     = :f_hosp_code
                                       AND A.Bunho         = :f_bunho
                                       AND (  (:f_reser_yn = 'N' AND A.RESER_DATE IS NULL AND ( A.ORDER_DATE BETWEEN :f_from_date AND :f_to_date))
                                           OR (:f_reser_yn = 'Y' AND A.RESER_DATE BETWEEN :f_from_date AND :f_to_date) )
                                       AND A.JUBSU_DATE IS NOT NULL
                                       AND A.IN_OUT_GUBUN = 'I'
                                       AND A.DOCTOR        = :f_doctor
                                       AND B.HOSP_CODE     = A.HOSP_CODE
                                       AND B.PKOCS2003     = A.FKOCS2003
                                       AND (:f_emergency_yn = 'N' AND NVL(B.EMERGENCY, 'N') = 'N'
                                         OR :f_emergency_yn = 'Y' AND NVL(B.EMERGENCY, 'N') = 'Y')
                                       AND B.DC_YN = 'N' 
                                       AND B.NALSU > 0
                                       AND C.HOSP_CODE     = A.HOSP_CODE
                                       AND C.BUNHO         = A.BUNHO
                                       AND C.JAEWON_DATE   = TRUNC(SYSDATE)
                                     ORDER BY A.ORDER_DATE DESC, A.ORDER_TIME DESC";
            }

//            this.grdPa.QuerySQL = @"SELECT /* grdpa Before Print Lable */
//                                           DISTINCT
//                                           A.ORDER_DATE                         ORDER_DATE
//                                         , A.ORDER_TIME                         ORDER_TIME
//                                         , FN_OCS_LOAD_ORDER_DOCTOR_NAME(NVL(A.FKOCS1003, A.FKOCS2003)) DOCTOR_NAME
//                                         , A.DOCTOR                             DOCTOR
//                                    --   ,  TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')||' '||SUBSTR(A.JUBSU_TIME,1,2)||':'||SUBSTR(A.JUBSU_TIME,3)      JUBSU_DATE,
//                                         , A.JUBSU_DATE
//                                         , A.JUBSU_TIME
//                                         , DECODE(A.JUBSU_DATE,NULL,'1','2')    SEQ
//                                         , A.BUNHO                              BUNHO
//                                         , B.SUNAME                             SUNAME
//                                         , FN_BAS_LOAD_GWA_NAME(E.HO_DONG1,A.ORDER_DATE)      HO_DONG
//                                           --,A.HO_CODE                            HO_CODE
//                                         , E.HO_CODE1                            HO_CODE
//                                         , A.GUBUN                              GUBUN
//                                         , A.GWA                                GWA
//                                         , A.IN_OUT_GUBUN                       IN_OUT_GUBUN
//                                         , D.NOTE_RE                            PA_COMMENT
//                                         , A.RESER_DATE                         RESER_DATE
//                                         , A.JUBSUJA
//                                         , TO_CHAR(A.RESER_DATE, 'YYYY/MM/DD')||RPAD(A.HO_DONG,4,'0')||RPAD(A.HO_CODE,4,'0')||
//                                           RPAD(A.BUNHO,9,'0')||TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')||RPAD(A.ORDER_TIME,4,'0')   KEY
//                                      FROM VW_OCS_INP1001_01 E
//                                         , CPL0111 D
//                                         , CPL1002 C
//                                         , OUT0101 B
//                                         , CPL2010 A
//                                     WHERE A.HOSP_CODE     = :f_hosp_code
//                                       AND B.HOSP_CODE     = A.HOSP_CODE
//                                       AND C.HOSP_CODE(+)  = A.HOSP_CODE
//                                       AND D.HOSP_CODE(+)  = C.HOSP_CODE
//                                       AND E.HOSP_CODE     = A.HOSP_CODE
//                                       AND (  (:f_reser_yn = 'N' AND (  A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                                     OR A.RESER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')))
//                                           OR (:f_reser_yn = 'Y' AND A.RESER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')) )
//                                       AND E.HO_DONG1    LIKE :f_ho_dong
//                                       AND A.IN_OUT_GUBUN = 'I'
//                                       AND DECODE(JUBSU_DATE,NULL,'N','Y') LIKE :f_jubsu_yn
//                                       AND NVL(A.DC_YN,'N') = 'N'
//                                       AND B.BUNHO          = A.BUNHO
//                                       AND C.BUNHO (+)      = A.BUNHO
//                                       AND E.BUNHO          = A.BUNHO
//                                       AND D.JUNDAL_GUBUN(+)= 'PA'
//                                       AND D.CODE(+)        = C.COMMENT_CODE
//                                     ORDER BY A.RESER_DATE, HO_DONG, E.HO_CODE1, A.BUNHO, A.ORDER_DATE DESC, A.ORDER_TIME DESC
//                                    ";

//            this.grdPa.QuerySQL = @"SELECT /* grdpa After Print Lable */
//                                           DISTINCT
//                                           A.ORDER_DATE                         ORDER_DATE,
//                                           A.ORDER_TIME                         ORDER_TIME,
//                                           FN_OCS_LOAD_ORDER_DOCTOR_NAME(NVL(A.FKOCS1003, A.FKOCS2003)) DOCTOR_NAME,
//                                           A.DOCTOR                             DOCTOR,
//                                           TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')||' '||SUBSTR(A.JUBSU_TIME,1,2)||':'||SUBSTR(A.JUBSU_TIME,3)       JUBSU_DATE,
//                                           DECODE(A.JUBSU_DATE,NULL,'1','2')    SEQ,
//                                           A.BUNHO                              BUNHO,
//                                           B.SUNAME                             SUNAME,
//                                           FN_BAS_LOAD_GWA_NAME(A.HO_DONG,A.ORDER_DATE)     HO_DONG,
//                                           A.HO_CODE                            HO_CODE,
//                                           A.GUBUN                              GUBUN,
//                                           A.GWA                                GWA,
//                                           A.IN_OUT_GUBUN                       IN_OUT_GUBUN,
//                                           D.NOTE_RE                            PA_COMMENT,
//                                           A.RESER_DATE                         RESER_DATE,
//                                           A.JUBSUJA                            JUBSUJA
//                                      FROM CPL0111 D,
//                                           CPL1002 C,
//                                           OUT0101 B,
//                                           CPL2010 A
//                                     WHERE A.HOSP_CODE     = :f_hosp_code
//                                       AND B.HOSP_CODE     = A.HOSP_CODE
//                                       AND C.HOSP_CODE(+)  = A.HOSP_CODE
//                                       AND D.HOSP_CODE(+)  = C.HOSP_CODE
//                                       AND (  (:f_reser_yn = 'N' AND (  A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                                     OR A.RESER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')))
//                                           OR (:f_reser_yn = 'Y' AND A.RESER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')) )
//                                       AND A.BUNHO      = :f_bunho
//                                       AND A.HO_DONG    LIKE :f_ho_dong||'%'
//                                       AND NVL(A.DC_YN,'N') = 'N'
//                                       AND DECODE(JUBSU_DATE,NULL,'N','Y') LIKE :f_jubsu_yn
//                                       AND B.BUNHO      = A.BUNHO
//                                       AND C.BUNHO (+)      = A.BUNHO
//                                       AND D.JUNDAL_GUBUN(+)= 'PA'
//                                       AND D.CODE(+)        = C.COMMENT_CODE
//                                     ORDER BY HO_DONG, A.HO_CODE, A.BUNHO, A.ORDER_DATE DESC, A.ORDER_TIME DESC";

            this.grdPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPa.SetBindVarValue("f_from_date", dtpFromOrderDate.GetDataValue());
            this.grdPa.SetBindVarValue("f_to_date", dtpToOrderDate.GetDataValue());
            this.grdPa.SetBindVarValue("f_bunho", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "bunho"));
            //this.grdPa.SetBindVarValue("f_reser_yn", this.cbxReser.GetDataValue());
            this.grdPa.SetBindVarValue("f_reser_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "reser_yn"));
            this.grdPa.SetBindVarValue("f_emergency_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "emergency_yn"));
            this.grdPa.SetBindVarValue("f_doctor", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "doctor"));
            



            //this.grdSpecimen.Reset();
            //if (this.rbxJubsu.Checked == true)
            //    this.grdPa.SetBindVarValue("f_jubsu_yn", "Y");
            //else
            //    this.grdPa.SetBindVarValue("f_jubsu_yn", "N");
        }

        private void grdPa_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.rbxMijubsu.Checked)
            {
                for (int i = 0; i < this.grdPa.RowCount; i++)
                {
                    this.grdPa.SetItemValue(i, "jubsu_date", EnvironInfo.GetSysDate());
                    this.grdPa.SetItemValue(i, "jubsu_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                }
            }
        }

        private void grdSpecimen_QueryStarting(object sender, CancelEventArgs e)
        {
            if (this.rbxMijubsu.Checked == true)// 채혈, 미채혈. 실제로 사용되지 않음... 왜있는거지....?
            {
                this.grdSpecimen.QuerySQL = @"   --  grdSpecimen (before print label) --
                                                SELECT A.PKCPL2010
                                                     , DECODE(A.SUNAB_DATE, NULL, 'N', 'Y')          SUNAB_YN
                                                     , DECODE(A.JUBSU_DATE, NULL, 'N', 'Y')          JUBSU_FLAG
                                                     , F.SLIP_NAME
                                                     , A.HANGMOG_CODE
                                                     , C.GUMSA_NAME
                                                     , A.SPECIMEN_CODE
                                                     , NVL(B.CODE_NAME_RE, B.CODE_NAME)  SPECIMEN_NAME
                                                     , A.EMERGENCY
                                                     , A.TUBE_CODE
                                                     , NVL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME
                                                     , A.SPECIMEN_SER
                                                     --, FN_CPL_SUB_COMMENT(A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)                 COMMENT_JU_CODE
                                                     , FN_XRT_LOAD_COMMENT(A.FKOCS1003, A.FKOCS2003) DOC_COMMENT
                                                     , A.FKOCS2003
                                                     , NVL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN
                                                     , DECODE(A.PART_JUBSU_DATE, NULL, 'N', 'Y')     PART_JUBSU_FLAG
                                                     , DECODE(A.GUM_JUBSU_DATE, NULL, 'N', 'Y')      GUM_JUBSU_FLAG
                                                     , A.DUMMY
                                                     , DECODE(C.GROUP_GUBUN,'03','Y','N')            MODIFY_YN
                                                     , DECODE(A.HANGMOG_CODE,A.GROUP_HANGMOG,DECODE(C.GROUP_GUBUN,'02','N','Y'),'N')    MODIFY_YN_1
                                                     , A.JUNDAL_GUBUN
                                                     , A.JUBSUJA
                                                     , A.ORDER_DATE
                                                     , A.BUNHO
                                                     , A.JUBSU_DATE
                                                     , A.JUBSU_TIME
                                                     , A.ORDER_TIME
                                                     , C.SPCIAL_NAME
                                                     , A.GROUP_HANGMOG
                                                     , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE) BARCODE_NAME
                                                     , C.UITAK_CODE
                                                     , NVL(C.MIDDLE_RESULT, 'N')              MIDDLE_RESULT
                                                  FROM CPL0001 F
                                                     , CPL0109 D
                                                     , CPL0101 C
                                                     , CPL0109 B
                                                     , OCS2003 O
                                                     , CPL2010 A
                                                 WHERE A.HOSP_CODE                = :f_hosp_code
                                                   AND B.HOSP_CODE(+)             = A.HOSP_CODE
                                                   AND C.HOSP_CODE                = A.HOSP_CODE
                                                   AND D.HOSP_CODE(+)             = A.HOSP_CODE
                                                   AND F.HOSP_CODE(+)             = A.HOSP_CODE
                                                   AND A.ORDER_DATE               = :f_order_date
                                                   AND A.BUNHO                    = :f_bunho
                                                   AND A.GWA                      = :f_gwa
                                                   AND A.ORDER_TIME               = :f_order_time
                                                   --AND A.GUBUN                  = :f_gubun
                                                   AND A.DOCTOR                   = :f_doctor
                                                   AND A.IN_OUT_GUBUN             = 'I'
                                                   --AND (  :f_reser_date IS NOT NULL AND A.RESER_DATE = :f_reser_date
                                                   --    OR :f_reser_date IS NULL )
                                                   AND (  :f_reser_yn = 'Y' AND A.RESER_DATE = :f_reser_date
                                                       OR :f_reser_yn = 'N' AND A.RESER_DATE IS NULL)
                                                   AND A.JUBSU_DATE               IS NULL

                                                   --
                                                   AND A.GROUP_SER                = :f_group_ser

                                                   AND NVL(A.DC_YN,'N') = 'N'
                                                   AND ( (A.AFTER_ACT_YN IS NULL) OR
                                                       (A.AFTER_ACT_YN =  'N' ) )
                                                   AND B.CODE(+)                  = A.SPECIMEN_CODE
                                                   AND B.CODE_TYPE(+)             = '04'
                                                   AND C.HANGMOG_CODE             = A.HANGMOG_CODE
                                                   AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE
                                                   AND C.EMERGENCY                = A.EMERGENCY
                                                   AND D.CODE(+)                  = A.TUBE_CODE
                                                   AND D.CODE_TYPE(+)             = '02'
                                                   AND F.SLIP_CODE(+)             = A.SLIP_CODE

                                                   AND O.HOSP_CODE                = A.HOSP_CODE
                                                   AND O.PKOCS2003                = A.FKOCS2003
                                                   AND (:f_emergency_yn = 'N' AND NVL(O.EMERGENCY, 'N') = 'N'
                                                     OR :f_emergency_yn = 'Y' AND NVL(O.EMERGENCY, 'N') = 'Y')
                                                   AND O.DC_YN = 'N' 
                                                   AND O.NALSU > 0
                                                 ORDER BY C.UITAK_CODE,
                                                       LPAD(A.GROUP_HANGMOG,10,'0'),
                                                       DECODE(A.GROUP_HANGMOG, A.HANGMOG_CODE, 1, 2 ),
                                                       LPAD(A.HANGMOG_CODE,10,'0'),
                                                       A.TUBE_CODE,
                                                       A.ORDER_TIME,
                                                       A.JUNDAL_GUBUN,
                                                       A.SPECIMEN_CODE,
                                                       NVL(C.SERIAL,'9999999999')";
            }
            else//채혈
            {
                this.grdSpecimen.QuerySQL = @"   --  grdSpecimen (after print label) --
                                                SELECT A.PKCPL2010
                                                     , DECODE(A.SUNAB_DATE, NULL, 'N', 'Y')             SUNAB_YN
                                                     , DECODE(A.JUBSU_DATE, NULL, 'N', 'Y')          JUBSU_FLAG
                                                     , F.SLIP_NAME
                                                     , A.HANGMOG_CODE
                                                     , C.GUMSA_NAME
                                                     , A.SPECIMEN_CODE
                                                     , NVL(B.CODE_NAME_RE, B.CODE_NAME)  SPECIMEN_NAME
                                                     , A.EMERGENCY
                                                     , A.TUBE_CODE
                                                     , NVL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME
                                                     , A.SPECIMEN_SER
                                                     --, FN_CPL_SUB_COMMENT(A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)                 COMMENT_JU_CODE
                                                     , FN_XRT_LOAD_COMMENT(A.FKOCS1003, A.FKOCS2003) DOC_COMMENT
                                                     , A.FKOCS2003
                                                     , NVL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN
                                                     , DECODE(A.PART_JUBSU_DATE, NULL, 'N', 'Y')     PART_JUBSU_FLAG
                                                     , DECODE(A.GUM_JUBSU_DATE, NULL, 'N', 'Y')      GUM_JUBSU_FLAG
                                                     , A.DUMMY
                                                     , DECODE(C.GROUP_GUBUN,'03','Y','N')            MODIFY_YN
                                                     , DECODE(A.HANGMOG_CODE,A.GROUP_HANGMOG,DECODE(C.GROUP_GUBUN,'02','N','Y'),'N')    MODIFY_YN_1
                                                     , A.JUNDAL_GUBUN
                                                     , A.JUBSUJA
                                                     , A.ORDER_DATE
                                                     , A.BUNHO
                                                     , A.JUBSU_DATE
                                                     , A.JUBSU_TIME
                                                     , A.ORDER_TIME
                                                     , C.SPCIAL_NAME
                                                     , A.GROUP_HANGMOG
                                                     , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE) BARCODE_NAME
                                                     , C.UITAK_CODE
                                                     , NVL(C.MIDDLE_RESULT, 'N')              MIDDLE_RESULT
                                                  FROM CPL0001 F
                                                     , CPL0109 D
                                                     , CPL0101 C
                                                     , CPL0109 B
                                                     , OCS2003 O
                                                     , CPL2010 A
                                                 WHERE A.HOSP_CODE                = :f_hosp_code
                                                   AND B.HOSP_CODE(+)             = A.HOSP_CODE
                                                   AND C.HOSP_CODE                = A.HOSP_CODE
                                                   AND D.HOSP_CODE(+)             = A.HOSP_CODE
                                                   AND F.HOSP_CODE(+)             = A.HOSP_CODE
                                                   AND A.ORDER_DATE               = :f_order_date
                                                   AND A.BUNHO                    = :f_bunho
                                                   AND A.GWA                      = :f_gwa
                                                   AND A.ORDER_TIME               = :f_order_time
                                                   --AND A.GUBUN                    = :f_gubun
                                                   AND A.DOCTOR                   = :f_doctor
                                                   AND A.IN_OUT_GUBUN             = 'I'
                                                   --AND (  :f_reser_date IS NOT NULL AND A.RESER_DATE = :f_reser_date
                                                   --    OR :f_reser_date IS NULL )
                                                   AND (  :f_reser_yn = 'Y' AND A.RESER_DATE = :f_reser_date
                                                       OR :f_reser_yn = 'N' AND A.RESER_DATE IS NULL)
                                                   AND A.JUBSU_DATE               = :f_jubsu_date
                                                   AND A.JUBSU_TIME               = :f_jubsu_time

                                                   --
                                                   AND A.GROUP_SER                = :f_group_ser

                                                   AND NVL(A.DC_YN,'N') = 'N'
                                                   AND ( (A.AFTER_ACT_YN IS NULL) OR
                                                       (A.AFTER_ACT_YN =  'N' ) )
                                                   AND B.CODE(+)                  = A.SPECIMEN_CODE
                                                   AND B.CODE_TYPE(+)             = '04'
                                                   AND C.HANGMOG_CODE             = A.HANGMOG_CODE
                                                   AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE
                                                   AND C.EMERGENCY                = A.EMERGENCY
                                                   AND D.CODE(+)                  = A.TUBE_CODE
                                                   AND D.CODE_TYPE(+)             = '02'
                                                   AND F.SLIP_CODE(+)             = A.SLIP_CODE

                                                   AND O.HOSP_CODE                = A.HOSP_CODE
                                                   AND O.PKOCS2003                = A.FKOCS2003
                                                   AND (:f_emergency_yn = 'N' AND NVL(O.EMERGENCY, 'N') = 'N'
                                                     OR :f_emergency_yn = 'Y' AND NVL(O.EMERGENCY, 'N') = 'Y')
                                                   AND O.DC_YN = 'N' 
                                                   AND O.NALSU > 0
                                                 ORDER BY C.UITAK_CODE,
                                                       LPAD(A.GROUP_HANGMOG,10,'0'),
                                                       DECODE(A.GROUP_HANGMOG, A.HANGMOG_CODE, 1, 2 ),
                                                       LPAD(A.HANGMOG_CODE,10,'0'),
                                                       A.TUBE_CODE,
                                                       A.ORDER_TIME,
                                                       A.JUNDAL_GUBUN,
                                                       A.SPECIMEN_CODE,
                                                       NVL(C.SERIAL,'9999999999')";


            }

            this.grdSpecimen.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSpecimen.SetBindVarValue("f_order_date", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "order_date"));
            this.grdSpecimen.SetBindVarValue("f_bunho", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "bunho"));
            this.grdSpecimen.SetBindVarValue("f_gwa", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "gwa"));
            this.grdSpecimen.SetBindVarValue("f_order_time", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "order_time"));
            this.grdSpecimen.SetBindVarValue("f_doctor", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "doctor"));
            this.grdSpecimen.SetBindVarValue("f_reser_date", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "reser_date"));
            this.grdSpecimen.SetBindVarValue("f_jubsu_date", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jubsu_date"));
            this.grdSpecimen.SetBindVarValue("f_jubsu_time", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jubsu_time"));

            this.grdSpecimen.SetBindVarValue("f_group_ser", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "group_ser"));

            //this.grdSpecimen.SetBindVarValue("f_reser_yn", this.cbxReser.GetDataValue());
            this.grdSpecimen.SetBindVarValue("f_reser_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "reser_yn"));
            this.grdSpecimen.SetBindVarValue("f_emergency_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "emergency_yn"));

        }

        private void txtBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                this.txtBunho.SetEditValue("");
                this.clearGrid();
                return;
            }

            string bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
            this.txtBunho.SetDataValue(bunho);
            this.paBox.SetPatientID(this.txtBunho.GetDataValue());


            // 患者リストから選択されている　患者のオーダ情報取得
            this.grdPa.QueryLayout(false);
        }

        private void clearGrid()
        {
            this.grdPa.Reset();
            this.grdSpecimen.Reset();
            this.grdTube.Reset();
        }

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

        private void grdSpecimen_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.rbxMijubsu.Checked == true) this.MakeJubsu();

            this.setGrdHeaderImage(this.grdSpecimen);
        }

        private void grdSpecimen_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            // 院内検査は「Color.LightSkyBlue」セット
            if (this.grdSpecimen.GetItemString(e.RowNumber, "uitak_code") == "00" && (e.ColName == "hangmog_code"))
            {
                e.BackColor = Color.LightSkyBlue;
            }

            if (e.ColName != "hangmog_code" && this.grdSpecimen.GetItemString(e.RowNumber, "doc_comment") != "")
                e.BackColor = Color.LightPink;
        }

        #region [timer1_Tick] 自動照会関連
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = (this.QueryTime / 1000).ToString();
            this.QueryTime = this.QueryTime - 1000;

            if (QueryTime == 0)
            {
                // 受付TABの場合、再照会
                if (this.rbxMijubsu.Checked) this.grdPaList.QueryLayout(true);
                else
                    // 受付TABが選択される。
                    this.rbxMijubsu.Checked = true;

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
                this.btnUseTimeChk.ImageIndex = 1;
                this.useTimeChkYN = "Y";

                this.timer1.Start();
                this.cboTime.Enabled = true;
                this.tbxTimer.SetDataValue("Y");
                this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
                this.txtTimeInterval.AcceptData();
            }
            else
            {
                this.btnUseTimeChk.ImageIndex = 0;
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
                this.btnUseAlarmChk.ImageIndex = 1;
                this.useAlarmChkYN = "Y";
            }
            else
            {
                this.btnUseAlarmChk.ImageIndex = 0;
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

        #region [btnOrderPrint_Click 患者のオーダ内訳を印刷]
        private void btnOrderPrint_Click(object sender, EventArgs e)
        {
            if (this.grdSpecimen.RowCount < 1) return;

            this.layOrderPrint.Reset();
   //         this.dwOrderPrint.Reset();

            string suname = this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "suname");

            for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            {
                this.layOrderPrint.InsertRow(i);
                this.layOrderPrint.SetItemValue(i, "cnt", (i + 1).ToString());
                this.layOrderPrint.SetItemValue(i, "order_date", this.grdSpecimen.GetItemString(i, "order_date"));
                this.layOrderPrint.SetItemValue(i, "order_time", this.grdSpecimen.GetItemString(i, "order_time"));
                this.layOrderPrint.SetItemValue(i, "bunho", this.txtBunho.GetDataValue());
                this.layOrderPrint.SetItemValue(i, "suname", suname);
                this.layOrderPrint.SetItemValue(i, "suname2", "");
                this.layOrderPrint.SetItemValue(i, "hangmog_code", this.grdSpecimen.GetItemString(i, "hangmog_code"));
                this.layOrderPrint.SetItemValue(i, "hangmog_name", this.grdSpecimen.GetItemString(i, "gumsa_name"));
                this.layOrderPrint.SetItemValue(i, "tube_name", this.grdSpecimen.GetItemString(i, "tube_name"));
            }

        //    this.dwOrderPrint.FillData(this.layOrderPrint.LayoutTable);
       //     this.dwOrderPrint.Print();
        }
        #endregion

        private void CPL2010U01_Closing(object sender, CancelEventArgs e)
        {
            this.timer1.Stop();
        }

        private void btnOrderPrint_Click_1(object sender, EventArgs e)
        {

        }
	}
}

