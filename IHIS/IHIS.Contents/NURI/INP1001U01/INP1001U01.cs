#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.NURI;
using System.Net.Sockets;
using System.Net;
using System.Text;
#endregion

/* 후납에 대한 주석.....
 * 자동차 보험에 대하여 후납이 존재한다.
 * 가해자 A, 피해자 B가 존재 
 * A의 한도는 10000원이 한도다. B의 치료비는 20000원이다
 * 이때 A와 B는 협의하에 B는 일반보험으로 입원하고 7:3으로 나누어진
 * 본인부담에 대하여 후납(자보)으로 처리한다. */

/* 
 *    
 * 
 * */

namespace IHIS.NURI
{
	/// <summary>
	/// INP1001U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INP1001U01 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XButton btnIpwonTrans;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XButton btnIpwonCancel;
        private IHIS.Framework.XButton btnTransDate;
		private IHIS.Framework.XEditMask emkGisanJaewonIlsu;
		private IHIS.Framework.XDatePicker dtpIpwonDate;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XEditGrid grdINP1001;
		private IHIS.Framework.XDatePicker dtpGisanDate;
		private IHIS.Framework.XLabel xLabel36;
		private IHIS.Framework.XLabel xLabel32;
		private IHIS.Framework.XDictComboBox cboBabyStatus;
		private IHIS.Framework.XDictComboBox cboIpwonRtn2;
		private IHIS.Framework.XLabel xLabel19;
		private IHIS.Framework.XLabel xLabel25;
		private IHIS.Framework.XCheckBox cbxIncuYN;
		private IHIS.Framework.XDictComboBox cboHoGrade1;
		private IHIS.Framework.XDisplayBox dbxDoctorName;
		private IHIS.Framework.XFindBox fbxDoctor;
		private IHIS.Framework.XEditMask txtIpwonTime;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel16;
		private IHIS.Framework.XLabel xLabel18;
		private IHIS.Framework.XDictComboBox cboChojae;
		private IHIS.Framework.XLabel xLabel47;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
        private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
        private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
        private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell68;
		private IHIS.Framework.XEditGridCell xEditGridCell69;
		private IHIS.Framework.XEditGridCell xEditGridCell70;
		private IHIS.Framework.XEditGridCell xEditGridCell71;
		private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
		private IHIS.Framework.XEditGridCell xEditGridCell92;
		private IHIS.Framework.XEditGridCell xEditGridCell93;
		private IHIS.Framework.XEditGridCell xEditGridCell94;
		private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell97;
		private IHIS.Framework.XEditGridCell xEditGridCell105;
        private IHIS.Framework.XEditGridCell xEditGridCell167;
		private IHIS.Framework.XEditGridCell xEditGridCell192;
		private IHIS.Framework.XEditGridCell xEditGridCell78;
		private IHIS.Framework.XPanel pnlPatientInfo;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XLabel xLabel12;
        private IHIS.Framework.XLabel xLabel20;
		private IHIS.Framework.XPanel xPanel9;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
        private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XDisplayBox dbxHoCode;
        private IHIS.Framework.XDisplayBox dbxBedNo;
        private IHIS.Framework.XDictComboBox cboIpwonType;
        private IHIS.Framework.XGrid grdOUT0103;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.XDisplayBox dbxGwaName;
		private IHIS.Framework.XFindBox fbxGwa;
        private IHIS.Framework.XButton btnBedButton;
		private IHIS.Framework.XPanel pnlINP1001Control;
        private IHIS.Framework.XDisplayBox dbxHoDong;
		private IHIS.Framework.XButton btnRegDoubleType;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private System.Windows.Forms.PictureBox pbxIpwonTrans;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XLabel xLabel27;
		private IHIS.Framework.XDisplayBox dbxJisiDoctorName;
		private IHIS.Framework.XFindBox fbxJisiDoctor;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private System.Windows.Forms.PictureBox pbxDoubleTypeYN;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.MultiLayout layCommon;
        private IHIS.Framework.MultiLayout layINP1002Update;
        private XLabel xLabel30;
        private XEditGridCell xEditGridCell13;
        private SingleLayout layInp1002;
        private SingleLayoutItem singleLayoutItem1;
        private XPanel pnlGongbi;
        private XEditGrid grdOUT0106;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XButton btnRegOUT0106;
        private XPanel xPanel1;
        private XPanel pnlNUR0106;
        private XEditGrid grdINP1008;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XButton btnRegOUT0105;
        private XLabel xLabel7;
        private XLabel xLabel1;
        private XButton btnBoheomOpen;
        private XDisplayBox dbxGubunName;
        private XFindBox fbxGubun;
        private XFindWorker fwkGubun;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XDatePicker dtpLastCheckDate;
        private XEditGridCell xEditGridCell4;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private XButton btnTest;
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
        private SingleLayoutItem singleLayoutItem4;
        private XEditGridCell xEditGridCell7;
        private XButton btnResend;
        private SingleLayout layLastCheckDate;
        private SingleLayoutItem singleLayoutItem5;
        private XEditGridCell xEditGridCell12;
        private XButton btnAddEtcIpwon;
        private SingleLayout layCheckEctIpwon;
        private SingleLayoutItem singleLayoutItem6;
        private XButton btnChangeGubun;
        private XTreeView tvwBoheomInfo;
        private XPanel xPanel3;
        private XEditGrid grdINP1004;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell20;
        private XTextBox txtName;
        private XEditGridCell xEditGridCell21;
        private XFindBox fbxZipCode1;
        private XEditGridCell xEditGridCell22;
        private XEditMask txtZipCode2;
        private XEditGridCell xEditGridCell23;
        private XFindBox fbxAddress1;
        private XEditGridCell xEditGridCell24;
        private XTextBox txtAddress2;
        private XEditGridCell xEditGridCell31;
        private XEditMask txtTel1;
        private XEditGridCell xEditGridCell34;
        private XEditMask txtTel2;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XTextBox txtBigo;
        private XEditGridCell xEditGridCell48;
        private XFindBox fbxBoninGubun;
        private XEditGridCell xEditGridCell180;
        private XTextBox txtBoninGubunName;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XDictComboBox cboTelGubun;
        private XEditGridCell xEditGridCell54;
        private XDictComboBox cboTelGubun2;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XTextBox txtName2;
        private XEditGridCell xEditGridCell61;
        private XDatePicker dtpBirth;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell74;
        private XGroupBox gbxWith;
        private XRadioButton rbxWithN;
        private XRadioButton rbxWithY;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XEditGridCell xEditGridCell76;
        private XGroupBox gbxLive;
        private XRadioButton rbxLiveN;
        private XRadioButton rbxLiveY;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XEditGridCell xEditGridCell77;
        private XPanel xPanel4;
        private XLabel xLabel26;
        private XLabel xLabel24;
        private XLabel xLabel17;
        private XLabel xLabel41;
        private XPanel pnlINP1004;
        private XTextBox txtAge;
        private XLabel lblLive;
        private XLabel lblWith;
        private XLabel xLabel5;
        private XLabel xLabel3;
        private XLabel xLabel8;
        private XEditMask txtSeq;
        private XLabel xLabel21;
        private XLabel xLabel22;
        private XLabel xLabel23;
        private XLabel xLabel29;
        private XPanel xPanel6;
        private XButton btnDelete;
        private XButton btnInsert;
        private PictureBox pictureBox1;
        private XEditGridCell xEditGridCell15;
        private XLabel xLabel9;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XLabel xLabel10;
        private XDictComboBox cboEmergencyGubun;
        private XMemoBox mbxEmergencyDetail;
        private XDictComboBox cboKaikei_HoCode;
        private XBuseoCombo cboKaikei_HoDong;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XLabel xLabel11;
        private XEditGridCell xEditGridCell84;
        private XButton btnPrint;
        private System.ComponentModel.Container components = null;
		#endregion

