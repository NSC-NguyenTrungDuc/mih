#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector.Contracts.Arguments.Phys;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Messaging;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using System.IO;
using IHIS.PHYS.Properties;
using IHIS.CloudConnector.Contracts.Results.Phys;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using ComboListItemInfo = IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo;
using PHY8002U01GrdOTListItemInfo = IHIS.CloudConnector.Contracts.Models.Phys.PHY8002U01GrdOTListItemInfo;
using PHY8002U01GrdPHY8002LisItemInfo = IHIS.CloudConnector.Contracts.Models.Phys.PHY8002U01GrdPHY8002LisItemInfo;
using PHY8002U01GrdPHY8003LisItemInfo = IHIS.CloudConnector.Contracts.Models.Phys.PHY8002U01GrdPHY8003LisItemInfo;
using PHY8002U01GrdPHY8004LisItemInfo = IHIS.CloudConnector.Contracts.Models.Phys.PHY8002U01GrdPHY8004LisItemInfo;

#endregion

namespace IHIS.PHYS
{
	/// <summary>
	/// PHY1000U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class PHY8002U01 : IHIS.Framework.XScreen
	{
        //copy用依頼書pkocskey
        private string copyPkocskey = "";
        private MultiLayout layPHY8002 = null;
        private const int print_cnt = 2;
        private DirectoryInfo dirInfo = null;
        //Control HashTable
        string mPKPHY8002 = "";
        const string mIRAI_KUBUN = "D";
        Hashtable htPHY8002;
        string mHospCode = UserInfo.HospCode;
        // 저장용 flag 변수

        private string mApproveDoctorID = "";
        private string mApproveDoctorGWA = "";

        // PT, OT, ST の変更可否
        private bool mChanged = false;
        // PHY8003, PHY8004, PT, OT, ST, PHY8002 の変更可否
        private bool update_changed = false;
        private int leaveCnt = 0;
        bool mIsUpdateSuccess = false;
        private string mMsg = "";
        private string mCap = "";
        private XImageEditor imageEditorOri = new XImageEditor();
        private string mPKSCAN001 = "";
        private string clientFilePath = "";
        private string fileName = "";

        private XEditGrid mCurrentGrid = null;
        private IHIS.OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz("PHY8002U01");
        /////////////Popup Menu ////////////////////////////////////////////////////////////////////////////
        private IHIS.X.Magic.Menus.PopupMenu popupOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 처방Grid용

		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlCenter;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlCenterLeft;
		private IHIS.Framework.XButtonList btnList;

        private IHIS.Framework.XTextBox txtInfectious;
        private IHIS.Framework.XPatientBox patBox;
		private IHIS.Framework.XEditGrid grdPHY8002;
        private XPanel pnlSukoumoku;
        private XPanel pnlIrainaiyou;
        private XGroupBox gbxPT;
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
        private XEditGridCell xEditGridCell19;
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
        private XEditGrid grdPHY8003;
        private XPanel pnlTopInfo;
        private XGroupBox gbxSindanmei;
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
        private XEditGridCell xEditGridCell117;
        private XEditGridCell xEditGridCell118;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell120;
        private XEditGridCell xEditGridCell121;
        private XEditGridCell xEditGridCell122;
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell125;
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
        private XDatePicker dtpKyuseizouakubi;
        private XDatePicker dtpSyujyutubi;
        private XLabel xLabel3;
        private XLabel xLabel2;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell14;
        private XDataWindow dwIraisyo;
        private MultiLayout layIraisyo;
        private XPanel pnlDisUseObj;
        private XTextBox txtDisUse_Contents;
        private XDictComboBox cboDisUse_Kainyu;
        private XDictComboBox cboDisUse_Kaizen;
        private XDictComboBox cboDisUse_ADL;
        private XDictComboBox cboDisUse_Gasyou;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XTextBox txtDisuse_FIMBI;
        private XFlatLabel xFlatLabel10;
        private XFlatLabel xFlatLabel9;
        private XGroupBox gbxDisuse_Kaizen;
        private XGroupBox gbxDisuse_Kainyu;
        private XGroupBox gbxDisuse_ADL;
        private XGroupBox gbxDisuse_Gasyou;
        private XEditGridCell xEditGridCell23;
        private XEditGrid grdPHY8004;
        private XEditGridCell xEditGridCell116;
        private XEditGridCell xEditGridCell152;
        private XEditGridCell xEditGridCell153;
        private XEditGridCell xEditGridCell155;
        private XEditGridCell xEditGridCell166;
        private XEditGridCell xEditGridCell167;
        private XEditGridCell xEditGridCell168;
        private XEditGridCell xEditGridCell169;
        private XEditGridCell xEditGridCell170;
        private XEditGridCell xEditGridCell154;
        private XEditGridCell xEditGridCell171;
        private XGroupBox grbDisability;
        private XButton btnDisability;
        private XTextBox txtDisability;
        private XFlatRadioButton rbtGasyou_01;
        private XGroupBox gbxDisuse_Contents;
        private XFlatRadioButton rbtGasyou_02;
        private XFlatRadioButton rbtKaizen_03;
        private XFlatRadioButton rbtKaizen_05;
        private XFlatRadioButton rbtKaizen_02;
        private XFlatRadioButton rbtKaizen_01;
        private XFlatRadioButton rbtKaizen_04;
        private XFlatRadioButton rbtBEFADL_03;
        private XFlatRadioButton rbtBEFADL_06;
        private XFlatRadioButton rbtBEFADL_05;
        private XFlatRadioButton rbtBEFADL_01;
        private XFlatRadioButton rbtBEFADL_04;
        private XFlatRadioButton rbtBEFADL_02;
        private XFlatRadioButton rbtGasyou_03;
        private XFlatRadioButton rbtGasyou_05;
        private XFlatRadioButton rbtGasyou_04;
        private XFlatRadioButton rbtKainyu_03;
        private XFlatRadioButton rbtKainyu_05;
        private XFlatRadioButton rbtKainyu_02;
        private XFlatRadioButton rbtKainyu_04;
        private XFlatRadioButton rbtKainyu_01;
        private Label label2;
        private Label label3;
        private Label label4;
        private XEditGridCell xEditGridCell24;
        private XTextBox txtYoin_sindan_date;
        private XTextBox txtYoin_start_date;
        private XFlatLabel xFlatLabel2;
        private XFlatLabel xFlatLabel1;
        private XFlatLabel xFlatLabel3;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell48;
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
        private MultiLayoutItem multiLayoutItem178;
        private MultiLayoutItem multiLayoutItem179;
        private MultiLayoutItem multiLayoutItem180;
        private MultiLayoutItem multiLayoutItem181;
        private MultiLayoutItem multiLayoutItem182;
        private MultiLayoutItem multiLayoutItem183;
        private MultiLayoutItem multiLayoutItem184;
        private MultiLayoutItem multiLayoutItem185;
        private MultiLayoutItem multiLayoutItem186;
        private MultiLayoutItem multiLayoutItem187;
        private MultiLayoutItem multiLayoutItem188;
        private MultiLayoutItem multiLayoutItem189;
        private MultiLayoutItem multiLayoutItem190;
        private MultiLayoutItem multiLayoutItem191;
        private MultiLayoutItem multiLayoutItem192;
        private MultiLayoutItem multiLayoutItem193;
        private MultiLayoutItem multiLayoutItem194;
        private MultiLayoutItem multiLayoutItem195;
        private MultiLayoutItem multiLayoutItem196;
        private MultiLayoutItem multiLayoutItem197;
        private MultiLayoutItem multiLayoutItem198;
        private MultiLayoutItem multiLayoutItem237;
        private MultiLayoutItem multiLayoutItem238;
        private MultiLayoutItem multiLayoutItem239;
        private MultiLayoutItem multiLayoutItem242;
        private MultiLayoutItem multiLayoutItem243;
        private MultiLayoutItem multiLayoutItem252;
        private MultiLayoutItem multiLayoutItem253;
        private MultiLayoutItem multiLayoutItem254;
        private MultiLayoutItem multiLayoutItem255;
        private MultiLayoutItem multiLayoutItem256;
        private MultiLayoutItem multiLayoutItem257;
        private MultiLayoutItem multiLayoutItem258;
        private MultiLayoutItem multiLayoutItem259;
        private MultiLayoutItem multiLayoutItem262;
        private MultiLayoutItem multiLayoutItem263;
        private MultiLayoutItem multiLayoutItem264;
        private XCheckBox cbxSu_2_4_c;
        private XCheckBox cbxBU_FLAG;
        private XCheckBox cbxSu_2_3;
        private XCheckBox cbxKE_FLAG;
        private XCheckBox cbxSu_2_2;
        private XFlatRadioButton rbtSu_3_1;
        private XCheckBox cbxSu_2_1;
        private XFlatRadioButton rbtSu_3_2;
        private XFlatLabel xFlatLabel39;
        private XTextBox txtKg;
        private XTextBox txtSu_2_4;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XButton btnCopy;
        private XCheckBox cbxSu_4_1;
        private XButton btnObjective;
        private XButton btnJisi;
        private XPanel pnlCenterRight;
        private XPanel xPanel12;
        private XImageEditor imageEditor;
        private XPanel xPanel9;
        private XButton btnReset;
        private XLabel xLabel5;
        private XLabel xLabel4;
        private XTabControl tabReha;
        private IHIS.X.Magic.Controls.TabPage tpgImage;
        private IHIS.X.Magic.Controls.TabPage tpgFIM;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell149;
        private XEditGridCell xEditGridCell151;
        private XEditGridCell xEditGridCell156;
        private string mPathNm = string.Empty;

        //tungtx
	    private PHY8002U01MultiGrdResult multiGrdResult = null;
	    private PHY8002U01SaveLayoutResult saveLayoutResult = null;

		public PHY8002U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            //grdPHY8002.SavePerformer = new XSavePerformer(this);
            //grdPHY8003.SavePerformer = grdPHY8002.SavePerformer;
            //grdPHY8004.SavePerformer = grdPHY8003.SavePerformer;

            //set ParamList
            grdPHY8002.ParamList = new List<string>(new String[] { "f_fk_ocs" });
            grdPHY8003.ParamList = new List<string>(new String[] { "f_kanja_no", "f_fk_ocs_irai" });
            grdPHY8004.ParamList = new List<string>(new String[] { "f_fk_ocs_irai" });

            //set ExecuteQuery
		    grdPHY8002.ExecuteQuery = LoadDataGrdPHY8002;
		    grdPHY8003.ExecuteQuery = LoadDataGrdPHY8003;
		    grdPHY8004.ExecuteQuery = LoadDataGrdPHY8004;
		    grdOT.ExecuteQuery = LoadDataGrdOT;
		    grdPT.ExecuteQuery = LoadDataGrdPT;
		    grdST.ExecuteQuery = LoadDataGrdST;
		    cboDisUse_Kaizen.ExecuteQuery = LoadDataCboKaizen;
		    cboDisUse_Kainyu.ExecuteQuery = LoadDataCboKaiNyu;
		    cboDisUse_ADL.ExecuteQuery = LoadDataCboADL;
		    cboDisUse_Gasyou.ExecuteQuery = LoadDataCboGasyou;
		    cboDisUse_Kaizen.SetDictDDLB();
		    cboDisUse_Kainyu.SetDictDDLB();
		    cboDisUse_ADL.SetDictDDLB();
		    cboDisUse_Gasyou.SetDictDDLB();
		}

	    #region CloudService



