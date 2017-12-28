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

namespace IHIS.OCSI
{
	/// <summary>
	/// OCS2003U10에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS2003U10 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 

		private IHIS.OCS.PatientInfo mPatientInfo = null;     // OCS 환자정보 그룹 라이브러리 
		#endregion

		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		//등록번호
		private string mBunho = "";
		//입원Key
        //private int mFkinp1001 = 0;
		//처방일자
		private string mOrder_date = "";

		//Data가 없는 경우 화면 닫을지 여부
		private bool mAuto_close = false;

        // Hospital Code
        private string mHospCode = EnvironInfo.HospCode;
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPanel xPanel5;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel lblSelectOrder;
		private IHIS.Framework.XEditGrid grdOCS2003;
		private IHIS.Framework.XEditGridCell xEditGridCell178;
		private IHIS.Framework.XEditGridCell xEditGridCell179;
		private IHIS.Framework.XEditGridCell xEditGridCell180;
		private IHIS.Framework.XEditGridCell xEditGridCell181;
		private IHIS.Framework.XEditGridCell xEditGridCell183;
		private IHIS.Framework.XEditGridCell xEditGridCell182;
		private IHIS.Framework.XEditGridCell xEditGridCell185;
		private IHIS.Framework.XEditGridCell xEditGridCell186;
		private IHIS.Framework.XEditGridCell xEditGridCell187;
		private IHIS.Framework.XEditGridCell xEditGridCell188;
		private IHIS.Framework.XEditGridCell xEditGridCell189;
		private IHIS.Framework.XEditGridCell xEditGridCell280;
		private IHIS.Framework.XEditGridCell xEditGridCellhangmog_code;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
        private IHIS.Framework.XEditGridCell xEditGridCell150;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCellspecimen_code;
		private IHIS.Framework.XEditGridCell xEditGridCellSuryang;
		private IHIS.Framework.XEditGridCell xEditGridCellsubul_suryang;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCelldv_time;
		private IHIS.Framework.XEditGridCell xEditGridCelldv;
		private IHIS.Framework.XEditGridCell xEditGridCell296;
		private IHIS.Framework.XEditGridCell xEditGridCell297;
		private IHIS.Framework.XEditGridCell xEditGridCell298;
		private IHIS.Framework.XEditGridCell xEditGridCell299;
		private IHIS.Framework.XEditGridCell xEditGridCellNalsu;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell155;
		private IHIS.Framework.XEditGridCell xEditGridCell156;
		private IHIS.Framework.XEditGridCell xEditGridCell259;
		private IHIS.Framework.XEditGridCell xEditGridCelljundal_part;
		private IHIS.Framework.XEditGridCell xEditGridCell260;
		private IHIS.Framework.XEditGridCell xEditGridCell157;
		private IHIS.Framework.XEditGridCell xEditGridCellmuhyo;
        private IHIS.Framework.XEditGridCell xEditGridCellportable_yn;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCellpay;
		private IHIS.Framework.XEditGridCell xEditGridCell159;
		private IHIS.Framework.XEditGridCell xEditGridCell160;
		private IHIS.Framework.XEditGridCell xEditGridCell161;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell162;
		private IHIS.Framework.XEditGridCell xEditGridCell163;
		private IHIS.Framework.XEditGridCell xEditGridCell190;
		private IHIS.Framework.XEditGridCell xEditGridCell1dc_gubun;
		private IHIS.Framework.XEditGridCell xEditGridCell164;
		private IHIS.Framework.XEditGridCell xEditGridCell166;
		private IHIS.Framework.XEditGridCell xEditGridCell167;
        private IHIS.Framework.XEditGridCell xEditGridCell168;
		private IHIS.Framework.XEditGridCell xEditGridCellamt;
		private IHIS.Framework.XEditGridCell xEditGridCell170;
		private IHIS.Framework.XEditGridCell xEditGridCell73;
		private IHIS.Framework.XEditGridCell xEditGridCell171;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell172;
		private IHIS.Framework.XEditGridCell xEditGridCell173;
        private IHIS.Framework.XEditGridCell xEditGridCell174;
		private IHIS.Framework.XEditGridCell xEditGridCell175;
		private IHIS.Framework.XEditGridCell xEditGridCellbichi_yn;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell57;
        private IHIS.Framework.XEditGridCell xEditGridCell289;
        private IHIS.Framework.XEditGridCell xEditGridCellpowder_yn;
		private IHIS.Framework.XEditGridCell xEditGridCellhope_date;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCellMix;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell77;
		private IHIS.Framework.XEditGridCell xEditGridCell78;
		private IHIS.Framework.XEditGridCell xEditGridCell79;
		private IHIS.Framework.XEditGridCell xEditGridCell98;
		private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
		private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell105;
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
		private IHIS.Framework.XEditGridCell xEditGridCelltoiwon_drg_yn;
		private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XEditGridCell xEditGridCell110;
		private IHIS.Framework.XEditGridCell xEditGridCellorder_remark;
		private IHIS.Framework.XEditGridCell xEditGridCellreturn_remark;
        private IHIS.Framework.XEditGridCell xEditGridCell193;
		private IHIS.Framework.XEditGridCell xEditGridCell196;
        private IHIS.Framework.XEditGridCell xEditGridCell253;
		private IHIS.Framework.XEditGridCell xEditGridCell256;
		private IHIS.Framework.XEditGridCell xEditGridCell257;
		private IHIS.Framework.XEditGridCell xEditGridCell258;
		private IHIS.Framework.XEditGridCell xEditGridCell276;
		private IHIS.Framework.XEditGridCell xEditGridCell277;
		private IHIS.Framework.XEditGridCell xEditGridCell278;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell292;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell294;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
		private IHIS.Framework.XEditGridCell xEditGridCelltel_display;
        private IHIS.Framework.XEditGridCell xEditGridCell113;
		private IHIS.Framework.XGridHeader xGridHeaderDv;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XPanel pnlInput_gubun;
		private IHIS.Framework.XRadioButton rbt;
		private IHIS.Framework.XRadioButton rbtConfirmY;
		private IHIS.Framework.XRadioButton rbtConfirmN;
		private IHIS.Framework.XRadioButton rbtALL;
		private IHIS.Framework.XPatientBox pbxBunho;
		private IHIS.Framework.XDatePicker dpkFrom_date;
		private IHIS.Framework.XDatePicker dpkTo_date;
		private System.Windows.Forms.Label label1;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XTextBox txtConfirmUser;
		private IHIS.Framework.XDisplayBox dbxConfirmUserName;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XLabel lblNurseId;
		private IHIS.Framework.XButton btnClearConfirmUser;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell14;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS2003U10()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mPatientInfo = new IHIS.OCS.PatientInfo(this.ScreenID);    // OCS 환자정보 그룹 라이브러리 
			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
			this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리

