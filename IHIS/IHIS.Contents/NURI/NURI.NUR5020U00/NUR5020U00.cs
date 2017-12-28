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
using System.Collections.Specialized;
using IHIS.Framework;
#endregion

////////////////////////////////////////////////////////////////////
/// 1. 간호관리에 기준정보 추가                                  ///
///    - NUR0101 : CODE_TYPE = 'GYNMU_GUBUN'                     ///
///    - NUR0102 : CODE = 01, CODE_NAME = 深夜, MENT = 0000-0829 ///
///                       02,           = 日勤,        0830-1659 ///
///                       03,           = 準夜,        1700-2359 ///
////////////////////////////////////////////////////////////////////

namespace IHIS.NURI
{
	/// <summary>
	/// NUR1018R02에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR5020U00 : IHIS.Framework.XScreen
	{
		#region user generated value

		string[] weeks = new string[]{"日曜日", "月曜日", "火曜日", "水曜日", "木曜日", "金曜日", "土曜日"};
        XEditGrid mPBGrid = new XEditGrid();

		#endregion

        #region 자동생성
        private XPanel pnlTop;
        private XPanel pnlButton;
        private XPanel pnlMain;
        private XLabel xLabel1;
        private XDatePicker dtpDate;
        private XBuseoCombo cboBuseo;
        private XLabel xLabel2;
        private XButtonList btnList;
        private XPanel pnlLeft;
        private XPanel pnlFill;
        private XPanel pnlRight;
        private XLabel xLabel3;
        private XLabel xLabel7;
        private XLabel xLabel6;
        private XLabel xLabel5;
        private XEditMask emkJaewon;
        private XEditMask emkToiwon;
        private XEditMask emkIpwon;
        private SingleLayout layTotalCnt;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayout layStairCnt;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private XLabel xLabel8;
        private XPanel pnlWoi;
        private XLabel xLabel10;
        private XLabel xLabel11;
        private XPanel pnlTrans;
        private XLabel xLabel12;
        private XPanel pnlIpToi;
        private XPanel pnlWatchList;
        private XLabel xLabel14;
        private XPanel pnlSusul;
        private XLabel xLabel13;
        private XPanel pnlComment;
        private XLabel xLabel15;
        private XPanel pnlNurCnt;
        private XLabel xLabel16;
        private XLabel xLabel17;
        private XEditMask emkGamyum1;
        private XEditMask emkGamyum6;
        private XLabel xLabel20;
        private XEditMask emkGamyum4;
        private XTextBox txtGamyum6;
        private XLabel xLabel34;
        private XEditMask emkGamyum3;
        private XLabel xLabel26;
        private XEditMask emkGamyum5;
        private XLabel xLabel28;
        private XEditMask emkGamyum2;
        private XEditGrid grdWoi;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGrid grdComment;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGrid grdNurse;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XGridHeader xGridHeader1;
        private XEditGrid grdIpToi;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGrid grdTrans;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XGridHeader xGridHeader2;
        private XGridHeader xGridHeader3;
        private XGridHeader xGridHeader4;
        private XEditGrid grdSusul;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell69;
        private XGridHeader xGridHeader5;
        private XGridHeader xGridHeader6;
        private XEditGrid grdWatchList;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XGridHeader xGridHeader7;
        private XGridHeader xGridHeader8;
        private XEditGridCell xEditGridCell64;
        private SingleLayout layGamyumCnt;
        private SingleLayoutItem singleLayoutItem8;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem11;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private SingleLayoutItem singleLayoutItem18;
        private XFindWorker fwkNurse;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XEditGridCell xEditGridCell86;
        private XCheckBox cbxConfirm_yn;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private SingleLayout layConfirm_yn;
        private SingleLayoutItem singleLayoutItem37;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private XCheckBox cbxLoadNewData;
        private SingleLayout layPatientInfo_in;
        private SingleLayoutItem singleLayoutItem40;
        private SingleLayoutItem singleLayoutItem41;
        private SingleLayoutItem singleLayoutItem42;
        private SingleLayoutItem singleLayoutItem43;
        private SingleLayoutItem singleLayoutItem44;
        private SingleLayout layPatientInfo_out;
        private SingleLayoutItem singleLayoutItem45;
        private SingleLayoutItem singleLayoutItem46;
        private SingleLayoutItem singleLayoutItem47;
        private SingleLayoutItem singleLayoutItem48;
        private SingleLayoutItem singleLayoutItem49;
        private SingleLayoutItem singleLayoutItem51;
        private SingleLayoutItem singleLayoutItem50;
        private XDataWindow dw_print;
        private MultiLayout layNur5020;
        private SingleLayout layNur5020Save;
        private SingleLayoutItem singleLayoutItem19;
        private SingleLayoutItem singleLayoutItem20;
        private SingleLayoutItem singleLayoutItem21;
        private SingleLayoutItem singleLayoutItem22;
        private SingleLayoutItem singleLayoutItem23;
        private SingleLayoutItem singleLayoutItem24;
        private SingleLayoutItem singleLayoutItem25;
        private SingleLayoutItem singleLayoutItem26;
        private SingleLayoutItem singleLayoutItem27;
        private SingleLayoutItem singleLayoutItem28;
        private SingleLayoutItem singleLayoutItem31;
        private SingleLayoutItem singleLayoutItem34;
        private SingleLayoutItem singleLayoutItem35;
        private SingleLayoutItem singleLayoutItem36;
        private SingleLayoutItem singleLayoutItem38;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell91;
        private MultiLayout layNurCnt;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private SingleLayoutItem singleLayoutItem39;
        private SingleLayout layPatientInfo;
        private SingleLayoutItem singleLayoutItem52;
        private SingleLayoutItem singleLayoutItem53;
        private SingleLayoutItem singleLayoutItem54;
        private SingleLayoutItem singleLayoutItem55;
        private SingleLayoutItem singleLayoutItem56;
        private SingleLayoutItem singleLayoutItem57;
        #endregion
        private XLabel xLabel24;
        private XLabel xLabel4;
        private XEditMask emkMoveIn;
        private XEditMask emkMoveOut;
        private SingleLayoutItem singleLayoutItem60;
        private SingleLayoutItem singleLayoutItem61;
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
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private XLabel xLabel18;
        private XEditGrid grdGwa;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell92;
        private XEditGrid grdNURCnt;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell102;
        private XEditGridCell xEditGridCell103;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell106;
        private XEditGridCell xEditGridCell107;
        private XEditGridCell xEditGridCell108;
        private XEditGridCell xEditGridCell109;
        private XLabel xLabel9;
        private XPanel pnlGwa;
        private XPanel pnlGuho;
        private XPanel pnlGamyum;
        private XPanel pnlPatient;
        private XPanel pnlLR;
        private XPanel pnlLL;
        private XPanel xPanel3;
        private XLabel xLabel19;
        private XEditGrid grdBedSore;
        private XEditGridCell xEditGridCell110;
        private XEditGridCell xEditGridCell111;
        private XEditGridCell xEditGridCell112;
        private XEditGridCell xEditGridCell113;
        private XEditGridCell xEditGridCell114;
        private XEditGridCell xEditGridCell115;
        private XEditGridCell xEditGridCell116;
        private SingleLayoutItem singleLayoutItem29;
        private SingleLayoutItem singleLayoutItem30;
        private SingleLayoutItem singleLayoutItem32;
        private SingleLayoutItem singleLayoutItem33;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell118;
        private XEditGridCell xEditGridCell117;
        private XEditGrid grdGuhoGubun;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XFindWorker fwkGwa;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XGridHeader xGridHeader9;
        private XEditGridCell xEditGridCell120;
        private XEditGridCell xEditGridCell121;
        private XEditGridCell xEditGridCell122;

        #region 자동 생성 멤버 변수

        private System.ComponentModel.IContainer components = null;

		#endregion		

		#region 생성자


		public NUR5020U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}

		#endregion