		public INP1001U01()
		{
            try
            {
                // 이 호출은 Windows Form 디자이너에 필요합니다.
                InitializeComponent();

                this.SaveLayoutList.Add(this.grdINP1001);
//                this.SaveLayoutList.Add(this.layINP1002Update);
                this.SaveLayoutList.Add(this.grdINP1004);
                this.SaveLayoutList.Add(this.grdINP1008);

                this.grdINP1001.SavePerformer = new XSavePerformer(this);
//                this.layINP1002Update.SavePerformer = this.grdINP1001.SavePerformer;
                this.grdINP1004.SavePerformer = this.grdINP1001.SavePerformer;
                this.grdINP1008.SavePerformer = this.grdINP1001.SavePerformer;
            }
            catch(Exception x)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(x.StackTrace.ToString());
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP1001U01));
            this.btnList = new IHIS.Framework.XButtonList();
            this.btnIpwonTrans = new IHIS.Framework.XButton();
            this.btnRegDoubleType = new IHIS.Framework.XButton();
            this.btnIpwonCancel = new IHIS.Framework.XButton();
            this.btnTransDate = new IHIS.Framework.XButton();
            this.pnlINP1001Control = new IHIS.Framework.XPanel();
            this.cboKaikei_HoDong = new IHIS.Framework.XBuseoCombo();
            this.cboKaikei_HoCode = new IHIS.Framework.XDictComboBox();
            this.dbxBedNo = new IHIS.Framework.XDisplayBox();
            this.dbxHoDong = new IHIS.Framework.XDisplayBox();
            this.dbxHoCode = new IHIS.Framework.XDisplayBox();
            this.btnBedButton = new IHIS.Framework.XButton();
            this.mbxEmergencyDetail = new IHIS.Framework.XMemoBox();
            this.cboEmergencyGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.btnAddEtcIpwon = new IHIS.Framework.XButton();
            this.dbxGubunName = new IHIS.Framework.XDisplayBox();
            this.fbxGubun = new IHIS.Framework.XFindBox();
            this.fwkGubun = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xLabel47 = new IHIS.Framework.XLabel();
            this.cboChojae = new IHIS.Framework.XDictComboBox();
            this.xLabel30 = new IHIS.Framework.XLabel();
            this.dbxJisiDoctorName = new IHIS.Framework.XDisplayBox();
            this.fbxJisiDoctor = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.emkGisanJaewonIlsu = new IHIS.Framework.XEditMask();
            this.dbxGwaName = new IHIS.Framework.XDisplayBox();
            this.dtpIpwonDate = new IHIS.Framework.XDatePicker();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.dtpGisanDate = new IHIS.Framework.XDatePicker();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.xLabel32 = new IHIS.Framework.XLabel();
            this.cboBabyStatus = new IHIS.Framework.XDictComboBox();
            this.cboIpwonRtn2 = new IHIS.Framework.XDictComboBox();
            this.fbxGwa = new IHIS.Framework.XFindBox();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.cbxIncuYN = new IHIS.Framework.XCheckBox();
            this.cboHoGrade1 = new IHIS.Framework.XDictComboBox();
            this.dbxDoctorName = new IHIS.Framework.XDisplayBox();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.txtIpwonTime = new IHIS.Framework.XEditMask();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cboIpwonType = new IHIS.Framework.XDictComboBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.grdINP1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell192 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.btnBoheomOpen = new IHIS.Framework.XButton();
            this.pnlGongbi = new IHIS.Framework.XPanel();
            this.grdINP1008 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.btnRegOUT0105 = new IHIS.Framework.XButton();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.grdOUT0106 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.btnRegOUT0106 = new IHIS.Framework.XButton();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.pnlINP1004 = new IHIS.Framework.XPanel();
            this.txtAge = new IHIS.Framework.XTextBox();
            this.txtBoninGubunName = new IHIS.Framework.XTextBox();
            this.gbxLive = new IHIS.Framework.XGroupBox();
            this.rbxLiveN = new IHIS.Framework.XRadioButton();
            this.rbxLiveY = new IHIS.Framework.XRadioButton();
            this.gbxWith = new IHIS.Framework.XGroupBox();
            this.rbxWithN = new IHIS.Framework.XRadioButton();
            this.rbxWithY = new IHIS.Framework.XRadioButton();
            this.lblLive = new IHIS.Framework.XLabel();
            this.lblWith = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpBirth = new IHIS.Framework.XDatePicker();
            this.txtName2 = new IHIS.Framework.XTextBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.fbxBoninGubun = new IHIS.Framework.XFindBox();
            this.txtSeq = new IHIS.Framework.XEditMask();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.txtBigo = new IHIS.Framework.XTextBox();
            this.txtName = new IHIS.Framework.XTextBox();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.grdINP1004 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.fbxZipCode1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.txtZipCode2 = new IHIS.Framework.XEditMask();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.fbxAddress1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.txtAddress2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.txtTel1 = new IHIS.Framework.XEditMask();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.txtTel2 = new IHIS.Framework.XEditMask();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.cboTelGubun = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.cboTelGubun2 = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel41 = new IHIS.Framework.XLabel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnInsert = new IHIS.Framework.XButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.pnlNUR0106 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.tvwBoheomInfo = new IHIS.Framework.XTreeView();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdOUT0103 = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.pnlPatientInfo = new IHIS.Framework.XPanel();
            this.btnChangeGubun = new IHIS.Framework.XButton();
            this.pbxDoubleTypeYN = new System.Windows.Forms.PictureBox();
            this.dtpLastCheckDate = new IHIS.Framework.XDatePicker();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.btnTest = new IHIS.Framework.XButton();
            this.pbxIpwonTrans = new System.Windows.Forms.PictureBox();
            this.layCommon = new IHIS.Framework.MultiLayout();
            this.layINP1002Update = new IHIS.Framework.MultiLayout();
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
            this.layInp1002 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.btnResend = new IHIS.Framework.XButton();
            this.layLastCheckDate = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.layCheckEctIpwon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.btnPrint = new IHIS.Framework.XButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlINP1001Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKaikei_HoDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).BeginInit();
            this.pnlGongbi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1008)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0106)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.pnlINP1004.SuspendLayout();
            this.gbxLive.SuspendLayout();
            this.gbxWith.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1004)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xPanel9.SuspendLayout();
            this.pnlNUR0106.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0103)).BeginInit();
            this.pnlPatientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDoubleTypeYN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIpwonTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layINP1002Update)).BeginInit();
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
            this.ImageList.Images.SetKeyName(12, "");
            this.ImageList.Images.SetKeyName(13, "로테이트.gif");
            this.ImageList.Images.SetKeyName(14, "전송_16.gif");
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(389, 539);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 34);
            this.btnList.TabIndex = 1;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // btnIpwonTrans
            // 
            this.btnIpwonTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIpwonTrans.ImageIndex = 8;
            this.btnIpwonTrans.ImageList = this.ImageList;
            this.btnIpwonTrans.Location = new System.Drawing.Point(102, 542);
            this.btnIpwonTrans.Name = "btnIpwonTrans";
            this.btnIpwonTrans.Size = new System.Drawing.Size(85, 28);
            this.btnIpwonTrans.TabIndex = 49;
            this.btnIpwonTrans.Text = "転入処理";
            this.btnIpwonTrans.Click += new System.EventHandler(this.btnIpwonTrans_Click);
            // 
            // btnRegDoubleType
            // 
            this.btnRegDoubleType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegDoubleType.ImageIndex = 1;
            this.btnRegDoubleType.ImageList = this.ImageList;
            this.btnRegDoubleType.Location = new System.Drawing.Point(701, 4);
            this.btnRegDoubleType.Name = "btnRegDoubleType";
            this.btnRegDoubleType.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnRegDoubleType.Size = new System.Drawing.Size(101, 28);
            this.btnRegDoubleType.TabIndex = 51;
            this.btnRegDoubleType.Text = "  複数保険登録";
            this.btnRegDoubleType.Visible = false;
            this.btnRegDoubleType.Click += new System.EventHandler(this.btnRegDoubleType_Click);
            // 
            // btnIpwonCancel
            // 
            this.btnIpwonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIpwonCancel.ImageIndex = 10;
            this.btnIpwonCancel.ImageList = this.ImageList;
            this.btnIpwonCancel.Location = new System.Drawing.Point(5, 542);
            this.btnIpwonCancel.Name = "btnIpwonCancel";
            this.btnIpwonCancel.Size = new System.Drawing.Size(95, 28);
            this.btnIpwonCancel.TabIndex = 52;
            this.btnIpwonCancel.Text = "入院取消";
            this.btnIpwonCancel.Click += new System.EventHandler(this.btnIpwonCancel_Click);
            // 
            // btnTransDate
            // 
            this.btnTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransDate.ImageIndex = 11;
            this.btnTransDate.ImageList = this.ImageList;
            this.btnTransDate.Location = new System.Drawing.Point(189, 542);
            this.btnTransDate.Name = "btnTransDate";
            this.btnTransDate.Size = new System.Drawing.Size(95, 28);
            this.btnTransDate.TabIndex = 53;
            this.btnTransDate.Text = "入院日変更";
            this.btnTransDate.Click += new System.EventHandler(this.btnTransDate_Click);
            // 
            // pnlINP1001Control
            // 
            this.pnlINP1001Control.Controls.Add(this.cboKaikei_HoDong);
            this.pnlINP1001Control.Controls.Add(this.cboKaikei_HoCode);
            this.pnlINP1001Control.Controls.Add(this.dbxBedNo);
            this.pnlINP1001Control.Controls.Add(this.dbxHoDong);
            this.pnlINP1001Control.Controls.Add(this.dbxHoCode);
            this.pnlINP1001Control.Controls.Add(this.btnBedButton);
            this.pnlINP1001Control.Controls.Add(this.mbxEmergencyDetail);
            this.pnlINP1001Control.Controls.Add(this.cboEmergencyGubun);
            this.pnlINP1001Control.Controls.Add(this.xLabel10);
            this.pnlINP1001Control.Controls.Add(this.btnAddEtcIpwon);
            this.pnlINP1001Control.Controls.Add(this.dbxGubunName);
            this.pnlINP1001Control.Controls.Add(this.fbxGubun);
            this.pnlINP1001Control.Controls.Add(this.xLabel47);
            this.pnlINP1001Control.Controls.Add(this.cboChojae);
            this.pnlINP1001Control.Controls.Add(this.xLabel30);
            this.pnlINP1001Control.Controls.Add(this.dbxJisiDoctorName);
            this.pnlINP1001Control.Controls.Add(this.fbxJisiDoctor);
            this.pnlINP1001Control.Controls.Add(this.xLabel27);
            this.pnlINP1001Control.Controls.Add(this.emkGisanJaewonIlsu);
            this.pnlINP1001Control.Controls.Add(this.dbxGwaName);
            this.pnlINP1001Control.Controls.Add(this.dtpIpwonDate);
            this.pnlINP1001Control.Controls.Add(this.xLabel4);
            this.pnlINP1001Control.Controls.Add(this.dtpGisanDate);
            this.pnlINP1001Control.Controls.Add(this.xLabel36);
            this.pnlINP1001Control.Controls.Add(this.xLabel32);
            this.pnlINP1001Control.Controls.Add(this.cboBabyStatus);
            this.pnlINP1001Control.Controls.Add(this.cboIpwonRtn2);
            this.pnlINP1001Control.Controls.Add(this.fbxGwa);
            this.pnlINP1001Control.Controls.Add(this.xLabel19);
            this.pnlINP1001Control.Controls.Add(this.xLabel25);
            this.pnlINP1001Control.Controls.Add(this.cbxIncuYN);
            this.pnlINP1001Control.Controls.Add(this.cboHoGrade1);
            this.pnlINP1001Control.Controls.Add(this.dbxDoctorName);
            this.pnlINP1001Control.Controls.Add(this.fbxDoctor);
            this.pnlINP1001Control.Controls.Add(this.txtIpwonTime);
            this.pnlINP1001Control.Controls.Add(this.xLabel6);
            this.pnlINP1001Control.Controls.Add(this.xLabel16);
            this.pnlINP1001Control.Controls.Add(this.xLabel18);
            this.pnlINP1001Control.Controls.Add(this.xLabel2);
            this.pnlINP1001Control.Controls.Add(this.cboIpwonType);
            this.pnlINP1001Control.Controls.Add(this.xLabel12);
            this.pnlINP1001Control.Controls.Add(this.xLabel11);
            this.pnlINP1001Control.Controls.Add(this.grdINP1001);
            this.pnlINP1001Control.Location = new System.Drawing.Point(3, 36);
            this.pnlINP1001Control.Name = "pnlINP1001Control";
            this.pnlINP1001Control.Size = new System.Drawing.Size(876, 102);
            this.pnlINP1001Control.TabIndex = 0;
            // 
            // cboKaikei_HoDong
            // 
            this.cboKaikei_HoDong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboKaikei_HoDong.Location = new System.Drawing.Point(751, 53);
            this.cboKaikei_HoDong.Name = "cboKaikei_HoDong";
            this.cboKaikei_HoDong.Size = new System.Drawing.Size(57, 21);
            this.cboKaikei_HoDong.TabIndex = 8;
            this.cboKaikei_HoDong.SelectedIndexChanged += new System.EventHandler(this.cboKaikei_HoDong_SelectedIndexChanged);
            // 
            // cboKaikei_HoCode
            // 
            this.cboKaikei_HoCode.Location = new System.Drawing.Point(809, 53);
            this.cboKaikei_HoCode.Name = "cboKaikei_HoCode";
            this.cboKaikei_HoCode.Size = new System.Drawing.Size(49, 21);
            this.cboKaikei_HoCode.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboKaikei_HoCode.TabIndex = 9;
            this.cboKaikei_HoCode.UserSQL = "SELECT HO_CODE, HO_CODE\r\n  FROM BAS0250 \r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND" +
                " HO_DONG = :f_kaikei_hodong";
            // 
            // dbxBedNo
            // 
            this.dbxBedNo.Location = new System.Drawing.Point(683, 54);
            this.dbxBedNo.Name = "dbxBedNo";
            this.dbxBedNo.Size = new System.Drawing.Size(28, 21);
            this.dbxBedNo.TabIndex = 99;
            this.dbxBedNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxHoDong
            // 
            this.dbxHoDong.Location = new System.Drawing.Point(575, 54);
            this.dbxHoDong.Name = "dbxHoDong";
            this.dbxHoDong.Size = new System.Drawing.Size(46, 21);
            this.dbxHoDong.TabIndex = 100;
            this.dbxHoDong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxHoCode
            // 
            this.dbxHoCode.Location = new System.Drawing.Point(627, 54);
            this.dbxHoCode.Name = "dbxHoCode";
            this.dbxHoCode.Size = new System.Drawing.Size(50, 21);
            this.dbxHoCode.TabIndex = 98;
            this.dbxHoCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBedButton
            // 
            this.btnBedButton.Image = ((System.Drawing.Image)(resources.GetObject("btnBedButton.Image")));
            this.btnBedButton.Location = new System.Drawing.Point(543, 53);
            this.btnBedButton.Name = "btnBedButton";
            this.btnBedButton.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnBedButton.Size = new System.Drawing.Size(26, 23);
            this.btnBedButton.TabIndex = 7;
            this.btnBedButton.Click += new System.EventHandler(this.btnBedButton_Click);
            // 
            // mbxEmergencyDetail
            // 
            this.mbxEmergencyDetail.DisplayMemoText = true;
            this.mbxEmergencyDetail.Enabled = false;
            this.mbxEmergencyDetail.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.mbxEmergencyDetail.Location = new System.Drawing.Point(456, 79);
            this.mbxEmergencyDetail.Name = "mbxEmergencyDetail";
            this.mbxEmergencyDetail.Size = new System.Drawing.Size(402, 23);
            this.mbxEmergencyDetail.TabIndex = 113;
            this.mbxEmergencyDetail.Visible = false;
            // 
            // cboEmergencyGubun
            // 
            this.cboEmergencyGubun.Location = new System.Drawing.Point(124, 79);
            this.cboEmergencyGubun.Name = "cboEmergencyGubun";
            this.cboEmergencyGubun.Size = new System.Drawing.Size(285, 21);
            this.cboEmergencyGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboEmergencyGubun.TabIndex = 112;
            this.cboEmergencyGubun.UserSQL = "  SELECT CODE, CODE_NAME\r\n    FROM BAS0102\r\n   WHERE HOSP_CODE = FN_ADM_LOAD_HOSP" +
                "_CODE()\r\n     AND CODE_TYPE =\'EMERGENCY_GUBUN\'\r\nORDER BY CODE";
            this.cboEmergencyGubun.SelectedValueChanged += new System.EventHandler(this.cboEmergencyGubun_SelectedValueChanged);
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel10.Location = new System.Drawing.Point(34, 79);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(84, 20);
            this.xLabel10.TabIndex = 111;
            this.xLabel10.Text = "救急加算";
            this.xLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddEtcIpwon
            // 
            this.btnAddEtcIpwon.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEtcIpwon.Image")));
            this.btnAddEtcIpwon.Location = new System.Drawing.Point(1001, 68);
            this.btnAddEtcIpwon.Name = "btnAddEtcIpwon";
            this.btnAddEtcIpwon.Size = new System.Drawing.Size(92, 22);
            this.btnAddEtcIpwon.TabIndex = 110;
            this.btnAddEtcIpwon.Text = "他院履歴";
            this.btnAddEtcIpwon.Click += new System.EventHandler(this.btnAddEtcIpwon_Click);
            // 
            // dbxGubunName
            // 
            this.dbxGubunName.Location = new System.Drawing.Point(908, 103);
            this.dbxGubunName.Name = "dbxGubunName";
            this.dbxGubunName.Size = new System.Drawing.Size(119, 21);
            this.dbxGubunName.TabIndex = 109;
            // 
            // fbxGubun
            // 
            this.fbxGubun.FindWorker = this.fwkGubun;
            this.fbxGubun.Location = new System.Drawing.Point(819, 104);
            this.fbxGubun.Name = "fbxGubun";
            this.fbxGubun.Size = new System.Drawing.Size(86, 20);
            this.fbxGubun.TabIndex = 108;
            this.fbxGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxGubun.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxGubun_FindSelected);
            // 
            // fwkGubun
            // 
            this.fwkGubun.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2,
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkGubun.InputSQL = resources.GetString("fwkGubun.InputSQL");
            this.fwkGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGubun_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "gubun";
            this.findColumnInfo1.ColWidth = 69;
            this.findColumnInfo1.HeaderText = "保険区分";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "gubun_name";
            this.findColumnInfo2.ColWidth = 122;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "保険名";
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "last_check_date";
            this.findColumnInfo3.ColType = IHIS.Framework.FindColType.Date;
            this.findColumnInfo3.HeaderText = "最終確認日";
            this.findColumnInfo3.Mask = "YYYY/MM/DD";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo4.ColName = "gongbi_yn";
            this.findColumnInfo4.ColWidth = 59;
            this.findColumnInfo4.HeaderText = "公費適用";
            // 
            // xLabel47
            // 
            this.xLabel47.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel47.EdgeRounding = false;
            this.xLabel47.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel47.Location = new System.Drawing.Point(496, 141);
            this.xLabel47.Name = "xLabel47";
            this.xLabel47.Size = new System.Drawing.Size(88, 20);
            this.xLabel47.TabIndex = 21;
            this.xLabel47.Text = "初 ・再診";
            this.xLabel47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel47.Visible = false;
            // 
            // cboChojae
            // 
            this.cboChojae.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChojae.Location = new System.Drawing.Point(586, 141);
            this.cboChojae.Name = "cboChojae";
            this.cboChojae.Size = new System.Drawing.Size(202, 20);
            this.cboChojae.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboChojae.TabIndex = 7;
            this.cboChojae.UserSQL = "SELECT CODE, CODE_NAME\r\n FROM BAS0102\r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() " +
                "\r\n  AND CODE_TYPE = \'CHOJAE\'";
            this.cboChojae.Visible = false;
            // 
            // xLabel30
            // 
            this.xLabel30.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel30.EdgeRounding = false;
            this.xLabel30.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel30.Location = new System.Drawing.Point(739, 102);
            this.xLabel30.Name = "xLabel30";
            this.xLabel30.Size = new System.Drawing.Size(100, 20);
            this.xLabel30.TabIndex = 106;
            this.xLabel30.Text = "保　　険";
            this.xLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel30.Visible = false;
            // 
            // dbxJisiDoctorName
            // 
            this.dbxJisiDoctorName.Location = new System.Drawing.Point(244, 54);
            this.dbxJisiDoctorName.Name = "dbxJisiDoctorName";
            this.dbxJisiDoctorName.Size = new System.Drawing.Size(165, 21);
            this.dbxJisiDoctorName.TabIndex = 104;
            this.dbxJisiDoctorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxJisiDoctor
            // 
            this.fbxJisiDoctor.ApplyByteLimit = true;
            this.fbxJisiDoctor.AutoTabDataSelected = true;
            this.fbxJisiDoctor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJisiDoctor.FindWorker = this.fwkCommon;
            this.fbxJisiDoctor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.fbxJisiDoctor.Location = new System.Drawing.Point(124, 54);
            this.fbxJisiDoctor.MaxLength = 20;
            this.fbxJisiDoctor.Name = "fbxJisiDoctor";
            this.fbxJisiDoctor.Size = new System.Drawing.Size(114, 20);
            this.fbxJisiDoctor.TabIndex = 6;
            this.fbxJisiDoctor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxJisiDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxJisiDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // xLabel27
            // 
            this.xLabel27.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel27.EdgeRounding = false;
            this.xLabel27.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel27.Location = new System.Drawing.Point(34, 54);
            this.xLabel27.Name = "xLabel27";
            this.xLabel27.Size = new System.Drawing.Size(84, 20);
            this.xLabel27.TabIndex = 15;
            this.xLabel27.Text = "指 示 医";
            this.xLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emkGisanJaewonIlsu
            // 
            this.emkGisanJaewonIlsu.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkGisanJaewonIlsu.Location = new System.Drawing.Point(902, 52);
            this.emkGisanJaewonIlsu.Name = "emkGisanJaewonIlsu";
            this.emkGisanJaewonIlsu.Size = new System.Drawing.Size(38, 20);
            this.emkGisanJaewonIlsu.TabIndex = 3;
            this.emkGisanJaewonIlsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emkGisanJaewonIlsu.Visible = false;
            // 
            // dbxGwaName
            // 
            this.dbxGwaName.Location = new System.Drawing.Point(244, 29);
            this.dbxGwaName.Name = "dbxGwaName";
            this.dbxGwaName.Size = new System.Drawing.Size(165, 21);
            this.dbxGwaName.TabIndex = 58;
            this.dbxGwaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpIpwonDate
            // 
            this.dtpIpwonDate.IsJapanYearType = true;
            this.dtpIpwonDate.Location = new System.Drawing.Point(124, 5);
            this.dtpIpwonDate.Name = "dtpIpwonDate";
            this.dtpIpwonDate.Size = new System.Drawing.Size(140, 20);
            this.dtpIpwonDate.TabIndex = 0;
            this.dtpIpwonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpIpwonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpIpwonDate_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Location = new System.Drawing.Point(456, 54);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(84, 20);
            this.xLabel4.TabIndex = 16;
            this.xLabel4.Text = "病室情報";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpGisanDate
            // 
            this.dtpGisanDate.IsJapanYearType = true;
            this.dtpGisanDate.Location = new System.Drawing.Point(885, 69);
            this.dtpGisanDate.Name = "dtpGisanDate";
            this.dtpGisanDate.Size = new System.Drawing.Size(114, 20);
            this.dtpGisanDate.TabIndex = 2;
            this.dtpGisanDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpGisanDate.Visible = false;
            // 
            // xLabel36
            // 
            this.xLabel36.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel36.EdgeRounding = false;
            this.xLabel36.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel36.Location = new System.Drawing.Point(866, 76);
            this.xLabel36.Name = "xLabel36";
            this.xLabel36.Size = new System.Drawing.Size(100, 20);
            this.xLabel36.TabIndex = 19;
            this.xLabel36.Text = "起 算 日";
            this.xLabel36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel36.Visible = false;
            // 
            // xLabel32
            // 
            this.xLabel32.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel32.EdgeRounding = false;
            this.xLabel32.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel32.Location = new System.Drawing.Point(441, 141);
            this.xLabel32.Name = "xLabel32";
            this.xLabel32.Size = new System.Drawing.Size(88, 20);
            this.xLabel32.TabIndex = 22;
            this.xLabel32.Text = "分娩状態";
            this.xLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel32.Visible = false;
            // 
            // cboBabyStatus
            // 
            this.cboBabyStatus.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBabyStatus.Location = new System.Drawing.Point(531, 141);
            this.cboBabyStatus.Name = "cboBabyStatus";
            this.cboBabyStatus.Size = new System.Drawing.Size(202, 20);
            this.cboBabyStatus.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboBabyStatus.TabIndex = 10;
            this.cboBabyStatus.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE =\'BABY_STATUS\'\r\n UNION \r\nSELECT \' \', \'ない\'\r\n  FROM DUAL\r\n ORD" +
                "ER BY 1";
            this.cboBabyStatus.Visible = false;
            // 
            // cboIpwonRtn2
            // 
            this.cboIpwonRtn2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIpwonRtn2.Location = new System.Drawing.Point(543, 5);
            this.cboIpwonRtn2.Name = "cboIpwonRtn2";
            this.cboIpwonRtn2.Size = new System.Drawing.Size(119, 20);
            this.cboIpwonRtn2.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboIpwonRtn2.TabIndex = 2;
            this.cboIpwonRtn2.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE    = FN_ADM_LOAD_HOSP_CO" +
                "DE()\r\n   AND CODE_TYPE = \'IPWON_RTN2\'";
            // 
            // fbxGwa
            // 
            this.fbxGwa.ApplyByteLimit = true;
            this.fbxGwa.AutoTabDataSelected = true;
            this.fbxGwa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxGwa.FindWorker = this.fwkCommon;
            this.fbxGwa.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.fbxGwa.Location = new System.Drawing.Point(124, 29);
            this.fbxGwa.MaxLength = 2;
            this.fbxGwa.Name = "fbxGwa";
            this.fbxGwa.Size = new System.Drawing.Size(114, 20);
            this.fbxGwa.TabIndex = 4;
            this.fbxGwa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xLabel19
            // 
            this.xLabel19.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel19.EdgeRounding = false;
            this.xLabel19.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel19.Location = new System.Drawing.Point(456, 5);
            this.xLabel19.Name = "xLabel19";
            this.xLabel19.Size = new System.Drawing.Size(84, 20);
            this.xLabel19.TabIndex = 17;
            this.xLabel19.Text = "入院経路";
            this.xLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel25
            // 
            this.xLabel25.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel25.EdgeRounding = false;
            this.xLabel25.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel25.Location = new System.Drawing.Point(34, 29);
            this.xLabel25.Name = "xLabel25";
            this.xLabel25.Size = new System.Drawing.Size(84, 20);
            this.xLabel25.TabIndex = 14;
            this.xLabel25.Text = "診 療 科";
            this.xLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxIncuYN
            // 
            this.cbxIncuYN.Location = new System.Drawing.Point(419, 143);
            this.cbxIncuYN.Name = "cbxIncuYN";
            this.cbxIncuYN.Size = new System.Drawing.Size(16, 18);
            this.cbxIncuYN.TabIndex = 12;
            this.cbxIncuYN.UseVisualStyleBackColor = false;
            this.cbxIncuYN.Visible = false;
            // 
            // cboHoGrade1
            // 
            this.cboHoGrade1.DropDownWidth = 160;
            this.cboHoGrade1.Location = new System.Drawing.Point(866, 57);
            this.cboHoGrade1.MaxDropDownItems = 15;
            this.cboHoGrade1.Name = "cboHoGrade1";
            this.cboHoGrade1.Size = new System.Drawing.Size(123, 21);
            this.cboHoGrade1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoGrade1.TabIndex = 24;
            this.cboHoGrade1.UserSQL = "SELECT A.HO_GRADE\r\n     , A.HO_GRADE_NAME\r\n  FROM BAS0251 A\r\n WHERE A.HOSP_CODE  " +
                "  = FN_ADM_LOAD_HOSP_CODE()\r\n   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.EN" +
                "D_DATE";
            this.cboHoGrade1.Visible = false;
            // 
            // dbxDoctorName
            // 
            this.dbxDoctorName.Location = new System.Drawing.Point(672, 29);
            this.dbxDoctorName.Name = "dbxDoctorName";
            this.dbxDoctorName.Size = new System.Drawing.Size(185, 21);
            this.dbxDoctorName.TabIndex = 37;
            this.dbxDoctorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.ApplyByteLimit = true;
            this.fbxDoctor.AutoTabDataSelected = true;
            this.fbxDoctor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxDoctor.FindWorker = this.fwkCommon;
            this.fbxDoctor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.fbxDoctor.Location = new System.Drawing.Point(543, 29);
            this.fbxDoctor.MaxLength = 20;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.Size = new System.Drawing.Size(119, 20);
            this.fbxDoctor.TabIndex = 5;
            this.fbxDoctor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // txtIpwonTime
            // 
            this.txtIpwonTime.EditMaskType = IHIS.Framework.MaskType.Time;
            this.txtIpwonTime.Location = new System.Drawing.Point(270, 4);
            this.txtIpwonTime.Mask = "HH:MI";
            this.txtIpwonTime.Name = "txtIpwonTime";
            this.txtIpwonTime.Size = new System.Drawing.Size(139, 20);
            this.txtIpwonTime.TabIndex = 1;
            this.txtIpwonTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(327, 141);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(88, 20);
            this.xLabel6.TabIndex = 23;
            this.xLabel6.Text = "保育器";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel6.Visible = false;
            // 
            // xLabel16
            // 
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel16.Location = new System.Drawing.Point(456, 29);
            this.xLabel16.Name = "xLabel16";
            this.xLabel16.Size = new System.Drawing.Size(84, 20);
            this.xLabel16.TabIndex = 20;
            this.xLabel16.Text = "主 治 医";
            this.xLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel18
            // 
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel18.Location = new System.Drawing.Point(34, 5);
            this.xLabel18.Name = "xLabel18";
            this.xLabel18.Size = new System.Drawing.Size(84, 20);
            this.xLabel18.TabIndex = 13;
            this.xLabel18.Text = "入 院 日";
            this.xLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel2.Image = ((System.Drawing.Image)(resources.GetObject("xLabel2.Image")));
            this.xLabel2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xLabel2.Location = new System.Drawing.Point(0, 0);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(30, 102);
            this.xLabel2.TabIndex = 0;
            this.xLabel2.Text = "入\n院\n情\n報";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboIpwonType
            // 
            this.cboIpwonType.Enabled = false;
            this.cboIpwonType.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIpwonType.Location = new System.Drawing.Point(739, 5);
            this.cboIpwonType.Name = "cboIpwonType";
            this.cboIpwonType.Protect = true;
            this.cboIpwonType.Size = new System.Drawing.Size(119, 20);
            this.cboIpwonType.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboIpwonType.TabIndex = 3;
            this.cboIpwonType.TabStop = false;
            this.cboIpwonType.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE = \'IPWON_TYPE\'\r\n ORDER BY CODE\r\n";
            this.cboIpwonType.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboIpwonType_DataValidating);
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel12.Location = new System.Drawing.Point(672, 5);
            this.xLabel12.Name = "xLabel12";
            this.xLabel12.Size = new System.Drawing.Size(64, 20);
            this.xLabel12.TabIndex = 18;
            this.xLabel12.Text = "入院タイプ";
            this.xLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel11
            // 
            this.xLabel11.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel11.Location = new System.Drawing.Point(717, 55);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(44, 19);
            this.xLabel11.TabIndex = 120;
            this.xLabel11.Text = "会計";
            // 
            // grdINP1001
            // 
            this.grdINP1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell58,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell75,
            this.xEditGridCell83,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell16,
            this.xEditGridCell97,
            this.xEditGridCell105,
            this.xEditGridCell167,
            this.xEditGridCell192,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell11,
            this.xEditGridCell17,
            this.xEditGridCell10,
            this.xEditGridCell78,
            this.xEditGridCell13,
            this.xEditGridCell4,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell84});
            this.grdINP1001.ColPerLine = 56;
            this.grdINP1001.Cols = 56;
            this.grdINP1001.ControlBinding = true;
            this.grdINP1001.FixedRows = 1;
            this.grdINP1001.HeaderHeights.Add(15);
            this.grdINP1001.Location = new System.Drawing.Point(863, 6);
            this.grdINP1001.Name = "grdINP1001";
            this.grdINP1001.QuerySQL = resources.GetString("grdINP1001.QuerySQL");
            this.grdINP1001.Rows = 2;
            this.grdINP1001.Size = new System.Drawing.Size(341, 73);
            this.grdINP1001.TabIndex = 9;
            this.grdINP1001.UseDefaultTransaction = false;
            this.grdINP1001.Visible = false;
            this.grdINP1001.ImeModeChanged += new System.EventHandler(this.grdINP1001_ImeModeChanged);
            this.grdINP1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdINP1001_RowFocusChanged);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "pkinp1001";
            this.xEditGridCell28.CellWidth = 81;
            this.xEditGridCell28.HeaderText = "pkinp1001";
            this.xEditGridCell28.IsUpdatable = false;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "bunho";
            this.xEditGridCell29.Col = 1;
            this.xEditGridCell29.HeaderText = "bunho";
            this.xEditGridCell29.IsNotNull = true;
            this.xEditGridCell29.IsUpdatable = false;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.BindControl = this.dtpIpwonDate;
            this.xEditGridCell30.CellName = "ipwon_date";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell30.Col = 2;
            this.xEditGridCell30.HeaderText = "ipwon_date";
            this.xEditGridCell30.IsNotNull = true;
            this.xEditGridCell30.IsUpdatable = false;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.BindControl = this.cboIpwonType;
            this.xEditGridCell32.CellName = "ipwon_type";
            this.xEditGridCell32.Col = 4;
            this.xEditGridCell32.HeaderText = "ipwon_type";
            this.xEditGridCell32.IsNotNull = true;
            this.xEditGridCell32.IsUpdatable = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.BindControl = this.txtIpwonTime;
            this.xEditGridCell33.CellName = "ipwon_time";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell33.Col = 5;
            this.xEditGridCell33.HeaderText = "ipwon_time";
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.Mask = "HH:MI";
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "suname";
            this.xEditGridCell35.Col = 7;
            this.xEditGridCell35.HeaderText = "suname";
            this.xEditGridCell35.IsUpdatable = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "birth";
            this.xEditGridCell36.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell36.Col = 8;
            this.xEditGridCell36.HeaderText = "birth";
            this.xEditGridCell36.IsUpdatable = false;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "sex";
            this.xEditGridCell37.Col = 9;
            this.xEditGridCell37.HeaderText = "sex";
            this.xEditGridCell37.IsUpdatable = false;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "ipwon_gwa";
            this.xEditGridCell38.Col = 10;
            this.xEditGridCell38.HeaderText = "ipwon_gwa";
            this.xEditGridCell38.IsUpdatable = false;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.BindControl = this.fbxGwa;
            this.xEditGridCell39.CellName = "gwa";
            this.xEditGridCell39.Col = 11;
            this.xEditGridCell39.HeaderText = "gwa";
            this.xEditGridCell39.IsNotNull = true;
            this.xEditGridCell39.IsUpdatable = false;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.BindControl = this.fbxDoctor;
            this.xEditGridCell40.CellLen = 20;
            this.xEditGridCell40.CellName = "doctor";
            this.xEditGridCell40.Col = 12;
            this.xEditGridCell40.HeaderText = "doctor";
            this.xEditGridCell40.IsNotNull = true;
            this.xEditGridCell40.IsUpdatable = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "resident";
            this.xEditGridCell41.Col = 13;
            this.xEditGridCell41.HeaderText = "resident";
            this.xEditGridCell41.IsNotNull = true;
            this.xEditGridCell41.IsUpdatable = false;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.BindControl = this.dbxHoCode;
            this.xEditGridCell42.CellName = "ho_code1";
            this.xEditGridCell42.Col = 14;
            this.xEditGridCell42.HeaderText = "ho_code1";
            this.xEditGridCell42.IsNotNull = true;
            this.xEditGridCell42.IsUpdatable = false;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "ho_dong1";
            this.xEditGridCell43.Col = 15;
            this.xEditGridCell43.HeaderText = "ho_dong1";
            this.xEditGridCell43.IsNotNull = true;
            this.xEditGridCell43.IsUpdatable = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "ho_code2";
            this.xEditGridCell46.Col = 18;
            this.xEditGridCell46.HeaderText = "ho_code2";
            this.xEditGridCell46.IsUpdatable = false;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "ho_dong2";
            this.xEditGridCell47.Col = 19;
            this.xEditGridCell47.HeaderText = "ho_dong2";
            this.xEditGridCell47.IsUpdatable = false;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.BindControl = this.cboIpwonRtn2;
            this.xEditGridCell51.CellName = "ipwon_rtn2";
            this.xEditGridCell51.Col = 23;
            this.xEditGridCell51.HeaderText = "ipwon_rtn2";
            this.xEditGridCell51.IsUpdatable = false;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.BindControl = this.cboChojae;
            this.xEditGridCell52.CellName = "chojae";
            this.xEditGridCell52.Col = 24;
            this.xEditGridCell52.HeaderText = "chojae";
            this.xEditGridCell52.IsUpdatable = false;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.BindControl = this.cboBabyStatus;
            this.xEditGridCell53.CellName = "baby_status";
            this.xEditGridCell53.Col = 25;
            this.xEditGridCell53.HeaderText = "baby_status";
            this.xEditGridCell53.IsUpdatable = false;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "inp_trans_yn";
            this.xEditGridCell55.Col = 27;
            this.xEditGridCell55.HeaderText = "inp_trans_yn";
            this.xEditGridCell55.IsUpdatable = false;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "fkout1001";
            this.xEditGridCell56.Col = 28;
            this.xEditGridCell56.HeaderText = "fkout1001";
            this.xEditGridCell56.IsUpdatable = false;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "jaewon_flag";
            this.xEditGridCell58.Col = 30;
            this.xEditGridCell58.HeaderText = "jaewon_flag";
            this.xEditGridCell58.IsUpdatable = false;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "toiwon_goji_yn";
            this.xEditGridCell62.Col = 34;
            this.xEditGridCell62.HeaderText = "toiwon_goji_yn";
            this.xEditGridCell62.IsUpdatable = false;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "toiwon_res_date";
            this.xEditGridCell63.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell63.Col = 35;
            this.xEditGridCell63.HeaderText = "toiwon_res_date";
            this.xEditGridCell63.IsUpdatable = false;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "ga_toiwon_date";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell64.Col = 36;
            this.xEditGridCell64.HeaderText = "ga_toiwon_date";
            this.xEditGridCell64.IsUpdatable = false;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "toiwon_date";
            this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell65.Col = 37;
            this.xEditGridCell65.HeaderText = "toiwon_date";
            this.xEditGridCell65.IsUpdatable = false;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "toiwon_time";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell66.Col = 38;
            this.xEditGridCell66.HeaderText = "toiwon_time";
            this.xEditGridCell66.IsUpdatable = false;
            this.xEditGridCell66.Mask = "HH:MI";
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "result";
            this.xEditGridCell68.Col = 40;
            this.xEditGridCell68.HeaderText = "result";
            this.xEditGridCell68.IsUpdatable = false;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "sigi_magam_yn";
            this.xEditGridCell69.Col = 41;
            this.xEditGridCell69.HeaderText = "sigi_magam_yn";
            this.xEditGridCell69.IsUpdatable = false;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "simsa_magam_yn";
            this.xEditGridCell70.Col = 42;
            this.xEditGridCell70.HeaderText = "simsa_magam_yn";
            this.xEditGridCell70.IsUpdatable = false;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "cancel_date";
            this.xEditGridCell71.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell71.Col = 43;
            this.xEditGridCell71.HeaderText = "cancel_date";
            this.xEditGridCell71.IsUpdatable = false;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "cancel_user";
            this.xEditGridCell72.Col = 44;
            this.xEditGridCell72.HeaderText = "cancel_user";
            this.xEditGridCell72.IsUpdatable = false;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "cancel_yn";
            this.xEditGridCell73.Col = 45;
            this.xEditGridCell73.HeaderText = "cancel_yn";
            this.xEditGridCell73.IsUpdatable = false;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "fkinp1003";
            this.xEditGridCell75.Col = 47;
            this.xEditGridCell75.HeaderText = "fkinp1003";
            this.xEditGridCell75.IsUpdatable = false;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "team";
            this.xEditGridCell83.Col = 3;
            this.xEditGridCell83.HeaderText = "team";
            this.xEditGridCell83.IsUpdatable = false;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "ipwon_gwa_name";
            this.xEditGridCell92.Col = 6;
            this.xEditGridCell92.HeaderText = "ipwon_gwa_name";
            this.xEditGridCell92.IsUpdatable = false;
            this.xEditGridCell92.IsUpdCol = false;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.BindControl = this.dbxGwaName;
            this.xEditGridCell93.CellName = "gwa_name";
            this.xEditGridCell93.Col = 16;
            this.xEditGridCell93.HeaderText = "gwa_name";
            this.xEditGridCell93.IsUpdatable = false;
            this.xEditGridCell93.IsUpdCol = false;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.BindControl = this.dbxDoctorName;
            this.xEditGridCell94.CellName = "doctor_name";
            this.xEditGridCell94.Col = 17;
            this.xEditGridCell94.HeaderText = "doctor_name";
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.IsUpdCol = false;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "resident_name";
            this.xEditGridCell95.Col = 20;
            this.xEditGridCell95.HeaderText = "resident_name";
            this.xEditGridCell95.IsUpdatable = false;
            this.xEditGridCell95.IsUpdCol = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.BindControl = this.dbxHoDong;
            this.xEditGridCell16.CellName = "ho_dong_name";
            this.xEditGridCell16.Col = 48;
            this.xEditGridCell16.HeaderText = "ho_dong_name";
            this.xEditGridCell16.IsUpdCol = false;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "doctor_special_yn";
            this.xEditGridCell97.Col = 21;
            this.xEditGridCell97.HeaderText = "doctor_special_yn";
            this.xEditGridCell97.IsUpdatable = false;
            this.xEditGridCell97.IsUpdCol = false;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.BindControl = this.dtpGisanDate;
            this.xEditGridCell105.CellName = "gisan_ipwon_date";
            this.xEditGridCell105.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell105.Col = 22;
            this.xEditGridCell105.HeaderText = "gisan_ipwon_date";
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.BindControl = this.dbxBedNo;
            this.xEditGridCell167.CellName = "bed_no";
            this.xEditGridCell167.Col = 26;
            this.xEditGridCell167.HeaderText = "bed_no";
            this.xEditGridCell167.IsUpdatable = false;
            // 
            // xEditGridCell192
            // 
            this.xEditGridCell192.BindControl = this.emkGisanJaewonIlsu;
            this.xEditGridCell192.CellName = "gisan_jaewon_ilsu";
            this.xEditGridCell192.Col = 29;
            this.xEditGridCell192.HeaderText = "gisan_jaewon_ilsu";
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.fbxJisiDoctor;
            this.xEditGridCell18.CellName = "jisi_doctor";
            this.xEditGridCell18.Col = 31;
            this.xEditGridCell18.HeaderText = "jisi_doctor";
            this.xEditGridCell18.IsUpdatable = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.BindControl = this.dbxJisiDoctorName;
            this.xEditGridCell19.CellName = "jisi_doctor_name";
            this.xEditGridCell19.Col = 32;
            this.xEditGridCell19.HeaderText = "jisi_doctor_name";
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsUpdCol = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "ipwon_type_name";
            this.xEditGridCell11.Col = 33;
            this.xEditGridCell11.HeaderText = "ipwon_type_name";
            this.xEditGridCell11.IsUpdCol = false;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "check_trans_yn";
            this.xEditGridCell17.Col = 49;
            this.xEditGridCell17.HeaderText = "check_trans_yn";
            this.xEditGridCell17.IsUpdCol = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "double_type_exist_yn";
            this.xEditGridCell10.Col = 39;
            this.xEditGridCell10.HeaderText = "double_type_exist_yn";
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "retrieve_yn";
            this.xEditGridCell78.Col = 46;
            this.xEditGridCell78.HeaderText = "retrieve_yn";
            this.xEditGridCell78.IsUpdatable = false;
            this.xEditGridCell78.IsUpdCol = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.BindControl = this.fbxGubun;
            this.xEditGridCell13.CellName = "gubun";
            this.xEditGridCell13.Col = 50;
            this.xEditGridCell13.HeaderText = "gubun";
            this.xEditGridCell13.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.cboHoGrade1;
            this.xEditGridCell4.CellName = "ho_grade1";
            this.xEditGridCell4.Col = 51;
            this.xEditGridCell4.HeaderText = "ho_grade1";
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.BindControl = this.cboEmergencyGubun;
            this.xEditGridCell79.CellName = "emergency_gubun";
            this.xEditGridCell79.Col = 52;
            this.xEditGridCell79.HeaderText = "emergency_gubun";
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.BindControl = this.mbxEmergencyDetail;
            this.xEditGridCell80.CellLen = 250;
            this.xEditGridCell80.CellName = "emergency_detail";
            this.xEditGridCell80.Col = 53;
            this.xEditGridCell80.HeaderText = "emergency_detail";
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.BindControl = this.cboKaikei_HoDong;
            this.xEditGridCell81.CellName = "kaikei_hodong";
            this.xEditGridCell81.Col = 54;
            this.xEditGridCell81.HeaderText = "kaikei_hodong";
            this.xEditGridCell81.IsUpdatable = false;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.BindControl = this.cboKaikei_HoCode;
            this.xEditGridCell82.CellName = "kaikei_hocode";
            this.xEditGridCell82.Col = 55;
            this.xEditGridCell82.HeaderText = "kaikei_hocode";
            this.xEditGridCell82.IsUpdatable = false;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "changed_yn";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.HeaderText = "changed_yn";
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // btnBoheomOpen
            // 
            this.btnBoheomOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnBoheomOpen.Image")));
            this.btnBoheomOpen.Location = new System.Drawing.Point(753, 4);
            this.btnBoheomOpen.Name = "btnBoheomOpen";
            this.btnBoheomOpen.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnBoheomOpen.Size = new System.Drawing.Size(25, 22);
            this.btnBoheomOpen.TabIndex = 107;
            this.btnBoheomOpen.Click += new System.EventHandler(this.btnBoheomOpen_Click);
            // 
            // pnlGongbi
            // 
            this.pnlGongbi.Controls.Add(this.grdINP1008);
            this.pnlGongbi.Controls.Add(this.btnRegOUT0105);
            this.pnlGongbi.Controls.Add(this.xLabel7);
            this.pnlGongbi.Location = new System.Drawing.Point(866, 8);
            this.pnlGongbi.Name = "pnlGongbi";
            this.pnlGongbi.Size = new System.Drawing.Size(128, 120);
            this.pnlGongbi.TabIndex = 6;
            this.pnlGongbi.Visible = false;
            // 
            // grdINP1008
            // 
            this.grdINP1008.CallerID = '4';
            this.grdINP1008.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell7,
            this.xEditGridCell12});
            this.grdINP1008.ColPerLine = 4;
            this.grdINP1008.Cols = 4;
            this.grdINP1008.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1008.FixedRows = 1;
            this.grdINP1008.HeaderHeights.Add(28);
            this.grdINP1008.Location = new System.Drawing.Point(30, 0);
            this.grdINP1008.Name = "grdINP1008";
            this.grdINP1008.QuerySQL = resources.GetString("grdINP1008.QuerySQL");
            this.grdINP1008.Rows = 2;
            this.grdINP1008.Size = new System.Drawing.Size(98, 120);
            this.grdINP1008.TabIndex = 8;
            this.grdINP1008.ToolTipActive = true;
            this.grdINP1008.UseDefaultTransaction = false;
            this.grdINP1008.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdINP1008_ItemValueChanging);
            this.grdINP1008.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdINP1008_GridColumnProtectModify);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "check_yn";
            this.xEditGridCell1.CellWidth = 29;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "選択";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "gongbi_code";
            this.xEditGridCell2.CellWidth = 48;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "公費";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "gongbi_name";
            this.xEditGridCell3.CellWidth = 290;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "公費名";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "fkinp1002";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "bunho";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gubun";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gubun_name";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "gubun_ipwon_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "gubun_ipwon_date";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "priority";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.CellWidth = 29;
            this.xEditGridCell12.Col = 1;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "順位";
            // 
            // btnRegOUT0105
            // 
            this.btnRegOUT0105.Image = ((System.Drawing.Image)(resources.GetObject("btnRegOUT0105.Image")));
            this.btnRegOUT0105.Location = new System.Drawing.Point(3, 125);
            this.btnRegOUT0105.Name = "btnRegOUT0105";
            this.btnRegOUT0105.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRegOUT0105.Size = new System.Drawing.Size(24, 24);
            this.btnRegOUT0105.TabIndex = 9;
            this.btnRegOUT0105.Click += new System.EventHandler(this.btnRegOUT0105_Click);
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.xLabel7.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel7.Image = ((System.Drawing.Image)(resources.GetObject("xLabel7.Image")));
            this.xLabel7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xLabel7.ImageIndex = 6;
            this.xLabel7.ImageList = this.ImageList;
            this.xLabel7.Location = new System.Drawing.Point(0, 0);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(30, 120);
            this.xLabel7.TabIndex = 7;
            this.xLabel7.Text = "公\n費\n情\n報";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdOUT0106
            // 
            this.grdOUT0106.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27});
            this.grdOUT0106.ColPerLine = 1;
            this.grdOUT0106.Cols = 1;
            this.grdOUT0106.FixedRows = 1;
            this.grdOUT0106.HeaderHeights.Add(21);
            this.grdOUT0106.Location = new System.Drawing.Point(33, 0);
            this.grdOUT0106.Name = "grdOUT0106";
            this.grdOUT0106.QuerySQL = resources.GetString("grdOUT0106.QuerySQL");
            this.grdOUT0106.ReadOnly = true;
            this.grdOUT0106.Rows = 2;
            this.grdOUT0106.Size = new System.Drawing.Size(333, 184);
            this.grdOUT0106.TabIndex = 4;
            this.grdOUT0106.ToolTipActive = true;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "seq";
            this.xEditGridCell25.CellWidth = 37;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "順序";
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "comment";
            this.xEditGridCell26.CellWidth = 309;
            this.xEditGridCell26.DisplayMemoText = true;
            this.xEditGridCell26.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell26.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell26.HeaderText = "特記事項";
            this.xEditGridCell26.IsReadOnly = true;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "bunho";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // btnRegOUT0106
            // 
            this.btnRegOUT0106.Image = ((System.Drawing.Image)(resources.GetObject("btnRegOUT0106.Image")));
            this.btnRegOUT0106.Location = new System.Drawing.Point(3, 146);
            this.btnRegOUT0106.Name = "btnRegOUT0106";
            this.btnRegOUT0106.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRegOUT0106.Size = new System.Drawing.Size(24, 24);
            this.btnRegOUT0106.TabIndex = 2;
            this.btnRegOUT0106.Click += new System.EventHandler(this.btnRegOUT0106_Click);
            // 
            // xPanel5
            // 
            this.xPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel5.Controls.Add(this.xPanel3);
            this.xPanel5.Controls.Add(this.xPanel9);
            this.xPanel5.Location = new System.Drawing.Point(4, 139);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(875, 400);
            this.xPanel5.TabIndex = 2;
            // 
            // xPanel3
            // 
            this.xPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel3.Controls.Add(this.pnlINP1004);
            this.xPanel3.Controls.Add(this.grdINP1004);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Controls.Add(this.xPanel6);
            this.xPanel3.Location = new System.Drawing.Point(-1, 187);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(875, 210);
            this.xPanel3.TabIndex = 168;
            // 
            // pnlINP1004
            // 
            this.pnlINP1004.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlINP1004.Controls.Add(this.txtAge);
            this.pnlINP1004.Controls.Add(this.txtBoninGubunName);
            this.pnlINP1004.Controls.Add(this.gbxLive);
            this.pnlINP1004.Controls.Add(this.gbxWith);
            this.pnlINP1004.Controls.Add(this.lblLive);
            this.pnlINP1004.Controls.Add(this.lblWith);
            this.pnlINP1004.Controls.Add(this.xLabel5);
            this.pnlINP1004.Controls.Add(this.xLabel3);
            this.pnlINP1004.Controls.Add(this.dtpBirth);
            this.pnlINP1004.Controls.Add(this.txtName2);
            this.pnlINP1004.Controls.Add(this.xLabel8);
            this.pnlINP1004.Controls.Add(this.fbxBoninGubun);
            this.pnlINP1004.Controls.Add(this.txtSeq);
            this.pnlINP1004.Controls.Add(this.xLabel21);
            this.pnlINP1004.Controls.Add(this.txtBigo);
            this.pnlINP1004.Controls.Add(this.txtName);
            this.pnlINP1004.Controls.Add(this.xLabel22);
            this.pnlINP1004.Controls.Add(this.xLabel23);
            this.pnlINP1004.Controls.Add(this.xLabel29);
            this.pnlINP1004.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlINP1004.Location = new System.Drawing.Point(579, 28);
            this.pnlINP1004.Name = "pnlINP1004";
            this.pnlINP1004.Size = new System.Drawing.Size(294, 180);
            this.pnlINP1004.TabIndex = 51;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(212, 77);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(33, 20);
            this.txtAge.TabIndex = 115;
            // 
            // txtBoninGubunName
            // 
            this.txtBoninGubunName.Location = new System.Drawing.Point(157, 52);
            this.txtBoninGubunName.Name = "txtBoninGubunName";
            this.txtBoninGubunName.Size = new System.Drawing.Size(100, 20);
            this.txtBoninGubunName.TabIndex = 114;
            // 
            // gbxLive
            // 
            this.gbxLive.Controls.Add(this.rbxLiveN);
            this.gbxLive.Controls.Add(this.rbxLiveY);
            this.gbxLive.Location = new System.Drawing.Point(90, 122);
            this.gbxLive.Name = "gbxLive";
            this.gbxLive.Size = new System.Drawing.Size(131, 30);
            this.gbxLive.TabIndex = 5;
            this.gbxLive.TabStop = false;
            // 
            // rbxLiveN
            // 
            this.rbxLiveN.AutoSize = true;
            this.rbxLiveN.CheckedValue = "N";
            this.rbxLiveN.Location = new System.Drawing.Point(72, 9);
            this.rbxLiveN.Name = "rbxLiveN";
            this.rbxLiveN.Size = new System.Drawing.Size(51, 17);
            this.rbxLiveN.TabIndex = 1;
            this.rbxLiveN.TabStop = true;
            this.rbxLiveN.Text = "死亡";
            this.rbxLiveN.UseVisualStyleBackColor = true;
            // 
            // rbxLiveY
            // 
            this.rbxLiveY.AutoSize = true;
            this.rbxLiveY.Checked = true;
            this.rbxLiveY.Location = new System.Drawing.Point(14, 9);
            this.rbxLiveY.Name = "rbxLiveY";
            this.rbxLiveY.Size = new System.Drawing.Size(51, 17);
            this.rbxLiveY.TabIndex = 0;
            this.rbxLiveY.TabStop = true;
            this.rbxLiveY.Text = "生存";
            this.rbxLiveY.UseVisualStyleBackColor = true;
            // 
            // gbxWith
            // 
            this.gbxWith.Controls.Add(this.rbxWithN);
            this.gbxWith.Controls.Add(this.rbxWithY);
            this.gbxWith.Location = new System.Drawing.Point(90, 97);
            this.gbxWith.Name = "gbxWith";
            this.gbxWith.Size = new System.Drawing.Size(131, 30);
            this.gbxWith.TabIndex = 4;
            this.gbxWith.TabStop = false;
            // 
            // rbxWithN
            // 
            this.rbxWithN.AutoSize = true;
            this.rbxWithN.CheckedValue = "N";
            this.rbxWithN.Location = new System.Drawing.Point(72, 9);
            this.rbxWithN.Name = "rbxWithN";
            this.rbxWithN.Size = new System.Drawing.Size(57, 17);
            this.rbxWithN.TabIndex = 1;
            this.rbxWithN.Text = "いいえ";
            this.rbxWithN.UseVisualStyleBackColor = true;
            // 
            // rbxWithY
            // 
            this.rbxWithY.AutoSize = true;
            this.rbxWithY.Checked = true;
            this.rbxWithY.Location = new System.Drawing.Point(15, 9);
            this.rbxWithY.Name = "rbxWithY";
            this.rbxWithY.Size = new System.Drawing.Size(47, 17);
            this.rbxWithY.TabIndex = 0;
            this.rbxWithY.TabStop = true;
            this.rbxWithY.Text = "はい";
            this.rbxWithY.UseVisualStyleBackColor = true;
            // 
            // lblLive
            // 
            this.lblLive.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblLive.EdgeRounding = false;
            this.lblLive.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblLive.Location = new System.Drawing.Point(2, 127);
            this.lblLive.Name = "lblLive";
            this.lblLive.Size = new System.Drawing.Size(82, 20);
            this.lblLive.TabIndex = 111;
            this.lblLive.Text = "状　　態";
            this.lblLive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWith
            // 
            this.lblWith.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblWith.EdgeRounding = false;
            this.lblWith.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblWith.Location = new System.Drawing.Point(2, 102);
            this.lblWith.Name = "lblWith";
            this.lblWith.Size = new System.Drawing.Size(82, 20);
            this.lblWith.TabIndex = 110;
            this.lblWith.Text = "同　　居";
            this.lblWith.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel5
            // 
            this.xLabel5.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel5.Location = new System.Drawing.Point(246, 78);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(33, 19);
            this.xLabel5.TabIndex = 108;
            this.xLabel5.Text = "才";
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Location = new System.Drawing.Point(2, 77);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(82, 20);
            this.xLabel3.TabIndex = 106;
            this.xLabel3.Text = "生年月日";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpBirth
            // 
            this.dtpBirth.IsJapanYearType = true;
            this.dtpBirth.Location = new System.Drawing.Point(87, 77);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(116, 20);
            this.dtpBirth.TabIndex = 3;
            this.dtpBirth.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpBirth_DataValidating_1);
            // 
            // txtName2
            // 
            this.txtName2.ApplyByteLimit = true;
            this.txtName2.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtName2.Location = new System.Drawing.Point(87, 2);
            this.txtName2.MaxLength = 20;
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(116, 20);
            this.txtName2.TabIndex = 0;
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Location = new System.Drawing.Point(2, 2);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(82, 20);
            this.xLabel8.TabIndex = 103;
            this.xLabel8.Text = "氏名(ｶﾅ)";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxBoninGubun
            // 
            this.fbxBoninGubun.ApplyByteLimit = true;
            this.fbxBoninGubun.FindWorker = this.fwkCommon;
            this.fbxBoninGubun.Location = new System.Drawing.Point(87, 52);
            this.fbxBoninGubun.MaxLength = 1;
            this.fbxBoninGubun.Name = "fbxBoninGubun";
            this.fbxBoninGubun.Size = new System.Drawing.Size(66, 20);
            this.fbxBoninGubun.TabIndex = 2;
            this.fbxBoninGubun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxBoninGubun.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxBoninGubun_FindSelected);
            this.fbxBoninGubun.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // txtSeq
            // 
            this.txtSeq.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtSeq.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtSeq.GeneralNumberFormat = true;
            this.txtSeq.Location = new System.Drawing.Point(217, 25);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.ReadOnly = true;
            this.txtSeq.Size = new System.Drawing.Size(40, 20);
            this.txtSeq.TabIndex = 1;
            this.txtSeq.TabStop = false;
            this.txtSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSeq.Visible = false;
            // 
            // xLabel21
            // 
            this.xLabel21.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel21.EdgeRounding = false;
            this.xLabel21.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel21.Location = new System.Drawing.Point(207, 2);
            this.xLabel21.Name = "xLabel21";
            this.xLabel21.Size = new System.Drawing.Size(50, 20);
            this.xLabel21.TabIndex = 89;
            this.xLabel21.Text = "順位";
            this.xLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel21.Visible = false;
            // 
            // txtBigo
            // 
            this.txtBigo.ApplyByteLimit = true;
            this.txtBigo.Location = new System.Drawing.Point(87, 152);
            this.txtBigo.MaxLength = 80;
            this.txtBigo.Name = "txtBigo";
            this.txtBigo.Size = new System.Drawing.Size(203, 20);
            this.txtBigo.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.ApplyByteLimit = true;
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtName.Location = new System.Drawing.Point(87, 27);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(116, 20);
            this.txtName.TabIndex = 1;
            // 
            // xLabel22
            // 
            this.xLabel22.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel22.EdgeRounding = false;
            this.xLabel22.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel22.Location = new System.Drawing.Point(2, 152);
            this.xLabel22.Name = "xLabel22";
            this.xLabel22.Size = new System.Drawing.Size(82, 20);
            this.xLabel22.TabIndex = 86;
            this.xLabel22.Text = "備　　考";
            this.xLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel23
            // 
            this.xLabel23.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel23.EdgeRounding = false;
            this.xLabel23.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel23.Location = new System.Drawing.Point(2, 52);
            this.xLabel23.Name = "xLabel23";
            this.xLabel23.Size = new System.Drawing.Size(82, 20);
            this.xLabel23.TabIndex = 85;
            this.xLabel23.Text = "続　　柄";
            this.xLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel29
            // 
            this.xLabel29.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel29.EdgeRounding = false;
            this.xLabel29.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel29.Location = new System.Drawing.Point(2, 27);
            this.xLabel29.Name = "xLabel29";
            this.xLabel29.Size = new System.Drawing.Size(82, 20);
            this.xLabel29.TabIndex = 82;
            this.xLabel29.Text = "氏名(漢字)";
            this.xLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdINP1004
            // 
            this.grdINP1004.CallerID = '3';
            this.grdINP1004.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell31,
            this.xEditGridCell34,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell48,
            this.xEditGridCell180,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell54,
            this.xEditGridCell57,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell67,
            this.xEditGridCell74,
            this.xEditGridCell76,
            this.xEditGridCell77});
            this.grdINP1004.ColPerLine = 7;
            this.grdINP1004.Cols = 7;
            this.grdINP1004.ControlBinding = true;
            this.grdINP1004.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdINP1004.FixedRows = 1;
            this.grdINP1004.HeaderHeights.Add(21);
            this.grdINP1004.Location = new System.Drawing.Point(0, 28);
            this.grdINP1004.Name = "grdINP1004";
            this.grdINP1004.QuerySQL = resources.GetString("grdINP1004.QuerySQL");
            this.grdINP1004.Rows = 2;
            this.grdINP1004.Size = new System.Drawing.Size(571, 180);
            this.grdINP1004.TabIndex = 0;
            this.grdINP1004.UseDefaultTransaction = false;
            this.grdINP1004.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdINP1004_QueryEnd);
            this.grdINP1004.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1004_QueryStarting);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "priority";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell14.CellWidth = 30;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "順位";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "bunho";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "bunho";
            this.xEditGridCell15.IsNotNull = true;
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.BindControl = this.txtName;
            this.xEditGridCell20.CellLen = 20;
            this.xEditGridCell20.CellName = "name";
            this.xEditGridCell20.CellWidth = 104;
            this.xEditGridCell20.Col = 1;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell20.HeaderText = "氏名";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.BindControl = this.fbxZipCode1;
            this.xEditGridCell21.CellLen = 3;
            this.xEditGridCell21.CellName = "zip_code1";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "zip_code1";
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // fbxZipCode1
            // 
            this.fbxZipCode1.Location = new System.Drawing.Point(45, 9);
            this.fbxZipCode1.MaxLength = 3;
            this.fbxZipCode1.Name = "fbxZipCode1";
            this.fbxZipCode1.Size = new System.Drawing.Size(58, 20);
            this.fbxZipCode1.TabIndex = 2;
            this.fbxZipCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxZipCode1.Visible = false;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.BindControl = this.txtZipCode2;
            this.xEditGridCell22.CellLen = 4;
            this.xEditGridCell22.CellName = "zip_code2";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "zip_code2";
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // txtZipCode2
            // 
            this.txtZipCode2.Location = new System.Drawing.Point(115, 9);
            this.txtZipCode2.MaxLength = 4;
            this.txtZipCode2.Name = "txtZipCode2";
            this.txtZipCode2.Size = new System.Drawing.Size(52, 20);
            this.txtZipCode2.TabIndex = 3;
            this.txtZipCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtZipCode2.Visible = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.BindControl = this.fbxAddress1;
            this.xEditGridCell23.CellLen = 60;
            this.xEditGridCell23.CellName = "address1";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "address1";
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // fbxAddress1
            // 
            this.fbxAddress1.ApplyByteLimit = true;
            this.fbxAddress1.Location = new System.Drawing.Point(174, 9);
            this.fbxAddress1.MaxLength = 60;
            this.fbxAddress1.Name = "fbxAddress1";
            this.fbxAddress1.Size = new System.Drawing.Size(161, 20);
            this.fbxAddress1.TabIndex = 4;
            this.fbxAddress1.Visible = false;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.BindControl = this.txtAddress2;
            this.xEditGridCell24.CellLen = 40;
            this.xEditGridCell24.CellName = "address2";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "address2";
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // txtAddress2
            // 
            this.txtAddress2.ApplyByteLimit = true;
            this.txtAddress2.Location = new System.Drawing.Point(45, 32);
            this.txtAddress2.MaxLength = 40;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(290, 20);
            this.txtAddress2.TabIndex = 5;
            this.txtAddress2.Visible = false;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.BindControl = this.txtTel1;
            this.xEditGridCell31.CellLen = 15;
            this.xEditGridCell31.CellName = "tel1";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.HeaderText = "tel1";
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // txtTel1
            // 
            this.txtTel1.Location = new System.Drawing.Point(95, 56);
            this.txtTel1.MaxLength = 15;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(182, 20);
            this.txtTel1.TabIndex = 6;
            this.txtTel1.Visible = false;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.BindControl = this.txtTel2;
            this.xEditGridCell34.CellLen = 15;
            this.xEditGridCell34.CellName = "tel2";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.HeaderText = "tel2";
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // txtTel2
            // 
            this.txtTel2.Location = new System.Drawing.Point(95, 80);
            this.txtTel2.MaxLength = 15;
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(182, 20);
            this.txtTel2.TabIndex = 8;
            this.txtTel2.Visible = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "tel3";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.HeaderText = "tel3";
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AppendReservedMemoText = true;
            this.xEditGridCell45.BindControl = this.txtBigo;
            this.xEditGridCell45.CellName = "bigo";
            this.xEditGridCell45.CellWidth = 117;
            this.xEditGridCell45.Col = 6;
            this.xEditGridCell45.DisplayMemoText = true;
            this.xEditGridCell45.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell45.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell45.HeaderText = "備考";
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.BindControl = this.fbxBoninGubun;
            this.xEditGridCell48.CellLen = 1;
            this.xEditGridCell48.CellName = "bonin_gubun";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.HeaderText = "bonin_gubun";
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.BindControl = this.txtBoninGubunName;
            this.xEditGridCell180.CellLen = 80;
            this.xEditGridCell180.CellName = "bonin_gubun_name";
            this.xEditGridCell180.CellWidth = 60;
            this.xEditGridCell180.Col = 2;
            this.xEditGridCell180.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell180.HeaderText = "続柄";
            this.xEditGridCell180.IsUpdCol = false;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "old_seq";
            this.xEditGridCell49.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "old_seq";
            this.xEditGridCell49.IsUpdCol = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.BindControl = this.cboTelGubun;
            this.xEditGridCell50.CellName = "tel_gubun";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "tel_gubun";
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // cboTelGubun
            // 
            this.cboTelGubun.Location = new System.Drawing.Point(279, 55);
            this.cboTelGubun.Name = "cboTelGubun";
            this.cboTelGubun.Size = new System.Drawing.Size(56, 21);
            this.cboTelGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTelGubun.TabIndex = 7;
            this.cboTelGubun.Visible = false;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.BindControl = this.cboTelGubun2;
            this.xEditGridCell54.CellName = "tel_gubun2";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.HeaderText = "tel_gubun2";
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // cboTelGubun2
            // 
            this.cboTelGubun2.Location = new System.Drawing.Point(279, 79);
            this.cboTelGubun2.Name = "cboTelGubun2";
            this.cboTelGubun2.Size = new System.Drawing.Size(56, 21);
            this.cboTelGubun2.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTelGubun2.TabIndex = 9;
            this.cboTelGubun2.Visible = false;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "tel_gubun3";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.HeaderText = "tel_gubun3";
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellLen = 1;
            this.xEditGridCell59.CellName = "retrieve_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.HeaderText = "retrieve_yn";
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.BindControl = this.txtName2;
            this.xEditGridCell60.CellName = "name2";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.HeaderText = "name2";
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.BindControl = this.dtpBirth;
            this.xEditGridCell61.CellName = "birth";
            this.xEditGridCell61.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell61.CellWidth = 63;
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell61.HeaderText = "誕生日";
            this.xEditGridCell61.IsJapanYearType = true;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "age";
            this.xEditGridCell67.CellWidth = 59;
            this.xEditGridCell67.Col = 3;
            this.xEditGridCell67.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell67.HeaderText = "年齢";
            this.xEditGridCell67.IsReadOnly = true;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.BindControl = this.gbxWith;
            this.xEditGridCell74.CellName = "with_yn";
            this.xEditGridCell74.CellWidth = 71;
            this.xEditGridCell74.Col = 4;
            this.xEditGridCell74.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell74.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell74.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell74.HeaderText = "同居";
            this.xEditGridCell74.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "―";
            this.xComboItem1.ValueItem = "N";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "○";
            this.xComboItem2.ValueItem = "Y";
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.BindControl = this.gbxLive;
            this.xEditGridCell76.CellName = "live_yn";
            this.xEditGridCell76.CellWidth = 111;
            this.xEditGridCell76.Col = 5;
            this.xEditGridCell76.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell76.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell76.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell76.HeaderText = "状態";
            this.xEditGridCell76.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "　";
            this.xComboItem3.ValueItem = "Y";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "●";
            this.xComboItem4.ValueItem = "N";
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "seq";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.HeaderText = "seq";
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xLabel26);
            this.xPanel4.Controls.Add(this.xLabel24);
            this.xPanel4.Controls.Add(this.xLabel17);
            this.xPanel4.Controls.Add(this.fbxZipCode1);
            this.xPanel4.Controls.Add(this.xLabel41);
            this.xPanel4.Controls.Add(this.txtZipCode2);
            this.xPanel4.Controls.Add(this.cboTelGubun2);
            this.xPanel4.Controls.Add(this.fbxAddress1);
            this.xPanel4.Controls.Add(this.cboTelGubun);
            this.xPanel4.Controls.Add(this.txtAddress2);
            this.xPanel4.Controls.Add(this.txtTel1);
            this.xPanel4.Controls.Add(this.txtTel2);
            this.xPanel4.Location = new System.Drawing.Point(435, 249);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(354, 134);
            this.xPanel4.TabIndex = 105;
            this.xPanel4.Visible = false;
            // 
            // xLabel26
            // 
            this.xLabel26.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel26.EdgeRounding = false;
            this.xLabel26.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel26.Location = new System.Drawing.Point(7, 9);
            this.xLabel26.Name = "xLabel26";
            this.xLabel26.Size = new System.Drawing.Size(36, 42);
            this.xLabel26.TabIndex = 83;
            this.xLabel26.Text = "住所";
            this.xLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel26.Visible = false;
            // 
            // xLabel24
            // 
            this.xLabel24.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel24.EdgeRounding = false;
            this.xLabel24.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel24.Location = new System.Drawing.Point(7, 56);
            this.xLabel24.Name = "xLabel24";
            this.xLabel24.Size = new System.Drawing.Size(82, 20);
            this.xLabel24.TabIndex = 84;
            this.xLabel24.Text = "連絡先1";
            this.xLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel24.Visible = false;
            // 
            // xLabel17
            // 
            this.xLabel17.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel17.EdgeRounding = false;
            this.xLabel17.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel17.Location = new System.Drawing.Point(101, 9);
            this.xLabel17.Name = "xLabel17";
            this.xLabel17.Size = new System.Drawing.Size(14, 20);
            this.xLabel17.TabIndex = 91;
            this.xLabel17.Text = "-";
            this.xLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel17.Visible = false;
            // 
            // xLabel41
            // 
            this.xLabel41.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel41.EdgeRounding = false;
            this.xLabel41.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel41.Location = new System.Drawing.Point(7, 80);
            this.xLabel41.Name = "xLabel41";
            this.xLabel41.Size = new System.Drawing.Size(82, 20);
            this.xLabel41.TabIndex = 100;
            this.xLabel41.Text = "連絡先2";
            this.xLabel41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel41.Visible = false;
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.xLabel9);
            this.xPanel6.Controls.Add(this.btnDelete);
            this.xPanel6.Controls.Add(this.btnInsert);
            this.xPanel6.Controls.Add(this.pictureBox1);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel6.Location = new System.Drawing.Point(0, 0);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(873, 28);
            this.xPanel6.TabIndex = 49;
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel9.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel9.Image = ((System.Drawing.Image)(resources.GetObject("xLabel9.Image")));
            this.xLabel9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel9.Location = new System.Drawing.Point(0, 0);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(873, 26);
            this.xLabel9.TabIndex = 105;
            this.xLabel9.Text = "家族構成";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 2;
            this.btnDelete.ImageList = this.ImageList;
            this.btnDelete.Location = new System.Drawing.Point(308, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 23);
            this.btnDelete.TabIndex = 104;
            this.btnDelete.Text = "削除";
            // 
            // btnInsert
            // 
            this.btnInsert.ImageIndex = 1;
            this.btnInsert.ImageList = this.ImageList;
            this.btnInsert.Location = new System.Drawing.Point(173, 3);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(129, 23);
            this.btnInsert.TabIndex = 103;
            this.btnInsert.Text = "家族構成員入力";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(873, 28);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // xPanel9
            // 
            this.xPanel9.Controls.Add(this.pnlNUR0106);
            this.xPanel9.Controls.Add(this.pnlGongbi);
            this.xPanel9.Controls.Add(this.tvwBoheomInfo);
            this.xPanel9.Controls.Add(this.xPanel1);
            this.xPanel9.Location = new System.Drawing.Point(-2, 2);
            this.xPanel9.Name = "xPanel9";
            this.xPanel9.Size = new System.Drawing.Size(871, 185);
            this.xPanel9.TabIndex = 3;
            // 
            // pnlNUR0106
            // 
            this.pnlNUR0106.Controls.Add(this.btnRegOUT0106);
            this.pnlNUR0106.Controls.Add(this.xLabel1);
            this.pnlNUR0106.Controls.Add(this.grdOUT0106);
            this.pnlNUR0106.Location = new System.Drawing.Point(510, 1);
            this.pnlNUR0106.Name = "pnlNUR0106";
            this.pnlNUR0106.Size = new System.Drawing.Size(366, 185);
            this.pnlNUR0106.TabIndex = 5;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.Image = ((System.Drawing.Image)(resources.GetObject("xLabel1.Image")));
            this.xLabel1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xLabel1.Location = new System.Drawing.Point(0, 0);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(33, 185);
            this.xLabel1.TabIndex = 1;
            this.xLabel1.Text = "特記事項";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tvwBoheomInfo
            // 
            this.tvwBoheomInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwBoheomInfo.ImageIndex = 0;
            this.tvwBoheomInfo.ImageList = this.ImageList;
            this.tvwBoheomInfo.Location = new System.Drawing.Point(647, 146);
            this.tvwBoheomInfo.Name = "tvwBoheomInfo";
            this.tvwBoheomInfo.SelectedImageIndex = 0;
            this.tvwBoheomInfo.Size = new System.Drawing.Size(172, 168);
            this.tvwBoheomInfo.TabIndex = 0;
            this.tvwBoheomInfo.Visible = false;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdOUT0103);
            this.xPanel1.Controls.Add(this.xLabel20);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(510, 185);
            this.xPanel1.TabIndex = 4;
            // 
            // grdOUT0103
            // 
            this.grdOUT0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5});
            this.grdOUT0103.ColPerLine = 4;
            this.grdOUT0103.Cols = 4;
            this.grdOUT0103.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOUT0103.FixedRows = 1;
            this.grdOUT0103.HeaderHeights.Add(21);
            this.grdOUT0103.Location = new System.Drawing.Point(30, 0);
            this.grdOUT0103.Name = "grdOUT0103";
            this.grdOUT0103.QuerySQL = resources.GetString("grdOUT0103.QuerySQL");
            this.grdOUT0103.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdOUT0103.Rows = 2;
            this.grdOUT0103.Size = new System.Drawing.Size(480, 185);
            this.grdOUT0103.TabIndex = 3;
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "gwa_name";
            this.xGridCell1.CellWidth = 99;
            this.xGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell1.HeaderText = "診療科";
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "doctor_name";
            this.xGridCell2.CellWidth = 117;
            this.xGridCell2.Col = 1;
            this.xGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell2.HeaderText = "主治医";
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "gubun";
            this.xGridCell3.CellWidth = 103;
            this.xGridCell3.Col = -1;
            this.xGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell3.HeaderText = "保険";
            this.xGridCell3.IsVisible = false;
            this.xGridCell3.Row = -1;
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "ipwon_date";
            this.xGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell4.CellWidth = 118;
            this.xGridCell4.Col = 3;
            this.xGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell4.HeaderText = "入院日";
            this.xGridCell4.IsJapanYearType = true;
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "toiwon_date";
            this.xGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell5.CellWidth = 124;
            this.xGridCell5.Col = 2;
            this.xGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell5.HeaderText = "退院日";
            this.xGridCell5.IsJapanYearType = true;
            // 
            // xLabel20
            // 
            this.xLabel20.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.xLabel20.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel20.Image = ((System.Drawing.Image)(resources.GetObject("xLabel20.Image")));
            this.xLabel20.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xLabel20.ImageIndex = 2;
            this.xLabel20.ImageList = this.ImageList;
            this.xLabel20.Location = new System.Drawing.Point(0, 0);
            this.xLabel20.Name = "xLabel20";
            this.xLabel20.Size = new System.Drawing.Size(30, 185);
            this.xLabel20.TabIndex = 2;
            this.xLabel20.Text = "入\n院\n履\n歴";
            this.xLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPatientInfo
            // 
            this.pnlPatientInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlPatientInfo.BackgroundImage")));
            this.pnlPatientInfo.Controls.Add(this.btnChangeGubun);
            this.pnlPatientInfo.Controls.Add(this.pbxDoubleTypeYN);
            this.pnlPatientInfo.Controls.Add(this.dtpLastCheckDate);
            this.pnlPatientInfo.Controls.Add(this.btnBoheomOpen);
            this.pnlPatientInfo.Controls.Add(this.paBox);
            this.pnlPatientInfo.Controls.Add(this.btnRegDoubleType);
            this.pnlPatientInfo.Controls.Add(this.btnTest);
            this.pnlPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatientInfo.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.pnlPatientInfo.Location = new System.Drawing.Point(4, 4);
            this.pnlPatientInfo.Name = "pnlPatientInfo";
            this.pnlPatientInfo.Size = new System.Drawing.Size(875, 36);
            this.pnlPatientInfo.TabIndex = 0;
            // 
            // btnChangeGubun
            // 
            this.btnChangeGubun.ImageIndex = 14;
            this.btnChangeGubun.ImageList = this.ImageList;
            this.btnChangeGubun.Location = new System.Drawing.Point(707, 38);
            this.btnChangeGubun.Name = "btnChangeGubun";
            this.btnChangeGubun.Size = new System.Drawing.Size(95, 28);
            this.btnChangeGubun.TabIndex = 63;
            this.btnChangeGubun.Text = "保険変更";
            this.btnChangeGubun.Visible = false;
            this.btnChangeGubun.Click += new System.EventHandler(this.btnChangeGubun_Click);
            // 
            // pbxDoubleTypeYN
            // 
            this.pbxDoubleTypeYN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbxDoubleTypeYN.BackColor = System.Drawing.Color.Transparent;
            this.pbxDoubleTypeYN.Image = ((System.Drawing.Image)(resources.GetObject("pbxDoubleTypeYN.Image")));
            this.pbxDoubleTypeYN.Location = new System.Drawing.Point(707, 72);
            this.pbxDoubleTypeYN.Name = "pbxDoubleTypeYN";
            this.pbxDoubleTypeYN.Size = new System.Drawing.Size(16, 16);
            this.pbxDoubleTypeYN.TabIndex = 60;
            this.pbxDoubleTypeYN.TabStop = false;
            this.pbxDoubleTypeYN.Visible = false;
            // 
            // dtpLastCheckDate
            // 
            this.dtpLastCheckDate.Location = new System.Drawing.Point(328, 3);
            this.dtpLastCheckDate.Name = "dtpLastCheckDate";
            this.dtpLastCheckDate.Size = new System.Drawing.Size(107, 20);
            this.dtpLastCheckDate.TabIndex = 16;
            this.dtpLastCheckDate.Visible = false;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(875, 32);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(712, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 17;
            this.btnTest.Text = "TESTモード";
            this.btnTest.Visible = false;
            // 
            // pbxIpwonTrans
            // 
            this.pbxIpwonTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbxIpwonTrans.BackColor = System.Drawing.Color.Transparent;
            this.pbxIpwonTrans.Image = ((System.Drawing.Image)(resources.GetObject("pbxIpwonTrans.Image")));
            this.pbxIpwonTrans.Location = new System.Drawing.Point(107, 548);
            this.pbxIpwonTrans.Name = "pbxIpwonTrans";
            this.pbxIpwonTrans.Size = new System.Drawing.Size(16, 15);
            this.pbxIpwonTrans.TabIndex = 59;
            this.pbxIpwonTrans.TabStop = false;
            this.pbxIpwonTrans.Visible = false;
            // 
            // layINP1002Update
            // 
            this.layINP1002Update.CallerID = '2';
            this.layINP1002Update.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem24});
            this.layINP1002Update.UseDefaultTransaction = false;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "pkinp1002";
            this.multiLayoutItem13.IsUpdItem = true;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "fkinp1001";
            this.multiLayoutItem14.IsUpdItem = true;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "bunho";
            this.multiLayoutItem15.IsUpdItem = true;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "gubun";
            this.multiLayoutItem16.IsUpdItem = true;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "seq";
            this.multiLayoutItem17.IsUpdItem = true;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "gubun_trans_date";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem18.IsUpdItem = true;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "gubun_ipwon_date";
            this.multiLayoutItem19.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem19.IsUpdItem = true;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "gubun_trans_cnt";
            this.multiLayoutItem20.IsUpdItem = true;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "gubun_trans_yn";
            this.multiLayoutItem21.IsUpdItem = true;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "from_jy_date";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem22.IsUpdItem = true;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "to_jy_date";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem23.IsUpdItem = true;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "iud_gubun";
            this.multiLayoutItem24.IsUpdItem = true;
            // 
            // layInp1002
            // 
            this.layInp1002.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4});
            this.layInp1002.QuerySQL = resources.GetString("layInp1002.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "gubun";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "gubun_name";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "pkinp1002";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "gubun_ipwon_date";
            // 
            // btnResend
            // 
            this.btnResend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResend.ImageIndex = 13;
            this.btnResend.ImageList = this.ImageList;
            this.btnResend.Location = new System.Drawing.Point(290, 567);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(101, 28);
            this.btnResend.TabIndex = 62;
            this.btnResend.Text = "会計再転送";
            this.btnResend.Visible = false;
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // layLastCheckDate
            // 
            this.layLastCheckDate.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem5});
            this.layLastCheckDate.QuerySQL = "SELECT A.LAST_CHECK_DATE\r\n  FROM OUT0102 A\r\n WHERE A.HOSP_CODE = :f_hosp_code\r\n  " +
                " AND A.GUBUN     = :f_gubun\r\n   AND A.BUNHO     = :f_bunho\r\n   AND :f_date BETWE" +
                "EN A.START_DATE AND A.END_DATE";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.BindControl = this.dtpLastCheckDate;
            this.singleLayoutItem5.DataName = "last_check_date";
            // 
            // layCheckEctIpwon
            // 
            this.layCheckEctIpwon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem6});
            this.layCheckEctIpwon.QuerySQL = "SELECT A.IPWON_TYPE\r\n  FROM INP1001 A\r\n WHERE A.HOSP_CODE  = :f_hosp_code\r\n   AND" +
                " A.BUNHO      = :f_bunho\r\n   AND A.IPWON_DATE = :f_ipwon_date";
            this.layCheckEctIpwon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCheckEctIpwon_QueryStarting);
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "ipwon_type";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Location = new System.Drawing.Point(290, 543);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 28);
            this.btnPrint.TabIndex = 63;
            this.btnPrint.Text = "リストバンド出力";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // INP1001U01
            // 
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pbxIpwonTrans);
            this.Controls.Add(this.pnlINP1001Control);
            this.Controls.Add(this.btnResend);
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnIpwonTrans);
            this.Controls.Add(this.pnlPatientInfo);
            this.Controls.Add(this.btnTransDate);
            this.Controls.Add(this.btnIpwonCancel);
            this.Name = "INP1001U01";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(883, 576);
            this.Load += new System.EventHandler(this.INP1001U01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlINP1001Control.ResumeLayout(false);
            this.pnlINP1001Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKaikei_HoDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).EndInit();
            this.pnlGongbi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1008)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0106)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.pnlINP1004.ResumeLayout(false);
            this.pnlINP1004.PerformLayout();
            this.gbxLive.ResumeLayout(false);
            this.gbxLive.PerformLayout();
            this.gbxWith.ResumeLayout(false);
            this.gbxWith.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1004)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xPanel9.ResumeLayout(false);
            this.pnlNUR0106.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0103)).EndInit();
            this.pnlPatientInfo.ResumeLayout(false);
            this.pnlPatientInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDoubleTypeYN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIpwonTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layINP1002Update)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수

		// 메세지 변수
		private string mMsg = "";
		private string mCap = "";

        NURI.PatientInfo mPaInfo = new PatientInfo();

        private bool isNew = true;

        private string fkout1001 = "";

		// 카르테 출력 관련 플레그 변수
		private bool mPrintChart = false;
		private string mPkinp1001_1   = string.Empty;
		private string mIpwon_type    = string.Empty;
		private string mIpwonsi_Order = string.Empty;
		private string mHo_dong1      = string.Empty;
		private string mHo_code1      = string.Empty;
		private string mBed_no        = string.Empty;
		private string mDoctor        = string.Empty;
		private string mIpwon_date    = string.Empty;
        private string mGubun         = string.Empty;

		// 퇴원후 추가처방 관련
		private bool mIsAddedOrderType = false;
		private const string  mAddedOrderType = "3";

        private string mGongbiYN = "";
        private string mPKINP1002 = "";

        private string mEtcIpwonDate = "";

        public string EtcIpwonDate
        {
            set { this.mEtcIpwonDate = value;  }
            get { return this.mEtcIpwonDate; }
        }


		#endregion

		#region Screen Load 이벤트 
		
		private void INP1001U01_Load(object sender, System.EventArgs e)
		{
			// 시작시 딱한번 타는 로직들
            this.InitScreen ();
		}

		#endregion

		#region OpenScreen (다른 스크린 열기)

		// 예약폼 오픈
		private void OpenForm_ReserSelectForm(ref MultiLayout aReserLayout)
		{
			ReserSelectForm form = new ReserSelectForm(this.paBox.BunHo);

            if (form.grdRowCount > 0)
            {
                form.ShowDialog();

                aReserLayout = form.ReturnLayout;
            }
            form.Dispose();
		}

		/// <summary>
		/// BED관리 창 Open
		/// </summary>
		private void OpenScreen_BAS0250Q00()
		{
			CommonItemCollection param = new CommonItemCollection();

			param.Add("ho_dong"   , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ho_dong1"));
			param.Add("ipwon_date", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));
            param.Add("accept_use_bed", "N");
            param.Add("sex", this.paBox.Sex);

			XScreen.OpenScreenWithParam(this, "BASS", "BAS0250Q00", ScreenOpenStyle.ResponseFixed, param);
		}

		/// <summary>
		/// 우편번호 조회 창 Open
		/// </summary>
		/// <param name="aSearchGubun"></param>
		/// <param name="aZipCode1"></param>
		/// <param name="aZipCode2"></param>
		/// <param name="aAddress"></param>
		private void OpenScreen_BAS0123Q00(string aSearchGubun, string aZipCode1, string aZipCode2, string aAddress)
		{
			CommonItemCollection param = new CommonItemCollection();

			if (aSearchGubun == "zipCode")
			{
				param.Add("SearchGubun", aSearchGubun);
				param.Add("zip_code1", aZipCode1);
				param.Add("zip_code2", aZipCode2);
			}
			else
			{
				param.Add("SearchGubun", aSearchGubun);
				param.Add("address", aAddress);
			}

			XScreen.OpenScreenWithParam(this, "BASS", "BAS0123Q00", ScreenOpenStyle.ResponseFixed, param);
		}

		/// <summary>
		/// 환자 특기사항 등록
		/// </summary>
		private void OpenScreen_OUT0106U00()
		{
			if (this.grdINP1001.RowCount > 0)
			{
				CommonItemCollection param = new CommonItemCollection();

				param.Add("bunho", this.paBox.BunHo);
				param.Add("naewon_date", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));

				XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", ScreenOpenStyle.ResponseFixed, param);
			}
		}

		/// <summary>
		/// 환자별 공비정보 등록창 Open
		/// </summary>
        private void OpenScreen_OUT0101U02()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.paBox.BunHo);

            XScreen.OpenScreenWithParam(this, "NURO", "OUT0101U02", ScreenOpenStyle.ResponseFixed, param);
        }

        private void btnBoheomOpen_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.paBox.BunHo);

            XScreen.OpenScreenWithParam(this, "NURO", "OUT0101U02", ScreenOpenStyle.ResponseFixed, param);

        }
		/// <summary>
		/// 환자 보험 등록 
		/// </summary>
        //private void OpenScreen_OUT0102U00 ()
        //{
        //    CommonItemCollection param = new CommonItemCollection();

        //    param.Add("bunho", this.paBox.BunHo);

        //    XScreen.OpenScreenWithParam(this, "NURO", "OUT0102U00", ScreenOpenStyle.ResponseFixed,  ScreenAlignment.ScreenMiddleCenter, param);
        //}

		// 입원일자 변경 폼
		private void OpenForm_IpwonDateTrans ()
		{
			INPDateForm form = new INPDateForm(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"), 
				this.paBox.BunHo, this.paBox.SuName, this.dtpIpwonDate.GetDataValue(),
				this.txtIpwonTime.GetDataValue());

			form.ShowDialog();
		}

		// 복수보험 등록 폼 
		private void OpenForm_DoubleTypeRegForm ()
		{
			DoubleTypeRegForm form = new DoubleTypeRegForm(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001")
				,this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date")
				,this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho"));
			form.ShowDialog();
		}

		private void OpenForm_IpwonSelectForm (ref MultiLayout aReturnLayout)
		{
			IpwonSelectForm form = new IpwonSelectForm(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho"));

			form.ShowDialog();

			aReturnLayout = form.mReturnLayout;
		}

		// 입원 전입 
		private void OpenScreen_INP2001U02()
		{
			CommonItemCollection param = new CommonItemCollection();

			param.Add("pkinp1001" , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"));
			param.Add("bunho"     , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho" ));
			param.Add("ipwon_date", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date" ));

			XScreen.OpenScreenWithParam(this, "NURI", "INP2001U02", ScreenOpenStyle.ResponseFixed, param);

            CheckIpwonTrans();
		}

		#endregion

		#region Function

		#region InitScreen 

		private void InitScreen ()
		{
			// 각 컨트롤 프로텍트
			this.ProtectIpwonInfo();     // 입원정보
			this.ProtectKeyPersonInfo(); // 보증인정보

			// 입원전입 마크 안보이게
			this.pbxIpwonTrans.Visible = false;

            this.dbxGubunName.SetDataValue("");
			// 포커스 
			this.paBox.Focus();
		}

		#endregion

		#region 데이터 체크

		#region 환자 체크

		private bool IsValidPatient ()
		{
			// 환자 정보 로드
            this.mPaInfo.ClearPatientInfo();
            this.mPaInfo.GetPatientInfo(paBox.BunHo);

			// 삭제여부 체크
            if (this.mPaInfo.DeleteYN == "Y")
			{
				this.mMsg = NetInfo.Language == LangMode.Ko ? "의무기록실에서 삭제한 등록번호입니다. 번호를 확인하십시오" 
					: "削除された患者番号です。患者番号を確認してください。";
				this.mCap = NetInfo.Language == LangMode.Ko ? "환자체크" : "患者チェック";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}

			return true;
		}

		#endregion

		#region 예약 데이터 셋팅

		private bool CheckReserData()
		{
			MultiLayout reserLayout = null;

			this.OpenForm_ReserSelectForm(ref reserLayout);

			// 예약건이 있고 선택이 된경우
			if (reserLayout != null)
			{
                //입원 예약일
                this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_date", reserLayout.GetItemString(0, "reser_date"));

				// 진료과, 주치의
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gwa"             , reserLayout.GetItemString(0, "gwa")             );
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_gwa"       , reserLayout.GetItemString(0, "gwa")             );
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gwa_name"        , reserLayout.GetItemString(0, "gwa_name")        );
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "doctor"          , reserLayout.GetItemString(0, "doctor")          );
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "doctor_name"     , reserLayout.GetItemString(0, "doctor_name")     );
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jisi_doctor"     , reserLayout.GetItemString(0, "jisi_doctor")     );
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jisi_doctor_name", reserLayout.GetItemString(0, "jisi_doctor_name"));
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "resident"        , reserLayout.GetItemString(0, "doctor")          );

                // 초재진 구분 셋팅
                this.SetChojaeGubun(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date")
                    , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho")
                    , reserLayout.GetItemString(0, "gwa") 
                    , this.fbxGubun.GetDataValue());   

				// 진료과 화면 표시
				this.fbxGwa.SetDataValue(reserLayout.GetItemString(0, "gwa"));
				this.dbxGwaName.SetDataValue(reserLayout.GetItemString(0, "gwa_name"));
				// 주치의 화면표시
				this.fbxDoctor.SetDataValue(reserLayout.GetItemString(0, "doctor"));
				this.dbxDoctorName.SetDataValue(reserLayout.GetItemString(0, "doctor_name"));

				// 지시의사 화면표시
				this.fbxJisiDoctor.SetDataValue(reserLayout.GetItemString(0, "jisi_doctor"));
				this.dbxJisiDoctorName.SetDataValue(reserLayout.GetItemString(0, "jisi_doctor_name"));

				// 병동, 병실, 베드, 병실등급, 병실status
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ho_dong1"   , reserLayout.GetItemString(0, "ho_dong")  );
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ho_code1"   , reserLayout.GetItemString(0, "ho_code")  );
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "bed_no"     , reserLayout.GetItemString(0, "bed_no")   );
                this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ho_grade1", reserLayout.GetItemString(0, "ho_grade"));
                this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "kaikei_hodong", reserLayout.GetItemString(0, "ho_dong"));
                this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "kaikei_hocode", reserLayout.GetItemString(0, "ho_code"));
                //this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ho_status1" , reserLayout.GetItemString(0, "ho_status"));

				// 화면표시
				this.dbxHoDong.SetDataValue(reserLayout.GetItemString(0, "ho_dong"));
				this.dbxHoCode.SetDataValue(reserLayout.GetItemString(0, "ho_code"));
				this.dbxBedNo.SetDataValue(reserLayout.GetItemString(0, "bed_no"));

				// 키값 셋팅
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "pkinp1001"  , reserLayout.GetItemString(0, "reser_fkinp1001"));
				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "fkinp1003"  , reserLayout.GetItemString(0, "pkinp1003"));
                this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "fkout1001", reserLayout.GetItemString(0, "fkout1001"));

                //구급 정보 세팅
                this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "emergency_gubun", reserLayout.GetItemString(0, "emergency_gubun"));
                if (reserLayout.GetItemString(0, "emergency_gubun") == "10")
                {
                    this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "emergency_detail", reserLayout.GetItemString(0, "emergency_detail"));
                    mbxEmergencyDetail.Enabled = true;
                    mbxEmergencyDetail.Visible = true;
                }
				if (reserLayout.GetItemString(0, "remark") != "")
				{
					this.mMsg = NetInfo.Language == LangMode.Ko ? "입원예약정보를 로드하였습니다." : "入院予約データをロードしました。";
					this.mMsg += "\n====================================================\n";
					this.mMsg += " ▶ コメント\n";
					this.mMsg += "       " + reserLayout.GetItemString(0, "remark");

					this.mCap = NetInfo.Language == LangMode.Ko ? "입원예약" : "入院予約";

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
                    //this.mMsg = NetInfo.Language == LangMode.Ko ? "입원예약정보를 로드하였습니다." : "入院予約データをロードしました。";
                    //this.mCap = NetInfo.Language == LangMode.Ko ? "입원예약" : "入院予約";

                    //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

                txtIpwonTime.Focus();


				return true;
			}

			return false;
		}

		#endregion

		#region 보험코드 체크 

		private void CheckBoheomInfo ()
		{
            //this.mGubunDetail.GetData(this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun")
            //    , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));

            this.mGongbiYN = IHIS.NURI.Methodes.ChkGetGongbiYN(this.fbxGubun.GetDataValue(), this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));
            if (this.mGongbiYN == "N")
            {
                if (this.grdINP1008.RowCount > 0)
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "현재 보험종류는 공비를 적용하지 않습니다." : "現在の保険は公費を適用できません。";
                    this.mCap = NetInfo.Language == LangMode.Ko ? "보험선택" : "保険選択";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }			
		}

		#endregion

		#region 저장전 체크

		#region INP1001 체크
		/// <summary>
		/// 입원마스터 체크
		/// </summary>
		/// <returns></returns>
		private bool CheckINP1001 ()
		{
			// 1001 체크
			// 카르테 출력을 위한 플레그값 셋팅 
			// 체크 순서 각종 NULL값 체크
			// -- 클라이언트 체크
			//         널값 체크
			// -- 서버체크
			//         이미 재원중인지 여부 체크
			//         병실 사용여부 체크

			this.mCap = (NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗");

			for (int i=0; i<this.grdINP1001.RowCount; i++)
			{
				if (this.grdINP1001.GetRowState(i) == DataRowState.Added)
				{
					if (this.mPrintChart == false)
						this.mPrintChart = true;
				}

				if (this.grdINP1001.GetItemString(i, "ipwon_date") == "")
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원일자를 입력해 주십시오." : "入院日を入力してください。");
					
					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.dtpIpwonDate.SelectAll();
					this.dtpIpwonDate.Focus();

					return false;
				}

				if (this.grdINP1001.GetItemString(i, "ipwon_time").Replace(":", "") == "" )
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원시간를 입력해 주십시오." : "入院時間を入力してください。");

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.txtIpwonTime.SelectAll();
					this.txtIpwonTime.Focus();

					return false;
				}


                if (this.grdINP1001.GetItemString(i, "ipwon_type") == "")
                {
                    this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원유형을 입력해 주세요" : "入院タイプを入力してください。");

                    this.SetMsg(this.mMsg, MsgType.Error);

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.cboIpwonType.Focus();

                    return false;
                }

                /*
				if (this.grdINP1001.GetItemString(i, "gisan_ipwon_date") == "")
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "기산일을 입력해 주십시오." : "起算日を入力してください。");

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.dtpGisanDate.SelectAll();
					this.dtpGisanDate.Focus();

					return false;
				}
                */
				if (this.grdINP1001.GetItemString(i, "gwa") == "")
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "진료과를 입력해 주십시오." : "診療科を入力してください。");

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.fbxGwa.SelectAll();
					this.fbxGwa.Focus();

					return false;
				}

				if (this.grdINP1001.GetItemString(i, "doctor") == "")
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "주치의를 입력해 주십시오." : "主治医を入力してください。");

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.fbxDoctor.SelectAll();
					this.fbxDoctor.Focus();

					return false;
				}

                //if (this.grdINP1001.GetItemString(i, "chojae") == "")
                //{
                //    this.mMsg = (NetInfo.Language == LangMode.Ko ? "초재진 코드를 입력해 주세요." : "初再診コードを入力してください。");

                //    this.SetMsg(this.mMsg, MsgType.Error);

                //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    this.cboChojae.Focus();

                //    return false;
                //}

				if (this.grdINP1001.GetItemString(i, "ho_dong1") == "" ||
					this.grdINP1001.GetItemString(i, "ho_code1") == "" || 
					this.grdINP1001.GetItemString(i, "bed_no") == ""     )
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "병동,병실,베드정보를 입력해 주세요." : "病棟,病室,病床情報を入力してください。");

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.btnBedButton.Focus();

					return false;
				}

                if(this.cboKaikei_HoDong.GetDataValue() == "" ||
                    this.cboKaikei_HoCode.GetDataValue() == "")
                {
                    this.mMsg = (NetInfo.Language == LangMode.Ko ? "회계병동, 회계 병실정보를 입력해 주세요." : "会計病棟、会計病室を入力してください。");

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					this.cboKaikei_HoCode.Focus();

                    return false;
                }

				// 기산일은 입원일 보다 미래일 수 없다.
				/*
                DateTime ipwonDate = DateTime.Parse(this.grdINP1001.GetItemString(i, "ipwon_date"));
				DateTime gisanDate = DateTime.Parse(this.grdINP1001.GetItemString(i, "gisan_ipwon_date"));

				if (ipwonDate < gisanDate)
				{
					this.mMsg = NetInfo.Language == LangMode.Ko ? "기산일은 입원보다 미래일 수 없습니다." : "起算日は入院日より未来の日付での入力できません。";

					this.SetMsg(this.mMsg, MsgType.Error);

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					return false;
				}
                 */
			}

			return true;
			
		}

		#endregion

		#region INP1002 보험정보 체크

		private bool CheckINP1002 ()
		{
            this.mCap = (NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗");

            for (int i = 0; i < this.layINP1002Update.RowCount; i++)
            {
                //mGubunDetail.GetData(this.layINP1002Update.GetItemString(i, "gubun")
                //    , this.layINP1002Update.GetItemString(i, "gubun_ipwon_date"));

                if (this.layINP1002Update.GetItemString(i, "gubun") == "")
                {
                    this.mMsg = (NetInfo.Language == LangMode.Ko ? "보험종류를 입력해 주십시오." : "保険種別を入力してください。");

                    this.SetMsg(this.mMsg, MsgType.Error);

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
		}

		#endregion

		#region INP1008 공비 체크

		private bool CheckINP1008 ()
		{
			// 공비가 필요하지 않은 보험인데 공비가 선택된 경우
			// 메세지와 함계 공비선택을 해제 한다

            this.mGongbiYN = NURI.Methodes.ChkGetGongbiYN(this.fbxGubun.GetDataValue(), EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            if (this.mGongbiYN == "N")
            {
                bool isShownMsg = false;

                for (int i = 0; i < this.grdINP1008.RowCount; i++)
                {
                    if (this.grdINP1008.GetItemString(i, "check_yn") == "Y")
                    {
                        if (isShownMsg == false)
                        {
                            this.mMsg = (NetInfo.Language == LangMode.Ko ? "현재 보험종류는 공비를 적용하지 않습니다.\n공비선택을 해제 합니다."
                                : "現在の保険種類は公費を適用できません。\n選択された公費を解除します。");
                            this.mCap = (NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ");

                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            isShownMsg = true;

                        }

                        this.grdINP1008.SetItemValue(i, "check_yn", "N");
                        this.grdINP1008.SetItemValue(i, "priority", "");
                    }
                }
            }

			return true;
		}

		#endregion

		#endregion

		#endregion

		#region Clear

        //private void ClearKeyPersonInfo ()
        //{
        //    foreach (Control control in this.pnlKeyPersonHeader.Controls)
        //    {
        //        if (control is IDataControl)
        //        {
        //            ((IDataControl)(control)).DataValue = "";
        //        }
        //    }
        //}

		private void ClearFlag ()
		{
			// 퇴원후 추가처방 플래그
			this.mIsAddedOrderType = false;

			this.pbxIpwonTrans.Visible = false;

			this.pbxDoubleTypeYN.Visible = false;

			// 카르테 출력 관련 플레그
			this.mPrintChart = false;

            this.mPKINP1002 = "";
            this.mGongbiYN = "";
		}

		#endregion

		#region 컨트롤 프로텍트

		#region 입원정보 컨트롤 프로텍트

		private void ProtectIpwonInfo ()
		{
			if (this.grdINP1001.RowCount <= 0)
			{
				foreach (Control control in this.pnlINP1001Control.Controls)
				{
					if (control is IDataControl)
					{
						((IDataControl)control).Protect = true;
					}
                }

				return;
			}

			if (this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) == DataRowState.Added)
			{
				foreach(XEditGridCell cell in this.grdINP1001.CellInfos)
				{
					if (cell.BindControl != null )
					{
						((IDataControl)cell.BindControl).Protect = false;
					}
				}
			}
			else if (this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) == DataRowState.Unchanged ||
				this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) == DataRowState.Modified   )
			{
				foreach(XEditGridCell cell in this.grdINP1001.CellInfos)
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
		}

		#endregion


		#region 보증인정보 컨트롤 프로텍트

		private void ProtectKeyPersonInfo ()
		{
			if (this.grdINP1004.RowCount <= 0)
			{
				foreach (Control control in this.pnlINP1004.Controls)
				{
					if (control is IDataControl)
					{
						((IDataControl)control).Protect = true;
					}
				}

				return;
			}

			if (this.grdINP1004.GetRowState(grdINP1004.CurrentRowNumber) == DataRowState.Added)
			{
				foreach(XEditGridCell cell in this.grdINP1004.CellInfos)
				{
					if (cell.BindControl != null )
					{
						((IDataControl)cell.BindControl).Protect = false;
					}
				}
			}
			else if (this.grdINP1004.GetRowState(grdINP1004.CurrentRowNumber) == DataRowState.Unchanged ||
				this.grdINP1004.GetRowState(grdINP1004.CurrentRowNumber) == DataRowState.Modified   )
			{
				foreach(XEditGridCell cell in this.grdINP1004.CellInfos)
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
		}

		#endregion

		#endregion

		#region 초재진 구분 기본셋팅

		private void SetChojaeGubun(string aIpwonDate, string aBunho, string aGwa, string aGubun)
		{
			string chojaeGubun = "";

			// 입원등록시에만 자동설정
			// 조회된 경우는 변경 없음.
			if (this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) == DataRowState.Added)
			{
				chojaeGubun = NURI.Methodes.GetChoJae(aIpwonDate, aBunho, aGwa, aGubun);

				this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "chojae", chojaeGubun);
			}
		}

		#endregion

		#region 보험 내역 트리뷰 생성

        private void MakeIpwonTypeNode()
        {
            // 일단 클리어 하고
            this.tvwBoheomInfo.Nodes.Clear();

            TreeNode node;

            foreach (DataRow dr in this.layCommon.LayoutTable.Rows)
            {
                string title = "";

                title = dr["ipwon_type_name"].ToString() + "[" + dr["start_boheom_date"].ToString() + "]";

                node = new TreeNode(title, 6, 6);
                node.Tag = dr["pkinp1001"].ToString();

                this.tvwBoheomInfo.Nodes.Add(node);
            }

            // 차일드 노드 생성 
            this.MakeBoheomChildNode();
        }

        private void MakeBoheomChildNode()
        {
            TreeNode childNode;
            string title = "";

            foreach (TreeNode node in this.tvwBoheomInfo.Nodes)
            {
                this.LoadBoheomChildList(node.Tag.ToString());

                foreach (DataRow dr in this.layCommon.LayoutTable.Rows)
                {
                    title = dr["gubun_name"].ToString() + " [" + dr["gubun_ipwon_date"].ToString() + "]";

                    childNode = new TreeNode(title, 7, 7);
                    childNode.Tag = dr["pkinp1002"].ToString();

                    node.Nodes.Add(childNode);
                }
            }
        }

		#endregion

		#region 콤보박스 셋팅

		/// <summary>
		/// 입원유형 콤보 셋팅
		/// </summary>
		private void MakeIpwonTypeCombo (string aComboGubun)
		{
			// 현재 입원등록이 된 상태냐 아니냐에따라
			// 입원유형을 선택할수 있는 갯수가 정해져 있음.
			// 판단은 aComboGubun 이 1이면 입원등록을 해야하는 상태이고
			//                       1이 아니면 입원등록이 완료된 상태이다
			if (aComboGubun == "1" )
			{
				this.cboIpwonType.UserSQL = @"  SELECT A.CODE 
					                                 , A.CODE_NAME 
					                              FROM BAS0102 A 
					                             WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                                   AND A.CODE_TYPE = 'IPWON_TYPE2' 
					                             ORDER BY A.CODE " ;
			}
			else
			{
				this.cboIpwonType.UserSQL = @"SELECT A.CODE 
					                                 , A.CODE_NAME 
					                              FROM BAS0102 A 
					                             WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                                   AND A.CODE_TYPE = 'IPWON_TYPE' 
					                             ORDER BY A.CODE ";
			}

			this.cboIpwonType.SetDictDDLB();
		}

		#endregion

		#region 퇴원후 추가처방 적용

		private bool ApplyAddedOrderType ()
		{
			MultiLayout returnLayout = new MultiLayout();

			this.OpenForm_IpwonSelectForm(ref returnLayout);

			if (returnLayout.RowCount > 0)
			{
				this.SetAddedOrderType(returnLayout);

				return true;
			}
			else
			{
				return false;
			}
		}

		private void SetAddedOrderType (MultiLayout aPastInfo)
		{
			this.fbxGwa.SetEditValue(aPastInfo.GetItemString(0, "gwa"));
			this.fbxGwa.AcceptData();

			this.fbxDoctor.SetEditValue(aPastInfo.GetItemString(0, "doctor"));
			this.fbxDoctor.AcceptData();

			this.dbxHoDong.SetDataValue(aPastInfo.GetItemString(0, "ho_dong_name"));
			this.dbxHoCode.SetDataValue(aPastInfo.GetItemString(0, "ho_code"));
			this.dbxBedNo.SetDataValue(aPastInfo.GetItemString(0, "bed_no"));
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ho_dong1", aPastInfo.GetItemString(0, "ho_dong"));
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ho_code1", aPastInfo.GetItemString(0, "ho_code"));
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "bed_no"  , aPastInfo.GetItemString(0, "bed_no"));


            this.cboHoGrade1.SetEditValue(aPastInfo.GetItemString(0, "ho_grade"));
            this.cboHoGrade1.AcceptData();

			this.dtpIpwonDate.SetEditValue(aPastInfo.GetItemString(0, "ipwon_date"));
			this.dtpIpwonDate.AcceptData();

			this.dtpGisanDate.SetEditValue(aPastInfo.GetItemString(0, "ipwon_date"));
			this.dtpGisanDate.AcceptData();

            this.cboKaikei_HoDong.SetEditValue(aPastInfo.GetItemString(0, "kaikei_hodong"));
            cboKaikei_HoDong.AcceptData();

            this.cboKaikei_HoCode.SetEditValue(aPastInfo.GetItemString(0, "kaikei_hocode"));
            cboKaikei_HoCode.AcceptData();

            this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "kaikei_hodong", aPastInfo.GetItemString(0, "ho_dong"));
            this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "kaikei_hocode", aPastInfo.GetItemString(0, "ho_code"));

			this.fbxGwa.Protect = true;
			this.fbxDoctor.Protect = true;
			this.cboHoGrade1.Protect = true;
			this.dtpIpwonDate.Protect = true;
			this.cboIpwonType.Protect = true;
		}

		#endregion

		#endregion

		#region 기본값 셋팅

		#region INP1001 입원마스터 기본값 셋팅

		private void DefaultSettingINP1001 ()
		{

            string strSql = "SELECT INP1001_SEQ.NEXTVAL FROM DUAL";

            object retVal = Service.ExecuteScalar(strSql);

            this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "pkinp1001", retVal.ToString());

            string DefaultDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

			// 환자번호, 입원일자, 기산일자, 입원시간
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "bunho"           , this.paBox.BunHo );
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "suname"          , this.paBox.SuName);
			if(!TypeCheck.IsNull(this.paBox.Birth))
			{
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "birth"           , Convert.ToDateTime(paBox.Birth).ToString("yyyy/MM/dd"));
			}
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "sex"             , this.paBox.Sex   );

			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_date"      , DefaultDate      );
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gisan_ipwon_date", DefaultDate      );
            this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
			
			this.dtpIpwonDate.SetDataValue(DefaultDate);
			this.dtpGisanDate.SetDataValue(DefaultDate);
			this.txtIpwonTime.SetDataValue(EnvironInfo.GetSysDateTime().ToString("HHmm"));

			// 재원플레그, 심사마감 구분
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jaewon_flag"   , "Y");  // 재원중
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "simsa_magam_yn", "1");  // 재원중

			// 취소데이터 여부
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "cancel_yn"     , "N");  // 취소여부

			// 입원경로1, 2 첫번째 데이터로 기본셋팅
            //this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_rtn1"    , "1");  // 입원경로
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_rtn2"    , "1");  // 입원경로2

			// 입원타입
			this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_type", "0"); //입원유형은 "정상"으로 기본셋팅
			this.cboIpwonType.SetDataValue("0");

			this.cboIpwonRtn2.SetDataValue("1");


		}

		#endregion

		#region 보증인 INP1004 기본값 셋팅

		private void DefaultSettingINP1004()
		{
			this.grdINP1004.SetItemValue(grdINP1004.CurrentRowNumber, "bunho", this.paBox.BunHo);
		}

		#endregion

		#endregion

		#region Data Loading

		#region 입원정보

		// 데이터 생성 (입원등록의 경우)
		///////////////////////////////////////////////////////////////////////////////////////////////////////////
		private void MakeIpwonData ()
		{
			this.grdINP1001.Reset();

			// 새로운 행 삽입
			this.grdINP1001.InsertRow(-1);

			// 디폴트 데이터 생성
			this.DefaultSettingINP1001();

			// 예약 체크
			this.CheckReserData();
		}

		// 데이터 조회 (입원등록 완료후 조회의 경우)
		///////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CheckIpwonTrans()
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            //BindVarCollection bindVars = new BindVarCollection();
            //object retVal;

            for (int i = 0; i < this.grdINP1001.RowCount; i++)
            {
                inputList.Clear();
                outputList.Clear();

                inputList.Add(EnvironInfo.HospCode);
                inputList.Add(this.grdINP1001.GetItemString(i, "bunho"));
                inputList.Add(this.grdINP1001.GetItemValue(i, "ipwon_date"));

                if (!Service.ExecuteProcedure("PR_INP_CHECK_IPWON_TRANS", inputList, outputList))
                {
                    XMessageBox.Show(Service.ErrFullMsg + " : 外来来院履歴の照会中にエラーが発生しました。\r\n" +
                                                          "   PR_INP_CHECK_IPWON_TRANS Error");
                    return;
                }

                this.grdINP1001.SetItemValue(i, "check_trans_yn", outputList[0].ToString());

                if (this.grdINP1001.GetItemString(i, "check_trans_yn") != "0")
                {
                    this.pbxIpwonTrans.Visible = true;
                    XMessageBox.Show("転入処理対象のデータがあります。確認してください。");
                }
                else
                {
                    this.pbxIpwonTrans.Visible = false;
                }

                /* 20110413　이중유형 없어짐
                bindVars.Clear();
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVars.Add("f_bunho", this.grdINP1001.GetItemString(i, "bunho"));

                string cmdText = @"SELECT 'Y'
                                 FROM DUAL
                                WHERE EXISTS ( SELECT 'X'
                                                 FROM INP1001 
                                                WHERE HOSP_CODE           = :f_hosp_code
                                                  AND BUNHO               = :f_bunho
                                                  AND JAEWON_FLAG         = 'Y'
                                                  AND NVL(CANCEL_YN, 'N') = 'N'
                                                  AND IPWON_TYPE = '2' )";
                retVal = null;
                retVal = Service.ExecuteScalar(cmdText, bindVars);
                if (!TypeCheck.IsNull(retVal))
                {
                    this.grdINP1001.SetItemValue(i, "double_type_exist_yn", retVal.ToString());
                }
                 * */
            }
        }
        
		private void LoadIpwonData()
        {
            this.grdINP1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP1001.SetBindVarValue("f_pkinp1001", this.mPaInfo.PKINP1001);

			if(!this.grdINP1001.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdINP1001 Query Error");
				return;
			}

            CheckIpwonTrans();

            this.layInp1002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layInp1002.SetBindVarValue("f_fkinp1001", this.mPaInfo.PKINP1001);
            this.layInp1002.QueryLayout();

            this.mPKINP1002 = this.layInp1002.GetItemValue("pkinp1002").ToString();
            this.fbxGubun.SetDataValue(this.layInp1002.GetItemValue("gubun"));
            this.dbxGubunName.SetDataValue(this.layInp1002.GetItemValue("gubun_name"));

            this.GetLastCheckDate(this.layInp1002.GetItemValue("gubun").ToString());

            this.grdINP1001.ResetUpdate();
		}

		#endregion

		#region 특기사항 

		private void LoadOUT0106 ()
        {
            this.grdOUT0106.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdOUT0106.SetBindVarValue("f_bunho"     , this.paBox.BunHo);
			this.grdOUT0106.SetBindVarValue("f_ipwon_date", this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "ipwon_date"));

			if(!this.grdOUT0106.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdOUT0106 Query Error");
				return;
			}
		}

		#endregion

		#region 공비정보 조회

		private void LoadGongbiQuery()
		{
            string mGubun_Ipwon_date = string.Empty;

            if (this.layInp1002.GetItemValue("pkinp1002").ToString().Length == 0)
            {
                mGubun_Ipwon_date = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "ipwon_date");
            }
            else
            {
                mGubun_Ipwon_date = this.layInp1002.GetItemValue("gubun_ipwon_date").ToString();
            }
                        
            this.grdINP1008.SetBindVarValue("f_hosp_code"       , EnvironInfo.HospCode);
			this.grdINP1008.SetBindVarValue("f_bunho"           , this.paBox.BunHo);
			this.grdINP1008.SetBindVarValue("f_fkinp1002"       , this.mPKINP1002);
			this.grdINP1008.SetBindVarValue("f_gubun_ipwon_date", mGubun_Ipwon_date);
            this.grdINP1008.SetBindVarValue("f_gubun"           , this.fbxGubun.GetDataValue());
			this.grdINP1008.SetBindVarValue("f_ipwon_date"      , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));

			if(!this.grdINP1008.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdINP1008 Query Error");
				return;
			}

            string cmdText = @"SELECT GONGBI_CODE
                                     , PRIORITY 
                                 FROM INP1008
                                WHERE HOSP_CODE   = :f_hosp_code
                                  AND GONGBI_CODE = TRIM(:f_gongbi_code)
                                  AND FKINP1002   = TRIM(:f_fkinp1002)  ";

			BindVarCollection bindVars = new BindVarCollection();
			DataTable dt = null;

			for(int i=0; i < this.grdINP1008.RowCount; i++)
            {
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
				bindVars.Add("f_gongbi_code", this.grdINP1008.GetItemString(i, "gongbi_code"));
                bindVars.Add("f_fkinp1002", this.mPKINP1002);

                dt = null;
                dt = Service.ExecuteDataTable(cmdText, bindVars);

                if (!TypeCheck.IsNull(dt))
				{
                    if (dt.Rows[0]["GONGBI_CODE"] != null)
                    {
                        this.grdINP1008.SetItemValue(i, "check_yn", "Y");
                        if (dt.Rows[0]["PRIORITY"] != null)
                            this.grdINP1008.SetItemValue(i, "priority", dt.Rows[0]["PRIORITY"].ToString());
                    }
				}
			}
            this.grdINP1008.ResetUpdate();
            
		}

		#endregion

		#region 내원이력 조회

		private void LoadNaewonHis()
        {
            this.grdOUT0103.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdOUT0103.SetBindVarValue("f_bunho", this.paBox.BunHo);

			if(!this.grdOUT0103.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdOUT0103 Query Error");
				return;
			}
		}

		#endregion

		#region 보증인 정보 조회

		private void LoadKeyPerson ()
        {
            this.grdINP1004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdINP1004.SetBindVarValue("f_bunho", paBox.BunHo);

			if(!this.grdINP1004.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdINP1004 Query Error");
				return;
			}

			// 맨위에 첫번째 사람정보 셋팅
			//this.ClearKeyPersonInfo();

            //if (this.grdINP1004.RowCount > 0)
            //{
            //    this.dbxName.SetDataValue(this.grdINP1004.GetItemString(0, "name"));
            //    this.dbxBoninGubun.SetDataValue(this.grdINP1004.GetItemString(0, "bonin_gubun_name"));
            //    this.dbxTel1.SetDataValue(this.grdINP1004.GetItemString(0, "tel1"));
            //    this.cboDispTelGubun.SetDataValue(this.grdINP1004.GetItemString(0, "tel_gubun"));
            //}
		}

		#endregion

		#region 보험이력 조회

        private void LoadIpwonTypeList()
        {
            // 입원유형별 root 생성
            // 서비스 셋팅

            layCommon.QuerySQL = @"SELECT A.PKINP1001
                                        , A.IPWON_TYPE
                                        , FN_BAS_LOAD_CODE_NAME('IPWON_TYPE', A.IPWON_TYPE)
                                        , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.IPWON_DATE )
                                        , A.IPWON_TYPE || TO_CHAR(A.PKINP1001, '0000000000') CONT_KEY
                                     FROM INP1001 A
                                    WHERE A.HOSP_CODE   = :f_hosp_code
                                      AND A.BUNHO       = :f_bunho
                                      AND A.JAEWON_FLAG = 'Y'
                                      AND NVL(A.CANCEL_YN, 'N') = 'N'
                                    ORDER BY CONT_KEY";

            layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layCommon.SetBindVarValue("f_bunho", this.paBox.BunHo);

            this.layCommon.LayoutItems.Clear();
            this.layCommon.LayoutItems.Add("pkinp1001", DataType.String, false, false);
            this.layCommon.LayoutItems.Add("ipwon_type", DataType.String, false, false);
            this.layCommon.LayoutItems.Add("ipwon_type_name", DataType.String, false, false);
            this.layCommon.LayoutItems.Add("start_boheom_date", DataType.String, false, false);
            this.layCommon.InitializeLayoutTable();

            if (!layCommon.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg + " : layCommon Query Error");
                return;
            }

            this.MakeIpwonTypeNode();
        }

        private void LoadBoheomChildList(string aPkinp1001)
        {
            // 입원유형별 보험사항 조회

            layCommon.QuerySQL = @"SELECT A.PKINP1002
                                        , A.GUBUN
                                        , FN_BAS_LOAD_GUBUN_NAME (A.GUBUN, A.GUBUN_IPWON_DATE)
                                        , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.GUBUN_IPWON_DATE)
                                     FROM INP1002 A
                                    WHERE A.HOSP_CODE = :f_hosp_code 
                                      AND A.FKINP1001 = :f_fkinp1001
                                      --AND A.GUBUN_TRANS_YN = 'N'
                                    ORDER BY A.GUBUN_IPWON_DATE DESC";

            layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layCommon.SetBindVarValue("f_fkinp1001", aPkinp1001);

            this.layCommon.LayoutItems.Clear();
            this.layCommon.LayoutItems.Add("pkinp1002", DataType.String, false, false);
            this.layCommon.LayoutItems.Add("gubun", DataType.String, false, false);
            this.layCommon.LayoutItems.Add("gubun_name", DataType.String, false, false);
            this.layCommon.LayoutItems.Add("gubun_ipwon_date", DataType.String, false, false);
            this.layCommon.InitializeLayoutTable();

            if (!layCommon.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg + " : layCommon Query Error");
                return;
            }
        }

		#endregion

		#endregion

		#region Update 관련

		#region 업데이트 데이터 생성

		private void MakeUpdateINP1002()
		{
			this.layINP1002Update.Reset();

			// 최초 입원 등록시
			if (this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) == DataRowState.Added)
			{
                int rowNum = this.layINP1002Update.InsertRow(0);

                this.layINP1002Update.SetItemValue(rowNum, "fkinp1001", this.mPaInfo.PKINP1001);
                this.layINP1002Update.SetItemValue(rowNum, "gubun", this.fbxGubun.GetDataValue());
                this.layINP1002Update.SetItemValue(rowNum, "from_jy_date", this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "ipwon_date"));
                this.layINP1002Update.SetItemValue(rowNum, "gubun_ipwon_date", this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "ipwon_date"));
                this.layINP1002Update.SetItemValue(rowNum, "gubun_trans_cnt", "1");
                this.layINP1002Update.SetItemValue(rowNum, "gubun_trans_yn", "N");
                this.layINP1002Update.SetItemValue(rowNum, "bunho", this.paBox.BunHo);

                this.layINP1002Update.SetItemValue(rowNum, "iud_gubun", "I");
					                  
			}
				// 입원 등록후 변경시 ( 이중유형도 생각해야 하므로)
			else
			{
                //for (int i=0; i<this.grdINP1002.RowCount; i++)
                //{
                //    if (this.grdINP1002.GetRowState(i) == DataRowState.Modified)
                //    {
                //        this.layINP1002Update.LayoutTable.ImportRow(this.grdINP1002.LayoutTable.Rows[i]);

                //        this.layINP1002Update.SetItemValue(this.layINP1002Update.RowCount-1, "iud_gubun", "U");
                //    }
                //}
			}
		}

		#endregion

		#region 입원 취소 관련

		private bool IpwonCancel()
		{
            MessageBoxIcon icon ;
			// 입원 취소시 오더 발생여부를 체크한다
			// 오더 발생건이 있는 경우 메세지로 물어본다


            // 첫번째 반환값 : 전입 처리 오더 유무 확인
            // 두번째 반환값 : 입원 오더 중 실시된 오더 유무 확인
            // 세번째 반환값 : 입원 처리 후 발생한 오더 유무 확인
            string cmdText = @"SELECT FN_OCS_EXISTS_INP_ORDER(:f_bunho, :f_pkinp1001)
								 FROM DUAL";

			BindVarCollection bindVars = new BindVarCollection();
			bindVars.Add("f_bunho"    , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho"));
			bindVars.Add("f_pkinp1001", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"));

			object retVal = Service.ExecuteScalar(cmdText, bindVars);

            string result = retVal.ToString();
            int intSeq = 0;
            string strMessage = "";

            if (result == "XXX")
            {
                XMessageBox.Show("入院取り消しに失敗しました。", "警告", MessageBoxIcon.Exclamation);
                return false;
            }

            if (result.Substring(0, 1) == "Y")
            {
                intSeq ++;
                strMessage += intSeq.ToString() + ".　転入処理されたオーダがあります。　転入処理を取り消してください。\r\n\r\n"; 

            }
            if (result.Substring(1, 1) == "Y")
            {
                intSeq++;
                strMessage += intSeq.ToString() + ".　実施されたオーダがあります。　実施を取り消してください。\r\n\r\n"; 
            }
            if (result.Substring(2, 1) == "Y")
            {
                intSeq++;
                strMessage += intSeq.ToString() + ".　入院登録後発生したオーダがあります。　キャンセルしてください。\r\n\r\n"; 
            }

            if (intSeq != 0)
            {
                strMessage += "入院取り消しが出来ませんでした。　処理後また行ってください。";
                XMessageBox.Show(strMessage, "警告", MessageBoxIcon.Exclamation);
                return false;
            }            

            /*
			if(TypeCheck.IsNull(retVal))
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원취소를 하시겠습니까?" : "入院取消を行いますか。");
				this.mCap = (NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ");

				icon = MessageBoxIcon.Question;
			}
			else
			{
				if(retVal.ToString() == "Y")
				{
                    //this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원오더가 존재합니다. 그래도 입원취소를 하시겠습니까?\n입원취소시 발생한 오더는 모두 삭제 됩니다."
                    //    : "入院オーダが存在します。 このまま,入院取消を行いますか。\n入院取消を行えば、オーダ情報は全て削除されます。");
                    //this.mCap = (NetInfo.Language == LangMode.Ko ? "경고" : "警告");

                    this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원오더가 존재합니다. 그래도 입원취소를 하시겠습니까?\n입원취소시 발생한 오더는 모두 삭제 됩니다."
                        : "登録されている入院時オーダがあります。\r\n 入院オーダは取り消します。");
                    this.mCap = (NetInfo.Language == LangMode.Ko ? "경고" : "警告");

                    icon = MessageBoxIcon.Warning;
                    //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, icon);
                    //return false;
				}
				else
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원취소를 하시겠습니까?" : "入院取消を行いますか。");
					this.mCap = (NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ");

					icon = MessageBoxIcon.Question;
				}
			}


            DialogResult result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, icon);

			if (result != DialogResult.Yes)
			{
				return false;
			}
            
            */


            cmdText = string.Empty;
			bindVars.Clear();
			retVal = null;


			ArrayList inputList = new ArrayList();
			ArrayList outputList = new ArrayList();

            /* 입원취소 */
			inputList.Add(UserInfo.UserID);
			inputList.Add(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"));
            inputList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

			if(!Service.ExecuteProcedure("PR_INP_IPWON_CANCEL", inputList, outputList))
			{
				XMessageBox.Show(Service.ErrFullMsg + "\r\n PR_INP_IPWON_CANCEL Error");
				return false;
			}
			else
			{
				if(outputList[0].ToString() != "0")
				{
                    XMessageBox.Show(Service.ErrFullMsg + outputList[0].ToString() + "\r\n PR_INP_IPWON_CANCEL Error Code");
					return false;
				}
			}

            this.mMsg = NetInfo.Language == LangMode.Ko ? "입원취소가 완료 되었습니다." : "入院取消が完了しました。";
            this.mCap = NetInfo.Language == LangMode.Ko ? "취소완료" : "取消完了";

            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);             

            return true;
		}

		#endregion

		#endregion

		#region XPatientBox 

		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			// 환자가 바뀌면 일단 플레그들은 클리어
			this.CompClear();

            // 이벤트 두번 타는 문제 임시 해결
            this.paBox.PatientSelected -= new System.EventHandler(this.paBox_PatientSelected);

			this.btnList.PerformClick(FunctionType.Query);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
		}

		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			this.btnList.PerformClick(FunctionType.Reset);
		}

		#region Component Clear

		private void CompClear()
		{
			// 입원정보
			this.dtpIpwonDate.ResetData();
			this.txtIpwonTime.Clear();
			this.dtpGisanDate.ResetData();
			this.emkGisanJaewonIlsu.Clear();
			this.fbxGwa.Clear();
			this.fbxDoctor.Clear();
			this.fbxJisiDoctor.Clear();
			this.cboChojae.ResetData();
			this.dbxHoDong.ResetData();
			this.dbxHoCode.ResetData();
			this.dbxBedNo.ResetData();
			this.cboHoGrade1.ResetData();
			this.cboIpwonRtn2.ResetData();
			this.cboBabyStatus.ResetData();
			this.cboIpwonType.ResetData();
            this.fbxGubun.ResetData();
            this.dbxGubunName.ResetData();
            this.cboKaikei_HoDong.ResetData();
            this.cboKaikei_HoCode.ResetData();
            this.cboEmergencyGubun.ResetData();
            this.mbxEmergencyDetail.ResetData();
        }

		#endregion

		#endregion

		#region XButtonList

        private string tMSG = "";
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query :

					#region 조회

                    e.IsBaseCall = false;
                    this.dbxGubunName.SetDataValue("");

					ClearFlag();

					if (this.IsValidPatient() == false)
					{
						this.btnList.PerformClick(FunctionType.Reset);
					}

					// 재원 체크
					///////////////////////////////////////////////////////////////////////////////////////////////////////////
					// 입원등록하는 경우
                    if (this.mPaInfo.PKINP1001 == null || this.mPaInfo.PKINP1001 == "")
					{
						this.MakeIpwonTypeCombo("1");  // 입원등록용으로 구성

						this.MakeIpwonData();
                        isNew = true;

					}
						///////////////////////////////////////////////////////////////////////////////////////////////////////////
						// 조회의 경우
					else
					{
						this.MakeIpwonTypeCombo("2");  // 입원 조회용으로 구성

						this.LoadIpwonData();
                        isNew = false;
					}

					// 보험 정보 조회
                    //this.LoadBoheomInfo(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));

					// 환자 특기사항 조회
					this.LoadOUT0106();

					// 공비정보 조회
                    this.LoadGongbiQuery();

					// 내원 이력 조회
					this.LoadNaewonHis();

					// 보증인 정보 로드
					this.LoadKeyPerson();

					// 보험 리스트
                    this.LoadIpwonTypeList();

					#endregion

					break;

				case FunctionType.Insert :

					#region 삽입

					e.IsBaseCall = false;

					if (this.paBox.BunHo == "")
					{
						return;
					}

					this.grdINP1004.InsertRow(-1);

					this.DefaultSettingINP1004();

                    this.pnlINP1004.Enabled = true;

					this.txtName2.Focus();

					#endregion

					break;

				case FunctionType.Delete :

					#region 삭제

					e.IsBaseCall = false;

					this.grdINP1004.DeleteRow(grdINP1004.CurrentRowNumber);

					this.ProtectKeyPersonInfo();

                    if (grdINP1004.RowCount == 0)
                    {
                        pnlINP1004.Enabled = false;
                    }

					#endregion

					break;

				case FunctionType.Update :
                    
                    #region 업데이트
                    tMSG = "";
                    e.IsBaseCall = false;

                        /*
                        if (this.dtpIpwonDate.GetDataValue() != this.dtpGisanDate.GetDataValue())
                        {
                            //타원입원일이 기산일일 경우에 메세지뿌림
                            this.layCheckEctIpwon.QueryLayout();

                            if (layCheckEctIpwon.GetItemValue("ipwon_type").ToString() == "7")
                            {
                                DialogResult dr = XMessageBox.Show("入院日と起算日が異なります。\r\n" +
                                "他院履歴がある場合にはSAKURAにも入院履歴を登録する必要があります。\r\n"+
                                "　・SAKURAでの登録済みの場合には「Yes」クリックして入院登録を完了してください。\r\n" +
                                "　・未登録の場合には「No」をクリックしてSAKURA登録を行ってください。","確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (dr == DialogResult.No)
                                    return;
                            }

                        }
                        */

                    this.AcceptData();

                        // 일단은 보험정보의 업데이트 데이터를 만들어내고
                        //this.MakeUpdateINP1002();

                    if (this.CheckINP1001() == false //||
                        //this.CheckINP1002() == false || //보험정보체크 김보현
                        //this.CheckINP1008() == false  //공비정보체크
                        )
                    {
                        return;
                    }

                    this.grdINP1004.SaveLayout();

                    try
                    {

                        //if (!this.layINP1002Update.SaveLayout())
                        //    throw new Exception();


                        //if (!this.grdINP1008.SaveLayout())
                        //    throw new Exception();

                        //
                        Service.BeginTransaction();

                        ArrayList inputList = new ArrayList();
                        ArrayList outputList = new ArrayList();
                        inputList.Add(UserInfo.UserID);
                        inputList.Add(dtpIpwonDate.GetDataValue());
                        inputList.Add(this.paBox.BunHo);
                        inputList.Add(this.fbxGwa.GetDataValue());
                        inputList.Add(this.fbxGubun.GetDataValue());
                        inputList.Add(this.fbxDoctor.GetDataValue());
                        inputList.Add("I");
                        inputList.Add(this.fbxGwa.GetDataValue());
                        inputList.Add("0");
                        inputList.Add(DBNull.Value);
                        inputList.Add(DBNull.Value);

                        if (!Service.ExecuteProcedure("PR_INP_UPDATE_OUT0103", inputList, outputList))
                        {
                            throw new Exception();
                            //return;
                        }


                        //진료 종료 여부 확인.
                        if(grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "fkout1001") != "")
                        {
                            BindVarCollection bindVar= new BindVarCollection();

                            string sqlCmd = @"SELECT NAEWON_YN
                                                FROM OUT1001 A
                                               WHERE A.HOSP_CODE = :f_hosp_code 
                                                 AND A.PKOUT1001 = :f_fkout1001";

                            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                            bindVar.Add("f_fkout1001", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "fkout1001"));

                            object retVal = Service.ExecuteScalar(sqlCmd, bindVar);

                            if (!TypeCheck.IsNull(retVal) && retVal.ToString() != "E")
                            {
                                XMessageBox.Show(paBox.SuName + "さんはまだ診療終了されてません。先生に確認してください。", "確認", MessageBoxIcon.Warning);
                                throw new Exception(paBox.SuName + "さんはまだ診療終了されてません。先生に確認してください。");
                            }
                        }
                        


                        if (grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "retrieve_yn") != "Y")// 새로 등록된 경우만 저장
                        {
                            if (this.grdINP1001.SaveLayout())// 저장 성공시 사쿠라 전송
                            {
                                Service.CommitTransaction();
                                SakuraIpwonInput("I");
                            }
                            else
                            {
                                throw new Exception();
                            }

                            if (IpwonSiksaInput("I"))
                            {
                                XMessageBox.Show("基本食事が生成されました。");
                            }
                        }
                        else
                        {
                            this.tMSG = "入院登録情報は既に保存されています。\r\n 入院登録情報を修正する場合は、入院取り消してください。";
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        //mPKINP1002 = t_pkinp1002;
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : "保存出来ませんでした。";
                        this.mMsg += "\r\n" + tMSG + "\r\n" + Service.ErrFullMsg;

                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        Service.RollbackTransaction();

                        return;
                    }

                    this.mMsg = NetInfo.Language == LangMode.Ko ? "정상적으로 저장 되었습니다." : "保存しました。";
                    this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PopupNUR1001R09();

                    this.btnList.PerformClick(FunctionType.Query);

                    #endregion
                    
                    break;

				case FunctionType.Reset :

					break;
			}
		}

        private bool IpwonSiksaInput(string aIUD_GUBUN)
        {
            string data_date = this.dtpIpwonDate.GetDataValue();
            string pkinp1001 = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "pkinp1001");
            string bunho = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "bunho");

            /*
             I_HOSP_CODE   IN VARCHAR2
            , I_PKINP1001   IN NUMBER
            , I_BUNHO       IN NUMBER
            , I_IPWON_DATE  IN DATE
            , I_IUD_GUBUN   IN VARCHAR2
             */
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(pkinp1001);
            inputList.Add(bunho);
            inputList.Add(data_date);
            inputList.Add(aIUD_GUBUN);
            if (Service.ExecuteProcedure("PR_OCS_INIT_CREATE_SIKSA", inputList, outputList))
                return true;
            else
                return false;
        }


        private void SakuraIpwonInput(string proc_gubun)
        {
            string data_date = this.dtpIpwonDate.GetDataValue();
            string ho_dong = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "kaikei_hodong");
            string ho_code = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "kaikei_hocode");
            string bed_no = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "bed_no");
            string gwa = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "ipwon_gwa");
            string doctor = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "doctor");   
            string pkinp1001 = this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "pkinp1001");

            SakuraChangeTrans("1", proc_gubun, this.paBox.BunHo, data_date, ho_dong, ho_code, bed_no, gwa, doctor, pkinp1001, UserInfo.UserID, "");

        }

        /// <summary>
        /// 転科転室転送情報作成(IFS3011)
        /// PR_IFS_MAKE_IPWON_HISTORY 사용
        /// </summary>
        /// <param name="data_gubun">入院：1, 転入：2, 退院：4</param>
        /// 
        /// <param name="proc_gubun">登録：I, 修正：U, 削除：D</param>
        /// <param name="bunho">患者番号</param>
        /// <param name="data_date">データ日付</param>
        /// <param name="ho_dong">棟コード</param>
        /// <param name="ho_code">室コード</param>
        /// <param name="bed_no">床コード</param>
        /// <param name="gwa">科コード</param>
        /// <param name="doctor">医師コード</param>
        /// <param name="pkinp1001">PKINP1001</param>
        /// <param name="userid">登録者ID</param>
        /// <param name="toiwon_gubun">[""可] 治癒：１、死亡：２、中止：３、他移：４、転医：５、転科：６、軽快：７、転棟：８、転室：９</param>

        private void SakuraChangeTrans(string data_gubun, string proc_gubun, string bunho, string data_date, string ho_dong, string ho_code, string bed_no, string gwa, string doctor, string pkinp1001, string userid, string toiwon_gubun)
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(proc_gubun);
            inputList.Add(bunho);
            inputList.Add(data_date);
            inputList.Add(ho_dong);
            inputList.Add(ho_code);
            inputList.Add("");//inputList.Add(bed_no);    SAKURAには病床の情報は送らない。　20130621
            inputList.Add(gwa);
            inputList.Add(doctor);
            inputList.Add(pkinp1001);
            inputList.Add(userid);
            inputList.Add(data_gubun);
            inputList.Add(toiwon_gubun);

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

        }

        private void OrcaIpwonInput()
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(this.paBox.BunHo);
            inputList.Add(this.dtpIpwonDate.GetDataValue());
            inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "pkinp1001"));
            inputList.Add(this.mPKINP1002);
            inputList.Add(System.Guid.NewGuid().ToString());
            inputList.Add(System.Guid.NewGuid().ToString());
            inputList.Add(System.Guid.NewGuid().ToString());
            inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "doctor"));
            inputList.Add(UserInfo.UserID);

            if (!Service.ExecuteProcedure("PR_OIF_MAKE_IPWON_INPUT", inputList, outputList))
            {
                this.mMsg = "ORCAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg;
                this.mCap = "処理失敗";

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (outputList[1].ToString() != "0")
                {
                    this.mMsg = "ORCAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg;
                    this.mCap = "処理失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                IHIS.Framework.tcpHelper Helper = new tcpHelper();
                
                int ret = Helper.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), outputList[0].ToString());

                if (ret == -1)
                {
                    this.mMsg = "ORCAへのデータ転送に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg;
                    this.mCap = "転送失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;                
                }

                this.mMsg = "ORCAへのデータ転送が完了しました。";
                this.mCap = "転送完了";
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Reset :

                    this.ClearFlag();

					this.InitScreen();

					break;
			}		
		}

		#endregion

		#region XButton
		/// <summary>
		/// 베드 선택 화면 오픈
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBedButton_Click(object sender, System.EventArgs e)
		{
			if (this.grdINP1001.RowCount <= 0 ||
				this.paBox.BunHo == ""        ||
				this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) != DataRowState.Added ||
				this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_type") == mAddedOrderType)
			{
				return;
			}

			this.OpenScreen_BAS0250Q00();
		}

		/// <summary>
		/// 특기사항 등록
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRegOUT0106_Click(object sender, System.EventArgs e)
		{
			this.OpenScreen_OUT0106U00();

			this.LoadOUT0106();
		}

		/// <summary>
		/// 환자별 공비등록
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRegOUT0105_Click(object sender, System.EventArgs e)
		{
            this.OpenScreen_OUT0101U02();

            this.LoadGongbiQuery();
		}

		/// <summary>
		/// 입원일 변경 폼 오픈
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTransDate_Click(object sender, System.EventArgs e)
		{
			if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001") == "" ||
				this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) == DataRowState.Added)
			{
                this.mMsg = NetInfo.Language == LangMode.Ko ? "입원 등록후 사용이 가능 합니다." : "入院情報を保存してからご使用ください。";
				this.mCap = NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

				return ;
			}

			this.OpenForm_IpwonDateTrans();

			this.LoadIpwonData();
		}

		/// <summary>
		/// 입원 취소
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnIpwonCancel_Click(object sender, System.EventArgs e)
		{
			if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001") == "" ||
				this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) == DataRowState.Added)
			{
                this.mMsg = NetInfo.Language == LangMode.Ko ? "입원 등록후 사용이 가능 합니다." : "まだ入院登録されていないので入院取消しできません。";
				this.mCap = NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

				return ;
			}

			// 입원시 오더 발생여부 
			// 입력된 오더가 있으면 물어보고 취소한다.
			if (this.IpwonCancel() == true)
            {
                if (IpwonSiksaInput("D"))
                {
                    XMessageBox.Show("基本食事が削除されました。");
                }

                //OrcaIpwonCancelInput();
                SakuraIpwonInput("D");
                

				this.btnList.PerformClick(FunctionType.Query);
			}
		}

        private void OrcaIpwonCancelInput()
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(this.paBox.BunHo);
            inputList.Add(this.dtpIpwonDate.GetDataValue());
            inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "pkinp1001"));
            inputList.Add(this.mPKINP1002);
            inputList.Add(System.Guid.NewGuid().ToString());
            inputList.Add(System.Guid.NewGuid().ToString());
            inputList.Add(System.Guid.NewGuid().ToString());
            inputList.Add(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "doctor"));
            inputList.Add(UserInfo.UserID);

            if (!Service.ExecuteProcedure("PR_OIF_MAKE_IPWON_CANCEL_INPUT", inputList, outputList))
            {
                this.mMsg = "ORCAへのデータ処理に失敗しました。\r\n ORCAにて入院取消しを行ってください。\r\n" + Service.ErrFullMsg;
                this.mCap = "処理失敗";

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (outputList[1].ToString() != "0")
                {
                    this.mMsg = "ORCAへのデータ処理に失敗しました。\r\n ORCAにて入院取消しを行ってください。\r\n" + Service.ErrFullMsg;
                    this.mCap = "処理失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                IHIS.Framework.tcpHelper Helper = new tcpHelper();
                int ret = Helper.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), outputList[0].ToString());

                if (ret == -1)
                {
                    this.mMsg = "ORCAへのデータ転送に失敗しました。\r\n ORCAにて入院取消しを行ってください。\r\n" + Service.ErrFullMsg;
                    this.mCap = "転送失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.mMsg = "ORCAへのデータ転送が完了しました。";
                this.mCap = "転送完了";
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

		/// <summary>
		/// 입원 전입
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnIpwonTrans_Click(object sender, System.EventArgs e)
		{
			if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001") == "" ||
				this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) == DataRowState.Added)
			{
				this.mMsg = NetInfo.Language == LangMode.Ko ? "입원 등록후 사용이 가능 합니다." : "入院情報を保存してからご使用ください。";
				this.mCap = NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

				return ;
			}

            //if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "check_trans_yn") == "0")
            //{
            //    this.mMsg = NetInfo.Language == LangMode.Ko ? "전입할 데이터가 없습니다." : "転入するデータがありません。";
            //    this.mCap = NetInfo.Language == LangMode.Ko ? "입원전입" : "入院転入";

            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    return;
            //}

			this.OpenScreen_INP2001U02();

		}

		/// <summary>
		/// 복수 보험 등록 폼 오픈
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRegDoubleType_Click(object sender, System.EventArgs e)
		{
			if (this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001") == "" ||
				this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) == DataRowState.Added)
			{
                this.mMsg = NetInfo.Language == LangMode.Ko ? "입원등록후 사용이 가능 합니다." : "入院情報を保存してからご使用ください。";
				this.mCap = NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

				return;
			}

			this.OpenForm_DoubleTypeRegForm();

			this.btnList.PerformClick(FunctionType.Query);
		}

		#endregion

		#region XFindBox

		#region FindClick

		private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XFindBox control = sender as XFindBox;

			switch (control.Name)
			{
				case "fbxGwa":

					#region 진료과

                    fwkCommon.AutoQuery = true;
                    fwkCommon.ServerFilter = false;

                    fwkCommon.InputSQL = @"SELECT A.GWA
                                                , A.GWA_NAME
                                                , A.BUSEO_CODE
                                             FROM BAS0260 A
                                            WHERE A.HOSP_CODE   = :f_hosp_code
                                              AND A.BUSEO_GUBUN = '1'  /*진료과*/
                                              AND :f_buseo_ymd BETWEEN A.START_DATE AND A.END_DATE
                                              AND(A.GWA       LIKE '%' || :f_find1 || '%'
                                               OR A.GWA_NAME  LIKE '%' || :f_find1 || '%')
                                              AND A.IPWON_YN    = 'Y'
                                            ORDER BY A.GWA";

                    fwkCommon.BindVarList.Clear();
                    fwkCommon.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                    //fwkCommon.BindVarList.Add("f_buseo_ymd", this.grdINP1002.GetItemString(grdINP1002.CurrentRowNumber, "gubun_ipwon_date"));
                    fwkCommon.BindVarList.Add("f_buseo_ymd", this.dtpIpwonDate.GetDataValue());

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("gwa", "診療科", FindColType.String, 80, 0, true, FilterType.No);
                    this.fwkCommon.ColInfos.Add("gwa_name", "診療科名", FindColType.String, 200, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;

				case "fbxDoctor":

					#region 주치의

                    fwkCommon.AutoQuery = true;
                    fwkCommon.ServerFilter = false;

                    fwkCommon.InputSQL = @"SELECT DOCTOR 
                                                 , DOCTOR_NAME
                                              FROM BAS0270
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND DOCTOR_GWA = :f_gwa
                                               AND :f_ipwon_date BETWEEN START_DATE AND END_DATE
                                             ORDER BY DOCTOR ";

                    fwkCommon.BindVarList.Clear();
                    fwkCommon.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                    fwkCommon.BindVarList.Add("f_gwa", this.fbxGwa.GetDataValue());
                    fwkCommon.BindVarList.Add("f_ipwon_date", this.dtpIpwonDate.GetDataValue());

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("doctor", "医師コード", FindColType.String, 70, 0, true, FilterType.No);
                    this.fwkCommon.ColInfos.Add("doctor_name", "医師名", FindColType.String, 160, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[1].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;

				case "fbxJisiDoctor":

					#region 지시의

                    fwkCommon.AutoQuery = true;
                    fwkCommon.ServerFilter = false;

                    fwkCommon.InputSQL = @"SELECT DOCTOR 
                                                 , DOCTOR_NAME
                                              FROM BAS0270
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND DOCTOR_GWA = :f_gwa
                                               AND :f_ipwon_date BETWEEN START_DATE AND END_DATE
                                             ORDER BY DOCTOR ";

                    fwkCommon.BindVarList.Clear();
                    fwkCommon.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                    fwkCommon.BindVarList.Add("f_gwa", this.fbxGwa.GetDataValue());
                    fwkCommon.BindVarList.Add("f_ipwon_date", this.dtpIpwonDate.GetDataValue());

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("doctor", "医師コード", FindColType.String, 70, 0, true, FilterType.No);
                    this.fwkCommon.ColInfos.Add("doctor_name", "医師名", FindColType.String, 160, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[1].ColAlign = HorizontalAlignment.Center;

					#endregion

					break;

					// 우편번호 창 Open
				case "fbxZipCode1":
					OpenScreen_BAS0123Q00("zipCode", fbxZipCode1.GetDataValue(), txtZipCode2.GetDataValue(), "");
					break;

					// 우편번호 창 Open
				case "fbxAddress1":

					OpenScreen_BAS0123Q00( "address", "", "", fbxAddress1.GetDataValue() );

					break;

                case "fbxBoninGubun":

                    fwkCommon.InputSQL = @"SELECT A.CODE
                                                , A.CODE_NAME
                                             FROM BAS0102 A
                                            WHERE A.HOSP_CODE = :f_hosp_code 
                                              AND A.CODE_TYPE = :f_code_type
                                              AND(A.CODE      LIKE '%' || :f_find1 || '%'
                                               OR A.CODE_NAME LIKE '%' || :f_find1 || '%' )
                                            ORDER BY 1";

                    fwkCommon.BindVarList.Clear();
                    fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    fwkCommon.SetBindVarValue("f_code_type", "BONIN_GUBUN");
                    fwkCommon.SetBindVarValue("f_find1", fbxBoninGubun.GetDataValue());

                    fwkCommon.ColInfos.Clear();
                    fwkCommon.ColInfos.Add("code", "コード", FindColType.String, 60, 0, true, FilterType.InitYes);
                    fwkCommon.ColInfos.Add("code_name", "コード名称", FindColType.String, 240, 0, true, FilterType.InitYes);

                    fwkCommon.ColInfos[0].ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gwa_name", "");
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_gwa", "");
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_gwa_name", "");
						this.fbxDoctor.SetEditValue("");
						this.fbxDoctor.AcceptData();
						this.fbxJisiDoctor.SetEditValue("");
						this.fbxJisiDoctor.AcceptData();

						this.SetMsg("");

						return;
					}

					name = NURI.Methodes.GetGwaNameBAS0260(e.DataValue, this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));

					if (name == "")
					{
						this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과가 정확하지않습니다. 확인바랍니다." : "診療科コードが有効ではありません。";

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}
					else
					{
						this.dbxGwaName.SetDataValue(name);
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gwa_name", name);
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_gwa", e.DataValue);
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "ipwon_gwa_name", name);
						this.fbxDoctor.SetEditValue("");
						this.fbxDoctor.AcceptData();
						this.fbxJisiDoctor.SetEditValue("");
						this.fbxJisiDoctor.AcceptData();
					}

					// 초재진 구분 셋팅
                    this.SetChojaeGubun(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date")
                        , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho")
                        , e.DataValue
                        , this.fbxGubun.GetDataValue());

					this.SetMsg("");

					#endregion

					break;

				case "fbxDoctor":

					#region 주치의

					if (e.DataValue == "")
					{
						this.dbxDoctorName.SetDataValue("");
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "doctor_name", "");
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "resident", "");
						
						this.SetMsg("");

						return ;
					}

					name = NURI.Methodes.GetDoctorNameBAS0270(e.DataValue,
						this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "gwa"),
						this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));

					if (name == "")
					{
						this.mMsg = NetInfo.Language == LangMode.Ko ? "의사코드가 정확하지않습니다. 확인바랍니다." : "医師コードが有効ではありません。";

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}
					else
					{
						this.dbxDoctorName.SetDataValue(name);
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "doctor_name", name);

						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "resident", e.DataValue);
					}

					this.SetMsg("");

					#endregion

					break;

				case "fbxJisiDoctor":

					#region 지시의

					if (e.DataValue == "")
					{
						this.dbxJisiDoctorName.SetDataValue("");
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jisi_doctor_name", "");
						
						this.SetMsg("");

						return ;
					}

					name = NURI.Methodes.GetDoctorNameBAS0270(e.DataValue,
						this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "gwa"),
						this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));

					if (name == "")
					{
						this.mMsg = NetInfo.Language == LangMode.Ko ? "의사코드가 정확하지않습니다. 확인바랍니다." : "医師コードが有効ではありません。";

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}
					else
					{
						this.dbxJisiDoctorName.SetDataValue(name);
						this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "jisi_doctor_name", name);
					}

					this.SetMsg("");

					#endregion

					break;

                case "fbxGubun" :
                    this.dbxGubunName.ResetData();

                    this.GetLastCheckDate(e.DataValue);
                    if (this.GubunValidating(e.DataValue) == false)
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "보험정보가 유효하지 않습니다." : "保険情報が有効ではありません。";
                        this.SetMsg(this.mMsg, MsgType.Error);
                        e.Cancel = true;
                        return;
                    }

                    // 보험 정보 체크
                    this.CheckBoheomInfo();

                    // 초재진 구분 셋팅
                    this.SetChojaeGubun(this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date")
                        , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho")
                        , this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "gwa")
                        , e.DataValue);

                    // 공비 정보 로드
                    //this.LoadGongbiQuery();

                    break;

                
				case "fbxBoninGubun":

					#region 본인과의 관계

					if (e.DataValue == "")
					{
						//this.dbxBoninGubunName.SetDataValue("");
						this.grdINP1004.SetItemValue(grdINP1004.CurrentRowNumber, "bonin_gubun_name", "");

						this.SetMsg("");

						return;
					}

					name = NURI.Methodes.GetCodeNameBAS0102("BONIN_GUBUN", e.DataValue);

					if (name == "")
					{
						this.mMsg = NetInfo.Language == LangMode.Ko ? "본인여부코드가 정확하지않습니다. 확인바랍니다." : "関係コードが有効ではありません。";

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}
					else
					{
						//this.dbxBoninGubunName.SetDataValue(name);
						this.grdINP1004.SetItemValue(grdINP1004.CurrentRowNumber, "bonin_gubun_name", name);
					}

					this.SetMsg("");

					#endregion

					break;
			}
		}

		#endregion

		#endregion

		#region XEditMask

		/// <summary>
		/// 우편번호 벨리데이팅
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtZipCode2_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string name = "";

			if (e.DataValue == "")
			{
				this.fbxAddress1.SetEditValue("");
				this.fbxAddress1.AcceptData();
				this.txtAddress2.SetEditValue("");
				this.txtAddress2.AcceptData();

				this.SetMsg("");
				
				return;
			}

            name = NURI.Methodes.GetZipName(this.fbxAddress1.GetDataValue(), e.DataValue);

			this.fbxAddress1.SetEditValue(name);
			this.fbxAddress1.AcceptData();

			this.txtAddress2.SetEditValue("");
			this.txtAddress2.AcceptData();
		}

		#endregion

		#region XEditGrid

		#region 입원마스터 그리드

		private void grdINP1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			this.ProtectIpwonInfo();

            /* 20110413
			if (this.grdINP1001.GetItemString(e.CurrentRow, "double_type_exist_yn") == "Y")
			{
				this.pbxDoubleTypeYN.Visible = true;
			}
			else
			{
				this.pbxDoubleTypeYN.Visible = false;
			}
             * */
		}

		#endregion


		#region 보증인정보 그리드

		private void grdINP1004_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			this.ProtectKeyPersonInfo();
		}

		#endregion

		#region 공비정보 그리드

		private void grdINP1008_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
            if (this.grdINP1001.GetRowState(grdINP1001.CurrentRowNumber) != DataRowState.Added)
            {
                e.Protect = true;
            }
		}

		#endregion

		#endregion

		#region Command

		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch (command)
			{
				case "BAS0250Q00":
					this.dbxHoDong.SetDataValue(NURI.Methodes.GetGwaNameBAS0260(commandParam["ho_dong"].ToString()
						,this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date")));
					this.dbxHoCode.SetDataValue(commandParam["ho_code"].ToString());
					this.dbxBedNo.SetDataValue(commandParam["bed_no"].ToString());
					this.cboHoGrade1.SetDataValue(commandParam["ho_grade"].ToString());
					this.grdINP1001.SetItemValue(0, "ho_dong1", commandParam["ho_dong"].ToString());
					this.grdINP1001.SetItemValue(0, "ho_code1", commandParam["ho_code"].ToString() );
					this.grdINP1001.SetItemValue(0, "bed_no", commandParam["bed_no"].ToString() );
                    this.grdINP1001.SetItemValue(0, "ho_grade1", commandParam["ho_grade"].ToString());

                    this.grdINP1001.SetItemValue(0, "kaikei_hodong", commandParam["ho_dong"].ToString());
                    this.grdINP1001.SetItemValue(0, "kaikei_hocode", commandParam["ho_code"].ToString());
                    this.grdINP1001.SetItemValue(0, "changed_yn", "Y");
                    
                    this.cboKaikei_HoDong.SetDataValue(commandParam["ho_dong"].ToString());
                    this.cboKaikei_HoDong.AcceptData();
                    this.cboKaikei_HoCode.SetDataValue(commandParam["ho_code"].ToString());
                    this.cboKaikei_HoCode.AcceptData();

					break;

				case "BAS0123Q00":
					this.fbxZipCode1.SetDataValue(commandParam["zip_code1"]);
					this.txtZipCode2.SetDataValue(commandParam["zip_code2"]);
					this.fbxAddress1.SetDataValue(commandParam["address"]);
					this.grdINP1004.SetItemValue(grdINP1004.CurrentRowNumber, "zip_code1", commandParam["zip_code1"]);
					this.grdINP1004.SetItemValue(grdINP1004.CurrentRowNumber, "zip_code2", commandParam["zip_code2"]);
					this.grdINP1004.SetItemValue(grdINP1004.CurrentRowNumber, "address1" , commandParam["address"]);

					break;				
			}

			return base.Command (command, commandParam);
		}


		#endregion

		#region XDatePicker

		// 입원일자 변경시
		private void dtpIpwonDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			// 입원일자 변경시
			// 실 입원일자 동일하게 셋팅
			// 차트 입원일자 동일하게 셋팅
			// 보험 다시 로드 ( 입원가능한 보험으로 다시 로드 )
			// 원래는 초재진구분도 다시 로드 해야 하지만 보험을 다시 로드 하면서 
			// 초재진구분이 다시 셋팅되므로 여기선 뺀다.

			if (e.DataValue == "")
			{
				// 경고 메세지 
				this.mMsg = NetInfo.Language == LangMode.Ko ? "입원일자는 반드시 입력해야할 항목 입니다." : "入院日は必須入力項目です。";
				this.mCap = NetInfo.Language == LangMode.Ko ? "입원일" : "入院日";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

				return;
			}

            dtpGisanDate.SetDataValue(dtpIpwonDate.GetDataValue());
		}

		#endregion

		#region XComboBox

		// 입원 유형
		private void cboIpwonType_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			switch (e.DataValue)
			{
				case mAddedOrderType:    // 퇴원후 추가처방

                    this.mIsAddedOrderType = true;

                    if (this.ApplyAddedOrderType() == false)
                    {
                        // 플레그 클리어 하고
                        this.ClearFlag();

                        this.btnList.PerformClick(FunctionType.Query);

                        return;
                    }

					break;
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

		#region 저장로직
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private INP1001U01 parent = null;

			public XSavePerformer(INP1001U01 parent)
			{
				this.parent = parent;
			}

			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdQry = null; //저장 쿼리용
                
				string cmdText = string.Empty; //임시쿼리용
				BindVarCollection bindVars = new BindVarCollection();
				object retVal = null;
				DataTable retTab = null;

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
				item.BindVarList.Add("f_user_id", UserInfo.UserID);                

				if(callerID == '1')
				{
                    //if(Convert.ToDateTime(item.BindVarList["f_gisan_ipwon_date"].VarValue)
                    //    > Convert.ToDateTime(item.BindVarList["f_ipwon_date"].VarValue))
                    //{
                    //    XMessageBox.Show(EnvironInfo.GetServerMsg(3639));
                    //    return false;
                    //}

					cmdText = string.Empty;
					bindVars.Clear();

                    //cmdText = @"SELECT FN_INP_IS_VALID_GISAN_DATE (:f_gisan_ipwon_date, :f_ipwon_date, :f_bunho) FROM DUAL";

                    //retVal = null;
                    //retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                    //if(!TypeCheck.IsNull(retVal))
                    //{
                    //    if(retVal.ToString() != "Y")
                    //    {
                    //        parent.tMSG = EnvironInfo.GetServerMsg(3640);
                    //        return false;
                    //    }
                    //}
                    //else
                    //{
                    //    parent.tMSG = EnvironInfo.GetServerMsg(3640);
                    //    return false;
                    //}


					switch(item.RowState)
					{
						case DataRowState.Added:

							#region Insert

							cmdText = string.Empty;
							bindVars.Clear();

							if(item.BindVarList["f_ipwon_type"].VarValue == "0")
							{
								cmdText = string.Empty;
								bindVars.Clear();

								cmdText = @"SELECT A.PKINP1001
												 , A.JAEWON_FLAG 
											  FROM INP1001 A
											 WHERE A.HOSP_CODE           = :f_hosp_code
                                               AND A.BUNHO               = :f_bunho
											   AND A.JAEWON_FLAG         = 'Y'
											   AND NVL(A.CANCEL_YN, 'N') = 'N'
											   AND A.IPWON_DATE         <= NVL(:f_ipwon_date , TRUNC(SYSDATE))
											 ORDER BY A.IPWON_DATE";

								retTab = null;
								retTab = Service.ExecuteDataTable(cmdText, item.BindVarList);
                                if (retTab.Rows.Count < 1)
								{
								}
								else
								{
									if(retTab.Rows[0]["jaewon_flag"].ToString() == "Y")
                                    {
                                        parent.tMSG = EnvironInfo.GetServerMsg(293); //現在在院中の患者です。
										return false;
									}
								}
							}

							if(item.BindVarList["f_chojae"].VarValue == "")
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(3278); //初再診コードを入力してください。
								return false;
							}

							cmdText = string.Empty;
							bindVars.Clear();

                            cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS ( SELECT 'X'
                                                          FROM BAS0260 A
                                                         WHERE A.HOSP_CODE = :f_hosp_code
                                                           AND A.GWA       = :f_ipwon_gwa
                                                           AND :f_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";

							retVal = null;
							retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
							if(TypeCheck.IsNull(retVal))
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(297); //診療科が正確ではありません。確認してください。
								return false;
							}
							else
							{
								if(retVal.ToString() != "Y")
                                {
                                    parent.tMSG = EnvironInfo.GetServerMsg(297);
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
                                                           AND :f_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";

                            //bindVars.Add("f_gwa", item.BindVarList["f_ipwon_gwa"].VarValue);
                            //bindVars.Add("f_doctor", item.BindVarList["f_doctor"].VarValue);
                            //bindVars.Add("f_doctor_ymd", item.BindVarList["f_sil_ipwon_date"].VarValue);

							retVal = null;
							retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
							if(TypeCheck.IsNull(retVal))
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(298); //主治医が正確ではありません。確認してください。
								return false;
							}
							else
							{
								if(retVal.ToString() != "Y")
                                {
                                    parent.tMSG = EnvironInfo.GetServerMsg(298);
									return false;
								}
							}

							if(item.BindVarList["f_ipwon_date"].VarValue == "")
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(327); //入院日がありません。確認してください。
								return false;
							}

                            if (item.BindVarList["f_ipwon_time"].VarValue.Replace(":", "") == "" )
                                //item.BindVarList["f_ipwon_time"].VarValue.Replace(":", "") == "0000")
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(328);//入院時間がありません。確認してください。
								return false; 
							}

							if(item.BindVarList["f_ipwon_type"].VarValue == "")
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(330);//入院タイプが正確ではありません。確認してください。
								return false;
							}

							if((item.BindVarList["f_ipwon_type"].VarValue != "2")
								&& (item.BindVarList["f_ipwon_type"].VarValue != "3"))
							{
								cmdText = string.Empty;
								bindVars.Clear();

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0260 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.GWA       = :f_ho_dong1
                                                               AND :f_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";

								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(TypeCheck.IsNull(retVal))
                                {
                                    parent.tMSG = EnvironInfo.GetServerMsg(3317);//病棟コードが正確ではありません。確認してください。
									return false;
								}
								else
								{
									if(retVal.ToString() != "Y")
                                    {
                                        parent.tMSG = EnvironInfo.GetServerMsg(3317);
										return false;
									}
								}

								cmdText = string.Empty;
								bindVars.Clear();

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0250 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.HO_DONG   = :f_ho_dong1
                                                               AND A.HO_CODE   = :f_ho_code1
                                                               AND :f_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";

								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(TypeCheck.IsNull(retVal))
                                {
                                    parent.tMSG = EnvironInfo.GetServerMsg(3318); //病室コードが正確ではありません。確認してください。
									return false;
								}
								else
								{
									if(retVal.ToString() != "Y")
                                    {
                                        parent.tMSG = EnvironInfo.GetServerMsg(3318);
										return false;
									}
								}

								cmdText = string.Empty;
								bindVars.Clear();

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0253 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND A.HO_DONG   = :f_ho_dong1
                                                               AND A.HO_CODE   = :f_ho_code1
                                                               AND A.BED_NO    = :f_bed_no
                                                               AND :f_ipwon_date BETWEEN A.FROM_BED_DATE 
                                                                                     AND NVL(A.TO_BED_DATE, '9998/12/31'))";
								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(TypeCheck.IsNull(retVal))
                                {
                                    parent.tMSG = EnvironInfo.GetServerMsg(3319); //病床が正確ではありません。確認してください。
									return false;
								}
								else
								{
									if(retVal.ToString() != "Y")
                                    {
                                        parent.tMSG = EnvironInfo.GetServerMsg(3319);
										return false;
									}
								}

								if(( item.BindVarList["f_ho_dong1"].VarValue == "")
								  ||(item.BindVarList["f_ho_code1"].VarValue == "")
								  ||(item.BindVarList["f_bed_no"].VarValue == ""))
                                {
                                    parent.tMSG = EnvironInfo.GetServerMsg(331);//病棟、病室、病床情報がありません。確認してください。
									return false;
								}

								cmdText = string.Empty;
								bindVars.Clear();

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM INP1001
                                                             WHERE HOSP_CODE   = :f_hosp_code
                                                               AND JAEWON_FLAG = 'Y'
                                                               AND NVL(CANCEL_YN, 'N') = 'N'
                                                               AND NVL(TOIWON_CANCEL_YN, 'N') = 'N'
                                                               AND HO_DONG1    = :f_ho_dong1
                                                               AND HO_CODE1    = :f_ho_code1
                                                               AND BED_NO      = :f_bed_no   )";
								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(!TypeCheck.IsNull(retVal))
								{
									if(retVal.ToString() == "Y")
                                    {
                                        parent.tMSG = EnvironInfo.GetServerMsg(295); //既に入院している病床です。
										return false;
									}
								}

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0250 B
                                                                 , BAS0253 A
                                                             WHERE A.HOSP_CODE = :f_hosp_code
                                                               AND B.HOSP_CODE = A.HOSP_CODE 
                                                               AND A.HO_CODE   = :f_ho_code1
                                                               AND A.BED_NO    = :f_bed_no
                                                               AND A.HO_CODE   = B.HO_CODE 
                                                               AND B.HO_DONG   = :f_ho_dong1
                                                               AND A.HO_DONG   = B.HO_DONG
                                                               AND A.BED_STATUS NOT IN ('00', '01') 
                                                               AND :f_ipwon_date BETWEEN B.START_DATE AND B.END_DATE )";								
								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(!TypeCheck.IsNull(retVal))
								{
									if(retVal.ToString() == "Y")
                                    {
                                        parent.tMSG = EnvironInfo.GetServerMsg(296);//入院が可能な状態の病床ではありません。
										return false;
									}
								}
							}

							if((item.BindVarList["f_fkinp1003"].VarValue == "")
								||(item.BindVarList["f_fkinp1003"].VarValue != "")
								&&(item.BindVarList["f_pkinp1001"].VarValue == ""))
							{
								cmdText = string.Empty;
								bindVars.Clear();

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM INP1003 A
                                                             WHERE A.HOSP_CODE      = :f_hosp_code 
                                                               AND A.BUNHO          = :f_bunho
                                                               AND A.RESER_END_TYPE = '0'
                                                               AND A.RESER_DATE     >=  TRUNC(SYSDATE) -1
                                                               AND A.RESER_FKINP1001 IS NOT NULL )";

                                //bindVars.Add("f_bunho", item.BindVarList["f_bunho"].VarValue);
								
								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

								if(!TypeCheck.IsNull(retVal))
								{
									if(retVal.ToString() == "Y")
                                    {
                                        parent.tMSG = EnvironInfo.GetServerMsg(3443); //入院時オーダが存在します。入院登録を再度してください。
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
								retVal = Service.ExecuteScalar(cmdText);
								if(TypeCheck.IsNull(retVal))
								{
									XMessageBox.Show("INP1001_SEQ.NEXTVAL Error");
									return false;
								}

								parent.mIpwonsi_Order = "N";
								item.BindVarList.Add("f_pkinp1001", retVal.ToString());
							}
							else
							{
								parent.mIpwonsi_Order = "Y";
							}
							
							if(item.BindVarList["f_pkinp1001"].VarValue == "")
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(321); //入院キーを探せません。
								return false;
							}

							if(item.BindVarList["f_ipwon_type"].VarValue != "2")
							{
								item.BindVarList.Add("f_fk_inp_key", item.BindVarList["f_pkinp1001"].VarValue);
							}
							else
							{
								cmdText = string.Empty;
								bindVars.Clear();

                                cmdText = @"SELECT A.PKINP1001
                                              FROM INP1001 A
                                             WHERE A.HOSP_CODE           = :f_hosp_code
                                               AND A.BUNHO               = :f_bunho
                                               AND A.JAEWON_FLAG         = 'Y'
                                               AND NVL(A.CANCEL_YN, 'N') = 'N'
                                               AND A.IPWON_TYPE          = '0'";
								
								
								retVal = null;
								retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
								if(!TypeCheck.IsNull(retVal))
								{
									item.BindVarList.Add("f_fk_inp_key", retVal.ToString());
								}
							}

							parent.mPkinp1001_1 = item.BindVarList["f_pkinp1001"].VarValue;
							parent.mIpwon_type = item.BindVarList["f_ipwon_type"].VarValue;
							parent.mHo_dong1 = item.BindVarList["f_ho_dong1"].VarValue;
							parent.mHo_code1 = item.BindVarList["f_ho_code1"].VarValue;
							parent.mBed_no = item.BindVarList["f_bed_no"].VarValue;
							parent.mDoctor = item.BindVarList["f_doctor"].VarValue;
							parent.mIpwon_date = item.BindVarList["f_ipwon_date"].VarValue;

                            item.BindVarList.Add("t_ipwon_time", item.BindVarList["f_ipwon_time"].VarValue.Replace(":", ""));
                            cmdQry = @"INSERT INTO INP1001
                                            ( SYS_DATE          , SYS_ID            , UPD_DATE          , UPD_ID
                                            , HOSP_CODE         , PKINP1001         , BUNHO             , IPWON_DATE
                                            , IPWON_TYPE        , IPWON_TIME        , IPWON_GWA         , GWA
                                            , DOCTOR            , RESIDENT          
                                            , HO_CODE1          , HO_DONG1          , HO_CODE2          , HO_DONG2
                                            , IPWON_RTN2        , CHOJAE            , BABY_STATUS       , INP_TRANS_YN
                                            , FKOUT1001         , JAEWON_FLAG       , TOIWON_GOJI_YN    
                                            , TOIWON_RES_DATE   , TOIWON_RES_TIME   , GA_TOIWON_DATE    
                                            , TOIWON_DATE       , TOIWON_TIME       , RESULT            , SIGI_MAGAM_YN        , SIMSA_MAGAM_GUBUN
                                            , CANCEL_DATE       , CANCEL_USER       , CANCEL_YN         , FKINP1003
                                            , TEAM              , SIMSA_MAGAMJA     , SIMSA_MAGAM_DATE  , SIMSA_MAGAM_TIME
                                            , GISAN_IPWON_DATE  , BED_NO            , GISAN_JAEWON_ILSU , JISI_DOCTOR           
                                            , FK_INP_KEY        , HO_GRADE1         , EMERGENCY_GUBUN   , EMERGENCY_DETAIL 
                                            , KAIKEI_HODONG     , KAIKEI_HOCODE      )
                                       VALUES
                                            ( SYSDATE               , :f_user_id        , SYSDATE               , :f_user_id
                                            , :f_hosp_code          , :f_pkinp1001      , :f_bunho              , :f_ipwon_date
                                            , :f_ipwon_type         , REPLACE(:t_ipwon_time,':')     , :f_ipwon_gwa          , :f_gwa
                                            , :f_doctor             , :f_resident       
                                            , :f_ho_code1           , :f_ho_dong1       , :f_ho_code2           , :f_ho_dong2
                                            , :f_ipwon_rtn2         , :f_chojae         , :f_baby_status        , :f_inp_trans_yn
                                            , :f_fkout1001          , :f_jaewon_flag    , :f_toiwon_goji_yn
                                            , :f_toiwon_res_date    , NULL              , :f_ga_toiwon_date
                                            , :f_toiwon_date        , :f_toiwon_time    , :f_result             , :f_sigi_magam_yn   , :f_simsa_magam_yn
                                            , :f_cancel_date        , :f_cancel_user    , :f_cancel_yn          , :f_fkinp1003
                                            , :f_team               , NULL              , NULL                  , NULL
                                            , :f_ipwon_date /* :f_gisan_ipwon_date */   , :f_bed_no         , :f_gisan_jaewon_ilsu  , :f_jisi_doctor    
                                            , :f_fk_inp_key         , :f_ho_grade1      , :f_emergency_gubun    , :f_emergency_detail 
                                            , :f_kaikei_hodong      , :f_kaikei_hocode   )";

							if(!Service.ExecuteNonQuery(cmdQry, item.BindVarList))
                            {
                                parent.tMSG = "INP1001 Insert Error";
								return false;
							}

							cmdText = string.Empty;
							bindVars.Clear();

							cmdText = @"SELECT FN_OUT_CHECK_JUBSU_CNT(:f_bunho, :f_ipwon_date) FROM DUAL";											
							retVal = null;
							retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
							if(TypeCheck.IsNull(retVal))
                            {
                                parent.tMSG = "FN_OUT_CHECK_JUBSU_CNT Error";
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
                                parent.tMSG = EnvironInfo.GetServerMsg(321);//入院キーを探せません。
								return false;
							}

							if(item.BindVarList["f_bunho"].VarValue == "")
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(283);//患者番号を入力してください。
								return false;
							}

							parent.mPkinp1001_1 = item.BindVarList["f_pkinp1001"].VarValue;
							parent.mIpwon_type = item.BindVarList["f_ipwon_date"].VarValue;
							parent.mHo_dong1 = item.BindVarList["f_ho_dong1"].VarValue;
							parent.mHo_code1 = item.BindVarList["f_ho_code1"].VarValue;
							parent.mBed_no = item.BindVarList["f_bed_no"].VarValue;
							parent.mDoctor = item.BindVarList["f_doctor"].VarValue;
							parent.mIpwon_date = item.BindVarList["f_ipwon_date"].VarValue;

                            item.BindVarList.Add("t_ipwon_time", item.BindVarList["f_ipwon_time"].VarValue.Replace(":", ""));
                            cmdQry = @"UPDATE INP1001
                                          SET UPD_ID                = :f_user_id
                                            , UPD_DATE              = SYSDATE
                                            , IPWON_TIME            = REPLACE(:t_ipwon_time,':') 
                                            , IPWON_GWA             = :f_ipwon_gwa
                                            , GWA                   = :f_gwa
                                            , DOCTOR                = :f_doctor
                                            , RESIDENT              = :f_resident
                                            , HO_CODE1              = :f_ho_code1
                                            , HO_DONG1              = :f_ho_dong1
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
                                            , SIMSA_MAGAM_GUBUN     = :f_simsa_magam_yn
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
                                            , IPWON_TYPE            = :f_ipwon_type
                                            , HO_GRADE1             = :f_ho_grade1
                                            , EMERGENCY_GUBUN       = :f_emergency_gubun
                                            , EMERGENCY_DETAIL      = :f_emergency_detail
                                            , KAIKEI_HODONG         = :f_kaikei_hodong
                                            , KAIKEI_HOCODE         = :f_kaikei_hocode
                                        WHERE HOSP_CODE             = :f_hosp_code
                                          AND PKINP1001             = :f_pkinp1001";

							#endregion

							break;

						case DataRowState.Deleted:

							break;
					}
                }

                #region layINP1002Update

                if (callerID == '2')
                {
                    /* Fkinp1001값을 가져온다 */
					if(item.BindVarList["f_fkinp1001"].VarValue == "")
					{
						item.BindVarList.Add("f_fkinp1001", parent.mPkinp1001_1);
					}

					switch(item.BindVarList["f_iud_gubun"].VarValue)
					{
						case "I":  

							#region Insert

                            /*****************************PKINP1001 NULL체크 */
							if(item.BindVarList["f_fkinp1001"].VarValue == "")
							{
								if(parent.mPkinp1001_1 == "")
                                {
                                    parent.tMSG = "INP1001 PK is NULL";
									return false;
								}

								item.BindVarList.Add("f_fkinp1001", parent.mPkinp1001_1);
							}

							if(item.BindVarList["f_fkinp1001"].VarValue == "")
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(340);//在院者マスタキーを探せません。
								return false;
							}

							cmdText = string.Empty;
							bindVars.Clear();

                            cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS ( SELECT 'X'
                                                          FROM BAS0210 A
                                                         WHERE A.HOSP_CODE = :f_hosp_code
                                                           AND A.GUBUN     = :f_gubun
                                                           AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";

							retVal = null;
							retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
							if(TypeCheck.IsNull(retVal))
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(338); //保険者番号が正確ではありません。確認してください。
								return false;
							}
							else
							{
								if(retVal.ToString() != "Y")
                                {
                                    parent.tMSG = EnvironInfo.GetServerMsg(338);
									return false;
								}
							}


                            cmdText = @"SELECT NVL(A.GONGBI_YN, 'Y')
                                          FROM BAS0210 A
                                         WHERE A.HOSP_CODE = :f_hosp_code
                                           AND A.GUBUN     = :f_gubun
                                           AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND A.END_DATE";
                            
                            //retTab = null;
                            //retTab = Service.ExecuteDataTable(cmdText, item.BindVarList);
                            retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if ((TypeCheck.IsNull(retVal)))
                            {
                                XMessageBox.Show(EnvironInfo.GetServerMsg(361)); //保険チェック情報の取り込み中にエラーが発生しました。
                                return false;
                            }

                            string gongbiYN = retVal.ToString();

                            string mJohap_Gubun = string.Empty;

                            cmdText = string.Empty;

                            cmdText = @"SELECT A.JOHAP_GUBUN
                                          FROM BAS0210 A
                                         WHERE A.HOSP_CODE = :f_hosp_code 
                                           AND A.GUBUN     = :f_gubun
                                           AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND END_DATE";

                            retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                            if(TypeCheck.IsNull(retVal))
                            {
                                // 테스트 모드 아닐때 데이타가 다 안들어 있어서 테스트 모드일 경우 안타짐
                                if(!parent.btnTest.Visible)
                                {
                                    parent.tMSG = EnvironInfo.GetServerMsg(334);//保険者番号の取り込み中にエラーが発生しました。
                                    return false;
                                }

                            }
                            else
                            {
                                if(retVal.ToString().Length > 0)
                                {
                                    mJohap_Gubun = retVal.ToString();
                                }
                            }

                            int rNum_age = 0;
							
                            cmdText = string.Empty;
                            bindVars.Clear();

                            cmdText = @"SELECT FN_BAS_LOAD_AGE(TRUNC(SYSDATE), A.BIRTH, 'XXXX')
										  FROM OUT0101 A
										 WHERE A.HOSP_CODE = :f_hosp_code 
                                           AND A.BUNHO     = :f_bunho";

                            retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if(TypeCheck.IsNull(retVal))
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(352);//年齢の取り込み中にエラーが発生しました。
                                return false;
                            }
                            else
                            {
                                rNum_age = Convert.ToInt32(retVal.ToString());
                            }

                                                        //if ((retTab.Rows[0][0].ToString() == "Y") && (item.BindVarList["f_from_jy_date"].VarValue == ""))
                            if ((gongbiYN == "Y") && (item.BindVarList["f_from_jy_date"].VarValue == ""))
                            {
                                XMessageBox.Show(EnvironInfo.GetServerMsg(358)); //保険情報の適用日がありません。
                                return false;
                            }
                            
                            ArrayList inputList = new ArrayList();
							ArrayList outputList = new ArrayList();

							inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
							inputList.Add(item.BindVarList["f_gubun"].VarValue);

							if(!Service.ExecuteProcedure("PR_INP_MAKE_PKINP1002", inputList, outputList))
                            {
                                parent.tMSG = "PR_INP_MAKE_PKINP1002 Error";
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
                                parent.tMSG = EnvironInfo.GetServerMsg(189); //保険別マスタキーを作るのに失敗しました。
								return false;
							}

                            cmdQry = @"INSERT INTO INP1002
                                            ( SYS_DATE            , SYS_ID             , UPD_DATE           , UPD_ID
                                            , HOSP_CODE           , PKINP1002          , FKINP1001          , BUNHO
                                            , GUBUN               , SEQ                , GUBUN_TRANS_DATE   , GUBUN_IPWON_DATE
                                            , GUBUN_TOIWON_DATE   , GUBUN_TRANS_CNT    , GUBUN_TRANS_YN     , SIMSAJA
                                            , SIMSA_MAGAM_YN      )
                                       VALUES
                                            ( SYSDATE             , :f_user_id         , SYSDATE            , :f_user_id
                                            , :f_hosp_code        , :f_pkinp1002       , :f_fkinp1001       , :f_bunho
                                            , :f_gubun            , :f_seq             , NULL               , TO_DATE(:f_gubun_ipwon_date, 'YYYY/MM/DD')
                                            , NULL                , :f_gubun_trans_cnt , :f_gubun_trans_yn  , NULL
                                            , :f_simsa_magam_yn   )";

							if(!Service.ExecuteNonQuery(cmdQry, item.BindVarList))
                            {
                                parent.tMSG = "INP1002 Insert Error";
								return false;
							}

							if(parent.mIpwonsi_Order == "Y")
							{
								inputList.Clear();
								outputList.Clear();

								inputList.Add(UserInfo.UserID);
								inputList.Add(item.BindVarList["f_bunho"].VarValue);
								inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);

								if(!Service.ExecuteProcedure("PR_OCS_UPDATE_INP_ORDER_RES", inputList, outputList))
                                {
                                    parent.tMSG = "PR_OCS_UPDATE_INP_ORDER_RES Error";
									return false;
								}
								else
								{
									if((outputList[1].ToString() != "0")&&(outputList[1].ToString() != "1"))
									{
										XMessageBox.Show(outputList[0].ToString());
										return false;
									}
								}

                                
								inputList.Clear();
								outputList.Clear();                                
                            
                            }