        private List<object[]> LoadDataLayJisseki(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY8002U01GetLayJissekiDataArgs args = new PHY8002U01GetLayJissekiDataArgs();
            args.Fkocs = bc["f_fkocs"] != null ? bc["f_fkocs"].VarValue : "";
            args.InOutGubun = bc["f_in_out_gubun"] != null ? bc["f_in_out_gubun"].VarValue : "";
            PHY8002U01GetLayJissekiDataResult result = CloudService.Instance.Submit<PHY8002U01GetLayJissekiDataResult, PHY8002U01GetLayJissekiDataArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.Result
                });
            }
            return res;
        } 



        private List<object[]> LoadDataLayCbo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY8002U01GetLayComboArgs args = new PHY8002U01GetLayComboArgs();
            ComboResult result =
                CacheService.Instance.Get<PHY8002U01GetLayComboArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
        }

        private List<object[]> LoadDataCboGasyou(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY8002U01CboDisUseGasyouArgs args = new PHY8002U01CboDisUseGasyouArgs();
            ComboResult result =
                CacheService.Instance.Get<PHY8002U01CboDisUseGasyouArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
        }

        private List<object[]> LoadDataCboADL(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY8002U01CboDisUseADLArgs args = new PHY8002U01CboDisUseADLArgs();
            ComboResult result =
                CacheService.Instance.Get<PHY8002U01CboDisUseADLArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
        }

        private List<object[]> LoadDataCboKaiNyu(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY8002U01CboDisUseKainyuArgs args = new PHY8002U01CboDisUseKainyuArgs();
            ComboResult result =
                CacheService.Instance.Get<PHY8002U01CboDisUseKainyuArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
        }

        private List<object[]> LoadDataCboKaizen(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
            PHY8002U01CboDisUseKaizenArgs args = new PHY8002U01CboDisUseKaizenArgs();
            ComboResult result =
                CacheService.Instance.Get<PHY8002U01CboDisUseKaizenArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
	    }

	    private List<object[]> LoadDataGrdST(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            if (multiGrdResult != null && multiGrdResult.GrdSTList != null)
            {
                List<PHY8002U01GrdOTListItemInfo> grdList = multiGrdResult.GrdSTList;
                foreach (PHY8002U01GrdOTListItemInfo info in grdList)
                {
                    res.Add(new object[]
                    {
                        info.Selected,
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
        } 

        private List<object[]> LoadDataGrdPT(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            if (multiGrdResult != null && multiGrdResult.GrdPTList != null)
            {
                List<PHY8002U01GrdOTListItemInfo> grdList = multiGrdResult.GrdPTList;
                foreach (PHY8002U01GrdOTListItemInfo info in grdList)
                {
                    res.Add(new object[]
                    {
                        info.Selected,
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
        } 

        private List<object[]> LoadDataGrdOT(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            if (multiGrdResult != null && multiGrdResult.GrdOTList != null)
            {
                List<PHY8002U01GrdOTListItemInfo> grdList = multiGrdResult.GrdOTList;
                foreach (PHY8002U01GrdOTListItemInfo info in grdList)
                {
                    res.Add(new object[]
                    {
                        info.Selected,
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return res;
        } 

        private List<object[]> LoadDataGrdPHY8004(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY8002U01GrdPHY8004Args args = new PHY8002U01GrdPHY8004Args();
            args.FkOcsIrai = bc["f_fk_ocs_irai"] != null ? bc["f_fk_ocs_irai"].VarValue : "";
            PHY8002U01GrdPHY8004Result result = CloudService.Instance.Submit<PHY8002U01GrdPHY8004Result, PHY8002U01GrdPHY8004Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (PHY8002U01GrdPHY8004LisItemInfo item in result.List)
                {
                    object[] objects = 
				{ 
					item.SysDate, 
					item.UserId, 
					item.UpdDate, 
					item.HospCode, 
					item.PkPhySyougai, 
					item.DataKubun, 
					item.FkOcsIrai, 
					item.SyougaiId, 
					item.Syougaimei, 
					item.KanjaNo, 
					item.Fkcht0113
				};
                    res.Add(objects);
                }
            }
            return res;
        } 



        private List<object[]> LoadDataGrdPHY8003(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY8002U01GrdPHY8003Args args = new PHY8002U01GrdPHY8003Args();
            args.KanjaNo = bc["f_kanja_no"] != null ? bc["f_kanja_no"].VarValue : "";
            args.FkOcsIrai = bc["f_fk_ocs_irai"] != null ? bc["f_fk_ocs_irai"].VarValue : "";
            PHY8002U01GrdPHY8003Result result = CloudService.Instance.Submit<PHY8002U01GrdPHY8003Result, PHY8002U01GrdPHY8003Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (PHY8002U01GrdPHY8003LisItemInfo item in result.List)
                {
                    object[] objects = 
				{ 
					item.YsDate, 
					item.UserId, 
					item.UpdDate, 
					item.HospCode, 
					item.PkPhySyoubyou, 
					item.DataKubun, 
					item.FkOcsIrai, 
					item.IoKubun, 
					item.IraiDate, 
					item.KanjaNo, 
					item.Sinryouka, 
					item.SyoubyoumeiCode, 
					item.ModifierName, 
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
					item.Hassyoubi, 
					item.Sindanbi, 
					item.PreModifierName, 
					item.PostModifierName, 
					item.Syoubyoumei, 
					item.Fkoutsang
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdPHY8002AfterSave(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            List<PHY8002U01GrdPHY8002LisItemInfo> resultList = saveLayoutResult.SetPHY8002Info;

            if (resultList != null)
            {
                foreach (PHY8002U01GrdPHY8002LisItemInfo item in resultList)
                {
                    object[] objects =
                    {
                        item.SysDate,
                        item.UserId,
                        item.UpdDate,
                        item.HospCode,
                        item.Pkphy8002,
                        item.FkOcs,
                        item.IoKubun,
                        item.IraiDate,
                        item.KanjaNo,
                        item.Sinryouka,
                        item.Sindanisi,
                        item.Tantoui,
                        item.Nyuuinnbi,
                        item.ByousituCode,
                        item.ByoutouCode,
                        item.Kaisibi,
                        item.Nissuu,
                        item.KoumokuCode,
                        item.Pt1,
                        item.Pt2,
                        item.Pt3,
                        item.Pt4,
                        item.Pt5,
                        item.Pt6,
                        item.Pt7,
                        item.Pt8,
                        item.Pt9,
                        item.Pt10,
                        item.Ot1,
                        item.Ot2,
                        item.Ot3,
                        item.Ot4,
                        item.Ot5,
                        item.Ot6,
                        item.Ot7,
                        item.Ot8,
                        item.Ot9,
                        item.Ot10,
                        item.St1,
                        item.St2,
                        item.St3,
                        item.St4,
                        item.St5,
                        item.St6,
                        item.St7,
                        item.St8,
                        item.St9,
                        item.St10,
                        item.Objective,
                        item.ConsultComment,
                        item.Genbyoureki,
                        item.Complications,
                        item.Taboo,
                        item.StopKijyun,
                        item.Frequency,
                        item.Infectious,
                        item.Kioureki,
                        item.SyoriFlag,
                        item.PtFlag,
                        item.OtFlag,
                        item.StFlag,
                        item.BuFlag,
                        item.Syujyutubi,
                        item.Kyuseizouakubi,
                        item.DisuseGasyou,
                        item.DisuseAdl,
                        item.DisuseKainyu,
                        item.DisuseKaizen,
                        item.DisuseContents,
                        item.IraiKubun,
                        item.DisuseFimbi,
                        item.YoinStartDate,
                        item.YoinSindanDate,
                        item.Su1,
                        item.Su21,
                        item.Su22,
                        item.Su23,
                        item.Su24,
                        item.Su31,
                        item.Su32,
                        item.Su41,
                        item.Su42,
                        item.Su43,
                        item.KeFlag,
                        item.Image,
                        item.ImagePath,
                        item.ImageSeq,
                        item.CrTime
                    };
                    res.Add(objects);
                }
            }
            return res;
        }


        private List<object[]> LoadDataGrdPHY8002(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        PHY8002U01GrdPHY8002Args args = new PHY8002U01GrdPHY8002Args();
	        args.FkOcs = bc["f_fk_ocs"] != null ? bc["f_fk_ocs"].VarValue : "";
	        PHY8002U01GrdPHY8002Result result =
	            CloudService.Instance.Submit<PHY8002U01GrdPHY8002Result, PHY8002U01GrdPHY8002Args>(
	                args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (PHY8002U01GrdPHY8002LisItemInfo item in result.List)
	            {
	                object[] objects =
	                {
	                    item.SysDate,
	                    item.UserId,
	                    item.UpdDate,
	                    item.HospCode,
	                    item.Pkphy8002,
	                    item.FkOcs,
	                    item.IoKubun,
	                    item.IraiDate,
	                    item.KanjaNo,
	                    item.Sinryouka,
	                    item.Sindanisi,
	                    item.Tantoui,
	                    item.Nyuuinnbi,
	                    item.ByousituCode,
	                    item.ByoutouCode,
	                    item.Kaisibi,
	                    item.Nissuu,
	                    item.KoumokuCode,
	                    item.Pt1,
	                    item.Pt2,
	                    item.Pt3,
	                    item.Pt4,
	                    item.Pt5,
	                    item.Pt6,
	                    item.Pt7,
	                    item.Pt8,
	                    item.Pt9,
	                    item.Pt10,
	                    item.Ot1,
	                    item.Ot2,
	                    item.Ot3,
	                    item.Ot4,
	                    item.Ot5,
	                    item.Ot6,
	                    item.Ot7,
	                    item.Ot8,
	                    item.Ot9,
	                    item.Ot10,
	                    item.St1,
	                    item.St2,
	                    item.St3,
	                    item.St4,
	                    item.St5,
	                    item.St6,
	                    item.St7,
	                    item.St8,
	                    item.St9,
	                    item.St10,
	                    item.Objective,
	                    item.ConsultComment,
	                    item.Genbyoureki,
	                    item.Complications,
	                    item.Taboo,
	                    item.StopKijyun,
	                    item.Frequency,
	                    item.Infectious,
	                    item.Kioureki,
	                    item.SyoriFlag,
	                    item.PtFlag,
	                    item.OtFlag,
	                    item.StFlag,
	                    item.BuFlag,
	                    item.Syujyutubi,
	                    item.Kyuseizouakubi,
	                    item.DisuseGasyou,
	                    item.DisuseAdl,
	                    item.DisuseKainyu,
	                    item.DisuseKaizen,
	                    item.DisuseContents,
	                    item.IraiKubun,
	                    item.DisuseFimbi,
	                    item.YoinStartDate,
	                    item.YoinSindanDate,
	                    item.Su1,
	                    item.Su21,
	                    item.Su22,
	                    item.Su23,
	                    item.Su24,
	                    item.Su31,
	                    item.Su32,
	                    item.Su41,
	                    item.Su42,
	                    item.Su43,
	                    item.KeFlag,
	                    item.Image,
	                    item.ImagePath,
	                    item.ImageSeq,
	                    item.CrTime
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        private void SavePHY8002U01()
        {
            saveLayoutResult = new PHY8002U01SaveLayoutResult();

            List<PHY8002U01GrdPHY8002LisItemInfo> list8002 = GetListFromGrd8002();
            List<PHY8002U01GrdPHY8003LisItemInfo> list8003 = GetListFromGrd8003();
            List<PHY8002U01GrdPHY8004LisItemInfo> list8004 = GetListFromGrd8004();
            if (list8002.Count == 0 && list8003.Count == 0 && list8004.Count == 0 && leaveCnt < 1)
            {
                saveLayoutResult.Result8002 = true;
                saveLayoutResult.Result8003 = true;
                saveLayoutResult.Result8004 = true;
                return;
            }

            PHY8002U01SaveLayoutArgs args = new PHY8002U01SaveLayoutArgs();
            args.ApproveDoctorGwa = mApproveDoctorGWA;
            args.ApproveDoctorId = mApproveDoctorID;
            args.Bunho = mBunho;
            args.CopyPkocskey = copyPkocskey;
            args.FkOcs = mFkocs;
            args.Input8002 = list8002;
            args.Input8003 = list8003;
            args.Input8004 = list8004;
            args.IoKubun = mInOutGubun;
            args.PkScan001 = mPKSCAN001;
            args.UserGubun = UserType.Doctor.ToString();
            args.UserId = UserInfo.UserID;
            args.LeaveCnt = leaveCnt.ToString();

            saveLayoutResult = CloudService.Instance.Submit<PHY8002U01SaveLayoutResult, PHY8002U01SaveLayoutArgs>(args);
            if (saveLayoutResult.ExecutionStatus == ExecutionStatus.Success)
            {
                if (saveLayoutResult.Result8002 && saveLayoutResult.Result8003 && saveLayoutResult.Result8004 && leaveCnt > 0)
                {
                    this.mPKPHY8002 = saveLayoutResult.PkPhy8002;

                    SetPHY8002Info();

                    //Save end
                    /////////////////////
                    string jundal_part = "REHA";
                    string irai_date = this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "irai_date");
                    string image_name = this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "image");

                    Image image = imageEditor.Image;
                    string filePath = Application.StartupPath + "\\" + "REHA" + "Images" + "\\" + jundal_part;
                    //파일경로가 없으면 생성
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    //Image를 Client 파일로 저장(파일명은 서버파일명으로)한후에 FTP를 통해 서버로 Upload
                    fileName = Application.StartupPath + "\\" + "REHA" + "Images" + "\\" + jundal_part + "\\" +
                               image_name;
                    //Image를 지정한 파일로 저장
                    if (!ImageHelper.SaveImageFile(image, fileName)) return;

                    //clientFilePath = Application.StartupPath + "\\" + "REHA" + "Images" + "\\" + jundal_part;

                    /*
                    * 추후 경로변경 필요
                    * "/IFCImage/..."를 "/IHISImage/..."로 변경필요
                    * 
                    * */
                    //string serverFilePath = mPathNm + "/"
                    //                        + "REHA" + "/"
                    //                        + "REHA" + "/"
                    //                        + irai_date.Substring(0, 4) + "/"
                    //                        + irai_date;

                    //ArrayList uploadFileInfoList = new ArrayList();
                    //uploadFileInfoList.Add(new ImageFileInfo(clientFilePath, serverFilePath, image_name, image_name));

                    //Upload 실패시 Return

                    //TODO: Upload image to server
                    //if (!ImageHelper.UploadImages(uploadFileInfoList, true))
                    //    return;

                    // MED-10181
                    //string uploadAddress = IHIS.Framework.Utilities.GetFileConfig("UploadBaseUri");
                    string uploadAddress = Utility.GetConfig("UploadBaseUri", UserInfo.VpnYn);

                    string uploadToken = IHIS.Framework.Utilities.GetFileConfig("UploadToken");
                    Uri address = new Uri(uploadAddress);
                    IHIS.Framework.Utilities.UploadFile(address, fileName, uploadToken, mHospCode, mBunho);
                }
                else
                {
                    if (!String.IsNullOrEmpty(saveLayoutResult.MsgCase3))
                    {
                        XMessageBox.Show(Resources.TEXT31);
                    }
                }
            }
            else
            {
                saveLayoutResult.Result8002 = false;
                saveLayoutResult.Result8003 = false;
                saveLayoutResult.Result8004 = false;
            }
        }

	    private List<PHY8002U01GrdPHY8004LisItemInfo> GetListFromGrd8004()
	    {
            List<PHY8002U01GrdPHY8004LisItemInfo> dataList = new List<PHY8002U01GrdPHY8004LisItemInfo>();
            for (int i = 0; i < grdPHY8004.RowCount; i++)
            {
                if (grdPHY8004.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                PHY8002U01GrdPHY8004LisItemInfo info = new PHY8002U01GrdPHY8004LisItemInfo();
                info.SysDate = grdPHY8004.GetItemString(i, "sys_date");
                info.UserId = grdPHY8004.GetItemString(i, "user_id");
                info.UpdDate = grdPHY8004.GetItemString(i, "upd_date");
                info.HospCode = grdPHY8004.GetItemString(i, "hosp_code");
                info.PkPhySyougai = grdPHY8004.GetItemString(i, "pk_phy_syougai");
                info.DataKubun = grdPHY8004.GetItemString(i, "data_kubun");
                info.FkOcsIrai = grdPHY8004.GetItemString(i, "fk_ocs_irai");
                info.SyougaiId = grdPHY8004.GetItemString(i, "syougai_id");
                info.Syougaimei = grdPHY8004.GetItemString(i, "syougaimei");
                info.KanjaNo = grdPHY8004.GetItemString(i, "kanja_no");
                info.Fkcht0113 = grdPHY8004.GetItemString(i, "fkcht0113");
                info.RowState = grdPHY8004.GetRowState(i).ToString();
                dataList.Add(info);
            }
            if (grdPHY8004.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdPHY8004.DeletedRowTable.Rows)
                {
                    PHY8002U01GrdPHY8004LisItemInfo info = new PHY8002U01GrdPHY8004LisItemInfo();
                    info.SysDate = row["sys_date"].ToString();
                    info.UserId = row["user_id"].ToString();
                    info.UpdDate = row["upd_date"].ToString();
                    info.HospCode = row["hosp_code"].ToString();
                    info.PkPhySyougai = row["pk_phy_syougai"].ToString();
                    info.DataKubun = row["data_kubun"].ToString();
                    info.FkOcsIrai = row["fk_ocs_irai"].ToString();
                    info.SyougaiId = row["syougai_id"].ToString();
                    info.Syougaimei = row["syougaimei"].ToString();
                    info.KanjaNo = row["kanja_no"].ToString();
                    info.Fkcht0113 = row["fkcht0113"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
	    }

	    private List<PHY8002U01GrdPHY8003LisItemInfo> GetListFromGrd8003()
	    {
            List<PHY8002U01GrdPHY8003LisItemInfo> dataList = new List<PHY8002U01GrdPHY8003LisItemInfo>();
            for (int i = 0; i < grdPHY8003.RowCount; i++)
            {
                if (grdPHY8003.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                PHY8002U01GrdPHY8003LisItemInfo info = new PHY8002U01GrdPHY8003LisItemInfo();
                info.YsDate = grdPHY8003.GetItemString(i, "sys_date");
                info.UserId = grdPHY8003.GetItemString(i, "user_id");
                info.UpdDate = grdPHY8003.GetItemString(i, "upd_date");
                info.HospCode = grdPHY8003.GetItemString(i, "hosp_code");
                info.PkPhySyoubyou = grdPHY8003.GetItemString(i, "pk_phy_syoubyou");
                info.DataKubun = grdPHY8003.GetItemString(i, "data_kubun");
                info.FkOcsIrai = grdPHY8003.GetItemString(i, "fk_ocs_irai");
                info.IoKubun = grdPHY8003.GetItemString(i, "io_kubun");
                info.IraiDate = grdPHY8003.GetItemString(i, "irai_date");
                info.KanjaNo = grdPHY8003.GetItemString(i, "kanja_no");
                info.Sinryouka = grdPHY8003.GetItemString(i, "sinryouka");
                info.SyoubyoumeiCode = grdPHY8003.GetItemString(i, "syoubyoumei_code");
                info.ModifierName = grdPHY8003.GetItemString(i, "display_syoubyoumei");
                info.PreModifier1 = grdPHY8003.GetItemString(i, "pre_modifier1");
                info.PreModifier2 = grdPHY8003.GetItemString(i, "pre_modifier2");
                info.PreModifier3 = grdPHY8003.GetItemString(i, "pre_modifier3");
                info.PreModifier4 = grdPHY8003.GetItemString(i, "pre_modifier4");
                info.PreModifier5 = grdPHY8003.GetItemString(i, "pre_modifier5");
                info.PreModifier6 = grdPHY8003.GetItemString(i, "pre_modifier6");
                info.PreModifier7 = grdPHY8003.GetItemString(i, "pre_modifier7");
                info.PreModifier8 = grdPHY8003.GetItemString(i, "pre_modifier8");
                info.PreModifier9 = grdPHY8003.GetItemString(i, "pre_modifier9");
                info.PreModifier10 = grdPHY8003.GetItemString(i, "pre_modifier10");
                info.PostModifier1 = grdPHY8003.GetItemString(i, "post_modifier1");
                info.PostModifier2 = grdPHY8003.GetItemString(i, "post_modifier2");
                info.PostModifier3 = grdPHY8003.GetItemString(i, "post_modifier3");
                info.PostModifier4 = grdPHY8003.GetItemString(i, "post_modifier4");
                info.PostModifier5 = grdPHY8003.GetItemString(i, "post_modifier5");
                info.PostModifier6 = grdPHY8003.GetItemString(i, "post_modifier6");
                info.PostModifier7 = grdPHY8003.GetItemString(i, "post_modifier7");
                info.PostModifier8 = grdPHY8003.GetItemString(i, "post_modifier8");
                info.PostModifier9 = grdPHY8003.GetItemString(i, "post_modifier9");
                info.PostModifier10 = grdPHY8003.GetItemString(i, "post_modifier10");
                info.Hassyoubi = grdPHY8003.GetItemString(i, "hassyoubi");
                info.Sindanbi = grdPHY8003.GetItemString(i, "sindanbi");
                info.PreModifierName = grdPHY8003.GetItemString(i, "pre_modifier_name");
                info.PostModifierName = grdPHY8003.GetItemString(i, "post_modifier_name");
                info.Syoubyoumei = grdPHY8003.GetItemString(i, "syoubyoumei");
                info.Fkoutsang = grdPHY8003.GetItemString(i, "fkoutsang");
                info.RowState = grdPHY8003.GetRowState(i).ToString();
                dataList.Add(info);
            }
            if (grdPHY8003.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdPHY8003.DeletedRowTable.Rows)
                {
                    PHY8002U01GrdPHY8003LisItemInfo info = new PHY8002U01GrdPHY8003LisItemInfo();
                    info.YsDate = row["sys_date"].ToString();
                    info.UserId = row["user_id"].ToString();
                    info.UpdDate = row["upd_date"].ToString();
                    info.HospCode = row["hosp_code"].ToString();
                    info.PkPhySyoubyou = row["pk_phy_syoubyou"].ToString();
                    info.DataKubun = row["data_kubun"].ToString();
                    info.FkOcsIrai = row["fk_ocs_irai"].ToString();
                    info.IoKubun = row["io_kubun"].ToString();
                    info.IraiDate = row["irai_date"].ToString();
                    info.KanjaNo = row["kanja_no"].ToString();
                    info.Sinryouka = row["sinryouka"].ToString();
                    info.SyoubyoumeiCode = row["syoubyoumei_code"].ToString();
                    info.ModifierName = row["display_syoubyoumei"].ToString();
                    info.PreModifier1 = row["pre_modifier1"].ToString();
                    info.PreModifier2 = row["pre_modifier2"].ToString();
                    info.PreModifier3 = row["pre_modifier3"].ToString();
                    info.PreModifier4 = row["pre_modifier4"].ToString();
                    info.PreModifier5 = row["pre_modifier5"].ToString();
                    info.PreModifier6 = row["pre_modifier6"].ToString();
                    info.PreModifier7 = row["pre_modifier7"].ToString();
                    info.PreModifier8 = row["pre_modifier8"].ToString();
                    info.PreModifier9 = row["pre_modifier9"].ToString();
                    info.PreModifier10 = row["pre_modifier10"].ToString();
                    info.PostModifier1 = row["post_modifier1"].ToString();
                    info.PostModifier2 = row["post_modifier2"].ToString();
                    info.PostModifier3 = row["post_modifier3"].ToString();
                    info.PostModifier4 = row["post_modifier4"].ToString();
                    info.PostModifier5 = row["post_modifier5"].ToString();
                    info.PostModifier6 = row["post_modifier6"].ToString();
                    info.PostModifier7 = row["post_modifier7"].ToString();
                    info.PostModifier8 = row["post_modifier8"].ToString();
                    info.PostModifier9 = row["post_modifier9"].ToString();
                    info.PostModifier10 = row["post_modifier10"].ToString();
                    info.Hassyoubi = row["hassyoubi"].ToString();
                    info.Sindanbi = row["sindanbi"].ToString();
                    info.PreModifierName = row["pre_modifier_name"].ToString();
                    info.PostModifierName = row["post_modifier_name"].ToString();
                    info.Syoubyoumei = row["syoubyoumei"].ToString();
                    info.Fkoutsang = row["fkoutsang"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
	    }

	    private List<PHY8002U01GrdPHY8002LisItemInfo> GetListFromGrd8002()
	    {
            List<PHY8002U01GrdPHY8002LisItemInfo> dataList = new List<PHY8002U01GrdPHY8002LisItemInfo>();
            for (int i = 0; i < grdPHY8002.RowCount; i++)
            {
                PHY8002U01GrdPHY8002LisItemInfo info = new PHY8002U01GrdPHY8002LisItemInfo();
                info.SysDate = grdPHY8002.GetItemString(i, "sys_date");
                info.UserId = grdPHY8002.GetItemString(i, "user_id");
                info.UpdDate = grdPHY8002.GetItemString(i, "upd_date");
                info.HospCode = grdPHY8002.GetItemString(i, "hosp_code");
                info.Pkphy8002 = grdPHY8002.GetItemString(i, "pkphy8002");
                info.FkOcs = grdPHY8002.GetItemString(i, "fk_ocs");
                info.IoKubun = grdPHY8002.GetItemString(i, "io_kubun");
                info.IraiDate = grdPHY8002.GetItemString(i, "irai_date");
                info.KanjaNo = grdPHY8002.GetItemString(i, "kanja_no");
                info.Sinryouka = grdPHY8002.GetItemString(i, "sinryouka");
                info.Sindanisi = grdPHY8002.GetItemString(i, "sindanisi");
                info.Tantoui = grdPHY8002.GetItemString(i, "tantoui");
                info.Nyuuinnbi = grdPHY8002.GetItemString(i, "nyuuinnbi");
                info.ByousituCode = grdPHY8002.GetItemString(i, "byousitu_code");
                info.ByoutouCode = grdPHY8002.GetItemString(i, "byoutou_code");
                info.Kaisibi = grdPHY8002.GetItemString(i, "kaisibi");
                info.Nissuu = grdPHY8002.GetItemString(i, "nissuu");
                info.KoumokuCode = grdPHY8002.GetItemString(i, "koumoku_code");
                info.Pt1 = grdPHY8002.GetItemString(i, "pt1");
                info.Pt2 = grdPHY8002.GetItemString(i, "pt2");
                info.Pt3 = grdPHY8002.GetItemString(i, "pt3");
                info.Pt4 = grdPHY8002.GetItemString(i, "pt4");
                info.Pt5 = grdPHY8002.GetItemString(i, "pt5");
                info.Pt6 = grdPHY8002.GetItemString(i, "pt6");
                info.Pt7 = grdPHY8002.GetItemString(i, "pt7");
                info.Pt8 = grdPHY8002.GetItemString(i, "pt8");
                info.Pt9 = grdPHY8002.GetItemString(i, "pt9");
                info.Pt10 = grdPHY8002.GetItemString(i, "pt10");
                info.Ot1 = grdPHY8002.GetItemString(i, "ot1");
                info.Ot2 = grdPHY8002.GetItemString(i, "ot2");
                info.Ot3 = grdPHY8002.GetItemString(i, "ot3");
                info.Ot4 = grdPHY8002.GetItemString(i, "ot4");
                info.Ot5 = grdPHY8002.GetItemString(i, "ot5");
                info.Ot6 = grdPHY8002.GetItemString(i, "ot6");
                info.Ot7 = grdPHY8002.GetItemString(i, "ot7");
                info.Ot8 = grdPHY8002.GetItemString(i, "ot8");
                info.Ot9 = grdPHY8002.GetItemString(i, "ot9");
                info.Ot10 = grdPHY8002.GetItemString(i, "ot10");
                info.St1 = grdPHY8002.GetItemString(i, "st1");
                info.St2 = grdPHY8002.GetItemString(i, "st2");
                info.St3 = grdPHY8002.GetItemString(i, "st3");
                info.St4 = grdPHY8002.GetItemString(i, "st4");
                info.St5 = grdPHY8002.GetItemString(i, "st5");
                info.St6 = grdPHY8002.GetItemString(i, "st6");
                info.St7 = grdPHY8002.GetItemString(i, "st7");
                info.St8 = grdPHY8002.GetItemString(i, "st8");
                info.St9 = grdPHY8002.GetItemString(i, "st9");
                info.St10 = grdPHY8002.GetItemString(i, "st10");
                info.Objective = grdPHY8002.GetItemString(i, "objective");
                info.ConsultComment = grdPHY8002.GetItemString(i, "consult_comment");
                info.Genbyoureki = grdPHY8002.GetItemString(i, "genbyoureki");
                info.Complications = grdPHY8002.GetItemString(i, "complications");
                info.Taboo = grdPHY8002.GetItemString(i, "taboo");
                info.StopKijyun = grdPHY8002.GetItemString(i, "stop_kijyun");
                info.Frequency = grdPHY8002.GetItemString(i, "frequency");
                info.Infectious = grdPHY8002.GetItemString(i, "infectious");
                info.Kioureki = grdPHY8002.GetItemString(i, "kioureki");
                info.SyoriFlag = grdPHY8002.GetItemString(i, "syori_flag");
                info.PtFlag = grdPHY8002.GetItemString(i, "pt_flag");
                info.OtFlag = grdPHY8002.GetItemString(i, "ot_flag");
                info.StFlag = grdPHY8002.GetItemString(i, "st_flag");
                info.BuFlag = grdPHY8002.GetItemString(i, "bu_flag");
                info.Syujyutubi = grdPHY8002.GetItemString(i, "syujyutubi");
                info.Kyuseizouakubi = grdPHY8002.GetItemString(i, "kyuseizouakubi");
                info.DisuseGasyou = grdPHY8002.GetItemString(i, "disuse_gasyou");
                info.DisuseAdl = grdPHY8002.GetItemString(i, "disuse_adl");
                info.DisuseKainyu = grdPHY8002.GetItemString(i, "disuse_kainyu");
                info.DisuseKaizen = grdPHY8002.GetItemString(i, "disuse_kaizen");
                info.DisuseContents = grdPHY8002.GetItemString(i, "disuse_contents");
                info.IraiKubun = grdPHY8002.GetItemString(i, "irai_kubun");
                info.DisuseFimbi = grdPHY8002.GetItemString(i, "disuse_fimbi");
                info.YoinStartDate = grdPHY8002.GetItemString(i, "yoin_start_date");
                info.YoinSindanDate = grdPHY8002.GetItemString(i, "yoin_sindan_date");
                info.Su1 = grdPHY8002.GetItemString(i, "su_1");
                info.Su21 = grdPHY8002.GetItemString(i, "su_2_1");
                info.Su22 = grdPHY8002.GetItemString(i, "su_2_2");
                info.Su23 = grdPHY8002.GetItemString(i, "su_2_3");
                info.Su24 = grdPHY8002.GetItemString(i, "su_2_4");
                info.Su31 = grdPHY8002.GetItemString(i, "su_3_1");
                info.Su32 = grdPHY8002.GetItemString(i, "su_3_2");
                info.Su41 = grdPHY8002.GetItemString(i, "su_4_1");
                info.Su42 = grdPHY8002.GetItemString(i, "su_4_2");
                info.Su43 = grdPHY8002.GetItemString(i, "su_4_3");
                info.KeFlag = grdPHY8002.GetItemString(i, "ke_flag");
                info.Image = grdPHY8002.GetItemString(i, "image");
                info.ImagePath = grdPHY8002.GetItemString(i, "image_path");
                info.ImageSeq = grdPHY8002.GetItemString(i, "image_seq");
                info.CrTime = grdPHY8002.GetItemString(i, "cr_time");
                info.RowState = grdPHY8002.GetRowState(i).ToString();
                dataList.Add(info);
            }
            if (grdPHY8002.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdPHY8002.DeletedRowTable.Rows)
                {
                    PHY8002U01GrdPHY8002LisItemInfo info = new PHY8002U01GrdPHY8002LisItemInfo();
                    info.SysDate = row["sys_date"].ToString();
                    info.UserId = row["user_id"].ToString();
                    info.UpdDate = row["upd_date"].ToString();
                    info.HospCode = row["hosp_code"].ToString();
                    info.Pkphy8002 = row["pkphy8002"].ToString();
                    info.FkOcs = row["fk_ocs"].ToString();
                    info.IoKubun = row["io_kubun"].ToString();
                    info.IraiDate = row["irai_date"].ToString();
                    info.KanjaNo = row["kanja_no"].ToString();
                    info.Sinryouka = row["sinryouka"].ToString();
                    info.Sindanisi = row["sindanisi"].ToString();
                    info.Tantoui = row["tantoui"].ToString();
                    info.Nyuuinnbi = row["nyuuinnbi"].ToString();
                    info.ByousituCode = row["byousitu_code"].ToString();
                    info.ByoutouCode = row["byoutou_code"].ToString();
                    info.Kaisibi = row["kaisibi"].ToString();
                    info.Nissuu = row["nissuu"].ToString();
                    info.KoumokuCode = row["koumoku_code"].ToString();
                    info.Pt1 = row["pt1"].ToString();
                    info.Pt2 = row["pt2"].ToString();
                    info.Pt3 = row["pt3"].ToString();
                    info.Pt4 = row["pt4"].ToString();
                    info.Pt5 = row["pt5"].ToString();
                    info.Pt6 = row["pt6"].ToString();
                    info.Pt7 = row["pt7"].ToString();
                    info.Pt8 = row["pt8"].ToString();
                    info.Pt9 = row["pt9"].ToString();
                    info.Pt10 = row["pt10"].ToString();
                    info.Ot1 = row["ot1"].ToString();
                    info.Ot2 = row["ot2"].ToString();
                    info.Ot3 = row["ot3"].ToString();
                    info.Ot4 = row["ot4"].ToString();
                    info.Ot5 = row["ot5"].ToString();
                    info.Ot6 = row["ot6"].ToString();
                    info.Ot7 = row["ot7"].ToString();
                    info.Ot8 = row["ot8"].ToString();
                    info.Ot9 = row["ot9"].ToString();
                    info.Ot10 = row["ot10"].ToString();
                    info.St1 = row["st1"].ToString();
                    info.St2 = row["st2"].ToString();
                    info.St3 = row["st3"].ToString();
                    info.St4 = row["st4"].ToString();
                    info.St5 = row["st5"].ToString();
                    info.St6 = row["st6"].ToString();
                    info.St7 = row["st7"].ToString();
                    info.St8 = row["st8"].ToString();
                    info.St9 = row["st9"].ToString();
                    info.St10 = row["st10"].ToString();
                    info.Objective = row["objective"].ToString();
                    info.ConsultComment = row["consult_comment"].ToString();
                    info.Genbyoureki = row["genbyoureki"].ToString();
                    info.Complications = row["complications"].ToString();
                    info.Taboo = row["taboo"].ToString();
                    info.StopKijyun = row["stop_kijyun"].ToString();
                    info.Frequency = row["frequency"].ToString();
                    info.Infectious = row["infectious"].ToString();
                    info.Kioureki = row["kioureki"].ToString();
                    info.SyoriFlag = row["syori_flag"].ToString();
                    info.PtFlag = row["pt_flag"].ToString();
                    info.OtFlag = row["ot_flag"].ToString();
                    info.StFlag = row["st_flag"].ToString();
                    info.BuFlag = row["bu_flag"].ToString();
                    info.Syujyutubi = row["syujyutubi"].ToString();
                    info.Kyuseizouakubi = row["kyuseizouakubi"].ToString();
                    info.DisuseGasyou = row["disuse_gasyou"].ToString();
                    info.DisuseAdl = row["disuse_adl"].ToString();
                    info.DisuseKainyu = row["disuse_kainyu"].ToString();
                    info.DisuseKaizen = row["disuse_kaizen"].ToString();
                    info.DisuseContents = row["disuse_contents"].ToString();
                    info.IraiKubun = row["irai_kubun"].ToString();
                    info.DisuseFimbi = row["disuse_fimbi"].ToString();
                    info.YoinStartDate = row["yoin_start_date"].ToString();
                    info.YoinSindanDate = row["yoin_sindan_date"].ToString();
                    info.Su1 = row["su_1"].ToString();
                    info.Su21 = row["su_2_1"].ToString();
                    info.Su22 = row["su_2_2"].ToString();
                    info.Su23 = row["su_2_3"].ToString();
                    info.Su24 = row["su_2_4"].ToString();
                    info.Su31 = row["su_3_1"].ToString();
                    info.Su32 = row["su_3_2"].ToString();
                    info.Su41 = row["su_4_1"].ToString();
                    info.Su42 = row["su_4_2"].ToString();
                    info.Su43 = row["su_4_3"].ToString();
                    info.KeFlag = row["ke_flag"].ToString();
                    info.Image = row["image"].ToString();
                    info.ImagePath = row["image_path"].ToString();
                    info.ImageSeq = row["image_seq"].ToString();
                    info.CrTime = row["cr_time"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
	    }

	    #endregion




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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PHY8002U01));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.patBox = new IHIS.Framework.XPatientBox();
            this.lblGwa = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel7 = new IHIS.Framework.XFlatLabel();
            this.pnlCenter = new IHIS.Framework.XPanel();
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
            this.pnlTopInfo = new IHIS.Framework.XPanel();
            this.cbxSu_4_1 = new IHIS.Framework.XCheckBox();
            this.cbxSu_2_4_c = new IHIS.Framework.XCheckBox();
            this.cbxBU_FLAG = new IHIS.Framework.XCheckBox();
            this.cbxSu_2_3 = new IHIS.Framework.XCheckBox();
            this.cbxKE_FLAG = new IHIS.Framework.XCheckBox();
            this.cbxSu_2_2 = new IHIS.Framework.XCheckBox();
            this.rbtSu_3_1 = new IHIS.Framework.XFlatRadioButton();
            this.cbxSu_2_1 = new IHIS.Framework.XCheckBox();
            this.rbtSu_3_2 = new IHIS.Framework.XFlatRadioButton();
            this.xFlatLabel39 = new IHIS.Framework.XFlatLabel();
            this.txtKg = new IHIS.Framework.XTextBox();
            this.txtSu_2_4 = new IHIS.Framework.XTextBox();
            this.grbDisability = new IHIS.Framework.XGroupBox();
            this.grdPHY8004 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell168 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell169 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell171 = new IHIS.Framework.XEditGridCell();
            this.btnDisability = new IHIS.Framework.XButton();
            this.txtDisability = new IHIS.Framework.XTextBox();
            this.btnInfectious = new IHIS.Framework.XButton();
            this.gbxGenbyoureki = new IHIS.Framework.XGroupBox();
            this.txtYoin_sindan_date = new IHIS.Framework.XTextBox();
            this.txtYoin_start_date = new IHIS.Framework.XTextBox();
            this.txtGenbyoureki = new IHIS.Framework.XTextBox();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.btnGenbyoureki = new IHIS.Framework.XButton();
            this.btnFrequency = new IHIS.Framework.XButton();
            this.btnTaboo = new IHIS.Framework.XButton();
            this.btnStop_kijyun = new IHIS.Framework.XButton();
            this.lblNalsu = new IHIS.Framework.XLabel();
            this.cboNissuu = new IHIS.Framework.XComboBox();
            this.dtpKyuseizouakubi = new IHIS.Framework.XDatePicker();
            this.dtpSyujyutubi = new IHIS.Framework.XDatePicker();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dptKaisibi = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.gbxComplications = new IHIS.Framework.XGroupBox();
            this.btnComplications = new IHIS.Framework.XButton();
            this.txtComplications = new IHIS.Framework.XTextBox();
            this.gbxKioureki = new IHIS.Framework.XGroupBox();
            this.btnKioureki = new IHIS.Framework.XButton();
            this.txtKioureki = new IHIS.Framework.XTextBox();
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
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.txtInfectious = new IHIS.Framework.XTextBox();
            this.txtTaboo = new IHIS.Framework.XTextBox();
            this.txtStop_kijyun = new IHIS.Framework.XTextBox();
            this.txtFrequency = new IHIS.Framework.XTextBox();
            this.pnlRightUnderLeft = new IHIS.Framework.XPanel();
            this.btnObjective = new IHIS.Framework.XButton();
            this.btnJisi = new IHIS.Framework.XButton();
            this.xFlatLabel5 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel6 = new IHIS.Framework.XFlatLabel();
            this.txtObjective = new IHIS.Framework.XTextBox();
            this.txtConsult_comment = new IHIS.Framework.XTextBox();
            this.pnlDisUseObj = new IHIS.Framework.XPanel();
            this.gbxDisuse_Contents = new IHIS.Framework.XGroupBox();
            this.txtDisUse_Contents = new IHIS.Framework.XTextBox();
            this.gbxDisuse_Kaizen = new IHIS.Framework.XGroupBox();
            this.rbtKaizen_03 = new IHIS.Framework.XFlatRadioButton();
            this.rbtKaizen_05 = new IHIS.Framework.XFlatRadioButton();
            this.cboDisUse_Kaizen = new IHIS.Framework.XDictComboBox();
            this.rbtKaizen_02 = new IHIS.Framework.XFlatRadioButton();
            this.rbtKaizen_01 = new IHIS.Framework.XFlatRadioButton();
            this.rbtKaizen_04 = new IHIS.Framework.XFlatRadioButton();
            this.gbxDisuse_Kainyu = new IHIS.Framework.XGroupBox();
            this.rbtKainyu_03 = new IHIS.Framework.XFlatRadioButton();
            this.dwIraisyo = new IHIS.Framework.XDataWindow();
            this.rbtKainyu_05 = new IHIS.Framework.XFlatRadioButton();
            this.rbtKainyu_02 = new IHIS.Framework.XFlatRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtKainyu_04 = new IHIS.Framework.XFlatRadioButton();
            this.cboDisUse_Kainyu = new IHIS.Framework.XDictComboBox();
            this.rbtKainyu_01 = new IHIS.Framework.XFlatRadioButton();
            this.xFlatLabel9 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel10 = new IHIS.Framework.XFlatLabel();
            this.txtDisuse_FIMBI = new IHIS.Framework.XTextBox();
            this.gbxDisuse_ADL = new IHIS.Framework.XGroupBox();
            this.rbtBEFADL_03 = new IHIS.Framework.XFlatRadioButton();
            this.cboDisUse_ADL = new IHIS.Framework.XDictComboBox();
            this.rbtBEFADL_06 = new IHIS.Framework.XFlatRadioButton();
            this.rbtBEFADL_05 = new IHIS.Framework.XFlatRadioButton();
            this.rbtBEFADL_01 = new IHIS.Framework.XFlatRadioButton();
            this.rbtBEFADL_04 = new IHIS.Framework.XFlatRadioButton();
            this.rbtBEFADL_02 = new IHIS.Framework.XFlatRadioButton();
            this.gbxDisuse_Gasyou = new IHIS.Framework.XGroupBox();
            this.rbtGasyou_03 = new IHIS.Framework.XFlatRadioButton();
            this.rbtGasyou_05 = new IHIS.Framework.XFlatRadioButton();
            this.rbtGasyou_02 = new IHIS.Framework.XFlatRadioButton();
            this.rbtGasyou_04 = new IHIS.Framework.XFlatRadioButton();
            this.rbtGasyou_01 = new IHIS.Framework.XFlatRadioButton();
            this.cboDisUse_Gasyou = new IHIS.Framework.XDictComboBox();
            this.grdPHY8002 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnCopy = new IHIS.Framework.XButton();
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
            this.layIraisyo = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem178 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem179 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem180 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem181 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem182 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem183 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem184 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem185 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem186 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem187 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem188 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem189 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem190 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem191 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem192 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem193 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem194 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem195 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem196 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem197 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem198 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem237 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem238 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem239 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem242 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem243 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem252 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem253 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem254 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem255 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem256 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem257 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem258 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem259 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem262 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem263 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem264 = new IHIS.Framework.MultiLayoutItem();
            this.pnlCenterRight = new IHIS.Framework.XPanel();
            this.xPanel12 = new IHIS.Framework.XPanel();
            this.imageEditor = new IHIS.Framework.XImageEditor();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.btnReset = new IHIS.Framework.XButton();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.tabReha = new IHIS.Framework.XTabControl();
            this.tpgImage = new IHIS.X.Magic.Controls.TabPage();
            this.tpgFIM = new IHIS.X.Magic.Controls.TabPage();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patBox)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.pnlCenterLeft.SuspendLayout();
            this.pnlIrainaiyou.SuspendLayout();
            this.gbxST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdST)).BeginInit();
            this.gbxPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPT)).BeginInit();
            this.gbxOT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOT)).BeginInit();
            this.pnlTopInfo.SuspendLayout();
            this.grbDisability.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY8004)).BeginInit();
            this.gbxGenbyoureki.SuspendLayout();
            this.gbxComplications.SuspendLayout();
            this.gbxKioureki.SuspendLayout();
            this.gbxSindanmei.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY8003)).BeginInit();
            this.pnlRightUnderLeft.SuspendLayout();
            this.pnlDisUseObj.SuspendLayout();
            this.gbxDisuse_Contents.SuspendLayout();
            this.gbxDisuse_Kaizen.SuspendLayout();
            this.gbxDisuse_Kainyu.SuspendLayout();
            this.gbxDisuse_ADL.SuspendLayout();
            this.gbxDisuse_Gasyou.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY8002)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layIraisyo)).BeginInit();
            this.pnlCenterRight.SuspendLayout();
            this.xPanel12.SuspendLayout();
            this.xPanel9.SuspendLayout();
            this.tabReha.SuspendLayout();
            this.tpgImage.SuspendLayout();
            this.tpgFIM.SuspendLayout();
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
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Name = "pnlTop";
            // 
            // patBox
            // 
            this.patBox.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            resources.ApplyResources(this.patBox, "patBox");
            this.patBox.IsEditableBunho = false;
            this.patBox.Name = "patBox";
            // 
            // lblGwa
            // 
            this.lblGwa.ForeColor = IHIS.Framework.XColor.XMatrixLineColor;
            resources.ApplyResources(this.lblGwa, "lblGwa");
            this.lblGwa.Name = "lblGwa";
            // 
            // xFlatLabel7
            // 
            this.xFlatLabel7.ForeColor = IHIS.Framework.XColor.XMatrixLineColor;
            resources.ApplyResources(this.xFlatLabel7, "xFlatLabel7");
            this.xFlatLabel7.Name = "xFlatLabel7";
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlCenterLeft);
            this.pnlCenter.DrawBorder = true;
            resources.ApplyResources(this.pnlCenter, "pnlCenter");
            this.pnlCenter.Name = "pnlCenter";
            // 
            // pnlCenterLeft
            // 
            this.pnlCenterLeft.Controls.Add(this.pnlIrainaiyou);
            this.pnlCenterLeft.Controls.Add(this.pnlSukoumoku);
            this.pnlCenterLeft.Controls.Add(this.pnlTopInfo);
            resources.ApplyResources(this.pnlCenterLeft, "pnlCenterLeft");
            this.pnlCenterLeft.DrawBorder = true;
            this.pnlCenterLeft.Name = "pnlCenterLeft";
            // 
            // pnlIrainaiyou
            // 
            this.pnlIrainaiyou.Controls.Add(this.gbxST);
            this.pnlIrainaiyou.Controls.Add(this.gbxPT);
            this.pnlIrainaiyou.Controls.Add(this.gbxOT);
            resources.ApplyResources(this.pnlIrainaiyou, "pnlIrainaiyou");
            this.pnlIrainaiyou.Name = "pnlIrainaiyou";
            // 
            // gbxST
            // 
            this.gbxST.Controls.Add(this.cbxST_FLAG);
            this.gbxST.Controls.Add(this.grdST);
            resources.ApplyResources(this.gbxST, "gbxST");
            this.gbxST.Name = "gbxST";
            this.gbxST.Protect = true;
            this.gbxST.TabStop = false;
            // 
            // cbxST_FLAG
            // 
            resources.ApplyResources(this.cbxST_FLAG, "cbxST_FLAG");
            this.cbxST_FLAG.Name = "cbxST_FLAG";
            this.cbxST_FLAG.UseVisualStyleBackColor = false;
            this.cbxST_FLAG.CheckedChanged += new System.EventHandler(this.cbx_FLAG_CheckedChanged);
            // 
            // grdST
            // 
            this.grdST.ApplyPaintEventToAllColumn = true;
            this.grdST.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66});
            this.grdST.ColPerLine = 2;
            this.grdST.Cols = 2;
            resources.ApplyResources(this.grdST, "grdST");
            this.grdST.ExecuteQuery = null;
            this.grdST.FixedRows = 1;
            this.grdST.HeaderHeights.Add(21);
            this.grdST.Name = "grdST";
            this.grdST.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdST.ParamList")));
            this.grdST.QuerySQL = resources.GetString("grdST.QuerySQL");
            this.grdST.Rows = 2;
            this.grdST.RowStateCheckOnPaint = false;
            this.grdST.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdST.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdST.Click += new System.EventHandler(this.grd_Click);
            this.grdST.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdST.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grd_GridCellPainting);
            this.grdST.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdST_QueryStarting);
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "select";
            this.xEditGridCell64.CellWidth = 41;
            this.xEditGridCell64.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "code";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
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
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsUpdatable = false;
            // 
            // gbxPT
            // 
            this.gbxPT.Controls.Add(this.cbxPT_FLAG);
            this.gbxPT.Controls.Add(this.grdPT);
            resources.ApplyResources(this.gbxPT, "gbxPT");
            this.gbxPT.Name = "gbxPT";
            this.gbxPT.Protect = true;
            this.gbxPT.TabStop = false;
            // 
            // cbxPT_FLAG
            // 
            resources.ApplyResources(this.cbxPT_FLAG, "cbxPT_FLAG");
            this.cbxPT_FLAG.Name = "cbxPT_FLAG";
            this.cbxPT_FLAG.UseVisualStyleBackColor = false;
            this.cbxPT_FLAG.CheckedChanged += new System.EventHandler(this.cbx_FLAG_CheckedChanged);
            // 
            // grdPT
            // 
            this.grdPT.ApplyPaintEventToAllColumn = true;
            this.grdPT.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60});
            this.grdPT.ColPerLine = 2;
            this.grdPT.Cols = 2;
            resources.ApplyResources(this.grdPT, "grdPT");
            this.grdPT.ExecuteQuery = null;
            this.grdPT.FixedRows = 1;
            this.grdPT.HeaderHeights.Add(21);
            this.grdPT.Name = "grdPT";
            this.grdPT.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPT.ParamList")));
            this.grdPT.QuerySQL = resources.GetString("grdPT.QuerySQL");
            this.grdPT.Rows = 2;
            this.grdPT.RowStateCheckOnPaint = false;
            this.grdPT.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdPT.Click += new System.EventHandler(this.grd_Click);
            this.grdPT.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdPT.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grd_GridCellPainting);
            this.grdPT.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPT_QueryStarting);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "select";
            this.xEditGridCell58.CellWidth = 41;
            this.xEditGridCell58.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "code";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
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
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsUpdatable = false;
            // 
            // gbxOT
            // 
            this.gbxOT.Controls.Add(this.cbxOT_FLAG);
            this.gbxOT.Controls.Add(this.grdOT);
            resources.ApplyResources(this.gbxOT, "gbxOT");
            this.gbxOT.Name = "gbxOT";
            this.gbxOT.Protect = true;
            this.gbxOT.TabStop = false;
            // 
            // cbxOT_FLAG
            // 
            resources.ApplyResources(this.cbxOT_FLAG, "cbxOT_FLAG");
            this.cbxOT_FLAG.Name = "cbxOT_FLAG";
            this.cbxOT_FLAG.UseVisualStyleBackColor = false;
            this.cbxOT_FLAG.CheckedChanged += new System.EventHandler(this.cbx_FLAG_CheckedChanged);
            // 
            // grdOT
            // 
            this.grdOT.ApplyPaintEventToAllColumn = true;
            this.grdOT.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63});
            this.grdOT.ColPerLine = 2;
            this.grdOT.Cols = 2;
            resources.ApplyResources(this.grdOT, "grdOT");
            this.grdOT.ExecuteQuery = null;
            this.grdOT.FixedRows = 1;
            this.grdOT.HeaderHeights.Add(21);
            this.grdOT.Name = "grdOT";
            this.grdOT.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOT.ParamList")));
            this.grdOT.QuerySQL = resources.GetString("grdOT.QuerySQL");
            this.grdOT.Rows = 2;
            this.grdOT.RowStateCheckOnPaint = false;
            this.grdOT.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdOT.Click += new System.EventHandler(this.grd_Click);
            this.grdOT.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdOT.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grd_GridCellPainting);
            this.grdOT.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOT_QueryStarting);
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "select";
            this.xEditGridCell61.CellWidth = 41;
            this.xEditGridCell61.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "code";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
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
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsUpdatable = false;
            // 
            // pnlSukoumoku
            // 
            resources.ApplyResources(this.pnlSukoumoku, "pnlSukoumoku");
            this.pnlSukoumoku.Name = "pnlSukoumoku";
            // 
            // pnlTopInfo
            // 
            this.pnlTopInfo.Controls.Add(this.cbxSu_4_1);
            this.pnlTopInfo.Controls.Add(this.cbxSu_2_4_c);
            this.pnlTopInfo.Controls.Add(this.cbxBU_FLAG);
            this.pnlTopInfo.Controls.Add(this.cbxSu_2_3);
            this.pnlTopInfo.Controls.Add(this.cbxKE_FLAG);
            this.pnlTopInfo.Controls.Add(this.cbxSu_2_2);
            this.pnlTopInfo.Controls.Add(this.rbtSu_3_1);
            this.pnlTopInfo.Controls.Add(this.cbxSu_2_1);
            this.pnlTopInfo.Controls.Add(this.rbtSu_3_2);
            this.pnlTopInfo.Controls.Add(this.xFlatLabel39);
            this.pnlTopInfo.Controls.Add(this.txtKg);
            this.pnlTopInfo.Controls.Add(this.txtSu_2_4);
            this.pnlTopInfo.Controls.Add(this.grbDisability);
            this.pnlTopInfo.Controls.Add(this.btnInfectious);
            this.pnlTopInfo.Controls.Add(this.gbxGenbyoureki);
            this.pnlTopInfo.Controls.Add(this.btnFrequency);
            this.pnlTopInfo.Controls.Add(this.btnTaboo);
            this.pnlTopInfo.Controls.Add(this.btnStop_kijyun);
            this.pnlTopInfo.Controls.Add(this.lblNalsu);
            this.pnlTopInfo.Controls.Add(this.cboNissuu);
            this.pnlTopInfo.Controls.Add(this.dtpKyuseizouakubi);
            this.pnlTopInfo.Controls.Add(this.dtpSyujyutubi);
            this.pnlTopInfo.Controls.Add(this.xLabel3);
            this.pnlTopInfo.Controls.Add(this.dptKaisibi);
            this.pnlTopInfo.Controls.Add(this.xLabel2);
            this.pnlTopInfo.Controls.Add(this.xLabel1);
            this.pnlTopInfo.Controls.Add(this.gbxComplications);
            this.pnlTopInfo.Controls.Add(this.gbxKioureki);
            this.pnlTopInfo.Controls.Add(this.gbxSindanmei);
            this.pnlTopInfo.Controls.Add(this.txtInfectious);
            this.pnlTopInfo.Controls.Add(this.txtTaboo);
            this.pnlTopInfo.Controls.Add(this.txtStop_kijyun);
            this.pnlTopInfo.Controls.Add(this.txtFrequency);
            resources.ApplyResources(this.pnlTopInfo, "pnlTopInfo");
            this.pnlTopInfo.Name = "pnlTopInfo";
            // 
            // cbxSu_4_1
            // 
            resources.ApplyResources(this.cbxSu_4_1, "cbxSu_4_1");
            this.cbxSu_4_1.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.cbxSu_4_1.Name = "cbxSu_4_1";
            this.cbxSu_4_1.UseVisualStyleBackColor = false;
            this.cbxSu_4_1.CheckedChanged += new System.EventHandler(this.cbxSu_4_1_CheckedChanged);
            // 
            // cbxSu_2_4_c
            // 
            resources.ApplyResources(this.cbxSu_2_4_c, "cbxSu_2_4_c");
            this.cbxSu_2_4_c.Name = "cbxSu_2_4_c";
            this.cbxSu_2_4_c.UseVisualStyleBackColor = false;
            this.cbxSu_2_4_c.CheckedChanged += new System.EventHandler(this.cbxSu_CheckedChanged);
            // 
            // cbxBU_FLAG
            // 
            resources.ApplyResources(this.cbxBU_FLAG, "cbxBU_FLAG");
            this.cbxBU_FLAG.Name = "cbxBU_FLAG";
            this.cbxBU_FLAG.UseVisualStyleBackColor = false;
            this.cbxBU_FLAG.CheckedChanged += new System.EventHandler(this.cbxBU_FLAG_CheckedChanged);
            // 
            // cbxSu_2_3
            // 
            resources.ApplyResources(this.cbxSu_2_3, "cbxSu_2_3");
            this.cbxSu_2_3.Name = "cbxSu_2_3";
            this.cbxSu_2_3.UseVisualStyleBackColor = false;
            this.cbxSu_2_3.CheckedChanged += new System.EventHandler(this.cbxSu_CheckedChanged);
            // 
            // cbxKE_FLAG
            // 
            resources.ApplyResources(this.cbxKE_FLAG, "cbxKE_FLAG");
            this.cbxKE_FLAG.Name = "cbxKE_FLAG";
            this.cbxKE_FLAG.UseVisualStyleBackColor = false;
            this.cbxKE_FLAG.CheckedChanged += new System.EventHandler(this.cbxKE_FLAG_CheckedChanged);
            // 
            // cbxSu_2_2
            // 
            resources.ApplyResources(this.cbxSu_2_2, "cbxSu_2_2");
            this.cbxSu_2_2.Name = "cbxSu_2_2";
            this.cbxSu_2_2.UseVisualStyleBackColor = false;
            this.cbxSu_2_2.CheckedChanged += new System.EventHandler(this.cbxSu_CheckedChanged);
            // 
            // rbtSu_3_1
            // 
            resources.ApplyResources(this.rbtSu_3_1, "rbtSu_3_1");
            this.rbtSu_3_1.Name = "rbtSu_3_1";
            this.rbtSu_3_1.UseVisualStyleBackColor = true;
            this.rbtSu_3_1.CheckedChanged += new System.EventHandler(this.rbtSu_3_1_CheckedChanged);
            // 
            // cbxSu_2_1
            // 
            resources.ApplyResources(this.cbxSu_2_1, "cbxSu_2_1");
            this.cbxSu_2_1.Name = "cbxSu_2_1";
            this.cbxSu_2_1.UseVisualStyleBackColor = false;
            this.cbxSu_2_1.CheckedChanged += new System.EventHandler(this.cbxSu_CheckedChanged);
            // 
            // rbtSu_3_2
            // 
            resources.ApplyResources(this.rbtSu_3_2, "rbtSu_3_2");
            this.rbtSu_3_2.Name = "rbtSu_3_2";
            this.rbtSu_3_2.UseVisualStyleBackColor = true;
            this.rbtSu_3_2.CheckedChanged += new System.EventHandler(this.rbtSu_3_1_CheckedChanged);
            // 
            // xFlatLabel39
            // 
            resources.ApplyResources(this.xFlatLabel39, "xFlatLabel39");
            this.xFlatLabel39.Name = "xFlatLabel39";
            // 
            // txtKg
            // 
            resources.ApplyResources(this.txtKg, "txtKg");
            this.txtKg.Name = "txtKg";
            this.txtKg.Validating += new System.ComponentModel.CancelEventHandler(this.txtKg_Validating);
            this.txtKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBoInt_KeyPress);
            // 
            // txtSu_2_4
            // 
            resources.ApplyResources(this.txtSu_2_4, "txtSu_2_4");
            this.txtSu_2_4.Name = "txtSu_2_4";
            this.txtSu_2_4.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // grbDisability
            // 
            this.grbDisability.Controls.Add(this.grdPHY8004);
            this.grbDisability.Controls.Add(this.btnDisability);
            this.grbDisability.Controls.Add(this.txtDisability);
            resources.ApplyResources(this.grbDisability, "grbDisability");
            this.grbDisability.Name = "grbDisability";
            this.grbDisability.Protect = true;
            this.grbDisability.TabStop = false;
            // 
            // grdPHY8004
            // 
            this.grdPHY8004.CallerID = '3';
            this.grdPHY8004.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell116,
            this.xEditGridCell152,
            this.xEditGridCell153,
            this.xEditGridCell155,
            this.xEditGridCell166,
            this.xEditGridCell167,
            this.xEditGridCell168,
            this.xEditGridCell169,
            this.xEditGridCell170,
            this.xEditGridCell154,
            this.xEditGridCell171});
            this.grdPHY8004.ColPerLine = 2;
            this.grdPHY8004.Cols = 2;
            resources.ApplyResources(this.grdPHY8004, "grdPHY8004");
            this.grdPHY8004.ExecuteQuery = null;
            this.grdPHY8004.FixedRows = 1;
            this.grdPHY8004.HeaderHeights.Add(16);
            this.grdPHY8004.Name = "grdPHY8004";
            this.grdPHY8004.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPHY8004.ParamList")));
            this.grdPHY8004.QuerySQL = resources.GetString("grdPHY8004.QuerySQL");
            this.grdPHY8004.Rows = 2;
            this.grdPHY8004.RowStateCheckOnPaint = false;
            this.grdPHY8004.Click += new System.EventHandler(this.grd_Click);
            this.grdPHY8004.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdPHY8004.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPHY8004_QueryStarting);
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "sys_date";
            this.xEditGridCell116.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsReadOnly = true;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "user_id";
            this.xEditGridCell152.Col = -1;
            this.xEditGridCell152.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell152, "xEditGridCell152");
            this.xEditGridCell152.IsReadOnly = true;
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "upd_date";
            this.xEditGridCell153.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell153.Col = -1;
            this.xEditGridCell153.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell153, "xEditGridCell153");
            this.xEditGridCell153.IsReadOnly = true;
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "hosp_code";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell155, "xEditGridCell155");
            this.xEditGridCell155.IsReadOnly = true;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellName = "pk_phy_syougai";
            this.xEditGridCell166.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell166.Col = -1;
            this.xEditGridCell166.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell166, "xEditGridCell166");
            this.xEditGridCell166.IsReadOnly = true;
            this.xEditGridCell166.IsVisible = false;
            this.xEditGridCell166.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "data_kubun";
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell167, "xEditGridCell167");
            this.xEditGridCell167.IsReadOnly = true;
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellName = "fk_ocs_irai";
            this.xEditGridCell168.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell168.Col = -1;
            this.xEditGridCell168.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell168, "xEditGridCell168");
            this.xEditGridCell168.IsReadOnly = true;
            this.xEditGridCell168.IsVisible = false;
            this.xEditGridCell168.Row = -1;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellLen = 4;
            this.xEditGridCell169.CellName = "syougai_id";
            this.xEditGridCell169.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell169, "xEditGridCell169");
            this.xEditGridCell169.IsReadOnly = true;
            this.xEditGridCell169.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellLen = 50;
            this.xEditGridCell170.CellName = "syougaimei";
            this.xEditGridCell170.CellWidth = 179;
            this.xEditGridCell170.Col = 1;
            this.xEditGridCell170.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell170, "xEditGridCell170");
            this.xEditGridCell170.IsReadOnly = true;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellName = "kanja_no";
            this.xEditGridCell154.Col = -1;
            this.xEditGridCell154.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell154, "xEditGridCell154");
            this.xEditGridCell154.IsReadOnly = true;
            this.xEditGridCell154.IsVisible = false;
            this.xEditGridCell154.Row = -1;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellName = "fkcht0113";
            this.xEditGridCell171.Col = -1;
            this.xEditGridCell171.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell171, "xEditGridCell171");
            this.xEditGridCell171.IsReadOnly = true;
            this.xEditGridCell171.IsVisible = false;
            this.xEditGridCell171.Row = -1;
            // 
            // btnDisability
            // 
            resources.ApplyResources(this.btnDisability, "btnDisability");
            this.btnDisability.Name = "btnDisability";
            this.btnDisability.Click += new System.EventHandler(this.btnDisability_Click);
            // 
            // txtDisability
            // 
            resources.ApplyResources(this.txtDisability, "txtDisability");
            this.txtDisability.Name = "txtDisability";
            // 
            // btnInfectious
            // 
            resources.ApplyResources(this.btnInfectious, "btnInfectious");
            this.btnInfectious.Name = "btnInfectious";
            this.btnInfectious.Tag = "I";
            this.btnInfectious.Click += new System.EventHandler(this.btnInfectious_Click);
            // 
            // gbxGenbyoureki
            // 
            this.gbxGenbyoureki.Controls.Add(this.txtYoin_sindan_date);
            this.gbxGenbyoureki.Controls.Add(this.txtYoin_start_date);
            this.gbxGenbyoureki.Controls.Add(this.txtGenbyoureki);
            this.gbxGenbyoureki.Controls.Add(this.xFlatLabel3);
            this.gbxGenbyoureki.Controls.Add(this.xFlatLabel2);
            this.gbxGenbyoureki.Controls.Add(this.xFlatLabel1);
            this.gbxGenbyoureki.Controls.Add(this.btnGenbyoureki);
            resources.ApplyResources(this.gbxGenbyoureki, "gbxGenbyoureki");
            this.gbxGenbyoureki.Name = "gbxGenbyoureki";
            this.gbxGenbyoureki.Protect = true;
            this.gbxGenbyoureki.TabStop = false;
            // 
            // txtYoin_sindan_date
            // 
            resources.ApplyResources(this.txtYoin_sindan_date, "txtYoin_sindan_date");
            this.txtYoin_sindan_date.Name = "txtYoin_sindan_date";
            // 
            // txtYoin_start_date
            // 
            resources.ApplyResources(this.txtYoin_start_date, "txtYoin_start_date");
            this.txtYoin_start_date.Name = "txtYoin_start_date";
            // 
            // txtGenbyoureki
            // 
            resources.ApplyResources(this.txtGenbyoureki, "txtGenbyoureki");
            this.txtGenbyoureki.Name = "txtGenbyoureki";
            // 
            // xFlatLabel3
            // 
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.Name = "xFlatLabel3";
            this.xFlatLabel3.Click += new System.EventHandler(this.xFlatLabel2_Click);
            // 
            // xFlatLabel2
            // 
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.Name = "xFlatLabel2";
            this.xFlatLabel2.Click += new System.EventHandler(this.xFlatLabel2_Click);
            // 
            // xFlatLabel1
            // 
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // btnGenbyoureki
            // 
            resources.ApplyResources(this.btnGenbyoureki, "btnGenbyoureki");
            this.btnGenbyoureki.Name = "btnGenbyoureki";
            this.btnGenbyoureki.Tag = "G";
            this.btnGenbyoureki.Click += new System.EventHandler(this.bntOUSANG_Click);
            // 
            // btnFrequency
            // 
            resources.ApplyResources(this.btnFrequency, "btnFrequency");
            this.btnFrequency.Name = "btnFrequency";
            this.btnFrequency.Tag = "12";
            this.btnFrequency.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnTaboo
            // 
            resources.ApplyResources(this.btnTaboo, "btnTaboo");
            this.btnTaboo.Name = "btnTaboo";
            this.btnTaboo.Tag = "10";
            this.btnTaboo.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnStop_kijyun
            // 
            resources.ApplyResources(this.btnStop_kijyun, "btnStop_kijyun");
            this.btnStop_kijyun.Name = "btnStop_kijyun";
            this.btnStop_kijyun.Tag = "11";
            this.btnStop_kijyun.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // lblNalsu
            // 
            this.lblNalsu.EdgeRounding = false;
            resources.ApplyResources(this.lblNalsu, "lblNalsu");
            this.lblNalsu.Name = "lblNalsu";
            // 
            // cboNissuu
            // 
            this.cboNissuu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            resources.ApplyResources(this.cboNissuu, "cboNissuu");
            this.cboNissuu.Name = "cboNissuu";
            // 
            // dtpKyuseizouakubi
            // 
            this.dtpKyuseizouakubi.IsJapanYearType = true;
            resources.ApplyResources(this.dtpKyuseizouakubi, "dtpKyuseizouakubi");
            this.dtpKyuseizouakubi.Name = "dtpKyuseizouakubi";
            this.dtpKyuseizouakubi.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dptKaisibi_DataValidating);
            // 
            // dtpSyujyutubi
            // 
            this.dtpSyujyutubi.IsJapanYearType = true;
            resources.ApplyResources(this.dtpSyujyutubi, "dtpSyujyutubi");
            this.dtpSyujyutubi.Name = "dtpSyujyutubi";
            this.dtpSyujyutubi.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dptKaisibi_DataValidating);
            // 
            // xLabel3
            // 
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // dptKaisibi
            // 
            this.dptKaisibi.IsJapanYearType = true;
            resources.ApplyResources(this.dptKaisibi, "dptKaisibi");
            this.dptKaisibi.Name = "dptKaisibi";
            this.dptKaisibi.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dptKaisibi_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // gbxComplications
            // 
            this.gbxComplications.Controls.Add(this.btnComplications);
            this.gbxComplications.Controls.Add(this.txtComplications);
            resources.ApplyResources(this.gbxComplications, "gbxComplications");
            this.gbxComplications.Name = "gbxComplications";
            this.gbxComplications.Protect = true;
            this.gbxComplications.TabStop = false;
            // 
            // btnComplications
            // 
            resources.ApplyResources(this.btnComplications, "btnComplications");
            this.btnComplications.Name = "btnComplications";
            this.btnComplications.Tag = "C";
            this.btnComplications.Click += new System.EventHandler(this.bntOUSANG_Click);
            // 
            // txtComplications
            // 
            resources.ApplyResources(this.txtComplications, "txtComplications");
            this.txtComplications.Name = "txtComplications";
            this.txtComplications.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // gbxKioureki
            // 
            this.gbxKioureki.Controls.Add(this.btnKioureki);
            this.gbxKioureki.Controls.Add(this.txtKioureki);
            resources.ApplyResources(this.gbxKioureki, "gbxKioureki");
            this.gbxKioureki.Name = "gbxKioureki";
            this.gbxKioureki.Protect = true;
            this.gbxKioureki.TabStop = false;
            // 
            // btnKioureki
            // 
            resources.ApplyResources(this.btnKioureki, "btnKioureki");
            this.btnKioureki.Name = "btnKioureki";
            this.btnKioureki.Tag = "K";
            this.btnKioureki.Click += new System.EventHandler(this.bntOUSANG_Click);
            // 
            // txtKioureki
            // 
            resources.ApplyResources(this.txtKioureki, "txtKioureki");
            this.txtKioureki.Name = "txtKioureki";
            this.txtKioureki.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // gbxSindanmei
            // 
            this.gbxSindanmei.Controls.Add(this.btnSindanmei);
            this.gbxSindanmei.Controls.Add(this.grdPHY8003);
            resources.ApplyResources(this.gbxSindanmei, "gbxSindanmei");
            this.gbxSindanmei.Name = "gbxSindanmei";
            this.gbxSindanmei.Protect = true;
            this.gbxSindanmei.TabStop = false;
            // 
            // btnSindanmei
            // 
            resources.ApplyResources(this.btnSindanmei, "btnSindanmei");
            this.btnSindanmei.Name = "btnSindanmei";
            this.btnSindanmei.Tag = "S";
            this.btnSindanmei.Click += new System.EventHandler(this.bntOUSANG_Click);
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
            this.xEditGridCell147,
            this.xEditGridCell23});
            this.grdPHY8003.ColPerLine = 4;
            this.grdPHY8003.Cols = 4;
            resources.ApplyResources(this.grdPHY8003, "grdPHY8003");
            this.grdPHY8003.ExecuteQuery = null;
            this.grdPHY8003.FixedRows = 1;
            this.grdPHY8003.HeaderHeights.Add(21);
            this.grdPHY8003.Name = "grdPHY8003";
            this.grdPHY8003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPHY8003.ParamList")));
            this.grdPHY8003.QuerySQL = resources.GetString("grdPHY8003.QuerySQL");
            this.grdPHY8003.Rows = 2;
            this.grdPHY8003.RowStateCheckOnPaint = false;
            this.grdPHY8003.Click += new System.EventHandler(this.grd_Click);
            this.grdPHY8003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdPHY8003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdIFS8003_QueryStarting);
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "sys_date";
            this.xEditGridCell110.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
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
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
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
            this.xEditGridCell112.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsReadOnly = true;
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "hosp_code";
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsReadOnly = true;
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "pk_phy_syoubyou";
            this.xEditGridCell114.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsReadOnly = true;
            this.xEditGridCell114.IsUpdatable = false;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellName = "data_kubun";
            this.xEditGridCell150.Col = -1;
            this.xEditGridCell150.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell150, "xEditGridCell150");
            this.xEditGridCell150.IsVisible = false;
            this.xEditGridCell150.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "fk_ocs_irai";
            this.xEditGridCell115.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsReadOnly = true;
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellLen = 1;
            this.xEditGridCell117.CellName = "io_kubun";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsReadOnly = true;
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellLen = 8;
            this.xEditGridCell118.CellName = "irai_date";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsReadOnly = true;
            this.xEditGridCell118.IsUpdatable = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "kanja_no";
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.IsUpdatable = false;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellLen = 2;
            this.xEditGridCell120.CellName = "sinryouka";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsReadOnly = true;
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellLen = 7;
            this.xEditGridCell121.CellName = "syoubyoumei_code";
            this.xEditGridCell121.Col = 3;
            this.xEditGridCell121.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsReadOnly = true;
            this.xEditGridCell121.IsUpdatable = false;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellLen = 200;
            this.xEditGridCell125.CellName = "display_syoubyoumei";
            this.xEditGridCell125.CellWidth = 220;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsReadOnly = true;
            this.xEditGridCell125.IsUpdatable = false;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "pre_modifier1";
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsReadOnly = true;
            this.xEditGridCell126.IsUpdatable = false;
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "pre_modifier2";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsReadOnly = true;
            this.xEditGridCell127.IsUpdatable = false;
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "pre_modifier3";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsReadOnly = true;
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "pre_modifier4";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsReadOnly = true;
            this.xEditGridCell129.IsUpdatable = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "pre_modifier5";
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.IsReadOnly = true;
            this.xEditGridCell130.IsUpdatable = false;
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "pre_modifier6";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsReadOnly = true;
            this.xEditGridCell131.IsUpdatable = false;
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "pre_modifier7";
            this.xEditGridCell132.Col = -1;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsReadOnly = true;
            this.xEditGridCell132.IsUpdatable = false;
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "pre_modifier8";
            this.xEditGridCell133.Col = -1;
            this.xEditGridCell133.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsReadOnly = true;
            this.xEditGridCell133.IsUpdatable = false;
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "pre_modifier9";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsReadOnly = true;
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "pre_modifier10";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            this.xEditGridCell135.IsReadOnly = true;
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "post_modifier1";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsReadOnly = true;
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "post_modifier2";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsReadOnly = true;
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "post_modifier3";
            this.xEditGridCell138.Col = -1;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsReadOnly = true;
            this.xEditGridCell138.IsUpdatable = false;
            this.xEditGridCell138.IsVisible = false;
            this.xEditGridCell138.Row = -1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "post_modifier4";
            this.xEditGridCell139.Col = -1;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.IsReadOnly = true;
            this.xEditGridCell139.IsUpdatable = false;
            this.xEditGridCell139.IsVisible = false;
            this.xEditGridCell139.Row = -1;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "post_modifier5";
            this.xEditGridCell140.Col = -1;
            this.xEditGridCell140.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsReadOnly = true;
            this.xEditGridCell140.IsUpdatable = false;
            this.xEditGridCell140.IsVisible = false;
            this.xEditGridCell140.Row = -1;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "post_modifier6";
            this.xEditGridCell141.Col = -1;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsReadOnly = true;
            this.xEditGridCell141.IsUpdatable = false;
            this.xEditGridCell141.IsVisible = false;
            this.xEditGridCell141.Row = -1;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "post_modifier7";
            this.xEditGridCell142.Col = -1;
            this.xEditGridCell142.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsReadOnly = true;
            this.xEditGridCell142.IsUpdatable = false;
            this.xEditGridCell142.IsVisible = false;
            this.xEditGridCell142.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "post_modifier8";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsReadOnly = true;
            this.xEditGridCell143.IsUpdatable = false;
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "post_modifier9";
            this.xEditGridCell144.Col = -1;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsReadOnly = true;
            this.xEditGridCell144.IsUpdatable = false;
            this.xEditGridCell144.IsVisible = false;
            this.xEditGridCell144.Row = -1;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "post_modifier10";
            this.xEditGridCell145.Col = -1;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsReadOnly = true;
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.IsVisible = false;
            this.xEditGridCell145.Row = -1;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellLen = 8;
            this.xEditGridCell122.CellName = "hassyoubi";
            this.xEditGridCell122.Col = 1;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsReadOnly = true;
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.Mask = "####/##/##";
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellLen = 8;
            this.xEditGridCell123.CellName = "sindanbi";
            this.xEditGridCell123.Col = 2;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsReadOnly = true;
            this.xEditGridCell123.IsUpdatable = false;
            this.xEditGridCell123.Mask = "####/##/##";
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "pre_modifier_name";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsReadOnly = true;
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "post_modifier_name";
            this.xEditGridCell146.Col = -1;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsReadOnly = true;
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.IsVisible = false;
            this.xEditGridCell146.Row = -1;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "syoubyoumei";
            this.xEditGridCell147.Col = -1;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsReadOnly = true;
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.IsVisible = false;
            this.xEditGridCell147.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "fkoutsang";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // txtInfectious
            // 
            resources.ApplyResources(this.txtInfectious, "txtInfectious");
            this.txtInfectious.Name = "txtInfectious";
            this.txtInfectious.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // txtTaboo
            // 
            resources.ApplyResources(this.txtTaboo, "txtTaboo");
            this.txtTaboo.Name = "txtTaboo";
            this.txtTaboo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // txtStop_kijyun
            // 
            resources.ApplyResources(this.txtStop_kijyun, "txtStop_kijyun");
            this.txtStop_kijyun.Name = "txtStop_kijyun";
            this.txtStop_kijyun.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // txtFrequency
            // 
            resources.ApplyResources(this.txtFrequency, "txtFrequency");
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // pnlRightUnderLeft
            // 
            this.pnlRightUnderLeft.Controls.Add(this.btnObjective);
            this.pnlRightUnderLeft.Controls.Add(this.btnJisi);
            this.pnlRightUnderLeft.Controls.Add(this.xFlatLabel5);
            this.pnlRightUnderLeft.Controls.Add(this.xFlatLabel6);
            this.pnlRightUnderLeft.Controls.Add(this.txtObjective);
            this.pnlRightUnderLeft.Controls.Add(this.txtConsult_comment);
            resources.ApplyResources(this.pnlRightUnderLeft, "pnlRightUnderLeft");
            this.pnlRightUnderLeft.Name = "pnlRightUnderLeft";
            // 
            // btnObjective
            // 
            resources.ApplyResources(this.btnObjective, "btnObjective");
            this.btnObjective.Name = "btnObjective";
            this.btnObjective.Tag = "14";
            this.btnObjective.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnJisi
            // 
            resources.ApplyResources(this.btnJisi, "btnJisi");
            this.btnJisi.Name = "btnJisi";
            this.btnJisi.Tag = "13";
            this.btnJisi.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // xFlatLabel5
            // 
            this.xFlatLabel5.ForeColor = IHIS.Framework.XColor.XMatrixLineColor;
            resources.ApplyResources(this.xFlatLabel5, "xFlatLabel5");
            this.xFlatLabel5.Name = "xFlatLabel5";
            // 
            // xFlatLabel6
            // 
            this.xFlatLabel6.ForeColor = IHIS.Framework.XColor.XMatrixLineColor;
            resources.ApplyResources(this.xFlatLabel6, "xFlatLabel6");
            this.xFlatLabel6.Name = "xFlatLabel6";
            this.xFlatLabel6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xFlatLabel6_MouseDown);
            // 
            // txtObjective
            // 
            resources.ApplyResources(this.txtObjective, "txtObjective");
            this.txtObjective.Name = "txtObjective";
            this.txtObjective.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // txtConsult_comment
            // 
            resources.ApplyResources(this.txtConsult_comment, "txtConsult_comment");
            this.txtConsult_comment.Name = "txtConsult_comment";
            this.txtConsult_comment.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // pnlDisUseObj
            // 
            this.pnlDisUseObj.Controls.Add(this.gbxDisuse_Contents);
            this.pnlDisUseObj.Controls.Add(this.gbxDisuse_Kaizen);
            this.pnlDisUseObj.Controls.Add(this.gbxDisuse_Kainyu);
            this.pnlDisUseObj.Controls.Add(this.gbxDisuse_ADL);
            this.pnlDisUseObj.Controls.Add(this.gbxDisuse_Gasyou);
            resources.ApplyResources(this.pnlDisUseObj, "pnlDisUseObj");
            this.pnlDisUseObj.Name = "pnlDisUseObj";
            // 
            // gbxDisuse_Contents
            // 
            this.gbxDisuse_Contents.Controls.Add(this.txtDisUse_Contents);
            resources.ApplyResources(this.gbxDisuse_Contents, "gbxDisuse_Contents");
            this.gbxDisuse_Contents.Name = "gbxDisuse_Contents";
            this.gbxDisuse_Contents.Protect = true;
            this.gbxDisuse_Contents.TabStop = false;
            // 
            // txtDisUse_Contents
            // 
            resources.ApplyResources(this.txtDisUse_Contents, "txtDisUse_Contents");
            this.txtDisUse_Contents.Name = "txtDisUse_Contents";
            this.txtDisUse_Contents.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            // 
            // gbxDisuse_Kaizen
            // 
            this.gbxDisuse_Kaizen.Controls.Add(this.rbtKaizen_03);
            this.gbxDisuse_Kaizen.Controls.Add(this.rbtKaizen_05);
            this.gbxDisuse_Kaizen.Controls.Add(this.cboDisUse_Kaizen);
            this.gbxDisuse_Kaizen.Controls.Add(this.rbtKaizen_02);
            this.gbxDisuse_Kaizen.Controls.Add(this.rbtKaizen_01);
            this.gbxDisuse_Kaizen.Controls.Add(this.rbtKaizen_04);
            resources.ApplyResources(this.gbxDisuse_Kaizen, "gbxDisuse_Kaizen");
            this.gbxDisuse_Kaizen.Name = "gbxDisuse_Kaizen";
            this.gbxDisuse_Kaizen.Protect = true;
            this.gbxDisuse_Kaizen.TabStop = false;
            // 
            // rbtKaizen_03
            // 
            this.rbtKaizen_03.CheckedValue = "2";
            resources.ApplyResources(this.rbtKaizen_03, "rbtKaizen_03");
            this.rbtKaizen_03.Name = "rbtKaizen_03";
            this.rbtKaizen_03.TabStop = true;
            this.rbtKaizen_03.UseVisualStyleBackColor = true;
            this.rbtKaizen_03.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtKaizen_05
            // 
            this.rbtKaizen_05.CheckedValue = "4";
            resources.ApplyResources(this.rbtKaizen_05, "rbtKaizen_05");
            this.rbtKaizen_05.Name = "rbtKaizen_05";
            this.rbtKaizen_05.TabStop = true;
            this.rbtKaizen_05.UseVisualStyleBackColor = true;
            this.rbtKaizen_05.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // cboDisUse_Kaizen
            // 
            this.cboDisUse_Kaizen.EnterKeyToTab = false;
            this.cboDisUse_Kaizen.ExecuteQuery = null;
            resources.ApplyResources(this.cboDisUse_Kaizen, "cboDisUse_Kaizen");
            this.cboDisUse_Kaizen.Name = "cboDisUse_Kaizen";
            this.cboDisUse_Kaizen.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDisUse_Kaizen.ParamList")));
            this.cboDisUse_Kaizen.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDisUse_Kaizen.TabStop = false;
            this.cboDisUse_Kaizen.SelectedValueChanged += new System.EventHandler(this.cboDisUse_Kaizen_SelectedValueChanged);
            // 
            // rbtKaizen_02
            // 
            this.rbtKaizen_02.CheckedValue = "1";
            resources.ApplyResources(this.rbtKaizen_02, "rbtKaizen_02");
            this.rbtKaizen_02.Name = "rbtKaizen_02";
            this.rbtKaizen_02.TabStop = true;
            this.rbtKaizen_02.UseVisualStyleBackColor = true;
            this.rbtKaizen_02.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtKaizen_01
            // 
            this.rbtKaizen_01.CheckedValue = "0";
            resources.ApplyResources(this.rbtKaizen_01, "rbtKaizen_01");
            this.rbtKaizen_01.Name = "rbtKaizen_01";
            this.rbtKaizen_01.TabStop = true;
            this.rbtKaizen_01.UseVisualStyleBackColor = true;
            this.rbtKaizen_01.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtKaizen_04
            // 
            this.rbtKaizen_04.CheckedValue = "3";
            resources.ApplyResources(this.rbtKaizen_04, "rbtKaizen_04");
            this.rbtKaizen_04.Name = "rbtKaizen_04";
            this.rbtKaizen_04.TabStop = true;
            this.rbtKaizen_04.UseVisualStyleBackColor = true;
            this.rbtKaizen_04.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // gbxDisuse_Kainyu
            // 
            this.gbxDisuse_Kainyu.Controls.Add(this.rbtKainyu_03);
            this.gbxDisuse_Kainyu.Controls.Add(this.dwIraisyo);
            this.gbxDisuse_Kainyu.Controls.Add(this.rbtKainyu_05);
            this.gbxDisuse_Kainyu.Controls.Add(this.rbtKainyu_02);
            this.gbxDisuse_Kainyu.Controls.Add(this.label2);
            this.gbxDisuse_Kainyu.Controls.Add(this.label3);
            this.gbxDisuse_Kainyu.Controls.Add(this.label4);
            this.gbxDisuse_Kainyu.Controls.Add(this.rbtKainyu_04);
            this.gbxDisuse_Kainyu.Controls.Add(this.cboDisUse_Kainyu);
            this.gbxDisuse_Kainyu.Controls.Add(this.rbtKainyu_01);
            this.gbxDisuse_Kainyu.Controls.Add(this.xFlatLabel9);
            this.gbxDisuse_Kainyu.Controls.Add(this.xFlatLabel10);
            this.gbxDisuse_Kainyu.Controls.Add(this.txtDisuse_FIMBI);
            resources.ApplyResources(this.gbxDisuse_Kainyu, "gbxDisuse_Kainyu");
            this.gbxDisuse_Kainyu.Name = "gbxDisuse_Kainyu";
            this.gbxDisuse_Kainyu.Protect = true;
            this.gbxDisuse_Kainyu.TabStop = false;
            // 
            // rbtKainyu_03
            // 
            this.rbtKainyu_03.CheckedValue = "2";
            resources.ApplyResources(this.rbtKainyu_03, "rbtKainyu_03");
            this.rbtKainyu_03.Name = "rbtKainyu_03";
            this.rbtKainyu_03.TabStop = true;
            this.rbtKainyu_03.UseVisualStyleBackColor = true;
            this.rbtKainyu_03.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // dwIraisyo
            // 
            this.dwIraisyo.DataWindowObject = "reha_iraisyo";
            this.dwIraisyo.LibraryList = "PHYS\\phys.phy8002u01.pbd";
            resources.ApplyResources(this.dwIraisyo, "dwIraisyo");
            this.dwIraisyo.Name = "dwIraisyo";
            this.dwIraisyo.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            // 
            // rbtKainyu_05
            // 
            this.rbtKainyu_05.CheckedValue = "4";
            resources.ApplyResources(this.rbtKainyu_05, "rbtKainyu_05");
            this.rbtKainyu_05.Name = "rbtKainyu_05";
            this.rbtKainyu_05.TabStop = true;
            this.rbtKainyu_05.UseVisualStyleBackColor = true;
            this.rbtKainyu_05.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtKainyu_02
            // 
            this.rbtKainyu_02.CheckedValue = "1";
            resources.ApplyResources(this.rbtKainyu_02, "rbtKainyu_02");
            this.rbtKainyu_02.Name = "rbtKainyu_02";
            this.rbtKainyu_02.TabStop = true;
            this.rbtKainyu_02.UseVisualStyleBackColor = true;
            this.rbtKainyu_02.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // rbtKainyu_04
            // 
            this.rbtKainyu_04.CheckedValue = "3";
            resources.ApplyResources(this.rbtKainyu_04, "rbtKainyu_04");
            this.rbtKainyu_04.Name = "rbtKainyu_04";
            this.rbtKainyu_04.TabStop = true;
            this.rbtKainyu_04.UseVisualStyleBackColor = true;
            this.rbtKainyu_04.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // cboDisUse_Kainyu
            // 
            this.cboDisUse_Kainyu.EnterKeyToTab = false;
            this.cboDisUse_Kainyu.ExecuteQuery = null;
            resources.ApplyResources(this.cboDisUse_Kainyu, "cboDisUse_Kainyu");
            this.cboDisUse_Kainyu.Name = "cboDisUse_Kainyu";
            this.cboDisUse_Kainyu.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDisUse_Kainyu.ParamList")));
            this.cboDisUse_Kainyu.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDisUse_Kainyu.TabStop = false;
            this.cboDisUse_Kainyu.SelectedValueChanged += new System.EventHandler(this.cboDisUse_Kainyu_SelectedValueChanged);
            // 
            // rbtKainyu_01
            // 
            this.rbtKainyu_01.CheckedValue = "0";
            resources.ApplyResources(this.rbtKainyu_01, "rbtKainyu_01");
            this.rbtKainyu_01.Name = "rbtKainyu_01";
            this.rbtKainyu_01.TabStop = true;
            this.rbtKainyu_01.UseVisualStyleBackColor = true;
            this.rbtKainyu_01.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // xFlatLabel9
            // 
            resources.ApplyResources(this.xFlatLabel9, "xFlatLabel9");
            this.xFlatLabel9.Name = "xFlatLabel9";
            // 
            // xFlatLabel10
            // 
            resources.ApplyResources(this.xFlatLabel10, "xFlatLabel10");
            this.xFlatLabel10.Name = "xFlatLabel10";
            // 
            // txtDisuse_FIMBI
            // 
            resources.ApplyResources(this.txtDisuse_FIMBI, "txtDisuse_FIMBI");
            this.txtDisuse_FIMBI.Name = "txtDisuse_FIMBI";
            this.txtDisuse_FIMBI.Validating += new System.ComponentModel.CancelEventHandler(this.txtLength_Validating);
            this.txtDisuse_FIMBI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBoInt_KeyPress);
            // 
            // gbxDisuse_ADL
            // 
            this.gbxDisuse_ADL.Controls.Add(this.rbtBEFADL_03);
            this.gbxDisuse_ADL.Controls.Add(this.cboDisUse_ADL);
            this.gbxDisuse_ADL.Controls.Add(this.rbtBEFADL_06);
            this.gbxDisuse_ADL.Controls.Add(this.rbtBEFADL_05);
            this.gbxDisuse_ADL.Controls.Add(this.rbtBEFADL_01);
            this.gbxDisuse_ADL.Controls.Add(this.rbtBEFADL_04);
            this.gbxDisuse_ADL.Controls.Add(this.rbtBEFADL_02);
            resources.ApplyResources(this.gbxDisuse_ADL, "gbxDisuse_ADL");
            this.gbxDisuse_ADL.Name = "gbxDisuse_ADL";
            this.gbxDisuse_ADL.Protect = true;
            this.gbxDisuse_ADL.TabStop = false;
            // 
            // rbtBEFADL_03
            // 
            this.rbtBEFADL_03.CheckedValue = "2";
            resources.ApplyResources(this.rbtBEFADL_03, "rbtBEFADL_03");
            this.rbtBEFADL_03.Name = "rbtBEFADL_03";
            this.rbtBEFADL_03.TabStop = true;
            this.rbtBEFADL_03.UseVisualStyleBackColor = true;
            this.rbtBEFADL_03.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // cboDisUse_ADL
            // 
            this.cboDisUse_ADL.EnterKeyToTab = false;
            this.cboDisUse_ADL.ExecuteQuery = null;
            resources.ApplyResources(this.cboDisUse_ADL, "cboDisUse_ADL");
            this.cboDisUse_ADL.Name = "cboDisUse_ADL";
            this.cboDisUse_ADL.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDisUse_ADL.ParamList")));
            this.cboDisUse_ADL.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDisUse_ADL.TabStop = false;
            this.cboDisUse_ADL.SelectedValueChanged += new System.EventHandler(this.cboDisUse_ADL_SelectedValueChanged);
            // 
            // rbtBEFADL_06
            // 
            this.rbtBEFADL_06.CheckedValue = "5";
            resources.ApplyResources(this.rbtBEFADL_06, "rbtBEFADL_06");
            this.rbtBEFADL_06.Name = "rbtBEFADL_06";
            this.rbtBEFADL_06.TabStop = true;
            this.rbtBEFADL_06.UseVisualStyleBackColor = true;
            this.rbtBEFADL_06.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtBEFADL_05
            // 
            this.rbtBEFADL_05.CheckedValue = "4";
            resources.ApplyResources(this.rbtBEFADL_05, "rbtBEFADL_05");
            this.rbtBEFADL_05.Name = "rbtBEFADL_05";
            this.rbtBEFADL_05.TabStop = true;
            this.rbtBEFADL_05.UseVisualStyleBackColor = true;
            this.rbtBEFADL_05.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtBEFADL_01
            // 
            this.rbtBEFADL_01.CheckedValue = "0";
            resources.ApplyResources(this.rbtBEFADL_01, "rbtBEFADL_01");
            this.rbtBEFADL_01.Name = "rbtBEFADL_01";
            this.rbtBEFADL_01.TabStop = true;
            this.rbtBEFADL_01.UseVisualStyleBackColor = true;
            this.rbtBEFADL_01.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtBEFADL_04
            // 
            this.rbtBEFADL_04.CheckedValue = "3";
            resources.ApplyResources(this.rbtBEFADL_04, "rbtBEFADL_04");
            this.rbtBEFADL_04.Name = "rbtBEFADL_04";
            this.rbtBEFADL_04.TabStop = true;
            this.rbtBEFADL_04.UseVisualStyleBackColor = true;
            this.rbtBEFADL_04.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtBEFADL_02
            // 
            this.rbtBEFADL_02.CheckedValue = "1";
            resources.ApplyResources(this.rbtBEFADL_02, "rbtBEFADL_02");
            this.rbtBEFADL_02.Name = "rbtBEFADL_02";
            this.rbtBEFADL_02.TabStop = true;
            this.rbtBEFADL_02.UseVisualStyleBackColor = true;
            this.rbtBEFADL_02.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // gbxDisuse_Gasyou
            // 
            this.gbxDisuse_Gasyou.Controls.Add(this.rbtGasyou_03);
            this.gbxDisuse_Gasyou.Controls.Add(this.rbtGasyou_05);
            this.gbxDisuse_Gasyou.Controls.Add(this.rbtGasyou_02);
            this.gbxDisuse_Gasyou.Controls.Add(this.rbtGasyou_04);
            this.gbxDisuse_Gasyou.Controls.Add(this.rbtGasyou_01);
            this.gbxDisuse_Gasyou.Controls.Add(this.cboDisUse_Gasyou);
            resources.ApplyResources(this.gbxDisuse_Gasyou, "gbxDisuse_Gasyou");
            this.gbxDisuse_Gasyou.Name = "gbxDisuse_Gasyou";
            this.gbxDisuse_Gasyou.Protect = true;
            this.gbxDisuse_Gasyou.TabStop = false;
            // 
            // rbtGasyou_03
            // 
            this.rbtGasyou_03.CheckedValue = "2";
            resources.ApplyResources(this.rbtGasyou_03, "rbtGasyou_03");
            this.rbtGasyou_03.Name = "rbtGasyou_03";
            this.rbtGasyou_03.TabStop = true;
            this.rbtGasyou_03.UseVisualStyleBackColor = true;
            this.rbtGasyou_03.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtGasyou_05
            // 
            this.rbtGasyou_05.CheckedValue = "4";
            resources.ApplyResources(this.rbtGasyou_05, "rbtGasyou_05");
            this.rbtGasyou_05.Name = "rbtGasyou_05";
            this.rbtGasyou_05.TabStop = true;
            this.rbtGasyou_05.UseVisualStyleBackColor = true;
            this.rbtGasyou_05.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtGasyou_02
            // 
            this.rbtGasyou_02.CheckedValue = "1";
            resources.ApplyResources(this.rbtGasyou_02, "rbtGasyou_02");
            this.rbtGasyou_02.Name = "rbtGasyou_02";
            this.rbtGasyou_02.TabStop = true;
            this.rbtGasyou_02.UseVisualStyleBackColor = true;
            this.rbtGasyou_02.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtGasyou_04
            // 
            this.rbtGasyou_04.CheckedValue = "3";
            resources.ApplyResources(this.rbtGasyou_04, "rbtGasyou_04");
            this.rbtGasyou_04.Name = "rbtGasyou_04";
            this.rbtGasyou_04.TabStop = true;
            this.rbtGasyou_04.UseVisualStyleBackColor = true;
            this.rbtGasyou_04.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtGasyou_01
            // 
            this.rbtGasyou_01.CheckedValue = "0";
            resources.ApplyResources(this.rbtGasyou_01, "rbtGasyou_01");
            this.rbtGasyou_01.Name = "rbtGasyou_01";
            this.rbtGasyou_01.TabStop = true;
            this.rbtGasyou_01.UseVisualStyleBackColor = true;
            this.rbtGasyou_01.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // cboDisUse_Gasyou
            // 
            this.cboDisUse_Gasyou.EnterKeyToTab = false;
            this.cboDisUse_Gasyou.ExecuteQuery = null;
            resources.ApplyResources(this.cboDisUse_Gasyou, "cboDisUse_Gasyou");
            this.cboDisUse_Gasyou.Name = "cboDisUse_Gasyou";
            this.cboDisUse_Gasyou.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDisUse_Gasyou.ParamList")));
            this.cboDisUse_Gasyou.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDisUse_Gasyou.TabStop = false;
            this.cboDisUse_Gasyou.UserSQL = "SELECT A.CODE_NAME, A.CODE\r\n  FROM OCS0132 A\r\n WHERE A.HOSP_CODE = FN_ADM_LOAD_HO" +
                "SP_CODE()\r\n   AND A.CODE_TYPE = \'PHY_DISUSE_GASYOU\'\r\n ORDER BY A.SORT_KEY";
            this.cboDisUse_Gasyou.SelectedValueChanged += new System.EventHandler(this.cboDisUse_Gasyou_SelectedValueChanged);
            // 
            // grdPHY8002
            // 
            this.grdPHY8002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell24,
            this.xEditGridCell7,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell25,
            this.xEditGridCell48,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell68,
            this.xEditGridCell73,
            this.xEditGridCell74,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell148,
            this.xEditGridCell149,
            this.xEditGridCell151,
            this.xEditGridCell156});
            this.grdPHY8002.ColPerLine = 88;
            this.grdPHY8002.Cols = 88;
            this.grdPHY8002.ControlBinding = true;
            this.grdPHY8002.ExecuteQuery = null;
            this.grdPHY8002.FixedRows = 1;
            this.grdPHY8002.HeaderHeights.Add(20);
            resources.ApplyResources(this.grdPHY8002, "grdPHY8002");
            this.grdPHY8002.Name = "grdPHY8002";
            this.grdPHY8002.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPHY8002.ParamList")));
            this.grdPHY8002.QuerySQL = resources.GetString("grdPHY8002.QuerySQL");
            this.grdPHY8002.Rows = 2;
            this.grdPHY8002.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPHY8002_RowFocusChanged);
            this.grdPHY8002.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdPHY8002_SaveEnd);
            this.grdPHY8002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPHY8002_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "sys_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 4;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 8;
            this.xEditGridCell2.CellName = "user_id";
            this.xEditGridCell2.Col = 5;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "upd_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = 6;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "hosp_code";
            this.xEditGridCell54.Col = 53;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsUpdatable = false;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "pkphy8002";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.CellWidth = 125;
            this.xEditGridCell67.Col = 2;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsUpdatable = false;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "fk_ocs";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 1;
            this.xEditGridCell6.CellName = "io_kubun";
            this.xEditGridCell6.CellWidth = 90;
            this.xEditGridCell6.Col = 9;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 8;
            this.xEditGridCell4.CellName = "irai_date";
            this.xEditGridCell4.Col = 7;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "kanja_no";
            this.xEditGridCell8.Col = 10;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 2;
            this.xEditGridCell5.CellName = "sinryouka";
            this.xEditGridCell5.Col = 8;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "sindanisi";
            this.xEditGridCell9.Col = 11;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "tantoui";
            this.xEditGridCell69.Col = 51;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsUpdatable = false;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellLen = 8;
            this.xEditGridCell70.CellName = "nyuuinnbi";
            this.xEditGridCell70.Col = 54;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsUpdatable = false;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellLen = 2;
            this.xEditGridCell71.CellName = "byousitu_code";
            this.xEditGridCell71.Col = 55;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsUpdatable = false;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellLen = 4;
            this.xEditGridCell72.CellName = "byoutou_code";
            this.xEditGridCell72.Col = 56;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsUpdatable = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "kaisibi";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = 12;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 3;
            this.xEditGridCell19.CellName = "nissuu";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.Col = 23;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "koumoku_code";
            this.xEditGridCell13.Col = 14;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdatable = false;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellLen = 50;
            this.xEditGridCell26.CellName = "pt1";
            this.xEditGridCell26.Col = 27;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsUpdatable = false;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellLen = 50;
            this.xEditGridCell27.CellName = "pt2";
            this.xEditGridCell27.Col = 28;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdatable = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellLen = 50;
            this.xEditGridCell28.CellName = "pt3";
            this.xEditGridCell28.Col = 29;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdatable = false;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellLen = 50;
            this.xEditGridCell29.CellName = "pt4";
            this.xEditGridCell29.Col = 30;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdatable = false;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 50;
            this.xEditGridCell30.CellName = "pt5";
            this.xEditGridCell30.Col = 31;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdatable = false;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 50;
            this.xEditGridCell31.CellName = "pt6";
            this.xEditGridCell31.Col = 32;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdatable = false;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellLen = 50;
            this.xEditGridCell32.CellName = "pt7";
            this.xEditGridCell32.Col = 33;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsUpdatable = false;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellLen = 50;
            this.xEditGridCell77.CellName = "pt8";
            this.xEditGridCell77.Col = 61;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsUpdatable = false;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellLen = 50;
            this.xEditGridCell78.CellName = "pt9";
            this.xEditGridCell78.Col = 62;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsUpdatable = false;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellLen = 50;
            this.xEditGridCell79.CellName = "pt10";
            this.xEditGridCell79.Col = 1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsUpdatable = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 50;
            this.xEditGridCell33.CellName = "ot1";
            this.xEditGridCell33.Col = 34;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsUpdatable = false;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellLen = 50;
            this.xEditGridCell34.CellName = "ot2";
            this.xEditGridCell34.Col = 35;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsUpdatable = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellLen = 50;
            this.xEditGridCell35.CellName = "ot3";
            this.xEditGridCell35.Col = 36;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdatable = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 50;
            this.xEditGridCell36.CellName = "ot4";
            this.xEditGridCell36.Col = 37;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsUpdatable = false;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellLen = 50;
            this.xEditGridCell37.CellName = "ot5";
            this.xEditGridCell37.Col = 38;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsUpdatable = false;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 50;
            this.xEditGridCell38.CellName = "ot6";
            this.xEditGridCell38.Col = 39;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsUpdatable = false;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellLen = 50;
            this.xEditGridCell80.CellName = "ot7";
            this.xEditGridCell80.Col = 3;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsUpdatable = false;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellLen = 50;
            this.xEditGridCell81.CellName = "ot8";
            this.xEditGridCell81.Col = 13;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsUpdatable = false;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellLen = 50;
            this.xEditGridCell82.CellName = "ot9";
            this.xEditGridCell82.Col = 15;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsUpdatable = false;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellLen = 50;
            this.xEditGridCell83.CellName = "ot10";
            this.xEditGridCell83.Col = 16;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsUpdatable = false;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 50;
            this.xEditGridCell39.CellName = "st1";
            this.xEditGridCell39.Col = 40;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsUpdatable = false;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellLen = 50;
            this.xEditGridCell40.CellName = "st2";
            this.xEditGridCell40.Col = 41;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsUpdatable = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 50;
            this.xEditGridCell41.CellName = "st3";
            this.xEditGridCell41.Col = 42;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsUpdatable = false;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellLen = 50;
            this.xEditGridCell42.CellName = "st4";
            this.xEditGridCell42.Col = 43;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsUpdatable = false;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellLen = 50;
            this.xEditGridCell43.CellName = "st5";
            this.xEditGridCell43.Col = 44;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsUpdatable = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellLen = 50;
            this.xEditGridCell44.CellName = "st6";
            this.xEditGridCell44.Col = 45;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsUpdatable = false;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellLen = 50;
            this.xEditGridCell84.CellName = "st7";
            this.xEditGridCell84.Col = 17;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsUpdatable = false;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellLen = 50;
            this.xEditGridCell85.CellName = "st8";
            this.xEditGridCell85.Col = 18;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsUpdatable = false;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellLen = 50;
            this.xEditGridCell86.CellName = "st9";
            this.xEditGridCell86.Col = 19;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsUpdatable = false;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellLen = 50;
            this.xEditGridCell87.CellName = "st10";
            this.xEditGridCell87.Col = 20;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsUpdatable = false;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellLen = 100;
            this.xEditGridCell45.CellName = "objective";
            this.xEditGridCell45.Col = 46;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellLen = 100;
            this.xEditGridCell46.CellName = "consult_comment";
            this.xEditGridCell46.CellWidth = 234;
            this.xEditGridCell46.Col = 47;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellLen = 100;
            this.xEditGridCell88.CellName = "genbyoureki";
            this.xEditGridCell88.Col = 21;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellLen = 100;
            this.xEditGridCell47.CellName = "complications";
            this.xEditGridCell47.Col = 48;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 100;
            this.xEditGridCell49.CellName = "taboo";
            this.xEditGridCell49.Col = 49;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellLen = 100;
            this.xEditGridCell50.CellName = "stop_kijyun";
            this.xEditGridCell50.Col = 50;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellLen = 100;
            this.xEditGridCell52.CellName = "frequency";
            this.xEditGridCell52.Col = 52;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellLen = 100;
            this.xEditGridCell89.CellName = "infectious";
            this.xEditGridCell89.Col = 22;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellLen = 200;
            this.xEditGridCell90.CellName = "kioureki";
            this.xEditGridCell90.Col = 24;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellLen = 1;
            this.xEditGridCell91.CellName = "syori_flag";
            this.xEditGridCell91.Col = 25;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsUpdatable = false;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellLen = 1;
            this.xEditGridCell92.CellName = "pt_flag";
            this.xEditGridCell92.Col = 26;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellLen = 1;
            this.xEditGridCell93.CellName = "ot_flag";
            this.xEditGridCell93.Col = 57;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellLen = 1;
            this.xEditGridCell94.CellName = "st_flag";
            this.xEditGridCell94.Col = 58;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "bu_flag";
            this.xEditGridCell24.Col = 70;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "syujyutubi";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = 59;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "kyuseizouakubi";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell14.Col = 60;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 50;
            this.xEditGridCell15.CellName = "disuse_gasyou";
            this.xEditGridCell15.Col = 63;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 50;
            this.xEditGridCell16.CellName = "disuse_adl";
            this.xEditGridCell16.Col = 64;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 3;
            this.xEditGridCell17.CellName = "disuse_kainyu";
            this.xEditGridCell17.Col = 65;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellLen = 50;
            this.xEditGridCell18.CellName = "disuse_kaizen";
            this.xEditGridCell18.Col = 66;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellLen = 100;
            this.xEditGridCell20.CellName = "disuse_contents";
            this.xEditGridCell20.Col = 67;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellLen = 1;
            this.xEditGridCell21.CellName = "irai_kubun";
            this.xEditGridCell21.Col = 68;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellLen = 3;
            this.xEditGridCell22.CellName = "disuse_fimbi";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell22.Col = 69;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.BindControl = this.txtYoin_start_date;
            this.xEditGridCell25.CellName = "yoin_start_date";
            this.xEditGridCell25.Col = 71;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.BindControl = this.txtYoin_sindan_date;
            this.xEditGridCell48.CellName = "yoin_sindan_date";
            this.xEditGridCell48.Col = 72;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellLen = 50;
            this.xEditGridCell55.CellName = "su_1";
            this.xEditGridCell55.Col = 73;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellLen = 50;
            this.xEditGridCell56.CellName = "su_2_1";
            this.xEditGridCell56.Col = 74;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellLen = 50;
            this.xEditGridCell57.CellName = "su_2_2";
            this.xEditGridCell57.Col = 75;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellLen = 50;
            this.xEditGridCell68.CellName = "su_2_3";
            this.xEditGridCell68.Col = 76;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellLen = 50;
            this.xEditGridCell73.CellName = "su_2_4";
            this.xEditGridCell73.Col = 77;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellLen = 50;
            this.xEditGridCell74.CellName = "su_3_1";
            this.xEditGridCell74.Col = 78;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellLen = 50;
            this.xEditGridCell75.CellName = "su_3_2";
            this.xEditGridCell75.Col = 79;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellLen = 50;
            this.xEditGridCell76.CellName = "su_4_1";
            this.xEditGridCell76.Col = 80;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellLen = 50;
            this.xEditGridCell95.CellName = "su_4_2";
            this.xEditGridCell95.Col = 81;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellLen = 50;
            this.xEditGridCell96.CellName = "su_4_3";
            this.xEditGridCell96.Col = 82;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellLen = 1;
            this.xEditGridCell97.CellName = "ke_flag";
            this.xEditGridCell97.Col = 83;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellLen = 100;
            this.xEditGridCell148.CellName = "image";
            this.xEditGridCell148.Col = 84;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsUpdatable = false;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellLen = 100;
            this.xEditGridCell149.CellName = "image_path";
            this.xEditGridCell149.Col = 85;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsUpdatable = false;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "image_seq";
            this.xEditGridCell151.Col = 86;
            this.xEditGridCell151.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell151, "xEditGridCell151");
            this.xEditGridCell151.IsUpdatable = false;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "cr_time";
            this.xEditGridCell156.CellType = IHIS.Framework.XCellDataType.DateTime;
            this.xEditGridCell156.Col = 87;
            this.xEditGridCell156.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell156, "xEditGridCell156");
            this.xEditGridCell156.IsUpdatable = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCopy);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.DrawBorder = true;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBottom_MouseDown);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::IHIS.PHYS.Properties.Resources.복사;
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnList
            // 
            this.btnList.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F9, global::IHIS.PHYS.Properties.Resources.TEXT1, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Preview, System.Windows.Forms.Shortcut.F10, global::IHIS.PHYS.Properties.Resources.TEXT2, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.F11, global::IHIS.PHYS.Properties.Resources.TEXT3, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.F12, global::IHIS.PHYS.Properties.Resources.TEXT4, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.PHYS.Properties.Resources.TEXT5, -1, "")});
            this.btnList.IsVisibleReset = false;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "sys_date";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "user_id";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "upd_date";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "hosp_code";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "pk_phy_syoubyou";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "fk_ocs_irai";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "i_seq";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "io_kubun";
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "irai_date";
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "kanja_no";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "sinryouka";
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "syoubyoumei_code";
            this.xEditGridCell106.Col = 1;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "hassyoubi";
            this.xEditGridCell107.Col = 2;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "sindanbi";
            this.xEditGridCell108.Col = 3;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "reigai_sindanmei";
            this.xEditGridCell109.Col = 4;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
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
            // layIraisyo
            // 
            this.layIraisyo.ExecuteQuery = null;
            this.layIraisyo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem178,
            this.multiLayoutItem179,
            this.multiLayoutItem180,
            this.multiLayoutItem181,
            this.multiLayoutItem182,
            this.multiLayoutItem183,
            this.multiLayoutItem184,
            this.multiLayoutItem185,
            this.multiLayoutItem186,
            this.multiLayoutItem187,
            this.multiLayoutItem188,
            this.multiLayoutItem189,
            this.multiLayoutItem190,
            this.multiLayoutItem191,
            this.multiLayoutItem192,
            this.multiLayoutItem193,
            this.multiLayoutItem194,
            this.multiLayoutItem195,
            this.multiLayoutItem196,
            this.multiLayoutItem197,
            this.multiLayoutItem198,
            this.multiLayoutItem237,
            this.multiLayoutItem238,
            this.multiLayoutItem239,
            this.multiLayoutItem242,
            this.multiLayoutItem243,
            this.multiLayoutItem252,
            this.multiLayoutItem253,
            this.multiLayoutItem254,
            this.multiLayoutItem255,
            this.multiLayoutItem256,
            this.multiLayoutItem257,
            this.multiLayoutItem258,
            this.multiLayoutItem259,
            this.multiLayoutItem262,
            this.multiLayoutItem263,
            this.multiLayoutItem264});
            this.layIraisyo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layIraisyo.ParamList")));
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "SYS_DATE";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "USER_ID";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "UPD_DATE";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "HOSP_CODE";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "PK_IFS_IRAI";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "DATA_KUBUN";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "FK_OCS_IRAI";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "I_SEQ";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "IO_KUBUN";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "IRAI_DATE";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "KANJA_NO";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "SINRYOUKA";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "SINDANISI";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "TANTOUI";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "NYUUINNBI";
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "BYOUTOU_CODE";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "BYOUSITU_CODE";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "NISSUU";
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "KAISIBI";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "SYUJYUTUBI";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "KYUSEIZOUAKUBI";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "SU_1";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "SU_2_1";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "SU_2_2";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "SU_2_3";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "SU_2_4";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "SU_3_1";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "SU_3_2";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "SU_4_1";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "SU_4_2";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "SU_4_3";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "REHA1";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "REHA2";
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "REHA3";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "REHA4";
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "REHA5";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "PT1";
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "PT2";
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "PT3";
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "PT4";
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "PT5";
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "PT6";
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "PT7";
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "PT8";
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "PT9";
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "PT10";
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "OT1";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "OT2";
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "OT3";
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "OT4";
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "OT5";
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "OT6";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "OT7";
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "OT8";
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "OT9";
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "OT10";
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "ST1";
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "ST2";
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "ST3";
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "ST4";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "ST5";
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "ST6";
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "ST7";
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "ST8";
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "ST9";
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "ST10";
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "OBJECTIVE";
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "CONSULT_COMMENT";
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "GENBYOUREKI";
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "COMPLICATIONS";
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "TABOO";
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "STOP_KIJYUN";
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "FREQUENCY";
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "INFECTIOUS";
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "KIOUREKI";
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "SYORI_FLAG";
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "PT_FLAG";
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "OT_FLAG";
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "ST_FLAG";
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "BU_FLAG";
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "REMARK";
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "DISPLAY_SYOUBYOUMEI1";
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "DISPLAY_SYOUBYOUMEI2";
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "DISPLAY_SYOUBYOUMEI3";
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "DISPLAY_SYOUBYOUMEI4";
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "DISPLAY_SYOUBYOUMEI5";
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "DISPLAY_SYOUBYOUMEI6";
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "DISPLAY_SYOUBYOUMEI7";
            // 
            // multiLayoutItem170
            // 
            this.multiLayoutItem170.DataName = "DISPLAY_SYOUBYOUMEI8";
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "DISPLAY_SYOUBYOUMEI9";
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "DISPLAY_SYOUBYOUMEI10";
            // 
            // multiLayoutItem173
            // 
            this.multiLayoutItem173.DataName = "HASSYOUBI1";
            // 
            // multiLayoutItem174
            // 
            this.multiLayoutItem174.DataName = "HASSYOUBI2";
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "HASSYOUBI3";
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "HASSYOUBI4";
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "HASSYOUBI5";
            // 
            // multiLayoutItem178
            // 
            this.multiLayoutItem178.DataName = "HASSYOUBI6";
            // 
            // multiLayoutItem179
            // 
            this.multiLayoutItem179.DataName = "HASSYOUBI7";
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "HASSYOUBI8";
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "HASSYOUBI9";
            // 
            // multiLayoutItem182
            // 
            this.multiLayoutItem182.DataName = "HASSYOUBI10";
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "SINDANBI1";
            // 
            // multiLayoutItem184
            // 
            this.multiLayoutItem184.DataName = "SINDANBI2";
            // 
            // multiLayoutItem185
            // 
            this.multiLayoutItem185.DataName = "SINDANBI3";
            // 
            // multiLayoutItem186
            // 
            this.multiLayoutItem186.DataName = "SINDANBI4";
            // 
            // multiLayoutItem187
            // 
            this.multiLayoutItem187.DataName = "SINDANBI5";
            // 
            // multiLayoutItem188
            // 
            this.multiLayoutItem188.DataName = "SINDANBI6";
            // 
            // multiLayoutItem189
            // 
            this.multiLayoutItem189.DataName = "SINDANBI7";
            // 
            // multiLayoutItem190
            // 
            this.multiLayoutItem190.DataName = "SINDANBI8";
            // 
            // multiLayoutItem191
            // 
            this.multiLayoutItem191.DataName = "SINDANBI9";
            // 
            // multiLayoutItem192
            // 
            this.multiLayoutItem192.DataName = "SINDANBI10";
            // 
            // multiLayoutItem193
            // 
            this.multiLayoutItem193.DataName = "KANJI_NAME";
            // 
            // multiLayoutItem194
            // 
            this.multiLayoutItem194.DataName = "KANA_NAME";
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "SEX";
            // 
            // multiLayoutItem196
            // 
            this.multiLayoutItem196.DataName = "BIRTH_DAY";
            // 
            // multiLayoutItem197
            // 
            this.multiLayoutItem197.DataName = "ADDRESS";
            // 
            // multiLayoutItem198
            // 
            this.multiLayoutItem198.DataName = "AGE";
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "YOYANG_NAME";
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "JAEDAN_NAME";
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "SU_3";
            // 
            // multiLayoutItem242
            // 
            this.multiLayoutItem242.DataName = "KG";
            // 
            // multiLayoutItem243
            // 
            this.multiLayoutItem243.DataName = "SU_ETC";
            // 
            // multiLayoutItem252
            // 
            this.multiLayoutItem252.DataName = "DISUSE_GASYOU";
            // 
            // multiLayoutItem253
            // 
            this.multiLayoutItem253.DataName = "DISUSE_ADL";
            // 
            // multiLayoutItem254
            // 
            this.multiLayoutItem254.DataName = "DISUSE_KAINYU";
            // 
            // multiLayoutItem255
            // 
            this.multiLayoutItem255.DataName = "DISUSE_KAIZEN";
            // 
            // multiLayoutItem256
            // 
            this.multiLayoutItem256.DataName = "DISUSE_CONTENTS";
            // 
            // multiLayoutItem257
            // 
            this.multiLayoutItem257.DataName = "DISUSE_FIMBI";
            // 
            // multiLayoutItem258
            // 
            this.multiLayoutItem258.DataName = "IRAI_KUBUN";
            // 
            // multiLayoutItem259
            // 
            this.multiLayoutItem259.DataName = "PKPHY8002";
            // 
            // multiLayoutItem262
            // 
            this.multiLayoutItem262.DataName = "DISABILITY";
            // 
            // multiLayoutItem263
            // 
            this.multiLayoutItem263.DataName = "YOIN_START_DATE";
            // 
            // multiLayoutItem264
            // 
            this.multiLayoutItem264.DataName = "YOIN_SINDAN_DATE";
            // 
            // pnlCenterRight
            // 
            this.pnlCenterRight.Controls.Add(this.xPanel12);
            this.pnlCenterRight.Controls.Add(this.xPanel9);
            resources.ApplyResources(this.pnlCenterRight, "pnlCenterRight");
            this.pnlCenterRight.Name = "pnlCenterRight";
            // 
            // xPanel12
            // 
            this.xPanel12.Controls.Add(this.imageEditor);
            resources.ApplyResources(this.xPanel12, "xPanel12");
            this.xPanel12.Name = "xPanel12";
            // 
            // imageEditor
            // 
            resources.ApplyResources(this.imageEditor, "imageEditor");
            this.imageEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.imageEditor.Image = ((System.Drawing.Image)(resources.GetObject("imageEditor.Image")));
            this.imageEditor.Name = "imageEditor";
            this.imageEditor.ShowSaveButton = false;
            this.imageEditor.Validated += new System.EventHandler(this.imageEditor_Validated);
            // 
            // xPanel9
            // 
            this.xPanel9.Controls.Add(this.btnReset);
            this.xPanel9.Controls.Add(this.xLabel5);
            this.xPanel9.Controls.Add(this.xLabel4);
            resources.ApplyResources(this.xPanel9, "xPanel9");
            this.xPanel9.Name = "xPanel9";
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // xLabel5
            // 
            this.xLabel5.EdgeRounding = false;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel4
            // 
            this.xLabel4.EdgeRounding = false;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // tabReha
            // 
            this.tabReha.IDEPixelArea = true;
            this.tabReha.IDEPixelBorder = false;
            resources.ApplyResources(this.tabReha, "tabReha");
            this.tabReha.Name = "tabReha";
            this.tabReha.SelectedIndex = 0;
            this.tabReha.SelectedTab = this.tpgImage;
            this.tabReha.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tpgImage,
            this.tpgFIM});
            // 
            // tpgImage
            // 
            this.tpgImage.Controls.Add(this.pnlCenterRight);
            resources.ApplyResources(this.tpgImage, "tpgImage");
            this.tpgImage.Name = "tpgImage";
            // 
            // tpgFIM
            // 
            this.tpgFIM.Controls.Add(this.pnlDisUseObj);
            resources.ApplyResources(this.tpgFIM, "tpgFIM");
            this.tpgFIM.Name = "tpgFIM";
            this.tpgFIM.Selected = false;
            // 
            // PHY8002U01
            // 
            this.Controls.Add(this.tabReha);
            this.Controls.Add(this.pnlRightUnderLeft);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.grdPHY8002);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "PHY8002U01";
            resources.ApplyResources(this, "$this");
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PHY8002U01_Closing);
            this.Load += new System.EventHandler(this.PHY1000U00_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.PHY1000U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patBox)).EndInit();
            this.pnlCenter.ResumeLayout(false);
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
            this.pnlTopInfo.ResumeLayout(false);
            this.pnlTopInfo.PerformLayout();
            this.grbDisability.ResumeLayout(false);
            this.grbDisability.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY8004)).EndInit();
            this.gbxGenbyoureki.ResumeLayout(false);
            this.gbxGenbyoureki.PerformLayout();
            this.gbxComplications.ResumeLayout(false);
            this.gbxComplications.PerformLayout();
            this.gbxKioureki.ResumeLayout(false);
            this.gbxKioureki.PerformLayout();
            this.gbxSindanmei.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY8003)).EndInit();
            this.pnlRightUnderLeft.ResumeLayout(false);
            this.pnlRightUnderLeft.PerformLayout();
            this.pnlDisUseObj.ResumeLayout(false);
            this.gbxDisuse_Contents.ResumeLayout(false);
            this.gbxDisuse_Contents.PerformLayout();
            this.gbxDisuse_Kaizen.ResumeLayout(false);
            this.gbxDisuse_Kainyu.ResumeLayout(false);
            this.gbxDisuse_Kainyu.PerformLayout();
            this.gbxDisuse_ADL.ResumeLayout(false);
            this.gbxDisuse_Gasyou.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY8002)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layIraisyo)).EndInit();
            this.pnlCenterRight.ResumeLayout(false);
            this.xPanel12.ResumeLayout(false);
            this.xPanel9.ResumeLayout(false);
            this.tabReha.ResumeLayout(false);
            this.tpgImage.ResumeLayout(false);
            this.tpgFIM.ResumeLayout(false);
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
        private string mAutoColseYN;
        private string mCaller_screen_id;

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
				if(this.OpenParam.Contains("pkocskey"))
                    this.mFkocs          = this.OpenParam["pkocskey"].ToString();
                if (this.OpenParam.Contains("in_out_gubun"))
				    this.mInOutGubun     = this.OpenParam["in_out_gubun"].ToString();
                
                if (this.OpenParam.Contains("gwa"))
                    this.mGwa = this.OpenParam["gwa"].ToString();
                else
                    this.mGwa = "";

                if (this.OpenParam.Contains("bunho"))
				    this.mBunho		     = this.OpenParam["bunho"].ToString();
                if (this.OpenParam.Contains("order_date"))
				    this.mOrder_date     = this.OpenParam["order_date"].ToString();
                if (this.OpenParam.Contains("query_mode"))
				    this.mquery_mode     = this.OpenParam["query_mode"].ToString();
                if (this.OpenParam.Contains("hangmog_code"))
				    this.mHangmog_code   = this.OpenParam["hangmog_code"].ToString();
                if (this.OpenParam.Contains("caller_screen_id"))
                    this.mCaller_screen_id = this.OpenParam["caller_screen_id"].ToString();

                if (this.OpenParam.Contains("approve_doctor"))
                {
                    if (UserInfo.Gwa == "CK")
                    {
                        this.mApproveDoctorGWA = this.OpenParam["approve_doctor"].ToString().Substring(0, 2);
                        this.mApproveDoctorID = this.OpenParam["approve_doctor"].ToString().Substring(2);
                    }
                }

                // 自動出力用
                if(this.OpenParam.Contains("AutoCloseYN"))
                    this.mAutoColseYN = this.OpenParam["AutoCloseYN"].ToString();
			}

            if (this.mAutoColseYN == "Y")
            {
                this.pnlCenter.Enabled = false;
                this.ParentForm.WindowState = FormWindowState.Minimized;
            }

            SetNumCombo(this.cboNissuu, "nalsu", false);
            this.cboNissuu.SelectedIndex = 0;
            this.cboNissuu.AcceptData();

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


            //string cmdStr = @"SELECT CODE_NAME FROM OCS0132 WHERE CODE_TYPE = 'RESULT_PATH' AND CODE = 'PATH' AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()";
            //object retVal = Service.ExecuteScalar(cmdStr);

		    PHY8002U01PHY1000U00ScreenOpenArgs args = new PHY8002U01PHY1000U00ScreenOpenArgs();
		    PHY8002U01PHY1000U00ScreenOpenResult result =
		        CloudService.Instance.Submit<PHY8002U01PHY1000U00ScreenOpenResult, PHY8002U01PHY1000U00ScreenOpenArgs>(args);
            //if (!TypeCheck.IsNull(retVal))
            if (result.ExecutionStatus == ExecutionStatus.Success && !String.IsNullOrEmpty(result.CodeName))
            {
                //mPathNm = retVal.ToString();
                mPathNm = result.CodeName;
            }
            this.mReturnControl = "";

            DataSetting();
		}

        private void DataSetting()
        {
            if (mFkocs != "")
            {
                //this.grdPHY8002.RowFocusChanged -= new IHIS.Framework.RowFocusChangedEventHandler(this.grdPHY8002_RowFocusChanged);
                this.grdPHY8002.QueryLayout(true);
                //this.grdPHY8002.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPHY8002_RowFocusChanged);

                #region [主項目のチェックボックスの初期値設定]
                if (this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_3_1") != "")
                {
                    string kg = this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_3_1");
                    this.cbxKE_FLAG.Checked = true;
                    this.rbtSu_3_1.CheckedChanged -= new System.EventHandler(this.rbtSu_3_1_CheckedChanged);
                    this.rbtSu_3_1.Checked = true;
                    this.rbtSu_3_1.CheckedChanged += new System.EventHandler(this.rbtSu_3_1_CheckedChanged);
                    this.txtKg.Text = kg;
                }
                else if (this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_3_2") != "")
                {
                    string kg = this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_3_2");
                    this.cbxKE_FLAG.Checked = true;
                    this.rbtSu_3_2.CheckedChanged -= new System.EventHandler(this.rbtSu_3_1_CheckedChanged);
                    this.rbtSu_3_2.Checked = true;
                    this.rbtSu_3_2.CheckedChanged += new System.EventHandler(this.rbtSu_3_1_CheckedChanged);
                    this.txtKg.Text = kg;
                }
                //else
                //    this.rbtSu_3_1.Checked = true;

                if (this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_2_4") != "")
                {
                    this.cbxSu_2_4_c.Checked = true;
                }
                if (this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_2_1") == "Y"
                    || this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_2_2") == "Y"
                    || this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_2_3") == "Y"
                    || this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_2_4") != "")
                {
                    this.cbxBU_FLAG.Checked = true;
                }
                #endregion

                if (this.grdPHY8002.RowCount < 1)
                    InsertRow_grdPHY8002();
            }
            this.grdPHY8004.QueryLayout(true);

            PHY8002U01MultiGrdArgs args = new PHY8002U01MultiGrdArgs();
            multiGrdResult = CloudService.Instance.Submit<PHY8002U01MultiGrdResult, PHY8002U01MultiGrdArgs>(args);

            this.grdPT.QueryLayout(true);
            this.grdOT.QueryLayout(true);
            this.grdST.QueryLayout(true);

            this.grdPT.Refresh();
            this.grdOT.Refresh();
            this.grdST.Refresh();

            this.grdPHY8003.QueryLayout(true);

            //if (this.grdPHY8003.RowCount == 0)
            //    this.btnSindanmei.PerformClick();


            if (this.grdPHY8002.RowCount > 0)
            {
                this.setgrdPT();
                this.setgrdOT();
                this.setgrdST();
            }
            else
                InsertRow_grdPHY8002();

            InitContol();
            this.InitScreen();

            if (this.mAutoColseYN == "Y")
                this.btnList.PerformClick(FunctionType.Print);
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
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? Resources.TEXT6 : Resources.TEXT7, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuDelete_Click)));

            if (UserInfo.UserGubun == UserType.Doctor)
                lblGwa.Text = UserInfo.GwaName;
            else if (UserInfo.Gwa == "CK")
            {
                string gwa_name = "";
                this.mOrderBiz.LoadColumnCodeName("gwa", this.mApproveDoctorGWA, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref gwa_name);
                this.lblGwa.Text = gwa_name;
            }

            if (this.txtKg.Text == "" && this.cbxKE_FLAG.Checked == false)
                this.txtKg.Enabled = false;

            if (this.txtSu_2_4.Text == "")
                this.txtSu_2_4.Enabled = false;

            // 実績画面から呼び出された際には画面全体を修正不可とする。
            if (this.mCaller_screen_id == "OCS3003Q10" || this.mCaller_screen_id == "OCSAPPROVE" || (this.IsJissekiData() == true && this.copyPkocskey == ""))
            {
                this.pnlCenterLeft.Enabled = false; 
                this.pnlDisUseObj.Enabled = false;
                this.btnCopy.Visible = false;
                string str = "";
                this.mOrderBiz.LoadColumnCodeName("gwa_all", this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "sinryouka"), this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "irai_date"), ref str);
                lblGwa.Text = str;

                this.btnList.FunctionItems.Clear();
                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Preview, Shortcut.None, "EMR伝送", -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Print, Shortcut.F11, Resources.TEXT3, -1, ""));
                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Update, Shortcut.None, "保存", -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Close, Shortcut.None, Resources.TEXT5, -1, ""));
                this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                //this.btnList.Location = new Point(this.Parent.Width - 460, this.Parent.Height - 35);
                this.btnList.InitializeButtons();
                this.btnList.Refresh();
            }
            else
            {
                this.btnList.FunctionItems.Clear();
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.F9, Resources.TEXT1, -1, ""));
                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Preview, Shortcut.F10, "EMR伝送", -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Print, Shortcut.F11, Resources.TEXT3, -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Update, Shortcut.F12, Resources.TEXT4, -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Close, Shortcut.None, Resources.TEXT5, -1, ""));
                this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                //this.btnList.Location = new Point(this.Parent.Width - 460, this.Parent.Height - 35);
                this.btnList.InitializeButtons();
                this.btnList.Refresh();
            }
        }
        // 처방행삭제
        private void PopUpMenuDelete_Click(object sender, System.EventArgs e)
        {
            XEditGrid currentGrid = this.mCurrentGrid;

            if (this.btnList.Enabled)
            {
                //this.grdPHY8003.Focus();
                //this.btnList.PerformClick(FunctionType.Delete);
                currentGrid.DeleteRow(currentGrid.CurrentRowNumber);
                currentGrid.UnSelectAll();
            }
        }
        #endregion
        
        public void setgrdPT()
        {
            string columnName = "pt";
            int row = 1;
            string column = "";
            string data = "";
            for (int i = 1; i <= this.grdPT.RowCount; i++)
            {
                column = columnName + (row++).ToString();
                data = this.grdPHY8002.LayoutTable.Rows[0][column].ToString();
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
                data = this.grdPHY8002.LayoutTable.Rows[0][column].ToString();
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
                data = this.grdPHY8002.LayoutTable.Rows[0][column].ToString();
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
            //this.cbxSu_2_1.Enabled = false;
            //this.cbxSu_2_2.Enabled = false;
            //this.cbxSu_2_3.Enabled = false;
            //this.cbxSu_2_4_c.Enabled = false;

            //this.txtSu_2_4.Enabled = false;

            //this.rbtSu_3_1.Enabled = false;
            //this.rbtSu_3_2.Enabled = false;
            //this.txtKg.Enabled = false;
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
            layCombo.LayoutItems.Add("code", IHIS.Framework.DataType.String);
            layCombo.LayoutItems.Add("code_name", IHIS.Framework.DataType.String);

            layCombo.InitializeLayoutTable();

            switch (aColName)
            {
                case "nalsu":

//                    layCombo.QuerySQL =
//                        @" SELECT '0', '0', 0
//                             FROM SYS.DUAL
//                            UNION
//                           SELECT A.CODE CODE, A.CODE CODE_NAME, A.SORT_KEY
//                             FROM OCS0132 A 
//                            WHERE A.CODE_TYPE = 'NALSU' 
//                              AND A.HOSP_CODE   = '" + EnvironInfo.HospCode + @"'
//                            ORDER BY 3, 1 ";
                    layCombo.ExecuteQuery = LoadDataLayCbo;

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
                case FunctionType.Close:
                    e.IsBaseCall = false;
                    if (!(this.grdPHY8002.GetRowState(this.grdPHY8002.CurrentRowNumber) == DataRowState.Unchanged))
                    {
                        if (XMessageBox.Show(Resources.TEXT8, Resources.TEXT9, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            Close();
                    }
                    else
                        Close();
                    break;
				case FunctionType.Delete:
                    
					break;

				case FunctionType.Update:
                    
                    if (this.grdPHY8002.GetRowState(this.grdPHY8002.CurrentRowNumber) != DataRowState.Unchanged) { update_changed = true; }
                    //if (this.grdPT.GetRowState(this.grdPT.CurrentRowNumber) != DataRowState.Unchanged) { }

                    //PT, OT, ST, REHAをクリックした場合修正されたとみなす。
                    if (this.mChanged == true) { update_changed = true; }
                    //傷病リストに変更があった場合修正されたとみなす。
                    for (int i = 0; i < this.grdPHY8003.RowCount; i++)
                        if (this.grdPHY8003.GetRowState(i) != DataRowState.Unchanged) { update_changed = true; }
                    //障害リストに変更があった場合修正されたとみなす。
                    for (int i = 0; i < this.grdPHY8004.RowCount; i++)
                        if (this.grdPHY8004.GetRowState(i) != DataRowState.Unchanged) { update_changed = true; }

                    // leaveCntが1以上の場合は修正されたとみなす。
                    
                    if (this.leaveCnt > 0)
                        update_changed = true;

                    //ValidationCheck

                    
                    //if (!this.ValidateCheck())
                    //{
                    //    return;
                    //}
                    

                    //Add アップデータ不可能なケース設定
                    if (update_changed == true && this.IsJissekiData())
                    {
                        XMessageBox.Show(Resources.TEXT10,Resources.TEXT11);
                        break;
                    }

                    this.imageEditor.Save();//更新時点でのイメージ保存

                    // 変更があったときのみPHY8002に書き込み、OCS0103U11に修正「CHANGED」フラグを立てる。
                    if (update_changed)
                    {
                        InsertGridData();//各種REHA, PT, OT, STの項目をgrdPHY8002に挿入

                        InvokeReturnSendReturnDataTable();
                    }
					break;

				case FunctionType.Query:
                    
					break;

                case FunctionType.Print:
                    
                    //this.btnList.PerformClick(FunctionType.Update);
                    if (this.grdPHY8002.GetRowState(this.grdPHY8002.CurrentRowNumber) == DataRowState.Unchanged)
                    {
                        this.dwIraisyo.Reset();
                        this.setPrintData();

                        this.dwIraisyo.Modify("p_1.filename=" + "\"C:\\IHIS\\REHAImages\\REHA\\" + this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "image") + "\"");

                        int currRow = layIraisyo.InsertRow(-1);

                        //依頼データ
                        foreach (DataColumn cl in grdPHY8002.LayoutTable.Columns)
                        {
                            if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName))
                            {
                                if (cl.ColumnName == "io_kubun")
                                {
                                    if (grdPHY8002.GetItemString(0, cl.ColumnName) == "O")
                                        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = Resources.TEXT12;
                                    else if (grdPHY8002.GetItemString(0, cl.ColumnName) == "I")
                                        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = Resources.TEXT13;
                                }
                                else if (cl.ColumnName == "sinryouka")
                                {
                                    //if (UserInfo.UserGubun != UserType.Doctor)
                                    //{
                                    //    if(grdPHY8002.GetItemString(0, cl.ColumnName) == "CK")
                                    //        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = "代行オーダー(未承認)";
                                    //    else
                                    //        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = "部門オーダー";
                                    //}
                                    //else
                                    //{
                                        //string str =  " SELECT A.GWA_NAME "
                                        //            + "   FROM VW_BAS_GWA A "
                                        //            + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                        //            + "    AND A.START_DATE <= TO_DATE(NVL(TRIM('" + EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/") + "') ,TO_CHAR(SYSDATE, 'YYYY/MM/DD')), 'YYYY/MM/DD') "
                                        //            + "    AND A.END_DATE   >= TO_DATE(NVL(TRIM('" + EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/") + "') ,TO_CHAR(SYSDATE, 'YYYY/MM/DD')), 'YYYY/MM/DD') "
                                        //            + "    AND A.GWA = '" + grdPHY8002.GetItemString(0, cl.ColumnName) + "' ";
                                        //object obj = Service.ExecuteScalar(str);

                                    PHY8002U01BtnPrintGetGwaNameArgs argsSinryouka = new PHY8002U01BtnPrintGetGwaNameArgs();
                                    argsSinryouka.ColName = "sinryouka";
                                    argsSinryouka.StartDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
                                    argsSinryouka.EndDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
                                    argsSinryouka.Gwa = grdPHY8002.GetItemString(0, cl.ColumnName);
                                    PHY8002U01BtnPrintGetGwaNameResult resultSinryouka =
                                        CloudService.Instance
                                            .Submit
                                            <PHY8002U01BtnPrintGetGwaNameResult, PHY8002U01BtnPrintGetGwaNameArgs>(argsSinryouka);

                                        //layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = obj.ToString();
                                    if (resultSinryouka.ExecutionStatus == ExecutionStatus.Success)
                                    {
                                        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = resultSinryouka.GwaName;
                                    }
                                    //}
                                }
                                else if (cl.ColumnName == "su_3_1" || cl.ColumnName == "su_3_2")
                                {
                                    if (grdPHY8002.GetItemString(0, cl.ColumnName) != "")
                                    {
                                        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = "Y";
                                        layIraisyo.LayoutTable.Rows[currRow]["su_3"] = "Y";
                                        layIraisyo.LayoutTable.Rows[currRow]["kg"] = grdPHY8002.GetItemString(0, cl.ColumnName);
                                    }
                                }
                                else if (cl.ColumnName == "su_2_4")
                                {
                                    if (grdPHY8002.GetItemString(0, cl.ColumnName) != "")
                                    {
                                        layIraisyo.LayoutTable.Rows[currRow]["su_etc"] = "Y";
                                        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = grdPHY8002.GetItemString(0, cl.ColumnName);
                                    }
                                }
                                else if (cl.ColumnName == "tantoui" || cl.ColumnName == "sindanisi")
                                {
                                    string doctor_name = "";
                                    this.mOrderBiz.LoadColumnCodeName("gwa_doctor", this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "sinryouka"), this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "sinryouka") + this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, cl.ColumnName), EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"), ref doctor_name);
                                    layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = doctor_name;
                                }
                                else if (cl.ColumnName == "irai_date")
                                {
                                    string irai_date = this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "irai_date");

                                    //string cmdSQL = "SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1', '" + irai_date + "') FROM SYS.DUAL";

                                    //object result = Service.ExecuteScalar(cmdSQL);

                                    PHY8002U01BtnPrintGetGwaNameArgs argsIraiDate = new PHY8002U01BtnPrintGetGwaNameArgs();
                                    argsIraiDate.ColName = "irai_date";
                                    argsIraiDate.IraiDate = irai_date;
                                    PHY8002U01BtnPrintGetGwaNameResult resultIraiDate =
                                        CloudService.Instance
                                            .Submit
                                            <PHY8002U01BtnPrintGetGwaNameResult, PHY8002U01BtnPrintGetGwaNameArgs>(argsIraiDate);

                                    if (resultIraiDate.ExecutionStatus == ExecutionStatus.Success)
                                    {
                                        //layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = result.ToString();
                                        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = resultIraiDate.GwaName;
                                    }
                                }
                                else if ((cl.ColumnName == "yoin_start_date" || cl.ColumnName == "yoin_sindan_date") && grdPHY8002.GetItemString(0, cl.ColumnName) != "")
                                    layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = grdPHY8002.GetItemString(0, cl.ColumnName).Substring(0, 10);
                                else
                                    layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = grdPHY8002.GetItemString(0, cl.ColumnName);
                            }
                        }

                        //障害データ
                        if (this.grdPHY8004.RowCount > 0)
                        {
                            string disability_name = "";
                            disability_name = txtDisability.GetDataValue();

                            for (int i = 0; i < this.grdPHY8004.RowCount; i++)
                            {
                                if (TypeCheck.IsNull(disability_name))
                                    disability_name = disability_name + this.grdPHY8004.GetItemString(i, "syougaimei");
                                else
                                    disability_name = disability_name + "\r\n" + this.grdPHY8004.GetItemString(i, "syougaimei");
                            }
                            txtDisability.SetEditValue(disability_name);
                            if (!TypeCheck.IsNull(txtDisability.Text)) txtDisability.SelectionStart = disability_name.Length;
                            txtDisability.ScrollToCaret();

                            layIraisyo.LayoutTable.Rows[currRow]["disability"] = txtDisability.GetDataValue();
                        }

                        //傷病データ
                        for (int i = 0; i < this.grdPHY8003.RowCount; i++)
                        {
                            foreach (DataColumn cl in grdPHY8003.LayoutTable.Columns)
                            {
                                if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi" || cl.ColumnName == "display_syoubyoumei")
                                {
                                    if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName + (i + 1).ToString()))
                                    {
                                        if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi")
                                        {
                                            string date = grdPHY8003.GetItemString(i, cl.ColumnName);
                                            layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6);
                                        }
                                        else
                                            layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = grdPHY8003.GetItemString(i, cl.ColumnName);
                                    }
                                }
                            }
                        }
                        //患者データ
                        layIraisyo.LayoutTable.Rows[currRow]["kanji_name"]  = patBox.SuName;
                        layIraisyo.LayoutTable.Rows[currRow]["kana_name"]   = patBox.SuName2;
                        layIraisyo.LayoutTable.Rows[currRow]["birth_day"]   = patBox.Birth;
                        layIraisyo.LayoutTable.Rows[currRow]["address"]     = patBox.Address1;
                        layIraisyo.LayoutTable.Rows[currRow]["age"]         = patBox.YearAge;

                        if(patBox.Sex == "M")
                            layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.TEXT17;
                        else
                            layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.TEXT18;

                        //病院データ