		#region 소멸자

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

		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR5020U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cbxLoadNewData = new IHIS.Framework.XCheckBox();
            this.cbxConfirm_yn = new IHIS.Framework.XCheckBox();
            this.cboBuseo = new IHIS.Framework.XBuseoCombo();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pnlWoi = new IHIS.Framework.XPanel();
            this.grdWoi = new IHIS.Framework.XEditGrid();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.pnlButton = new IHIS.Framework.XPanel();
            this.dw_print = new IHIS.Framework.XDataWindow();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlMain = new IHIS.Framework.XPanel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.pnlTrans = new IHIS.Framework.XPanel();
            this.grdTrans = new IHIS.Framework.XEditGrid();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.xGridHeader4 = new IHIS.Framework.XGridHeader();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.pnlIpToi = new IHIS.Framework.XPanel();
            this.grdIpToi = new IHIS.Framework.XEditGrid();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.pnlSusul = new IHIS.Framework.XPanel();
            this.grdSusul = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader5 = new IHIS.Framework.XGridHeader();
            this.xGridHeader6 = new IHIS.Framework.XGridHeader();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.pnlWatchList = new IHIS.Framework.XPanel();
            this.grdWatchList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader7 = new IHIS.Framework.XGridHeader();
            this.xGridHeader8 = new IHIS.Framework.XGridHeader();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdBedSore = new IHIS.Framework.XEditGrid();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.pnlLR = new IHIS.Framework.XPanel();
            this.pnlGwa = new IHIS.Framework.XPanel();
            this.grdGwa = new IHIS.Framework.XEditGrid();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.fwkGwa = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader9 = new IHIS.Framework.XGridHeader();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.pnlGuho = new IHIS.Framework.XPanel();
            this.grdGuhoGubun = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.pnlLL = new IHIS.Framework.XPanel();
            this.pnlGamyum = new IHIS.Framework.XPanel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.emkGamyum2 = new IHIS.Framework.XEditMask();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.emkGamyum3 = new IHIS.Framework.XEditMask();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.emkGamyum5 = new IHIS.Framework.XEditMask();
            this.txtGamyum6 = new IHIS.Framework.XTextBox();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.emkGamyum4 = new IHIS.Framework.XEditMask();
            this.emkGamyum1 = new IHIS.Framework.XEditMask();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel34 = new IHIS.Framework.XLabel();
            this.emkGamyum6 = new IHIS.Framework.XEditMask();
            this.pnlPatient = new IHIS.Framework.XPanel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.emkMoveIn = new IHIS.Framework.XEditMask();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.emkJaewon = new IHIS.Framework.XEditMask();
            this.emkToiwon = new IHIS.Framework.XEditMask();
            this.emkMoveOut = new IHIS.Framework.XEditMask();
            this.emkIpwon = new IHIS.Framework.XEditMask();
            this.pnlNurCnt = new IHIS.Framework.XPanel();
            this.grdNURCnt = new IHIS.Framework.XEditGrid();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.grdNurse = new IHIS.Framework.XEditGrid();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.fwkNurse = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.pnlComment = new IHIS.Framework.XPanel();
            this.grdComment = new IHIS.Framework.XEditGrid();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.layTotalCnt = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem29 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem30 = new IHIS.Framework.SingleLayoutItem();
            this.layStairCnt = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem39 = new IHIS.Framework.SingleLayoutItem();
            this.layGamyumCnt = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.layConfirm_yn = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem37 = new IHIS.Framework.SingleLayoutItem();
            this.layPatientInfo_in = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem32 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem40 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem41 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem42 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem43 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem44 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem51 = new IHIS.Framework.SingleLayoutItem();
            this.layPatientInfo_out = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem33 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem45 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem46 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem47 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem48 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem49 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem50 = new IHIS.Framework.SingleLayoutItem();
            this.layNur5020 = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.layNur5020Save = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem20 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem21 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem22 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem60 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem61 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem23 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem24 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem25 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem26 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem27 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem28 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem31 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem34 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem35 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem36 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem38 = new IHIS.Framework.SingleLayoutItem();
            this.layNurCnt = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.layPatientInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem52 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem53 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem54 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem55 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem56 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem57 = new IHIS.Framework.SingleLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBuseo)).BeginInit();
            this.pnlWoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWoi)).BeginInit();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.pnlTrans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrans)).BeginInit();
            this.pnlIpToi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIpToi)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlSusul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSusul)).BeginInit();
            this.pnlWatchList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWatchList)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBedSore)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlLR.SuspendLayout();
            this.pnlGwa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGwa)).BeginInit();
            this.pnlGuho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGuhoGubun)).BeginInit();
            this.pnlLL.SuspendLayout();
            this.pnlGamyum.SuspendLayout();
            this.pnlPatient.SuspendLayout();
            this.pnlNurCnt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNURCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNurse)).BeginInit();
            this.pnlComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNur5020)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNurCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "회전_글올리기(화살표)_1.gif");
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = global::IHIS.NURI.Properties.Resources.TopBackground;
            this.pnlTop.Controls.Add(this.cbxLoadNewData);
            this.pnlTop.Controls.Add(this.cbxConfirm_yn);
            this.pnlTop.Controls.Add(this.cboBuseo);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.dtpDate);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1404, 31);
            this.pnlTop.TabIndex = 0;
            // 
            // cbxLoadNewData
            // 
            this.cbxLoadNewData.AutoSize = true;
            this.cbxLoadNewData.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.cbxLoadNewData.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.cbxLoadNewData.ForeColor = IHIS.Framework.XColor.ShadowForeColor;
            this.cbxLoadNewData.Location = new System.Drawing.Point(570, 7);
            this.cbxLoadNewData.Name = "cbxLoadNewData";
            this.cbxLoadNewData.Size = new System.Drawing.Size(159, 19);
            this.cbxLoadNewData.TabIndex = 6;
            this.cbxLoadNewData.Text = "新規データを取り込む";
            this.cbxLoadNewData.UseVisualStyleBackColor = false;
            this.cbxLoadNewData.Visible = false;
            this.cbxLoadNewData.CheckedChanged += new System.EventHandler(this.cbxLoadNewData_CheckedChanged);
            // 
            // cbxConfirm_yn
            // 
            this.cbxConfirm_yn.AutoSize = true;
            this.cbxConfirm_yn.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.cbxConfirm_yn.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.cbxConfirm_yn.ForeColor = IHIS.Framework.XColor.ShadowForeColor;
            this.cbxConfirm_yn.Location = new System.Drawing.Point(383, 7);
            this.cbxConfirm_yn.Name = "cbxConfirm_yn";
            this.cbxConfirm_yn.Size = new System.Drawing.Size(181, 19);
            this.cbxConfirm_yn.TabIndex = 5;
            this.cbxConfirm_yn.Text = "病棟管理日誌作成済み";
            this.cbxConfirm_yn.UseVisualStyleBackColor = false;
            // 
            // cboBuseo
            // 
            this.cboBuseo.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboBuseo.Location = new System.Drawing.Point(256, 5);
            this.cboBuseo.Name = "cboBuseo";
            this.cboBuseo.Size = new System.Drawing.Size(121, 21);
            this.cboBuseo.TabIndex = 3;
            this.cboBuseo.SelectedValueChanged += new System.EventHandler(this.cboBuseo_SelectedValueChanged);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(186, 5);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(70, 21);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "病棟";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.dtpDate.IsJapanYearType = true;
            this.dtpDate.Location = new System.Drawing.Point(73, 5);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(110, 21);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(3, 5);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(70, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "基準日";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlWoi
            // 
            this.pnlWoi.Controls.Add(this.grdWoi);
            this.pnlWoi.Controls.Add(this.xLabel10);
            this.pnlWoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlWoi.Location = new System.Drawing.Point(0, 478);
            this.pnlWoi.Name = "pnlWoi";
            this.pnlWoi.Size = new System.Drawing.Size(535, 195);
            this.pnlWoi.TabIndex = 1;
            // 
            // grdWoi
            // 
            this.grdWoi.CallerID = '3';
            this.grdWoi.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell119,
            this.xEditGridCell8,
            this.xEditGridCell69,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell84,
            this.xEditGridCell14,
            this.xEditGridCell85,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell89,
            this.xEditGridCell91});
            this.grdWoi.ColPerLine = 8;
            this.grdWoi.Cols = 8;
            this.grdWoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWoi.FixedRows = 1;
            this.grdWoi.HeaderHeights.Add(32);
            this.grdWoi.Location = new System.Drawing.Point(0, 21);
            this.grdWoi.Name = "grdWoi";
            this.grdWoi.Rows = 2;
            this.grdWoi.Size = new System.Drawing.Size(535, 174);
            this.grdWoi.TabIndex = 6;
            this.grdWoi.ToolTipActive = true;
            this.grdWoi.UseDefaultTransaction = false;
            this.grdWoi.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grd_ItemValueChanging);
            this.grdWoi.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdWoi_QueryStarting);
            this.grdWoi.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdWoi.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grd_GridColumnProtectModify);
            this.grdWoi.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdWoi.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grd_GridFindClick);
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "pknur5023";
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.IsUpdatable = false;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "nur_wrdt";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "nur_wrdt";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "ho_dong";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.HeaderText = "ho_dong";
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 2;
            this.xEditGridCell9.CellName = "gubun";
            this.xEditGridCell9.CellWidth = 30;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell9.HeaderText = "区分";
            this.xEditGridCell9.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell9.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'WOICHUL_WOPIBAK_GUBUN\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "gubun_name";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "gubun_name";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bunho";
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell11.HeaderText = "患者番号";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 30;
            this.xEditGridCell12.CellName = "suname";
            this.xEditGridCell12.CellWidth = 90;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.HeaderText = "患者名";
            this.xEditGridCell12.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell12.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 5;
            this.xEditGridCell13.CellName = "ho_code";
            this.xEditGridCell13.CellWidth = 30;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.HeaderText = "病室";
            this.xEditGridCell13.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "date1";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.HeaderText = "date1";
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "time1";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell14.CellWidth = 40;
            this.xEditGridCell14.Col = 4;
            this.xEditGridCell14.HeaderText = "出院\r\n時間";
            this.xEditGridCell14.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell14.Mask = "HH:MI";
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "date2";
            this.xEditGridCell85.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell85.Col = 5;
            this.xEditGridCell85.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell85.HeaderText = "帰院\r\n日付";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "time2";
            this.xEditGridCell15.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell15.CellWidth = 40;
            this.xEditGridCell15.Col = 6;
            this.xEditGridCell15.HeaderText = "帰院\r\n時間";
            this.xEditGridCell15.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell15.Mask = "HH:MI";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 100;
            this.xEditGridCell16.CellName = "bigo";
            this.xEditGridCell16.CellWidth = 200;
            this.xEditGridCell16.Col = 7;
            this.xEditGridCell16.HeaderText = "備考";
            this.xEditGridCell16.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellLen = 20;
            this.xEditGridCell89.CellName = "date1_jpn";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellLen = 20;
            this.xEditGridCell91.CellName = "date2_jpn";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.IsUpdatable = false;
            this.xEditGridCell91.IsUpdCol = false;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel10.Location = new System.Drawing.Point(0, 0);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(535, 21);
            this.xLabel10.TabIndex = 5;
            this.xLabel10.Text = "外出・外泊";
            // 
            // pnlButton
            // 
            this.pnlButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButton.Controls.Add(this.dw_print);
            this.pnlButton.Controls.Add(this.btnList);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 706);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1404, 36);
            this.pnlButton.TabIndex = 0;
            // 
            // dw_print
            // 
            this.dw_print.DataWindowObject = "dw_title";
            this.dw_print.LibraryList = "..\\NURI\\nuri.nur5020u00.pbd";
            this.dw_print.Location = new System.Drawing.Point(301, 5);
            this.dw_print.Name = "dw_print";
            this.dw_print.Size = new System.Drawing.Size(75, 23);
            this.dw_print.TabIndex = 1;
            this.dw_print.Text = "xDataWindow1";
            this.dw_print.Visible = false;
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(912, -2);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(487, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlFill);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1404, 675);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlFill
            // 
            this.pnlFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFill.Controls.Add(this.pnlTrans);
            this.pnlFill.Controls.Add(this.pnlWoi);
            this.pnlFill.Controls.Add(this.pnlIpToi);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(401, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(537, 675);
            this.pnlFill.TabIndex = 1;
            // 
            // pnlTrans
            // 
            this.pnlTrans.Controls.Add(this.grdTrans);
            this.pnlTrans.Controls.Add(this.xLabel12);
            this.pnlTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrans.Location = new System.Drawing.Point(0, 265);
            this.pnlTrans.Name = "pnlTrans";
            this.pnlTrans.Size = new System.Drawing.Size(535, 213);
            this.pnlTrans.TabIndex = 8;
            // 
            // grdTrans
            // 
            this.grdTrans.AddedHeaderLine = 1;
            this.grdTrans.CallerID = '7';
            this.grdTrans.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell118,
            this.xEditGridCell38,
            this.xEditGridCell65,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell47,
            this.xEditGridCell48});
            this.grdTrans.ColPerLine = 11;
            this.grdTrans.Cols = 11;
            this.grdTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTrans.FixedRows = 2;
            this.grdTrans.HeaderHeights.Add(21);
            this.grdTrans.HeaderHeights.Add(0);
            this.grdTrans.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2,
            this.xGridHeader3,
            this.xGridHeader4});
            this.grdTrans.Location = new System.Drawing.Point(0, 21);
            this.grdTrans.Name = "grdTrans";
            this.grdTrans.Rows = 3;
            this.grdTrans.Size = new System.Drawing.Size(535, 192);
            this.grdTrans.TabIndex = 8;
            this.grdTrans.ToolTipActive = true;
            this.grdTrans.UseDefaultTransaction = false;
            this.grdTrans.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grd_ItemValueChanging);
            this.grdTrans.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdTrans_QueryStarting);
            this.grdTrans.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdTrans.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grd_GridColumnProtectModify);
            this.grdTrans.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdTrans.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grd_GridFindClick);
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "pknur5023";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.IsUpdatable = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "nur_wrdt";
            this.xEditGridCell38.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.HeaderText = "nur_wrdt";
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "ho_dong";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.HeaderText = "ho_dong";
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "gubun";
            this.xEditGridCell39.CellWidth = 30;
            this.xEditGridCell39.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell39.HeaderText = "区分";
            this.xEditGridCell39.RowSpan = 2;
            this.xEditGridCell39.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell39.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell39.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'JUNGWA_JUNSIL\'\r\n ORDER BY SORT_KEY, CODE";
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "gubun_name";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.HeaderText = "gubun_name";
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "bunho";
            this.xEditGridCell41.CellWidth = 71;
            this.xEditGridCell41.Col = 1;
            this.xEditGridCell41.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell41.HeaderText = "患者番号";
            this.xEditGridCell41.Row = 1;
            this.xEditGridCell41.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "suname";
            this.xEditGridCell42.CellWidth = 83;
            this.xEditGridCell42.Col = 2;
            this.xEditGridCell42.HeaderText = "氏名";
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.Row = 1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "from_gwa";
            this.xEditGridCell43.CellWidth = 85;
            this.xEditGridCell43.Col = 5;
            this.xEditGridCell43.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell43.HeaderText = "from_gwa";
            this.xEditGridCell43.Row = 1;
            this.xEditGridCell43.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell43.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell43.UserSQL = "SELECT GWA, GWA_NAME\r\n  FROM BAS0260\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r" +
                "\n   AND BUSEO_GUBUN = \'1\'\r\n   AND SYSDATE BETWEEN START_DATE AND END_DATE\r\n ORDE" +
                "R BY GWA";
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "to_gwa";
            this.xEditGridCell44.CellWidth = 85;
            this.xEditGridCell44.Col = 7;
            this.xEditGridCell44.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell44.HeaderText = "to_gwa";
            this.xEditGridCell44.Row = 1;
            this.xEditGridCell44.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell44.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell44.UserSQL = "SELECT GWA, GWA_NAME\r\n  FROM BAS0260\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r" +
                "\n   AND BUSEO_GUBUN = \'1\'\r\n   AND SYSDATE BETWEEN START_DATE AND END_DATE\r\n ORDE" +
                "R BY GWA";
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellLen = 5;
            this.xEditGridCell45.CellName = "from_ho_code";
            this.xEditGridCell45.CellWidth = 39;
            this.xEditGridCell45.Col = 8;
            this.xEditGridCell45.HeaderText = "from_ho_code";
            this.xEditGridCell45.Row = 1;
            this.xEditGridCell45.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellLen = 5;
            this.xEditGridCell46.CellName = "to_ho_code";
            this.xEditGridCell46.CellWidth = 39;
            this.xEditGridCell46.Col = 10;
            this.xEditGridCell46.HeaderText = "to_ho_code";
            this.xEditGridCell46.Row = 1;
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "from_gwa_name";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.HeaderText = "from_gwa_name";
            this.xEditGridCell87.IsUpdCol = false;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "to_gwa_name";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.HeaderText = "to_gwa_name";
            this.xEditGridCell88.IsUpdCol = false;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "age";
            this.xEditGridCell120.CellWidth = 22;
            this.xEditGridCell120.Col = 3;
            this.xEditGridCell120.HeaderText = "年";
            this.xEditGridCell120.IsReadOnly = true;
            this.xEditGridCell120.RowSpan = 2;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "sex";
            this.xEditGridCell121.CellWidth = 23;
            this.xEditGridCell121.Col = 4;
            this.xEditGridCell121.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell121.HeaderText = "性";
            this.xEditGridCell121.IsReadOnly = true;
            this.xEditGridCell121.RowSpan = 2;
            this.xEditGridCell121.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell121.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'SEX\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowImage = global::IHIS.NURI.Properties.Resources.회전_글올리기_화살표__1;
            this.xEditGridCell47.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell47.CellName = "image1";
            this.xEditGridCell47.CellWidth = 21;
            this.xEditGridCell47.Col = 6;
            this.xEditGridCell47.HeaderText = "image1";
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsUpdCol = false;
            this.xEditGridCell47.Row = 1;
            this.xEditGridCell47.RowImage = global::IHIS.NURI.Properties.Resources.회전_글올리기_화살표__1;
            this.xEditGridCell47.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowImage = global::IHIS.NURI.Properties.Resources.회전_글올리기_화살표__1;
            this.xEditGridCell48.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell48.CellName = "image2";
            this.xEditGridCell48.CellWidth = 32;
            this.xEditGridCell48.Col = 9;
            this.xEditGridCell48.HeaderText = "image2";
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.IsUpdCol = false;
            this.xEditGridCell48.Row = 1;
            this.xEditGridCell48.RowImage = global::IHIS.NURI.Properties.Resources.회전_글올리기_화살표__1;
            this.xEditGridCell48.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 1;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderText = "患　者";
            this.xGridHeader2.HeaderWidth = 58;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 5;
            this.xGridHeader3.ColSpan = 3;
            this.xGridHeader3.HeaderText = "診療科";
            this.xGridHeader3.HeaderWidth = 85;
            // 
            // xGridHeader4
            // 
            this.xGridHeader4.Col = 8;
            this.xGridHeader4.ColSpan = 3;
            this.xGridHeader4.HeaderText = "病室";
            this.xGridHeader4.HeaderWidth = 39;
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel12.Location = new System.Drawing.Point(0, 0);
            this.xLabel12.Name = "xLabel12";
            this.xLabel12.Size = new System.Drawing.Size(535, 21);
            this.xLabel12.TabIndex = 7;
            this.xLabel12.Text = "転科・転室";
            // 
            // pnlIpToi
            // 
            this.pnlIpToi.Controls.Add(this.grdIpToi);
            this.pnlIpToi.Controls.Add(this.xLabel11);
            this.pnlIpToi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIpToi.Location = new System.Drawing.Point(0, 0);
            this.pnlIpToi.Name = "pnlIpToi";
            this.pnlIpToi.Size = new System.Drawing.Size(535, 265);
            this.pnlIpToi.TabIndex = 7;
            // 
            // grdIpToi
            // 
            this.grdIpToi.CallerID = '6';
            this.grdIpToi.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell117,
            this.xEditGridCell27,
            this.xEditGridCell66,
            this.xEditGridCell28,
            this.xEditGridCell86,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37});
            this.grdIpToi.ColPerLine = 9;
            this.grdIpToi.Cols = 9;
            this.grdIpToi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIpToi.FixedRows = 1;
            this.grdIpToi.HeaderHeights.Add(21);
            this.grdIpToi.Location = new System.Drawing.Point(0, 21);
            this.grdIpToi.Name = "grdIpToi";
            this.grdIpToi.Rows = 2;
            this.grdIpToi.Size = new System.Drawing.Size(535, 244);
            this.grdIpToi.TabIndex = 7;
            this.grdIpToi.ToolTipActive = true;
            this.grdIpToi.UseDefaultTransaction = false;
            this.grdIpToi.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grd_ItemValueChanging);
            this.grdIpToi.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdIpToi_QueryStarting);
            this.grdIpToi.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdIpToi.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grd_GridColumnProtectModify);
            this.grdIpToi.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdIpToi.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grd_GridFindClick);
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "pknur5023";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "nur_wrdt";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.HeaderText = "nur_wrdt";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "ho_dong";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.HeaderText = "ho_dong";
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "gubun";
            this.xEditGridCell28.CellWidth = 30;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell28.HeaderText = "区分";
            this.xEditGridCell28.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell28.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell28.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'IPWON_TOIWON\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "gubun_name";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.IsUpdCol = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "gwa";
            this.xEditGridCell29.CellWidth = 66;
            this.xEditGridCell29.Col = 1;
            this.xEditGridCell29.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell29.HeaderText = "科";
            this.xEditGridCell29.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell29.UserSQL = "SELECT GWA, GWA_NAME\r\n  FROM BAS0260\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r" +
                "\n   AND BUSEO_GUBUN = \'1\'\r\n   AND SYSDATE BETWEEN START_DATE AND END_DATE\r\n ORDE" +
                "R BY GWA";
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "gwa_name";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.HeaderText = "gwa_name";
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 5;
            this.xEditGridCell31.CellName = "ho_code";
            this.xEditGridCell31.CellWidth = 30;
            this.xEditGridCell31.Col = 2;
            this.xEditGridCell31.HeaderText = "病室";
            this.xEditGridCell31.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "bunho";
            this.xEditGridCell32.CellWidth = 92;
            this.xEditGridCell32.Col = 3;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell32.HeaderText = "患者番号";
            this.xEditGridCell32.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "suname";
            this.xEditGridCell33.CellWidth = 100;
            this.xEditGridCell33.Col = 4;
            this.xEditGridCell33.HeaderText = "患者名";
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdatable = false;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "age";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell34.CellWidth = 27;
            this.xEditGridCell34.Col = 5;
            this.xEditGridCell34.HeaderText = "年齢";
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.MaxinumCipher = 3;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "sex";
            this.xEditGridCell35.CellWidth = 27;
            this.xEditGridCell35.Col = 6;
            this.xEditGridCell35.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell35.HeaderText = "性別";
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell35.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell35.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'SEX\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 100;
            this.xEditGridCell36.CellName = "sang";
            this.xEditGridCell36.CellWidth = 110;
            this.xEditGridCell36.Col = 7;
            this.xEditGridCell36.HeaderText = "疾患名";
            this.xEditGridCell36.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellLen = 50;
            this.xEditGridCell37.CellName = "bigo";
            this.xEditGridCell37.CellWidth = 151;
            this.xEditGridCell37.Col = 8;
            this.xEditGridCell37.HeaderText = "記事";
            this.xEditGridCell37.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel11.Location = new System.Drawing.Point(0, 0);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(535, 21);
            this.xLabel11.TabIndex = 6;
            this.xLabel11.Text = "入院・退院";
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.pnlSusul);
            this.pnlRight.Controls.Add(this.pnlWatchList);
            this.pnlRight.Controls.Add(this.xPanel3);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(938, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(466, 675);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlSusul
            // 
            this.pnlSusul.Controls.Add(this.grdSusul);
            this.pnlSusul.Controls.Add(this.xLabel13);
            this.pnlSusul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSusul.Location = new System.Drawing.Point(0, 265);
            this.pnlSusul.Name = "pnlSusul";
            this.pnlSusul.Size = new System.Drawing.Size(464, 213);
            this.pnlSusul.TabIndex = 0;
            // 
            // grdSusul
            // 
            this.grdSusul.AddedHeaderLine = 1;
            this.grdSusul.CallerID = '8';
            this.grdSusul.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63});
            this.grdSusul.ColPerLine = 11;
            this.grdSusul.Cols = 11;
            this.grdSusul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSusul.FixedRows = 2;
            this.grdSusul.FocusColumnName = "bunho";
            this.grdSusul.HeaderHeights.Add(16);
            this.grdSusul.HeaderHeights.Add(17);
            this.grdSusul.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader5,
            this.xGridHeader6});
            this.grdSusul.Location = new System.Drawing.Point(0, 21);
            this.grdSusul.Name = "grdSusul";
            this.grdSusul.Rows = 3;
            this.grdSusul.Size = new System.Drawing.Size(464, 192);
            this.grdSusul.TabIndex = 8;
            this.grdSusul.ToolTipActive = true;
            this.grdSusul.UseDefaultTransaction = false;
            this.grdSusul.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSusul_QueryStarting);
            this.grdSusul.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdSusul.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdSusul.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grd_GridFindClick);
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "nur_wrdt";
            this.xEditGridCell49.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "nur_wrdt";
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "gubun";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "区分";
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellLen = 20;
            this.xEditGridCell51.CellName = "gwa";
            this.xEditGridCell51.CellWidth = 55;
            this.xEditGridCell51.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell51.HeaderText = "診療科";
            this.xEditGridCell51.RowSpan = 2;
            this.xEditGridCell51.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell51.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell51.UserSQL = "SELECT GWA, GWA_NAME\r\n  FROM BAS0260\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r" +
                "\n   AND BUSEO_GUBUN = \'1\'\r\n   AND SYSDATE BETWEEN START_DATE AND END_DATE\r\n ORDE" +
                "R BY GWA";
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "gwa_name";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.HeaderText = "科";
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsUpdCol = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "ho_dong";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.HeaderText = "病棟";
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellLen = 5;
            this.xEditGridCell54.CellName = "ho_code";
            this.xEditGridCell54.CellWidth = 27;
            this.xEditGridCell54.Col = 1;
            this.xEditGridCell54.HeaderText = "病室";
            this.xEditGridCell54.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell54.RowSpan = 2;
            this.xEditGridCell54.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "bunho";
            this.xEditGridCell55.CellWidth = 75;
            this.xEditGridCell55.Col = 2;
            this.xEditGridCell55.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell55.HeaderText = "患者番号";
            this.xEditGridCell55.Row = 1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellLen = 60;
            this.xEditGridCell56.CellName = "suname";
            this.xEditGridCell56.CellWidth = 100;
            this.xEditGridCell56.Col = 3;
            this.xEditGridCell56.HeaderText = "患者名";
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.Row = 1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellLen = 30;
            this.xEditGridCell57.CellName = "age";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell57.CellWidth = 25;
            this.xEditGridCell57.Col = 4;
            this.xEditGridCell57.HeaderText = "年\r\n齢";
            this.xEditGridCell57.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.MaxinumCipher = 3;
            this.xEditGridCell57.RowSpan = 2;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "sex";
            this.xEditGridCell58.CellWidth = 24;
            this.xEditGridCell58.Col = 5;
            this.xEditGridCell58.HeaderText = "性\r\n別";
            this.xEditGridCell58.IsReadOnly = true;
            this.xEditGridCell58.RowSpan = 2;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellLen = 1200;
            this.xEditGridCell59.CellName = "sang";
            this.xEditGridCell59.CellWidth = 133;
            this.xEditGridCell59.Col = 6;
            this.xEditGridCell59.HeaderText = "病名";
            this.xEditGridCell59.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell59.RowSpan = 2;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellLen = 30;
            this.xEditGridCell60.CellName = "susul";
            this.xEditGridCell60.CellWidth = 100;
            this.xEditGridCell60.Col = 7;
            this.xEditGridCell60.HeaderText = "術式";
            this.xEditGridCell60.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell60.RowSpan = 2;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellLen = 100;
            this.xEditGridCell61.CellName = "state1";
            this.xEditGridCell61.CellWidth = 120;
            this.xEditGridCell61.Col = 8;
            this.xEditGridCell61.HeaderText = "0:00～9:00";
            this.xEditGridCell61.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell61.Row = 1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellLen = 100;
            this.xEditGridCell62.CellName = "state2";
            this.xEditGridCell62.CellWidth = 120;
            this.xEditGridCell62.Col = 9;
            this.xEditGridCell62.HeaderText = "9:00～17:00";
            this.xEditGridCell62.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell62.Row = 1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellLen = 100;
            this.xEditGridCell63.CellName = "state3";
            this.xEditGridCell63.CellWidth = 120;
            this.xEditGridCell63.Col = 10;
            this.xEditGridCell63.HeaderText = "17:00～0:00";
            this.xEditGridCell63.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell63.Row = 1;
            // 
            // xGridHeader5
            // 
            this.xGridHeader5.Col = 2;
            this.xGridHeader5.ColSpan = 2;
            this.xGridHeader5.HeaderText = "患　者";
            this.xGridHeader5.HeaderWidth = 75;
            // 
            // xGridHeader6
            // 
            this.xGridHeader6.Col = 8;
            this.xGridHeader6.ColSpan = 3;
            this.xGridHeader6.HeaderText = "術後の状態";
            this.xGridHeader6.HeaderWidth = 120;
            // 
            // xLabel13
            // 
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel13.Location = new System.Drawing.Point(0, 0);
            this.xLabel13.Name = "xLabel13";
            this.xLabel13.Size = new System.Drawing.Size(472, 21);
            this.xLabel13.TabIndex = 7;
            this.xLabel13.Text = "本日の手術";
            // 
            // pnlWatchList
            // 
            this.pnlWatchList.Controls.Add(this.grdWatchList);
            this.pnlWatchList.Controls.Add(this.xLabel14);
            this.pnlWatchList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlWatchList.Location = new System.Drawing.Point(0, 478);
            this.pnlWatchList.Name = "pnlWatchList";
            this.pnlWatchList.Size = new System.Drawing.Size(464, 195);
            this.pnlWatchList.TabIndex = 1;
            // 
            // grdWatchList
            // 
            this.grdWatchList.AddedHeaderLine = 1;
            this.grdWatchList.CallerID = '9';
            this.grdWatchList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell64,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell74,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83});
            this.grdWatchList.ColPerLine = 11;
            this.grdWatchList.Cols = 11;
            this.grdWatchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWatchList.FixedRows = 2;
            this.grdWatchList.HeaderHeights.Add(17);
            this.grdWatchList.HeaderHeights.Add(16);
            this.grdWatchList.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader7,
            this.xGridHeader8});
            this.grdWatchList.IsAllDataQuery = true;
            this.grdWatchList.Location = new System.Drawing.Point(0, 21);
            this.grdWatchList.Name = "grdWatchList";
            this.grdWatchList.QuerySQL = resources.GetString("grdWatchList.QuerySQL");
            this.grdWatchList.Rows = 3;
            this.grdWatchList.Size = new System.Drawing.Size(464, 174);
            this.grdWatchList.TabIndex = 9;
            this.grdWatchList.UseDefaultTransaction = false;
            this.grdWatchList.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grd_ItemValueChanging);
            this.grdWatchList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdWatchList_QueryStarting);
            this.grdWatchList.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdWatchList.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grd_GridColumnProtectModify);
            this.grdWatchList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdWatchList.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grd_GridFindClick);
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "nur_wrdt";
            this.xEditGridCell70.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.IsReadOnly = true;
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "gubun";
            this.xEditGridCell71.CellWidth = 40;
            this.xEditGridCell71.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6});
            this.xEditGridCell71.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell71.HeaderText = "区分";
            this.xEditGridCell71.IsUpdatable = false;
            this.xEditGridCell71.RowSpan = 2;
            this.xEditGridCell71.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell71.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell71.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'WATCHLIST\'\r\n ORDER BY CODE";
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "要注意";
            this.xComboItem5.ValueItem = "01";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "重症";
            this.xComboItem6.ValueItem = "02";
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "gubun_name";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.HeaderText = "gubun_name";
            this.xEditGridCell64.IsReadOnly = true;
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "gwa";
            this.xEditGridCell72.CellWidth = 52;
            this.xEditGridCell72.Col = 1;
            this.xEditGridCell72.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell72.HeaderText = "診療科";
            this.xEditGridCell72.RowSpan = 2;
            this.xEditGridCell72.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell72.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell72.UserSQL = "SELECT GWA, GWA_NAME\r\n  FROM BAS0260\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r" +
                "\n   AND BUSEO_GUBUN = \'1\'\r\n   AND SYSDATE BETWEEN START_DATE AND END_DATE\r\n ORDE" +
                "R BY GWA";
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "gwa_name";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "ho_dong";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.HeaderText = "病棟";
            this.xEditGridCell74.IsReadOnly = true;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellLen = 5;
            this.xEditGridCell75.CellName = "ho_code";
            this.xEditGridCell75.CellWidth = 27;
            this.xEditGridCell75.Col = 2;
            this.xEditGridCell75.HeaderText = "病室";
            this.xEditGridCell75.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell75.RowSpan = 2;
            this.xEditGridCell75.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "bunho";
            this.xEditGridCell76.CellWidth = 75;
            this.xEditGridCell76.Col = 3;
            this.xEditGridCell76.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell76.HeaderText = "患者番号";
            this.xEditGridCell76.Row = 1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellLen = 30;
            this.xEditGridCell77.CellName = "suname";
            this.xEditGridCell77.CellWidth = 114;
            this.xEditGridCell77.Col = 4;
            this.xEditGridCell77.HeaderText = "患者名";
            this.xEditGridCell77.IsReadOnly = true;
            this.xEditGridCell77.Row = 1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "age";
            this.xEditGridCell78.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell78.CellWidth = 25;
            this.xEditGridCell78.Col = 5;
            this.xEditGridCell78.HeaderText = "年\r\n齢";
            this.xEditGridCell78.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell78.IsReadOnly = true;
            this.xEditGridCell78.MaxinumCipher = 3;
            this.xEditGridCell78.RowSpan = 2;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "sex";
            this.xEditGridCell79.CellWidth = 24;
            this.xEditGridCell79.Col = 6;
            this.xEditGridCell79.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell79.HeaderText = "性\r\n別";
            this.xEditGridCell79.IsReadOnly = true;
            this.xEditGridCell79.RowSpan = 2;
            this.xEditGridCell79.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell79.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell79.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'SEX\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellLen = 1200;
            this.xEditGridCell80.CellName = "sang";
            this.xEditGridCell80.CellWidth = 100;
            this.xEditGridCell80.Col = 7;
            this.xEditGridCell80.HeaderText = "病名";
            this.xEditGridCell80.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell80.RowSpan = 2;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellLen = 100;
            this.xEditGridCell81.CellName = "state1";
            this.xEditGridCell81.CellWidth = 120;
            this.xEditGridCell81.Col = 8;
            this.xEditGridCell81.HeaderText = "0:00～9:00";
            this.xEditGridCell81.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell81.Row = 1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellLen = 100;
            this.xEditGridCell82.CellName = "state2";
            this.xEditGridCell82.CellWidth = 120;
            this.xEditGridCell82.Col = 9;
            this.xEditGridCell82.HeaderText = "9:00～17:00";
            this.xEditGridCell82.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell82.Row = 1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellLen = 100;
            this.xEditGridCell83.CellName = "state3";
            this.xEditGridCell83.CellWidth = 120;
            this.xEditGridCell83.Col = 10;
            this.xEditGridCell83.HeaderText = "17:00～0:00";
            this.xEditGridCell83.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell83.Row = 1;
            // 
            // xGridHeader7
            // 
            this.xGridHeader7.Col = 3;
            this.xGridHeader7.ColSpan = 2;
            this.xGridHeader7.HeaderText = "患　者";
            this.xGridHeader7.HeaderWidth = 75;
            // 
            // xGridHeader8
            // 
            this.xGridHeader8.Col = 8;
            this.xGridHeader8.ColSpan = 3;
            this.xGridHeader8.HeaderText = "状態";
            this.xGridHeader8.HeaderWidth = 120;
            // 
            // xLabel14
            // 
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel14.Location = new System.Drawing.Point(0, 0);
            this.xLabel14.Name = "xLabel14";
            this.xLabel14.Size = new System.Drawing.Size(472, 21);
            this.xLabel14.TabIndex = 8;
            this.xLabel14.Text = "本日の要注意・重症";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdBedSore);
            this.xPanel3.Controls.Add(this.xLabel19);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.Location = new System.Drawing.Point(0, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(464, 265);
            this.xPanel3.TabIndex = 10;
            // 
            // grdBedSore
            // 
            this.grdBedSore.CallerID = 'B';
            this.grdBedSore.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell116});
            this.grdBedSore.ColPerLine = 5;
            this.grdBedSore.Cols = 5;
            this.grdBedSore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBedSore.FixedRows = 1;
            this.grdBedSore.FocusColumnName = "bunho";
            this.grdBedSore.HeaderHeights.Add(21);
            this.grdBedSore.Location = new System.Drawing.Point(0, 21);
            this.grdBedSore.Name = "grdBedSore";
            this.grdBedSore.Rows = 2;
            this.grdBedSore.Size = new System.Drawing.Size(464, 244);
            this.grdBedSore.TabIndex = 10;
            this.grdBedSore.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBedSore_QueryStarting);
            this.grdBedSore.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdBedSore.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdBedSore.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grd_GridFindClick);
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "ho_dong";
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.HeaderText = "ho_dong";
            this.xEditGridCell110.IsReadOnly = true;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "nur_wrdt";
            this.xEditGridCell111.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.HeaderText = "nur_wrdt";
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "ho_code";
            this.xEditGridCell112.CellWidth = 33;
            this.xEditGridCell112.HeaderText = "病室";
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "bunho";
            this.xEditGridCell113.CellWidth = 71;
            this.xEditGridCell113.Col = 1;
            this.xEditGridCell113.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell113.HeaderText = "患者番号";
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "suname";
            this.xEditGridCell114.CellWidth = 83;
            this.xEditGridCell114.Col = 2;
            this.xEditGridCell114.HeaderText = "患者名";
            this.xEditGridCell114.IsReadOnly = true;
            this.xEditGridCell114.IsUpdatable = false;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "from_date";
            this.xEditGridCell115.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell115.CellWidth = 86;
            this.xEditGridCell115.Col = 3;
            this.xEditGridCell115.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell115.HeaderText = "開始日";
            this.xEditGridCell115.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellLen = 500;
            this.xEditGridCell116.CellName = "buwi";
            this.xEditGridCell116.CellWidth = 174;
            this.xEditGridCell116.Col = 4;
            this.xEditGridCell116.HeaderText = "部位";
            // 
            // xLabel19
            // 
            this.xLabel19.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel19.EdgeRounding = false;
            this.xLabel19.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel19.Location = new System.Drawing.Point(0, 0);
            this.xLabel19.Name = "xLabel19";
            this.xLabel19.Size = new System.Drawing.Size(472, 21);
            this.xLabel19.TabIndex = 9;
            this.xLabel19.Text = "褥瘡患者";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.pnlLR);
            this.pnlLeft.Controls.Add(this.pnlLL);
            this.pnlLeft.Controls.Add(this.pnlNurCnt);
            this.pnlLeft.Controls.Add(this.pnlComment);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(401, 675);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlLR
            // 
            this.pnlLR.Controls.Add(this.pnlGwa);
            this.pnlLR.Controls.Add(this.pnlGuho);
            this.pnlLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLR.Location = new System.Drawing.Point(182, 0);
            this.pnlLR.Name = "pnlLR";
            this.pnlLR.Size = new System.Drawing.Size(217, 353);
            this.pnlLR.TabIndex = 5;
            // 
            // pnlGwa
            // 
            this.pnlGwa.Controls.Add(this.grdGwa);
            this.pnlGwa.Controls.Add(this.xLabel18);
            this.pnlGwa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGwa.Location = new System.Drawing.Point(0, 64);
            this.pnlGwa.Name = "pnlGwa";
            this.pnlGwa.Size = new System.Drawing.Size(217, 289);
            this.pnlGwa.TabIndex = 2;
            // 
            // grdGwa
            // 
            this.grdGwa.AddedHeaderLine = 1;
            this.grdGwa.CallerID = 'A';
            this.grdGwa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell95,
            this.xEditGridCell92,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell99});
            this.grdGwa.ColPerLine = 3;
            this.grdGwa.Cols = 3;
            this.grdGwa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGwa.FixedRows = 2;
            this.grdGwa.HeaderHeights.Add(21);
            this.grdGwa.HeaderHeights.Add(0);
            this.grdGwa.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader9});
            this.grdGwa.Location = new System.Drawing.Point(0, 21);
            this.grdGwa.Name = "grdGwa";
            this.grdGwa.Rows = 3;
            this.grdGwa.Size = new System.Drawing.Size(217, 268);
            this.grdGwa.TabIndex = 6;
            this.grdGwa.ToolTipActive = true;
            this.grdGwa.UseDefaultTransaction = false;
            this.grdGwa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGwa_QueryStarting);
            this.grdGwa.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdGwa.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdGwa_GridFindSelected);
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "nur_wrdt";
            this.xEditGridCell95.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.HeaderText = "日付";
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "ho_dong";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.HeaderText = "ho_dong";
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "gwa";
            this.xEditGridCell97.CellWidth = 28;
            this.xEditGridCell97.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell97.FindWorker = this.fwkGwa;
            this.xEditGridCell97.HeaderText = "gwa";
            this.xEditGridCell97.Row = 1;
            // 
            // fwkGwa
            // 
            this.fwkGwa.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkGwa.InputSQL = "SELECT A.GWA, A.GWA_NAME\r\n  FROM BAS0260 A\r\n WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP" +
                "_CODE() \r\n   AND A.BUSEO_GUBUN = \'1\'\r\n   AND A.IPWON_YN = \'Y\'\r\n ORDER BY A.GWA";
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "gwa";
            this.findColumnInfo3.HeaderText = "科コード";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "gwa_name";
            this.findColumnInfo4.HeaderText = "科名";
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "gwa_name";
            this.xEditGridCell98.CellWidth = 130;
            this.xEditGridCell98.Col = 1;
            this.xEditGridCell98.HeaderText = "診療科";
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.Row = 1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "pa_cnt";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell99.CellWidth = 57;
            this.xEditGridCell99.Col = 2;
            this.xEditGridCell99.HeaderText = "患者数";
            this.xEditGridCell99.MaxinumCipher = 4;
            this.xEditGridCell99.RowSpan = 2;
            // 
            // xGridHeader9
            // 
            this.xGridHeader9.ColSpan = 2;
            this.xGridHeader9.HeaderText = "診療科";
            // 
            // xLabel18
            // 
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel18.Location = new System.Drawing.Point(0, 0);
            this.xLabel18.Name = "xLabel18";
            this.xLabel18.Size = new System.Drawing.Size(217, 21);
            this.xLabel18.TabIndex = 5;
            this.xLabel18.Text = "　科別患者数";
            // 
            // pnlGuho
            // 
            this.pnlGuho.Controls.Add(this.grdGuhoGubun);
            this.pnlGuho.Controls.Add(this.xLabel9);
            this.pnlGuho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGuho.Location = new System.Drawing.Point(0, 0);
            this.pnlGuho.Name = "pnlGuho";
            this.pnlGuho.Size = new System.Drawing.Size(217, 64);
            this.pnlGuho.TabIndex = 1;
            // 
            // grdGuhoGubun
            // 
            this.grdGuhoGubun.CallerID = '2';
            this.grdGuhoGubun.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell1,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell90,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdGuhoGubun.ColPerLine = 3;
            this.grdGuhoGubun.Cols = 3;
            this.grdGuhoGubun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdGuhoGubun.FixedRows = 1;
            this.grdGuhoGubun.HeaderHeights.Add(21);
            this.grdGuhoGubun.Location = new System.Drawing.Point(0, 21);
            this.grdGuhoGubun.Name = "grdGuhoGubun";
            this.grdGuhoGubun.Rows = 2;
            this.grdGuhoGubun.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdGuhoGubun.Size = new System.Drawing.Size(217, 48);
            this.grdGuhoGubun.TabIndex = 3;
            this.grdGuhoGubun.ToolTipActive = true;
            this.grdGuhoGubun.UseDefaultTransaction = false;
            this.grdGuhoGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGuhoGubun_QueryStarting);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "stair";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "stair";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "stair_name";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "階";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "stair_total_cnt";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "各階総数";
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.MaxinumCipher = 4;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "nur_wrdt";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "日付";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "ho_dong";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "dansong_cnt";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.CellWidth = 71;
            this.xEditGridCell2.HeaderText = "担送";
            this.xEditGridCell2.MaxinumCipher = 4;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hosong_cnt";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 71;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderText = "護送";
            this.xEditGridCell3.MaxinumCipher = 4;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "dokbo_cnt";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.CellWidth = 71;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.HeaderText = "独歩";
            this.xEditGridCell4.MaxinumCipher = 4;
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel9.Location = new System.Drawing.Point(0, 0);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(217, 21);
            this.xLabel9.TabIndex = 25;
            this.xLabel9.Text = "　護送区分";
            // 
            // pnlLL
            // 
            this.pnlLL.Controls.Add(this.pnlGamyum);
            this.pnlLL.Controls.Add(this.pnlPatient);
            this.pnlLL.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLL.Location = new System.Drawing.Point(0, 0);
            this.pnlLL.Name = "pnlLL";
            this.pnlLL.Size = new System.Drawing.Size(182, 353);
            this.pnlLL.TabIndex = 4;
            // 
            // pnlGamyum
            // 
            this.pnlGamyum.Controls.Add(this.xLabel8);
            this.pnlGamyum.Controls.Add(this.emkGamyum2);
            this.pnlGamyum.Controls.Add(this.xLabel28);
            this.pnlGamyum.Controls.Add(this.emkGamyum3);
            this.pnlGamyum.Controls.Add(this.xLabel20);
            this.pnlGamyum.Controls.Add(this.emkGamyum5);
            this.pnlGamyum.Controls.Add(this.txtGamyum6);
            this.pnlGamyum.Controls.Add(this.xLabel26);
            this.pnlGamyum.Controls.Add(this.emkGamyum4);
            this.pnlGamyum.Controls.Add(this.emkGamyum1);
            this.pnlGamyum.Controls.Add(this.xLabel17);
            this.pnlGamyum.Controls.Add(this.xLabel34);
            this.pnlGamyum.Controls.Add(this.emkGamyum6);
            this.pnlGamyum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGamyum.Location = new System.Drawing.Point(0, 156);
            this.pnlGamyum.Name = "pnlGamyum";
            this.pnlGamyum.Size = new System.Drawing.Size(182, 197);
            this.pnlGamyum.TabIndex = 3;
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel8.Location = new System.Drawing.Point(1, 0);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(182, 21);
            this.xLabel8.TabIndex = 3;
            this.xLabel8.Text = "　感染症";
            // 
            // emkGamyum2
            // 
            this.emkGamyum2.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkGamyum2.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkGamyum2.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkGamyum2.Location = new System.Drawing.Point(91, 53);
            this.emkGamyum2.MaxinumCipher = 3;
            this.emkGamyum2.MaxLength = 4;
            this.emkGamyum2.Name = "emkGamyum2";
            this.emkGamyum2.Size = new System.Drawing.Size(85, 22);
            this.emkGamyum2.TabIndex = 1;
            this.emkGamyum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xLabel28
            // 
            this.xLabel28.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel28.EdgeRounding = false;
            this.xLabel28.Location = new System.Drawing.Point(7, 53);
            this.xLabel28.Name = "xLabel28";
            this.xLabel28.Size = new System.Drawing.Size(79, 22);
            this.xLabel28.TabIndex = 15;
            this.xLabel28.Text = "HBs";
            this.xLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emkGamyum3
            // 
            this.emkGamyum3.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkGamyum3.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkGamyum3.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkGamyum3.Location = new System.Drawing.Point(91, 82);
            this.emkGamyum3.MaxinumCipher = 3;
            this.emkGamyum3.MaxLength = 4;
            this.emkGamyum3.Name = "emkGamyum3";
            this.emkGamyum3.Size = new System.Drawing.Size(85, 22);
            this.emkGamyum3.TabIndex = 2;
            this.emkGamyum3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xLabel20
            // 
            this.xLabel20.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel20.EdgeRounding = false;
            this.xLabel20.Location = new System.Drawing.Point(7, 111);
            this.xLabel20.Name = "xLabel20";
            this.xLabel20.Size = new System.Drawing.Size(79, 22);
            this.xLabel20.TabIndex = 9;
            this.xLabel20.Text = "MRSA";
            this.xLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emkGamyum5
            // 
            this.emkGamyum5.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkGamyum5.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkGamyum5.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkGamyum5.Location = new System.Drawing.Point(91, 140);
            this.emkGamyum5.MaxinumCipher = 3;
            this.emkGamyum5.MaxLength = 4;
            this.emkGamyum5.Name = "emkGamyum5";
            this.emkGamyum5.Size = new System.Drawing.Size(85, 22);
            this.emkGamyum5.TabIndex = 4;
            this.emkGamyum5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGamyum6
            // 
            this.txtGamyum6.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.txtGamyum6.Location = new System.Drawing.Point(7, 169);
            this.txtGamyum6.MaxLength = 30;
            this.txtGamyum6.Name = "txtGamyum6";
            this.txtGamyum6.Size = new System.Drawing.Size(79, 22);
            this.txtGamyum6.TabIndex = 5;
            this.txtGamyum6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel26
            // 
            this.xLabel26.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel26.EdgeRounding = false;
            this.xLabel26.Location = new System.Drawing.Point(7, 140);
            this.xLabel26.Name = "xLabel26";
            this.xLabel26.Size = new System.Drawing.Size(79, 22);
            this.xLabel26.TabIndex = 18;
            this.xLabel26.Text = "緑膿菌";
            this.xLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emkGamyum4
            // 
            this.emkGamyum4.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkGamyum4.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkGamyum4.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkGamyum4.Location = new System.Drawing.Point(91, 111);
            this.emkGamyum4.MaxinumCipher = 3;
            this.emkGamyum4.MaxLength = 4;
            this.emkGamyum4.Name = "emkGamyum4";
            this.emkGamyum4.Size = new System.Drawing.Size(85, 22);
            this.emkGamyum4.TabIndex = 3;
            this.emkGamyum4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // emkGamyum1
            // 
            this.emkGamyum1.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkGamyum1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkGamyum1.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkGamyum1.Location = new System.Drawing.Point(91, 24);
            this.emkGamyum1.MaxinumCipher = 3;
            this.emkGamyum1.MaxLength = 4;
            this.emkGamyum1.Name = "emkGamyum1";
            this.emkGamyum1.Size = new System.Drawing.Size(85, 22);
            this.emkGamyum1.TabIndex = 0;
            this.emkGamyum1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xLabel17
            // 
            this.xLabel17.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel17.EdgeRounding = false;
            this.xLabel17.Location = new System.Drawing.Point(7, 24);
            this.xLabel17.Name = "xLabel17";
            this.xLabel17.Size = new System.Drawing.Size(79, 22);
            this.xLabel17.TabIndex = 6;
            this.xLabel17.Text = "TPHA";
            this.xLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel34
            // 
            this.xLabel34.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel34.EdgeRounding = false;
            this.xLabel34.Location = new System.Drawing.Point(7, 82);
            this.xLabel34.Name = "xLabel34";
            this.xLabel34.Size = new System.Drawing.Size(79, 22);
            this.xLabel34.TabIndex = 24;
            this.xLabel34.Text = "HCV";
            this.xLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emkGamyum6
            // 
            this.emkGamyum6.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkGamyum6.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkGamyum6.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkGamyum6.Location = new System.Drawing.Point(91, 169);
            this.emkGamyum6.MaxinumCipher = 3;
            this.emkGamyum6.MaxLength = 4;
            this.emkGamyum6.Name = "emkGamyum6";
            this.emkGamyum6.Size = new System.Drawing.Size(85, 22);
            this.emkGamyum6.TabIndex = 6;
            this.emkGamyum6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlPatient
            // 
            this.pnlPatient.Controls.Add(this.xLabel24);
            this.pnlPatient.Controls.Add(this.xLabel3);
            this.pnlPatient.Controls.Add(this.xLabel4);
            this.pnlPatient.Controls.Add(this.emkMoveIn);
            this.pnlPatient.Controls.Add(this.xLabel5);
            this.pnlPatient.Controls.Add(this.xLabel7);
            this.pnlPatient.Controls.Add(this.xLabel6);
            this.pnlPatient.Controls.Add(this.emkJaewon);
            this.pnlPatient.Controls.Add(this.emkToiwon);
            this.pnlPatient.Controls.Add(this.emkMoveOut);
            this.pnlPatient.Controls.Add(this.emkIpwon);
            this.pnlPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatient.Location = new System.Drawing.Point(0, 0);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Size = new System.Drawing.Size(182, 156);
            this.pnlPatient.TabIndex = 0;
            // 
            // xLabel24
            // 
            this.xLabel24.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel24.EdgeRounding = false;
            this.xLabel24.Location = new System.Drawing.Point(7, 101);
            this.xLabel24.Name = "xLabel24";
            this.xLabel24.Size = new System.Drawing.Size(81, 22);
            this.xLabel24.TabIndex = 12;
            this.xLabel24.Text = "転　入";
            this.xLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel3.Location = new System.Drawing.Point(0, 0);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(182, 21);
            this.xLabel3.TabIndex = 0;
            this.xLabel3.Text = "　病床使用状況";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Location = new System.Drawing.Point(7, 76);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(81, 22);
            this.xLabel4.TabIndex = 10;
            this.xLabel4.Text = "転　棟";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emkMoveIn
            // 
            this.emkMoveIn.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkMoveIn.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkMoveIn.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkMoveIn.Location = new System.Drawing.Point(91, 101);
            this.emkMoveIn.MaxLength = 4;
            this.emkMoveIn.Name = "emkMoveIn";
            this.emkMoveIn.Size = new System.Drawing.Size(85, 22);
            this.emkMoveIn.TabIndex = 11;
            this.emkMoveIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Location = new System.Drawing.Point(7, 24);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(81, 22);
            this.xLabel5.TabIndex = 4;
            this.xLabel5.Text = "入　院";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Location = new System.Drawing.Point(7, 127);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(81, 22);
            this.xLabel7.TabIndex = 8;
            this.xLabel7.Text = "総患者数";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Location = new System.Drawing.Point(7, 50);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(81, 22);
            this.xLabel6.TabIndex = 6;
            this.xLabel6.Text = "退　院";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emkJaewon
            // 
            this.emkJaewon.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkJaewon.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkJaewon.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkJaewon.Location = new System.Drawing.Point(91, 127);
            this.emkJaewon.MaxLength = 4;
            this.emkJaewon.Name = "emkJaewon";
            this.emkJaewon.Size = new System.Drawing.Size(85, 22);
            this.emkJaewon.TabIndex = 6;
            this.emkJaewon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // emkToiwon
            // 
            this.emkToiwon.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkToiwon.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkToiwon.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkToiwon.Location = new System.Drawing.Point(91, 50);
            this.emkToiwon.MaxLength = 4;
            this.emkToiwon.Name = "emkToiwon";
            this.emkToiwon.Size = new System.Drawing.Size(85, 22);
            this.emkToiwon.TabIndex = 5;
            this.emkToiwon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // emkMoveOut
            // 
            this.emkMoveOut.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkMoveOut.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkMoveOut.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkMoveOut.Location = new System.Drawing.Point(91, 76);
            this.emkMoveOut.MaxLength = 4;
            this.emkMoveOut.Name = "emkMoveOut";
            this.emkMoveOut.Size = new System.Drawing.Size(85, 22);
            this.emkMoveOut.TabIndex = 9;
            this.emkMoveOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // emkIpwon
            // 
            this.emkIpwon.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkIpwon.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.emkIpwon.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkIpwon.Location = new System.Drawing.Point(91, 24);
            this.emkIpwon.MaxLength = 4;
            this.emkIpwon.Name = "emkIpwon";
            this.emkIpwon.Size = new System.Drawing.Size(85, 22);
            this.emkIpwon.TabIndex = 4;
            this.emkIpwon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlNurCnt
            // 
            this.pnlNurCnt.Controls.Add(this.grdNURCnt);
            this.pnlNurCnt.Controls.Add(this.grdNurse);
            this.pnlNurCnt.Controls.Add(this.xLabel16);
            this.pnlNurCnt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNurCnt.Location = new System.Drawing.Point(0, 353);
            this.pnlNurCnt.Name = "pnlNurCnt";
            this.pnlNurCnt.Size = new System.Drawing.Size(399, 168);
            this.pnlNurCnt.TabIndex = 8;
            // 
            // grdNURCnt
            // 
            this.grdNURCnt.CallerID = '5';
            this.grdNURCnt.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell96,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell122,
            this.xEditGridCell109});
            this.grdNURCnt.ColPerLine = 11;
            this.grdNURCnt.Cols = 11;
            this.grdNURCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNURCnt.FixedRows = 1;
            this.grdNURCnt.HeaderHeights.Add(32);
            this.grdNURCnt.Location = new System.Drawing.Point(0, 21);
            this.grdNURCnt.Name = "grdNURCnt";
            this.grdNURCnt.QuerySQL = resources.GetString("grdNURCnt.QuerySQL");
            this.grdNURCnt.Rows = 2;
            this.grdNURCnt.Size = new System.Drawing.Size(399, 147);
            this.grdNURCnt.TabIndex = 8;
            this.grdNURCnt.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNURCnt_QueryEnd);
            this.grdNURCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNURCnt_QueryStarting);
            this.grdNURCnt.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdNURCnt.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNURCnt_GridColumnChanged);
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "nur_wrdt";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.HeaderText = "nur_wrdt";
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "ho_dong";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.HeaderText = "ho_dong";
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "nur_grade";
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.HeaderText = "NUR_GRADE";
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "nur_grade_name";
            this.xEditGridCell100.CellWidth = 70;
            this.xEditGridCell100.HeaderText = "区分";
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellLen = 4;
            this.xEditGridCell101.CellName = "dawn_cnt";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell101.CellWidth = 33;
            this.xEditGridCell101.Col = 1;
            this.xEditGridCell101.DecimalDigits = 1;
            this.xEditGridCell101.HeaderText = "夜明";
            this.xEditGridCell101.InitValue = "0";
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellLen = 4;
            this.xEditGridCell102.CellName = "day_cnt";
            this.xEditGridCell102.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell102.CellWidth = 33;
            this.xEditGridCell102.Col = 2;
            this.xEditGridCell102.DecimalDigits = 1;
            this.xEditGridCell102.DecimalPlaces = 1;
            this.xEditGridCell102.HeaderText = "日勤";
            this.xEditGridCell102.InitValue = "0";
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellLen = 4;
            this.xEditGridCell103.CellName = "night_cnt";
            this.xEditGridCell103.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell103.CellWidth = 33;
            this.xEditGridCell103.Col = 3;
            this.xEditGridCell103.DecimalDigits = 1;
            this.xEditGridCell103.HeaderText = "夜入";
            this.xEditGridCell103.InitValue = "0";
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellLen = 4;
            this.xEditGridCell104.CellName = "holi_cnt";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell104.CellWidth = 33;
            this.xEditGridCell104.Col = 4;
            this.xEditGridCell104.DecimalDigits = 1;
            this.xEditGridCell104.HeaderText = "公休";
            this.xEditGridCell104.InitValue = "0";
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellLen = 4;
            this.xEditGridCell105.CellName = "pay_cnt";
            this.xEditGridCell105.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell105.CellWidth = 33;
            this.xEditGridCell105.Col = 5;
            this.xEditGridCell105.DecimalDigits = 1;
            this.xEditGridCell105.HeaderText = "有休";
            this.xEditGridCell105.InitValue = "0";
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellLen = 4;
            this.xEditGridCell106.CellName = "childcare_cnt";
            this.xEditGridCell106.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell106.CellWidth = 33;
            this.xEditGridCell106.Col = 6;
            this.xEditGridCell106.DecimalDigits = 1;
            this.xEditGridCell106.HeaderText = "産･育";
            this.xEditGridCell106.InitValue = "0";
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellLen = 4;
            this.xEditGridCell107.CellName = "special_cnt";
            this.xEditGridCell107.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell107.CellWidth = 33;
            this.xEditGridCell107.Col = 7;
            this.xEditGridCell107.DecimalDigits = 1;
            this.xEditGridCell107.HeaderText = "特休";
            this.xEditGridCell107.InitValue = "0";
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellLen = 4;
            this.xEditGridCell108.CellName = "study_cnt";
            this.xEditGridCell108.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell108.CellWidth = 33;
            this.xEditGridCell108.Col = 8;
            this.xEditGridCell108.DecimalDigits = 1;
            this.xEditGridCell108.HeaderText = "研･出";
            this.xEditGridCell108.InitValue = "0";
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellLen = 4;
            this.xEditGridCell122.CellName = "absence_cnt";
            this.xEditGridCell122.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell122.CellWidth = 33;
            this.xEditGridCell122.Col = 9;
            this.xEditGridCell122.DecimalDigits = 1;
            this.xEditGridCell122.HeaderText = "欠勤";
            this.xEditGridCell122.InitValue = "0";
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellLen = 5;
            this.xEditGridCell109.CellName = "total_cnt";
            this.xEditGridCell109.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell109.CellWidth = 28;
            this.xEditGridCell109.Col = 10;
            this.xEditGridCell109.DecimalDigits = 1;
            this.xEditGridCell109.HeaderText = "計";
            this.xEditGridCell109.InitValue = "0";
            this.xEditGridCell109.IsReadOnly = true;
            // 
            // grdNurse
            // 
            this.grdNurse.AddedHeaderLine = 1;
            this.grdNurse.CallerID = 'Z';
            this.grdNurse.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell20,
            this.xEditGridCell67,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26});
            this.grdNurse.ColPerLine = 4;
            this.grdNurse.Cols = 5;
            this.grdNurse.FixedCols = 1;
            this.grdNurse.FixedRows = 2;
            this.grdNurse.HeaderHeights.Add(21);
            this.grdNurse.HeaderHeights.Add(0);
            this.grdNurse.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdNurse.Location = new System.Drawing.Point(28, 167);
            this.grdNurse.Name = "grdNurse";
            this.grdNurse.QuerySQL = resources.GetString("grdNurse.QuerySQL");
            this.grdNurse.RowHeaderVisible = true;
            this.grdNurse.Rows = 3;
            this.grdNurse.Size = new System.Drawing.Size(351, 114);
            this.grdNurse.TabIndex = 7;
            this.grdNurse.ToolTipActive = true;
            this.grdNurse.UseDefaultTransaction = false;
            this.grdNurse.Visible = false;
            this.grdNurse.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNurse_QueryStarting);
            this.grdNurse.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdNurse.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdNurse_GridFindSelected);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "nur_wrdt";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "勤務日付";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "ho_dong";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.HeaderText = "ho_dong";
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "nurse_grade";
            this.xEditGridCell21.CellWidth = 68;
            this.xEditGridCell21.Col = 1;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell21.HeaderText = "区分";
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell21.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'NURSE_GRADE\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "work_type";
            this.xEditGridCell22.CellWidth = 60;
            this.xEditGridCell22.Col = 2;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell22.HeaderText = "勤務区分";
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell22.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'WORK_TYPE_IN\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "nurse_id";
            this.xEditGridCell23.CellWidth = 88;
            this.xEditGridCell23.Col = 3;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell23.FindWorker = this.fwkNurse;
            this.xEditGridCell23.HeaderText = "nurse_id";
            this.xEditGridCell23.Row = 1;
            // 
            // fwkNurse
            // 
            this.fwkNurse.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkNurse.FormText = "看護師";
            this.fwkNurse.InputSQL = resources.GetString("fwkNurse.InputSQL");
            this.fwkNurse.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkNurse_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "sabun";
            this.findColumnInfo1.ColWidth = 104;
            this.findColumnInfo1.HeaderText = "看護師ID";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sabun_name";
            this.findColumnInfo2.ColWidth = 194;
            this.findColumnInfo2.HeaderText = "看護師名";
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 30;
            this.xEditGridCell24.CellName = "nurse_name";
            this.xEditGridCell24.CellWidth = 151;
            this.xEditGridCell24.Col = 4;
            this.xEditGridCell24.HeaderText = "看護師名";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.Row = 1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "nurse_grade_name";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "nurse_grade_name";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "work_type_name";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.HeaderText = "work_type_name";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 3;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "看護師";
            this.xGridHeader1.HeaderWidth = 88;
            // 
            // xLabel16
            // 
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel16.Location = new System.Drawing.Point(0, 0);
            this.xLabel16.Name = "xLabel16";
            this.xLabel16.Size = new System.Drawing.Size(399, 21);
            this.xLabel16.TabIndex = 6;
            this.xLabel16.Text = "　職員勤務状況";
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.grdComment);
            this.pnlComment.Controls.Add(this.xLabel15);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(0, 521);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(399, 152);
            this.pnlComment.TabIndex = 2;
            // 
            // grdComment
            // 
            this.grdComment.CallerID = '4';
            this.grdComment.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell17,
            this.xEditGridCell68,
            this.xEditGridCell18,
            this.xEditGridCell19});
            this.grdComment.ColHeaderVisible = false;
            this.grdComment.ColPerLine = 1;
            this.grdComment.Cols = 2;
            this.grdComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdComment.FixedCols = 1;
            this.grdComment.FixedRows = 1;
            this.grdComment.HeaderHeights.Add(21);
            this.grdComment.Location = new System.Drawing.Point(0, 21);
            this.grdComment.Name = "grdComment";
            this.grdComment.QuerySQL = "SELECT COMMENT_DATE\r\n     , HO_DONG\r\n     , REMARK\r\n     , SEQ\r\n  FROM NUR5025\r\n " +
                "WHERE HOSP_CODE = :f_hosp_code\r\n   AND HO_DONG   = :f_ho_dong\r\n   AND COMMENT_DA" +
                "TE = :f_date\r\n ORDER BY SEQ";
            this.grdComment.RowHeaderVisible = true;
            this.grdComment.Rows = 2;
            this.grdComment.Size = new System.Drawing.Size(399, 131);
            this.grdComment.TabIndex = 6;
            this.grdComment.UseDefaultTransaction = false;
            this.grdComment.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdComment_QueryStarting);
            this.grdComment.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "nur_wrdt";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "ho_dong";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.HeaderText = "ho_dong";
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellLen = 135;
            this.xEditGridCell18.CellName = "comment";
            this.xEditGridCell18.CellWidth = 353;
            this.xEditGridCell18.Col = 1;
            this.xEditGridCell18.HeaderText = "特記事項";
            this.xEditGridCell18.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "seq";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xLabel15
            // 
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel15.Location = new System.Drawing.Point(0, 0);
            this.xLabel15.Name = "xLabel15";
            this.xLabel15.Size = new System.Drawing.Size(399, 21);
            this.xLabel15.TabIndex = 5;
            this.xLabel15.Text = "特記事項";
            // 
            // layTotalCnt
            // 
            this.layTotalCnt.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4,
            this.singleLayoutItem29,
            this.singleLayoutItem30});
            this.layTotalCnt.QuerySQL = resources.GetString("layTotalCnt.QuerySQL");
            this.layTotalCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTotalCnt_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "emkYesterDay";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "emkIpwon";
            this.singleLayoutItem2.IsUpdItem = true;
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "emkToiwon";
            this.singleLayoutItem3.IsUpdItem = true;
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "emkJaewon";
            this.singleLayoutItem4.IsUpdItem = true;
            // 
            // singleLayoutItem29
            // 
            this.singleLayoutItem29.DataName = "emkMoveIn";
            // 
            // singleLayoutItem30
            // 
            this.singleLayoutItem30.DataName = "emkMoveOut";
            // 
            // layStairCnt
            // 
            this.layStairCnt.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem39});
            this.layStairCnt.QuerySQL = resources.GetString("layStairCnt.QuerySQL");
            this.layStairCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layStairCnt_QueryStarting);
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "dansong";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "hosong";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "dokbo";
            // 
            // singleLayoutItem39
            // 
            this.singleLayoutItem39.DataName = "stair_total_cnt";
            // 
            // layGamyumCnt
            // 
            this.layGamyumCnt.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem11,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17,
            this.singleLayoutItem18});
            this.layGamyumCnt.QuerySQL = resources.GetString("layGamyumCnt.QuerySQL");
            this.layGamyumCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layGamyumCnt_QueryStarting);
            this.layGamyumCnt.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layGamyumCnt_QueryEnd);
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "gamyum_cnt1";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "gamyum_cnt2";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "gamyum_cnt3";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "gamyum_cnt4";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "gamyum_cnt5";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "gamyum_cnt6";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "gamyum_cnt7";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.DataName = "gamyum_cnt8";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "txtGamyum6";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.DataName = "txtGamyum7";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "txtGamyum8";
            // 
            // layConfirm_yn
            // 
            this.layConfirm_yn.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem37});
            this.layConfirm_yn.QuerySQL = resources.GetString("layConfirm_yn.QuerySQL");
            this.layConfirm_yn.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layConfirm_yn_QueryStarting);
            this.layConfirm_yn.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layConfirm_yn_QueryEnd);
            // 
            // singleLayoutItem37
            // 
            this.singleLayoutItem37.DataName = "confirm_yn";
            // 
            // layPatientInfo_in
            // 
            this.layPatientInfo_in.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem32,
            this.singleLayoutItem40,
            this.singleLayoutItem41,
            this.singleLayoutItem42,
            this.singleLayoutItem43,
            this.singleLayoutItem44,
            this.singleLayoutItem51});
            this.layPatientInfo_in.QuerySQL = resources.GetString("layPatientInfo_in.QuerySQL");
            this.layPatientInfo_in.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPaitientInfo_QueryStarting);
            // 
            // singleLayoutItem32
            // 
            this.singleLayoutItem32.DataName = "ho_dong";
            // 
            // singleLayoutItem40
            // 
            this.singleLayoutItem40.DataName = "ho_code";
            // 
            // singleLayoutItem41
            // 
            this.singleLayoutItem41.DataName = "suname";
            // 
            // singleLayoutItem42
            // 
            this.singleLayoutItem42.DataName = "age";
            // 
            // singleLayoutItem43
            // 
            this.singleLayoutItem43.DataName = "sex";
            // 
            // singleLayoutItem44
            // 
            this.singleLayoutItem44.DataName = "sang";
            // 
            // singleLayoutItem51
            // 
            this.singleLayoutItem51.DataName = "gwa";
            // 
            // layPatientInfo_out
            // 
            this.layPatientInfo_out.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem33,
            this.singleLayoutItem45,
            this.singleLayoutItem46,
            this.singleLayoutItem47,
            this.singleLayoutItem48,
            this.singleLayoutItem49,
            this.singleLayoutItem50});
            this.layPatientInfo_out.QuerySQL = resources.GetString("layPatientInfo_out.QuerySQL");
            this.layPatientInfo_out.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPaitientInfo_QueryStarting);
            // 
            // singleLayoutItem33
            // 
            this.singleLayoutItem33.DataName = "ho_dong";
            // 
            // singleLayoutItem45
            // 
            this.singleLayoutItem45.DataName = "ho_code";
            // 
            // singleLayoutItem46
            // 
            this.singleLayoutItem46.DataName = "suname";
            // 
            // singleLayoutItem47
            // 
            this.singleLayoutItem47.DataName = "age";
            // 
            // singleLayoutItem48
            // 
            this.singleLayoutItem48.DataName = "sex";
            // 
            // singleLayoutItem49
            // 
            this.singleLayoutItem49.DataName = "sang";
            // 
            // singleLayoutItem50
            // 
            this.singleLayoutItem50.DataName = "gwa";
            // 
            // layNur5020
            // 
            this.layNur5020.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem54,
            this.multiLayoutItem55});
            this.layNur5020.QuerySQL = resources.GetString("layNur5020.QuerySQL");
            this.layNur5020.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNur5020_QueryStarting);
            this.layNur5020.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layNur5020_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "yesterday_cnt";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "ipwon_cnt";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "toiwon_cnt";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "jaewon_cnt";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "move_out_cnt";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "move_in_cnt";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "gamyum1_cnt";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "gamyum2_cnt";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "gamyum3_cnt";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "gamyum4_cnt";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "gamyum5_cnt";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "gamyum6_cnt";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "gamyum7_cnt";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "gamyum8_cnt";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "gamyum6_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "gamyum7_name";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "gamyum8_name";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "nurse";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "nurse_name";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "yokchang_comment";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "nur_wrdt";
            this.multiLayoutItem41.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "nur_wrdt_jpn";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "ho_dong";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "ho_dong_name";
            // 
            // layNur5020Save
            // 
            this.layNur5020Save.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem19,
            this.singleLayoutItem20,
            this.singleLayoutItem21,
            this.singleLayoutItem22,
            this.singleLayoutItem60,
            this.singleLayoutItem61,
            this.singleLayoutItem23,
            this.singleLayoutItem24,
            this.singleLayoutItem25,
            this.singleLayoutItem26,
            this.singleLayoutItem27,
            this.singleLayoutItem28,
            this.singleLayoutItem31,
            this.singleLayoutItem34,
            this.singleLayoutItem35,
            this.singleLayoutItem36,
            this.singleLayoutItem38});
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "yesterday_cnt";
            this.singleLayoutItem19.IsUpdItem = true;
            // 
            // singleLayoutItem20
            // 
            this.singleLayoutItem20.BindControl = this.emkIpwon;
            this.singleLayoutItem20.DataName = "ipwon_cnt";
            this.singleLayoutItem20.IsUpdItem = true;
            // 
            // singleLayoutItem21
            // 
            this.singleLayoutItem21.BindControl = this.emkToiwon;
            this.singleLayoutItem21.DataName = "toiwon_cnt";
            this.singleLayoutItem21.IsUpdItem = true;
            // 
            // singleLayoutItem22
            // 
            this.singleLayoutItem22.BindControl = this.emkJaewon;
            this.singleLayoutItem22.DataName = "jaewon_cnt";
            this.singleLayoutItem22.IsUpdItem = true;
            // 
            // singleLayoutItem60
            // 
            this.singleLayoutItem60.BindControl = this.emkMoveIn;
            this.singleLayoutItem60.DataName = "move_in_cnt";
            this.singleLayoutItem60.IsUpdItem = true;
            // 
            // singleLayoutItem61
            // 
            this.singleLayoutItem61.BindControl = this.emkMoveOut;
            this.singleLayoutItem61.DataName = "move_out_cnt";
            this.singleLayoutItem61.IsUpdItem = true;
            // 
            // singleLayoutItem23
            // 
            this.singleLayoutItem23.BindControl = this.emkGamyum1;
            this.singleLayoutItem23.DataName = "gamyum1_cnt";
            this.singleLayoutItem23.IsUpdItem = true;
            // 
            // singleLayoutItem24
            // 
            this.singleLayoutItem24.BindControl = this.emkGamyum2;
            this.singleLayoutItem24.DataName = "gamyum2_cnt";
            this.singleLayoutItem24.IsUpdItem = true;
            // 
            // singleLayoutItem25
            // 
            this.singleLayoutItem25.BindControl = this.emkGamyum3;
            this.singleLayoutItem25.DataName = "gamyum3_cnt";
            this.singleLayoutItem25.IsUpdItem = true;
            // 
            // singleLayoutItem26
            // 
            this.singleLayoutItem26.BindControl = this.emkGamyum4;
            this.singleLayoutItem26.DataName = "gamyum4_cnt";
            this.singleLayoutItem26.IsUpdItem = true;
            // 
            // singleLayoutItem27
            // 
            this.singleLayoutItem27.BindControl = this.emkGamyum5;
            this.singleLayoutItem27.DataName = "gamyum5_cnt";
            this.singleLayoutItem27.IsUpdItem = true;
            // 
            // singleLayoutItem28
            // 
            this.singleLayoutItem28.BindControl = this.emkGamyum6;
            this.singleLayoutItem28.DataName = "gamyum6_cnt";
            this.singleLayoutItem28.IsUpdItem = true;
            // 
            // singleLayoutItem31
            // 
            this.singleLayoutItem31.BindControl = this.txtGamyum6;
            this.singleLayoutItem31.DataName = "gamyum6_name";
            this.singleLayoutItem31.IsUpdItem = true;
            // 
            // singleLayoutItem34
            // 
            this.singleLayoutItem34.DataName = "nurse";
            this.singleLayoutItem34.IsUpdItem = true;
            // 
            // singleLayoutItem35
            // 
            this.singleLayoutItem35.DataName = "yokchang_comment";
            this.singleLayoutItem35.IsUpdItem = true;
            // 
            // singleLayoutItem36
            // 
            this.singleLayoutItem36.BindControl = this.cboBuseo;
            this.singleLayoutItem36.DataName = "ho_dong";
            this.singleLayoutItem36.IsUpdItem = true;
            // 
            // singleLayoutItem38
            // 
            this.singleLayoutItem38.BindControl = this.dtpDate;
            this.singleLayoutItem38.DataName = "nur_wrdt";
            this.singleLayoutItem38.IsUpdItem = true;
            // 
            // layNurCnt
            // 
            this.layNurCnt.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem33,
            this.multiLayoutItem34});
            this.layNurCnt.QuerySQL = resources.GetString("layNurCnt.QuerySQL");
            this.layNurCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNurCnt_QueryStarting);
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "nurse_grade_name";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "early_cnt";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "day_cnt";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "late_cnt";
            this.multiLayoutItem24.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "night_cnt";
            this.multiLayoutItem25.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "holy_cnt";
            this.multiLayoutItem33.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "vac_cnt";
            this.multiLayoutItem34.DataType = IHIS.Framework.DataType.Number;
            // 
            // layPatientInfo
            // 
            this.layPatientInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem52,
            this.singleLayoutItem53,
            this.singleLayoutItem54,
            this.singleLayoutItem55,
            this.singleLayoutItem56,
            this.singleLayoutItem57});
            this.layPatientInfo.QuerySQL = resources.GetString("layPatientInfo.QuerySQL");
            this.layPatientInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPaitientInfo_QueryStarting);
            // 
            // singleLayoutItem52
            // 
            this.singleLayoutItem52.DataName = "ho_code";
            // 
            // singleLayoutItem53
            // 
            this.singleLayoutItem53.DataName = "suname";
            // 
            // singleLayoutItem54
            // 
            this.singleLayoutItem54.DataName = "age";
            // 
            // singleLayoutItem55
            // 
            this.singleLayoutItem55.DataName = "sex";
            // 
            // singleLayoutItem56
            // 
            this.singleLayoutItem56.DataName = "sang";
            // 
            // singleLayoutItem57
            // 
            this.singleLayoutItem57.DataName = "gwa";
            // 
            // NUR5020U00
            // 
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR5020U00";
            this.Size = new System.Drawing.Size(1404, 742);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBuseo)).EndInit();
            this.pnlWoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWoi)).EndInit();
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.pnlTrans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTrans)).EndInit();
            this.pnlIpToi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIpToi)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlSusul.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSusul)).EndInit();
            this.pnlWatchList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWatchList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBedSore)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLR.ResumeLayout(false);
            this.pnlGwa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGwa)).EndInit();
            this.pnlGuho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGuhoGubun)).EndInit();
            this.pnlLL.ResumeLayout(false);
            this.pnlGamyum.ResumeLayout(false);
            this.pnlGamyum.PerformLayout();
            this.pnlPatient.ResumeLayout(false);
            this.pnlPatient.PerformLayout();
            this.pnlNurCnt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNURCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNurse)).EndInit();
            this.pnlComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNur5020)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNurCnt)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            
            this.layNur5020Save.SavePerformer = new XSavePerformer(this);
            this.grdGuhoGubun.SavePerformer = this.layNur5020Save.SavePerformer;
            this.grdWoi.SavePerformer = this.layNur5020Save.SavePerformer;
            this.grdComment.SavePerformer = this.layNur5020Save.SavePerformer;
            //this.grdNurse.SavePerformer = this.layNur5020Save.SavePerformer;
            this.grdNURCnt.SavePerformer = this.layNur5020Save.SavePerformer;
            this.grdIpToi.SavePerformer = this.layNur5020Save.SavePerformer;
            this.grdTrans.SavePerformer = this.layNur5020Save.SavePerformer;
            this.grdSusul.SavePerformer = this.layNur5020Save.SavePerformer;
            this.grdWatchList.SavePerformer = this.layNur5020Save.SavePerformer;
            this.grdGwa.SavePerformer = this.layNur5020Save.SavePerformer;
            this.grdBedSore.SavePerformer = this.layNur5020Save.SavePerformer;

            // 마감을 저녁 12시에 하기 때문에 그에 대한 추가 내용은 다음날 작성한다.
            // 따라서 기준일은 작성 시점의 하루 전날이 된다. 
            this.dtpDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(-1));
            
            if (!TypeCheck.IsNull(UserInfo.HoDong))
                this.cboBuseo.SetDataValue(UserInfo.HoDong);
            else
                this.cboBuseo.SetDataValue("1");

            QueryAll();
		}

		#endregion

		#region 타Screen에서 Open (Command)	
		public override object Command(string command, CommonItemCollection commandParam)
		{
            switch (command)
            {
                case "OUT0101":

                    #region 환자검색후

                    try
                    {
                        //this.mPBGrid.SetFocusToItem(this.mPBGrid.CurrentRowNumber, "bunho");
                        this.mPBGrid.SetItemValue(this.mPBGrid.CurrentRowNumber, "bunho", ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["bunho"]);
                        
                        int rowNum = this.mPBGrid.CurrentRowNumber;
                        grd_GridColumnChanged(this.mPBGrid, new GridColumnChangedEventArgs(rowNum, "bunho", this.mPBGrid.LayoutTable.Rows[rowNum], ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["bunho"]));
                        //this.mPBGrid.AcceptData();

                        //this.mPBGrid.SetItemValue(this.grdWoi.CurrentRowNumber, "suname", ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["suname"]);
                        
                    }
                    catch
                    {
                    }

                    #endregion

                    break;


            }
			return base.Command(command, commandParam);
		}
		#endregion
        
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            { 
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    QueryAll();

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    try
                    {
                        //Service.BeginTransaction();

                        if (!SaveNur5200())
                            throw new Exception();

                        //if (!DeleteData())
                        //    throw new Exception();

                        if (!this.layNur5020Save.SaveLayout())
                            throw new Exception();

                        if (!this.grdGuhoGubun.SaveLayout())
                            throw new Exception();

                        if (!this.grdWoi.SaveLayout())
                            throw new Exception();

                        if (!this.grdComment.SaveLayout())
                            throw new Exception();

                        //if (!this.grdNurse.SaveLayout())
                        //    throw new Exception();
                        
                        if (!this.grdNURCnt.SaveLayout())
                            throw new Exception();
                        
                        if (!this.grdIpToi.SaveLayout())
                            throw new Exception();

                        if (!this.grdTrans.SaveLayout())
                            throw new Exception();

                        if (!this.grdSusul.SaveLayout())
                            throw new Exception();

                        if (!this.grdWatchList.SaveLayout())
                            throw new Exception();

                        if (!this.grdGwa.SaveLayout())
                            throw new Exception();

                        if (!this.grdBedSore.SaveLayout())
                            throw new Exception();  

                        //Service.CommitTransaction();
                        XMessageBox.Show("保存が完了しました。", "保存", MessageBoxIcon.Information);
                        this.cbxLoadNewData.Checked = false;
                        QueryAll();
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        XMessageBox.Show("保存に失敗しました。\r\n" + Service.ErrFullMsg , "保存失敗", MessageBoxIcon.Error);
                    }

                    break;

                case FunctionType.Print:

                    SetDataWindow();

                    if (this.dw_print.RowCount < 1)
                        return;

                    this.dw_print.Print();

                    break;

            }
        }

        private bool SaveNur5200()
        {
            string cmdText = "";

            cmdText = @"SELECT A.CONFIRM_YN, A.SEQ
                          FROM NUR5200 A
                         WHERE A.HOSP_CODE = :f_hosp_code
                           AND A.HO_DONG   = :f_ho_dong
                           AND NUR_WRDT    = :f_nur_wrdt
                           AND A.SEQ       = (SELECT MAX(Z.SEQ)
                                                  FROM NUR5200 Z
                                                 WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                   AND Z.HO_DONG   = A.HO_DONG
                                                   AND Z.NUR_WRDT  = A.NUR_WRDT  )";

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_ho_dong", this.cboBuseo.GetDataValue());
            bc.Add("f_nur_wrdt", this.dtpDate.GetDataValue());

            DataTable dt = Service.ExecuteDataTable(cmdText, bc);

            cmdText = @"INSERT INTO NUR5200
                             ( SYS_DATE         , SYS_ID
                             , UPD_DATE         , UPD_ID        
                             , HOSP_CODE        , HO_DONG
                             , NUR_WRDT         , CONFIRM_YN        , SEQ       )
                        VALUES 
                             ( SYSDATE          , :q_user_id
                             , SYSDATE          , :q_user_id    
                             , :f_hosp_code     , :f_ho_dong
                             , :f_nur_wrdt      , :f_confirm_yn     , :f_seq      )";

            bc.Add("q_user_id", UserInfo.UserID);
            bc.Add("f_confirm_yn", this.cbxConfirm_yn.Checked ? "Y" : "N");
            bc.Add("f_seq", "1");

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["confirm_yn"].ToString() == "N")
                {
                    cmdText = @"UPDATE NUR5200
                                   SET UPD_DATE   = SYSDATE
                                     , UPD_ID     = :q_user_id
                                     , CONFIRM_YN = :f_confirm_yn
                                 WHERE HOSP_CODE  = :f_hosp_code
                                   AND HO_DONG    = :f_ho_dong
                                   AND NUR_WRDT   = :f_nur_wrdt
                                   AND SEQ        = :f_seq         ";
                    bc.Add("f_seq", dt.Rows[0]["seq"].ToString());
                }
                else
                {
                    int t_seq = Convert.ToInt32(dt.Rows[0]["seq"]) + 1;
                    bc.Add("f_seq", t_seq.ToString());
                }
            }

            if (!Service.ExecuteNonQuery(cmdText, bc))
                return false;

            return true;
        }

        private bool DeleteData()
        {

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(cboBuseo.GetDataValue());
            inputList.Add(this.dtpDate.GetDataValue());
            return Service.ExecuteProcedure("PR_NUR_NUR5200_SUB_DELETE", inputList, outputList);

           /*
            string cmdText = "";
            
            //병상, 감염증, 욕창
            cmdText = @"DELETE FROM NUR5020
                         WHERE HOSP_CODE = :f_hosp_code
                           AND HO_DONG   = :f_ho_dong
                           AND NUR_WRDT  = :f_nur_wrdt";

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_ho_dong", this.cboBuseo.GetDataValue());
            bc.Add("f_nur_wrdt", this.dtpDate.GetDataValue());

            if (!Service.ExecuteNonQuery(cmdText, bc))
                return false;

            //구호구분
            cmdText = @"DELETE FROM NUR5021
                         WHERE HOSP_CODE = :f_hosp_code
                           AND HO_DONG   = :f_ho_dong
                           AND NUR_WRDT  = :f_nur_wrdt";

            if (!Service.ExecuteNonQuery(cmdText, bc))
                return false;

            //외출,외박  입원,퇴원  전과,전실
            cmdText = @"DELETE FROM NUR5023
                         WHERE HOSP_CODE = :f_hosp_code
                           AND HO_DONG   = :f_ho_dong
                           AND NUR_WRDT  = :f_nur_wrdt";

            if (!Service.ExecuteNonQuery(cmdText, bc))
                return false;

            //수술 //요주의
            cmdText = @"DELETE FROM NUR5024
                         WHERE HOSP_CODE = :f_hosp_code
                           AND HO_DONG   = :f_ho_dong
                           AND NUR_WRDT  = :f_nur_wrdt
                           --AND GUBUN     = '1' 
                        ";

            if (!Service.ExecuteNonQuery(cmdText, bc))
                return false;
            */
        }

        private void cboBuseo_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (this.cbxConfirm_yn.Checked)
            //    return;
            QueryAll();
        }

        private void QueryAll()
        {
            this.layConfirm_yn.QueryLayout();
            //string confirm_yn = this.layConfirm_yn.GetItemValue("confirm_yn").ToString();
            
            this.layNur5020.Reset();

            //if (!this.cbxConfirm_yn.Checked && DateTime.Parse(dtpDate.GetDataValue()) == EnvironInfo.GetSysDate())
            if (!this.cbxConfirm_yn.Checked && cbxLoadNewData.Checked)
            {
                //쿼리문 변경 (간호 데이터에서  조회해옴. 신규)
                #region Query
                this.grdGuhoGubun.QuerySQL = @"SELECT  '' STAIR,
                                                       '' STAIR_NAME,
                                                       '' STAIR_TOTAL_CNT,
                                                       :f_date NUR_WRDT,
                                                       :f_ho_dong HO_DONG,
                                                       NVL(SUM(DECODE(Z.DIRECT_CONT1,'1',1,0)), 0) DANSONG_CNT,
                                                       NVL(SUM(DECODE(Z.DIRECT_CONT1,'2',1,0)), 0) HOSONG_CNT,
                                                       NVL(SUM(DECODE(NVL(Z.DIRECT_CONT1, '3'),'3',1,0)), 0) DOKBO_CNT
                                                       --NVL(SUM(1), 0)                              TOT_CNT
                                                      FROM ( SELECT A.FKINP1001     FKINP1001
                                                                  , A.ORDER_DATE    ORDER_DATE
                                                                  , A.DIRECT_CONT1  DIRECT_CONT1
                                                               FROM OCS2005 A
                                                              WHERE A.HOSP_CODE = :f_hosp_code
                                                                AND A.DIRECT_CODE = '0021'
                                                                AND A.ORDER_DATE = ( SELECT MAX(Z.ORDER_DATE)
                                                                              FROM OCS2005 Z
                                                                             WHERE Z.HOSP_CODE    = A.HOSP_CODE
                                                                               AND Z.FKINP1001    = A.FKINP1001
                                                                               AND Z.DIRECT_GUBUN = A.DIRECT_GUBUN
                                                                               AND Z.DIRECT_CODE  = A.DIRECT_CODE
                                                                               AND Z.ORDER_DATE  <= :f_date )) Z
                                                         , VW_OCS_INP1001_01 B
                                                     WHERE B.HOSP_CODE    = :f_hosp_code
                                                       AND B.KAIKEI_HODONG    = :f_ho_dong
                                                       AND B.JAEWON_FLAG  = 'Y'
                                                       AND NVL(B.CANCEL_YN,'N') = 'N'
                                                       AND Z.FKINP1001(+) = B.PKINP1001";

                this.grdWoi.QuerySQL = @"SELECT    :f_date NUR_WRDT
                                                 , :f_ho_dong   HO_DONG
                                                 , A.WOICHUL_WOIBAK_GUBUN                                                   DETAIL_GUBUN
                                                 , FN_NUR_LOAD_CODE_NAME('WOICHUL_WOPIBAK_GUBUN', A.WOICHUL_WOIBAK_GUBUN)   GUBUN_NAME   
                                                 , A.BUNHO                                                                  BUNHO
                                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)                                              SUNAME
                                                 , FN_INP_LOAD_HO_CODE_HISTORY(A.BUNHO, :f_date)                            HO_CODE
                                                 , A.OUT_DATE                                                               DATE1
                                                 , A.OUT_TIME                                                               TIME1
                                                 , NVL(A.IN_TRUE_DATE, A.IN_HOPE_DATE)                                      DATE2
                                                 , NVL(A.IN_TRUE_TIME, A.IN_HOPE_TIME)                                      TIME2
                                                 , ''                                                                       BIGO
                                                 , ''                                                                       JAPAN_DATE1
                                                 , ''                                                                       JAPAN_DATE2
                                              FROM NUR1014 A
                                                 , INP1001 B
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND B.HOSP_CODE = A.HOSP_CODE                                            
                                               AND :f_date BETWEEN A.OUT_DATE AND NVL(A.IN_HOPE_DATE, NVL(A.IN_TRUE_DATE, '9998/12/31')) 
                                               AND B.PKINP1001 = A.FKINP1001
                                               AND B.JAEWON_FLAG = 'Y'
                                               AND NVL(B.CANCEL_YN, 'N') = 'N'   
                                               AND B.KAIKEI_HODONG  = :f_ho_dong
                                               AND B.IPWON_TYPE IN ('0', '1')
                                               ORDER BY A.WOICHUL_WOIBAK_GUBUN, OUT_DATE, OUT_TIME";

                this.grdIpToi.QuerySQL = @"SELECT A.IPWON_DATE                                                             IPWON_DATE
                                                 , A.KAIKEI_HODONG                                                          HO_DONG
                                                 , '01'                                                                     GUBUN  -- IPWON  
                                                 , FN_NUR_LOAD_CODE_NAME('IPWON_TOIWON', '01')                              GUBUN_NAME                   
                                                 , A.GWA                                                                    GWA
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA, A.IPWON_DATE)                                GWA_NAME
                                                 , A.KAIKEI_HOCODE                                                               HO_CODE
                                                 , A.BUNHO                                                                  BUNHO
                                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)                                              SUNAME
                                                 , FN_BAS_LOAD_AGE(SYSDATE, B.BIRTH, '')                                        AGE
                                                 , B.SEX                                                                    SEX
                                                 , FN_OCS_LOAD_SANG_NAME(A.BUNHO, A.PKINP1001)                              SANG
                                                 , ''                                                                       BIGO
                                              FROM INP1001 A
                                                 , OUT0101 B
                                             WHERE A.HOSP_CODE  = :f_hosp_code
                                               AND B.HOSP_CODE  = A.HOSP_CODE
                                               AND A.BUNHO      = B.BUNHO 
                                               AND A.IPWON_DATE = :f_date
                                               AND A.KAIKEI_HODONG   = :f_ho_dong
                                               AND NVL(CANCEL_YN, 'N') = 'N'
                                               AND A.IPWON_TYPE IN ('0', '1')
                                               AND A.BUNHO NOT LIKE '5%'
                                             UNION 
                                            SELECT A.TOIWON_DATE                                                            IPWON_DATE
                                                 , A.KAIKEI_HODONG                                                          HO_DONG
                                                 , '02'                                                                     GUBUN   --TOIWON  
                                                 , FN_NUR_LOAD_CODE_NAME('IPWON_TOIWON', '02')                                              
                                                 , A.GWA                                                                    GWA
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA, A.TOIWON_DATE)                               GWA_NAME
                                                 , A.KAIKEI_HOCODE                                                               HO_CODE
                                                 , A.BUNHO                                                                  BUNHO
                                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)                                              SUNAME
                                                 , FN_BAS_LOAD_AGE(SYSDATE, B.BIRTH, '')                                        AGE
                                                 , B.SEX                                                                    SEX
                                                 , FN_OCS_LOAD_SANG_NAME(A.BUNHO, A.PKINP1001)                              SANG
                                                 , ''                                                                       BIGO
                                              FROM INP1001 A
                                                 , OUT0101 B
                                             WHERE A.HOSP_CODE   = :f_hosp_code
                                               AND B.HOSP_CODE   = A.HOSP_CODE
                                               AND A.BUNHO       = B.BUNHO 
                                               AND A.TOIWON_DATE = :f_date
                                               AND A.KAIKEI_HODONG    = :f_ho_dong
                                               AND NVL(CANCEL_YN, 'N') = 'N'
                                               AND A.IPWON_TYPE IN ('0', '1')
                                               AND A.BUNHO NOT LIKE '5%'";
                 
                this.grdTrans.QuerySQL = @"SELECT A.START_DATE
                                                 , CASE WHEN A.FROM_KAIKEI_HODONG = :f_ho_dong THEN
                                                             A.FROM_KAIKEI_HODONG
                                                   ELSE A.TO_KAIKEI_HODONG        END       HO_DONG
                                                 , '01'            -- JUNGWA
                                                 , FN_NUR_LOAD_CODE_NAME('JUNGWA_JUNSIL', '01')
                                                 , A.BUNHO
                                                 , C.SUNAME
                                                 , A.FROM_GWA
                                                 , A.TO_GWA
                                                 , A.FROM_KAIKEI_HOCODE
                                                 , A.TO_KAIKEI_HOCODE
                                                 , FN_BAS_LOAD_GWA_NAME(A.FROM_GWA, A.START_DATE)
                                                 , FN_BAS_LOAD_GWA_NAME(A.TO_GWA, A.START_DATE)
                                              FROM OUT0101 C
                                                 , INP1001 B
                                                 , INP2004 A
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND B.HOSP_CODE = A.HOSP_CODE
                                               AND C.HOSP_CODE = A.HOSP_CODE 
                                               AND A.FKINP1001 = B.PKINP1001
                                               AND A.BUNHO NOT LIKE '5%'
                                               AND A.BUNHO     = C.BUNHO
                                               AND A.BUNHO     = B.BUNHO
                                               AND A.FROM_GWA <> A.TO_GWA  
                                               AND A.START_DATE = :f_date  
                                               AND (  A.FROM_KAIKEI_HODONG = :f_ho_dong
                                                   OR A.TO_KAIKEI_HODONG   = :f_ho_dong)
                                            UNION 
                                            SELECT A.START_DATE
                                                 , CASE WHEN A.FROM_KAIKEI_HODONG = :f_ho_dong THEN
                                                             A.FROM_KAIKEI_HODONG
                                                   ELSE A.TO_KAIKEI_HODONG        END       HO_DONG
                                                 , '02'            -- JUNSIL
                                                 , FN_NUR_LOAD_CODE_NAME('JUNGWA_JUNSIL', '02')
                                                 , A.BUNHO
                                                 , C.SUNAME
                                                 , A.FROM_GWA
                                                 , A.TO_GWA
                                                 , A.FROM_KAIKEI_HOCODE
                                                 , A.TO_KAIKEI_HOCODE
                                                 , ''
                                                 , ''
                                              FROM OUT0101 C
                                                 , INP1001 B
                                                 , INP2004 A
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND B.HOSP_CODE = A.HOSP_CODE
                                               AND C.HOSP_CODE = A.HOSP_CODE 
                                               AND A.FKINP1001 = B.PKINP1001
                                               AND A.BUNHO NOT LIKE '5%'
                                               AND A.BUNHO     = C.BUNHO
                                               AND A.BUNHO     = B.BUNHO
                                               AND A.FROM_KAIKEI_HOCODE <> A.TO_KAIKEI_HOCODE  
                                               AND A.START_DATE = :f_date  
                                               AND (  A.FROM_KAIKEI_HODONG = :f_ho_dong
                                                   OR A.TO_KAIKEI_HODONG   = :f_ho_dong)";

                this.grdSusul.QuerySQL = @"SELECT A.RESER_DATE
                                                 , '01'           -- SUSUL
                                                 , A.GWA
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA, A.RESER_DATE)
                                                 , B.KAIKEI_HODONG
                                                 , B.KAIKEI_HOCODE
                                                 , B.BUNHO
                                                 , C.SUNAME
                                                 , FN_BAS_LOAD_AGE(SYSDATE, C.BIRTH, '')
                                                 , C.SEX
                                                 , FN_OCS_LOAD_SANG_NAME(B.BUNHO, B.PKINP1001)
                                                 , D.HANGMOG_NAME
                                              FROM SCH0201 A
                                                 , INP1001 B
                                                 , OUT0101 C
                                                 , OCS0103 D
                                             WHERE A.HOSP_CODE           = :f_hosp_code
                                               AND B.HOSP_CODE           = A.HOSP_CODE
                                               AND C.HOSP_CODE           = A.HOSP_CODE
                                               AND D.HOSP_CODE           = A.HOSP_CODE
                                               AND A.JUNDAL_TABLE        = 'OP'
                                               AND A.RESER_DATE          = :f_date
                                               AND A.BUNHO               = B.BUNHO
                                               AND B.KAIKEI_HODONG            = :f_ho_dong
                                               AND B.JAEWON_FLAG         = 'Y'
                                               AND NVL(B.CANCEL_YN, 'N') = 'N'
                                               AND B.IPWON_TYPE IN ('0', '1')
                                               AND C.BUNHO               = B.BUNHO
                                               AND D.HANGMOG_CODE        = A.HANGMOG_CODE
                                               AND A.RESER_DATE BETWEEN D.START_DATE AND D.END_DATE
                                             ORDER BY B.KAIKEI_HOCODE, B.BUNHO";

                this.grdGwa.QuerySQL = @"   SELECT A.GWA, B.GWA_NAME, COUNT(*), B.GWA_COLOR
                                              FROM BAS0260 B
                                                 , VW_OCS_INP1001_01 A      
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND A.KAIKEI_HODONG = :f_ho_dong
                                               AND B.HOSP_CODE = A.HOSP_CODE
                                               AND B.GWA = A.GWA
                                             GROUP BY A.GWA, B.GWA_NAME, B.GWA_COLOR
                                             ORDER BY A.GWA ";


                this.grdBedSore.QuerySQL = @"SELECT B.HO_CODE1       HO_CODE
                                                  , B.BUNHO          BUNHO
                                                  , C.SUNAME         SUNAME 
                                                  , A.FROM_DATE      FROM_DATE     
                                                  , F1.CODE_NAME || ', ' || F2.CODE_NAME || ', ' || F3.CODE_NAME || ', ' || F4.CODE_NAME || ', ' || F5.CODE_NAME || ', ' || F6.CODE_NAME     BUWI
                                               FROM NUR6001 A 
                                                  , VW_OCS_INP1001_01 B
                                                  , OUT0101 C
                                                  , NUR0102 F1
                                                  , NUR0102 F2
                                                  , NUR0102 F3
                                                  , NUR0102 F4
                                                  , NUR0102 F5
                                                  , NUR0102 F6
                                              WHERE A.HOSP_CODE = :f_hosp_code
                                                AND B.HOSP_CODE = A.HOSP_CODE
                                                AND B.PKINP1001 = A.FKINP1001
                                                AND SYSDATE BETWEEN A.FROM_DATE AND NVL(A.END_DATE, '9998/12/31') 
                                                AND B.KAIKEI_HODONG = 'A'
                                                AND C.HOSP_CODE = A.HOSP_CODE
                                                AND C.BUNHO = A.BUNHO
                                                AND F1.HOSP_CODE = A.HOSP_CODE
                                                AND F1.CODE_TYPE = 'BEDSORE_BUWI'
                                                AND F1.CODE = A.BEDSORE_BUWI1
                                               
                                                AND F2.HOSP_CODE = A.HOSP_CODE
                                                AND F2.CODE_TYPE = 'BEDSORE_BUWI'
                                                AND F2.CODE = A.BEDSORE_BUWI2
                                                
                                                AND F3.HOSP_CODE = A.HOSP_CODE
                                                AND F3.CODE_TYPE = 'BEDSORE_BUWI'
                                                AND F3.CODE = A.BEDSORE_BUWI3
                                                
                                                AND F4.HOSP_CODE = A.HOSP_CODE
                                                AND F4.CODE_TYPE = 'BEDSORE_BUWI'
                                                AND F4.CODE = A.BEDSORE_BUWI4
                                                
                                                AND F5.HOSP_CODE = A.HOSP_CODE
                                                AND F5.CODE_TYPE = 'BEDSORE_BUWI'
                                                AND F5.CODE = A.BEDSORE_BUWI5
                                                
                                                AND F6.HOSP_CODE = A.HOSP_CODE
                                                AND F6.CODE_TYPE = 'BEDSORE_BUWI'
                                                AND F6.CODE = A.BEDSORE_BUWI6";
 
                #endregion
            }
            else
            {
                //쿼리문 변경 (저장된 데이터에서 조회해옴)
                #region Query

                this.grdGuhoGubun.QuerySQL = @"SELECT STAIR
                                                     , STAIR_NAME
                                                     , STAIR_TOTAL_CNT
                                                     , NUR_WRDT
                                                     , HO_DONG
                                                     , DANSONG_CNT
                                                     , HOSONG_CNT
                                                     , DOKBO_CNT
                                                  FROM NUR5021
                                                 WHERE HOSP_CODE = :f_hosp_code
                                                   AND HO_DONG   = :f_ho_dong
                                                   AND NUR_WRDT  = :f_date";

                this.grdGwa.QuerySQL = @" SELECT A.NUR_WRDT
                                               , A.HO_DONG
                                               , A.GWA
                                               , A.GWA_NAME
                                               , A.PA_CNT
                                            FROM NUR5026 A
                                           WHERE A.HOSP_CODE = :f_hosp_code
                                             AND A.NUR_WRDT  = :f_date
                                             AND A.HO_DONG   = :f_ho_dong";

                this.grdIpToi.QuerySQL = @"SELECT  PKNUR5023
                                                 , A.NUR_WRDT
                                                 , A.HO_DONG
                                                 , A.DETAIL_GUBUN
                                                 , FN_NUR_LOAD_CODE_NAME('IPWON_TOIWON', A.DETAIL_GUBUN)
                                                 , A.GWA
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NUR_WRDT)
                                                 , A.HO_CODE
                                                 , A.BUNHO
                                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)
                                                 , FN_OCS_LOAD_AGE(A.BUNHO, SYSDATE)
                                                 , B.SEX
                                                 , A.SANG 
                                                 , A.BIGO 
                                              FROM NUR5023 A
                                                 , OUT0101 B
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND B.HOSP_CODE = A.HOSP_CODE
                                               AND B.BUNHO     = A.BUNHO
                                               AND A.HO_DONG   = :f_ho_dong
                                               AND A.NUR_WRDT  = :f_date
                                               AND A.GUBUN     = '2' -- IPWON, TOIWON";

                this.grdTrans.QuerySQL = @"SELECT  PKNUR5023
                                                 , A.NUR_WRDT
                                                 , A.HO_DONG
                                                 , A.DETAIL_GUBUN
                                                 , FN_NUR_LOAD_CODE_NAME('JUNGWA_JUNSIL', A.DETAIL_GUBUN)
                                                 , A.BUNHO
                                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)
                                                 , A.FROM_GWA
                                                 , A.TO_GWA
                                                 , A.FROM_HO_CODE
                                                 , A.TO_HO_CODE
                                                 , FN_BAS_LOAD_GWA_NAME(A.FROM_GWA, A.NUR_WRDT)
                                                 , FN_BAS_LOAD_GWA_NAME(A.TO_GWA, A.NUR_WRDT)
                                                 , FN_OCS_LOAD_AGE(A.BUNHO, A.NUR_WRDT)
                                                 , FN_OCS_LOAD_SEX(A.BUNHO)
                                              FROM NUR5023 A
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND A.HO_DONG   = :f_ho_dong
                                               AND A.NUR_WRDT  = :f_date                                               
                                               AND A.GUBUN     = '3'-- JUNGWA, JUNSIL";


                this.grdWoi.QuerySQL = @"SELECT PKNUR5023
                                              , NUR_WRDT
                                              , HO_DONG
                                              , DETAIL_GUBUN
                                              , FN_NUR_LOAD_CODE_NAME('WOICHUL_WOPIBAK_GUBUN', DETAIL_GUBUN) GUBUN_NAME
                                              , BUNHO
                                              , FN_OUT_LOAD_SUNAME(BUNHO)    SUNAME
                                              , HO_CODE
                                              , DATE1
                                              , TIME1
                                              , DATE2
                                              , TIME2
                                              , BIGO 
                                              , FN_BAS_TO_JAPAN_DATE_CONVERT('1', DATE1) JAPAN_DATE1
                                              , FN_BAS_TO_JAPAN_DATE_CONVERT('1', DATE2) JAPAN_DATE2
                                           FROM NUR5023
                                          WHERE HOSP_CODE = :f_hosp_code
                                            AND HO_DONG   = :f_ho_dong
                                            AND NUR_WRDT  = :f_date
                                            AND GUBUN     = '1' -- WOICHUL, WOIBAK";

                this.grdBedSore.QuerySQL = @"SELECT A.HO_DONG
                                                  , A.NUR_WRDT
                                                  , A.HO_CODE
                                                  , A.BUNHO
                                                  , B.SUNAME
                                                  , A.FROM_DATE
                                                  , A.BUWI
                                               FROM NUR5028 A
                                                  , OUT0101 B
                                              WHERE A.HOSP_CODE = :f_hosp_code
                                                AND A.HO_DONG   = :f_ho_dong
                                                AND A.NUR_WRDT  = :f_date
                                                AND B.HOSP_CODE = A.HOSP_CODE
                                                AND B.BUNHO     = A.BUNHO ";

                this.grdSusul.QuerySQL = @" SELECT A.NUR_WRDT
                                                 , A.DETAIL_GUBUN
                                                 , A.GWA
                                                 , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NUR_WRDT)
                                                 , A.HO_DONG
                                                 , A.HO_CODE
                                                 , A.BUNHO
                                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)
                                                 , FN_OCS_LOAD_AGE(A.BUNHO, SYSDATE)
                                                 , B.SEX
                                                 , A.SANG
                                                 , A.SULSIK
                                                 , A.COMMENT1
                                                 , A.COMMENT2
                                                 , A.COMMENT3
                                              FROM NUR5024 A
                                                 , OUT0101 B
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND B.HOSP_CODE = A.HOSP_CODE
                                               AND B.BUNHO     = A.BUNHO
                                               AND A.GUBUN     = '1'   -- SUSUL
                                               AND A.NUR_WRDT  = :f_date
                                               AND A.HO_DONG   = :f_ho_dong
                                             ORDER BY A.HO_CODE, A.BUNHO";
                #endregion
            }

            ClearControls();
            this.grdGuhoGubun.QueryLayout(false);
            //this.grdNurse.QueryLayout(false);
            this.grdNURCnt.QueryLayout(false);
            this.grdGwa.QueryLayout(false);
            //this.layNurCnt.QueryLayout(false);

            this.grdWoi.QueryLayout(false);
            this.grdComment.QueryLayout(false);
            this.grdIpToi.QueryLayout(false);
            this.grdTrans.QueryLayout(false);
            this.grdSusul.QueryLayout(false);
            this.grdWatchList.QueryLayout(false);
            this.grdBedSore.QueryLayout(false);

            if (cbxLoadNewData.Checked) //신규데이타 조회
            {
                this.layTotalCnt.QueryLayout();
                this.layGamyumCnt.QueryLayout();

                for (int i = 0; i < this.grdGuhoGubun.RowCount; i++)
                {
                    this.layStairCnt.SetBindVarValue("f_stair", this.grdGuhoGubun.GetItemString(i, "stair"));
                    this.layStairCnt.QueryLayout();

                    this.grdGuhoGubun.SetItemValue(i, "dansong_cnt", this.layStairCnt.GetItemValue("dansong"));
                    this.grdGuhoGubun.SetItemValue(i, "hosong_cnt", this.layStairCnt.GetItemValue("hosong"));
                    this.grdGuhoGubun.SetItemValue(i, "dokbo_cnt", this.layStairCnt.GetItemValue("dokbo"));
                    this.grdGuhoGubun.SetItemValue(i, "stair_total_cnt", this.layStairCnt.GetItemValue("stair_total_cnt"));
                }
                this.grdGuhoGubun.ResetUpdate();
            }
            else  // 보존데이타 조회
            {
                this.layNur5020.QueryLayout(false);
            }            
            
        }

        private void SetDataWindow()
        {
            this.dw_print.Reset();
            string[] dateString = this.dtpDate.GetDataValue().Split('/');
            this.dw_print.Modify("t_nur_wrdt_jpn.text = '" + dateString[0] + "年 " + dateString[1]
                            + "月 " + dateString[2] + "日'");
            this.dw_print.Modify("t_ho_dong_name.text = '" + this.cboBuseo.Text + "'");

            DataTable dt = new DataTable("temp_table");

            if (this.layNur5020.RowCount > 0)
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt = layNur5020.Copy().LayoutTable;

                dt.Columns.Add("dansong_cnt");
                dt.Columns.Add("hosong_cnt");
                dt.Columns.Add("dokbo_cnt");

                dt.Rows[0]["dansong_cnt"] = grdGuhoGubun.GetItemValue(0, "dansong_cnt");
                dt.Rows[0]["hosong_cnt"] = grdGuhoGubun.GetItemValue(0, "hosong_cnt");
                dt.Rows[0]["dokbo_cnt"] = grdGuhoGubun.GetItemValue(0, "dokbo_cnt");

                this.dw_print.FillChildData("dw_1", dt);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("yesterday_cnt");
                dt.Columns.Add("ipwon_cnt");
                dt.Columns.Add("toiwon_cnt");
                dt.Columns.Add("jaewon_cnt");
                dt.Columns.Add("gamyum1_cnt");
                dt.Columns.Add("gamyum2_cnt");
                dt.Columns.Add("gamyum3_cnt");
                dt.Columns.Add("gamyum4_cnt");
                dt.Columns.Add("gamyum5_cnt");
                dt.Columns.Add("gamyum6_cnt");
                dt.Columns.Add("gamyum7_cnt");
                dt.Columns.Add("gamyum8_cnt");
                dt.Columns.Add("gamyum6_name");
                dt.Columns.Add("gamyum7_name");
                dt.Columns.Add("gamyum8_name");
                dt.Columns.Add("move_out_cnt");
                dt.Columns.Add("move_in_cnt");
                dt.Columns.Add("dansong_cnt");
                dt.Columns.Add("hosong_cnt");
                dt.Columns.Add("dokbo_cnt");

                object t_yesterday_cnt = this.layTotalCnt.GetItemValue("emkYesterDay");
                object t_ipwon_cnt = this.layTotalCnt.GetItemValue("emkIpwon");
                object t_toiwon_cnt = this.layTotalCnt.GetItemValue("emkToiwon");
                object t_jaewon_cnt = this.layTotalCnt.GetItemValue("emkJaewon");
                object t_gamyum1_cnt = this.layGamyumCnt.GetItemValue("gamyum_cnt1");
                object t_gamyum2_cnt = this.layGamyumCnt.GetItemValue("gamyum_cnt2");
                object t_gamyum3_cnt = this.layGamyumCnt.GetItemValue("gamyum_cnt3");
                object t_gamyum4_cnt = this.layGamyumCnt.GetItemValue("gamyum_cnt4");
                object t_gamyum5_cnt = this.layGamyumCnt.GetItemValue("gamyum_cnt5");
                object t_gamyum6_cnt = this.layGamyumCnt.GetItemValue("gamyum_cnt6");
                object t_gamyum7_cnt = this.layGamyumCnt.GetItemValue("gamyum_cnt7");
                object t_gamyum8_cnt = this.layGamyumCnt.GetItemValue("gamyum_cnt8");
                object t_gamyum6_name = this.layGamyumCnt.GetItemValue("txtGamyum6");
                object t_gamyum7_name = this.layGamyumCnt.GetItemValue("txtGamyum7");
                object t_gamyum8_name = this.layGamyumCnt.GetItemValue("txtGamyum8");
                object t_move_out_cnt = this.layTotalCnt.GetItemValue("move_out_cnt");
                object t_move_in_cnt = this.layTotalCnt.GetItemValue("move_in_cnt");
                object t_dansong_cnt = this.grdGuhoGubun.GetItemValue(0, "dansong_cnt");
                object t_hosong_cnt = this.grdGuhoGubun.GetItemValue(0, "hosong_cnt");
                object t_dokbo_cnt = this.grdGuhoGubun.GetItemValue(0, "dokbo_cnt");

                //string t_yokchang_comment = "　　　　　　　　　　　　　　　------ なし -----";

                dt.Rows.Add(t_yesterday_cnt, t_ipwon_cnt, t_toiwon_cnt, t_jaewon_cnt
                          , t_gamyum1_cnt, t_gamyum2_cnt, t_gamyum3_cnt, t_gamyum4_cnt
                          , t_gamyum5_cnt, t_gamyum6_cnt, t_gamyum7_cnt, t_gamyum8_cnt
                          , t_gamyum6_name, t_gamyum7_name, t_gamyum8_name
                          , t_move_out_cnt, t_move_in_cnt, t_dansong_cnt
                          , t_hosong_cnt, t_dokbo_cnt);
                this.dw_print.FillChildData("dw_1", dt);
            }

            //if (this.grdGuhoGubun.RowCount > 0)
            //{
            //    this.dw_print.FillChildData("dw_2", this.grdGuhoGubun.LayoutTable);
            //}
            //else
            //{
            //    dt.Columns.Clear();
            //    dt.Rows.Clear();

            //    dt.Columns.Add("stair_name");
            //    dt.Rows.Add("");
            //    this.dw_print.FillChildData("dw_2", dt);
            //}

            if (this.grdGwa.RowCount > 0)
            {
                this.dw_print.FillChildData("dw_2", this.grdGwa.LayoutTable);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("gwa_name");
                dt.Rows.Add("");
                this.dw_print.FillChildData("dw_2", dt);
            }



            if (this.grdIpToi.RowCount > 0)
            {
                this.dw_print.FillChildData("dw_3", this.grdIpToi.LayoutTable);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("ho_dong");
                dt.Rows.Add("");
                this.dw_print.FillChildData("dw_3", dt);
            }

            if (this.grdTrans.RowCount > 0)
            {
                this.dw_print.FillChildData("dw_4", this.grdTrans.LayoutTable);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("ho_dong");
                dt.Rows.Add("");
                this.dw_print.FillChildData("dw_4", dt);
            }

            if (this.grdWoi.RowCount > 0)
            {
                this.dw_print.FillChildData("dw_5", this.grdWoi.LayoutTable);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("ho_dong");
                dt.Rows.Add("");
                this.dw_print.FillChildData("dw_5", dt);
            }

            if (this.grdNURCnt.RowCount > 0)
            {
                this.dw_print.FillChildData("dw_6", this.grdNURCnt.LayoutTable);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("ho_dong");
                dt.Rows.Add("");
                this.dw_print.FillChildData("dw_6", dt);
            }

            //if (this.grdNurse.RowCount > 0)
            //{
            //    this.dw_print.FillChildData("dw_7", this.grdNurse.LayoutTable);
            //}
            //else
            //{
            //    dt.Columns.Clear();
            //    dt.Rows.Clear();

            //    dt.Columns.Add("ho_dong");
            //    dt.Rows.Add("");
            //    this.dw_print.FillChildData("dw_7", dt);
            //}

            if (this.grdSusul.RowCount > 0)
            {
                this.dw_print.FillChildData("dw_8", this.grdSusul.LayoutTable);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("ho_dong");
                dt.Rows.Add("");
                this.dw_print.FillChildData("dw_8", dt);
            }

            if (this.grdWatchList.RowCount > 0)
            {
                this.dw_print.FillChildData("dw_9", this.grdWatchList.LayoutTable);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("ho_dong");
                dt.Rows.Add("");
                this.dw_print.FillChildData("dw_9", dt);
            }

            if (this.grdBedSore.RowCount > 0)
            {
                this.dw_print.FillChildData("dw_7", this.grdBedSore.LayoutTable);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("ho_code");
                dt.Rows.Add("");
                this.dw_print.FillChildData("dw_7", dt);
            }

            if (this.grdComment.RowCount > 0)
            {
                this.dw_print.FillChildData("dw_10", this.grdComment.LayoutTable);
            }
            else
            {
                dt.Columns.Clear();
                dt.Rows.Clear();

                dt.Columns.Add("comment");
                dt.Rows.Add("　　　　　　　　　　　　　　　              　            ------ なし -----");
                this.dw_print.FillChildData("dw_10", dt);
            }
        }

        private void ClearControls()
        {
            //this.emkYesterDay.ResetData();
            this.emkIpwon.ResetData();
            this.emkToiwon.ResetData();
            this.emkJaewon.ResetData();
            this.emkMoveOut.ResetData();
            this.emkMoveIn.ResetData();

            this.emkGamyum1.ResetData();
            this.emkGamyum2.ResetData();
            this.emkGamyum3.ResetData();
            this.emkGamyum4.ResetData();
            this.emkGamyum5.ResetData();
            this.emkGamyum6.ResetData();
            this.txtGamyum6.ResetData();

            //this.fbxNurse.ResetData();
            //this.dbxNurseName.ResetData();
            //this.txtYokchang.ResetData();
        }

        private void layConfirm_yn_QueryStarting(object sender, CancelEventArgs e)
        {
            layConfirm_yn.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layConfirm_yn.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            layConfirm_yn.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());            
        }

        private void layNur5020_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNur5020.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNur5020.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.layNur5020.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdGuhoGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdGuhoGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdGuhoGubun.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.grdGuhoGubun.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void layStairCnt_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layStairCnt.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layStairCnt.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
            this.layStairCnt.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
        }

        private void layGamyumCnt_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layGamyumCnt.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layGamyumCnt.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
            this.layGamyumCnt.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
        }

        private void grdWoi_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdWoi.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdWoi.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.grdWoi.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdComment_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdComment.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdComment.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.grdComment.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdNurse_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNurse.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNurse.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.grdNurse.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdIpToi_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdIpToi.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdIpToi.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.grdIpToi.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdTrans_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdTrans.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdTrans.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.grdTrans.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdSusul_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSusul.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSusul.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.grdSusul.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdWatchList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdWatchList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdWatchList.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.grdWatchList.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdNURCnt_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNURCnt.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNURCnt.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.grdNURCnt.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdGwa_QueryStarting(object sender, CancelEventArgs e)
        {
            grdGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdGwa.SetBindVarValue("f_date", dtpDate.GetDataValue());
            grdGwa.SetBindVarValue("f_ho_dong", cboBuseo.GetDataValue());
        }

        private void grdBedSore_QueryStarting(object sender, CancelEventArgs e)
        {
            grdBedSore.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdBedSore.SetBindVarValue("f_ho_dong", cboBuseo.GetDataValue());
            grdBedSore.SetBindVarValue("f_date", dtpDate.GetDataValue());
        }

        private void layTotalCnt_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layTotalCnt.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layTotalCnt.SetBindVarValue("f_date", this.dtpDate.GetDataValue());
            this.layTotalCnt.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }

        private void grdNURCnt_QueryEnd(object sender, QueryEndEventArgs e)
        {
            for(int i = 0; i < grdNURCnt.RowCount; i++)
            {
                SumNurseCount(i);
            }
            grdNURCnt.ResetUpdate();
        }

        private void SumNurseCount(int row_num)
        {
            try
            {

                this.grdNURCnt.SetItemValue(row_num, "total_cnt", grdNURCnt.GetItemDouble(row_num, "dawn_cnt")
                                                                + grdNURCnt.GetItemDouble(row_num, "day_cnt")
                                                                + grdNURCnt.GetItemDouble(row_num, "night_cnt")
                                                                + grdNURCnt.GetItemDouble(row_num, "holi_cnt")
                                                                + grdNURCnt.GetItemDouble(row_num, "pay_cnt")
                                                                + grdNURCnt.GetItemDouble(row_num, "childcare_cnt")
                                                                + grdNURCnt.GetItemDouble(row_num, "special_cnt")
                                                                + grdNURCnt.GetItemDouble(row_num, "study_cnt")
                                                                + grdNURCnt.GetItemDouble(row_num, "absence_cnt"));
            }
            catch
            {}

        }

        //private void layTotalCnt_QueryEnd(object sender, QueryEndEventArgs e)
        //{            
        //    this.emkIpwon.SetEditValue(this.layTotalCnt.GetItemValue("emkIpwon"));
        //    this.emkIpwon.AcceptData();

        //    this.emkToiwon.SetEditValue(this.layTotalCnt.GetItemValue("emkToiwon"));
        //    this.emkToiwon.AcceptData();

        //    this.emkJaewon.SetEditValue(this.layTotalCnt.GetItemValue("emkJaewon"));
        //    this.emkJaewon.AcceptData();
        //}

        private void layGamyumCnt_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.emkGamyum1.SetEditValue(this.layGamyumCnt.GetItemValue("gamyum_cnt1"));
            this.emkGamyum1.AcceptData();

            this.emkGamyum2.SetEditValue(this.layGamyumCnt.GetItemValue("gamyum_cnt2"));
            this.emkGamyum2.AcceptData();

            this.emkGamyum3.SetEditValue(this.layGamyumCnt.GetItemValue("gamyum_cnt3"));
            this.emkGamyum3.AcceptData();

            this.emkGamyum4.SetEditValue(this.layGamyumCnt.GetItemValue("gamyum_cnt4"));
            this.emkGamyum4.AcceptData();

            this.emkGamyum5.SetEditValue(this.layGamyumCnt.GetItemValue("gamyum_cnt5"));
            this.emkGamyum5.AcceptData();

            this.emkGamyum6.SetEditValue(this.layGamyumCnt.GetItemValue("gamyum_cnt6"));
            this.emkGamyum6.AcceptData();

            this.txtGamyum6.SetEditValue(this.layGamyumCnt.GetItemValue("txtGamyum6"));
            this.txtGamyum6.AcceptData();
        }


        private void fwkNurse_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkNurse.SetBindVarValue("f_buseo_code", UserInfo.BuseoCode);
            this.fwkNurse.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        private void layNurCnt_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNurCnt.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNurCnt.SetBindVarValue("f_nur_wrdt", this.dtpDate.GetDataValue());
        }

        private void layConfirm_yn_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layConfirm_yn.GetItemValue("confirm_yn").ToString() == "Y")
                {
                    this.cbxConfirm_yn.Checked = true;
                    this.pnlMain.Enabled = false;
                    this.pnlLeft.Enabled = false;
                }
                else
                {
                    this.cbxConfirm_yn.Checked = false;
                    this.pnlMain.Enabled = true;
                    this.pnlLeft.Enabled = true;
                }
        }

        private void grd_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            switch (e.ColName)
            {
                case "bunho":
                    mPBGrid = grd;
                    XScreen.OpenScreen(this, "OUT0101Q01", ScreenOpenStyle.ResponseFixed);
                    mPBGrid = null;
                    break;
            }
        }

        private void grdNurse_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            switch (e.ColName)
            { 
                case "nurse_id":
                    this.grdNurse.SetItemValue(e.RowNumber, "nurse_name", e.ReturnValues[1].ToString());
                    break;
            }
        }

        private void layPaitientInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            SingleLayout layout = sender as SingleLayout;

            layout.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layout.SetBindVarValue("f_nur_wrdt", this.dtpDate.GetDataValue());
        }

        private void grd_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            
            string bunho = e.ChangeValue.ToString();

            switch (grd.Name)
            {
                #region 入院、退院
                case "grdIpToi":
                    switch (e.ColName)
                    {
                        case "bunho":

                            if (this.grdIpToi.GetItemString(e.RowNumber, "gubun") == "")
                            {
                                XMessageBox.Show("入・退院区分を選択してください。", "お知らせ", MessageBoxIcon.Warning);
                                this.grdIpToi.SetItemValue(e.RowNumber, "bunho", "");
                                this.grdIpToi.SetFocusToItem(e.RowNumber, "gubun");
                                return;
                            }

                            bunho = BizCodeHelper.GetStandardBunHo(bunho);

                            if (bunho != "" && bunho != "000000000")
                            {
                                this.grdIpToi.SetItemValue(e.RowNumber, "bunho", bunho);

                                if (this.grdIpToi.GetItemString(e.RowNumber, "gubun") == "01") //입원
                                {
                                    this.layPatientInfo_in.SetBindVarValue("f_bunho", bunho);
                                    this.layPatientInfo_in.QueryLayout();

                                    if (this.layPatientInfo_in.GetItemValue("suname").ToString() != "")
                                    {
                                        this.grdIpToi.SetItemValue(e.RowNumber, "ho_code", this.layPatientInfo_in.GetItemValue("ho_code"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "suname", this.layPatientInfo_in.GetItemValue("suname"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "age", this.layPatientInfo_in.GetItemValue("age"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "sex", this.layPatientInfo_in.GetItemValue("sex"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "sang", this.layPatientInfo_in.GetItemValue("sang"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "gwa", this.layPatientInfo_in.GetItemValue("gwa"));
                                    }
                                    else
                                    {
                                        this.layPatientInfo.SetBindVarValue("f_bunho", bunho);
                                        this.layPatientInfo.QueryLayout();
                                        this.grdIpToi.SetItemValue(e.RowNumber, "suname", this.layPatientInfo.GetItemValue("suname"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "age", this.layPatientInfo.GetItemValue("age"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "sex", this.layPatientInfo.GetItemValue("sex"));
                                    }
                                }
                                else if (this.grdIpToi.GetItemString(e.RowNumber, "gubun") == "02") //퇴원
                                {
                                    this.layPatientInfo_out.SetBindVarValue("f_bunho", bunho);
                                    this.layPatientInfo_out.QueryLayout();

                                    if (this.layPatientInfo_out.GetItemValue("suname").ToString() != "")
                                    {
                                        this.grdIpToi.SetItemValue(e.RowNumber, "ho_code", this.layPatientInfo_out.GetItemValue("ho_code"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "suname", this.layPatientInfo_out.GetItemValue("suname"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "age", this.layPatientInfo_out.GetItemValue("age"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "sex", this.layPatientInfo_out.GetItemValue("sex"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "sang", this.layPatientInfo_out.GetItemValue("sang"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "gwa", this.layPatientInfo_out.GetItemValue("gwa"));
                                    }
                                    else
                                    {
                                        this.layPatientInfo.SetBindVarValue("f_bunho", bunho);
                                        this.layPatientInfo.QueryLayout();
                                        this.grdIpToi.SetItemValue(e.RowNumber, "suname", this.layPatientInfo.GetItemValue("suname"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "age", this.layPatientInfo.GetItemValue("age"));
                                        this.grdIpToi.SetItemValue(e.RowNumber, "sex", this.layPatientInfo.GetItemValue("sex"));
                                    }

                                }
                            }
                            //else
                            //    e.Cancel = true;
                            break;
                    }

                    break;
                #endregion

                #region 転科、転室
                case "grdTrans":
                    switch (e.ColName)
                    {
                        case "bunho":

                            if (this.grdTrans.GetItemString(e.RowNumber, "gubun") == "")
                            {
                                XMessageBox.Show("転科・転室区分を選択してください。", "お知らせ", MessageBoxIcon.Warning);
                                this.grdTrans.SetItemValue(e.RowNumber, "bunho", "");
                                this.grdTrans.SetFocusToItem(e.RowNumber, "gubun");
                                return;
                            }

                            bunho = BizCodeHelper.GetStandardBunHo(bunho);

                            if (bunho != "" && bunho != "000000000")
                            {
                                this.grdTrans.SetItemValue(e.RowNumber, "bunho", bunho);

                                this.layPatientInfo_in.SetBindVarValue("f_bunho", bunho);
                                this.layPatientInfo_in.QueryLayout();

                                if(this.layPatientInfo_in.GetItemValue("suname").ToString() != "")
                                {
                                    this.grdTrans.SetItemValue(e.RowNumber, "to_ho_code", this.layPatientInfo_in.GetItemValue("ho_dong").ToString().Substring(0, 1) + this.layPatientInfo_in.GetItemValue("ho_code").ToString());
                                    this.grdTrans.SetItemValue(e.RowNumber, "to_gwa", this.layPatientInfo_in.GetItemValue("gwa"));
                                    this.grdTrans.SetItemValue(e.RowNumber, "suname", this.layPatientInfo_in.GetItemValue("suname"));
                                    this.grdTrans.SetItemValue(e.RowNumber, "age", this.layPatientInfo_in.GetItemValue("age"));
                                    this.grdTrans.SetItemValue(e.RowNumber, "sex", this.layPatientInfo_in.GetItemValue("sex"));
                                }
                                else
                                {
                                    this.layPatientInfo.SetBindVarValue("f_bunho", bunho);
                                    this.layPatientInfo.QueryLayout();
                                    this.grdTrans.SetItemValue(e.RowNumber, "suname", this.layPatientInfo.GetItemValue("suname"));
                                }
                            }
                            //else
                            //    e.Cancel = true;
                            break;
                    }

                    break;
                #endregion

                #region 褥瘡
                case "grdBedSore":
                    switch (e.ColName)
                    {
                        case "bunho":

                            bunho = BizCodeHelper.GetStandardBunHo(bunho);

                            if (bunho != "" && bunho != "000000000")
                            {
                                this.grdBedSore.SetItemValue(e.RowNumber, "bunho", bunho);

                                this.layPatientInfo_in.SetBindVarValue("f_bunho", bunho);
                                this.layPatientInfo_in.QueryLayout();

                                if (this.layPatientInfo_in.GetItemValue("suname").ToString() != "")
                                {
                                    this.grdBedSore.SetItemValue(e.RowNumber, "ho_code", this.layPatientInfo_in.GetItemValue("ho_code").ToString());
                                    this.grdBedSore.SetItemValue(e.RowNumber, "suname", this.layPatientInfo_in.GetItemValue("suname").ToString());
                                    
                                }
                                else
                                {
                                    this.layPatientInfo.SetBindVarValue("f_bunho", bunho);
                                    this.layPatientInfo.QueryLayout();
                                    this.grdBedSore.SetItemValue(e.RowNumber, "suname", this.layPatientInfo.GetItemValue("suname"));
                                }
                            }
                            //else
                            //    e.Cancel = true;
                            break;
                    }

                    break;
                #endregion

                #region 外出、外泊
                case "grdWoi":

                    switch (e.ColName)
                    {
                        case "bunho":

                            if (this.grdWoi.GetItemString(e.RowNumber, "gubun") == "")
                            {
                                XMessageBox.Show("外出・外泊区分を選択してください。", "お知らせ", MessageBoxIcon.Warning);
                                this.grdWoi.SetItemValue(e.RowNumber, "bunho", "");
                                this.grdWoi.SetFocusToItem(e.RowNumber, "gubun");
                                return;
                            }

                            bunho = BizCodeHelper.GetStandardBunHo(bunho);
                            if (bunho != "" && bunho != "000000000")
                            {
                                this.grdWoi.SetItemValue(e.RowNumber, "bunho", bunho);

                                this.layPatientInfo_in.SetBindVarValue("f_bunho", bunho);
                                this.layPatientInfo_in.QueryLayout();

                                if (this.layPatientInfo_in.GetItemValue("suname").ToString() != "")
                                {
                                    this.grdWoi.SetItemValue(e.RowNumber, "ho_code", this.layPatientInfo_in.GetItemValue("ho_code"));
                                    this.grdWoi.SetItemValue(e.RowNumber, "suname", this.layPatientInfo_in.GetItemValue("suname"));
                                }
                                else
                                {
                                    this.layPatientInfo.SetBindVarValue("f_bunho", bunho);
                                    this.layPatientInfo.QueryLayout();
                                    this.grdWoi.SetItemValue(e.RowNumber, "suname", this.layPatientInfo.GetItemValue("suname"));                           
                                }
                            }
                            //else
                            //    e.Cancel = true;

                            break;

                    }
                    break;
                #endregion

                #region 重症度
                case "grdWatchList":
                    switch (e.ColName)
                    {
                        case "bunho":

                            if (this.grdWatchList.GetItemString(e.RowNumber, "gubun") == "")
                            {
                                XMessageBox.Show("要注意・重症区分を選択してください。", "お知らせ", MessageBoxIcon.Warning);
                                this.grdWatchList.SetItemValue(e.RowNumber, "bunho", "");
                                this.grdWatchList.SetFocusToItem(e.RowNumber, "gubun");
                                return;
                            }

                            bunho = BizCodeHelper.GetStandardBunHo(bunho);
                            if (bunho != "" && bunho != "000000000")
                            {
                                this.grdWatchList.SetItemValue(e.RowNumber, "bunho", bunho);

                                this.layPatientInfo_in.SetBindVarValue("f_bunho", bunho);
                                this.layPatientInfo_in.QueryLayout();

                                if (this.layPatientInfo_in.GetItemValue("suname").ToString() != "")
                                {
                                    this.grdWatchList.SetItemValue(e.RowNumber, "ho_code", this.layPatientInfo_in.GetItemValue("ho_code"));
                                    this.grdWatchList.SetItemValue(e.RowNumber, "suname", this.layPatientInfo_in.GetItemValue("suname"));
                                    this.grdWatchList.SetItemValue(e.RowNumber, "age", this.layPatientInfo_in.GetItemValue("age"));
                                    this.grdWatchList.SetItemValue(e.RowNumber, "sex", this.layPatientInfo_in.GetItemValue("sex"));
                                    this.grdWatchList.SetItemValue(e.RowNumber, "sang", this.layPatientInfo_in.GetItemValue("sang"));
                                    this.grdWatchList.SetItemValue(e.RowNumber, "gwa", this.layPatientInfo_in.GetItemValue("gwa"));


                                }
                                else
                                {
                                    this.layPatientInfo.SetBindVarValue("f_bunho", bunho);
                                    this.layPatientInfo.QueryLayout();
                                    this.grdWatchList.SetItemValue(e.RowNumber, "suname", this.layPatientInfo.GetItemValue("suname"));
                                    this.grdWatchList.SetItemValue(e.RowNumber, "age", this.layPatientInfo.GetItemValue("age"));
                                    this.grdWatchList.SetItemValue(e.RowNumber, "sex", this.layPatientInfo.GetItemValue("sex"));
                                }
                            }
                            //else                                
                            //    e.Cancel = true;

                            break;
                    }
                    break;
                #endregion

                #region 手術
                case "grdSusul":
                    switch (e.ColName)
                    {
                        case "bunho":

                            bunho = BizCodeHelper.GetStandardBunHo(bunho);
                            if (bunho != "" && bunho != "000000000")
                            {
                                this.grdSusul.SetItemValue(e.RowNumber, "bunho", bunho);

                                this.layPatientInfo_in.SetBindVarValue("f_bunho", bunho);
                                this.layPatientInfo_in.QueryLayout();

                                if (this.layPatientInfo_in.GetItemValue("suname").ToString() != "")
                                {
                                    this.grdSusul.SetItemValue(e.RowNumber, "ho_code", this.layPatientInfo_in.GetItemValue("ho_code"));
                                    this.grdSusul.SetItemValue(e.RowNumber, "suname", this.layPatientInfo_in.GetItemValue("suname"));
                                    this.grdSusul.SetItemValue(e.RowNumber, "age", this.layPatientInfo_in.GetItemValue("age"));
                                    this.grdSusul.SetItemValue(e.RowNumber, "sex", this.layPatientInfo_in.GetItemValue("sex"));
                                    this.grdSusul.SetItemValue(e.RowNumber, "sang", this.layPatientInfo_in.GetItemValue("sang"));
                                    this.grdSusul.SetItemValue(e.RowNumber, "gwa", this.layPatientInfo_in.GetItemValue("gwa"));
                                }
                                else
                                {
                                    this.layPatientInfo.SetBindVarValue("f_bunho", bunho);
                                    this.layPatientInfo.QueryLayout();
                                    this.grdSusul.SetItemValue(e.RowNumber, "suname", this.layPatientInfo.GetItemValue("suname"));
                                    this.grdSusul.SetItemValue(e.RowNumber, "age", this.layPatientInfo.GetItemValue("age"));
                                    this.grdSusul.SetItemValue(e.RowNumber, "sex", this.layPatientInfo.GetItemValue("sex"));
                                }

                            }
                            //else
                            //    e.Cancel = true;
                            break;
                    }

                    break;
                #endregion

            }

        }

        private void dtpDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            QueryAll();

            if (DateTime.Parse(dtpDate.GetDataValue()) == EnvironInfo.GetSysDate())
            {
                grdIpToi.Enabled = false;
                grdWoi.Enabled = false;
                grdTrans.Enabled = false;
                grdBedSore.Enabled = false;
                pnlPatient.Enabled = false;
                pnlGamyum.Enabled = false;
                pnlGuho.Enabled = false;
                pnlGwa.Enabled = false;
            }
            else
            {
                grdIpToi.Enabled = true;
                grdWoi.Enabled = true;
                grdTrans.Enabled = true;
                grdBedSore.Enabled = true;
                pnlPatient.Enabled = true;
                pnlGamyum.Enabled = true;
                pnlGuho.Enabled = true;
                pnlGwa.Enabled = true;
            }
        }

        private void cbxLoadNewData_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxConfirm_yn.Checked)
            {
                this.cbxLoadNewData.Checked = false;
                return;
            }
            QueryAll();
        }

        private void layNur5020_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layNur5020.RowCount < 1)
                return;

            //this.emkYesterDay.SetEditValue(this.layNur5020.GetItemValue(0,"yesterday_cnt"));
            //this.emkYesterDay.AcceptData();

            this.emkIpwon.SetEditValue(this.layNur5020.GetItemValue(0, "ipwon_cnt"));
            this.emkIpwon.AcceptData();

            this.emkToiwon.SetEditValue(this.layNur5020.GetItemValue(0, "toiwon_cnt"));
            this.emkToiwon.AcceptData();

            this.emkJaewon.SetEditValue(this.layNur5020.GetItemValue(0, "jaewon_cnt"));
            this.emkJaewon.AcceptData();
            
            this.emkMoveOut.SetEditValue(this.layNur5020.GetItemValue(0, "move_out_cnt"));
            this.emkMoveOut.AcceptData();
            
            this.emkMoveIn.SetEditValue(this.layNur5020.GetItemValue(0, "move_in_cnt"));
            this.emkMoveIn.AcceptData();

            this.emkGamyum1.SetEditValue(this.layNur5020.GetItemValue(0, "gamyum1_cnt"));
            this.emkGamyum1.AcceptData();

            this.emkGamyum2.SetEditValue(this.layNur5020.GetItemValue(0, "gamyum2_cnt"));
            this.emkGamyum2.AcceptData();

            this.emkGamyum3.SetEditValue(this.layNur5020.GetItemValue(0, "gamyum3_cnt"));
            this.emkGamyum3.AcceptData();

            this.emkGamyum4.SetEditValue(this.layNur5020.GetItemValue(0, "gamyum4_cnt"));
            this.emkGamyum4.AcceptData();

            this.emkGamyum5.SetEditValue(this.layNur5020.GetItemValue(0, "gamyum5_cnt"));
            this.emkGamyum5.AcceptData();

            this.emkGamyum6.SetEditValue(this.layNur5020.GetItemValue(0, "gamyum6_cnt"));
            this.emkGamyum6.AcceptData();

            this.txtGamyum6.SetEditValue(this.layNur5020.GetItemValue(0, "gamyum6_name"));
            this.txtGamyum6.AcceptData();

            //this.fbxNurse.SetDataValue(this.layNur5020.GetItemValue(0, "nurse"));
            //this.dbxNurseName.SetDataValue(this.layNur5020.GetItemValue(0, "nurse_name"));
            //this.txtYokchang.SetDataValue(this.layNur5020.GetItemValue(0, "yokchang_comment"));
        }


        private void fbxNurse_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string cmdText = @" SELECT B.USER_NM
                                  FROM ADM3200 B
                                 WHERE HOSP_CODE = :f_hosp_code
                                   AND (B.USER_END_YMD IS NULL
                                    OR SYSDATE < B.USER_END_YMD)
                                   AND B.USER_ID LIKE TRIM(:f_id)||'%'
                                   AND B.USER_GUBUN = '2'
                                   AND B.DEPT_CODE = :f_buseo_code
                                 ";
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_id", e.DataValue);
            bc.Add("f_buseo_code", UserInfo.BuseoCode);

            object nurse_name = Service.ExecuteScalar(cmdText, bc);

            //this.dbxNurseName.SetDataValue("");
            //if (!TypeCheck.IsNull(nurse_name))
           // {
           //     this.dbxNurseName.SetDataValue(nurse_name);
           // }

        }

        private void grd_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            if(e.RowState == DataRowState.Added)
            {
                grd.SetItemValue(e.RowNumber, "nur_wrdt", this.dtpDate.GetDataValue());
                grd.SetItemValue(e.RowNumber, "ho_dong", this.cboBuseo.GetDataValue());
            }
        }

        #region  XSavePerformer

        private class XSavePerformer : ISavePerformer
        {
            NUR5020U00 parent;

            public XSavePerformer(NUR5020U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                

                switch (callerID)
                {
                    case '1':// layNur5020 병상사용정보, 감염증, 욕창

//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                cmdText = @"INSERT INTO NUR5020
//                                             ( SYS_DATE         , SYS_ID        
//                                             , UPD_DATE         , UPD_ID            , HOSP_CODE
//                                             , NUR_WRDT         , HO_DONG           
//                                             , YESTERDAY_CNT    , IPWON_CNT         , MOVE_IN_CNT
//                                             , TOIWON_CNT       , JAEWON_CNT        , MOVE_OUT_CNT
//                                             , GAMYUM1_CNT      , GAMYUM2_CNT
//                                             , GAMYUM3_CNT      , GAMYUM4_CNT
//                                             , GAMYUM5_CNT      , GAMYUM6_CNT
//                                             , GAMYUM7_CNT      , GAMYUM8_CNT
//                                             , GAMYUM6_NAME     , GAMYUM7_NAME      , GAMYUM8_NAME
//                                             , YOKCHANG_NURSE   , YOKCHANG_COMMENT  )
//                                        VALUES
//                                             ( SYSDATE          , :q_user_id
//                                             , SYSDATE          , :q_user_id        , :f_hosp_code
//                                             , :f_nur_wrdt      , :f_ho_dong
//                                             , :f_yesterday_cnt , :f_ipwon_cnt      , :f_move_in_cnt
//                                             , :f_toiwon_cnt    , :f_jaewon_cnt     , :f_move_out_cnt
//                                             , :f_gamyum1_cnt   , :f_gamyum2_cnt
//                                             , :f_gamyum3_cnt   , :f_gamyum4_cnt
//                                             , :f_gamyum5_cnt   , :f_gamyum6_cnt
//                                             , :f_gamyum7_cnt   , :f_gamyum8_cnt
//                                             , :f_gamyum6_name  , :f_gamyum7_name   , :f_gamyum8_name
//                                             , :f_nurse         , :f_yokchang_comment                      )";
//                                break;

//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE NUR5020
//                                           SET UPD_DATE             = SYSDATE
//                                             , UPD_ID               = :q_user_id
//                                             , YESTERDAY_CNT        = :f_yesterday_cnt
//                                             , IPWON_CNT            = :f_ipwon_cnt
//                                             , MOVE_IN_CNT          = :f_move_in_cnt
//                                             , TOIWON_CNT           = :f_toiwon_cnt
//                                             , JAEWON_CNT           = :f_jaewon_cnt
//                                             , MOVE_OUT_CNT         = :f_move_out_cnt
//                                             , GAMYUM1_CNT          = :f_gamyum1_cnt
//                                             , GAMYUM2_CNT          = :f_gamyum2_cnt
//                                             , GAMYUM3_CNT          = :f_gamyum3_cnt
//                                             , GAMYUM4_CNT          = :f_gamyum4_cnt
//                                             , GAMYUM5_CNT          = :f_gamyum5_cnt
//                                             , GAMYUM6_CNT          = :f_gamyum6_cnt
//                                             , GAMYUM7_CNT          = :f_gamyum7_cnt
//                                             , GAMYUM8_CNT          = :f_gamyum8_cnt
//                                             , GAMYUM6_NAME         = :f_gamyum6_name
//                                             , GAMYUM7_NAME         = :f_gamyum7_name
//                                             , GAMYUM8_NAME         = :f_gamyum8_name
//                                             , YOKCHANG_NURSE       = :f_nurse
//                                             , YOKCHANG_COMMENT     = :f_yokchang_comment
//                                         WHERE HOSP_CODE            = :f_hosp_code
//                                           AND NUR_WRDT             = :f_nur_wrdt
//                                           AND HO_DONG              = :f_ho_dong";
//                                break;

//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE NUR5020
//                                             WHERE HOSP_CODE            = :f_hosp_code
//                                               AND NUR_WRDT             = :f_nur_wrdt
//                                               AND HO_DONG              = :f_ho_dong";
//                                break;

//                        }
                        cmdText = @"BEGIN
                                        INSERT INTO NUR5020
                                             ( SYS_DATE         , SYS_ID        
                                             , UPD_DATE         , UPD_ID            , HOSP_CODE
                                             , NUR_WRDT         , HO_DONG           
                                             , YESTERDAY_CNT    , IPWON_CNT         , MOVE_IN_CNT
                                             , TOIWON_CNT       , JAEWON_CNT        , MOVE_OUT_CNT
                                             , GAMYUM1_CNT      , GAMYUM2_CNT
                                             , GAMYUM3_CNT      , GAMYUM4_CNT
                                             , GAMYUM5_CNT      , GAMYUM6_CNT
                                             , GAMYUM7_CNT      , GAMYUM8_CNT
                                             , GAMYUM6_NAME     , GAMYUM7_NAME      , GAMYUM8_NAME
                                             , YOKCHANG_NURSE   , YOKCHANG_COMMENT  )
                                        VALUES
                                             ( SYSDATE          , :q_user_id
                                             , SYSDATE          , :q_user_id        , :f_hosp_code
                                             , :f_nur_wrdt      , :f_ho_dong
                                             , :f_yesterday_cnt , :f_ipwon_cnt      , :f_move_in_cnt
                                             , :f_toiwon_cnt    , :f_jaewon_cnt     , :f_move_out_cnt
                                             , :f_gamyum1_cnt   , :f_gamyum2_cnt
                                             , :f_gamyum3_cnt   , :f_gamyum4_cnt
                                             , :f_gamyum5_cnt   , :f_gamyum6_cnt
                                             , :f_gamyum7_cnt   , :f_gamyum8_cnt
                                             , :f_gamyum6_name  , :f_gamyum7_name   , :f_gamyum8_name
                                             , :f_nurse         , :f_yokchang_comment                      );

                                    EXCEPTION WHEN DUP_VAL_ON_INDEX THEN

                                        UPDATE NUR5020
                                           SET UPD_DATE             = SYSDATE
                                             , UPD_ID               = :q_user_id
                                             , YESTERDAY_CNT        = :f_yesterday_cnt
                                             , IPWON_CNT            = :f_ipwon_cnt
                                             , MOVE_IN_CNT          = :f_move_in_cnt
                                             , TOIWON_CNT           = :f_toiwon_cnt
                                             , JAEWON_CNT           = :f_jaewon_cnt
                                             , MOVE_OUT_CNT         = :f_move_out_cnt
                                             , GAMYUM1_CNT          = :f_gamyum1_cnt
                                             , GAMYUM2_CNT          = :f_gamyum2_cnt
                                             , GAMYUM3_CNT          = :f_gamyum3_cnt
                                             , GAMYUM4_CNT          = :f_gamyum4_cnt
                                             , GAMYUM5_CNT          = :f_gamyum5_cnt
                                             , GAMYUM6_CNT          = :f_gamyum6_cnt
                                             , GAMYUM7_CNT          = :f_gamyum7_cnt
                                             , GAMYUM8_CNT          = :f_gamyum8_cnt
                                             , GAMYUM6_NAME         = :f_gamyum6_name
                                             , GAMYUM7_NAME         = :f_gamyum7_name
                                             , GAMYUM8_NAME         = :f_gamyum8_name
                                             , YOKCHANG_NURSE       = :f_nurse
                                             , YOKCHANG_COMMENT     = :f_yokchang_comment
                                         WHERE HOSP_CODE            = :f_hosp_code
                                           AND NUR_WRDT             = :f_nur_wrdt
                                           AND HO_DONG              = :f_ho_dong;
                                    END;";
                        break;

                    case '2': //구호구분정보

                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO NUR5021
                                             ( SYS_DATE         , SYS_ID        
                                             , UPD_DATE         , UPD_ID            , HOSP_CODE
                                             , NUR_WRDT         , HO_DONG           
                                             , STAIR            , STAIR_NAME        , STAIR_TOTAL_CNT
                                             , DANSONG_CNT      , HOSONG_CNT        , DOKBO_CNT        )
                                        VALUES
                                             ( SYSDATE          , :q_user_id
                                             , SYSDATE          , :q_user_id        , :f_hosp_code
                                             , :f_nur_wrdt      , :f_ho_dong 
                                             , :f_stair         , :f_stair_name     , :f_stair_total_cnt
                                             , :f_dansong_cnt   , :f_hosong_cnt     , :f_dokbo_cnt     )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR5021
                                           SET STAIR            = :f_stair
                                             , STAIR_NAME       = :f_stair_name 
                                             , STAIR_TOTAL_CNT  = :f_stair_total_cnt
                                             , DANSONG_CNT      = :f_dansong_cnt
                                             , HOSONG_CNT       = :f_hosong_cnt
                                             , DOKBO_CNT        = :f_dokbo_cnt
                                         WHERE HOSP_CODE        = :f_hosp_code
                                           AND NUR_WRDT         = :f_nur_wrdt
                                           AND HO_DONG          = :f_ho_dong";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR5021
                                         WHERE HOSP_CODE        = :f_hosp_code
                                           AND NUR_WRDT         = :f_nur_wrdt
                                           AND HO_DONG          = :f_ho_dong";
                                break;

                        }

//                        cmdText = @"BEGIN
//                                        INSERT INTO NUR5021
//                                             ( SYS_DATE         , SYS_ID        
//                                             , UPD_DATE         , UPD_ID            , HOSP_CODE
//                                             , NUR_WRDT         , HO_DONG           
//                                             , STAIR            , STAIR_NAME        , STAIR_TOTAL_CNT
//                                             , DANSONG_CNT      , HOSONG_CNT        , DOKBO_CNT        )
//                                        VALUES
//                                             ( SYSDATE          , :q_user_id
//                                             , SYSDATE          , :q_user_id        , :f_hosp_code
//                                             , :f_nur_wrdt      , :f_ho_dong 
//                                             , :f_stair         , :f_stair_name     , :f_stair_total_cnt
//                                             , :f_dansong_cnt   , :f_hosong_cnt     , :f_dokbo_cnt     );
//
//                                    EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
//
//                                        UPDATE NUR5021
//                                           SET STAIR            = :f_stair
//                                             , STAIR_NAME       = :f_stair_name 
//                                             , STAIR_TOTAL_CNT  = :f_stair_total_cnt
//                                             , DANSONG_CNT      = :f_dansong_cnt
//                                             , HOSONG_CNT       = :f_hosong_cnt
//                                             , DOKBO_CNT        = :f_dokbo_cnt
//                                         WHERE HOSP_CODE        = :f_hosp_code
//                                           AND NUR_WRDT         = :f_nur_wrdt
//                                           AND HO_DONG          = :f_ho_dong ;
//                                    END; ";
                        break;

                    case '3': //외출외박
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO NUR5023
                                         ( SYS_DATE         , SYS_ID            , PKNUR5023
                                         , UPD_DATE         , UPD_ID            , HOSP_CODE
                                         , NUR_WRDT         , HO_DONG           , HO_CODE
                                         , GUBUN            , DETAIL_GUBUN      , BUNHO             
                                         , DATE1            , TIME1       
                                         , DATE2            , TIME2             , BIGO        )
                                    VALUES
                                         ( SYSDATE          , :q_user_id        , NUR5023_SEQ.NEXTVAL
                                         , SYSDATE          , :q_user_id        , :f_hosp_code
                                         , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
                                         , '1'              , :f_gubun          , :f_bunho
                                         , :f_date1         , :f_time1
                                         , :f_date2         , :f_time2          , :f_bigo     )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR5023
                                               SET BUNHO     = :f_bunho
                                                 , HO_CODE   = :f_ho_code
                                                 , DETAIL_GUBUN     = :f_gubun
                                                 , DATE1     = :f_date1
                                                 , TIME1     = :f_time1
                                                 , DATE2     = :f_date2
                                                 , TIME2     = :f_time2
                                                 , BIGO      = :f_bigo
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKNUR5023 = :f_pknur5023";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR5023 
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKNUR5023 = :f_pknur5023";
                                break;

                        }

//                        cmdText = @"INSERT INTO NUR5023
//                                         ( SYS_DATE         , SYS_ID            , PKNUR5023
//                                         , UPD_DATE         , UPD_ID            , HOSP_CODE
//                                         , NUR_WRDT         , HO_DONG           , HO_CODE
//                                         , GUBUN            , DETAIL_GUBUN      , BUNHO             
//                                         , DATE1            , TIME1       
//                                         , DATE2            , TIME2             , BIGO        )
//                                    VALUES
//                                         ( SYSDATE          , :q_user_id        , NUR5023_SEQ.NEXTVAL
//                                         , SYSDATE          , :q_user_id        , :f_hosp_code
//                                         , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
//                                         , '1'              , :f_gubun          , :f_bunho
//                                         , :f_date1         , :f_time1
//                                         , :f_date2         , :f_time2          , :f_bigo     )";
                        break;

                    case '4': //특기사항

                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT NVL(MAX(SEQ), 0) + 1
                                              FROM NUR5025
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND HO_DONG      = :f_ho_dong
                                               AND COMMENT_DATE = :f_nur_wrdt   ";
                                object t_seq = Service.ExecuteScalar(cmdText, item.BindVarList);

                                item.BindVarList.Remove("t_seq");

                                if (!TypeCheck.IsNull(t_seq))
                                    item.BindVarList.Add("t_seq", t_seq.ToString());


                                cmdText = @"INSERT INTO NUR5025
                                                 ( SYS_DATE             , SYS_ID
                                                 , UPD_DATE             , UPD_ID            
                                                 , HOSP_CODE            , HO_DONG 
                                                 , COMMENT_DATE         , REMARK            , SEQ           )
                                            VALUES 
                                                 ( SYSDATE              , :q_user_id
                                                 , SYSDATE              , :q_user_id        
                                                 , :f_hosp_code         , :f_ho_dong
                                                 , :f_nur_wrdt          , :f_comment        , :t_seq        ) ";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE NUR5025
                                               SET UPD_DATE     = SYSDATE
                                                 , UPD_ID       = :q_user_id
                                                 , REMARK       = :f_comment
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND HO_DONG      = :f_ho_dong
                                               AND COMMENT_DATE = :f_nur_wrdt
                                               AND SEQ          = :f_seq     ";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE FROM NUR5025
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND HO_DONG      = :f_ho_dong
                                               AND COMMENT_DATE = :f_nur_wrdt
                                               AND SEQ          = :f_seq     ";

                                break;
                        }

                        break;

                    case '5': //근무상황

                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:

                                cmdText = @"BEGIN

                                            INSERT INTO NUR5027
                                                 ( SYS_DATE             , SYS_ID
                                                 , UPD_DATE             , UPD_ID            
                                                 , HOSP_CODE            , HO_DONG 
                                                 , NUR_WRDT             , NUR_GRADE   
                                                 , DAWN_CNT             , DAY_CNT
                                                 , NIGHT_CNT            , HOLI_CNT
                                                 , PAY_CNT              , CHILDCARE_CNT
                                                 , SPECIAL_CNT          , STUDY_CNT     , ABSENCE_CNT    )
                                            VALUES 
                                                 ( SYSDATE              , :q_user_id
                                                 , SYSDATE              , :q_user_id        
                                                 , :f_hosp_code         , :f_ho_dong
                                                 , :f_nur_wrdt          , :f_nur_grade
                                                 , :f_dawn_cnt          , :f_day_cnt
                                                 , :f_night_cnt         , :f_holi_cnt
                                                 , :f_pay_cnt           , :f_childcare_cnt
                                                 , :f_special_cnt       , :f_study_cnt   , :f_absence_cnt  );

                                            EXCEPTION WHEN DUP_VAL_ON_INDEX THEN

                                            UPDATE NUR5027
                                               SET UPD_DATE         = SYSDATE
                                                 , UPD_ID           = :q_user_id
                                                 , DAWN_CNT         = :f_dawn_cnt
                                                 , DAY_CNT          = :f_day_cnt
                                                 , NIGHT_CNT        = :f_night_cnt
                                                 , HOLI_CNT         = :f_holi_cnt
                                                 , PAY_CNT          = :f_pay_cnt
                                                 , CHILDCARE_CNT    = :f_childcare_cnt
                                                 , SPECIAL_CNT      = :f_special_cnt
                                                 , STUDY_CNT        = :f_study_cnt
                                                 , ABSENCE_CNT      = :f_absence_cnt
                                             WHERE HOSP_CODE        = :f_hosp_code
                                               AND HO_DONG          = :f_ho_dong
                                               AND NUR_WRDT         = :f_nur_wrdt
                                               AND NUR_GRADE        = :f_nur_grade;
                                            
                                            END; ";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE FROM NUR5027
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND HO_DONG    = :f_ho_dong
                                               AND NUR_WRDT   = :f_nur_wrdt
                                               AND NUR_GRADE  = :f_nur_grade";
                                break;
                        }

//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @"INSERT INTO NUR5022
//                                                 ( SYS_DATE             , SYS_ID
//                                                 , UPD_DATE             , UPD_ID            
//                                                 , HOSP_CODE            , HO_DONG 
//                                                 , NUR_WRDT             , NURSE_GRADE       
//                                                 , NURSE_ID             , WORK_TYPE     )
//                                            VALUES 
//                                                 ( SYSDATE              , :q_user_id
//                                                 , SYSDATE              , :q_user_id        
//                                                 , :f_hosp_code         , :f_ho_dong
//                                                 , :f_nur_wrdt          , :f_nurse_grade    
//                                                 , :f_nurse_id          , :f_work_type   ) ";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE NUR5022
//                                               SET UPD_DATE    = SYSDATE
//                                                 , UPD_ID      = :q_user_id
//                                                 , NURSE_GRADE = :f_nurse_grade
//                                                 , WORK_TYPE   = :f_work_type
//                                             WHERE HOSP_CODE   = :f_hosp_code
//                                               AND HO_DONG     = :f_ho_dong
//                                               AND NUR_WRDT    = :f_nur_wrdt
//                                               AND NURSE_ID    = :f_nurse_id ";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE FROM NUR5022
//                                             WHERE HOSP_CODE  = :f_hosp_code
//                                               AND HO_DONG    = :f_ho_dong
//                                               AND NUR_WRDT   = :f_nur_wrdt
//                                               AND NURSE_ID   = :f_nurse_id  ";
//                                break;
//                        }

                        break;

                    case '6': //입원, 퇴원

                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO NUR5023
                                         ( SYS_DATE         , SYS_ID            , PKNUR5023
                                         , UPD_DATE         , UPD_ID            , HOSP_CODE
                                         , NUR_WRDT         , HO_DONG           , HO_CODE
                                         , GUBUN            , DETAIL_GUBUN      
                                         , BUNHO            , GWA             
                                         , SANG             , BIGO        )
                                    VALUES
                                         ( SYSDATE          , :q_user_id        , NUR5023_SEQ.NEXTVAL
                                         , SYSDATE          , :q_user_id        , :f_hosp_code
                                         , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
                                         , '2'              , :f_gubun   
                                         , :f_bunho         , :f_gwa
                                         , SUBSTRB(:f_sang, 1, 100)          , :f_bigo     )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR5023
                                               SET BUNHO     = :f_bunho
                                                 , DETAIL_GUBUN = :f_gubun
                                                 , GWA       = :f_gwa
                                                 , SANG      = SUBSTRB(:f_sang, 1, 100)
                                                 , BIGO      = :f_bigo
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKNUR5023 = :f_pknur5023";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR5023 
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKNUR5023 = :f_pknur5023";
                                break;

                        }


//                        cmdText = @"INSERT INTO NUR5023
//                                         ( SYS_DATE         , SYS_ID            , PKNUR5023
//                                         , UPD_DATE         , UPD_ID            , HOSP_CODE
//                                         , NUR_WRDT         , HO_DONG           , HO_CODE
//                                         , GUBUN            , DETAIL_GUBUN      
//                                         , BUNHO            , GWA             
//                                         , SANG             , BIGO        )
//                                    VALUES
//                                         ( SYSDATE          , :q_user_id        , NUR5023_SEQ.NEXTVAL
//                                         , SYSDATE          , :q_user_id        , :f_hosp_code
//                                         , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
//                                         , '2'              , :f_gubun   
//                                         , :f_bunho         , :f_gwa
//                                         , SUBSTRB(:f_sang, 1, 100)          , :f_bigo     )";

                        break;

                    case '7': //전과, 전실

                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO NUR5023
                                         ( SYS_DATE         , SYS_ID            , PKNUR5023
                                         , UPD_DATE         , UPD_ID            , HOSP_CODE
                                         , NUR_WRDT         , HO_DONG           , HO_CODE
                                         , GUBUN            , DETAIL_GUBUN      , BUNHO            
                                         , FROM_GWA         , TO_GWA
                                         , FROM_HO_CODE     , TO_HO_CODE            )
                                    VALUES
                                         ( SYSDATE          , :q_user_id        , NUR5023_SEQ.NEXTVAL
                                         , SYSDATE          , :q_user_id        , :f_hosp_code
                                         , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
                                         , '3'              , :f_gubun          , :f_bunho
                                         , :f_from_gwa      , :f_to_gwa
                                         , :f_from_ho_code  , :f_to_ho_code    )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR5023
                                               SET BUNHO        = :f_bunho
                                                 , DETAIL_GUBUN = :f_gubun
                                                 , FROM_GWA     = :f_from_gwa
                                                 , TO_GWA       = :f_to_gwa
                                                 , FROM_HO_CODE = :f_from_ho_code
                                                 , TO_HO_CODE   = :f_to_ho_code
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND PKNUR5023    = :f_pknur5023";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR5023 
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKNUR5023 = :f_pknur5023";
                                break;

                        }

//                        cmdText = @"INSERT INTO NUR5023
//                                         ( SYS_DATE         , SYS_ID            , PKNUR5023
//                                         , UPD_DATE         , UPD_ID            , HOSP_CODE
//                                         , NUR_WRDT         , HO_DONG           , HO_CODE
//                                         , GUBUN            , DETAIL_GUBUN      , BUNHO            
//                                         , FROM_GWA         , TO_GWA
//                                         , FROM_HO_CODE     , TO_HO_CODE            )
//                                    VALUES
//                                         ( SYSDATE          , :q_user_id        , NUR5023_SEQ.NEXTVAL
//                                         , SYSDATE          , :q_user_id        , :f_hosp_code
//                                         , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
//                                         , '3'              , :f_gubun          , :f_bunho
//                                         , :f_from_gwa      , :f_to_gwa
//                                         , :f_from_ho_code  , :f_to_ho_code    )";

                        break;

                    case '8': //수술
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO NUR5024
                                             ( SYS_DATE         , SYS_ID        
                                             , UPD_DATE         , UPD_ID            , HOSP_CODE
                                             , NUR_WRDT         , HO_DONG           , HO_CODE
                                             , GUBUN            , DETAIL_GUBUN      , BUNHO            
                                             , SANG             , SULSIK            , GWA
                                             , COMMENT1         , COMMENT2          , COMMENT3      )
                                        VALUES
                                             ( SYSDATE          , :q_user_id
                                             , SYSDATE          , :q_user_id        , :f_hosp_code
                                             , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
                                             , '1'              , '1'               , :f_bunho
                                             , SUBSTRB(:f_sang, 1, 500)          , :f_susul          , :f_gwa
                                             , :f_state1        , :f_state2         , :f_state3)";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR5024
                                               SET UPD_DATE         = SYSDATE
                                                 , UPD_ID           = :q_user_id 
                                                 , HO_CODE          = :f_ho_code
                                                 , SANG             = SUBSTRB(:f_sang, 1, 500) 
                                                 , SULSIK           = :f_susul
                                                 , GWA              = :f_gwa
                                                 , COMMENT1         = :f_state1
                                                 , COMMENT2         = :f_state2
                                                 , COMMENT3         = :f_state3
                                             WHERE HOSP_CODE        = :f_hosp_code
                                               AND NUR_WRDT         = :f_nur_wrdt
                                               AND HO_DONG          = :f_ho_dong
                                               AND GUBUN            = '1'
                                               AND DETAIL_GUBUN     = '1'
                                               AND BUNHO            = :f_bunho";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR5024
                                             WHERE HOSP_CODE        = :f_hosp_code
                                               AND NUR_WRDT         = :f_nur_wrdt
                                               AND HO_DONG          = :f_ho_dong
                                               AND GUBUN            = '1'
                                               AND DETAIL_GUBUN     = '1'
                                               AND BUNHO            = :f_bunho";
                                break;

                        }



                            
                    break;

                    case '9': //요주의, 중상
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO NUR5024
                                             ( SYS_DATE         , SYS_ID        
                                             , UPD_DATE         , UPD_ID            , HOSP_CODE
                                             , NUR_WRDT         , HO_DONG           , HO_CODE
                                             , GUBUN            , DETAIL_GUBUN      , BUNHO            
                                             , SANG             , SULSIK            , GWA
                                             , COMMENT1         , COMMENT2          , COMMENT3      )
                                        VALUES
                                             ( SYSDATE          , :q_user_id
                                             , SYSDATE          , :q_user_id        , :f_hosp_code
                                             , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
                                             , '2'              , :f_gubun          , :f_bunho
                                             , SUBSTRB(:f_sang, 1, 500)          , :f_susul          , :f_gwa
                                             , :f_state1        , :f_state2         , :f_state3)";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR5024
                                               SET UPD_DATE         = SYSDATE
                                                 , UPD_ID           = :q_user_id 
                                                 , HO_CODE          = :f_ho_code
                                                 , SANG             = SUBSTRB(:f_sang, 1, 500) 
                                                 , SULSIK           = :f_susul
                                                 , GWA              = :f_gwa
                                                 , COMMENT1         = :f_state1
                                                 , COMMENT2         = :f_state2
                                                 , COMMENT3         = :f_state3
                                             WHERE HOSP_CODE        = :f_hosp_code
                                               AND NUR_WRDT         = :f_nur_wrdt
                                               AND HO_DONG          = :f_ho_dong
                                               AND GUBUN            = '2'
                                               AND DETAIL_GUBUN     = :f_gubun
                                               AND BUNHO            = :f_bunho";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR5024
                                             WHERE HOSP_CODE        = :f_hosp_code
                                               AND NUR_WRDT         = :f_nur_wrdt
                                               AND HO_DONG          = :f_ho_dong
                                               AND GUBUN            = '2'
                                               AND DETAIL_GUBUN     = :f_gubun
                                               AND BUNHO            = :f_bunho";
                                break;
                        }
                        break;

                    case 'A': //과별 환자 수

