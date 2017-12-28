#region 사용 NameSpace 지정
using System;
using System.IO;
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
	/// NUR6001U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR6001U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private bool isPatient = false;		//환자번호 유효성여부
		//Message처리
		string mbxMsg = "", mbxCap = "";
		private string FindName = string.Empty;
		private string sDate     = string.Empty;
		private string mPopupClick = string.Empty; //팝업클릭주체
		#endregion

		#region 팝엄메뉴 코드 관리
		IHIS.X.Magic.Menus.PopupMenu popMenu = new IHIS.X.Magic.Menus.PopupMenu();	//팝업메뉴
		private ArrayList jobCodeList = new ArrayList();

		private class JobItem
		{
			public int Code = 0;
			public string CodeName = "";
			public JobItem(int code, string codeName)
			{
				this.Code = code;
				this.CodeName = codeName;
			}
		}
		#endregion

		#region 자동생성 변수
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
        private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XButton btnInsert;
		private IHIS.Framework.XButton btnSave;
		private IHIS.Framework.XButton btnDelete;
		private IHIS.Framework.XEditGrid grdNur6001;
		private IHIS.Framework.XLabel labDepth;
		private IHIS.Framework.XRadioButton xRadioButton1;
		private IHIS.Framework.XRadioButton xRadioButton2;
		private IHIS.Framework.XRadioButton xRadioButton3;
		private IHIS.Framework.XRadioButton xRadioButton4;
		private IHIS.Framework.XRadioButton xRadioButton5;
		private IHIS.Framework.XLabel labExdate;
		private IHIS.Framework.XLabel xLabel22;
		private IHIS.Framework.XLabel xLabel23;
		private IHIS.Framework.XLabel xLabel24;
		private IHIS.Framework.XLabel xLabel25;
        private IHIS.Framework.XLabel xLabel31;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XPatientBox ptbPatient;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XCalendar calBedsore;
		private IHIS.Framework.MultiLayout layCalendar;
		private IHIS.Framework.MultiLayout layNur6002_del;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
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
		private IHIS.Framework.XFindBox fbAssessor;
		private System.Windows.Forms.ImageList imageList1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdNur6002;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XTextBox txtAssessor;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XLabel xLabel32;
		private IHIS.Framework.XLabel xLabel36;
		private IHIS.Framework.XDatePicker dtpAssessor_date;
        private IHIS.Framework.XTabControl tabBuwi;
		private IHIS.Framework.MultiLayout layMonthNur6002;
		private IHIS.Framework.XEditGrid grdImage;
		private System.Windows.Forms.Panel panel3;
		private IHIS.Framework.XLabel xLabel37;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XButton btnImageAdd;
		private IHIS.Framework.XButton btnImageDelete;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XLabel xLabel40;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell61;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XPanel pnlInfo;
		private IHIS.Framework.XPanel pnlImage;
		private IHIS.Framework.XButton btnNur6001Query;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private System.Windows.Forms.ImageList jobImageList;
		private IHIS.Framework.XCheckBox chkEndYn;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XButton btnMatress;
		private IHIS.Framework.XMemoBox mbMetress;
		private IHIS.Framework.MultiLayout layComboSet;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
		private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell67;
		private IHIS.Framework.XLabel xLabel51;
		private IHIS.Framework.XComboBox cboFirst_sayu;
		private IHIS.Framework.XLabel xLabel52;
		private IHIS.Framework.XComboBox cboLast_sayu;
		private IHIS.Framework.XRadioButton xRadioButton7;
		private IHIS.Framework.XLabel xLabel53;
		private IHIS.Framework.XLabel xLabel54;
		private IHIS.Framework.XRadioButton xRadioButton8;
		private IHIS.Framework.XGroupBox gbxYokchang_deep;
		private IHIS.Framework.XGroupBox gbxSamchul_yang;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XRadioButton xRadioButton12;
		private IHIS.Framework.XRadioButton xRadioButton13;
		private IHIS.Framework.XRadioButton xRadioButton17;
		private IHIS.Framework.XRadioButton xRadioButton18;
		private IHIS.Framework.XRadioButton xRadioButton19;
		private IHIS.Framework.XLabel labSize;
		private IHIS.Framework.XGroupBox gbxYokchang_size;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XRadioButton xRadioButton9;
		private IHIS.Framework.XRadioButton xRadioButton10;
		private IHIS.Framework.XRadioButton xRadioButton23;
		private IHIS.Framework.XRadioButton xRadioButton24;
		private IHIS.Framework.XRadioButton xRadioButton25;
		private IHIS.Framework.XRadioButton xRadioButton26;
		private IHIS.Framework.XRadioButton xRadioButton27;
		private IHIS.Framework.XRadioButton xRadioButton28;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XLabel labInf;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XLabel xLabel17;
		private IHIS.Framework.XRadioButton xRadioButton29;
		private IHIS.Framework.XRadioButton xRadioButton30;
		private IHIS.Framework.XRadioButton xRadioButton31;
		private IHIS.Framework.XRadioButton xRadioButton32;
		private IHIS.Framework.XRadioButton xRadioButton33;
		private IHIS.Framework.XGroupBox gbxYokchang_gamyum;
		private IHIS.Framework.XLabel labGranulation;
		private IHIS.Framework.XGroupBox gbxYukajojik;
		private IHIS.Framework.XLabel xLabel19;
		private IHIS.Framework.XLabel xLabel29;
		private IHIS.Framework.XRadioButton xRadioButton34;
		private IHIS.Framework.XRadioButton xRadioButton35;
		private IHIS.Framework.XRadioButton xRadioButton36;
		private IHIS.Framework.XRadioButton xRadioButton37;
		private IHIS.Framework.XRadioButton xRadioButton38;
		private IHIS.Framework.XRadioButton xRadioButton39;
		private IHIS.Framework.XRadioButton xRadioButton40;
		private IHIS.Framework.XLabel labNT;
		private IHIS.Framework.XGroupBox gbxGaesajojik;
		private IHIS.Framework.XLabel xLabel12;
		private IHIS.Framework.XLabel xLabel13;
		private IHIS.Framework.XRadioButton xRadioButton11;
		private IHIS.Framework.XRadioButton xRadioButton14;
		private IHIS.Framework.XRadioButton xRadioButton15;
		private IHIS.Framework.XRadioButton xRadioButton16;
		private IHIS.Framework.XLabel labPocket;
		private IHIS.Framework.XGroupBox gbxPocket_gubun;
		private IHIS.Framework.XLabel xLabel15;
		private IHIS.Framework.XRadioButton xRadioButton20;
		private IHIS.Framework.XRadioButton xRadioButton21;
		private IHIS.Framework.XRadioButton xRadioButton22;
		private IHIS.Framework.XRadioButton xRadioButton41;
		private IHIS.Framework.XRadioButton xRadioButton42;
		private IHIS.Framework.XRadioButton xRadioButton43;
		private IHIS.Framework.XLabel xLabel20;
		private IHIS.Framework.XEditMask emkYokchang_hb;
		private IHIS.Framework.XEditMask emkYokchang_alb;
		private IHIS.Framework.XEditMask emkYokchang_Tp;
		private IHIS.Framework.XTextBox txtChuchi_text;
		private IHIS.Framework.XLabel xLabel21;
		private IHIS.Framework.XLabel xLabel28;
		private IHIS.Framework.XLabel xLabel16;
		private IHIS.Framework.XEditMask emkYokchang_size_start;
		private IHIS.Framework.XEditMask emkYokchang_size_end;
		private IHIS.Framework.XEditMask emkTotal_count;
		private IHIS.Framework.XLabel xLabel27;
		private IHIS.Framework.XGroupBox gbxYokchang_stage;
		private IHIS.Framework.XRadioButton xRadioButton44;
		private IHIS.Framework.XRadioButton xRadioButton45;
		private IHIS.Framework.XRadioButton xRadioButton46;
		private IHIS.Framework.XRadioButton xRadioButton47;
		private IHIS.Framework.XRadioButton xRadioButton48;
		private IHIS.Framework.XLabel xLabel30;
		private IHIS.Framework.XLabel xLabel33;
		private IHIS.Framework.XGroupBox gbxYungyang_siksa_gubun;
		private IHIS.Framework.XLabel xLabel38;
		private IHIS.Framework.XRadioButton xRadioButton6;
		private IHIS.Framework.XRadioButton xRadioButton49;
		private IHIS.Framework.XRadioButton xRadioButton50;
		private IHIS.Framework.XRadioButton xRadioButton51;
		private IHIS.Framework.XEditMask emkYunayang_siksa_yang;
		private IHIS.Framework.XLabel xLabel34;
		private IHIS.Framework.XLabel xLabel39;
		private IHIS.Framework.XLabel xLabel41;
		private IHIS.Framework.XButton btnWeight;
		private IHIS.Framework.XDisplayBox dpbWeight;
		private IHIS.Framework.XLabel xLabel26;
		private IHIS.Framework.XDatePicker dtpIpwon;
		private IHIS.Framework.XEditMask emkYungyang_siksa_percent;
		private IHIS.Framework.XEditMask emkPocket_size_end;
		private IHIS.Framework.XEditMask emkPocket_size_start;
		private IHIS.Framework.XEditGridCell xEditGridCell68;
		private IHIS.Framework.XEditGridCell xEditGridCell69;
		private IHIS.Framework.XEditGridCell xEditGridCell70;
		private IHIS.Framework.XEditGridCell xEditGridCell71;
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
		private IHIS.Framework.XEditGridCell xEditGridCell83;
		private IHIS.Framework.XEditGridCell xEditGridCell84;
		private IHIS.Framework.XEditGridCell xEditGridCell85;
		private IHIS.Framework.XEditGridCell xEditGridCell86;
		private IHIS.Framework.XEditGridCell xEditGridCell87;
		private IHIS.Framework.XEditGridCell xEditGridCell88;
		private IHIS.Framework.XEditGridCell xEditGridCell89;
		private IHIS.Framework.XEditGridCell xEditGridCell90;
		private IHIS.Framework.XEditGridCell xEditGridCell91;
		private IHIS.Framework.XLabel xLabel42;
		private IHIS.Framework.XGroupBox gbxYungyang_suaek_yn;
		private IHIS.Framework.XRadioButton xRadioButton54;
		private IHIS.Framework.XRadioButton xRadioButton55;
		private IHIS.Framework.XRadioButton xRadioButton56;
		private IHIS.Framework.XLabel xLabel43;
		private IHIS.Framework.XEditMask emkYungyang_suaek_yang;
		private IHIS.Framework.XEditGridCell xEditGridCell92;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private XFindWorker fwkAssessor;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XEditGridCell xEditGridCell93;
        private System.ComponentModel.IContainer components;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
		#endregion

        #region FTP 관련사항
        private string strServer = EnvironInfo.GetDownloadServerIP();
        private string strFtpUser = "";
        private string strFtpPass = "";

        private string strServerPath = "";//"/home/medi/IHIS/NURIImages/";
        private string strClientPath = "";//"C:\\IHIS\\NURIImages\\";
        private ToolTip toolTip1;
        private XPanel xPanel5;
        private XLabel xLabel1;
        private XPanel xPanel6;
        private XLabel xLabel4;
        private XPanel xPanel7;
        private XLabel xLabel8;
        private XPanel pnlMain;
        private XDisplayBox dpbLifeselfgrade;
        private XLabel xLabel10;
        private XButton btnPrint;
        private XEditGrid grdPrint;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell102;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell103;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell106;
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
        private XEditGridCell xEditGridCell118;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell120;
        private XEditGridCell xEditGridCell121;
        private XEditGridCell xEditGridCell122;
        private XEditGridCell xEditGridCell123;
        private XDataWindow dwPrint;
        private XEditGridCell xEditGridCell124;
        private XEditGridCell xEditGridCell125;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell127;
        private MultiLayout layImage;
        private MultiLayoutItem multiLayoutItem6;
        private XEditGridCell xEditGridCell128;
        private MultiLayout layPrintLoad;
        private MultiLayoutItem multiLayoutItem7;
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
        private MultiLayoutItem multiLayoutItem75;
        private XEditGrid grdNur6002Copy;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell130;
        private XEditGridCell xEditGridCell131;
        private XEditGridCell xEditGridCell132;
        private XEditGridCell xEditGridCell133;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell144;
        private XEditGridCell xEditGridCell145;
        private XEditGridCell xEditGridCell146;
        private XEditGridCell xEditGridCell147;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell149;
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
        private XEditGridCell xEditGridCell181;
        private XEditGridCell xEditGridCell182;
        private XEditGridCell xEditGridCell183;
        private XEditGridCell xEditGridCell184;
        private XEditGridCell xEditGridCell185;
        private XEditGridCell xEditGridCell186;
        private XEditGridCell xEditGridCell187;
        private XEditGridCell xEditGridCell188;
        private XEditGridCell xEditGridCell189;
        private XEditGridCell xEditGridCell190;
        private XEditGridCell xEditGridCell191;
        private XEditGridCell xEditGridCell192;
        private XEditGridCell xEditGridCell193;
        private XEditGridCell xEditGridCell194;
        private XEditGridCell xEditGridCell195;
        private XEditGridCell xEditGridCell196;
        private XTextBox txtBedSore_gita;
        private XLabel xLabel11;
        //private string strBaseImagePath = "";
        private XEditGridCell xEditGridCell94;

        //private string Seq = "";
        #endregion

		#region 생성자 및 소멸자
		public NUR6001U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdNur6001.SavePerformer = new XSavePerformer(this);
            this.grdNur6002.SavePerformer = grdNur6001.SavePerformer;
            this.grdImage.SavePerformer = grdNur6001.SavePerformer;
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdNur6001);
            this.SaveLayoutList.Add(this.grdNur6002);
            this.SaveLayoutList.Add(this.grdImage);
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
		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR6001U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dwPrint = new IHIS.Framework.XDataWindow();
            this.ptbPatient = new IHIS.Framework.XPatientBox();
            this.grdPrint = new IHIS.Framework.XEditGrid();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdNur6002Copy = new IHIS.Framework.XEditGrid();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.dtpAssessor_date = new IHIS.Framework.XDatePicker();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.fbAssessor = new IHIS.Framework.XFindBox();
            this.fwkAssessor = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
            this.txtAssessor = new IHIS.Framework.XTextBox();
            this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell160 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell165 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.chkEndYn = new IHIS.Framework.XCheckBox();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell168 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell169 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell171 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell172 = new IHIS.Framework.XEditGridCell();
            this.cboFirst_sayu = new IHIS.Framework.XComboBox();
            this.xEditGridCell173 = new IHIS.Framework.XEditGridCell();
            this.cboLast_sayu = new IHIS.Framework.XComboBox();
            this.xEditGridCell174 = new IHIS.Framework.XEditGridCell();
            this.gbxYokchang_deep = new IHIS.Framework.XGroupBox();
            this.xLabel54 = new IHIS.Framework.XLabel();
            this.xLabel53 = new IHIS.Framework.XLabel();
            this.xRadioButton7 = new IHIS.Framework.XRadioButton();
            this.xRadioButton5 = new IHIS.Framework.XRadioButton();
            this.xRadioButton4 = new IHIS.Framework.XRadioButton();
            this.xRadioButton3 = new IHIS.Framework.XRadioButton();
            this.xRadioButton2 = new IHIS.Framework.XRadioButton();
            this.xRadioButton1 = new IHIS.Framework.XRadioButton();
            this.xRadioButton8 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell175 = new IHIS.Framework.XEditGridCell();
            this.gbxSamchul_yang = new IHIS.Framework.XGroupBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xRadioButton12 = new IHIS.Framework.XRadioButton();
            this.xRadioButton13 = new IHIS.Framework.XRadioButton();
            this.xRadioButton17 = new IHIS.Framework.XRadioButton();
            this.xRadioButton18 = new IHIS.Framework.XRadioButton();
            this.xRadioButton19 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell176 = new IHIS.Framework.XEditGridCell();
            this.gbxYokchang_size = new IHIS.Framework.XGroupBox();
            this.xRadioButton28 = new IHIS.Framework.XRadioButton();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xRadioButton9 = new IHIS.Framework.XRadioButton();
            this.xRadioButton10 = new IHIS.Framework.XRadioButton();
            this.xRadioButton23 = new IHIS.Framework.XRadioButton();
            this.xRadioButton24 = new IHIS.Framework.XRadioButton();
            this.xRadioButton25 = new IHIS.Framework.XRadioButton();
            this.xRadioButton26 = new IHIS.Framework.XRadioButton();
            this.xRadioButton27 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell177 = new IHIS.Framework.XEditGridCell();
            this.emkYokchang_size_start = new IHIS.Framework.XEditMask();
            this.xEditGridCell178 = new IHIS.Framework.XEditGridCell();
            this.emkYokchang_size_end = new IHIS.Framework.XEditMask();
            this.xEditGridCell179 = new IHIS.Framework.XEditGridCell();
            this.gbxYokchang_gamyum = new IHIS.Framework.XGroupBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xRadioButton29 = new IHIS.Framework.XRadioButton();
            this.xRadioButton30 = new IHIS.Framework.XRadioButton();
            this.xRadioButton31 = new IHIS.Framework.XRadioButton();
            this.xRadioButton32 = new IHIS.Framework.XRadioButton();
            this.xRadioButton33 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
            this.gbxYukajojik = new IHIS.Framework.XGroupBox();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.xRadioButton34 = new IHIS.Framework.XRadioButton();
            this.xRadioButton35 = new IHIS.Framework.XRadioButton();
            this.xRadioButton36 = new IHIS.Framework.XRadioButton();
            this.xRadioButton37 = new IHIS.Framework.XRadioButton();
            this.xRadioButton38 = new IHIS.Framework.XRadioButton();
            this.xRadioButton39 = new IHIS.Framework.XRadioButton();
            this.xRadioButton40 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
            this.gbxGaesajojik = new IHIS.Framework.XGroupBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xRadioButton11 = new IHIS.Framework.XRadioButton();
            this.xRadioButton14 = new IHIS.Framework.XRadioButton();
            this.xRadioButton15 = new IHIS.Framework.XRadioButton();
            this.xRadioButton16 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell182 = new IHIS.Framework.XEditGridCell();
            this.gbxPocket_gubun = new IHIS.Framework.XGroupBox();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xRadioButton20 = new IHIS.Framework.XRadioButton();
            this.xRadioButton21 = new IHIS.Framework.XRadioButton();
            this.xRadioButton22 = new IHIS.Framework.XRadioButton();
            this.xRadioButton41 = new IHIS.Framework.XRadioButton();
            this.xRadioButton42 = new IHIS.Framework.XRadioButton();
            this.xRadioButton43 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell183 = new IHIS.Framework.XEditGridCell();
            this.emkPocket_size_start = new IHIS.Framework.XEditMask();
            this.xEditGridCell184 = new IHIS.Framework.XEditGridCell();
            this.emkPocket_size_end = new IHIS.Framework.XEditMask();
            this.xEditGridCell185 = new IHIS.Framework.XEditGridCell();
            this.gbxYokchang_stage = new IHIS.Framework.XGroupBox();
            this.xRadioButton44 = new IHIS.Framework.XRadioButton();
            this.xRadioButton45 = new IHIS.Framework.XRadioButton();
            this.xRadioButton46 = new IHIS.Framework.XRadioButton();
            this.xRadioButton47 = new IHIS.Framework.XRadioButton();
            this.xRadioButton48 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell186 = new IHIS.Framework.XEditGridCell();
            this.emkTotal_count = new IHIS.Framework.XEditMask();
            this.xEditGridCell187 = new IHIS.Framework.XEditGridCell();
            this.gbxYungyang_siksa_gubun = new IHIS.Framework.XGroupBox();
            this.xLabel38 = new IHIS.Framework.XLabel();
            this.xRadioButton6 = new IHIS.Framework.XRadioButton();
            this.xRadioButton49 = new IHIS.Framework.XRadioButton();
            this.xRadioButton50 = new IHIS.Framework.XRadioButton();
            this.xRadioButton51 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell188 = new IHIS.Framework.XEditGridCell();
            this.emkYunayang_siksa_yang = new IHIS.Framework.XEditMask();
            this.xEditGridCell189 = new IHIS.Framework.XEditGridCell();
            this.emkYungyang_siksa_percent = new IHIS.Framework.XEditMask();
            this.xEditGridCell190 = new IHIS.Framework.XEditGridCell();
            this.gbxYungyang_suaek_yn = new IHIS.Framework.XGroupBox();
            this.xRadioButton54 = new IHIS.Framework.XRadioButton();
            this.xRadioButton55 = new IHIS.Framework.XRadioButton();
            this.xRadioButton56 = new IHIS.Framework.XRadioButton();
            this.xEditGridCell191 = new IHIS.Framework.XEditGridCell();
            this.emkYungyang_suaek_yang = new IHIS.Framework.XEditMask();
            this.xEditGridCell192 = new IHIS.Framework.XEditGridCell();
            this.txtChuchi_text = new IHIS.Framework.XTextBox();
            this.xEditGridCell193 = new IHIS.Framework.XEditGridCell();
            this.emkYokchang_hb = new IHIS.Framework.XEditMask();
            this.xEditGridCell194 = new IHIS.Framework.XEditGridCell();
            this.emkYokchang_alb = new IHIS.Framework.XEditMask();
            this.xEditGridCell195 = new IHIS.Framework.XEditGridCell();
            this.emkYokchang_Tp = new IHIS.Framework.XEditMask();
            this.xEditGridCell196 = new IHIS.Framework.XEditGridCell();
            this.dpbWeight = new IHIS.Framework.XDisplayBox();
            this.grdNur6002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.txtBedSore_gita = new IHIS.Framework.XTextBox();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.btnPrint = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.calBedsore = new IHIS.Framework.XCalendar();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.dpbLifeselfgrade = new IHIS.Framework.XDisplayBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.mbMetress = new IHIS.Framework.XMemoBox();
            this.btnMatress = new IHIS.Framework.XButton();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdNur6001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.btnNur6001Query = new IHIS.Framework.XButton();
            this.btnInsert = new IHIS.Framework.XButton();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnSave = new IHIS.Framework.XButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabBuwi = new IHIS.Framework.XTabControl();
            this.labDepth = new IHIS.Framework.XLabel();
            this.labExdate = new IHIS.Framework.XLabel();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.pnlInfo = new IHIS.Framework.XPanel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel43 = new IHIS.Framework.XLabel();
            this.xLabel42 = new IHIS.Framework.XLabel();
            this.dtpIpwon = new IHIS.Framework.XDatePicker();
            this.btnWeight = new IHIS.Framework.XButton();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel41 = new IHIS.Framework.XLabel();
            this.xLabel39 = new IHIS.Framework.XLabel();
            this.xLabel34 = new IHIS.Framework.XLabel();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.xLabel30 = new IHIS.Framework.XLabel();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.labPocket = new IHIS.Framework.XLabel();
            this.labNT = new IHIS.Framework.XLabel();
            this.labGranulation = new IHIS.Framework.XLabel();
            this.labInf = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.labSize = new IHIS.Framework.XLabel();
            this.xLabel52 = new IHIS.Framework.XLabel();
            this.xLabel51 = new IHIS.Framework.XLabel();
            this.xLabel40 = new IHIS.Framework.XLabel();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.xLabel32 = new IHIS.Framework.XLabel();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.grdImage = new IHIS.Framework.XEditGrid();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.layCalendar = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.layNur6002_del = new IHIS.Framework.MultiLayout();
            this.layMonthNur6002 = new IHIS.Framework.MultiLayout();
            this.pnlImage = new IHIS.Framework.XPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnImageAdd = new IHIS.Framework.XButton();
            this.btnImageDelete = new IHIS.Framework.XButton();
            this.xLabel37 = new IHIS.Framework.XLabel();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.jobImageList = new System.Windows.Forms.ImageList(this.components);
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain = new IHIS.Framework.XPanel();
            this.layImage = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.layPrintLoad = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem75 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrint)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur6002Copy)).BeginInit();
            this.gbxYokchang_deep.SuspendLayout();
            this.gbxSamchul_yang.SuspendLayout();
            this.gbxYokchang_size.SuspendLayout();
            this.gbxYokchang_gamyum.SuspendLayout();
            this.gbxYukajojik.SuspendLayout();
            this.gbxGaesajojik.SuspendLayout();
            this.gbxPocket_gubun.SuspendLayout();
            this.gbxYokchang_stage.SuspendLayout();
            this.gbxYungyang_siksa_gubun.SuspendLayout();
            this.gbxYungyang_suaek_yn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur6002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calBedsore)).BeginInit();
            this.xPanel6.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur6001)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNur6002_del)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMonthNur6002)).BeginInit();
            this.pnlImage.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPrintLoad)).BeginInit();
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
            this.ImageList.Images.SetKeyName(9, "출력.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.dwPrint);
            this.xPanel1.Controls.Add(this.ptbPatient);
            this.xPanel1.Controls.Add(this.grdPrint);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(5, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1007, 33);
            this.xPanel1.TabIndex = 0;
            // 
            // dwPrint
            // 
            this.dwPrint.DataWindowObject = "printnur6001u00";
            this.dwPrint.LibraryList = "..\\NURI\\nuri.nur6001u00.pbd";
            this.dwPrint.Location = new System.Drawing.Point(391, 4);
            this.dwPrint.Name = "dwPrint";
            this.dwPrint.Size = new System.Drawing.Size(0, 0);
            this.dwPrint.TabIndex = 2;
            this.dwPrint.Text = "xDataWindow1";
            // 
            // ptbPatient
            // 
            this.ptbPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbPatient.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptbPatient.Location = new System.Drawing.Point(0, 0);
            this.ptbPatient.Name = "ptbPatient";
            this.ptbPatient.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.ptbPatient.Size = new System.Drawing.Size(1007, 33);
            this.ptbPatient.TabIndex = 0;
            this.ptbPatient.PatientSelectionFailed += new System.EventHandler(this.xPatientBox1_PatientSelectionFailed);
            this.ptbPatient.PatientSelected += new System.EventHandler(this.xPatientBox1_PatientSelected);
            // 
            // grdPrint
            // 
            this.grdPrint.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell101,
            this.xEditGridCell102,
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
            this.xEditGridCell123,
            this.xEditGridCell124,
            this.xEditGridCell125,
            this.xEditGridCell126,
            this.xEditGridCell128,
            this.xEditGridCell127});
            this.grdPrint.ColPerLine = 34;
            this.grdPrint.Cols = 34;
            this.grdPrint.FixedRows = 1;
            this.grdPrint.HeaderHeights.Add(21);
            this.grdPrint.Location = new System.Drawing.Point(602, -38);
            this.grdPrint.Name = "grdPrint";
            this.grdPrint.QuerySQL = resources.GetString("grdPrint.QuerySQL");
            this.grdPrint.Rows = 2;
            this.grdPrint.Size = new System.Drawing.Size(100, 100);
            this.grdPrint.TabIndex = 1;
            this.grdPrint.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPrint_QueryEnd);
            this.grdPrint.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPrint_QueryStarting);
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "bunho";
            this.xEditGridCell95.CellWidth = 45;
            this.xEditGridCell95.HeaderText = "bunho";
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "name";
            this.xEditGridCell96.CellWidth = 62;
            this.xEditGridCell96.Col = 1;
            this.xEditGridCell96.HeaderText = "name";
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "name2";
            this.xEditGridCell97.CellWidth = 54;
            this.xEditGridCell97.Col = 2;
            this.xEditGridCell97.HeaderText = "name2";
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "gender";
            this.xEditGridCell98.CellWidth = 64;
            this.xEditGridCell98.Col = 3;
            this.xEditGridCell98.HeaderText = "gender";
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "birth";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell99.CellWidth = 55;
            this.xEditGridCell99.Col = 4;
            this.xEditGridCell99.HeaderText = "birth";
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "age";
            this.xEditGridCell100.CellWidth = 14;
            this.xEditGridCell100.Col = 5;
            this.xEditGridCell100.HeaderText = "age";
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "buwi";
            this.xEditGridCell103.CellWidth = 31;
            this.xEditGridCell103.Col = 8;
            this.xEditGridCell103.HeaderText = "buwi";
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "from_date";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell104.CellWidth = 24;
            this.xEditGridCell104.Col = 9;
            this.xEditGridCell104.HeaderText = "from_date";
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "assessor";
            this.xEditGridCell101.CellWidth = 13;
            this.xEditGridCell101.Col = 6;
            this.xEditGridCell101.HeaderText = "assessor";
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "assessor_date";
            this.xEditGridCell102.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell102.CellWidth = 22;
            this.xEditGridCell102.Col = 7;
            this.xEditGridCell102.HeaderText = "assessor_date";
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "depth";
            this.xEditGridCell105.CellWidth = 27;
            this.xEditGridCell105.Col = 10;
            this.xEditGridCell105.HeaderText = "depth";
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "exudate";
            this.xEditGridCell106.CellWidth = 22;
            this.xEditGridCell106.Col = 11;
            this.xEditGridCell106.HeaderText = "exudate";
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "s_size";
            this.xEditGridCell107.CellWidth = 23;
            this.xEditGridCell107.Col = 12;
            this.xEditGridCell107.HeaderText = "s_size";
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "infection";
            this.xEditGridCell108.CellWidth = 15;
            this.xEditGridCell108.Col = 13;
            this.xEditGridCell108.HeaderText = "infection";
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "granulation";
            this.xEditGridCell109.CellWidth = 21;
            this.xEditGridCell109.Col = 14;
            this.xEditGridCell109.HeaderText = "granulation";
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "necrotic_tissue";
            this.xEditGridCell110.CellWidth = 28;
            this.xEditGridCell110.Col = 15;
            this.xEditGridCell110.HeaderText = "necrotic_tissue";
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "pocket";
            this.xEditGridCell111.CellWidth = 27;
            this.xEditGridCell111.Col = 16;
            this.xEditGridCell111.HeaderText = "pocket";
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "total";
            this.xEditGridCell112.CellWidth = 24;
            this.xEditGridCell112.Col = 17;
            this.xEditGridCell112.HeaderText = "total";
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "stage";
            this.xEditGridCell113.CellWidth = 24;
            this.xEditGridCell113.Col = 18;
            this.xEditGridCell113.HeaderText = "stage";
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "yungyang_siksa_gubun";
            this.xEditGridCell114.CellWidth = 16;
            this.xEditGridCell114.Col = 19;
            this.xEditGridCell114.HeaderText = "yungyang_siksa_gubyungyang_sik";
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "yungyang_siksa_yang";
            this.xEditGridCell115.CellWidth = 25;
            this.xEditGridCell115.Col = 20;
            this.xEditGridCell115.HeaderText = "yungyang_siksa_percent";
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "yungyang_siksa_percent";
            this.xEditGridCell116.CellWidth = 18;
            this.xEditGridCell116.Col = 21;
            this.xEditGridCell116.HeaderText = "yungyang_siksa_percent";
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "yungyang_suaek_yn";
            this.xEditGridCell117.CellWidth = 26;
            this.xEditGridCell117.Col = 22;
            this.xEditGridCell117.HeaderText = "yungyang_suaek_yn";
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "yungyang_suaek_yang";
            this.xEditGridCell118.CellWidth = 34;
            this.xEditGridCell118.Col = 23;
            this.xEditGridCell118.HeaderText = "yungyang_suaek_yang";
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "chuchi_text";
            this.xEditGridCell119.CellWidth = 40;
            this.xEditGridCell119.Col = 24;
            this.xEditGridCell119.HeaderText = "chuchi_text";
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "yokchang_hb";
            this.xEditGridCell120.CellWidth = 70;
            this.xEditGridCell120.Col = 25;
            this.xEditGridCell120.HeaderText = "yokchang_hb";
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "yokchang_alb";
            this.xEditGridCell121.CellWidth = 20;
            this.xEditGridCell121.Col = 26;
            this.xEditGridCell121.HeaderText = "yokchang_alb";
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "yokchang_tp";
            this.xEditGridCell122.CellWidth = 68;
            this.xEditGridCell122.Col = 27;
            this.xEditGridCell122.HeaderText = "yokchang_tp";
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "yokchang_weight";
            this.xEditGridCell123.CellWidth = 27;
            this.xEditGridCell123.Col = 28;
            this.xEditGridCell123.HeaderText = "yokchang_weight";
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "ipwon_date";
            this.xEditGridCell124.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell124.CellWidth = 46;
            this.xEditGridCell124.Col = 29;
            this.xEditGridCell124.HeaderText = "ipwon_date";
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "ho_dong";
            this.xEditGridCell125.CellWidth = 51;
            this.xEditGridCell125.Col = 30;
            this.xEditGridCell125.HeaderText = "ho_dong";
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "ho_code";
            this.xEditGridCell126.CellWidth = 57;
            this.xEditGridCell126.Col = 31;
            this.xEditGridCell126.HeaderText = "ho_code";
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "bedsore_buwi";
            this.xEditGridCell128.CellWidth = 30;
            this.xEditGridCell128.Col = 32;
            this.xEditGridCell128.HeaderText = "bedsore_buwi";
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "image";
            this.xEditGridCell127.CellWidth = 415;
            this.xEditGridCell127.Col = 33;
            this.xEditGridCell127.HeaderText = "image";
            this.xEditGridCell127.IsReadOnly = true;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdNur6002Copy);
            this.xPanel2.Controls.Add(this.grdNur6002);
            this.xPanel2.Controls.Add(this.btnPrint);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(5, 705);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1007, 35);
            this.xPanel2.TabIndex = 1;
            // 
            // grdNur6002Copy
            // 
            this.grdNur6002Copy.CallerID = '2';
            this.grdNur6002Copy.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell129,
            this.xEditGridCell130,
            this.xEditGridCell131,
            this.xEditGridCell132,
            this.xEditGridCell133,
            this.xEditGridCell134,
            this.xEditGridCell135,
            this.xEditGridCell136,
            this.xEditGridCell137,
            this.xEditGridCell138,
            this.xEditGridCell139,
            this.xEditGridCell140,
            this.xEditGridCell141,
            this.xEditGridCell142,
            this.xEditGridCell143,
            this.xEditGridCell144,
            this.xEditGridCell145,
            this.xEditGridCell146,
            this.xEditGridCell147,
            this.xEditGridCell148,
            this.xEditGridCell149,
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
            this.xEditGridCell170,
            this.xEditGridCell171,
            this.xEditGridCell172,
            this.xEditGridCell173,
            this.xEditGridCell174,
            this.xEditGridCell175,
            this.xEditGridCell176,
            this.xEditGridCell177,
            this.xEditGridCell178,
            this.xEditGridCell179,
            this.xEditGridCell180,
            this.xEditGridCell181,
            this.xEditGridCell182,
            this.xEditGridCell183,
            this.xEditGridCell184,
            this.xEditGridCell185,
            this.xEditGridCell186,
            this.xEditGridCell187,
            this.xEditGridCell188,
            this.xEditGridCell189,
            this.xEditGridCell190,
            this.xEditGridCell191,
            this.xEditGridCell192,
            this.xEditGridCell193,
            this.xEditGridCell194,
            this.xEditGridCell195,
            this.xEditGridCell196});
            this.grdNur6002Copy.ColPerLine = 68;
            this.grdNur6002Copy.Cols = 68;
            this.grdNur6002Copy.ControlBinding = true;
            this.grdNur6002Copy.FixedRows = 1;
            this.grdNur6002Copy.HeaderHeights.Add(21);
            this.grdNur6002Copy.Location = new System.Drawing.Point(446, -80);
            this.grdNur6002Copy.Name = "grdNur6002Copy";
            this.grdNur6002Copy.QuerySQL = resources.GetString("grdNur6002Copy.QuerySQL");
            this.grdNur6002Copy.Rows = 2;
            this.grdNur6002Copy.Size = new System.Drawing.Size(114, 72);
            this.grdNur6002Copy.TabIndex = 66;
            this.grdNur6002Copy.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNur6002Copy_QueryStarting);
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellLen = 9;
            this.xEditGridCell129.CellName = "bunho";
            this.xEditGridCell129.CellWidth = 82;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "from_date";
            this.xEditGridCell130.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell130.CellWidth = 79;
            this.xEditGridCell130.Col = 1;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellLen = 1;
            this.xEditGridCell131.CellName = "bedsore_buwi";
            this.xEditGridCell131.Col = 2;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.BindControl = this.dtpAssessor_date;
            this.xEditGridCell132.CellName = "assessor_date";
            this.xEditGridCell132.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell132.Col = 3;
            this.xEditGridCell132.InvalidDateIsStringEmpty = false;
            this.xEditGridCell132.IsReadOnly = true;
            // 
            // dtpAssessor_date
            // 
            this.dtpAssessor_date.IsJapanYearType = true;
            this.dtpAssessor_date.Location = new System.Drawing.Point(92, 30);
            this.dtpAssessor_date.Name = "dtpAssessor_date";
            this.dtpAssessor_date.Size = new System.Drawing.Size(108, 20);
            this.dtpAssessor_date.TabIndex = 103;
            this.dtpAssessor_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpAssessor_date_DataValidating);
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.BindControl = this.fbAssessor;
            this.xEditGridCell133.CellLen = 8;
            this.xEditGridCell133.CellName = "assessor";
            this.xEditGridCell133.Col = 4;
            // 
            // fbAssessor
            // 
            this.fbAssessor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbAssessor.FindWorker = this.fwkAssessor;
            this.fbAssessor.Location = new System.Drawing.Point(270, 30);
            this.fbAssessor.Name = "fbAssessor";
            this.fbAssessor.Size = new System.Drawing.Size(83, 20);
            this.fbAssessor.TabIndex = 104;
            this.fbAssessor.FindSelected += new IHIS.Framework.FindEventHandler(this.fbAssessor_FindSelected);
            // 
            // fwkAssessor
            // 
            this.fwkAssessor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkAssessor.FormText = "評価者リスト";
            this.fwkAssessor.InputSQL = resources.GetString("fwkAssessor.InputSQL");
            this.fwkAssessor.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkAssessor_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "assessor";
            this.findColumnInfo3.HeaderText = "USER ID";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "assessor_name";
            this.findColumnInfo4.HeaderText = "評価者";
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellLen = 2;
            this.xEditGridCell134.CellName = "bedsore_deep";
            this.xEditGridCell134.Col = 5;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "bedsore_depth";
            this.xEditGridCell135.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell135.Col = 6;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellLen = 1;
            this.xEditGridCell136.CellName = "bedsore_color";
            this.xEditGridCell136.Col = 7;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "bedsore_size1";
            this.xEditGridCell137.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell137.Col = 8;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "bedsore_size_start1";
            this.xEditGridCell138.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell138.Col = 9;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "bedsore_size_finish1";
            this.xEditGridCell139.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell139.Col = 10;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "bedsore_poket1";
            this.xEditGridCell140.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell140.Col = 11;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "bedsore_poket_start1";
            this.xEditGridCell141.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell141.Col = 12;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "bedsore_poket_finish1";
            this.xEditGridCell142.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell142.Col = 13;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellLen = 1;
            this.xEditGridCell143.CellName = "bedsore_death";
            this.xEditGridCell143.Col = 14;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellLen = 1;
            this.xEditGridCell144.CellName = "exudation_volume";
            this.xEditGridCell144.Col = 15;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellLen = 1;
            this.xEditGridCell145.CellName = "exudation_state";
            this.xEditGridCell145.Col = 24;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellLen = 50;
            this.xEditGridCell146.CellName = "exudation_color";
            this.xEditGridCell146.Col = 16;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellLen = 50;
            this.xEditGridCell147.CellName = "exudation_smell";
            this.xEditGridCell147.Col = 17;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellLen = 50;
            this.xEditGridCell148.CellName = "bedsore_skin";
            this.xEditGridCell148.Col = 18;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellLen = 1;
            this.xEditGridCell149.CellName = "bedsore_infe";
            this.xEditGridCell149.Col = 19;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellLen = 1;
            this.xEditGridCell150.CellName = "bedsore_moist";
            this.xEditGridCell150.Col = 20;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "bedsore_moist_rate";
            this.xEditGridCell151.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell151.Col = 21;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellLen = 200;
            this.xEditGridCell152.CellName = "bedsore_gita";
            this.xEditGridCell152.Col = 22;
            this.xEditGridCell152.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellLen = 50;
            this.xEditGridCell153.CellName = "bedsore_nut";
            this.xEditGridCell153.Col = 25;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellName = "bedsore_hb";
            this.xEditGridCell154.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell154.Col = 26;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "bedsore_alb";
            this.xEditGridCell155.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell155.Col = 27;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "bedsore_fbs";
            this.xEditGridCell156.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell156.Col = 28;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "bedsore_zn";
            this.xEditGridCell157.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell157.Col = 29;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.BindControl = this.txtAssessor;
            this.xEditGridCell158.CellLen = 30;
            this.xEditGridCell158.CellName = "assessor_name";
            this.xEditGridCell158.Col = 23;
            this.xEditGridCell158.IsUpdatable = false;
            this.xEditGridCell158.IsUpdCol = false;
            // 
            // txtAssessor
            // 
            this.txtAssessor.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.txtAssessor.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtAssessor.Location = new System.Drawing.Point(354, 30);
            this.txtAssessor.Name = "txtAssessor";
            this.txtAssessor.Size = new System.Drawing.Size(144, 20);
            this.txtAssessor.TabIndex = 66;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellName = "bedsore_size2";
            this.xEditGridCell159.Col = 30;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "bedre_size_start2";
            this.xEditGridCell160.Col = 34;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellName = "bedsore_size_finish2";
            this.xEditGridCell161.Col = 35;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "bedsore_poket2";
            this.xEditGridCell162.Col = 33;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellName = "bedsore_poket_start2";
            this.xEditGridCell163.Col = 31;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellName = "bedsore_poket_finish2";
            this.xEditGridCell164.Col = 32;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.CellName = "weight";
            this.xEditGridCell165.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell165.Col = 36;
            this.xEditGridCell165.IsUpdCol = false;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.BindControl = this.chkEndYn;
            this.xEditGridCell166.CellName = "end_yn";
            this.xEditGridCell166.Col = 37;
            // 
            // chkEndYn
            // 
            this.chkEndYn.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.chkEndYn.Location = new System.Drawing.Point(646, 2);
            this.chkEndYn.Name = "chkEndYn";
            this.chkEndYn.Size = new System.Drawing.Size(96, 24);
            this.chkEndYn.TabIndex = 91;
            this.chkEndYn.Text = "完治";
            this.chkEndYn.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "exudation_state1";
            this.xEditGridCell167.Col = 38;
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellName = "exudation_state2";
            this.xEditGridCell168.Col = 39;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellLen = 1;
            this.xEditGridCell169.CellName = "bedsore_color2";
            this.xEditGridCell169.Col = 40;
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellLen = 1;
            this.xEditGridCell170.CellName = "bedsore_color3";
            this.xEditGridCell170.Col = 41;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellLen = 1;
            this.xEditGridCell171.CellName = "bedsore_color4";
            this.xEditGridCell171.Col = 42;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.BindControl = this.cboFirst_sayu;
            this.xEditGridCell172.CellName = "first_sayu";
            this.xEditGridCell172.Col = 43;
            this.xEditGridCell172.HeaderText = "first_sayu";
            // 
            // cboFirst_sayu
            // 
            this.cboFirst_sayu.Location = new System.Drawing.Point(239, 1);
            this.cboFirst_sayu.Name = "cboFirst_sayu";
            this.cboFirst_sayu.Size = new System.Drawing.Size(113, 21);
            this.cboFirst_sayu.TabIndex = 101;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.BindControl = this.cboLast_sayu;
            this.xEditGridCell173.CellName = "last_sayu";
            this.xEditGridCell173.Col = 44;
            this.xEditGridCell173.HeaderText = "last_sayu";
            // 
            // cboLast_sayu
            // 
            this.cboLast_sayu.Location = new System.Drawing.Point(389, 1);
            this.cboLast_sayu.Name = "cboLast_sayu";
            this.cboLast_sayu.Size = new System.Drawing.Size(109, 21);
            this.cboLast_sayu.TabIndex = 102;
            // 
            // xEditGridCell174
            // 
            this.xEditGridCell174.BindControl = this.gbxYokchang_deep;
            this.xEditGridCell174.CellName = "yokchang_deep";
            this.xEditGridCell174.Col = 45;
            this.xEditGridCell174.HeaderText = "yokchang_deep";
            // 
            // gbxYokchang_deep
            // 
            this.gbxYokchang_deep.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxYokchang_deep.Controls.Add(this.xLabel54);
            this.gbxYokchang_deep.Controls.Add(this.xLabel53);
            this.gbxYokchang_deep.Controls.Add(this.xRadioButton7);
            this.gbxYokchang_deep.Controls.Add(this.xRadioButton5);
            this.gbxYokchang_deep.Controls.Add(this.xRadioButton4);
            this.gbxYokchang_deep.Controls.Add(this.xRadioButton3);
            this.gbxYokchang_deep.Controls.Add(this.xRadioButton2);
            this.gbxYokchang_deep.Controls.Add(this.xRadioButton1);
            this.gbxYokchang_deep.Controls.Add(this.xRadioButton8);
            this.gbxYokchang_deep.Location = new System.Drawing.Point(92, 53);
            this.gbxYokchang_deep.Name = "gbxYokchang_deep";
            this.gbxYokchang_deep.Size = new System.Drawing.Size(406, 30);
            this.gbxYokchang_deep.TabIndex = 1;
            this.gbxYokchang_deep.TabStop = false;
            // 
            // xLabel54
            // 
            this.xLabel54.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel54.Location = new System.Drawing.Point(180, 7);
            this.xLabel54.Name = "xLabel54";
            this.xLabel54.Size = new System.Drawing.Size(22, 20);
            this.xLabel54.TabIndex = 7;
            this.xLabel54.Text = "D";
            this.xLabel54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel53
            // 
            this.xLabel53.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel53.Location = new System.Drawing.Point(4, 7);
            this.xLabel53.Name = "xLabel53";
            this.xLabel53.Size = new System.Drawing.Size(22, 20);
            this.xLabel53.TabIndex = 6;
            this.xLabel53.Text = "d";
            this.xLabel53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xRadioButton7
            // 
            this.xRadioButton7.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton7.CheckedValue = "5";
            this.xRadioButton7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton7.Location = new System.Drawing.Point(300, 8);
            this.xRadioButton7.Name = "xRadioButton7";
            this.xRadioButton7.Size = new System.Drawing.Size(33, 18);
            this.xRadioButton7.TabIndex = 5;
            this.xRadioButton7.Tag = "5";
            this.xRadioButton7.Text = "5";
            this.toolTip1.SetToolTip(this.xRadioButton7, "関節腔、体腔に至る損傷または､深さ判定が不能の場合");
            this.xRadioButton7.UseVisualStyleBackColor = false;
            this.xRadioButton7.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton5
            // 
            this.xRadioButton5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton5.CheckedValue = "4";
            this.xRadioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton5.Location = new System.Drawing.Point(251, 8);
            this.xRadioButton5.Name = "xRadioButton5";
            this.xRadioButton5.Size = new System.Drawing.Size(45, 18);
            this.xRadioButton5.TabIndex = 4;
            this.xRadioButton5.Tag = "4";
            this.xRadioButton5.Text = "4";
            this.toolTip1.SetToolTip(this.xRadioButton5, "皮下組織を越える損傷");
            this.xRadioButton5.UseVisualStyleBackColor = false;
            this.xRadioButton5.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton4
            // 
            this.xRadioButton4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton4.CheckedValue = "3";
            this.xRadioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton4.Location = new System.Drawing.Point(203, 8);
            this.xRadioButton4.Name = "xRadioButton4";
            this.xRadioButton4.Size = new System.Drawing.Size(42, 18);
            this.xRadioButton4.TabIndex = 3;
            this.xRadioButton4.Tag = "3";
            this.xRadioButton4.Text = "3";
            this.toolTip1.SetToolTip(this.xRadioButton4, "皮下組織までの損傷");
            this.xRadioButton4.UseVisualStyleBackColor = false;
            this.xRadioButton4.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton3
            // 
            this.xRadioButton3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton3.CheckedValue = "2";
            this.xRadioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton3.Location = new System.Drawing.Point(153, 8);
            this.xRadioButton3.Name = "xRadioButton3";
            this.xRadioButton3.Size = new System.Drawing.Size(26, 18);
            this.xRadioButton3.TabIndex = 2;
            this.xRadioButton3.Tag = "2";
            this.xRadioButton3.Text = "2";
            this.toolTip1.SetToolTip(this.xRadioButton3, "真皮までの損傷");
            this.xRadioButton3.UseVisualStyleBackColor = false;
            this.xRadioButton3.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton2
            // 
            this.xRadioButton2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton2.CheckedValue = "1";
            this.xRadioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton2.Location = new System.Drawing.Point(104, 8);
            this.xRadioButton2.Name = "xRadioButton2";
            this.xRadioButton2.Size = new System.Drawing.Size(41, 18);
            this.xRadioButton2.TabIndex = 1;
            this.xRadioButton2.Tag = "1";
            this.xRadioButton2.Text = "1";
            this.toolTip1.SetToolTip(this.xRadioButton2, "持続する発赤");
            this.xRadioButton2.UseVisualStyleBackColor = false;
            this.xRadioButton2.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton1
            // 
            this.xRadioButton1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton1.CheckedValue = "0";
            this.xRadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton1.Location = new System.Drawing.Point(28, 8);
            this.xRadioButton1.Name = "xRadioButton1";
            this.xRadioButton1.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton1.TabIndex = 0;
            this.xRadioButton1.Tag = "0";
            this.xRadioButton1.Text = "0(なし)";
            this.toolTip1.SetToolTip(this.xRadioButton1, "皮膚損傷・発赤なし");
            this.xRadioButton1.UseVisualStyleBackColor = false;
            this.xRadioButton1.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton8
            // 
            this.xRadioButton8.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton8.CheckedValue = "1";
            this.xRadioButton8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton8.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton8.Name = "xRadioButton8";
            this.xRadioButton8.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton8.TabIndex = 1;
            this.xRadioButton8.Text = "1";
            this.xRadioButton8.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.BindControl = this.gbxSamchul_yang;
            this.xEditGridCell175.CellName = "samchul_yang";
            this.xEditGridCell175.Col = 46;
            this.xEditGridCell175.HeaderText = "samchul_yang";
            // 
            // gbxSamchul_yang
            // 
            this.gbxSamchul_yang.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxSamchul_yang.Controls.Add(this.xLabel2);
            this.gbxSamchul_yang.Controls.Add(this.xLabel3);
            this.gbxSamchul_yang.Controls.Add(this.xRadioButton12);
            this.gbxSamchul_yang.Controls.Add(this.xRadioButton13);
            this.gbxSamchul_yang.Controls.Add(this.xRadioButton17);
            this.gbxSamchul_yang.Controls.Add(this.xRadioButton18);
            this.gbxSamchul_yang.Controls.Add(this.xRadioButton19);
            this.gbxSamchul_yang.Location = new System.Drawing.Point(92, 82);
            this.gbxSamchul_yang.Name = "gbxSamchul_yang";
            this.gbxSamchul_yang.Size = new System.Drawing.Size(406, 30);
            this.gbxSamchul_yang.TabIndex = 2;
            this.gbxSamchul_yang.TabStop = false;
            // 
            // xLabel2
            // 
            this.xLabel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel2.Location = new System.Drawing.Point(180, 7);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(22, 20);
            this.xLabel2.TabIndex = 7;
            this.xLabel2.Text = "E";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel3
            // 
            this.xLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel3.Location = new System.Drawing.Point(4, 7);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(22, 20);
            this.xLabel3.TabIndex = 6;
            this.xLabel3.Text = "e";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xRadioButton12
            // 
            this.xRadioButton12.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton12.CheckedValue = "3";
            this.xRadioButton12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton12.Location = new System.Drawing.Point(203, 8);
            this.xRadioButton12.Name = "xRadioButton12";
            this.xRadioButton12.Size = new System.Drawing.Size(42, 18);
            this.xRadioButton12.TabIndex = 3;
            this.xRadioButton12.Tag = "3";
            this.xRadioButton12.Text = "3";
            this.toolTip1.SetToolTip(this.xRadioButton12, "多量：1日２回以上のドレッシング交換を要する");
            this.xRadioButton12.UseVisualStyleBackColor = false;
            this.xRadioButton12.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton13
            // 
            this.xRadioButton13.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton13.CheckedValue = "2";
            this.xRadioButton13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton13.Location = new System.Drawing.Point(153, 8);
            this.xRadioButton13.Name = "xRadioButton13";
            this.xRadioButton13.Size = new System.Drawing.Size(26, 18);
            this.xRadioButton13.TabIndex = 2;
            this.xRadioButton13.Tag = "2";
            this.xRadioButton13.Text = "2";
            this.toolTip1.SetToolTip(this.xRadioButton13, "中等量：1日1回のドレッシング交換を要する");
            this.xRadioButton13.UseVisualStyleBackColor = false;
            this.xRadioButton13.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton17
            // 
            this.xRadioButton17.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton17.CheckedValue = "1";
            this.xRadioButton17.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton17.Location = new System.Drawing.Point(104, 8);
            this.xRadioButton17.Name = "xRadioButton17";
            this.xRadioButton17.Size = new System.Drawing.Size(43, 18);
            this.xRadioButton17.TabIndex = 1;
            this.xRadioButton17.Tag = "1";
            this.xRadioButton17.Text = "1";
            this.toolTip1.SetToolTip(this.xRadioButton17, "少量：毎日のドレッシング交換を要しない");
            this.xRadioButton17.UseVisualStyleBackColor = false;
            this.xRadioButton17.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton18
            // 
            this.xRadioButton18.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton18.CheckedValue = "0";
            this.xRadioButton18.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton18.Location = new System.Drawing.Point(28, 8);
            this.xRadioButton18.Name = "xRadioButton18";
            this.xRadioButton18.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton18.TabIndex = 0;
            this.xRadioButton18.Tag = "0";
            this.xRadioButton18.Text = "0(なし)";
            this.toolTip1.SetToolTip(this.xRadioButton18, "なし");
            this.xRadioButton18.UseVisualStyleBackColor = false;
            this.xRadioButton18.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton19
            // 
            this.xRadioButton19.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton19.CheckedValue = "1";
            this.xRadioButton19.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton19.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton19.Name = "xRadioButton19";
            this.xRadioButton19.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton19.TabIndex = 1;
            this.xRadioButton19.Text = "1";
            this.xRadioButton19.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.BindControl = this.gbxYokchang_size;
            this.xEditGridCell176.CellName = "yokchang_size";
            this.xEditGridCell176.Col = 47;
            this.xEditGridCell176.HeaderText = "yokchang_size";
            // 
            // gbxYokchang_size
            // 
            this.gbxYokchang_size.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxYokchang_size.Controls.Add(this.xRadioButton28);
            this.gbxYokchang_size.Controls.Add(this.xLabel5);
            this.gbxYokchang_size.Controls.Add(this.xLabel6);
            this.gbxYokchang_size.Controls.Add(this.xRadioButton9);
            this.gbxYokchang_size.Controls.Add(this.xRadioButton10);
            this.gbxYokchang_size.Controls.Add(this.xRadioButton23);
            this.gbxYokchang_size.Controls.Add(this.xRadioButton24);
            this.gbxYokchang_size.Controls.Add(this.xRadioButton25);
            this.gbxYokchang_size.Controls.Add(this.xRadioButton26);
            this.gbxYokchang_size.Controls.Add(this.xRadioButton27);
            this.gbxYokchang_size.Location = new System.Drawing.Point(92, 133);
            this.gbxYokchang_size.Name = "gbxYokchang_size";
            this.gbxYokchang_size.Size = new System.Drawing.Size(406, 30);
            this.gbxYokchang_size.TabIndex = 3;
            this.gbxYokchang_size.TabStop = false;
            // 
            // xRadioButton28
            // 
            this.xRadioButton28.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton28.CheckedValue = "6";
            this.xRadioButton28.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton28.Location = new System.Drawing.Point(349, 8);
            this.xRadioButton28.Name = "xRadioButton28";
            this.xRadioButton28.Size = new System.Drawing.Size(32, 18);
            this.xRadioButton28.TabIndex = 8;
            this.xRadioButton28.Tag = "6";
            this.xRadioButton28.Text = "6";
            this.toolTip1.SetToolTip(this.xRadioButton28, "１００以上");
            this.xRadioButton28.UseVisualStyleBackColor = false;
            this.xRadioButton28.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xLabel5
            // 
            this.xLabel5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel5.Location = new System.Drawing.Point(325, 7);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(22, 20);
            this.xLabel5.TabIndex = 7;
            this.xLabel5.Text = "S";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel6
            // 
            this.xLabel6.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel6.Location = new System.Drawing.Point(4, 7);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(22, 20);
            this.xLabel6.TabIndex = 6;
            this.xLabel6.Text = "s";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xRadioButton9
            // 
            this.xRadioButton9.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton9.CheckedValue = "5";
            this.xRadioButton9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton9.Location = new System.Drawing.Point(300, 8);
            this.xRadioButton9.Name = "xRadioButton9";
            this.xRadioButton9.Size = new System.Drawing.Size(33, 18);
            this.xRadioButton9.TabIndex = 5;
            this.xRadioButton9.Tag = "5";
            this.xRadioButton9.Text = "5";
            this.toolTip1.SetToolTip(this.xRadioButton9, "６４以上１００未満");
            this.xRadioButton9.UseVisualStyleBackColor = false;
            this.xRadioButton9.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton10
            // 
            this.xRadioButton10.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton10.CheckedValue = "4";
            this.xRadioButton10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton10.Location = new System.Drawing.Point(251, 8);
            this.xRadioButton10.Name = "xRadioButton10";
            this.xRadioButton10.Size = new System.Drawing.Size(39, 18);
            this.xRadioButton10.TabIndex = 4;
            this.xRadioButton10.Tag = "4";
            this.xRadioButton10.Text = "4";
            this.toolTip1.SetToolTip(this.xRadioButton10, "３６以上６４未満");
            this.xRadioButton10.UseVisualStyleBackColor = false;
            this.xRadioButton10.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton23
            // 
            this.xRadioButton23.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton23.CheckedValue = "3";
            this.xRadioButton23.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton23.Location = new System.Drawing.Point(202, 8);
            this.xRadioButton23.Name = "xRadioButton23";
            this.xRadioButton23.Size = new System.Drawing.Size(43, 18);
            this.xRadioButton23.TabIndex = 3;
            this.xRadioButton23.Tag = "3";
            this.xRadioButton23.Text = "3";
            this.toolTip1.SetToolTip(this.xRadioButton23, "１６以上３６未満");
            this.xRadioButton23.UseVisualStyleBackColor = false;
            this.xRadioButton23.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton24
            // 
            this.xRadioButton24.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton24.CheckedValue = "2";
            this.xRadioButton24.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton24.Location = new System.Drawing.Point(153, 8);
            this.xRadioButton24.Name = "xRadioButton24";
            this.xRadioButton24.Size = new System.Drawing.Size(43, 18);
            this.xRadioButton24.TabIndex = 2;
            this.xRadioButton24.Tag = "2";
            this.xRadioButton24.Text = "2";
            this.toolTip1.SetToolTip(this.xRadioButton24, "４以上１６未満");
            this.xRadioButton24.UseVisualStyleBackColor = false;
            this.xRadioButton24.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton25
            // 
            this.xRadioButton25.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton25.CheckedValue = "1";
            this.xRadioButton25.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton25.Location = new System.Drawing.Point(104, 8);
            this.xRadioButton25.Name = "xRadioButton25";
            this.xRadioButton25.Size = new System.Drawing.Size(41, 18);
            this.xRadioButton25.TabIndex = 1;
            this.xRadioButton25.Tag = "1";
            this.xRadioButton25.Text = "1";
            this.toolTip1.SetToolTip(this.xRadioButton25, "４未満");
            this.xRadioButton25.UseVisualStyleBackColor = false;
            this.xRadioButton25.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton26
            // 
            this.xRadioButton26.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton26.CheckedValue = "0";
            this.xRadioButton26.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton26.Location = new System.Drawing.Point(28, 8);
            this.xRadioButton26.Name = "xRadioButton26";
            this.xRadioButton26.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton26.TabIndex = 0;
            this.xRadioButton26.Tag = "0";
            this.xRadioButton26.Text = "0(なし)";
            this.toolTip1.SetToolTip(this.xRadioButton26, "皮膚損傷なし");
            this.xRadioButton26.UseVisualStyleBackColor = false;
            this.xRadioButton26.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton27
            // 
            this.xRadioButton27.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton27.CheckedValue = "1";
            this.xRadioButton27.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton27.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton27.Name = "xRadioButton27";
            this.xRadioButton27.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton27.TabIndex = 1;
            this.xRadioButton27.Text = "1";
            this.xRadioButton27.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.BindControl = this.emkYokchang_size_start;
            this.xEditGridCell177.CellName = "yokchang_size_start";
            this.xEditGridCell177.Col = 48;
            this.xEditGridCell177.HeaderText = "yokchang_size_start";
            // 
            // emkYokchang_size_start
            // 
            this.emkYokchang_size_start.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkYokchang_size_start.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkYokchang_size_start.Location = new System.Drawing.Point(227, 117);
            this.emkYokchang_size_start.MaxinumCipher = 3;
            this.emkYokchang_size_start.Name = "emkYokchang_size_start";
            this.emkYokchang_size_start.Size = new System.Drawing.Size(73, 20);
            this.emkYokchang_size_start.TabIndex = 126;
            this.emkYokchang_size_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emkYokchang_size_start.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkYokchang_size_DataValidating);
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.BindControl = this.emkYokchang_size_end;
            this.xEditGridCell178.CellName = "yokchang_size_end";
            this.xEditGridCell178.Col = 49;
            this.xEditGridCell178.HeaderText = "yokchang_size_end";
            // 
            // emkYokchang_size_end
            // 
            this.emkYokchang_size_end.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkYokchang_size_end.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkYokchang_size_end.Location = new System.Drawing.Point(325, 117);
            this.emkYokchang_size_end.MaxinumCipher = 3;
            this.emkYokchang_size_end.Name = "emkYokchang_size_end";
            this.emkYokchang_size_end.Size = new System.Drawing.Size(73, 20);
            this.emkYokchang_size_end.TabIndex = 127;
            this.emkYokchang_size_end.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emkYokchang_size_end.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkYokchang_size_DataValidating);
            // 
            // xEditGridCell179
            // 
            this.xEditGridCell179.BindControl = this.gbxYokchang_gamyum;
            this.xEditGridCell179.CellName = "yokchang_gamyum";
            this.xEditGridCell179.Col = 50;
            this.xEditGridCell179.HeaderText = "yokchang_gamyum";
            // 
            // gbxYokchang_gamyum
            // 
            this.gbxYokchang_gamyum.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxYokchang_gamyum.Controls.Add(this.xLabel9);
            this.gbxYokchang_gamyum.Controls.Add(this.xLabel17);
            this.gbxYokchang_gamyum.Controls.Add(this.xRadioButton29);
            this.gbxYokchang_gamyum.Controls.Add(this.xRadioButton30);
            this.gbxYokchang_gamyum.Controls.Add(this.xRadioButton31);
            this.gbxYokchang_gamyum.Controls.Add(this.xRadioButton32);
            this.gbxYokchang_gamyum.Controls.Add(this.xRadioButton33);
            this.gbxYokchang_gamyum.Location = new System.Drawing.Point(92, 163);
            this.gbxYokchang_gamyum.Name = "gbxYokchang_gamyum";
            this.gbxYokchang_gamyum.Size = new System.Drawing.Size(406, 30);
            this.gbxYokchang_gamyum.TabIndex = 4;
            this.gbxYokchang_gamyum.TabStop = false;
            // 
            // xLabel9
            // 
            this.xLabel9.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel9.Location = new System.Drawing.Point(130, 8);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(22, 20);
            this.xLabel9.TabIndex = 7;
            this.xLabel9.Text = "I";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel17
            // 
            this.xLabel17.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel17.Location = new System.Drawing.Point(4, 7);
            this.xLabel17.Name = "xLabel17";
            this.xLabel17.Size = new System.Drawing.Size(22, 20);
            this.xLabel17.TabIndex = 6;
            this.xLabel17.Text = "i";
            this.xLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xRadioButton29
            // 
            this.xRadioButton29.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton29.CheckedValue = "3";
            this.xRadioButton29.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton29.Location = new System.Drawing.Point(203, 9);
            this.xRadioButton29.Name = "xRadioButton29";
            this.xRadioButton29.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton29.TabIndex = 3;
            this.xRadioButton29.Tag = "3";
            this.xRadioButton29.Text = "3";
            this.toolTip1.SetToolTip(this.xRadioButton29, "全身的影響あり(発熱など)");
            this.xRadioButton29.UseVisualStyleBackColor = false;
            this.xRadioButton29.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton30
            // 
            this.xRadioButton30.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton30.CheckedValue = "2";
            this.xRadioButton30.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton30.Location = new System.Drawing.Point(153, 9);
            this.xRadioButton30.Name = "xRadioButton30";
            this.xRadioButton30.Size = new System.Drawing.Size(44, 18);
            this.xRadioButton30.TabIndex = 2;
            this.xRadioButton30.Tag = "2";
            this.xRadioButton30.Text = "2";
            this.toolTip1.SetToolTip(this.xRadioButton30, "局所の明らかな感染徴候あり（炎症徴候、膿・悪臭など）");
            this.xRadioButton30.UseVisualStyleBackColor = false;
            this.xRadioButton30.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton31
            // 
            this.xRadioButton31.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton31.CheckedValue = "1";
            this.xRadioButton31.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton31.Location = new System.Drawing.Point(104, 9);
            this.xRadioButton31.Name = "xRadioButton31";
            this.xRadioButton31.Size = new System.Drawing.Size(25, 18);
            this.xRadioButton31.TabIndex = 1;
            this.xRadioButton31.Tag = "1";
            this.xRadioButton31.Text = "1";
            this.toolTip1.SetToolTip(this.xRadioButton31, "局所の炎症徴候あり(創周囲の発赤､腫脹､熱感､疼痛)");
            this.xRadioButton31.UseVisualStyleBackColor = false;
            this.xRadioButton31.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton32
            // 
            this.xRadioButton32.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton32.CheckedValue = "0";
            this.xRadioButton32.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton32.Location = new System.Drawing.Point(28, 9);
            this.xRadioButton32.Name = "xRadioButton32";
            this.xRadioButton32.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton32.TabIndex = 0;
            this.xRadioButton32.Tag = "0";
            this.xRadioButton32.Text = "0(なし)";
            this.toolTip1.SetToolTip(this.xRadioButton32, "局所の炎症徴候なし");
            this.xRadioButton32.UseVisualStyleBackColor = false;
            this.xRadioButton32.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton33
            // 
            this.xRadioButton33.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton33.CheckedValue = "1";
            this.xRadioButton33.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton33.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton33.Name = "xRadioButton33";
            this.xRadioButton33.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton33.TabIndex = 1;
            this.xRadioButton33.Text = "1";
            this.xRadioButton33.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.BindControl = this.gbxYukajojik;
            this.xEditGridCell180.CellName = "yukajojik";
            this.xEditGridCell180.Col = 51;
            this.xEditGridCell180.HeaderText = "yukajojik";
            // 
            // gbxYukajojik
            // 
            this.gbxYukajojik.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxYukajojik.Controls.Add(this.xLabel19);
            this.gbxYukajojik.Controls.Add(this.xLabel29);
            this.gbxYukajojik.Controls.Add(this.xRadioButton34);
            this.gbxYukajojik.Controls.Add(this.xRadioButton35);
            this.gbxYukajojik.Controls.Add(this.xRadioButton36);
            this.gbxYukajojik.Controls.Add(this.xRadioButton37);
            this.gbxYukajojik.Controls.Add(this.xRadioButton38);
            this.gbxYukajojik.Controls.Add(this.xRadioButton39);
            this.gbxYukajojik.Controls.Add(this.xRadioButton40);
            this.gbxYukajojik.Location = new System.Drawing.Point(92, 193);
            this.gbxYukajojik.Name = "gbxYukajojik";
            this.gbxYukajojik.Size = new System.Drawing.Size(406, 30);
            this.gbxYukajojik.TabIndex = 5;
            this.gbxYukajojik.TabStop = false;
            // 
            // xLabel19
            // 
            this.xLabel19.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel19.Location = new System.Drawing.Point(180, 7);
            this.xLabel19.Name = "xLabel19";
            this.xLabel19.Size = new System.Drawing.Size(22, 20);
            this.xLabel19.TabIndex = 7;
            this.xLabel19.Text = "G";
            this.xLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel29
            // 
            this.xLabel29.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel29.Location = new System.Drawing.Point(4, 7);
            this.xLabel29.Name = "xLabel29";
            this.xLabel29.Size = new System.Drawing.Size(22, 20);
            this.xLabel29.TabIndex = 6;
            this.xLabel29.Text = "g";
            this.xLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xRadioButton34
            // 
            this.xRadioButton34.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton34.CheckedValue = "5";
            this.xRadioButton34.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton34.Location = new System.Drawing.Point(300, 8);
            this.xRadioButton34.Name = "xRadioButton34";
            this.xRadioButton34.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton34.TabIndex = 5;
            this.xRadioButton34.Tag = "5";
            this.xRadioButton34.Text = "5";
            this.toolTip1.SetToolTip(this.xRadioButton34, "良性肉芽がまったく形成されていない");
            this.xRadioButton34.UseVisualStyleBackColor = false;
            this.xRadioButton34.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton35
            // 
            this.xRadioButton35.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton35.CheckedValue = "4";
            this.xRadioButton35.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton35.Location = new System.Drawing.Point(251, 8);
            this.xRadioButton35.Name = "xRadioButton35";
            this.xRadioButton35.Size = new System.Drawing.Size(43, 18);
            this.xRadioButton35.TabIndex = 4;
            this.xRadioButton35.Tag = "4";
            this.xRadioButton35.Text = "4";
            this.toolTip1.SetToolTip(this.xRadioButton35, "良性肉芽が、創面の10%未満を占める");
            this.xRadioButton35.UseVisualStyleBackColor = false;
            this.xRadioButton35.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton36
            // 
            this.xRadioButton36.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton36.CheckedValue = "3";
            this.xRadioButton36.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton36.Location = new System.Drawing.Point(203, 8);
            this.xRadioButton36.Name = "xRadioButton36";
            this.xRadioButton36.Size = new System.Drawing.Size(42, 18);
            this.xRadioButton36.TabIndex = 3;
            this.xRadioButton36.Tag = "3";
            this.xRadioButton36.Text = "3";
            this.toolTip1.SetToolTip(this.xRadioButton36, "良性肉芽が、創面の10%以上50%未満を占める");
            this.xRadioButton36.UseVisualStyleBackColor = false;
            this.xRadioButton36.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton37
            // 
            this.xRadioButton37.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton37.CheckedValue = "2";
            this.xRadioButton37.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton37.Location = new System.Drawing.Point(153, 8);
            this.xRadioButton37.Name = "xRadioButton37";
            this.xRadioButton37.Size = new System.Drawing.Size(26, 18);
            this.xRadioButton37.TabIndex = 2;
            this.xRadioButton37.Tag = "2";
            this.xRadioButton37.Text = "2";
            this.toolTip1.SetToolTip(this.xRadioButton37, "良性肉芽が、創面の50%以上90%未満を占める");
            this.xRadioButton37.UseVisualStyleBackColor = false;
            this.xRadioButton37.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton38
            // 
            this.xRadioButton38.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton38.CheckedValue = "1";
            this.xRadioButton38.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton38.Location = new System.Drawing.Point(104, 8);
            this.xRadioButton38.Name = "xRadioButton38";
            this.xRadioButton38.Size = new System.Drawing.Size(43, 18);
            this.xRadioButton38.TabIndex = 1;
            this.xRadioButton38.Tag = "1";
            this.xRadioButton38.Text = "1";
            this.toolTip1.SetToolTip(this.xRadioButton38, "良性肉芽が、創面の90%以上を占める");
            this.xRadioButton38.UseVisualStyleBackColor = false;
            this.xRadioButton38.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton39
            // 
            this.xRadioButton39.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton39.CheckedValue = "0";
            this.xRadioButton39.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton39.Location = new System.Drawing.Point(28, 8);
            this.xRadioButton39.Name = "xRadioButton39";
            this.xRadioButton39.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton39.TabIndex = 0;
            this.xRadioButton39.Tag = "0";
            this.xRadioButton39.Text = "0";
            this.toolTip1.SetToolTip(this.xRadioButton39, "治癒あるいは創が浅いため肉芽形成の評価が出来ない");
            this.xRadioButton39.UseVisualStyleBackColor = false;
            this.xRadioButton39.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton40
            // 
            this.xRadioButton40.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton40.CheckedValue = "1";
            this.xRadioButton40.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton40.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton40.Name = "xRadioButton40";
            this.xRadioButton40.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton40.TabIndex = 1;
            this.xRadioButton40.Text = "1";
            this.xRadioButton40.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.BindControl = this.gbxGaesajojik;
            this.xEditGridCell181.CellName = "gaesajojik";
            this.xEditGridCell181.Col = 52;
            this.xEditGridCell181.HeaderText = "gaesajojik";
            // 
            // gbxGaesajojik
            // 
            this.gbxGaesajojik.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxGaesajojik.Controls.Add(this.xLabel12);
            this.gbxGaesajojik.Controls.Add(this.xLabel13);
            this.gbxGaesajojik.Controls.Add(this.xRadioButton11);
            this.gbxGaesajojik.Controls.Add(this.xRadioButton14);
            this.gbxGaesajojik.Controls.Add(this.xRadioButton15);
            this.gbxGaesajojik.Controls.Add(this.xRadioButton16);
            this.gbxGaesajojik.Location = new System.Drawing.Point(92, 223);
            this.gbxGaesajojik.Name = "gbxGaesajojik";
            this.gbxGaesajojik.Size = new System.Drawing.Size(406, 30);
            this.gbxGaesajojik.TabIndex = 6;
            this.gbxGaesajojik.TabStop = false;
            // 
            // xLabel12
            // 
            this.xLabel12.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel12.Location = new System.Drawing.Point(80, 8);
            this.xLabel12.Name = "xLabel12";
            this.xLabel12.Size = new System.Drawing.Size(22, 20);
            this.xLabel12.TabIndex = 7;
            this.xLabel12.Text = "N";
            this.xLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel13
            // 
            this.xLabel13.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel13.Location = new System.Drawing.Point(4, 7);
            this.xLabel13.Name = "xLabel13";
            this.xLabel13.Size = new System.Drawing.Size(22, 20);
            this.xLabel13.TabIndex = 6;
            this.xLabel13.Text = "n";
            this.xLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xRadioButton11
            // 
            this.xRadioButton11.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton11.CheckedValue = "2";
            this.xRadioButton11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton11.Location = new System.Drawing.Point(153, 9);
            this.xRadioButton11.Name = "xRadioButton11";
            this.xRadioButton11.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton11.TabIndex = 2;
            this.xRadioButton11.Tag = "2";
            this.xRadioButton11.Text = "2";
            this.toolTip1.SetToolTip(this.xRadioButton11, "硬く厚い密着した壊死組織あり");
            this.xRadioButton11.UseVisualStyleBackColor = false;
            this.xRadioButton11.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton14
            // 
            this.xRadioButton14.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton14.CheckedValue = "1";
            this.xRadioButton14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton14.Location = new System.Drawing.Point(104, 9);
            this.xRadioButton14.Name = "xRadioButton14";
            this.xRadioButton14.Size = new System.Drawing.Size(48, 18);
            this.xRadioButton14.TabIndex = 1;
            this.xRadioButton14.Tag = "1";
            this.xRadioButton14.Text = "1";
            this.toolTip1.SetToolTip(this.xRadioButton14, "柔らかい壊死組織あり");
            this.xRadioButton14.UseVisualStyleBackColor = false;
            this.xRadioButton14.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton15
            // 
            this.xRadioButton15.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton15.CheckedValue = "0";
            this.xRadioButton15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton15.Location = new System.Drawing.Point(28, 9);
            this.xRadioButton15.Name = "xRadioButton15";
            this.xRadioButton15.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton15.TabIndex = 0;
            this.xRadioButton15.Tag = "0";
            this.xRadioButton15.Text = "0(なし)";
            this.toolTip1.SetToolTip(this.xRadioButton15, "壊死組織なし");
            this.xRadioButton15.UseVisualStyleBackColor = false;
            this.xRadioButton15.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton16
            // 
            this.xRadioButton16.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton16.CheckedValue = "1";
            this.xRadioButton16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton16.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton16.Name = "xRadioButton16";
            this.xRadioButton16.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton16.TabIndex = 1;
            this.xRadioButton16.Text = "1";
            this.xRadioButton16.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell182
            // 
            this.xEditGridCell182.BindControl = this.gbxPocket_gubun;
            this.xEditGridCell182.CellName = "pocket_gubun";
            this.xEditGridCell182.Col = 53;
            this.xEditGridCell182.HeaderText = "pocket_gubun";
            // 
            // gbxPocket_gubun
            // 
            this.gbxPocket_gubun.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxPocket_gubun.Controls.Add(this.xLabel15);
            this.gbxPocket_gubun.Controls.Add(this.xRadioButton20);
            this.gbxPocket_gubun.Controls.Add(this.xRadioButton21);
            this.gbxPocket_gubun.Controls.Add(this.xRadioButton22);
            this.gbxPocket_gubun.Controls.Add(this.xRadioButton41);
            this.gbxPocket_gubun.Controls.Add(this.xRadioButton42);
            this.gbxPocket_gubun.Controls.Add(this.xRadioButton43);
            this.gbxPocket_gubun.Location = new System.Drawing.Point(92, 276);
            this.gbxPocket_gubun.Name = "gbxPocket_gubun";
            this.gbxPocket_gubun.Size = new System.Drawing.Size(406, 30);
            this.gbxPocket_gubun.TabIndex = 7;
            this.gbxPocket_gubun.TabStop = false;
            // 
            // xLabel15
            // 
            this.xLabel15.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel15.Location = new System.Drawing.Point(80, 7);
            this.xLabel15.Name = "xLabel15";
            this.xLabel15.Size = new System.Drawing.Size(22, 20);
            this.xLabel15.TabIndex = 7;
            this.xLabel15.Text = "P";
            this.xLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xRadioButton20
            // 
            this.xRadioButton20.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton20.CheckedValue = "4";
            this.xRadioButton20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton20.Location = new System.Drawing.Point(251, 8);
            this.xRadioButton20.Name = "xRadioButton20";
            this.xRadioButton20.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton20.TabIndex = 4;
            this.xRadioButton20.Tag = "4";
            this.xRadioButton20.Text = "4";
            this.toolTip1.SetToolTip(this.xRadioButton20, "３６以上");
            this.xRadioButton20.UseVisualStyleBackColor = false;
            this.xRadioButton20.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton21
            // 
            this.xRadioButton21.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton21.CheckedValue = "3";
            this.xRadioButton21.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton21.Location = new System.Drawing.Point(203, 8);
            this.xRadioButton21.Name = "xRadioButton21";
            this.xRadioButton21.Size = new System.Drawing.Size(42, 18);
            this.xRadioButton21.TabIndex = 3;
            this.xRadioButton21.Tag = "3";
            this.xRadioButton21.Text = "3";
            this.toolTip1.SetToolTip(this.xRadioButton21, "１６以上３６未満");
            this.xRadioButton21.UseVisualStyleBackColor = false;
            this.xRadioButton21.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton22
            // 
            this.xRadioButton22.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton22.CheckedValue = "2";
            this.xRadioButton22.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton22.Location = new System.Drawing.Point(153, 8);
            this.xRadioButton22.Name = "xRadioButton22";
            this.xRadioButton22.Size = new System.Drawing.Size(46, 18);
            this.xRadioButton22.TabIndex = 2;
            this.xRadioButton22.Tag = "2";
            this.xRadioButton22.Text = "2";
            this.toolTip1.SetToolTip(this.xRadioButton22, "４以上１６未満");
            this.xRadioButton22.UseVisualStyleBackColor = false;
            this.xRadioButton22.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton41
            // 
            this.xRadioButton41.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton41.CheckedValue = "1";
            this.xRadioButton41.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton41.Location = new System.Drawing.Point(104, 8);
            this.xRadioButton41.Name = "xRadioButton41";
            this.xRadioButton41.Size = new System.Drawing.Size(43, 18);
            this.xRadioButton41.TabIndex = 1;
            this.xRadioButton41.Tag = "1";
            this.xRadioButton41.Text = "1";
            this.toolTip1.SetToolTip(this.xRadioButton41, "４未満");
            this.xRadioButton41.UseVisualStyleBackColor = false;
            this.xRadioButton41.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton42
            // 
            this.xRadioButton42.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton42.CheckedValue = "0";
            this.xRadioButton42.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton42.Location = new System.Drawing.Point(28, 8);
            this.xRadioButton42.Name = "xRadioButton42";
            this.xRadioButton42.Size = new System.Drawing.Size(51, 18);
            this.xRadioButton42.TabIndex = 0;
            this.xRadioButton42.Tag = "0";
            this.xRadioButton42.Text = "(なし)";
            this.xRadioButton42.UseVisualStyleBackColor = false;
            this.xRadioButton42.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton43
            // 
            this.xRadioButton43.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton43.CheckedValue = "1";
            this.xRadioButton43.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton43.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton43.Name = "xRadioButton43";
            this.xRadioButton43.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton43.TabIndex = 1;
            this.xRadioButton43.Text = "1";
            this.xRadioButton43.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell183
            // 
            this.xEditGridCell183.BindControl = this.emkPocket_size_start;
            this.xEditGridCell183.CellName = "pocket_size_start";
            this.xEditGridCell183.Col = 54;
            this.xEditGridCell183.HeaderText = "pocket_size_start";
            // 
            // emkPocket_size_start
            // 
            this.emkPocket_size_start.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkPocket_size_start.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkPocket_size_start.Location = new System.Drawing.Point(227, 260);
            this.emkPocket_size_start.MaxinumCipher = 3;
            this.emkPocket_size_start.Name = "emkPocket_size_start";
            this.emkPocket_size_start.Size = new System.Drawing.Size(73, 20);
            this.emkPocket_size_start.TabIndex = 128;
            this.emkPocket_size_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emkPocket_size_start.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkPocket_size_DataValidating);
            // 
            // xEditGridCell184
            // 
            this.xEditGridCell184.BindControl = this.emkPocket_size_end;
            this.xEditGridCell184.CellName = "pocket_size_end";
            this.xEditGridCell184.Col = 55;
            this.xEditGridCell184.HeaderText = "pocket_size_end";
            // 
            // emkPocket_size_end
            // 
            this.emkPocket_size_end.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkPocket_size_end.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkPocket_size_end.Location = new System.Drawing.Point(325, 260);
            this.emkPocket_size_end.MaxinumCipher = 3;
            this.emkPocket_size_end.Name = "emkPocket_size_end";
            this.emkPocket_size_end.Size = new System.Drawing.Size(73, 20);
            this.emkPocket_size_end.TabIndex = 129;
            this.emkPocket_size_end.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emkPocket_size_end.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkPocket_size_DataValidating);
            // 
            // xEditGridCell185
            // 
            this.xEditGridCell185.BindControl = this.gbxYokchang_stage;
            this.xEditGridCell185.CellName = "yokchang_stage";
            this.xEditGridCell185.Col = 56;
            this.xEditGridCell185.HeaderText = "yokchang_stage";
            // 
            // gbxYokchang_stage
            // 
            this.gbxYokchang_stage.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxYokchang_stage.Controls.Add(this.xRadioButton44);
            this.gbxYokchang_stage.Controls.Add(this.xRadioButton45);
            this.gbxYokchang_stage.Controls.Add(this.xRadioButton46);
            this.gbxYokchang_stage.Controls.Add(this.xRadioButton47);
            this.gbxYokchang_stage.Controls.Add(this.xRadioButton48);
            this.gbxYokchang_stage.Location = new System.Drawing.Point(92, 308);
            this.gbxYokchang_stage.Name = "gbxYokchang_stage";
            this.gbxYokchang_stage.Size = new System.Drawing.Size(406, 30);
            this.gbxYokchang_stage.TabIndex = 8;
            this.gbxYokchang_stage.TabStop = false;
            // 
            // xRadioButton44
            // 
            this.xRadioButton44.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton44.CheckedValue = "4";
            this.xRadioButton44.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton44.Location = new System.Drawing.Point(223, 8);
            this.xRadioButton44.Name = "xRadioButton44";
            this.xRadioButton44.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton44.TabIndex = 3;
            this.xRadioButton44.Tag = "4";
            this.xRadioButton44.Text = "Ⅳ度";
            this.xRadioButton44.UseVisualStyleBackColor = false;
            this.xRadioButton44.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton45
            // 
            this.xRadioButton45.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton45.CheckedValue = "3";
            this.xRadioButton45.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton45.Location = new System.Drawing.Point(160, 8);
            this.xRadioButton45.Name = "xRadioButton45";
            this.xRadioButton45.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton45.TabIndex = 2;
            this.xRadioButton45.Tag = "3";
            this.xRadioButton45.Text = "Ⅲ度";
            this.xRadioButton45.UseVisualStyleBackColor = false;
            this.xRadioButton45.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton46
            // 
            this.xRadioButton46.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton46.CheckedValue = "2";
            this.xRadioButton46.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton46.Location = new System.Drawing.Point(102, 8);
            this.xRadioButton46.Name = "xRadioButton46";
            this.xRadioButton46.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton46.TabIndex = 1;
            this.xRadioButton46.Tag = "2";
            this.xRadioButton46.Text = "Ⅱ度";
            this.xRadioButton46.UseVisualStyleBackColor = false;
            this.xRadioButton46.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton47
            // 
            this.xRadioButton47.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton47.CheckedValue = "1";
            this.xRadioButton47.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton47.Location = new System.Drawing.Point(40, 8);
            this.xRadioButton47.Name = "xRadioButton47";
            this.xRadioButton47.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton47.TabIndex = 0;
            this.xRadioButton47.Tag = "1";
            this.xRadioButton47.Text = "Ⅰ度";
            this.xRadioButton47.UseVisualStyleBackColor = false;
            this.xRadioButton47.CheckedChanged += new System.EventHandler(this.All_Check_Changed);
            // 
            // xRadioButton48
            // 
            this.xRadioButton48.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton48.CheckedValue = "1";
            this.xRadioButton48.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton48.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton48.Name = "xRadioButton48";
            this.xRadioButton48.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton48.TabIndex = 1;
            this.xRadioButton48.Text = "1";
            this.xRadioButton48.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell186
            // 
            this.xEditGridCell186.BindControl = this.emkTotal_count;
            this.xEditGridCell186.CellName = "total_count";
            this.xEditGridCell186.Col = 57;
            this.xEditGridCell186.HeaderText = "total_count";
            // 
            // emkTotal_count
            // 
            this.emkTotal_count.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.emkTotal_count.Location = new System.Drawing.Point(92, 345);
            this.emkTotal_count.Name = "emkTotal_count";
            this.emkTotal_count.Size = new System.Drawing.Size(73, 22);
            this.emkTotal_count.TabIndex = 130;
            this.emkTotal_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xEditGridCell187
            // 
            this.xEditGridCell187.BindControl = this.gbxYungyang_siksa_gubun;
            this.xEditGridCell187.CellName = "yungyang_siksa_gubun";
            this.xEditGridCell187.Col = 58;
            this.xEditGridCell187.HeaderText = "yungyang_siksa_gubun";
            // 
            // gbxYungyang_siksa_gubun
            // 
            this.gbxYungyang_siksa_gubun.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxYungyang_siksa_gubun.Controls.Add(this.xLabel38);
            this.gbxYungyang_siksa_gubun.Controls.Add(this.xRadioButton6);
            this.gbxYungyang_siksa_gubun.Controls.Add(this.xRadioButton49);
            this.gbxYungyang_siksa_gubun.Controls.Add(this.xRadioButton50);
            this.gbxYungyang_siksa_gubun.Controls.Add(this.xRadioButton51);
            this.gbxYungyang_siksa_gubun.Location = new System.Drawing.Point(92, 368);
            this.gbxYungyang_siksa_gubun.Name = "gbxYungyang_siksa_gubun";
            this.gbxYungyang_siksa_gubun.Size = new System.Drawing.Size(406, 30);
            this.gbxYungyang_siksa_gubun.TabIndex = 135;
            this.gbxYungyang_siksa_gubun.TabStop = false;
            // 
            // xLabel38
            // 
            this.xLabel38.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel38.Location = new System.Drawing.Point(4, 7);
            this.xLabel38.Name = "xLabel38";
            this.xLabel38.Size = new System.Drawing.Size(34, 20);
            this.xLabel38.TabIndex = 6;
            this.xLabel38.Text = "食事";
            this.xLabel38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xRadioButton6
            // 
            this.xRadioButton6.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton6.CheckedValue = "3";
            this.xRadioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton6.Location = new System.Drawing.Point(160, 9);
            this.xRadioButton6.Name = "xRadioButton6";
            this.xRadioButton6.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton6.TabIndex = 2;
            this.xRadioButton6.Text = "NPO";
            this.xRadioButton6.UseVisualStyleBackColor = false;
            // 
            // xRadioButton49
            // 
            this.xRadioButton49.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton49.CheckedValue = "2";
            this.xRadioButton49.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton49.Location = new System.Drawing.Point(102, 9);
            this.xRadioButton49.Name = "xRadioButton49";
            this.xRadioButton49.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton49.TabIndex = 1;
            this.xRadioButton49.Text = "経管";
            this.xRadioButton49.UseVisualStyleBackColor = false;
            // 
            // xRadioButton50
            // 
            this.xRadioButton50.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton50.CheckedValue = "1";
            this.xRadioButton50.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton50.Location = new System.Drawing.Point(40, 9);
            this.xRadioButton50.Name = "xRadioButton50";
            this.xRadioButton50.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton50.TabIndex = 0;
            this.xRadioButton50.Text = "経口";
            this.xRadioButton50.UseVisualStyleBackColor = false;
            // 
            // xRadioButton51
            // 
            this.xRadioButton51.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton51.CheckedValue = "1";
            this.xRadioButton51.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton51.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton51.Name = "xRadioButton51";
            this.xRadioButton51.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton51.TabIndex = 1;
            this.xRadioButton51.Text = "1";
            this.xRadioButton51.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell188
            // 
            this.xEditGridCell188.BindControl = this.emkYunayang_siksa_yang;
            this.xEditGridCell188.CellName = "yungyang_siksa_yang";
            this.xEditGridCell188.Col = 59;
            this.xEditGridCell188.HeaderText = "yungyang_siksa_yang";
            // 
            // emkYunayang_siksa_yang
            // 
            this.emkYunayang_siksa_yang.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkYunayang_siksa_yang.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkYunayang_siksa_yang.Location = new System.Drawing.Point(92, 399);
            this.emkYunayang_siksa_yang.Name = "emkYunayang_siksa_yang";
            this.emkYunayang_siksa_yang.Size = new System.Drawing.Size(73, 20);
            this.emkYunayang_siksa_yang.TabIndex = 136;
            this.emkYunayang_siksa_yang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xEditGridCell189
            // 
            this.xEditGridCell189.BindControl = this.emkYungyang_siksa_percent;
            this.xEditGridCell189.CellName = "yungyang_siksa_percent";
            this.xEditGridCell189.Col = 60;
            this.xEditGridCell189.HeaderText = "yungyang_siksa_percent";
            // 
            // emkYungyang_siksa_percent
            // 
            this.emkYungyang_siksa_percent.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkYungyang_siksa_percent.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkYungyang_siksa_percent.Location = new System.Drawing.Point(291, 399);
            this.emkYungyang_siksa_percent.Name = "emkYungyang_siksa_percent";
            this.emkYungyang_siksa_percent.Size = new System.Drawing.Size(73, 20);
            this.emkYungyang_siksa_percent.TabIndex = 139;
            this.emkYungyang_siksa_percent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xEditGridCell190
            // 
            this.xEditGridCell190.BindControl = this.gbxYungyang_suaek_yn;
            this.xEditGridCell190.CellName = "yungyang_suaek_yn";
            this.xEditGridCell190.Col = 61;
            this.xEditGridCell190.HeaderText = "yungyang_suaek_yn";
            // 
            // gbxYungyang_suaek_yn
            // 
            this.gbxYungyang_suaek_yn.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxYungyang_suaek_yn.Controls.Add(this.xRadioButton54);
            this.gbxYungyang_suaek_yn.Controls.Add(this.xRadioButton55);
            this.gbxYungyang_suaek_yn.Controls.Add(this.xRadioButton56);
            this.gbxYungyang_suaek_yn.Location = new System.Drawing.Point(148, 421);
            this.gbxYungyang_suaek_yn.Name = "gbxYungyang_suaek_yn";
            this.gbxYungyang_suaek_yn.Size = new System.Drawing.Size(123, 30);
            this.gbxYungyang_suaek_yn.TabIndex = 146;
            this.gbxYungyang_suaek_yn.TabStop = false;
            // 
            // xRadioButton54
            // 
            this.xRadioButton54.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton54.CheckedValue = "1";
            this.xRadioButton54.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton54.Location = new System.Drawing.Point(63, 8);
            this.xRadioButton54.Name = "xRadioButton54";
            this.xRadioButton54.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton54.TabIndex = 1;
            this.xRadioButton54.Text = "有";
            this.xRadioButton54.UseVisualStyleBackColor = false;
            // 
            // xRadioButton55
            // 
            this.xRadioButton55.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton55.CheckedValue = "0";
            this.xRadioButton55.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton55.Location = new System.Drawing.Point(4, 8);
            this.xRadioButton55.Name = "xRadioButton55";
            this.xRadioButton55.Size = new System.Drawing.Size(58, 18);
            this.xRadioButton55.TabIndex = 0;
            this.xRadioButton55.Text = "無";
            this.xRadioButton55.UseVisualStyleBackColor = false;
            // 
            // xRadioButton56
            // 
            this.xRadioButton56.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xRadioButton56.CheckedValue = "1";
            this.xRadioButton56.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xRadioButton56.Location = new System.Drawing.Point(546, 270);
            this.xRadioButton56.Name = "xRadioButton56";
            this.xRadioButton56.Size = new System.Drawing.Size(50, 18);
            this.xRadioButton56.TabIndex = 1;
            this.xRadioButton56.Text = "1";
            this.xRadioButton56.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell191
            // 
            this.xEditGridCell191.BindControl = this.emkYungyang_suaek_yang;
            this.xEditGridCell191.CellName = "yungyang_suaek_yang";
            this.xEditGridCell191.Col = 62;
            this.xEditGridCell191.HeaderText = "yungyang_suaek_yang";
            // 
            // emkYungyang_suaek_yang
            // 
            this.emkYungyang_suaek_yang.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkYungyang_suaek_yang.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.emkYungyang_suaek_yang.Location = new System.Drawing.Point(273, 428);
            this.emkYungyang_suaek_yang.Name = "emkYungyang_suaek_yang";
            this.emkYungyang_suaek_yang.Size = new System.Drawing.Size(73, 20);
            this.emkYungyang_suaek_yang.TabIndex = 147;
            this.emkYungyang_suaek_yang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xEditGridCell192
            // 
            this.xEditGridCell192.BindControl = this.txtChuchi_text;
            this.xEditGridCell192.CellLen = 1000;
            this.xEditGridCell192.CellName = "chuchi_text";
            this.xEditGridCell192.Col = 63;
            this.xEditGridCell192.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell192.HeaderText = "chuchi_text";
            // 
            // txtChuchi_text
            // 
            this.txtChuchi_text.Location = new System.Drawing.Point(92, 455);
            this.txtChuchi_text.MaxLength = 1000;
            this.txtChuchi_text.Multiline = true;
            this.txtChuchi_text.Name = "txtChuchi_text";
            this.txtChuchi_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChuchi_text.Size = new System.Drawing.Size(406, 82);
            this.txtChuchi_text.TabIndex = 150;
            // 
            // xEditGridCell193
            // 
            this.xEditGridCell193.BindControl = this.emkYokchang_hb;
            this.xEditGridCell193.CellName = "yokchang_hb";
            this.xEditGridCell193.Col = 64;
            this.xEditGridCell193.HeaderText = "yokchang_hb";
            // 
            // emkYokchang_hb
            // 
            this.emkYokchang_hb.Location = new System.Drawing.Point(130, 540);
            this.emkYokchang_hb.Name = "emkYokchang_hb";
            this.emkYokchang_hb.Size = new System.Drawing.Size(48, 20);
            this.emkYokchang_hb.TabIndex = 151;
            this.emkYokchang_hb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xEditGridCell194
            // 
            this.xEditGridCell194.BindControl = this.emkYokchang_alb;
            this.xEditGridCell194.CellName = "yokchang_alb";
            this.xEditGridCell194.Col = 65;
            this.xEditGridCell194.HeaderText = "yokchang_alb";
            // 
            // emkYokchang_alb
            // 
            this.emkYokchang_alb.Location = new System.Drawing.Point(218, 540);
            this.emkYokchang_alb.Name = "emkYokchang_alb";
            this.emkYokchang_alb.Size = new System.Drawing.Size(48, 20);
            this.emkYokchang_alb.TabIndex = 152;
            this.emkYokchang_alb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xEditGridCell195
            // 
            this.xEditGridCell195.BindControl = this.emkYokchang_Tp;
            this.xEditGridCell195.CellName = "yokchang_tp";
            this.xEditGridCell195.Col = 66;
            this.xEditGridCell195.HeaderText = "yokchang_tp";
            // 
            // emkYokchang_Tp
            // 
            this.emkYokchang_Tp.Location = new System.Drawing.Point(306, 540);
            this.emkYokchang_Tp.Name = "emkYokchang_Tp";
            this.emkYokchang_Tp.Size = new System.Drawing.Size(48, 20);
            this.emkYokchang_Tp.TabIndex = 153;
            this.emkYokchang_Tp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xEditGridCell196
            // 
            this.xEditGridCell196.BindControl = this.dpbWeight;
            this.xEditGridCell196.CellName = "yokchang_weight";
            this.xEditGridCell196.Col = 67;
            this.xEditGridCell196.HeaderText = "yokchang_weight";
            this.xEditGridCell196.IsUpdCol = false;
            // 
            // dpbWeight
            // 
            this.dpbWeight.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.dpbWeight.Location = new System.Drawing.Point(395, 540);
            this.dpbWeight.Name = "dpbWeight";
            this.dpbWeight.Size = new System.Drawing.Size(46, 20);
            this.dpbWeight.TabIndex = 141;
            this.dpbWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdNur6002
            // 
            this.grdNur6002.CallerID = '2';
            this.grdNur6002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell48,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell41,
            this.xEditGridCell60,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell63,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
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
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92});
            this.grdNur6002.ColPerLine = 68;
            this.grdNur6002.Cols = 68;
            this.grdNur6002.ControlBinding = true;
            this.grdNur6002.FixedRows = 1;
            this.grdNur6002.HeaderHeights.Add(21);
            this.grdNur6002.Location = new System.Drawing.Point(186, -80);
            this.grdNur6002.Name = "grdNur6002";
            this.grdNur6002.QuerySQL = resources.GetString("grdNur6002.QuerySQL");
            this.grdNur6002.Rows = 2;
            this.grdNur6002.Size = new System.Drawing.Size(114, 72);
            this.grdNur6002.TabIndex = 64;
            this.grdNur6002.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNur6002_QueryEnd);
            this.grdNur6002.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNur6002_SaveEnd);
            this.grdNur6002.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNur6002_RowFocusChanged);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellLen = 9;
            this.xEditGridCell18.CellName = "bunho";
            this.xEditGridCell18.CellWidth = 82;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "from_date";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell19.CellWidth = 79;
            this.xEditGridCell19.Col = 1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellLen = 1;
            this.xEditGridCell20.CellName = "bedsore_buwi";
            this.xEditGridCell20.Col = 2;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.BindControl = this.dtpAssessor_date;
            this.xEditGridCell21.CellName = "assessor_date";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell21.Col = 3;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell21.InvalidDateIsStringEmpty = false;
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.BindControl = this.fbAssessor;
            this.xEditGridCell22.CellLen = 8;
            this.xEditGridCell22.CellName = "assessor";
            this.xEditGridCell22.Col = 4;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 2;
            this.xEditGridCell23.CellName = "bedsore_deep";
            this.xEditGridCell23.Col = 5;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "bedsore_depth";
            this.xEditGridCell24.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell24.Col = 6;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellLen = 1;
            this.xEditGridCell25.CellName = "bedsore_color";
            this.xEditGridCell25.Col = 7;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "bedsore_size1";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell26.Col = 8;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "bedsore_size_start1";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell27.Col = 9;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "bedsore_size_finish1";
            this.xEditGridCell28.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell28.Col = 10;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "bedsore_poket1";
            this.xEditGridCell29.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell29.Col = 11;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "bedsore_poket_start1";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell30.Col = 12;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "bedsore_poket_finish1";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell31.Col = 13;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellLen = 1;
            this.xEditGridCell32.CellName = "bedsore_death";
            this.xEditGridCell32.Col = 14;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 1;
            this.xEditGridCell33.CellName = "exudation_volume";
            this.xEditGridCell33.Col = 15;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellLen = 1;
            this.xEditGridCell48.CellName = "exudation_state";
            this.xEditGridCell48.Col = 24;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellLen = 50;
            this.xEditGridCell34.CellName = "exudation_color";
            this.xEditGridCell34.Col = 16;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellLen = 50;
            this.xEditGridCell35.CellName = "exudation_smell";
            this.xEditGridCell35.Col = 17;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 50;
            this.xEditGridCell36.CellName = "bedsore_skin";
            this.xEditGridCell36.Col = 18;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellLen = 1;
            this.xEditGridCell37.CellName = "bedsore_infe";
            this.xEditGridCell37.Col = 19;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 1;
            this.xEditGridCell38.CellName = "bedsore_moist";
            this.xEditGridCell38.Col = 20;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "bedsore_moist_rate";
            this.xEditGridCell39.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell39.Col = 21;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.BindControl = this.txtBedSore_gita;
            this.xEditGridCell40.CellLen = 200;
            this.xEditGridCell40.CellName = "bedsore_gita";
            this.xEditGridCell40.Col = 22;
            this.xEditGridCell40.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            // 
            // txtBedSore_gita
            // 
            this.txtBedSore_gita.Location = new System.Drawing.Point(92, 565);
            this.txtBedSore_gita.MaxLength = 1000;
            this.txtBedSore_gita.Multiline = true;
            this.txtBedSore_gita.Name = "txtBedSore_gita";
            this.txtBedSore_gita.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBedSore_gita.Size = new System.Drawing.Size(406, 76);
            this.txtBedSore_gita.TabIndex = 162;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 50;
            this.xEditGridCell49.CellName = "bedsore_nut";
            this.xEditGridCell49.Col = 25;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "bedsore_hb";
            this.xEditGridCell50.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell50.Col = 26;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "bedsore_alb";
            this.xEditGridCell51.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell51.Col = 27;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "bedsore_fbs";
            this.xEditGridCell52.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell52.Col = 28;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "bedsore_zn";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.Col = 29;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.BindControl = this.txtAssessor;
            this.xEditGridCell41.CellLen = 30;
            this.xEditGridCell41.CellName = "assessor_name";
            this.xEditGridCell41.Col = 23;
            this.xEditGridCell41.IsUpdatable = false;
            this.xEditGridCell41.IsUpdCol = false;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "bedsore_size2";
            this.xEditGridCell60.Col = 30;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "bedre_size_start2";
            this.xEditGridCell58.Col = 34;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "bedsore_size_finish2";
            this.xEditGridCell59.Col = 35;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "bedsore_poket2";
            this.xEditGridCell63.Col = 33;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "bedsore_poket_start2";
            this.xEditGridCell61.Col = 31;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "bedsore_poket_finish2";
            this.xEditGridCell62.Col = 32;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "weight";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell54.Col = 36;
            this.xEditGridCell54.IsUpdCol = false;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.BindControl = this.chkEndYn;
            this.xEditGridCell55.CellName = "end_yn";
            this.xEditGridCell55.Col = 37;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "exudation_state1";
            this.xEditGridCell56.Col = 38;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "exudation_state2";
            this.xEditGridCell64.Col = 39;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellLen = 1;
            this.xEditGridCell65.CellName = "bedsore_color2";
            this.xEditGridCell65.Col = 40;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellLen = 1;
            this.xEditGridCell66.CellName = "bedsore_color3";
            this.xEditGridCell66.Col = 41;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellLen = 1;
            this.xEditGridCell67.CellName = "bedsore_color4";
            this.xEditGridCell67.Col = 42;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.BindControl = this.cboFirst_sayu;
            this.xEditGridCell68.CellName = "first_sayu";
            this.xEditGridCell68.Col = 43;
            this.xEditGridCell68.HeaderText = "first_sayu";
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.BindControl = this.cboLast_sayu;
            this.xEditGridCell69.CellName = "last_sayu";
            this.xEditGridCell69.Col = 44;
            this.xEditGridCell69.HeaderText = "last_sayu";
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.BindControl = this.gbxYokchang_deep;
            this.xEditGridCell70.CellName = "yokchang_deep";
            this.xEditGridCell70.Col = 45;
            this.xEditGridCell70.HeaderText = "yokchang_deep";
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.BindControl = this.gbxSamchul_yang;
            this.xEditGridCell71.CellName = "samchul_yang";
            this.xEditGridCell71.Col = 46;
            this.xEditGridCell71.HeaderText = "samchul_yang";
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.BindControl = this.gbxYokchang_size;
            this.xEditGridCell72.CellName = "yokchang_size";
            this.xEditGridCell72.Col = 47;
            this.xEditGridCell72.HeaderText = "yokchang_size";
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.BindControl = this.emkYokchang_size_start;
            this.xEditGridCell73.CellName = "yokchang_size_start";
            this.xEditGridCell73.Col = 48;
            this.xEditGridCell73.HeaderText = "yokchang_size_start";
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.BindControl = this.emkYokchang_size_end;
            this.xEditGridCell74.CellName = "yokchang_size_end";
            this.xEditGridCell74.Col = 49;
            this.xEditGridCell74.HeaderText = "yokchang_size_end";
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.BindControl = this.gbxYokchang_gamyum;
            this.xEditGridCell75.CellName = "yokchang_gamyum";
            this.xEditGridCell75.Col = 50;
            this.xEditGridCell75.HeaderText = "yokchang_gamyum";
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.BindControl = this.gbxYukajojik;
            this.xEditGridCell76.CellName = "yukajojik";
            this.xEditGridCell76.Col = 51;
            this.xEditGridCell76.HeaderText = "yukajojik";
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.BindControl = this.gbxGaesajojik;
            this.xEditGridCell77.CellName = "gaesajojik";
            this.xEditGridCell77.Col = 52;
            this.xEditGridCell77.HeaderText = "gaesajojik";
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.BindControl = this.gbxPocket_gubun;
            this.xEditGridCell78.CellName = "pocket_gubun";
            this.xEditGridCell78.Col = 53;
            this.xEditGridCell78.HeaderText = "pocket_gubun";
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.BindControl = this.emkPocket_size_start;
            this.xEditGridCell79.CellName = "pocket_size_start";
            this.xEditGridCell79.Col = 54;
            this.xEditGridCell79.HeaderText = "pocket_size_start";
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.BindControl = this.emkPocket_size_end;
            this.xEditGridCell80.CellName = "pocket_size_end";
            this.xEditGridCell80.Col = 55;
            this.xEditGridCell80.HeaderText = "pocket_size_end";
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.BindControl = this.gbxYokchang_stage;
            this.xEditGridCell81.CellName = "yokchang_stage";
            this.xEditGridCell81.Col = 56;
            this.xEditGridCell81.HeaderText = "yokchang_stage";
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.BindControl = this.emkTotal_count;
            this.xEditGridCell82.CellName = "total_count";
            this.xEditGridCell82.Col = 57;
            this.xEditGridCell82.HeaderText = "total_count";
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.BindControl = this.gbxYungyang_siksa_gubun;
            this.xEditGridCell83.CellName = "yungyang_siksa_gubun";
            this.xEditGridCell83.Col = 58;
            this.xEditGridCell83.HeaderText = "yungyang_siksa_gubun";
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.BindControl = this.emkYunayang_siksa_yang;
            this.xEditGridCell84.CellName = "yungyang_siksa_yang";
            this.xEditGridCell84.Col = 59;
            this.xEditGridCell84.HeaderText = "yungyang_siksa_yang";
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.BindControl = this.emkYungyang_siksa_percent;
            this.xEditGridCell85.CellName = "yungyang_siksa_percent";
            this.xEditGridCell85.Col = 60;
            this.xEditGridCell85.HeaderText = "yungyang_siksa_percent";
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.BindControl = this.gbxYungyang_suaek_yn;
            this.xEditGridCell86.CellName = "yungyang_suaek_yn";
            this.xEditGridCell86.Col = 61;
            this.xEditGridCell86.HeaderText = "yungyang_suaek_yn";
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.BindControl = this.emkYungyang_suaek_yang;
            this.xEditGridCell87.CellName = "yungyang_suaek_yang";
            this.xEditGridCell87.Col = 62;
            this.xEditGridCell87.HeaderText = "yungyang_suaek_yang";
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.BindControl = this.txtChuchi_text;
            this.xEditGridCell88.CellLen = 1000;
            this.xEditGridCell88.CellName = "chuchi_text";
            this.xEditGridCell88.Col = 63;
            this.xEditGridCell88.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell88.HeaderText = "chuchi_text";
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.BindControl = this.emkYokchang_hb;
            this.xEditGridCell89.CellName = "yokchang_hb";
            this.xEditGridCell89.Col = 64;
            this.xEditGridCell89.HeaderText = "yokchang_hb";
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.BindControl = this.emkYokchang_alb;
            this.xEditGridCell90.CellName = "yokchang_alb";
            this.xEditGridCell90.Col = 65;
            this.xEditGridCell90.HeaderText = "yokchang_alb";
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.BindControl = this.emkYokchang_Tp;
            this.xEditGridCell91.CellName = "yokchang_tp";
            this.xEditGridCell91.Col = 66;
            this.xEditGridCell91.HeaderText = "yokchang_tp";
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.BindControl = this.dpbWeight;
            this.xEditGridCell92.CellName = "yokchang_weight";
            this.xEditGridCell92.Col = 67;
            this.xEditGridCell92.HeaderText = "yokchang_weight";
            this.xEditGridCell92.IsUpdCol = false;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = 9;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Location = new System.Drawing.Point(602, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(79, 28);
            this.btnPrint.TabIndex = 65;
            this.btnPrint.Text = "出力";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(682, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.Size = new System.Drawing.Size(325, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "출력.gif");
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xPanel7);
            this.xPanel3.Controls.Add(this.xPanel6);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel3.Location = new System.Drawing.Point(5, 33);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(226, 672);
            this.xPanel3.TabIndex = 2;
            // 
            // xPanel7
            // 
            this.xPanel7.Controls.Add(this.calBedsore);
            this.xPanel7.Controls.Add(this.xLabel8);
            this.xPanel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel7.Location = new System.Drawing.Point(0, 398);
            this.xPanel7.Name = "xPanel7";
            this.xPanel7.Size = new System.Drawing.Size(226, 274);
            this.xPanel7.TabIndex = 1;
            // 
            // calBedsore
            // 
            this.calBedsore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calBedsore.FullHolidaySelectable = true;
            this.calBedsore.ImageList = this.imageList1;
            this.calBedsore.Location = new System.Drawing.Point(0, 25);
            this.calBedsore.MaxDate = new System.DateTime(2015, 10, 6, 0, 0, 0, 0);
            this.calBedsore.MinDate = new System.DateTime(1995, 10, 6, 0, 0, 0, 0);
            this.calBedsore.Name = "calBedsore";
            this.calBedsore.Size = new System.Drawing.Size(226, 249);
            this.calBedsore.TabIndex = 1;
            this.calBedsore.DaySelected += new IHIS.Framework.XCalendarDaySelectedEventHandler(this.calBedsore_DaySelected);
            this.calBedsore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.calBedsore_MouseDown);
            this.calBedsore.MonthChanged += new IHIS.Framework.XCalendarMonthChangedEventHandler(this.calBedsore_MonthChanged);
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.xLabel8.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel8.Location = new System.Drawing.Point(0, 0);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(233, 25);
            this.xLabel8.TabIndex = 97;
            this.xLabel8.Text = "褥瘡患者評価";
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.xLabel10);
            this.xPanel6.Controls.Add(this.dpbLifeselfgrade);
            this.xPanel6.Controls.Add(this.xLabel4);
            this.xPanel6.Controls.Add(this.mbMetress);
            this.xPanel6.Controls.Add(this.btnMatress);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel6.Location = new System.Drawing.Point(0, 340);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(226, 332);
            this.xPanel6.TabIndex = 1;
            // 
            // xLabel10
            // 
            this.xLabel10.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel10.Location = new System.Drawing.Point(1, 61);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(110, 20);
            this.xLabel10.TabIndex = 106;
            this.xLabel10.Text = "日常生活自立度";
            this.xLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.xLabel10, "皮膚損傷範囲を測定：[長径(cm)×長径と直交する最大経(cm)]");
            // 
            // dpbLifeselfgrade
            // 
            this.dpbLifeselfgrade.Location = new System.Drawing.Point(113, 61);
            this.dpbLifeselfgrade.Name = "dpbLifeselfgrade";
            this.dpbLifeselfgrade.Size = new System.Drawing.Size(107, 20);
            this.dpbLifeselfgrade.TabIndex = 1;
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.xLabel4.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel4.Location = new System.Drawing.Point(0, 0);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(233, 25);
            this.xLabel4.TabIndex = 96;
            this.xLabel4.Text = "マットレス";
            // 
            // mbMetress
            // 
            this.mbMetress.DisplayMemoText = true;
            this.mbMetress.Location = new System.Drawing.Point(1, 31);
            this.mbMetress.MaxTextLength = 1000;
            this.mbMetress.Name = "mbMetress";
            this.mbMetress.Protect = true;
            this.mbMetress.Size = new System.Drawing.Size(176, 20);
            this.mbMetress.TabIndex = 35;
            // 
            // btnMatress
            // 
            this.btnMatress.Font = new System.Drawing.Font("MS UI Gothic", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatress.ImageIndex = 5;
            this.btnMatress.ImageList = this.ImageList;
            this.btnMatress.Location = new System.Drawing.Point(176, 30);
            this.btnMatress.Name = "btnMatress";
            this.btnMatress.Size = new System.Drawing.Size(52, 22);
            this.btnMatress.TabIndex = 95;
            this.btnMatress.Text = "設定";
            this.btnMatress.Click += new System.EventHandler(this.btnMatress_Click);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.grdNur6001);
            this.xPanel4.Controls.Add(this.xLabel1);
            this.xPanel4.Controls.Add(this.xPanel5);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel4.Location = new System.Drawing.Point(0, 0);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(226, 340);
            this.xPanel4.TabIndex = 0;
            // 
            // grdNur6001
            // 
            this.grdNur6001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell16,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell17,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8});
            this.grdNur6001.ColPerLine = 8;
            this.grdNur6001.Cols = 8;
            this.grdNur6001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNur6001.FixedRows = 1;
            this.grdNur6001.HeaderHeights.Add(21);
            this.grdNur6001.Location = new System.Drawing.Point(0, 25);
            this.grdNur6001.Name = "grdNur6001";
            this.grdNur6001.QuerySQL = resources.GetString("grdNur6001.QuerySQL");
            this.grdNur6001.Rows = 2;
            this.grdNur6001.Size = new System.Drawing.Size(226, 278);
            this.grdNur6001.TabIndex = 0;
            this.grdNur6001.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNur6001_ItemValueChanging);
            this.grdNur6001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNur6001_QueryStarting);
            this.grdNur6001.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdNur6001_MouseUp);
            this.grdNur6001.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNur6001_SaveEnd);
            this.grdNur6001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNur6001_RowFocusChanged);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "bunho";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "from_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.HeaderText = "褥瘡管理開始日";
            this.xEditGridCell1.IsJapanYearType = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "end_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.Col = 7;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell2.HeaderText = "褥瘡管理終了日";
            this.xEditGridCell2.IsJapanYearType = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "fkinp1001";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "chk1";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "chk2";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "chk3";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "chk4";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "chk5";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "chk6";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bedsore_buwi1";
            this.xEditGridCell3.CellWidth = 70;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.HeaderText = "部位1";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "bedsore_buwi2";
            this.xEditGridCell4.CellWidth = 70;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell4.HeaderText = "部位2";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bedsore_buwi3";
            this.xEditGridCell5.CellWidth = 70;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.HeaderText = "部位3";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "bedsore_buwi4";
            this.xEditGridCell6.CellWidth = 70;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.HeaderText = "部位4";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "bedsore_buwi5";
            this.xEditGridCell7.CellWidth = 70;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell7.HeaderText = "部位5";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "bedsore_buwi6";
            this.xEditGridCell8.CellWidth = 70;
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell8.HeaderText = "部位6";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.xLabel1.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel1.Location = new System.Drawing.Point(0, 0);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(233, 25);
            this.xLabel1.TabIndex = 1;
            this.xLabel1.Text = "褥瘡患者";
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.btnNur6001Query);
            this.xPanel5.Controls.Add(this.btnInsert);
            this.xPanel5.Controls.Add(this.btnDelete);
            this.xPanel5.Controls.Add(this.btnSave);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel5.Location = new System.Drawing.Point(0, 303);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(226, 37);
            this.xPanel5.TabIndex = 1;
            // 
            // btnNur6001Query
            // 
            this.btnNur6001Query.ImageIndex = 8;
            this.btnNur6001Query.ImageList = this.ImageList;
            this.btnNur6001Query.Location = new System.Drawing.Point(3, 3);
            this.btnNur6001Query.Name = "btnNur6001Query";
            this.btnNur6001Query.Size = new System.Drawing.Size(55, 28);
            this.btnNur6001Query.TabIndex = 4;
            this.btnNur6001Query.Text = "照会";
            this.btnNur6001Query.Click += new System.EventHandler(this.btnNur6001Query_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.ImageIndex = 6;
            this.btnInsert.ImageList = this.ImageList;
            this.btnInsert.Location = new System.Drawing.Point(58, 3);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(55, 28);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "入力";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 1;
            this.btnDelete.ImageList = this.ImageList;
            this.btnDelete.Location = new System.Drawing.Point(113, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "削除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.ImageList;
            this.btnSave.Location = new System.Drawing.Point(168, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(231, 33);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 672);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // tabBuwi
            // 
            this.tabBuwi.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabBuwi.IDEPixelArea = true;
            this.tabBuwi.IDEPixelBorder = false;
            this.tabBuwi.ImageList = this.imageList1;
            this.tabBuwi.Location = new System.Drawing.Point(0, 0);
            this.tabBuwi.Name = "tabBuwi";
            this.tabBuwi.Size = new System.Drawing.Size(778, 26);
            this.tabBuwi.TabIndex = 0;
            this.tabBuwi.SelectionChanged += new System.EventHandler(this.tabBuwi_SelectionChanged);
            this.tabBuwi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabBuwi_MouseDown);
            // 
            // labDepth
            // 
            this.labDepth.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.labDepth.Location = new System.Drawing.Point(3, 59);
            this.labDepth.Name = "labDepth";
            this.labDepth.Size = new System.Drawing.Size(86, 20);
            this.labDepth.TabIndex = 5;
            this.labDepth.Text = "深さ";
            this.labDepth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labDepth, "創内の一番深い部分で評価し、改善に伴い創底が浅くなった場合、これと相応の深さとして評価する");
            // 
            // labExdate
            // 
            this.labExdate.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.labExdate.Location = new System.Drawing.Point(3, 88);
            this.labExdate.Name = "labExdate";
            this.labExdate.Size = new System.Drawing.Size(86, 20);
            this.labExdate.TabIndex = 17;
            this.labExdate.Text = "滲出液";
            this.labExdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel22
            // 
            this.xLabel22.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel22.Location = new System.Drawing.Point(3, 455);
            this.xLabel22.Name = "xLabel22";
            this.xLabel22.Size = new System.Drawing.Size(86, 20);
            this.xLabel22.TabIndex = 29;
            this.xLabel22.Text = "処置";
            this.xLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel23
            // 
            this.xLabel23.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel23.Location = new System.Drawing.Point(92, 540);
            this.xLabel23.Name = "xLabel23";
            this.xLabel23.Size = new System.Drawing.Size(36, 20);
            this.xLabel23.TabIndex = 30;
            this.xLabel23.Text = "Hb";
            this.xLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel24
            // 
            this.xLabel24.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel24.Location = new System.Drawing.Point(180, 540);
            this.xLabel24.Name = "xLabel24";
            this.xLabel24.Size = new System.Drawing.Size(36, 20);
            this.xLabel24.TabIndex = 31;
            this.xLabel24.Text = "Alb";
            this.xLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel25
            // 
            this.xLabel25.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel25.Location = new System.Drawing.Point(268, 540);
            this.xLabel25.Name = "xLabel25";
            this.xLabel25.Size = new System.Drawing.Size(36, 20);
            this.xLabel25.TabIndex = 32;
            this.xLabel25.Text = "TP";
            this.xLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel31
            // 
            this.xLabel31.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel31.Location = new System.Drawing.Point(3, 540);
            this.xLabel31.Name = "xLabel31";
            this.xLabel31.Size = new System.Drawing.Size(86, 20);
            this.xLabel31.TabIndex = 62;
            this.xLabel31.Text = "検査値";
            this.xLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.txtBedSore_gita);
            this.pnlInfo.Controls.Add(this.xLabel11);
            this.pnlInfo.Controls.Add(this.xLabel43);
            this.pnlInfo.Controls.Add(this.emkYungyang_suaek_yang);
            this.pnlInfo.Controls.Add(this.gbxYungyang_suaek_yn);
            this.pnlInfo.Controls.Add(this.xLabel42);
            this.pnlInfo.Controls.Add(this.dtpIpwon);
            this.pnlInfo.Controls.Add(this.btnWeight);
            this.pnlInfo.Controls.Add(this.dpbWeight);
            this.pnlInfo.Controls.Add(this.xLabel26);
            this.pnlInfo.Controls.Add(this.xLabel41);
            this.pnlInfo.Controls.Add(this.emkYungyang_siksa_percent);
            this.pnlInfo.Controls.Add(this.xLabel39);
            this.pnlInfo.Controls.Add(this.xLabel34);
            this.pnlInfo.Controls.Add(this.emkYunayang_siksa_yang);
            this.pnlInfo.Controls.Add(this.gbxYungyang_siksa_gubun);
            this.pnlInfo.Controls.Add(this.xLabel33);
            this.pnlInfo.Controls.Add(this.xLabel30);
            this.pnlInfo.Controls.Add(this.gbxYokchang_stage);
            this.pnlInfo.Controls.Add(this.xLabel27);
            this.pnlInfo.Controls.Add(this.emkTotal_count);
            this.pnlInfo.Controls.Add(this.emkPocket_size_end);
            this.pnlInfo.Controls.Add(this.emkPocket_size_start);
            this.pnlInfo.Controls.Add(this.emkYokchang_size_end);
            this.pnlInfo.Controls.Add(this.emkYokchang_size_start);
            this.pnlInfo.Controls.Add(this.xLabel16);
            this.pnlInfo.Controls.Add(this.xLabel21);
            this.pnlInfo.Controls.Add(this.xLabel28);
            this.pnlInfo.Controls.Add(this.xLabel20);
            this.pnlInfo.Controls.Add(this.gbxPocket_gubun);
            this.pnlInfo.Controls.Add(this.labPocket);
            this.pnlInfo.Controls.Add(this.gbxGaesajojik);
            this.pnlInfo.Controls.Add(this.labNT);
            this.pnlInfo.Controls.Add(this.gbxYukajojik);
            this.pnlInfo.Controls.Add(this.labGranulation);
            this.pnlInfo.Controls.Add(this.gbxYokchang_gamyum);
            this.pnlInfo.Controls.Add(this.labInf);
            this.pnlInfo.Controls.Add(this.xLabel7);
            this.pnlInfo.Controls.Add(this.labSize);
            this.pnlInfo.Controls.Add(this.gbxSamchul_yang);
            this.pnlInfo.Controls.Add(this.cboLast_sayu);
            this.pnlInfo.Controls.Add(this.xLabel52);
            this.pnlInfo.Controls.Add(this.cboFirst_sayu);
            this.pnlInfo.Controls.Add(this.xLabel51);
            this.pnlInfo.Controls.Add(this.txtChuchi_text);
            this.pnlInfo.Controls.Add(this.chkEndYn);
            this.pnlInfo.Controls.Add(this.xLabel40);
            this.pnlInfo.Controls.Add(this.dtpAssessor_date);
            this.pnlInfo.Controls.Add(this.xLabel36);
            this.pnlInfo.Controls.Add(this.xLabel32);
            this.pnlInfo.Controls.Add(this.txtAssessor);
            this.pnlInfo.Controls.Add(this.fbAssessor);
            this.pnlInfo.Controls.Add(this.emkYokchang_Tp);
            this.pnlInfo.Controls.Add(this.labDepth);
            this.pnlInfo.Controls.Add(this.gbxYokchang_deep);
            this.pnlInfo.Controls.Add(this.xLabel25);
            this.pnlInfo.Controls.Add(this.emkYokchang_hb);
            this.pnlInfo.Controls.Add(this.xLabel24);
            this.pnlInfo.Controls.Add(this.emkYokchang_alb);
            this.pnlInfo.Controls.Add(this.xLabel23);
            this.pnlInfo.Controls.Add(this.labExdate);
            this.pnlInfo.Controls.Add(this.xLabel22);
            this.pnlInfo.Controls.Add(this.xLabel31);
            this.pnlInfo.Controls.Add(this.gbxYokchang_size);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(0, 26);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(506, 646);
            this.pnlInfo.TabIndex = 63;
            // 
            // xLabel11
            // 
            this.xLabel11.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel11.Location = new System.Drawing.Point(3, 565);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(86, 20);
            this.xLabel11.TabIndex = 161;
            this.xLabel11.Text = "備考";
            this.xLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel43
            // 
            this.xLabel43.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel43.Location = new System.Drawing.Point(347, 428);
            this.xLabel43.Name = "xLabel43";
            this.xLabel43.Size = new System.Drawing.Size(55, 20);
            this.xLabel43.TabIndex = 148;
            this.xLabel43.Text = "kcal/day";
            this.xLabel43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel42
            // 
            this.xLabel42.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel42.Location = new System.Drawing.Point(92, 428);
            this.xLabel42.Name = "xLabel42";
            this.xLabel42.Size = new System.Drawing.Size(55, 20);
            this.xLabel42.TabIndex = 145;
            this.xLabel42.Text = "輸液";
            this.xLabel42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpIpwon
            // 
            this.dtpIpwon.IsJapanYearType = true;
            this.dtpIpwon.Location = new System.Drawing.Point(92, 1);
            this.dtpIpwon.Name = "dtpIpwon";
            this.dtpIpwon.ReadOnly = true;
            this.dtpIpwon.Size = new System.Drawing.Size(108, 20);
            this.dtpIpwon.TabIndex = 144;
            this.dtpIpwon.TabStop = false;
            // 
            // btnWeight
            // 
            this.btnWeight.ImageIndex = 7;
            this.btnWeight.ImageList = this.ImageList;
            this.btnWeight.Location = new System.Drawing.Point(441, 539);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnWeight.Size = new System.Drawing.Size(58, 21);
            this.btnWeight.TabIndex = 160;
            this.btnWeight.Text = "設定";
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // xLabel26
            // 
            this.xLabel26.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel26.Location = new System.Drawing.Point(357, 540);
            this.xLabel26.Name = "xLabel26";
            this.xLabel26.Size = new System.Drawing.Size(36, 20);
            this.xLabel26.TabIndex = 142;
            this.xLabel26.Text = "体重";
            this.xLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel41
            // 
            this.xLabel41.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel41.Location = new System.Drawing.Point(365, 399);
            this.xLabel41.Name = "xLabel41";
            this.xLabel41.Size = new System.Drawing.Size(17, 20);
            this.xLabel41.TabIndex = 140;
            this.xLabel41.Text = "%";
            this.xLabel41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel39
            // 
            this.xLabel39.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel39.Location = new System.Drawing.Point(231, 399);
            this.xLabel39.Name = "xLabel39";
            this.xLabel39.Size = new System.Drawing.Size(60, 20);
            this.xLabel39.TabIndex = 138;
            this.xLabel39.Text = "摂取状況";
            this.xLabel39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel34
            // 
            this.xLabel34.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel34.Location = new System.Drawing.Point(166, 399);
            this.xLabel34.Name = "xLabel34";
            this.xLabel34.Size = new System.Drawing.Size(55, 20);
            this.xLabel34.TabIndex = 137;
            this.xLabel34.Text = "kcal/day";
            this.xLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel33
            // 
            this.xLabel33.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel33.Location = new System.Drawing.Point(3, 375);
            this.xLabel33.Name = "xLabel33";
            this.xLabel33.Size = new System.Drawing.Size(86, 20);
            this.xLabel33.TabIndex = 134;
            this.xLabel33.Text = "栄養";
            this.xLabel33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel30
            // 
            this.xLabel30.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel30.Location = new System.Drawing.Point(165, 345);
            this.xLabel30.Name = "xLabel30";
            this.xLabel30.Size = new System.Drawing.Size(23, 22);
            this.xLabel30.TabIndex = 133;
            this.xLabel30.Text = "点";
            this.xLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel27
            // 
            this.xLabel27.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel27.Location = new System.Drawing.Point(3, 315);
            this.xLabel27.Name = "xLabel27";
            this.xLabel27.Size = new System.Drawing.Size(86, 20);
            this.xLabel27.TabIndex = 131;
            this.xLabel27.Text = "褥瘡ステージ";
            this.xLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel16
            // 
            this.xLabel16.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel16.Location = new System.Drawing.Point(3, 345);
            this.xLabel16.Name = "xLabel16";
            this.xLabel16.Size = new System.Drawing.Size(86, 22);
            this.xLabel16.TabIndex = 125;
            this.xLabel16.Text = "総数";
            this.xLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel21
            // 
            this.xLabel21.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel21.Location = new System.Drawing.Point(92, 260);
            this.xLabel21.Name = "xLabel21";
            this.xLabel21.Size = new System.Drawing.Size(135, 20);
            this.xLabel21.TabIndex = 124;
            this.xLabel21.Text = "[長径(cm) X 短径(cm)]";
            this.xLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel28
            // 
            this.xLabel28.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel28.Location = new System.Drawing.Point(301, 260);
            this.xLabel28.Name = "xLabel28";
            this.xLabel28.Size = new System.Drawing.Size(23, 20);
            this.xLabel28.TabIndex = 121;
            this.xLabel28.Text = "X";
            this.xLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel20
            // 
            this.xLabel20.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel20.Location = new System.Drawing.Point(92, 117);
            this.xLabel20.Name = "xLabel20";
            this.xLabel20.Size = new System.Drawing.Size(135, 20);
            this.xLabel20.TabIndex = 119;
            this.xLabel20.Text = "[長径(cm) X 短径(cm)]";
            this.xLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labPocket
            // 
            this.labPocket.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.labPocket.Location = new System.Drawing.Point(3, 260);
            this.labPocket.Name = "labPocket";
            this.labPocket.Size = new System.Drawing.Size(86, 20);
            this.labPocket.TabIndex = 116;
            this.labPocket.Text = "ポケット";
            this.labPocket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labPocket, "毎回同じ体位で、ポケット全周(潰瘍面も含め) \r\n[長径(cm)×短径(cm)]から潰瘍の大きさを差し引いたもの");
            // 
            // labNT
            // 
            this.labNT.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.labNT.Location = new System.Drawing.Point(3, 230);
            this.labNT.Name = "labNT";
            this.labNT.Size = new System.Drawing.Size(86, 20);
            this.labNT.TabIndex = 114;
            this.labNT.Text = "壊死組織";
            this.labNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labNT, "混在している場合は全体的に多い病態を持って判断する");
            // 
            // labGranulation
            // 
            this.labGranulation.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.labGranulation.Location = new System.Drawing.Point(3, 200);
            this.labGranulation.Name = "labGranulation";
            this.labGranulation.Size = new System.Drawing.Size(86, 20);
            this.labGranulation.TabIndex = 112;
            this.labGranulation.Text = "肉芽組織";
            this.labGranulation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labInf
            // 
            this.labInf.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.labInf.Location = new System.Drawing.Point(3, 170);
            this.labInf.Name = "labInf";
            this.labInf.Size = new System.Drawing.Size(86, 20);
            this.labInf.TabIndex = 110;
            this.labInf.Text = "炎症/感染";
            this.labInf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel7.Location = new System.Drawing.Point(301, 117);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(23, 20);
            this.xLabel7.TabIndex = 108;
            this.xLabel7.Text = "X";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labSize
            // 
            this.labSize.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.labSize.Location = new System.Drawing.Point(3, 117);
            this.labSize.Name = "labSize";
            this.labSize.Size = new System.Drawing.Size(86, 20);
            this.labSize.TabIndex = 105;
            this.labSize.Text = "大きさ";
            this.labSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labSize, "皮膚損傷範囲を測定：[長径(cm)×長径と直交する最大経(cm)]");
            // 
            // xLabel52
            // 
            this.xLabel52.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel52.Location = new System.Drawing.Point(353, 1);
            this.xLabel52.Name = "xLabel52";
            this.xLabel52.Size = new System.Drawing.Size(35, 20);
            this.xLabel52.TabIndex = 102;
            this.xLabel52.Text = "退院";
            this.xLabel52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel51
            // 
            this.xLabel51.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel51.Location = new System.Drawing.Point(203, 1);
            this.xLabel51.Name = "xLabel51";
            this.xLabel51.Size = new System.Drawing.Size(34, 20);
            this.xLabel51.TabIndex = 100;
            this.xLabel51.Text = "入院";
            this.xLabel51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel40
            // 
            this.xLabel40.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel40.Location = new System.Drawing.Point(3, 1);
            this.xLabel40.Name = "xLabel40";
            this.xLabel40.Size = new System.Drawing.Size(86, 20);
            this.xLabel40.TabIndex = 73;
            this.xLabel40.Text = "入院日付";
            this.xLabel40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel36
            // 
            this.xLabel36.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel36.Location = new System.Drawing.Point(3, 30);
            this.xLabel36.Name = "xLabel36";
            this.xLabel36.Size = new System.Drawing.Size(86, 20);
            this.xLabel36.TabIndex = 69;
            this.xLabel36.Text = "評価日付";
            this.xLabel36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel32
            // 
            this.xLabel32.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel32.Location = new System.Drawing.Point(203, 30);
            this.xLabel32.Name = "xLabel32";
            this.xLabel32.Size = new System.Drawing.Size(64, 20);
            this.xLabel32.TabIndex = 68;
            this.xLabel32.Text = "評価者";
            this.xLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "assessor";
            this.findColumnInfo1.ColWidth = 68;
            this.findColumnInfo1.HeaderText = "USER ID";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "assessor_name";
            this.findColumnInfo2.ColWidth = 119;
            this.findColumnInfo2.HeaderText = "評価者";
            // 
            // grdImage
            // 
            this.grdImage.AddedHeaderLine = 1;
            this.grdImage.CallerID = '3';
            this.grdImage.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell15,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell93,
            this.xEditGridCell94});
            this.grdImage.ColPerLine = 2;
            this.grdImage.Cols = 3;
            this.grdImage.DefaultHeight = 180;
            this.grdImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdImage.FixedCols = 1;
            this.grdImage.FixedRows = 2;
            this.grdImage.HeaderHeights.Add(21);
            this.grdImage.HeaderHeights.Add(0);
            this.grdImage.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdImage.Location = new System.Drawing.Point(0, 26);
            this.grdImage.Name = "grdImage";
            this.grdImage.QuerySQL = resources.GetString("grdImage.QuerySQL");
            this.grdImage.RowHeaderVisible = true;
            this.grdImage.Rows = 3;
            this.grdImage.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdImage.Size = new System.Drawing.Size(272, 620);
            this.grdImage.TabIndex = 66;
            this.grdImage.Tag = "瘡内の一番深い部分で評価し、";
            this.grdImage.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdImage_QueryEnd);
            this.grdImage.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdImage_QueryStarting);
            this.grdImage.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdImage_PreSaveLayout);
            this.grdImage.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdImage_SaveEnd);
            this.grdImage.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdImage_GridButtonClick);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "bunho";
            this.xEditGridCell15.CellWidth = 197;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "from_date";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "bedsore_buwi";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "assessor_date";
            this.xEditGridCell44.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "seq";
            this.xEditGridCell45.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell45.CellWidth = 30;
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "image";
            this.xEditGridCell46.CellType = IHIS.Framework.XCellDataType.Binary;
            this.xEditGridCell46.CellWidth = 192;
            this.xEditGridCell46.Col = 1;
            this.xEditGridCell46.HeaderText = "Image";
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.Row = 1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.ButtonText = "フ\nァ\nイ\nル";
            this.xEditGridCell47.CellName = "button";
            this.xEditGridCell47.CellWidth = 25;
            this.xEditGridCell47.Col = 2;
            this.xEditGridCell47.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell47.IsUpdCol = false;
            this.xEditGridCell47.Row = 1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "image_path";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.IsUpdatable = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "base_image_path";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 1;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "イメージ";
            this.xGridHeader1.HeaderWidth = 192;
            // 
            // layCalendar
            // 
            this.layCalendar.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5});
            this.layCalendar.QuerySQL = resources.GetString("layCalendar.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "from_date";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "bedsore_buwi";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "assessor_date";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "assessor";
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.grdImage);
            this.pnlImage.Controls.Add(this.panel3);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlImage.Location = new System.Drawing.Point(506, 26);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(272, 646);
            this.pnlImage.TabIndex = 67;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnImageAdd);
            this.panel3.Controls.Add(this.btnImageDelete);
            this.panel3.Controls.Add(this.xLabel37);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 26);
            this.panel3.TabIndex = 0;
            // 
            // btnImageAdd
            // 
            this.btnImageAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImageAdd.ImageIndex = 0;
            this.btnImageAdd.ImageList = this.ImageList;
            this.btnImageAdd.Location = new System.Drawing.Point(162, 0);
            this.btnImageAdd.Name = "btnImageAdd";
            this.btnImageAdd.Size = new System.Drawing.Size(55, 26);
            this.btnImageAdd.TabIndex = 1;
            this.btnImageAdd.Text = "追加";
            this.btnImageAdd.Click += new System.EventHandler(this.btnImageAdd_Click);
            // 
            // btnImageDelete
            // 
            this.btnImageDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImageDelete.ImageIndex = 1;
            this.btnImageDelete.ImageList = this.ImageList;
            this.btnImageDelete.Location = new System.Drawing.Point(217, 0);
            this.btnImageDelete.Name = "btnImageDelete";
            this.btnImageDelete.Size = new System.Drawing.Size(55, 26);
            this.btnImageDelete.TabIndex = 2;
            this.btnImageDelete.Text = "削除";
            this.btnImageDelete.Click += new System.EventHandler(this.btnImageDelete_Click);
            // 
            // xLabel37
            // 
            this.xLabel37.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xLabel37.Image = ((System.Drawing.Image)(resources.GetObject("xLabel37.Image")));
            this.xLabel37.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel37.Location = new System.Drawing.Point(0, 0);
            this.xLabel37.Name = "xLabel37";
            this.xLabel37.Size = new System.Drawing.Size(272, 26);
            this.xLabel37.TabIndex = 0;
            this.xLabel37.Text = "IMAGE";
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "bedsore_poket_start1";
            this.xEditGridCell57.Col = 33;
            // 
            // jobImageList
            // 
            this.jobImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("jobImageList.ImageStream")));
            this.jobImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.jobImageList.Images.SetKeyName(0, "");
            // 
            // layComboSet
            // 
            this.layComboSet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem8,
            this.multiLayoutItem9});
            this.layComboSet.QuerySQL = "SELECT CODE      CODE,\r\n       CODE_NAME CODE_NAME,\r\n       SORT_KEY\r\n  FROM NUR0" +
                "102\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = :f_code_type\r\n ORDER BY" +
                " 1, 3";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "code";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "code_name";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 20;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlInfo);
            this.pnlMain.Controls.Add(this.pnlImage);
            this.pnlMain.Controls.Add(this.tabBuwi);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(234, 33);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(778, 672);
            this.pnlMain.TabIndex = 68;
            // 
            // layImage
            // 
            this.layImage.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6});
            this.layImage.QuerySQL = resources.GetString("layImage.QuerySQL");
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "image_path";
            // 
            // layPrintLoad
            // 
            this.layPrintLoad.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
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
            this.multiLayoutItem75});
            this.layPrintLoad.QuerySQL = resources.GetString("layPrintLoad.QuerySQL");
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "bunho";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "name";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "name2";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "gender";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "birth";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "age";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "buwi";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "from_date";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "assessor";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "assessor_date";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "depth";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "exudate";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "s_size";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "infection";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "granulation";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "necrotic_tissue";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "pocket";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "total";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "stage";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "yungyang_siksa_gubun";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "yungyang_siksa_yang";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "yungyang_siksa_percent";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "yungyang_suaek_yn";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "yungyang_suaek_yang";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "chuchi_text";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "yokchang_hb";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "yokchang_alb";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "yokchang_tp";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "yokchang_weight";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "ipwon_date";
            this.multiLayoutItem38.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "ho_dong";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "ho_code";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "bedsore_buwi";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "image";
            // 
            // NUR6001U00
            // 
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "NUR6001U00";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Size = new System.Drawing.Size(1017, 740);
            this.UserChanged += new System.EventHandler(this.NUR6001U00_UserChanged);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrint)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNur6002Copy)).EndInit();
            this.gbxYokchang_deep.ResumeLayout(false);
            this.gbxSamchul_yang.ResumeLayout(false);
            this.gbxYokchang_size.ResumeLayout(false);
            this.gbxYokchang_gamyum.ResumeLayout(false);
            this.gbxYukajojik.ResumeLayout(false);
            this.gbxGaesajojik.ResumeLayout(false);
            this.gbxPocket_gubun.ResumeLayout(false);
            this.gbxYokchang_stage.ResumeLayout(false);
            this.gbxYungyang_siksa_gubun.ResumeLayout(false);
            this.gbxYungyang_suaek_yn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNur6002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calBedsore)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNur6001)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNur6002_del)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMonthNur6002)).EndInit();
            this.pnlImage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPrintLoad)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// <summary>
		/// 수술예약 등록 콤보박스 셋팅
		/// </summary>
		/// <param name="aComboGubun">
		/// 콤보구분
		/// </param>
		#region 콤보박스 셋팅
		private void GetComboSetting(string aComboGubun)
        {
            layComboSet.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layComboSet.SetBindVarValue("f_code_type", aComboGubun);

            if (layComboSet.QueryLayout(false))
            {
                switch (aComboGubun)
                {
                    case "BEDSORE_BUWI":
                        if (this.layComboSet.LayoutTable.Rows.Count > 0)
                        {
                            this.grdNur6001.SetComboItems("bedsore_buwi1", this.layComboSet.LayoutTable, "code_name", "code");
                            this.grdNur6001.SetComboItems("bedsore_buwi2", this.layComboSet.LayoutTable, "code_name", "code");
                            this.grdNur6001.SetComboItems("bedsore_buwi3", this.layComboSet.LayoutTable, "code_name", "code");
                            this.grdNur6001.SetComboItems("bedsore_buwi4", this.layComboSet.LayoutTable, "code_name", "code");
                            this.grdNur6001.SetComboItems("bedsore_buwi5", this.layComboSet.LayoutTable, "code_name", "code");
                            this.grdNur6001.SetComboItems("bedsore_buwi6", this.layComboSet.LayoutTable, "code_name", "code");
                        }
                        break;
                    case "FIRST_SAYU":
                        if (this.layComboSet.LayoutTable.Rows.Count > 0)
                        {
                            this.cboFirst_sayu.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                        }
                        break;
                    case "LAST_SAYU":
                        if (this.layComboSet.LayoutTable.Rows.Count > 0)
                        {
                            this.cboLast_sayu.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
		}
		#endregion
		
		#region 스크린 로드
		protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

        private void SetToolTip()
        {
            //string msg = "";

            //for (int i = 0; i < pnlInfo.Controls.Count; i++)
            //{
            //    msg = "";
            //    if (pnlInfo.Controls[i].Name.Contains("lab"))
            //    { 
            //        //XLabel lb = pnlInfo.Controls[i] as XLabel;
            //        if(pnlInfo.Controls[i].Tag != null)
            //            msg = pnlInfo.Controls[i].Tag.ToString();

            //        toolTip1.SetToolTip(pnlInfo.Controls[i], msg);
            //    }
            //}
        }

        private void PostLoad()
        {
            /* FTP OPTION LOAD*/
            LoadFtpOption();
            SetToolTip();

            /* 콤보박스 셋팅 */
			this.GetComboSetting("BEDSORE_BUWI");
			this.GetComboSetting("FIRST_SAYU");
			this.GetComboSetting("LAST_SAYU");
			//
			this.calBedsore.SetActiveMonth(IHIS.Framework.EnvironInfo.GetSysDate().Year,IHIS.Framework.EnvironInfo.GetSysDate().Month);

			//달력일자 오늘로 세팅
			//this.calBedsore.SelectDate(IHIS.Framework.EnvironInfo.GetSysDate());

			//tabPage Clear				
			if (this.tabBuwi.Controls != null)
			{
				try
				{
					if (this.tabBuwi.TabPages.Count > 0)
						this.tabBuwi.TabPages.Clear();
				}
				catch(Exception e)
				{
					//https://sofiamedix.atlassian.net/browse/MED-10610
					//XMessageBox.Show(e.StackTrace.ToString());
					return;
				}
			}


			if (this.OpenParam != null)
			{
				this.ptbPatient.SetPatientID(this.OpenParam["bunho"].ToString());
			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.ptbPatient.SetPatientID(patientInfo.BunHo);
				}
            }
		}
		#endregion

        #region LoadFtpOption
        private void LoadFtpOption()
        {
            object retVal = null;
            string cmdText = @"SELECT CODE_NAME
                                  FROM NUR0102
                                 WHERE HOSP_CODE = :f_hosp_code 
                                   AND CODE_TYPE = 'FTP_OPTION'
                                   AND CODE      = UPPER(:f_gubun)";

            BindVarCollection bc = new BindVarCollection();
            //bc.Add("f_hosp_code", EnvironInfo.HospCode);
            //bc.Add("f_gubun", "user_id");

            //retVal = Service.ExecuteScalar(cmdText, bc);

            //if (TypeCheck.IsNull(retVal))
            //{
            //    XMessageBox.Show("コード管理画面にてFTP_OPTION情報(USER_ID, PASSWORD, SERVER_IMAGE_PATH, CLIENT_IMAGE_PATH)を登録してください。");
            //    return;
            //}
            //strFtpUser = retVal.ToString();
            strFtpUser = EnvironInfo.GetImageUserID();

            //bc.Clear();
            //bc.Add("f_hosp_code", EnvironInfo.HospCode);
            //bc.Add("f_gubun", "password");

            //retVal = Service.ExecuteScalar(cmdText, bc);

            //if (TypeCheck.IsNull(retVal))
            //{
            //    XMessageBox.Show("コード管理画面にてFTP_OPTION情報(USER_ID, PASSWORD, SERVER_IMAGE_PATH, CLIENT_IMAGE_PATH)を登録してください。");
            //    return;
            //}

            //strFtpPass = retVal.ToString();
            strFtpPass = EnvironInfo.GetImageUserPW();

            bc.Clear();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_gubun", "server_image_path");

            retVal = Service.ExecuteScalar(cmdText, bc);

            if (TypeCheck.IsNull(retVal))
            {
                XMessageBox.Show("コード管理画面にてFTP_OPTION情報(SERVER_IMAGE_PATH)を登録してください。");
                return;
            }

            strServerPath = retVal.ToString();

            bc.Clear();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_gubun", "client_image_path");

            retVal = Service.ExecuteScalar(cmdText, bc);

            if (TypeCheck.IsNull(retVal))
            {
                XMessageBox.Show("コード管理画面にてFTP_OPTION情報(CLIENT_IMAGE_PATH)を登録してください。");
                return;
            }

            strClientPath = retVal.ToString();
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
				this.ptbPatient.Focus();
				this.ptbPatient.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.ptbPatient.BunHo.ToString()))
			{
				return new XPatientInfo(this.ptbPatient.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion

        #region 부위콤보박스 값 변경시

        private void grdNur6001_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            grdNur6001.ItemValueChanging -= new ItemValueChangingEventHandler(grdNur6001_ItemValueChanging);
            for (int i = 1; i <= 6; i++)
            {
                if (e.ColName != "bedsore_buwi" + i.ToString())
                {
                    if (e.ChangeValue.Equals(grdNur6001.GetItemValue(e.RowNumber, "bedsore_buwi" + i.ToString())))
                    {
                        XMessageBox.Show("部位が重複されました。確認してください。");
                        grdNur6001.SetItemValue(e.RowNumber, e.ColName, null);
                    }
                }                
            }

            grdNur6001.ItemValueChanging += new ItemValueChangingEventHandler(grdNur6001_ItemValueChanging);

            if (e.DataRow.RowState == DataRowState.Added)
            {
                string number = e.ColName.Substring(12, 1);

                string cmdText = @"SELECT CODE_NAME CODE_NAME
                                  FROM NUR0102
                                 WHERE HOSP_CODE = :f_hosp_code
                                   AND CODE_TYPE = 'BEDSORE_BUWI'
                                   AND CODE      = :f_code";
                BindVarCollection bc = new BindVarCollection();
                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_code", e.ChangeValue.ToString());

                object buwi_name = Service.ExecuteScalar(cmdText, bc);

                if (buwi_name != null)
                {
                    this.grdNur6001.SetItemValue(e.RowNumber, "chk" + number, buwi_name.ToString());
                }
            }
        }

        #endregion

        #region 욕창환자등록,삭제,저장버튼
        //욕창환자등록정보조회
		private void btnNur6001Query_Click(object sender, System.EventArgs e)
		{
			if(this.ptbPatient.BunHo.ToString() != "")
			{
				//등록번호 유효여부
				isPatient = true;
			
				//재원여부 체크
                //ChkJaewon();  //주석2011.12.1 woo

				//욕창환자정보로드
				this.GetNur6001();
			}
		}

		//욕창환자입력
		private void btnInsert_Click(object sender, System.EventArgs e)
		{
			this.grdNur6001.AcceptData();
			int j = 0;
			if(this.ptbPatient.BunHo.ToString() != "")
			{
				for(int i = 0; i < this.grdNur6001.RowCount; i++)
				{
					if(this.grdNur6001.GetRowState(i) == DataRowState.Added)
					{
						j++;
					}
				}
				if(j >= 1)
				{
					this.GetMessage("insert_chk");
					return;
				}
				int row = this.grdNur6001.InsertRow(-1);

				this.grdNur6001.SetItemValue(row,"bunho",this.ptbPatient.BunHo);

                //재원여부
                ArrayList array = IsJaewon();
                if (array.Count > 0)
                    this.grdNur6001.SetItemValue(row, "fkinp1001", array[1].ToString());

                this.grdNur6001.SetItemValue(row, "from_date", IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                this.grdNur6001.SetItemValue(row, "end_date", "9998/12/31");
                this.grdNur6001.SetItemValue(row, "bedsore_buwi1", "0");
                this.grdNur6001.SetItemValue(row, "bedsore_buwi2", "0");
                this.grdNur6001.SetItemValue(row, "bedsore_buwi3", "0");
                this.grdNur6001.SetItemValue(row, "bedsore_buwi4", "0");
                this.grdNur6001.SetItemValue(row, "bedsore_buwi5", "0");
                this.grdNur6001.SetItemValue(row, "bedsore_buwi6", "0");

				this.grdNur6001.SetFocusToItem(row,"from_date");
			}
		}

		//욕창환자등록 삭제
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if (this.grdNur6001.RowCount <= 0 || this.grdNur6001.CurrentRowNumber < 0) return;

			this.grdNur6001.DeleteRow(this.grdNur6001.CurrentRowNumber);

		}

		//욕창환자등록 저장
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string save_Yn = "";
			this.AcceptData();
			for(int i = 0; i < this.grdNur6001.RowCount; i++)
			{
                if ((this.grdNur6001.GetItemValue(i, "bedsore_buwi1").ToString() == "" || this.grdNur6001.GetItemValue(i, "bedsore_buwi1").ToString() == "0") &&
                    (this.grdNur6001.GetItemValue(i, "bedsore_buwi2").ToString() == "" || this.grdNur6001.GetItemValue(i, "bedsore_buwi2").ToString() == "0") &&
				    (this.grdNur6001.GetItemValue(i, "bedsore_buwi3").ToString() == "" || this.grdNur6001.GetItemValue(i, "bedsore_buwi3").ToString() == "0") && 
                    (this.grdNur6001.GetItemValue(i, "bedsore_buwi4").ToString() == "" || this.grdNur6001.GetItemValue(i, "bedsore_buwi4").ToString() == "0") &&
				    (this.grdNur6001.GetItemValue(i, "bedsore_buwi5").ToString() == "" || this.grdNur6001.GetItemValue(i, "bedsore_buwi5").ToString() == "0") &&
                    (this.grdNur6001.GetItemValue(i, "bedsore_buwi6").ToString() == "" || this.grdNur6001.GetItemValue(i, "bedsore_buwi6").ToString() == "0"))
				{
					this.GetMessage("buwi_insert");
					save_Yn = "N";
					break;
				}
			}
			if(save_Yn != "N")
			{
				DialogResult result;
				mbxMsg = NetInfo.Language == LangMode.Jr ? "褥瘡患者情報を保存しますか。" : "욕창환자 정보를 저장하시겠습니까?.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "保存" : "저장";
				result = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					//욕창환자 저장처리
                    if (grdNur6001.SaveLayout())
                    {
                        GetNur6001();
                    }
                    else
                    {
                        XMessageBox.Show("保存に失敗しました。", "保存失敗", MessageBoxIcon.Error);
                    }
				}
			}
		}
		#endregion

		#region 환자번호 선택 성공,실패시
        private bool isPassQueryImage = false;
		private void xPatientBox1_PatientSelected(object sender, System.EventArgs e)
		{
            PostCallHelper.PostCall(new PostMethod(SelectPatient));
            /* 포커스가 자꾸 환자검색창으로와서 여러번 호출하기때문에 
             * PostCall로 메소드 연결 */
		}

        private void SelectPatient()
        {
            /* 입력 불가 모드로 전환 */
            this.xPanel7.Enabled = false;
            this.xPanel6.Enabled = false;
            this.tabBuwi.Enabled = false;
            this.pnlInfo.Enabled = false;
            this.pnlImage.Enabled = false;

            //등록번호 유효여부
            isPatient = true;

            //재원여부 체크
            ChkJaewon();

            //욕창환자정보로드
            this.GetNur6001();
        }

		private void xPatientBox1_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			isPatient = false;
            ClearAll();
		}

		//욕창환자정보로드
		private void GetNur6001()
		{
			if(!isPatient) return;
			
			//욕창환자정보로드
            if (grdNur6001.QueryLayout(false))
            {
                if (this.grdNur6001.RowCount == 0)
                {
                    /* 입력 불가 모드로 전환 */
                    this.tabBuwi.TabPages.Clear();
                    this.xPanel7.Enabled = false;
                    this.xPanel6.Enabled = false;
                    this.tabBuwi.Enabled = false;
                    this.pnlInfo.Enabled = false;
                    this.pnlImage.Enabled = false;
                }
                else
                {
                    /* 입력 가능 모드로 전환 */
                    this.xPanel7.Enabled = true;
                    this.xPanel6.Enabled = true;
                    this.tabBuwi.Enabled = true;
                    this.pnlInfo.Enabled = true;
                    this.pnlImage.Enabled = true;

                    //체크된 부위 이미지로 변환
                    SetBuwiChkImage();
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }
		}

		//체크된 부위 이미지로 변경
		private void SetBuwiChkImage()
		{
            #region 원본에도 주석처리 2010.05 KHJ
//			int k = 0;
//			string colName = string.Empty;
//			string icolName = string.Empty;
//			//row
//			for (int i=0; i<this.grdNur6001.RowCount; i++)
//			{
//				//column
//				//부위 데이타 컬럼
//				k = 0;
//				for (int j=1; j<7; j++)
//				{
//					k++;
//					colName = "chk"+k;
//					icolName = "bedsore_buwi"+k;
//
//					//해당부위가 있으면 이미지로 변환처리
//					if (this.grdNur6001.GetItemString(i,colName) == "Y")
//					{
//						
////						this.grdNur6001[i,icolName].Image = this.imageList1.Images[1] as Image;
////						this.grdNur6001[i,icolName].ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
//					}
//				}
//			}
//			this.grdNur6001.AcceptData();
            #endregion
		}

		//재원여부 체크, 간호도,팀,일상생활자립도,담당간호사 로드
		private void ChkJaewon()
		{
            //재원여부
            ArrayList array = IsJaewon();

            if (!TypeCheck.IsNull(array) && array.Count > 0)
            {
                if (array[0].ToString() == "Y")
                {
                    //각종컨트롤 enable
                    ControlEnable(true);
                }
                else
                {
                    GetMessage("search_patient");
                    ClearAll();
                    ControlEnable(false);
                }
            }
            else
            {
                GetMessage("search_patient");
                ClearAll();
                ControlEnable(false);
            }
		}

        // dsvIsJaewon Service
        private ArrayList IsJaewon()
        {
            /*-----------------------------------   2010.05. KHJ
             * 
             *  IsJaewon()[0]  -- jaewon_yn
             *  IsJaewon()[1]  -- pkinp1001
             *  IsJaewon()[2]  -- ipwon_date
             *  IsJaewon()[3]  -- first_sayu
             *  IsJaewon()[4]  -- last_sayu
             * 
             *---------------------------------*/
            ArrayList arrResult = new ArrayList();
            string fkinp1001;
            string cmdSql = @"SELECT A.PKINP1001, A.IPWON_DATE
                                FROM VW_OCS_INP1001_01 A
                               WHERE A.HOSP_CODE   = :f_hosp_code
                                 AND A.BUNHO       = :f_bunho
                                 AND A.JAEWON_FLAG = 'Y'
                                 AND NVL(A.CANCEL_YN, 'N') = 'N'";

            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_bunho", ptbPatient.BunHo);

            DataTable resTable = Service.ExecuteDataTable(cmdSql, bindVars);

            if (resTable.Rows.Count > 0)
            {
                fkinp1001 = resTable.Rows[0]["pkinp1001"].ToString();
                arrResult.Add("Y");
                arrResult.Add(resTable.Rows[0]["pkinp1001"].ToString());
                arrResult.Add(resTable.Rows[0]["ipwon_date"].ToString());


//                cmdSql = string.Empty;
//                bindVars.Clear();
//                resTable.Clear();

//                cmdSql = @"SELECT B.FIRST_SAYU
//                                , B.LAST_SAYU
//                             FROM NUR6001 A
//                                , NUR6002 B
//                            WHERE A.HOSP_CODE = :f_hosp_code
//                              AND B.HOSP_CODE = A.HOSP_CODE
//                              AND A.BUNHO     = :f_bunho
//                              AND A.FKINP1001 = :f_fkinp1001
//                              AND A.BUNHO     = B.BUNHO
//                              AND B.FROM_DATE BETWEEN A.FROM_DATE AND NVL(A.END_DATE,TO_DATE('99981231','YYYYMMDD'))
//                              AND B.ASSESSOR_DATE = (SELECT MAX(C.ASSESSOR_DATE)
//                                                       FROM NUR6002 C
//                                                      WHERE C.HOSP_CODE = B.HOSP_CODE
//                                                        AND C.BUNHO     = B.BUNHO
//                                                        AND C.ASSESSOR_DATE BETWEEN A.FROM_DATE AND NVL(A.END_DATE,TO_DATE('99981231','YYYYMMDD'))
//                                                        AND ((C.FIRST_SAYU IS NOT NULL)
//                                                         OR  (C.LAST_SAYU IS NOT NULL)))
//                              AND ROWNUM = 1";

//                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//                bindVars.Add("f_bunho",     ptbPatient.BunHo);
//                bindVars.Add("f_fkinp1001", fkinp1001);

//                resTable = Service.ExecuteDataTable(cmdSql, bindVars);

//                if (resTable.Rows.Count > 0)
//                {
//                    arrResult.Add(resTable.Rows[0]["first_sayu"].ToString());
//                    arrResult.Add(resTable.Rows[0]["last_sayu"].ToString());
//                }
//                else
//                {
//                    arrResult.Add("");
//                    arrResult.Add("");                  
//                }
            }
            else
            {
                arrResult.Add("");
                arrResult.Add("");
                arrResult.Add("");
                //arrResult.Add("");
                //arrResult.Add("");           
            }
                
            return arrResult;
        }

		private void ControlEnable(bool isbool)
		{
			this.btnInsert.Enabled    = isbool;
			this.btnDelete.Enabled    = isbool;
			this.btnSave.Enabled      = isbool;

		}
		#endregion

		#region 욕창환자등록정보 선택시 해당일자의 욕창환자 정보 조회
		private void grdNur6001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{	
			if(this.grdNur6001.GetRowState(this.grdNur6001.CurrentRowNumber) == DataRowState.Added)
			{
				/* 입력 가능 모드로 전환 */
                this.xPanel7.Enabled = true;
                this.xPanel6.Enabled = true;
                this.tabBuwi.Enabled = true;
                this.pnlInfo.Enabled = true;
                this.pnlImage.Enabled = true;
			}

			//매트리스 사용내역 조회
			GetNur6005();

			//해당 부위 탭 동적생성
			TabCreateBuwi();

            isPassQueryImage = true;
			//욕창달력처리
            GetCalendar();
            isPassQueryImage = false;
			
			//간호정보로드
			GetNurseInfo();

			//평가정보로드
			if (this.tabBuwi.TabPages.Count > 0)
			{
				this.GetNur6002();
			}
		}

		private void GetNur6005()
		{
			if (this.ptbPatient.BunHo != "")
			{	
				this.mbMetress.ResetData();

                string metress = string.Empty;
                string cmdSql = @"SELECT A.START_DATE || DECODE(A.END_DATE,NULL, '', '~' || A.END_DATE) || '->' || B.CODE_NAME METRESS
                                    FROM NUR6005 A, NUR0102 B
                                   WHERE A.HOSP_CODE     = :f_hosp_code
                                     AND A.BUNHO         = :f_bunho
                                     AND B.HOSP_CODE     = A.HOSP_CODE
                                     AND B.CODE          = A.METRESS_GUBUN
                                     AND B.CODE_TYPE     = 'METRESS_GUBUN'
                                   ORDER BY A.START_DATE DESC";

                BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVars.Add("f_bunho", ptbPatient.BunHo);
                DataTable retTable = Service.ExecuteDataTable(cmdSql, bindVars);

                if (retTable.Rows.Count > 0)
                {
                    for (int i = 0; i < retTable.Rows.Count; i++)
                    {
                        if (i < retTable.Rows.Count)
                        {
                            metress += retTable.Rows[i]["metress"].ToString() + "\n\r";
                        }
                        else
                        {
                            metress += retTable.Rows[i]["metress"].ToString();
                        }
                    }
                    mbMetress.SetDataValue(metress);
                }
                else
                {
                    //XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }
			}
		}

		private void GetNurseInfo()
		{
			//해당 욕창환자 종료일자, 현재일자 기준으로 로드
			//간호도
			//팀
			//일상생활자립도
			//담당간호사
			//초기화
			this.dpbLifeselfgrade.SetEditValue("");

            string damdang_nurse = " ";
            string ganhodo = "";
            string life_self_grade = "";

            object retVal = null;
				
            /* 일상생활자립도 */
            string cmdSql = @"SELECT A.LIFE_SELF_GRADE
                                FROM NUR1012 A
                               WHERE A.HOSP_CODE  = :f_hosp_code
                                 AND A.FKINP1001  = :f_fkinp1001
                                 AND A.JUKYONG_DATE = ( SELECT MAX(C.JUKYONG_DATE)
                                                          FROM NUR1012 C
                                                         WHERE C.HOSP_CODE = A.HOSP_CODE 
                                                           AND C.FKINP1001 = A.FKINP1001
                                                           AND C.JUKYONG_DATE <= TO_DATE(:f_jukyong_date, 'YYYY/MM/DD'))";

            //환자번호, 입원키, 적용일자 
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code",    EnvironInfo.HospCode);
            bindVars.Add("f_bunho",        ptbPatient.BunHo);
            bindVars.Add("f_fkinp1001",    grdNur6001.GetItemString(grdNur6001.CurrentRowNumber, "fkinp1001"));
            bindVars.Add("f_jukyong_date", grdNur6001.GetItemString(grdNur6001.CurrentRowNumber, "end_date"));

            retVal = Service.ExecuteScalar(cmdSql, bindVars);
            if (!TypeCheck.IsNull(retVal))
                life_self_grade = retVal.ToString();

            dpbLifeselfgrade.SetEditValue(life_self_grade);

            retVal = string.Empty;

            /* 담당간호사 */
            cmdSql = @"SELECT B.USER_NM
                         FROM ADM3200 B, NUR1010 A
                        WHERE A.HOSP_CODE     = :f_hosp_code 
                          AND A.FKINP1001     = :f_fkinp1001
                          AND B.HOSP_CODE     = A.HOSP_CODE
                          AND B.USER_ID       = A.DAMDANG_NURSE                          
                          AND A.JUKYONG_DATE  = ( SELECT MAX(C.JUKYONG_DATE)
                                                    FROM NUR1010 C
                                                   WHERE C.HOSP_CODE = A.HOSP_CODE
                                                     AND C.FKINP1001 = A.FKINP1001
                                                     AND C.JUKYONG_DATE <= TO_DATE(:f_jukyong_date, 'YYYY/MM/DD'))";

            retVal = Service.ExecuteScalar(cmdSql, bindVars);

            if (!TypeCheck.IsNull(retVal))
                damdang_nurse = retVal.ToString();                

            retVal = string.Empty;

            /* 간호도 */
            cmdSql = @"SELECT A.GANHODO
                         FROM NUR1011 A
                        WHERE A.HOSP_CODE    = :f_hosp_code 
                          AND A.FKINP1001    = :f_fkinp1001
                          AND A.JUKYONG_DATE = ( SELECT MAX(C.JUKYONG_DATE)
                                                   FROM NUR1011 C
                                                  WHERE C.HOSP_CODE = A.HOSP_CODE 
                                                    AND C.FKINP1001 = A.FKINP1001
                                                    AND C.JUKYONG_DATE <= TO_DATE(:f_jukyong_date, 'YYYY/MM/DD'))";

            retVal = Service.ExecuteScalar(cmdSql, bindVars);

            if (!TypeCheck.IsNull(retVal))
                ganhodo = retVal.ToString();     

            retVal = string.Empty;

            /* 체중 */
            cmdSql = "SELECT FN_NUR_LOAD_WEIGHT(:f_bunho, TO_DATE(:f_jukyong_date, 'YYYY/MM/DD')) FROM DUAL";
            retVal = Service.ExecuteScalar(cmdSql, bindVars).ToString();


            /* 입원일 */
            cmdSql = "SELECT IPWON_DATE FROM INP1001 WHERE HOSP_CODE = :f_hosp_code AND PKINP1001 = :f_fkinp1001";
            object aIpwonDate = Service.ExecuteScalar(cmdSql, bindVars);

            if (!TypeCheck.IsNull(aIpwonDate))
                this.dtpIpwon.SetDataValue(aIpwonDate.ToString());   
        }

		//욕창환자 평가 정보 달력처리

        private void GetCalendar()
        {
            GetCalendar("");
        }

		private void GetCalendar(string p_date)
		{
			//달력초기화
			this.calBedsore.ResetText();
			
			this.calBedsore.Dates.Clear();

			this.calBedsore.UnSelectAll();

			foreach(XCalendarDate dt in this.calBedsore.Dates)
			{					
				dt.ImageIndex = -1;
				dt.Tag = "";			
			}

			if (this.grdNur6001.RowCount <= 0) return;

			if(this.calBedsore.CurrentMonth.ToString() == "") return;

            layCalendar.SetBindVarValue("f_hosp_code",  EnvironInfo.HospCode);
            layCalendar.SetBindVarValue("f_bunho",      ptbPatient.BunHo);
            layCalendar.SetBindVarValue("f_from_date",  grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "from_date"));
            layCalendar.SetBindVarValue("f_from_month", calBedsore.CurrentMonth.ToString().Replace("/", ""));
            
            sDate = "";
			//욕창환자등록정보 로드
            if(layCalendar.QueryLayout(false))
            {
                foreach(DataRow dr in this.layCalendar.LayoutTable.Rows)
                {
                    //평가일자 생성
                    IHIS.Framework.XCalendarDate date = new XCalendarDate(DateTime.Parse(dr["assessor_date"].ToString()));
                    sDate = dr["assessor_date"].ToString();

                    //이미지추가
                    date.ImageIndex = 0;

                    string bedsore_buwi = string.Empty;

                    switch(dr["bedsore_buwi"].ToString())
                    {
                        case "1"://천골부
                            bedsore_buwi = "仙骨部"+"\n";
                            break;
                        case "2"://좌골부
                            bedsore_buwi = "坐骨部"+"\n";
                            break;
                        case "3"://미골부
                            bedsore_buwi = "尾骨部"+"\n";
                            break;
                        case "4"://장골부
                            bedsore_buwi = "腸骨部"+"\n";
                            break;
                        case "5"://대전자부
                            bedsore_buwi = "大転子部"+"\n";
                            break;
                        case "6"://종부
                            bedsore_buwi = "踵部"+"\n";
                            break;
                        default:
                            break;
                    }

                    //욕창부위정보
                    date.Tag = bedsore_buwi;
				
                    this.calBedsore.AddCalendarDate(date);
                }

				//입력된 욕창정보가 있는 날자중에서 가장 나중에 날짜를 선택모드로...
                //if (sDate.ToString() != "")
                //{
                //    this.calBedsore.SelectDate(DateTime.Parse(sDate));
                //}
                //else
                //{
                //    this.calBedsore.SelectDate(IHIS.Framework.EnvironInfo.GetSysDate());
                //}
                if (!TypeCheck.IsNull(p_date)) 
                {
                    this.calBedsore.SelectDate(Convert.ToDateTime(p_date));
                }
                else
                {
                    this.calBedsore.SelectDate(IHIS.Framework.EnvironInfo.GetSysDate());
                }

            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }
			this.calBedsore.Refresh();
		}

		//부위별 tabPage 동적생성
		private bool isTagpageCreating = false;
		private void TabCreateBuwi()
		{
			string bedsore_buwi1 = string.Empty;
		    string bedsore_buwi2 = string.Empty;
			string bedsore_buwi3 = string.Empty;
			string bedsore_buwi4 = string.Empty;
			string bedsore_buwi5 = string.Empty;
			string bedsore_buwi6 = string.Empty;
			
			isTagpageCreating = true; //Flag Set SelectionChanged에서 다음 Logic을 구동하지 않도록함
			//tabPage Clear			
			if (this.tabBuwi.Controls != null)
			{
				try
				{
                    if (this.tabBuwi.TabPages.Count > 0)
                    {
                        try
                        {
                            this.tabBuwi.TabPages.Clear();
                        }catch
                        {
                            this.tabBuwi.Refresh();
                        }
                    }
				}
				catch(Exception e)
				{
					//https://sofiamedix.atlassian.net/browse/MED-10610
					//XMessageBox.Show(e.StackTrace.ToString());
					return;
				}
			}
				
			//부위1
            string buwi = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber,"bedsore_buwi1");
            if (buwi != "" && buwi != "0")
			{				
				IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage();

				//tp.Location = new System.Drawing.Point(0, 25);
				tp.Name = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk1").ToString();//"仙骨部";
				//tp.Size = new System.Drawing.Size(703, 0);				
				tp.Text = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk1").ToString();//"仙骨部";
				tp.Title = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk1").ToString();//"仙骨部";
				tp.Tag = this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber, "bedsore_buwi1").ToString();//"1";
				tp.ImageList = this.imageList1;
				tp.ImageIndex = 1;
				
				this.tabBuwi.TabPages.Add(tp);
			}

			//부위2
            buwi = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "bedsore_buwi2");
            if (buwi != "" && buwi != "0")//if (this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber,"chk2") == "Y")
			{
				
				IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage();
				//TabPage tp = new TabPage();

				//tp.Location = new System.Drawing.Point(0, 25);
				tp.Name = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk2").ToString();//"坐骨部";
				//tp.Size = new System.Drawing.Size(703, 0);				
				tp.Text = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk2").ToString();//"坐骨部";
				tp.Title = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk2").ToString();//"坐骨部";
				tp.Tag = this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber, "bedsore_buwi2").ToString();//"2";
				tp.ImageList = this.imageList1;
				tp.ImageIndex = 2;

				this.tabBuwi.TabPages.Add(tp);
				
			}

            //부위3
            buwi = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "bedsore_buwi3");
            if (buwi != "" && buwi != "0")//if (this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber,"chk2") == "Y")
			{
				
				IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage();
				//TabPage tp = new TabPage();

				//tp.Location = new System.Drawing.Point(0, 25);
				tp.Name = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk3").ToString();//"坐骨部";
				//tp.Size = new System.Drawing.Size(703, 0);				
				tp.Text = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk3").ToString();//"坐骨部";
				tp.Title = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk3").ToString();//"坐骨部";
				tp.Tag = this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber, "bedsore_buwi3").ToString();//"2";
				tp.ImageList = this.imageList1;
				tp.ImageIndex = 2;

				this.tabBuwi.TabPages.Add(tp);
				
			}

            //부위4
            buwi = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "bedsore_buwi4");
            if (buwi != "" && buwi != "0")//if (this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber,"chk2") == "Y")
			{
				
				IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage();
				//TabPage tp = new TabPage();

				//tp.Location = new System.Drawing.Point(0, 25);
				tp.Name = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk4").ToString();//"坐骨部";
				//tp.Size = new System.Drawing.Size(703, 0);				
				tp.Text = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk4").ToString();//"坐骨部";
				tp.Title = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk4").ToString();//"坐骨部";
				tp.Tag = this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber, "bedsore_buwi4").ToString();//"2";
				tp.ImageList = this.imageList1;
				tp.ImageIndex = 2;

				this.tabBuwi.TabPages.Add(tp);
				
			}

            //부위5
            buwi = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "bedsore_buwi5");
            if (buwi != "" && buwi != "0")//if (this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber,"chk2") == "Y")
			{
				
				IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage();
				//TabPage tp = new TabPage();

				//tp.Location = new System.Drawing.Point(0, 25);
				tp.Name = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk5").ToString();//"坐骨部";
				//tp.Size = new System.Drawing.Size(703, 0);				
				tp.Text = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk5").ToString();//"坐骨部";
				tp.Title = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk5").ToString();//"坐骨部";
				tp.Tag = this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber, "bedsore_buwi5").ToString();//"2";
				tp.ImageList = this.imageList1;
				tp.ImageIndex = 2;

				this.tabBuwi.TabPages.Add(tp);
				
			}

            //부위6
            buwi = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "bedsore_buwi6");
            if (buwi != "" && buwi != "0")//if (this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber,"chk2") == "Y")
			{
				
				IHIS.X.Magic.Controls.TabPage tp = new IHIS.X.Magic.Controls.TabPage();
				//TabPage tp = new TabPage();

				//tp.Location = new System.Drawing.Point(0, 25);
				tp.Name = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk6").ToString();//"坐骨部";
				//tp.Size = new System.Drawing.Size(703, 0);				
				tp.Text = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk6").ToString();//"坐骨部";
				tp.Title = this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "chk6").ToString();//"坐骨部";
				tp.Tag = this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber, "bedsore_buwi6").ToString();//"2";
				tp.ImageList = this.imageList1;
				tp.ImageIndex = 2;

				this.tabBuwi.TabPages.Add(tp);				
			}

			isTagpageCreating = false; //Flag Clear

			//첫번째 Tab으로 Select
			if (this.tabBuwi.TabCount > 0)
				this.tabBuwi.SelectedIndex = 0;
		}

		#endregion

		#region 평가일자 선택시 
		private void calBedsore_DaySelected(object sender, IHIS.Framework.XCalendarDaySelectedEventArgs e)
		{
			if(this.grdNur6001.RowCount > 0)
			{
				if(this.grdNur6001.CurrentRowNumber >= 0)
				{
					if(int.Parse(this.calBedsore.SelectedDays[0].Date.ToString("yyyyMMdd")) < 
						int.Parse(DateTime.Parse(this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber, "from_date").ToString()).ToString("yyyyMMdd")))
					{
					}
				}
			}

		    this.GetNur6002();

			//재원여부 체크
			//ChkJaewon();  //주석2011.12.1 woo
		}
		
		private void GetNur6002()
		{
			if(this.grdNur6001.RowCount <= 0) return;

            if (this.isPassQueryImage) return;

			//평가일자가 선택이 안되어 있으면 리턴
			if(this.calBedsore.SelectedDays.Count <= 0) return;

			//초기화
            //this.grdNur6002.Reset();
			this.grdImage.Reset();

            grdNur6002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdNur6002.SetBindVarValue("f_bunho",     ptbPatient.BunHo);
            grdNur6002.SetBindVarValue("f_from_date", grdNur6001.GetItemString(grdNur6001.CurrentRowNumber, "from_date"));
            //grdNur6002.SetBindVarValue("f_bedsore_buwi", "%");
            grdNur6002.SetBindVarValue("f_bedsore_buwi", this.tabBuwi.SelectedTab.Tag.ToString());
            grdNur6002.SetBindVarValue("f_assessor_date", calBedsore.SelectedDays[0].Date.ToString("yyyy/MM/dd"));
			
            //평가정보 로드처리
            if (grdNur6002.QueryLayout(false))
            {
                GetBuwiFilter();
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
		}

		private void GetBuwiFilter()
		{	
			string bedsore_buwi = this.tabBuwi.SelectedTab.Tag.ToString();
			//평가정보가 없으면 새로운 행 입력처리
			if (this.grdNur6002.RowCount <=0 )
			{
				InsrowNur6002(bedsore_buwi);
			}
			else
			{
				bool isBuwi = false;
				for (int i=0; i<this.grdNur6002.RowCount; i++)
				{
					if (bedsore_buwi == this.grdNur6002.GetItemString(i,"bedsore_buwi"))
					{
						this.grdNur6002.SetFocusToItem(i,"bedsore_buwi");
						isBuwi = true;
						break;
					}
				}
				if(!isBuwi)
				{
					InsrowNur6002(bedsore_buwi);
				}
			}
		}
		
		private void InsrowNur6002(string bedsore_buwi)
        {
            int rowNum = this.grdNur6002.InsertRow(-1);

            grdNur6002Copy.Reset();

            if (!this.grdNur6002Copy.QueryLayout(false))
            {
                XMessageBox.Show("先日情報の取り込みに失敗しました。", "情報取り込み失敗", MessageBoxIcon.Information);
                return;
            }

            if (this.grdNur6002Copy.RowCount > 0)
            {
                foreach (DataRow row in grdNur6002Copy.LayoutTable.Rows)
                {

                    foreach (DataColumn dc in row.Table.Columns)
                    {
                        if (row[dc.ColumnName].ToString() != "")
                        {
                            this.grdNur6002.SetItemValue(rowNum, dc.ColumnName, row[dc.ColumnName].ToString());
                        }
                    }
                }

                this.grdNur6002.AcceptData();
            }

            this.grdNur6002.SetItemValue(rowNum, "bunho", this.ptbPatient.BunHo);
            this.grdNur6002.SetItemValue(rowNum, "from_date", this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "from_date"));
            this.grdNur6002.SetItemValue(rowNum, "bedsore_buwi", bedsore_buwi);
            this.grdNur6002.SetItemValue(rowNum, "assessor_date", this.calBedsore.SelectedDays[0].Date.ToString("yyyy/MM/dd"));
            this.grdNur6002.SetItemValue(rowNum, "assessor", IHIS.Framework.UserInfo.UserID);
            this.grdNur6002.SetItemValue(rowNum, "assessor_name", IHIS.Framework.UserInfo.UserName);

            //Default정보 입력
            this.fbAssessor.SetEditValue(IHIS.Framework.UserInfo.UserID);
            this.fbAssessor.AcceptData();
            this.txtAssessor.SetEditValue(IHIS.Framework.UserInfo.UserName);
            this.txtAssessor.AcceptData();
            this.dtpAssessor_date.SetEditValue(this.calBedsore.SelectedDays[0].Date);
            this.dtpAssessor_date.AcceptData();
			
            //int row = this.grdNur6002.InsertRow(-1);
            //this.grdNur6002.SetItemValue(row,"bunho",this.ptbPatient.BunHo);
            //this.grdNur6002.SetItemValue(row,"from_date",this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber,"from_date"));
            //this.grdNur6002.SetItemValue(row,"bedsore_buwi",bedsore_buwi);
            //this.grdNur6002.SetItemValue(row,"assessor_date",this.calBedsore.SelectedDays[0].Date.ToString("yyyy/MM/dd"));
            //this.grdNur6002.SetItemValue(row,"assessor",IHIS.Framework.UserInfo.UserID);
            //this.grdNur6002.SetItemValue(row,"assessor_name",IHIS.Framework.UserInfo.UserName);

            //this.grdNur6002.AcceptData();

			//검사치 최근의 결과로 가져올 것
			//GetGumsaResult();
		}

		private void GetGumsaResult()
		{
            string cmdSql = @"
            SELECT FN_CPL_HANGMOG_RESULT_4(:f_bunho, FN_NUR_LOAD_CODE_NAME('NUR6001_GUMSA','HB'),  TRUNC(TO_DATE(:f_date, 'YYYY/MM/DD'))) HB_RESULT
                 , FN_CPL_HANGMOG_RESULT_4(:f_bunho, FN_NUR_LOAD_CODE_NAME('NUR6001_GUMSA','ALB'), TRUNC(TO_DATE(:f_date, 'YYYY/MM/DD'))) ALB_RESULT
                 , FN_CPL_HANGMOG_RESULT_4(:f_bunho, FN_NUR_LOAD_CODE_NAME('NUR6001_GUMSA','TP'),  TRUNC(TO_DATE(:f_date, 'YYYY/MM/DD'))) TP_RESULT
              FROM DUAL";
            BindVarCollection bindCol = new BindVarCollection();
            bindCol.Add("f_bunho", ptbPatient.BunHo);
            bindCol.Add("f_date",  dtpAssessor_date.GetDataValue());
            DataTable resTable = Service.ExecuteDataTable(cmdSql, bindCol);

            if (resTable.Rows.Count > 0)
            {
                grdNur6002.SetItemValue(grdNur6002.CurrentRowNumber, "yokchang_hb", resTable.Rows[0]["hb_result"].ToString());
                grdNur6002.SetItemValue(grdNur6002.CurrentRowNumber, "yokchang_alb", resTable.Rows[0]["alb_result"].ToString());
                grdNur6002.SetItemValue(grdNur6002.CurrentRowNumber, "yokchang_tp", resTable.Rows[0]["tp_result"].ToString());
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
		}
		#endregion

		#region 욕창환자등록 부위선택시 체크이미지 처리
		private void grdNur6001_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            /* 원본에도 주석 2010.05. KHJ
            if (this.grdNur6001.RowCount <= 0) return;

            if (this.grdNur6001.CurrentRowNumber < 0) return;

            XCell ac = this.grdNur6001.CellAtPoint(new Point(e.X, e.Y));

            if (ac == null) return;

            if (ac.CellName.Length < 12) return;
            if (ac.CellName.Substring(0, 12) != "bedsore_buwi") return;

            string colName = "chk" + ac.CellName.Substring(12);
            if (this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, colName).ToString() == "Y")
            {
                this.grdNur6001.SetItemValue(this.grdNur6001.CurrentRowNumber, colName, "N");
                //this.grdNur6001.FocusCell.Image = null;
            }
            else
            {
                this.grdNur6001.SetItemValue(this.grdNur6001.CurrentRowNumber, colName, "Y");
                //this.grdNur6001.FocusCell.Image = this.imageList1.Images[1] as Image;
                //this.grdNur6001.FocusCell.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            }
            this.grdNur6001.AcceptData();
             //*/
		}
		#endregion

		#region 버튼클릭
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{

			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					
					//욕창달력처리
					GetCalendar();

					//평가내역조회
					this.GetNur6002();
					break;
				case FunctionType.Insert:

					break;
				case FunctionType.Update:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
                    }
                    e.IsBaseCall = false;

					if(this.grdNur6001.RowCount == 0) return;

					if(this.grdNur6001.GetRowState(this.grdNur6001.CurrentRowNumber) == DataRowState.Added)
						return;


					//기본값체크
					if (!ChkValidation()) return;

					DialogResult result;
					mbxMsg = NetInfo.Language == LangMode.Jr ? "褥瘡患者評価情報を 保存しますか。" : "욕창환자평가 정보를 저장하시겠습니까?.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "保存" : "저장";
					result = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						SetSave();
					}
					break;
				case FunctionType.Reset:
					e.IsBaseCall = false;
					//this.PostLoad();
                    this.ptbPatient.Reset();
                    ClearAll();
					break;

				default:
					break;
			}
		}

		private void SetSave()
		{			
			this.grdNur6002.AcceptData();
            try
            {
                Service.BeginTransaction();

                //부위별 평가내역저장
                if (grdNur6002.SaveLayout())
                {
                    if (grdImage.SaveLayout())
                    {
                        isPassQueryImage = true;
                        
                        //욕창달력처리
                        string selectedDate = "";
                        if (this.calBedsore.SelectedDays.Count > 0)
                            selectedDate = this.calBedsore.SelectedDays[0].Date.ToString("yyyy/MM/dd");

                        GetCalendar(selectedDate);

                        isPassQueryImage = false;

                        //재조회
                        GetNur6002();
                        //this.GetMessage("nur6002_save_true");
                    }
                    else
                    {
                        throw new Exception();
                        //XMessageBox.Show(Service.ErrFullMsg);
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch 
            {
                Service.RollbackTransaction();
                this.GetMessage("nur6002_save_false");
                //XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
		}

        private bool ChkValidation()
        {
            //평가일자 시작일자 비교처리
            if (DateTime.Compare(DateTime.Parse(this.dtpAssessor_date.GetDataValue().ToString()),
                DateTime.Parse(this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber, "from_date").ToString())) >= 0)
            {
                return true;
            }
            return false;
        }
		#endregion

        #region Clear 2011.12.01 추가
        private void ClearAll()
        {
            /* 클리어 시 모든 창을 리셋시켜주는 메소드 추가 2011.12.01 woo*/
            this.grdImage.Reset();  //이미지 박스 리셋
            this.grdNur6001.Reset();//환자 욕창정보 리셋
            this.grdNur6002.Reset();//욕창 상세정보 리셋
            this.mbMetress.ResetData();
            this.mbMetress.Refresh();
            try
            {
                this.tabBuwi.TabPages.Clear();  //부위별 탭 클리어
            }
            catch
            {
                this.tabBuwi.Refresh();
            }
            GetCalendar();            //달력 기본 셋팅
            ControlEnable(false);   //각종 컨트롤 잠금.
        }
        #endregion

        #region 환자간호정보. 간호도,일상생활자립도,담당간호사,체중 등록
        //private void btnGanhodo_Click(object sender, System.EventArgs e)
        //{
        //    CommonItemCollection cic = new CommonItemCollection();
        //    cic.Add("bunho", this.ptbPatient.BunHo);

        //    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1011U00", ScreenOpenStyle.ResponseFixed, cic);

        //    //재조회
        //    this.GetNurseInfo();
        //}

		private void btnLife_Click(object sender, System.EventArgs e)
		{
            //CommonItemCollection cic = new CommonItemCollection();
            //cic.Add("bunho", this.ptbPatient.BunHo);

            //IHIS.Framework.XScreen.OpenScreenWithParam(this,"NURI","NUR1012U00", ScreenOpenStyle.ResponseFixed,cic);
            ////재조회
            //this.GetNurseInfo();
		}

        //private void btnNurse_Click(object sender, System.EventArgs e)
        //{
        //    CommonItemCollection cic = new CommonItemCollection();
        //    cic.Add("bunho", this.ptbPatient.BunHo);

        //    IHIS.Framework.XScreen.OpenScreenWithParam(this,"NURI","NUR1010U00", ScreenOpenStyle.ResponseFixed,cic);
        //    //재조회
        //    this.GetNurseInfo();
        //}
		private void btnWeight_Click(object sender, System.EventArgs e)
		{
            //CommonItemCollection cic  = new CommonItemCollection();
            //cic.Add( "sysid", "NURI");
            //cic.Add( "screen", this.ScreenID.ToString());
            //cic.Add( "bunho", this.ptbPatient.BunHo.ToString());
            //cic.Add( "flag", "Y");
	
            //IHIS.Framework.XScreen.OpenScreenWithParam(this,"NURI", "NUR7001U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, cic);

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("sysid", "NURI");
            openParams.Add("screen", this.ScreenID.ToString());
            //openParams.Add( "ho_dong", this.paBox.ToString());
            openParams.Add("bunho", this.ptbPatient.BunHo.ToString());
            openParams.Add("date", this.dtpAssessor_date.GetDataValue());

            XScreen.OpenScreenWithParam(this, "NURI", "NUR1020U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopRight, openParams);


			//재조회
			//this.GetNur6002();
		}
		#endregion

		#region 욕창부위 tab 선택시
		private void tabBuwi_SelectionChanged(object sender, System.EventArgs e)
		{
			if (this.tabBuwi.TabCount < 1) return;
			//TabCreateBuwi()에서 TagPage생성중에는 Call하지 않음
			if (this.isTagpageCreating) return;

			foreach(IHIS.X.Magic.Controls.TabPage tp in this.tabBuwi.TabPages)
			{
				tp.ImageIndex = 2;
			}

			this.tabBuwi.SelectedTab.ImageIndex = 1;

			this.GetNur6002();
		}
		#endregion

		#region 달력월 선택시 해당환자 욕창평가일자 달력표시처리
		private void calBedsore_MonthChanged(object sender, IHIS.Framework.XCalendarMonthChangedEventArgs e)
		{
			if(!this.isPatient) return;

			//욕창달력처리
			GetCalendar();

			//평가내역조회
			this.GetNur6002();
		}
		#endregion

		#region 욕창이미지 관리의 버튼을 클릭을 했을 때
		//추가버튼
		private void btnImageAdd_Click(object sender, System.EventArgs e)
		{
			this.grdImage.InsertRow(-1);
		}

		//삭제버튼
		private void btnImageDelete_Click(object sender, System.EventArgs e)
		{
			if (this.grdImage.CurrentRowNumber >= 0)
				this.grdImage.DeleteRow(this.grdImage.CurrentRowNumber);
		}

		#endregion

		#region 이미지 그리드의 이미지로드 버튼을 클릭을 했을 때
		private void grdImage_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
		{
			if (e.ColName == "button")  //Image Load
			{
				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = "Image Files(*.JPG)|*.JPG";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
                    Image image = null;
					try
					{
						image = Image.FromFile(dlg.FileName);                        
						this.grdImage.SetItemValue(e.RowNumber, "image", image);          
						this.grdImage.SetItemValue(e.RowNumber, "base_image_path", dlg.FileName);
                        image.Dispose();

                        /* 원본 주석 2010.05. KHJ
						//Image를 byte[]로 변환하여 SetItemValue함
//						using (MemoryStream ms = new MemoryStream())
//						{
//							image.Save(ms, image.RawFormat);b
//							this.grdImage.SetItemValue(e.RowNumber, "image", ms.ToArray());
//						}//*/
					}
					catch(Exception xe)
					{
                        image.Dispose();
						Debug.WriteLine(xe.Message);
						Debug.WriteLine(xe.StackTrace);
					}
				}
			}
		}
		#endregion

		#region 이미지 저장전 키값셋팅(입력일 경우에만)
        private void grdImage_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            //저장시 I.Insert이면 번호,시작일자,부위구분,평가일자
            if (e.RowState == DataRowState.Added)
            {
                this.grdImage.SetItemValue(e.RowNumber, "bunho", this.ptbPatient.BunHo);
                string data = this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber, "from_date").ToString();
                this.grdImage.SetItemValue(e.RowNumber, "from_date", DateTime.Parse(data).ToString("yyyyMMdd"));
                this.grdImage.SetItemValue(e.RowNumber, "bedsore_buwi", this.tabBuwi.SelectedTab.Tag.ToString());  //현재 선택된 Tabpage의 Tag에 저장된 Code값
                this.grdImage.SetItemValue(e.RowNumber, "assessor_date", DateTime.Parse(this.dtpAssessor_date.GetDataValue()).ToString("yyyyMMdd"));
            }
        }
		#endregion

		#region 이미지 저장후 이벤트
        private void grdImage_SaveEnd(object sender, SaveEndEventArgs e)
        {
            /* 저장 후 재조회 해주므로 따로 셋팅할 필요없을 듯? 
             * 뭔가 다른 이유가 있는 건지??    2010/06/07 김보현 
             * 
            //입력일 경우에 서버에서 입력순번을 가져와 셋팅을 한다.
            if (e.IsSuccess == true)
            {
                int seq = 0;
                string cmdText = @"SELECT NVL(MAX(SEQ), 0)
                                     FROM NUR6004
                                    WHERE BUNHO         = :f_bunho
                                      AND FROM_DATE     = TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                      AND BEDSORE_BUWI  = :f_bedsore_buwi
                                      AND ASSESSOR_DATE = TO_DATE(:f_assessor_date, 'YYYY/MM/DD')";

                BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_bunho", grdImage.GetItemString(grdImage.CurrentRowNumber, "bunho"));
                bindVars.Add("f_from_date", grdImage.GetItemString(grdImage.CurrentRowNumber, "from_date"));
                bindVars.Add("f_bedsore_buwi", grdImage.GetItemString(grdImage.CurrentRowNumber, "bedsore_buwi"));
                bindVars.Add("f_assessor_date", grdImage.GetItemString(grdImage.CurrentRowNumber, "assessor_date"));
                seq = Convert.ToInt32(Service.ExecuteScalar(cmdText, bindVars));

                if (seq > 0)
                {
                    for (int i = 0; i < this.grdImage.RowCount; i++)
                    {
                        if (this.grdImage.GetItemValue(i, "seq").ToString() == "")
                        {
                            this.grdImage.SetItemValue(i, "seq", seq);
                            seq++;
                        }
                    }
                }
            }
            //else
            //{
            //    this.GetMessage("Image_save_false");
            //    return;
            //}
            */
        }
		#endregion

		#region 평가자 이름 조회
		private void fbAssessor_Enter(object sender, System.EventArgs e)
		{
			FindName = "assessor";
			this.MakeValService(this.fbAssessor);
		}
		#endregion

		/// <summary>
		///	파인드 박스 통합 Validation 체크 
		/// </summary>
		/// <param name="fbx">
		/// 파인드박스 명
		/// </param>
		/// <returns></returns>
		#region Total Validation Check
		private void MakeValService(XFindBox fb)
		{
            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            object retVal = null;

			switch(fb.Name)
			{
				case "fbAssessor":
                    cmdText = "SELECT FN_ADM_LOAD_USER_NM(:f_code, TRUNC(SYSDATE)) FROM DUAL";
                    bindVars.Add("f_code", fbAssessor.GetDataValue());  // 평가자 사번을 입력을 했을 때 이름 조회
                    retVal = Service.ExecuteScalar(cmdText, bindVars);
                    if (!TypeCheck.IsNull(retVal) && !retVal.ToString().Equals(""))
                    {
                        txtAssessor.Clear();
                        txtAssessor.SetEditValue(retVal.ToString());
                        txtAssessor.AcceptData();
                        FindName = "";
                        gbxYokchang_deep.Focus();
                    }
					break;
				default:
					break;
			}
		}
		#endregion

		#region 사용자변경이 있을 때
		private void NUR6001U00_UserChanged(object sender, System.EventArgs e)
		{
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "insert_chk":
					msg = NetInfo.Language == LangMode.Ko ? "개시일 정보 저장을 먼저 해야 합니다."
						: "先に開始日情報を保存してください。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "Image_save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "保存";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nur6002_save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "保存";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nur6001_save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "保存";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "Image_save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。ご確認ください。";
                    //msg += "\r\n[" + this.dsvSetImageList.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "에러"
                        : "保存失敗";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				case "buwi_insert":
					msg = NetInfo.Language == LangMode.Ko ? "부위를 입력해 주세요." 
						: "部位を入力してください。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nur6002_save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。ご確認ください。";
                    //msg += "\r\n[" + this.dsvSetNur6002.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "에러" 
						: "保存失敗";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				case "nur6001_save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。ご確認ください。";
                    //msg += "\r\n[" + this.dsvSetNur6001.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "에러" 
						: "保存失敗";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
                case "search_patient":  //2011.12.05 추가 woo
                    msg = NetInfo.Language == LangMode.Ko ? "입원환자가 아닙니다. 확인바랍니다."
                        : "入院患者ではありません。ご確認ください。";
                    //msg += "\r\n[" + this.dsvSetNur6001.ErrFullMsg + "]";
                    caption = NetInfo.Language == LangMode.Ko ? "에러"
                        : "患者検索";
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
                    break;
				default:
					break;
			}
		}
		#endregion

		#region 욕창부위정보를 저장을 한 후의 이벤트
        private void grdNur6002_SaveEnd(object sender, SaveEndEventArgs e)
        {
            //입력일 경우에 서버에서 입력순번을 가져와 셋팅을 한다.
            //if (e.IsSuccess == true)
            //{
            //    this.GetMessage("nur6002_save_true");

            //}
            //else
            //{
            //    this.GetMessage("nur6002_save_false");
            //    return;
            //}
        }
		#endregion

		#region 욕창개시정보를 저장을 한 후의 이벤트
        private void grdNur6001_SaveEnd(object sender, SaveEndEventArgs e)
        {
            //입력일 경우에 서버에서 입력순번을 가져와 셋팅을 한다.
            if (e.IsSuccess == true)
            {
                this.GetMessage("nur6001_save_true");

            }
            else
            {
                this.GetMessage("nur6001_save_false");
                return;
            }
        }
		#endregion
	
		#region PopupMenu Handling
		private void OnPopMenuClick(object sender, EventArgs e)
		{
			//Tag에 저장된 JobItem Get
			JobItem item = (JobItem) ((IHIS.X.Magic.Menus.MenuCommand) sender).Tag;

            string cmdText = @"DELETE NUR6002
                                WHERE HOSP_CODE      = :f_hosp_code
                                  AND BUNHO          = :f_bunho
                                  AND FROM_DATE      = TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                  AND BEDSORE_BUWI   = :f_bedsore_buwi
                                  AND ASSESSOR_DATE  = TO_DATE(:f_assessor_date, 'YYYY/MM/DD')";
            BindVarCollection bindVars = new BindVarCollection();

			DialogResult result;
			mbxMsg = NetInfo.Language == LangMode.Jr ? item.CodeName+" 褥瘡患者評価情報を削除保存しますか。" : "욕창환자평가 정보를 삭제하시겠습니까?.";
			mbxCap = NetInfo.Language == LangMode.Jr ? "削除" : "삭제";
			result = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
            {
                bindVars.Add("f_hosp_code",     EnvironInfo.HospCode);
                bindVars.Add("f_bunho",         ptbPatient.BunHo);
                bindVars.Add("f_from_date",     grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "from_date"));
                bindVars.Add("f_bedsore_buwi",  item.Code.ToString());
                bindVars.Add("f_assessor_date", calBedsore.SelectedDays[0].Date.ToString("yyyy/MM/dd"));

                try
                {
                    Service.BeginTransaction();

                    if (Service.ExecuteNonQuery(cmdText, bindVars))
                    {
                        cmdText = string.Empty;
                        cmdText = @"DELETE NUR6004
                                     WHERE HOSP_CODE      = :f_hosp_code
                                       AND BUNHO          = :f_bunho
                                       AND FROM_DATE      = TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                       AND BEDSORE_BUWI   = :f_bedsore_buwi
                                       AND ASSESSOR_DATE  = TO_DATE(:f_assessor_date, 'YYYY/MM/DD')";
                        if (!Service.ExecuteNonQuery(cmdText, bindVars))
                        {
                            XMessageBox.Show(Service.ErrFullMsg);
                            return;
                        }
                    }
                    Service.CommitTransaction();

                    isPassQueryImage = true;
                    //욕창달력처리
                    string selectedDate = "";
                    if (this.calBedsore.SelectedDays.Count > 0)
                        selectedDate = this.calBedsore.SelectedDays[0].Date.ToString("yyyy/MM/dd");

                    GetCalendar(selectedDate);
                    isPassQueryImage = false;

                    //재조회
                    GetNur6002();
                }
                catch (Exception ex)
                {
                    Service.RollbackTransaction();
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);                    
                }
			}
			
		}
		#endregion

		#region 달력 평가일자 삭제처리 팝업메뉴
		private void calBedsore_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//Left인 상태에서 Move시
			if ((e.Button == MouseButtons.Right) )
			{
				string menuName = string.Empty;

				jobCodeList.Clear();
				foreach(IHIS.X.Magic.Controls.TabPage tp in this.tabBuwi.TabPages)
				{
					menuName = tp.Title+"評価内容削除";
					jobCodeList.Add(new JobItem(int.Parse(tp.Tag.ToString()), menuName));
				}
				
				DelNur6002(e);
			}
		}
		private void tabBuwi_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            /* 원문주석 2010.05 KHJ
//			//Left인 상태에서 Move시
//			if ((e.Button == MouseButtons.Right) )
//			{
//				mPopupClick = "";
//
//				DelNur6002(e);
//			}
             */
		}
		private void DelNur6002(System.Windows.Forms.MouseEventArgs e)
		{
			if (this.calBedsore.SelectedDays.Count <= 0) return;

			//등록된 욕창정보가 없으면. 리턴
			if (TypeCheck.IsNull(this.calBedsore.GetCalendarDate(this.calBedsore.SelectedDays[0].Date)))
				return;

			if (this.grdNur6002.RowCount > 0 )
			{
				//메뉴초기화
				popMenu.MenuCommands.Clear();

				//PopupMenu 메뉴 구성  //Tag에 Code 저장
				IHIS.X.Magic.Menus.MenuCommand menuCmd = null;
						
				foreach (JobItem item in jobCodeList)
				{	
					//PopupMenu 구성, Tag에 JobItem 보관
					menuCmd = new IHIS.X.Magic.Menus.MenuCommand(item.CodeName, (Image)this.jobImageList.Images[0], new EventHandler(OnPopMenuClick));
					menuCmd.Tag = item;
					
					popMenu.MenuCommands.Add(menuCmd);

					//평가일자가 완료되면 삭제할 수 없음
					if (this.grdNur6002.GetItemString(this.grdNur6002.CurrentRowNumber,"end_yn") == "Y")
					{
						menuCmd.Enabled = false;
					}
				}
				popMenu.TrackPopup(this.calBedsore.PointToScreen(new Point(e.X, e.Y)));
			}
		}
		#endregion

		#region 욕창환자이미지 조회
		private void grdNur6002_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			//욕창환자이미지 조회
            if(!grdImage.QueryLayout(false))
            {
                //XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
		}
		#endregion

		#region 매트리스등록
		private void btnMatress_Click(object sender, System.EventArgs e)
		{
			if(this.ptbPatient.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				if (this.grdNur6001.RowCount > 0)
				{
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "bunho", this.ptbPatient.BunHo.ToString());
					openParams.Add( "fkinp1001", this.grdNur6001.GetItemValue(this.grdNur6001.CurrentRowNumber,"fkinp1001").ToString());
					XScreen.OpenScreenWithParam(this, "NURI", "NUR6005U00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);

					this.GetNur6005();
				}
			}
		}
		#endregion

		#region 총수 자동 계산
		private void SetTotalCount()
		{
			int total_count = int.Parse(TypeCheck.NVL(this.gbxYokchang_deep.GetDataValue().ToString(), "0").ToString()) + 
			int.Parse(TypeCheck.NVL(this.gbxSamchul_yang.GetDataValue().ToString(), "0").ToString()) + 
			int.Parse(TypeCheck.NVL(this.gbxYokchang_size.GetDataValue().ToString(), "0").ToString()) + 
            int.Parse(TypeCheck.NVL(this.gbxYokchang_gamyum.GetDataValue().ToString(), "0").ToString()) + 
			int.Parse(TypeCheck.NVL(this.gbxYukajojik.GetDataValue().ToString(), "0").ToString()) + 
			int.Parse(TypeCheck.NVL(this.gbxGaesajojik.GetDataValue().ToString(), "0").ToString()) + 
			int.Parse(TypeCheck.NVL(this.gbxPocket_gubun.GetDataValue().ToString(), "0").ToString()) + 
			int.Parse(TypeCheck.NVL(this.gbxYokchang_stage.GetDataValue().ToString(), "0").ToString());

			this.emkTotal_count.SetEditValue(total_count.ToString());
			this.emkTotal_count.AcceptData();
		}
		#endregion

		#region 총수 자동계산정보 보여주기
		private void All_Check_Changed(object sender, System.EventArgs e)
		{
			SetTotalCount();
		}
		#endregion

		#region 날짜 변경을 했을 때
		private void dtpAssessor_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			//검사치 최근의 결과로 가져올 것
			GetGumsaResult();
		}
		#endregion

        #region 그리드 쿼리 이벤트
        private void grdNur6001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNur6001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNur6001.SetBindVarValue("f_bunho", this.ptbPatient.BunHo);
        }

        private void grdImage_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdImage.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdImage.SetBindVarValue("f_bunho", this.ptbPatient.BunHo);
            this.grdImage.SetBindVarValue("f_from_date", this.grdNur6001.GetItemString(this.grdNur6001.CurrentRowNumber, "from_date"));
            this.grdImage.SetBindVarValue("f_buwi_gubun", this.grdNur6002.GetItemString(this.grdNur6002.CurrentRowNumber, "bedsore_buwi"));
            this.grdImage.SetBindVarValue("f_assessor_date", this.dtpAssessor_date.GetDataValue());
        }

        private void grdImage_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdImage.RowCount < 1)
                return;

            string strKey = "";
            if (!Directory.Exists(strClientPath))
                Directory.CreateDirectory(strClientPath);

            IHIS.Framework.XFTPWorker ftp = null;
            Image image = null;
            bool isMakeDir = true;


            try
            {
                char[] spliter = { '/' };
                string[] array1 = strServerPath.Split(spliter); // /NURI/
                ArrayList array2 = new ArrayList();
                IHIS.Framework.XFTPWorker.DirItems dirItem = new XFTPWorker.DirItems();

                ftp = new XFTPWorker(strFtpUser, strFtpPass, strServer);

                if (ftp.Connected)
                {
                    isMakeDir = true;
                    array2 = ftp.GetDirList(false);
                    /////////////////////////////////////////
                    for (int i = 0; i < array1.Length; i++)
                    {
                        if (array1[i] == "")
                            continue;

                        isMakeDir = true;
                        array2 = ftp.GetDirList(false);
                        for (int j = 0; j < array2.Count; j++)
                        {
                            dirItem = (IHIS.Framework.XFTPWorker.DirItems)array2[j];
                            if (dirItem.IsFile)
                                continue;
                            if (array1[i] == "#PatienID")
                            {
                                if (dirItem.Filename == ptbPatient.BunHo)
                                    isMakeDir = false;
                            }
                            else
                            {
                                if (dirItem.Filename == array1[i]) //3
                                    isMakeDir = false;
                            }
                        }

                        if (array1[i] == "#PatienID")
                        {
                            if (isMakeDir)
                                if (!ftp.MakeDir(ptbPatient.BunHo))
                                    throw new Exception("MakeDir Error");

                            if (!ftp.ChangeDir(ptbPatient.BunHo))
                                throw new Exception("ChangeDir Error");
                        }
                        else
                        {
                            if (isMakeDir)
                                if (!ftp.MakeDir(array1[i]))
                                    throw new Exception("MakeDir Error");

                            if (!ftp.ChangeDir(array1[i]))
                                throw new Exception("ChangeDir Error");
                        }
                    }
                    ///////////////////////////////////////////////////
                    //for (int j = 0; j < array2.Count; j++)
                    //{
                    //    dirItem = (IHIS.Framework.XFTPWorker.DirItems)array2[j];
                    //    if (dirItem.IsFile)
                    //        continue;

                    //    if (dirItem.Filename == array1[1]) //3
                    //        isMakeDir = false;
                    //}
                    //if (isMakeDir)
                    //    ftp.MakeDir(array1[1]); //3;

                    //ftp.ChangeDir(array1[1]); //3;
                    //array2 = ftp.GetDirList(false);

                    //isMakeDir = true;
                    //array2 = ftp.GetDirList(false);
                    //for (int j = 0; j < array2.Count; j++)
                    //{
                    //    dirItem = (IHIS.Framework.XFTPWorker.DirItems)array2[j];
                    //    if (dirItem.IsFile)
                    //        continue;

                    //    if (dirItem.Filename == this.ptbPatient.BunHo)
                    //        isMakeDir = false;
                    //}
                    //if (isMakeDir)
                    //    ftp.MakeDir(this.ptbPatient.BunHo);
                    //ftp.ChangeDir(this.ptbPatient.BunHo);

                    for (int i = 0; i < this.grdImage.RowCount; i++)
                    {
                        strKey = this.grdImage.GetItemString(i, "image_path");

                        if (this.grdImage.GetItemString(i, "image_path").Length > 0)
                        {
                            //string tPath = Directory.GetCurrentDirectory();
                            Directory.SetCurrentDirectory(strClientPath);
                            ftp.SendFileToClient(strKey, strKey);
                            Directory.SetCurrentDirectory(@"C:\\IHIS\\bin\\");

                            image = Image.FromFile(strClientPath + strKey);
                            this.grdImage.SetItemValue(i, "image", image);
                            image.Dispose();
                            File.Delete(strClientPath + strKey);
                        }
                    }
                    if (!TypeCheck.IsNull(ftp))
                        ftp.Close();
                }
                else
                {
                    if (!TypeCheck.IsNull(ftp))
                        ftp.Close();
                    XMessageBox.Show("FTP ログインに失敗しました。");
                    return;
                }
            }
            catch (Exception ex)
            {
                if (!TypeCheck.IsNull(image))
                    image.Dispose();

                if (!TypeCheck.IsNull(ftp))
                    ftp.Close();
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("イメージ取り込み中にエラーが発生しました。 : " + ex.ToString());
            }
            this.grdImage.ResetUpdate();
        }

        private void grdNur6002_QueryEnd(object sender, QueryEndEventArgs e)
        {
//            object o_weight = null;
//            string cmdText = @"SELECT A.WEIGHT
//                                  FROM NUR7001 A
//                                 WHERE HOSP_CODE      = :f_hosp_code
//                                   AND BUNHO          = :f_bunho
//                                   AND A.MEASURE_DATE = (SELECT MAX(D.MEASURE_DATE)
//                                                               FROM NUR7001 D
//                                                              WHERE D.HOSP_CODE = A.HOSP_CODE 
//                                                                AND D.BUNHO = A.BUNHO
//                                                                AND D.VALD  = 'Y'
//                                                                AND D.MEASURE_DATE <= SYSDATE)
//                                   AND A.SEQ          = (SELECT MAX(E.SEQ)
//                                                               FROM NUR7001 E
//                                                              WHERE E.HOSP_CODE = A.HOSP_CODE 
//                                                                AND E.BUNHO = A.BUNHO
//                                                                AND E.VALD = 'Y'
//                                                                AND E.MEASURE_DATE = (SELECT MAX(F.MEASURE_DATE)
//                                                                                       FROM NUR7001 F
//                                                                                      WHERE F.HOSP_CODE = A.HOSP_CODE 
//                                                                                        AND F.BUNHO = A.BUNHO
//                                                                                        AND F.VALD  = 'Y'
//                                                                                        AND F.MEASURE_DATE <= SYSDATE))";

//            BindVarCollection bc = new BindVarCollection();
//            bc.Add("f_bunho", this.ptbPatient.BunHo);
//            bc.Add("f_hosp_code", EnvironInfo.HospCode);

//            o_weight = Service.ExecuteScalar(cmdText, bc);

//            if (!TypeCheck.IsNull(o_weight))
//            {
//                for (int i = 0; i < this.grdNur6002.RowCount; i++)
//                {
//                    this.grdNur6002.SetItemValue(i, "weight", o_weight);
//                    this.grdNur6002.SetItemValue(i, "yokchang_weight", o_weight);
//                }
//            }
//            this.grdNur6002.ResetUpdate();
        }
        #endregion

        #region 출력관련 grdPrint, btnPrint
        private void grdPrint_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPrint.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPrint.SetBindVarValue("f_bunho", this.ptbPatient.BunHo);
            this.grdPrint.SetBindVarValue("f_from_date", this.grdNur6001.GetItemString(grdNur6001.CurrentRowNumber, "from_date"));
            this.grdPrint.SetBindVarValue("f_assessor_date", calBedsore.SelectedDays[0].Date.ToString("yyyy/MM/dd"));
        }

        private void grdPrint_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdPrint.RowCount < 1)
                return;

            for (int i = 0; i < this.grdPrint.RowCount; i++)
            {
                this.layImage.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.layImage.SetBindVarValue("f_bunho", this.grdPrint.GetItemString(i,"bunho"));
                this.layImage.SetBindVarValue("f_from_date", this.grdPrint.GetItemString(i,"from_date"));
                this.layImage.SetBindVarValue("f_assessor_date", this.grdPrint.GetItemString(i,"assessor_date"));
                this.layImage.SetBindVarValue("f_buwi", this.grdPrint.GetItemString(i,"bedsore_buwi"));
                this.layImage.QueryLayout(true);
                if (this.layImage.RowCount > 0)
                {
                    string strKey = "";
                    if (!Directory.Exists(strClientPath))
                        Directory.CreateDirectory(strClientPath);
                    IHIS.Framework.XFTPWorker ftp = null;
                    Image image = null;
                    bool isMakeDir = true;

                    try
                    {
                        char[] spliter = { '/' };
                        string[] array1 = strServerPath.Split(spliter);
                        ArrayList array2 = new ArrayList();
                        IHIS.Framework.XFTPWorker.DirItems dirItem = new XFTPWorker.DirItems();

                        ftp = new XFTPWorker(strFtpUser, strFtpPass, strServer);
                        if (ftp.Connected)
                        {
                            isMakeDir = true;
                            array2 = ftp.GetDirList(false);
                            for (int j = 0; j < array1.Length; j++)
                            {
                                if (array1[j] == "")
                                    continue;

                                isMakeDir = true;
                                array2 = ftp.GetDirList(false);
                                for (int k = 0; k < array2.Count; k++)
                                {
                                    dirItem = (IHIS.Framework.XFTPWorker.DirItems)array2[k];
                                    if (dirItem.IsFile)
                                        continue;
                                    if (array1[j] == "#PatienID")
                                    {
                                        if (dirItem.Filename == ptbPatient.BunHo)
                                            isMakeDir = false;
                                    }
                                    else
                                    {
                                        if (dirItem.Filename == array1[j])
                                            isMakeDir = false;
                                    }
                                }

                                if (array1[j] == "#PatienID")
                                {
                                    if (isMakeDir)
                                        if (!ftp.MakeDir(ptbPatient.BunHo))
                                            throw new Exception("MakeDir Error");
                                    if (!ftp.ChangeDir(ptbPatient.BunHo))
                                        throw new Exception("ChangeDir Error");
                                }
                                else
                                {
                                    if (isMakeDir)
                                        if (!ftp.MakeDir(array1[j]))
                                            throw new Exception("MakeDir Error");
                                    if (!ftp.ChangeDir(array1[j]))
                                        throw new Exception("ChangeDir Error");
                                }
                            }
                            strKey = this.layImage.GetItemString(0, "image_path");
                            if (this.layImage.GetItemString(0, "image_path").Length > 0)
                            {
                                Directory.SetCurrentDirectory(strClientPath);
                                ftp.SendFileToClient(strKey, strKey);
                                Directory.SetCurrentDirectory(@"C:\\IHIS\\bin\\");

                                image = Image.FromFile(strClientPath + strKey);
                                this.grdPrint.SetItemValue(i, "image", strClientPath + strKey);
                                image.Dispose();
                            }
                            if (!TypeCheck.IsNull(ftp))
                                ftp.Close();
                        }
                        else
                        {
                            if (!TypeCheck.IsNull(ftp))
                                ftp.Close();
                            XMessageBox.Show("FTPログインに失敗しました");
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        if (!TypeCheck.IsNull(image))
                            image.Dispose();

                        if (!TypeCheck.IsNull(ftp))
                            ftp.Close();
						//https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show("イメージ取り込み中にエラーが発生しました。 : " + ex.ToString());
                    }
                    
                    this.grdPrint.ResetUpdate();
                }
                
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.grdNur6001.CurrentRowNumber < 0)
                return;
            PrintSet printSet = new PrintSet(this.ptbPatient.BunHo, 
                this.grdNur6001.GetItemDateTime(this.grdNur6001.CurrentRowNumber, "from_date"),
                calBedsore.SelectedDays[0].Date);

            printSet.ShowDialog();


            //2012.01.31 주석
            //this.grdPrint.Reset();
            //this.dwPrint.Reset();
            //this.grdPrint.QueryLayout(true);
            //foreach (DataRow dr in this.grdPrint.LayoutTable.Rows)
            //{
            //    this.layPrintLoad.LayoutTable.ImportRow(dr);
            //    this.dwPrint.FillData(layPrintLoad.LayoutTable);
            //    this.dwPrint.Modify("p_5.filename='" + this.layPrintLoad.GetItemString(0, "image") + "'");
            //    //this.dwPrint.Modify("p_5.height='100%'");
            //    this.dwPrint.Refresh();
            //    this.dwPrint.Print();
            //    if (this.layImage.RowCount > 0)
            //    {
            //        File.Delete(this.layPrintLoad.GetItemString(0, "image"));
            //    }
            //    this.layPrintLoad.Reset();
            //    this.dwPrint.Reset();
            //}
        }

        #endregion

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR6001U00 parent = null;

            public XSavePerformer(NUR6001U00 parent)
            {
                this.parent = parent;
            }
            //Execute 구현
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal  = null;

                string fileName = "";
                string assessorDate = "";
                IHIS.Framework.XFTPWorker ftp = null;
                char[] spliter1 = { '.' };
                string[] arrayFile = null;

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"
                                    UPDATE NUR6001 A
                                       SET A.END_DATE  = TO_DATE(:f_from_date,'YYYY/MM/DD') -1
                                     WHERE A.HOSP_CODE = :f_hosp_code 
                                       AND A.BUNHO     = :f_bunho
                                       AND A.FROM_DATE = ( SELECT MAX(B.FROM_DATE)
                                                             FROM NUR6001 B
                                                            WHERE B.HOSP_CODE = A.HOSP_CODE 
                                                              AND B.BUNHO = A.BUNHO
                                                              AND B.FROM_DATE <= TO_DATE(:f_from_date, 'YYYY/MM/DD') )";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return false;
                                    }
                                }

                                if (int.Parse(item.BindVarList["f_from_date"].VarValue.Replace("/", "")) >
                                    int.Parse(item.BindVarList["f_end_date"].VarValue.Replace("/", "")))
                                {
                                    XMessageBox.Show("開始日が終了日より後に設定されています。", "エラー", MessageBoxIcon.Error);
                                    return false;
                                }

                                cmdText = @"
                        INSERT INTO NUR6001 (SYS_DATE ,         SYS_ID,             UPD_DATE,           UPD_ID,      
                                             HOSP_CODE,         BUNHO,
                                             FROM_DATE,         END_DATE,           BEDSORE_BUWI1,      BEDSORE_BUWI2,
                                             BEDSORE_BUWI3,     BEDSORE_BUWI4,      BEDSORE_BUWI5,      BEDSORE_BUWI6,
                                             FKINP1001)
                        VALUES              (SYSDATE,           :q_user_id,         SYSDATE,            :q_user_id,
                                             :f_hosp_code,      :f_bunho,
                                             TO_DATE(:f_from_date, 'YYYY/MM/DD'),   :f_end_date,        :f_bedsore_buwi1, :f_bedsore_buwi2,
                                             :f_bedsore_buwi3,  :f_bedsore_buwi4,   :f_bedsore_buwi5,   :f_bedsore_buwi6,
                                             :f_fkinp1001)";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR6001
                                               SET UPD_ID         = :q_user_id,
                                                   UPD_DATE       = SYSDATE,
                                                   END_DATE       = :f_end_date,
                                                   BEDSORE_BUWI1  = :f_bedsore_buwi1,
                                                   BEDSORE_BUWI2  = :f_bedsore_buwi2,
                                                   BEDSORE_BUWI3  = :f_bedsore_buwi3,
                                                   BEDSORE_BUWI4  = :f_bedsore_buwi4,
                                                   BEDSORE_BUWI5  = :f_bedsore_buwi5,
                                                   BEDSORE_BUWI6  = :f_bedsore_buwi6
                                            WHERE  HOSP_CODE = :f_hosp_code 
                                              AND  BUNHO     = :f_bunho
                                              AND  FROM_DATE = TO_DATE(:f_from_date, 'YYYY/MM/DD')";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM NUR6002
                                                             WHERE HOSP_CODE        = :f_hosp_code 
                                                               AND BUNHO            = :f_bunho
                                                               AND FROM_DATE        = TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                                               AND NVL(END_YN, 'N') = 'Y')";
                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show("既に褥瘡評価がされています。ご確認ください。", "注意", MessageBoxIcon.Error);
                                    return false;
                                }

                                cmdText = "DELETE NUR6001 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho AND FROM_DATE = TO_DATE(:f_from_date, 'YYYY/MM/DD')";
                                if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    cmdText = "DELETE NUR6002 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho AND FROM_DATE = TO_DATE(:f_from_date, 'YYYY/MM/DD')";
                                }
                                else
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return false;
                                    }
                                }
                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS (SELECT 'X'
                                                             FROM NUR6001
                                                            WHERE HOSP_CODE = :f_hosp_code
                                                              AND BUNHO     = :f_bunho
                                                              AND FROM_DATE = :f_from_date
                                                              AND :f_assessor_date BETWEEN FROM_DATE 
                                                                                       AND NVL(END_DATE,TO_DATE('99981231','YYYYMMDD')))";
                                retVal = null;
                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(retVal) && !retVal.ToString().Equals("Y"))
                                {
                                    parent.SetMsg("褥瘡評価日付は褥瘡発生日と褥瘡終了日の間に設定してください。", MsgType.Error);
                                    return false;
                                }

                                cmdText = @"
                                INSERT INTO NUR6002 
                                          ( SYS_DATE                , SYS_ID                    , UPD_DATE                  , UPD_ID              , 
                                            HOSP_CODE               , BUNHO                     ,
                                            FROM_DATE               , BEDSORE_BUWI              , ASSESSOR_DATE             , ASSESSOR            ,
                                            BEDSORE_DEEP            , BEDSORE_DEPTH             , BEDSORE_COLOR             , BEDSORE_SIZE1       ,
                                            BEDSORE_SIZE_START1     , BEDSORE_SIZE_FINISH1      , BEDSORE_POKET1            , BEDSORE_POKET_START1,
                                            BEDSORE_POKET_FINISH1   , BEDSORE_DEATH             , EXUDATION_VOLUME          , EXUDATION_STATE     ,
                                            EXUDATION_COLOR         , EXUDATION_SMELL           , BEDSORE_SKIN              , BEDSORE_INFE        ,
                                            BEDSORE_MOIST           , BEDSORE_MOIST_RATE        , BEDSORE_GITA              , BEDSORE_NUT         ,
                                            BEDSORE_HB              , BEDSORE_ALB               , BEDSORE_FBS               , BEDSORE_ZN          ,
                                            BEDSORE_SIZE2           , BEDSORE_SIZE_START2       , BEDSORE_SIZE_FINISH2      , BEDSORE_POKET2      ,
                                            BEDSORE_POKET_START2    , BEDSORE_POKET_FINISH2     , END_YN                    , EXUDATION_STATE1    ,
                                            EXUDATION_STATE2        , BEDSORE_COLOR2            , BEDSORE_COLOR3            , BEDSORE_COLOR4      ,
                                            FIRST_SAYU              , LAST_SAYU                 , YOKCHANG_DEEP             ,
                                            SAMCHUL_YANG            , YOKCHANG_SIZE             , YOKCHANG_SIZE_START       ,
                                            YOKCHANG_SIZE_END       , YOKCHANG_GAMYUM           , YUKAJOJIK                 ,
                                            GAESAJOJIK              , POCKET_GUBUN              , POCKET_SIZE_START         ,
                                            POCKET_SIZE_END         , YOKCHANG_STAGE            , TOTAL_COUNT               ,
                                            YUNGYANG_SIKSA_GUBUN    , YUNGYANG_SIKSA_YANG       , YUNGYANG_SIKSA_PERCENT    ,
                                            YUNGYANG_SUAEK_YN       , YUNGYANG_SUAEK_YANG       , CHUCHI_TEXT               ,
                                            YOKCHANG_HB             , YOKCHANG_ALB              , YOKCHANG_TP               )
                                     VALUES (
                                             SYSDATE                , :q_user_id                , SYSDATE                   , :q_user_id          ,
                                             :f_hosp_code           , :f_bunho                  ,
                                             TO_DATE(:f_from_date, 'YYYY/MM/DD')  , :f_bedsore_buwi  , TO_DATE(:f_assessor_date, 'YYYY/MM/DD')  ,:f_assessor,
                                             :f_bedsore_deep         , :f_bedsore_depth         , :f_bedsore_color          , :f_bedsore_size1,
                                             :f_bedsore_size_start1  , :f_bedsore_size_finish1  , :f_bedsore_poket1         , :f_bedsore_poket_start1,
                                             :f_bedsore_poket_finish1, :f_bedsore_death         , :f_exudation_volume       , :f_exudation_state,
                                             :f_exudation_color      , :f_exudation_smell       , :f_bedsore_skin           , :f_bedsore_infe,
                                             :f_bedsore_moist        , :f_bedsore_moist_rate    , :f_bedsore_gita           , :f_bedsore_nut,
                                             :f_bedsore_hb           , :f_bedsore_alb           , :f_bedsore_fbs            , :f_bedsore_zn,
                                             :f_bedsore_size2        , :f_bedsore_size_start2   , :f_bedsore_size_finish2   , :f_bedsore_poket2,
                                             :f_bedsore_poket_start2 , :f_bedsore_poket_finish2 , :f_end_yn                 , :f_exudation_state1   ,
                                             :f_exudation_state2     , :f_bedsore_color2        , :f_bedsore_color3         , :f_bedsore_color4,
                                             :f_first_sayu           , :f_last_sayu             , :f_yokchang_deep          ,
                                             :f_samchul_yang         , :f_yokchang_size         , :f_yokchang_size_start    ,
                                             :f_yokchang_size_end    , :f_yokchang_gamyum       , :f_yukajojik              ,
                                             :f_gaesajojik           , :f_pocket_gubun          , :f_pocket_size_start      ,
                                             :f_pocket_size_end      , :f_yokchang_stage        , :f_total_count            ,
                                             :f_yungyang_siksa_gubun , :f_yungyang_siksa_yang   , :f_yungyang_siksa_percent ,
                                             :f_yungyang_suaek_yn    , :f_yungyang_suaek_yang   , :f_chuchi_text            ,
                                             :f_yokchang_hb          , :f_yokchang_alb          , :f_yokchang_tp            )   ";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR6002
                                               SET UPD_ID                 = :q_user_id
                                                 , UPD_DATE               = SYSDATE
                                                 , ASSESSOR               = :f_assessor
                                                 , BEDSORE_DEEP           = :f_bedsore_deep
                                                 , BEDSORE_DEPTH          = :f_bedsore_depth
                                                 , BEDSORE_COLOR          = :f_bedsore_color
                                                 , BEDSORE_SIZE1          = :f_bedsore_size1
                                                 , BEDSORE_SIZE_START1    = :f_bedsore_size_start1
                                                 , BEDSORE_SIZE_FINISH1   = :f_bedsore_size_finish1
                                                 , BEDSORE_POKET1         = :f_bedsore_poket1
                                                 , BEDSORE_POKET_START1   = :f_bedsore_poket_start1
                                                 , BEDSORE_POKET_FINISH1  = :f_bedsore_poket_finish1
                                                 , BEDSORE_DEATH          = :f_bedsore_death
                                                 , EXUDATION_VOLUME       = :f_exudation_volume
                                                 , EXUDATION_STATE        = :f_exudation_state
                                                 , EXUDATION_COLOR        = :f_exudation_color
                                                 , EXUDATION_SMELL        = :f_exudation_smell
                                                 , BEDSORE_SKIN           = :f_bedsore_skin
                                                 , BEDSORE_INFE           = :f_bedsore_infe
                                                 , BEDSORE_MOIST          = :f_bedsore_moist
                                                 , BEDSORE_MOIST_RATE     = :f_bedsore_moist_rate
                                                 , BEDSORE_GITA           = :f_bedsore_gita
                                                 , BEDSORE_NUT            = :f_bedsore_nut
                                                 , BEDSORE_HB             = :f_bedsore_hb
                                                 , BEDSORE_ALB            = :f_bedsore_alb
                                                 , BEDSORE_FBS            = :f_bedsore_fbs
                                                 , BEDSORE_ZN             = :f_bedsore_zn
                                                 , BEDSORE_SIZE2          = :f_bedsore_size2
                                                 , BEDSORE_SIZE_START2    = :f_bedsore_size_start2
                                                 , BEDSORE_SIZE_FINISH2   = :f_bedsore_size_finish2
                                                 , BEDSORE_POKET2         = :f_bedsore_poket2
                                                 , BEDSORE_POKET_START2   = :f_bedsore_poket_start2
                                                 , BEDSORE_POKET_FINISH2  = :f_bedsore_poket_finish2
                                                 , END_YN                 = :f_end_yn
                                                 , EXUDATION_STATE1       = :f_exudation_state1
                                                 , EXUDATION_STATE2       = :f_exudation_state2
                                                 , BEDSORE_COLOR2         = :f_bedsore_color2
                                                 , BEDSORE_COLOR3         = :f_bedsore_color3
                                                 , BEDSORE_COLOR4         = :f_bedsore_color4
                                                 , FIRST_SAYU             = :f_first_sayu            
                                                 , LAST_SAYU              = :f_last_sayu             
                                                 , YOKCHANG_DEEP          = :f_yokchang_deep         
                                                 , SAMCHUL_YANG           = :f_samchul_yang          
                                                 , YOKCHANG_SIZE          = :f_yokchang_size         
                                                 , YOKCHANG_SIZE_START    = :f_yokchang_size_start   
                                                 , YOKCHANG_SIZE_END      = :f_yokchang_size_end     
                                                 , YOKCHANG_GAMYUM        = :f_yokchang_gamyum       
                                                 , YUKAJOJIK              = :f_yukajojik             
                                                 , GAESAJOJIK             = :f_gaesajojik            
                                                 , POCKET_GUBUN           = :f_pocket_gubun          
                                                 , POCKET_SIZE_START      = :f_pocket_size_start     
                                                 , POCKET_SIZE_END        = :f_pocket_size_end       
                                                 , YOKCHANG_STAGE         = :f_yokchang_stage        
                                                 , TOTAL_COUNT            = :f_total_count           
                                                 , YUNGYANG_SIKSA_GUBUN   = :f_yungyang_siksa_gubun  
                                                 , YUNGYANG_SIKSA_YANG    = :f_yungyang_siksa_yang   
                                                 , YUNGYANG_SIKSA_PERCENT = :f_yungyang_siksa_percent
                                                 , YUNGYANG_SUAEK_YN      = :f_yungyang_suaek_yn     
                                                 , YUNGYANG_SUAEK_YANG    = :f_yungyang_suaek_yang   
                                                 , CHUCHI_TEXT            = :f_chuchi_text           
                                                 , YOKCHANG_HB            = :f_yokchang_hb           
                                                 , YOKCHANG_ALB           = :f_yokchang_alb          
                                                 , YOKCHANG_TP            = :f_yokchang_tp  
                                             WHERE HOSP_CODE              = :f_hosp_code 
                                               AND BUNHO                  = :f_bunho
                                               AND FROM_DATE              = TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                               AND BEDSORE_BUWI           = :f_bedsore_buwi
                                               AND ASSESSOR_DATE          = TO_DATE(:f_assessor_date, 'YYYY/MM/DD')";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM NUR6002
                                                             WHERE HOSP_CODE    = :f_hosp_code
                                                               AND BUNHO        = :f_bunho
                                                               AND FROM_DATE    = :f_from_date
                                                               AND BEDSORE_BUWI = :f_bedsore_buwi
                                                               AND END_YN = 'Y' )";
                                retVal = null;
                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                                {
                                    parent.SetMsg("褥瘡評価が完了され削除できません。", MsgType.Error);
                                    return false;
                                }

                                cmdText = string.Empty;
                                cmdText = @"DELETE NUR6002
                                             WHERE HOSP_CODE      = :f_hosp_code 
                                               AND BUNHO          = :f_bunho
                                               AND FROM_DATE      = TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                               AND  BEDSORE_BUWI  = :f_bedsore_buwi
                                               AND  ASSESSOR_DATE = TO_DATE(:f_assessor_date, 'YYYY/MM/DD')";
                                break;
                        }
                        break;

                    case '3':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                assessorDate = item.BindVarList["f_assessor_date"].VarValue.Replace("/", "").Replace("-", "").Substring(0, 8);

                                cmdText = @"
                                            SELECT NVL(MAX(SEQ),0) + 1
                                              FROM NUR6004
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND BUNHO         = :f_bunho
                                               AND FROM_DATE     = TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                               AND BEDSORE_BUWI  = :f_bedsore_buwi
                                               AND ASSESSOR_DATE = TO_DATE(:f_assessor_date, 'YYYY/MM/DD')";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                // 파일명 저장

                                arrayFile = item.BindVarList["f_base_image_path"].VarValue.Split(spliter1);

                                if (item.BindVarList["f_image"].ValueLen > 0)
                                {
                                    fileName = item.BindVarList["f_bunho"].VarValue + assessorDate +
                                        item.BindVarList["f_bedsore_buwi"].VarValue + retVal.ToString() + "." + arrayFile[arrayFile.Length - 1].ToString().ToUpper();

                                    item.BindVarList.Add("t_file_name", fileName);
                                    item.BindVarList.Add("t_seq", retVal.ToString());
                                }

                                cmdText = @"
                                            INSERT INTO NUR6004 ( SYS_DATE       , SYS_ID      , UPD_DATE             , UPD_ID         ,
                                                                  HOSP_CODE      , BUNHO       , FROM_DATE            , BEDSORE_BUWI   ,
                                                                  ASSESSOR_DATE  , SEQ         , BEDSORE_BUWI_IMAGE   )
                                            VALUES              ( SYSDATE        , :q_user_id  , SYSDATE              , :q_user_id     ,
                                                                  :f_hosp_code   , :f_bunho    , TO_DATE(:f_from_date, 'YYYY/MM/DD'), :f_bedsore_buwi     ,
                                                                  TO_DATE(:f_assessor_date, 'YYYY/MM/DD'), :t_seq      , :t_file_name)";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    throw new Exception();

                                ftp = null;

                                try
                                {
                                    ftp = new XFTPWorker(parent.strFtpUser, parent.strFtpPass, parent.strServer);
                                    if (ftp.Connected)
                                    {
                                        bool isMakeDir = true;
                                        IHIS.Framework.XFTPWorker.DirItems dirItem = new XFTPWorker.DirItems();
                                   
                                        char[] spliter = { '/' };
                                        string[] array1 = parent.strServerPath.Split(spliter); // /NURI/
                                        ArrayList array2 = ftp.GetDirList(false);

                                        for (int i = 0; i < array1.Length; i++)
                                        {
                                            if (array1[i] == "")
                                                continue;

                                            isMakeDir = true;
                                            array2 = ftp.GetDirList(false);
                                            for (int j = 0; j < array2.Count; j++)
                                            {
                                                dirItem = (IHIS.Framework.XFTPWorker.DirItems)array2[j];
                                                if (dirItem.IsFile)
                                                    continue;
                                                if (array1[i] == "#PatienID")
                                                {
                                                    if (dirItem.Filename == item.BindVarList["f_bunho"].VarValue)
                                                        isMakeDir = false;
                                                }
                                                else
                                                {
                                                    if (dirItem.Filename == array1[i]) //3
                                                        isMakeDir = false;
                                                }
                                            }

                                            if (array1[i] == "#PatienID")
                                            {
                                                if (isMakeDir)
                                                    if (!ftp.MakeDir(item.BindVarList["f_bunho"].VarValue))
                                                        throw new Exception("MakeDir Error");

                                                if (!ftp.ChangeDir(item.BindVarList["f_bunho"].VarValue))
                                                    throw new Exception("ChangeDir Error");
                                            }
                                            else
                                            {
                                                if (isMakeDir)
                                                    if (!ftp.MakeDir(array1[i]))
                                                        throw new Exception("MakeDir Error");
                                                if (!ftp.ChangeDir(array1[i]))
                                                    throw new Exception("ChangeDir Error");
                                            }

                                        }

                                        //if (ftp.ExistFile(fileName))
                                        //{
                                        //    ftp.DeleteFile(fileName);
                                        //}

                                        //string serverFile = /* parent.strServerPath + item.BindVarList["f_bunho"].VarValue + "/" + fileName;*/
                                        if (!ftp.SendFileToServer(item.BindVarList["f_base_image_path"].VarValue, fileName))
                                            throw new Exception();

                                        if (!TypeCheck.IsNull(ftp))
                                            ftp.Close();
                                    }
                                    else
                                    {
                                        if (!TypeCheck.IsNull(ftp))
                                            ftp.Close();
                                        XMessageBox.Show("FTP ログインに失敗しました。");
                                        return false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if(!TypeCheck.IsNull(ftp))
                                    ftp.Close();
									//https://sofiamedix.atlassian.net/browse/MED-10610
                                    //XMessageBox.Show("イメージ保存中にエラーが発生しました。" + ex.ToString());
                                    return false;
                                }
                                return true;

                            case DataRowState.Modified:
                                ftp = null;

                                try
                                {
                                    if (item.BindVarList["f_image"].ValueLen > 0)
                                    {
                                        fileName = item.BindVarList["f_image_path"].VarValue;
                                    }

                                    ftp = new XFTPWorker(parent.strFtpUser, parent.strFtpPass, parent.strServer);
                                    if (ftp.Connected)
                                    {
                                        bool isMakeDir = true;
                                        IHIS.Framework.XFTPWorker.DirItems dirItem = new XFTPWorker.DirItems();

                                        char[] spliter = { '/' };
                                        string[] array1 = parent.strServerPath.Split(spliter); // /NURI/
                                        ArrayList array2 = ftp.GetDirList(false);

                                        for (int i = 0; i < array1.Length; i++)
                                        {
                                            if (array1[i] == "")
                                                continue;

                                            isMakeDir = true;
                                            array2 = ftp.GetDirList(false);
                                            for (int j = 0; j < array2.Count; j++)
                                            {
                                                dirItem = (IHIS.Framework.XFTPWorker.DirItems)array2[j];
                                                if (dirItem.IsFile)
                                                    continue;
                                                if (array1[i] == "#PatienID")
                                                {
                                                    if (dirItem.Filename == item.BindVarList["f_bunho"].VarValue)
                                                        isMakeDir = false;
                                                }
                                                else
                                                {
                                                    if (dirItem.Filename == array1[i]) //3
                                                        isMakeDir = false;
                                                }
                                            }

                                            if (array1[i] == "#PatienID")
                                            {
                                                if (isMakeDir)
                                                    if (!ftp.MakeDir(item.BindVarList["f_bunho"].VarValue))
                                                        throw new Exception("MakeDir Error");

                                                if (!ftp.ChangeDir(item.BindVarList["f_bunho"].VarValue))
                                                    throw new Exception("ChangeDir Error");
                                            }
                                            else
                                            {
                                                if (isMakeDir)
                                                    if (!ftp.MakeDir(array1[i]))
                                                        throw new Exception("MakeDir Error");
                                                if (!ftp.ChangeDir(array1[i]))
                                                    throw new Exception("ChangeDir Error");
                                            }

                                        }

                                        //if (ftp.ExistFile(fileName))
                                        //{
                                        //    ftp.DeleteFile(fileName);
                                        //}

                                        //string serverFile = /* parent.strServerPath + item.BindVarList["f_bunho"].VarValue + "/" + fileName;*/
                                        if (!ftp.SendFileToServer(item.BindVarList["f_base_image_path"].VarValue, fileName))
                                            throw new Exception();

                                        if (!TypeCheck.IsNull(ftp))
                                            ftp.Close();
                                    }
                                    else
                                    {
                                        if (!TypeCheck.IsNull(ftp))
                                            ftp.Close();
                                        XMessageBox.Show("FTP ログインに失敗しました。");
                                        return false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (!TypeCheck.IsNull(ftp))
                                        ftp.Close();
									//https://sofiamedix.atlassian.net/browse/MED-10610
                                    //XMessageBox.Show("イメージ保存中にエラーが発生しました。" + ex.ToString());
                                    return false;
                                }
                                return true;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR6004
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND BUNHO         = :f_bunho
                                               AND FROM_DATE     = TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                               AND BEDSORE_BUWI  = :f_bedsore_buwi
                                               AND ASSESSOR_DATE = TO_DATE(:f_assessor_date, 'YYYY/MM/DD')
                                               AND SEQ           = :f_seq";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    return false;

                                ftp = null;

                                try
                                {
                                    fileName = item.BindVarList["f_image_path"].VarValue;

                                    ftp = new XFTPWorker(parent.strFtpUser, parent.strFtpPass, parent.strServer);
                                    if (ftp.Connected)
                                    {
                                        bool isMakeDir = true;
                                        IHIS.Framework.XFTPWorker.DirItems dirItem = new XFTPWorker.DirItems();

                                        char[] spliter = { '/' };
                                        string[] array1 = parent.strServerPath.Split(spliter); // /NURI/
                                        ArrayList array2 = ftp.GetDirList(false);

                                        for (int i = 0; i < array1.Length; i++)
                                        {
                                            if (array1[i] == "")
                                                continue;

                                            isMakeDir = true;
                                            array2 = ftp.GetDirList(false);
                                            for (int j = 0; j < array2.Count; j++)
                                            {
                                                dirItem = (IHIS.Framework.XFTPWorker.DirItems)array2[j];
                                                if (dirItem.IsFile)
                                                    continue;
                                                if (array1[i] == "#PatienID")
                                                {
                                                    if (dirItem.Filename == item.BindVarList["f_bunho"].VarValue)
                                                        isMakeDir = false;
                                                }
                                                else
                                                {
                                                    if (dirItem.Filename == array1[i]) //3
                                                        isMakeDir = false;
                                                }
                                            }

                                            if (array1[i] == "#PatienID")
                                            {
                                                if (isMakeDir)
                                                    if(!ftp.MakeDir(item.BindVarList["f_bunho"].VarValue))
                                                        throw new Exception("MakeDir Error");

                                                if (!ftp.ChangeDir(item.BindVarList["f_bunho"].VarValue))
                                                    throw new Exception("ChangeDir Error");
                                            }
                                            else
                                            {
                                                if (isMakeDir)
                                                    if (!ftp.MakeDir(array1[i]))
                                                        throw new Exception("MakeDir Error");

                                                if (!ftp.ChangeDir(array1[i]))
                                                    throw new Exception("ChangeDir Error");
                                            }
                                        }

                                        if (!ftp.DeleteFile(fileName))
                                            throw new Exception("ChangeDir Error");

                                        if (!TypeCheck.IsNull(ftp))
                                            ftp.Close();
                                    }
                                    else
                                    {
                                        XMessageBox.Show("FTP ログインに失敗しました。");

                                        if (!TypeCheck.IsNull(ftp))
                                            ftp.Close();
                                        return false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (!TypeCheck.IsNull(ftp))
                                        ftp.Close();
									//https://sofiamedix.atlassian.net/browse/MED-10610
                                    //XMessageBox.Show("イメージ削除中にエラーが発生しました。 : " + ex.ToString());

                                    return false;
                                }
                                return true;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList) ;
            }
        }
        #endregion

        private void emkYokchang_size_DataValidating(object sender, DataValidatingEventArgs e)
        {
            int cal_val = 0;
            string t_start = this.emkYokchang_size_start.GetDataValue().Trim();
            string t_end   = this.emkYokchang_size_end.GetDataValue().Trim();
           
            if ( t_start != "" && t_end != "")
            {
                cal_val = Int32.Parse(t_start) * Int32.Parse(t_end);

                if (cal_val < 4)
                {
                    this.xRadioButton25.Checked = true;
                }
                else if (cal_val >= 4 && cal_val < 16)
                {
                    this.xRadioButton24.Checked = true;
                }
                else if (cal_val >= 16 && cal_val < 36)
                {
                    this.xRadioButton23.Checked = true;
                }
                else if (cal_val >= 36 && cal_val < 64)
                {
                    this.xRadioButton10.Checked = true;
                }
                else if (cal_val >= 64 && cal_val < 100)
                {
                    this.xRadioButton9.Checked = true;
                }
                else if (cal_val >= 100)
                {
                    this.xRadioButton28.Checked = true;
                }
                else
                {
                    this.xRadioButton26.Checked = true;
                }
            }

            if (t_start == "" && t_end == "")
            {
                this.xRadioButton26.Checked = true;
            }
        }

        private void emkPocket_size_DataValidating(object sender, DataValidatingEventArgs e)
        {
            int cal_val = 0;
            string t_start = this.emkPocket_size_start.GetDataValue().Trim();
            string t_end = this.emkPocket_size_end.GetDataValue().Trim();

            if (t_start != "" && t_end != "")
            {
                cal_val = Int32.Parse(t_start) * Int32.Parse(t_end);

                if (cal_val < 4)
                {
                    this.xRadioButton41.Checked = true;
                }
                else if (cal_val >= 4 && cal_val < 16)
                {
                    this.xRadioButton22.Checked = true;
                }
                else if (cal_val >= 16 && cal_val < 36)
                {
                    this.xRadioButton21.Checked = true;
                }
                else if (cal_val >= 36)
                {
                    this.xRadioButton20.Checked = true;                
                }
                else
                {
                    this.xRadioButton42.Checked = true;
                }
            }

            if (t_start == "" && t_end == "")
            {
                this.xRadioButton42.Checked = true;
            }

        }

        private void grdNur6002Copy_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNur6002Copy.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdNur6002Copy.SetBindVarValue("f_bunho", ptbPatient.BunHo);
            grdNur6002Copy.SetBindVarValue("f_from_date", grdNur6001.GetItemString(grdNur6001.CurrentRowNumber, "from_date"));
            grdNur6002Copy.SetBindVarValue("f_bedsore_buwi", this.tabBuwi.SelectedTab.Tag.ToString());
            grdNur6002Copy.SetBindVarValue("f_assessor_date", calBedsore.SelectedDays[0] .Date.ToString("yyyy/MM/dd"));

        }

        private void fbAssessor_FindSelected(object sender, FindEventArgs e)
        {
            this.txtAssessor.Text = e.ReturnValues[1].ToString();
        }

        private void fwkAssessor_QueryStarting(object sender, CancelEventArgs e)
        {
            string cmdText = @"SELECT HO_DONG1 FROM VW_OCS_INP1001_01 WHERE HOSP_CODE=:f_hosp_code AND BUNHO = :f_bunho";
            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_bunho", ptbPatient.BunHo);
            
            object result = Service.ExecuteScalar(cmdText, bindVar);

            if (result != null)
            {
                fwkAssessor.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                fwkAssessor.SetBindVarValue("f_buseo_name", result.ToString());
            }
            else
            {
                XMessageBox.Show("患者情報照会エラー");
            }
        }
	}
}

