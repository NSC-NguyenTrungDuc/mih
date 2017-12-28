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

namespace IHIS.NURI
{
	/// <summary>
	/// INP3003U00에 대한 요약 설명입니다. (外)ミトコンドリアＤＮＡ１１７７８
	/// 
	///  심사 마감 구분에 따른 변화
	///      1. 가퇴원, 퇴원 일자의 프로텍트 => 심사마감구분 콤보, LoadINP1001 이후
	///      2. 각 상태에 따른 Validation 체크 => 심사마감구분 콤보의 DataValidating
	///      
	///  수납코드 
	///      => 심사마감 구분에 따라 입력할 수 있는 수납코드가 다르다
	///      => 그리드의 ColumnChanged 이벤트 살펴볼것...
	/// </summary>
	[ToolboxItem(false)]
	public class INP3003U00 : IHIS.Framework.XScreen
    {
        #region 자동생성

        private IHIS.Framework.XPanel pnlPatientInfo;
        private IHIS.Framework.XPanel pnlIpwonInfo;
        private IHIS.Framework.XPanel pnlInIpwonInfo;
        private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XLabel xLabel10;
        private IHIS.Framework.XLabel xLabel11;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XLabel xLabel50;
        private IHIS.Framework.XMstGrid grdINP1001;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell61;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
        private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
		private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell67;
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
        private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XTextBox txtPkinp1001;
		private IHIS.Framework.XDisplayBox dbxSimsajaName;
		private IHIS.Framework.XDisplayBox dbxSimsaja;
		private IHIS.Framework.XDisplayBox dbxBedNo;
		private IHIS.Framework.XDisplayBox dbxHoCode;
		private IHIS.Framework.XDisplayBox dbxHoDong;
		private IHIS.Framework.XDisplayBox dbxJaewonIlsu;
		private IHIS.Framework.XDisplayBox dbxGwaName;
        private IHIS.Framework.XDisplayBox dbxGwa;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.MultiLayout layINP1002;
		private IHIS.Framework.XDictComboBox cboSimsaMagamGubun;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XFindWorker fwkBAS0102;
		private IHIS.Framework.XFindWorker fwkDisGubun;
		private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
		private IHIS.Framework.XFindWorker fwkHunabGubun;
		private IHIS.Framework.FindColumnInfo findColumnInfo5;
		private IHIS.Framework.FindColumnInfo findColumnInfo6;
		private IHIS.Framework.MultiLayout layCardAmt;
		private IHIS.Framework.SingleLayout layCheckINP3007;
		private IHIS.Framework.XEditGridCell xEditGridCell126;
		private IHIS.Framework.XEditGridCell xEditGridCell127;
		private IHIS.Framework.XEditGridCell xEditGridCell128;
		private IHIS.Framework.XEditGridCell xEditGridCell129;
		private IHIS.Framework.XEditGridCell xEditGridCell130;
		private IHIS.Framework.XEditGridCell xEditGridCell131;
        private IHIS.Framework.XEditGridCell xEditGridCell132;
		private IHIS.Framework.XEditGridCell xEditGridCell134;
		private IHIS.Framework.XEditGridCell xEditGridCell135;
		private IHIS.Framework.XEditGridCell xEditGridCell136;
		private IHIS.Framework.XEditGridCell xEditGridCell137;
		private IHIS.Framework.XEditGridCell xEditGridCell138;
		private IHIS.Framework.XEditGridCell xEditGridCell139;
		private IHIS.Framework.XEditGridCell xEditGridCell140;
		private IHIS.Framework.XEditGridCell xEditGridCell141;
		private IHIS.Framework.XEditGridCell xEditGridCell142;
		private IHIS.Framework.XEditGridCell xEditGridCell143;
		private IHIS.Framework.XEditGridCell xEditGridCell144;
		private IHIS.Framework.XEditGridCell xEditGridCell145;
		private IHIS.Framework.XEditGridCell xEditGridCell148;
		private IHIS.Framework.XEditGridCell xEditGridCell149;
		private IHIS.Framework.XEditGridCell xEditGridCell150;
		private IHIS.Framework.XEditGridCell xEditGridCell151;
		private IHIS.Framework.XEditGridCell xEditGridCell152;
		private IHIS.Framework.XEditGridCell xEditGridCell153;
		private IHIS.Framework.XEditGridCell xEditGridCell154;
		private IHIS.Framework.XEditGridCell xEditGridCell155;
		private IHIS.Framework.XEditGridCell xEditGridCell156;
		private IHIS.Framework.XEditGridCell xEditGridCell157;
		private IHIS.Framework.XEditGridCell xEditGridCell158;
		private IHIS.Framework.XEditGridCell xEditGridCell159;
		private IHIS.Framework.XEditGridCell xEditGridCell162;
		private IHIS.Framework.XEditGridCell xEditGridCell164;
		private IHIS.Framework.XEditGridCell xEditGridCell165;
		private IHIS.Framework.XEditGridCell xEditGridCell166;
		private IHIS.Framework.XEditGridCell xEditGridCell167;
		private IHIS.Framework.XEditGridCell xEditGridCell168;
		private IHIS.Framework.XEditGridCell xEditGridCell169;
		private IHIS.Framework.XEditGridCell xEditGridCell170;
		private IHIS.Framework.XEditGridCell xEditGridCell171;
		private IHIS.Framework.XEditGridCell xEditGridCell172;
		private IHIS.Framework.XEditGridCell xEditGridCell173;
		private IHIS.Framework.XEditGridCell xEditGridCell174;
		private IHIS.Framework.XEditGridCell xEditGridCell175;
		private IHIS.Framework.XEditGridCell xEditGridCell176;
		private IHIS.Framework.XEditGridCell xEditGridCell177;
		private IHIS.Framework.XEditGridCell xEditGridCell178;
		private IHIS.Framework.XEditGridCell xEditGridCell179;
		private IHIS.Framework.XEditGridCell xEditGridCell180;
		private IHIS.Framework.XEditGridCell xEditGridCell181;
		private IHIS.Framework.XEditGridCell xEditGridCell182;
		private IHIS.Framework.XEditGridCell xEditGridCell183;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.MultiLayout layINP1005;
		private IHIS.Framework.FindColumnInfo findColumnInfo7;
        private IHIS.Framework.FindColumnInfo findColumnInfo8;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XDatePicker dtpGaToiwonDate;
		private IHIS.Framework.XDatePicker dtpToiwonDate;
        private IHIS.Framework.XEditMask emkToiwonTime;
		private IHIS.Framework.SingleLayout layCreatePoint;
		private IHIS.Framework.XEditGridCell xEditGridCell82;
		private IHIS.Framework.XEditGridCell xEditGridCell83;
		private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
		private IHIS.Framework.XEditGridCell xEditGridCell86;
		private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditMask emkSimsaMagamTime;
		private IHIS.Framework.XEditGridCell xEditGridCell93;
		private IHIS.Framework.XEditGridCell xEditGridCell94;
		private IHIS.Framework.XEditGridCell xEditGridCell95;
		private IHIS.Framework.XEditGridCell xEditGridCell96;
		private IHIS.Framework.XEditGridCell xEditGridCell97;
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
        private IHIS.Framework.XEditGridCell xEditGridCell110;
        private IHIS.Framework.XEditGridCell xEditGridCell111;
		private IHIS.Framework.XButton btnToiwonCancel;
		private IHIS.Framework.SingleLayout layToiwonCancel;
        private IHIS.Framework.SingleLayout layLoadToiwonResDate;
        private IHIS.Framework.SingleLayout layCreateToiwonDrug;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private XPanel panButton;
        private XPanel panMiddle;
        private XTabControl tabInfo;
        private IHIS.X.Magic.Controls.TabPage tpgSang;
        private XEditGrid grdINP2002;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell122;
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell124;
        private IHIS.X.Magic.Controls.TabPage tpgIpwonList;
        private XMstGrid grdINP1001Past;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell108;
        private XEditGridCell xEditGridCell109;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XButton btnReTrans;
        private XDatePicker dtpSimsaMagamDate;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
		private System.ComponentModel.IContainer components;

        #endregion