//                        cmdText = @" INSERT INTO NUR5026
//                                                  ( SYS_DATE         , SYS_ID        
//                                                  , UPD_DATE         , UPD_ID            , HOSP_CODE
//                                                  , NUR_WRDT         , HO_DONG           
//                                                  , GWA              , GWA_NAME          , PA_CNT)
//                                             VALUES
//                                                  ( SYSDATE          , :q_user_id
//                                                  , SYSDATE          , :q_user_id        , :f_hosp_code
//                                                  , :f_nur_wrdt      , :f_ho_dong
//                                                  , :f_gwa           , :f_gwa_name       , :f_pa_cnt )";

                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @" INSERT INTO NUR5026
                                                  ( SYS_DATE         , SYS_ID        
                                                  , UPD_DATE         , UPD_ID            , HOSP_CODE
                                                  , NUR_WRDT         , HO_DONG           
                                                  , GWA              , GWA_NAME          , PA_CNT)
                                             VALUES
                                                  ( SYSDATE          , :q_user_id
                                                  , SYSDATE          , :q_user_id        , :f_hosp_code
                                                  , :f_nur_wrdt      , :f_ho_dong
                                                  , :f_gwa           , :f_gwa_name       , :f_pa_cnt )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE NUR5026
                                               SET UPD_DATE    = SYSDATE
                                                 , UPD_ID      = :q_user_id
                                                 , PA_CNT      = :f_pa_cnt
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND HO_DONG     = :f_ho_dong
                                               AND NUR_WRDT    = :f_nur_wrdt
                                               AND GWA         = :f_gwa";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE FROM NUR5026
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND HO_DONG     = :f_ho_dong
                                               AND NUR_WRDT    = :f_nur_wrdt
                                               AND GWA         = :f_gwa";
                                break;
                        }

                        break;
 
                    case 'B': //욕창 관리


                                                
