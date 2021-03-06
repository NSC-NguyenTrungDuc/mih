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

namespace IHIS.NURI
{
	/// <summary>
	/// ORDERTRANS에 대한 요약 설명입니다.
	/// </summary>
    [ToolboxItem(false)]

	public class INPORDERTRANS : IHIS.Framework.XScreen
	{
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
        private XEditGridCell xEditGridCell65;
        private XGridHeader xGridHeader2;
        private XEditGrid grdOCS2003;
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
        private XEditGridCell xEditGridCell78;
        private XButton btnCompar;
        private XButton btnSend;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell128;
        private XPanel xPanel5;
        private XPanel xPanel11;
        private XLabel xLabel9;
        private XPanel xPanel2;
        private XPanel xPanel6;
        private XEditGrid grdInpList;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell130;
        private XEditGridCell xEditGridCell84;
        private XTabControl tabDataGubun;
        private XPanel xPanel4;
        private XRadioButton rbnTrans;
        private XRadioButton rbnMiTrans;
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
        private XEditGridCell xEditGridCell182;
        private MultiLayout layRequisInfo;
        private XEditGridCell xEditGridCell187;
        private XEditGridCell xEditGridCell191;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell192;
        private XEditGridCell xEditGridCell201;
        private XDatePicker dtpJunsongFromDate;
        private XEditGridCell xEditGridCell206;
        private XEditGridCell xEditGridCell207;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private XTextBox txtGongbi_yn;
        private XEditGridCell xEditGridCell226;
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
        private XEditGridCell xEditGridCell249;
        private XDatePicker dtpJunsongToDate;
        private XLabel xLabel10;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XMonthBox monthBox;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGrid grdSiksaList;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell70;
        private IContainer components;

