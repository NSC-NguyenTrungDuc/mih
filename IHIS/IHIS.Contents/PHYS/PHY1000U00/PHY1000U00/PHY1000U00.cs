#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.IO;
#endregion

namespace IHIS.PHYS
{
	/// <summary>
	/// PHY1000U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class PHY1000U00 : IHIS.Framework.XScreen
	{
        //Control HashTable
        string mR_SEQ = "";
        Hashtable htPHY2000;
        string mHospCode = EnvironInfo.HospCode;
        // 저장용 flag 변수 
        bool mIsUpdateSuccess = false;
        private string mMsg = "";
        private string mCap = "";
        private string mPKSCAN001 = "";

        /////////////Popup Menu ////////////////////////////////////////////////////////////////////////////
        private IHIS.X.Magic.Menus.PopupMenu popupOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 처방Grid용

		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlCenter;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlCenterLeft;
		private IHIS.Framework.XButtonList btnList;

        private IHIS.Framework.XTextBox txtInfectious;
        private IHIS.Framework.XPatientBox patBox;
		private IHIS.Framework.XFlatRadioButton rb1;
		private IHIS.Framework.XFlatRadioButton rb2;
		private IHIS.Framework.XFlatRadioButton rb3;
        private IHIS.Framework.XPanel pan1;
		private IHIS.Framework.XEditGrid grdPHY2000;
        private XPanel pnlSukoumoku;
        private XPanel pnlCenterRight;
        private XPanel pnlRightUnder;
        private XPanel xPanel9;
        private XLabel xLabel5;
        private XLabel xLabel4;
        private XPanel pnlIrainaiyou;
        private XGroupBox gbxPT;
        private XPanel pnlShuhangmog;
        private XGroupBox gbx2;
        private XGroupBox gbx1;
        private XCheckBox cbxSu_3;
        private XCheckBox cbxSu_1;
        private XCheckBox cbxBU_FLAG;
        private XFlatLabel xFlatLabel39;
        private XTextBox txtKg;
        private XFlatRadioButton rbtSu_3_2;
        private XFlatRadioButton rbtSu_3_1;
        private IContainer components;
        private XTextBox txtFrequency;
        private XTextBox txtStop_kijyun;
        private XTextBox txtConsult_comment;
        private XTextBox txtTaboo;
        private XFlatLabel xFlatLabel5;
        private XFlatLabel xFlatLabel6;
        private XFlatLabel lblGwa;
        private XFlatLabel xFlatLabel7;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
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
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XCheckBox cbxSu_2_4_c;
        private XCheckBox cbxSu_2_3;
        private XCheckBox cbxSu_2_2;
        private XCheckBox cbxSu_2_1;
        private XTextBox txtSu_2_4;
        private XEditGrid grdReha;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XEditGrid grdPT;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XGroupBox gbxST;
        private XEditGrid grdST;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XGroupBox gbxOT;
        private XEditGrid grdOT;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XPanel xPanel12;
        private XImageEditor imageEditor;
        private XEditGrid grdPHY8003;
        private XPanel pnlTopInfo;
        private XGroupBox gbxSindanmei;
        private XPanel pnlRightUnderRight;
        private XPanel xPanel4;
        private XPanel xPanel5;
        private XPanel xPanel1;
        private XPanel pnlRightUnderLeft;
        private XGroupBox gbxGenbyoureki;
        private XTextBox txtGenbyoureki;
        private XGroupBox gbxComplications;
        private XTextBox txtComplications;
        private XGroupBox gbxKioureki;
        private XTextBox txtKioureki;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell69;
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
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell99;
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
        private XEditGridCell xEditGridCell125;
        private XPanel pnlSu;
        private XTextBox txtObjective;
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
        private XEditGridCell xEditGridCell124;
        private XEditGridCell xEditGridCell146;
        private XEditGridCell xEditGridCell147;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell149;
        private ImageList imageListPopupMenu;
        private XCheckBox cbxST_FLAG;
        private XCheckBox cbxPT_FLAG;
        private XCheckBox cbxOT_FLAG;
        private XDatePicker dptKaisibi;
        private XLabel xLabel1;
        private XComboBox cboNissuu;
        private XLabel lblNalsu;
        private XButton btnStop_kijyun;
        private XButton btnInfectious;
        private XButton btnKioureki;
        private XButton btnGenbyoureki;
        private XButton btnSindanmei;
        private XButton btnTaboo;
        private XButton btnComplications;
        private XButton btnFrequency;
        private XEditGridCell xEditGridCell150;
        private string mPathNm = string.Empty;

		public PHY1000U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            grdPHY2000.SavePerformer = new XSavePerformer(this);
            grdPHY8003.SavePerformer = grdPHY2000.SavePerformer;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PHY1000U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.patBox = new IHIS.Framework.XPatientBox();
            this.lblGwa = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel7 = new IHIS.Framework.XFlatLabel();
            this.pnlCenter = new IHIS.Framework.XPanel();
            this.pnlCenterRight = new IHIS.Framework.XPanel();
            this.xPanel12 = new IHIS.Framework.XPanel();
            this.imageEditor = new IHIS.Framework.XImageEditor();
            this.pnlRightUnder = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.pnlRightUnderLeft = new IHIS.Framework.XPanel();
            this.txtConsult_comment = new IHIS.Framework.XTextBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xFlatLabel5 = new IHIS.Framework.XFlatLabel();
            this.pnlRightUnderRight = new IHIS.Framework.XPanel();
            this.txtObjective = new IHIS.Framework.XTextBox();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xFlatLabel6 = new IHIS.Framework.XFlatLabel();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlCenterLeft = new IHIS.Framework.XPanel();
            this.pnlIrainaiyou = new IHIS.Framework.XPanel();
            this.gbxST = new IHIS.Framework.XGroupBox();
            this.cbxST_FLAG = new IHIS.Framework.XCheckBox();
            this.grdST = new IHIS.Framework.XEditGrid();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.gbxPT = new IHIS.Framework.XGroupBox();
            this.cbxPT_FLAG = new IHIS.Framework.XCheckBox();
            this.grdPT = new IHIS.Framework.XEditGrid();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.gbxOT = new IHIS.Framework.XGroupBox();
            this.cbxOT_FLAG = new IHIS.Framework.XCheckBox();
            this.grdOT = new IHIS.Framework.XEditGrid();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.pnlSukoumoku = new IHIS.Framework.XPanel();
            this.gbx2 = new IHIS.Framework.XGroupBox();
            this.grdReha = new IHIS.Framework.XEditGrid();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.pnlShuhangmog = new IHIS.Framework.XPanel();
            this.gbx1 = new IHIS.Framework.XGroupBox();
            this.pnlSu = new IHIS.Framework.XPanel();
            this.cbxSu_1 = new IHIS.Framework.XCheckBox();
            this.cbxSu_2_4_c = new IHIS.Framework.XCheckBox();
            this.cbxBU_FLAG = new IHIS.Framework.XCheckBox();
            this.cbxSu_2_3 = new IHIS.Framework.XCheckBox();
            this.cbxSu_3 = new IHIS.Framework.XCheckBox();
            this.cbxSu_2_2 = new IHIS.Framework.XCheckBox();
            this.rbtSu_3_1 = new IHIS.Framework.XFlatRadioButton();
            this.cbxSu_2_1 = new IHIS.Framework.XCheckBox();
            this.rbtSu_3_2 = new IHIS.Framework.XFlatRadioButton();
            this.xFlatLabel39 = new IHIS.Framework.XFlatLabel();
            this.txtKg = new IHIS.Framework.XTextBox();
            this.txtSu_2_4 = new IHIS.Framework.XTextBox();
            this.pnlTopInfo = new IHIS.Framework.XPanel();
            this.btnInfectious = new IHIS.Framework.XButton();
            this.btnFrequency = new IHIS.Framework.XButton();
            this.btnTaboo = new IHIS.Framework.XButton();
            this.btnStop_kijyun = new IHIS.Framework.XButton();
            this.lblNalsu = new IHIS.Framework.XLabel();
            this.cboNissuu = new IHIS.Framework.XComboBox();
            this.dptKaisibi = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.gbxComplications = new IHIS.Framework.XGroupBox();
            this.btnComplications = new IHIS.Framework.XButton();
            this.txtComplications = new IHIS.Framework.XTextBox();
            this.gbxKioureki = new IHIS.Framework.XGroupBox();
            this.btnKioureki = new IHIS.Framework.XButton();
            this.txtKioureki = new IHIS.Framework.XTextBox();
            this.gbxGenbyoureki = new IHIS.Framework.XGroupBox();
            this.btnGenbyoureki = new IHIS.Framework.XButton();
            this.txtGenbyoureki = new IHIS.Framework.XTextBox();
            this.gbxSindanmei = new IHIS.Framework.XGroupBox();
            this.btnSindanmei = new IHIS.Framework.XButton();
            this.grdPHY8003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.txtInfectious = new IHIS.Framework.XTextBox();
            this.txtTaboo = new IHIS.Framework.XTextBox();
            this.txtStop_kijyun = new IHIS.Framework.XTextBox();
            this.txtFrequency = new IHIS.Framework.XTextBox();
            this.pan1 = new IHIS.Framework.XPanel();
            this.rb3 = new IHIS.Framework.XFlatRadioButton();
            this.rb2 = new IHIS.Framework.XFlatRadioButton();
            this.rb1 = new IHIS.Framework.XFlatRadioButton();
            this.grdPHY2000 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.imageListPopupMenu = new System.Windows.Forms.ImageList(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patBox)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.pnlCenterRight.SuspendLayout();
            this.xPanel12.SuspendLayout();
            this.pnlRightUnder.SuspendLayout();
            this.xPanel5.SuspendLayout();
            this.pnlRightUnderLeft.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.pnlRightUnderRight.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.xPanel9.SuspendLayout();
            this.pnlCenterLeft.SuspendLayout();
            this.pnlIrainaiyou.SuspendLayout();
            this.gbxST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdST)).BeginInit();
            this.gbxPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPT)).BeginInit();
            this.gbxOT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOT)).BeginInit();
            this.pnlSukoumoku.SuspendLayout();
            this.gbx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReha)).BeginInit();
            this.pnlShuhangmog.SuspendLayout();
            this.gbx1.SuspendLayout();
            this.pnlSu.SuspendLayout();
            this.pnlTopInfo.SuspendLayout();
            this.gbxComplications.SuspendLayout();
            this.gbxKioureki.SuspendLayout();
            this.gbxGenbyoureki.SuspendLayout();
            this.gbxSindanmei.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY8003)).BeginInit();
            this.pan1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY2000)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "body&brain.bmp");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.patBox);
            this.pnlTop.Controls.Add(this.lblGwa);
            this.pnlTop.Controls.Add(this.xFlatLabel7);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(5, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(1368, 35);
            this.pnlTop.TabIndex = 1;
            // 
            // patBox
            // 
            this.patBox.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.patBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.patBox.IsEditableBunho = false;
            this.patBox.Location = new System.Drawing.Point(2, 2);
            this.patBox.Name = "patBox";
            this.patBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.patBox.Size = new System.Drawing.Size(1079, 29);
            this.patBox.TabIndex = 3;
            // 
            // lblGwa
            // 
            this.lblGwa.ForeColor = IHIS.Framework.XColor.XMatrixLineColor;
            this.lblGwa.Location = new System.Drawing.Point(747, 2);
            this.lblGwa.Name = "lblGwa";
            this.lblGwa.Size = new System.Drawing.Size(98, 29);
            this.lblGwa.TabIndex = 24;
            // 
            // xFlatLabel7
            // 
            this.xFlatLabel7.ForeColor = IHIS.Framework.XColor.XMatrixLineColor;
            this.xFlatLabel7.Location = new System.Drawing.Point(1087, 2);
            this.xFlatLabel7.Name = "xFlatLabel7";
            this.xFlatLabel7.Size = new System.Drawing.Size(54, 29);
            this.xFlatLabel7.TabIndex = 24;
            this.xFlatLabel7.Text = "診療科 : ";
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlCenterRight);
            this.pnlCenter.Controls.Add(this.pnlCenterLeft);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.DrawBorder = true;
            this.pnlCenter.Location = new System.Drawing.Point(5, 40);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(2);
            this.pnlCenter.Size = new System.Drawing.Size(1368, 571);
            this.pnlCenter.TabIndex = 2;
            // 
            // pnlCenterRight
            // 
            this.pnlCenterRight.Controls.Add(this.xPanel12);
            this.pnlCenterRight.Controls.Add(this.pnlRightUnder);
            this.pnlCenterRight.Controls.Add(this.xPanel9);
            this.pnlCenterRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCenterRight.Location = new System.Drawing.Point(740, 2);
            this.pnlCenterRight.Name = "pnlCenterRight";
            this.pnlCenterRight.Size = new System.Drawing.Size(624, 565);
            this.pnlCenterRight.TabIndex = 8;
            // 
            // xPanel12
            // 
            this.xPanel12.Controls.Add(this.imageEditor);
            this.xPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel12.Location = new System.Drawing.Point(0, 25);
            this.xPanel12.Name = "xPanel12";
            this.xPanel12.Size = new System.Drawing.Size(624, 479);
            this.xPanel12.TabIndex = 0;
            // 
            // imageEditor
            // 
            this.imageEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageEditor.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.imageEditor.Image = ((System.Drawing.Image)(resources.GetObject("imageEditor.Image")));
            this.imageEditor.Location = new System.Drawing.Point(0, 0);
            this.imageEditor.Name = "imageEditor";
            this.imageEditor.ShowSaveButton = false;
            this.imageEditor.Size = new System.Drawing.Size(624, 479);
            this.imageEditor.TabIndex = 9;
            // 
            // pnlRightUnder
            // 
            this.pnlRightUnder.Controls.Add(this.xPanel5);
            this.pnlRightUnder.Controls.Add(this.pnlRightUnderRight);
            this.pnlRightUnder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRightUnder.Location = new System.Drawing.Point(0, 504);
            this.pnlRightUnder.Name = "pnlRightUnder";
            this.pnlRightUnder.Size = new System.Drawing.Size(624, 61);
            this.pnlRightUnder.TabIndex = 0;
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.pnlRightUnderLeft);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel5.Location = new System.Drawing.Point(0, 0);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(336, 61);
            this.xPanel5.TabIndex = 0;
            // 
            // pnlRightUnderLeft
            // 
            this.pnlRightUnderLeft.Controls.Add(this.txtConsult_comment);
            this.pnlRightUnderLeft.Controls.Add(this.xPanel1);
            this.pnlRightUnderLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightUnderLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlRightUnderLeft.Name = "pnlRightUnderLeft";
            this.pnlRightUnderLeft.Size = new System.Drawing.Size(336, 61);
            this.pnlRightUnderLeft.TabIndex = 104;
            // 
            // txtConsult_comment
            // 
            this.txtConsult_comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsult_comment.Location = new System.Drawing.Point(70, 0);
            this.txtConsult_comment.Multiline = true;
            this.txtConsult_comment.Name = "txtConsult_comment";
            this.txtConsult_comment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsult_comment.Size = new System.Drawing.Size(266, 61);
            this.txtConsult_comment.TabIndex = 94;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xFlatLabel5);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(70, 61);
            this.xPanel1.TabIndex = 103;
            // 
            // xFlatLabel5
            // 
            this.xFlatLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xFlatLabel5.ForeColor = IHIS.Framework.XColor.XMatrixLineColor;
            this.xFlatLabel5.Location = new System.Drawing.Point(0, 0);
            this.xFlatLabel5.Name = "xFlatLabel5";
            this.xFlatLabel5.Size = new System.Drawing.Size(70, 61);
            this.xFlatLabel5.TabIndex = 102;
            this.xFlatLabel5.Text = "指示事項・注意事項";
            // 
            // pnlRightUnderRight
            // 
            this.pnlRightUnderRight.Controls.Add(this.txtObjective);
            this.pnlRightUnderRight.Controls.Add(this.xPanel4);
            this.pnlRightUnderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightUnderRight.Location = new System.Drawing.Point(338, 0);
            this.pnlRightUnderRight.Name = "pnlRightUnderRight";
            this.pnlRightUnderRight.Size = new System.Drawing.Size(286, 61);
            this.pnlRightUnderRight.TabIndex = 0;
            // 
            // txtObjective
            // 
            this.txtObjective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObjective.Location = new System.Drawing.Point(36, 0);
            this.txtObjective.Multiline = true;
            this.txtObjective.Name = "txtObjective";
            this.txtObjective.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObjective.Size = new System.Drawing.Size(250, 61);
            this.txtObjective.TabIndex = 103;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xFlatLabel6);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel4.Location = new System.Drawing.Point(0, 0);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(36, 61);
            this.xPanel4.TabIndex = 0;
            // 
            // xFlatLabel6
            // 
            this.xFlatLabel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.xFlatLabel6.ForeColor = IHIS.Framework.XColor.XMatrixLineColor;
            this.xFlatLabel6.Location = new System.Drawing.Point(0, 0);
            this.xFlatLabel6.Name = "xFlatLabel6";
            this.xFlatLabel6.Size = new System.Drawing.Size(70, 61);
            this.xFlatLabel6.TabIndex = 104;
            this.xFlatLabel6.Text = "目標";
            // 
            // xPanel9
            // 
            this.xPanel9.Controls.Add(this.xLabel5);
            this.xPanel9.Controls.Add(this.xLabel4);
            this.xPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel9.Location = new System.Drawing.Point(0, 0);
            this.xPanel9.Name = "xPanel9";
            this.xPanel9.Size = new System.Drawing.Size(624, 25);
            this.xPanel9.TabIndex = 12;
            // 
            // xLabel5
            // 
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Location = new System.Drawing.Point(335, 0);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(290, 25);
            this.xLabel5.TabIndex = 5;
            this.xLabel5.Text = "ＣＴ・ＭＲＩ画像";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel4
            // 
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Location = new System.Drawing.Point(81, 0);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(255, 25);
            this.xLabel4.TabIndex = 4;
            this.xLabel4.Text = "治療部位";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCenterLeft
            // 
            this.pnlCenterLeft.Controls.Add(this.pnlIrainaiyou);
            this.pnlCenterLeft.Controls.Add(this.pnlSukoumoku);
            this.pnlCenterLeft.Controls.Add(this.pnlTopInfo);
            this.pnlCenterLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCenterLeft.DrawBorder = true;
            this.pnlCenterLeft.Location = new System.Drawing.Point(2, 2);
            this.pnlCenterLeft.Name = "pnlCenterLeft";
            this.pnlCenterLeft.Size = new System.Drawing.Size(735, 565);
            this.pnlCenterLeft.TabIndex = 7;
            // 
            // pnlIrainaiyou
            // 
            this.pnlIrainaiyou.Controls.Add(this.gbxST);
            this.pnlIrainaiyou.Controls.Add(this.gbxPT);
            this.pnlIrainaiyou.Controls.Add(this.gbxOT);
            this.pnlIrainaiyou.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlIrainaiyou.Location = new System.Drawing.Point(0, 355);
            this.pnlIrainaiyou.Name = "pnlIrainaiyou";
            this.pnlIrainaiyou.Size = new System.Drawing.Size(733, 208);
            this.pnlIrainaiyou.TabIndex = 2;
            // 
            // gbxST
            // 
            this.gbxST.Controls.Add(this.cbxST_FLAG);
            this.gbxST.Controls.Add(this.grdST);
            this.gbxST.Location = new System.Drawing.Point(492, 4);
            this.gbxST.Name = "gbxST";
            this.gbxST.Protect = true;
            this.gbxST.Size = new System.Drawing.Size(240, 196);
            this.gbxST.TabIndex = 11;
            this.gbxST.TabStop = false;
            this.gbxST.Text = "ST";
            // 
            // cbxST_FLAG
            // 
            this.cbxST_FLAG.AutoSize = true;
            this.cbxST_FLAG.Location = new System.Drawing.Point(28, 2);
            this.cbxST_FLAG.Name = "cbxST_FLAG";
            this.cbxST_FLAG.Size = new System.Drawing.Size(12, 11);
            this.cbxST_FLAG.TabIndex = 94;
            this.cbxST_FLAG.UseVisualStyleBackColor = false;
            this.cbxST_FLAG.CheckedChanged += new System.EventHandler(this.cbx_FLAG_CheckedChanged);
            // 
            // grdST
            // 
            this.grdST.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66});
            this.grdST.ColPerLine = 2;
            this.grdST.Cols = 2;
            this.grdST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdST.FixedRows = 1;
            this.grdST.HeaderHeights.Add(21);
            this.grdST.Location = new System.Drawing.Point(3, 16);
            this.grdST.Name = "grdST";
            this.grdST.QuerySQL = "SELECT \'N\' SELECTED,\r\n       A.CODE,\r\n       A.CODE_NAME\r\n  FROM OCS0132 A\r\n WHER" +
                "E A.HOSP_CODE = :f_hosp_code\r\n   AND A.CODE_TYPE = \'PHY_ST\'\r\n      ";
            this.grdST.Rows = 2;
            this.grdST.Size = new System.Drawing.Size(234, 177);
            this.grdST.TabIndex = 1;
            this.grdST.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdST.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdST_QueryStarting);
            this.grdST.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdST.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "select";
            this.xEditGridCell64.CellWidth = 41;
            this.xEditGridCell64.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell64.HeaderText = "選択";
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "code";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.HeaderText = "コード";
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellLen = 50;
            this.xEditGridCell66.CellName = "code_name";
            this.xEditGridCell66.CellWidth = 191;
            this.xEditGridCell66.Col = 1;
            this.xEditGridCell66.HeaderText = "項目";
            this.xEditGridCell66.IsUpdatable = false;
            // 
            // gbxPT
            // 
            this.gbxPT.Controls.Add(this.cbxPT_FLAG);
            this.gbxPT.Controls.Add(this.grdPT);
            this.gbxPT.Location = new System.Drawing.Point(5, 5);
            this.gbxPT.Name = "gbxPT";
            this.gbxPT.Protect = true;
            this.gbxPT.Size = new System.Drawing.Size(240, 195);
            this.gbxPT.TabIndex = 34;
            this.gbxPT.TabStop = false;
            this.gbxPT.Text = "PT";
            // 
            // cbxPT_FLAG
            // 
            this.cbxPT_FLAG.AutoSize = true;
            this.cbxPT_FLAG.Location = new System.Drawing.Point(28, 2);
            this.cbxPT_FLAG.Name = "cbxPT_FLAG";
            this.cbxPT_FLAG.Size = new System.Drawing.Size(12, 11);
            this.cbxPT_FLAG.TabIndex = 94;
            this.cbxPT_FLAG.UseVisualStyleBackColor = false;
            this.cbxPT_FLAG.CheckedChanged += new System.EventHandler(this.cbx_FLAG_CheckedChanged);
            // 
            // grdPT
            // 
            this.grdPT.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60});
            this.grdPT.ColPerLine = 2;
            this.grdPT.Cols = 2;
            this.grdPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPT.FixedRows = 1;
            this.grdPT.HeaderHeights.Add(21);
            this.grdPT.Location = new System.Drawing.Point(3, 16);
            this.grdPT.Name = "grdPT";
            this.grdPT.QuerySQL = "SELECT \'N\' SELECTED,\r\n       A.CODE,\r\n       A.CODE_NAME\r\n  FROM OCS0132 A\r\n WHER" +
                "E A.HOSP_CODE = :f_hosp_code\r\n   AND A.CODE_TYPE = \'PHY_PT\'\r\n      ";
            this.grdPT.Rows = 2;
            this.grdPT.Size = new System.Drawing.Size(234, 176);
            this.grdPT.TabIndex = 1;
            this.grdPT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdPT.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPT_QueryStarting);
            this.grdPT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdPT.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "select";
            this.xEditGridCell58.CellWidth = 41;
            this.xEditGridCell58.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell58.HeaderText = "選択";
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "code";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.HeaderText = "コード";
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellLen = 50;
            this.xEditGridCell60.CellName = "code_name";
            this.xEditGridCell60.CellWidth = 191;
            this.xEditGridCell60.Col = 1;
            this.xEditGridCell60.HeaderText = "項目";
            this.xEditGridCell60.IsUpdatable = false;
            // 
            // gbxOT
            // 
            this.gbxOT.Controls.Add(this.cbxOT_FLAG);
            this.gbxOT.Controls.Add(this.grdOT);
            this.gbxOT.Location = new System.Drawing.Point(249, 5);
            this.gbxOT.Name = "gbxOT";
            this.gbxOT.Protect = true;
            this.gbxOT.Size = new System.Drawing.Size(240, 195);
            this.gbxOT.TabIndex = 12;
            this.gbxOT.TabStop = false;
            this.gbxOT.Text = "OT";
            // 
            // cbxOT_FLAG
            // 
            this.cbxOT_FLAG.AutoSize = true;
            this.cbxOT_FLAG.Location = new System.Drawing.Point(28, 2);
            this.cbxOT_FLAG.Name = "cbxOT_FLAG";
            this.cbxOT_FLAG.Size = new System.Drawing.Size(12, 11);
            this.cbxOT_FLAG.TabIndex = 94;
            this.cbxOT_FLAG.UseVisualStyleBackColor = false;
            this.cbxOT_FLAG.CheckedChanged += new System.EventHandler(this.cbx_FLAG_CheckedChanged);
            // 
            // grdOT
            // 
            this.grdOT.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63});
            this.grdOT.ColPerLine = 2;
            this.grdOT.Cols = 2;
            this.grdOT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOT.FixedRows = 1;
            this.grdOT.HeaderHeights.Add(21);
            this.grdOT.Location = new System.Drawing.Point(3, 16);
            this.grdOT.Name = "grdOT";
            this.grdOT.QuerySQL = "SELECT \'N\' SELECTED,\r\n       A.CODE,\r\n       A.CODE_NAME\r\n  FROM OCS0132 A\r\n WHER" +
                "E A.HOSP_CODE = :f_hosp_code\r\n   AND A.CODE_TYPE = \'PHY_OT\'\r\n      ";
            this.grdOT.Rows = 2;
            this.grdOT.Size = new System.Drawing.Size(234, 176);
            this.grdOT.TabIndex = 1;
            this.grdOT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdOT.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOT_QueryStarting);
            this.grdOT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdOT.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "select";
            this.xEditGridCell61.CellWidth = 41;
            this.xEditGridCell61.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell61.HeaderText = "選択";
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "code";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.HeaderText = "コード";
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellLen = 50;
            this.xEditGridCell63.CellName = "code_name";
            this.xEditGridCell63.CellWidth = 191;
            this.xEditGridCell63.Col = 1;
            this.xEditGridCell63.HeaderText = "項目";
            this.xEditGridCell63.IsUpdatable = false;
            // 
            // pnlSukoumoku
            // 
            this.pnlSukoumoku.Controls.Add(this.gbx2);
            this.pnlSukoumoku.Controls.Add(this.pnlShuhangmog);
            this.pnlSukoumoku.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSukoumoku.Location = new System.Drawing.Point(0, 226);
            this.pnlSukoumoku.Name = "pnlSukoumoku";
            this.pnlSukoumoku.Size = new System.Drawing.Size(733, 337);
            this.pnlSukoumoku.TabIndex = 10;
            // 
            // gbx2
            // 
            this.gbx2.Controls.Add(this.grdReha);
            this.gbx2.Location = new System.Drawing.Point(382, 6);
            this.gbx2.Name = "gbx2";
            this.gbx2.Protect = true;
            this.gbx2.Size = new System.Drawing.Size(350, 125);
            this.gbx2.TabIndex = 0;
            this.gbx2.TabStop = false;
            this.gbx2.Text = "該当する疾患別リハビリテーション科";
            // 
            // grdReha
            // 
            this.grdReha.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell48,
            this.xEditGridCell56,
            this.xEditGridCell57});
            this.grdReha.ColPerLine = 2;
            this.grdReha.Cols = 2;
            this.grdReha.FixedRows = 1;
            this.grdReha.HeaderHeights.Add(21);
            this.grdReha.Location = new System.Drawing.Point(3, 16);
            this.grdReha.Name = "grdReha";
            this.grdReha.QuerySQL = "SELECT \'N\' SELECTED,\r\n       A.CODE,\r\n       A.CODE_NAME\r\n  FROM OCS0132 A\r\n WHER" +
                "E A.HOSP_CODE = :f_hosp_code\r\n   AND A.CODE_TYPE = \'PHY_REHA\'\r\n      ";
            this.grdReha.Rows = 2;
            this.grdReha.Size = new System.Drawing.Size(341, 100);
            this.grdReha.TabIndex = 0;
            this.grdReha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdReha.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdReha_QueryStarting);
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "select";
            this.xEditGridCell48.CellWidth = 41;
            this.xEditGridCell48.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell48.HeaderText = "選択";
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "code";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.HeaderText = "コード";
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellLen = 50;
            this.xEditGridCell57.CellName = "code_name";
            this.xEditGridCell57.CellWidth = 296;
            this.xEditGridCell57.Col = 1;
            this.xEditGridCell57.HeaderText = "項目";
            this.xEditGridCell57.IsUpdatable = false;
            // 
            // pnlShuhangmog
            // 
            this.pnlShuhangmog.Controls.Add(this.gbx1);
            this.pnlShuhangmog.Location = new System.Drawing.Point(0, 0);
            this.pnlShuhangmog.Name = "pnlShuhangmog";
            this.pnlShuhangmog.Size = new System.Drawing.Size(376, 131);
            this.pnlShuhangmog.TabIndex = 2;
            // 
            // gbx1
            // 
            this.gbx1.Controls.Add(this.pnlSu);
            this.gbx1.Location = new System.Drawing.Point(8, 7);
            this.gbx1.Name = "gbx1";
            this.gbx1.Protect = true;
            this.gbx1.Size = new System.Drawing.Size(365, 112);
            this.gbx1.TabIndex = 0;
            this.gbx1.TabStop = false;
            this.gbx1.Text = "主項目";
            // 
            // pnlSu
            // 
            this.pnlSu.Controls.Add(this.cbxSu_1);
            this.pnlSu.Controls.Add(this.cbxSu_2_4_c);
            this.pnlSu.Controls.Add(this.cbxBU_FLAG);
            this.pnlSu.Controls.Add(this.cbxSu_2_3);
            this.pnlSu.Controls.Add(this.cbxSu_3);
            this.pnlSu.Controls.Add(this.cbxSu_2_2);
            this.pnlSu.Controls.Add(this.rbtSu_3_1);
            this.pnlSu.Controls.Add(this.cbxSu_2_1);
            this.pnlSu.Controls.Add(this.rbtSu_3_2);
            this.pnlSu.Controls.Add(this.xFlatLabel39);
            this.pnlSu.Controls.Add(this.txtKg);
            this.pnlSu.Controls.Add(this.txtSu_2_4);
            this.pnlSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSu.Location = new System.Drawing.Point(3, 16);
            this.pnlSu.Name = "pnlSu";
            this.pnlSu.Size = new System.Drawing.Size(359, 93);
            this.pnlSu.TabIndex = 118;
            // 
            // cbxSu_1
            // 
            this.cbxSu_1.AutoSize = true;
            this.cbxSu_1.Location = new System.Drawing.Point(17, 3);
            this.cbxSu_1.Name = "cbxSu_1";
            this.cbxSu_1.Size = new System.Drawing.Size(75, 17);
            this.cbxSu_1.TabIndex = 1;
            this.cbxSu_1.Text = "個別療法";
            this.cbxSu_1.UseVisualStyleBackColor = false;
            // 
            // cbxSu_2_4_c
            // 
            this.cbxSu_2_4_c.AutoSize = true;
            this.cbxSu_2_4_c.Location = new System.Drawing.Point(179, 42);
            this.cbxSu_2_4_c.Name = "cbxSu_2_4_c";
            this.cbxSu_2_4_c.Size = new System.Drawing.Size(57, 17);
            this.cbxSu_2_4_c.TabIndex = 117;
            this.cbxSu_2_4_c.Text = "その他";
            this.cbxSu_2_4_c.UseVisualStyleBackColor = false;
            // 
            // cbxBU_FLAG
            // 
            this.cbxBU_FLAG.AutoSize = true;
            this.cbxBU_FLAG.Location = new System.Drawing.Point(17, 23);
            this.cbxBU_FLAG.Name = "cbxBU_FLAG";
            this.cbxBU_FLAG.Size = new System.Drawing.Size(75, 17);
            this.cbxBU_FLAG.TabIndex = 2;
            this.cbxBU_FLAG.Text = "物理療法";
            this.cbxBU_FLAG.UseVisualStyleBackColor = false;
            this.cbxBU_FLAG.CheckedChanged += new System.EventHandler(this.cbxBU_CheckedChanged);
            // 
            // cbxSu_2_3
            // 
            this.cbxSu_2_3.AutoSize = true;
            this.cbxSu_2_3.Location = new System.Drawing.Point(94, 42);
            this.cbxSu_2_3.Name = "cbxSu_2_3";
            this.cbxSu_2_3.Size = new System.Drawing.Size(62, 17);
            this.cbxSu_2_3.TabIndex = 116;
            this.cbxSu_2_3.Text = "低周波";
            this.cbxSu_2_3.UseVisualStyleBackColor = false;
            // 
            // cbxSu_3
            // 
            this.cbxSu_3.AutoSize = true;
            this.cbxSu_3.Location = new System.Drawing.Point(17, 68);
            this.cbxSu_3.Name = "cbxSu_3";
            this.cbxSu_3.Size = new System.Drawing.Size(75, 17);
            this.cbxSu_3.TabIndex = 3;
            this.cbxSu_3.Text = "牽引療法";
            this.cbxSu_3.UseVisualStyleBackColor = false;
            this.cbxSu_3.CheckedChanged += new System.EventHandler(this.cbxSu_3_CheckedChanged);
            // 
            // cbxSu_2_2
            // 
            this.cbxSu_2_2.AutoSize = true;
            this.cbxSu_2_2.Location = new System.Drawing.Point(179, 24);
            this.cbxSu_2_2.Name = "cbxSu_2_2";
            this.cbxSu_2_2.Size = new System.Drawing.Size(79, 17);
            this.cbxSu_2_2.TabIndex = 115;
            this.cbxSu_2_2.Text = "ホットパック";
            this.cbxSu_2_2.UseVisualStyleBackColor = false;
            // 
            // rbtSu_3_1
            // 
            this.rbtSu_3_1.Location = new System.Drawing.Point(100, 67);
            this.rbtSu_3_1.Name = "rbtSu_3_1";
            this.rbtSu_3_1.Size = new System.Drawing.Size(53, 24);
            this.rbtSu_3_1.TabIndex = 110;
            this.rbtSu_3_1.TabStop = true;
            this.rbtSu_3_1.Text = "頸椎";
            this.rbtSu_3_1.UseVisualStyleBackColor = true;
            this.rbtSu_3_1.CheckedChanged += new System.EventHandler(this.rbtSu_3_1_CheckedChanged);
            // 
            // cbxSu_2_1
            // 
            this.cbxSu_2_1.AutoSize = true;
            this.cbxSu_2_1.Location = new System.Drawing.Point(94, 24);
            this.cbxSu_2_1.Name = "cbxSu_2_1";
            this.cbxSu_2_1.Size = new System.Drawing.Size(75, 17);
            this.cbxSu_2_1.TabIndex = 114;
            this.cbxSu_2_1.Text = "極超短波";
            this.cbxSu_2_1.UseVisualStyleBackColor = false;
            // 
            // rbtSu_3_2
            // 
            this.rbtSu_3_2.Location = new System.Drawing.Point(155, 67);
            this.rbtSu_3_2.Name = "rbtSu_3_2";
            this.rbtSu_3_2.Size = new System.Drawing.Size(53, 24);
            this.rbtSu_3_2.TabIndex = 111;
            this.rbtSu_3_2.TabStop = true;
            this.rbtSu_3_2.Text = "腰椎";
            this.rbtSu_3_2.UseVisualStyleBackColor = true;
            // 
            // xFlatLabel39
            // 
            this.xFlatLabel39.AutoSize = true;
            this.xFlatLabel39.Location = new System.Drawing.Point(246, 72);
            this.xFlatLabel39.Name = "xFlatLabel39";
            this.xFlatLabel39.Size = new System.Drawing.Size(19, 13);
            this.xFlatLabel39.TabIndex = 113;
            this.xFlatLabel39.Text = "kg";
            // 
            // txtKg
            // 
            this.txtKg.Location = new System.Drawing.Point(213, 67);
            this.txtKg.Name = "txtKg";
            this.txtKg.Size = new System.Drawing.Size(32, 20);
            this.txtKg.TabIndex = 112;
            // 
            // txtSu_2_4
            // 
            this.txtSu_2_4.Location = new System.Drawing.Point(236, 44);
            this.txtSu_2_4.Name = "txtSu_2_4";
            this.txtSu_2_4.Size = new System.Drawing.Size(88, 20);
            this.txtSu_2_4.TabIndex = 112;
            // 
            // pnlTopInfo
            // 
            this.pnlTopInfo.Controls.Add(this.btnInfectious);
            this.pnlTopInfo.Controls.Add(this.btnFrequency);
            this.pnlTopInfo.Controls.Add(this.btnTaboo);
            this.pnlTopInfo.Controls.Add(this.btnStop_kijyun);
            this.pnlTopInfo.Controls.Add(this.lblNalsu);
            this.pnlTopInfo.Controls.Add(this.cboNissuu);
            this.pnlTopInfo.Controls.Add(this.dptKaisibi);
            this.pnlTopInfo.Controls.Add(this.xLabel1);
            this.pnlTopInfo.Controls.Add(this.gbxComplications);
            this.pnlTopInfo.Controls.Add(this.gbxKioureki);
            this.pnlTopInfo.Controls.Add(this.gbxGenbyoureki);
            this.pnlTopInfo.Controls.Add(this.gbxSindanmei);
            this.pnlTopInfo.Controls.Add(this.txtInfectious);
            this.pnlTopInfo.Controls.Add(this.txtTaboo);
            this.pnlTopInfo.Controls.Add(this.txtStop_kijyun);
            this.pnlTopInfo.Controls.Add(this.txtFrequency);
            this.pnlTopInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopInfo.Name = "pnlTopInfo";
            this.pnlTopInfo.Size = new System.Drawing.Size(733, 226);
            this.pnlTopInfo.TabIndex = 108;
            // 
            // btnInfectious
            // 
            this.btnInfectious.Location = new System.Drawing.Point(345, 4);
            this.btnInfectious.Name = "btnInfectious";
            this.btnInfectious.Size = new System.Drawing.Size(60, 25);
            this.btnInfectious.TabIndex = 108;
            this.btnInfectious.Text = "感染症";
            this.btnInfectious.Click += new System.EventHandler(this.btnInfectious_Click);
            // 
            // btnFrequency
            // 
            this.btnFrequency.Location = new System.Drawing.Point(345, 82);
            this.btnFrequency.Name = "btnFrequency";
            this.btnFrequency.Size = new System.Drawing.Size(60, 25);
            this.btnFrequency.TabIndex = 108;
            this.btnFrequency.Text = "頻度";
            this.btnFrequency.Click += new System.EventHandler(this.btnFrequency_Click);
            // 
            // btnTaboo
            // 
            this.btnTaboo.Location = new System.Drawing.Point(345, 56);
            this.btnTaboo.Name = "btnTaboo";
            this.btnTaboo.Size = new System.Drawing.Size(60, 25);
            this.btnTaboo.TabIndex = 108;
            this.btnTaboo.Text = "禁忌事項";
            this.btnTaboo.Click += new System.EventHandler(this.btnTaboo_Click);
            // 
            // btnStop_kijyun
            // 
            this.btnStop_kijyun.Location = new System.Drawing.Point(345, 30);
            this.btnStop_kijyun.Name = "btnStop_kijyun";
            this.btnStop_kijyun.Size = new System.Drawing.Size(60, 25);
            this.btnStop_kijyun.TabIndex = 108;
            this.btnStop_kijyun.Text = "中止基準";
            this.btnStop_kijyun.Click += new System.EventHandler(this.btnStop_kijyun_Click);
            // 
            // lblNalsu
            // 
            this.lblNalsu.EdgeRounding = false;
            this.lblNalsu.Location = new System.Drawing.Point(538, 108);
            this.lblNalsu.Name = "lblNalsu";
            this.lblNalsu.Size = new System.Drawing.Size(68, 21);
            this.lblNalsu.TabIndex = 122;
            this.lblNalsu.Text = "日数";
            this.lblNalsu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboNissuu
            // 
            this.cboNissuu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboNissuu.Location = new System.Drawing.Point(612, 108);
            this.cboNissuu.Name = "cboNissuu";
            this.cboNissuu.Size = new System.Drawing.Size(115, 21);
            this.cboNissuu.TabIndex = 121;
            // 
            // dptKaisibi
            // 
            this.dptKaisibi.IsJapanYearType = true;
            this.dptKaisibi.Location = new System.Drawing.Point(411, 108);
            this.dptKaisibi.Name = "dptKaisibi";
            this.dptKaisibi.Size = new System.Drawing.Size(112, 20);
            this.dptKaisibi.TabIndex = 120;
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(345, 109);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(60, 20);
            this.xLabel1.TabIndex = 119;
            this.xLabel1.Text = "適用日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxComplications
            // 
            this.gbxComplications.Controls.Add(this.btnComplications);
            this.gbxComplications.Controls.Add(this.txtComplications);
            this.gbxComplications.Location = new System.Drawing.Point(296, 134);
            this.gbxComplications.Name = "gbxComplications";
            this.gbxComplications.Protect = true;
            this.gbxComplications.Size = new System.Drawing.Size(190, 86);
            this.gbxComplications.TabIndex = 110;
            this.gbxComplications.TabStop = false;
            this.gbxComplications.Text = "合併症";
            // 
            // btnComplications
            // 
            this.btnComplications.Location = new System.Drawing.Point(130, -1);
            this.btnComplications.Name = "btnComplications";
            this.btnComplications.Size = new System.Drawing.Size(60, 17);
            this.btnComplications.TabIndex = 108;
            this.btnComplications.Text = "傷病リスト";
            this.btnComplications.Click += new System.EventHandler(this.btnComplications_Click);
            // 
            // txtComplications
            // 
            this.txtComplications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComplications.Location = new System.Drawing.Point(3, 16);
            this.txtComplications.Multiline = true;
            this.txtComplications.Name = "txtComplications";
            this.txtComplications.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComplications.Size = new System.Drawing.Size(184, 67);
            this.txtComplications.TabIndex = 94;
            // 
            // gbxKioureki
            // 
            this.gbxKioureki.Controls.Add(this.btnKioureki);
            this.gbxKioureki.Controls.Add(this.txtKioureki);
            this.gbxKioureki.Location = new System.Drawing.Point(489, 134);
            this.gbxKioureki.Name = "gbxKioureki";
            this.gbxKioureki.Protect = true;
            this.gbxKioureki.Size = new System.Drawing.Size(237, 86);
            this.gbxKioureki.TabIndex = 110;
            this.gbxKioureki.TabStop = false;
            this.gbxKioureki.Text = "既往歴";
            // 
            // btnKioureki
            // 
            this.btnKioureki.Location = new System.Drawing.Point(163, -1);
            this.btnKioureki.Name = "btnKioureki";
            this.btnKioureki.Size = new System.Drawing.Size(75, 17);
            this.btnKioureki.TabIndex = 108;
            this.btnKioureki.Text = "患者傷病";
            this.btnKioureki.Click += new System.EventHandler(this.btnKioureki_Click);
            // 
            // txtKioureki
            // 
            this.txtKioureki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKioureki.Location = new System.Drawing.Point(3, 16);
            this.txtKioureki.Multiline = true;
            this.txtKioureki.Name = "txtKioureki";
            this.txtKioureki.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtKioureki.Size = new System.Drawing.Size(231, 67);
            this.txtKioureki.TabIndex = 94;
            // 
            // gbxGenbyoureki
            // 
            this.gbxGenbyoureki.Controls.Add(this.btnGenbyoureki);
            this.gbxGenbyoureki.Controls.Add(this.txtGenbyoureki);
            this.gbxGenbyoureki.Location = new System.Drawing.Point(6, 134);
            this.gbxGenbyoureki.Name = "gbxGenbyoureki";
            this.gbxGenbyoureki.Protect = true;
            this.gbxGenbyoureki.Size = new System.Drawing.Size(287, 86);
            this.gbxGenbyoureki.TabIndex = 109;
            this.gbxGenbyoureki.TabStop = false;
            this.gbxGenbyoureki.Text = "現病歴";
            // 
            // btnGenbyoureki
            // 
            this.btnGenbyoureki.Location = new System.Drawing.Point(212, -1);
            this.btnGenbyoureki.Name = "btnGenbyoureki";
            this.btnGenbyoureki.Size = new System.Drawing.Size(75, 17);
            this.btnGenbyoureki.TabIndex = 108;
            this.btnGenbyoureki.Text = "患者傷病";
            this.btnGenbyoureki.Click += new System.EventHandler(this.btnGenbyoureki_Click);
            // 
            // txtGenbyoureki
            // 
            this.txtGenbyoureki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGenbyoureki.Location = new System.Drawing.Point(3, 16);
            this.txtGenbyoureki.Multiline = true;
            this.txtGenbyoureki.Name = "txtGenbyoureki";
            this.txtGenbyoureki.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGenbyoureki.Size = new System.Drawing.Size(281, 67);
            this.txtGenbyoureki.TabIndex = 94;
            // 
            // gbxSindanmei
            // 
            this.gbxSindanmei.Controls.Add(this.btnSindanmei);
            this.gbxSindanmei.Controls.Add(this.grdPHY8003);
            this.gbxSindanmei.Location = new System.Drawing.Point(3, 3);
            this.gbxSindanmei.Name = "gbxSindanmei";
            this.gbxSindanmei.Protect = true;
            this.gbxSindanmei.Size = new System.Drawing.Size(330, 130);
            this.gbxSindanmei.TabIndex = 118;
            this.gbxSindanmei.TabStop = false;
            this.gbxSindanmei.Text = "診断名";
            // 
            // btnSindanmei
            // 
            this.btnSindanmei.Location = new System.Drawing.Point(255, -1);
            this.btnSindanmei.Name = "btnSindanmei";
            this.btnSindanmei.Size = new System.Drawing.Size(75, 17);
            this.btnSindanmei.TabIndex = 108;
            this.btnSindanmei.Text = "患者傷病";
            this.btnSindanmei.Click += new System.EventHandler(this.btnSindanmei_Click);
            // 
            // grdPHY8003
            // 
            this.grdPHY8003.CallerID = '2';
            this.grdPHY8003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell150,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell117,
            this.xEditGridCell118,
            this.xEditGridCell119,
            this.xEditGridCell120,
            this.xEditGridCell121,
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
            this.xEditGridCell122,
            this.xEditGridCell123,
            this.xEditGridCell124,
            this.xEditGridCell146,
            this.xEditGridCell147});
            this.grdPHY8003.ColPerLine = 33;
            this.grdPHY8003.Cols = 33;
            this.grdPHY8003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPHY8003.FixedRows = 1;
            this.grdPHY8003.HeaderHeights.Add(21);
            this.grdPHY8003.Location = new System.Drawing.Point(3, 16);
            this.grdPHY8003.Name = "grdPHY8003";
            this.grdPHY8003.QuerySQL = resources.GetString("grdPHY8003.QuerySQL");
            this.grdPHY8003.Rows = 2;
            this.grdPHY8003.Size = new System.Drawing.Size(324, 111);
            this.grdPHY8003.TabIndex = 107;
            this.grdPHY8003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdIFS8003_MouseDown);
            this.grdPHY8003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdIFS8003_QueryStarting);
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "sys_date";
            this.xEditGridCell110.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.HeaderText = "生成日時";
            this.xEditGridCell110.IsReadOnly = true;
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellLen = 8;
            this.xEditGridCell111.CellName = "user_id";
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.HeaderText = "ユーザID";
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsUpdatable = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "upd_date";
            this.xEditGridCell112.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell112.Col = -1;
            this.xEditGridCell112.HeaderText = "更新日時";
            this.xEditGridCell112.IsReadOnly = true;
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "hosp_code";
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.HeaderText = "病院コード";
            this.xEditGridCell113.IsReadOnly = true;
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "pk_ifs_syoubyou";
            this.xEditGridCell114.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell114.Col = 32;
            this.xEditGridCell114.HeaderText = "テーブル基本キー";
            this.xEditGridCell114.IsReadOnly = true;
            this.xEditGridCell114.IsUpdatable = false;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellName = "data_kubun";
            this.xEditGridCell150.Col = 31;
            this.xEditGridCell150.HeaderText = "データ区分";
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "fk_ocs_irai";
            this.xEditGridCell115.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell115.Col = 3;
            this.xEditGridCell115.HeaderText = "依頼キー";
            this.xEditGridCell115.IsReadOnly = true;
            this.xEditGridCell115.IsUpdatable = false;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "i_seq";
            this.xEditGridCell116.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell116.Col = 4;
            this.xEditGridCell116.HeaderText = "一連番号";
            this.xEditGridCell116.IsReadOnly = true;
            this.xEditGridCell116.IsUpdatable = false;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellLen = 1;
            this.xEditGridCell117.CellName = "io_kubun";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.HeaderText = "入院外来区分";
            this.xEditGridCell117.IsReadOnly = true;
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellLen = 8;
            this.xEditGridCell118.CellName = "irai_date";
            this.xEditGridCell118.Col = 5;
            this.xEditGridCell118.HeaderText = "依頼データ";
            this.xEditGridCell118.IsReadOnly = true;
            this.xEditGridCell118.IsUpdatable = false;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "kanja_no";
            this.xEditGridCell119.Col = 6;
            this.xEditGridCell119.HeaderText = "患者番号";
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.IsUpdatable = false;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellLen = 2;
            this.xEditGridCell120.CellName = "sinryouka";
            this.xEditGridCell120.Col = 7;
            this.xEditGridCell120.HeaderText = "診療科";
            this.xEditGridCell120.IsReadOnly = true;
            this.xEditGridCell120.IsUpdatable = false;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellLen = 7;
            this.xEditGridCell121.CellName = "syoubyoumei_code";
            this.xEditGridCell121.Col = 8;
            this.xEditGridCell121.HeaderText = "傷病名コード";
            this.xEditGridCell121.IsReadOnly = true;
            this.xEditGridCell121.IsUpdatable = false;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellLen = 200;
            this.xEditGridCell125.CellName = "display_syoubyoumei";
            this.xEditGridCell125.CellWidth = 221;
            this.xEditGridCell125.HeaderText = "表示傷病名";
            this.xEditGridCell125.IsReadOnly = true;
            this.xEditGridCell125.IsUpdatable = false;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "pre_modifier1";
            this.xEditGridCell126.Col = 9;
            this.xEditGridCell126.HeaderText = "pr1";
            this.xEditGridCell126.IsReadOnly = true;
            this.xEditGridCell126.IsUpdatable = false;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "pre_modifier2";
            this.xEditGridCell127.Col = 10;
            this.xEditGridCell127.HeaderText = "pr2";
            this.xEditGridCell127.IsReadOnly = true;
            this.xEditGridCell127.IsUpdatable = false;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "pre_modifier3";
            this.xEditGridCell128.Col = 11;
            this.xEditGridCell128.HeaderText = "pr3";
            this.xEditGridCell128.IsReadOnly = true;
            this.xEditGridCell128.IsUpdatable = false;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "pre_modifier4";
            this.xEditGridCell129.Col = 12;
            this.xEditGridCell129.HeaderText = "pr4";
            this.xEditGridCell129.IsReadOnly = true;
            this.xEditGridCell129.IsUpdatable = false;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "pre_modifier5";
            this.xEditGridCell130.Col = 13;
            this.xEditGridCell130.HeaderText = "pr5";
            this.xEditGridCell130.IsReadOnly = true;
            this.xEditGridCell130.IsUpdatable = false;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "pre_modifier6";
            this.xEditGridCell131.Col = 14;
            this.xEditGridCell131.HeaderText = "pr6";
            this.xEditGridCell131.IsReadOnly = true;
            this.xEditGridCell131.IsUpdatable = false;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "pre_modifier7";
            this.xEditGridCell132.Col = 15;
            this.xEditGridCell132.HeaderText = "pr7";
            this.xEditGridCell132.IsReadOnly = true;
            this.xEditGridCell132.IsUpdatable = false;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "pre_modifier8";
            this.xEditGridCell133.Col = 16;
            this.xEditGridCell133.HeaderText = "pr8";
            this.xEditGridCell133.IsReadOnly = true;
            this.xEditGridCell133.IsUpdatable = false;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "pre_modifier9";
            this.xEditGridCell134.Col = 17;
            this.xEditGridCell134.HeaderText = "pr9";
            this.xEditGridCell134.IsReadOnly = true;
            this.xEditGridCell134.IsUpdatable = false;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "pre_modifier10";
            this.xEditGridCell135.Col = 18;
            this.xEditGridCell135.HeaderText = "pr10";
            this.xEditGridCell135.IsReadOnly = true;
            this.xEditGridCell135.IsUpdatable = false;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "post_modifier1";
            this.xEditGridCell136.Col = 19;
            this.xEditGridCell136.HeaderText = "po1";
            this.xEditGridCell136.IsReadOnly = true;
            this.xEditGridCell136.IsUpdatable = false;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "post_modifier2";
            this.xEditGridCell137.Col = 20;
            this.xEditGridCell137.HeaderText = "po2";
            this.xEditGridCell137.IsReadOnly = true;
            this.xEditGridCell137.IsUpdatable = false;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "post_modifier3";
            this.xEditGridCell138.Col = 21;
            this.xEditGridCell138.HeaderText = "po3";
            this.xEditGridCell138.IsReadOnly = true;
            this.xEditGridCell138.IsUpdatable = false;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "post_modifier4";
            this.xEditGridCell139.Col = 22;
            this.xEditGridCell139.HeaderText = "po4";
            this.xEditGridCell139.IsReadOnly = true;
            this.xEditGridCell139.IsUpdatable = false;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "post_modifier5";
            this.xEditGridCell140.Col = 23;
            this.xEditGridCell140.HeaderText = "po5";
            this.xEditGridCell140.IsReadOnly = true;
            this.xEditGridCell140.IsUpdatable = false;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "post_modifier6";
            this.xEditGridCell141.Col = 24;
            this.xEditGridCell141.HeaderText = "po6";
            this.xEditGridCell141.IsReadOnly = true;
            this.xEditGridCell141.IsUpdatable = false;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "post_modifier7";
            this.xEditGridCell142.Col = 25;
            this.xEditGridCell142.HeaderText = "po7";
            this.xEditGridCell142.IsReadOnly = true;
            this.xEditGridCell142.IsUpdatable = false;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "post_modifier8";
            this.xEditGridCell143.Col = 26;
            this.xEditGridCell143.HeaderText = "po8";
            this.xEditGridCell143.IsReadOnly = true;
            this.xEditGridCell143.IsUpdatable = false;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "post_modifier9";
            this.xEditGridCell144.Col = -1;
            this.xEditGridCell144.HeaderText = "po9";
            this.xEditGridCell144.IsReadOnly = true;
            this.xEditGridCell144.IsUpdatable = false;
            this.xEditGridCell144.IsVisible = false;
            this.xEditGridCell144.Row = -1;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "post_modifier10";
            this.xEditGridCell145.Col = 27;
            this.xEditGridCell145.HeaderText = "po10";
            this.xEditGridCell145.IsReadOnly = true;
            this.xEditGridCell145.IsUpdatable = false;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellLen = 8;
            this.xEditGridCell122.CellName = "hassyoubi";
            this.xEditGridCell122.Col = 1;
            this.xEditGridCell122.HeaderText = "発症日";
            this.xEditGridCell122.IsReadOnly = true;
            this.xEditGridCell122.IsUpdatable = false;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellLen = 8;
            this.xEditGridCell123.CellName = "sindanbi";
            this.xEditGridCell123.Col = 2;
            this.xEditGridCell123.HeaderText = "診断日";
            this.xEditGridCell123.IsReadOnly = true;
            this.xEditGridCell123.IsUpdatable = false;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "pre_modifier_name";
            this.xEditGridCell124.Col = 28;
            this.xEditGridCell124.HeaderText = "接頭語名";
            this.xEditGridCell124.IsReadOnly = true;
            this.xEditGridCell124.IsUpdatable = false;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "post_modifier_name";
            this.xEditGridCell146.Col = 29;
            this.xEditGridCell146.HeaderText = "接尾語名";
            this.xEditGridCell146.IsReadOnly = true;
            this.xEditGridCell146.IsUpdatable = false;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "syoubyoumei";
            this.xEditGridCell147.Col = 30;
            this.xEditGridCell147.HeaderText = "傷病名";
            this.xEditGridCell147.IsReadOnly = true;
            this.xEditGridCell147.IsUpdatable = false;
            // 
            // txtInfectious
            // 
            this.txtInfectious.Location = new System.Drawing.Point(411, 4);
            this.txtInfectious.Multiline = true;
            this.txtInfectious.Name = "txtInfectious";
            this.txtInfectious.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfectious.Size = new System.Drawing.Size(316, 25);
            this.txtInfectious.TabIndex = 0;
            // 
            // txtTaboo
            // 
            this.txtTaboo.Location = new System.Drawing.Point(411, 56);
            this.txtTaboo.Multiline = true;
            this.txtTaboo.Name = "txtTaboo";
            this.txtTaboo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTaboo.Size = new System.Drawing.Size(316, 25);
            this.txtTaboo.TabIndex = 1;
            // 
            // txtStop_kijyun
            // 
            this.txtStop_kijyun.Location = new System.Drawing.Point(411, 30);
            this.txtStop_kijyun.Multiline = true;
            this.txtStop_kijyun.Name = "txtStop_kijyun";
            this.txtStop_kijyun.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStop_kijyun.Size = new System.Drawing.Size(316, 25);
            this.txtStop_kijyun.TabIndex = 95;
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(411, 82);
            this.txtFrequency.Multiline = true;
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFrequency.Size = new System.Drawing.Size(316, 25);
            this.txtFrequency.TabIndex = 97;
            // 
            // pan1
            // 
            this.pan1.Controls.Add(this.rb3);
            this.pan1.Controls.Add(this.rb2);
            this.pan1.Controls.Add(this.rb1);
            this.pan1.Location = new System.Drawing.Point(1039, 35);
            this.pan1.Name = "pan1";
            this.pan1.Size = new System.Drawing.Size(154, 28);
            this.pan1.TabIndex = 92;
            // 
            // rb3
            // 
            this.rb3.CheckedValue = "3";
            this.rb3.Location = new System.Drawing.Point(102, 6);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(52, 19);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "変更";
            this.rb3.UseVisualStyleBackColor = false;
            // 
            // rb2
            // 
            this.rb2.CheckedValue = "2";
            this.rb2.Location = new System.Drawing.Point(55, 6);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(52, 16);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "追加";
            this.rb2.UseVisualStyleBackColor = false;
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.CheckedValue = "1";
            this.rb1.Location = new System.Drawing.Point(8, 6);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(52, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "新規";
            this.rb1.UseVisualStyleBackColor = false;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // grdPHY2000
            // 
            this.grdPHY2000.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell54,
            this.xEditGridCell67,
            this.xEditGridCell53,
            this.xEditGridCell6,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell5,
            this.xEditGridCell9,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell10,
            this.xEditGridCell19,
            this.xEditGridCell13,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell55,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell73,
            this.xEditGridCell74,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell88,
            this.xEditGridCell47,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell52,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell148,
            this.xEditGridCell149});
            this.grdPHY2000.ColPerLine = 81;
            this.grdPHY2000.Cols = 81;
            this.grdPHY2000.ControlBinding = true;
            this.grdPHY2000.FixedRows = 1;
            this.grdPHY2000.HeaderHeights.Add(21);
            this.grdPHY2000.Location = new System.Drawing.Point(2, 1);
            this.grdPHY2000.Name = "grdPHY2000";
            this.grdPHY2000.QuerySQL = resources.GetString("grdPHY2000.QuerySQL");
            this.grdPHY2000.Rows = 2;
            this.grdPHY2000.Size = new System.Drawing.Size(863, 94);
            this.grdPHY2000.TabIndex = 93;
            this.grdPHY2000.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPhy2000_QueryStarting);
            this.grdPHY2000.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPHY2000_GridColumnChanged);
            this.grdPHY2000.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdPHY2000_SaveEnd);
            this.grdPHY2000.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPHY2000_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "sys_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 4;
            this.xEditGridCell1.HeaderText = "生成日付";
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 8;
            this.xEditGridCell2.CellName = "user_id";
            this.xEditGridCell2.Col = 5;
            this.xEditGridCell2.HeaderText = "ユーザＩＤ";
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "upd_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = 6;
            this.xEditGridCell3.HeaderText = "更新日付";
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "hosp_code";
            this.xEditGridCell54.Col = 53;
            this.xEditGridCell54.HeaderText = "病院コード";
            this.xEditGridCell54.IsUpdatable = false;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "pkphy2000";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.CellWidth = 125;
            this.xEditGridCell67.Col = 2;
            this.xEditGridCell67.HeaderText = "テーブル基本キー";
            this.xEditGridCell67.IsUpdatable = false;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "fk_ocs_irai";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.HeaderText = "OCSオーダキー(依頼キー)";
            this.xEditGridCell53.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 1;
            this.xEditGridCell6.CellName = "io_kubun";
            this.xEditGridCell6.CellWidth = 90;
            this.xEditGridCell6.Col = 9;
            this.xEditGridCell6.HeaderText = "入院外来区分";
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 8;
            this.xEditGridCell4.CellName = "irai_date";
            this.xEditGridCell4.Col = 7;
            this.xEditGridCell4.HeaderText = "依頼日付";
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "kanja_no";
            this.xEditGridCell8.Col = 10;
            this.xEditGridCell8.HeaderText = "患者番号";
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 2;
            this.xEditGridCell5.CellName = "sinryouka";
            this.xEditGridCell5.Col = 8;
            this.xEditGridCell5.HeaderText = "診療科";
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "sindanisi";
            this.xEditGridCell9.Col = 11;
            this.xEditGridCell9.HeaderText = "診断医師";
            this.xEditGridCell9.IsUpdatable = false;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "tantoui";
            this.xEditGridCell69.Col = 51;
            this.xEditGridCell69.HeaderText = "担当医";
            this.xEditGridCell69.IsUpdatable = false;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellLen = 8;
            this.xEditGridCell70.CellName = "nyuuinnbi";
            this.xEditGridCell70.Col = 54;
            this.xEditGridCell70.HeaderText = "入院日";
            this.xEditGridCell70.IsUpdatable = false;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellLen = 2;
            this.xEditGridCell71.CellName = "byousitu_code";
            this.xEditGridCell71.Col = 55;
            this.xEditGridCell71.HeaderText = "病室コード";
            this.xEditGridCell71.IsUpdatable = false;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellLen = 4;
            this.xEditGridCell72.CellName = "byoutou_code";
            this.xEditGridCell72.Col = 56;
            this.xEditGridCell72.HeaderText = "病棟コード";
            this.xEditGridCell72.IsUpdatable = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "kaisibi";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = 12;
            this.xEditGridCell10.HeaderText = "開始日";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 3;
            this.xEditGridCell19.CellName = "nissuu";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.Col = 23;
            this.xEditGridCell19.HeaderText = "日数";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "koumoku_code";
            this.xEditGridCell13.Col = 14;
            this.xEditGridCell13.HeaderText = "項目コード";
            this.xEditGridCell13.IsUpdatable = false;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 50;
            this.xEditGridCell15.CellName = "su_1";
            this.xEditGridCell15.Col = 15;
            this.xEditGridCell15.HeaderText = "主項目1";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 50;
            this.xEditGridCell16.CellName = "su_2_1";
            this.xEditGridCell16.Col = 16;
            this.xEditGridCell16.HeaderText = "主項目2";
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellLen = 50;
            this.xEditGridCell55.CellName = "su_2_2";
            this.xEditGridCell55.Col = 17;
            this.xEditGridCell55.HeaderText = "主項目3";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 50;
            this.xEditGridCell17.CellName = "su_2_3";
            this.xEditGridCell17.Col = 18;
            this.xEditGridCell17.HeaderText = "主項目4";
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellLen = 50;
            this.xEditGridCell18.CellName = "su_2_4";
            this.xEditGridCell18.Col = 19;
            this.xEditGridCell18.HeaderText = "主項目5";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellLen = 50;
            this.xEditGridCell20.CellName = "su_3_1";
            this.xEditGridCell20.Col = 20;
            this.xEditGridCell20.HeaderText = "主項目6";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellLen = 50;
            this.xEditGridCell21.CellName = "su_3_2";
            this.xEditGridCell21.Col = 21;
            this.xEditGridCell21.HeaderText = "主項目7";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellLen = 50;
            this.xEditGridCell22.CellName = "su_4_1";
            this.xEditGridCell22.Col = 22;
            this.xEditGridCell22.HeaderText = "主項目8";
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellLen = 50;
            this.xEditGridCell73.CellName = "su_4_2";
            this.xEditGridCell73.Col = 57;
            this.xEditGridCell73.HeaderText = "主項目9";
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellLen = 50;
            this.xEditGridCell74.CellName = "su_4_3";
            this.xEditGridCell74.Col = 58;
            this.xEditGridCell74.HeaderText = "主項目10";
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 50;
            this.xEditGridCell23.CellName = "reha1";
            this.xEditGridCell23.Col = 24;
            this.xEditGridCell23.HeaderText = "疾患別リハビリテーション料1";
            this.xEditGridCell23.IsUpdatable = false;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 50;
            this.xEditGridCell24.CellName = "reha2";
            this.xEditGridCell24.Col = 25;
            this.xEditGridCell24.HeaderText = "疾患別リハビリテーション料2";
            this.xEditGridCell24.IsUpdatable = false;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellLen = 50;
            this.xEditGridCell25.CellName = "reha3";
            this.xEditGridCell25.Col = 26;
            this.xEditGridCell25.HeaderText = "疾患別リハビリテーション料3";
            this.xEditGridCell25.IsUpdatable = false;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellLen = 50;
            this.xEditGridCell75.CellName = "reha4";
            this.xEditGridCell75.Col = 59;
            this.xEditGridCell75.HeaderText = "疾患別リハビリテーション料4";
            this.xEditGridCell75.IsUpdatable = false;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellLen = 50;
            this.xEditGridCell76.CellName = "reha5";
            this.xEditGridCell76.Col = 60;
            this.xEditGridCell76.HeaderText = "疾患別リハビリテーション料5";
            this.xEditGridCell76.IsUpdatable = false;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellLen = 50;
            this.xEditGridCell26.CellName = "pt1";
            this.xEditGridCell26.Col = 27;
            this.xEditGridCell26.HeaderText = "PT依頼内容1";
            this.xEditGridCell26.IsUpdatable = false;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellLen = 50;
            this.xEditGridCell27.CellName = "pt2";
            this.xEditGridCell27.Col = 28;
            this.xEditGridCell27.HeaderText = "PT依頼内容2";
            this.xEditGridCell27.IsUpdatable = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellLen = 50;
            this.xEditGridCell28.CellName = "pt3";
            this.xEditGridCell28.Col = 29;
            this.xEditGridCell28.HeaderText = "PT依頼内容3";
            this.xEditGridCell28.IsUpdatable = false;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellLen = 50;
            this.xEditGridCell29.CellName = "pt4";
            this.xEditGridCell29.Col = 30;
            this.xEditGridCell29.HeaderText = "PT依頼内容4";
            this.xEditGridCell29.IsUpdatable = false;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 50;
            this.xEditGridCell30.CellName = "pt5";
            this.xEditGridCell30.Col = 31;
            this.xEditGridCell30.HeaderText = "PT依頼内容5";
            this.xEditGridCell30.IsUpdatable = false;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 50;
            this.xEditGridCell31.CellName = "pt6";
            this.xEditGridCell31.Col = 32;
            this.xEditGridCell31.HeaderText = "PT依頼内容6";
            this.xEditGridCell31.IsUpdatable = false;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellLen = 50;
            this.xEditGridCell32.CellName = "pt7";
            this.xEditGridCell32.Col = 33;
            this.xEditGridCell32.HeaderText = "PT依頼内容7";
            this.xEditGridCell32.IsUpdatable = false;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellLen = 50;
            this.xEditGridCell77.CellName = "pt8";
            this.xEditGridCell77.Col = 61;
            this.xEditGridCell77.HeaderText = "PT依頼内容8";
            this.xEditGridCell77.IsUpdatable = false;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellLen = 50;
            this.xEditGridCell78.CellName = "pt9";
            this.xEditGridCell78.Col = 62;
            this.xEditGridCell78.HeaderText = "PT依頼内容9";
            this.xEditGridCell78.IsUpdatable = false;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellLen = 50;
            this.xEditGridCell79.CellName = "pt10";
            this.xEditGridCell79.Col = 63;
            this.xEditGridCell79.HeaderText = "PT依頼内容10";
            this.xEditGridCell79.IsUpdatable = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 50;
            this.xEditGridCell33.CellName = "ot1";
            this.xEditGridCell33.Col = 34;
            this.xEditGridCell33.HeaderText = "OT依頼内容1";
            this.xEditGridCell33.IsUpdatable = false;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellLen = 50;
            this.xEditGridCell34.CellName = "ot2";
            this.xEditGridCell34.Col = 35;
            this.xEditGridCell34.HeaderText = "OT依頼内容2";
            this.xEditGridCell34.IsUpdatable = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellLen = 50;
            this.xEditGridCell35.CellName = "ot3";
            this.xEditGridCell35.Col = 36;
            this.xEditGridCell35.HeaderText = "OT依頼内容3";
            this.xEditGridCell35.IsUpdatable = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 50;
            this.xEditGridCell36.CellName = "ot4";
            this.xEditGridCell36.Col = 37;
            this.xEditGridCell36.HeaderText = "OT依頼内容4";
            this.xEditGridCell36.IsUpdatable = false;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellLen = 50;
            this.xEditGridCell37.CellName = "ot5";
            this.xEditGridCell37.Col = 38;
            this.xEditGridCell37.HeaderText = "OT依頼内容5";
            this.xEditGridCell37.IsUpdatable = false;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 50;
            this.xEditGridCell38.CellName = "ot6";
            this.xEditGridCell38.Col = 39;
            this.xEditGridCell38.HeaderText = "OT依頼内容6";
            this.xEditGridCell38.IsUpdatable = false;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellLen = 50;
            this.xEditGridCell80.CellName = "ot7";
            this.xEditGridCell80.Col = 64;
            this.xEditGridCell80.HeaderText = "OT依頼内容7";
            this.xEditGridCell80.IsUpdatable = false;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellLen = 50;
            this.xEditGridCell81.CellName = "ot8";
            this.xEditGridCell81.Col = 65;
            this.xEditGridCell81.HeaderText = "OT依頼内容8";
            this.xEditGridCell81.IsUpdatable = false;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellLen = 50;
            this.xEditGridCell82.CellName = "ot9";
            this.xEditGridCell82.Col = 66;
            this.xEditGridCell82.HeaderText = "OT依頼内容9";
            this.xEditGridCell82.IsUpdatable = false;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellLen = 50;
            this.xEditGridCell83.CellName = "ot10";
            this.xEditGridCell83.Col = 67;
            this.xEditGridCell83.HeaderText = "OT依頼内容10";
            this.xEditGridCell83.IsUpdatable = false;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 50;
            this.xEditGridCell39.CellName = "st1";
            this.xEditGridCell39.Col = 40;
            this.xEditGridCell39.HeaderText = "ST依頼内容1";
            this.xEditGridCell39.IsUpdatable = false;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellLen = 50;
            this.xEditGridCell40.CellName = "st2";
            this.xEditGridCell40.Col = 41;
            this.xEditGridCell40.HeaderText = "ST依頼内容2";
            this.xEditGridCell40.IsUpdatable = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 50;
            this.xEditGridCell41.CellName = "st3";
            this.xEditGridCell41.Col = 42;
            this.xEditGridCell41.HeaderText = "ST依頼内容3";
            this.xEditGridCell41.IsUpdatable = false;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellLen = 50;
            this.xEditGridCell42.CellName = "st4";
            this.xEditGridCell42.Col = 43;
            this.xEditGridCell42.HeaderText = "ST依頼内容4";
            this.xEditGridCell42.IsUpdatable = false;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellLen = 50;
            this.xEditGridCell43.CellName = "st5";
            this.xEditGridCell43.Col = 44;
            this.xEditGridCell43.HeaderText = "ST依頼内容5";
            this.xEditGridCell43.IsUpdatable = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellLen = 50;
            this.xEditGridCell44.CellName = "st6";
            this.xEditGridCell44.Col = 45;
            this.xEditGridCell44.HeaderText = "ST依頼内容6";
            this.xEditGridCell44.IsUpdatable = false;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellLen = 50;
            this.xEditGridCell84.CellName = "st7";
            this.xEditGridCell84.Col = 68;
            this.xEditGridCell84.HeaderText = "ST依頼内容7";
            this.xEditGridCell84.IsUpdatable = false;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellLen = 50;
            this.xEditGridCell85.CellName = "st8";
            this.xEditGridCell85.Col = 69;
            this.xEditGridCell85.HeaderText = "ST依頼内容8";
            this.xEditGridCell85.IsUpdatable = false;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellLen = 50;
            this.xEditGridCell86.CellName = "st9";
            this.xEditGridCell86.Col = 70;
            this.xEditGridCell86.HeaderText = "ST依頼内容9";
            this.xEditGridCell86.IsUpdatable = false;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellLen = 50;
            this.xEditGridCell87.CellName = "st10";
            this.xEditGridCell87.Col = 71;
            this.xEditGridCell87.HeaderText = "ST依頼内容10";
            this.xEditGridCell87.IsUpdatable = false;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellLen = 100;
            this.xEditGridCell45.CellName = "objective";
            this.xEditGridCell45.Col = 46;
            this.xEditGridCell45.HeaderText = "目標";
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellLen = 100;
            this.xEditGridCell46.CellName = "consult_comment";
            this.xEditGridCell46.CellWidth = 234;
            this.xEditGridCell46.Col = 47;
            this.xEditGridCell46.HeaderText = "指示事項・注意事項";
            this.xEditGridCell46.IsUpdatable = false;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellLen = 100;
            this.xEditGridCell88.CellName = "genbyoureki";
            this.xEditGridCell88.Col = 72;
            this.xEditGridCell88.HeaderText = "現病歴";
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellLen = 100;
            this.xEditGridCell47.CellName = "complications";
            this.xEditGridCell47.Col = 48;
            this.xEditGridCell47.HeaderText = "合併症";
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 100;
            this.xEditGridCell49.CellName = "taboo";
            this.xEditGridCell49.Col = 49;
            this.xEditGridCell49.HeaderText = "禁忌注意";
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellLen = 100;
            this.xEditGridCell50.CellName = "stop_kijyun";
            this.xEditGridCell50.Col = 50;
            this.xEditGridCell50.HeaderText = "中止基準";
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellLen = 100;
            this.xEditGridCell52.CellName = "frequency";
            this.xEditGridCell52.Col = 52;
            this.xEditGridCell52.HeaderText = "頻度";
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellLen = 100;
            this.xEditGridCell89.CellName = "infectious";
            this.xEditGridCell89.Col = 73;
            this.xEditGridCell89.HeaderText = "感染症";
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellLen = 200;
            this.xEditGridCell90.CellName = "kioureki";
            this.xEditGridCell90.Col = 74;
            this.xEditGridCell90.HeaderText = "既往歴";
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellLen = 1;
            this.xEditGridCell91.CellName = "syori_flag";
            this.xEditGridCell91.Col = 75;
            this.xEditGridCell91.HeaderText = "処理フラグ";
            this.xEditGridCell91.IsUpdatable = false;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellLen = 1;
            this.xEditGridCell92.CellName = "pt_flag";
            this.xEditGridCell92.Col = 76;
            this.xEditGridCell92.HeaderText = "PT依頼ありフラグ";
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellLen = 1;
            this.xEditGridCell93.CellName = "ot_flag";
            this.xEditGridCell93.Col = 77;
            this.xEditGridCell93.HeaderText = "OT依頼ありフラグ";
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellLen = 1;
            this.xEditGridCell94.CellName = "st_flag";
            this.xEditGridCell94.Col = 78;
            this.xEditGridCell94.HeaderText = "ST依頼ありフラグ";
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellLen = 1;
            this.xEditGridCell95.CellName = "bu_flag";
            this.xEditGridCell95.Col = 79;
            this.xEditGridCell95.HeaderText = "物療依頼ありフラグ";
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellLen = 100;
            this.xEditGridCell96.CellName = "image";
            this.xEditGridCell96.CellWidth = 200;
            this.xEditGridCell96.Col = 80;
            this.xEditGridCell96.HeaderText = "イメージファイル名";
            this.xEditGridCell96.IsUpdatable = false;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellLen = 100;
            this.xEditGridCell97.CellName = "image_path";
            this.xEditGridCell97.CellWidth = 266;
            this.xEditGridCell97.Col = 1;
            this.xEditGridCell97.HeaderText = "イメージ格納経路";
            this.xEditGridCell97.IsUpdatable = false;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "image_seq";
            this.xEditGridCell148.Col = 3;
            this.xEditGridCell148.HeaderText = "scan0001seq";
            this.xEditGridCell148.IsUpdatable = false;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "cr_time";
            this.xEditGridCell149.CellType = IHIS.Framework.XCellDataType.DateTime;
            this.xEditGridCell149.CellWidth = 149;
            this.xEditGridCell149.Col = 13;
            this.xEditGridCell149.HeaderText = "createTime";
            this.xEditGridCell149.IsUpdatable = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pan1);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Controls.Add(this.grdPHY2000);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(5, 611);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(2);
            this.pnlBottom.Size = new System.Drawing.Size(1368, 98);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Preview, System.Windows.Forms.Shortcut.None, "EMR伝送", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "出力", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(871, 2);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(493, 92);
            this.btnList.TabIndex = 1;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "sys_date";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "生成日時";
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "user_id";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "ユーザID";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "upd_date";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "更新日時";
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "hosp_code";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.HeaderText = "病院コード";
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "pk_ifs_syoubyou";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.HeaderText = "テーブル基本キー";
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "fk_ocs_irai";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.HeaderText = "依頼キー";
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "i_seq";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.HeaderText = "一連番号";
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "io_kubun";
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.HeaderText = "入院外来区分";
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "irai_date";
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.HeaderText = "依頼日付";
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "kanja_no";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.HeaderText = "患者番号";
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "sinryouka";
            this.xEditGridCell105.HeaderText = "診療科";
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "syoubyoumei_code";
            this.xEditGridCell106.Col = 1;
            this.xEditGridCell106.HeaderText = "傷病名コード";
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "hassyoubi";
            this.xEditGridCell107.Col = 2;
            this.xEditGridCell107.HeaderText = "発症日";
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "sindanbi";
            this.xEditGridCell108.Col = 3;
            this.xEditGridCell108.HeaderText = "診断日";
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "reigai_sindanmei";
            this.xEditGridCell109.Col = 4;
            this.xEditGridCell109.HeaderText = "例外診断名";
            // 
            // imageListPopupMenu
            // 
            this.imageListPopupMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPopupMenu.ImageStream")));
            this.imageListPopupMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPopupMenu.Images.SetKeyName(0, "YESUP1.ICO");
            this.imageListPopupMenu.Images.SetKeyName(1, "YESEN1.ICO");
            this.imageListPopupMenu.Images.SetKeyName(2, "복사.gif");
            this.imageListPopupMenu.Images.SetKeyName(3, "붙여넣기.gif");
            this.imageListPopupMenu.Images.SetKeyName(4, "삭제.gif");
            this.imageListPopupMenu.Images.SetKeyName(5, "+.gif");
            this.imageListPopupMenu.Images.SetKeyName(6, "_.gif");
            this.imageListPopupMenu.Images.SetKeyName(7, "행추가.gif");
            // 
            // PHY1000U00
            // 
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "PHY1000U00";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1378, 714);
            this.Load += new System.EventHandler(this.PHY1000U00_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.PHY1000U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patBox)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.pnlCenterRight.ResumeLayout(false);
            this.xPanel12.ResumeLayout(false);
            this.pnlRightUnder.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            this.pnlRightUnderLeft.ResumeLayout(false);
            this.pnlRightUnderLeft.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            this.pnlRightUnderRight.ResumeLayout(false);
            this.pnlRightUnderRight.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            this.xPanel9.ResumeLayout(false);
            this.pnlCenterLeft.ResumeLayout(false);
            this.pnlIrainaiyou.ResumeLayout(false);
            this.gbxST.ResumeLayout(false);
            this.gbxST.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdST)).EndInit();
            this.gbxPT.ResumeLayout(false);
            this.gbxPT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPT)).EndInit();
            this.gbxOT.ResumeLayout(false);
            this.gbxOT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOT)).EndInit();
            this.pnlSukoumoku.ResumeLayout(false);
            this.gbx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReha)).EndInit();
            this.pnlShuhangmog.ResumeLayout(false);
            this.gbx1.ResumeLayout(false);
            this.pnlSu.ResumeLayout(false);
            this.pnlSu.PerformLayout();
            this.pnlTopInfo.ResumeLayout(false);
            this.pnlTopInfo.PerformLayout();
            this.gbxComplications.ResumeLayout(false);
            this.gbxComplications.PerformLayout();
            this.gbxKioureki.ResumeLayout(false);
            this.gbxKioureki.PerformLayout();
            this.gbxGenbyoureki.ResumeLayout(false);
            this.gbxGenbyoureki.PerformLayout();
            this.gbxSindanmei.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY8003)).EndInit();
            this.pan1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY2000)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 이미지 Fields
		//이미지 Size는 640 * 480으로 고정
		const int IMAGE_WIDTH = 640;
		const int IMAGE_HEIGHT = 480;
		const int MIN_WIDTH = 520;  //Form의 최소 Size
		const int MIN_HEIGHT = 490; //Form의 최소 Size
		#endregion

		#region feilds
		private string mInOutGubun;
        private string mGwa;
		private string mFkocs;
		private string mBunho;
		private string mOrder_date;		
		private string mquery_mode;
		private string mHangmog_code;
		private string mSeq;
        

        //insert by jc 
        /// <summary>
        /// G : 現病歴
        /// K : 既往歴
        /// C : 合併症
        /// I : 感染症
        /// S : 診断名
        /// </summary>
        private string mReturnControl;
		#endregion

		[Browsable(false), DataBindable]
		public string InOutGubun
		{
			get {return mInOutGubun;}
		}

		[Browsable(false), DataBindable]
		public string Fkocs
		{
			get {return mFkocs;}
		}

		[Browsable(false), DataBindable]
		public string Bunho
		{
			get {return mBunho;}
		}

		[Browsable(false), DataBindable]
		public string OrderDate
		{
			get {return mOrder_date;}
		}
	
		[Browsable(false), DataBindable]
		public string SEQ
		{
			get {return mSeq;}
			set {mSeq = value;}
		}


		private void PHY1000U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            //((Form)this.ParentForm).WindowState = FormWindowState.Minimized;
			if (this.OpenParam != null )
			{
				//입원/외래구분in_out_gubun, 처방일order_date, 등록번호bunho, 처방키pkocskey
				this.mFkocs          = this.OpenParam["pkocskey"].ToString();
				this.mInOutGubun     = this.OpenParam["in_out_gubun"].ToString();
                this.mGwa            = this.OpenParam["gwa"].ToString();
				this.mBunho		     = this.OpenParam["bunho"].ToString();
				this.mOrder_date     = this.OpenParam["order_date"].ToString();				
				this.mquery_mode     = this.OpenParam["query_mode"].ToString();							
				this.mHangmog_code   = this.OpenParam["hangmog_code"].ToString();
			}

            SetNumCombo(this.cboNissuu, "nalsu", false);

			//중복체크 
			if (mquery_mode == "N")
			{	
                //dsvQueryChk.SetBindVarValue("order_date",mOrder_date);
                //dsvQueryChk.SetBindVarValue("in_out_gubun",mInOutGubun);
                //dsvQueryChk.SetBindVarValue("bunho",mBunho);
                //dsvQueryChk.SetBindVarValue("fkocs",mFkocs);
                //dsvQueryChk.SetBindVarValue("hangmog_code",mHangmog_code);

                //DataServiceCall(dsvQueryChk);

                //if (dsvQueryChk.GetOutValue("chk").ToString() == "Y")
                //{
                //    this.Close();
                //    return;
                //}
					
			}
			((Form)this.ParentForm).WindowState = FormWindowState.Normal;
			
			patBox.SetPatientID(mBunho);
            //this.DataServiceCall(dsvBunho);


            string cmdStr = @"SELECT CODE_NAME FROM OCS0132 WHERE CODE_TYPE = 'RESULT_PATH' AND CODE = 'PATH' AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()";
            object retVal = Service.ExecuteScalar(cmdStr);
            if (!TypeCheck.IsNull(retVal))
            {
                mPathNm = retVal.ToString();
            }
            this.mReturnControl = "";

            if (mFkocs != "")
            {
                //this.grdPHY2000.RowFocusChanged -= new IHIS.Framework.RowFocusChangedEventHandler(this.grdPHY2000_RowFocusChanged);
                this.grdPHY2000.QueryLayout(true);
                //this.grdPHY2000.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPHY2000_RowFocusChanged);

                #region [主項目のチェックボックスの初期値設定]
                if (this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "su_3_1") != "")
                {
                    string kg = this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "su_3_1");
                    this.cbxSu_3.Checked = true;
                    this.rbtSu_3_1.Checked = true;
                    this.txtKg.Text = kg;
                }
                else if (this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "su_3_2") != "")
                {
                    string kg = this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "su_3_2");
                    this.cbxSu_3.Checked = true;
                    this.rbtSu_3_2.Checked = true;
                    this.txtKg.Text = kg;
                }
                if (this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "su_2_4") != "")
                {
                    this.cbxSu_2_4_c.Checked = true;
                }
                if (this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "su_2_1") != ""
                    || this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "su_2_2") != ""
                    || this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "su_2_3") != ""
                    || this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "su_2_4") != "")
                {
                    this.cbxBU_FLAG.Checked = true;
                }
                #endregion

                if (this.grdPHY2000.RowCount < 1)
                    InsertRow_grdPHY2000();
            }
            this.grdReha.QueryLayout(true);
            this.grdPT.QueryLayout(true);
            this.grdOT.QueryLayout(true);
            this.grdST.QueryLayout(true);
            this.grdPHY8003.QueryLayout(true);

           

            if(this.grdPHY2000.RowCount > 0)
            {
                this.setgrdREHA();
                this.setgrdPT();
                this.setgrdOT();
                this.setgrdST();
			}
            else
			    InsertRow_grdPHY2000();

            InitContol();
            this.InitScreen();
		}
        #region [ 각종 초기화 ]

        private void InitScreen()
        {
            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            popupOrderMenu.MenuCommands.Clear();
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "全体選択" : "전체선택", (Image)this.imageListPopupMenu.Images[0],
            //    new EventHandler(PopUpMenuSelectAll_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "選択取消" : "선택취소", (Image)this.imageListPopupMenu.Images[1],
            //    new EventHandler(PopUpMenuUnSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "行削除" : "행삭제", (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuDelete_Click)));
        
        }
        // 처방행삭제
        private void PopUpMenuDelete_Click(object sender, System.EventArgs e)
        {
            if (this.btnList.Enabled)
            {
                this.grdPHY8003.Focus();
                this.btnList.PerformClick(FunctionType.Delete);
                this.grdPHY8003.UnSelectAll();
            }
        }
        #endregion
        public void setgrdREHA()
        {
            string columnName = "reha";
            int row = 1;
            string column = "";
            string data = "";
            for(int i = 1; i <= this.grdReha.RowCount; i++)
            {
                column = columnName + (row++).ToString();
                data = this.grdPHY2000.LayoutTable.Rows[0][column].ToString();
                if (data != "")
                {
                    for (int j = 0; j < this.grdReha.RowCount; j++)
                    {
                        if (data == this.grdReha.GetItemString(j, "code_name"))
                        {
                            this.grdReha.SetItemValue(j, "select", "Y");
                        }
                    }
                }
            }
            
        }

        public void setgrdPT()
        {
            string columnName = "pt";
            int row = 1;
            string column = "";
            string data = "";
            for (int i = 1; i <= this.grdPT.RowCount; i++)
            {
                column = columnName + (row++).ToString();
                data = this.grdPHY2000.LayoutTable.Rows[0][column].ToString();
                if (data != "")
                {
                    for (int j = 0; j < this.grdPT.RowCount; j++)
                    {
                        if (data == this.grdPT.GetItemString(j, "code_name"))
                        {
                            this.grdPT.SetItemValue(j, "select", "Y");
                        }
                    }
                }
            }

        }

        public void setgrdST()
        {
            string columnName = "st";
            int row = 1;
            string column = "";
            string data = "";
            for (int i = 1; i <= this.grdST.RowCount; i++)
            {
                column = columnName + (row++).ToString();
                data = this.grdPHY2000.LayoutTable.Rows[0][column].ToString();
                if (data != "")
                {
                    for (int j = 0; j < this.grdST.RowCount; j++)
                    {
                        if (data == this.grdST.GetItemString(j, "code_name"))
                        {
                            this.grdST.SetItemValue(j, "select", "Y");
                        }
                    }
                }
            }

        }

        public void setgrdOT()
        {
            string columnName = "ot";
            int row = 1;
            string column = "";
            string data = "";
            for (int i = 1; i <= this.grdOT.RowCount; i++)
            {
                column = columnName + (row++).ToString();
                data = this.grdPHY2000.LayoutTable.Rows[0][column].ToString();
                if (data != "")
                {
                    for (int j = 0; j < this.grdOT.RowCount; j++)
                    {
                        if (data == this.grdOT.GetItemString(j, "code_name"))
                        {
                            this.grdOT.SetItemValue(j, "select", "Y");
                        }
                    }
                }
            }

        }
        


        public void InitContol()
        {
            this.cbxSu_2_1.Enabled = false;
            this.cbxSu_2_2.Enabled = false;
            this.cbxSu_2_3.Enabled = false;
            this.cbxSu_2_4_c.Enabled = false;

            this.txtSu_2_4.Enabled = false;

            this.rbtSu_3_1.Enabled = false;
            this.rbtSu_3_2.Enabled = false;
            this.txtKg.Enabled = false;
        }

		public string GetItemXPanel(XPanel con)
		{
			foreach(Control item in con.Controls)
			{
				if (item is XFlatRadioButton)
				{
					if(((XFlatRadioButton)item).Checked)
						return ((XFlatRadioButton)item).CheckedValue;
				}
			}
			return "";
		}

		public void SetItemXPanel(XPanel con, string data)
		{
			if (data == "") return;
			foreach(Control item in con.Controls)
			{
				if (item is XFlatRadioButton)
				{
					if(((XFlatRadioButton)item).CheckedValue == data)
						((XFlatRadioButton)item).Checked = true;
				}
			}
		}


        public void SetNumCombo(XComboBox ctrl, string colName, bool isDecimal)
        {
            DataTable dtTemp = this.LoadComboDataSource(colName).LayoutTable;
            ctrl.SetComboItems(dtTemp, "code_name", "code");
            ctrl.KeyPress += new KeyPressEventHandler(ComBoInt_KeyPress);
        }

        public MultiLayout LoadComboDataSource(string aColName)
        {
            IHIS.Framework.MultiLayout layCombo = new MultiLayout();

            layCombo.Reset();
            layCombo.LayoutItems.Clear();
            layCombo.LayoutItems.Add("code", DataType.String);
            layCombo.LayoutItems.Add("code_name", DataType.String);

            layCombo.InitializeLayoutTable();

            switch (aColName)
            {
                case "nalsu":

                    layCombo.QuerySQL =
                        " SELECT A.CODE CODE, A.CODE CODE_NAME "
                        + "   FROM OCS0132 A "
                        + "  WHERE A.CODE_TYPE = 'NALSU' "
                        + "    AND A.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
                        + "  ORDER BY A.SORT_KEY, A.CODE ";

                    break;
                default:
                    return layCombo; // 빈상태로 넘긴다
                //return (DataLayoutMIO)null;
            }

            layCombo.QueryLayout(true);

            return layCombo;

        }
        /// <summary>
        /// 정수만 등록할 수 있도록 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ComBoInt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            XComboBox numCombo = sender as XComboBox;

            if (e.KeyChar != (char)8 && !TypeCheck.IsInt(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
		
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			int row =0;
			switch(e.Func)
			{
				case FunctionType.Delete:
                    
					break;

				case FunctionType.Update:
                    
                    //Add アップデータ不可能なケース設定
                    if (this.IsJissekiData())
                    {
                        XMessageBox.Show("この依頼件に関しましては実績データが存在するため修正することができません。");
                        break;
                    }

                    this.imageEditor.Save();//更新時点でのイメージ保存

                    InsertGridData();//各種REHA, PT, OT, STの項目をgrdPhy2000に挿入
					break;

				case FunctionType.Query:
                    
					break;
				default:
					break;
			}
		}
        // 依頼件において実績データが存在するのか確認。
        // あればtrue, なければfalse
        private bool IsJissekiData()
        {
            SingleLayout layJissekiData = new SingleLayout();
            
            layJissekiData.LayoutItems.Add("CNT");
            
            layJissekiData.QuerySQL = @"SELECT COUNT(*) 
                                          FROM IFS8052 A 
                                         WHERE A.FK_OCS_IRAI = :f_fk_ocs_irai
                                           AND A.DATA_KUBUN  <> 'D'";

            layJissekiData.SetBindVarValue("f_fk_ocs_irai", this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "fk_ocs_irai"));

            layJissekiData.QueryLayout();

            if (int.Parse(layJissekiData.GetItemValue("CNT").ToString()) < 1)
                return false;
            else
                return true;

        }
        private void InsertGridData()
        {
            string data = "";
            string columnNo = "";
            string selected = "";
            int row = 0;
            //REHA
            for (int i = 0; i < this.grdReha.RowCount; i++)
            {
                this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "reha" + (i + 1).ToString(), "");
            }
            row = 1;
            for (int i = 0; i < this.grdReha.RowCount; i++)
            {
                data = this.grdReha.GetItemString(i, "code_name");
                selected = this.grdReha.GetItemString(i, "select");
                columnNo = "reha" + row.ToString();
                if (selected == "Y")
                {
                    this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, columnNo, data);
                    row++;
                }
            }
            //PT
            for (int i = 0; i < this.grdPT.RowCount; i++)
            {
                this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "pt" + (i + 1).ToString(), "");
            }
            row = 1;
            for (int i = 0; i < this.grdPT.RowCount; i++)
            {
                data = this.grdPT.GetItemString(i, "code_name");
                selected = this.grdPT.GetItemString(i, "select");
                columnNo = "pt" + row.ToString();
                if (selected == "Y")
                {
                    this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, columnNo, data);
                    row++;
                }
            }
            //OT
            for (int i = 0; i < this.grdOT.RowCount; i++)
            {
                this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "ot" + (i + 1).ToString(), "");
            }
            row = 1;
            for (int i = 0; i < this.grdOT.RowCount; i++)
            {
                data = this.grdOT.GetItemString(i, "code_name");
                selected = this.grdOT.GetItemString(i, "select");
                columnNo = "ot" + row.ToString();
                if (selected == "Y")
                {
                    this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, columnNo, data);
                    row++;
                }
            }
            //ST
            for (int i = 0; i < this.grdST.RowCount; i++)
            {
                this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "st" + (i + 1).ToString(), "");
            }
            row = 1;
            for (int i = 0; i < this.grdST.RowCount; i++)
            {
                data = this.grdST.GetItemString(i, "code_name");
                selected = this.grdST.GetItemString(i, "select");
                columnNo = "st" + row.ToString();
                if (selected == "Y")
                {
                    this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, columnNo, data);
                    row++;
                }
            }
        }
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Delete:
                    
                    break;

                case FunctionType.Update:

                    //Add アップデータ不可能なケース設定
                    if (this.IsJissekiData())
                        break;

                    // 트랜잭션 시작
                    try
                    {
                        Service.BeginTransaction();

                        if (e.IsSuccess)
                        {
                            //cr_time, image, image_path, image_seqのセット
                            SetPHY2000Info();
                            if (this.grdPHY2000.SaveLayout() == true)
                            {
                                
                                if (DialogResult.OK == XMessageBox.Show("保存しました.", "保存しました.", MessageBoxButtons.OKCancel))
                                {
                                    Close();
                                }
                            }
                            else
                            {
                                Service.RollbackTransaction();

                                this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                mIsUpdateSuccess = false;

                                return;
                            }
                            //i_seq更新
                            SetSyoubyouKeySeqInfo();
                            if (this.grdPHY8003.SaveLayout() == true)
                            {
                                
                            }
                            else
                            {
                                Service.RollbackTransaction();

                                this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                mIsUpdateSuccess = false;

                                return;
                            }

                        }
                    }
                    catch
                    {
                        Service.RollbackTransaction();

                        mIsUpdateSuccess = false;

                        return;
                    }

                    Service.CommitTransaction();  // 커밋

                    //this.InvokeReturnSendReturnDataTable();

                    

                    break;

                default:
                    break;
            }
        }





        //#region 원래 오더 화면에 데이터 넘기기

        //private void InvokeReturnSendReturnDataTable()
        //{
        //    CommonItemCollection param = new CommonItemCollection();
        //    //入院登録画面と以外の画面とのＲＥＴＵＲＮＧＲＤの変更
            
        //    param.Add("reha_consult_date", this.grdPHY2000);

        //    ((XScreen)this.Opener).Command(this.Name, param);
        //}

        //#endregion
        

		#region OnCommad override
		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch(command.Trim())
			{				
				case "OCS0221Q01": //OCS 상용어

					#region

					if (commandParam.Contains("COMMENT") )
					{
						int    startIndex = 0;
						string setText    = "";
                        
						//현재 Focus된 Text위치에 comment를 Concat한다.
						switch (this.ActiveControl.Name)
						{
                            case "btnStop_kijyun":

                                startIndex = txtStop_kijyun.SelectionStart;

                                setText = txtStop_kijyun.Text.Substring(0, startIndex) + commandParam["COMMENT"].ToString()
                                    + txtStop_kijyun.Text.Substring(startIndex);

                                txtStop_kijyun.SetEditValue(setText);

                                txtStop_kijyun.Focus();
                                if (!TypeCheck.IsNull(txtStop_kijyun.Text)) txtStop_kijyun.SelectionStart = txtStop_kijyun.GetDataValue().Length;
                                txtStop_kijyun.ScrollToCaret();
								break;

							case "btnTaboo":

                                startIndex = txtTaboo.SelectionStart;

                                setText = txtTaboo.Text.Substring(0, startIndex) + commandParam["COMMENT"].ToString()
                                    + txtTaboo.Text.Substring(startIndex);

                                txtTaboo.SetEditValue(setText);

                                txtTaboo.Focus();
                                if (!TypeCheck.IsNull(txtTaboo.Text)) txtTaboo.SelectionStart = txtTaboo.GetDataValue().Length;
                                txtTaboo.ScrollToCaret();
								break;

                            case "btnFrequency":

                                startIndex = txtFrequency.SelectionStart;

                                setText = txtFrequency.Text.Substring(0, startIndex) + commandParam["COMMENT"].ToString()
                                    + txtFrequency.Text.Substring(startIndex);

                                txtFrequency.SetEditValue(setText);

                                txtFrequency.Focus();
                                if (!TypeCheck.IsNull(txtFrequency.Text)) txtFrequency.SelectionStart = txtFrequency.GetDataValue().Length;
                                txtFrequency.ScrollToCaret();
                                break;
							
						}								
					}
					break;
                case "CHT0110Q01":
                    if (commandParam.Contains("CHT0110") && (MultiLayout)commandParam["CHT0110"] != null &&
                        ((MultiLayout)commandParam["CHT0110"]).RowCount > 0)
                    {
                        string sang_name = "";
                        switch (this.mReturnControl)
                        {
                            case "I":
                                sang_name = txtInfectious.GetDataValue();
                                break;
                            case "C":
                                sang_name = txtComplications.GetDataValue();
                                break;
                            
                        }
                        for (int i = 0; i < ((MultiLayout)commandParam["CHT0110"]).RowCount; i++)
                        {
                            if (TypeCheck.IsNull(sang_name))
                                sang_name = sang_name + ((MultiLayout)commandParam["CHT0110"]).GetItemString(i, "sang_name");
                            else
                                sang_name = sang_name + "\r\n" + ((MultiLayout)commandParam["CHT0110"]).GetItemString(i, "sang_name");
                        }

                        switch (this.mReturnControl)
                        {
                            case "I":
                                txtInfectious.Focus();
                                txtInfectious.SetEditValue(sang_name);
                                
                                
                                if (!TypeCheck.IsNull(txtInfectious.Text)) txtInfectious.SelectionStart = sang_name.Length;
                                txtInfectious.ScrollToCaret();
                                txtInfectious.Focus();
                                break;
                            case "C":
                                txtComplications.Focus();
                                txtComplications.SetEditValue(sang_name);
                                
                                
                                if (!TypeCheck.IsNull(txtComplications.Text)) txtComplications.SelectionStart = sang_name.Length;
                                txtComplications.ScrollToCaret();
                                txtComplications.Focus();
                                break;
                        }

                    }
                    break;

                case "OUTSANGQ00":
                    if (commandParam.Contains("OUTSANG") && (MultiLayout)commandParam["OUTSANG"] != null &&
                        ((MultiLayout)commandParam["OUTSANG"]).RowCount > 0)
                    {
                        string sang_name = "";
                        switch (this.mReturnControl)
                        {
                            case "G":
                                 sang_name = txtGenbyoureki.GetDataValue(); 
                                break;
                            case "K":
                                sang_name = txtKioureki.GetDataValue(); 
                                break;
                            case "C":
                                sang_name = txtComplications.GetDataValue(); 
                                break;
                            case "S":
                                
                                
                                break;

                        }
                        
                        for (int i = 0; i < ((MultiLayout)commandParam["OUTSANG"]).RowCount; i++)
                        {
                            if (TypeCheck.IsNull(sang_name))
                                sang_name = sang_name + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name");
                            else
                                sang_name = sang_name + "\r\n" + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name");
                        }

                        switch (this.mReturnControl)
                        {
                            case "G" :
                                txtGenbyoureki.SetEditValue(sang_name);
                                txtGenbyoureki.Focus();
                                if (!TypeCheck.IsNull(txtGenbyoureki.Text)) txtGenbyoureki.SelectionStart = sang_name.Length;
                                txtGenbyoureki.ScrollToCaret();
                                break;
                            case "K":
                                txtKioureki.SetEditValue(sang_name);
                                txtKioureki.Focus();
                                if (!TypeCheck.IsNull(txtGenbyoureki.Text)) txtKioureki.SelectionStart = sang_name.Length;
                                txtKioureki.ScrollToCaret();
                                break;
                            case "C":
                                txtComplications.SetEditValue(sang_name);
                                txtComplications.Focus();
                                if (!TypeCheck.IsNull(txtGenbyoureki.Text)) txtComplications.SelectionStart = sang_name.Length;
                                txtComplications.ScrollToCaret();
                                break;
                            case "S":

                                

                                for (int i = 0; i < ((MultiLayout)commandParam["OUTSANG"]).RowCount; i++)
                                {
                                    //string cmdText = @"SELECT IFS8003_SEQ.NEXTVAL FROM SYS.DUAL";
                                    //object t_chk = Service.ExecuteScalar(cmdText);

                                    this.grdPHY8003.InsertRow(-1);
                                    int currRow = this.grdPHY8003.CurrentRowNumber;
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "syoubyoumei_code", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_code"));

                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "hassyoubi", 
                                        ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_start_date").Replace("/", ""));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "sindanbi",
                                        ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_start_date").Replace("/", ""));


                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "display_syoubyoumei", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "syoubyoumei", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_name"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "hosp_code", EnvironInfo.HospCode);
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "sys_date", EnvironInfo.GetSysDateTime());
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "kanja_no", mBunho);
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "data_kubun", "I");
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "sinryouka", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "gwa"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "io_kubun", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "io_gubun"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "user_id", UserInfo.UserID);
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "irai_date", this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "irai_date"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "fk_ocs_irai", this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "fk_ocs_irai"));
                                    //this.grdIFS8003.SetItemValue(this.grdIFS8003.CurrentRowNumber, "pk_ifs_syoubyou", int.Parse(t_chk.ToString()));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "pre_modifier_name", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "pre_modifier_name"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "post_modifier_name", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "post_modifier_name"));
                                    //this.grdIFS8003.SetItemValue(this.grdIFS8003.CurrentRowNumber, "i_seq", i_seq);
                                    string pre_modifier = "pre_modifier";
                                    string post_modifier = "post_modifier";
                                    //int row = 1;
                                    for (int j = 1; j <= 10; j++)
                                    {
                                        this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, pre_modifier + j.ToString(), ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, pre_modifier+j.ToString()));
                                        this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, post_modifier + j.ToString(), ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, post_modifier + j.ToString()));
                                    }
                                    //checkplz
                                    //foreach (DataColumn cl in ((MultiLayout)commandParam["OUTSANG"]).LayoutTable.Columns)
                                    //{
                                    //    if (grdIFS8003.LayoutTable.Columns.Contains(cl.ColumnName))
                                    //    {
                                    //        this.grdIFS8003.LayoutTable.Rows[currRow][cl.ColumnName] = ((MultiLayout)commandParam["OUTSANG"]).LayoutTable.Rows[i][cl.ColumnName].ToString();
                                    //    }
                                    //}
                                    
                                }
                                

                                break;
                            
                        }
                        
                    }
                    break;

					#endregion
			}

			return base.Command (command, commandParam);
		}

		#endregion

		#region [ OCS 상용어]
		/// <summary>
		/// OCS 상용어 조회
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void linkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			ShowReservedScreen("01");		
		}
	    
		/// <summary>
		/// 상용어 조회화면을 Open한다.
		/// </summary>
		/// <param name="aCategory"></param>
		private void ShowReservedScreen(string aCategory)
		{
			CommonItemCollection openParams = new CommonItemCollection();
			openParams.Add("category_gubun", aCategory );
			XScreen.OpenScreenWithParam(this, "OCSA", "OCS0221Q01", ScreenOpenStyle.ResponseFixed, openParams);	
		}
		#endregion

		private void rb1_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

        private void btnOutsang_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void grdReha_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdReha.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdPT_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPT.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdOT_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOT.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdST_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdST.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void llbGenbyoureki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mReturnControl = "G";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void llbComplications_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mReturnControl = "C";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
            
        }

        private void llbKioureki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mReturnControl = "K";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
            
        }

        private void llbSindanmei_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mReturnControl = "S";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void grdPhy2000_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPHY2000.SetBindVarValue("f_fk_ocs_irai", this.mFkocs);
            grdPHY2000.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }


        //#region [Control]
        /// <summary>
        /// Control Binding, Set Hashtable
        /// 1.Hashtable에 각 DataControl를 Load시켜서 해당 Control의 제어를 용이하게 한다.
        /// 2.해당Control Event Binding
        /// </summary>
        private void SetControl(ref Hashtable htControl, XPanel pnlControl, ref XEditGrid grdControl)
        {
            htControl = new Hashtable();
            string colName = "";

            foreach (object obj in pnlControl.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
                    {
                        colName = ((XTextBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XTextBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XEditMask)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XCheckBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
                    {
                        colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
                    {
                        colName = ((XFindBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        //((XFindBox)obj).FindClick += new System.ComponentModel.CancelEventHandler(Control_FindClick);
                        ((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XDatePicker)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }

                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }
            }
            grdControl.InitializeColumns();
        }

        private void SetControl(ref Hashtable htControl, XGroupBox pnlControl, ref XEditGrid grdControl)
        {
            htControl = new Hashtable();
            string colName = "";

            foreach (object obj in pnlControl.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
                    {
                        colName = ((XTextBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XTextBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XEditMask)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XCheckBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
                    {
                        colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
                    {
                        colName = ((XFindBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        //((XFindBox)obj).FindClick += new System.ComponentModel.CancelEventHandler(Control_FindClick);
                        ((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XDatePicker)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }

                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }
            }
            grdControl.InitializeColumns();
        }

        /// <summary>
        /// 해당 Grid에 Binding 
        /// ** Frame에서 제공하는 SetBindControl이 문제가 있어서 별도 처리.
        /// </summary>
        /// <param name="aGrid"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        private void SetGridBinding(XEditGrid aGrid, string colName, IDataControl control)
        {
            foreach (XEditGridCell cell in aGrid.CellInfos)
            {
                if (cell.CellName == colName)
                    cell.BindControl = control;
            }
        }

        private void Control_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            e.Cancel = false;
            string codeName = "";
            string colName = GetColumnName(sender);

            switch (colName)
            {
            //基本ControlBindingになるが、特別な場合だけここに定義
                case "kg":
                    if (e.DataValue.ToString().Trim() != "")
                        grdPHY2000.SetItemValue(grdPHY2000.CurrentRowNumber, "su_3_1", "");
                        grdPHY2000.SetItemValue(grdPHY2000.CurrentRowNumber, "su_3_2", "");
                        if (this.rbtSu_3_1.Checked == true)
                            grdPHY2000.SetItemValue(grdPHY2000.CurrentRowNumber, "su_3_1", e.DataValue.ToString());
                        else
                            grdPHY2000.SetItemValue(grdPHY2000.CurrentRowNumber, "su_3_2", e.DataValue.ToString());
                    break;
                

                default:
                    break;
            }
        }

        /// <summary>
        /// 해당 항목 Control의 컬럼명을 가져온다.
        /// </summary>
        /// <param name="obj"> 항목 Control</param>
        /// <returns></returns>
        private string GetColumnName(object obj)
        {
            string colName = "";

            if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
            {
                colName = ((XComboBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
            {
                colName = ((XTextBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
            {
                colName = ((XEditMask)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
            {
                colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
            {
                colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
            {
                colName = ((XFindBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
            {
                colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
            }
            return colName;
        }

        #region [XSavePerformer Class]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private PHY1000U00 parent = null;

            public XSavePerformer(PHY1000U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = ""; //PHY2000
                string strCmd = "";  //SCAN001
                object t_chk = "";
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                
                item.BindVarList.Add("f_fk_ocs_irai", parent.mFkocs);
                item.BindVarList.Add("f_io_kubun", parent.mInOutGubun);
                //item.BindVarList.Add("f_pk_ocs_irai", parent.mInOutGubun);

                switch (callerID)
                {
                        //依頼grid
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                //依頼キー
                                //if (item.BindVarList["f_fk_ocs_irai"].VarValue == "")
                                //{
                                //    cmdText = " SELECT PHY2000_IRAI_SEQ.NEXTVAL "
                                //            + "   FROM SYS.DUAL ";

                                //    t_chk = Service.ExecuteScalar(cmdText);

                                //    item.BindVarList.Remove("f_pk_ocs_irai");
                                //    item.BindVarList.Add("f_pk_ocs_irai", t_chk.ToString());

                                //}

                                //item.BindVarList.Add("f_data_kubun", "I");
                                // 키가 입력되지 않은경우 키를 따야함..
                                //ROW単位キー
                                if (item.BindVarList["f_pkphy2000"].VarValue == "")
                                {
                                    cmdText = " SELECT PHY2000_SEQ.NEXTVAL "
                                            + "   FROM SYS.DUAL ";

                                    t_chk = Service.ExecuteScalar(cmdText);

                                    item.BindVarList.Remove("f_pkocskey");
                                    item.BindVarList.Add("f_pkphy2000", t_chk.ToString());
                                    
                                }
                                ////依頼が修正された時の履歴
                                //// 시퀀스 가져오기
                                //if (item.BindVarList["f_r_seq"].VarValue == "")
                                //{
                                //    cmdText = " SELECT MAX(R_SEQ)+1 SEQ "
                                //            + "   FROM PHY2000 "
                                //            + "  WHERE FK_OCS_IRAI = " + item.BindVarList["f_fk_ocs_irai"].VarValue
                                //            + "    AND HOSP_CODE = '" + EnvironInfo.HospCode + "' ";
                                //    t_chk = Service.ExecuteScalar(cmdText);

                                //    if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                //    {
                                //        t_chk = "1";
                                //    }
                                    
                                   
                                //    item.BindVarList.Remove("f_r_seq");
                                //    item.BindVarList.Add("f_r_seq", t_chk.ToString());
                                //}
                                //parent.mR_SEQ = item.BindVarList["f_r_seq"].VarValue;
                                cmdText = @"INSERT INTO PHY2000 (
                                                     SYS_DATE,      USER_ID,                         HOSP_CODE,    PKPHY2000,
                                                     FK_OCS_IRAI,   IO_KUBUN,
                                                     IRAI_DATE,     KANJA_NO,      SINRYOUKA,        SINDANISI,    TANTOUI,
                                                     NYUUINNBI,     BYOUTOU_CODE,  BYOUSITU_CODE,    KAISIBI,      NISSUU,
                                                     KOUMOKU_CODE,  SU_1,          SU_2_1,           SU_2_2,       SU_2_3,
                                                     SU_2_4,        SU_3_1,        SU_3_2,           SU_4_1,       SU_4_2,
                                                     SU_4_3,        REHA1,         REHA2,            REHA3,        REHA4, 
                                                     REHA5,         PT1,           PT2,              PT3,          PT4,
                                                     PT5,           PT6,           PT7,              PT8,          PT9,
                                                     PT10,          OT1,           OT2,              OT3,          OT4,
                                                     OT5,           OT6,           OT7,              OT8,          OT9,
                                                     OT10,          ST1,           ST2,              ST3,          ST4,
                                                     ST5,           ST6,           ST7,              ST8,          ST9,
                                                     ST10,          OBJECTIVE,     CONSULT_COMMENT,  GENBYOUREKI,  COMPLICATIONS,
                                                     TABOO,         STOP_KIJYUN,   FREQUENCY,        INFECTIOUS,   KIOUREKI,
                                                     SYORI_FLAG,    PT_FLAG,       OT_FLAG,          ST_FLAG,      BU_FLAG,
                                                     IMAGE,         IMAGE_PATH,    IMAGE_SEQ,        CR_TIME)
                                            values( sysdate,            :f_user_id,                             :f_hosp_code,       :f_pkphy2000,
                                                    :f_fk_ocs_irai,     :f_io_kubun,
                                                    :f_irai_date,       :f_kanja_no,        :f_sinryouka,             :f_sindani,         :f_tantoui,
                                                    :f_nyuuinnbi,       :f_byoutou_code,    :byousitu_code,     :f_kaisibi,         :f_nissuu,
                                                    :f_koumoku_code,    :f_su_1,            :f_su_2_1,          :f_su_2_2,          :f_su_2_3,
                                                    :f_su_2_4,          :f_su_3_1,          :f_su_3_2,          :f_su_4_1,          :f_su_4_2,
                                                    :f_su_4_3,          :f_reha1,           :f_reha2,           :f_reha3,           :f_reha4,
                                                    :f_reha5,           :f_pt1,             :f_pt2,             :f_pt3,             :f_pt4,
                                                    :f_pt5,             :f_pt6,             :f_pt7,             :f_pt8,             :f_pt9,
                                                    :f_pt10,            :f_ot1,             :f_ot2,             :f_ot3,             :f_ot4,
                                                    :f_ot5,             :f_ot6,             :f_ot7,             :f_ot8,             :f_ot9,
                                                    :f_ot10,            :f_st1,             :f_st2,             :f_st3,             :f_st4,
                                                    :f_st5,             :f_st6,             :f_st7,             :f_st8,             :f_st9,
                                                    :f_st10,            :f_objective,       :f_consult_comment, :f_genbyoureki,     :f_complications, 
                                                    :f_taboo,           :f_stop_kijyun,     :f_frequency,       :f_infectious,      :f_kioureki, 
                                                    :f_syori_flag,      :f_pt_flag,         :f_ot_flag,         :f_st_flag,         :f_bu_flag, 
                                                    :f_image,           :f_image_path,      :f_image_seq,       TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
                                                    )";




                                //image save
                                for (int i = 0; i < parent.grdPHY2000.RowCount; i++)
                                {
                                    item.BindVarList.Add("f_pkscan001", parent.mPKSCAN001);
                                    item.BindVarList.Add("f_fkocs", parent.grdPHY2000.GetItemString(i, "fk_ocs_irai"));
                                    item.BindVarList.Add("f_system", "REHA");
                                    item.BindVarList.Add("f_jundal_part", "REHA");
                                    item.BindVarList.Add("f_kanja_no", parent.mBunho);
                                    item.BindVarList.Add("f_image_path", item.BindVarList["f_image_path"].VarValue);
                                    item.BindVarList.Add("f_image", item.BindVarList["f_image"].VarValue);
                                    item.BindVarList.Add("f_seq", parent.mPKSCAN001);
                                    item.BindVarList.Add("f_user_id", UserInfo.UserID);
                                    item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);


                                    
                                    //Hashtable inputList = new Hashtable();
                                    //Hashtable outputList = new Hashtable();

                                    strCmd = @"INSERT INTO SCAN001 (SYS_DATE, UPD_ID, UPD_DATE
                                                          ,PKSCAN001
                                                          ,FKOCS
                                                          ,SYSTEM
                                                          ,CR_TIME
                                                          ,JUNDAL_PART
                                                          ,BUNHO
                                                          ,IMAGE_PATH
                                                          ,IMAGE
                                                          ,SEQ
                                                          ,SYS_ID
                                                          ,HOSP_CODE
                                                        ) VALUES ( SYSDATE
                                                          ,:f_user_id 
                                                          ,SYSDATE
                                                          ,:f_pkscan001
                                                          ,:f_fkocs
                                                          ,:f_system
                                                          ,TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
                                                          ,'REHA'
                                                          ,:f_kanja_no
                                                          ,:f_image_path
                                                          ,:f_image
                                                          ,:f_seq
                                                          ,:f_user_id
                                                          ,:f_hosp_code) ";

                                    if (Service.ExecuteNonQuery(strCmd, item.BindVarList))
                                    {
                                        //inputList.Clear();
                                        //outputList.Clear();
                                        //inputList.Add("I_IN_OUT_GUBUN", parent.grdPHY2000.GetItemString(parent.grdPHY2000.CurrentRowNumber, "io_kubun"));
                                        //inputList.Add("I_FKOCS", parent.grdPHY2000.GetItemInt(i, "fkocskey"));
                                        //inputList.Add("I_RESULT_BUSEO", "REHA");
                                        //inputList.Add("I_RESULT_DATE", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                                        //if (Service.ExecuteProcedure("PR_OCS_UPDATE_RESULT", inputList, outputList))
                                        //{

                                        //}
                                        //else
                                        //{
                                        //    XMessageBox.Show(Service.ErrFullMsg);
                                        //}
                                    }
                                    else
                                        XMessageBox.Show(Service.ErrFullMsg);
                                }
                                            
                                break;
                            case DataRowState.Modified:
                                //parent.InsertInitValues();
                                //item.BindVarList.Add("f_data_kubun", "U");
                                // 시퀀스 가져오기
                                //if (item.BindVarList["f_r_seq"].VarValue != "")
                                //{
                                //    cmdText = " SELECT MAX(R_SEQ)+1 SEQ "
                                //            + "   FROM PHY2000 "
                                //            + "  WHERE FKOCSKEY = " + item.BindVarList["f_fkocskey"].VarValue
                                //            + "    AND HOSP_CODE = '" + EnvironInfo.HospCode + "' ";
                                //    t_chk = Service.ExecuteScalar(cmdText);

                                //    if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                //    {
                                //        t_chk = "1";
                                //    }
                                    
                                //    item.BindVarList.Remove("f_r_seq");
                                //    item.BindVarList.Add("f_r_seq", t_chk.ToString());
                                //}
                                //parent.mR_SEQ = item.BindVarList["f_r_seq"].VarValue;
                                
                                //PHY2000 ROW SEQUENCE
                                cmdText = " SELECT PHY2000_SEQ.NEXTVAL "
                                            + "   FROM SYS.DUAL ";

                                t_chk = Service.ExecuteScalar(cmdText);

                                item.BindVarList.Remove("f_pkocskey");
                                item.BindVarList.Add("f_pkphy2000", t_chk.ToString());
                                
//                                cmdText = @"insert into phy2000 (
//                                                     SYS_DATE,      USER_ID,       UPD_DATE,         HOSP_CODE,    PKPHY2000,
//                                                     FK_OCS_IRAI,   IO_KUBUN,
//                                                     IRAI_DATE,     KANJA_NO,      SINRYOUKA,        SINDANISI,    TANTOUI,
//                                                     NYUUINNBI,     BYOUTOU_CODE,  BYOUSITU_CODE,    KAISIBI,      NISSUU,
//                                                     KOUMOKU_CODE,  SU_1,          SU_2_1,           SU_2_2,       SU_2_3,
//                                                     SU_2_4,        SU_3_1,        SU_3_2,           SU_4_1,       SU_4_2,
//                                                     SU_4_3,        REHA1,         REHA2,            REHA3,        REHA4, 
//                                                     REHA5,         PT1,           PT2,              PT3,          PT4,
//                                                     PT5,           PT6,           PT7,              PT8,          PT9,
//                                                     PT10,          OT1,           OT2,              OT3,          OT4,
//                                                     OT5,           OT6,           OT7,              OT8,          OT9,
//                                                     OT10,          ST1,           ST2,              ST3,          ST4,
//                                                     ST5,           ST6,           ST7,              ST8,          ST9,
//                                                     ST10,          OBJECTIVE,     CONSULT_COMMENT,  GENBYOUREKI,  COMPLICATIONS,
//                                                     TABOO,         STOP_KIJYUN,   FREQUENCY,        INFECTIOUS,   KIOUREKI,
//                                                     SYORI_FLAG,    PT_FLAG,       OT_FLAG,          ST_FLAG,      BU_FLAG,
//                                                     IMAGE,         IMAGE_PATH,    IMAGE_SEQ,        CR_TIME)
//                                            values( sysdate,            :f_user_id,         sysdate,            :f_hosp_code,       :f_pkphy2000,
//                                                    :f_fk_ocs_irai,     :f_io_kubun,
//                                                    :f_irai_date,       :f_kanja_no,        :f_sinryouka,             :f_sindani,         :f_tantoui,
//                                                    :f_nyuuinnbi,       :f_byoutou_code,    :byousitu_code,     :f_kaisibi,         :f_nissuu,
//                                                    :f_koumoku_code,    :f_su_1,            :f_su_2_1,          :f_su_2_2,          :f_su_2_3,
//                                                    :f_su_2_4,          :f_su_3_1,          :f_su_3_2,          :f_su_4_1,          :f_su_4_2,
//                                                    :f_su_4_3,          :f_reha1,           :f_reha2,           :f_reha3,           :f_reha4,
//                                                    :f_reha5,           :f_pt1,             :f_pt2,             :f_pt3,             :f_pt4,
//                                                    :f_pt5,             :f_pt6,             :f_pt7,             :f_pt8,             :f_pt9,
//                                                    :f_pt10,            :f_ot1,             :f_ot2,             :f_ot3,             :f_ot4,
//                                                    :f_ot5,             :f_ot6,             :f_ot7,             :f_ot8,             :f_ot9,
//                                                    :f_ot10,            :f_st1,             :f_st2,             :f_st3,             :f_st4,
//                                                    :f_st5,             :f_st6,             :f_st7,             :f_st8,             :f_st9,
//                                                    :f_st10,            :f_objective,       :f_consult_comment, :f_genbyoureki,     :f_complications, 
//                                                    :f_taboo,           :f_stop_kijyun,     :f_frequency,       :f_infectious,      :f_kioureki, 
//                                                    :f_syori_flag,      :f_pt_flag,         :f_ot_flag,         :f_st_flag,         :f_bu_flag, 
//                                                    :f_image,           :f_image_path,      :f_image_seq,       TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
//                                                    )";

                                cmdText = @"UPDATE  PHY2000 
                                               set  USER_ID         =:f_user_id,
                                                    UPD_DATE        =sysdate,
                                                    IRAI_DATE       =:f_irai_date,
                                                    KAISIBI         =:f_kaisibi,
                                                    NISSUU          =:f_nissuu,
                                                    SU_1            =:f_su_1,
                                                    SU_2_1          =:f_su_2_1,
                                                    SU_2_2          =:f_su_2_2,
                                                    SU_2_3          =:f_su_2_3,
                                                    SU_2_4          =:f_su_2_4,
                                                    SU_3_1          =:f_su_3_1,
                                                    SU_3_2          =:f_su_3_2,
                                                    SU_4_1          =:f_su_4_1,
                                                    SU_4_2          =:f_su_4_2,
                                                    SU_4_3          =:f_su_4_3,
                                                    REHA1           =:f_reha1,
                                                    REHA2           =:f_reha2,
                                                    REHA3           =:f_reha3,
                                                    REHA4           =:f_reha4, 
                                                    REHA5           =:f_reha5,
                                                    PT1             =:f_pt1,
                                                    PT2             =:f_pt2,
                                                    PT3             =:f_pt3,
                                                    PT4             =:f_pt4,
                                                    PT5             =:f_pt5,
                                                    PT6             =:f_pt6,
                                                    PT7             =:f_pt7,
                                                    PT8             =:f_pt8,
                                                    PT9             =:f_pt9,
                                                    PT10            =:f_pt10,
                                                    OT1             =:f_ot1,
                                                    OT2             =:f_ot2,
                                                    OT3             =:f_ot3,
                                                    OT4             =:f_ot4,
                                                    OT5             =:f_ot5,
                                                    OT6             =:f_ot6, 
                                                    OT7             =:f_ot7, 
                                                    OT8             =:f_ot8,
                                                    OT9             =:f_ot9,
                                                    OT10            =:f_ot10,  
                                                    ST1             =:f_st1, 
                                                    ST2             =:f_st2,  
                                                    ST3             =:f_st3, 
                                                    ST4             =:f_st4,
                                                    ST5             =:f_st5, 
                                                    ST6             =:f_st6,  
                                                    ST7             =:f_st7,   
                                                    ST8             =:f_st8,  
                                                    ST9             =:f_st9,
                                                    ST10            =:f_st10, 
                                                    OBJECTIVE       =:f_objective,
                                                    CONSULT_COMMENT =:f_consult_comment, 
                                                    GENBYOUREKI     =:f_genbyoureki, 
                                                    COMPLICATIONS   =:f_complications,
                                                    TABOO           =:f_taboo,  
                                                    STOP_KIJYUN     =:f_stop_kijyun, 
                                                    FREQUENCY       =:f_frequency,  
                                                    INFECTIOUS      =:f_infectious,
                                                    KIOUREKI        =:f_kioureki,
                                                    SYORI_FLAG      =:f_syori_flag, 
                                                    PT_FLAG         =:f_pt_flag,   
                                                    OT_FLAG         =:f_ot_flag,      
                                                    ST_FLAG         =:f_st_flag,    
                                                    BU_FLAG         =:f_bu_flag,
                                                    IMAGE           =:f_image,  
                                                    IMAGE_PATH      =:f_image_path,
                                                    IMAGE_SEQ       =:f_image_seq,       
                                                    CR_TIME         =TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
                                             WHERE FK_OCS_IRAI      = :f_fk_ocs_irai
                                               AND HOSP_CODE        = :f_hosp_code
                                               AND IO_KUBUN         = :f_io_kubun";

                                //string strCmd = "";
                                
                                //image save
                                
                                for (int i = 0; i < parent.grdPHY2000.RowCount; i++)
                                {
                                    item.BindVarList.Add("f_pkscan001", parent.mPKSCAN001);
                                    item.BindVarList.Add("f_fkocs", parent.grdPHY2000.GetItemString(i, "fk_ocs_irai"));
                                    item.BindVarList.Add("f_system", "REHA");
                                    item.BindVarList.Add("f_jundal_part", "REHA");
                                    item.BindVarList.Add("f_kanja_no", parent.mBunho);
                                    //item.BindVarList.Add("f_image_path", item.BindVarList["f_image_path"].VarValue);
                                    //item.BindVarList.Add("f_image", item.BindVarList["f_image"].VarValue);
                                    item.BindVarList.Add("f_seq", parent.mPKSCAN001);
                                    item.BindVarList.Add("f_user_id", UserInfo.UserID);
                                    item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                                }

                                strCmd = @"INSERT INTO SCAN001 (SYS_DATE, UPD_ID, UPD_DATE
                                                          ,PKSCAN001
                                                          ,FKOCS
                                                          ,SYSTEM
                                                          ,CR_TIME
                                                          ,JUNDAL_PART
                                                          ,BUNHO
                                                          ,IMAGE_PATH
                                                          ,IMAGE
                                                          ,SEQ
                                                          ,SYS_ID
                                                          ,HOSP_CODE
                                                        ) VALUES ( SYSDATE
                                                          ,:f_user_id 
                                                          ,SYSDATE
                                                          ,:f_pkscan001
                                                          ,:f_fkocs
                                                          ,:f_system
                                                          ,TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
                                                          ,'REHA'
                                                          ,:f_kanja_no
                                                          ,:f_image_path
                                                          ,:f_image
                                                          ,:f_seq
                                                          ,:f_user_id
                                                          ,:f_hosp_code) ";

                                if (Service.ExecuteNonQuery(strCmd, item.BindVarList))
                                {
                                    //inputList.Clear();
                                    //outputList.Clear();
                                    //inputList.Add("I_IN_OUT_GUBUN", parent.grdPHY2000.GetItemString(parent.grdPHY2000.CurrentRowNumber, "io_kubun"));
                                    //inputList.Add("I_FKOCS", parent.grdPHY2000.GetItemInt(i, "fkocskey"));
                                    //inputList.Add("I_RESULT_BUSEO", "REHA");
                                    //inputList.Add("I_RESULT_DATE", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                                    //if (Service.ExecuteProcedure("PR_OCS_UPDATE_RESULT", inputList, outputList))
                                    //{

                                    //}
                                    //else
                                    //{
                                    //    XMessageBox.Show(Service.ErrFullMsg);
                                    //}
                                }
                                else
                                    XMessageBox.Show(Service.ErrFullMsg);



                                break;
                            case DataRowState.Deleted:
                                //item.BindVarList.Add("f_data_kubun", "D");
                                cmdText = @"";
                                break;
                        }
                        break;

                        // 傷病grid
                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                item.BindVarList["f_data_kubun"].VarValue = "I";

                                cmdText = @"INSERT INTO PHY8003(SYS_DATE,
                                                                USER_ID,
                                                                HOSP_CODE,
                                                                PK_IFS_SYOUBYOU,
                                                                FK_OCS_IRAI,
                                                                DATA_KUBUN,
                                                                I_SEQ,
                                                                IO_KUBUN,
                                                                IRAI_DATE,
                                                                KANJA_NO,
                                                                SINRYOUKA,
                                                                SYOUBYOUMEI_CODE,
                                                                PRE_MODIFIER1,
                                                                PRE_MODIFIER2,
                                                                PRE_MODIFIER3,
                                                                PRE_MODIFIER4,
                                                                PRE_MODIFIER5,
                                                                PRE_MODIFIER6,
                                                                PRE_MODIFIER7,
                                                                PRE_MODIFIER8,
                                                                PRE_MODIFIER9,
                                                                PRE_MODIFIER10,
                                                                POST_MODIFIER1,
                                                                POST_MODIFIER2,
                                                                POST_MODIFIER3,
                                                                POST_MODIFIER4,
                                                                POST_MODIFIER5,
                                                                POST_MODIFIER6,
                                                                POST_MODIFIER7,
                                                                POST_MODIFIER8,
                                                                POST_MODIFIER9,
                                                                POST_MODIFIER10,
                                                                HASSYOUBI,
                                                                SINDANBI,
                                                                PRE_MODIFIER_NAME,
                                                                POST_MODIFIER_NAME,
                                                                SYOUBYOUMEI
                                                                )
                                            VALUES( sysdate,
                                                    :f_user_id,
                                                    :f_hosp_code,
                                                    :f_pk_ifs_syoubyou,
                                                    :f_fk_ocs_irai,
                                                    :f_data_kubun,
                                                    :f_i_seq,
                                                    :f_io_kubun,
                                                    :f_irai_date,
                                                    :f_kanja_no,
                                                    :f_sinryouka,
                                                    :f_syoubyoumei_code,
                                                    :f_pre_modifier1,
                                                    :f_pre_modifier2,
                                                    :f_pre_modifier3,
                                                    :f_pre_modifier4,
                                                    :f_pre_modifier5,
                                                    :f_pre_modifier6,
                                                    :f_pre_modifier7,
                                                    :f_pre_modifier8,
                                                    :f_pre_modifier9,
                                                    :f_pre_modifier10,
                                                    :f_post_modifier1,
                                                    :f_post_modifier2,
                                                    :f_post_modifier3,
                                                    :f_post_modifier4,
                                                    :f_post_modifier5,
                                                    :f_post_modifier6,
                                                    :f_post_modifier7,
                                                    :f_post_modifier8,
                                                    :f_post_modifier9,
                                                    :f_post_modifier10,
                                                    :f_hassyoubi,
                                                    :f_sindanbi,
                                                    :f_pre_modifier_name,
                                                    :f_post_modifier_name,
                                                    :f_syoubyoumei
                                                    )";
                                break;
                            case DataRowState.Modified:
                                item.BindVarList["f_data_kubun"].VarValue = "U";

                                //依頼が修正された時の履歴
                                // 시퀀스 가져오기
                                //if (item.BindVarList["f_r_seq"].VarValue == "")
                                //{
                                //    cmdText = " SELECT MAX(I_SEQ)+1 SEQ "
                                //            + "   FROM IFS8003 "
                                //            + "  WHERE FK_OCS_IRAI = " + item.BindVarList["f_fk_ocs_irai"].VarValue
                                //            + "    AND HOSP_CODE = '" + EnvironInfo.HospCode + "' ";
                                //    t_chk = Service.ExecuteScalar(cmdText);

                                //    if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                //    {
                                //        t_chk = "1";
                                //    }


                                //    item.BindVarList.Remove("f_i_seq");
                                //    item.BindVarList.Add("f_i_seq", t_chk.ToString());
                                //}
                                //parent.mR_SEQ = item.BindVarList["f_r_seq"].VarValue;

                                cmdText = @"INSERT INTO PHY8003(SYS_DATE,
                                                                USER_ID,
                                                                HOSP_CODE,
                                                                PK_IFS_SYOUBYOU,
                                                                FK_OCS_IRAI,
                                                                DATA_KUBUN,
                                                                I_SEQ,
                                                                IO_KUBUN,
                                                                IRAI_DATE,
                                                                KANJA_NO,
                                                                SINRYOUKA,
                                                                SYOUBYOUMEI_CODE,
                                                                PRE_MODIFIER1,
                                                                PRE_MODIFIER2,
                                                                PRE_MODIFIER3,
                                                                PRE_MODIFIER4,
                                                                PRE_MODIFIER5,
                                                                PRE_MODIFIER6,
                                                                PRE_MODIFIER7,
                                                                PRE_MODIFIER8,
                                                                PRE_MODIFIER9,
                                                                PRE_MODIFIER10,
                                                                POST_MODIFIER1,
                                                                POST_MODIFIER2,
                                                                POST_MODIFIER3,
                                                                POST_MODIFIER4,
                                                                POST_MODIFIER5,
                                                                POST_MODIFIER6,
                                                                POST_MODIFIER7,
                                                                POST_MODIFIER8,
                                                                POST_MODIFIER9,
                                                                POST_MODIFIER10,
                                                                HASSYOUBI,
                                                                SINDANBI,
                                                                PRE_MODIFIER_NAME,
                                                                POST_MODIFIER_NAME,
                                                                SYOUBYOUMEI
                                                                )
                                            VALUES( sysdate,
                                                    :f_user_id,
                                                    :f_hosp_code,
                                                    :f_pk_ifs_syoubyou,
                                                    :f_fk_ocs_irai,
                                                    :f_data_kubun,
                                                    :f_i_seq,
                                                    :f_io_kubun,
                                                    :f_irai_date,
                                                    :f_kanja_no,
                                                    :f_sinryouka,
                                                    :f_syoubyoumei_code,
                                                    :f_pre_modifier1,
                                                    :f_pre_modifier2,
                                                    :f_pre_modifier3,
                                                    :f_pre_modifier4,
                                                    :f_pre_modifier5,
                                                    :f_pre_modifier6,
                                                    :f_pre_modifier7,
                                                    :f_pre_modifier8,
                                                    :f_pre_modifier9,
                                                    :f_pre_modifier10,
                                                    :f_post_modifier1,
                                                    :f_post_modifier2,
                                                    :f_post_modifier3,
                                                    :f_post_modifier4,
                                                    :f_post_modifier5,
                                                    :f_post_modifier6,
                                                    :f_post_modifier7,
                                                    :f_post_modifier8,
                                                    :f_post_modifier9,
                                                    :f_post_modifier10,
                                                    :f_hassyoubi,
                                                    :f_sindanbi,
                                                    :f_pre_modifier_name,
                                                    :f_post_modifier_name,
                                                    :f_syoubyoumei
                                                    )";
                                break;
//                            
                            case DataRowState.Deleted:
                                cmdText = @"UPDATE PHY8003
                                               SET DATA_KUBUN = 'D'
                                             WHERE FK_OCS_IRAI = :f_fk_ocs_irai
                                               AND HOSP_CODE   = :f_hosp_code
                                               AND I_SEQ       = :f_i_seq";
                                break;

                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void PHY1000U00_Load(object sender, EventArgs e)
        {
            SetControl(ref htPHY2000, pnlCenter, ref grdPHY2000);
            SetControl(ref htPHY2000, pnlTopInfo, ref grdPHY2000);
            SetControl(ref htPHY2000, pnlSu, ref grdPHY2000);
            SetControl(ref htPHY2000, gbxComplications, ref grdPHY2000);
            SetControl(ref htPHY2000, gbxGenbyoureki, ref grdPHY2000);
            SetControl(ref htPHY2000, gbxKioureki, ref grdPHY2000);

            SetControl(ref htPHY2000, gbxPT, ref grdPHY2000);
            SetControl(ref htPHY2000, gbxOT, ref grdPHY2000);
            SetControl(ref htPHY2000, gbxST, ref grdPHY2000);

            SetControl(ref htPHY2000, pnlRightUnderLeft, ref grdPHY2000);
            SetControl(ref htPHY2000, pnlRightUnderRight, ref grdPHY2000);

        }
        private void InsertRow_grdPHY2000()
        {
            this.AcceptData();
            object t_chk;
            string cmdText = "";
            string fk_ocs_irai = this.OpenParam["pkocskey"].ToString();
            
            //依頼キー発行
            cmdText = " SELECT PHY2000_IRAI_SEQ.NEXTVAL "
                    + "   FROM SYS.DUAL ";
            t_chk = Service.ExecuteScalar(cmdText);
            if (fk_ocs_irai == "") return;

            int insertRow = this.grdPHY2000.InsertRow(-1);
            
            this.dptKaisibi.SetEditValue(EnvironInfo.GetSysDate());
            this.dptKaisibi.AcceptData();

            //this.grdPHY2000.SetItemValue(insertRow, "pk_ocs_irai", t_chk.ToString());

            //cmdText = " SELECT MAX(R_SEQ)+1 SEQ "
            //        + "   FROM PHY2000 "
            //        + "  WHERE PK_OCS_IRAI = " + this.grdPHY2000.GetItemString(insertRow, "pk_ocs_irai")
            //        + "    AND HOSP_CODE = '" + EnvironInfo.HospCode + "' ";
            //t_chk = Service.ExecuteScalar(cmdText);

            //if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
            //{
            //    t_chk = "1";
            //}
            //this.grdPHY2000.SetItemValue(insertRow, "r_seq", t_chk.ToString());

            InsertInitValues();
           
        }
        private void InsertInitValues()
        {
            //initial value
            string strsql = "   SELECT SCAN001_SEQ.NEXTVAL FROM DUAL ";

            object retVal = Service.ExecuteScalar(strsql);

            if (retVal == null)
            {
                retVal = "1";
            }
            this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "sys_date", EnvironInfo.GetSysDateTime());
            this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "fk_ocs_irai", this.OpenParam["pkocskey"].ToString());
            this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "kanja_no", this.OpenParam["bunho"].ToString());
            this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "sinryouka", UserInfo.Gwa);
            this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "koumoku_code", this.OpenParam["hangmog_code"].ToString());
            this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "sindanisi", UserInfo.UserID);
            this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "kaisibi", EnvironInfo.GetSysDateTime().ToString("yyyy/MM/dd"));




            if (this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "irai_date") == "")
                this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "irai_date", EnvironInfo.GetSysDateTime().ToString("yyyyMMdd"));
        }

        private void SetPHY2000Info()
        {
            //initial value
            string ho_dong = "";
            string ho_code = "";
            string strsql = "   SELECT SCAN001_SEQ.NEXTVAL FROM DUAL ";
            int CurrentRowNum = this.grdPHY2000.CurrentRowNumber;
            object retVal = Service.ExecuteScalar(strsql);

            if (retVal == null)
            {
                retVal = "1";
            }
            this.mPKSCAN001 = retVal.ToString();
            string irai_date = TypeCheck.NVL(this.grdPHY2000.GetItemString(CurrentRowNum, "irai_date"), EnvironInfo.GetSysDateTime().ToString()).ToString();
            string path = mPathNm + "/"

                + "REHA" + "/"
                + "REHA" + "/"
                + irai_date.Substring(0, 4) + "/"
                + irai_date + "/";
            string name = mBunho + "."
               + this.grdPHY2000.GetItemString(CurrentRowNum, "irai_date").Replace("/", "") + "."
               + this.mPKSCAN001 + ".JPG";
            this.grdPHY2000.SetItemValue(CurrentRowNum, "image_path", path);
            this.grdPHY2000.SetItemValue(CurrentRowNum, "image", name);
            this.grdPHY2000.SetItemValue(CurrentRowNum, "image_seq", this.mPKSCAN001);
            this.grdPHY2000.SetItemValue(CurrentRowNum, "cr_time", EnvironInfo.GetSysDateTime());

            // 入院患者の場合は入院日、病棟、病室までINSERTする。
            if (this.mInOutGubun == "I")
            {
                //病棟、病室
                strsql = "   SELECT FN_INP_LOAD_JAEWON_GO_DONG('"+ this.mBunho +"') FROM DUAL ";
                retVal = Service.ExecuteScalar(strsql);
                if (retVal.ToString() != "")
                {
                    string [] str = retVal.ToString().Split('-');

                    if (str[0].ToString() != "" && str[1].ToString() != "")
                    {
                        ho_dong = str[0].ToString();
                        ho_code = str[1].ToString();
                    }

                    this.grdPHY2000.SetItemValue(CurrentRowNum, "byoutou_code", ho_dong);
                    this.grdPHY2000.SetItemValue(CurrentRowNum, "byousitu_code", ho_code);
                }

                //入院日
                strsql = "SELECT FN_INP_LOAD_LAST_IPWON('" + mBunho + "') FROM SYS.DUAL";
                retVal = Service.ExecuteScalar(strsql);
                if (retVal.ToString() != "")
                {
                    this.grdPHY2000.SetItemValue(CurrentRowNum, "nyuuinnbi", retVal.ToString());
                }
            }

            
            //this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "upd_date", EnvironInfo.GetSysDateTime());//queryでSYSDATEに挿入
        }
        private void SetSyoubyouKeySeqInfo()
        {
            //PHY2000 inser, update 時新しく生成されたR_SEQを全域関数で持ってくる。
            string cmdText = " SELECT MAX(I_SEQ)+1 SEQ "
                                            + "   FROM PHY8003 "
                                            + "  WHERE FK_OCS_IRAI = " + mFkocs
                                            + "    AND HOSP_CODE = '" + EnvironInfo.HospCode + "' ";

            object i_seq_chk = Service.ExecuteScalar(cmdText);
            object pk_chk;
            if (TypeCheck.IsNull(i_seq_chk) || i_seq_chk.ToString() == "")
                i_seq_chk = "1";

            for (int i = 0; i < this.grdPHY8003.RowCount; i++)
            {
                int i_seq = int.Parse(i_seq_chk.ToString());

                this.grdPHY8003.SetItemValue(i, "i_seq", i_seq);

                cmdText = @"SELECT PHY8003_SEQ.NEXTVAL FROM SYS.DUAL";
                pk_chk = Service.ExecuteScalar(cmdText);
                this.grdPHY8003.SetItemValue(i, "pk_ifs_syoubyou", int.Parse(pk_chk.ToString()));
            }

            

        }
        private void rbtSu_3_1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtKg.SetDataValue("");
            this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "su_3_1", "");
            this.grdPHY2000.SetItemValue(this.grdPHY2000.CurrentRowNumber, "su_3_2", "");
        }

        private void cbxBU_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxBU_FLAG.Checked == true)
            {
                this.cbxSu_2_1.Enabled = true;
                this.cbxSu_2_2.Enabled = true;
                this.cbxSu_2_3.Enabled = true;
                this.cbxSu_2_4_c.Enabled = true;
                this.txtSu_2_4.Enabled = true;
            }
            else
            {

                this.cbxSu_2_1.Enabled = false;
                this.cbxSu_2_2.Enabled = false;
                this.cbxSu_2_3.Enabled = false;
                this.cbxSu_2_4_c.Enabled = false;
                this.txtSu_2_4.Enabled = false;
            }
        }

        private void cbxSu_3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxSu_3.Checked == true)
            {
                this.rbtSu_3_1.Enabled = true;
                this.rbtSu_3_2.Enabled = true;
                this.txtKg.Enabled = true;
            }
            else
            {
                this.rbtSu_3_1.Enabled = false;
                this.rbtSu_3_2.Enabled = false;
                this.txtKg.Enabled = false;
            }
        }

        private void grdIFS8003_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPHY8003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPHY8003.SetBindVarValue("f_kanja_no", mBunho);
            this.grdPHY8003.SetBindVarValue("f_sinryouka", mGwa);
            this.grdPHY8003.SetBindVarValue("f_io_kubun", mInOutGubun);
            this.grdPHY8003.SetBindVarValue("f_fk_ocs_irai", this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "fk_ocs_irai"));
            //this.grdIFS8003.SetBindVarValue("f_i_seq", this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "r_seq"));
        }

        private void grdPHY2000_SaveEnd(object sender, SaveEndEventArgs e)
        {
            
            /////////////////////
            string jundal_part = "REHA";
            string irai_date = this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "irai_date");
            string image_name = this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "image");

            Image image = imageEditor.Image;
            string filePath = Directory.GetParent(Application.StartupPath) + "\\" + "REHA" + "Images" + "\\" + jundal_part;
            //파일경로가 없으면 생성
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            //Image를 Client 파일로 저장(파일명은 서버파일명으로)한후에 FTP를 통해 서버로 Upload
            string fileName = Directory.GetParent(Application.StartupPath) + "\\" + "REHA" + "Images" + "\\" + jundal_part + "\\" + image_name;
            //Image를 지정한 파일로 저장
            if (!ImageHelper.SaveImageFile(image, fileName)) return;

            string clientFilePath = Directory.GetParent(Application.StartupPath) + "\\" + "REHA" + "Images" + "\\" + jundal_part;

            /*
                * 추후 경로변경 필요
                * "/IFCImage/..."를 "/IHISImage/..."로 변경필요
                * 
            * */
            string serverFilePath = mPathNm + "/"
                //+ this.cboSystem.GetDataValue().Substring(0, 3) + "/"
                    + "REHA" + "/"
                    + "REHA" + "/"
                    + irai_date.Substring(0, 4) + "/"
                    + irai_date;
            //					string serverFilePath = "/IHISImage/" + cboSystem.GetDataValue().Substring(0,3) + "/" + jundal_part;
            ArrayList uploadFileInfoList = new ArrayList();
            uploadFileInfoList.Add(new ImageFileInfo(clientFilePath, serverFilePath, image_name, image_name));

            //Upload 실패시 Return
            if (!ImageHelper.UploadImages(uploadFileInfoList, true))
                return;

        }

        private void grdPHY2000_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            
        }

        private void grdPHY2000_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //imageEditor.Image = null;

            if (grdPHY2000.RowCount < 1) return;

            if (grdPHY2000.GetRowState(e.CurrentRow) == DataRowState.Unchanged)
            {
                //이미지 다운로드하여 이미지 SET(다운로드 이미지 리스트를 만들어 Download)
                string fileName = this.grdPHY2000.GetItemString(this.grdPHY2000.CurrentRowNumber, "image");
                if (fileName.Trim().Length > 0)
                {
                    string jundal_part = "REHA";
                    string filePath = Directory.GetParent(Application.StartupPath) + "\\" + "Images" + "\\" + jundal_part;
                    string createTime = grdPHY2000.GetItemString(grdPHY2000.CurrentRowNumber, "cr_time");
                    //createTime = EnvironInfo.GetSysDate().ToString();
                    string serverPath = grdPHY2000.GetItemString(grdPHY2000.CurrentRowNumber, "image_path");
                    if (ImageHelper.IsFileDownload(filePath + "\\" + fileName, DateTime.Parse(createTime)))
                    {
                        ArrayList fileList = new ArrayList();
                        fileList.Add(new ImageFileInfo(filePath, serverPath, fileName, fileName));
                        ImageHelper.DownloadImages(fileList, false);
                    }
                    if (ImageHelper.GetImage(filePath + "\\" + fileName) != null)
                        this.imageEditor.Image = ImageHelper.GetImage(filePath + "\\" + fileName);

                }
            }
        }

        private void grdIFS8003_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex = -1;
            XEditGrid grd = sender as XEditGrid;

            curRowIndex = grd.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void grd_MouseDown(object sender, MouseEventArgs e)
        {
            //XEditGrid grd = sender as XEditGrid;
            //int rowNumber = -1;
            //if (e.Button == MouseButtons.Left && e.Clicks == 1)
            //{
            //    rowNumber = grd.GetHitRowNumber(e.Y);
            //    if (grd.CurrentColName == "code_name")
            //    {
            //        if (grd.GetItemString(rowNumber, "select") == "Y")
            //        {
            //            grd.SetItemValue(rowNumber, "select", "N");
            //            //grd.AcceptData();   
            //        }
            //        else
            //        {
            //            grd.SetItemValue(rowNumber, "select", "Y");
            //            //grd.AcceptData();
            //        }
            //    }
            //}

        }

        private void grd_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

            XEditGrid grd = sender as XEditGrid;
            bool IsChecked = false;

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetItemString(i, "select") == "Y")
                {
                    switch (grd.Name)
                    {
                        case "grdPT":
                            this.cbxPT_FLAG.Checked = true;
                            IsChecked = true;
                            break;
                        case "grdOT":
                            this.cbxOT_FLAG.Checked = true;
                            IsChecked = true;
                            break;
                        case "grdST":
                            this.cbxST_FLAG.Checked = true;
                            IsChecked = true;
                            break;

                    }
                    break;
                }
            }
            if (IsChecked == false)
            {
                switch (grd.Name)
                {
                    case "grdPT":
                        this.cbxPT_FLAG.Checked = false;
                        break;
                    case "grdOT":
                        this.cbxOT_FLAG.Checked = false;
                        break;
                    case "grdST":
                        this.cbxST_FLAG.Checked = false;
                        break;
                }
            }
        }

        private void grd_MouseUp(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            switch (grd.Name)
            {
                case "grdPT":
                    this.cbxPT_FLAG.Focus();
                    break;
                case "grdOT":
                    this.cbxOT_FLAG.Focus();
                    break;
                case "grdST":
                    this.cbxST_FLAG.Focus();
                    break;
            }
        }

        private void cbx_FLAG_CheckedChanged(object sender, EventArgs e)
        {
            XCheckBox cbx = sender as XCheckBox;
            string str = cbx.Name;
            if (cbx.Checked == false)
            {
                switch (str)
                {
                    case "cbxPT_FLAG":
                        for (int i = 0; i < this.grdPT.RowCount; i++)
                        {
                            this.grdPT.SetItemValue(i, "select", "N");
                        }
                        break;
                    case "cbxOT_FLAG":
                        for (int i = 0; i < this.grdOT.RowCount; i++)
                        {
                            this.grdOT.SetItemValue(i, "select", "N");
                        }
                        break;
                    case "cbxST_FLAG":
                        for (int i = 0; i < this.grdPT.RowCount; i++)
                        {
                            this.grdST.SetItemValue(i, "select", "N");
                        }
                        break;
                }
            }
        }

        private void btnSindanmei_Click(object sender, EventArgs e)
        {
            mReturnControl = "S";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void btnGenbyoureki_Click(object sender, EventArgs e)
        {
            mReturnControl = "G";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
            this.txtGenbyoureki.Focus();
        }

        private void btnComplications_Click(object sender, EventArgs e)
        {
            mReturnControl = "C";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("multiSelect", true);
            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
            this.txtComplications.Focus();
        }

        private void btnKioureki_Click(object sender, EventArgs e)
        {
            mReturnControl = "K";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
            this.txtKioureki.Focus();
        }

        private void btnInfectious_Click(object sender, EventArgs e)
        {
            mReturnControl = "I";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("multiSelect", true);
            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
            this.txtInfectious.Focus();
        }
        
        private void btnStop_kijyun_Click(object sender, EventArgs e)
        {
            ShowReservedScreen("01");
            this.txtStop_kijyun.Focus();
        }

        private void btnTaboo_Click(object sender, EventArgs e)
        {
            ShowReservedScreen("01");
            this.txtTaboo.Focus();
        }

        private void btnFrequency_Click(object sender, EventArgs e)
        {
            ShowReservedScreen("01");
            this.txtFrequency.Focus();
        }
    }
}