//                            cmdText = @" INSERT INTO NUR5028
//                                                  ( SYS_DATE         , SYS_ID        
//                                                  , UPD_DATE         , UPD_ID            , HOSP_CODE
//                                                  , NUR_WRDT         , HO_DONG           , HO_CODE
//                                                  , BUNHO            , FROM_DATE         , BUWI)
//                                              VALUES
//                                                  ( SYSDATE          , :q_user_id
//                                                  , SYSDATE          , :q_user_id        , :f_hosp_code
//                                                  , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
//                                                  , :f_bunho         , :f_from_date      , :f_buwi)";

                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @" INSERT INTO NUR5028
                                                  ( SYS_DATE         , SYS_ID        
                                                  , UPD_DATE         , UPD_ID            , HOSP_CODE
                                                  , NUR_WRDT         , HO_DONG           , HO_CODE
                                                  , BUNHO            , FROM_DATE         , BUWI)
                                              VALUES
                                                  ( SYSDATE          , :q_user_id
                                                  , SYSDATE          , :q_user_id        , :f_hosp_code
                                                  , :f_nur_wrdt      , :f_ho_dong        , :f_ho_code
                                                  , :f_bunho         , :f_from_date      , :f_buwi)";
                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE NUR5028
                                               SET UPD_DATE    = SYSDATE
                                                 , UPD_ID      = :q_user_id
                                                 , BUWI        = :f_buwi
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND HO_DONG     = :f_ho_dong
                                               AND NUR_WRDT    = :f_nur_wrdt
                                               AND BUNHO       = :f_bunho
                                               AND FROM_DATE   = :f_from_date";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE FROM NUR5028
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND HO_DONG     = :f_ho_dong
                                               AND NUR_WRDT    = :f_nur_wrdt
                                               AND BUNHO       = :f_bunho
                                               AND FROM_DATE   = :f_from_date";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        #endregion

        private void grdNURCnt_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            SumNurseCount(e.RowNumber);
        }

        private void grd_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.DataRow["gubun"].ToString() == "" && e.ColName == "bunho")
                e.Protect = true;
            else
                e.Protect = false;
        }

        private void grd_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            if (e.ColName == "gubun")
                grid.SetFocusToItem(e.RowNumber, "bunho");
        }

        private void grdGwa_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {           
            if (e.ColName == "gwa")
            {
                for(int i = 0; i < grdGwa.RowCount; i++)
                {
                    if (i != e.RowNumber && e.ReturnValues.GetValue(0).Equals(grdGwa.GetItemValue(i, "gwa")))
                    {
                        XMessageBox.Show("既に存在する科です。", "エラー", MessageBoxIcon.Error);
                        grdGwa.SetItemValue(e.RowNumber, e.ColName, "");
                        return;
                    }
                }

                grdGwa.SetItemValue(e.RowNumber, "gwa_name", e.ReturnValues.GetValue(1).ToString());
                grdGwa.SetFocusToItem(e.RowNumber, "pa_cnt");
            }
        }
    }
}