        public INP3003U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP3003U00));
            this.pnlPatientInfo = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlIpwonInfo = new IHIS.Framework.XPanel();
            this.tabInfo = new IHIS.Framework.XTabControl();
            this.tpgIpwonList = new IHIS.X.Magic.Controls.TabPage();
            this.grdINP1001Past = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.tpgSang = new IHIS.X.Magic.Controls.TabPage();
            this.grdINP2002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.pnlInIpwonInfo = new IHIS.Framework.XPanel();
            this.panMiddle = new IHIS.Framework.XPanel();
            this.grdINP1001 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.dbxGwa = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.dbxHoCode = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.dbxBedNo = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.dtpSimsaMagamDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.emkSimsaMagamTime = new IHIS.Framework.XEditMask();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.dbxSimsaja = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.dbxSimsajaName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.dtpGaToiwonDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.dtpToiwonDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.emkToiwonTime = new IHIS.Framework.XEditMask();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.cboSimsaMagamGubun = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.dbxGwaName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.dbxJaewonIlsu = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.dbxHoDong = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.txtPkinp1001 = new IHIS.Framework.XTextBox();
            this.xLabel50 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.fwkBAS0102 = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.fwkDisGubun = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.fwkHunabGubun = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo7 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo8 = new IHIS.Framework.FindColumnInfo();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layINP1002 = new IHIS.Framework.MultiLayout();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell182 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell183 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.layCardAmt = new IHIS.Framework.MultiLayout();
            this.layCheckINP3007 = new IHIS.Framework.SingleLayout();
            this.layINP1005 = new IHIS.Framework.MultiLayout();
            this.layCreatePoint = new IHIS.Framework.SingleLayout();
            this.btnToiwonCancel = new IHIS.Framework.XButton();
            this.layToiwonCancel = new IHIS.Framework.SingleLayout();
            this.layLoadToiwonResDate = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.layCreateToiwonDrug = new IHIS.Framework.SingleLayout();
            this.panButton = new IHIS.Framework.XPanel();
            this.btnReTrans = new IHIS.Framework.XButton();
            this.pnlPatientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlIpwonInfo.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tpgIpwonList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001Past)).BeginInit();
            this.tpgSang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2002)).BeginInit();
            this.pnlInIpwonInfo.SuspendLayout();
            this.panMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layINP1002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCardAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layINP1005)).BeginInit();
            this.panButton.SuspendLayout();
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
            this.ImageList.Images.SetKeyName(9, "로테이트.gif");
            // 
            // pnlPatientInfo
            // 
            this.pnlPatientInfo.Controls.Add(this.paBox);
            this.pnlPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatientInfo.Location = new System.Drawing.Point(2, 2);
            this.pnlPatientInfo.Name = "pnlPatientInfo";
            this.pnlPatientInfo.Size = new System.Drawing.Size(615, 36);
            this.pnlPatientInfo.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.paBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(615, 36);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlIpwonInfo
            // 
            this.pnlIpwonInfo.Controls.Add(this.tabInfo);
            this.pnlIpwonInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIpwonInfo.Location = new System.Drawing.Point(2, 38);
            this.pnlIpwonInfo.Name = "pnlIpwonInfo";
            this.pnlIpwonInfo.Size = new System.Drawing.Size(615, 152);
            this.pnlIpwonInfo.TabIndex = 1;
            // 
            // tabInfo
            // 
            this.tabInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInfo.IDEPixelArea = true;
            this.tabInfo.IDEPixelBorder = false;
            this.tabInfo.Location = new System.Drawing.Point(0, 0);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedIndex = 0;
            this.tabInfo.SelectedTab = this.tpgIpwonList;
            this.tabInfo.Size = new System.Drawing.Size(615, 152);
            this.tabInfo.TabIndex = 6;
            this.tabInfo.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tpgIpwonList,
            this.tpgSang});
            this.tabInfo.TextInactiveColor = System.Drawing.Color.Black;
            this.tabInfo.SelectionChanged += new System.EventHandler(this.tabInfo_SelectionChanged);
            // 
            // tpgIpwonList
            // 
            this.tpgIpwonList.Controls.Add(this.grdINP1001Past);
            this.tpgIpwonList.ImageIndex = 1;
            this.tpgIpwonList.ImageList = this.ImageList;
            this.tpgIpwonList.Location = new System.Drawing.Point(0, 25);
            this.tpgIpwonList.Name = "tpgIpwonList";
            this.tpgIpwonList.Padding = new System.Windows.Forms.Padding(1);
            this.tpgIpwonList.Size = new System.Drawing.Size(615, 127);
            this.tpgIpwonList.TabIndex = 3;
            this.tpgIpwonList.Title = "入院履歴 ";
            // 
            // grdINP1001Past
            // 
            this.grdINP1001Past.ApplyPaintEventToAllColumn = true;
            this.grdINP1001Past.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell92,
            this.xEditGridCell13,
            this.xEditGridCell16,
            this.xEditGridCell108,
            this.xEditGridCell109});
            this.grdINP1001Past.ColPerLine = 6;
            this.grdINP1001Past.Cols = 7;
            this.grdINP1001Past.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1001Past.FixedCols = 1;
            this.grdINP1001Past.FixedRows = 1;
            this.grdINP1001Past.HeaderHeights.Add(27);
            this.grdINP1001Past.Location = new System.Drawing.Point(1, 1);
            this.grdINP1001Past.Name = "grdINP1001Past";
            this.grdINP1001Past.QuerySQL = resources.GetString("grdINP1001Past.QuerySQL");
            this.grdINP1001Past.ReadOnly = true;
            this.grdINP1001Past.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdINP1001Past.RowHeaderVisible = true;
            this.grdINP1001Past.Rows = 2;
            this.grdINP1001Past.Size = new System.Drawing.Size(613, 125);
            this.grdINP1001Past.TabIndex = 7;
            this.grdINP1001Past.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdINP1001Past_RowFocusChanged);
            this.grdINP1001Past.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdINP1001Past_GridCellPainting);
            this.grdINP1001Past.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1001Past_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pkinp1001";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "pkinp1001";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "ipwon_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "入院日付";
            this.xEditGridCell2.IsJapanYearType = true;
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "ipwon_type";
            this.xEditGridCell3.CellWidth = 33;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "입원유형";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "ipwon_type_name";
            this.xEditGridCell4.CellWidth = 100;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "入院タイプ";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gwa";
            this.xEditGridCell8.CellWidth = 36;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "診療科";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gwa_name";
            this.xEditGridCell9.CellWidth = 110;
            this.xEditGridCell9.Col = 4;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "診療科";
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "doctor";
            this.xEditGridCell14.CellWidth = 50;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "医師";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "doctor_name";
            this.xEditGridCell15.CellWidth = 110;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "主治医";
            this.xEditGridCell15.IsReadOnly = true;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "jaewon_ilsu";
            this.xEditGridCell92.CellWidth = 40;
            this.xEditGridCell92.Col = 2;
            this.xEditGridCell92.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell92.HeaderText = "在院\r\n日数";
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "result_code";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "転帰コード";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "result";
            this.xEditGridCell16.CellWidth = 110;
            this.xEditGridCell16.Col = 6;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "転帰";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "toiwon_date";
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.HeaderText = "toiwon_date";
            this.xEditGridCell108.IsUpdCol = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "toiwon_res_date";
            this.xEditGridCell109.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell109.Col = -1;
            this.xEditGridCell109.HeaderText = "toiwon_res_date";
            this.xEditGridCell109.IsUpdCol = false;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            // 
            // tpgSang
            // 
            this.tpgSang.Controls.Add(this.grdINP2002);
            this.tpgSang.ImageIndex = 2;
            this.tpgSang.ImageList = this.ImageList;
            this.tpgSang.Location = new System.Drawing.Point(0, 25);
            this.tpgSang.Name = "tpgSang";
            this.tpgSang.Selected = false;
            this.tpgSang.Size = new System.Drawing.Size(615, 127);
            this.tpgSang.TabIndex = 5;
            this.tpgSang.Title = "傷病情報";
            // 
            // grdINP2002
            // 
            this.grdINP2002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell122,
            this.xEditGridCell123,
            this.xEditGridCell124});
            this.grdINP2002.ColPerLine = 5;
            this.grdINP2002.Cols = 5;
            this.grdINP2002.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP2002.FixedRows = 1;
            this.grdINP2002.HeaderHeights.Add(21);
            this.grdINP2002.Location = new System.Drawing.Point(0, 0);
            this.grdINP2002.Name = "grdINP2002";
            this.grdINP2002.QuerySQL = resources.GetString("grdINP2002.QuerySQL");
            this.grdINP2002.Rows = 2;
            this.grdINP2002.Size = new System.Drawing.Size(615, 127);
            this.grdINP2002.TabIndex = 8;
            this.grdINP2002.Visible = false;
            this.grdINP2002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP2002_QueryStarting);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ju_sang_yn";
            this.xEditGridCell5.CellWidth = 30;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderText = "主";
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sang_code";
            this.xEditGridCell6.CellWidth = 89;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "傷病コード";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sang_name";
            this.xEditGridCell7.CellWidth = 233;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "傷病名";
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "sang_start_date";
            this.xEditGridCell122.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell122.CellWidth = 100;
            this.xEditGridCell122.Col = 2;
            this.xEditGridCell122.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell122.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell122.HeaderText = "開始日付";
            this.xEditGridCell122.IsJapanYearType = true;
            this.xEditGridCell122.IsReadOnly = true;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "sang_end_date";
            this.xEditGridCell123.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell123.CellWidth = 100;
            this.xEditGridCell123.Col = 3;
            this.xEditGridCell123.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell123.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell123.HeaderText = "終了日付";
            this.xEditGridCell123.IsJapanYearType = true;
            this.xEditGridCell123.IsReadOnly = true;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "sang_end_sayu";
            this.xEditGridCell124.CellWidth = 112;
            this.xEditGridCell124.Col = 4;
            this.xEditGridCell124.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell124.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell124.HeaderText = "終了事由";
            this.xEditGridCell124.IsReadOnly = true;
            this.xEditGridCell124.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInIpwonInfo
            // 
            this.pnlInIpwonInfo.Controls.Add(this.panMiddle);
            this.pnlInIpwonInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInIpwonInfo.DrawBorder = true;
            this.pnlInIpwonInfo.Location = new System.Drawing.Point(2, 190);
            this.pnlInIpwonInfo.Name = "pnlInIpwonInfo";
            this.pnlInIpwonInfo.Size = new System.Drawing.Size(615, 161);
            this.pnlInIpwonInfo.TabIndex = 0;
            // 
            // panMiddle
            // 
            this.panMiddle.Controls.Add(this.grdINP1001);
            this.panMiddle.Controls.Add(this.cboSimsaMagamGubun);
            this.panMiddle.Controls.Add(this.dtpSimsaMagamDate);
            this.panMiddle.Controls.Add(this.dbxSimsaja);
            this.panMiddle.Controls.Add(this.xLabel11);
            this.panMiddle.Controls.Add(this.xLabel2);
            this.panMiddle.Controls.Add(this.xLabel4);
            this.panMiddle.Controls.Add(this.emkSimsaMagamTime);
            this.panMiddle.Controls.Add(this.xLabel6);
            this.panMiddle.Controls.Add(this.emkToiwonTime);
            this.panMiddle.Controls.Add(this.xLabel7);
            this.panMiddle.Controls.Add(this.dtpToiwonDate);
            this.panMiddle.Controls.Add(this.xLabel8);
            this.panMiddle.Controls.Add(this.dtpGaToiwonDate);
            this.panMiddle.Controls.Add(this.xLabel10);
            this.panMiddle.Controls.Add(this.txtPkinp1001);
            this.panMiddle.Controls.Add(this.xLabel50);
            this.panMiddle.Controls.Add(this.xLabel9);
            this.panMiddle.Controls.Add(this.dbxSimsajaName);
            this.panMiddle.Controls.Add(this.dbxGwa);
            this.panMiddle.Controls.Add(this.dbxGwaName);
            this.panMiddle.Controls.Add(this.dbxBedNo);
            this.panMiddle.Controls.Add(this.dbxJaewonIlsu);
            this.panMiddle.Controls.Add(this.dbxHoCode);
            this.panMiddle.Controls.Add(this.dbxHoDong);
            this.panMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMiddle.Location = new System.Drawing.Point(0, 0);
            this.panMiddle.Name = "panMiddle";
            this.panMiddle.Size = new System.Drawing.Size(613, 159);
            this.panMiddle.TabIndex = 339;
            // 
            // grdINP1001
            // 
            this.grdINP1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell78,
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
            this.xEditGridCell10,
            this.xEditGridCell126,
            this.xEditGridCell127,
            this.xEditGridCell128,
            this.xEditGridCell129,
            this.xEditGridCell130,
            this.xEditGridCell131,
            this.xEditGridCell132,
            this.xEditGridCell46,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell17,
            this.xEditGridCell18});
            this.grdINP1001.ColPerLine = 36;
            this.grdINP1001.Cols = 36;
            this.grdINP1001.ControlBinding = true;
            this.grdINP1001.FixedRows = 1;
            this.grdINP1001.HeaderHeights.Add(21);
            this.grdINP1001.Location = new System.Drawing.Point(593, 14);
            this.grdINP1001.Name = "grdINP1001";
            this.grdINP1001.QuerySQL = resources.GetString("grdINP1001.QuerySQL");
            this.grdINP1001.Rows = 2;
            this.grdINP1001.Size = new System.Drawing.Size(577, 104);
            this.grdINP1001.TabIndex = 36;
            this.grdINP1001.Visible = false;
            this.grdINP1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdINP1001_RowFocusChanged);
            this.grdINP1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1001_QueryStarting);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "pkinp1001";
            this.xEditGridCell55.HeaderText = "pkinp1001";
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "bunho";
            this.xEditGridCell56.Col = 1;
            this.xEditGridCell56.HeaderText = "bunho";
            this.xEditGridCell56.IsUpdCol = false;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "ipwon_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.Col = 2;
            this.xEditGridCell57.HeaderText = "ipwon_date";
            this.xEditGridCell57.IsUpdCol = false;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "ipwon_time";
            this.xEditGridCell58.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell58.Col = 3;
            this.xEditGridCell58.HeaderText = "ipwon_time";
            this.xEditGridCell58.IsUpdCol = false;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "ipwon_type";
            this.xEditGridCell59.Col = 4;
            this.xEditGridCell59.HeaderText = "ipwon_type";
            this.xEditGridCell59.IsUpdCol = false;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "ipwon_gwa";
            this.xEditGridCell60.Col = 5;
            this.xEditGridCell60.HeaderText = "ipwon_gwa";
            this.xEditGridCell60.IsUpdCol = false;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.BindControl = this.dbxGwa;
            this.xEditGridCell61.CellName = "gwa";
            this.xEditGridCell61.Col = 6;
            this.xEditGridCell61.HeaderText = "gwa";
            this.xEditGridCell61.IsUpdCol = false;
            // 
            // dbxGwa
            // 
            this.dbxGwa.Location = new System.Drawing.Point(118, 3);
            this.dbxGwa.Name = "dbxGwa";
            this.dbxGwa.Size = new System.Drawing.Size(52, 21);
            this.dbxGwa.TabIndex = 19;
            this.dbxGwa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "ho_dong1";
            this.xEditGridCell62.Col = 7;
            this.xEditGridCell62.HeaderText = "ho_dong1";
            this.xEditGridCell62.IsUpdCol = false;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.BindControl = this.dbxHoCode;
            this.xEditGridCell63.CellName = "ho_code1";
            this.xEditGridCell63.Col = 8;
            this.xEditGridCell63.HeaderText = "ho_code1";
            this.xEditGridCell63.IsUpdCol = false;
            // 
            // dbxHoCode
            // 
            this.dbxHoCode.Location = new System.Drawing.Point(449, 4);
            this.dbxHoCode.Name = "dbxHoCode";
            this.dbxHoCode.Size = new System.Drawing.Size(38, 21);
            this.dbxHoCode.TabIndex = 24;
            this.dbxHoCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.BindControl = this.dbxBedNo;
            this.xEditGridCell78.CellName = "bed_no";
            this.xEditGridCell78.Col = 23;
            this.xEditGridCell78.HeaderText = "bed_no";
            this.xEditGridCell78.IsUpdCol = false;
            // 
            // dbxBedNo
            // 
            this.dbxBedNo.Location = new System.Drawing.Point(489, 4);
            this.dbxBedNo.Name = "dbxBedNo";
            this.dbxBedNo.Size = new System.Drawing.Size(24, 21);
            this.dbxBedNo.TabIndex = 25;
            this.dbxBedNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.BindControl = this.dtpSimsaMagamDate;
            this.xEditGridCell65.CellName = "simsa_magam_date";
            this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell65.Col = 10;
            this.xEditGridCell65.HeaderText = "simsa_magam_date";
            // 
            // dtpSimsaMagamDate
            // 
            this.dtpSimsaMagamDate.IsJapanYearType = true;
            this.dtpSimsaMagamDate.Location = new System.Drawing.Point(118, 51);
            this.dtpSimsaMagamDate.Name = "dtpSimsaMagamDate";
            this.dtpSimsaMagamDate.Size = new System.Drawing.Size(108, 20);
            this.dtpSimsaMagamDate.TabIndex = 43;
            this.dtpSimsaMagamDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpSimsaMagamDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpSimsaMagamDate_DataValidating);
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.BindControl = this.emkSimsaMagamTime;
            this.xEditGridCell66.CellName = "simsa_magam_time";
            this.xEditGridCell66.Col = 11;
            this.xEditGridCell66.HeaderText = "simsa_magam_time";
            // 
            // emkSimsaMagamTime
            // 
            this.emkSimsaMagamTime.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkSimsaMagamTime.Location = new System.Drawing.Point(227, 51);
            this.emkSimsaMagamTime.Mask = "HH:MI";
            this.emkSimsaMagamTime.Name = "emkSimsaMagamTime";
            this.emkSimsaMagamTime.Size = new System.Drawing.Size(42, 20);
            this.emkSimsaMagamTime.TabIndex = 44;
            this.emkSimsaMagamTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.BindControl = this.dbxSimsaja;
            this.xEditGridCell67.CellName = "simsaja";
            this.xEditGridCell67.Col = 12;
            this.xEditGridCell67.HeaderText = "simsaja";
            // 
            // dbxSimsaja
            // 
            this.dbxSimsaja.Location = new System.Drawing.Point(383, 51);
            this.dbxSimsaja.Name = "dbxSimsaja";
            this.dbxSimsaja.Size = new System.Drawing.Size(58, 21);
            this.dbxSimsaja.TabIndex = 29;
            this.dbxSimsaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.BindControl = this.dbxSimsajaName;
            this.xEditGridCell68.CellName = "simsaja_name";
            this.xEditGridCell68.Col = 13;
            this.xEditGridCell68.HeaderText = "simsaja_name";
            this.xEditGridCell68.IsUpdCol = false;
            // 
            // dbxSimsajaName
            // 
            this.dbxSimsajaName.Location = new System.Drawing.Point(444, 51);
            this.dbxSimsajaName.Name = "dbxSimsajaName";
            this.dbxSimsajaName.Size = new System.Drawing.Size(90, 21);
            this.dbxSimsajaName.TabIndex = 30;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.BindControl = this.dtpGaToiwonDate;
            this.xEditGridCell69.CellName = "ga_toiwon_date";
            this.xEditGridCell69.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell69.Col = 14;
            this.xEditGridCell69.HeaderText = "ga_toiwon_date";
            // 
            // dtpGaToiwonDate
            // 
            this.dtpGaToiwonDate.IsJapanYearType = true;
            this.dtpGaToiwonDate.Location = new System.Drawing.Point(393, 93);
            this.dtpGaToiwonDate.Name = "dtpGaToiwonDate";
            this.dtpGaToiwonDate.Size = new System.Drawing.Size(114, 20);
            this.dtpGaToiwonDate.TabIndex = 40;
            this.dtpGaToiwonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpGaToiwonDate.Visible = false;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.BindControl = this.dtpToiwonDate;
            this.xEditGridCell70.CellName = "toiwon_date";
            this.xEditGridCell70.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell70.Col = 15;
            this.xEditGridCell70.HeaderText = "toiwon_date";
            // 
            // dtpToiwonDate
            // 
            this.dtpToiwonDate.IsJapanYearType = true;
            this.dtpToiwonDate.Location = new System.Drawing.Point(118, 75);
            this.dtpToiwonDate.Name = "dtpToiwonDate";
            this.dtpToiwonDate.Size = new System.Drawing.Size(108, 20);
            this.dtpToiwonDate.TabIndex = 41;
            this.dtpToiwonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.BindControl = this.emkToiwonTime;
            this.xEditGridCell71.CellName = "toiwon_time";
            this.xEditGridCell71.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell71.Col = 16;
            this.xEditGridCell71.HeaderText = "toiwon_time";
            // 
            // emkToiwonTime
            // 
            this.emkToiwonTime.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkToiwonTime.Location = new System.Drawing.Point(227, 75);
            this.emkToiwonTime.Mask = "HH:MI";
            this.emkToiwonTime.Name = "emkToiwonTime";
            this.emkToiwonTime.Size = new System.Drawing.Size(42, 20);
            this.emkToiwonTime.TabIndex = 42;
            this.emkToiwonTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.BindControl = this.cboSimsaMagamGubun;
            this.xEditGridCell72.CellName = "simsa_magam_yn";
            this.xEditGridCell72.Col = 17;
            this.xEditGridCell72.HeaderText = "simsa_magam_yn";
            // 
            // cboSimsaMagamGubun
            // 
            this.cboSimsaMagamGubun.ItemHeight = 13;
            this.cboSimsaMagamGubun.Location = new System.Drawing.Point(118, 27);
            this.cboSimsaMagamGubun.Name = "cboSimsaMagamGubun";
            this.cboSimsaMagamGubun.Size = new System.Drawing.Size(151, 21);
            this.cboSimsaMagamGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSimsaMagamGubun.TabIndex = 14;
            this.cboSimsaMagamGubun.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102 \r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE" +
                "()\r\n   AND CODE_TYPE = \'SIMSA_MAGAM_GUBUN\'";
            this.cboSimsaMagamGubun.SelectedIndexChanged += new System.EventHandler(this.cboSimsaMagamGubun_SelectedIndexChanged);
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "drg_yn";
            this.xEditGridCell73.Col = 18;
            this.xEditGridCell73.HeaderText = "drg_yn";
            this.xEditGridCell73.IsUpdCol = false;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "drg_no";
            this.xEditGridCell74.Col = 19;
            this.xEditGridCell74.HeaderText = "drg_no";
            this.xEditGridCell74.IsUpdCol = false;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "date_from";
            this.xEditGridCell75.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell75.Col = 20;
            this.xEditGridCell75.HeaderText = "date_from";
            this.xEditGridCell75.IsUpdCol = false;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "date_to";
            this.xEditGridCell76.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell76.Col = 21;
            this.xEditGridCell76.HeaderText = "date_to";
            this.xEditGridCell76.IsUpdCol = false;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.BindControl = this.dbxGwaName;
            this.xEditGridCell77.CellName = "gwa_name";
            this.xEditGridCell77.Col = 22;
            this.xEditGridCell77.HeaderText = "gwa_name";
            this.xEditGridCell77.IsUpdCol = false;
            // 
            // dbxGwaName
            // 
            this.dbxGwaName.Location = new System.Drawing.Point(172, 3);
            this.dbxGwaName.Name = "dbxGwaName";
            this.dbxGwaName.Size = new System.Drawing.Size(97, 21);
            this.dbxGwaName.TabIndex = 20;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.BindControl = this.dbxJaewonIlsu;
            this.xEditGridCell10.CellName = "jaewon_ilsu";
            this.xEditGridCell10.Col = 24;
            this.xEditGridCell10.HeaderText = "jaewon_ilsu";
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // dbxJaewonIlsu
            // 
            this.dbxJaewonIlsu.Location = new System.Drawing.Point(118, 99);
            this.dbxJaewonIlsu.Name = "dbxJaewonIlsu";
            this.dbxJaewonIlsu.Size = new System.Drawing.Size(92, 21);
            this.dbxJaewonIlsu.TabIndex = 22;
            this.dbxJaewonIlsu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "jaewon_flag";
            this.xEditGridCell126.Col = 28;
            this.xEditGridCell126.HeaderText = "jaewon_flag";
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "old_simsa_magam_yn";
            this.xEditGridCell127.Col = 29;
            this.xEditGridCell127.HeaderText = "old_simsa_magam_yn";
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "old_simsa_magam_date";
            this.xEditGridCell128.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell128.Col = 30;
            this.xEditGridCell128.HeaderText = "old_simsa_magam_date";
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "old_simsa_magam_time";
            this.xEditGridCell129.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell129.Col = 31;
            this.xEditGridCell129.HeaderText = "old_simsa_magam_time";
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "old_ga_toiwon_date";
            this.xEditGridCell130.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell130.Col = 9;
            this.xEditGridCell130.HeaderText = "old_ga_toiwon_date";
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "old_toiwon_date";
            this.xEditGridCell131.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell131.Col = 25;
            this.xEditGridCell131.HeaderText = "old_toiwon_date";
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "old_toiwon_time";
            this.xEditGridCell132.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell132.Col = 26;
            this.xEditGridCell132.HeaderText = "old_toiwon_time";
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.BindControl = this.dbxHoDong;
            this.xEditGridCell46.CellName = "ho_dong1_name";
            this.xEditGridCell46.Col = 27;
            this.xEditGridCell46.HeaderText = "ho_dong1_name";
            this.xEditGridCell46.IsUpdCol = false;
            // 
            // dbxHoDong
            // 
            this.dbxHoDong.Location = new System.Drawing.Point(383, 4);
            this.dbxHoDong.Name = "dbxHoDong";
            this.dbxHoDong.Size = new System.Drawing.Size(64, 21);
            this.dbxHoDong.TabIndex = 23;
            this.dbxHoDong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "ho_grade1";
            this.xEditGridCell11.Col = 32;
            this.xEditGridCell11.HeaderText = "ho_grade1";
            this.xEditGridCell11.IsUpdCol = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "doctor";
            this.xEditGridCell12.Col = 33;
            this.xEditGridCell12.HeaderText = "doctor";
            this.xEditGridCell12.IsUpdCol = false;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "toiwon_res_date";
            this.xEditGridCell17.Col = 34;
            this.xEditGridCell17.HeaderText = "toiwon_res_date";
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "toiwon_res_time";
            this.xEditGridCell18.Col = 35;
            this.xEditGridCell18.HeaderText = "toiwon_res_time";
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel11.Location = new System.Drawing.Point(287, 4);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(90, 21);
            this.xLabel11.TabIndex = 11;
            this.xLabel11.Text = "病      室";
            this.xLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(22, 27);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(90, 21);
            this.xLabel2.TabIndex = 1;
            this.xLabel2.Text = "審査区分";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Location = new System.Drawing.Point(22, 51);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(90, 21);
            this.xLabel4.TabIndex = 3;
            this.xLabel4.Text = "審査締切日";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(22, 3);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(90, 21);
            this.xLabel6.TabIndex = 7;
            this.xLabel6.Text = "診  療  科";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Location = new System.Drawing.Point(22, 75);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(90, 21);
            this.xLabel7.TabIndex = 8;
            this.xLabel7.Text = "退院日付";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Location = new System.Drawing.Point(22, 99);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(90, 21);
            this.xLabel8.TabIndex = 9;
            this.xLabel8.Text = "在院日数";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel10.Location = new System.Drawing.Point(297, 93);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(90, 21);
            this.xLabel10.TabIndex = 12;
            this.xLabel10.Text = "仮  退  院";
            this.xLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel10.Visible = false;
            // 
            // txtPkinp1001
            // 
            this.txtPkinp1001.Location = new System.Drawing.Point(513, 93);
            this.txtPkinp1001.Name = "txtPkinp1001";
            this.txtPkinp1001.Size = new System.Drawing.Size(34, 20);
            this.txtPkinp1001.TabIndex = 37;
            this.txtPkinp1001.Visible = false;
            // 
            // xLabel50
            // 
            this.xLabel50.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel50.EdgeRounding = false;
            this.xLabel50.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel50.Location = new System.Drawing.Point(214, 99);
            this.xLabel50.Name = "xLabel50";
            this.xLabel50.Size = new System.Drawing.Size(21, 21);
            this.xLabel50.TabIndex = 34;
            this.xLabel50.Text = "日";
            this.xLabel50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel9.Location = new System.Drawing.Point(287, 51);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(90, 21);
            this.xLabel9.TabIndex = 13;
            this.xLabel9.Text = "審  査  者";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkBAS0102
            // 
            this.fwkBAS0102.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkBAS0102.FormText = "コード照会";
            this.fwkBAS0102.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkBAS0102.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "コード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 193;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "コード名称";
            // 
            // fwkDisGubun
            // 
            this.fwkDisGubun.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkDisGubun.FormText = "コード照会";
            this.fwkDisGubun.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkDisGubun.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "code";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo3.HeaderText = "コード";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "code_name";
            this.findColumnInfo4.ColWidth = 229;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo4.HeaderText = "コード名称";
            // 
            // fwkHunabGubun
            // 
            this.fwkHunabGubun.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6,
            this.findColumnInfo7,
            this.findColumnInfo8});
            this.fwkHunabGubun.FormText = "後払区分";
            this.fwkHunabGubun.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkHunabGubun.ServerFilter = true;
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo5.ColName = "hunab_gubun";
            this.findColumnInfo5.ColWidth = 101;
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo5.HeaderText = "後払区分";
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "hunab_gubun_name";
            this.findColumnInfo6.ColWidth = 268;
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo6.HeaderText = "後払区分名称";
            // 
            // findColumnInfo7
            // 
            this.findColumnInfo7.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo7.ColName = "gubun";
            this.findColumnInfo7.HeaderText = "保険種別";
            // 
            // findColumnInfo8
            // 
            this.findColumnInfo8.ColName = "gubun_name";
            this.findColumnInfo8.ColWidth = 207;
            this.findColumnInfo8.HeaderText = "保険種別名称";
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(288, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.Size = new System.Drawing.Size(325, 34);
            this.btnList.TabIndex = 6;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "pay_gibon";
            this.xEditGridCell134.HeaderText = "pay_gibon";
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "pay_gwanri";
            this.xEditGridCell82.Col = 54;
            this.xEditGridCell82.HeaderText = "pay_gwanri";
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "pay_house";
            this.xEditGridCell83.Col = 55;
            this.xEditGridCell83.HeaderText = "pay_house";
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "pay_drg";
            this.xEditGridCell135.Col = 1;
            this.xEditGridCell135.HeaderText = "pay_drg";
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "pay_jusa";
            this.xEditGridCell136.Col = 2;
            this.xEditGridCell136.HeaderText = "pay_jusa";
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "pay_chuchi";
            this.xEditGridCell137.Col = 3;
            this.xEditGridCell137.HeaderText = "pay_chuchi";
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "pay_susul";
            this.xEditGridCell138.Col = 4;
            this.xEditGridCell138.HeaderText = "pay_susul";
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "pay_machee";
            this.xEditGridCell86.Col = 58;
            this.xEditGridCell86.HeaderText = "pay_machee";
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "pay_lab";
            this.xEditGridCell139.Col = 5;
            this.xEditGridCell139.HeaderText = "pay_lab";
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "pay_xray";
            this.xEditGridCell140.Col = 6;
            this.xEditGridCell140.HeaderText = "pay_xray";
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "pay_ihak";
            this.xEditGridCell141.Col = 7;
            this.xEditGridCell141.HeaderText = "pay_ihak";
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "pay_etc";
            this.xEditGridCell142.Col = 8;
            this.xEditGridCell142.HeaderText = "pay_etc";
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "pay_ipwon";
            this.xEditGridCell143.Col = 9;
            this.xEditGridCell143.HeaderText = "pay_ipwon";
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "pay_tot";
            this.xEditGridCell144.Col = 10;
            this.xEditGridCell144.HeaderText = "pay_tot";
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "bon_tot";
            this.xEditGridCell145.Col = 11;
            this.xEditGridCell145.HeaderText = "bon_tot";
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "gongbi_gibon";
            this.xEditGridCell93.Col = 60;
            this.xEditGridCell93.HeaderText = "gongbi_gibon";
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "gongbi_gwanri";
            this.xEditGridCell94.Col = 61;
            this.xEditGridCell94.HeaderText = "gongbi_gwanri";
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "gongbi_house";
            this.xEditGridCell95.Col = 62;
            this.xEditGridCell95.HeaderText = "gongbi_house";
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "gongbi_drg";
            this.xEditGridCell96.Col = 63;
            this.xEditGridCell96.HeaderText = "gongbi_drg";
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "gongbi_jusa";
            this.xEditGridCell97.Col = 64;
            this.xEditGridCell97.HeaderText = "gongbi_jusa";
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "gongbi_chuchi";
            this.xEditGridCell98.Col = 65;
            this.xEditGridCell98.HeaderText = "gongbi_chuchi";
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "gongbi_susul";
            this.xEditGridCell99.Col = 66;
            this.xEditGridCell99.HeaderText = "gongbi_susul";
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "gongbi_machee";
            this.xEditGridCell100.Col = 67;
            this.xEditGridCell100.HeaderText = "gongbi_machee";
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "gongbi_lab";
            this.xEditGridCell101.Col = 12;
            this.xEditGridCell101.HeaderText = "gongbi_lab";
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "gongbi_xray";
            this.xEditGridCell102.Col = 13;
            this.xEditGridCell102.HeaderText = "gongbi_xray";
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "gongbi_ihak";
            this.xEditGridCell103.Col = 26;
            this.xEditGridCell103.HeaderText = "gongbi_ihak";
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "gongbi_etc";
            this.xEditGridCell104.Col = 27;
            this.xEditGridCell104.HeaderText = "gongbi_etc";
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "gongbi_ipwon";
            this.xEditGridCell105.Col = 29;
            this.xEditGridCell105.HeaderText = "gongbi_ipwon";
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "gongbi_tot";
            this.xEditGridCell106.Col = 50;
            this.xEditGridCell106.HeaderText = "gongbi_tot";
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "gongbi_bon";
            this.xEditGridCell107.Col = 51;
            this.xEditGridCell107.HeaderText = "gongbi_bon";
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "non_pay_gibon";
            this.xEditGridCell148.Col = 14;
            this.xEditGridCell148.HeaderText = "non_pay_gibon";
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "non_pay_gwanri";
            this.xEditGridCell84.Col = 56;
            this.xEditGridCell84.HeaderText = "non_pay_gwanri";
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "non_pay_house";
            this.xEditGridCell85.Col = 57;
            this.xEditGridCell85.HeaderText = "non_pay_house";
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "non_pay_drg";
            this.xEditGridCell149.Col = 15;
            this.xEditGridCell149.HeaderText = "non_pay_drg";
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellName = "non_pay_jusa";
            this.xEditGridCell150.Col = 16;
            this.xEditGridCell150.HeaderText = "non_pay_jusa";
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "non_pay_chuchi";
            this.xEditGridCell151.Col = 17;
            this.xEditGridCell151.HeaderText = "non_pay_chuchi";
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "non_pay_susul";
            this.xEditGridCell152.Col = 18;
            this.xEditGridCell152.HeaderText = "non_pay_susul";
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "non_pay_machee";
            this.xEditGridCell87.Col = 59;
            this.xEditGridCell87.HeaderText = "non_pay_machee";
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "non_pay_lab";
            this.xEditGridCell153.Col = 19;
            this.xEditGridCell153.HeaderText = "non_pay_lab";
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellName = "non_pay_xray";
            this.xEditGridCell154.Col = 20;
            this.xEditGridCell154.HeaderText = "non_pay_xray";
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "non_pay_ihak";
            this.xEditGridCell155.Col = 21;
            this.xEditGridCell155.HeaderText = "non_pay_ihak";
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "non_pay_etc";
            this.xEditGridCell156.Col = 22;
            this.xEditGridCell156.HeaderText = "non_pay_etc";
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "non_pay_ipwon";
            this.xEditGridCell157.Col = 23;
            this.xEditGridCell157.HeaderText = "non_pay_ipwon";
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellName = "non_pay_tot";
            this.xEditGridCell158.Col = 24;
            this.xEditGridCell158.HeaderText = "non_pay_tot";
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellName = "non_pay_room";
            this.xEditGridCell159.Col = 25;
            this.xEditGridCell159.HeaderText = "non_pay_room";
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "non_pay_cloth";
            this.xEditGridCell162.Col = 28;
            this.xEditGridCell162.HeaderText = "non_pay_cloth";
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellName = "non_pay_munseo";
            this.xEditGridCell164.Col = 30;
            this.xEditGridCell164.HeaderText = "non_pay_munseo";
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.CellName = "non_pay_metrial";
            this.xEditGridCell165.Col = 31;
            this.xEditGridCell165.HeaderText = "non_pay_metrial";
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellName = "non_pay_lab_etc";
            this.xEditGridCell166.Col = 32;
            this.xEditGridCell166.HeaderText = "non_pay_lab_etc";
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "non_pay_drg_etc";
            this.xEditGridCell167.Col = 33;
            this.xEditGridCell167.HeaderText = "non_pay_drg_etc";
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellName = "non_pay_bunman";
            this.xEditGridCell168.Col = 34;
            this.xEditGridCell168.HeaderText = "non_pay_bunman";
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellName = "non_pay_yebang";
            this.xEditGridCell169.Col = 35;
            this.xEditGridCell169.HeaderText = "non_pay_yebang";
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellName = "non_pay_etc_etc";
            this.xEditGridCell170.Col = 36;
            this.xEditGridCell170.HeaderText = "non_pay_etc_etc";
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellName = "non_pay_tot_etc";
            this.xEditGridCell171.Col = 37;
            this.xEditGridCell171.HeaderText = "non_pay_tot_etc";
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellName = "siksa_yoyang_amt";
            this.xEditGridCell172.Col = 38;
            this.xEditGridCell172.HeaderText = "siksa_yoyang_amt";
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.CellName = "siksa_budam_amt";
            this.xEditGridCell173.Col = 39;
            this.xEditGridCell173.HeaderText = "siksa_budam_amt";
            // 
            // xEditGridCell174
            // 
            this.xEditGridCell174.CellName = "tax_daesang_amt";
            this.xEditGridCell174.Col = 40;
            this.xEditGridCell174.HeaderText = "tax_daesang_amt";
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellName = "tot_amt";
            this.xEditGridCell175.Col = 41;
            this.xEditGridCell175.HeaderText = "tot_amt";
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.CellName = "bon_tot_amt";
            this.xEditGridCell176.Col = 42;
            this.xEditGridCell176.HeaderText = "bon_tot_amt";
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellName = "out_amt";
            this.xEditGridCell177.Col = 43;
            this.xEditGridCell177.HeaderText = "out_amt";
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellName = "gi_amt";
            this.xEditGridCell178.Col = 44;
            this.xEditGridCell178.HeaderText = "gi_amt";
            // 
            // xEditGridCell179
            // 
            this.xEditGridCell179.CellName = "dis_amt";
            this.xEditGridCell179.Col = 45;
            this.xEditGridCell179.HeaderText = "dis_amt";
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "hunab_amt";
            this.xEditGridCell32.Col = 53;
            this.xEditGridCell32.HeaderText = "hunab_amt";
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellName = "tax_amt";
            this.xEditGridCell180.Col = 46;
            this.xEditGridCell180.HeaderText = "tax_amt";
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.CellName = "sil_bon_amt";
            this.xEditGridCell181.Col = 47;
            this.xEditGridCell181.HeaderText = "sil_bon_amt";
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "misu_amt";
            this.xEditGridCell31.Col = 52;
            this.xEditGridCell31.HeaderText = "misu_amt";
            // 
            // xEditGridCell182
            // 
            this.xEditGridCell182.CellName = "gatoiwon_amt";
            this.xEditGridCell182.Col = 48;
            this.xEditGridCell182.HeaderText = "gatoiwon_amt";
            // 
            // xEditGridCell183
            // 
            this.xEditGridCell183.CellName = "sil_amt";
            this.xEditGridCell183.Col = 49;
            this.xEditGridCell183.HeaderText = "sil_amt";
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "dpc_rate_amt";
            this.xEditGridCell110.Col = 68;
            this.xEditGridCell110.HeaderText = "dpc_rate_amt";
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "dpc_rate_bon_amt";
            this.xEditGridCell111.Col = 69;
            this.xEditGridCell111.HeaderText = "dpc_rate_bon_amt";
            // 
            // btnToiwonCancel
            // 
            this.btnToiwonCancel.ImageIndex = 8;
            this.btnToiwonCancel.ImageList = this.ImageList;
            this.btnToiwonCancel.Location = new System.Drawing.Point(2, 3);
            this.btnToiwonCancel.Name = "btnToiwonCancel";
            this.btnToiwonCancel.Size = new System.Drawing.Size(89, 28);
            this.btnToiwonCancel.TabIndex = 337;
            this.btnToiwonCancel.Text = "退院取消";
            this.btnToiwonCancel.Click += new System.EventHandler(this.btnToiwonCancel_Click);
            // 
            // layLoadToiwonResDate
            // 
            this.layLoadToiwonResDate.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4,
            this.singleLayoutItem5});
            this.layLoadToiwonResDate.QuerySQL = resources.GetString("layLoadToiwonResDate.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "toiwon_res_date";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "toiwon_res_time";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "sigi_magam_date";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "sys_date";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "sys_time";
            // 
            // panButton
            // 
            this.panButton.Controls.Add(this.btnReTrans);
            this.panButton.Controls.Add(this.btnList);
            this.panButton.Controls.Add(this.btnToiwonCancel);
            this.panButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButton.DrawBorder = true;
            this.panButton.Location = new System.Drawing.Point(2, 315);
            this.panButton.Name = "panButton";
            this.panButton.Size = new System.Drawing.Size(615, 36);
            this.panButton.TabIndex = 339;
            // 
            // btnReTrans
            // 
            this.btnReTrans.ImageIndex = 9;
            this.btnReTrans.ImageList = this.ImageList;
            this.btnReTrans.Location = new System.Drawing.Point(91, 3);
            this.btnReTrans.Name = "btnReTrans";
            this.btnReTrans.Size = new System.Drawing.Size(103, 28);
            this.btnReTrans.TabIndex = 338;
            this.btnReTrans.Text = "会計再転送";
            this.btnReTrans.Click += new System.EventHandler(this.btnReTrans_Click);
            // 
            // INP3003U00
            // 
            this.Controls.Add(this.panButton);
            this.Controls.Add(this.pnlInIpwonInfo);
            this.Controls.Add(this.pnlIpwonInfo);
            this.Controls.Add(this.pnlPatientInfo);
            this.Name = "INP3003U00";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(619, 353);
            this.Load += new System.EventHandler(this.INP3003U00_Load);
            this.UserChanged += new System.EventHandler(this.INP3003U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.INP3003U00_ScreenOpen);
            this.pnlPatientInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlIpwonInfo.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tpgIpwonList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001Past)).EndInit();
            this.tpgSang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2002)).EndInit();
            this.pnlInIpwonInfo.ResumeLayout(false);
            this.panMiddle.ResumeLayout(false);
            this.panMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layINP1002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCardAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layINP1005)).EndInit();
            this.panButton.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수

		private string mMsg = "";
		private string mCap = "";

		/*************************************
		 * 수납코드 하드코딩 const 변수
		 * ***********************************/
        //private const string IpwonTransCode        = "11";    // 입원전입금
        //private const string JungganGumCode        = "13";    // 중간금
        //private const string ToiwonGumCode         = "14";    // 퇴원금
        //private const string GaToiwonGumCode       = "15";    // 가퇴원금
        //private const string ChugaGumCode          = "16";    // 추가금(퇴원후 유형변경 추가금)
        //private const string HunabGumCode          = "21";    // 후불금
        //private const string DisGumCode            = "22";    // 감면금
        //private const string MisuGumCode           = "23";    // 미수금
        //private const string JunggiDisGumCode      = "24";    // 정기청구 감면금
        //private const string JunggiHunabGumCode    = "25";    // 정기청구 후납금
        //private const string SuHyeulDisCode        = "31";    // 수혈공제
        //private const string GaSuipGumCode         = "51";    // 가수입금
        //private const string IpwonTransReturnCode  = "61";    // 입원전입금환불
        //private const string JungganGumReturnCode  = "62";    // 중간금환불
        //private const string ToiwonGumReturnCode   = "63";    // 퇴원금환불
        //private const string GaToiwonGumReturnCode = "64";    // 가퇴원금환불
        //private const string EtcReturnCode         = "65";    // 기타환불금
        //private const string OldMisuGumCode        = "99";    // 구미수금

		/*************************************
		 * 심사구분 하드코딩 const 변수
		 * ***********************************/
		private const string Jaewon     = "1";
		private const string SimsaMagam = "2";
		private const string GaToiwon   = "3";
		private const string Toiwon     = "4";

		/*************************************
		 * 점수 코드 조회 관련 const 변수 
		 * ***********************************/
		/* Nu코드 (200 입원 영수증 기준 ) */
        //private const string Gibon       = "01";
        //private const string Drg         = "02";
        //private const string Jusa        = "03";
        //private const string Chuchi      = "04";
        //private const string Susul       = "05";
        //private const string Lab         = "06";
        //private const string XRay        = "07";
        //private const string IHak        = "08";
        //private const string Etc         = "10";
        //private const string Ipwon       = "11";
        //private const string SiksaYoyang = "12";
        //private const string SiksaBudam  = "13";
        //private const string Room        = "20";
        //private const string Yuji        = "21";
        //private const string Buchum      = "22";
        //private const string Cloth       = "23";
        //private const string Tel         = "24";
        //private const string Munseo      = "25";
        //private const string Metrial     = "26";
        //private const string LabEtc      = "27";
        //private const string DrgEtc      = "28";
        //private const string Bunman      = "29";
        //private const string Yebang      = "30";
        //private const string EtcEtc      = "31";

		// 추가분
        //private const string Gwanri      = "40";
        //private const string House       = "50";
        //private const string Machee      = "60";

		/* 보험 비보험 */
        //private const string Pay         = "0";
        //private const string NonPay      = "1";


		/*************************************
		 * 저장이 완료 되었는지 여부
		 * 카드 입력 폼에서 넘겨받은 
		 * 레이아웃 테이블을 다시 넘겨줄지
		 * 여부를 결정한다.
		 * ***********************************/
        //private bool IsProcessUpdate = false;
        //private bool IsSendToForm    = false;
		/* 
		 * 심사 구분 변경시 e.cancel True 가 걸려도 버튼이 눌러짐
		 * ?
		 */
		//private bool IsAbleToUpdate = true;

		// 퇴원건 색
		XColor mToiwonColor = new XColor(Color.AntiqueWhite);

		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{
            this.grdINP1001.SavePerformer = new XSavePerformer(this);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
			
			base.OnLoad (e);
		}

		private void PostLoad()
		{	
			//Set Current Grid
			//Create Dyn Service Control

			this.paBox.Focus();

		}

		#endregion
		
		#region TabPage

		private void tabInfo_SelectionChanged(object sender, System.EventArgs e)
		{
			switch(tabInfo.SelectedTab.Name)
			{
				case "tpgIpwonList":
					this.grdINP2002.Visible = false;
					this.grdINP1001Past.Visible = true;
					
					break;
				case "tpgSang":
					this.grdINP1001Past.Visible = false;
					this.grdINP2002.Visible = true;
					break;
			}
		}

		#endregion

		#region ScreenOpen

		private void INP3003U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			//이전 스크린의 등록번호를 가져온다
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

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query :

					this.LoadAll();

					e.IsBaseCall = false;

					break;


				case FunctionType.Update:

                    e.IsBaseCall = false;

                    if (!this.CheckUpdate())
                    {
                        return;
                    }
                    
                    ControlProtect("", "");
                    
                    if (cboSimsaMagamGubun.GetDataValue() == SimsaMagam)
                    {
                        //오더 전송 화면 호출
                        CommonItemCollection cic = new CommonItemCollection();
                        cic.Add("bunho", paBox.BunHo);
                        XScreen.OpenScreenWithParam(this, "NURI", "INPORDERTRANS", ScreenOpenStyle.ResponseFixed, cic);

                        if (XMessageBox.Show("会計システムに退院情報を送りますか？", "転送", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            SakuraToiwonInput("I");
                        }
                    }
					
					try
					{
                        //if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "old_simsa_magam_yn") == Jaewon &&
                        //    this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "simsa_magam_yn") == SimsaMagam )
                        //{

                        //    //this.SetStatusMsg((NetInfo.Language == LangMode.Ko ? "퇴원약 발생처리를 실시하고 있습니다." : "退院薬発生処理をしています。しばらくお待ちください。"));

                        //    //if (CreateToiwonDrug() == false)
                        //    //{
                        //    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "퇴원약발생처리에 실패하였습니다." : "退院薬発生処理に失敗しました。";
                        //    //    this.mMsg += "-" + Service.ErrFullMsg;

                        //    //    this.mCap = NetInfo.Language == LangMode.Ko ? "퇴원약발생처리" : "退院薬発生処理";

                        //    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    //    this.VisibleSettingStatusBar(false);

                        //    //    return;
                        //    //}
                        //}

						if (this.grdINP1001.SaveLayout())
						{
							this.mMsg = (NetInfo.Language == LangMode.Ko ? "정상적으로 저장 되었습니다." : "保存が完了しました。");

							XMessageBox.Show(this.mMsg, "保存", MessageBoxIcon.Information);

							e.IsSuccess = true;

                            this.LoadAll();
                            //OrcaToiwonInput();
						}
						else
						{
							this.mCap = (NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗");

                            if (mErrMsg != "")
                                XMessageBox.Show(this.mErrMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
						
							e.IsSuccess = false;
						}
					}
					finally
					{
					}

					break;
			}
		}

        private void SakuraToiwonInput(string proc_gubun)
        {
            if (this.cboSimsaMagamGubun.GetDataValue() != "2") // 심사마감이 아니면 무시
                return;

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            string t_pkinp1002 = "";

            string t_pkinp1001 = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "pkinp1001");
            string cmdText = @" SELECT A.PKINP1002
                                  FROM INP1002 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.FKINP1001 = :f_pkinp1001
                                   AND A.GUBUN_TRANS_YN = 'N' 
                                   AND A.GUBUN_TRANS_CNT = (SELECT MAX(Z.GUBUN_TRANS_CNT)
                                                      FROM INP1002 Z
                                                     WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                       AND Z.FKINP1001 = A.FKINP1001
                                                       AND Z.GUBUN_TRANS_YN = 'N' )";

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_pkinp1001", t_pkinp1001);

            object retval = Service.ExecuteScalar(cmdText, bc);

            if (!TypeCheck.IsNull(retval))
            {
                t_pkinp1002 = retval.ToString();
            }

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(proc_gubun);
            inputList.Add(this.paBox.BunHo);
            inputList.Add(this.dtpSimsaMagamDate.GetDataValue());
            inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "ho_dong1"));
            inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "ho_code1"));
            inputList.Add("");//inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "bed_no")); SAKURAには病床の情報は送らない。　20130621
            inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "ipwon_gwa"));
            inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "doctor"));   
            inputList.Add(t_pkinp1001);
            inputList.Add(UserInfo.UserID);
            inputList.Add("4"); //入院：１、転入：２、退院：４
            inputList.Add(grdINP1001Past.GetItemValue(grdINP1001Past.CurrentRowNumber, "result_code"));

            if (!Service.ExecuteProcedure("PR_IFS_MAKE_IPWON_HISTORY", inputList, outputList))
            {
                this.mMsg = "SAKURAへのデータ転送に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg;
                this.mCap = "転送失敗";

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (outputList[1].ToString() != "0")
                {
                    this.mMsg = "SAKURAへのデータ転送に失敗しました。\r\n再転送を行ってください。\r\n" + outputList[1].ToString();
                    this.mCap = "転送失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
                string msgText = "00291" + outputList[0].ToString();

                //XMessageBox.Show(msgText);

                int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);


                this.mMsg = "SAKURAへのデータ転送が完了しました。";
                this.mCap = "転送完了";
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region [Orca]
        /*
        private void OrcaToiwonInput()
        {
            if (this.cboSimsaMagamYN.GetDataValue() != "4") // 퇴원이 아니면
                return;

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            string t_pkinp1002 = "";

            string t_pkinp1001 = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "pkinp1001");
            string cmdText = @" SELECT A.PKINP1002
                                  FROM INP1002 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.FKINP1001 = :f_pkinp1001
                                   AND A.GUBUN_TRANS_YN = 'N' 
                                   AND A.GUBUN_TRANS_CNT = (SELECT MAX(Z.GUBUN_TRANS_CNT)
                                                      FROM INP1002 Z
                                                     WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                       AND Z.FKINP1001 = A.FKINP1001
                                                       AND Z.GUBUN_TRANS_YN = 'N' )";
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_pkinp1001", t_pkinp1001);

            object retval = Service.ExecuteScalar(cmdText, bc);

            if (!TypeCheck.IsNull(retval))
            {
                t_pkinp1002 = retval.ToString();
            }

            inputList.Add(this.paBox.BunHo);
            inputList.Add(this.dtpToiwonDate.GetDataValue());
            inputList.Add(t_pkinp1001);
            inputList.Add(t_pkinp1002);
            inputList.Add(System.Guid.NewGuid().ToString());
            inputList.Add(System.Guid.NewGuid().ToString());
            inputList.Add(System.Guid.NewGuid().ToString());
            inputList.Add(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "doctor"));
            inputList.Add(UserInfo.UserID);

            if (!Service.ExecuteProcedure("PR_OIF_MAKE_TOIWON_INPUT", inputList, outputList))
            {
                this.mMsg = "ORCAへのデータ転送に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg;
                this.mCap = "転送失敗";

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (outputList[1].ToString() != "0")
                {
                    this.mMsg = "ORCAへのデータ転送に失敗しました。\r\n再転送を行ってください。\r\n" + outputList[1].ToString();
                    this.mCap = "転送失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                } 
                
                IHIS.Framework.tcpHelper Helper = new tcpHelper();
                Helper.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), outputList[0].ToString());

                this.mMsg = "ORCAへのデータ転送が完了しました。";
                this.mCap = "転送完了";
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        */
        #endregion
        //        private bool CreateToiwonDrug()
//        {
//            ArrayList inputList = new ArrayList();
//            ArrayList outputList = new ArrayList();

//            string cmdText = @"SELECT A.SIMSA_MAGAM_YN   SIMSA_MAGAM_YN
//	                             FROM INP1001 A
//	                            WHERE A.HOSP_CODE = :f_hosp_code
//                                  AND A.PKINP1001 = :f_fkinp1001";
            
//            BindVarCollection bc = new BindVarCollection();
//            bc.Add("f_hosp_code", EnvironInfo.HospCode);
//            bc.Add("f_fkinp1001", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"));

//            DataTable dt = Service.ExecuteDataTable(cmdText, bc);

//            if (!TypeCheck.IsNull(dt))
//            {
//                for (int i = 0; i < dt.Rows.Count; i++)
//                { 
//                    //기존 심사구분이 재원중 인경우만 퇴원약 로직을 탄다.
//                    if (dt.Rows[i]["simsa_magam_yn"].ToString() == "1")
//                    {
//                        inputList.Clear();
//                        outputList.Clear();

//                        inputList.Add(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"));
//                        inputList.Add(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "simsa_magam_date"));

//                        return Service.ExecuteProcedure("PR_INP_CREATE_TOIWON_DRUG", inputList, outputList);
//                    }
//                }
//            }
//            return true;
//        }

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:
					break;
				case FunctionType.Reset:
					
					this.ClearFlagVar();
					this.ControlProtect("", "");

					this.btnList.Focus();

					this.paBox.Focus();

					break;
			}
		}

		#endregion

		#region PatientBox

		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			this.ClearFlagVar();

			this.LoadINP1001_Past();

			if (this.grdINP1001Past.RowCount <= 0)
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원내역이 존재하지 않습니다." : "入院履歴がありません。");

				XMessageBox.Show(this.mMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				PostCallHelper.PostCall(new PostMethod(PostSelectedFail));
			}

			//			this.LoadAll();

			//this.ControlProtect(true, true);			
		}

		private void PostSelectedFail()
		{
			this.btnList.PerformClick(FunctionType.Reset);
		}

		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			// 환자번호 잘못 입력시 전부 클리어
			this.btnList.PerformClick(FunctionType.Reset);
		}

		#endregion

		#region Function

		#region GetPkInp1001
		/// <summary>
		/// 환자번호로 INP1001정보 가져오기
		/// </summary>
		/// <returns></returns>
        //private int GetPKINP1001()
        //{
        //    string msg = "";
        //    string caption = "";

        //    ArrayList inputList = new ArrayList();
        //    ArrayList outputList = new ArrayList();

        //    inputList.Add(paBox.BunHo);

        //    if (!Service.ExecuteProcedure("PR_INP_LOAD_INP1001_CNT", inputList, outputList))
        //    {
        //        msg = (NetInfo.Language == LangMode.Ko ? "서비스에러" : "取り込み中エラーが発生しました。\r\nPR_INP_LOAD_INP1001_CNT");

        //        this.SetMsg(msg, MsgType.Error);
        //        return 1;
        //    }

        //    if(outputList.Count < 1)
        //        return 1;

        //    if (outputList[0].ToString() == "")
        //    {
        //        return 1;
        //    }

        //    switch (outputList[0].ToString().ToString())
        //    {
        //        case "0": // 재원중인 환자가 아니다...
        //            msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." : "在院中の患者ではありません。");
        //            caption = (NetInfo.Language == LangMode.Ko ? "오류" : "注意");

        //            XMessageBox.Show(msg, caption);
        //            return 1;
        //        case "1": // INP1001에 재원중인데이터가 한건 있다.				
										
        //            break;
        //        default : // INP1001에 재원중인 데이터가 두건 이상이다.

        //            CommonItemCollection param = new CommonItemCollection();
        //            param.Add("bunho", this.paBox.BunHo);
        //            param.Add("jaewon_flag", "Y");

        //            XScreen.OpenScreenWithParam(this, "NURI", "INP1001Q00", ScreenOpenStyle.ResponseFixed, param);

        //            break;
        //    }

        //    return 0;
        //}

		#endregion		

		#region Clear Variable

		private void ClearFlagVar()
		{
			/*************************************
				* 저장이 완료 되었는지 여부
				* 카드 입력 폼에서 넘겨받은 
				* 레이아웃 테이블을 다시 넘겨줄지
				* 여부를 결정한다.
				* ***********************************/
            //IsProcessUpdate = false;
            //IsSendToForm = false;

			/* 
				* 심사 구분 변경시 e.cancel True 가 걸려도 버튼이 눌러짐
				* ?
				*/
			//IsAbleToUpdate = true;

		}

		#endregion

		#region ControProtect

		private void ControlProtect (string aCurSimsaMagamYN, string aOldSimsaMagamYN)
		{
			// 로우가 없는 경우 전부 프로텍트
			if (this.grdINP1001Past.RowCount == 0 ||
				aCurSimsaMagamYN == aOldSimsaMagamYN )
			{
                foreach (Control control in this.panMiddle.Controls)
				{
					if (control is IDataControl &&
						control.Name != "cboSimsaMagamGubun")
					{
						((IDataControl) control).Protect = true ;
					}
                }

                if (this.dtpToiwonDate.GetDataValue() != "")
                {
                    if (this.dtpToiwonDate.GetDataValue() == EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"))
                    {
                        this.cboSimsaMagamGubun.Protect = false;
                    }
                }

				return;
			}

			// 프로텍트 걸 기준이 될 심사 마감 YN값은 현재의 심사 마감 값

			switch (aCurSimsaMagamYN)
			{
				case Jaewon :

					// 퇴원일자 가퇴원일자 입력란 프로텍트
					this.dtpToiwonDate.Protect = true;
					this.emkToiwonTime.Protect = true;
					this.dtpGaToiwonDate.Protect = true;
					this.dtpSimsaMagamDate.Protect = true;
					this.emkSimsaMagamTime.Protect = true;

					break;

				case SimsaMagam :

					// 퇴원일자 가퇴원일자 입력란 프로텍트
					this.dtpToiwonDate.Protect = true;
					this.emkToiwonTime.Protect = true;
					this.dtpGaToiwonDate.Protect = true;

					if (aOldSimsaMagamYN == Jaewon)
					{
						this.dtpSimsaMagamDate.Protect = false;
						this.emkSimsaMagamTime.Protect = false;
					}
					else
					{
						this.dtpSimsaMagamDate.Protect = true;
						this.emkSimsaMagamTime.Protect = true;
					}

					break;

				case GaToiwon :

					// 퇴원일자 가퇴원일자 입력란 프로텍트
					this.dtpToiwonDate.Protect = true;
					this.emkToiwonTime.Protect = true;
					if (aOldSimsaMagamYN == Jaewon)
						this.dtpGaToiwonDate.Protect = false;
					else
						this.dtpGaToiwonDate.Protect = true;

					this.dtpSimsaMagamDate.Protect = true;
					this.emkSimsaMagamTime.Protect = true;

					break;

				case Toiwon :

					// 퇴원일자 가퇴원일자 입력란 프로텍트
					if (aOldSimsaMagamYN == SimsaMagam)
					{
						this.dtpToiwonDate.Protect = false;
						this.emkToiwonTime.Protect = false;
					}
					else
					{
						this.dtpToiwonDate.Protect = true;
						this.emkToiwonTime.Protect = true;
					}
					this.dtpGaToiwonDate.Protect = true;

					this.dtpSimsaMagamDate.Protect = true;
					this.emkSimsaMagamTime.Protect = true;

					break;
			}
		}

		#endregion 		

		#region CheckUpdate

		private bool CheckUpdate()
		{
			#region INP1001 체크
			DialogResult result ;
            DateTime ipwonDate;
            DateTime simsaDate;
            DateTime toiwonDate;

			// 심사마감 구분에 따른 데이터 체크
			if (this.grdINP1001.GetRowState(this.grdINP1001.CurrentRowNumber) != DataRowState.Unchanged)
			{
				this.mMsg = "";

				switch (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "simsa_magam_yn"))
				{
					case Jaewon :

						break;

					case SimsaMagam :

						#region 심사 마감

						// 심사마감 일자 및 심사마감 시간 데이터 널 체크
						if (this.dtpSimsaMagamDate.GetDataValue() == "")
						{
							this.mMsg = NetInfo.Language == LangMode.Ko ? "심사마감일자를 입력해 주세요." : "審査締切日付を入力してください。";

							this.SetMsg(this.mMsg, MsgType.Error);

							break;
						}

						if (this.emkSimsaMagamTime.GetDataValue() == "")
						{
							this.mMsg = NetInfo.Language == LangMode.Ko ? "심사마감시간을 입력해 주세요." : "審査締切時間を入力してください。";

							this.SetMsg(this.mMsg, MsgType.Error);

							break;
						}



                        // 퇴원일자 벨리데이션 체크 => 퇴원일자는 심사 마감일보다 과거가 될 수 없음.
                        ipwonDate = DateTime.Parse(grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));
                        simsaDate = DateTime.Parse(this.dtpSimsaMagamDate.GetDataValue());

                        if (simsaDate < ipwonDate)
                        {
                            this.mMsg = NetInfo.Language == LangMode.Ko ? "심사마감일은 입원일보다 과거 일 수 없습니다." :
                                                     "審査締切日付は入院日より後の日付を登録してください。";

                            this.SetMsg(this.mMsg, MsgType.Error);

                            break;
                        }

                        if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "simsa_magam_date") != this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "toiwon_res_date"))
                        {
                            this.mMsg = NetInfo.Language == LangMode.Ko ? "퇴원예정일이 " + this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "toiwon_res_date") + "로 지정되어있습니다." :
                                                                          "退院予定日が" + this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "toiwon_res_date") + "で指定されています。";
                            this.mMsg += NetInfo.Language == LangMode.Ko ? "\n이대로 심사마감 하시겠습니까?" : "\nこのまま、審査締め切りをしますか?";

                            this.mCap = NetInfo.Language == LangMode.Ko ? "정산처리" : "審査締め切り";

                            result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result != DialogResult.Yes)
                            {
                                return false;
                            }

                            this.mMsg = "";
                        }


						#endregion

						break;

                    //case GaToiwon :

                    //    #region 가퇴원

                    //    if (this.dtpGaToiwonDate.GetDataValue() == "")
                    //    {
                    //        this.mMsg = NetInfo.Language == LangMode.Ko ? "가퇴원일자를 입력해 주세요" : "仮退院日付を入力してください。";

                    //        this.SetMsg(this.mMsg, MsgType.Error);

                    //        break;
                    //    }

                    //    #endregion

                    //    break;

					case Toiwon :

						#region 퇴원

						if (this.dtpToiwonDate.GetDataValue() == "" || !TypeCheck.IsDateTime(this.dtpToiwonDate.GetDataValue()))
						{
							this.mMsg = NetInfo.Language == LangMode.Ko ? "퇴원일자를 입력해 주세요." : "退院日付を入力してください。";

							this.SetMsg(this.mMsg, MsgType.Error);

							break;
						}

						if (this.emkToiwonTime.GetDataValue() == "")
						{
							this.mMsg = NetInfo.Language == LangMode.Ko ? "퇴원시간을 입력해 주세요." : "退院時間を入力してください。";

							this.SetMsg(this.mMsg, MsgType.Error);

							break;
						}

						// 퇴원일자 벨리데이션 체크 => 퇴원일자는 심사 마감일보다 과거가 될 수 없음.
						toiwonDate = DateTime.Parse(this.dtpToiwonDate.GetDataValue());
						simsaDate  = DateTime.Parse(this.dtpSimsaMagamDate.GetDataValue());

						if (toiwonDate < simsaDate)
						{
							this.mMsg = NetInfo.Language == LangMode.Ko ? "퇴원일은 심사마감일보다 과거 일 수 없습니다." : 
                                　　　　　　　　　　　　　　　　　　　　　"退院日付は審査締切日付より後の日付を登録してください。";

							this.SetMsg(this.mMsg, MsgType.Error);

							break;
						}

						if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_date") != this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "toiwon_res_date"))
						{
							this.mMsg = NetInfo.Language == LangMode.Ko ? "퇴원예정일이 " + this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "toiwon_res_date") + "로 지정되어있습니다." :
								                                          "退院予定日が" + this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "toiwon_res_date") + "で指定されています。";
							this.mMsg += NetInfo.Language == LangMode.Ko ? "\n이대로 퇴원처리 하시겠습니까?" : "\nこのまま、退院処理をしますか?";

							this.mCap = NetInfo.Language == LangMode.Ko ? "퇴원처리" : "退院処理";

							result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

							if (result != DialogResult.Yes)
							{
								return false;
							}

							this.mMsg = "";
						}
						
						#endregion

						break;

				}

				if (this.mMsg != "")
				{
					this.mCap = NetInfo.Language == LangMode.Ko ? "저장 실패" : "保存失敗";
					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					return false;
				}
			}

			#endregion			
			
			return true;
		}

		#endregion		

		#region 퇴원예고 일자 로드

		private bool GetToiwonResDate (string aPkinp1001, ref string aToiwonResDate, ref string aToiwonResTime )
		{
            this.layLoadToiwonResDate.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.layLoadToiwonResDate.SetBindVarValue("f_pkinp1001", aPkinp1001);

			this.layLoadToiwonResDate.QueryLayout();

			string toiwonResDate = this.layLoadToiwonResDate.GetItemValue("toiwon_res_date").ToString();
			string toiwonResTime = this.layLoadToiwonResDate.GetItemValue("toiwon_res_time").ToString();
			string sigiMagamDate = this.layLoadToiwonResDate.GetItemValue("sigi_magam_date").ToString();
			string sysDate       = this.layLoadToiwonResDate.GetItemValue("sys_date").ToString();
			string sysTime       = this.layLoadToiwonResDate.GetItemValue("sys_time").ToString();

			if (toiwonResDate == "")
			{
				if (sigiMagamDate == "")
				{
					toiwonResDate = sysDate;
				}
				else
				{
					toiwonResDate = sigiMagamDate ;
				}
			}

			if (toiwonResTime == "")
			{
				toiwonResTime = sysTime ;
			}


			if (toiwonResDate != "" && toiwonResTime != "")
			{
				aToiwonResDate = toiwonResDate ;
				aToiwonResTime = toiwonResTime ;

				return true;
			}

			return false;

		}

		#endregion


		
		#endregion
	
		#region Command

		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch(command)
			{
				case "PastIpwonResult" :
					this.txtPkinp1001.SetEditValue(commandParam["pkinp1001"]);
					this.txtPkinp1001.AcceptData();
					break;
			}

			return base.Command (command, commandParam);
		}

		#endregion

		#region Load Data

		private void LoadINP1001()
		{
			this.grdINP1001.QueryLayout(false);

			// INP1001 정보 로드시 퇴원환자이고 퇴원일자가 전표일자보다 이전일경우 
			// 퇴원 취소 불가
			// 프로텍트 걸어 버림.
			//ControlProtect(true, false);

			if (this.grdINP1001.RowCount == 0)
			{
				ControlProtect ("", "");
			}
			else
			{
				ControlProtect (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "simsa_magam_yn"),
					            this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "old_simsa_magam_yn"));
			}
		}

		private void LoadINP1001_Past()
		{
			try
			{
				this.grdINP1001Past.QueryLayout(false);
			}
			catch (Exception ex)
			{
				//https://sofiamedix.atlassian.net/browse/MED-10610
				//XMessageBox.Show(ex.Message);
			}
        }


		private void LoadAll()
		{
			this.SetMsg("");

			this.LoadINP1001();

			/*********************************************
			 * 현재 PatientSeleted 이벤트가 두번 발생한다.
			 * 원인 모름, 따라서 탭을 만들때 이벤트 삭제
			 * *******************************************/

			this.paBox.PatientSelected -= new System.EventHandler(this.paBox_PatientSelected);

			this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);

            this.grdINP2002.QueryLayout(false);
		}

		
		#endregion

		#region Grid Event

		#region INP3005_Grid

		#region Grid RowFocusChange

		private void grdINP1001Past_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			this.LoadAll();
		}

		#endregion

		#endregion

		#region INP1001_Grid

		#region Grid RowFocusChanged

		private void grdINP1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            this.ControlProtect(this.grdINP1001.GetItemString(e.CurrentRow, "simsa_magam_yn"), this.grdINP1001.GetItemString(e.CurrentRow, "old_simsa_magam_yn"));
		}

		#endregion

		#region INP1001Past Grid

		private void grdINP1001Past_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			XEditGrid grd = sender as XEditGrid;

			switch (e.ColName)
			{
				case "ipwon_date":

					if (grd.GetItemString(e.RowNumber, "toiwon_date") != "")
					{
						e.BackColor = mToiwonColor.Color;
					}

					break;
			}
		}

		#endregion

		#endregion

		#endregion

		#region OpenScreen

		#endregion

		#region XButton

		#region 퇴원취소

		private void btnToiwonCancel_Click(object sender, System.EventArgs e)
		{
			if (this.grdINP1001Past.RowCount <= 0 ||
				this.grdINP1001Past.CurrentRowNumber < 0 ||
				this.grdINP1001.RowCount <= 0 ||
				this.grdINP1001.CurrentRowNumber < 0)
			{
				return ;
			}

			if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "simsa_magam_yn", DataBufferType.OriginalBuffer) != "4")
			{
				this.mMsg = NetInfo.Language == LangMode.Ko ? "퇴원완료된 입원건만 취소가 가능합니다." : 
                    　　　　　　　　　　　　　　　　　　　　　"退院処理が完了された入院情報のみ取消が可能です。";
				this.mCap = NetInfo.Language == LangMode.Ko ? "퇴원취소" : "退院取消";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "simsa_magam_yn", DataBufferType.OriginalBuffer) !=
				this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "simsa_magam_yn") )
			{
				this.mMsg = "▶ " +
					(NetInfo.Language == LangMode.Ko ? "입원일 : " : "入院日 : ") +
					this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "ipwon_date") + ", " +
					(NetInfo.Language == LangMode.Ko ? "입원유형 : " : "入院タイプ : ") +
					this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "ipwon_type_name") + "\n" +
					"================================================================\n";

				this.mMsg += NetInfo.Language == LangMode.Ko ? "환자의 심사구분(재원구분)이 변경되었습니다. 이대로 퇴원취소처리를 하시겠습니까?"
					: "患者様の審査区分(在院区分)が変更されてます。\nこのまま退院取消をしますか?";
				this.mCap = NetInfo.Language == LangMode.Ko ? "퇴원취소" : "退院取消";

				if (XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					return;
				}
			}
			else
			{
				this.mMsg = "▶ " +
					        (NetInfo.Language == LangMode.Ko ? "입원일 : " : "入院日 : ") +
					        this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "ipwon_date") + ", " +
					        (NetInfo.Language == LangMode.Ko ? "입원유형 : " : "入院タイプ : ") +
					        this.grdINP1001Past.GetItemString(grdINP1001Past.CurrentRowNumber, "ipwon_type_name") + "\n" +
					"================================================================\n";

				this.mMsg += (NetInfo.Language == LangMode.Ko ? "퇴원취소처리를 실행하시겠습니까?" : "退院取消処理を実施しますか?");

				this.mCap = NetInfo.Language == LangMode.Ko ? "퇴원취소" : "退院取消";

				if (XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					return;
				}
			}
            //당일 퇴원환자의경우에 회계위한 퇴원취소인지, 병실로 돌려보낼 퇴원취소인지 물어본다.

            if (this.dtpToiwonDate.GetDataValue() != "")
            {
                //if (this.dtpToiwonDate.GetDataValue() == EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"))
                //{
                DialogResult dr = XMessageBox.Show("会計再処理の為の退院取消しの場合にのみ 「Yes」 ボタンをクリックしてください。\r\n" +
                                                   "この場合には患者は病室画面には表示されません。\r\n"+
                                                   "患者を病室に戻すには 「No」 ボタンをクリックし、審査区分を「在院中」に変更してください。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                //}
            }
            
            if (ToiwonCancel() == true)
			{

				this.mMsg = NetInfo.Language == LangMode.Ko ? "처리가 완료되었습니다." : 
                                                              "処理が完了しました。\r\n　会計システムでも「退院取消」を行ってください。";

				this.mCap = NetInfo.Language == LangMode.Ko ? "퇴원취소" : "退院取消";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

				this.LoadINP1001_Past();
			}
			else
			{
				this.mMsg = NetInfo.Language == LangMode.Ko ? "처리에 실패하였습니다." : "処理に失敗しました。";
				this.mMsg += "-" + Service.ErrFullMsg;
				this.mCap = NetInfo.Language == LangMode.Ko ? "퇴원취소" : "退院取消";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

        private bool ToiwonCancel()
        {
            string cmdText = "";
            BindVarCollection bc = new BindVarCollection();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            string t_pkinp1001 = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001");

            inputList.Add(t_pkinp1001);
            inputList.Add(UserInfo.UserID);

            try
            {
                //Service.BeginTransaction();

                if (!Service.ExecuteProcedure("PR_INP_TOIWON_CANCEL", inputList, outputList))
                    throw new Exception();

                if (outputList != null)
                {
                    if (outputList[0].ToString() != "0")
                    {
                        throw new Exception();                        
                    }
                }

                // 복수보험의 퇴원취소처리 
                cmdText = @"SELECT A.PKINP1001
                                      FROM INP1001 A
                                     WHERE A.HOSP_CODE = :f_hosp_code                                       
                                       AND A.FK_INP_KEY = ( SELECT Z.FK_INP_KEY
                                                              FROM INP1001 Z
                                                             WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                               AND Z.PKINP1001 = :f_pkinp1001  
                                                               AND Z.JAEWON_FLAG = 'Y' --위에서 퇴원취소처리 했으므로... 
                                                               AND NVL(Z.CANCEL_YN, 'N') = 'N' ) 
                                       AND A.JAEWON_FLAG = 'N'
                                       AND NVL(A.CANCEL_YN, 'N') = 'N'";

                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_pkinp1001", t_pkinp1001);

                DataTable dt = Service.ExecuteDataTable(cmdText, bc);

                if (!TypeCheck.IsNull(dt))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string t_pkinp1001_2 = dt.Rows[i]["pkinp1001"].ToString();

                        if (t_pkinp1001 != t_pkinp1001_2)
                        {
                            inputList.Clear();
                            outputList.Clear();

                            inputList.Add(t_pkinp1001_2);
                            inputList.Add(UserInfo.UserID);

                            if (!Service.ExecuteProcedure("PR_INP_TOIWON_CANCEL", inputList, outputList))
                                throw new Exception();
                        }
                    }
                }

                //Service.CommitTransaction();
            }
            catch
            {
               // Service.RollbackTransaction();

                return false;
            }

            return true;     
        }
		#endregion

		#region XDatePicker

		private void dtpToiwonDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			// 퇴원일자는 심사마감일 보다 미래가 될 수는 없겠지?

			if (e.DataValue != "")
			{
			}
		}

		private void dtpGaToiwonDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			// 요건 언제가 될지 모르는 것이기 때문에....
		}

		private void dtpSimsaMagamDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			// 벨리데이팅 처리를 해야 하는데...
			// 일단 여기는 미래일자의 심사마감을 막는걸로 할까?
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
            if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
            {
                return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

        #region UserChange

        private void INP3003U00_UserChanged(object sender, System.EventArgs e)
		{
			// 지금은 없음. 알아서 채울것.
			this.btnList.PerformClick(FunctionType.Reset);     // 초기화
		}

		#endregion

		#region Load

		private void INP3003U00_Load(object sender, System.EventArgs e)
		{
			// TabPage Init
			this.grdINP2002.FixedCols = 2;

			this.ControlProtect("", "");

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		#endregion

		#region XComboBox

		#region SimsaMagamCombo

		private void cboSimsaMagamGubun_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			/*********************************************************************************
			 * 
			 *  심사마감 구분 변경시 체크
			 *      1. 식이 마감이 되었는지 여부
			 *      2  입원유형이 "0", "1", "2"인경우
			 *          1) 심사마감이 재원중에서 퇴원으로 바뀐경우
			 *               " 심사마감후 퇴원가능" 메세지 출력
			 *          2) 심사마감이 가퇴원에서 퇴원으로 바뀐경우
			 *               " 심사마감후 퇴원가능" 메세지 출력
			 *          3) 심사마감이 퇴원에서 뭔가로 바뀐경우 => 재원환자만 RETRIEVE 한다?
			 * 
			 * *******************************************************************************/
			/* 벨리데이팅 죽이기 위한 플레그 변수 셋팅 */


			string systime = "";
			string sysdate = "";

			string toiwonResDate = "";
			string toiwonResTime = "";
			string oldSimsaMagamYN = NURI.ChkData.ChkSimsaMagam_INP1001(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"));

            //this.ControlProtect(e.DataValue, oldSimsaMagamYN);

            //if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_type") == "0" ||
            //    this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_type") == "1" ||
            //    this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_type") == "2"   )
            //{
            //    switch (oldSimsaMagamYN)
            //    {
            //        case Jaewon:    // 재원중

            //            // 심사구분이 재원중에서 퇴원으로 바뀌는 경우
            //            //if (e.DataValue == Toiwon)
            //            //{
            //            //    this.mMsg = (NetInfo.Language == LangMode.Ko ? "심사 마감후 퇴원이 가능합니다." : "審査締切をしてから退院処理を行ってください。");
							
            //            //    this.SetMsg(this.mMsg, MsgType.Error);

            //            //    e.Cancel = true;

            //            //    this.IsAbleToUpdate = false;

            //            //    return;
            //            //}
            //            //else if(e.DataValue == SimsaMagam)
            //            //{
            //            //    if (XMessageBox.Show("会計システムに退院情報を送信しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            //            //    {
            //            //        SakuraToiwonInput("I");
            //            //    }
            //            //}

            //            break;
            //        case SimsaMagam:   // 심사마감
            //            break;
            //        case GaToiwon:   // 가퇴원

            //            //// 심사구분이 가퇴원에서 퇴원으로 바뀌는 경우
            //            //if (e.DataValue == Toiwon)
            //            //{
            //            //    this.mMsg = (NetInfo.Language == LangMode.Ko ? "심사 마감후 퇴원이 가능합니다." : "審査締切をしてから退院処理を行ってください。");
							
            //            //    this.SetMsg(this.mMsg, MsgType.Error);

            //            //    e.Cancel = true;

            //            //    this.IsAbleToUpdate = false;

            //            //    return;
            //            //}

            //            break;
            //        case Toiwon:   // 퇴원						

            //            break;
            //    }
            //}

            //this.IsAbleToUpdate = true;

			switch (e.DataValue)
			{
				case Jaewon :

					// 가퇴원일자, 퇴원일자, 챠트 퇴원일, 심사마감일, 심사마감시간 => NULL
					// 재원플레그 => Y
                    
					this.dtpGaToiwonDate.SetEditValue("");
					this.dtpGaToiwonDate.AcceptData();

					this.dtpToiwonDate.SetEditValue("");
					this.dtpToiwonDate.AcceptData();
					this.emkToiwonTime.SetEditValue("");
					this.emkToiwonTime.AcceptData();
                    
					this.dtpSimsaMagamDate.SetDataValue("");
					this.emkSimsaMagamTime.SetDataValue("");
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_date", "");
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_time", "");

					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jaewon_flag", "Y");

					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsaja", "");
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsaja_name", "");
					this.dbxSimsaja.SetDataValue("");
					this.dbxSimsajaName.SetDataValue("");

					break;

				case SimsaMagam :

					if (oldSimsaMagamYN == Toiwon || oldSimsaMagamYN == SimsaMagam )
					{
						// 퇴원시 심사마감이 완료된 상태이므로, 단순히 퇴원일자를 널로, 
						// 재원플레그를 Y로 바꾸는것 만으로 가능하다.
						this.dtpToiwonDate.SetEditValue("");
						this.dtpToiwonDate.AcceptData();

						this.emkToiwonTime.SetEditValue("");
						this.emkToiwonTime.AcceptData();
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jaewon_flag", "Y");

						break;
					}
						// 이전이 가퇴원
					else if (oldSimsaMagamYN == GaToiwon)
					{
						this.dtpGaToiwonDate.SetEditValue("");
						this.dtpGaToiwonDate.AcceptData();
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jaewon_flag", "Y");

						break;
					}

					// 심사 마감일자 및 마감시간 입력
					if (!this.GetToiwonResDate(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"), ref sysdate, ref systime))
					{
                        sysdate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                        systime = EnvironInfo.GetSysDateTime().ToString("HHmm");
					}

                    //this.dtpSimsaMagamDate.SetDataValue(sysdate);
                    //this.emkSimsaMagamTime.SetDataValue(systime);
                    //this.dbxSimsaja.SetDataValue(UserInfo.UserID);
                    //this.dbxSimsajaName.SetDataValue(UserInfo.UserName);
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_date", dtpSimsaMagamDate.GetDataValue());
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_time", emkSimsaMagamTime.Text);
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsaja", UserInfo.UserID);
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsaja_name", UserInfo.UserName);

                    //오더 전송 화면 호출
                    CommonItemCollection cic = new CommonItemCollection();
                    cic.Add("bunho", paBox.BunHo);
                    XScreen.OpenScreenWithParam(this, "NURI", "INPORDERTRANS", ScreenOpenStyle.ResponseFixed, cic);

					break;

				case GaToiwon :

					string gaToiwonDate = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ga_toiwon_date");
					string oldGaToiwonDate = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "old_ga_toiwon_date");

					// 심사 마감일자 및 마감시간 입력
					if (this.GetToiwonResDate(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"), ref sysdate, ref systime) == false)
					{
                        sysdate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                        systime = EnvironInfo.GetSysDateTime().ToString("HHmm");
					}

					// 가퇴원 일자는 최초 한번 입력한 그 날자가 되어야 함.
					if (gaToiwonDate == "")
					{
						if (oldGaToiwonDate == "")
						{
							this.dtpGaToiwonDate.SetEditValue(sysdate);
							this.dtpGaToiwonDate.AcceptData();
						}
						else
						{
							this.dtpGaToiwonDate.SetEditValue(oldGaToiwonDate);
							this.dtpGaToiwonDate.AcceptData();
						}
					}

					// 재원 플레그
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jaewon_flag", "N");

					this.dtpToiwonDate.SetEditValue("");
					this.dtpToiwonDate.AcceptData();
					this.emkToiwonTime.SetEditValue("");
					this.emkToiwonTime.AcceptData();

					this.dtpGaToiwonDate.Focus();
					this.dtpGaToiwonDate.SelectAll();

					break;

				case Toiwon :

					string toiwonDate      = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_date");
					string toiwonTime      = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_time");
					string oldToiwonDate   = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "old_toiwon_date");
					string oldToiwonTime   = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "old_toiwon_time");

					// 심사 마감일자 및 마감시간 입력
					if (this.GetToiwonResDate(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"), ref sysdate, ref systime) == false)
					{
                        sysdate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                        systime = EnvironInfo.GetSysDateTime().ToString("HHmm");
					}

					// 퇴원일자, 퇴원시간 셋팅
					if (toiwonDate == "")
					{
						if (oldToiwonDate == "")
						{
							this.dtpToiwonDate.SetEditValue(sysdate);
							this.dtpToiwonDate.AcceptData();
							this.emkToiwonTime.SetEditValue(systime);
							this.emkToiwonTime.AcceptData();
						}
						else
						{
							this.dtpToiwonDate.SetEditValue(oldToiwonDate);
							this.dtpToiwonDate.AcceptData();
							this.emkToiwonTime.SetEditValue(oldToiwonTime);
							this.emkToiwonTime.AcceptData();
						}	
					}
					
					// 재원플레그 N
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jaewon_flag", "N");
					
					// 가퇴원일자/챠트퇴원일자 복원
					this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ga_toiwon_date",
						this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "old_ga_toiwon_date"));

					this.dtpToiwonDate.Focus();
					this.dtpToiwonDate.SelectAll();

					break;
			}

			this.SetMsg("");

		}

		#endregion

        private void grdINP1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP1001.SetBindVarValue("f_pkinp1001", this.grdINP1001Past.GetItemString(this.grdINP1001Past.CurrentRowNumber, "pkinp1001"));
        }
	

		#endregion

        #region QueryStarting
        private void grdINP1001Past_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP1001Past.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP1001Past.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }
        
        private void grdINP2002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP2002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP2002.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdINP2002.SetBindVarValue("f_gwa", this.grdINP1001Past.GetItemString(this.grdINP1001Past.CurrentRowNumber, "gwa"));
        
        }
        #endregion

        #region btnOrca_Click
        private void btnReTrans_Click(object sender, EventArgs e)
        {
            SakuraToiwonInput("U");
            //OrcaToiwonInput();
        }
        #endregion

        #region XSavePerformer
        string mErrMsg = "";
        private class XSavePerformer : ISavePerformer
        {
            private INP3003U00 parent;

            public XSavePerformer(INP3003U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                parent.mErrMsg = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case '1':/* INP1001 업데이트 */

                        /**************************************************************
                         * 심사 마감 INP1001 업데이트 이때
                         * INP1002 의 SIMSA_MAGAM_YN이 'N'으로 되어 있는지
                         * 여부를 체크하고 되어 있지 않다면 자동으로 업데이트 해준다.
                         ***************************************************************/

                        /**************************************************************
                         * 너스콜 관련 이전 심사마감 가져온다
                         **************************************************************/
                        //                        cmdText = @"SELECT A.SIMSA_MAGAM_YN
                        //               	                      FROM INP1001 A
                        //               	                     WHERE A.HOSP_CODE = :f_hosp_code 
                        //                                       AND A.PKINP1001 = :f_pkinp1001";

                        //                        object t_last_simsa_magam_yn = Service.ExecuteScalar(cmdText, item.BindVarList);

                        //                        if (Service.ErrCode != 0)
                        //                        {
                        //                            XMessageBox.Show(Service.ErrFullMsg, "保存失敗", MessageBoxIcon.Error);
                        //                            return false;
                        //                        }

                        ArrayList inputList = new ArrayList();
                        ArrayList outputList = new ArrayList();

                        inputList.Add(item.BindVarList["q_user_id"].VarValue);
                        inputList.Add(item.BindVarList["f_pkinp1001"].VarValue);
                        inputList.Add(item.BindVarList["f_simsa_magam_date"].VarValue);
                        inputList.Add(item.BindVarList["f_simsa_magam_time"].VarValue);
                        inputList.Add(item.BindVarList["f_simsa_magam_yn"].VarValue);
                        inputList.Add(item.BindVarList["f_toiwon_date"].VarValue);
                        inputList.Add(item.BindVarList["f_toiwon_time"].VarValue);
                        inputList.Add(item.BindVarList["f_ga_toiwon_date"].VarValue);

                        if (!Service.ExecuteProcedure("PR_INP_PROCESS_TOIWON", inputList, outputList))
                        {
                            parent.mErrMsg = Service.ErrFullMsg;
                            if (outputList.Count > 0)
                            {
                                if (TypeCheck.IsNull(outputList[0]))
                                    parent.mErrMsg += "\r\n" + outputList[0].ToString();
                            }
                            return false;
                        }

                        if (outputList.Count > 0)
                        {
                            if (outputList[0].ToString() != "0")
                            {
                                if (!TypeCheck.IsNull(outputList[1]))
                                    parent.mErrMsg += "\r\n" + outputList[1].ToString();
                                return false;
                            }
                        }

                        // 복수보험의 퇴원처리 
                        cmdText = @"SELECT A.PKINP1001
                                      FROM INP1001 A
                                     WHERE A.HOSP_CODE = :f_hosp_code                                       
                                       AND A.FK_INP_KEY = ( SELECT Z.FK_INP_KEY
                                                              FROM INP1001 Z
                                                             WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                               AND Z.PKINP1001 = :f_pkinp1001  
                                                               AND Z.JAEWON_FLAG = 'N' 
                                                               AND NVL(Z.CANCEL_YN, 'N') = 'N' ) 
                                       AND A.JAEWON_FLAG = 'Y'
                                       AND NVL(A.CANCEL_YN, 'N') = 'N'";

                        DataTable dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

                        if (!TypeCheck.IsNull(dt))
                        {
                            String tPKINP1001 = "";
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                tPKINP1001 = dt.Rows[i]["pkinp1001"].ToString();

                                if (tPKINP1001 != item.BindVarList["f_pkinp1001"].VarValue)
                                {
                                    inputList.Clear();
                                    outputList.Clear();

                                    inputList.Add(item.BindVarList["q_user_id"].VarValue);
                                    inputList.Add(tPKINP1001);
                                    inputList.Add(item.BindVarList["f_simsa_magam_date"].VarValue);
                                    inputList.Add(item.BindVarList["f_simsa_magam_time"].VarValue);
                                    inputList.Add(item.BindVarList["f_simsa_magam_yn"].VarValue);
                                    inputList.Add(item.BindVarList["f_toiwon_date"].VarValue);
                                    inputList.Add(item.BindVarList["f_toiwon_time"].VarValue);
                                    inputList.Add(item.BindVarList["f_ga_toiwon_date"].VarValue);

                                    if (!Service.ExecuteProcedure("PR_INP_PROCESS_TOIWON", inputList, outputList))
                                    {
                                        parent.mErrMsg = Service.ErrFullMsg;
                                        if (outputList.Count > 0)
                                        {
                                            if (TypeCheck.IsNull(outputList[0]))
                                                parent.mErrMsg += "\r\n" + outputList[0].ToString();
                                        }
                                        return false;
                                    }

                                    if (outputList.Count > 0)
                                    {
                                        if (outputList[0].ToString() != "0")
                                        {
                                            if (!TypeCheck.IsNull(outputList[1]))
                                                parent.mErrMsg += "\r\n" + outputList[1].ToString();
                                            return false;
                                        }
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

        private void cboSimsaMagamGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oldSimsaMagamYN = NURI.ChkData.ChkSimsaMagam_INP1001(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"));

            switch (cboSimsaMagamGubun.GetDataValue())
            {
                case Jaewon:

                    dtpSimsaMagamDate.Protect = true;
                    emkSimsaMagamTime.Protect = true;
                    dtpToiwonDate.Protect = true;
                    emkToiwonTime.Protect = true;


                    grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_date", "");
                    grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_time", "");
                    grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsaja", "");
                    grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsaja_name", "");
                    grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "toiwon_date", "");
                    grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "toiwon_time", "");
                    grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jaewon_flag", "Y");
                    grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_yn", Jaewon);
                    grdINP1001.AcceptData();

                    dtpGaToiwonDate.SetEditValue("");
                    dtpGaToiwonDate.AcceptData();


                    break;


                case SimsaMagam:

                        dtpSimsaMagamDate.Protect = false;
                        emkSimsaMagamTime.Protect = false;
                        dtpToiwonDate.Protect = true;
                        emkToiwonTime.Protect = true;

                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_date", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_res_date"));
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_time", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_res_time"));
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsaja", UserInfo.UserID);
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsaja_name", UserInfo.UserName);
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "toiwon_date", "");
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "toiwon_time", "");
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jaewon_flag", "Y");
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_yn", SimsaMagam);
                        grdINP1001.AcceptData();

                        dtpSimsaMagamDate.Focus();
                        dtpSimsaMagamDate.SelectAll();
                    break;

                case Toiwon:

                    if (oldSimsaMagamYN == Jaewon)
                    {
                       XMessageBox.Show((NetInfo.Language == LangMode.Ko ? "심사 마감후 퇴원이 가능합니다." : "審査締切をしてから退院処理を行ってください。"), "お知らせ",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboSimsaMagamGubun.SetDataValue(Jaewon);
                    }
                    else
                    {
                        dtpSimsaMagamDate.Protect = true;
                        emkSimsaMagamTime.Protect = true;
                        dtpToiwonDate.Protect = false;
                        emkToiwonTime.Protect = false;

                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "toiwon_date", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_res_date"));
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "toiwon_time", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_res_time"));
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_yn", Toiwon);
                        grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jaewon_flag", "N");
                        grdINP1001.AcceptData();

                        dtpToiwonDate.Focus();
                        dtpToiwonDate.SelectAll();
                    }
                    break;

            }
        }

    }
}

