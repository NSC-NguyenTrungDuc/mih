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

namespace IHIS.SCHS
{
	/// <summary>
	/// SCH0201U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH0201U00 : IHIS.Framework.XScreen
	{
		#region 화면변수	
		private string in_out_gubun, doctor, hangmog_code;
		private string jundal_table;
		private string jundal_part ;
		private string reser_date  ;
		private string key         ;
		private string hangmog_name;
		private string gwa         ;
		private string time_yn     ;
		private string chk_dw      ;
		private string reser_gumsa_yn;
		private string col_name      ;
		private string reser_yn      ;

		private bool dw_1, dw_2, dw_3, dw_4, dw_5, dw_6, dw_7, dw_8, dw_9, dw_10;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPatientBox paBoxPatient;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.MultiLayout layReserList;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XPanel xPanel5;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XDatePicker dtDate;
		private IHIS.Framework.XButton btPreDate;
		private IHIS.Framework.XButton btPostDate;
		private IHIS.Framework.SingleLayout layHoliYN;
		private IHIS.Framework.MultiLayout layTimeList;
		private IHIS.Framework.XDataWindow dwReserList;
		private IHIS.Framework.XButton btnSave;
        private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XDataWindow dwReserPrint;
		private IHIS.Framework.XButton btnReserPrint;
		private IHIS.Framework.XDataWindow dwReserList_1;
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XPanel xPanel8;
		private IHIS.Framework.XPanel xPanel10;
		private IHIS.Framework.XPanel xPanel12;
		private IHIS.Framework.XPanel xPanel14;
		private IHIS.Framework.XDataWindow dwReserList_5;
		private IHIS.Framework.XDataWindow dwReserList_4;
		private IHIS.Framework.XDataWindow dwReserList_3;
		private IHIS.Framework.XDataWindow dwReserList_2;
		private IHIS.Framework.XLabel lbHangmogName_1;
		private IHIS.Framework.XLabel lbReserDate_1;
		private IHIS.Framework.XLabel lbHangmogName_5;
		private IHIS.Framework.XLabel lbReserDate_5;
		private IHIS.Framework.XLabel lbHangmogName_4;
		private IHIS.Framework.XLabel lbReserDate_4;
		private IHIS.Framework.XLabel lbHangmogName_3;
		private IHIS.Framework.XLabel lbReserDate_3;
		private IHIS.Framework.XLabel lbHangmogName_2;
		private IHIS.Framework.XLabel lbReserDate_2;
		private IHIS.Framework.XEditGrid grdReserDate;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XDatePicker xdtReserDate;
		private IHIS.Framework.XEditMask xemPrintCnt;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditMask txtTime_1;
		private IHIS.Framework.XEditMask txtTime_2;
		private IHIS.Framework.XEditMask txtTime_3;
		private IHIS.Framework.XEditMask txtTime_4;
		private IHIS.Framework.XEditMask txtTime_5;
		private IHIS.Framework.XPanel panReser_5;
		private IHIS.Framework.XPanel panReser_4;
		private IHIS.Framework.XPanel panReser_3;
		private IHIS.Framework.XPanel panReser_2;
		private IHIS.Framework.XPanel panReser_1;
		private IHIS.Framework.XPanel panReser_6;
		private IHIS.Framework.XDataWindow dwReserList_6;
		private IHIS.Framework.XPanel xPanel16;
		private IHIS.Framework.XPanel panReser_7;
		private IHIS.Framework.XPanel xPanel7;
		private IHIS.Framework.XPanel panReser_8;
		private IHIS.Framework.XPanel xPanel11;
		private IHIS.Framework.XPanel xPanel9;
		private IHIS.Framework.XPanel xPanel15;
		private IHIS.Framework.XDataWindow dwReserList_8;
		private IHIS.Framework.XEditMask txtTime_8;
		private IHIS.Framework.XLabel lbHangmogName_8;
		private IHIS.Framework.XLabel lbReserDate_8;
		private IHIS.Framework.XDataWindow dwReserList_7;
		private IHIS.Framework.XEditMask txtTime_7;
		private IHIS.Framework.XLabel lbHangmogName_7;
		private IHIS.Framework.XLabel lbReserDate_7;
		private IHIS.Framework.XEditMask txtTime_6;
		private IHIS.Framework.XLabel lbHangmogName_6;
		private IHIS.Framework.XLabel lbReserDate_6;
		private IHIS.Framework.XPanel panReser_9;
		private IHIS.Framework.XDataWindow dwReserList_9;
		private IHIS.Framework.XEditMask txtTime_9;
		private IHIS.Framework.XLabel lbHangmogName_9;
		private IHIS.Framework.XLabel lbReserDate_9;
		private IHIS.Framework.XPanel panReser_10;
		private IHIS.Framework.XDataWindow dwReserList_10;
		private IHIS.Framework.XEditMask txtTime_10;
		private IHIS.Framework.XLabel lbHangmogName_10;
		private IHIS.Framework.XLabel lbReserDate_10;
		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XButton btnComment;
        private IHIS.Framework.XButton btnReserList;
        private IHIS.Framework.SingleLayout layAddInwonChk;
        private IHIS.Framework.SingleLayout layLoginGwa;
		private IHIS.Framework.XButton btnReserOrder;
		private System.Windows.Forms.Label lblGwa;
		private IHIS.Framework.XBuseoCombo cboGwa;
		private System.Windows.Forms.Label lblDoctor;
		private IHIS.Framework.XComboBox cboDoctor;
		private IHIS.Framework.MultiLayout layDoctorList;
		private IHIS.Framework.SingleLayout layJubsuChk;
        private IHIS.Framework.SingleLayout layReserTimeChk;
        private MultiLayout layLoadRES0101;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem9;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private XButton btnResend;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem106;
        private MultiLayoutItem multiLayoutItem89;
        private MultiLayoutItem multiLayoutItem90;
        private MultiLayoutItem multiLayoutItem91;
        private MultiLayoutItem multiLayoutItem92;
        private MultiLayoutItem multiLayoutItem93;
        private MultiLayoutItem multiLayoutItem94;
        private MultiLayoutItem multiLayoutItem95;
        private MultiLayoutItem multiLayoutItem96;
        private MultiLayoutItem multiLayoutItem105;
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
        private MultiLayoutItem multiLayoutItem180;
        private MultiLayoutItem multiLayoutItem183;
        private MultiLayoutItem multiLayoutItem181;
        private XCheckBox cbxIF_YN;
        private SingleLayout layTimeReserYn;
        private SingleLayoutItem singleLayoutItem6;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public SCH0201U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0201U00));
            this.btPreDate = new IHIS.Framework.XButton();
            this.btPostDate = new IHIS.Framework.XButton();
            this.paBoxPatient = new IHIS.Framework.XPatientBox();
            this.dwReserList_1 = new IHIS.Framework.XDataWindow();
            this.layReserList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem89 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem90 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem91 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem92 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem93 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem94 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem105 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem180 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem183 = new IHIS.Framework.MultiLayoutItem();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboDoctor = new IHIS.Framework.XComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cboGwa = new IHIS.Framework.XBuseoCombo();
            this.lblGwa = new System.Windows.Forms.Label();
            this.dtDate = new IHIS.Framework.XDatePicker();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dwReserList = new IHIS.Framework.XDataWindow();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.panReser_10 = new IHIS.Framework.XPanel();
            this.dwReserList_10 = new IHIS.Framework.XDataWindow();
            this.xPanel15 = new IHIS.Framework.XPanel();
            this.txtTime_10 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_10 = new IHIS.Framework.XLabel();
            this.lbReserDate_10 = new IHIS.Framework.XLabel();
            this.panReser_9 = new IHIS.Framework.XPanel();
            this.dwReserList_9 = new IHIS.Framework.XDataWindow();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.txtTime_9 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_9 = new IHIS.Framework.XLabel();
            this.lbReserDate_9 = new IHIS.Framework.XLabel();
            this.panReser_8 = new IHIS.Framework.XPanel();
            this.dwReserList_8 = new IHIS.Framework.XDataWindow();
            this.xPanel11 = new IHIS.Framework.XPanel();
            this.txtTime_8 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_8 = new IHIS.Framework.XLabel();
            this.lbReserDate_8 = new IHIS.Framework.XLabel();
            this.panReser_7 = new IHIS.Framework.XPanel();
            this.dwReserList_7 = new IHIS.Framework.XDataWindow();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.txtTime_7 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_7 = new IHIS.Framework.XLabel();
            this.lbReserDate_7 = new IHIS.Framework.XLabel();
            this.panReser_6 = new IHIS.Framework.XPanel();
            this.dwReserList_6 = new IHIS.Framework.XDataWindow();
            this.xPanel16 = new IHIS.Framework.XPanel();
            this.txtTime_6 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_6 = new IHIS.Framework.XLabel();
            this.lbReserDate_6 = new IHIS.Framework.XLabel();
            this.panReser_5 = new IHIS.Framework.XPanel();
            this.dwReserList_5 = new IHIS.Framework.XDataWindow();
            this.xPanel14 = new IHIS.Framework.XPanel();
            this.txtTime_5 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_5 = new IHIS.Framework.XLabel();
            this.lbReserDate_5 = new IHIS.Framework.XLabel();
            this.panReser_4 = new IHIS.Framework.XPanel();
            this.dwReserList_4 = new IHIS.Framework.XDataWindow();
            this.xPanel12 = new IHIS.Framework.XPanel();
            this.txtTime_4 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_4 = new IHIS.Framework.XLabel();
            this.lbReserDate_4 = new IHIS.Framework.XLabel();
            this.panReser_3 = new IHIS.Framework.XPanel();
            this.dwReserList_3 = new IHIS.Framework.XDataWindow();
            this.xPanel10 = new IHIS.Framework.XPanel();
            this.txtTime_3 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_3 = new IHIS.Framework.XLabel();
            this.lbReserDate_3 = new IHIS.Framework.XLabel();
            this.panReser_2 = new IHIS.Framework.XPanel();
            this.dwReserList_2 = new IHIS.Framework.XDataWindow();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.txtTime_2 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_2 = new IHIS.Framework.XLabel();
            this.lbReserDate_2 = new IHIS.Framework.XLabel();
            this.panReser_1 = new IHIS.Framework.XPanel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.txtTime_1 = new IHIS.Framework.XEditMask();
            this.lbHangmogName_1 = new IHIS.Framework.XLabel();
            this.lbReserDate_1 = new IHIS.Framework.XLabel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.cbxIF_YN = new IHIS.Framework.XCheckBox();
            this.btnResend = new IHIS.Framework.XButton();
            this.btnReserOrder = new IHIS.Framework.XButton();
            this.xdtReserDate = new IHIS.Framework.XDatePicker();
            this.btnReserList = new IHIS.Framework.XButton();
            this.btnComment = new IHIS.Framework.XButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xemPrintCnt = new IHIS.Framework.XEditMask();
            this.btnReserPrint = new IHIS.Framework.XButton();
            this.dwReserPrint = new IHIS.Framework.XDataWindow();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnSave = new IHIS.Framework.XButton();
            this.grdReserDate = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layHoliYN = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layTimeList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem106 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.layAddInwonChk = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.layLoginGwa = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.layDoctorList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.layJubsuChk = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.layReserTimeChk = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.layLoadRES0101 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem181 = new IHIS.Framework.MultiLayoutItem();
            this.layTimeReserYn = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.paBoxPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.panReser_10.SuspendLayout();
            this.xPanel15.SuspendLayout();
            this.panReser_9.SuspendLayout();
            this.xPanel9.SuspendLayout();
            this.panReser_8.SuspendLayout();
            this.xPanel11.SuspendLayout();
            this.panReser_7.SuspendLayout();
            this.xPanel7.SuspendLayout();
            this.panReser_6.SuspendLayout();
            this.xPanel16.SuspendLayout();
            this.panReser_5.SuspendLayout();
            this.xPanel14.SuspendLayout();
            this.panReser_4.SuspendLayout();
            this.xPanel12.SuspendLayout();
            this.panReser_3.SuspendLayout();
            this.xPanel10.SuspendLayout();
            this.panReser_2.SuspendLayout();
            this.xPanel8.SuspendLayout();
            this.panReser_1.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReserDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layDoctorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLoadRES0101)).BeginInit();
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
            this.ImageList.Images.SetKeyName(9, "");
            this.ImageList.Images.SetKeyName(10, "");
            this.ImageList.Images.SetKeyName(11, "");
            // 
            // btPreDate
            // 
            this.btPreDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPreDate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreDate.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btPreDate.ImageIndex = 1;
            this.btPreDate.ImageList = this.ImageList;
            this.btPreDate.Location = new System.Drawing.Point(1207, 5);
            this.btPreDate.Name = "btPreDate";
            this.btPreDate.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btPreDate.Size = new System.Drawing.Size(40, 24);
            this.btPreDate.TabIndex = 5;
            this.btPreDate.Click += new System.EventHandler(this.btPreDate_Click);
            // 
            // btPostDate
            // 
            this.btPostDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPostDate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPostDate.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btPostDate.ImageIndex = 0;
            this.btPostDate.ImageList = this.ImageList;
            this.btPostDate.Location = new System.Drawing.Point(1167, 5);
            this.btPostDate.Name = "btPostDate";
            this.btPostDate.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btPostDate.Size = new System.Drawing.Size(40, 24);
            this.btPostDate.TabIndex = 6;
            this.btPostDate.Click += new System.EventHandler(this.btPostDate_Click);
            // 
            // paBoxPatient
            // 
            this.paBoxPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paBoxPatient.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBoxPatient.Location = new System.Drawing.Point(0, 0);
            this.paBoxPatient.Name = "paBoxPatient";
            this.paBoxPatient.Padding = new System.Windows.Forms.Padding(0, 7, 0, 6);
            this.paBoxPatient.ShowBoxImage = false;
            this.paBoxPatient.Size = new System.Drawing.Size(669, 34);
            this.paBoxPatient.TabIndex = 3;
            this.paBoxPatient.PatientSelected += new System.EventHandler(this.paBoxPatient_PatientSelected);
            // 
            // dwReserList_1
            // 
            this.dwReserList_1.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_1.DataWindowObject = "d_reser_time_list_1";
            this.dwReserList_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_1.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_1.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_1.Name = "dwReserList_1";
            this.dwReserList_1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_1.Size = new System.Drawing.Size(298, 418);
            this.dwReserList_1.TabIndex = 9;
            this.dwReserList_1.Text = "xDataWindow2";
            this.dwReserList_1.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserAMList_RowFocusChanged);
            this.dwReserList_1.Click += new System.EventHandler(this.dwReserList_1_Click);
            // 
            // layReserList
            // 
            this.layReserList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem89,
            this.multiLayoutItem90,
            this.multiLayoutItem91,
            this.multiLayoutItem92,
            this.multiLayoutItem93,
            this.multiLayoutItem94,
            this.multiLayoutItem95,
            this.multiLayoutItem96,
            this.multiLayoutItem105,
            this.multiLayoutItem107,
            this.multiLayoutItem108,
            this.multiLayoutItem109,
            this.multiLayoutItem110,
            this.multiLayoutItem111,
            this.multiLayoutItem112,
            this.multiLayoutItem113,
            this.multiLayoutItem114,
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
            this.multiLayoutItem180,
            this.multiLayoutItem183});
            this.layReserList.QuerySQL = resources.GetString("layReserList.QuerySQL");
            this.layReserList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layReserList_QueryEnd);
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "hangmog_code";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "hangmog_name";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "reser_date";
            this.multiLayoutItem91.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "day_1";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "day_2";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "day_3";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "day_4";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "day_5";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "day_6";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "day_7";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "day_8";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "day_9";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "day_10";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "day_11";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "day_12";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "day_13";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "day_14";
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "day_15";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "day_16";
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "day_17";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "day_18";
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "day_19";
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "day_20";
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "day_21";
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "day_22";
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "day_23";
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "day_24";
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "day_25";
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "day_26";
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "day_27";
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "day_28";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "day_29";
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "day_30";
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "day_31";
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "jundal_table";
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "jundal_part";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "key";
            this.multiLayoutItem134.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "reser_gumsa_yn";
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "gwa_name";
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "reser_time";
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "reser_yn";
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "gwa";
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "doctor";
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "doctor_name";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "time_yn";
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "order_date";
            this.multiLayoutItem143.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "order_remark";
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "emergency";
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "res_1";
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "res_2";
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "res_3";
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "res_4";
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "res_5";
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "res_6";
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "res_7";
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "res_8";
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "res_9";
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "res_10";
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "res_11";
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "res_12";
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "res_13";
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "res_14";
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "res_15";
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "res_16";
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "res_17";
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "res_18";
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "res_19";
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "res_20";
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "res_21";
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "res_22";
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "res_23";
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "res_24";
            // 
            // multiLayoutItem170
            // 
            this.multiLayoutItem170.DataName = "res_25";
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "res_26";
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "res_27";
            // 
            // multiLayoutItem173
            // 
            this.multiLayoutItem173.DataName = "res_28";
            // 
            // multiLayoutItem174
            // 
            this.multiLayoutItem174.DataName = "res_29";
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "res_30";
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "res_31";
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "ocs0103_jundal_part";
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "pkocs";
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "in_out_gubun";
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(1040, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.cboDoctor);
            this.xPanel2.Controls.Add(this.lblDoctor);
            this.xPanel2.Controls.Add(this.cboGwa);
            this.xPanel2.Controls.Add(this.lblGwa);
            this.xPanel2.Controls.Add(this.dtDate);
            this.xPanel2.Controls.Add(this.btPostDate);
            this.xPanel2.Controls.Add(this.btPreDate);
            this.xPanel2.Controls.Add(this.paBoxPatient);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 5);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(1297, 36);
            this.xPanel2.TabIndex = 10;
            // 
            // cboDoctor
            // 
            this.cboDoctor.Location = new System.Drawing.Point(879, 7);
            this.cboDoctor.MaxDropDownItems = 40;
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(119, 21);
            this.cboDoctor.TabIndex = 30;
            // 
            // lblDoctor
            // 
            this.lblDoctor.Location = new System.Drawing.Point(832, 8);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(46, 21);
            this.lblDoctor.TabIndex = 29;
            this.lblDoctor.Text = "依頼医";
            this.lblDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboGwa
            // 
            this.cboGwa.IsAppendAll = true;
            this.cboGwa.Location = new System.Drawing.Point(713, 7);
            this.cboGwa.MaxDropDownItems = 40;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.Size = new System.Drawing.Size(115, 21);
            this.cboGwa.TabIndex = 28;
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // lblGwa
            // 
            this.lblGwa.Location = new System.Drawing.Point(666, 8);
            this.lblGwa.Name = "lblGwa";
            this.lblGwa.Size = new System.Drawing.Size(46, 21);
            this.lblGwa.TabIndex = 27;
            this.lblGwa.Text = "依頼科";
            this.lblGwa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.dtDate.Location = new System.Drawing.Point(1061, 7);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(104, 21);
            this.dtDate.TabIndex = 7;
            this.dtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtDate_DataValidating);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.dwReserList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(5, 41);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel3.Size = new System.Drawing.Size(1297, 207);
            this.xPanel3.TabIndex = 11;
            // 
            // dwReserList
            // 
            this.dwReserList.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList.DataWindowObject = "d_reser_list";
            this.dwReserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList.Location = new System.Drawing.Point(2, 2);
            this.dwReserList.Name = "dwReserList";
            this.dwReserList.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList.Size = new System.Drawing.Size(1291, 201);
            this.dwReserList.TabIndex = 0;
            this.dwReserList.Text = "xDataWindow1";
            this.dwReserList.DoubleClick += new System.EventHandler(this.dwReserList_DoubleClick);
            this.dwReserList.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_RowFocusChanged_1);
            this.dwReserList.ItemChanged += new Sybase.DataWindow.ItemChangedEventHandler(this.dwReserList_ItemChanged);
            this.dwReserList.Click += new System.EventHandler(this.dwReserList_Click);
            // 
            // xPanel4
            // 
            this.xPanel4.AutoScroll = true;
            this.xPanel4.Controls.Add(this.panReser_10);
            this.xPanel4.Controls.Add(this.panReser_9);
            this.xPanel4.Controls.Add(this.panReser_8);
            this.xPanel4.Controls.Add(this.panReser_7);
            this.xPanel4.Controls.Add(this.panReser_6);
            this.xPanel4.Controls.Add(this.panReser_5);
            this.xPanel4.Controls.Add(this.panReser_4);
            this.xPanel4.Controls.Add(this.panReser_3);
            this.xPanel4.Controls.Add(this.panReser_2);
            this.xPanel4.Controls.Add(this.panReser_1);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel4.Location = new System.Drawing.Point(0, 0);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(1297, 487);
            this.xPanel4.TabIndex = 12;
            // 
            // panReser_10
            // 
            this.panReser_10.Controls.Add(this.dwReserList_10);
            this.panReser_10.Controls.Add(this.xPanel15);
            this.panReser_10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_10.DrawBorder = true;
            this.panReser_10.Location = new System.Drawing.Point(2776, 0);
            this.panReser_10.Name = "panReser_10";
            this.panReser_10.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_10.Size = new System.Drawing.Size(312, 470);
            this.panReser_10.TabIndex = 19;
            // 
            // dwReserList_10
            // 
            this.dwReserList_10.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_10.DataWindowObject = "d_reser_time_list_10";
            this.dwReserList_10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_10.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_10.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_10.Name = "dwReserList_10";
            this.dwReserList_10.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_10.Size = new System.Drawing.Size(306, 418);
            this.dwReserList_10.TabIndex = 9;
            this.dwReserList_10.Text = "xDataWindow2";
            this.dwReserList_10.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_10_RowFocusChanged);
            this.dwReserList_10.Click += new System.EventHandler(this.dwReserList_10_Click);
            // 
            // xPanel15
            // 
            this.xPanel15.Controls.Add(this.txtTime_10);
            this.xPanel15.Controls.Add(this.lbHangmogName_10);
            this.xPanel15.Controls.Add(this.lbReserDate_10);
            this.xPanel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel15.Location = new System.Drawing.Point(2, 2);
            this.xPanel15.Name = "xPanel15";
            this.xPanel15.Size = new System.Drawing.Size(306, 46);
            this.xPanel15.TabIndex = 10;
            // 
            // txtTime_10
            // 
            this.txtTime_10.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_10.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_10.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_10.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_10.Location = new System.Drawing.Point(112, 24);
            this.txtTime_10.Mask = "HH:MI";
            this.txtTime_10.Name = "txtTime_10";
            this.txtTime_10.Size = new System.Drawing.Size(56, 16);
            this.txtTime_10.TabIndex = 28;
            this.txtTime_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_10
            // 
            this.lbHangmogName_10.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_10.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_10.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_10.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_10.Name = "lbHangmogName_10";
            this.lbHangmogName_10.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_10.TabIndex = 17;
            // 
            // lbReserDate_10
            // 
            this.lbReserDate_10.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_10.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_10.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_10.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_10.Name = "lbReserDate_10";
            this.lbReserDate_10.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_10.TabIndex = 15;
            this.lbReserDate_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panReser_9
            // 
            this.panReser_9.Controls.Add(this.dwReserList_9);
            this.panReser_9.Controls.Add(this.xPanel9);
            this.panReser_9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_9.DrawBorder = true;
            this.panReser_9.Location = new System.Drawing.Point(2464, 0);
            this.panReser_9.Name = "panReser_9";
            this.panReser_9.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_9.Size = new System.Drawing.Size(312, 470);
            this.panReser_9.TabIndex = 18;
            // 
            // dwReserList_9
            // 
            this.dwReserList_9.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_9.DataWindowObject = "d_reser_time_list_9";
            this.dwReserList_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_9.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_9.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_9.Name = "dwReserList_9";
            this.dwReserList_9.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_9.Size = new System.Drawing.Size(306, 418);
            this.dwReserList_9.TabIndex = 9;
            this.dwReserList_9.Text = "xDataWindow2";
            this.dwReserList_9.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_9_RowFocusChanged);
            this.dwReserList_9.Click += new System.EventHandler(this.dwReserList_9_Click);
            // 
            // xPanel9
            // 
            this.xPanel9.Controls.Add(this.txtTime_9);
            this.xPanel9.Controls.Add(this.lbHangmogName_9);
            this.xPanel9.Controls.Add(this.lbReserDate_9);
            this.xPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel9.Location = new System.Drawing.Point(2, 2);
            this.xPanel9.Name = "xPanel9";
            this.xPanel9.Size = new System.Drawing.Size(306, 46);
            this.xPanel9.TabIndex = 10;
            // 
            // txtTime_9
            // 
            this.txtTime_9.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_9.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_9.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_9.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_9.Location = new System.Drawing.Point(112, 24);
            this.txtTime_9.Mask = "HH:MI";
            this.txtTime_9.Name = "txtTime_9";
            this.txtTime_9.Size = new System.Drawing.Size(56, 16);
            this.txtTime_9.TabIndex = 28;
            this.txtTime_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_9
            // 
            this.lbHangmogName_9.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_9.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_9.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_9.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_9.Name = "lbHangmogName_9";
            this.lbHangmogName_9.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_9.TabIndex = 17;
            // 
            // lbReserDate_9
            // 
            this.lbReserDate_9.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_9.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_9.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_9.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_9.Name = "lbReserDate_9";
            this.lbReserDate_9.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_9.TabIndex = 15;
            this.lbReserDate_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panReser_8
            // 
            this.panReser_8.Controls.Add(this.dwReserList_8);
            this.panReser_8.Controls.Add(this.xPanel11);
            this.panReser_8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_8.DrawBorder = true;
            this.panReser_8.Location = new System.Drawing.Point(2152, 0);
            this.panReser_8.Name = "panReser_8";
            this.panReser_8.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_8.Size = new System.Drawing.Size(312, 470);
            this.panReser_8.TabIndex = 17;
            // 
            // dwReserList_8
            // 
            this.dwReserList_8.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_8.DataWindowObject = "d_reser_time_list_8";
            this.dwReserList_8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_8.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_8.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_8.Name = "dwReserList_8";
            this.dwReserList_8.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_8.Size = new System.Drawing.Size(306, 418);
            this.dwReserList_8.TabIndex = 9;
            this.dwReserList_8.Text = "xDataWindow2";
            this.dwReserList_8.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_8_RowFocusChanged);
            this.dwReserList_8.Click += new System.EventHandler(this.dwReserList_8_Click);
            // 
            // xPanel11
            // 
            this.xPanel11.Controls.Add(this.txtTime_8);
            this.xPanel11.Controls.Add(this.lbHangmogName_8);
            this.xPanel11.Controls.Add(this.lbReserDate_8);
            this.xPanel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel11.Location = new System.Drawing.Point(2, 2);
            this.xPanel11.Name = "xPanel11";
            this.xPanel11.Size = new System.Drawing.Size(306, 46);
            this.xPanel11.TabIndex = 10;
            // 
            // txtTime_8
            // 
            this.txtTime_8.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_8.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_8.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_8.Location = new System.Drawing.Point(112, 24);
            this.txtTime_8.Mask = "HH:MI";
            this.txtTime_8.Name = "txtTime_8";
            this.txtTime_8.Size = new System.Drawing.Size(56, 16);
            this.txtTime_8.TabIndex = 28;
            this.txtTime_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_8
            // 
            this.lbHangmogName_8.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_8.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_8.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_8.Name = "lbHangmogName_8";
            this.lbHangmogName_8.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_8.TabIndex = 17;
            // 
            // lbReserDate_8
            // 
            this.lbReserDate_8.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_8.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_8.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_8.Name = "lbReserDate_8";
            this.lbReserDate_8.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_8.TabIndex = 15;
            this.lbReserDate_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panReser_7
            // 
            this.panReser_7.Controls.Add(this.dwReserList_7);
            this.panReser_7.Controls.Add(this.xPanel7);
            this.panReser_7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_7.DrawBorder = true;
            this.panReser_7.Location = new System.Drawing.Point(1840, 0);
            this.panReser_7.Name = "panReser_7";
            this.panReser_7.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_7.Size = new System.Drawing.Size(312, 470);
            this.panReser_7.TabIndex = 16;
            // 
            // dwReserList_7
            // 
            this.dwReserList_7.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_7.DataWindowObject = "d_reser_time_list_7";
            this.dwReserList_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_7.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_7.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_7.Name = "dwReserList_7";
            this.dwReserList_7.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_7.Size = new System.Drawing.Size(306, 418);
            this.dwReserList_7.TabIndex = 9;
            this.dwReserList_7.Text = "xDataWindow2";
            this.dwReserList_7.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_7_RowFocusChanged);
            this.dwReserList_7.Click += new System.EventHandler(this.dwReserList_7_Click);
            // 
            // xPanel7
            // 
            this.xPanel7.Controls.Add(this.txtTime_7);
            this.xPanel7.Controls.Add(this.lbHangmogName_7);
            this.xPanel7.Controls.Add(this.lbReserDate_7);
            this.xPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel7.Location = new System.Drawing.Point(2, 2);
            this.xPanel7.Name = "xPanel7";
            this.xPanel7.Size = new System.Drawing.Size(306, 46);
            this.xPanel7.TabIndex = 10;
            // 
            // txtTime_7
            // 
            this.txtTime_7.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_7.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_7.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_7.Location = new System.Drawing.Point(112, 24);
            this.txtTime_7.Mask = "HH:MI";
            this.txtTime_7.Name = "txtTime_7";
            this.txtTime_7.Size = new System.Drawing.Size(56, 16);
            this.txtTime_7.TabIndex = 28;
            this.txtTime_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_7
            // 
            this.lbHangmogName_7.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_7.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_7.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_7.Name = "lbHangmogName_7";
            this.lbHangmogName_7.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_7.TabIndex = 17;
            // 
            // lbReserDate_7
            // 
            this.lbReserDate_7.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_7.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_7.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_7.Name = "lbReserDate_7";
            this.lbReserDate_7.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_7.TabIndex = 15;
            this.lbReserDate_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panReser_6
            // 
            this.panReser_6.Controls.Add(this.dwReserList_6);
            this.panReser_6.Controls.Add(this.xPanel16);
            this.panReser_6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_6.DrawBorder = true;
            this.panReser_6.Location = new System.Drawing.Point(1528, 0);
            this.panReser_6.Name = "panReser_6";
            this.panReser_6.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_6.Size = new System.Drawing.Size(312, 470);
            this.panReser_6.TabIndex = 15;
            // 
            // dwReserList_6
            // 
            this.dwReserList_6.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_6.DataWindowObject = "d_reser_time_list_6";
            this.dwReserList_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_6.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_6.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_6.Name = "dwReserList_6";
            this.dwReserList_6.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_6.Size = new System.Drawing.Size(306, 418);
            this.dwReserList_6.TabIndex = 9;
            this.dwReserList_6.Text = "xDataWindow2";
            this.dwReserList_6.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_6_RowFocusChanged);
            this.dwReserList_6.Click += new System.EventHandler(this.dwReserList_6_Click);
            // 
            // xPanel16
            // 
            this.xPanel16.Controls.Add(this.txtTime_6);
            this.xPanel16.Controls.Add(this.lbHangmogName_6);
            this.xPanel16.Controls.Add(this.lbReserDate_6);
            this.xPanel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel16.Location = new System.Drawing.Point(2, 2);
            this.xPanel16.Name = "xPanel16";
            this.xPanel16.Size = new System.Drawing.Size(306, 46);
            this.xPanel16.TabIndex = 10;
            // 
            // txtTime_6
            // 
            this.txtTime_6.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_6.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_6.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_6.Location = new System.Drawing.Point(112, 24);
            this.txtTime_6.Mask = "HH:MI";
            this.txtTime_6.Name = "txtTime_6";
            this.txtTime_6.Size = new System.Drawing.Size(56, 16);
            this.txtTime_6.TabIndex = 28;
            this.txtTime_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_6
            // 
            this.lbHangmogName_6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_6.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_6.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_6.Name = "lbHangmogName_6";
            this.lbHangmogName_6.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_6.TabIndex = 17;
            // 
            // lbReserDate_6
            // 
            this.lbReserDate_6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_6.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_6.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_6.Name = "lbReserDate_6";
            this.lbReserDate_6.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_6.TabIndex = 15;
            this.lbReserDate_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panReser_5
            // 
            this.panReser_5.Controls.Add(this.dwReserList_5);
            this.panReser_5.Controls.Add(this.xPanel14);
            this.panReser_5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_5.DrawBorder = true;
            this.panReser_5.Location = new System.Drawing.Point(1216, 0);
            this.panReser_5.Name = "panReser_5";
            this.panReser_5.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_5.Size = new System.Drawing.Size(312, 470);
            this.panReser_5.TabIndex = 14;
            // 
            // dwReserList_5
            // 
            this.dwReserList_5.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_5.DataWindowObject = "d_reser_time_list_5";
            this.dwReserList_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_5.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_5.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_5.Name = "dwReserList_5";
            this.dwReserList_5.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_5.Size = new System.Drawing.Size(306, 418);
            this.dwReserList_5.TabIndex = 9;
            this.dwReserList_5.Text = "xDataWindow2";
            this.dwReserList_5.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_5_RowFocusChanged);
            this.dwReserList_5.Click += new System.EventHandler(this.dwReserList_5_Click);
            // 
            // xPanel14
            // 
            this.xPanel14.Controls.Add(this.txtTime_5);
            this.xPanel14.Controls.Add(this.lbHangmogName_5);
            this.xPanel14.Controls.Add(this.lbReserDate_5);
            this.xPanel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel14.Location = new System.Drawing.Point(2, 2);
            this.xPanel14.Name = "xPanel14";
            this.xPanel14.Size = new System.Drawing.Size(306, 46);
            this.xPanel14.TabIndex = 10;
            // 
            // txtTime_5
            // 
            this.txtTime_5.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_5.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_5.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_5.Location = new System.Drawing.Point(112, 24);
            this.txtTime_5.Mask = "HH:MI";
            this.txtTime_5.Name = "txtTime_5";
            this.txtTime_5.Size = new System.Drawing.Size(56, 16);
            this.txtTime_5.TabIndex = 28;
            this.txtTime_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_5
            // 
            this.lbHangmogName_5.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_5.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_5.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_5.Name = "lbHangmogName_5";
            this.lbHangmogName_5.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_5.TabIndex = 17;
            // 
            // lbReserDate_5
            // 
            this.lbReserDate_5.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_5.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_5.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_5.Name = "lbReserDate_5";
            this.lbReserDate_5.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_5.TabIndex = 15;
            this.lbReserDate_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panReser_4
            // 
            this.panReser_4.Controls.Add(this.dwReserList_4);
            this.panReser_4.Controls.Add(this.xPanel12);
            this.panReser_4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_4.DrawBorder = true;
            this.panReser_4.Location = new System.Drawing.Point(912, 0);
            this.panReser_4.Name = "panReser_4";
            this.panReser_4.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_4.Size = new System.Drawing.Size(304, 470);
            this.panReser_4.TabIndex = 13;
            // 
            // dwReserList_4
            // 
            this.dwReserList_4.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_4.DataWindowObject = "d_reser_time_list_4";
            this.dwReserList_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_4.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_4.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_4.Name = "dwReserList_4";
            this.dwReserList_4.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_4.Size = new System.Drawing.Size(298, 418);
            this.dwReserList_4.TabIndex = 9;
            this.dwReserList_4.Text = "xDataWindow2";
            this.dwReserList_4.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_4_RowFocusChanged);
            this.dwReserList_4.Click += new System.EventHandler(this.dwReserList_4_Click);
            // 
            // xPanel12
            // 
            this.xPanel12.Controls.Add(this.txtTime_4);
            this.xPanel12.Controls.Add(this.lbHangmogName_4);
            this.xPanel12.Controls.Add(this.lbReserDate_4);
            this.xPanel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel12.Location = new System.Drawing.Point(2, 2);
            this.xPanel12.Name = "xPanel12";
            this.xPanel12.Size = new System.Drawing.Size(298, 46);
            this.xPanel12.TabIndex = 10;
            // 
            // txtTime_4
            // 
            this.txtTime_4.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_4.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_4.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_4.Location = new System.Drawing.Point(112, 24);
            this.txtTime_4.Mask = "HH:MI";
            this.txtTime_4.Name = "txtTime_4";
            this.txtTime_4.Size = new System.Drawing.Size(56, 16);
            this.txtTime_4.TabIndex = 28;
            this.txtTime_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_4
            // 
            this.lbHangmogName_4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_4.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_4.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_4.Name = "lbHangmogName_4";
            this.lbHangmogName_4.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_4.TabIndex = 17;
            // 
            // lbReserDate_4
            // 
            this.lbReserDate_4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_4.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_4.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_4.Name = "lbReserDate_4";
            this.lbReserDate_4.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_4.TabIndex = 15;
            this.lbReserDate_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panReser_3
            // 
            this.panReser_3.Controls.Add(this.dwReserList_3);
            this.panReser_3.Controls.Add(this.xPanel10);
            this.panReser_3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_3.DrawBorder = true;
            this.panReser_3.Location = new System.Drawing.Point(608, 0);
            this.panReser_3.Name = "panReser_3";
            this.panReser_3.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_3.Size = new System.Drawing.Size(304, 470);
            this.panReser_3.TabIndex = 12;
            // 
            // dwReserList_3
            // 
            this.dwReserList_3.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_3.DataWindowObject = "d_reser_time_list_3";
            this.dwReserList_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_3.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_3.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_3.Name = "dwReserList_3";
            this.dwReserList_3.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_3.Size = new System.Drawing.Size(298, 418);
            this.dwReserList_3.TabIndex = 9;
            this.dwReserList_3.Text = "xDataWindow2";
            this.dwReserList_3.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_3_RowFocusChanged);
            this.dwReserList_3.Click += new System.EventHandler(this.dwReserList_3_Click);
            // 
            // xPanel10
            // 
            this.xPanel10.Controls.Add(this.txtTime_3);
            this.xPanel10.Controls.Add(this.lbHangmogName_3);
            this.xPanel10.Controls.Add(this.lbReserDate_3);
            this.xPanel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel10.Location = new System.Drawing.Point(2, 2);
            this.xPanel10.Name = "xPanel10";
            this.xPanel10.Size = new System.Drawing.Size(298, 46);
            this.xPanel10.TabIndex = 10;
            // 
            // txtTime_3
            // 
            this.txtTime_3.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_3.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_3.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_3.Location = new System.Drawing.Point(112, 24);
            this.txtTime_3.Mask = "HH:MI";
            this.txtTime_3.Name = "txtTime_3";
            this.txtTime_3.Size = new System.Drawing.Size(56, 16);
            this.txtTime_3.TabIndex = 28;
            this.txtTime_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_3
            // 
            this.lbHangmogName_3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_3.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_3.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_3.Name = "lbHangmogName_3";
            this.lbHangmogName_3.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_3.TabIndex = 17;
            // 
            // lbReserDate_3
            // 
            this.lbReserDate_3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_3.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_3.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_3.Name = "lbReserDate_3";
            this.lbReserDate_3.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_3.TabIndex = 15;
            this.lbReserDate_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panReser_2
            // 
            this.panReser_2.Controls.Add(this.dwReserList_2);
            this.panReser_2.Controls.Add(this.xPanel8);
            this.panReser_2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_2.DrawBorder = true;
            this.panReser_2.Location = new System.Drawing.Point(304, 0);
            this.panReser_2.Name = "panReser_2";
            this.panReser_2.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_2.Size = new System.Drawing.Size(304, 470);
            this.panReser_2.TabIndex = 11;
            // 
            // dwReserList_2
            // 
            this.dwReserList_2.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList_2.DataWindowObject = "d_reser_time_list_2";
            this.dwReserList_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList_2.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserList_2.Location = new System.Drawing.Point(2, 48);
            this.dwReserList_2.Name = "dwReserList_2";
            this.dwReserList_2.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList_2.Size = new System.Drawing.Size(298, 418);
            this.dwReserList_2.TabIndex = 9;
            this.dwReserList_2.Text = "xDataWindow2";
            this.dwReserList_2.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_2_RowFocusChanged);
            this.dwReserList_2.Click += new System.EventHandler(this.dwReserList_2_Click);
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.txtTime_2);
            this.xPanel8.Controls.Add(this.lbHangmogName_2);
            this.xPanel8.Controls.Add(this.lbReserDate_2);
            this.xPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel8.Location = new System.Drawing.Point(2, 2);
            this.xPanel8.Name = "xPanel8";
            this.xPanel8.Size = new System.Drawing.Size(298, 46);
            this.xPanel8.TabIndex = 10;
            // 
            // txtTime_2
            // 
            this.txtTime_2.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_2.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_2.Location = new System.Drawing.Point(112, 24);
            this.txtTime_2.Mask = "HH:MI";
            this.txtTime_2.Name = "txtTime_2";
            this.txtTime_2.Size = new System.Drawing.Size(56, 16);
            this.txtTime_2.TabIndex = 26;
            this.txtTime_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_2
            // 
            this.lbHangmogName_2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_2.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_2.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_2.Name = "lbHangmogName_2";
            this.lbHangmogName_2.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_2.TabIndex = 17;
            // 
            // lbReserDate_2
            // 
            this.lbReserDate_2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_2.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_2.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_2.Name = "lbReserDate_2";
            this.lbReserDate_2.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_2.TabIndex = 15;
            this.lbReserDate_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panReser_1
            // 
            this.panReser_1.Controls.Add(this.dwReserList_1);
            this.panReser_1.Controls.Add(this.xPanel6);
            this.panReser_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panReser_1.DrawBorder = true;
            this.panReser_1.Location = new System.Drawing.Point(0, 0);
            this.panReser_1.Name = "panReser_1";
            this.panReser_1.Padding = new System.Windows.Forms.Padding(2);
            this.panReser_1.Size = new System.Drawing.Size(304, 470);
            this.panReser_1.TabIndex = 10;
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.txtTime_1);
            this.xPanel6.Controls.Add(this.lbHangmogName_1);
            this.xPanel6.Controls.Add(this.lbReserDate_1);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel6.Location = new System.Drawing.Point(2, 2);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(298, 46);
            this.xPanel6.TabIndex = 10;
            // 
            // txtTime_1
            // 
            this.txtTime_1.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.txtTime_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime_1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtTime_1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime_1.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.txtTime_1.Location = new System.Drawing.Point(112, 24);
            this.txtTime_1.Mask = "HH:MI";
            this.txtTime_1.Name = "txtTime_1";
            this.txtTime_1.Size = new System.Drawing.Size(56, 16);
            this.txtTime_1.TabIndex = 24;
            this.txtTime_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbHangmogName_1
            // 
            this.lbHangmogName_1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName_1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName_1.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbHangmogName_1.Location = new System.Drawing.Point(1, 1);
            this.lbHangmogName_1.Name = "lbHangmogName_1";
            this.lbHangmogName_1.Size = new System.Drawing.Size(343, 23);
            this.lbHangmogName_1.TabIndex = 17;
            // 
            // lbReserDate_1
            // 
            this.lbReserDate_1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate_1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate_1.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.lbReserDate_1.Location = new System.Drawing.Point(1, 22);
            this.lbReserDate_1.Name = "lbReserDate_1";
            this.lbReserDate_1.Size = new System.Drawing.Size(111, 19);
            this.lbReserDate_1.TabIndex = 15;
            this.lbReserDate_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.cbxIF_YN);
            this.xPanel5.Controls.Add(this.btnResend);
            this.xPanel5.Controls.Add(this.btnReserOrder);
            this.xPanel5.Controls.Add(this.xdtReserDate);
            this.xPanel5.Controls.Add(this.btnReserList);
            this.xPanel5.Controls.Add(this.btnComment);
            this.xPanel5.Controls.Add(this.xLabel1);
            this.xPanel5.Controls.Add(this.xemPrintCnt);
            this.xPanel5.Controls.Add(this.btnReserPrint);
            this.xPanel5.Controls.Add(this.dwReserPrint);
            this.xPanel5.Controls.Add(this.btnCancel);
            this.xPanel5.Controls.Add(this.btnSave);
            this.xPanel5.Controls.Add(this.xButtonList1);
            this.xPanel5.Controls.Add(this.grdReserDate);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Location = new System.Drawing.Point(5, 739);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel5.Size = new System.Drawing.Size(1297, 36);
            this.xPanel5.TabIndex = 13;
            // 
            // cbxIF_YN
            // 
            this.cbxIF_YN.AutoSize = true;
            this.cbxIF_YN.Location = new System.Drawing.Point(525, 8);
            this.cbxIF_YN.Name = "cbxIF_YN";
            this.cbxIF_YN.Size = new System.Drawing.Size(67, 17);
            this.cbxIF_YN.TabIndex = 30;
            this.cbxIF_YN.Text = "MX転送";
            this.cbxIF_YN.UseVisualStyleBackColor = false;
            // 
            // btnResend
            // 
            this.btnResend.ImageIndex = 11;
            this.btnResend.ImageList = this.ImageList;
            this.btnResend.Location = new System.Drawing.Point(420, 3);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(100, 28);
            this.btnResend.TabIndex = 29;
            this.btnResend.Text = "MX再転送";
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // btnReserOrder
            // 
            this.btnReserOrder.ImageIndex = 10;
            this.btnReserOrder.ImageList = this.ImageList;
            this.btnReserOrder.Location = new System.Drawing.Point(320, 3);
            this.btnReserOrder.Name = "btnReserOrder";
            this.btnReserOrder.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReserOrder.Size = new System.Drawing.Size(100, 28);
            this.btnReserOrder.TabIndex = 28;
            this.btnReserOrder.Text = "予約順番";
            this.btnReserOrder.Click += new System.EventHandler(this.xButton1_Click_1);
            // 
            // xdtReserDate
            // 
            this.xdtReserDate.Location = new System.Drawing.Point(606, 5);
            this.xdtReserDate.Name = "xdtReserDate";
            this.xdtReserDate.Size = new System.Drawing.Size(104, 20);
            this.xdtReserDate.TabIndex = 20;
            this.xdtReserDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.xdtReserDate.Visible = false;
            // 
            // btnReserList
            // 
            this.btnReserList.ImageIndex = 6;
            this.btnReserList.ImageList = this.ImageList;
            this.btnReserList.Location = new System.Drawing.Point(110, 3);
            this.btnReserList.Name = "btnReserList";
            this.btnReserList.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReserList.Size = new System.Drawing.Size(110, 28);
            this.btnReserList.TabIndex = 24;
            this.btnReserList.Text = "予約詳細内訳";
            this.btnReserList.Click += new System.EventHandler(this.btnReserList_Click);
            // 
            // btnComment
            // 
            this.btnComment.ImageIndex = 5;
            this.btnComment.ImageList = this.ImageList;
            this.btnComment.Location = new System.Drawing.Point(220, 3);
            this.btnComment.Name = "btnComment";
            this.btnComment.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnComment.Size = new System.Drawing.Size(100, 28);
            this.btnComment.TabIndex = 23;
            this.btnComment.Text = "予約コメント";
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // xLabel1
            // 
            this.xLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.Location = new System.Drawing.Point(834, 11);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(62, 16);
            this.xLabel1.TabIndex = 22;
            this.xLabel1.Text = "印刷部数";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xemPrintCnt
            // 
            this.xemPrintCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xemPrintCnt.EditMaskType = IHIS.Framework.MaskType.Number;
            this.xemPrintCnt.Location = new System.Drawing.Point(898, 8);
            this.xemPrintCnt.Name = "xemPrintCnt";
            this.xemPrintCnt.Size = new System.Drawing.Size(38, 20);
            this.xemPrintCnt.TabIndex = 21;
            this.xemPrintCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReserPrint
            // 
            this.btnReserPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReserPrint.ImageIndex = 4;
            this.btnReserPrint.ImageList = this.ImageList;
            this.btnReserPrint.Location = new System.Drawing.Point(944, 3);
            this.btnReserPrint.Name = "btnReserPrint";
            this.btnReserPrint.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReserPrint.Size = new System.Drawing.Size(96, 28);
            this.btnReserPrint.TabIndex = 18;
            this.btnReserPrint.Text = "予約票";
            this.btnReserPrint.Click += new System.EventHandler(this.btnReserPrint_Click);
            // 
            // dwReserPrint
            // 
            this.dwReserPrint.DataWindowObject = "d_reser_print";
            this.dwReserPrint.LibraryList = "..\\SCHS\\schs.sch0201u00.pbd";
            this.dwReserPrint.Location = new System.Drawing.Point(136, 44);
            this.dwReserPrint.Name = "dwReserPrint";
            this.dwReserPrint.Size = new System.Drawing.Size(136, 150);
            this.dwReserPrint.TabIndex = 17;
            this.dwReserPrint.Text = "xDataWindow1";
            this.dwReserPrint.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageIndex = 3;
            this.btnCancel.ImageList = this.ImageList;
            this.btnCancel.Location = new System.Drawing.Point(2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCancel.Size = new System.Drawing.Size(108, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "予約取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.ImageList;
            this.btnSave.Location = new System.Drawing.Point(1122, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "予約";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdReserDate
            // 
            this.grdReserDate.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1});
            this.grdReserDate.ColPerLine = 1;
            this.grdReserDate.Cols = 1;
            this.grdReserDate.FixedRows = 1;
            this.grdReserDate.HeaderHeights.Add(19);
            this.grdReserDate.Location = new System.Drawing.Point(640, 5);
            this.grdReserDate.Name = "grdReserDate";
            this.grdReserDate.Rows = 2;
            this.grdReserDate.Size = new System.Drawing.Size(164, 325);
            this.grdReserDate.TabIndex = 19;
            this.grdReserDate.Visible = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "reser_date";
            this.xEditGridCell1.CellWidth = 113;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(5, 248);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1297, 4);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // layHoliYN
            // 
            this.layHoliYN.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2});
            this.layHoliYN.QuerySQL = "SELECT DECODE(A.HOLIDAY_YN,\'N\',\'N\',\'Y\')\r\n     , A.YOIL_GUBUN\r\n  FROM RES0101 A\r\n " +
                "WHERE A.HOLI_DAY     = to_date(:f_date,\'yyyymmdd\')";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "holi_yn";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "yoil_gubun";
            // 
            // layTimeList
            // 
            this.layTimeList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem106});
            this.layTimeList.QuerySQL = resources.GetString("layTimeList.QuerySQL");
            this.layTimeList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTimeList_QueryStarting);
            this.layTimeList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layTimeList_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "reser_date";
            this.multiLayoutItem1.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "reser_time";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "bunho";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "suname";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "hangmog_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "hangmog_name";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "gwa";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "doctor_name";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "act_yn";
            // 
            // xPanel1
            // 
            this.xPanel1.AutoScroll = true;
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(5, 252);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1297, 487);
            this.xPanel1.TabIndex = 15;
            // 
            // layAddInwonChk
            // 
            this.layAddInwonChk.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem5});
            this.layAddInwonChk.QuerySQL = resources.GetString("layAddInwonChk.QuerySQL");
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "reser_chk";
            // 
            // layLoginGwa
            // 
            this.layLoginGwa.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem3});
            this.layLoginGwa.QuerySQL = "SELECT CODE2\r\n  FROM SCH0109\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE =" +
                " \'LOGIN_GWA\'\r\n   AND CODE      = :f_user_id\r\n";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "gwa";
            // 
            // layDoctorList
            // 
            this.layDoctorList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem11,
            this.multiLayoutItem12});
            this.layDoctorList.QuerySQL = resources.GetString("layDoctorList.QuerySQL");
            this.layDoctorList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDoctorList_QueryStarting);
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "doctor";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "doctor_name";
            // 
            // layJubsuChk
            // 
            this.layJubsuChk.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem9});
            this.layJubsuChk.QuerySQL = resources.GetString("layJubsuChk.QuerySQL");
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "jubsu_chk";
            // 
            // layReserTimeChk
            // 
            this.layReserTimeChk.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4});
            this.layReserTimeChk.QuerySQL = resources.GetString("layReserTimeChk.QuerySQL");
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "reser_chk";
            // 
            // layLoadRES0101
            // 
            this.layLoadRES0101.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17});
            this.layLoadRES0101.QuerySQL = resources.GetString("layLoadRES0101.QuerySQL");
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "holi_day";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "last_day";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "yoil_gubun";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "day";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "day_gubun";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "cnt";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "res";
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "in_out_gubun";
            // 
            // layTimeReserYn
            // 
            this.layTimeReserYn.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem6});
            this.layTimeReserYn.QuerySQL = "SELECT FN_SCH_TIME_RESER_YN(:f_hangmog_code, :f_reser_date) TIME_RESER_YN FROM DU" +
                "AL";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "time_reser_yn";
            // 
            // SCH0201U00
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Name = "SCH0201U00";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1307, 780);
            this.Enter += new System.EventHandler(this.SCH0201U00_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.paBoxPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.panReser_10.ResumeLayout(false);
            this.xPanel15.ResumeLayout(false);
            this.xPanel15.PerformLayout();
            this.panReser_9.ResumeLayout(false);
            this.xPanel9.ResumeLayout(false);
            this.xPanel9.PerformLayout();
            this.panReser_8.ResumeLayout(false);
            this.xPanel11.ResumeLayout(false);
            this.xPanel11.PerformLayout();
            this.panReser_7.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            this.xPanel7.PerformLayout();
            this.panReser_6.ResumeLayout(false);
            this.xPanel16.ResumeLayout(false);
            this.xPanel16.PerformLayout();
            this.panReser_5.ResumeLayout(false);
            this.xPanel14.ResumeLayout(false);
            this.xPanel14.PerformLayout();
            this.panReser_4.ResumeLayout(false);
            this.xPanel12.ResumeLayout(false);
            this.xPanel12.PerformLayout();
            this.panReser_3.ResumeLayout(false);
            this.xPanel10.ResumeLayout(false);
            this.xPanel10.PerformLayout();
            this.panReser_2.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            this.xPanel8.PerformLayout();
            this.panReser_1.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            this.xPanel6.PerformLayout();
            this.xPanel5.ResumeLayout(false);
            this.xPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReserDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layDoctorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLoadRES0101)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 의사콤보박스 셋팅
		private void SetDoctorList()
		{
			if (this.cboGwa.GetDataValue().ToString() == "") return;

			if (this.layDoctorList.QueryLayout(true))
			{
				this.cboDoctor.SetComboItems(this.layDoctorList.LayoutTable, "doctor_name", "doctor");
                this.cboDoctor.SelectedIndex = 0;
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}
		}
		#endregion

		#region 의뢰과를 변경을 했을 때 의사콤보박스를 다시 조회
		private void cboGwa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetDoctorList();
		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);


            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //this.ParentForm.Size = new System.Drawing.Size(rc.Width - 45, rc.Height - 130);
            this.ParentForm.Size = new System.Drawing.Size(this.Width, rc.Height - 105);

			dw_1 = false;
			dw_2 = false;
			dw_3 = false;
			dw_4 = false;
			dw_5 = false;
	
			if (EnvironInfo.CurrSystemID == "OCSI" || EnvironInfo.CurrSystemID == "OCSO")
			{
				if (EnvironInfo.CurrSystemID == "OCSO")
				{
					//외래오다화면에서 연 경우에는 CALL한 과와 의사로 셋팅을 한다.
					this.cboGwa.SetEditValue(UserInfo.Gwa.ToString());
					this.cboGwa.AcceptData();

					//의뢰의 콤보리스트 셋팅 후 로그인의사로 셋팅
					SetDoctorList();
					
					this.cboDoctor.SetEditValue(UserInfo.UserID.ToString());
					this.cboDoctor.AcceptData();
				}
				else
				{
					//입원오다화면에서 연 경우에는 의뢰과와 의뢰의사를 전체로 셋팅을 한다.
					this.cboGwa.SetEditValue("%");
					this.cboGwa.AcceptData();
			
					//의뢰의 콤보리스트 셋팅
					SetDoctorList();

					this.cboDoctor.SetEditValue("%");
					this.cboDoctor.AcceptData();
				}
			}
			else
			{
				cboGwa.SetEditValue("%");
				cboGwa.AcceptData();
				
				//의뢰의 콤보리스트 셋팅
				SetDoctorList();
				
				cboDoctor.SetEditValue("%");
				cboDoctor.AcceptData();
			}

			dtDate.SetDataValue(DateTime.Now);
			xemPrintCnt.SetDataValue(1);

			if (this.OpenParam != null ) 
			{
				this.paBoxPatient.SetPatientID(this.OpenParam["bunho"].ToString());
				in_out_gubun = this.OpenParam["in_out_gubun"].ToString();
				doctor       = this.OpenParam["doctor"].ToString();
				hangmog_code = this.OpenParam["hangmog_code"].ToString();

				this.ReserQuery();
				return;
			}
			else
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
					this.paBoxPatient.SetPatientID(patientInfo.BunHo);
					in_out_gubun = "O";
					doctor       = "%";

					this.ReserQuery();
					return;
				}
				else
				{
					//paBox.SetPatientID("000400017");
				}
			}
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
                this.paBoxPatient.Focus();
                this.paBoxPatient.SetPatientID(info.BunHo);
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBoxPatient.BunHo.ToString()))
            {
                return new XPatientInfo(this.paBoxPatient.BunHo.ToString(), "", "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

		#region dwGetString
		private string dwGetString(XDataWindow dw, int row, string colNm)
		{
			if(!dw.IsItemNull(row,colNm))
				return dw.GetItemString(row, colNm);
            //return " ";
            return "";
		}
		#endregion

		#region Patient Reser Query 환자 예약조회

        #region 주석
        //private void PatientReserQuery()
//        {
//            this.layReserList.QuerySQL = @"SELECT DECODE(A.JUNDAL_PART, 'CPL', 'CPL', A.HANGMOG_CODE)                                   HANGMOG_CODE
//                                              ,DECODE(A.JUNDAL_PART,'CPL',C.JUNDAL_PART_NAME, B.HANGMOG_NAME) ||                      
//                                               DECODE(NVL(A.JUSA_RESER_YN,'N'),'Y','('||FN_ADM_MSG(4108)||')','')                    HANGMOG_NAME
//                                              ,TO_CHAR(NVL(A.RESER_DATE,A.HOPE_DATE),'YYYY/MM/DD')                                   RESER_DATE
//                                              ,A.RESER_TIME                                                                          RESER_TIME
//                                              ,A.JUNDAL_TABLE                                                                        JUNDAL_TABLE
//                                              ,A.JUNDAL_PART                                                                         JUNDAL_PART
//                                              ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                             GWA_NAME
//                                              ,A.GWA                                                                                 GWA
//                                              ,A.DOCTOR                                                                              DOCTOR
//                                              ,DECODE(NVL(A.EMERGENCY,'N'),'Y','N',DECODE(B.HANGMOG_CODE, NULL, 'N', 'Y'))           TIME_YN
//                                              ,MIN(A.PKSCH0201)                                                                      KEY
//                                              ,DECODE(A.JUNDAL_PART,'CPL','Y',DECODE(D.HANGMOG_CODE, NULL, 'N', 'Y'))                RESER_GUMSA_YN
//                                              ,DECODE(A.RESER_DATE, NULL, 'N', 'Y')                                                  RESER_YN
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 0  ,'YYYYMMDD'), 'R','')   DATE_1
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 1  ,'YYYYMMDD'), 'R','')   DATE_2
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 2  ,'YYYYMMDD'), 'R','')   DATE_3
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 3  ,'YYYYMMDD'), 'R','')   DATE_4
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 4  ,'YYYYMMDD'), 'R','')   DATE_5
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 5  ,'YYYYMMDD'), 'R','')   DATE_6
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 6  ,'YYYYMMDD'), 'R','')   DATE_7
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 7  ,'YYYYMMDD'), 'R','')   DATE_8
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 8  ,'YYYYMMDD'), 'R','')   DATE_9
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 9  ,'YYYYMMDD'), 'R','')   DATE_10
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 10 ,'YYYYMMDD'), 'R','')   DATE_11
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 11 ,'YYYYMMDD'), 'R','')   DATE_12
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 12 ,'YYYYMMDD'), 'R','')   DATE_13
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 13 ,'YYYYMMDD'), 'R','')   DATE_14
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 14 ,'YYYYMMDD'), 'R','')   DATE_15
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 15 ,'YYYYMMDD'), 'R','')   DATE_16
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 16 ,'YYYYMMDD'), 'R','')   DATE_17
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 17 ,'YYYYMMDD'), 'R','')   DATE_18
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 18 ,'YYYYMMDD'), 'R','')   DATE_19
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 19 ,'YYYYMMDD'), 'R','')   DATE_20
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 20 ,'YYYYMMDD'), 'R','')   DATE_21
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 21 ,'YYYYMMDD'), 'R','')   DATE_22
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 22 ,'YYYYMMDD'), 'R','')   DATE_23
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 23 ,'YYYYMMDD'), 'R','')   DATE_24
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 24 ,'YYYYMMDD'), 'R','')   DATE_25
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 25 ,'YYYYMMDD'), 'R','')   DATE_26
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 26 ,'YYYYMMDD'), 'R','')   DATE_27
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 27 ,'YYYYMMDD'), 'R','')   DATE_28
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 28 ,'YYYYMMDD'), 'R','')   DATE_29
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 29 ,'YYYYMMDD'), 'R','')   DATE_30
//                                              ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 30 ,'YYYYMMDD'), 'R','')   DATE_31
//                                              ,A.ORDER_DATE                                                                                                      ORDER_DATE
//                                              ,FN_SCH_ORDER_REMARK(A.IN_OUT_GUBUN,A.FKOCS)                                                                       ORDER_REMARK
//                                              ,DECODE(NVL(A.EMERGENCY,'N'), 'N', A.IN_OUT_GUBUN, NVL(A.EMERGENCY,'N'))                                           EMERGENCY
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 0, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_1
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 1, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_2
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 2, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_3
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 3, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_4
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 4, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_5
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 5, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_6
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 6, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_7
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 7, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_8
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 8, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_9
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 9, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_10
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 10, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_11
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 11, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_12
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 12, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_13
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 13, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_14
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 14, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_15
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 15, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_16
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 16, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_17
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 17, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_18
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 18, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_19
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 19, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_20
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 20, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_21
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 21, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_22
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 22, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_23
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 23, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_24
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 24, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_25
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 25, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_26
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 26, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_27
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 27, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_28
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 28, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_29
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 29, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_30
//                                              ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 30, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_31
//                                              ,B.JUNDAL_PART_OUT                                                                                                 JUNDAL_PART_OUT
//                                          FROM SCH0002 D,
//                                               SCH0001 C,
//                                               OCS0103 B,
//                                               SCH0201 A
//                                         WHERE A.HOSP_CODE          = :f_hosp_code
//                                           AND B.HOSP_CODE(+)       = A.HOSP_CODE
//                                           AND C.HOSP_CODE(+)       = A.HOSP_CODE
//                                           AND D.HOSP_CODE(+)       = A.HOSP_CODE 
//                                           AND A.BUNHO              = :f_bunho
//                                           AND A.DOCTOR             LIKE NVL(:f_doctor, '%')
//                                           AND A.GWA                LIKE NVL(:f_gwa, '%')
//                                           AND A.RESER_DATE         IS NOT NULL
//                                           AND NVL(A.CANCEL_YN,'N') = 'N'
//                                           AND A.ACTING_DATE        IS NULL
//                                           AND FN_SCH_OCS_JUBSU_YN(A.IN_OUT_GUBUN, A.FKOCS) = 'N'
//                                           AND B.HANGMOG_CODE(+)    = A.HANGMOG_CODE
//                                           AND C.JUNDAL_TABLE(+)    = A.JUNDAL_TABLE
//                                           AND C.JUNDAL_PART(+)     = A.JUNDAL_PART
//                                           AND D.HANGMOG_CODE(+)    = A.HANGMOG_CODE
//                                         GROUP BY
//                                               DECODE(A.JUNDAL_PART, 'CPL', 'CPL', A.HANGMOG_CODE)
//                                              ,DECODE(A.JUNDAL_PART,'CPL',C.JUNDAL_PART_NAME, B.HANGMOG_NAME)
//                                               || DECODE(NVL(A.JUSA_RESER_YN,'N'),'Y','('||FN_ADM_MSG(4108)||')','')  
//                                              ,TO_CHAR(NVL(A.RESER_DATE,A.HOPE_DATE),'YYYY/MM/DD')
//                                              ,A.RESER_TIME
//                                              ,A.JUNDAL_TABLE
//                                              ,A.JUNDAL_PART
//                                              ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.INPUT_DATE)
//                                              ,DECODE(A.JUNDAL_PART,'CPL','Y',DECODE(D.HANGMOG_CODE, NULL, 'N', 'Y'))
//                                              ,A.RESER_DATE
//                                              ,A.BUNHO
//                                              ,A.GWA
//                                              ,A.DOCTOR
//                                              ,DECODE(NVL(A.EMERGENCY,'N'),'Y','N',DECODE(B.HANGMOG_CODE, NULL, 'N', 'Y'))
//                                              ,A.ORDER_DATE
//                                              ,FN_SCH_ORDER_REMARK(A.IN_OUT_GUBUN,A.FKOCS)
//                                              ,DECODE(NVL(A.EMERGENCY,'N'),'N',A.IN_OUT_GUBUN, NVL(A.EMERGENCY,'N'))
//                                              ,B.JUNDAL_PART_OUT 
//                                         ORDER BY 8, 45, 5, 6";
//            this.layReserList.QueryLayout(true);
//        }
        #endregion

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch( e.Func )
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					this.dwReserList.Reset();
					clear_1();
					clear_2();
					clear_3();
					clear_4();
					clear_5();
					this.ReserQuery();
					break;
				default:
					break;
			}
		}

		//		private void SetData
		#endregion

		#region 환자예약 조회
		private void ReserQuery()
		{
			string text;
			DateTime dt;

            // 예약할 처방의 날짜별 가능여부 조회
            this.layReserList.SetBindVarValue("f_hosp_code"    , EnvironInfo.HospCode);
			this.layReserList.SetBindVarValue("f_bunho"        , this.paBoxPatient.BunHo.ToString());
            //this.layReserList.SetBindVarValue("f_in_out_gubun" , in_out_gubun);
            this.layReserList.SetBindVarValue("f_doctor"       , this.cboDoctor.GetDataValue().ToString());
            //this.layReserList.SetBindVarValue("f_hangmog_code" , hangmog_code);
            this.layReserList.SetBindVarValue("f_reser_date"   , dtDate.GetDataValue());
            this.layReserList.SetBindVarValue("f_gwa"          , this.cboGwa.GetDataValue().ToString());
			dwReserList.Reset();
            if (this.layReserList.QueryLayout(true))
                dwReserList.FillData(layReserList.LayoutTable);
            else
                XMessageBox.Show(Service.ErrMsg);

            // 예약사항 조회

            string tempQuery = this.layReserList.QuerySQL;

            this.layReserList.QuerySQL = @"SELECT DECODE(A.JUNDAL_PART, 'CPL', 'CPL', A.HANGMOG_CODE)                                   HANGMOG_CODE
                                                  ,DECODE(A.JUNDAL_PART,'CPL',C.JUNDAL_PART_NAME, B.HANGMOG_NAME) ||                      
                                                   DECODE(NVL(A.JUSA_RESER_YN,'N'),'Y','('||FN_ADM_MSG(4108)||')','')                    HANGMOG_NAME
                                                  ,TO_CHAR(NVL(A.RESER_DATE,A.HOPE_DATE),'YYYY/MM/DD')                                   RESER_DATE
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 0  ,'YYYYMMDD'), 'R','')   DATE_1
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 1  ,'YYYYMMDD'), 'R','')   DATE_2
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 2  ,'YYYYMMDD'), 'R','')   DATE_3
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 3  ,'YYYYMMDD'), 'R','')   DATE_4
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 4  ,'YYYYMMDD'), 'R','')   DATE_5
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 5  ,'YYYYMMDD'), 'R','')   DATE_6
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 6  ,'YYYYMMDD'), 'R','')   DATE_7
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 7  ,'YYYYMMDD'), 'R','')   DATE_8
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 8  ,'YYYYMMDD'), 'R','')   DATE_9
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 9  ,'YYYYMMDD'), 'R','')   DATE_10
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 10 ,'YYYYMMDD'), 'R','')   DATE_11
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 11 ,'YYYYMMDD'), 'R','')   DATE_12
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 12 ,'YYYYMMDD'), 'R','')   DATE_13
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 13 ,'YYYYMMDD'), 'R','')   DATE_14
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 14 ,'YYYYMMDD'), 'R','')   DATE_15
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 15 ,'YYYYMMDD'), 'R','')   DATE_16
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 16 ,'YYYYMMDD'), 'R','')   DATE_17
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 17 ,'YYYYMMDD'), 'R','')   DATE_18
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 18 ,'YYYYMMDD'), 'R','')   DATE_19
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 19 ,'YYYYMMDD'), 'R','')   DATE_20
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 20 ,'YYYYMMDD'), 'R','')   DATE_21
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 21 ,'YYYYMMDD'), 'R','')   DATE_22
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 22 ,'YYYYMMDD'), 'R','')   DATE_23
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 23 ,'YYYYMMDD'), 'R','')   DATE_24
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 24 ,'YYYYMMDD'), 'R','')   DATE_25
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 25 ,'YYYYMMDD'), 'R','')   DATE_26
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 26 ,'YYYYMMDD'), 'R','')   DATE_27
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 27 ,'YYYYMMDD'), 'R','')   DATE_28
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 28 ,'YYYYMMDD'), 'R','')   DATE_29
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 29 ,'YYYYMMDD'), 'R','')   DATE_30
                                                  ,DECODE(TO_CHAR(A.RESER_DATE,'YYYYMMDD'), TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 30 ,'YYYYMMDD'), 'R','')   DATE_31
                                                  ,A.JUNDAL_TABLE                                                                        JUNDAL_TABLE --
                                                  ,A.JUNDAL_PART                                                                         JUNDAL_PART --
                                                  ,MIN(A.PKSCH0201)                                                                      KEY
                                                  ,DECODE(A.JUNDAL_PART,'CPL','Y',DECODE(D.HANGMOG_CODE, NULL, 'N', 'Y'))                RESER_GUMSA_YN
                                                  ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                             GWA_NAME
                                                  ,A.RESER_TIME                                                                          RESER_TIME
                                                  ,DECODE(A.RESER_DATE, NULL, 'N', 'Y')                                                  RESER_YN
                                                  ,A.GWA                                                                                 GWA 
                                                  ,A.DOCTOR                                                                              DOCTOR
                                                  ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                       DOCTOR_NAME
                                                  /*,NVL(MAX((SELECT 'Y' FROM DUAL WHERE 
                                                            EXISTS (SELECT 'Y' FROM SCH3000 X  WHERE X.JUNDAL_PART = A.JUNDAL_PART 
                                                              UNION SELECT 'Y' FROM SCH3101 X  WHERE X.JUNDAL_PART = A.JUNDAL_PART))), 'N')   TIME_YN*/
                                                  ,''                                                                                         TIME_YN
                                                  ,A.ORDER_DATE                                                                                                      ORDER_DATE
                                                  ,FN_SCH_ORDER_REMARK(A.IN_OUT_GUBUN,A.FKOCS)                                                                       ORDER_REMARK
                                                  --,DECODE(NVL(A.EMERGENCY,'N'), 'N', A.IN_OUT_GUBUN, NVL(A.EMERGENCY,'N'))                                           EMERGENCY
                                                  ,NVL(A.EMERGENCY,'N')                                                                                              EMERGENCY
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 0, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_1
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 1, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_2
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 2, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_3
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 3, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_4
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 4, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_5
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 5, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_6
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 6, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_7
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 7, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_8
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 8, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_9
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 9, A.BUNHO, A.GWA, A.DOCTOR)                           RESER_DATE_YN_10
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 10, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_11
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 11, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_12
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 12, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_13
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 13, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_14
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 14, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_15
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 15, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_16
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 16, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_17
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 17, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_18
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 18, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_19
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 19, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_20
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 20, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_21
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 21, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_22
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 22, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_23
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 23, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_24
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 24, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_25
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 25, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_26
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 26, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_27
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 27, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_28
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 28, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_29
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 29, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_30
                                                  ,FN_SCH_RESER_DATE_YN(TO_DATE(:f_reser_date,'YYYY/MM/DD') + 30, A.BUNHO, A.GWA, A.DOCTOR)                          RESER_DATE_YN_31
                                                  ,B.JUNDAL_PART_OUT                                                           JUNDAL_PART_OUT
                                                  ,DECODE(A.JUNDAL_PART, 'ENDO',  A.FKOCS )      FKOCS                                                                    
                                                  ,A.IN_OUT_GUBUN    
                                              FROM SCH0002 D,
                                                   SCH0001 C,
                                                   OCS0103 B,
                                                   SCH0201 A
                                             WHERE A.HOSP_CODE          = :f_hosp_code
                                               AND B.HOSP_CODE(+)       = A.HOSP_CODE
                                               AND C.HOSP_CODE(+)       = A.HOSP_CODE
                                               AND D.HOSP_CODE(+)       = A.HOSP_CODE 
                                               AND A.BUNHO              = :f_bunho
                                               AND A.DOCTOR             LIKE NVL(:f_doctor, '%')
                                               AND A.GWA                LIKE NVL(:f_gwa, '%')
                                               AND A.RESER_DATE         IS NOT NULL
                                               AND NVL(A.CANCEL_YN,'N') = 'N'
                                               AND A.ACTING_DATE        IS NULL
                                               AND FN_SCH_OCS_JUBSU_YN(A.IN_OUT_GUBUN, A.FKOCS) = 'N'
                                               AND ((A.IN_OUT_GUBUN  = 'O' AND B.RESER_YN_OUT = 'Y') OR 
                                                    (A.IN_OUT_GUBUN  = 'I' AND B.RESER_YN_INP = 'Y')) 
                                               AND B.HANGMOG_CODE(+)    = A.HANGMOG_CODE
                                               AND C.JUNDAL_TABLE(+)    = A.JUNDAL_TABLE
                                               AND C.JUNDAL_PART(+)     = A.JUNDAL_PART
                                               AND D.HANGMOG_CODE(+)    = A.HANGMOG_CODE
                                             GROUP BY
                                                   DECODE(A.JUNDAL_PART, 'CPL', 'CPL', A.HANGMOG_CODE)
                                                  ,DECODE(A.JUNDAL_PART,'CPL',C.JUNDAL_PART_NAME, B.HANGMOG_NAME)
                                                   || DECODE(NVL(A.JUSA_RESER_YN,'N'),'Y','('||FN_ADM_MSG(4108)||')','')  
                                                  ,TO_CHAR(NVL(A.RESER_DATE,A.HOPE_DATE),'YYYY/MM/DD')
                                                  ,A.RESER_TIME
                                                  ,A.JUNDAL_TABLE
                                                  ,A.JUNDAL_PART
                                                  ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.INPUT_DATE)
                                                  ,DECODE(A.JUNDAL_PART,'CPL','Y',DECODE(D.HANGMOG_CODE, NULL, 'N', 'Y'))
                                                  ,A.RESER_DATE
                                                  ,A.BUNHO
                                                  ,A.GWA
                                                  ,A.DOCTOR
                                                  ,DECODE(NVL(A.EMERGENCY,'N'),'Y','N',DECODE(D.HANGMOG_CODE, NULL, 'N', 'Y'))
                                                  ,A.ORDER_DATE
                                                  ,FN_SCH_ORDER_REMARK(A.IN_OUT_GUBUN,A.FKOCS)
                                                  --,DECODE(NVL(A.EMERGENCY,'N'),'N',A.IN_OUT_GUBUN, NVL(A.EMERGENCY,'N'))
                                                  ,NVL(A.EMERGENCY,'N')
                                                  ,B.JUNDAL_PART_OUT                                                                             
                                                  ,DECODE(A.JUNDAL_PART, 'ENDO',  A.FKOCS )                                                                
                                                  ,A.IN_OUT_GUBUN   
                                             ORDER BY 42      -- GWA
                                                    , 45 DESC -- TIME_YN
                                                    , 35      -- JUNDAL_TABLE
                                                    , 36      -- JUNDAL_PART";

            //dwReserList.Reset();
            this.layReserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layReserList.SetBindVarValue("f_bunho", this.paBoxPatient.BunHo.ToString());
            this.layReserList.SetBindVarValue("f_reser_date", dtDate.GetDataValue());
            this.layReserList.SetBindVarValue("f_doctor", this.cboDoctor.GetDataValue().ToString());
            this.layReserList.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue().ToString());

            isCallQueryEnd = false;

            if (this.layReserList.QueryLayout(true))
            {
                dwReserList.FillData(layReserList.LayoutTable);
            }
            else
            {
                XMessageBox.Show(Service.ErrMsg);
            }

            isCallQueryEnd = true;
            this.layReserList.QuerySQL = tempQuery;

			//예약일자 Set
			dt = DateTime.Parse(dtDate.GetDataValue());
			// 일자 setting
			string dd = string.Empty;
			string yoil_gubun = string.Empty;
			string TextColor = string.Empty;
			for (int i = 1 ; i <= 31 ; i++)
			{
				//휴일 색 지정
				layHoliYN.SetBindVarValue("f_date", dt.AddDays(i - 1).ToString("yyyyMMdd"));

				if (layHoliYN.QueryLayout())
				{
					if (layHoliYN.GetItemValue("holi_yn").ToString() == "Y")
						text = "t_" + i.ToString("00") + ".color = '134217857'";
					else
						text = "t_" + i.ToString("00") + ".color = '33554432'";

					dwReserList.Modify(text);

                    yoil_gubun = layHoliYN.GetItemValue("yoil_gubun").ToString();
				}
				dd = dt.AddDays(i - 1).ToString("dd");

				text = "t_" + i.ToString("00") + ".text = '" + dd + "'";
				dwReserList.Modify(text);

				if ((dd == "01") || (i == 1))
				{
					dd = dt.AddDays(i - 1).ToString("MM");
					TextColor = "m_" + i.ToString("00") + ".color = '33554432'";
				}
				else
				{
					if (yoil_gubun == "1") yoil_gubun = "日";
					if (yoil_gubun == "2") yoil_gubun = "月";
					if (yoil_gubun == "3") yoil_gubun = "火";
					if (yoil_gubun == "4") yoil_gubun = "水";
					if (yoil_gubun == "5") yoil_gubun = "木";
					if (yoil_gubun == "6") yoil_gubun = "金";
					if (yoil_gubun == "7") yoil_gubun = "土";
					dd = yoil_gubun;					
					TextColor = "m_" + i.ToString("00") + ".color = '32768'";
				}
				text = "m_" + i.ToString("00") + ".text = '" + dd + "'";

				dwReserList.Modify(text);
				dwReserList.Modify(TextColor);
			}
			dwReserList.Refresh();
		}
		#endregion

		#region 환자선택
		private void paBoxPatient_PatientSelected(object sender, System.EventArgs e)
		{
			this.dwReserList.Reset();
			ClearAll();

			this.ReserQuery();
		}

		#endregion

		#region 달력선택
		private void btPostDate_Click(object sender, System.EventArgs e)
		{
			DateTime dt = DateTime.Parse(dtDate.GetDataValue());
			dtDate.SetDataValue(dt.AddDays(-31));
			this.ReserQuery();

			ClearAll();
		}

		private void btPreDate_Click(object sender, System.EventArgs e)
		{
			DateTime dt = DateTime.Parse(dtDate.GetDataValue());
			dtDate.SetDataValue(dt.AddDays(31));
			this.ReserQuery();
			
			ClearAll();
		}

		#endregion

		#region ClearAll
		private void ClearAll()
		{
			clear_1();
			clear_2();
			clear_3();
			clear_4();
			clear_5();
			clear_6();
			clear_7();
			clear_8();
			clear_9();
			clear_10();
		}
		#endregion

		#region 예약일자 선택
		private void dwReserList_Click(object sender, System.EventArgs e)
		{
			try
			{
				Sybase.DataWindow.ObjectAtPointer oap = dwReserList.ObjectUnderMouse;
				int    row = oap.RowNumber;
				string colname, reser_yn, data_col, suntak_yn = "N";

				colname = oap.Gob.Name;

				// 핵의학의 예약은 불가능
				if (colname.Substring(1, 1).ToString() == "_" && row >= 1)
				{
					data_col = colname.Replace("d", "day");
					data_col = data_col.Replace("day_0", "day_");

					if (this.dwReserList.GetItemString(row, "ocs0103_jundal_part") == "RI" && this.dwReserList.GetItemString(row, data_col).ToString() != "R")
					{
						string msg = (NetInfo.Language == LangMode.Ko ? "핵의학 검사예약은 방사선과에 연락하여 주십시오."
							: "核医学検査予約は放射線科にご連絡ください。");
						XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
						data_col = "";
						return;
					}

					data_col = "";
				}

				if (colname == "b_remark")
				{
                    string order_remark = dwGetString(dwReserList, row, "order_remark");
					XMessageBox.Show(order_remark, "オーダコメント");
					return;
				}

				if ((colname == "DataWindow") || (colname == "reser_chk_yn") || (colname == "gwa_name") || (colname == "dis_hangmog_name") || 
                    (colname == "chk_yn") || (colname == "reser_date") || (colname == "reser_time") || (colname == "order_date") ||
                    (colname == "emergency") || (colname == "doctor_name"))
				{
					if (row > 0)
						dwReserList.SetRow(row);

					return;
				}
				
				if (row < 1)
				{
					if (oap.Gob.Name.ToString().Substring(0,1) == "t")
					{
						// 초기화
						for (int j = 1; j <= dwReserList.RowCount ; j++)
						{
							dwReserList.SetItemString(j, "chk_yn", "");
						}

						ClearAll();

						/// 사용자가 임의로 선택한 검사가 있을 경우는 선택한 검사만
						/// 그렇지 않은 경우는 전체를 선택한다.
						for (int k = 1; k <= dwReserList.RowCount ; k++)
						{
							if (dwGetString(dwReserList, k, "reser_chk_yn") == "Y")
							{
								suntak_yn = "Y";
							}
						}


						// 선택된 검사 예약일자 Setting
						colname = colname.Replace("t", "d");
						for (int i = 1; i <= dwReserList.RowCount ; i++)
						{
							// 사용자가 선택한 검사가 있을경우
							if (suntak_yn == "Y")
							{
								if (dwGetString(dwReserList, i, "reser_chk_yn") == "Y")
								{
									data_col = colname.Replace("d", "day");
									data_col = data_col.Replace("day_0", "day_");
									reser_yn = dwGetString(dwReserList, i, data_col);

									if ((reser_yn == "Y") || (reser_yn == "R"))
									{
										// 예약일자 선택
										DWSet(i, colname);
									}
								}
							}
							else
							{
                                if (colname.Substring(1, 1).ToString() == "_")
                                {
                                    data_col = colname.Replace("d", "day");
                                    data_col = data_col.Replace("day_0", "day_");
                                    reser_yn = dwGetString(dwReserList, i, data_col);
                                    if ((reser_yn == "Y") || (reser_yn == "R"))
                                    {
                                        // 예약일자 선택
                                        DWSet(i, colname);
                                    }
                                }
							}
						}
					}
				}				
				else
				{
					dwReserList.SetRow(row);

					// 예약가능 유무 체크
					data_col = colname.Replace("d", "day");
					data_col = data_col.Replace("day_0", "day_");
					reser_yn = dwGetString(dwReserList, dwReserList.CurrentRow, data_col);

					if ((reser_yn == "Y") || (reser_yn == "R"))
					{
						// 예약일자 선택
						DWSet(row, colname);
					}
				}
				
				dwReserList.Refresh();
			}
			catch ( Exception ex )
			{
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);

			}
		}
		#endregion

        private void dwReserList_DoubleClick(object sender, System.EventArgs e)
        {
            int row = dwReserList.CurrentRow;
            if (row < 1) return;

            //string reser_date = xdtReserDate.GetDataValue().ToString();
            string jundalpart = dwGetString(dwReserList, row, "jundal_part");
            if (jundalpart != "CPL") return;

            string bunho = paBoxPatient.BunHo;

            string reser_date = dwGetString(dwReserList, row, "reser_date");
            string order_date = dwGetString(dwReserList, row, "order_date");

            string ls = dwReserList.GetColumnName().ToString();

            FINDReserList dlg = new FINDReserList(bunho, reser_date, order_date, jundalpart);
            dlg.ShowDialog();

            this.dwReserList.Reset();
            ClearAll();

            this.ReserQuery();
        }

		#region dw 선택
		private void DWSet(int row, string colname)
		{
			DateTime dt = DateTime.Parse(dtDate.GetDataValue());
			int      addDate;

			addDate = int.Parse(colname.Substring(2,2));

			DateTime dtReserDate = dt.AddDays(addDate - 1);

			hangmog_code   = dwGetString(dwReserList, row, "hangmog_code");
			jundal_table   = dwGetString(dwReserList, row, "jundal_table");
			jundal_part    = dwGetString(dwReserList, row, "jundal_part");
			key            = dwGetString(dwReserList, row, "key");
			hangmog_name   = dwGetString(dwReserList, row, "dis_hangmog_name");
			gwa            = dwGetString(dwReserList, row, "gwa");

            //time_yn = dwGetString(dwReserList, row, "time_yn");

            this.layTimeReserYn.SetBindVarValue("f_hangmog_code", hangmog_code);
            this.layTimeReserYn.SetBindVarValue("f_reser_date", dtReserDate.ToString("yyyy/MM/dd"));
            //this.layTimeReserYn.QueryLayout();

            //object retVal = Service.ExecuteScalar("SELECT FN_SCH_TIME_RESER_YN('" + hangmog_code + "', '" + dtReserDate.ToString("yyyy/MM/dd") + "' ) TIME_RESER_YN FROM DUAL");
            //time_yn = "";
            time_yn = this.layTimeReserYn.GetItemValue("time_reser_yn").ToString(); 

            //if (!TypeCheck.IsNull(retVal))
            //{
            //    time_yn = retVal.ToString();
            //}
            //else
            //{
            //    time_yn = "";
            //}

           // XMessageBox.Show(time_yn);

			chk_dw         = dwGetString(dwReserList, row, "chk_yn");
			reser_gumsa_yn = dwGetString(dwReserList, row, "reser_gumsa_yn");
			col_name       = "day_" + addDate.ToString();
			reser_yn       = dwGetString(dwReserList, row, col_name);

			if (dwGetString(dwReserList, row, "ocs0103_jundal_part") == "RI") return;

			
			// 오다일자보다 적으면 선택 안되게 10.02.02
			if ( double.Parse(dtReserDate.ToString("yyyyMMdd").Replace("-","").Replace("/","")) < double.Parse(dwGetString(dwReserList,row,"order_date").Replace("/","").Replace("-","")))
			{
				XMessageBox.Show("オーダ日付より以前の日付は選択できません。");
				return;
			}

			// 현재일자보다 적으면 선택 안되게 10.03.18
			if ( double.Parse(dtReserDate.ToString("yyyyMMdd").Replace("-","").Replace("/","")) < double.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd").Replace("/","").Replace("-","")))
			{
				XMessageBox.Show("今日より以前の日付は選択できません。");
				return;
			}


			// 접수 유무 체크
			if (!ChkJubsu(key))
				return;

			xdtReserDate.SetDataValue(dtReserDate);
			
			if (chk_dw.Trim() == "")
			{
				if (dw_1 == false)
				{
					ChkSetItem(row, "1", dtReserDate, true);
					ReserTimeList_1(true);
					dw_1 = true;
					return;
				}
				if (dw_2 == false)
				{
					ChkSetItem(row, "2", dtReserDate, true);
					ReserTimeList_2(true);
					dw_2 = true;
					return;
				}
				if (dw_3 == false)
				{
					ChkSetItem(row, "3", dtReserDate, true);
					ReserTimeList_3(true);
					dw_3 = true;
					return;
				}
				if (dw_4 == false)
				{
					ChkSetItem(row, "4", dtReserDate, true);
					ReserTimeList_4(true);
					dw_4 = true;
					return;
				}
				if (dw_5 == false)
				{
					ChkSetItem(row, "5", dtReserDate, true);
					ReserTimeList_5(true);
					dw_5 = true;
					return;
				}

				if (dw_6 == false)
				{
					ChkSetItem(row, "6", dtReserDate, true);
					ReserTimeList_6(true);
					dw_6 = true;
					return;
				}
				if (dw_7 == false)
				{
					ChkSetItem(row, "7", dtReserDate, true);
					ReserTimeList_7(true);
					dw_7 = true;
					return;
				}
				if (dw_8 == false)
				{
					ChkSetItem(row, "8", dtReserDate, true);
					ReserTimeList_8(true);
					dw_8 = true;
					return;
				}
				if (dw_9 == false)
				{
					ChkSetItem(row, "9", dtReserDate, true);
					ReserTimeList_9(true);
					dw_9 = true;
					return;
				}
				if (dw_10 == false)
				{
					ChkSetItem(row, "10", dtReserDate, true);
					ReserTimeList_10(true);
					dw_10 = true;
					return;
				}
			}
			else
			{
				if (chk_dw == "1")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_1(false);
					return;
				}
				if (chk_dw == "2")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_2(false);
					return;
				}
				if (chk_dw == "3")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_3(false);
					return;
				}
				if (chk_dw == "4")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_4(false);
					return;
				}
				if (chk_dw == "5")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_5(false);
					return;
				}
				if (chk_dw == "6")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_6(false);
					return;
				}
				if (chk_dw == "7")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_7(false);
					return;
				}
				if (chk_dw == "8")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_8(false);
					return;
				}
				if (chk_dw == "9")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_9(false);
					return;
				}				
				if (chk_dw == "10")
				{
					ChkSetItem(row, "", dtReserDate, false);
					ReserTimeList_10(false);
					return;
				}
			}
		}
		#endregion

		#region 예약검사가 아닌경우는 일괄로 예약 처리한다.
		private void ChkSetItem(int row, string setDWBunho, DateTime setReserDate, bool reserProcess)
		{
			if (reserProcess)
			{
				dwReserList.SetItemString(row, "chk_yn", setDWBunho);
				dwReserList.SetItemDate(row, "set_reser_date", setReserDate);
			}
			else
			{
				dwReserList.SetItemString(row, "chk_yn", setDWBunho);
				dwReserList.SetItemString(row, "reser_chk_yn", "N");
				dwReserList.SetItemDate(row, "set_reser_date", setReserDate);		
			}
		}
		#endregion

		#region SetdwReserList
		private void SetdwReserList(string dw_bunho, string col_name, string set_data)
		{
			for (int i = 1; i<=dwReserList.RowCount; i++)
			{
				if (dw_bunho == dwGetString(dwReserList, i, "chk_yn"))
				{
					dwReserList.SetItemString(i, col_name, set_data);
				}
			}
			dwReserList.AcceptText();
		}
		#endregion

		#region GetdwReserList
		private string GetdwReserListString(string dw_bunho, string col_name)
		{
			for (int i = 1; i<=dwReserList.RowCount; i++)
			{
				if (dw_bunho == dwGetString(dwReserList, i, "chk_yn"))
				{
					return dwGetString(dwReserList, i, col_name);
				}
			}
			return "";
		}
		#endregion

		#region ReserTimeList

		#region ReserTimeList_1
		private void ReserTimeList_1(bool flag)
		{
			if (flag)
			{
				lbHangmogName_1.Text  = hangmog_name;
				lbReserDate_1.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_1.Text        = "";
				
				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());

				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_1.ForeColor = XColor.DisabledForeColor;
					lbReserDate_1.ForeColor   = XColor.DisabledForeColor;
					txtTime_1.Enabled = false;
				}
				else
				{
					lbHangmogName_1.ForeColor = XColor.UpdatedForeColor;
					lbReserDate_1.ForeColor   = XColor.UpdatedForeColor;
					txtTime_1.Enabled = true;

                    //시간와꾸있는 검사일때만 시간 표시함
                    dwReserList_1.Reset();
                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_1.FillData(layTimeList.LayoutTable);
                }

			}
			else
			{
				lbHangmogName_1.Text  = string.Empty;
				lbReserDate_1.Text    = string.Empty;
				txtTime_1.Text        = string.Empty;
				
				dwReserList_1.Reset();
				dw_1 = false;
				return;
			}
		}
		#endregion

		#region ReserTimeList_2
		private void ReserTimeList_2(bool flag)
		{
			if (flag)
			{
				lbHangmogName_2.Text  = hangmog_name;
				lbReserDate_2.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_2.Text        = "";
				
				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());

				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_2.ForeColor = XColor.DisabledForeColor;
					lbReserDate_2.ForeColor   = XColor.DisabledForeColor;
					txtTime_2.Enabled = false;
				}
				else
				{
					lbHangmogName_2.ForeColor = XColor.UpdatedForeColor;
					lbReserDate_2.ForeColor   = XColor.UpdatedForeColor;
                    txtTime_2.Enabled = true;


                    dwReserList_2.Reset();
                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_2.FillData(layTimeList.LayoutTable);
				}

			}
			else
			{
				lbHangmogName_2.Text  = string.Empty;
				lbReserDate_2.Text    = string.Empty;
				txtTime_2.Text        = string.Empty;
				
				dwReserList_2.Reset();
				dw_2 = false;
				return;
			}
		}
		#endregion

		#region ReserTimeList_3
		private void ReserTimeList_3(bool flag)
		{
			if (flag)
			{
				lbHangmogName_3.Text  = hangmog_name;
				lbReserDate_3.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_3.Text        = "";
				
				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());
				
				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_3.ForeColor = XColor.DisabledForeColor;
					lbReserDate_3.ForeColor   = XColor.DisabledForeColor;
					txtTime_3.Enabled = false;
				}
				else
				{
					lbHangmogName_3.ForeColor = XColor.UpdatedForeColor;					
					lbReserDate_3.ForeColor   = XColor.UpdatedForeColor;
					txtTime_3.Enabled = true;


                    dwReserList_3.Reset();

                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_3.FillData(layTimeList.LayoutTable);
				}
			}
			else
			{
				lbHangmogName_3.Text  = string.Empty;
				lbReserDate_3.Text    = string.Empty;
				txtTime_3.Text        = string.Empty;
				
				dwReserList_3.Reset();
				dw_3 = false;
				return;
			}
		}
		#endregion

		#region ReserTimeList_4
		private void ReserTimeList_4(bool flag)
		{
			if (flag)
			{
				lbHangmogName_4.Text  = hangmog_name;
				lbReserDate_4.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_4.Text        = "";

				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());
				
				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_4.ForeColor = XColor.DisabledForeColor;
					lbReserDate_4.ForeColor   = XColor.DisabledForeColor;
					txtTime_4.Enabled = false;
				}
				else
				{
					lbHangmogName_4.ForeColor = XColor.UpdatedForeColor;					
					lbReserDate_4.ForeColor   = XColor.UpdatedForeColor;
					txtTime_4.Enabled = true;


                    dwReserList_4.Reset();

                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_4.FillData(layTimeList.LayoutTable);
				}
			}
			else
			{
				lbHangmogName_4.Text  = string.Empty;
				lbReserDate_4.Text    = string.Empty;
				txtTime_4.Text        = string.Empty;
				
				dwReserList_4.Reset();
				dw_4 = false;
				return;
			}
		}
		#endregion

		#region ReserTimeList_5
		private void ReserTimeList_5(bool flag)
		{
			if (flag)
			{
				lbHangmogName_5.Text  = hangmog_name;
				lbReserDate_5.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_5.Text        = "";
				
				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());
				
				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_5.ForeColor = XColor.DisabledForeColor;
					lbReserDate_5.ForeColor   = XColor.DisabledForeColor;
					txtTime_5.Enabled = false;
				}
				else
				{
					lbHangmogName_5.ForeColor = XColor.UpdatedForeColor;					
					lbReserDate_5.ForeColor   = XColor.UpdatedForeColor;
					txtTime_5.Enabled = true;


                    dwReserList_5.Reset();

                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_5.FillData(layTimeList.LayoutTable);
				}
			}
			else
			{
				lbHangmogName_5.Text  = string.Empty;
				lbReserDate_5.Text    = string.Empty;
				txtTime_5.Text    = string.Empty;
				
				dwReserList_5.Reset();
				dw_5 = false;
				return;
			}
		}
		#endregion

		#region ReserTimeList_6
		private void ReserTimeList_6(bool flag)
		{
			if (flag)
			{
				lbHangmogName_6.Text  = hangmog_name;
				lbReserDate_6.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_6.Text        = "";
				
				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());
				
				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_6.ForeColor = XColor.DisabledForeColor;
					lbReserDate_6.ForeColor   = XColor.DisabledForeColor;
					txtTime_6.Enabled = false;
				}
				else
				{
					lbHangmogName_6.ForeColor = XColor.UpdatedForeColor;					
					lbReserDate_6.ForeColor   = XColor.UpdatedForeColor;
					txtTime_6.Enabled = true;


                    dwReserList_6.Reset();

                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_6.FillData(layTimeList.LayoutTable);
				}
			}
			else
			{
				lbHangmogName_6.Text  = string.Empty;
				lbReserDate_6.Text    = string.Empty;
				txtTime_6.Text    = string.Empty;
				
				dwReserList_6.Reset();
				dw_6 = false;
				return;
			}
		}
		#endregion

		#region ReserTimeList_7
		private void ReserTimeList_7(bool flag)
		{
			if (flag)
			{
				lbHangmogName_7.Text  = hangmog_name;
				lbReserDate_7.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_7.Text        = "";
				
				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());
				
				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_7.ForeColor = XColor.DisabledForeColor;
					lbReserDate_7.ForeColor   = XColor.DisabledForeColor;
					txtTime_7.Enabled = false;
				}
				else
				{
					lbHangmogName_7.ForeColor = XColor.UpdatedForeColor;					
					lbReserDate_7.ForeColor   = XColor.UpdatedForeColor;
					txtTime_7.Enabled = true;


                    dwReserList_7.Reset();

                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_7.FillData(layTimeList.LayoutTable);
				}
			}
			else
			{
				lbHangmogName_7.Text  = string.Empty;
				lbReserDate_7.Text    = string.Empty;
				txtTime_7.Text    = string.Empty;
				
				dwReserList_7.Reset();
				dw_7 = false;
				return;
			}
		}
		#endregion

		#region ReserTimeList_8
		private void ReserTimeList_8(bool flag)
		{
			if (flag)
			{
				lbHangmogName_8.Text  = hangmog_name;
				lbReserDate_8.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_8.Text        = "";
				
				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());
				
				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_8.ForeColor = XColor.DisabledForeColor;
					lbReserDate_8.ForeColor   = XColor.DisabledForeColor;
					txtTime_8.Enabled = false;
				}
				else
				{
					lbHangmogName_8.ForeColor = XColor.UpdatedForeColor;					
					lbReserDate_8.ForeColor   = XColor.UpdatedForeColor;
					txtTime_8.Enabled = true;


                    dwReserList_8.Reset();

                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_8.FillData(layTimeList.LayoutTable);
				}
			}
			else
			{
				lbHangmogName_8.Text  = string.Empty;
				lbReserDate_8.Text    = string.Empty;
				txtTime_8.Text    = string.Empty;
				
				dwReserList_8.Reset();
				dw_8 = false;
				return;
			}
		}
		#endregion

		#region ReserTimeList_9
		private void ReserTimeList_9(bool flag)
		{
			if (flag)
			{
				lbHangmogName_9.Text  = hangmog_name;
				lbReserDate_9.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_9.Text        = "";
				
				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());
				
				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_9.ForeColor = XColor.DisabledForeColor;
					lbReserDate_9.ForeColor   = XColor.DisabledForeColor;
					txtTime_9.Enabled = false;
				}
				else
				{
					lbHangmogName_9.ForeColor = XColor.UpdatedForeColor;					
					lbReserDate_9.ForeColor   = XColor.UpdatedForeColor;
					txtTime_9.Enabled = true;


                    dwReserList_9.Reset();

                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_9.FillData(layTimeList.LayoutTable);
				}
			}
			else
			{
				lbHangmogName_9.Text  = string.Empty;
				lbReserDate_9.Text    = string.Empty;
				txtTime_9.Text    = string.Empty;
				
				dwReserList_9.Reset();
				dw_9 = false;
				return;
			}
		}
		#endregion

		#region ReserTimeList_10
		private void ReserTimeList_10(bool flag)
		{
			if (flag)
			{
				lbHangmogName_10.Text  = hangmog_name;
				lbReserDate_10.Text    = xdtReserDate.GetDataValue().ToString();
				txtTime_10.Text        = "";
				
				//당일예약 메시지
				ReserMsg(time_yn, xdtReserDate.GetDataValue().ToString());
				
				//예약시간 지정여부
				if (time_yn == "N")
				{
					lbHangmogName_10.ForeColor = XColor.DisabledForeColor;
					lbReserDate_10.ForeColor   = XColor.DisabledForeColor;
					txtTime_10.Enabled = false;
				}
				else
				{
					lbHangmogName_10.ForeColor = XColor.UpdatedForeColor;					
					lbReserDate_10.ForeColor   = XColor.UpdatedForeColor;
					txtTime_10.Enabled = true;


                    dwReserList_10.Reset();

                    // 일자별 예약시간 조회
                    layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                    if (layTimeList.QueryLayout(true))
                        dwReserList_10.FillData(layTimeList.LayoutTable);
				}
			}
			else
			{
				lbHangmogName_10.Text  = string.Empty;
				lbReserDate_10.Text    = string.Empty;
				txtTime_10.Text    = string.Empty;
				
				dwReserList_10.Reset();
				dw_10 = false;
				return;
			}
		}
		#endregion

		private void ReserMsg(string time_yn, string dateTime)
		{
			if (time_yn == "N") return;
			if (dateTime.Replace("/","") == EnvironInfo.GetSysDate().ToString("yyyyMMdd"))

                // 20110419 김보현
                if (dwGetString(dwReserList, this.dwReserList.CurrentRow, "reser_yn") != "Y")
				    XMessageBox.Show("当日予約を行うには、必ず検査部門に連絡し、承認された場合のみ登録を行ってください。", "注意", MessageBoxIcon.Information);
		}
		#endregion

		#region 데이터윈도우 이벤트
		private void dwReserList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList.Refresh();
		}

		private void dwReserList_RowFocusChanged_1(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			int   row = e.RowNumber;


			if (row < 1) return;
			string i_hangmog_code = dwReserList.GetItemString(row, "hangmog_code");
			dwReserList.Refresh();

		}
		#endregion

		#region 저장버튼을 클릭을 했을 때
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계

				//070314 김민수 현재 예약을 잡은 날짜만을 출력(기존에 예약잡은 날은 출력하지 않는다
				ArrayList reser_date_list = new ArrayList();
				int i = 0;
				if ( this.lbReserDate_1.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_1.Text);

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_1.Text )
							reser_date_list.Add(lbReserDate_1.Text);
					}
				}
				if ( this.lbReserDate_2.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_2.Text);

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_2.Text )
							reser_date_list.Add(lbReserDate_2.Text);
					}
				}
				if ( this.lbReserDate_3.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_3.Text);

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_3.Text )
							reser_date_list.Add(lbReserDate_3.Text);
					}
				}
				if ( this.lbReserDate_4.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_4.Text);

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_4.Text )
							reser_date_list.Add(lbReserDate_4.Text);
					}
				}
				if ( this.lbReserDate_5.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_5.Text);


					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_5.Text )
							reser_date_list.Add(lbReserDate_5.Text);
					}
				}
				if ( this.lbReserDate_6.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_6.Text);

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_6.Text )
							reser_date_list.Add(lbReserDate_6.Text);
					}
				}
				if ( this.lbReserDate_7.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_7.Text);

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_7.Text )
							reser_date_list.Add(lbReserDate_7.Text);
					}
				}
				if ( this.lbReserDate_8.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_8.Text);

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_8.Text )
							reser_date_list.Add(lbReserDate_8.Text);
					}
				}
				if ( this.lbReserDate_9.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_9.Text);

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_9.Text )
							reser_date_list.Add(lbReserDate_9.Text);
					}
				}
				if ( this.lbReserDate_10.Text.Length > 0 )
				{
					if ( reser_date_list.Count == 0 )
						reser_date_list.Add(lbReserDate_10.Text);

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						if ( reser_date_list[i].ToString() != this.lbReserDate_10.Text )
							reser_date_list.Add(lbReserDate_10.Text);
					}
				}

				// 예약 가능 체크
				if (PreReserSave())
				{
                    if (!ReserSave())
                        return;

					for ( i = 0; i < reser_date_list.Count; i++ )
					{
						xdtReserDate.SetDataValue(reser_date_list[i].ToString());
						xdtReserDate.AcceptData();

						#region gwa
						string gwa = UserInfo.Gwa;

                        layLoginGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
						layLoginGwa.SetBindVarValue("f_user_id", UserInfo.UserID);

                        layLoginGwa.QueryLayout();

						gwa = layLoginGwa.GetItemValue("gwa").ToString();

						if (IHIS.Framework.EnvironInfo.CurrSystemID == "HPCS")	gwa = "HC";					
						if (IHIS.Framework.EnvironInfo.CurrSystemID == "AKUS")	gwa = "08";			
						if (gwa == "OUT")	gwa = "01";
						#endregion

						//ReserPrint(gwa, "Y");
					}
					//______________________________________________________________________________________________
				
					// Reset
					grdReserDate.Reset();
					xdtReserDate.SetDataValue(null);
					this.dwReserList.Reset();
					ClearAll();

					// query
					this.ReserQuery();
				}
			}
			finally
			{
				Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
			}
		}
		#endregion

		#region 예약시간 선택
		private bool PreReserSave()
		{
			string reser_time   = "";
			string time_yn      = "";
			string reser_yn     = "";
			string chk_yn       = "";
			string hangmogName  = "";

			for (int i = 1; i <= dwReserList.RowCount; i++)
			{
				reser_time  = dwGetString(dwReserList, i, "set_reser_time").Trim();
				time_yn     = dwGetString(dwReserList, i, "time_yn").Trim();
				reser_yn    = dwGetString(dwReserList, i, "reser_yn").Trim();
				chk_yn      = dwGetString(dwReserList, i, "chk_yn").Trim();

				if ((reser_yn != "Y") && (chk_yn != "")) // 예약검사, 방번호
				{
					if ( (time_yn == "Y") && (reser_time == "")) // 예약검사, 예약시간					
					{
						switch (chk_yn)
						{
							case "1":
								hangmogName = this.lbHangmogName_1.Text;
								break;
							case "2":
								hangmogName = this.lbHangmogName_2.Text;
								break;
							case "3":
								hangmogName = this.lbHangmogName_3.Text;
								break;
							case "4":
								hangmogName = this.lbHangmogName_4.Text;
								break;
							case "5":
								hangmogName = this.lbHangmogName_5.Text;
								break;
							case "6":
								hangmogName = this.lbHangmogName_6.Text;
								break;
							case "7":
								hangmogName = this.lbHangmogName_7.Text;
								break;
							case "8":
								hangmogName = this.lbHangmogName_8.Text;
								break;
							case "9":
								hangmogName = this.lbHangmogName_9.Text;
								break;
							case "10":
								hangmogName = this.lbHangmogName_10.Text;
								break;
							default:
								break;
						}

						XMessageBox.Show(hangmogName + "  時間を選んでください。");
						return false;
					}

					dwReserList.SetItemString(i, "reser_chk_yn", "Y");
				}
			}

			dwReserList.AcceptText();
			return true;
			
		}
		#endregion

		#region 예약
        String mErrMSG = "";
        ArrayList arrayIF = new ArrayList();
        private bool CallSaveService(string aKey, string aHangmogCode, string aReserDate, string aReserTime, string aSeq)
        {
            string  reser_chk;
            int row = 0;

            SingleLayout laySingleTemp = new SingleLayout();
            MultiLayout layMultiTemp = new MultiLayout();

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            //MX IF용 20101001
            string tJundalPart = "";
            string tJundalTable = "";
            string tIOGubun = "";
            string tFKOCS = "";

            laySingleTemp.LayoutItems.Add("bunho");
            laySingleTemp.LayoutItems.Add("input_date");
            laySingleTemp.LayoutItems.Add("jundal_table");
            laySingleTemp.LayoutItems.Add("jundal_part");
            laySingleTemp.LayoutItems.Add("gwa");
            laySingleTemp.LayoutItems.Add("chr_key");
            laySingleTemp.LayoutItems.Add("in_out_gubun");
            laySingleTemp.LayoutItems.Add("reser_date");
            laySingleTemp.LayoutItems.Add("emergency");

            laySingleTemp.QuerySQL = @" SELECT A.BUNHO
                                             , A.ORDER_DATE
                                             , A.JUNDAL_TABLE
                                             , A.JUNDAL_PART
                                             , A.GWA
                                             , DECODE(A.JUNDAL_PART, 'CPL', '%', TO_CHAR(A.PKSCH0201))
                                             , A.IN_OUT_GUBUN
                                             , A.RESER_DATE
                                             , NVL(A.EMERGENCY,'N')
                                          FROM SCH0002 B,
                                               SCH0201 A
                                         WHERE A.HOSP_CODE       = :f_hosp_code
                                           AND B.HOSP_CODE(+)    = A.HOSP_CODE 
                                           AND A.PKSCH0201       = :f_key
                                           AND B.HANGMOG_CODE(+) = A.HANGMOG_CODE";

            laySingleTemp.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            laySingleTemp.SetBindVarValue("f_key", aKey);

            laySingleTemp.QueryLayout();
            
            layMultiTemp.LayoutItems.Add("pksch0201", DataType.String);
            layMultiTemp.LayoutItems.Add("hangmog_code", DataType.String);
            layMultiTemp.LayoutItems.Add("fkocs", DataType.String);
            layMultiTemp.InitializeLayoutTable();

            layMultiTemp.QuerySQL = @"  SELECT A.PKSCH0201,
                                               A.HANGMOG_CODE,
                                               A.FKOCS
                                          FROM SCH0201 A
                                         WHERE A.HOSP_CODE          = :f_hosp_code 
                                           AND A.BUNHO              = :o_bunho
                                           AND A.JUNDAL_TABLE       = :o_jundal_table
                                           AND A.JUNDAL_PART        = :o_jundal_part
                                           AND NVL(A.GWA,'%')       = NVL(:o_gwa,'%')
                                           AND TO_CHAR(A.PKSCH0201) LIKE :o_chr_key
                                           AND NVL(A.CANCEL_YN,'N') = 'N'
                                           AND A.ACTING_DATE        IS NULL
                                           AND A.ORDER_DATE         = :o_input_date
                                           AND A.IN_OUT_GUBUN       = :o_in_out_gubun
                                           AND NVL(A.EMERGENCY,'N') = :o_emergency
                                           AND (  (:f_reser_date IS NULL AND A.RESER_DATE = :o_reser_date)
                                               OR (:f_reser_date IS NOT NULL AND A.RESER_DATE IS NULL    )    )";

            //MX IF용 20101001
            tJundalPart = laySingleTemp.GetItemValue("jundal_part").ToString();
            tJundalTable = laySingleTemp.GetItemValue("jundal_table").ToString();
            tIOGubun = laySingleTemp.GetItemValue("in_out_gubun").ToString();

            layMultiTemp.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layMultiTemp.SetBindVarValue("o_bunho", laySingleTemp.GetItemValue("bunho").ToString());
            layMultiTemp.SetBindVarValue("o_jundal_table", laySingleTemp.GetItemValue("jundal_table").ToString());
            layMultiTemp.SetBindVarValue("o_jundal_part", laySingleTemp.GetItemValue("jundal_part").ToString());
            layMultiTemp.SetBindVarValue("o_gwa", laySingleTemp.GetItemValue("gwa").ToString());
            layMultiTemp.SetBindVarValue("o_chr_key", laySingleTemp.GetItemValue("chr_key").ToString());

            string temp_date = laySingleTemp.GetItemValue("input_date").ToString();

            if (temp_date != "" && temp_date.Length >= 10)
                layMultiTemp.SetBindVarValue("o_input_date", temp_date.Substring(0, 10));
            else
                layMultiTemp.SetBindVarValue("o_input_date", "");
                
            layMultiTemp.SetBindVarValue("o_in_out_gubun", laySingleTemp.GetItemValue("in_out_gubun").ToString());
            layMultiTemp.SetBindVarValue("o_emergency", laySingleTemp.GetItemValue("emergency").ToString());

            temp_date = laySingleTemp.GetItemValue("reser_date").ToString();

            if (temp_date != "" && temp_date.Length >= 10)
                layMultiTemp.SetBindVarValue("o_reser_date", temp_date.Substring(0, 10));
            else
                layMultiTemp.SetBindVarValue("o_reser_date", "");

            layMultiTemp.SetBindVarValue("f_reser_date", aReserDate);

            if (!layMultiTemp.QueryLayout(true))
            {
                //XMessageBox.Show("保存できませんでした。\r\n" + Service.ErrFullMsg, "保存失敗", MessageBoxIcon.Error);
                mErrMSG = "保存できませんでした。\r\n" + Service.ErrFullMsg;
                return false;
            }            

            try
            {
                //Service.BeginTransaction();

                for (int k = 0; k < layMultiTemp.RowCount; k++)
                {
                    tFKOCS = layMultiTemp.GetItemString(k, "fkocs");

                    inputList.Clear();
                    inputList.Add(layMultiTemp.GetItemString(k, "pksch0201"));
                    inputList.Add(layMultiTemp.GetItemString(k, "hangmog_code"));
                    inputList.Add("");
                    if (TypeCheck.IsNull(aReserDate))
                        inputList.Add(DBNull.Value);
                    else
                        inputList.Add(aReserDate);
                    inputList.Add(aReserTime);
                    inputList.Add(UserInfo.UserID);
                    inputList.Add(""); //i_comment
                    inputList.Add(""); //i_suname
                    inputList.Add(aSeq);

                    if (!Service.ExecuteProcedure("PR_SCH_SCH0201_INSERT", inputList, outputList))
                    {
                        //XMessageBox.Show(Service.ErrFullMsg);
                        throw new Exception(Service.ErrFullMsg);
                    }

                    if (outputList.Count > 0)
                    {
                        if (!TypeCheck.IsNull(outputList[0]))
                        {
                            if (outputList[0].ToString() == "X")
                            {
                                throw new Exception("予約可能な人数を超えました。\r\n２枠以上の検査の場合には２枠以上の空き枠が必要です。");
                            } 
                            if (outputList[0].ToString() != "0")
                            {
                                //throw new Exception(outputList[0].ToString() + "\r\n" + Service.ErrFullMsg);
                            }
                        }
                    }

                    if (tJundalTable == "ENDO")
                    {
                        arrayIF.Add(tIOGubun + "\t" + tFKOCS);
                    }
                }
                //Service.CommitTransaction();
                //XMessageBox.Show("保存しました。", "保存", MessageBoxIcon.Error);
            }
            catch(Exception xe)
            {
                //Service.RollbackTransaction();
                mErrMSG = "保存できませんでした。\r\n" + xe.Message + "\r\n";// +xe.StackTrace;
                //XMessageBox.Show("保存できませんでした。\r\n" + xe.Message + "\r\n" + xe.StackTrace, "保存失敗", MessageBoxIcon.Error);
                return false;
            }

            //예약증 출력용
            reser_chk = "Y";
            for (int j = 0; j < grdReserDate.RowCount; j++)
            {
                if (aReserDate == grdReserDate.GetItemValue(j, "reser_date").ToString())
                    reser_chk = "N";
            }

            if (reser_chk == "Y")
            {
                row = grdReserDate.InsertRow();
                grdReserDate.SetItemValue(row, "reser_date", aReserDate);
            }
            return true;
        }

		private bool ReserSave()
		{
			string key, hangmog_code, reser_date, reser_time, seq;
			//int row = 0;

            grdReserDate.Reset();
            mErrMSG = "";
            arrayIF.Clear();

            try
            {
                Service.BeginTransaction();

                for (int i = 1; i <= dwReserList.RowCount; i++)
                {
                    if (dwGetString(dwReserList, i, "reser_chk_yn") == "Y")
                    {
                        key = dwGetString(dwReserList, i, "key").Trim();
                        hangmog_code = dwGetString(dwReserList, i, "hangmog_code").Trim();
                        reser_date = dwGetString(dwReserList, i, "set_reser_date").Trim();
                        reser_time = dwGetString(dwReserList, i, "set_reser_time").Trim();
                        //seq = dwGetString(dwReserList, i, "chk_yn").Trim(); 예약일에서 맥스값가져와야할듯
                        
                        string query = @"SELECT NVL(MAX(A.SEQ), 0 ) + 1 SEQ
                                              FROM SCH0201 A
                                             WHERE A.HOSP_CODE  = :f_hosp_code
                                               AND A.RESER_DATE = :f_reser_date
                                               AND A.BUNHO      = :f_bunho";
                        BindVarCollection bc = new BindVarCollection();
                        bc.Add("f_hosp_code", EnvironInfo.HospCode);
                        bc.Add("f_reser_date", reser_date);
                        bc.Add("f_bunho", this.paBoxPatient.BunHo);
                        object t_seq = Service.ExecuteScalar(query, bc);

                        seq = t_seq.ToString();

                        //io_gubun = dwGetString(dwReserList, i, "emergency").Trim();

                        if (!ChkJubsu(key))
                            throw new Exception();

                        if (!CallSaveService(key, hangmog_code, reser_date, reser_time, seq))
                            throw new Exception();
                    }
                }
                Service.CommitTransaction();

                if (this.cbxIF_YN.Checked)
                {
                    /////////////////////////////////////////////////////////////////////
                    if (arrayIF.Count > 0)
                    {
                        IHIS.Framework.tcpHelper sendIFsocket = new tcpHelper();
                        string tInput = "";

                        foreach (string io_gubun_pkOCS in arrayIF)
                        {
                            tInput = "MX" + "\t" + "UPDATE" + "\t" + io_gubun_pkOCS + "\t" + UserInfo.UserID;
                            sendIFsocket.Send(EnvironInfo.GetInterfaceIP(), EnvironInfo.GetInterfacePort(), tInput);
                        }
                    }
                    //////////////////////////////////////////////////////////////////////
                }
            }
            catch
            {
                Service.RollbackTransaction();
                XMessageBox.Show(mErrMSG,"予約失敗",MessageBoxIcon.Error);
                return false;
            }
            return true;
		}

		#endregion

		#region 예약증 출력
		private void ReserPrint(string gwa, string auto_close)
		{
            if (this.dwReserList.RowCount > 0)
            {
                //검사(진료)예약표 출력
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("auto_close", auto_close);
                openParams.Add("total_query_yn", "N");
                openParams.Add("bunho", this.paBoxPatient.BunHo.ToString());
                //openParams.Add("reser_date", this.xdtReserDate.GetDataValue().ToString());
                openParams.Add("reser_date", dwGetString(dwReserList, dwReserList.CurrentRow, "reser_date"));
                openParams.Add("gwa", gwa);

                XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R98", ScreenOpenStyle.ResponseSizable, openParams);
            }


		}
		#endregion

		#region 취소버튼을 클릭을 했을 때
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계

                if (!ReserCancelSave())
                {
                }
                    //throw new Exception();
			}
			finally
			{
				Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
			}
		}
		#endregion

		#region ReserCancelSave()
		private bool ReserCancelSave()
		{
			string key = string.Empty;

            mErrMSG = "";
            arrayIF.Clear();
            try
            {
                Service.BeginTransaction();

                for (int i = 1; i <= dwReserList.RowCount; i++)
                {
                    if ((dwGetString(dwReserList, i, "reser_chk_yn") == "Y") && (dwGetString(dwReserList, i, "reser_yn") == "Y") &&
                        (dwGetString(dwReserList, i, "ocs0103_jundal_part") != "RI"))
                    {
                        key = dwGetString(dwReserList, i, "key");

                        if (!CallSaveService(key, "", "", "", "0"))
                            throw new Exception();
                    }
                }

                Service.CommitTransaction();

                if (this.cbxIF_YN.Checked)
                {
                    /////////////////////////////////////////////////////////////////////
                    if (arrayIF.Count > 0)
                    {
                        IHIS.Framework.tcpHelper sendIFsocket = new tcpHelper();
                        string tInput = "";

                        foreach (string io_gubun_pkOCS in arrayIF)
                        {
                            tInput = "MX" + "\t" + "DELETE" + "\t" + io_gubun_pkOCS + "\t" + UserInfo.UserID;
                            sendIFsocket.Send(EnvironInfo.GetInterfaceIP(), EnvironInfo.GetInterfacePort(), tInput);
                        }
                    }
                    //////////////////////////////////////////////////////////////////////
                }
            }
            catch
            { 
                Service.RollbackTransaction();
                XMessageBox.Show(mErrMSG, "予約取消し失敗", MessageBoxIcon.Error);
                return false;
            }

			// Reset
			grdReserDate.Reset();
			xdtReserDate.SetDataValue(null);

			this.dwReserList.Reset();
			ClearAll();
			this.ReserQuery();

            return true;
		}
		#endregion
		
		#region 날짜를 변경을 했을 때
		private void dtDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.ReserQuery();
			
			ClearAll();
		}
		#endregion
		
		#region 예약표출력버튼을 클릭을 했을 때
		private void btnReserPrint_Click(object sender, System.EventArgs e)
		{
			// 환자번호가 입력되지 않은 경우는 메세지를 띄우고 return한다.
			// 이인철 2008.09.27. 적용
			if ( this.paBoxPatient.BunHo == "" ) 
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "환자번호를 입력해 주세요."
					: "患者番号を入力してください。");
				XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
			    return;
			}

            if(dwGetString(dwReserList, dwReserList.CurrentRow, "reser_date") != "")
            {
                DateTime dt = Convert.ToDateTime(dwGetString(dwReserList, dwReserList.CurrentRow, "reser_date"));

                if (dt < EnvironInfo.GetSysDate())
                {
                    XMessageBox.Show("過去日付の予約票は発行出来ません。", "印刷失敗", MessageBoxIcon.Information);
                    return;
                }

                if (TypeCheck.IsInt(xemPrintCnt.GetDataValue()))
                {
                    int cnt = Convert.ToInt32(xemPrintCnt.GetDataValue());
                    for (int i = 0; i < cnt; i++)
                    {
                        ReserPrint("%", "Y"); //"Y" 화면 열고 프린트 하고 바로 닫음
                    }
                }
            }
		}
		#endregion

		#region clear
		private void clear_1()
		{
			lbHangmogName_1.Text  = string.Empty;
			lbReserDate_1.Text    = string.Empty;
			txtTime_1.Text        = string.Empty;

			dwReserList_1.Reset();
			dw_1 = false;
		}

		private void clear_2()
		{
			lbHangmogName_2.Text  = string.Empty;
			lbReserDate_2.Text    = string.Empty;
			txtTime_2.Text        = string.Empty;
			
			dwReserList_2.Reset();
			dw_2 = false;
		}

		private void clear_3()
		{
			lbHangmogName_3.Text  = string.Empty;
			lbReserDate_3.Text    = string.Empty;
			txtTime_3.Text        = string.Empty;
			
			dwReserList_3.Reset();
			dw_3 = false;
		}

		private void clear_4()
		{
			lbHangmogName_4.Text  = string.Empty;
			lbReserDate_4.Text    = string.Empty;
			txtTime_4.Text        = string.Empty;
			
			dwReserList_4.Reset();
			dw_4 = false;
		}

		private void clear_5()
		{
			lbHangmogName_5.Text  = string.Empty;
			lbReserDate_5.Text    = string.Empty;
			txtTime_5.Text        = string.Empty;
			
			dwReserList_5.Reset();
			dw_5 = false;
		}

		private void clear_6()
		{
			lbHangmogName_6.Text  = string.Empty;
			lbReserDate_6.Text    = string.Empty;
			txtTime_6.Text        = string.Empty;
			
			dwReserList_6.Reset();
			dw_6 = false;
		}

		private void clear_7()
		{
			lbHangmogName_7.Text  = string.Empty;
			lbReserDate_7.Text    = string.Empty;
			txtTime_7.Text        = string.Empty;
			
			dwReserList_7.Reset();
			dw_7 = false;
		}

		private void clear_8()
		{
			lbHangmogName_8.Text  = string.Empty;
			lbReserDate_8.Text    = string.Empty;
			txtTime_8.Text        = string.Empty;
			
			dwReserList_8.Reset();
			dw_8 = false;
		}

		private void clear_9()
		{
			lbHangmogName_9.Text  = string.Empty;
			lbReserDate_9.Text    = string.Empty;
			txtTime_9.Text        = string.Empty;
			
			dwReserList_9.Reset();
			dw_9 = false;
		}

		private void clear_10()
		{
			lbHangmogName_10.Text  = string.Empty;
			lbReserDate_10.Text    = string.Empty;
			txtTime_10.Text        = string.Empty;
			
			dwReserList_10.Reset();
			dw_10 = false;
		}
		#endregion

		#region ReserTimeList Click
		private void dwReserList_1_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_1.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;
			
			// 시간 지정이 필요 없는것
            if (!txtTime_1.Enabled) return;

			// 선택시간에 예약되어 있는 경우
			string suname = dwGetString(dwReserList_1, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}			

			string reser_time = dwGetString(dwReserList_1, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("1", reser_time)) return;

			txtTime_1.SetDataValue(reser_time);
			SetdwReserList("1", "set_reser_time", reser_time);

			lbHangmogName_1.ForeColor = XColor.DisabledForeColor;
			lbReserDate_1.ForeColor   = XColor.DisabledForeColor;

			dwReserList_1.Refresh();
		}



		private void dwReserList_2_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_2.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;

			//시간 지정이 필요 없는것
			if (!txtTime_2.Enabled) return;

			string suname = dwGetString(dwReserList_2, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}
			
			string reser_time = dwGetString(dwReserList_2, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("2", reser_time)) return;

			txtTime_2.SetDataValue(reser_time);
			SetdwReserList("2", "set_reser_time", reser_time);

			lbHangmogName_2.ForeColor = XColor.DisabledForeColor;
			lbReserDate_2.ForeColor   = XColor.DisabledForeColor;

			dwReserList_2.Refresh();
		}

		private void dwReserList_3_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_3.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;

			//시간 지정이 필요 없는것
			if (!txtTime_3.Enabled) return;

			string suname = dwGetString(dwReserList_3, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}
			
			string reser_time = dwGetString(dwReserList_3, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("3", reser_time)) return;

			txtTime_3.SetDataValue(reser_time);
			SetdwReserList("3", "set_reser_time", reser_time);

			lbHangmogName_3.ForeColor = XColor.DisabledForeColor;
			lbReserDate_3.ForeColor   = XColor.DisabledForeColor;

			dwReserList_3.Refresh();
		}

		private void dwReserList_4_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_4.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;

			//시간 지정이 필요 없는것
			if (!txtTime_4.Enabled) return;

			string suname = dwGetString(dwReserList_4, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}
			
			string reser_time = dwGetString(dwReserList_4, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("4", reser_time)) return;

			txtTime_4.SetDataValue(reser_time);
			SetdwReserList("4", "set_reser_time", reser_time);

			lbHangmogName_4.ForeColor = XColor.DisabledForeColor;
			lbReserDate_4.ForeColor   = XColor.DisabledForeColor;

			dwReserList_4.Refresh();
		}

		private void dwReserList_5_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_5.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;

			//시간 지정이 필요 없는것
			if (!txtTime_5.Enabled) return;

			string suname = dwGetString(dwReserList_5, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}
			
			string reser_time = dwGetString(dwReserList_5, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("5", reser_time)) return;

			txtTime_5.SetDataValue(reser_time);
			SetdwReserList("5", "set_reser_time", reser_time);

			lbHangmogName_5.ForeColor = XColor.DisabledForeColor;
			lbReserDate_5.ForeColor   = XColor.DisabledForeColor;

			dwReserList_5.Refresh();
		}

		private void dwReserList_6_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_6.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;

			//시간 지정이 필요 없는것
			if (!txtTime_6.Enabled) return;

			string suname = dwGetString(dwReserList_6, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}
			
			string reser_time = dwGetString(dwReserList_6, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("6", reser_time)) return;

			txtTime_6.SetDataValue(reser_time);
			SetdwReserList("6", "set_reser_time", reser_time);

			lbHangmogName_6.ForeColor = XColor.DisabledForeColor;
			lbReserDate_6.ForeColor   = XColor.DisabledForeColor;

			dwReserList_6.Refresh();		
		}

		private void dwReserList_7_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_7.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;

			//시간 지정이 필요 없는것
			if (!txtTime_7.Enabled) return;

			string suname = dwGetString(dwReserList_7, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}
			
			string reser_time = dwGetString(dwReserList_7, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("7", reser_time)) return;

			txtTime_7.SetDataValue(reser_time);
			SetdwReserList("7", "set_reser_time", reser_time);

			lbHangmogName_7.ForeColor = XColor.DisabledForeColor;
			lbReserDate_7.ForeColor   = XColor.DisabledForeColor;

			dwReserList_7.Refresh();		
		}

		private void dwReserList_8_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_8.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;

			//시간 지정이 필요 없는것
			if (!txtTime_8.Enabled) return;

			string suname = dwGetString(dwReserList_8, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}
			
			string reser_time = dwGetString(dwReserList_8, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("8", reser_time)) return;

			txtTime_8.SetDataValue(reser_time);
			SetdwReserList("8", "set_reser_time", reser_time);

			lbHangmogName_8.ForeColor = XColor.DisabledForeColor;
			lbReserDate_8.ForeColor   = XColor.DisabledForeColor;

			dwReserList_8.Refresh();		
		}

		private void dwReserList_9_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_9.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;

			//시간 지정이 필요 없는것
			if (!txtTime_9.Enabled) return;

			string suname = dwGetString(dwReserList_9, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}
			
			string reser_time = dwGetString(dwReserList_9, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("9", reser_time)) return;

			txtTime_9.SetDataValue(reser_time);
			SetdwReserList("9", "set_reser_time", reser_time);

			lbHangmogName_9.ForeColor = XColor.DisabledForeColor;
			lbReserDate_9.ForeColor   = XColor.DisabledForeColor;

			dwReserList_9.Refresh();
		}

		private void dwReserList_10_Click(object sender, System.EventArgs e)
		{
			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_10.ObjectUnderMouse;
			int    row = oap.RowNumber;			
			if (row < 1) return;

			//시간 지정이 필요 없는것
			if (!txtTime_10.Enabled) return;

			string suname = dwGetString(dwReserList_10, row, "suname");
			if (suname.Trim() != "")
			{
				XMessageBox.Show("空いている予約時間を選択してください。");
				return;
			}
			
			string reser_time = dwGetString(dwReserList_10, row, "reser_time");

			// 예약가능 체크
			if (ReserTimeCheck("10", reser_time)) return;

			//예약시간 지정
			txtTime_10.SetDataValue(reser_time);
			SetdwReserList("10", "set_reser_time", reser_time);

			lbHangmogName_10.ForeColor = XColor.DisabledForeColor;
			lbReserDate_10.ForeColor   = XColor.DisabledForeColor;

			dwReserList_10.Refresh();
		}
		#endregion

		#region 한 환자에 대해 같은날 같은시간에 다른 검사 동시에 잡는거 막기
		/* 원래주석
				private bool ShowMessage(string seq, string date, string time)
		{
			string other_jundal_part = string.Empty;

			//true이면 예약잡아도 되고 아니면 예약잡으면 안됨

			//예약시간
			string current_text = date+time.Replace(":","");

			string other_text_1 = this.lbReserDate_1.Text + this.txtTime_1.Text.Replace(":","");
			string other_text_2 = this.lbReserDate_2.Text + this.txtTime_2.Text.Replace(":","");
			string other_text_3 = this.lbReserDate_3.Text + this.txtTime_3.Text.Replace(":","");
			string other_text_4 = this.lbReserDate_4.Text + this.txtTime_4.Text.Replace(":","");
			string other_text_5 = this.lbReserDate_5.Text + this.txtTime_5.Text.Replace(":","");
			
			//전달파트
			if (seq == "1")
				other_jundal_part = this.txtJundalPart_1.Text;
			else if (seq == "2")
				other_jundal_part = this.txtJundalPart_2.Text;
			else if (seq == "3")
				other_jundal_part = this.txtJundalPart_3.Text;
			else if (seq == "4")
				other_jundal_part = this.txtJundalPart_4.Text;
			else if (seq == "5")				
				other_jundal_part = this.txtJundalPart_5.Text;

			if ((other_jundal_part == "EYE") || (other_jundal_part == "CHP") || (other_jundal_part == "CPL"))
			{
				return true;
			}

			//  안과와 검체검사는 제외한다.
			if ( seq == "1" )
			{
				if ( current_text == other_text_2 || current_text == other_text_3 || current_text == other_text_4 || current_text == other_text_5 )
				{
					string msg = (NetInfo.Language == LangMode.Ko ? "이미 예약이 잡힌 예정시간입니다."
						: "既に予約されている予定時間です。");
					XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
					return false;
				}
			}
			else if ( seq == "2" )
			{
				if ( current_text == other_text_1 || current_text == other_text_3 || current_text == other_text_4 || current_text == other_text_5 )
				{
					string msg = (NetInfo.Language == LangMode.Ko ? "이미 예약이 잡힌 예정시간입니다."
						: "既に予約されている予定時間です。");
					XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
					return false;
				}
			}
			else if ( seq == "3" )
			{
				if ( current_text == other_text_1 || current_text == other_text_2 || current_text == other_text_4 || current_text == other_text_5 )
				{
					string msg = (NetInfo.Language == LangMode.Ko ? "이미 예약이 잡힌 예정시간입니다."
						: "既に予約されている予定時間です。");
					XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
					return false;
				}
			}
			else if ( seq == "4" )
			{
				if ( current_text == other_text_1 || current_text == other_text_2 || current_text == other_text_3 || current_text == other_text_5 )
				{
					string msg = (NetInfo.Language == LangMode.Ko ? "이미 예약이 잡힌 예정시간입니다."
						: "既に予約されている予定時間です。");
					XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
					return false;
				}
			}
			else if ( seq == "5" )
			{
				if ( current_text == other_text_1 || current_text == other_text_2 || current_text == other_text_3 || current_text == other_text_4 )
				{
					string msg = (NetInfo.Language == LangMode.Ko ? "이미 예약이 잡힌 예정시간입니다."
						: "既に予約されている予定時間です。");
					XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
					return false;
				}
			}

			return true;
		}
*/
		#endregion

		#region AutoSetTime [jundal_table, jundal_part 가 같은경우는 같은 시간으로 Set]
		private void AutoSetTime(string dw_bunho, string reser_time)
		{
			if (reser_time == "") return;

			string jundal_table     = "";
			string jundal_part      = "";			
			string cur_jundal_table = "";
			string cur_jundal_part  = "";
			string cur_dw_bunho     = "";

			//선택된 DW
			for (int i = 1 ; i <= dwReserList.RowCount ; i++)
			{
				if (dw_bunho == dwGetString(dwReserList, i, "chk_yn"))
				{
					jundal_table = dwGetString(dwReserList, i, "jundal_table");
					jundal_part  = dwGetString(dwReserList, i, "jundal_part");
				}
			}

			//
			for (int j = 1 ; j <= dwReserList.RowCount ; j++)
			{
				cur_jundal_table = dwGetString(dwReserList, j, "jundal_table").Trim();
				cur_jundal_part  = dwGetString(dwReserList, j, "jundal_part").Trim();
				cur_dw_bunho     = dwGetString(dwReserList, j, "chk_yn").Trim();

				if ((cur_dw_bunho != "") && (jundal_table == cur_jundal_table) && (jundal_part == cur_jundal_part))
				{
					dwReserList.SetItemString(j, "set_reser_time", reser_time);

					#region txt time set
					if (cur_dw_bunho == "1")
						txtTime_1.Text = reser_time;
					else if (cur_dw_bunho == "2")
						txtTime_2.Text = reser_time;
					else if (cur_dw_bunho == "3")
						txtTime_3.Text = reser_time;
					else if (cur_dw_bunho == "4")
						txtTime_4.Text = reser_time;
					else if (cur_dw_bunho == "5")
						txtTime_5.Text = reser_time;
					else if (cur_dw_bunho == "6")
						txtTime_6.Text = reser_time;
					else if (cur_dw_bunho == "7")
						txtTime_7.Text = reser_time;
					else if (cur_dw_bunho == "8")
						txtTime_8.Text = reser_time;
					else if (cur_dw_bunho == "9")
						txtTime_9.Text = reser_time;
					else if (cur_dw_bunho == "10")
						txtTime_10.Text = reser_time;
					#endregion
				}
			}

			dwReserList.AcceptText();

		}
		#endregion

		#region ReserTimeCheck [예약시간 체크]
		private bool ReserTimeCheck(string dw_bunho, string reser_time)
		{
			string jundal_table     = "";
			string jundal_part      = "";
			string in_out_gubun     = "";

			string cur_jundal_table = "";
			string cur_jundal_part  = "";
			string cur_dw_bunho     = "";
			string cur_reser_date   = "";
			string cur_reser_time   = "";
			
			//선택된 DW
			for (int i = 1 ; i <= dwReserList.RowCount ; i++)
			{
				if (dw_bunho == dwGetString(dwReserList, i, "chk_yn"))
				{
					jundal_table = dwGetString(dwReserList, i, "jundal_table").Trim();
					jundal_part  = dwGetString(dwReserList, i, "jundal_part").Trim();
					reser_date   = dwGetString(dwReserList, i, "set_reser_date").Trim().Replace("-","/");					
					hangmog_code = dwGetString(dwReserList, i, "hangmog_code").Trim();
					in_out_gubun = dwGetString(dwReserList, i, "emergency").Trim();
				}
			}

			// 화면에 있는거 체크
			for (int j = 1 ; j <= dwReserList.RowCount ; j++)
			{
				cur_jundal_table = dwGetString(dwReserList, j, "jundal_table").Trim();
				cur_jundal_part  = dwGetString(dwReserList, j, "jundal_part").Trim();
				cur_reser_date   = dwGetString(dwReserList, j, "set_reser_date").Trim().Replace("-","/");
				cur_reser_time   = dwGetString(dwReserList, j, "set_reser_time").Trim();
				cur_dw_bunho     = dwGetString(dwReserList, j, "chk_yn").Trim();

				// 10.03.18
//				if ((jundal_table != cur_jundal_table) || (jundal_part != cur_jundal_part))
//				{
					if ( (cur_dw_bunho != dw_bunho) && (reser_date == cur_reser_date) && (reser_time == cur_reser_time))
					{
						string msg = (NetInfo.Language == LangMode.Ko ? "동일동시간와꾸에 다른 검사예약이 들어있습니다.그대로 검사예약을 등록하겠습니까"
							: "同日同時間枠に別の検査予約が入っています。" + "\n\r" + "そのまま検査予約を登録しますか？");
						if (XMessageBox.Show( msg,"確認", MessageBoxButtons.YesNo ) == DialogResult.Yes)
                            return false;
						else
							return true;
					}
//				}
			}

            // 서버에 있는거 체크
            layReserTimeChk.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			layReserTimeChk.SetBindVarValue("f_bunho", paBoxPatient.BunHo);
            layReserTimeChk.SetBindVarValue("f_reser_date", reser_date);
            layReserTimeChk.SetBindVarValue("f_reser_time", reser_time);

            if (layReserTimeChk.QueryLayout())
			{
				if (layReserTimeChk.GetItemValue("reser_chk").ToString() == "Y")
				{
					string msg = (NetInfo.Language == LangMode.Ko ? "동일동시간와꾸에 다른 검사예약이 들어있습니다.그대로 검사예약을 등록하겠습니까"
						: "同日同時間枠に別の検査予約が入っています。" + "\n\r" + "そのまま検査予約を登録しますか？");
					if (XMessageBox.Show( msg,"確認", MessageBoxButtons.YesNo ) == DialogResult.Yes)
						return false;
					else
						return true;
				}
			}



			//내시경 응급체크 hsy 01.01.22
			if ((jundal_part == "ENDO") || (jundal_part == "ENDO_1") || (jundal_part == "ENDO_2") || (jundal_part == "ENDO_3") || (jundal_part == "ENDO_4") || (jundal_part == "ENDO_5") || (jundal_part == "ENDO_6"))
			{
				// 예약일자 및 시간지정
				if ( Double.Parse(reser_date.Replace("-","").Replace("/","") + reser_time) <= Double.Parse(EnvironInfo.GetSysDateTime().ToString("yyyyMMddHHmm")))
				{
					if (in_out_gubun == "Y")
					{
						string msg = (NetInfo.Language == LangMode.Ko ? "예약시간이 넘었습니다. 내시경에 연락해주세요."
							: "予約の時間が過ぎています。"+ "\n\r" +"内視鏡に連絡してください。");
						XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
						return true;
					}
					else
					{
						string msg = (NetInfo.Language == LangMode.Ko ? "예약시간이 넘었습니다. 확인해주세요."
							: "予約の時間が過ぎています。"+ "\n\r" +"ご確認ください。");
						XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
						return false;
					}
				}
			}

            /* 일단 주석처리 2010/10/07

			// 방사선 체크
			if ((jundal_part == "MRI") || (jundal_part == "MRI_1") || (jundal_part == "MR2"))
			{
				// 외래환자 예약시간 체크
				if ((in_out_gubun == "O") && (int.Parse(reser_time) > int.Parse("1720")))
				{
					string msg = (NetInfo.Language == LangMode.Ko ? "病棟患者用の予約枠に外来患者を予約しますか？"
						: "病棟患者用の予約枠に外来患者を予約しますか");

					if (XMessageBox.Show( msg,"確認", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						return true;
					}
				}
			}
             * */

			return false;
		}
		#endregion

		#region 예약인원체크
		private string ReserInwonChk(string dw_bunho)
		{
			//선택된 DW
			for (int i = 1 ; i <= dwReserList.RowCount ; i++)
			{
				if (dw_bunho == dwGetString(dwReserList, i, "chk_yn"))
				{
					jundal_table = dwGetString(dwReserList, i, "jundal_table").Trim();
					jundal_part  = dwGetString(dwReserList, i, "jundal_part").Trim();
					reser_date   = dwGetString(dwReserList, i, "set_reser_date").Trim().Replace("-","/");
				}
			}

            layAddInwonChk.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			layAddInwonChk.SetBindVarValue("f_jundal_table", jundal_table);
            layAddInwonChk.SetBindVarValue("f_jundal_part", jundal_part);
            layAddInwonChk.SetBindVarValue("f_reser_date", reser_date);

            layAddInwonChk.QueryLayout();

			return layAddInwonChk.GetItemValue("reser_chk").ToString();
		}
		#endregion

		#region RwoFocusChanged
		private void dwReserAMList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_1.Refresh();
		}
		
		private void dwReserList_2_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_2.Refresh();
		}

		private void dwReserList_3_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_3.Refresh();
		}

		private void dwReserList_4_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_4.Refresh();
		}

		private void dwReserList_5_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_5.Refresh();
		}

		private void dwReserList_6_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_6.Refresh();
		}

		private void dwReserList_7_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_7.Refresh();
		}

		private void dwReserList_8_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_8.Refresh();
		}

		private void dwReserList_9_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_9.Refresh();
		}

		private void dwReserList_10_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList_10.Refresh();
		}
		#endregion

		private void btnComment_Click(object sender, System.EventArgs e)
		{
            if (this.paBoxPatient.BunHo == "")
                return;

            if (this.dwReserList.RowCount < 1)
                return;

            if (this.dwReserList.CurrentRow < 0)
                return;

			string bunho = paBoxPatient.BunHo;
            string reser_date = dwGetString(dwReserList, dwReserList.CurrentRow , "reser_date");

            if (reser_date == "")
            {
                XMessageBox.Show("予約コメントは予約済みの項目にのみ入力可能です。", "注意", MessageBoxIcon.Warning);
                return;
            }

			#region gwa
			string gwa = string.Empty;

            layLoginGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			layLoginGwa.SetBindVarValue("f_user_id", UserInfo.UserID);

            if (layLoginGwa.QueryLayout())
				gwa = layLoginGwa.GetItemValue("gwa").ToString();
			else
				gwa = UserInfo.Gwa;

            if (gwa == "")
                gwa = "%";

			if (IHIS.Framework.EnvironInfo.CurrSystemID == "HPCS")	gwa = "HC";					
			if (IHIS.Framework.EnvironInfo.CurrSystemID == "AKUS")	gwa = "08";			
			if (gwa == "OUT")	gwa = "01";
			#endregion

			FINDComment dlg = new FINDComment(bunho, reser_date, gwa);
		    
			dlg.ShowDialog();
		}

		private void btnReserList_Click(object sender, System.EventArgs e)
		{
			int row = dwReserList.CurrentRow;
			if (row < 1) return;

			//string reser_date = xdtReserDate.GetDataValue().ToString();
            string jundalpart = dwGetString(dwReserList, row, "jundal_part");
            if (jundalpart != "CPL") return;
			string bunho = paBoxPatient.BunHo;

			string reser_date = dwGetString(dwReserList, row, "reser_date");
			string order_date = dwGetString(dwReserList, row, "order_date");

			FINDReserList dlg = new FINDReserList(bunho, reser_date, order_date, jundalpart);
		    
			dlg.ShowDialog();
		}

        //private void xButton1_Click(object sender, System.EventArgs e)
        //{
        //    string reser_time = "";
        //    string reser_chk  = "N";
        //    string dw_bunho   = "1";
        //    XDataWindow dw = dwReserList_1;

        //    int    row = dw.CurrentRow;
        //    if (row<1) return;

			
        //    // 예약 체크
        //    reser_chk = ReserInwonChk(dw_bunho);
        //    if (reser_chk == "Y")
        //    {
        //        XMessageBox.Show("時間を選んでください。");
        //        return;
        //    }
        //    if (reser_chk == "Z")
        //    {
        //        reser_time = dwGetString(dw, dw.RowCount, "reser_time").Trim();

        //        // 예약가능 체크
        //        if (ReserTimeCheck(dw_bunho, reser_time)) return;
        //        txtTime_1.SetDataValue(reser_time);
        //        SetdwReserList(dw_bunho, "set_reser_time", reser_time);
        //        return;
        //    }
        //    else
        //    {
        //        // 건진 환자는 예약할수 있게 한다
        //        if (IHIS.Framework.EnvironInfo.CurrSystemID == "HPCS")
        //        {
        //            reser_time = dwGetString(dw, dw.RowCount, "reser_time").Trim();

        //            // 예약가능 체크
        //            if (ReserTimeCheck(dw_bunho, reser_time)) return;
        //            txtTime_1.SetDataValue(reser_time);
        //            SetdwReserList(dw_bunho, "set_reser_time", reser_time);
        //            return;
        //        }
			
        //        XMessageBox.Show("人員を超過しました。");
        //        return;
        //    }
        //}		

        //예약순번버튼
		private void xButton1_Click_1(object sender, System.EventArgs e)
		{
			IHIS.Framework.IXScreen aScreen;

			int row = dwReserList.CurrentRow;
			if (row < 1) return;

			string bunho = paBoxPatient.BunHo;

			aScreen = XScreen.FindScreen("SCHS", "SCH0201U10");

			if (aScreen == null)
			{
				
				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add( "bunho", bunho);

				XScreen.OpenScreenWithParam(this,"SCHS", "SCH0201U10", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
			}
			else
			{
				((XScreen)aScreen).Activate();
			}
		}

		private void dwReserList_ItemChanged(object sender, Sybase.DataWindow.ItemChangedEventArgs e)
		{
			// 핵의학은 취소가 불가능
			if (dwGetString(dwReserList, e.RowNumber, "ocs0103_jundal_part") == "RI" && e.RowNumber >= 1)
			{
				PostCallHelper.PostCall(new PostMethod(Dw));
				return;
			}
			
			// 접수건 취소시 에러메시지
			if (dwGetString(dwReserList, dwReserList.CurrentRow, "reser_chk_yn") == "N" && e.RowNumber >= 1)
			{
				string hangmogCode, key;

				key         = dwGetString(dwReserList, dwReserList.CurrentRow, "key").Trim();
				
				if (!ChkJubsu(key))
				{
					PostCallHelper.PostCall(new PostMethod(Dw2));
					return;
				}
			}
						//접수된 건은 검사예약화면에 보여 주되, 예약취소는 할 수 없다.
			//자동접수처리 되는 JUNDAL_PART가 ('NUT','NUE')인 오더는 제외(예약 변경이 가능함)
			//메세지 처리.
			//if (dwGetString(dwReserList, e.RowNumber, "jubsu_yn") == "Y" && e.RowNumber >= 1)
			//{
			//	PostCallHelper.PostCall(new PostMethod(Dw2));
			//	return;
			//}
		}

		private void Dw()
		{
			string msg = (NetInfo.Language == LangMode.Ko ? "핵의학 검사예약은 방사선과에 연락하여 주십시오."
						: "核医学検査予約は放射線科にご連絡ください。");
			XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
			this.dwReserList.SetItemString(this.dwReserList.CurrentRow, "reser_chk_yn", "N");
			this.dwReserList.AcceptText();
		}

		private void Dw2()
		{
			this.dwReserList.SetItemString(this.dwReserList.CurrentRow, "reser_chk_yn", "N");
			this.dwReserList.AcceptText();
		}
        

		#region 접수유무 체크(에러나고 있음)
		private bool ChkJubsu(string key)
        {
            string cmdText = @" SELECT FKOCS
                                      ,JUNDAL_TABLE
                                  FROM SCH0201
                                 WHERE HOSP_CODE = :f_hosp_code 
                                   AND PKSCH0201 = :f_pksch0201";

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_pksch0201", key);

            DataTable dt = Service.ExecuteDataTable(cmdText, bc);

            if (!TypeCheck.IsNull(dt))
            {

                layJubsuChk.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                layJubsuChk.SetBindVarValue("o_fkocs", dt.Rows[0]["fkocs"].ToString());
                layJubsuChk.SetBindVarValue("o_jundal_table", dt.Rows[0]["jundal_table"].ToString());

                // 예약
                layJubsuChk.QueryLayout();
                if (layJubsuChk.GetItemValue("jubsu_chk").ToString() == "Y")
                {
                    XMessageBox.Show("検査部署で受付されました。受付取消後予約してください。", "確認");
                    return false;
                }
            }
			return true;
		}
		#endregion

		#region 검사예약화면이 활성화 될때 다시 재조회 해온다.
		private void SCH0201U00_Enter(object sender, System.EventArgs e)
		{
            //this.dwReserList.Reset();
            //clear_1();
            //clear_2();
            //clear_3();
            //clear_4();
            //clear_5();
            //this.ReserQuery();
		}
		#endregion

		private void dwReserList_1_MouseHover(object sender, System.EventArgs e)
		{
//			Sybase.DataWindow.ObjectAtPointer oap = dwReserList_1.ObjectUnderMouse;
//			int row = oap.RowNumber;
//			//int lbX = oap.Gob.X;
//			//int lbY = oap.Gob.Y;
//
//			//MessageBox.Show(row.ToString());
//			if (row < 1) return;
//			
//			lbText.Text = "";
//			lbText.Visible = false;
//			lbText.Text = dwGetString(dwReserList_1, row, "suname").Trim() + ", "+ dwGetString(dwReserList_1, row, "doctor_name").Trim();
//
//			if(lbText.Text != "")
//			{
//				
//				lbText.Visible = true;
//			}
		}

        private void layDoctorList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDoctorList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDoctorList.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
        }


        bool isCallQueryEnd = true;
        private void layReserList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (!isCallQueryEnd)
                return;

            string o_jundal_table, o_jundal_part, o_hangmog_code, o_emergency;

            for (int i = 0; i < layReserList.RowCount; i++)
            {
                o_jundal_table = this.layReserList.GetItemString(i, "jundal_table");
                o_jundal_part = this.layReserList.GetItemString(i, "jundal_part");
                o_hangmog_code = this.layReserList.GetItemString(i, "hangmog_code");
                o_emergency = this.layReserList.GetItemString(i, "emergency");

                this.layLoadRES0101.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.layLoadRES0101.SetBindVarValue("f_bunho", this.paBoxPatient.BunHo.ToString());
                this.layLoadRES0101.SetBindVarValue("f_doctor", this.cboDoctor.GetDataValue().ToString());
                this.layLoadRES0101.SetBindVarValue("f_reser_date", dtDate.GetDataValue());
                this.layLoadRES0101.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue().ToString());

                this.layLoadRES0101.SetBindVarValue("o_jundal_table", o_jundal_table);
                this.layLoadRES0101.SetBindVarValue("o_jundal_part", o_jundal_part);
                this.layLoadRES0101.SetBindVarValue("o_hangmog_code", o_hangmog_code);
                this.layLoadRES0101.SetBindVarValue("o_emergency", o_emergency);

                this.layLoadRES0101.QueryLayout(true);

                for (int j = 0; j < layLoadRES0101.RowCount; j++)
                {
                    if (this.layLoadRES0101.GetItemString(j, "day") == "01" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_1", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "02" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_2", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "03" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_3", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "04" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_4", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "05" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_5", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "06" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_6", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "07" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_7", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "08" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_8", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "09" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_9", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "10" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_10", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "11" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_11", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "12" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_12", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "13" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_13", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "14" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_14", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "15" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_15", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "16" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_16", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "17" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_17", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "18" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_18", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "19" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_19", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "20" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_20", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "21" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_21", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "22" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_22", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "23" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_23", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "24" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_24", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "25" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_25", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "26" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_26", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "27" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_27", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "28" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_28", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "29" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_29", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "30" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_30", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "31" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_31", "Y");

                    if (this.layLoadRES0101.GetItemString(j, "day") == "01" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_1", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "02" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_2", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "03" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_3", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "04" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_4", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "05" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_5", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "06" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_6", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "07" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_7", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "08" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_8", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "09" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_9", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "10" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_10", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "11" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_11", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "12" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_12", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "13" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_13", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "14" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_14", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "15" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_15", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "16" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_16", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "17" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_17", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "18" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_18", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "19" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_19", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "20" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_20", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "21" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_21", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "22" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_22", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "23" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_23", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "24" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_24", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "25" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_25", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "26" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_26", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "27" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_27", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "28" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_28", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "29" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_29", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "30" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_30", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "31" && this.layLoadRES0101.GetItemString(j, "res") == "Y")
                        this.layReserList.SetItemValue(i, "res_31", "Y");
                }
            }
        }

        private void layTimeList_QueryStarting(object sender, CancelEventArgs e)
        {
            Service.ExecuteProcedure("PR_SCH_TIME_LIST", Service.ClientIP, jundal_table, jundal_part, hangmog_code, xdtReserDate.GetDataValue());
        }

        private void layTimeList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            BindVarCollection bc = new BindVarCollection();
            bc.Add("q_ip_addr", Service.ClientIP);
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            Service.ExecuteNonQuery("DELETE SCH_TEMP WHERE IP_ADDRESS = :q_ip_addr AND HOSP_CODE = :f_hosp_code", bc);
        }

        private void btnResend_Click(object sender, EventArgs e)
        {
            if (!this.cbxIF_YN.Checked)
                return;
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계

                if (!ReserResend())
                {
                }
                //throw new Exception();
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
            }
        }

        #region ReserResend()
        private bool ReserResend()
        {
            string key = "";
            string jundal_table = "";
            string send_mode = "";

            mErrMSG = "";
            arrayIF.Clear();
            try
            {
                IHIS.Framework.tcpHelper sendIFsocket = new tcpHelper();
                string tInput = "";
                string io_gubun_pkOCS = "";

                for (int i = 1; i <= dwReserList.RowCount; i++)
                {
                    if ((dwGetString(dwReserList, i, "reser_chk_yn") == "Y") &&
                        (dwGetString(dwReserList, i, "ocs0103_jundal_part") != "RI"))
                    {
                        key = dwGetString(dwReserList, i, "key");
                        jundal_table = dwGetString(dwReserList, i, "jundal_table");

                        if (jundal_table == "ENDO")
                        {
                            //arrayIF.Add(tIOGubun + "\t" + tFKOCS);
                            io_gubun_pkOCS = dwGetString(dwReserList, i, "in_out_gubun") + "\t" + dwGetString(dwReserList, i, "pkocs");

                            if (dwGetString(dwReserList, i, "reser_yn") == "Y")
                                send_mode = "UPDATE";
                            else
                                send_mode = "DELETE";

                            tInput = "MX" + "\t" + send_mode + "\t" + io_gubun_pkOCS + "\t" + UserInfo.UserID;
                            sendIFsocket.Send(EnvironInfo.GetInterfaceIP(), EnvironInfo.GetInterfacePort(), tInput);
                        }
                    }                    
                }
                
            }
            catch
            {
                XMessageBox.Show("予約情報の再転送に失敗しました", "エラー", MessageBoxIcon.Error);
                return false;
            }

            //// Reset
            //grdReserDate.Reset();
            //xdtReserDate.SetDataValue(null);

            //this.dwReserList.Reset();
            //ClearAll();
            //this.ReserQuery();

            return true;
        }
        #endregion
    }
}