//                            if(parent.mIpwon_type == "0")
//                            {
//                                cmdText = string.Empty;
//                                bindVars.Clear();

//                                cmdText = @"SELECT A.IP_ADDR    IP_ADDR
//											  FROM NUR0106 A
//											 WHERE A.HOSP_CODE = :f_hosp_code 
//                                               AND A.HO_DONG   = :f_ho_dong1";

//                                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//                                bindVars.Add("f_ho_dong1", parent.mHo_dong1);

//                                retTab = null;
//                                retTab = Service.ExecuteDataTable(cmdText, bindVars);

//                                if (retTab.Rows.Count < 1)
//                                {
//                                    parent.tMSG = "IP_ADDR Query Error";
//                                    return false;
//                                }
//                                else
//                                {
//                                    for(int i=0; i < retTab.Rows.Count; i++)
//                                    {
//                                        string ip = retTab.Rows[i]["ip_addr"].ToString();

//                                        cmdText = string.Empty;
//                                        bindVars.Clear();

//                                        cmdText = @"SELECT :f_bunho  || ',' || :f_ho_code1 || ',' ||
//														   :f_bed_no || ',' || FN_BAS_LOAD_DOCTOR_NAME(:f_doctor, :f_ipwon_date) || ',' ||
//														   A.SUNAME
//													  FROM OUT0101 A
//													 WHERE A.HOSP_CODE = :f_hosp_code 
//                                                       AND A.BUNHO     = :f_bunho";

