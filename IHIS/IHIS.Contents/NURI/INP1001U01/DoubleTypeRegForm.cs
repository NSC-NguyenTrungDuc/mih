using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using IHIS.Framework;
using IHIS.X;

namespace IHIS.NURI
{
	/// <summary>
	/// DoubleTypeRegForm에 대한 요약 설명입니다.
	/// </summary>
	public class DoubleTypeRegForm : IHIS.Framework.XForm
	{
		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel pnlBoheom;
		private IHIS.Framework.XButton btnRegOUT0102;
		private IHIS.Framework.XPanel xPanel8;
		private IHIS.Framework.XTabControl tabOUT0102;
		private IHIS.Framework.XEditGrid grdINP1002;
		private IHIS.Framework.XDictComboBox cboIpwonType;
		private IHIS.Framework.XLabel xLabel12;
		private IHIS.Framework.XCheckBox cbxLastCheck;
		private IHIS.Framework.XDatePicker dtpLastCheck;
		private IHIS.Framework.XLabel xLabel38;
		private IHIS.Framework.XLabel xLabel34;
        private IHIS.Framework.XDictComboBox cboHiAgeGubun;
		private IHIS.Framework.XDisplayBox dbxGaeinNo;
		private IHIS.Framework.XDisplayBox dbxGaein;
		private IHIS.Framework.XLabel xLabel43;
        private IHIS.Framework.XLabel xLabel13;
		private IHIS.Framework.XDisplayBox dbxGubun;
		private IHIS.Framework.XDisplayBox dbxJohap;
		private IHIS.Framework.XLabel xLabel15;
		private IHIS.Framework.XDisplayBox dbxGubunName;
		private IHIS.Framework.XLabel xLabel14;
		private IHIS.Framework.XDisplayBox dbxJohapName;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
		private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XEditGridCell xEditGridCell111;
		private IHIS.Framework.XEditGridCell xEditGridCell112;
		private IHIS.Framework.XEditGridCell xEditGridCell113;
		private IHIS.Framework.XEditGridCell xEditGridCell115;
		private IHIS.Framework.XEditGridCell xEditGridCell116;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell119;
		private IHIS.Framework.XEditGridCell xEditGridCell120;
		private IHIS.Framework.XEditGridCell xEditGridCell121;
		private IHIS.Framework.XEditGridCell xEditGridCell122;
		private IHIS.Framework.XEditGridCell xEditGridCell125;
        private IHIS.Framework.XEditGridCell xEditGridCell126;
        private IHIS.Framework.XEditGridCell xEditGridCell131;
		private IHIS.Framework.XEditGridCell xEditGridCell134;
		private IHIS.Framework.XEditGridCell xEditGridCell148;
        private IHIS.Framework.XEditGridCell xEditGridCell149;
		private IHIS.Framework.XEditGridCell xEditGridCell110;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XDisplayBox dbxIpwonDate;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XDatePicker dtpGubunIpwonDate;
		private System.Windows.Forms.ImageList ImageList;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XPanel xPanel7;
		private IHIS.Framework.XButton btnRegOUT0105;
		private IHIS.Framework.XEditGrid grdINP1008;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell189;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XDisplayBox dbxGwaName;
		private IHIS.Framework.XFindBox fbxGwa;
		private IHIS.Framework.XLabel xLabel25;
		private IHIS.Framework.XDisplayBox dbxDoctorName;
		private IHIS.Framework.XFindBox fbxDoctor;
		private IHIS.Framework.XLabel xLabel16;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.MultiLayout layINP1002Update;
        private IHIS.Framework.MultiLayout layINP1001Update;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem118;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem119;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem120;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem121;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem122;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem123;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem124;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem125;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem126;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem127;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem128;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem129;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem130;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem131;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem132;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem133;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem134;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem135;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem136;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem137;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem138;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem139;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem140;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem141;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem142;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem143;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem144;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem145;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem146;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem147;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem148;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem149;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem150;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem151;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem152;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem153;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem154;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem155;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem156;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem157;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem158;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem159;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem160;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem161;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem162;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem163;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem164;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem165;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem166;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem167;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem168;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem169;
        private XEditGridCell xEditGridCell21;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
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
        private MultiLayoutItem multiLayoutItem76;
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
        private MultiLayoutItem multiLayoutItem95;
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
        private MultiLayoutItem multiLayoutItem116;
        private MultiLayoutItem multiLayoutItem117;
		private System.ComponentModel.IContainer components;
		#endregion

		public DoubleTypeRegForm(string aPkinp1001, string aIpwonDate, string aBunho)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			this.mPkinp1001 = aPkinp1001 ;
			this.mIpwonDate = aIpwonDate ;
			this.mBunho     = aBunho     ;

