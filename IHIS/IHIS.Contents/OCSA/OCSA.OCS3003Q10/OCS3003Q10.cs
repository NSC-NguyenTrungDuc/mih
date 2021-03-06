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
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.Framework;
using IHIS.OCS;
using System.IO;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS3003Q10에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS3003Q10 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리		
        private IHIS.OCS.PatientInfo mSelectedPatientInfo = null;
		#endregion

		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		//등록번호
		private string mBunho = "";
		//처방일자
		private string mOrder_date = "";
        //入外区分
        private string mIO_GUBUN = "";
		//INPUT GUBUN
		private string mInputGubun = "";
        //依頼区分　B：一般、D：廃用
        private string mIraiKubun = "";
        // 팝업메뉴
        private IHIS.X.Magic.Menus.PopupMenu mMenuPFEResult = new IHIS.X.Magic.Menus.PopupMenu();

        private DirectoryInfo dirInfo = null;
        private string fileName = "";

		#endregion

        private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
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
		private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
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
        private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
		private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell67;
		private IHIS.Framework.XEditGridCell xEditGridCell68;
		private IHIS.Framework.XEditGridCell xEditGridCell69;
		private IHIS.Framework.XEditGridCell xEditGridCell70;
		private IHIS.Framework.XEditGridCell xEditGridCell71;
		private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
		private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
		private IHIS.Framework.XEditGridCell xEditGridCell80;
		private IHIS.Framework.XEditGridCell xEditGridCell81;
		private IHIS.Framework.XEditGridCell xEditGridCell82;
		private IHIS.Framework.XEditGridCell xEditGridCell83;
		private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
		private IHIS.Framework.XEditGridCell xEditGridCell87;
		private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
		private IHIS.Framework.XEditGridCell xEditGridCell92;
		private IHIS.Framework.XEditGridCell xEditGridCell93;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XDatePicker dpkOrder_date;
		private IHIS.Framework.XEditGridCell xEditGridCell94;
		private IHIS.Framework.XLabel lblSelectOrder;
		private IHIS.Framework.XLabel lblSelectSang;
		private IHIS.Framework.XEditGridCell xEditGridCell98;
		private IHIS.Framework.XEditGridCell xEditGridCell99;
		private IHIS.Framework.XEditGridCell xEditGridCell100;
		private IHIS.Framework.XEditGridCell xEditGridCell101;
		private IHIS.Framework.XEditGridCell xEditGridCell102;
		private IHIS.Framework.XEditGridCell xEditGridCell103;
		private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell105;
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
		private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XEditGridCell xEditGridCell110;
		private IHIS.Framework.XEditGridCell xEditGridCell111;
		private IHIS.Framework.XEditGridCell xEditGridCell112;
		private IHIS.Framework.XEditGridCell xEditGridCell113;
		private IHIS.Framework.XEditGridCell xEditGridCell114;
		private IHIS.Framework.XEditGridCell xEditGridCell115;
		private IHIS.Framework.XEditGridCell xEditGridCell116;
		private IHIS.Framework.XEditGridCell xEditGridCell117;
		private IHIS.Framework.XEditGridCell xEditGridCell118;
		private IHIS.Framework.XEditGridCell xEditGridCell119;
		private IHIS.Framework.XEditGridCell xEditGridCell120;
		private IHIS.Framework.XEditGridCell xEditGridCell121;
		private IHIS.Framework.XEditGridCell xEditGridCell122;
		private IHIS.Framework.XEditGridCell xEditGridCell123;
		private IHIS.Framework.XEditGridCell xEditGridCell124;
		private IHIS.Framework.XEditGridCell xEditGridCell125;
		private IHIS.Framework.XEditGridCell xEditGridCell126;
		private IHIS.Framework.XEditGridCell xEditGridCell127;
		private IHIS.Framework.XEditGridCell xEditGridCell128;
		private IHIS.Framework.XEditGridCell xEditGridCell129;
        private IHIS.Framework.XEditGridCell xEditGridCell130;
        private IHIS.Framework.XEditGridCell xEditGridCell132;
        private IHIS.Framework.XEditGridCell xEditGridCell135;
        private IHIS.Framework.XEditGridCell xEditGridCell143;
		private IHIS.Framework.XPatientBox pbxSearch;
		private IHIS.Framework.XMstGrid grdOrderDateList;
		private IHIS.Framework.XEditGrid grdSangInfo;
		private IHIS.Framework.XEditGrid grdOrderInfo;
		private System.Windows.Forms.ImageList imageListMixGroup;
		private System.Windows.Forms.RadioButton rbtOut;
		private System.Windows.Forms.RadioButton rbtIn;
		private IHIS.Framework.XPanel xPanel6;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell95;
		private IHIS.Framework.XEditGridCell xEditGridCell96;
		private IHIS.Framework.XEditGridCell xEditGridCell97;
		private IHIS.Framework.XEditGridCell xEditGridCell142;
		private IHIS.Framework.XEditGridCell xEditGridCell145;
		private IHIS.Framework.XEditGridCell xEditGridCell146;
		private IHIS.Framework.XEditGridCell xEditGridCell147;
		private IHIS.Framework.XEditGridCell xEditGridCell148;
		private IHIS.Framework.XEditGridCell xEditGridCell149;
        private IHIS.Framework.XEditGridCell xEditGridCell150;
        private IHIS.Framework.XTabControl tabOrderGubun;
		private IHIS.Framework.XEditGridCell xEditGridCell151;
		private IHIS.Framework.XPanel pnlSang;
		private IHIS.Framework.XPanel pnlOrder;
        private System.Windows.Forms.Splitter sptMid;
        private IHIS.Framework.XEditGridCell xEditGridCell158;
		private IHIS.Framework.XEditGridCell xEditGridCell160;
		private IHIS.Framework.XEditGridCell xEditGridCell161;
		private IHIS.Framework.XEditGridCell xEditGridCell162;
		private IHIS.Framework.XEditGridCell xEditGridCell163;
		private IHIS.Framework.XEditGridCell xEditGridCell164;
		private IHIS.Framework.XTextBox txtDrg_info;
		private IHIS.Framework.XButton btnLabelPrt;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XEditGridCell xEditGridCell165;
		private IHIS.Framework.XEditGridCell xEditGridCell166;
		private IHIS.Framework.XEditGridCell xEditGridCell167;
        //private XEditGridCell xEditGridCell133;
        private XButtonList btnList;
        private XPanel xPanel2;
        private XEditGridCell xEditGridCell31;
        private IHIS.X.Magic.Controls.TabPage tabPage5;
        private XButton btnIraisyo;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XButton btnCopy;
        private XEditGridCell xEditGridCell60;
        private XPanel pnlImage;
        private XButton btnRotateL;
        private XButton btnRotateR;
        private XPictureBox pbxImage;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XButton btnHealthQuestionnair;
		private System.ComponentModel.IContainer components;

        public OCS3003Q10()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리		

            grdOrderDateList.ParamList = new List<string>(new String[] { "f_bunho", "f_order_date", "f_io_gubun", "f_order_gubun" });
            grdOrderDateList.ExecuteQuery = ExecuteQueryGrdOrderDateListItemInfo;

            grdOrderInfo.ParamList = new List<string>(new String[] { "f_bunho", "f_naewon_date", "f_gwa", "f_doctor", "f_naewon_type", "f_jubsu_no", "f_order_gubun", "f_pk_order", "f_io_gubun", "f_pkocskey" });
            grdOrderInfo.ExecuteQuery = ExecuteQueryGrdOrderListItemInfo;

            grdSangInfo.ParamList = new List<string>(new String[] { "f_bunho", "f_naewon_date", "f_gwa", "f_doctor", "f_naewon_type", "f_jubsu_no", "f_io_gubun" });
            grdSangInfo.ExecuteQuery = ExecuteQueryGrdSangListItemInfo;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS3003Q10));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.dpkOrder_date = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.btnLabelPrt = new IHIS.Framework.XButton();
            this.pbxSearch = new IHIS.Framework.XPatientBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdOrderDateList = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.tabOrderGubun = new IHIS.Framework.XTabControl();
            this.tabPage5 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbtIn = new System.Windows.Forms.RadioButton();
            this.rbtOut = new System.Windows.Forms.RadioButton();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.pnlSang = new IHIS.Framework.XPanel();
            this.grdSangInfo = new IHIS.Framework.XEditGrid();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.lblSelectSang = new IHIS.Framework.XLabel();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.grdOrderInfo = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell160 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.txtDrg_info = new IHIS.Framework.XTextBox();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell165 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.lblSelectOrder = new IHIS.Framework.XLabel();
            this.sptMid = new System.Windows.Forms.Splitter();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnCopy = new IHIS.Framework.XButton();
            this.btnHealthQuestionnair = new IHIS.Framework.XButton();
            this.btnIraisyo = new IHIS.Framework.XButton();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.pnlImage = new IHIS.Framework.XPanel();
            this.btnRotateL = new IHIS.Framework.XButton();
            this.btnRotateR = new IHIS.Framework.XButton();
            this.pbxImage = new IHIS.Framework.XPictureBox();
            this.xPanel1.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderDateList)).BeginInit();
            this.tabOrderGubun.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.pnlSang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangInfo)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
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
            this.ImageList.Images.SetKeyName(6, "RR331.ico");
            this.ImageList.Images.SetKeyName(7, "ﾃ､ｿｭｽﾇ.ico");
            this.ImageList.Images.SetKeyName(8, "ﾃｻｱｸｽﾉｻ・.ico");
            this.ImageList.Images.SetKeyName(9, "RANG.ico");
            this.ImageList.Images.SetKeyName(10, "view.gif");
            this.ImageList.Images.SetKeyName(11, "グラフ.ico");
            this.ImageList.Images.SetKeyName(12, "生理.gif");
            this.ImageList.Images.SetKeyName(13, "BML結果照会.ico");
            this.ImageList.Images.SetKeyName(14, "結果照会.ico");
            this.ImageList.Images.SetKeyName(15, "生理検査結果.ico");
            this.ImageList.Images.SetKeyName(16, "放射線照会.ico");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.pbxSearch);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.dpkOrder_date);
            this.xPanel4.Controls.Add(this.xLabel5);
            this.xPanel4.Controls.Add(this.btnLabelPrt);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // dpkOrder_date
            // 
            this.dpkOrder_date.AccessibleDescription = null;
            this.dpkOrder_date.AccessibleName = null;
            resources.ApplyResources(this.dpkOrder_date, "dpkOrder_date");
            this.dpkOrder_date.BackgroundImage = null;
            this.dpkOrder_date.Font = null;
            this.dpkOrder_date.Name = "dpkOrder_date";
            this.dpkOrder_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkOrder_date_DataValidating);
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // btnLabelPrt
            // 
            this.btnLabelPrt.AccessibleDescription = null;
            this.btnLabelPrt.AccessibleName = null;
            resources.ApplyResources(this.btnLabelPrt, "btnLabelPrt");
            this.btnLabelPrt.BackgroundImage = null;
            this.btnLabelPrt.Font = null;
            this.btnLabelPrt.ImageIndex = 2;
            this.btnLabelPrt.ImageList = this.ImageList;
            this.btnLabelPrt.Name = "btnLabelPrt";
            this.btnLabelPrt.Click += new System.EventHandler(this.btnLabelPrt_Click);
            // 
            // pbxSearch
            // 
            this.pbxSearch.AccessibleDescription = null;
            this.pbxSearch.AccessibleName = null;
            resources.ApplyResources(this.pbxSearch, "pbxSearch");
            this.pbxSearch.BackgroundImage = null;
            this.pbxSearch.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.pbxSearch.Font = null;
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.PatientSelectionFailed += new System.EventHandler(this.pbxSearch_PatientSelectionFailed);
            this.pbxSearch.PatientSelected += new System.EventHandler(this.pbxSearch_PatientSelected);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdOrderDateList);
            this.xPanel3.Controls.Add(this.tabOrderGubun);
            this.xPanel3.Controls.Add(this.xPanel6);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdOrderDateList
            // 
            resources.ApplyResources(this.grdOrderDateList, "grdOrderDateList");
            this.grdOrderDateList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell127,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell129,
            this.xEditGridCell8,
            this.xEditGridCell164,
            this.xEditGridCell9,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell39,
            this.xEditGridCell57,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63});
            this.grdOrderDateList.ColPerLine = 11;
            this.grdOrderDateList.Cols = 12;
            this.grdOrderDateList.EnableMultiSelection = true;
            this.grdOrderDateList.ExecuteQuery = null;
            this.grdOrderDateList.FixedCols = 1;
            this.grdOrderDateList.FixedRows = 1;
            this.grdOrderDateList.HeaderHeights.Add(28);
            this.grdOrderDateList.ImageList = this.ImageList;
            this.grdOrderDateList.Name = "grdOrderDateList";
            this.grdOrderDateList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderDateList.ParamList")));
            this.grdOrderDateList.QuerySQL = resources.GetString("grdOrderDateList.QuerySQL");
            this.grdOrderDateList.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOrderDateList.RowHeaderVisible = true;
            this.grdOrderDateList.Rows = 2;
            this.grdOrderDateList.RowStateCheckOnPaint = false;
            this.grdOrderDateList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOrderDateList_GridColumnChanged);
            this.grdOrderDateList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOrderDateList_MouseDown);
            this.grdOrderDateList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrderDateList_RowFocusChanged);
            this.grdOrderDateList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderDateList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "naewon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell1.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "gwa";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsUpdatable = false;
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 69;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellName = "doctor_name";
            this.xEditGridCell3.CellWidth = 90;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bunho";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "naewon_type";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "jubsu_no";
            this.xEditGridCell129.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsUpdatable = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pk_order";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellName = "io_gubun";
            this.xEditGridCell164.Col = -1;
            this.xEditGridCell164.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell164, "xEditGridCell164");
            this.xEditGridCell164.IsUpdatable = false;
            this.xEditGridCell164.IsVisible = false;
            this.xEditGridCell164.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "specific_comment";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "pkocskey";
            this.xEditGridCell34.Col = 5;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsUpdatable = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "hangmog_name";
            this.xEditGridCell35.CellWidth = 133;
            this.xEditGridCell35.Col = 2;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdatable = false;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "hangmog_code";
            this.xEditGridCell39.Col = 6;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsUpdatable = false;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "jundal_part";
            this.xEditGridCell57.CellWidth = 99;
            this.xEditGridCell57.Col = 7;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsUpdatable = false;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "irai_kubun";
            this.xEditGridCell60.Col = 8;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsUpdatable = false;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellLen = 50;
            this.xEditGridCell61.CellName = "image";
            this.xEditGridCell61.Col = 9;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsUpdatable = false;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellLen = 50;
            this.xEditGridCell62.CellName = "image_path";
            this.xEditGridCell62.CellWidth = 94;
            this.xEditGridCell62.Col = 10;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsUpdatable = false;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "cr_time";
            this.xEditGridCell63.Col = 11;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsUpdatable = false;
            // 
            // tabOrderGubun
            // 
            this.tabOrderGubun.AccessibleDescription = null;
            this.tabOrderGubun.AccessibleName = null;
            resources.ApplyResources(this.tabOrderGubun, "tabOrderGubun");
            this.tabOrderGubun.BackgroundImage = null;
            this.tabOrderGubun.Font = null;
            this.tabOrderGubun.IDEPixelArea = true;
            this.tabOrderGubun.IDEPixelBorder = false;
            this.tabOrderGubun.ImageList = this.ImageList;
            this.tabOrderGubun.Name = "tabOrderGubun";
            this.tabOrderGubun.SelectedIndex = 0;
            this.tabOrderGubun.SelectedTab = this.tabPage5;
            this.tabOrderGubun.ShowClose = false;
            this.tabOrderGubun.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage5});
            this.tabOrderGubun.SelectionChanged += new System.EventHandler(this.tabOrderGubun_SelectionChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.AccessibleDescription = null;
            this.tabPage5.AccessibleName = null;
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.BackgroundImage = null;
            this.tabPage5.Font = null;
            this.tabPage5.ImageIndex = 0;
            this.tabPage5.ImageList = this.ImageList;
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Tag = "4";
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.rbtIn);
            this.xPanel6.Controls.Add(this.rbtOut);
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
            // 
            // rbtIn
            // 
            this.rbtIn.AccessibleDescription = null;
            this.rbtIn.AccessibleName = null;
            resources.ApplyResources(this.rbtIn, "rbtIn");
            this.rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtIn.BackgroundImage = null;
            this.rbtIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtIn.ImageList = this.ImageList;
            this.rbtIn.Name = "rbtIn";
            this.rbtIn.UseVisualStyleBackColor = false;
            // 
            // rbtOut
            // 
            this.rbtOut.AccessibleDescription = null;
            this.rbtOut.AccessibleName = null;
            resources.ApplyResources(this.rbtOut, "rbtOut");
            this.rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtOut.BackgroundImage = null;
            this.rbtOut.Checked = true;
            this.rbtOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbtOut.ImageList = this.ImageList;
            this.rbtOut.Name = "rbtOut";
            this.rbtOut.TabStop = true;
            this.rbtOut.UseVisualStyleBackColor = false;
            this.rbtOut.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "order_gubun";
            this.xEditGridCell151.Col = -1;
            this.xEditGridCell151.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell151, "xEditGridCell151");
            this.xEditGridCell151.IsUpdatable = false;
            this.xEditGridCell151.IsVisible = false;
            this.xEditGridCell151.Row = -1;
            // 
            // pnlSang
            // 
            this.pnlSang.AccessibleDescription = null;
            this.pnlSang.AccessibleName = null;
            this.pnlSang.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.pnlSang, "pnlSang");
            this.pnlSang.BackgroundImage = null;
            this.pnlSang.Controls.Add(this.grdSangInfo);
            this.pnlSang.Controls.Add(this.lblSelectSang);
            this.pnlSang.Font = null;
            this.pnlSang.Name = "pnlSang";
            // 
            // grdSangInfo
            // 
            resources.ApplyResources(this.grdSangInfo, "grdSangInfo");
            this.grdSangInfo.ApplyPaintEventToAllColumn = true;
            this.grdSangInfo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell31,
            this.xEditGridCell125,
            this.xEditGridCell12,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell29,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell130,
            this.xEditGridCell18,
            this.xEditGridCell126,
            this.xEditGridCell103,
            this.xEditGridCell104,
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
            this.xEditGridCell28,
            this.xEditGridCell98});
            this.grdSangInfo.ColPerLine = 8;
            this.grdSangInfo.Cols = 9;
            this.grdSangInfo.EnableMultiSelection = true;
            this.grdSangInfo.ExecuteQuery = null;
            this.grdSangInfo.FixedCols = 1;
            this.grdSangInfo.FixedRows = 1;
            this.grdSangInfo.HeaderHeights.Add(26);
            this.grdSangInfo.MasterLayout = this.grdOrderDateList;
            this.grdSangInfo.Name = "grdSangInfo";
            this.grdSangInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSangInfo.ParamList")));
            this.grdSangInfo.QuerySQL = resources.GetString("grdSangInfo.QuerySQL");
            this.grdSangInfo.ReadOnly = true;
            this.grdSangInfo.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdSangInfo.RowHeaderVisible = true;
            this.grdSangInfo.Rows = 2;
            this.grdSangInfo.RowStateCheckOnPaint = false;
            this.grdSangInfo.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdSangInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSangInfo_QueryStarting);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.CellName = "ju_sang_yn";
            this.xEditGridCell10.CellWidth = 42;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.ImageList = this.ImageList;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.CellName = "sang_code";
            this.xEditGridCell11.CellWidth = 131;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.ImageList = this.ImageList;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "gwa_name";
            this.xEditGridCell31.Col = 2;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.IsUpdCol = false;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "ser";
            this.xEditGridCell125.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsUpdatable = false;
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.CellName = "display_sang_name";
            this.xEditGridCell12.CellWidth = 323;
            this.xEditGridCell12.Col = 4;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.ImageList = this.ImageList;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell99.CellName = "sang_start_date";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell99.CellWidth = 97;
            this.xEditGridCell99.Col = 5;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell99.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.CellName = "sang_end_date";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell100.CellWidth = 95;
            this.xEditGridCell100.Col = 7;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell101.CellName = "sang_end_sayu_name";
            this.xEditGridCell101.CellWidth = 114;
            this.xEditGridCell101.Col = 8;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.HeaderImageStretch = true;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsUpdatable = false;
            this.xEditGridCell101.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell101.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "sang_end_sayu";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "bunho";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "naewon_date";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "gwa";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "doctor";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "naewon_type";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "jubsu_no";
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.IsUpdatable = false;
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "pk_order";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "sang_name";
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsUpdatable = false;
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "pre_modifier1";
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsUpdatable = false;
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "pre_modifier2";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsUpdatable = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "pre_modifier3";
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsUpdatable = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "pre_modifier4";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsUpdatable = false;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "pre_modifier5";
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "pre_modifier6";
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "pre_modifier7";
            this.xEditGridCell109.Col = -1;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "pre_modifier8";
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "pre_modifier9";
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsUpdatable = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "pre_modifier10";
            this.xEditGridCell112.Col = -1;
            this.xEditGridCell112.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "pre_modifier_name";
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "post_modifier1";
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsUpdatable = false;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "post_modifier2";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "post_modifier3";
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsUpdatable = false;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "post_modifier4";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "post_modifier5";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsUpdatable = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "post_modifier6";
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsUpdatable = false;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "post_modifier7";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "post_modifier8";
            this.xEditGridCell121.Col = -1;
            this.xEditGridCell121.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsUpdatable = false;
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "post_modifier9";
            this.xEditGridCell122.Col = -1;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.IsVisible = false;
            this.xEditGridCell122.Row = -1;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "post_modifier10";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsUpdatable = false;
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "post_modifier_name";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "sang_jindan_date";
            this.xEditGridCell28.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell28.CellWidth = 106;
            this.xEditGridCell28.Col = 6;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdatable = false;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "bulyong_check";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsUpdatable = false;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // lblSelectSang
            // 
            this.lblSelectSang.AccessibleDescription = null;
            this.lblSelectSang.AccessibleName = null;
            resources.ApplyResources(this.lblSelectSang, "lblSelectSang");
            this.lblSelectSang.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectSang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectSang.Font = null;
            this.lblSelectSang.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectSang.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectSang.Image = null;
            this.lblSelectSang.ImageList = this.ImageList;
            this.lblSelectSang.Name = "lblSelectSang";
            // 
            // pnlOrder
            // 
            this.pnlOrder.AccessibleDescription = null;
            this.pnlOrder.AccessibleName = null;
            this.pnlOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.pnlOrder, "pnlOrder");
            this.pnlOrder.BackgroundImage = null;
            this.pnlOrder.Controls.Add(this.grdOrderInfo);
            this.pnlOrder.Controls.Add(this.txtDrg_info);
            this.pnlOrder.Controls.Add(this.lblSelectOrder);
            this.pnlOrder.Font = null;
            this.pnlOrder.Name = "pnlOrder";
            // 
            // grdOrderInfo
            // 
            this.grdOrderInfo.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOrderInfo, "grdOrderInfo");
            this.grdOrderInfo.ApplyPaintEventToAllColumn = true;
            this.grdOrderInfo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell19,
            this.xEditGridCell102,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell23,
            this.xEditGridCell135,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell30,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell158,
            this.xEditGridCell42,
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
            this.xEditGridCell59,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell94,
            this.xEditGridCell68,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell142,
            this.xEditGridCell145,
            this.xEditGridCell146,
            this.xEditGridCell160,
            this.xEditGridCell161,
            this.xEditGridCell149,
            this.xEditGridCell147,
            this.xEditGridCell148,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell128,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell132,
            this.xEditGridCell150,
            this.xEditGridCell143,
            this.xEditGridCell162,
            this.xEditGridCell163,
            this.xEditGridCell165,
            this.xEditGridCell166,
            this.xEditGridCell167,
            this.xEditGridCell22});
            this.grdOrderInfo.ColPerLine = 18;
            this.grdOrderInfo.Cols = 19;
            this.grdOrderInfo.ControlBinding = true;
            this.grdOrderInfo.ExecuteQuery = null;
            this.grdOrderInfo.FixedCols = 1;
            this.grdOrderInfo.FixedRows = 2;
            this.grdOrderInfo.HeaderHeights.Add(39);
            this.grdOrderInfo.HeaderHeights.Add(1);
            this.grdOrderInfo.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOrderInfo.MasterLayout = this.grdOrderDateList;
            this.grdOrderInfo.Name = "grdOrderInfo";
            this.grdOrderInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderInfo.ParamList")));
            this.grdOrderInfo.QuerySQL = resources.GetString("grdOrderInfo.QuerySQL");
            this.grdOrderInfo.ReadOnly = true;
            this.grdOrderInfo.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOrderInfo.RowHeaderVisible = true;
            this.grdOrderInfo.Rows = 3;
            this.grdOrderInfo.RowStateCheckOnPaint = false;
            this.grdOrderInfo.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrderInfo.ToolTipActive = true;
            this.grdOrderInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOrderInfo_QueryEnd);
            this.grdOrderInfo.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrderInfo_RowFocusChanged);
            this.grdOrderInfo.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrderInfo_GridCellPainting);
            this.grdOrderInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderInfo_QueryStarting);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellName = "input_gubun_name";
            this.xEditGridCell4.CellWidth = 66;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.CellName = "group_ser";
            this.xEditGridCell19.CellWidth = 34;
            this.xEditGridCell19.Col = 4;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.CellName = "order_gubun_name";
            this.xEditGridCell102.CellWidth = 65;
            this.xEditGridCell102.Col = 3;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell102.SuppressRepeating = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.CellWidth = 74;
            this.xEditGridCell20.Col = 6;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 252;
            this.xEditGridCell21.Col = 7;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.CellName = "suryang";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell23.CellWidth = 61;
            this.xEditGridCell23.Col = 10;
            this.xEditGridCell23.DecimalDigits = 3;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
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
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellName = "ord_danui_name";
            this.xEditGridCell24.CellWidth = 76;
            this.xEditGridCell24.Col = 11;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.RowSpan = 2;
            this.xEditGridCell24.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellName = "dv_time";
            this.xEditGridCell25.CellWidth = 21;
            this.xEditGridCell25.Col = 12;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.Row = 1;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellName = "dv";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell26.CellWidth = 30;
            this.xEditGridCell26.Col = 13;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellName = "nalsu";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell27.CellWidth = 56;
            this.xEditGridCell27.Col = 14;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellName = "wonyoi_order_yn";
            this.xEditGridCell30.CellWidth = 59;
            this.xEditGridCell30.Col = 16;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 68;
            this.xEditGridCell32.Col = 15;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellName = "pay";
            this.xEditGridCell33.CellWidth = 35;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.CellName = "anti_cancer_yn";
            this.xEditGridCell36.CellWidth = 45;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "muhyo";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.CellName = "portable_yn";
            this.xEditGridCell38.CellWidth = 61;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
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
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellName = "input_tab";
            this.xEditGridCell158.Col = -1;
            this.xEditGridCell158.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell158, "xEditGridCell158");
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "input_gubun";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "after_act_yn";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "jundal_table";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
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
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "move_part";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
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
            this.xEditGridCell48.CellName = "naewon_date";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
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
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "naewon_type";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "pk_order";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
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
            this.xEditGridCell54.CellName = "pkocs1003";
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
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "sutak_yn";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "amt";
            this.xEditGridCell59.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "dv_1";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "dv_2";
            this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "dv_3";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "dv_4";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.CellName = "order_remark";
            this.xEditGridCell94.Col = 17;
            this.xEditGridCell94.DisplayMemoText = true;
            this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.RowSpan = 2;
            this.xEditGridCell94.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "mix_group";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "jubsu_date";
            this.xEditGridCell95.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsUpdatable = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "acting_date";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell96.CellWidth = 98;
            this.xEditGridCell96.Col = 8;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsUpdatable = false;
            this.xEditGridCell96.RowSpan = 2;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "result_date";
            this.xEditGridCell97.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsUpdatable = false;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell142.CellName = "dc_gubun";
            this.xEditGridCell142.CellWidth = 64;
            this.xEditGridCell142.Col = 5;
            this.xEditGridCell142.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell142.ExecuteQuery = null;
            this.xEditGridCell142.HeaderForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsUpdatable = false;
            this.xEditGridCell142.RowSpan = 2;
            this.xEditGridCell142.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell142.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "dc_yn";
            this.xEditGridCell145.Col = -1;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.IsVisible = false;
            this.xEditGridCell145.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "bannab_yn";
            this.xEditGridCell146.Col = -1;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.IsVisible = false;
            this.xEditGridCell146.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "donbog_yn";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell160, "xEditGridCell160");
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellName = "dv_name";
            this.xEditGridCell161.Col = -1;
            this.xEditGridCell161.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell161, "xEditGridCell161");
            this.xEditGridCell161.IsVisible = false;
            this.xEditGridCell161.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "confirm_check";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "sunab_check";
            this.xEditGridCell147.Col = -1;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.IsVisible = false;
            this.xEditGridCell147.Row = -1;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "dc_check";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsUpdatable = false;
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "slip_code";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "group_yn";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "sg_code";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "order_gubun_bas";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "input_control";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "suga_yn";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "emergency_check";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "limit_suryang";
            this.xEditGridCell80.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "specimen_yn";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "jaeryo_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "ord_danui_check";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "ord_danui_bas";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "jundal_table_out";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "jundal_part_out";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "bulyong_check";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "nday_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "muhyo_yn";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "tel_yn";
            this.xEditGridCell132.Col = -1;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell150.CellName = "jundal_part_name";
            this.xEditGridCell150.CellWidth = 92;
            this.xEditGridCell150.Col = 18;
            this.xEditGridCell150.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell150, "xEditGridCell150");
            this.xEditGridCell150.IsUpdatable = false;
            this.xEditGridCell150.RowSpan = 2;
            this.xEditGridCell150.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell150.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "bun_code";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.BindControl = this.txtDrg_info;
            this.xEditGridCell162.CellName = "drg_info";
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell162, "xEditGridCell162");
            this.xEditGridCell162.IsReadOnly = true;
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsUpdCol = false;
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // txtDrg_info
            // 
            this.txtDrg_info.AccessibleDescription = null;
            this.txtDrg_info.AccessibleName = null;
            resources.ApplyResources(this.txtDrg_info, "txtDrg_info");
            this.txtDrg_info.BackgroundImage = null;
            this.txtDrg_info.Font = null;
            this.txtDrg_info.Name = "txtDrg_info";
            this.txtDrg_info.Protect = true;
            this.txtDrg_info.ReadOnly = true;
            this.txtDrg_info.TabStop = false;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellName = "drg_bunryu";
            this.xEditGridCell163.Col = -1;
            this.xEditGridCell163.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell163, "xEditGridCell163");
            this.xEditGridCell163.IsReadOnly = true;
            this.xEditGridCell163.IsUpdatable = false;
            this.xEditGridCell163.IsUpdCol = false;
            this.xEditGridCell163.IsVisible = false;
            this.xEditGridCell163.Row = -1;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell165.CellName = "child_gubun";
            this.xEditGridCell165.CellWidth = 25;
            this.xEditGridCell165.Col = 1;
            this.xEditGridCell165.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell165, "xEditGridCell165");
            this.xEditGridCell165.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell165.RowSpan = 2;
            this.xEditGridCell165.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellName = "bom_source_key";
            this.xEditGridCell166.Col = -1;
            this.xEditGridCell166.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell166, "xEditGridCell166");
            this.xEditGridCell166.IsVisible = false;
            this.xEditGridCell166.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "bom_occur_yn";
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell167, "xEditGridCell167");
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "acting_itme";
            this.xEditGridCell22.CellWidth = 123;
            this.xEditGridCell22.Col = 9;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.Mask = "##:##";
            this.xEditGridCell22.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 12;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 21;
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // lblSelectOrder
            // 
            this.lblSelectOrder.AccessibleDescription = null;
            this.lblSelectOrder.AccessibleName = null;
            resources.ApplyResources(this.lblSelectOrder, "lblSelectOrder");
            this.lblSelectOrder.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectOrder.Font = null;
            this.lblSelectOrder.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectOrder.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectOrder.Image = null;
            this.lblSelectOrder.ImageList = this.ImageList;
            this.lblSelectOrder.Name = "lblSelectOrder";
            // 
            // sptMid
            // 
            this.sptMid.AccessibleDescription = null;
            this.sptMid.AccessibleName = null;
            resources.ApplyResources(this.sptMid, "sptMid");
            this.sptMid.BackgroundImage = null;
            this.sptMid.Font = null;
            this.sptMid.Name = "sptMid";
            this.sptMid.TabStop = false;
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "");
            this.imageListMixGroup.Images.SetKeyName(1, "");
            this.imageListMixGroup.Images.SetKeyName(2, "");
            this.imageListMixGroup.Images.SetKeyName(3, "");
            this.imageListMixGroup.Images.SetKeyName(4, "");
            this.imageListMixGroup.Images.SetKeyName(5, "");
            this.imageListMixGroup.Images.SetKeyName(6, "");
            this.imageListMixGroup.Images.SetKeyName(7, "");
            this.imageListMixGroup.Images.SetKeyName(8, "");
            this.imageListMixGroup.Images.SetKeyName(9, "");
            this.imageListMixGroup.Images.SetKeyName(10, "");
            this.imageListMixGroup.Images.SetKeyName(11, "");
            this.imageListMixGroup.Images.SetKeyName(12, "");
            this.imageListMixGroup.Images.SetKeyName(13, "");
            this.imageListMixGroup.Images.SetKeyName(14, "");
            this.imageListMixGroup.Images.SetKeyName(15, "");
            this.imageListMixGroup.Images.SetKeyName(16, "");
            this.imageListMixGroup.Images.SetKeyName(17, "");
            this.imageListMixGroup.Images.SetKeyName(18, "");
            this.imageListMixGroup.Images.SetKeyName(19, "");
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnCopy);
            this.xPanel2.Controls.Add(this.btnHealthQuestionnair);
            this.xPanel2.Controls.Add(this.btnIraisyo);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleDescription = null;
            this.btnCopy.AccessibleName = null;
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.BackgroundImage = null;
            this.btnCopy.Font = null;
            this.btnCopy.Image = global::IHIS.OCSA.Properties.Resources.복사;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnHealthQuestionnair
            // 
            this.btnHealthQuestionnair.AccessibleDescription = null;
            this.btnHealthQuestionnair.AccessibleName = null;
            resources.ApplyResources(this.btnHealthQuestionnair, "btnHealthQuestionnair");
            this.btnHealthQuestionnair.BackgroundImage = null;
            this.btnHealthQuestionnair.Font = null;
            this.btnHealthQuestionnair.Image = global::IHIS.OCSA.Properties.Resources.printPreview;
            this.btnHealthQuestionnair.Name = "btnHealthQuestionnair";
            this.btnHealthQuestionnair.Click += new System.EventHandler(this.btnHealthQuestionnair_Click);
            // 
            // btnIraisyo
            // 
            this.btnIraisyo.AccessibleDescription = null;
            this.btnIraisyo.AccessibleName = null;
            resources.ApplyResources(this.btnIraisyo, "btnIraisyo");
            this.btnIraisyo.BackgroundImage = null;
            this.btnIraisyo.Font = null;
            this.btnIraisyo.Image = global::IHIS.OCSA.Properties.Resources.printPreview;
            this.btnIraisyo.Name = "btnIraisyo";
            this.btnIraisyo.Click += new System.EventHandler(this.btnIraisyo_Click);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "io_gubun";
            this.xEditGridCell58.Col = 8;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            // 
            // pnlImage
            // 
            this.pnlImage.AccessibleDescription = null;
            this.pnlImage.AccessibleName = null;
            resources.ApplyResources(this.pnlImage, "pnlImage");
            this.pnlImage.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.WhiteSmoke);
            this.pnlImage.BackgroundImage = null;
            this.pnlImage.Controls.Add(this.btnRotateL);
            this.pnlImage.Controls.Add(this.btnRotateR);
            this.pnlImage.Controls.Add(this.pbxImage);
            this.pnlImage.Font = null;
            this.pnlImage.Name = "pnlImage";
            // 
            // btnRotateL
            // 
            this.btnRotateL.AccessibleDescription = null;
            this.btnRotateL.AccessibleName = null;
            resources.ApplyResources(this.btnRotateL, "btnRotateL");
            this.btnRotateL.BackgroundImage = null;
            this.btnRotateL.Font = null;
            this.btnRotateL.Name = "btnRotateL";
            // 
            // btnRotateR
            // 
            this.btnRotateR.AccessibleDescription = null;
            this.btnRotateR.AccessibleName = null;
            resources.ApplyResources(this.btnRotateR, "btnRotateR");
            this.btnRotateR.BackgroundImage = null;
            this.btnRotateR.Font = null;
            this.btnRotateR.Name = "btnRotateR";
            // 
            // pbxImage
            // 
            this.pbxImage.AccessibleDescription = null;
            this.pbxImage.AccessibleName = null;
            resources.ApplyResources(this.pbxImage, "pbxImage");
            this.pbxImage.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pbxImage.BackgroundImage = null;
            this.pbxImage.Font = null;
            this.pbxImage.ImageLocation = null;
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Protect = false;
            this.pbxImage.TabStop = false;
            // 
            // OCS3003Q10
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.pnlSang);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.sptMid);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "OCS3003Q10";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS3003Q10_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS3003Q10_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderDateList)).EndInit();
            this.tabOrderGubun.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            this.pnlSang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSangInfo)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
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
			// 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
			if ( this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed )
			{
				Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;			
				this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 105);
			}	

			//comboBox생성
			CreateCombo();

			//grd Setting [외래]
			//입력구분
			//ntt
			grdOrderInfo.AutoSizeColumn(2, 0);
			//반납지시
			grdOrderInfo.AutoSizeColumn(5, 0);

            grdOrderDateList.SetBindVarValue("f_io_gubun", "O");
            grdOrderDateList.SetBindVarValue("f_order_gubun", tabOrderGubun.SelectedTab.Tag.ToString());

			mOrder_date = IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

			//input gubun 설정
            if (IHIS.Framework.UserInfo.UserGubun.ToString() == "Doctor")      //의사
                mInputGubun = "D%";
            else if (IHIS.Framework.UserInfo.UserGubun.ToString() == "Nurse") //간호사
                mInputGubun = "NR";
            else                                                         //그외의 유저
                //mInputGubun = OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items["input_gubun"].ToString();
                mInputGubun = UserInfo.InputGubun;
			
			base.OnLoad (e);
		}

		private void OCS3003Q10_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            // 각종 변수 초기화
            this.mSelectedPatientInfo = new IHIS.OCS.PatientInfo(this.Name);  // 환자정보 
                     
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
						mBunho = OpenParam["bunho"].ToString().Trim();

				    
					if(OpenParam.Contains("order_date"))
					{
						if(TypeCheck.IsDateTime(OpenParam["order_date"].ToString()))
							mOrder_date = OpenParam["order_date"].ToString();
					}

                    if (OpenParam.Contains("io_gubun"))
                        mIO_GUBUN = OpenParam["io_gubun"].ToString();

                    if (OpenParam.Contains("irai_kubun"))
                        mIraiKubun = OpenParam["irai_kubun"].ToString();
					
				}
				catch (Exception ex)
				{
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");	
					this.Close();
				}
			}
            InitialDesign();

			dpkOrder_date.SetDataValue(mOrder_date);
			
			PostCallHelper.PostCall(new PostMethod(PostLoad));			
		
		}

        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>
        private void InitialDesign()
        {
            //this.grdOrderInfo.FixedCols = 9;
        }

		private void PostLoad()
		{			
		
			if(TypeCheck.IsNull(mBunho))
			{
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

				if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
				{
					// 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
					patientInfo = XScreen.GetOtherScreenBunHo(this, true);
				}

				if (patientInfo != null)
				{
					this.pbxSearch.SetPatientID(patientInfo.BunHo);					
				}
			}
			else
				this.pbxSearch.SetPatientID(mBunho);		
			

			if(EnvironInfo.CurrSystemID == "OCSI" ||
			   EnvironInfo.CurrSystemID == "NURI" )
				rbtIn.Checked = true;
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
				this.mBunho = info.BunHo;
				this.pbxSearch.Focus();
				this.pbxSearch.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
			{
				return new XPatientInfo(this.pbxSearch.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion 

		#region [Combo 생성]
		
		private void CreateCombo()
		{
			// Combo 세팅
			DataTable dtTemp = null;

			//주사
			dtTemp = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
			this.grdOrderInfo.SetComboItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);

			//급여여부
			dtTemp = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
			this.grdOrderInfo.SetComboItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);

			// 이동촬영여부
			dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
			this.grdOrderInfo.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

			// 주사스피드구분
//			dtTemp = this.mOrderBiz.LoadComboDataSource("jusa_spd_gubun").LayoutTable;
//			this.grdOrderInfo.SetListItems("jusa_spd_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);

		}
		#endregion
    
		#region [ButtonList]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process:

					break;

				case FunctionType.Print:

					OrderInfoPrint();

					break;


				default:

					break;
			}			
		}

		#endregion

		#region [grdOrderInfo Event]
		

		private void grdOrderInfo_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;			

			if (e.CurrentRow >= 0) 
			{				
				// 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
				this.mHangmogInfo.DisplaySpecialColHeader("O", grd, e.CurrentRow, grd.GetItemString(e.CurrentRow, "hangmog_code"));
			}		
		}

		private void grdOrderInfo_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			string io_gubun = "";
			if( rbtOut.Checked )
				io_gubun = "O";
			else
				io_gubun = "I";

			
			this.mHangmogInfo.ColumnColorForOrderState(io_gubun, grdOrderInfo, e); // 처방상태에 따른 색상 처리

            if (e.ColName == "bogyong_name")
            {
                // 불균등분할
                if (!TypeCheck.IsNull(grdOrderInfo.GetItemString(e.RowNumber, "dv_name")))
                    e.BackColor = System.Drawing.Color.LightCyan;

                // 돈복여부
                if (grdOrderInfo.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                    e.BackColor = System.Drawing.Color.Beige;
            }
            else if (e.ColName == "child_gubun")
            {
                e.ForeColor = Color.Transparent;
            }

			#region 코드만 화면 Display하는 필드를 명칭으로 ToolTip 처리
			switch (e.ColName)
			{
				case "bogyong_name": // 용법코드
					grdOrderInfo[e.RowNumber, e.ColName].ToolTipText = grdOrderInfo.GetItemString(e.RowNumber, "bogyong_name") + " " + grdOrderInfo.GetItemString(e.RowNumber, "dv_name") ;
					break;
			
							
			}
			#endregion
		
		}


		#endregion

		#region 환자번호입력시
		private void pbxSearch_PatientSelected(object sender, System.EventArgs e)
		{
			ControlClear();

			if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
				LoadData();
		}

		private void pbxSearch_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			ControlClear();
		}

		private void dpkOrder_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			LoadData();
		}
		
		#endregion

		#region [Data Load]

		private void LoadData()
		{
			if(!TypeCheck.IsDateTime(dpkOrder_date.GetDataValue()))
			{
				mbxMsg = Resources.MSG001_MSG;
				mbxCap = "";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				ControlClear();

				dpkOrder_date.Focus();
				return;
			}
			
			try
			{	
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				SetMsg("");

                if (!grdOrderDateList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
			}
			finally
			{
				SetMsg(" ");
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}
	
		#endregion

		#region [Function]
        
		/// <summary>
		/// Control정보 Reset
		/// </summary>
		private void ControlClear()
		{
			this.grdOrderInfo.Reset();
			this.grdSangInfo.Reset();
			this.grdOrderDateList.Reset();
		}

//        private string GetQueryString(string aIOGubun)
//        {
//            string querySql = "";

//            if (aIOGubun == "O")
//            {
//                querySql = @"
//                       SELECT /* WorkTP 3 */
//                       ''                                                         INPUT_GUBUN_NAME        ,
//                       A.GROUP_SER                                                GROUP_SER               ,
//                       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
//                       A.HANGMOG_CODE                                             HANGMOG_CODE            ,
//                       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
//                              THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
//                              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
//                       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
//                       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
//                       A.SURYANG                                                  SURYANG                 ,
//                       A.ORD_DANUI                                                ORD_DANUI               ,
//                       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
//                       A.DV_TIME                                                  DV_TIME                 ,
//                       A.DV                                                       DV                      ,
//                       A.NALSU                                                    NALSU                   ,
//                       A.JUSA                                                     JUSA                    ,
//                       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
//                       A.BOGYONG_CODE                                             BOGYONG_CODE            ,
//                       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
//                                                                                  BOGYONG_NAME            ,
//                       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
//                       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
//                       A.PHARMACY                                                 PHARMACY                ,
//                       A.DRG_PACK_YN                                              DRG_PACK_YN             ,
//                       A.POWDER_YN                                                POWDER_YN               ,
//                       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
//                --       A.WONNAE_SAYU_CODE                                         WONNAE_SAYU_CODE        ,
//                       NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN   ,
//                       NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                         DANGIL_GUMSA_RESULT_YN  ,
//                       NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
//                       A.PAY                                                      PAY                     ,
//                --       A.FLUID_YN                                                 FLUID_YN                ,
//                --       A.TPN_YN                                                   TPN_YN                  ,
//                       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
//                       A.MUHYO                                                    MUHYO                   ,
//                       A.PORTABLE_YN                                              PORTABLE_YN             ,
//                --       A.SYMYA                                                    SYMYA                   ,
//                       A.OCS_FLAG                                                 OCS_FLAG                ,
//                       A.ORDER_GUBUN                                              ORDER_GUBUN             ,
//                       A.INPUT_TAB                                                INPUT_TAB               ,
//                       A.INPUT_GUBUN                                              INPUT_GUBUN             ,
//                       A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,
//                       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
//                       A.JUNDAL_PART                                              JUNDAL_PART             ,
//                       A.MOVE_PART                                                MOVE_PART               ,
//                       A.BUNHO                                                    BUNHO                   ,
//                       A.ORDER_DATE                                               NAEWON_DATE             ,
//                       A.GWA                                                      GWA                     ,
//                       A.DOCTOR                                                   DOCTOR                  ,
//                       A.NAEWON_TYPE                                              NAEWON_TYPE             ,
//                --       A.JUBSU_NO                                                 JUBSU_NO                ,
//                       A.FKOUT1001                                                PK_ORDER                ,
//                       A.SEQ                                                      SEQ                     ,
//                       A.PKOCS1003                                                PKOCS1003               ,
//                       A.SUB_SUSUL                                                SUB_SUSUL               ,
//                       A.SUTAK_YN                                                 SUTAK_YN                ,
//                --       A.SANG_CODE                                                SANG_CODE               ,
//                --       A.SYMYA_TIME                                               SYMYA_TIME              ,
//                       A.AMT                                                      AMT                     ,
//                --       A.NALSU_SAYU_CODE                                          NALSU_SAYU_CODE         ,
//                --       A.PHYSICAL_CODE                                            PHYSICAL_CODE           ,
//                --       A.NDAY_NALSU                                               NDAY_NALSU              ,
//                --       A.NDAY_SUNAB                                               NDAY_SUNAB              ,
//                       A.DV_1                                                     DV_1                    ,
//                       A.DV_2                                                     DV_2                    ,
//                       A.DV_3                                                     DV_3                    ,
//                       A.DV_4                                                     DV_4                    ,
//                --       A.DV_5                                                     DV_5                    ,
//                       A.HOPE_DATE                                                HOPE_DATE               ,
//                       A.ORDER_REMARK                                             ORDER_REMARK            ,
//                       A.MIX_GROUP                                                MIX_GROUP               ,
//                       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
//                       A.RESER_DATE                                               RESER_DATE              ,
//                       A.JUBSU_DATE                                               JUBSU_DATE              ,
//                       A.ACTING_DATE                                              ACTING_DATE             ,
//                       A.RESULT_DATE                                              RESULT_DATE             ,
//                       A.DC_GUBUN                                                 DC_GUBUN                ,
//                       A.DC_YN                                                    DC_YN                   ,
//                       A.BANNAB_YN                                                BANNAB_YN               ,
//                       DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
//                                                                                  DONBOK_YN               ,
//                       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4)  DV_NAME                 ,
//                       DECODE(A.NURSE_CONFIRM_DATE, NULL, 'N','Y')                CONFIRM_CHECK           ,
//                       DECODE(A.SUNAB_DATE, NULL, 'N','Y')                        SUNAB_CHECK             ,
//                       DECODE(SIGN(A.NALSU),1,'N',0,'N','Y')                      DC_CHECK                ,
//                       B.SLIP_CODE                                                SLIP_CODE               ,
//                       B.GROUP_YN                                                 GROUP_YN                ,
//                       B.SG_CODE                                                  SG_CODE                 ,
//                       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
//                       B.INPUT_CONTROL                                            INPUT_CONTROL           ,
//                --       B.PRIS_NAME                                                PRIS_NAME               ,
//                --       B.KYUKYEOK                                                 KYUKYEOK                ,
//                       NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
//                       DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
//                --       NVL(B.MULTI_GUMSA_YN,'N')                                  MULTI_GUMSA_YN          ,
//                --       NVL(B.SPECIAL_YN,'N')                                      SPECIAL_CHECK           ,
//                       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
//                       NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
//                       NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
//                       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
//                       B.ORD_DANUI                                                ORD_DANUI_BAS           ,
//                       B.JUNDAL_TABLE_OUT                                         JUNDAL_TABLE_OUT        ,
//                       B.JUNDAL_PART_OUT                                          JUNDAL_PART_OUT         ,
//                --       NVL(B.PORTABLE_YN,'N')                                     PORTABLE_CR_YN          ,
//                       FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
//                       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
//                       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
//                --       B.WONNAE_SAYU_CODE                                         DEFAULT_WONNAE_SAYU_CODE,
//                --       B.SPECIAL_CODE                                             SPECIAL_CODE            ,
//                       NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
//                       NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
//                       NVL(A.TEL_YN, 'N')                                         TEL_YN                  ,
//                       FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE)          JUNDAL_PART_NAME        ,
//                       E.BUN_CODE                                                 BUN_CODE                ,
//                --       E.SG_GESAN                                                 SG_GESAN                ,
//                       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
//                       ''                                                         DRG_BUNRYU              ,             
//                       DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('O',A.PKOCS1003),'3')      CHILD_GUBUN,
//                       A.BOM_SOURCE_KEY                                           BOM_SOURCE_KEY,
//                       A.BOM_OCCUR_YN                                             BOM_OCCUR_YN,
//                       TO_CHAR(A.GROUP_SER, '00000000000')
//                    || TO_CHAR(CASE WHEN A.SOURCE_FKOCS1003 IS NOT NULL THEN A.SOURCE_FKOCS1003 
//                                    WHEN A.BOM_SOURCE_KEY IS NULL THEN A.PKOCS1003
//                                    ELSE A.BOM_SOURCE_KEY END )
//                    || A.PKOCS1003                                                CONT_KEY 
//                  FROM ( SELECT A.SG_CODE
//                              , A.SG_NAME
//                              , A.BUN_CODE
//                              , A.HOSP_CODE
//                           FROM BAS0310 A
//                          WHERE A.SG_YMD = ( SELECT MAX(Z.SG_YMD)
//                                               FROM BAS0310 Z
//                                              WHERE Z.SG_CODE = A.SG_CODE
//                                                AND Z.SG_YMD <= :f_naewon_date )
//                       ) E,
//                       OCS0116 D,
//                       OCS0132 C,
//                       OCS0103 B,
//                       OCS1003 A
//                 WHERE :f_io_gubun = 'O'
//                   AND A.FKOUT1001 = :f_pk_order
//                   AND ( ( :f_order_gubun = '%'           ) OR
//                         ( :f_order_gubun = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('C', 'D') ) OR
//                         ( :f_order_gubun = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B') ) OR
//                         ( :f_order_gubun = '3' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E') ) )
//                   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
//                   AND B.HOSP_CODE        = A.HOSP_CODE
//                   AND C.CODE     (+)     = SUBSTR(A.ORDER_GUBUN, 2, 1)
//                   AND C.CODE_TYPE(+)     = 'ORDER_GUBUN_BAS'
//                   AND C.HOSP_CODE(+)     = A.HOSP_CODE
//                   AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
//                   AND D.HOSP_CODE(+)     = A.HOSP_CODE
//                   AND E.SG_CODE  (+)     = B.SG_CODE
//                   AND E.HOSP_CODE(+)     = B.HOSP_CODE
//                 ORDER BY 97";
//            }
//            else
//            {
//                querySql = @"
//                   SELECT /*+ rule */
//                   F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
//                   A.GROUP_SER                                                GROUP_SER               ,
//                   NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
//                   A.HANGMOG_CODE                                             HANGMOG_CODE            ,
//                   ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
//                          THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
//                          ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
//                   A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
//                   D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
//                   A.SURYANG                                                  SURYANG                 ,
//                   A.ORD_DANUI                                                ORD_DANUI               ,
//                   FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
//                   A.DV_TIME                                                  DV_TIME                 ,
//                   A.DV                                                       DV                      ,
//                   A.NALSU                                                    NALSU                   ,
//                   A.JUSA                                                     JUSA                    ,
//                   FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
//                   A.BOGYONG_CODE                                             BOGYONG_CODE            ,
//                   FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
//                                                                              BOGYONG_NAME            ,
//                   A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
//                   A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
//                   A.PHARMACY                                                 PHARMACY                ,
//                   A.DRG_PACK_YN                                              DRG_PACK_YN             ,
//                   A.POWDER_YN                                                POWDER_YN               ,
//                   A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
//            --       A.WONNAE_SAYU_CODE                                         WONNAE_SAYU_CODE        ,
//                   'N'                                                        DANGIL_GUMSA_ORDER_YN   ,
//                   'N'                                                        DANGIL_GUMSA_RESULT_YN  ,
//                   NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
//                   A.PAY                                                      PAY                     ,
//            --       A.FLUID_YN                                                 FLUID_YN                ,
//            --       A.TPN_YN                                                   TPN_YN                  ,
//                   A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
//                   A.MUHYO                                                    MUHYO                   ,
//                   A.PORTABLE_YN                                              PORTABLE_YN             ,
//            --       A.SYMYA                                                    SYMYA                   ,
//                   A.OCS_FLAG                                                 OCS_FLAG                ,
//                   A.ORDER_GUBUN                                              ORDER_GUBUN             ,
//                   A.INPUT_TAB                                                INPUT_TAB               ,
//                   A.INPUT_GUBUN                                              INPUT_GUBUN             ,
//                   'N'                                                        AFTER_ACT_YN            ,
//                   A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
//                   A.JUNDAL_PART                                              JUNDAL_PART             ,
//                   NULL                                                       MOVE_PART               ,
//                   A.BUNHO                                                    BUNHO                   ,
//                   A.ORDER_DATE                                               NAEWON_DATE             ,
//                   A.INPUT_PART                                               GWA                     ,
//                   A.INPUT_ID                                                 DOCTOR                  ,
//                   '0'                                                        NAEWON_TYPE             ,
//            --       A.FKINP1001                                                JUBSU_NO                ,
//                   A.FKINP1001                                                PK_ORDER                ,
//                   A.SEQ                                                      SEQ                     ,
//                   A.PKOCS2003                                                PKOCS1003               ,
//                   A.SUB_SUSUL                                                SUB_SUSUL               ,
//                   NULL                                                       SUTAK_YN                , 
//            --       NULL                                                       SANG_CODE               ,
//            --       A.SYMYA_TIME                                               SYMYA_TIME              ,
//                   A.AMT                                                      AMT                     ,
//            --       A.NALSU_SAYU_CODE                                          NALSU_SAYU_CODE         ,
//            --       A.PHYSICAL_CODE                                            PHYSICAL_CODE           ,
//            --       NULL                                                       NDAY_NALSU              ,
//            --       NULL                                                       NDAY_SUNAB              ,
//                   A.DV_1                                                     DV_1                    ,
//                   A.DV_2                                                     DV_2                    ,
//                   A.DV_3                                                     DV_3                    ,
//                   A.DV_4                                                     DV_4                    ,
//            --       A.DV_5                                                     DV_5                    ,
//                   A.HOPE_DATE                                                HOPE_DATE               ,
//                   A.ORDER_REMARK                                             ORDER_REMARK            ,
//                   A.MIX_GROUP                                                MIX_GROUP               ,
//                   NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
//                   A.RESER_DATE                                               RESER_DATE              ,
//                   A.JUBSU_DATE                                               JUBSU_DATE              ,
//                   A.ACTING_DATE                                              ACTING_DATE             ,
//                   A.RESULT_DATE                                              RESULT_DATE             ,
//                   A.DC_GUBUN                                                 DC_GUBUN                ,
//                   A.DC_YN                                                    DC_YN                   ,
//                   A.BANNAB_YN                                                BANNAB_YN               ,
//                   DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
//                                                                              DONBOK_YN               ,
//                   FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4)  DV_NAME                 ,
//                   DECODE(A.NURSE_CONFIRM_DATE, NULL, 'N','Y')                CONFIRM_CHECK           ,
//                   DECODE(A.SUNAB_DATE, NULL, 'N','Y')                        SUNAB_CHECK             ,
//                   DECODE(SIGN(A.NALSU),1,'N',0,'N','Y')                      DC_CHECK                ,
//                   B.SLIP_CODE                                                SLIP_CODE               ,
//                   B.GROUP_YN                                                 GROUP_YN                ,
//                   B.SG_CODE                                                  SG_CODE                 ,
//                   B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
//                   B.INPUT_CONTROL                                            INPUT_CONTROL           ,
//            --       B.PRIS_NAME                                                PRIS_NAME               ,
//            --       B.KYUKYEOK                                                 KYUKYEOK                ,
//                   NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
//                   DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
//            --       NVL(B.MULTI_GUMSA_YN,'N')                                  MULTI_GUMSA_YN          ,
//            --       NVL(B.SPECIAL_YN,'N')                                      SPECIAL_CHECK           ,
//                   B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
//                   NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
//                   NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
//                   DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
//                   B.ORD_DANUI                                                ORD_DANUI_BAS           ,
//                   B.JUNDAL_TABLE_OUT                                         JUNDAL_TABLE_OUT        ,
//                   B.JUNDAL_PART_OUT                                          JUNDAL_PART_OUT         ,
//            --       NVL(B.PORTABLE_YN,'N')                                     PORTABLE_CR_YN          ,
//                   FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
//                   FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
//                   B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
//            --       B.WONNAE_SAYU_CODE                                         DEFAULT_WONNAE_SAYU_CODE,
//            --       B.SPECIAL_CODE                                             SPECIAL_CODE            ,
//                   NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
//                   NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
//                   NVL(A.TEL_YN, 'N')                                         TEL_YN                  ,
//                   FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE )         JUNDAL_PART_NAME        ,
//                   E.BUN_CODE                                                 BUN_CODE                ,
//            --       E.SG_GESAN                                                 SG_GESAN                ,
//                   FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
//                   ''                                                         DRG_BUNRYU              ,
//                   DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('I',A.PKOCS2003),'3')      CHILD_GUBUN,
//                   A.BOM_SOURCE_KEY                                           BOM_SOURCE_KEY,
//                   A.BOM_OCCUR_YN                                             BOM_OCCUR_YN,
//                   TO_CHAR(A.GROUP_SER, '00000000000')
//                || TO_CHAR(CASE WHEN A.SOURCE_FKOCS2003 IS NOT NULL THEN A.SOURCE_FKOCS2003 
//                                WHEN A.BOM_SOURCE_KEY IS NULL THEN A.PKOCS2003
//                                ELSE A.BOM_SOURCE_KEY END )
//                || A.PKOCS2003                                                CONT_KEY
//              FROM ADM3200 G,
//                   OCS0132 F,
//                   ( SELECT A.SG_CODE
//                          , A.SG_NAME
//                          , A.BUN_CODE
//                          , A.HOSP_CODE
//                       FROM BAS0310 A
//                      WHERE A.SG_YMD = ( SELECT MAX(Z.SG_YMD)
//                                           FROM BAS0310 Z
//                                          WHERE Z.SG_CODE = A.SG_CODE
//                                            AND Z.SG_YMD <= :f_naewon_date )
//                   ) E,
//                   OCS0116 D,
//                   OCS0132 C,
//                   OCS0103 B,
//                   OCS2003 A
//             WHERE :f_io_gubun = 'I'
//               AND A.BUNHO            = :f_bunho
//               AND A.FKINP1001        = :f_jubsu_no
//               AND A.ORDER_DATE       = :f_naewon_date
//               AND A.HOSP_CODE        = :f_hosp_code
//               AND ( ( :f_order_gubun = '%'           ) OR
//                     ( :f_order_gubun = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('C', 'D') ) OR
//                     ( :f_order_gubun = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B') ) OR
//                     ( :f_order_gubun = '3' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E') ) )
//               AND B.HANGMOG_CODE     = A.HANGMOG_CODE
//               AND B.HOSP_CODE        = A.HOSP_CODE
//               AND C.CODE     (+)     = SUBSTR(A.ORDER_GUBUN, 2, 1)
//               AND C.CODE_TYPE(+)     = 'ORDER_GUBUN_BAS'
//               AND C.HOSP_CODE(+)     = A.HOSP_CODE
//               AND F.CODE     (+)     = A.INPUT_GUBUN
//               AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
//               AND F.HOSP_CODE(+)     = A.HOSP_CODE
//               AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
//               AND D.HOSP_CODE(+)     = A.HOSP_CODE
//               AND E.SG_CODE  (+)     = B.SG_CODE
//               AND E.HOSP_CODE(+)     = B.HOSP_CODE
//               AND G.USER_ID  (+)     = A.INPUT_ID
//               AND G.HOSP_CODE(+)     = A.HOSP_CODE
//               AND FN_BAS_LOAD_DOCTOR_GWA(A.INPUT_DOCTOR, A.ORDER_DATE) = :f_gwa
//               AND A.INPUT_DOCTOR                                       = :f_doctor
//               AND EXISTS ( SELECT 'X' FROM VW_OCS_INP1001_RES_02 Z WHERE Z.PKINP1001 = A.FKINP1001 )
//             ORDER BY 97";
//            }

//            return querySql;
        //        }
        #endregion

        #region [DataService Event]

        private void grdOrderInfo_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			//Tel display
            //for(int i = 0; i < grdOrderInfo.RowCount; i++)
            //{
            //    if(grdOrderInfo.GetItemString(i, "tel_yn") == "Y")
            //        grdOrderInfo.SetItemValue(i, "tel_display", "Nur");
            //}

			DiaplayMixGroup(grdOrderInfo);

			//ntt
			this.childSetImage();
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
					// 이미 이미지 세팅이 안된건에 한해서 작업수행
					if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
					{
						//이미수행한건 빼는로직이 있어야함..
						int count = 0;
						for (int j = i; j < aGrd.RowCount; j++)
						{
							// 동일 group_ser, 동일 mix_group
							if (aGrd.GetItemValue(i, "input_gubun").ToString().Trim() == aGrd.GetItemValue(j, "input_gubun").ToString().Trim() &&
								aGrd.GetItemValue(i, "order_gubun").ToString().Trim() == aGrd.GetItemValue(j, "order_gubun").ToString().Trim() &&
								aGrd.GetItemValue(i, "group_ser"  ).ToString().Trim() == aGrd.GetItemValue(j, "group_ser"  ).ToString().Trim() &&
								aGrd.GetItemValue(i, "mix_group"  ).ToString().Trim() == aGrd.GetItemValue(j, "mix_group"  ).ToString().Trim() &&
								aGrd.GetItemValue(i, "hope_date"  ).ToString().Trim() == aGrd.GetItemValue(j, "hope_date"  ).ToString().Trim())
							{
								count++;
								if (count > 1)
								{
									//      헤더를 빼야 실제 Row
									aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
									aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
								}
							}
						}
						// 현재는 image 갯수만큼 처리
						imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
					}
				}
			}
			finally
			{
				//aGrd.Redraw = true; // Grid Display 
			}

		}
		#endregion

		#region [외래/입원전환]

		private void rbtOut_CheckedChanged(object sender, System.EventArgs e)
		{
			//외래
			if(rbtOut.Checked)
			{
				//ntt
				//입력구분
				grdOrderInfo.AutoSizeColumn(2, 0);

				//반납지시
                grdOrderInfo.AutoSizeColumn(6, 0);
                 
				//당일시행, 당일결과여부
				grdOrderInfo.AutoSizeColumn(16, 30);
				grdOrderInfo.AutoSizeColumn(17, 30);

				rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtOut.ImageIndex = 1;

				rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtIn.ImageIndex = 0;

                //grdOrderDateList.SetBindVarValue("f_io_gubun", "O");

			}
			//입원
			else
			{
				//입력구분
				grdOrderInfo.AutoSizeColumn(2, 77);

				//반납지시
				grdOrderInfo.AutoSizeColumn(6, 30);

				//당일시행, 당일결과여부
				grdOrderInfo.AutoSizeColumn(16, 0);
				grdOrderInfo.AutoSizeColumn(17, 0);

				rbtIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtIn.ImageIndex = 1;

				rbtOut.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtOut.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtOut.ImageIndex = 0;

                //grdOrderDateList.SetBindVarValue("f_io_gubun", "I");
			}

			LoadData();
		
		}

		#endregion

		

		#region Order_gubun Tab 변경
		/// <summary>
		/// tab 변경시 해당 처방조회
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabOrderGubun_SelectionChanged(object sender, System.EventArgs e)
		{
			if( tabOrderGubun.SelectedTab == null ) return;

			foreach( IHIS.X.Magic.Controls.TabPage page in tabOrderGubun.TabPages)
			{
				if(tabOrderGubun.SelectedTab == page)
					page.ImageIndex = 1;
				else
					page.ImageIndex = 0;
			}
            
			
            if (tabOrderGubun.SelectedTab.Tag.ToString() == "4")
            {
                grdOrderDateList[0, grdOrderDateList.CellInfos["naewon_date"].Col].Value = Resources.MSG002_MSG;

                #region grdOrderDateList WorkTP 4
                grdOrderDateList.QuerySQL = @"/* WorkTP 4 */
                        SELECT DISTINCT
                               NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) NAEWON_DATE,
                               A.GWA                                                                 GWA,
                               FN_BAS_LOAD_GWA_NAME( A.GWA, A.ORDER_DATE)                            GWA_NAME,
                               FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                       DOCTOR_NAME,
                               A.BUNHO                           BUNHO,
                               A.DOCTOR                          DOCTOR,
                               '0'                               NAEWON_TYPE,
                               0                                 JUBSU_NO   ,
                               A.FKOUT1001                       PK_ORDER   ,
                               'O'                               IO_GUBUN
                          FROM OCS1003 A
                         WHERE :f_io_gubun    = 'O'
                           AND A.BUNHO        = :f_bunho
                           AND A.ORDER_DATE   < :f_order_date
                           AND A.HOSP_CODE    = :f_hosp_code
                           AND NVL(A.DC_YN,'N')        = 'N'
                           AND A.NALSU                 >= 0
                           AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('I')
                           AND A.SORT_FKOCSKEY IS NOT NULL
                        UNION ALL
                        SELECT --DISTINCT
                               A.NAEWON_DATE,
                               A.GWA        ,
                               FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE)
                                                                 GWA_NAME,
                               FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                                                                 DOCTOR_NAME,
                               A.BUNHO                           BUNHO      ,
                               A.DOCTOR                          DOCTOR     ,
                               A.NAEWON_TYPE                     NAEWON_TYPE,
                               A.JUBSU_NO                        JUBSU_NO   ,
                        --modify by jc [重複除去のためグルーピング]
                        --    A.PK_ORDER                        PK_ORDER   ,
                               MAX(A.PK_ORDER)                        PK_ORDER   ,
                               'I'                               IO_GUBUN
                          FROM ( SELECT NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                                                                          NAEWON_DATE,
                        -- modify by jc [C.USER_ID -> A.INPUT_DOCTOR]
                        --                FN_BAS_LOAD_DOCTOR_GWA(DECODE(NVL(C.USER_GUBUN, 'X'), '1', C.USER_ID, A.DOCTOR), A.ORDER_DATE)
                                        FN_BAS_LOAD_DOCTOR_GWA(A.INPUT_DOCTOR, A.ORDER_DATE)
                                                                            GWA      ,
                                        A.BUNHO                           BUNHO      ,
                        -- modify by jc [C.USER_ID -> A.INPUT_DOCTOR]
                        --                DECODE(NVL(C.USER_GUBUN, 'X'), '1', C.USER_ID, A.DOCTOR)
                                        A.INPUT_DOCTOR
                                                                          DOCTOR     ,
                                        '0'                               NAEWON_TYPE,
                                        A.FKINP1001                       JUBSU_NO   ,
                                        A.PKOCS2003                       PK_ORDER
                                   FROM ADM3200 C,
                                        INP1001 B,
                                        OCS2003 A
                                  WHERE :f_io_gubun            = 'I'
                                    AND A.BUNHO                = :f_bunho
                                    AND A.ORDER_DATE          <= :f_order_date
                                    AND A.HOSP_CODE            = :f_hosp_code
                                    AND A.IO_GUBUN             IS NULL
                                    AND A.NALSU               >= 0
                                    AND NVL(A.DISPLAY_YN,'Y')  = 'Y'
                                    AND NVL(A.DC_YN,'N')       = 'N'
                                    AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('I')
                                    AND B.PKINP1001            = A.FKINP1001
                                    AND B.HOSP_CODE            = A.HOSP_CODE
                                    AND NVL(B.CANCEL_YN, 'N')  = 'N'
                                    AND C.USER_ID   (+)        = A.INPUT_ID
                                    AND C.HOSP_CODE (+)        = A.HOSP_CODE ) A
                        --INSERT BY JC [DISTINCT代わりの重複除去]
                        GROUP BY A.NAEWON_DATE
                               , A.GWA        
                               , FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE)
                               , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                               , A.BUNHO                           
                               , A.DOCTOR                          
                               , A.NAEWON_TYPE                     
                               , A.JUBSU_NO
                          ORDER BY 9 DESC";
                #endregion

                #region grdOrderInfo WorkTP 5

                grdOrderInfo.QuerySQL = @"SELECT /* WorkTP 5 */
                           ''                                                         INPUT_GUBUN_NAME        ,
                           A.GROUP_SER                                                GROUP_SER               ,
                           NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
                           A.HANGMOG_CODE                                             HANGMOG_CODE            ,
                           ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                                  THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
                                  ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
                           A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
                           D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
                           A.SURYANG                                                  SURYANG                 ,
                           A.ORD_DANUI                                                ORD_DANUI               ,
                           FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
                           A.DV_TIME                                                  DV_TIME                 ,
                           A.DV                                                       DV                      ,
                           A.NALSU                                                    NALSU                   ,
                           A.JUSA                                                     JUSA                    ,
                           FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
                           A.BOGYONG_CODE                                             BOGYONG_CODE            ,
                           FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                                      BOGYONG_NAME            ,
                           A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
                           A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
                           A.PHARMACY                                                 PHARMACY                ,
                           A.DRG_PACK_YN                                              DRG_PACK_YN             ,
                           A.POWDER_YN                                                POWDER_YN               ,
                           A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
                    --       A.WONNAE_SAYU_CODE                                         WONNAE_SAYU_CODE        ,
                           NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN   ,
                           NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                         DANGIL_GUMSA_RESULT_YN  ,
                           NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
                           A.PAY                                                      PAY                     ,
                    --       A.FLUID_YN                                                 FLUID_YN                ,
                    --       A.TPN_YN                                                   TPN_YN                  ,
                           A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
                           A.MUHYO                                                    MUHYO                   ,
                           A.PORTABLE_YN                                              PORTABLE_YN             ,
                    --       A.SYMYA                                                    SYMYA                   ,
                           A.OCS_FLAG                                                 OCS_FLAG                ,
                           A.ORDER_GUBUN                                              ORDER_GUBUN             ,
                           A.INPUT_TAB                                                INPUT_TAB               ,
                           A.INPUT_GUBUN                                              INPUT_GUBUN             ,
                           A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,
                           A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
                           A.JUNDAL_PART                                              JUNDAL_PART             ,
                           A.MOVE_PART                                                MOVE_PART               ,
                           A.BUNHO                                                    BUNHO                   ,
                           A.ORDER_DATE                                               NAEWON_DATE             ,
                           A.GWA                                                      GWA                     ,
                           A.DOCTOR                                                   DOCTOR                  ,
                           A.NAEWON_TYPE                                              NAEWON_TYPE             ,
                    --       A.JUBSU_NO                                                 JUBSU_NO                ,
                           A.FKOUT1001                                                PK_ORDER                ,
                           A.SEQ                                                      SEQ                     ,
                           A.PKOCS1003                                                PKOCS1003               ,
                           A.SUB_SUSUL                                                SUB_SUSUL               ,
                           A.SUTAK_YN                                                 SUTAK_YN                ,
                    --       A.SANG_CODE                                                SANG_CODE               ,
                    --       A.SYMYA_TIME                                               SYMYA_TIME              ,
                           A.AMT                                                      AMT                     ,
                    --       A.NALSU_SAYU_CODE                                          NALSU_SAYU_CODE         ,
                    --       A.PHYSICAL_CODE                                            PHYSICAL_CODE           ,
                    --       A.NDAY_NALSU                                               NDAY_NALSU              ,
                    --       A.NDAY_SUNAB                                               NDAY_SUNAB              ,
                           A.DV_1                                                     DV_1                    ,
                           A.DV_2                                                     DV_2                    ,
                           A.DV_3                                                     DV_3                    ,
                           A.DV_4                                                     DV_4                    ,
                    --       A.DV_5                                                     DV_5                    ,
                           A.HOPE_DATE                                                HOPE_DATE               ,
                           A.ORDER_REMARK                                             ORDER_REMARK            ,
                           A.MIX_GROUP                                                MIX_GROUP               ,
                           NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
                           A.RESER_DATE                                               RESER_DATE              ,
                           A.JUBSU_DATE                                               JUBSU_DATE              ,
                           A.ACTING_DATE                                              ACTING_DATE             ,
                           A.RESULT_DATE                                              RESULT_DATE             ,
                           A.DC_GUBUN                                                 DC_GUBUN                ,
                           A.DC_YN                                                    DC_YN                   ,
                           A.BANNAB_YN                                                BANNAB_YN               ,
                           DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                                      DONBOK_YN               ,
                           FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4)  DV_NAME                 ,
                           DECODE(A.NURSE_CONFIRM_DATE, NULL, 'N','Y')                CONFIRM_CHECK           ,
                           DECODE(A.SUNAB_DATE, NULL, 'N','Y')                        SUNAB_CHECK             ,
                           DECODE(SIGN(A.NALSU),1,'N',0,'N','Y')                      DC_CHECK                ,
                           B.SLIP_CODE                                                SLIP_CODE               ,
                           B.GROUP_YN                                                 GROUP_YN                ,
                           B.SG_CODE                                                  SG_CODE                 ,
                           B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
                           B.INPUT_CONTROL                                            INPUT_CONTROL           ,
                    --       B.PRIS_NAME                                                PRIS_NAME               ,
                    --       B.KYUKYEOK                                                 KYUKYEOK                ,
                           NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
                           DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
                    --       NVL(B.MULTI_GUMSA_YN,'N')                                  MULTI_GUMSA_YN          ,
                    --       NVL(B.SPECIAL_YN,'N')                                      SPECIAL_CHECK           ,
                           B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
                           NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
                           NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
                           DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
                           B.ORD_DANUI                                                ORD_DANUI_BAS           ,
                           B.JUNDAL_TABLE_OUT                                         JUNDAL_TABLE_OUT        ,
                           B.JUNDAL_PART_OUT                                          JUNDAL_PART_OUT         ,
                    --       NVL(B.PORTABLE_YN,'N')                                     PORTABLE_CR_YN          ,
                           FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
                           FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
                           B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
                    --       B.WONNAE_SAYU_CODE                                         DEFAULT_WONNAE_SAYU_CODE,
                    --       B.SPECIAL_CODE                                             SPECIAL_CODE            ,
                           NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
                           NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
                           NVL(A.TEL_YN, 'N')                                         TEL_YN                  ,
                           FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE)          JUNDAL_PART_NAME        ,
                           E.BUN_CODE                                                 BUN_CODE                ,
                    --       E.SG_GESAN                                                 SG_GESAN                ,
                           FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
                           ''                                                         DRG_BUNRYU              ,             
                           DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('O',A.PKOCS1003),'3')      CHILD_GUBUN,
                           A.BOM_SOURCE_KEY                                           BOM_SOURCE_KEY,
                           A.BOM_OCCUR_YN                                             BOM_OCCUR_YN,
                           FN_OCS_LOAD_ORDER_QUERY_SORT('O',A.TEL_YN,A.ORDER_GUBUN,C.SORT_KEY,A.GROUP_SER,A.MIX_GROUP,
                                                        A.SEQ,A.HOPE_DATE,A.PKOCS1003,A.SOURCE_FKOCS1003,A.BOM_SOURCE_KEY) CONT_KEY
                      FROM BAS0310 E,
                           OCS0116 D,
                           OCS0132 C,
                           OCS0103 B,
                           OCS1003 A
                     WHERE A.BUNHO            = :f_bunho
                       AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) = :f_naewon_date
                       AND A.GWA              = :f_gwa
                       AND A.DOCTOR           = :f_doctor
                       AND A.HOSP_CODE        = :f_hosp_code
                       AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('I')
                       AND B.HANGMOG_CODE     = A.HANGMOG_CODE
                       AND B.HOSP_CODE        = A.HOSP_CODE
                       AND C.CODE     (+)     = SUBSTR(A.ORDER_GUBUN, 2, 1)
                       AND C.CODE_TYPE(+)     = 'ORDER_GUBUN_BAS'
                       AND C.HOSP_CODE(+)     = A.HOSP_CODE
                       AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
                       AND D.HOSP_CODE(+)     = A.HOSP_CODE
                       AND E.SG_CODE  (+)     = B.SG_CODE
                       AND E.HOSP_CODE(+)     = B.HOSP_CODE
                    UNION ALL
                    SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
                           A.GROUP_SER                                                GROUP_SER               ,
                           NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
                           A.HANGMOG_CODE                                             HANGMOG_CODE            ,
                           ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                                  THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
                                  ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
                           A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
                           D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
                           A.SURYANG                                                  SURYANG                 ,
                           A.ORD_DANUI                                                ORD_DANUI               ,
                           FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
                           A.DV_TIME                                                  DV_TIME                 ,
                           A.DV                                                       DV                      ,
                           A.NALSU                                                    NALSU                   ,
                           A.JUSA                                                     JUSA                    ,
                           FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
                           A.BOGYONG_CODE                                             BOGYONG_CODE            ,
                           FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                                                                                      BOGYONG_NAME            ,
                           A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
                           A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
                           A.PHARMACY                                                 PHARMACY                ,
                           A.DRG_PACK_YN                                              DRG_PACK_YN             ,
                           A.POWDER_YN                                                POWDER_YN               ,
                           A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
                    --       A.WONNAE_SAYU_CODE                                         WONNAE_SAYU_CODE        ,
                           'N'                                                        DANGIL_GUMSA_ORDER_YN   ,
                           'N'                                                        DANGIL_GUMSA_RESULT_YN  ,
                           NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
                           A.PAY                                                      PAY                     ,
                    --       A.FLUID_YN                                                 FLUID_YN                ,
                    --       A.TPN_YN                                                   TPN_YN                  ,
                           A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
                           A.MUHYO                                                    MUHYO                   ,
                           A.PORTABLE_YN                                              PORTABLE_YN             ,
                    --       A.SYMYA                                                    SYMYA                   ,
                           A.OCS_FLAG                                                 OCS_FLAG                ,
                           A.ORDER_GUBUN                                              ORDER_GUBUN             ,
                           A.INPUT_TAB                                                INPUT_TAB               ,
                           A.INPUT_GUBUN                                              INPUT_GUBUN             ,
                           'N'                                                        AFTER_ACT_YN            ,
                           A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
                           A.JUNDAL_PART                                              JUNDAL_PART             ,
                           NULL                                                       MOVE_PART               ,
                           A.BUNHO                                                    BUNHO                   ,
                           A.ORDER_DATE                                               NAEWON_DATE             ,
                           A.INPUT_PART                                               GWA                     ,
                           A.INPUT_ID                                                 DOCTOR                  ,
                           '0'                                                        NAEWON_TYPE             ,
                    --       A.FKINP1001                                                JUBSU_NO                ,
                           A.FKINP1001                                                PK_ORDER                ,
                           A.SEQ                                                      SEQ                     ,
                           A.PKOCS2003                                                PKOCS1003               ,
                           A.SUB_SUSUL                                                SUB_SUSUL               ,
                           NULL                                                       SUTAK_YN                ,
                    --       NULL                                                       SANG_CODE               ,
                    --       A.SYMYA_TIME                                               SYMYA_TIME              ,
                           A.AMT                                                      AMT                     ,
                    --       A.NALSU_SAYU_CODE                                          NALSU_SAYU_CODE         ,
                    --       A.PHYSICAL_CODE                                            PHYSICAL_CODE           ,
                    --       NULL                                                       NDAY_NALSU              ,
                    --       NULL                                                       NDAY_SUNAB              ,
                           A.DV_1                                                     DV_1                    ,
                           A.DV_2                                                     DV_2                    ,
                           A.DV_3                                                     DV_3                    ,
                           A.DV_4                                                     DV_4                    ,
                    --       A.DV_5                                                     DV_5                    ,
                           A.HOPE_DATE                                                HOPE_DATE               ,
                           A.ORDER_REMARK                                             ORDER_REMARK            ,
                           A.MIX_GROUP                                                MIX_GROUP               ,
                           NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
                           A.RESER_DATE                                               RESER_DATE              ,
                           A.JUBSU_DATE                                               JUBSU_DATE              ,
                           A.ACTING_DATE                                              ACTING_DATE             ,
                           A.RESULT_DATE                                              RESULT_DATE             ,
                           A.DC_GUBUN                                                 DC_GUBUN                ,
                           A.DC_YN                                                    DC_YN                   ,
                           A.BANNAB_YN                                                BANNAB_YN               ,
                           DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
                                                                                      DONBOK_YN               ,
                           FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4)  DV_NAME                 ,
                           DECODE(A.NURSE_CONFIRM_DATE, NULL, 'N','Y')                CONFIRM_CHECK           ,
                           DECODE(A.SUNAB_DATE, NULL, 'N','Y')                        SUNAB_CHECK             ,
                           DECODE(SIGN(A.NALSU),1,'N',0,'N','Y')                      DC_CHECK                ,
                           B.SLIP_CODE                                                SLIP_CODE               ,
                           B.GROUP_YN                                                 GROUP_YN                ,
                           B.SG_CODE                                                  SG_CODE                 ,
                           B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
                           B.INPUT_CONTROL                                            INPUT_CONTROL           ,
                    --       B.PRIS_NAME                                                PRIS_NAME               ,
                    --       B.KYUKYEOK                                                 KYUKYEOK                ,
                           NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
                           DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
                    --       NVL(B.MULTI_GUMSA_YN,'N')                                  MULTI_GUMSA_YN          ,
                    --       NVL(B.SPECIAL_YN,'N')                                      SPECIAL_CHECK           ,
                           B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
                           NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
                           NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
                           DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
                           B.ORD_DANUI                                                ORD_DANUI_BAS           ,
                           B.JUNDAL_TABLE_OUT                                         JUNDAL_TABLE_OUT        ,
                           B.JUNDAL_PART_OUT                                          JUNDAL_PART_OUT         ,
                    --       NVL(B.PORTABLE_YN,'N')                                     PORTABLE_CR_YN          ,
                           FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
                           FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
                           B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
                    --       B.WONNAE_SAYU_CODE                                         DEFAULT_WONNAE_SAYU_CODE,
                    --       B.SPECIAL_CODE                                             SPECIAL_CODE            ,
                           NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
                           NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
                           NVL(A.TEL_YN, 'N')                                         TEL_YN                  ,
                           FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE )         JUNDAL_PART_NAME        ,
                           E.BUN_CODE                                                 BUN_CODE                ,
                    --       E.SG_GESAN                                                 SG_GESAN                ,
                           FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
                           ''                                                         DRG_BUNRYU              ,
                           DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('I',A.PKOCS2003),'3')      CHILD_GUBUN,
                           A.BOM_SOURCE_KEY                                           BOM_SOURCE_KEY,
                           A.BOM_OCCUR_YN                                             BOM_OCCUR_YN,
                           FN_OCS_LOAD_ORDER_QUERY_SORT('I',A.TEL_YN,A.ORDER_GUBUN,C.SORT_KEY,A.GROUP_SER,A.MIX_GROUP,
                                                        A.SEQ,A.HOPE_DATE,A.PKOCS2003,A.SOURCE_FKOCS2003,A.BOM_SOURCE_KEY) CONT_KEY
                      FROM ADM3200 G,
                           OCS0132 F,
                           BAS0310 E,
                           OCS0116 D,
                           OCS0132 C,
                           OCS0103 B,
                           OCS2003 A
                     WHERE A.BUNHO            = :f_bunho
                       AND A.FKINP1001        = :f_jubsu_no
                       AND A.HOSP_CODE        = :f_hosp_code
                       AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) = :f_naewon_date
                       AND ( ( :f_order_gubun = '%'           ) OR
                             ( :f_order_gubun = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('C', 'D') ) OR
                             ( :f_order_gubun = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B') ) OR
                             ( :f_order_gubun = '3' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E') ) OR
                             ( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('I') ))
                       AND B.HANGMOG_CODE     = A.HANGMOG_CODE
                       AND B.HOSP_CODE        = A.HOSP_CODE
                       AND C.CODE     (+)     = SUBSTR(A.ORDER_GUBUN, 2, 1)
                       AND C.CODE_TYPE(+)     = 'ORDER_GUBUN_BAS'
                       AND C.HOSP_CODE(+)     = A.HOSP_CODE
                       AND F.CODE     (+)     = A.INPUT_GUBUN
                       AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
                       AND F.HOSP_CODE(+)     = A.HOSP_CODE
                       AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
                       AND D.HOSP_CODE(+)     = A.HOSP_CODE
                       AND E.SG_CODE  (+)     = B.SG_CODE
                       AND E.HOSP_CODE(+)     = B.HOSP_CODE
                       AND G.USER_ID  (+)     = A.INPUT_ID
                       AND G.HOSP_CODE(+)     = A.HOSP_CODE
                    --modify by jc [C.USER_ID -> A.INPUT_DOCTOR]
                       --AND FN_BAS_LOAD_DOCTOR_GWA(DECODE(NVL(G.USER_GUBUN, 'X'), '1', G.USER_ID, A.DOCTOR), A.ORDER_DATE) = :f_gwa
                       AND FN_BAS_LOAD_DOCTOR_GWA(A.INPUT_DOCTOR, A.ORDER_DATE) = :f_gwa
                    --modify by jc [C.USER_ID -> A.INPUT_DOCTOR]
                       --AND DECODE(NVL(G.USER_GUBUN, 'X'), '1', G.USER_ID, A.DOCTOR )                                      = :f_doctor
                       AND A.INPUT_DOCTOR = :f_doctor
                     ORDER BY 97";
                
                #endregion
                this.pnlSang.Visible = false;
                this.sptMid.Visible = false;
            }

            grdOrderDateList.SetBindVarValue("f_order_gubun", tabOrderGubun.SelectedTab.Tag.ToString());
            if (!grdOrderDateList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
		}

		#endregion

		#region [출력]

		private void OrderInfoPrint()
		{
			if(grdOrderInfo.RowCount < 0 ) return;

			// Order내역 정보조회 화면 Open
			CommonItemCollection openParams  = new CommonItemCollection();
			if (rbtOut.Checked)
                openParams.Add("io_gubun", "O");
			else
				openParams.Add("io_gubun", "I");

			openParams.Add("bunho"      , grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "bunho"      ));
			openParams.Add("naewon_date", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "naewon_date"));
			openParams.Add("gwa"        , grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "gwa"        ));
			openParams.Add("doctor"     , grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "doctor"     ));
			openParams.Add("naewon_type", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "naewon_type"));
			openParams.Add("jubsu_no"   , grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "jubsu_no"   ));
			openParams.Add("order_gubun", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "order_gubun"));
			XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003R05", ScreenOpenStyle.ResponseSizable, openParams);
		}


		#endregion

		#region btnLabelPrt_Click (의사지시전 출력 화면 call)
		private void btnLabelPrt_Click(object sender, System.EventArgs e)
		{
			int currRow = this.grdOrderDateList.CurrentRowNumber;
			
			if(rbtOut.Checked)  // 외래
			{
				try
				{
					CommonItemCollection openParams = new CommonItemCollection();
					openParams.Add("bunho"      , this.pbxSearch.BunHo);
					openParams.Add("naewon_date", this.grdOrderDateList.GetItemString(currRow, "naewon_date"));
					openParams.Add("gwa"        , this.grdOrderDateList.GetItemString(currRow, "gwa"));
					openParams.Add("doctor"     , this.grdOrderDateList.GetItemString(currRow, "doctor"));
					openParams.Add("naewon_type", this.grdOrderDateList.GetItemString(currRow, "naewon_type"));
					openParams.Add("jubsu_no"   , this.grdOrderDateList.GetItemString(currRow, "jubsu_no"));
					openParams.Add("input_gubun", mInputGubun);
					openParams.Add("auto_close" , false);

					XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003R00", ScreenOpenStyle.ResponseSizable, openParams);
				}
				catch{}
			}
			else                // 입원
			{
				try
				{
					CommonItemCollection openParams = new CommonItemCollection();
					openParams.Add("bunho"      , this.pbxSearch.BunHo);
					openParams.Add("fkinp1001"  , this.grdOrderDateList.GetItemString(currRow, "jubsu_no"));
					openParams.Add("input_gubun", mInputGubun);
					openParams.Add("order_date" , this.grdOrderDateList.GetItemString(currRow, "naewon_date"));
					openParams.Add("auto_close" , false);
					
					XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003R00", ScreenOpenStyle.ResponseSizable, openParams);
				}
				catch{}
			}
		}
		#endregion

		#region ntt childSetImage
		private void childSetImage()
		{
			for (int i=0; i<this.grdOrderInfo.RowCount; i++)
			{
				this.grdOrderInfo[i,"child_gubun"].ForeColor = IHIS.Framework.XColor.XGridColHeaderForeColor;
				switch (this.grdOrderInfo.GetItemString(i,"child_gubun"))
				{
					case "1":
						this.grdOrderInfo[i,"child_gubun"].Image = this.ImageList.Images[3];
						break;
					case "2":
						this.grdOrderInfo[i,"child_gubun"].Image = this.ImageList.Images[3];
						break;
					case "3":
						this.grdOrderInfo[i,"child_gubun"].Image = this.ImageList.Images[5];
						break;
					default:
						this.grdOrderInfo[i,"child_gubun"].Image = this.ImageList.Images[3];
						break;

				}
				this.grdOrderInfo[i,"child_gubun"].ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			}
		}
		#endregion

        #region 각 그리드에 바인드변수 셋팅
        private void grdOrderDateList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrderDateList.SetBindVarValue("f_bunho",      pbxSearch.BunHo);
            grdOrderDateList.SetBindVarValue("f_order_date", dpkOrder_date.GetDataValue());
            grdOrderDateList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (rbtOut.Checked)
            {
                grdOrderDateList.SetBindVarValue("f_io_gubun", "O");
            }
            else
            {
                grdOrderDateList.SetBindVarValue("f_io_gubun", "I");
            }
        }

        private void grdSangInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            
            grdSangInfo.SetBindVarValue("f_bunho",       grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "bunho"));
            grdSangInfo.SetBindVarValue("f_naewon_date", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "naewon_date"));
            grdSangInfo.SetBindVarValue("f_gwa",         grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "gwa"));
            grdSangInfo.SetBindVarValue("f_doctor",      grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "doctor"));
            grdSangInfo.SetBindVarValue("f_naewon_type", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "naewon_type"));
            grdSangInfo.SetBindVarValue("f_jubsu_no",    grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "jubsu_no"));
            //grdSangInfo.SetBindVarValue("f_io_gubun", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "io_gubun"));
            grdSangInfo.SetBindVarValue("f_hosp_code",   EnvironInfo.HospCode);

            if (rbtOut.Checked)
            {
                grdSangInfo.SetBindVarValue("f_io_gubun", "O");
            }
            else
            {
                grdSangInfo.SetBindVarValue("f_io_gubun", "I");
            }
        }

        private void grdOrderInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            //grdOrderInfo.QuerySQL = this.GetQueryString(grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "io_gubun"));
            
            grdOrderInfo.SetBindVarValue("f_bunho",       grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "bunho"));
            grdOrderInfo.SetBindVarValue("f_naewon_date", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "naewon_date"));
            grdOrderInfo.SetBindVarValue("f_gwa",         grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "gwa"));
            grdOrderInfo.SetBindVarValue("f_doctor",      grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "doctor"));
            grdOrderInfo.SetBindVarValue("f_naewon_type", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "naewon_type"));
            grdOrderInfo.SetBindVarValue("f_jubsu_no",    grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "jubsu_no"));
            //grdOrderInfo.SetBindVarValue("f_order_gubun", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "order_gubun"));
            grdOrderInfo.SetBindVarValue("f_order_gubun", tabOrderGubun.SelectedTab.Tag.ToString());
            grdOrderInfo.SetBindVarValue("f_hosp_code",   EnvironInfo.HospCode);
            grdOrderInfo.SetBindVarValue("f_pk_order", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "pk_order"));
            grdOrderInfo.SetBindVarValue("f_io_gubun", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "io_gubun"));
            grdOrderInfo.SetBindVarValue("f_pkocskey", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "pkocskey"));
        }
        #endregion

        private void btnIraisyo_Click(object sender, EventArgs e)
        {
            if (this.grdOrderDateList.CurrentRowNumber < 0) return;
            this.grdOrderInfo.SetItemValue(this.grdOrderInfo.CurrentRowNumber, "nalsu", 1);
            this.OpenScreen_SpecificComment(this.grdOrderDateList, this.grdOrderDateList.CurrentRowNumber);
        }

        /// <summary>
        /// 의뢰서 화면 오픈
        /// </summary>
        /// <param name="aGrid"></param>
        /// <param name="aRowNumber"></param>
        private void OpenScreen_SpecificComment(XEditGrid aGrid, int aRowNumber)
        {

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho",             aGrid.GetItemString(aRowNumber, "bunho"));
            openParams.Add("order_date",        dpkOrder_date.GetDataValue().ToString());
            openParams.Add("pkocskey",          aGrid.GetItemString(aRowNumber, "pkocskey"));
            openParams.Add("in_out_gubun",      aGrid.GetItemString(aRowNumber, "io_gubun"));
            openParams.Add("hangmog_code",      aGrid.GetItemString(aRowNumber, "hangmog_code"));
            openParams.Add("gwa",               aGrid.GetItemString(aRowNumber, "gwa"));
            openParams.Add("doctor",            aGrid.GetItemString(aRowNumber, "doctor"));
            openParams.Add("jundal_part",       aGrid.GetItemString(aRowNumber, "jundal_part"));
            openParams.Add("naewon_key",        aGrid.GetItemString(aRowNumber, "pk_order"));
            openParams.Add("caller_screen_id",  this.ScreenID);

            if (aGrid.GetItemString(aRowNumber, "specific_comment") == "18")
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U00", ScreenOpenStyle.ResponseFixed, openParams);
            else
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U01", ScreenOpenStyle.ResponseFixed, openParams);

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            
            commandParams.Add("OCS3003Q10", this.grdOrderDateList.GetItemString(this.grdOrderDateList.CurrentRowNumber, "pkocskey"));
            commandParams.Add("pkphy8002", this.grdOrderDateList.GetItemString(this.grdOrderDateList.CurrentRowNumber, "pkocskey"));
            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }

        private void grdOrderDateList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            
        }

        private void grdOrderDateList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (this.grdOrderDateList.GetItemString(e.CurrentRow, "irai_kubun") == this.mIraiKubun)
                this.btnCopy.Enabled = true;
            else
                this.btnCopy.Enabled = true;

            //this.LoadResult();
            //if (this.grdOrderDateList.GetItemString(this.grdOrderDateList.CurrentRowNumber, "irai_kubun") == "B")
            //{
                //이미지 다운로드하여 이미지 SET(다운로드 이미지 리스트를 만들어 Download)
                fileName = this.grdOrderDateList.GetItemString(this.grdOrderDateList.CurrentRowNumber, "image");
                if (fileName.Trim().Length > 0)
                {
                    string jundal_part = "REHA";
                    string filePath = Directory.GetParent(Application.StartupPath) + "\\" + "REHA" + "Images" + "\\" + jundal_part;
                    string createTime = grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "cr_time");
                    //createTime = EnvironInfo.GetSysDate().ToString();
                    string serverPath = grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "image_path");
                    if (ImageHelper.IsFileDownload(filePath + "\\" + fileName, DateTime.Parse(createTime)))
                    {
                        ArrayList fileList = new ArrayList();
                        fileList.Add(new ImageFileInfo(filePath, serverPath, fileName, fileName));
                        ImageHelper.DownloadImages(fileList, false);
                    }
                    if (ImageHelper.GetImage(filePath + "\\" + fileName) != null)
                        this.pbxImage.Image = ImageHelper.GetImage(filePath + "\\" + fileName);

                    dirInfo = new DirectoryInfo(filePath);

                }
            //}
            //else
            //    this.pbxImage.Image = null;
        }

        #region ImageItem (Image 편집후 저장시 사용할 class, Cell의 Tag와 PictureBox의 Tag에 저장하였다가 이미지 편집후 저장처리함)
        internal class ImageItem
        {
            public PictureBox PBox = null;      //Image가 있는 PictureBox
            public XCell Cell = null;      //Image가 있는 Cell
            public Image Image = null;      //Image
            public string ClientFileName = "";  //Client File Name 
            public string ServerFileName = "";  //Server File Name
            public string ClientFilePath = "";  //Client의 파일 Path
            public string ServerFilePath = "";  //Server에 저장된 File Path
            public string CheckYn = "";         //결과조회에 보여주어야하는지의 여부
            /********************************************************/
            public string Seq = "";             //서버에 저장된 seq순번

            public string JundalPart = "";
            public string JundalPartName = "";
            public string HangmogCode = "";
            public string HangmogName = "";

            public string OrderDate = "";
            public string ActingDate = "";
            public string ResultDate = "";

            public ImageItem() { }
        }
        #endregion        

        #region 검사 결과 Load (결과 Image)
        private ImageItem currentImageItem = null;  //현재 선택된 ImageItem
        private ArrayList ImageItemList = new ArrayList(); //Dicom Image의 ImageItem 관리 List

        private void LoadResult()
        {
            try
            {
                //결과 이미지 조회, 성공시 Grid에 Image Set
                this.pbxImage.Image = null;
                this.currentImageItem = null; //Clear
                this.ImageItemList.Clear();

                ArrayList imageFileInfoList = new ArrayList();  //Total ImageFileInfo List
                ArrayList downloadFileInfoList = new ArrayList();  //다운로드할 ImageInfo의 List (ImageInfo 관리)

                string imagePath = ImageHelper.GetImageRoot();
                ImageFileInfo info = null;

                string image = "";
                string image_path = "";
                string cr_time = "";
                int currRow = this.grdOrderDateList.CurrentRowNumber;
                
                if (currRow > 0)
                {
                    image = this.grdOrderDateList.GetItemString(currRow, "image");
                    image_path = this.grdOrderDateList.GetItemString(currRow, "image_path");
                    cr_time = this.grdOrderDateList.GetItemString(currRow, "cr_time");
                
                    //if (this.layResultImageList.QueryLayout(true))
                    //{
                    //    foreach (DataRow dtRow in this.layResultImageList.LayoutTable.Rows)
                    //    {
                            //2006.03.15 이미지 다운로드 규칙( 파일존재여부와 서버 생성시간과 비교하여 처리함)
                    info = new ImageFileInfo(imagePath, image_path, image, image);

                            //다운로드할 파일이면 다운로드 리스트에 Add
                    if (ImageHelper.IsFileDownload(imagePath + "\\" + image, DateTime.Parse(cr_time)))
                            {
                                downloadFileInfoList.Add(info);
                            }
                            //이미지 List 에 Add
                            imageFileInfoList.Add(info);
                    //    }
                    //}
                    //Download Image
                    ImageItem imgItem = null;

                    if (ImageHelper.DownloadImages(downloadFileInfoList, false))
                    {
                        int rowNum = 0;
                        foreach (ImageFileInfo fInfo in imageFileInfoList)
                        {
                            imgItem = new ImageItem();
                            //Image는 ImageHelper를 통해서 가져옴. 바로 Image.FromFile을 하면 File사용해제가 안되서 Upload처리하지 못함
                            //기준정보 Image와 결과 Image를 같은 Dir에서 관리한다고 가정하고 처리함.
                            //다른 Server Dir에 관리한다면 다르게 처리해야함
                            imgItem.Image = ImageHelper.GetImage(fInfo.ClientPath + "\\" + fInfo.ClientFileName);
                            imgItem.ClientFilePath = fInfo.ClientPath;
                            imgItem.ClientFileName = fInfo.ClientFileName;
                            imgItem.ServerFilePath = fInfo.ServerPath;
                            /********************************************************************/
                            //imgItem.Seq = fInfo.Seq;
                            //imgItem.PBox = this.pbxImage;

                            //imgItem.JundalPart = this.layResultImageList.GetItemString(rowNum, "jundal_part");
                            ////imgItem.JundalPartName = this.layResultImageList.GetItemString(rowNum, "jundal_part");
                            //imgItem.HangmogCode = this.layResultImageList.GetItemString(rowNum, "hangmog_code");
                            //imgItem.HangmogName = this.layResultImageList.GetItemString(rowNum, "hangmog_name");
                            //imgItem.OrderDate = this.layResultImageList.GetItemString(rowNum, "order_date");
                            //imgItem.ActingDate = this.layResultImageList.GetItemString(rowNum, "acting_date");
                            //imgItem.ResultDate = this.layResultImageList.GetItemString(rowNum, "result_date");

                            this.ImageItemList.Add(imgItem);
                            rowNum++;
                        }
                    }
                }
                //Image 배치하기
                //ArrangeDicomImages();
            }
            catch (Exception xe)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(Resources.MSG003_MSG + xe.Message + "]");
            }
        }

        #endregion

        private void grdOrderDateList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
                this.btnIraisyo.PerformClick();
        }

        private void btnHealthQuestionnair_Click(object sender, EventArgs e)
        {
            string targetUrl = "";
            string HQNServerIP = this.mOrderBiz.GetServerIP("HQN");
            targetUrl = "http://" + HQNServerIP + "/Public/index.html?page=answers&patientid=" + this.pbxSearch.BunHo.ToString();
            System.Diagnostics.Process.Start(targetUrl);
        }

        private void OCS3003Q10_Closing(object sender, CancelEventArgs e)
        {
            //dirInfo.Delete();
            if (dirInfo.Exists)
            {
                FileInfo[] sfiles = dirInfo.GetFiles();

                foreach (FileInfo fi in sfiles)
                {
                    //if (fi.Name == fileName)
                    fi.Delete();// 파일삭제
                }
                // 폴더삭제
                //while (dirInfo.Exists)
                //{
                //    dirInfo.Delete();
                //}
            }
        }

        #region Connect to cloud service

        /// <summary>
        /// ExecuteQueryGrdOrderDateListItemInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOrderDateListItemInfo(BindVarCollection bc)
        {
            
            List<object[]> res = new List<object[]>();
            OCS3003Q10GrdOrderDateArgs vOCS3003Q10GrdOrderDateArgs = new OCS3003Q10GrdOrderDateArgs();
            vOCS3003Q10GrdOrderDateArgs.IoGubun = bc["f_io_gubun"] != null ? bc["f_io_gubun"].VarValue : "";
            vOCS3003Q10GrdOrderDateArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            vOCS3003Q10GrdOrderDateArgs.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            vOCS3003Q10GrdOrderDateArgs.OrderGubun = bc["f_order_gubun"] != null ? bc["f_order_gubun"].VarValue : "";
            OCS3003Q10GrdOrderDateResult result = CloudService.Instance.Submit<OCS3003Q10GrdOrderDateResult, OCS3003Q10GrdOrderDateArgs>(vOCS3003Q10GrdOrderDateArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS3003Q10GrdOrderDateListItemInfo item in result.ListInfo)
                {
                    object[] objects = 
				{ 
					item.OrderDate, 
					item.Gwa, 
					item.GwaName, 
					item.DoctorName, 
					item.Bunho, 
					item.Doctor, 
					item.NaewonType, 
					item.JubsuNo, 
					item.PkOrder, 
					item.IoGubun, 
					item.SpecificComment, 
					item.Pkocskey, 
					item.HangmogName, 
					item.HangmogCode, 
					item.JundalPart, 
					item.IraiKubun, 
					item.Image, 
					item.ImagePath, 
					item.CrTime
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOrderListItemInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOrderListItemInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS3003Q10GrdOrderArgs vOCS3003Q10GrdOrderArgs = new OCS3003Q10GrdOrderArgs();
            vOCS3003Q10GrdOrderArgs.NaewonDate = bc["f_naewon_date"] != null ? bc["f_naewon_date"].VarValue : "";
            vOCS3003Q10GrdOrderArgs.IoGubun = bc["f_io_gubun"] != null ? bc["f_io_gubun"].VarValue : "";
            vOCS3003Q10GrdOrderArgs.OrderGubun = bc["f_order_gubun"] != null ? bc["f_order_gubun"].VarValue : "";
            vOCS3003Q10GrdOrderArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            vOCS3003Q10GrdOrderArgs.PkOcskey = bc["f_pkocskey"] != null ? bc["f_pkocskey"].VarValue : "";
            vOCS3003Q10GrdOrderArgs.JubsuNo = bc["f_jubsu_no"] != null ? bc["f_jubsu_no"].VarValue : "";
            vOCS3003Q10GrdOrderArgs.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            vOCS3003Q10GrdOrderArgs.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            OCS3003Q10GrdOrderResult result = CloudService.Instance.Submit<OCS3003Q10GrdOrderResult, OCS3003Q10GrdOrderArgs>(vOCS3003Q10GrdOrderArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS3003Q10GrdOrderListItemInfo item in result.ListResult)
                {
                    object[] objects = 
				{ 
					item.InputGubunName, 
					item.GroupSer, 
					item.OrderGubunName, 
					item.HangmogCode, 
					item.HangmogName, 
					item.Suryang, 
					item.OrdDanui, 
					item.OrdDanuiName, 
					item.DvTime, 
					item.Dv, 
					item.Nalsu, 
					item.WonyoiOrderYn, 
					item.Emergency, 
					item.Pay, 
					item.AntiCancerYn, 
					item.Muhyo, 
					item.PortableYn, 
					item.OcsFlag, 
					item.OrderGubun, 
					item.InputTab, 
					item.InputGubun, 
					item.AfterActYn, 
					item.JundalTable, 
					item.JundalPart, 
					item.MovePart, 
					item.Bunho, 
					item.NaewonDate, 
					item.Gwa, 
					item.Doctor, 
					item.NaewonType, 
					item.PkOrder, 
					item.Seq, 
					item.Pkocs1003, 
					item.SubSusul, 
					item.SutakYn, 
					item.Amt, 
					item.Dv1, 
					item.Dv2, 
					item.Dv3, 
					item.Dv4, 
					item.OrderRemark, 
					item.MixGroup, 
					item.JubsuDate, 
					item.ActingDate, 
					item.ResultDate, 
					item.DcGubun, 
					item.DcYn, 
					item.BannabYn, 
					item.DonbokYn, 
					item.DvName, 
					item.ConfirmCheck, 
					item.SunabCheck, 
					item.DcCheck, 
					item.SlipCode, 
					item.GroupYn, 
					item.SgCode, 
					item.OrderGubunBas, 
					item.InputControl, 
					item.SugaYn, 
					item.EmergencyCheck, 
					item.LimitSuryang, 
					item.SpecimenYn, 
					item.JaeryoYn, 
					item.OrdDanuiCheck, 
					item.OrdDanuiBas, 
					item.JundalTableOut, 
					item.JundalPartOut, 
					item.BulyongCheck, 
					item.WonyoiOrderCrYn, 
					item.DefaultWonyoiOrderYn, 
					item.NdayYn, 
					item.MuhyoYn, 
					item.TelYn, 
					item.JundalPartName, 
					item.BunCode, 
					item.DrgInfo, 
					item.DrgBunryu, 
					item.ChildGubun, 
					item.BomSourceKey, 
					item.BomOccurYn, 
					item.ActingTime, 
					item.ContKey
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdSangListItemInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdSangListItemInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS3003Q10GrdSangArgs vOCS3003Q10GrdSangArgs = new OCS3003Q10GrdSangArgs();
            vOCS3003Q10GrdSangArgs.IoGubun = bc["f_io_gubun"] != null ? bc["f_io_gubun"].VarValue : "";
            vOCS3003Q10GrdSangArgs.JubsuNo = bc["f_jubsu_no"] != null ? bc["f_jubsu_no"].VarValue : "";
            vOCS3003Q10GrdSangArgs.NaewonDate = bc["f_naewon_date"] != null ? bc["f_naewon_date"].VarValue : "";
            vOCS3003Q10GrdSangArgs.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            vOCS3003Q10GrdSangArgs.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            vOCS3003Q10GrdSangArgs.NaewonType = bc["f_naewon_type"] != null ? bc["f_naewon_type"].VarValue : "";
            vOCS3003Q10GrdSangArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            OCS3003Q10GrdSangResult result = CloudService.Instance.Submit<OCS3003Q10GrdSangResult, OCS3003Q10GrdSangArgs>(vOCS3003Q10GrdSangArgs);
            if (result != null && result.ExecutionStatus ==ExecutionStatus.Success)
            {
                foreach (OCS3003Q10GrdSangListItemInfo item in result.ListResult)
                {
                    object[] objects = 
				{ 
					item.JuSangYn, 
					item.SangCode, 
					item.GwaName, 
					item.Ser, 
					item.DisSangName, 
					item.SangStartDate, 
					item.SangEndDate, 
					item.SangEndSayuName, 
					item.SangEndSayu, 
					item.Bunho, 
					item.NaewonDate, 
					item.Gwa, 
					item.Doctor, 
					item.NaewonType, 
					item.JubsuNo, 
					item.PkOrder, 
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
					item.SangJindanDate, 
					item.EndYn, 
					item.OrderByKey
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion 

    }
}