//                                        bindVars.Add("f_hosp_code" , item.BindVarList["f_hosp_code"].VarValue);
//                                        bindVars.Add("f_bunho"     , item.BindVarList["f_bunho"].VarValue);
//                                        bindVars.Add("f_ho_code1"  , parent.mHo_code1);
//                                        bindVars.Add("f_bed_no"    , parent.mBed_no);
//                                        bindVars.Add("f_doctor"    , parent.mDoctor);
//                                        bindVars.Add("f_ipwon_date", Convert.ToDateTime(parent.mIpwon_date).ToString("yyyy/MM/dd"));

//                                        retVal = null;
//                                        retVal = Service.ExecuteScalar(cmdText, bindVars);

//                                        if(TypeCheck.IsNull(retVal))
//                                        {
//                                            parent.tMSG = "Ipwon Msg is null";
//                                            return false;
//                                        }

//                                        XMsgSender.SendToSystem(ip, "NURI", "IPWONMSG", retVal.ToString());
//                                    }
//                                }

//                                inputList.Clear();
//                                outputList.Clear();

//                                inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
//                                inputList.Add(item.BindVarList["f_pkinp1002"].VarValue);
//                                inputList.Add(UserInfo.UserID);

//                                //if(!Service.ExecuteProcedure("PR_INP_COMPUTE_JINCHAL_JPN", inputList, outputList))
//                                //{
//                                //    XMessageBox.Show(Service.ErrFullMsg + " : PR_INP_COMPUTE_JINCHAL_JPN Error");
//                                //    return false;
//                                //}
//                                //else
//                                //{
//                                //    if(outputList[0].ToString() != "0")
//                                //    {
//                                //        XMessageBox.Show(EnvironInfo.GetServerMsg(3279));
//                                //        return false;
//                                //    }
//                                //}
//                            }

							return true;

							#endregion

						case "U":