            //저장 수행자 Set
            this.grdOCS2003.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdOCS2003);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2003U10));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnClearConfirmUser = new IHIS.Framework.XButton();
            this.dbxConfirmUserName = new IHIS.Framework.XDisplayBox();
            this.txtConfirmUser = new IHIS.Framework.XTextBox();
            this.lblNurseId = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dpkTo_date = new IHIS.Framework.XDatePicker();
            this.rbtALL = new IHIS.Framework.XRadioButton();
            this.rbtConfirmY = new IHIS.Framework.XRadioButton();
            this.pbxBunho = new IHIS.Framework.XPatientBox();
            this.dpkFrom_date = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.rbtConfirmN = new IHIS.Framework.XRadioButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdOCS2003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell178 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell179 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell183 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell182 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell185 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell186 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell187 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell188 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell189 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell280 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellhangmog_code = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellspecimen_code = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellSuryang = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellsubul_suryang = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCelldv_time = new IHIS.Framework.XEditGridCell();
            this.xEditGridCelldv = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell296 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell297 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell298 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell299 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellNalsu = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell259 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCelljundal_part = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell260 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellmuhyo = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellportable_yn = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellpay = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell160 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell190 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1dc_gubun = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell168 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellamt = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell171 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell172 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell173 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell174 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell175 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellbichi_yn = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell289 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellpowder_yn = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellhope_date = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellMix = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCelltoiwon_drg_yn = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellorder_remark = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellreturn_remark = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell193 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell196 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell253 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell256 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell257 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell258 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell276 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell277 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell278 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell292 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell294 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCelltel_display = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xGridHeaderDv = new IHIS.Framework.XGridHeader();
            this.lblSelectOrder = new IHIS.Framework.XLabel();
            this.pnlInput_gubun = new IHIS.Framework.XPanel();
            this.rbt = new IHIS.Framework.XRadioButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBunho)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).BeginInit();
            this.pnlInput_gubun.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.btnClearConfirmUser);
            this.xPanel1.Controls.Add(this.dbxConfirmUserName);
            this.xPanel1.Controls.Add(this.txtConfirmUser);
            this.xPanel1.Controls.Add(this.lblNurseId);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Controls.Add(this.dpkTo_date);
            this.xPanel1.Controls.Add(this.rbtALL);
            this.xPanel1.Controls.Add(this.rbtConfirmY);
            this.xPanel1.Controls.Add(this.pbxBunho);
            this.xPanel1.Controls.Add(this.dpkFrom_date);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.rbtConfirmN);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(960, 62);
            this.xPanel1.TabIndex = 0;
            // 
            // btnClearConfirmUser
            // 
            this.btnClearConfirmUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearConfirmUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearConfirmUser.Image = ((System.Drawing.Image)(resources.GetObject("btnClearConfirmUser.Image")));
            this.btnClearConfirmUser.Location = new System.Drawing.Point(884, 32);
            this.btnClearConfirmUser.Name = "btnClearConfirmUser";
            this.btnClearConfirmUser.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnClearConfirmUser.Size = new System.Drawing.Size(62, 24);
            this.btnClearConfirmUser.TabIndex = 20;
            this.btnClearConfirmUser.Text = "クリア";
            this.btnClearConfirmUser.Click += new System.EventHandler(this.btnClearConfirmUser_Click);
            // 
            // dbxConfirmUserName
            // 
            this.dbxConfirmUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dbxConfirmUserName.Font = new System.Drawing.Font("MS PMincho", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbxConfirmUserName.Location = new System.Drawing.Point(772, 34);
            this.dbxConfirmUserName.Name = "dbxConfirmUserName";
            this.dbxConfirmUserName.Size = new System.Drawing.Size(110, 22);
            this.dbxConfirmUserName.TabIndex = 19;
            // 
            // txtConfirmUser
            // 
            this.txtConfirmUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConfirmUser.Font = new System.Drawing.Font("MS PMincho", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmUser.Location = new System.Drawing.Point(658, 34);
            this.txtConfirmUser.Name = "txtConfirmUser";
            this.txtConfirmUser.Size = new System.Drawing.Size(112, 23);
            this.txtConfirmUser.TabIndex = 18;
            this.txtConfirmUser.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtConfirmUser_DataValidating);
            // 
            // lblNurseId
            // 
            this.lblNurseId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNurseId.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNurseId.EdgeRounding = false;
            this.lblNurseId.Font = new System.Drawing.Font("MS PMincho", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNurseId.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNurseId.Location = new System.Drawing.Point(532, 34);
            this.lblNurseId.Name = "lblNurseId";
            this.lblNurseId.Size = new System.Drawing.Size(124, 24);
            this.lblNurseId.TabIndex = 17;
            this.lblNurseId.Text = "看護確認 ID";
            this.lblNurseId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(210, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 16;
            // 
            // dpkTo_date
            // 
            this.dpkTo_date.Location = new System.Drawing.Point(234, 34);
            this.dpkTo_date.Name = "dpkTo_date";
            this.dpkTo_date.Size = new System.Drawing.Size(102, 20);
            this.dpkTo_date.TabIndex = 2;
            this.dpkTo_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkOrder_date_DataValidating);
            // 
            // rbtALL
            // 
            this.rbtALL.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbtALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtALL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtALL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtALL.ImageIndex = 0;
            this.rbtALL.Location = new System.Drawing.Point(476, 32);
            this.rbtALL.Name = "rbtALL";
            this.rbtALL.Size = new System.Drawing.Size(56, 26);
            this.rbtALL.TabIndex = 14;
            this.rbtALL.Text = " 全体";
            this.rbtALL.UseVisualStyleBackColor = false;
            this.rbtALL.Click += new System.EventHandler(this.rbtConfirm_Click);
            // 
            // rbtConfirmY
            // 
            this.rbtConfirmY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbtConfirmY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtConfirmY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtConfirmY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtConfirmY.ImageIndex = 0;
            this.rbtConfirmY.Location = new System.Drawing.Point(416, 32);
            this.rbtConfirmY.Name = "rbtConfirmY";
            this.rbtConfirmY.Size = new System.Drawing.Size(58, 26);
            this.rbtConfirmY.TabIndex = 13;
            this.rbtConfirmY.Text = " 確認";
            this.rbtConfirmY.UseVisualStyleBackColor = false;
            this.rbtConfirmY.Click += new System.EventHandler(this.rbtConfirm_Click);
            // 
            // pbxBunho
            // 
            this.pbxBunho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxBunho.Location = new System.Drawing.Point(0, 0);
            this.pbxBunho.Name = "pbxBunho";
            this.pbxBunho.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pbxBunho.Size = new System.Drawing.Size(958, 30);
            this.pbxBunho.TabIndex = 0;
            this.pbxBunho.PatientSelectionFailed += new System.EventHandler(this.pbxBunho_PatientSelectionFailed);
            this.pbxBunho.PatientSelected += new System.EventHandler(this.pbxBunho_PatientSelected);
            // 
            // dpkFrom_date
            // 
            this.dpkFrom_date.Location = new System.Drawing.Point(104, 34);
            this.dpkFrom_date.Name = "dpkFrom_date";
            this.dpkFrom_date.Size = new System.Drawing.Size(102, 20);
            this.dpkFrom_date.TabIndex = 1;
            this.dpkFrom_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkOrder_date_DataValidating);
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(4, 34);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(98, 19);
            this.xLabel5.TabIndex = 4;
            this.xLabel5.Text = "オ―ダ日付";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtConfirmN
            // 
            this.rbtConfirmN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbtConfirmN.Checked = true;
            this.rbtConfirmN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtConfirmN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtConfirmN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtConfirmN.ImageIndex = 1;
            this.rbtConfirmN.Location = new System.Drawing.Point(340, 32);
            this.rbtConfirmN.Name = "rbtConfirmN";
            this.rbtConfirmN.Size = new System.Drawing.Size(74, 26);
            this.rbtConfirmN.TabIndex = 11;
            this.rbtConfirmN.TabStop = true;
            this.rbtConfirmN.Text = " 未確認";
            this.rbtConfirmN.UseVisualStyleBackColor = false;
            this.rbtConfirmN.Click += new System.EventHandler(this.rbtConfirm_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 548);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(960, 42);
            this.xPanel2.TabIndex = 1;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(700, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.xPanel5.Controls.Add(this.grdOCS2003);
            this.xPanel5.Controls.Add(this.lblSelectOrder);
            this.xPanel5.Controls.Add(this.pnlInput_gubun);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel5.Location = new System.Drawing.Point(0, 62);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(960, 486);
            this.xPanel5.TabIndex = 4;
            // 
            // grdOCS2003
            // 
            this.grdOCS2003.AddedHeaderLine = 1;
            this.grdOCS2003.ApplyPaintEventToAllColumn = true;
            this.grdOCS2003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell40,
            this.xEditGridCell178,
            this.xEditGridCell179,
            this.xEditGridCell180,
            this.xEditGridCell181,
            this.xEditGridCell183,
            this.xEditGridCell182,
            this.xEditGridCell185,
            this.xEditGridCell186,
            this.xEditGridCell187,
            this.xEditGridCell188,
            this.xEditGridCell189,
            this.xEditGridCell280,
            this.xEditGridCellhangmog_code,
            this.xEditGridCell48,
            this.xEditGridCell46,
            this.xEditGridCell150,
            this.xEditGridCell8,
            this.xEditGridCell4,
            this.xEditGridCellspecimen_code,
            this.xEditGridCellSuryang,
            this.xEditGridCellsubul_suryang,
            this.xEditGridCell51,
            this.xEditGridCell63,
            this.xEditGridCell9,
            this.xEditGridCelldv_time,
            this.xEditGridCelldv,
            this.xEditGridCell296,
            this.xEditGridCell297,
            this.xEditGridCell298,
            this.xEditGridCell299,
            this.xEditGridCellNalsu,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell59,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell259,
            this.xEditGridCelljundal_part,
            this.xEditGridCell260,
            this.xEditGridCell157,
            this.xEditGridCellmuhyo,
            this.xEditGridCellportable_yn,
            this.xEditGridCell69,
            this.xEditGridCellpay,
            this.xEditGridCell159,
            this.xEditGridCell160,
            this.xEditGridCell161,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell162,
            this.xEditGridCell163,
            this.xEditGridCell190,
            this.xEditGridCell1dc_gubun,
            this.xEditGridCell164,
            this.xEditGridCell166,
            this.xEditGridCell167,
            this.xEditGridCell168,
            this.xEditGridCellamt,
            this.xEditGridCell170,
            this.xEditGridCell73,
            this.xEditGridCell171,
            this.xEditGridCell12,
            this.xEditGridCell172,
            this.xEditGridCell173,
            this.xEditGridCell174,
            this.xEditGridCell175,
            this.xEditGridCellbichi_yn,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell57,
            this.xEditGridCell289,
            this.xEditGridCellpowder_yn,
            this.xEditGridCellhope_date,
            this.xEditGridCell17,
            this.xEditGridCellMix,
            this.xEditGridCell11,
            this.xEditGridCell26,
            this.xEditGridCell28,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell49,
            this.xEditGridCell52,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCelltoiwon_drg_yn,
            this.xEditGridCell109,
            this.xEditGridCell110,
            this.xEditGridCellorder_remark,
            this.xEditGridCellreturn_remark,
            this.xEditGridCell45,
            this.xEditGridCell193,
            this.xEditGridCell196,
            this.xEditGridCell253,
            this.xEditGridCell256,
            this.xEditGridCell257,
            this.xEditGridCell258,
            this.xEditGridCell276,
            this.xEditGridCell277,
            this.xEditGridCell278,
            this.xEditGridCell19,
            this.xEditGridCell292,
            this.xEditGridCell10,
            this.xEditGridCell294,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell108,
            this.xEditGridCelltel_display,
            this.xEditGridCell113,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell25,
            this.xEditGridCell27,
            this.xEditGridCell29,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell41,
            this.xEditGridCell39,
            this.xEditGridCell1});
            this.grdOCS2003.ColPerLine = 32;
            this.grdOCS2003.ColResizable = true;
            this.grdOCS2003.Cols = 32;
            this.grdOCS2003.ControlBinding = true;
            this.grdOCS2003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS2003.EnableMultiSelection = true;
            this.grdOCS2003.FixedRows = 2;
            this.grdOCS2003.FocusColumnName = "hangmog_code";
            this.grdOCS2003.HeaderHeights.Add(34);
            this.grdOCS2003.HeaderHeights.Add(0);
            this.grdOCS2003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeaderDv});
            this.grdOCS2003.Location = new System.Drawing.Point(0, 52);
            this.grdOCS2003.Name = "grdOCS2003";
            this.grdOCS2003.QuerySQL = resources.GetString("grdOCS2003.QuerySQL");
            this.grdOCS2003.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS2003.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdOCS2003.Rows = 3;
            this.grdOCS2003.RowStateCheckOnPaint = false;
            this.grdOCS2003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS2003.SelectionModeChangeable = true;
            this.grdOCS2003.Size = new System.Drawing.Size(960, 434);
            this.grdOCS2003.TabIndex = 17;
            this.grdOCS2003.TogglingRowSelection = true;
            this.grdOCS2003.ToolTipActive = true;
            this.grdOCS2003.ToolTipType = IHIS.Framework.XGridToolTipType.ColumnDesc;
            this.grdOCS2003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS2003_MouseDown);
            this.grdOCS2003.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS2003_PreSaveLayout);
            this.grdOCS2003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS2003_GridCellPainting);
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell40.CellName = "plan_yn";
            this.xEditGridCell40.CellWidth = 32;
            this.xEditGridCell40.Col = 2;
            this.xEditGridCell40.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell40.HeaderText = "治療\r\n計画";
            this.xEditGridCell40.IsUpdatable = false;
            this.xEditGridCell40.RowSpan = 2;
            this.xEditGridCell40.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell40.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellName = "sys_date";
            this.xEditGridCell178.CellType = IHIS.Framework.XCellDataType.DateTime;
            this.xEditGridCell178.Col = -1;
            this.xEditGridCell178.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell178.HeaderText = "sysdate";
            this.xEditGridCell178.IsUpdatable = false;
            this.xEditGridCell178.IsUpdCol = false;
            this.xEditGridCell178.IsVisible = false;
            this.xEditGridCell178.Row = -1;
            // 
            // xEditGridCell179
            // 
            this.xEditGridCell179.CellLen = 8;
            this.xEditGridCell179.CellName = "user_id";
            this.xEditGridCell179.Col = -1;
            this.xEditGridCell179.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell179.HeaderText = "사용자";
            this.xEditGridCell179.IsUpdatable = false;
            this.xEditGridCell179.IsUpdCol = false;
            this.xEditGridCell179.IsVisible = false;
            this.xEditGridCell179.Row = -1;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellName = "upd_date";
            this.xEditGridCell180.CellType = IHIS.Framework.XCellDataType.DateTime;
            this.xEditGridCell180.Col = -1;
            this.xEditGridCell180.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell180.HeaderText = "upddate";
            this.xEditGridCell180.IsUpdatable = false;
            this.xEditGridCell180.IsUpdCol = false;
            this.xEditGridCell180.IsVisible = false;
            this.xEditGridCell180.Row = -1;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.CellLen = 40;
            this.xEditGridCell181.CellName = "pkocs2003";
            this.xEditGridCell181.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell181.Col = -1;
            this.xEditGridCell181.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell181.HeaderText = "PK";
            this.xEditGridCell181.IsUpdatable = false;
            this.xEditGridCell181.IsVisible = false;
            this.xEditGridCell181.Row = -1;
            // 
            // xEditGridCell183
            // 
            this.xEditGridCell183.CellLen = 9;
            this.xEditGridCell183.CellName = "bunho";
            this.xEditGridCell183.Col = -1;
            this.xEditGridCell183.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell183.HeaderText = "환자번호";
            this.xEditGridCell183.IsUpdatable = false;
            this.xEditGridCell183.IsVisible = false;
            this.xEditGridCell183.Row = -1;
            // 
            // xEditGridCell182
            // 
            this.xEditGridCell182.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell182.CellName = "order_date";
            this.xEditGridCell182.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell182.Col = 1;
            this.xEditGridCell182.HeaderText = "オーダ日付";
            this.xEditGridCell182.IsUpdatable = false;
            this.xEditGridCell182.RowSpan = 2;
            this.xEditGridCell182.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell182.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell185
            // 
            this.xEditGridCell185.CellLen = 5;
            this.xEditGridCell185.CellName = "doctor";
            this.xEditGridCell185.Col = -1;
            this.xEditGridCell185.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell185.HeaderText = "진료의사";
            this.xEditGridCell185.IsUpdatable = false;
            this.xEditGridCell185.IsUpdCol = false;
            this.xEditGridCell185.IsVisible = false;
            this.xEditGridCell185.Row = -1;
            // 
            // xEditGridCell186
            // 
            this.xEditGridCell186.CellLen = 1;
            this.xEditGridCell186.CellName = "ipwon_type";
            this.xEditGridCell186.Col = -1;
            this.xEditGridCell186.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell186.HeaderText = "입원Type";
            this.xEditGridCell186.IsUpdatable = false;
            this.xEditGridCell186.IsUpdCol = false;
            this.xEditGridCell186.IsVisible = false;
            this.xEditGridCell186.Row = -1;
            // 
            // xEditGridCell187
            // 
            this.xEditGridCell187.CellName = "input_id";
            this.xEditGridCell187.Col = -1;
            this.xEditGridCell187.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell187.HeaderText = "입력ID";
            this.xEditGridCell187.IsUpdatable = false;
            this.xEditGridCell187.IsUpdCol = false;
            this.xEditGridCell187.IsVisible = false;
            this.xEditGridCell187.Row = -1;
            // 
            // xEditGridCell188
            // 
            this.xEditGridCell188.CellName = "input_part";
            this.xEditGridCell188.Col = -1;
            this.xEditGridCell188.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell188.HeaderText = "입력파트";
            this.xEditGridCell188.IsUpdatable = false;
            this.xEditGridCell188.IsUpdCol = false;
            this.xEditGridCell188.IsVisible = false;
            this.xEditGridCell188.Row = -1;
            // 
            // xEditGridCell189
            // 
            this.xEditGridCell189.CellLen = 2;
            this.xEditGridCell189.CellName = "input_gubun";
            this.xEditGridCell189.Col = -1;
            this.xEditGridCell189.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell189.HeaderText = "입력구분";
            this.xEditGridCell189.IsUpdatable = false;
            this.xEditGridCell189.IsVisible = false;
            this.xEditGridCell189.Row = -1;
            // 
            // xEditGridCell280
            // 
            this.xEditGridCell280.CellName = "seq";
            this.xEditGridCell280.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell280.Col = -1;
            this.xEditGridCell280.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell280.HeaderText = "순번";
            this.xEditGridCell280.IsUpdatable = false;
            this.xEditGridCell280.IsUpdCol = false;
            this.xEditGridCell280.IsVisible = false;
            this.xEditGridCell280.Row = -1;
            // 
            // xEditGridCellhangmog_code
            // 
            this.xEditGridCellhangmog_code.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellhangmog_code.ApplyPaintingEvent = true;
            this.xEditGridCellhangmog_code.CellName = "hangmog_code";
            this.xEditGridCellhangmog_code.CellWidth = 85;
            this.xEditGridCellhangmog_code.Col = 6;
            this.xEditGridCellhangmog_code.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCellhangmog_code.HeaderText = "オーダコード";
            this.xEditGridCellhangmog_code.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellhangmog_code.IsUpdatable = false;
            this.xEditGridCellhangmog_code.RowSpan = 2;
            this.xEditGridCellhangmog_code.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell48.CellLen = 80;
            this.xEditGridCell48.CellName = "hangmog_name";
            this.xEditGridCell48.CellWidth = 261;
            this.xEditGridCell48.Col = 7;
            this.xEditGridCell48.HeaderText = "オーダ名";
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.RowSpan = 2;
            this.xEditGridCell48.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell46.CellName = "group_ser";
            this.xEditGridCell46.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell46.CellWidth = 16;
            this.xEditGridCell46.Col = 5;
            this.xEditGridCell46.HeaderText = "G\r\nR";
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.RowSpan = 2;
            this.xEditGridCell46.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell46.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellLen = 4;
            this.xEditGridCell150.CellName = "slip_code";
            this.xEditGridCell150.Col = -1;
            this.xEditGridCell150.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell150.HeaderText = "서식지코드";
            this.xEditGridCell150.IsUpdatable = false;
            this.xEditGridCell150.IsUpdCol = false;
            this.xEditGridCell150.IsVisible = false;
            this.xEditGridCell150.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 2;
            this.xEditGridCell8.CellName = "order_gubun";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "처방구분";
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "input_tab";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "input_tab";
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCellspecimen_code
            // 
            this.xEditGridCellspecimen_code.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellspecimen_code.CellLen = 3;
            this.xEditGridCellspecimen_code.CellName = "specimen_code";
            this.xEditGridCellspecimen_code.CellWidth = 40;
            this.xEditGridCellspecimen_code.Col = 10;
            this.xEditGridCellspecimen_code.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCellspecimen_code.HeaderText = "検体";
            this.xEditGridCellspecimen_code.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellspecimen_code.IsUpdatable = false;
            this.xEditGridCellspecimen_code.IsUpdCol = false;
            this.xEditGridCellspecimen_code.RowSpan = 2;
            this.xEditGridCellspecimen_code.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCellSuryang
            // 
            this.xEditGridCellSuryang.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellSuryang.CellName = "suryang";
            this.xEditGridCellSuryang.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCellSuryang.CellWidth = 50;
            this.xEditGridCellSuryang.Col = 11;
            this.xEditGridCellSuryang.DecimalDigits = 3;
            this.xEditGridCellSuryang.GeneralNumberFormat = true;
            this.xEditGridCellSuryang.HeaderText = "数量";
            this.xEditGridCellSuryang.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellSuryang.IsUpdatable = false;
            this.xEditGridCellSuryang.IsUpdCol = false;
            this.xEditGridCellSuryang.RowSpan = 2;
            this.xEditGridCellSuryang.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCellsubul_suryang
            // 
            this.xEditGridCellsubul_suryang.CellName = "subul_suryang";
            this.xEditGridCellsubul_suryang.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCellsubul_suryang.Col = -1;
            this.xEditGridCellsubul_suryang.DecimalDigits = 3;
            this.xEditGridCellsubul_suryang.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCellsubul_suryang.HeaderText = "수불수량";
            this.xEditGridCellsubul_suryang.IsUpdatable = false;
            this.xEditGridCellsubul_suryang.IsUpdCol = false;
            this.xEditGridCellsubul_suryang.IsVisible = false;
            this.xEditGridCellsubul_suryang.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellLen = 6;
            this.xEditGridCell51.CellName = "ord_danui";
            this.xEditGridCell51.CellWidth = 45;
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "単位";
            this.xEditGridCell51.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsUpdCol = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell63.CellLen = 100;
            this.xEditGridCell63.CellName = "ord_danui_name";
            this.xEditGridCell63.CellWidth = 58;
            this.xEditGridCell63.Col = 12;
            this.xEditGridCell63.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell63.HeaderText = "単位";
            this.xEditGridCell63.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.IsUpdCol = false;
            this.xEditGridCell63.RowSpan = 2;
            this.xEditGridCell63.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 6;
            this.xEditGridCell9.CellName = "subul_danul";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "수불단위";
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCelldv_time
            // 
            this.xEditGridCelldv_time.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCelldv_time.CellLen = 1;
            this.xEditGridCelldv_time.CellName = "dv_time";
            this.xEditGridCelldv_time.CellWidth = 20;
            this.xEditGridCelldv_time.Col = 13;
            this.xEditGridCelldv_time.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCelldv_time.IsUpdatable = false;
            this.xEditGridCelldv_time.IsUpdCol = false;
            this.xEditGridCelldv_time.Row = 1;
            this.xEditGridCelldv_time.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCelldv
            // 
            this.xEditGridCelldv.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCelldv.CellLen = 3;
            this.xEditGridCelldv.CellName = "dv";
            this.xEditGridCelldv.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCelldv.CellWidth = 18;
            this.xEditGridCelldv.Col = 14;
            this.xEditGridCelldv.GeneralNumberFormat = true;
            this.xEditGridCelldv.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCelldv.IsUpdatable = false;
            this.xEditGridCelldv.IsUpdCol = false;
            this.xEditGridCelldv.MaxinumCipher = 3;
            this.xEditGridCelldv.Row = 1;
            this.xEditGridCelldv.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell296
            // 
            this.xEditGridCell296.CellName = "dv_1";
            this.xEditGridCell296.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell296.Col = -1;
            this.xEditGridCell296.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell296.HeaderText = "DV1";
            this.xEditGridCell296.IsUpdatable = false;
            this.xEditGridCell296.IsUpdCol = false;
            this.xEditGridCell296.IsVisible = false;
            this.xEditGridCell296.Row = -1;
            // 
            // xEditGridCell297
            // 
            this.xEditGridCell297.CellName = "dv_2";
            this.xEditGridCell297.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell297.Col = -1;
            this.xEditGridCell297.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell297.HeaderText = "DV2";
            this.xEditGridCell297.IsUpdatable = false;
            this.xEditGridCell297.IsUpdCol = false;
            this.xEditGridCell297.IsVisible = false;
            this.xEditGridCell297.Row = -1;
            // 
            // xEditGridCell298
            // 
            this.xEditGridCell298.CellName = "dv_3";
            this.xEditGridCell298.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell298.Col = -1;
            this.xEditGridCell298.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell298.HeaderText = "DV3";
            this.xEditGridCell298.IsUpdatable = false;
            this.xEditGridCell298.IsUpdCol = false;
            this.xEditGridCell298.IsVisible = false;
            this.xEditGridCell298.Row = -1;
            // 
            // xEditGridCell299
            // 
            this.xEditGridCell299.CellName = "dv_4";
            this.xEditGridCell299.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell299.Col = -1;
            this.xEditGridCell299.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell299.HeaderText = "DV4";
            this.xEditGridCell299.IsUpdatable = false;
            this.xEditGridCell299.IsUpdCol = false;
            this.xEditGridCell299.IsVisible = false;
            this.xEditGridCell299.Row = -1;
            // 
            // xEditGridCellNalsu
            // 
            this.xEditGridCellNalsu.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellNalsu.CellName = "nalsu";
            this.xEditGridCellNalsu.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCellNalsu.CellWidth = 20;
            this.xEditGridCellNalsu.Col = 15;
            this.xEditGridCellNalsu.GeneralNumberFormat = true;
            this.xEditGridCellNalsu.HeaderText = "日\r\n数";
            this.xEditGridCellNalsu.IsUpdatable = false;
            this.xEditGridCellNalsu.IsUpdCol = false;
            this.xEditGridCellNalsu.MaxinumCipher = 3;
            this.xEditGridCellNalsu.RowSpan = 2;
            this.xEditGridCellNalsu.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell55.CellLen = 1;
            this.xEditGridCell55.CellName = "jusa";
            this.xEditGridCell55.CellWidth = 29;
            this.xEditGridCell55.Col = 16;
            this.xEditGridCell55.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell55.HeaderText = "注射";
            this.xEditGridCell55.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell55.IsUpdatable = false;
            this.xEditGridCell55.IsUpdCol = false;
            this.xEditGridCell55.RowSpan = 2;
            this.xEditGridCell55.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell56.CellName = "bogyong_code";
            this.xEditGridCell56.CellWidth = 63;
            this.xEditGridCell56.Col = 17;
            this.xEditGridCell56.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell56.HeaderText = "用法";
            this.xEditGridCell56.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsUpdCol = false;
            this.xEditGridCell56.RowSpan = 2;
            this.xEditGridCell56.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell59.CellLen = 1;
            this.xEditGridCell59.CellName = "emergency";
            this.xEditGridCell59.CellWidth = 22;
            this.xEditGridCell59.Col = 19;
            this.xEditGridCell59.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell59.HeaderText = "至\r\n急";
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsUpdCol = false;
            this.xEditGridCell59.RowSpan = 2;
            this.xEditGridCell59.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellLen = 1;
            this.xEditGridCell155.CellName = "jaeryo_jundal_yn";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell155.HeaderText = "재료전달여부";
            this.xEditGridCell155.IsUpdatable = false;
            this.xEditGridCell155.IsUpdCol = false;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellLen = 5;
            this.xEditGridCell156.CellName = "jundal_table";
            this.xEditGridCell156.Col = -1;
            this.xEditGridCell156.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell156.HeaderText = "전달테이블";
            this.xEditGridCell156.IsUpdatable = false;
            this.xEditGridCell156.IsUpdCol = false;
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            // 
            // xEditGridCell259
            // 
            this.xEditGridCell259.CellLen = 5;
            this.xEditGridCell259.CellName = "jundal_table_inp";
            this.xEditGridCell259.Col = -1;
            this.xEditGridCell259.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell259.HeaderText = "입원전달테이블";
            this.xEditGridCell259.IsUpdatable = false;
            this.xEditGridCell259.IsUpdCol = false;
            this.xEditGridCell259.IsVisible = false;
            this.xEditGridCell259.Row = -1;
            // 
            // xEditGridCelljundal_part
            // 
            this.xEditGridCelljundal_part.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCelljundal_part.CellName = "jundal_part";
            this.xEditGridCelljundal_part.CellWidth = 34;
            this.xEditGridCelljundal_part.Col = 21;
            this.xEditGridCelljundal_part.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCelljundal_part.HeaderText = "行為\r\n部署";
            this.xEditGridCelljundal_part.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCelljundal_part.IsUpdatable = false;
            this.xEditGridCelljundal_part.IsUpdCol = false;
            this.xEditGridCelljundal_part.RowSpan = 2;
            this.xEditGridCelljundal_part.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell260
            // 
            this.xEditGridCell260.CellName = "jundal_part_inp";
            this.xEditGridCell260.Col = -1;
            this.xEditGridCell260.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell260.HeaderText = "입원전달부서";
            this.xEditGridCell260.IsUpdatable = false;
            this.xEditGridCell260.IsUpdCol = false;
            this.xEditGridCell260.IsVisible = false;
            this.xEditGridCell260.Row = -1;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "move_part";
            this.xEditGridCell157.Col = -1;
            this.xEditGridCell157.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell157.HeaderText = "이동부서";
            this.xEditGridCell157.IsUpdatable = false;
            this.xEditGridCell157.IsUpdCol = false;
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xEditGridCellmuhyo
            // 
            this.xEditGridCellmuhyo.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellmuhyo.CellLen = 1;
            this.xEditGridCellmuhyo.CellName = "muhyo";
            this.xEditGridCellmuhyo.CellWidth = 20;
            this.xEditGridCellmuhyo.Col = 29;
            this.xEditGridCellmuhyo.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCellmuhyo.HeaderText = "無\r\n効";
            this.xEditGridCellmuhyo.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellmuhyo.IsUpdatable = false;
            this.xEditGridCellmuhyo.IsUpdCol = false;
            this.xEditGridCellmuhyo.RowSpan = 2;
            this.xEditGridCellmuhyo.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCellportable_yn
            // 
            this.xEditGridCellportable_yn.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellportable_yn.CellLen = 1;
            this.xEditGridCellportable_yn.CellName = "portable_yn";
            this.xEditGridCellportable_yn.CellWidth = 32;
            this.xEditGridCellportable_yn.Col = 27;
            this.xEditGridCellportable_yn.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCellportable_yn.HeaderText = "移動\r\n撮影";
            this.xEditGridCellportable_yn.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellportable_yn.InitValue = "N";
            this.xEditGridCellportable_yn.IsUpdatable = false;
            this.xEditGridCellportable_yn.IsUpdCol = false;
            this.xEditGridCellportable_yn.RowSpan = 2;
            this.xEditGridCellportable_yn.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellportable_yn.ToolTipText = "Po:移動撮影, Op:手術室 移動撮影, No:無 移動撮影";
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellLen = 1;
            this.xEditGridCell69.CellName = "anti_cancer_yn";
            this.xEditGridCell69.CellWidth = 33;
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.HeaderText = "抗癌";
            this.xEditGridCell69.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell69.IsUpdatable = false;
            this.xEditGridCell69.IsUpdCol = false;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCellpay
            // 
            this.xEditGridCellpay.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellpay.CellLen = 1;
            this.xEditGridCellpay.CellName = "pay";
            this.xEditGridCellpay.CellWidth = 36;
            this.xEditGridCellpay.Col = 22;
            this.xEditGridCellpay.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCellpay.HeaderText = "請求\r\n区分";
            this.xEditGridCellpay.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellpay.InitValue = "0";
            this.xEditGridCellpay.IsUpdatable = false;
            this.xEditGridCellpay.IsUpdCol = false;
            this.xEditGridCellpay.RowSpan = 2;
            this.xEditGridCellpay.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellName = "sunab_date";
            this.xEditGridCell159.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell159.Col = -1;
            this.xEditGridCell159.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell159.HeaderText = "수납일자";
            this.xEditGridCell159.IsUpdatable = false;
            this.xEditGridCell159.IsUpdCol = false;
            this.xEditGridCell159.IsVisible = false;
            this.xEditGridCell159.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "reser_date";
            this.xEditGridCell160.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell160.HeaderText = "예약일자";
            this.xEditGridCell160.IsUpdatable = false;
            this.xEditGridCell160.IsUpdCol = false;
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellLen = 4;
            this.xEditGridCell161.CellName = "reser_time";
            this.xEditGridCell161.Col = -1;
            this.xEditGridCell161.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell161.HeaderText = "예약시간";
            this.xEditGridCell161.IsUpdatable = false;
            this.xEditGridCell161.IsUpdCol = false;
            this.xEditGridCell161.IsVisible = false;
            this.xEditGridCell161.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "jubsu_date";
            this.xEditGridCell32.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.HeaderText = "접수일자";
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 4;
            this.xEditGridCell33.CellName = "jubsu_time";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.HeaderText = "접수시간";
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "acting_date";
            this.xEditGridCell162.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell162.HeaderText = "수행일자";
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsUpdCol = false;
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellLen = 4;
            this.xEditGridCell163.CellName = "acting_time";
            this.xEditGridCell163.Col = -1;
            this.xEditGridCell163.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell163.HeaderText = "수행시간";
            this.xEditGridCell163.IsUpdatable = false;
            this.xEditGridCell163.IsUpdCol = false;
            this.xEditGridCell163.IsVisible = false;
            this.xEditGridCell163.Row = -1;
            // 
            // xEditGridCell190
            // 
            this.xEditGridCell190.CellName = "acting_day";
            this.xEditGridCell190.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell190.Col = -1;
            this.xEditGridCell190.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell190.HeaderText = "수행일";
            this.xEditGridCell190.IsUpdatable = false;
            this.xEditGridCell190.IsUpdCol = false;
            this.xEditGridCell190.IsVisible = false;
            this.xEditGridCell190.Row = -1;
            // 
            // xEditGridCell1dc_gubun
            // 
            this.xEditGridCell1dc_gubun.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1dc_gubun.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.xEditGridCell1dc_gubun.CellLen = 1;
            this.xEditGridCell1dc_gubun.CellName = "dc_gubun";
            this.xEditGridCell1dc_gubun.CellWidth = 30;
            this.xEditGridCell1dc_gubun.Col = 8;
            this.xEditGridCell1dc_gubun.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1dc_gubun.HeaderForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.xEditGridCell1dc_gubun.HeaderText = "返納\r\n指示";
            this.xEditGridCell1dc_gubun.IsUpdatable = false;
            this.xEditGridCell1dc_gubun.IsUpdCol = false;
            this.xEditGridCell1dc_gubun.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.xEditGridCell1dc_gubun.RowSpan = 2;
            this.xEditGridCell1dc_gubun.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellLen = 1;
            this.xEditGridCell164.CellName = "dc_yn";
            this.xEditGridCell164.Col = -1;
            this.xEditGridCell164.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell164.HeaderText = "DC여부";
            this.xEditGridCell164.IsUpdatable = false;
            this.xEditGridCell164.IsUpdCol = false;
            this.xEditGridCell164.IsVisible = false;
            this.xEditGridCell164.Row = -1;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellLen = 1;
            this.xEditGridCell166.CellName = "bannab_yn";
            this.xEditGridCell166.Col = -1;
            this.xEditGridCell166.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell166.HeaderText = "반납여부";
            this.xEditGridCell166.IsUpdatable = false;
            this.xEditGridCell166.IsUpdCol = false;
            this.xEditGridCell166.IsVisible = false;
            this.xEditGridCell166.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell167.CellLen = 1;
            this.xEditGridCell167.CellName = "bannab_confirm";
            this.xEditGridCell167.CellWidth = 33;
            this.xEditGridCell167.Col = 31;
            this.xEditGridCell167.HeaderText = "返納\r\n確認";
            this.xEditGridCell167.IsUpdatable = false;
            this.xEditGridCell167.IsUpdCol = false;
            this.xEditGridCell167.RowSpan = 2;
            this.xEditGridCell167.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell167.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellLen = 40;
            this.xEditGridCell168.CellName = "source_fkocs2003";
            this.xEditGridCell168.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell168.Col = -1;
            this.xEditGridCell168.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell168.HeaderText = "source_fkocs2003";
            this.xEditGridCell168.IsUpdatable = false;
            this.xEditGridCell168.IsUpdCol = false;
            this.xEditGridCell168.IsVisible = false;
            this.xEditGridCell168.Row = -1;
            // 
            // xEditGridCellamt
            // 
            this.xEditGridCellamt.CellName = "amt";
            this.xEditGridCellamt.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCellamt.Col = -1;
            this.xEditGridCellamt.HeaderText = "金額";
            this.xEditGridCellamt.IsUpdatable = false;
            this.xEditGridCellamt.IsUpdCol = false;
            this.xEditGridCellamt.IsVisible = false;
            this.xEditGridCellamt.Row = -1;
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellLen = 5;
            this.xEditGridCell170.CellName = "act_doctor";
            this.xEditGridCell170.Col = -1;
            this.xEditGridCell170.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell170.HeaderText = "시행의사";
            this.xEditGridCell170.IsUpdatable = false;
            this.xEditGridCell170.IsUpdCol = false;
            this.xEditGridCell170.IsVisible = false;
            this.xEditGridCell170.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellLen = 30;
            this.xEditGridCell73.CellName = "act_doctor_name";
            this.xEditGridCell73.CellWidth = 49;
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.HeaderText = "特診医";
            this.xEditGridCell73.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.IsUpdCol = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellName = "act_gwa";
            this.xEditGridCell171.Col = -1;
            this.xEditGridCell171.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell171.HeaderText = "시행과";
            this.xEditGridCell171.IsUpdatable = false;
            this.xEditGridCell171.IsUpdCol = false;
            this.xEditGridCell171.IsVisible = false;
            this.xEditGridCell171.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "act_buseo";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "시행부서";
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellLen = 1;
            this.xEditGridCell172.CellName = "ocs_flag";
            this.xEditGridCell172.Col = -1;
            this.xEditGridCell172.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell172.HeaderText = "OCSFLAG";
            this.xEditGridCell172.IsUpdatable = false;
            this.xEditGridCell172.IsUpdCol = false;
            this.xEditGridCell172.IsVisible = false;
            this.xEditGridCell172.Row = -1;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.CellName = "sg_code";
            this.xEditGridCell173.Col = -1;
            this.xEditGridCell173.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell173.HeaderText = "수가코드";
            this.xEditGridCell173.IsUpdatable = false;
            this.xEditGridCell173.IsUpdCol = false;
            this.xEditGridCell173.IsVisible = false;
            this.xEditGridCell173.Row = -1;
            // 
            // xEditGridCell174
            // 
            this.xEditGridCell174.CellLen = 1;
            this.xEditGridCell174.CellName = "io_gubun";
            this.xEditGridCell174.Col = -1;
            this.xEditGridCell174.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell174.HeaderText = "IO구분";
            this.xEditGridCell174.IsUpdatable = false;
            this.xEditGridCell174.IsUpdCol = false;
            this.xEditGridCell174.IsVisible = false;
            this.xEditGridCell174.Row = -1;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellLen = 40;
            this.xEditGridCell175.CellName = "fkocs1003";
            this.xEditGridCell175.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell175.Col = -1;
            this.xEditGridCell175.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell175.HeaderText = "FKOCS1003";
            this.xEditGridCell175.IsUpdatable = false;
            this.xEditGridCell175.IsUpdCol = false;
            this.xEditGridCell175.IsVisible = false;
            this.xEditGridCell175.Row = -1;
            // 
            // xEditGridCellbichi_yn
            // 
            this.xEditGridCellbichi_yn.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellbichi_yn.CellLen = 1;
            this.xEditGridCellbichi_yn.CellName = "bichi_yn";
            this.xEditGridCellbichi_yn.CellWidth = 19;
            this.xEditGridCellbichi_yn.Col = 30;
            this.xEditGridCellbichi_yn.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCellbichi_yn.HeaderText = "配\r\n置";
            this.xEditGridCellbichi_yn.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellbichi_yn.IsUpdatable = false;
            this.xEditGridCellbichi_yn.IsUpdCol = false;
            this.xEditGridCellbichi_yn.RowSpan = 2;
            this.xEditGridCellbichi_yn.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "drg_bunho";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "투약번호";
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 1;
            this.xEditGridCell14.CellName = "sub_susul";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "副手術";
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellLen = 1;
            this.xEditGridCell57.CellName = "wonyoi_order_yn";
            this.xEditGridCell57.CellWidth = 19;
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.HeaderText = "院\r\n外";
            this.xEditGridCell57.IsUpdatable = false;
            this.xEditGridCell57.IsUpdCol = false;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell289
            // 
            this.xEditGridCell289.CellLen = 1;
            this.xEditGridCell289.CellName = "nday_yn";
            this.xEditGridCell289.Col = -1;
            this.xEditGridCell289.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell289.HeaderText = "nDay여부";
            this.xEditGridCell289.IsUpdatable = false;
            this.xEditGridCell289.IsUpdCol = false;
            this.xEditGridCell289.IsVisible = false;
            this.xEditGridCell289.Row = -1;
            // 
            // xEditGridCellpowder_yn
            // 
            this.xEditGridCellpowder_yn.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellpowder_yn.CellLen = 1;
            this.xEditGridCellpowder_yn.CellName = "powder_yn";
            this.xEditGridCellpowder_yn.CellWidth = 19;
            this.xEditGridCellpowder_yn.Col = 25;
            this.xEditGridCellpowder_yn.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCellpowder_yn.HeaderText = "粉\r\n砕";
            this.xEditGridCellpowder_yn.IsUpdatable = false;
            this.xEditGridCellpowder_yn.IsUpdCol = false;
            this.xEditGridCellpowder_yn.RowSpan = 2;
            this.xEditGridCellpowder_yn.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCellhope_date
            // 
            this.xEditGridCellhope_date.CellName = "hope_date";
            this.xEditGridCellhope_date.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCellhope_date.CellWidth = 94;
            this.xEditGridCellhope_date.Col = -1;
            this.xEditGridCellhope_date.HeaderText = "希望日";
            this.xEditGridCellhope_date.IsUpdatable = false;
            this.xEditGridCellhope_date.IsUpdCol = false;
            this.xEditGridCellhope_date.IsVisible = false;
            this.xEditGridCellhope_date.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 4;
            this.xEditGridCell17.CellName = "hope_time";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "time";
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCellMix
            // 
            this.xEditGridCellMix.CellLen = 1;
            this.xEditGridCellMix.CellName = "mix_group";
            this.xEditGridCellMix.CellWidth = 19;
            this.xEditGridCellMix.Col = -1;
            this.xEditGridCellMix.HeaderText = "M\r\nI\r\nX";
            this.xEditGridCellMix.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCellMix.IsUpdatable = false;
            this.xEditGridCellMix.IsUpdCol = false;
            this.xEditGridCellMix.IsVisible = false;
            this.xEditGridCellMix.Row = -1;
            this.xEditGridCellMix.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 1;
            this.xEditGridCell11.CellName = "append_yn";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellLen = 1;
            this.xEditGridCell26.CellName = "doner_yn";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellLen = 30;
            this.xEditGridCell28.CellName = "drug_time";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 1;
            this.xEditGridCell30.CellName = "error_flag";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 40;
            this.xEditGridCell31.CellName = "fkinp1001";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jundal_part_run";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellLen = 1;
            this.xEditGridCell35.CellName = "label_print_yn";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "nurse_confirm_date";
            this.xEditGridCell49.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsUpdCol = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellLen = 4;
            this.xEditGridCell52.CellName = "nurse_confirm_time";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsUpdCol = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "nurse_confirm_user";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.IsUpdatable = false;
            this.xEditGridCell77.IsUpdCol = false;
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "nurse_pickup_date";
            this.xEditGridCell78.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.IsUpdatable = false;
            this.xEditGridCell78.IsUpdCol = false;
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellLen = 4;
            this.xEditGridCell79.CellName = "nurse_pickup_time";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.IsUpdatable = false;
            this.xEditGridCell79.IsUpdCol = false;
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "nurse_pickup_user";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.IsUpdatable = false;
            this.xEditGridCell98.IsUpdCol = false;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellLen = 4;
            this.xEditGridCell99.CellName = "order_time";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.IsUpdCol = false;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellLen = 1;
            this.xEditGridCell100.CellName = "prepare_yn";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellLen = 1;
            this.xEditGridCell104.CellName = "prn_nurse";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.IsUpdatable = false;
            this.xEditGridCell104.IsUpdCol = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellLen = 1;
            this.xEditGridCell105.CellName = "prn_yn";
            this.xEditGridCell105.CellWidth = 19;
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.HeaderText = "P\r\nR\r\nN";
            this.xEditGridCell105.IsUpdatable = false;
            this.xEditGridCell105.IsUpdCol = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellLen = 5;
            this.xEditGridCell106.CellName = "resident";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.IsUpdatable = false;
            this.xEditGridCell106.IsUpdCol = false;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellLen = 1;
            this.xEditGridCell107.CellName = "tel_yn";
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.IsUpdCol = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCelltoiwon_drg_yn
            // 
            this.xEditGridCelltoiwon_drg_yn.CellLen = 1;
            this.xEditGridCelltoiwon_drg_yn.CellName = "toiwon_drg_yn";
            this.xEditGridCelltoiwon_drg_yn.CellWidth = 19;
            this.xEditGridCelltoiwon_drg_yn.Col = -1;
            this.xEditGridCelltoiwon_drg_yn.HeaderText = "退\r\n/\r\n外";
            this.xEditGridCelltoiwon_drg_yn.IsUpdatable = false;
            this.xEditGridCelltoiwon_drg_yn.IsUpdCol = false;
            this.xEditGridCelltoiwon_drg_yn.IsVisible = false;
            this.xEditGridCelltoiwon_drg_yn.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellLen = 1;
            this.xEditGridCell109.CellName = "nurse_update";
            this.xEditGridCell109.Col = -1;
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.IsUpdCol = false;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell110.CellLen = 2000;
            this.xEditGridCell110.CellName = "nurse_remark";
            this.xEditGridCell110.Col = 28;
            this.xEditGridCell110.HeaderText = "看護\r\nComment";
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.IsUpdCol = false;
            this.xEditGridCell110.RowSpan = 2;
            this.xEditGridCell110.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCellorder_remark
            // 
            this.xEditGridCellorder_remark.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCellorder_remark.CellLen = 2000;
            this.xEditGridCellorder_remark.CellName = "order_remark";
            this.xEditGridCellorder_remark.Col = 20;
            this.xEditGridCellorder_remark.DisplayMemoText = true;
            this.xEditGridCellorder_remark.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCellorder_remark.HeaderText = "Comment";
            this.xEditGridCellorder_remark.IsUpdatable = false;
            this.xEditGridCellorder_remark.IsUpdCol = false;
            this.xEditGridCellorder_remark.RowFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCellorder_remark.RowSpan = 2;
            this.xEditGridCellorder_remark.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCellreturn_remark
            // 
            this.xEditGridCellreturn_remark.CellLen = 2000;
            this.xEditGridCellreturn_remark.CellName = "return_remark";
            this.xEditGridCellreturn_remark.Col = -1;
            this.xEditGridCellreturn_remark.IsUpdatable = false;
            this.xEditGridCellreturn_remark.IsUpdCol = false;
            this.xEditGridCellreturn_remark.IsVisible = false;
            this.xEditGridCellreturn_remark.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell45.CellLen = 80;
            this.xEditGridCell45.CellName = "order_gubun_bas_name";
            this.xEditGridCell45.CellWidth = 48;
            this.xEditGridCell45.Col = 4;
            this.xEditGridCell45.HeaderText = "オーダ\r\n区分";
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsUpdatable = false;
            this.xEditGridCell45.IsUpdCol = false;
            this.xEditGridCell45.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell45.RowSpan = 2;
            this.xEditGridCell45.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell45.SuppressRepeating = true;
            // 
            // xEditGridCell193
            // 
            this.xEditGridCell193.CellLen = 1;
            this.xEditGridCell193.CellName = "input_control";
            this.xEditGridCell193.Col = -1;
            this.xEditGridCell193.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell193.HeaderText = "입력제어";
            this.xEditGridCell193.IsUpdatable = false;
            this.xEditGridCell193.IsUpdCol = false;
            this.xEditGridCell193.IsVisible = false;
            this.xEditGridCell193.Row = -1;
            // 
            // xEditGridCell196
            // 
            this.xEditGridCell196.CellLen = 1;
            this.xEditGridCell196.CellName = "suga_yn";
            this.xEditGridCell196.Col = -1;
            this.xEditGridCell196.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell196.HeaderText = "수가여부";
            this.xEditGridCell196.IsUpdatable = false;
            this.xEditGridCell196.IsUpdCol = false;
            this.xEditGridCell196.IsVisible = false;
            this.xEditGridCell196.Row = -1;
            // 
            // xEditGridCell253
            // 
            this.xEditGridCell253.CellLen = 1;
            this.xEditGridCell253.CellName = "emergency_check";
            this.xEditGridCell253.Col = -1;
            this.xEditGridCell253.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell253.HeaderText = "응급여부";
            this.xEditGridCell253.IsUpdatable = false;
            this.xEditGridCell253.IsUpdCol = false;
            this.xEditGridCell253.IsVisible = false;
            this.xEditGridCell253.Row = -1;
            // 
            // xEditGridCell256
            // 
            this.xEditGridCell256.CellName = "limit_suryang";
            this.xEditGridCell256.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell256.Col = -1;
            this.xEditGridCell256.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell256.HeaderText = "한계수량";
            this.xEditGridCell256.IsUpdatable = false;
            this.xEditGridCell256.IsUpdCol = false;
            this.xEditGridCell256.IsVisible = false;
            this.xEditGridCell256.Row = -1;
            // 
            // xEditGridCell257
            // 
            this.xEditGridCell257.CellLen = 1;
            this.xEditGridCell257.CellName = "specimen_yn";
            this.xEditGridCell257.Col = -1;
            this.xEditGridCell257.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell257.HeaderText = "검체YN";
            this.xEditGridCell257.IsUpdatable = false;
            this.xEditGridCell257.IsUpdCol = false;
            this.xEditGridCell257.IsVisible = false;
            this.xEditGridCell257.Row = -1;
            // 
            // xEditGridCell258
            // 
            this.xEditGridCell258.CellLen = 1;
            this.xEditGridCell258.CellName = "jaeryo_yn";
            this.xEditGridCell258.Col = -1;
            this.xEditGridCell258.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell258.HeaderText = "재료YN";
            this.xEditGridCell258.IsReadOnly = true;
            this.xEditGridCell258.IsUpdatable = false;
            this.xEditGridCell258.IsUpdCol = false;
            this.xEditGridCell258.IsVisible = false;
            this.xEditGridCell258.Row = -1;
            // 
            // xEditGridCell276
            // 
            this.xEditGridCell276.CellLen = 1;
            this.xEditGridCell276.CellName = "sunab_check";
            this.xEditGridCell276.Col = -1;
            this.xEditGridCell276.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell276.HeaderText = "수납체크";
            this.xEditGridCell276.IsUpdatable = false;
            this.xEditGridCell276.IsUpdCol = false;
            this.xEditGridCell276.IsVisible = false;
            this.xEditGridCell276.Row = -1;
            // 
            // xEditGridCell277
            // 
            this.xEditGridCell277.CellLen = 1;
            this.xEditGridCell277.CellName = "dc_check";
            this.xEditGridCell277.Col = -1;
            this.xEditGridCell277.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell277.HeaderText = "DC체크";
            this.xEditGridCell277.IsUpdatable = false;
            this.xEditGridCell277.IsUpdCol = false;
            this.xEditGridCell277.IsVisible = false;
            this.xEditGridCell277.Row = -1;
            // 
            // xEditGridCell278
            // 
            this.xEditGridCell278.CellLen = 1;
            this.xEditGridCell278.CellName = "default_jaeryo_jundal_yn";
            this.xEditGridCell278.Col = -1;
            this.xEditGridCell278.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell278.HeaderText = "기본재료전달";
            this.xEditGridCell278.IsUpdatable = false;
            this.xEditGridCell278.IsUpdCol = false;
            this.xEditGridCell278.IsVisible = false;
            this.xEditGridCell278.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 1;
            this.xEditGridCell19.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell292
            // 
            this.xEditGridCell292.CellLen = 1;
            this.xEditGridCell292.CellName = "muhyo_yn";
            this.xEditGridCell292.Col = -1;
            this.xEditGridCell292.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell292.HeaderText = "무효YN";
            this.xEditGridCell292.IsUpdatable = false;
            this.xEditGridCell292.IsUpdCol = false;
            this.xEditGridCell292.IsVisible = false;
            this.xEditGridCell292.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 2;
            this.xEditGridCell10.CellName = "order_gubun_bas";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell294
            // 
            this.xEditGridCell294.CellLen = 1;
            this.xEditGridCell294.CellName = "default_powder_yn";
            this.xEditGridCell294.Col = -1;
            this.xEditGridCell294.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell294.HeaderText = "기본가루YN";
            this.xEditGridCell294.IsUpdatable = false;
            this.xEditGridCell294.IsUpdCol = false;
            this.xEditGridCell294.IsVisible = false;
            this.xEditGridCell294.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell5.CellLen = 3;
            this.xEditGridCell5.CellName = "gongbi_code";
            this.xEditGridCell5.CellWidth = 52;
            this.xEditGridCell5.Col = 9;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.HeaderText = "公費";
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.RowSpan = 2;
            this.xEditGridCell5.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 100;
            this.xEditGridCell6.CellName = "gongbi_name";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 100;
            this.xEditGridCell7.CellName = "specimen_name";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellLen = 100;
            this.xEditGridCell20.CellName = "jusa_name";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellLen = 100;
            this.xEditGridCell21.CellName = "pay_name";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellLen = 80;
            this.xEditGridCell22.CellName = "bogyong_name";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.IsUpdCol = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 20;
            this.xEditGridCell23.CellName = "jundal_part_name";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsUpdCol = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 1;
            this.xEditGridCell24.CellName = "group_gumsa_yn";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "마루메처방여부";
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellLen = 1;
            this.xEditGridCell108.CellName = "double_ipwon_type";
            this.xEditGridCell108.CellWidth = 36;
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.HeaderText = "他\r\n保険";
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.IsUpdCol = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCelltel_display
            // 
            this.xEditGridCelltel_display.CellLen = 20;
            this.xEditGridCelltel_display.CellName = "tel_display";
            this.xEditGridCelltel_display.CellWidth = 30;
            this.xEditGridCelltel_display.Col = 3;
            this.xEditGridCelltel_display.IsReadOnly = true;
            this.xEditGridCelltel_display.IsUpdatable = false;
            this.xEditGridCelltel_display.IsUpdCol = false;
            this.xEditGridCelltel_display.RowSpan = 2;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellLen = 1;
            this.xEditGridCell113.CellName = "confirm_check";
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.HeaderText = "간호Confirm";
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "input_gubun_name";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "input_gubun_name";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bulyong_check";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "bulyong_check";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.CellName = "jusa_spd_gubun";
            this.xEditGridCell15.CellWidth = 38;
            this.xEditGridCell15.Col = 18;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell15.HeaderText = "ml\r\nhr";
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.CellName = "hubal_change_yn";
            this.xEditGridCell16.CellWidth = 18;
            this.xEditGridCell16.Col = 26;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell16.HeaderText = "後\r\n発";
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.RowSpan = 2;
            this.xEditGridCell16.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellName = "pharmacy";
            this.xEditGridCell25.CellWidth = 19;
            this.xEditGridCell25.Col = 24;
            this.xEditGridCell25.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell25.HeaderText = "簡\r\n易";
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.RowSpan = 2;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellName = "drg_pack_yn";
            this.xEditGridCell27.CellWidth = 20;
            this.xEditGridCell27.Col = 23;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell27.HeaderText = "一\r\n包";
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "donbog_yn";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.HeaderText = "donbog_yn";
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "dv_name";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderText = "dv_name";
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "drg_info";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.HeaderText = "drg_info";
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "drg_bunryu";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.HeaderText = "drg_bunryu";
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsUpdCol = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "pkocs6010";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.HeaderText = "pkocs6010";
            this.xEditGridCell41.IsUpdatable = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "confirm_user";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.HeaderText = "confirm_user";
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.CellName = "select";
            this.xEditGridCell1.CellWidth = 37;
            this.xEditGridCell1.HeaderText = "選択";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xGridHeaderDv
            // 
            this.xGridHeaderDv.Col = 13;
            this.xGridHeaderDv.ColSpan = 2;
            this.xGridHeaderDv.HeaderText = "回数";
            this.xGridHeaderDv.HeaderWidth = 20;
            // 
            // lblSelectOrder
            // 
            this.lblSelectOrder.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectOrder.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectOrder.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectOrder.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectOrder.Image")));
            this.lblSelectOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectOrder.ImageIndex = 0;
            this.lblSelectOrder.ImageList = this.ImageList;
            this.lblSelectOrder.Location = new System.Drawing.Point(0, 28);
            this.lblSelectOrder.Name = "lblSelectOrder";
            this.lblSelectOrder.Size = new System.Drawing.Size(960, 24);
            this.lblSelectOrder.TabIndex = 16;
            this.lblSelectOrder.Text = " 全体選択";
            this.lblSelectOrder.Click += new System.EventHandler(this.lblSelectOrder_Click);
            // 
            // pnlInput_gubun
            // 
            this.pnlInput_gubun.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pnlInput_gubun.Controls.Add(this.rbt);
            this.pnlInput_gubun.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput_gubun.Location = new System.Drawing.Point(0, 0);
            this.pnlInput_gubun.Name = "pnlInput_gubun";
            this.pnlInput_gubun.Size = new System.Drawing.Size(960, 28);
            this.pnlInput_gubun.TabIndex = 18;
            // 
            // rbt
            // 
            this.rbt.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbt.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbt.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbt.ImageIndex = 0;
            this.rbt.ImageList = this.ImageList;
            this.rbt.Location = new System.Drawing.Point(2, 2);
            this.rbt.Name = "rbt";
            this.rbt.Size = new System.Drawing.Size(112, 26);
            this.rbt.TabIndex = 11;
            this.rbt.UseVisualStyleBackColor = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 62);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(960, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // OCS2003U10
            // 
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS2003U10";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBunho)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).EndInit();
            this.pnlInput_gubun.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			return base.Command (command, commandParam);
		}

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);
			
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
					{
						if(TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正確ではないです。 確認してください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);
							this.Close();
							return;
						}
						else
							mBunho = OpenParam["bunho"].ToString().Trim();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正確ではないです。 確認してください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
						this.Close();
						return;
					}
				
					
					mOrder_date = DateTime.Now.ToString("yyyy/MM/dd");
					if(OpenParam.Contains("order_date"))
					{
						if(TypeCheck.IsDateTime(OpenParam["order_date"].ToString()))
							mOrder_date = OpenParam["order_date"].ToString();
					}
					
					//Data가 없는 경우 화면 닫을지 여부
					if(OpenParam.Contains("auto_close"))
					{
						mAuto_close = bool.Parse(OpenParam["auto_close"].ToString().Trim());
					}

				}
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");	
					this.Close();
				}
			}
			else
			{				
				mOrder_date = DateTime.Now.ToString("yyyy/MM/dd");
			}
            
			InitialDesign();
			
			PostCallHelper.PostCall(new PostMethod(PostLoad));			
		}
        
		/// <summary>
		/// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
		/// </summary>
		private void InitialDesign()
		{
			pnlInput_gubun.Controls.Clear();
		}

		private void PostLoad()
		{		
			//comboBox생성
			CreateCombo();

            dpkFrom_date.SetDataValue(mOrder_date);		    
			dpkTo_date.SetDataValue(mOrder_date);

			if(mBunho == "")
			{
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

				if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
				{
					// 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
					patientInfo = XScreen.GetOtherScreenBunHo(this, true);
				}

				if(patientInfo != null)
					this.pbxBunho.SetPatientID(patientInfo.BunHo);					
					
			}
			else 
				this.pbxBunho.SetPatientID(mBunho);

			
		}        
		
		#endregion

		#region [Combo 생성]
		
		private void CreateCombo()
		{
			// Combo 세팅
			DataTable dtTemp = null;
			
			// 급여구분
			dtTemp  = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;	
			grdOCS2003.SetComboItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);
			
			// DV_TIME
			dtTemp = this.mOrderBiz.LoadComboDataSource("dv_time").LayoutTable;
			grdOCS2003.SetListItems("dv_time", dtTemp, "code_name", "code", XComboSetType.NoAppend);

			// 이동촬영여부
			dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
			grdOCS2003.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

			// 주사스피드구분
			dtTemp = this.mOrderBiz.LoadComboDataSource("jusa_spd_gubun").LayoutTable;
			grdOCS2003.SetListItems("jusa_spd_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);

		}
		#endregion
        
		#region [DataService Event]
        private void grdOCS2003_PreSaveLayout(object sender, GridRecordEventArgs e)
		{
			//저장전 Check
			foreach(DataRow row in grdOCS2003.LayoutTable.Rows)
			{
				//이미 확인된 건
				if(row["confirm_check"].ToString() == "Y" && TypeCheck.IsDateTime(row["nurse_pickup_date"].ToString()))
					row.AcceptChanges();
                
				//미확인건
				if(row["confirm_check"].ToString() == "N" && !TypeCheck.IsDateTime(row["nurse_pickup_date"].ToString()))
					row.AcceptChanges();

				if( row.RowState == DataRowState.Modified ) row["confirm_user"] = this.txtConfirmUser.GetDataValue();
			}
		
		}
		#endregion
		
		#region [grdOCS2003 Event]

		private void grdOCS2003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid aGrd = sender as XEditGrid;	

			if (!TypeCheck.IsNull(aGrd.GetItemValue(e.RowNumber, "nalsu")) && aGrd.GetItemInt(e.RowNumber, "nalsu") < 0)
			{
				e.ForeColor= Color.Red;
			}
			else if (aGrd.GetItemString(e.RowNumber, "dc_yn").Trim() == "Y")
			{
				switch (e.ColName)
				{
					case "hangmog_code": case "hangmog_name": // 항목코드
						e.DrawMiddleLine  = true;
						e.MiddleLineColor = Color.Red;
						break;
				}				
			}

			#region 코드만 화면 Display하는 필드를 명칭으로 ToolTip 처리
			switch (e.ColName)
			{
				
				case "specimen_code": // 검체코드
					aGrd[e.RowNumber, e.ColName].ToolTipText = aGrd.GetItemString(e.RowNumber, "specimen_name");
					break;

				case "jusa": // 주사
					aGrd[e.RowNumber, e.ColName].ToolTipText = aGrd.GetItemString(e.RowNumber, "jusa_name");
					break;

				case "pay": // 급여
					aGrd[e.RowNumber, e.ColName].ToolTipText = aGrd.GetItemString(e.RowNumber, "pay_name");
					break;

				case "bogyong_code": // 용법코드
					aGrd[e.RowNumber, e.ColName].ToolTipText = aGrd.GetItemString(e.RowNumber, "bogyong_name") + aGrd.GetItemString(e.RowNumber, "dv_name") ;
					break;

				case "jundal_part": // 전달파트
					aGrd[e.RowNumber, e.ColName].ToolTipText = aGrd.GetItemString(e.RowNumber, "jundal_part_name");
					break;
				
			}
			#endregion
		}

		private void grdOCS2003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				int rowIndex = grdOCS2003.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				string plan_yn, pkocs6010, order_date, input_gubun, order_gubun, group_ser;

				if(grdOCS2003.CurrentColNumber == 0)
				{
					plan_yn     = grdOCS2003.GetItemString(rowIndex, "plan_yn"    );
					pkocs6010   = grdOCS2003.GetItemString(rowIndex, "pkocs6010"  );
					order_date  = grdOCS2003.GetItemString(rowIndex, "order_date" );
					input_gubun = grdOCS2003.GetItemString(rowIndex, "input_gubun");
					order_gubun = grdOCS2003.GetItemString(rowIndex, "order_gubun");
					group_ser   = grdOCS2003.GetItemString(rowIndex, "group_ser"  );					
					
					if(grdOCS2003.GetItemString(rowIndex, "select") == "")
					{
						for(int i = 0; i < grdOCS2003.RowCount; i++)
						{
							if( plan_yn     == grdOCS2003.GetItemString(i, "plan_yn"    ) &&
								pkocs6010   == grdOCS2003.GetItemString(i, "pkocs6010"  ) &&
								order_date  == grdOCS2003.GetItemString(i, "order_date" ) &&
								input_gubun == grdOCS2003.GetItemString(i, "input_gubun") &&
								order_gubun == grdOCS2003.GetItemString(i, "order_gubun") &&
								group_ser   == grdOCS2003.GetItemString(i, "group_ser"  ) )
							{
								//불용처리된 것은 선택을 막는다.
								if(grdOCS2003.GetItemString(i, "bulyong_check") == "Y") continue;

								if( plan_yn == "Y" || CheckOrderConfirmPossible(i))
								{
									grdOCS2003.SetItemValue(i, "select", " ");
									SelectionBackColorChange(sender, i, "Y");
                            
									grdOCS2003.SetItemValue(i, "confirm_check"     , "Y"            );
									grdOCS2003.SetItemValue(i, "nurse_confirm_user", UserInfo.UserID);
									grdOCS2003.SetItemValue(i, "nurse_pickup_user" , UserInfo.UserID);
								}
							}
						}
					}
					else
					{
						if( plan_yn == "N")
						{
							if(CheckOrderConfirmCancelPossible(rowIndex))
							{
								grdOCS2003.SetItemValue(rowIndex, "select", "");
								SelectionBackColorChange(sender, rowIndex, "N");
                            
								grdOCS2003.SetItemValue(rowIndex, "confirm_check"     , "N");
								grdOCS2003.SetItemValue(rowIndex, "nurse_confirm_user", "" );
								grdOCS2003.SetItemValue(rowIndex, "nurse_pickup_user" , "" );
							}
						}
						else
						{
							for(int i = 0; i < grdOCS2003.RowCount; i++)
							{
								if( plan_yn     == grdOCS2003.GetItemString(i, "plan_yn"    ) &&
									pkocs6010   == grdOCS2003.GetItemString(i, "pkocs6010"  ) &&
									order_date  == grdOCS2003.GetItemString(i, "order_date" ) &&
									input_gubun == grdOCS2003.GetItemString(i, "input_gubun") &&
									order_gubun == grdOCS2003.GetItemString(i, "order_gubun") &&
									group_ser   == grdOCS2003.GetItemString(i, "group_ser"  ) )
								{									
									grdOCS2003.SetItemValue(i, "select", "");
									SelectionBackColorChange(sender, i, "N");
                            
									grdOCS2003.SetItemValue(i, "confirm_check"     , "N");
									grdOCS2003.SetItemValue(i, "nurse_confirm_user", "" );
									grdOCS2003.SetItemValue(i, "nurse_pickup_user" , "" );									
								}
							}
						}

					}					
				}
			}	
		}

		#endregion

		#region [Fuction]

		private void LoadOCS2003()
		{
			grdOCS2003.Reset();
			lblSelectOrder.ImageIndex = 0;
			lblSelectOrder.Text = " 全体選択";

			pnlInput_gubun.Controls.Clear();

			if(mPatientInfo.GetPatientInfo == null) return;

			grdOCS2003.SetBindVarValue("f_bunho"    , mPatientInfo.GetPatientInfo["bunho"].ToString());
            grdOCS2003.SetBindVarValue("f_fkinp1001", mPatientInfo.GetPatientInfo["naewon_key"].ToString());
            grdOCS2003.SetBindVarValue("f_from_date", dpkFrom_date.GetDataValue());
            grdOCS2003.SetBindVarValue("f_to_date",   dpkTo_date.GetDataValue());
            grdOCS2003.SetBindVarValue("f_hosp_code", mHospCode);
            grdOCS2003.QueryLayout(true);
			ShowInput_gubun();
		}
		#endregion

		#region [Input_gubun RadioBotton 생성]
        
		const int INPUT_GUBUN_WIDTH  = 112;
		const int INPUT_GUBUN_HEIGHT = 26;		

		private void ShowInput_gubun()
		{
			pnlInput_gubun.Controls.Clear();
            
			string input_gubun = "";

			XRadioButton rbtInput_gubun;

			int startX = 2;

			foreach(DataRow row in grdOCS2003.LayoutTable.Select("", "input_gubun ASC") )
			{
				if(input_gubun != row["input_gubun"].ToString())
				{
					rbtInput_gubun = new XRadioButton();
					rbtInput_gubun.Appearance = System.Windows.Forms.Appearance.Button;
					rbtInput_gubun.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
					rbtInput_gubun.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
					rbtInput_gubun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
					rbtInput_gubun.ImageList = this.ImageList;
					rbtInput_gubun.ImageIndex = 0;			
					rbtInput_gubun.Location = new System.Drawing.Point(startX, 2);
					rbtInput_gubun.Name = "rbt" + row["input_gubun"];
					rbtInput_gubun.Size = new System.Drawing.Size(112, 26);			
					rbtInput_gubun.Text = "     " + row["input_gubun_name"].ToString();
					rbtInput_gubun.Tag  = row["input_gubun"].ToString();
					rbtInput_gubun.Click += new System.EventHandler(this.rbtInput_gubun_Click);
					pnlInput_gubun.Controls.Add(rbtInput_gubun);
					
					startX = startX + INPUT_GUBUN_WIDTH;
					input_gubun = row["input_gubun"].ToString();
				}
			}
        
			if(pnlInput_gubun.Controls.Count > 0)
			{
                ((XRadioButton)pnlInput_gubun.Controls[0]).Checked = true;
				rbtInput_gubun_Click(pnlInput_gubun.Controls[0], null);
			}
			
		}

		private void rbtInput_gubun_Click(object sender, System.EventArgs e)
		{
			XRadioButton rbt = sender as XRadioButton;

			foreach( object obj in pnlInput_gubun.Controls)
			{
				if( ((XRadioButton)obj).Name == rbt.Name )
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
					((XRadioButton)obj).ImageIndex = 1;
				}
				else
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
					((XRadioButton)obj).ImageIndex = 0;  
				}
			}

			//해당 input_gubun filter
			SetFilter();
		
		}
		#endregion

		#region [Filtering]

		private void SetFilter()
		{
			grdOCS2003.ClearFilter();
			if(grdOCS2003.RowCount < 1) return;

			//해당 input_gubun filter
			string input_gubun  = "";
			foreach(object obj in pnlInput_gubun.Controls)
			{
				if(((XRadioButton)obj).Checked)
				{
					input_gubun = ((XRadioButton)obj).Tag.ToString();
					break;
				}
			}

			string confirmCheck = "";
			if(rbtConfirmN.Checked)
				confirmCheck = "N";
			else if(rbtConfirmY.Checked)
				confirmCheck = "Y";

			string filter       = "";
			if(confirmCheck != "")
				filter = "input_gubun = '" + input_gubun + "' and confirm_check = '" + confirmCheck + "' ";
			else
				filter = "input_gubun = '" + input_gubun + "' ";

            
			grdOCS2003.SetFilter(filter);
            
			SelectionBackColorChange(grdOCS2003);

		}

		#endregion

		#region [Cotrol Event]

		private void pbxBunho_PatientSelected(object sender, System.EventArgs e)
		{
			SetBunho(pbxBunho.BunHo);
		}

		private void pbxBunho_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			InitialBunhoChange();
		}

		private void lblSelectOrder_Click(object sender, System.EventArgs e)
		{
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				
				if(lblSelectOrder.ImageIndex == 0)
				{
					grdSelectAll(grdOCS2003, true);
					lblSelectOrder.ImageIndex = 1;
					lblSelectOrder.Text = " 全体選択取消";
				}
				else
				{
					grdSelectAll(grdOCS2003, false);
					lblSelectOrder.ImageIndex = 0;
					lblSelectOrder.Text = " 全体選択";
				}
				
			}
			finally
			{					
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}			
		}
        
		/// <summary>
		/// 해당 Grid 전체선택 해제
		/// </summary>
		/// <param name="grd"></param>
		/// <param name="select"></param>
		private void grdSelectAll(XGrid grdObject, bool select)
		{
			int rowIndex = -1;

			if(select)
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					if(grdObject.GetItemString( rowIndex, "bulyong_check") != "Y" ) 
					{
						if(CheckOrderConfirmPossible(rowIndex))
						{
							grdOCS2003.SetItemValue(rowIndex, "select", " ");
							SelectionBackColorChange(grdOCS2003, rowIndex, "Y");
                            
							grdOCS2003.SetItemValue(rowIndex, "confirm_check"     , "Y"            );
							grdOCS2003.SetItemValue(rowIndex, "nurse_confirm_user", UserInfo.UserID);
							grdOCS2003.SetItemValue(rowIndex, "nurse_pickup_user" , UserInfo.UserID);
						}
						else
						{
							grdOCS2003.SetFocusToItem(rowIndex, 0);
							break;
						}
					}
				}
			}
			else
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					if(grdObject.GetItemString( rowIndex, "bulyong_check") != "Y" ) 
					{
						if(CheckOrderConfirmCancelPossible(rowIndex))
						{
							grdOCS2003.SetItemValue(rowIndex, "select", "");
							SelectionBackColorChange(grdOCS2003, rowIndex, "N");
                            
							grdOCS2003.SetItemValue(rowIndex, "confirm_check"     , "N");
							grdOCS2003.SetItemValue(rowIndex, "nurse_confirm_user", "" );
							grdOCS2003.SetItemValue(rowIndex, "nurse_pickup_user" , "" );
						}
						else
						{
							grdOCS2003.SetFocusToItem(rowIndex, 0);
							break;
						}
					}
				}
			}

			SelectionBackColorChange(grdObject);
		}
		
		private void dpkOrder_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			LoadOCS2003();
		}
        
		/// <summary>
		/// 간호확인여부 Filtering
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbtConfirm_Click(object sender, System.EventArgs e)
		{
			SetFilter();
		}

		#endregion

		#region [Check]

		/// <summary>
		/// 간호확인이 가능한지 Check한다.
		/// </summary>
		/// <returns></returns>
		private bool CheckOrderConfirmPossible(int rowIndex)
		{
			bool returnValue = true;

			if(	rowIndex < 0 ) return false;

			string checkValue = GetCheckValue("confirm_check", grdOCS2003.GetItemString(rowIndex, "pkocs2003"));

			switch (checkValue.Trim())
			{
				case "B":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "不用処理されたオーダコードです。処方の再入力を求めてください。" : "불용처리 되어 처방확인이 불가능합니다. \n\r 처방을 재입력을 요청하세요";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "J":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "該当オーダの伝達基準が変わりました。処方の再入力を求めてください。" : "해당 처방의 전달기준이 바뀌었습니다.\n\r 처방을 재입력을 요청하세요";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "D":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "同一グループ内に重複オーダが存在します。確認しますか。" : "동일그룹내에 중복 Order가 존재합니다.\n\r 확인하시겠습니까?";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認" : "간호확인";
					DialogResult result;
					result = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Question); 
					if(result == DialogResult.Yes)
						returnValue = true;
					else if(result == DialogResult.Cancel)
						returnValue = false;

					break;

				case "OE":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "入力されたオーダ単位は間違っています。\n\r 確認してください。": "입력된 처방단위의 오류가 있습니다. \n\r 확인하세요.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "OB":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダ単位が必ず入力されるべきです。\n\r 確認してください。": "처방단위가 반드시 입력되어야 합니다. \n\r 확인하세요.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "ON":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダ単位値が不必要です。\n\r 確認してください。": "처방단위값이 불필요합니다. \n\r 확인하세요.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "G":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "入力されたオーダ日付が退院日付より大きいです。\n\r 確認してください。": "입력된 처방일자가 가퇴원일자보다 큽니다. \n\r 확인하세요.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;
				
				default:

					returnValue = true;

					break;
			}
            
			return returnValue;
		}

		/// <summary>
		/// 간호확인취소가 가능한지 Check한다.
		/// </summary>
		/// <returns></returns>
		private bool CheckOrderConfirmCancelPossible(int rowIndex)
		{
			bool returnValue = true;

			if(	rowIndex < 0 ) return false;

			///간호확인을 한 사람만이 간호확인취소가 가능하다.
			string nurse_confirm_user = grdOCS2003.GetItemString(rowIndex, "nurse_pickup_user");
			if(UserInfo.UserID != nurse_confirm_user)
			{
//				string user_name = this.GetUSER_NAME(nurse_confirm_user);
//
//				mbxMsg = NetInfo.Language == LangMode.Jr ? "確認者[" + user_name + "]が違えばキャンセルできません。\n\r 確認してください。": "확인자가 다르면 취소를 할 수 없습니다. \n\r 확인하세요.";
//				mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認取消し不可" : "간호확인취소불가";
//				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
//				returnValue = false;
			}

			string checkValue = GetCheckValue("confirm_cancel_check", grdOCS2003.GetItemString(rowIndex, "pkocs2003"));
			if(checkValue != "N")
			{
                mbxMsg = NetInfo.Language == LangMode.Jr ? "既に部門で実施されたオーダは取消できません。\n\r ご確認ください。" : "이미 시행된 처방입니다. \n\r 확인하세요.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認取消不可" : "간호확인취소불가";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
				returnValue = false;
			}

			return returnValue;

		}
        
		/// <summary>
		/// 간호확인시 각종 CHECK값을 가져옵니다.
		/// </summary>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCheckValue(string checkMode, string code)
		{
			string checkValue = "";
            string cmdText    = "";
            object retVal     = null;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_code", code);
            bindVars.Add("f_hosp_code", mHospCode);

			if(code.Trim() == "" ) return checkValue;

			switch (checkMode)
			{
				case "confirm_check":
          
					cmdText = @"SELECT FN_OCS_CHECK_CAN_CONFIRM_INP(:f_code) FROM DUAL ";

                    retVal = Service.ExecuteScalar(cmdText);

                    if (Service.ErrCode != 0 || TypeCheck.IsNull(retVal))
					{
						checkValue = "F";					
					}
					else
                        checkValue = retVal.ToString();

					break;

				case "confirm_cancel_check":
                    
                    cmdText = @"SELECT DECODE(OCS_FLAG, '1', 'Y', 'N')
  FROM OCS2003
 WHERE PKOCS2003 = :f_code
   AND HOSP_CODE = :f_hosp_code";

                    retVal = Service.ExecuteScalar(cmdText, bindVars);

                    if (Service.ErrCode != 0 || TypeCheck.IsNull(retVal))
					{
						checkValue = "F";					
					}
					else
						checkValue = retVal.ToString();

					break;
				
				default:
					break;
			}

			return checkValue;

		}
		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			SetMsg("");

			switch (e.Func)
			{
				case FunctionType.Query:

					e.IsBaseCall = false;

					LoadOCS2003();
				
					break;

				case FunctionType.Update:

					e.IsBaseCall = false;
                    
					this.AcceptData();
					
					if(TypeCheck.IsNull(dbxConfirmUserName.GetDataValue()))
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "看護確認 IDに間違いがあります。 ご確認ください。" : "간호확인 ID가 정확하지않습니다. 확인바랍니다.";							
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
						txtConfirmUser.Focus();
                        txtConfirmUser.SelectAll();
						break;
					}

					//환자가 선택되어 있지않으면 Slip
					if(this.mPatientInfo.GetPatientInfo == null)
						return;

					bool jusa_confirm = false;
					//주사Check
					for(int i = 0; i < grdOCS2003.RowCount; i++)
					{
						if(grdOCS2003.GetRowState(i) == DataRowState.Modified && grdOCS2003.GetItemString(i, "confirm_check") == "Y" &&
						   grdOCS2003.GetItemString(i, "order_gubun").Substring(1, 1) == "B" )
						{
							jusa_confirm = true;
							break;
						}
					}

					if(grdOCS2003.SaveLayout())
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
						SetMsg(mbxMsg);

						try
						{
							IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

							CommonItemCollection commandParams  = new CommonItemCollection();
							commandParams.Add( "retrieve", "Y");
							scrOpener.Command("retrieve", commandParams);

							if(this.mAuto_close)
								this.Close();
						}
						catch
						{
						}

						LoadOCS2003();

						// 간호확인시 주사마감
						if(jusa_confirm)
						{
							CommonItemCollection openParams  = new CommonItemCollection();							
							openParams.Add("bunho"  , mPatientInfo.GetPatientInfo["bunho"  ].ToString());
							openParams.Add("ho_dong", mPatientInfo.GetPatientInfo["ho_dong"].ToString());
					
							//CP등록 화면 Open
							XScreen.OpenScreenWithParam(this, "DRGS", "DRG3010P89", ScreenOpenStyle.ResponseSizable, openParams);
						}
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : "저장이 실패하였습니다."; 
						mbxMsg = mbxMsg + Service.ErrMsg;
						mbxCap = NetInfo.Language == LangMode.Jr ? "保存エラー" : "Save Error";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
					}

					break;

					
				default:

					break;
			}
		}

		#endregion

		#region [환자정보 Load]

		private void SetBunho(string aBunho)
		{
			string order_date = "";
			
			if (TypeCheck.IsNull(aBunho)) 
			{						
				InitialBunhoChange();
				return;
			}
			
			order_date = dpkFrom_date.GetDataValue();

			this.mPatientInfo.Parameter.Clear();
			this.mPatientInfo.Parameter.Bunho = aBunho;
			this.mPatientInfo.Parameter.Gwa = "%";            //OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items["doctor_gwa"].ToString();
			this.mPatientInfo.Parameter.Doctor = "%";         //OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items["doctor"].ToString();    
			this.mPatientInfo.Parameter.IOEGubun =   "I";     // 입원
			this.mPatientInfo.Parameter.JaewonFlag = "Y";     // 재원상태
			this.mPatientInfo.Parameter.NaewonDate = "";      // order_date;
			//this.mPatientInfo.Parameter.PopUp = "Y";

			if (!this.mPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo))
			{
				if (this.mPatientInfo.GetPatientInfo == null || TypeCheck.IsNull(this.mPatientInfo.GetPatientInfo["suname"]))
					mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号に間違いがあります。 ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
				else
					mbxMsg = NetInfo.Language == LangMode.Jr ? "該当患者に対してオーダ権限がありません。ご確認ください。" : "해당환자에 대해 처방권한이 없습니다. 확인바랍니다.";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
				InitialBunhoChange();
				
				return;
			}

			// 재원이면서 퇴원일자가 있는 경우는 가퇴원일자가 있는 환자입니다.
			if (!TypeCheck.IsNull(this.mPatientInfo.GetPatientInfo["toiwon_date"].ToString()))
			{

				if (int.Parse(this.mPatientInfo.GetPatientInfo["toiwon_date"].ToString().Replace("/","")) < int.Parse(order_date.Replace("/","")))
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ? "[{0}]日付の仮退院の患者様です。\n\r仮退院以前の日付のみがオーダ入力可能です。" : "[%s]일자로 가퇴원되었습니다. 이전일자로만 처방입력가능합니다.";
					mbxMsg = String.Format(mbxMsg, this.mPatientInfo.GetPatientInfo["toiwon_date"].ToString());
					XMessageBox.Show(mbxMsg, mbxCap);
					pbxBunho.SetPatientID("");					
					return;
				}
			}

			LoadOCS2003();
		}

		private void InitialBunhoChange()
		{
			mPatientInfo.ClearPatientInfo();
			grdOCS2003.SetBindVarValue("f_bunho"    , "");
            grdOCS2003.SetBindVarValue("f_fkinp1001", "0");
            grdOCS2003.SetBindVarValue("f_from_date", dpkFrom_date.GetDataValue());
            grdOCS2003.SetBindVarValue("f_to_date",   dpkTo_date.GetDataValue());
            grdOCS2003.SetBindVarValue("f_hosp_code", mHospCode);
			grdOCS2003.Reset();
			pnlInput_gubun.Controls.Clear();
			pbxBunho.Focus();

			lblSelectOrder.ImageIndex = 0;
			lblSelectOrder.Text = " 全体選択";
		}
		
		#endregion

		#region [사용자명을 가져옵니다.]
        
		private string GetUSER_NAME(string aUser_id)
		{
			string user_name = "";
            string cmdText   = "";
            object retVal    = null;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_user_id", aUser_id);
            bindVars.Add("f_hosp_code", mHospCode);

            cmdText = @"SELECT MEMB_NAME
  FROM OCS0130
 WHERE MEMB      = :f_user_id
   AND HOSP_CODE = :f_hosp_code";

            retVal = Service.ExecuteScalar(cmdText, bindVars);
                    
			if(!TypeCheck.IsNull(retVal))
				user_name = retVal.ToString();

			return user_name;
		}

		private string GetAdminUSER_NAME(string aUser_id)
        {
            string user_name  = "";
            string cmdText    = "";
            DataTable dtTable = new DataTable();
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_user_id", aUser_id);
            bindVars.Add("f_hosp_code", mHospCode);

            cmdText = @"SELECT USER_NM, FN_PPE_LOAD_CONFIRM_ENABLE(USER_ID) CONFIRM_GRANT
  FROM ADM3200
 WHERE USER_ID   = :f_user_id
   AND HOSP_CODE = :f_hosp_code";

            dtTable = Service.ExecuteDataTable(cmdText, bindVars);
                    
			if(dtTable.Rows.Count > 0)
			{
				if( dtTable.Rows[0]["confirm_grant"].ToString() != "Y" )
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダ確認権限がありません。ご確認ください。" : "오더확인권한이 없습니다. 확인바랍니다.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					return user_name;

				}
				user_name = dtTable.Rows[0]["user_nm"].ToString();				
			}


			return user_name;
		}

		#endregion
		
		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
		private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
		{
			XEditGrid grdObject = (XEditGrid)grid;          
            
			//선택된 Row에대해서 색을 변경한다
			//data   Y :색을 변경, N :색을 변경 해제
			//image 설정
			if(data == "Y")
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
			else
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

			for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
			{
				if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
				{
					// 돈복여부
					if( grdObject.GetItemString(currentRowIndex, "donbog_yn") == "Y")
					{
						grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
						continue;
					}

					// 불균등분할
					if( !TypeCheck.IsNull(grdObject.GetItemString(currentRowIndex, "dv_name")))
					{
						grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
						continue;
					}
				}

				if(data == "Y")
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
					//grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
				}
				else 
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
					//grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
				}
			}
		}
			
		private void SelectionBackColorChange(object grid)
		{
			XEditGrid grdObject = (XEditGrid)grid;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{
				//불용은 넘어간다.
				if(grdObject.CellInfos.Contains("bulyong_check") && grdObject.GetItemString(rowIndex, "bulyong_check") == "Y" ) continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " " || grdObject.GetItemString(rowIndex, "confirm_check").ToString() == "Y")
				{
					if(grdObject.GetItemString(rowIndex, "select") == "")
						grdObject.SetItemValue(rowIndex, "select", " ");


					//image 변경
                    if (rowIndex > 199)
                    {
                    }
                    else
                    {
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];

                        //ColorYn Y :색을 변경, N :색을 변경 해제
                        for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                        {
                            if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                            {
                                // 돈복여부
                                if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                                {
                                    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                    continue;
                                }

                                // 불균등분할
                                if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                                {
                                    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                    continue;
                                }
                            }


                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                            //grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                        }
                    }
				}
				else
				{
					//image 변경
                    if (rowIndex > 199)
                    {
                        //XMessageBox.Show("照会結果が多すぎます。照会期間を短くして再照会してください。", "ご注意", MessageBoxIcon.Warning);
                        //return;
                    }
                    else
                    {
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

                        for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                        {
                            if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                            {
                                // 돈복여부
                                if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                                {
                                    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                    continue;
                                }

                                // 불균등분할
                                if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                                {
                                    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                    continue;
                                }
                            }


                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                            //grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                        }
                    }
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
				this.pbxBunho.Focus();
				this.pbxBunho.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.pbxBunho.BunHo.ToString()))
			{
				return new XPatientInfo(this.pbxBunho.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion 
		
		#region [간호확인사용자]
		private void txtConfirmUser_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			dbxConfirmUserName.SetDataValue("");

			if( TypeCheck.IsNull(e.DataValue) )
			{
				txtConfirmUser.SetDataValue("");
			}
			
			string user_nm = GetAdminUSER_NAME(e.DataValue);

			if( TypeCheck.IsNull(user_nm) )
			{
				txtConfirmUser.SetDataValue("");
				txtConfirmUser.Focus();
				txtConfirmUser.SelectAll();
				return;
			}

			dbxConfirmUserName.SetDataValue(user_nm);
		}

		private void btnClearConfirmUser_Click(object sender, System.EventArgs e)
		{
			txtConfirmUser.SetDataValue("");
			dbxConfirmUserName.SetDataValue("");
		}
		#endregion


        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS2003U10 parent = null;
            public XSavePerformer(OCS2003U10 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                object retVal = "";

                //Grid에서 넘어온 Bind 변수에 q_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                #region
                /*
                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"";
                        break;
                    case DataRowState.Modified:
                        cmdText = @"";
                        break;
                    case DataRowState.Deleted:
                        cmdText = @"";
                        break;
                }
*/
                #endregion

                /* 간호확인 */
                if (item.BindVarList["f_confirm_check"].VarValue.Equals("Y"))
                {
                    if (item.BindVarList["f_plan_yn"].VarValue.Equals("Y"))
                    {
                        cmdText = @"UPDATE OCS6013
                                       SET UPD_ID             = :q_user_id,
                                           UPD_DATE           = SYSDATE   ,
                                           NURSE_HOLD_USER    = NULL      ,
                                           NURSE_HOLD_DATE    = NULL      ,
                                           NURSE_HOLD_TIME    = NULL
                                     WHERE PKOCS6013          = :f_pkocs2003
                                       AND HOSP_CODE          = :f_hosp_code";

                        if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                        {
                            ArrayList inputList  = new ArrayList();
                            ArrayList outputList = new ArrayList();

                            inputList.Add(item.BindVarList["f_bunho"].VarValue);
                            inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
                            inputList.Add(item.BindVarList["f_pkocs6010"].VarValue);
                            inputList.Add(item.BindVarList["f_order_date"].VarValue);
                            inputList.Add(item.BindVarList["f_input_gubun"].VarValue);
                            inputList.Add(item.BindVarList["f_order_gubun"].VarValue);
                            inputList.Add(item.BindVarList["f_group_ser"].VarValue);
                            inputList.Add(item.BindVarList["f_confirm_user"].VarValue);

                            if (Service.ExecuteProcedure("PR_OCS_APPLY_PLAN_ORDER_GROUP", inputList, outputList))
                            {
                                if (outputList[1].ToString().Equals("1"))
                                {
                                    XMessageBox.Show(outputList[0].ToString(), "保存エラー", MessageBoxIcon.Error);
                                    return false;
                                }
                                else if (!outputList[1].ToString().Equals("0"))
                                {
                                    XMessageBox.Show(outputList[0].ToString(), "保存エラー", MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                XMessageBox.Show(Service.ErrFullMsg, "保存エラー", MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        cmdText = @"SELECT DECODE(NURSE_PICKUP_USER, NULL, 'N', 'Y')
                                      FROM OCS2003
                                     WHERE PKOCS2003 = :f_pkocs2003
                                       AND HOSP_CODE = :f_hosp_code";
                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                        {
                            XMessageBox.Show("既に看護されたORDER[ " + item.BindVarList["f_hangmog_code"].VarValue + " ]が存在します。"
                            , "保存エラー", MessageBoxIcon.Error);
                            return false;
                        }

                        cmdText = @"UPDATE OCS2003
                                       SET UPD_ID             = :q_user_id      ,
                                           UPD_DATE           = SYSDATE         ,
                                           NURSE_PICKUP_USER  = :f_confirm_user                                                         ,
                                           NURSE_PICKUP_DATE  = TRUNC(SYSDATE)                                                          ,
                                           NURSE_PICKUP_TIME  = TO_CHAR(SYSDATE, 'HH24MI')                                              ,
                                           NURSE_HOLD_USER    = NULL,
                                           NURSE_HOLD_DATE    = NULL,
                                           NURSE_HOLD_TIME    = NULL
                                     WHERE PKOCS2003          = :f_pkocs2003
                                       AND HOSP_CODE          = :f_hosp_code";

                    }
                }
                else
                {
                    if (item.BindVarList["f_plan_yn"].VarValue.Equals("Y"))
                    {
                    }
                    else
                    {
                        cmdText = @"SELECT DECODE(ACTING_DATE, NULL, 'N', 'Y')
                                      FROM OCS2003
                                     WHERE PKOCS2003 = :f_pkocs2003
                                       AND HOSP_CODE = :f_hosp_code";

                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList).ToString();

                        if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                        {
                            XMessageBox.Show("既に施行されたORDER [ " + item.BindVarList["f_hangmog_code"] + " ] が存在します。"
                            , "保存エラー", MessageBoxIcon.Error);
                            return false;
                        }

                        cmdText = @"UPDATE OCS2003
                                       SET UPD_ID             = :q_user_id,
                                           UPD_DATE           = SYSDATE   ,
                                           NURSE_PICKUP_USER  = NULL      ,
                                           NURSE_PICKUP_DATE  = NULL      ,
                                           NURSE_PICKUP_TIME  = NULL
                                     WHERE PKOCS2003          = :f_pkocs2003
                                       AND HOSP_CODE          = :f_hosp_code";
                    }
                }

                bool retService = Service.ExecuteNonQuery(cmdText, item.BindVarList);

                if (!retService)
                {
                    XMessageBox.Show(Service.ErrFullMsg, "保存エラー", MessageBoxIcon.Error);
                }

                return retService;
            }
        }
        #endregion

	}
}