			this.SaveLayoutList.Add(this.layINP1001Update);
			this.SaveLayoutList.Add(this.layINP1002Update);
			this.SaveLayoutList.Add(this.grdINP1008);
			this.layINP1001Update.SavePerformer = new XSavePerformer(this);
            this.layINP1002Update.SavePerformer = this.layINP1001Update.SavePerformer;
            this.grdINP1008.SavePerformer = this.layINP1001Update.SavePerformer;
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoubleTypeRegForm));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlBoheom = new IHIS.Framework.XPanel();
            this.grdINP1002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.dbxGubun = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.dtpGubunIpwonDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.fbxGwa = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.cboIpwonType = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.dbxJohap = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.dbxGaein = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.dbxGaeinNo = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.dtpLastCheck = new IHIS.Framework.XDatePicker();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.dbxGubunName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.dbxGwaName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.dbxDoctorName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.dbxIpwonDate = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.cbxLastCheck = new IHIS.Framework.XCheckBox();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnRegOUT0102 = new IHIS.Framework.XButton();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.tabOUT0102 = new IHIS.Framework.XTabControl();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel38 = new IHIS.Framework.XLabel();
            this.xLabel34 = new IHIS.Framework.XLabel();
            this.cboHiAgeGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel43 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.dbxJohapName = new IHIS.Framework.XDisplayBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.btnRegOUT0105 = new IHIS.Framework.XButton();
            this.grdINP1008 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell189 = new IHIS.Framework.XEditGridCell();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.layINP1002Update = new IHIS.Framework.MultiLayout();
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
            this.layINP1001Update = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem76 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem116 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem117 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlBoheom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1002)).BeginInit();
            this.xPanel8.SuspendLayout();
            this.xPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1008)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layINP1002Update)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layINP1001Update)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(941, 36);
            this.xPanel1.TabIndex = 1;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(941, 32);
            this.paBox.TabIndex = 0;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 216);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(941, 34);
            this.xPanel2.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Cancel, System.Windows.Forms.Shortcut.F3, "入院取消", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(609, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(332, 34);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlBoheom
            // 
            this.pnlBoheom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoheom.Controls.Add(this.grdINP1002);
            this.pnlBoheom.Controls.Add(this.dbxGwaName);
            this.pnlBoheom.Controls.Add(this.fbxGwa);
            this.pnlBoheom.Controls.Add(this.xLabel25);
            this.pnlBoheom.Controls.Add(this.dbxDoctorName);
            this.pnlBoheom.Controls.Add(this.fbxDoctor);
            this.pnlBoheom.Controls.Add(this.xLabel16);
            this.pnlBoheom.Controls.Add(this.dtpGubunIpwonDate);
            this.pnlBoheom.Controls.Add(this.xLabel1);
            this.pnlBoheom.Controls.Add(this.btnRegOUT0102);
            this.pnlBoheom.Controls.Add(this.xPanel8);
            this.pnlBoheom.Controls.Add(this.cboIpwonType);
            this.pnlBoheom.Controls.Add(this.xLabel12);
            this.pnlBoheom.Controls.Add(this.cbxLastCheck);
            this.pnlBoheom.Controls.Add(this.dtpLastCheck);
            this.pnlBoheom.Controls.Add(this.xLabel38);
            this.pnlBoheom.Controls.Add(this.xLabel34);
            this.pnlBoheom.Controls.Add(this.cboHiAgeGubun);
            this.pnlBoheom.Controls.Add(this.dbxGaeinNo);
            this.pnlBoheom.Controls.Add(this.dbxGaein);
            this.pnlBoheom.Controls.Add(this.xLabel43);
            this.pnlBoheom.Controls.Add(this.xLabel13);
            this.pnlBoheom.Controls.Add(this.dbxGubun);
            this.pnlBoheom.Controls.Add(this.dbxJohap);
            this.pnlBoheom.Controls.Add(this.xLabel15);
            this.pnlBoheom.Controls.Add(this.dbxGubunName);
            this.pnlBoheom.Controls.Add(this.xLabel14);
            this.pnlBoheom.Controls.Add(this.dbxJohapName);
            this.pnlBoheom.Controls.Add(this.xLabel5);
            this.pnlBoheom.Controls.Add(this.xLabel2);
            this.pnlBoheom.Controls.Add(this.dbxIpwonDate);
            this.pnlBoheom.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBoheom.Location = new System.Drawing.Point(0, 0);
            this.pnlBoheom.Name = "pnlBoheom";
            this.pnlBoheom.Size = new System.Drawing.Size(618, 180);
            this.pnlBoheom.TabIndex = 3;
            // 
            // grdINP1002
            // 
            this.grdINP1002.CallerID = '4';
            this.grdINP1002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell119,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell125,
            this.xEditGridCell126,
            this.xEditGridCell131,
            this.xEditGridCell134,
            this.xEditGridCell148,
            this.xEditGridCell149,
            this.xEditGridCell21,
            this.xEditGridCell110,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell1,
            this.xEditGridCell7,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell22,
            this.xEditGridCell4,
            this.xEditGridCell17});
            this.grdINP1002.ColPerLine = 35;
            this.grdINP1002.Cols = 35;
            this.grdINP1002.ControlBinding = true;
            this.grdINP1002.FixedRows = 1;
            this.grdINP1002.HeaderHeights.Add(25);
            this.grdINP1002.Location = new System.Drawing.Point(120, 30);
            this.grdINP1002.Name = "grdINP1002";
            this.grdINP1002.QuerySQL = resources.GetString("grdINP1002.QuerySQL");
            this.grdINP1002.ReadOnly = true;
            this.grdINP1002.Rows = 2;
            this.grdINP1002.Size = new System.Drawing.Size(60, 99);
            this.grdINP1002.TabIndex = 131;
            this.grdINP1002.UseDefaultTransaction = false;
            this.grdINP1002.Visible = false;
            this.grdINP1002.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdINP1002_RowFocusChanged);
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "pkinp1002";
            this.xEditGridCell106.HeaderText = "pkinp1002";
            this.xEditGridCell106.IsUpdatable = false;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "fkinp1001";
            this.xEditGridCell107.Col = 1;
            this.xEditGridCell107.HeaderText = "fkinp1001";
            this.xEditGridCell107.IsUpdatable = false;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "bunho";
            this.xEditGridCell108.Col = 2;
            this.xEditGridCell108.HeaderText = "bunho";
            this.xEditGridCell108.IsNotNull = true;
            this.xEditGridCell108.IsUpdatable = false;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.BindControl = this.dbxGubun;
            this.xEditGridCell109.CellName = "gubun";
            this.xEditGridCell109.Col = 3;
            this.xEditGridCell109.HeaderText = "gubun";
            this.xEditGridCell109.IsNotNull = true;
            this.xEditGridCell109.IsUpdatable = false;
            // 
            // dbxGubun
            // 
            this.dbxGubun.Location = new System.Drawing.Point(401, 76);
            this.dbxGubun.Name = "dbxGubun";
            this.dbxGubun.Size = new System.Drawing.Size(80, 20);
            this.dbxGubun.TabIndex = 100;
            this.dbxGubun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "seq";
            this.xEditGridCell111.Col = 4;
            this.xEditGridCell111.HeaderText = "seq";
            this.xEditGridCell111.IsUpdatable = false;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "gubun_trans_date";
            this.xEditGridCell112.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell112.Col = 5;
            this.xEditGridCell112.HeaderText = "gubun_trans_date";
            this.xEditGridCell112.IsUpdatable = false;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.BindControl = this.dtpGubunIpwonDate;
            this.xEditGridCell113.CellName = "gubun_ipwon_date";
            this.xEditGridCell113.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell113.Col = 6;
            this.xEditGridCell113.HeaderText = "gubun_ipwon_date";
            // 
            // dtpGubunIpwonDate
            // 
            this.dtpGubunIpwonDate.IsJapanYearType = true;
            this.dtpGubunIpwonDate.Location = new System.Drawing.Point(401, 28);
            this.dtpGubunIpwonDate.Name = "dtpGubunIpwonDate";
            this.dtpGubunIpwonDate.Size = new System.Drawing.Size(108, 20);
            this.dtpGubunIpwonDate.TabIndex = 132;
            this.dtpGubunIpwonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpGubunIpwonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpGubunIpwonDate_DataValidating);
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "gubun_trans_cnt";
            this.xEditGridCell115.Col = 7;
            this.xEditGridCell115.HeaderText = "gubun_trans_cnt";
            this.xEditGridCell115.IsUpdatable = false;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "gubun_trans_yn";
            this.xEditGridCell116.Col = 8;
            this.xEditGridCell116.HeaderText = "gubun_trans_yn";
            this.xEditGridCell116.InitValue = "N";
            this.xEditGridCell116.IsUpdatable = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.BindControl = this.fbxGwa;
            this.xEditGridCell10.CellName = "gwa";
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.HeaderText = "gwa";
            // 
            // fbxGwa
            // 
            this.fbxGwa.ApplyByteLimit = true;
            this.fbxGwa.AutoTabDataSelected = true;
            this.fbxGwa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxGwa.FindWorker = this.fwkCommon;
            this.fbxGwa.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.fbxGwa.Location = new System.Drawing.Point(120, 52);
            this.fbxGwa.MaxLength = 2;
            this.fbxGwa.Name = "fbxGwa";
            this.fbxGwa.Size = new System.Drawing.Size(90, 20);
            this.fbxGwa.TabIndex = 142;
            this.fbxGwa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.BindControl = this.fbxDoctor;
            this.xEditGridCell11.CellName = "doctor";
            this.xEditGridCell11.Col = 10;
            this.xEditGridCell11.HeaderText = "doctor";
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.ApplyByteLimit = true;
            this.fbxDoctor.AutoTabDataSelected = true;
            this.fbxDoctor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxDoctor.FindWorker = this.fwkCommon;
            this.fbxDoctor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.fbxDoctor.Location = new System.Drawing.Point(401, 52);
            this.fbxDoctor.MaxLength = 20;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.Size = new System.Drawing.Size(80, 20);
            this.fbxDoctor.TabIndex = 143;
            this.fbxDoctor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.cboIpwonType;
            this.xEditGridCell12.CellName = "ipwon_type";
            this.xEditGridCell12.Col = 11;
            this.xEditGridCell12.HeaderText = "ipwon_type";
            this.xEditGridCell12.IsUpdatable = false;
            // 
            // cboIpwonType
            // 
            this.cboIpwonType.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIpwonType.Location = new System.Drawing.Point(120, 124);
            this.cboIpwonType.Name = "cboIpwonType";
            this.cboIpwonType.Protect = true;
            this.cboIpwonType.Size = new System.Drawing.Size(136, 20);
            this.cboIpwonType.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboIpwonType.TabIndex = 128;
            this.cboIpwonType.TabStop = false;
            this.cboIpwonType.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'IPWON_TYPE\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.BindControl = this.dbxJohap;
            this.xEditGridCell119.CellName = "johap";
            this.xEditGridCell119.Col = 12;
            this.xEditGridCell119.HeaderText = "johap";
            this.xEditGridCell119.IsUpdatable = false;
            // 
            // dbxJohap
            // 
            this.dbxJohap.Location = new System.Drawing.Point(120, 76);
            this.dbxJohap.Name = "dbxJohap";
            this.dbxJohap.Size = new System.Drawing.Size(90, 20);
            this.dbxJohap.TabIndex = 99;
            this.dbxJohap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.BindControl = this.dbxGaein;
            this.xEditGridCell120.CellName = "gaein";
            this.xEditGridCell120.Col = 13;
            this.xEditGridCell120.HeaderText = "gaein";
            this.xEditGridCell120.IsUpdatable = false;
            // 
            // dbxGaein
            // 
            this.dbxGaein.Location = new System.Drawing.Point(120, 100);
            this.dbxGaein.Name = "dbxGaein";
            this.dbxGaein.Size = new System.Drawing.Size(136, 20);
            this.dbxGaein.TabIndex = 112;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "bonin_gubun";
            this.xEditGridCell121.Col = 14;
            this.xEditGridCell121.HeaderText = "bonin_gubun";
            this.xEditGridCell121.IsUpdatable = false;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellLen = 30;
            this.xEditGridCell122.CellName = "piname";
            this.xEditGridCell122.Col = 15;
            this.xEditGridCell122.HeaderText = "piname";
            this.xEditGridCell122.IsUpdatable = false;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "from_jy_date";
            this.xEditGridCell125.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell125.Col = 16;
            this.xEditGridCell125.HeaderText = "from_jy_date";
            this.xEditGridCell125.IsUpdatable = false;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "to_jy_date";
            this.xEditGridCell126.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell126.Col = 17;
            this.xEditGridCell126.HeaderText = "to_jy_date";
            this.xEditGridCell126.IsUpdatable = false;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "simsa_magam_yn";
            this.xEditGridCell131.Col = 18;
            this.xEditGridCell131.HeaderText = "simsa_magam_yn";
            this.xEditGridCell131.IsUpdatable = false;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "johap_gubun";
            this.xEditGridCell134.Col = 19;
            this.xEditGridCell134.HeaderText = "johap_gubun";
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsUpdCol = false;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.BindControl = this.dbxGaeinNo;
            this.xEditGridCell148.CellLen = 30;
            this.xEditGridCell148.CellName = "gaein_no";
            this.xEditGridCell148.Col = 20;
            this.xEditGridCell148.HeaderText = "gaein_no";
            this.xEditGridCell148.IsUpdatable = false;
            // 
            // dbxGaeinNo
            // 
            this.dbxGaeinNo.Location = new System.Drawing.Point(401, 100);
            this.dbxGaeinNo.Name = "dbxGaeinNo";
            this.dbxGaeinNo.Size = new System.Drawing.Size(128, 20);
            this.dbxGaeinNo.TabIndex = 113;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.BindControl = this.dtpLastCheck;
            this.xEditGridCell149.CellName = "last_check_date";
            this.xEditGridCell149.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell149.Col = 21;
            this.xEditGridCell149.HeaderText = "last_check_date";
            this.xEditGridCell149.IsUpdatable = false;
            // 
            // dtpLastCheck
            // 
            this.dtpLastCheck.IsJapanYearType = true;
            this.dtpLastCheck.Location = new System.Drawing.Point(120, 148);
            this.dtpLastCheck.Name = "dtpLastCheck";
            this.dtpLastCheck.Protect = true;
            this.dtpLastCheck.ReadOnly = true;
            this.dtpLastCheck.Size = new System.Drawing.Size(108, 20);
            this.dtpLastCheck.TabIndex = 124;
            this.dtpLastCheck.TabStop = false;
            this.dtpLastCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "johap_name";
            this.xEditGridCell21.Col = 22;
            this.xEditGridCell21.HeaderText = "johap_name";
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.BindControl = this.dbxGubunName;
            this.xEditGridCell110.CellName = "gubun_name";
            this.xEditGridCell110.Col = 23;
            this.xEditGridCell110.HeaderText = "gubun_name";
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.IsUpdCol = false;
            // 
            // dbxGubunName
            // 
            this.dbxGubunName.Location = new System.Drawing.Point(482, 76);
            this.dbxGubunName.Name = "dbxGubunName";
            this.dbxGubunName.Size = new System.Drawing.Size(128, 20);
            this.dbxGubunName.TabIndex = 98;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.BindControl = this.dbxGwaName;
            this.xEditGridCell13.CellName = "gwa_name";
            this.xEditGridCell13.CellWidth = 75;
            this.xEditGridCell13.Col = 24;
            this.xEditGridCell13.HeaderText = "gwa_name";
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsUpdCol = false;
            // 
            // dbxGwaName
            // 
            this.dbxGwaName.Location = new System.Drawing.Point(210, 52);
            this.dbxGwaName.Name = "dbxGwaName";
            this.dbxGwaName.Size = new System.Drawing.Size(107, 21);
            this.dbxGwaName.TabIndex = 147;
            this.dbxGwaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.BindControl = this.dbxDoctorName;
            this.xEditGridCell14.CellName = "doctor_name";
            this.xEditGridCell14.Col = 25;
            this.xEditGridCell14.HeaderText = "doctor_name";
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // dbxDoctorName
            // 
            this.dbxDoctorName.Location = new System.Drawing.Point(482, 52);
            this.dbxDoctorName.Name = "dbxDoctorName";
            this.dbxDoctorName.Size = new System.Drawing.Size(128, 21);
            this.dbxDoctorName.TabIndex = 145;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "ipwon_type_name";
            this.xEditGridCell15.Col = 26;
            this.xEditGridCell15.HeaderText = "ipwon_type_name";
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsUpdCol = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.BindControl = this.dbxIpwonDate;
            this.xEditGridCell1.CellName = "ipwon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 27;
            this.xEditGridCell1.HeaderText = "ipwon_date";
            this.xEditGridCell1.IsUpdCol = false;
            // 
            // dbxIpwonDate
            // 
            this.dbxIpwonDate.EditMaskType = IHIS.Framework.MaskType.Date;
            this.dbxIpwonDate.IsJapanYearType = true;
            this.dbxIpwonDate.Location = new System.Drawing.Point(120, 28);
            this.dbxIpwonDate.Name = "dbxIpwonDate";
            this.dbxIpwonDate.Size = new System.Drawing.Size(110, 20);
            this.dbxIpwonDate.TabIndex = 135;
            this.dbxIpwonDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "data_gubun";
            this.xEditGridCell7.Col = 28;
            this.xEditGridCell7.HeaderText = "data_gubun";
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "org_ho_dong1";
            this.xEditGridCell18.Col = 29;
            this.xEditGridCell18.HeaderText = "org_ho_dong1";
            this.xEditGridCell18.IsUpdCol = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "org_ho_code1";
            this.xEditGridCell19.Col = 30;
            this.xEditGridCell19.HeaderText = "org_ho_code1";
            this.xEditGridCell19.IsUpdCol = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "org_ho_grade1";
            this.xEditGridCell20.Col = 31;
            this.xEditGridCell20.HeaderText = "org_ho_grade1";
            this.xEditGridCell20.IsUpdCol = false;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "org_bed_no";
            this.xEditGridCell22.Col = 32;
            this.xEditGridCell22.HeaderText = "org_bed_no";
            this.xEditGridCell22.IsUpdCol = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.cbxLastCheck;
            this.xEditGridCell4.CellName = "last_check";
            this.xEditGridCell4.Col = 33;
            this.xEditGridCell4.HeaderText = "last_check";
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // cbxLastCheck
            // 
            this.cbxLastCheck.Location = new System.Drawing.Point(230, 146);
            this.cbxLastCheck.Name = "cbxLastCheck";
            this.cbxLastCheck.Size = new System.Drawing.Size(16, 24);
            this.cbxLastCheck.TabIndex = 125;
            this.cbxLastCheck.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "iud_gubun";
            this.xEditGridCell17.Col = 34;
            this.xEditGridCell17.HeaderText = "iud_gubun";
            // 
            // xLabel25
            // 
            this.xLabel25.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel25.EdgeRounding = false;
            this.xLabel25.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel25.Location = new System.Drawing.Point(40, 52);
            this.xLabel25.Name = "xLabel25";
            this.xLabel25.Size = new System.Drawing.Size(78, 20);
            this.xLabel25.TabIndex = 146;
            this.xLabel25.Text = "診 療 科";
            this.xLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel16
            // 
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel16.Location = new System.Drawing.Point(321, 52);
            this.xLabel16.Name = "xLabel16";
            this.xLabel16.Size = new System.Drawing.Size(78, 20);
            this.xLabel16.TabIndex = 144;
            this.xLabel16.Text = "主 治 医";
            this.xLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(321, 28);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(78, 20);
            this.xLabel1.TabIndex = 133;
            this.xLabel1.Text = "開始日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegOUT0102
            // 
            this.btnRegOUT0102.Image = ((System.Drawing.Image)(resources.GetObject("btnRegOUT0102.Image")));
            this.btnRegOUT0102.Location = new System.Drawing.Point(8, 151);
            this.btnRegOUT0102.Name = "btnRegOUT0102";
            this.btnRegOUT0102.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRegOUT0102.Size = new System.Drawing.Size(24, 24);
            this.btnRegOUT0102.TabIndex = 3;
            this.btnRegOUT0102.Click += new System.EventHandler(this.btnRegOUT0102_Click);
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.tabOUT0102);
            this.xPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel8.Location = new System.Drawing.Point(38, 0);
            this.xPanel8.Name = "xPanel8";
            this.xPanel8.Size = new System.Drawing.Size(578, 24);
            this.xPanel8.TabIndex = 130;
            // 
            // tabOUT0102
            // 
            this.tabOUT0102.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOUT0102.IDEPixelArea = true;
            this.tabOUT0102.IDEPixelBorder = false;
            this.tabOUT0102.Location = new System.Drawing.Point(0, 0);
            this.tabOUT0102.Name = "tabOUT0102";
            this.tabOUT0102.Size = new System.Drawing.Size(578, 24);
            this.tabOUT0102.TabIndex = 92;
            this.tabOUT0102.SelectionChanged += new System.EventHandler(this.tabOUT0102_SelectionChanged);
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel12.Location = new System.Drawing.Point(40, 124);
            this.xLabel12.Name = "xLabel12";
            this.xLabel12.Size = new System.Drawing.Size(78, 20);
            this.xLabel12.TabIndex = 127;
            this.xLabel12.Text = "入院タイプ";
            this.xLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel38
            // 
            this.xLabel38.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel38.EdgeRounding = false;
            this.xLabel38.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel38.Location = new System.Drawing.Point(40, 148);
            this.xLabel38.Name = "xLabel38";
            this.xLabel38.Size = new System.Drawing.Size(78, 20);
            this.xLabel38.TabIndex = 126;
            this.xLabel38.Text = "最終確認日";
            this.xLabel38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel34
            // 
            this.xLabel34.EdgeRounding = false;
            this.xLabel34.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel34.Location = new System.Drawing.Point(321, 148);
            this.xLabel34.Name = "xLabel34";
            this.xLabel34.Size = new System.Drawing.Size(78, 20);
            this.xLabel34.TabIndex = 123;
            this.xLabel34.Text = "高齢者区分";
            this.xLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel34.Visible = false;
            // 
            // cboHiAgeGubun
            // 
            this.cboHiAgeGubun.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHiAgeGubun.Location = new System.Drawing.Point(401, 148);
            this.cboHiAgeGubun.Name = "cboHiAgeGubun";
            this.cboHiAgeGubun.Protect = true;
            this.cboHiAgeGubun.Size = new System.Drawing.Size(136, 20);
            this.cboHiAgeGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHiAgeGubun.TabIndex = 122;
            this.cboHiAgeGubun.TabStop = false;
            this.cboHiAgeGubun.UserSQL = "SELECT A.CODE, A.CODE_NAME\r\nFROM BAS0102 A\r\nWHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE AND A.CODE_TYPE = \'HI_AGE_GUBUN\'";
            this.cboHiAgeGubun.Visible = false;
            // 
            // xLabel43
            // 
            this.xLabel43.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel43.EdgeRounding = false;
            this.xLabel43.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel43.Location = new System.Drawing.Point(321, 100);
            this.xLabel43.Name = "xLabel43";
            this.xLabel43.Size = new System.Drawing.Size(78, 20);
            this.xLabel43.TabIndex = 111;
            this.xLabel43.Text = "番 号";
            this.xLabel43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel13
            // 
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel13.Location = new System.Drawing.Point(40, 100);
            this.xLabel13.Name = "xLabel13";
            this.xLabel13.Size = new System.Drawing.Size(78, 20);
            this.xLabel13.TabIndex = 110;
            this.xLabel13.Text = "記     号";
            this.xLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel15
            // 
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel15.Location = new System.Drawing.Point(321, 76);
            this.xLabel15.Name = "xLabel15";
            this.xLabel15.Size = new System.Drawing.Size(78, 20);
            this.xLabel15.TabIndex = 97;
            this.xLabel15.Text = "保険種別";
            this.xLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel14
            // 
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel14.Location = new System.Drawing.Point(40, 76);
            this.xLabel14.Name = "xLabel14";
            this.xLabel14.Size = new System.Drawing.Size(78, 20);
            this.xLabel14.TabIndex = 94;
            this.xLabel14.Text = "保険者番号";
            this.xLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxJohapName
            // 
            this.dbxJohapName.Location = new System.Drawing.Point(210, 76);
            this.dbxJohapName.Name = "dbxJohapName";
            this.dbxJohapName.Size = new System.Drawing.Size(107, 20);
            this.dbxJohapName.TabIndex = 95;
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel5.Image = ((System.Drawing.Image)(resources.GetObject("xLabel5.Image")));
            this.xLabel5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xLabel5.ImageIndex = 2;
            this.xLabel5.ImageList = this.ImageList;
            this.xLabel5.Location = new System.Drawing.Point(0, 0);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(38, 178);
            this.xLabel5.TabIndex = 1;
            this.xLabel5.Text = "保\n険\n情\n報";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(40, 28);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(78, 20);
            this.xLabel2.TabIndex = 134;
            this.xLabel2.Text = "入院日付";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel7
            // 
            this.xPanel7.Controls.Add(this.btnRegOUT0105);
            this.xPanel7.Controls.Add(this.grdINP1008);
            this.xPanel7.Controls.Add(this.xLabel7);
            this.xPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel7.Location = new System.Drawing.Point(618, 0);
            this.xPanel7.Name = "xPanel7";
            this.xPanel7.Size = new System.Drawing.Size(323, 180);
            this.xPanel7.TabIndex = 4;
            // 
            // btnRegOUT0105
            // 
            this.btnRegOUT0105.Image = ((System.Drawing.Image)(resources.GetObject("btnRegOUT0105.Image")));
            this.btnRegOUT0105.Location = new System.Drawing.Point(8, 152);
            this.btnRegOUT0105.Name = "btnRegOUT0105";
            this.btnRegOUT0105.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRegOUT0105.Size = new System.Drawing.Size(24, 24);
            this.btnRegOUT0105.TabIndex = 6;
            this.btnRegOUT0105.Click += new System.EventHandler(this.btnRegOUT0105_Click);
            // 
            // grdINP1008
            // 
            this.grdINP1008.CallerID = '3';
            this.grdINP1008.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell16,
            this.xEditGridCell189});
            this.grdINP1008.ColPerLine = 3;
            this.grdINP1008.Cols = 3;
            this.grdINP1008.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1008.FixedRows = 1;
            this.grdINP1008.HeaderHeights.Add(28);
            this.grdINP1008.Location = new System.Drawing.Point(38, 0);
            this.grdINP1008.Name = "grdINP1008";
            this.grdINP1008.QuerySQL = resources.GetString("grdINP1008.QuerySQL");
            this.grdINP1008.Rows = 2;
            this.grdINP1008.Size = new System.Drawing.Size(285, 180);
            this.grdINP1008.TabIndex = 5;
            this.grdINP1008.ToolTipActive = true;
            this.grdINP1008.UseDefaultTransaction = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "check_yn";
            this.xEditGridCell2.CellWidth = 31;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "選択";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "gongbi_code";
            this.xEditGridCell3.CellWidth = 50;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "公費";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gongbi_name";
            this.xEditGridCell5.CellWidth = 195;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderText = "公費名";
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "fkinp1002";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "bunho";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gubun";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "gubun_name";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell189
            // 
            this.xEditGridCell189.CellName = "master_gwanri_yn";
            this.xEditGridCell189.Col = -1;
            this.xEditGridCell189.IsUpdCol = false;
            this.xEditGridCell189.IsVisible = false;
            this.xEditGridCell189.Row = -1;
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.xLabel7.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel7.Image = ((System.Drawing.Image)(resources.GetObject("xLabel7.Image")));
            this.xLabel7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xLabel7.ImageIndex = 2;
            this.xLabel7.ImageList = this.ImageList;
            this.xLabel7.Location = new System.Drawing.Point(0, 0);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(38, 180);
            this.xLabel7.TabIndex = 4;
            this.xLabel7.Text = "公\n費\n情\n報";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xPanel7);
            this.xPanel3.Controls.Add(this.pnlBoheom);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(0, 36);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(941, 180);
            this.xPanel3.TabIndex = 5;
            // 
            // layINP1002Update
            // 
            this.layINP1002Update.CallerID = '2';
            this.layINP1002Update.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem169});
            this.layINP1002Update.UseDefaultTransaction = false;
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "pkinp1002";
            this.multiLayoutItem118.IsUpdItem = true;
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "fkinp1001";
            this.multiLayoutItem119.IsUpdItem = true;
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "bunho";
            this.multiLayoutItem120.IsUpdItem = true;
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "gubun";
            this.multiLayoutItem121.IsUpdItem = true;
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "seq";
            this.multiLayoutItem122.IsUpdItem = true;
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "gubun_trans_date";
            this.multiLayoutItem123.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem123.IsUpdItem = true;
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "gubun_ipwon_date";
            this.multiLayoutItem124.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem124.IsUpdItem = true;
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "gubun_trans_cnt";
            this.multiLayoutItem125.IsUpdItem = true;
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "gubun_trans_yn";
            this.multiLayoutItem126.IsUpdItem = true;
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "gwa";
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "doctor";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "ipwon_type";
            this.multiLayoutItem129.IsUpdItem = true;
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "hunab_gubun";
            this.multiLayoutItem130.IsUpdItem = true;
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "dis_gubun";
            this.multiLayoutItem131.IsUpdItem = true;
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "johap";
            this.multiLayoutItem132.IsUpdItem = true;
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "gaein";
            this.multiLayoutItem133.IsUpdItem = true;
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "bonin_gubun";
            this.multiLayoutItem134.IsUpdItem = true;
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "piname";
            this.multiLayoutItem135.IsUpdItem = true;
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "from_jy_date";
            this.multiLayoutItem136.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem136.IsUpdItem = true;
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "to_jy_date";
            this.multiLayoutItem137.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem137.IsUpdItem = true;
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "slip_magam_yn";
            this.multiLayoutItem138.IsUpdItem = true;
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "simsa_magam_yn";
            this.multiLayoutItem139.IsUpdItem = true;
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "toiwon_gubun_yn";
            this.multiLayoutItem140.IsUpdItem = true;
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "johap_gubun";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "gaein_no";
            this.multiLayoutItem142.IsUpdItem = true;
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "last_check_date";
            this.multiLayoutItem143.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem143.IsUpdItem = true;
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "relation_code";
            this.multiLayoutItem144.IsUpdItem = true;
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "sunwon_gubun";
            this.multiLayoutItem145.IsUpdItem = true;
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "hasun_date";
            this.multiLayoutItem146.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem146.IsUpdItem = true;
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "sunwon_end_date";
            this.multiLayoutItem147.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem147.IsUpdItem = true;
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "hi_age_gubun";
            this.multiLayoutItem148.IsUpdItem = true;
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "budamja_bunho";
            this.multiLayoutItem149.IsUpdItem = true;
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "sugubja_bunho";
            this.multiLayoutItem150.IsUpdItem = true;
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "siksa_bon_gubun";
            this.multiLayoutItem151.IsUpdItem = true;
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "self_hando_gubun";
            this.multiLayoutItem152.IsUpdItem = true;
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "johap_name";
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "hunab_gubun_name";
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "dis_gubun_name";
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "gubun_name";
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "gwa_name";
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "doctor_name";
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "ipwon_type_name";
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "data_gubun";
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "ipwon_date";
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "org_ho_dong1";
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "org_ho_code1";
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "org_ho_grade1";
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "org_ho_status1";
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "org_bed_no";
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "last_check";
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "patient_gubun";
            this.multiLayoutItem168.IsUpdItem = true;
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "iud_gubun";
            this.multiLayoutItem169.IsUpdItem = true;
            // 
            // layINP1001Update
            // 
            this.layINP1001Update.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
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
            this.multiLayoutItem75,
            this.multiLayoutItem76,
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
            this.multiLayoutItem94,
            this.multiLayoutItem95,
            this.multiLayoutItem96,
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
            this.multiLayoutItem115,
            this.multiLayoutItem116,
            this.multiLayoutItem117});
            this.layINP1001Update.UseDefaultTransaction = false;
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "pkinp1001";
            this.multiLayoutItem53.IsUpdItem = true;
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "bunho";
            this.multiLayoutItem54.IsUpdItem = true;
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "ipwon_date";
            this.multiLayoutItem55.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem55.IsUpdItem = true;
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "sil_ipwon_date";
            this.multiLayoutItem56.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem56.IsUpdItem = true;
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "ipwon_type";
            this.multiLayoutItem57.IsUpdItem = true;
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "ipwon_time";
            this.multiLayoutItem58.IsUpdItem = true;
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "cht_ipwon_date";
            this.multiLayoutItem59.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem59.IsUpdItem = true;
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "suname";
            this.multiLayoutItem60.IsUpdItem = true;
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "birth";
            this.multiLayoutItem61.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem61.IsUpdItem = true;
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "sex";
            this.multiLayoutItem62.IsUpdItem = true;
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "ipwon_gwa";
            this.multiLayoutItem63.IsUpdItem = true;
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "gwa";
            this.multiLayoutItem64.IsUpdItem = true;
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "doctor";
            this.multiLayoutItem65.IsUpdItem = true;
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "resident";
            this.multiLayoutItem66.IsUpdItem = true;
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "ho_code1";
            this.multiLayoutItem67.IsUpdItem = true;
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "ho_dong1";
            this.multiLayoutItem68.IsUpdItem = true;
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "ho_grade1";
            this.multiLayoutItem69.IsUpdItem = true;
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "ho_status1";
            this.multiLayoutItem70.IsUpdItem = true;
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "ho_code2";
            this.multiLayoutItem71.IsUpdItem = true;
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "ho_dong2";
            this.multiLayoutItem72.IsUpdItem = true;
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "ho_grade2";
            this.multiLayoutItem73.IsUpdItem = true;
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "ho_status2";
            this.multiLayoutItem74.IsUpdItem = true;
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "ipwon_rtn1";
            this.multiLayoutItem75.IsUpdItem = true;
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "ipwon_rtn2";
            this.multiLayoutItem76.IsUpdItem = true;
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "chojae";
            this.multiLayoutItem77.IsUpdItem = true;
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "baby_status";
            this.multiLayoutItem78.IsUpdItem = true;
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "sanmo_bunho";
            this.multiLayoutItem79.IsUpdItem = true;
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "inp_trans_yn";
            this.multiLayoutItem80.IsUpdItem = true;
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "fkout1001";
            this.multiLayoutItem81.IsUpdItem = true;
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "special_yn";
            this.multiLayoutItem82.IsUpdItem = true;
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "jaewon_flag";
            this.multiLayoutItem83.IsUpdItem = true;
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "old_ilsu";
            this.multiLayoutItem84.IsUpdItem = true;
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "icu_old_ilsu";
            this.multiLayoutItem85.IsUpdItem = true;
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "junggan_bil_cnt";
            this.multiLayoutItem86.IsUpdItem = true;
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "toiwon_goji_yn";
            this.multiLayoutItem87.IsUpdItem = true;
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "toiwon_res_date";
            this.multiLayoutItem88.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem88.IsUpdItem = true;
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "ga_toiwon_date";
            this.multiLayoutItem89.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem89.IsUpdItem = true;
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "toiwon_date";
            this.multiLayoutItem90.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem90.IsUpdItem = true;
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "toiwon_time";
            this.multiLayoutItem91.IsUpdItem = true;
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "cht_toiwon_date";
            this.multiLayoutItem92.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem92.IsUpdItem = true;
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "result";
            this.multiLayoutItem93.IsUpdItem = true;
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "sigi_magam_yn";
            this.multiLayoutItem94.IsUpdItem = true;
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "simsa_magam_gubun";
            this.multiLayoutItem95.IsUpdItem = true;
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "cancel_date";
            this.multiLayoutItem96.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem96.IsUpdItem = true;
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "cancel_user";
            this.multiLayoutItem97.IsUpdItem = true;
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "cancel_yn";
            this.multiLayoutItem98.IsUpdItem = true;
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "toiwon_drg_ilsu";
            this.multiLayoutItem99.IsUpdItem = true;
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "fkinp1003";
            this.multiLayoutItem100.IsUpdItem = true;
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "toiwon_gubun_yn";
            this.multiLayoutItem101.IsUpdItem = true;
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "er_wait_yn";
            this.multiLayoutItem102.IsUpdItem = true;
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "ipwon_gasan_yn";
            this.multiLayoutItem103.IsUpdItem = true;
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "toiwon_gasan_yn";
            this.multiLayoutItem104.IsUpdItem = true;
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "team";
            this.multiLayoutItem105.IsUpdItem = true;
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "wonyoi_order_yn";
            this.multiLayoutItem106.IsUpdItem = true;
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "wonnae_sayu_code";
            this.multiLayoutItem107.IsUpdItem = true;
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "gwanri_patient_yn";
            this.multiLayoutItem108.IsUpdItem = true;
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "sabun";
            this.multiLayoutItem109.IsUpdItem = true;
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "incu_yn";
            this.multiLayoutItem110.IsUpdItem = true;
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "zip_code1";
            this.multiLayoutItem111.IsUpdItem = true;
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "zip_code2";
            this.multiLayoutItem112.IsUpdItem = true;
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "gisan_ipwon_date";
            this.multiLayoutItem113.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem113.IsUpdItem = true;
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "bed_no";
            this.multiLayoutItem114.IsUpdItem = true;
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "source_pkinp1001";
            this.multiLayoutItem115.IsUpdItem = true;
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "gisan_jaewon_ilsu";
            this.multiLayoutItem116.IsUpdItem = true;
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "jisi_doctor";
            this.multiLayoutItem117.IsUpdItem = true;
            // 
            // DoubleTypeRegForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(941, 272);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "DoubleTypeRegForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "複数保険登録";
            this.Load += new System.EventHandler(this.DoubleTypeRegForm_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.Controls.SetChildIndex(this.xPanel3, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlBoheom.ResumeLayout(false);
            this.pnlBoheom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1002)).EndInit();
            this.xPanel8.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1008)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layINP1002Update)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layINP1001Update)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수

		private string mPkinp1001 = "";
		private string mIpwonDate = "";
		private string mBunho     = "";
		private string sPkinp1001 = "";

		//private INP.GubunDetail mGubunDetail = new IHIS.INP.GubunDetail();

		//private WON.LoadData.LoadBoheomInfo ldBoheomInfo = new IHIS.WON.LoadData.LoadBoheomInfo();

		private string mMsg = "";
		private string mCap = "";
        
        string mPKINP1002 = "";
		#endregion

		#region 다른 스크린 오픈 

		/// <summary>
		/// 환자별 공비정보 등록창 Open
		/// </summary>
		private void OpenScreen_OUT0105U00()
		{
			if (this.grdINP1002.RowCount > 0)
			{
				CommonItemCollection param = new CommonItemCollection();

				param.Add("bunho", this.paBox.BunHo);

                XScreen.OpenScreenWithParam(this, "NURO", "OUT0101U02", ScreenOpenStyle.ResponseFixed, param);
			}
		}

		/// <summary>
		/// 환자 보험 등록 
		/// </summary>
		private void OpenScreen_OUT0102U00 ()
		{
			if (this.grdINP1002.RowCount > 0)
			{
				CommonItemCollection param = new CommonItemCollection();

				param.Add("bunho", this.paBox.BunHo);

				XScreen.OpenScreenWithParam(this, "NURO", "OUT0101U02", ScreenOpenStyle.ResponseFixed,  ScreenAlignment.ScreenMiddleCenter, param);
			}
		}


		#endregion

		#region Screen Load

		private void DoubleTypeRegForm_Load(object sender, System.EventArgs e)
		{
			this.InitForm();

			this.LoadData();
		}

		#endregion

		#region Function

		#region InitForm

		private void InitForm ()
		{
			// 개시일자를 우선은 입원일자로 셋팅
			this.dtpGubunIpwonDate.SetEditValue(this.mIpwonDate);
			this.dtpGubunIpwonDate.AcceptData();

			// 환자번호
			this.paBox.SetPatientID(this.mBunho);
			this.paBox.IsEditableBunho = false;
		}

		#endregion

		#region ClearBoheomTab

		private void ClearBoheomTab()
		{
			try
			{
				this.tabOUT0102.TabPages.Clear();
			}
			catch
			{
				this.tabOUT0102.Refresh();
			}
		}

		#endregion

		#region MakeBoheomTab

		private void MakeBoheomTab ()
		{
			X.Magic.Controls.TabPage tpgNode ;
			string title = "";

			this.tabOUT0102.SelectionChanged -= new EventHandler(tabOUT0102_SelectionChanged);

			this.ClearBoheomTab();

			for(int i=0; i<this.grdINP1002.RowCount; i++)
			{
				if (this.grdINP1002.GetItemString(i, "data_gubun") == "O")
				{
					title = this.grdINP1002.GetItemString(i, "gubun_name");
				}
				else
				{
					title = this.grdINP1002.GetItemString(i, "ipwon_type_name") + " [" +
						this.grdINP1002.GetItemString(i, "gubun_name") + "]";
				}

				tpgNode = new IHIS.X.Magic.Controls.TabPage(title);
				tpgNode.ImageList = this.ImageList;
				tpgNode.ImageIndex = 1;

				tpgNode.Tag = i.ToString();

				this.tabOUT0102.TabPages.Add(tpgNode);
			}

			if (this.grdINP1002.RowCount > 0)
			{
				this.tabOUT0102.SelectedIndex = 0;
				this.tabOUT0102_SelectionChanged(this.tabOUT0102, new System.EventArgs());
			}

			this.tabOUT0102.SelectionChanged += new EventHandler(tabOUT0102_SelectionChanged);
		}

		#endregion

		#region 보험정보 컨트롤 프로텍트

		private void ProtectBoheomInfo ()
		{
			if (this.grdINP1002.RowCount <= 0)
			{
				foreach (Control control in this.pnlBoheom.Controls)
				{
					if (control is IDataControl )
					{
						((IDataControl)control).Protect = true;
					}
				}
			}

			if (this.grdINP1002.RowCount > 0 &&
				this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "data_gubun") == "O")
			{
				foreach(XEditGridCell cell in this.grdINP1002.CellInfos)
				{
					if (cell.BindControl != null )
					{
						if (cell.IsUpdatable == false)
						{
							((IDataControl)cell.BindControl).Protect = true;
						}
						else
						{
							((IDataControl)cell.BindControl).Protect = false;
						}
					}
				}
			}
			else
			{
				// 저장 완료후에는 식사 구분과, 자기한도 구분은 풀어주자
				foreach (Control control in this.pnlBoheom.Controls)
				{
					if (control is IDataControl &&
						control.Name != "cboSelfHandoGubun" &&
						control.Name != "cboSiksaBonGubun" &&
						control.Name != "cboPatientGubun"    )
					{
						((IDataControl)control).Protect = true;
					}
				}
			}
		}

		#endregion

		#region 보험코드 체크 
        string mGongbiYN = "";
		private void CheckBoheomInfo (int rowNum)
		{
            this.mGongbiYN = IHIS.NURI.Methodes.ChkGetGongbiYN(grdINP1002.GetItemString(rowNum, "gubun"),this.mIpwonDate);
            if (this.mGongbiYN == "N")
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "현재 보험종류는 공비를 적용하지 않습니다." : "現在の保険は公費を適用できません。";
                this.mCap = NetInfo.Language == LangMode.Ko ? "보험선택" : "保険選択";

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
			
		}

		#endregion

		#region 보험정보 그리드 데이터 변경

		private void SetDataToBoheomGrid(string aColName, string aData)
		{
			for (int i=0; i<this.grdINP1002.RowCount; i++)
			{
				if (this.grdINP1002.GetItemString(i, "data_gubun") == "O")
				{
					this.grdINP1002.SetItemValue(i, aColName, aData);
				}
			}
		}

		#endregion

		#endregion

		#region Load Data

		#region 보험정보 조회

		private void LoadData ()
        {
            string cmdText = @"SELECT 'Y'           EXIST_DOUBLE_TYPE
                                     , A.PKINP1001  PKINP1001
                                  FROM INP1001 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.BUNHO     = :f_bunho
                                   AND A.JAEWON_FLAG = 'Y'
                                   AND NVL(A.CANCEL_YN, 'N') = 'N'
                                   AND A.IPWON_TYPE = '2'/* 복수보험 */";

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_bunho", this.mBunho);

            DataTable dt = Service.ExecuteDataTable(cmdText, bc);

            string t_exist_double_type = "";
            string t_double_pkinp1001 = "";

            if (!TypeCheck.IsNull(dt))
            {
                t_exist_double_type = dt.Rows[0]["exist_double_type"].ToString();
                t_double_pkinp1001 = dt.Rows[0]["pkinp1001"].ToString();
            }

            this.grdINP1002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdINP1002.SetBindVarValue("f_bunho", this.mBunho);
            this.grdINP1002.SetBindVarValue("f_gubun_ipwon_date", this.dtpGubunIpwonDate.GetDataValue());
            this.grdINP1002.SetBindVarValue("t_exist_double_type", t_exist_double_type);
            this.grdINP1002.SetBindVarValue("t_double_pkinp1001", t_double_pkinp1001);

			this.grdINP1002.RowFocusChanged -=new RowFocusChangedEventHandler(grdINP1002_RowFocusChanged);

			if(!this.grdINP1002.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdINP1002 Query Error");
				return;
			}

			this.grdINP1002.RowFocusChanged +=new RowFocusChangedEventHandler(grdINP1002_RowFocusChanged);

			this.MakeBoheomTab();

			if (this.grdINP1002.RowCount > 0)
			{
				this.grdINP1002_RowFocusChanged(this.grdINP1002, new RowFocusChangedEventArgs(-1, this.grdINP1002.CurrentRowNumber));
			}
		}

		#endregion

		#region 공비정보 조회

		private void LoadGongbiQuery()
        {
            this.grdINP1008.SetBindVarValue("f_hosp_code"       , EnvironInfo.HospCode);
			this.grdINP1008.SetBindVarValue("f_bunho"           , this.paBox.BunHo);
			this.grdINP1008.SetBindVarValue("f_fkinp1002"       , this.grdINP1002.GetItemString(this.grdINP1002.CurrentRowNumber, "pkinp1002"));
			this.grdINP1008.SetBindVarValue("f_gubun_ipwon_date", this.grdINP1002.GetItemString(this.grdINP1002.CurrentRowNumber, "gubun_ipwon_date"));
			this.grdINP1008.SetBindVarValue("f_gubun"           , this.grdINP1002.GetItemString(this.grdINP1002.CurrentRowNumber, "gubun"));
			this.grdINP1008.SetBindVarValue("f_ipwon_date"      , this.mIpwonDate);

			if(!this.grdINP1008.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdINP1008 Query Error");
				return;
			}
		}

		#endregion

		#endregion

		#region Update 관련

		private void MakeUpdateInpwonInfo ()
		{
			this.layINP1001Update.Reset();

			if (this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "data_gubun") == "O")
			{
				this.layINP1001Update.InsertRow(-1);

				// 환자번호, 입원일자, 기산일자, 입원시간
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "bunho"           , this.paBox.BunHo );
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "suname"          , this.paBox.SuName);
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "birth"           , Convert.ToDateTime(this.paBox.Birth).ToString("yyyy/MM/dd"));
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "sex"             , this.paBox.Sex   );

				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ipwon_date"      , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun_ipwon_date"));
                //this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "cht_ipwon_date"  , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun_ipwon_date"));
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "gisan_ipwon_date", this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun_ipwon_date"));
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ipwon_time"      , EnvironInfo.GetSysDateTime().ToString("Hmm"));
                this.layINP1001Update.SetItemValue(layINP1001Update.RowCount - 1, "sil_ipwon_date", this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun_ipwon_date"));

				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ipwon_gwa"       , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gwa"));
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "gwa"             , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gwa"));
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "doctor"          , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "doctor"));
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "resident"        , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "doctor"));
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "jisi_doctor"     , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "doctor"));

				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ho_dong1"        , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "org_ho_dong1"));
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ho_code1"        , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "org_ho_code1"));
                this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ho_grade1"       , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "org_ho_grade1"));
                //this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ho_status1"      , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "org_ho_status1"));
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "bed_no"          , this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "org_bed_no"));

				// 입원타잎 
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ipwon_type", this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "ipwon_type")); //입원유형은 "정상"으로 기본셋팅

				// 재원플레그, 심사마감 구분
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "jaewon_flag"   , "Y");  // 재원중
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "simsa_magam_gubun", "1");  // 재원중

				// 취소데이터 여부
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "cancel_yn"     , "N");  // 취소여부

				// 입원경로1, 2 첫번째 데이터로 기본셋팅
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ipwon_rtn1"    , "1");  // 입원경로
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "ipwon_rtn2"    , "1");  // 입원경로2

				// 특진
				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "special_yn"    , "N");  // 특진

				// 초재진 데이터 로드 
				string chojae = NURI.Methodes.GetChoJae(this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun_ipwon_date"), this.paBox.BunHo, 
					this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gwa"), 
					this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun"));

				this.layINP1001Update.SetItemValue(layINP1001Update.RowCount-1, "chojae", chojae);
				
			}
		}

		private void MakeUpdateBoheomInfo ()
		{
			this.layINP1002Update.Reset();

			if (this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "data_gubun") == "O")
			{
				this.layINP1002Update.LayoutTable.ImportRow(this.grdINP1002.LayoutTable.Rows[this.grdINP1002.CurrentRowNumber]);

				this.layINP1002Update.SetItemValue(this.layINP1002Update.RowCount-1, "gubun_trans_cnt", "1");
				this.layINP1002Update.SetItemValue(this.layINP1002Update.RowCount-1, "gubun_trans_yn" , "N");

				this.layINP1002Update.SetItemValue(this.layINP1002Update.RowCount-1, "iud_gubun", "I");
			}
			else
			{
				for (int i=0;i<this.grdINP1002.RowCount; i++)
				{
					if (this.grdINP1002.GetRowState(i) == DataRowState.Modified)
					{
						this.layINP1002Update.LayoutTable.ImportRow(this.grdINP1002.LayoutTable.Rows[i]);

						this.layINP1002Update.SetItemValue(this.layINP1002Update.RowCount-1, "iud_gubun", "U");
					}
				}
			}
		}

		private bool CheckINP1002 ()
		{
			this.mCap = (NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗");

			for (int i=0; i<this.layINP1002Update.RowCount; i++)
			{
                //ldBoheomInfo.GetData(this.layINP1002Update.GetItemString(i, "gubun")
                //    , this.layINP1002Update.GetItemString(i, "gubun_ipwon_date"));

				if (this.layINP1002Update.GetItemString(i, "gwa") == "")
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "진료과를 입력해 주십시오." : "診療科を入力してください。");

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.fbxGwa.SelectAll();
					this.fbxGwa.Focus();

					return false;
				}

				if (this.layINP1002Update.GetItemString(i, "doctor") == "")
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "주치의를 입력해 주십시오." : "主治医を入力してください。");

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.fbxDoctor.SelectAll();
					this.fbxDoctor.Focus();

					return false;
				}

				if (this.layINP1002Update.GetItemString(i, "gubun_ipwon_date") == "")
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "개시일자를 입력해 주십시오." : "開始日付を入力してください。");
					
					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.dtpGubunIpwonDate.SelectAll();
					this.dtpGubunIpwonDate.Focus();

					return false;
				}


				if (this.layINP1002Update.GetItemString(i, "gubun") == "")
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "보험종류를 입력해 주십시오." : "保険種別を入力してください");

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					return false;
				}

				// 보험자번호 체크 YN
                //if (ldBoheomInfo.JOHAP_YN == "Y")
                //{
                //    // 보험자 번호 체크
                //    if (this.layINP1002Update.GetItemString(i, "johap") == "")
                //    {
                //        this.mMsg = (NetInfo.Language == LangMode.Ko ? "보험자번호를 입력해 주십시오." : "保険者番号を入力してください");

                //        this.SetMsg(this.mMsg, MsgType.Error);

                //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //        return false;
                //    }
                //}

			}

			return true;
		}

		#endregion

		#region 입원취소

		private bool ProcessIpwonCancel()
		{
            //string cmdText = @"SELECT TRUNC(FN_INP_LOAD_JUNPYO_DATE()) FROM DUAL";

            //BindVarCollection bindVars = new BindVarCollection();

            //object retVal = Service.ExecuteScalar(cmdText, bindVars);
            //if(TypeCheck.IsNull(retVal))
            //{
            //    XMessageBox.Show("FN_INP_LOAD_JUNPYO_DATE Error");
            //}

			ArrayList inputList = new ArrayList();
			ArrayList outputList = new ArrayList();
			ArrayList outputList1 = new ArrayList();

            /* 입원취소 */
			inputList.Add(UserInfo.UserID);
			inputList.Add(this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "fkinp1001"));
			inputList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

			if(!Service.ExecuteProcedure("PR_INP_IPWON_CANCEL", inputList, outputList))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : PR_INP_IPWON_CANCEL Error");
				return false;
			}

			if(outputList[0].ToString() != "0")
			{
				XMessageBox.Show(Service.ErrFullMsg + " : " + outputList[0].ToString() + " ,  PR_INP_IPWON_CANCEL Error");
				return false;
			}

            /*********입원취소 너스콜*/