//                            #region Update

//                            cmdQry = @"UPDATE INP1002
//										  SET UPD_ID           = :f_user_id
//											, UPD_DATE         = SYSDATE
//											, SELF_HANDO_GUBUN = :f_self_hando_gubun
//											, SIKSA_BON_GUBUN  = :f_siksa_bon_gubun
//											--, PATIENT_GUBUN    = :f_patient_gubun
//										WHERE HOSP_CODE        = :f_hosp_code 
//                                          AND PKINP1002        = :f_pkinp1002";

//                            #endregion

							break;
					}
                }

                #endregion


                if (callerID == '3')
				{
					switch(item.RowState)
					{
                        case DataRowState.Added:
                            retVal = Service.ExecuteScalar(@"SELECT NVL(MAX(A.SEQ),0) + 1 SEQ 
                                                                   FROM INP1004 A 
                                                                  WHERE A.HOSP_CODE = '" + item.BindVarList["f_hosp_code"].VarValue + "'"
                                                            + " AND A.BUNHO     = '" + parent.paBox.BunHo + "'");

                            item.BindVarList.Add("f_seq", retVal.ToString());

                            cmdQry = @"INSERT INTO INP1004 ( SYS_DATE,      SYS_ID,         UPD_DATE,     UPD_ID,  
                                                                  HOSP_CODE,     SEQ
                                                                , BUNHO,         NAME,           ZIP_CODE1,    ZIP_CODE2
                                                                , ADDRESS1,      ADDRESS2,       TEL1,         TEL2
                                                                , BIGO,          BONIN_GUBUN,    TEL3,         TEL_GUBUN
                                                                , TEL_GUBUN2,    TEL_GUBUN3,     NAME2,        PRIORITY
                                                                , BIRTH,         WITH_YN,        LIVE_YN                )
                                                          VALUES( SYSDATE,       :f_user_id,     SYSDATE,      :f_user_id, 
                                                                  :f_hosp_code,  :f_seq, 
                                                                  :f_bunho,      :f_name,        :f_zip_code1, :f_zip_code2
                                                                , :f_address1,   :f_address2,    :f_tel1,      :f_tel2
                                                                , :f_bigo,       :f_bonin_gubun, :f_tel3,      :f_tel_gubun
                                                                , :f_tel_gubun2, :f_tel_gubun3,  :f_name2,     :f_priority
                                                                , :f_birth,      :f_with_yn,     :f_live_yn             )";
                            break;

                        case DataRowState.Modified:
                            if (TypeCheck.IsNull(item.BindVarList["f_seq"].VarValue))
                            {
                                XMessageBox.Show("保証人順番が見つかりません。", "エラー", MessageBoxIcon.Error);
                                return false;
                            }
                            cmdQry = @"UPDATE INP1004
                                               SET UPD_ID      = :f_user_id
                                                 , UPD_DATE    = SYSDATE
                                                 , NAME        = :f_name
                                                 , ZIP_CODE1   = :f_zip_code1
                                                 , ZIP_CODE2   = :f_zip_code2
                                                 , ADDRESS1    = :f_address1
                                                 , ADDRESS2    = :f_address2
                                                 , TEL1        = :f_tel1
                                                 , TEL2        = :f_tel2
                                                 , BIGO        = :f_bigo
                                                 , BONIN_GUBUN = :f_bonin_gubun
                                                 , TEL3        = :f_tel3
                                                 , TEL_GUBUN   = :f_tel_gubun
                                                 , TEL_GUBUN2  = :f_tel_gubun2
                                                 , TEL_GUBUN3  = :f_tel_gubun3
                                                 , NAME2       = :f_name2
                                                 , PRIORITY    = :f_priority 
                                                 , BIRTH       = :f_birth
                                                 , WITH_YN     = :f_with_yn
                                                 , LIVE_YN     = :f_live_yn
                                             WHERE HOSP_CODE   = :f_hosp_code 
                                               AND BUNHO       = :f_bunho
                                               AND SEQ         = :f_seq";
                            break;
                        case DataRowState.Deleted:
                            cmdQry = @"DELETE FROM INP1004
    	    	    	                     WHERE HOSP_CODE   = :f_hosp_code 
                                               AND BUNHO     = :f_bunho
    	    	    	                       AND SEQ       = :f_seq";
                            break;
					}
                }

                #region callerID == '4'
                //////////////////////////////////////////////////////////////////////////////
                if (callerID == '4')
                {
                    item.BindVarList.Add("f_pkinp1002", parent.mPKINP1002);
                    switch (item.BindVarList["f_check_yn"].VarValue)
                    {
                        case "Y":

                            #region Check_Y

                            if (item.BindVarList["f_fkinp1002"].VarValue == "")
                            {
                                if (item.BindVarList["f_pkinp1002"].VarValue == "")
                                {
                                    parent.tMSG = "INP1002 PK is null";
                                    return false;
                                }

                                item.BindVarList.Add("f_fkinp1002", item.BindVarList["f_pkinp1002"].VarValue);
                            }

                            if (item.BindVarList["f_fkinp1002"].VarValue == "")
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(190); //保険別マスタキーを探せません。
                                return false;
                            }

                            cmdText = string.Empty;
                            bindVars.Clear();

                            cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS ( SELECT 'X'
                                                          FROM OUT0105 A
                                                         WHERE A.HOSP_CODE     = :f_hosp_code 
                                                           AND A.BUNHO         = :f_bunho
                                                           AND A.GONGBI_CODE   = :f_gongbi_code
                                                           AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND END_DATE )";

                            retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                            if (TypeCheck.IsNull(retVal))
                            {
                                parent.tMSG = EnvironInfo.GetServerMsg(359);//公費が正確ではありません。確認してください。
                                return false;
                            }
                            else
                            {
                                if (retVal.ToString() != "Y")
                                {
                                    parent.tMSG = EnvironInfo.GetServerMsg(359);
                                    return false;
                                }
                            }

                            cmdQry = @"DECLARE
                                        BEGIN

                                        UPDATE INP1008
                                            SET UPD_ID         = :f_user_id
                                              , UPD_DATE       = SYSDATE
                                              , BUNHO          = :f_bunho
                                              , PRIORITY       = :f_priority
                                          WHERE HOSP_CODE      = :f_hosp_code 
                                            AND FKINP1002      = :f_fkinp1002
                                            AND GONGBI_CODE    = :f_gongbi_code;

                                        IF SQL%NOTFOUND THEN
                                        INSERT INTO INP1008
                                            ( SYS_DATE
                                            , SYS_ID
                                            , UPD_DATE
                                            , UPD_ID
                                            , HOSP_CODE 
                                            , FKINP1002
                                            , GONGBI_CODE
                                            , BUNHO      
                                            , PRIORITY    )
                                        VALUES(SYSDATE
                                            , :f_user_id
                                            , SYSDATE
                                            , :f_user_id
                                            , :f_hosp_code
                                            , :f_fkinp1002
                                            , :f_gongbi_code
                                            , :f_bunho  
                                            , :f_priority  );
										     
                                        END IF;
                                        END;";

                            cmdQry = cmdQry.Replace("\r", " ");
                            #endregion

                            break;

                        case "N":

                            #region Check_N

                            if (item.BindVarList["f_fkinp1002"].VarValue == "")
                            {
                                if (item.BindVarList["f_pkinp1002"].VarValue == "")
                                {
                                    parent.tMSG = "INP1002 PK is null";
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
                ///////////////////////////////////////////////////////////////////////////
                #endregion

                return Service.ExecuteNonQuery(cmdQry, item.BindVarList);
			}
		}
		#endregion

        private void fwkGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkGubun.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
            fwkGubun.BindVarList.Add("f_bunho", this.paBox.BunHo);
            fwkGubun.BindVarList.Add("f_naewon_date", this.dtpIpwonDate.GetDataValue());
        }

        private void fbxGubun_FindSelected(object sender, FindEventArgs e)
        {
            this.mGubun = this.fbxGubun.GetDataValue();
            //this.dbxGubunName = e.ReturnValues[1].ToString();
            this.dtpLastCheckDate.SetDataValue(e.ReturnValues[2].ToString());
            this.mGongbiYN = e.ReturnValues[3].ToString();
        }

        #region GubunValidating
        private bool GubunValidating(string aGubun)
        {
            string name = "";

            if (aGubun == "")
            {
                this.SetMsg("");

                return true;
            }
            name = IHIS.NURI.Methodes.GetGubunName(aGubun, this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));

            if (name == "")
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "보험정보가 유효하지 않습니다." : "保険情報が有効ではありません。";

                //this.SetMsg(this.mMsg, MsgType.Error);

                return false;
            }

            //this.grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gubun_name", name);
            this.dbxGubunName.SetDataValue(name);

            // 3. 공비적용가능여부 체크
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //mBoheomInfo.GetData(aGubun, EnvironInfo.GetSysDate());
            //if (this.mBoheomInfo.GONGBI_YN != "Y")

            this.mGongbiYN = NURI.Methodes.ChkGetGongbiYN(aGubun, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            if (this.mGongbiYN != "Y")
            {
                // 현재 보험이 공비 적용이 안되니깐 
                // 적용할건지 여부를 물어봄
                if (!this.IsApplyNewGubun())
                {
                    // 공비 체크 해제
                    for (int i = 0; i < grdINP1008.RowCount; i++)
                    {
                        grdINP1008.SetItemValue(i, "check", "N");
                    }

                    //grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gongbi_code1", "");
                    //grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gongbi_code2", "");
                    //grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gongbi_code3", "");
                    //grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "gongbi_code4", "");

                    // 공비 체크 해제후 공비 그리드 ReadOnly
                    this.grdINP1008.ReadOnly = true;
                }
                else
                {
                    this.mMsg = (NetInfo.Language == LangMode.Ko ? "보험종류를 다시 선택하세요." : "保険種類を再度選択してください。");
                    this.dbxGubunName.SetDataValue("");
                    this.SetMsg(mMsg, MsgType.Error);

                    return false;
                }
            }
            else
            {
                this.grdINP1008.ReadOnly = false;
            }

            //// 4. 보험탭 선택
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //this.SelectCurrentBoheomTab(aGubun);

            //// 5. 최종확인일 체크
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //this.CheckLastCheckDate(this.dtpIpwonDate.GetDataValue());

            return true;
        }
        #endregion

        #region 최종확인일 체크

        private void CheckLastCheckDate(string aNaewonDate)
        {
            DateTime lastCheckDate;
            DateTime currentDate;
            bool isShowMsg = false;

            if (this.dtpLastCheckDate.GetDataValue() == "")
            {
                isShowMsg = true;
            }

            if (isShowMsg == false)
            {
                lastCheckDate = DateTime.Parse(this.dtpLastCheckDate.GetDataValue());
                currentDate = DateTime.Parse(aNaewonDate);

                if (lastCheckDate.Year <= currentDate.Year &&
                    lastCheckDate.Month < currentDate.Month)
                {
                    isShowMsg = true;
                }
            }

            if (isShowMsg == true)
            {
                this.mMsg = (NetInfo.Language == LangMode.Ko ? "마지막으로 보험을 확인한 일이 1개월 이전입니다.보험정보를 확인해주세요."
                    : "保険の最終確認日付が1ヶ月以前です。保険を確認してください。");
                this.mCap = (NetInfo.Language == LangMode.Ko ? "보험확인" : "保険確認");

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region 공비 적용 여부 메세지(공비 적용 못하는 보험일 경우)
        private bool IsApplyNewGubun()
        {
            this.mMsg = (NetInfo.Language == LangMode.Ko ? "현재 보험종류는 공비를 적용하지 않습니다.\n보험종류를 변경하시겠습니까?"
                : "現在の保険種類は公費の適用ができません。\n保険種類を変更しますか。");
            this.mCap = (NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ");

            if (this.grdINP1008.RowCount <= 0)
                return false;

            if (XMessageBox.Show(mMsg, mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        private void btnResend_Click(object sender, EventArgs e)
        {
            SakuraIpwonInput("I");
            //OrcaIpwonInput();
        }

        private void GetLastCheckDate(string gubun)
        {
            this.layLastCheckDate.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layLastCheckDate.SetBindVarValue("f_gubun", gubun);
            this.layLastCheckDate.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layLastCheckDate.SetBindVarValue("f_date", this.dtpIpwonDate.GetDataValue());

            this.layLastCheckDate.QueryLayout();
        }

        private void grdINP1008_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "check_yn")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    this.AddGongbiCode(e.RowNumber, this.grdINP1008.GetItemString(e.RowNumber, "gongbi_code"));// 공비 우선순위 변경
                    //this.AddGongbi(this.grdGongBi.GetItemString(e.RowNumber, "gongbi_code"));//접수테이블에 삽입
                }
                else
                {
                    // 공비 우선순위 변경하고 접수그리드에서 삭제
                    this.DelGongbiCode(e.RowNumber, this.grdINP1008.GetItemString(e.RowNumber, "gongbi_code"));
                    //this.DeleteGongbi(this.grdGongBi.GetItemString(e.RowNumber, "gongbi_code"));//접수테이블에서 삭제
                }
            }
            this.grdINP1008.AcceptData();

        }

        private void AddGongbiCode(int nCnt, string aGongbiCode)
        {
            DataRow[] dtRow = this.grdINP1008.LayoutTable.Select("check_yn =" + "'Y'");

            int cnt = dtRow.Length + 1;

            this.grdINP1008.SetItemValue(nCnt, "priority", cnt);
        }

        private void DelGongbiCode(int nCnt, string aGongbiCode)
        {
            //if (IsCheckedGongbiCode(aGongbiCode) < 0) return;
            int cnt = nCnt + 1;
            string str = this.grdINP1008.GetItemString(nCnt, "priority");
            DataRow[] dtRow = this.grdINP1008.LayoutTable.Select("priority > " + Int32.Parse(str));
            if (dtRow.Length > 0)
            {
                for (int i = 0; i < this.grdINP1008.RowCount; i++)
                {
                    int nPrior = Int32.Parse(this.grdINP1008.GetItemString(i, "priority"));
                    if (nPrior > Int32.Parse(str))
                    {
                        int num = nPrior - 1;
                        this.grdINP1008.SetItemValue(i, "priority", num);
                    }
                }
            }
            this.grdINP1008.SetItemValue(nCnt, "priority", DBNull.Value);

        }

        private void btnAddEtcIpwon_Click(object sender, EventArgs e)
        {
            EtcIpwon etcIpwon = new EtcIpwon(this.paBox.BunHo, 
                                             dtpIpwonDate.GetDataValue(), 
                                             this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "retrieve_yn"));

            DialogResult dr = etcIpwon.ShowDialog();

            if (etcIpwon.EtcIpwonDate != "")
            {
                if (etcIpwon.EtcToiwonDate != "")
                {
                    DateTime ipwon_date = Convert.ToDateTime(this.dtpIpwonDate.GetDataValue());
                    DateTime gisan_date = Convert.ToDateTime(etcIpwon.EtcToiwonDate);

                    if (ipwon_date <= gisan_date)
                    {
                        XMessageBox.Show("他院履歴の退院日を確認してください。\r\n" +
                                         "他院履歴の退院日は現在の入院の「入院日 - 1」の日付を入力してください。", "他院入院", MessageBoxIcon.Warning);
                        return;
                    }

                    //this.dtpGisanDate.SetDataValue(etcIpwon.EtcIpwonDate);
                    //this.grdINP1001.SetItemValue(this.grdINP1001.CurrentRowNumber, "gisan_ipwon_date", this.dtpGisanDate.GetDataValue());
                    this.grdINP1001.SetItemValue(this.grdINP1001.CurrentRowNumber, "gisan_ipwon_date", this.dtpIpwonDate.GetDataValue());
                    this.grdINP1001.AcceptData();

                }
            }

        }

        private void layCheckEctIpwon_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCheckEctIpwon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layCheckEctIpwon.SetBindVarValue("f_bunho", this.paBox.BunHo);
            //this.layCheckEctIpwon.SetBindVarValue("f_ipwon_date", this.dtpGisanDate.GetDataValue());
            this.layCheckEctIpwon.SetBindVarValue("f_ipwon_date", this.dtpIpwonDate.GetDataValue());
        }

        private void btnChangeGubun_Click(object sender, EventArgs e)
        {
            ChangeGubun cgForm = new ChangeGubun(this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber, "pkinp1001"), this.paBox.BunHo);
            cgForm.ShowDialog();
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void grdINP1004_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdINP1004.RowCount > 0)
            {
                pnlINP1004.Enabled = true;
            }
            else
            {
                pnlINP1004.Enabled = false;
            }
        }

        private void grdINP1004_QueryStarting(object sender, CancelEventArgs e)
        {
            grdINP1004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //grdINP1004.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void dtpBirth_DataValidating(object sender, DataValidatingEventArgs e)
        {
            grdINP1004.SetItemValue(grdINP1004.CurrentRowNumber, "birth", e.DataValue);

            string cmdText = "SELECT FN_BAS_LOAD_AGE(SYSDATE, :f_birth, '') FROM DUAL";
            BindVarCollection inputList = new BindVarCollection();

            inputList.Add("f_birth", dtpBirth.GetDataValue());

            object retval = Service.ExecuteScalar(cmdText, inputList);

            if (retval != null)
            {
                txtAge.Text = retval.ToString();
            }
        }

        private void dtpBirth_DataValidating_1(object sender, DataValidatingEventArgs e)
        {
            string cmdText = "SELECT FN_BAS_LOAD_AGE(SYSDATE, :f_birth, '') FROM DUAL";
            BindVarCollection inputList = new BindVarCollection();

            inputList.Add("f_birth", dtpBirth.GetDataValue());

            object retval = Service.ExecuteScalar(cmdText, inputList);

            if (retval != null)
            {
                txtAge.Text = retval.ToString();
            }
        }

        #region 본인구분을 선택을 했을 때
        private void fbxBoninGubun_FindSelected(object sender, IHIS.Framework.FindEventArgs e)
        {
            this.txtBoninGubunName.SetEditValue(e.ReturnValues[1].ToString());
        }
        #endregion

        private void cboEmergencyGubun_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboEmergencyGubun.SelectedValue != null)
            {
                if (cboEmergencyGubun.SelectedValue.Equals("10"))
                {
                    mbxEmergencyDetail.Visible = true;
                    mbxEmergencyDetail.Enabled = true;
                    return;
                }
            }

            mbxEmergencyDetail.Text = "";
            mbxEmergencyDetail.Visible = false;
            mbxEmergencyDetail.Enabled = false;
        }

        private void cboKaikei_HoDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboKaikei_HoCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            cboKaikei_HoCode.SetBindVarValue("f_kaikei_hodong", cboKaikei_HoDong.GetDataValue());

            if (cboKaikei_HoCode.SetDictDDLB())
            {
                
            };
        }

        private void grdINP1001_ImeModeChanged(object sender, EventArgs e)
        {
            grdINP1001.SetItemValue(grdINP1001.CurrentRowNumber, "changed_yn", "Y");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PopupNUR1001R09();
        }

        private void PopupNUR1001R09()
        {            
            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("ho_dong", grdINP1001.GetItemString(0, "ho_dong1"));
            cic.Add("bunho", grdINP1001.GetItemString(0, "bunho"));
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1001R09", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopCenter, cic);
        }
    }
}