//                        BindVarCollection bindVars_hosp = new BindVarCollection();
//                        string strCmd_hosp = @"SELECT A.YOYANG_NAME
//                                                      ,A.SIMPLE_YOYANG_NAME
//                                                      ,A.TEL
//                                                      ,A.HOMEPAGE
//                                                  FROM BAS0001 A 
//                                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                                   AND SYSDATE BETWEEN A.START_DATE 
//                                                                   AND A.END_DATE ";
//                        bindVars_hosp.Add("f_hosp_code", mHospCode);

//                        DataTable dt_hosp = Service.ExecuteDataTable(strCmd_hosp, bindVars_hosp);

                        PHY8002U01BtnPrintGetDataWindowArgs argsDW = new PHY8002U01BtnPrintGetDataWindowArgs();
                        PHY8002U01BtnPrintGetDataWindowResult resultDW =
                            CloudService.Instance
                                .Submit<PHY8002U01BtnPrintGetDataWindowResult, PHY8002U01BtnPrintGetDataWindowArgs>(
                                    argsDW);

                        if (resultDW.ExecutionStatus == ExecutionStatus.Success)
                        {
                            //if (dt_hosp.Rows.Count > 0)
                            if (resultDW.InfoList.Count > 0)
                            {
                                //layIraisyo.LayoutTable.Rows[currRow]["yoyang_name"] =
                                //    dt_hosp.Rows[0]["YOYANG_NAME"].ToString();

                                layIraisyo.LayoutTable.Rows[currRow]["yoyang_name"] =
                                    resultDW.InfoList[0].YoyangName;
                                //layIraisyo.LayoutTable.Rows[currRow]["jaedan_name"] = dt_hosp.Rows[0]["SIMPLE_YOYANG_NAME"].ToString();
                            }
                        }
                        this.dwIraisyo.FillData(this.layIraisyo.LayoutTable);

                        try
                        {
                            for (int i = 0; i < print_cnt; i++)
                            {
                                this.dwIraisyo.Print(true);
                            }
                            //自動出力用
                            if (this.mAutoColseYN == "Y")
                                this.Close();
                        }
                        catch
                        {
                            this.Close();
                        }
                    }
                    else
                        XMessageBox.Show(Resources.TEXT19,Resources.TEXT9);
                    
                    break;
                case FunctionType.Process:
                    //依頼をコピーしリターンする。
                    this.OpenScreen_OCS3003Q10(this.mBunho, this.mOrder_date);
                    break;
				default:
					break;
			}
		}
        private void setPrintData()
        {

        }
        private bool ValidateCheck()
        {
            // 依頼を出す時一つ以上の傷病が必要。
            string pMsg = "";
            string pCap = "";
            bool result = true;

            if (  this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "pt_flag") != "Y"
               && this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "ot_flag") != "Y"
               && this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "st_flag") != "Y"
               && this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "bu_flag") != "Y")
            {
                pMsg = Resources.TEXT20;
                pCap = Resources.TEXT9;
                result = false;
            }

            if (this.grdPHY8003.RowCount <= 0)
            {
                pMsg = Resources.TEXT21;
                pCap = Resources.TEXT9;
                result = false;
            }
            else if (int.Parse(this.cboNissuu.GetDataValue()) <= -1)
            {
                pMsg = Resources.TEXT22;
                pCap = Resources.TEXT9;
                result = false;
            }
            else if (int.Parse(this.dptKaisibi.GetDataValue().ToString().Replace("/", "")) < int.Parse(this.mOrder_date.Replace("/", "")))
            {
                pMsg = Resources.TEXT23;
                pCap = Resources.TEXT9;
                result = false;
            }
            else if (   this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "genbyoureki")      == ""
                     || this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "yoin_start_date")  == ""
                     || this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "yoin_sindan_date") == "")
            {
                pMsg = Resources.TEXT24;
                pCap = Resources.TEXT9;
                result = false;
            }
            //else if(this.IsHassyoubiSameSindanbi(this.grdPHY8003))
            //{
            //    pMsg = "廃用の場合は発症日と診断日が同じものは登録することができません。";
            //    pCap = "確認";
            //    result = false;
            //}

            if (result == false)
            {
                XMessageBox.Show(pMsg, pCap);
                this.SetMsg(pMsg, MsgType.Error);
            }


            // 指示事項、注意事項警告
            if (result)
            {
                if (this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "consult_comment") == "")
                {
                    pMsg = Resources.TEXT25;
                    pCap = Resources.TEXT9;
                    if (XMessageBox.Show(pMsg, pCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        result = false;
                }
            }

            // 目標欄警告
            if (result)
            {
                if (this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "objective") == "")
                {
                    pMsg = Resources.TEXT26;
                    pCap = Resources.TEXT9;
                    if (XMessageBox.Show(pMsg, pCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        result = false;
                }
            }

            if (result)
            {
                for (int i = 0; i < this.grdPHY8003.RowCount; i++)
                {
                    if (int.Parse(this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "yoin_start_date").Replace("/", "").Replace("-", "")) >= int.Parse(this.grdPHY8003.GetItemString(i, "hassyoubi")))
                    {
                        pMsg = Resources.TEXT27;
                        pCap = Resources.TEXT9;
                        XMessageBox.Show(pMsg, pCap, MessageBoxIcon.Warning);
                        result = false;
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// 廃用の場合は発症日と診断日が違うので同じなのかをチェック
        /// </summary>
        /// <param name="aGrid"></param>
        private bool IsHassyoubiSameSindanbi(XEditGrid aGrd)
        {
            for (int i = 0; i < aGrd.RowCount; i++)
            {
                if (aGrd.GetItemString(i, "hassyoubi") == aGrd.GetItemString(i, "sindanbi"))
                    return true;
            }
            return false;
        }
        // 依頼件において実績データが存在するのか確認。
        // あればtrue, なければfalse
        private bool IsJissekiData()
        {
            SingleLayout layJissekiData = new SingleLayout();
            layJissekiData.ParamList = new List<string>(new String[] { "f_in_out_gubun", "f_fkocs" });
            string fk_ocs = this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "fk_ocs");

            if (fk_ocs == "")
                return false;

            layJissekiData.LayoutItems.Add("CNT");
            //            SELECT A.SUNAB_YN, A.PKOCS1003, A.* FROM OCS1003 A WHERE A.SORT_FKOCSKEY = '7898669';

            if (this.mInOutGubun == "O")
            {
//                layJissekiData.QuerySQL = @"SELECT COUNT(*) CNT
//                                              FROM OCS1003 A 
//                                             WHERE A.HOSP_CODE = :f_hosp_code
//                                               AND A.SORT_FKOCSKEY = :f_fk_ocs ";
                layJissekiData.SetBindVarValue("f_in_out_gubun", "O");
            }
            else
            {
//                layJissekiData.QuerySQL = @"SELECT COUNT(*) CNT
//                                              FROM OCS2003 A 
//                                             WHERE A.HOSP_CODE = :f_hosp_code
//                                               AND A.SORT_FKOCSKEY = :f_fk_ocs ";
                layJissekiData.SetBindVarValue("f_in_out_gubun", "X");
            }

            layJissekiData.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layJissekiData.SetBindVarValue("f_fkocs", fk_ocs);

            layJissekiData.ExecuteQuery = LoadDataLayJisseki;
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
            
            //PT
            for (int i = 0; i < this.grdPT.RowCount; i++)
            {
                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "pt" + (i + 1).ToString(), "");
            }
            row = 1;
            for (int i = 0; i < this.grdPT.RowCount; i++)
            {
                data = this.grdPT.GetItemString(i, "code_name");
                selected = this.grdPT.GetItemString(i, "select");
                columnNo = "pt" + row.ToString();
                if (selected == "Y")
                {
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, columnNo, data);
                    row++;
                }
            }
            //OT
            for (int i = 0; i < this.grdOT.RowCount; i++)
            {
                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "ot" + (i + 1).ToString(), "");
            }
            row = 1;
            for (int i = 0; i < this.grdOT.RowCount; i++)
            {
                data = this.grdOT.GetItemString(i, "code_name");
                selected = this.grdOT.GetItemString(i, "select");
                columnNo = "ot" + row.ToString();
                if (selected == "Y")
                {
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, columnNo, data);
                    row++;
                }
            }
            //ST
            for (int i = 0; i < this.grdST.RowCount; i++)
            {
                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "st" + (i + 1).ToString(), "");
            }
            row = 1;
            for (int i = 0; i < this.grdST.RowCount; i++)
            {
                data = this.grdST.GetItemString(i, "code_name");
                selected = this.grdST.GetItemString(i, "select");
                columnNo = "st" + row.ToString();
                if (selected == "Y")
                {
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, columnNo, data);
                    row++;
                }
            }
        }
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Delete:
                    this.grdPHY8003.DeleteRow(this.grdPHY8003.CurrentRowNumber);
                    break;

                case FunctionType.Update:
                    DataRowState rowState = this.grdPHY8002.GetRowState(this.grdPHY8002.CurrentRowNumber);
                    if (!this.ValidateCheck())
                    {
                        return;
                    }

                    //Add アップデータ不可能なケース設定
                    if (this.IsJissekiData())
                        break;

                    // 트랜잭션 시작
                    try
                    {
                        //Service.BeginTransaction();

                        //if (e.IsSuccess)
                        SavePHY8002U01();
                        
                            //if (this.grdPHY8003.SaveLayout() == true)
                            if (saveLayoutResult.Result8003 == true)
                            {

                            }
                            else
                            {
                                //Service.RollbackTransaction();

                                this.mMsg = Resources.TEXT28 + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                mIsUpdateSuccess = false;

                                return;
                            }

                            //if (this.grdPHY8004.SaveLayout() == true)
                            if (saveLayoutResult.Result8004 == true)
                            {

                            }
                            else
                            {
                                //Service.RollbackTransaction();
                                this.mMsg = Resources.TEXT29 + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                mIsUpdateSuccess = false;

                                return;
                            }
                            //if (this.leaveCnt >= 1 || rowState != DataRowState.Unchanged)
                            //    SetPHY8002Info();

                            //if (this.grdPHY8002.SaveLayout() == true)
                            if (this.saveLayoutResult.Result8002 == true)
                            {
                                //依頼書の修正があった場合のみ依頼書を出力する。（登録の場合はOCS1003P01から出力される。）
                                if (rowState == DataRowState.Modified && this.copyPkocskey == "") btnList.PerformClick(FunctionType.Print);
                                this.AutoCheckInputLayoutChanged = false;
                                Close();
                            }
                            else
                            {
                                //Service.RollbackTransaction();

                                this.mMsg = Resources.TEXT30 + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                mIsUpdateSuccess = false;

                                return;
                            }
                            
                            

                        
                    }
                    catch (Exception ex)
                    {
                        //Service.RollbackTransaction();

                        mIsUpdateSuccess = false;

                        return;
                    }

                    //Service.CommitTransaction();  // 커밋

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

        //    param.Add("reha_consult_date", this.grdPHY8002);

        //    ((XScreen)this.Opener).Command(this.Name, param);
        //}

        //#endregion
        

		#region OnCommad override
		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch(command.Trim())
            {
                #region
                case "OCS0221Q01": //OCS 상용어

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

							case "btnJisi":
                                startIndex = txtConsult_comment.SelectionStart;

                                setText = txtConsult_comment.Text.Substring(0, startIndex) + commandParam["COMMENT"].ToString()
                                    + txtConsult_comment.Text.Substring(startIndex);

                                txtConsult_comment.SetEditValue(setText);

                                txtConsult_comment.Focus();
                                if (!TypeCheck.IsNull(txtConsult_comment.Text)) txtConsult_comment.SelectionStart = txtConsult_comment.GetDataValue().Length;
                                txtConsult_comment.ScrollToCaret();
                                break;
                            case "btnObjective":
                                startIndex = txtObjective.SelectionStart;

                                setText = txtObjective.Text.Substring(0, startIndex) + commandParam["COMMENT"].ToString()
                                    + txtObjective.Text.Substring(startIndex);

                                txtObjective.SetEditValue(setText);

                                txtObjective.Focus();
                                if (!TypeCheck.IsNull(txtObjective.Text)) txtObjective.SelectionStart = txtObjective.GetDataValue().Length;
                                txtObjective.ScrollToCaret();
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
                            case "G":
                                sang_name = txtGenbyoureki.GetDataValue();
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
                            case "G":
                                txtGenbyoureki.Focus();
                                txtGenbyoureki.SetEditValue(sang_name);

                                if (!TypeCheck.IsNull(txtGenbyoureki.Text)) txtGenbyoureki.SelectionStart = sang_name.Length;
                                txtGenbyoureki.ScrollToCaret();
                                txtGenbyoureki.Focus();
                                break;
                        }

                    }
                    break;

                case "OUTSANGQ00":

                    string strsql = "";
                    object retVal = "";

                    //if (this.mInOutGubun == "I")
                    //{
                    //    strsql = "SELECT FN_INP_LOAD_LAST_IPWON_DATE('" + mBunho + "') FROM SYS.DUAL";
                    //    retVal = Service.ExecuteScalar(strsql);
                    //}



                    if (commandParam.Contains("OUTSANG") && (MultiLayout)commandParam["OUTSANG"] != null &&
                        ((MultiLayout)commandParam["OUTSANG"]).RowCount > 0)
                    {
                        string sang_name = "";
                        //string sang_start_date = "";
                        //string sang_jindan_date = "";
                        this.txtGenbyoureki.Text = "";
                        this.txtYoin_sindan_date.Text = "";
                        this.txtYoin_start_date.Text = "";
                        switch (this.mReturnControl)
                        {
                            case "G":
                                if (txtGenbyoureki.GetDataValue() != "")
                                {
                                    sang_name = txtGenbyoureki.GetDataValue();
                                }
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
                            {
                                
                                if (this.mReturnControl == "G")
                                {
                                    //if (this.mInOutGubun == "I")
                                    //{
                                    //    if (retVal.ToString() != "")
                                    //    {
                                    //        if (DateTime.Parse(retVal.ToString()) < DateTime.Parse(((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_start_date")))
                                    //        {
                                    //            XMessageBox.Show("廃用依頼書の場合、廃用にもたらすに至った原因(" + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_name") + ") の発症日は入院日(" + DateTime.Parse(retVal.ToString()).ToString("yyyy/MM/dd") + ")以下ではなければなりません。ご確認ください。", "確認");

                                    //            continue;
                                    //        }
                                    //    }
                                    //}

                                    this.txtYoin_start_date.Text = (((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_start_date"));
                                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "yoin_start_date", this.txtYoin_start_date.Text);
                                    this.txtYoin_sindan_date.Text = (((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_jindan_date"));
                                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "yoin_sindan_date", this.txtYoin_sindan_date.Text);
                                }

                                sang_name = sang_name + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name");
                            }
                            else
                                sang_name = sang_name + "\r\n" + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name");
                            //this.txtYoin_sindan_date.Focus();
                            //this.txtYoin_start_date.Focus();
                            //this.txtGenbyoureki.Focus();
                            //else
                            //{
                            //    sang_name = sang_name + "," + sang_start_date + "," + sang_jindan_date; 
                            //    sang_name = sang_name + "\r\n" + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name");
                            //    sang_start_date = ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_start_date");
                            //    sang_jindan_date = ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_jindan_date");
                            //}
                        }

                        
                        switch (this.mReturnControl)
                        {
                            case "G":
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
                                    // 入院日と診断名の診断日のチェック
                                    // 廃用の診断名の診断日は入院日以降ではなければならないとの病院の条件
                                    // 入院オーダのみ

                                    //if(this.mInOutGubun == "I")
                                    //{
                                    //    if (retVal.ToString() != "")
                                    //    {
                                    //        if (DateTime.Parse(retVal.ToString()) >= DateTime.Parse(((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_start_date")))
                                    //        {
                                    //            XMessageBox.Show("廃用依頼書の場合、診断名(" + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_name") + ") の発症日は入院日(" + DateTime.Parse(retVal.ToString()).ToString("yyyy/MM/dd") + ")超過ではなければなりません。ご確認ください。", "確認");

                                    //            continue;
                                    //        }
                                    //    }
                                        
                                    //}
                                    if (dupSangChk(((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "pkoutsang")))
                                        continue;

                                    this.grdPHY8003.InsertRow(-1);
                                    int currRow = this.grdPHY8003.CurrentRowNumber;
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "syoubyoumei_code", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_code"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "hassyoubi", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_start_date").Replace("/", ""));
                                    //廃用の依頼の場合は診断日＝依頼日（2012/11/19リハビリ科の田代さんに確認済み）
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "sindanbi", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_jindan_date").Replace("/", ""));
                                    //this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "sindanbi", (this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "irai_date")).Replace("/", ""));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "display_syoubyoumei", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "syoubyoumei", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_name"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "hosp_code", EnvironInfo.HospCode);
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "sys_date", EnvironInfo.GetSysDateTime());
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "kanja_no", mBunho);
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "data_kubun", "I");
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "sinryouka", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "gwa"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "io_kubun", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "io_gubun"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "user_id", UserInfo.UserID);
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "irai_date", this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "irai_date"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "fk_ocs_irai", this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "pkphy8002"));
                                    //this.grdIFS8003.SetItemValue(this.grdIFS8003.CurrentRowNumber, "pk_phy_syoubyou", int.Parse(t_chk.ToString()));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "pre_modifier_name", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "pre_modifier_name"));
                                    this.grdPHY8003.SetItemValue(this.grdPHY8003.CurrentRowNumber, "post_modifier_name", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "post_modifier_name"));
                                    this.grdPHY8003.SetItemValue(currRow, "fkoutsang", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "pkoutsang"));
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
                                    //if (this.IsHassyoubiSameSindanbi(this.grdPHY8003))
                                    //{
                                    //    string pMsg = "廃用の場合は発症日と診断日が同じものは登録することができません。";
                                    //    this.SetMsg(pMsg, MsgType.Error);
                                    //}
                                }
                                break;
                        }
                    }
                    break;
                case "CHT0113Q00":
                    MultiLayout grd = (MultiLayout)commandParam["CHT0113"];
                    if (commandParam.Contains("CHT0113") && grd != null && grd.RowCount > 0)
                    {
                        switch (this.mReturnControl)
                        {
                            case "D":
                                for (int i = 0; i < grd.RowCount; i++)
                                {
                                    if (dupDisabilityChk(grd.GetItemString(i, "pkcht0113")))
                                        continue;

                                    this.grdPHY8004.InsertRow(-1);
                                    int currRow = this.grdPHY8004.CurrentRowNumber;

                                    //this.grdPHY8004.SetItemValue(currRow, "pk_phy_syougai", grd.GetItemString(currRow, "")); pkkeyは保存する時に付与

                                    this.grdPHY8004.SetItemValue(currRow, "sys_date",       EnvironInfo.GetSysDateTime());
                                    this.grdPHY8004.SetItemValue(currRow, "user_id",        UserInfo.UserID);
                                    this.grdPHY8004.SetItemValue(currRow, "upd_date",       EnvironInfo.GetSysDateTime());
                                    this.grdPHY8004.SetItemValue(currRow, "hosp_code",      EnvironInfo.HospCode);
                                    this.grdPHY8004.SetItemValue(currRow, "data_kubun",     "I");
                                    this.grdPHY8004.SetItemValue(currRow, "kanja_no",       mBunho);
                                    this.grdPHY8004.SetItemValue(currRow, "syougai_id",     grd.GetItemString(i, "disability_code"));
                                    this.grdPHY8004.SetItemValue(currRow, "syougaimei",     grd.GetItemString(i, "disability_name"));
                                    this.grdPHY8004.SetItemValue(currRow, "fkcht0113",      grd.GetItemString(i, "pkcht0113"));
                                    this.grdPHY8004.SetItemValue(currRow, "fk_ocs_irai",    this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "pkphy8002"));
                                }
                                break;
                        }
                    }
                    break;

                case "OCS3003Q10": //コピーされた依頼書

                    #region [コピーしてからのデータコントロール]

                    int currRowIndex = -1;

                    this.copyPkocskey = commandParam["OCS3003Q10"].ToString(); //コピーする依頼のocskey

                    //LIBで生成されたOCSKEYを臨時保存してコピーのOCSKEYをQUERYするためにmFkocsに挿入。
                    //QUERYが終わったらもとに戻してLIBで生成されたKEYでPHY8003にINSERTする。
                    string imsiFkocs = this.mFkocs; //追加するocskeyを臨時保存
                    this.mFkocs = copyPkocskey;

                    //DataTable dtTemp = this.grdPHY8002.LayoutTable.Clone();
                    //this.grdPHY8002.QueryLayout(false);
                    //dtTemp.ImportRow(this.grdPHY8002.LayoutTable.Rows[0]);

                    this.DataSetting();
                    this.mFkocs = imsiFkocs;


                    //新しい依頼キーを付与
                    //string cmdText = " SELECT PHY8002_SEQ.NEXTVAL "
                    //               + "   FROM SYS.DUAL ";
                    //object t_chk = Service.ExecuteScalar(cmdText);

                    PHY8002U01GetPhy8002SeqArgs args = new PHY8002U01GetPhy8002SeqArgs();
                    PHY8002U01GetPhy8002SeqResult result =
                        CloudService.Instance.Submit<PHY8002U01GetPhy8002SeqResult, PHY8002U01GetPhy8002SeqArgs>(args);

                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        //this.mPKPHY8002 = t_chk.ToString();
                        this.mPKPHY8002 = result.Seq;
                    }

                    currRowIndex = this.grdPHY8002.CurrentRowNumber;

                    //開始日を基本オーダ日付で設定
                    this.dptKaisibi.SetEditValue(this.mOrder_date);
                    this.grdPHY8002.SetItemValue(currRowIndex, "kaisibi", this.mOrder_date);
                    this.grdPHY8002.SetItemValue(currRowIndex, "irai_date", this.mOrder_date.Replace("/", "").Replace("-", ""));
                    this.grdPHY8002.SetItemValue(currRowIndex, "fk_ocs", this.mFkocs);
                    this.grdPHY8002.SetItemValue(currRowIndex, "pkphy8002", this.mPKPHY8002);
                    this.grdPHY8002.SetItemValue(currRowIndex, "sys_date", EnvironInfo.GetSysDateTime());
                    this.grdPHY8002.SetItemValue(currRowIndex, "kanja_no", this.OpenParam["bunho"].ToString());
                    this.grdPHY8002.SetItemValue(currRowIndex, "sinryouka", UserInfo.Gwa);
                    this.grdPHY8002.SetItemValue(currRowIndex, "sindanisi", UserInfo.UserID);
                    this.grdPHY8002.SetItemValue(currRowIndex, "tantoui", UserInfo.UserID);
                    this.grdPHY8002.SetItemValue(currRowIndex, "io_kubun", this.mInOutGubun);


                    //診断名のfk_ocs_iraiキーを新しいPKPHY8002に変える
                    for (int i = 0; i < this.grdPHY8003.RowCount; i++)
                    {
                        this.grdPHY8003.SetItemValue(i, "fk_ocs_irai", this.mPKPHY8002);
                    }

                    //障害名のfk_ocs_iraiキーを新しいPKPHY8002に変える
                    for (int i = 0; i < this.grdPHY8004.RowCount; i++)
                    {
                        this.grdPHY8004.SetItemValue(i, "fk_ocs_irai", this.mPKPHY8002);
                    }

                    break;
                    #endregion
                #endregion
            }

			return base.Command (command, commandParam);
		}

		#endregion
        /// <summary>
        /// CHT0113Q00から傷病を取得してPHY8004にINSERTする際にすでにあるものは排除するため
        /// </summary>
        /// <param name="aPkoutsang">CHT0113のPRIMARYKEY</param>
        private bool dupDisabilityChk(string aPkcht0113)
        {
            for (int i = 0; i < this.grdPHY8004.RowCount; i++)
            {
                if (this.grdPHY8004.GetItemString(i, "fkcht0113") == aPkcht0113)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// OUTSANGQ00から傷病を取得してPHY8003にINSERTする際にすでにあるものは排除するため
        /// </summary>
        /// <param name="aPkoutsang">OUTSANGのPRIMARYKEY</param>
        private bool dupSangChk(string aPkoutsang)
        {
            for (int i = 0; i < this.grdPHY8003.RowCount; i++)
            {
                if (this.grdPHY8003.GetItemString(i, "fkoutsang") == aPkoutsang)
                {
                    return true;
                }
            }
            return false;
        }

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

        private void grdPHY8002_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPHY8002.SetBindVarValue("f_fk_ocs", this.mFkocs);
            grdPHY8002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
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
                    else if (obj.GetType().Name.ToString().IndexOf("XDictComboBox") >= 0)
                    {
                        colName = ((XDictComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XDictComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
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
                    else if (obj.GetType().Name.ToString().IndexOf("XDictComboBox") >= 0)
                    {
                        colName = ((XDictComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XDictComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
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
                        grdPHY8002.SetItemValue(grdPHY8002.CurrentRowNumber, "su_3_1", "");
                    grdPHY8002.SetItemValue(grdPHY8002.CurrentRowNumber, "su_3_2", "");
                    if (this.rbtSu_3_1.Checked == true)
                        grdPHY8002.SetItemValue(grdPHY8002.CurrentRowNumber, "su_3_1", e.DataValue.ToString());
                    else
                        grdPHY8002.SetItemValue(grdPHY8002.CurrentRowNumber, "su_3_2", e.DataValue.ToString());
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
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private PHY8002U01 parent = null;

//            public XSavePerformer(PHY8002U01 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = ""; //PHY8002
//                string strCmd = "";  //SCAN001
//                object t_chk = "";
//                item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                
//                item.BindVarList.Add("f_fk_ocs", parent.mFkocs);
//                item.BindVarList.Add("f_io_kubun", parent.mInOutGubun);
//                //item.BindVarList.Add("f_pk_ocs_irai", parent.mInOutGubun);

//                switch (callerID)
//                {
//                        //依頼grid
//                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                if (UserInfo.UserGubun != UserType.Doctor)
//                                {
////                                    string cmd = @" SELECT A.GWA
////                                         , SUBSTR(A.DOCTOR, LENGTH(A.DOCTOR) - 4) DOCTOR
////                                      FROM VW_OCS_INP1001_RES A
////                                     WHERE A.BUNHO = :f_bunho
////                                     UNION
////                                    SELECT A.GWA
////                                         , SUBSTR(A.DOCTOR, LENGTH(A.DOCTOR) - 4) DOCTOR
////                                      FROM OUT1001 A
////                                     WHERE A.HOSP_CODE   = :f_hosp_code
////                                       AND A.BUNHO       = :f_bunho
////                                       AND A.NAEWON_DATE = :f_naewon_date";

////                                    BindVarCollection bind = new BindVarCollection();
////                                    bind.Add("f_bunho", parent.mBunho);
////                                    bind.Add("f_naewon_date", parent.mOrder_date);
////                                    bind.Add("f_hosp_code", EnvironInfo.HospCode);

////                                    DataTable Dt = Service.ExecuteDataTable(cmd, bind);

////                                    if (Dt.Rows.Count > 0)
////                                    {
////                                        item.BindVarList.Remove("f_sinryouka");
////                                        item.BindVarList.Remove("f_sindanisi");
////                                        item.BindVarList.Remove("f_tantoui");

////                                        item.BindVarList.Add("f_sinryouka", Dt.Rows[0]["gwa"].ToString());
////                                        item.BindVarList.Add("f_sindanisi", Dt.Rows[0]["doctor"].ToString());
////                                        item.BindVarList.Add("f_tantoui", Dt.Rows[0]["doctor"].ToString());
////                                    }
//                                    item.BindVarList.Remove("f_sinryouka");
//                                    item.BindVarList.Remove("f_sindanisi");
//                                    item.BindVarList.Remove("f_tantoui");

//                                    item.BindVarList.Add("f_sinryouka", parent.mApproveDoctorGWA);
//                                    item.BindVarList.Add("f_sindanisi", parent.mApproveDoctorID);
//                                    item.BindVarList.Add("f_tantoui", parent.mApproveDoctorID);
//                                }

//                                //依頼キー
//                                //if (item.BindVarList["f_fk_ocs_irai"].VarValue == "")
//                                //{
//                                //    cmdText = " SELECT PHY8002_IRAI_SEQ.NEXTVAL "
//                                //            + "   FROM SYS.DUAL ";

//                                //    t_chk = Service.ExecuteScalar(cmdText);

//                                //    item.BindVarList.Remove("f_pk_ocs_irai");
//                                //    item.BindVarList.Add("f_pk_ocs_irai", t_chk.ToString());

//                                //}

//                                //item.BindVarList.Add("f_data_kubun", "I");
//                                // 키가 입력되지 않은경우 키를 따야함..
//                                //ROW単位キー
//                                if (item.BindVarList["f_pkphy8002"].VarValue == "")
//                                {
//                                    cmdText = " SELECT PHY8002_SEQ.NEXTVAL "
//                                            + "   FROM SYS.DUAL ";

//                                    t_chk = Service.ExecuteScalar(cmdText);

//                                    item.BindVarList.Remove("f_pkocskey");
//                                    item.BindVarList.Add("f_pkphy8002", t_chk.ToString());
                                    
//                                }

//                                parent.mPKPHY8002 = item.BindVarList["f_pkphy8002"].VarValue;
//                                ////依頼が修正された時の履歴
//                                //// 시퀀스 가져오기
//                                //if (item.BindVarList["f_r_seq"].VarValue == "")
//                                //{
//                                //    cmdText = " SELECT MAX(R_SEQ)+1 SEQ "
//                                //            + "   FROM PHY8002 "
//                                //            + "  WHERE FK_OCS_IRAI = " + item.BindVarList["f_fk_ocs_irai"].VarValue
//                                //            + "    AND HOSP_CODE = '" + EnvironInfo.HospCode + "' ";
//                                //    t_chk = Service.ExecuteScalar(cmdText);

//                                //    if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
//                                //    {
//                                //        t_chk = "1";
//                                //    }
                                    
                                   
//                                //    item.BindVarList.Remove("f_r_seq");
//                                //    item.BindVarList.Add("f_r_seq", t_chk.ToString());
//                                //}
                                
//                                cmdText = @"INSERT INTO PHY8002 (
//                                                     SYS_DATE,          USER_ID,           HOSP_CODE,            PKPHY8002,
//                                                     FK_OCS,            IO_KUBUN,
//                                                     IRAI_DATE,         KANJA_NO,          SINRYOUKA,            SINDANISI,        TANTOUI,
//                                                     NYUUINNBI,         BYOUTOU_CODE,      BYOUSITU_CODE,        KAISIBI,          NISSUU,
//                                                     KOUMOKU_CODE,      PT1,               PT2,                  PT3,              PT4,
//                                                     PT5,               PT6,               PT7,                  PT8,              PT9,
//                                                     PT10,              OT1,               OT2,                  OT3,              OT4,
//                                                     OT5,               OT6,               OT7,                  OT8,              OT9,
//                                                     OT10,              ST1,               ST2,                  ST3,              ST4,
//                                                     ST5,               ST6,               ST7,                  ST8,              ST9,
//                                                     ST10,              OBJECTIVE,         CONSULT_COMMENT,      GENBYOUREKI,      COMPLICATIONS,
//                                                     TABOO,             STOP_KIJYUN,       FREQUENCY,            INFECTIOUS,       KIOUREKI,
//                                                     SYORI_FLAG,        PT_FLAG,           OT_FLAG,              ST_FLAG,          SYUJYUTUBI,
//                                                     KYUSEIZOUAKUBI,    DISUSE_GASYOU,     DISUSE_ADL,           DISUSE_KAINYU,    DISUSE_KAIZEN,
//	                                                 DISUSE_CONTENTS,   IRAI_KUBUN,        DISUSE_FIMBI,         BU_FLAG,
//                                                     YOIN_START_DATE,   YOIN_SINDAN_DATE,  KE_FLAG,
//                                                     SU_1,              SU_2_1,            SU_2_2,               SU_2_3,           SU_2_4,        
//                                                     SU_3_1,            SU_3_2,            SU_4_1,               SU_4_2,           SU_4_3,
//                                                     IMAGE,             IMAGE_PATH,        IMAGE_SEQ,            CR_TIME)
//                                            values( sysdate,            :f_user_id,         :f_hosp_code,       :f_pkphy8002,
//                                                    :f_fk_ocs,          :f_io_kubun,
//                                                    :f_irai_date,       :f_kanja_no,        :f_sinryouka,       :f_sindanisi,       :f_tantoui,
//                                                    :f_nyuuinnbi,       :f_byoutou_code,    :f_byousitu_code,   :f_kaisibi,         :f_nissuu,
//                                                    :f_koumoku_code,    :f_pt1,             :f_pt2,             :f_pt3,             :f_pt4,
//                                                    :f_pt5,             :f_pt6,             :f_pt7,             :f_pt8,             :f_pt9,
//                                                    :f_pt10,            :f_ot1,             :f_ot2,             :f_ot3,             :f_ot4,
//                                                    :f_ot5,             :f_ot6,             :f_ot7,             :f_ot8,             :f_ot9,
//                                                    :f_ot10,            :f_st1,             :f_st2,             :f_st3,             :f_st4,
//                                                    :f_st5,             :f_st6,             :f_st7,             :f_st8,             :f_st9,
//                                                    :f_st10,            :f_objective,       :f_consult_comment, :f_genbyoureki,     :f_complications, 
//                                                    :f_taboo,           :f_stop_kijyun,     :f_frequency,       :f_infectious,      :f_kioureki, 
//                                                    :f_syori_flag,      :f_pt_flag,         :f_ot_flag,         :f_st_flag,         :f_syujyutubi, 
//                                                    :f_kyuseizouakubi,  :f_disuse_gasyou,   :f_disuse_adl,      :f_disuse_kainyu,   :f_disuse_kaizen,
//                                                    :f_disuse_contents, :f_irai_kubun,      :f_disuse_fimbi,    :f_bu_flag,
//                                                    :f_yoin_start_date, :f_yoin_sindan_date,:f_ke_flag,    
//                                                    :f_su_1,            :f_su_2_1,          :f_su_2_2,          :f_su_2_3,          :f_su_2_4,
//                                                    :f_su_3_1,          :f_su_3_2,          :f_su_4_1,          :f_su_4_2,          :f_su_4_3,
//                                                    :f_image,           :f_image_path,      :f_image_seq,       TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
//                                                    )";

//                                //image save
//                                for (int i = 0; i < parent.grdPHY8002.RowCount; i++)
//                                {
//                                    item.BindVarList.Add("f_pkscan001", parent.mPKSCAN001);
//                                    item.BindVarList.Add("f_fkocs", parent.grdPHY8002.GetItemString(i, "fk_ocs"));
//                                    item.BindVarList.Add("f_system", "REHA");
//                                    item.BindVarList.Add("f_jundal_part", "REHA");
//                                    item.BindVarList.Add("f_kanja_no", parent.mBunho);
//                                    item.BindVarList.Add("f_image_path", item.BindVarList["f_image_path"].VarValue);
//                                    item.BindVarList.Add("f_image", item.BindVarList["f_image"].VarValue);
//                                    item.BindVarList.Add("f_seq", parent.mPKSCAN001);
//                                    item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                                    item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                                    strCmd = @"INSERT INTO SCAN001 (SYS_DATE, UPD_ID, UPD_DATE
//                                                          ,PKSCAN001
//                                                          ,FKOCS
//                                                          ,SYSTEM
//                                                          ,CR_TIME
//                                                          ,JUNDAL_PART
//                                                          ,BUNHO
//                                                          ,IMAGE_PATH
//                                                          ,IMAGE
//                                                          ,SEQ
//                                                          ,SYS_ID
//                                                          ,HOSP_CODE
//                                                        ) VALUES ( SYSDATE
//                                                          ,:f_user_id 
//                                                          ,SYSDATE
//                                                          ,:f_pkscan001
//                                                          ,:f_fkocs
//                                                          ,:f_system
//                                                          ,TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
//                                                          ,'REHA'
//                                                          ,:f_kanja_no
//                                                          ,:f_image_path
//                                                          ,:f_image
//                                                          ,:f_seq
//                                                          ,:f_user_id
//                                                          ,:f_hosp_code) ";

//                                    if (Service.ExecuteNonQuery(strCmd, item.BindVarList))
//                                    {
//                                    }
//                                    else
//                                        XMessageBox.Show(Service.ErrFullMsg);
//                                }

                                                                                                            
//                                break;
//                            case DataRowState.Modified:
//                                if (parent.copyPkocskey != "")
//                                {
//                                    if (item.BindVarList["f_pkphy8002"].VarValue == "")
//                                    {
//                                        cmdText = " SELECT PHY8002_SEQ.NEXTVAL "
//                                                + "   FROM SYS.DUAL ";

//                                        t_chk = Service.ExecuteScalar(cmdText);

//                                        item.BindVarList.Remove("f_pkocskey");
//                                        item.BindVarList.Add("f_pkphy8002", t_chk.ToString());

//                                    }

//                                    parent.mPKPHY8002 = item.BindVarList["f_pkphy8002"].VarValue;

//                                    cmdText = @"INSERT INTO PHY8002 (
//                                                     SYS_DATE,          USER_ID,           HOSP_CODE,            PKPHY8002,
//                                                     FK_OCS,            IO_KUBUN,
//                                                     IRAI_DATE,         KANJA_NO,          SINRYOUKA,            SINDANISI,        TANTOUI,
//                                                     NYUUINNBI,         BYOUTOU_CODE,      BYOUSITU_CODE,        KAISIBI,          NISSUU,
//                                                     KOUMOKU_CODE,      PT1,               PT2,                  PT3,              PT4,
//                                                     PT5,               PT6,               PT7,                  PT8,              PT9,
//                                                     PT10,              OT1,               OT2,                  OT3,              OT4,
//                                                     OT5,               OT6,               OT7,                  OT8,              OT9,
//                                                     OT10,              ST1,               ST2,                  ST3,              ST4,
//                                                     ST5,               ST6,               ST7,                  ST8,              ST9,
//                                                     ST10,              OBJECTIVE,         CONSULT_COMMENT,      GENBYOUREKI,      COMPLICATIONS,
//                                                     TABOO,             STOP_KIJYUN,       FREQUENCY,            INFECTIOUS,       KIOUREKI,
//                                                     SYORI_FLAG,        PT_FLAG,           OT_FLAG,              ST_FLAG,          SYUJYUTUBI,
//                                                     KYUSEIZOUAKUBI,    DISUSE_GASYOU,     DISUSE_ADL,           DISUSE_KAINYU,    DISUSE_KAIZEN,
//	                                                 DISUSE_CONTENTS,   IRAI_KUBUN,        DISUSE_FIMBI,         BU_FLAG,
//                                                     YOIN_START_DATE,   YOIN_SINDAN_DATE,  KE_FLAG,
//                                                     SU_1,              SU_2_1,            SU_2_2,               SU_2_3,           SU_2_4,        
//                                                     SU_3_1,            SU_3_2,            SU_4_1,               SU_4_2,           SU_4_3,
//                                                     IMAGE,             IMAGE_PATH,        IMAGE_SEQ,            CR_TIME)
//                                            values( sysdate,            :f_user_id,         :f_hosp_code,       :f_pkphy8002,
//                                                    :f_fk_ocs,          :f_io_kubun,
//                                                    :f_irai_date,       :f_kanja_no,        :f_sinryouka,       :f_sindanisi,       :f_tantoui,
//                                                    :f_nyuuinnbi,       :f_byoutou_code,    :f_byousitu_code,   :f_kaisibi,         :f_nissuu,
//                                                    :f_koumoku_code,    :f_pt1,             :f_pt2,             :f_pt3,             :f_pt4,
//                                                    :f_pt5,             :f_pt6,             :f_pt7,             :f_pt8,             :f_pt9,
//                                                    :f_pt10,            :f_ot1,             :f_ot2,             :f_ot3,             :f_ot4,
//                                                    :f_ot5,             :f_ot6,             :f_ot7,             :f_ot8,             :f_ot9,
//                                                    :f_ot10,            :f_st1,             :f_st2,             :f_st3,             :f_st4,
//                                                    :f_st5,             :f_st6,             :f_st7,             :f_st8,             :f_st9,
//                                                    :f_st10,            :f_objective,       :f_consult_comment, :f_genbyoureki,     :f_complications, 
//                                                    :f_taboo,           :f_stop_kijyun,     :f_frequency,       :f_infectious,      :f_kioureki, 
//                                                    :f_syori_flag,      :f_pt_flag,         :f_ot_flag,         :f_st_flag,         :f_syujyutubi, 
//                                                    :f_kyuseizouakubi,  :f_disuse_gasyou,   :f_disuse_adl,      :f_disuse_kainyu,   :f_disuse_kaizen,
//                                                    :f_disuse_contents, :f_irai_kubun,      :f_disuse_fimbi,    :f_bu_flag,
//                                                    :f_yoin_start_date, :f_yoin_sindan_date,:f_ke_flag,    
//                                                    :f_su_1,            :f_su_2_1,          :f_su_2_2,          :f_su_2_3,          :f_su_2_4,
//                                                    :f_su_3_1,          :f_su_3_2,          :f_su_4_1,          :f_su_4_2,          :f_su_4_3,
//                                                    :f_image,           :f_image_path,      :f_image_seq,       TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
//                                                    )";

//                                    //image save
//                                    for (int i = 0; i < parent.grdPHY8002.RowCount; i++)
//                                    {
//                                        item.BindVarList.Add("f_pkscan001", parent.mPKSCAN001);
//                                        item.BindVarList.Add("f_fkocs", parent.grdPHY8002.GetItemString(i, "fk_ocs"));
//                                        item.BindVarList.Add("f_system", "REHA");
//                                        item.BindVarList.Add("f_jundal_part", "REHA");
//                                        item.BindVarList.Add("f_kanja_no", parent.mBunho);
//                                        item.BindVarList.Add("f_image_path", item.BindVarList["f_image_path"].VarValue);
//                                        item.BindVarList.Add("f_image", item.BindVarList["f_image"].VarValue);
//                                        item.BindVarList.Add("f_seq", parent.mPKSCAN001);
//                                        item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                                        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);



//                                        //Hashtable inputList = new Hashtable();
//                                        //Hashtable outputList = new Hashtable();

//                                        strCmd = @"INSERT INTO SCAN001 (SYS_DATE, UPD_ID, UPD_DATE
//                                                          ,PKSCAN001
//                                                          ,FKOCS
//                                                          ,SYSTEM
//                                                          ,CR_TIME
//                                                          ,JUNDAL_PART
//                                                          ,BUNHO
//                                                          ,IMAGE_PATH
//                                                          ,IMAGE
//                                                          ,SEQ
//                                                          ,SYS_ID
//                                                          ,HOSP_CODE
//                                                        ) VALUES ( SYSDATE
//                                                          ,:f_user_id 
//                                                          ,SYSDATE
//                                                          ,:f_pkscan001
//                                                          ,:f_fkocs
//                                                          ,:f_system
//                                                          ,TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
//                                                          ,'REHA'
//                                                          ,:f_kanja_no
//                                                          ,:f_image_path
//                                                          ,:f_image
//                                                          ,:f_seq
//                                                          ,:f_user_id
//                                                          ,:f_hosp_code) ";

//                                        if (Service.ExecuteNonQuery(strCmd, item.BindVarList))
//                                        {
                                           
//                                        }
//                                        else
//                                            XMessageBox.Show(Service.ErrFullMsg);
//                                    }

//                                }
//                                else
//                                {
//                                    //PHY8002 ROW SEQUENCE
//                                    if (item.BindVarList["f_pkphy8002"].VarValue == "")
//                                    {
//                                        cmdText = " SELECT PHY8002_SEQ.NEXTVAL "
//                                                    + "   FROM SYS.DUAL ";

//                                        t_chk = Service.ExecuteScalar(cmdText);

//                                        item.BindVarList.Remove("f_pkocskey");
//                                        item.BindVarList.Add("f_pkphy8002", t_chk.ToString());
//                                    }
//                                    parent.mPKPHY8002 = item.BindVarList["f_pkphy8002"].VarValue;

//                                    cmdText = @"UPDATE  PHY8002 
//                                               set  PKPHY8002       = :f_pkphy8002,
//                                                    USER_ID         = :f_user_id,
//                                                    UPD_DATE        = sysdate,
//                                                    IRAI_DATE       = :f_irai_date,
//                                                    KAISIBI         = :f_kaisibi,
//                                                    NISSUU          = :f_nissuu,
//                                                    SU_1            = :f_su_1,
//                                                    SU_2_1          = :f_su_2_1,
//                                                    SU_2_2          = :f_su_2_2,
//                                                    SU_2_3          = :f_su_2_3,
//                                                    SU_2_4          = :f_su_2_4,
//                                                    SU_3_1          = :f_su_3_1,
//                                                    SU_3_2          = :f_su_3_2,
//                                                    SU_4_1          = :f_su_4_1,
//                                                    SU_4_2          = :f_su_4_2,
//                                                    SU_4_3          = :f_su_4_3,
//                                                    PT1             = :f_pt1,
//                                                    PT2             = :f_pt2,
//                                                    PT3             = :f_pt3,
//                                                    PT4             = :f_pt4,
//                                                    PT5             = :f_pt5,
//                                                    PT6             = :f_pt6,
//                                                    PT7             = :f_pt7,
//                                                    PT8             = :f_pt8,
//                                                    PT9             = :f_pt9,
//                                                    PT10            = :f_pt10,
//                                                    OT1             = :f_ot1,
//                                                    OT2             = :f_ot2,
//                                                    OT3             = :f_ot3,
//                                                    OT4             = :f_ot4,
//                                                    OT5             = :f_ot5,
//                                                    OT6             = :f_ot6, 
//                                                    OT7             = :f_ot7, 
//                                                    OT8             = :f_ot8,
//                                                    OT9             = :f_ot9,
//                                                    OT10            = :f_ot10,  
//                                                    ST1             = :f_st1, 
//                                                    ST2             = :f_st2,  
//                                                    ST3             = :f_st3, 
//                                                    ST4             = :f_st4,
//                                                    ST5             = :f_st5, 
//                                                    ST6             = :f_st6,  
//                                                    ST7             = :f_st7,   
//                                                    ST8             = :f_st8,  
//                                                    ST9             = :f_st9,
//                                                    ST10            = :f_st10, 
//                                                    OBJECTIVE       = :f_objective,
//                                                    CONSULT_COMMENT = :f_consult_comment, 
//                                                    GENBYOUREKI     = :f_genbyoureki, 
//                                                    COMPLICATIONS   = :f_complications,
//                                                    TABOO           = :f_taboo,  
//                                                    STOP_KIJYUN     = :f_stop_kijyun, 
//                                                    FREQUENCY       = :f_frequency,  
//                                                    INFECTIOUS      = :f_infectious,
//                                                    KIOUREKI        = :f_kioureki,
//                                                    SYORI_FLAG      = :f_syori_flag, 
//                                                    PT_FLAG         = :f_pt_flag,   
//                                                    OT_FLAG         = :f_ot_flag,      
//                                                    ST_FLAG         = :f_st_flag,  
//                                                    BU_FLAG         = :f_bu_flag,
//                                                    KE_FLAG         = :f_ke_flag,  
//                                                    SYUJYUTUBI      = :f_syujyutubi,
//                                                    KYUSEIZOUAKUBI  = :f_kyuseizouakubi,
//  --                                                  OCS_SAVE_YN     = 'N',
//                                                    DISUSE_GASYOU   = :f_disuse_gasyou,
//                                                    DISUSE_ADL      = :f_disuse_adl,
//                                                    DISUSE_KAINYU   = :f_disuse_kainyu,
//                                                    DISUSE_KAIZEN   = :f_disuse_kaizen,
//                                                    DISUSE_CONTENTS = :f_disuse_contents,
//                                                    DISUSE_FIMBI    = :f_disuse_fimbi,
//                                                    YOIN_START_DATE = :f_yoin_start_date,
//                                                    YOIN_SINDAN_DATE= :f_yoin_sindan_date,
//                                                    IMAGE           = :f_image,  
//                                                    IMAGE_PATH      = :f_image_path,
//                                                    IMAGE_SEQ       = :f_image_seq,       
//                                                    CR_TIME         = TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
//
//                                             WHERE FK_OCS           = :f_fk_ocs
//                                               AND HOSP_CODE        = :f_hosp_code
//                                               AND IO_KUBUN         = :f_io_kubun";

//                                    //image save

//                                    for (int i = 0; i < parent.grdPHY8002.RowCount; i++)
//                                    {
//                                        item.BindVarList.Add("f_pkscan001", parent.mPKSCAN001);
//                                        item.BindVarList.Add("f_fkocs", parent.grdPHY8002.GetItemString(i, "fk_ocs"));
//                                        item.BindVarList.Add("f_system", "REHA");
//                                        item.BindVarList.Add("f_jundal_part", "REHA");
//                                        item.BindVarList.Add("f_kanja_no", parent.mBunho);
//                                        //item.BindVarList.Add("f_image_path", item.BindVarList["f_image_path"].VarValue);
//                                        //item.BindVarList.Add("f_image", item.BindVarList["f_image"].VarValue);
//                                        item.BindVarList.Add("f_seq", parent.mPKSCAN001);
//                                        item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                                        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                                    }

//                                    strCmd = @"INSERT INTO SCAN001 (SYS_DATE, UPD_ID, UPD_DATE
//                                                          ,PKSCAN001
//                                                          ,FKOCS
//                                                          ,SYSTEM
//                                                          ,CR_TIME
//                                                          ,JUNDAL_PART
//                                                          ,BUNHO
//                                                          ,IMAGE_PATH
//                                                          ,IMAGE
//                                                          ,SEQ
//                                                          ,SYS_ID
//                                                          ,HOSP_CODE
//                                                        ) VALUES ( SYSDATE
//                                                          ,:f_user_id 
//                                                          ,SYSDATE
//                                                          ,:f_pkscan001
//                                                          ,:f_fkocs
//                                                          ,:f_system
//                                                          ,TO_DATE(:f_cr_time, 'YYYY/MM/DD HH24/MI/SS')
//                                                          ,'REHA'
//                                                          ,:f_kanja_no
//                                                          ,:f_image_path
//                                                          ,:f_image
//                                                          ,:f_seq
//                                                          ,:f_user_id
//                                                          ,:f_hosp_code) ";

//                                    if (Service.ExecuteNonQuery(strCmd, item.BindVarList))
//                                    {
                                    
//                                    }
//                                    else
//                                        XMessageBox.Show(Service.ErrFullMsg);

//                                }
//                                break;
//                            case DataRowState.Deleted:
//                                cmdText = @"";
//                                break;
//                        }
//                        break;

//                        // 傷病grid
//                    case '2':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                string PHY8003_SEQ = @"SELECT PHY8003_SEQ.NEXTVAL FROM SYS.DUAL";
//                                object pk_chk = Service.ExecuteScalar(PHY8003_SEQ);
//                                item.BindVarList.Add("f_pk_phy_syoubyou", pk_chk.ToString());

//                                item.BindVarList["f_data_kubun"].VarValue = "I";

//                                cmdText = @"INSERT INTO PHY8003(SYS_DATE,
//                                                                USER_ID,
//                                                                HOSP_CODE,
//                                                                PK_PHY_SYOUBYOU,
//                                                                FK_OCS_IRAI,
//                                                                DATA_KUBUN,
//                                                                
//                                                                IO_KUBUN,
//                                                                IRAI_DATE,
//                                                                KANJA_NO,
//                                                                SINRYOUKA,
//                                                                SYOUBYOUMEI_CODE,
//                                                                PRE_MODIFIER1,
//                                                                PRE_MODIFIER2,
//                                                                PRE_MODIFIER3,
//                                                                PRE_MODIFIER4,
//                                                                PRE_MODIFIER5,
//                                                                PRE_MODIFIER6,
//                                                                PRE_MODIFIER7,
//                                                                PRE_MODIFIER8,
//                                                                PRE_MODIFIER9,
//                                                                PRE_MODIFIER10,
//                                                                POST_MODIFIER1,
//                                                                POST_MODIFIER2,
//                                                                POST_MODIFIER3,
//                                                                POST_MODIFIER4,
//                                                                POST_MODIFIER5,
//                                                                POST_MODIFIER6,
//                                                                POST_MODIFIER7,
//                                                                POST_MODIFIER8,
//                                                                POST_MODIFIER9,
//                                                                POST_MODIFIER10,
//                                                                HASSYOUBI,
//                                                                SINDANBI,
//                                                                PRE_MODIFIER_NAME,
//                                                                POST_MODIFIER_NAME,
//                                                                SYOUBYOUMEI,
//                                                                FKOUTSANG
//                                                                )
//                                            VALUES( sysdate,
//                                                    :f_user_id,
//                                                    :f_hosp_code,
//                                                    :f_pk_phy_syoubyou,
//                                                    :f_fk_ocs_irai,
//                                                    :f_data_kubun,
//                                                    
//                                                    :f_io_kubun,
//                                                    :f_irai_date,
//                                                    :f_kanja_no,
//                                                    :f_sinryouka,
//                                                    :f_syoubyoumei_code,
//                                                    :f_pre_modifier1,
//                                                    :f_pre_modifier2,
//                                                    :f_pre_modifier3,
//                                                    :f_pre_modifier4,
//                                                    :f_pre_modifier5,
//                                                    :f_pre_modifier6,
//                                                    :f_pre_modifier7,
//                                                    :f_pre_modifier8,
//                                                    :f_pre_modifier9,
//                                                    :f_pre_modifier10,
//                                                    :f_post_modifier1,
//                                                    :f_post_modifier2,
//                                                    :f_post_modifier3,
//                                                    :f_post_modifier4,
//                                                    :f_post_modifier5,
//                                                    :f_post_modifier6,
//                                                    :f_post_modifier7,
//                                                    :f_post_modifier8,
//                                                    :f_post_modifier9,
//                                                    :f_post_modifier10,
//                                                    :f_hassyoubi,
//                                                    :f_sindanbi,
//                                                    :f_pre_modifier_name,
//                                                    :f_post_modifier_name,
//                                                    :f_syoubyoumei,
//                                                    :f_fkoutsang
//                                                    )";
//                                break;
//                            case DataRowState.Modified:
//                                if (parent.copyPkocskey != "")
//                                {
//                                    PHY8003_SEQ = @"SELECT PHY8003_SEQ.NEXTVAL FROM SYS.DUAL";
//                                    pk_chk = Service.ExecuteScalar(PHY8003_SEQ);
//                                    item.BindVarList.Add("f_pk_phy_syoubyou", pk_chk.ToString());

//                                    item.BindVarList["f_data_kubun"].VarValue = "I";

//                                    cmdText = @"INSERT INTO PHY8003(SYS_DATE,
//                                                                USER_ID,
//                                                                HOSP_CODE,
//                                                                PK_PHY_SYOUBYOU,
//                                                                FK_OCS_IRAI,
//                                                                DATA_KUBUN,
//                                                                
//                                                                IO_KUBUN,
//                                                                IRAI_DATE,
//                                                                KANJA_NO,
//                                                                SINRYOUKA,
//                                                                SYOUBYOUMEI_CODE,
//                                                                PRE_MODIFIER1,
//                                                                PRE_MODIFIER2,
//                                                                PRE_MODIFIER3,
//                                                                PRE_MODIFIER4,
//                                                                PRE_MODIFIER5,
//                                                                PRE_MODIFIER6,
//                                                                PRE_MODIFIER7,
//                                                                PRE_MODIFIER8,
//                                                                PRE_MODIFIER9,
//                                                                PRE_MODIFIER10,
//                                                                POST_MODIFIER1,
//                                                                POST_MODIFIER2,
//                                                                POST_MODIFIER3,
//                                                                POST_MODIFIER4,
//                                                                POST_MODIFIER5,
//                                                                POST_MODIFIER6,
//                                                                POST_MODIFIER7,
//                                                                POST_MODIFIER8,
//                                                                POST_MODIFIER9,
//                                                                POST_MODIFIER10,
//                                                                HASSYOUBI,
//                                                                SINDANBI,
//                                                                PRE_MODIFIER_NAME,
//                                                                POST_MODIFIER_NAME,
//                                                                SYOUBYOUMEI,
//                                                                FKOUTSANG
//                                                                )
//                                            VALUES( sysdate,
//                                                    :f_user_id,
//                                                    :f_hosp_code,
//                                                    :f_pk_phy_syoubyou,
//                                                    :f_fk_ocs_irai,
//                                                    :f_data_kubun,
//                                                    
//                                                    :f_io_kubun,
//                                                    :f_irai_date,
//                                                    :f_kanja_no,
//                                                    :f_sinryouka,
//                                                    :f_syoubyoumei_code,
//                                                    :f_pre_modifier1,
//                                                    :f_pre_modifier2,
//                                                    :f_pre_modifier3,
//                                                    :f_pre_modifier4,
//                                                    :f_pre_modifier5,
//                                                    :f_pre_modifier6,
//                                                    :f_pre_modifier7,
//                                                    :f_pre_modifier8,
//                                                    :f_pre_modifier9,
//                                                    :f_pre_modifier10,
//                                                    :f_post_modifier1,
//                                                    :f_post_modifier2,
//                                                    :f_post_modifier3,
//                                                    :f_post_modifier4,
//                                                    :f_post_modifier5,
//                                                    :f_post_modifier6,
//                                                    :f_post_modifier7,
//                                                    :f_post_modifier8,
//                                                    :f_post_modifier9,
//                                                    :f_post_modifier10,
//                                                    :f_hassyoubi,
//                                                    :f_sindanbi,
//                                                    :f_pre_modifier_name,
//                                                    :f_post_modifier_name,
//                                                    :f_syoubyoumei,
//                                                    :f_fkoutsang
//                                                    )";
//                                }
//                                else
//                                {
//                                    item.BindVarList["f_data_kubun"].VarValue = "U";

//                                    cmdText = @" UPDATE PHY8003 A
//                                                SET USER_ID = :f_user_id,
//                                                    DATA_KUBUN = :f_data_kubun,
//                                                    
//                                                    IO_KUBUN=:f_io_kubun,
//                                                    IRAI_DATE=:f_irai_date,
//                                                    SYOUBYOUMEI_CODE=:f_syoubyoumei_code,
//                                                    PRE_MODIFIER1=:f_pre_modifier1,
//                                                    PRE_MODIFIER2= :f_pre_modifier2,
//                                                    PRE_MODIFIER3=:f_pre_modifier3,
//                                                    PRE_MODIFIER4=:f_pre_modifier4,
//                                                    PRE_MODIFIER5=:f_pre_modifier5,
//                                                    PRE_MODIFIER6=:f_pre_modifier6,
//                                                    PRE_MODIFIER7=:f_pre_modifier7,
//                                                    PRE_MODIFIER8=:f_pre_modifier8,
//                                                    PRE_MODIFIER9=:f_pre_modifier9,
//                                                    PRE_MODIFIER10=:f_pre_modifier10,
//                                                    POST_MODIFIER1=:f_post_modifier1,
//                                                    POST_MODIFIER2=:f_post_modifier2,
//                                                    POST_MODIFIER3=:f_post_modifier3,
//                                                    POST_MODIFIER4=:f_post_modifier4,
//                                                    POST_MODIFIER5=:f_post_modifier5,
//                                                    POST_MODIFIER6=:f_post_modifier6,
//                                                    POST_MODIFIER7=:f_post_modifier7,
//                                                    POST_MODIFIER8=:f_post_modifier8,
//                                                    POST_MODIFIER9=:f_post_modifier9,
//                                                    POST_MODIFIER10=:f_post_modifier10,
//                                                    HASSYOUBI=:f_hassyoubi,
//                                                    SINDANBI=:f_sindanbi,
//                                                    PRE_MODIFIER_NAME=:f_pre_modifier_name,
//                                                    POST_MODIFIER_NAME=:f_post_modifier_name,
//                                                    SYOUBYOUMEI=:f_syoubyoumei
//                                              WHERE A.HOSP_CODE = :f_hosp_code
//                                                AND A.PK_PHY_SYOUBYOU =:f_pk_phy_syoubyou
//                                                   ";
//                                }
//                                break;
////                            
//                            case DataRowState.Deleted:
//                                item.BindVarList["f_data_kubun"].VarValue = "D";
//                                cmdText = @"DELETE PHY8003 A
//                                             WHERE A.PK_PHY_SYOUBYOU =:f_pk_phy_syoubyou
//                                               AND A.HOSP_CODE   = :f_hosp_code"
//                                               ;
//                                break;

//                        }
//                        break;

//                    case '3':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                string PHY8004_SEQ = @"SELECT PHY8004_SEQ.NEXTVAL FROM SYS.DUAL";
//                                object pk_chk = Service.ExecuteScalar(PHY8004_SEQ);
//                                item.BindVarList.Add("f_pk_phy_syougai", pk_chk.ToString());

//                                item.BindVarList["f_data_kubun"].VarValue = "I";

//                                cmdText = @"INSERT INTO PHY8004(SYS_DATE,
//                                                                USER_ID,
//                                                                UPD_DATE,
//                                                                HOSP_CODE,
//                                                                PK_PHY_SYOUGAI,
//                                                                DATA_KUBUN,
//                                                                FK_OCS_IRAI,
//                                                                SYOUGAI_ID,
//                                                                SYOUGAIMEI,
//                                                                KANJA_NO,
//                                                                FKCHT0113
//                                                                )
//                                            VALUES(             sysdate,
//                                                                :f_user_id,
//                                                                :f_upd_date,
//                                                                :f_hosp_code,
//                                                                :f_pk_phy_syougai,
//                                                                :f_data_kubun,
//                                                                :f_fk_ocs_irai,
//                                                                :f_syougai_id,
//                                                                :f_syougaimei,
//                                                                :f_kanja_no,
//                                                                :f_fkcht0113
//                                                    )";
//                                break;
//                            case DataRowState.Modified:
//                                if (parent.copyPkocskey != "")
//                                {
//                                    PHY8004_SEQ = @"SELECT PHY8004_SEQ.NEXTVAL FROM SYS.DUAL";
//                                    pk_chk = Service.ExecuteScalar(PHY8004_SEQ);
//                                    item.BindVarList.Add("f_pk_phy_syougai", pk_chk.ToString());

//                                    item.BindVarList["f_data_kubun"].VarValue = "I";

//                                    cmdText = @"INSERT INTO PHY8004(SYS_DATE,
//                                                                USER_ID,
//                                                                UPD_DATE,
//                                                                HOSP_CODE,
//                                                                PK_PHY_SYOUGAI,
//                                                                DATA_KUBUN,
//                                                                FK_OCS_IRAI,
//                                                                SYOUGAI_ID,
//                                                                SYOUGAIMEI,
//                                                                KANJA_NO,
//                                                                FKCHT0113
//                                                                )
//                                            VALUES(             sysdate,
//                                                                :f_user_id,
//                                                                :f_upd_date,
//                                                                :f_hosp_code,
//                                                                :f_pk_phy_syougai,
//                                                                :f_data_kubun,
//                                                                :f_fk_ocs_irai,
//                                                                :f_syougai_id,
//                                                                :f_syougaimei,
//                                                                :f_kanja_no,
//                                                                :f_fkcht0113
//                                                    )";
//                                }
//                                else
//                                {
//                                    item.BindVarList["f_data_kubun"].VarValue = "U";
//                                    XMessageBox.Show(Resources.TEXT31);
//                                }
//                                break;
//                            //                            
//                            case DataRowState.Deleted:
//                                item.BindVarList["f_data_kubun"].VarValue = "D";
//                                cmdText = @"DELETE PHY8004 A
//                                             WHERE A.PK_PHY_SYOUGAI =:f_pk_phy_syougai
//                                               AND A.HOSP_CODE   = :f_hosp_code"
//                                               ;
//                                break;
//                        }
//                        break;
//                }
//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        private void PHY1000U00_Load(object sender, EventArgs e)
        {
            SetControl(ref htPHY8002, pnlCenter,        ref grdPHY8002);
            SetControl(ref htPHY8002, pnlTopInfo,       ref grdPHY8002);
            SetControl(ref htPHY8002, pnlDisUseObj,     ref grdPHY8002);
            SetControl(ref htPHY8002, gbxComplications, ref grdPHY8002);
            SetControl(ref htPHY8002, gbxGenbyoureki,   ref grdPHY8002);
            SetControl(ref htPHY8002, gbxKioureki,      ref grdPHY8002);

            SetControl(ref htPHY8002, gbxPT, ref grdPHY8002);
            SetControl(ref htPHY8002, gbxOT, ref grdPHY8002);
            SetControl(ref htPHY8002, gbxST, ref grdPHY8002);

            SetControl(ref htPHY8002, pnlRightUnderLeft,  ref grdPHY8002);
            //SetControl(ref htPHY8002, pnlRightUnderRight, ref grdPHY8002);

            SetControl(ref htPHY8002, gbxDisuse_Gasyou,   ref grdPHY8002);
            SetControl(ref htPHY8002, gbxDisuse_ADL,      ref grdPHY8002);
            SetControl(ref htPHY8002, gbxDisuse_Kainyu,   ref grdPHY8002);
            SetControl(ref htPHY8002, gbxDisuse_Kaizen,   ref grdPHY8002);
            SetControl(ref htPHY8002, gbxDisuse_Contents, ref grdPHY8002);
            
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.Green);
            g.DrawLine(pen, 100, 100, 600, 600);
            

        }
        private void InsertRow_grdPHY8002()
        {
            this.AcceptData();
            object t_chk;
            string cmdText = "";
            string fk_ocs = this.OpenParam["pkocskey"].ToString();
            
            if (fk_ocs == "") return;

            int insertRow = this.grdPHY8002.InsertRow(-1);
            
            this.dptKaisibi.SetEditValue(EnvironInfo.GetSysDate());
            this.dptKaisibi.AcceptData();

            //this.grdPHY8002.SetItemValue(insertRow, "pk_ocs_irai", t_chk.ToString());

            //cmdText = " SELECT MAX(R_SEQ)+1 SEQ "
            //        + "   FROM PHY8002 "
            //        + "  WHERE PK_OCS_IRAI = " + this.grdPHY8002.GetItemString(insertRow, "pk_ocs_irai")
            //        + "    AND HOSP_CODE = '" + EnvironInfo.HospCode + "' ";
            //t_chk = Service.ExecuteScalar(cmdText);

            //if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
            //{
            //    t_chk = "1";
            //}
            //this.grdPHY8002.SetItemValue(insertRow, "r_seq", t_chk.ToString());

            InsertInitValues();
           
        }
        private void InsertInitValues()
        {
            //initial value
            //依頼キー発行
            int currRow = -1;
            currRow = this.grdPHY8002.CurrentRowNumber;

            //string cmdText = " SELECT PHY8002_SEQ.NEXTVAL "
            //        + "   FROM SYS.DUAL ";
            //object t_chk = Service.ExecuteScalar(cmdText);

            //string strsql = "   SELECT SCAN001_SEQ.NEXTVAL FROM DUAL ";

            //object retVal = Service.ExecuteScalar(strsql);

            PHY8002U01GetPhy8002SeqArgs argsPhy = new PHY8002U01GetPhy8002SeqArgs();
            PHY8002U01GetPhy8002SeqResult resultPhy =
                CloudService.Instance.Submit<PHY8002U01GetPhy8002SeqResult, PHY8002U01GetPhy8002SeqArgs>(argsPhy);

            PHY8002U01GetScan001SeqArgs argsScan = new PHY8002U01GetScan001SeqArgs();
            PHY8002U01GetScan001SeqResult resultScan =
                CloudService.Instance.Submit<PHY8002U01GetScan001SeqResult, PHY8002U01GetScan001SeqArgs>(argsScan);

            //if (retVal == null)
            if (String.IsNullOrEmpty(resultScan.Seq))
            {
                //retVal = "1";
                resultScan.Seq = "1";
            }
            this.grdPHY8002.SetItemValue(currRow, "sys_date", EnvironInfo.GetSysDateTime());
            this.grdPHY8002.SetItemValue(currRow, "fk_ocs", this.OpenParam["pkocskey"].ToString());
            this.grdPHY8002.SetItemValue(currRow, "kanja_no", this.OpenParam["bunho"].ToString());
            this.grdPHY8002.SetItemValue(currRow, "sinryouka", UserInfo.Gwa);
            this.grdPHY8002.SetItemValue(currRow, "koumoku_code", this.OpenParam["hangmog_code"].ToString());
            this.grdPHY8002.SetItemValue(currRow, "sindanisi", UserInfo.UserID);
            this.grdPHY8002.SetItemValue(currRow, "tantoui", UserInfo.UserID);
            this.grdPHY8002.SetItemValue(currRow, "kaisibi", this.mOrder_date);
            //this.grdPHY8002.SetItemValue(currRow, "pkphy8002", t_chk.ToString());
            this.grdPHY8002.SetItemValue(currRow, "pkphy8002", resultPhy.Seq);
            this.grdPHY8002.SetItemValue(currRow, "nissuu", 0);
            this.grdPHY8002.SetItemValue(currRow, "irai_kubun", mIRAI_KUBUN);
            this.grdPHY8002.SetItemValue(currRow, "pt_flag", "N");
            this.grdPHY8002.SetItemValue(currRow, "ot_flag", "N");
            this.grdPHY8002.SetItemValue(currRow, "st_flag", "N");
            this.grdPHY8002.SetItemValue(currRow, "bu_flag", "N");
            this.grdPHY8002.SetItemValue(currRow, "ke_flag", "N");




            if (this.grdPHY8002.GetItemString(currRow, "irai_date") == "")
                this.grdPHY8002.SetItemValue(currRow, "irai_date", this.mOrder_date.Replace("/", "").Replace("-", ""));
        }

        private void SetPHY8002Info()
        {
            //tungtx
            this.grdPHY8002.ExecuteQuery = LoadDataGrdPHY8002AfterSave;
            this.grdPHY8002.QueryLayout(false);
        }
        
        private void grdIFS8003_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPHY8003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPHY8003.SetBindVarValue("f_kanja_no", mBunho);
            this.grdPHY8003.SetBindVarValue("f_sinryouka", mGwa);
            this.grdPHY8003.SetBindVarValue("f_io_kubun", mInOutGubun);
            this.grdPHY8003.SetBindVarValue("f_fk_ocs_irai", this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "pkphy8002"));
        }
                
        //private void grdIFS8003_MouseDown(object sender, MouseEventArgs e)
        //{
        //    int curRowIndex = -1;
        //    XEditGrid grd = sender as XEditGrid;

        //    curRowIndex = grd.GetHitRowNumber(e.Y);

        //    if (e.Button == MouseButtons.Right && e.Clicks == 1)
        //    {
        //        popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
        //    }
        //}

        private void grd_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

            XEditGrid grd = sender as XEditGrid;
            bool IsChecked = false;

            if (grd.GetItemString(e.RowNumber, "code") == "99")
            {
                for (int i = 0; i < grd.RowCount; i++)
                {
                    if (grd.GetItemString(i, "code") != "99")
                        grd.SetItemValue(i, "select", "N");
                }
            }
            else
            {
                for (int i = 0; i < grd.RowCount; i++)
                {
                    if (grd.GetItemString(i, "code") == "99")
                        grd.SetItemValue(i, "select", "N");
                }
            }


            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetItemString(i, "select") == "Y")
                {
                    switch (grd.Name)
                    {
                        case "grdPT":
                            this.cbxPT_FLAG.Checked = true;
                            IsChecked = true;
                            mChanged = true;
                            break;
                        case "grdOT":
                            this.cbxOT_FLAG.Checked = true;
                            IsChecked = true;
                            mChanged = true;
                            break;
                        case "grdST":
                            this.cbxST_FLAG.Checked = true;
                            IsChecked = true;
                            mChanged = true;
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
                        mChanged = true;
                        break;
                    case "grdOT":
                        this.cbxOT_FLAG.Checked = false;
                        mChanged = true;
                        break;
                    case "grdST":
                        this.cbxST_FLAG.Checked = false;
                        mChanged = true;
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

        private void bntOUSANG_Click(object sender, EventArgs e)
        {
            XButton btn = sender as XButton;

            mReturnControl = btn.Tag.ToString();

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);

            switch (btn.Tag.ToString())
            {
                case "C":
                    openParams.Add("multiSelect", true);
                    break;
                case "K":
                    openParams.Add("AllSelect", "Y");
                    break;
                case "S":
                    openParams.Add("phy8003", this.grdPHY8003.LayoutTable);
                    break;
            }

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
            this.txtGenbyoureki.Focus();
        }

        //private void btnSindanmei_Click(object sender, EventArgs e)
        //{
        //    mReturnControl = "S";
        //    CommonItemCollection openParams = new CommonItemCollection();
        //    openParams.Add("bunho", mBunho);
        //    openParams.Add("gwa", mGwa);
        //    openParams.Add("io_gubun", mInOutGubun);
        //    openParams.Add("phy8003", this.grdPHY8003.LayoutTable);

        //    //사용자조회 화면 Open
        //    XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        //}

        //private void btnGenbyoureki_Click(object sender, EventArgs e)
        //{
        //    mReturnControl = "G";
        //    CommonItemCollection openParams = new CommonItemCollection();
        //    openParams.Add("bunho", mBunho);
        //    openParams.Add("gwa", mGwa);
        //    openParams.Add("io_gubun", mInOutGubun);

        //    //사용자조회 화면 Open
        //    XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        //    this.txtGenbyoureki.Focus();
        //}

        //private void btnComplications_Click(object sender, EventArgs e)
        //{
        //    mReturnControl = "C";
        //    CommonItemCollection openParams = new CommonItemCollection();
        //    openParams.Add("multiSelect", true);
        //    XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseFixed, openParams);
        //    this.txtComplications.Focus();
        //}

        //private void btnKioureki_Click(object sender, EventArgs e)
        //{
        //    mReturnControl = "K";
        //    CommonItemCollection openParams = new CommonItemCollection();
        //    openParams.Add("bunho", mBunho);
        //    openParams.Add("gwa", mGwa);
        //    openParams.Add("io_gubun", mInOutGubun);
        //    openParams.Add("AllSelect", "Y");

        //    //사용자조회 화면 Open
        //    XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        //    this.txtKioureki.Focus();
        //}

        private void btnInfectious_Click(object sender, EventArgs e)
        {
            mReturnControl = "I";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("multiSelect", true);
            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
            this.txtInfectious.Focus();
        }
        
        private void dptKaisibi_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //if (int.Parse(this.dptKaisibi.GetDataValue().ToString().Replace("/", "")) < int.Parse(EnvironInfo.GetSysDateTime().ToString("yyyy/MM/dd").Replace("/", "")))
            if (int.Parse(this.dptKaisibi.GetDataValue().ToString().Replace("/", "")) < int.Parse(this.mOrder_date.Replace("/", "")))
            {
                XMessageBox.Show(Resources.TEXT23, Resources.TEXT9);
                PostCallHelper.PostCall(resetDate);
            }
            
        }

        private void resetDate()
        {
            this.dptKaisibi.SetDataValue(EnvironInfo.GetSysDateTime());
        }

        private void InvokeReturnSendReturnDataTable()
        {
            CommonItemCollection param = new CommonItemCollection();
            
            param.Add("PHY8002U01", "changed");

            ((IXScreen)this.Opener).Command(this.Name, param);
        }
        private void grd_Click(object sender, EventArgs e)
        {
            this.mCurrentGrid = sender as XEditGrid;
        }
        private void grd_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex = -1;
            XEditGrid grd = sender as XEditGrid;
            this.mCurrentGrid = grd;

            curRowIndex = grd.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                grd.SetFocusToItem(curRowIndex, 0);
                popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void btnDisability_Click(object sender, EventArgs e)
        {
            mReturnControl = "D";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("multiSelect", true);
            openParams.Add("grdPHY8004", this.grdPHY8004.LayoutTable);
            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0113Q00", ScreenOpenStyle.ResponseFixed, openParams);
            //this.txtGenbyoureki.Focus();
        }

        private void grdPHY8004_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPHY8004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPHY8004.SetBindVarValue("f_fk_ocs_irai", this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "pkphy8002"));
        }

        private void pnlBottom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 2)
            {
                if(this.grdPHY8002.Visible)
                    this.grdPHY8002.Visible = false;
                else
                    this.grdPHY8002.Visible = true;
            }
        }

        private void cboDisUse_Gasyou_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedVal = cboDisUse_Gasyou.GetDataValue();
            int selectedIndex = cboDisUse_Gasyou.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    this.rbtGasyou_01.Checked = true;
                    break;
                case 1:
                    this.rbtGasyou_02.Checked = true;
                    break;
                case 2:
                    this.rbtGasyou_03.Checked = true;
                    break;
                case 3:
                    this.rbtGasyou_04.Checked = true;
                    break;
                case 4:
                    this.rbtGasyou_05.Checked = true;
                    break;
            }
        }

        private void cboDisUse_ADL_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedVal = cboDisUse_ADL.GetDataValue();
            int selectedIndex = cboDisUse_ADL.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    this.rbtBEFADL_01.Checked = true;
                    break;
                case 1:
                    this.rbtBEFADL_02.Checked = true;
                    break;
                case 2:
                    this.rbtBEFADL_03.Checked = true;
                    break;
                case 3:
                    this.rbtBEFADL_04.Checked = true;
                    break;
                case 4:
                    this.rbtBEFADL_05.Checked = true;
                    break;
                case 5:
                    this.rbtBEFADL_06.Checked = true;
                    break;
            }
        }

        private void cboDisUse_Kainyu_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedVal = cboDisUse_Kainyu.GetDataValue();
            int selectedIndex = cboDisUse_Kainyu.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    this.rbtKainyu_01.Checked = true;
                    break;
                case 1:
                    this.rbtKainyu_02.Checked = true;
                    break;
                case 2:
                    this.rbtKainyu_03.Checked = true;
                    break;
                case 3:
                    this.rbtKainyu_04.Checked = true;
                    break;
                case 4:
                    this.rbtKainyu_05.Checked = true;
                    break;
            }
        }

        private void cboDisUse_Kaizen_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedVal = cboDisUse_Kaizen.GetDataValue();
            int selectedIndex = cboDisUse_Kaizen.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    this.rbtKaizen_01.Checked = true;
                    break;
                case 1:
                    this.rbtKaizen_02.Checked = true;
                    break;
                case 2:
                    this.rbtKaizen_03.Checked = true;
                    break;
                case 3:
                    this.rbtKaizen_04.Checked = true;
                    break;
                case 4:
                    this.rbtKaizen_05.Checked = true;
                    break;
            }
        }

        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            XFlatRadioButton rbt = sender as XFlatRadioButton;
            string currentRadioButtonName = rbt.Name.Substring(3, 6);

            switch (currentRadioButtonName)
            {
                case "Gasyou":
                    this.cboDisUse_Gasyou.SelectedValueChanged -= new System.EventHandler(this.cboDisUse_Gasyou_SelectedValueChanged);
                    cboDisUse_Gasyou.SelectedIndex = int.Parse(rbt.CheckedValue);
                    cboDisUse_Gasyou.Focus();
                    this.cboDisUse_Gasyou.SelectedValueChanged += new System.EventHandler(this.cboDisUse_Gasyou_SelectedValueChanged);
                    gbxDisuse_Gasyou.Focus();
                    break;
                case "BEFADL":
                    this.cboDisUse_ADL.SelectedValueChanged -= new System.EventHandler(this.cboDisUse_ADL_SelectedValueChanged);
                    cboDisUse_ADL.SelectedIndex = int.Parse(rbt.CheckedValue);
                    cboDisUse_ADL.Focus();
                    this.cboDisUse_ADL.SelectedValueChanged += new System.EventHandler(this.cboDisUse_ADL_SelectedValueChanged);
                    gbxDisuse_ADL.Focus();
                    break;
                case "Kainyu":
                    this.cboDisUse_Kainyu.SelectedValueChanged -= new System.EventHandler(this.cboDisUse_Kainyu_SelectedValueChanged);
                    cboDisUse_Kainyu.SelectedIndex = int.Parse(rbt.CheckedValue);
                    cboDisUse_Kainyu.Focus();
                    this.cboDisUse_Kainyu.SelectedValueChanged += new System.EventHandler(this.cboDisUse_Kainyu_SelectedValueChanged);
                    gbxDisuse_Kainyu.Focus();
                    break;
                case "Kaizen":
                    this.cboDisUse_Kaizen.SelectedValueChanged -= new System.EventHandler(this.cboDisUse_Kaizen_SelectedValueChanged);
                    cboDisUse_Kaizen.SelectedIndex = int.Parse(rbt.CheckedValue);
                    cboDisUse_Kaizen.Focus();
                    this.cboDisUse_Kaizen.SelectedValueChanged += new System.EventHandler(this.cboDisUse_Kaizen_SelectedValueChanged);
                    gbxDisuse_Kaizen.Focus();
                    break;
            }
        }

        private void xFlatLabel2_Click(object sender, EventArgs e)
        {

        }

        private void xFlatLabel6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                if (this.grdPHY8002.Visible == false)
                    this.grdPHY8002.Visible = true;
                else
                    this.grdPHY8002.Visible = false;
            }
        }

        private void cbxSu_CheckedChanged(object sender, EventArgs e)
        {
            XCheckBox cbx = sender as XCheckBox;

            if (cbx.Checked == true)
            {
                if (this.cbxSu_2_1.Checked == true
                    || this.cbxSu_2_2.Checked == true
                    || this.cbxSu_2_3.Checked == true
                    || this.cbxSu_2_4_c.Checked == true
                    )
                {
                    this.cbxSu_4_1.Checked = false;
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_4_1", "N");
                }
            }

            if (cbx.Checked == true && this.cbxBU_FLAG.Checked == false)
            {
                this.cbxBU_FLAG.Checked = true;
            }

            if (this.cbxSu_2_1.Checked == false
                && this.cbxSu_2_2.Checked == false
                && this.cbxSu_2_3.Checked == false
                && this.cbxSu_2_4_c.Checked == false
                && this.cbxSu_4_1.Checked == false)
            {
                this.cbxBU_FLAG.Checked = false;
            }

            if (cbx.Name == "cbxSu_2_4_c" && cbx.Checked == true)
                this.txtSu_2_4.Enabled = true;
            else if (cbx.Name == "cbxSu_2_4_c" && cbx.Checked == false)
            {
                this.txtSu_2_4.Enabled = false;
                this.txtSu_2_4.Text = "";
                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_2_4", "");
            }

            this.cbxBU_FLAG.Focus();
            cbx.Focus();
            
        }
        private void rbtSu_3_1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtSu_3_1.Checked == true
                || this.rbtSu_3_2.Checked == true
                )
            {
                this.cbxSu_4_1.Checked = false;
                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_4_1", "N");
            }

            if (this.rbtSu_3_1.Checked == false && this.rbtSu_3_2.Checked == false)
                this.cbxKE_FLAG.Checked = false;

            if (this.txtKg.Text != "")
            {
                if (this.rbtSu_3_1.Checked == true)
                {
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_3_1", this.txtKg.Text);
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_3_2", "");
                    this.cbxKE_FLAG.Checked = true;
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "ke_flag", "Y");
                }
                else if (this.rbtSu_3_2.Checked == true)
                {
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_3_2", this.txtKg.Text);
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_3_1", "");
                    this.cbxKE_FLAG.Checked = true;
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "ke_flag", "Y");
                }
            }
        }
        
        private void txtKg_Validating(object sender, CancelEventArgs e)
        {
            if (txtKg.Text != "")
            {
                if (this.cbxKE_FLAG.Checked == false)
                    this.cbxKE_FLAG.Checked = true;
                if (this.rbtSu_3_1.Checked == false && this.rbtSu_3_2.Checked == false)
                    this.rbtSu_3_1.Checked = true;
            }
        }

        private void cbxKE_FLAG_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxKE_FLAG.Checked == true)
            {
                this.txtKg.Enabled = true;
            }
            else
            {
                this.txtKg.Text = "0";
                this.txtKg.Enabled = false;
                this.rbtSu_3_1.Checked = false;
                this.rbtSu_3_2.Checked = false;
                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_3_1", "");
                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_3_2", "");
            }

            if (this.cbxKE_FLAG.Checked == true 
                && this.rbtSu_3_1.Checked == false 
                && this.rbtSu_3_2.Checked == false 
                && this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_3_1") == "" 
                && this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "su_3_2") == "")
            {
                this.rbtSu_3_1.Checked = true;
            }
        }

        private void cbxBU_FLAG_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxBU_FLAG.Checked == false)
            {
                this.cbxSu_2_1.Checked = false;
                this.cbxSu_2_2.Checked = false;
                this.cbxSu_2_3.Checked = false;
                this.cbxSu_2_4_c.Checked = false;
                this.txtSu_2_4.Text = "";

                int currRow = this.grdPHY8002.CurrentRowNumber;
                this.grdPHY8002.SetItemValue(currRow, "bu_flag", "N");
                this.grdPHY8002.SetItemValue(currRow, "su_2_1", "N");
                this.grdPHY8002.SetItemValue(currRow, "su_2_2", "N");
                this.grdPHY8002.SetItemValue(currRow, "su_2_3", "N");
                this.grdPHY8002.SetItemValue(currRow, "su_2_4", "");
            }
        }

        private void txtLength_Validating(object sender, CancelEventArgs e)
        {
            XTextBox txt = sender as XTextBox;
            int getByteCnt = System.Text.Encoding.Default.GetByteCount(txt.Text);
            if (txt.MaxLength < getByteCnt)
                XMessageBox.Show(Resources.TEXT32 + txt.MaxLength + Resources.TEXT33 + getByteCnt + Resources.TEXT34, Resources.TEXT9);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //依頼をコピーしリターンする。
            this.OpenScreen_OCS3003Q10(this.mBunho, this.mOrder_date);
        }

        private void OpenScreen_OCS3003Q10(string aBunho, string aOrderDate)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);
            openParam.Add("order_date", aOrderDate);
            openParam.Add("irai_kubun", "D");
            openParam.Add("io_gubun", mInOutGubun);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS3003Q10", ScreenOpenStyle.ResponseFixed, openParam);
        }

        private void cbxSu_4_1_CheckedChanged(object sender, EventArgs e)
        {
            XCheckBox cbx = sender as XCheckBox;

            if (cbx.Checked == true)
            {
                this.cbxBU_FLAG.Checked = true;
                this.cbxSu_2_1.Checked = false;
                this.cbxSu_2_2.Checked = false;
                this.cbxSu_2_3.Checked = false;
                this.cbxSu_2_4_c.Checked = false;
                this.rbtSu_3_1.Checked = false;
                this.rbtSu_3_2.Checked = false;

                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "su_4_1", "Y");
                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "ke_flag", "N");
                this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "bu_flag", "Y");
            }
            else
            {
                if (this.cbxSu_2_1.Checked == false
                    && this.cbxSu_2_2.Checked == false
                    && this.cbxSu_2_3.Checked == false
                    && this.cbxSu_2_4_c.Checked == false
                    && this.rbtSu_3_1.Checked == false
                    && this.rbtSu_3_2.Checked == false)
                {
                    this.cbxKE_FLAG.Checked = false;
                    this.cbxBU_FLAG.Checked = false;
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "ke_flag", "N");
                    this.grdPHY8002.SetItemValue(this.grdPHY8002.CurrentRowNumber, "bu_flag", "N");
                }
            }
        }

        private void grd_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["code"].ToString() == "99")
                e.ForeColor = Color.Red;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            XButton btn = sender as XButton;
            ShowReservedScreen(btn.Tag.ToString());
            btn.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PHY8002U01));
            this.imageEditor.Image = ((System.Drawing.Image)(resources.GetObject("imageEditor.Image")));
        }

        private void grdPHY8002_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (grdPHY8002.RowCount < 1) return;

            if (grdPHY8002.GetRowState(e.CurrentRow) == DataRowState.Unchanged)
            {
                //이미지 다운로드하여 이미지 SET(다운로드 이미지 리스트를 만들어 Download)
                fileName = this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "image");
                if (fileName.Trim().Length > 0)
                {
                    string jundal_part = "REHA";
                    
                    string filePath = Application.StartupPath + "\\" + "REHA" + "Images" + "\\" + jundal_part;
                    //string createTime = grdPHY8002.GetItemString(grdPHY8002.CurrentRowNumber, "cr_time");
                    
                    //string serverPath = grdPHY8002.GetItemString(grdPHY8002.CurrentRowNumber, "image_path");
                    Uri serverPath = new Uri(IHIS.Framework.Utilities.GetFileConfig("UploadBaseUri") + "/" + fileName);
                    //if (ImageHelper.IsFileDownload(filePath + "\\" + fileName, DateTime.Parse(createTime)))
                    //{
                    //    ArrayList fileList = new ArrayList();
                    //    fileList.Add(new ImageFileInfo(filePath, serverPath, fileName, fileName));

                    //    //TODO: download image from server
                    //    //ImageHelper.DownloadImages(fileList, false);
                    //}

                    string downLoadFilePath = IHIS.Framework.Utilities.ConvertToLocalPath(filePath + "\\" + fileName);
                    if (!File.Exists(downLoadFilePath)) IHIS.Framework.Utilities.DownloadFile(downLoadFilePath, mHospCode, mBunho);

                    if (ImageHelper.GetImage(filePath + "\\" + fileName) != null)
                    {
                        this.imageEditor.Image = ImageHelper.GetImage(filePath + "\\" + fileName);
                        imageEditorOri.Image = this.imageEditor.Image;

                    }

                    dirInfo = new DirectoryInfo(filePath);
                }
            }
        }

        private void grdPHY8002_SaveEnd(object sender, SaveEndEventArgs e)
        {
            ///////////////////////
            //string jundal_part = "REHA";
            //string irai_date = this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "irai_date");
            //string image_name = this.grdPHY8002.GetItemString(this.grdPHY8002.CurrentRowNumber, "image");

            //Image image = imageEditor.Image;
            //string filePath = Directory.GetParent(Application.StartupPath) + "\\" + "REHA" + "Images" + "\\" + jundal_part;
            ////파일경로가 없으면 생성
            //if (!Directory.Exists(filePath))
            //    Directory.CreateDirectory(filePath);
            ////Image를 Client 파일로 저장(파일명은 서버파일명으로)한후에 FTP를 통해 서버로 Upload
            //fileName = Directory.GetParent(Application.StartupPath) + "\\" + "REHA" + "Images" + "\\" + jundal_part + "\\" + image_name;
            ////Image를 지정한 파일로 저장
            //if (!ImageHelper.SaveImageFile(image, fileName)) return;

            //clientFilePath = Directory.GetParent(Application.StartupPath) + "\\" + "REHA" + "Images" + "\\" + jundal_part;

            ///*
            //    * 추후 경로변경 필요
            //    * "/IFCImage/..."를 "/IHISImage/..."로 변경필요
            //    * 
            //* */
            //string serverFilePath = mPathNm + "/"
            //        + "REHA" + "/"
            //        + "REHA" + "/"
            //        + irai_date.Substring(0, 4) + "/"
            //        + irai_date;
            
            //ArrayList uploadFileInfoList = new ArrayList();
            //uploadFileInfoList.Add(new ImageFileInfo(clientFilePath, serverFilePath, image_name, image_name));

            ////Upload 실패시 Return
            //if (!ImageHelper.UploadImages(uploadFileInfoList, true))
            //    return;

        }

        //private void imageEditor_Leave(object sender, EventArgs e)
        //{
        //    //XMessageBox.Show("test");
        //    leaveCnt++;
        //}

        private void imageEditor_Validated(object sender, EventArgs e)
        {
            leaveCnt++;
        }

        private void PHY8002U01_Closing(object sender, CancelEventArgs e)
        {
            //dirInfo.Delete();
            if (dirInfo.Exists)
            {
                FileInfo[] sfiles = dirInfo.GetFiles();

                foreach (FileInfo fi in sfiles)
                {
                    //if(fi.Name == fileName)
                        fi.Delete();// 파일삭제
                }
                // 폴더삭제
                //while (dirInfo.Exists)
                //{
                //    dirInfo.Delete();
                //}
            }
        }

        
        //private void btnStop_kijyun_Click(object sender, EventArgs e)
        //{
        //    ShowReservedScreen("11");
        //    this.txtStop_kijyun.Focus();
        //}

        //private void btnTaboo_Click(object sender, EventArgs e)
        //{
        //    ShowReservedScreen("10");
        //    this.txtTaboo.Focus();
        //}

        //private void btnFrequency_Click(object sender, EventArgs e)
        //{
        //    ShowReservedScreen("12");
        //    this.txtFrequency.Focus();
        //}

    }
}