        public INPORDERTRANS()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INPORDERTRANS));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.monthBox = new IHIS.Framework.XMonthBox();
            this.dtpJunsongToDate = new IHIS.Framework.XDatePicker();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.dtpJunsongFromDate = new IHIS.Framework.XDatePicker();
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
            this.grdOCS2003 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell207 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
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
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.grdSiksaList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell187 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell191 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell182 = new IHIS.Framework.XEditGridCell();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.rbnMiTrans = new IHIS.Framework.XRadioButton();
            this.rbnTrans = new IHIS.Framework.XRadioButton();
            this.tabDataGubun = new IHIS.Framework.XTabControl();
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
            this.txtGongbi_yn = new IHIS.Framework.XTextBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layOrderInfo = new IHIS.Framework.MultiLayout();
            this.pnlProgressBar = new IHIS.Framework.XPanel();
            this.lbTransCnt = new System.Windows.Forms.Label();
            this.lbTransHangmog = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.layOut0101 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.btnCompar = new IHIS.Framework.XButton();
            this.btnSend = new IHIS.Framework.XButton();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.layRequisInfo = new IHIS.Framework.MultiLayout();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell206 = new IHIS.Framework.XEditGridCell();
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
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2004)).BeginInit();
            this.pnlWoichul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWoichul)).BeginInit();
            this.pnlSiksa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSiksa)).BeginInit();
            this.pnlJungwa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJungwa)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSiksaList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInpList)).BeginInit();
            this.xPanel4.SuspendLayout();
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
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.monthBox);
            this.xPanel1.Controls.Add(this.dtpJunsongToDate);
            this.xPanel1.Controls.Add(this.xLabel10);
            this.xPanel1.Controls.Add(this.dtpJunsongFromDate);
            this.xPanel1.Controls.Add(this.dtpJunsongDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.dbxSuname);
            this.xPanel1.Controls.Add(this.fbxBunho);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(4, 4);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1101, 34);
            this.xPanel1.TabIndex = 0;
            // 
            // monthBox
            // 
            this.monthBox.Location = new System.Drawing.Point(658, 7);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(122, 21);
            this.monthBox.TabIndex = 4;
            this.monthBox.Visible = false;
            this.monthBox.PrevButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthBox_ButtonClick);
            this.monthBox.NextButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthBox_ButtonClick);
            // 
            // dtpJunsongToDate
            // 
            this.dtpJunsongToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpJunsongToDate.IsJapanYearType = true;
            this.dtpJunsongToDate.Location = new System.Drawing.Point(775, 7);
            this.dtpJunsongToDate.Name = "dtpJunsongToDate";
            this.dtpJunsongToDate.Size = new System.Drawing.Size(118, 20);
            this.dtpJunsongToDate.TabIndex = 11;
            this.dtpJunsongToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpJunsongToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpGijunDate_DataValidating);
            // 
            // xLabel10
            // 
            this.xLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.Location = new System.Drawing.Point(901, 7);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(80, 20);
            this.xLabel10.TabIndex = 10;
            this.xLabel10.Text = "転送日付";
            this.xLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpJunsongFromDate
            // 
            this.dtpJunsongFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpJunsongFromDate.IsJapanYearType = true;
            this.dtpJunsongFromDate.Location = new System.Drawing.Point(657, 7);
            this.dtpJunsongFromDate.Name = "dtpJunsongFromDate";
            this.dtpJunsongFromDate.Size = new System.Drawing.Size(118, 20);
            this.dtpJunsongFromDate.TabIndex = 9;
            this.dtpJunsongFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpJunsongFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpGijunDate_DataValidating);
            // 
            // dtpJunsongDate
            // 
            this.dtpJunsongDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpJunsongDate.IsJapanYearType = true;
            this.dtpJunsongDate.Location = new System.Drawing.Point(981, 7);
            this.dtpJunsongDate.Name = "dtpJunsongDate";
            this.dtpJunsongDate.Size = new System.Drawing.Size(118, 20);
            this.dtpJunsongDate.TabIndex = 1;
            this.dtpJunsongDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel1
            // 
            this.xLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(577, 7);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(80, 20);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "オーダ日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxSuname
            // 
            this.dbxSuname.Font = new System.Drawing.Font("MS UI Gothic", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbxSuname.Location = new System.Drawing.Point(180, 7);
            this.dbxSuname.Name = "dbxSuname";
            this.dbxSuname.Size = new System.Drawing.Size(386, 20);
            this.dbxSuname.TabIndex = 7;
            // 
            // fbxBunho
            // 
            this.fbxBunho.Location = new System.Drawing.Point(81, 7);
            this.fbxBunho.MaxLength = 9;
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.Size = new System.Drawing.Size(100, 20);
            this.fbxBunho.TabIndex = 0;
            this.fbxBunho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunho_DataValidating);
            this.fbxBunho.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunho_FindClick);
            // 
            // xLabel3
            // 
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(2, 7);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(80, 20);
            this.xLabel3.TabIndex = 5;
            this.xLabel3.Text = "患者番号";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkFind
            // 
            this.fwkFind.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkFind.FormText = "保険種別照会";
            this.fwkFind.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkFind.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "gubun";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "保険種別";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "gubun_name";
            this.findColumnInfo2.ColWidth = 150;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "保険種別名";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.pnlGrid);
            this.xPanel3.Controls.Add(this.xPanel5);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(4, 38);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(1101, 722);
            this.xPanel3.TabIndex = 2;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.pnlHelp);
            this.pnlGrid.Controls.Add(this.pnlOrder);
            this.pnlGrid.Controls.Add(this.pnlWoichul);
            this.pnlGrid.Controls.Add(this.pnlSiksa);
            this.pnlGrid.Controls.Add(this.pnlJungwa);
            this.pnlGrid.Controls.Add(this.lbSelectAll);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 346);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1101, 376);
            this.pnlGrid.TabIndex = 2;
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
            this.pnlHelp.Location = new System.Drawing.Point(1019, -2);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(81, 172);
            this.pnlHelp.TabIndex = 14;
            this.pnlHelp.Visible = false;
            // 
            // lblHlep2
            // 
            this.lblHlep2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.SkyBlue);
            this.lblHlep2.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.lblHlep2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHlep2.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Blue);
            this.lblHlep2.Location = new System.Drawing.Point(4, 38);
            this.lblHlep2.Margin = new System.Windows.Forms.Padding(0);
            this.lblHlep2.Name = "lblHlep2";
            this.lblHlep2.Size = new System.Drawing.Size(71, 29);
            this.lblHlep2.TabIndex = 8;
            this.lblHlep2.Text = "実施済み";
            this.lblHlep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHlep4
            // 
            this.lblHlep4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.DarkGray);
            this.lblHlep4.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.lblHlep4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHlep4.Location = new System.Drawing.Point(4, 104);
            this.lblHlep4.Name = "lblHlep4";
            this.lblHlep4.Size = new System.Drawing.Size(71, 29);
            this.lblHlep4.TabIndex = 7;
            this.lblHlep4.Text = "会計済み";
            this.lblHlep4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHlep3
            // 
            this.lblHlep3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.GreenYellow);
            this.lblHlep3.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.lblHlep3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHlep3.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Green);
            this.lblHlep3.Location = new System.Drawing.Point(4, 71);
            this.lblHlep3.Name = "lblHlep3";
            this.lblHlep3.Size = new System.Drawing.Size(71, 29);
            this.lblHlep3.TabIndex = 5;
            this.lblHlep3.Text = "転送成功";
            this.lblHlep3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHlep5
            // 
            this.lblHlep5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Pink);
            this.lblHlep5.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.lblHlep5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHlep5.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.lblHlep5.Location = new System.Drawing.Point(4, 137);
            this.lblHlep5.Name = "lblHlep5";
            this.lblHlep5.Size = new System.Drawing.Size(71, 29);
            this.lblHlep5.TabIndex = 6;
            this.lblHlep5.Text = "転送失敗";
            this.lblHlep5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHlep1
            // 
            this.lblHlep1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            this.lblHlep1.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.lblHlep1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHlep1.Location = new System.Drawing.Point(4, 5);
            this.lblHlep1.Name = "lblHlep1";
            this.lblHlep1.Size = new System.Drawing.Size(71, 29);
            this.lblHlep1.TabIndex = 4;
            this.lblHlep1.Text = "未実施";
            this.lblHlep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.grdOCS2003);
            this.pnlOrder.Controls.Add(this.grdINP2004);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrder.Location = new System.Drawing.Point(0, 36);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1101, 340);
            this.pnlOrder.TabIndex = 7;
            // 
            // grdOCS2003
            // 
            this.grdOCS2003.AddedHeaderLine = 1;
            this.grdOCS2003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell207});
            this.grdOCS2003.ColPerLine = 23;
            this.grdOCS2003.Cols = 24;
            this.grdOCS2003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS2003.FixedCols = 1;
            this.grdOCS2003.FixedRows = 2;
            this.grdOCS2003.HeaderHeights.Add(40);
            this.grdOCS2003.HeaderHeights.Add(0);
            this.grdOCS2003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS2003.Location = new System.Drawing.Point(0, 0);
            this.grdOCS2003.Name = "grdOCS2003";
            this.grdOCS2003.ReadOnly = true;
            this.grdOCS2003.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdOCS2003.RowHeaderVisible = true;
            this.grdOCS2003.Rows = 3;
            this.grdOCS2003.RowStateCheckOnPaint = false;
            this.grdOCS2003.Size = new System.Drawing.Size(1101, 340);
            this.grdOCS2003.TabIndex = 4;
            this.grdOCS2003.ToolTipActive = true;
            this.grdOCS2003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdEdit_MouseDown);
            this.grdOCS2003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2003_QueryEnd);
            this.grdOCS2003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grid_QueryStarting);
            this.grdOCS2003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS2003_GridCellPainting);
            this.grdOCS2003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS2003_RowFocusChanged);
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "pkinp3010";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.HeaderText = "pkinp3010";
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "pkocs";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.HeaderText = "PKOCS";
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "group_ser";
            this.xEditGridCell19.CellWidth = 32;
            this.xEditGridCell19.Col = 6;
            this.xEditGridCell19.HeaderText = "G\r\nR";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell249
            // 
            this.xEditGridCell249.CellName = "group_inp1001";
            this.xEditGridCell249.Col = -1;
            this.xEditGridCell249.HeaderText = "group_inp1001";
            this.xEditGridCell249.IsVisible = false;
            this.xEditGridCell249.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "order_gubun_name";
            this.xEditGridCell102.CellWidth = 71;
            this.xEditGridCell102.Col = 5;
            this.xEditGridCell102.HeaderText = "オ―ダ区分";
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
            this.xEditGridCell20.Col = 7;
            this.xEditGridCell20.HeaderText = "オ―ダコード";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 191;
            this.xEditGridCell21.Col = 8;
            this.xEditGridCell21.HeaderText = "オ―ダ名";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "specimen_code";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.HeaderText = "specimen_code";
            this.xEditGridCell134.IsReadOnly = true;
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "specimen_name";
            this.xEditGridCell22.CellWidth = 63;
            this.xEditGridCell22.Col = 17;
            this.xEditGridCell22.HeaderText = "検体";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "suryang";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell23.CellWidth = 41;
            this.xEditGridCell23.Col = 9;
            this.xEditGridCell23.DecimalDigits = 3;
            this.xEditGridCell23.HeaderText = "数量";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "ord_danui";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.HeaderText = "ord_danui";
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "ord_danui_name";
            this.xEditGridCell24.CellWidth = 41;
            this.xEditGridCell24.Col = 10;
            this.xEditGridCell24.HeaderText = "単位";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.RowSpan = 2;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "dv_time";
            this.xEditGridCell25.CellWidth = 21;
            this.xEditGridCell25.Col = 11;
            this.xEditGridCell25.HeaderText = "dv_time";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.Row = 1;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "dv";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell26.CellWidth = 25;
            this.xEditGridCell26.Col = 12;
            this.xEditGridCell26.HeaderText = "dv";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "nalsu";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell27.CellWidth = 35;
            this.xEditGridCell27.Col = 13;
            this.xEditGridCell27.HeaderText = "日数";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "jusa";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.HeaderText = "jusa";
            this.xEditGridCell136.IsReadOnly = true;
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "jusa_name";
            this.xEditGridCell28.CellWidth = 65;
            this.xEditGridCell28.Col = 14;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell28.HeaderText = "注射";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.RowSpan = 2;
            this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "jusa_spd_name";
            this.xEditGridCell9.CellWidth = 41;
            this.xEditGridCell9.Col = 16;
            this.xEditGridCell9.HeaderText = "注射\r\n速度";
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "bogyong_code";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.HeaderText = "bogyong_code";
            this.xEditGridCell137.IsReadOnly = true;
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "bogyong_name";
            this.xEditGridCell29.CellWidth = 50;
            this.xEditGridCell29.Col = 15;
            this.xEditGridCell29.HeaderText = "用法";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.RowSpan = 2;
            this.xEditGridCell29.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 21;
            this.xEditGridCell32.Col = 19;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.HeaderText = "緊\r\n急";
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jundal_part";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.HeaderText = "jundal_part";
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "wonyoi_order_yn";
            this.xEditGridCell30.CellWidth = 24;
            this.xEditGridCell30.Col = 20;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell30.HeaderText = "院\r\n外";
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell140.CellWidth = 30;
            this.xEditGridCell140.Col = 18;
            this.xEditGridCell140.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell140.HeaderText = "当日\r\n施行";
            this.xEditGridCell140.IsReadOnly = true;
            this.xEditGridCell140.IsUpdatable = false;
            this.xEditGridCell140.RowSpan = 2;
            this.xEditGridCell140.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "ocs_flag";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.HeaderText = "ocs_flag";
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "order_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.HeaderText = "order_gubun";
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "bunho";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.HeaderText = "bunho";
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "order_date";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell48.CellWidth = 95;
            this.xEditGridCell48.Col = 2;
            this.xEditGridCell48.HeaderText = "ｵｰﾀﾞ日付";
            this.xEditGridCell48.IsJapanYearType = true;
            this.xEditGridCell48.RowSpan = 2;
            this.xEditGridCell48.SuppressRepeating = true;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "gwa";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "gwa";
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "doctor";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "doctor";
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "seq";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.HeaderText = "seq";
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "fkocs1003";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.HeaderText = "fkocs1003";
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "sub_susul";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.HeaderText = "sub_susul";
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "acting_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 95;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.HeaderText = "実行日";
            this.xEditGridCell11.IsJapanYearType = true;
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "hope_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.CellWidth = 95;
            this.xEditGridCell31.Col = 3;
            this.xEditGridCell31.HeaderText = "予定日";
            this.xEditGridCell31.IsJapanYearType = true;
            this.xEditGridCell31.RowSpan = 2;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "sunab_date";
            this.xEditGridCell133.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell133.CellWidth = 100;
            this.xEditGridCell133.Col = -1;
            this.xEditGridCell133.HeaderText = "収納日付";
            this.xEditGridCell133.IsJapanYearType = true;
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "home_care_yn";
            this.xEditGridCell146.CellWidth = 31;
            this.xEditGridCell146.Col = 21;
            this.xEditGridCell146.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell146.HeaderText = "在宅\r\n治療";
            this.xEditGridCell146.RowSpan = 2;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "regular_yn";
            this.xEditGridCell147.CellWidth = 25;
            this.xEditGridCell147.Col = 22;
            this.xEditGridCell147.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell147.HeaderText = "定\r\n時";
            this.xEditGridCell147.RowSpan = 2;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "hubal_change_yn";
            this.xEditGridCell148.CellWidth = 35;
            this.xEditGridCell148.Col = 23;
            this.xEditGridCell148.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell148.HeaderText = "後発\r\n不可";
            this.xEditGridCell148.RowSpan = 2;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bun_code";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "bun_code";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "input_control";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "input_control";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "order_gubun_bas";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "order_gubun_bas";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "acting_yn";
            this.xEditGridCell149.CellWidth = 33;
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.HeaderText = "ACTING_YN";
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
            this.xEditGridCell97.CellWidth = 35;
            this.xEditGridCell97.Col = 1;
            this.xEditGridCell97.HeaderText = "転送";
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
            this.xEditGridCell68.HeaderText = "SEND_YN";
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell226
            // 
            this.xEditGridCell226.CellName = "if_flag";
            this.xEditGridCell226.Col = -1;
            this.xEditGridCell226.HeaderText = "if_flag";
            this.xEditGridCell226.IsVisible = false;
            this.xEditGridCell226.Row = -1;
            // 
            // xEditGridCell228
            // 
            this.xEditGridCell228.CellName = "fkifs3014";
            this.xEditGridCell228.Col = -1;
            this.xEditGridCell228.HeaderText = "fkifs3014";
            this.xEditGridCell228.IsVisible = false;
            this.xEditGridCell228.Row = -1;
            // 
            // xEditGridCell207
            // 
            this.xEditGridCell207.CellName = "order_by_key";
            this.xEditGridCell207.Col = -1;
            this.xEditGridCell207.HeaderText = "ORDER_BY_KEY";
            this.xEditGridCell207.IsVisible = false;
            this.xEditGridCell207.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 11;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 21;
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
            this.grdINP2004.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP2004.FixedCols = 1;
            this.grdINP2004.FixedRows = 2;
            this.grdINP2004.HeaderHeights.Add(21);
            this.grdINP2004.HeaderHeights.Add(21);
            this.grdINP2004.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader7,
            this.xGridHeader8});
            this.grdINP2004.Location = new System.Drawing.Point(0, 0);
            this.grdINP2004.Name = "grdINP2004";
            this.grdINP2004.QuerySQL = resources.GetString("grdINP2004.QuerySQL");
            this.grdINP2004.RowHeaderVisible = true;
            this.grdINP2004.Rows = 3;
            this.grdINP2004.Size = new System.Drawing.Size(1101, 340);
            this.grdINP2004.TabIndex = 5;
            this.grdINP2004.Visible = false;
            this.grdINP2004.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP2004_QueryStarting);
            // 
            // xEditGridCell229
            // 
            this.xEditGridCell229.CellName = "bunho";
            this.xEditGridCell229.Col = 1;
            this.xEditGridCell229.HeaderText = "患者番号";
            this.xEditGridCell229.RowSpan = 2;
            // 
            // xEditGridCell230
            // 
            this.xEditGridCell230.CellName = "suname";
            this.xEditGridCell230.Col = 2;
            this.xEditGridCell230.HeaderText = "患者名";
            this.xEditGridCell230.RowSpan = 2;
            // 
            // xEditGridCell231
            // 
            this.xEditGridCell231.CellName = "ipwon_date";
            this.xEditGridCell231.Col = 3;
            this.xEditGridCell231.HeaderText = "入院日";
            this.xEditGridCell231.RowSpan = 2;
            // 
            // xEditGridCell232
            // 
            this.xEditGridCell232.CellName = "data_date";
            this.xEditGridCell232.Col = 4;
            this.xEditGridCell232.HeaderText = "実施日";
            this.xEditGridCell232.RowSpan = 2;
            // 
            // xEditGridCell233
            // 
            this.xEditGridCell233.CellName = "fkinp1001";
            this.xEditGridCell233.Col = -1;
            this.xEditGridCell233.HeaderText = "fkinp1001";
            this.xEditGridCell233.IsVisible = false;
            this.xEditGridCell233.Row = -1;
            // 
            // xEditGridCell234
            // 
            this.xEditGridCell234.CellName = "fkinp1002";
            this.xEditGridCell234.Col = -1;
            this.xEditGridCell234.HeaderText = "fkinp1002";
            this.xEditGridCell234.IsVisible = false;
            this.xEditGridCell234.Row = -1;
            // 
            // xEditGridCell235
            // 
            this.xEditGridCell235.CellName = "from_gwa";
            this.xEditGridCell235.CellWidth = 50;
            this.xEditGridCell235.Col = 5;
            this.xEditGridCell235.HeaderText = "科";
            this.xEditGridCell235.Row = 1;
            // 
            // xEditGridCell237
            // 
            this.xEditGridCell237.CellName = "from_doctor";
            this.xEditGridCell237.CellWidth = 55;
            this.xEditGridCell237.Col = 6;
            this.xEditGridCell237.HeaderText = "医師";
            this.xEditGridCell237.Row = 1;
            // 
            // xEditGridCell239
            // 
            this.xEditGridCell239.CellName = "from_ho_dong";
            this.xEditGridCell239.Col = 7;
            this.xEditGridCell239.HeaderText = "棟";
            this.xEditGridCell239.Row = 1;
            // 
            // xEditGridCell241
            // 
            this.xEditGridCell241.CellName = "from_ho_code";
            this.xEditGridCell241.Col = 8;
            this.xEditGridCell241.HeaderText = "号室";
            this.xEditGridCell241.Row = 1;
            // 
            // xEditGridCell243
            // 
            this.xEditGridCell243.CellName = "from_bed_no";
            this.xEditGridCell243.Col = 9;
            this.xEditGridCell243.HeaderText = "病床";
            this.xEditGridCell243.Row = 1;
            // 
            // xEditGridCell236
            // 
            this.xEditGridCell236.CellName = "to_gwa";
            this.xEditGridCell236.CellWidth = 55;
            this.xEditGridCell236.Col = 10;
            this.xEditGridCell236.HeaderText = "科";
            this.xEditGridCell236.Row = 1;
            // 
            // xEditGridCell238
            // 
            this.xEditGridCell238.CellName = "to_doctor";
            this.xEditGridCell238.Col = 11;
            this.xEditGridCell238.HeaderText = "医師";
            this.xEditGridCell238.Row = 1;
            // 
            // xEditGridCell240
            // 
            this.xEditGridCell240.CellName = "to_ho_dong";
            this.xEditGridCell240.Col = 12;
            this.xEditGridCell240.HeaderText = "棟";
            this.xEditGridCell240.Row = 1;
            // 
            // xEditGridCell242
            // 
            this.xEditGridCell242.CellName = "to_ho_code";
            this.xEditGridCell242.Col = 13;
            this.xEditGridCell242.HeaderText = "号室";
            this.xEditGridCell242.Row = 1;
            // 
            // xEditGridCell244
            // 
            this.xEditGridCell244.CellName = "to_bed_no";
            this.xEditGridCell244.Col = 14;
            this.xEditGridCell244.HeaderText = "病床";
            this.xEditGridCell244.Row = 1;
            // 
            // xEditGridCell245
            // 
            this.xEditGridCell245.CellName = "send_yn";
            this.xEditGridCell245.Col = -1;
            this.xEditGridCell245.HeaderText = "send_yn";
            this.xEditGridCell245.IsVisible = false;
            this.xEditGridCell245.Row = -1;
            // 
            // xEditGridCell246
            // 
            this.xEditGridCell246.CellName = "if_flag";
            this.xEditGridCell246.Col = -1;
            this.xEditGridCell246.HeaderText = "if_flag";
            this.xEditGridCell246.IsVisible = false;
            this.xEditGridCell246.Row = -1;
            // 
            // xGridHeader7
            // 
            this.xGridHeader7.Col = 5;
            this.xGridHeader7.ColSpan = 5;
            this.xGridHeader7.HeaderText = "From";
            this.xGridHeader7.HeaderWidth = 50;
            // 
            // xGridHeader8
            // 
            this.xGridHeader8.Col = 10;
            this.xGridHeader8.ColSpan = 5;
            this.xGridHeader8.HeaderText = "To";
            this.xGridHeader8.HeaderWidth = 55;
            // 
            // pnlWoichul
            // 
            this.pnlWoichul.Controls.Add(this.grdWoichul);
            this.pnlWoichul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWoichul.Location = new System.Drawing.Point(0, 36);
            this.pnlWoichul.Name = "pnlWoichul";
            this.pnlWoichul.Size = new System.Drawing.Size(1101, 340);
            this.pnlWoichul.TabIndex = 10;
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
            this.grdWoichul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWoichul.FixedCols = 1;
            this.grdWoichul.FixedRows = 2;
            this.grdWoichul.HeaderHeights.Add(35);
            this.grdWoichul.HeaderHeights.Add(0);
            this.grdWoichul.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader3,
            this.xGridHeader4,
            this.xGridHeader5});
            this.grdWoichul.Location = new System.Drawing.Point(0, 0);
            this.grdWoichul.Name = "grdWoichul";
            this.grdWoichul.QuerySQL = resources.GetString("grdWoichul.QuerySQL");
            this.grdWoichul.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdWoichul.RowHeaderVisible = true;
            this.grdWoichul.Rows = 3;
            this.grdWoichul.RowStateCheckOnPaint = false;
            this.grdWoichul.Size = new System.Drawing.Size(1101, 340);
            this.grdWoichul.TabIndex = 4;
            this.grdWoichul.ToolTipActive = true;
            this.grdWoichul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdEdit_MouseDown);
            this.grdWoichul.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grid_QueryStarting);
            this.grdWoichul.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdWoichul_GridColumnProtectModify);
            this.grdWoichul.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdWoichul_GridColumnChanged);
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "pkINP1001";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.HeaderText = "pkINP1001";
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "pkocs";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.HeaderText = "FKINP1001";
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "bunho";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.HeaderText = "患者番号";
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
            this.xEditGridCell122.HeaderText = "開始日付";
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
            this.xEditGridCell123.HeaderText = "時間";
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
            this.xEditGridCell124.HeaderText = "終了日付";
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
            this.xEditGridCell125.HeaderText = "時間";
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
            this.xEditGridCell99.HeaderText = "帰室日付";
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
            this.xEditGridCell100.HeaderText = "時間";
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
            this.xEditGridCell98.HeaderText = "外泊目的";
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
            this.xEditGridCell105.HeaderText = "確定開始日付";
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
            this.xEditGridCell118.HeaderText = "確定終了日付";
            this.xEditGridCell118.IsJapanYearType = true;
            this.xEditGridCell118.RowSpan = 2;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "acting_yn";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "acting_yn";
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
            this.xEditGridCell127.HeaderText = "転送";
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
            this.xEditGridCell82.HeaderText = "SEND_YN";
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell192
            // 
            this.xEditGridCell192.CellName = "seq";
            this.xEditGridCell192.Col = -1;
            this.xEditGridCell192.HeaderText = "SEQ";
            this.xEditGridCell192.IsVisible = false;
            this.xEditGridCell192.Row = -1;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 2;
            this.xGridHeader3.ColSpan = 2;
            this.xGridHeader3.HeaderText = "外泊開始日時";
            this.xGridHeader3.HeaderWidth = 100;
            // 
            // xGridHeader4
            // 
            this.xGridHeader4.Col = 4;
            this.xGridHeader4.ColSpan = 2;
            this.xGridHeader4.HeaderText = "終了予定日時";
            this.xGridHeader4.HeaderWidth = 100;
            // 
            // xGridHeader5
            // 
            this.xGridHeader5.Col = 6;
            this.xGridHeader5.ColSpan = 2;
            this.xGridHeader5.HeaderText = "帰室日時";
            this.xGridHeader5.HeaderWidth = 100;
            // 
            // pnlSiksa
            // 
            this.pnlSiksa.Controls.Add(this.grdSiksa);
            this.pnlSiksa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSiksa.Location = new System.Drawing.Point(0, 36);
            this.pnlSiksa.Name = "pnlSiksa";
            this.pnlSiksa.Size = new System.Drawing.Size(1101, 340);
            this.pnlSiksa.TabIndex = 9;
            // 
            // grdSiksa
            // 
            this.grdSiksa.AddedHeaderLine = 1;
            this.grdSiksa.CallerID = '2';
            this.grdSiksa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell85,
            this.xEditGridCell18,
            this.xEditGridCell4,
            this.xEditGridCell15,
            this.xEditGridCell94,
            this.xEditGridCell17,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell65,
            this.xEditGridCell91});
            this.grdSiksa.ColPerLine = 6;
            this.grdSiksa.Cols = 7;
            this.grdSiksa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSiksa.FixedCols = 1;
            this.grdSiksa.FixedRows = 2;
            this.grdSiksa.HeaderHeights.Add(21);
            this.grdSiksa.HeaderHeights.Add(19);
            this.grdSiksa.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdSiksa.Location = new System.Drawing.Point(0, 0);
            this.grdSiksa.Name = "grdSiksa";
            this.grdSiksa.ReadOnly = true;
            this.grdSiksa.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdSiksa.RowHeaderVisible = true;
            this.grdSiksa.Rows = 3;
            this.grdSiksa.RowStateCheckOnPaint = false;
            this.grdSiksa.Size = new System.Drawing.Size(1101, 340);
            this.grdSiksa.TabIndex = 4;
            this.grdSiksa.ToolTipActive = true;
            this.grdSiksa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grid_QueryStarting);
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "bunho";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.HeaderText = "患者番号";
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "pkocs";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "pkocs";
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "fkinp1001";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "fkinp1001";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 20;
            this.xEditGridCell15.CellName = "group_inp1001";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "group_inp1001";
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "order_date";
            this.xEditGridCell94.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell94.CellWidth = 121;
            this.xEditGridCell94.Col = 2;
            this.xEditGridCell94.HeaderText = "最終オーダ日付";
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.RowSpan = 2;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "drt_date";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell17.CellWidth = 132;
            this.xEditGridCell17.Col = 3;
            this.xEditGridCell17.HeaderText = "指示日付";
            this.xEditGridCell17.IsJapanYearType = true;
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 30;
            this.xEditGridCell6.CellName = "siksa_gubun1";
            this.xEditGridCell6.CellWidth = 180;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.HeaderText = "朝食";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.Row = 1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 30;
            this.xEditGridCell7.CellName = "siksa_gubun2";
            this.xEditGridCell7.CellWidth = 180;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.HeaderText = "昼食";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.Row = 1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 30;
            this.xEditGridCell8.CellName = "siksa_gubun3";
            this.xEditGridCell8.CellWidth = 180;
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.HeaderText = "夕食";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.Row = 1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell65.AlterateRowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell65.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell65.CellName = "select";
            this.xEditGridCell65.CellWidth = 36;
            this.xEditGridCell65.Col = 1;
            this.xEditGridCell65.HeaderText = "転送";
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell65.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell65.RowSpan = 2;
            this.xEditGridCell65.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "send_yn";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.HeaderText = "SEND_YN";
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 4;
            this.xGridHeader2.ColSpan = 3;
            this.xGridHeader2.HeaderText = "食事区分";
            this.xGridHeader2.HeaderWidth = 180;
            // 
            // pnlJungwa
            // 
            this.pnlJungwa.Controls.Add(this.grdJungwa);
            this.pnlJungwa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJungwa.Location = new System.Drawing.Point(0, 36);
            this.pnlJungwa.Name = "pnlJungwa";
            this.pnlJungwa.Size = new System.Drawing.Size(1101, 340);
            this.pnlJungwa.TabIndex = 7;
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
            this.grdJungwa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJungwa.FixedCols = 1;
            this.grdJungwa.FixedRows = 1;
            this.grdJungwa.HeaderHeights.Add(33);
            this.grdJungwa.Location = new System.Drawing.Point(0, 0);
            this.grdJungwa.Name = "grdJungwa";
            this.grdJungwa.ReadOnly = true;
            this.grdJungwa.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdJungwa.RowHeaderVisible = true;
            this.grdJungwa.Rows = 2;
            this.grdJungwa.RowStateCheckOnPaint = false;
            this.grdJungwa.Size = new System.Drawing.Size(1101, 340);
            this.grdJungwa.TabIndex = 7;
            this.grdJungwa.ToolTipActive = true;
            this.grdJungwa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdEdit_MouseDown);
            this.grdJungwa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grid_QueryStarting);
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "pkINP1001";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.HeaderText = "pkINP1001";
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "pkocs";
            this.xEditGridCell106.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell106.CellWidth = 41;
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.HeaderText = "fkinp1001";
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "bunho";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.HeaderText = "患者番号";
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "order_date";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell66.CellWidth = 110;
            this.xEditGridCell66.Col = 2;
            this.xEditGridCell66.HeaderText = "転科転室日付";
            this.xEditGridCell66.IsJapanYearType = true;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "from_gwa";
            this.xEditGridCell107.CellWidth = 90;
            this.xEditGridCell107.Col = 12;
            this.xEditGridCell107.HeaderText = "前診療科";
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "to_gwa";
            this.xEditGridCell108.CellWidth = 90;
            this.xEditGridCell108.Col = 7;
            this.xEditGridCell108.HeaderText = "診療科";
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "from_doctor";
            this.xEditGridCell109.CellWidth = 115;
            this.xEditGridCell109.Col = 13;
            this.xEditGridCell109.HeaderText = "前主治医";
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "to_doctor";
            this.xEditGridCell110.CellWidth = 115;
            this.xEditGridCell110.Col = 8;
            this.xEditGridCell110.HeaderText = "主治医";
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "from_ho_dong";
            this.xEditGridCell111.Col = 9;
            this.xEditGridCell111.HeaderText = "前病棟";
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "to_ho_dong";
            this.xEditGridCell112.Col = 4;
            this.xEditGridCell112.HeaderText = "病棟";
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "from_ho_code";
            this.xEditGridCell113.Col = 10;
            this.xEditGridCell113.HeaderText = "前病室";
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "to_ho_code";
            this.xEditGridCell114.Col = 5;
            this.xEditGridCell114.HeaderText = "病室";
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "seq";
            this.xEditGridCell115.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.HeaderText = "順番";
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "trans_time";
            this.xEditGridCell116.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell116.CellWidth = 60;
            this.xEditGridCell116.Col = 3;
            this.xEditGridCell116.HeaderText = "時間";
            this.xEditGridCell116.Mask = "HH:MI";
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "from_bed_no";
            this.xEditGridCell117.CellWidth = 60;
            this.xEditGridCell117.Col = 11;
            this.xEditGridCell117.HeaderText = "前ベッド";
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "to_bed_no";
            this.xEditGridCell96.CellWidth = 60;
            this.xEditGridCell96.Col = 6;
            this.xEditGridCell96.HeaderText = "ベッド";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "acting_yn";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "acting_yn";
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
            this.xEditGridCell103.HeaderText = "転送";
            this.xEditGridCell103.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell103.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell103.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "send_yn";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.HeaderText = "SEND_YN";
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // lbSelectAll
            // 
            this.lbSelectAll.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbSelectAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSelectAll.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lbSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("lbSelectAll.Image")));
            this.lbSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbSelectAll.ImageIndex = 1;
            this.lbSelectAll.ImageList = this.ImageList;
            this.lbSelectAll.Location = new System.Drawing.Point(0, 0);
            this.lbSelectAll.Name = "lbSelectAll";
            this.lbSelectAll.Size = new System.Drawing.Size(1101, 36);
            this.lbSelectAll.TabIndex = 6;
            this.lbSelectAll.Tag = "N";
            this.lbSelectAll.Text = "全体選択";
            this.lbSelectAll.Visible = false;
            this.lbSelectAll.Click += new System.EventHandler(this.lbSelectAll_Click);
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.xPanel2);
            this.xPanel5.Controls.Add(this.xPanel11);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel5.Location = new System.Drawing.Point(0, 0);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(1101, 346);
            this.xPanel5.TabIndex = 3;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xPanel6);
            this.xPanel2.Controls.Add(this.tabDataGubun);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel2.Location = new System.Drawing.Point(0, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1101, 314);
            this.xPanel2.TabIndex = 1;
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.grdSiksaList);
            this.xPanel6.Controls.Add(this.grdInpList);
            this.xPanel6.Controls.Add(this.xPanel4);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel6.Location = new System.Drawing.Point(0, 25);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(1101, 289);
            this.xPanel6.TabIndex = 9;
            // 
            // grdSiksaList
            // 
            this.grdSiksaList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell46,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell67,
            this.xEditGridCell69,
            this.xEditGridCell70});
            this.grdSiksaList.ColPerLine = 10;
            this.grdSiksaList.Cols = 11;
            this.grdSiksaList.ControlBinding = true;
            this.grdSiksaList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSiksaList.FixedCols = 1;
            this.grdSiksaList.FixedRows = 1;
            this.grdSiksaList.HeaderHeights.Add(28);
            this.grdSiksaList.Location = new System.Drawing.Point(0, 37);
            this.grdSiksaList.Name = "grdSiksaList";
            this.grdSiksaList.ReadOnly = true;
            this.grdSiksaList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdSiksaList.RowHeaderVisible = true;
            this.grdSiksaList.Rows = 2;
            this.grdSiksaList.RowStateCheckOnPaint = false;
            this.grdSiksaList.Size = new System.Drawing.Size(1101, 252);
            this.grdSiksaList.TabIndex = 4;
            this.grdSiksaList.ToolTipActive = true;
            this.grdSiksaList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdList_MouseDown);
            this.grdSiksaList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdSiksaList_QueryEnd);
            this.grdSiksaList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            this.grdSiksaList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "pkinp1001";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.HeaderText = "pkinp1001";
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "bunho";
            this.xEditGridCell38.Col = 2;
            this.xEditGridCell38.HeaderText = "患者番号";
            this.xEditGridCell38.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "suname";
            this.xEditGridCell39.CellWidth = 131;
            this.xEditGridCell39.Col = 3;
            this.xEditGridCell39.HeaderText = "患者氏名";
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "ipwon_date";
            this.xEditGridCell42.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell42.CellWidth = 95;
            this.xEditGridCell42.Col = 8;
            this.xEditGridCell42.HeaderText = "入院日付";
            this.xEditGridCell42.IsJapanYearType = true;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "ipwon_time";
            this.xEditGridCell43.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell43.CellWidth = 55;
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.HeaderText = "入院時間";
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Mask = "HH:MI";
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "gwa";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.HeaderText = "診療科コード";
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "doctor";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.HeaderText = "診療医コード";
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "gwa_name";
            this.xEditGridCell51.CellWidth = 94;
            this.xEditGridCell51.Col = 4;
            this.xEditGridCell51.HeaderText = "診療科";
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "doctor_name";
            this.xEditGridCell52.CellWidth = 105;
            this.xEditGridCell52.Col = 5;
            this.xEditGridCell52.HeaderText = "診療医";
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "ho_dong";
            this.xEditGridCell56.CellWidth = 72;
            this.xEditGridCell56.Col = 6;
            this.xEditGridCell56.HeaderText = "病棟";
            this.xEditGridCell56.IsReadOnly = true;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "ho_code";
            this.xEditGridCell57.Col = 7;
            this.xEditGridCell57.HeaderText = "病室";
            this.xEditGridCell57.IsReadOnly = true;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "send_date";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell67.CellWidth = 95;
            this.xEditGridCell67.Col = 9;
            this.xEditGridCell67.HeaderText = "最終転送日";
            this.xEditGridCell67.IsJapanYearType = true;
            this.xEditGridCell67.IsReadOnly = true;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "trans_yn";
            this.xEditGridCell69.CellWidth = 100;
            this.xEditGridCell69.Col = 10;
            this.xEditGridCell69.HeaderText = "未転送データ";
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.RowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell69.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.CornflowerBlue);
            this.xEditGridCell69.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell70.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell70.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell70.AlterateRowImageIndex = 0;
            this.xEditGridCell70.CellName = "select";
            this.xEditGridCell70.CellWidth = 30;
            this.xEditGridCell70.Col = 1;
            this.xEditGridCell70.HeaderText = "選択";
            this.xEditGridCell70.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell70.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell70.RowImageIndex = 0;
            this.xEditGridCell70.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
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
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell2,
            this.xEditGridCell187,
            this.xEditGridCell1,
            this.xEditGridCell84,
            this.xEditGridCell191,
            this.xEditGridCell3,
            this.xEditGridCell182});
            this.grdInpList.ColPerLine = 12;
            this.grdInpList.Cols = 13;
            this.grdInpList.ControlBinding = true;
            this.grdInpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInpList.FixedCols = 1;
            this.grdInpList.FixedRows = 1;
            this.grdInpList.HeaderHeights.Add(28);
            this.grdInpList.Location = new System.Drawing.Point(0, 37);
            this.grdInpList.Name = "grdInpList";
            this.grdInpList.ReadOnly = true;
            this.grdInpList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdInpList.RowHeaderVisible = true;
            this.grdInpList.Rows = 2;
            this.grdInpList.RowStateCheckOnPaint = false;
            this.grdInpList.Size = new System.Drawing.Size(1101, 252);
            this.grdInpList.TabIndex = 3;
            this.grdInpList.ToolTipActive = true;
            this.grdInpList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdList_MouseDown);
            this.grdInpList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            this.grdInpList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdList_GridCellPainting);
            this.grdInpList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "pkinp1001";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.HeaderText = "pkinp1001";
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "bunho";
            this.xEditGridCell126.Col = 2;
            this.xEditGridCell126.HeaderText = "患者番号";
            this.xEditGridCell126.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "suname";
            this.xEditGridCell142.CellWidth = 131;
            this.xEditGridCell142.Col = 3;
            this.xEditGridCell142.HeaderText = "患者氏名";
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ipwon_date";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell104.CellWidth = 95;
            this.xEditGridCell104.Col = 8;
            this.xEditGridCell104.HeaderText = "入院日付";
            this.xEditGridCell104.IsJapanYearType = true;
            // 
            // xEditGridCell201
            // 
            this.xEditGridCell201.CellName = "ipwon_time";
            this.xEditGridCell201.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell201.CellWidth = 55;
            this.xEditGridCell201.Col = -1;
            this.xEditGridCell201.HeaderText = "入院時間";
            this.xEditGridCell201.IsVisible = false;
            this.xEditGridCell201.Mask = "HH:MI";
            this.xEditGridCell201.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "gwa";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.HeaderText = "診療科コード";
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "doctor";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.HeaderText = "診療医コード";
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "gwa_name";
            this.xEditGridCell129.CellWidth = 94;
            this.xEditGridCell129.Col = 4;
            this.xEditGridCell129.HeaderText = "診療科";
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "doctor_name";
            this.xEditGridCell130.CellWidth = 105;
            this.xEditGridCell130.Col = 5;
            this.xEditGridCell130.HeaderText = "診療医";
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "ho_dong";
            this.xEditGridCell35.CellWidth = 72;
            this.xEditGridCell35.Col = 6;
            this.xEditGridCell35.HeaderText = "病棟";
            this.xEditGridCell35.IsReadOnly = true;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "ho_code";
            this.xEditGridCell36.Col = 7;
            this.xEditGridCell36.HeaderText = "病室";
            this.xEditGridCell36.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "gubun";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "保険類型";
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell187
            // 
            this.xEditGridCell187.CellName = "order_date";
            this.xEditGridCell187.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell187.CellWidth = 95;
            this.xEditGridCell187.Col = 9;
            this.xEditGridCell187.HeaderText = "オーダ日付";
            this.xEditGridCell187.IsJapanYearType = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "acting_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 95;
            this.xEditGridCell1.Col = 10;
            this.xEditGridCell1.HeaderText = "実施日付";
            this.xEditGridCell1.IsJapanYearType = true;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "pkinp3010";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.HeaderText = "pkinp3010";
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell191
            // 
            this.xEditGridCell191.CellName = "send_date";
            this.xEditGridCell191.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell191.CellWidth = 95;
            this.xEditGridCell191.Col = 11;
            this.xEditGridCell191.HeaderText = "転送日付";
            this.xEditGridCell191.IsJapanYearType = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 1;
            this.xEditGridCell3.CellName = "toiwon_yn";
            this.xEditGridCell3.CellWidth = 35;
            this.xEditGridCell3.Col = 12;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell3.HeaderText = "退院";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.xEditGridCell182.HeaderText = "選択";
            this.xEditGridCell182.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell182.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell182.RowImageIndex = 0;
            this.xEditGridCell182.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.rbnMiTrans);
            this.xPanel4.Controls.Add(this.rbnTrans);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel4.Location = new System.Drawing.Point(0, 0);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(1101, 37);
            this.xPanel4.TabIndex = 0;
            // 
            // rbnMiTrans
            // 
            this.rbnMiTrans.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnMiTrans.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbnMiTrans.Checked = true;
            this.rbnMiTrans.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnMiTrans.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbnMiTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnMiTrans.ImageList = this.ImageList;
            this.rbnMiTrans.Location = new System.Drawing.Point(2, 3);
            this.rbnMiTrans.Name = "rbnMiTrans";
            this.rbnMiTrans.Size = new System.Drawing.Size(186, 32);
            this.rbnMiTrans.TabIndex = 0;
            this.rbnMiTrans.TabStop = true;
            this.rbnMiTrans.Text = "未転送";
            this.rbnMiTrans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnMiTrans.UseVisualStyleBackColor = false;
            this.rbnMiTrans.CheckedChanged += new System.EventHandler(this.RadioTrans_CheckedChanged);
            // 
            // rbnTrans
            // 
            this.rbnTrans.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnTrans.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnTrans.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnTrans.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnTrans.ImageList = this.ImageList;
            this.rbnTrans.Location = new System.Drawing.Point(187, 3);
            this.rbnTrans.Name = "rbnTrans";
            this.rbnTrans.Size = new System.Drawing.Size(186, 32);
            this.rbnTrans.TabIndex = 1;
            this.rbnTrans.Text = "転送済";
            this.rbnTrans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnTrans.UseVisualStyleBackColor = false;
            this.rbnTrans.CheckedChanged += new System.EventHandler(this.RadioTrans_CheckedChanged);
            // 
            // tabDataGubun
            // 
            this.tabDataGubun.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabDataGubun.IDEPixelArea = true;
            this.tabDataGubun.IDEPixelBorder = false;
            this.tabDataGubun.Location = new System.Drawing.Point(0, 0);
            this.tabDataGubun.Name = "tabDataGubun";
            this.tabDataGubun.ShowArrows = false;
            this.tabDataGubun.ShowClose = false;
            this.tabDataGubun.Size = new System.Drawing.Size(1101, 25);
            this.tabDataGubun.TabIndex = 8;
            // 
            // xPanel11
            // 
            this.xPanel11.Controls.Add(this.btnHelp);
            this.xPanel11.Controls.Add(this.pnlSang);
            this.xPanel11.Controls.Add(this.cboSangCode);
            this.xPanel11.Controls.Add(this.xLabel9);
            this.xPanel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel11.DrawBorder = true;
            this.xPanel11.Location = new System.Drawing.Point(0, 314);
            this.xPanel11.Name = "xPanel11";
            this.xPanel11.Size = new System.Drawing.Size(1101, 32);
            this.xPanel11.TabIndex = 4;
            // 
            // btnHelp
            // 
            this.btnHelp.ImageIndex = 15;
            this.btnHelp.ImageList = this.ImageList;
            this.btnHelp.Location = new System.Drawing.Point(1021, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "ヘルプ";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // pnlSang
            // 
            this.pnlSang.Controls.Add(this.grdOutSang);
            this.pnlSang.Location = new System.Drawing.Point(0, 32);
            this.pnlSang.Name = "pnlSang";
            this.pnlSang.Size = new System.Drawing.Size(1049, 0);
            this.pnlSang.TabIndex = 2;
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
            this.grdOutSang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOutSang.FixedRows = 2;
            this.grdOutSang.HeaderHeights.Add(21);
            this.grdOutSang.HeaderHeights.Add(0);
            this.grdOutSang.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader6});
            this.grdOutSang.Location = new System.Drawing.Point(0, 0);
            this.grdOutSang.Name = "grdOutSang";
            this.grdOutSang.QuerySQL = resources.GetString("grdOutSang.QuerySQL");
            this.grdOutSang.Rows = 3;
            this.grdOutSang.Size = new System.Drawing.Size(1049, 0);
            this.grdOutSang.TabIndex = 0;
            this.grdOutSang.Visible = false;
            this.grdOutSang.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOutSang_QueryStarting);
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "bunho";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.HeaderText = "bunho";
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "gwa";
            this.xEditGridCell132.CellWidth = 100;
            this.xEditGridCell132.Col = 3;
            this.xEditGridCell132.HeaderText = "gwa";
            this.xEditGridCell132.IsReadOnly = true;
            this.xEditGridCell132.Row = 1;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "gwa_name";
            this.xEditGridCell138.CellWidth = 100;
            this.xEditGridCell138.Col = 4;
            this.xEditGridCell138.HeaderText = "gwa_name";
            this.xEditGridCell138.IsReadOnly = true;
            this.xEditGridCell138.Row = 1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "io_gubun";
            this.xEditGridCell139.Col = -1;
            this.xEditGridCell139.HeaderText = "io_gubun";
            this.xEditGridCell139.IsVisible = false;
            this.xEditGridCell139.Row = -1;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "pk_seq";
            this.xEditGridCell141.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell141.Col = -1;
            this.xEditGridCell141.HeaderText = "pk_seq";
            this.xEditGridCell141.IsVisible = false;
            this.xEditGridCell141.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "ser";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.HeaderText = "ser";
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellLen = 7;
            this.xEditGridCell144.CellName = "sang_code";
            this.xEditGridCell144.CellWidth = 100;
            this.xEditGridCell144.Col = 1;
            this.xEditGridCell144.HeaderText = "傷病コード";
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
            this.xEditGridCell145.HeaderText = "傷病コード名";
            this.xEditGridCell145.IsReadOnly = true;
            this.xEditGridCell145.RowSpan = 2;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellLen = 200;
            this.xEditGridCell150.CellName = "sang_name";
            this.xEditGridCell150.Col = -1;
            this.xEditGridCell150.HeaderText = "sang_name";
            this.xEditGridCell150.IsVisible = false;
            this.xEditGridCell150.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellLen = 4;
            this.xEditGridCell151.CellName = "pre_modifier1";
            this.xEditGridCell151.Col = -1;
            this.xEditGridCell151.HeaderText = "pre_modifier1";
            this.xEditGridCell151.IsVisible = false;
            this.xEditGridCell151.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellLen = 4;
            this.xEditGridCell152.CellName = "pre_modifier2";
            this.xEditGridCell152.Col = -1;
            this.xEditGridCell152.HeaderText = "pre_modifier2";
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellLen = 4;
            this.xEditGridCell153.CellName = "pre_modifier3";
            this.xEditGridCell153.Col = -1;
            this.xEditGridCell153.HeaderText = "pre_modifier3";
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellLen = 4;
            this.xEditGridCell154.CellName = "pre_modifier4";
            this.xEditGridCell154.Col = -1;
            this.xEditGridCell154.HeaderText = "pre_modifier4";
            this.xEditGridCell154.IsVisible = false;
            this.xEditGridCell154.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellLen = 4;
            this.xEditGridCell155.CellName = "pre_modifier5";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.HeaderText = "pre_modifier5";
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellLen = 4;
            this.xEditGridCell156.CellName = "pre_modifier6";
            this.xEditGridCell156.Col = -1;
            this.xEditGridCell156.HeaderText = "pre_modifier6";
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellLen = 4;
            this.xEditGridCell157.CellName = "pre_modifier7";
            this.xEditGridCell157.Col = -1;
            this.xEditGridCell157.HeaderText = "pre_modifier7";
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellLen = 4;
            this.xEditGridCell158.CellName = "pre_modifier8";
            this.xEditGridCell158.Col = -1;
            this.xEditGridCell158.HeaderText = "pre_modifier8";
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellLen = 4;
            this.xEditGridCell159.CellName = "pre_modifier9";
            this.xEditGridCell159.Col = -1;
            this.xEditGridCell159.HeaderText = "pre_modifier9";
            this.xEditGridCell159.IsVisible = false;
            this.xEditGridCell159.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellLen = 4;
            this.xEditGridCell160.CellName = "pre_modifier10";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.HeaderText = "pre_modifier10";
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellLen = 500;
            this.xEditGridCell161.CellName = "pre_modifier_name";
            this.xEditGridCell161.Col = -1;
            this.xEditGridCell161.HeaderText = "pre_modifier_name";
            this.xEditGridCell161.IsVisible = false;
            this.xEditGridCell161.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellLen = 4;
            this.xEditGridCell162.CellName = "post_modifier1";
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.HeaderText = "post_modifier1";
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellLen = 4;
            this.xEditGridCell163.CellName = "post_modifier2";
            this.xEditGridCell163.Col = -1;
            this.xEditGridCell163.HeaderText = "post_modifier2";
            this.xEditGridCell163.IsVisible = false;
            this.xEditGridCell163.Row = -1;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellLen = 4;
            this.xEditGridCell164.CellName = "post_modifier3";
            this.xEditGridCell164.Col = -1;
            this.xEditGridCell164.HeaderText = "post_modifier3";
            this.xEditGridCell164.IsVisible = false;
            this.xEditGridCell164.Row = -1;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.CellLen = 4;
            this.xEditGridCell165.CellName = "post_modifier4";
            this.xEditGridCell165.Col = -1;
            this.xEditGridCell165.HeaderText = "post_modifier4";
            this.xEditGridCell165.IsVisible = false;
            this.xEditGridCell165.Row = -1;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellLen = 4;
            this.xEditGridCell166.CellName = "post_modifier5";
            this.xEditGridCell166.Col = -1;
            this.xEditGridCell166.HeaderText = "post_modifier5";
            this.xEditGridCell166.IsVisible = false;
            this.xEditGridCell166.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellLen = 4;
            this.xEditGridCell167.CellName = "post_modifier6";
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.HeaderText = "post_modifier6";
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellLen = 4;
            this.xEditGridCell168.CellName = "post_modifier7";
            this.xEditGridCell168.Col = -1;
            this.xEditGridCell168.HeaderText = "post_modifier7";
            this.xEditGridCell168.IsVisible = false;
            this.xEditGridCell168.Row = -1;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellLen = 4;
            this.xEditGridCell169.CellName = "post_modifier8";
            this.xEditGridCell169.Col = -1;
            this.xEditGridCell169.HeaderText = "post_modifier8";
            this.xEditGridCell169.IsVisible = false;
            this.xEditGridCell169.Row = -1;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellLen = 4;
            this.xEditGridCell171.CellName = "post_modifier9";
            this.xEditGridCell171.Col = -1;
            this.xEditGridCell171.HeaderText = "post_modifier9";
            this.xEditGridCell171.IsVisible = false;
            this.xEditGridCell171.Row = -1;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellLen = 4;
            this.xEditGridCell172.CellName = "post_modifier10";
            this.xEditGridCell172.Col = -1;
            this.xEditGridCell172.HeaderText = "post_modifier10";
            this.xEditGridCell172.IsVisible = false;
            this.xEditGridCell172.Row = -1;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.CellLen = 500;
            this.xEditGridCell173.CellName = "post_modifier_name";
            this.xEditGridCell173.Col = -1;
            this.xEditGridCell173.HeaderText = "post_modifier_name";
            this.xEditGridCell173.IsVisible = false;
            this.xEditGridCell173.Row = -1;
            // 
            // xEditGridCell174
            // 
            this.xEditGridCell174.CellName = "sang_start_date";
            this.xEditGridCell174.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell174.CellWidth = 100;
            this.xEditGridCell174.Col = 5;
            this.xEditGridCell174.HeaderText = "開始日";
            this.xEditGridCell174.IsJapanYearType = true;
            this.xEditGridCell174.IsReadOnly = true;
            this.xEditGridCell174.RowSpan = 2;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellName = "sang_start_date_jp";
            this.xEditGridCell175.Col = -1;
            this.xEditGridCell175.HeaderText = "sang_start_date_jp";
            this.xEditGridCell175.IsVisible = false;
            this.xEditGridCell175.Row = -1;
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.CellName = "sang_end_date";
            this.xEditGridCell176.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell176.CellWidth = 100;
            this.xEditGridCell176.Col = 6;
            this.xEditGridCell176.HeaderText = "終了日";
            this.xEditGridCell176.IsJapanYearType = true;
            this.xEditGridCell176.IsReadOnly = true;
            this.xEditGridCell176.RowSpan = 2;
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellName = "sang_end_date_jp";
            this.xEditGridCell177.Col = -1;
            this.xEditGridCell177.HeaderText = "sang_end_date_jp";
            this.xEditGridCell177.IsVisible = false;
            this.xEditGridCell177.Row = -1;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellName = "sang_end_sayu";
            this.xEditGridCell178.CellWidth = 100;
            this.xEditGridCell178.Col = -1;
            this.xEditGridCell178.IsVisible = false;
            this.xEditGridCell178.Row = -1;
            // 
            // xEditGridCell179
            // 
            this.xEditGridCell179.CellName = "sang_end_sayu_name";
            this.xEditGridCell179.Col = 7;
            this.xEditGridCell179.HeaderText = "終了事由";
            this.xEditGridCell179.IsReadOnly = true;
            this.xEditGridCell179.RowSpan = 2;
            this.xEditGridCell179.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellName = "ju_sang_yn";
            this.xEditGridCell180.CellWidth = 30;
            this.xEditGridCell180.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell180.HeaderText = "主";
            this.xEditGridCell180.IsReadOnly = true;
            this.xEditGridCell180.RowSpan = 2;
            // 
            // xGridHeader6
            // 
            this.xGridHeader6.Col = 3;
            this.xGridHeader6.ColSpan = 2;
            this.xGridHeader6.HeaderText = "診療科";
            // 
            // cboSangCode
            // 
            this.cboSangCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSangCode.DropDownWidth = 956;
            this.cboSangCode.Location = new System.Drawing.Point(70, 5);
            this.cboSangCode.Name = "cboSangCode";
            this.cboSangCode.Size = new System.Drawing.Size(605, 21);
            this.cboSangCode.TabIndex = 1;
            // 
            // xLabel9
            // 
            this.xLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.xLabel9.Image = ((System.Drawing.Image)(resources.GetObject("xLabel9.Image")));
            this.xLabel9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel9.Location = new System.Drawing.Point(0, 0);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(1102, 32);
            this.xLabel9.TabIndex = 0;
            this.xLabel9.Text = "　傷病";
            // 
            // txtGongbi_yn
            // 
            this.txtGongbi_yn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGongbi_yn.Location = new System.Drawing.Point(809, 772);
            this.txtGongbi_yn.Name = "txtGongbi_yn";
            this.txtGongbi_yn.Size = new System.Drawing.Size(41, 20);
            this.txtGongbi_yn.TabIndex = 7;
            this.txtGongbi_yn.Visible = false;
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(859, 764);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 3;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlProgressBar
            // 
            this.pnlProgressBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlProgressBar.BackgroundImage")));
            this.pnlProgressBar.Controls.Add(this.lbTransCnt);
            this.pnlProgressBar.Controls.Add(this.lbTransHangmog);
            this.pnlProgressBar.Controls.Add(this.pgbProgress);
            this.pnlProgressBar.Location = new System.Drawing.Point(234, 287);
            this.pnlProgressBar.Name = "pnlProgressBar";
            this.pnlProgressBar.Size = new System.Drawing.Size(612, 62);
            this.pnlProgressBar.TabIndex = 4;
            this.pnlProgressBar.Visible = false;
            // 
            // lbTransCnt
            // 
            this.lbTransCnt.BackColor = System.Drawing.Color.Transparent;
            this.lbTransCnt.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTransCnt.Location = new System.Drawing.Point(498, 38);
            this.lbTransCnt.Name = "lbTransCnt";
            this.lbTransCnt.Size = new System.Drawing.Size(100, 23);
            this.lbTransCnt.TabIndex = 2;
            this.lbTransCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTransHangmog
            // 
            this.lbTransHangmog.BackColor = System.Drawing.Color.Transparent;
            this.lbTransHangmog.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTransHangmog.Location = new System.Drawing.Point(12, 38);
            this.lbTransHangmog.Name = "lbTransHangmog";
            this.lbTransHangmog.Size = new System.Drawing.Size(484, 23);
            this.lbTransHangmog.TabIndex = 1;
            this.lbTransHangmog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(10, 12);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(590, 24);
            this.pgbProgress.TabIndex = 0;
            // 
            // layOut0101
            // 
            this.layOut0101.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layOut0101.QuerySQL = resources.GetString("layOut0101.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // layCommon
            // 
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4});
            // 
            // singleLayoutItem2
            // 
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
            // btnCompar
            // 
            this.btnCompar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompar.ImageIndex = 12;
            this.btnCompar.ImageList = this.ImageList;
            this.btnCompar.Location = new System.Drawing.Point(377, 764);
            this.btnCompar.Name = "btnCompar";
            this.btnCompar.Size = new System.Drawing.Size(116, 28);
            this.btnCompar.TabIndex = 5;
            this.btnCompar.Text = "送信オーダ参照";
            this.btnCompar.Visible = false;
            this.btnCompar.Click += new System.EventHandler(this.btnCompar_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSend.ImageIndex = 13;
            this.btnSend.ImageList = this.ImageList;
            this.btnSend.Location = new System.Drawing.Point(8, 767);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 28);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "再転送";
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnReSend_Click);
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellLen = 4;
            this.xEditGridCell170.CellName = "post_modifier8";
            this.xEditGridCell170.Col = -1;
            this.xEditGridCell170.HeaderText = "post_modifier8";
            this.xEditGridCell170.IsVisible = false;
            this.xEditGridCell170.Row = -1;
            // 
            // xEditGridCell206
            // 
            this.xEditGridCell206.CellName = "if_valid_yn";
            this.xEditGridCell206.Col = -1;
            this.xEditGridCell206.HeaderText = "if_valid_yn";
            this.xEditGridCell206.IsVisible = false;
            this.xEditGridCell206.Row = -1;
            // 
            // btnSiksaTest
            // 
            this.btnSiksaTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSiksaTest.Location = new System.Drawing.Point(295, 763);
            this.btnSiksaTest.Name = "btnSiksaTest";
            this.btnSiksaTest.Size = new System.Drawing.Size(82, 29);
            this.btnSiksaTest.TabIndex = 8;
            this.btnSiksaTest.Text = "外泊転送";
            this.btnSiksaTest.Visible = false;
            this.btnSiksaTest.Click += new System.EventHandler(this.btnSiksaTest_Click);
            // 
            // dtpFromdate
            // 
            this.dtpFromdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFromdate.Location = new System.Drawing.Point(520, 772);
            this.dtpFromdate.Name = "dtpFromdate";
            this.dtpFromdate.Size = new System.Drawing.Size(100, 20);
            this.dtpFromdate.TabIndex = 9;
            this.dtpFromdate.Visible = false;
            // 
            // dtpTodate
            // 
            this.dtpTodate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTodate.Location = new System.Drawing.Point(520, 772);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(100, 20);
            this.dtpTodate.TabIndex = 10;
            this.dtpTodate.Visible = false;
            // 
            // cboTosik
            // 
            this.cboTosik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboTosik.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem4});
            this.cboTosik.Location = new System.Drawing.Point(696, 771);
            this.cboTosik.Name = "cboTosik";
            this.cboTosik.Size = new System.Drawing.Size(64, 21);
            this.cboTosik.TabIndex = 12;
            this.cboTosik.Visible = false;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "朝";
            this.xComboItem1.ValueItem = "0";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "昼";
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "夕方";
            this.xComboItem3.ValueItem = "2";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "夜";
            this.xComboItem4.ValueItem = "3";
            // 
            // cboFromsik
            // 
            this.cboFromsik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboFromsik.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7,
            this.xComboItem8});
            this.cboFromsik.Location = new System.Drawing.Point(626, 771);
            this.cboFromsik.Name = "cboFromsik";
            this.cboFromsik.Size = new System.Drawing.Size(64, 21);
            this.cboFromsik.TabIndex = 13;
            this.cboFromsik.Visible = false;
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "朝";
            this.xComboItem5.ValueItem = "0";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "昼";
            this.xComboItem6.ValueItem = "1";
            // 
            // xComboItem7
            // 
            this.xComboItem7.DisplayItem = "夕方";
            this.xComboItem7.ValueItem = "2";
            // 
            // xComboItem8
            // 
            this.xComboItem8.DisplayItem = "夜";
            this.xComboItem8.ValueItem = "3";
            // 
            // btnForcedEnd
            // 
            this.btnForcedEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnForcedEnd.ImageIndex = 2;
            this.btnForcedEnd.ImageList = this.ImageList;
            this.btnForcedEnd.Location = new System.Drawing.Point(7, 766);
            this.btnForcedEnd.Name = "btnForcedEnd";
            this.btnForcedEnd.Size = new System.Drawing.Size(96, 29);
            this.btnForcedEnd.TabIndex = 14;
            this.btnForcedEnd.Text = "強制終了";
            this.btnForcedEnd.Visible = false;
            this.btnForcedEnd.Click += new System.EventHandler(this.btnForcedEnd_Click);
            // 
            // INPORDERTRANS
            // 
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
            this.Name = "INPORDERTRANS";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(1109, 800);
            this.Load += new System.EventHandler(this.ORDERTRANS_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.ORDERTRANS_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlHelp.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2004)).EndInit();
            this.pnlWoichul.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWoichul)).EndInit();
            this.pnlSiksa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSiksa)).EndInit();
            this.pnlJungwa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdJungwa)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSiksaList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInpList)).EndInit();
            this.xPanel4.ResumeLayout(false);
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

		#region Screen 변수

		// 라디오 버튼 컬러
		private XColor mSelectedBackColor   = new XColor(Color.FromName("ActiveCaption"));
		private XColor mSelectedForeColor   = new XColor(Color.FromName("ActiveCaptionText"));
		private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
		private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

		// 파라미터
		//private string mBunho      = "";
		//private string mNaewonDate = "";
        private string mIOGubun = "I";

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

        private string from_date = "";
        private string to_date = "";
		#endregion

        #region Screen Load
        private void ORDERTRANS_Load(object sender, System.EventArgs e)
        {
            //if (this.Opener != null &&
            //    this.Opener is XScreen &&
            //    this.OpenParam != null)
            //{
            //    if (this.OpenParam.Contains("io_gubun"))
            //    {
            //        this.mIOGubun = this.OpenParam["io_gubun"].ToString();

            //        if (this.mIOGubun == "")
            //        {
            //            this.mIOGubun = "O"; // 없으면 외래가 기본임.
            //        }
            //    }
            //    if (this.OpenParam.Contains("naewon_date"))
            //    {
            //        string naewon_date = this.OpenParam["naewon_date"].ToString();

            //        if (naewon_date == "")
            //        {
            //            naewon_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
            //        }
            //        //this.dtpGijunDate.SetDataValue(naewon_date);
            //    }
            //    if (this.OpenParam.Contains("bunho"))
            //    {
            //        string bunho = this.OpenParam["bunho"].ToString();

            //        this.fbxBunho.SetDataValue(bunho);
            //        PostCallHelper.PostCall(new PostMethod(PostBunhoValidating));
            //        //this.fbxBunho.AcceptData();
            //    }
            //}
            //else
            //{
            //    if (EnvironInfo.CurrSystemID == "NURI" ||
            //        EnvironInfo.CurrSystemID == "INPS" ||
            //        EnvironInfo.CurrSystemID == "OCSI")
            //    {
            //        this.mIOGubun = "I";
            //    }
            //    else
            //    {
            //        this.mIOGubun = "O";
            //    }
            //}
        }
        #endregion

        #region [ Screen 이벤트 ]
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

            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    // 환자번호
                    if (OpenParam.Contains("bunho"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
                        {
                            this.fbxBunho.SetEditValue(OpenParam["bunho"].ToString().Trim());
                            //this.btnList.PerformClick(FunctionType.Query);
                            this.fbxBunho.AcceptData();
                        }
                    }

                    // 조회기간 from
                    if (OpenParam.Contains("from_date"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["from_date"].ToString().Trim()))
                        {
                            from_date = OpenParam["from_date"].ToString().Trim();
                        }
                    }

                    // 조회기간 to
                    if (OpenParam.Contains("to_date"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["to_date"].ToString().Trim()))
                        {
                            to_date = OpenParam["to_date"].ToString().Trim();
                        }
                    }

                    this.MakeSangCombo();

                }
                catch (Exception ex)
                {
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }

            this.InitScreen();
        }
        #endregion

        #region [InitScreen]
        private void InitScreen()
        {
            //탭페이지 생성
            this.MakeDataGubunTabPages();

            //this.mCurrentGrid = this.grdInpList;
            this.mCurrentListGrid = this.grdInpList;

            string firstDay = "";
            string lastDay = "";

            // 呼出した画面からパラメータがあるとそのままセットする。
            if (from_date != "") firstDay = from_date;
            else firstDay = EnvironInfo.GetSysDate().Year.ToString() + "/" + EnvironInfo.GetSysDate().Month + "/" + "01";
            if (to_date != "") lastDay = to_date;
            else lastDay = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");

            // ORDER일자From 最初日 셋팅
            if (this.dtpJunsongFromDate.GetDataValue() == "")
                this.dtpJunsongFromDate.SetDataValue(firstDay);

            // ORDER일자To 最後日 셋팅
            if (this.dtpJunsongToDate.GetDataValue() == "")
                this.dtpJunsongToDate.SetDataValue(lastDay);

            // 전송일자 오늘로 셋팅
            if (this.dtpJunsongDate.GetDataValue() == "")
                this.dtpJunsongDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));

            // 基準月 前月に設定
            this.monthBox.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));

            // 디폴트 미전송 체크
            this.rbnMiTrans.Checked = true;
            //초재진
            //this.MakeChojaeCombo();
            // 백데이터셋팅
            this.layRequisInfo = this.mCurrentListGrid.CloneToLayout();
        }
        #endregion

        #region [ClearInputControl]
        private void ClearInputControl()
        {
            //외/입정보클리어
            this.mCurrentListGrid.Reset();
            //오더정보클리어
            this.mCurrentGrid.Reset();

            //전송일자클리어
            //this.dtpJunsongDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            ////기준일자클리어
            //this.dtpGijunDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

        }
        #endregion

        #region [라벨초기화함수]
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
        #endregion

        #region [환자정보 처리]
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            this.fbxBunho.SetDataValue(info.BunHo);
            PostCallHelper.PostCall(new PostMethod(PostBunhoValidating));
            base.OnReceiveBunHo(info);

            this.MakeSangCombo();
        }
        #endregion

        #region [환자정보 이벤트]
        private void fbxBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.IF_VALID_YN = "";

            if (e.DataValue != "")
            {
                string bunho = e.DataValue;
                bunho = BizCodeHelper.GetStandardBunHo(bunho);
                fbxBunho.SetDataValue(bunho);

                // 在院患者チェック
                if (isJaewonPatient(bunho))
                {
                    //환자상병정보클리어
                    this.grdOutSang.Reset();
                    this.cboSangCode.ComboItems.Clear();
                    this.cboSangCode.RefreshComboItems();

                    //상병정보표시처리
                    this.MakeSangCombo();

                    PostCallHelper.PostCall(new PostMethod(PostBunhoValidating));
                }
                else {
                    XMessageBox.Show("在院中の患者ではありません。患者番号を確認してください。", "患者番号確認", MessageBoxIcon.Warning);
                    fbxBunho.SetDataValue("");

                    this.dbxSuname.SetDataValue("");
                    ClearInputControl();

                    //환자상병정보클리어
                    this.grdOutSang.Reset();
                    this.cboSangCode.ComboItems.Clear();
                    this.cboSangCode.RefreshComboItems();

                    fbxBunho.Focus();
                }
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
                this.dtpJunsongFromDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                this.dtpJunsongToDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            }
        }

        private bool isJaewonPatient(string bunho)
        {
            bool rtnVal = false;

            string strCmd = "";
            BindVarCollection bindVar = new BindVarCollection();

            //bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_bunho", bunho);

            strCmd = @"SELECT FN_INP_JAEWON_CHECK(:f_bunho) JAEWON_YN
                         FROM DUAL";

            object result = Service.ExecuteScalar(strCmd, bindVar);

            if (TypeCheck.IsNull(result)) rtnVal = false;
            else rtnVal = result.ToString() == "Y"? true : false;

            return rtnVal;
        }
        #endregion

        #region [ 환자정보셋팅 ]
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
                                    this.layOut0101.GetItemValue("AGE").ToString() + "才";
                this.dbxSuname.SetEditValue(str);
                this.IF_VALID_YN = this.layOut0101.GetItemValue("IF_VALID_YN").ToString();
            }
        }
        #endregion

        #region [ 환자번호 클릭이벤트 ]
        private void fbxBunho_FindClick(object sender, CancelEventArgs e)
        {
            this.OpenScreen_OUT0101Q01();
        }
        #endregion

        #region [ 다른 화면 오픈 ]
        private void OpenScreen_OUT0101Q01()
        {
            CommonItemCollection param = new CommonItemCollection();
            XScreen.OpenScreenWithParam(this, "NURO", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
        }
        #endregion

        #region [ Command ]
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
        #endregion

        #region [버튼클릭이벤트처리]
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

                    this.btnList.FunctionItems.Add(FunctionType.Process, Shortcut.F12, "転 送", -1, "");
                    this.btnList.InitializeButtons();
                    this.btnList.Refresh();
                    this.lblHlep1.Text = "未実施";
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

                    this.btnList.FunctionItems.Add(FunctionType.Process, Shortcut.F12, "取 消", -1, "");
                    this.btnList.InitializeButtons();
                    this.btnList.Refresh();

                    this.lblHlep1.Text = "未転送";
                    //btnList.FunctionItems.
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
        #endregion

        #region [탭페이지 동적구성]
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
            tpg = new IHIS.X.Magic.Controls.TabPage("オーダ");
            tpg.ImageList = this.ImageList;
            tpg.ImageIndex = 3;
            tpg.Tag = "0";
            this.tabDataGubun.TabPages.Add(tpg);
            this.mCurrentGrid = this.grdOCS2003; //디폴트 오더탭설정

            // 레이아웃 셋팅
            this.layOrderInfo = this.mCurrentGrid.CloneToLayout();
            

            // 식사 탭페이지 생성
            tpg = new IHIS.X.Magic.Controls.TabPage("食事");
            tpg.ImageList = this.ImageList;
            tpg.ImageIndex = 4;
            tpg.Tag = "1";
            this.tabDataGubun.TabPages.Add(tpg);


            // 외출,외박 탭페이지 생성
            tpg = new IHIS.X.Magic.Controls.TabPage("外泊");
            tpg.ImageList = this.ImageList;
            tpg.ImageIndex = 5;
            tpg.Tag = "2";
            this.tabDataGubun.TabPages.Add(tpg);
            /*
                        //전과, 전실 탭페이지 생성
                        tpg = new IHIS.X.Magic.Controls.TabPage("転科・転棟・転室・転医");
                        tpg.ImageList = this.ImageList;
                        tpg.ImageIndex = 6;
                        tpg.Tag = "3";
                        this.tabDataGubun.TabPages.Add(tpg);
             * */

            this.tabDataGubun.SelectedTab = this.tabDataGubun.TabPages[0];
            this.tabDataGubun.SelectionChanged += new EventHandler(tabDataGubun_SelectionChanged);
            this.tabDataGubun_SelectionChanged(this.tabDataGubun, new EventArgs());
        }
        #endregion

        #region [ 탭 체인지 이벤트처리 ]
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

                            this.rbnMiTrans.Enabled = true;
                            this.rbnTrans.Enabled = true;

                            this.dtpJunsongFromDate.Visible = true;
                            this.dtpJunsongToDate.Visible = true;

                            this.monthBox.Visible = false;

                            this.grdInpList.Visible = true;
                            this.grdSiksaList.Visible = false;

                            this.mCurrentListGrid = this.grdInpList;
                            this.mCurrentGrid = this.grdOCS2003;
                            val = true;
                            break;
                        case "1": // 식사 탭
                            this.pnlSiksa.Visible = true;
                            this.pnlOrder.Visible = false;
                            this.pnlWoichul.Visible = false;
                            this.pnlJungwa.Visible = false;

                            this.rbnMiTrans.Checked = true;
                            this.rbnMiTrans.Enabled = false;
                            this.rbnTrans.Enabled = false;

                            this.dtpJunsongFromDate.Visible = false;
                            this.dtpJunsongToDate.Visible = false;

                            this.monthBox.Visible = true;

                            this.grdInpList.Visible = false;
                            this.grdSiksaList.Visible = true;

                            this.mCurrentListGrid = this.grdSiksaList;
                            this.mCurrentGrid = this.grdSiksa;
                            val = true;
                            break;
                        case "2": // 외출외박
                            this.pnlWoichul.Visible = true;
                            this.pnlOrder.Visible = false;
                            this.pnlSiksa.Visible = false;
                            this.pnlJungwa.Visible = false;

                            this.rbnMiTrans.Enabled = false;
                            this.rbnTrans.Enabled = false;

                            this.dtpJunsongFromDate.Visible = false;
                            this.dtpJunsongToDate.Visible = false;

                            this.monthBox.Visible = true;

                            this.grdInpList.Visible = false;
                            this.grdSiksaList.Visible = true;

                            this.mCurrentListGrid = this.grdSiksaList;
                            this.mCurrentGrid = this.grdWoichul;
                            val = true;
                            break;
                        case "3": //전과,전실
                            this.pnlJungwa.Visible = true;
                            this.pnlOrder.Visible = false;
                            this.pnlSiksa.Visible = false;
                            this.pnlWoichul.Visible = false;

                            this.rbnMiTrans.Enabled = false;
                            this.rbnTrans.Enabled = false;

                            this.dtpJunsongFromDate.Visible = false;
                            this.dtpJunsongToDate.Visible = false;

                            this.monthBox.Visible = true;

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

                    if ((tpg.Tag.ToString() =="0")&&(this.mSend_YN =="Y"))
                    {
                        this.btnCompar.Visible = false; //true;
                    }
                    else 
                    {
                        this.btnCompar.Visible =false ;
                    }
                }
            }
        }
        #endregion

        #region XLabel
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
        #endregion

        #region [그리트디폴트이미지셋팅]
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
                //if (this.mSend_YN == "N")
                //{
                //    if (grd.GetItemString(i, "naewon_yn") != "E")
                //    {
                //        grd.SetItemValue(i, "select", "X");
                //        grd[i, "select"].Image = this.ImageList.Images[3];
                //    }
                //}
            }
            this.checkSelectAll();
        }
        #endregion

        #region [전송일자 체크]
        private bool IsValidTransDate()
        {
            if (this.fbxBunho.GetDataValue() == "")
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "환자번호를 입력하여주십시요" : "患者番号を入力してください。";
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxIcon.Warning);
                return false;
            }
            DataRow[] dtRowData = this.mCurrentListGrid.LayoutTable.Select("select =" + "'Y'");
            if (dtRowData.Length <= 0) 
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "선택된 데이터가 없습니다." : "選択されたデータがありません。";
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
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "전송일자보다 과거의 오더정보가 있습니다. 전송처리하시겠습니까?" :
                                                                  "転送日付より過去のオーダ情報があります。転送処理を行いますが？";
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
        #endregion

        #region XButtonList
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.GridListSelectionChanged();
                    break;
                case FunctionType.Process:
                    this.AcceptData();
                    e.IsBaseCall = false;
                    this.btnList.Enabled = false;
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        string tab = this.tabDataGubun.SelectedTab.Tag.ToString();
                        bool value = false;

                        switch (tab)
                        {
                            case "0"://오더데이터처리

                                if (this.mSend_YN == "N")
                                {
                                    if (this.ProcessOrderSend() != true)
                                    {
                                        throw new Exception();
                                    }
                                }
                                else
                                {
                                    if (this.ProcessOrderCancel() != true)
                                    {
                                        throw new Exception();
                                    }
                                }
                                break;

                            case "1"://식사데이터처리
                                value = ProcessSiksaTrans();
                                break;
                            case "2"://외박데이터처리
                                value = ProcessWoichulTrans();
                                break;
                            case "3"://전과전실데이터처리
                                //value = ProcessJungwaTrans(ref listDateArry);
                                break;
                        }
                        this.GridListSelectionChanged();
                        this.Cursor = Cursors.Default;
                    }
                    catch
                    {
                        this.Cursor = Cursors.Default;
                    }
                    finally
                    {
                        this.btnList.Enabled = true;
                        this.fbxBunho.Focus();
                        
                    }
                    
                    break;
            }
        }
        #endregion

        #region [오더 그리드]
        private void grdOCS2003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            
            switch (e.ColName)
            {
                case "hangmog_code":
                    if (this.mSend_YN == "N")
                    {
                        if (grd.GetItemString(e.RowNumber, "jundal_part") == "PA"  ||
                            grd.GetItemString(e.RowNumber, "jundal_part") == "HOM" ||
                            grd.GetItemString(e.RowNumber, "acting_date") != ""      ) // Acting인 경우 (수납가능)
                        {
                            e.ForeColor = Color.Blue;    // 파랑색
                            e.BackColor = Color.SkyBlue; // 하늘색
                        }
                        //if (grd.GetItemString(e.RowNumber, "result_date") != "") // 결과입력된 경우
                        //{
                        //    e.ForeColor = Color.DeepPink;  // 보라색
                        //    e.BackColor = Color.SkyBlue;   // 하늘색
                        //}
                        //else if (grd.GetItemString(e.RowNumber, "ocs_flag").Trim() == "2") // 예약인 경우
                        //{
                        //    e.ForeColor = Color.Green;   // 녹색
                        //}
                        // 입원이 아닌 경우는 수납체크함
                        //if (grd.GetItemString(e.RowNumber, "ocs_flag").Trim() == "0") // 전달이 아닌경우
                        //{

                        //}
                        //else
                        //{
                        //    e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, IHIS.Framework.XEditGrid.DefaultFont.Size, FontStyle.Bold);
                        //}
                    }
                    else
                    {
                        switch (grd.GetItemString(e.RowNumber, "if_flag"))
                        {
                            case "10":　//未転送
                                e.ForeColor = Color.Black;
                                e.BackColor = Color.Transparent;
                                break;

                            case "20": //転送成功
                                e.ForeColor = Color.Green; 
                                e.BackColor = Color.GreenYellow;
                                break;

                            //case "21": //転送失敗
                            //    e.ForeColor = Color.Red;    
                            //    e.BackColor = Color.Pink;
                            //    break;

                            case "30": //会計済み
                                e.ForeColor = Color.Black;     
                                e.BackColor = Color.DarkGray;
                                break;

                            case "":
                                e.ForeColor = Color.Black;
                                e.BackColor = Color.DarkGray;
                                break;
                        }
                        //grd[e.RowNumber, e.ColName].SelectedForeColor = new XColor(e.ForeColor);
                        //grd[e.RowNumber, e.ColName].SelectedBackColor = new XColor(e.BackColor);
                    }
                break;
            }

            if (grd.GetItemString(e.RowNumber, "if_flag") == "21")
            {
                e.ForeColor = Color.Red;
                e.BackColor = Color.Pink;
                //grd[e.RowNumber, e.ColName].SelectedForeColor = new XColor(Color.Red);
                //grd[e.RowNumber, e.ColName].SelectedBackColor = new XColor(Color.Pink);
            }           
        }
        #endregion

        #region [그리드에디터리스트 포커스체인지]
        private void grdList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            this.hoken_valid_yn = false;

            if (e.CurrentRow >= 0)
            {
                //ArrayList inputList = new ArrayList();
                //ArrayList outputList = new ArrayList();

                //inputList.Add(EnvironInfo.HospCode);
                //inputList.Add(mCurrentListGrid.GetItemValue(e.CurrentRow, "acting_date"));
                //inputList.Add(mCurrentListGrid.GetItemValue(e.CurrentRow, "doctor"));
                //inputList.Add(this.fbxBunho.GetDataValue().ToString());

                //if (mSend_YN == "N")
                //{
                //    if (Service.ExecuteProcedure("PR_OUT_CHECK_ORDER_END", inputList, outputList))
                //    {
                //        if (outputList[0].ToString() != "E")
                //        {
                //            XMessageBox.Show("診療がまだ終了されておりません。診療終了状況を確認してください。", "診療終了確認", MessageBoxIcon.Information);
                //        }
                //    }
                //    else
                //    {
                //        XMessageBox.Show("診療終了情報取得に問題がありました。" + Service.ErrFullMsg, "診療終了確認エラー", MessageBoxIcon.Warning);
                //    }
                //}
                
                //그리드에디터데이터출력
                this.GridSelectChanged();


                this.layOrderInfo.Reset();


                //전송일자를실행일자로설정
                if (this.mCurrentListGrid.GetItemString(e.CurrentRow, "select") == "Y")
                {
                    this.dtpJunsongDate.SetDataValue(this.mCurrentListGrid.GetItemString(e.CurrentRow, "acting_date"));
                }

                this.mCurrentGrid.SetFocusToItem(this.mCurrentGrid.CurrentRowNumber, "hangmog_code");
            }
        }
        #endregion

        #region [ 그리드리스트에디터 쿼리실행 ]
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
            // 데이터 쿼리 취득
            string OcsQuery = this.SelectListQuerySQL(str);
            if (OcsQuery != "")
            {
                grdList.QuerySQL = OcsQuery;
                if (grdList.QueryLayout(true))
                {
                    //리스트 디폴트 이미지 셋팅
                    this.SetOutListImage();
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        #endregion

        #region [ 그리드에디터 쿼리 취득 ]
        private void GridSelectChanged()
        {
            XEditGrid grdEdit = this.mCurrentGrid;
            if (grdEdit == null)
            {
                return;
            }
            // 카운트 초기화
            this.mActCount = 0;
            #region grdOCS2003
            if (grdEdit.Name.Equals("grdOCS2003"))
            {
                #region INP ORDER Before Trans : comment
                /*
                string QuerySQL = @"-- INP ORDER Before Trans --
                                    SELECT  A.FKINP3010                                                PKINP3010
                                          , A.PKOCS2003                                                PKOCS 
                                          , A.GROUP_SER                                                GROUP_SER
                                          , A.GROUP_SER||A.FKINP1001                                   GROUP_INP1001
                                          , NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME
                                          , A.HANGMOG_CODE                                             HANGMOG_CODE 
                                          , B.HANGMOG_NAME                                             HANGMOG_NAME  
                                          , A.SPECIMEN_CODE                                            SPECIMEN_CODE
                                          , D.SPECIMEN_NAME                                            SPECIMEN_NAME
                                          , A.SURYANG                                                  SURYANG
                                          , A.ORD_DANUI                                                ORD_DANUI
                                          , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME
                                          , A.DV_TIME                                                  DV_TIME 
                                          , A.DV                                                       DV
                                          , A.NALSU                                                    NALSU
                                          , A.JUSA                                                     JUSA
                                          , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME
                                          , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', A.JUSA_SPD_GUBUN)  JUSA_SPD_NAME
                                          , A.BOGYONG_CODE                                             BOGYONG_CODE
                                          , FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN) BOGYONG_NAME
                                          , NVL(A.EMERGENCY, 'N')                                      EMERGENCY                                
                                          , A.JUNDAL_PART                                              JUNDAL_PART 
                                          , A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN
                                          , ''                                                         DANGIL_GUMSA_ORDER_YN
                                          , A.OCS_FLAG                                                 OCS_FLAG
                                          , A.ORDER_GUBUN                                              ORDER_GUBUN
                                          , A.BUNHO                                                    BUNHO
                                          , A.ORDER_DATE                                               ORDER_DATE
                                          --, A.INPUT_GWA                                                GWA
                                          --, A.INPUT_DOCTOR                                             DOCTOR
                                          , G.GWA                                                      GWA
                                          , H.ORG_DOCTOR                                               DOCTOR
                                          , A.SEQ                                                      SEQ
                                          , A.FKOCS1003                                                FKOCS1003
                                          , A.SUB_SUSUL                                                SUB_SUSUL
                                          , A.ACTING_DATE                                              ACTING_DATE
                                          , CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN NULL    
                                               ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))    
                                            END HOPE_DATE
                                          , A.SUNAB_DATE                                               SUNAB_DATE
                                          , 'N'                                                        HOME_CARE_YN
                                          , NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN 
                                          , A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN
                                          , E.BUN_CODE                                                 BUN_CODE
                                          , B.INPUT_CONTROL                                            INPUT_CONTROL  
                                          , B.ORDER_GUBUN                                              ORDER_GUBUN_BAS 
                                          , CASE WHEN A.JUNDAL_PART in ('HOM') THEN 'Y'
                                                 WHEN A.ACTING_DATE IS NOT NULL THEN 'Y'
                                                 ELSE  'N'
                                            END ACTING_YN 
                                          , :f_send_yn                                                 SELECT_YN   
                                          , A.IF_DATA_SEND_YN                                          SEND_YN
                                          , F.IF_FLAG                                                  IF_FLAG
                                          , F.FKIFS3014                                                FKIFS3014
                                          , TRIM(LPAD(TO_CHAR(C.SORT_KEY), 2, '0'))
                                          ||TRIM(TO_CHAR(A.GROUP_SER, '0000000000'))
                                          ||TRIM(TO_CHAR(NVL(A.BOM_SOURCE_KEY, A.PKOCS2003), '00000000000'))
                                          ||CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9'
                                                 ELSE '0'
                                            END 
                                          ||TRIM(TO_CHAR(A.SEQ, '00000000000')) 
                                          ||TRIM(TO_CHAR(A.PKOCS2003, '00000000000'))   ORDER_BY_KEY 
                                    FROM  OCS2003 A
                                        , OCS0103 B
                                        , OCS0132 C
                                        , OCS0116 D
                                        , BAS0310 E
                                        , INP1001 G
                                        , BAS0270 H
                                        ,(SELECT X.HOSP_CODE, X.FKOCS2003, X.FKINP3010, X.IF_FLAG, X.FKIFS3014
                                            FROM IFS4011 X  
                                           WHERE X.HOSP_CODE = :f_hosp_code
                                             AND X.FKINP3010 = :f_pkinp3010
                                             AND X.PKIFS4011 IN (SELECT MAX(Z.PKIFS4011) PKIFS4011
                                                                   FROM IFS4011 Z
                                                                  WHERE Z.HOSP_CODE = X.HOSP_CODE
                                                                    AND Z.BUNHO     = X.BUNHO
                                                                  GROUP BY Z.FKOCS2003, Z.HOSP_CODE, Z.FKINP3010)
                                         ) F
                                    WHERE A.HOSP_CODE        = :f_hosp_code
                                    AND ( 
                                          (
                                            :f_send_yn = 'Y'
                                            AND
                                            A.FKINP3010 = :f_pkinp3010
                                          )
                                          OR
                                          (
                                            :f_send_yn != 'Y'
                                            AND A.FKINP1001                      = :f_pkinp1001
                                            AND A.BUNHO                          = :f_bunho
                                            AND A.ORDER_DATE                     = :f_order_date
                                            AND NVL(A.IF_DATA_SEND_YN, 'N' )     = 'N'
                                            AND G.GWA                            = :f_gwa
                                            AND H.ORG_DOCTOR                     = :f_doctor
                                          )
                                        )
                                      AND A.NALSU                               >= 0
                                      AND ( (SUBSTR(A.ORDER_GUBUN, 2, 1)   NOT IN  ('C','D')
                                               AND NVL(A.DC_YN,'N')   = 'N')
                                            OR 
                                            (SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('C','D')))         -- 内用、外服薬は取消オーダ照会、以外は未照会
                                      AND NVL(A.MUHYO,'N')   = 'N'     
                                      AND NVL(A.NDAY_YN,'N') = 'N'
                                      AND B.HOSP_CODE(+)     = A.HOSP_CODE
                                      AND B.HANGMOG_CODE(+)  = A.HANGMOG_CODE
                                      AND A.ORDER_DATE BETWEEN B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                                      AND C.HOSP_CODE(+)     = A.HOSP_CODE
                                      AND C.CODE     (+)     = SUBSTR(A.ORDER_GUBUN, 2, 1)
                                      AND C.CODE_TYPE(+)     = 'ORDER_GUBUN_BAS'
                                      AND D.HOSP_CODE(+)     = A.HOSP_CODE
                                      AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
                                      AND E.HOSP_CODE(+)     = B.HOSP_CODE
                                      AND E.SG_CODE(+)       = B.SG_CODE
                                      AND A.ORDER_DATE BETWEEN E.SG_YMD AND NVL(E.BULYONG_YMD, '9998/12/31')

                                      AND F.HOSP_CODE     (+)= A.HOSP_CODE
                                      AND F.FKINP3010     (+)= A.FKINP3010
                                      AND F.FKOCS2003     (+)= A.PKOCS2003

                                      AND G.HOSP_CODE        = A.HOSP_CODE
                                      AND G.PKINP1001        = A.FKINP1001
                                      
                                      AND H.HOSP_CODE        = G.HOSP_CODE
                                      AND H.DOCTOR           = G.DOCTOR
                                      ORDER BY ORDER_BY_KEY ";
                */
                #endregion INP ORDER Before Trans : comment
                //
                #region 2013.09.16 LKH S : NEW SQL(detail)
//                string QuerySQL = @"-- INP ORDER Before Trans --
//SELECT 
//-----------------------------------------------
//        CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') THEN ZZ.FKINP3010
//           ELSE A.FKINP3010
//        END PKINP3010
//-----------------------------------------------
//--        A.FKINP3010                                                PKINP3010
//      , A.PKOCS2003                                                PKOCS 
//      , A.GROUP_SER                                                GROUP_SER
//      , A.GROUP_SER||A.FKINP1001                                   GROUP_INP1001
//      , NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME
//      , A.HANGMOG_CODE                                             HANGMOG_CODE 
//      , BB.HANGMOG_NAME                                             HANGMOG_NAME  
//      , D.SPECIMEN_CODE                                            SPECIMEN_CODE
//      , D.SPECIMEN_NAME                                            SPECIMEN_NAME
//      , A.SURYANG                                                  SURYANG
//      , A.ORD_DANUI                                                ORD_DANUI
//      , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME
//      , A.DV_TIME                                                  DV_TIME 
//      , A.DV                                                       DV
//-----------------------------------------------
//      , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') THEN 1
//           ELSE A.NALSU
//        END NALSU
//-----------------------------------------------
//      --, A.NALSU                                                    NALSU
//      , A.JUSA                                                     JUSA
//      , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME
//      , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', A.JUSA_SPD_GUBUN)  JUSA_SPD_NAME
//      , A.BOGYONG_CODE                                             BOGYONG_CODE
//      , FN_OCS_BOGYONG_COL_NAME(BB.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN) BOGYONG_NAME
//      , NVL(A.EMERGENCY, 'N')                                      EMERGENCY                                
//      , A.JUNDAL_PART                                              JUNDAL_PART 
//      , A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN
//      , ''                                                         DANGIL_GUMSA_ORDER_YN
//      , A.OCS_FLAG                                                 OCS_FLAG
//      , BB.ORDER_GUBUN                                             ORDER_GUBUN
//      , A.BUNHO                                                    BUNHO
//      , A.ORDER_DATE                                               ORDER_DATE
//      --, A.INPUT_GWA                                                GWA
//      --, A.INPUT_DOCTOR                                             DOCTOR
//      , AA.GWA                                                     GWA
//      , H.ORG_DOCTOR                                               DOCTOR
//      , A.SEQ                                                      SEQ
//      , A.FKOCS1003                                                FKOCS1003
//      , A.SUB_SUSUL                                                SUB_SUSUL
//---------------------      
//      , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') THEN zz.act_res_date --DECODE(zz.ACTING_DATE, NULL, zz.ACTING_DATE, zz.act_res_date)
//           ELSE A.ACTING_DATE 
//        END ACTING_DATE
//---------------------    
//      --, A.ACTING_DATE                                              ACTING_DATE
// ---------------------      
//      , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') THEN zz.act_res_date    
//           ELSE CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN NULL    
//                     ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))
//                     end
//        END HOPE_DATE
//---------------------     
//      --, CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN NULL    
//      --     ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))    
//      --  END HOPE_DATE
//      , A.SUNAB_DATE                                               SUNAB_DATE
//      , 'N'                                                        HOME_CARE_YN
//      , NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN 
//      , A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN
//      , BC.BUN_CODE                                                BUN_CODE
//      , BB.INPUT_CONTROL                                           INPUT_CONTROL  
//      , A.ORDER_GUBUN                                              ORDER_GUBUN_BAS
//--------------------------------------
//      , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') THEN decode(zz.cnt, a.dv, 'Y', 'N')
//           ELSE CASE WHEN A.JUNDAL_PART in ('HOM') THEN 'Y'
//                     WHEN A.ACTING_DATE IS NOT NULL THEN 'Y'
//                     ELSE  'N'
//                     END  
//        END ACTING_YN
//---------------------------------------
//      --, CASE WHEN A.JUNDAL_PART in ('HOM') THEN 'Y'
//      --       WHEN A.ACTING_DATE IS NOT NULL THEN 'Y'
//      --       ELSE  'N'
//      --  END ACTING_YN 
//      , :f_send_yn                                                 SELECT_YN   
//--------------------------------------
//      , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') THEN zz.send_yn
//           ELSE A.IF_DATA_SEND_YN  
//        END SEND_YN
//---------------------------------------
//--      , A.IF_DATA_SEND_YN                                          SEND_YN
//      , F.IF_FLAG                                                  IF_FLAG
//      , F.FKIFS3014                                                FKIFS3014
//      -- SORT : ORDER_DATE(DESC) + 
//      ,  TRIM(LPAD(TO_CHAR(C.SORT_KEY), 2, '0'))
//      || TRIM(TO_CHAR(A.GROUP_SER, '0000000000'))
//      || TRIM(TO_CHAR(NVL(A.BOM_SOURCE_KEY, A.PKOCS2003), '00000000000'))
//      || CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9'
//              ELSE '0'
//         END 
//      || TRIM(TO_CHAR(A.SEQ, '00000000000')) 
//      || TRIM(TO_CHAR(A.PKOCS2003, '00000000000'))                ORDER_BY_KEY 
//  FROM 
//     -- INP1001                AA
//       VW_OCS_INP1001_01     AA
//     , INP1002               AB
//     , OCS2003               A
//     , OCS0103               BB
//     , BAS0310               BC
//---------------------------
//     , (select b.hosp_code, a.order_gubun, b.order_date, b.act_res_date, b.fkocs2003, nvl(b.if_data_send_yn, 'N') send_yn, max(b.acting_date) acting_date
//             , (select count(1)
//                  from ocs2017 y
//                 where y.hosp_code = b.hosp_code
//                   and y.fkocs2003 = b.fkocs2003
//                   and y.act_res_date = :f_acting_date
//                   and y.pass_date is not null) cnt
//             , b.fkinp3010
//          from ocs2017 b
//             , ocs2003 a
//         where a.hosp_code  = :f_hosp_code
//           and a.bunho      = :f_bunho
///*           AND (        A.ACTING_DATE          = :f_acting_date 
//                OR (    A.ACTING_DATE          IS NULL
//                    AND A.ORDER_DATE           = :f_acting_date
//                   )
//               )*/
//           
//           and b.hosp_code  = a.hosp_code
//           and b.fkocs2003  = a.pkocs2003
//           and b.act_res_date = :f_acting_date
//          -- and b.pass_date is not null
//           AND (
//                   (    :f_send_yn             = 'Y' 
//                    AND nvl(B.If_Data_Send_Yn, 'N') = 'Y'
//                   )
//                    OR
//                   (
//                        :f_send_yn            <> 'Y'
//                    AND nvl(B.If_Data_Send_Yn, 'N') = 'N'
//                   )
//               )
//         group by b.hosp_code, a.order_gubun, b.order_date, b.act_res_date, b.fkocs2003, b.if_data_send_yn, b.fkinp3010
//         order by b.hosp_code, a.order_gubun, b.order_date, b.act_res_date, b.fkocs2003
//       )                    zz
//--------------------------
//     --
//     , OCS0132               C
//     , OCS0116               D
//     , BAS0270 H
//     , (
//        SELECT X.HOSP_CODE, X.FKOCS2003, X.FKINP3010, X.IF_FLAG, X.FKIFS3014
//          FROM IFS4011 X  
//         WHERE X.HOSP_CODE       = :f_hosp_code
//           AND X.FKINP3010       = :f_pkinp3010
//           AND X.PKIFS4011       IN (SELECT MAX(Z.PKIFS4011) PKIFS4011
//                                       FROM IFS4011 Z
//                                      WHERE Z.HOSP_CODE = X.HOSP_CODE
//                                        AND Z.BUNHO     = X.BUNHO
//                                      GROUP BY Z.FKOCS2003, Z.HOSP_CODE, Z.FKINP3010
//                                    )
//       ) F
// WHERE 1=1
//   -- VW_OCS_INP1001_01 - INP1001
//   AND AA.HOSP_CODE                    = :f_hosp_code
//   AND AA.BUNHO                        = :f_bunho
//   --
//   AND AA.JAEWON_FLAG                  = 'Y'
//   --
//   AND A.HOSP_CODE                     = AA.HOSP_CODE
//   AND (
//           (    'Y'                             = :f_send_yn 
//           -- AND A.FKINP3010                     = :f_pkinp3010
//              AND nvl(zz.FKINP3010, A.FKINP3010)       = :f_pkinp3010
//           )
//            OR
//           (
//                :f_send_yn                      <> 'Y'
//            AND A.BUNHO                         = AA.BUNHO
//            AND A.FKINP1001                     = :f_pkinp1001 
///*            AND (        A.ACTING_DATE          = :f_acting_date 
//                 OR (    A.ACTING_DATE          IS NULL
//                     AND A.ORDER_DATE           = :f_acting_date
//                    )
//                )*/
//            AND (        BB.ORDER_GUBUN         in ('B', 'C') and 
//                         zz.act_res_date          = :f_acting_date
//                  OR (    BB.ORDER_GUBUN         not in ('B', 'C') and 
//                          (        A.ACTING_DATE          = :f_acting_date
//                           OR (    A.ACTING_DATE          IS NULL
//                               AND A.ORDER_DATE           = :f_acting_date
//                              )
//                          )
//                      )
//                 )
//            --AND B.OCS_FLAG                     IN ('1', '2')
//--------------------------------------------------
//            AND (        BB.ORDER_GUBUN         in ('B', 'C')
//                 OR (    BB.ORDER_GUBUN         not in ('B', 'C')
//                     AND NVL(A.IF_DATA_SEND_YN, 'N' )    = 'N'
//                    )
//                )
//-------------------------------------------
//   --         AND NVL(A.IF_DATA_SEND_YN, 'N' )    = 'N'
//            AND AA.GWA                          = :f_gwa
//            AND H.ORG_DOCTOR                    = :f_doctor
//            -- ???
//            AND A.NALSU                         >= 0
//            --AND NVL(B.DISPLAY_YN , 'Y')         = 'Y'
//            AND NVL(A.DC_YN,'N')                = 'N'
//            AND NVL(A.MUHYO,'N')                = 'N'
//           )
//       )
//   -- INP1002
//   AND AB.HOSP_CODE                     = AA.HOSP_CODE
//   AND AB.BUNHO                         = AA.BUNHO
//   AND AB.FKINP1001                     = AA.PKINP1001 
//   AND AB.GUBUN_IPWON_DATE              <= NVL(A.ACTING_DATE, A.ORDER_DATE)
//   AND (   AB.GUBUN_TOIWON_DATE         IS NULL
//        OR AB.GUBUN_TOIWON_DATE         >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//       )
//   --
//   AND AB.PKINP1002                    = ( SELECT MAX(Z.PKINP1002)
//                                             FROM INP1002                  Z 
//                                            WHERE Z.HOSP_CODE              = AB.HOSP_CODE
//                                              AND Z.FKINP1001              = AB.FKINP1001
//                                              AND Z.GUBUN_IPWON_DATE       = AB.GUBUN_IPWON_DATE
//                                              AND (   Z.GUBUN_TOIWON_DATE  IS NULL
//                                                   OR Z.GUBUN_TOIWON_DATE  >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                                  )
//                                         )
//-------------------------------
//   and zz.hosp_code (+)= a.hosp_code
//   and zz.fkocs2003 (+)= a.pkocs2003
//-------------------------------
//   -- HANGMOG_CODE
//   AND BB.HOSP_CODE                    = A.HOSP_CODE
//   AND BB.HANGMOG_CODE                 = A.HANGMOG_CODE
//   AND BB.START_DATE                   = (SELECT MAX(Z.START_DATE)
//                                            FROM OCS0103 Z
//                                           WHERE Z.HOSP_CODE       = BB.HOSP_CODE
//                                             AND Z.HANGMOG_CODE    = BB.HANGMOG_CODE
//                                             AND Z.START_DATE      <= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                             AND (   Z.END_DATE    IS NULL
//                                                  OR Z.END_DATE    >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                                 )
//                                         )
//   AND (   BB.END_DATE                 IS NULL
//        OR BB.END_DATE                 >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//       )
//   -- JUMSU
//   AND BC.HOSP_CODE                    = A.HOSP_CODE
//   AND BC.SG_CODE                      = A.SG_CODE
//   AND BC.SG_YMD                       = (SELECT MAX(Z.SG_YMD)
//                                           FROM BAS0310 Z
//                                          WHERE Z.HOSP_CODE       = BC.HOSP_CODE
//                                            AND Z.SG_CODE         = BC.SG_CODE
//                                            AND Z.SG_YMD          <= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                            AND (   Z.BULYONG_YMD IS NULL
//                                                 OR Z.BULYONG_YMD >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                                )
//                                         )
//   AND (   BC.BULYONG_YMD             IS NULL
//        OR BC.BULYONG_YMD             >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//       )
//   -- ORDER_GUBUN_BAS                                       
//   AND C.HOSP_CODE                     (+)= A.HOSP_CODE
//   AND C.CODE_TYPE                     (+)= 'ORDER_GUBUN_BAS'
//   AND C.CODE                          (+)= SUBSTR(A.ORDER_GUBUN, 2, 1)
//   -- SPECIMEN
//   AND D.HOSP_CODE                     (+)= A.HOSP_CODE
//   AND D.SPECIMEN_CODE                 (+)= A.SPECIMEN_CODE
//   --
//   AND F.HOSP_CODE                     (+)= A.HOSP_CODE
//--------------------------------------------------------------
//--   AND F.FKINP3010                     (+)= A.FKINP3010
//--------------------------------------------------------------
//   AND F.FKOCS2003                     (+)= A.PKOCS2003
//   -- DOCTOR
//   AND H.HOSP_CODE                     = AA.HOSP_CODE
//   AND H.DOCTOR                        = AA.DOCTOR
// ORDER BY 
//       A.HOSP_CODE
//     , A.BUNHO
//     , A.ORDER_DATE                    DESC
//     , ORDER_BY_KEY
//";
                #endregion 2013.09.16 LKH S : NEW SQL(detail)

                #region 2013.11.26 update by park.w.j(detail)
//                string QuerySQL = @"-- INP ORDER Before Trans --
//                                    SELECT 
//                                          -- 2013.11.26 update by park.w.j
//                                          -- 内服、注射（退院薬除外）区分処理
//                                            CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN ZZ.FKINP3010
//                                               ELSE A.FKINP3010
//                                            END                                                        PKINP3010
//                                          , A.PKOCS2003                                                PKOCS 
//                                          , A.GROUP_SER                                                GROUP_SER
//                                          , A.GROUP_SER||A.FKINP1001                                   GROUP_INP1001
//                                          , NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME
//                                          , A.HANGMOG_CODE                                             HANGMOG_CODE 
//                                          , BB.HANGMOG_NAME                                             HANGMOG_NAME  
//                                          , D.SPECIMEN_CODE                                            SPECIMEN_CODE
//                                          , D.SPECIMEN_NAME                                            SPECIMEN_NAME
//                                          , A.SURYANG                                                  SURYANG
//                                          , A.ORD_DANUI                                                ORD_DANUI
//                                          , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME
//                                          , A.DV_TIME                                                  DV_TIME 
//                                          , A.DV                                                       DV
//                                          -- 2013.11.26 update by park.w.j
//                                          -- 内服、注射（退院薬除外）区分処理
//                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN 1
//                                               ELSE A.NALSU
//                                            END                                                        NALSU
//                                          , A.JUSA                                                     JUSA
//                                          , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME
//                                          , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', A.JUSA_SPD_GUBUN)  JUSA_SPD_NAME
//                                          , A.BOGYONG_CODE                                             BOGYONG_CODE
//                                          , FN_OCS_BOGYONG_COL_NAME(BB.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN) BOGYONG_NAME
//                                          , NVL(A.EMERGENCY, 'N')                                      EMERGENCY                                
//                                          , A.JUNDAL_PART                                              JUNDAL_PART 
//                                          , A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN
//                                          , ''                                                         DANGIL_GUMSA_ORDER_YN
//                                          , A.OCS_FLAG                                                 OCS_FLAG
//                                          , BB.ORDER_GUBUN                                             ORDER_GUBUN
//                                          , A.BUNHO                                                    BUNHO
//                                          , A.ORDER_DATE                                               ORDER_DATE
//                                          , AA.GWA                                                     GWA
//                                          , H.ORG_DOCTOR                                               DOCTOR
//                                          , A.SEQ                                                      SEQ
//                                          , A.FKOCS1003                                                FKOCS1003
//                                          , A.SUB_SUSUL                                                SUB_SUSUL
//                                          -- 2013.11.26 update by park.w.j
//                                          -- 内服、注射（退院薬除外）区分処理
//                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN ZZ.ACT_RES_DATE
//                                               ELSE CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN A.ORDER_DATE    
//                                                         ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))
//                                                         END
//                                            END                                                        ACTING_DATE
//                                          -- 2013.11.26 update by park.w.j
//                                          -- 内服、注射（退院薬除外）区分処理
//                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN ZZ.ACT_RES_DATE
//                                               ELSE CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN A.ORDER_DATE    
//                                                         ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))
//                                                         END
//                                            END                                                        HOPE_DATE
//                                          , A.SUNAB_DATE                                               SUNAB_DATE
//                                          , 'N'                                                        HOME_CARE_YN
//                                          , NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN 
//                                          , A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN
//                                          , BC.BUN_CODE                                                BUN_CODE
//                                          , BB.INPUT_CONTROL                                           INPUT_CONTROL  
//                                          , A.ORDER_GUBUN                                              ORDER_GUBUN_BAS
//                                          -- 2013.11.26 update by park.w.j
//                                          -- 内服、注射（退院薬除外）区分処理
//                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') 
//                                                      AND NVL(A.TOIWON_DRG_YN,'N') = 'N'
//                                                      AND A.JUNDAL_PART NOT IN ('HOM') THEN DECODE(ZZ.CNT, A.DV, 'Y', 'N')
//                                                 ELSE CASE WHEN A.JUNDAL_PART IN ('HOM') THEN 'Y'
//                                                           WHEN A.ACTING_DATE IS NOT NULL THEN 'Y'
//                                                           ELSE  'N'
//                                                           END  
//                                            END                                                        ACTING_YN
//                                          , :f_send_yn                                                 SELECT_YN   
//                                          -- 2013.11.26 update by park.w.j
//                                          -- 内服、注射（退院薬除外）区分処理
//                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN ZZ.SEND_YN
//                                               ELSE A.IF_DATA_SEND_YN  
//                                            END                                                        SEND_YN
//                                          , F.IF_FLAG                                                  IF_FLAG
//                                          , F.FKIFS3014                                                FKIFS3014
//                                          ,  TRIM(LPAD(TO_CHAR(C.SORT_KEY), 2, '0'))
//                                          || TRIM(TO_CHAR(A.GROUP_SER, '0000000000'))
//                                          || TRIM(TO_CHAR(NVL(A.BOM_SOURCE_KEY, A.PKOCS2003), '00000000000'))
//                                          || CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9'
//                                                  ELSE '0'
//                                             END 
//                                          || TRIM(TO_CHAR(A.SEQ, '00000000000')) 
//                                          || TRIM(TO_CHAR(A.PKOCS2003, '00000000000'))                ORDER_BY_KEY 
//                                      FROM VW_OCS_INP1001_01     AA
//                                         , INP1002               AB
//                                         , OCS2003               A
//                                         , OCS0103               BB
//                                         , BAS0310               BC
//                                         -- 2013.11.26 update by park.w.j
//                                         -- 内服、注射（退院薬除外）区分処理
//                                         -- 投薬記録「OCS2017」追加
//                                         , (SELECT B.HOSP_CODE                               HOSP_CODE
//                                                 , A.ORDER_GUBUN                             ORDER_GUBUN
//                                                 , B.ORDER_DATE                              ORDER_DATE
//                                                 , B.ACT_RES_DATE                            ACT_RES_DATE
//                                                 , B.FKOCS2003                               FKOCS2003
//                                                 , NVL(B.IF_DATA_SEND_YN, 'N')               SEND_YN
//                                                 , MAX(B.ACTING_DATE)                        ACTING_DATE
//                                                 , (SELECT COUNT(1)
//                                                      FROM OCS2017 Y
//                                                     WHERE Y.HOSP_CODE    = B.HOSP_CODE
//                                                       AND Y.FKOCS2003    = B.FKOCS2003
//                                                       AND Y.ACT_RES_DATE = :f_acting_date
//                                                       -- 2013.12.06 update by park.w.j
//                                                       AND NVL(Y.BANNAB_YN, 'N') = 'N'
//                                                       AND Y.PASS_DATE    IS NOT NULL)       CNT  -- 全ての回数の実施可否をチェックする。
//                                                 , B.FKINP3010
//                                              FROM OCS2017 B
//                                                 , OCS2003 A
//                                             WHERE A.HOSP_CODE           = :f_hosp_code
//                                               AND A.BUNHO               = :f_bunho           
//                                               AND B.HOSP_CODE           = A.HOSP_CODE
//                                               AND B.FKOCS2003           = A.PKOCS2003
//                                               AND B.ACT_RES_DATE        = :f_acting_date
//                                               -- 2013.12.06 update by park.w.j
//                                               AND NVL(B.BANNAB_YN, 'N') = 'N'
//                                               AND (
//                                                       (    :f_send_yn             = 'Y' 
//                                                        AND NVL(B.IF_DATA_SEND_YN, 'N') = 'Y'
//                                                       )
//                                                        OR
//                                                       (
//                                                            :f_send_yn            <> 'Y'
//                                                        AND NVL(B.IF_DATA_SEND_YN, 'N') = 'N'
//                                                       )
//                                                   )
//                                             GROUP BY B.HOSP_CODE, A.ORDER_GUBUN, B.ORDER_DATE, B.ACT_RES_DATE, B.FKOCS2003, B.IF_DATA_SEND_YN, B.FKINP3010
//                                             ORDER BY B.HOSP_CODE, A.ORDER_GUBUN, B.ORDER_DATE, B.ACT_RES_DATE, B.FKOCS2003
//                                           )                     ZZ
//                                         --
//                                         , OCS0132               C
//                                         , OCS0116               D
//                                         , BAS0270 H
//                                         , (SELECT X.HOSP_CODE, X.FKOCS2003, X.FKINP3010, X.IF_FLAG, X.FKIFS3014
//                                              FROM IFS4011 X  
//                                             WHERE X.HOSP_CODE       = :f_hosp_code
//                                               AND X.FKINP3010       = :f_pkinp3010
//                                               AND X.PKIFS4011       IN (SELECT MAX(Z.PKIFS4011) PKIFS4011
//                                                                           FROM IFS4011 Z
//                                                                          WHERE Z.HOSP_CODE = X.HOSP_CODE
//                                                                            AND Z.BUNHO     = X.BUNHO
//                                                                          GROUP BY Z.FKOCS2003, Z.HOSP_CODE, Z.FKINP3010
//                                                                        )
//                                           ) F
//                                     WHERE 1=1
//                                       AND AA.HOSP_CODE                    = :f_hosp_code
//                                       AND AA.BUNHO                        = :f_bunho
//                                       --
//                                       AND AA.JAEWON_FLAG                  = 'Y'
//                                       --
//                                       AND A.HOSP_CODE                     = AA.HOSP_CODE
//                                       -- 2013.12.06 update by park.w.j
//                                       AND A.NALSU                         >= 0
//                                       AND NVL(A.DC_YN,'N')                = 'N'
//                                       AND NVL(A.MUHYO,'N')                = 'N'
//                                       -- 
//                                       AND (
//                                               (  :f_send_yn                           = 'Y'
//                                                  AND( 
//                                                         ( SUBSTR(A.ORDER_GUBUN, 2, 1)              IN ('B', 'C')
//                                                           AND NVL(ZZ.FKINP3010, A.FKINP3010)           = :f_pkinp3010
//                                                           AND A.PKOCS2003 IN (SELECT FKOCS2003
//                                                                                 FROM OCS2017 A
//                                                                                WHERE A.HOSP_CODE       = :f_hosp_code
//                                                                                  AND A.FKINP3010       = :f_pkinp3010
//                                                                                  AND A.ACT_RES_DATE    = :f_acting_date
//                                                                                  AND A.IF_DATA_SEND_YN = 'Y')
//                                                          )
//                                                      )
//                                                      OR
//                                                      (
//                                                         ( SUBSTR(A.ORDER_GUBUN, 2, 1)           NOT   IN ('B', 'C')
//                                                           AND NVL(ZZ.FKINP3010, A.FKINP3010)           = :f_pkinp3010
//                                                          )
//                                                       )
//                                                )
//                                                OR
//                                               (
//                                                  :f_send_yn                           <> 'Y'
//                                                   AND A.BUNHO                         = AA.BUNHO
//                                                   AND A.FKINP1001                     = :f_pkinp1001 
//                                                   -- 2013.11.26 update by park.w.j
//                                                   -- 内服、注射（退院薬除外）区分処理
//                                                   AND (        SUBSTR(A.ORDER_GUBUN, 2, 1)                   IN ('B', 'C')
//                                                                AND NVL(A.TOIWON_DRG_YN,'N')     = 'N'
//                                                                AND ZZ.ACT_RES_DATE              = :f_acting_date
//                                                         OR (    
//                                                                 (SUBSTR(A.ORDER_GUBUN, 2, 1)                 IN ('B', 'C', 'D')
//                                                                 AND NVL(A.TOIWON_DRG_YN,'N')    <> 'N'
//                                                                 AND 
//                                                                 (        A.ACTING_DATE          = :f_acting_date
//                                                                  OR (    A.ACTING_DATE          IS NULL
//                                                                      AND NVL(A.HOPE_DATE, A.ORDER_DATE) = :f_acting_date
//                                                                     )
//                                                                 )
//                                                                 ) OR
//                                                                 
//                                                                 SUBSTR(A.ORDER_GUBUN, 2, 1)                  NOT IN ('B', 'C')
//                                                                 AND NVL(A.TOIWON_DRG_YN,'N')    = 'N'
//                                                                 AND 
//                                                                 (        A.ACTING_DATE          = :f_acting_date
//                                                                  OR (    A.ACTING_DATE          IS NULL
//                                                                      AND NVL(A.HOPE_DATE, A.ORDER_DATE) = :f_acting_date
//                                                                     )
//                                                                 )
//                                                             )
//                                                        )
//                                                   -- 2013.11.26 update by park.w.j
//                                                   -- 内服、注射（退院薬除外）区分処理
//                                                   AND (        SUBSTR(A.ORDER_GUBUN, 2, 1)                    IN ('B', 'C')
//                                                                AND NVL(A.TOIWON_DRG_YN,'N')      = 'N'
//                                                        OR (    
//                                                                (SUBSTR(A.ORDER_GUBUN, 2, 1)                   IN ('B', 'C', 'D')
//                                                                AND NVL(A.TOIWON_DRG_YN,'N')      <> 'N'
//                                                                AND NVL(A.IF_DATA_SEND_YN, 'N' )  = 'N'
//                                                                ) OR
//                                                                SUBSTR(A.ORDER_GUBUN, 2, 1)                    NOT IN ('B', 'C')
//                                                                AND NVL(A.TOIWON_DRG_YN,'N')      = 'N'
//                                                                AND NVL(A.IF_DATA_SEND_YN, 'N' )  = 'N'
//                                                           )
//                                                       )
//                                                   AND AA.GWA                          = :f_gwa
//                                                   AND H.ORG_DOCTOR                    = :f_doctor
//                                                   --
//                                                   -- 2013.12.06 update by park.w.j
//                                                   --AND A.NALSU                         >= 0
//                                                   --AND NVL(A.DC_YN,'N')                = 'N'
//                                                   --AND NVL(A.MUHYO,'N')                = 'N'
//                                               )
//                                           )
//                                       AND AB.HOSP_CODE                     = AA.HOSP_CODE
//                                       AND AB.BUNHO                         = AA.BUNHO
//                                       AND AB.FKINP1001                     = AA.PKINP1001 
//                                       AND AB.GUBUN_IPWON_DATE              <= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                       AND (   AB.GUBUN_TOIWON_DATE         IS NULL
//                                            OR AB.GUBUN_TOIWON_DATE         >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                           )
//                                       --
//                                       AND AB.PKINP1002                    = ( SELECT MAX(Z.PKINP1002)
//                                                                                 FROM INP1002                  Z 
//                                                                                WHERE Z.HOSP_CODE              = AB.HOSP_CODE
//                                                                                  AND Z.FKINP1001              = AB.FKINP1001
//                                                                                  AND Z.GUBUN_IPWON_DATE       = AB.GUBUN_IPWON_DATE
//                                                                                  AND (   Z.GUBUN_TOIWON_DATE  IS NULL
//                                                                                       OR Z.GUBUN_TOIWON_DATE  >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                                                                      )
//                                                                             )
//                                       -- 2013.11.26 update by park.w.j
//                                       -- 内服、注射（退院薬除外）区分処理
//                                       -- 投薬記録「OCS2017」追加
//                                       AND ZZ.HOSP_CODE                   (+)= A.HOSP_CODE
//                                       AND ZZ.FKOCS2003                   (+)= A.PKOCS2003
//                                       -- HANGMOG_CODE
//                                       AND BB.HOSP_CODE                    = A.HOSP_CODE
//                                       AND BB.HANGMOG_CODE                 = A.HANGMOG_CODE
//                                       AND BB.START_DATE                   = (SELECT MAX(Z.START_DATE)
//                                                                                FROM OCS0103 Z
//                                                                               WHERE Z.HOSP_CODE       = BB.HOSP_CODE
//                                                                                 AND Z.HANGMOG_CODE    = BB.HANGMOG_CODE
//                                                                                 AND Z.START_DATE      <= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                                                                 AND (   Z.END_DATE    IS NULL
//                                                                                      OR Z.END_DATE    >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                                                                     )
//                                                                             )
//                                       AND (   BB.END_DATE                 IS NULL
//                                            OR BB.END_DATE                 >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                           )
//                                       -- JUMSU
//                                       AND BC.HOSP_CODE                    = A.HOSP_CODE
//                                       AND BC.SG_CODE                      = A.SG_CODE
//                                       AND BC.SG_YMD                       = (SELECT MAX(Z.SG_YMD)
//                                                                               FROM BAS0310 Z
//                                                                              WHERE Z.HOSP_CODE       = BC.HOSP_CODE
//                                                                                AND Z.SG_CODE         = BC.SG_CODE
//                                                                                AND Z.SG_YMD          <= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                                                                AND (   Z.BULYONG_YMD IS NULL
//                                                                                     OR Z.BULYONG_YMD >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                                                                    )
//                                                                             )
//                                       AND (   BC.BULYONG_YMD             IS NULL
//                                            OR BC.BULYONG_YMD             >= NVL(A.ACTING_DATE, A.ORDER_DATE)
//                                           )
//                                       -- ORDER_GUBUN_BAS                                       
//                                       AND C.HOSP_CODE                     (+)= A.HOSP_CODE
//                                       AND C.CODE_TYPE                     (+)= 'ORDER_GUBUN_BAS'
//                                       AND C.CODE                          (+)= SUBSTR(A.ORDER_GUBUN, 2, 1)
//                                       -- SPECIMEN
//                                       AND D.HOSP_CODE                     (+)= A.HOSP_CODE
//                                       AND D.SPECIMEN_CODE                 (+)= A.SPECIMEN_CODE
//                                       --
//                                       AND F.HOSP_CODE                     (+)= A.HOSP_CODE
//                                       AND F.FKOCS2003                     (+)= A.PKOCS2003
//                                       -- DOCTOR
//                                       AND H.HOSP_CODE                     = AA.HOSP_CODE
//                                       AND H.DOCTOR                        = AA.DOCTOR
//                                     ORDER BY 
//                                           A.HOSP_CODE
//                                         , A.BUNHO
//                                         , A.ORDER_DATE                    DESC
//                                         , ORDER_BY_KEY
//                                    ";
                #endregion 2013.11.26 update by park.w.j(detail)

                #region 2014.1.21 update by park.w.j(detail)
                string QuerySQL = @"-- INP ORDER Trans Detail --
                                    SELECT 
                                          -- 2013.11.26 update by park.w.j
                                          -- 内服、注射（退院薬除外）区分処理
                                            CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN ZZ.FKINP3010
                                               ELSE A.FKINP3010
                                            END                                                        PKINP3010
                                          , A.PKOCS2003                                                PKOCS 
                                          , A.GROUP_SER                                                GROUP_SER
                                          , A.GROUP_SER||A.FKINP1001                                   GROUP_INP1001
                                          , NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME
                                          , A.HANGMOG_CODE                                             HANGMOG_CODE 
                                          , BB.HANGMOG_NAME                                             HANGMOG_NAME  
                                          , D.SPECIMEN_CODE                                            SPECIMEN_CODE
                                          , D.SPECIMEN_NAME                                            SPECIMEN_NAME
                                          , A.SURYANG                                                  SURYANG
                                          , A.ORD_DANUI                                                ORD_DANUI
                                          , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME
                                          , A.DV_TIME                                                  DV_TIME 
                                          , A.DV                                                       DV
                                          -- 2013.11.26 update by park.w.j
                                          -- 内服、注射（退院薬除外）区分処理
                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN 1
                                               ELSE A.NALSU
                                            END                                                        NALSU
                                          , A.JUSA                                                     JUSA
                                          , FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME
                                          , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN', A.JUSA_SPD_GUBUN)  JUSA_SPD_NAME
                                          , A.BOGYONG_CODE                                             BOGYONG_CODE
                                          , FN_OCS_BOGYONG_COL_NAME(BB.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN) BOGYONG_NAME
                                          , NVL(A.EMERGENCY, 'N')                                      EMERGENCY                                
                                          , A.JUNDAL_PART                                              JUNDAL_PART 
                                          , A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN
                                          , ''                                                         DANGIL_GUMSA_ORDER_YN
                                          , A.OCS_FLAG                                                 OCS_FLAG
                                          , BB.ORDER_GUBUN                                             ORDER_GUBUN
                                          , A.BUNHO                                                    BUNHO
                                          , A.ORDER_DATE                                               ORDER_DATE
                                          , AA.GWA                                                     GWA
                                          -- modified by LHD 2014.07.02 , H.ORG_DOCTOR                                               DOCTOR
                                          , SUBSTR(INPUT_DOCTOR, 3)                                    DOCTOR
                                          , A.SEQ                                                      SEQ
                                          , A.FKOCS1003                                                FKOCS1003
                                          , A.SUB_SUSUL                                                SUB_SUSUL
                                          -- 2013.11.26 update by park.w.j
                                          -- 内服、注射（退院薬除外）区分処理
                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN ZZ.ACT_RES_DATE
                                               ELSE CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN A.ORDER_DATE    
                                                         ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))
                                                         END
                                            END                                                        ACTING_DATE
                                          -- 2013.11.26 update by park.w.j
                                          -- 内服、注射（退院薬除外）区分処理
                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN ZZ.ACT_RES_DATE
                                               ELSE CASE WHEN A.JUNDAL_PART  IN ('HOM') THEN A.ORDER_DATE    
                                                         ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))
                                                         END
                                            END                                                        HOPE_DATE
                                          , A.SUNAB_DATE                                               SUNAB_DATE
                                          , 'N'                                                        HOME_CARE_YN
                                          , NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN 
                                          , A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN
                                          , BC.BUN_CODE                                                BUN_CODE
                                          , BB.INPUT_CONTROL                                           INPUT_CONTROL  
                                          , A.ORDER_GUBUN                                              ORDER_GUBUN_BAS
                                          -- 2013.11.26 update by park.w.j
                                          -- 内服、注射（退院薬除外）区分処理
                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') 
                                                      AND NVL(A.TOIWON_DRG_YN,'N') = 'N'
                                                      AND A.JUNDAL_PART NOT IN ('HOM') THEN DECODE(ZZ.CNT, A.DV, 'Y', 'N')
                                                 ELSE CASE WHEN A.JUNDAL_PART IN ('HOM') THEN 'Y'
                                                           WHEN A.ACTING_DATE IS NOT NULL THEN 'Y'
                                                           ELSE  'N'
                                                           END  
                                            END                                                        ACTING_YN
                                          , :f_send_yn                                                 SELECT_YN   
                                          -- 2013.11.26 update by park.w.j
                                          -- 内服、注射（退院薬除外）区分処理
                                          , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1)  IN ('B', 'C') AND NVL(A.TOIWON_DRG_YN,'N') = 'N' THEN ZZ.SEND_YN
                                               ELSE A.IF_DATA_SEND_YN  
                                            END                                                        SEND_YN
                                          --, F.IF_FLAG                                                  IF_FLAG
                                          --, F.FKIFS3014                                                FKIFS3014
                                          -- 2014.1.21 update by park.w.j
                                          , (SELECT MAX(Z.IF_FLAG)
                                               FROM IFS4011 Z
                                              WHERE Z.HOSP_CODE = :f_hosp_code
                                                AND Z.FKINP3010 = :f_pkinp3010
                                                AND Z.FKOCS2003 = FN_OCS_GET_SOURCE_KEY(:f_hosp_code, 'I', A.PKOCS2003)) IF_FLAG

                                          , (SELECT MAX(Z.FKIFS3014)
                                               FROM IFS4011 Z
                                              WHERE Z.HOSP_CODE = :f_hosp_code
                                                AND Z.FKINP3010 = :f_pkinp3010
                                                AND Z.FKOCS2003 = FN_OCS_GET_SOURCE_KEY(:f_hosp_code, 'I', A.PKOCS2003)) FKIFS3014
                                          ,  TRIM(LPAD(TO_CHAR(C.SORT_KEY), 2, '0'))
                                          || TRIM(TO_CHAR(A.GROUP_SER, '0000000000'))
                                          || TRIM(TO_CHAR(NVL(A.BOM_SOURCE_KEY, A.PKOCS2003), '00000000000'))
                                          || CASE WHEN A.BOM_SOURCE_KEY IS NOT NULL THEN '9'
                                                  ELSE '0'
                                             END 
                                          || TRIM(TO_CHAR(A.SEQ, '00000000000')) 
                                          || TRIM(TO_CHAR(A.PKOCS2003, '00000000000'))                ORDER_BY_KEY 
                                      FROM VW_OCS_INP1001_01     AA
                                         , INP1002               AB
                                         , OCS2003               A
                                         , OCS0103               BB
                                         , BAS0310               BC
                                         -- 2013.11.26 update by park.w.j
                                         -- 内服、注射（退院薬除外）区分処理
                                         -- 投薬記録「OCS2017」追加
                                         , (SELECT B.HOSP_CODE                               HOSP_CODE
                                                 , A.ORDER_GUBUN                             ORDER_GUBUN
                                                 , B.ORDER_DATE                              ORDER_DATE
                                                 , B.ACT_RES_DATE                            ACT_RES_DATE
                                                 , B.FKOCS2003                               FKOCS2003
                                                 , NVL(B.IF_DATA_SEND_YN, 'N')               SEND_YN
                                                 , MAX(B.ACTING_DATE)                        ACTING_DATE
                                                 , (SELECT COUNT(1)
                                                      FROM OCS2017 Y
                                                     WHERE Y.HOSP_CODE    = B.HOSP_CODE
                                                       AND Y.FKOCS2003    = B.FKOCS2003
                                                       AND Y.ACT_RES_DATE = :f_acting_date
                                                       -- 2013.12.06 update by park.w.j
                                                       AND NVL(Y.BANNAB_YN, 'N') = 'N'
                                                       AND Y.PASS_DATE    IS NOT NULL)       CNT  -- 全ての回数の実施可否をチェックする。
                                                 , B.FKINP3010
                                              FROM OCS2017 B
                                                 , OCS2003 A
                                             WHERE A.HOSP_CODE           = :f_hosp_code
                                               AND A.BUNHO               = :f_bunho           
                                               AND B.HOSP_CODE           = A.HOSP_CODE
                                               AND B.FKOCS2003           = A.PKOCS2003
                                               AND B.ACT_RES_DATE        = :f_acting_date
                                               -- 2013.12.06 update by park.w.j
                                               AND NVL(B.BANNAB_YN, 'N') = 'N'
                                               AND (
                                                       (    :f_send_yn             = 'Y' 
                                                        AND NVL(B.IF_DATA_SEND_YN, 'N') = 'Y'
                                                       )
                                                        OR
                                                       (
                                                            :f_send_yn            <> 'Y'
                                                        AND NVL(B.IF_DATA_SEND_YN, 'N') = 'N'
                                                       )
                                                   )
                                             GROUP BY B.HOSP_CODE, A.ORDER_GUBUN, B.ORDER_DATE, B.ACT_RES_DATE, B.FKOCS2003, B.IF_DATA_SEND_YN, B.FKINP3010
                                             ORDER BY B.HOSP_CODE, A.ORDER_GUBUN, B.ORDER_DATE, B.ACT_RES_DATE, B.FKOCS2003
                                           )                     ZZ
                                         --
                                         , OCS0132               C
                                         , OCS0116               D
                                         --, BAS0270 H
                                         --, (SELECT X.HOSP_CODE, X.FKOCS2003, X.FKINP3010, X.IF_FLAG, X.FKIFS3014
                                         --     FROM IFS4011 X  
                                         --    WHERE X.HOSP_CODE       = :f_hosp_code
                                         --      AND X.FKINP3010       = :f_pkinp3010
                                         --      AND X.PKIFS4011       IN (SELECT MAX(Z.PKIFS4011) PKIFS4011
                                         --                                  FROM IFS4011 Z
                                         --                                 WHERE Z.HOSP_CODE = X.HOSP_CODE
                                         --                                   AND Z.BUNHO     = X.BUNHO
                                         --                                 GROUP BY Z.FKOCS2003, Z.HOSP_CODE, Z.FKINP3010
                                         --                               )
                                         --  ) F
                                     WHERE 1=1
                                       AND AA.HOSP_CODE                    = :f_hosp_code
                                       AND AA.BUNHO                        = :f_bunho
                                       --
                                       AND AA.JAEWON_FLAG                  = 'Y'
                                       --AND AA.GWA                          = :f_gwa
                                       --
                                       AND A.HOSP_CODE                     = AA.HOSP_CODE
                                       AND A.FKINP1001                     = AA.PKINP1001
                                       -- 2013.12.06 update by park.w.j
                                       AND A.NALSU                         >= 0
                                       AND NVL(A.DC_YN,'N')                = 'N'
                                       AND NVL(A.MUHYO,'N')                = 'N'
                                       -- 
                                       AND (
                                               (  :f_send_yn                           = 'Y'
                                                  AND( 
                                                         ( SUBSTR(A.ORDER_GUBUN, 2, 1)              IN ('B', 'C')
                                                           AND NVL(A.TOIWON_DRG_YN,'N')     = 'N'
                                                           AND ZZ.FKINP3010           = :f_pkinp3010
                                                           AND ZZ.FKOCS2003           = A.PKOCS2003
                                                          )
                                                      )
                                                      OR
                                                      (
                                                         ( SUBSTR(A.ORDER_GUBUN, 2, 1)                 IN ('B', 'C', 'D')
                                                           AND NVL(A.TOIWON_DRG_YN,'N')    <> 'N'
                                                           AND A.FKINP3010           = :f_pkinp3010
                                                          ) OR (
                                                           SUBSTR(A.ORDER_GUBUN, 2, 1)                  NOT IN ('B', 'C')
                                                           AND NVL(A.TOIWON_DRG_YN,'N')    = 'N'
                                                           AND A.FKINP3010           = :f_pkinp3010
                                                          )
                                                       )
                                                )
                                                OR
                                               (
                                                  :f_send_yn                           <> 'Y'
                                                   AND A.BUNHO                         = AA.BUNHO
                                                   AND A.FKINP1001                     = :f_pkinp1001 
                                                   -- 2013.11.26 update by park.w.j
                                                   -- 内服、注射（退院薬除外）区分処理
                                                   AND (        SUBSTR(A.ORDER_GUBUN, 2, 1)                   IN ('B', 'C')
                                                                AND NVL(A.TOIWON_DRG_YN,'N')     = 'N'
                                                                --AND ZZ.ACT_RES_DATE              = :f_acting_date
                                                                AND ZZ.FKOCS2003 = A.PKOCS2003
                                                         OR (    
                                                                 (SUBSTR(A.ORDER_GUBUN, 2, 1)                 IN ('B', 'C', 'D')
                                                                 AND NVL(A.TOIWON_DRG_YN,'N')    <> 'N'
                                                                 AND NVL(A.IF_DATA_SEND_YN, 'N' )  = 'N'
                                                                 AND 
                                                                 (        A.ACTING_DATE          = :f_acting_date
                                                                  OR (    A.ACTING_DATE          IS NULL
                                                                      AND NVL(A.HOPE_DATE, A.ORDER_DATE) = :f_acting_date
                                                                     )
                                                                 )
                                                                 ) OR (
                                                                 
                                                                 SUBSTR(A.ORDER_GUBUN, 2, 1)                  NOT IN ('B', 'C')
                                                                 AND NVL(A.TOIWON_DRG_YN,'N')    = 'N'
                                                                 AND NVL(A.IF_DATA_SEND_YN, 'N' )  = 'N'
                                                                 AND (        A.ACTING_DATE          = :f_acting_date
                                                                      OR (    A.ACTING_DATE          IS NULL
                                                                          AND NVL(A.HOPE_DATE, A.ORDER_DATE) = :f_acting_date
                                                                         )
                                                                     )
                                                                 )
                                                             )
                                                        )
                                                   -- 2013.11.26 update by park.w.j
                                                   -- 内服、注射（退院薬除外）区分処理
                                                   --AND (        SUBSTR(A.ORDER_GUBUN, 2, 1)                    IN ('B', 'C')
                                                   --             AND NVL(A.TOIWON_DRG_YN,'N')      = 'N'
                                                   --     OR (    
                                                   --             (SUBSTR(A.ORDER_GUBUN, 2, 1)                   IN ('B', 'C', 'D')
                                                   --             AND NVL(A.TOIWON_DRG_YN,'N')      <> 'N'
                                                   --             AND NVL(A.IF_DATA_SEND_YN, 'N' )  = 'N'
                                                   --             ) OR
                                                   --             SUBSTR(A.ORDER_GUBUN, 2, 1)                    NOT IN ('B', 'C')
                                                   --             AND NVL(A.TOIWON_DRG_YN,'N')      = 'N'
                                                   --             AND NVL(A.IF_DATA_SEND_YN, 'N' )  = 'N'
                                                   --        )
                                                   --    )
                                                   --AND AA.GWA                          = :f_gwa
                                                   --AND H.ORG_DOCTOR                    = :f_doctor
                                                   --
                                                   -- 2013.12.06 update by park.w.j
                                                   --AND A.NALSU                         >= 0
                                                   --AND NVL(A.DC_YN,'N')                = 'N'
                                                   --AND NVL(A.MUHYO,'N')                = 'N'
                                               )
                                           )
                                       AND AB.HOSP_CODE                     = AA.HOSP_CODE
                                       AND AB.BUNHO                         = AA.BUNHO
                                       AND AB.FKINP1001                     = AA.PKINP1001 
                                       AND AB.GUBUN_IPWON_DATE              <= NVL(A.ACTING_DATE, A.ORDER_DATE)
                                       AND (   AB.GUBUN_TOIWON_DATE         IS NULL
                                            OR AB.GUBUN_TOIWON_DATE         >= NVL(A.ACTING_DATE, A.ORDER_DATE)
                                           )
                                       --
                                       AND AB.PKINP1002                    = ( SELECT MAX(Z.PKINP1002)
                                                                                 FROM INP1002                  Z 
                                                                                WHERE Z.HOSP_CODE              = AB.HOSP_CODE
                                                                                  AND Z.FKINP1001              = AB.FKINP1001
                                                                                  AND Z.GUBUN_IPWON_DATE       = AB.GUBUN_IPWON_DATE
                                                                                  AND (   Z.GUBUN_TOIWON_DATE  IS NULL
                                                                                       OR Z.GUBUN_TOIWON_DATE  >= NVL(A.ACTING_DATE, A.ORDER_DATE)
                                                                                      )
                                                                             )
                                       -- 2013.11.26 update by park.w.j
                                       -- 内服、注射（退院薬除外）区分処理
                                       -- 投薬記録「OCS2017」追加
                                       AND ZZ.HOSP_CODE                   (+)= A.HOSP_CODE
                                       AND ZZ.FKOCS2003                   (+)= A.PKOCS2003
                                       -- HANGMOG_CODE
                                       AND BB.HOSP_CODE                    = A.HOSP_CODE
                                       AND BB.HANGMOG_CODE                 = A.HANGMOG_CODE
                                       AND BB.START_DATE                   = (SELECT MAX(Z.START_DATE)
                                                                                FROM OCS0103 Z
                                                                               WHERE Z.HOSP_CODE       = BB.HOSP_CODE
                                                                                 AND Z.HANGMOG_CODE    = BB.HANGMOG_CODE
                                                                                 AND Z.START_DATE      <= NVL(A.ACTING_DATE, A.ORDER_DATE)
                                                                                 AND (   Z.END_DATE    IS NULL
                                                                                      OR Z.END_DATE    >= NVL(A.ACTING_DATE, A.ORDER_DATE)
                                                                                     )
                                                                             )
                                       AND (   BB.END_DATE                 IS NULL
                                            OR BB.END_DATE                 >= NVL(A.ACTING_DATE, A.ORDER_DATE)
                                           )
                                       -- JUMSU
                                       AND BC.HOSP_CODE                    = A.HOSP_CODE
                                       AND BC.SG_CODE                      = A.SG_CODE
                                       AND BC.SG_YMD                       = (SELECT MAX(Z.SG_YMD)
                                                                               FROM BAS0310 Z
                                                                              WHERE Z.HOSP_CODE       = BC.HOSP_CODE
                                                                                AND Z.SG_CODE         = BC.SG_CODE
                                                                                AND Z.SG_YMD          <= NVL(A.ACTING_DATE, A.ORDER_DATE)
                                                                                AND (   Z.BULYONG_YMD IS NULL
                                                                                     OR Z.BULYONG_YMD >= NVL(A.ACTING_DATE, A.ORDER_DATE)
                                                                                    )
                                                                             )
                                       AND (   BC.BULYONG_YMD             IS NULL
                                            OR BC.BULYONG_YMD             >= NVL(A.ACTING_DATE, A.ORDER_DATE)
                                           )
                                       -- ORDER_GUBUN_BAS                                       
                                       AND C.HOSP_CODE                     (+)= A.HOSP_CODE
                                       AND C.CODE_TYPE                     (+)= 'ORDER_GUBUN_BAS'
                                       AND C.CODE                          (+)= SUBSTR(A.ORDER_GUBUN, 2, 1)
                                       -- SPECIMEN
                                       AND D.HOSP_CODE                     (+)= A.HOSP_CODE
                                       AND D.SPECIMEN_CODE                 (+)= A.SPECIMEN_CODE
                                       --
                                       --AND F.HOSP_CODE                     (+)= A.HOSP_CODE
                                       --AND F.FKOCS2003                     (+)= A.PKOCS2003
                                       
                                       -- DOCTOR  -- modified by LHD 2014.07.02
                                       --AND H.HOSP_CODE                     = AA.HOSP_CODE
                                       --AND H.DOCTOR                        = AA.DOCTOR
                                       --AND H.ORG_DOCTOR                    = :f_doctor
                                     ORDER BY 
                                           A.HOSP_CODE
                                         , A.BUNHO
                                         , A.ORDER_DATE                    DESC
                                         , ORDER_BY_KEY
                                    ";
                #endregion 2013.11.26 update by park.w.j(detail)

                grdEdit.QuerySQL = QuerySQL;

                //SQL문체크
                if (grdEdit.QuerySQL != "")
                {
                    if (grdEdit.QueryLayout(false))
                    {
                        //그리트디폴트이미지셋팅
                        this.SettingDefaultImageGrid();
                    }
                }
            }
            #endregion grdOCS2003

            #region grdSiksa
            if (grdEdit.Name.Equals("grdSiksa"))
            {
                #region INP Siksa Trans
                string QuerySQL = @"-- INP Siksa Trans --
                                    SELECT A.BUNHO                                            BUNHO
                                         , A.FKINP1001                                        PKOCS
                                         , A.FKINP1001                                        FKINP1001
                                         , A.BUNHO || A.FKINP1001                             GROUP_INP1001
                                         , MAX(A.ORDER_DATE)                                  ORDER_DATE
                                         , A.DRT_DATE                                         DRT_DATE
                                         , MIN(DECODE(A.TIME_GUBUN, '0', DECODE(A.SIKSA_CODE, '000'
                                                                                            , (SELECT X.NUR_SO_NAME
                                                                                                 FROM NUR0112 X
                                                                                                WHERE X.HOSP_CODE = 'K01'
                                                                                                  AND X.NUR_GR_CODE = '03'
                                                                                                  AND X.NUR_MD_CODE = '0301'
                                                                                                  AND X.NUR_SO_CODE = '000')
                                                                                            , '001'
                                                                                            , (SELECT X.NUR_SO_NAME
                                                                                                 FROM NUR0112 X
                                                                                                WHERE X.HOSP_CODE = 'K01'
                                                                                                  AND X.NUR_GR_CODE = '03'
                                                                                                  AND X.NUR_MD_CODE = '0301'
                                                                                                  AND X.NUR_SO_CODE = '001')
                                                                                            , '009'
                                                                                            , (SELECT X.NUR_SO_NAME
                                                                                                 FROM NUR0112 X
                                                                                                WHERE X.HOSP_CODE = 'K01'
                                                                                                  AND X.NUR_GR_CODE = '03'
                                                                                                  AND X.NUR_MD_CODE = '0301'
                                                                                                  AND X.NUR_SO_CODE = '009')
                                                                                 ))) TIME_GUBUN1
                                         , MIN(DECODE(A.TIME_GUBUN, '1', DECODE(A.SIKSA_CODE, '000'
                                                                                            , (SELECT X.NUR_SO_NAME
                                                                                                 FROM NUR0112 X
                                                                                                WHERE X.HOSP_CODE = 'K01'
                                                                                                  AND X.NUR_GR_CODE = '03'
                                                                                                  AND X.NUR_MD_CODE = '0301'
                                                                                                  AND X.NUR_SO_CODE = '000')
                                                                                            , '001'
                                                                                            , (SELECT X.NUR_SO_NAME
                                                                                                 FROM NUR0112 X
                                                                                                WHERE X.HOSP_CODE = 'K01'
                                                                                                  AND X.NUR_GR_CODE = '03'
                                                                                                  AND X.NUR_MD_CODE = '0301'
                                                                                                  AND X.NUR_SO_CODE = '001')
                                                                                            , '009'
                                                                                            , (SELECT X.NUR_SO_NAME
                                                                                                 FROM NUR0112 X
                                                                                                WHERE X.HOSP_CODE = 'K01'
                                                                                                  AND X.NUR_GR_CODE = '03'
                                                                                                  AND X.NUR_MD_CODE = '0301'
                                                                                                  AND X.NUR_SO_CODE = '009')
                                                                                 ))) TIME_GUBUN2
                                         , MIN(DECODE(A.TIME_GUBUN, '2', DECODE(A.SIKSA_CODE, '000'
                                                                                            , (SELECT X.NUR_SO_NAME
                                                                                                 FROM NUR0112 X
                                                                                                WHERE X.HOSP_CODE = 'K01'
                                                                                                  AND X.NUR_GR_CODE = '03'
                                                                                                  AND X.NUR_MD_CODE = '0301'
                                                                                                  AND X.NUR_SO_CODE = '000')
                                                                                            , '001'
                                                                                            , (SELECT X.NUR_SO_NAME
                                                                                                 FROM NUR0112 X
                                                                                                WHERE X.HOSP_CODE = 'K01'
                                                                                                  AND X.NUR_GR_CODE = '03'
                                                                                                  AND X.NUR_MD_CODE = '0301'
                                                                                                  AND X.NUR_SO_CODE = '001')
                                                                                            , '009'
                                                                                            , (SELECT X.NUR_SO_NAME
                                                                                                 FROM NUR0112 X
                                                                                                WHERE X.HOSP_CODE = 'K01'
                                                                                                  AND X.NUR_GR_CODE = '03'
                                                                                                  AND X.NUR_MD_CODE = '0301'
                                                                                                  AND X.NUR_SO_CODE = '009')
                                                                                 ))) TIME_GUBUN3
                                         , :f_send_yn                                SELECT_YN 
                                      FROM OCS2015 A
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.BUNHO     = :f_bunho
                                       AND A.DRT_DATE  BETWEEN :f_yyyymmdd_first AND :f_yyyymmdd_last
                                    GROUP BY A.BUNHO
                                           , A.FKINP1001
                                           --, A.ORDER_DATE
                                           , A.DRT_DATE
                                    ORDER BY A.DRT_DATE";
                #endregion INP Siksa Trans

                grdEdit.QuerySQL = QuerySQL;

                //SQL문체크
                if (grdEdit.QuerySQL != "")
                {
                    if (grdEdit.QueryLayout(false))
                    {
                        //그리트디폴트이미지셋팅
                        //this.SettingDefaultImageGrid();
                    }
                }
            }
            #endregion grdSiksa

            #region grdWoichul
            if (grdEdit.Name.Equals("grdWoichul"))
            {
                #region INP grdWoichul Trans
                string QuerySQL = @"-- INP grdWoichul Trans --
                                    SELECT A.FKINP1001                                                       FKINP1001
                                          ,A.OUT_DATE                                                        FKINP1001
                                          ,A.BUNHO                                                           BUNHO
                                          ,A.OUT_DATE                                                        OUT_DATE
                                          ,A.OUT_TIME                                                        OUT_TIME 
                                          ,A.IN_HOPE_DATE                                                    IN_HOPE_DATE 
                                          ,A.IN_HOPE_TIME                                                    IN_HOPE_TIME 
                                          ,A.IN_TRUE_DATE                                                    IN_TRUE_DATE
                                          ,A.IN_TRUE_TIME                                                    IN_TRUE_TIME
                                          ,FN_NUR_LOAD_CODE_NAME('OUT_OBJECT', A.OUT_OBJECT)                 OUT_OBJECT_TEXT
                                          ,A.OUT_DATE                                                        START_DATE
                                          ,NVL(A.SUNAB_IN_DATE, A.IN_TRUE_DATE)                              END_DATE
                                          ,'Y'                                                               ACTING_YN
                                          ,:f_send_yn                                                        SELECT_YN
                                          , A.IF_DATA_SEND_YN                                                SEND_YN
                                          , 0                                                                SEQ
                                      FROM NUR1014 A
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.BUNHO     = :f_bunho
                                       --AND A.FKINP1001 = :f_pk1001
                                       AND A.OUT_DATE BETWEEN :f_yyyymmdd_first AND :f_yyyymmdd_last
                                       AND A.WOICHUL_WOIBAK_GUBUN = '02'
                                       AND A.IN_TRUE_DATE IS NOT NULL
                                     ORDER BY A.OUT_DATE,A.OUT_TIME DESC";
                #endregion INP grdWoichul Trans

                grdEdit.QuerySQL = QuerySQL;

                //SQL문체크
                if (grdEdit.QuerySQL != "")
                {
                    if (grdEdit.QueryLayout(false))
                    {
                        //그리트디폴트이미지셋팅
                        //this.SettingDefaultImageGrid();
                    }
                }
            }
            #endregion grdWoichul
        }
        #endregion

        #region [ 그리드에디터 쿼리 개시 ]
        private void grid_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            //커런트 그리드 취득
            XEditGrid grdList = this.mCurrentListGrid;

            string tap = this.tabDataGubun.SelectedTab.Tag.ToString();

            if (tap == null)
            {
                return;
            }

            if (tap == "0") // ORDER
            {
                #region Condition of ORDER DETAIL Query
                this.grdOCS2003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdOCS2003.SetBindVarValue("f_bunho", grdList.GetItemString(grdList.CurrentRowNumber, "bunho"));
                this.grdOCS2003.SetBindVarValue("f_pkinp1001", grdList.GetItemString(grdList.CurrentRowNumber, "pkinp1001"));
                this.grdOCS2003.SetBindVarValue("f_pkinp3010", grdList.GetItemString(grdList.CurrentRowNumber, "pkinp3010"));
                this.grdOCS2003.SetBindVarValue("f_send_yn", this.mSend_YN);
                // 2013.09.16 LKH S: ORDER_DATE -> ACTING_DATE
                this.grdOCS2003.SetBindVarValue("f_acting_date", grdList.GetItemString(grdList.CurrentRowNumber, "acting_date"));
                //this.grdOCS2003.SetBindVarValue("f_order_date", grdList.GetItemString(grdList.CurrentRowNumber, "order_date"));
                // 2013.09.16 LKH E: ORDER_DATE -> ACTING_DATE
                this.grdOCS2003.SetBindVarValue("f_gwa", grdList.GetItemString(grdList.CurrentRowNumber, "gwa"));
                this.grdOCS2003.SetBindVarValue("f_doctor", grdList.GetItemString(grdList.CurrentRowNumber, "doctor"));
                //grd.SetBindVarValue("f_gubun", grdList.GetItemString(grdList.CurrentRowNumber, "gubun"));
                #endregion Condition of ORDER DETAIL Query
            }

            if (tap == "1") // SIKSA
            {
                #region Condition of 食事 DETAIL Query
                this.grdSiksa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdSiksa.SetBindVarValue("f_bunho", grdList.GetItemString(grdList.CurrentRowNumber, "bunho"));
                this.grdSiksa.SetBindVarValue("f_yyyymmdd_first", this.monthBox.GetDataValue() + "01");
                this.grdSiksa.SetBindVarValue("f_yyyymmdd_last", this.monthBox.GetDataValue() + DateTime.DaysInMonth(int.Parse(this.monthBox.GetDataValue().Substring(0,4)), int.Parse(this.monthBox.GetDataValue().Substring(4,2))).ToString());
                this.grdSiksa.SetBindVarValue("f_send_yn", this.mSend_YN);
                #endregion Condition of 食事 DETAIL Query
            }

            if (tap == "2") // 外泊
            {
                #region Condition of 外泊 DETAIL Query
                this.grdWoichul.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdWoichul.SetBindVarValue("f_bunho", grdList.GetItemString(grdList.CurrentRowNumber, "bunho"));
                this.grdWoichul.SetBindVarValue("f_yyyymmdd_first", this.monthBox.GetDataValue() + "01");
                this.grdWoichul.SetBindVarValue("f_yyyymmdd_last", this.monthBox.GetDataValue() + DateTime.DaysInMonth(int.Parse(this.monthBox.GetDataValue().Substring(0, 4)), int.Parse(this.monthBox.GetDataValue().Substring(4, 2))).ToString());
                this.grdWoichul.SetBindVarValue("f_send_yn", this.mSend_YN);
                #endregion Condition of 外泊 DETAIL Query
            }
        }
        #endregion

        #region [ 그리드리스트에디터 쿼리 취득 ]
        private string SelectListQuerySQL(string str)
        {
            string QuerySQL = "";
            switch (str)
            {
                case "0":

                    if (this.mSend_YN == "N")
                    {
                        #region INP ORDER LIST Before Trans : comment
                        /*
                        QuerySQL = @"-- INP ORDER LIST Before Trans --
                                     SELECT B.PKINP1001                                                 PKINP1001
                                          , A.BUNHO                                                     BUNHO 
                                          , C.SUNAME                                                    SUNAME
                                          , B.IPWON_DATE                                                IPWON_DATE
                                          , B.IPWON_TIME                                                IPWON_TIME
                                          --, A.INPUT_GWA                                                 GWA
                                          --, A.INPUT_DOCTOR                                              DOCTOR
                                          , B.GWA                                                       GWA
                                          , F.ORG_DOCTOR                                                DOCTOR
                                          , FN_BAS_LOAD_GWA_NAME (B.GWA, A.ORDER_DATE )                 GWA_NAME 
                                          , FN_BAS_LOAD_DOCTOR_NAME (B.GWA||F.ORG_DOCTOR, A.ORDER_DATE) DOCTOR_NAME
                                          , MAX(FN_BAS_LOAD_GWA_NAME(D.TO_HO_DONG1, A.ORDER_DATE))      HO_DONG
                                          , MAX(D.TO_HO_CODE1)                                          HO_CODE
                                          , INS.GUBUN                                                   GUBUN
                                          , A.ORDER_DATE                                                ORDER_DATE
                                          , MAX(A.ACTING_DATE)                                          ACTING_DATE
                                          , A.FKINP3010                                                 PKINP3010   
                                          , A.IF_DATA_SEND_DATE                                         SEND_DATE
                                          , DECODE(B.TOIWON_DATE, NULL, 'N', 'Y')                       TOIWON_YN
                                     FROM OCS2003 A -- 入院 Order
                                        , INP1001 B -- 入院 Master
                                        , OUT0101 C
                                        , VW_OCS_INP2004 D
                                        , BAS0270 F -- 患者の科/医師VIEW
                                        , OCS0103 G
                                        , (SELECT D.PKINP1002
                                                , D.FKINP1001
                                                , D.GUBUN
                                                , E.GUBUN_NAME
                                                , E.GONGBI_YN
                                                , E.START_DATE
                                                , E.END_DATE
                                             FROM INP1002 D -- 入院保険
                                                , BAS0210 E -- 保険類型MASTER
                                            WHERE D.HOSP_CODE = :f_hosp_code 
                                              AND D.BUNHO     = :f_bunho
                                              AND E.HOSP_CODE   = D.HOSP_CODE
                                              AND E.GUBUN       = D.GUBUN
                                           ) INS
                                    WHERE A.HOSP_CODE                        = :f_hosp_code 
                                      AND A.BUNHO                            = :f_bunho
                                      AND A.ORDER_DATE BETWEEN :f_order_from_date AND :f_order_to_date
                                      AND NVL(A.IF_DATA_SEND_YN, 'N' )       = 'N'
                                      AND NVL(A.NDAY_YN,'N')                 = 'N' 
                                      AND A.NALSU                           >= 0
                                      AND NVL(A.DC_YN,'N')                   = 'N'
                                      AND B.HOSP_CODE                        = A.HOSP_CODE
                                      AND B.BUNHO                            = A.BUNHO
                                      AND B.PKINP1001                        = A.FKINP1001
                                      AND C.HOSP_CODE                        = A.HOSP_CODE
                                      AND C.BUNHO                            = A.BUNHO
                                      AND D.HOSP_CODE                        = A.HOSP_CODE
                                      AND D.BUNHO                            = A.BUNHO
                                      AND D.JAEWON_DATE                      = TRUNC(SYSDATE)
                                      AND F.HOSP_CODE                        = B.HOSP_CODE
                                      AND F.DOCTOR                           = B.DOCTOR
                                      AND G.HOSP_CODE                        = A.HOSP_CODE
                                      AND G.HANGMOG_CODE                     = A.HANGMOG_CODE
                                      AND G.SG_CODE                          IS NOT NULL
                                      AND A.ORDER_DATE BETWEEN G.START_DATE AND G.END_DATE
                                      AND B.IPWON_DATE BETWEEN NVL(INS.Start_Date, TO_DATE('19000101', 'YYYYMMDD')) AND NVL(INS.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
                                 GROUP BY B.PKINP1001
                                        , A.BUNHO                                                    
                                        , C.SUNAME                                                  
                                        , B.IPWON_DATE  
                                        , B.IPWON_TIME                                            
                                        --, A.INPUT_GWA
                                        --, A.INPUT_DOCTOR
                                        , B.GWA
                                        , F.ORG_DOCTOR
                                        , FN_BAS_LOAD_GWA_NAME (B.GWA, A.ORDER_DATE )
                                        , FN_BAS_LOAD_DOCTOR_NAME (B.GWA||F.ORG_DOCTOR, A.ORDER_DATE)
                                        , INS.GUBUN
                                        , A.ORDER_DATE
                                        --, A.ACTING_DATE
                                        , A.FKINP3010
                                        , A.IF_DATA_SEND_DATE
                                        , DECODE(B.TOIWON_DATE, NULL, 'N', 'Y')
                                 ORDER BY A.ORDER_DATE DESC, ACTING_DATE DESC";
                         */
                        #endregion INP ORDER LIST Before Trans : comment
                        //
                        #region 2013.09.16 LKH S : NEW SQL(master)
                        // new sql
//                        QuerySQL = @"-- INP ORDER LIST Before Trans --
//SELECT
//     --  AA.HOSP_CODE                                                           AS HOSP_CODE
//       AA.PKINP1001                                                           AS PKINP1001
//     , AA.BUNHO                                                               AS BUNHO
//     , F.SUNAME                                                               AS SUNAME
//     , AA.IPWON_DATE                                                          AS IPWON_DATE
//     , AA.IPWON_TIME                                                          AS IPWON_TIME
//     --
//     , AA.GWA                                                                 AS GWA
//     , SUBSTR(AA.DOCTOR, -5, 5)                                               AS DOCTOR
//     , FN_BAS_LOAD_GWA_NAME(AA.GWA, NVL(B.ACTING_DATE, B.ORDER_DATE))         AS GWA_NAME
//     , FN_BAS_LOAD_DOCTOR_NAME(AA.DOCTOR, NVL(B.ACTING_DATE, B.ORDER_DATE))   AS DOCTOR_NAME
//     , AA.HO_DONG1                                                            AS HO_DONG
//     --, FN_BAS_LOAD_GWA_NAME(AA.HO_DONG1, NVL(B.ACTING_DATE, B.ORDER_DATE))    AS HO_DONG1_NAME
//     , AA.HO_CODE1                                                            AS HO_CODE
//     , NVL(AB.GUBUN, '##')                                                    AS GUBUN
//     --, FN_BAS_LOAD_GUBUN_NAME(NVL(AB.GUBUN, '##') , NVL(B.ACTING_DATE, A.ORDER_DATE)) AS GUBUN_NAME
//     --
//     , MAX(B.ORDER_DATE)                                                      AS ORDER_DATE
//-------------------------------------
//     , NVL(ZZ.ACT_RES_DATE, NVL(B.ACTING_DATE, B.ORDER_DATE))                 AS ACTING_DATE
//----------------------------------------
//--     , NVL(B.ACTING_DATE, B.ORDER_DATE)                                       AS ACTING_DATE
//     , ''                                                                     AS PKINP3010   
//     , ''                                                                     AS SEND_DATE
//--     , B.FKINP3010                                                            AS PKINP3010   
//--     , B.IF_DATA_SEND_DATE                                                    AS SEND_DATE
//     , DECODE(AA.TOIWON_DATE, NULL, 'N', 'Y')                                 AS TOIWON_YN
//  FROM 
//     -- INP1001                AA
//       VW_OCS_INP1001_01     AA
//     , INP1002               AB
//     , OUT0101               F 
//     , OCS2003               B
//----------------------------------------
//     , (select a.*
//          from OCS2017 a
//         where a.hosp_code    = :f_hosp_code
//           and a.act_res_date BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                  AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//       )                     ZZ
//-----------------------------------------
//     , OCS0103               BB
//     , BAS0310               BC
// WHERE 1=1
//   -- VW_OCS_INP1001_01 - INP1001
//   AND AA.HOSP_CODE                    = :f_hosp_code
//   AND AA.BUNHO                        LIKE :f_bunho
//   --AND AA.PKINP1001                    LIKE C_FKINP1001
//   --
//   AND AA.JAEWON_FLAG                  = 'Y'
//   --
//   AND B.HOSP_CODE                     = AA.HOSP_CODE
//   AND B.BUNHO                         = AA.BUNHO
//   AND B.FKINP1001                     = AA.PKINP1001 
//   --
//--   AND NVL(B.IF_DATA_SEND_YN, 'N')     = 'N'
//   AND (
//         bb.order_gubun in ('B', 'C') and NVL(ZZ.IF_DATA_SEND_YN, 'N')     = 'N'
//       OR 
//         bb.order_gubun not in ('B', 'C') and NVL(B.IF_DATA_SEND_YN, 'N')     = 'N'
//       )
//   --
//   --AND A.OCS_FLAG                      IN ('1', '2')
///*   AND (   (    B.ACTING_DATE          IS NULL
//            AND (   B.ORDER_DATE       BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                           AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//                 OR B.RESER_DATE       BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                           AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//                 OR B.HOPE_DATE        BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                           AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//                )
//           )
//        OR (    B.ACTING_DATE          BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                           AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//           )
//       )    */
//
//   AND (
//          bb.order_gubun in ('B', 'C')
//          and zz.act_res_date              BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                               AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//       OR  (
//          bb.order_gubun not in ('B', 'C')    
//             and   
//               (    B.ACTING_DATE          IS NULL
//                AND (   B.ORDER_DATE       BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                               AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//                     OR B.RESER_DATE       BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                               AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//                     OR B.HOPE_DATE        BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                               AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//                    )
//                OR (    B.ACTING_DATE          BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
//                                                   AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
//                   )
//               )
//            )
//         )
//   -- ???
//   AND B.NALSU                         >= 0
//   --AND NVL(B.DISPLAY_YN , 'Y')         = 'Y'
//   AND NVL(B.DC_YN,'N')                = 'N'
//   AND NVL(B.MUHYO,'N')                = 'N'
//-------------------------------
//   and zz.hosp_code (+)= B.hosp_code
//   and zz.fkocs2003 (+)= B.pkocs2003
//-------------------------------
//   -- HANGMOG_CODE
//   AND BB.HOSP_CODE                    = B.HOSP_CODE
//   AND BB.HANGMOG_CODE                 = B.HANGMOG_CODE
//   AND BB.START_DATE                   = (SELECT MAX(Z.START_DATE)
//                                            FROM OCS0103 Z
//                                           WHERE Z.HOSP_CODE       = BB.HOSP_CODE
//                                             AND Z.HANGMOG_CODE    = BB.HANGMOG_CODE
//                                             AND Z.START_DATE      <= NVL(B.ACTING_DATE, B.ORDER_DATE)
//                                             AND (   Z.END_DATE    IS NULL
//                                                  OR Z.END_DATE    >= NVL(B.ACTING_DATE, B.ORDER_DATE)
//                                                 )
//                                         )
//   AND (   BB.END_DATE                 IS NULL
//        OR BB.END_DATE                 >= NVL(B.ACTING_DATE, B.ORDER_DATE)
//       )
//   -- JUMSU
//   AND BC.HOSP_CODE                    = B.HOSP_CODE
//   AND BC.SG_CODE                      = B.SG_CODE
//   AND BC.SG_YMD                       = (SELECT MAX(Z.SG_YMD)
//                                           FROM BAS0310 Z
//                                          WHERE Z.HOSP_CODE       = BC.HOSP_CODE
//                                            AND Z.SG_CODE         = BC.SG_CODE
//                                            AND Z.SG_YMD          <= NVL(B.ACTING_DATE, B.ORDER_DATE)
//                                            AND (   Z.BULYONG_YMD IS NULL
//                                                 OR Z.BULYONG_YMD >= NVL(B.ACTING_DATE, B.ORDER_DATE)
//                                                )
//                                         )
//   AND (   BC.BULYONG_YMD             IS NULL
//        OR BC.BULYONG_YMD             >= NVL(B.ACTING_DATE, B.ORDER_DATE)
//       )
//   -- INP1002
//   AND AB.HOSP_CODE                     = AA.HOSP_CODE
//   AND AB.BUNHO                         = AA.BUNHO
//   AND AB.FKINP1001                     = AA.PKINP1001 
//   AND AB.GUBUN_IPWON_DATE              <= NVL(B.ACTING_DATE, B.ORDER_DATE)
//   AND (   AB.GUBUN_TOIWON_DATE         IS NULL
//        OR AB.GUBUN_TOIWON_DATE         >= NVL(B.ACTING_DATE, B.ORDER_DATE)
//       )
//   --
//   AND AB.PKINP1002                    = ( SELECT MAX(Z.PKINP1002)
//                                             FROM INP1002                  Z 
//                                            WHERE Z.HOSP_CODE              = AB.HOSP_CODE
//                                              AND Z.FKINP1001              = AB.FKINP1001
//                                              AND Z.GUBUN_IPWON_DATE       = AB.GUBUN_IPWON_DATE
//                                              AND (   Z.GUBUN_TOIWON_DATE  IS NULL
//                                                   OR Z.GUBUN_TOIWON_DATE  >= NVL(B.ACTING_DATE, B.ORDER_DATE)
//                                                  )
//                                         )  
//   -- HWANJA NAME
//   AND F.HOSP_CODE                    = AA.HOSP_CODE
//   AND F.BUNHO                        = AA.BUNHO
// GROUP BY
//     --  AA.HOSP_CODE                                                           
//       AA.PKINP1001                                                           
//     , AA.BUNHO                                                               
//     , F.SUNAME                                                               
//     , AA.IPWON_DATE                                                          
//     , AA.IPWON_TIME                                                          
//     --
//     , AA.GWA                                                                 
//     , SUBSTR(AA.DOCTOR, -5, 5)                                               
//     , FN_BAS_LOAD_GWA_NAME(AA.GWA, NVL(B.ACTING_DATE, B.ORDER_DATE))         
//     , FN_BAS_LOAD_DOCTOR_NAME(AA.DOCTOR, NVL(B.ACTING_DATE, B.ORDER_DATE))   
//     , AA.HO_DONG1                                                            
//     --, FN_BAS_LOAD_GWA_NAME(AA.HO_DONG1, NVL(B.ACTING_DATE, B.ORDER_DATE))    
//     , AA.HO_CODE1                                                            
//     , NVL(AB.GUBUN, '##')                                                    
//     --, FN_BAS_LOAD_GUBUN_NAME(NVL(AB.GUBUN, '##') , NVL(B.ACTING_DATE, A.ORDER_DATE)) 
//     --
//     --, MAX(B.ORDER_DATE)
//------------------------------------------------------------
//     , NVL(ZZ.ACT_RES_DATE, NVL(B.ACTING_DATE, B.ORDER_DATE))
//------------------------------------------------------------
//--     , NVL(B.ACTING_DATE, B.ORDER_DATE)                                       
//--     , B.FKINP3010                                                            
//--     , B.IF_DATA_SEND_DATE                                                    
//     , DECODE(AA.TOIWON_DATE, NULL, 'N', 'Y')                                 
// ORDER BY 
//     --  AA.HOSP_CODE                                                      
//     --  B.ORDER_DATE                         DESC
//--------------------------------------------------------------
//NVL(ZZ.ACT_RES_DATE, NVL(B.ACTING_DATE, B.ORDER_DATE))
//--------------------------------------------------------------
//--       NVL(B.ACTING_DATE, B.ORDER_DATE)     DESC
//";
                        #endregion 2013.09.16 LKH S : NEW SQL(master)

                        #region 2013.11.26 update by park.w.j(master)
                        // new sql
                        QuerySQL = @"-- INP ORDER LIST Before Trans --
                                    SELECT AA.PKINP1001                                                           AS PKINP1001
                                         , AA.BUNHO                                                               AS BUNHO
                                         , F.SUNAME                                                               AS SUNAME
                                         , AA.IPWON_DATE                                                          AS IPWON_DATE
                                         , AA.IPWON_TIME                                                          AS IPWON_TIME
                                         --
                                         , AA.GWA                                                                 AS GWA
                                         , SUBSTR(AA.DOCTOR, -5, 5)                                               AS DOCTOR
                                         , FN_BAS_LOAD_GWA_NAME(AA.GWA, NVL(B.ACTING_DATE, B.ORDER_DATE))         AS GWA_NAME
                                         , FN_BAS_LOAD_DOCTOR_NAME(AA.DOCTOR, NVL(B.ACTING_DATE, B.ORDER_DATE))   AS DOCTOR_NAME
                                         , AA.HO_DONG1                                                            AS HO_DONG
                                         , AA.HO_CODE1                                                            AS HO_CODE
                                         , NVL(AB.GUBUN, '##')                                                    AS GUBUN
                                         --
                                         , MAX(B.ORDER_DATE)                                                      AS ORDER_DATE
                                         -- 2013.11.26 update by park.w.j
                                         -- 内服、注射（退院薬除外）区分処理
                                         -- 投薬記録「OCS2017」追加
                                         , NVL(ZZ.ACT_RES_DATE, NVL(B.ACTING_DATE, NVL(B.HOPE_DATE, B.ORDER_DATE)))  AS ACTING_DATE
                                         , ''                                                                     AS PKINP3010   
                                         , ''                                                                     AS SEND_DATE
                                         , DECODE(AA.TOIWON_DATE, NULL, 'N', 'Y')                                 AS TOIWON_YN
                                      FROM VW_OCS_INP1001_01     AA
                                         , INP1002               AB
                                         , OUT0101               F 
                                         , OCS2003               B
                                         -- 2013.11.26 update by park.w.j
                                         -- 内服、注射（退院薬除外）区分処理
                                         -- 投薬記録「OCS2017」追加
                                         , (SELECT A.*
                                              FROM OCS2017 A
                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                               AND A.ACT_RES_DATE BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                                      AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                               AND EXISTS (SELECT 'Y'
                                                      FROM OCS2003 X
                                                     WHERE X.HOSP_CODE   = :f_hosp_code
                                                       AND X.PKOCS2003   = A.FKOCS2003
                                                       AND X.ORDER_GUBUN NOT LIKE '%D')  -- 外用薬を除外
                                           )                     ZZ
                                         , OCS0103               BB
                                         , BAS0310               BC
                                     WHERE 1=1
                                       AND AA.HOSP_CODE                    = :f_hosp_code
                                       AND AA.BUNHO                        LIKE :f_bunho
                                       --
                                       AND AA.JAEWON_FLAG                  = 'Y'
                                       --
                                       AND B.HOSP_CODE                     = AA.HOSP_CODE
                                       AND B.BUNHO                         = AA.BUNHO
                                       AND B.FKINP1001                     = AA.PKINP1001 
                                       -- 2013.11.26 update by park.w.j
                                       -- 内服、注射（退院薬除外）区分処理
                                       AND (
                                             BB.ORDER_GUBUN IN ('B', 'C') 
                                             AND NVL(B.TOIWON_DRG_YN,'N') = 'N'
                                             AND NVL(ZZ.IF_DATA_SEND_YN, 'N')     = 'N'
                                           OR 
                                             (BB.ORDER_GUBUN IN ('B', 'C', 'D')
                                             AND NVL(B.TOIWON_DRG_YN,'N') <> 'N'
                                             AND NVL(B.IF_DATA_SEND_YN, 'N')     = 'N') OR
                                             
                                             (BB.ORDER_GUBUN NOT IN ('B', 'C')
                                             AND NVL(B.TOIWON_DRG_YN,'N') = 'N'
                                             AND NVL(B.IF_DATA_SEND_YN, 'N')     = 'N')
                                           )
                                       --
                                       AND (
                                                 BB.ORDER_GUBUN IN ('B', 'C')
                                                 AND NVL(B.TOIWON_DRG_YN,'N') = 'N'
                                                 AND ZZ.ACT_RES_DATE          BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                                                  AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                           OR  (
                                                 (BB.ORDER_GUBUN IN ('B', 'C', 'D')
                                                 AND NVL(B.TOIWON_DRG_YN,'N') <> 'N'
                                                 AND   
                                                   (    B.ACTING_DATE          IS NULL
                                                    AND (    NVL(B.HOPE_DATE, B.ORDER_DATE)       BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                                                                      AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                                         --OR B.RESER_DATE       BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                         --                          AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                                         --OR B.HOPE_DATE        BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                         --                          AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                                        )
                                                    OR (    B.ACTING_DATE      BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                                                   AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                                       )
                                                   )
                                                 ) OR
                                                 
                                                 (BB.ORDER_GUBUN NOT IN ('B', 'C')
                                                 AND NVL(B.TOIWON_DRG_YN,'N') = 'N'
                                                 AND   
                                                   (    B.ACTING_DATE          IS NULL
                                                    AND (    NVL(B.HOPE_DATE, B.ORDER_DATE)       BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                                                                      AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                                         --OR B.RESER_DATE       BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                         --                          AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                                         --OR B.HOPE_DATE        BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                         --                          AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                                        )
                                                    OR (    B.ACTING_DATE      BETWEEN TO_DATE(:f_order_from_date , 'YYYY/MM/DD')
                                                                                   AND TO_DATE(:f_order_to_date   , 'YYYY/MM/DD')
                                                       )
                                                   ))
                                                )
                                             )
                                       -- 
                                       AND B.NALSU                         >= 0
                                       --AND NVL(B.DISPLAY_YN , 'Y')         = 'Y'
                                       AND NVL(B.DC_YN,'N')                = 'N'
                                       AND NVL(B.MUHYO,'N')                = 'N'
                                       -- 2013.11.26 update by park.w.j
                                       -- 内服、注射（退院薬除外）区分処理
                                       -- 投薬記録「OCS2017」追加
                                       AND ZZ.HOSP_CODE                    (+)= B.HOSP_CODE
                                       AND ZZ.FKOCS2003                    (+)= B.PKOCS2003
                                       -- HANGMOG_CODE
                                       AND BB.HOSP_CODE                    = B.HOSP_CODE
                                       AND BB.HANGMOG_CODE                 = B.HANGMOG_CODE
                                       AND BB.START_DATE                   = (SELECT MAX(Z.START_DATE)
                                                                                FROM OCS0103 Z
                                                                               WHERE Z.HOSP_CODE       = BB.HOSP_CODE
                                                                                 AND Z.HANGMOG_CODE    = BB.HANGMOG_CODE
                                                                                 AND Z.START_DATE      <= NVL(B.ACTING_DATE, B.ORDER_DATE)
                                                                                 AND (   Z.END_DATE    IS NULL
                                                                                      OR Z.END_DATE    >= NVL(B.ACTING_DATE, B.ORDER_DATE)
                                                                                     )
                                                                             )
                                       AND (   BB.END_DATE                 IS NULL
                                            OR BB.END_DATE                 >= NVL(B.ACTING_DATE, B.ORDER_DATE)
                                           )
                                       -- JUMSU
                                       AND BC.HOSP_CODE                    = B.HOSP_CODE
                                       AND BC.SG_CODE                      = B.SG_CODE
                                       AND BC.SG_YMD                       = (SELECT MAX(Z.SG_YMD)
                                                                               FROM BAS0310 Z
                                                                              WHERE Z.HOSP_CODE       = BC.HOSP_CODE
                                                                                AND Z.SG_CODE         = BC.SG_CODE
                                                                                AND Z.SG_YMD          <= NVL(B.ACTING_DATE, B.ORDER_DATE)
                                                                                AND (   Z.BULYONG_YMD IS NULL
                                                                                     OR Z.BULYONG_YMD >= NVL(B.ACTING_DATE, B.ORDER_DATE)
                                                                                    )
                                                                             )
                                       AND (   BC.BULYONG_YMD             IS NULL
                                            OR BC.BULYONG_YMD             >= NVL(B.ACTING_DATE, B.ORDER_DATE)
                                           )
                                       -- INP1002
                                       AND AB.HOSP_CODE                     = AA.HOSP_CODE
                                       AND AB.BUNHO                         = AA.BUNHO
                                       AND AB.FKINP1001                     = AA.PKINP1001 
                                       AND AB.GUBUN_IPWON_DATE              <= NVL(B.ACTING_DATE, B.ORDER_DATE)
                                       AND (   AB.GUBUN_TOIWON_DATE         IS NULL
                                            OR AB.GUBUN_TOIWON_DATE         >= NVL(B.ACTING_DATE, B.ORDER_DATE)
                                           )
                                       --
                                       AND AB.PKINP1002                    = ( SELECT MAX(Z.PKINP1002)
                                                                                 FROM INP1002                  Z 
                                                                                WHERE Z.HOSP_CODE              = AB.HOSP_CODE
                                                                                  AND Z.FKINP1001              = AB.FKINP1001
                                                                                  AND Z.GUBUN_IPWON_DATE       = AB.GUBUN_IPWON_DATE
                                                                                  AND (   Z.GUBUN_TOIWON_DATE  IS NULL
                                                                                       OR Z.GUBUN_TOIWON_DATE  >= NVL(B.ACTING_DATE, B.ORDER_DATE)
                                                                                      )
                                                                             )  
                                       -- HWANJA NAME
                                       AND F.HOSP_CODE                    = AA.HOSP_CODE
                                       AND F.BUNHO                        = AA.BUNHO
                                     GROUP BY
                                           AA.PKINP1001                                                           
                                         , AA.BUNHO                                                               
                                         , F.SUNAME                                                               
                                         , AA.IPWON_DATE                                                          
                                         , AA.IPWON_TIME                                                          
                                         --
                                         , AA.GWA                                                                 
                                         , SUBSTR(AA.DOCTOR, -5, 5)                                               
                                         , FN_BAS_LOAD_GWA_NAME(AA.GWA, NVL(B.ACTING_DATE, B.ORDER_DATE))         
                                         , FN_BAS_LOAD_DOCTOR_NAME(AA.DOCTOR, NVL(B.ACTING_DATE, B.ORDER_DATE))   
                                         , AA.HO_DONG1
                                         , AA.HO_CODE1
                                         , NVL(AB.GUBUN, '##')
                                         -- 2013.11.26 update by park.w.j
                                         , NVL(ZZ.ACT_RES_DATE, NVL(B.ACTING_DATE, NVL(B.HOPE_DATE, B.ORDER_DATE)))
                                         , DECODE(AA.TOIWON_DATE, NULL, 'N', 'Y')                                 
                                     ORDER BY 
                                        -- 2013.11.26 update by park.w.j
                                        NVL(ZZ.ACT_RES_DATE, NVL(B.ACTING_DATE, NVL(B.HOPE_DATE, B.ORDER_DATE)))
                                    ";
                        #endregion 2013.11.26 update by park.w.j(master)

                    }
                    else
                    {
                        #region INP ORDER LIST After Trans
                        QuerySQL = @"-- INP ORDER LIST After Trans --
                                       SELECT A.FKINP1001                                               PKINP1001
                                            , A.BUNHO                                                   BUNHO 
                                            , C.SUNAME                                                  SUNAME
                                            , B.IPWON_DATE                                              IPWON_DATE
                                            , B.IPWON_TIME                                              IPWON_TIME
                                            , A.GWA                                                     GWA
                                            , A.DOCTOR                                                  DOCTOR
                                            , FN_BAS_LOAD_GWA_NAME (A.GWA, A.ACTING_DATE)               GWA_NAME 
                                            , FN_BAS_LOAD_DOCTOR_NAME (A.GWA || A.DOCTOR, A.ACTING_DATE) DOCTOR_NAME
                                            , FN_BAS_LOAD_GWA_NAME(D.TO_HO_DONG1, TRUNC(A.SYS_DATE))    HO_DONG
                                            , D.TO_HO_CODE1                                             HO_CODE
                                            , A.GUBUN                                                   GUBUN
                                            -- Update by park.w.j 2013/12/09
                                            -- If not OCS2017(ORDER_DATE), Get OCS2003(ORDER_DATE)
                                            , NVL(
                                                  (SELECT MAX(X.ORDER_DATE)
                                                     FROM OCS2017 X
                                                    WHERE X.HOSP_CODE = A.HOSP_CODE
                                                      AND X.FKINP3010 = A.PKINP3010)  
                                                                                     , (SELECT MAX(Y.ORDER_DATE)
                                                                                          FROM OCS2003 Y
                                                                                         WHERE Y.HOSP_CODE = A.HOSP_CODE
                                                                                           AND Y.FKINP3010 = A.PKINP3010)
                                                 )                                                      ORDER_DATE
                                            , A.ACTING_DATE                                             ACTING_DATE
                                            , A.PKINP3010                                               PKINP3010
                                            , TRUNC(A.SYS_DATE)                                         SEND_DATE
                                            , 'N'                                                       TOIWON_YN
                                       FROM INP3010 A -- 入院会計オーダマスター情報
                                          , INP1001 B
                                          , OUT0101 C
                                          , VW_OCS_INP2004 D
                                      WHERE A.HOSP_CODE      = :f_hosp_code
                                        AND A.BUNHO          = :f_bunho
                                        AND A.ACTING_DATE BETWEEN :f_order_from_date AND :f_order_to_date
                                        AND B.HOSP_CODE   (+)= D.HOSP_CODE
                                        AND B.BUNHO       (+)= D.BUNHO                                         
                                        AND B.PKINP1001   (+)= D.PKINP1001  
                                        AND C.HOSP_CODE      = A.HOSP_CODE
                                        AND C.BUNHO          = A.BUNHO
                                        AND EXISTS (SELECT 'Y' 
                                                      FROM OCS2003 Z 
                                                     WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                       AND Z.BUNHO     = A.BUNHO
                                                       AND Z.IF_DATA_SEND_YN = 'Y'
                                                    UNION
                                                    SELECT 'Y' 
                                                      FROM OCS2017 Q
                                                         , OCS2003 Z 
                                                     WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                       AND Z.BUNHO     = A.BUNHO
                                                       --AND Z.FKINP3010 = A.PKINP3010
                                                       AND Q.HOSP_CODE = Z.HOSP_CODE
                                                       AND Q.FKOCS2003 = Z.PKOCS2003
                                                       AND NVL(Q.IF_DATA_SEND_YN, 'N') = 'Y')
                                        AND D.HOSP_CODE      = A.HOSP_CODE
                                        AND D.BUNHO          = A.BUNHO
                                        AND D.JAEWON_DATE    = TRUNC(SYSDATE)
                                    ORDER BY A.ACTING_DATE DESC";
                        #endregion INP ORDER LIST After Trans
                    }

                    break;
                case "1": //식사
                    #region INP SIKSA LIST Before Trans
                    QuerySQL = @"-- INP SIKSA LIST Before Trans --
                                     SELECT B.PKINP1001                                                 PKINP1001
                                          , A.BUNHO                                                     BUNHO 
                                          , C.SUNAME                                                    SUNAME
                                          , B.IPWON_DATE                                                IPWON_DATE
                                          , B.IPWON_TIME                                                IPWON_TIME
                                          , B.GWA                                                       GWA
                                          , F.ORG_DOCTOR                                                DOCTOR
                                          , FN_BAS_LOAD_GWA_NAME (B.GWA, A.ORDER_DATE )                 GWA_NAME 
                                          , FN_BAS_LOAD_DOCTOR_NAME (B.GWA||F.ORG_DOCTOR, A.ORDER_DATE) DOCTOR_NAME
                                          , MAX(FN_BAS_LOAD_GWA_NAME(D.TO_HO_DONG1, A.ORDER_DATE))      HO_DONG
                                          , MAX(D.TO_HO_CODE1)                                          HO_CODE
                                          , MAX(TO_DATE(FN_NUT_GET_IFS_PROC_DATE(A.HOSP_CODE, A.FKINP1001, A.BUNHO, :f_yyyymm), 'YYYYMMDD') )  SEND_DATE
                                          , MAX(FN_OCSI_NUT_TRANSFER_CHK(A.BUNHO, A.FKINP1001))         TRANS_YN
                                     FROM OCS2015 A
                                         , INP1001 B -- 入院 Master
                                         , OUT0101 C
                                         , VW_OCS_INP2004 D
                                         , BAS0270 F -- 患者の科/医師VIEW
                                     WHERE A.HOSP_CODE       = :f_hosp_code
                                       AND A.BUNHO           = :f_bunho
                                       AND A.DRT_DATE BETWEEN :f_yyyymmdd_first AND :f_yyyymmdd_last
                                       AND B.HOSP_CODE       = A.HOSP_CODE
                                       AND B.BUNHO           = A.BUNHO
                                       AND B.PKINP1001       = A.FKINP1001
                                       AND C.HOSP_CODE       = A.HOSP_CODE
                                       AND C.BUNHO           = A.BUNHO
                                       AND D.HOSP_CODE       = A.HOSP_CODE
                                       AND D.BUNHO           = A.BUNHO
                                       AND D.JAEWON_DATE     = A.DRT_DATE
                                       AND F.HOSP_CODE       = B.HOSP_CODE
                                       AND F.DOCTOR          = B.DOCTOR
                                  GROUP BY B.PKINP1001                                       
                                         , A.BUNHO                                                     
                                         , C.SUNAME                                                    
                                         , B.IPWON_DATE                                             
                                         , B.IPWON_TIME                                                
                                         , B.GWA                                                       
                                         , F.ORG_DOCTOR                                                
                                         , FN_BAS_LOAD_GWA_NAME (B.GWA, A.ORDER_DATE )                
                                         , FN_BAS_LOAD_DOCTOR_NAME (B.GWA||F.ORG_DOCTOR, A.ORDER_DATE)
                                         , DECODE(B.TOIWON_DATE, NULL, 'N', 'Y')";
                    #endregion INP SIKSA LIST Before Trans
                    break;
                case "2": //외박처리 SQL문
                    #region 외박처리 SQL문
                    QuerySQL = @"SELECT DISTINCT B.PKINP1001                                                    FKINP1001
                                        , A.BUNHO                                                               BUNHO
                                        , C.SUNAME                                                              SUNAME
                                        , B.IPWON_DATE                                                          IPWON_DATE
                                        , B.IPWON_TIME                                                          IPWON_TIME
                                        , B.GWA                                                                 GWA
                                        , F.ORG_DOCTOR                                                          DOCTOR
                                        , FN_BAS_LOAD_GWA_NAME (B.GWA, A.OUT_DATE )                             GWA_NAME         
                                        , FN_BAS_LOAD_DOCTOR_NAME (B.GWA||F.ORG_DOCTOR, A.OUT_DATE)             DOCTOR_NAME
                                        , MAX(FN_BAS_LOAD_GWA_NAME(D.TO_HO_DONG1, A.OUT_DATE))                  HO_DONG
                                        , MAX(D.TO_HO_CODE1)                                                    HO_CODE
                                        , MAX(TO_DATE(FN_NUT_GET_IFS_PROC_DATE(A.HOSP_CODE, A.FKINP1001, A.BUNHO, :f_yyyymm), 'YYYYMMDD') )  SEND_DATE
                                        , MAX(FN_OCSI_GAIHAKU_TRANSFER_CHK(A.BUNHO, A.FKINP1001))               TRANS_YN
                                   FROM NUR1014 A
                                      , INP1001 B
                                      , OUT0101 C
                                      , VW_OCS_INP2004 D
                                      , BAS0270 F
                                  WHERE A.HOSP_CODE      = :f_hosp_code
                                    AND A.BUNHO       LIKE :f_bunho || '%'   
                                    AND A.OUT_DATE BETWEEN :f_yyyymmdd_first AND :f_yyyymmdd_last
                                    AND A.WOICHUL_WOIBAK_GUBUN       = '02'
                                    AND A.IN_TRUE_DATE IS NOT NULL
                                    AND B.HOSP_CODE       = A.HOSP_CODE
                                    AND B.BUNHO           = A.BUNHO
                                    AND B.PKINP1001       = A.FKINP1001
                                    AND C.HOSP_CODE       = A.HOSP_CODE
                                    AND C.BUNHO           = A.BUNHO
                                    AND D.HOSP_CODE       = A.HOSP_CODE
                                    AND D.BUNHO           = A.BUNHO
                                    AND D.JAEWON_DATE     = A.OUT_DATE
                                    AND F.HOSP_CODE       = B.HOSP_CODE
                                    AND F.DOCTOR          = B.DOCTOR
                                  GROUP BY B.PKINP1001                                       
                                         , A.BUNHO                                                     
                                         , C.SUNAME                                                    
                                         , B.IPWON_DATE                                             
                                         , B.IPWON_TIME                                                
                                         , B.GWA                                                       
                                         , F.ORG_DOCTOR                                                
                                         , FN_BAS_LOAD_GWA_NAME (B.GWA, A.OUT_DATE )                
                                         , FN_BAS_LOAD_DOCTOR_NAME (B.GWA||F.ORG_DOCTOR, A.OUT_DATE)
                                         , DECODE(B.TOIWON_DATE, NULL, 'N', 'Y')";
                    #endregion 외박처리 SQL문
                    break;
                case "3":  //전과,전실처리 SQL문
                    #region 전과,전실처리 SQL문
                    QuerySQL = @"SELECT DISTINCT  A.FKINP1001                                  FKINP1001
                                        , A.BUNHO                                              BUNHO
                                        , C.SUNAME                                             SUNAME
                                        , B.IPWON_DATE                                         IPWON_DATE
                                        , B.IPWON_TIME                                         IPWON_TIME
                                        , B.GWA                                                GWA
                                        , B.DOCTOR                                             DOCTOR
                                        , FN_BAS_LOAD_GWA_NAME (B.GWA, B.IPWON_DATE )          GWA_NAME         
                                        , FN_BAS_LOAD_DOCTOR_NAME ( B.DOCTOR, B.IPWON_DATE)    DOCTOR_NAME 
                                        , D.GUBUN
                                        --, FN_BAS_LOAD_GUBUN_NAME(D.GUBUN, TRUNC(SYSDATE))      GUBUN_NAME
                                        , E.GUBUN_NAME                                         GUBUN_NAME 
                                        , NVL(E.GONGBI_YN,'Y')                                 GONGBI_YN
                                        , B.CHOJAE
                                        , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE )           CHOJAE_NAME                                            
                                        , D.PKINP1002                                          
                                        --, NVL(MAX(A.ACTING_DATE), A.ORDER_DATE)                     ACTING_DATE 
                                        , A.START_DATE                                         ACTING_DATE 
                                        , A.START_DATE                                         ORDER_DATE  
                                        , D.GUBUN                                              GUBUN_OLD
                                        , B.CHOJAE                                             CHOJAE_OLD
                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 1)   GONGBI_CODE1
                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 2)   GONGBI_CODE2
                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 3)   GONGBI_CODE3
                                        , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 4)   GONGBI_CODE4
                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 1), A.START_DATE) GONGBI_CODE1_NAME
                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 2), A.START_DATE) GONGBI_CODE2_NAME
                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 3), A.START_DATE) GONGBI_CODE3_NAME
                                        , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 4), A.START_DATE) GONGBI_CODE4_NAME

                                        , ''                                                   PKOUT
                                        --, FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 1)   GONGBI_CODE_OLD1
                                        --, FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 2)   GONGBI_CODE_OLD2
                                        --, FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 3)   GONGBI_CODE_OLD3
                                        --, FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 4)   GONGBI_CODE_OLD4
                                        , A.IF_DATA_SEND_DATE                                  SEND_DATE
                                        , '1'                                                  SANJUNG_GUBUN
                                        --, '1'                                                  SANJUNG_GUBUN_OLD
                                        , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1' )          SANJUNG_GUBUN_NAME   
                                        , DECODE(FN_OUT_LOAD_JUBSU_GUBUN_VALID(A.BUNHO, D.GUBUN, A.START_DATE),'N','1',0)    IF_VALID_YN
                                  FROM INP2004 A
                                     , INP1001 B
                                     , OUT0101 C
                                     , INP1002 D
                                     , BAS0210 E
                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                   AND A.BUNHO  LIKE :f_bunho || '%'   
                                   --AND TO_DATE(:f_acting_date) BETWEEN  A.START_DATE and NVL(A.TONGGYE_DATE,'9998/12/31')
                                   AND NVL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn
                                   AND A.TRANS_CNT != 1 
                                   AND B.HOSP_CODE = A.HOSP_CODE    
                                   AND B.BUNHO     = A.BUNHO
                                   AND B.PKINP1001 = A.FKINP1001
                                   AND C.HOSP_CODE = A.HOSP_CODE
                                   AND C.BUNHO     = A.BUNHO
                                   AND D.HOSP_CODE = A.HOSP_CODE
                                   AND D.BUNHO     = A.BUNHO
                                   AND D.FKINP1001 = A.FKINP1001
                                   AND TO_DATE(:f_acting_date) BETWEEN D.GUBUN_IPWON_DATE AND NVL(D.GUBUN_TOIWON_DATE, '9998/12/31')
                                   AND ( A.FROM_GWA != A.TO_GWA
                                         OR 
                                         A.FROM_DOCTOR != A.TO_DOCTOR
                                         OR
                                         A.FROM_HO_DONG1 != A.TO_HO_DONG1
                                         OR 
                                         A.FROM_HO_CODE1 != A.TO_HO_CODE1
                                       )
                                    AND A.HOSP_CODE   = E.HOSP_CODE
                                    AND E.GUBUN       = D.GUBUN
                                    AND B.IPWON_DATE BETWEEN E.START_DATE
                                                      AND NVL(E.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
                                   ORDER BY B.IPWON_DATE, A.START_DATE DESC ";
                    #endregion 전과,전실처리 SQL문                
                    break;
                default:
                    break;
            }
            return QuerySQL;
        }
        #endregion

        #region [ 그리드에디터리스트 쿼리 개시 ]
        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            string tap = this.tabDataGubun.SelectedTab.Tag.ToString();

            if (tap == null)
            {
                return;
            }

            if (tap == "0") // ORDER
            {
                #region Condition of ORDER MASTER Query
                grd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                grd.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
                grd.SetBindVarValue("f_order_from_date", this.dtpJunsongFromDate.GetDataValue());
                grd.SetBindVarValue("f_order_to_date", this.dtpJunsongToDate.GetDataValue());
                #endregion Condition of ORDER MASTER Query
            }

            if (tap == "1") // 食事
            {
                #region Condition of 食事 MASTER Query
                grd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                grd.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
                grd.SetBindVarValue("f_yyyymm", this.monthBox.GetDataValue());
                grd.SetBindVarValue("f_yyyymmdd_first", this.monthBox.GetDataValue() + "01");
                grd.SetBindVarValue("f_yyyymmdd_last", this.monthBox.GetDataValue() + DateTime.DaysInMonth(int.Parse(this.monthBox.GetDataValue().Substring(0, 4)), int.Parse(this.monthBox.GetDataValue().Substring(4, 2))).ToString());
                #endregion Condition of 食事 MASTER Query
            }

            if (tap == "2") // 外泊
            {
                #region Condition of 外泊 MASTER Query
                grd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                grd.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
                grd.SetBindVarValue("f_yyyymm", this.monthBox.GetDataValue());
                grd.SetBindVarValue("f_yyyymmdd_first", this.monthBox.GetDataValue() + "01");
                grd.SetBindVarValue("f_yyyymmdd_last", this.monthBox.GetDataValue() + DateTime.DaysInMonth(int.Parse(this.monthBox.GetDataValue().Substring(0, 4)), int.Parse(this.monthBox.GetDataValue().Substring(4, 2))).ToString());
                #endregion Condition of 外泊 MASTER Query
            }
        }
        #endregion

        #region [ 그리드에디터리스트 GridCellPainting ]
        private void grdList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (grd.GetItemString(e.RowNumber, "toiwon_yn") == "Y")
            {
                e.ForeColor = Color.Red;
                e.BackColor = Color.Pink;
            }
        }
        #endregion

        #region [ 오더화면그리드 포커스체인지드 이벤트 ]
        private void grdOCS2003_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (e.CurrentRow >= 0)
            {
                DisplaySpecialColHeader(grd, e.CurrentRow);
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
                        aGrd[0, aGrd.CellInfos["suryang"].Col].Value = NetInfo.Language == LangMode.Jr ? "分当り\r\n注入量" : "분당\r\n주입량";
                    }
                    // InputControl(시간분입력) => 시간
                    else if (aGrd.CellInfos.Contains("input_control") && aGrd.GetItemString(aRow, "input_control") == "3")
                    {
                        aGrd[0, aGrd.CellInfos["suryang"].Col].Value = NetInfo.Language == LangMode.Jr ? "時間" : "시간";
                    }
                    else
                    {
                        aGrd[0, aGrd.CellInfos["suryang"].Col].Value = NetInfo.Language == LangMode.Jr ? "数量" : "수량";
                    }
                }

                // 회수 필드 처리
                if (aGrd.CellInfos.Contains("dv"))
                {
                    if (aGrd[0, aGrd.CellInfos["dv"].Col] != null) aGrd[0, aGrd.CellInfos["dv"].Col].Value = NetInfo.Language == LangMode.Jr ? "回数" : "회수";
                    for (int i = 0; i < aGrd.HeaderInfos.Count; i++) // Add Header에도 표시
                    {
                        if (aGrd.HeaderInfos[i].HeaderText == "分割数" || aGrd.HeaderInfos[i].HeaderText == "분할수" ||
                            aGrd.HeaderInfos[i].HeaderText == "回数" || aGrd.HeaderInfos[i].HeaderText == "회수")
                        {
                            aGrd[0, aGrd.HeaderInfos[i].Col].Value = NetInfo.Language == LangMode.Jr ? "回数" : "회수";
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
                        aGrd[0, aGrd.CellInfos["nalsu"].Col].Value = NetInfo.Language == LangMode.Jr ? "注入\r\n 分" : "주입\r\n 분";
                    }
                    // InputControl(시간분입력) => 분
                    else if (aGrd.CellInfos.Contains("input_control") && aGrd.GetItemString(aRow, "input_control") == "3") // 시간분입력
                    {
                        aGrd[0, aGrd.CellInfos["nalsu"].Col].Value = NetInfo.Language == LangMode.Jr ? "分" : "분";
                    }
                    else
                    {
                        aGrd[0, aGrd.CellInfos["nalsu"].Col].Value = NetInfo.Language == LangMode.Jr ? "日\r\n数" : "날\r\n수";
                    }
                }
                if (aGrd.CellInfos.Contains("bogyong_name") && aGrd[0, aGrd.CellInfos["bogyong_name"].Col] != null)
                {
                    if (aGrd.CellInfos.Contains("input_control") && aGrd.GetItemString(aRow, "input_control") == "2") // 주사약
                    {
                        aGrd[0, aGrd.CellInfos["bogyong_name"].Col].Value = NetInfo.Language == LangMode.Jr ? " 速度" : " 속도";
                    }
                    else if (aGrd.CellInfos.Contains("input_control") && aGrd.GetItemString(aRow, "input_control") == "A") // 처치
                    {
                        aGrd[0, aGrd.CellInfos["bogyong_name"].Col].Value = NetInfo.Language == LangMode.Jr ? " 処置\r\n 部位" : " 처치\r\n 부위";
                    }
                    else
                    {
                        aGrd[0, aGrd.CellInfos["bogyong_name"].Col].Value = NetInfo.Language == LangMode.Jr ? "用法" : "용법";
                    }
                }
            }
            catch { }
        }
        #endregion

        #region [외래예약환자컬러설정]
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
        #endregion

        #region [환자상병정보쿼리개시]
        private void grdOutSang_QueryStarting(object sender, CancelEventArgs e)
        {
            //커런트 그리드리스트 취득
            XEditGrid grdList = this.mCurrentListGrid;
            this.grdOutSang.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOutSang.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
            //this.grdOutSang.SetBindVarValue("f_gwa", grdList.GetItemString(grdList.CurrentRowNumber, "gwa"));
            //this.grdOutSang.SetBindVarValue("f_gijun_date", grdList.GetItemString(grdList.CurrentRowNumber, "order_date"));
            this.grdOutSang.SetBindVarValue("f_gijun_date", "");
            this.grdOutSang.SetBindVarValue("f_io_gubun", this.mIOGubun.ToString());
        }
        #endregion

        #region [오더 백 테이블 클리어]
        private void ClearOrderBack()
        {
            this.layOrderInfo.Reset();
            this.layRequisInfo.Reset();
        }
        #endregion

        #region [오더 선택 관련]
        private void ClickCurrentOrder(int aRowNumber)
        {
            //group_inp1001
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

                if (this.mCurrentGrid.GetItemString(aRowNumber, "order_date") == this.mCurrentGrid.GetItemString(i, "order_date")
                    && this.mCurrentGrid.GetItemString(aRowNumber, "order_gubun_bas") == this.mCurrentGrid.GetItemString(i, "order_gubun_bas")
                    && this.mCurrentGrid.GetItemString(aRowNumber, "group_inp1001") == this.mCurrentGrid.GetItemString(i, "group_inp1001"))
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

                }
            }           

            this.checkSelectAll();
        }

        private void checkSelectAll()
        {
            XEditGrid grd = this.mCurrentListGrid;
            Image Images = null;

            //DataRow[] dtRow = this.layOrderInfo.LayoutTable.Select("pkINP1001 =" + grd.GetItemString(grd.CurrentRowNumber, "pkINP1001"));

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
        #endregion

        #region [백테이블에 삽입, 삭제]
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
        #endregion

        #region [백테이블오더 체크]
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
        #endregion

        #region [상병정보출력]
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
        #endregion

        #region [초재진정보/정산구분정보출력]
        private void MakeChojaeCombo()
        {
            string UserSQL = @"SELECT CODE, CODE_NAME
                                 FROM BAS0102
                                WHERE HOSP_CODE = :f_hosp_code
                                  AND CODE_TYPE = :f_code_type ";
            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            layoutCombo.InitializeLayoutTable();
            layoutCombo.QuerySQL = UserSQL;
            layoutCombo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layoutCombo.SetBindVarValue("f_code_type", "CHOJAE");

            //if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
            //{
            //    this.cboChojae_Name.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
            //}

            //layoutCombo.SetBindVarValue("f_code_type", "JINCHAL_SANJUNG_GUBUN");

            //if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
            //{
            //    this.cboSanjung_Name.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
            //}
        }
        #endregion

        #region [오르카오더대조버튼]
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
                    string pkINP1001 = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "pkINP1001");
                    string JunsongDate = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "acting_date");
                    string IOGubun = this.mIOGubun;
                    string gwa = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "gwa");
                    string doctor = this.mCurrentListGrid.GetItemString(this.mCurrentListGrid.CurrentRowNumber, "doctor");
                    CommonItemCollection openParams = new CommonItemCollection();

                    openParams.Add("bunho", bunho);
                    openParams.Add("pkINP1001", pkINP1001);
                    openParams.Add("JunsongDate", JunsongDate);
                    //openParams.Add("gwa_name", this.dbxGwa_name.GetDataValue());
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
                    string mMsg = NetInfo.Language == LangMode.Ko ? "참조데이터가없습니다." :"参照データがありません。";
                    string mCap = NetInfo.Language == LangMode.Ko ? "확인" : "確認";
                    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }
        }
        #endregion

        #region [ 외래환자 리스트 이미지 셋팅 ]
        private void SetOutListImage()
        {
            for (int i = 0; i < this.mCurrentListGrid.RowCount; i++)
            {
                this.mCurrentListGrid[i, "select"].Image = this.ImageList.Images[1];
                this.mCurrentListGrid.SetItemValue(i, "select", "N");

                //if (this.mIOGubun =="O")
                //{
                //    // 예약환자
                //    if (this.mCurrentListGrid.GetItemString(i, "reser_yn") == "Y")
                //    {
                //        this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[7];
                //        this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].ToolTipText = this.mCurrentListGrid[i + this.grdOutList.HeaderHeights.Count, 0].ToolTipText + "/予約患者";
                //    }
                //    switch (this.mCurrentListGrid.GetItemString(i, "jubsu_gubun"))
                //    {
                //        case "07":    // 약만의 환자
                //            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[8];
                //            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].ToolTipText = this.mCurrentListGrid[i + this.grdOutList.HeaderHeights.Count, 0].ToolTipText + "/投薬受付";
                //            break;
                //        case "14":    // 긴급환자
                //            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[9];
                //            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].ToolTipText = this.mCurrentListGrid[i + this.grdOutList.HeaderHeights.Count, 0].ToolTipText + "/緊急";
                //            break;
                //        case "11":    // 건강검진
                //            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[14];
                //            this.mCurrentListGrid[i + this.mCurrentListGrid.HeaderHeights.Count, 0].ToolTipText = this.mCurrentListGrid[i + this.grdOutList.HeaderHeights.Count, 0].ToolTipText + "/`健康診断";
                //            break;

                //    }
                //}
            }
        }
        #endregion

        #region [ 에디터그리드리스트마우스클릭이벤트 ]
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

                    string tab = this.tabDataGubun.SelectedTab.Tag.ToString();

                    for (int i = 0; i < this.mCurrentGrid.RowCount; i++)
                    {
                        if (this.mCurrentGrid.GetItemString(i, "select") != "X")
                        {
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
                        }
                    }
                }

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
            }
        }
        #endregion

        #region [ 에디터그리드마우스클릭이벤트 ]
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
        #endregion

        #region [오더 데이터 재전송 버튼처리]
        private void btnReSend_Click(object sender, EventArgs e)
        {
            try
            {
                //MakeIFS1004("ORDER", this.tab

                if (layOrderInfo.RowCount <= 0)
                {
                    XMessageBox.Show("選択されたオーダがありません。", "再転送失敗", MessageBoxIcon.Warning);
                    return;
                }


                string pkINP3010 = this.layOrderInfo.GetItemString(mCurrentListGrid.CurrentRowNumber, "pkINP3010");
                int retVal = this.MakeIFS3014("ORDER", mIOGubun, pkINP3010, "R");
                
                if (retVal > 0)
                {
                    if (OrderTrans(pkINP3010, "R"))
                    {
                        XMessageBox.Show("オーダを再転送しました.", "再転送成功", MessageBoxIcon.Information);
                        btnList.PerformClick(FunctionType.Query);
                    }
                }
                else
                {

                }

                //if (this.ProcessOrderSend())
                //{
                //    this.mCap = NetInfo.Language == LangMode.Ko ? "재전송 완료"
                //                                                : "再転送完了";
                //    this.mMsg = NetInfo.Language == LangMode.Ko ? "정상적으로 재전송 되었습니다."
                //                                                : "正常的に再転送されました。";
                //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    this.mCap = NetInfo.Language == LangMode.Ko ? "재전송 실패"
                //                                                : "再転送失敗";
                //    this.mMsg = NetInfo.Language == LangMode.Ko ? "오더 재전송에 문제가 발생하였습니다."
                //                                                : "オーダ再転送に問題が発生しました。";
                //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, "再転送失敗", MessageBoxIcon.Exclamation);
                btnList.PerformClick(FunctionType.Query);
            }
        }
        #endregion

        #region [오더 데이터 전송처리함수]
        private bool ProcessOrderSend()
        {
            ArrayList listDateArry = new ArrayList();
            bool value = false;
            //string mmsg = "";
            string mcag = "";

            mcag = NetInfo.Language == LangMode.Ko ? "오더전송처리" : "オーダ転送処理";

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

                this.mMsg = NetInfo.Language == LangMode.Ko ? "전송일자 [ " + date + " ] 로" + mcag + "를 하시겠습니까?"
                                                            : "転送日付 [ " + date + " ] で" + mcag + "を実行しますか?";

                DialogResult result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return false;
                }

                //string tap = this.tabDataGubun.SelectedTab.Tag.ToString();

                if (this.mSend_YN == "N")
                {
                    if ((this.layRequisInfo.RowCount > 0) && (this.ProcessRequisInfo() == false))
                    //if (this.ProcessRequisInfo() == false)
                    {
                        throw new Exception();
                    }
                }

                //switch (tap)
                //{
                //    case "0"://오더데이터처리
                        value = ProcessOrderTrans(ref listDateArry);
                //        break;
                //    case "1"://식사데이터처리
                //        value = ProcessSiksaTrans(ref listDateArry);
                //        break;
                //    case "2"://외박데이터처리
                //        value = ProcessWoichulTrans(ref listDateArry);
                //        break;
                //    case "3"://전과전실데이터처리
                //        value = ProcessJungwaTrans(ref listDateArry);
                //        break;
                //}
                if (value == false)
                {
                    throw new Exception();
                }
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
            return true;
        }
        #endregion  

        #region [오더 데이터 취소처리함수]
        private bool ProcessOrderCancel()
        {
            ArrayList listDateArry = new ArrayList();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            //int sang_cnt = 0;
            int order_cnt = 0;

            string mcag = NetInfo.Language == LangMode.Ko ? "오더취소처리" : "オーダ取消処理";
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
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "선택된 데이터가 없습니다." : "選択されたデータがありません。";
                    this.mCap = mcag;
                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                this.mMsg = NetInfo.Language == LangMode.Ko ? mcag + "를 하시겠습니까?" : mcag + "を実行しますか?";

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
                        try
                        {
                            Service.BeginTransaction();

                            //string pkout1003 = layRequisInfo.GetItemString(0, "pkout");
                            string pkinp3010 = mCurrentGrid.GetItemString(0, "pkinp3010");
                            //sang_cnt = MakeIFS1004("SANG", mIOGubun, pkout1003, "N");

                            order_cnt = this.MakeIFS3014("ORDER", mIOGubun, pkinp3010, "N");


                            Service.CommitTransaction();


                            //if (sang_cnt > 0)
                            //{
                            //    SangTrans(pkout1003);
                            //}

                            if (order_cnt > 0)
                            {
                                //오더 취소 전문
                                this.OrderTrans(pkinp3010, "N"); 
                            }
                        }
                        catch (Exception ex)
                        {
                            Service.RollbackTransaction();
							//https://sofiamedix.atlassian.net/browse/MED-10610
                            //XMessageBox.Show(ex.Message, "オーダ取消転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        XMessageBox.Show("オーダ取消の申請を成功しました。", "オーダ取消", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
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
                            inputList.Add(this.layRequisInfo.GetItemValue(0, "pkINP1001"));     //I_FKINP1001 
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

            }
            catch(Exception ex)
            {
                Service.RollbackTransaction();
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, "オーダ取消失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        #endregion

        #region [접수 데이터 보험/초재진갱신처리]
        private bool ProcessRequisInfo()
        {
            string UserSQL = "";
            string UpDataSQL = "";

            UserSQL = @" UPDATE INP1001
                            SET CHOJAE     = :f_chojae
                                --SANJUNG_GUBUN = :f_sanjung_gubun   
                          WHERE HOSP_CODE  = :f_hosp_code
                            AND PKINP1001  = :f_pkINP1001";

            UpDataSQL = @" UPDATE INP1002
                             SET GUBUN      = :f_gubun
                           WHERE HOSP_CODE  = :f_hosp_code
                             AND FKINP1001  = :f_pkINP1001 
                             AND PKINP1002  = :f_pkinp1002";

            BindVarCollection item = new BindVarCollection();
            //접수데이터갱신
            for (int i = 0; i < this.layRequisInfo.RowCount; i++)
            {
                item.Clear();
                item.Add("f_hosp_code", EnvironInfo.HospCode);
                item.Add("f_pkINP1001", this.layRequisInfo.GetItemString(i, "pkINP1001"));
                item.Add("f_gubun", this.layRequisInfo.GetItemString(i, "gubun"));
                item.Add("f_chojae", this.layRequisInfo.GetItemString(i, "chojae"));
                item.Add("f_sanjung_gubun", this.layRequisInfo.GetItemString(i, "sanjung_gubun"));
                item.Add("f_pkinp1002", this.layRequisInfo.GetItemString(i, "pkinp1002"));

                if (ExecuteNonQuery(UserSQL, item) == false)
                {
                    return false;
                }
                ////입원시보험갱신
                //if (this.mIOGubun == "I")
                //{
                    if (ExecuteNonQuery(UpDataSQL, item) == false)
                    {
                        return false;
                    }
                //}
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
        #endregion

        #region [쿼리처리함수]
        private bool ExecuteNonQuery(string cmdText, BindVarCollection bindVals)
        {
            if (Service.ExecuteNonQuery(cmdText, bindVals) == false)
            {
                this.mMsg = Service.ErrFullMsg.ToString();
                return false;
            }
            return true;
        }
        #endregion

        #region [공비처리함수]
        private bool SetProcessGongbi(int cnt)
        {
            string QuerySQL = "";
            string DeleteSQL = "";
            string CheckSQL = "";
            object retVal = null;

            BindVarCollection item = new BindVarCollection();

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

            item.Clear();
            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_pkINP1001", this.layRequisInfo.GetItemString(cnt, "pkINP1001"));
            item.Add("f_pkinp1002", this.layRequisInfo.GetItemString(cnt, "pkinp1002"));

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
                    item.Add("f_pkINP1001", this.layRequisInfo.GetItemString(cnt, "pkINP1001"));
                    item.Add("f_bunho", this.layRequisInfo.GetItemString(cnt, "bunho"));
                    item.Add("f_gongbi_code", gongbi_code);
                    item.Add("f_priority", j.ToString());
                    item.Add("f_pkinp1002", this.layRequisInfo.GetItemString(cnt, "pkinp1002"));

                    if (ExecuteNonQuery(QuerySQL, item) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region [OUT1003_TEMP 등록]
        private bool SetProcessOut1003()
        {
            BindVarCollection item = new BindVarCollection();
            
            string QuerySQL = @" INSERT INTO OUT1003_TEMP
                                        ( FKOUT1001,    GWA,        DOCTOR  )
                                 VALUES ( :f_pkINP1001,    :f_gwa,     :f_doctor ) ";

            for (int i = 0; i < this.layRequisInfo.RowCount; i++)
            {
                item.Clear();
                item.Add("f_pkINP1001", this.layRequisInfo.GetItemString(i, "pkINP1001"));
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
        #endregion

        #region [전과전실 데이터 처리함수]
        
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
                    inputList.Add(this.layOrderInfo.GetItemString(i, "pkINP1001"));        //FKIN1001
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
                inputList.Add(this.layRequisInfo.GetItemValue(0, "pkINP1001"));        //FKIN1001
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
        #endregion  

        #region [식사 데이터 처리함수]
        private bool ProcessSiksaTrans()
        {
            BindVarCollection item = new BindVarCollection();
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            inputList.Clear();

            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
            inputList.Add("I_MASTER_FK", this.grdSiksaList.GetItemString(this.grdSiksaList.CurrentRowNumber, "pkinp1001"));
            inputList.Add("I_BUNHO", this.fbxBunho.GetDataValue());
            inputList.Add("I_YYYYMM", this.monthBox.GetDataValue());

            // 식사프로시저처리함수
            bool value = Service.ExecuteProcedure("PR_IFS_INP_MONTHLY_NUT", inputList, outputList);

            if (value == false || TypeCheck.IsNull(outputList["O_CNT"]) || outputList["O_CNT"].ToString().Equals("-1"))
            {
                throw new Exception("転送マスタ（IFS3031,IFS3041）作成に問題が発生しました。");
            }
            else if (outputList["O_FK"].ToString().Equals("-1"))
            {
                throw new Exception("[IFS3031]のKEY生成に問題が発生しました。");
            }
            else
            {
                // IFS3031 PK
                if (this.NutTrans(outputList["O_FK"].ToString()))
                {
                    XMessageBox.Show("食事電文の転送申請を成功しました。", "電文要請成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else throw new Exception("食事電文を転送する途中問題が発生しました。");
            }
        }
        #endregion

        #region [식사 데이터 전송함수]
        private bool NutTrans(string pkIFS3031)
        {
            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            // 欠食電文
            msgText = "00242" + pkIFS3031;
            int kret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            if (kret == -1)
            {
                throw new Exception("欠食電文を転送する途中問題が発生しました。電文：" + msgText);
            }

            // 特食電文
            msgText = "00243" + pkIFS3031;
            int tret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            if (tret == -1)
            {
                throw new Exception("特食電文を転送する途中問題が発生しました。電文：" + msgText);
            }

            return true;
        }
        #endregion

        #region [외박 데이터 처리함수]
        private bool ProcessWoichulTrans()
        {
            BindVarCollection item = new BindVarCollection();
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            inputList.Clear();

            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
            inputList.Add("I_MASTER_FK", this.grdSiksaList.GetItemString(this.grdSiksaList.CurrentRowNumber, "pkinp1001"));
            inputList.Add("I_BUNHO", this.fbxBunho.GetDataValue());
            inputList.Add("I_YYYYMM", this.monthBox.GetDataValue());

            // 外泊프로시저처리함수
            bool value = Service.ExecuteProcedure("PR_IFS_INP_MONTHLY_GAIHAKU", inputList, outputList);

            if (value == false || TypeCheck.IsNull(outputList["O_CNT"]) || outputList["O_CNT"].ToString().Equals("-1"))
            {
                throw new Exception("転送マスタ（IFS3021,IFS3022）作成に問題が発生しました。");
            }
            else if (outputList["O_FK"].ToString().Equals("-1"))
            {
                throw new Exception("[IFS3021]のKEY生成に問題が発生しました。");
            }
            else
            {
                // IFS3031 PK
                if (this.WoichulTrans(outputList["O_FK"].ToString()))
                {
                    XMessageBox.Show("外泊電文の転送申請を成功しました。", "電文要請成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else throw new Exception("外泊電文を転送する途中問題が発生しました。");
            }

            #region [OLD VERSION]
//            string QuerySQL = "";
//            //XEditGrid GridList = this.mCurrentListGrid as XEditGrid;
//            BindVarCollection item = new BindVarCollection();
//            ArrayList inputList = new ArrayList();

//            if (this.mSend_YN == "N")  //외박데이터전송처리
//            {
//                QuerySQL = @" UPDATE NUR1014
//                             SET SUNAB_OUT_DATE = :f_start_date, 
//                                 SUNAB_IN_DATE  = :f_end_date
//                           WHERE HOSP_CODE = :f_hosp_code
//                             AND FKINP1001 = :f_pkINP1001
//                             AND OUT_DATE  = :f_out_date";
//                for (int i = 0; i < this.layOrderInfo.RowCount; i++)
//                {
//                    item.Clear();
//                    item.Add("f_hosp_code", EnvironInfo.HospCode);
//                    item.Add("f_pkINP1001", this.layOrderInfo.GetItemString(i, "pkINP1001"));
//                    //item.Add("f_start_date", GridList.GetItemString(GridList.CurrentRowNumber, "order_date"));
//                    item.Add("f_start_date", this.layRequisInfo.GetItemValue(0, "order_date").ToString());
//                    item.Add("f_end_date", this.layOrderInfo.GetItemString(i, "end_date"));
//                    item.Add("f_out_date", this.layOrderInfo.GetItemString(i, "out_date"));
//                    if (ExecuteNonQuery(QuerySQL, item) == false)
//                    {
//                        return false;
//                    }
//                    inputList.Clear();
//                    inputList.Add(this.layOrderInfo.GetItemString(i, "bunho"));             //환자번호
//                    inputList.Add(this.layOrderInfo.GetItemString(i, "out_date"));          //외박개시일
//                    inputList.Add(this.layOrderInfo.GetItemString(i, "out_time"));          //외박개시시간
//                    inputList.Add(this.layOrderInfo.GetItemString(i, "pkINP1001"));            //FKIN1001
//                    inputList.Add(this.layRequisInfo.GetItemValue(0, "pkinp1002").ToString());//FKIN1002
//                    inputList.Add(this.dtpJunsongDate.GetDataValue());                      //전송일
//                    inputList.Add(System.Guid.NewGuid().ToString());                        //환자정보모듈UID
//                    inputList.Add(System.Guid.NewGuid().ToString());                        //환자보험정보모듈UID
//                    inputList.Add(System.Guid.NewGuid().ToString());                        //예약정보모듈UID
//                    inputList.Add(this.layRequisInfo.GetItemValue(0, "doctor").ToString()); //의사
//                    inputList.Add(UserInfo.UserID);                                         //작성자
//                    //외박처리
//                    if (SendProcedureCallFunc("PR_OIF_MAKE_WOIBAK_INPUT", inputList, ref listDateArry) == false)
//                    {
//                        return false;
//                    }
//                    //귀원처리
//                    if (SendProcedureCallFunc("PR_OIF_MAKE_RETURN_INPUT", inputList, ref listDateArry) == false)
//                    {
//                        return false;
//                    }
//                }
//            }
//            else  //외박데이터재전송처리
//            {
//                inputList.Clear();
//                inputList.Add(this.layRequisInfo.GetItemValue(0, "bunho"));         //환자번호
//                inputList.Add(this.layRequisInfo.GetItemValue(0, "acting_date"));   //외박개시일
//                inputList.Add("");                                                  //외박개시시간
//                inputList.Add(this.layRequisInfo.GetItemValue(0, "pkINP1001"));        //FKIN1001
//                inputList.Add(this.layRequisInfo.GetItemValue(0, "pkinp1002"));     //FKIN1002
//                inputList.Add(this.dtpJunsongDate.GetDataValue());                  //전송일
//                inputList.Add(System.Guid.NewGuid().ToString());                    //환자정보모듈UID
//                inputList.Add(System.Guid.NewGuid().ToString());                    //환자보험정보모듈UID
//                inputList.Add(System.Guid.NewGuid().ToString());                    //예약정보모듈UID
//                inputList.Add(this.layRequisInfo.GetItemValue(0, "doctor"));        //의사
//                inputList.Add(UserInfo.UserID);                                     //작성자
//                //외박처리
//                if (SendProcedureCallFunc("PR_OIF_MAKE_WOIBAK_INPUT", inputList, ref listDateArry) == false)
//                {
//                    return false;
//                }
//                //귀원처리
//                if (SendProcedureCallFunc("PR_OIF_MAKE_RETURN_INPUT", inputList, ref listDateArry) == false)
//                {
//                    return false;
//                }
//            }
            //            return true;
            #endregion [OLD VERSION]
        }
        #endregion

        #region [外泊 데이터 전송함수]
        private bool WoichulTrans(string pkIFS3021)
        {
            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            // 外泊電文
            msgText = "00241" + pkIFS3021;
            int kret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            if (kret == -1)
            {
                throw new Exception("外泊電文を転送する途中問題が発生しました。電文：" + msgText);
            }

            return true;
        }
        #endregion

        #region [송신프로시저 호출함수]
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
                        this.mMsg = NetInfo.Language == LangMode.Ko ?
                             "진료구분이 최대건수(19건)를초과하였습니다. 다시선택하여 전송하십시요." :
                             "診療区分が最大件数（19件）を超えました。再度選択して転送してください。";
                        return false;
                    }
                    else
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ?
                             "진료구분은최대19건까지전송가능합니다. 전송된데이터를 확인후 ORCA에서미전송오더를추가입력하여주십시요." :
                             "診療区分は最大19件まで転送可能です。転送データ確認後、ORCAにて未転送オーダを追加入力してください。";
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if ((outputList[1].ToString() == "OIF INSURE MASTER ERROR") ||
                        (outputList[1].ToString() == "OIF GONGBI MASTER ERROR"))
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ?
                                     "환자보험이유효하지않습니다.보험정보를 확인하여주십시요" :
                                     "患者保険が有効ではありません。保険情報を確認してください。";
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
        #endregion

        #region [프로시저 호출함수]
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
        #endregion

        #region [상병 데이터 처리 함수]

        private bool SangTrans(string fkINP3010)
        {
            DataTable send_list = new DataTable();

            BindVarCollection item = new BindVarCollection();
            string QuerySQL = "";

            item.Clear();
            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_fkINP3010", fkINP3010);

            QuerySQL = @"SELECT PKIFS3014
                                           FROM IFS3014
                                          WHERE HOSP_CODE = :f_hosp_code
                                            AND FKINP3010 = :f_fkINP3010
                                            AND IF_FLAG   = '10'";

            send_list = Service.ExecuteDataTable(QuerySQL, item);

            if (TypeCheck.IsNull(send_list) && send_list.Rows.Count == 0)
            {
                throw new Exception("転送するデータが存在しません。");
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            for (int i = 0; i < send_list.Rows.Count; i++)
            {
                msgText = "00281" + send_list.Rows[i]["PKIFS3014"].ToString();
                int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
                if (ret == -1)
                {
                    throw new Exception("傷病名を転送する途中問題が発生しました。電文：" + msgText);
                }
            }
            return true;
        }

        #endregion 

        #region [오더 데이터 전송함수]

        private bool OrderTrans(string fkINP3010, string trans_gubun)
        {
            DataTable send_list = new DataTable();

            BindVarCollection item = new BindVarCollection();
            string QuerySQL = "";

            item.Clear();
            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_fkINP3010", fkINP3010);

            QuerySQL = @"SELECT PKIFS3014
                           FROM IFS3014
                          WHERE HOSP_CODE = :f_hosp_code
                            AND FKINP3010 = :f_fkINP3010
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
                throw new Exception("転送するデータが存在しません。");
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            for (int i = 0; i < send_list.Rows.Count; i++)
            {
                msgText = "00221" + send_list.Rows[i]["PKIFS3014"].ToString();
                int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
                if (ret == -1)
                {
                    throw new Exception("オーダを転送する途中問題が発生しました。電文："　+ msgText);
                }
            }
            return true;
        }

        private int MakeIFS3014(string transGubun, string io_gubun, string pkINP3010, string trans_yn)
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
            inputList.Add(pkINP3010);
            inputList.Add(trans_yn);

            switch (transGubun)
            {
                case "SANG":
                    //inputList.Add("OUT_SANG_TRANS"); 
                    procedureName = "PR_IFS_OUTSANG_TRANS";
                    break;

                case  "ORDER":
                    //inputList.Add("CREATE_IF_DETAIL");
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
            string QuerySQL_OCS2017 = "";

            //string proced = "";
            XEditGrid GridList = this.mCurrentListGrid as XEditGrid;
            BindVarCollection item = new BindVarCollection();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            string pkINP3010 = "0";

            inputList.Clear();
            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(this.fbxBunho.GetDataValue()); //환자번호

            string actDate = GridList.GetItemString(GridList.CurrentRowNumber, "acting_date");
            if (TypeCheck.IsNull(actDate) || actDate.Equals("")) inputList.Add(this.dtpJunsongDate.GetDataValue());
            else inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "acting_date"));
            inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "gubun")); //보험
            inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "gwa"));//과
            inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "doctor"));//의사
            //inputList.Add(GridList.GetItemString(GridList.CurrentRowNumber, "chojae"));//초재진 여부
            inputList.Add("4");//초재진 여부

            try
            {
                Service.BeginTransaction();
                //オーダ転送対象データ作成　-　//INP3010作成
                int sang_cnt = -1;
                int order_cnt = -1;

                bool value = Service.ExecuteProcedure("PR_IFS_INP_ORDER_MASTER_INSERT", inputList, outputList);

                if (value == false || TypeCheck.IsNull(outputList[0]) || outputList[0].ToString().Equals("-1"))
                {
                    throw new Exception("転送マスタ（INP3010）作成に問題が発生しました。");
                }
                else
                {
                    pkINP3010 = outputList[0].ToString();

                    //OCS2003に転送情報Update
                    QuerySQL = @"UPDATE OCS2003 A
                                        SET --SUNAB_YN          = 'Y'
                                            SUNAB_DATE        = DECODE(SUBSTR(A.ORDER_GUBUN, 2, 1), 'C', NULL, 'B', NULL, :f_sunab_date)
                                          --, SUNAB_TIME        = TO_CHAR(SYSDATE, 'HH24MI')
                                          , IF_DATA_SEND_YN   = 'Y'
                                          , IF_DATA_SEND_DATE = TRUNC(SYSDATE)
                                          , FKINP3010         = :f_fkinp3010
                                      WHERE HOSP_CODE         = :f_hosp_code
                                        AND PKOCS2003         = :f_pkocs2003";


                    // Add by park.w.j 2013/11/26
                    // OCS2017に転送情報Update
                    QuerySQL_OCS2017 = @"UPDATE OCS2017 A
                                        SET A.IF_DATA_SEND_YN   = 'Y'
                                          , FKINP3010           = :f_fkinp3010
                                      WHERE A.HOSP_CODE         = :f_hosp_code
                                        AND A.FKOCS2003         = :f_pkocs2003
                                        AND A.ACT_RES_DATE      = :f_acting_date
                                        --AND A.PASS_DATE         IS NOT NULL
                                        ";

                    for (int i = 0; i < grdOCS2003.RowCount; i++)
                    {
                        if (grdOCS2003.GetItemString(i, "select") == "Y")
                        {
                            item.Clear();
                            item.Add("f_fkinp3010", pkINP3010);
                            item.Add("f_hosp_code", EnvironInfo.HospCode);
                            item.Add("f_pkocs2003", grdOCS2003.GetItemString(i, "pkocs"));
                            item.Add("f_sunab_date", dtpJunsongDate.GetDataValue().ToString().Replace("-", "/"));
                            ///
                            item.Add("f_acting_date", grdOCS2003.GetItemString(i, "acting_date"));

                            // Add by park.w.j 2013/11/26
                            if (!Service.ExecuteNonQuery(QuerySQL_OCS2017, item))
                            {
                                throw new Exception("オーダ情報に反映されませんでした。");
                            }

                            if (!Service.ExecuteNonQuery(QuerySQL, item))
                            {
                                throw new Exception("オーダ情報に反映されませんでした。");
                            }
                        }
                    }

                    sang_cnt = this.MakeIFS3014("SANG", mIOGubun, pkINP3010, "Y");

                    //オーダ転送デーだ作成
                    order_cnt = this.MakeIFS3014("ORDER", mIOGubun, pkINP3010, "Y");
                }

                Service.CommitTransaction();

                //オーダ SOCKET 転送
                if (sang_cnt > 0)
                {
                    this.SangTrans(pkINP3010);
                }
                if (order_cnt > 0)
                {
                    this.OrderTrans(pkINP3010, "Y");
                }
            }
            catch (Exception ex)
            {
                Service.RollbackTransaction();
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, "オーダ転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            XMessageBox.Show("オーダ転送の申請を成功しました。", "オーダ転送要請成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool ProcessOrderTrans(ref ArrayList listDateArry)
        {                        
            if (this.mSend_YN == "N")  //오더데이터전송처리
            {
                //if (grdInpList.GetItemString(grdInpList.CurrentRowNumber, "sended_yn") == "Y")
                //{
                //    this.AccountForcedEnd();
                //    return true;
                //}
                return this.AccountComplete();
            }
            return true;
        }
        #endregion

        #region [환자공비SQL문취득함수]
        private string SetUserSQL()
        {
            string UserSQL = "";

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
            return UserSQL;
        }
        #endregion

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
                    if ((this.layOrderInfo.GetItemString(i, "pkINP1001") == e.DataRow["pkINP1001"].ToString())&&
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

        private void grdOCS2003_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //再転送の対象データ（if_flag = 10, 20)がない場合、再転送ボタンをオフにする。
            DataRow[] dw = mCurrentGrid.LayoutTable.Select("if_flag = '10' OR if_flag = '21' ");

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

            if(TypeCheck.IsNull(bunho))
            {
                XMessageBox.Show("患者を選択してください。");
                return;
            }

            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);            
            inputList.Add("I_BUNHO", bunho);
            inputList.Add("I_FROM_DATE", dtpFromdate.GetDataValue().Replace("-","/"));
            inputList.Add("I_FROM_SIK", cboFromsik.GetDataValue());
            inputList.Add("I_TO_DATE", dtpTodate.GetDataValue().Replace("-", "/"));
            inputList.Add("I_TO_SIK", cboTosik.GetDataValue());

            outputList.Add("O_PKIFS3021", "");
            try
            {
                //Service.BeginTransaction();

                if (Service.ExecuteProcedure("PR_IFS_SIKSA_INPUT_TEST", inputList, outputList))
                {
                    IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
                    string msgText = "00241" + outputList["O_PKIFS3021"].ToString();
                    int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
                    if (ret == -1)
                    {
                        throw new Exception("外泊転送する途中問題が発生しました。電文：" + msgText);
                    }
                    else
                    {
                        XMessageBox.Show("転送成功", "成功", MessageBoxIcon.Information);
                    }
                }
                //Service.CommitTransaction();
            }
            catch (Exception ex)
            {
                //Service.RollbackTransaction();
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, "転送失敗", MessageBoxIcon.Exclamation);
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
            grdINP2004.SetBindVarValue("f_fkinp1001", this.mCurrentListGrid.GetItemString(mCurrentListGrid.CurrentRowNumber, "pkINP1001"));
        }
        
        private void AccountForcedEnd()
        {
            XEditGrid GridList = this.mCurrentListGrid as XEditGrid;
            BindVarCollection item = new BindVarCollection();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            if (this.mSend_YN == "N")  //오더데이터전송처리
            {
            }
        }

        private void btnForcedEnd_Click(object sender, EventArgs e)
        {
            AccountForcedEnd();
        }

        #region [monthBox_ButtonClick 照会月変更]
        private void monthBox_ButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
            this.GridListSelectionChanged();
        }
        #endregion

        private void grdSiksaList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            string trans_yn = this.grdSiksaList.GetItemString(this.grdSiksaList.CurrentRowNumber, "trans_yn");

            /*
            オーダ：食事
            SS:1  正正
            SN:2  正未
            SF:3　正失
            NS:4　未正
            NN:5　未未
            NF:6　未失
            FS:7　失正
            FN:8　失未
            FF:9　失失
            */

            if (trans_yn == "1" || trans_yn == "4" || trans_yn == "7") this.grdSiksaList.SetItemValue(this.grdSiksaList.CurrentRowNumber, "trans_yn", "無し");

            else this.grdSiksaList.SetItemValue(this.grdSiksaList.CurrentRowNumber, "trans_yn", "有り");

        }
    }
}

