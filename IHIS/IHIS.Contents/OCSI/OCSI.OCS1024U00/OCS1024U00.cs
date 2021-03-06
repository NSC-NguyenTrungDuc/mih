#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCSI.Properties;

#endregion

namespace IHIS.OCSI
{
	/// <summary>
	/// OCS1023U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS1024U00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		//private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		//private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		//private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		//private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
		#endregion

        private MultiLayout mLayOutputHangmogInfo = new MultiLayout();    // 항목정보 서비스 OutPutData LayoutTable
        
		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";	

		//등록번호
		private string mBunho = "";
		//진료과
		private string mGwa = "";

        private string mMode = "";

        // Parameter　　*주가
        private string mAutoClose = "N";

        // Parameter
        private string mInputTab = "%";
        private string mGenericSearchYN = "N";
        private string INPUTTAB = "01"; //持参薬は基本薬のみ
        private string IOEGUBUN = "I";  // 基本入院オーダでしか登録しない
        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리 
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리

		//OCS1023_SEQ
		private string mSeq = string.Empty;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell94;
		private IHIS.Framework.XEditGridCell xEditGridCell95;
		private IHIS.Framework.XEditGridCell xEditGridCell96;
		private IHIS.Framework.XEditGridCell xEditGridCell97;
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
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell67;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell103;
		private IHIS.Framework.XEditGridCell xEditGridCell98;
		private IHIS.Framework.XEditGridCell xEditGridCell116;
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
		private IHIS.Framework.XEditGridCell xEditGridCell99;
		private IHIS.Framework.XEditGridCell xEditGridCell100;
		private IHIS.Framework.XEditGridCell xEditGridCell101;
		private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
        private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XEditGrid grdOCS1024;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XButton btnDelete;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XLabel lblSelectOrder;
		private IHIS.Framework.MultiLayout dloSelectOCS1024;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell68;
        private XCheckBox cbxGeneric_YN;
        private XPatientBox paBox;
        private XDatePicker dpkOrder_Date;
        private XLabel xLabel1;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XLabel xLabel2;
        private XDWWorker dwPrint;
        private XButton btnPrint;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XLabel xLabel4;
        private XDictComboBox cbxActor;
        private XTabControl tabControl;
        private IHIS.X.Magic.Controls.TabPage tabPage1;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
        private XPanel xPanel2;
        private XPanel xPanel3;
        private XPanel xPanel4;
        private XLabel lblSelectJusaOrder;
        private XEditGrid grdOCS1024Jusa;
        private XEditGridCell xEditGridCell115;
        private XEditGridCell xEditGridCell117;
        private XEditGridCell xEditGridCell120;
        private XEditGridCell xEditGridCell121;
        private XEditGridCell xEditGridCell122;
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell124;
        private XEditGridCell xEditGridCell125;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell127;
        private XEditGridCell xEditGridCell128;
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
        private XEditGridCell xEditGridCell197;
        private XEditGridCell xEditGridCell198;
        private XEditGridCell xEditGridCell199;
        private XEditGridCell xEditGridCell200;
        private XEditGridCell xEditGridCell201;
        private XEditGridCell xEditGridCell202;
        private XEditGridCell xEditGridCell203;
        private XEditGridCell xEditGridCell204;
        private XEditGridCell xEditGridCell205;
        private XEditGridCell xEditGridCell206;
        private XEditGridCell xEditGridCell207;
        private XEditGridCell xEditGridCell208;
        private XGridHeader xGridHeader4;
        private MultiLayout dloSelectOCS1024Jusa;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public OCS1024U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			//this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			//this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			//this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
			//this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리

            this.SaveLayoutList.Add(this.grdOCS1024);
            this.grdOCS1024.SavePerformer = new XSavePerformer(this);