//            cmdText = string.Empty;
//            bindVars.Clear();

//            cmdText = @"SELECT BUNHO
//						  FROM INP1001
//						 WHERE HOSP_CODE = :f_hosp_code 
//                           AND PKINP1001 = :f_pkinp1001
//						   AND ROWNUM    = 1";

//            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//            bindVars.Add("f_pkinp1001", this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "fkinp1001"));

//            retVal = null;
//            retVal = Service.ExecuteScalar(cmdText,  bindVars);
            //if(TypeCheck.IsNull(retVal))
            //{
            //    this.mMsg = NetInfo.Language == LangMode.Ko ? "취소에 실패 하였습니다." : "取消に失敗しました。";
                
            //    if(Service.ErrFullMsg != "")
            //        this.mMsg += "-" + Service.ErrFullMsg;

            //    this.mCap = NetInfo.Language == LangMode.Ko ? "취소실패" : "取消失敗";

            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return false;
            //}
			
			this.mMsg = NetInfo.Language == LangMode.Ko ? "입원취소가 완료 되었습니다." : "入院取消が完了しました。";
			this.mCap = NetInfo.Language == LangMode.Ko ? "취소완료" : "取消完了";

			XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

			return true;
		}

		#endregion

		#region XTabPage

		private void tabOUT0102_SelectionChanged(object sender, EventArgs e)
		{
			foreach (X.Magic.Controls.TabPage tpg in this.tabOUT0102.TabPages)
			{
				if (tpg == this.tabOUT0102.SelectedTab )
				{
					tpg.ImageIndex = 0;

					this.grdINP1002.SetFocusToItem(int.Parse(tpg.Tag.ToString()), "gubun_ipwon_date");
				}
				else
				{
					tpg.ImageIndex = 1;
				}
			}
		}

		#endregion

		#region XEditGrid

		private void grdINP1002_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			this.ProtectBoheomInfo();

			// 보험 정보 체크
			this.CheckBoheomInfo(e.CurrentRow);

			// 자기 한도 기본 셋팅
            //this.SetDefaultSelfHandoGubun();

			// 공비 정보 로드
			this.LoadGongbiQuery();

            this.mPKINP1002 = this.grdINP1002.GetItemString(e.CurrentRow, "pkinp1002");
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query :

					e.IsBaseCall = false;

					this.LoadData();

					break;

				case FunctionType.Update :

					e.IsBaseCall = false;

					this.AcceptData();

					// 데이터 만들고
					this.MakeUpdateInpwonInfo();

					this.MakeUpdateBoheomInfo();

					if (this.CheckINP1002() == false)
					{
						return ;
					}

					try
					{
						Service.BeginTransaction();

                        if (!this.layINP1001Update.SaveLayout())
                            throw new Exception();

                        if (!this.layINP1002Update.SaveLayout())
                            throw new Exception();

                        if (!this.grdINP1008.SaveLayout())
                            throw new Exception();

                        Service.CommitTransaction();

                        this.mMsg = NetInfo.Language == LangMode.Ko ? "정상적으로 저장 되었습니다." : "保存が完了しました。";
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.btnList.PerformClick(FunctionType.Query);
					}
					catch
					{
                        Service.RollbackTransaction();

                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : "保存に失敗しました。";
                        if(mErrMsg != "")
                            this.mMsg += "-" + mErrMsg;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
					}
					

					break;

				case FunctionType.Cancel :

					if (this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "data_gubun") == "O")
					{
						return ;
					}

					this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원취소를 하시겠습니까?" : "入院取消をしますか?");
					this.mCap = (NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ");

					DialogResult result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (result != DialogResult.Yes)
					{
						return;
					}

					if (this.ProcessIpwonCancel() == true)
					{
						this.btnList.PerformClick(FunctionType.Query);
					}

					break;

				case FunctionType.Close :

					break;
			}
		}

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Reset :

					break;
			}
		}

		#endregion

		#region XDatePicker

		// 개시일
		private void dtpGubunIpwonDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.SetDataToBoheomGrid("gubun_ipwon_date", e.DataValue);
		}

		#endregion

		#region FindClick

		private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XFindBox control = sender as XFindBox;

			switch (control.Name)
			{
				case "fbxGwa":

					#region 진료과

					//this.fbxGwa.FindWorker = WON.ComFind.GetFindGwaBAS0260(false, "", this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun_ipwon_date"));
                    fwkCommon.AutoQuery = true;
                    fwkCommon.ServerFilter = false;

                    fwkCommon.InputSQL = @"SELECT A.GWA
                                                , A.GWA_NAME
                                                , A.BUSEO_CODE
                                             FROM BAS0260 A
                                            WHERE A.HOSP_CODE = :f_hosp_code
                                              AND A.BUSEO_GUBUN = '1'  /*진료과*/
                                              AND :f_buseo_ymd BETWEEN A.START_DATE AND A.END_DATE
                                              AND(A.GWA       LIKE '%' || :f_find1 || '%'
                                               OR A.GWA_NAME  LIKE '%' || :f_find1 || '%')
                                            ORDER BY A.GWA";

                    fwkCommon.BindVarList.Clear();
                    fwkCommon.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                    fwkCommon.BindVarList.Add("f_buseo_ymd", this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun_ipwon_date"));

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("gwa", "診療科", FindColType.String, 80, 0, true, FilterType.No);
                    this.fwkCommon.ColInfos.Add("gwa_name", "診療科名", FindColType.String, 200, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;
					#endregion

					break;

				case "fbxDoctor":

					#region 주치의

                    //this.fbxDoctor.FindWorker = WON.ComFind.GetFindDoctorBAS0270(false,
                    //    this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gwa"),
                    //    this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "ipwon_date"));


                    fwkCommon.AutoQuery = true;
                    fwkCommon.ServerFilter = false;

                    fwkCommon.InputSQL = @"SELECT DOCTOR 
                                                 , DOCTOR_NAME
                                              FROM BAS0270
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND DOCTOR_GWA = :f_gwa
                                               AND :f_ipwon_date BETWEEN START_DATE AND END_DATE";

                    fwkCommon.BindVarList.Clear();
                    fwkCommon.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                    fwkCommon.BindVarList.Add("f_gwa", this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gwa"));
                    fwkCommon.BindVarList.Add("f_ipwon_date", this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "ipwon_date"));

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("doctor", "医師コード", FindColType.String, 70, 0, true, FilterType.No);
                    this.fwkCommon.ColInfos.Add("doctor_name", "医師名", FindColType.String, 160, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;

			}
		}

		#endregion

		#region Find DataValidating

		private void FindBox_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			XFindBox control = sender as XFindBox;
			string name = "";

			switch (control.Name)
			{
				case "fbxGwa":

					#region 진료과

					if (e.DataValue == "")
					{
						this.dbxGwaName.SetDataValue("");
						this.grdINP1002.SetItemValue(grdINP1002.CurrentRowNumber, "gwa_name", "");
						this.fbxDoctor.SetEditValue("");
						this.fbxDoctor.AcceptData();

						this.SetMsg("");

						return;
					}

					name = NURI.Methodes.GetGwaNameBAS0260( e.DataValue, this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "ipwon_date"));

					if (name == "")
					{
						this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과가 정확하지않습니다. 확인바랍니다." : "診療科が正確ではありません。確認してください。";

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}
					else
					{
						this.dbxGwaName.SetDataValue(name);
						this.grdINP1002.SetItemValue(grdINP1002.CurrentRowNumber, "gwa_name", name);
						this.fbxDoctor.SetEditValue("");
						this.fbxDoctor.AcceptData();
					}

					this.SetMsg("");

					#endregion

					this.SetDataToBoheomGrid("gwa", e.DataValue);
					this.SetDataToBoheomGrid("gwa_name", name);

					break;

				case "fbxDoctor":

					#region 주치의

					if (e.DataValue == "")
					{
						this.dbxDoctorName.SetDataValue("");
						this.grdINP1002.SetItemValue(grdINP1002.CurrentRowNumber, "doctor_name", "");
						
						this.SetMsg("");

						return ;
					}

					name = NURI.Methodes.GetDoctorNameBAS0270(e.DataValue, 
						this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gwa"),
						this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "ipwon_date"));

					if (name == "")
					{
						this.mMsg = NetInfo.Language == LangMode.Ko ? "의사코드가 정확하지않습니다. 확인바랍니다." : "医師コードが正確ではありません。確認してください。";

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}
					else
					{
						this.dbxDoctorName.SetDataValue(name);
						this.grdINP1002.SetItemValue(grdINP1002.CurrentRowNumber, "doctor_name", name);
					}

					this.SetMsg("");

					#endregion

					this.SetDataToBoheomGrid("doctor", e.DataValue);
					this.SetDataToBoheomGrid("doctor_name", name);

					break;
			}
		}

		#endregion


		#region XButton

		private void btnRegOUT0102_Click(object sender, System.EventArgs e)
		{
			this.OpenScreen_OUT0102U00();
		}

		private void btnRegOUT0105_Click(object sender, System.EventArgs e)
		{
			this.OpenScreen_OUT0105U00();
		}

		#endregion
		
		#region 저장로직
        private string mErrMsg = "";

		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private DoubleTypeRegForm parent = null;

			public XSavePerformer(DoubleTypeRegForm parent)
			{
				this.parent = parent;
			}

			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdQry = null;

				string cmdText = string.Empty;
				BindVarCollection bindVars = new BindVarCollection();
				object retVal = null;
				DataTable retTab = null;

				string mIpwonsi_Order = string.Empty;
                parent.mErrMsg = "";
                
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

				if(callerID == '1')
				{
					if(Convert.ToDateTime(item.BindVarList["f_gisan_ipwon_date"].VarValue)
						> Convert.ToDateTime(item.BindVarList["f_ipwon_date"].VarValue))
					{
                        //XMessageBox.Show(EnvironInfo.GetServerMsg(3639));

                        parent.mErrMsg = EnvironInfo.GetServerMsg(3639);
						return false;
					}

					cmdText = string.Empty;

					cmdText = @"SELECT FN_INP_IS_VALID_GISAN_DATE (:f_gisan_ipwon_date, :f_ipwon_date, :f_bunho) FROM DUAL";
                    //bindVars.Add("f_gisan_ipwon_date", item.BindVarList["f_gisan_ipwon_date"].VarValue);
                    //bindVars.Add("f_ipwon_date"      , item.BindVarList["f_ipwon_date"].VarValue);
                    //bindVars.Add("f_bunho"           , item.BindVarList["f_bunho"].VarValue);

					retVal = null;
                    retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
					if(!TypeCheck.IsNull(retVal))
					{
						if(retVal.ToString() != "Y")
						{
                            parent.mErrMsg = EnvironInfo.GetServerMsg(3640);
							return false;
						}
					}
					else
					{
                        parent.mErrMsg = EnvironInfo.GetServerMsg(3640);
						return false;
					}
                    
					switch(item.RowState)
					{
						case DataRowState.Added:

							#region Insert

							cmdText = string.Empty;

//                            cmdText = @"SELECT NVL(A.DELETE_YN, 'N')
//											 , NVL(A.JUBSU_BREAK, 'N')
//											 , B.CODE_NAME
//										  FROM BAS0102 B
//											 , OUT0101 A
//										 WHERE A.BUNHO = :f_bunho  
//										   AND A.JUBSU_BREAK_REASON = B.CODE (+)
//										   AND B.CODE_TYPE(+) = 'JUBSU_BREAK_REASON'";

//                            bindVars.Add("f_bunho", item.BindVarList["f_bunho"].VarValue);

//                            retTab = null;
//                            retTab = Service.ExecuteDataTable(cmdText, bindVars);
//                            if (retTab.Rows.Count < 1)
//                            {
//                                XMessageBox.Show(EnvironInfo.GetServerMsg(290));
//                                return false;
//                            }
//                            else
//                            {
//                                if(retTab.Rows[0][0].ToString() != "N")
//                                {
//                                    XMessageBox.Show(EnvironInfo.GetServerMsg(291));
//                                    return false;
//                                }

//                                if(retTab.Rows[0][1].ToString() != "N")
//                                {
//                                    XMessageBox.Show(EnvironInfo.GetServerMsg(292));
//                                    return false;
//                                }
//                            }

							if(item.BindVarList["f_ipwon_type"].VarValue == "0")
							{
								cmdText = string.Empty;
								cmdText = @"SELECT A.PKINP1001
												 , A.JAEWON_FLAG 
											  FROM INP1001 A
											 WHERE A.HOSP_CODE = :f_hosp_code
                                               AND A.BUNHO     = :f_bunho
											   AND A.JAEWON_FLAG = 'Y'
											   AND NVL(A.CANCEL_YN, 'N') = 'N'
											   AND A.IPWON_DATE <= NVL(:f_ipwon_date , TRUNC(SYSDATE))
											 ORDER BY A.IPWON_DATE";

								retTab = null;
								retTab = Service.ExecuteDataTable(cmdText, item.BindVarList);
                                if (retTab.Rows.Count < 1)
								{
								}
								else
								{
									if(retTab.Rows[0][1].ToString() == "Y")
									{
                                        parent.mErrMsg = EnvironInfo.GetServerMsg(293);
										return false;
									}
								}
							}

							if(item.BindVarList["f_chojae"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(3278);
								return false;
							}

							cmdText = string.Empty;
                            cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS ( SELECT 'X'
                                                          FROM BAS0260 A
                                                         WHERE A.HOSP_CODE = :f_hosp_code
                                                           AND A.GWA       = :f_ipwon_gwa
                                                           AND :f_sil_ipwon_date BETWEEN A.START_DATE AND A.END_DATE  )";

							retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
							if(TypeCheck.IsNull(retVal))
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(297);
								return false;
							}
							else
							{
								if(retVal.ToString() != "Y")
                                {
                                    parent.mErrMsg = EnvironInfo.GetServerMsg(297);
									return false;
								}
							}

							cmdText = string.Empty;
							bindVars.Clear();

                            cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS ( SELECT 'X'
                                                           FROM BAS0270 A
                                                         WHERE A.HOSP_CODE  = :f_hosp_code
                                                           AND A.DOCTOR_GWA = :f_ipwon_gwa
                                                           AND A.DOCTOR     = :f_doctor
                                                           AND :f_sil_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";
							retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
							if(TypeCheck.IsNull(retVal))
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(298);
								return false;
							}
							else
							{
								if(retVal.ToString() != "Y")
                                {
                                    parent.mErrMsg = EnvironInfo.GetServerMsg(298);
									return false;
								}
							}

							if(item.BindVarList["f_ipwon_date"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(327);
								return false;
							}

							if(item.BindVarList["f_ipwon_time"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(328);
								return false;
							}

							if(item.BindVarList["f_ipwon_type"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(330);
								return false;
							}

							if((item.BindVarList["f_ipwon_type"].VarValue != "2")
								&& (item.BindVarList["f_ipwon_type"].VarValue != "3"))
							{
								cmdText = string.Empty;

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0260 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.GWA = :f_ho_dong1
                                                               AND :f_sil_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";

								retVal = null;
                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(TypeCheck.IsNull(retVal))
								{
                                    parent.mErrMsg = EnvironInfo.GetServerMsg(3317);
									return false;
								}
								else
								{
									if(retVal.ToString() != "Y")
                                    {
                                        parent.mErrMsg = EnvironInfo.GetServerMsg(3317);
										return false;
									}
								}

								cmdText = string.Empty;

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0250 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.HO_DONG = :f_ho_dong1
                                                               AND A.HO_CODE = :f_ho_code1
                                                               AND :f_sil_ipwon_date BETWEEN A.START_DATE AND A.END_DATE  )";
								retVal = null;
                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(TypeCheck.IsNull(retVal))
								{
                                    parent.mErrMsg = EnvironInfo.GetServerMsg(3318);
									return false;
								}
								else
								{
									if(retVal.ToString() != "Y")
									{
                                        parent.mErrMsg = EnvironInfo.GetServerMsg(3318);
										return false;
									}
								}

								cmdText = string.Empty;
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0253 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.HO_DONG = :f_ho_dong1
                                                               AND A.HO_CODE = :f_ho_code1
                                                               AND A.BED_NO  = :f_bed_no
                                                               AND :f_sil_ipwon_date BETWEEN A.FROM_BED_DATE AND NVL(A.TO_BED_DATE, '9998/12/31'))";

								retVal = null;
                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(TypeCheck.IsNull(retVal))
								{
                                    parent.mErrMsg = EnvironInfo.GetServerMsg(3319);
									return false;
								}
								else
								{
									if(retVal.ToString() != "Y")
									{
                                        parent.mErrMsg = EnvironInfo.GetServerMsg(3319);
										return false;
									}
								}

								if((item.BindVarList["f_ho_dong1"].VarValue == "")||(item.BindVarList["f_ho_code1"].VarValue == "")
									||(item.BindVarList["f_bed_no"].VarValue == ""))
								{
                                    parent.mErrMsg = EnvironInfo.GetServerMsg(331);
									return false;
								}

								cmdText = string.Empty;
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM INP1001 
                                                             WHERE HOSP_CODE   = :f_hosp_code
                                                               AND JAEWON_FLAG = 'Y'
                                                               AND HO_DONG1    = :f_ho_dong1
                                                               AND HO_CODE1    = :f_ho_code1
                                                               AND BED_NO      = :f_bed_no   )";

								retVal = null;
                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(!TypeCheck.IsNull(retVal))
								{
									if(retVal.ToString() == "Y")
									{
                                        parent.mErrMsg = EnvironInfo.GetServerMsg(295);
										return false;
									}
								}

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0250 B
                                                                 , BAS0253 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.BED_STATUS NOT IN ('00', '01', '02', '03') 
                                                               AND A.HO_CODE = :f_ho_code1
                                                               AND A.BED_NO  = :f_bed_no
                                                               AND B.HOSP_CODE = A.HOSP_CODE
                                                               AND B.HO_CODE = A.HO_CODE
                                                               AND B.HO_DONG = :f_ho_dong1
                                                               AND A.HO_DONG = B.HO_DONG
                                                               AND :f_sil_ipwon_date BETWEEN B.START_DATE AND B.END_DATE  )";								
								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(!TypeCheck.IsNull(retVal))
								{
									if(retVal.ToString() == "Y")
									{
                                        parent.mErrMsg = EnvironInfo.GetServerMsg(296);
										return false;
									}
								}
							}

							if((item.BindVarList["f_fkinp1003"].VarValue == "")||
								(item.BindVarList["f_fkinp1003"].VarValue != "")&&(item.BindVarList["f_pkinp1001"].VarValue == ""))
							{
								cmdText = string.Empty;
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM INP1003 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.BUNHO     = :f_bunho
                                                               AND A.RESER_END_TYPE = '0'
                                                               AND A.RESER_FKINP1001 IS NOT NULL )";								
								retVal = null;
                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(!TypeCheck.IsNull(retVal))
								{
									if(retVal.ToString() == "Y")
									{
                                        parent.mErrMsg = EnvironInfo.GetServerMsg(3443);
										return false;
									}
								}
							}

							if(item.BindVarList["f_pkinp1001"].VarValue == "")
							{
								cmdText = string.Empty;
								bindVars.Clear();

								cmdText = @"SELECT INP1001_SEQ.NEXTVAL FROM DUAL";

								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, bindVars);
								if(TypeCheck.IsNull(retVal))
								{
									XMessageBox.Show("INP1001_SEQ.NEXTVAL Error");
									return false;
								}

								mIpwonsi_Order = "N";
                                item.BindVarList.Remove("f_pkinp1001");
								item.BindVarList.Add("f_pkinp1001", retVal.ToString());
							}
							else
							{
								mIpwonsi_Order = "Y";
							}
							
							if(item.BindVarList["f_pkinp1001"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(321);
								return false;
							}

							if(item.BindVarList["f_ipwon_type"].VarValue != "2")
							{
								item.BindVarList.Add("f_fk_inp_key", item.BindVarList["f_pkinp1001"].VarValue);
							}
							else
							{
								cmdText = string.Empty;

								cmdText = @"SELECT A.PKINP1001
											  FROM INP1001 A
											 WHERE A.HOSP_CODE   = :f_hosp_code
                                               AND A.BUNHO       = :f_bunho
											   AND A.JAEWON_FLAG = 'Y'
											   AND NVL(A.CANCEL_YN, 'N') = 'N'
											   AND A.IPWON_TYPE = '0'";
								
								
								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(!TypeCheck.IsNull(retVal))
								{
									item.BindVarList.Add("f_fk_inp_key", retVal.ToString());
								}
							}

                            cmdQry = @"INSERT INTO INP1001
                                            ( SYS_DATE
                                            , SYS_ID
                                            , UPD_DATE
                                            , UPD_ID
                                            , HOSP_CODE
                                            , PKINP1001
                                            , BUNHO
                                            , IPWON_DATE
                                            , IPWON_TYPE
                                            , IPWON_TIME
                                            , IPWON_GWA
                                            , GWA
                                            , DOCTOR
                                            , RESIDENT
                                            , HO_CODE1
                                            , HO_DONG1
                                            , HO_GRADE1
                                            , HO_CODE2
                                            , HO_DONG2
                                            --, IPWON_RTN1
                                            , IPWON_RTN2
                                            , CHOJAE
                                            , BABY_STATUS
                                            , INP_TRANS_YN
                                            , FKOUT1001
                                            , JAEWON_FLAG
                                            , TOIWON_GOJI_YN
                                            , TOIWON_RES_DATE
                                            , TOIWON_RES_TIME
                                            , GA_TOIWON_DATE
                                            , TOIWON_DATE
                                            , TOIWON_TIME
                                            , RESULT
                                            , SIGI_MAGAM_YN
                                            , SIMSA_MAGAM_GUBUN
                                            , CANCEL_DATE
                                            , CANCEL_USER
                                            , CANCEL_YN
                                            --, TOIWON_DRG_ILSU
                                            , FKINP1003
                                            , TEAM
                                            , SIMSA_MAGAM_DATE
                                            , SIMSA_MAGAM_TIME
                                            , GISAN_IPWON_DATE
                                            , BED_NO                
                                            , GISAN_JAEWON_ILSU    
                                            , JISI_DOCTOR           
                                            , FK_INP_KEY         )
                                            VALUES(SYSDATE
                                            , :f_user_id
                                            , SYSDATE
                                            , :f_user_id
                                            , :f_hosp_code
                                            , :f_pkinp1001
                                            , :f_bunho
                                            , :f_ipwon_date
                                            , :f_ipwon_type
                                            , REPLACE(:f_ipwon_time, ':')
                                            , :f_ipwon_gwa
                                            , :f_gwa
                                            , :f_doctor
                                            , :f_resident
                                            , :f_ho_code1
                                            , :f_ho_dong1
                                            , :f_ho_grade1
                                            , :f_ho_code2
                                            , :f_ho_dong2
                                            --, :f_ipwon_rtn1
                                            , :f_ipwon_rtn2
                                            , :f_chojae
                                            , :f_baby_status
                                            , :f_inp_trans_yn
                                            , :f_fkout1001
                                            , :f_jaewon_flag
                                            , :f_toiwon_goji_yn
                                            , :f_toiwon_res_date
                                            , NULL
                                            , :f_ga_toiwon_date
                                            , :f_toiwon_date
                                            , :f_toiwon_time
                                            , :f_result
                                            , :f_sigi_magam_yn
                                            , :f_simsa_magam_gubun
                                            , :f_cancel_date
                                            , :f_cancel_user
                                            , :f_cancel_yn
                                            --, :f_toiwon_drg_ilsu
                                            , :f_fkinp1003
                                            , :f_team
                                            , NULL
                                            , NULL
                                            , :f_ipwon_date --:f_gisan_ipwon_date
                                            , :f_bed_no              
                                            , :f_gisan_jaewon_ilsu   
                                            , :f_jisi_doctor    
                                            , :f_fk_inp_key          )";

							if(!Service.ExecuteNonQuery(cmdQry, item.BindVarList))
							{
                                parent.mErrMsg = Service.ErrFullMsg + " : INP1001 Insert Error";
								return false;
							}

							parent.sPkinp1001 = item.BindVarList["f_pkinp1001"].VarValue;

							cmdText = string.Empty;
							cmdText = @"SELECT FN_OUT_CHECK_JUBSU_CNT(:f_bunho, :f_ipwon_date) FROM DUAL";
								
							retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
							if(TypeCheck.IsNull(retVal))
							{
                                parent.mErrMsg = "FN_OUT_CHECK_JUBSU_CNT Error";
								return false;
							}
							else
							{
								if((item.BindVarList["f_ipwon_type"].VarValue == "0")&&(retVal.ToString() == "0"))
								{
									retVal = "Y";
								}
								return true;
							}

							#endregion

						case DataRowState.Modified:

							#region Update

							if(item.BindVarList["f_pkinp1001"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(321);
								return false;
							}

							if(item.BindVarList["f_bunho"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(283);
								return false;
							}

                            cmdQry = @"UPDATE INP1001
                                          SET UPD_ID                = :f_user_id
                                            , UPD_DATE              = SYSDATE
                                            , IPWON_TIME            = REPLACE(:f_ipwon_time, ':')
                                            , IPWON_GWA             = :f_ipwon_gwa
                                            , GWA                   = :f_gwa
                                            , DOCTOR                = :f_doctor
                                            , RESIDENT              = :f_resident
                                            , HO_CODE1              = :f_ho_code1
                                            , HO_DONG1              = :f_ho_dong1
                                            , HO_GRADE1             = :f_ho_grade1
                                            , HO_CODE2              = :f_ho_code2
                                            , HO_DONG2              = :f_ho_dong2
                                            , IPWON_RTN2            = :f_ipwon_rtn2
                                            , CHOJAE                = :f_chojae
                                            , BABY_STATUS           = :f_baby_status
                                            , INP_TRANS_YN          = :f_inp_trans_yn
                                            , FKOUT1001             = :f_fkout1001
                                            , JAEWON_FLAG           = :f_jaewon_flag
                                            , TOIWON_GOJI_YN        = :f_toiwon_goji_yn
                                            , TOIWON_RES_DATE       = :f_toiwon_res_date
                                            , TOIWON_RES_TIME       = NULL
                                            , GA_TOIWON_DATE        = :f_ga_toiwon_date
                                            , TOIWON_DATE           = :f_toiwon_date
                                            , TOIWON_TIME           = :f_toiwon_time
                                            , RESULT                = :f_result
                                            , SIGI_MAGAM_YN         = :f_sigi_magam_yn
                                            --, SIMSA_MAGAM_YN        = :f_simsa_magam_yn
                                            , CANCEL_DATE           = :f_cancel_date
                                            , CANCEL_USER           = :f_cancel_user
                                            , CANCEL_YN             = :f_cancel_yn
                                            , FKINP1003             = :f_fkinp1003
                                            , TEAM                  = :f_team
                                            , SIMSA_MAGAMJA         = NULL
                                            , SIMSA_MAGAM_DATE      = NULL
                                            , SIMSA_MAGAM_TIME      = NULL
                                            , GISAN_IPWON_DATE      = :f_ipwon_date --:f_gisan_ipwon_date
                                            , BED_NO                = :f_bed_no
                                            , GISAN_JAEWON_ILSU     = :f_gisan_jaewon_ilsu 
                                            , JISI_DOCTOR           = :f_jisi_doctor
                                        WHERE HOSP_CODE :f_hosp_code
                                          AND PKINP1001 = :f_pkinp1001";

							#endregion

							break;

						case DataRowState.Deleted:

							break;
					}
				}
				
				if(callerID == '2')
				{
					item.BindVarList.Add("f_pkinp1001", parent.sPkinp1001);
					if(item.BindVarList["f_fkinp1001"].VarValue == "")
					{
						item.BindVarList.Add("f_fkinp1001", item.BindVarList["f_pkinp1001"].VarValue);
					}

					switch(item.BindVarList["f_iud_gubun"].VarValue)
					{
						case "I":

							#region Insert

							if(item.BindVarList["f_fkinp1001"].VarValue == "")
							{
								if(item.BindVarList["f_pkinp1001"].VarValue == "")
								{
                                    parent.mErrMsg = "INP1001 PK is NULL";
									return false;
								}

								item.BindVarList.Add("f_fkinp1001", item.BindVarList["f_pkinp1001"].VarValue);
							}

							if(item.BindVarList["f_fkinp1001"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(340);
								return false;
							}

							cmdText = string.Empty;
                            cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS ( SELECT 'X'
                                                          FROM BAS0210 A
                                                         WHERE A.HOSP_CODE = :f_hosp_code
                                                           AND A.GUBUN = :f_gubun
                                                           AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";
							retVal = null;
							retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
							if(TypeCheck.IsNull(retVal))
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(338);
								return false;
							}
							else
							{
								if(retVal.ToString() != "Y")
								{
                                    parent.mErrMsg = EnvironInfo.GetServerMsg(338);
									return false;
								}
							}

							cmdText = string.Empty;
                            cmdText = @"SELECT --A.TO_JY_DATE_YN
                                             --, A.JOHAP_YN
                                             --, A.GAEIN_YN
                                             --, A.BONIN_YN
                                             --, A.PINAME_YN
                                             --, A.GAEIN_NO_YN
                                               NVL(A.GONGBI_YN, 'Y')
                                             --, A.GUBUN_TRUE_YN
                                          FROM BAS0210 A
                                         WHERE A.HOSP_CODE = :f_hosp_code
                                           AND A.GUBUN = :f_gubun
                                           AND :f_gubun_ipwon_date  BETWEEN A.START_DATE AND A.END_DATE";

                            retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if ((TypeCheck.IsNull(retVal)))
                            {
                                parent.mErrMsg = EnvironInfo.GetServerMsg(361);
                                return false;
                            }

                            string gongbiYN = retVal.ToString();

                            int rNum_age = 0;

                            cmdText = string.Empty;
                            cmdText = @"SELECT FN_BAS_LOAD_AGE(TRUNC(SYSDATE), A.BIRTH, 'XXXX')
										  FROM OUT0101 A
										 WHERE A.HOSP_CODE = :f_hosp_code
                                           AND A.BUNHO = :f_bunho";

                            retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                            if (TypeCheck.IsNull(retVal))
                            {
                                parent.mErrMsg = EnvironInfo.GetServerMsg(352);
                                return false;
                            }
                            else
                            {
                                rNum_age = Convert.ToInt32(retVal.ToString());
                            }

                            //if ((mJohap_Gubun == "10") || (mJohap_Gubun == "20"))
                            //{
                            //    if (item.BindVarList["f_gubun"].VarValue == "02")
                            //    {
                            //        if (item.BindVarList["f_sunwon_gubun"].VarValue == "")
                            //        {
                            //            XMessageBox.Show(EnvironInfo.GetServerMsg(353));
                            //            return false;
                            //        }
                            //    }
                            //    else if ((item.BindVarList["f_gubun"].VarValue == "B1") ||
                            //        (item.BindVarList["f_gubun"].VarValue == "B2") ||
                            //        (item.BindVarList["f_gubun"].VarValue == "A1") ||
                            //        (item.BindVarList["f_gubun"].VarValue == "A2"))
                            //    {
                            //        if (item.BindVarList["f_budamja_bunho"].VarValue == "")
                            //        {
                            //            XMessageBox.Show(EnvironInfo.GetServerMsg(355));
                            //            return false;
                            //        }

                            //        if (item.BindVarList["f_sugubja_bunho"].VarValue == "")
                            //        {
                            //            XMessageBox.Show(EnvironInfo.GetServerMsg(356));
                            //            return false;
                            //        }
                            //    }
                            //}

                            if ((gongbiYN == "Y") && (item.BindVarList["f_from_jy_date"].VarValue == ""))
                            {
                                parent.mErrMsg = EnvironInfo.GetServerMsg(358);
                                return false;
                            }

							ArrayList inputList = new ArrayList();
							ArrayList outputList = new ArrayList();

							inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
							inputList.Add(item.BindVarList["f_gubun"].VarValue);

							if(!Service.ExecuteProcedure("PR_INP_MAKE_PKINP1002", inputList, outputList))
							{
                                parent.mErrMsg = Service.ErrFullMsg + " : PR_INP_MAKE_PKINP1002 Error";
								return false;
							}
							else
                            {
                                parent.mPKINP1002 = outputList[0].ToString();
								item.BindVarList.Add("f_pkinp1002", outputList[0].ToString());
								item.BindVarList.Add("f_seq"      , outputList[1].ToString());
							}

							if(item.BindVarList["f_pkinp1002"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(189);
								return false;
							}

                            cmdQry = @"INSERT INTO INP1002
                                                        ( SYS_DATE
                                                        , SYS_ID
                                                        , UPD_DATE
                                                        , UPD_ID
                                                        , HOSP_CODE
                                                        , PKINP1002
                                                        , FKINP1001
                                                        , BUNHO
                                                        , GUBUN
                                                        , SEQ
                                                        , GUBUN_TRANS_DATE
                                                        , GUBUN_IPWON_DATE
                                                        , GUBUN_TOIWON_DATE
                                                        , GUBUN_TRANS_CNT
                                                        , GUBUN_TRANS_YN
                                                        , SIMSAJA
                                                        , SIMSA_MAGAM_YN
                                                        )
                                                    VALUES(SYSDATE
                                                        , :f_user_id
                                                        , SYSDATE
                                                        , :f_user_id
                                                        , :f_hosp_code
                                                        , :f_pkinp1002
                                                        , :f_fkinp1001
                                                        , :f_bunho
                                                        , :f_gubun
                                                        , :f_seq
                                                        , NULL
                                                        , TO_DATE(:f_gubun_ipwon_date, 'YYYY/MM/DD')
                                                        , NULL
                                                        , :f_gubun_trans_cnt
                                                        , :f_gubun_trans_yn
                                                        , NULL
                                                        , :f_simsa_magam_yn
                                                        )";

							if(!Service.ExecuteNonQuery(cmdQry, item.BindVarList))
							{
                                parent.mErrMsg = Service.ErrFullMsg + " : INP1002 Insert Error";
								return false;
							}

							if(mIpwonsi_Order == "Y")
							{
								inputList.Clear();
								outputList.Clear();

								inputList.Add(UserInfo.UserID);
								inputList.Add(item.BindVarList["f_bunho"].VarValue);
								inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);

								if(!Service.ExecuteProcedure("PR_OCS_UPDATE_INP_ORDER_RES", inputList, outputList))
								{
                                    parent.mErrMsg = Service.ErrFullMsg + " : PR_OCS_UPDATE_INP_ORDER_RES Error";
									return false;
								}
								else
								{
									if((outputList[1].ToString() != "0")&&(outputList[1].ToString() != "1"))
									{
                                        parent.mErrMsg = outputList[0].ToString();
										return false;
									}
								}

                                //inputList.Clear();
                                //outputList.Clear();

                                //inputList.Add(item.BindVarList["f_bunho"].VarValue);
                                //inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
                                //inputList.Add(item.BindVarList["f_ipwon_date"].VarValue);
                                //inputList.Add(item.BindVarList["f_ipwon_date"].VarValue);
                                //inputList.Add("0");
                                //inputList.Add(item.BindVarList["f_doctor"].VarValue);

                                //if(!Service.ExecuteProcedure("PR_OCS_APPLY_PLAN_ORDER", inputList, outputList))
                                //{
                                //    XMessageBox.Show(Service.ErrFullMsg + " : PR_OCS_APPLY_PLAN_ORDER Error");
                                //    return false;
                                //}

                                //inputList.Clear();
                                //outputList.Clear();

                                //inputList.Add(item.BindVarList["f_bunho"].VarValue);
                                //inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
                                //inputList.Add(item.BindVarList["f_ipwon_date"].VarValue);
                                //inputList.Add(item.BindVarList["f_ipwon_date"].VarValue);
                                //inputList.Add(item.BindVarList["f_doctor"].VarValue);

                                //if(!Service.ExecuteProcedure("PR_OCS_APPLY_PLAN_DIRECT", inputList, outputList))
                                //{
                                //    XMessageBox.Show(Service.ErrFullMsg + " : PR_OCS_APPLY_PLAN_DIRECT Error");
                                //    return false;
                                //}
							}

                            ///////////////////////////////////////////////////////////////////////////////
//                            if(item.BindVarList["f_ipwon_type"].VarValue == "0")
//                            {
//                                cmdText = string.Empty;
//                                cmdText = @"SELECT A.IP_ADDR
//											  FROM NUR0106 A
//											 WHERE A.HOSP_CODE = :f_hosp_code
//                                               AND A.HO_DONG = :f_ho_dong1";

//                                retTab = null;
//                                retTab = Service.ExecuteDataTable(cmdText, item.BindVarList);
//                                if (retTab.Rows.Count < 1)
//                                {
//                                    parent.mErrMsg = "IP_ADDR Query Error";
//                                    return false;
//                                }
//                                else
//                                {
//                                    for(int i=0; i < retTab.Rows.Count; i++)
//                                    {
//                                        cmdText = string.Empty;
//                                        cmdText = @"SELECT :f_bunho  || ',' || :f_ho_code1 || ',' ||
//														   :f_bed_no || ',' || FN_BAS_LOAD_DOCTOR_NAME(:f_doctor, :f_ipwon_date) || ',' ||
//														   A.SUNAME
//													  FROM OUT0101 A
//													 WHERE A.HOSP_CODE = :f_hosp_code
//                                                       AND A.BUNHO = :f_bunho";
//                                        retVal = null;
//                                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
//                                        if(TypeCheck.IsNull(retVal))
//                                        {
//                                            parent.mErrMsg = "Ipwon Msg is null";
//                                            return false;
//                                        }
//                                    }
//                                }

//                                inputList.Clear();
//                                outputList.Clear();

//                                inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
//                                inputList.Add(item.BindVarList["f_pkinp1002"].VarValue);
//                                inputList.Add(UserInfo.UserID);

//                                if(!Service.ExecuteProcedure("PR_INP_COMPUTE_JINCHAL_JPN", inputList, outputList))
//                                {
//                                    parent.mErrMsg = Service.ErrFullMsg + " : PR_INP_COMPUTE_JINCHAL_JPN Error";
//                                    return false;
//                                }
//                                else
//                                {
//                                    if(outputList[0].ToString() != "0")
//                                    {
//                                        parent.mErrMsg = EnvironInfo.GetServerMsg(3279);
//                                        return false;
//                                    }
//                                }
//                            }
                            ////////////////////////////////////////////////////////////////////////////////////////

							return true;

							#endregion

						case "U":

							#region Update

//                            cmdQry = @"UPDATE INP1002
//										  SET UPD_ID           = :f_user_id
//											, UPD_DATE         = SYSDATE
//											, SELF_HANDO_GUBUN = :f_self_hando_gubun
//											, SIKSA_BON_GUBUN  = :f_siksa_bon_gubun
//											, PATIENT_GUBUN    = :f_patient_gubun
//										WHERE HOSP_CODE        = :f_hosp_code
//                                          AND PKINP1002        = :f_pkinp1002";

							#endregion

							break;
					}
				}

				if(callerID == '3')
                {
                    item.BindVarList.Add("f_pkinp1002", parent.mPKINP1002);
					switch(item.BindVarList["f_check_yn"].VarValue)
					{
						case "Y":

							#region Insert

							if(item.BindVarList["f_fkinp1002"].VarValue == "")
							{
								if(item.BindVarList["f_pkinp1002"].VarValue == "")
								{
                                    parent.mErrMsg = "INP1002 PK is null";
									return false;
								}

								item.BindVarList.Add("f_fkinp1002", item.BindVarList["f_pkinp1002"].VarValue);
							}

							if(item.BindVarList["f_fkinp1002"].VarValue == "")
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(190);
								return false;
							}

							cmdText = string.Empty;
                            cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS ( SELECT 'X'
                                                          FROM OUT0105 A
                                                         WHERE A.HOSP_CODE     = :f_hosp_code
                                                           AND A.BUNHO         = :f_bunho
                                                           AND A.GONGBI_CODE   = :f_gongbi_code
                                                           AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";

							retVal = null;
							retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
							if(TypeCheck.IsNull(retVal))
							{
                                parent.mErrMsg = EnvironInfo.GetServerMsg(359);
								return false;
							}
							else
							{
								if(retVal.ToString() != "Y")
								{
                                    parent.mErrMsg = EnvironInfo.GetServerMsg(359);
									return false;
								}
							}

							cmdQry = @"DECLARE
										BEGIN
										
                                         UPDATE INP1008
                                            SET UPD_ID          = :f_user_id
                                              , UPD_DATE         = SYSDATE
                                              , BUNHO            = :f_bunho
                                          WHERE HOSP_CODE        = :f_hosp_code 
                                            AND FKINP1002        = :f_fkinp1002
                                            AND GONGBI_CODE      = :f_gongbi_code;

										IF SQL%NOTFOUND THEN
                                        INSERT INTO INP1008
                                            ( SYS_DATE
                                            , SYS_ID
                                            , UPD_DATE
                                            , UPD_ID
                                            , HOSP_CODE 
                                            , FKINP1002
                                            , GONGBI_CODE
                                            , BUNHO         )
                                        VALUES(SYSDATE
                                            , :f_user_id
                                            , SYSDATE
                                            , :f_user_id
                                            , :f_hosp_code
                                            , :f_fkinp1002
                                            , :f_gongbi_code
                                            , :f_bunho     );                                        
										     
										END IF;
										END;";

							cmdQry = cmdQry.Replace("\r", " ");

							#endregion

							break;

						case "N":

							#region Update

							if(item.BindVarList["f_fkinp1002"].VarValue == "")
							{
								if(item.BindVarList["f_pkinp1002"].VarValue == "")
								{
                                    parent.mErrMsg = "INP1002 PK is null";
									return false;
								}

								item.BindVarList.Add("f_fkinp1002", "f_pkinp1002");
							}

							cmdQry = @"DELETE FROM INP1008
										WHERE HOSP_CODE   = :f_hosp_code
                                          AND FKINP1002   = :f_fkinp1002
										  AND GONGBI_CODE = :f_gongbi_code";

							#endregion

							break;
					}
				}
				return Service.ExecuteNonQuery(cmdQry, item.BindVarList);
			}
		}
		#endregion




    }
}
