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
	/// NUR1001U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1001U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string FindName = string.Empty;
		#endregion

		#region 자동생성

        private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditMask xEditMask1;
		private IHIS.Framework.MultiLayout layComboSet;
		private IHIS.Framework.XEditGrid grdINP1001;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XTextBox txtFkinp1001;
        private IHIS.Framework.XTextBox txtBunho;
		private IHIS.Framework.XTextBox txtUpd_gubun;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XFindWorker fwkFind;
        private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.XEditGrid grdNUR1002;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XTextBox txtDrug_comment;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private SingleLayout layINP1001;
        private SingleLayoutItem singleLayoutItem146;
        private SingleLayoutItem singleLayoutItem147;
        private SingleLayoutItem singleLayoutItem148;
        private SingleLayoutItem singleLayoutItem150;
        private SingleLayoutItem singleLayoutItem151;
        private SingleLayoutItem singleLayoutItem153;
        private SingleLayoutItem singleLayoutItem154;
        private SingleLayoutItem singleLayoutItem155;
        private SingleLayoutItem singleLayoutItem156;
        private SingleLayoutItem singleLayoutItem157;
        private SingleLayoutItem singleLayoutItem168;
        private SingleLayoutItem singleLayoutItem169;
        private SingleLayoutItem singleLayoutItem320;
        private SingleLayout layFkinp1001;
        private SingleLayoutItem singleLayoutItem160;
        private MultiLayout layReserInfo;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private SingleLayoutItem singleLayoutItem424;
        private XTabControl tabPatient;
        private IHIS.X.Magic.Controls.TabPage tabPage1;
        private XPanel pnlPatientInfoRight;
        private XLabel xLabel2;
        private XButton btnGanhodoOpen;
        private XDisplayBox dbxNurse;
        private XButton btnTeamOpen;
        private XDisplayBox dbxTeam;
        private XLabel lblTeam;
        private XLabel lblNurse;
        private XPanel pnlPatientInfoLeft;
        private XLabel xLabel3;
        private XDisplayBox dbxHo_Code;
        private XLabel lblBed;
        private XDisplayBox dbxBed;
        private XLabel lblInDate;
        private XDatePicker dtpIndate;
        private XLabel lblDoctor;
        private XLabel lblGwa;
        private XDisplayBox dbxGwa;
        private XDisplayBox dbxDoctor;
        private XLabel lblHo_dong;
        private XDisplayBox dbxHo_Dong;
        private XLabel lblHo_code;
        private XLabel xLabel4;
        private XLabel lblBlood;
        private XLabel lblAddress1;
        private XDisplayBox dbxAddress;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
        private XPanel pnlHealthRight;
        private XButton btnInfe;
        private XButton btnAllergy;
        private XPanel xPanel7;
        private XEditGrid grdNUR1017;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGrid grdNUR1016;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell24;
        private XPanel pnlHealthLeft;
        private XGroupBox gbxBringDrug;
        private XRadioButton rbxBringDrugY;
        private XRadioButton rbxBringDrugN;
        private XMemoBox mbxHealthcare;
        private XMemoBox mbxPastHis;
        private XLabel lblHealthCare;
        private XLabel lblBringDrug;
        private XLabel lblPast_his;
        private IHIS.X.Magic.Controls.TabPage tabPage4;
        private XPanel xPanel8;
        private GroupBox groupBox5;
        private XLabel xLabel71;
        private XLabel xLabel73;
        private XLabel xLabel75;
        private XLabel xLabel76;
        private XPanel pnlFood;
        private GroupBox groupBox4;
        private XLabel xLabel91;
        private XLabel lblAppetite;
        private XLabel lblFood_allergy;
        private IHIS.X.Magic.Controls.TabPage tabPage5;
        private XPanel xPanel9;
        private XPanel xPanel14;
        private IHIS.X.Magic.Controls.TabPage tabPage3;
        private XPanel pnlPerceptionRight;
        private XLabel lblParalysis;
        private XGroupBox gbxStagger;
        private XRadioButton rbxStaggerN;
        private XRadioButton rbxStaggerY;
        private XGroupBox gbxDizzy;
        private XRadioButton rbxDizzyY;
        private XRadioButton rbxDizzyN;
        private XTextBox txtStagger;
        private XTextBox txtDizzy;
        private XLabel lblStagger;
        private XLabel lblDizzy;
        private XPanel pnlPerceptionLeft;
        private XLabel lblSense_style;
        private XLabel lblObstacle;
        private XGroupBox gbxObstacle;
        private XRadioButton rbxObstacleY;
        private XRadioButton rbxObstacleN;
        private XComboBox cboSenseLevel;
        private Splitter splitter5;
        private IHIS.X.Magic.Controls.TabPage tabPage6;
        private XPanel xPanel15;
        private XGroupBox gbxReligion;
        private XRadioButton rbxReligionY;
        private XRadioButton rbxReligionN;
        private XPanel xPanel2;
        private XPanel pnlINP1004;
        private XTextBox txtName2;
        private XLabel xLabel6;
        private XLabel xLabel41;
        private XDictComboBox cboTelGubun2;
        private XDictComboBox cboTelGubun;
        private XFindBox fbxBoninGubun;
        private XEditMask txtTel2;
        private XEditMask txtTel1;
        private XTextBox txtAddress2;
        private XFindBox fbxAddress1;
        private XEditMask txtZipCode2;
        private XFindBox fbxZipCode1;
        private XLabel xLabel17;
        private XEditMask txtSeq;
        private XLabel xLabel21;
        private XTextBox txtBigo;
        private XTextBox txtName;
        private XLabel xLabel22;
        private XLabel xLabel23;
        private XLabel xLabel24;
        private XLabel xLabel26;
        private XLabel xLabel29;
        private XPanel xPanel3;
        private XButton btnDelete;
        private XButton btnInsert;
        private PictureBox pictureBox1;
        private XTextBox txtReligion;
        private XTextBox txtFamily;
        private XComboBox cboHouseKind;
        private XLabel lblFamily;
        private XLabel lblHouse_kind;
        private XLabel lblReligion;
        private XButton btnOrder;
        private XLabel lblSang_name;
        private XMemoBox mbxDiagnosisName;
        private XLabel xLabel78;
        private XDisplayBox dbxTel;
        private XLabel xLabel79;
        private GroupBox groupBox7;
        private XRichTextBox txtAssessment0;
        private GroupBox groupBox8;
        private XTextBox txtExplainF;
        private XTextBox txtExplainP;
        private XTextBox txtExplainD;
        private XLabel xLabel81;
        private XLabel xLabel84;
        private XLabel xLabel85;
        private XLabel lblFoodDislike;
        private XGroupBox gbxFoodDislike;
        private XRadioButton rbxFoodDislikeN;
        private XRadioButton rbxFoodDislikeY;
        private XLabel xLabel80;
        private GroupBox groupBox9;
        private XRichTextBox txtAssessment1;
        private XGroupBox gbxDysphagia;
        private XRadioButton rbxDysphagiaN;
        private XRadioButton rbxDysphagiaY;
        private XLabel lblDysphagia;
        private XTextBox txtAppetite;
        private XGroupBox gbxAppetite;
        private XRadioButton rbxAppetiteN;
        private XRadioButton rbxAppetiteY;
        private XTextBox txtFoodDislike;
        private XLabel xLabel90;
        private XLabel xLabel89;
        private XLabel lblFalseTeeth;
        private XLabel lblMouthPollution;
        private XTextBox txtIntake;
        private XComboBox cboIntakeWay;
        private XLabel xLabel86;
        private XTextBox txtDysphagia;
        private XLabel xLabel93;
        private XLabel xLabel92;
        private XLabel xLabel99;
        private XComboBox cboDungDay;
        private XComboBox cboDungCnt;
        private GroupBox groupBox10;
        private XCheckBox cbxIntermittent;
        private XCheckBox cbxDiapersU;
        private XGroupBox gbxUrinWill;
        private XRadioButton rbxUrinN;
        private XRadioButton rbxUrinWillY;
        private XLabel lblUrinWill;
        private XLabel xLabel97;
        private XComboBox cboUrinDay;
        private XComboBox cboUrinCnt;
        private XLabel xLabel98;
        private XLabel xLabel103;
        private XLabel xLabel104;
        private XLabel xLabel105;
        private XTextBox txtLaxation;
        private XCheckBox cbxAntidiarrheal;
        private XCheckBox cbxSuppository;
        private XCheckBox cbxLaxative;
        private XCheckBox cbxEnema;
        private XLabel xLabel102;
        private XCheckBox cbxOrthotics;
        private XCheckBox cbxDiapersD;
        private XGroupBox gbxDungWill;
        private XRadioButton rbxDungWillN;
        private XRadioButton rbxDungWillY;
        private XTextBox txtDungLast;
        private XTextBox txtDungState;
        private XLabel lblDungWill;
        private XLabel xLabel100;
        private XCheckBox cbxCatheter;
        private XLabel xLabel106;
        private XDatePicker dtpCatheter;
        private XLabel xLabel94;
        private XCheckBox cbxEnterokinesia;
        private XCheckBox cbxAbtominalVery;
        private XCheckBox cbxAbdominal;
        private XLabel xLabel96;
        private XComboBox cboWeightUpdownHow;
        private XTextBox txtFalseTeeth;
        private XComboBox cboWeightUpdownStart;
        private XLabel xLabel108;
        private XGroupBox gbxFalseTeeth;
        private XRadioButton rbxFalseTeethN;
        private XRadioButton rbxFalseTeethY;
        private XLabel xLabel109;
        private XTextBox txtMouthPollution;
        private XGroupBox gbxMouthPollution;
        private XRadioButton rbxMouthPollutionN;
        private XRadioButton rbxMouthPollutionY;
        private GroupBox groupBox11;
        private XRichTextBox txtAssessment2;
        private XTextBox txtBMI;
        private XLabel xLabel111;
        private XLabel xLabel110;
        private GroupBox groupBox12;
        private XTextBox txtWalk_ADL;
        private XComboBox cboWalk_ADL;
        private XLabel xLabel120;
        private XTextBox txtWheelchair_ADL;
        private XComboBox cboWheelchair_ADL;
        private XLabel xLabel119;
        private XTextBox txtBoard_ADL;
        private XComboBox cboBoard_ADL;
        private XLabel xLabel118;
        private XTextBox txtStruggle_ADL;
        private XComboBox cboStruggle_ADL;
        private XLabel xLabel117;
        private XTextBox txtExcretion_ADL;
        private XComboBox cboExcretion_ADL;
        private XLabel xLabel115;
        private XTextBox txtWash_ADL;
        private XComboBox cboWash_ADL;
        private XLabel xLabel114;
        private XTextBox txtCloth_ADL;
        private XComboBox cboCloth_ADL;
        private XLabel xLabel113;
        private XTextBox txtBath_ADL;
        private XComboBox cboBath_ADL;
        private XLabel xLabel112;
        private XTextBox txtFood_ADL;
        private XComboBox cboFood_ADL;
        private XLabel xLabel116;
        private GroupBox groupBox13;
        private XLabel xLabel122;
        private XTextBox txtSleepLess;
        private XCheckBox cbxSleepEtc;
        private XCheckBox cbxTeethGrinding;
        private XCheckBox cbxSleepTalk;
        private XCheckBox cbxSnoring;
        private XLabel xLabel121;
        private XTextBox txtSleepEnough;
        private XLabel lblSleepEnough;
        private XLabel xLabel124;
        private XLabel xLabel125;
        private XLabel xLabel126;
        private XLabel xLabel127;
        private XLabel xLabel128;
        private GroupBox groupBox14;
        private XRichTextBox txtAssessment4;
        private XTextBox txtSleepEtc;
        private XLabel xLabel129;
        private XGroupBox gbxSleepEnough;
        private XRadioButton rbxSleepEnoughN;
        private XRadioButton rbxSleepEnoughY;
        private XLabel lblRecognition;
        private XGroupBox gbxRecognition;
        private XRadioButton rbxRecognitionY;
        private XRadioButton rbxRecognitionN;
        private XGroupBox gbxSensor;
        private XRadioButton rbxSensorY;
        private XRadioButton rbxSensorN;
        private GroupBox gbxSensorDetail;
        private XLabel xLabel137;
        private XLabel xLabel136;
        private XLabel lblEarAid;
        private XLabel lblLens;
        private XLabel lblGlasses;
        private XLabel xLabel132;
        private XLabel xLabel131;
        private XLabel xLabel140;
        private XLabel xLabel138;
        private XDisplayBox dbxHoken;
        private GroupBox groupBox17;
        private GroupBox groupBox16;
        private XTextBox txtInformant;
        private XLabel xLabel139;
        private XLabel xLabel53;
        private XTextBox txtKeyRelation1;
        private XLabel xLabel142;
        private XLabel xLabel141;
        private XTextBox txtKeyName1;
        private XLabel xLabel52;
        private XTextBox txtKeyHome1;
        private XLabel xLabel143;
        private XTextBox txtDrinking;
        private XLabel xLabel145;
        private XLabel xLabel144;
        private XGroupBox gbxHealthCare;
        private XRadioButton rbxHealthcareY;
        private XRadioButton rbxHealthcareN;
        private XMemoBox mbxBringDrugComment;
        private XLabel xLabel146;
        private XLabel xLabel147;
        private XTextBox txtFoodLimit;
        private XLabel xLabel148;
        private XEditGrid grdNUR1029;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XLabel xLabel107;
        private XLabel xLabel149;
        private XLabel xLabel150;
        private GroupBox groupBox18;
        private XTextBox txtCareOffice;
        private XTextBox txtService;
        private XLabel xLabel156;
        private XLabel xLabel157;
        private XLabel lblNeedSupport;
        private XLabel lblNeedCare;
        private XGroupBox gbxNeedSupport;
        private XRadioButton rbxActivitySupport2;
        private XRadioButton rbxActivitySupport1;
        private XGroupBox gbxNeedCare;
        private XRadioButton rbxActivityCare5;
        private XRadioButton rbxActivityCare4;
        private XRadioButton rbxActivityCare3;
        private XRadioButton rbxActivityCare2;
        private XRadioButton rbxActivityCare1;
        private XLabel lblObstacleSpeech;
        private XTextBox txtRecognition;
        private XTextBox txtObstacle;
        private XGroupBox gbxObstacleSense;
        private XRadioButton rbxObstcleSenseY;
        private XRadioButton rbxObstcleSenseN;
        private XGroupBox gbxObstacleSpeech;
        private XRadioButton rbxObstacleSpeechY;
        private XRadioButton rbxObstacleSpeechN;
        private XGroupBox gbxGlasses;
        private XRadioButton rbxGlassesY;
        private XRadioButton rbxGlassesN;
        private XTextBox txtMouth;
        private XTextBox txtNose;
        private XTextBox txtEarRight;
        private XTextBox txtEarLeft;
        private XCheckBox cbxEarLeft;
        private XCheckBox cbxEarRight;
        private XTextBox txtEyeRight;
        private XTextBox txtEyeLeft;
        private XCheckBox cbxEyeLeft;
        private XCheckBox cbxEyeRight;
        private XGroupBox gbxLens;
        private XRadioButton rbxLensY;
        private XRadioButton rbxLensN;
        private XGroupBox gbxEarAid;
        private XRadioButton rbxEarAidY;
        private XRadioButton rbxEarAidN;
        private XGroupBox gbxPain;
        private XRadioButton rbxPainN;
        private XRadioButton rbxPainY;
        private XLabel lblPain;
        private XTextBox txtPain;
        private XGroupBox gbxMovement;
        private XRadioButton rbxMovementY;
        private XRadioButton rbxMovementN;
        private GroupBox gbxMovementDetail;
        private XLabel lblLossPart;
        private XLabel lblContracture;
        private XGroupBox gbxPerception;
        private XRadioButton rbxPerceptionN;
        private XRadioButton rbxPerceptionY;
        private XLabel lblPerception;
        private XTextBox txtPerception;
        private XGroupBox gbxFear;
        private XRadioButton rbxFearN;
        private XRadioButton rbxFearY;
        private XLabel lblFear;
        private XTextBox txtFear;
        private XGroupBox gbxWorry;
        private XRadioButton rbxWorryN;
        private XRadioButton rbxWorryY;
        private XLabel lblWorry;
        private XTextBox txtWorry;
        private XGroupBox gbxLossPart;
        private XRadioButton rbxLossPartY;
        private XRadioButton rbxLossPartN;
        private XGroupBox gbxContracture;
        private XRadioButton rbxContractureY;
        private XRadioButton rbxContractureN;
        private XGroupBox gbxParalysis;
        private XRadioButton rbxParalysisY;
        private XRadioButton rbxParalysisN;
        private GroupBox groupBox20;
        private XRichTextBox txtAssessment5;
        private XTextBox txtLossPart;
        private XTextBox txtContracture;
        private XTextBox txtParalysis;
        private XGroupBox gbxBarrierFree;
        private XRadioButton rbxBarrierFreeY;
        private XRadioButton rbxBarrierFreeN;
        private XLabel lblBarrierFree;
        private GroupBox groupBox21;
        private XRichTextBox txtAssessment7;
        private GroupBox gbxMens;
        private XLabel xLabel166;
        private XGroupBox gbxHobby;
        private XRadioButton rbxHobbyY;
        private XRadioButton rbxHobbyN;
        private XTextBox txtHobby;
        private GroupBox groupBox22;
        private XTextBox txtJobMate;
        private XTextBox txtJob;
        private XLabel xLabel163;
        private XLabel xLabel162;
        private XLabel lblHobby;
        private XGroupBox gbxMensesProblem;
        private XRadioButton rbxMensesProblemY;
        private XRadioButton rbxMensesProblemN;
        private XTextBox txtMensesProblem;
        private XComboBox cboMenses;
        private XLabel lblMensesProblem;
        private XTextBox txtStressManage;
        private XGroupBox gbxStress;
        private XRadioButton rbxStressY;
        private XRadioButton rbxStressN;
        private XLabel xLabel30;
        private XTextBox txtStress;
        private XLabel lblStress;
        private XGroupBox gbxPregnancy;
        private XRadioButton rbxPregnancyY;
        private XRadioButton rbxPregnancyN;
        private XLabel lblPregnancy;
        private XGroupBox gbxFamily;
        private XRadioButton rbxFamilyY;
        private XRadioButton rbxFamilyN;
        private XLabel xLabel31;
        private XPatientBox paBox;
        private XPanel pnlTop;
        private XRichTextBox txtInpatientCourse;
        private XButtonList btnListTukki;
        private XPanel xPanel4;
        private XEditGrid grdOUT0106;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell17;
        private XComboBox cboDignosisGubun;
        private XComboBox cboPurpose;
        private XDatePicker dtpOutdate;
        private SingleLayoutItem singleLayoutItem149;
        private SingleLayoutItem singleLayoutItem152;
        private SingleLayoutItem singleLayoutItem158;
        private SingleLayoutItem singleLayoutItem159;
        private SingleLayoutItem singleLayoutItem161;
        private SingleLayoutItem singleLayoutItem162;
        private SingleLayoutItem singleLayoutItem163;
        private SingleLayoutItem singleLayoutItem164;
        private SingleLayoutItem singleLayoutItem165;
        private SingleLayoutItem singleLayoutItem166;
        private SingleLayoutItem singleLayoutItem167;
        private SingleLayoutItem singleLayoutItem170;
        private SingleLayoutItem singleLayoutItem171;
        private SingleLayoutItem singleLayoutItem172;
        private SingleLayoutItem singleLayoutItem173;
        private SingleLayoutItem singleLayoutItem174;
        private SingleLayoutItem singleLayoutItem175;
        private SingleLayoutItem singleLayoutItem176;
        private SingleLayoutItem singleLayoutItem177;
        private SingleLayoutItem singleLayoutItem178;
        private SingleLayoutItem singleLayoutItem179;
        private SingleLayoutItem singleLayoutItem180;
        private SingleLayoutItem singleLayoutItem181;
        private SingleLayoutItem singleLayoutItem182;
        private SingleLayoutItem singleLayoutItem183;
        private SingleLayoutItem singleLayoutItem184;
        private SingleLayoutItem singleLayoutItem185;
        private SingleLayoutItem singleLayoutItem186;
        private SingleLayoutItem singleLayoutItem187;
        private SingleLayoutItem singleLayoutItem188;
        private SingleLayoutItem singleLayoutItem189;
        private SingleLayoutItem singleLayoutItem190;
        private SingleLayoutItem singleLayoutItem191;
        private SingleLayoutItem singleLayoutItem192;
        private SingleLayoutItem singleLayoutItem193;
        private SingleLayoutItem singleLayoutItem194;
        private SingleLayoutItem singleLayoutItem195;
        private SingleLayoutItem singleLayoutItem196;
        private SingleLayoutItem singleLayoutItem197;
        private SingleLayoutItem singleLayoutItem198;
        private SingleLayoutItem singleLayoutItem199;
        private SingleLayoutItem singleLayoutItem200;
        private SingleLayoutItem singleLayoutItem201;
        private SingleLayoutItem singleLayoutItem202;
        private SingleLayoutItem singleLayoutItem203;
        private SingleLayoutItem singleLayoutItem204;
        private SingleLayoutItem singleLayoutItem205;
        private SingleLayoutItem singleLayoutItem206;
        private SingleLayoutItem singleLayoutItem207;
        private SingleLayoutItem singleLayoutItem208;
        private SingleLayoutItem singleLayoutItem209;
        private SingleLayoutItem singleLayoutItem210;
        private SingleLayoutItem singleLayoutItem211;
        private SingleLayoutItem singleLayoutItem212;
        private SingleLayoutItem singleLayoutItem213;
        private SingleLayoutItem singleLayoutItem214;
        private SingleLayoutItem singleLayoutItem215;
        private SingleLayoutItem singleLayoutItem216;
        private SingleLayoutItem singleLayoutItem217;
        private SingleLayoutItem singleLayoutItem218;
        private SingleLayoutItem singleLayoutItem219;
        private SingleLayoutItem singleLayoutItem220;
        private SingleLayoutItem singleLayoutItem221;
        private SingleLayoutItem singleLayoutItem222;
        private SingleLayoutItem singleLayoutItem223;
        private SingleLayoutItem singleLayoutItem224;
        private SingleLayoutItem singleLayoutItem225;
        private SingleLayoutItem singleLayoutItem226;
        private SingleLayoutItem singleLayoutItem227;
        private SingleLayoutItem singleLayoutItem228;
        private SingleLayoutItem singleLayoutItem229;
        private SingleLayoutItem singleLayoutItem230;
        private SingleLayoutItem singleLayoutItem231;
        private SingleLayoutItem singleLayoutItem232;
        private SingleLayoutItem singleLayoutItem233;
        private SingleLayoutItem singleLayoutItem234;
        private SingleLayoutItem singleLayoutItem235;
        private SingleLayoutItem singleLayoutItem236;
        private SingleLayoutItem singleLayoutItem237;
        private SingleLayoutItem singleLayoutItem238;
        private SingleLayoutItem singleLayoutItem239;
        private SingleLayoutItem singleLayoutItem240;
        private SingleLayoutItem singleLayoutItem241;
        private SingleLayoutItem singleLayoutItem242;
        private SingleLayoutItem singleLayoutItem243;
        private SingleLayoutItem singleLayoutItem244;
        private SingleLayoutItem singleLayoutItem245;
        private SingleLayoutItem singleLayoutItem246;
        private SingleLayoutItem singleLayoutItem247;
        private SingleLayoutItem singleLayoutItem248;
        private SingleLayoutItem singleLayoutItem249;
        private SingleLayoutItem singleLayoutItem250;
        private SingleLayoutItem singleLayoutItem251;
        private SingleLayoutItem singleLayoutItem252;
        private SingleLayoutItem singleLayoutItem253;
        private SingleLayoutItem singleLayoutItem254;
        private SingleLayoutItem singleLayoutItem255;
        private SingleLayoutItem singleLayoutItem256;
        private SingleLayoutItem singleLayoutItem257;
        private SingleLayoutItem singleLayoutItem258;
        private SingleLayoutItem singleLayoutItem259;
        private SingleLayoutItem singleLayoutItem260;
        private SingleLayoutItem singleLayoutItem261;
        private SingleLayoutItem singleLayoutItem262;
        private SingleLayoutItem singleLayoutItem263;
        private SingleLayoutItem singleLayoutItem264;
        private SingleLayoutItem singleLayoutItem265;
        private SingleLayoutItem singleLayoutItem266;
        private SingleLayoutItem singleLayoutItem267;
        private SingleLayoutItem singleLayoutItem268;
        private SingleLayoutItem singleLayoutItem269;
        private SingleLayoutItem singleLayoutItem270;
        private SingleLayoutItem singleLayoutItem271;
        private SingleLayoutItem singleLayoutItem272;
        private SingleLayoutItem singleLayoutItem273;
        private SingleLayoutItem singleLayoutItem274;
        private SingleLayoutItem singleLayoutItem275;
        private SingleLayoutItem singleLayoutItem276;
        private SingleLayoutItem singleLayoutItem277;
        private SingleLayoutItem singleLayoutItem278;
        private SingleLayoutItem singleLayoutItem279;
        private SingleLayoutItem singleLayoutItem280;
        private SingleLayoutItem singleLayoutItem281;
        private SingleLayoutItem singleLayoutItem282;
        private SingleLayoutItem singleLayoutItem283;
        private SingleLayoutItem singleLayoutItem284;
        private SingleLayoutItem singleLayoutItem285;
        private SingleLayoutItem singleLayoutItem286;
        private SingleLayoutItem singleLayoutItem287;
        private SingleLayoutItem singleLayoutItem288;
        private SingleLayoutItem singleLayoutItem289;
        private SingleLayoutItem singleLayoutItem290;
        private SingleLayoutItem singleLayoutItem291;
        private SingleLayoutItem singleLayoutItem292;
        private SingleLayoutItem singleLayoutItem293;
        private SingleLayoutItem singleLayoutItem294;
        private SingleLayoutItem singleLayoutItem295;
        private SingleLayoutItem singleLayoutItem296;
        private SingleLayoutItem singleLayoutItem297;
        private SingleLayoutItem singleLayoutItem298;
        private SingleLayoutItem singleLayoutItem299;
        private SingleLayoutItem singleLayoutItem300;
        private SingleLayoutItem singleLayoutItem301;
        private SingleLayoutItem singleLayoutItem302;
        private SingleLayoutItem singleLayoutItem303;
        private SingleLayoutItem singleLayoutItem304;
        private SingleLayoutItem singleLayoutItem305;
        private SingleLayoutItem singleLayoutItem306;
        private SingleLayoutItem singleLayoutItem307;
        private SingleLayoutItem singleLayoutItem308;
        private SingleLayoutItem singleLayoutItem309;
        private SingleLayoutItem singleLayoutItem310;
        private SingleLayoutItem singleLayoutItem311;
        private SingleLayoutItem singleLayoutItem312;
        private SingleLayoutItem singleLayoutItem313;
        private SingleLayoutItem singleLayoutItem314;
        private SingleLayoutItem singleLayoutItem315;
        private SingleLayoutItem singleLayoutItem316;
        private SingleLayoutItem singleLayoutItem317;
        private SingleLayoutItem singleLayoutItem318;
        private SingleLayoutItem singleLayoutItem319;
        private SingleLayoutItem singleLayoutItem325;
        private SingleLayout layNUR1001;
        private SingleLayoutItem singleLayoutItem1;
        private XButton btnNurseOpen;
        private XNumericUpDown nudSmoking;
        private XEditGridCell xEditGridCell19;
        private XDatePicker dtpBirth;
        private XPanel xPanel5;
        private XLabel xLabel5;
        private XLabel xLabel1;
        private XLabel lblLive;
        private XLabel lblWith;
        private XGroupBox gbxWith;
        private XGroupBox gbxLive;
        private XRadioButton rbxLiveN;
        private XRadioButton rbxLiveY;
        //private XGridHeader xGridHeader1;
        private XRadioButton rbxWithN;
        private XRadioButton rbxWithY;
        private XEditGrid grdINP1004;
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
        private XEditGridCell xEditGridCell180;
        private XEditGridCell xEditGridCell48;
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
        private XTextBox txtBoninGubunName;
        private XTextBox txtAge;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XButton btnSkinDel;
        private XButton btnSkinAdd;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell16;
        private XLabel xLabel8;
        private XLabel xLabel7;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem7;
        private XEditMask txtUrinNightCnt;
        private XEditMask txtWeight;
        private XEditMask txtHeight;
        private XEditMask txtSleepEnd;
        private XEditMask txtSleepStart;
        private XEditMask txtIntermittent;
        private XLabel lblMovement;
        private XLabel lblSensor;
        private XEditMask txtSleepTime;
        private SingleLayoutItem singleLayoutItem2;
        private XComboBox cboBloodTypeRh;
        private XComboItem xComboItem9;
        private XComboItem xComboItem10;
        private XComboBox cboBloodTypeABO;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XComboItem xComboItem7;
        private XComboItem xComboItem8;
        private XFindBox fbxWriter;
        private XDisplayBox dbxWriter;
        private SingleLayoutItem singleLayoutItem3;
        private XEditMask txtMensesAge;
        private SingleLayout layCopy;
        private SingleLayoutItem singleLayoutItem322;
        private SingleLayoutItem singleLayoutItem346;
        private SingleLayoutItem singleLayoutItem347;
        private SingleLayoutItem singleLayoutItem348;
        private SingleLayoutItem singleLayoutItem349;
        private SingleLayoutItem singleLayoutItem350;
        private SingleLayoutItem singleLayoutItem351;
        private SingleLayoutItem singleLayoutItem352;
        private SingleLayoutItem singleLayoutItem353;
        private SingleLayoutItem singleLayoutItem354;
        private SingleLayoutItem singleLayoutItem355;
        private SingleLayoutItem singleLayoutItem356;
        private SingleLayoutItem singleLayoutItem357;
        private SingleLayoutItem singleLayoutItem358;
        private SingleLayoutItem singleLayoutItem359;
        private SingleLayoutItem singleLayoutItem360;
        private SingleLayoutItem singleLayoutItem361;
        private SingleLayoutItem singleLayoutItem362;
        private SingleLayoutItem singleLayoutItem363;
        private SingleLayoutItem singleLayoutItem364;
        private SingleLayoutItem singleLayoutItem365;
        private SingleLayoutItem singleLayoutItem366;
        private SingleLayoutItem singleLayoutItem367;
        private SingleLayoutItem singleLayoutItem368;
        private SingleLayoutItem singleLayoutItem369;
        private SingleLayoutItem singleLayoutItem370;
        private SingleLayoutItem singleLayoutItem371;
        private SingleLayoutItem singleLayoutItem372;
        private SingleLayoutItem singleLayoutItem373;
        private SingleLayoutItem singleLayoutItem374;
        private SingleLayoutItem singleLayoutItem375;
        private SingleLayoutItem singleLayoutItem376;
        private SingleLayoutItem singleLayoutItem377;
        private SingleLayoutItem singleLayoutItem378;
        private SingleLayoutItem singleLayoutItem379;
        private SingleLayoutItem singleLayoutItem380;
        private SingleLayoutItem singleLayoutItem381;
        private SingleLayoutItem singleLayoutItem382;
        private SingleLayoutItem singleLayoutItem383;
        private SingleLayoutItem singleLayoutItem384;
        private SingleLayoutItem singleLayoutItem385;
        private SingleLayoutItem singleLayoutItem386;
        private SingleLayoutItem singleLayoutItem387;
        private SingleLayoutItem singleLayoutItem388;
        private SingleLayoutItem singleLayoutItem389;
        private SingleLayoutItem singleLayoutItem390;
        private SingleLayoutItem singleLayoutItem391;
        private SingleLayoutItem singleLayoutItem392;
        private SingleLayoutItem singleLayoutItem393;
        private SingleLayoutItem singleLayoutItem394;
        private SingleLayoutItem singleLayoutItem395;
        private SingleLayoutItem singleLayoutItem396;
        private SingleLayoutItem singleLayoutItem397;
        private SingleLayoutItem singleLayoutItem398;
        private SingleLayoutItem singleLayoutItem399;
        private SingleLayoutItem singleLayoutItem400;
        private SingleLayoutItem singleLayoutItem401;
        private SingleLayoutItem singleLayoutItem402;
        private SingleLayoutItem singleLayoutItem403;
        private SingleLayoutItem singleLayoutItem404;
        private SingleLayoutItem singleLayoutItem405;
        private SingleLayoutItem singleLayoutItem406;
        private SingleLayoutItem singleLayoutItem407;
        private SingleLayoutItem singleLayoutItem408;
        private SingleLayoutItem singleLayoutItem409;
        private SingleLayoutItem singleLayoutItem410;
        private SingleLayoutItem singleLayoutItem411;
        private SingleLayoutItem singleLayoutItem412;
        private SingleLayoutItem singleLayoutItem413;
        private SingleLayoutItem singleLayoutItem414;
        private SingleLayoutItem singleLayoutItem415;
        private SingleLayoutItem singleLayoutItem416;
        private SingleLayoutItem singleLayoutItem417;
        private SingleLayoutItem singleLayoutItem418;
        private SingleLayoutItem singleLayoutItem419;
        private SingleLayoutItem singleLayoutItem420;
        private SingleLayoutItem singleLayoutItem421;
        private SingleLayoutItem singleLayoutItem422;
        private SingleLayoutItem singleLayoutItem423;
        private SingleLayoutItem singleLayoutItem425;
        private SingleLayoutItem singleLayoutItem426;
        private SingleLayoutItem singleLayoutItem427;
        private SingleLayoutItem singleLayoutItem428;
        private SingleLayoutItem singleLayoutItem429;
        private SingleLayoutItem singleLayoutItem430;
        private SingleLayoutItem singleLayoutItem431;
        private SingleLayoutItem singleLayoutItem432;
        private SingleLayoutItem singleLayoutItem433;
        private SingleLayoutItem singleLayoutItem434;
        private SingleLayoutItem singleLayoutItem435;
        private SingleLayoutItem singleLayoutItem436;
        private SingleLayoutItem singleLayoutItem437;
        private SingleLayoutItem singleLayoutItem438;
        private SingleLayoutItem singleLayoutItem439;
        private SingleLayoutItem singleLayoutItem440;
        private SingleLayoutItem singleLayoutItem441;
        private SingleLayoutItem singleLayoutItem442;
        private SingleLayoutItem singleLayoutItem443;
        private SingleLayoutItem singleLayoutItem444;
        private SingleLayoutItem singleLayoutItem445;
        private SingleLayoutItem singleLayoutItem446;
        private SingleLayoutItem singleLayoutItem447;
        private SingleLayoutItem singleLayoutItem448;
        private SingleLayoutItem singleLayoutItem449;
        private SingleLayoutItem singleLayoutItem450;
        private SingleLayoutItem singleLayoutItem451;
        private SingleLayoutItem singleLayoutItem452;
        private SingleLayoutItem singleLayoutItem453;
        private SingleLayoutItem singleLayoutItem454;
        private SingleLayoutItem singleLayoutItem455;
        private SingleLayoutItem singleLayoutItem456;
        private SingleLayoutItem singleLayoutItem457;
        private SingleLayoutItem singleLayoutItem458;
        private SingleLayoutItem singleLayoutItem459;
        private SingleLayoutItem singleLayoutItem460;
        private SingleLayoutItem singleLayoutItem461;
        private SingleLayoutItem singleLayoutItem462;
        private SingleLayoutItem singleLayoutItem463;
        private SingleLayoutItem singleLayoutItem464;
        private SingleLayoutItem singleLayoutItem465;
        private SingleLayoutItem singleLayoutItem466;
        private SingleLayoutItem singleLayoutItem467;
        private SingleLayoutItem singleLayoutItem468;
        private SingleLayoutItem singleLayoutItem469;
        private SingleLayoutItem singleLayoutItem470;
        private SingleLayoutItem singleLayoutItem471;
        private SingleLayoutItem singleLayoutItem472;
        private SingleLayoutItem singleLayoutItem473;
        private SingleLayoutItem singleLayoutItem474;
        private SingleLayoutItem singleLayoutItem475;
        private SingleLayoutItem singleLayoutItem476;
        private SingleLayoutItem singleLayoutItem477;
        private SingleLayoutItem singleLayoutItem478;
        private SingleLayoutItem singleLayoutItem479;
        private SingleLayoutItem singleLayoutItem480;
        private SingleLayoutItem singleLayoutItem481;
        private SingleLayoutItem singleLayoutItem482;
        private SingleLayoutItem singleLayoutItem483;
        private SingleLayoutItem singleLayoutItem484;
        private SingleLayoutItem singleLayoutItem485;
        private SingleLayoutItem singleLayoutItem486;
        private SingleLayoutItem singleLayoutItem487;
        private SingleLayoutItem singleLayoutItem488;
        private SingleLayoutItem singleLayoutItem489;
        private SingleLayoutItem singleLayoutItem490;
        private SingleLayoutItem singleLayoutItem491;
        private SingleLayoutItem singleLayoutItem492;
        private SingleLayoutItem singleLayoutItem493;
        private SingleLayoutItem singleLayoutItem494;
        private SingleLayoutItem singleLayoutItem495;
        private SingleLayoutItem singleLayoutItem496;
        private SingleLayoutItem singleLayoutItem497;
        private SingleLayoutItem singleLayoutItem498;
        private SingleLayoutItem singleLayoutItem499;
        private SingleLayoutItem singleLayoutItem500;
        private SingleLayoutItem singleLayoutItem501;
        private SingleLayoutItem singleLayoutItem502;
        private SingleLayoutItem singleLayoutItem503;
        private SingleLayoutItem singleLayoutItem504;
        private SingleLayoutItem singleLayoutItem505;
        private SingleLayoutItem singleLayoutItem506;
        private SingleLayoutItem singleLayoutItem507;
        private SingleLayoutItem singleLayoutItem508;
        private SingleLayoutItem singleLayoutItem509;
        private SingleLayoutItem singleLayoutItem510;
        private XButton btnVital;
        private XDictComboBox cboSubFood;
        private XDictComboBox cboMainFood;
        private XTextBox txtKeyOffice2;
        private XLabel xLabel15;
        private XTextBox txtKeyCell2;
        private XLabel xLabel16;
        private XTextBox txtKeyOffice1;
        private XLabel xLabel14;
        private XTextBox txtKeyCell1;
        private XLabel xLabel13;
        private XTextBox txtKeyHome2;
        private XLabel xLabel9;
        private XTextBox txtKeyRelation2;
        private XLabel xLabel10;
        private XLabel xLabel11;
        private XTextBox txtKeyName2;
        private XLabel xLabel12;
        private XComboBox cboKeyHomePri1;
        private XComboBox cboKeyOfficePri2;
        private XComboItem xComboItem32;
        private XComboItem xComboItem33;
        private XComboItem xComboItem34;
        private XComboItem xComboItem35;
        private XComboItem xComboItem36;
        private XComboItem xComboItem37;
        private XComboItem xComboItem38;
        private XComboBox cboKeyCellPri2;
        private XComboItem xComboItem39;
        private XComboItem xComboItem40;
        private XComboItem xComboItem41;
        private XComboItem xComboItem42;
        private XComboItem xComboItem43;
        private XComboItem xComboItem44;
        private XComboItem xComboItem45;
        private XComboBox cboKeyHomePri2;
        private XComboItem xComboItem46;
        private XComboItem xComboItem47;
        private XComboItem xComboItem48;
        private XComboItem xComboItem49;
        private XComboItem xComboItem50;
        private XComboItem xComboItem51;
        private XComboItem xComboItem52;
        private XComboBox cboKeyOfficePri1;
        private XComboItem xComboItem25;
        private XComboItem xComboItem26;
        private XComboItem xComboItem27;
        private XComboItem xComboItem28;
        private XComboItem xComboItem29;
        private XComboItem xComboItem30;
        private XComboItem xComboItem31;
        private XComboBox cboKeyCellPri1;
        private XComboItem xComboItem18;
        private XComboItem xComboItem19;
        private XComboItem xComboItem20;
        private XComboItem xComboItem21;
        private XComboItem xComboItem22;
        private XComboItem xComboItem23;
        private XComboItem xComboItem24;
        private XComboItem xComboItem11;
        private XComboItem xComboItem12;
        private XComboItem xComboItem13;
        private XComboItem xComboItem14;
        private XComboItem xComboItem15;
        private XComboItem xComboItem16;
        private XComboItem xComboItem17;
        private GroupBox groupBox1;
        private XRichTextBox txtKeyComment;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
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
        private XButton btnChiryo;
        private XButton btnNUR9001;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR1001U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.layNUR1001.SavePerformer = new XSavePerformer(this);
            //this.layNUR1001Update.SavePerformer = new XSavePerformer(this);
            //this.grdNUR1002.SavePerformer = this.layNUR1001Update.SavePerformer;
            this.grdINP1004.SavePerformer = this.layNUR1001.SavePerformer;
            //this.grdNur1009.SavePerformer = this.layNUR1001Update.SavePerformer;
            //this.layNUR1001A.SavePerformer = this.layNUR1001Update.SavePerformer;
            //this.layNUR1001B.SavePerformer = this.layNUR1001Update.SavePerformer;
            this.layCopy.SavePerformer = this.layNUR1001.SavePerformer;

            this.grdOUT0106.SavePerformer = this.layNUR1001.SavePerformer;
            this.grdNUR1029.SavePerformer = this.layNUR1001.SavePerformer;

            //저장 Layout List Set
            //this.SaveLayoutList.Add(this.layNUR1001Update);
            //this.SaveLayoutList.Add(this.grdNUR1002);
            //this.SaveLayoutList.Add(this.grdINP1004);
            //this.SaveLayoutList.Add(this.grdNur1009);
            //this.SaveLayoutList.Add(this.layNUR1001A);
            //this.SaveLayoutList.Add(this.layNUR1001B);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1001U00));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdINP1004 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.txtName = new IHIS.Framework.XTextBox();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.fbxZipCode1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.txtZipCode2 = new IHIS.Framework.XEditMask();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.fbxAddress1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.txtAddress2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.txtTel1 = new IHIS.Framework.XEditMask();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.txtTel2 = new IHIS.Framework.XEditMask();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.txtBigo = new IHIS.Framework.XTextBox();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.fbxBoninGubun = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
            this.txtBoninGubunName = new IHIS.Framework.XTextBox();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.cboTelGubun = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.cboTelGubun2 = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.txtName2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.dtpBirth = new IHIS.Framework.XDatePicker();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.gbxWith = new IHIS.Framework.XGroupBox();
            this.rbxWithN = new IHIS.Framework.XRadioButton();
            this.rbxWithY = new IHIS.Framework.XRadioButton();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.gbxLive = new IHIS.Framework.XGroupBox();
            this.rbxLiveN = new IHIS.Framework.XRadioButton();
            this.rbxLiveY = new IHIS.Framework.XRadioButton();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel41 = new IHIS.Framework.XLabel();
            this.pnlINP1004 = new IHIS.Framework.XPanel();
            this.txtAge = new IHIS.Framework.XTextBox();
            this.lblLive = new IHIS.Framework.XLabel();
            this.lblWith = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.txtSeq = new IHIS.Framework.XEditMask();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnInsert = new IHIS.Framework.XButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.fwkFind = new IHIS.Framework.XFindWorker();
            this.lblBlood = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnNUR9001 = new IHIS.Framework.XButton();
            this.btnChiryo = new IHIS.Framework.XButton();
            this.btnVital = new IHIS.Framework.XButton();
            this.txtUpd_gubun = new IHIS.Framework.XTextBox();
            this.txtBunho = new IHIS.Framework.XTextBox();
            this.txtFkinp1001 = new IHIS.Framework.XTextBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.txtDrug_comment = new IHIS.Framework.XTextBox();
            this.grdNUR1002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.btnAllergy = new IHIS.Framework.XButton();
            this.btnInfe = new IHIS.Framework.XButton();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.tabPatient = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.pnlPatientInfoRight = new IHIS.Framework.XPanel();
            this.dbxWriter = new IHIS.Framework.XDisplayBox();
            this.fbxWriter = new IHIS.Framework.XFindBox();
            this.dtpOutdate = new IHIS.Framework.XDatePicker();
            this.btnNurseOpen = new IHIS.Framework.XButton();
            this.cboDignosisGubun = new IHIS.Framework.XComboBox();
            this.xLabel139 = new IHIS.Framework.XLabel();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnListTukki = new IHIS.Framework.XButtonList();
            this.grdOUT0106 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtAssessment0 = new IHIS.Framework.XRichTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnGanhodoOpen = new IHIS.Framework.XButton();
            this.dbxNurse = new IHIS.Framework.XDisplayBox();
            this.btnTeamOpen = new IHIS.Framework.XButton();
            this.dbxTeam = new IHIS.Framework.XDisplayBox();
            this.lblTeam = new IHIS.Framework.XLabel();
            this.lblNurse = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.lblHo_code = new IHIS.Framework.XLabel();
            this.dbxHo_Dong = new IHIS.Framework.XDisplayBox();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.dbxDoctor = new IHIS.Framework.XDisplayBox();
            this.xLabel79 = new IHIS.Framework.XLabel();
            this.dbxGwa = new IHIS.Framework.XDisplayBox();
            this.lblGwa = new IHIS.Framework.XLabel();
            this.btnOrder = new IHIS.Framework.XButton();
            this.lblDoctor = new IHIS.Framework.XLabel();
            this.lblSang_name = new IHIS.Framework.XLabel();
            this.dtpIndate = new IHIS.Framework.XDatePicker();
            this.mbxDiagnosisName = new IHIS.Framework.XMemoBox();
            this.lblInDate = new IHIS.Framework.XLabel();
            this.dbxBed = new IHIS.Framework.XDisplayBox();
            this.lblBed = new IHIS.Framework.XLabel();
            this.dbxHo_Code = new IHIS.Framework.XDisplayBox();
            this.pnlPatientInfoLeft = new IHIS.Framework.XPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKeyComment = new IHIS.Framework.XRichTextBox();
            this.cboKeyOfficePri2 = new IHIS.Framework.XComboBox();
            this.xComboItem32 = new IHIS.Framework.XComboItem();
            this.xComboItem33 = new IHIS.Framework.XComboItem();
            this.xComboItem34 = new IHIS.Framework.XComboItem();
            this.xComboItem35 = new IHIS.Framework.XComboItem();
            this.xComboItem36 = new IHIS.Framework.XComboItem();
            this.xComboItem37 = new IHIS.Framework.XComboItem();
            this.xComboItem38 = new IHIS.Framework.XComboItem();
            this.cboKeyCellPri2 = new IHIS.Framework.XComboBox();
            this.xComboItem39 = new IHIS.Framework.XComboItem();
            this.xComboItem40 = new IHIS.Framework.XComboItem();
            this.xComboItem41 = new IHIS.Framework.XComboItem();
            this.xComboItem42 = new IHIS.Framework.XComboItem();
            this.xComboItem43 = new IHIS.Framework.XComboItem();
            this.xComboItem44 = new IHIS.Framework.XComboItem();
            this.xComboItem45 = new IHIS.Framework.XComboItem();
            this.cboKeyHomePri2 = new IHIS.Framework.XComboBox();
            this.xComboItem46 = new IHIS.Framework.XComboItem();
            this.xComboItem47 = new IHIS.Framework.XComboItem();
            this.xComboItem48 = new IHIS.Framework.XComboItem();
            this.xComboItem49 = new IHIS.Framework.XComboItem();
            this.xComboItem50 = new IHIS.Framework.XComboItem();
            this.xComboItem51 = new IHIS.Framework.XComboItem();
            this.xComboItem52 = new IHIS.Framework.XComboItem();
            this.cboKeyOfficePri1 = new IHIS.Framework.XComboBox();
            this.xComboItem25 = new IHIS.Framework.XComboItem();
            this.xComboItem26 = new IHIS.Framework.XComboItem();
            this.xComboItem27 = new IHIS.Framework.XComboItem();
            this.xComboItem28 = new IHIS.Framework.XComboItem();
            this.xComboItem29 = new IHIS.Framework.XComboItem();
            this.xComboItem30 = new IHIS.Framework.XComboItem();
            this.xComboItem31 = new IHIS.Framework.XComboItem();
            this.cboKeyCellPri1 = new IHIS.Framework.XComboBox();
            this.xComboItem18 = new IHIS.Framework.XComboItem();
            this.xComboItem19 = new IHIS.Framework.XComboItem();
            this.xComboItem20 = new IHIS.Framework.XComboItem();
            this.xComboItem21 = new IHIS.Framework.XComboItem();
            this.xComboItem22 = new IHIS.Framework.XComboItem();
            this.xComboItem23 = new IHIS.Framework.XComboItem();
            this.xComboItem24 = new IHIS.Framework.XComboItem();
            this.cboKeyHomePri1 = new IHIS.Framework.XComboBox();
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xComboItem12 = new IHIS.Framework.XComboItem();
            this.xComboItem13 = new IHIS.Framework.XComboItem();
            this.xComboItem14 = new IHIS.Framework.XComboItem();
            this.xComboItem15 = new IHIS.Framework.XComboItem();
            this.xComboItem16 = new IHIS.Framework.XComboItem();
            this.xComboItem17 = new IHIS.Framework.XComboItem();
            this.txtKeyOffice2 = new IHIS.Framework.XTextBox();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.txtKeyCell2 = new IHIS.Framework.XTextBox();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.txtKeyOffice1 = new IHIS.Framework.XTextBox();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.txtKeyCell1 = new IHIS.Framework.XTextBox();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.txtKeyHome2 = new IHIS.Framework.XTextBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.txtKeyRelation2 = new IHIS.Framework.XTextBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.txtKeyName2 = new IHIS.Framework.XTextBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.cboBloodTypeRh = new IHIS.Framework.XComboBox();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.cboBloodTypeABO = new IHIS.Framework.XComboBox();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.cboPurpose = new IHIS.Framework.XComboBox();
            this.txtKeyHome1 = new IHIS.Framework.XTextBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.txtInpatientCourse = new IHIS.Framework.XRichTextBox();
            this.xLabel143 = new IHIS.Framework.XLabel();
            this.txtKeyRelation1 = new IHIS.Framework.XTextBox();
            this.xLabel142 = new IHIS.Framework.XLabel();
            this.xLabel141 = new IHIS.Framework.XLabel();
            this.txtKeyName1 = new IHIS.Framework.XTextBox();
            this.xLabel52 = new IHIS.Framework.XLabel();
            this.xLabel53 = new IHIS.Framework.XLabel();
            this.txtInformant = new IHIS.Framework.XTextBox();
            this.xLabel140 = new IHIS.Framework.XLabel();
            this.xLabel138 = new IHIS.Framework.XLabel();
            this.dbxHoken = new IHIS.Framework.XDisplayBox();
            this.xLabel78 = new IHIS.Framework.XLabel();
            this.dbxTel = new IHIS.Framework.XDisplayBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.lblAddress1 = new IHIS.Framework.XLabel();
            this.dbxAddress = new IHIS.Framework.XDisplayBox();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.pnlHealthRight = new IHIS.Framework.XPanel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtAssessment1 = new IHIS.Framework.XRichTextBox();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.grdNUR1017 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.grdNUR1016 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.pnlHealthLeft = new IHIS.Framework.XPanel();
            this.nudSmoking = new IHIS.Framework.XNumericUpDown();
            this.txtDrinking = new IHIS.Framework.XTextBox();
            this.xLabel145 = new IHIS.Framework.XLabel();
            this.xLabel144 = new IHIS.Framework.XLabel();
            this.gbxHealthCare = new IHIS.Framework.XGroupBox();
            this.rbxHealthcareY = new IHIS.Framework.XRadioButton();
            this.rbxHealthcareN = new IHIS.Framework.XRadioButton();
            this.mbxBringDrugComment = new IHIS.Framework.XMemoBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtExplainF = new IHIS.Framework.XTextBox();
            this.txtExplainP = new IHIS.Framework.XTextBox();
            this.txtExplainD = new IHIS.Framework.XTextBox();
            this.xLabel81 = new IHIS.Framework.XLabel();
            this.xLabel84 = new IHIS.Framework.XLabel();
            this.xLabel85 = new IHIS.Framework.XLabel();
            this.mbxHealthcare = new IHIS.Framework.XMemoBox();
            this.mbxPastHis = new IHIS.Framework.XMemoBox();
            this.lblHealthCare = new IHIS.Framework.XLabel();
            this.lblBringDrug = new IHIS.Framework.XLabel();
            this.lblPast_his = new IHIS.Framework.XLabel();
            this.gbxBringDrug = new IHIS.Framework.XGroupBox();
            this.rbxBringDrugY = new IHIS.Framework.XRadioButton();
            this.rbxBringDrugN = new IHIS.Framework.XRadioButton();
            this.xLabel146 = new IHIS.Framework.XLabel();
            this.xLabel147 = new IHIS.Framework.XLabel();
            this.tabPage4 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btnSkinDel = new IHIS.Framework.XButton();
            this.btnSkinAdd = new IHIS.Framework.XButton();
            this.grdNUR1029 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xLabel107 = new IHIS.Framework.XLabel();
            this.cbxEnterokinesia = new IHIS.Framework.XCheckBox();
            this.cbxAbtominalVery = new IHIS.Framework.XCheckBox();
            this.cbxAbdominal = new IHIS.Framework.XCheckBox();
            this.xLabel96 = new IHIS.Framework.XLabel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtIntermittent = new IHIS.Framework.XEditMask();
            this.txtUrinNightCnt = new IHIS.Framework.XEditMask();
            this.dtpCatheter = new IHIS.Framework.XDatePicker();
            this.xLabel94 = new IHIS.Framework.XLabel();
            this.cbxCatheter = new IHIS.Framework.XCheckBox();
            this.xLabel106 = new IHIS.Framework.XLabel();
            this.cbxIntermittent = new IHIS.Framework.XCheckBox();
            this.cbxDiapersU = new IHIS.Framework.XCheckBox();
            this.gbxUrinWill = new IHIS.Framework.XGroupBox();
            this.rbxUrinN = new IHIS.Framework.XRadioButton();
            this.rbxUrinWillY = new IHIS.Framework.XRadioButton();
            this.lblUrinWill = new IHIS.Framework.XLabel();
            this.xLabel97 = new IHIS.Framework.XLabel();
            this.cboUrinDay = new IHIS.Framework.XComboBox();
            this.cboUrinCnt = new IHIS.Framework.XComboBox();
            this.xLabel98 = new IHIS.Framework.XLabel();
            this.xLabel103 = new IHIS.Framework.XLabel();
            this.xLabel104 = new IHIS.Framework.XLabel();
            this.xLabel105 = new IHIS.Framework.XLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtLaxation = new IHIS.Framework.XTextBox();
            this.cbxAntidiarrheal = new IHIS.Framework.XCheckBox();
            this.cbxSuppository = new IHIS.Framework.XCheckBox();
            this.cbxLaxative = new IHIS.Framework.XCheckBox();
            this.cbxEnema = new IHIS.Framework.XCheckBox();
            this.xLabel102 = new IHIS.Framework.XLabel();
            this.cbxOrthotics = new IHIS.Framework.XCheckBox();
            this.cbxDiapersD = new IHIS.Framework.XCheckBox();
            this.gbxDungWill = new IHIS.Framework.XGroupBox();
            this.rbxDungWillN = new IHIS.Framework.XRadioButton();
            this.rbxDungWillY = new IHIS.Framework.XRadioButton();
            this.txtDungLast = new IHIS.Framework.XTextBox();
            this.txtDungState = new IHIS.Framework.XTextBox();
            this.lblDungWill = new IHIS.Framework.XLabel();
            this.xLabel100 = new IHIS.Framework.XLabel();
            this.xLabel99 = new IHIS.Framework.XLabel();
            this.cboDungDay = new IHIS.Framework.XComboBox();
            this.cboDungCnt = new IHIS.Framework.XComboBox();
            this.xLabel71 = new IHIS.Framework.XLabel();
            this.xLabel73 = new IHIS.Framework.XLabel();
            this.xLabel75 = new IHIS.Framework.XLabel();
            this.xLabel76 = new IHIS.Framework.XLabel();
            this.pnlFood = new IHIS.Framework.XPanel();
            this.txtWeight = new IHIS.Framework.XEditMask();
            this.txtHeight = new IHIS.Framework.XEditMask();
            this.txtBMI = new IHIS.Framework.XTextBox();
            this.xLabel111 = new IHIS.Framework.XLabel();
            this.xLabel110 = new IHIS.Framework.XLabel();
            this.cboWeightUpdownHow = new IHIS.Framework.XComboBox();
            this.txtFalseTeeth = new IHIS.Framework.XTextBox();
            this.cboWeightUpdownStart = new IHIS.Framework.XComboBox();
            this.xLabel108 = new IHIS.Framework.XLabel();
            this.gbxFalseTeeth = new IHIS.Framework.XGroupBox();
            this.rbxFalseTeethN = new IHIS.Framework.XRadioButton();
            this.rbxFalseTeethY = new IHIS.Framework.XRadioButton();
            this.xLabel109 = new IHIS.Framework.XLabel();
            this.txtMouthPollution = new IHIS.Framework.XTextBox();
            this.gbxMouthPollution = new IHIS.Framework.XGroupBox();
            this.rbxMouthPollutionN = new IHIS.Framework.XRadioButton();
            this.rbxMouthPollutionY = new IHIS.Framework.XRadioButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtAssessment2 = new IHIS.Framework.XRichTextBox();
            this.xLabel93 = new IHIS.Framework.XLabel();
            this.xLabel92 = new IHIS.Framework.XLabel();
            this.xLabel90 = new IHIS.Framework.XLabel();
            this.xLabel89 = new IHIS.Framework.XLabel();
            this.lblFalseTeeth = new IHIS.Framework.XLabel();
            this.lblMouthPollution = new IHIS.Framework.XLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboSubFood = new IHIS.Framework.XDictComboBox();
            this.cboMainFood = new IHIS.Framework.XDictComboBox();
            this.txtFoodLimit = new IHIS.Framework.XTextBox();
            this.xLabel148 = new IHIS.Framework.XLabel();
            this.txtIntake = new IHIS.Framework.XTextBox();
            this.cboIntakeWay = new IHIS.Framework.XComboBox();
            this.xLabel86 = new IHIS.Framework.XLabel();
            this.txtDysphagia = new IHIS.Framework.XTextBox();
            this.gbxDysphagia = new IHIS.Framework.XGroupBox();
            this.rbxDysphagiaN = new IHIS.Framework.XRadioButton();
            this.rbxDysphagiaY = new IHIS.Framework.XRadioButton();
            this.lblDysphagia = new IHIS.Framework.XLabel();
            this.txtAppetite = new IHIS.Framework.XTextBox();
            this.gbxAppetite = new IHIS.Framework.XGroupBox();
            this.rbxAppetiteN = new IHIS.Framework.XRadioButton();
            this.rbxAppetiteY = new IHIS.Framework.XRadioButton();
            this.txtFoodDislike = new IHIS.Framework.XTextBox();
            this.lblFoodDislike = new IHIS.Framework.XLabel();
            this.gbxFoodDislike = new IHIS.Framework.XGroupBox();
            this.rbxFoodDislikeN = new IHIS.Framework.XRadioButton();
            this.rbxFoodDislikeY = new IHIS.Framework.XRadioButton();
            this.xLabel80 = new IHIS.Framework.XLabel();
            this.xLabel91 = new IHIS.Framework.XLabel();
            this.lblAppetite = new IHIS.Framework.XLabel();
            this.lblFood_allergy = new IHIS.Framework.XLabel();
            this.tabPage5 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.txtAssessment4 = new IHIS.Framework.XRichTextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtSleepTime = new IHIS.Framework.XEditMask();
            this.txtSleepEnd = new IHIS.Framework.XEditMask();
            this.txtSleepStart = new IHIS.Framework.XEditMask();
            this.gbxSleepEnough = new IHIS.Framework.XGroupBox();
            this.rbxSleepEnoughN = new IHIS.Framework.XRadioButton();
            this.rbxSleepEnoughY = new IHIS.Framework.XRadioButton();
            this.xLabel129 = new IHIS.Framework.XLabel();
            this.txtSleepEtc = new IHIS.Framework.XTextBox();
            this.xLabel122 = new IHIS.Framework.XLabel();
            this.txtSleepLess = new IHIS.Framework.XTextBox();
            this.cbxSleepEtc = new IHIS.Framework.XCheckBox();
            this.cbxTeethGrinding = new IHIS.Framework.XCheckBox();
            this.cbxSleepTalk = new IHIS.Framework.XCheckBox();
            this.cbxSnoring = new IHIS.Framework.XCheckBox();
            this.xLabel121 = new IHIS.Framework.XLabel();
            this.txtSleepEnough = new IHIS.Framework.XTextBox();
            this.lblSleepEnough = new IHIS.Framework.XLabel();
            this.xLabel124 = new IHIS.Framework.XLabel();
            this.xLabel125 = new IHIS.Framework.XLabel();
            this.xLabel126 = new IHIS.Framework.XLabel();
            this.xLabel127 = new IHIS.Framework.XLabel();
            this.xLabel128 = new IHIS.Framework.XLabel();
            this.xPanel14 = new IHIS.Framework.XPanel();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.txtCareOffice = new IHIS.Framework.XTextBox();
            this.txtService = new IHIS.Framework.XTextBox();
            this.xLabel156 = new IHIS.Framework.XLabel();
            this.xLabel157 = new IHIS.Framework.XLabel();
            this.lblNeedSupport = new IHIS.Framework.XLabel();
            this.lblNeedCare = new IHIS.Framework.XLabel();
            this.gbxNeedSupport = new IHIS.Framework.XGroupBox();
            this.rbxActivitySupport2 = new IHIS.Framework.XRadioButton();
            this.rbxActivitySupport1 = new IHIS.Framework.XRadioButton();
            this.gbxNeedCare = new IHIS.Framework.XGroupBox();
            this.rbxActivityCare5 = new IHIS.Framework.XRadioButton();
            this.rbxActivityCare4 = new IHIS.Framework.XRadioButton();
            this.rbxActivityCare3 = new IHIS.Framework.XRadioButton();
            this.rbxActivityCare2 = new IHIS.Framework.XRadioButton();
            this.rbxActivityCare1 = new IHIS.Framework.XRadioButton();
            this.xLabel149 = new IHIS.Framework.XLabel();
            this.xLabel150 = new IHIS.Framework.XLabel();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.txtWalk_ADL = new IHIS.Framework.XTextBox();
            this.cboWalk_ADL = new IHIS.Framework.XComboBox();
            this.xLabel120 = new IHIS.Framework.XLabel();
            this.txtWheelchair_ADL = new IHIS.Framework.XTextBox();
            this.cboWheelchair_ADL = new IHIS.Framework.XComboBox();
            this.xLabel119 = new IHIS.Framework.XLabel();
            this.txtBoard_ADL = new IHIS.Framework.XTextBox();
            this.cboBoard_ADL = new IHIS.Framework.XComboBox();
            this.xLabel118 = new IHIS.Framework.XLabel();
            this.txtStruggle_ADL = new IHIS.Framework.XTextBox();
            this.cboStruggle_ADL = new IHIS.Framework.XComboBox();
            this.xLabel117 = new IHIS.Framework.XLabel();
            this.txtExcretion_ADL = new IHIS.Framework.XTextBox();
            this.cboExcretion_ADL = new IHIS.Framework.XComboBox();
            this.xLabel115 = new IHIS.Framework.XLabel();
            this.txtWash_ADL = new IHIS.Framework.XTextBox();
            this.cboWash_ADL = new IHIS.Framework.XComboBox();
            this.xLabel114 = new IHIS.Framework.XLabel();
            this.txtCloth_ADL = new IHIS.Framework.XTextBox();
            this.cboCloth_ADL = new IHIS.Framework.XComboBox();
            this.xLabel113 = new IHIS.Framework.XLabel();
            this.txtBath_ADL = new IHIS.Framework.XTextBox();
            this.cboBath_ADL = new IHIS.Framework.XComboBox();
            this.xLabel112 = new IHIS.Framework.XLabel();
            this.txtFood_ADL = new IHIS.Framework.XTextBox();
            this.cboFood_ADL = new IHIS.Framework.XComboBox();
            this.xLabel116 = new IHIS.Framework.XLabel();
            this.tabPage3 = new IHIS.X.Magic.Controls.TabPage();
            this.pnlPerceptionRight = new IHIS.Framework.XPanel();
            this.lblMovement = new IHIS.Framework.XLabel();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.txtAssessment5 = new IHIS.Framework.XRichTextBox();
            this.gbxPerception = new IHIS.Framework.XGroupBox();
            this.rbxPerceptionN = new IHIS.Framework.XRadioButton();
            this.rbxPerceptionY = new IHIS.Framework.XRadioButton();
            this.gbxFear = new IHIS.Framework.XGroupBox();
            this.rbxFearN = new IHIS.Framework.XRadioButton();
            this.rbxFearY = new IHIS.Framework.XRadioButton();
            this.lblFear = new IHIS.Framework.XLabel();
            this.txtFear = new IHIS.Framework.XTextBox();
            this.gbxWorry = new IHIS.Framework.XGroupBox();
            this.rbxWorryN = new IHIS.Framework.XRadioButton();
            this.rbxWorryY = new IHIS.Framework.XRadioButton();
            this.lblWorry = new IHIS.Framework.XLabel();
            this.txtWorry = new IHIS.Framework.XTextBox();
            this.gbxMovement = new IHIS.Framework.XGroupBox();
            this.rbxMovementY = new IHIS.Framework.XRadioButton();
            this.rbxMovementN = new IHIS.Framework.XRadioButton();
            this.lblPerception = new IHIS.Framework.XLabel();
            this.gbxPain = new IHIS.Framework.XGroupBox();
            this.rbxPainN = new IHIS.Framework.XRadioButton();
            this.rbxPainY = new IHIS.Framework.XRadioButton();
            this.txtPerception = new IHIS.Framework.XTextBox();
            this.lblPain = new IHIS.Framework.XLabel();
            this.txtPain = new IHIS.Framework.XTextBox();
            this.gbxStagger = new IHIS.Framework.XGroupBox();
            this.rbxStaggerN = new IHIS.Framework.XRadioButton();
            this.rbxStaggerY = new IHIS.Framework.XRadioButton();
            this.gbxDizzy = new IHIS.Framework.XGroupBox();
            this.rbxDizzyY = new IHIS.Framework.XRadioButton();
            this.rbxDizzyN = new IHIS.Framework.XRadioButton();
            this.txtStagger = new IHIS.Framework.XTextBox();
            this.txtDizzy = new IHIS.Framework.XTextBox();
            this.lblStagger = new IHIS.Framework.XLabel();
            this.lblDizzy = new IHIS.Framework.XLabel();
            this.gbxMovementDetail = new System.Windows.Forms.GroupBox();
            this.txtLossPart = new IHIS.Framework.XTextBox();
            this.txtContracture = new IHIS.Framework.XTextBox();
            this.txtParalysis = new IHIS.Framework.XTextBox();
            this.gbxLossPart = new IHIS.Framework.XGroupBox();
            this.rbxLossPartY = new IHIS.Framework.XRadioButton();
            this.rbxLossPartN = new IHIS.Framework.XRadioButton();
            this.gbxContracture = new IHIS.Framework.XGroupBox();
            this.rbxContractureY = new IHIS.Framework.XRadioButton();
            this.rbxContractureN = new IHIS.Framework.XRadioButton();
            this.gbxParalysis = new IHIS.Framework.XGroupBox();
            this.rbxParalysisY = new IHIS.Framework.XRadioButton();
            this.rbxParalysisN = new IHIS.Framework.XRadioButton();
            this.lblLossPart = new IHIS.Framework.XLabel();
            this.lblContracture = new IHIS.Framework.XLabel();
            this.lblParalysis = new IHIS.Framework.XLabel();
            this.pnlPerceptionLeft = new IHIS.Framework.XPanel();
            this.lblSensor = new IHIS.Framework.XLabel();
            this.gbxRecognition = new IHIS.Framework.XGroupBox();
            this.rbxRecognitionY = new IHIS.Framework.XRadioButton();
            this.rbxRecognitionN = new IHIS.Framework.XRadioButton();
            this.lblObstacleSpeech = new IHIS.Framework.XLabel();
            this.txtRecognition = new IHIS.Framework.XTextBox();
            this.txtObstacle = new IHIS.Framework.XTextBox();
            this.gbxSensor = new IHIS.Framework.XGroupBox();
            this.rbxSensorY = new IHIS.Framework.XRadioButton();
            this.rbxSensorN = new IHIS.Framework.XRadioButton();
            this.gbxSensorDetail = new System.Windows.Forms.GroupBox();
            this.txtMouth = new IHIS.Framework.XTextBox();
            this.txtNose = new IHIS.Framework.XTextBox();
            this.txtEarRight = new IHIS.Framework.XTextBox();
            this.txtEarLeft = new IHIS.Framework.XTextBox();
            this.cbxEarLeft = new IHIS.Framework.XCheckBox();
            this.cbxEarRight = new IHIS.Framework.XCheckBox();
            this.txtEyeRight = new IHIS.Framework.XTextBox();
            this.txtEyeLeft = new IHIS.Framework.XTextBox();
            this.cbxEyeLeft = new IHIS.Framework.XCheckBox();
            this.cbxEyeRight = new IHIS.Framework.XCheckBox();
            this.xLabel137 = new IHIS.Framework.XLabel();
            this.xLabel136 = new IHIS.Framework.XLabel();
            this.lblEarAid = new IHIS.Framework.XLabel();
            this.lblLens = new IHIS.Framework.XLabel();
            this.lblGlasses = new IHIS.Framework.XLabel();
            this.xLabel132 = new IHIS.Framework.XLabel();
            this.xLabel131 = new IHIS.Framework.XLabel();
            this.gbxGlasses = new IHIS.Framework.XGroupBox();
            this.rbxGlassesY = new IHIS.Framework.XRadioButton();
            this.rbxGlassesN = new IHIS.Framework.XRadioButton();
            this.gbxLens = new IHIS.Framework.XGroupBox();
            this.rbxLensY = new IHIS.Framework.XRadioButton();
            this.rbxLensN = new IHIS.Framework.XRadioButton();
            this.gbxEarAid = new IHIS.Framework.XGroupBox();
            this.rbxEarAidY = new IHIS.Framework.XRadioButton();
            this.rbxEarAidN = new IHIS.Framework.XRadioButton();
            this.lblRecognition = new IHIS.Framework.XLabel();
            this.lblSense_style = new IHIS.Framework.XLabel();
            this.lblObstacle = new IHIS.Framework.XLabel();
            this.gbxObstacle = new IHIS.Framework.XGroupBox();
            this.rbxObstacleY = new IHIS.Framework.XRadioButton();
            this.rbxObstacleN = new IHIS.Framework.XRadioButton();
            this.cboSenseLevel = new IHIS.Framework.XComboBox();
            this.gbxObstacleSense = new IHIS.Framework.XGroupBox();
            this.rbxObstcleSenseY = new IHIS.Framework.XRadioButton();
            this.rbxObstcleSenseN = new IHIS.Framework.XRadioButton();
            this.gbxObstacleSpeech = new IHIS.Framework.XGroupBox();
            this.rbxObstacleSpeechY = new IHIS.Framework.XRadioButton();
            this.rbxObstacleSpeechN = new IHIS.Framework.XRadioButton();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.tabPage6 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel15 = new IHIS.Framework.XPanel();
            this.gbxFamily = new IHIS.Framework.XGroupBox();
            this.rbxFamilyY = new IHIS.Framework.XRadioButton();
            this.rbxFamilyN = new IHIS.Framework.XRadioButton();
            this.txtStressManage = new IHIS.Framework.XTextBox();
            this.gbxStress = new IHIS.Framework.XGroupBox();
            this.rbxStressY = new IHIS.Framework.XRadioButton();
            this.rbxStressN = new IHIS.Framework.XRadioButton();
            this.xLabel30 = new IHIS.Framework.XLabel();
            this.txtStress = new IHIS.Framework.XTextBox();
            this.lblStress = new IHIS.Framework.XLabel();
            this.gbxMens = new System.Windows.Forms.GroupBox();
            this.txtMensesAge = new IHIS.Framework.XEditMask();
            this.gbxPregnancy = new IHIS.Framework.XGroupBox();
            this.rbxPregnancyY = new IHIS.Framework.XRadioButton();
            this.rbxPregnancyN = new IHIS.Framework.XRadioButton();
            this.lblPregnancy = new IHIS.Framework.XLabel();
            this.gbxMensesProblem = new IHIS.Framework.XGroupBox();
            this.rbxMensesProblemY = new IHIS.Framework.XRadioButton();
            this.rbxMensesProblemN = new IHIS.Framework.XRadioButton();
            this.txtMensesProblem = new IHIS.Framework.XTextBox();
            this.cboMenses = new IHIS.Framework.XComboBox();
            this.lblMensesProblem = new IHIS.Framework.XLabel();
            this.xLabel166 = new IHIS.Framework.XLabel();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.gbxHobby = new IHIS.Framework.XGroupBox();
            this.rbxHobbyY = new IHIS.Framework.XRadioButton();
            this.rbxHobbyN = new IHIS.Framework.XRadioButton();
            this.txtHobby = new IHIS.Framework.XTextBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.txtJobMate = new IHIS.Framework.XTextBox();
            this.txtJob = new IHIS.Framework.XTextBox();
            this.xLabel163 = new IHIS.Framework.XLabel();
            this.xLabel162 = new IHIS.Framework.XLabel();
            this.lblHobby = new IHIS.Framework.XLabel();
            this.lblBarrierFree = new IHIS.Framework.XLabel();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.txtAssessment7 = new IHIS.Framework.XRichTextBox();
            this.gbxReligion = new IHIS.Framework.XGroupBox();
            this.rbxReligionY = new IHIS.Framework.XRadioButton();
            this.rbxReligionN = new IHIS.Framework.XRadioButton();
            this.txtReligion = new IHIS.Framework.XTextBox();
            this.txtFamily = new IHIS.Framework.XTextBox();
            this.cboHouseKind = new IHIS.Framework.XComboBox();
            this.lblFamily = new IHIS.Framework.XLabel();
            this.lblHouse_kind = new IHIS.Framework.XLabel();
            this.lblReligion = new IHIS.Framework.XLabel();
            this.gbxBarrierFree = new IHIS.Framework.XGroupBox();
            this.rbxBarrierFreeY = new IHIS.Framework.XRadioButton();
            this.rbxBarrierFreeN = new IHIS.Framework.XRadioButton();
            this.xEditMask1 = new IHIS.Framework.XEditMask();
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.grdINP1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.layINP1001 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem146 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem147 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem148 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem150 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem151 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem153 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem154 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem155 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem156 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem157 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem320 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem424 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem168 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem169 = new IHIS.Framework.SingleLayoutItem();
            this.layNUR1001 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem318 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem319 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem325 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem149 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem152 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem158 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem159 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem161 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem162 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem163 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem164 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem165 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem166 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem167 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem170 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem171 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem172 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem173 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem174 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem175 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem176 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem177 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem178 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem179 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem180 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem181 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem182 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem183 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem184 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem185 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem186 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem187 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem188 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem189 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem190 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem191 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem192 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem193 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem194 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem195 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem196 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem197 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem198 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem199 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem200 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem201 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem202 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem203 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem204 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem205 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem206 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem316 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem207 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem208 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem209 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem210 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem211 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem212 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem213 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem214 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem215 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem216 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem217 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem218 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem219 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem220 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem221 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem222 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem223 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem224 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem225 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem226 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem227 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem228 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem229 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem230 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem231 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem232 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem233 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem234 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem235 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem236 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem237 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem238 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem239 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem240 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem241 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem242 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem243 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem244 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem245 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem246 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem247 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem248 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem249 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem250 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem251 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem252 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem253 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem254 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem255 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem256 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem257 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem258 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem259 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem260 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem261 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem262 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem263 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem264 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem265 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem266 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem267 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem268 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem269 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem270 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem271 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem272 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem273 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem274 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem275 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem276 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem277 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem278 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem279 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem280 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem281 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem282 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem283 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem284 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem285 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem286 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem287 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem288 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem289 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem290 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem291 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem292 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem293 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem294 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem295 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem296 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem297 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem298 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem299 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem300 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem301 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem302 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem303 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem304 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem305 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem306 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem307 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem308 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem309 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem310 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem311 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem312 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem317 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem313 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem314 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem315 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
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
            this.layFkinp1001 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem160 = new IHIS.Framework.SingleLayoutItem();
            this.layReserInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.layCopy = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem322 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem346 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem347 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem348 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem349 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem350 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem351 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem352 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem353 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem354 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem355 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem356 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem357 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem358 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem359 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem360 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem361 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem362 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem363 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem364 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem365 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem366 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem367 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem368 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem369 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem370 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem371 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem372 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem373 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem374 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem375 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem376 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem377 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem378 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem379 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem380 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem381 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem382 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem383 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem384 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem385 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem386 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem387 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem388 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem389 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem390 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem391 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem392 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem393 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem394 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem395 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem396 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem397 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem398 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem399 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem400 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem401 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem402 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem403 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem404 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem405 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem406 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem407 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem408 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem409 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem410 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem411 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem412 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem413 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem414 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem415 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem416 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem417 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem418 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem419 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem420 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem421 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem422 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem423 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem425 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem426 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem427 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem428 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem429 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem430 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem431 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem432 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem433 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem434 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem435 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem436 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem437 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem438 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem439 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem440 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem441 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem442 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem443 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem444 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem445 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem446 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem447 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem448 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem449 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem450 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem451 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem452 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem453 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem454 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem455 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem456 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem457 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem458 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem459 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem460 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem461 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem462 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem463 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem464 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem465 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem466 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem467 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem468 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem469 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem470 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem471 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem472 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem473 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem474 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem475 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem476 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem477 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem478 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem479 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem480 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem481 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem482 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem483 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem484 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem485 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem486 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem487 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem488 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem489 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem490 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem491 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem492 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem493 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem494 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem495 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem496 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem497 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem498 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem499 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem500 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem501 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem502 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem503 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem504 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem505 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem506 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem507 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem508 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem509 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem510 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1004)).BeginInit();
            this.gbxWith.SuspendLayout();
            this.gbxLive.SuspendLayout();
            this.xPanel5.SuspendLayout();
            this.pnlINP1004.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1002)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.tabPatient.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlPatientInfoRight.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnListTukki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0106)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.pnlPatientInfoLeft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlHealthRight.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.xPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1017)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1016)).BeginInit();
            this.pnlHealthLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmoking)).BeginInit();
            this.gbxHealthCare.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gbxBringDrug.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1029)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.gbxUrinWill.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbxDungWill.SuspendLayout();
            this.pnlFood.SuspendLayout();
            this.gbxFalseTeeth.SuspendLayout();
            this.gbxMouthPollution.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbxDysphagia.SuspendLayout();
            this.gbxAppetite.SuspendLayout();
            this.gbxFoodDislike.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.xPanel9.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.gbxSleepEnough.SuspendLayout();
            this.xPanel14.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.gbxNeedSupport.SuspendLayout();
            this.gbxNeedCare.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.pnlPerceptionRight.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.gbxPerception.SuspendLayout();
            this.gbxFear.SuspendLayout();
            this.gbxWorry.SuspendLayout();
            this.gbxMovement.SuspendLayout();
            this.gbxPain.SuspendLayout();
            this.gbxStagger.SuspendLayout();
            this.gbxDizzy.SuspendLayout();
            this.gbxMovementDetail.SuspendLayout();
            this.gbxLossPart.SuspendLayout();
            this.gbxContracture.SuspendLayout();
            this.gbxParalysis.SuspendLayout();
            this.pnlPerceptionLeft.SuspendLayout();
            this.gbxRecognition.SuspendLayout();
            this.gbxSensor.SuspendLayout();
            this.gbxSensorDetail.SuspendLayout();
            this.gbxGlasses.SuspendLayout();
            this.gbxLens.SuspendLayout();
            this.gbxEarAid.SuspendLayout();
            this.gbxObstacle.SuspendLayout();
            this.gbxObstacleSense.SuspendLayout();
            this.gbxObstacleSpeech.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.xPanel15.SuspendLayout();
            this.gbxFamily.SuspendLayout();
            this.gbxStress.SuspendLayout();
            this.gbxMens.SuspendLayout();
            this.gbxPregnancy.SuspendLayout();
            this.gbxMensesProblem.SuspendLayout();
            this.gbxHobby.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.gbxReligion.SuspendLayout();
            this.gbxBarrierFree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layReserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "진료자.gif");
            this.ImageList.Images.SetKeyName(1, "추가.gif");
            this.ImageList.Images.SetKeyName(2, "행삭제.gif");
            this.ImageList.Images.SetKeyName(3, "new01.gif");
            this.ImageList.Images.SetKeyName(4, "자원관리.ico");
            this.ImageList.Images.SetKeyName(5, "외래간호.ico");
            this.ImageList.Images.SetKeyName(6, "관리계.ico");
            this.ImageList.Images.SetKeyName(7, "응급실간호.ico");
            this.ImageList.Images.SetKeyName(8, "식이관리.ico");
            this.ImageList.Images.SetKeyName(9, "간호기록.ico");
            this.ImageList.Images.SetKeyName(10, "");
            this.ImageList.Images.SetKeyName(11, "RANG.ico");
            this.ImageList.Images.SetKeyName(12, "++.gif");
            // 
            // xPanel2
            // 
            this.xPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel2.Controls.Add(this.grdINP1004);
            this.xPanel2.Controls.Add(this.xPanel5);
            this.xPanel2.Controls.Add(this.pnlINP1004);
            this.xPanel2.Controls.Add(this.xPanel3);
            this.xPanel2.Location = new System.Drawing.Point(13, 272);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(792, 257);
            this.xPanel2.TabIndex = 15;
            // 
            // grdINP1004
            // 
            this.grdINP1004.CallerID = '4';
            this.grdINP1004.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell180,
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
            this.xEditGridCell58});
            this.grdINP1004.ColPerLine = 7;
            this.grdINP1004.Cols = 7;
            this.grdINP1004.ControlBinding = true;
            this.grdINP1004.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1004.FixedRows = 1;
            this.grdINP1004.HeaderHeights.Add(21);
            this.grdINP1004.Location = new System.Drawing.Point(0, 28);
            this.grdINP1004.Name = "grdINP1004";
            this.grdINP1004.QuerySQL = resources.GetString("grdINP1004.QuerySQL");
            this.grdINP1004.Rows = 2;
            this.grdINP1004.Size = new System.Drawing.Size(435, 227);
            this.grdINP1004.TabIndex = 2;
            this.grdINP1004.TabStop = false;
            this.grdINP1004.UseDefaultTransaction = false;
            this.grdINP1004.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdINP1004_QueryEnd);
            this.grdINP1004.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1004_QueryStarting);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "priority";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell35.CellWidth = 30;
            this.xEditGridCell35.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell35.HeaderText = "順位";
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 9;
            this.xEditGridCell36.CellName = "bunho";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderText = "bunho";
            this.xEditGridCell36.IsNotNull = true;
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.BindControl = this.txtName;
            this.xEditGridCell37.CellLen = 20;
            this.xEditGridCell37.CellName = "name";
            this.xEditGridCell37.CellWidth = 84;
            this.xEditGridCell37.Col = 1;
            this.xEditGridCell37.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell37.HeaderText = "氏名";
            // 
            // txtName
            // 
            this.txtName.ApplyByteLimit = true;
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtName.Location = new System.Drawing.Point(87, 34);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(116, 20);
            this.txtName.TabIndex = 2;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.BindControl = this.fbxZipCode1;
            this.xEditGridCell38.CellLen = 3;
            this.xEditGridCell38.CellName = "zip_code1";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.HeaderText = "zip_code1";
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // fbxZipCode1
            // 
            this.fbxZipCode1.Location = new System.Drawing.Point(45, 9);
            this.fbxZipCode1.MaxLength = 3;
            this.fbxZipCode1.Name = "fbxZipCode1";
            this.fbxZipCode1.Size = new System.Drawing.Size(58, 20);
            this.fbxZipCode1.TabIndex = 999;
            this.fbxZipCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxZipCode1.Visible = false;
            this.fbxZipCode1.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.BindControl = this.txtZipCode2;
            this.xEditGridCell39.CellLen = 4;
            this.xEditGridCell39.CellName = "zip_code2";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.HeaderText = "zip_code2";
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // txtZipCode2
            // 
            this.txtZipCode2.Location = new System.Drawing.Point(115, 9);
            this.txtZipCode2.MaxLength = 4;
            this.txtZipCode2.Name = "txtZipCode2";
            this.txtZipCode2.Size = new System.Drawing.Size(52, 20);
            this.txtZipCode2.TabIndex = 999;
            this.txtZipCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtZipCode2.Visible = false;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.BindControl = this.fbxAddress1;
            this.xEditGridCell40.CellLen = 60;
            this.xEditGridCell40.CellName = "address1";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.HeaderText = "address1";
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // fbxAddress1
            // 
            this.fbxAddress1.ApplyByteLimit = true;
            this.fbxAddress1.Location = new System.Drawing.Point(174, 9);
            this.fbxAddress1.MaxLength = 60;
            this.fbxAddress1.Name = "fbxAddress1";
            this.fbxAddress1.Size = new System.Drawing.Size(161, 20);
            this.fbxAddress1.TabIndex = 999;
            this.fbxAddress1.Visible = false;
            this.fbxAddress1.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.BindControl = this.txtAddress2;
            this.xEditGridCell41.CellLen = 40;
            this.xEditGridCell41.CellName = "address2";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.HeaderText = "address2";
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // txtAddress2
            // 
            this.txtAddress2.ApplyByteLimit = true;
            this.txtAddress2.Location = new System.Drawing.Point(45, 32);
            this.txtAddress2.MaxLength = 40;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(290, 20);
            this.txtAddress2.TabIndex = 999;
            this.txtAddress2.Visible = false;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.BindControl = this.txtTel1;
            this.xEditGridCell42.CellLen = 15;
            this.xEditGridCell42.CellName = "tel1";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.HeaderText = "tel1";
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // txtTel1
            // 
            this.txtTel1.Location = new System.Drawing.Point(95, 56);
            this.txtTel1.MaxLength = 15;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(182, 20);
            this.txtTel1.TabIndex = 999;
            this.txtTel1.Visible = false;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.BindControl = this.txtTel2;
            this.xEditGridCell43.CellLen = 15;
            this.xEditGridCell43.CellName = "tel2";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.HeaderText = "tel2";
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // txtTel2
            // 
            this.txtTel2.Location = new System.Drawing.Point(95, 80);
            this.txtTel2.MaxLength = 15;
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(182, 20);
            this.txtTel2.TabIndex = 999;
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
            this.xEditGridCell45.CellWidth = 98;
            this.xEditGridCell45.Col = 6;
            this.xEditGridCell45.DisplayMemoText = true;
            this.xEditGridCell45.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell45.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell45.HeaderText = "備考";
            // 
            // txtBigo
            // 
            this.txtBigo.ApplyByteLimit = true;
            this.txtBigo.Location = new System.Drawing.Point(87, 194);
            this.txtBigo.MaxLength = 80;
            this.txtBigo.Name = "txtBigo";
            this.txtBigo.Size = new System.Drawing.Size(212, 20);
            this.txtBigo.TabIndex = 7;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.BindControl = this.fbxBoninGubun;
            this.xEditGridCell46.CellLen = 1;
            this.xEditGridCell46.CellName = "bonin_gubun";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.HeaderText = "bonin_gubun";
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // fbxBoninGubun
            // 
            this.fbxBoninGubun.ApplyByteLimit = true;
            this.fbxBoninGubun.FindWorker = this.fwkCommon;
            this.fbxBoninGubun.Location = new System.Drawing.Point(87, 66);
            this.fbxBoninGubun.MaxLength = 1;
            this.fbxBoninGubun.Name = "fbxBoninGubun";
            this.fbxBoninGubun.Size = new System.Drawing.Size(66, 20);
            this.fbxBoninGubun.TabIndex = 3;
            this.fbxBoninGubun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxBoninGubun.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxBoninGubun_FindSelected);
            this.fbxBoninGubun.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.FormText = "コード照会";
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.BindControl = this.txtBoninGubunName;
            this.xEditGridCell180.CellLen = 80;
            this.xEditGridCell180.CellName = "bonin_gubun_name";
            this.xEditGridCell180.CellWidth = 64;
            this.xEditGridCell180.Col = 2;
            this.xEditGridCell180.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell180.HeaderText = "続柄";
            this.xEditGridCell180.IsUpdCol = false;
            // 
            // txtBoninGubunName
            // 
            this.txtBoninGubunName.Location = new System.Drawing.Point(157, 66);
            this.txtBoninGubunName.Name = "txtBoninGubunName";
            this.txtBoninGubunName.Size = new System.Drawing.Size(100, 20);
            this.txtBoninGubunName.TabIndex = 999;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "old_seq";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.HeaderText = "old_seq";
            this.xEditGridCell48.IsUpdCol = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.BindControl = this.cboTelGubun;
            this.xEditGridCell49.CellName = "tel_gubun";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "tel_gubun";
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // cboTelGubun
            // 
            this.cboTelGubun.Location = new System.Drawing.Point(279, 55);
            this.cboTelGubun.Name = "cboTelGubun";
            this.cboTelGubun.Size = new System.Drawing.Size(56, 21);
            this.cboTelGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTelGubun.TabIndex = 999;
            this.cboTelGubun.Visible = false;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.BindControl = this.cboTelGubun2;
            this.xEditGridCell50.CellName = "tel_gubun2";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "tel_gubun2";
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // cboTelGubun2
            // 
            this.cboTelGubun2.Location = new System.Drawing.Point(279, 79);
            this.cboTelGubun2.Name = "cboTelGubun2";
            this.cboTelGubun2.Size = new System.Drawing.Size(56, 21);
            this.cboTelGubun2.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTelGubun2.TabIndex = 999;
            this.cboTelGubun2.Visible = false;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "tel_gubun3";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "tel_gubun3";
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellLen = 1;
            this.xEditGridCell52.CellName = "retrieve_yn";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.HeaderText = "retrieve_yn";
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.BindControl = this.txtName2;
            this.xEditGridCell53.CellName = "name2";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.HeaderText = "name2";
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // txtName2
            // 
            this.txtName2.ApplyByteLimit = true;
            this.txtName2.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtName2.Location = new System.Drawing.Point(87, 2);
            this.txtName2.MaxLength = 20;
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(116, 20);
            this.txtName2.TabIndex = 1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.BindControl = this.dtpBirth;
            this.xEditGridCell54.CellName = "birth";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell54.CellWidth = 63;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell54.HeaderText = "誕生日";
            this.xEditGridCell54.IsJapanYearType = true;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // dtpBirth
            // 
            this.dtpBirth.IsJapanYearType = true;
            this.dtpBirth.Location = new System.Drawing.Point(87, 98);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(116, 20);
            this.dtpBirth.TabIndex = 4;
            this.dtpBirth.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpBirth_DataValidating);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "age";
            this.xEditGridCell55.CellWidth = 35;
            this.xEditGridCell55.Col = 3;
            this.xEditGridCell55.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell55.HeaderText = "年齢";
            this.xEditGridCell55.IsReadOnly = true;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.BindControl = this.gbxWith;
            this.xEditGridCell56.CellName = "with_yn";
            this.xEditGridCell56.CellWidth = 48;
            this.xEditGridCell56.Col = 4;
            this.xEditGridCell56.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell56.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell56.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell56.HeaderText = "同居";
            this.xEditGridCell56.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxWith
            // 
            this.gbxWith.Controls.Add(this.rbxWithN);
            this.gbxWith.Controls.Add(this.rbxWithY);
            this.gbxWith.Location = new System.Drawing.Point(90, 125);
            this.gbxWith.Name = "gbxWith";
            this.gbxWith.Size = new System.Drawing.Size(131, 30);
            this.gbxWith.TabIndex = 5;
            this.gbxWith.TabStop = false;
            // 
            // rbxWithN
            // 
            this.rbxWithN.AutoSize = true;
            this.rbxWithN.CheckedValue = "N";
            this.rbxWithN.Location = new System.Drawing.Point(72, 9);
            this.rbxWithN.Name = "rbxWithN";
            this.rbxWithN.Size = new System.Drawing.Size(57, 17);
            this.rbxWithN.TabIndex = 2;
            this.rbxWithN.TabStop = true;
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
            this.rbxWithY.TabIndex = 1;
            this.rbxWithY.TabStop = true;
            this.rbxWithY.Text = "はい";
            this.rbxWithY.UseVisualStyleBackColor = true;
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
            // xEditGridCell57
            // 
            this.xEditGridCell57.BindControl = this.gbxLive;
            this.xEditGridCell57.CellName = "live_yn";
            this.xEditGridCell57.CellWidth = 55;
            this.xEditGridCell57.Col = 5;
            this.xEditGridCell57.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell57.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell57.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell57.HeaderText = "状態";
            this.xEditGridCell57.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxLive
            // 
            this.gbxLive.Controls.Add(this.rbxLiveN);
            this.gbxLive.Controls.Add(this.rbxLiveY);
            this.gbxLive.Location = new System.Drawing.Point(90, 157);
            this.gbxLive.Name = "gbxLive";
            this.gbxLive.Size = new System.Drawing.Size(131, 30);
            this.gbxLive.TabIndex = 6;
            this.gbxLive.TabStop = false;
            // 
            // rbxLiveN
            // 
            this.rbxLiveN.AutoSize = true;
            this.rbxLiveN.CheckedValue = "N";
            this.rbxLiveN.Location = new System.Drawing.Point(72, 9);
            this.rbxLiveN.Name = "rbxLiveN";
            this.rbxLiveN.Size = new System.Drawing.Size(51, 17);
            this.rbxLiveN.TabIndex = 2;
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
            this.rbxLiveY.TabIndex = 1;
            this.rbxLiveY.TabStop = true;
            this.rbxLiveY.Text = "生存";
            this.rbxLiveY.UseVisualStyleBackColor = true;
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
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "seq";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.HeaderText = "seq";
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.xLabel26);
            this.xPanel5.Controls.Add(this.xLabel24);
            this.xPanel5.Controls.Add(this.xLabel17);
            this.xPanel5.Controls.Add(this.fbxZipCode1);
            this.xPanel5.Controls.Add(this.xLabel41);
            this.xPanel5.Controls.Add(this.txtZipCode2);
            this.xPanel5.Controls.Add(this.cboTelGubun2);
            this.xPanel5.Controls.Add(this.fbxAddress1);
            this.xPanel5.Controls.Add(this.cboTelGubun);
            this.xPanel5.Controls.Add(this.txtAddress2);
            this.xPanel5.Controls.Add(this.txtTel1);
            this.xPanel5.Controls.Add(this.txtTel2);
            this.xPanel5.Location = new System.Drawing.Point(435, 249);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(354, 134);
            this.xPanel5.TabIndex = 999;
            this.xPanel5.Visible = false;
            // 
            // xLabel26
            // 
            this.xLabel26.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel26.EdgeRounding = false;
            this.xLabel26.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel26.Location = new System.Drawing.Point(7, 9);
            this.xLabel26.Name = "xLabel26";
            this.xLabel26.Size = new System.Drawing.Size(36, 42);
            this.xLabel26.TabIndex = 999;
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
            this.xLabel24.TabIndex = 999;
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
            this.xLabel17.TabIndex = 999;
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
            this.xLabel41.TabIndex = 999;
            this.xLabel41.Text = "連絡先2";
            this.xLabel41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel41.Visible = false;
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
            this.pnlINP1004.Controls.Add(this.xLabel1);
            this.pnlINP1004.Controls.Add(this.dtpBirth);
            this.pnlINP1004.Controls.Add(this.txtName2);
            this.pnlINP1004.Controls.Add(this.xLabel6);
            this.pnlINP1004.Controls.Add(this.fbxBoninGubun);
            this.pnlINP1004.Controls.Add(this.txtSeq);
            this.pnlINP1004.Controls.Add(this.xLabel21);
            this.pnlINP1004.Controls.Add(this.txtBigo);
            this.pnlINP1004.Controls.Add(this.txtName);
            this.pnlINP1004.Controls.Add(this.xLabel22);
            this.pnlINP1004.Controls.Add(this.xLabel23);
            this.pnlINP1004.Controls.Add(this.xLabel29);
            this.pnlINP1004.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlINP1004.Location = new System.Drawing.Point(435, 28);
            this.pnlINP1004.Name = "pnlINP1004";
            this.pnlINP1004.Size = new System.Drawing.Size(355, 227);
            this.pnlINP1004.TabIndex = 3;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(212, 98);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(33, 20);
            this.txtAge.TabIndex = 999;
            // 
            // lblLive
            // 
            this.lblLive.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblLive.EdgeRounding = false;
            this.lblLive.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblLive.Location = new System.Drawing.Point(2, 162);
            this.lblLive.Name = "lblLive";
            this.lblLive.Size = new System.Drawing.Size(82, 20);
            this.lblLive.TabIndex = 999;
            this.lblLive.Text = "状　　態";
            this.lblLive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWith
            // 
            this.lblWith.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblWith.EdgeRounding = false;
            this.lblWith.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblWith.Location = new System.Drawing.Point(2, 130);
            this.lblWith.Name = "lblWith";
            this.lblWith.Size = new System.Drawing.Size(82, 20);
            this.lblWith.TabIndex = 999;
            this.lblWith.Text = "同　　居";
            this.lblWith.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel5
            // 
            this.xLabel5.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel5.Location = new System.Drawing.Point(246, 99);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(33, 19);
            this.xLabel5.TabIndex = 999;
            this.xLabel5.Text = "才";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(2, 98);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(82, 20);
            this.xLabel1.TabIndex = 999;
            this.xLabel1.Text = "生年月日";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(2, 2);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(82, 20);
            this.xLabel6.TabIndex = 999;
            this.xLabel6.Text = "氏名(ｶﾅ)";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSeq
            // 
            this.txtSeq.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtSeq.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtSeq.GeneralNumberFormat = true;
            this.txtSeq.Location = new System.Drawing.Point(259, 2);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.ReadOnly = true;
            this.txtSeq.Size = new System.Drawing.Size(40, 20);
            this.txtSeq.TabIndex = 999;
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
            this.xLabel21.TabIndex = 999;
            this.xLabel21.Text = "順位";
            this.xLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel21.Visible = false;
            // 
            // xLabel22
            // 
            this.xLabel22.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel22.EdgeRounding = false;
            this.xLabel22.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel22.Location = new System.Drawing.Point(2, 194);
            this.xLabel22.Name = "xLabel22";
            this.xLabel22.Size = new System.Drawing.Size(82, 20);
            this.xLabel22.TabIndex = 999;
            this.xLabel22.Text = "備　　考";
            this.xLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel23
            // 
            this.xLabel23.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel23.EdgeRounding = false;
            this.xLabel23.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel23.Location = new System.Drawing.Point(2, 66);
            this.xLabel23.Name = "xLabel23";
            this.xLabel23.Size = new System.Drawing.Size(82, 20);
            this.xLabel23.TabIndex = 999;
            this.xLabel23.Text = "続　　柄";
            this.xLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel29
            // 
            this.xLabel29.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel29.EdgeRounding = false;
            this.xLabel29.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel29.Location = new System.Drawing.Point(2, 34);
            this.xLabel29.Name = "xLabel29";
            this.xLabel29.Size = new System.Drawing.Size(82, 20);
            this.xLabel29.TabIndex = 999;
            this.xLabel29.Text = "氏名(漢字)";
            this.xLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnDelete);
            this.xPanel3.Controls.Add(this.btnInsert);
            this.xPanel3.Controls.Add(this.pictureBox1);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.Location = new System.Drawing.Point(0, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(790, 28);
            this.xPanel3.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 2;
            this.btnDelete.ImageList = this.ImageList;
            this.btnDelete.Location = new System.Drawing.Point(137, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "削除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.ImageIndex = 1;
            this.btnInsert.ImageList = this.ImageList;
            this.btnInsert.Location = new System.Drawing.Point(2, 3);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(129, 23);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "家族構成員入力";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(790, 28);
            this.pictureBox1.TabIndex = 999;
            this.pictureBox1.TabStop = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.BindControl = this.gbxLive;
            this.xEditGridCell19.CellName = "live_y";
            this.xEditGridCell19.Col = 6;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "状態Y";
            this.xEditGridCell19.Row = 1;
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkFind
            // 
            this.fwkFind.InputSQL = resources.GetString("fwkFind.InputSQL");
            this.fwkFind.IsSetControlText = true;
            this.fwkFind.ServerFilter = true;
            this.fwkFind.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkFind_QueryStarting);
            // 
            // lblBlood
            // 
            this.lblBlood.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBlood.EdgeRounding = false;
            this.lblBlood.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.lblBlood.Location = new System.Drawing.Point(208, 95);
            this.lblBlood.Name = "lblBlood";
            this.lblBlood.Size = new System.Drawing.Size(93, 24);
            this.lblBlood.TabIndex = 999;
            this.lblBlood.Text = "血　液　型";
            this.lblBlood.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnNUR9001);
            this.pnlBottom.Controls.Add(this.btnChiryo);
            this.pnlBottom.Controls.Add(this.btnVital);
            this.pnlBottom.Controls.Add(this.txtUpd_gubun);
            this.pnlBottom.Controls.Add(this.txtBunho);
            this.pnlBottom.Controls.Add(this.txtFkinp1001);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Controls.Add(this.txtDrug_comment);
            this.pnlBottom.Controls.Add(this.grdNUR1002);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 598);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1156, 37);
            this.pnlBottom.TabIndex = 999;
            // 
            // btnNUR9001
            // 
            this.btnNUR9001.ImageIndex = 9;
            this.btnNUR9001.ImageList = this.ImageList;
            this.btnNUR9001.Location = new System.Drawing.Point(584, 4);
            this.btnNUR9001.Name = "btnNUR9001";
            this.btnNUR9001.Size = new System.Drawing.Size(120, 28);
            this.btnNUR9001.TabIndex = 1002;
            this.btnNUR9001.Text = "看護経過記録";
            this.btnNUR9001.Click += new System.EventHandler(this.btnNUR9001_Click);
            // 
            // btnChiryo
            // 
            this.btnChiryo.Image = ((System.Drawing.Image)(resources.GetObject("btnChiryo.Image")));
            this.btnChiryo.Location = new System.Drawing.Point(706, 4);
            this.btnChiryo.Name = "btnChiryo";
            this.btnChiryo.Size = new System.Drawing.Size(97, 28);
            this.btnChiryo.TabIndex = 1001;
            this.btnChiryo.Text = "治療計画";
            this.btnChiryo.Click += new System.EventHandler(this.btnChiryo_Click);
            // 
            // btnVital
            // 
            this.btnVital.Image = ((System.Drawing.Image)(resources.GetObject("btnVital.Image")));
            this.btnVital.Location = new System.Drawing.Point(805, 3);
            this.btnVital.Name = "btnVital";
            this.btnVital.Size = new System.Drawing.Size(99, 28);
            this.btnVital.TabIndex = 1000;
            this.btnVital.Text = "温度板照会";
            this.btnVital.Click += new System.EventHandler(this.btnVital_Click);
            // 
            // txtUpd_gubun
            // 
            this.txtUpd_gubun.Location = new System.Drawing.Point(382, 6);
            this.txtUpd_gubun.MaxLength = 1;
            this.txtUpd_gubun.Name = "txtUpd_gubun";
            this.txtUpd_gubun.Size = new System.Drawing.Size(17, 20);
            this.txtUpd_gubun.TabIndex = 999;
            this.txtUpd_gubun.Visible = false;
            // 
            // txtBunho
            // 
            this.txtBunho.Location = new System.Drawing.Point(280, 6);
            this.txtBunho.Name = "txtBunho";
            this.txtBunho.Size = new System.Drawing.Size(100, 20);
            this.txtBunho.TabIndex = 999;
            this.txtBunho.Visible = false;
            // 
            // txtFkinp1001
            // 
            this.txtFkinp1001.Location = new System.Drawing.Point(178, 6);
            this.txtFkinp1001.Name = "txtFkinp1001";
            this.txtFkinp1001.Size = new System.Drawing.Size(100, 20);
            this.txtFkinp1001.TabIndex = 999;
            this.txtFkinp1001.Visible = false;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(910, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(244, 35);
            this.btnList.TabIndex = 999;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // txtDrug_comment
            // 
            this.txtDrug_comment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDrug_comment.Location = new System.Drawing.Point(40, -78);
            this.txtDrug_comment.MaxLength = 4000;
            this.txtDrug_comment.Multiline = true;
            this.txtDrug_comment.Name = "txtDrug_comment";
            this.txtDrug_comment.Size = new System.Drawing.Size(803, 32);
            this.txtDrug_comment.TabIndex = 999;
            // 
            // grdNUR1002
            // 
            this.grdNUR1002.CallerID = '2';
            this.grdNUR1002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell12,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell11});
            this.grdNUR1002.ColPerLine = 2;
            this.grdNUR1002.Cols = 3;
            this.grdNUR1002.ControlBinding = true;
            this.grdNUR1002.FixedCols = 1;
            this.grdNUR1002.FixedRows = 1;
            this.grdNUR1002.FocusColumnName = "drug_comment";
            this.grdNUR1002.HeaderHeights.Add(21);
            this.grdNUR1002.Location = new System.Drawing.Point(-16, -306);
            this.grdNUR1002.Name = "grdNUR1002";
            this.grdNUR1002.QuerySQL = resources.GetString("grdNUR1002.QuerySQL");
            this.grdNUR1002.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR1002.RowHeaderVisible = true;
            this.grdNUR1002.Rows = 2;
            this.grdNUR1002.Size = new System.Drawing.Size(803, 264);
            this.grdNUR1002.TabIndex = 999;
            this.grdNUR1002.UseDefaultTransaction = false;
            this.grdNUR1002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1002_QueryStarting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkinp1001";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "fkinp1001";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "bunho";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "bunho";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "insert_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 180;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell3.HeaderText = "入力日付";
            this.xEditGridCell3.IsJapanYearType = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "ser";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "順番";
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.txtDrug_comment;
            this.xEditGridCell5.CellLen = 4000;
            this.xEditGridCell5.CellName = "drug_comment";
            this.xEditGridCell5.CellWidth = 579;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.DisplayMemoText = true;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell5.HeaderText = "薬コメント";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "tag";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "tag";
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // btnAllergy
            // 
            this.btnAllergy.ImageIndex = 10;
            this.btnAllergy.ImageList = this.ImageList;
            this.btnAllergy.Location = new System.Drawing.Point(322, 173);
            this.btnAllergy.Name = "btnAllergy";
            this.btnAllergy.Size = new System.Drawing.Size(62, 21);
            this.btnAllergy.TabIndex = 2;
            this.btnAllergy.Text = "修正";
            this.btnAllergy.Click += new System.EventHandler(this.btnAllergy_Click);
            // 
            // btnInfe
            // 
            this.btnInfe.ImageIndex = 11;
            this.btnInfe.ImageList = this.ImageList;
            this.btnInfe.Location = new System.Drawing.Point(322, 25);
            this.btnInfe.Name = "btnInfe";
            this.btnInfe.Size = new System.Drawing.Size(62, 21);
            this.btnInfe.TabIndex = 1;
            this.btnInfe.Text = "修正";
            this.btnInfe.Click += new System.EventHandler(this.btnInfe_Click);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.tabPatient);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Location = new System.Drawing.Point(313, 33);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(843, 565);
            this.pnlFill.TabIndex = 999;
            // 
            // tabPatient
            // 
            this.tabPatient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPatient.IDEPixelArea = true;
            this.tabPatient.IDEPixelBorder = false;
            this.tabPatient.ImageList = this.ImageList;
            this.tabPatient.Location = new System.Drawing.Point(0, 0);
            this.tabPatient.Name = "tabPatient";
            this.tabPatient.SelectedIndex = 0;
            this.tabPatient.SelectedTab = this.tabPage1;
            this.tabPatient.Size = new System.Drawing.Size(841, 563);
            this.tabPatient.TabIndex = 0;
            this.tabPatient.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage4,
            this.tabPage5,
            this.tabPage3,
            this.tabPage6});
            this.tabPatient.TabStop = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlPatientInfoRight);
            this.tabPage1.Controls.Add(this.pnlPatientInfoLeft);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(841, 538);
            this.tabPage1.TabIndex = 999;
            this.tabPage1.Title = "基本情報";
            // 
            // pnlPatientInfoRight
            // 
            this.pnlPatientInfoRight.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlPatientInfoRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPatientInfoRight.Controls.Add(this.dbxWriter);
            this.pnlPatientInfoRight.Controls.Add(this.fbxWriter);
            this.pnlPatientInfoRight.Controls.Add(this.dtpOutdate);
            this.pnlPatientInfoRight.Controls.Add(this.btnNurseOpen);
            this.pnlPatientInfoRight.Controls.Add(this.cboDignosisGubun);
            this.pnlPatientInfoRight.Controls.Add(this.xLabel139);
            this.pnlPatientInfoRight.Controls.Add(this.groupBox17);
            this.pnlPatientInfoRight.Controls.Add(this.groupBox7);
            this.pnlPatientInfoRight.Controls.Add(this.xLabel2);
            this.pnlPatientInfoRight.Controls.Add(this.btnGanhodoOpen);
            this.pnlPatientInfoRight.Controls.Add(this.dbxNurse);
            this.pnlPatientInfoRight.Controls.Add(this.btnTeamOpen);
            this.pnlPatientInfoRight.Controls.Add(this.dbxTeam);
            this.pnlPatientInfoRight.Controls.Add(this.lblTeam);
            this.pnlPatientInfoRight.Controls.Add(this.lblNurse);
            this.pnlPatientInfoRight.Controls.Add(this.xLabel3);
            this.pnlPatientInfoRight.Controls.Add(this.lblHo_code);
            this.pnlPatientInfoRight.Controls.Add(this.dbxHo_Dong);
            this.pnlPatientInfoRight.Controls.Add(this.lblHo_dong);
            this.pnlPatientInfoRight.Controls.Add(this.dbxDoctor);
            this.pnlPatientInfoRight.Controls.Add(this.xLabel79);
            this.pnlPatientInfoRight.Controls.Add(this.dbxGwa);
            this.pnlPatientInfoRight.Controls.Add(this.lblGwa);
            this.pnlPatientInfoRight.Controls.Add(this.btnOrder);
            this.pnlPatientInfoRight.Controls.Add(this.lblDoctor);
            this.pnlPatientInfoRight.Controls.Add(this.lblSang_name);
            this.pnlPatientInfoRight.Controls.Add(this.dtpIndate);
            this.pnlPatientInfoRight.Controls.Add(this.mbxDiagnosisName);
            this.pnlPatientInfoRight.Controls.Add(this.lblInDate);
            this.pnlPatientInfoRight.Controls.Add(this.dbxBed);
            this.pnlPatientInfoRight.Controls.Add(this.lblBed);
            this.pnlPatientInfoRight.Controls.Add(this.dbxHo_Code);
            this.pnlPatientInfoRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPatientInfoRight.Location = new System.Drawing.Point(402, 0);
            this.pnlPatientInfoRight.Name = "pnlPatientInfoRight";
            this.pnlPatientInfoRight.Size = new System.Drawing.Size(439, 538);
            this.pnlPatientInfoRight.TabIndex = 1;
            // 
            // dbxWriter
            // 
            this.dbxWriter.EdgeRounding = false;
            this.dbxWriter.Location = new System.Drawing.Point(252, 216);
            this.dbxWriter.Name = "dbxWriter";
            this.dbxWriter.Size = new System.Drawing.Size(112, 20);
            this.dbxWriter.TabIndex = 1001;
            // 
            // fbxWriter
            // 
            this.fbxWriter.FindWorker = this.fwkFind;
            this.fbxWriter.Location = new System.Drawing.Point(134, 216);
            this.fbxWriter.Name = "fbxWriter";
            this.fbxWriter.Size = new System.Drawing.Size(112, 20);
            this.fbxWriter.TabIndex = 7;
            this.fbxWriter.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxWriter_FindSelected);
            this.fbxWriter.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // dtpOutdate
            // 
            this.dtpOutdate.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.dtpOutdate.IsJapanYearType = true;
            this.dtpOutdate.Location = new System.Drawing.Point(210, 37);
            this.dtpOutdate.Name = "dtpOutdate";
            this.dtpOutdate.ReadOnly = true;
            this.dtpOutdate.Size = new System.Drawing.Size(110, 20);
            this.dtpOutdate.TabIndex = 999;
            this.dtpOutdate.TabStop = false;
            this.dtpOutdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNurseOpen
            // 
            this.btnNurseOpen.ImageIndex = 5;
            this.btnNurseOpen.ImageList = this.ImageList;
            this.btnNurseOpen.Location = new System.Drawing.Point(648, 35);
            this.btnNurseOpen.Name = "btnNurseOpen";
            this.btnNurseOpen.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnNurseOpen.Size = new System.Drawing.Size(53, 28);
            this.btnNurseOpen.TabIndex = 2;
            this.btnNurseOpen.Text = "設定";
            this.btnNurseOpen.Visible = false;
            this.btnNurseOpen.Click += new System.EventHandler(this.btnNurseOpen_Click);
            // 
            // cboDignosisGubun
            // 
            this.cboDignosisGubun.Location = new System.Drawing.Point(287, 127);
            this.cboDignosisGubun.Name = "cboDignosisGubun";
            this.cboDignosisGubun.Size = new System.Drawing.Size(113, 21);
            this.cboDignosisGubun.TabIndex = 4;
            // 
            // xLabel139
            // 
            this.xLabel139.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel139.EdgeRounding = false;
            this.xLabel139.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel139.Location = new System.Drawing.Point(14, 212);
            this.xLabel139.Name = "xLabel139";
            this.xLabel139.Size = new System.Drawing.Size(112, 24);
            this.xLabel139.TabIndex = 999;
            this.xLabel139.Text = "記　録　者";
            this.xLabel139.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.xPanel4);
            this.groupBox17.Controls.Add(this.grdOUT0106);
            this.groupBox17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox17.Location = new System.Drawing.Point(14, 248);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(404, 161);
            this.groupBox17.TabIndex = 8;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "特記事項";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.btnListTukki);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel4.Location = new System.Drawing.Point(3, 123);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(398, 35);
            this.xPanel4.TabIndex = 999;
            // 
            // btnListTukki
            // 
            this.btnListTukki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListTukki.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnListTukki.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnListTukki.Location = new System.Drawing.Point(0, 1);
            this.btnListTukki.Name = "btnListTukki";
            this.btnListTukki.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnListTukki.Size = new System.Drawing.Size(398, 34);
            this.btnListTukki.TabIndex = 999;
            this.btnListTukki.TabStop = false;
            this.btnListTukki.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnListTukki_ButtonClick);
            this.btnListTukki.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnListTukki_MouseDown);
            // 
            // grdOUT0106
            // 
            this.grdOUT0106.CallerID = 'T';
            this.grdOUT0106.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell1,
            this.xEditGridCell17});
            this.grdOUT0106.ColPerLine = 2;
            this.grdOUT0106.Cols = 3;
            this.grdOUT0106.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOUT0106.FixedCols = 1;
            this.grdOUT0106.FixedRows = 1;
            this.grdOUT0106.HeaderHeights.Add(21);
            this.grdOUT0106.Location = new System.Drawing.Point(3, 16);
            this.grdOUT0106.Name = "grdOUT0106";
            this.grdOUT0106.QuerySQL = resources.GetString("grdOUT0106.QuerySQL");
            this.grdOUT0106.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdOUT0106.RowHeaderVisible = true;
            this.grdOUT0106.Rows = 2;
            this.grdOUT0106.Size = new System.Drawing.Size(398, 142);
            this.grdOUT0106.TabIndex = 0;
            this.grdOUT0106.TabStop = false;
            this.grdOUT0106.ToolTipActive = true;
            this.grdOUT0106.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOUT0106_QueryStarting);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell14.CellLen = 80;
            this.xEditGridCell14.CellName = "comments";
            this.xEditGridCell14.CellWidth = 280;
            this.xEditGridCell14.Col = 1;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "参考";
            this.xEditGridCell14.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.CellName = "ser";
            this.xEditGridCell15.CellWidth = 50;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.HeaderText = "順番";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "display_yn";
            this.xEditGridCell17.CellWidth = 71;
            this.xEditGridCell17.Col = 2;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell17.HeaderText = "医師表示";
            this.xEditGridCell17.InitValue = "N";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtAssessment0);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox7.Location = new System.Drawing.Point(11, 415);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(404, 116);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "備考";
            // 
            // txtAssessment0
            // 
            this.txtAssessment0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAssessment0.EnterKeyToTab = false;
            this.txtAssessment0.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAssessment0.Location = new System.Drawing.Point(3, 16);
            this.txtAssessment0.MaxLength = 4000;
            this.txtAssessment0.Name = "txtAssessment0";
            this.txtAssessment0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtAssessment0.Size = new System.Drawing.Size(398, 97);
            this.txtAssessment0.TabIndex = 0;
            this.txtAssessment0.Text = "";
            // 
            // xLabel2
            // 
            this.xLabel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel2.Image = ((System.Drawing.Image)(resources.GetObject("xLabel2.Image")));
            this.xLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel2.Location = new System.Drawing.Point(14, 186);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(128, 24);
            this.xLabel2.TabIndex = 999;
            this.xLabel2.Text = "看護情報";
            // 
            // btnGanhodoOpen
            // 
            this.btnGanhodoOpen.ImageIndex = 6;
            this.btnGanhodoOpen.ImageList = this.ImageList;
            this.btnGanhodoOpen.Location = new System.Drawing.Point(707, 35);
            this.btnGanhodoOpen.Name = "btnGanhodoOpen";
            this.btnGanhodoOpen.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnGanhodoOpen.Size = new System.Drawing.Size(53, 28);
            this.btnGanhodoOpen.TabIndex = 999;
            this.btnGanhodoOpen.Text = "設定";
            this.btnGanhodoOpen.Visible = false;
            this.btnGanhodoOpen.Click += new System.EventHandler(this.btnGanhodoOpen_Click);
            // 
            // dbxNurse
            // 
            this.dbxNurse.EdgeRounding = false;
            this.dbxNurse.Location = new System.Drawing.Point(530, 39);
            this.dbxNurse.Name = "dbxNurse";
            this.dbxNurse.Size = new System.Drawing.Size(112, 20);
            this.dbxNurse.TabIndex = 999;
            this.dbxNurse.Visible = false;
            // 
            // btnTeamOpen
            // 
            this.btnTeamOpen.ImageIndex = 7;
            this.btnTeamOpen.ImageList = this.ImageList;
            this.btnTeamOpen.Location = new System.Drawing.Point(648, 4);
            this.btnTeamOpen.Name = "btnTeamOpen";
            this.btnTeamOpen.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnTeamOpen.Size = new System.Drawing.Size(53, 28);
            this.btnTeamOpen.TabIndex = 1;
            this.btnTeamOpen.Text = "設定";
            this.btnTeamOpen.Visible = false;
            this.btnTeamOpen.Click += new System.EventHandler(this.btnTeamOpen_Click);
            // 
            // dbxTeam
            // 
            this.dbxTeam.EdgeRounding = false;
            this.dbxTeam.Location = new System.Drawing.Point(530, 8);
            this.dbxTeam.Name = "dbxTeam";
            this.dbxTeam.Size = new System.Drawing.Size(112, 20);
            this.dbxTeam.TabIndex = 999;
            this.dbxTeam.Visible = false;
            // 
            // lblTeam
            // 
            this.lblTeam.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblTeam.EdgeRounding = false;
            this.lblTeam.Location = new System.Drawing.Point(410, 6);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(112, 24);
            this.lblTeam.TabIndex = 999;
            this.lblTeam.Text = "チーム";
            this.lblTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTeam.Visible = false;
            // 
            // lblNurse
            // 
            this.lblNurse.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNurse.EdgeRounding = false;
            this.lblNurse.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNurse.Location = new System.Drawing.Point(410, 37);
            this.lblNurse.Name = "lblNurse";
            this.lblNurse.Size = new System.Drawing.Size(112, 24);
            this.lblNurse.TabIndex = 999;
            this.lblNurse.Text = "担当看護師";
            this.lblNurse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNurse.Visible = false;
            // 
            // xLabel3
            // 
            this.xLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel3.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel3.Image = ((System.Drawing.Image)(resources.GetObject("xLabel3.Image")));
            this.xLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel3.Location = new System.Drawing.Point(14, 6);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(128, 24);
            this.xLabel3.TabIndex = 999;
            this.xLabel3.Text = "入院事項";
            // 
            // lblHo_code
            // 
            this.lblHo_code.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_code.EdgeRounding = false;
            this.lblHo_code.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.lblHo_code.Location = new System.Drawing.Point(14, 153);
            this.lblHo_code.Name = "lblHo_code";
            this.lblHo_code.Size = new System.Drawing.Size(72, 24);
            this.lblHo_code.TabIndex = 999;
            this.lblHo_code.Text = "病　　室";
            this.lblHo_code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxHo_Dong
            // 
            this.dbxHo_Dong.EdgeRounding = false;
            this.dbxHo_Dong.Location = new System.Drawing.Point(94, 129);
            this.dbxHo_Dong.Name = "dbxHo_Dong";
            this.dbxHo_Dong.Size = new System.Drawing.Size(98, 20);
            this.dbxHo_Dong.TabIndex = 3;
            this.dbxHo_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            this.lblHo_dong.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.lblHo_dong.Location = new System.Drawing.Point(14, 125);
            this.lblHo_dong.Name = "lblHo_dong";
            this.lblHo_dong.Size = new System.Drawing.Size(72, 24);
            this.lblHo_dong.TabIndex = 999;
            this.lblHo_dong.Text = "病　　棟";
            this.lblHo_dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxDoctor
            // 
            this.dbxDoctor.EdgeRounding = false;
            this.dbxDoctor.Location = new System.Drawing.Point(287, 98);
            this.dbxDoctor.Name = "dbxDoctor";
            this.dbxDoctor.Size = new System.Drawing.Size(113, 20);
            this.dbxDoctor.TabIndex = 2;
            // 
            // xLabel79
            // 
            this.xLabel79.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel79.EdgeRounding = false;
            this.xLabel79.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel79.Location = new System.Drawing.Point(198, 125);
            this.xLabel79.Name = "xLabel79";
            this.xLabel79.Size = new System.Drawing.Size(81, 24);
            this.xLabel79.TabIndex = 999;
            this.xLabel79.Text = "診断区分名";
            this.xLabel79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxGwa
            // 
            this.dbxGwa.EdgeRounding = false;
            this.dbxGwa.Location = new System.Drawing.Point(94, 98);
            this.dbxGwa.Name = "dbxGwa";
            this.dbxGwa.Size = new System.Drawing.Size(98, 20);
            this.dbxGwa.TabIndex = 1;
            this.dbxGwa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGwa
            // 
            this.lblGwa.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblGwa.EdgeRounding = false;
            this.lblGwa.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.lblGwa.Location = new System.Drawing.Point(14, 95);
            this.lblGwa.Name = "lblGwa";
            this.lblGwa.Size = new System.Drawing.Size(72, 24);
            this.lblGwa.TabIndex = 999;
            this.lblGwa.Text = "診療科";
            this.lblGwa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOrder
            // 
            this.btnOrder.ImageIndex = 4;
            this.btnOrder.ImageList = this.ImageList;
            this.btnOrder.Location = new System.Drawing.Point(319, 63);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnOrder.Size = new System.Drawing.Size(81, 28);
            this.btnOrder.TabIndex = 0;
            this.btnOrder.Text = "詳細照会";
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblDoctor
            // 
            this.lblDoctor.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDoctor.EdgeRounding = false;
            this.lblDoctor.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.lblDoctor.Location = new System.Drawing.Point(197, 95);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(82, 24);
            this.lblDoctor.TabIndex = 999;
            this.lblDoctor.Text = "主　治　医";
            this.lblDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSang_name
            // 
            this.lblSang_name.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSang_name.EdgeRounding = false;
            this.lblSang_name.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.lblSang_name.Location = new System.Drawing.Point(14, 65);
            this.lblSang_name.Name = "lblSang_name";
            this.lblSang_name.Size = new System.Drawing.Size(72, 24);
            this.lblSang_name.TabIndex = 999;
            this.lblSang_name.Text = "診断名";
            this.lblSang_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpIndate
            // 
            this.dtpIndate.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.dtpIndate.IsJapanYearType = true;
            this.dtpIndate.Location = new System.Drawing.Point(94, 37);
            this.dtpIndate.Name = "dtpIndate";
            this.dtpIndate.ReadOnly = true;
            this.dtpIndate.Size = new System.Drawing.Size(110, 20);
            this.dtpIndate.TabIndex = 999;
            this.dtpIndate.TabStop = false;
            this.dtpIndate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mbxDiagnosisName
            // 
            this.mbxDiagnosisName.DisplayMemoText = true;
            this.mbxDiagnosisName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.mbxDiagnosisName.Location = new System.Drawing.Point(94, 66);
            this.mbxDiagnosisName.Name = "mbxDiagnosisName";
            this.mbxDiagnosisName.Size = new System.Drawing.Size(220, 22);
            this.mbxDiagnosisName.TabIndex = 8;
            // 
            // lblInDate
            // 
            this.lblInDate.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblInDate.EdgeRounding = false;
            this.lblInDate.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.lblInDate.Location = new System.Drawing.Point(14, 34);
            this.lblInDate.Name = "lblInDate";
            this.lblInDate.Size = new System.Drawing.Size(72, 24);
            this.lblInDate.TabIndex = 999;
            this.lblInDate.Text = "入院日付";
            this.lblInDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBed
            // 
            this.dbxBed.EdgeRounding = false;
            this.dbxBed.Location = new System.Drawing.Point(287, 156);
            this.dbxBed.Name = "dbxBed";
            this.dbxBed.Size = new System.Drawing.Size(113, 20);
            this.dbxBed.TabIndex = 6;
            this.dbxBed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBed
            // 
            this.lblBed.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBed.EdgeRounding = false;
            this.lblBed.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.lblBed.Location = new System.Drawing.Point(198, 153);
            this.lblBed.Name = "lblBed";
            this.lblBed.Size = new System.Drawing.Size(81, 24);
            this.lblBed.TabIndex = 999;
            this.lblBed.Text = "病　　床";
            this.lblBed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxHo_Code
            // 
            this.dbxHo_Code.EdgeRounding = false;
            this.dbxHo_Code.Location = new System.Drawing.Point(94, 156);
            this.dbxHo_Code.Name = "dbxHo_Code";
            this.dbxHo_Code.Size = new System.Drawing.Size(98, 20);
            this.dbxHo_Code.TabIndex = 5;
            this.dbxHo_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPatientInfoLeft
            // 
            this.pnlPatientInfoLeft.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlPatientInfoLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPatientInfoLeft.Controls.Add(this.groupBox1);
            this.pnlPatientInfoLeft.Controls.Add(this.cboKeyOfficePri2);
            this.pnlPatientInfoLeft.Controls.Add(this.cboKeyCellPri2);
            this.pnlPatientInfoLeft.Controls.Add(this.cboKeyHomePri2);
            this.pnlPatientInfoLeft.Controls.Add(this.cboKeyOfficePri1);
            this.pnlPatientInfoLeft.Controls.Add(this.cboKeyCellPri1);
            this.pnlPatientInfoLeft.Controls.Add(this.cboKeyHomePri1);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyOffice2);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel15);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyCell2);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel16);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyOffice1);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel14);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyCell1);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel13);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyHome2);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel9);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyRelation2);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel10);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel11);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyName2);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel12);
            this.pnlPatientInfoLeft.Controls.Add(this.cboBloodTypeRh);
            this.pnlPatientInfoLeft.Controls.Add(this.cboBloodTypeABO);
            this.pnlPatientInfoLeft.Controls.Add(this.cboPurpose);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyHome1);
            this.pnlPatientInfoLeft.Controls.Add(this.groupBox16);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel143);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyRelation1);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel142);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel141);
            this.pnlPatientInfoLeft.Controls.Add(this.txtKeyName1);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel52);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel53);
            this.pnlPatientInfoLeft.Controls.Add(this.txtInformant);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel140);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel138);
            this.pnlPatientInfoLeft.Controls.Add(this.dbxHoken);
            this.pnlPatientInfoLeft.Controls.Add(this.lblBlood);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel78);
            this.pnlPatientInfoLeft.Controls.Add(this.dbxTel);
            this.pnlPatientInfoLeft.Controls.Add(this.xLabel4);
            this.pnlPatientInfoLeft.Controls.Add(this.lblAddress1);
            this.pnlPatientInfoLeft.Controls.Add(this.dbxAddress);
            this.pnlPatientInfoLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPatientInfoLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlPatientInfoLeft.Name = "pnlPatientInfoLeft";
            this.pnlPatientInfoLeft.Size = new System.Drawing.Size(402, 538);
            this.pnlPatientInfoLeft.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKeyComment);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(5, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 62);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "連絡先に関するコメント";
            // 
            // txtKeyComment
            // 
            this.txtKeyComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyComment.EnterKeyToTab = false;
            this.txtKeyComment.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyComment.Location = new System.Drawing.Point(3, 16);
            this.txtKeyComment.MaxLength = 4000;
            this.txtKeyComment.Name = "txtKeyComment";
            this.txtKeyComment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtKeyComment.Size = new System.Drawing.Size(383, 43);
            this.txtKeyComment.TabIndex = 0;
            this.txtKeyComment.Text = "";
            // 
            // cboKeyOfficePri2
            // 
            this.cboKeyOfficePri2.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem32,
            this.xComboItem33,
            this.xComboItem34,
            this.xComboItem35,
            this.xComboItem36,
            this.xComboItem37,
            this.xComboItem38});
            this.cboKeyOfficePri2.Location = new System.Drawing.Point(24, 358);
            this.cboKeyOfficePri2.Name = "cboKeyOfficePri2";
            this.cboKeyOfficePri2.Size = new System.Drawing.Size(57, 21);
            this.cboKeyOfficePri2.TabIndex = 19;
            // 
            // xComboItem32
            // 
            this.xComboItem32.DisplayItem = "未設定";
            this.xComboItem32.ValueItem = "0";
            // 
            // xComboItem33
            // 
            this.xComboItem33.DisplayItem = "1";
            this.xComboItem33.ValueItem = "1";
            // 
            // xComboItem34
            // 
            this.xComboItem34.DisplayItem = "2";
            this.xComboItem34.ValueItem = "2";
            // 
            // xComboItem35
            // 
            this.xComboItem35.DisplayItem = "3";
            this.xComboItem35.ValueItem = "3";
            // 
            // xComboItem36
            // 
            this.xComboItem36.DisplayItem = "4";
            this.xComboItem36.ValueItem = "4";
            // 
            // xComboItem37
            // 
            this.xComboItem37.DisplayItem = "5";
            this.xComboItem37.ValueItem = "5";
            // 
            // xComboItem38
            // 
            this.xComboItem38.DisplayItem = "6";
            this.xComboItem38.ValueItem = "6";
            // 
            // cboKeyCellPri2
            // 
            this.cboKeyCellPri2.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem39,
            this.xComboItem40,
            this.xComboItem41,
            this.xComboItem42,
            this.xComboItem43,
            this.xComboItem44,
            this.xComboItem45});
            this.cboKeyCellPri2.Location = new System.Drawing.Point(24, 330);
            this.cboKeyCellPri2.Name = "cboKeyCellPri2";
            this.cboKeyCellPri2.Size = new System.Drawing.Size(57, 21);
            this.cboKeyCellPri2.TabIndex = 18;
            // 
            // xComboItem39
            // 
            this.xComboItem39.DisplayItem = "未設定";
            this.xComboItem39.ValueItem = "0";
            // 
            // xComboItem40
            // 
            this.xComboItem40.DisplayItem = "1";
            this.xComboItem40.ValueItem = "1";
            // 
            // xComboItem41
            // 
            this.xComboItem41.DisplayItem = "2";
            this.xComboItem41.ValueItem = "2";
            // 
            // xComboItem42
            // 
            this.xComboItem42.DisplayItem = "3";
            this.xComboItem42.ValueItem = "3";
            // 
            // xComboItem43
            // 
            this.xComboItem43.DisplayItem = "4";
            this.xComboItem43.ValueItem = "4";
            // 
            // xComboItem44
            // 
            this.xComboItem44.DisplayItem = "5";
            this.xComboItem44.ValueItem = "5";
            // 
            // xComboItem45
            // 
            this.xComboItem45.DisplayItem = "6";
            this.xComboItem45.ValueItem = "6";
            // 
            // cboKeyHomePri2
            // 
            this.cboKeyHomePri2.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem46,
            this.xComboItem47,
            this.xComboItem48,
            this.xComboItem49,
            this.xComboItem50,
            this.xComboItem51,
            this.xComboItem52});
            this.cboKeyHomePri2.Location = new System.Drawing.Point(24, 302);
            this.cboKeyHomePri2.Name = "cboKeyHomePri2";
            this.cboKeyHomePri2.Size = new System.Drawing.Size(57, 21);
            this.cboKeyHomePri2.TabIndex = 17;
            // 
            // xComboItem46
            // 
            this.xComboItem46.DisplayItem = "未設定";
            this.xComboItem46.ValueItem = "0";
            // 
            // xComboItem47
            // 
            this.xComboItem47.DisplayItem = "1";
            this.xComboItem47.ValueItem = "1";
            // 
            // xComboItem48
            // 
            this.xComboItem48.DisplayItem = "2";
            this.xComboItem48.ValueItem = "2";
            // 
            // xComboItem49
            // 
            this.xComboItem49.DisplayItem = "3";
            this.xComboItem49.ValueItem = "3";
            // 
            // xComboItem50
            // 
            this.xComboItem50.DisplayItem = "4";
            this.xComboItem50.ValueItem = "4";
            // 
            // xComboItem51
            // 
            this.xComboItem51.DisplayItem = "5";
            this.xComboItem51.ValueItem = "5";
            // 
            // xComboItem52
            // 
            this.xComboItem52.DisplayItem = "6";
            this.xComboItem52.ValueItem = "6";
            // 
            // cboKeyOfficePri1
            // 
            this.cboKeyOfficePri1.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem25,
            this.xComboItem26,
            this.xComboItem27,
            this.xComboItem28,
            this.xComboItem29,
            this.xComboItem30,
            this.xComboItem31});
            this.cboKeyOfficePri1.Location = new System.Drawing.Point(24, 241);
            this.cboKeyOfficePri1.Name = "cboKeyOfficePri1";
            this.cboKeyOfficePri1.Size = new System.Drawing.Size(57, 21);
            this.cboKeyOfficePri1.TabIndex = 16;
            // 
            // xComboItem25
            // 
            this.xComboItem25.DisplayItem = "未設定";
            this.xComboItem25.ValueItem = "0";
            // 
            // xComboItem26
            // 
            this.xComboItem26.DisplayItem = "1";
            this.xComboItem26.ValueItem = "1";
            // 
            // xComboItem27
            // 
            this.xComboItem27.DisplayItem = "2";
            this.xComboItem27.ValueItem = "2";
            // 
            // xComboItem28
            // 
            this.xComboItem28.DisplayItem = "3";
            this.xComboItem28.ValueItem = "3";
            // 
            // xComboItem29
            // 
            this.xComboItem29.DisplayItem = "4";
            this.xComboItem29.ValueItem = "4";
            // 
            // xComboItem30
            // 
            this.xComboItem30.DisplayItem = "5";
            this.xComboItem30.ValueItem = "5";
            // 
            // xComboItem31
            // 
            this.xComboItem31.DisplayItem = "6";
            this.xComboItem31.ValueItem = "6";
            // 
            // cboKeyCellPri1
            // 
            this.cboKeyCellPri1.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem18,
            this.xComboItem19,
            this.xComboItem20,
            this.xComboItem21,
            this.xComboItem22,
            this.xComboItem23,
            this.xComboItem24});
            this.cboKeyCellPri1.Location = new System.Drawing.Point(24, 213);
            this.cboKeyCellPri1.Name = "cboKeyCellPri1";
            this.cboKeyCellPri1.Size = new System.Drawing.Size(57, 21);
            this.cboKeyCellPri1.TabIndex = 15;
            // 
            // xComboItem18
            // 
            this.xComboItem18.DisplayItem = "未設定";
            this.xComboItem18.ValueItem = "0";
            // 
            // xComboItem19
            // 
            this.xComboItem19.DisplayItem = "1";
            this.xComboItem19.ValueItem = "1";
            // 
            // xComboItem20
            // 
            this.xComboItem20.DisplayItem = "2";
            this.xComboItem20.ValueItem = "2";
            // 
            // xComboItem21
            // 
            this.xComboItem21.DisplayItem = "3";
            this.xComboItem21.ValueItem = "3";
            // 
            // xComboItem22
            // 
            this.xComboItem22.DisplayItem = "4";
            this.xComboItem22.ValueItem = "4";
            // 
            // xComboItem23
            // 
            this.xComboItem23.DisplayItem = "5";
            this.xComboItem23.ValueItem = "5";
            // 
            // xComboItem24
            // 
            this.xComboItem24.DisplayItem = "6";
            this.xComboItem24.ValueItem = "6";
            // 
            // cboKeyHomePri1
            // 
            this.cboKeyHomePri1.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem11,
            this.xComboItem12,
            this.xComboItem13,
            this.xComboItem14,
            this.xComboItem15,
            this.xComboItem16,
            this.xComboItem17});
            this.cboKeyHomePri1.Location = new System.Drawing.Point(24, 185);
            this.cboKeyHomePri1.Name = "cboKeyHomePri1";
            this.cboKeyHomePri1.Size = new System.Drawing.Size(57, 21);
            this.cboKeyHomePri1.TabIndex = 14;
            // 
            // xComboItem11
            // 
            this.xComboItem11.DisplayItem = "未設定";
            this.xComboItem11.ValueItem = "0";
            // 
            // xComboItem12
            // 
            this.xComboItem12.DisplayItem = "1";
            this.xComboItem12.ValueItem = "1";
            // 
            // xComboItem13
            // 
            this.xComboItem13.DisplayItem = "2";
            this.xComboItem13.ValueItem = "2";
            // 
            // xComboItem14
            // 
            this.xComboItem14.DisplayItem = "3";
            this.xComboItem14.ValueItem = "3";
            // 
            // xComboItem15
            // 
            this.xComboItem15.DisplayItem = "4";
            this.xComboItem15.ValueItem = "4";
            // 
            // xComboItem16
            // 
            this.xComboItem16.DisplayItem = "5";
            this.xComboItem16.ValueItem = "5";
            // 
            // xComboItem17
            // 
            this.xComboItem17.DisplayItem = "6";
            this.xComboItem17.ValueItem = "6";
            // 
            // txtKeyOffice2
            // 
            this.txtKeyOffice2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyOffice2.Location = new System.Drawing.Point(148, 359);
            this.txtKeyOffice2.MaxLength = 1000;
            this.txtKeyOffice2.Name = "txtKeyOffice2";
            this.txtKeyOffice2.Size = new System.Drawing.Size(244, 20);
            this.txtKeyOffice2.TabIndex = 13;
            // 
            // xLabel15
            // 
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel15.Location = new System.Drawing.Point(86, 357);
            this.xLabel15.Name = "xLabel15";
            this.xLabel15.Size = new System.Drawing.Size(56, 24);
            this.xLabel15.TabIndex = 1014;
            this.xLabel15.Text = "勤務先";
            this.xLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyCell2
            // 
            this.txtKeyCell2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyCell2.Location = new System.Drawing.Point(148, 331);
            this.txtKeyCell2.MaxLength = 1000;
            this.txtKeyCell2.Name = "txtKeyCell2";
            this.txtKeyCell2.Size = new System.Drawing.Size(244, 20);
            this.txtKeyCell2.TabIndex = 12;
            // 
            // xLabel16
            // 
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel16.Location = new System.Drawing.Point(87, 329);
            this.xLabel16.Name = "xLabel16";
            this.xLabel16.Size = new System.Drawing.Size(56, 24);
            this.xLabel16.TabIndex = 1012;
            this.xLabel16.Text = "携帯";
            this.xLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyOffice1
            // 
            this.txtKeyOffice1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyOffice1.Location = new System.Drawing.Point(150, 242);
            this.txtKeyOffice1.MaxLength = 1000;
            this.txtKeyOffice1.Name = "txtKeyOffice1";
            this.txtKeyOffice1.Size = new System.Drawing.Size(244, 20);
            this.txtKeyOffice1.TabIndex = 8;
            // 
            // xLabel14
            // 
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel14.Location = new System.Drawing.Point(88, 240);
            this.xLabel14.Name = "xLabel14";
            this.xLabel14.Size = new System.Drawing.Size(56, 24);
            this.xLabel14.TabIndex = 1010;
            this.xLabel14.Text = "勤務先";
            this.xLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyCell1
            // 
            this.txtKeyCell1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyCell1.Location = new System.Drawing.Point(150, 214);
            this.txtKeyCell1.MaxLength = 1000;
            this.txtKeyCell1.Name = "txtKeyCell1";
            this.txtKeyCell1.Size = new System.Drawing.Size(244, 20);
            this.txtKeyCell1.TabIndex = 7;
            // 
            // xLabel13
            // 
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel13.Location = new System.Drawing.Point(89, 212);
            this.xLabel13.Name = "xLabel13";
            this.xLabel13.Size = new System.Drawing.Size(56, 24);
            this.xLabel13.TabIndex = 1008;
            this.xLabel13.Text = "携帯";
            this.xLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyHome2
            // 
            this.txtKeyHome2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyHome2.Location = new System.Drawing.Point(149, 303);
            this.txtKeyHome2.MaxLength = 1000;
            this.txtKeyHome2.Name = "txtKeyHome2";
            this.txtKeyHome2.Size = new System.Drawing.Size(244, 20);
            this.txtKeyHome2.TabIndex = 11;
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel9.Location = new System.Drawing.Point(87, 301);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(56, 24);
            this.xLabel9.TabIndex = 1005;
            this.xLabel9.Text = "自宅";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyRelation2
            // 
            this.txtKeyRelation2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyRelation2.Location = new System.Drawing.Point(305, 275);
            this.txtKeyRelation2.MaxLength = 1000;
            this.txtKeyRelation2.Name = "txtKeyRelation2";
            this.txtKeyRelation2.Size = new System.Drawing.Size(88, 20);
            this.txtKeyRelation2.TabIndex = 10;
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel10.Location = new System.Drawing.Point(229, 273);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(70, 24);
            this.xLabel10.TabIndex = 1006;
            this.xLabel10.Text = "関　係";
            this.xLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel11.Location = new System.Drawing.Point(7, 273);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(71, 24);
            this.xLabel11.TabIndex = 1004;
            this.xLabel11.Text = "Key Person";
            this.xLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyName2
            // 
            this.txtKeyName2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyName2.Location = new System.Drawing.Point(149, 275);
            this.txtKeyName2.MaxLength = 1000;
            this.txtKeyName2.Name = "txtKeyName2";
            this.txtKeyName2.Size = new System.Drawing.Size(75, 20);
            this.txtKeyName2.TabIndex = 9;
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel12.Location = new System.Drawing.Point(87, 273);
            this.xLabel12.Name = "xLabel12";
            this.xLabel12.Size = new System.Drawing.Size(56, 24);
            this.xLabel12.TabIndex = 1003;
            this.xLabel12.Text = "名　前";
            this.xLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBloodTypeRh
            // 
            this.cboBloodTypeRh.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem9,
            this.xComboItem10});
            this.cboBloodTypeRh.Location = new System.Drawing.Point(345, 95);
            this.cboBloodTypeRh.Name = "cboBloodTypeRh";
            this.cboBloodTypeRh.Size = new System.Drawing.Size(50, 21);
            this.cboBloodTypeRh.TabIndex = 1;
            // 
            // xComboItem9
            // 
            this.xComboItem9.DisplayItem = "Rh+";
            this.xComboItem9.ValueItem = "Rh+";
            // 
            // xComboItem10
            // 
            this.xComboItem10.DisplayItem = "Rh-";
            this.xComboItem10.ValueItem = "Rh-";
            // 
            // cboBloodTypeABO
            // 
            this.cboBloodTypeABO.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7,
            this.xComboItem8});
            this.cboBloodTypeABO.Location = new System.Drawing.Point(307, 95);
            this.cboBloodTypeABO.Name = "cboBloodTypeABO";
            this.cboBloodTypeABO.Size = new System.Drawing.Size(39, 21);
            this.cboBloodTypeABO.TabIndex = 0;
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "A";
            this.xComboItem5.ValueItem = "A";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "AB";
            this.xComboItem6.ValueItem = "AB";
            // 
            // xComboItem7
            // 
            this.xComboItem7.DisplayItem = "B";
            this.xComboItem7.ValueItem = "B";
            // 
            // xComboItem8
            // 
            this.xComboItem8.DisplayItem = "O";
            this.xComboItem8.ValueItem = "O";
            // 
            // cboPurpose
            // 
            this.cboPurpose.Location = new System.Drawing.Point(90, 127);
            this.cboPurpose.Name = "cboPurpose";
            this.cboPurpose.Size = new System.Drawing.Size(109, 21);
            this.cboPurpose.TabIndex = 2;
            // 
            // txtKeyHome1
            // 
            this.txtKeyHome1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyHome1.Location = new System.Drawing.Point(151, 186);
            this.txtKeyHome1.MaxLength = 1000;
            this.txtKeyHome1.Name = "txtKeyHome1";
            this.txtKeyHome1.Size = new System.Drawing.Size(244, 20);
            this.txtKeyHome1.TabIndex = 6;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.txtInpatientCourse);
            this.groupBox16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox16.Location = new System.Drawing.Point(3, 453);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(389, 80);
            this.groupBox16.TabIndex = 21;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "入院までの経過";
            // 
            // txtInpatientCourse
            // 
            this.txtInpatientCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInpatientCourse.EnterKeyToTab = false;
            this.txtInpatientCourse.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtInpatientCourse.Location = new System.Drawing.Point(3, 16);
            this.txtInpatientCourse.MaxLength = 4000;
            this.txtInpatientCourse.Name = "txtInpatientCourse";
            this.txtInpatientCourse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtInpatientCourse.Size = new System.Drawing.Size(383, 61);
            this.txtInpatientCourse.TabIndex = 0;
            this.txtInpatientCourse.Text = "";
            // 
            // xLabel143
            // 
            this.xLabel143.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel143.EdgeRounding = false;
            this.xLabel143.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel143.Location = new System.Drawing.Point(89, 184);
            this.xLabel143.Name = "xLabel143";
            this.xLabel143.Size = new System.Drawing.Size(56, 24);
            this.xLabel143.TabIndex = 999;
            this.xLabel143.Text = "自宅";
            this.xLabel143.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyRelation1
            // 
            this.txtKeyRelation1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyRelation1.Location = new System.Drawing.Point(307, 158);
            this.txtKeyRelation1.MaxLength = 1000;
            this.txtKeyRelation1.Name = "txtKeyRelation1";
            this.txtKeyRelation1.Size = new System.Drawing.Size(88, 20);
            this.txtKeyRelation1.TabIndex = 5;
            // 
            // xLabel142
            // 
            this.xLabel142.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel142.EdgeRounding = false;
            this.xLabel142.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel142.Location = new System.Drawing.Point(231, 156);
            this.xLabel142.Name = "xLabel142";
            this.xLabel142.Size = new System.Drawing.Size(70, 24);
            this.xLabel142.TabIndex = 999;
            this.xLabel142.Text = "関　係";
            this.xLabel142.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel141
            // 
            this.xLabel141.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel141.EdgeRounding = false;
            this.xLabel141.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel141.Location = new System.Drawing.Point(9, 156);
            this.xLabel141.Name = "xLabel141";
            this.xLabel141.Size = new System.Drawing.Size(71, 24);
            this.xLabel141.TabIndex = 999;
            this.xLabel141.Text = "Key Person";
            this.xLabel141.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKeyName1
            // 
            this.txtKeyName1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKeyName1.Location = new System.Drawing.Point(151, 158);
            this.txtKeyName1.MaxLength = 1000;
            this.txtKeyName1.Name = "txtKeyName1";
            this.txtKeyName1.Size = new System.Drawing.Size(75, 20);
            this.txtKeyName1.TabIndex = 4;
            // 
            // xLabel52
            // 
            this.xLabel52.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel52.EdgeRounding = false;
            this.xLabel52.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel52.Location = new System.Drawing.Point(89, 156);
            this.xLabel52.Name = "xLabel52";
            this.xLabel52.Size = new System.Drawing.Size(56, 24);
            this.xLabel52.TabIndex = 999;
            this.xLabel52.Text = "名　前";
            this.xLabel52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel53
            // 
            this.xLabel53.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel53.EdgeRounding = false;
            this.xLabel53.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel53.Location = new System.Drawing.Point(9, 125);
            this.xLabel53.Name = "xLabel53";
            this.xLabel53.Size = new System.Drawing.Size(71, 24);
            this.xLabel53.TabIndex = 999;
            this.xLabel53.Text = "入院目的";
            this.xLabel53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInformant
            // 
            this.txtInformant.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtInformant.Location = new System.Drawing.Point(307, 127);
            this.txtInformant.MaxLength = 1000;
            this.txtInformant.Name = "txtInformant";
            this.txtInformant.Size = new System.Drawing.Size(88, 20);
            this.txtInformant.TabIndex = 3;
            // 
            // xLabel140
            // 
            this.xLabel140.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel140.EdgeRounding = false;
            this.xLabel140.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel140.Location = new System.Drawing.Point(208, 125);
            this.xLabel140.Name = "xLabel140";
            this.xLabel140.Size = new System.Drawing.Size(93, 24);
            this.xLabel140.TabIndex = 999;
            this.xLabel140.Text = "情報提供者";
            this.xLabel140.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel138
            // 
            this.xLabel138.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel138.EdgeRounding = false;
            this.xLabel138.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel138.Location = new System.Drawing.Point(9, 95);
            this.xLabel138.Name = "xLabel138";
            this.xLabel138.Size = new System.Drawing.Size(72, 24);
            this.xLabel138.TabIndex = 999;
            this.xLabel138.Text = "保険情報";
            this.xLabel138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxHoken
            // 
            this.dbxHoken.EdgeRounding = false;
            this.dbxHoken.Location = new System.Drawing.Point(89, 97);
            this.dbxHoken.Name = "dbxHoken";
            this.dbxHoken.Size = new System.Drawing.Size(110, 20);
            this.dbxHoken.TabIndex = 999;
            // 
            // xLabel78
            // 
            this.xLabel78.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel78.EdgeRounding = false;
            this.xLabel78.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel78.Location = new System.Drawing.Point(9, 65);
            this.xLabel78.Name = "xLabel78";
            this.xLabel78.Size = new System.Drawing.Size(72, 24);
            this.xLabel78.TabIndex = 999;
            this.xLabel78.Text = "TEL";
            this.xLabel78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxTel
            // 
            this.dbxTel.EdgeRounding = false;
            this.dbxTel.Location = new System.Drawing.Point(89, 67);
            this.dbxTel.Name = "dbxTel";
            this.dbxTel.Size = new System.Drawing.Size(306, 20);
            this.dbxTel.TabIndex = 999;
            // 
            // xLabel4
            // 
            this.xLabel4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel4.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel4.Image = ((System.Drawing.Image)(resources.GetObject("xLabel4.Image")));
            this.xLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel4.Location = new System.Drawing.Point(9, 6);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(128, 24);
            this.xLabel4.TabIndex = 999;
            this.xLabel4.Text = "人的事項";
            // 
            // lblAddress1
            // 
            this.lblAddress1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblAddress1.EdgeRounding = false;
            this.lblAddress1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.lblAddress1.Location = new System.Drawing.Point(9, 34);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(72, 24);
            this.lblAddress1.TabIndex = 999;
            this.lblAddress1.Text = "現住所";
            this.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxAddress
            // 
            this.dbxAddress.EdgeRounding = false;
            this.dbxAddress.Location = new System.Drawing.Point(89, 36);
            this.dbxAddress.Name = "dbxAddress";
            this.dbxAddress.Size = new System.Drawing.Size(306, 20);
            this.dbxAddress.TabIndex = 999;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlHealthRight);
            this.tabPage2.Controls.Add(this.pnlHealthLeft);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(841, 538);
            this.tabPage2.TabIndex = 999;
            this.tabPage2.Title = "Ⅰ.健康管理";
            // 
            // pnlHealthRight
            // 
            this.pnlHealthRight.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlHealthRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHealthRight.Controls.Add(this.groupBox9);
            this.pnlHealthRight.Controls.Add(this.xPanel7);
            this.pnlHealthRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHealthRight.DrawBorder = true;
            this.pnlHealthRight.Location = new System.Drawing.Point(402, 0);
            this.pnlHealthRight.Name = "pnlHealthRight";
            this.pnlHealthRight.Size = new System.Drawing.Size(439, 538);
            this.pnlHealthRight.TabIndex = 3;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtAssessment1);
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox9.Location = new System.Drawing.Point(6, 343);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(414, 138);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "備考";
            // 
            // txtAssessment1
            // 
            this.txtAssessment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAssessment1.EnterKeyToTab = false;
            this.txtAssessment1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAssessment1.Location = new System.Drawing.Point(3, 16);
            this.txtAssessment1.MaxLength = 4000;
            this.txtAssessment1.Name = "txtAssessment1";
            this.txtAssessment1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtAssessment1.Size = new System.Drawing.Size(408, 119);
            this.txtAssessment1.TabIndex = 0;
            this.txtAssessment1.Text = "";
            // 
            // xPanel7
            // 
            this.xPanel7.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xPanel7.Controls.Add(this.btnAllergy);
            this.xPanel7.Controls.Add(this.btnInfe);
            this.xPanel7.Controls.Add(this.xLabel8);
            this.xPanel7.Controls.Add(this.xLabel7);
            this.xPanel7.Controls.Add(this.grdNUR1017);
            this.xPanel7.Controls.Add(this.grdNUR1016);
            this.xPanel7.Location = new System.Drawing.Point(6, 8);
            this.xPanel7.Name = "xPanel7";
            this.xPanel7.Size = new System.Drawing.Size(414, 321);
            this.xPanel7.TabIndex = 1;
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Location = new System.Drawing.Point(4, 148);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(72, 24);
            this.xLabel8.TabIndex = 999;
            this.xLabel8.Text = "アレルギー";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Location = new System.Drawing.Point(4, 0);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(72, 24);
            this.xLabel7.TabIndex = 999;
            this.xLabel7.Text = "感　染　症";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdNUR1017
            // 
            this.grdNUR1017.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29});
            this.grdNUR1017.ColPerLine = 3;
            this.grdNUR1017.Cols = 4;
            this.grdNUR1017.FixedCols = 1;
            this.grdNUR1017.FixedRows = 1;
            this.grdNUR1017.HeaderHeights.Add(21);
            this.grdNUR1017.Location = new System.Drawing.Point(4, 24);
            this.grdNUR1017.Name = "grdNUR1017";
            this.grdNUR1017.QuerySQL = resources.GetString("grdNUR1017.QuerySQL");
            this.grdNUR1017.RowHeaderVisible = true;
            this.grdNUR1017.Rows = 2;
            this.grdNUR1017.Size = new System.Drawing.Size(406, 121);
            this.grdNUR1017.TabIndex = 999;
            this.grdNUR1017.TabStop = false;
            this.grdNUR1017.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1017_QueryStarting);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "start_date";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell27.Col = 1;
            this.xEditGridCell27.HeaderText = "開始日";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdatable = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "infe_jaeryo";
            this.xEditGridCell28.CellWidth = 47;
            this.xEditGridCell28.Col = 2;
            this.xEditGridCell28.HeaderText = "材料";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "infe_code";
            this.xEditGridCell29.CellWidth = 227;
            this.xEditGridCell29.Col = 3;
            this.xEditGridCell29.HeaderText = "感染症";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            // 
            // grdNUR1016
            // 
            this.grdNUR1016.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell26,
            this.xEditGridCell25,
            this.xEditGridCell24});
            this.grdNUR1016.ColPerLine = 3;
            this.grdNUR1016.Cols = 4;
            this.grdNUR1016.FixedCols = 1;
            this.grdNUR1016.FixedRows = 1;
            this.grdNUR1016.HeaderHeights.Add(21);
            this.grdNUR1016.Location = new System.Drawing.Point(4, 172);
            this.grdNUR1016.Name = "grdNUR1016";
            this.grdNUR1016.QuerySQL = resources.GetString("grdNUR1016.QuerySQL");
            this.grdNUR1016.RowHeaderVisible = true;
            this.grdNUR1016.Rows = 2;
            this.grdNUR1016.Size = new System.Drawing.Size(405, 145);
            this.grdNUR1016.TabIndex = 999;
            this.grdNUR1016.TabStop = false;
            this.grdNUR1016.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1016_QueryStarting);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "start_date";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell26.Col = 1;
            this.xEditGridCell26.HeaderText = "開始日";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "allergy_gubun";
            this.xEditGridCell25.CellWidth = 47;
            this.xEditGridCell25.Col = 2;
            this.xEditGridCell25.HeaderText = "区分";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "allergy_info";
            this.xEditGridCell24.CellWidth = 227;
            this.xEditGridCell24.Col = 3;
            this.xEditGridCell24.HeaderText = "アレルギー内容";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            // 
            // pnlHealthLeft
            // 
            this.pnlHealthLeft.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlHealthLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHealthLeft.Controls.Add(this.nudSmoking);
            this.pnlHealthLeft.Controls.Add(this.txtDrinking);
            this.pnlHealthLeft.Controls.Add(this.xLabel145);
            this.pnlHealthLeft.Controls.Add(this.xLabel144);
            this.pnlHealthLeft.Controls.Add(this.gbxHealthCare);
            this.pnlHealthLeft.Controls.Add(this.mbxBringDrugComment);
            this.pnlHealthLeft.Controls.Add(this.groupBox8);
            this.pnlHealthLeft.Controls.Add(this.mbxHealthcare);
            this.pnlHealthLeft.Controls.Add(this.mbxPastHis);
            this.pnlHealthLeft.Controls.Add(this.lblHealthCare);
            this.pnlHealthLeft.Controls.Add(this.lblBringDrug);
            this.pnlHealthLeft.Controls.Add(this.lblPast_his);
            this.pnlHealthLeft.Controls.Add(this.gbxBringDrug);
            this.pnlHealthLeft.Controls.Add(this.xLabel146);
            this.pnlHealthLeft.Controls.Add(this.xLabel147);
            this.pnlHealthLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHealthLeft.DrawBorder = true;
            this.pnlHealthLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlHealthLeft.Name = "pnlHealthLeft";
            this.pnlHealthLeft.Size = new System.Drawing.Size(402, 538);
            this.pnlHealthLeft.TabIndex = 2;
            // 
            // nudSmoking
            // 
            this.nudSmoking.Location = new System.Drawing.Point(93, 180);
            this.nudSmoking.Name = "nudSmoking";
            this.nudSmoking.Size = new System.Drawing.Size(56, 20);
            this.nudSmoking.TabIndex = 6;
            // 
            // txtDrinking
            // 
            this.txtDrinking.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDrinking.Location = new System.Drawing.Point(276, 180);
            this.txtDrinking.MaxLength = 1000;
            this.txtDrinking.Name = "txtDrinking";
            this.txtDrinking.Size = new System.Drawing.Size(112, 20);
            this.txtDrinking.TabIndex = 7;
            // 
            // xLabel145
            // 
            this.xLabel145.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel145.EdgeRounding = false;
            this.xLabel145.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel145.Location = new System.Drawing.Point(198, 178);
            this.xLabel145.Name = "xLabel145";
            this.xLabel145.Size = new System.Drawing.Size(72, 24);
            this.xLabel145.TabIndex = 999;
            this.xLabel145.Text = "飲　　　酒";
            this.xLabel145.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel144
            // 
            this.xLabel144.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel144.EdgeRounding = false;
            this.xLabel144.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel144.Location = new System.Drawing.Point(13, 178);
            this.xLabel144.Name = "xLabel144";
            this.xLabel144.Size = new System.Drawing.Size(72, 24);
            this.xLabel144.TabIndex = 999;
            this.xLabel144.Text = "喫　　　煙";
            this.xLabel144.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxHealthCare
            // 
            this.gbxHealthCare.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxHealthCare.Controls.Add(this.rbxHealthcareY);
            this.gbxHealthCare.Controls.Add(this.rbxHealthcareN);
            this.gbxHealthCare.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxHealthCare.Location = new System.Drawing.Point(93, 118);
            this.gbxHealthCare.Name = "gbxHealthCare";
            this.gbxHealthCare.Size = new System.Drawing.Size(101, 39);
            this.gbxHealthCare.TabIndex = 4;
            this.gbxHealthCare.TabStop = false;
            // 
            // rbxHealthcareY
            // 
            this.rbxHealthcareY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxHealthcareY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxHealthcareY.Location = new System.Drawing.Point(8, 13);
            this.rbxHealthcareY.Name = "rbxHealthcareY";
            this.rbxHealthcareY.Size = new System.Drawing.Size(36, 18);
            this.rbxHealthcareY.TabIndex = 0;
            this.rbxHealthcareY.TabStop = true;
            this.rbxHealthcareY.Text = "有";
            this.rbxHealthcareY.UseVisualStyleBackColor = false;
            this.rbxHealthcareY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxHealthcareN
            // 
            this.rbxHealthcareN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxHealthcareN.CheckedValue = "N";
            this.rbxHealthcareN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxHealthcareN.Location = new System.Drawing.Point(60, 13);
            this.rbxHealthcareN.Name = "rbxHealthcareN";
            this.rbxHealthcareN.Size = new System.Drawing.Size(35, 18);
            this.rbxHealthcareN.TabIndex = 1;
            this.rbxHealthcareN.TabStop = true;
            this.rbxHealthcareN.Text = "無";
            this.rbxHealthcareN.UseVisualStyleBackColor = false;
            // 
            // mbxBringDrugComment
            // 
            this.mbxBringDrugComment.DisplayMemoText = true;
            this.mbxBringDrugComment.Enabled = false;
            this.mbxBringDrugComment.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.mbxBringDrugComment.Location = new System.Drawing.Point(197, 78);
            this.mbxBringDrugComment.Name = "mbxBringDrugComment";
            this.mbxBringDrugComment.Size = new System.Drawing.Size(191, 20);
            this.mbxBringDrugComment.TabIndex = 3;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtExplainF);
            this.groupBox8.Controls.Add(this.txtExplainP);
            this.groupBox8.Controls.Add(this.txtExplainD);
            this.groupBox8.Controls.Add(this.xLabel81);
            this.groupBox8.Controls.Add(this.xLabel84);
            this.groupBox8.Controls.Add(this.xLabel85);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(14, 247);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(374, 234);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "現在の病気について医師からの説明とそのたらえかた";
            // 
            // txtExplainF
            // 
            this.txtExplainF.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtExplainF.Location = new System.Drawing.Point(104, 159);
            this.txtExplainF.MaxLength = 1000;
            this.txtExplainF.Multiline = true;
            this.txtExplainF.Name = "txtExplainF";
            this.txtExplainF.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExplainF.Size = new System.Drawing.Size(255, 65);
            this.txtExplainF.TabIndex = 3;
            // 
            // txtExplainP
            // 
            this.txtExplainP.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtExplainP.Location = new System.Drawing.Point(104, 90);
            this.txtExplainP.MaxLength = 1000;
            this.txtExplainP.Multiline = true;
            this.txtExplainP.Name = "txtExplainP";
            this.txtExplainP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExplainP.Size = new System.Drawing.Size(255, 63);
            this.txtExplainP.TabIndex = 2;
            // 
            // txtExplainD
            // 
            this.txtExplainD.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtExplainD.Location = new System.Drawing.Point(104, 22);
            this.txtExplainD.MaxLength = 1000;
            this.txtExplainD.Multiline = true;
            this.txtExplainD.Name = "txtExplainD";
            this.txtExplainD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExplainD.Size = new System.Drawing.Size(255, 62);
            this.txtExplainD.TabIndex = 1;
            // 
            // xLabel81
            // 
            this.xLabel81.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel81.EdgeRounding = false;
            this.xLabel81.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel81.Location = new System.Drawing.Point(16, 22);
            this.xLabel81.Name = "xLabel81";
            this.xLabel81.Size = new System.Drawing.Size(82, 24);
            this.xLabel81.TabIndex = 999;
            this.xLabel81.Text = "医　　　師";
            this.xLabel81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel84
            // 
            this.xLabel84.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel84.EdgeRounding = false;
            this.xLabel84.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel84.Location = new System.Drawing.Point(16, 90);
            this.xLabel84.Name = "xLabel84";
            this.xLabel84.Size = new System.Drawing.Size(82, 24);
            this.xLabel84.TabIndex = 999;
            this.xLabel84.Text = "本　　　人";
            this.xLabel84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel85
            // 
            this.xLabel85.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel85.EdgeRounding = false;
            this.xLabel85.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel85.Location = new System.Drawing.Point(16, 159);
            this.xLabel85.Name = "xLabel85";
            this.xLabel85.Size = new System.Drawing.Size(82, 24);
            this.xLabel85.TabIndex = 999;
            this.xLabel85.Text = "家　　　族";
            this.xLabel85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mbxHealthcare
            // 
            this.mbxHealthcare.DisplayMemoText = true;
            this.mbxHealthcare.Enabled = false;
            this.mbxHealthcare.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.mbxHealthcare.Location = new System.Drawing.Point(197, 124);
            this.mbxHealthcare.Name = "mbxHealthcare";
            this.mbxHealthcare.Size = new System.Drawing.Size(191, 32);
            this.mbxHealthcare.TabIndex = 5;
            // 
            // mbxPastHis
            // 
            this.mbxPastHis.DisplayMemoText = true;
            this.mbxPastHis.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.mbxPastHis.Location = new System.Drawing.Point(91, 29);
            this.mbxPastHis.Name = "mbxPastHis";
            this.mbxPastHis.ReservedMemoClassName = "IHIS.OCS.ReservedComment";
            this.mbxPastHis.ReservedMemoFileName = "C:\\IHIS\\OCSI\\OCS.Lib.CommonForms.dll";
            this.mbxPastHis.ShowReservedMemoButton = true;
            this.mbxPastHis.Size = new System.Drawing.Size(297, 20);
            this.mbxPastHis.TabIndex = 1;
            this.mbxPastHis.ReservedMemoButtonClick += new System.EventHandler(this.mbxPast_his_ReservedMemoButtonClick);
            // 
            // lblHealthCare
            // 
            this.lblHealthCare.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHealthCare.EdgeRounding = false;
            this.lblHealthCare.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHealthCare.Location = new System.Drawing.Point(13, 123);
            this.lblHealthCare.Name = "lblHealthCare";
            this.lblHealthCare.Size = new System.Drawing.Size(72, 32);
            this.lblHealthCare.TabIndex = 999;
            this.lblHealthCare.Text = "健康管理の方法";
            this.lblHealthCare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHealthCare.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblBringDrug
            // 
            this.lblBringDrug.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBringDrug.EdgeRounding = false;
            this.lblBringDrug.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBringDrug.Location = new System.Drawing.Point(13, 76);
            this.lblBringDrug.Name = "lblBringDrug";
            this.lblBringDrug.Size = new System.Drawing.Size(72, 24);
            this.lblBringDrug.TabIndex = 999;
            this.lblBringDrug.Text = "持　参　薬";
            this.lblBringDrug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBringDrug.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblPast_his
            // 
            this.lblPast_his.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblPast_his.EdgeRounding = false;
            this.lblPast_his.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblPast_his.Location = new System.Drawing.Point(13, 29);
            this.lblPast_his.Name = "lblPast_his";
            this.lblPast_his.Size = new System.Drawing.Size(72, 24);
            this.lblPast_his.TabIndex = 999;
            this.lblPast_his.Text = "既　往　歴";
            this.lblPast_his.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxBringDrug
            // 
            this.gbxBringDrug.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxBringDrug.Controls.Add(this.rbxBringDrugY);
            this.gbxBringDrug.Controls.Add(this.rbxBringDrugN);
            this.gbxBringDrug.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxBringDrug.Location = new System.Drawing.Point(91, 70);
            this.gbxBringDrug.Name = "gbxBringDrug";
            this.gbxBringDrug.Size = new System.Drawing.Size(101, 31);
            this.gbxBringDrug.TabIndex = 2;
            this.gbxBringDrug.TabStop = false;
            // 
            // rbxBringDrugY
            // 
            this.rbxBringDrugY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxBringDrugY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxBringDrugY.Location = new System.Drawing.Point(10, 9);
            this.rbxBringDrugY.Name = "rbxBringDrugY";
            this.rbxBringDrugY.Size = new System.Drawing.Size(36, 18);
            this.rbxBringDrugY.TabIndex = 0;
            this.rbxBringDrugY.TabStop = true;
            this.rbxBringDrugY.Text = "有";
            this.rbxBringDrugY.UseVisualStyleBackColor = false;
            this.rbxBringDrugY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxBringDrugN
            // 
            this.rbxBringDrugN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxBringDrugN.CheckedValue = "N";
            this.rbxBringDrugN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxBringDrugN.Location = new System.Drawing.Point(60, 9);
            this.rbxBringDrugN.Name = "rbxBringDrugN";
            this.rbxBringDrugN.Size = new System.Drawing.Size(35, 18);
            this.rbxBringDrugN.TabIndex = 1;
            this.rbxBringDrugN.TabStop = true;
            this.rbxBringDrugN.Text = "無";
            this.rbxBringDrugN.UseVisualStyleBackColor = false;
            // 
            // xLabel146
            // 
            this.xLabel146.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel146.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel146.Location = new System.Drawing.Point(139, 178);
            this.xLabel146.Name = "xLabel146";
            this.xLabel146.Size = new System.Drawing.Size(53, 24);
            this.xLabel146.TabIndex = 999;
            this.xLabel146.Text = "本/日";
            this.xLabel146.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel147
            // 
            this.xLabel147.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel147.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel147.Location = new System.Drawing.Point(327, 178);
            this.xLabel147.Name = "xLabel147";
            this.xLabel147.Size = new System.Drawing.Size(53, 24);
            this.xLabel147.TabIndex = 999;
            this.xLabel147.Text = "本/日";
            this.xLabel147.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel147.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.xPanel8);
            this.tabPage4.Controls.Add(this.pnlFood);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(841, 538);
            this.tabPage4.TabIndex = 999;
            this.tabPage4.Title = "Ⅱ・Ⅲ.栄養・代謝";
            // 
            // xPanel8
            // 
            this.xPanel8.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel8.Controls.Add(this.btnSkinDel);
            this.xPanel8.Controls.Add(this.btnSkinAdd);
            this.xPanel8.Controls.Add(this.grdNUR1029);
            this.xPanel8.Controls.Add(this.xLabel107);
            this.xPanel8.Controls.Add(this.cbxEnterokinesia);
            this.xPanel8.Controls.Add(this.cbxAbtominalVery);
            this.xPanel8.Controls.Add(this.cbxAbdominal);
            this.xPanel8.Controls.Add(this.xLabel96);
            this.xPanel8.Controls.Add(this.groupBox10);
            this.xPanel8.Controls.Add(this.groupBox5);
            this.xPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Location = new System.Drawing.Point(402, 0);
            this.xPanel8.Name = "xPanel8";
            this.xPanel8.Size = new System.Drawing.Size(439, 538);
            this.xPanel8.TabIndex = 5;
            // 
            // btnSkinDel
            // 
            this.btnSkinDel.ImageIndex = 2;
            this.btnSkinDel.ImageList = this.ImageList;
            this.btnSkinDel.Location = new System.Drawing.Point(35, 63);
            this.btnSkinDel.Name = "btnSkinDel";
            this.btnSkinDel.Size = new System.Drawing.Size(61, 23);
            this.btnSkinDel.TabIndex = 2;
            this.btnSkinDel.Text = "削除";
            this.btnSkinDel.Click += new System.EventHandler(this.btnSkinDel_Click);
            // 
            // btnSkinAdd
            // 
            this.btnSkinAdd.ImageIndex = 1;
            this.btnSkinAdd.ImageList = this.ImageList;
            this.btnSkinAdd.Location = new System.Drawing.Point(36, 38);
            this.btnSkinAdd.Name = "btnSkinAdd";
            this.btnSkinAdd.Size = new System.Drawing.Size(58, 23);
            this.btnSkinAdd.TabIndex = 1;
            this.btnSkinAdd.Text = "入力";
            this.btnSkinAdd.Click += new System.EventHandler(this.btnSkinAdd_Click);
            // 
            // grdNUR1029
            // 
            this.grdNUR1029.CallerID = 'S';
            this.grdNUR1029.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell16,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32});
            this.grdNUR1029.ColPerLine = 3;
            this.grdNUR1029.Cols = 3;
            this.grdNUR1029.FixedRows = 1;
            this.grdNUR1029.HeaderHeights.Add(21);
            this.grdNUR1029.Location = new System.Drawing.Point(100, 10);
            this.grdNUR1029.Name = "grdNUR1029";
            this.grdNUR1029.QuerySQL = "  SELECT PKNUR1029\r\n       , START_DATE\r\n       , BUWI\r\n       , BUWI_COMMENT\r\n  " +
                "  FROM NUR1029\r\n   WHERE HOSP_CODE = :f_hosp_code\r\n     AND BUNHO     = :f_bunho" +
                "";
            this.grdNUR1029.Rows = 2;
            this.grdNUR1029.Size = new System.Drawing.Size(289, 97);
            this.grdNUR1029.TabIndex = 999;
            this.grdNUR1029.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1029_QueryStarting);
            this.grdNUR1029.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdNUR1029_GridFindClick);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "pknur1029";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "pknur1029";
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "start_date";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell30.CellWidth = 92;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell30.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell30.HeaderText = "入力日";
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 15;
            this.xEditGridCell31.CellName = "buwi";
            this.xEditGridCell31.CellWidth = 52;
            this.xEditGridCell31.Col = 1;
            this.xEditGridCell31.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell31.FindWorker = this.fwkCommon;
            this.xEditGridCell31.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell31.HeaderText = "部位";
            this.xEditGridCell31.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellLen = 500;
            this.xEditGridCell32.CellName = "buwi_comment";
            this.xEditGridCell32.CellWidth = 123;
            this.xEditGridCell32.Col = 2;
            this.xEditGridCell32.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell32.HeaderText = "状態";
            this.xEditGridCell32.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xLabel107
            // 
            this.xLabel107.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel107.EdgeRounding = false;
            this.xLabel107.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel107.Location = new System.Drawing.Point(15, 11);
            this.xLabel107.Name = "xLabel107";
            this.xLabel107.Size = new System.Drawing.Size(79, 24);
            this.xLabel107.TabIndex = 999;
            this.xLabel107.Text = "皮膚の損傷";
            this.xLabel107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxEnterokinesia
            // 
            this.cbxEnterokinesia.AutoSize = true;
            this.cbxEnterokinesia.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxEnterokinesia.Location = new System.Drawing.Point(326, 456);
            this.cbxEnterokinesia.Name = "cbxEnterokinesia";
            this.cbxEnterokinesia.Size = new System.Drawing.Size(62, 17);
            this.cbxEnterokinesia.TabIndex = 7;
            this.cbxEnterokinesia.Text = "腸蠕動";
            this.cbxEnterokinesia.UseVisualStyleBackColor = false;
            // 
            // cbxAbtominalVery
            // 
            this.cbxAbtominalVery.AutoSize = true;
            this.cbxAbtominalVery.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxAbtominalVery.Location = new System.Drawing.Point(219, 456);
            this.cbxAbtominalVery.Name = "cbxAbtominalVery";
            this.cbxAbtominalVery.Size = new System.Drawing.Size(75, 17);
            this.cbxAbtominalVery.TabIndex = 6;
            this.cbxAbtominalVery.Text = "腹部緊満";
            this.cbxAbtominalVery.UseVisualStyleBackColor = false;
            // 
            // cbxAbdominal
            // 
            this.cbxAbdominal.AutoSize = true;
            this.cbxAbdominal.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxAbdominal.Location = new System.Drawing.Point(112, 456);
            this.cbxAbdominal.Name = "cbxAbdominal";
            this.cbxAbdominal.Size = new System.Drawing.Size(75, 17);
            this.cbxAbdominal.TabIndex = 5;
            this.cbxAbdominal.Text = "腹部膨満";
            this.cbxAbdominal.UseVisualStyleBackColor = false;
            // 
            // xLabel96
            // 
            this.xLabel96.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel96.EdgeRounding = false;
            this.xLabel96.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel96.Location = new System.Drawing.Point(21, 453);
            this.xLabel96.Name = "xLabel96";
            this.xLabel96.Size = new System.Drawing.Size(80, 24);
            this.xLabel96.TabIndex = 999;
            this.xLabel96.Text = "腹部の状態";
            this.xLabel96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtIntermittent);
            this.groupBox10.Controls.Add(this.txtUrinNightCnt);
            this.groupBox10.Controls.Add(this.dtpCatheter);
            this.groupBox10.Controls.Add(this.xLabel94);
            this.groupBox10.Controls.Add(this.cbxCatheter);
            this.groupBox10.Controls.Add(this.xLabel106);
            this.groupBox10.Controls.Add(this.cbxIntermittent);
            this.groupBox10.Controls.Add(this.cbxDiapersU);
            this.groupBox10.Controls.Add(this.gbxUrinWill);
            this.groupBox10.Controls.Add(this.lblUrinWill);
            this.groupBox10.Controls.Add(this.xLabel97);
            this.groupBox10.Controls.Add(this.cboUrinDay);
            this.groupBox10.Controls.Add(this.cboUrinCnt);
            this.groupBox10.Controls.Add(this.xLabel98);
            this.groupBox10.Controls.Add(this.xLabel103);
            this.groupBox10.Controls.Add(this.xLabel104);
            this.groupBox10.Controls.Add(this.xLabel105);
            this.groupBox10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox10.ForeColor = System.Drawing.Color.Black;
            this.groupBox10.Location = new System.Drawing.Point(18, 290);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(371, 150);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "排尿のパタン";
            // 
            // txtIntermittent
            // 
            this.txtIntermittent.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtIntermittent.Location = new System.Drawing.Point(222, 94);
            this.txtIntermittent.Name = "txtIntermittent";
            this.txtIntermittent.Size = new System.Drawing.Size(31, 20);
            this.txtIntermittent.TabIndex = 6;
            this.txtIntermittent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUrinNightCnt
            // 
            this.txtUrinNightCnt.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtUrinNightCnt.Location = new System.Drawing.Point(75, 61);
            this.txtUrinNightCnt.Name = "txtUrinNightCnt";
            this.txtUrinNightCnt.Size = new System.Drawing.Size(86, 20);
            this.txtUrinNightCnt.TabIndex = 3;
            this.txtUrinNightCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpCatheter
            // 
            this.dtpCatheter.Enabled = false;
            this.dtpCatheter.IsJapanYearType = true;
            this.dtpCatheter.Location = new System.Drawing.Point(148, 123);
            this.dtpCatheter.Name = "dtpCatheter";
            this.dtpCatheter.Size = new System.Drawing.Size(110, 20);
            this.dtpCatheter.TabIndex = 8;
            this.dtpCatheter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel94
            // 
            this.xLabel94.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel94.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel94.Location = new System.Drawing.Point(248, 94);
            this.xLabel94.Name = "xLabel94";
            this.xLabel94.Size = new System.Drawing.Size(53, 24);
            this.xLabel94.TabIndex = 999;
            this.xLabel94.Text = "時間毎";
            this.xLabel94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxCatheter
            // 
            this.cbxCatheter.AutoSize = true;
            this.cbxCatheter.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxCatheter.Location = new System.Drawing.Point(73, 124);
            this.cbxCatheter.Name = "cbxCatheter";
            this.cbxCatheter.Size = new System.Drawing.Size(74, 17);
            this.cbxCatheter.TabIndex = 7;
            this.cbxCatheter.Text = "カテーテル";
            this.cbxCatheter.UseVisualStyleBackColor = false;
            this.cbxCatheter.CheckedChanged += new System.EventHandler(this.cbxCheckedChanged);
            // 
            // xLabel106
            // 
            this.xLabel106.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel106.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel106.Location = new System.Drawing.Point(155, 62);
            this.xLabel106.Name = "xLabel106";
            this.xLabel106.Size = new System.Drawing.Size(32, 24);
            this.xLabel106.TabIndex = 999;
            this.xLabel106.Text = "回";
            this.xLabel106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxIntermittent
            // 
            this.cbxIntermittent.AutoSize = true;
            this.cbxIntermittent.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxIntermittent.Location = new System.Drawing.Point(171, 98);
            this.cbxIntermittent.Name = "cbxIntermittent";
            this.cbxIntermittent.Size = new System.Drawing.Size(49, 17);
            this.cbxIntermittent.TabIndex = 5;
            this.cbxIntermittent.Text = "間欠";
            this.cbxIntermittent.UseVisualStyleBackColor = false;
            // 
            // cbxDiapersU
            // 
            this.cbxDiapersU.AutoSize = true;
            this.cbxDiapersU.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxDiapersU.Location = new System.Drawing.Point(267, 124);
            this.cbxDiapersU.Name = "cbxDiapersU";
            this.cbxDiapersU.Size = new System.Drawing.Size(54, 17);
            this.cbxDiapersU.TabIndex = 9;
            this.cbxDiapersU.Text = "オムツ";
            this.cbxDiapersU.UseVisualStyleBackColor = false;
            // 
            // gbxUrinWill
            // 
            this.gbxUrinWill.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxUrinWill.Controls.Add(this.rbxUrinN);
            this.gbxUrinWill.Controls.Add(this.rbxUrinWillY);
            this.gbxUrinWill.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxUrinWill.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.gbxUrinWill.Location = new System.Drawing.Point(75, 88);
            this.gbxUrinWill.Name = "gbxUrinWill";
            this.gbxUrinWill.Size = new System.Drawing.Size(93, 31);
            this.gbxUrinWill.TabIndex = 4;
            this.gbxUrinWill.TabStop = false;
            // 
            // rbxUrinN
            // 
            this.rbxUrinN.AutoSize = true;
            this.rbxUrinN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxUrinN.CheckedValue = "N";
            this.rbxUrinN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxUrinN.Location = new System.Drawing.Point(50, 10);
            this.rbxUrinN.Name = "rbxUrinN";
            this.rbxUrinN.Size = new System.Drawing.Size(37, 17);
            this.rbxUrinN.TabIndex = 2;
            this.rbxUrinN.TabStop = true;
            this.rbxUrinN.Text = "無";
            this.rbxUrinN.UseVisualStyleBackColor = false;
            // 
            // rbxUrinWillY
            // 
            this.rbxUrinWillY.AutoSize = true;
            this.rbxUrinWillY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxUrinWillY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxUrinWillY.Location = new System.Drawing.Point(7, 10);
            this.rbxUrinWillY.Name = "rbxUrinWillY";
            this.rbxUrinWillY.Size = new System.Drawing.Size(37, 17);
            this.rbxUrinWillY.TabIndex = 1;
            this.rbxUrinWillY.TabStop = true;
            this.rbxUrinWillY.Text = "有";
            this.rbxUrinWillY.UseVisualStyleBackColor = false;
            // 
            // lblUrinWill
            // 
            this.lblUrinWill.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblUrinWill.EdgeRounding = false;
            this.lblUrinWill.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblUrinWill.Location = new System.Drawing.Point(15, 92);
            this.lblUrinWill.Name = "lblUrinWill";
            this.lblUrinWill.Size = new System.Drawing.Size(54, 24);
            this.lblUrinWill.TabIndex = 999;
            this.lblUrinWill.Text = "尿　意";
            this.lblUrinWill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUrinWill.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // xLabel97
            // 
            this.xLabel97.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel97.EdgeRounding = false;
            this.xLabel97.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel97.Location = new System.Drawing.Point(15, 59);
            this.xLabel97.Name = "xLabel97";
            this.xLabel97.Size = new System.Drawing.Size(54, 24);
            this.xLabel97.TabIndex = 999;
            this.xLabel97.Text = "夜　間";
            this.xLabel97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboUrinDay
            // 
            this.cboUrinDay.Location = new System.Drawing.Point(250, 23);
            this.cboUrinDay.Name = "cboUrinDay";
            this.cboUrinDay.Size = new System.Drawing.Size(64, 21);
            this.cboUrinDay.TabIndex = 2;
            // 
            // cboUrinCnt
            // 
            this.cboUrinCnt.Location = new System.Drawing.Point(75, 22);
            this.cboUrinCnt.Name = "cboUrinCnt";
            this.cboUrinCnt.Size = new System.Drawing.Size(64, 21);
            this.cboUrinCnt.TabIndex = 1;
            // 
            // xLabel98
            // 
            this.xLabel98.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel98.EdgeRounding = false;
            this.xLabel98.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel98.Location = new System.Drawing.Point(15, 22);
            this.xLabel98.Name = "xLabel98";
            this.xLabel98.Size = new System.Drawing.Size(54, 24);
            this.xLabel98.TabIndex = 999;
            this.xLabel98.Text = "回　数";
            this.xLabel98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel103
            // 
            this.xLabel103.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel103.EdgeRounding = false;
            this.xLabel103.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel103.Location = new System.Drawing.Point(190, 19);
            this.xLabel103.Name = "xLabel103";
            this.xLabel103.Size = new System.Drawing.Size(54, 24);
            this.xLabel103.TabIndex = 999;
            this.xLabel103.Text = "日　数";
            this.xLabel103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel104
            // 
            this.xLabel104.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel104.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel104.Location = new System.Drawing.Point(130, 23);
            this.xLabel104.Name = "xLabel104";
            this.xLabel104.Size = new System.Drawing.Size(40, 24);
            this.xLabel104.TabIndex = 999;
            this.xLabel104.Text = "回";
            this.xLabel104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel105
            // 
            this.xLabel105.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel105.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel105.Location = new System.Drawing.Point(304, 24);
            this.xLabel105.Name = "xLabel105";
            this.xLabel105.Size = new System.Drawing.Size(40, 24);
            this.xLabel105.TabIndex = 999;
            this.xLabel105.Text = "日";
            this.xLabel105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtLaxation);
            this.groupBox5.Controls.Add(this.cbxAntidiarrheal);
            this.groupBox5.Controls.Add(this.cbxSuppository);
            this.groupBox5.Controls.Add(this.cbxLaxative);
            this.groupBox5.Controls.Add(this.cbxEnema);
            this.groupBox5.Controls.Add(this.xLabel102);
            this.groupBox5.Controls.Add(this.cbxOrthotics);
            this.groupBox5.Controls.Add(this.cbxDiapersD);
            this.groupBox5.Controls.Add(this.gbxDungWill);
            this.groupBox5.Controls.Add(this.txtDungLast);
            this.groupBox5.Controls.Add(this.txtDungState);
            this.groupBox5.Controls.Add(this.lblDungWill);
            this.groupBox5.Controls.Add(this.xLabel100);
            this.groupBox5.Controls.Add(this.xLabel99);
            this.groupBox5.Controls.Add(this.cboDungDay);
            this.groupBox5.Controls.Add(this.cboDungCnt);
            this.groupBox5.Controls.Add(this.xLabel71);
            this.groupBox5.Controls.Add(this.xLabel73);
            this.groupBox5.Controls.Add(this.xLabel75);
            this.groupBox5.Controls.Add(this.xLabel76);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(18, 113);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(371, 163);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "排便のパタン";
            // 
            // txtLaxation
            // 
            this.txtLaxation.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtLaxation.Location = new System.Drawing.Point(117, 126);
            this.txtLaxation.Name = "txtLaxation";
            this.txtLaxation.Size = new System.Drawing.Size(229, 20);
            this.txtLaxation.TabIndex = 12;
            // 
            // cbxAntidiarrheal
            // 
            this.cbxAntidiarrheal.AutoSize = true;
            this.cbxAntidiarrheal.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxAntidiarrheal.Location = new System.Drawing.Point(275, 109);
            this.cbxAntidiarrheal.Name = "cbxAntidiarrheal";
            this.cbxAntidiarrheal.Size = new System.Drawing.Size(73, 17);
            this.cbxAntidiarrheal.TabIndex = 11;
            this.cbxAntidiarrheal.Text = "下痢止め";
            this.cbxAntidiarrheal.UseVisualStyleBackColor = false;
            // 
            // cbxSuppository
            // 
            this.cbxSuppository.AutoSize = true;
            this.cbxSuppository.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxSuppository.Location = new System.Drawing.Point(222, 109);
            this.cbxSuppository.Name = "cbxSuppository";
            this.cbxSuppository.Size = new System.Drawing.Size(49, 17);
            this.cbxSuppository.TabIndex = 10;
            this.cbxSuppository.Text = "座薬";
            this.cbxSuppository.UseVisualStyleBackColor = false;
            // 
            // cbxLaxative
            // 
            this.cbxLaxative.AutoSize = true;
            this.cbxLaxative.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxLaxative.Location = new System.Drawing.Point(171, 109);
            this.cbxLaxative.Name = "cbxLaxative";
            this.cbxLaxative.Size = new System.Drawing.Size(49, 17);
            this.cbxLaxative.TabIndex = 9;
            this.cbxLaxative.Text = "下剤";
            this.cbxLaxative.UseVisualStyleBackColor = false;
            // 
            // cbxEnema
            // 
            this.cbxEnema.AutoSize = true;
            this.cbxEnema.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxEnema.Location = new System.Drawing.Point(118, 109);
            this.cbxEnema.Name = "cbxEnema";
            this.cbxEnema.Size = new System.Drawing.Size(49, 17);
            this.cbxEnema.TabIndex = 8;
            this.cbxEnema.Text = "浣腸";
            this.cbxEnema.UseVisualStyleBackColor = false;
            // 
            // xLabel102
            // 
            this.xLabel102.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel102.EdgeRounding = false;
            this.xLabel102.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel102.Location = new System.Drawing.Point(15, 108);
            this.xLabel102.Name = "xLabel102";
            this.xLabel102.Size = new System.Drawing.Size(96, 38);
            this.xLabel102.TabIndex = 999;
            this.xLabel102.Text = "便通のために使用するもの";
            this.xLabel102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxOrthotics
            // 
            this.cbxOrthotics.AutoSize = true;
            this.cbxOrthotics.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxOrthotics.Location = new System.Drawing.Point(222, 84);
            this.cbxOrthotics.Name = "cbxOrthotics";
            this.cbxOrthotics.Size = new System.Drawing.Size(49, 17);
            this.cbxOrthotics.TabIndex = 7;
            this.cbxOrthotics.Text = "装具";
            this.cbxOrthotics.UseVisualStyleBackColor = false;
            // 
            // cbxDiapersD
            // 
            this.cbxDiapersD.AutoSize = true;
            this.cbxDiapersD.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxDiapersD.Location = new System.Drawing.Point(171, 84);
            this.cbxDiapersD.Name = "cbxDiapersD";
            this.cbxDiapersD.Size = new System.Drawing.Size(54, 17);
            this.cbxDiapersD.TabIndex = 6;
            this.cbxDiapersD.Text = "オムツ";
            this.cbxDiapersD.UseVisualStyleBackColor = false;
            // 
            // gbxDungWill
            // 
            this.gbxDungWill.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxDungWill.Controls.Add(this.rbxDungWillN);
            this.gbxDungWill.Controls.Add(this.rbxDungWillY);
            this.gbxDungWill.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxDungWill.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.gbxDungWill.Location = new System.Drawing.Point(75, 74);
            this.gbxDungWill.Name = "gbxDungWill";
            this.gbxDungWill.Size = new System.Drawing.Size(93, 31);
            this.gbxDungWill.TabIndex = 5;
            this.gbxDungWill.TabStop = false;
            // 
            // rbxDungWillN
            // 
            this.rbxDungWillN.AutoSize = true;
            this.rbxDungWillN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxDungWillN.CheckedValue = "N";
            this.rbxDungWillN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxDungWillN.Location = new System.Drawing.Point(50, 10);
            this.rbxDungWillN.Name = "rbxDungWillN";
            this.rbxDungWillN.Size = new System.Drawing.Size(37, 17);
            this.rbxDungWillN.TabIndex = 2;
            this.rbxDungWillN.TabStop = true;
            this.rbxDungWillN.Text = "無";
            this.rbxDungWillN.UseVisualStyleBackColor = false;
            // 
            // rbxDungWillY
            // 
            this.rbxDungWillY.AutoSize = true;
            this.rbxDungWillY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxDungWillY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxDungWillY.Location = new System.Drawing.Point(7, 10);
            this.rbxDungWillY.Name = "rbxDungWillY";
            this.rbxDungWillY.Size = new System.Drawing.Size(37, 17);
            this.rbxDungWillY.TabIndex = 1;
            this.rbxDungWillY.TabStop = true;
            this.rbxDungWillY.Text = "有";
            this.rbxDungWillY.UseVisualStyleBackColor = false;
            // 
            // txtDungLast
            // 
            this.txtDungLast.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDungLast.Location = new System.Drawing.Point(255, 50);
            this.txtDungLast.Name = "txtDungLast";
            this.txtDungLast.Size = new System.Drawing.Size(91, 20);
            this.txtDungLast.TabIndex = 4;
            // 
            // txtDungState
            // 
            this.txtDungState.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDungState.Location = new System.Drawing.Point(75, 50);
            this.txtDungState.Name = "txtDungState";
            this.txtDungState.Size = new System.Drawing.Size(86, 20);
            this.txtDungState.TabIndex = 3;
            // 
            // lblDungWill
            // 
            this.lblDungWill.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDungWill.EdgeRounding = false;
            this.lblDungWill.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblDungWill.Location = new System.Drawing.Point(15, 78);
            this.lblDungWill.Name = "lblDungWill";
            this.lblDungWill.Size = new System.Drawing.Size(54, 24);
            this.lblDungWill.TabIndex = 999;
            this.lblDungWill.Text = "便　意";
            this.lblDungWill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDungWill.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // xLabel100
            // 
            this.xLabel100.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel100.EdgeRounding = false;
            this.xLabel100.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel100.Location = new System.Drawing.Point(190, 50);
            this.xLabel100.Name = "xLabel100";
            this.xLabel100.Size = new System.Drawing.Size(60, 24);
            this.xLabel100.TabIndex = 999;
            this.xLabel100.Text = "最終排便";
            this.xLabel100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel99
            // 
            this.xLabel99.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel99.EdgeRounding = false;
            this.xLabel99.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel99.Location = new System.Drawing.Point(15, 50);
            this.xLabel99.Name = "xLabel99";
            this.xLabel99.Size = new System.Drawing.Size(54, 24);
            this.xLabel99.TabIndex = 999;
            this.xLabel99.Text = "性　状";
            this.xLabel99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDungDay
            // 
            this.cboDungDay.Location = new System.Drawing.Point(255, 23);
            this.cboDungDay.Name = "cboDungDay";
            this.cboDungDay.Size = new System.Drawing.Size(64, 21);
            this.cboDungDay.TabIndex = 2;
            // 
            // cboDungCnt
            // 
            this.cboDungCnt.Location = new System.Drawing.Point(75, 22);
            this.cboDungCnt.Name = "cboDungCnt";
            this.cboDungCnt.Size = new System.Drawing.Size(64, 21);
            this.cboDungCnt.TabIndex = 1;
            // 
            // xLabel71
            // 
            this.xLabel71.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel71.EdgeRounding = false;
            this.xLabel71.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel71.Location = new System.Drawing.Point(15, 22);
            this.xLabel71.Name = "xLabel71";
            this.xLabel71.Size = new System.Drawing.Size(54, 24);
            this.xLabel71.TabIndex = 999;
            this.xLabel71.Text = "回　数";
            this.xLabel71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel73
            // 
            this.xLabel73.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel73.EdgeRounding = false;
            this.xLabel73.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel73.Location = new System.Drawing.Point(190, 19);
            this.xLabel73.Name = "xLabel73";
            this.xLabel73.Size = new System.Drawing.Size(61, 24);
            this.xLabel73.TabIndex = 999;
            this.xLabel73.Text = "日　数";
            this.xLabel73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel75
            // 
            this.xLabel75.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel75.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel75.Location = new System.Drawing.Point(130, 23);
            this.xLabel75.Name = "xLabel75";
            this.xLabel75.Size = new System.Drawing.Size(40, 24);
            this.xLabel75.TabIndex = 999;
            this.xLabel75.Text = "回";
            this.xLabel75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel76
            // 
            this.xLabel76.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel76.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel76.Location = new System.Drawing.Point(308, 24);
            this.xLabel76.Name = "xLabel76";
            this.xLabel76.Size = new System.Drawing.Size(40, 24);
            this.xLabel76.TabIndex = 999;
            this.xLabel76.Text = "日";
            this.xLabel76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFood
            // 
            this.pnlFood.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFood.Controls.Add(this.txtWeight);
            this.pnlFood.Controls.Add(this.txtHeight);
            this.pnlFood.Controls.Add(this.txtBMI);
            this.pnlFood.Controls.Add(this.xLabel111);
            this.pnlFood.Controls.Add(this.xLabel110);
            this.pnlFood.Controls.Add(this.cboWeightUpdownHow);
            this.pnlFood.Controls.Add(this.txtFalseTeeth);
            this.pnlFood.Controls.Add(this.cboWeightUpdownStart);
            this.pnlFood.Controls.Add(this.xLabel108);
            this.pnlFood.Controls.Add(this.gbxFalseTeeth);
            this.pnlFood.Controls.Add(this.xLabel109);
            this.pnlFood.Controls.Add(this.txtMouthPollution);
            this.pnlFood.Controls.Add(this.gbxMouthPollution);
            this.pnlFood.Controls.Add(this.groupBox11);
            this.pnlFood.Controls.Add(this.xLabel93);
            this.pnlFood.Controls.Add(this.xLabel92);
            this.pnlFood.Controls.Add(this.xLabel90);
            this.pnlFood.Controls.Add(this.xLabel89);
            this.pnlFood.Controls.Add(this.lblFalseTeeth);
            this.pnlFood.Controls.Add(this.lblMouthPollution);
            this.pnlFood.Controls.Add(this.groupBox4);
            this.pnlFood.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFood.DrawBorder = true;
            this.pnlFood.Location = new System.Drawing.Point(0, 0);
            this.pnlFood.Name = "pnlFood";
            this.pnlFood.Size = new System.Drawing.Size(402, 538);
            this.pnlFood.TabIndex = 4;
            // 
            // txtWeight
            // 
            this.txtWeight.DecimalDigits = 1;
            this.txtWeight.EditMaskType = IHIS.Framework.MaskType.Decimal;
            this.txtWeight.Location = new System.Drawing.Point(206, 345);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(46, 20);
            this.txtWeight.TabIndex = 9;
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWeight.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtWeight_DataValidating);
            // 
            // txtHeight
            // 
            this.txtHeight.DecimalDigits = 1;
            this.txtHeight.EditMaskType = IHIS.Framework.MaskType.Decimal;
            this.txtHeight.Location = new System.Drawing.Point(74, 345);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(45, 20);
            this.txtHeight.TabIndex = 8;
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHeight.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHeight_DataValidating);
            // 
            // txtBMI
            // 
            this.txtBMI.Enabled = false;
            this.txtBMI.Location = new System.Drawing.Point(332, 345);
            this.txtBMI.Name = "txtBMI";
            this.txtBMI.Size = new System.Drawing.Size(43, 20);
            this.txtBMI.TabIndex = 999;
            // 
            // xLabel111
            // 
            this.xLabel111.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel111.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel111.Location = new System.Drawing.Point(249, 345);
            this.xLabel111.Name = "xLabel111";
            this.xLabel111.Size = new System.Drawing.Size(27, 24);
            this.xLabel111.TabIndex = 999;
            this.xLabel111.Text = "kg";
            this.xLabel111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel110
            // 
            this.xLabel110.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel110.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel110.Location = new System.Drawing.Point(117, 345);
            this.xLabel110.Name = "xLabel110";
            this.xLabel110.Size = new System.Drawing.Size(27, 24);
            this.xLabel110.TabIndex = 999;
            this.xLabel110.Text = "cm";
            this.xLabel110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboWeightUpdownHow
            // 
            this.cboWeightUpdownHow.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F);
            this.cboWeightUpdownHow.Location = new System.Drawing.Point(254, 316);
            this.cboWeightUpdownHow.Name = "cboWeightUpdownHow";
            this.cboWeightUpdownHow.Size = new System.Drawing.Size(77, 21);
            this.cboWeightUpdownHow.TabIndex = 7;
            // 
            // txtFalseTeeth
            // 
            this.txtFalseTeeth.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFalseTeeth.Location = new System.Drawing.Point(226, 288);
            this.txtFalseTeeth.Name = "txtFalseTeeth";
            this.txtFalseTeeth.Size = new System.Drawing.Size(127, 20);
            this.txtFalseTeeth.TabIndex = 5;
            // 
            // cboWeightUpdownStart
            // 
            this.cboWeightUpdownStart.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F);
            this.cboWeightUpdownStart.Location = new System.Drawing.Point(129, 316);
            this.cboWeightUpdownStart.Name = "cboWeightUpdownStart";
            this.cboWeightUpdownStart.Size = new System.Drawing.Size(74, 21);
            this.cboWeightUpdownStart.TabIndex = 6;
            // 
            // xLabel108
            // 
            this.xLabel108.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel108.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel108.Location = new System.Drawing.Point(195, 315);
            this.xLabel108.Name = "xLabel108";
            this.xLabel108.Size = new System.Drawing.Size(61, 24);
            this.xLabel108.TabIndex = 999;
            this.xLabel108.Text = "日前から";
            this.xLabel108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxFalseTeeth
            // 
            this.gbxFalseTeeth.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxFalseTeeth.Controls.Add(this.rbxFalseTeethN);
            this.gbxFalseTeeth.Controls.Add(this.rbxFalseTeethY);
            this.gbxFalseTeeth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxFalseTeeth.Location = new System.Drawing.Point(130, 280);
            this.gbxFalseTeeth.Name = "gbxFalseTeeth";
            this.gbxFalseTeeth.Size = new System.Drawing.Size(94, 31);
            this.gbxFalseTeeth.TabIndex = 4;
            this.gbxFalseTeeth.TabStop = false;
            // 
            // rbxFalseTeethN
            // 
            this.rbxFalseTeethN.AutoSize = true;
            this.rbxFalseTeethN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxFalseTeethN.CheckedValue = "N";
            this.rbxFalseTeethN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxFalseTeethN.Location = new System.Drawing.Point(53, 10);
            this.rbxFalseTeethN.Name = "rbxFalseTeethN";
            this.rbxFalseTeethN.Size = new System.Drawing.Size(37, 17);
            this.rbxFalseTeethN.TabIndex = 2;
            this.rbxFalseTeethN.TabStop = true;
            this.rbxFalseTeethN.Text = "無";
            this.rbxFalseTeethN.UseVisualStyleBackColor = false;
            // 
            // rbxFalseTeethY
            // 
            this.rbxFalseTeethY.AutoSize = true;
            this.rbxFalseTeethY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxFalseTeethY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxFalseTeethY.Location = new System.Drawing.Point(6, 10);
            this.rbxFalseTeethY.Name = "rbxFalseTeethY";
            this.rbxFalseTeethY.Size = new System.Drawing.Size(37, 17);
            this.rbxFalseTeethY.TabIndex = 1;
            this.rbxFalseTeethY.TabStop = true;
            this.rbxFalseTeethY.Text = "有";
            this.rbxFalseTeethY.UseVisualStyleBackColor = false;
            this.rbxFalseTeethY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // xLabel109
            // 
            this.xLabel109.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel109.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel109.Location = new System.Drawing.Point(328, 315);
            this.xLabel109.Name = "xLabel109";
            this.xLabel109.Size = new System.Drawing.Size(53, 24);
            this.xLabel109.TabIndex = 999;
            this.xLabel109.Text = "kgぐらい";
            this.xLabel109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMouthPollution
            // 
            this.txtMouthPollution.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtMouthPollution.Location = new System.Drawing.Point(226, 258);
            this.txtMouthPollution.Name = "txtMouthPollution";
            this.txtMouthPollution.Size = new System.Drawing.Size(127, 20);
            this.txtMouthPollution.TabIndex = 3;
            // 
            // gbxMouthPollution
            // 
            this.gbxMouthPollution.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxMouthPollution.Controls.Add(this.rbxMouthPollutionN);
            this.gbxMouthPollution.Controls.Add(this.rbxMouthPollutionY);
            this.gbxMouthPollution.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxMouthPollution.Location = new System.Drawing.Point(130, 250);
            this.gbxMouthPollution.Name = "gbxMouthPollution";
            this.gbxMouthPollution.Size = new System.Drawing.Size(94, 31);
            this.gbxMouthPollution.TabIndex = 2;
            this.gbxMouthPollution.TabStop = false;
            // 
            // rbxMouthPollutionN
            // 
            this.rbxMouthPollutionN.AutoSize = true;
            this.rbxMouthPollutionN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxMouthPollutionN.CheckedValue = "N";
            this.rbxMouthPollutionN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxMouthPollutionN.Location = new System.Drawing.Point(53, 10);
            this.rbxMouthPollutionN.Name = "rbxMouthPollutionN";
            this.rbxMouthPollutionN.Size = new System.Drawing.Size(37, 17);
            this.rbxMouthPollutionN.TabIndex = 2;
            this.rbxMouthPollutionN.TabStop = true;
            this.rbxMouthPollutionN.Text = "無";
            this.rbxMouthPollutionN.UseVisualStyleBackColor = false;
            // 
            // rbxMouthPollutionY
            // 
            this.rbxMouthPollutionY.AutoSize = true;
            this.rbxMouthPollutionY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxMouthPollutionY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxMouthPollutionY.Location = new System.Drawing.Point(6, 10);
            this.rbxMouthPollutionY.Name = "rbxMouthPollutionY";
            this.rbxMouthPollutionY.Size = new System.Drawing.Size(37, 17);
            this.rbxMouthPollutionY.TabIndex = 1;
            this.rbxMouthPollutionY.TabStop = true;
            this.rbxMouthPollutionY.Text = "有";
            this.rbxMouthPollutionY.UseVisualStyleBackColor = false;
            this.rbxMouthPollutionY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtAssessment2);
            this.groupBox11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox11.Location = new System.Drawing.Point(23, 378);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(354, 99);
            this.groupBox11.TabIndex = 10;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "備考";
            // 
            // txtAssessment2
            // 
            this.txtAssessment2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAssessment2.EnterKeyToTab = false;
            this.txtAssessment2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAssessment2.Location = new System.Drawing.Point(3, 16);
            this.txtAssessment2.MaxLength = 4000;
            this.txtAssessment2.Name = "txtAssessment2";
            this.txtAssessment2.Size = new System.Drawing.Size(348, 80);
            this.txtAssessment2.TabIndex = 1;
            this.txtAssessment2.Text = "";
            // 
            // xLabel93
            // 
            this.xLabel93.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel93.EdgeRounding = false;
            this.xLabel93.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel93.Location = new System.Drawing.Point(281, 342);
            this.xLabel93.Name = "xLabel93";
            this.xLabel93.Size = new System.Drawing.Size(48, 24);
            this.xLabel93.TabIndex = 999;
            this.xLabel93.Text = "BMI";
            this.xLabel93.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel92
            // 
            this.xLabel92.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel92.EdgeRounding = false;
            this.xLabel92.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel92.Location = new System.Drawing.Point(155, 342);
            this.xLabel92.Name = "xLabel92";
            this.xLabel92.Size = new System.Drawing.Size(48, 24);
            this.xLabel92.TabIndex = 999;
            this.xLabel92.Text = "体重";
            this.xLabel92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel90
            // 
            this.xLabel90.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel90.EdgeRounding = false;
            this.xLabel90.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel90.Location = new System.Drawing.Point(23, 342);
            this.xLabel90.Name = "xLabel90";
            this.xLabel90.Size = new System.Drawing.Size(48, 24);
            this.xLabel90.TabIndex = 999;
            this.xLabel90.Text = "身長";
            this.xLabel90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel89
            // 
            this.xLabel89.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel89.EdgeRounding = false;
            this.xLabel89.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel89.Location = new System.Drawing.Point(23, 313);
            this.xLabel89.Name = "xLabel89";
            this.xLabel89.Size = new System.Drawing.Size(99, 24);
            this.xLabel89.TabIndex = 999;
            this.xLabel89.Text = "体重減少/増加";
            this.xLabel89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFalseTeeth
            // 
            this.lblFalseTeeth.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblFalseTeeth.EdgeRounding = false;
            this.lblFalseTeeth.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblFalseTeeth.Location = new System.Drawing.Point(23, 284);
            this.lblFalseTeeth.Name = "lblFalseTeeth";
            this.lblFalseTeeth.Size = new System.Drawing.Size(99, 24);
            this.lblFalseTeeth.TabIndex = 999;
            this.lblFalseTeeth.Text = "義　　　歯";
            this.lblFalseTeeth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFalseTeeth.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblMouthPollution
            // 
            this.lblMouthPollution.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblMouthPollution.EdgeRounding = false;
            this.lblMouthPollution.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblMouthPollution.Location = new System.Drawing.Point(23, 255);
            this.lblMouthPollution.Name = "lblMouthPollution";
            this.lblMouthPollution.Size = new System.Drawing.Size(99, 24);
            this.lblMouthPollution.TabIndex = 999;
            this.lblMouthPollution.Text = "口腔内汚染";
            this.lblMouthPollution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMouthPollution.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboSubFood);
            this.groupBox4.Controls.Add(this.cboMainFood);
            this.groupBox4.Controls.Add(this.txtFoodLimit);
            this.groupBox4.Controls.Add(this.xLabel148);
            this.groupBox4.Controls.Add(this.txtIntake);
            this.groupBox4.Controls.Add(this.cboIntakeWay);
            this.groupBox4.Controls.Add(this.xLabel86);
            this.groupBox4.Controls.Add(this.txtDysphagia);
            this.groupBox4.Controls.Add(this.gbxDysphagia);
            this.groupBox4.Controls.Add(this.lblDysphagia);
            this.groupBox4.Controls.Add(this.txtAppetite);
            this.groupBox4.Controls.Add(this.gbxAppetite);
            this.groupBox4.Controls.Add(this.txtFoodDislike);
            this.groupBox4.Controls.Add(this.lblFoodDislike);
            this.groupBox4.Controls.Add(this.gbxFoodDislike);
            this.groupBox4.Controls.Add(this.xLabel80);
            this.groupBox4.Controls.Add(this.xLabel91);
            this.groupBox4.Controls.Add(this.lblAppetite);
            this.groupBox4.Controls.Add(this.lblFood_allergy);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(8, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(361, 240);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // cboSubFood
            // 
            this.cboSubFood.Location = new System.Drawing.Point(121, 54);
            this.cboSubFood.Name = "cboSubFood";
            this.cboSubFood.Size = new System.Drawing.Size(225, 21);
            this.cboSubFood.TabIndex = 1;
            // 
            // cboMainFood
            // 
            this.cboMainFood.Location = new System.Drawing.Point(121, 23);
            this.cboMainFood.Name = "cboMainFood";
            this.cboMainFood.Size = new System.Drawing.Size(224, 21);
            this.cboMainFood.TabIndex = 0;
            // 
            // txtFoodLimit
            // 
            this.txtFoodLimit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFoodLimit.Location = new System.Drawing.Point(121, 212);
            this.txtFoodLimit.Name = "txtFoodLimit";
            this.txtFoodLimit.Size = new System.Drawing.Size(224, 20);
            this.txtFoodLimit.TabIndex = 10;
            // 
            // xLabel148
            // 
            this.xLabel148.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel148.EdgeRounding = false;
            this.xLabel148.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel148.Location = new System.Drawing.Point(16, 210);
            this.xLabel148.Name = "xLabel148";
            this.xLabel148.Size = new System.Drawing.Size(99, 24);
            this.xLabel148.TabIndex = 999;
            this.xLabel148.Text = "食事制限";
            this.xLabel148.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIntake
            // 
            this.txtIntake.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtIntake.Location = new System.Drawing.Point(219, 182);
            this.txtIntake.Name = "txtIntake";
            this.txtIntake.Size = new System.Drawing.Size(127, 20);
            this.txtIntake.TabIndex = 9;
            // 
            // cboIntakeWay
            // 
            this.cboIntakeWay.Location = new System.Drawing.Point(121, 182);
            this.cboIntakeWay.Name = "cboIntakeWay";
            this.cboIntakeWay.Size = new System.Drawing.Size(96, 21);
            this.cboIntakeWay.TabIndex = 8;
            // 
            // xLabel86
            // 
            this.xLabel86.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel86.EdgeRounding = false;
            this.xLabel86.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel86.Location = new System.Drawing.Point(16, 180);
            this.xLabel86.Name = "xLabel86";
            this.xLabel86.Size = new System.Drawing.Size(99, 24);
            this.xLabel86.TabIndex = 999;
            this.xLabel86.Text = "摂取方法";
            this.xLabel86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDysphagia
            // 
            this.txtDysphagia.Enabled = false;
            this.txtDysphagia.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDysphagia.Location = new System.Drawing.Point(219, 151);
            this.txtDysphagia.Name = "txtDysphagia";
            this.txtDysphagia.Size = new System.Drawing.Size(127, 20);
            this.txtDysphagia.TabIndex = 7;
            // 
            // gbxDysphagia
            // 
            this.gbxDysphagia.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxDysphagia.Controls.Add(this.rbxDysphagiaN);
            this.gbxDysphagia.Controls.Add(this.rbxDysphagiaY);
            this.gbxDysphagia.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxDysphagia.Location = new System.Drawing.Point(123, 143);
            this.gbxDysphagia.Name = "gbxDysphagia";
            this.gbxDysphagia.Size = new System.Drawing.Size(94, 31);
            this.gbxDysphagia.TabIndex = 6;
            this.gbxDysphagia.TabStop = false;
            // 
            // rbxDysphagiaN
            // 
            this.rbxDysphagiaN.AutoSize = true;
            this.rbxDysphagiaN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxDysphagiaN.CheckedValue = "N";
            this.rbxDysphagiaN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxDysphagiaN.Location = new System.Drawing.Point(53, 10);
            this.rbxDysphagiaN.Name = "rbxDysphagiaN";
            this.rbxDysphagiaN.Size = new System.Drawing.Size(37, 17);
            this.rbxDysphagiaN.TabIndex = 2;
            this.rbxDysphagiaN.TabStop = true;
            this.rbxDysphagiaN.Text = "無";
            this.rbxDysphagiaN.UseVisualStyleBackColor = false;
            // 
            // rbxDysphagiaY
            // 
            this.rbxDysphagiaY.AutoSize = true;
            this.rbxDysphagiaY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxDysphagiaY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxDysphagiaY.Location = new System.Drawing.Point(6, 10);
            this.rbxDysphagiaY.Name = "rbxDysphagiaY";
            this.rbxDysphagiaY.Size = new System.Drawing.Size(37, 17);
            this.rbxDysphagiaY.TabIndex = 1;
            this.rbxDysphagiaY.TabStop = true;
            this.rbxDysphagiaY.Text = "有";
            this.rbxDysphagiaY.UseVisualStyleBackColor = false;
            this.rbxDysphagiaY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // lblDysphagia
            // 
            this.lblDysphagia.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDysphagia.EdgeRounding = false;
            this.lblDysphagia.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblDysphagia.Location = new System.Drawing.Point(16, 148);
            this.lblDysphagia.Name = "lblDysphagia";
            this.lblDysphagia.Size = new System.Drawing.Size(99, 24);
            this.lblDysphagia.TabIndex = 999;
            this.lblDysphagia.Text = "嚥下障害";
            this.lblDysphagia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDysphagia.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // txtAppetite
            // 
            this.txtAppetite.Enabled = false;
            this.txtAppetite.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAppetite.Location = new System.Drawing.Point(219, 120);
            this.txtAppetite.Name = "txtAppetite";
            this.txtAppetite.Size = new System.Drawing.Size(127, 20);
            this.txtAppetite.TabIndex = 5;
            // 
            // gbxAppetite
            // 
            this.gbxAppetite.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxAppetite.Controls.Add(this.rbxAppetiteN);
            this.gbxAppetite.Controls.Add(this.rbxAppetiteY);
            this.gbxAppetite.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxAppetite.Location = new System.Drawing.Point(123, 112);
            this.gbxAppetite.Name = "gbxAppetite";
            this.gbxAppetite.Size = new System.Drawing.Size(94, 31);
            this.gbxAppetite.TabIndex = 4;
            this.gbxAppetite.TabStop = false;
            // 
            // rbxAppetiteN
            // 
            this.rbxAppetiteN.AutoSize = true;
            this.rbxAppetiteN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxAppetiteN.CheckedValue = "N";
            this.rbxAppetiteN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxAppetiteN.Location = new System.Drawing.Point(53, 10);
            this.rbxAppetiteN.Name = "rbxAppetiteN";
            this.rbxAppetiteN.Size = new System.Drawing.Size(37, 17);
            this.rbxAppetiteN.TabIndex = 2;
            this.rbxAppetiteN.TabStop = true;
            this.rbxAppetiteN.Text = "無";
            this.rbxAppetiteN.UseVisualStyleBackColor = false;
            // 
            // rbxAppetiteY
            // 
            this.rbxAppetiteY.AutoSize = true;
            this.rbxAppetiteY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxAppetiteY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxAppetiteY.Location = new System.Drawing.Point(6, 10);
            this.rbxAppetiteY.Name = "rbxAppetiteY";
            this.rbxAppetiteY.Size = new System.Drawing.Size(37, 17);
            this.rbxAppetiteY.TabIndex = 1;
            this.rbxAppetiteY.TabStop = true;
            this.rbxAppetiteY.Text = "有";
            this.rbxAppetiteY.UseVisualStyleBackColor = false;
            this.rbxAppetiteY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // txtFoodDislike
            // 
            this.txtFoodDislike.Enabled = false;
            this.txtFoodDislike.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFoodDislike.Location = new System.Drawing.Point(219, 87);
            this.txtFoodDislike.Name = "txtFoodDislike";
            this.txtFoodDislike.Size = new System.Drawing.Size(127, 20);
            this.txtFoodDislike.TabIndex = 3;
            // 
            // lblFoodDislike
            // 
            this.lblFoodDislike.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblFoodDislike.EdgeRounding = false;
            this.lblFoodDislike.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblFoodDislike.Location = new System.Drawing.Point(16, 84);
            this.lblFoodDislike.Name = "lblFoodDislike";
            this.lblFoodDislike.Size = new System.Drawing.Size(99, 24);
            this.lblFoodDislike.TabIndex = 999;
            this.lblFoodDislike.Text = "偏　　　食";
            this.lblFoodDislike.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFoodDislike.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // gbxFoodDislike
            // 
            this.gbxFoodDislike.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxFoodDislike.Controls.Add(this.rbxFoodDislikeN);
            this.gbxFoodDislike.Controls.Add(this.rbxFoodDislikeY);
            this.gbxFoodDislike.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxFoodDislike.Location = new System.Drawing.Point(123, 79);
            this.gbxFoodDislike.Name = "gbxFoodDislike";
            this.gbxFoodDislike.Size = new System.Drawing.Size(94, 31);
            this.gbxFoodDislike.TabIndex = 2;
            this.gbxFoodDislike.TabStop = false;
            // 
            // rbxFoodDislikeN
            // 
            this.rbxFoodDislikeN.AutoSize = true;
            this.rbxFoodDislikeN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxFoodDislikeN.CheckedValue = "N";
            this.rbxFoodDislikeN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxFoodDislikeN.Location = new System.Drawing.Point(53, 10);
            this.rbxFoodDislikeN.Name = "rbxFoodDislikeN";
            this.rbxFoodDislikeN.Size = new System.Drawing.Size(37, 17);
            this.rbxFoodDislikeN.TabIndex = 2;
            this.rbxFoodDislikeN.TabStop = true;
            this.rbxFoodDislikeN.Text = "無";
            this.rbxFoodDislikeN.UseVisualStyleBackColor = false;
            // 
            // rbxFoodDislikeY
            // 
            this.rbxFoodDislikeY.AutoSize = true;
            this.rbxFoodDislikeY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxFoodDislikeY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxFoodDislikeY.Location = new System.Drawing.Point(6, 10);
            this.rbxFoodDislikeY.Name = "rbxFoodDislikeY";
            this.rbxFoodDislikeY.Size = new System.Drawing.Size(37, 17);
            this.rbxFoodDislikeY.TabIndex = 1;
            this.rbxFoodDislikeY.TabStop = true;
            this.rbxFoodDislikeY.Text = "有";
            this.rbxFoodDislikeY.UseVisualStyleBackColor = false;
            this.rbxFoodDislikeY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // xLabel80
            // 
            this.xLabel80.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel80.EdgeRounding = false;
            this.xLabel80.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel80.Location = new System.Drawing.Point(16, 52);
            this.xLabel80.Name = "xLabel80";
            this.xLabel80.Size = new System.Drawing.Size(99, 24);
            this.xLabel80.TabIndex = 999;
            this.xLabel80.Text = "副　　　食";
            this.xLabel80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel91
            // 
            this.xLabel91.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel91.EdgeRounding = false;
            this.xLabel91.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel91.Location = new System.Drawing.Point(16, 20);
            this.xLabel91.Name = "xLabel91";
            this.xLabel91.Size = new System.Drawing.Size(99, 24);
            this.xLabel91.TabIndex = 999;
            this.xLabel91.Text = "主　　　食";
            this.xLabel91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppetite
            // 
            this.lblAppetite.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblAppetite.EdgeRounding = false;
            this.lblAppetite.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblAppetite.Location = new System.Drawing.Point(16, 116);
            this.lblAppetite.Name = "lblAppetite";
            this.lblAppetite.Size = new System.Drawing.Size(99, 24);
            this.lblAppetite.TabIndex = 999;
            this.lblAppetite.Text = "食　　　欲";
            this.lblAppetite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppetite.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblFood_allergy
            // 
            this.lblFood_allergy.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblFood_allergy.EdgeRounding = false;
            this.lblFood_allergy.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblFood_allergy.Location = new System.Drawing.Point(16, 20);
            this.lblFood_allergy.Name = "lblFood_allergy";
            this.lblFood_allergy.Size = new System.Drawing.Size(99, 24);
            this.lblFood_allergy.TabIndex = 999;
            this.lblFood_allergy.Text = "食べ物アレルギー";
            this.lblFood_allergy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFood_allergy.Visible = false;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.xPanel9);
            this.tabPage5.Controls.Add(this.xPanel14);
            this.tabPage5.Location = new System.Drawing.Point(0, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(841, 538);
            this.tabPage5.TabIndex = 999;
            this.tabPage5.Title = "Ⅳ.活動・休息";
            // 
            // xPanel9
            // 
            this.xPanel9.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xPanel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel9.Controls.Add(this.groupBox14);
            this.xPanel9.Controls.Add(this.groupBox13);
            this.xPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel9.DrawBorder = true;
            this.xPanel9.Location = new System.Drawing.Point(438, 0);
            this.xPanel9.Name = "xPanel9";
            this.xPanel9.Size = new System.Drawing.Size(403, 538);
            this.xPanel9.TabIndex = 7;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.txtAssessment4);
            this.groupBox14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox14.Location = new System.Drawing.Point(12, 307);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(358, 131);
            this.groupBox14.TabIndex = 2;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "備考";
            // 
            // txtAssessment4
            // 
            this.txtAssessment4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAssessment4.EnterKeyToTab = false;
            this.txtAssessment4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAssessment4.Location = new System.Drawing.Point(3, 16);
            this.txtAssessment4.MaxLength = 4000;
            this.txtAssessment4.Name = "txtAssessment4";
            this.txtAssessment4.Size = new System.Drawing.Size(352, 112);
            this.txtAssessment4.TabIndex = 1;
            this.txtAssessment4.Text = "";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.txtSleepTime);
            this.groupBox13.Controls.Add(this.txtSleepEnd);
            this.groupBox13.Controls.Add(this.txtSleepStart);
            this.groupBox13.Controls.Add(this.gbxSleepEnough);
            this.groupBox13.Controls.Add(this.xLabel129);
            this.groupBox13.Controls.Add(this.txtSleepEtc);
            this.groupBox13.Controls.Add(this.xLabel122);
            this.groupBox13.Controls.Add(this.txtSleepLess);
            this.groupBox13.Controls.Add(this.cbxSleepEtc);
            this.groupBox13.Controls.Add(this.cbxTeethGrinding);
            this.groupBox13.Controls.Add(this.cbxSleepTalk);
            this.groupBox13.Controls.Add(this.cbxSnoring);
            this.groupBox13.Controls.Add(this.xLabel121);
            this.groupBox13.Controls.Add(this.txtSleepEnough);
            this.groupBox13.Controls.Add(this.lblSleepEnough);
            this.groupBox13.Controls.Add(this.xLabel124);
            this.groupBox13.Controls.Add(this.xLabel125);
            this.groupBox13.Controls.Add(this.xLabel126);
            this.groupBox13.Controls.Add(this.xLabel127);
            this.groupBox13.Controls.Add(this.xLabel128);
            this.groupBox13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox13.ForeColor = System.Drawing.Color.Black;
            this.groupBox13.Location = new System.Drawing.Point(12, 15);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(358, 243);
            this.groupBox13.TabIndex = 1;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "休息";
            // 
            // txtSleepTime
            // 
            this.txtSleepTime.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtSleepTime.Location = new System.Drawing.Point(83, 25);
            this.txtSleepTime.Name = "txtSleepTime";
            this.txtSleepTime.Size = new System.Drawing.Size(58, 20);
            this.txtSleepTime.TabIndex = 1;
            this.txtSleepTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSleepEnd
            // 
            this.txtSleepEnd.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtSleepEnd.Location = new System.Drawing.Point(259, 55);
            this.txtSleepEnd.Name = "txtSleepEnd";
            this.txtSleepEnd.Size = new System.Drawing.Size(45, 20);
            this.txtSleepEnd.TabIndex = 3;
            this.txtSleepEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSleepStart
            // 
            this.txtSleepStart.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtSleepStart.Location = new System.Drawing.Point(83, 55);
            this.txtSleepStart.Name = "txtSleepStart";
            this.txtSleepStart.Size = new System.Drawing.Size(58, 20);
            this.txtSleepStart.TabIndex = 2;
            this.txtSleepStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbxSleepEnough
            // 
            this.gbxSleepEnough.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxSleepEnough.Controls.Add(this.rbxSleepEnoughN);
            this.gbxSleepEnough.Controls.Add(this.rbxSleepEnoughY);
            this.gbxSleepEnough.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxSleepEnough.Location = new System.Drawing.Point(111, 84);
            this.gbxSleepEnough.Name = "gbxSleepEnough";
            this.gbxSleepEnough.Size = new System.Drawing.Size(119, 31);
            this.gbxSleepEnough.TabIndex = 4;
            this.gbxSleepEnough.TabStop = false;
            // 
            // rbxSleepEnoughN
            // 
            this.rbxSleepEnoughN.AutoSize = true;
            this.rbxSleepEnoughN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxSleepEnoughN.CheckedValue = "N";
            this.rbxSleepEnoughN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxSleepEnoughN.Location = new System.Drawing.Point(57, 10);
            this.rbxSleepEnoughN.Name = "rbxSleepEnoughN";
            this.rbxSleepEnoughN.Size = new System.Drawing.Size(56, 17);
            this.rbxSleepEnoughN.TabIndex = 2;
            this.rbxSleepEnoughN.TabStop = true;
            this.rbxSleepEnoughN.Text = "いいえ";
            this.rbxSleepEnoughN.UseVisualStyleBackColor = false;
            this.rbxSleepEnoughN.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxSleepEnoughY
            // 
            this.rbxSleepEnoughY.AutoSize = true;
            this.rbxSleepEnoughY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxSleepEnoughY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxSleepEnoughY.Location = new System.Drawing.Point(6, 10);
            this.rbxSleepEnoughY.Name = "rbxSleepEnoughY";
            this.rbxSleepEnoughY.Size = new System.Drawing.Size(46, 17);
            this.rbxSleepEnoughY.TabIndex = 1;
            this.rbxSleepEnoughY.TabStop = true;
            this.rbxSleepEnoughY.Text = "はい";
            this.rbxSleepEnoughY.UseVisualStyleBackColor = false;
            // 
            // xLabel129
            // 
            this.xLabel129.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel129.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel129.Location = new System.Drawing.Point(300, 55);
            this.xLabel129.Name = "xLabel129";
            this.xLabel129.Size = new System.Drawing.Size(40, 24);
            this.xLabel129.TabIndex = 999;
            this.xLabel129.Text = "時頃";
            this.xLabel129.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSleepEtc
            // 
            this.txtSleepEtc.Enabled = false;
            this.txtSleepEtc.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSleepEtc.Location = new System.Drawing.Point(178, 212);
            this.txtSleepEtc.Name = "txtSleepEtc";
            this.txtSleepEtc.Size = new System.Drawing.Size(159, 20);
            this.txtSleepEtc.TabIndex = 11;
            // 
            // xLabel122
            // 
            this.xLabel122.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel122.EdgeRounding = false;
            this.xLabel122.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel122.Location = new System.Drawing.Point(14, 193);
            this.xLabel122.Name = "xLabel122";
            this.xLabel122.Size = new System.Drawing.Size(96, 38);
            this.xLabel122.TabIndex = 999;
            this.xLabel122.Text = "眠っているときの様子";
            this.xLabel122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSleepLess
            // 
            this.txtSleepLess.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSleepLess.Location = new System.Drawing.Point(112, 145);
            this.txtSleepLess.Multiline = true;
            this.txtSleepLess.Name = "txtSleepLess";
            this.txtSleepLess.Size = new System.Drawing.Size(225, 38);
            this.txtSleepLess.TabIndex = 6;
            // 
            // cbxSleepEtc
            // 
            this.cbxSleepEtc.AutoSize = true;
            this.cbxSleepEtc.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxSleepEtc.Location = new System.Drawing.Point(115, 213);
            this.cbxSleepEtc.Name = "cbxSleepEtc";
            this.cbxSleepEtc.Size = new System.Drawing.Size(57, 17);
            this.cbxSleepEtc.TabIndex = 10;
            this.cbxSleepEtc.Text = "その他";
            this.cbxSleepEtc.UseVisualStyleBackColor = false;
            this.cbxSleepEtc.CheckedChanged += new System.EventHandler(this.cbxCheckedChanged);
            // 
            // cbxTeethGrinding
            // 
            this.cbxTeethGrinding.AutoSize = true;
            this.cbxTeethGrinding.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxTeethGrinding.Location = new System.Drawing.Point(277, 193);
            this.cbxTeethGrinding.Name = "cbxTeethGrinding";
            this.cbxTeethGrinding.Size = new System.Drawing.Size(63, 17);
            this.cbxTeethGrinding.TabIndex = 9;
            this.cbxTeethGrinding.Text = "歯ぎしり";
            this.cbxTeethGrinding.UseVisualStyleBackColor = false;
            // 
            // cbxSleepTalk
            // 
            this.cbxSleepTalk.AutoSize = true;
            this.cbxSleepTalk.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxSleepTalk.Location = new System.Drawing.Point(199, 193);
            this.cbxSleepTalk.Name = "cbxSleepTalk";
            this.cbxSleepTalk.Size = new System.Drawing.Size(49, 17);
            this.cbxSleepTalk.TabIndex = 8;
            this.cbxSleepTalk.Text = "寝言";
            this.cbxSleepTalk.UseVisualStyleBackColor = false;
            // 
            // cbxSnoring
            // 
            this.cbxSnoring.AutoSize = true;
            this.cbxSnoring.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxSnoring.Location = new System.Drawing.Point(115, 193);
            this.cbxSnoring.Name = "cbxSnoring";
            this.cbxSnoring.Size = new System.Drawing.Size(55, 17);
            this.cbxSnoring.TabIndex = 7;
            this.cbxSnoring.Text = "いびき";
            this.cbxSnoring.UseVisualStyleBackColor = false;
            // 
            // xLabel121
            // 
            this.xLabel121.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel121.EdgeRounding = false;
            this.xLabel121.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel121.Location = new System.Drawing.Point(14, 145);
            this.xLabel121.Name = "xLabel121";
            this.xLabel121.Size = new System.Drawing.Size(96, 38);
            this.xLabel121.TabIndex = 999;
            this.xLabel121.Text = "眠れないときの対処方法";
            this.xLabel121.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSleepEnough
            // 
            this.txtSleepEnough.Enabled = false;
            this.txtSleepEnough.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSleepEnough.Location = new System.Drawing.Point(111, 115);
            this.txtSleepEnough.Name = "txtSleepEnough";
            this.txtSleepEnough.Size = new System.Drawing.Size(225, 20);
            this.txtSleepEnough.TabIndex = 5;
            // 
            // lblSleepEnough
            // 
            this.lblSleepEnough.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSleepEnough.EdgeRounding = false;
            this.lblSleepEnough.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblSleepEnough.Location = new System.Drawing.Point(14, 89);
            this.lblSleepEnough.Name = "lblSleepEnough";
            this.lblSleepEnough.Size = new System.Drawing.Size(95, 46);
            this.lblSleepEnough.TabIndex = 999;
            this.lblSleepEnough.Text = "睡眠は十分\nとれていますか？";
            this.lblSleepEnough.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSleepEnough.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // xLabel124
            // 
            this.xLabel124.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel124.EdgeRounding = false;
            this.xLabel124.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel124.Location = new System.Drawing.Point(193, 53);
            this.xLabel124.Name = "xLabel124";
            this.xLabel124.Size = new System.Drawing.Size(60, 24);
            this.xLabel124.TabIndex = 999;
            this.xLabel124.Text = "起床時間";
            this.xLabel124.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel125
            // 
            this.xLabel125.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel125.EdgeRounding = false;
            this.xLabel125.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel125.Location = new System.Drawing.Point(15, 22);
            this.xLabel125.Name = "xLabel125";
            this.xLabel125.Size = new System.Drawing.Size(62, 24);
            this.xLabel125.TabIndex = 999;
            this.xLabel125.Text = "睡眠時間";
            this.xLabel125.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel126
            // 
            this.xLabel126.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel126.EdgeRounding = false;
            this.xLabel126.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel126.Location = new System.Drawing.Point(15, 53);
            this.xLabel126.Name = "xLabel126";
            this.xLabel126.Size = new System.Drawing.Size(62, 24);
            this.xLabel126.TabIndex = 999;
            this.xLabel126.Text = "就寝時間";
            this.xLabel126.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel127
            // 
            this.xLabel127.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel127.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel127.Location = new System.Drawing.Point(140, 26);
            this.xLabel127.Name = "xLabel127";
            this.xLabel127.Size = new System.Drawing.Size(54, 24);
            this.xLabel127.TabIndex = 999;
            this.xLabel127.Text = "時間/日";
            this.xLabel127.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel128
            // 
            this.xLabel128.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel128.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel128.Location = new System.Drawing.Point(140, 55);
            this.xLabel128.Name = "xLabel128";
            this.xLabel128.Size = new System.Drawing.Size(40, 24);
            this.xLabel128.TabIndex = 999;
            this.xLabel128.Text = "時頃";
            this.xLabel128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel14
            // 
            this.xPanel14.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xPanel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel14.Controls.Add(this.groupBox18);
            this.xPanel14.Controls.Add(this.xLabel149);
            this.xPanel14.Controls.Add(this.xLabel150);
            this.xPanel14.Controls.Add(this.groupBox12);
            this.xPanel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel14.DrawBorder = true;
            this.xPanel14.Location = new System.Drawing.Point(0, 0);
            this.xPanel14.Name = "xPanel14";
            this.xPanel14.Size = new System.Drawing.Size(438, 538);
            this.xPanel14.TabIndex = 6;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.txtCareOffice);
            this.groupBox18.Controls.Add(this.txtService);
            this.groupBox18.Controls.Add(this.xLabel156);
            this.groupBox18.Controls.Add(this.xLabel157);
            this.groupBox18.Controls.Add(this.lblNeedSupport);
            this.groupBox18.Controls.Add(this.lblNeedCare);
            this.groupBox18.Controls.Add(this.gbxNeedSupport);
            this.groupBox18.Controls.Add(this.gbxNeedCare);
            this.groupBox18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox18.ForeColor = System.Drawing.Color.Black;
            this.groupBox18.Location = new System.Drawing.Point(4, 298);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(428, 140);
            this.groupBox18.TabIndex = 2;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "活動";
            // 
            // txtCareOffice
            // 
            this.txtCareOffice.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtCareOffice.Location = new System.Drawing.Point(141, 110);
            this.txtCareOffice.Name = "txtCareOffice";
            this.txtCareOffice.Size = new System.Drawing.Size(278, 20);
            this.txtCareOffice.TabIndex = 4;
            // 
            // txtService
            // 
            this.txtService.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtService.Location = new System.Drawing.Point(141, 81);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(278, 20);
            this.txtService.TabIndex = 3;
            // 
            // xLabel156
            // 
            this.xLabel156.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel156.EdgeRounding = false;
            this.xLabel156.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel156.Location = new System.Drawing.Point(6, 108);
            this.xLabel156.Name = "xLabel156";
            this.xLabel156.Size = new System.Drawing.Size(128, 24);
            this.xLabel156.TabIndex = 999;
            this.xLabel156.Text = "居宅介護支援事務所";
            this.xLabel156.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel157
            // 
            this.xLabel157.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel157.EdgeRounding = false;
            this.xLabel157.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel157.Location = new System.Drawing.Point(6, 79);
            this.xLabel157.Name = "xLabel157";
            this.xLabel157.Size = new System.Drawing.Size(128, 24);
            this.xLabel157.TabIndex = 999;
            this.xLabel157.Text = "受けているサービス";
            this.xLabel157.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNeedSupport
            // 
            this.lblNeedSupport.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNeedSupport.EdgeRounding = false;
            this.lblNeedSupport.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNeedSupport.Location = new System.Drawing.Point(6, 50);
            this.lblNeedSupport.Name = "lblNeedSupport";
            this.lblNeedSupport.Size = new System.Drawing.Size(128, 24);
            this.lblNeedSupport.TabIndex = 999;
            this.lblNeedSupport.Text = "要　支　援";
            this.lblNeedSupport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNeedSupport.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblNeedCare
            // 
            this.lblNeedCare.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNeedCare.EdgeRounding = false;
            this.lblNeedCare.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNeedCare.Location = new System.Drawing.Point(6, 20);
            this.lblNeedCare.Name = "lblNeedCare";
            this.lblNeedCare.Size = new System.Drawing.Size(128, 24);
            this.lblNeedCare.TabIndex = 999;
            this.lblNeedCare.Text = "要　介　護";
            this.lblNeedCare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNeedCare.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // gbxNeedSupport
            // 
            this.gbxNeedSupport.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxNeedSupport.Controls.Add(this.rbxActivitySupport2);
            this.gbxNeedSupport.Controls.Add(this.rbxActivitySupport1);
            this.gbxNeedSupport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxNeedSupport.Location = new System.Drawing.Point(141, 44);
            this.gbxNeedSupport.Name = "gbxNeedSupport";
            this.gbxNeedSupport.Size = new System.Drawing.Size(82, 31);
            this.gbxNeedSupport.TabIndex = 2;
            this.gbxNeedSupport.TabStop = false;
            // 
            // rbxActivitySupport2
            // 
            this.rbxActivitySupport2.AutoSize = true;
            this.rbxActivitySupport2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxActivitySupport2.CheckedValue = "2";
            this.rbxActivitySupport2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxActivitySupport2.Location = new System.Drawing.Point(48, 10);
            this.rbxActivitySupport2.Name = "rbxActivitySupport2";
            this.rbxActivitySupport2.Size = new System.Drawing.Size(31, 17);
            this.rbxActivitySupport2.TabIndex = 2;
            this.rbxActivitySupport2.TabStop = true;
            this.rbxActivitySupport2.Text = "2";
            this.rbxActivitySupport2.UseVisualStyleBackColor = false;
            // 
            // rbxActivitySupport1
            // 
            this.rbxActivitySupport1.AutoSize = true;
            this.rbxActivitySupport1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxActivitySupport1.CheckedValue = "1";
            this.rbxActivitySupport1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxActivitySupport1.Location = new System.Drawing.Point(6, 10);
            this.rbxActivitySupport1.Name = "rbxActivitySupport1";
            this.rbxActivitySupport1.Size = new System.Drawing.Size(31, 17);
            this.rbxActivitySupport1.TabIndex = 1;
            this.rbxActivitySupport1.TabStop = true;
            this.rbxActivitySupport1.Text = "1";
            this.rbxActivitySupport1.UseVisualStyleBackColor = false;
            // 
            // gbxNeedCare
            // 
            this.gbxNeedCare.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxNeedCare.Controls.Add(this.rbxActivityCare5);
            this.gbxNeedCare.Controls.Add(this.rbxActivityCare4);
            this.gbxNeedCare.Controls.Add(this.rbxActivityCare3);
            this.gbxNeedCare.Controls.Add(this.rbxActivityCare2);
            this.gbxNeedCare.Controls.Add(this.rbxActivityCare1);
            this.gbxNeedCare.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxNeedCare.Location = new System.Drawing.Point(141, 14);
            this.gbxNeedCare.Name = "gbxNeedCare";
            this.gbxNeedCare.Size = new System.Drawing.Size(218, 31);
            this.gbxNeedCare.TabIndex = 1;
            this.gbxNeedCare.TabStop = false;
            // 
            // rbxActivityCare5
            // 
            this.rbxActivityCare5.AutoSize = true;
            this.rbxActivityCare5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxActivityCare5.CheckedValue = "5";
            this.rbxActivityCare5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxActivityCare5.Location = new System.Drawing.Point(182, 10);
            this.rbxActivityCare5.Name = "rbxActivityCare5";
            this.rbxActivityCare5.Size = new System.Drawing.Size(31, 17);
            this.rbxActivityCare5.TabIndex = 5;
            this.rbxActivityCare5.TabStop = true;
            this.rbxActivityCare5.Text = "5";
            this.rbxActivityCare5.UseVisualStyleBackColor = false;
            // 
            // rbxActivityCare4
            // 
            this.rbxActivityCare4.AutoSize = true;
            this.rbxActivityCare4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxActivityCare4.CheckedValue = "4";
            this.rbxActivityCare4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxActivityCare4.Location = new System.Drawing.Point(138, 10);
            this.rbxActivityCare4.Name = "rbxActivityCare4";
            this.rbxActivityCare4.Size = new System.Drawing.Size(31, 17);
            this.rbxActivityCare4.TabIndex = 4;
            this.rbxActivityCare4.TabStop = true;
            this.rbxActivityCare4.Text = "4";
            this.rbxActivityCare4.UseVisualStyleBackColor = false;
            // 
            // rbxActivityCare3
            // 
            this.rbxActivityCare3.AutoSize = true;
            this.rbxActivityCare3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxActivityCare3.CheckedValue = "3";
            this.rbxActivityCare3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxActivityCare3.Location = new System.Drawing.Point(94, 10);
            this.rbxActivityCare3.Name = "rbxActivityCare3";
            this.rbxActivityCare3.Size = new System.Drawing.Size(31, 17);
            this.rbxActivityCare3.TabIndex = 3;
            this.rbxActivityCare3.TabStop = true;
            this.rbxActivityCare3.Text = "3";
            this.rbxActivityCare3.UseVisualStyleBackColor = false;
            // 
            // rbxActivityCare2
            // 
            this.rbxActivityCare2.AutoSize = true;
            this.rbxActivityCare2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxActivityCare2.CheckedValue = "2";
            this.rbxActivityCare2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxActivityCare2.Location = new System.Drawing.Point(50, 10);
            this.rbxActivityCare2.Name = "rbxActivityCare2";
            this.rbxActivityCare2.Size = new System.Drawing.Size(31, 17);
            this.rbxActivityCare2.TabIndex = 2;
            this.rbxActivityCare2.TabStop = true;
            this.rbxActivityCare2.Text = "2";
            this.rbxActivityCare2.UseVisualStyleBackColor = false;
            // 
            // rbxActivityCare1
            // 
            this.rbxActivityCare1.AutoSize = true;
            this.rbxActivityCare1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxActivityCare1.CheckedValue = "1";
            this.rbxActivityCare1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxActivityCare1.Location = new System.Drawing.Point(6, 10);
            this.rbxActivityCare1.Name = "rbxActivityCare1";
            this.rbxActivityCare1.Size = new System.Drawing.Size(31, 17);
            this.rbxActivityCare1.TabIndex = 1;
            this.rbxActivityCare1.TabStop = true;
            this.rbxActivityCare1.Text = "1";
            this.rbxActivityCare1.UseVisualStyleBackColor = false;
            // 
            // xLabel149
            // 
            this.xLabel149.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel149.EdgeRounding = false;
            this.xLabel149.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel149.Location = new System.Drawing.Point(152, 9);
            this.xLabel149.Name = "xLabel149";
            this.xLabel149.Size = new System.Drawing.Size(82, 24);
            this.xLabel149.TabIndex = 999;
            this.xLabel149.Text = "状　　態";
            this.xLabel149.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel150
            // 
            this.xLabel150.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel150.EdgeRounding = false;
            this.xLabel150.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel150.Location = new System.Drawing.Point(315, 9);
            this.xLabel150.Name = "xLabel150";
            this.xLabel150.Size = new System.Drawing.Size(82, 24);
            this.xLabel150.TabIndex = 999;
            this.xLabel150.Text = "ケ　　ア";
            this.xLabel150.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.txtWalk_ADL);
            this.groupBox12.Controls.Add(this.cboWalk_ADL);
            this.groupBox12.Controls.Add(this.xLabel120);
            this.groupBox12.Controls.Add(this.txtWheelchair_ADL);
            this.groupBox12.Controls.Add(this.cboWheelchair_ADL);
            this.groupBox12.Controls.Add(this.xLabel119);
            this.groupBox12.Controls.Add(this.txtBoard_ADL);
            this.groupBox12.Controls.Add(this.cboBoard_ADL);
            this.groupBox12.Controls.Add(this.xLabel118);
            this.groupBox12.Controls.Add(this.txtStruggle_ADL);
            this.groupBox12.Controls.Add(this.cboStruggle_ADL);
            this.groupBox12.Controls.Add(this.xLabel117);
            this.groupBox12.Controls.Add(this.txtExcretion_ADL);
            this.groupBox12.Controls.Add(this.cboExcretion_ADL);
            this.groupBox12.Controls.Add(this.xLabel115);
            this.groupBox12.Controls.Add(this.txtWash_ADL);
            this.groupBox12.Controls.Add(this.cboWash_ADL);
            this.groupBox12.Controls.Add(this.xLabel114);
            this.groupBox12.Controls.Add(this.txtCloth_ADL);
            this.groupBox12.Controls.Add(this.cboCloth_ADL);
            this.groupBox12.Controls.Add(this.xLabel113);
            this.groupBox12.Controls.Add(this.txtBath_ADL);
            this.groupBox12.Controls.Add(this.cboBath_ADL);
            this.groupBox12.Controls.Add(this.xLabel112);
            this.groupBox12.Controls.Add(this.txtFood_ADL);
            this.groupBox12.Controls.Add(this.cboFood_ADL);
            this.groupBox12.Controls.Add(this.xLabel116);
            this.groupBox12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox12.ForeColor = System.Drawing.Color.Black;
            this.groupBox12.Location = new System.Drawing.Point(3, 18);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(428, 278);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "活動";
            // 
            // txtWalk_ADL
            // 
            this.txtWalk_ADL.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtWalk_ADL.Location = new System.Drawing.Point(288, 243);
            this.txtWalk_ADL.Name = "txtWalk_ADL";
            this.txtWalk_ADL.Size = new System.Drawing.Size(134, 20);
            this.txtWalk_ADL.TabIndex = 18;
            // 
            // cboWalk_ADL
            // 
            this.cboWalk_ADL.Location = new System.Drawing.Point(112, 242);
            this.cboWalk_ADL.Name = "cboWalk_ADL";
            this.cboWalk_ADL.Size = new System.Drawing.Size(171, 21);
            this.cboWalk_ADL.TabIndex = 17;
            // 
            // xLabel120
            // 
            this.xLabel120.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel120.EdgeRounding = false;
            this.xLabel120.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel120.Location = new System.Drawing.Point(6, 243);
            this.xLabel120.Name = "xLabel120";
            this.xLabel120.Size = new System.Drawing.Size(99, 24);
            this.xLabel120.TabIndex = 999;
            this.xLabel120.Text = "歩　　　行";
            this.xLabel120.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWheelchair_ADL
            // 
            this.txtWheelchair_ADL.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtWheelchair_ADL.Location = new System.Drawing.Point(288, 213);
            this.txtWheelchair_ADL.Name = "txtWheelchair_ADL";
            this.txtWheelchair_ADL.Size = new System.Drawing.Size(134, 20);
            this.txtWheelchair_ADL.TabIndex = 16;
            // 
            // cboWheelchair_ADL
            // 
            this.cboWheelchair_ADL.Location = new System.Drawing.Point(112, 212);
            this.cboWheelchair_ADL.Name = "cboWheelchair_ADL";
            this.cboWheelchair_ADL.Size = new System.Drawing.Size(171, 21);
            this.cboWheelchair_ADL.TabIndex = 15;
            // 
            // xLabel119
            // 
            this.xLabel119.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel119.EdgeRounding = false;
            this.xLabel119.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel119.Location = new System.Drawing.Point(6, 213);
            this.xLabel119.Name = "xLabel119";
            this.xLabel119.Size = new System.Drawing.Size(99, 24);
            this.xLabel119.TabIndex = 999;
            this.xLabel119.Text = "車椅子への移動";
            this.xLabel119.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoard_ADL
            // 
            this.txtBoard_ADL.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtBoard_ADL.Location = new System.Drawing.Point(288, 183);
            this.txtBoard_ADL.Name = "txtBoard_ADL";
            this.txtBoard_ADL.Size = new System.Drawing.Size(134, 20);
            this.txtBoard_ADL.TabIndex = 14;
            // 
            // cboBoard_ADL
            // 
            this.cboBoard_ADL.Location = new System.Drawing.Point(112, 182);
            this.cboBoard_ADL.Name = "cboBoard_ADL";
            this.cboBoard_ADL.Size = new System.Drawing.Size(171, 21);
            this.cboBoard_ADL.TabIndex = 13;
            // 
            // xLabel118
            // 
            this.xLabel118.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel118.EdgeRounding = false;
            this.xLabel118.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel118.Location = new System.Drawing.Point(6, 183);
            this.xLabel118.Name = "xLabel118";
            this.xLabel118.Size = new System.Drawing.Size(99, 24);
            this.xLabel118.TabIndex = 999;
            this.xLabel118.Text = "移乗方法";
            this.xLabel118.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStruggle_ADL
            // 
            this.txtStruggle_ADL.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtStruggle_ADL.Location = new System.Drawing.Point(288, 155);
            this.txtStruggle_ADL.Name = "txtStruggle_ADL";
            this.txtStruggle_ADL.Size = new System.Drawing.Size(134, 20);
            this.txtStruggle_ADL.TabIndex = 12;
            // 
            // cboStruggle_ADL
            // 
            this.cboStruggle_ADL.Location = new System.Drawing.Point(112, 154);
            this.cboStruggle_ADL.Name = "cboStruggle_ADL";
            this.cboStruggle_ADL.Size = new System.Drawing.Size(171, 21);
            this.cboStruggle_ADL.TabIndex = 11;
            // 
            // xLabel117
            // 
            this.xLabel117.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel117.EdgeRounding = false;
            this.xLabel117.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel117.Location = new System.Drawing.Point(6, 155);
            this.xLabel117.Name = "xLabel117";
            this.xLabel117.Size = new System.Drawing.Size(99, 24);
            this.xLabel117.TabIndex = 999;
            this.xLabel117.Text = "寝　返　し";
            this.xLabel117.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtExcretion_ADL
            // 
            this.txtExcretion_ADL.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtExcretion_ADL.Location = new System.Drawing.Point(288, 129);
            this.txtExcretion_ADL.Name = "txtExcretion_ADL";
            this.txtExcretion_ADL.Size = new System.Drawing.Size(134, 20);
            this.txtExcretion_ADL.TabIndex = 10;
            // 
            // cboExcretion_ADL
            // 
            this.cboExcretion_ADL.Location = new System.Drawing.Point(112, 128);
            this.cboExcretion_ADL.Name = "cboExcretion_ADL";
            this.cboExcretion_ADL.Size = new System.Drawing.Size(171, 21);
            this.cboExcretion_ADL.TabIndex = 9;
            // 
            // xLabel115
            // 
            this.xLabel115.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel115.EdgeRounding = false;
            this.xLabel115.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel115.Location = new System.Drawing.Point(6, 129);
            this.xLabel115.Name = "xLabel115";
            this.xLabel115.Size = new System.Drawing.Size(99, 24);
            this.xLabel115.TabIndex = 999;
            this.xLabel115.Text = "排　　　泄";
            this.xLabel115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWash_ADL
            // 
            this.txtWash_ADL.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtWash_ADL.Location = new System.Drawing.Point(288, 102);
            this.txtWash_ADL.Name = "txtWash_ADL";
            this.txtWash_ADL.Size = new System.Drawing.Size(134, 20);
            this.txtWash_ADL.TabIndex = 8;
            // 
            // cboWash_ADL
            // 
            this.cboWash_ADL.Location = new System.Drawing.Point(112, 101);
            this.cboWash_ADL.Name = "cboWash_ADL";
            this.cboWash_ADL.Size = new System.Drawing.Size(171, 21);
            this.cboWash_ADL.TabIndex = 7;
            // 
            // xLabel114
            // 
            this.xLabel114.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel114.EdgeRounding = false;
            this.xLabel114.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel114.Location = new System.Drawing.Point(6, 102);
            this.xLabel114.Name = "xLabel114";
            this.xLabel114.Size = new System.Drawing.Size(99, 24);
            this.xLabel114.TabIndex = 999;
            this.xLabel114.Text = "整　　　容";
            this.xLabel114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCloth_ADL
            // 
            this.txtCloth_ADL.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtCloth_ADL.Location = new System.Drawing.Point(288, 76);
            this.txtCloth_ADL.Name = "txtCloth_ADL";
            this.txtCloth_ADL.Size = new System.Drawing.Size(134, 20);
            this.txtCloth_ADL.TabIndex = 6;
            // 
            // cboCloth_ADL
            // 
            this.cboCloth_ADL.Location = new System.Drawing.Point(112, 75);
            this.cboCloth_ADL.Name = "cboCloth_ADL";
            this.cboCloth_ADL.Size = new System.Drawing.Size(171, 21);
            this.cboCloth_ADL.TabIndex = 5;
            // 
            // xLabel113
            // 
            this.xLabel113.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel113.EdgeRounding = false;
            this.xLabel113.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel113.Location = new System.Drawing.Point(6, 76);
            this.xLabel113.Name = "xLabel113";
            this.xLabel113.Size = new System.Drawing.Size(99, 24);
            this.xLabel113.TabIndex = 999;
            this.xLabel113.Text = "衣類着脱";
            this.xLabel113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBath_ADL
            // 
            this.txtBath_ADL.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtBath_ADL.Location = new System.Drawing.Point(288, 49);
            this.txtBath_ADL.Name = "txtBath_ADL";
            this.txtBath_ADL.Size = new System.Drawing.Size(134, 20);
            this.txtBath_ADL.TabIndex = 4;
            // 
            // cboBath_ADL
            // 
            this.cboBath_ADL.Location = new System.Drawing.Point(112, 48);
            this.cboBath_ADL.Name = "cboBath_ADL";
            this.cboBath_ADL.Size = new System.Drawing.Size(171, 21);
            this.cboBath_ADL.TabIndex = 3;
            // 
            // xLabel112
            // 
            this.xLabel112.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel112.EdgeRounding = false;
            this.xLabel112.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel112.Location = new System.Drawing.Point(6, 49);
            this.xLabel112.Name = "xLabel112";
            this.xLabel112.Size = new System.Drawing.Size(99, 24);
            this.xLabel112.TabIndex = 999;
            this.xLabel112.Text = "入　　　浴";
            this.xLabel112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFood_ADL
            // 
            this.txtFood_ADL.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFood_ADL.Location = new System.Drawing.Point(288, 22);
            this.txtFood_ADL.Name = "txtFood_ADL";
            this.txtFood_ADL.Size = new System.Drawing.Size(134, 20);
            this.txtFood_ADL.TabIndex = 2;
            // 
            // cboFood_ADL
            // 
            this.cboFood_ADL.Location = new System.Drawing.Point(112, 21);
            this.cboFood_ADL.Name = "cboFood_ADL";
            this.cboFood_ADL.Size = new System.Drawing.Size(171, 21);
            this.cboFood_ADL.TabIndex = 1;
            // 
            // xLabel116
            // 
            this.xLabel116.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel116.EdgeRounding = false;
            this.xLabel116.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel116.Location = new System.Drawing.Point(6, 22);
            this.xLabel116.Name = "xLabel116";
            this.xLabel116.Size = new System.Drawing.Size(99, 24);
            this.xLabel116.TabIndex = 999;
            this.xLabel116.Text = "食　　　事";
            this.xLabel116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pnlPerceptionRight);
            this.tabPage3.Controls.Add(this.pnlPerceptionLeft);
            this.tabPage3.Controls.Add(this.splitter5);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(841, 538);
            this.tabPage3.TabIndex = 999;
            this.tabPage3.Title = "Ⅴ・Ⅵ.認知・知覚";
            // 
            // pnlPerceptionRight
            // 
            this.pnlPerceptionRight.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlPerceptionRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPerceptionRight.Controls.Add(this.lblMovement);
            this.pnlPerceptionRight.Controls.Add(this.groupBox20);
            this.pnlPerceptionRight.Controls.Add(this.gbxPerception);
            this.pnlPerceptionRight.Controls.Add(this.gbxFear);
            this.pnlPerceptionRight.Controls.Add(this.lblFear);
            this.pnlPerceptionRight.Controls.Add(this.txtFear);
            this.pnlPerceptionRight.Controls.Add(this.gbxWorry);
            this.pnlPerceptionRight.Controls.Add(this.lblWorry);
            this.pnlPerceptionRight.Controls.Add(this.txtWorry);
            this.pnlPerceptionRight.Controls.Add(this.gbxMovement);
            this.pnlPerceptionRight.Controls.Add(this.lblPerception);
            this.pnlPerceptionRight.Controls.Add(this.gbxPain);
            this.pnlPerceptionRight.Controls.Add(this.txtPerception);
            this.pnlPerceptionRight.Controls.Add(this.lblPain);
            this.pnlPerceptionRight.Controls.Add(this.txtPain);
            this.pnlPerceptionRight.Controls.Add(this.gbxStagger);
            this.pnlPerceptionRight.Controls.Add(this.gbxDizzy);
            this.pnlPerceptionRight.Controls.Add(this.txtStagger);
            this.pnlPerceptionRight.Controls.Add(this.txtDizzy);
            this.pnlPerceptionRight.Controls.Add(this.lblStagger);
            this.pnlPerceptionRight.Controls.Add(this.lblDizzy);
            this.pnlPerceptionRight.Controls.Add(this.gbxMovementDetail);
            this.pnlPerceptionRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPerceptionRight.Location = new System.Drawing.Point(402, 0);
            this.pnlPerceptionRight.Name = "pnlPerceptionRight";
            this.pnlPerceptionRight.Size = new System.Drawing.Size(439, 538);
            this.pnlPerceptionRight.TabIndex = 9;
            // 
            // lblMovement
            // 
            this.lblMovement.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblMovement.EdgeRounding = false;
            this.lblMovement.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblMovement.Location = new System.Drawing.Point(15, 180);
            this.lblMovement.Name = "lblMovement";
            this.lblMovement.Size = new System.Drawing.Size(72, 24);
            this.lblMovement.TabIndex = 999;
            this.lblMovement.Text = "運動障害";
            this.lblMovement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMovement.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.txtAssessment5);
            this.groupBox20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox20.Location = new System.Drawing.Point(5, 391);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(428, 91);
            this.groupBox20.TabIndex = 15;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "備考";
            // 
            // txtAssessment5
            // 
            this.txtAssessment5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAssessment5.EnterKeyToTab = false;
            this.txtAssessment5.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAssessment5.Location = new System.Drawing.Point(3, 16);
            this.txtAssessment5.MaxLength = 4000;
            this.txtAssessment5.Name = "txtAssessment5";
            this.txtAssessment5.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtAssessment5.Size = new System.Drawing.Size(422, 72);
            this.txtAssessment5.TabIndex = 999;
            this.txtAssessment5.Text = "";
            // 
            // gbxPerception
            // 
            this.gbxPerception.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxPerception.Controls.Add(this.rbxPerceptionN);
            this.gbxPerception.Controls.Add(this.rbxPerceptionY);
            this.gbxPerception.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxPerception.Location = new System.Drawing.Point(95, 128);
            this.gbxPerception.Name = "gbxPerception";
            this.gbxPerception.Size = new System.Drawing.Size(101, 31);
            this.gbxPerception.TabIndex = 7;
            this.gbxPerception.TabStop = false;
            // 
            // rbxPerceptionN
            // 
            this.rbxPerceptionN.AutoSize = true;
            this.rbxPerceptionN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxPerceptionN.CheckedValue = "N";
            this.rbxPerceptionN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxPerceptionN.Location = new System.Drawing.Point(57, 10);
            this.rbxPerceptionN.Name = "rbxPerceptionN";
            this.rbxPerceptionN.Size = new System.Drawing.Size(37, 17);
            this.rbxPerceptionN.TabIndex = 2;
            this.rbxPerceptionN.TabStop = true;
            this.rbxPerceptionN.Text = "無";
            this.rbxPerceptionN.UseVisualStyleBackColor = false;
            // 
            // rbxPerceptionY
            // 
            this.rbxPerceptionY.AutoSize = true;
            this.rbxPerceptionY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxPerceptionY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxPerceptionY.Location = new System.Drawing.Point(6, 10);
            this.rbxPerceptionY.Name = "rbxPerceptionY";
            this.rbxPerceptionY.Size = new System.Drawing.Size(37, 17);
            this.rbxPerceptionY.TabIndex = 1;
            this.rbxPerceptionY.TabStop = true;
            this.rbxPerceptionY.Text = "有";
            this.rbxPerceptionY.UseVisualStyleBackColor = false;
            this.rbxPerceptionY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // gbxFear
            // 
            this.gbxFear.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxFear.Controls.Add(this.rbxFearN);
            this.gbxFear.Controls.Add(this.rbxFearY);
            this.gbxFear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxFear.Location = new System.Drawing.Point(95, 346);
            this.gbxFear.Name = "gbxFear";
            this.gbxFear.Size = new System.Drawing.Size(101, 31);
            this.gbxFear.TabIndex = 13;
            this.gbxFear.TabStop = false;
            // 
            // rbxFearN
            // 
            this.rbxFearN.AutoSize = true;
            this.rbxFearN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxFearN.CheckedValue = "N";
            this.rbxFearN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxFearN.Location = new System.Drawing.Point(57, 10);
            this.rbxFearN.Name = "rbxFearN";
            this.rbxFearN.Size = new System.Drawing.Size(37, 17);
            this.rbxFearN.TabIndex = 2;
            this.rbxFearN.TabStop = true;
            this.rbxFearN.Text = "無";
            this.rbxFearN.UseVisualStyleBackColor = false;
            // 
            // rbxFearY
            // 
            this.rbxFearY.AutoSize = true;
            this.rbxFearY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxFearY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxFearY.Location = new System.Drawing.Point(6, 10);
            this.rbxFearY.Name = "rbxFearY";
            this.rbxFearY.Size = new System.Drawing.Size(37, 17);
            this.rbxFearY.TabIndex = 1;
            this.rbxFearY.TabStop = true;
            this.rbxFearY.Text = "有";
            this.rbxFearY.UseVisualStyleBackColor = false;
            this.rbxFearY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // lblFear
            // 
            this.lblFear.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblFear.EdgeRounding = false;
            this.lblFear.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblFear.Location = new System.Drawing.Point(18, 352);
            this.lblFear.Name = "lblFear";
            this.lblFear.Size = new System.Drawing.Size(72, 24);
            this.lblFear.TabIndex = 999;
            this.lblFear.Text = "不安";
            this.lblFear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFear.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // txtFear
            // 
            this.txtFear.Enabled = false;
            this.txtFear.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFear.Location = new System.Drawing.Point(202, 353);
            this.txtFear.Name = "txtFear";
            this.txtFear.Size = new System.Drawing.Size(177, 20);
            this.txtFear.TabIndex = 14;
            // 
            // gbxWorry
            // 
            this.gbxWorry.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxWorry.Controls.Add(this.rbxWorryN);
            this.gbxWorry.Controls.Add(this.rbxWorryY);
            this.gbxWorry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxWorry.Location = new System.Drawing.Point(95, 313);
            this.gbxWorry.Name = "gbxWorry";
            this.gbxWorry.Size = new System.Drawing.Size(101, 31);
            this.gbxWorry.TabIndex = 11;
            this.gbxWorry.TabStop = false;
            // 
            // rbxWorryN
            // 
            this.rbxWorryN.AutoSize = true;
            this.rbxWorryN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxWorryN.CheckedValue = "N";
            this.rbxWorryN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxWorryN.Location = new System.Drawing.Point(57, 10);
            this.rbxWorryN.Name = "rbxWorryN";
            this.rbxWorryN.Size = new System.Drawing.Size(37, 17);
            this.rbxWorryN.TabIndex = 2;
            this.rbxWorryN.TabStop = true;
            this.rbxWorryN.Text = "無";
            this.rbxWorryN.UseVisualStyleBackColor = false;
            // 
            // rbxWorryY
            // 
            this.rbxWorryY.AutoSize = true;
            this.rbxWorryY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxWorryY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxWorryY.Location = new System.Drawing.Point(6, 10);
            this.rbxWorryY.Name = "rbxWorryY";
            this.rbxWorryY.Size = new System.Drawing.Size(37, 17);
            this.rbxWorryY.TabIndex = 1;
            this.rbxWorryY.TabStop = true;
            this.rbxWorryY.Text = "有";
            this.rbxWorryY.UseVisualStyleBackColor = false;
            this.rbxWorryY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // lblWorry
            // 
            this.lblWorry.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblWorry.EdgeRounding = false;
            this.lblWorry.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblWorry.Location = new System.Drawing.Point(18, 319);
            this.lblWorry.Name = "lblWorry";
            this.lblWorry.Size = new System.Drawing.Size(72, 24);
            this.lblWorry.TabIndex = 999;
            this.lblWorry.Text = "悩み";
            this.lblWorry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWorry.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // txtWorry
            // 
            this.txtWorry.Enabled = false;
            this.txtWorry.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtWorry.Location = new System.Drawing.Point(202, 320);
            this.txtWorry.Name = "txtWorry";
            this.txtWorry.Size = new System.Drawing.Size(177, 20);
            this.txtWorry.TabIndex = 12;
            // 
            // gbxMovement
            // 
            this.gbxMovement.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxMovement.Controls.Add(this.rbxMovementY);
            this.gbxMovement.Controls.Add(this.rbxMovementN);
            this.gbxMovement.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxMovement.Location = new System.Drawing.Point(91, 175);
            this.gbxMovement.Name = "gbxMovement";
            this.gbxMovement.Size = new System.Drawing.Size(96, 31);
            this.gbxMovement.TabIndex = 9;
            this.gbxMovement.TabStop = false;
            // 
            // rbxMovementY
            // 
            this.rbxMovementY.AutoSize = true;
            this.rbxMovementY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxMovementY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxMovementY.Location = new System.Drawing.Point(11, 9);
            this.rbxMovementY.Name = "rbxMovementY";
            this.rbxMovementY.Size = new System.Drawing.Size(37, 17);
            this.rbxMovementY.TabIndex = 1;
            this.rbxMovementY.TabStop = true;
            this.rbxMovementY.Text = "有";
            this.rbxMovementY.UseVisualStyleBackColor = false;
            this.rbxMovementY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxMovementN
            // 
            this.rbxMovementN.AutoSize = true;
            this.rbxMovementN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxMovementN.CheckedValue = "N";
            this.rbxMovementN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxMovementN.Location = new System.Drawing.Point(55, 9);
            this.rbxMovementN.Name = "rbxMovementN";
            this.rbxMovementN.Size = new System.Drawing.Size(37, 17);
            this.rbxMovementN.TabIndex = 2;
            this.rbxMovementN.TabStop = true;
            this.rbxMovementN.Text = "無";
            this.rbxMovementN.UseVisualStyleBackColor = false;
            // 
            // lblPerception
            // 
            this.lblPerception.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblPerception.EdgeRounding = false;
            this.lblPerception.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblPerception.Location = new System.Drawing.Point(18, 134);
            this.lblPerception.Name = "lblPerception";
            this.lblPerception.Size = new System.Drawing.Size(72, 24);
            this.lblPerception.TabIndex = 999;
            this.lblPerception.Text = "知覚障害";
            this.lblPerception.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPerception.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // gbxPain
            // 
            this.gbxPain.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxPain.Controls.Add(this.rbxPainN);
            this.gbxPain.Controls.Add(this.rbxPainY);
            this.gbxPain.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxPain.Location = new System.Drawing.Point(95, 93);
            this.gbxPain.Name = "gbxPain";
            this.gbxPain.Size = new System.Drawing.Size(101, 31);
            this.gbxPain.TabIndex = 5;
            this.gbxPain.TabStop = false;
            // 
            // rbxPainN
            // 
            this.rbxPainN.AutoSize = true;
            this.rbxPainN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxPainN.CheckedValue = "N";
            this.rbxPainN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxPainN.Location = new System.Drawing.Point(57, 10);
            this.rbxPainN.Name = "rbxPainN";
            this.rbxPainN.Size = new System.Drawing.Size(37, 17);
            this.rbxPainN.TabIndex = 2;
            this.rbxPainN.TabStop = true;
            this.rbxPainN.Text = "無";
            this.rbxPainN.UseVisualStyleBackColor = false;
            // 
            // rbxPainY
            // 
            this.rbxPainY.AutoSize = true;
            this.rbxPainY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxPainY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxPainY.Location = new System.Drawing.Point(6, 10);
            this.rbxPainY.Name = "rbxPainY";
            this.rbxPainY.Size = new System.Drawing.Size(37, 17);
            this.rbxPainY.TabIndex = 1;
            this.rbxPainY.TabStop = true;
            this.rbxPainY.Text = "有";
            this.rbxPainY.UseVisualStyleBackColor = false;
            this.rbxPainY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // txtPerception
            // 
            this.txtPerception.Enabled = false;
            this.txtPerception.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtPerception.Location = new System.Drawing.Point(202, 135);
            this.txtPerception.Name = "txtPerception";
            this.txtPerception.Size = new System.Drawing.Size(177, 20);
            this.txtPerception.TabIndex = 8;
            // 
            // lblPain
            // 
            this.lblPain.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblPain.EdgeRounding = false;
            this.lblPain.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblPain.Location = new System.Drawing.Point(18, 99);
            this.lblPain.Name = "lblPain";
            this.lblPain.Size = new System.Drawing.Size(72, 24);
            this.lblPain.TabIndex = 999;
            this.lblPain.Text = "疼痛";
            this.lblPain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPain.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // txtPain
            // 
            this.txtPain.Enabled = false;
            this.txtPain.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtPain.Location = new System.Drawing.Point(202, 100);
            this.txtPain.Name = "txtPain";
            this.txtPain.Size = new System.Drawing.Size(177, 20);
            this.txtPain.TabIndex = 6;
            // 
            // gbxStagger
            // 
            this.gbxStagger.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxStagger.Controls.Add(this.rbxStaggerN);
            this.gbxStagger.Controls.Add(this.rbxStaggerY);
            this.gbxStagger.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxStagger.Location = new System.Drawing.Point(95, 60);
            this.gbxStagger.Name = "gbxStagger";
            this.gbxStagger.Size = new System.Drawing.Size(101, 31);
            this.gbxStagger.TabIndex = 3;
            this.gbxStagger.TabStop = false;
            // 
            // rbxStaggerN
            // 
            this.rbxStaggerN.AutoSize = true;
            this.rbxStaggerN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxStaggerN.CheckedValue = "N";
            this.rbxStaggerN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxStaggerN.Location = new System.Drawing.Point(57, 10);
            this.rbxStaggerN.Name = "rbxStaggerN";
            this.rbxStaggerN.Size = new System.Drawing.Size(37, 17);
            this.rbxStaggerN.TabIndex = 2;
            this.rbxStaggerN.TabStop = true;
            this.rbxStaggerN.Text = "無";
            this.rbxStaggerN.UseVisualStyleBackColor = false;
            // 
            // rbxStaggerY
            // 
            this.rbxStaggerY.AutoSize = true;
            this.rbxStaggerY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxStaggerY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxStaggerY.Location = new System.Drawing.Point(6, 10);
            this.rbxStaggerY.Name = "rbxStaggerY";
            this.rbxStaggerY.Size = new System.Drawing.Size(37, 17);
            this.rbxStaggerY.TabIndex = 1;
            this.rbxStaggerY.TabStop = true;
            this.rbxStaggerY.Text = "有";
            this.rbxStaggerY.UseVisualStyleBackColor = false;
            this.rbxStaggerY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // gbxDizzy
            // 
            this.gbxDizzy.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxDizzy.Controls.Add(this.rbxDizzyY);
            this.gbxDizzy.Controls.Add(this.rbxDizzyN);
            this.gbxDizzy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxDizzy.Location = new System.Drawing.Point(95, 27);
            this.gbxDizzy.Name = "gbxDizzy";
            this.gbxDizzy.Size = new System.Drawing.Size(101, 31);
            this.gbxDizzy.TabIndex = 1;
            this.gbxDizzy.TabStop = false;
            // 
            // rbxDizzyY
            // 
            this.rbxDizzyY.AutoSize = true;
            this.rbxDizzyY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxDizzyY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxDizzyY.Location = new System.Drawing.Point(6, 9);
            this.rbxDizzyY.Name = "rbxDizzyY";
            this.rbxDizzyY.Size = new System.Drawing.Size(37, 17);
            this.rbxDizzyY.TabIndex = 1;
            this.rbxDizzyY.TabStop = true;
            this.rbxDizzyY.Text = "有";
            this.rbxDizzyY.UseVisualStyleBackColor = false;
            this.rbxDizzyY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxDizzyN
            // 
            this.rbxDizzyN.AutoSize = true;
            this.rbxDizzyN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxDizzyN.CheckedValue = "N";
            this.rbxDizzyN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxDizzyN.Location = new System.Drawing.Point(57, 9);
            this.rbxDizzyN.Name = "rbxDizzyN";
            this.rbxDizzyN.Size = new System.Drawing.Size(37, 17);
            this.rbxDizzyN.TabIndex = 2;
            this.rbxDizzyN.TabStop = true;
            this.rbxDizzyN.Text = "無";
            this.rbxDizzyN.UseVisualStyleBackColor = false;
            // 
            // txtStagger
            // 
            this.txtStagger.Enabled = false;
            this.txtStagger.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtStagger.Location = new System.Drawing.Point(202, 67);
            this.txtStagger.Name = "txtStagger";
            this.txtStagger.Size = new System.Drawing.Size(177, 20);
            this.txtStagger.TabIndex = 4;
            // 
            // txtDizzy
            // 
            this.txtDizzy.Enabled = false;
            this.txtDizzy.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDizzy.Location = new System.Drawing.Point(202, 34);
            this.txtDizzy.Name = "txtDizzy";
            this.txtDizzy.Size = new System.Drawing.Size(177, 20);
            this.txtDizzy.TabIndex = 2;
            // 
            // lblStagger
            // 
            this.lblStagger.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblStagger.EdgeRounding = false;
            this.lblStagger.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblStagger.Location = new System.Drawing.Point(18, 66);
            this.lblStagger.Name = "lblStagger";
            this.lblStagger.Size = new System.Drawing.Size(72, 24);
            this.lblStagger.TabIndex = 999;
            this.lblStagger.Text = "ふらつき";
            this.lblStagger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStagger.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblDizzy
            // 
            this.lblDizzy.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDizzy.EdgeRounding = false;
            this.lblDizzy.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblDizzy.Location = new System.Drawing.Point(18, 33);
            this.lblDizzy.Name = "lblDizzy";
            this.lblDizzy.Size = new System.Drawing.Size(72, 24);
            this.lblDizzy.TabIndex = 999;
            this.lblDizzy.Text = "めまい";
            this.lblDizzy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDizzy.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // gbxMovementDetail
            // 
            this.gbxMovementDetail.Controls.Add(this.txtLossPart);
            this.gbxMovementDetail.Controls.Add(this.txtContracture);
            this.gbxMovementDetail.Controls.Add(this.txtParalysis);
            this.gbxMovementDetail.Controls.Add(this.gbxLossPart);
            this.gbxMovementDetail.Controls.Add(this.gbxContracture);
            this.gbxMovementDetail.Controls.Add(this.gbxParalysis);
            this.gbxMovementDetail.Controls.Add(this.lblLossPart);
            this.gbxMovementDetail.Controls.Add(this.lblContracture);
            this.gbxMovementDetail.Controls.Add(this.lblParalysis);
            this.gbxMovementDetail.Location = new System.Drawing.Point(15, 187);
            this.gbxMovementDetail.Name = "gbxMovementDetail";
            this.gbxMovementDetail.Size = new System.Drawing.Size(364, 123);
            this.gbxMovementDetail.TabIndex = 10;
            this.gbxMovementDetail.TabStop = false;
            // 
            // txtLossPart
            // 
            this.txtLossPart.Enabled = false;
            this.txtLossPart.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtLossPart.Location = new System.Drawing.Point(187, 95);
            this.txtLossPart.Name = "txtLossPart";
            this.txtLossPart.Size = new System.Drawing.Size(171, 20);
            this.txtLossPart.TabIndex = 6;
            // 
            // txtContracture
            // 
            this.txtContracture.Enabled = false;
            this.txtContracture.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtContracture.Location = new System.Drawing.Point(187, 59);
            this.txtContracture.Name = "txtContracture";
            this.txtContracture.Size = new System.Drawing.Size(171, 20);
            this.txtContracture.TabIndex = 4;
            // 
            // txtParalysis
            // 
            this.txtParalysis.Enabled = false;
            this.txtParalysis.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtParalysis.Location = new System.Drawing.Point(187, 27);
            this.txtParalysis.Name = "txtParalysis";
            this.txtParalysis.Size = new System.Drawing.Size(171, 20);
            this.txtParalysis.TabIndex = 2;
            // 
            // gbxLossPart
            // 
            this.gbxLossPart.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxLossPart.Controls.Add(this.rbxLossPartY);
            this.gbxLossPart.Controls.Add(this.rbxLossPartN);
            this.gbxLossPart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxLossPart.Location = new System.Drawing.Point(80, 86);
            this.gbxLossPart.Name = "gbxLossPart";
            this.gbxLossPart.Size = new System.Drawing.Size(101, 31);
            this.gbxLossPart.TabIndex = 5;
            this.gbxLossPart.TabStop = false;
            // 
            // rbxLossPartY
            // 
            this.rbxLossPartY.AutoSize = true;
            this.rbxLossPartY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxLossPartY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxLossPartY.Location = new System.Drawing.Point(6, 9);
            this.rbxLossPartY.Name = "rbxLossPartY";
            this.rbxLossPartY.Size = new System.Drawing.Size(37, 17);
            this.rbxLossPartY.TabIndex = 1;
            this.rbxLossPartY.TabStop = true;
            this.rbxLossPartY.Text = "有";
            this.rbxLossPartY.UseVisualStyleBackColor = false;
            this.rbxLossPartY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxLossPartN
            // 
            this.rbxLossPartN.AutoSize = true;
            this.rbxLossPartN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxLossPartN.CheckedValue = "N";
            this.rbxLossPartN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxLossPartN.Location = new System.Drawing.Point(57, 9);
            this.rbxLossPartN.Name = "rbxLossPartN";
            this.rbxLossPartN.Size = new System.Drawing.Size(37, 17);
            this.rbxLossPartN.TabIndex = 2;
            this.rbxLossPartN.TabStop = true;
            this.rbxLossPartN.Text = "無";
            this.rbxLossPartN.UseVisualStyleBackColor = false;
            // 
            // gbxContracture
            // 
            this.gbxContracture.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxContracture.Controls.Add(this.rbxContractureY);
            this.gbxContracture.Controls.Add(this.rbxContractureN);
            this.gbxContracture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxContracture.Location = new System.Drawing.Point(80, 53);
            this.gbxContracture.Name = "gbxContracture";
            this.gbxContracture.Size = new System.Drawing.Size(101, 31);
            this.gbxContracture.TabIndex = 3;
            this.gbxContracture.TabStop = false;
            // 
            // rbxContractureY
            // 
            this.rbxContractureY.AutoSize = true;
            this.rbxContractureY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxContractureY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxContractureY.Location = new System.Drawing.Point(6, 9);
            this.rbxContractureY.Name = "rbxContractureY";
            this.rbxContractureY.Size = new System.Drawing.Size(37, 17);
            this.rbxContractureY.TabIndex = 1;
            this.rbxContractureY.TabStop = true;
            this.rbxContractureY.Text = "有";
            this.rbxContractureY.UseVisualStyleBackColor = false;
            this.rbxContractureY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxContractureN
            // 
            this.rbxContractureN.AutoSize = true;
            this.rbxContractureN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxContractureN.CheckedValue = "N";
            this.rbxContractureN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxContractureN.Location = new System.Drawing.Point(57, 9);
            this.rbxContractureN.Name = "rbxContractureN";
            this.rbxContractureN.Size = new System.Drawing.Size(37, 17);
            this.rbxContractureN.TabIndex = 2;
            this.rbxContractureN.TabStop = true;
            this.rbxContractureN.Text = "無";
            this.rbxContractureN.UseVisualStyleBackColor = false;
            // 
            // gbxParalysis
            // 
            this.gbxParalysis.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxParalysis.Controls.Add(this.rbxParalysisY);
            this.gbxParalysis.Controls.Add(this.rbxParalysisN);
            this.gbxParalysis.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxParalysis.Location = new System.Drawing.Point(80, 19);
            this.gbxParalysis.Name = "gbxParalysis";
            this.gbxParalysis.Size = new System.Drawing.Size(101, 31);
            this.gbxParalysis.TabIndex = 1;
            this.gbxParalysis.TabStop = false;
            // 
            // rbxParalysisY
            // 
            this.rbxParalysisY.AutoSize = true;
            this.rbxParalysisY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxParalysisY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxParalysisY.Location = new System.Drawing.Point(6, 9);
            this.rbxParalysisY.Name = "rbxParalysisY";
            this.rbxParalysisY.Size = new System.Drawing.Size(37, 17);
            this.rbxParalysisY.TabIndex = 1;
            this.rbxParalysisY.TabStop = true;
            this.rbxParalysisY.Text = "有";
            this.rbxParalysisY.UseVisualStyleBackColor = false;
            this.rbxParalysisY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxParalysisN
            // 
            this.rbxParalysisN.AutoSize = true;
            this.rbxParalysisN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxParalysisN.CheckedValue = "N";
            this.rbxParalysisN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxParalysisN.Location = new System.Drawing.Point(57, 9);
            this.rbxParalysisN.Name = "rbxParalysisN";
            this.rbxParalysisN.Size = new System.Drawing.Size(37, 17);
            this.rbxParalysisN.TabIndex = 2;
            this.rbxParalysisN.TabStop = true;
            this.rbxParalysisN.Text = "無";
            this.rbxParalysisN.UseVisualStyleBackColor = false;
            // 
            // lblLossPart
            // 
            this.lblLossPart.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblLossPart.EdgeRounding = false;
            this.lblLossPart.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblLossPart.Location = new System.Drawing.Point(6, 90);
            this.lblLossPart.Name = "lblLossPart";
            this.lblLossPart.Size = new System.Drawing.Size(72, 24);
            this.lblLossPart.TabIndex = 999;
            this.lblLossPart.Text = "欠損部位";
            this.lblLossPart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLossPart.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblContracture
            // 
            this.lblContracture.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblContracture.EdgeRounding = false;
            this.lblContracture.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblContracture.Location = new System.Drawing.Point(6, 57);
            this.lblContracture.Name = "lblContracture";
            this.lblContracture.Size = new System.Drawing.Size(72, 24);
            this.lblContracture.TabIndex = 999;
            this.lblContracture.Text = "拘縮";
            this.lblContracture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContracture.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblParalysis
            // 
            this.lblParalysis.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblParalysis.EdgeRounding = false;
            this.lblParalysis.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblParalysis.Location = new System.Drawing.Point(6, 25);
            this.lblParalysis.Name = "lblParalysis";
            this.lblParalysis.Size = new System.Drawing.Size(72, 24);
            this.lblParalysis.TabIndex = 999;
            this.lblParalysis.Text = "麻痺";
            this.lblParalysis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblParalysis.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // pnlPerceptionLeft
            // 
            this.pnlPerceptionLeft.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlPerceptionLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPerceptionLeft.Controls.Add(this.lblSensor);
            this.pnlPerceptionLeft.Controls.Add(this.gbxRecognition);
            this.pnlPerceptionLeft.Controls.Add(this.lblObstacleSpeech);
            this.pnlPerceptionLeft.Controls.Add(this.txtRecognition);
            this.pnlPerceptionLeft.Controls.Add(this.txtObstacle);
            this.pnlPerceptionLeft.Controls.Add(this.gbxSensor);
            this.pnlPerceptionLeft.Controls.Add(this.gbxSensorDetail);
            this.pnlPerceptionLeft.Controls.Add(this.lblRecognition);
            this.pnlPerceptionLeft.Controls.Add(this.lblSense_style);
            this.pnlPerceptionLeft.Controls.Add(this.lblObstacle);
            this.pnlPerceptionLeft.Controls.Add(this.gbxObstacle);
            this.pnlPerceptionLeft.Controls.Add(this.cboSenseLevel);
            this.pnlPerceptionLeft.Controls.Add(this.gbxObstacleSense);
            this.pnlPerceptionLeft.Controls.Add(this.gbxObstacleSpeech);
            this.pnlPerceptionLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPerceptionLeft.DrawBorder = true;
            this.pnlPerceptionLeft.Location = new System.Drawing.Point(3, 0);
            this.pnlPerceptionLeft.Name = "pnlPerceptionLeft";
            this.pnlPerceptionLeft.Size = new System.Drawing.Size(399, 538);
            this.pnlPerceptionLeft.TabIndex = 8;
            // 
            // lblSensor
            // 
            this.lblSensor.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSensor.EdgeRounding = false;
            this.lblSensor.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblSensor.Location = new System.Drawing.Point(12, 229);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(58, 24);
            this.lblSensor.TabIndex = 999;
            this.lblSensor.Text = "感覚器";
            this.lblSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSensor.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // gbxRecognition
            // 
            this.gbxRecognition.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxRecognition.Controls.Add(this.rbxRecognitionY);
            this.gbxRecognition.Controls.Add(this.rbxRecognitionN);
            this.gbxRecognition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxRecognition.Location = new System.Drawing.Point(119, 169);
            this.gbxRecognition.Name = "gbxRecognition";
            this.gbxRecognition.Size = new System.Drawing.Size(101, 31);
            this.gbxRecognition.TabIndex = 6;
            this.gbxRecognition.TabStop = false;
            // 
            // rbxRecognitionY
            // 
            this.rbxRecognitionY.AutoSize = true;
            this.rbxRecognitionY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxRecognitionY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxRecognitionY.Location = new System.Drawing.Point(8, 9);
            this.rbxRecognitionY.Name = "rbxRecognitionY";
            this.rbxRecognitionY.Size = new System.Drawing.Size(37, 17);
            this.rbxRecognitionY.TabIndex = 1;
            this.rbxRecognitionY.TabStop = true;
            this.rbxRecognitionY.Text = "有";
            this.rbxRecognitionY.UseVisualStyleBackColor = false;
            this.rbxRecognitionY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxRecognitionN
            // 
            this.rbxRecognitionN.AutoSize = true;
            this.rbxRecognitionN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxRecognitionN.CheckedValue = "N";
            this.rbxRecognitionN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxRecognitionN.Location = new System.Drawing.Point(59, 9);
            this.rbxRecognitionN.Name = "rbxRecognitionN";
            this.rbxRecognitionN.Size = new System.Drawing.Size(37, 17);
            this.rbxRecognitionN.TabIndex = 2;
            this.rbxRecognitionN.TabStop = true;
            this.rbxRecognitionN.Text = "無";
            this.rbxRecognitionN.UseVisualStyleBackColor = false;
            // 
            // lblObstacleSpeech
            // 
            this.lblObstacleSpeech.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblObstacleSpeech.EdgeRounding = false;
            this.lblObstacleSpeech.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblObstacleSpeech.Location = new System.Drawing.Point(22, 76);
            this.lblObstacleSpeech.Name = "lblObstacleSpeech";
            this.lblObstacleSpeech.Size = new System.Drawing.Size(92, 24);
            this.lblObstacleSpeech.TabIndex = 999;
            this.lblObstacleSpeech.Text = "言語障害";
            this.lblObstacleSpeech.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblObstacleSpeech.DoubleClick += new System.EventHandler(this.lblObstacleSpeech_DoubleClick);
            // 
            // txtRecognition
            // 
            this.txtRecognition.Enabled = false;
            this.txtRecognition.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtRecognition.Location = new System.Drawing.Point(223, 177);
            this.txtRecognition.Name = "txtRecognition";
            this.txtRecognition.Size = new System.Drawing.Size(130, 20);
            this.txtRecognition.TabIndex = 7;
            // 
            // txtObstacle
            // 
            this.txtObstacle.Enabled = false;
            this.txtObstacle.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtObstacle.Location = new System.Drawing.Point(223, 127);
            this.txtObstacle.Name = "txtObstacle";
            this.txtObstacle.Size = new System.Drawing.Size(130, 20);
            this.txtObstacle.TabIndex = 5;
            // 
            // gbxSensor
            // 
            this.gbxSensor.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxSensor.Controls.Add(this.rbxSensorY);
            this.gbxSensor.Controls.Add(this.rbxSensorN);
            this.gbxSensor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxSensor.Location = new System.Drawing.Point(74, 224);
            this.gbxSensor.Name = "gbxSensor";
            this.gbxSensor.Size = new System.Drawing.Size(96, 31);
            this.gbxSensor.TabIndex = 8;
            this.gbxSensor.TabStop = false;
            // 
            // rbxSensorY
            // 
            this.rbxSensorY.AutoSize = true;
            this.rbxSensorY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxSensorY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxSensorY.Location = new System.Drawing.Point(11, 9);
            this.rbxSensorY.Name = "rbxSensorY";
            this.rbxSensorY.Size = new System.Drawing.Size(37, 17);
            this.rbxSensorY.TabIndex = 1;
            this.rbxSensorY.TabStop = true;
            this.rbxSensorY.Text = "有";
            this.rbxSensorY.UseVisualStyleBackColor = false;
            this.rbxSensorY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxSensorN
            // 
            this.rbxSensorN.AutoSize = true;
            this.rbxSensorN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxSensorN.CheckedValue = "N";
            this.rbxSensorN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxSensorN.Location = new System.Drawing.Point(55, 9);
            this.rbxSensorN.Name = "rbxSensorN";
            this.rbxSensorN.Size = new System.Drawing.Size(37, 17);
            this.rbxSensorN.TabIndex = 2;
            this.rbxSensorN.TabStop = true;
            this.rbxSensorN.Text = "無";
            this.rbxSensorN.UseVisualStyleBackColor = false;
            // 
            // gbxSensorDetail
            // 
            this.gbxSensorDetail.Controls.Add(this.txtMouth);
            this.gbxSensorDetail.Controls.Add(this.txtNose);
            this.gbxSensorDetail.Controls.Add(this.txtEarRight);
            this.gbxSensorDetail.Controls.Add(this.txtEarLeft);
            this.gbxSensorDetail.Controls.Add(this.cbxEarLeft);
            this.gbxSensorDetail.Controls.Add(this.cbxEarRight);
            this.gbxSensorDetail.Controls.Add(this.txtEyeRight);
            this.gbxSensorDetail.Controls.Add(this.txtEyeLeft);
            this.gbxSensorDetail.Controls.Add(this.cbxEyeLeft);
            this.gbxSensorDetail.Controls.Add(this.cbxEyeRight);
            this.gbxSensorDetail.Controls.Add(this.xLabel137);
            this.gbxSensorDetail.Controls.Add(this.xLabel136);
            this.gbxSensorDetail.Controls.Add(this.lblEarAid);
            this.gbxSensorDetail.Controls.Add(this.lblLens);
            this.gbxSensorDetail.Controls.Add(this.lblGlasses);
            this.gbxSensorDetail.Controls.Add(this.xLabel132);
            this.gbxSensorDetail.Controls.Add(this.xLabel131);
            this.gbxSensorDetail.Controls.Add(this.gbxGlasses);
            this.gbxSensorDetail.Controls.Add(this.gbxLens);
            this.gbxSensorDetail.Controls.Add(this.gbxEarAid);
            this.gbxSensorDetail.Location = new System.Drawing.Point(12, 237);
            this.gbxSensorDetail.Name = "gbxSensorDetail";
            this.gbxSensorDetail.Size = new System.Drawing.Size(364, 245);
            this.gbxSensorDetail.TabIndex = 9;
            this.gbxSensorDetail.TabStop = false;
            // 
            // txtMouth
            // 
            this.txtMouth.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtMouth.Location = new System.Drawing.Point(56, 208);
            this.txtMouth.Name = "txtMouth";
            this.txtMouth.Size = new System.Drawing.Size(284, 20);
            this.txtMouth.TabIndex = 13;
            // 
            // txtNose
            // 
            this.txtNose.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtNose.Location = new System.Drawing.Point(56, 177);
            this.txtNose.Name = "txtNose";
            this.txtNose.Size = new System.Drawing.Size(284, 20);
            this.txtNose.TabIndex = 12;
            // 
            // txtEarRight
            // 
            this.txtEarRight.Enabled = false;
            this.txtEarRight.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtEarRight.Location = new System.Drawing.Point(98, 98);
            this.txtEarRight.Name = "txtEarRight";
            this.txtEarRight.Size = new System.Drawing.Size(242, 20);
            this.txtEarRight.TabIndex = 8;
            // 
            // txtEarLeft
            // 
            this.txtEarLeft.Enabled = false;
            this.txtEarLeft.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtEarLeft.Location = new System.Drawing.Point(98, 119);
            this.txtEarLeft.Name = "txtEarLeft";
            this.txtEarLeft.Size = new System.Drawing.Size(242, 20);
            this.txtEarLeft.TabIndex = 10;
            // 
            // cbxEarLeft
            // 
            this.cbxEarLeft.AutoSize = true;
            this.cbxEarLeft.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxEarLeft.Location = new System.Drawing.Point(59, 119);
            this.cbxEarLeft.Name = "cbxEarLeft";
            this.cbxEarLeft.Size = new System.Drawing.Size(36, 17);
            this.cbxEarLeft.TabIndex = 9;
            this.cbxEarLeft.Text = "左";
            this.cbxEarLeft.UseVisualStyleBackColor = false;
            this.cbxEarLeft.CheckedChanged += new System.EventHandler(this.cbxCheckedChanged);
            // 
            // cbxEarRight
            // 
            this.cbxEarRight.AutoSize = true;
            this.cbxEarRight.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxEarRight.Location = new System.Drawing.Point(59, 101);
            this.cbxEarRight.Name = "cbxEarRight";
            this.cbxEarRight.Size = new System.Drawing.Size(36, 17);
            this.cbxEarRight.TabIndex = 7;
            this.cbxEarRight.Text = "右";
            this.cbxEarRight.UseVisualStyleBackColor = false;
            this.cbxEarRight.CheckedChanged += new System.EventHandler(this.cbxCheckedChanged);
            // 
            // txtEyeRight
            // 
            this.txtEyeRight.Enabled = false;
            this.txtEyeRight.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtEyeRight.Location = new System.Drawing.Point(99, 20);
            this.txtEyeRight.Name = "txtEyeRight";
            this.txtEyeRight.Size = new System.Drawing.Size(242, 20);
            this.txtEyeRight.TabIndex = 2;
            // 
            // txtEyeLeft
            // 
            this.txtEyeLeft.Enabled = false;
            this.txtEyeLeft.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtEyeLeft.Location = new System.Drawing.Point(99, 41);
            this.txtEyeLeft.Name = "txtEyeLeft";
            this.txtEyeLeft.Size = new System.Drawing.Size(242, 20);
            this.txtEyeLeft.TabIndex = 4;
            // 
            // cbxEyeLeft
            // 
            this.cbxEyeLeft.AutoSize = true;
            this.cbxEyeLeft.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxEyeLeft.Location = new System.Drawing.Point(60, 41);
            this.cbxEyeLeft.Name = "cbxEyeLeft";
            this.cbxEyeLeft.Size = new System.Drawing.Size(36, 17);
            this.cbxEyeLeft.TabIndex = 3;
            this.cbxEyeLeft.Text = "左";
            this.cbxEyeLeft.UseVisualStyleBackColor = false;
            this.cbxEyeLeft.CheckedChanged += new System.EventHandler(this.cbxCheckedChanged);
            // 
            // cbxEyeRight
            // 
            this.cbxEyeRight.AutoSize = true;
            this.cbxEyeRight.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.cbxEyeRight.Location = new System.Drawing.Point(60, 23);
            this.cbxEyeRight.Name = "cbxEyeRight";
            this.cbxEyeRight.Size = new System.Drawing.Size(36, 17);
            this.cbxEyeRight.TabIndex = 1;
            this.cbxEyeRight.Text = "右";
            this.cbxEyeRight.UseVisualStyleBackColor = false;
            this.cbxEyeRight.CheckedChanged += new System.EventHandler(this.cbxCheckedChanged);
            // 
            // xLabel137
            // 
            this.xLabel137.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel137.EdgeRounding = false;
            this.xLabel137.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel137.Location = new System.Drawing.Point(21, 207);
            this.xLabel137.Name = "xLabel137";
            this.xLabel137.Size = new System.Drawing.Size(30, 24);
            this.xLabel137.TabIndex = 999;
            this.xLabel137.Text = "口";
            this.xLabel137.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel136
            // 
            this.xLabel136.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel136.EdgeRounding = false;
            this.xLabel136.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel136.Location = new System.Drawing.Point(21, 175);
            this.xLabel136.Name = "xLabel136";
            this.xLabel136.Size = new System.Drawing.Size(30, 24);
            this.xLabel136.TabIndex = 999;
            this.xLabel136.Text = "鼻";
            this.xLabel136.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEarAid
            // 
            this.lblEarAid.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblEarAid.EdgeRounding = false;
            this.lblEarAid.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblEarAid.Location = new System.Drawing.Point(21, 145);
            this.lblEarAid.Name = "lblEarAid";
            this.lblEarAid.Size = new System.Drawing.Size(72, 24);
            this.lblEarAid.TabIndex = 999;
            this.lblEarAid.Text = "補聴器";
            this.lblEarAid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEarAid.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblLens
            // 
            this.lblLens.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblLens.EdgeRounding = false;
            this.lblLens.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblLens.Location = new System.Drawing.Point(182, 66);
            this.lblLens.Name = "lblLens";
            this.lblLens.Size = new System.Drawing.Size(72, 24);
            this.lblLens.TabIndex = 999;
            this.lblLens.Text = "コンタクト";
            this.lblLens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLens.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblGlasses
            // 
            this.lblGlasses.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblGlasses.EdgeRounding = false;
            this.lblGlasses.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblGlasses.Location = new System.Drawing.Point(20, 66);
            this.lblGlasses.Name = "lblGlasses";
            this.lblGlasses.Size = new System.Drawing.Size(72, 24);
            this.lblGlasses.TabIndex = 999;
            this.lblGlasses.Text = "メガネ";
            this.lblGlasses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGlasses.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // xLabel132
            // 
            this.xLabel132.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel132.EdgeRounding = false;
            this.xLabel132.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel132.Location = new System.Drawing.Point(20, 106);
            this.xLabel132.Name = "xLabel132";
            this.xLabel132.Size = new System.Drawing.Size(30, 24);
            this.xLabel132.TabIndex = 999;
            this.xLabel132.Text = "耳";
            this.xLabel132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel131
            // 
            this.xLabel131.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel131.EdgeRounding = false;
            this.xLabel131.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel131.Location = new System.Drawing.Point(21, 27);
            this.xLabel131.Name = "xLabel131";
            this.xLabel131.Size = new System.Drawing.Size(30, 24);
            this.xLabel131.TabIndex = 999;
            this.xLabel131.Text = "目";
            this.xLabel131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxGlasses
            // 
            this.gbxGlasses.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxGlasses.Controls.Add(this.rbxGlassesY);
            this.gbxGlasses.Controls.Add(this.rbxGlassesN);
            this.gbxGlasses.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxGlasses.Location = new System.Drawing.Point(94, 60);
            this.gbxGlasses.Name = "gbxGlasses";
            this.gbxGlasses.Size = new System.Drawing.Size(85, 31);
            this.gbxGlasses.TabIndex = 5;
            this.gbxGlasses.TabStop = false;
            // 
            // rbxGlassesY
            // 
            this.rbxGlassesY.AutoSize = true;
            this.rbxGlassesY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxGlassesY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxGlassesY.Location = new System.Drawing.Point(8, 9);
            this.rbxGlassesY.Name = "rbxGlassesY";
            this.rbxGlassesY.Size = new System.Drawing.Size(37, 17);
            this.rbxGlassesY.TabIndex = 1;
            this.rbxGlassesY.TabStop = true;
            this.rbxGlassesY.Text = "有";
            this.rbxGlassesY.UseVisualStyleBackColor = false;
            // 
            // rbxGlassesN
            // 
            this.rbxGlassesN.AutoSize = true;
            this.rbxGlassesN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxGlassesN.CheckedValue = "N";
            this.rbxGlassesN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxGlassesN.Location = new System.Drawing.Point(45, 9);
            this.rbxGlassesN.Name = "rbxGlassesN";
            this.rbxGlassesN.Size = new System.Drawing.Size(37, 17);
            this.rbxGlassesN.TabIndex = 2;
            this.rbxGlassesN.TabStop = true;
            this.rbxGlassesN.Text = "無";
            this.rbxGlassesN.UseVisualStyleBackColor = false;
            // 
            // gbxLens
            // 
            this.gbxLens.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxLens.Controls.Add(this.rbxLensY);
            this.gbxLens.Controls.Add(this.rbxLensN);
            this.gbxLens.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxLens.Location = new System.Drawing.Point(256, 60);
            this.gbxLens.Name = "gbxLens";
            this.gbxLens.Size = new System.Drawing.Size(86, 31);
            this.gbxLens.TabIndex = 6;
            this.gbxLens.TabStop = false;
            // 
            // rbxLensY
            // 
            this.rbxLensY.AutoSize = true;
            this.rbxLensY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxLensY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxLensY.Location = new System.Drawing.Point(8, 9);
            this.rbxLensY.Name = "rbxLensY";
            this.rbxLensY.Size = new System.Drawing.Size(37, 17);
            this.rbxLensY.TabIndex = 1;
            this.rbxLensY.TabStop = true;
            this.rbxLensY.Text = "有";
            this.rbxLensY.UseVisualStyleBackColor = false;
            // 
            // rbxLensN
            // 
            this.rbxLensN.AutoSize = true;
            this.rbxLensN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxLensN.CheckedValue = "N";
            this.rbxLensN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxLensN.Location = new System.Drawing.Point(46, 9);
            this.rbxLensN.Name = "rbxLensN";
            this.rbxLensN.Size = new System.Drawing.Size(37, 17);
            this.rbxLensN.TabIndex = 2;
            this.rbxLensN.TabStop = true;
            this.rbxLensN.Text = "無";
            this.rbxLensN.UseVisualStyleBackColor = false;
            // 
            // gbxEarAid
            // 
            this.gbxEarAid.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxEarAid.Controls.Add(this.rbxEarAidY);
            this.gbxEarAid.Controls.Add(this.rbxEarAidN);
            this.gbxEarAid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxEarAid.Location = new System.Drawing.Point(95, 140);
            this.gbxEarAid.Name = "gbxEarAid";
            this.gbxEarAid.Size = new System.Drawing.Size(85, 31);
            this.gbxEarAid.TabIndex = 11;
            this.gbxEarAid.TabStop = false;
            // 
            // rbxEarAidY
            // 
            this.rbxEarAidY.AutoSize = true;
            this.rbxEarAidY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxEarAidY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxEarAidY.Location = new System.Drawing.Point(8, 9);
            this.rbxEarAidY.Name = "rbxEarAidY";
            this.rbxEarAidY.Size = new System.Drawing.Size(37, 17);
            this.rbxEarAidY.TabIndex = 1;
            this.rbxEarAidY.TabStop = true;
            this.rbxEarAidY.Text = "有";
            this.rbxEarAidY.UseVisualStyleBackColor = false;
            // 
            // rbxEarAidN
            // 
            this.rbxEarAidN.AutoSize = true;
            this.rbxEarAidN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxEarAidN.CheckedValue = "N";
            this.rbxEarAidN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxEarAidN.Location = new System.Drawing.Point(45, 9);
            this.rbxEarAidN.Name = "rbxEarAidN";
            this.rbxEarAidN.Size = new System.Drawing.Size(37, 17);
            this.rbxEarAidN.TabIndex = 2;
            this.rbxEarAidN.TabStop = true;
            this.rbxEarAidN.Text = "無";
            this.rbxEarAidN.UseVisualStyleBackColor = false;
            // 
            // lblRecognition
            // 
            this.lblRecognition.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblRecognition.EdgeRounding = false;
            this.lblRecognition.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblRecognition.Location = new System.Drawing.Point(22, 174);
            this.lblRecognition.Name = "lblRecognition";
            this.lblRecognition.Size = new System.Drawing.Size(92, 24);
            this.lblRecognition.TabIndex = 999;
            this.lblRecognition.Text = "認知症状";
            this.lblRecognition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecognition.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblSense_style
            // 
            this.lblSense_style.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSense_style.EdgeRounding = false;
            this.lblSense_style.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblSense_style.Location = new System.Drawing.Point(22, 27);
            this.lblSense_style.Name = "lblSense_style";
            this.lblSense_style.Size = new System.Drawing.Size(92, 24);
            this.lblSense_style.TabIndex = 999;
            this.lblSense_style.Text = "意識レベル";
            this.lblSense_style.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblObstacle
            // 
            this.lblObstacle.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblObstacle.EdgeRounding = false;
            this.lblObstacle.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblObstacle.Location = new System.Drawing.Point(22, 125);
            this.lblObstacle.Name = "lblObstacle";
            this.lblObstacle.Size = new System.Drawing.Size(92, 24);
            this.lblObstacle.TabIndex = 999;
            this.lblObstacle.Text = "見当識障害";
            this.lblObstacle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblObstacle.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // gbxObstacle
            // 
            this.gbxObstacle.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxObstacle.Controls.Add(this.rbxObstacleY);
            this.gbxObstacle.Controls.Add(this.rbxObstacleN);
            this.gbxObstacle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxObstacle.Location = new System.Drawing.Point(119, 119);
            this.gbxObstacle.Name = "gbxObstacle";
            this.gbxObstacle.Size = new System.Drawing.Size(101, 31);
            this.gbxObstacle.TabIndex = 4;
            this.gbxObstacle.TabStop = false;
            // 
            // rbxObstacleY
            // 
            this.rbxObstacleY.AutoSize = true;
            this.rbxObstacleY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxObstacleY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxObstacleY.Location = new System.Drawing.Point(8, 9);
            this.rbxObstacleY.Name = "rbxObstacleY";
            this.rbxObstacleY.Size = new System.Drawing.Size(37, 17);
            this.rbxObstacleY.TabIndex = 1;
            this.rbxObstacleY.TabStop = true;
            this.rbxObstacleY.Text = "有";
            this.rbxObstacleY.UseVisualStyleBackColor = false;
            this.rbxObstacleY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxObstacleN
            // 
            this.rbxObstacleN.AutoSize = true;
            this.rbxObstacleN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxObstacleN.CheckedValue = "N";
            this.rbxObstacleN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxObstacleN.Location = new System.Drawing.Point(59, 9);
            this.rbxObstacleN.Name = "rbxObstacleN";
            this.rbxObstacleN.Size = new System.Drawing.Size(37, 17);
            this.rbxObstacleN.TabIndex = 2;
            this.rbxObstacleN.TabStop = true;
            this.rbxObstacleN.Text = "無";
            this.rbxObstacleN.UseVisualStyleBackColor = false;
            // 
            // cboSenseLevel
            // 
            this.cboSenseLevel.Location = new System.Drawing.Point(119, 29);
            this.cboSenseLevel.MaxDropDownItems = 20;
            this.cboSenseLevel.Name = "cboSenseLevel";
            this.cboSenseLevel.Size = new System.Drawing.Size(200, 21);
            this.cboSenseLevel.TabIndex = 1;
            // 
            // gbxObstacleSense
            // 
            this.gbxObstacleSense.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxObstacleSense.Controls.Add(this.rbxObstcleSenseY);
            this.gbxObstacleSense.Controls.Add(this.rbxObstcleSenseN);
            this.gbxObstacleSense.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxObstacleSense.Location = new System.Drawing.Point(223, 70);
            this.gbxObstacleSense.Name = "gbxObstacleSense";
            this.gbxObstacleSense.Size = new System.Drawing.Size(112, 31);
            this.gbxObstacleSense.TabIndex = 3;
            this.gbxObstacleSense.TabStop = false;
            // 
            // rbxObstcleSenseY
            // 
            this.rbxObstcleSenseY.AutoSize = true;
            this.rbxObstcleSenseY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxObstcleSenseY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxObstcleSenseY.Location = new System.Drawing.Point(8, 9);
            this.rbxObstcleSenseY.Name = "rbxObstcleSenseY";
            this.rbxObstcleSenseY.Size = new System.Drawing.Size(50, 17);
            this.rbxObstcleSenseY.TabIndex = 1;
            this.rbxObstcleSenseY.TabStop = true;
            this.rbxObstcleSenseY.Text = "感覚";
            this.rbxObstcleSenseY.UseVisualStyleBackColor = false;
            // 
            // rbxObstcleSenseN
            // 
            this.rbxObstcleSenseN.AutoSize = true;
            this.rbxObstcleSenseN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxObstcleSenseN.CheckedValue = "N";
            this.rbxObstcleSenseN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxObstcleSenseN.Location = new System.Drawing.Point(59, 9);
            this.rbxObstcleSenseN.Name = "rbxObstcleSenseN";
            this.rbxObstcleSenseN.Size = new System.Drawing.Size(50, 17);
            this.rbxObstcleSenseN.TabIndex = 2;
            this.rbxObstcleSenseN.TabStop = true;
            this.rbxObstcleSenseN.Text = "構語";
            this.rbxObstcleSenseN.UseVisualStyleBackColor = false;
            // 
            // gbxObstacleSpeech
            // 
            this.gbxObstacleSpeech.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxObstacleSpeech.Controls.Add(this.rbxObstacleSpeechY);
            this.gbxObstacleSpeech.Controls.Add(this.rbxObstacleSpeechN);
            this.gbxObstacleSpeech.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxObstacleSpeech.Location = new System.Drawing.Point(119, 70);
            this.gbxObstacleSpeech.Name = "gbxObstacleSpeech";
            this.gbxObstacleSpeech.Size = new System.Drawing.Size(101, 31);
            this.gbxObstacleSpeech.TabIndex = 2;
            this.gbxObstacleSpeech.TabStop = false;
            // 
            // rbxObstacleSpeechY
            // 
            this.rbxObstacleSpeechY.AutoSize = true;
            this.rbxObstacleSpeechY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxObstacleSpeechY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxObstacleSpeechY.Location = new System.Drawing.Point(8, 9);
            this.rbxObstacleSpeechY.Name = "rbxObstacleSpeechY";
            this.rbxObstacleSpeechY.Size = new System.Drawing.Size(37, 17);
            this.rbxObstacleSpeechY.TabIndex = 1;
            this.rbxObstacleSpeechY.TabStop = true;
            this.rbxObstacleSpeechY.Text = "有";
            this.rbxObstacleSpeechY.UseVisualStyleBackColor = false;
            this.rbxObstacleSpeechY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxObstacleSpeechN
            // 
            this.rbxObstacleSpeechN.AutoSize = true;
            this.rbxObstacleSpeechN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxObstacleSpeechN.CheckedValue = "N";
            this.rbxObstacleSpeechN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxObstacleSpeechN.Location = new System.Drawing.Point(59, 9);
            this.rbxObstacleSpeechN.Name = "rbxObstacleSpeechN";
            this.rbxObstacleSpeechN.Size = new System.Drawing.Size(37, 17);
            this.rbxObstacleSpeechN.TabIndex = 2;
            this.rbxObstacleSpeechN.TabStop = true;
            this.rbxObstacleSpeechN.Text = "無";
            this.rbxObstacleSpeechN.UseVisualStyleBackColor = false;
            // 
            // splitter5
            // 
            this.splitter5.Location = new System.Drawing.Point(0, 0);
            this.splitter5.Margin = new System.Windows.Forms.Padding(0);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(3, 538);
            this.splitter5.TabIndex = 999;
            this.splitter5.TabStop = false;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.xPanel15);
            this.tabPage6.Location = new System.Drawing.Point(0, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Selected = false;
            this.tabPage6.Size = new System.Drawing.Size(841, 538);
            this.tabPage6.TabIndex = 999;
            this.tabPage6.Title = "Ⅶ～.家族構成";
            // 
            // xPanel15
            // 
            this.xPanel15.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xPanel15.Controls.Add(this.xPanel2);
            this.xPanel15.Controls.Add(this.gbxFamily);
            this.xPanel15.Controls.Add(this.txtStressManage);
            this.xPanel15.Controls.Add(this.gbxStress);
            this.xPanel15.Controls.Add(this.xLabel30);
            this.xPanel15.Controls.Add(this.txtStress);
            this.xPanel15.Controls.Add(this.lblStress);
            this.xPanel15.Controls.Add(this.gbxMens);
            this.xPanel15.Controls.Add(this.gbxHobby);
            this.xPanel15.Controls.Add(this.txtHobby);
            this.xPanel15.Controls.Add(this.groupBox22);
            this.xPanel15.Controls.Add(this.lblHobby);
            this.xPanel15.Controls.Add(this.lblBarrierFree);
            this.xPanel15.Controls.Add(this.groupBox21);
            this.xPanel15.Controls.Add(this.gbxReligion);
            this.xPanel15.Controls.Add(this.txtReligion);
            this.xPanel15.Controls.Add(this.txtFamily);
            this.xPanel15.Controls.Add(this.cboHouseKind);
            this.xPanel15.Controls.Add(this.lblFamily);
            this.xPanel15.Controls.Add(this.lblHouse_kind);
            this.xPanel15.Controls.Add(this.lblReligion);
            this.xPanel15.Controls.Add(this.gbxBarrierFree);
            this.xPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel15.DrawBorder = true;
            this.xPanel15.Location = new System.Drawing.Point(0, 0);
            this.xPanel15.Name = "xPanel15";
            this.xPanel15.Size = new System.Drawing.Size(841, 538);
            this.xPanel15.TabIndex = 10;
            // 
            // gbxFamily
            // 
            this.gbxFamily.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxFamily.Controls.Add(this.rbxFamilyY);
            this.gbxFamily.Controls.Add(this.rbxFamilyN);
            this.gbxFamily.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxFamily.Location = new System.Drawing.Point(286, 4);
            this.gbxFamily.Name = "gbxFamily";
            this.gbxFamily.Size = new System.Drawing.Size(115, 31);
            this.gbxFamily.TabIndex = 1;
            this.gbxFamily.TabStop = false;
            // 
            // rbxFamilyY
            // 
            this.rbxFamilyY.AutoSize = true;
            this.rbxFamilyY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxFamilyY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxFamilyY.Location = new System.Drawing.Point(14, 9);
            this.rbxFamilyY.Name = "rbxFamilyY";
            this.rbxFamilyY.Size = new System.Drawing.Size(37, 17);
            this.rbxFamilyY.TabIndex = 1;
            this.rbxFamilyY.TabStop = true;
            this.rbxFamilyY.Text = "有";
            this.rbxFamilyY.UseVisualStyleBackColor = false;
            this.rbxFamilyY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxFamilyN
            // 
            this.rbxFamilyN.AutoSize = true;
            this.rbxFamilyN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxFamilyN.CheckedValue = "N";
            this.rbxFamilyN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxFamilyN.Location = new System.Drawing.Point(65, 9);
            this.rbxFamilyN.Name = "rbxFamilyN";
            this.rbxFamilyN.Size = new System.Drawing.Size(37, 17);
            this.rbxFamilyN.TabIndex = 2;
            this.rbxFamilyN.TabStop = true;
            this.rbxFamilyN.Text = "無";
            this.rbxFamilyN.UseVisualStyleBackColor = false;
            // 
            // txtStressManage
            // 
            this.txtStressManage.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtStressManage.Location = new System.Drawing.Point(420, 208);
            this.txtStressManage.Name = "txtStressManage";
            this.txtStressManage.Size = new System.Drawing.Size(385, 20);
            this.txtStressManage.TabIndex = 12;
            // 
            // gbxStress
            // 
            this.gbxStress.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxStress.Controls.Add(this.rbxStressY);
            this.gbxStress.Controls.Add(this.rbxStressN);
            this.gbxStress.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxStress.Location = new System.Drawing.Point(503, 144);
            this.gbxStress.Name = "gbxStress";
            this.gbxStress.Size = new System.Drawing.Size(108, 31);
            this.gbxStress.TabIndex = 10;
            this.gbxStress.TabStop = false;
            // 
            // rbxStressY
            // 
            this.rbxStressY.AutoSize = true;
            this.rbxStressY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxStressY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxStressY.Location = new System.Drawing.Point(8, 9);
            this.rbxStressY.Name = "rbxStressY";
            this.rbxStressY.Size = new System.Drawing.Size(37, 17);
            this.rbxStressY.TabIndex = 1;
            this.rbxStressY.TabStop = true;
            this.rbxStressY.Text = "有";
            this.rbxStressY.UseVisualStyleBackColor = false;
            this.rbxStressY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxStressN
            // 
            this.rbxStressN.AutoSize = true;
            this.rbxStressN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxStressN.CheckedValue = "N";
            this.rbxStressN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxStressN.Location = new System.Drawing.Point(64, 9);
            this.rbxStressN.Name = "rbxStressN";
            this.rbxStressN.Size = new System.Drawing.Size(37, 17);
            this.rbxStressN.TabIndex = 2;
            this.rbxStressN.TabStop = true;
            this.rbxStressN.Text = "無";
            this.rbxStressN.UseVisualStyleBackColor = false;
            // 
            // xLabel30
            // 
            this.xLabel30.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel30.EdgeRounding = false;
            this.xLabel30.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel30.Location = new System.Drawing.Point(420, 180);
            this.xLabel30.Name = "xLabel30";
            this.xLabel30.Size = new System.Drawing.Size(161, 24);
            this.xLabel30.TabIndex = 999;
            this.xLabel30.Text = "ストレスに対する対処方法";
            this.xLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStress
            // 
            this.txtStress.Enabled = false;
            this.txtStress.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtStress.Location = new System.Drawing.Point(613, 152);
            this.txtStress.Name = "txtStress";
            this.txtStress.Size = new System.Drawing.Size(192, 20);
            this.txtStress.TabIndex = 11;
            // 
            // lblStress
            // 
            this.lblStress.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblStress.EdgeRounding = false;
            this.lblStress.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblStress.Location = new System.Drawing.Point(420, 149);
            this.lblStress.Name = "lblStress";
            this.lblStress.Size = new System.Drawing.Size(77, 24);
            this.lblStress.TabIndex = 999;
            this.lblStress.Text = "ストレス";
            this.lblStress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStress.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // gbxMens
            // 
            this.gbxMens.Controls.Add(this.txtMensesAge);
            this.gbxMens.Controls.Add(this.gbxPregnancy);
            this.gbxMens.Controls.Add(this.lblPregnancy);
            this.gbxMens.Controls.Add(this.gbxMensesProblem);
            this.gbxMens.Controls.Add(this.txtMensesProblem);
            this.gbxMens.Controls.Add(this.cboMenses);
            this.gbxMens.Controls.Add(this.lblMensesProblem);
            this.gbxMens.Controls.Add(this.xLabel166);
            this.gbxMens.Controls.Add(this.xLabel31);
            this.gbxMens.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxMens.Location = new System.Drawing.Point(415, 6);
            this.gbxMens.Name = "gbxMens";
            this.gbxMens.Size = new System.Drawing.Size(390, 110);
            this.gbxMens.TabIndex = 7;
            this.gbxMens.TabStop = false;
            this.gbxMens.Text = "女性";
            // 
            // txtMensesAge
            // 
            this.txtMensesAge.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtMensesAge.Location = new System.Drawing.Point(251, 21);
            this.txtMensesAge.Name = "txtMensesAge";
            this.txtMensesAge.Size = new System.Drawing.Size(67, 20);
            this.txtMensesAge.TabIndex = 2;
            this.txtMensesAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbxPregnancy
            // 
            this.gbxPregnancy.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxPregnancy.Controls.Add(this.rbxPregnancyY);
            this.gbxPregnancy.Controls.Add(this.rbxPregnancyN);
            this.gbxPregnancy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxPregnancy.Location = new System.Drawing.Point(137, 72);
            this.gbxPregnancy.Name = "gbxPregnancy";
            this.gbxPregnancy.Size = new System.Drawing.Size(123, 31);
            this.gbxPregnancy.TabIndex = 5;
            this.gbxPregnancy.TabStop = false;
            // 
            // rbxPregnancyY
            // 
            this.rbxPregnancyY.AutoSize = true;
            this.rbxPregnancyY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxPregnancyY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxPregnancyY.Location = new System.Drawing.Point(8, 9);
            this.rbxPregnancyY.Name = "rbxPregnancyY";
            this.rbxPregnancyY.Size = new System.Drawing.Size(46, 17);
            this.rbxPregnancyY.TabIndex = 1;
            this.rbxPregnancyY.TabStop = true;
            this.rbxPregnancyY.Text = "はい";
            this.rbxPregnancyY.UseVisualStyleBackColor = false;
            // 
            // rbxPregnancyN
            // 
            this.rbxPregnancyN.AutoSize = true;
            this.rbxPregnancyN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxPregnancyN.CheckedValue = "N";
            this.rbxPregnancyN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxPregnancyN.Location = new System.Drawing.Point(64, 9);
            this.rbxPregnancyN.Name = "rbxPregnancyN";
            this.rbxPregnancyN.Size = new System.Drawing.Size(56, 17);
            this.rbxPregnancyN.TabIndex = 2;
            this.rbxPregnancyN.TabStop = true;
            this.rbxPregnancyN.Text = "いいえ";
            this.rbxPregnancyN.UseVisualStyleBackColor = false;
            // 
            // lblPregnancy
            // 
            this.lblPregnancy.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblPregnancy.EdgeRounding = false;
            this.lblPregnancy.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblPregnancy.Location = new System.Drawing.Point(12, 77);
            this.lblPregnancy.Name = "lblPregnancy";
            this.lblPregnancy.Size = new System.Drawing.Size(120, 24);
            this.lblPregnancy.TabIndex = 999;
            this.lblPregnancy.Text = "妊　　娠";
            this.lblPregnancy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPregnancy.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // gbxMensesProblem
            // 
            this.gbxMensesProblem.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxMensesProblem.Controls.Add(this.rbxMensesProblemY);
            this.gbxMensesProblem.Controls.Add(this.rbxMensesProblemN);
            this.gbxMensesProblem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxMensesProblem.Location = new System.Drawing.Point(136, 42);
            this.gbxMensesProblem.Name = "gbxMensesProblem";
            this.gbxMensesProblem.Size = new System.Drawing.Size(108, 31);
            this.gbxMensesProblem.TabIndex = 3;
            this.gbxMensesProblem.TabStop = false;
            // 
            // rbxMensesProblemY
            // 
            this.rbxMensesProblemY.AutoSize = true;
            this.rbxMensesProblemY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxMensesProblemY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxMensesProblemY.Location = new System.Drawing.Point(8, 9);
            this.rbxMensesProblemY.Name = "rbxMensesProblemY";
            this.rbxMensesProblemY.Size = new System.Drawing.Size(37, 17);
            this.rbxMensesProblemY.TabIndex = 1;
            this.rbxMensesProblemY.TabStop = true;
            this.rbxMensesProblemY.Text = "有";
            this.rbxMensesProblemY.UseVisualStyleBackColor = false;
            this.rbxMensesProblemY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxMensesProblemN
            // 
            this.rbxMensesProblemN.AutoSize = true;
            this.rbxMensesProblemN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxMensesProblemN.CheckedValue = "N";
            this.rbxMensesProblemN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxMensesProblemN.Location = new System.Drawing.Point(64, 9);
            this.rbxMensesProblemN.Name = "rbxMensesProblemN";
            this.rbxMensesProblemN.Size = new System.Drawing.Size(37, 17);
            this.rbxMensesProblemN.TabIndex = 2;
            this.rbxMensesProblemN.TabStop = true;
            this.rbxMensesProblemN.Text = "無";
            this.rbxMensesProblemN.UseVisualStyleBackColor = false;
            // 
            // txtMensesProblem
            // 
            this.txtMensesProblem.Enabled = false;
            this.txtMensesProblem.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtMensesProblem.Location = new System.Drawing.Point(251, 49);
            this.txtMensesProblem.Name = "txtMensesProblem";
            this.txtMensesProblem.Size = new System.Drawing.Size(133, 20);
            this.txtMensesProblem.TabIndex = 4;
            // 
            // cboMenses
            // 
            this.cboMenses.Location = new System.Drawing.Point(137, 20);
            this.cboMenses.Name = "cboMenses";
            this.cboMenses.Size = new System.Drawing.Size(108, 21);
            this.cboMenses.TabIndex = 1;
            // 
            // lblMensesProblem
            // 
            this.lblMensesProblem.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblMensesProblem.EdgeRounding = false;
            this.lblMensesProblem.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblMensesProblem.Location = new System.Drawing.Point(11, 47);
            this.lblMensesProblem.Name = "lblMensesProblem";
            this.lblMensesProblem.Size = new System.Drawing.Size(120, 24);
            this.lblMensesProblem.TabIndex = 999;
            this.lblMensesProblem.Text = "月経による問題";
            this.lblMensesProblem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensesProblem.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // xLabel166
            // 
            this.xLabel166.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel166.EdgeRounding = false;
            this.xLabel166.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel166.Location = new System.Drawing.Point(11, 18);
            this.xLabel166.Name = "xLabel166";
            this.xLabel166.Size = new System.Drawing.Size(120, 24);
            this.xLabel166.TabIndex = 999;
            this.xLabel166.Text = "月　　経";
            this.xLabel166.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel31
            // 
            this.xLabel31.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel31.BorderColor = IHIS.Framework.XColor.XPanelBackColor;
            this.xLabel31.Location = new System.Drawing.Point(316, 20);
            this.xLabel31.Name = "xLabel31";
            this.xLabel31.Size = new System.Drawing.Size(23, 24);
            this.xLabel31.TabIndex = 999;
            this.xLabel31.Text = "才";
            this.xLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxHobby
            // 
            this.gbxHobby.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxHobby.Controls.Add(this.rbxHobbyY);
            this.gbxHobby.Controls.Add(this.rbxHobbyN);
            this.gbxHobby.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxHobby.Location = new System.Drawing.Point(503, 114);
            this.gbxHobby.Name = "gbxHobby";
            this.gbxHobby.Size = new System.Drawing.Size(108, 31);
            this.gbxHobby.TabIndex = 8;
            this.gbxHobby.TabStop = false;
            // 
            // rbxHobbyY
            // 
            this.rbxHobbyY.AutoSize = true;
            this.rbxHobbyY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxHobbyY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxHobbyY.Location = new System.Drawing.Point(8, 9);
            this.rbxHobbyY.Name = "rbxHobbyY";
            this.rbxHobbyY.Size = new System.Drawing.Size(37, 17);
            this.rbxHobbyY.TabIndex = 1;
            this.rbxHobbyY.TabStop = true;
            this.rbxHobbyY.Text = "有";
            this.rbxHobbyY.UseVisualStyleBackColor = false;
            this.rbxHobbyY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxHobbyN
            // 
            this.rbxHobbyN.AutoSize = true;
            this.rbxHobbyN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxHobbyN.CheckedValue = "N";
            this.rbxHobbyN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxHobbyN.Location = new System.Drawing.Point(64, 9);
            this.rbxHobbyN.Name = "rbxHobbyN";
            this.rbxHobbyN.Size = new System.Drawing.Size(37, 17);
            this.rbxHobbyN.TabIndex = 2;
            this.rbxHobbyN.TabStop = true;
            this.rbxHobbyN.Text = "無";
            this.rbxHobbyN.UseVisualStyleBackColor = false;
            // 
            // txtHobby
            // 
            this.txtHobby.Enabled = false;
            this.txtHobby.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtHobby.Location = new System.Drawing.Point(613, 122);
            this.txtHobby.Name = "txtHobby";
            this.txtHobby.Size = new System.Drawing.Size(192, 20);
            this.txtHobby.TabIndex = 9;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.txtJobMate);
            this.groupBox22.Controls.Add(this.txtJob);
            this.groupBox22.Controls.Add(this.xLabel163);
            this.groupBox22.Controls.Add(this.xLabel162);
            this.groupBox22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox22.Location = new System.Drawing.Point(11, 69);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(390, 83);
            this.groupBox22.TabIndex = 3;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "職業";
            // 
            // txtJobMate
            // 
            this.txtJobMate.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtJobMate.Location = new System.Drawing.Point(137, 49);
            this.txtJobMate.Name = "txtJobMate";
            this.txtJobMate.Size = new System.Drawing.Size(238, 20);
            this.txtJobMate.TabIndex = 2;
            // 
            // txtJob
            // 
            this.txtJob.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtJob.Location = new System.Drawing.Point(137, 20);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(238, 20);
            this.txtJob.TabIndex = 1;
            // 
            // xLabel163
            // 
            this.xLabel163.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel163.EdgeRounding = false;
            this.xLabel163.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel163.Location = new System.Drawing.Point(11, 47);
            this.xLabel163.Name = "xLabel163";
            this.xLabel163.Size = new System.Drawing.Size(120, 24);
            this.xLabel163.TabIndex = 999;
            this.xLabel163.Text = "配偶者";
            this.xLabel163.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel162
            // 
            this.xLabel162.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel162.EdgeRounding = false;
            this.xLabel162.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel162.Location = new System.Drawing.Point(11, 18);
            this.xLabel162.Name = "xLabel162";
            this.xLabel162.Size = new System.Drawing.Size(120, 24);
            this.xLabel162.TabIndex = 999;
            this.xLabel162.Text = "本　　人";
            this.xLabel162.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHobby
            // 
            this.lblHobby.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHobby.EdgeRounding = false;
            this.lblHobby.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHobby.Location = new System.Drawing.Point(418, 120);
            this.lblHobby.Name = "lblHobby";
            this.lblHobby.Size = new System.Drawing.Size(79, 24);
            this.lblHobby.TabIndex = 999;
            this.lblHobby.Text = "趣味";
            this.lblHobby.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHobby.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblBarrierFree
            // 
            this.lblBarrierFree.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBarrierFree.EdgeRounding = false;
            this.lblBarrierFree.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBarrierFree.Location = new System.Drawing.Point(199, 157);
            this.lblBarrierFree.Name = "lblBarrierFree";
            this.lblBarrierFree.Size = new System.Drawing.Size(84, 24);
            this.lblBarrierFree.TabIndex = 999;
            this.lblBarrierFree.Text = "バリアフリー";
            this.lblBarrierFree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBarrierFree.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.txtAssessment7);
            this.groupBox21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox21.Location = new System.Drawing.Point(13, 187);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(380, 79);
            this.groupBox21.TabIndex = 6;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "備考";
            // 
            // txtAssessment7
            // 
            this.txtAssessment7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAssessment7.EnterKeyToTab = false;
            this.txtAssessment7.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAssessment7.Location = new System.Drawing.Point(3, 16);
            this.txtAssessment7.MaxLength = 4000;
            this.txtAssessment7.Name = "txtAssessment7";
            this.txtAssessment7.Size = new System.Drawing.Size(374, 60);
            this.txtAssessment7.TabIndex = 999;
            this.txtAssessment7.Text = "";
            // 
            // gbxReligion
            // 
            this.gbxReligion.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxReligion.Controls.Add(this.rbxReligionY);
            this.gbxReligion.Controls.Add(this.rbxReligionN);
            this.gbxReligion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxReligion.Location = new System.Drawing.Point(545, 235);
            this.gbxReligion.Name = "gbxReligion";
            this.gbxReligion.Size = new System.Drawing.Size(108, 31);
            this.gbxReligion.TabIndex = 13;
            this.gbxReligion.TabStop = false;
            // 
            // rbxReligionY
            // 
            this.rbxReligionY.AutoSize = true;
            this.rbxReligionY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxReligionY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxReligionY.Location = new System.Drawing.Point(8, 9);
            this.rbxReligionY.Name = "rbxReligionY";
            this.rbxReligionY.Size = new System.Drawing.Size(37, 17);
            this.rbxReligionY.TabIndex = 1;
            this.rbxReligionY.TabStop = true;
            this.rbxReligionY.Text = "有";
            this.rbxReligionY.UseVisualStyleBackColor = false;
            this.rbxReligionY.CheckedChanged += new System.EventHandler(this.rbxCheckedChanged);
            // 
            // rbxReligionN
            // 
            this.rbxReligionN.AutoSize = true;
            this.rbxReligionN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxReligionN.CheckedValue = "N";
            this.rbxReligionN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxReligionN.Location = new System.Drawing.Point(64, 9);
            this.rbxReligionN.Name = "rbxReligionN";
            this.rbxReligionN.Size = new System.Drawing.Size(37, 17);
            this.rbxReligionN.TabIndex = 2;
            this.rbxReligionN.TabStop = true;
            this.rbxReligionN.Text = "無";
            this.rbxReligionN.UseVisualStyleBackColor = false;
            // 
            // txtReligion
            // 
            this.txtReligion.Enabled = false;
            this.txtReligion.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtReligion.Location = new System.Drawing.Point(655, 242);
            this.txtReligion.Name = "txtReligion";
            this.txtReligion.Size = new System.Drawing.Size(150, 20);
            this.txtReligion.TabIndex = 14;
            // 
            // txtFamily
            // 
            this.txtFamily.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFamily.Location = new System.Drawing.Point(11, 41);
            this.txtFamily.Name = "txtFamily";
            this.txtFamily.Size = new System.Drawing.Size(390, 20);
            this.txtFamily.TabIndex = 2;
            // 
            // cboHouseKind
            // 
            this.cboHouseKind.Location = new System.Drawing.Point(96, 159);
            this.cboHouseKind.MaxDropDownItems = 50;
            this.cboHouseKind.Name = "cboHouseKind";
            this.cboHouseKind.Size = new System.Drawing.Size(96, 21);
            this.cboHouseKind.TabIndex = 4;
            // 
            // lblFamily
            // 
            this.lblFamily.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblFamily.EdgeRounding = false;
            this.lblFamily.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblFamily.Location = new System.Drawing.Point(12, 9);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(271, 24);
            this.lblFamily.TabIndex = 999;
            this.lblFamily.Text = "入院中、協力してくれる家族はいるか";
            this.lblFamily.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFamily.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblHouse_kind
            // 
            this.lblHouse_kind.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHouse_kind.EdgeRounding = false;
            this.lblHouse_kind.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHouse_kind.Location = new System.Drawing.Point(12, 157);
            this.lblHouse_kind.Name = "lblHouse_kind";
            this.lblHouse_kind.Size = new System.Drawing.Size(79, 24);
            this.lblHouse_kind.TabIndex = 999;
            this.lblHouse_kind.Text = "住まい";
            this.lblHouse_kind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReligion
            // 
            this.lblReligion.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblReligion.EdgeRounding = false;
            this.lblReligion.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblReligion.Location = new System.Drawing.Point(420, 240);
            this.lblReligion.Name = "lblReligion";
            this.lblReligion.Size = new System.Drawing.Size(120, 24);
            this.lblReligion.TabIndex = 999;
            this.lblReligion.Text = "信仰している宗教";
            this.lblReligion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReligion.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // gbxBarrierFree
            // 
            this.gbxBarrierFree.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.gbxBarrierFree.Controls.Add(this.rbxBarrierFreeY);
            this.gbxBarrierFree.Controls.Add(this.rbxBarrierFreeN);
            this.gbxBarrierFree.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxBarrierFree.Location = new System.Drawing.Point(286, 152);
            this.gbxBarrierFree.Name = "gbxBarrierFree";
            this.gbxBarrierFree.Size = new System.Drawing.Size(115, 30);
            this.gbxBarrierFree.TabIndex = 5;
            this.gbxBarrierFree.TabStop = false;
            // 
            // rbxBarrierFreeY
            // 
            this.rbxBarrierFreeY.AutoSize = true;
            this.rbxBarrierFreeY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxBarrierFreeY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxBarrierFreeY.Location = new System.Drawing.Point(8, 9);
            this.rbxBarrierFreeY.Name = "rbxBarrierFreeY";
            this.rbxBarrierFreeY.Size = new System.Drawing.Size(46, 17);
            this.rbxBarrierFreeY.TabIndex = 1;
            this.rbxBarrierFreeY.TabStop = true;
            this.rbxBarrierFreeY.Text = "はい";
            this.rbxBarrierFreeY.UseVisualStyleBackColor = false;
            // 
            // rbxBarrierFreeN
            // 
            this.rbxBarrierFreeN.AutoSize = true;
            this.rbxBarrierFreeN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.rbxBarrierFreeN.CheckedValue = "N";
            this.rbxBarrierFreeN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbxBarrierFreeN.Location = new System.Drawing.Point(54, 9);
            this.rbxBarrierFreeN.Name = "rbxBarrierFreeN";
            this.rbxBarrierFreeN.Size = new System.Drawing.Size(56, 17);
            this.rbxBarrierFreeN.TabIndex = 2;
            this.rbxBarrierFreeN.TabStop = true;
            this.rbxBarrierFreeN.Text = "いいえ";
            this.rbxBarrierFreeN.UseVisualStyleBackColor = false;
            // 
            // xEditMask1
            // 
            this.xEditMask1.Location = new System.Drawing.Point(192, 68);
            this.xEditMask1.Name = "xEditMask1";
            this.xEditMask1.Size = new System.Drawing.Size(62, 20);
            this.xEditMask1.TabIndex = 999;
            // 
            // layComboSet
            // 
            this.layComboSet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem7});
            this.layComboSet.QuerySQL = "SELECT CODE,\r\n       CODE_NAME,\r\n       CODE_TYPE,\r\n       SORT_KEY\r\n  FROM NUR01" +
                "02\r\n WHERE HOSP_CODE = :f_hosp_code\r\n  -- AND CODE_TYPE = :f_code_type\r\n ORDER B" +
                "Y 4, 1";
            this.layComboSet.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layComboSet_QueryStarting);
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "code_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "code_type";
            // 
            // grdINP1001
            // 
            this.grdINP1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell8,
            this.xEditGridCell13,
            this.xEditGridCell22});
            this.grdINP1001.ColPerLine = 3;
            this.grdINP1001.Cols = 4;
            this.grdINP1001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1001.FixedCols = 1;
            this.grdINP1001.FixedRows = 1;
            this.grdINP1001.HeaderHeights.Add(25);
            this.grdINP1001.Location = new System.Drawing.Point(0, 0);
            this.grdINP1001.Name = "grdINP1001";
            this.grdINP1001.QuerySQL = resources.GetString("grdINP1001.QuerySQL");
            this.grdINP1001.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdINP1001.RowHeaderVisible = true;
            this.grdINP1001.Rows = 2;
            this.grdINP1001.RowStateCheckOnPaint = false;
            this.grdINP1001.Size = new System.Drawing.Size(313, 565);
            this.grdINP1001.TabIndex = 999;
            this.grdINP1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdInp1001_QueryStarting);
            this.grdINP1001.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdInp1001_GridButtonClick);
            this.grdINP1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdInp1001_RowFocusChanged);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "bunho";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "환자번호";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "ipwon_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 117;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "入院日付";
            this.xEditGridCell7.IsJapanYearType = true;
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "toiwon_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.CellWidth = 117;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "退院日付";
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jaewon_flag";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "재원여부";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "fkinp1001";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "입원키";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "ho_dong";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "ho_dong";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell22.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell22.ButtonImage")));
            this.xEditGridCell22.CellName = "copy";
            this.xEditGridCell22.CellWidth = 33;
            this.xEditGridCell22.Col = 3;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell22.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell22.HeaderText = "コピー";
            this.xEditGridCell22.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdINP1001);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel1.Location = new System.Drawing.Point(0, 33);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(313, 565);
            this.xPanel1.TabIndex = 999;
            // 
            // layINP1001
            // 
            this.layINP1001.CallerID = 'A';
            this.layINP1001.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem146,
            this.singleLayoutItem147,
            this.singleLayoutItem148,
            this.singleLayoutItem150,
            this.singleLayoutItem151,
            this.singleLayoutItem153,
            this.singleLayoutItem154,
            this.singleLayoutItem155,
            this.singleLayoutItem156,
            this.singleLayoutItem157,
            this.singleLayoutItem320,
            this.singleLayoutItem424,
            this.singleLayoutItem168,
            this.singleLayoutItem169});
            this.layINP1001.QuerySQL = resources.GetString("layINP1001.QuerySQL");
            this.layINP1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layINP1001_QueryStarting);
            // 
            // singleLayoutItem146
            // 
            this.singleLayoutItem146.BindControl = this.dbxAddress;
            this.singleLayoutItem146.DataName = "address";
            // 
            // singleLayoutItem147
            // 
            this.singleLayoutItem147.BindControl = this.dbxTel;
            this.singleLayoutItem147.DataName = "tel";
            // 
            // singleLayoutItem148
            // 
            this.singleLayoutItem148.BindControl = this.dbxHoken;
            this.singleLayoutItem148.DataName = "gubun_name";
            // 
            // singleLayoutItem150
            // 
            this.singleLayoutItem150.BindControl = this.dtpIndate;
            this.singleLayoutItem150.DataName = "indate";
            // 
            // singleLayoutItem151
            // 
            this.singleLayoutItem151.BindControl = this.dtpOutdate;
            this.singleLayoutItem151.DataName = "outdate";
            // 
            // singleLayoutItem153
            // 
            this.singleLayoutItem153.BindControl = this.dbxGwa;
            this.singleLayoutItem153.DataName = "gwa_name";
            // 
            // singleLayoutItem154
            // 
            this.singleLayoutItem154.BindControl = this.dbxDoctor;
            this.singleLayoutItem154.DataName = "doctor_name";
            // 
            // singleLayoutItem155
            // 
            this.singleLayoutItem155.BindControl = this.dbxHo_Dong;
            this.singleLayoutItem155.DataName = "ho_dong_name";
            // 
            // singleLayoutItem156
            // 
            this.singleLayoutItem156.BindControl = this.dbxHo_Code;
            this.singleLayoutItem156.DataName = "ho_code";
            // 
            // singleLayoutItem157
            // 
            this.singleLayoutItem157.BindControl = this.dbxBed;
            this.singleLayoutItem157.DataName = "bed_no";
            // 
            // singleLayoutItem320
            // 
            this.singleLayoutItem320.DataName = "ho_dong";
            // 
            // singleLayoutItem424
            // 
            this.singleLayoutItem424.DataName = "gwa";
            // 
            // singleLayoutItem168
            // 
            this.singleLayoutItem168.BindControl = this.dbxNurse;
            this.singleLayoutItem168.DataName = "dbxnurse";
            // 
            // singleLayoutItem169
            // 
            this.singleLayoutItem169.BindControl = this.dbxTeam;
            this.singleLayoutItem169.DataName = "dbxteam";
            // 
            // layNUR1001
            // 
            this.layNUR1001.CallerID = 'M';
            this.layNUR1001.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem318,
            this.singleLayoutItem319,
            this.singleLayoutItem325,
            this.singleLayoutItem149,
            this.singleLayoutItem2,
            this.singleLayoutItem152,
            this.singleLayoutItem158,
            this.singleLayoutItem159,
            this.singleLayoutItem161,
            this.singleLayoutItem162,
            this.singleLayoutItem163,
            this.singleLayoutItem3,
            this.singleLayoutItem164,
            this.singleLayoutItem165,
            this.singleLayoutItem166,
            this.singleLayoutItem167,
            this.singleLayoutItem170,
            this.singleLayoutItem171,
            this.singleLayoutItem172,
            this.singleLayoutItem173,
            this.singleLayoutItem174,
            this.singleLayoutItem175,
            this.singleLayoutItem176,
            this.singleLayoutItem177,
            this.singleLayoutItem178,
            this.singleLayoutItem179,
            this.singleLayoutItem180,
            this.singleLayoutItem181,
            this.singleLayoutItem182,
            this.singleLayoutItem183,
            this.singleLayoutItem184,
            this.singleLayoutItem185,
            this.singleLayoutItem186,
            this.singleLayoutItem187,
            this.singleLayoutItem188,
            this.singleLayoutItem189,
            this.singleLayoutItem190,
            this.singleLayoutItem191,
            this.singleLayoutItem192,
            this.singleLayoutItem193,
            this.singleLayoutItem194,
            this.singleLayoutItem195,
            this.singleLayoutItem196,
            this.singleLayoutItem197,
            this.singleLayoutItem198,
            this.singleLayoutItem199,
            this.singleLayoutItem1,
            this.singleLayoutItem200,
            this.singleLayoutItem201,
            this.singleLayoutItem202,
            this.singleLayoutItem203,
            this.singleLayoutItem204,
            this.singleLayoutItem205,
            this.singleLayoutItem206,
            this.singleLayoutItem316,
            this.singleLayoutItem207,
            this.singleLayoutItem208,
            this.singleLayoutItem209,
            this.singleLayoutItem210,
            this.singleLayoutItem211,
            this.singleLayoutItem212,
            this.singleLayoutItem213,
            this.singleLayoutItem214,
            this.singleLayoutItem215,
            this.singleLayoutItem216,
            this.singleLayoutItem217,
            this.singleLayoutItem218,
            this.singleLayoutItem219,
            this.singleLayoutItem220,
            this.singleLayoutItem221,
            this.singleLayoutItem222,
            this.singleLayoutItem223,
            this.singleLayoutItem224,
            this.singleLayoutItem225,
            this.singleLayoutItem226,
            this.singleLayoutItem227,
            this.singleLayoutItem228,
            this.singleLayoutItem229,
            this.singleLayoutItem230,
            this.singleLayoutItem231,
            this.singleLayoutItem232,
            this.singleLayoutItem233,
            this.singleLayoutItem234,
            this.singleLayoutItem235,
            this.singleLayoutItem236,
            this.singleLayoutItem237,
            this.singleLayoutItem238,
            this.singleLayoutItem239,
            this.singleLayoutItem240,
            this.singleLayoutItem241,
            this.singleLayoutItem242,
            this.singleLayoutItem243,
            this.singleLayoutItem244,
            this.singleLayoutItem245,
            this.singleLayoutItem246,
            this.singleLayoutItem247,
            this.singleLayoutItem248,
            this.singleLayoutItem249,
            this.singleLayoutItem250,
            this.singleLayoutItem251,
            this.singleLayoutItem252,
            this.singleLayoutItem253,
            this.singleLayoutItem254,
            this.singleLayoutItem255,
            this.singleLayoutItem256,
            this.singleLayoutItem257,
            this.singleLayoutItem258,
            this.singleLayoutItem259,
            this.singleLayoutItem260,
            this.singleLayoutItem261,
            this.singleLayoutItem262,
            this.singleLayoutItem263,
            this.singleLayoutItem264,
            this.singleLayoutItem265,
            this.singleLayoutItem266,
            this.singleLayoutItem267,
            this.singleLayoutItem268,
            this.singleLayoutItem269,
            this.singleLayoutItem270,
            this.singleLayoutItem271,
            this.singleLayoutItem272,
            this.singleLayoutItem273,
            this.singleLayoutItem274,
            this.singleLayoutItem275,
            this.singleLayoutItem276,
            this.singleLayoutItem277,
            this.singleLayoutItem278,
            this.singleLayoutItem279,
            this.singleLayoutItem280,
            this.singleLayoutItem281,
            this.singleLayoutItem282,
            this.singleLayoutItem283,
            this.singleLayoutItem284,
            this.singleLayoutItem285,
            this.singleLayoutItem286,
            this.singleLayoutItem287,
            this.singleLayoutItem288,
            this.singleLayoutItem289,
            this.singleLayoutItem290,
            this.singleLayoutItem291,
            this.singleLayoutItem292,
            this.singleLayoutItem293,
            this.singleLayoutItem294,
            this.singleLayoutItem295,
            this.singleLayoutItem296,
            this.singleLayoutItem297,
            this.singleLayoutItem298,
            this.singleLayoutItem299,
            this.singleLayoutItem300,
            this.singleLayoutItem301,
            this.singleLayoutItem302,
            this.singleLayoutItem303,
            this.singleLayoutItem304,
            this.singleLayoutItem305,
            this.singleLayoutItem306,
            this.singleLayoutItem307,
            this.singleLayoutItem308,
            this.singleLayoutItem309,
            this.singleLayoutItem310,
            this.singleLayoutItem311,
            this.singleLayoutItem312,
            this.singleLayoutItem317,
            this.singleLayoutItem313,
            this.singleLayoutItem314,
            this.singleLayoutItem315,
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem11,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17});
            this.layNUR1001.QuerySQL = resources.GetString("layNUR1001.QuerySQL");
            this.layNUR1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR1001_QueryStarting);
            this.layNUR1001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layNUR1001_QueryEnd);
            this.layNUR1001.SaveStarting += new System.ComponentModel.CancelEventHandler(this.layNUR1001_SaveStarting);
            // 
            // singleLayoutItem318
            // 
            this.singleLayoutItem318.DataName = "hosp_code";
            this.singleLayoutItem318.IsUpdItem = true;
            // 
            // singleLayoutItem319
            // 
            this.singleLayoutItem319.DataName = "bunho";
            this.singleLayoutItem319.IsUpdItem = true;
            // 
            // singleLayoutItem325
            // 
            this.singleLayoutItem325.DataName = "fkinp1001";
            this.singleLayoutItem325.IsUpdItem = true;
            // 
            // singleLayoutItem149
            // 
            this.singleLayoutItem149.BindControl = this.cboBloodTypeABO;
            this.singleLayoutItem149.DataName = "blood_type_abo";
            this.singleLayoutItem149.IsUpdItem = true;
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.cboBloodTypeRh;
            this.singleLayoutItem2.DataName = "blood_type_rh";
            this.singleLayoutItem2.IsUpdItem = true;
            // 
            // singleLayoutItem152
            // 
            this.singleLayoutItem152.BindControl = this.cboPurpose;
            this.singleLayoutItem152.DataName = "purpose";
            this.singleLayoutItem152.IsUpdItem = true;
            // 
            // singleLayoutItem158
            // 
            this.singleLayoutItem158.BindControl = this.txtInformant;
            this.singleLayoutItem158.DataName = "informant";
            this.singleLayoutItem158.IsUpdItem = true;
            // 
            // singleLayoutItem159
            // 
            this.singleLayoutItem159.BindControl = this.txtKeyName1;
            this.singleLayoutItem159.DataName = "key_name1";
            this.singleLayoutItem159.IsUpdItem = true;
            // 
            // singleLayoutItem161
            // 
            this.singleLayoutItem161.BindControl = this.txtKeyRelation1;
            this.singleLayoutItem161.DataName = "key_relation1";
            this.singleLayoutItem161.IsUpdItem = true;
            // 
            // singleLayoutItem162
            // 
            this.singleLayoutItem162.BindControl = this.txtKeyHome1;
            this.singleLayoutItem162.DataName = "key_home1";
            this.singleLayoutItem162.IsUpdItem = true;
            // 
            // singleLayoutItem163
            // 
            this.singleLayoutItem163.BindControl = this.fbxWriter;
            this.singleLayoutItem163.DataName = "writer";
            this.singleLayoutItem163.IsUpdItem = true;
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.BindControl = this.dbxWriter;
            this.singleLayoutItem3.DataName = "writer_name";
            // 
            // singleLayoutItem164
            // 
            this.singleLayoutItem164.BindControl = this.mbxDiagnosisName;
            this.singleLayoutItem164.DataName = "diagnosis_name";
            this.singleLayoutItem164.IsUpdItem = true;
            // 
            // singleLayoutItem165
            // 
            this.singleLayoutItem165.BindControl = this.cboDignosisGubun;
            this.singleLayoutItem165.DataName = "diagnosis_gubun";
            this.singleLayoutItem165.IsUpdItem = true;
            // 
            // singleLayoutItem166
            // 
            this.singleLayoutItem166.BindControl = this.txtInpatientCourse;
            this.singleLayoutItem166.DataName = "inpatient_course";
            this.singleLayoutItem166.IsUpdItem = true;
            // 
            // singleLayoutItem167
            // 
            this.singleLayoutItem167.BindControl = this.txtAssessment0;
            this.singleLayoutItem167.DataName = "assessment_0";
            this.singleLayoutItem167.IsUpdItem = true;
            // 
            // singleLayoutItem170
            // 
            this.singleLayoutItem170.BindControl = this.mbxPastHis;
            this.singleLayoutItem170.DataName = "past_his";
            this.singleLayoutItem170.IsUpdItem = true;
            // 
            // singleLayoutItem171
            // 
            this.singleLayoutItem171.BindControl = this.gbxBringDrug;
            this.singleLayoutItem171.DataName = "bring_drug_yn";
            this.singleLayoutItem171.IsUpdItem = true;
            // 
            // singleLayoutItem172
            // 
            this.singleLayoutItem172.BindControl = this.mbxBringDrugComment;
            this.singleLayoutItem172.DataName = "bring_drug_comment";
            this.singleLayoutItem172.IsUpdItem = true;
            // 
            // singleLayoutItem173
            // 
            this.singleLayoutItem173.BindControl = this.gbxHealthCare;
            this.singleLayoutItem173.DataName = "healthcare_yn";
            this.singleLayoutItem173.IsUpdItem = true;
            // 
            // singleLayoutItem174
            // 
            this.singleLayoutItem174.BindControl = this.mbxHealthcare;
            this.singleLayoutItem174.DataName = "healthcare_comment";
            this.singleLayoutItem174.IsUpdItem = true;
            // 
            // singleLayoutItem175
            // 
            this.singleLayoutItem175.BindControl = this.nudSmoking;
            this.singleLayoutItem175.DataName = "smoking_day";
            this.singleLayoutItem175.IsUpdItem = true;
            // 
            // singleLayoutItem176
            // 
            this.singleLayoutItem176.BindControl = this.txtDrinking;
            this.singleLayoutItem176.DataName = "drinking";
            this.singleLayoutItem176.IsUpdItem = true;
            // 
            // singleLayoutItem177
            // 
            this.singleLayoutItem177.BindControl = this.txtExplainD;
            this.singleLayoutItem177.DataName = "explain_doctor";
            this.singleLayoutItem177.IsUpdItem = true;
            // 
            // singleLayoutItem178
            // 
            this.singleLayoutItem178.BindControl = this.txtExplainP;
            this.singleLayoutItem178.DataName = "explain_patient";
            this.singleLayoutItem178.IsUpdItem = true;
            // 
            // singleLayoutItem179
            // 
            this.singleLayoutItem179.BindControl = this.txtExplainF;
            this.singleLayoutItem179.DataName = "explain_family";
            this.singleLayoutItem179.IsUpdItem = true;
            // 
            // singleLayoutItem180
            // 
            this.singleLayoutItem180.BindControl = this.txtAssessment1;
            this.singleLayoutItem180.DataName = "assessment_1";
            this.singleLayoutItem180.IsUpdItem = true;
            // 
            // singleLayoutItem181
            // 
            this.singleLayoutItem181.BindControl = this.cboMainFood;
            this.singleLayoutItem181.DataName = "main_food";
            this.singleLayoutItem181.IsUpdItem = true;
            // 
            // singleLayoutItem182
            // 
            this.singleLayoutItem182.BindControl = this.cboSubFood;
            this.singleLayoutItem182.DataName = "sub_food";
            this.singleLayoutItem182.IsUpdItem = true;
            // 
            // singleLayoutItem183
            // 
            this.singleLayoutItem183.BindControl = this.gbxFoodDislike;
            this.singleLayoutItem183.DataName = "food_dislike_yn";
            this.singleLayoutItem183.IsUpdItem = true;
            // 
            // singleLayoutItem184
            // 
            this.singleLayoutItem184.BindControl = this.txtFoodDislike;
            this.singleLayoutItem184.DataName = "food_dislike_comment";
            this.singleLayoutItem184.IsUpdItem = true;
            // 
            // singleLayoutItem185
            // 
            this.singleLayoutItem185.BindControl = this.gbxAppetite;
            this.singleLayoutItem185.DataName = "appetite_yn";
            this.singleLayoutItem185.IsUpdItem = true;
            // 
            // singleLayoutItem186
            // 
            this.singleLayoutItem186.BindControl = this.txtAppetite;
            this.singleLayoutItem186.DataName = "appetite_comment";
            this.singleLayoutItem186.IsUpdItem = true;
            // 
            // singleLayoutItem187
            // 
            this.singleLayoutItem187.BindControl = this.gbxDysphagia;
            this.singleLayoutItem187.DataName = "dysphagia_yn";
            this.singleLayoutItem187.IsUpdItem = true;
            // 
            // singleLayoutItem188
            // 
            this.singleLayoutItem188.BindControl = this.txtDysphagia;
            this.singleLayoutItem188.DataName = "dysphagia_comment";
            this.singleLayoutItem188.IsUpdItem = true;
            // 
            // singleLayoutItem189
            // 
            this.singleLayoutItem189.BindControl = this.cboIntakeWay;
            this.singleLayoutItem189.DataName = "intake_way";
            this.singleLayoutItem189.IsUpdItem = true;
            // 
            // singleLayoutItem190
            // 
            this.singleLayoutItem190.BindControl = this.txtIntake;
            this.singleLayoutItem190.DataName = "intake_comment";
            this.singleLayoutItem190.IsUpdItem = true;
            // 
            // singleLayoutItem191
            // 
            this.singleLayoutItem191.BindControl = this.txtFoodLimit;
            this.singleLayoutItem191.DataName = "food_limit";
            this.singleLayoutItem191.IsUpdItem = true;
            // 
            // singleLayoutItem192
            // 
            this.singleLayoutItem192.BindControl = this.gbxMouthPollution;
            this.singleLayoutItem192.DataName = "mouth_pollution_yn";
            this.singleLayoutItem192.IsUpdItem = true;
            // 
            // singleLayoutItem193
            // 
            this.singleLayoutItem193.BindControl = this.txtMouthPollution;
            this.singleLayoutItem193.DataName = "mouth_pollution_comment";
            this.singleLayoutItem193.IsUpdItem = true;
            // 
            // singleLayoutItem194
            // 
            this.singleLayoutItem194.BindControl = this.gbxFalseTeeth;
            this.singleLayoutItem194.DataName = "false_teeth_yn";
            this.singleLayoutItem194.IsUpdItem = true;
            // 
            // singleLayoutItem195
            // 
            this.singleLayoutItem195.BindControl = this.txtFalseTeeth;
            this.singleLayoutItem195.DataName = "false_teeth_comment";
            this.singleLayoutItem195.IsUpdItem = true;
            // 
            // singleLayoutItem196
            // 
            this.singleLayoutItem196.BindControl = this.cboWeightUpdownStart;
            this.singleLayoutItem196.DataName = "weight_updown_start";
            this.singleLayoutItem196.IsUpdItem = true;
            // 
            // singleLayoutItem197
            // 
            this.singleLayoutItem197.BindControl = this.cboWeightUpdownHow;
            this.singleLayoutItem197.DataName = "weight_updown_how";
            this.singleLayoutItem197.IsUpdItem = true;
            // 
            // singleLayoutItem198
            // 
            this.singleLayoutItem198.BindControl = this.txtHeight;
            this.singleLayoutItem198.DataName = "height";
            this.singleLayoutItem198.IsUpdItem = true;
            // 
            // singleLayoutItem199
            // 
            this.singleLayoutItem199.BindControl = this.txtWeight;
            this.singleLayoutItem199.DataName = "weight";
            this.singleLayoutItem199.IsUpdItem = true;
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.txtBMI;
            this.singleLayoutItem1.DataName = "bmi";
            // 
            // singleLayoutItem200
            // 
            this.singleLayoutItem200.BindControl = this.cboDungCnt;
            this.singleLayoutItem200.DataName = "dung_count";
            this.singleLayoutItem200.IsUpdItem = true;
            // 
            // singleLayoutItem201
            // 
            this.singleLayoutItem201.BindControl = this.cboDungDay;
            this.singleLayoutItem201.DataName = "dung_day";
            this.singleLayoutItem201.IsUpdItem = true;
            // 
            // singleLayoutItem202
            // 
            this.singleLayoutItem202.BindControl = this.txtDungState;
            this.singleLayoutItem202.DataName = "dung_state";
            this.singleLayoutItem202.IsUpdItem = true;
            // 
            // singleLayoutItem203
            // 
            this.singleLayoutItem203.BindControl = this.txtDungLast;
            this.singleLayoutItem203.DataName = "dung_last";
            this.singleLayoutItem203.IsUpdItem = true;
            // 
            // singleLayoutItem204
            // 
            this.singleLayoutItem204.BindControl = this.gbxDungWill;
            this.singleLayoutItem204.DataName = "dung_will_yn";
            this.singleLayoutItem204.IsUpdItem = true;
            // 
            // singleLayoutItem205
            // 
            this.singleLayoutItem205.BindControl = this.cbxDiapersD;
            this.singleLayoutItem205.DataName = "diapers_yn";
            this.singleLayoutItem205.IsUpdItem = true;
            // 
            // singleLayoutItem206
            // 
            this.singleLayoutItem206.BindControl = this.cbxOrthotics;
            this.singleLayoutItem206.DataName = "orthotics_yn";
            this.singleLayoutItem206.IsUpdItem = true;
            // 
            // singleLayoutItem316
            // 
            this.singleLayoutItem316.BindControl = this.cbxEnema;
            this.singleLayoutItem316.DataName = "enema_yn";
            this.singleLayoutItem316.IsUpdItem = true;
            // 
            // singleLayoutItem207
            // 
            this.singleLayoutItem207.BindControl = this.cbxLaxative;
            this.singleLayoutItem207.DataName = "laxative_yn";
            this.singleLayoutItem207.IsUpdItem = true;
            // 
            // singleLayoutItem208
            // 
            this.singleLayoutItem208.BindControl = this.cbxSuppository;
            this.singleLayoutItem208.DataName = "suppository_yn";
            this.singleLayoutItem208.IsUpdItem = true;
            // 
            // singleLayoutItem209
            // 
            this.singleLayoutItem209.BindControl = this.cbxAntidiarrheal;
            this.singleLayoutItem209.DataName = "antidiarrheal_yn";
            this.singleLayoutItem209.IsUpdItem = true;
            // 
            // singleLayoutItem210
            // 
            this.singleLayoutItem210.BindControl = this.txtLaxation;
            this.singleLayoutItem210.DataName = "laxation_comment";
            this.singleLayoutItem210.IsUpdItem = true;
            // 
            // singleLayoutItem211
            // 
            this.singleLayoutItem211.BindControl = this.cboUrinCnt;
            this.singleLayoutItem211.DataName = "urin_count";
            this.singleLayoutItem211.IsUpdItem = true;
            // 
            // singleLayoutItem212
            // 
            this.singleLayoutItem212.BindControl = this.cboUrinDay;
            this.singleLayoutItem212.DataName = "urin_day";
            this.singleLayoutItem212.IsUpdItem = true;
            // 
            // singleLayoutItem213
            // 
            this.singleLayoutItem213.BindControl = this.txtUrinNightCnt;
            this.singleLayoutItem213.DataName = "urin_night_count";
            this.singleLayoutItem213.IsUpdItem = true;
            // 
            // singleLayoutItem214
            // 
            this.singleLayoutItem214.BindControl = this.gbxUrinWill;
            this.singleLayoutItem214.DataName = "urin_will_yn";
            this.singleLayoutItem214.IsUpdItem = true;
            // 
            // singleLayoutItem215
            // 
            this.singleLayoutItem215.BindControl = this.cbxIntermittent;
            this.singleLayoutItem215.DataName = "intermittent_yn";
            this.singleLayoutItem215.IsUpdItem = true;
            // 
            // singleLayoutItem216
            // 
            this.singleLayoutItem216.BindControl = this.txtIntermittent;
            this.singleLayoutItem216.DataName = "intermittent_comment";
            this.singleLayoutItem216.IsUpdItem = true;
            // 
            // singleLayoutItem217
            // 
            this.singleLayoutItem217.BindControl = this.cbxCatheter;
            this.singleLayoutItem217.DataName = "catheter_yn";
            this.singleLayoutItem217.IsUpdItem = true;
            // 
            // singleLayoutItem218
            // 
            this.singleLayoutItem218.BindControl = this.dtpCatheter;
            this.singleLayoutItem218.DataName = "catheter_start_date";
            this.singleLayoutItem218.IsUpdItem = true;
            // 
            // singleLayoutItem219
            // 
            this.singleLayoutItem219.BindControl = this.cbxAbdominal;
            this.singleLayoutItem219.DataName = "abdominal_inflation_yn";
            this.singleLayoutItem219.IsUpdItem = true;
            // 
            // singleLayoutItem220
            // 
            this.singleLayoutItem220.BindControl = this.cbxAbtominalVery;
            this.singleLayoutItem220.DataName = "abdominal_inflation_very_yn";
            this.singleLayoutItem220.IsUpdItem = true;
            // 
            // singleLayoutItem221
            // 
            this.singleLayoutItem221.BindControl = this.cbxEnterokinesia;
            this.singleLayoutItem221.DataName = "enterokinesia_yn";
            this.singleLayoutItem221.IsUpdItem = true;
            // 
            // singleLayoutItem222
            // 
            this.singleLayoutItem222.BindControl = this.txtAssessment2;
            this.singleLayoutItem222.DataName = "assessment_2";
            this.singleLayoutItem222.IsUpdItem = true;
            // 
            // singleLayoutItem223
            // 
            this.singleLayoutItem223.BindControl = this.cboFood_ADL;
            this.singleLayoutItem223.DataName = "adl_food_state";
            this.singleLayoutItem223.IsUpdItem = true;
            // 
            // singleLayoutItem224
            // 
            this.singleLayoutItem224.BindControl = this.txtFood_ADL;
            this.singleLayoutItem224.DataName = "adl_food_comment";
            this.singleLayoutItem224.IsUpdItem = true;
            // 
            // singleLayoutItem225
            // 
            this.singleLayoutItem225.BindControl = this.cboBath_ADL;
            this.singleLayoutItem225.DataName = "adl_bath_state";
            this.singleLayoutItem225.IsUpdItem = true;
            // 
            // singleLayoutItem226
            // 
            this.singleLayoutItem226.BindControl = this.txtBath_ADL;
            this.singleLayoutItem226.DataName = "adl_bath_comment";
            this.singleLayoutItem226.IsUpdItem = true;
            // 
            // singleLayoutItem227
            // 
            this.singleLayoutItem227.BindControl = this.cboCloth_ADL;
            this.singleLayoutItem227.DataName = "adl_cloth_state";
            this.singleLayoutItem227.IsUpdItem = true;
            // 
            // singleLayoutItem228
            // 
            this.singleLayoutItem228.BindControl = this.txtCloth_ADL;
            this.singleLayoutItem228.DataName = "adl_cloth_comment";
            this.singleLayoutItem228.IsUpdItem = true;
            // 
            // singleLayoutItem229
            // 
            this.singleLayoutItem229.BindControl = this.cboWash_ADL;
            this.singleLayoutItem229.DataName = "adl_wash_state";
            this.singleLayoutItem229.IsUpdItem = true;
            // 
            // singleLayoutItem230
            // 
            this.singleLayoutItem230.BindControl = this.txtWash_ADL;
            this.singleLayoutItem230.DataName = "adl_wash_comment";
            this.singleLayoutItem230.IsUpdItem = true;
            // 
            // singleLayoutItem231
            // 
            this.singleLayoutItem231.BindControl = this.cboExcretion_ADL;
            this.singleLayoutItem231.DataName = "adl_excretion_state";
            this.singleLayoutItem231.IsUpdItem = true;
            // 
            // singleLayoutItem232
            // 
            this.singleLayoutItem232.BindControl = this.txtExcretion_ADL;
            this.singleLayoutItem232.DataName = "adl_excretion_comment";
            this.singleLayoutItem232.IsUpdItem = true;
            // 
            // singleLayoutItem233
            // 
            this.singleLayoutItem233.BindControl = this.cboStruggle_ADL;
            this.singleLayoutItem233.DataName = "adl_struggle_state";
            this.singleLayoutItem233.IsUpdItem = true;
            // 
            // singleLayoutItem234
            // 
            this.singleLayoutItem234.BindControl = this.txtStruggle_ADL;
            this.singleLayoutItem234.DataName = "adl_struggle_comment";
            this.singleLayoutItem234.IsUpdItem = true;
            // 
            // singleLayoutItem235
            // 
            this.singleLayoutItem235.BindControl = this.cboBoard_ADL;
            this.singleLayoutItem235.DataName = "adl_board_state";
            this.singleLayoutItem235.IsUpdItem = true;
            // 
            // singleLayoutItem236
            // 
            this.singleLayoutItem236.BindControl = this.txtBoard_ADL;
            this.singleLayoutItem236.DataName = "adl_board_comment";
            this.singleLayoutItem236.IsUpdItem = true;
            // 
            // singleLayoutItem237
            // 
            this.singleLayoutItem237.BindControl = this.cboWheelchair_ADL;
            this.singleLayoutItem237.DataName = "adl_wheelchair_state";
            this.singleLayoutItem237.IsUpdItem = true;
            // 
            // singleLayoutItem238
            // 
            this.singleLayoutItem238.BindControl = this.txtWheelchair_ADL;
            this.singleLayoutItem238.DataName = "adl_wheelchair_comment";
            this.singleLayoutItem238.IsUpdItem = true;
            // 
            // singleLayoutItem239
            // 
            this.singleLayoutItem239.BindControl = this.cboWalk_ADL;
            this.singleLayoutItem239.DataName = "adl_walk_state";
            this.singleLayoutItem239.IsUpdItem = true;
            // 
            // singleLayoutItem240
            // 
            this.singleLayoutItem240.BindControl = this.txtWalk_ADL;
            this.singleLayoutItem240.DataName = "adl_walk_comment";
            this.singleLayoutItem240.IsUpdItem = true;
            // 
            // singleLayoutItem241
            // 
            this.singleLayoutItem241.BindControl = this.gbxNeedCare;
            this.singleLayoutItem241.DataName = "need_care";
            this.singleLayoutItem241.IsUpdItem = true;
            // 
            // singleLayoutItem242
            // 
            this.singleLayoutItem242.BindControl = this.gbxNeedSupport;
            this.singleLayoutItem242.DataName = "need_support";
            this.singleLayoutItem242.IsUpdItem = true;
            // 
            // singleLayoutItem243
            // 
            this.singleLayoutItem243.BindControl = this.txtService;
            this.singleLayoutItem243.DataName = "service_comment";
            this.singleLayoutItem243.IsUpdItem = true;
            // 
            // singleLayoutItem244
            // 
            this.singleLayoutItem244.BindControl = this.txtCareOffice;
            this.singleLayoutItem244.DataName = "care_office_comment";
            this.singleLayoutItem244.IsUpdItem = true;
            // 
            // singleLayoutItem245
            // 
            this.singleLayoutItem245.BindControl = this.txtSleepTime;
            this.singleLayoutItem245.DataName = "sleep_time";
            this.singleLayoutItem245.IsUpdItem = true;
            // 
            // singleLayoutItem246
            // 
            this.singleLayoutItem246.BindControl = this.txtSleepStart;
            this.singleLayoutItem246.DataName = "sleep_start_time";
            this.singleLayoutItem246.IsUpdItem = true;
            // 
            // singleLayoutItem247
            // 
            this.singleLayoutItem247.BindControl = this.txtSleepEnd;
            this.singleLayoutItem247.DataName = "sleep_end_time";
            this.singleLayoutItem247.IsUpdItem = true;
            // 
            // singleLayoutItem248
            // 
            this.singleLayoutItem248.BindControl = this.gbxSleepEnough;
            this.singleLayoutItem248.DataName = "sleep_enough_yn";
            this.singleLayoutItem248.IsUpdItem = true;
            // 
            // singleLayoutItem249
            // 
            this.singleLayoutItem249.BindControl = this.txtSleepEnough;
            this.singleLayoutItem249.DataName = "sleep_enough_comment";
            this.singleLayoutItem249.IsUpdItem = true;
            // 
            // singleLayoutItem250
            // 
            this.singleLayoutItem250.BindControl = this.txtSleepLess;
            this.singleLayoutItem250.DataName = "sleepless_comment";
            this.singleLayoutItem250.IsUpdItem = true;
            // 
            // singleLayoutItem251
            // 
            this.singleLayoutItem251.BindControl = this.cbxSnoring;
            this.singleLayoutItem251.DataName = "snoring_yn";
            this.singleLayoutItem251.IsUpdItem = true;
            // 
            // singleLayoutItem252
            // 
            this.singleLayoutItem252.BindControl = this.cbxSleepTalk;
            this.singleLayoutItem252.DataName = "sleep_talk_yn";
            this.singleLayoutItem252.IsUpdItem = true;
            // 
            // singleLayoutItem253
            // 
            this.singleLayoutItem253.BindControl = this.cbxTeethGrinding;
            this.singleLayoutItem253.DataName = "teeth_grinding_yn";
            this.singleLayoutItem253.IsUpdItem = true;
            // 
            // singleLayoutItem254
            // 
            this.singleLayoutItem254.BindControl = this.cbxSleepEtc;
            this.singleLayoutItem254.DataName = "sleep_etc_yn";
            this.singleLayoutItem254.IsUpdItem = true;
            // 
            // singleLayoutItem255
            // 
            this.singleLayoutItem255.BindControl = this.txtSleepEtc;
            this.singleLayoutItem255.DataName = "sleep_etc_comment";
            this.singleLayoutItem255.IsUpdItem = true;
            // 
            // singleLayoutItem256
            // 
            this.singleLayoutItem256.BindControl = this.txtAssessment4;
            this.singleLayoutItem256.DataName = "assessment_4";
            this.singleLayoutItem256.IsUpdItem = true;
            // 
            // singleLayoutItem257
            // 
            this.singleLayoutItem257.BindControl = this.cboSenseLevel;
            this.singleLayoutItem257.DataName = "sense_level";
            this.singleLayoutItem257.IsUpdItem = true;
            // 
            // singleLayoutItem258
            // 
            this.singleLayoutItem258.BindControl = this.gbxObstacleSpeech;
            this.singleLayoutItem258.DataName = "obstacle_speech_yn";
            this.singleLayoutItem258.IsUpdItem = true;
            // 
            // singleLayoutItem259
            // 
            this.singleLayoutItem259.BindControl = this.gbxObstacleSense;
            this.singleLayoutItem259.DataName = "obstacle_sense_yn";
            this.singleLayoutItem259.IsUpdItem = true;
            // 
            // singleLayoutItem260
            // 
            this.singleLayoutItem260.BindControl = this.gbxObstacle;
            this.singleLayoutItem260.DataName = "obstacle_yn";
            this.singleLayoutItem260.IsUpdItem = true;
            // 
            // singleLayoutItem261
            // 
            this.singleLayoutItem261.BindControl = this.txtObstacle;
            this.singleLayoutItem261.DataName = "obstacle_comment";
            this.singleLayoutItem261.IsUpdItem = true;
            // 
            // singleLayoutItem262
            // 
            this.singleLayoutItem262.BindControl = this.gbxRecognition;
            this.singleLayoutItem262.DataName = "recognition_yn";
            this.singleLayoutItem262.IsUpdItem = true;
            // 
            // singleLayoutItem263
            // 
            this.singleLayoutItem263.BindControl = this.txtRecognition;
            this.singleLayoutItem263.DataName = "recognition_comment";
            this.singleLayoutItem263.IsUpdItem = true;
            // 
            // singleLayoutItem264
            // 
            this.singleLayoutItem264.BindControl = this.gbxSensor;
            this.singleLayoutItem264.DataName = "sensor_yn";
            this.singleLayoutItem264.IsUpdItem = true;
            // 
            // singleLayoutItem265
            // 
            this.singleLayoutItem265.BindControl = this.cbxEyeRight;
            this.singleLayoutItem265.DataName = "eye_right_yn";
            this.singleLayoutItem265.IsUpdItem = true;
            // 
            // singleLayoutItem266
            // 
            this.singleLayoutItem266.BindControl = this.txtEyeRight;
            this.singleLayoutItem266.DataName = "eye_right_comment";
            this.singleLayoutItem266.IsUpdItem = true;
            // 
            // singleLayoutItem267
            // 
            this.singleLayoutItem267.BindControl = this.cbxEyeLeft;
            this.singleLayoutItem267.DataName = "eye_left_yn";
            this.singleLayoutItem267.IsUpdItem = true;
            // 
            // singleLayoutItem268
            // 
            this.singleLayoutItem268.BindControl = this.txtEyeLeft;
            this.singleLayoutItem268.DataName = "eye_left_comment";
            this.singleLayoutItem268.IsUpdItem = true;
            // 
            // singleLayoutItem269
            // 
            this.singleLayoutItem269.BindControl = this.gbxGlasses;
            this.singleLayoutItem269.DataName = "eye_glasses_yn";
            this.singleLayoutItem269.IsUpdItem = true;
            // 
            // singleLayoutItem270
            // 
            this.singleLayoutItem270.BindControl = this.gbxLens;
            this.singleLayoutItem270.DataName = "eye_lens_yn";
            this.singleLayoutItem270.IsUpdItem = true;
            // 
            // singleLayoutItem271
            // 
            this.singleLayoutItem271.BindControl = this.cbxEarRight;
            this.singleLayoutItem271.DataName = "ear_right_yn";
            this.singleLayoutItem271.IsUpdItem = true;
            // 
            // singleLayoutItem272
            // 
            this.singleLayoutItem272.BindControl = this.txtEarRight;
            this.singleLayoutItem272.DataName = "ear_right_comment";
            this.singleLayoutItem272.IsUpdItem = true;
            // 
            // singleLayoutItem273
            // 
            this.singleLayoutItem273.BindControl = this.cbxEarLeft;
            this.singleLayoutItem273.DataName = "ear_left_yn";
            this.singleLayoutItem273.IsUpdItem = true;
            // 
            // singleLayoutItem274
            // 
            this.singleLayoutItem274.BindControl = this.txtEarLeft;
            this.singleLayoutItem274.DataName = "ear_left_comment";
            this.singleLayoutItem274.IsUpdItem = true;
            // 
            // singleLayoutItem275
            // 
            this.singleLayoutItem275.BindControl = this.gbxEarAid;
            this.singleLayoutItem275.DataName = "ear_aid_yn";
            this.singleLayoutItem275.IsUpdItem = true;
            // 
            // singleLayoutItem276
            // 
            this.singleLayoutItem276.BindControl = this.txtNose;
            this.singleLayoutItem276.DataName = "nose_comment";
            this.singleLayoutItem276.IsUpdItem = true;
            // 
            // singleLayoutItem277
            // 
            this.singleLayoutItem277.BindControl = this.txtMouth;
            this.singleLayoutItem277.DataName = "mouth_comment";
            this.singleLayoutItem277.IsUpdItem = true;
            // 
            // singleLayoutItem278
            // 
            this.singleLayoutItem278.BindControl = this.gbxDizzy;
            this.singleLayoutItem278.DataName = "dizzy_yn";
            this.singleLayoutItem278.IsUpdItem = true;
            // 
            // singleLayoutItem279
            // 
            this.singleLayoutItem279.BindControl = this.txtDizzy;
            this.singleLayoutItem279.DataName = "dizzy_comment";
            this.singleLayoutItem279.IsUpdItem = true;
            // 
            // singleLayoutItem280
            // 
            this.singleLayoutItem280.BindControl = this.gbxStagger;
            this.singleLayoutItem280.DataName = "stagger_yn";
            this.singleLayoutItem280.IsUpdItem = true;
            // 
            // singleLayoutItem281
            // 
            this.singleLayoutItem281.BindControl = this.txtStagger;
            this.singleLayoutItem281.DataName = "stagger_comment";
            this.singleLayoutItem281.IsUpdItem = true;
            // 
            // singleLayoutItem282
            // 
            this.singleLayoutItem282.BindControl = this.gbxPain;
            this.singleLayoutItem282.DataName = "pain_yn";
            this.singleLayoutItem282.IsUpdItem = true;
            // 
            // singleLayoutItem283
            // 
            this.singleLayoutItem283.BindControl = this.txtPain;
            this.singleLayoutItem283.DataName = "pain_comment";
            this.singleLayoutItem283.IsUpdItem = true;
            // 
            // singleLayoutItem284
            // 
            this.singleLayoutItem284.BindControl = this.gbxPerception;
            this.singleLayoutItem284.DataName = "perception_yn";
            this.singleLayoutItem284.IsUpdItem = true;
            // 
            // singleLayoutItem285
            // 
            this.singleLayoutItem285.BindControl = this.txtPerception;
            this.singleLayoutItem285.DataName = "perception_comment";
            this.singleLayoutItem285.IsUpdItem = true;
            // 
            // singleLayoutItem286
            // 
            this.singleLayoutItem286.BindControl = this.gbxMovement;
            this.singleLayoutItem286.DataName = "movement_yn";
            this.singleLayoutItem286.IsUpdItem = true;
            // 
            // singleLayoutItem287
            // 
            this.singleLayoutItem287.BindControl = this.gbxParalysis;
            this.singleLayoutItem287.DataName = "paralysis_yn";
            this.singleLayoutItem287.IsUpdItem = true;
            // 
            // singleLayoutItem288
            // 
            this.singleLayoutItem288.BindControl = this.txtParalysis;
            this.singleLayoutItem288.DataName = "paralysis_comment";
            this.singleLayoutItem288.IsUpdItem = true;
            // 
            // singleLayoutItem289
            // 
            this.singleLayoutItem289.BindControl = this.gbxContracture;
            this.singleLayoutItem289.DataName = "contracture_yn";
            this.singleLayoutItem289.IsUpdItem = true;
            // 
            // singleLayoutItem290
            // 
            this.singleLayoutItem290.BindControl = this.txtContracture;
            this.singleLayoutItem290.DataName = "contracture_comment";
            this.singleLayoutItem290.IsUpdItem = true;
            // 
            // singleLayoutItem291
            // 
            this.singleLayoutItem291.BindControl = this.gbxLossPart;
            this.singleLayoutItem291.DataName = "loss_part_yn";
            this.singleLayoutItem291.IsUpdItem = true;
            // 
            // singleLayoutItem292
            // 
            this.singleLayoutItem292.BindControl = this.txtLossPart;
            this.singleLayoutItem292.DataName = "loss_part_comment";
            this.singleLayoutItem292.IsUpdItem = true;
            // 
            // singleLayoutItem293
            // 
            this.singleLayoutItem293.BindControl = this.gbxWorry;
            this.singleLayoutItem293.DataName = "worry_yn";
            this.singleLayoutItem293.IsUpdItem = true;
            // 
            // singleLayoutItem294
            // 
            this.singleLayoutItem294.BindControl = this.txtWorry;
            this.singleLayoutItem294.DataName = "worry_comment";
            this.singleLayoutItem294.IsUpdItem = true;
            // 
            // singleLayoutItem295
            // 
            this.singleLayoutItem295.BindControl = this.gbxFear;
            this.singleLayoutItem295.DataName = "fear_yn";
            this.singleLayoutItem295.IsUpdItem = true;
            // 
            // singleLayoutItem296
            // 
            this.singleLayoutItem296.BindControl = this.txtFear;
            this.singleLayoutItem296.DataName = "fear_comment";
            this.singleLayoutItem296.IsUpdItem = true;
            // 
            // singleLayoutItem297
            // 
            this.singleLayoutItem297.BindControl = this.txtAssessment5;
            this.singleLayoutItem297.DataName = "assessment_5";
            this.singleLayoutItem297.IsUpdItem = true;
            // 
            // singleLayoutItem298
            // 
            this.singleLayoutItem298.BindControl = this.gbxFamily;
            this.singleLayoutItem298.DataName = "family_yn";
            this.singleLayoutItem298.IsUpdItem = true;
            // 
            // singleLayoutItem299
            // 
            this.singleLayoutItem299.BindControl = this.txtFamily;
            this.singleLayoutItem299.DataName = "family_comment";
            this.singleLayoutItem299.IsUpdItem = true;
            // 
            // singleLayoutItem300
            // 
            this.singleLayoutItem300.BindControl = this.txtJob;
            this.singleLayoutItem300.DataName = "job";
            this.singleLayoutItem300.IsUpdItem = true;
            // 
            // singleLayoutItem301
            // 
            this.singleLayoutItem301.BindControl = this.txtJobMate;
            this.singleLayoutItem301.DataName = "job_mate";
            this.singleLayoutItem301.IsUpdItem = true;
            // 
            // singleLayoutItem302
            // 
            this.singleLayoutItem302.BindControl = this.cboHouseKind;
            this.singleLayoutItem302.DataName = "house_kind";
            this.singleLayoutItem302.IsUpdItem = true;
            // 
            // singleLayoutItem303
            // 
            this.singleLayoutItem303.BindControl = this.gbxBarrierFree;
            this.singleLayoutItem303.DataName = "barrier_free_yn";
            this.singleLayoutItem303.IsUpdItem = true;
            // 
            // singleLayoutItem304
            // 
            this.singleLayoutItem304.BindControl = this.cboMenses;
            this.singleLayoutItem304.DataName = "menses";
            this.singleLayoutItem304.IsUpdItem = true;
            // 
            // singleLayoutItem305
            // 
            this.singleLayoutItem305.BindControl = this.txtMensesAge;
            this.singleLayoutItem305.DataName = "menses_age";
            this.singleLayoutItem305.IsUpdItem = true;
            // 
            // singleLayoutItem306
            // 
            this.singleLayoutItem306.BindControl = this.gbxMensesProblem;
            this.singleLayoutItem306.DataName = "menses_problem_yn";
            this.singleLayoutItem306.IsUpdItem = true;
            // 
            // singleLayoutItem307
            // 
            this.singleLayoutItem307.BindControl = this.txtMensesProblem;
            this.singleLayoutItem307.DataName = "menses_problem_comment";
            this.singleLayoutItem307.IsUpdItem = true;
            // 
            // singleLayoutItem308
            // 
            this.singleLayoutItem308.BindControl = this.gbxPregnancy;
            this.singleLayoutItem308.DataName = "pregnancy_yn";
            this.singleLayoutItem308.IsUpdItem = true;
            // 
            // singleLayoutItem309
            // 
            this.singleLayoutItem309.BindControl = this.gbxHobby;
            this.singleLayoutItem309.DataName = "hobby_yn";
            this.singleLayoutItem309.IsUpdItem = true;
            // 
            // singleLayoutItem310
            // 
            this.singleLayoutItem310.BindControl = this.txtHobby;
            this.singleLayoutItem310.DataName = "hobby_comment";
            this.singleLayoutItem310.IsUpdItem = true;
            // 
            // singleLayoutItem311
            // 
            this.singleLayoutItem311.BindControl = this.gbxStress;
            this.singleLayoutItem311.DataName = "stress_yn";
            this.singleLayoutItem311.IsUpdItem = true;
            // 
            // singleLayoutItem312
            // 
            this.singleLayoutItem312.BindControl = this.txtStress;
            this.singleLayoutItem312.DataName = "stress_comment";
            this.singleLayoutItem312.IsUpdItem = true;
            // 
            // singleLayoutItem317
            // 
            this.singleLayoutItem317.BindControl = this.txtStressManage;
            this.singleLayoutItem317.DataName = "stress_manage";
            this.singleLayoutItem317.IsUpdItem = true;
            // 
            // singleLayoutItem313
            // 
            this.singleLayoutItem313.BindControl = this.gbxReligion;
            this.singleLayoutItem313.DataName = "religion_yn";
            this.singleLayoutItem313.IsUpdItem = true;
            // 
            // singleLayoutItem314
            // 
            this.singleLayoutItem314.BindControl = this.txtReligion;
            this.singleLayoutItem314.DataName = "religion_comment";
            this.singleLayoutItem314.IsUpdItem = true;
            // 
            // singleLayoutItem315
            // 
            this.singleLayoutItem315.BindControl = this.txtAssessment7;
            this.singleLayoutItem315.DataName = "assessment_7";
            this.singleLayoutItem315.IsUpdItem = true;
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.BindControl = this.txtKeyCell1;
            this.singleLayoutItem4.DataName = "key_cell1";
            this.singleLayoutItem4.IsUpdItem = true;
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.BindControl = this.txtKeyOffice1;
            this.singleLayoutItem5.DataName = "key_office1";
            this.singleLayoutItem5.IsUpdItem = true;
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.BindControl = this.txtKeyName2;
            this.singleLayoutItem6.DataName = "key_name2";
            this.singleLayoutItem6.IsUpdItem = true;
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.BindControl = this.txtKeyRelation2;
            this.singleLayoutItem7.DataName = "key_relation2";
            this.singleLayoutItem7.IsUpdItem = true;
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.BindControl = this.txtKeyHome2;
            this.singleLayoutItem8.DataName = "key_home2";
            this.singleLayoutItem8.IsUpdItem = true;
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.BindControl = this.txtKeyCell2;
            this.singleLayoutItem9.DataName = "key_cell2";
            this.singleLayoutItem9.IsUpdItem = true;
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.BindControl = this.txtKeyOffice2;
            this.singleLayoutItem10.DataName = "key_office2";
            this.singleLayoutItem10.IsUpdItem = true;
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.BindControl = this.txtKeyComment;
            this.singleLayoutItem11.DataName = "key_comment";
            this.singleLayoutItem11.IsUpdItem = true;
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.BindControl = this.cboKeyHomePri1;
            this.singleLayoutItem12.DataName = "key_home1_pri";
            this.singleLayoutItem12.IsUpdItem = true;
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.BindControl = this.cboKeyCellPri1;
            this.singleLayoutItem13.DataName = "key_cell1_pri";
            this.singleLayoutItem13.IsUpdItem = true;
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.BindControl = this.cboKeyOfficePri1;
            this.singleLayoutItem14.DataName = "key_office1_pri";
            this.singleLayoutItem14.IsUpdItem = true;
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.BindControl = this.cboKeyHomePri2;
            this.singleLayoutItem15.DataName = "key_home2_pri";
            this.singleLayoutItem15.IsUpdItem = true;
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.BindControl = this.cboKeyCellPri2;
            this.singleLayoutItem16.DataName = "key_cell2_pri";
            this.singleLayoutItem16.IsUpdItem = true;
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.BindControl = this.cboKeyOfficePri2;
            this.singleLayoutItem17.DataName = "key_office2_pri";
            this.singleLayoutItem17.IsUpdItem = true;
            // 
            // layFkinp1001
            // 
            this.layFkinp1001.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem160});
            this.layFkinp1001.QuerySQL = "SELECT PKINP1001\r\n  FROM VW_OCS_INP1001_01\r\n WHERE HOSP_CODE            = :f_hosp" +
                "_code\r\n   AND NVL(CANCEL_YN,\'N\')   = \'N\'\r\n   AND NVL(JAEWON_FLAG,\'N\') = \'Y\'\r\n   " +
                "AND BUNHO                = :f_bunho";
            // 
            // singleLayoutItem160
            // 
            this.singleLayoutItem160.DataName = "fkinp1001";
            // 
            // layReserInfo
            // 
            this.layReserInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layReserInfo.QuerySQL = "SELECT RESER_FKINP1001\r\n     , RESER_DATE \r\n  FROM INP1003 \r\n WHERE HOSP_CODE = :" +
                "f_hosp_code\r\n   AND BUNHO     = :f_bunho \r\n   AND RESER_END_TYPE = \'0\'";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "fkinp1001";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "reser_date";
            this.multiLayoutItem6.DataType = IHIS.Framework.DataType.Date;
            // 
            // paBox
            // 
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.paBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(1154, 32);
            this.paBox.TabIndex = 999;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1156, 33);
            this.pnlTop.TabIndex = 999;
            // 
            // layCopy
            // 
            this.layCopy.CallerID = 'M';
            this.layCopy.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem322,
            this.singleLayoutItem346,
            this.singleLayoutItem347,
            this.singleLayoutItem348,
            this.singleLayoutItem349,
            this.singleLayoutItem350,
            this.singleLayoutItem351,
            this.singleLayoutItem352,
            this.singleLayoutItem353,
            this.singleLayoutItem354,
            this.singleLayoutItem355,
            this.singleLayoutItem356,
            this.singleLayoutItem357,
            this.singleLayoutItem358,
            this.singleLayoutItem359,
            this.singleLayoutItem360,
            this.singleLayoutItem361,
            this.singleLayoutItem362,
            this.singleLayoutItem363,
            this.singleLayoutItem364,
            this.singleLayoutItem365,
            this.singleLayoutItem366,
            this.singleLayoutItem367,
            this.singleLayoutItem368,
            this.singleLayoutItem369,
            this.singleLayoutItem370,
            this.singleLayoutItem371,
            this.singleLayoutItem372,
            this.singleLayoutItem373,
            this.singleLayoutItem374,
            this.singleLayoutItem375,
            this.singleLayoutItem376,
            this.singleLayoutItem377,
            this.singleLayoutItem378,
            this.singleLayoutItem379,
            this.singleLayoutItem380,
            this.singleLayoutItem381,
            this.singleLayoutItem382,
            this.singleLayoutItem383,
            this.singleLayoutItem384,
            this.singleLayoutItem385,
            this.singleLayoutItem386,
            this.singleLayoutItem387,
            this.singleLayoutItem388,
            this.singleLayoutItem389,
            this.singleLayoutItem390,
            this.singleLayoutItem391,
            this.singleLayoutItem392,
            this.singleLayoutItem393,
            this.singleLayoutItem394,
            this.singleLayoutItem395,
            this.singleLayoutItem396,
            this.singleLayoutItem397,
            this.singleLayoutItem398,
            this.singleLayoutItem399,
            this.singleLayoutItem400,
            this.singleLayoutItem401,
            this.singleLayoutItem402,
            this.singleLayoutItem403,
            this.singleLayoutItem404,
            this.singleLayoutItem405,
            this.singleLayoutItem406,
            this.singleLayoutItem407,
            this.singleLayoutItem408,
            this.singleLayoutItem409,
            this.singleLayoutItem410,
            this.singleLayoutItem411,
            this.singleLayoutItem412,
            this.singleLayoutItem413,
            this.singleLayoutItem414,
            this.singleLayoutItem415,
            this.singleLayoutItem416,
            this.singleLayoutItem417,
            this.singleLayoutItem418,
            this.singleLayoutItem419,
            this.singleLayoutItem420,
            this.singleLayoutItem421,
            this.singleLayoutItem422,
            this.singleLayoutItem423,
            this.singleLayoutItem425,
            this.singleLayoutItem426,
            this.singleLayoutItem427,
            this.singleLayoutItem428,
            this.singleLayoutItem429,
            this.singleLayoutItem430,
            this.singleLayoutItem431,
            this.singleLayoutItem432,
            this.singleLayoutItem433,
            this.singleLayoutItem434,
            this.singleLayoutItem435,
            this.singleLayoutItem436,
            this.singleLayoutItem437,
            this.singleLayoutItem438,
            this.singleLayoutItem439,
            this.singleLayoutItem440,
            this.singleLayoutItem441,
            this.singleLayoutItem442,
            this.singleLayoutItem443,
            this.singleLayoutItem444,
            this.singleLayoutItem445,
            this.singleLayoutItem446,
            this.singleLayoutItem447,
            this.singleLayoutItem448,
            this.singleLayoutItem449,
            this.singleLayoutItem450,
            this.singleLayoutItem451,
            this.singleLayoutItem452,
            this.singleLayoutItem453,
            this.singleLayoutItem454,
            this.singleLayoutItem455,
            this.singleLayoutItem456,
            this.singleLayoutItem457,
            this.singleLayoutItem458,
            this.singleLayoutItem459,
            this.singleLayoutItem460,
            this.singleLayoutItem461,
            this.singleLayoutItem462,
            this.singleLayoutItem463,
            this.singleLayoutItem464,
            this.singleLayoutItem465,
            this.singleLayoutItem466,
            this.singleLayoutItem467,
            this.singleLayoutItem468,
            this.singleLayoutItem469,
            this.singleLayoutItem470,
            this.singleLayoutItem471,
            this.singleLayoutItem472,
            this.singleLayoutItem473,
            this.singleLayoutItem474,
            this.singleLayoutItem475,
            this.singleLayoutItem476,
            this.singleLayoutItem477,
            this.singleLayoutItem478,
            this.singleLayoutItem479,
            this.singleLayoutItem480,
            this.singleLayoutItem481,
            this.singleLayoutItem482,
            this.singleLayoutItem483,
            this.singleLayoutItem484,
            this.singleLayoutItem485,
            this.singleLayoutItem486,
            this.singleLayoutItem487,
            this.singleLayoutItem488,
            this.singleLayoutItem489,
            this.singleLayoutItem490,
            this.singleLayoutItem491,
            this.singleLayoutItem492,
            this.singleLayoutItem493,
            this.singleLayoutItem494,
            this.singleLayoutItem495,
            this.singleLayoutItem496,
            this.singleLayoutItem497,
            this.singleLayoutItem498,
            this.singleLayoutItem499,
            this.singleLayoutItem500,
            this.singleLayoutItem501,
            this.singleLayoutItem502,
            this.singleLayoutItem503,
            this.singleLayoutItem504,
            this.singleLayoutItem505,
            this.singleLayoutItem506,
            this.singleLayoutItem507,
            this.singleLayoutItem508,
            this.singleLayoutItem509,
            this.singleLayoutItem510});
            // 
            // singleLayoutItem322
            // 
            this.singleLayoutItem322.DataName = "hosp_code";
            this.singleLayoutItem322.IsUpdItem = true;
            // 
            // singleLayoutItem346
            // 
            this.singleLayoutItem346.DataName = "bunho";
            this.singleLayoutItem346.IsUpdItem = true;
            // 
            // singleLayoutItem347
            // 
            this.singleLayoutItem347.DataName = "fkinp1001";
            this.singleLayoutItem347.IsUpdItem = true;
            // 
            // singleLayoutItem348
            // 
            this.singleLayoutItem348.BindControl = this.cboBloodTypeABO;
            this.singleLayoutItem348.DataName = "blood_type_abo";
            this.singleLayoutItem348.IsUpdItem = true;
            // 
            // singleLayoutItem349
            // 
            this.singleLayoutItem349.BindControl = this.cboBloodTypeRh;
            this.singleLayoutItem349.DataName = "blood_type_rh";
            this.singleLayoutItem349.IsUpdItem = true;
            // 
            // singleLayoutItem350
            // 
            this.singleLayoutItem350.BindControl = this.cboPurpose;
            this.singleLayoutItem350.DataName = "purpose";
            this.singleLayoutItem350.IsUpdItem = true;
            // 
            // singleLayoutItem351
            // 
            this.singleLayoutItem351.BindControl = this.txtInformant;
            this.singleLayoutItem351.DataName = "informant";
            this.singleLayoutItem351.IsUpdItem = true;
            // 
            // singleLayoutItem352
            // 
            this.singleLayoutItem352.BindControl = this.txtKeyName1;
            this.singleLayoutItem352.DataName = "key_name";
            this.singleLayoutItem352.IsUpdItem = true;
            // 
            // singleLayoutItem353
            // 
            this.singleLayoutItem353.BindControl = this.txtKeyRelation1;
            this.singleLayoutItem353.DataName = "key_relation";
            this.singleLayoutItem353.IsUpdItem = true;
            // 
            // singleLayoutItem354
            // 
            this.singleLayoutItem354.BindControl = this.txtKeyHome1;
            this.singleLayoutItem354.DataName = "key_contact";
            this.singleLayoutItem354.IsUpdItem = true;
            // 
            // singleLayoutItem355
            // 
            this.singleLayoutItem355.BindControl = this.fbxWriter;
            this.singleLayoutItem355.DataName = "writer";
            this.singleLayoutItem355.IsUpdItem = true;
            // 
            // singleLayoutItem356
            // 
            this.singleLayoutItem356.BindControl = this.dbxWriter;
            this.singleLayoutItem356.DataName = "writer_name";
            // 
            // singleLayoutItem357
            // 
            this.singleLayoutItem357.BindControl = this.mbxDiagnosisName;
            this.singleLayoutItem357.DataName = "diagnosis_name";
            this.singleLayoutItem357.IsUpdItem = true;
            // 
            // singleLayoutItem358
            // 
            this.singleLayoutItem358.BindControl = this.cboDignosisGubun;
            this.singleLayoutItem358.DataName = "diagnosis_gubun";
            this.singleLayoutItem358.IsUpdItem = true;
            // 
            // singleLayoutItem359
            // 
            this.singleLayoutItem359.BindControl = this.txtInpatientCourse;
            this.singleLayoutItem359.DataName = "inpatient_course";
            this.singleLayoutItem359.IsUpdItem = true;
            // 
            // singleLayoutItem360
            // 
            this.singleLayoutItem360.BindControl = this.txtAssessment0;
            this.singleLayoutItem360.DataName = "assessment_0";
            this.singleLayoutItem360.IsUpdItem = true;
            // 
            // singleLayoutItem361
            // 
            this.singleLayoutItem361.BindControl = this.mbxPastHis;
            this.singleLayoutItem361.DataName = "past_his";
            this.singleLayoutItem361.IsUpdItem = true;
            // 
            // singleLayoutItem362
            // 
            this.singleLayoutItem362.BindControl = this.gbxBringDrug;
            this.singleLayoutItem362.DataName = "bring_drug_yn";
            this.singleLayoutItem362.IsUpdItem = true;
            // 
            // singleLayoutItem363
            // 
            this.singleLayoutItem363.BindControl = this.mbxBringDrugComment;
            this.singleLayoutItem363.DataName = "bring_drug_comment";
            this.singleLayoutItem363.IsUpdItem = true;
            // 
            // singleLayoutItem364
            // 
            this.singleLayoutItem364.BindControl = this.gbxHealthCare;
            this.singleLayoutItem364.DataName = "healthcare_yn";
            this.singleLayoutItem364.IsUpdItem = true;
            // 
            // singleLayoutItem365
            // 
            this.singleLayoutItem365.BindControl = this.mbxHealthcare;
            this.singleLayoutItem365.DataName = "healthcare_comment";
            this.singleLayoutItem365.IsUpdItem = true;
            // 
            // singleLayoutItem366
            // 
            this.singleLayoutItem366.BindControl = this.nudSmoking;
            this.singleLayoutItem366.DataName = "smoking_day";
            this.singleLayoutItem366.IsUpdItem = true;
            // 
            // singleLayoutItem367
            // 
            this.singleLayoutItem367.BindControl = this.txtDrinking;
            this.singleLayoutItem367.DataName = "drinking";
            this.singleLayoutItem367.IsUpdItem = true;
            // 
            // singleLayoutItem368
            // 
            this.singleLayoutItem368.BindControl = this.txtExplainD;
            this.singleLayoutItem368.DataName = "explain_doctor";
            this.singleLayoutItem368.IsUpdItem = true;
            // 
            // singleLayoutItem369
            // 
            this.singleLayoutItem369.BindControl = this.txtExplainP;
            this.singleLayoutItem369.DataName = "explain_patient";
            this.singleLayoutItem369.IsUpdItem = true;
            // 
            // singleLayoutItem370
            // 
            this.singleLayoutItem370.BindControl = this.txtExplainF;
            this.singleLayoutItem370.DataName = "explain_family";
            this.singleLayoutItem370.IsUpdItem = true;
            // 
            // singleLayoutItem371
            // 
            this.singleLayoutItem371.BindControl = this.txtAssessment1;
            this.singleLayoutItem371.DataName = "assessment_1";
            this.singleLayoutItem371.IsUpdItem = true;
            // 
            // singleLayoutItem372
            // 
            this.singleLayoutItem372.DataName = "main_food";
            this.singleLayoutItem372.IsUpdItem = true;
            // 
            // singleLayoutItem373
            // 
            this.singleLayoutItem373.DataName = "sub_food";
            this.singleLayoutItem373.IsUpdItem = true;
            // 
            // singleLayoutItem374
            // 
            this.singleLayoutItem374.BindControl = this.gbxFoodDislike;
            this.singleLayoutItem374.DataName = "food_dislike_yn";
            this.singleLayoutItem374.IsUpdItem = true;
            // 
            // singleLayoutItem375
            // 
            this.singleLayoutItem375.BindControl = this.txtFoodDislike;
            this.singleLayoutItem375.DataName = "food_dislike_comment";
            this.singleLayoutItem375.IsUpdItem = true;
            // 
            // singleLayoutItem376
            // 
            this.singleLayoutItem376.BindControl = this.gbxAppetite;
            this.singleLayoutItem376.DataName = "appetite_yn";
            this.singleLayoutItem376.IsUpdItem = true;
            // 
            // singleLayoutItem377
            // 
            this.singleLayoutItem377.BindControl = this.txtAppetite;
            this.singleLayoutItem377.DataName = "appetite_comment";
            this.singleLayoutItem377.IsUpdItem = true;
            // 
            // singleLayoutItem378
            // 
            this.singleLayoutItem378.BindControl = this.gbxDysphagia;
            this.singleLayoutItem378.DataName = "dysphagia_yn";
            this.singleLayoutItem378.IsUpdItem = true;
            // 
            // singleLayoutItem379
            // 
            this.singleLayoutItem379.BindControl = this.txtDysphagia;
            this.singleLayoutItem379.DataName = "dysphagia_comment";
            this.singleLayoutItem379.IsUpdItem = true;
            // 
            // singleLayoutItem380
            // 
            this.singleLayoutItem380.BindControl = this.cboIntakeWay;
            this.singleLayoutItem380.DataName = "intake_way";
            this.singleLayoutItem380.IsUpdItem = true;
            // 
            // singleLayoutItem381
            // 
            this.singleLayoutItem381.BindControl = this.txtIntake;
            this.singleLayoutItem381.DataName = "intake_comment";
            this.singleLayoutItem381.IsUpdItem = true;
            // 
            // singleLayoutItem382
            // 
            this.singleLayoutItem382.BindControl = this.txtFoodLimit;
            this.singleLayoutItem382.DataName = "food_limit";
            this.singleLayoutItem382.IsUpdItem = true;
            // 
            // singleLayoutItem383
            // 
            this.singleLayoutItem383.BindControl = this.gbxMouthPollution;
            this.singleLayoutItem383.DataName = "mouth_pollution_yn";
            this.singleLayoutItem383.IsUpdItem = true;
            // 
            // singleLayoutItem384
            // 
            this.singleLayoutItem384.BindControl = this.txtMouthPollution;
            this.singleLayoutItem384.DataName = "mouth_pollution_comment";
            this.singleLayoutItem384.IsUpdItem = true;
            // 
            // singleLayoutItem385
            // 
            this.singleLayoutItem385.BindControl = this.gbxFalseTeeth;
            this.singleLayoutItem385.DataName = "false_teeth_yn";
            this.singleLayoutItem385.IsUpdItem = true;
            // 
            // singleLayoutItem386
            // 
            this.singleLayoutItem386.BindControl = this.txtFalseTeeth;
            this.singleLayoutItem386.DataName = "false_teeth_comment";
            this.singleLayoutItem386.IsUpdItem = true;
            // 
            // singleLayoutItem387
            // 
            this.singleLayoutItem387.BindControl = this.cboWeightUpdownStart;
            this.singleLayoutItem387.DataName = "weight_updown_start";
            this.singleLayoutItem387.IsUpdItem = true;
            // 
            // singleLayoutItem388
            // 
            this.singleLayoutItem388.BindControl = this.cboWeightUpdownHow;
            this.singleLayoutItem388.DataName = "weight_updown_how";
            this.singleLayoutItem388.IsUpdItem = true;
            // 
            // singleLayoutItem389
            // 
            this.singleLayoutItem389.BindControl = this.txtHeight;
            this.singleLayoutItem389.DataName = "height";
            this.singleLayoutItem389.IsUpdItem = true;
            // 
            // singleLayoutItem390
            // 
            this.singleLayoutItem390.BindControl = this.txtWeight;
            this.singleLayoutItem390.DataName = "weight";
            this.singleLayoutItem390.IsUpdItem = true;
            // 
            // singleLayoutItem391
            // 
            this.singleLayoutItem391.BindControl = this.txtBMI;
            this.singleLayoutItem391.DataName = "bmi";
            // 
            // singleLayoutItem392
            // 
            this.singleLayoutItem392.BindControl = this.cboDungCnt;
            this.singleLayoutItem392.DataName = "dung_count";
            this.singleLayoutItem392.IsUpdItem = true;
            // 
            // singleLayoutItem393
            // 
            this.singleLayoutItem393.BindControl = this.cboDungDay;
            this.singleLayoutItem393.DataName = "dung_day";
            this.singleLayoutItem393.IsUpdItem = true;
            // 
            // singleLayoutItem394
            // 
            this.singleLayoutItem394.BindControl = this.txtDungState;
            this.singleLayoutItem394.DataName = "dung_state";
            this.singleLayoutItem394.IsUpdItem = true;
            // 
            // singleLayoutItem395
            // 
            this.singleLayoutItem395.BindControl = this.txtDungLast;
            this.singleLayoutItem395.DataName = "dung_last";
            this.singleLayoutItem395.IsUpdItem = true;
            // 
            // singleLayoutItem396
            // 
            this.singleLayoutItem396.BindControl = this.gbxDungWill;
            this.singleLayoutItem396.DataName = "dung_will_yn";
            this.singleLayoutItem396.IsUpdItem = true;
            // 
            // singleLayoutItem397
            // 
            this.singleLayoutItem397.BindControl = this.cbxDiapersD;
            this.singleLayoutItem397.DataName = "diapers_yn";
            this.singleLayoutItem397.IsUpdItem = true;
            // 
            // singleLayoutItem398
            // 
            this.singleLayoutItem398.BindControl = this.cbxOrthotics;
            this.singleLayoutItem398.DataName = "orthotics_yn";
            this.singleLayoutItem398.IsUpdItem = true;
            // 
            // singleLayoutItem399
            // 
            this.singleLayoutItem399.BindControl = this.cbxEnema;
            this.singleLayoutItem399.DataName = "enema_yn";
            this.singleLayoutItem399.IsUpdItem = true;
            // 
            // singleLayoutItem400
            // 
            this.singleLayoutItem400.BindControl = this.cbxLaxative;
            this.singleLayoutItem400.DataName = "laxative_yn";
            this.singleLayoutItem400.IsUpdItem = true;
            // 
            // singleLayoutItem401
            // 
            this.singleLayoutItem401.BindControl = this.cbxSuppository;
            this.singleLayoutItem401.DataName = "suppository_yn";
            this.singleLayoutItem401.IsUpdItem = true;
            // 
            // singleLayoutItem402
            // 
            this.singleLayoutItem402.BindControl = this.cbxAntidiarrheal;
            this.singleLayoutItem402.DataName = "antidiarrheal_yn";
            this.singleLayoutItem402.IsUpdItem = true;
            // 
            // singleLayoutItem403
            // 
            this.singleLayoutItem403.BindControl = this.txtLaxation;
            this.singleLayoutItem403.DataName = "laxation_comment";
            this.singleLayoutItem403.IsUpdItem = true;
            // 
            // singleLayoutItem404
            // 
            this.singleLayoutItem404.BindControl = this.cboUrinCnt;
            this.singleLayoutItem404.DataName = "urin_count";
            this.singleLayoutItem404.IsUpdItem = true;
            // 
            // singleLayoutItem405
            // 
            this.singleLayoutItem405.BindControl = this.cboUrinDay;
            this.singleLayoutItem405.DataName = "urin_day";
            this.singleLayoutItem405.IsUpdItem = true;
            // 
            // singleLayoutItem406
            // 
            this.singleLayoutItem406.BindControl = this.txtUrinNightCnt;
            this.singleLayoutItem406.DataName = "urin_night_count";
            this.singleLayoutItem406.IsUpdItem = true;
            // 
            // singleLayoutItem407
            // 
            this.singleLayoutItem407.BindControl = this.gbxUrinWill;
            this.singleLayoutItem407.DataName = "urin_will_yn";
            this.singleLayoutItem407.IsUpdItem = true;
            // 
            // singleLayoutItem408
            // 
            this.singleLayoutItem408.BindControl = this.cbxIntermittent;
            this.singleLayoutItem408.DataName = "intermittent_yn";
            this.singleLayoutItem408.IsUpdItem = true;
            // 
            // singleLayoutItem409
            // 
            this.singleLayoutItem409.BindControl = this.txtIntermittent;
            this.singleLayoutItem409.DataName = "intermittent_comment";
            this.singleLayoutItem409.IsUpdItem = true;
            // 
            // singleLayoutItem410
            // 
            this.singleLayoutItem410.BindControl = this.cbxCatheter;
            this.singleLayoutItem410.DataName = "catheter_yn";
            this.singleLayoutItem410.IsUpdItem = true;
            // 
            // singleLayoutItem411
            // 
            this.singleLayoutItem411.BindControl = this.dtpCatheter;
            this.singleLayoutItem411.DataName = "catheter_start_date";
            this.singleLayoutItem411.IsUpdItem = true;
            // 
            // singleLayoutItem412
            // 
            this.singleLayoutItem412.BindControl = this.cbxAbdominal;
            this.singleLayoutItem412.DataName = "abdominal_inflation_yn";
            this.singleLayoutItem412.IsUpdItem = true;
            // 
            // singleLayoutItem413
            // 
            this.singleLayoutItem413.BindControl = this.cbxAbtominalVery;
            this.singleLayoutItem413.DataName = "abdominal_inflation_very_yn";
            this.singleLayoutItem413.IsUpdItem = true;
            // 
            // singleLayoutItem414
            // 
            this.singleLayoutItem414.BindControl = this.cbxEnterokinesia;
            this.singleLayoutItem414.DataName = "enterokinesia_yn";
            this.singleLayoutItem414.IsUpdItem = true;
            // 
            // singleLayoutItem415
            // 
            this.singleLayoutItem415.BindControl = this.txtAssessment2;
            this.singleLayoutItem415.DataName = "assessment_2";
            this.singleLayoutItem415.IsUpdItem = true;
            // 
            // singleLayoutItem416
            // 
            this.singleLayoutItem416.BindControl = this.cboFood_ADL;
            this.singleLayoutItem416.DataName = "adl_food_state";
            this.singleLayoutItem416.IsUpdItem = true;
            // 
            // singleLayoutItem417
            // 
            this.singleLayoutItem417.BindControl = this.txtFood_ADL;
            this.singleLayoutItem417.DataName = "adl_food_comment";
            this.singleLayoutItem417.IsUpdItem = true;
            // 
            // singleLayoutItem418
            // 
            this.singleLayoutItem418.BindControl = this.cboBath_ADL;
            this.singleLayoutItem418.DataName = "adl_bath_state";
            this.singleLayoutItem418.IsUpdItem = true;
            // 
            // singleLayoutItem419
            // 
            this.singleLayoutItem419.BindControl = this.txtBath_ADL;
            this.singleLayoutItem419.DataName = "adl_bath_comment";
            this.singleLayoutItem419.IsUpdItem = true;
            // 
            // singleLayoutItem420
            // 
            this.singleLayoutItem420.BindControl = this.cboCloth_ADL;
            this.singleLayoutItem420.DataName = "adl_cloth_state";
            this.singleLayoutItem420.IsUpdItem = true;
            // 
            // singleLayoutItem421
            // 
            this.singleLayoutItem421.BindControl = this.txtCloth_ADL;
            this.singleLayoutItem421.DataName = "adl_cloth_comment";
            this.singleLayoutItem421.IsUpdItem = true;
            // 
            // singleLayoutItem422
            // 
            this.singleLayoutItem422.BindControl = this.cboWash_ADL;
            this.singleLayoutItem422.DataName = "adl_wash_state";
            this.singleLayoutItem422.IsUpdItem = true;
            // 
            // singleLayoutItem423
            // 
            this.singleLayoutItem423.BindControl = this.txtWash_ADL;
            this.singleLayoutItem423.DataName = "adl_wash_comment";
            this.singleLayoutItem423.IsUpdItem = true;
            // 
            // singleLayoutItem425
            // 
            this.singleLayoutItem425.BindControl = this.cboExcretion_ADL;
            this.singleLayoutItem425.DataName = "adl_excretion_state";
            this.singleLayoutItem425.IsUpdItem = true;
            // 
            // singleLayoutItem426
            // 
            this.singleLayoutItem426.BindControl = this.txtExcretion_ADL;
            this.singleLayoutItem426.DataName = "adl_excretion_comment";
            this.singleLayoutItem426.IsUpdItem = true;
            // 
            // singleLayoutItem427
            // 
            this.singleLayoutItem427.BindControl = this.cboStruggle_ADL;
            this.singleLayoutItem427.DataName = "adl_struggle_state";
            this.singleLayoutItem427.IsUpdItem = true;
            // 
            // singleLayoutItem428
            // 
            this.singleLayoutItem428.BindControl = this.txtStruggle_ADL;
            this.singleLayoutItem428.DataName = "adl_struggle_comment";
            this.singleLayoutItem428.IsUpdItem = true;
            // 
            // singleLayoutItem429
            // 
            this.singleLayoutItem429.BindControl = this.cboBoard_ADL;
            this.singleLayoutItem429.DataName = "adl_board_state";
            this.singleLayoutItem429.IsUpdItem = true;
            // 
            // singleLayoutItem430
            // 
            this.singleLayoutItem430.BindControl = this.txtBoard_ADL;
            this.singleLayoutItem430.DataName = "adl_board_comment";
            this.singleLayoutItem430.IsUpdItem = true;
            // 
            // singleLayoutItem431
            // 
            this.singleLayoutItem431.BindControl = this.cboWheelchair_ADL;
            this.singleLayoutItem431.DataName = "adl_wheelchair_state";
            this.singleLayoutItem431.IsUpdItem = true;
            // 
            // singleLayoutItem432
            // 
            this.singleLayoutItem432.BindControl = this.txtWheelchair_ADL;
            this.singleLayoutItem432.DataName = "adl_wheelchair_comment";
            this.singleLayoutItem432.IsUpdItem = true;
            // 
            // singleLayoutItem433
            // 
            this.singleLayoutItem433.BindControl = this.cboWalk_ADL;
            this.singleLayoutItem433.DataName = "adl_walk_state";
            this.singleLayoutItem433.IsUpdItem = true;
            // 
            // singleLayoutItem434
            // 
            this.singleLayoutItem434.BindControl = this.txtWalk_ADL;
            this.singleLayoutItem434.DataName = "adl_walk_comment";
            this.singleLayoutItem434.IsUpdItem = true;
            // 
            // singleLayoutItem435
            // 
            this.singleLayoutItem435.BindControl = this.gbxNeedCare;
            this.singleLayoutItem435.DataName = "need_care";
            this.singleLayoutItem435.IsUpdItem = true;
            // 
            // singleLayoutItem436
            // 
            this.singleLayoutItem436.BindControl = this.gbxNeedSupport;
            this.singleLayoutItem436.DataName = "need_support";
            this.singleLayoutItem436.IsUpdItem = true;
            // 
            // singleLayoutItem437
            // 
            this.singleLayoutItem437.BindControl = this.txtService;
            this.singleLayoutItem437.DataName = "service_comment";
            this.singleLayoutItem437.IsUpdItem = true;
            // 
            // singleLayoutItem438
            // 
            this.singleLayoutItem438.BindControl = this.txtCareOffice;
            this.singleLayoutItem438.DataName = "care_office_comment";
            this.singleLayoutItem438.IsUpdItem = true;
            // 
            // singleLayoutItem439
            // 
            this.singleLayoutItem439.BindControl = this.txtSleepTime;
            this.singleLayoutItem439.DataName = "sleep_time";
            this.singleLayoutItem439.IsUpdItem = true;
            // 
            // singleLayoutItem440
            // 
            this.singleLayoutItem440.BindControl = this.txtSleepStart;
            this.singleLayoutItem440.DataName = "sleep_start_time";
            this.singleLayoutItem440.IsUpdItem = true;
            // 
            // singleLayoutItem441
            // 
            this.singleLayoutItem441.BindControl = this.txtSleepEnd;
            this.singleLayoutItem441.DataName = "sleep_end_time";
            this.singleLayoutItem441.IsUpdItem = true;
            // 
            // singleLayoutItem442
            // 
            this.singleLayoutItem442.BindControl = this.gbxSleepEnough;
            this.singleLayoutItem442.DataName = "sleep_enough_yn";
            this.singleLayoutItem442.IsUpdItem = true;
            // 
            // singleLayoutItem443
            // 
            this.singleLayoutItem443.BindControl = this.txtSleepEnough;
            this.singleLayoutItem443.DataName = "sleep_enough_comment";
            this.singleLayoutItem443.IsUpdItem = true;
            // 
            // singleLayoutItem444
            // 
            this.singleLayoutItem444.BindControl = this.txtSleepLess;
            this.singleLayoutItem444.DataName = "sleepless_comment";
            this.singleLayoutItem444.IsUpdItem = true;
            // 
            // singleLayoutItem445
            // 
            this.singleLayoutItem445.BindControl = this.cbxSnoring;
            this.singleLayoutItem445.DataName = "snoring_yn";
            this.singleLayoutItem445.IsUpdItem = true;
            // 
            // singleLayoutItem446
            // 
            this.singleLayoutItem446.BindControl = this.cbxSleepTalk;
            this.singleLayoutItem446.DataName = "sleep_talk_yn";
            this.singleLayoutItem446.IsUpdItem = true;
            // 
            // singleLayoutItem447
            // 
            this.singleLayoutItem447.BindControl = this.cbxTeethGrinding;
            this.singleLayoutItem447.DataName = "teeth_grinding_yn";
            this.singleLayoutItem447.IsUpdItem = true;
            // 
            // singleLayoutItem448
            // 
            this.singleLayoutItem448.BindControl = this.cbxSleepEtc;
            this.singleLayoutItem448.DataName = "sleep_etc_yn";
            this.singleLayoutItem448.IsUpdItem = true;
            // 
            // singleLayoutItem449
            // 
            this.singleLayoutItem449.BindControl = this.txtSleepEtc;
            this.singleLayoutItem449.DataName = "sleep_etc_comment";
            this.singleLayoutItem449.IsUpdItem = true;
            // 
            // singleLayoutItem450
            // 
            this.singleLayoutItem450.BindControl = this.txtAssessment4;
            this.singleLayoutItem450.DataName = "assessment_4";
            this.singleLayoutItem450.IsUpdItem = true;
            // 
            // singleLayoutItem451
            // 
            this.singleLayoutItem451.BindControl = this.cboSenseLevel;
            this.singleLayoutItem451.DataName = "sense_level";
            this.singleLayoutItem451.IsUpdItem = true;
            // 
            // singleLayoutItem452
            // 
            this.singleLayoutItem452.BindControl = this.gbxObstacleSpeech;
            this.singleLayoutItem452.DataName = "obstacle_speech_yn";
            this.singleLayoutItem452.IsUpdItem = true;
            // 
            // singleLayoutItem453
            // 
            this.singleLayoutItem453.BindControl = this.gbxObstacleSense;
            this.singleLayoutItem453.DataName = "obstacle_sense_yn";
            this.singleLayoutItem453.IsUpdItem = true;
            // 
            // singleLayoutItem454
            // 
            this.singleLayoutItem454.BindControl = this.gbxObstacle;
            this.singleLayoutItem454.DataName = "obstacle_yn";
            this.singleLayoutItem454.IsUpdItem = true;
            // 
            // singleLayoutItem455
            // 
            this.singleLayoutItem455.BindControl = this.txtObstacle;
            this.singleLayoutItem455.DataName = "obstacle_comment";
            this.singleLayoutItem455.IsUpdItem = true;
            // 
            // singleLayoutItem456
            // 
            this.singleLayoutItem456.BindControl = this.gbxRecognition;
            this.singleLayoutItem456.DataName = "recognition_yn";
            this.singleLayoutItem456.IsUpdItem = true;
            // 
            // singleLayoutItem457
            // 
            this.singleLayoutItem457.BindControl = this.txtRecognition;
            this.singleLayoutItem457.DataName = "recognition_comment";
            this.singleLayoutItem457.IsUpdItem = true;
            // 
            // singleLayoutItem458
            // 
            this.singleLayoutItem458.BindControl = this.gbxSensor;
            this.singleLayoutItem458.DataName = "sensor_yn";
            this.singleLayoutItem458.IsUpdItem = true;
            // 
            // singleLayoutItem459
            // 
            this.singleLayoutItem459.BindControl = this.cbxEyeRight;
            this.singleLayoutItem459.DataName = "eye_right_yn";
            this.singleLayoutItem459.IsUpdItem = true;
            // 
            // singleLayoutItem460
            // 
            this.singleLayoutItem460.BindControl = this.txtEyeRight;
            this.singleLayoutItem460.DataName = "eye_right_comment";
            this.singleLayoutItem460.IsUpdItem = true;
            // 
            // singleLayoutItem461
            // 
            this.singleLayoutItem461.BindControl = this.cbxEyeLeft;
            this.singleLayoutItem461.DataName = "eye_left_yn";
            this.singleLayoutItem461.IsUpdItem = true;
            // 
            // singleLayoutItem462
            // 
            this.singleLayoutItem462.BindControl = this.txtEyeLeft;
            this.singleLayoutItem462.DataName = "eye_left_comment";
            this.singleLayoutItem462.IsUpdItem = true;
            // 
            // singleLayoutItem463
            // 
            this.singleLayoutItem463.BindControl = this.gbxGlasses;
            this.singleLayoutItem463.DataName = "eye_glasses_yn";
            this.singleLayoutItem463.IsUpdItem = true;
            // 
            // singleLayoutItem464
            // 
            this.singleLayoutItem464.BindControl = this.gbxLens;
            this.singleLayoutItem464.DataName = "eye_lens_yn";
            this.singleLayoutItem464.IsUpdItem = true;
            // 
            // singleLayoutItem465
            // 
            this.singleLayoutItem465.BindControl = this.cbxEarRight;
            this.singleLayoutItem465.DataName = "ear_right_yn";
            this.singleLayoutItem465.IsUpdItem = true;
            // 
            // singleLayoutItem466
            // 
            this.singleLayoutItem466.BindControl = this.txtEarRight;
            this.singleLayoutItem466.DataName = "ear_right_comment";
            this.singleLayoutItem466.IsUpdItem = true;
            // 
            // singleLayoutItem467
            // 
            this.singleLayoutItem467.BindControl = this.cbxEarLeft;
            this.singleLayoutItem467.DataName = "ear_left_yn";
            this.singleLayoutItem467.IsUpdItem = true;
            // 
            // singleLayoutItem468
            // 
            this.singleLayoutItem468.BindControl = this.txtEarLeft;
            this.singleLayoutItem468.DataName = "ear_left_comment";
            this.singleLayoutItem468.IsUpdItem = true;
            // 
            // singleLayoutItem469
            // 
            this.singleLayoutItem469.BindControl = this.gbxEarAid;
            this.singleLayoutItem469.DataName = "ear_aid_yn";
            this.singleLayoutItem469.IsUpdItem = true;
            // 
            // singleLayoutItem470
            // 
            this.singleLayoutItem470.BindControl = this.txtNose;
            this.singleLayoutItem470.DataName = "nose_comment";
            this.singleLayoutItem470.IsUpdItem = true;
            // 
            // singleLayoutItem471
            // 
            this.singleLayoutItem471.BindControl = this.txtMouth;
            this.singleLayoutItem471.DataName = "mouth_comment";
            this.singleLayoutItem471.IsUpdItem = true;
            // 
            // singleLayoutItem472
            // 
            this.singleLayoutItem472.BindControl = this.gbxDizzy;
            this.singleLayoutItem472.DataName = "dizzy_yn";
            this.singleLayoutItem472.IsUpdItem = true;
            // 
            // singleLayoutItem473
            // 
            this.singleLayoutItem473.BindControl = this.txtDizzy;
            this.singleLayoutItem473.DataName = "dizzy_comment";
            this.singleLayoutItem473.IsUpdItem = true;
            // 
            // singleLayoutItem474
            // 
            this.singleLayoutItem474.BindControl = this.gbxStagger;
            this.singleLayoutItem474.DataName = "stagger_yn";
            this.singleLayoutItem474.IsUpdItem = true;
            // 
            // singleLayoutItem475
            // 
            this.singleLayoutItem475.BindControl = this.txtStagger;
            this.singleLayoutItem475.DataName = "stagger_comment";
            this.singleLayoutItem475.IsUpdItem = true;
            // 
            // singleLayoutItem476
            // 
            this.singleLayoutItem476.BindControl = this.gbxPain;
            this.singleLayoutItem476.DataName = "pain_yn";
            this.singleLayoutItem476.IsUpdItem = true;
            // 
            // singleLayoutItem477
            // 
            this.singleLayoutItem477.BindControl = this.txtPain;
            this.singleLayoutItem477.DataName = "pain_comment";
            this.singleLayoutItem477.IsUpdItem = true;
            // 
            // singleLayoutItem478
            // 
            this.singleLayoutItem478.BindControl = this.gbxPerception;
            this.singleLayoutItem478.DataName = "perception_yn";
            this.singleLayoutItem478.IsUpdItem = true;
            // 
            // singleLayoutItem479
            // 
            this.singleLayoutItem479.BindControl = this.txtPerception;
            this.singleLayoutItem479.DataName = "perception_comment";
            this.singleLayoutItem479.IsUpdItem = true;
            // 
            // singleLayoutItem480
            // 
            this.singleLayoutItem480.BindControl = this.gbxMovement;
            this.singleLayoutItem480.DataName = "movement_yn";
            this.singleLayoutItem480.IsUpdItem = true;
            // 
            // singleLayoutItem481
            // 
            this.singleLayoutItem481.BindControl = this.gbxParalysis;
            this.singleLayoutItem481.DataName = "paralysis_yn";
            this.singleLayoutItem481.IsUpdItem = true;
            // 
            // singleLayoutItem482
            // 
            this.singleLayoutItem482.BindControl = this.txtParalysis;
            this.singleLayoutItem482.DataName = "paralysis_comment";
            this.singleLayoutItem482.IsUpdItem = true;
            // 
            // singleLayoutItem483
            // 
            this.singleLayoutItem483.BindControl = this.gbxContracture;
            this.singleLayoutItem483.DataName = "contracture_yn";
            this.singleLayoutItem483.IsUpdItem = true;
            // 
            // singleLayoutItem484
            // 
            this.singleLayoutItem484.BindControl = this.txtContracture;
            this.singleLayoutItem484.DataName = "contracture_comment";
            this.singleLayoutItem484.IsUpdItem = true;
            // 
            // singleLayoutItem485
            // 
            this.singleLayoutItem485.BindControl = this.gbxLossPart;
            this.singleLayoutItem485.DataName = "loss_part_yn";
            this.singleLayoutItem485.IsUpdItem = true;
            // 
            // singleLayoutItem486
            // 
            this.singleLayoutItem486.BindControl = this.txtLossPart;
            this.singleLayoutItem486.DataName = "loss_part_comment";
            this.singleLayoutItem486.IsUpdItem = true;
            // 
            // singleLayoutItem487
            // 
            this.singleLayoutItem487.BindControl = this.gbxWorry;
            this.singleLayoutItem487.DataName = "worry_yn";
            this.singleLayoutItem487.IsUpdItem = true;
            // 
            // singleLayoutItem488
            // 
            this.singleLayoutItem488.BindControl = this.txtWorry;
            this.singleLayoutItem488.DataName = "worry_comment";
            this.singleLayoutItem488.IsUpdItem = true;
            // 
            // singleLayoutItem489
            // 
            this.singleLayoutItem489.BindControl = this.gbxFear;
            this.singleLayoutItem489.DataName = "fear_yn";
            this.singleLayoutItem489.IsUpdItem = true;
            // 
            // singleLayoutItem490
            // 
            this.singleLayoutItem490.BindControl = this.txtFear;
            this.singleLayoutItem490.DataName = "fear_comment";
            this.singleLayoutItem490.IsUpdItem = true;
            // 
            // singleLayoutItem491
            // 
            this.singleLayoutItem491.BindControl = this.txtAssessment5;
            this.singleLayoutItem491.DataName = "assessment_5";
            this.singleLayoutItem491.IsUpdItem = true;
            // 
            // singleLayoutItem492
            // 
            this.singleLayoutItem492.BindControl = this.gbxFamily;
            this.singleLayoutItem492.DataName = "family_yn";
            this.singleLayoutItem492.IsUpdItem = true;
            // 
            // singleLayoutItem493
            // 
            this.singleLayoutItem493.BindControl = this.txtFamily;
            this.singleLayoutItem493.DataName = "family_comment";
            this.singleLayoutItem493.IsUpdItem = true;
            // 
            // singleLayoutItem494
            // 
            this.singleLayoutItem494.BindControl = this.txtJob;
            this.singleLayoutItem494.DataName = "job";
            this.singleLayoutItem494.IsUpdItem = true;
            // 
            // singleLayoutItem495
            // 
            this.singleLayoutItem495.BindControl = this.txtJobMate;
            this.singleLayoutItem495.DataName = "job_mate";
            this.singleLayoutItem495.IsUpdItem = true;
            // 
            // singleLayoutItem496
            // 
            this.singleLayoutItem496.BindControl = this.cboHouseKind;
            this.singleLayoutItem496.DataName = "house_kind";
            this.singleLayoutItem496.IsUpdItem = true;
            // 
            // singleLayoutItem497
            // 
            this.singleLayoutItem497.BindControl = this.gbxBarrierFree;
            this.singleLayoutItem497.DataName = "barrier_free_yn";
            this.singleLayoutItem497.IsUpdItem = true;
            // 
            // singleLayoutItem498
            // 
            this.singleLayoutItem498.BindControl = this.cboMenses;
            this.singleLayoutItem498.DataName = "menses";
            this.singleLayoutItem498.IsUpdItem = true;
            // 
            // singleLayoutItem499
            // 
            this.singleLayoutItem499.BindControl = this.txtMensesAge;
            this.singleLayoutItem499.DataName = "menses_age";
            this.singleLayoutItem499.IsUpdItem = true;
            // 
            // singleLayoutItem500
            // 
            this.singleLayoutItem500.BindControl = this.gbxMensesProblem;
            this.singleLayoutItem500.DataName = "menses_problem_yn";
            this.singleLayoutItem500.IsUpdItem = true;
            // 
            // singleLayoutItem501
            // 
            this.singleLayoutItem501.BindControl = this.txtMensesProblem;
            this.singleLayoutItem501.DataName = "menses_problem_comment";
            this.singleLayoutItem501.IsUpdItem = true;
            // 
            // singleLayoutItem502
            // 
            this.singleLayoutItem502.BindControl = this.gbxPregnancy;
            this.singleLayoutItem502.DataName = "pregnancy_yn";
            this.singleLayoutItem502.IsUpdItem = true;
            // 
            // singleLayoutItem503
            // 
            this.singleLayoutItem503.BindControl = this.gbxHobby;
            this.singleLayoutItem503.DataName = "hobby_yn";
            this.singleLayoutItem503.IsUpdItem = true;
            // 
            // singleLayoutItem504
            // 
            this.singleLayoutItem504.BindControl = this.txtHobby;
            this.singleLayoutItem504.DataName = "hobby_comment";
            this.singleLayoutItem504.IsUpdItem = true;
            // 
            // singleLayoutItem505
            // 
            this.singleLayoutItem505.BindControl = this.gbxStress;
            this.singleLayoutItem505.DataName = "stress_yn";
            this.singleLayoutItem505.IsUpdItem = true;
            // 
            // singleLayoutItem506
            // 
            this.singleLayoutItem506.BindControl = this.txtStress;
            this.singleLayoutItem506.DataName = "stress_comment";
            this.singleLayoutItem506.IsUpdItem = true;
            // 
            // singleLayoutItem507
            // 
            this.singleLayoutItem507.BindControl = this.txtStressManage;
            this.singleLayoutItem507.DataName = "stress_manage";
            this.singleLayoutItem507.IsUpdItem = true;
            // 
            // singleLayoutItem508
            // 
            this.singleLayoutItem508.BindControl = this.gbxReligion;
            this.singleLayoutItem508.DataName = "religion_yn";
            this.singleLayoutItem508.IsUpdItem = true;
            // 
            // singleLayoutItem509
            // 
            this.singleLayoutItem509.BindControl = this.txtReligion;
            this.singleLayoutItem509.DataName = "religion_comment";
            this.singleLayoutItem509.IsUpdItem = true;
            // 
            // singleLayoutItem510
            // 
            this.singleLayoutItem510.BindControl = this.txtAssessment7;
            this.singleLayoutItem510.DataName = "assessment_7";
            this.singleLayoutItem510.IsUpdItem = true;
            // 
            // NUR1001U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1001U00";
            this.Size = new System.Drawing.Size(1156, 635);
            this.UserChanged += new System.EventHandler(this.NUR1001U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1001U00_ScreenOpen);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1004)).EndInit();
            this.gbxWith.ResumeLayout(false);
            this.gbxWith.PerformLayout();
            this.gbxLive.ResumeLayout(false);
            this.gbxLive.PerformLayout();
            this.xPanel5.ResumeLayout(false);
            this.xPanel5.PerformLayout();
            this.pnlINP1004.ResumeLayout(false);
            this.pnlINP1004.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1002)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.tabPatient.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlPatientInfoRight.ResumeLayout(false);
            this.pnlPatientInfoRight.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnListTukki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0106)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.pnlPatientInfoLeft.ResumeLayout(false);
            this.pnlPatientInfoLeft.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pnlHealthRight.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1017)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1016)).EndInit();
            this.pnlHealthLeft.ResumeLayout(false);
            this.pnlHealthLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmoking)).EndInit();
            this.gbxHealthCare.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.gbxBringDrug.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            this.xPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1029)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.gbxUrinWill.ResumeLayout(false);
            this.gbxUrinWill.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbxDungWill.ResumeLayout(false);
            this.gbxDungWill.PerformLayout();
            this.pnlFood.ResumeLayout(false);
            this.pnlFood.PerformLayout();
            this.gbxFalseTeeth.ResumeLayout(false);
            this.gbxFalseTeeth.PerformLayout();
            this.gbxMouthPollution.ResumeLayout(false);
            this.gbxMouthPollution.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbxDysphagia.ResumeLayout(false);
            this.gbxDysphagia.PerformLayout();
            this.gbxAppetite.ResumeLayout(false);
            this.gbxAppetite.PerformLayout();
            this.gbxFoodDislike.ResumeLayout(false);
            this.gbxFoodDislike.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.xPanel9.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.gbxSleepEnough.ResumeLayout(false);
            this.gbxSleepEnough.PerformLayout();
            this.xPanel14.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.gbxNeedSupport.ResumeLayout(false);
            this.gbxNeedSupport.PerformLayout();
            this.gbxNeedCare.ResumeLayout(false);
            this.gbxNeedCare.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.pnlPerceptionRight.ResumeLayout(false);
            this.pnlPerceptionRight.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.gbxPerception.ResumeLayout(false);
            this.gbxPerception.PerformLayout();
            this.gbxFear.ResumeLayout(false);
            this.gbxFear.PerformLayout();
            this.gbxWorry.ResumeLayout(false);
            this.gbxWorry.PerformLayout();
            this.gbxMovement.ResumeLayout(false);
            this.gbxMovement.PerformLayout();
            this.gbxPain.ResumeLayout(false);
            this.gbxPain.PerformLayout();
            this.gbxStagger.ResumeLayout(false);
            this.gbxStagger.PerformLayout();
            this.gbxDizzy.ResumeLayout(false);
            this.gbxDizzy.PerformLayout();
            this.gbxMovementDetail.ResumeLayout(false);
            this.gbxMovementDetail.PerformLayout();
            this.gbxLossPart.ResumeLayout(false);
            this.gbxLossPart.PerformLayout();
            this.gbxContracture.ResumeLayout(false);
            this.gbxContracture.PerformLayout();
            this.gbxParalysis.ResumeLayout(false);
            this.gbxParalysis.PerformLayout();
            this.pnlPerceptionLeft.ResumeLayout(false);
            this.pnlPerceptionLeft.PerformLayout();
            this.gbxRecognition.ResumeLayout(false);
            this.gbxRecognition.PerformLayout();
            this.gbxSensor.ResumeLayout(false);
            this.gbxSensor.PerformLayout();
            this.gbxSensorDetail.ResumeLayout(false);
            this.gbxSensorDetail.PerformLayout();
            this.gbxGlasses.ResumeLayout(false);
            this.gbxGlasses.PerformLayout();
            this.gbxLens.ResumeLayout(false);
            this.gbxLens.PerformLayout();
            this.gbxEarAid.ResumeLayout(false);
            this.gbxEarAid.PerformLayout();
            this.gbxObstacle.ResumeLayout(false);
            this.gbxObstacle.PerformLayout();
            this.gbxObstacleSense.ResumeLayout(false);
            this.gbxObstacleSense.PerformLayout();
            this.gbxObstacleSpeech.ResumeLayout(false);
            this.gbxObstacleSpeech.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.xPanel15.ResumeLayout(false);
            this.xPanel15.PerformLayout();
            this.gbxFamily.ResumeLayout(false);
            this.gbxFamily.PerformLayout();
            this.gbxStress.ResumeLayout(false);
            this.gbxStress.PerformLayout();
            this.gbxMens.ResumeLayout(false);
            this.gbxMens.PerformLayout();
            this.gbxPregnancy.ResumeLayout(false);
            this.gbxPregnancy.PerformLayout();
            this.gbxMensesProblem.ResumeLayout(false);
            this.gbxMensesProblem.PerformLayout();
            this.gbxHobby.ResumeLayout(false);
            this.gbxHobby.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.gbxReligion.ResumeLayout(false);
            this.gbxReligion.PerformLayout();
            this.gbxBarrierFree.ResumeLayout(false);
            this.gbxBarrierFree.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layReserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

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
				case "jeawonYn":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." + " 환자번호를 확인해 주세요"
						: "在院中の患者ではありません。患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "query":
					msg = (NetInfo.Language == LangMode.Ko ? "조회실패."
						: "照会失敗。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "エラー");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。ご確認ください。";
                    //msg += "\r\n[" + this.dsvNUR1001Update.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "エラー";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;

                case "bunho":
                    msg = (NetInfo.Language == LangMode.Ko ? "환자번호를 입력해주세요."
                        : "患者番号を入力してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;

				default:
					break;
			}
		}
		#endregion

		/// <summary>
		/// 화면을 클리어 한다.
		/// </summary>
		/// <param name="aScreenYn">
		/// 화면 잠금여부
		/// </param>
		#region 화면 클리어
		private void ResetControl(Control parent)
		{
			//this.grdInp1001.Reset();
			foreach (Control cont in parent.Controls)
			{
				if (cont is IDataControl)
				{
					((IDataControl) cont).ResetData();
				}
				else if(cont is XRadioButton)
				{
					((XRadioButton)cont).Checked = false;
				}
				else if ((cont.Controls != null) && (cont.Controls.Count > 0))
					ResetControl(cont);
			}
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
            if (aComboGubun == "ANAMUNE_SINDAN")
            {
                object retVal = Service.ExecuteScalar("");
                aComboGubun += "_" + grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ho_dong");
                this.layComboSet.SetBindVarValue("f_code_type", aComboGubun );
            }

            this.layComboSet.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layComboSet.SetBindVarValue("f_code_type", aComboGubun);

            if (layComboSet.QueryLayout(false))
            {
                if (this.layComboSet.LayoutTable.Rows.Count > 0)
                {

                    switch (aComboGubun)
                    {
                        case "MAIN_FOOD":
                                this.cboMainFood.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                this.cboSubFood.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                            break;
                        case "ACTIVITY_LEVEL":
                                //this.cboAdl_food_yn.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                //this.cboAdl_bath_yn.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                //this.cboAdl_cloth_yn.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                //this.cboAdl_wash_yn.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                //this.cboAdl_excretion_yn.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                //this.cboActivity_struggle_yn.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                //this.cboActivity_seat_yn.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                //this.cboActivity_chair_yn.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                //this.cboActivity_wark_yn.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                            break;
                        case "FAMILY_ROLE":
                                //this.cboFamily_role.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                            break;
                        case "HOUSE_KIND":
                                this.cboHouseKind.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                            break;
                        case "TRAFFIC_METHOD":
                                //this.cboTraffic_method.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                            break;
                        case "SENSE_STYLE":
                                this.cboSenseLevel.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                                //this.cmbSense_style.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                            break;

                        case "ANAMUNE_PURPOSE":
                                this.cboPurpose.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                            break;

                        case "ANAMUNE_SINDAN_C2":
                                this.cboDignosisGubun.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                            break;

                        case "ANAMUNE_SINDAN_C3":
                                this.cboDignosisGubun.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }
		}

        private void GetComboSetting(XComboBox cbo, string aComboGubun)
        {
            cbo.SetComboItems(layComboSet.LayoutTable.Select("code_type = '" + aComboGubun + "'"), "code_name", "code");
        }
		#endregion

		/// <summary>
		/// 환자의 재원정보를 조회한다.
		/// </summary>
		#region 재원정보 조회
		private void Load_Patient_Info()
		{
			this.txtFkinp1001.Clear();
			this.grdINP1001.Reset();
            //this.dtpJukyong_date.ResetData();
			this.txtBunho.Clear();

			/* 환자의 입원이력을 조회한다. */
			if(grdINP1001.QueryLayout(false))
			{
				//재원환자이면
				if (this.grdINP1001.GetItemString(this.grdINP1001.CurrentRowNumber,"jaewon_flag") == "Y")
				{
					//this.txtFkinp1001.SetEditValue(this.dsvFkinp1001.GetOutValue("fkinp1001").ToString());
                    //this.dtpJukyong_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

					this.tabPage1.Enabled = true;
					this.tabPage2.Enabled = true;
					this.tabPage3.Enabled = true;
					this.tabPage4.Enabled = true;
					this.tabPage5.Enabled = true;
					this.tabPage6.Enabled = true;
			
					//기본정보 선택처리
					this.tabPatient.SelectedTab = this.tabPage1;
				}
				else
				{
                    /* dsvReser_fkinp1001 Service 河中*/
					/* 환자가 입원예약환자인지 조회를 한다. */
                    //object retVal = Service.ExecuteScalar("SELECT RESER_FKINP1001 FROM INP1003 WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' AND BUNHO = '" + paBox.BunHo + "' AND RESER_END_TYPE = '0'");
                    this.layReserInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layReserInfo.SetBindVarValue("f_bunho", this.paBox.BunHo);
                    this.layReserInfo.QueryLayout(false);

                    //if(!TypeCheck.IsNull(retVal))
                    if(this.layReserInfo.RowCount > 0)
					{
                        //if (retVal.ToString() != "")
                        if(this.layReserInfo.GetItemString(0, "fkinp1001") != "")
                        {

                            this.grdINP1001.RowFocusChanged -= new IHIS.Framework.RowFocusChangedEventHandler(this.grdInp1001_RowFocusChanged);
							this.grdINP1001.InsertRow(-1);
							this.grdINP1001.SetItemValue(this.grdINP1001.CurrentRowNumber, "bunho", this.paBox.BunHo.ToString());
                            this.grdINP1001.SetItemValue(this.grdINP1001.CurrentRowNumber, "ipwon_date", this.layReserInfo.GetItemString(0, "reser_date"));
							this.grdINP1001.SetItemValue(this.grdINP1001.CurrentRowNumber, "jaewon_flag", "Y");
                            this.grdINP1001.SetItemValue(this.grdINP1001.CurrentRowNumber, "fkinp1001", this.layReserInfo.GetItemString(0, "fkinp1001"));

                            jukyongDateQuery = this.layReserInfo.GetItemString(0, "reser_date");
                            this.grdINP1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdInp1001_RowFocusChanged);

							//재원환자정보로드
							if(this.layINP1001.QueryLayout())
                            {
                                /// 환자 기본 정보 조회 201005 河中
                                if (!BasicQuery())
                                {
                                    return;
                                }
							}

							if(grdINP1004.QueryLayout(false))
							{
							}
							else
							{
								XMessageBox.Show(Service.ErrFullMsg.ToString());
								return;
							}
						}
						else
						{
                            //this.dtpJukyong_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
							//this.GetMessage("jeawonYn");
							this.tabPage1.Enabled = true;
							this.tabPage2.Enabled = true;
							this.tabPage3.Enabled = true;
							this.tabPage4.Enabled = true;
							this.tabPage5.Enabled = true;
							this.tabPage6.Enabled = true;

							//기본정보 선택처리
							this.tabPatient.SelectedTab = this.tabPage1;
							return;
						}
					}
					else
					{
                        SetMsg("入院患者ではありません。", MsgType.Error);
					}
				}
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}
		}
		#endregion

        #region 患者基本情報 201005河中 dsvNUR1001Query
        private bool BasicQuery()
        {
            string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();
            object retVal = null;
            DataTable resTbl = new DataTable();

            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_bunho", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho"));
            bindVars.Add("f_fkinp1001", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "fkinp1001"));

            if (this.jukyongDateQuery == "")
                this.jukyongDateQuery = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            bindVars.Add("f_jukyong_date", jukyongDateQuery.Replace("-", "").Replace("/", "").Substring(0, 8));
            
            /* 환자의 키, 체중정보를 조회한다. */
            
            /*
            cmdText = @"SELECT A.HEIGHT HEIGHT,
                               A.WEIGHT WEIGHT
                          FROM NUR7001 A
                         WHERE A.HOSP_CODE = :f_hosp_code
                           AND A.BUNHO     = :f_bunho
                           AND A.VALD      = 'Y'
                           AND A.MEASURE_DATE = (SELECT MAX(B.MEASURE_DATE)
                                                   FROM NUR7001 B
                                                  WHERE B.HOSP_CODE = A.HOSP_CODE 
                                                    AND B.BUNHO     = A.BUNHO
                                                    AND B.VALD      = 'Y'
                                                    AND B.MEASURE_DATE <= :f_jukyong_date)
                           AND A.SEQ          = (SELECT MAX(SEQ)
                                                   FROM NUR7001 C
                                                  WHERE C.HOSP_CODE = A.HOSP_CODE 
                                                    AND C.BUNHO = A.BUNHO
                                                    AND C.VALD = 'Y'
                                                    AND C.MEASURE_DATE = A.MEASURE_DATE)";



            resTbl = Service.ExecuteDataTable(cmdText, bindVars);

            if (resTbl.Rows.Count > 0)
            {
                layNUR1001A.SetItemValue("dbxHeight", resTbl.Rows[0]["height"].ToString());
                layNUR1001A.SetItemValue("dbxWeight", resTbl.Rows[0]["weight"].ToString());
            }
            */

            /* 간호도를 조회한다. */

            /*
            cmdText = string.Empty;
            cmdText = @"SELECT A.GANHODO
                          FROM NUR1011 A
                         WHERE A.HOSP_CODE    = :f_hosp_code 
                           AND A.FKINP1001    = :f_fkinp1001
                           AND A.JUKYONG_DATE = (SELECT MAX(B.JUKYONG_DATE)
                                                   FROM NUR1011 B
                                                  WHERE B.HOSP_CODE = A.HOSP_CODE 
                                                    AND B.FKINP1001 = A.FKINP1001
                                                    AND B.JUKYONG_DATE <= :f_jukyong_date)";
            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (!TypeCheck.IsNull(retVal))
            {
                layNUR1001A.SetItemValue("dbxGanhodo", retVal.ToString());
            }
            */
            
            
            /* 일상생활자립도를 조회한다. */
            /*
            cmdText = string.Empty;
            retVal = null;
            cmdText = @"SELECT A.LIFE_SELF_GRADE
                          FROM NUR1012 A
                         WHERE A.HOSP_CODE    = :f_hosp_code 
                           AND A.FKINP1001    = :f_fkinp1001
                           AND A.JUKYONG_DATE = (SELECT MAX(B.JUKYONG_DATE)
                                                   FROM NUR1012 B
                                                  WHERE B.HOSP_CODE = A.HOSP_CODE 
                                                    AND B.FKINP1001 = A.FKINP1001
                                                    AND B.JUKYONG_DATE <= :f_jukyong_date)";
            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (!TypeCheck.IsNull(retVal))
            {
                layNUR1001A.SetItemValue("dbxJalib", retVal.ToString());
            }
            */


            /* 담당간호사를 조회한다. */
            
            cmdText = string.Empty;
            retVal = null;
            cmdText = @"SELECT FN_ADM_LOAD_USER_NM(A.DAMDANG_NURSE, TRUNC(A.JUKYONG_DATE))||'['||A.DAMDANG_NURSE||']' DAMDANG_NURSE
                          FROM NUR1010 A
                         WHERE A.HOSP_CODE    = :f_hosp_code 
                           AND A.FKINP1001     = :f_fkinp1001
                           AND A.JUKYONG_DATE = (SELECT MAX(B.JUKYONG_DATE)
                                                   FROM NUR1010 B
                                                  WHERE B.HOSP_CODE = A.HOSP_CODE 
                                                    AND B.FKINP1001 = A.FKINP1001
                                                    AND B.JUKYONG_DATE <= :f_jukyong_date)";
            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (!TypeCheck.IsNull(retVal))
            {
                layINP1001.SetItemValue("dbxnurse", retVal.ToString());
            }


            /* 팀을 조회한다. */
            cmdText = string.Empty;
            retVal = null;
            cmdText = @"SELECT A.HO_TEAM
                          FROM NUR0104 A    
                             , INP1001 B
                         WHERE A.HOSP_CODE = :f_hosp_code
                           AND B.HOSP_CODE = A.HOSP_CODE
                           AND B.PKINP1001 = :f_fkinp1001
                           AND A.HO_DONG   = B.HO_DONG1
                           AND A.HO_CODE   = B.HO_CODE1
                           AND A.JUKYONG_DATE = (SELECT MAX(Z.JUKYONG_DATE)
                                                   FROM NUR0104 Z
                                                  WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                    AND Z.HO_DONG   = A.HO_DONG
                                                    AND Z.HO_CODE   = A.HO_CODE  )";
            bindVars.Add("f_ho_dong", layINP1001.GetItemValue("ho_dong").ToString());
            bindVars.Add("f_ho_code", layINP1001.GetItemValue("ho_code").ToString());

            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (!TypeCheck.IsNull(retVal))
            {
                layINP1001.SetItemValue("dbxteam", retVal.ToString());
            }

            /// 남은 컬럼들을 조회 layNUR1001B ///  

            this.GetComboSetting(cboDignosisGubun, "ANAMUNE_SINDAN_" + grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ho_dong"));

            if (!layNUR1001.QueryLayout())
            {
                if (Service.ErrCode != 0)
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    return false;
                }
            } 

            return true;
        }
        #endregion

        private void InitAllCombox()
        {
            layComboSet.QueryLayout(true);

            this.GetComboSetting(cboPurpose,"ANAMUNE_PURPOSE");
            //this.GetComboSetting(cboDignosisGubun,"");
            this.GetComboSetting(cboMainFood,"MAIN_FOOD");
            this.GetComboSetting(cboSubFood,"SUB_FOOD");
            this.GetComboSetting(cboIntakeWay,"ANAMUNE_SESSYU");
            this.GetComboSetting(cboWeightUpdownStart,"ANAMUNE_WEIGHT_DAY");
            this.GetComboSetting(cboWeightUpdownHow,"ANAMUNE_WEIGHT");
            this.GetComboSetting(cboDungCnt,"ANAMUNE_HAIBEN_KAI");
            this.GetComboSetting(cboDungDay,"ANAMUNE_HAIBEN_NITI");
            this.GetComboSetting(cboUrinCnt,"ANAMUNE_HAIBEN_KAI");
            this.GetComboSetting(cboUrinDay,"ANAMUNE_HAIBEN_NITI");
            this.GetComboSetting(cboFood_ADL, "ANAMUNE_ADL_SYOKUZI");
            this.GetComboSetting(cboBath_ADL, "ANAMUNE_ADL_NYUYOKU");
            this.GetComboSetting(cboCloth_ADL, "ANAMUNE_ADL_KIGAE");
            this.GetComboSetting(cboWash_ADL, "ANAMUNE_ADL_SEIYOU");
            this.GetComboSetting(cboExcretion_ADL, "ANAMUNE_ADL_HAISETU");
            this.GetComboSetting(cboStruggle_ADL, "ANAMUNE_ADL_NEGAERI");
            this.GetComboSetting(cboBoard_ADL, "ANAMUNE_ADL_ISYOU");
            this.GetComboSetting(cboWheelchair_ADL, "ANAMUNE_ADL_KURUMA");
            this.GetComboSetting(cboWalk_ADL, "ANAMUNE_ADL_ARUKI");
            this.GetComboSetting(cboSenseLevel, "ANAMUNE_SENSE_LEVEL");
            this.GetComboSetting(cboHouseKind,"ANAMUNE_HOUSEKIND");
            this.GetComboSetting(cboMenses,"ANAMUNE_GEKKEI");
        }



        #region Screen Load
        private void NUR1001U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {

            string basicQuery = @"SELECT CODE, CODE_NAME
                                    FROM BAS0102 
                                   WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "'" +
                      @" AND CODE_TYPE = 'TEL_GUBUN'";

            cboTelGubun.UserSQL = basicQuery;
            cboTelGubun2.UserSQL = basicQuery;
            //cboTelGubun3.UserSQL = basicQuery;
            //cboDispTelGubun.UserSQL = basicQuery;

            /* 콤보박스 셋팅 */
            InitAllCombox();

            /*
            this.GetComboSetting("MAIN_FOOD");
            this.GetComboSetting("MAIN_FOOD");
            this.GetComboSetting("ACTIVITY_LEVEL");
            this.GetComboSetting("FAMILY_RELATION");
            this.GetComboSetting("FAMILY_ROLE");
            this.GetComboSetting("JOB");
            this.GetComboSetting("HOUSE_KIND");
            this.GetComboSetting("TRAFFIC_METHOD");
            this.GetComboSetting("SENSE_STYLE");
            this.GetComboSetting("ANAMUNE_PURPOSE");
            */


            if (this.OpenParam != null)
            {
                this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
            }
            else
            {
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
            }
            
			this.txtUpd_gubun.SetEditValue("I");			

			this.tabPatient.SelectedTab = this.tabPage1;
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

		#region 환자의 등록번호를 입력을 했을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			this.ResetControl(this.tabPatient);
			if(!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
			{
				if(this.paBox.Sex.ToString() == "M")
				{
                    this.gbxMens.Enabled = false;
				}
				else
				{
                    this.gbxMens.Enabled = true;
                    //this.cbxBunman_yn.Enabled = true;
				}
				this.txtBunho.SetEditValue(this.paBox.BunHo.ToString());
                
				/* 재원환자 정보 조회 */
				this.Load_Patient_Info();
			}
			this.tabPatient.SelectedTab = this.tabPage1;
		}
		#endregion
            
		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Update:
					if (IHIS.Framework.EnvironInfo.CurrSystemID == "DRGS")
						return;

					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					e.IsBaseCall = false;

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        //Service.BeginTransaction();

                        if (layNUR1001.SaveLayout())
                        {
                            if (!grdOUT0106.SaveLayout())                            
                                throw new Exception();
                            
                            if (!grdINP1004.SaveLayout())
                                throw new Exception();

                            if (!grdNUR1029.SaveLayout())
                                throw new Exception();

                            grdINP1004.QueryLayout(false);
                        }
                        else
                            throw new Exception();

                        ////약정보를 저장한다.
                        //if (!grdNUR1002.SaveLayout())
                        //    throw new Exception();

                        //환자의 기왕임신분만 정보를 저장한다.
                        //if (grdNur1009.SaveLayout())
                        {
                            //환자의 기왕임신분만 정보를 조회한다.
                            //if (!grdNur1009.QueryLayout(false))
                            {
                                //bthrow new Exception();
                            }
                        }
                        //else
                        //    throw new Exception();
                    }
                    catch 
                    {
                        //Service.RollbackTransaction();
                        XMessageBox.Show("保存に失敗しました。" + "\r\n" + Service.ErrFullMsg, "保存失敗", MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    //Service.CommitTransaction();
                    this.Cursor = Cursors.Default;
                    XMessageBox.Show("保存が完了しました。", "保存", MessageBoxIcon.Information);

					break;
			    case FunctionType.Delete:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					if(this.CurrMSLayout == this.grdNUR1002)
					{
					}
					else
					{
						e.IsBaseCall = false;
						this.ResetControl(this.tabPatient);
						this.txtUpd_gubun.SetEditValue("D");
						this.tabPage1.Enabled = false;
						this.tabPage2.Enabled = false;
						this.tabPage3.Enabled = false;
						this.tabPage4.Enabled = false;
						this.tabPage5.Enabled = false;
						this.tabPage6.Enabled = false;
					}
					break;
				case FunctionType.Insert:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}
					if(this.CurrMSLayout == this.grdNUR1002)
					{
					}
					else
					{
						e.IsBaseCall = false;
					}
					break;
				case FunctionType.Query:
					if(!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
					{
						this.txtBunho.SetEditValue(this.paBox.BunHo.ToString());
						/* 재원화자 정보 조회 */
						this.Load_Patient_Info();
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 신체계측 관리 화면 오픈
		private void btnBodyOpen_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("NURI", "NUR7001U00");

				if (aScreen == null)
				{
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sysid", "NURI");
					openParams.Add( "screen", this.ScreenID.ToString());
					openParams.Add( "bunho", this.paBox.BunHo.ToString());
					openParams.Add( "flag", "Y");
			
					XScreen.OpenScreenWithParam(this,"NURI", "NUR7001U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

		#region 간호도 관리 화면 오픈
		private void btnGanhodoOpen_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("NURI", "NUR1011U00");

				if (aScreen == null)
				{
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sysid", "NURI");
					openParams.Add( "screen", this.ScreenID.ToString());
					openParams.Add( "bunho", this.paBox.BunHo.ToString());
					openParams.Add( "flag", "Y");
			
					XScreen.OpenScreenWithParam(this,"NURI", "NUR1011U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

		#region 일상생활자립도 관리 화면 오픈
		private void btnJalibOpen_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("NURI", "NUR1012U00");

				if (aScreen == null)
				{
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sysid", "NURI");
					openParams.Add( "screen", this.ScreenID.ToString());
					openParams.Add( "bunho", this.paBox.BunHo.ToString());
					openParams.Add( "flag", "Y");
			
					XScreen.OpenScreenWithParam(this,"NURI", "NUR1012U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

		#region 담당간호사 관리 화면 오픈
		private void btnNurseOpen_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("NURI", "NUR1010U00");

				if (aScreen == null)
				{
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sysid", "NURI");
					openParams.Add( "screen", this.ScreenID.ToString());
					openParams.Add( "bunho", this.paBox.BunHo.ToString());
					openParams.Add( "flag", "Y");
			
					XScreen.OpenScreenWithParam(this,"NURI", "NUR1010U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

		#region 팀관리화면 오픈
		private void btnTeamOpen_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add( "sysid", "NURI");
				openParams.Add( "screen", this.ScreenID.ToString());
				openParams.Add( "flag", "Y");
				XScreen.OpenScreenWithParam(this, "NURI", "NUR0104U00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
			}
		}
		#endregion

		#region 팝업화면에서 데이터 받기
		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch (command)
			{
				case "NUR1010U00":
				case "NUR1011U00":
				case "NUR1012U00":
				case "NUR7001U00":
				case "NUR0104U00":
					/* 재조회 */
					this.Load_Patient_Info();
					break;
				case "NUR1017U00":
				case "NUR1016U00":
					/* 재조회 */
					this.Load_Patient_Info();
					this.tabPatient.SelectedIndex = 1;
					break;
				case "BAS0123Q00":
					this.fbxZipCode1.SetEditValue(commandParam["zip_code1"]);
					this.fbxZipCode1.AcceptData();
					this.txtZipCode2.SetEditValue(commandParam["zip_code2"]);
					this.txtZipCode2.AcceptData();
					this.fbxAddress1.SetEditValue(commandParam["address"]);
					this.fbxAddress1.AcceptData();

					break;
                case "OUTSANGQ00":
                    MultiLayout retSang = (MultiLayout)commandParam[0];

                    for (int i = 0; i < retSang.RowCount; i++)
                    {
                        if (mbxDiagnosisName.Text.Length == 0 || mbxDiagnosisName.Text.EndsWith("\r\n"))
                        {
                            mbxDiagnosisName.Text = mbxDiagnosisName.Text + retSang.GetItemString(i, "display_sang_name") + "\r\n";
                        }
                        else
                        {
                            mbxDiagnosisName.Text = "\r\n" + mbxDiagnosisName.Text + retSang.GetItemString(i, "display_sang_name") + "\r\n";
                        }
                    }
                    layNUR1001.SetItemValue("diagnosis_name", mbxDiagnosisName.Text);
                    break;
			}
			return base.Command (command, commandParam);
		}
		#endregion

        private string jukyongDateQuery = "";
		#region 입원일자 변경시 재조회
		private void grdInp1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			//재원환자는 현재일자, 퇴원환자는 퇴원일자로 적용일자로 처리
			if (this.grdINP1001.GetItemString(e.CurrentRow,"jaewon_flag") == "Y")
                jukyongDateQuery = IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
			else
                jukyongDateQuery = this.grdINP1001.GetItemString(e.CurrentRow, "toiwon_date");

            //재원환자정보로드
            if (layINP1001.QueryLayout())
            {
                if (!BasicQuery())
                {
                    return;
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }



            //알레르기 조회 추가 2011.12.21 woo
            if (!this.grdNUR1016.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }

            //감염증 조회 추가 2011.12.21 woo
            if (!this.grdNUR1017.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }

            if (!grdINP1004.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }

            //피부손상 조회 추가 2013.02
            if (!this.grdNUR1029.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }
            //특기사항 조회 추가 2013.02
            if (!grdOUT0106.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }
            ////환자의 약정보 로드
            //if (!grdNUR1002.QueryLayout(false))
            //{
            //    XMessageBox.Show(Service.ErrFullMsg.ToString());
            //    return;
            //}

            //환자의 기왕임신분만 정보를 조회한다.
            //if (!grdNur1009.QueryLayout(false))
            //{
            //    XMessageBox.Show(Service.ErrFullMsg.ToString());
            //    return;
            //}

            this.AcceptData();
		}
		#endregion

        ///// 파인드 박스 셋팅
        ///// </summary>
        ///// <param name="findMode">
        ///// 파인드 구분
        ///// </param>
        ///// <returns></returns>
        //#region [GetFindWorker - Find 창 open]
        //private void SetFindBox(string findMode)
        //{
        //    switch (findMode)
        //    {
				
        //    }
        //}
        //#endregion

		#region 파인드버튼을 클릭을 했을 때
		
		#endregion

		#region FindBox Click (FindWorker Setting)

		private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 공통으로 사용할 파라미터 선언
			//CommonItemCollection param ;
			XFindBox control = sender as XFindBox;

			// 파인드 워커 초기화
            //fwkCommon.InputLayoutItems.Clear();
			fwkCommon.ColInfos.Clear();

			switch (control.Name)
			{
				// 우편번호 창 Open
				case "fbxZipCode1":
					OpenScreen_BAS0123Q00("zipCode", fbxZipCode1.GetDataValue(), txtZipCode2.GetDataValue(), "");
					break;

				// 우편번호 창 Open
				case "fbxAddress1":
					OpenScreen_BAS0123Q00( "address", "", "", fbxAddress1.GetDataValue() );
					break;

				// 본인구분
				case "fbxBoninGubun":
                    fwkCommon.ColInfos.Add("code", "コード", FindColType.String, 60, 0, true, FilterType.InitYes);
                    fwkCommon.ColInfos.Add("code_name", "コード名称", FindColType.String, 240, 0, true, FilterType.InitYes);
                    fwkCommon.InputSQL = @"SELECT A.CODE
                                                , A.CODE_NAME
                                             FROM BAS0102 A
                                            WHERE A.HOSP_CODE = :f_hosp_code 
                                              AND A.CODE_TYPE = :f_code_type
                                              AND(A.CODE      LIKE '%' || :f_find1 || '%'
                                               OR A.CODE_NAME LIKE '%' || :f_find1 || '%' )
                                            ORDER BY 1";
                    fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    fwkCommon.SetBindVarValue("f_code_type", "BONIN_GUBUN");
					fwkCommon.ColInfos[0].ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
					break;

                case "fbxWriter":
                    fwkCommon.ColInfos.Add("user_id", "I　D", FindColType.String, 60, 0, true, FilterType.InitYes);
                    fwkCommon.ColInfos.Add("user_nm", "名前", FindColType.String, 150, 0, true, FilterType.InitYes);
                    fwkCommon.InputSQL = @"SELECT A.USER_ID, A.USER_NM 
                                             FROM ADM3200 A
                                                , BAS0260 B
                                            WHERE A.HOSP_CODE = :f_hosp_code
                                              AND B.HOSP_CODE = A.HOSP_CODE
                                              AND B.BUSEO_CODE = A.DEPT_CODE
                                              AND B.BUSEO_NAME = :f_buseo_name";
                    fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    fwkFind.SetBindVarValue("f_buseo_name", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ho_dong"));
                    fwkCommon.ColInfos[0].ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
                    break;

				default:
					break;
			}
		}

		#endregion

		#region 우편번호 조회창 Open

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

		#endregion

		#region 본인구분을 선택을 했을 때
		private void fbxBoninGubun_FindSelected(object sender, IHIS.Framework.FindEventArgs e)
		{
			this.txtBoninGubunName.SetEditValue(e.ReturnValues[1].ToString());


		}
		#endregion

		#region 본인구분 그리드에 ROW 생성
		private void btnInsert_Click(object sender, System.EventArgs e)
		{
            /*
			int rowNum = this.grdINP1004.InsertRow(-1);

            grdINP1004.SetItemValue(rowNum, "bunho", this.paBox.BunHo);
            this.txtSeq.SetEditValue(this.grdINP1004.GetItemValue(rowNum, "seq"));
			
            grdINP1004.AcceptData();
             */
            this.grdINP1004.InsertRow(-1);

            pnlINP1004.Enabled = true;

            txtName2.Focus();
		}
		#endregion

		#region 본인구분 삭제
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			this.grdINP1004.DeleteRow(this.grdINP1004.CurrentRowNumber);

            if (grdINP1004.RowCount == 0)
            {
                pnlINP1004.Enabled = false; 
            }
		}
		#endregion

		#region 등록번호를 잘못입력을 했을 때
		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			this.ResetControl(this.tabPatient);
		}
		#endregion

		#region 사용자 변경이 있을 때
		private void NUR1001U00_UserChanged(object sender, System.EventArgs e)
		{
			this.ResetControl(this.tabPatient);
			
			/* 콤보박스 셋팅 */
            //this.GetComboSetting("MAIN_FOOD");
            //this.GetComboSetting("ACTIVITY_LEVEL");
            //this.GetComboSetting("FAMILY_RELATION");
            //this.GetComboSetting("FAMILY_ROLE");
            //this.GetComboSetting("JOB");
            //this.GetComboSetting("HOUSE_KIND");
            //this.GetComboSetting("TRAFFIC_METHOD");

            this.InitAllCombox();

			this.txtUpd_gubun.SetEditValue("I");

			if (this.OpenParam != null)
			{
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
				this.btnList.Focus();
			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.paBox.SetPatientID(patientInfo.BunHo);
					this.btnList.Focus();
				}
			}
		}
		#endregion

		#region 감염증 관리 프로그램을 오픈시킨다.
		private void btnInfe_codeOpen_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add( "sysid", "NURI");
				openParams.Add( "screen", this.ScreenID.ToString());
				openParams.Add( "bunho", this.paBox.BunHo.ToString());
				openParams.Add( "flag", "Y");
				XScreen.OpenScreenWithParam(this, "NURI", "NUR1017U00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
			}
		}
		#endregion

        #region 알레르기관리창 오픈
        private void btnAllergyOpen_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add( "sysid", "NURI");
				openParams.Add( "screen", this.ScreenID.ToString());
				openParams.Add( "bunho", this.paBox.BunHo.ToString());
				openParams.Add( "flag", "Y");
				XScreen.OpenScreenWithParam(this, "NURI", "NUR1016U00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
			}
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
		private void MakeValService(XFindBox fbx, string dataValue)
		{
            //string cmdText = string.Empty;
            //object retVal = null;
            //BindVarCollection bindVars = new BindVarCollection();
            //switch(fbx.Name)
            //{
            //    case "fbxFamily_relation1":
            //        cmdText = "SELECT CODE FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code AND CODE_TYPE = 'BONIN_GUBUN' AND CODE_NAME = :f_code";

            //        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //        bindVars.Add("f_code", dataValue);

            //        retVal = Service.ExecuteScalar(cmdText, bindVars);
            //        if (!TypeCheck.IsNull(retVal))
            //        {
            //            //this.txtFamily_relation1.Clear();
            //            //this.txtFamily_relation1.SetEditValue(retVal.ToString());
            //            //this.txtFamily_relation1.AcceptData();
            //            FindName = "";
            //        }
            //        break;

            //    case "fbxFamily_relation2":
            //        cmdText = "SELECT CODE FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code CODE_TYPE = 'BONIN_GUBUN' AND CODE_NAME = :f_code";

            //        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //        bindVars.Add("f_code", dataValue);

            //        retVal = Service.ExecuteScalar(cmdText, bindVars);
            //        if (!TypeCheck.IsNull(retVal))
            //        {
            //            //this.txtFamily_relation2.Clear();
            //            //this.txtFamily_relation2.SetEditValue(retVal.ToString());
            //            //this.txtFamily_relation2.AcceptData();
            //            FindName = "";
            //        }
            //        break;

            //    case "fbxFamily_relation3":
            //        cmdText = "SELECT CODE FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code CODE_TYPE = 'BONIN_GUBUN' AND CODE_NAME = :f_code";

            //        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //        bindVars.Add("f_code", dataValue);

            //        retVal = Service.ExecuteScalar(cmdText, bindVars);
            //        if (!TypeCheck.IsNull(retVal))
            //        {
            //            //this.fbxFamily_relation3.Clear();
            //            //this.fbxFamily_relation3.SetEditValue(retVal.ToString());
            //            //this.fbxFamily_relation3.AcceptData();
            //            FindName = "";
            //        }
            //        break;

            //    case "fbxFamily_relation4":

            //        cmdText = "SELECT CODE FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code CODE_TYPE = 'BONIN_GUBUN' AND CODE_NAME = :f_code";
                    
            //        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //        bindVars.Add("f_code", dataValue);
                    
            //        retVal = Service.ExecuteScalar(cmdText, bindVars);
            //        if (!TypeCheck.IsNull(retVal))
            //        {
            //            //this.fbxFamily_relation4.Clear();
            //            //this.fbxFamily_relation4.SetEditValue(retVal.ToString());
            //            //this.fbxFamily_relation4.AcceptData();
            //            FindName = "";
            //        }
            //        break;

            //    case "fbxFamily_relation5":

            //        cmdText = "SELECT CODE FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code CODE_TYPE = 'BONIN_GUBUN' AND CODE_NAME = :f_code";

            //        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //        bindVars.Add("f_code", dataValue);

            //        retVal = Service.ExecuteScalar(cmdText, bindVars);
            //        if (!TypeCheck.IsNull(retVal))
            //        {
            //            this.fbxFamily_relation5.Clear();
            //            this.fbxFamily_relation5.SetEditValue(retVal.ToString());
            //            this.fbxFamily_relation5.AcceptData();
            //            FindName = "";
            //        }
            //        break;

            //    case "fbxFamily_relation6":
            //        cmdText = "SELECT CODE FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code CODE_TYPE = 'BONIN_GUBUN' AND CODE_NAME = :f_code";

            //        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //        bindVars.Add("f_code", dataValue);
            //        retVal = Service.ExecuteScalar(cmdText, bindVars);
            //        if (!TypeCheck.IsNull(retVal))
            //        {
            //            this.fbxFamily_relation6.Clear();
            //            this.fbxFamily_relation6.SetEditValue(retVal.ToString());
            //            this.fbxFamily_relation6.AcceptData();
            //            FindName = "";
            //        }
            //        break;
            //    case "fbxFamily_relation7":
            //        cmdText = "SELECT CODE FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code CODE_TYPE = 'BONIN_GUBUN' AND CODE_NAME = :f_code";

            //        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //        bindVars.Add("f_code", dataValue);
            //        retVal = Service.ExecuteScalar(cmdText, bindVars);
            //        if (!TypeCheck.IsNull(retVal))
            //        {
            //            this.fbxFamily_relation7.Clear();
            //            this.fbxFamily_relation7.SetEditValue(retVal.ToString());
            //            this.fbxFamily_relation7.AcceptData();
            //            FindName = "";
            //        }
            //        break;
            //    case "fbxSupproter_relation":
            //        cmdText = "SELECT CODE FROM BAS0102 WHERE HOSP_CODE = :f_hosp_code CODE_TYPE = 'BONIN_GUBUN' AND CODE_NAME = :f_code";

            //        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //        bindVars.Add("f_code", dataValue);
            //        retVal = Service.ExecuteScalar(cmdText, bindVars);
            //        if (!TypeCheck.IsNull(retVal))
            //        {
            //            FindName = "";
            //        }
            //        break;
            //    default:
            //        break;
            //}
		}
        #endregion

        #region 파인드박스 바인드 셋팅
        private void fbxFamily_relation_DataValidating(object sender, DataValidatingEventArgs e)
        {
            XFindBox fbx = sender as XFindBox;
            MakeValService(fbx, e.DataValue);
        }
        #endregion

        #region 파인드 셋팅
        private void fbxFamily_relation1_Enter(object sender, System.EventArgs e)
		{
			//FindName = "relation1";
			//this.MakeValService(this.fbxFamily_relation1);
		}

		private void fbxFamily_relation2_Enter(object sender, System.EventArgs e)
		{
			//FindName = "relation2";
			//this.MakeValService(this.fbxFamily_relation2);
		}

		private void fbxFamily_relation3_Enter(object sender, System.EventArgs e)
		{
			//FindName = "relation3";
			//this.MakeValService(this.fbxFamily_relation3);
		}

		private void fbxFamily_relation4_Enter(object sender, System.EventArgs e)
		{
			//FindName = "relation4";
			//this.MakeValService(this.fbxFamily_relation4);
		}

		private void fbxFamily_relation5_Enter(object sender, System.EventArgs e)
		{
			//FindName = "relation5";
			//this.MakeValService(this.fbxFamily_relation5);
		}

		private void fbxFamily_relation6_Enter(object sender, System.EventArgs e)
		{
			//FindName = "relation6";
			//this.MakeValService(this.fbxFamily_relation6);
		}

		private void fbxFamily_relation7_Enter(object sender, System.EventArgs e)
		{
			//FindName = "relation7";
			//this.MakeValService(this.fbxFamily_relation7);
		}

        #endregion

		/// <summary>
		/// Validation 통합 체크 후 각각의 텍스트 박스에 셋팅
		/// </summary>
		/// <param name="findMode">
		/// 파인드 구분
		/// </param>
		#region 통합 체크 후 이벤트
        //private void vsvValidationChk_PostServiceCall(object sender, IHIS.Framework.DataValidatingEventArgs e)
        //{
        //    switch(FindName)
        //    {
        //        //가족관계1		
        //        case "relation1":
        //            string relation1 = string.Empty;
					
        //            relation1 = this.vsvValidationChk.GetOutValue("txtCode").ToString();
			
        //            this.txtFamily_relation1.Clear();
        //            this.txtFamily_relation1.SetEditValue(relation1);
        //            this.txtFamily_relation1.AcceptData();
        //            FindName = "";
        //            break;
        //        //가족관계2		
        //        case "relation2":
        //            string relation2 = string.Empty;

        //            relation2 = this.vsvValidationChk.GetOutValue("txtCode2").ToString();
			
        //            this.txtFamily_relation2.Clear();
        //            this.txtFamily_relation2.SetEditValue(relation2);
        //            this.txtFamily_relation2.AcceptData();
        //            FindName = "";
        //            break;
        //        //가족관계3		
        //        case "relation3":
        //            string relation3 = string.Empty;

        //            relation3 = this.vsvValidationChk.GetOutValue("txtCode3").ToString();
			
        //            this.txtFamily_relation3.Clear();
        //            this.txtFamily_relation3.SetEditValue(relation3);
        //            this.txtFamily_relation3.AcceptData();
        //            FindName = "";
        //            break;
        //        //가족관계4		
        //        case "relation4":
        //            string relation4 = string.Empty;

        //            relation4 = this.vsvValidationChk.GetOutValue("txtCode4").ToString();
			
        //            this.txtFamily_relation4.Clear();
        //            this.txtFamily_relation4.SetEditValue(relation4);
        //            this.txtFamily_relation4.AcceptData();
        //            FindName = "";
        //            break;
        //        //가족관계5		
        //        case "relation5":
        //            string relation5 = string.Empty;

        //            relation5 = this.vsvValidationChk.GetOutValue("txtCode5").ToString();
			
        //            this.txtFamily_relation5.Clear();
        //            this.txtFamily_relation5.SetEditValue(relation5);
        //            this.txtFamily_relation5.AcceptData();
        //            FindName = "";
        //            break;
        //        //가족관계6		
        //        case "relation6":
        //            string relation6 = string.Empty;

        //            relation6 = this.vsvValidationChk.GetOutValue("txtCode6").ToString();
			
        //            this.txtFamily_relation6.Clear();
        //            this.txtFamily_relation6.SetEditValue(relation6);
        //            this.txtFamily_relation6.AcceptData();
        //            FindName = "";
        //            break;
        //        //가족관계7		
        //        case "relation7":
        //            string relation7 = string.Empty;

        //            relation7 = this.vsvValidationChk.GetOutValue("txtCode7").ToString();
			
        //            this.txtFamily_relation7.Clear();
        //            this.txtFamily_relation7.SetEditValue(relation7);
        //            this.txtFamily_relation7.AcceptData();
        //            FindName = "";
        //            break;
        //        //부양자와의 관계		
        //        case "supporter":
        //            string supporter = string.Empty;

        //            supporter = this.vsvValidationChk.GetOutValue("txtCode8").ToString();
			
        //            this.txtSupproter_relation.Clear();
        //            this.txtSupproter_relation.SetEditValue(supporter);
        //            this.txtSupproter_relation.AcceptData();
        //            FindName = "";
        //            break;
        //        default:
        //            break;
        //    }
        //}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 한 후의 이벤트
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
                    //if(this.CurrMSLayout == this.grdNUR1002)
                    //{
                    //    this.grdNUR1002.SetItemValue(this.grdNUR1002.CurrentRowNumber, "fkinp1001"  , this.grdInp1001.GetItemValue(this.grdInp1001.CurrentRowNumber, "fkinp1001"));
                    //    this.grdNUR1002.SetItemValue(this.grdNUR1002.CurrentRowNumber, "bunho", this.paBox.BunHo.ToString());
                    //    this.grdNUR1002.SetItemValue(this.grdNUR1002.CurrentRowNumber, "insert_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    //}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 진단명, 오다 상세조회창 오픈
		private void btnOrder_Click(object sender, System.EventArgs e)
		{
			CommonItemCollection openParams  = new CommonItemCollection();
            openParams.Add("naewon_date", this.grdINP1001.GetItemDateTime(this.grdINP1001.CurrentRowNumber, "ipwon_date").ToString("yyyy/MM/dd"));
            openParams.Add("bunho", paBox.BunHo);
            openParams.Add("io_gubun", "I");
            openParams.Add("gwa", this.layINP1001.GetItemValue("gwa").ToString());
            XScreen.OpenScreenWithParam(this, "OCSO", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        }
		#endregion

		#region 기왕력은 정형문을 불러 올 수 있도록 처리
		private void mbxPast_his_ReservedMemoButtonClick(object sender, System.EventArgs e)
		{
			CommonItemCollection loadParams;
		
		
			loadParams = new CommonItemCollection();
			loadParams.Add("category_gubun", "07"); //의료처치등정형문

			mbxPastHis.SetReservedMemoControlLoadParam(loadParams);
			mbxPastHis.AcceptData();
		}
		#endregion

		#region 영양관리계획서 화면 오픈
		private void btnNUT3004U00_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("NUTS", "NUT3004U00");

				if (aScreen == null)
				{
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sysid"  , "NURI");
					openParams.Add( "screen" , this.ScreenID.ToString());
					openParams.Add( "bunho"  , this.paBox.BunHo.ToString());
					openParams.Add( "ho_dong", this.grdINP1001.GetItemValue(this.grdINP1001.CurrentRowNumber, "ho_dong").ToString());
			
					XScreen.OpenScreenWithParam(this,"NUTS", "NUT3004U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

		#region 기왕임신분만정보를 변경 하기 위해 Row추가 및 삭제
		private void btnNur1009_insert_Click(object sender, System.EventArgs e)
		{
            //int Row = this.grdNur1009.InsertRow();
            //this.grdNur1009.SetItemValue(Row, "bunho"     , this.grdInp1001.GetItemValue(this.grdInp1001.CurrentRowNumber, "bunho").ToString());
            //this.grdNur1009.SetItemValue(Row, "fkinp1001" , this.grdInp1001.GetItemValue(this.grdInp1001.CurrentRowNumber, "fkinp1001").ToString());
            //this.grdNur1009.SetItemValue(Row, "girok_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
		}

		private void btnNur1009_Delete_Click(object sender, System.EventArgs e)
		{
            //this.grdNur1009.DeleteRow(this.grdNur1009.CurrentRowNumber);
		}
		#endregion


		#region 전도전락화면 열기
		private void btnJundo_junlak_Click(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() == "")
			{
				this.GetMessage("bunho");
				return;
			}
			else
			{
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen("NURI", "NUR1008U00");

				if (aScreen == null)
				{
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "sysid"  , "NURI");
					openParams.Add( "screen" , this.ScreenID.ToString());
					openParams.Add( "bunho"  , this.paBox.BunHo.ToString());
			
					XScreen.OpenScreenWithParam(this,"NURI", "NUR1008U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft,  openParams);
				}
				else
				{
					((XScreen)aScreen).Activate();
				}
			}
		}
		#endregion

		#region 그리드의 버튼을 클릭을 했을 때

		private void grdInp1001_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
		{            
			switch(e.ColName)
			{
				case "copy":
					string mbxMsg = "", mbxCap = "";
					
					mbxMsg = NetInfo.Language == LangMode.Jr ? "選択した入院日付の病棟患者情報を" + "\r\n" + "現在入院中の病棟患者情報へコピーしますか？" + "コピー時には選択した情報へ現在の病棟患者情報が全部コピーされます。" : "선택하신 입원일자의 병동환자정보를" +  "\r\n" + "현재 입원 중인 병동환자정보로 복사하시겠습니까?" + "복사할 때에는 선택한 정보로 현재의 병동환자정보가 전부 복사됩니다.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "入力確認" : "입력확인";
		
					if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
                        //현재 환자의 입원키를 조회한다.
                        this.layFkinp1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        this.layFkinp1001.SetBindVarValue("f_bunho", this.paBox.BunHo);
                        
                        if (this.layFkinp1001.QueryLayout())
                        {
                            this.layCopy.SetItemValue("fkinp1001", this.layFkinp1001.GetItemValue("fkinp1001").ToString());
                            this.layCopy.SetItemValue("bunho", this.paBox.BunHo);

                            if (this.layCopy.SaveLayout())
                            {
                            }
                            else
                            {
                                XMessageBox.Show(Service.ErrFullMsg.ToString());
                                return;
                            }
                        }
                        //else
                        //{
                        //    XMessageBox.Show(Service.ErrFullMsg.ToString());
                        //    return;
                        //}
					}
					break;

				default:
					break;
			}
		}

		#endregion

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

        #region [ 各 LAYOUT에 바인드 변수 셋팅 /* 201005 河中 */ grdInp1001, grdINP1004, layNUR1001A, layNUR1001B, grdNUR1002, grdNur1009 ]
        private void grdInp1001_QueryStarting(object sender, CancelEventArgs e)
        {
            grdINP1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdINP1001.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void grdINP1004_QueryStarting(object sender, CancelEventArgs e)
        {
            grdINP1004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdINP1004.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void layINP1001_QueryStarting(object sender, CancelEventArgs e)
        {
            layINP1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layINP1001.SetBindVarValue("f_bunho", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho"));
            layINP1001.SetBindVarValue("f_fkinp1001", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "fkinp1001"));
        }

        private void layNUR1001_QueryStarting(object sender, CancelEventArgs e)
        {
            layNUR1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layNUR1001.SetBindVarValue("f_bunho", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho"));
            layNUR1001.SetBindVarValue("f_fkinp1001", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "fkinp1001"));
            layNUR1001.SetBindVarValue("f_ipwon_date", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ipwon_date"));
        }

        private void layNUR1001_SaveStarting(object sender, CancelEventArgs e)
        {
            layNUR1001.SetItemValue("hosp_code", EnvironInfo.HospCode);
            layNUR1001.SetItemValue("bunho", paBox.BunHo);
            layNUR1001.SetItemValue("fkinp1001", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "fkinp1001"));
        }

        private void grdNUR1002_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR1002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdNUR1002.SetBindVarValue("f_bunho", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "bunho"));
            grdNUR1002.SetBindVarValue("f_fkinp1001", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "fkinp1001"));
        }

        private void grdNur1009_QueryStarting(object sender, CancelEventArgs e)
        {
            //grdNur1009.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //grdNur1009.SetBindVarValue("f_bunho", grdInp1001.GetItemString(grdInp1001.CurrentRowNumber, "bunho"));
            //grdNur1009.SetBindVarValue("f_fkinp1001", grdInp1001.GetItemString(grdInp1001.CurrentRowNumber, "fkinp1001"));
        }
        #endregion

        #region 알레르기 조회 관련 2011.12.21 woo
        private void grdNUR1016_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR1016.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR1016.SetBindVarValue("f_bunho", paBox.BunHo);
            this.grdNUR1016.SetBindVarValue("f_sys_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
        }

        private void btnAllergy_Click(object sender, EventArgs e)
        {
            CommonItemCollection allergyOpen = new CommonItemCollection();
            allergyOpen.Add("sysid", UserInfo.UserID);
            allergyOpen.Add("screen", this.ScreenID.ToString());
            allergyOpen.Add("bunho", paBox.BunHo);
            allergyOpen.Add("flag", "");

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1016U00", ScreenOpenStyle.ResponseFixed, allergyOpen);

            this.grdNUR1016.QueryLayout(false);
        }
        #endregion

        #region 알레르기버튼관련 2011.12.22woo
        private void grdNUR1017_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR1017.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR1017.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void btnInfe_Click(object sender, EventArgs e)
        {
            CommonItemCollection infeOpen = new CommonItemCollection();
            infeOpen.Add("sysid", UserInfo.UserID);
            infeOpen.Add("screen", this.ScreenID.ToString());
            infeOpen.Add("bunho", paBox.BunHo);
            infeOpen.Add("flag", "");

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1017U00", ScreenOpenStyle.ResponseFixed, infeOpen);

            this.grdNUR1017.QueryLayout(false);
        }

        #endregion

        #region [====== [[ XSavePerformer ]] ======]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR1001U00 parent = null;
            public XSavePerformer(NUR1001U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal = null;
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("f_bunho", parent.paBox.BunHo);
                //item.BindVarList.Add("f_fkinp1001", parent.grdInp1001.GetItemString(parent.grdInp1001.CurrentRowNumber, "fkinp1001"));
                item.BindVarList.Add("f_upd_gubun", parent.txtUpd_gubun.Text);
                //item.BindVarList.Add("f_sys_id", UserInfo.UserID);

                switch (callerID)
                {
                    case 'T':

                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT NVL(MAX(SER), 0) + 1 SER
                                                 FROM OUT0106
                                                WHERE HOSP_CODE = :f_hosp_code
                                                  AND BUNHO = :f_bunho";

                                BindVarCollection bindVars = new BindVarCollection();
                                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                                bindVars.Add("f_bunho", parent.paBox.BunHo);

                                retVal = Service.ExecuteScalar(cmdText, bindVars);
                                if (retVal == null)
                                {
                                    XMessageBox.Show(Service.ErrFullMsg + "順番がありません。");
                                    return false;
                                }
                                else
                                {
                                    item.BindVarList.Add("f_ser1", retVal.ToString());
                                }

                                cmdText = @"INSERT INTO OUT0106( SYS_DATE		, SYS_ID    	, UPD_DATE  , UPD_ID
                                                          , HOSP_CODE       , COMMENTS		, SER		, BUNHO
														  , DISPLAY_YN      , CMMT_GUBUN    )
													VALUES( SYSDATE 		, :q_user_id    , SYSDATE   , :q_user_id
                                                          , :f_hosp_code    , :f_comments   , :f_ser1	, :f_bunho
														  , :f_display_yn   , 'B' )";
                                /*
                                 * 1. 환자별 코멘트(특이사항)
                                      CMMT_GUBUN : 'B'
                                      - 환자별 특이사항 등록시 해당 파라미터를 'B'로 셋팅하면 됨
                                   2. 환자별 파트별 코멘트(특이사항)
                                      CMMT_GUBUN : 'P'
                                      - 환자별 파트별(각 부문 실시 파트 혹은 무브 파트별)로 등록 가능함
                                   3. 환자별 오더별 코멘트(특이사항)
                                      CMMT_GUBUN : 'O'

                                 * */
                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE OUT0106
										  SET UPD_ID          = :f_user_id
											, UPD_DATE        = SYSDATE
											, COMMENTS        = :f_comments
											, DISPLAY_YN      = :f_display_yn
										WHERE HOSP_CODE       = :f_hosp_code 
                                          AND BUNHO           = :f_bunho
										  AND SER             = :f_ser";
                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE FROM OUT0106
										WHERE HOSP_CODE       = :f_hosp_code 
                                          AND BUNHO           = :f_bunho
										  AND SER             = :f_ser";
                                break;
                        }
                        break;

                    case 'S':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                BindVarCollection bindVars = new BindVarCollection();

                                cmdText = @"SELECT NUR1029_SEQ.NEXTVAL FROM DUAL";

                                retVal = Service.ExecuteScalar(cmdText);
                                if (retVal == null)
                                {
                                    XMessageBox.Show(Service.ErrFullMsg + "順番がありません。");
                                    return false;
                                }
                                else
                                {
                                    item.BindVarList.Add("f_pknur1029", retVal.ToString());
                                }

                                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                                bindVars.Add("f_bunho", parent.paBox.BunHo);

                                cmdText = @"INSERT INTO NUR1029 (
                                                        SYS_DATE             , SYS_ID        , UPD_DATE      , UPD_ID
                                                      , HOSP_CODE            , PKNUR1029     , BUNHO         , BUWI
                                                      , START_DATE           , END_DATE      , BUWI_COMMENT              ) 
                                                VALUES( SYSDATE 		     , :q_user_id    , SYSDATE       , :q_user_id
                                                      , :f_hosp_code         , :f_pknur1029  , :f_bunho      , :f_buwi
                                                      , :f_start_date        , :f_end_date   , :f_buwi_comment           )";
                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE NUR1029
                                               SET UPD_DATE     = SYSDATE         ,
                                                   UPD_ID       = :q_user_id      ,
                                                   BUWI         = :f_buwi         ,
                                                   START_DATE   = :f_start_date   ,
                                                   END_DATE     = :f_end_date     ,
                                                   BUWI_COMMENT = :f_buwi_comment   
                                             WHERE HOSP_CODE    = :f_hosp_code 
                                               AND BUNHO        = :f_bunho
										       AND PKNUR1029    = :f_pknur1029";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE FROM NUR1029
										     WHERE HOSP_CODE  = :f_hosp_code 
                                               AND BUNHO      = :f_bunho
										       AND PKNUR1029  = :f_pknur1029";
                                break;
                        }
                           
                        break;

                    case 'M':
                        retVal = Service.ExecuteScalar(@"SELECT 'X'
                                                           FROM NUR1001
                                                          WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                                                        + " AND BUNHO     = '" + item.BindVarList["f_bunho"].VarValue
                                                       + "' AND FKINP1001 = '" + item.BindVarList["f_fkinp1001"].VarValue + "'");
                        //switch (item.BindVarList["f_upd_gubun"].VarValue)
                        //{
                        //    case "I": 
                                if (!TypeCheck.IsNull(retVal))
                                {
                                    cmdText = @"UPDATE NUR1001
                                                SET    UPD_DATE                    = SYSDATE,
                                                       UPD_ID                      = :q_user_id,
                                                       HOSP_CODE                   = :f_hosp_code,
                                                       FKINP1001                   = :f_fkinp1001,
                                                       BUNHO                       = :f_bunho,
                                                       BLOOD_TYPE_ABO              = :f_blood_type_abo,
                                                       BLOOD_TYPE_RH               = :f_blood_type_rh,
                                                       PURPOSE                     = :f_purpose,
                                                       INFORMANT                   = :f_informant,
                                                       KEY_NAME1                   = :f_key_name1,
                                                       KEY_RELATION1               = :f_key_relation1,
                                                       KEY_HOME1                   = :f_key_home1,
                                                       WRITER                      = :f_writer,
                                                       DIAGNOSIS_NAME              = :f_diagnosis_name,
                                                       DIAGNOSIS_GUBUN             = :f_diagnosis_gubun,
                                                       INPATIENT_COURSE            = :f_inpatient_course,
                                                       ASSESSMENT_0                = :f_assessment_0,
                                                       PAST_HIS                    = :f_past_his,
                                                       BRING_DRUG_YN               = :f_bring_drug_yn,
                                                       BRING_DRUG_COMMENT          = :f_bring_drug_comment,
                                                       HEALTHCARE_YN               = :f_healthcare_yn,
                                                       HEALTHCARE_COMMENT          = :f_healthcare_comment,
                                                       SMOKING_DAY                 = :f_smoking_day,
                                                       DRINKING                    = :f_drinking,
                                                       EXPLAIN_DOCTOR              = :f_explain_doctor,
                                                       EXPLAIN_PATIENT             = :f_explain_patient,
                                                       EXPLAIN_FAMILY              = :f_explain_family,
                                                       ASSESSMENT_1                = :f_assessment_1,
                                                       MAIN_FOOD                   = :f_main_food,
                                                       SUB_FOOD                    = :f_sub_food,
                                                       FOOD_DISLIKE_YN             = :f_food_dislike_yn,
                                                       FOOD_DISLIKE_COMMENT        = :f_food_dislike_comment,
                                                       APPETITE_YN                 = :f_appetite_yn,
                                                       APPETITE_COMMENT            = :f_appetite_comment,
                                                       DYSPHAGIA_YN                = :f_dysphagia_yn,
                                                       DYSPHAGIA_COMMENT           = :f_dysphagia_comment,
                                                       INTAKE_WAY                  = :f_intake_way,
                                                       INTAKE_COMMENT              = :f_intake_comment,
                                                       FOOD_LIMIT                  = :f_food_limit,
                                                       MOUTH_POLLUTION_YN          = :f_mouth_pollution_yn,
                                                       MOUTH_POLLUTION_COMMENT     = :f_mouth_pollution_comment,
                                                       FALSE_TEETH_YN              = :f_false_teeth_yn,
                                                       FALSE_TEETH_COMMENT         = :f_false_teeth_comment,
                                                       WEIGHT_UPDOWN_START         = :f_weight_updown_start,
                                                       WEIGHT_UPDOWN_HOW           = :f_weight_updown_how,
                                                       HEIGHT                      = :f_height,
                                                       WEIGHT                      = :f_weight,
                                                       DUNG_COUNT                  = :f_dung_count,
                                                       DUNG_DAY                    = :f_dung_day,
                                                       DUNG_STATE                  = :f_dung_state,
                                                       DUNG_LAST                   = :f_dung_last,
                                                       DUNG_WILL_YN                = :f_dung_will_yn,
                                                       DIAPERS_YN                  = :f_diapers_yn,
                                                       ORTHOTICS_YN                = :f_orthotics_yn,
                                                       ENEMA_YN                    = :f_enema_yn,
                                                       LAXATIVE_YN                 = :f_laxative_yn,
                                                       SUPPOSITORY_YN              = :f_suppository_yn,
                                                       ANTIDIARRHEAL_YN            = :f_antidiarrheal_yn,
                                                       LAXATION_COMMENT            = :f_laxation_comment,
                                                       URIN_COUNT                  = :f_urin_count,
                                                       URIN_DAY                    = :f_urin_day,
                                                       URIN_NIGHT_COUNT            = :f_urin_night_count,
                                                       URIN_WILL_YN                = :f_urin_will_yn,
                                                       INTERMITTENT_YN             = :f_intermittent_yn,
                                                       INTERMITTENT_COMMENT        = :f_intermittent_comment,
                                                       CATHETER_YN                 = :f_catheter_yn,
                                                       CATHETER_START_DATE         = :f_catheter_start_date,
                                                       ABDOMINAL_INFLATION_YN      = :f_abdominal_inflation_yn,
                                                       ABDOMINAL_INFLATION_VERY_YN = :f_abdominal_inflation_very_yn,
                                                       ENTEROKINESIA_YN            = :f_enterokinesia_yn,
                                                       ASSESSMENT_2                = :f_assessment_2,
                                                       ADL_FOOD_STATE              = :f_adl_food_state,
                                                       ADL_FOOD_COMMENT            = :f_adl_food_comment,
                                                       ADL_BATH_STATE              = :f_adl_bath_state,
                                                       ADL_BATH_COMMENT            = :f_adl_bath_comment,
                                                       ADL_CLOTH_STATE             = :f_adl_cloth_state,
                                                       ADL_CLOTH_COMMENT           = :f_adl_cloth_comment,
                                                       ADL_WASH_STATE              = :f_adl_wash_state,
                                                       ADL_WASH_COMMENT            = :f_adl_wash_comment,
                                                       ADL_EXCRETION_STATE         = :f_adl_excretion_state,
                                                       ADL_EXCRETION_COMMENT       = :f_adl_excretion_comment,
                                                       ADL_STRUGGLE_STATE          = :f_adl_struggle_state,
                                                       ADL_STRUGGLE_COMMENT        = :f_adl_struggle_comment,
                                                       ADL_BOARD_STATE             = :f_adl_board_state,
                                                       ADL_BOARD_COMMENT           = :f_adl_board_comment,
                                                       ADL_WHEELCHAIR_STATE        = :f_adl_wheelchair_state,
                                                       ADL_WHEELCHAIR_COMMENT      = :f_adl_wheelchair_comment,
                                                       ADL_WALK_STATE              = :f_adl_walk_state,
                                                       ADL_WALK_COMMENT            = :f_adl_walk_comment,
                                                       NEED_CARE                   = :f_need_care,
                                                       NEED_SUPPORT                = :f_need_support,
                                                       SERVICE_COMMENT             = :f_service_comment,
                                                       CARE_OFFICE_COMMENT         = :f_care_office_comment,
                                                       SLEEP_TIME                  = :f_sleep_time,
                                                       SLEEP_START_TIME            = :f_sleep_start_time,
                                                       SLEEP_END_TIME              = :f_sleep_end_time,
                                                       SLEEP_ENOUGH_YN             = :f_sleep_enough_yn,
                                                       SLEEP_ENOUGH_COMMENT        = :f_sleep_enough_comment,
                                                       SLEEPLESS_COMMENT           = :f_sleepless_comment,
                                                       SNORING_YN                  = :f_snoring_yn,
                                                       SLEEP_TALK_YN               = :f_sleep_talk_yn,
                                                       TEETH_GRINDING_YN           = :f_teeth_grinding_yn,
                                                       SLEEP_ETC_YN                = :f_sleep_etc_yn,
                                                       SLEEP_ETC_COMMENT           = :f_sleep_etc_comment,
                                                       ASSESSMENT_4                = :f_assessment_4,
                                                       SENSE_LEVEL                 = :f_sense_level,
                                                       OBSTACLE_SPEECH_YN          = :f_obstacle_speech_yn,
                                                       OBSTACLE_SENSE_YN           = :f_obstacle_sense_yn,
                                                       OBSTACLE_YN                 = :f_obstacle_yn,
                                                       OBSTACLE_COMMENT            = :f_obstacle_comment,
                                                       RECOGNITION_YN              = :f_recognition_yn,
                                                       RECOGNITION_COMMENT         = :f_recognition_comment,
                                                       SENSOR_YN                   = :f_sensor_yn,
                                                       EYE_RIGHT_YN                = :f_eye_right_yn,
                                                       EYE_RIGHT_COMMENT           = :f_eye_right_comment,
                                                       EYE_LEFT_YN                 = :f_eye_left_yn,
                                                       EYE_LEFT_COMMENT            = :f_eye_left_comment,
                                                       EYE_GLASSES_YN              = :f_eye_glasses_yn,
                                                       EYE_LENS_YN                 = :f_eye_lens_yn,
                                                       EAR_RIGHT_YN                = :f_ear_right_yn,
                                                       EAR_RIGHT_COMMENT           = :f_ear_right_comment,
                                                       EAR_LEFT_YN                 = :f_ear_left_yn,
                                                       EAR_LEFT_COMMENT            = :f_ear_left_comment,
                                                       EAR_AID_YN                  = :f_ear_aid_yn,
                                                       NOSE_COMMENT                = :f_nose_comment,
                                                       MOUTH_COMMENT               = :f_mouth_comment,
                                                       DIZZY_YN                    = :f_dizzy_yn,
                                                       DIZZY_COMMENT               = :f_dizzy_comment,
                                                       STAGGER_YN                  = :f_stagger_yn,
                                                       STAGGER_COMMENT             = :f_stagger_comment,
                                                       PAIN_YN                     = :f_pain_yn,
                                                       PAIN_COMMENT                = :f_pain_comment,
                                                       PERCEPTION_YN               = :f_perception_yn,
                                                       PERCEPTION_COMMENT          = :f_perception_comment,
                                                       MOVEMENT_YN                 = :f_movement_yn,
                                                       PARALYSIS_YN                = :f_paralysis_yn,
                                                       PARALYSIS_COMMENT           = :f_paralysis_comment,
                                                       CONTRACTURE_YN              = :f_contracture_yn,
                                                       CONTRACTURE_COMMENT         = :f_contracture_comment,
                                                       LOSS_PART_YN                = :f_loss_part_yn,
                                                       LOSS_PART_COMMENT           = :f_loss_part_comment,
                                                       WORRY_YN                    = :f_worry_yn,
                                                       WORRY_COMMENT               = :f_worry_comment,
                                                       FEAR_YN                     = :f_fear_yn,
                                                       FEAR_COMMENT                = :f_fear_comment,
                                                       ASSESSMENT_5                = :f_assessment_5,
                                                       FAMILY_YN                   = :f_family_yn,
                                                       FAMILY_COMMENT              = :f_family_comment,
                                                       JOB                         = :f_job,
                                                       JOB_MATE                    = :f_job_mate,
                                                       HOUSE_KIND                  = :f_house_kind,
                                                       BARRIER_FREE_YN             = :f_barrier_free_yn,
                                                       MENSES                      = :f_menses,
                                                       MENSES_AGE                  = :f_menses_age,
                                                       MENSES_PROBLEM_YN           = :f_menses_problem_yn,
                                                       MENSES_PROBLEM_COMMENT      = :f_menses_problem_comment,
                                                       PREGNANCY_YN                = :f_pregnancy_yn,
                                                       HOBBY_YN                    = :f_hobby_yn,
                                                       HOBBY_COMMENT               = :f_hobby_comment,
                                                       STRESS_YN                   = :f_stress_yn,
                                                       STRESS_COMMENT              = :f_stress_comment,
                                                       STRESS_MANAGE               = :f_stress_manage,
                                                       RELIGION_YN                 = :f_religion_yn,
                                                       RELIGION_COMMENT            = :f_religion_comment,
                                                       ASSESSMENT_7                = :f_assessment_7,
                                                       KEY_CELL1                   = :f_key_cell1,
                                                       KEY_OFFICE1                 = :f_key_office1,
                                                       KEY_NAME2                   = :f_key_name2,
                                                       KEY_RELATION2               = :f_key_relation2,
                                                       KEY_HOME2                   = :f_key_home2,
                                                       KEY_CELL2                   = :f_key_cell2,
                                                       KEY_OFFICE2                 = :f_key_office2,
                                                       KEY_COMMENT                 = :f_key_comment,
                                                       KEY_HOME1_PRI               = :f_key_home1_pri,
                                                       KEY_CELL1_PRI               = :f_key_cell1_pri,
                                                       KEY_OFFICE1_PRI             = :f_key_office1_pri,
                                                       KEY_HOME2_PRI               = :f_key_home2_pri,
                                                       KEY_CELL2_PRI               = :f_key_cell2_pri,
                                                       KEY_OFFICE2_PRI             = :f_key_office2_pri
                                                 WHERE HOSP_CODE                   = :f_hosp_code 
                                                   AND BUNHO                       = :f_bunho
                                                   AND FKINP1001                   = :f_fkinp1001      ";
                                }
                                else if (TypeCheck.IsNull(retVal))
                                {
                                    cmdText = @"INSERT INTO NUR1001
                                                     (SYS_DATE,
                                                      SYS_ID,
                                                      HOSP_CODE,
                                                      FKINP1001,
                                                      BUNHO,
                                                      BLOOD_TYPE_ABO,
                                                      BLOOD_TYPE_RH,
                                                      PURPOSE,
                                                      INFORMANT,
                                                      KEY_NAME1,
                                                      KEY_RELATION1,
                                                      KEY_HOME1,
                                                      WRITER,
                                                      DIAGNOSIS_NAME,
                                                      DIAGNOSIS_GUBUN,
                                                      INPATIENT_COURSE,
                                                      ASSESSMENT_0,
                                                      PAST_HIS,
                                                      BRING_DRUG_YN,
                                                      BRING_DRUG_COMMENT,
                                                      HEALTHCARE_YN,
                                                      HEALTHCARE_COMMENT,
                                                      SMOKING_DAY,
                                                      DRINKING,
                                                      EXPLAIN_DOCTOR,
                                                      EXPLAIN_PATIENT,
                                                      EXPLAIN_FAMILY,
                                                      ASSESSMENT_1,
                                                      MAIN_FOOD,
                                                      SUB_FOOD,
                                                      FOOD_DISLIKE_YN,
                                                      FOOD_DISLIKE_COMMENT,
                                                      APPETITE_YN,
                                                      APPETITE_COMMENT,
                                                      DYSPHAGIA_YN,
                                                      DYSPHAGIA_COMMENT,
                                                      INTAKE_WAY,
                                                      INTAKE_COMMENT,
                                                      FOOD_LIMIT,
                                                      MOUTH_POLLUTION_YN,
                                                      MOUTH_POLLUTION_COMMENT,
                                                      FALSE_TEETH_YN,
                                                      FALSE_TEETH_COMMENT,
                                                      WEIGHT_UPDOWN_START,
                                                      WEIGHT_UPDOWN_HOW,
                                                      HEIGHT,
                                                      WEIGHT,
                                                      DUNG_COUNT,
                                                      DUNG_DAY,
                                                      DUNG_STATE,
                                                      DUNG_LAST,
                                                      DUNG_WILL_YN,
                                                      DIAPERS_YN,
                                                      ORTHOTICS_YN,
                                                      ENEMA_YN,
                                                      LAXATIVE_YN,
                                                      SUPPOSITORY_YN,
                                                      ANTIDIARRHEAL_YN,
                                                      LAXATION_COMMENT,
                                                      URIN_COUNT,
                                                      URIN_DAY,
                                                      URIN_NIGHT_COUNT,
                                                      URIN_WILL_YN,
                                                      INTERMITTENT_YN,
                                                      INTERMITTENT_COMMENT,
                                                      CATHETER_YN,
                                                      CATHETER_START_DATE,
                                                      ABDOMINAL_INFLATION_YN,
                                                      ABDOMINAL_INFLATION_VERY_YN,
                                                      ENTEROKINESIA_YN,
                                                      ASSESSMENT_2,
                                                      ADL_FOOD_STATE,
                                                      ADL_FOOD_COMMENT,
                                                      ADL_BATH_STATE,
                                                      ADL_BATH_COMMENT,
                                                      ADL_CLOTH_STATE,
                                                      ADL_CLOTH_COMMENT,
                                                      ADL_WASH_STATE,
                                                      ADL_WASH_COMMENT,
                                                      ADL_EXCRETION_STATE,
                                                      ADL_EXCRETION_COMMENT,
                                                      ADL_STRUGGLE_STATE,
                                                      ADL_STRUGGLE_COMMENT,
                                                      ADL_BOARD_STATE,
                                                      ADL_BOARD_COMMENT,
                                                      ADL_WHEELCHAIR_STATE,
                                                      ADL_WHEELCHAIR_COMMENT,
                                                      ADL_WALK_STATE,
                                                      ADL_WALK_COMMENT,
                                                      NEED_CARE,
                                                      NEED_SUPPORT,
                                                      SERVICE_COMMENT,
                                                      CARE_OFFICE_COMMENT,
                                                      SLEEP_TIME,
                                                      SLEEP_START_TIME,
                                                      SLEEP_END_TIME,
                                                      SLEEP_ENOUGH_YN,
                                                      SLEEP_ENOUGH_COMMENT,
                                                      SLEEPLESS_COMMENT,
                                                      SNORING_YN,
                                                      SLEEP_TALK_YN,
                                                      TEETH_GRINDING_YN,
                                                      SLEEP_ETC_YN,
                                                      SLEEP_ETC_COMMENT,
                                                      ASSESSMENT_4,
                                                      SENSE_LEVEL,
                                                      OBSTACLE_SPEECH_YN,
                                                      OBSTACLE_SENSE_YN,
                                                      OBSTACLE_YN,
                                                      OBSTACLE_COMMENT,
                                                      RECOGNITION_YN,
                                                      RECOGNITION_COMMENT,
                                                      SENSOR_YN,
                                                      EYE_RIGHT_YN,
                                                      EYE_RIGHT_COMMENT,
                                                      EYE_LEFT_YN,
                                                      EYE_LEFT_COMMENT,
                                                      EYE_GLASSES_YN,
                                                      EYE_LENS_YN,
                                                      EAR_RIGHT_YN,
                                                      EAR_RIGHT_COMMENT,
                                                      EAR_LEFT_YN,
                                                      EAR_LEFT_COMMENT,
                                                      EAR_AID_YN,
                                                      NOSE_COMMENT,
                                                      MOUTH_COMMENT,
                                                      DIZZY_YN,
                                                      DIZZY_COMMENT,
                                                      STAGGER_YN,
                                                      STAGGER_COMMENT,
                                                      PAIN_YN,
                                                      PAIN_COMMENT,
                                                      PERCEPTION_YN,
                                                      PERCEPTION_COMMENT,
                                                      MOVEMENT_YN,
                                                      PARALYSIS_YN,
                                                      PARALYSIS_COMMENT,
                                                      CONTRACTURE_YN,
                                                      CONTRACTURE_COMMENT,
                                                      LOSS_PART_YN,
                                                      LOSS_PART_COMMENT,
                                                      WORRY_YN,
                                                      WORRY_COMMENT,
                                                      FEAR_YN,
                                                      FEAR_COMMENT,
                                                      ASSESSMENT_5,
                                                      FAMILY_YN,
                                                      FAMILY_COMMENT,
                                                      JOB,
                                                      JOB_MATE,
                                                      HOUSE_KIND,
                                                      BARRIER_FREE_YN,
                                                      MENSES,
                                                      MENSES_AGE,
                                                      MENSES_PROBLEM_YN,
                                                      MENSES_PROBLEM_COMMENT,
                                                      PREGNANCY_YN,
                                                      HOBBY_YN,
                                                      HOBBY_COMMENT,
                                                      STRESS_YN,
                                                      STRESS_COMMENT,
                                                      STRESS_MANAGE,
                                                      RELIGION_YN,
                                                      RELIGION_COMMENT,
                                                      ASSESSMENT_7,
                                                      KEY_CELL1,
                                                      KEY_OFFICE1,
                                                      KEY_NAME2,
                                                      KEY_RELATION2,
                                                      KEY_HOME2,
                                                      KEY_CELL2,
                                                      KEY_OFFICE2,
                                                      KEY_COMMENT,
                                                      KEY_HOME1_PRI,
                                                      KEY_CELL1_PRI,
                                                      KEY_OFFICE1_PRI,
                                                      KEY_HOME2_PRI,
                                                      KEY_CELL2_PRI,
                                                      KEY_OFFICE2_PRI
                                                      )
                                                VALUES 
                                                     ( SYSDATE,
                                                       :q_user_id,
                                                       :f_hosp_code,
                                                       :f_fkinp1001,
                                                       :f_bunho,
                                                       :f_blood_type_abo,
                                                       :f_blood_type_rh,
                                                       :f_purpose,
                                                       :f_informant,
                                                       :f_key_name,
                                                       :f_key_relation,
                                                       :f_key_contact,
                                                       :f_writer,
                                                       :f_diagnosis_name,
                                                       :f_diagnosis_gubun,
                                                       :f_inpatient_course,
                                                       :f_assessment_0,
                                                       :f_past_his,
                                                       :f_bring_drug_yn,
                                                       :f_bring_drug_comment,
                                                       :f_healthcare_yn,
                                                       :f_healthcare_comment,
                                                       :f_smoking_day,
                                                       :f_drinking,
                                                       :f_explain_doctor,
                                                       :f_explain_patient,
                                                       :f_explain_family,
                                                       :f_assessment_1,
                                                       :f_main_food,
                                                       :f_sub_food,
                                                       :f_food_dislike_yn,
                                                       :f_food_dislike,
                                                       :f_appetite_yn,
                                                       :f_appetite_comment,
                                                       :f_dysphagia_yn,
                                                       :f_dysphagia_comment,
                                                       :f_intake_way,
                                                       :f_intake_comment,
                                                       :f_food_limit,
                                                       :f_mouth_pollution_yn,
                                                       :f_mouth_pollution_comment,
                                                       :f_false_teeth_yn,
                                                       :f_false_teeth_comment,
                                                       :f_weight_updown_start,
                                                       :f_weight_updown_how,
                                                       :f_height,
                                                       :f_weight,
                                                       :f_dung_count,
                                                       :f_dung_day,
                                                       :f_dung_state,
                                                       :f_dung_last,
                                                       :f_dung_will_yn,
                                                       :f_diapers_yn,
                                                       :f_orthotics_yn,
                                                       :f_enema_yn,
                                                       :f_laxative_yn,
                                                       :f_suppository_yn,
                                                       :f_antidiarrheal_yn,
                                                       :f_laxation_comment,
                                                       :f_urin_count,
                                                       :f_urin_day,
                                                       :f_urin_night_count,
                                                       :f_urin_will_yn,
                                                       :f_intermittent_yn,
                                                       :f_intermittent_comment,
                                                       :f_catheter_yn,
                                                       :f_catheter_start_date,
                                                       :f_abdominal_inflation_yn,
                                                       :f_abdominal_inflation_very_yn,
                                                       :f_enterokinesia_yn,
                                                       :f_assessment_2,
                                                       :f_adl_food_state,
                                                       :f_adl_food_comment,
                                                       :f_adl_bath_state,
                                                       :f_adl_bath_comment,
                                                       :f_adl_cloth_state,
                                                       :f_adl_cloth_comment,
                                                       :f_adl_wash_state,
                                                       :f_adl_wash_comment,
                                                       :f_adl_excretion_state,
                                                       :f_adl_excretion_comment,
                                                       :f_adl_struggle_state,
                                                       :f_adl_struggle_comment,
                                                       :f_adl_board_state,
                                                       :f_adl_board_comment,
                                                       :f_adl_wheelchair_state,
                                                       :f_adl_wheelchair_comment,
                                                       :f_adl_walk_state,
                                                       :f_adl_walk_comment,
                                                       :f_need_care,
                                                       :f_need_support,
                                                       :f_service_comment,
                                                       :f_care_office_comment,
                                                       :f_sleep_time,
                                                       :f_sleep_start_time,
                                                       :f_sleep_end_time,
                                                       :f_sleep_enough_yn,
                                                       :f_sleep_enough_comment,
                                                       :f_sleepless_comment,
                                                       :f_snoring_yn,
                                                       :f_sleep_talk_yn,
                                                       :f_teeth_grinding_yn,
                                                       :f_sleep_etc_yn,
                                                       :f_sleep_etc_comment,
                                                       :f_assessment_4,
                                                       :f_sense_level,
                                                       :f_obstacle_speech_yn,
                                                       :f_obstacle_sense_yn,
                                                       :f_obstacle_yn,
                                                       :f_obstacle_comment,
                                                       :f_recognition_yn,
                                                       :f_recognition_comment,
                                                       :f_sensor_yn,
                                                       :f_eye_right_yn,
                                                       :f_eye_right_comment,
                                                       :f_eye_left_yn,
                                                       :f_eye_left_comment,
                                                       :f_eye_glasses_yn,
                                                       :f_eye_lens_yn,
                                                       :f_ear_right_yn,
                                                       :f_ear_right_comment,
                                                       :f_ear_left_yn,
                                                       :f_ear_left_comment,
                                                       :f_ear_aid_yn,
                                                       :f_nose_comment,
                                                       :f_mouth_comment,
                                                       :f_dizzy_yn,
                                                       :f_dizzy_comment,
                                                       :f_stagger_yn,
                                                       :f_stagger_comment,
                                                       :f_pain_yn,
                                                       :f_pain_comment,
                                                       :f_perception_yn,
                                                       :f_perception_comment,
                                                       :f_movement_yn,
                                                       :f_paralysis_yn,
                                                       :f_paralysis_comment,
                                                       :f_contracture_yn,
                                                       :f_contracture_comment,
                                                       :f_loss_part_yn,
                                                       :f_loss_part_comment,
                                                       :f_worry_yn,
                                                       :f_worry_comment,
                                                       :f_fear_yn,
                                                       :f_fear_comment,
                                                       :f_assessment_5,
                                                       :f_family_yn,
                                                       :f_family_comment,
                                                       :f_job,
                                                       :f_job_mate,
                                                       :f_house_kind,
                                                       :f_barrier_free_yn,
                                                       :f_menses,
                                                       :f_menses_age,
                                                       :f_menses_problem_yn,
                                                       :f_menses_problem_comment,
                                                       :f_pregnancy_yn,
                                                       :f_hobby_yn,
                                                       :f_hobby_comment,
                                                       :f_stress_yn,
                                                       :f_stress_comment,
                                                       :f_stress_manage,
                                                       :f_religion_yn,
                                                       :f_religion_comment,
                                                       :f_assessment_7,
                                                       :f_key_cell1,
                                                       :f_key_office1,
                                                       :f_key_name2,
                                                       :f_key_relation2,
                                                       :f_key_home2,
                                                       :f_key_cell2,
                                                       :f_key_office2,
                                                       :f_key_comment,
                                                       :f_key_home1_pri,
                                                       :f_key_cell1_pri,
                                                       :f_key_office1_pri,
                                                       :f_key_home2_pri,
                                                       :f_key_cell2_pri,
                                                       :f_key_office2_pri)";
                                }
//                                break;
//                            case "D":
//                                if (!TypeCheck.IsNull(retVal))
//                                {
//                                    cmdText = @"DELETE NUR1001_NEW
//                                                 WHERE HOSP_CODE = :f_hosp_code 
//                                                   AND BUNHO     = :f_bunho
//                                                   AND FKINP1001 = :f_fkinp1001";
//                                }
//                                break;
//                        }
                        break;

//                    case '2':   // grdNUR1002
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                item.BindVarList.Remove("f_ser");
//                                item.BindVarList.Add("f_ser",
//                                Service.ExecuteScalar(@"SELECT NVL(MAX(A.SER) + 1, 1) SER
//                                                          FROM NUR1002 A
//                                                         WHERE A.HOSP_CODE   = '" + item.BindVarList["f_hosp_code"].VarValue +
//                                                        "' AND A.FKINP1001   = '" + item.BindVarList["f_fkinp1001"].VarValue +
//                                                        "' AND A.BUNHO       = '" + item.BindVarList["f_f_bunho"].VarValue +
//                                                        "' AND A.INSERT_DATE = TO_DATE('" + item.BindVarList["f_insert_date"].VarValue + "', 'YYYY/MM/DD')").ToString());
                                
//                                cmdText = @"INSERT INTO NUR1002(SYS_DATE    , SYS_ID         , UPD_DATE                             ,  
//                                                                UPD_ID      , HOSP_CODE      ,
//                                                                FKINP1001   , BUNHO          , INSERT_DATE                          ,
//                                                                SER         , DRUG_COMMENT)
//                                            VALUES             (SYSDATE     , :q_user_id     , SYSDATE                              ,
//                                                                :q_user_id  , :f_hosp_code   ,
//                                                                :f_fkinp1001, :f_bunho       , TO_DATE(:f_insert_date, 'YYYY/MM/DD'),
//                                                                :f_ser      , :f_drug_comment)";
//                                break;
//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE NUR1002
//                                               SET UPD_ID       = :q_user_id
//                                                 , UPD_DATE     = SYSDATE
//                                                 , DRUG_COMMENT = :f_drug_comment
//                                             WHERE HOSP_CODE    = :f_hosp_code 
//                                               AND FKINP1001    = :f_fkinp1001
//                                               AND BUNHO        = :f_bunho
//                                               AND INSERT_DATE  = TO_DATE(:f_insert_date, 'YYYY/MM/DD')
//                                               AND SER          = :f_ser";
//                                break;
//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE NUR1002
//                                             WHERE HOSP_CODE   = :f_hosp_code 
//                                               AND FKINP1001   = :f_fkinp1001
//                                               AND BUNHO       = :f_bunho
//                                               AND INSERT_DATE = TO_DATE(:f_insert_date, 'YYYY/MM/DD')
//                                               AND SER         = :f_ser";
//                                break;
//                        }
//                        break;

                    case '4':   // grdINP1004
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                retVal = Service.ExecuteScalar(@"SELECT NVL(MAX(A.SEQ),0) + 1 SEQ 
                                                                   FROM INP1004 A 
                                                                  WHERE A.HOSP_CODE = '" + item.BindVarList["f_hosp_code"].VarValue + "'"
                                                                + " AND A.BUNHO     = '" + item.BindVarList["f_bunho"].VarValue + "'");

                                item.BindVarList.Add("f_seq", retVal.ToString());

                                cmdText = @"INSERT INTO INP1004 ( SYS_DATE,      SYS_ID,         UPD_DATE,     UPD_ID,  
                                                                  HOSP_CODE,     SEQ
                                                                , BUNHO,         NAME,           ZIP_CODE1,    ZIP_CODE2
                                                                , ADDRESS1,      ADDRESS2,       TEL1,         TEL2
                                                                , BIGO,          BONIN_GUBUN,    TEL3,         TEL_GUBUN
                                                                , TEL_GUBUN2,    TEL_GUBUN3,     NAME2,        PRIORITY
                                                                , BIRTH,         WITH_YN,        LIVE_YN                )
                                                          VALUES( SYSDATE,       :q_user_id,     SYSDATE,      :q_user_id, 
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
                                cmdText = @"UPDATE INP1004
                                               SET UPD_ID      = :q_user_id
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
                                cmdText = @"DELETE FROM INP1004
    	    	    	                     WHERE HOSP_CODE   = :f_hosp_code 
                                               AND BUNHO     = :f_bunho
    	    	    	                       AND SEQ       = :f_seq";
                                break;
                        }
                        break;

                    case '9':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq",
                                Service.ExecuteScalar(@"SELECT NVL(MAX(A.SEQ) + 1, 1) SER
                                                          FROM NUR1009 A
                                                         WHERE A.HOSP_CODE   = '" + item.BindVarList["f_hosp_code"].VarValue +
                                                        "' AND A.FKINP1001   = '" + item.BindVarList["f_fkinp1001"].VarValue +
                                                        "' AND A.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue +
                                                        "' AND A.GIROK_DATE  = TO_DATE('" + item.BindVarList["f_girok_date"].VarValue + "', 'YYYY/MM/DD')").ToString());
                                
                                cmdText = @"INSERT INTO NUR1009
                                                 ( SYS_DATE      , SYS_ID       , UPD_DATE            ,  UPD_ID       , HOSP_CODE,
                                                   BUNHO         , FKINP1001    , GIROK_DATE                          ,
                                                   SEQ           , JAETE_JUSU   , IMSIN_BUNMAN_SANYOK                 ,
                                                   SEX           , WEIGHT       )
                                            VALUES 
                                                 ( SYSDATE       , :q_user_id   , SYSDATE             , :q_user_id    , :f_hosp_code,
                                                   :f_bunho      , :f_fkinp1001 , TO_DATE(:f_girok_date, 'YYYY/MM/DD'),
                                                   NVL(:f_seq, 1), :f_jaete_jusu, :f_imsin_bunman_sanyok              ,
                                                   :f_sex        , :f_weight    )";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR1009
                                               SET UPD_DATE            = SYSDATE
                                                 , UPD_ID              = :q_user_id 
                                                 , JAETE_JUSU          = :f_jaete_jusu
                                                 , IMSIN_BUNMAN_SANYOK = :f_imsin_bunman_sanyok
                                                 , SEX                 = :f_sex
                                                 , WEIGHT              = :f_weight
                                             WHERE HOSP_CODE           = :f_hosp_code 
                                               AND BUNHO               = :f_bunho
                                               AND FKINP1001           = :f_fkinp1001
                                               AND GIROK_DATE          = TO_DATE(:f_girok_date, 'YYYY/MM/DD')
                                               AND SEQ                 = :f_seq";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR1009
                                             WHERE HOSP_CODE  = :f_hosp_code 
                                               AND BUNHO      = :f_bunho
                                               AND FKINP1001  = :f_fkinp1001
                                               AND GIROK_DATE = TO_DATE(:f_girok_date, 'YYYY/MM/DD')
                                               AND SEQ        = :f_seq";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void txtWeight_DataValidating(object sender, DataValidatingEventArgs e)
        {
            double result=0;

            if (TypeCheck.IsDouble(txtHeight.Text) && double.Parse(txtHeight.Text) > 0)
            {
                if (TypeCheck.IsDouble(txtWeight.Text) && double.Parse(txtWeight.Text) > 0)
                {
                    result = (double.Parse(txtWeight.Text) / (double.Parse(txtHeight.Text) * double.Parse(txtHeight.Text)) * 10000);
                    txtBMI.Text = result.ToString("#.##");
                }
            }
        }

        private void txtHeight_DataValidating(object sender, DataValidatingEventArgs e)
        {
            double result=0;
            if (TypeCheck.IsDouble(txtHeight.Text) && double.Parse(txtHeight.Text) > 0)
            {
                if (TypeCheck.IsDouble(txtWeight.Text) && double.Parse(txtWeight.Text) > 0)
                {
                    result = (double.Parse(txtWeight.Text) / (double.Parse(txtHeight.Text) * double.Parse(txtHeight.Text)) * 10000);
                    txtBMI.Text = result.ToString("#.##");
                }
            }
        }

        private void btnListTukki_MouseDown(object sender, MouseEventArgs e)
        {
            grdOUT0106.Focus();
        }

        private void grdOUT0106_QueryStarting(object sender, CancelEventArgs e)
        {            
            this.grdOUT0106.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOUT0106.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void btnListTukki_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    grdOUT0106.InsertRow();
                    break;

                case FunctionType.Delete:
                    e.IsBaseCall = false;
                    grdOUT0106.DeleteRow();
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    if (!grdOUT0106.SaveLayout())
                    {
                        XMessageBox.Show("update fail");
                    }
                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;
                    if (!grdOUT0106.QueryLayout(false))
                    {
                        XMessageBox.Show("query fail");
                    }
                    break;

                    
            }
        }

        private void layNUR1001_QueryEnd(object sender, QueryEndEventArgs e)
        {
            Controls_Enable_PreSet();

            if (layNUR1001.GetItemValue("writer").ToString() == "")
            {
                layNUR1001.SetItemValue("writer", UserInfo.UserID);
                layNUR1001.SetItemValue("writer_name", UserInfo.UserName);
            }
        }

        private void Controls_Enable_PreSet()
        {
            mbxBringDrugComment.Enabled   = layNUR1001.GetItemValue("bring_drug_yn").ToString() == "Y" ;
            mbxHealthcare.Enabled           = layNUR1001.GetItemValue("healthcare_yn").ToString() == "Y" ;
            txtFoodDislike.Enabled          = layNUR1001.GetItemValue("food_dislike_yn").ToString() == "Y" ;
            txtAppetite.Enabled             = layNUR1001.GetItemValue("appetite_yn").ToString() == "Y" ;
            txtDysphagia.Enabled            = layNUR1001.GetItemValue("dysphagia_yn").ToString() == "Y" ;
            //txtIntake.Enabled             = layNUR1001.GetItemValue("_yn").ToString() == "Y" ;
            txtMouthPollution.Enabled       = layNUR1001.GetItemValue("mouth_pollution_yn").ToString() == "Y" ;
            txtFalseTeeth.Enabled           = layNUR1001.GetItemValue("false_teeth_yn").ToString() == "Y" ;
            dtpCatheter.Enabled             = layNUR1001.GetItemValue("catheter_yn").ToString() == "Y";
            txtSleepEnough.Enabled          = layNUR1001.GetItemValue("sleep_enough_yn").ToString() == "N" ;
            txtSleepEtc.Enabled             = layNUR1001.GetItemValue("sleep_etc_yn").ToString() == "Y" ;
            gbxObstacleSense.Enabled        = layNUR1001.GetItemValue("obstacle_speech_yn").ToString() == "Y";
            txtObstacle.Enabled             = layNUR1001.GetItemValue("obstacle_yn").ToString() == "Y" ;
            txtRecognition.Enabled          = layNUR1001.GetItemValue("recognition_yn").ToString() == "Y" ;
            gbxSensorDetail.Enabled         = layNUR1001.GetItemValue("sensor_yn").ToString() == "Y" ;
            txtEyeRight.Enabled             = layNUR1001.GetItemValue("eye_right_yn").ToString() == "Y" ;
            txtEyeLeft.Enabled              = layNUR1001.GetItemValue("eye_left_yn").ToString() == "Y" ;
            txtEarRight.Enabled             = layNUR1001.GetItemValue("ear_right_yn").ToString() == "Y" ;
            txtEarLeft.Enabled              = layNUR1001.GetItemValue("ear_left_yn").ToString() == "Y" ;
            txtDizzy.Enabled                = layNUR1001.GetItemValue("dizzy_yn").ToString() == "Y" ;
            txtStagger.Enabled              = layNUR1001.GetItemValue("stagger_yn").ToString() == "Y" ;
            txtPain.Enabled                 = layNUR1001.GetItemValue("pain_yn").ToString() == "Y" ;
            txtPerception.Enabled           = layNUR1001.GetItemValue("perception_yn").ToString() == "Y" ;
            gbxMovementDetail.Enabled       = layNUR1001.GetItemValue("movement_yn").ToString() == "Y" ;
            txtParalysis.Enabled            = layNUR1001.GetItemValue("paralysis_yn").ToString() == "Y" ;
            txtContracture.Enabled          = layNUR1001.GetItemValue("contracture_yn").ToString() == "Y" ;
            txtLossPart.Enabled             = layNUR1001.GetItemValue("loss_part_yn").ToString() == "Y" ;
            txtWorry.Enabled                = layNUR1001.GetItemValue("worry_yn").ToString() == "Y" ;
            txtFear.Enabled                 = layNUR1001.GetItemValue("fear_yn").ToString() == "Y" ;
            txtFamily.Enabled               = layNUR1001.GetItemValue("family_yn").ToString() == "Y" ;
            //txtMensesAge.Enabled           = layNUR1001.GetItemValue("_yn").ToString() == "Y" ;
            txtMensesProblem.Enabled        = layNUR1001.GetItemValue("menses_problem_yn").ToString() == "Y" ;
            txtHobby.Enabled                = layNUR1001.GetItemValue("hobby_yn").ToString() == "Y" ;
            txtStress.Enabled               = layNUR1001.GetItemValue("stress_yn").ToString() == "Y" ;
            txtReligion.Enabled             = layNUR1001.GetItemValue("religion_yn").ToString() == "Y";            
        }

        private void rbxCheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rb = (XRadioButton)sender;

            switch (rb.Name)
            {
                case "rbxBringDrugY":
                    mbxBringDrugComment.Enabled = rb.Checked;
                    break;
                case "rbxHealthcareY":
                    mbxHealthcare.Enabled = rb.Checked;
                    break;
                case "rbxFoodDislikeY":
                    txtFoodDislike.Enabled = rb.Checked;
                    break;
                case "rbxAppetiteY":
                    txtAppetite.Enabled = rb.Checked;
                    break;
                case "rbxDysphagiaY":
                     txtDysphagia.Enabled = rb.Checked;
                    break;
                case "rbxMouthPollutionY":
                    txtMouthPollution.Enabled = rb.Checked;
                    break;
                case "rbxFalseTeethY":
                    txtFalseTeeth.Enabled = rb.Checked;
                    break;
                case "rbxSleepEnoughN":
                    txtSleepEnough.Enabled = rb.Checked;
                    break;
                case "rbxObstacleSpeechY":
                    gbxObstacleSense.Enabled = rb.Checked;
                    break;
                case "rbxObstacleY":
                    txtObstacle.Enabled = rb.Checked;
                    break;
                case "rbxRecognitionY":
                    txtRecognition.Enabled = rb.Checked;
                    break;
                case "rbxSensorY":
                    gbxSensorDetail.Enabled = rb.Checked;
                    break;
                case "rbxDizzyY":
                    txtDizzy.Enabled = rb.Checked;
                    break;
                case "rbxStaggerY":
                    txtStagger.Enabled = rb.Checked;
                    break;
                case "rbxPainY":
                    txtPain.Enabled = rb.Checked;
                    break;
                case "rbxPerceptionY":
                    txtPerception.Enabled = rb.Checked;
                    break;
                case "rbxMovementY":
                    gbxMovementDetail.Enabled = rb.Checked;
                    break;
                case "rbxParalysisY":
                    txtParalysis.Enabled = rb.Checked;
                    break;
                case "rbxContractureY":
                    txtContracture.Enabled = rb.Checked;
                    break;
                case "rbxLossPartY":
                    txtLossPart.Enabled = rb.Checked;
                    break;
                case "rbxWorryY":
                    txtWorry.Enabled = rb.Checked;
                    break;
                case "rbxFearY":
                    txtFear.Enabled = rb.Checked;
                    break;
                case "rbxFamilyY":
                    txtFamily.Enabled = rb.Checked;
                    break;
                case "rbxMensesProblemY":
                    txtMensesProblem.Enabled = rb.Checked;
                    break;
                case "rbxHobbyY":
                    txtHobby.Enabled = rb.Checked;
                    break;
                case "rbxStressY":
                    txtStress.Enabled = rb.Checked;
                    break;
                case "rbxReligionY":
                    txtReligion.Enabled = rb.Checked;
                    break;
            }
        }

        private void cbxCheckedChanged(object sender, EventArgs e)
        {
            XCheckBox cb = (XCheckBox)sender;

            switch (cb.Name)
            {
                case "cbxCatheter":
                    dtpCatheter.Enabled = cb.Checked;
                    break;
                case "cbxSleepEtc":
                    txtSleepEtc.Enabled = cb.Checked;
                    break;                    
                case "cbxEyeRight":
                    txtEyeRight.Enabled = cb.Checked;
                    break;
                case "cbxEyeLeft":
                    txtEyeLeft.Enabled = cb.Checked;
                    break;
                case "cbxEarRight":
                    txtEarRight.Enabled = cb.Checked;
                    break;
                case "cbxEarLeft":
                    txtEarLeft.Enabled = cb.Checked;
                    break;
            }
        }

        private void dtpBirth_DataValidating(object sender, DataValidatingEventArgs e)
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

        private void lbl_DoubleClick(object sender, EventArgs e)
        {
            
            XLabel lb = (XLabel)sender;

            string ctrl = lb.Name.Replace("lbl", "gbx");

            ((XGroupBox)((XLabel)sender).Parent.Controls[ctrl]).SetDataValue(null);
            
        }

        private void btnSkinAdd_Click(object sender, EventArgs e)
        {
            grdNUR1029.InsertRow(-1);

        }

        private void btnSkinDel_Click(object sender, EventArgs e)
        {
            grdNUR1029.DeleteRow(grdNUR1029.CurrentRowNumber);
        }

        private void grdNUR1029_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR1029.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR1029.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void layComboSet_QueryStarting(object sender, CancelEventArgs e)
        {
            layComboSet.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void lblObstacleSpeech_DoubleClick(object sender, EventArgs e)
        {
            lbl_DoubleClick(sender, e);
            gbxObstacleSense.SetDataValue(null);
        }

        private void fwkFind_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkFind.SetBindVarValue("f_buseo_name", grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "ho_dong"));
        }

        private void fbxWriter_FindSelected(object sender, FindEventArgs e)
        {
            dbxWriter.SetDataValue(e.ReturnValues[1].ToString());
        }

        private void grdNUR1029_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            fwkCommon.ColInfos.Clear();

            //fwkCommon.ColInfos.Add("code", "コード", FindColType.String, 60, 0, true, FilterType.InitYes);
            fwkCommon.ColInfos.Add("code_name", "コード名称", FindColType.String, 240, 0, true, FilterType.InitYes);
            fwkCommon.InputSQL = @"SELECT A.CODE_NAME
                                                --, A.CODE_NAME
                                             FROM NUR0102 A
                                            WHERE A.HOSP_CODE = :f_hosp_code 
                                              AND A.CODE_TYPE = :f_code_type
                                            ORDER BY 1";
            fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkCommon.SetBindVarValue("f_code_type", "ANAMUNE_SKIN");   
            fwkCommon.ColInfos[0].ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
        }

        private void btnVital_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo.ToString() == "")
            {
                this.GetMessage("bunho");
                return;
            }
            else
            {
                string toiwon_date = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_date");

                if (toiwon_date == "")
                {
                    toiwon_date = EnvironInfo.GetSysDate().ToShortDateString();
                }

                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("sysid", EnvironInfo.CurrSystemID);
                openParams.Add("screen", this.ScreenID.ToString());
                openParams.Add("bunho", this.paBox.BunHo);
                openParams.Add("date", toiwon_date);
                //openParams.Add("hodong", this.cboHo_dong.GetDataValue());
                openParams.Add("jaewon_yn", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "jaewon_flag"));
                openParams.Add("fkinp1001", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "fkinp1001"));
                
                XScreen.OpenScreenWithParam(this, "NURI", "NUR1020Q00", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopLeft, openParams);
            }

        }

        private void btnChiryo_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo.ToString() == "")
            {
                XMessageBox.Show("患者番号が選択されていません。");
                paBox.Focus();
                return;
            }
            else
            {
                //IXScreen screen = XScreen.FindScreen("OCSI", "OCS6010U10");
                //if (screen == null)
                //{

                string toiwon_date = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_date");

                if (toiwon_date == "")
                {
                    toiwon_date = EnvironInfo.GetSysDate().ToShortDateString();
                }

                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("sysid", EnvironInfo.CurrSystemID);
                openParams.Add("screen", this.ScreenID.ToString());
                openParams.Add("bunho", this.paBox.BunHo);
                openParams.Add("jaewon_yn", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "jaewon_flag"));
                openParams.Add("fkinp1001", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "fkinp1001"));
                openParams.Add("query_date", toiwon_date);

                XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopLeft, openParams);

                //}
                //else
                //{
                //    screen.Activate();
                //    XPatientInfo pInfo = new XPatientInfo(paBox.BunHo, "", "", "", this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "pkinp1001"), PatientPKGubun.In, this.ScreenID);
                //    XScreen.SendPatientInfo(pInfo);
                //}

            }
        }

        private void btnNUR9001_Click(object sender, EventArgs e)
        {
            IHIS.Framework.IXScreen aScreen;
            aScreen = XScreen.FindScreen("NURI", "NUR9001U00");

            string toiwon_date = this.grdINP1001.GetItemString(grdINP1001.CurrentRowNumber, "toiwon_date");

            if (toiwon_date == "")
            {
                toiwon_date = EnvironInfo.GetSysDate().ToShortDateString();
            }

            if (aScreen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("toiwon_date", toiwon_date);
                openParams.Add("fkinp1001", this.grdINP1001.GetItemValue(this.grdINP1001.CurrentRowNumber, "fkinp1001"));
                openParams.Add("bunho", this.grdINP1001.GetItemValue(this.grdINP1001.CurrentRowNumber, "bunho"));
                XScreen.OpenScreenWithParam(this, "NURI", "NUR9001U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);
            }
            else
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("toiwon_date", this.grdINP1001.GetItemValue(this.grdINP1001.CurrentRowNumber, "toiwon_date"));
                openParams.Add("fkinp1001", this.grdINP1001.GetItemValue(this.grdINP1001.CurrentRowNumber, "fkinp1001"));
                openParams.Add("bunho", this.grdINP1001.GetItemValue(this.grdINP1001.CurrentRowNumber, "bunho"));
                this.Close();
                aScreen.Command("toiwon_date", openParams);
            }
        }

    }
}