            this.SaveLayoutList.Add(this.grdOCS1024Jusa);
            this.grdOCS1024Jusa.SavePerformer = new XSavePerformer(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1024U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnPrint = new IHIS.Framework.XButton();
            this.cbxGeneric_YN = new IHIS.Framework.XCheckBox();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnProcess = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdOCS1024 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.lblSelectOrder = new IHIS.Framework.XLabel();
            this.dloSelectOCS1024 = new IHIS.Framework.MultiLayout();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.dpkOrder_Date = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dwPrint = new IHIS.Framework.XDWWorker();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.tabControl = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.grdOCS1024Jusa = new IHIS.Framework.XEditGrid();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell182 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell183 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell184 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell185 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell186 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell187 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell188 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell189 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell190 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell191 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell192 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell193 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell194 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell195 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell196 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell197 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell198 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell199 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell200 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell201 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell202 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell203 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell204 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell205 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell206 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell207 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell208 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader4 = new IHIS.Framework.XGridHeader();
            this.lblSelectJusaOrder = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.dloSelectOCS1024Jusa = new IHIS.Framework.MultiLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1024)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1024)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1024Jusa)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1024Jusa)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "약국정보관리16.ico");
            this.ImageList.Images.SetKeyName(3, "주사실수행관리16.ico");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnPrint);
            this.xPanel1.Controls.Add(this.cbxGeneric_YN);
            this.xPanel1.Controls.Add(this.btnDelete);
            this.xPanel1.Controls.Add(this.btnProcess);
            this.xPanel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbxGeneric_YN
            // 
            resources.ApplyResources(this.cbxGeneric_YN, "cbxGeneric_YN");
            this.cbxGeneric_YN.Name = "cbxGeneric_YN";
            this.cbxGeneric_YN.TabStop = false;
            this.cbxGeneric_YN.UseVisualStyleBackColor = false;
            this.cbxGeneric_YN.CheckedChanged += new System.EventHandler(this.cbxGeneric_YN_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnProcess
            // 
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdOCS1024
            // 
            this.grdOCS1024.AddedHeaderLine = 1;
            this.grdOCS1024.ApplyPaintEventToAllColumn = true;
            this.grdOCS1024.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell8,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
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
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell106,
            this.xEditGridCell40,
            this.xEditGridCell67,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell103,
            this.xEditGridCell98,
            this.xEditGridCell116,
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
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell104,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell9,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell73,
            this.xEditGridCell75,
            this.xEditGridCell74,
            this.xEditGridCell77,
            this.xEditGridCell1,
            this.xEditGridCell76,
            this.xEditGridCell79});
            this.grdOCS1024.ColPerLine = 15;
            this.grdOCS1024.Cols = 16;
            this.grdOCS1024.ControlBinding = true;
            resources.ApplyResources(this.grdOCS1024, "grdOCS1024");
            this.grdOCS1024.EnableMultiSelection = true;
            this.grdOCS1024.FixedCols = 1;
            this.grdOCS1024.FixedRows = 2;
            this.grdOCS1024.FocusColumnName = "hangmog_code";
            this.grdOCS1024.HeaderHeights.Add(34);
            this.grdOCS1024.HeaderHeights.Add(0);
            this.grdOCS1024.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdOCS1024.Name = "grdOCS1024";
            this.grdOCS1024.QuerySQL = resources.GetString("grdOCS1024.QuerySQL");
            this.grdOCS1024.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS1024.RowHeaderVisible = true;
            this.grdOCS1024.Rows = 3;
            this.grdOCS1024.RowStateCheckOnPaint = false;
            this.grdOCS1024.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1024.SelectionModeChangeable = true;
            this.grdOCS1024.TabStop = false;
            this.grdOCS1024.TogglingRowSelection = true;
            this.grdOCS1024.ToolTipActive = true;
            this.grdOCS1024.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1023_MouseDown);
            this.grdOCS1024.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1023_QueryEnd);
            this.grdOCS1024.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1023_QueryStarting);
            this.grdOCS1024.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS1024_GridColumnProtectModify);
            this.grdOCS1024.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS1024_GridColumnChanged);
            this.grdOCS1024.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1024_GridCellPainting);
            this.grdOCS1024.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS1024_GridFindClick);
            this.grdOCS1024.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1023_RowFocusChanged);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bunho";
            this.xEditGridCell10.Col = -1;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsNotNull = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "gwa";
            this.xEditGridCell11.Col = -1;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsNotNull = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "pkocs1024";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.Col = -1;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.CellLen = 2;
            this.xEditGridCell13.CellName = "group_ser";
            this.xEditGridCell13.CellWidth = 22;
            this.xEditGridCell13.Col = -1;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "seq";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell14.Col = -1;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell15.AutoTabDataSelected = true;
            this.xEditGridCell15.CellLen = 20;
            this.xEditGridCell15.CellName = "hangmog_code";
            this.xEditGridCell15.CellWidth = 77;
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell15.IsNotNull = true;
            this.xEditGridCell15.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.CellLen = 80;
            this.xEditGridCell16.CellName = "hangmog_name";
            this.xEditGridCell16.CellWidth = 214;
            this.xEditGridCell16.Col = 4;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.CellLen = 3;
            this.xEditGridCell17.CellName = "specimen_code";
            this.xEditGridCell17.CellWidth = 45;
            this.xEditGridCell17.Col = -1;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.InitValue = "*";
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            this.xEditGridCell17.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell18.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xEditGridCell18.CellName = "suryang";
            this.xEditGridCell18.CellWidth = 53;
            this.xEditGridCell18.Col = 5;
            this.xEditGridCell18.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.InitValue = "1";
            this.xEditGridCell18.IsNotNull = true;
            this.xEditGridCell18.MaxDropDownItems = 10;
            this.xEditGridCell18.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell18.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 6;
            this.xEditGridCell8.CellName = "ord_danui";
            this.xEditGridCell8.Col = -1;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsNotNull = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.CellLen = 100;
            this.xEditGridCell19.CellName = "ord_danui_name";
            this.xEditGridCell19.CellWidth = 43;
            this.xEditGridCell19.Col = 6;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellLen = 1;
            this.xEditGridCell20.CellName = "dv_time";
            this.xEditGridCell20.CellWidth = 22;
            this.xEditGridCell20.Col = 7;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.InitValue = "*";
            this.xEditGridCell20.IsNotNull = true;
            this.xEditGridCell20.Row = 1;
            this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellName = "dv";
            this.xEditGridCell21.CellWidth = 36;
            this.xEditGridCell21.Col = 8;
            this.xEditGridCell21.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.InitValue = "1";
            this.xEditGridCell21.IsNotNull = true;
            this.xEditGridCell21.Row = 1;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "dv_1";
            this.xEditGridCell94.Col = -1;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "dv_2";
            this.xEditGridCell95.Col = -1;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "dv_3";
            this.xEditGridCell96.Col = -1;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "dv_4";
            this.xEditGridCell97.Col = -1;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.CellName = "nalsu";
            this.xEditGridCell22.CellWidth = 49;
            this.xEditGridCell22.Col = 9;
            this.xEditGridCell22.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.InitValue = "1";
            this.xEditGridCell22.IsNotNull = true;
            this.xEditGridCell22.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.CellLen = 2;
            this.xEditGridCell23.CellName = "jusa";
            this.xEditGridCell23.CellWidth = 46;
            this.xEditGridCell23.Col = -1;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell24.CellName = "bogyong_code";
            this.xEditGridCell24.CellWidth = 67;
            this.xEditGridCell24.Col = 10;
            this.xEditGridCell24.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsNotNull = true;
            this.xEditGridCell24.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellLen = 1;
            this.xEditGridCell25.CellName = "emergency";
            this.xEditGridCell25.CellWidth = 27;
            this.xEditGridCell25.Col = -1;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellLen = 1;
            this.xEditGridCell26.CellName = "pay";
            this.xEditGridCell26.CellWidth = 36;
            this.xEditGridCell26.Col = -1;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.InitValue = "0";
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellLen = 1;
            this.xEditGridCell27.CellName = "fluid_yn";
            this.xEditGridCell27.CellWidth = 43;
            this.xEditGridCell27.Col = -1;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell27.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell27.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellLen = 1;
            this.xEditGridCell28.CellName = "tpn_yn";
            this.xEditGridCell28.CellWidth = 38;
            this.xEditGridCell28.Col = -1;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell28.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell28.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.CellLen = 1;
            this.xEditGridCell29.CellName = "anti_cancer_yn";
            this.xEditGridCell29.CellWidth = 52;
            this.xEditGridCell29.Col = -1;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            this.xEditGridCell29.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell29.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell29.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellLen = 1;
            this.xEditGridCell30.CellName = "portable_yn";
            this.xEditGridCell30.CellWidth = 34;
            this.xEditGridCell30.Col = -1;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell31.CellLen = 1;
            this.xEditGridCell31.CellName = "powder_yn";
            this.xEditGridCell31.CellWidth = 26;
            this.xEditGridCell31.Col = -1;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellLen = 1;
            this.xEditGridCell32.CellName = "special_yn";
            this.xEditGridCell32.CellWidth = 47;
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            this.xEditGridCell32.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell32.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell32.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellLen = 5;
            this.xEditGridCell33.CellName = "act_doctor";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell33.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell33.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.CellLen = 1;
            this.xEditGridCell34.CellName = "muhyo";
            this.xEditGridCell34.CellWidth = 21;
            this.xEditGridCell34.Col = -1;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellLen = 1;
            this.xEditGridCell35.CellName = "symya";
            this.xEditGridCell35.Col = -1;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "special_rate";
            this.xEditGridCell36.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell36.Col = -1;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.InitValue = "0";
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell37.CellLen = 30;
            this.xEditGridCell37.CellName = "act_doctor_name";
            this.xEditGridCell37.CellWidth = 90;
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell37.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell37.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 1;
            this.xEditGridCell38.CellName = "prn_yn";
            this.xEditGridCell38.Col = -1;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 1;
            this.xEditGridCell39.CellName = "prepare_yn";
            this.xEditGridCell39.Col = -1;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsUpdatable = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "order_gubun";
            this.xEditGridCell106.Col = -1;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellLen = 2;
            this.xEditGridCell40.CellName = "order_gubun_bas";
            this.xEditGridCell40.Col = -1;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell67.CellName = "order_gubun_bas_name";
            this.xEditGridCell67.CellWidth = 76;
            this.xEditGridCell67.Col = -1;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsUpdatable = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            this.xEditGridCell67.SuppressRepeating = true;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell41.CellLen = 2000;
            this.xEditGridCell41.CellName = "order_remark";
            this.xEditGridCell41.Col = -1;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell42.CellLen = 2000;
            this.xEditGridCell42.CellName = "nurse_remark";
            this.xEditGridCell42.CellWidth = 89;
            this.xEditGridCell42.Col = -1;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell103.CellLen = 2;
            this.xEditGridCell103.CellName = "mix_group";
            this.xEditGridCell103.CellWidth = 24;
            this.xEditGridCell103.Col = -1;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell98.CellLen = 1;
            this.xEditGridCell98.CellName = "wonyoi_order_yn";
            this.xEditGridCell98.CellWidth = 21;
            this.xEditGridCell98.Col = -1;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "wonnae_sayu_code";
            this.xEditGridCell116.Col = -1;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellLen = 1;
            this.xEditGridCell43.CellName = "input_control";
            this.xEditGridCell43.Col = -1;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsUpdatable = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellLen = 1;
            this.xEditGridCell44.CellName = "suga_yn";
            this.xEditGridCell44.Col = -1;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsUpdatable = false;
            this.xEditGridCell44.IsUpdCol = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellLen = 1;
            this.xEditGridCell45.CellName = "jaeryo_yn";
            this.xEditGridCell45.Col = -1;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsUpdatable = false;
            this.xEditGridCell45.IsUpdCol = false;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellLen = 1;
            this.xEditGridCell46.CellName = "special_check";
            this.xEditGridCell46.Col = -1;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.IsUpdCol = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellLen = 80;
            this.xEditGridCell47.CellName = "pris_name";
            this.xEditGridCell47.Col = -1;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdatable = false;
            this.xEditGridCell47.IsUpdCol = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellLen = 4;
            this.xEditGridCell48.CellName = "slip_code";
            this.xEditGridCell48.Col = -1;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.IsUpdCol = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 1;
            this.xEditGridCell49.CellName = "emergency_check";
            this.xEditGridCell49.Col = -1;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsUpdCol = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellLen = 1;
            this.xEditGridCell50.CellName = "specimen_yn";
            this.xEditGridCell50.Col = -1;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsUpdCol = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellLen = 1;
            this.xEditGridCell51.CellName = "multi_gumsa_yn";
            this.xEditGridCell51.Col = -1;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsUpdCol = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellLen = 1;
            this.xEditGridCell52.CellName = "specimen_cr_yn";
            this.xEditGridCell52.Col = -1;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsUpdCol = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellLen = 1;
            this.xEditGridCell53.CellName = "suryang_cr_yn";
            this.xEditGridCell53.Col = -1;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsUpdatable = false;
            this.xEditGridCell53.IsUpdCol = false;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellLen = 1;
            this.xEditGridCell54.CellName = "ord_danui_cr_yn";
            this.xEditGridCell54.Col = -1;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsUpdatable = false;
            this.xEditGridCell54.IsUpdCol = false;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellLen = 1;
            this.xEditGridCell55.CellName = "dv_time_cr_yn";
            this.xEditGridCell55.Col = -1;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsUpdatable = false;
            this.xEditGridCell55.IsUpdCol = false;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellLen = 1;
            this.xEditGridCell56.CellName = "dv_cr_yn";
            this.xEditGridCell56.Col = -1;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsUpdCol = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellLen = 1;
            this.xEditGridCell57.CellName = "nalsu_cr_yn";
            this.xEditGridCell57.Col = -1;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsUpdatable = false;
            this.xEditGridCell57.IsUpdCol = false;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellLen = 1;
            this.xEditGridCell58.CellName = "jusa_cr_yn";
            this.xEditGridCell58.Col = -1;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsUpdatable = false;
            this.xEditGridCell58.IsUpdCol = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellLen = 1;
            this.xEditGridCell59.CellName = "bogyong_code_cr_yn";
            this.xEditGridCell59.Col = -1;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsUpdCol = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellLen = 1;
            this.xEditGridCell60.CellName = "toiwon_drg_cr_yn";
            this.xEditGridCell60.Col = -1;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsUpdatable = false;
            this.xEditGridCell60.IsUpdCol = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellLen = 1;
            this.xEditGridCell61.CellName = "tpn_cr_yn";
            this.xEditGridCell61.Col = -1;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsUpdatable = false;
            this.xEditGridCell61.IsUpdCol = false;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellLen = 1;
            this.xEditGridCell62.CellName = "anti_cancer_cr_yn";
            this.xEditGridCell62.Col = -1;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsUpdCol = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellLen = 1;
            this.xEditGridCell63.CellName = "fluid_cr_yn";
            this.xEditGridCell63.Col = -1;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.IsUpdCol = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellLen = 1;
            this.xEditGridCell64.CellName = "portable_cr_yn";
            this.xEditGridCell64.Col = -1;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellLen = 1;
            this.xEditGridCell65.CellName = "doner_cr_yn";
            this.xEditGridCell65.Col = -1;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.IsUpdCol = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellLen = 1;
            this.xEditGridCell66.CellName = "amt_cr_yn";
            this.xEditGridCell66.Col = -1;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsUpdatable = false;
            this.xEditGridCell66.IsUpdCol = false;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "specimen_name";
            this.xEditGridCell99.Col = -1;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.IsUpdCol = false;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.CellName = "jusa_name";
            this.xEditGridCell100.Col = -1;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            this.xEditGridCell100.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "pay_name";
            this.xEditGridCell101.Col = -1;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsUpdatable = false;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.CellName = "bogyong_name";
            this.xEditGridCell102.CellWidth = 116;
            this.xEditGridCell102.Col = 11;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.IsUpdCol = false;
            this.xEditGridCell102.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "bun_code";
            this.xEditGridCell104.Col = -1;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsUpdatable = false;
            this.xEditGridCell104.IsUpdCol = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "limit_suryang";
            this.xEditGridCell108.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell108.Col = -1;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.IsUpdCol = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "limit_nalsu";
            this.xEditGridCell109.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell109.Col = -1;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.IsUpdCol = false;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bulyong_check";
            this.xEditGridCell2.Col = -1;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "input_tab";
            this.xEditGridCell3.Col = -1;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "dv_5";
            this.xEditGridCell4.Col = -1;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "dv_6";
            this.xEditGridCell5.Col = -1;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "dv_7";
            this.xEditGridCell6.Col = -1;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "dv_8";
            this.xEditGridCell7.Col = -1;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 1;
            this.xEditGridCell9.CellName = "general_disp_yn";
            this.xEditGridCell9.Col = -1;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellLen = 50;
            this.xEditGridCell68.CellName = "generic_name";
            this.xEditGridCell68.Col = -1;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "fkinp1001";
            this.xEditGridCell69.Col = -1;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsNotNull = true;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell70.CellName = "order_date";
            this.xEditGridCell70.Col = 2;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsNotNull = true;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellLen = 300;
            this.xEditGridCell71.CellName = "drg_comment";
            this.xEditGridCell71.CellWidth = 85;
            this.xEditGridCell71.Col = 14;
            this.xEditGridCell71.DisplayMemoText = true;
            this.xEditGridCell71.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "total_suryang";
            this.xEditGridCell73.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell73.CellWidth = 53;
            this.xEditGridCell73.Col = 12;
            this.xEditGridCell73.DecimalDigits = 1;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsNotNull = true;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "current_suryang";
            this.xEditGridCell75.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell75.CellWidth = 59;
            this.xEditGridCell75.Col = 13;
            this.xEditGridCell75.DecimalDigits = 1;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "usedup_yn";
            this.xEditGridCell74.Col = -1;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellLen = 50;
            this.xEditGridCell77.CellName = "input_user_id";
            this.xEditGridCell77.CellWidth = 100;
            this.xEditGridCell77.Col = 15;
            this.xEditGridCell77.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell77.UserSQL = resources.GetString("xEditGridCell77.UserSQL");
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.CellName = "select";
            this.xEditGridCell1.CellWidth = 33;
            this.xEditGridCell1.Col = 1;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellLen = 30;
            this.xEditGridCell76.CellName = "suname";
            this.xEditGridCell76.Col = -1;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "jusa_spd_gubun";
            this.xEditGridCell79.Col = -1;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 7;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 22;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 8;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 22;
            // 
            // lblSelectOrder
            // 
            this.lblSelectOrder.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblSelectOrder, "lblSelectOrder");
            this.lblSelectOrder.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectOrder.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectOrder.ImageList = this.ImageList;
            this.lblSelectOrder.Name = "lblSelectOrder";
            this.lblSelectOrder.Click += new System.EventHandler(this.lblSelectOrder_Click);
            // 
            // paBox
            // 
            this.paBox.BackgroundImage = global::IHIS.OCSI.Properties.Resources.TopBackground;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // dpkOrder_Date
            // 
            resources.ApplyResources(this.dpkOrder_Date, "dpkOrder_Date");
            this.dpkOrder_Date.Name = "dpkOrder_Date";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "muhyo";
            this.xEditGridCell72.Col = -1;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dwPrint
            // 
            this.dwPrint.DataWindowObject = "d_drg900";
            this.dwPrint.IsLandScape = false;
            this.dwPrint.IsPreviewStatusPopup = true;
            this.dwPrint.LibraryList = "..\\OCSI\\ocsi.ocs1024u00.pbd";
            this.dwPrint.PaperSize = IHIS.Framework.DataWindowPaperSize.A4;
            this.dwPrint.PrintStart += new System.ComponentModel.CancelEventHandler(this.dwPrint_PrintStart);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // cbxActor
            // 
            resources.ApplyResources(this.cbxActor, "cbxActor");
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxActor.UserSQL = resources.GetString("cbxActor.UserSQL");
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.IDEPixelArea = true;
            this.tabControl.IDEPixelBorder = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedTab = this.tabPage1;
            this.tabControl.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdOCS1024);
            this.tabPage1.Controls.Add(this.lblSelectOrder);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.ImageList = this.ImageList;
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdOCS1024Jusa);
            this.tabPage2.Controls.Add(this.lblSelectJusaOrder);
            this.tabPage2.ImageIndex = 3;
            this.tabPage2.ImageList = this.ImageList;
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            // 
            // grdOCS1024Jusa
            // 
            this.grdOCS1024Jusa.AddedHeaderLine = 1;
            this.grdOCS1024Jusa.ApplyPaintEventToAllColumn = true;
            this.grdOCS1024Jusa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell115,
            this.xEditGridCell117,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell123,
            this.xEditGridCell124,
            this.xEditGridCell125,
            this.xEditGridCell126,
            this.xEditGridCell127,
            this.xEditGridCell128,
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
            this.xEditGridCell196,
            this.xEditGridCell197,
            this.xEditGridCell198,
            this.xEditGridCell199,
            this.xEditGridCell200,
            this.xEditGridCell201,
            this.xEditGridCell202,
            this.xEditGridCell203,
            this.xEditGridCell204,
            this.xEditGridCell205,
            this.xEditGridCell206,
            this.xEditGridCell207,
            this.xEditGridCell208,
            this.xEditGridCell78});
            this.grdOCS1024Jusa.ColPerLine = 15;
            this.grdOCS1024Jusa.Cols = 16;
            this.grdOCS1024Jusa.ControlBinding = true;
            resources.ApplyResources(this.grdOCS1024Jusa, "grdOCS1024Jusa");
            this.grdOCS1024Jusa.EnableMultiSelection = true;
            this.grdOCS1024Jusa.FixedCols = 1;
            this.grdOCS1024Jusa.FixedRows = 2;
            this.grdOCS1024Jusa.FocusColumnName = "hangmog_code";
            this.grdOCS1024Jusa.HeaderHeights.Add(34);
            this.grdOCS1024Jusa.HeaderHeights.Add(0);
            this.grdOCS1024Jusa.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader4});
            this.grdOCS1024Jusa.Name = "grdOCS1024Jusa";
            this.grdOCS1024Jusa.QuerySQL = resources.GetString("grdOCS1024Jusa.QuerySQL");
            this.grdOCS1024Jusa.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS1024Jusa.RowHeaderVisible = true;
            this.grdOCS1024Jusa.Rows = 3;
            this.grdOCS1024Jusa.RowStateCheckOnPaint = false;
            this.grdOCS1024Jusa.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1024Jusa.SelectionModeChangeable = true;
            this.grdOCS1024Jusa.TabStop = false;
            this.grdOCS1024Jusa.TogglingRowSelection = true;
            this.grdOCS1024Jusa.ToolTipActive = true;
            this.grdOCS1024Jusa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1024Jusa_MouseDown);
            this.grdOCS1024Jusa.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1024Jusa_QueryEnd);
            this.grdOCS1024Jusa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1024Jusa_QueryStarting);
            this.grdOCS1024Jusa.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS1024Jusa_GridColumnProtectModify);
            this.grdOCS1024Jusa.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS1024_GridColumnChanged);
            this.grdOCS1024Jusa.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1024_GridCellPainting);
            this.grdOCS1024Jusa.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS1024Jusa_GridFindClick);
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "bunho";
            this.xEditGridCell115.Col = -1;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsNotNull = true;
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "gwa";
            this.xEditGridCell117.Col = -1;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsNotNull = true;
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "pkocs1024";
            this.xEditGridCell120.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell120.Col = -1;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell121.CellLen = 2;
            this.xEditGridCell121.CellName = "group_ser";
            this.xEditGridCell121.CellWidth = 22;
            this.xEditGridCell121.Col = -1;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            this.xEditGridCell121.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "seq";
            this.xEditGridCell122.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell122.Col = -1;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.IsVisible = false;
            this.xEditGridCell122.Row = -1;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell123.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell123.AutoTabDataSelected = true;
            this.xEditGridCell123.CellLen = 20;
            this.xEditGridCell123.CellName = "hangmog_code";
            this.xEditGridCell123.CellWidth = 77;
            this.xEditGridCell123.Col = 3;
            this.xEditGridCell123.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell123.IsNotNull = true;
            this.xEditGridCell123.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell123.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell124.CellLen = 80;
            this.xEditGridCell124.CellName = "hangmog_name";
            this.xEditGridCell124.CellWidth = 214;
            this.xEditGridCell124.Col = 4;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsReadOnly = true;
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell124.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell125.CellLen = 3;
            this.xEditGridCell125.CellName = "specimen_code";
            this.xEditGridCell125.CellWidth = 45;
            this.xEditGridCell125.Col = -1;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.InitValue = "*";
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            this.xEditGridCell125.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell126.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xEditGridCell126.CellName = "suryang";
            this.xEditGridCell126.CellWidth = 36;
            this.xEditGridCell126.Col = 5;
            this.xEditGridCell126.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell126.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.InitValue = "1";
            this.xEditGridCell126.IsNotNull = true;
            this.xEditGridCell126.MaxDropDownItems = 10;
            this.xEditGridCell126.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell126.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellLen = 6;
            this.xEditGridCell127.CellName = "ord_danui";
            this.xEditGridCell127.Col = -1;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsNotNull = true;
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell128.CellLen = 100;
            this.xEditGridCell128.CellName = "ord_danui_name";
            this.xEditGridCell128.CellWidth = 43;
            this.xEditGridCell128.Col = 6;
            this.xEditGridCell128.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell128.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell129.CellLen = 1;
            this.xEditGridCell129.CellName = "dv_time";
            this.xEditGridCell129.CellWidth = 22;
            this.xEditGridCell129.Col = 7;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.InitValue = "*";
            this.xEditGridCell129.IsNotNull = true;
            this.xEditGridCell129.Row = 1;
            this.xEditGridCell129.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell129.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell129.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell130.CellName = "dv";
            this.xEditGridCell130.CellWidth = 36;
            this.xEditGridCell130.Col = 8;
            this.xEditGridCell130.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell130.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.InitValue = "1";
            this.xEditGridCell130.IsNotNull = true;
            this.xEditGridCell130.Row = 1;
            this.xEditGridCell130.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell130.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell130.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "dv_1";
            this.xEditGridCell131.Col = -1;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "dv_2";
            this.xEditGridCell132.Col = -1;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "dv_3";
            this.xEditGridCell133.Col = -1;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "dv_4";
            this.xEditGridCell134.Col = -1;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell135.CellName = "nalsu";
            this.xEditGridCell135.CellWidth = 34;
            this.xEditGridCell135.Col = 9;
            this.xEditGridCell135.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell135.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            this.xEditGridCell135.InitValue = "1";
            this.xEditGridCell135.IsNotNull = true;
            this.xEditGridCell135.IsReadOnly = true;
            this.xEditGridCell135.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell135.RowSpan = 2;
            this.xEditGridCell135.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell136.CellName = "jusa";
            this.xEditGridCell136.CellWidth = 46;
            this.xEditGridCell136.Col = 10;
            this.xEditGridCell136.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsNotNull = true;
            this.xEditGridCell136.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell136.RowSpan = 2;
            this.xEditGridCell136.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell137.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell137.CellName = "bogyong_code";
            this.xEditGridCell137.CellWidth = 34;
            this.xEditGridCell137.Col = -1;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            this.xEditGridCell137.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell137.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell138.CellLen = 1;
            this.xEditGridCell138.CellName = "emergency";
            this.xEditGridCell138.CellWidth = 27;
            this.xEditGridCell138.Col = -1;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsVisible = false;
            this.xEditGridCell138.Row = -1;
            this.xEditGridCell138.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.CellLen = 1;
            this.xEditGridCell139.CellName = "pay";
            this.xEditGridCell139.CellWidth = 36;
            this.xEditGridCell139.Col = -1;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.InitValue = "0";
            this.xEditGridCell139.IsVisible = false;
            this.xEditGridCell139.Row = -1;
            this.xEditGridCell139.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell140.CellLen = 1;
            this.xEditGridCell140.CellName = "fluid_yn";
            this.xEditGridCell140.CellWidth = 43;
            this.xEditGridCell140.Col = -1;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsVisible = false;
            this.xEditGridCell140.Row = -1;
            this.xEditGridCell140.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell140.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell140.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell141.CellLen = 1;
            this.xEditGridCell141.CellName = "tpn_yn";
            this.xEditGridCell141.CellWidth = 38;
            this.xEditGridCell141.Col = -1;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsVisible = false;
            this.xEditGridCell141.Row = -1;
            this.xEditGridCell141.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell141.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell141.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell142.CellLen = 1;
            this.xEditGridCell142.CellName = "anti_cancer_yn";
            this.xEditGridCell142.CellWidth = 52;
            this.xEditGridCell142.Col = -1;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsVisible = false;
            this.xEditGridCell142.Row = -1;
            this.xEditGridCell142.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell142.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell142.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell143.CellLen = 1;
            this.xEditGridCell143.CellName = "portable_yn";
            this.xEditGridCell143.CellWidth = 34;
            this.xEditGridCell143.Col = -1;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            this.xEditGridCell143.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell144.CellLen = 1;
            this.xEditGridCell144.CellName = "powder_yn";
            this.xEditGridCell144.CellWidth = 26;
            this.xEditGridCell144.Col = -1;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsVisible = false;
            this.xEditGridCell144.Row = -1;
            this.xEditGridCell144.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell145.CellLen = 1;
            this.xEditGridCell145.CellName = "special_yn";
            this.xEditGridCell145.CellWidth = 47;
            this.xEditGridCell145.Col = -1;
            this.xEditGridCell145.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsVisible = false;
            this.xEditGridCell145.Row = -1;
            this.xEditGridCell145.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell145.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell145.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell146.CellLen = 5;
            this.xEditGridCell146.CellName = "act_doctor";
            this.xEditGridCell146.Col = -1;
            this.xEditGridCell146.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsVisible = false;
            this.xEditGridCell146.Row = -1;
            this.xEditGridCell146.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell146.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell146.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell147.CellLen = 1;
            this.xEditGridCell147.CellName = "muhyo";
            this.xEditGridCell147.CellWidth = 21;
            this.xEditGridCell147.Col = -1;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsVisible = false;
            this.xEditGridCell147.Row = -1;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellLen = 1;
            this.xEditGridCell148.CellName = "symya";
            this.xEditGridCell148.Col = -1;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsUpdatable = false;
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "special_rate";
            this.xEditGridCell149.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell149.Col = -1;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.InitValue = "0";
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell150.CellLen = 30;
            this.xEditGridCell150.CellName = "act_doctor_name";
            this.xEditGridCell150.CellWidth = 90;
            this.xEditGridCell150.Col = -1;
            this.xEditGridCell150.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell150, "xEditGridCell150");
            this.xEditGridCell150.IsReadOnly = true;
            this.xEditGridCell150.IsUpdatable = false;
            this.xEditGridCell150.IsVisible = false;
            this.xEditGridCell150.Row = -1;
            this.xEditGridCell150.RowGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell150.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell150.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellLen = 1;
            this.xEditGridCell151.CellName = "prn_yn";
            this.xEditGridCell151.Col = -1;
            resources.ApplyResources(this.xEditGridCell151, "xEditGridCell151");
            this.xEditGridCell151.IsUpdatable = false;
            this.xEditGridCell151.IsVisible = false;
            this.xEditGridCell151.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellLen = 1;
            this.xEditGridCell152.CellName = "prepare_yn";
            this.xEditGridCell152.Col = -1;
            resources.ApplyResources(this.xEditGridCell152, "xEditGridCell152");
            this.xEditGridCell152.IsUpdatable = false;
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "order_gubun";
            this.xEditGridCell153.Col = -1;
            resources.ApplyResources(this.xEditGridCell153, "xEditGridCell153");
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellLen = 2;
            this.xEditGridCell154.CellName = "order_gubun_bas";
            this.xEditGridCell154.Col = -1;
            resources.ApplyResources(this.xEditGridCell154, "xEditGridCell154");
            this.xEditGridCell154.IsUpdatable = false;
            this.xEditGridCell154.IsVisible = false;
            this.xEditGridCell154.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell155.CellName = "order_gubun_bas_name";
            this.xEditGridCell155.CellWidth = 76;
            this.xEditGridCell155.Col = -1;
            resources.ApplyResources(this.xEditGridCell155, "xEditGridCell155");
            this.xEditGridCell155.IsReadOnly = true;
            this.xEditGridCell155.IsUpdatable = false;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            this.xEditGridCell155.SuppressRepeating = true;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell156.CellLen = 2000;
            this.xEditGridCell156.CellName = "order_remark";
            this.xEditGridCell156.Col = -1;
            resources.ApplyResources(this.xEditGridCell156, "xEditGridCell156");
            this.xEditGridCell156.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell157.CellLen = 2000;
            this.xEditGridCell157.CellName = "nurse_remark";
            this.xEditGridCell157.CellWidth = 89;
            this.xEditGridCell157.Col = -1;
            resources.ApplyResources(this.xEditGridCell157, "xEditGridCell157");
            this.xEditGridCell157.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell158.CellLen = 2;
            this.xEditGridCell158.CellName = "mix_group";
            this.xEditGridCell158.CellWidth = 24;
            this.xEditGridCell158.Col = -1;
            resources.ApplyResources(this.xEditGridCell158, "xEditGridCell158");
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell159.CellLen = 1;
            this.xEditGridCell159.CellName = "wonyoi_order_yn";
            this.xEditGridCell159.CellWidth = 21;
            this.xEditGridCell159.Col = -1;
            resources.ApplyResources(this.xEditGridCell159, "xEditGridCell159");
            this.xEditGridCell159.IsVisible = false;
            this.xEditGridCell159.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "wonnae_sayu_code";
            this.xEditGridCell160.Col = -1;
            resources.ApplyResources(this.xEditGridCell160, "xEditGridCell160");
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellLen = 1;
            this.xEditGridCell161.CellName = "input_control";
            this.xEditGridCell161.Col = -1;
            resources.ApplyResources(this.xEditGridCell161, "xEditGridCell161");
            this.xEditGridCell161.IsUpdatable = false;
            this.xEditGridCell161.IsVisible = false;
            this.xEditGridCell161.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellLen = 1;
            this.xEditGridCell162.CellName = "suga_yn";
            this.xEditGridCell162.Col = -1;
            resources.ApplyResources(this.xEditGridCell162, "xEditGridCell162");
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsUpdCol = false;
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellLen = 1;
            this.xEditGridCell163.CellName = "jaeryo_yn";
            this.xEditGridCell163.Col = -1;
            resources.ApplyResources(this.xEditGridCell163, "xEditGridCell163");
            this.xEditGridCell163.IsUpdatable = false;
            this.xEditGridCell163.IsUpdCol = false;
            this.xEditGridCell163.IsVisible = false;
            this.xEditGridCell163.Row = -1;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellLen = 1;
            this.xEditGridCell164.CellName = "special_check";
            this.xEditGridCell164.Col = -1;
            resources.ApplyResources(this.xEditGridCell164, "xEditGridCell164");
            this.xEditGridCell164.IsUpdatable = false;
            this.xEditGridCell164.IsUpdCol = false;
            this.xEditGridCell164.IsVisible = false;
            this.xEditGridCell164.Row = -1;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.CellLen = 80;
            this.xEditGridCell165.CellName = "pris_name";
            this.xEditGridCell165.Col = -1;
            resources.ApplyResources(this.xEditGridCell165, "xEditGridCell165");
            this.xEditGridCell165.IsUpdatable = false;
            this.xEditGridCell165.IsUpdCol = false;
            this.xEditGridCell165.IsVisible = false;
            this.xEditGridCell165.Row = -1;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellLen = 4;
            this.xEditGridCell166.CellName = "slip_code";
            this.xEditGridCell166.Col = -1;
            resources.ApplyResources(this.xEditGridCell166, "xEditGridCell166");
            this.xEditGridCell166.IsUpdatable = false;
            this.xEditGridCell166.IsUpdCol = false;
            this.xEditGridCell166.IsVisible = false;
            this.xEditGridCell166.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellLen = 1;
            this.xEditGridCell167.CellName = "emergency_check";
            this.xEditGridCell167.Col = -1;
            resources.ApplyResources(this.xEditGridCell167, "xEditGridCell167");
            this.xEditGridCell167.IsUpdatable = false;
            this.xEditGridCell167.IsUpdCol = false;
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellLen = 1;
            this.xEditGridCell168.CellName = "specimen_yn";
            this.xEditGridCell168.Col = -1;
            resources.ApplyResources(this.xEditGridCell168, "xEditGridCell168");
            this.xEditGridCell168.IsUpdatable = false;
            this.xEditGridCell168.IsUpdCol = false;
            this.xEditGridCell168.IsVisible = false;
            this.xEditGridCell168.Row = -1;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellLen = 1;
            this.xEditGridCell169.CellName = "multi_gumsa_yn";
            this.xEditGridCell169.Col = -1;
            resources.ApplyResources(this.xEditGridCell169, "xEditGridCell169");
            this.xEditGridCell169.IsUpdatable = false;
            this.xEditGridCell169.IsUpdCol = false;
            this.xEditGridCell169.IsVisible = false;
            this.xEditGridCell169.Row = -1;
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellLen = 1;
            this.xEditGridCell170.CellName = "specimen_cr_yn";
            this.xEditGridCell170.Col = -1;
            resources.ApplyResources(this.xEditGridCell170, "xEditGridCell170");
            this.xEditGridCell170.IsUpdatable = false;
            this.xEditGridCell170.IsUpdCol = false;
            this.xEditGridCell170.IsVisible = false;
            this.xEditGridCell170.Row = -1;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellLen = 1;
            this.xEditGridCell171.CellName = "suryang_cr_yn";
            this.xEditGridCell171.Col = -1;
            resources.ApplyResources(this.xEditGridCell171, "xEditGridCell171");
            this.xEditGridCell171.IsUpdatable = false;
            this.xEditGridCell171.IsUpdCol = false;
            this.xEditGridCell171.IsVisible = false;
            this.xEditGridCell171.Row = -1;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellLen = 1;
            this.xEditGridCell172.CellName = "ord_danui_cr_yn";
            this.xEditGridCell172.Col = -1;
            resources.ApplyResources(this.xEditGridCell172, "xEditGridCell172");
            this.xEditGridCell172.IsUpdatable = false;
            this.xEditGridCell172.IsUpdCol = false;
            this.xEditGridCell172.IsVisible = false;
            this.xEditGridCell172.Row = -1;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.CellLen = 1;
            this.xEditGridCell173.CellName = "dv_time_cr_yn";
            this.xEditGridCell173.Col = -1;
            resources.ApplyResources(this.xEditGridCell173, "xEditGridCell173");
            this.xEditGridCell173.IsUpdatable = false;
            this.xEditGridCell173.IsUpdCol = false;
            this.xEditGridCell173.IsVisible = false;
            this.xEditGridCell173.Row = -1;
            // 
            // xEditGridCell174
            // 
            this.xEditGridCell174.CellLen = 1;
            this.xEditGridCell174.CellName = "dv_cr_yn";
            this.xEditGridCell174.Col = -1;
            resources.ApplyResources(this.xEditGridCell174, "xEditGridCell174");
            this.xEditGridCell174.IsUpdatable = false;
            this.xEditGridCell174.IsUpdCol = false;
            this.xEditGridCell174.IsVisible = false;
            this.xEditGridCell174.Row = -1;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellLen = 1;
            this.xEditGridCell175.CellName = "nalsu_cr_yn";
            this.xEditGridCell175.Col = -1;
            resources.ApplyResources(this.xEditGridCell175, "xEditGridCell175");
            this.xEditGridCell175.IsUpdatable = false;
            this.xEditGridCell175.IsUpdCol = false;
            this.xEditGridCell175.IsVisible = false;
            this.xEditGridCell175.Row = -1;
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.CellLen = 1;
            this.xEditGridCell176.CellName = "jusa_cr_yn";
            this.xEditGridCell176.Col = -1;
            resources.ApplyResources(this.xEditGridCell176, "xEditGridCell176");
            this.xEditGridCell176.IsUpdatable = false;
            this.xEditGridCell176.IsUpdCol = false;
            this.xEditGridCell176.IsVisible = false;
            this.xEditGridCell176.Row = -1;
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellLen = 1;
            this.xEditGridCell177.CellName = "bogyong_code_cr_yn";
            this.xEditGridCell177.Col = -1;
            resources.ApplyResources(this.xEditGridCell177, "xEditGridCell177");
            this.xEditGridCell177.IsUpdatable = false;
            this.xEditGridCell177.IsUpdCol = false;
            this.xEditGridCell177.IsVisible = false;
            this.xEditGridCell177.Row = -1;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellLen = 1;
            this.xEditGridCell178.CellName = "toiwon_drg_cr_yn";
            this.xEditGridCell178.Col = -1;
            resources.ApplyResources(this.xEditGridCell178, "xEditGridCell178");
            this.xEditGridCell178.IsUpdatable = false;
            this.xEditGridCell178.IsUpdCol = false;
            this.xEditGridCell178.IsVisible = false;
            this.xEditGridCell178.Row = -1;
            // 
            // xEditGridCell179
            // 
            this.xEditGridCell179.CellLen = 1;
            this.xEditGridCell179.CellName = "tpn_cr_yn";
            this.xEditGridCell179.Col = -1;
            resources.ApplyResources(this.xEditGridCell179, "xEditGridCell179");
            this.xEditGridCell179.IsUpdatable = false;
            this.xEditGridCell179.IsUpdCol = false;
            this.xEditGridCell179.IsVisible = false;
            this.xEditGridCell179.Row = -1;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellLen = 1;
            this.xEditGridCell180.CellName = "anti_cancer_cr_yn";
            this.xEditGridCell180.Col = -1;
            resources.ApplyResources(this.xEditGridCell180, "xEditGridCell180");
            this.xEditGridCell180.IsUpdatable = false;
            this.xEditGridCell180.IsUpdCol = false;
            this.xEditGridCell180.IsVisible = false;
            this.xEditGridCell180.Row = -1;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.CellLen = 1;
            this.xEditGridCell181.CellName = "fluid_cr_yn";
            this.xEditGridCell181.Col = -1;
            resources.ApplyResources(this.xEditGridCell181, "xEditGridCell181");
            this.xEditGridCell181.IsUpdatable = false;
            this.xEditGridCell181.IsUpdCol = false;
            this.xEditGridCell181.IsVisible = false;
            this.xEditGridCell181.Row = -1;
            // 
            // xEditGridCell182
            // 
            this.xEditGridCell182.CellLen = 1;
            this.xEditGridCell182.CellName = "portable_cr_yn";
            this.xEditGridCell182.Col = -1;
            resources.ApplyResources(this.xEditGridCell182, "xEditGridCell182");
            this.xEditGridCell182.IsUpdatable = false;
            this.xEditGridCell182.IsUpdCol = false;
            this.xEditGridCell182.IsVisible = false;
            this.xEditGridCell182.Row = -1;
            // 
            // xEditGridCell183
            // 
            this.xEditGridCell183.CellLen = 1;
            this.xEditGridCell183.CellName = "doner_cr_yn";
            this.xEditGridCell183.Col = -1;
            resources.ApplyResources(this.xEditGridCell183, "xEditGridCell183");
            this.xEditGridCell183.IsUpdatable = false;
            this.xEditGridCell183.IsUpdCol = false;
            this.xEditGridCell183.IsVisible = false;
            this.xEditGridCell183.Row = -1;
            // 
            // xEditGridCell184
            // 
            this.xEditGridCell184.CellLen = 1;
            this.xEditGridCell184.CellName = "amt_cr_yn";
            this.xEditGridCell184.Col = -1;
            resources.ApplyResources(this.xEditGridCell184, "xEditGridCell184");
            this.xEditGridCell184.IsUpdatable = false;
            this.xEditGridCell184.IsUpdCol = false;
            this.xEditGridCell184.IsVisible = false;
            this.xEditGridCell184.Row = -1;
            // 
            // xEditGridCell185
            // 
            this.xEditGridCell185.CellName = "specimen_name";
            this.xEditGridCell185.Col = -1;
            resources.ApplyResources(this.xEditGridCell185, "xEditGridCell185");
            this.xEditGridCell185.IsUpdatable = false;
            this.xEditGridCell185.IsUpdCol = false;
            this.xEditGridCell185.IsVisible = false;
            this.xEditGridCell185.Row = -1;
            // 
            // xEditGridCell186
            // 
            this.xEditGridCell186.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell186.CellName = "jusa_name";
            this.xEditGridCell186.CellWidth = 135;
            this.xEditGridCell186.Col = 11;
            resources.ApplyResources(this.xEditGridCell186, "xEditGridCell186");
            this.xEditGridCell186.IsReadOnly = true;
            this.xEditGridCell186.IsUpdatable = false;
            this.xEditGridCell186.IsUpdCol = false;
            this.xEditGridCell186.RowSpan = 2;
            this.xEditGridCell186.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell186.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell187
            // 
            this.xEditGridCell187.CellName = "pay_name";
            this.xEditGridCell187.Col = -1;
            resources.ApplyResources(this.xEditGridCell187, "xEditGridCell187");
            this.xEditGridCell187.IsUpdatable = false;
            this.xEditGridCell187.IsUpdCol = false;
            this.xEditGridCell187.IsVisible = false;
            this.xEditGridCell187.Row = -1;
            // 
            // xEditGridCell188
            // 
            this.xEditGridCell188.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell188.CellName = "bogyong_name";
            this.xEditGridCell188.CellWidth = 116;
            this.xEditGridCell188.Col = -1;
            resources.ApplyResources(this.xEditGridCell188, "xEditGridCell188");
            this.xEditGridCell188.IsReadOnly = true;
            this.xEditGridCell188.IsUpdatable = false;
            this.xEditGridCell188.IsUpdCol = false;
            this.xEditGridCell188.IsVisible = false;
            this.xEditGridCell188.Row = -1;
            this.xEditGridCell188.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell188.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell189
            // 
            this.xEditGridCell189.CellName = "bun_code";
            this.xEditGridCell189.Col = -1;
            resources.ApplyResources(this.xEditGridCell189, "xEditGridCell189");
            this.xEditGridCell189.IsUpdatable = false;
            this.xEditGridCell189.IsUpdCol = false;
            this.xEditGridCell189.IsVisible = false;
            this.xEditGridCell189.Row = -1;
            // 
            // xEditGridCell190
            // 
            this.xEditGridCell190.CellName = "limit_suryang";
            this.xEditGridCell190.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell190.Col = -1;
            resources.ApplyResources(this.xEditGridCell190, "xEditGridCell190");
            this.xEditGridCell190.IsUpdatable = false;
            this.xEditGridCell190.IsUpdCol = false;
            this.xEditGridCell190.IsVisible = false;
            this.xEditGridCell190.Row = -1;
            // 
            // xEditGridCell191
            // 
            this.xEditGridCell191.CellName = "limit_nalsu";
            this.xEditGridCell191.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell191.Col = -1;
            resources.ApplyResources(this.xEditGridCell191, "xEditGridCell191");
            this.xEditGridCell191.IsUpdatable = false;
            this.xEditGridCell191.IsUpdCol = false;
            this.xEditGridCell191.IsVisible = false;
            this.xEditGridCell191.Row = -1;
            // 
            // xEditGridCell192
            // 
            this.xEditGridCell192.CellName = "bulyong_check";
            this.xEditGridCell192.Col = -1;
            resources.ApplyResources(this.xEditGridCell192, "xEditGridCell192");
            this.xEditGridCell192.IsUpdatable = false;
            this.xEditGridCell192.IsUpdCol = false;
            this.xEditGridCell192.IsVisible = false;
            this.xEditGridCell192.Row = -1;
            // 
            // xEditGridCell193
            // 
            this.xEditGridCell193.CellName = "input_tab";
            this.xEditGridCell193.Col = -1;
            resources.ApplyResources(this.xEditGridCell193, "xEditGridCell193");
            this.xEditGridCell193.IsVisible = false;
            this.xEditGridCell193.Row = -1;
            // 
            // xEditGridCell194
            // 
            this.xEditGridCell194.CellName = "dv_5";
            this.xEditGridCell194.Col = -1;
            resources.ApplyResources(this.xEditGridCell194, "xEditGridCell194");
            this.xEditGridCell194.IsVisible = false;
            this.xEditGridCell194.Row = -1;
            // 
            // xEditGridCell195
            // 
            this.xEditGridCell195.CellName = "dv_6";
            this.xEditGridCell195.Col = -1;
            resources.ApplyResources(this.xEditGridCell195, "xEditGridCell195");
            this.xEditGridCell195.IsVisible = false;
            this.xEditGridCell195.Row = -1;
            // 
            // xEditGridCell196
            // 
            this.xEditGridCell196.CellName = "dv_7";
            this.xEditGridCell196.Col = -1;
            resources.ApplyResources(this.xEditGridCell196, "xEditGridCell196");
            this.xEditGridCell196.IsVisible = false;
            this.xEditGridCell196.Row = -1;
            // 
            // xEditGridCell197
            // 
            this.xEditGridCell197.CellName = "dv_8";
            this.xEditGridCell197.Col = -1;
            resources.ApplyResources(this.xEditGridCell197, "xEditGridCell197");
            this.xEditGridCell197.IsVisible = false;
            this.xEditGridCell197.Row = -1;
            // 
            // xEditGridCell198
            // 
            this.xEditGridCell198.CellLen = 1;
            this.xEditGridCell198.CellName = "general_disp_yn";
            this.xEditGridCell198.Col = -1;
            resources.ApplyResources(this.xEditGridCell198, "xEditGridCell198");
            this.xEditGridCell198.IsVisible = false;
            this.xEditGridCell198.Row = -1;
            // 
            // xEditGridCell199
            // 
            this.xEditGridCell199.CellLen = 50;
            this.xEditGridCell199.CellName = "generic_name";
            this.xEditGridCell199.Col = -1;
            resources.ApplyResources(this.xEditGridCell199, "xEditGridCell199");
            this.xEditGridCell199.IsVisible = false;
            this.xEditGridCell199.Row = -1;
            // 
            // xEditGridCell200
            // 
            this.xEditGridCell200.CellName = "fkinp1001";
            this.xEditGridCell200.Col = -1;
            resources.ApplyResources(this.xEditGridCell200, "xEditGridCell200");
            this.xEditGridCell200.IsNotNull = true;
            this.xEditGridCell200.IsVisible = false;
            this.xEditGridCell200.Row = -1;
            // 
            // xEditGridCell201
            // 
            this.xEditGridCell201.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell201.CellName = "order_date";
            this.xEditGridCell201.Col = 2;
            resources.ApplyResources(this.xEditGridCell201, "xEditGridCell201");
            this.xEditGridCell201.IsNotNull = true;
            // 
            // xEditGridCell202
            // 
            this.xEditGridCell202.CellLen = 300;
            this.xEditGridCell202.CellName = "drg_comment";
            this.xEditGridCell202.CellWidth = 85;
            this.xEditGridCell202.Col = 14;
            this.xEditGridCell202.DisplayMemoText = true;
            this.xEditGridCell202.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            resources.ApplyResources(this.xEditGridCell202, "xEditGridCell202");
            // 
            // xEditGridCell203
            // 
            this.xEditGridCell203.CellName = "total_suryang";
            this.xEditGridCell203.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell203.CellWidth = 37;
            this.xEditGridCell203.Col = 12;
            this.xEditGridCell203.DecimalDigits = 1;
            resources.ApplyResources(this.xEditGridCell203, "xEditGridCell203");
            this.xEditGridCell203.IsNotNull = true;
            // 
            // xEditGridCell204
            // 
            this.xEditGridCell204.CellName = "current_suryang";
            this.xEditGridCell204.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell204.CellWidth = 39;
            this.xEditGridCell204.Col = 13;
            this.xEditGridCell204.DecimalDigits = 1;
            resources.ApplyResources(this.xEditGridCell204, "xEditGridCell204");
            // 
            // xEditGridCell205
            // 
            this.xEditGridCell205.CellName = "usedup_yn";
            this.xEditGridCell205.Col = -1;
            resources.ApplyResources(this.xEditGridCell205, "xEditGridCell205");
            this.xEditGridCell205.IsVisible = false;
            this.xEditGridCell205.Row = -1;
            // 
            // xEditGridCell206
            // 
            this.xEditGridCell206.CellLen = 50;
            this.xEditGridCell206.CellName = "input_user_id";
            this.xEditGridCell206.CellWidth = 100;
            this.xEditGridCell206.Col = 15;
            this.xEditGridCell206.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell206, "xEditGridCell206");
            this.xEditGridCell206.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell206.UserSQL = resources.GetString("xEditGridCell206.UserSQL");
            // 
            // xEditGridCell207
            // 
            this.xEditGridCell207.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell207.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell207.CellName = "select";
            this.xEditGridCell207.CellWidth = 33;
            this.xEditGridCell207.Col = 1;
            resources.ApplyResources(this.xEditGridCell207, "xEditGridCell207");
            this.xEditGridCell207.IsUpdatable = false;
            this.xEditGridCell207.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell207.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell208
            // 
            this.xEditGridCell208.CellLen = 30;
            this.xEditGridCell208.CellName = "suname";
            this.xEditGridCell208.Col = -1;
            resources.ApplyResources(this.xEditGridCell208, "xEditGridCell208");
            this.xEditGridCell208.IsVisible = false;
            this.xEditGridCell208.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "jusa_spd_gubun";
            this.xEditGridCell78.Col = -1;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xGridHeader4
            // 
            this.xGridHeader4.Col = 7;
            this.xGridHeader4.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader4, "xGridHeader4");
            this.xGridHeader4.HeaderWidth = 22;
            // 
            // lblSelectJusaOrder
            // 
            this.lblSelectJusaOrder.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectJusaOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblSelectJusaOrder, "lblSelectJusaOrder");
            this.lblSelectJusaOrder.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectJusaOrder.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectJusaOrder.ImageList = this.ImageList;
            this.lblSelectJusaOrder.Name = "lblSelectJusaOrder";
            this.lblSelectJusaOrder.Click += new System.EventHandler(this.lblSelectJusaOrder_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.tabControl);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel3
            // 
            this.xPanel3.BackgroundImage = global::IHIS.OCSI.Properties.Resources.TopBackground;
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Controls.Add(this.paBox);
            this.xPanel3.Controls.Add(this.dpkOrder_Date);
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Controls.Add(this.xLabel4);
            this.xPanel3.Controls.Add(this.cbxActor);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xPanel2);
            this.xPanel4.Controls.Add(this.xPanel3);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // OCS1024U00
            // 
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel1);
            resources.ApplyResources(this, "$this");
            this.Name = "OCS1024U00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS1024U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1024)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1024)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1024Jusa)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1024Jusa)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region [Screen Event]

        private void OCS1024U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{

            this.mOrderBiz = new IHIS.OCS.OrderBiz(this.Name);             // OCS 그룹 Business 라이브러리
            this.mOrderFunc = new IHIS.OCS.OrderFunc(this.Name);            // OCS 그룹 Function 라이브러리
            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.Name);        // OCS 항목정보 그룹 라이브러리
            //this.mPatientInfo = new IHIS.OCS.PatientInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 환자정보 그룹 라이브러리 
            //this.mInputControl = new IHIS.OCS.InputControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // 입력제어 그룹 라이브러리 
            //this.mCommonForms = new IHIS.OCS.CommonForms();                 // OCS 공통Form's 그룹 라이브러리 
            //this.mColumnControl = new ColumnControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // OCS 컬럼 컨트롤 그룹 라이브러리 
            //this.mInterface = new IHIS.OCS.OrderInterface();

			// Call된 경우
			if ( e.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
						this.paBox.SetPatientID(OpenParam["bunho"].ToString().Trim());
					else
						return;

					if(OpenParam.Contains("gwa"))
						mGwa = OpenParam["gwa"].ToString().Trim();

                    if (OpenParam.Contains("mode"))
                        mMode = OpenParam["mode"].ToString().Trim();
                    else
                        mMode = "update";

                    //Prameter  추가
                    if (OpenParam.Contains("auto_close_yn"))
                        mAutoClose = OpenParam["auto_close_yn"].ToString().Trim();

                    //Parameter 추가
                    if (OpenParam.Contains("input_tab"))
                        mInputTab = OpenParam["input_tab"].ToString().Trim();
                        
               
                    //if ( this.mAutoClose == "Y")
                    //    this.ParentForm.WindowState = FormWindowState.Minimized;

                }
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");	
					this.Close();
				}
				
			}

            //if (this.mMode == "select")
            //    this.grdOCS1024.Enabled = false;
            //else if (this.mMode == "update")
            //    this.grdOCS1024.Enabled = true;

            this.dpkOrder_Date.SetDataValue(EnvironInfo.GetSysDate());
            this.SetLayout(mLayOutputHangmogInfo);
            this.mOrderBiz.SetNumCombo(this.grdOCS1024, "suryang", true);
            this.mOrderBiz.SetNumCombo(this.grdOCS1024, "dv", false);
            this.mOrderBiz.SetNumCombo(this.grdOCS1024, "nalsu", false);


            this.mOrderBiz.SetNumCombo(this.grdOCS1024Jusa, "suryang", true);
            this.mOrderBiz.SetNumCombo(this.grdOCS1024Jusa, "dv", false);
            this.mOrderBiz.SetNumCombo(this.grdOCS1024Jusa, "nalsu", false);

            this.initScreen();
		}
		
        private void initScreen()
        {
            if (EnvironInfo.CurrSystemID == "DRGS")
            {
                this.CurrMQLayout = this.grdOCS1024;

                this.btnProcess.Visible = false;

                // 薬「選択」Column
                this.grdOCS1024.AutoSizeColumn(1, 0);
                this.grdOCS1024.AutoSizeColumn(4, 247);

                // 注射「選択」Column
                this.grdOCS1024Jusa.AutoSizeColumn(1, 0);
                this.grdOCS1024Jusa.AutoSizeColumn(4, 247);

                this.cbxActor.SetDataValue(UserInfo.UserID);
                this.cbxActor.Enabled = true;

                this.paBox.Focus();
            }
            else if (EnvironInfo.CurrSystemID == "OCSI" || EnvironInfo.CurrSystemID == "INSI")
            {
                this.btnProcess.Visible = true;

                this.btnList.FunctionItems.Clear();
                this.btnList.Name = "btnList";
                this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
                this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                //this.btnList.Location = new System.Drawing.Point(558, 2);
                this.btnList.Location = new System.Drawing.Point(890, 2);
                this.btnList.Size = new System.Drawing.Size(406, 34);
                this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
                this.btnList.InitializeButtons();
                this.btnList.Refresh();

                this.btnProcess.Location = new System.Drawing.Point(700, 5);
                this.btnPrint.Location = new System.Drawing.Point(808, 5);

                this.cbxActor.Enabled = false;

                // 薬
                if (this.mInputTab == "01")
                {
                    this.tabControl.SelectedIndex = 0;
                    this.CurrMQLayout = this.grdOCS1024;

                    // Set Congrols Enable
                    this.lblSelectJusaOrder.Enabled = false;

                    this.grdOCS1024Jusa.Enabled = false;
                }

                // 注射
                if (this.mInputTab == "03")
                {
                    this.tabControl.SelectedIndex = 1;
                    this.CurrMQLayout = this.grdOCS1024Jusa;

                    // Set Congrols Enable
                    this.lblSelectOrder.Enabled = false;

                    this.grdOCS1024.Enabled = false;
                }
            }
        }
		protected override void OnLoad(EventArgs e)
		{	 
			base.OnLoad (e);
            
            PostLoad();
			
		}

        private void grdOCS1024_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (EnvironInfo.CurrSystemID == "OCSI" || EnvironInfo.CurrSystemID == "INSI")
                e.Protect = true;
            else
            {
                // No control Inserted Row
                //string pkocs1024 = this.grdOCS1024.GetItemString(this.grdOCS1024.CurrentRowNumber, "pkocs1024");
                //if (TypeCheck.IsNull(pkocs1024)) return;

                //if (this.grdOCS1024.GetItemString(this.grdOCS1024.CurrentRowNumber, "current_suryang") == "0")
                if (e.ColName == "current_suryang") e.Protect = true;

                // 外用の場合、日数を「1」に固定
                if (e.ColName == "nalsu" &&
                    this.grdOCS1024.GetItemString(this.grdOCS1024.CurrentRowNumber, "order_gubun").Contains("D")) e.Protect = true;

                // update by p.w.j 2013/12/19
                //if (e.ColName == "hangmog_code" || e.ColName == "suryang" || e.ColName == "dv" || e.ColName == "nalsu" || e.ColName == "bogyong_code")
                if (e.ColName != "total_suryang")
                {
                    if (this.grdOCS1024.GetItemString(this.grdOCS1024.CurrentRowNumber, "total_suryang") != this.grdOCS1024.GetItemString(this.grdOCS1024.CurrentRowNumber, "current_suryang"))
                        e.Protect = true;
                }
            }
        }

		private void PostLoad()
		{      
            
            //Create Return DataLayout 
			CreateLayout();



            if (!this.grdOCS1024.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            else
            {
                //if (EnvironInfo.CurrSystemID == "OCSI")
                //{
                //    for (int i = 0; i < this.grdOCS1024.RowCount; i++)
                //    {
                //        foreach (DataColumn column in grdOCS1024.LayoutTable.Columns)
                //        {
                //            GridColumnProtectModifyEventArgs me = new GridColumnProtectModifyEventArgs(column.ToString(), i, grdOCS1024.LayoutTable.Rows[i], false);
                //            grdOCS1024_GridColumnProtectModify(grdOCS1024, me);

                //            column.ReadOnly = true;
                //        }
                //    }
                    
                //}
            }

            ////데이터 0건이고 AUTO_CLOSE_YN=Y 경우는 화면을 닫아버린다.
            //if (dloSelectOCS1023.LayoutTable.Rows.Count == 0 && mAutoClose == "Y")
            //{
            //     this.Close();
            //}
            //else
            //{
            //    //　데이터가 있으면 화면 사이즈를 Normal한다.
            //    if (mAutoClose == "Y")
            //        this.ParentForm.WindowState = FormWindowState.Normal;

            //}
         }
		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout()
		{			
			//OCS1023
			foreach(XGridCell cell in this.grdOCS1024.CellInfos)
			{
				dloSelectOCS1024.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
			}

            dloSelectOCS1024.LayoutItems.Add("brought_drg_yn", DataType.String);

			dloSelectOCS1024.InitializeLayoutTable();

            foreach (XGridCell cell in this.grdOCS1024Jusa.CellInfos)
            {
                dloSelectOCS1024Jusa.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS1024Jusa.LayoutItems.Add("brought_drg_yn", DataType.String);

            dloSelectOCS1024Jusa.InitializeLayoutTable();		
		
		}

		#endregion

		#region [Return Layout 생성]
        
        // 薬
		private void CreateReturnLayout()
		{
            if (   EnvironInfo.CurrSystemID != "OCSI"
                && EnvironInfo.CurrSystemID != "INSI") return;

			this.AcceptData();

			dloSelectOCS1024.Reset();
			
			for(int i = 0; i < grdOCS1024.RowCount; i++)
			{
				if(grdOCS1024.GetItemString(i, "select") == " ")
					dloSelectOCS1024.LayoutTable.ImportRow(grdOCS1024.LayoutTable.Rows[i]);

			}
			if(dloSelectOCS1024.LayoutTable.Rows.Count < 1 )
				return;

            // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
            DataRow row;

            for (int i = 0; i < dloSelectOCS1024.RowCount; i++)
            {
                row = dloSelectOCS1024.LayoutTable.Rows[i];

                if (row["general_disp_yn"].ToString().Trim() == "Y")
                {
                    row["hangmog_name"] = row["generic_name"].ToString().Trim();
                }
                row["brought_drg_yn"] = "Y";

                if (row["total_suryang"].ToString() != row["current_suryang"].ToString())
                {
                    if (row["dv_time"].ToString() == "/")
                        //row["nalsu"] = (double.Parse(row["current_suryang"].ToString()) / int.Parse(row["suryang"].ToString())) / int.Parse(row["dv"].ToString());
                        //row["nalsu"] = (double.Parse(row["current_suryang"].ToString()) / double.Parse(row["suryang"].ToString())).ToString("N0");
                        row["nalsu"] = System.Math.Floor((double.Parse(row["current_suryang"].ToString()) / double.Parse(row["suryang"].ToString())));
                    else
                        row["suryang"] = row["current_suryang"].ToString();

                }

            }

			//약속코드선택정보가 있는 경우 Return Value
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "OCS1024", dloSelectOCS1024);
			scrOpener.Command(ScreenID, commandParams);
            
			ClearSelect();
		}

        // 注射
        private void CreateReturnLayoutJusa()
        {
            if (   EnvironInfo.CurrSystemID != "OCSI"
                && EnvironInfo.CurrSystemID != "INSI") return;

            this.AcceptData();

            dloSelectOCS1024Jusa.Reset();

            for (int i = 0; i < grdOCS1024Jusa.RowCount; i++)
            {
                if (grdOCS1024Jusa.GetItemString(i, "select") == " ")
                    dloSelectOCS1024Jusa.LayoutTable.ImportRow(grdOCS1024Jusa.LayoutTable.Rows[i]);

            }
            if (dloSelectOCS1024Jusa.LayoutTable.Rows.Count < 1)
                return;

            // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
            DataRow row;

            for (int i = 0; i < dloSelectOCS1024Jusa.RowCount; i++)
            {
                row = dloSelectOCS1024Jusa.LayoutTable.Rows[i];

                if (row["general_disp_yn"] != null)
                {
                    if (row["general_disp_yn"].ToString().Trim() == "Y")
                    {
                        row["hangmog_name"] = row["generic_name"].ToString().Trim();
                    }
                }
                row["brought_drg_yn"] = "Y";

                if (row["total_suryang"].ToString() != row["current_suryang"].ToString())
                {
                    if (row["dv_time"].ToString() == "/")
                        //row["nalsu"] = (double.Parse(row["current_suryang"].ToString()) / int.Parse(row["suryang"].ToString())) / int.Parse(row["dv"].ToString());
                        //row["nalsu"] =                   (double.Parse(row["current_suryang"].ToString()) / double.Parse(row["suryang"].ToString())) / 1;
                        row["nalsu"] = System.Math.Floor((double.Parse(row["current_suryang"].ToString()) / double.Parse(row["suryang"].ToString())));
                    else
                        row["suryang"] = row["current_suryang"].ToString();

                }

            }

            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("OCS1024", dloSelectOCS1024Jusa);
            scrOpener.Command(ScreenID, commandParams);

            ClearSelectJusa();
        }
		
		#endregion

		#region [Control Event]
		
		private void btnProcess_Click(object sender, System.EventArgs e)
		{
            if (this.CurrMQLayout == this.grdOCS1024) // 薬
            {
                CreateReturnLayout();
            }

            if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
            {
                CreateReturnLayoutJusa();
            }
            Close();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(grdOCS1024.CurrentRowNumber < 0) return;	

			if(CurrMSLayout == grdOCS1024)
			{
				ArrayList isSelectedRow = new ArrayList();

				for (int i = grdOCS1024.RowCount - 1; i >= 0 ; i--)
				{
					if (grdOCS1024.IsSelectedRow(i) && grdOCS1024.IsVisibleRow(i)) 
						isSelectedRow.Add(i);
				}

				for (int i = 0; i < isSelectedRow.Count; i++)						
					grdOCS1024.DeleteRow((int)isSelectedRow[i]);
                        
				//select된 row가 없는 경우 현재 row삭제
				if(isSelectedRow.Count == 0) grdOCS1024.DeleteRow(grdOCS1024.CurrentRowNumber);
				
				grdOCS1024.UnSelectAll();
			}
		}
		
		
		#endregion

		#region [DataService Event]

		private void grdOCS1023_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{                            

            SelectionBackColorChange(this.grdOCS1024);

     	}

//		private void dsvLDOCS1023_ServiceEnd(object sender, IHIS.Framework.ServiceEndArgs e)
//		{
//			SelectionBackColorChange(grdOCS1023);
//		}
//
//		private void dsvLDPATOCS1023_ServiceEnd(object sender, IHIS.Framework.ServiceEndArgs e)
//		{
//			SelectionBackColorChange(grdOCS1023);		
//		}

		#endregion

		#region [grdOCS1023 Event]
		
		private void grdOCS1023_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			return;
		}

		private void grdOCS1023_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            int curRowIndex = -1;

            if (this.grdOCS1024.CurrentColName == "select")
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    curRowIndex = grdOCS1024.GetHitRowNumber(e.Y);
                    if (curRowIndex < 0) return;
                    CreateReturnLayout();
                }
                else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdOCS1024.CurrentColNumber == 0)
                {
                    curRowIndex = grdOCS1024.GetHitRowNumber(e.Y);
                    if (curRowIndex < 0) return;

                    if (grdOCS1024.CurrentColNumber == 0)
                    {
                        //불용처리된 것은 선택을 막는다.
                        if (   grdOCS1024.GetItemString(curRowIndex, "bulyong_check") == "Y" 
                            || grdOCS1024.GetItemString(curRowIndex, "usedup_yn") == "Y"
                            || double.Parse(grdOCS1024.GetItemString(curRowIndex, "current_suryang")) <= 0
                            ) return;

                        if (grdOCS1024.GetItemString(curRowIndex, "select") == "")
                        {
                            grdOCS1024.SetItemValue(curRowIndex, "select", " ");
                            SelectionBackColorChange(sender, curRowIndex, "Y");
                        }
                        else
                        {
                            grdOCS1024.SetItemValue(curRowIndex, "select", "");
                            SelectionBackColorChange(sender, curRowIndex, "N");
                        }
                    }

                }
                else if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    if (grdOCS1024.GetHitRowNumber(e.Y) < 0) return;
                    curRowIndex = grdOCS1024.GetHitRowNumber(e.Y);

                    //Drag시 show info정보
                    string dragInfo = "[" + grdOCS1024.GetItemString(curRowIndex, "hangmog_code") + "]" + grdOCS1024.GetItemString(curRowIndex, "hangmog_name");
                    DragHelper.CreateDragCursor(grdOCS1024, dragInfo, this.Font);

                    dloSelectOCS1024.Reset();
                    for (int i = 0; i < grdOCS1024.RowCount; i++)
                    {
                        if (grdOCS1024.GetItemString(i, "select") == " ")
                            dloSelectOCS1024.LayoutTable.ImportRow(grdOCS1024.LayoutTable.Rows[i]);

                    }

                    object[] dragData = new object[2];
                    dragData[0] = this.ScreenID;
                    dragData[1] = dloSelectOCS1024;
                    grdOCS1024.DoDragDrop(dragData, DragDropEffects.Move);
                }
            }
		}

		private void grdOCS1023_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시			
		}

		private void grdOCS1023_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}				
		}

		private void grdOCS1023_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.DataRow["bulyong_check"].ToString() == "Y")
			{
				e.ForeColor = Color.Red;
			}
		}

		private void grdOCS1023_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;			

			if (e.CurrentRow >= 0) 
			{				
				// 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
				//this.mHangmogInfo.DisplaySpecialColHeader("O", grd, e.CurrentRow, grd.GetItemString(e.CurrentRow, "hangmog_code"));
			}		
		}
		
		#endregion

        #region [grdOCS1024Jusa Event]
        private void grdOCS1024Jusa_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex = -1;

            if (this.grdOCS1024Jusa.CurrentColName == "select")
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    curRowIndex = grdOCS1024Jusa.GetHitRowNumber(e.Y);
                    if (curRowIndex < 0) return;
                    CreateReturnLayoutJusa();
                }
                else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdOCS1024Jusa.CurrentColNumber == 0)
                {
                    curRowIndex = grdOCS1024Jusa.GetHitRowNumber(e.Y);
                    if (curRowIndex < 0) return;

                    if (grdOCS1024Jusa.CurrentColNumber == 0)
                    {
                        //불용처리된 것은 선택을 막는다.
                        if (grdOCS1024Jusa.GetItemString(curRowIndex, "bulyong_check") == "Y"
                            || grdOCS1024Jusa.GetItemString(curRowIndex, "usedup_yn") == "Y"
                            || double.Parse(grdOCS1024Jusa.GetItemString(curRowIndex, "current_suryang")) <= 0
                            ) return;

                        if (grdOCS1024Jusa.GetItemString(curRowIndex, "select") == "")
                        {
                            grdOCS1024Jusa.SetItemValue(curRowIndex, "select", " ");
                            SelectionBackColorChange(sender, curRowIndex, "Y");
                        }
                        else
                        {
                            grdOCS1024Jusa.SetItemValue(curRowIndex, "select", "");
                            SelectionBackColorChange(sender, curRowIndex, "N");
                        }
                    }

                }
                else if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    if (grdOCS1024Jusa.GetHitRowNumber(e.Y) < 0) return;
                    curRowIndex = grdOCS1024Jusa.GetHitRowNumber(e.Y);

                    //Drag시 show info정보
                    string dragInfo = "[" + grdOCS1024Jusa.GetItemString(curRowIndex, "hangmog_code") + "]" + grdOCS1024Jusa.GetItemString(curRowIndex, "hangmog_name");
                    DragHelper.CreateDragCursor(grdOCS1024Jusa, dragInfo, this.Font);

                    dloSelectOCS1024Jusa.Reset();
                    for (int i = 0; i < grdOCS1024Jusa.RowCount; i++)
                    {
                        if (grdOCS1024Jusa.GetItemString(i, "select") == " ")
                            dloSelectOCS1024Jusa.LayoutTable.ImportRow(dloSelectOCS1024Jusa.LayoutTable.Rows[i]);

                    }

                    object[] dragData = new object[2];
                    dragData[0] = this.ScreenID;
                    dragData[1] = dloSelectOCS1024;
                    grdOCS1024Jusa.DoDragDrop(dragData, DragDropEffects.Move);
                }
            }
        }
        #endregion

        #region [項目ValidationCheck]
        private bool ValidationCheck()
        {
            object obj = null;
            string cmd = @"SELECT A.BOGYONG_GUBUN
                             FROM DRG0120 A
                            WHERE A.HOSP_CODE    = :f_hosp_code
                              AND A.BOGYONG_CODE = :f_bogyong_code
                             
            ";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            

            for (int i = 0; i < this.grdOCS1024.RowCount; i++)
            {
                // 内服の場合のみチェック
                if (this.grdOCS1024.GetItemString(i, "order_gubun").Contains("C"))
                {

                    bind.Add("f_bogyong_code", this.grdOCS1024.GetItemString(i, "bogyong_code"));
                    obj = Service.ExecuteScalar(cmd, bind);

                    if (obj == null) return false;

                    if (this.grdOCS1024.GetItemString(i, "dv") != obj.ToString())
                    {
                        XMessageBox.Show(Resources.XMessageBox1, Resources.XMessageBox_caption1);
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        private string checkHangmogCode(XEditGrid aGrid)
        {
            XEditGrid grid = aGrid as XEditGrid;

            string rtnVal = null;

            for (int i = 0; i < grid.RowCount; i++)
            {
                string hangmogCode = grid.GetItemString(i, "hangmog_code");

                for (int k = 0; k < grid.RowCount; k++)
                {
                    if (i != k && grid.GetItemString(k, "hangmog_code").Equals(hangmogCode)) rtnVal = hangmogCode;
                }
            }
            return rtnVal;
        }

        #region [ButtonList]

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    if (this.CurrMQLayout == this.grdOCS1024) // 薬
                    {
                        int row = this.grdOCS1024.InsertRow(-1);

                        this.grdOCS1024.SetItemValue(row, "input_user_id", this.cbxActor.GetDataValue());
                    }

                    if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
                    {
                        int row = this.grdOCS1024Jusa.InsertRow(-1);

                        this.grdOCS1024Jusa.SetItemValue(row, "input_user_id", this.cbxActor.GetDataValue());
                    }

                    break;

                case FunctionType.Delete:
                    e.IsBaseCall = false;

                    if (this.CurrMQLayout == this.grdOCS1024) // 薬
                    {
                        string cmd = @"SELECT B.TOTAL_SURYANG, B.CURRENT_SURYANG
                                         FROM OCS2003 A
                                             ,OCS1024 B
                                        WHERE A.HOSP_CODE      = :f_hosp_code
                                          AND A.HANGMOG_CODE   = :f_hangmog_code
                                          AND A.FKINP1001      = :f_fkinp1001
                                          AND A.BROUGHT_DRG_YN = 'Y'
                                          --AND A.MUHYO          = 'Y'
                                          --
                                          AND B.HOSP_CODE = A.HOSP_CODE
                                          AND B.PKOCS1024 = A.PKOCS1024";
                        BindVarCollection bind = new BindVarCollection();

                        bind.Add("f_hosp_code", EnvironInfo.HospCode);
                        bind.Add("f_hangmog_code", this.grdOCS1024.GetItemString(this.grdOCS1024.CurrentRowNumber, "hangmog_code"));
                        bind.Add("f_fkinp1001", this.grdOCS1024.GetItemString(this.grdOCS1024.CurrentRowNumber, "fkinp1001"));

                        DataTable dt = Service.ExecuteDataTable(cmd, bind);

                        if (dt.Rows.Count > 0 && (double.Parse(dt.Rows[0]["total_suryang"].ToString()) != double.Parse(dt.Rows[0]["current_suryang"].ToString())))
                        {
                            XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption1);
                            return;
                        }
                        else
                            this.grdOCS1024.DeleteRow(this.grdOCS1024.CurrentRowNumber);
                    }

                    if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
                    {
                        string cmd = @"SELECT B.TOTAL_SURYANG, B.CURRENT_SURYANG
                                         FROM OCS2003 A
                                             ,OCS1024 B
                                        WHERE A.HOSP_CODE      = :f_hosp_code
                                          AND A.HANGMOG_CODE   = :f_hangmog_code
                                          AND A.FKINP1001      = :f_fkinp1001
                                          AND A.BROUGHT_DRG_YN = 'Y'
                                          --AND A.MUHYO          = 'Y'
                                          --
                                          AND B.HOSP_CODE = A.HOSP_CODE
                                          AND B.PKOCS1024 = A.PKOCS1024";
                        BindVarCollection bind = new BindVarCollection();

                        bind.Add("f_hosp_code", EnvironInfo.HospCode);
                        bind.Add("f_hangmog_code", this.grdOCS1024Jusa.GetItemString(this.grdOCS1024Jusa.CurrentRowNumber, "hangmog_code"));
                        bind.Add("f_fkinp1001", this.grdOCS1024Jusa.GetItemString(this.grdOCS1024Jusa.CurrentRowNumber, "fkinp1001"));

                        DataTable dt = Service.ExecuteDataTable(cmd, bind);

                        if (dt.Rows.Count > 0 && (double.Parse(dt.Rows[0]["total_suryang"].ToString()) != double.Parse(dt.Rows[0]["current_suryang"].ToString())))
                        {
                            XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption1);
                            return;
                        }
                        else
                            this.grdOCS1024Jusa.DeleteRow(this.grdOCS1024Jusa.CurrentRowNumber);
                    }

                    break;

				case FunctionType.Query:
                    e.IsBaseCall = false;

                    if (this.CurrMQLayout == this.grdOCS1024) // 薬
                    {
                        this.grdOCS1024.QueryLayout(true);
                    }

                    if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
                    {
                        this.grdOCS1024Jusa.QueryLayout(true);
                    }
					
					break;

				case FunctionType.Update:
                    e.IsBaseCall = false;

                    if (this.CurrMQLayout == this.grdOCS1024) // 薬
                    {
                        //if (this.grdOCS1024.RowCount < 1) return;

                        //string hangmogCode = this.checkHangmogCode(this.grdOCS1024);

                        //if (!TypeCheck.IsNull(hangmogCode))
                        //{
                        //    XMessageBox.Show("同じ項目コード [" + hangmogCode + "] が登録されています。", "重複コード確認", MessageBoxIcon.Warning);
                        //    return;
                        //}

                        try
                        {
                            this.AcceptData();

                            Service.BeginTransaction();

                            if (this.grdOCS1024.SaveLayout())
                            {
                                Service.CommitTransaction();

                                XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox_caption2, MessageBoxIcon.Warning);

                                //키값 때문에 일단은...
                                if (!this.grdOCS1024.QueryLayout(false))
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return;
                                }
                            }
                            else
                            {
                                Service.RollbackTransaction();
                                mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.mbxMsg_JP : Resources.mbxMsg_Ko;
                                mbxMsg = mbxMsg + Service.ErrFullMsg;
                                mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                                XMessageBox.Show(mbxMsg, mbxCap);
                            }

                        }
                        catch (Exception xe)
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show("ButtonList Update CommitRransaction " + xe.Message);
                        }
                    }

                    if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
                    {
                        //if (this.grdOCS1024Jusa.RowCount < 1) return;

                        string hangmogCode = this.checkHangmogCode(this.grdOCS1024Jusa);

                        if (!TypeCheck.IsNull(hangmogCode))
                        {
                            XMessageBox.Show(Resources.XMessageBox5 + hangmogCode + Resources.XMessageBox6, Resources.XMessageBox_Caption3, MessageBoxIcon.Warning);
                            return;
                        }

                        try
                        {
                            this.AcceptData();

                            Service.BeginTransaction();

                            if (this.grdOCS1024Jusa.SaveLayout())
                            {
                                Service.CommitTransaction();

                                XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox_caption2, MessageBoxIcon.Warning);

                                //키값 때문에 일단은...
                                if (!this.grdOCS1024Jusa.QueryLayout(false))
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return;
                                }
                            }
                            else
                            {
                                Service.RollbackTransaction();
                                mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.mbxMsg_JP : Resources.mbxMsg_Ko;
                                mbxMsg = mbxMsg + Service.ErrFullMsg;
                                mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                                XMessageBox.Show(mbxMsg, mbxCap);
                            }

                        }
                        catch (Exception xe)
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show("ButtonList Update CommitRransaction " + xe.Message);
                        }
                    }

					break;


				default:

					break;
			}			
		}

		#endregion
		
		#region [Function]

		private void ClearSelect()
		{
			//선택된 row Clear
			for(int i = 0; i < this.grdOCS1024.RowCount; i++)
			{
				grdOCS1024.SetItemValue(i, "select", "");
			}

			SelectionBackColorChange(grdOCS1024);

			dloSelectOCS1024.Reset();
		}

        private void ClearSelectJusa()
        {
            //선택된 row Clear
            for (int i = 0; i < this.grdOCS1024Jusa.RowCount; i++)
            {
                grdOCS1024Jusa.SetItemValue(i, "select", "");
            }

            SelectionBackColorChange(grdOCS1024Jusa);

            dloSelectOCS1024Jusa.Reset();
        }     
		
		#endregion

		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
		private void SelectionBackColorChange(object grd, int currentRowIndex, string data)
		{
			XGrid grdObject = (XGrid)grd;
			//선택된 Row에대해서 색을 변경한다
			//data   Y :색을 변경, N :색을 변경 해제
			//image 설정
			if(data == "Y")
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
			else
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];

			for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
			{
				if(data == "Y")
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
				}
				else 
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
				}
			}
			
		}

		
		
		private void SelectionBackColorChange(object grd)
		{
			XGrid grdObject = (XGrid)grd;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{	
				//불용은 넘어간다.
                if (grdObject.GetItemString(rowIndex, "bulyong_check") == "Y" || grdObject.GetItemString(rowIndex, "usedup_yn") == "Y") continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];					

					//ColorYn Y :색을 변경, N :색을 변경 해제
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
					}
				}
				else
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					}
				}
			}
		}
		#endregion

		#region [전체선택]

		private void lblSelectOrder_Click(object sender, System.EventArgs e)
		{
			if(lblSelectOrder.ImageIndex == 0)
			{
				grdSelectAll(grdOCS1024, true);
				lblSelectOrder.ImageIndex = 1;
				lblSelectOrder.Text = Resources.lblSelectOrderText1;
			}
			else
			{
				grdSelectAll(grdOCS1024, false);
				lblSelectOrder.ImageIndex = 0;
				lblSelectOrder.Text = Resources.lblSelectOrderText2;
			}
		}

        private void lblSelectJusaOrder_Click(object sender, EventArgs e)
        {
            if (lblSelectJusaOrder.ImageIndex == 0)
            {
                grdSelectAll(grdOCS1024Jusa, true);
                lblSelectJusaOrder.ImageIndex = 1;
                lblSelectJusaOrder.Text = Resources.lblSelectOrderText1;
            }
            else
            {
                grdSelectAll(grdOCS1024Jusa, false);
                lblSelectJusaOrder.ImageIndex = 0;
                lblSelectJusaOrder.Text = Resources.lblSelectOrderText2;
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
                    if (   grdObject.GetItemString(rowIndex, "bulyong_check") != "Y" 
                        && grdObject.GetItemString(rowIndex, "usedup_yn") != "Y" 
                        && double.Parse(grdObject.GetItemString(rowIndex, "current_suryang")) > 0
                        ) 
                        grdObject.SetItemValue(rowIndex, "select", " ");
				}
			}
			else
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
                    if (   grdObject.GetItemString(rowIndex, "bulyong_check") != "Y" 
                        && grdObject.GetItemString(rowIndex, "usedup_yn") != "Y"
                        && double.Parse(grdObject.GetItemString(rowIndex, "current_suryang")) > 0
                        ) 
                        grdObject.SetItemValue(rowIndex, "select", "");
				}
			}

			SelectionBackColorChange(grdObject);
		}

		#endregion

		#region 저장로직
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private OCS1024U00 parent = null;

			public XSavePerformer(OCS1024U00 parent)
			{
				this.parent = parent;
			}

			public bool Execute(char callerID, RowDataItem item)
			{
				String cmdQry = null;
				string p_seq = "";
                string pkocs1024 = "";

                string cmd = @" SELECT NVL(MAX(SEQ), 0) + 1
                                  FROM OCS1024
                                 WHERE HOSP_CODE = :f_hosp_code
                                   AND BUNHO     = :f_bunho
                                   AND GWA       = :f_gwa"
                ;
                BindVarCollection bind = new BindVarCollection();
                bind.Add("f_hosp_code", EnvironInfo.HospCode);
                bind.Add("f_bunho", item.BindVarList["f_bunho"].ToString());
                bind.Add("f_gwa", item.BindVarList["f_gwa"].ToString());

                object obj = Service.ExecuteScalar(cmd, bind);
                if(obj != null)
                    p_seq = obj.ToString();

                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_seq", p_seq);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                string orderGubun = item.BindVarList["f_order_gubun"].VarValue;

                if (callerID == '1') // 薬GRID
                {
                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            // 内服の場合
                            if (orderGubun.Contains("C"))
                            {

                                if (!parent.ValidationCheck())
                                    return false;
                            }

                            string cmdTExt = @" SELECT OCS1024_SEQ.NEXTVAL
                                      FROM SYS.DUAL"
                                              ;

                            object retVal = Service.ExecuteScalar(cmdTExt);
                            if (retVal == null)
                            {
                                XMessageBox.Show(Service.ErrFullMsg);
                                return false;
                            }
                            else
                                pkocs1024 = retVal.ToString();

                            item.BindVarList.Add("f_pkocs1024", pkocs1024);

                            cmdQry = @"INSERT INTO OCS1024
                                   ( SYS_DATE        , SYS_ID        , UPD_DATE      , BUNHO           ,
                                     GWA             , HANGMOG_CODE  , SEQ           , FKINP1001       ,
                                     PKOCS1024       , SURYANG       , ORD_DANUI     , ORDER_DATE      ,
                                     DV_TIME         , DV            , NALSU         , GENERAL_DISP_YN ,
                                     BOGYONG_CODE    , UPD_ID        , HOSP_CODE     , ORDER_GUBUN     , 
                                     INPUT_TAB       , DRG_COMMENT   , TOTAL_SURYANG , CURRENT_SURYANG ,
                                     INPUT_USER_ID   , JUSA          , JUSA_SPD_GUBUN
                                    )
                                
                             VALUES
                                   ( SYSDATE         , :f_user_id       , SYSDATE      , :f_bunho      ,
                                     :f_gwa          , :f_hangmog_code  , :f_seq       , :f_fkinp1001  ,
                                     :f_pkocs1024    , :f_suryang       , :f_ord_danui , :f_order_date ,
                                     :f_dv_time      , :f_dv            , :f_nalsu     , 'N'           ,
                                     :f_bogyong_code , :f_user_id       , :f_hosp_code , :f_order_gubun, 
                                     :f_input_tab    , :f_drg_comment   , :f_total_suryang, :f_current_suryang ,
                                     :f_input_user_id, :f_jusa          , :f_jusa_spd_gubun
                                    )";

                            break;

                        case DataRowState.Modified:

                            // 内服の場合
                            if (orderGubun.Contains("C"))
                            {

                                if (!parent.ValidationCheck())
                                    return false;
                            }

                            cmdQry = @" UPDATE OCS1024
                                       SET UPD_ID           = :f_user_id         
                                         , UPD_DATE         = SYSDATE            
                                         , SEQ              = :f_seq             
                                         , SURYANG          = :f_suryang         
                                         , ORD_DANUI        = :f_ord_danui       
                                         , DV_TIME          = :f_dv_time         
                                         , DV               = :f_dv              
                                         , NALSU            = :f_nalsu         
                                         , DRG_COMMENT      = :f_drg_comment  
                                         , BOGYONG_CODE     = :f_bogyong_code    
                                         , TOTAL_SURYANG    = :f_total_suryang
                                         , CURRENT_SURYANG  = :f_current_suryang
                                         , INPUT_USER_ID    = :f_input_user_id
                                         , JUSA             = :f_jusa
                                         , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun
                                     WHERE PKOCS1024        = :f_pkocs1024       
                                       AND HOSP_CODE        = :f_hosp_code        ";
                            break;

                        case DataRowState.Deleted:
                            cmdQry = @"DELETE OCS1024
								    WHERE PKOCS1024 = :f_pkocs1024
                                      AND HOSP_CODE = :f_hosp_code";
                            break;
                    }
                }
                else if (callerID == '2')  // 注射GRID
                {
                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            //if (!parent.ValidationCheck())
                            //    return false;

                            string cmdTExt = @" SELECT OCS1024_SEQ.NEXTVAL
                                      FROM SYS.DUAL"
                                              ;

                            object retVal = Service.ExecuteScalar(cmdTExt);
                            if (retVal == null)
                            {
                                XMessageBox.Show(Service.ErrFullMsg);
                                return false;
                            }
                            else
                                pkocs1024 = retVal.ToString();

                            item.BindVarList.Add("f_pkocs1024", pkocs1024);

                            cmdQry = @"INSERT INTO OCS1024
                                   ( SYS_DATE        , SYS_ID        , UPD_DATE      , BUNHO           ,
                                     GWA             , HANGMOG_CODE  , SEQ           , FKINP1001       ,
                                     PKOCS1024       , SURYANG       , ORD_DANUI     , ORDER_DATE      ,
                                     DV_TIME         , DV            , NALSU         , GENERAL_DISP_YN ,
                                     BOGYONG_CODE    , UPD_ID        , HOSP_CODE     , ORDER_GUBUN     , 
                                     INPUT_TAB       , DRG_COMMENT   , TOTAL_SURYANG , CURRENT_SURYANG ,
                                     INPUT_USER_ID   , JUSA,         , JUSA_SPD_GUBUN
                                    )
                                
                             VALUES
                                   ( SYSDATE         , :f_user_id       , SYSDATE      , :f_bunho      ,
                                     :f_gwa          , :f_hangmog_code  , :f_seq       , :f_fkinp1001  ,
                                     :f_pkocs1024    , :f_suryang       , :f_ord_danui , :f_order_date ,
                                     :f_dv_time      , :f_dv            , :f_nalsu     , 'N'           ,
                                     :f_bogyong_code , :f_user_id       , :f_hosp_code , :f_order_gubun, 
                                     :f_input_tab    , :f_drg_comment   , :f_total_suryang, :f_current_suryang ,
                                     :f_input_user_id, :f_jusa          , :f_jusa_spd_gubun
                                    )";

                            break;

                        case DataRowState.Modified:

                            //if (!parent.ValidationCheck())
                            //    return false;

                            cmdQry = @" UPDATE OCS1024
                                       SET UPD_ID           = :f_user_id         
                                         , UPD_DATE         = SYSDATE            
                                         , SEQ              = :f_seq             
                                         , SURYANG          = :f_suryang         
                                         , ORD_DANUI        = :f_ord_danui       
                                         , DV_TIME          = :f_dv_time         
                                         , DV               = :f_dv              
                                         , NALSU            = :f_nalsu         
                                         , DRG_COMMENT      = :f_drg_comment  
                                         , BOGYONG_CODE     = :f_bogyong_code    
                                         , TOTAL_SURYANG    = :f_total_suryang
                                         , CURRENT_SURYANG  = :f_current_suryang
                                         , INPUT_USER_ID    = :f_input_user_id
                                         , JUSA             = :f_jusa
                                         , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun
                                     WHERE PKOCS1024        = :f_pkocs1024       
                                       AND HOSP_CODE        = :f_hosp_code        ";
                            break;

                        case DataRowState.Deleted:
                            cmdQry = @"DELETE OCS1024
								    WHERE PKOCS1024 = :f_pkocs1024
                                      AND HOSP_CODE = :f_hosp_code";
                            break;
                    }
                }

				return Service.ExecuteNonQuery(cmdQry,item.BindVarList);
			}
		}
		#endregion

        private void grdOCS1023_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS1024.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdOCS1024.SetBindVarValue("f_gwa", "01");
            this.grdOCS1024.SetBindVarValue("f_input_tab", "01");
            this.grdOCS1024.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS1024.SetBindVarValue("f_fkinp1001", this.GetPkInp1001());
            this.grdOCS1024.SetBindVarValue("f_generic_yn", this.cbxGeneric_YN.GetDataValue());
        }

        private void cbxGeneric_YN_CheckedChanged(object sender, EventArgs e)
        {
            this.grdOCS1024.QueryLayout(true);
        }

        /// <summary>
        /// 항목코드 파인드 창 오픈
        /// </summary>
        /// <param name="aHangmogCode">검색어</param>
        /// <param name="aMultiSelect">복수선택여부</param>
        private void OpenScreen_OCS0103Q00(string aHangmogCode, bool aMultiSelect)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("hangmog_code", aHangmogCode);
            param.Add("multiSelect", true);
            param.Add("input_tab", INPUTTAB);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void grdOCS1024_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "hangmog_code":     // 항목코드 

                    e.Cancel = true; // 별도의 화면 오픈 

                    if (this.dpkOrder_Date.GetDataValue() == "")
                    {
                        return;
                    }

                    this.INPUTTAB = "01";

                    this.OpenScreen_OCS0103Q00(grid.GetItemString(e.RowNumber, e.ColName), true); // 화면오픈

                    break;

                case "ord_danui_name":  // 오더단위

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part" : // 전달파트

                    // 외래 전달 파트 
                    if (this.IOEGUBUN == "O")
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    // 입원 전달파트 
                    else
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "jundal_part_out" : // 전달파트 외래

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part_inp": // 전달파트 입원

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;
                case "bogyong_code":
                    //((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("bogyong_code_inp", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    string orderGubun = this.grdOCS1024.GetItemString(e.RowNumber, "order_gubun");

                    // 外用薬
                    if (orderGubun.Contains("D")) this.OpenScreen_OCS0208Q01("", this.grdOCS1024.GetItemString(e.RowNumber, "bogyong_code"), "");

                    // 内服薬
                    if (orderGubun.Contains("C")) this.OpenScreen_OCS0208Q00();

                    break;
            }
        }

        // 内服薬 服用コード
        private void OpenScreen_OCS0208Q00()
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("suryang", "");
            openParams.Add("dv", "");
            openParams.Add("dv_time", "");
            openParams.Add("dv_1", "");
            openParams.Add("dv_2", "");
            openParams.Add("dv_3", "");
            openParams.Add("dv_4", "");
            openParams.Add("dv_5", "");
            openParams.Add("order_remark", "");

            openParams.Add("bogyong_code", "");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        // 外用薬 服用コード
        private void OpenScreen_OCS0208Q01(string aOrderRemark, string aBogyongCode, string aHangmogCode)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("order_remark", aOrderRemark);
            openParams.Add("bogyong_code", aBogyongCode);
            openParams.Add("hangmog_code", aHangmogCode);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private string getBogyong_name(string aBogyong_code)
        {
            string cmd = @"SELECT FN_DRG_LOAD_BOGYONG_NAME(:f_bogyong_code) FROM SYS.DUAL";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_bogyong_code", aBogyong_code);

            string name = Service.ExecuteScalar(cmd, bind).ToString();

            if (name != "")
                return name;
            else
                return "";
        }

        private string getJusa_name(string aJusa_code)
        {
            string cmd = @"SELECT FN_DRG_LOAD_BOGYONG_JUSA_NAME('B', :f_jusa_code) FROM SYS.DUAL";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_jusa_code", aJusa_code);

            string name = Service.ExecuteScalar(cmd, bind).ToString();

            if (name != "")
                return name;
            else
                return "";
        }

        #region GetPkInp1001()
        /// <summary>
        /// 患者番号でその患者のPKINP1001を取得する
        /// </summary>
        /// <returns>pkinp1001</returns>
        private string GetPkInp1001()
        {
            if (this.paBox.BunHo == "")
                return "0";

            string cmdText = string.Format(@"SELECT PKINP1001
                                               FROM INP1001 A
                                              WHERE BUNHO       = {0}
                                                AND JAEWON_FLAG = '{2}'
                                                AND HOSP_CODE   = '{1}'
                                              ORDER BY A.PKINP1001 DESC", this.paBox.BunHo, EnvironInfo.HospCode, "Y");

            object retVal = Service.ExecuteScalar(cmdText);

            if (retVal == null)
            {
                cmdText = string.Format(@"SELECT RESER_FKINP1001
                                               FROM INP1003
                                              WHERE BUNHO          = {0}
                                                AND RESER_END_TYPE = '0'
                                                AND HOSP_CODE      = '{1}'", this.paBox.BunHo, EnvironInfo.HospCode);

                retVal = Service.ExecuteScalar(cmdText);

                //XMessageBox.Show("在院中の患者ではありません。", "患者ID入力ミス", MessageBoxIcon.Error);
                //return "0";
            }
            if (retVal == null)
            {
                XMessageBox.Show(Resources.XMessageBox7, Resources.XMessageBox_caption1);
                this.paBox.Focus();
                return "0";
            }
            else
                return retVal.ToString();
        }
        #endregion

        #region [Command]
        public override object Command(string command, CommonItemCollection commandParam)
        {
            XEditGrid grid = null;

            string inputTab = null;

            if (this.CurrMQLayout == this.grdOCS1024) // 薬
            {
                grid = this.grdOCS1024;

                inputTab = "01";
            }

            if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
            {
                grid = this.grdOCS1024Jusa;

                inputTab = "03";
            }

            switch (command)
            {
                case "OCS0208Q00":   // 内服　복용코드 정보

                    #region 복용코드 정보

                    if (commandParam != null)
                    {
                        //if (commandParam.Contains("order_remark"))
                        //    this.mTemp = commandParam["order_remark"].ToString();
                        //else
                        //    this.mTemp = "";

                        if (commandParam.Contains("OCS0208"))
                        {
                            //this.fbxBogyongCode.SetDataValue(((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_code"));
                            //this.dbxBogyongName.SetDataValue(((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_name"));

                            grid.SetItemValue(grid.CurrentRowNumber, "bogyong_code", ((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_code"));
                            grid.SetItemValue(grid.CurrentRowNumber, "bogyong_name", ((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_name"));

                            //this.ApplyGroupInfo(((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_code")
                            //                   , ((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_name")
                            //                   , ((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "dv")
                            //                   , this.cboNalsu.GetDataValue(), this.cbxEmergency.GetDataValue(), this.cbxWonyoiOrderYN.GetDataValue()
                            //                   , ((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "donbog_yn"), this.mTemp);

                            //Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                            //// 외용 내복에 따른 그룹항목 visible Setting 
                            //this.SetGroupControlVisible(groupInfo["group_ser"].ToString());

                            //PostCallHelper.PostCall(new PostMethod(PostBogyongCodeValidating));
                        }

                        //this.mTemp = "";
                    }


                    #endregion

                    break;

                case "OCS0208Q01":   // 外用　복용코드 정보

                    #region 복용코드 정보

                    if (commandParam.Contains("bogyong_code"))
                    {
                        grid.SetItemValue(grid.CurrentRowNumber, "bogyong_code", commandParam["bogyong_code"].ToString());
                        grid.SetItemValue(grid.CurrentRowNumber, "bogyong_name", this.getBogyong_name(commandParam["bogyong_code"].ToString()));
                    }


                    #endregion

                    break;

                case "OCS0103Q00":            // 항목검색

                    #region 항목검색

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS0103") && ((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
                        {
                            foreach (DataRow dr in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
                            {
                                if (grid.GetItemString(grid.CurrentRowNumber, "hangmog_name") != "")
                                    this.btnList.PerformClick(FunctionType.Insert);
                                
                                if (this.ApplySangOrderInfo(dr["hangmog_code"].ToString(), grid.CurrentRowNumber, true, mGenericSearchYN))
                                {
                                    foreach (DataRow dr_h in this.mLayOutputHangmogInfo.LayoutTable.Rows)
                                    {
                                        foreach (DataColumn col in dr_h.Table.Columns)
                                        {
                                            if(grid.CellInfos.Contains(col.ToString()))
                                            {
                                                if (col.ToString() == "order_gubun")
                                                    grid.SetItemValue(grid.CurrentRowNumber, "order_gubun", "0" + dr_h[col.ToString()].ToString());
                                                else
                                                    grid.SetItemValue(grid.CurrentRowNumber, col.ToString(), dr_h[col.ToString()].ToString());
                                            }
                                            
                                           

                                            //dloSelectOCS1023.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
                                        }

                                        grid.SetItemValue(grid.CurrentRowNumber, "nalsu", "1");
                                        grid.SetItemValue(grid.CurrentRowNumber, "bunho", this.paBox.BunHo);
                                        grid.SetItemValue(grid.CurrentRowNumber, "gwa", "01");
                                        grid.SetItemValue(grid.CurrentRowNumber, "input_tab", inputTab);
                                        grid.SetItemValue(grid.CurrentRowNumber, "order_date", this.dpkOrder_Date.GetDataValue());
                                        grid.SetItemValue(grid.CurrentRowNumber, "fkinp1001", this.GetPkInp1001());
                                        //grid.SetItemValue(grid.CurrentRowNumber, "bogyong_code", "110002");
                                        grid.SetItemValue(grid.CurrentRowNumber, "usedup_yn", "N");
                                        grid.SetItemValue(grid.CurrentRowNumber, "muhyo", "N");
                                        grid.SetItemValue(grid.CurrentRowNumber, "total_suryang", getTotalSuryang(grid.GetItemDouble(grid.CurrentRowNumber, "suryang"), grid.GetItemInt(grid.CurrentRowNumber, "dv"), grid.GetItemInt(grid.CurrentRowNumber, "nalsu"), grid.GetItemString(grid.CurrentRowNumber, "dv_time")));
                                        // update by p.w.j 2013/12/19
                                        grid.SetItemValue(grid.CurrentRowNumber, "current_suryang", grid.GetItemDouble(grid.CurrentRowNumber, "total_suryang"));
                                        grid.SetItemValue(grid.CurrentRowNumber, "bogyong_name", this.getBogyong_name(grid.GetItemString(grid.CurrentRowNumber, "bogyong_code")));
                                    }
                                }

                            }

                        }
                    }
                    #endregion

                    break;

            }
            return base.Command(command, commandParam);
        }
        #endregion

        #region [SetLayout]
        private void SetLayout(MultiLayout aLayOutput)
        {
            aLayOutput.LayoutItems.Add("hangmog_code", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("hangmog_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("slip_code", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("group_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("position", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("input_tab", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("input_tab_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("order_gubun", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("order_gubun_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("input_control", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jundal_table_out", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jundal_table_inp", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jundal_part_out", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jundal_part_inp", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jaeryo_jundal_yn_out", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jaeryo_jundal_yn_inp", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("move_part", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("group_ser", DataType.Number, false, true);
            aLayOutput.LayoutItems.Add("suryang", DataType.Number, false, true);
            aLayOutput.LayoutItems.Add("dv_time", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("dv", DataType.Number, false, true);
            aLayOutput.LayoutItems.Add("dv_1", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("dv_2", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("dv_3", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("dv_4", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("dv_5", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("dv_6", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("dv_7", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("dv_8", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("nalsu", DataType.Number, false, true);
            aLayOutput.LayoutItems.Add("ord_danui", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("ord_danui_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jusa", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("bogyong_code", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("suga_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("sg_code", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("pay", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("symya", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("symya_time", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jaeryo_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jaeryo_code", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("bulyong_ymd", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("bulyong_check", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("bulyong_check_out", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specimen_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specimen_code", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("portable_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("portable_check", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("xray_buwi", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specific_comment", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specific_comment_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specific_comment_sys_id", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specific_comment_pgm_id", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specific_comment_not_null", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specific_comment_table_id", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specific_comment_col_id", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("reser_yn_out", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("reser_yn_inp", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("amt", DataType.Number, false, true);
            aLayOutput.LayoutItems.Add("emergency", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("emergency_check", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("limit_suryang", DataType.Number, false, true);
            aLayOutput.LayoutItems.Add("limit_nalsu", DataType.Number, false, true);
            aLayOutput.LayoutItems.Add("bom_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("return_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("bichi_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("wonyoi_order_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("wonyoi_check", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("fluid_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("tpn_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("anti_cancer_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("flag", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("nday_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("muhyo_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("mansung_jilhwan_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("powder_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("powder_check", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("mix_group", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("order_remark", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("nurse_remark", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("prn_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("prepare_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("hope_date", DataType.Date, false, true);
            aLayOutput.LayoutItems.Add("chisik", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("chisik_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("chisik_check", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("data_control", DataType.String, false, true);
            // Out 변수만 있슴
            aLayOutput.LayoutItems.Add("order_gubun_bas", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("specimen_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jusa_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("pay_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("bogyong_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jundal_part_out_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("jundal_part_inp_name", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("nday_nalsu", DataType.Number, false, true);
            aLayOutput.LayoutItems.Add("mayak_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("pkocskey", DataType.Number, false, true); // 처방 키 (타시스템 추가정보 입력시등에서 저장이전에 저장데이타관리..)
            aLayOutput.LayoutItems.Add("nurse_input_yn", DataType.String, false, true); // 간호처방 입력가능여부
            aLayOutput.LayoutItems.Add("supply_input_yn", DataType.String, false, true); // 부서처방 입력가능여부
            aLayOutput.LayoutItems.Add("nurse_confirm_gubun", DataType.String, false, true); // 간호확인구분
            //this.mLayOutputHangmogInfo.LayoutItems.Add("donbok_yn", DataType.String, false, true); // 돈복여부
            aLayOutput.LayoutItems.Add("donbog_yn", DataType.String, false, true); // 돈복여부
            aLayOutput.LayoutItems.Add("hubal_change_check", DataType.String, false, true); // 후발의약품변경가능여부
            aLayOutput.LayoutItems.Add("pharmacy_check", DataType.String, false, true); // 간이현탁법  가능여부
            aLayOutput.LayoutItems.Add("drg_pack_check", DataType.String, false, true); // 일포화가능여부
            aLayOutput.LayoutItems.Add("general_disp_yn", DataType.String, false, true); //一般名表示YN

            // 특정 input값을 받아서 처리하기 위한 컬럼
            aLayOutput.LayoutItems.Add("home_care_yn", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("gongbi_code", DataType.String, false, true);

            aLayOutput.LayoutItems.Add("dangil_gumsa_order_yn", DataType.String, false, true); // 당일검사처방여부
            aLayOutput.LayoutItems.Add("dangil_gumsa_result_yn", DataType.String, false, true); // 당일검사결과여부

            aLayOutput.LayoutItems.Add("hubal_change_yn", DataType.String, false, true); // 후발의약품사용여부
            aLayOutput.LayoutItems.Add("pharmacy", DataType.String, false, true); // 간이현탁법여부
            aLayOutput.LayoutItems.Add("drg_pack_yn", DataType.String, false, true); // 일포화여부

            // 약속처방등에서 전달파트를 가져오는 경우 Grouping등 때문에 전달파트 변경을 막기위한 변수
            aLayOutput.LayoutItems.Add("fixed_jundal", DataType.String, false, true);

            // 서버로 받을 필드들 End 

            // 대체오더정보 
            aLayOutput.LayoutItems.Add("cov_remark", DataType.String, false, true);
            aLayOutput.LayoutItems.Add("cov_msg_yn", DataType.String, false, true);

            // 특정 약속오더인 경우에는 간호사 입력가능하도록 처리
            aLayOutput.LayoutItems.Add("grant_nur", DataType.String, false, true);

            // 서버가 아닌 현 HangmogInfo에서 세팅할 필드들 즉 서버와의 Out변수로 추가할 사항이 생기면 아래가 아닌 위 // 서버로 받을 필드들 End 위에다 기술해야함			

            // 정규/임시약여부
            aLayOutput.LayoutItems.Add("regular_yn", DataType.String, false, true);

            // 유효한 레코드 인지 여부
            aLayOutput.LayoutItems.Add("record_valid", DataType.String, false, false);
            // 주사속도 구분
            aLayOutput.LayoutItems.Add("jusa_spd_gubun", DataType.String, false, true);
            // 오더구분 BAS 명칭
            aLayOutput.LayoutItems.Add("order_gubun_bas_name", DataType.String, false, false);
            // 무효
            aLayOutput.LayoutItems.Add("muhyo", DataType.String, false, false);
            // child_yn
            aLayOutput.LayoutItems.Add("child_yn", DataType.String, false, false);
            // OCS0103 IF_INPUT_CONTROL
            aLayOutput.LayoutItems.Add("if_input_control", DataType.String, false, false);
            aLayOutput.LayoutItems.Add("org_key", DataType.String, false, false);
            aLayOutput.LayoutItems.Add("parent_key", DataType.String, false, false);

            // 오더연계관련
            aLayOutput.LayoutItems.Add("order_if_yn", DataType.String, false, false);      // 인터페이스 가능항목인지 여부
            aLayOutput.LayoutItems.Add("order_if_gubun", DataType.String, false, false);   // 인터페이스 구분 ( MX, PACS )

            // bun_code 
            aLayOutput.LayoutItems.Add("bun_code", DataType.String, false, false);
            // 원내 채용약 
            aLayOutput.LayoutItems.Add("wonnae_drg_yn", DataType.String, false, false);
            // 디폴트 복용코드
            aLayOutput.LayoutItems.Add("default_bogyong_code", DataType.String, false, false);

            aLayOutput.LayoutItems.Add("bogyong_code_sub", DataType.String, false, false);
            aLayOutput.LayoutItems.Add("bogyong_name_sub", DataType.String, false, false);

            try
            {
                aLayOutput.InitializeLayoutTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion 

        #region [ApplySangOrderInfo]
        private bool ApplySangOrderInfo(string aHangmogCode, int aApplyRow, bool aIsApplyCurrentRow, string aGenericSearchYN)
        {
            // Load order's information by hangmog_code
            ArrayList inputArrayList = new ArrayList();
            ArrayList outputArrayList = new ArrayList();
            string cmdText = "";
            int outputRowIndex = -1;
            bool isSuccess = false;

            

            string returnflag = "", returnMsg = "";
            string spName = "PR_OCS_LOAD_HANGMOG_INFO";

            inputArrayList.Clear();

            inputArrayList.Add(this.dpkOrder_Date.GetDataValue()); // order_date 
            inputArrayList.Add("01"); // input_part DRG 
            inputArrayList.Add("01"); // input_gwa  DRG
            inputArrayList.Add(aHangmogCode); //hangmog_code


            if (this.CurrMQLayout == this.grdOCS1024) // 薬
            {
                inputArrayList.Add("01"); // input_tab
            }

            if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
            {
                inputArrayList.Add("03"); // input_tab
            }

            outputArrayList.Clear();
                        
            
            // Set readed order's infomation to Grid
            if (Service.ExecuteProcedure(spName, inputArrayList, outputArrayList))
            {

                returnflag = outputArrayList[65].ToString();
                returnMsg = outputArrayList[66].ToString();
                if (returnflag == "0")
                {
                    // OUTPUT Layout에 기본항목정보 Setting
                    outputRowIndex = mLayOutputHangmogInfo.InsertRow(-1);

                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["hangmog_code"] = outputArrayList[0].ToString();
                    //insert by jc [項目をLOADする時一般名のデータが入ってればその一般名をINSERT] 2012/11/01
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["hangmog_name"] = outputArrayList[1].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["slip_code"] = outputArrayList[2].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["group_yn"] = outputArrayList[3].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["input_tab"] = outputArrayList[4].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["order_gubun"] = outputArrayList[5].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["order_gubun_bas"] = outputArrayList[5].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["input_control"] = outputArrayList[6].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["jundal_table_out"] = outputArrayList[7].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["jundal_table_inp"] = outputArrayList[8].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["jundal_part_out"] = outputArrayList[9].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["jundal_part_inp"] = outputArrayList[10].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["jaeryo_jundal_yn_out"] = outputArrayList[11].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["jaeryo_jundal_yn_inp"] = outputArrayList[12].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["move_part"] = outputArrayList[13].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["suryang"] = (outputArrayList[14].ToString() == "" ? "1" : outputArrayList[14].ToString());
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["ord_danui"] = outputArrayList[15].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["dv_time"] = outputArrayList[16].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["dv"] = (outputArrayList[17].ToString() == "" ? "1" : outputArrayList[17].ToString());
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["jusa"] = outputArrayList[18].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["bogyong_code"] = outputArrayList[19].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["default_bogyong_code"] = outputArrayList[19].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["suga_yn"] = outputArrayList[20].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["sg_code"] = outputArrayList[21].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["jaeryo_yn"] = outputArrayList[22].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["jaeryo_code"] = outputArrayList[23].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["bulyong_ymd"] = outputArrayList[24].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["bulyong_check"] = outputArrayList[25].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["bulyong_check_out"] = outputArrayList[26].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["specimen_yn"] = outputArrayList[27].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["specimen_code"] = outputArrayList[28].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["portable_yn"] = outputArrayList[29].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["portable_check"] = outputArrayList[30].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["xray_buwi"] = outputArrayList[31].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["reser_yn_out"] = outputArrayList[32].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["reser_yn_inp"] = outputArrayList[33].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["emergency"] = outputArrayList[34].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["emergency_check"] = outputArrayList[35].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["bom_yn"] = outputArrayList[36].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["bichi_yn"] = outputArrayList[37].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["wonyoi_order_yn"] = outputArrayList[38].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["wonyoi_check"] = outputArrayList[39].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["powder_yn"] = outputArrayList[40].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["powder_check"] = outputArrayList[41].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["nday_yn"] = outputArrayList[42].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["chisik_yn"] = outputArrayList[43].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["muhyo_yn"] = outputArrayList[44].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["nurse_input_yn"] = outputArrayList[45].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["supply_input_yn"] = outputArrayList[46].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["limit_suryang"] = (outputArrayList[47].ToString() == "" ? "99999999" : outputArrayList[47].ToString());
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["limit_nalsu"] = (outputArrayList[48].ToString() == "" ? "99999999" : outputArrayList[48].ToString());
                    //mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["remark"] = outputArrayList[49].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["nurse_confirm_gubun"] = outputArrayList[50].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["specific_comment"] = outputArrayList[51].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["hubal_change_check"] = outputArrayList[52].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["pharmacy_check"] = outputArrayList[53].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["drg_pack_check"] = outputArrayList[54].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["child_yn"] = outputArrayList[55].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["if_input_control"] = outputArrayList[55].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["bun_code"] = outputArrayList[56].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["wonnae_drg_yn"] = outputArrayList[57].ToString();
                    
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["general_disp_yn"] = "N";

                    //外用薬、注射薬部位 2013/05/19
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["bogyong_code_sub"] = "";
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["bogyong_name_sub"] = "";


                    cmdText = " SELECT FN_OCS_LOAD_CODE_NAME('ORD_DANUI', TRIM('" + mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["ord_danui"].ToString() + "')) ORD_DANUI_NAME "
                            + "   FROM SYS.DUAL ";

                    DataTable tableCodeName = Service.ExecuteDataTable(cmdText);
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["ord_danui_name"] = tableCodeName.Rows[0][0].ToString();
                    mLayOutputHangmogInfo.LayoutTable.Rows[outputRowIndex]["input_tab"] = "01";
                }
                // 항목정보 Load 실패
                else
                {
                    if (returnflag == "3")
                    {
                        isSuccess = false;
                        return isSuccess;
                    }
                    else
                    {
                        isSuccess = false;
                        mbxMsg = "[" + aHangmogCode + "] " + Resources.XMessageBox8;
                        mbxCap = Resources.mbxCap2;
                        MessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return isSuccess;
                    }
                }
                isSuccess = true;
                return isSuccess;
            }
            else
            {
                isSuccess = false;
                mbxMsg = "[" + aHangmogCode + "] HangmogInfo Load Error.";
                mbxCap = Resources.mbxCap2;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
                return isSuccess;

            }
        }
        #endregion

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            if (GetPkInp1001() == "0")
                return;
            else
            {
                this.grdOCS1024.QueryLayout(false);

                this.grdOCS1024Jusa.QueryLayout(false);
            }
        }

        private void grdOCS1024_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if(e.DataRow["usedup_yn"].ToString() == "Y" || (e.DataRow["current_suryang"].ToString() != "" && double.Parse(e.DataRow["current_suryang"].ToString()) <= 0))
                e.BackColor = Color.LightGray;
        }

        private double getTotalSuryang(double aSuryang, double aDv, double aNalsu, string aDv_time)
        {
            double result = -1;
            switch (aDv_time)
            {
                case "*":
                    if (aSuryang > 0 && aDv > 0 && aNalsu > 0)
                        result = aSuryang * aDv * aNalsu;
                    break;
                case "/":
                    if (aSuryang > 0 && aNalsu > 0)
                        result = aSuryang * aNalsu;
                    break;
            }

            if (result > 0)
                return result;
            else
                return 0;
        }
        private void grdOCS1024_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            string code_name = "";

            object previousValue = grid.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer);

            switch (e.ColName)
            {
                case "hangmog_code":

                    // 注射
                    if (this.CurrMQLayout == this.grdOCS1024Jusa) this.INPUTTAB = "03";

                    this.OpenScreen_OCS0103Q00(grid.GetItemString(e.RowNumber, e.ColName), true); // 화면오픈

                    // 注射の場合、基本「１」にセット
                    grid.SetItemValue(e.RowNumber, "dv", 1);
                    grid.SetItemValue(e.RowNumber, "total_suryang", 1);
                    grid.SetItemValue(e.RowNumber, "current_suryang", 1);
                    break;
                case "suryang":
                case "dv":
                case "nalsu":
                    grid.SetItemValue(e.RowNumber, "total_suryang", this.getTotalSuryang(grid.GetItemDouble(e.RowNumber, "suryang"), grid.GetItemDouble(e.RowNumber, "dv"), grid.GetItemDouble(e.RowNumber, "nalsu"), grid.GetItemString(e.RowNumber, "dv_time")));
                    // update by p.w.j 2013/12/19
                    grid.SetItemValue(e.RowNumber, "current_suryang", grid.GetItemString(e.RowNumber, "total_suryang"));
                    break;
                case "bogyong_code":
                    if (this.CurrMQLayout == this.grdOCS1024) // 薬
                        grid.SetItemValue(e.RowNumber, "bogyong_name", this.getBogyong_name(e.ChangeValue.ToString()));
                    break;
                case "jusa":
                    if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
                        grid.SetItemValue(e.RowNumber, "jusa_name", this.getJusa_name(e.ChangeValue.ToString()));
                    break;
                case "ord_danui_name":

                    if (!TypeCheck.IsNull(e.ChangeValue))
                    {

                        if (!this.mOrderBiz.LoadColumnCodeName(e.ColName, e.ChangeValue.ToString().Trim(), e.DataRow["hangmog_code"].ToString(), ref code_name))
                        {

                            mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.XMessageBox9_JP : Resources.XMessageBox_Ko;

                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);




                            this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다

                        }

                        else
                        {

                            grid.SetItemValue(e.RowNumber, "ord_danui", code_name); // 처방단위 세팅

                        }

                    }

                    else // null 인 경우 default 값으로 세팅한다	
                    {

                        string ord_danui = "", ord_danui_name = "";

                        if (this.mOrderBiz.GetDefaultOrdDanui(e.DataRow["hangmog_code"].ToString(), ref ord_danui, ref ord_danui_name))
                        {

                            grid.SetItemValue(e.RowNumber, "ord_danui", ord_danui);

                            grid.SetItemValue(e.RowNumber, e.ColName, ord_danui_name);

                        }

                    }
                    break;

                // update by p.w.j 2013/12/19
                case "total_suryang":

                    // オーダ登録した数量
                    double used_suryang = double.Parse(previousValue.ToString()) - grid.GetItemDouble(e.RowNumber, "current_suryang");

                    // 残量にセットする。
                    grid.SetItemValue(e.RowNumber, "current_suryang", grid.GetItemDouble(e.RowNumber, "total_suryang") - used_suryang);

                    break;
            }
        }

        #region [印刷関連]
        private void dwPrint_PrintStart(object sender, CancelEventArgs e)
        {
            if (this.CurrMQLayout == this.grdOCS1024) // 薬
            {
                for (int i = 0; i < this.grdOCS1024.RowCount; i++)
                {
                    this.grdOCS1024.SetItemValue(i, "suname", this.paBox.SuName);
                }

                this.dwPrint.SourceTable = this.grdOCS1024.LayoutTable;
            }

            if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
            {
                for (int i = 0; i < this.grdOCS1024Jusa.RowCount; i++)
                {
                    this.grdOCS1024Jusa.SetItemValue(i, "suname", this.paBox.SuName);
                }

                this.dwPrint.SourceTable = this.grdOCS1024Jusa.LayoutTable;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (this.CurrMQLayout == this.grdOCS1024) // 薬
            {
                this.dwPrint.DataWindowObject = "d_drg900";
                dwPrint.Print();
            }

            if (this.CurrMQLayout == this.grdOCS1024Jusa) // 注射
            {
                this.dwPrint.DataWindowObject = "d_drg900_jusa";
                dwPrint.Print();
            }
        }
        #endregion

        private void grdOCS1024Jusa_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "hangmog_code":     // 항목코드 

                    e.Cancel = true; // 별도의 화면 오픈 

                    this.INPUTTAB = "03";

                    this.OpenScreen_OCS0103Q00(grid.GetItemString(e.RowNumber, e.ColName), true); // 화면오픈

                    break;

                case "ord_danui_name":  // 오더단위

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part": // 전달파트

                    // 외래 전달 파트 
                    if (this.IOEGUBUN == "O")
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    // 입원 전달파트 
                    else
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "jundal_part_out": // 전달파트 외래

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part_inp": // 전달파트 입원

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;
                case "jusa":
                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jusa", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;
            }
        }

        #region [TAB Change]
        private void tabControl_SelectionChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                this.CurrMQLayout = this.grdOCS1024;
            }

            if (tabControl.SelectedIndex == 1)
            {
                this.CurrMQLayout = this.grdOCS1024Jusa;
            }

            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region [注射GRID イベント]
        private void grdOCS1024Jusa_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS1024Jusa.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdOCS1024Jusa.SetBindVarValue("f_gwa", "01");
            this.grdOCS1024Jusa.SetBindVarValue("f_input_tab", "03");
            this.grdOCS1024Jusa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS1024Jusa.SetBindVarValue("f_fkinp1001", this.GetPkInp1001());
            this.grdOCS1024Jusa.SetBindVarValue("f_generic_yn", this.cbxGeneric_YN.GetDataValue());
        }

        private void grdOCS1024Jusa_QueryEnd(object sender, QueryEndEventArgs e)
        {
            SelectionBackColorChange(this.grdOCS1024Jusa);
        }

        private void grdOCS1024Jusa_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (EnvironInfo.CurrSystemID == "OCSI")
                e.Protect = true;
            else
            {
                // No control Inserted Row
                //string pkocs1024 = this.grdOCS1024.GetItemString(this.grdOCS1024.CurrentRowNumber, "pkocs1024");
                //if (TypeCheck.IsNull(pkocs1024)) return;

                //if (this.grdOCS1024.GetItemString(this.grdOCS1024.CurrentRowNumber, "current_suryang") == "0")
                if (e.ColName == "current_suryang") e.Protect = true;

                // update by p.w.j 2013/12/19
                //if (e.ColName == "hangmog_code" || e.ColName == "suryang" || e.ColName == "dv" || e.ColName == "nalsu" || e.ColName == "jusa")
                if (e.ColName != "total_suryang")
                {
                    if (this.grdOCS1024Jusa.GetItemString(this.grdOCS1024Jusa.CurrentRowNumber, "total_suryang") != this.grdOCS1024Jusa.GetItemString(this.grdOCS1024Jusa.CurrentRowNumber, "current_suryang"))
                        e.Protect = true;
                }
            }
        }
        #endregion
    }
}

