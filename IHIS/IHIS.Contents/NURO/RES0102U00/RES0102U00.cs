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
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.NURO.Properties;

#endregion

namespace IHIS.NURO
{
    /// <summary>
    /// RES0102U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class RES0102U00 : XScreen
    {
        #region [DynService Control]

        //private IHIS.Framework.ValidationServiceDyn mVsdCommon = new ValidationServiceDyn();	
        //private IHIS.Framework.DataServiceDynMO mDsdCombo = new DataServiceDynMO();	
        private SingleLayout layCommon = new SingleLayout();
        private const string CACHE_RES0102U00_COMBO_ITEM_KEYS = "NURO.Res0102U00.CboListItem";
        private NuroRES0102U00GetDataGridViewResult res0102U00GetDataGridViewResult;
        private NuroRes0102u00InitCboListItemResult cboListItemResult;
        #endregion

        #region [Instance Variable]

        private int AM_START_TIME = 0800;
        private int AM_END_TIME = 1200;
        private int PM_START_TIME = 1200;
        private int PM_END_TIME = 1800;

        private string mHospCode = string.Empty;

        //Control HashTable
        private Hashtable htControl;

        //Message처리
        private string mbxMsg = "", mbxCap = "";

        //진료과
        private string mGwa = "";
        //의사
        private string mDoctor = "";

        #endregion

        private XPanel xPanel1;
        private XPanel pnlWeekSchedule;
        private XButtonList xButtonList1;
        private XPanel xPanel2;
        private XPanel panAddedSchedule;
        private XPanel xPanel4;
        private XComboBox cboDoctor;
        private XLabel xLabel6;
        private XComboBox cboGwa;
        private XLabel xLabel5;
        private XLabel lblSelectAll;
        private XLabel xLabel1;
        private XLabel xLabel2;
        private XLabel xLabel3;
        private XLabel xLabel4;
        private XLabel xLabel7;
        private XLabel xLabel8;
        private XLabel xLabel9;
        private XLabel xLabel10;
        private XLabel xLabel11;
        private XLabel xLabel12;
        private XLabel xLabel13;
        private XLabel xLabel14;
        private XLabel xLabel15;
        private XLabel xLabel16;
        private XLabel xLabel17;
        private XLabel xLabel21;
        private XLabel xLabel24;
        private XLabel xLabel25;
        private XLabel xLabel28;
        private XLabel xLabel29;
        private XLabel xLabel32;
        private XLabel xLabel33;
        private XLabel xLabel36;
        private XLabel xLabel37;
        private XLabel xLabel40;
        private XEditGrid grdRES0103;
        private XEditGrid grdRES0104;
        private XEditMask emkAm_start_hhmm1;
        private XEditMask emkAm_end_hhmm1;
        private XLabel xLabel41;
        private XLabel xLabel42;
        private XLabel xLabel20;
        private XLabel xLabel18;
        private XEditMask emkAm_end_hhmm2;
        private XEditMask emkAm_start_hhmm2;
        private XLabel xLabel19;
        private XLabel xLabel22;
        private XLabel xLabel23;
        private XLabel xLabel26;
        private XEditMask emkAm_end_hhmm3;
        private XEditMask emkAm_start_hhmm3;
        private XLabel xLabel27;
        private XLabel xLabel30;
        private XLabel xLabel31;
        private XLabel xLabel34;
        private XEditMask emkAm_end_hhmm4;
        private XEditMask emkAm_start_hhmm4;
        private XLabel xLabel35;
        private XLabel xLabel38;
        private XLabel xLabel39;
        private XLabel xLabel43;
        private XEditMask emkAm_start_hhmm5;
        private XLabel xLabel44;
        private XLabel xLabel45;
        private XLabel xLabel46;
        private XLabel xLabel47;
        private XEditMask emkAm_start_hhmm6;
        private XLabel xLabel48;
        private XLabel xLabel49;
        private XLabel xLabel50;
        private XLabel xLabel51;
        private XEditMask emkAm_start_hhmm7;
        private XLabel xLabel52;
        private XLabel xLabel53;
        private XLabel xLabel54;
        private XEditMask emkPm_end_hhmm1;
        private XEditMask emkPm_start_hhmm1;
        private XEditMask emkPm_end_hhmm2;
        private XEditMask emkPm_start_hhmm2;
        private XEditMask emkPm_end_hhmm3;
        private XEditMask emkPm_start_hhmm3;
        private XEditMask emkPm_end_hhmm4;
        private XEditMask emkPm_start_hhmm4;
        private XEditMask emkPm_end_hhmm5;
        private XEditMask emkPm_start_hhmm5;
        private XEditMask emkAm_end_hhmm5;
        private XEditMask emkPm_end_hhmm6;
        private XEditMask emkPm_start_hhmm6;
        private XEditMask emkAm_end_hhmm6;
        private XEditMask emkPm_end_hhmm7;
        private XEditMask emkPm_start_hhmm7;
        private XEditMask emkAm_end_hhmm7;
        private XDatePicker dpkStart_date;
        private XEditGrid grdRES0102;
        private XCheckBox chkJinryo_break_yn;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
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
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XComboBox cboAm_gwa_room7;
        private XComboBox cboAm_gwa_room6;
        private XComboBox cboAm_gwa_room5;
        private XComboBox cboAm_gwa_room4;
        private XComboBox cboAm_gwa_room3;
        private XComboBox cboAm_gwa_room2;
        private XComboBox cboAm_gwa_room1;
        private XEditGridCell xEditGridCell56;
        private XComboBox cboPm_gwa_room1;
        private XComboBox cboPm_gwa_room7;
        private XComboBox cboPm_gwa_room6;
        private XComboBox cboPm_gwa_room5;
        private XComboBox cboPm_gwa_room4;
        private XComboBox cboPm_gwa_room3;
        private XComboBox cboPm_gwa_room2;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XLabel lb1;
        private XLabel lb4;
        private XEditGridCell xEditGridCell64;
        private XButton btnInsertRES0102;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditMask EmkDoc_res_limit;
        private XEditMask emkEtc_res_limit;
        private XLabel lb3;
        private XLabel lb2;
        private XDatePicker dpkApp_date;
        private XLabel xLabel59;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
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
        private XPanel pnlJinryo;
        private XRadioButton rbtJinryo;
        private XPanel pnlReser;
        private XEditMask emkRes_pm_start_hhmm2;
        private XEditMask emkRes_am_end_hhmm2;
        private XEditMask emkRes_am_start_hhmm2;
        private XEditMask emkRes_pm_start_hhmm4;
        private XLabel xLabel61;
        private XEditMask emkRes_pm_end_hhmm3;
        private XEditMask emkRes_pm_start_hhmm3;
        private XEditMask emkRes_pm_end_hhmm2;
        private XEditMask emkRes_am_end_hhmm3;
        private XEditMask emkRes_am_start_hhmm3;
        private XLabel xLabel62;
        private XLabel xLabel63;
        private XLabel xLabel64;
        private XLabel xLabel65;
        private XLabel xLabel66;
        private XEditMask emkRes_pm_end_hhmm1;
        private XEditMask emkRes_pm_start_hhmm1;
        private XLabel xLabel67;
        private XEditMask emkRes_am_end_hhmm1;
        private XEditMask emkRes_am_start_hhmm1;
        private XLabel xLabel68;
        private XLabel xLabel69;
        private XLabel xLabel70;
        private XLabel xLabel71;
        private XLabel xLabel72;
        private XLabel xLabel73;
        private XLabel xLabel74;
        private XLabel xLabel75;
        private XLabel xLabel76;
        private XLabel xLabel83;
        private XLabel xLabel84;
        private XLabel xLabel85;
        private XLabel xLabel86;
        private XEditMask emkRes_pm_end_hhmm7;
        private XEditMask emkRes_pm_start_hhmm7;
        private XLabel xLabel87;
        private XEditMask emkRes_am_end_hhmm7;
        private XEditMask emkRes_am_start_hhmm7;
        private XLabel xLabel88;
        private XLabel xLabel89;
        private XLabel xLabel90;
        private XEditMask emkRes_pm_end_hhmm6;
        private XEditMask emkRes_pm_start_hhmm6;
        private XLabel xLabel91;
        private XEditMask emkRes_am_end_hhmm6;
        private XEditMask emkRes_am_start_hhmm6;
        private XLabel xLabel92;
        private XLabel xLabel93;
        private XLabel xLabel94;
        private XEditMask emkRes_pm_end_hhmm5;
        private XEditMask emkRes_pm_start_hhmm5;
        private XLabel xLabel95;
        private XEditMask emkRes_am_end_hhmm5;
        private XEditMask emkRes_am_start_hhmm5;
        private XLabel xLabel96;
        private XLabel xLabel97;
        private XLabel xLabel98;
        private XEditMask emkRes_pm_end_hhmm4;
        private XLabel xLabel99;
        private XEditMask emkRes_am_end_hhmm4;
        private XEditMask emkRes_am_start_hhmm4;
        private XLabel xLabel100;
        private XLabel xLabel101;
        private XLabel xLabel102;
        private XLabel xLabel103;
        private XLabel xLabel104;
        private XLabel xLabel105;
        private XLabel xLabel106;
        private XLabel xLabel107;
        private XLabel xLabel108;
        private XDisplayBox dbxDoctor_name;
        private XFindBox fbxDoctor;
        private MultiLayout layoutCboGwa;
        private SingleLayout layChkHyujin;
        private SingleLayoutItem singleLayoutItem1;
        private XEditGridCell xEditGridCell5;
        private XEditGrid grdRES0103R;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell99;
        private XGridHeader xGridHeader3;
        private XGridHeader xGridHeader4;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayout layCboDoctor;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayout layCboGwaRoom;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private XDatePicker dpkEnd_date;
        private XLabel xLabel58;
        private XPanel pnlMain;
        private XPanel pnlList;
        private XLabel xLabel60;
        private XPanel pnl;
        private XRadioButton rbtReser;
        private XDictComboBox cboAvg_time;
        private XButton btnMakeDefaultTime;
        private XHospBox xHospBox1;
        private XEditMask emkOut_Hosp_Res_Limit;
        private XLabel lb55;
        private XEditGridCell xEditGridCell100;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private Container components = null;

        public RES0102U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //SaveLayoutList.Add(grdRES0102);
            //SaveLayoutList.Add(grdRES0103);
            //SaveLayoutList.Add(grdRES0103R);
            //SaveLayoutList.Add(grdRES0104);

            //grdRES0102.SavePerformer = new XSavePerformer(this);
            //grdRES0103.SavePerformer = grdRES0102.SavePerformer;
            //grdRES0103R.SavePerformer = grdRES0102.SavePerformer;
            //grdRES0104.SavePerformer = grdRES0103.SavePerformer;

            grdRES0102.ExecuteQuery = grdRES0102ExecuteQuery;
            grdRES0103.ExecuteQuery = grdRES0103ExecuteQuery;
            grdRES0103R.ExecuteQuery = grdRES0103RExecuteQuery;
            grdRES0104.ExecuteQuery = grdRES0104ExecuteQuery;

            layChkHyujin.ParamList =
                new List<string>(new String[] { "f_doctor", "f_start_date", "f_end_date", "f_hosp_code" });
            layChkHyujin.ExecuteQuery = ChkHyujinExecuteQuery;
            //            cboAvg_time.ExecuteQuery = CboAvgTimeExecuteQuery;
            //            cboAvg_time.SetDictDDLB();
        }


        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RES0102U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xHospBox1 = new IHIS.Framework.XHospBox();
            this.xLabel60 = new IHIS.Framework.XLabel();
            this.btnInsertRES0102 = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdRES0102 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.dpkStart_date = new IHIS.Framework.XDatePicker();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.cboAvg_time = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.chkJinryo_break_yn = new IHIS.Framework.XCheckBox();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.dpkEnd_date = new IHIS.Framework.XDatePicker();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.pnlWeekSchedule = new IHIS.Framework.XPanel();
            this.pnlMain = new IHIS.Framework.XPanel();
            this.emkOut_Hosp_Res_Limit = new IHIS.Framework.XEditMask();
            this.lb55 = new IHIS.Framework.XLabel();
            this.btnMakeDefaultTime = new IHIS.Framework.XButton();
            this.lblSelectAll = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel58 = new IHIS.Framework.XLabel();
            this.rbtJinryo = new IHIS.Framework.XRadioButton();
            this.rbtReser = new IHIS.Framework.XRadioButton();
            this.lb1 = new IHIS.Framework.XLabel();
            this.lb2 = new IHIS.Framework.XLabel();
            this.emkEtc_res_limit = new IHIS.Framework.XEditMask();
            this.lb4 = new IHIS.Framework.XLabel();
            this.EmkDoc_res_limit = new IHIS.Framework.XEditMask();
            this.lb3 = new IHIS.Framework.XLabel();
            this.pnlJinryo = new IHIS.Framework.XPanel();
            this.xLabel38 = new IHIS.Framework.XLabel();
            this.xLabel53 = new IHIS.Framework.XLabel();
            this.xLabel49 = new IHIS.Framework.XLabel();
            this.xLabel45 = new IHIS.Framework.XLabel();
            this.emkPm_start_hhmm2 = new IHIS.Framework.XEditMask();
            this.cboAm_gwa_room6 = new IHIS.Framework.XComboBox();
            this.emkAm_end_hhmm2 = new IHIS.Framework.XEditMask();
            this.emkAm_start_hhmm2 = new IHIS.Framework.XEditMask();
            this.emkPm_start_hhmm4 = new IHIS.Framework.XEditMask();
            this.cboAm_gwa_room1 = new IHIS.Framework.XComboBox();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel39 = new IHIS.Framework.XLabel();
            this.emkPm_end_hhmm3 = new IHIS.Framework.XEditMask();
            this.emkPm_start_hhmm3 = new IHIS.Framework.XEditMask();
            this.emkPm_end_hhmm2 = new IHIS.Framework.XEditMask();
            this.emkAm_end_hhmm3 = new IHIS.Framework.XEditMask();
            this.emkAm_start_hhmm3 = new IHIS.Framework.XEditMask();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.xLabel30 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.emkPm_end_hhmm1 = new IHIS.Framework.XEditMask();
            this.emkPm_start_hhmm1 = new IHIS.Framework.XEditMask();
            this.xLabel42 = new IHIS.Framework.XLabel();
            this.emkAm_end_hhmm1 = new IHIS.Framework.XEditMask();
            this.emkAm_start_hhmm1 = new IHIS.Framework.XEditMask();
            this.xLabel41 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.cboAm_gwa_room7 = new IHIS.Framework.XComboBox();
            this.xLabel37 = new IHIS.Framework.XLabel();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.cboAm_gwa_room5 = new IHIS.Framework.XComboBox();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.cboAm_gwa_room4 = new IHIS.Framework.XComboBox();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.cboAm_gwa_room3 = new IHIS.Framework.XComboBox();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.cboAm_gwa_room2 = new IHIS.Framework.XComboBox();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.cboPm_gwa_room7 = new IHIS.Framework.XComboBox();
            this.cboPm_gwa_room6 = new IHIS.Framework.XComboBox();
            this.cboPm_gwa_room5 = new IHIS.Framework.XComboBox();
            this.cboPm_gwa_room4 = new IHIS.Framework.XComboBox();
            this.cboPm_gwa_room3 = new IHIS.Framework.XComboBox();
            this.cboPm_gwa_room2 = new IHIS.Framework.XComboBox();
            this.cboPm_gwa_room1 = new IHIS.Framework.XComboBox();
            this.emkPm_end_hhmm7 = new IHIS.Framework.XEditMask();
            this.emkPm_start_hhmm7 = new IHIS.Framework.XEditMask();
            this.xLabel51 = new IHIS.Framework.XLabel();
            this.emkAm_end_hhmm7 = new IHIS.Framework.XEditMask();
            this.emkAm_start_hhmm7 = new IHIS.Framework.XEditMask();
            this.xLabel52 = new IHIS.Framework.XLabel();
            this.xLabel54 = new IHIS.Framework.XLabel();
            this.emkPm_end_hhmm6 = new IHIS.Framework.XEditMask();
            this.emkPm_start_hhmm6 = new IHIS.Framework.XEditMask();
            this.xLabel47 = new IHIS.Framework.XLabel();
            this.emkAm_end_hhmm6 = new IHIS.Framework.XEditMask();
            this.emkAm_start_hhmm6 = new IHIS.Framework.XEditMask();
            this.xLabel48 = new IHIS.Framework.XLabel();
            this.xLabel50 = new IHIS.Framework.XLabel();
            this.emkPm_end_hhmm5 = new IHIS.Framework.XEditMask();
            this.emkPm_start_hhmm5 = new IHIS.Framework.XEditMask();
            this.xLabel43 = new IHIS.Framework.XLabel();
            this.emkAm_end_hhmm5 = new IHIS.Framework.XEditMask();
            this.emkAm_start_hhmm5 = new IHIS.Framework.XEditMask();
            this.xLabel44 = new IHIS.Framework.XLabel();
            this.xLabel46 = new IHIS.Framework.XLabel();
            this.emkPm_end_hhmm4 = new IHIS.Framework.XEditMask();
            this.xLabel34 = new IHIS.Framework.XLabel();
            this.emkAm_end_hhmm4 = new IHIS.Framework.XEditMask();
            this.emkAm_start_hhmm4 = new IHIS.Framework.XEditMask();
            this.xLabel35 = new IHIS.Framework.XLabel();
            this.xLabel40 = new IHIS.Framework.XLabel();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.xLabel32 = new IHIS.Framework.XLabel();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.pnlReser = new IHIS.Framework.XPanel();
            this.emkRes_pm_start_hhmm2 = new IHIS.Framework.XEditMask();
            this.emkRes_am_end_hhmm2 = new IHIS.Framework.XEditMask();
            this.emkRes_am_start_hhmm2 = new IHIS.Framework.XEditMask();
            this.emkRes_pm_start_hhmm4 = new IHIS.Framework.XEditMask();
            this.xLabel61 = new IHIS.Framework.XLabel();
            this.emkRes_pm_end_hhmm3 = new IHIS.Framework.XEditMask();
            this.emkRes_pm_start_hhmm3 = new IHIS.Framework.XEditMask();
            this.emkRes_pm_end_hhmm2 = new IHIS.Framework.XEditMask();
            this.emkRes_am_end_hhmm3 = new IHIS.Framework.XEditMask();
            this.emkRes_am_start_hhmm3 = new IHIS.Framework.XEditMask();
            this.xLabel62 = new IHIS.Framework.XLabel();
            this.xLabel63 = new IHIS.Framework.XLabel();
            this.xLabel64 = new IHIS.Framework.XLabel();
            this.xLabel65 = new IHIS.Framework.XLabel();
            this.xLabel66 = new IHIS.Framework.XLabel();
            this.emkRes_pm_end_hhmm1 = new IHIS.Framework.XEditMask();
            this.emkRes_pm_start_hhmm1 = new IHIS.Framework.XEditMask();
            this.xLabel67 = new IHIS.Framework.XLabel();
            this.emkRes_am_end_hhmm1 = new IHIS.Framework.XEditMask();
            this.emkRes_am_start_hhmm1 = new IHIS.Framework.XEditMask();
            this.xLabel68 = new IHIS.Framework.XLabel();
            this.xLabel69 = new IHIS.Framework.XLabel();
            this.xLabel70 = new IHIS.Framework.XLabel();
            this.xLabel71 = new IHIS.Framework.XLabel();
            this.xLabel72 = new IHIS.Framework.XLabel();
            this.xLabel73 = new IHIS.Framework.XLabel();
            this.xLabel74 = new IHIS.Framework.XLabel();
            this.xLabel75 = new IHIS.Framework.XLabel();
            this.xLabel76 = new IHIS.Framework.XLabel();
            this.xLabel83 = new IHIS.Framework.XLabel();
            this.xLabel84 = new IHIS.Framework.XLabel();
            this.xLabel85 = new IHIS.Framework.XLabel();
            this.xLabel86 = new IHIS.Framework.XLabel();
            this.emkRes_pm_end_hhmm7 = new IHIS.Framework.XEditMask();
            this.emkRes_pm_start_hhmm7 = new IHIS.Framework.XEditMask();
            this.xLabel87 = new IHIS.Framework.XLabel();
            this.emkRes_am_end_hhmm7 = new IHIS.Framework.XEditMask();
            this.emkRes_am_start_hhmm7 = new IHIS.Framework.XEditMask();
            this.xLabel88 = new IHIS.Framework.XLabel();
            this.xLabel89 = new IHIS.Framework.XLabel();
            this.xLabel90 = new IHIS.Framework.XLabel();
            this.emkRes_pm_end_hhmm6 = new IHIS.Framework.XEditMask();
            this.emkRes_pm_start_hhmm6 = new IHIS.Framework.XEditMask();
            this.xLabel91 = new IHIS.Framework.XLabel();
            this.emkRes_am_end_hhmm6 = new IHIS.Framework.XEditMask();
            this.emkRes_am_start_hhmm6 = new IHIS.Framework.XEditMask();
            this.xLabel92 = new IHIS.Framework.XLabel();
            this.xLabel93 = new IHIS.Framework.XLabel();
            this.xLabel94 = new IHIS.Framework.XLabel();
            this.emkRes_pm_end_hhmm5 = new IHIS.Framework.XEditMask();
            this.emkRes_pm_start_hhmm5 = new IHIS.Framework.XEditMask();
            this.xLabel95 = new IHIS.Framework.XLabel();
            this.emkRes_am_end_hhmm5 = new IHIS.Framework.XEditMask();
            this.emkRes_am_start_hhmm5 = new IHIS.Framework.XEditMask();
            this.xLabel96 = new IHIS.Framework.XLabel();
            this.xLabel97 = new IHIS.Framework.XLabel();
            this.xLabel98 = new IHIS.Framework.XLabel();
            this.emkRes_pm_end_hhmm4 = new IHIS.Framework.XEditMask();
            this.xLabel99 = new IHIS.Framework.XLabel();
            this.emkRes_am_end_hhmm4 = new IHIS.Framework.XEditMask();
            this.emkRes_am_start_hhmm4 = new IHIS.Framework.XEditMask();
            this.xLabel100 = new IHIS.Framework.XLabel();
            this.xLabel101 = new IHIS.Framework.XLabel();
            this.xLabel102 = new IHIS.Framework.XLabel();
            this.xLabel103 = new IHIS.Framework.XLabel();
            this.xLabel104 = new IHIS.Framework.XLabel();
            this.xLabel105 = new IHIS.Framework.XLabel();
            this.xLabel106 = new IHIS.Framework.XLabel();
            this.xLabel107 = new IHIS.Framework.XLabel();
            this.xLabel108 = new IHIS.Framework.XLabel();
            this.pnlList = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dpkApp_date = new IHIS.Framework.XDatePicker();
            this.dbxDoctor_name = new IHIS.Framework.XDisplayBox();
            this.cboGwa = new IHIS.Framework.XComboBox();
            this.xLabel59 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.cboDoctor = new IHIS.Framework.XComboBox();
            this.panAddedSchedule = new IHIS.Framework.XPanel();
            this.pnl = new IHIS.Framework.XPanel();
            this.grdRES0103 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.grdRES0103R = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.xGridHeader4 = new IHIS.Framework.XGridHeader();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdRES0104 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.layoutCboGwa = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layChkHyujin = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layCboDoctor = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.layCboGwaRoom = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRES0102)).BeginInit();
            this.pnlWeekSchedule.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlJinryo.SuspendLayout();
            this.pnlReser.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.panAddedSchedule.SuspendLayout();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRES0103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRES0103R)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRES0104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCboGwa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCboDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCboGwaRoom)).BeginInit();
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
            this.ImageList.Images.SetKeyName(5, "전송_16.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xHospBox1);
            this.xPanel1.Controls.Add(this.xLabel60);
            this.xPanel1.Controls.Add(this.btnInsertRES0102);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xHospBox1
            // 
            this.xHospBox1.AccessibleDescription = null;
            this.xHospBox1.AccessibleName = null;
            resources.ApplyResources(this.xHospBox1, "xHospBox1");
            this.xHospBox1.BackColor = System.Drawing.Color.Transparent;
            this.xHospBox1.BackgroundImage = null;
            this.xHospBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xHospBox1.HospCode = "";
            this.xHospBox1.Name = "xHospBox1";
            this.xHospBox1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xHospBox1_DataValidating);
            this.xHospBox1.FindClick += new System.EventHandler(this.xHospBox1_FindClick);
            // 
            // xLabel60
            // 
            this.xLabel60.AccessibleDescription = null;
            this.xLabel60.AccessibleName = null;
            resources.ApplyResources(this.xLabel60, "xLabel60");
            this.xLabel60.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel60.Image = null;
            this.xLabel60.Name = "xLabel60";
            this.xLabel60.Click += new System.EventHandler(this.xLabel60_Click);
            // 
            // btnInsertRES0102
            // 
            this.btnInsertRES0102.AccessibleDescription = null;
            this.btnInsertRES0102.AccessibleName = null;
            resources.ApplyResources(this.btnInsertRES0102, "btnInsertRES0102");
            this.btnInsertRES0102.BackgroundImage = null;
            this.btnInsertRES0102.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertRES0102.Image")));
            this.btnInsertRES0102.Name = "btnInsertRES0102";
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdRES0102
            // 
            resources.ApplyResources(this.grdRES0102, "grdRES0102");
            this.grdRES0102.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
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
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
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
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell64,
            this.xEditGridCell5,
            this.xEditGridCell100});
            this.grdRES0102.ColPerLine = 2;
            this.grdRES0102.Cols = 2;
            this.grdRES0102.ControlBinding = true;
            this.grdRES0102.ExecuteQuery = null;
            this.grdRES0102.FixedRows = 1;
            this.grdRES0102.HeaderHeights.Add(18);
            this.grdRES0102.Name = "grdRES0102";
            this.grdRES0102.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRES0102.ParamList")));
            this.grdRES0102.Rows = 2;
            this.grdRES0102.ToolTipActive = true;
            this.grdRES0102.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdRES0102.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdRES0102_QueryEnd);
            this.grdRES0102.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRES0102_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "doctor";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "gwa";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.BindControl = this.dpkStart_date;
            this.xEditGridCell3.CellName = "start_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 136;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // dpkStart_date
            // 
            this.dpkStart_date.AccessibleDescription = null;
            this.dpkStart_date.AccessibleName = null;
            resources.ApplyResources(this.dpkStart_date, "dpkStart_date");
            this.dpkStart_date.BackgroundImage = null;
            this.dpkStart_date.IsVietnameseYearType = false;
            this.dpkStart_date.Name = "dpkStart_date";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.cboAvg_time;
            this.xEditGridCell4.CellName = "avg_time";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.InitValue = "0";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // cboAvg_time
            // 
            this.cboAvg_time.AccessibleDescription = null;
            this.cboAvg_time.AccessibleName = null;
            resources.ApplyResources(this.cboAvg_time, "cboAvg_time");
            this.cboAvg_time.BackgroundImage = null;
            this.cboAvg_time.ExecuteQuery = null;
            this.cboAvg_time.FormatString = "N0";
            this.cboAvg_time.Name = "cboAvg_time";
            this.cboAvg_time.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboAvg_time.ParamList")));
            this.cboAvg_time.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.chkJinryo_break_yn;
            this.xEditGridCell8.CellName = "jinryo_break_yn";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.InitValue = "N";
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // chkJinryo_break_yn
            // 
            this.chkJinryo_break_yn.AccessibleDescription = null;
            this.chkJinryo_break_yn.AccessibleName = null;
            resources.ApplyResources(this.chkJinryo_break_yn, "chkJinryo_break_yn");
            this.chkJinryo_break_yn.BackgroundImage = null;
            this.chkJinryo_break_yn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkJinryo_break_yn.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.chkJinryo_break_yn.Name = "chkJinryo_break_yn";
            this.chkJinryo_break_yn.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "am_start_hhmm1";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "am_start_hhmm2";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "am_start_hhmm3";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "am_start_hhmm4";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "am_start_hhmm5";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "am_start_hhmm6";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "am_start_hhmm7";
            this.xEditGridCell15.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "am_end_hhmm1";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "am_end_hhmm2";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "am_end_hhmm3";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "am_end_hhmm4";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "am_end_hhmm5";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "am_end_hhmm6";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "am_end_hhmm7";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "pm_start_hhmm1";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "pm_start_hhmm2";
            this.xEditGridCell24.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "pm_start_hhmm3";
            this.xEditGridCell25.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "pm_start_hhmm4";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "pm_start_hhmm5";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "pm_start_hhmm6";
            this.xEditGridCell28.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "pm_start_hhmm7";
            this.xEditGridCell29.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "pm_end_hhmm1";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "pm_end_hhmm2";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "pm_end_hhmm3";
            this.xEditGridCell32.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "pm_end_hhmm4";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "pm_end_hhmm5";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "pm_end_hhmm6";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "pm_end_hhmm7";
            this.xEditGridCell36.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "am_gwa_room1";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "am_gwa_room2";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "am_gwa_room3";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "am_gwa_room4";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "am_gwa_room5";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "am_gwa_room6";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "am_gwa_room7";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "pm_gwa_room1";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "pm_gwa_room2";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "pm_gwa_room3";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "pm_gwa_room4";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "pm_gwa_room5";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "pm_gwa_room6";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "pm_gwa_room7";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "res_am_start_hhmm1";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "res_am_start_hhmm2";
            this.xEditGridCell68.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "res_am_start_hhmm3";
            this.xEditGridCell69.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "res_am_start_hhmm4";
            this.xEditGridCell70.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "res_am_start_hhmm5";
            this.xEditGridCell71.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "res_am_start_hhmm6";
            this.xEditGridCell72.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "res_am_start_hhmm7";
            this.xEditGridCell73.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "res_am_end_hhmm1";
            this.xEditGridCell74.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "res_am_end_hhmm2";
            this.xEditGridCell75.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "res_am_end_hhmm3";
            this.xEditGridCell76.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "res_am_end_hhmm4";
            this.xEditGridCell77.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "res_am_end_hhmm5";
            this.xEditGridCell78.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "res_am_end_hhmm6";
            this.xEditGridCell79.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "res_am_end_hhmm7";
            this.xEditGridCell80.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "res_pm_start_hhmm1";
            this.xEditGridCell81.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "res_pm_start_hhmm2";
            this.xEditGridCell82.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "res_pm_start_hhmm3";
            this.xEditGridCell83.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "res_pm_start_hhmm4";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "res_pm_start_hhmm5";
            this.xEditGridCell85.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "res_pm_start_hhmm6";
            this.xEditGridCell86.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "res_pm_start_hhmm7";
            this.xEditGridCell87.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "res_pm_end_hhmm1";
            this.xEditGridCell88.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "res_pm_end_hhmm2";
            this.xEditGridCell89.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "res_pm_end_hhmm3";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "res_pm_end_hhmm4";
            this.xEditGridCell91.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "res_pm_end_hhmm5";
            this.xEditGridCell92.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "res_pm_end_hhmm6";
            this.xEditGridCell93.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "res_pm_end_hhmm7";
            this.xEditGridCell94.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "doc_res_limit";
            this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "etc_res_limit";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "source_start_date";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.dpkEnd_date;
            this.xEditGridCell5.CellName = "end_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 128;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // dpkEnd_date
            // 
            this.dpkEnd_date.AccessibleDescription = null;
            this.dpkEnd_date.AccessibleName = null;
            resources.ApplyResources(this.dpkEnd_date, "dpkEnd_date");
            this.dpkEnd_date.BackgroundImage = null;
            this.dpkEnd_date.IsVietnameseYearType = false;
            this.dpkEnd_date.Name = "dpkEnd_date";
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "out_hosp_res_limit";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // pnlWeekSchedule
            // 
            this.pnlWeekSchedule.AccessibleDescription = null;
            this.pnlWeekSchedule.AccessibleName = null;
            resources.ApplyResources(this.pnlWeekSchedule, "pnlWeekSchedule");
            this.pnlWeekSchedule.BackgroundImage = null;
            this.pnlWeekSchedule.Controls.Add(this.pnlMain);
            this.pnlWeekSchedule.Controls.Add(this.pnlList);
            this.pnlWeekSchedule.Font = null;
            this.pnlWeekSchedule.Name = "pnlWeekSchedule";
            // 
            // pnlMain
            // 
            this.pnlMain.AccessibleDescription = null;
            this.pnlMain.AccessibleName = null;
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.BackgroundImage = null;
            this.pnlMain.Controls.Add(this.emkOut_Hosp_Res_Limit);
            this.pnlMain.Controls.Add(this.lb55);
            this.pnlMain.Controls.Add(this.btnMakeDefaultTime);
            this.pnlMain.Controls.Add(this.cboAvg_time);
            this.pnlMain.Controls.Add(this.lblSelectAll);
            this.pnlMain.Controls.Add(this.xLabel3);
            this.pnlMain.Controls.Add(this.dpkEnd_date);
            this.pnlMain.Controls.Add(this.xLabel58);
            this.pnlMain.Controls.Add(this.dpkStart_date);
            this.pnlMain.Controls.Add(this.rbtJinryo);
            this.pnlMain.Controls.Add(this.chkJinryo_break_yn);
            this.pnlMain.Controls.Add(this.rbtReser);
            this.pnlMain.Controls.Add(this.lb1);
            this.pnlMain.Controls.Add(this.lb2);
            this.pnlMain.Controls.Add(this.emkEtc_res_limit);
            this.pnlMain.Controls.Add(this.lb4);
            this.pnlMain.Controls.Add(this.EmkDoc_res_limit);
            this.pnlMain.Controls.Add(this.lb3);
            this.pnlMain.Controls.Add(this.pnlJinryo);
            this.pnlMain.Controls.Add(this.pnlReser);
            this.pnlMain.Font = null;
            this.pnlMain.Name = "pnlMain";
            // 
            // emkOut_Hosp_Res_Limit
            // 
            this.emkOut_Hosp_Res_Limit.AccessibleDescription = null;
            this.emkOut_Hosp_Res_Limit.AccessibleName = null;
            resources.ApplyResources(this.emkOut_Hosp_Res_Limit, "emkOut_Hosp_Res_Limit");
            this.emkOut_Hosp_Res_Limit.BackgroundImage = null;
            this.emkOut_Hosp_Res_Limit.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkOut_Hosp_Res_Limit.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.emkOut_Hosp_Res_Limit.IsVietnameseYearType = false;
            this.emkOut_Hosp_Res_Limit.MaxinumCipher = 2;
            this.emkOut_Hosp_Res_Limit.Name = "emkOut_Hosp_Res_Limit";
            // 
            // lb55
            // 
            this.lb55.AccessibleDescription = null;
            this.lb55.AccessibleName = null;
            resources.ApplyResources(this.lb55, "lb55");
            this.lb55.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lb55.EdgeRounding = false;
            this.lb55.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lb55.Image = null;
            this.lb55.Name = "lb55";
            // 
            // btnMakeDefaultTime
            // 
            this.btnMakeDefaultTime.AccessibleDescription = null;
            this.btnMakeDefaultTime.AccessibleName = null;
            resources.ApplyResources(this.btnMakeDefaultTime, "btnMakeDefaultTime");
            this.btnMakeDefaultTime.BackgroundImage = null;
            this.btnMakeDefaultTime.ImageIndex = 5;
            this.btnMakeDefaultTime.ImageList = this.ImageList;
            this.btnMakeDefaultTime.Name = "btnMakeDefaultTime";
            this.btnMakeDefaultTime.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnMakeDefaultTime.Click += new System.EventHandler(this.btnMakeDefaultTime_Click);
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.AccessibleDescription = null;
            this.lblSelectAll.AccessibleName = null;
            resources.ApplyResources(this.lblSelectAll, "lblSelectAll");
            this.lblSelectAll.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectAll.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectAll.ImageList = this.ImageList;
            this.lblSelectAll.Name = "lblSelectAll";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel58
            // 
            this.xLabel58.AccessibleDescription = null;
            this.xLabel58.AccessibleName = null;
            resources.ApplyResources(this.xLabel58, "xLabel58");
            this.xLabel58.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel58.EdgeRounding = false;
            this.xLabel58.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel58.Image = null;
            this.xLabel58.Name = "xLabel58";
            // 
            // rbtJinryo
            // 
            this.rbtJinryo.AccessibleDescription = null;
            this.rbtJinryo.AccessibleName = null;
            resources.ApplyResources(this.rbtJinryo, "rbtJinryo");
            this.rbtJinryo.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtJinryo.BackgroundImage = null;
            this.rbtJinryo.Checked = true;
            this.rbtJinryo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtJinryo.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtJinryo.ImageList = this.ImageList;
            this.rbtJinryo.Name = "rbtJinryo";
            this.rbtJinryo.TabStop = true;
            this.rbtJinryo.UseVisualStyleBackColor = false;
            this.rbtJinryo.CheckedChanged += new System.EventHandler(this.rbtJinryo_CheckedChanged);
            // 
            // rbtReser
            // 
            this.rbtReser.AccessibleDescription = null;
            this.rbtReser.AccessibleName = null;
            resources.ApplyResources(this.rbtReser, "rbtReser");
            this.rbtReser.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtReser.BackgroundImage = null;
            this.rbtReser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtReser.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtReser.ImageList = this.ImageList;
            this.rbtReser.Name = "rbtReser";
            this.rbtReser.UseVisualStyleBackColor = false;
            // 
            // lb1
            // 
            this.lb1.AccessibleDescription = null;
            this.lb1.AccessibleName = null;
            resources.ApplyResources(this.lb1, "lb1");
            this.lb1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lb1.EdgeRounding = false;
            this.lb1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lb1.Image = null;
            this.lb1.Name = "lb1";
            // 
            // lb2
            // 
            this.lb2.AccessibleDescription = null;
            this.lb2.AccessibleName = null;
            resources.ApplyResources(this.lb2, "lb2");
            this.lb2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lb2.EdgeRounding = false;
            this.lb2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lb2.Image = null;
            this.lb2.Name = "lb2";
            // 
            // emkEtc_res_limit
            // 
            this.emkEtc_res_limit.AccessibleDescription = null;
            this.emkEtc_res_limit.AccessibleName = null;
            resources.ApplyResources(this.emkEtc_res_limit, "emkEtc_res_limit");
            this.emkEtc_res_limit.BackgroundImage = null;
            this.emkEtc_res_limit.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkEtc_res_limit.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.emkEtc_res_limit.IsVietnameseYearType = false;
            this.emkEtc_res_limit.MaxinumCipher = 2;
            this.emkEtc_res_limit.Name = "emkEtc_res_limit";
            // 
            // lb4
            // 
            this.lb4.AccessibleDescription = null;
            this.lb4.AccessibleName = null;
            resources.ApplyResources(this.lb4, "lb4");
            this.lb4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lb4.Image = null;
            this.lb4.Name = "lb4";
            // 
            // EmkDoc_res_limit
            // 
            this.EmkDoc_res_limit.AccessibleDescription = null;
            this.EmkDoc_res_limit.AccessibleName = null;
            resources.ApplyResources(this.EmkDoc_res_limit, "EmkDoc_res_limit");
            this.EmkDoc_res_limit.BackgroundImage = null;
            this.EmkDoc_res_limit.EditMaskType = IHIS.Framework.MaskType.Number;
            this.EmkDoc_res_limit.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.EmkDoc_res_limit.IsVietnameseYearType = false;
            this.EmkDoc_res_limit.MaxinumCipher = 2;
            this.EmkDoc_res_limit.Name = "EmkDoc_res_limit";
            // 
            // lb3
            // 
            this.lb3.AccessibleDescription = null;
            this.lb3.AccessibleName = null;
            resources.ApplyResources(this.lb3, "lb3");
            this.lb3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lb3.EdgeRounding = false;
            this.lb3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lb3.Image = null;
            this.lb3.Name = "lb3";
            // 
            // pnlJinryo
            // 
            this.pnlJinryo.AccessibleDescription = null;
            this.pnlJinryo.AccessibleName = null;
            resources.ApplyResources(this.pnlJinryo, "pnlJinryo");
            this.pnlJinryo.BackgroundImage = null;
            this.pnlJinryo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlJinryo.Controls.Add(this.xLabel38);
            this.pnlJinryo.Controls.Add(this.xLabel53);
            this.pnlJinryo.Controls.Add(this.xLabel49);
            this.pnlJinryo.Controls.Add(this.xLabel45);
            this.pnlJinryo.Controls.Add(this.emkPm_start_hhmm2);
            this.pnlJinryo.Controls.Add(this.cboAm_gwa_room6);
            this.pnlJinryo.Controls.Add(this.emkAm_end_hhmm2);
            this.pnlJinryo.Controls.Add(this.emkAm_start_hhmm2);
            this.pnlJinryo.Controls.Add(this.emkPm_start_hhmm4);
            this.pnlJinryo.Controls.Add(this.cboAm_gwa_room1);
            this.pnlJinryo.Controls.Add(this.xLabel16);
            this.pnlJinryo.Controls.Add(this.xLabel39);
            this.pnlJinryo.Controls.Add(this.emkPm_end_hhmm3);
            this.pnlJinryo.Controls.Add(this.emkPm_start_hhmm3);
            this.pnlJinryo.Controls.Add(this.emkPm_end_hhmm2);
            this.pnlJinryo.Controls.Add(this.emkAm_end_hhmm3);
            this.pnlJinryo.Controls.Add(this.emkAm_start_hhmm3);
            this.pnlJinryo.Controls.Add(this.xLabel27);
            this.pnlJinryo.Controls.Add(this.xLabel30);
            this.pnlJinryo.Controls.Add(this.xLabel19);
            this.pnlJinryo.Controls.Add(this.xLabel22);
            this.pnlJinryo.Controls.Add(this.xLabel23);
            this.pnlJinryo.Controls.Add(this.emkPm_end_hhmm1);
            this.pnlJinryo.Controls.Add(this.emkPm_start_hhmm1);
            this.pnlJinryo.Controls.Add(this.xLabel42);
            this.pnlJinryo.Controls.Add(this.emkAm_end_hhmm1);
            this.pnlJinryo.Controls.Add(this.emkAm_start_hhmm1);
            this.pnlJinryo.Controls.Add(this.xLabel41);
            this.pnlJinryo.Controls.Add(this.xLabel13);
            this.pnlJinryo.Controls.Add(this.xLabel14);
            this.pnlJinryo.Controls.Add(this.xLabel12);
            this.pnlJinryo.Controls.Add(this.xLabel11);
            this.pnlJinryo.Controls.Add(this.xLabel10);
            this.pnlJinryo.Controls.Add(this.xLabel9);
            this.pnlJinryo.Controls.Add(this.xLabel8);
            this.pnlJinryo.Controls.Add(this.xLabel7);
            this.pnlJinryo.Controls.Add(this.cboAm_gwa_room7);
            this.pnlJinryo.Controls.Add(this.xLabel37);
            this.pnlJinryo.Controls.Add(this.xLabel33);
            this.pnlJinryo.Controls.Add(this.cboAm_gwa_room5);
            this.pnlJinryo.Controls.Add(this.xLabel29);
            this.pnlJinryo.Controls.Add(this.cboAm_gwa_room4);
            this.pnlJinryo.Controls.Add(this.xLabel25);
            this.pnlJinryo.Controls.Add(this.cboAm_gwa_room3);
            this.pnlJinryo.Controls.Add(this.xLabel21);
            this.pnlJinryo.Controls.Add(this.cboAm_gwa_room2);
            this.pnlJinryo.Controls.Add(this.xLabel17);
            this.pnlJinryo.Controls.Add(this.xLabel4);
            this.pnlJinryo.Controls.Add(this.xLabel18);
            this.pnlJinryo.Controls.Add(this.xLabel26);
            this.pnlJinryo.Controls.Add(this.xLabel31);
            this.pnlJinryo.Controls.Add(this.cboPm_gwa_room7);
            this.pnlJinryo.Controls.Add(this.cboPm_gwa_room6);
            this.pnlJinryo.Controls.Add(this.cboPm_gwa_room5);
            this.pnlJinryo.Controls.Add(this.cboPm_gwa_room4);
            this.pnlJinryo.Controls.Add(this.cboPm_gwa_room3);
            this.pnlJinryo.Controls.Add(this.cboPm_gwa_room2);
            this.pnlJinryo.Controls.Add(this.cboPm_gwa_room1);
            this.pnlJinryo.Controls.Add(this.emkPm_end_hhmm7);
            this.pnlJinryo.Controls.Add(this.emkPm_start_hhmm7);
            this.pnlJinryo.Controls.Add(this.xLabel51);
            this.pnlJinryo.Controls.Add(this.emkAm_end_hhmm7);
            this.pnlJinryo.Controls.Add(this.emkAm_start_hhmm7);
            this.pnlJinryo.Controls.Add(this.xLabel52);
            this.pnlJinryo.Controls.Add(this.xLabel54);
            this.pnlJinryo.Controls.Add(this.emkPm_end_hhmm6);
            this.pnlJinryo.Controls.Add(this.emkPm_start_hhmm6);
            this.pnlJinryo.Controls.Add(this.xLabel47);
            this.pnlJinryo.Controls.Add(this.emkAm_end_hhmm6);
            this.pnlJinryo.Controls.Add(this.emkAm_start_hhmm6);
            this.pnlJinryo.Controls.Add(this.xLabel48);
            this.pnlJinryo.Controls.Add(this.xLabel50);
            this.pnlJinryo.Controls.Add(this.emkPm_end_hhmm5);
            this.pnlJinryo.Controls.Add(this.emkPm_start_hhmm5);
            this.pnlJinryo.Controls.Add(this.xLabel43);
            this.pnlJinryo.Controls.Add(this.emkAm_end_hhmm5);
            this.pnlJinryo.Controls.Add(this.emkAm_start_hhmm5);
            this.pnlJinryo.Controls.Add(this.xLabel44);
            this.pnlJinryo.Controls.Add(this.xLabel46);
            this.pnlJinryo.Controls.Add(this.emkPm_end_hhmm4);
            this.pnlJinryo.Controls.Add(this.xLabel34);
            this.pnlJinryo.Controls.Add(this.emkAm_end_hhmm4);
            this.pnlJinryo.Controls.Add(this.emkAm_start_hhmm4);
            this.pnlJinryo.Controls.Add(this.xLabel35);
            this.pnlJinryo.Controls.Add(this.xLabel40);
            this.pnlJinryo.Controls.Add(this.xLabel36);
            this.pnlJinryo.Controls.Add(this.xLabel32);
            this.pnlJinryo.Controls.Add(this.xLabel28);
            this.pnlJinryo.Controls.Add(this.xLabel24);
            this.pnlJinryo.Controls.Add(this.xLabel20);
            this.pnlJinryo.Controls.Add(this.xLabel15);
            this.pnlJinryo.Font = null;
            this.pnlJinryo.Name = "pnlJinryo";
            // 
            // xLabel38
            // 
            this.xLabel38.AccessibleDescription = null;
            this.xLabel38.AccessibleName = null;
            resources.ApplyResources(this.xLabel38, "xLabel38");
            this.xLabel38.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel38.Image = null;
            this.xLabel38.Name = "xLabel38";
            // 
            // xLabel53
            // 
            this.xLabel53.AccessibleDescription = null;
            this.xLabel53.AccessibleName = null;
            resources.ApplyResources(this.xLabel53, "xLabel53");
            this.xLabel53.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel53.Image = null;
            this.xLabel53.Name = "xLabel53";
            // 
            // xLabel49
            // 
            this.xLabel49.AccessibleDescription = null;
            this.xLabel49.AccessibleName = null;
            resources.ApplyResources(this.xLabel49, "xLabel49");
            this.xLabel49.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel49.Image = null;
            this.xLabel49.Name = "xLabel49";
            // 
            // xLabel45
            // 
            this.xLabel45.AccessibleDescription = null;
            this.xLabel45.AccessibleName = null;
            resources.ApplyResources(this.xLabel45, "xLabel45");
            this.xLabel45.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel45.Image = null;
            this.xLabel45.Name = "xLabel45";
            // 
            // emkPm_start_hhmm2
            // 
            this.emkPm_start_hhmm2.AccessibleDescription = null;
            this.emkPm_start_hhmm2.AccessibleName = null;
            resources.ApplyResources(this.emkPm_start_hhmm2, "emkPm_start_hhmm2");
            this.emkPm_start_hhmm2.BackgroundImage = null;
            this.emkPm_start_hhmm2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm2.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm2.IsVietnameseYearType = false;
            this.emkPm_start_hhmm2.Mask = "HH:MI";
            this.emkPm_start_hhmm2.Name = "emkPm_start_hhmm2";
            this.emkPm_start_hhmm2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // cboAm_gwa_room6
            // 
            this.cboAm_gwa_room6.AccessibleDescription = null;
            this.cboAm_gwa_room6.AccessibleName = null;
            resources.ApplyResources(this.cboAm_gwa_room6, "cboAm_gwa_room6");
            this.cboAm_gwa_room6.BackgroundImage = null;
            this.cboAm_gwa_room6.Name = "cboAm_gwa_room6";
            // 
            // emkAm_end_hhmm2
            // 
            this.emkAm_end_hhmm2.AccessibleDescription = null;
            this.emkAm_end_hhmm2.AccessibleName = null;
            resources.ApplyResources(this.emkAm_end_hhmm2, "emkAm_end_hhmm2");
            this.emkAm_end_hhmm2.BackgroundImage = null;
            this.emkAm_end_hhmm2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm2.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm2.IsVietnameseYearType = false;
            this.emkAm_end_hhmm2.Mask = "HH:MI";
            this.emkAm_end_hhmm2.Name = "emkAm_end_hhmm2";
            this.emkAm_end_hhmm2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkAm_start_hhmm2
            // 
            this.emkAm_start_hhmm2.AccessibleDescription = null;
            this.emkAm_start_hhmm2.AccessibleName = null;
            resources.ApplyResources(this.emkAm_start_hhmm2, "emkAm_start_hhmm2");
            this.emkAm_start_hhmm2.BackgroundImage = null;
            this.emkAm_start_hhmm2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm2.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm2.IsVietnameseYearType = false;
            this.emkAm_start_hhmm2.Mask = "HH:MI";
            this.emkAm_start_hhmm2.Name = "emkAm_start_hhmm2";
            this.emkAm_start_hhmm2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkPm_start_hhmm4
            // 
            this.emkPm_start_hhmm4.AccessibleDescription = null;
            this.emkPm_start_hhmm4.AccessibleName = null;
            resources.ApplyResources(this.emkPm_start_hhmm4, "emkPm_start_hhmm4");
            this.emkPm_start_hhmm4.BackgroundImage = null;
            this.emkPm_start_hhmm4.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm4.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm4.IsVietnameseYearType = false;
            this.emkPm_start_hhmm4.Mask = "HH:MI";
            this.emkPm_start_hhmm4.Name = "emkPm_start_hhmm4";
            this.emkPm_start_hhmm4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // cboAm_gwa_room1
            // 
            this.cboAm_gwa_room1.AccessibleDescription = null;
            this.cboAm_gwa_room1.AccessibleName = null;
            resources.ApplyResources(this.cboAm_gwa_room1, "cboAm_gwa_room1");
            this.cboAm_gwa_room1.BackgroundImage = null;
            this.cboAm_gwa_room1.Name = "cboAm_gwa_room1";
            // 
            // xLabel16
            // 
            this.xLabel16.AccessibleDescription = null;
            this.xLabel16.AccessibleName = null;
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel16.Name = "xLabel16";
            // 
            // xLabel39
            // 
            this.xLabel39.AccessibleDescription = null;
            this.xLabel39.AccessibleName = null;
            resources.ApplyResources(this.xLabel39, "xLabel39");
            this.xLabel39.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel39.Image = null;
            this.xLabel39.Name = "xLabel39";
            // 
            // emkPm_end_hhmm3
            // 
            this.emkPm_end_hhmm3.AccessibleDescription = null;
            this.emkPm_end_hhmm3.AccessibleName = null;
            resources.ApplyResources(this.emkPm_end_hhmm3, "emkPm_end_hhmm3");
            this.emkPm_end_hhmm3.BackgroundImage = null;
            this.emkPm_end_hhmm3.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm3.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm3.IsVietnameseYearType = false;
            this.emkPm_end_hhmm3.Mask = "HH:MI";
            this.emkPm_end_hhmm3.Name = "emkPm_end_hhmm3";
            this.emkPm_end_hhmm3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkPm_start_hhmm3
            // 
            this.emkPm_start_hhmm3.AccessibleDescription = null;
            this.emkPm_start_hhmm3.AccessibleName = null;
            resources.ApplyResources(this.emkPm_start_hhmm3, "emkPm_start_hhmm3");
            this.emkPm_start_hhmm3.BackgroundImage = null;
            this.emkPm_start_hhmm3.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm3.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm3.IsVietnameseYearType = false;
            this.emkPm_start_hhmm3.Mask = "HH:MI";
            this.emkPm_start_hhmm3.Name = "emkPm_start_hhmm3";
            this.emkPm_start_hhmm3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkPm_end_hhmm2
            // 
            this.emkPm_end_hhmm2.AccessibleDescription = null;
            this.emkPm_end_hhmm2.AccessibleName = null;
            resources.ApplyResources(this.emkPm_end_hhmm2, "emkPm_end_hhmm2");
            this.emkPm_end_hhmm2.BackgroundImage = null;
            this.emkPm_end_hhmm2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm2.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm2.IsVietnameseYearType = false;
            this.emkPm_end_hhmm2.Mask = "HH:MI";
            this.emkPm_end_hhmm2.Name = "emkPm_end_hhmm2";
            this.emkPm_end_hhmm2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkAm_end_hhmm3
            // 
            this.emkAm_end_hhmm3.AccessibleDescription = null;
            this.emkAm_end_hhmm3.AccessibleName = null;
            resources.ApplyResources(this.emkAm_end_hhmm3, "emkAm_end_hhmm3");
            this.emkAm_end_hhmm3.BackgroundImage = null;
            this.emkAm_end_hhmm3.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm3.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm3.IsVietnameseYearType = false;
            this.emkAm_end_hhmm3.Mask = "HH:MI";
            this.emkAm_end_hhmm3.Name = "emkAm_end_hhmm3";
            this.emkAm_end_hhmm3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkAm_start_hhmm3
            // 
            this.emkAm_start_hhmm3.AccessibleDescription = null;
            this.emkAm_start_hhmm3.AccessibleName = null;
            resources.ApplyResources(this.emkAm_start_hhmm3, "emkAm_start_hhmm3");
            this.emkAm_start_hhmm3.BackgroundImage = null;
            this.emkAm_start_hhmm3.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm3.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm3.IsVietnameseYearType = false;
            this.emkAm_start_hhmm3.Mask = "HH:MI";
            this.emkAm_start_hhmm3.Name = "emkAm_start_hhmm3";
            this.emkAm_start_hhmm3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel27
            // 
            this.xLabel27.AccessibleDescription = null;
            this.xLabel27.AccessibleName = null;
            resources.ApplyResources(this.xLabel27, "xLabel27");
            this.xLabel27.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel27.Name = "xLabel27";
            // 
            // xLabel30
            // 
            this.xLabel30.AccessibleDescription = null;
            this.xLabel30.AccessibleName = null;
            resources.ApplyResources(this.xLabel30, "xLabel30");
            this.xLabel30.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel30.Image = null;
            this.xLabel30.Name = "xLabel30";
            // 
            // xLabel19
            // 
            this.xLabel19.AccessibleDescription = null;
            this.xLabel19.AccessibleName = null;
            resources.ApplyResources(this.xLabel19, "xLabel19");
            this.xLabel19.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel19.Name = "xLabel19";
            // 
            // xLabel22
            // 
            this.xLabel22.AccessibleDescription = null;
            this.xLabel22.AccessibleName = null;
            resources.ApplyResources(this.xLabel22, "xLabel22");
            this.xLabel22.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel22.Image = null;
            this.xLabel22.Name = "xLabel22";
            // 
            // xLabel23
            // 
            this.xLabel23.AccessibleDescription = null;
            this.xLabel23.AccessibleName = null;
            resources.ApplyResources(this.xLabel23, "xLabel23");
            this.xLabel23.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel23.Image = null;
            this.xLabel23.Name = "xLabel23";
            // 
            // emkPm_end_hhmm1
            // 
            this.emkPm_end_hhmm1.AccessibleDescription = null;
            this.emkPm_end_hhmm1.AccessibleName = null;
            resources.ApplyResources(this.emkPm_end_hhmm1, "emkPm_end_hhmm1");
            this.emkPm_end_hhmm1.BackgroundImage = null;
            this.emkPm_end_hhmm1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm1.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm1.IsVietnameseYearType = false;
            this.emkPm_end_hhmm1.Mask = "HH:MI";
            this.emkPm_end_hhmm1.Name = "emkPm_end_hhmm1";
            this.emkPm_end_hhmm1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkPm_start_hhmm1
            // 
            this.emkPm_start_hhmm1.AccessibleDescription = null;
            this.emkPm_start_hhmm1.AccessibleName = null;
            resources.ApplyResources(this.emkPm_start_hhmm1, "emkPm_start_hhmm1");
            this.emkPm_start_hhmm1.BackgroundImage = null;
            this.emkPm_start_hhmm1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm1.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm1.IsVietnameseYearType = false;
            this.emkPm_start_hhmm1.Mask = "HH:MI";
            this.emkPm_start_hhmm1.Name = "emkPm_start_hhmm1";
            this.emkPm_start_hhmm1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel42
            // 
            this.xLabel42.AccessibleDescription = null;
            this.xLabel42.AccessibleName = null;
            resources.ApplyResources(this.xLabel42, "xLabel42");
            this.xLabel42.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel42.Name = "xLabel42";
            // 
            // emkAm_end_hhmm1
            // 
            this.emkAm_end_hhmm1.AccessibleDescription = null;
            this.emkAm_end_hhmm1.AccessibleName = null;
            resources.ApplyResources(this.emkAm_end_hhmm1, "emkAm_end_hhmm1");
            this.emkAm_end_hhmm1.BackgroundImage = null;
            this.emkAm_end_hhmm1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm1.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm1.IsVietnameseYearType = false;
            this.emkAm_end_hhmm1.Mask = "HH:MI";
            this.emkAm_end_hhmm1.Name = "emkAm_end_hhmm1";
            this.emkAm_end_hhmm1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkAm_start_hhmm1
            // 
            this.emkAm_start_hhmm1.AccessibleDescription = null;
            this.emkAm_start_hhmm1.AccessibleName = null;
            resources.ApplyResources(this.emkAm_start_hhmm1, "emkAm_start_hhmm1");
            this.emkAm_start_hhmm1.BackgroundImage = null;
            this.emkAm_start_hhmm1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm1.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm1.IsVietnameseYearType = false;
            this.emkAm_start_hhmm1.Mask = "HH:MI";
            this.emkAm_start_hhmm1.Name = "emkAm_start_hhmm1";
            this.emkAm_start_hhmm1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel41
            // 
            this.xLabel41.AccessibleDescription = null;
            this.xLabel41.AccessibleName = null;
            resources.ApplyResources(this.xLabel41, "xLabel41");
            this.xLabel41.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel41.Name = "xLabel41";
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel10
            // 
            this.xLabel10.AccessibleDescription = null;
            this.xLabel10.AccessibleName = null;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel10.Image = null;
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // cboAm_gwa_room7
            // 
            this.cboAm_gwa_room7.AccessibleDescription = null;
            this.cboAm_gwa_room7.AccessibleName = null;
            resources.ApplyResources(this.cboAm_gwa_room7, "cboAm_gwa_room7");
            this.cboAm_gwa_room7.BackgroundImage = null;
            this.cboAm_gwa_room7.Name = "cboAm_gwa_room7";
            // 
            // xLabel37
            // 
            this.xLabel37.AccessibleDescription = null;
            this.xLabel37.AccessibleName = null;
            resources.ApplyResources(this.xLabel37, "xLabel37");
            this.xLabel37.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel37.Name = "xLabel37";
            // 
            // xLabel33
            // 
            this.xLabel33.AccessibleDescription = null;
            this.xLabel33.AccessibleName = null;
            resources.ApplyResources(this.xLabel33, "xLabel33");
            this.xLabel33.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel33.Name = "xLabel33";
            // 
            // cboAm_gwa_room5
            // 
            this.cboAm_gwa_room5.AccessibleDescription = null;
            this.cboAm_gwa_room5.AccessibleName = null;
            resources.ApplyResources(this.cboAm_gwa_room5, "cboAm_gwa_room5");
            this.cboAm_gwa_room5.BackgroundImage = null;
            this.cboAm_gwa_room5.Name = "cboAm_gwa_room5";
            // 
            // xLabel29
            // 
            this.xLabel29.AccessibleDescription = null;
            this.xLabel29.AccessibleName = null;
            resources.ApplyResources(this.xLabel29, "xLabel29");
            this.xLabel29.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel29.Name = "xLabel29";
            // 
            // cboAm_gwa_room4
            // 
            this.cboAm_gwa_room4.AccessibleDescription = null;
            this.cboAm_gwa_room4.AccessibleName = null;
            resources.ApplyResources(this.cboAm_gwa_room4, "cboAm_gwa_room4");
            this.cboAm_gwa_room4.BackgroundImage = null;
            this.cboAm_gwa_room4.Name = "cboAm_gwa_room4";
            // 
            // xLabel25
            // 
            this.xLabel25.AccessibleDescription = null;
            this.xLabel25.AccessibleName = null;
            resources.ApplyResources(this.xLabel25, "xLabel25");
            this.xLabel25.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel25.Name = "xLabel25";
            // 
            // cboAm_gwa_room3
            // 
            this.cboAm_gwa_room3.AccessibleDescription = null;
            this.cboAm_gwa_room3.AccessibleName = null;
            resources.ApplyResources(this.cboAm_gwa_room3, "cboAm_gwa_room3");
            this.cboAm_gwa_room3.BackgroundImage = null;
            this.cboAm_gwa_room3.Name = "cboAm_gwa_room3";
            // 
            // xLabel21
            // 
            this.xLabel21.AccessibleDescription = null;
            this.xLabel21.AccessibleName = null;
            resources.ApplyResources(this.xLabel21, "xLabel21");
            this.xLabel21.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel21.Name = "xLabel21";
            // 
            // cboAm_gwa_room2
            // 
            this.cboAm_gwa_room2.AccessibleDescription = null;
            this.cboAm_gwa_room2.AccessibleName = null;
            resources.ApplyResources(this.cboAm_gwa_room2, "cboAm_gwa_room2");
            this.cboAm_gwa_room2.BackgroundImage = null;
            this.cboAm_gwa_room2.Name = "cboAm_gwa_room2";
            // 
            // xLabel17
            // 
            this.xLabel17.AccessibleDescription = null;
            this.xLabel17.AccessibleName = null;
            resources.ApplyResources(this.xLabel17, "xLabel17");
            this.xLabel17.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel17.Name = "xLabel17";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel18
            // 
            this.xLabel18.AccessibleDescription = null;
            this.xLabel18.AccessibleName = null;
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel18.Name = "xLabel18";
            // 
            // xLabel26
            // 
            this.xLabel26.AccessibleDescription = null;
            this.xLabel26.AccessibleName = null;
            resources.ApplyResources(this.xLabel26, "xLabel26");
            this.xLabel26.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel26.Name = "xLabel26";
            // 
            // xLabel31
            // 
            this.xLabel31.AccessibleDescription = null;
            this.xLabel31.AccessibleName = null;
            resources.ApplyResources(this.xLabel31, "xLabel31");
            this.xLabel31.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel31.Image = null;
            this.xLabel31.Name = "xLabel31";
            // 
            // cboPm_gwa_room7
            // 
            this.cboPm_gwa_room7.AccessibleDescription = null;
            this.cboPm_gwa_room7.AccessibleName = null;
            resources.ApplyResources(this.cboPm_gwa_room7, "cboPm_gwa_room7");
            this.cboPm_gwa_room7.BackgroundImage = null;
            this.cboPm_gwa_room7.Name = "cboPm_gwa_room7";
            // 
            // cboPm_gwa_room6
            // 
            this.cboPm_gwa_room6.AccessibleDescription = null;
            this.cboPm_gwa_room6.AccessibleName = null;
            resources.ApplyResources(this.cboPm_gwa_room6, "cboPm_gwa_room6");
            this.cboPm_gwa_room6.BackgroundImage = null;
            this.cboPm_gwa_room6.Name = "cboPm_gwa_room6";
            // 
            // cboPm_gwa_room5
            // 
            this.cboPm_gwa_room5.AccessibleDescription = null;
            this.cboPm_gwa_room5.AccessibleName = null;
            resources.ApplyResources(this.cboPm_gwa_room5, "cboPm_gwa_room5");
            this.cboPm_gwa_room5.BackgroundImage = null;
            this.cboPm_gwa_room5.Name = "cboPm_gwa_room5";
            // 
            // cboPm_gwa_room4
            // 
            this.cboPm_gwa_room4.AccessibleDescription = null;
            this.cboPm_gwa_room4.AccessibleName = null;
            resources.ApplyResources(this.cboPm_gwa_room4, "cboPm_gwa_room4");
            this.cboPm_gwa_room4.BackgroundImage = null;
            this.cboPm_gwa_room4.Name = "cboPm_gwa_room4";
            // 
            // cboPm_gwa_room3
            // 
            this.cboPm_gwa_room3.AccessibleDescription = null;
            this.cboPm_gwa_room3.AccessibleName = null;
            resources.ApplyResources(this.cboPm_gwa_room3, "cboPm_gwa_room3");
            this.cboPm_gwa_room3.BackgroundImage = null;
            this.cboPm_gwa_room3.Name = "cboPm_gwa_room3";
            // 
            // cboPm_gwa_room2
            // 
            this.cboPm_gwa_room2.AccessibleDescription = null;
            this.cboPm_gwa_room2.AccessibleName = null;
            resources.ApplyResources(this.cboPm_gwa_room2, "cboPm_gwa_room2");
            this.cboPm_gwa_room2.BackgroundImage = null;
            this.cboPm_gwa_room2.Name = "cboPm_gwa_room2";
            // 
            // cboPm_gwa_room1
            // 
            this.cboPm_gwa_room1.AccessibleDescription = null;
            this.cboPm_gwa_room1.AccessibleName = null;
            resources.ApplyResources(this.cboPm_gwa_room1, "cboPm_gwa_room1");
            this.cboPm_gwa_room1.BackgroundImage = null;
            this.cboPm_gwa_room1.Name = "cboPm_gwa_room1";
            // 
            // emkPm_end_hhmm7
            // 
            this.emkPm_end_hhmm7.AccessibleDescription = null;
            this.emkPm_end_hhmm7.AccessibleName = null;
            resources.ApplyResources(this.emkPm_end_hhmm7, "emkPm_end_hhmm7");
            this.emkPm_end_hhmm7.BackgroundImage = null;
            this.emkPm_end_hhmm7.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm7.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm7.IsVietnameseYearType = false;
            this.emkPm_end_hhmm7.Mask = "HH:MI";
            this.emkPm_end_hhmm7.Name = "emkPm_end_hhmm7";
            this.emkPm_end_hhmm7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkPm_start_hhmm7
            // 
            this.emkPm_start_hhmm7.AccessibleDescription = null;
            this.emkPm_start_hhmm7.AccessibleName = null;
            resources.ApplyResources(this.emkPm_start_hhmm7, "emkPm_start_hhmm7");
            this.emkPm_start_hhmm7.BackgroundImage = null;
            this.emkPm_start_hhmm7.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm7.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm7.IsVietnameseYearType = false;
            this.emkPm_start_hhmm7.Mask = "HH:MI";
            this.emkPm_start_hhmm7.Name = "emkPm_start_hhmm7";
            this.emkPm_start_hhmm7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel51
            // 
            this.xLabel51.AccessibleDescription = null;
            this.xLabel51.AccessibleName = null;
            resources.ApplyResources(this.xLabel51, "xLabel51");
            this.xLabel51.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel51.Name = "xLabel51";
            // 
            // emkAm_end_hhmm7
            // 
            this.emkAm_end_hhmm7.AccessibleDescription = null;
            this.emkAm_end_hhmm7.AccessibleName = null;
            resources.ApplyResources(this.emkAm_end_hhmm7, "emkAm_end_hhmm7");
            this.emkAm_end_hhmm7.BackgroundImage = null;
            this.emkAm_end_hhmm7.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm7.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm7.IsVietnameseYearType = false;
            this.emkAm_end_hhmm7.Mask = "HH:MI";
            this.emkAm_end_hhmm7.Name = "emkAm_end_hhmm7";
            this.emkAm_end_hhmm7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkAm_start_hhmm7
            // 
            this.emkAm_start_hhmm7.AccessibleDescription = null;
            this.emkAm_start_hhmm7.AccessibleName = null;
            resources.ApplyResources(this.emkAm_start_hhmm7, "emkAm_start_hhmm7");
            this.emkAm_start_hhmm7.BackgroundImage = null;
            this.emkAm_start_hhmm7.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm7.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm7.IsVietnameseYearType = false;
            this.emkAm_start_hhmm7.Mask = "HH:MI";
            this.emkAm_start_hhmm7.Name = "emkAm_start_hhmm7";
            this.emkAm_start_hhmm7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel52
            // 
            this.xLabel52.AccessibleDescription = null;
            this.xLabel52.AccessibleName = null;
            resources.ApplyResources(this.xLabel52, "xLabel52");
            this.xLabel52.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel52.Name = "xLabel52";
            // 
            // xLabel54
            // 
            this.xLabel54.AccessibleDescription = null;
            this.xLabel54.AccessibleName = null;
            resources.ApplyResources(this.xLabel54, "xLabel54");
            this.xLabel54.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel54.Image = null;
            this.xLabel54.Name = "xLabel54";
            // 
            // emkPm_end_hhmm6
            // 
            this.emkPm_end_hhmm6.AccessibleDescription = null;
            this.emkPm_end_hhmm6.AccessibleName = null;
            resources.ApplyResources(this.emkPm_end_hhmm6, "emkPm_end_hhmm6");
            this.emkPm_end_hhmm6.BackgroundImage = null;
            this.emkPm_end_hhmm6.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm6.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm6.IsVietnameseYearType = false;
            this.emkPm_end_hhmm6.Mask = "HH:MI";
            this.emkPm_end_hhmm6.Name = "emkPm_end_hhmm6";
            this.emkPm_end_hhmm6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkPm_start_hhmm6
            // 
            this.emkPm_start_hhmm6.AccessibleDescription = null;
            this.emkPm_start_hhmm6.AccessibleName = null;
            resources.ApplyResources(this.emkPm_start_hhmm6, "emkPm_start_hhmm6");
            this.emkPm_start_hhmm6.BackgroundImage = null;
            this.emkPm_start_hhmm6.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm6.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm6.IsVietnameseYearType = false;
            this.emkPm_start_hhmm6.Mask = "HH:MI";
            this.emkPm_start_hhmm6.Name = "emkPm_start_hhmm6";
            this.emkPm_start_hhmm6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel47
            // 
            this.xLabel47.AccessibleDescription = null;
            this.xLabel47.AccessibleName = null;
            resources.ApplyResources(this.xLabel47, "xLabel47");
            this.xLabel47.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel47.Name = "xLabel47";
            // 
            // emkAm_end_hhmm6
            // 
            this.emkAm_end_hhmm6.AccessibleDescription = null;
            this.emkAm_end_hhmm6.AccessibleName = null;
            resources.ApplyResources(this.emkAm_end_hhmm6, "emkAm_end_hhmm6");
            this.emkAm_end_hhmm6.BackgroundImage = null;
            this.emkAm_end_hhmm6.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm6.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm6.IsVietnameseYearType = false;
            this.emkAm_end_hhmm6.Mask = "HH:MI";
            this.emkAm_end_hhmm6.Name = "emkAm_end_hhmm6";
            this.emkAm_end_hhmm6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkAm_start_hhmm6
            // 
            this.emkAm_start_hhmm6.AccessibleDescription = null;
            this.emkAm_start_hhmm6.AccessibleName = null;
            resources.ApplyResources(this.emkAm_start_hhmm6, "emkAm_start_hhmm6");
            this.emkAm_start_hhmm6.BackgroundImage = null;
            this.emkAm_start_hhmm6.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm6.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm6.IsVietnameseYearType = false;
            this.emkAm_start_hhmm6.Mask = "HH:MI";
            this.emkAm_start_hhmm6.Name = "emkAm_start_hhmm6";
            this.emkAm_start_hhmm6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel48
            // 
            this.xLabel48.AccessibleDescription = null;
            this.xLabel48.AccessibleName = null;
            resources.ApplyResources(this.xLabel48, "xLabel48");
            this.xLabel48.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel48.Name = "xLabel48";
            // 
            // xLabel50
            // 
            this.xLabel50.AccessibleDescription = null;
            this.xLabel50.AccessibleName = null;
            resources.ApplyResources(this.xLabel50, "xLabel50");
            this.xLabel50.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel50.Image = null;
            this.xLabel50.Name = "xLabel50";
            // 
            // emkPm_end_hhmm5
            // 
            this.emkPm_end_hhmm5.AccessibleDescription = null;
            this.emkPm_end_hhmm5.AccessibleName = null;
            resources.ApplyResources(this.emkPm_end_hhmm5, "emkPm_end_hhmm5");
            this.emkPm_end_hhmm5.BackgroundImage = null;
            this.emkPm_end_hhmm5.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm5.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm5.IsVietnameseYearType = false;
            this.emkPm_end_hhmm5.Mask = "HH:MI";
            this.emkPm_end_hhmm5.Name = "emkPm_end_hhmm5";
            this.emkPm_end_hhmm5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkPm_start_hhmm5
            // 
            this.emkPm_start_hhmm5.AccessibleDescription = null;
            this.emkPm_start_hhmm5.AccessibleName = null;
            resources.ApplyResources(this.emkPm_start_hhmm5, "emkPm_start_hhmm5");
            this.emkPm_start_hhmm5.BackgroundImage = null;
            this.emkPm_start_hhmm5.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm5.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_start_hhmm5.IsVietnameseYearType = false;
            this.emkPm_start_hhmm5.Mask = "HH:MI";
            this.emkPm_start_hhmm5.Name = "emkPm_start_hhmm5";
            this.emkPm_start_hhmm5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel43
            // 
            this.xLabel43.AccessibleDescription = null;
            this.xLabel43.AccessibleName = null;
            resources.ApplyResources(this.xLabel43, "xLabel43");
            this.xLabel43.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel43.Name = "xLabel43";
            // 
            // emkAm_end_hhmm5
            // 
            this.emkAm_end_hhmm5.AccessibleDescription = null;
            this.emkAm_end_hhmm5.AccessibleName = null;
            resources.ApplyResources(this.emkAm_end_hhmm5, "emkAm_end_hhmm5");
            this.emkAm_end_hhmm5.BackgroundImage = null;
            this.emkAm_end_hhmm5.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm5.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm5.IsVietnameseYearType = false;
            this.emkAm_end_hhmm5.Mask = "HH:MI";
            this.emkAm_end_hhmm5.Name = "emkAm_end_hhmm5";
            this.emkAm_end_hhmm5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkAm_start_hhmm5
            // 
            this.emkAm_start_hhmm5.AccessibleDescription = null;
            this.emkAm_start_hhmm5.AccessibleName = null;
            resources.ApplyResources(this.emkAm_start_hhmm5, "emkAm_start_hhmm5");
            this.emkAm_start_hhmm5.BackgroundImage = null;
            this.emkAm_start_hhmm5.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm5.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm5.IsVietnameseYearType = false;
            this.emkAm_start_hhmm5.Mask = "HH:MI";
            this.emkAm_start_hhmm5.Name = "emkAm_start_hhmm5";
            this.emkAm_start_hhmm5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel44
            // 
            this.xLabel44.AccessibleDescription = null;
            this.xLabel44.AccessibleName = null;
            resources.ApplyResources(this.xLabel44, "xLabel44");
            this.xLabel44.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel44.Name = "xLabel44";
            // 
            // xLabel46
            // 
            this.xLabel46.AccessibleDescription = null;
            this.xLabel46.AccessibleName = null;
            resources.ApplyResources(this.xLabel46, "xLabel46");
            this.xLabel46.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel46.Image = null;
            this.xLabel46.Name = "xLabel46";
            // 
            // emkPm_end_hhmm4
            // 
            this.emkPm_end_hhmm4.AccessibleDescription = null;
            this.emkPm_end_hhmm4.AccessibleName = null;
            resources.ApplyResources(this.emkPm_end_hhmm4, "emkPm_end_hhmm4");
            this.emkPm_end_hhmm4.BackgroundImage = null;
            this.emkPm_end_hhmm4.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm4.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkPm_end_hhmm4.IsVietnameseYearType = false;
            this.emkPm_end_hhmm4.Mask = "HH:MI";
            this.emkPm_end_hhmm4.Name = "emkPm_end_hhmm4";
            this.emkPm_end_hhmm4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel34
            // 
            this.xLabel34.AccessibleDescription = null;
            this.xLabel34.AccessibleName = null;
            resources.ApplyResources(this.xLabel34, "xLabel34");
            this.xLabel34.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel34.Name = "xLabel34";
            // 
            // emkAm_end_hhmm4
            // 
            this.emkAm_end_hhmm4.AccessibleDescription = null;
            this.emkAm_end_hhmm4.AccessibleName = null;
            resources.ApplyResources(this.emkAm_end_hhmm4, "emkAm_end_hhmm4");
            this.emkAm_end_hhmm4.BackgroundImage = null;
            this.emkAm_end_hhmm4.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm4.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_end_hhmm4.IsVietnameseYearType = false;
            this.emkAm_end_hhmm4.Mask = "HH:MI";
            this.emkAm_end_hhmm4.Name = "emkAm_end_hhmm4";
            this.emkAm_end_hhmm4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkAm_start_hhmm4
            // 
            this.emkAm_start_hhmm4.AccessibleDescription = null;
            this.emkAm_start_hhmm4.AccessibleName = null;
            resources.ApplyResources(this.emkAm_start_hhmm4, "emkAm_start_hhmm4");
            this.emkAm_start_hhmm4.BackgroundImage = null;
            this.emkAm_start_hhmm4.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm4.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkAm_start_hhmm4.IsVietnameseYearType = false;
            this.emkAm_start_hhmm4.Mask = "HH:MI";
            this.emkAm_start_hhmm4.Name = "emkAm_start_hhmm4";
            this.emkAm_start_hhmm4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel35
            // 
            this.xLabel35.AccessibleDescription = null;
            this.xLabel35.AccessibleName = null;
            resources.ApplyResources(this.xLabel35, "xLabel35");
            this.xLabel35.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel35.Name = "xLabel35";
            // 
            // xLabel40
            // 
            this.xLabel40.AccessibleDescription = null;
            this.xLabel40.AccessibleName = null;
            resources.ApplyResources(this.xLabel40, "xLabel40");
            this.xLabel40.EdgeRounding = false;
            this.xLabel40.Image = null;
            this.xLabel40.Name = "xLabel40";
            // 
            // xLabel36
            // 
            this.xLabel36.AccessibleDescription = null;
            this.xLabel36.AccessibleName = null;
            resources.ApplyResources(this.xLabel36, "xLabel36");
            this.xLabel36.EdgeRounding = false;
            this.xLabel36.Image = null;
            this.xLabel36.Name = "xLabel36";
            // 
            // xLabel32
            // 
            this.xLabel32.AccessibleDescription = null;
            this.xLabel32.AccessibleName = null;
            resources.ApplyResources(this.xLabel32, "xLabel32");
            this.xLabel32.EdgeRounding = false;
            this.xLabel32.Image = null;
            this.xLabel32.Name = "xLabel32";
            // 
            // xLabel28
            // 
            this.xLabel28.AccessibleDescription = null;
            this.xLabel28.AccessibleName = null;
            resources.ApplyResources(this.xLabel28, "xLabel28");
            this.xLabel28.EdgeRounding = false;
            this.xLabel28.Image = null;
            this.xLabel28.Name = "xLabel28";
            // 
            // xLabel24
            // 
            this.xLabel24.AccessibleDescription = null;
            this.xLabel24.AccessibleName = null;
            resources.ApplyResources(this.xLabel24, "xLabel24");
            this.xLabel24.EdgeRounding = false;
            this.xLabel24.Image = null;
            this.xLabel24.Name = "xLabel24";
            // 
            // xLabel20
            // 
            this.xLabel20.AccessibleDescription = null;
            this.xLabel20.AccessibleName = null;
            resources.ApplyResources(this.xLabel20, "xLabel20");
            this.xLabel20.EdgeRounding = false;
            this.xLabel20.Image = null;
            this.xLabel20.Name = "xLabel20";
            // 
            // xLabel15
            // 
            this.xLabel15.AccessibleDescription = null;
            this.xLabel15.AccessibleName = null;
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.Image = null;
            this.xLabel15.Name = "xLabel15";
            // 
            // pnlReser
            // 
            this.pnlReser.AccessibleDescription = null;
            this.pnlReser.AccessibleName = null;
            resources.ApplyResources(this.pnlReser, "pnlReser");
            this.pnlReser.BackgroundImage = null;
            this.pnlReser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlReser.Controls.Add(this.emkRes_pm_start_hhmm2);
            this.pnlReser.Controls.Add(this.emkRes_am_end_hhmm2);
            this.pnlReser.Controls.Add(this.emkRes_am_start_hhmm2);
            this.pnlReser.Controls.Add(this.emkRes_pm_start_hhmm4);
            this.pnlReser.Controls.Add(this.xLabel61);
            this.pnlReser.Controls.Add(this.emkRes_pm_end_hhmm3);
            this.pnlReser.Controls.Add(this.emkRes_pm_start_hhmm3);
            this.pnlReser.Controls.Add(this.emkRes_pm_end_hhmm2);
            this.pnlReser.Controls.Add(this.emkRes_am_end_hhmm3);
            this.pnlReser.Controls.Add(this.emkRes_am_start_hhmm3);
            this.pnlReser.Controls.Add(this.xLabel62);
            this.pnlReser.Controls.Add(this.xLabel63);
            this.pnlReser.Controls.Add(this.xLabel64);
            this.pnlReser.Controls.Add(this.xLabel65);
            this.pnlReser.Controls.Add(this.xLabel66);
            this.pnlReser.Controls.Add(this.emkRes_pm_end_hhmm1);
            this.pnlReser.Controls.Add(this.emkRes_pm_start_hhmm1);
            this.pnlReser.Controls.Add(this.xLabel67);
            this.pnlReser.Controls.Add(this.emkRes_am_end_hhmm1);
            this.pnlReser.Controls.Add(this.emkRes_am_start_hhmm1);
            this.pnlReser.Controls.Add(this.xLabel68);
            this.pnlReser.Controls.Add(this.xLabel69);
            this.pnlReser.Controls.Add(this.xLabel70);
            this.pnlReser.Controls.Add(this.xLabel71);
            this.pnlReser.Controls.Add(this.xLabel72);
            this.pnlReser.Controls.Add(this.xLabel73);
            this.pnlReser.Controls.Add(this.xLabel74);
            this.pnlReser.Controls.Add(this.xLabel75);
            this.pnlReser.Controls.Add(this.xLabel76);
            this.pnlReser.Controls.Add(this.xLabel83);
            this.pnlReser.Controls.Add(this.xLabel84);
            this.pnlReser.Controls.Add(this.xLabel85);
            this.pnlReser.Controls.Add(this.xLabel86);
            this.pnlReser.Controls.Add(this.emkRes_pm_end_hhmm7);
            this.pnlReser.Controls.Add(this.emkRes_pm_start_hhmm7);
            this.pnlReser.Controls.Add(this.xLabel87);
            this.pnlReser.Controls.Add(this.emkRes_am_end_hhmm7);
            this.pnlReser.Controls.Add(this.emkRes_am_start_hhmm7);
            this.pnlReser.Controls.Add(this.xLabel88);
            this.pnlReser.Controls.Add(this.xLabel89);
            this.pnlReser.Controls.Add(this.xLabel90);
            this.pnlReser.Controls.Add(this.emkRes_pm_end_hhmm6);
            this.pnlReser.Controls.Add(this.emkRes_pm_start_hhmm6);
            this.pnlReser.Controls.Add(this.xLabel91);
            this.pnlReser.Controls.Add(this.emkRes_am_end_hhmm6);
            this.pnlReser.Controls.Add(this.emkRes_am_start_hhmm6);
            this.pnlReser.Controls.Add(this.xLabel92);
            this.pnlReser.Controls.Add(this.xLabel93);
            this.pnlReser.Controls.Add(this.xLabel94);
            this.pnlReser.Controls.Add(this.emkRes_pm_end_hhmm5);
            this.pnlReser.Controls.Add(this.emkRes_pm_start_hhmm5);
            this.pnlReser.Controls.Add(this.xLabel95);
            this.pnlReser.Controls.Add(this.emkRes_am_end_hhmm5);
            this.pnlReser.Controls.Add(this.emkRes_am_start_hhmm5);
            this.pnlReser.Controls.Add(this.xLabel96);
            this.pnlReser.Controls.Add(this.xLabel97);
            this.pnlReser.Controls.Add(this.xLabel98);
            this.pnlReser.Controls.Add(this.emkRes_pm_end_hhmm4);
            this.pnlReser.Controls.Add(this.xLabel99);
            this.pnlReser.Controls.Add(this.emkRes_am_end_hhmm4);
            this.pnlReser.Controls.Add(this.emkRes_am_start_hhmm4);
            this.pnlReser.Controls.Add(this.xLabel100);
            this.pnlReser.Controls.Add(this.xLabel101);
            this.pnlReser.Controls.Add(this.xLabel102);
            this.pnlReser.Controls.Add(this.xLabel103);
            this.pnlReser.Controls.Add(this.xLabel104);
            this.pnlReser.Controls.Add(this.xLabel105);
            this.pnlReser.Controls.Add(this.xLabel106);
            this.pnlReser.Controls.Add(this.xLabel107);
            this.pnlReser.Controls.Add(this.xLabel108);
            this.pnlReser.Font = null;
            this.pnlReser.Name = "pnlReser";
            // 
            // emkRes_pm_start_hhmm2
            // 
            this.emkRes_pm_start_hhmm2.AccessibleDescription = null;
            this.emkRes_pm_start_hhmm2.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_start_hhmm2, "emkRes_pm_start_hhmm2");
            this.emkRes_pm_start_hhmm2.BackgroundImage = null;
            this.emkRes_pm_start_hhmm2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm2.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm2.IsVietnameseYearType = false;
            this.emkRes_pm_start_hhmm2.Mask = "HH:MI";
            this.emkRes_pm_start_hhmm2.Name = "emkRes_pm_start_hhmm2";
            this.emkRes_pm_start_hhmm2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_am_end_hhmm2
            // 
            this.emkRes_am_end_hhmm2.AccessibleDescription = null;
            this.emkRes_am_end_hhmm2.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_end_hhmm2, "emkRes_am_end_hhmm2");
            this.emkRes_am_end_hhmm2.BackgroundImage = null;
            this.emkRes_am_end_hhmm2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm2.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm2.IsVietnameseYearType = false;
            this.emkRes_am_end_hhmm2.Mask = "HH:MI";
            this.emkRes_am_end_hhmm2.Name = "emkRes_am_end_hhmm2";
            this.emkRes_am_end_hhmm2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_am_start_hhmm2
            // 
            this.emkRes_am_start_hhmm2.AccessibleDescription = null;
            this.emkRes_am_start_hhmm2.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_start_hhmm2, "emkRes_am_start_hhmm2");
            this.emkRes_am_start_hhmm2.BackgroundImage = null;
            this.emkRes_am_start_hhmm2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm2.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm2.IsVietnameseYearType = false;
            this.emkRes_am_start_hhmm2.Mask = "HH:MI";
            this.emkRes_am_start_hhmm2.Name = "emkRes_am_start_hhmm2";
            this.emkRes_am_start_hhmm2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_pm_start_hhmm4
            // 
            this.emkRes_pm_start_hhmm4.AccessibleDescription = null;
            this.emkRes_pm_start_hhmm4.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_start_hhmm4, "emkRes_pm_start_hhmm4");
            this.emkRes_pm_start_hhmm4.BackgroundImage = null;
            this.emkRes_pm_start_hhmm4.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm4.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm4.IsVietnameseYearType = false;
            this.emkRes_pm_start_hhmm4.Mask = "HH:MI";
            this.emkRes_pm_start_hhmm4.Name = "emkRes_pm_start_hhmm4";
            this.emkRes_pm_start_hhmm4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel61
            // 
            this.xLabel61.AccessibleDescription = null;
            this.xLabel61.AccessibleName = null;
            resources.ApplyResources(this.xLabel61, "xLabel61");
            this.xLabel61.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel61.Image = null;
            this.xLabel61.Name = "xLabel61";
            // 
            // emkRes_pm_end_hhmm3
            // 
            this.emkRes_pm_end_hhmm3.AccessibleDescription = null;
            this.emkRes_pm_end_hhmm3.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_end_hhmm3, "emkRes_pm_end_hhmm3");
            this.emkRes_pm_end_hhmm3.BackgroundImage = null;
            this.emkRes_pm_end_hhmm3.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm3.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm3.IsVietnameseYearType = false;
            this.emkRes_pm_end_hhmm3.Mask = "HH:MI";
            this.emkRes_pm_end_hhmm3.Name = "emkRes_pm_end_hhmm3";
            this.emkRes_pm_end_hhmm3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_pm_start_hhmm3
            // 
            this.emkRes_pm_start_hhmm3.AccessibleDescription = null;
            this.emkRes_pm_start_hhmm3.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_start_hhmm3, "emkRes_pm_start_hhmm3");
            this.emkRes_pm_start_hhmm3.BackgroundImage = null;
            this.emkRes_pm_start_hhmm3.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm3.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm3.IsVietnameseYearType = false;
            this.emkRes_pm_start_hhmm3.Mask = "HH:MI";
            this.emkRes_pm_start_hhmm3.Name = "emkRes_pm_start_hhmm3";
            this.emkRes_pm_start_hhmm3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_pm_end_hhmm2
            // 
            this.emkRes_pm_end_hhmm2.AccessibleDescription = null;
            this.emkRes_pm_end_hhmm2.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_end_hhmm2, "emkRes_pm_end_hhmm2");
            this.emkRes_pm_end_hhmm2.BackgroundImage = null;
            this.emkRes_pm_end_hhmm2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm2.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm2.IsVietnameseYearType = false;
            this.emkRes_pm_end_hhmm2.Mask = "HH:MI";
            this.emkRes_pm_end_hhmm2.Name = "emkRes_pm_end_hhmm2";
            this.emkRes_pm_end_hhmm2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_am_end_hhmm3
            // 
            this.emkRes_am_end_hhmm3.AccessibleDescription = null;
            this.emkRes_am_end_hhmm3.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_end_hhmm3, "emkRes_am_end_hhmm3");
            this.emkRes_am_end_hhmm3.BackgroundImage = null;
            this.emkRes_am_end_hhmm3.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm3.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm3.IsVietnameseYearType = false;
            this.emkRes_am_end_hhmm3.Mask = "HH:MI";
            this.emkRes_am_end_hhmm3.Name = "emkRes_am_end_hhmm3";
            this.emkRes_am_end_hhmm3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_am_start_hhmm3
            // 
            this.emkRes_am_start_hhmm3.AccessibleDescription = null;
            this.emkRes_am_start_hhmm3.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_start_hhmm3, "emkRes_am_start_hhmm3");
            this.emkRes_am_start_hhmm3.BackgroundImage = null;
            this.emkRes_am_start_hhmm3.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm3.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm3.IsVietnameseYearType = false;
            this.emkRes_am_start_hhmm3.Mask = "HH:MI";
            this.emkRes_am_start_hhmm3.Name = "emkRes_am_start_hhmm3";
            this.emkRes_am_start_hhmm3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel62
            // 
            this.xLabel62.AccessibleDescription = null;
            this.xLabel62.AccessibleName = null;
            resources.ApplyResources(this.xLabel62, "xLabel62");
            this.xLabel62.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel62.Name = "xLabel62";
            // 
            // xLabel63
            // 
            this.xLabel63.AccessibleDescription = null;
            this.xLabel63.AccessibleName = null;
            resources.ApplyResources(this.xLabel63, "xLabel63");
            this.xLabel63.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel63.Image = null;
            this.xLabel63.Name = "xLabel63";
            // 
            // xLabel64
            // 
            this.xLabel64.AccessibleDescription = null;
            this.xLabel64.AccessibleName = null;
            resources.ApplyResources(this.xLabel64, "xLabel64");
            this.xLabel64.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel64.Name = "xLabel64";
            // 
            // xLabel65
            // 
            this.xLabel65.AccessibleDescription = null;
            this.xLabel65.AccessibleName = null;
            resources.ApplyResources(this.xLabel65, "xLabel65");
            this.xLabel65.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel65.Image = null;
            this.xLabel65.Name = "xLabel65";
            // 
            // xLabel66
            // 
            this.xLabel66.AccessibleDescription = null;
            this.xLabel66.AccessibleName = null;
            resources.ApplyResources(this.xLabel66, "xLabel66");
            this.xLabel66.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel66.Image = null;
            this.xLabel66.Name = "xLabel66";
            // 
            // emkRes_pm_end_hhmm1
            // 
            this.emkRes_pm_end_hhmm1.AccessibleDescription = null;
            this.emkRes_pm_end_hhmm1.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_end_hhmm1, "emkRes_pm_end_hhmm1");
            this.emkRes_pm_end_hhmm1.BackgroundImage = null;
            this.emkRes_pm_end_hhmm1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm1.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm1.IsVietnameseYearType = false;
            this.emkRes_pm_end_hhmm1.Mask = "HH:MI";
            this.emkRes_pm_end_hhmm1.Name = "emkRes_pm_end_hhmm1";
            this.emkRes_pm_end_hhmm1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_pm_start_hhmm1
            // 
            this.emkRes_pm_start_hhmm1.AccessibleDescription = null;
            this.emkRes_pm_start_hhmm1.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_start_hhmm1, "emkRes_pm_start_hhmm1");
            this.emkRes_pm_start_hhmm1.BackgroundImage = null;
            this.emkRes_pm_start_hhmm1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm1.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm1.IsVietnameseYearType = false;
            this.emkRes_pm_start_hhmm1.Mask = "HH:MI";
            this.emkRes_pm_start_hhmm1.Name = "emkRes_pm_start_hhmm1";
            this.emkRes_pm_start_hhmm1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel67
            // 
            this.xLabel67.AccessibleDescription = null;
            this.xLabel67.AccessibleName = null;
            resources.ApplyResources(this.xLabel67, "xLabel67");
            this.xLabel67.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel67.Name = "xLabel67";
            // 
            // emkRes_am_end_hhmm1
            // 
            this.emkRes_am_end_hhmm1.AccessibleDescription = null;
            this.emkRes_am_end_hhmm1.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_end_hhmm1, "emkRes_am_end_hhmm1");
            this.emkRes_am_end_hhmm1.BackgroundImage = null;
            this.emkRes_am_end_hhmm1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm1.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm1.IsVietnameseYearType = false;
            this.emkRes_am_end_hhmm1.Mask = "HH:MI";
            this.emkRes_am_end_hhmm1.Name = "emkRes_am_end_hhmm1";
            this.emkRes_am_end_hhmm1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_am_start_hhmm1
            // 
            this.emkRes_am_start_hhmm1.AccessibleDescription = null;
            this.emkRes_am_start_hhmm1.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_start_hhmm1, "emkRes_am_start_hhmm1");
            this.emkRes_am_start_hhmm1.BackgroundImage = null;
            this.emkRes_am_start_hhmm1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm1.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm1.IsVietnameseYearType = false;
            this.emkRes_am_start_hhmm1.Mask = "HH:MI";
            this.emkRes_am_start_hhmm1.Name = "emkRes_am_start_hhmm1";
            this.emkRes_am_start_hhmm1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel68
            // 
            this.xLabel68.AccessibleDescription = null;
            this.xLabel68.AccessibleName = null;
            resources.ApplyResources(this.xLabel68, "xLabel68");
            this.xLabel68.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel68.Name = "xLabel68";
            // 
            // xLabel69
            // 
            this.xLabel69.AccessibleDescription = null;
            this.xLabel69.AccessibleName = null;
            resources.ApplyResources(this.xLabel69, "xLabel69");
            this.xLabel69.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel69.Image = null;
            this.xLabel69.Name = "xLabel69";
            // 
            // xLabel70
            // 
            this.xLabel70.AccessibleDescription = null;
            this.xLabel70.AccessibleName = null;
            resources.ApplyResources(this.xLabel70, "xLabel70");
            this.xLabel70.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel70.Image = null;
            this.xLabel70.Name = "xLabel70";
            // 
            // xLabel71
            // 
            this.xLabel71.AccessibleDescription = null;
            this.xLabel71.AccessibleName = null;
            resources.ApplyResources(this.xLabel71, "xLabel71");
            this.xLabel71.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel71.EdgeRounding = false;
            this.xLabel71.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel71.Image = null;
            this.xLabel71.Name = "xLabel71";
            // 
            // xLabel72
            // 
            this.xLabel72.AccessibleDescription = null;
            this.xLabel72.AccessibleName = null;
            resources.ApplyResources(this.xLabel72, "xLabel72");
            this.xLabel72.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel72.EdgeRounding = false;
            this.xLabel72.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel72.Image = null;
            this.xLabel72.Name = "xLabel72";
            // 
            // xLabel73
            // 
            this.xLabel73.AccessibleDescription = null;
            this.xLabel73.AccessibleName = null;
            resources.ApplyResources(this.xLabel73, "xLabel73");
            this.xLabel73.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel73.EdgeRounding = false;
            this.xLabel73.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel73.Image = null;
            this.xLabel73.Name = "xLabel73";
            // 
            // xLabel74
            // 
            this.xLabel74.AccessibleDescription = null;
            this.xLabel74.AccessibleName = null;
            resources.ApplyResources(this.xLabel74, "xLabel74");
            this.xLabel74.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel74.EdgeRounding = false;
            this.xLabel74.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel74.Image = null;
            this.xLabel74.Name = "xLabel74";
            // 
            // xLabel75
            // 
            this.xLabel75.AccessibleDescription = null;
            this.xLabel75.AccessibleName = null;
            resources.ApplyResources(this.xLabel75, "xLabel75");
            this.xLabel75.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel75.EdgeRounding = false;
            this.xLabel75.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel75.Image = null;
            this.xLabel75.Name = "xLabel75";
            // 
            // xLabel76
            // 
            this.xLabel76.AccessibleDescription = null;
            this.xLabel76.AccessibleName = null;
            resources.ApplyResources(this.xLabel76, "xLabel76");
            this.xLabel76.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel76.EdgeRounding = false;
            this.xLabel76.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel76.Image = null;
            this.xLabel76.Name = "xLabel76";
            // 
            // xLabel83
            // 
            this.xLabel83.AccessibleDescription = null;
            this.xLabel83.AccessibleName = null;
            resources.ApplyResources(this.xLabel83, "xLabel83");
            this.xLabel83.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel83.EdgeRounding = false;
            this.xLabel83.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.xLabel83.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel83.Image = null;
            this.xLabel83.Name = "xLabel83";
            // 
            // xLabel84
            // 
            this.xLabel84.AccessibleDescription = null;
            this.xLabel84.AccessibleName = null;
            resources.ApplyResources(this.xLabel84, "xLabel84");
            this.xLabel84.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel84.Name = "xLabel84";
            // 
            // xLabel85
            // 
            this.xLabel85.AccessibleDescription = null;
            this.xLabel85.AccessibleName = null;
            resources.ApplyResources(this.xLabel85, "xLabel85");
            this.xLabel85.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel85.Name = "xLabel85";
            // 
            // xLabel86
            // 
            this.xLabel86.AccessibleDescription = null;
            this.xLabel86.AccessibleName = null;
            resources.ApplyResources(this.xLabel86, "xLabel86");
            this.xLabel86.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel86.Image = null;
            this.xLabel86.Name = "xLabel86";
            // 
            // emkRes_pm_end_hhmm7
            // 
            this.emkRes_pm_end_hhmm7.AccessibleDescription = null;
            this.emkRes_pm_end_hhmm7.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_end_hhmm7, "emkRes_pm_end_hhmm7");
            this.emkRes_pm_end_hhmm7.BackgroundImage = null;
            this.emkRes_pm_end_hhmm7.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm7.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm7.IsVietnameseYearType = false;
            this.emkRes_pm_end_hhmm7.Mask = "HH:MI";
            this.emkRes_pm_end_hhmm7.Name = "emkRes_pm_end_hhmm7";
            this.emkRes_pm_end_hhmm7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_pm_start_hhmm7
            // 
            this.emkRes_pm_start_hhmm7.AccessibleDescription = null;
            this.emkRes_pm_start_hhmm7.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_start_hhmm7, "emkRes_pm_start_hhmm7");
            this.emkRes_pm_start_hhmm7.BackgroundImage = null;
            this.emkRes_pm_start_hhmm7.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm7.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm7.IsVietnameseYearType = false;
            this.emkRes_pm_start_hhmm7.Mask = "HH:MI";
            this.emkRes_pm_start_hhmm7.Name = "emkRes_pm_start_hhmm7";
            this.emkRes_pm_start_hhmm7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel87
            // 
            this.xLabel87.AccessibleDescription = null;
            this.xLabel87.AccessibleName = null;
            resources.ApplyResources(this.xLabel87, "xLabel87");
            this.xLabel87.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel87.Name = "xLabel87";
            // 
            // emkRes_am_end_hhmm7
            // 
            this.emkRes_am_end_hhmm7.AccessibleDescription = null;
            this.emkRes_am_end_hhmm7.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_end_hhmm7, "emkRes_am_end_hhmm7");
            this.emkRes_am_end_hhmm7.BackgroundImage = null;
            this.emkRes_am_end_hhmm7.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm7.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm7.IsVietnameseYearType = false;
            this.emkRes_am_end_hhmm7.Mask = "HH:MI";
            this.emkRes_am_end_hhmm7.Name = "emkRes_am_end_hhmm7";
            this.emkRes_am_end_hhmm7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_am_start_hhmm7
            // 
            this.emkRes_am_start_hhmm7.AccessibleDescription = null;
            this.emkRes_am_start_hhmm7.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_start_hhmm7, "emkRes_am_start_hhmm7");
            this.emkRes_am_start_hhmm7.BackgroundImage = null;
            this.emkRes_am_start_hhmm7.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm7.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm7.IsVietnameseYearType = false;
            this.emkRes_am_start_hhmm7.Mask = "HH:MI";
            this.emkRes_am_start_hhmm7.Name = "emkRes_am_start_hhmm7";
            this.emkRes_am_start_hhmm7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel88
            // 
            this.xLabel88.AccessibleDescription = null;
            this.xLabel88.AccessibleName = null;
            resources.ApplyResources(this.xLabel88, "xLabel88");
            this.xLabel88.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel88.Name = "xLabel88";
            // 
            // xLabel89
            // 
            this.xLabel89.AccessibleDescription = null;
            this.xLabel89.AccessibleName = null;
            resources.ApplyResources(this.xLabel89, "xLabel89");
            this.xLabel89.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel89.Image = null;
            this.xLabel89.Name = "xLabel89";
            // 
            // xLabel90
            // 
            this.xLabel90.AccessibleDescription = null;
            this.xLabel90.AccessibleName = null;
            resources.ApplyResources(this.xLabel90, "xLabel90");
            this.xLabel90.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel90.Image = null;
            this.xLabel90.Name = "xLabel90";
            // 
            // emkRes_pm_end_hhmm6
            // 
            this.emkRes_pm_end_hhmm6.AccessibleDescription = null;
            this.emkRes_pm_end_hhmm6.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_end_hhmm6, "emkRes_pm_end_hhmm6");
            this.emkRes_pm_end_hhmm6.BackgroundImage = null;
            this.emkRes_pm_end_hhmm6.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm6.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm6.IsVietnameseYearType = false;
            this.emkRes_pm_end_hhmm6.Mask = "HH:MI";
            this.emkRes_pm_end_hhmm6.Name = "emkRes_pm_end_hhmm6";
            this.emkRes_pm_end_hhmm6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_pm_start_hhmm6
            // 
            this.emkRes_pm_start_hhmm6.AccessibleDescription = null;
            this.emkRes_pm_start_hhmm6.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_start_hhmm6, "emkRes_pm_start_hhmm6");
            this.emkRes_pm_start_hhmm6.BackgroundImage = null;
            this.emkRes_pm_start_hhmm6.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm6.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm6.IsVietnameseYearType = false;
            this.emkRes_pm_start_hhmm6.Mask = "HH:MI";
            this.emkRes_pm_start_hhmm6.Name = "emkRes_pm_start_hhmm6";
            this.emkRes_pm_start_hhmm6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel91
            // 
            this.xLabel91.AccessibleDescription = null;
            this.xLabel91.AccessibleName = null;
            resources.ApplyResources(this.xLabel91, "xLabel91");
            this.xLabel91.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel91.Name = "xLabel91";
            // 
            // emkRes_am_end_hhmm6
            // 
            this.emkRes_am_end_hhmm6.AccessibleDescription = null;
            this.emkRes_am_end_hhmm6.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_end_hhmm6, "emkRes_am_end_hhmm6");
            this.emkRes_am_end_hhmm6.BackgroundImage = null;
            this.emkRes_am_end_hhmm6.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm6.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm6.IsVietnameseYearType = false;
            this.emkRes_am_end_hhmm6.Mask = "HH:MI";
            this.emkRes_am_end_hhmm6.Name = "emkRes_am_end_hhmm6";
            this.emkRes_am_end_hhmm6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_am_start_hhmm6
            // 
            this.emkRes_am_start_hhmm6.AccessibleDescription = null;
            this.emkRes_am_start_hhmm6.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_start_hhmm6, "emkRes_am_start_hhmm6");
            this.emkRes_am_start_hhmm6.BackgroundImage = null;
            this.emkRes_am_start_hhmm6.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm6.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm6.IsVietnameseYearType = false;
            this.emkRes_am_start_hhmm6.Mask = "HH:MI";
            this.emkRes_am_start_hhmm6.Name = "emkRes_am_start_hhmm6";
            this.emkRes_am_start_hhmm6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel92
            // 
            this.xLabel92.AccessibleDescription = null;
            this.xLabel92.AccessibleName = null;
            resources.ApplyResources(this.xLabel92, "xLabel92");
            this.xLabel92.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel92.Name = "xLabel92";
            // 
            // xLabel93
            // 
            this.xLabel93.AccessibleDescription = null;
            this.xLabel93.AccessibleName = null;
            resources.ApplyResources(this.xLabel93, "xLabel93");
            this.xLabel93.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel93.Image = null;
            this.xLabel93.Name = "xLabel93";
            // 
            // xLabel94
            // 
            this.xLabel94.AccessibleDescription = null;
            this.xLabel94.AccessibleName = null;
            resources.ApplyResources(this.xLabel94, "xLabel94");
            this.xLabel94.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel94.Image = null;
            this.xLabel94.Name = "xLabel94";
            // 
            // emkRes_pm_end_hhmm5
            // 
            this.emkRes_pm_end_hhmm5.AccessibleDescription = null;
            this.emkRes_pm_end_hhmm5.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_end_hhmm5, "emkRes_pm_end_hhmm5");
            this.emkRes_pm_end_hhmm5.BackgroundImage = null;
            this.emkRes_pm_end_hhmm5.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm5.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm5.IsVietnameseYearType = false;
            this.emkRes_pm_end_hhmm5.Mask = "HH:MI";
            this.emkRes_pm_end_hhmm5.Name = "emkRes_pm_end_hhmm5";
            this.emkRes_pm_end_hhmm5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_pm_start_hhmm5
            // 
            this.emkRes_pm_start_hhmm5.AccessibleDescription = null;
            this.emkRes_pm_start_hhmm5.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_start_hhmm5, "emkRes_pm_start_hhmm5");
            this.emkRes_pm_start_hhmm5.BackgroundImage = null;
            this.emkRes_pm_start_hhmm5.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm5.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_start_hhmm5.IsVietnameseYearType = false;
            this.emkRes_pm_start_hhmm5.Mask = "HH:MI";
            this.emkRes_pm_start_hhmm5.Name = "emkRes_pm_start_hhmm5";
            this.emkRes_pm_start_hhmm5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel95
            // 
            this.xLabel95.AccessibleDescription = null;
            this.xLabel95.AccessibleName = null;
            resources.ApplyResources(this.xLabel95, "xLabel95");
            this.xLabel95.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel95.Name = "xLabel95";
            // 
            // emkRes_am_end_hhmm5
            // 
            this.emkRes_am_end_hhmm5.AccessibleDescription = null;
            this.emkRes_am_end_hhmm5.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_end_hhmm5, "emkRes_am_end_hhmm5");
            this.emkRes_am_end_hhmm5.BackgroundImage = null;
            this.emkRes_am_end_hhmm5.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm5.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm5.IsVietnameseYearType = false;
            this.emkRes_am_end_hhmm5.Mask = "HH:MI";
            this.emkRes_am_end_hhmm5.Name = "emkRes_am_end_hhmm5";
            this.emkRes_am_end_hhmm5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_am_start_hhmm5
            // 
            this.emkRes_am_start_hhmm5.AccessibleDescription = null;
            this.emkRes_am_start_hhmm5.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_start_hhmm5, "emkRes_am_start_hhmm5");
            this.emkRes_am_start_hhmm5.BackgroundImage = null;
            this.emkRes_am_start_hhmm5.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm5.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm5.IsVietnameseYearType = false;
            this.emkRes_am_start_hhmm5.Mask = "HH:MI";
            this.emkRes_am_start_hhmm5.Name = "emkRes_am_start_hhmm5";
            this.emkRes_am_start_hhmm5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel96
            // 
            this.xLabel96.AccessibleDescription = null;
            this.xLabel96.AccessibleName = null;
            resources.ApplyResources(this.xLabel96, "xLabel96");
            this.xLabel96.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel96.Name = "xLabel96";
            // 
            // xLabel97
            // 
            this.xLabel97.AccessibleDescription = null;
            this.xLabel97.AccessibleName = null;
            resources.ApplyResources(this.xLabel97, "xLabel97");
            this.xLabel97.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel97.Image = null;
            this.xLabel97.Name = "xLabel97";
            // 
            // xLabel98
            // 
            this.xLabel98.AccessibleDescription = null;
            this.xLabel98.AccessibleName = null;
            resources.ApplyResources(this.xLabel98, "xLabel98");
            this.xLabel98.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel98.Image = null;
            this.xLabel98.Name = "xLabel98";
            // 
            // emkRes_pm_end_hhmm4
            // 
            this.emkRes_pm_end_hhmm4.AccessibleDescription = null;
            this.emkRes_pm_end_hhmm4.AccessibleName = null;
            resources.ApplyResources(this.emkRes_pm_end_hhmm4, "emkRes_pm_end_hhmm4");
            this.emkRes_pm_end_hhmm4.BackgroundImage = null;
            this.emkRes_pm_end_hhmm4.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm4.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_pm_end_hhmm4.IsVietnameseYearType = false;
            this.emkRes_pm_end_hhmm4.Mask = "HH:MI";
            this.emkRes_pm_end_hhmm4.Name = "emkRes_pm_end_hhmm4";
            this.emkRes_pm_end_hhmm4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel99
            // 
            this.xLabel99.AccessibleDescription = null;
            this.xLabel99.AccessibleName = null;
            resources.ApplyResources(this.xLabel99, "xLabel99");
            this.xLabel99.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel99.Name = "xLabel99";
            // 
            // emkRes_am_end_hhmm4
            // 
            this.emkRes_am_end_hhmm4.AccessibleDescription = null;
            this.emkRes_am_end_hhmm4.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_end_hhmm4, "emkRes_am_end_hhmm4");
            this.emkRes_am_end_hhmm4.BackgroundImage = null;
            this.emkRes_am_end_hhmm4.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm4.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_end_hhmm4.IsVietnameseYearType = false;
            this.emkRes_am_end_hhmm4.Mask = "HH:MI";
            this.emkRes_am_end_hhmm4.Name = "emkRes_am_end_hhmm4";
            this.emkRes_am_end_hhmm4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // emkRes_am_start_hhmm4
            // 
            this.emkRes_am_start_hhmm4.AccessibleDescription = null;
            this.emkRes_am_start_hhmm4.AccessibleName = null;
            resources.ApplyResources(this.emkRes_am_start_hhmm4, "emkRes_am_start_hhmm4");
            this.emkRes_am_start_hhmm4.BackgroundImage = null;
            this.emkRes_am_start_hhmm4.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm4.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkRes_am_start_hhmm4.IsVietnameseYearType = false;
            this.emkRes_am_start_hhmm4.Mask = "HH:MI";
            this.emkRes_am_start_hhmm4.Name = "emkRes_am_start_hhmm4";
            this.emkRes_am_start_hhmm4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkTime_DataValidating);
            // 
            // xLabel100
            // 
            this.xLabel100.AccessibleDescription = null;
            this.xLabel100.AccessibleName = null;
            resources.ApplyResources(this.xLabel100, "xLabel100");
            this.xLabel100.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel100.Name = "xLabel100";
            // 
            // xLabel101
            // 
            this.xLabel101.AccessibleDescription = null;
            this.xLabel101.AccessibleName = null;
            resources.ApplyResources(this.xLabel101, "xLabel101");
            this.xLabel101.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel101.Image = null;
            this.xLabel101.Name = "xLabel101";
            // 
            // xLabel102
            // 
            this.xLabel102.AccessibleDescription = null;
            this.xLabel102.AccessibleName = null;
            resources.ApplyResources(this.xLabel102, "xLabel102");
            this.xLabel102.EdgeRounding = false;
            this.xLabel102.Image = null;
            this.xLabel102.Name = "xLabel102";
            // 
            // xLabel103
            // 
            this.xLabel103.AccessibleDescription = null;
            this.xLabel103.AccessibleName = null;
            resources.ApplyResources(this.xLabel103, "xLabel103");
            this.xLabel103.EdgeRounding = false;
            this.xLabel103.Image = null;
            this.xLabel103.Name = "xLabel103";
            // 
            // xLabel104
            // 
            this.xLabel104.AccessibleDescription = null;
            this.xLabel104.AccessibleName = null;
            resources.ApplyResources(this.xLabel104, "xLabel104");
            this.xLabel104.EdgeRounding = false;
            this.xLabel104.Image = null;
            this.xLabel104.Name = "xLabel104";
            // 
            // xLabel105
            // 
            this.xLabel105.AccessibleDescription = null;
            this.xLabel105.AccessibleName = null;
            resources.ApplyResources(this.xLabel105, "xLabel105");
            this.xLabel105.EdgeRounding = false;
            this.xLabel105.Image = null;
            this.xLabel105.Name = "xLabel105";
            // 
            // xLabel106
            // 
            this.xLabel106.AccessibleDescription = null;
            this.xLabel106.AccessibleName = null;
            resources.ApplyResources(this.xLabel106, "xLabel106");
            this.xLabel106.EdgeRounding = false;
            this.xLabel106.Image = null;
            this.xLabel106.Name = "xLabel106";
            // 
            // xLabel107
            // 
            this.xLabel107.AccessibleDescription = null;
            this.xLabel107.AccessibleName = null;
            resources.ApplyResources(this.xLabel107, "xLabel107");
            this.xLabel107.EdgeRounding = false;
            this.xLabel107.Image = null;
            this.xLabel107.Name = "xLabel107";
            // 
            // xLabel108
            // 
            this.xLabel108.AccessibleDescription = null;
            this.xLabel108.AccessibleName = null;
            resources.ApplyResources(this.xLabel108, "xLabel108");
            this.xLabel108.EdgeRounding = false;
            this.xLabel108.Image = null;
            this.xLabel108.Name = "xLabel108";
            // 
            // pnlList
            // 
            this.pnlList.AccessibleDescription = null;
            this.pnlList.AccessibleName = null;
            resources.ApplyResources(this.pnlList, "pnlList");
            this.pnlList.BackgroundImage = null;
            this.pnlList.Controls.Add(this.grdRES0102);
            this.pnlList.Font = null;
            this.pnlList.Name = "pnlList";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.dpkApp_date);
            this.xPanel2.Controls.Add(this.dbxDoctor_name);
            this.xPanel2.Controls.Add(this.cboGwa);
            this.xPanel2.Controls.Add(this.xLabel59);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.xLabel6);
            this.xPanel2.Controls.Add(this.fbxDoctor);
            this.xPanel2.Controls.Add(this.cboDoctor);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // dpkApp_date
            // 
            this.dpkApp_date.AccessibleDescription = null;
            this.dpkApp_date.AccessibleName = null;
            resources.ApplyResources(this.dpkApp_date, "dpkApp_date");
            this.dpkApp_date.BackgroundImage = null;
            this.dpkApp_date.IsVietnameseYearType = false;
            this.dpkApp_date.Name = "dpkApp_date";
            this.dpkApp_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkApp_date_DataValidating);
            // 
            // dbxDoctor_name
            // 
            this.dbxDoctor_name.AccessibleDescription = null;
            this.dbxDoctor_name.AccessibleName = null;
            resources.ApplyResources(this.dbxDoctor_name, "dbxDoctor_name");
            this.dbxDoctor_name.EdgeRounding = false;
            this.dbxDoctor_name.Image = null;
            this.dbxDoctor_name.Name = "dbxDoctor_name";
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // xLabel59
            // 
            this.xLabel59.AccessibleDescription = null;
            this.xLabel59.AccessibleName = null;
            resources.ApplyResources(this.xLabel59, "xLabel59");
            this.xLabel59.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel59.EdgeRounding = false;
            this.xLabel59.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel59.Image = null;
            this.xLabel59.Name = "xLabel59";
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
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.AccessibleDescription = null;
            this.fbxDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxDoctor, "fbxDoctor");
            this.fbxDoctor.BackgroundImage = null;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDoctor_FindClick);
            // 
            // cboDoctor
            // 
            this.cboDoctor.AccessibleDescription = null;
            this.cboDoctor.AccessibleName = null;
            resources.ApplyResources(this.cboDoctor, "cboDoctor");
            this.cboDoctor.BackgroundImage = null;
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_SelectedIndexChanged);
            // 
            // panAddedSchedule
            // 
            this.panAddedSchedule.AccessibleDescription = null;
            this.panAddedSchedule.AccessibleName = null;
            resources.ApplyResources(this.panAddedSchedule, "panAddedSchedule");
            this.panAddedSchedule.BackgroundImage = null;
            this.panAddedSchedule.Controls.Add(this.pnl);
            this.panAddedSchedule.Controls.Add(this.xLabel1);
            this.panAddedSchedule.Font = null;
            this.panAddedSchedule.Name = "panAddedSchedule";
            // 
            // pnl
            // 
            this.pnl.AccessibleDescription = null;
            this.pnl.AccessibleName = null;
            resources.ApplyResources(this.pnl, "pnl");
            this.pnl.BackgroundImage = null;
            this.pnl.Controls.Add(this.grdRES0103);
            this.pnl.Controls.Add(this.grdRES0103R);
            this.pnl.Font = null;
            this.pnl.Name = "pnl";
            // 
            // grdRES0103
            // 
            this.grdRES0103.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdRES0103, "grdRES0103");
            this.grdRES0103.CallerID = '2';
            this.grdRES0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell56});
            this.grdRES0103.ColPerLine = 5;
            this.grdRES0103.Cols = 6;
            this.grdRES0103.ExecuteQuery = null;
            this.grdRES0103.FixedCols = 1;
            this.grdRES0103.FixedRows = 2;
            this.grdRES0103.FocusColumnName = "jinryo_pre_date";
            this.grdRES0103.HeaderHeights.Add(21);
            this.grdRES0103.HeaderHeights.Add(0);
            this.grdRES0103.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdRES0103.Name = "grdRES0103";
            this.grdRES0103.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRES0103.ParamList")));
            this.grdRES0103.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdRES0103.RowHeaderVisible = true;
            this.grdRES0103.Rows = 3;
            this.grdRES0103.ToolTipActive = true;
            this.grdRES0103.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdRES0103.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdRES0103_GridColumnChanged);
            this.grdRES0103.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRES0103_QueryStarting);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "doctor";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsNotNull = true;
            this.xEditGridCell44.IsUpdatable = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jinryo_pre_date";
            this.xEditGridCell45.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell45.CellWidth = 115;
            this.xEditGridCell45.Col = 1;
            this.xEditGridCell45.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsNotNull = true;
            this.xEditGridCell45.IsUpdatable = false;
            this.xEditGridCell45.RowSpan = 2;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "am_start_hhmm";
            this.xEditGridCell46.Col = 2;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.Mask = "##:##";
            this.xEditGridCell46.Row = 1;
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "am_end_hhmm";
            this.xEditGridCell47.Col = 3;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.Mask = "##:##";
            this.xEditGridCell47.Row = 1;
            this.xEditGridCell47.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "pm_start_hhmm";
            this.xEditGridCell48.Col = 4;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.Mask = "##:##";
            this.xEditGridCell48.Row = 1;
            this.xEditGridCell48.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "pm_end_hhmm";
            this.xEditGridCell49.Col = 5;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.Mask = "##:##";
            this.xEditGridCell49.Row = 1;
            this.xEditGridCell49.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "remark";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "am_gwa_room";
            this.xEditGridCell51.CellWidth = 30;
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "pm_gwa_room";
            this.xEditGridCell56.CellWidth = 30;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 2;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 4;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            // 
            // grdRES0103R
            // 
            this.grdRES0103R.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdRES0103R, "grdRES0103R");
            this.grdRES0103R.CallerID = '3';
            this.grdRES0103R.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell99});
            this.grdRES0103R.ColPerLine = 5;
            this.grdRES0103R.Cols = 6;
            this.grdRES0103R.ExecuteQuery = null;
            this.grdRES0103R.FixedCols = 1;
            this.grdRES0103R.FixedRows = 2;
            this.grdRES0103R.FocusColumnName = "jinryo_pre_date";
            this.grdRES0103R.HeaderHeights.Add(21);
            this.grdRES0103R.HeaderHeights.Add(0);
            this.grdRES0103R.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader3,
            this.xGridHeader4});
            this.grdRES0103R.Name = "grdRES0103R";
            this.grdRES0103R.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRES0103R.ParamList")));
            this.grdRES0103R.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdRES0103R.RowHeaderVisible = true;
            this.grdRES0103R.Rows = 3;
            this.grdRES0103R.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdRES0103R.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdRES0103R_GridColumnChanged);
            this.grdRES0103R.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRES0103R_QueryStarting);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jinryo_pre_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 115;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "res_am_start_hhmm";
            this.xEditGridCell95.Col = 2;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.Mask = "##:##";
            this.xEditGridCell95.Row = 1;
            this.xEditGridCell95.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "res_am_end_hhmm";
            this.xEditGridCell96.Col = 3;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.Mask = "##:##";
            this.xEditGridCell96.Row = 1;
            this.xEditGridCell96.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "res_pm_start_hhmm";
            this.xEditGridCell97.Col = 4;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.Mask = "##:##";
            this.xEditGridCell97.Row = 1;
            this.xEditGridCell97.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "res_pm_end_hhmm";
            this.xEditGridCell98.Col = 5;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.Mask = "##:##";
            this.xEditGridCell98.Row = 1;
            this.xEditGridCell98.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "remark";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 2;
            this.xGridHeader3.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            // 
            // xGridHeader4
            // 
            this.xGridHeader4.Col = 4;
            this.xGridHeader4.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader4, "xGridHeader4");
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel1.ImageList = this.ImageList;
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.grdRES0104);
            this.xPanel4.Controls.Add(this.xLabel2);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // grdRES0104
            // 
            resources.ApplyResources(this.grdRES0104, "grdRES0104");
            this.grdRES0104.CallerID = '4';
            this.grdRES0104.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55});
            this.grdRES0104.ColPerLine = 3;
            this.grdRES0104.Cols = 4;
            this.grdRES0104.ExecuteQuery = null;
            this.grdRES0104.FixedCols = 1;
            this.grdRES0104.FixedRows = 1;
            this.grdRES0104.FocusColumnName = "from_date";
            this.grdRES0104.HeaderHeights.Add(21);
            this.grdRES0104.Name = "grdRES0104";
            this.grdRES0104.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRES0104.ParamList")));
            this.grdRES0104.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdRES0104.RowHeaderVisible = true;
            this.grdRES0104.Rows = 2;
            this.grdRES0104.ToolTipActive = true;
            this.grdRES0104.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grd_PreSaveLayout);
            this.grdRES0104.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdRES0104_GridColumnChanged);
            this.grdRES0104.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRES0104_QueryStarting);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "doctor";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsNotNull = true;
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "start_date";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell53.CellWidth = 106;
            this.xEditGridCell53.Col = 1;
            this.xEditGridCell53.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsNotNull = true;
            this.xEditGridCell53.IsUpdatable = false;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "end_date";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell54.CellWidth = 110;
            this.xEditGridCell54.Col = 2;
            this.xEditGridCell54.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellLen = 200;
            this.xEditGridCell55.CellName = "sayu";
            this.xEditGridCell55.CellWidth = 260;
            this.xEditGridCell55.Col = 3;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel2.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel2.ImageList = this.ImageList;
            this.xLabel2.Name = "xLabel2";
            // 
            // layoutCboGwa
            // 
            this.layoutCboGwa.ExecuteQuery = null;
            this.layoutCboGwa.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layoutCboGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layoutCboGwa.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gwa";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "gwa_name";
            // 
            // layChkHyujin
            // 
            this.layChkHyujin.ExecuteQuery = null;
            this.layChkHyujin.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layChkHyujin.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layChkHyujin.ParamList")));
            this.layChkHyujin.QuerySQL = resources.GetString("layChkHyujin.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "check";
            // 
            // layCboDoctor
            // 
            this.layCboDoctor.ExecuteQuery = null;
            this.layCboDoctor.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layCboDoctor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCboDoctor.ParamList")));
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "doctor";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "doctor_name";
            // 
            // layCboGwaRoom
            // 
            this.layCboGwaRoom.ExecuteQuery = null;
            this.layCboGwaRoom.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layCboGwaRoom.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCboGwaRoom.ParamList")));
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "gwa_room";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "gwa_room_name";
            // 
            // RES0102U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.panAddedSchedule);
            this.Controls.Add(this.pnlWeekSchedule);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "RES0102U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.RES0102U00_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.RES1001U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRES0102)).EndInit();
            this.pnlWeekSchedule.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlJinryo.ResumeLayout(false);
            this.pnlJinryo.PerformLayout();
            this.pnlReser.ResumeLayout(false);
            this.pnlReser.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.panAddedSchedule.ResumeLayout(false);
            this.pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRES0103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRES0103R)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRES0104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCboGwa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCboDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCboGwaRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region [Screen Event]

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //tungtx
            mHospCode = UserInfo.HospCode;
            if (String.IsNullOrEmpty(mHospCode))
            {
                mHospCode = EnvironInfo.HospCode;
            }

            if (UserInfo.AdminType == AdminType.SuperAdmin)
            //if (true)
            {
                xHospBox1.Visible = true;
                pnlMain.Enabled = false;
                xButtonList1.SetEnabled(FunctionType.Insert, false);
                xButtonList1.SetEnabled(FunctionType.Delete, false);
                xButtonList1.SetEnabled(FunctionType.Update, false);
            }
            else
            {
                xHospBox1.Visible = false;
            }
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void RES1001U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // Call된 경우
            if (OpenParam != null)
            {
            }
        }

        private void PostLoad()
        {

            //default value
            dpkApp_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            CreateCombo();

            SetBinding();

            ClearALL();

            // 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            RES0102U00_UserChanged(this, new EventArgs());
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void RES0102U00_UserChanged(object sender, EventArgs e)
        {
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                mDoctor = UserInfo.DoctorID;
                mGwa = UserInfo.Gwa;

                cboGwa.SetEditValue(mGwa);
                cboDoctor.SetEditValue(mDoctor);

                fbxDoctor.SetEditValue(cboDoctor.GetDataValue().ToString());
                fbxDoctor.AcceptData();

                dbxDoctor_name.SetEditValue(cboDoctor.Text.ToString());
                dbxDoctor_name.AcceptData();
            }
        }

        #endregion

        #region [Control]

        /// <summary>
        /// Control Binding
        /// </summary>
        private void SetBinding()
        {
            htControl = new Hashtable();
            string colName = "";

            foreach (object obj in pnlWeekSchedule.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        if (grdRES0102.CellInfos.Contains(colName))
                            grdRES0102.SetBindControl(colName, ((XComboBox)obj));
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        if (grdRES0102.CellInfos.Contains(colName))
                            grdRES0102.SetBindControl(colName, ((XEditMask)obj));
                        ((XEditMask)obj).DataValidating += new DataValidatingEventHandler(Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }
            }

            foreach (object obj in pnlJinryo.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        if (grdRES0102.CellInfos.Contains(colName))
                            grdRES0102.SetBindControl(colName, ((XComboBox)obj));
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        if (grdRES0102.CellInfos.Contains(colName))
                            grdRES0102.SetBindControl(colName, ((XEditMask)obj));
                        ((XEditMask)obj).DataValidating += new DataValidatingEventHandler(Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }
            }

            foreach (object obj in pnlReser.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        if (grdRES0102.CellInfos.Contains(colName))
                            grdRES0102.SetBindControl(colName, ((XComboBox)obj));
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        if (grdRES0102.CellInfos.Contains(colName))
                            grdRES0102.SetBindControl(colName, ((XEditMask)obj));
                        ((XEditMask)obj).DataValidating += new DataValidatingEventHandler(Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }
            }
            foreach (object obj in pnlMain.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        if (grdRES0102.CellInfos.Contains(colName))
                            grdRES0102.SetBindControl(colName, ((XComboBox)obj));
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        if (grdRES0102.CellInfos.Contains(colName))
                            grdRES0102.SetBindControl(colName, ((XEditMask)obj));
                        ((XEditMask)obj).DataValidating += new DataValidatingEventHandler(Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }
            }

            //GRID Column Binding Initialize
            grdRES0102.InitializeColumns();
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

            return colName;
        }

        /// <summary>
        /// 항목에 보이는 값들을 Clear한다.
        /// </summary>
        private void ClearControl()
        {
            if (!TypeCheck.IsNull(htControl))
            {
                foreach (object key in htControl.Keys)
                {
                    ((IDataControl)htControl[key]).DataValue = "";
                }
            }
        }

        private void ClearALL()
        {
            grdRES0102.Reset();
            ClearControl();
            grdRES0103.Reset();
            grdRES0104.Reset();
            pnlWeekSchedule.Enabled = false;
        }

        #endregion

        #region [Control DataValidating]

        private void Control_DataValidating(object sender, DataValidatingEventArgs e)
        {
            e.Cancel = false;

            string colName = GetColumnName(sender);

            if (colName == "avg_time")
            {
                if (e.DataValue == "")
                {
                    mbxMsg = Resource.MSG001_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    ((XEditMask)sender).SetDataValue("0");
                    e.Cancel = true;
                }

                return;
            }

            if (colName == "doc_res_limit" || colName == "etc_res_limit" || colName == "out_hosp_res_limit") return;

            if (e.DataValue == "") return;

            if (!TypeCheck.IsDateTime("2006/04/01 " + ((XEditMask)sender).Text))
            {
                mbxMsg = Resource.MSG002_MSG;
                mbxCap = "";
                XMessageBox.Show(mbxMsg, mbxCap);
                ((XEditMask)sender).SetDataValue("");
                e.Cancel = true;
                return;
            }
        }

        #endregion

        #region [Combo 생성]

        private void CreateCombo()
        {
            MultiLayout multiLayout = new MultiLayout();
            multiLayout.ExecuteQuery = CboGwaExecuteQuery;
            multiLayout.LayoutItems.Add("gwa", DataType.String);
            multiLayout.LayoutItems.Add("gwa_name", DataType.String);
            multiLayout.InitializeLayoutTable();

            if (multiLayout.QueryLayout(true) && multiLayout.RowCount > 0)
            {
                cboGwa.SetComboItems(multiLayout.LayoutTable, "gwa_name", "gwa");
                cboGwa.SelectedIndex = 0;
            }

            cboAvg_time.ExecuteQuery = CboAvgTimeExecuteQuery;
            cboAvg_time.SetDictDDLB();
            cboAvg_time.SelectedIndex = 0;
        }

        private IList<object[]> CboGwaExecuteQuery(BindVarCollection varList)
        {
            IList<object[]> dataList = new List<object[]>();
            initializeComboListItem();
            if (cboListItemResult != null)
            {
                dataList = createListDataForCombo(cboListItemResult.GwaItem);
            }
            return dataList;
        }

        private void CreateDoctorCombo(string aGwa)
        {
            layCboDoctor.Reset();
            layCboDoctor.ParamList = new List<string>(new string[] { "f_gwa", "f_app_date" });
            layCboDoctor.ExecuteQuery = DoctorQueryCombo;
            layCboDoctor.SetBindVarValue("f_hosp_code", mHospCode);
            layCboDoctor.SetBindVarValue("f_gwa", aGwa);
            layCboDoctor.SetBindVarValue("f_app_date", dpkApp_date.GetDataValue());

            if (layCboDoctor.QueryLayout(true) && layCboDoctor.RowCount > 0)
            {
                cboDoctor.SetComboItems(layCboDoctor.LayoutTable, "doctor_name", "doctor", XComboSetType.AppendNone);
                if (layCboDoctor.RowCount > 0)
                {
                    cboDoctor.SelectedIndex = 0;
                    fbxDoctor.SetEditValue(cboDoctor.GetDataValue().ToString());
                    fbxDoctor.AcceptData();

                    dbxDoctor_name.SetEditValue(cboDoctor.Text.ToString());
                    dbxDoctor_name.AcceptData();
                }
            }
        }

        private IList<object[]> DoctorQueryCombo(BindVarCollection varList)
        {
            List<object[]> dataList = new List<object[]>();
            String appDate = varList["f_app_date"].VarValue;
            String gwa = varList["f_gwa"].VarValue;
            //if (String.IsNullOrEmpty(appDate) || String.IsNullOrEmpty(gwa) || "%".Equals(gwa))
            //{
            //    return dataList;
            //}
            NuroRES0102U00CboDoctorArgs args = new NuroRES0102U00CboDoctorArgs();
            args.AppDate = appDate;
            args.Gwa = gwa;
            args.HospCode = mHospCode;
            NuroRES0102U00CboDoctorResult result =
                CloudService.Instance.Submit<NuroRES0102U00CboDoctorResult, NuroRES0102U00CboDoctorArgs>(args);
            if (result != null && result.CboItemList.Count > 0)
            {
                IList<ComboListItemInfo> listItemInfos = result.CboItemList;
                if (listItemInfos != null)
                {
                    foreach (ComboListItemInfo comboListItemInfo in listItemInfos)
                    {
                        dataList.Add(new object[]
                        {
                            comboListItemInfo.Code,
                            comboListItemInfo.CodeName
                        });
                    }
                }
            }
            return dataList;
        }


        private void CreateGwa_roomCombo(string aGwa)
        {
            layCboGwaRoom.Reset();
            layCboGwaRoom.ExecuteQuery = CboGwaRoomExecuteQuery;
            layCboGwaRoom.ParamList = new List<string>(new String[] { "f_hosp_code", "f_gwa", "f_date" });
            layCboGwaRoom.SetBindVarValue("f_hosp_code", mHospCode);
            layCboGwaRoom.SetBindVarValue("f_gwa", aGwa);

            if (dpkStart_date.GetDataValue() == "")
                layCboGwaRoom.SetBindVarValue("f_date", dpkApp_date.GetDataValue());
            else
                layCboGwaRoom.SetBindVarValue("f_date", dpkStart_date.GetDataValue());


            if (layCboGwaRoom.QueryLayout(true) && layoutCboGwa.RowCount > 0)
            {
                cboAm_gwa_room1.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboAm_gwa_room1.SelectedIndex = 0;
                cboAm_gwa_room2.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboAm_gwa_room2.SelectedIndex = 0;
                cboAm_gwa_room3.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboAm_gwa_room3.SelectedIndex = 0;
                cboAm_gwa_room4.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboAm_gwa_room4.SelectedIndex = 0;
                cboAm_gwa_room5.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboAm_gwa_room5.SelectedIndex = 0;
                cboAm_gwa_room6.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboAm_gwa_room6.SelectedIndex = 0;
                cboAm_gwa_room7.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboAm_gwa_room7.SelectedIndex = 0;
                cboPm_gwa_room1.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboPm_gwa_room1.SelectedIndex = 0;
                cboPm_gwa_room2.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboPm_gwa_room2.SelectedIndex = 0;
                cboPm_gwa_room3.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboPm_gwa_room3.SelectedIndex = 0;
                cboPm_gwa_room4.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboPm_gwa_room4.SelectedIndex = 0;
                cboPm_gwa_room5.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboPm_gwa_room5.SelectedIndex = 0;
                cboPm_gwa_room6.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboPm_gwa_room6.SelectedIndex = 0;
                cboPm_gwa_room7.SetComboItems(layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                cboPm_gwa_room7.SelectedIndex = 0;

                grdRES0103.SetComboItems("am_gwa_room", layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                grdRES0103.SetComboItems("pm_gwa_room", layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                grdRES0103R.SetComboItems("res_am_gwa_room", layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
                grdRES0103R.SetComboItems("res_pm_gwa_room", layCboGwaRoom.LayoutTable, "gwa_room_name", "gwa_room",
                    XComboSetType.AppendNone);
            }
        }

        private IList<object[]> CboGwaRoomExecuteQuery(BindVarCollection varList)
        {
            List<object[]> dataList = new List<object[]>();
            String date = varList["f_date"].VarValue;
            String gwa = varList["f_gwa"].VarValue;
            if (String.IsNullOrEmpty(gwa) || "%".Equals(gwa))
            {
                return dataList;
            }
            NuroRES0102U00CboGwaRoomArgs args = new NuroRES0102U00CboGwaRoomArgs();
            args.Date = date;
            args.Gwa = gwa;
            args.HospCode = mHospCode;
            NuroRES0102U00CboGwaRoomResult result =
                CloudService.Instance.Submit<NuroRES0102U00CboGwaRoomResult, NuroRES0102U00CboGwaRoomArgs>(args);

            if (result != null && result.CboItemList.Count > 0)
            {
                IList<ComboListItemInfo> listItemInfos = result.CboItemList;
                if (listItemInfos != null)
                {
                    foreach (ComboListItemInfo comboListItemInfo in listItemInfos)
                    {
                        dataList.Add(new object[]
                        {
                            comboListItemInfo.Code,
                            comboListItemInfo.CodeName
                        });
                    }
                    //                    cboGwa.SelectedIndex = 0;
                }
            }
            return dataList;
        }

        #endregion

        #region [ButtonList Event]

        private string mErrMsg = "";
        private bool mIsSaveSuccess = true;

        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;                    
                    // Connect cloud
                    res0102U00GetDataGridViewResult = NuroRES0102U00GetDataGridView();

                    grdRES0102.QueryLayout(true);
                    grdRES0103.QueryLayout(true);
                    grdRES0103R.QueryLayout(true);
                    grdRES0104.QueryLayout(true);

                    break;
                case FunctionType.Insert:

                    e.IsBaseCall = false;
                    xEditGridCell100.IsReadOnly = false;

                    if (CurrMSLayout == grdRES0102)
                    {
                        string doctor = cboDoctor.GetDataValue();
                        if (doctor == "")
                        {
                            mbxMsg = Resource.MSG003_MSG;
                            mbxCap = "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                        }
                        else
                            InsertRES0102();
                    }
                    else
                    {
                        if (CurrMSLayout == null) return;

                        string doctor = "";
                        int insertRow = -1;

                        if (grdRES0102.CurrentRowNumber < 0)
                            return;
                        else
                            doctor = grdRES0102.GetItemString(grdRES0102.CurrentRowNumber, "doctor");

                        DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

                        if (chkCell.RowNumber < 0)
                        {
                            insertRow = ((XEditGrid)CurrMSLayout).InsertRow(-1);
                            ((XEditGrid)CurrMSLayout).SetItemValue(insertRow, "doctor", doctor);
                        }
                        else
                            ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    }


                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;
                    mIsSaveSuccess = true;
                    mErrMsg = "";
                    if (rbtReser.Checked)
                    {
                        if (EmkDoc_res_limit.Text.Equals("") || emkEtc_res_limit.Text.Equals("") || emkOut_Hosp_Res_Limit.Text.Equals(""))
                        {
                            mbxMsg = Resource.MSG_32;
                            XMessageBox.Show(mbxMsg, Resource.MSG022_CAP, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            int emkDoc = Convert.ToInt32(EmkDoc_res_limit.Text) !=null ? Convert.ToInt32(EmkDoc_res_limit.Text) : 0;
                            int emkEtc = Convert.ToInt32(emkEtc_res_limit.Text) !=null ? Convert.ToInt32(emkEtc_res_limit.Text) : 0;
                            int emkOut = Convert.ToInt32(emkOut_Hosp_Res_Limit.Text) != null ? Convert.ToInt32(emkOut_Hosp_Res_Limit.Text) : 0;
                            if (emkDoc < emkEtc + emkOut)
                            {
                                mbxMsg = Resource.MSG035_MSG;
                                XMessageBox.Show(mbxMsg, "", MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < this.grdRES0102.RowCount; i++)
                    {
                        NuroRES0102U00GrdRES0102Info list = new NuroRES0102U00GrdRES0102Info();
                        DateTime StartDate = Convert.ToDateTime(this.grdRES0102.GetItemString(i, "start_date"));
                        DateTime EndDate = Convert.ToDateTime(this.grdRES0102.GetItemString(i, "end_date"));
                        TimeSpan subDate = EndDate - StartDate;
                        Double subDateValue = subDate.TotalDays;
                        if (subDateValue < 0)
                        {
                            XMessageBox.Show(Resource.msgCheckDate, Resource.msgCheckDateCap, MessageBoxIcon.Warning);
                            return;
                        }
                        
                    }
                    try
                    {
                        NuroRES0102U00SaveScheduleArgs saveScheduleArgs = new NuroRES0102U00SaveScheduleArgs();
                        saveScheduleArgs.GridRes0102SaveItem = create_dataSaveGridRes0102();
                        saveScheduleArgs.GridRes0103SaveItem = create_dataSaveGridRes0103();
                        saveScheduleArgs.GridRes0103RSaveItem = create_dataSaveGridRes0103Res();
                        saveScheduleArgs.GridDoctorSaveItem = create_dataSaveGridDoctor();
                        saveScheduleArgs.UserId = UserInfo.UserID;
                        saveScheduleArgs.HospCode = mHospCode;
                        UpdateResult updateResult =
                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00SaveScheduleArgs>(saveScheduleArgs);

                        if (updateResult != null && updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result == true)
                        {
                            mIsSaveSuccess = true;

                        }
                        else
                        {
                            mIsSaveSuccess = false;
                        }

                        if (mIsSaveSuccess && updateResult.Msg == "")
                        {
                            mbxMsg = Resource.MSG004_MSG;
                            XMessageBox.Show(mbxMsg, Resource.MSG004_CAP);
                            xButtonList1.PerformClick(FunctionType.Query);
                        }
                        else if (updateResult.Msg == "MSG025_MSG")
                        {
                            int currentRowIndex = grdRES0102.CurrentRowNumber;
                            mbxMsg = Resource.MSG025_0_MSG + grdRES0102.GetItemString(currentRowIndex, "start_date") + Resource.MSG025_MSG;
                            XMessageBox.Show(mbxMsg, Resource.MSG005_CAP);
                            xButtonList1.PerformClick(FunctionType.Query);
                        }
                        else if (updateResult.Msg == "MSG028_MSG")
                        {
                            XMessageBox.Show(Resource.MSG28);
                            xButtonList1.PerformClick(FunctionType.Query);
                        }
                        else
                        {                                                       
                            mbxMsg = Resource.MSG031_MSG;
                            mbxCap = Resource.MSG005_CAP;
                            XMessageBox.Show(mbxMsg, mbxCap);
                        }

                        //                        Service.BeginTransaction();
                        //
                        //                        if (grdRES0102.SaveLayout())
                        //                        {
                        //                            if (grdRES0103.SaveLayout())
                        //                            {
                        //                                if (grdRES0103R.SaveLayout())
                        //                                {
                        //                                    if (grdRES0104.SaveLayout())
                        //                                    {
                        //                                        mbxMsg = Resource.MSG004_MSG;
                        //                                        XMessageBox.Show(mbxMsg, Resource.MSG004_CAP);
                        //
                        //                                        //다시 조회
                        //                                        grdRES0103.QueryLayout(false);
                        //                                        grdRES0103R.QueryLayout(false);
                        //                                        grdRES0104.QueryLayout(false);
                        //                                    }
                        //                                    else
                        //                                        throw new Exception();
                        //                                }
                        //                                else
                        //                                    throw new Exception();
                        //                            }
                        //                            else
                        //                                throw new Exception();
                        //                        }
                        //                        else
                        //                            throw new Exception();
                        //
                        //                        Service.CommitTransaction();

                        // Connect cloud


                    }
                    catch
                    {
                        //                        Service.RollbackTransaction();
                        mIsSaveSuccess = false;
                        //mbxMsg = mErrMsg + Service.ErrFullMsg;
                        mbxMsg = Resource.MSG031_MSG;
                        mbxCap = Resource.MSG005_CAP;
                        XMessageBox.Show(mbxMsg, mbxCap);
                        return;
                    }
                    break;

                case FunctionType.Delete:

                    if (CurrMSLayout == grdRES0102) return;

                    break;

                default:

                    break;
            }
        }

        #endregion

        #region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)

        /// <summary>
        /// Insert한 Row 중에 Not Null필드 미입력 Row Search
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
        /// </remarks>
        /// <param name="aGrd"> XEditGrid  </param>
        /// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added &&
                            TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            celReturn.ColumnNumber = cell.Col;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }
            }
            return celReturn;
        }

        #endregion

        #region [grdRES0102]

        private void grdRES0102_QueryStarting(object sender, CancelEventArgs e)
        {
            grdRES0102.SetBindVarValue("f_hosp_code", mHospCode);
            grdRES0102.SetBindVarValue("f_doctor", cboDoctor.GetDataValue());
            grdRES0102.SetBindVarValue("f_date", dpkApp_date.GetDataValue());
            CreateGwa_roomCombo(cboGwa.GetDataValue());
        }

        private void grdRES0102_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdRES0102.RowCount < 1)
            {
                InsertRES0102();
            }
            else
            {
                dpkStart_date.ReadOnly = true;
                pnlWeekSchedule.Enabled = true;
            }
        }

        #endregion

        #region [grdRES0103]

        private void grdRES0103_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            string chktime = "";

            switch (e.ColName)
            {
                case "jinryo_pre_date":

                    if (e.ChangeValue.ToString().Trim() == "") break;

                    // 중복 Check
                    // 현재 화면
                    for (int i = 0; i < grdRES0103.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdRES0103.GetItemString(i, "jinryo_pre_date").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = Resource.MSG006_MSG;
                                mbxCap = "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    // Delete Table Check
                    // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
                    bool deleted = false;
                    if (grdRES0103.DeletedRowTable != null)
                    {
                        foreach (DataRow row in grdRES0103.DeletedRowTable.Rows)
                        {
                            if (row[e.ColName].ToString() == e.ChangeValue.ToString())
                            {
                                deleted = true;
                                break;
                            }
                        }
                    }

                    if (deleted) break;

                    //Check Origin Data
                    layCommon.Reset();
                    layCommon.ParamList = new List<string>(new String[] { "f_hosp_code", "f_doctor", "f_jinryo_pre_date" });
                    layCommon.ExecuteQuery = GetDoctorByJinryo1ExecuteQuery;
                    layCommon.LayoutItems.Clear();
                    layCommon.LayoutItems.Add("doctor");

                    layCommon.SetBindVarValue("f_hosp_code", mHospCode);
                    layCommon.SetBindVarValue("f_doctor", e.DataRow["doctor"].ToString());
                    layCommon.SetBindVarValue("f_jinryo_pre_date", e.ChangeValue.ToString());

                    if (layCommon.QueryLayout() && !TypeCheck.IsNull(layCommon.GetItemValue("doctor")))
                    {
                        mbxMsg = Resource.MSG006_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }

                    break;

                case "am_start_hhmm":

                    if (e.ChangeValue.ToString() == "") return;

                    if (e.ChangeValue.ToString().Length != 4)
                    {
                        mbxMsg = Resource.MSG007_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

                    if (!TypeCheck.IsDateTime("2006/04/01 " + chktime))
                    {
                        mbxMsg = Resource.MSG007_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    if (int.Parse(e.ChangeValue.ToString()) < AM_START_TIME ||
                        int.Parse(e.ChangeValue.ToString()) > AM_END_TIME)
                    {
                        string start_time_str = AM_START_TIME.ToString().Substring(0, 2) + ":" +
                                                AM_START_TIME.ToString().Substring(2, 2);
                        string end_time_str = AM_END_TIME.ToString().Substring(0, 2) + ":" +
                                              AM_END_TIME.ToString().Substring(2, 2);

                        //MED-12064
                        if (NetInfo.Language == LangMode.Jr)
                        {
                            mbxMsg = Resource.MSG008_MSG_1 + start_time_str + " ~ " + end_time_str + Resource.MSG008_MSG_2;
                        }
                        else
                        {
                            mbxMsg = Resource.MSG008_MSG_1 + start_time_str + " ~ " + end_time_str + "」";
                        }
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    break;

                case "am_end_hhmm":

                    if (e.ChangeValue.ToString() == "") return;

                    if (e.ChangeValue.ToString().Length != 4)
                    {
                        mbxMsg = Resource.MSG009_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

                    if (!TypeCheck.IsDateTime("2006/04/01 " + chktime))
                    {
                        mbxMsg = Resource.MSG009_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    if (int.Parse(e.ChangeValue.ToString()) < AM_START_TIME ||
                        int.Parse(e.ChangeValue.ToString()) > AM_END_TIME)
                    {
                        string start_time_str = AM_START_TIME.ToString().Substring(0, 2) + ":" +
                                                AM_START_TIME.ToString().Substring(2, 2);
                        string end_time_str = AM_END_TIME.ToString().Substring(0, 2) + ":" +
                                              AM_END_TIME.ToString().Substring(2, 2);

                        //MED-12064
                        if (NetInfo.Language == LangMode.Jr)
                        {
                            mbxMsg = Resource.MSG008_MSG_1 + start_time_str + " ~ " + end_time_str + Resource.MSG008_MSG_2;
                        }
                        else
                        {
                            mbxMsg = Resource.MSG008_MSG_1 + start_time_str + " ~ " + end_time_str + "」";
                        }
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    break;

                case "pm_start_hhmm":

                    if (e.ChangeValue.ToString() == "") return;

                    if (e.ChangeValue.ToString().Length != 4)
                    {
                        mbxMsg = Resource.MSG010_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

                    if (!TypeCheck.IsDateTime("2006/04/01 " + chktime))
                    {
                        mbxMsg = Resource.MSG010_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    if (int.Parse(e.ChangeValue.ToString()) < PM_START_TIME ||
                        int.Parse(e.ChangeValue.ToString()) > PM_END_TIME)
                    {
                        string start_time_str = PM_START_TIME.ToString().Substring(0, 2) + ":" +
                                                PM_START_TIME.ToString().Substring(2, 2);
                        string end_time_str = PM_END_TIME.ToString().Substring(0, 2) + ":" +
                                              PM_END_TIME.ToString().Substring(2, 2);

                        //MED-12064
                        if (NetInfo.Language == LangMode.Jr)
                        {
                            mbxMsg = Resource.MSG011_MSG_1 + start_time_str + " ~ " + end_time_str + Resource.MSG008_MSG_2;
                        }
                        else
                        {
                            mbxMsg = Resource.MSG011_MSG_1 + start_time_str + " ~ " + end_time_str + "」";
                        }
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }


                    break;

                case "pm_end_hhmm":

                    if (e.ChangeValue.ToString() == "") return;

                    if (e.ChangeValue.ToString().Length != 4)
                    {
                        mbxMsg = Resource.MSG012_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

                    if (!TypeCheck.IsDateTime("2006/04/01 " + chktime))
                    {
                        mbxMsg = Resource.MSG012_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    if (int.Parse(e.ChangeValue.ToString()) < PM_START_TIME ||
                        int.Parse(e.ChangeValue.ToString()) > PM_END_TIME)
                    {
                        string start_time_str = PM_START_TIME.ToString().Substring(0, 2) + ":" +
                                                PM_START_TIME.ToString().Substring(2, 2);
                        string end_time_str = PM_END_TIME.ToString().Substring(0, 2) + ":" +
                                              PM_END_TIME.ToString().Substring(2, 2);

                        //MED-12064
                        if (NetInfo.Language == LangMode.Jr)
                        {
                            mbxMsg = Resource.MSG011_MSG_1 + start_time_str + " ~ " + end_time_str + Resource.MSG008_MSG_2;
                        }
                        else
                        {
                            mbxMsg = Resource.MSG011_MSG_1 + start_time_str + " ~ " + end_time_str + "」";
                        }
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }


                    break;

                default:
                    break;
            }
        }

        private IList<object[]> GetDoctorByJinryo1ExecuteQuery(BindVarCollection varList)
        {
            return GetDoctor(varList, false);
        }

        private IList<object[]> GetDoctorByJinryo2ExecuteQuery(BindVarCollection varList)
        {
            return GetDoctor(varList, true);
        }

        private IList<object[]> GetDoctor(BindVarCollection varList, bool byRespm)
        {
            NuroRES0102U00GetDoctorByJinryoDateArgs args = new NuroRES0102U00GetDoctorByJinryoDateArgs();
            args.ByResPm = byRespm;
            args.Doctor = varList["f_doctor"].VarValue;
            args.JinryoPreDate = varList["f_jinryo_pre_date"].VarValue;
            args.HospCode = mHospCode;
            NuroRES0102U00GetDoctorResult result =
                CloudService.Instance.Submit<NuroRES0102U00GetDoctorResult, NuroRES0102U00GetDoctorByJinryoDateArgs>(
                    args);

            List<object[]> dataList = new List<object[]>();

            if (result != null && result.DoctorItem.Count > 0)
            {
                foreach (NuroRES0102U00GetDoctorInfo item in result.DoctorItem)
                {
                    dataList.Add(new object[]
                    {
                        item.Doctor
                    });
                }
            }
            return dataList;
        }

        private void grdRES0103_QueryStarting(object sender, CancelEventArgs e)
        {
            grdRES0103.SetBindVarValue("f_hosp_code", mHospCode);
            grdRES0103.SetBindVarValue("f_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            grdRES0103.SetBindVarValue("f_doctor", cboDoctor.GetDataValue());
        }

        #endregion

        #region [grdRES0103Ｒ]

        private void grdRES0103R_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            string chktime = "";

            switch (e.ColName)
            {
                case "jinryo_pre_date":

                    if (e.ChangeValue.ToString().Trim() == "") break;

                    // 중복 Check
                    // 현재 화면
                    for (int i = 0; i < grdRES0103R.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdRES0103R.GetItemString(i, "jinryo_pre_date").Trim() ==
                                e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = Resource.MSG013_MSG;
                                mbxCap = "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    // Delete Table Check
                    // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
                    bool deleted = false;
                    if (grdRES0103R.DeletedRowTable != null)
                    {
                        foreach (DataRow row in grdRES0103R.DeletedRowTable.Rows)
                        {
                            if (row[e.ColName].ToString() == e.ChangeValue.ToString())
                            {
                                deleted = true;
                                break;
                            }
                        }
                    }

                    if (deleted) break;

                    //Check Origin Data
                    layCommon.Reset();
                    layCommon.ParamList = new List<string>(new String[] { "f_hosp_code", "f_doctor", "f_jinryo_pre_date" });
                    layCommon.ExecuteQuery = GetDoctorByJinryo2ExecuteQuery;

                    layCommon.LayoutItems.Clear();
                    layCommon.LayoutItems.Add("doctor");

                    layCommon.SetBindVarValue("f_hosp_code", mHospCode);
                    layCommon.SetBindVarValue("f_doctor", e.DataRow["doctor"].ToString());
                    layCommon.SetBindVarValue("f_jinryo_pre_date", e.ChangeValue.ToString());

                    if (layCommon.QueryLayout() && !TypeCheck.IsNull(layCommon.GetItemValue("doctor")))
                    {
                        mbxMsg = Resource.MSG013_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }

                    break;

                case "res_am_start_hhmm":

                    if (e.ChangeValue.ToString() == "") return;

                    if (e.ChangeValue.ToString().Length != 4)
                    {
                        mbxMsg = Resource.MSG014_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

                    if (!TypeCheck.IsDateTime("2006/04/01 " + chktime))
                    {
                        mbxMsg = Resource.MSG014_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    if (int.Parse(e.ChangeValue.ToString()) < AM_START_TIME ||
                        int.Parse(e.ChangeValue.ToString()) > AM_END_TIME)
                    {
                        string time_str = AM_END_TIME.ToString().Substring(0, 2) + ":" +
                                          AM_END_TIME.ToString().Substring(2, 2);

                        //MED-12064
                        if (NetInfo.Language == LangMode.Jr)
                        {
                            mbxMsg = Resource.MSG008_MSG_1 + time_str + Resource.MSG008_MSG_2;
                        }
                        else
                        {
                            mbxMsg = Resource.MSG008_MSG_1 + time_str + "」";
                        }
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    break;

                case "res_am_end_hhmm":

                    if (e.ChangeValue.ToString() == "") return;

                    if (e.ChangeValue.ToString().Length != 4)
                    {
                        mbxMsg = Resource.MSG015_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

                    if (!TypeCheck.IsDateTime("2006/04/01 " + chktime))
                    {
                        mbxMsg = Resource.MSG015_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    if (int.Parse(e.ChangeValue.ToString()) < AM_START_TIME ||
                        int.Parse(e.ChangeValue.ToString()) > AM_END_TIME)
                    {
                        string time_str = AM_END_TIME.ToString().Substring(0, 2) + ":" +
                                          AM_END_TIME.ToString().Substring(2, 2);

                        //MED-12064
                        if (NetInfo.Language == LangMode.Jr)
                        {
                            mbxMsg = Resource.MSG008_MSG_1 + time_str + Resource.MSG008_MSG_2;
                        }
                        else
                        {
                            mbxMsg = Resource.MSG008_MSG_1 + time_str + "」";
                        }

                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    break;

                case "res_pm_start_hhmm":

                    if (e.ChangeValue.ToString() == "") return;

                    if (e.ChangeValue.ToString().Length != 4)
                    {
                        mbxMsg = Resource.MSG016_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

                    if (!TypeCheck.IsDateTime("2006/04/01 " + chktime))
                    {
                        mbxMsg = Resource.MSG016_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    if (int.Parse(e.ChangeValue.ToString()) < PM_START_TIME ||
                        int.Parse(e.ChangeValue.ToString()) > PM_END_TIME)
                    {
                        string time_str = AM_END_TIME.ToString().Substring(0, 2) + ":" +
                                          AM_END_TIME.ToString().Substring(2, 2);

                        //MED-12064
                        if (NetInfo.Language == LangMode.Jr)
                        {
                            mbxMsg = Resource.MSG011_MSG_1 + time_str + Resource.MSG017_MSG_2;
                        }
                        else
                        {
                            mbxMsg = Resource.MSG011_MSG_1 + time_str + "」";
                        }
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }


                    break;

                case "res_pm_end_hhmm":

                    if (e.ChangeValue.ToString() == "") return;

                    if (e.ChangeValue.ToString().Length != 4)
                    {
                        mbxMsg = Resource.MSG018_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

                    if (!TypeCheck.IsDateTime("2006/04/01 " + chktime))
                    {
                        mbxMsg = Resource.MSG018_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }

                    if (int.Parse(e.ChangeValue.ToString()) < PM_START_TIME ||
                        int.Parse(e.ChangeValue.ToString()) > PM_END_TIME)
                    {
                        string time_str = AM_END_TIME.ToString().Substring(0, 2) + ":" +
                                          AM_END_TIME.ToString().Substring(2, 2);

                        //MED-12064
                        if (NetInfo.Language == LangMode.Jr)
                        {
                            mbxMsg = Resource.MSG011_MSG_1 + time_str + Resource.MSG017_MSG_2;
                        }
                        else
                        {
                            mbxMsg = Resource.MSG011_MSG_1 + time_str + "」";
                        }
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        break;
                    }


                    break;

                default:
                    break;
            }
        }

        private void grdRES0103R_QueryStarting(object sender, CancelEventArgs e)
        {
            grdRES0103R.SetBindVarValue("f_hosp_code", mHospCode);
            grdRES0103R.SetBindVarValue("f_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            grdRES0103R.SetBindVarValue("f_doctor", cboDoctor.GetDataValue());
        }

        #endregion

        #region [grdRES0104]

        private void grdRES0104_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            e.Cancel = false;


            switch (e.ColName)
            {
                case "start_date":

                    if (e.ChangeValue.ToString().Trim() == "") break;

                    // 중복 Check
                    // 현재 화면
                    for (int i = 0; i < grdRES0104.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdRES0104.GetItemString(i, "start_date").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = Resource.MSG019_MSG;
                                mbxCap = "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    // Delete Table Check
                    // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
                    bool deleted = false;
                    if (grdRES0104.DeletedRowTable != null && grdRES0104.DeletedRowCount > 0)
                    {
                        foreach (DataRow row in grdRES0104.DeletedRowTable.Rows)
                        {
                            if (row[e.ColName].ToString() == e.ChangeValue.ToString())
                            {
                                deleted = true;
                                break;
                            }
                        }
                    }

                    if (deleted) break;

                    //Check Origin Data
                    layCommon.Reset();
                    layCommon.ParamList = new List<string>(new String[] { "f_hosp_code", "f_doctor", "f_start_date" });
                    layCommon.ExecuteQuery = GetDoctorByStartDateExecuteQuery;
                    layCommon.LayoutItems.Clear();
                    layCommon.LayoutItems.Add("doctor");

                    layCommon.SetBindVarValue("f_hosp_code", mHospCode);
                    layCommon.SetBindVarValue("f_doctor", e.DataRow["doctor"].ToString());
                    layCommon.SetBindVarValue("f_start_date", e.ChangeValue.ToString());

                    if (layCommon.QueryLayout() && !TypeCheck.IsNull(layCommon.GetItemValue("doctor")))
                    {
                        mbxMsg = Resource.MSG019_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }

                    //휴진일자 체크하여 예약환자 메시지 처리
                    if (!TypeCheck.IsNull(e.ColName) &&
                        !TypeCheck.IsNull(grdRES0104.GetItemString(e.RowNumber, "end_date")))
                    {
                        if (ChkHyujinPatients())
                        {
                            if (o_check == "Y")
                            {
                                string mbxMsg = "", mbxCap = "";
                                mbxMsg = Resource.MSG020_MSG;

                                switch (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo))
                                {
                                    case DialogResult.No:
                                        grdRES0104.SetItemValue(e.RowNumber, "start_date", "");
                                        Objects objects = null;
                                        objects = new Objects(grdRES0104, e.RowNumber, "end_date");
                                        PostCallHelper.PostCall(new PostMethodObject(PostSetFocusToItem),
                                            ((object)objects)); // 현재 Column으로 Focus이동처리
                                        break;
                                    case DialogResult.Yes:
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    break;

                case "end_date":
                    if (e.ChangeValue.ToString().Trim() == "") break;

                    if (!TypeCheck.IsNull(e.ColName) &&
                        !TypeCheck.IsNull(grdRES0104.GetItemString(e.RowNumber, "start_date")))
                    {
                        if (ChkHyujinPatients())
                        {
                            if (o_check == "Y")
                            {
                                string mbxMsg = "", mbxCap = "";
                                mbxMsg = Resource.MSG021_MSG;

                                switch (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo))
                                {
                                    case DialogResult.No:
                                        grdRES0104.SetItemValue(e.RowNumber, "end_date", "");
                                        Objects objects = null;
                                        objects = new Objects(grdRES0104, e.RowNumber, "end_date");
                                        PostCallHelper.PostCall(new PostMethodObject(PostSetFocusToItem),
                                            ((object)objects)); // 현재 Column으로 Focus이동처리
                                        //e.Cancel = true;
                                        break;
                                    case DialogResult.Yes:
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private IList<object[]> GetDoctorByStartDateExecuteQuery(BindVarCollection varList)
        {
            NuroRES0102U00GetDoctorByStarDateArgs args = new NuroRES0102U00GetDoctorByStarDateArgs();
            args.Doctor = varList["f_doctor"].VarValue;
            args.StartDate = varList["f_start_date"].VarValue;
            args.HospCode = mHospCode;
            NuroRES0102U00GetDoctorResult result =
                CloudService.Instance.Submit<NuroRES0102U00GetDoctorResult, NuroRES0102U00GetDoctorByStarDateArgs>(
                    args);

            List<object[]> dataList = new List<object[]>();

            if (result != null && result.DoctorItem.Count > 0)
            {
                foreach (NuroRES0102U00GetDoctorInfo item in result.DoctorItem)
                {
                    dataList.Add(new object[]
                    {
                        item.Doctor
                    });
                }
            }
            return dataList;
        }

        private void grdRES0104_QueryStarting(object sender, CancelEventArgs e)
        {
            grdRES0104.SetBindVarValue("f_hosp_code", mHospCode);
            grdRES0104.SetBindVarValue("f_doctor", cboDoctor.GetDataValue());
        }

        #endregion

        #region [ChkHyujinPatients]

        private string o_check = "";

        private bool ChkHyujinPatients()
        {
            object t_doctor = null;

            o_check = "";

            string f_doctor = cboDoctor.GetDataValue();
            string f_start_date = grdRES0104.GetItemString(grdRES0104.CurrentRowNumber, "start_date");
            string f_end_date = grdRES0104.GetItemString(grdRES0104.CurrentRowNumber, "end_date");

            NuroRES0102U00GetDoctorInBetweenDateArgs args = new NuroRES0102U00GetDoctorInBetweenDateArgs();
            args.Doctor = f_doctor;
            args.StartDate = f_start_date;
            args.HospCode = mHospCode;
            NuroRES0102U00GetDoctorResult result =
                CloudService.Instance.Submit<NuroRES0102U00GetDoctorResult, NuroRES0102U00GetDoctorInBetweenDateArgs>(
                    args);

            t_doctor = result.DoctorItem[0];

            if (TypeCheck.IsNull(t_doctor))
            {
                XMessageBox.Show(Resource.MSG022_MSG, Resource.MSG022_CAP, MessageBoxIcon.Warning);
                return false;
            }

            /* 대표의사코드로 예약환자 여부 체크 */

            layChkHyujin.SetBindVarValue("f_hosp_code", mHospCode);
            layChkHyujin.SetBindVarValue("f_start_date", f_start_date);
            layChkHyujin.SetBindVarValue("f_end_date", f_end_date);
            layChkHyujin.SetBindVarValue("f_doctor", result.DoctorItem[0].Doctor);

            if (!layChkHyujin.QueryLayout())
            {
                //XMessageBox.Show(Service.ErrFullMsg, "エラー", MessageBoxIcon.Stop);
                o_check = "";
                return false;
            }
            o_check = layChkHyujin.GetItemValue("check").ToString();
            return true;
        }

        #endregion

        #region [Service Control Event]

        /// <summary>
        /// 저장전 Validation Check 
        /// </summary>
        private void grd_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            //grdRES0102
            if (!TypeCheck.IsDateTime(dpkStart_date.Text))
            {
                mbxMsg = Resource.MSG023_MSG;
                mbxCap = "";
                XMessageBox.Show(mbxMsg, mbxCap);
                dpkStart_date.Focus();
                return;
            }

            for (int rowIndex = 0; rowIndex < grdRES0103.RowCount; rowIndex++)
            {
                if (grdRES0103.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdRES0103.GetItemString(rowIndex, "jinryo_pre_date").Trim() == "")
                    {
                        grdRES0103.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                    }
                }
            }

            for (int rowIndex = 0; rowIndex < grdRES0103R.RowCount; rowIndex++)
            {
                if (grdRES0103R.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdRES0103R.GetItemString(rowIndex, "jinryo_pre_date").Trim() == "")
                    {
                        grdRES0103R.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                    }
                }
            }

            for (int rowIndex = 0; rowIndex < grdRES0104.RowCount; rowIndex++)
            {
                if (grdRES0104.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdRES0104.GetItemString(rowIndex, "start_date").Trim() == "")
                    {
                        grdRES0104.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                    }
                }
            }
        }

        #endregion

        #region [Control Event ]

        private void cboGwa_SelectedIndexChanged(object sender, EventArgs e)
        {
            mGwa = cboGwa.SelectedValue.ToString();
            CreateDoctorCombo(mGwa);
            CreateGwa_roomCombo(mGwa);
            ClearALL();
        }

        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearALL();

            // Connect cloud
            res0102U00GetDataGridViewResult = NuroRES0102U00GetDataGridView();

            grdRES0102.QueryLayout(true);
            grdRES0103.QueryLayout(true);
            grdRES0103R.QueryLayout(true);
            grdRES0104.QueryLayout(true);
        }

        private void dpkApp_date_DataValidating(object sender, DataValidatingEventArgs e)
        {
            ClearALL();

            CreateDoctorCombo(cboGwa.GetDataValue());

            // Connect cloud
            res0102U00GetDataGridViewResult = NuroRES0102U00GetDataGridView();

            grdRES0102.QueryLayout(true);
            grdRES0103.QueryLayout(true);
            grdRES0103R.QueryLayout(true);
            grdRES0104.QueryLayout(true);
        }

        #endregion

        #region [SetPostFocusGrid]

        private void PostSetFocusGrd(string colName)
        {
            ((XEditGrid)CurrMSLayout).SetFocusToItem(((XEditGrid)CurrMSLayout).CurrentRowNumber, colName);
        }

        #endregion

        #region [Insert RES0102]

        private void InsertRES0102()
        {            
            string doctor = cboDoctor.GetDataValue();
            if (doctor != "")
            {
                int currentRowIndex = grdRES0102.CurrentRowNumber;
                string tStartDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

                ///* 같은 날짜로 생성하려고 하면 중복에러 나므로 추가 김보현 2010/06/16 */
                if (grdRES0102.GetItemString(currentRowIndex, "start_date") == tStartDate)
                {
                    XMessageBox.Show(Resource.MSG024_0_MSG + tStartDate + Resource.MSG024_MSG, Resource.MSG022_CAP,
                        MessageBoxIcon.Warning);
                    //return;
                }

                string gwa = cboGwa.GetDataValue();

                pnlWeekSchedule.Enabled = true;
                dpkStart_date.ReadOnly = false;

                int insertRow = grdRES0102.InsertRow(-1);
                grdRES0102.SetItemValue(insertRow, "doctor", doctor);
                grdRES0102.SetItemValue(insertRow, "gwa", gwa);
                grdRES0102.SetItemValue(insertRow, "start_date", tStartDate);
                grdRES0102.SetItemValue(insertRow, "end_date", "9998/12/31");
                ((IDataControl)htControl["start_date"]).DataValue = tStartDate;

                //기존에 값이 있는 경우 해당 값을 default로 가져간다.
                if (currentRowIndex >= 0 && grdRES0102.GetRowState(currentRowIndex) != DataRowState.Added)
                {
                    foreach (XEditGridCell cell in grdRES0102.CellInfos)
                    {
                        if (TypeCheck.IsNull(grdRES0102.GetItemValue(insertRow, cell.CellName)))
                            grdRES0102.SetItemValue(insertRow, cell.CellName,
                                grdRES0102.GetItemValue(currentRowIndex, cell.CellName));
                    }
                }

                dpkStart_date.Focus();
            }
        }

        #endregion

        #region [진료시간 설정 RadioButton]

        private void rbtJinryo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtJinryo.Checked)
            {
                rbtJinryo.BackColor = new XColor(SystemColors.ActiveCaption);
                rbtJinryo.Font = new Font(rbtJinryo.Font.FontFamily, rbtJinryo.Font.Size, FontStyle.Bold);
                rbtJinryo.ImageIndex = 4;

                rbtReser.BackColor = new XColor(SystemColors.InactiveCaption);
                rbtReser.Font = new Font(rbtJinryo.Font.FontFamily, rbtJinryo.Font.Size);
                rbtReser.ImageIndex = 3;
                
                pnlReser.Visible = false;
                pnlJinryo.Visible = true;
                xLabel1.Text = Resource.RBTJINRYO1_TEXT;
                grdRES0103.Visible = true;
                grdRES0103R.Visible = false;

                lb1.Visible = false;
                lb2.Visible = false;
                lb3.Visible = false;
                lb4.Visible = false;
                lb55.Visible = false;
                emkOut_Hosp_Res_Limit.Visible = false;
                cboAvg_time.Visible = false;
                EmkDoc_res_limit.Visible = false;
                emkEtc_res_limit.Visible = false;
            }
            else
            {
                rbtReser.BackColor = new XColor(SystemColors.ActiveCaption);
                rbtReser.Font = new Font(rbtJinryo.Font.FontFamily, rbtJinryo.Font.Size, FontStyle.Bold);
                rbtReser.ImageIndex = 4;

                rbtJinryo.BackColor = new XColor(SystemColors.InactiveCaption);
                rbtJinryo.Font = new Font(rbtJinryo.Font.FontFamily, rbtJinryo.Font.Size);
                rbtJinryo.ImageIndex = 3;

                pnlJinryo.Visible = false;
                pnlReser.Visible = true;

                xLabel1.Text = Resource.RBTJINRYO2_TEXT;
                grdRES0103.Visible = false;
                grdRES0103R.Visible = true;

                lb1.Visible = true;
                lb2.Visible = true;
                lb3.Visible = true;
                lb4.Visible = true;
                lb55.Visible = true;
                emkOut_Hosp_Res_Limit.Visible = true;
                cboAvg_time.Visible = true;
                EmkDoc_res_limit.Visible = true;
                emkEtc_res_limit.Visible = true;
            }
        }

        #endregion

        #region [의사리스트 조회화면 콜]

        private void fbxDoctor_FindClick(object sender, CancelEventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("gwa", cboGwa.GetDataValue().ToString());
            openParams.Add("word", "");
            openParams.Add("all_gubun", "N");
            openParams.Add("query_gubun", "%");
            openParams.Add("jukyong_date", dpkApp_date.GetDataValue());
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                openParams.Add("hosp_code", xHospBox1.HospCode);
            }

            OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        #endregion

        #region [팝업화면에서 데이터 받기]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "OCS0270Q00")
            {
                cboGwa.SetDataValue(commandParam["gwa"].ToString());

                dbxDoctor_name.SetEditValue(commandParam["doctor_name"].ToString());
                dbxDoctor_name.AcceptData();

                fbxDoctor.SetEditValue(commandParam["doctor"].ToString());
                fbxDoctor.AcceptData();

                object obj = cboDoctor.DataSource;
                cboDoctor.SetEditValue(commandParam["doctor"].ToString());
                cboDoctor.AcceptData();
            }

            return base.Command(command, commandParam);
        }

        #endregion

        #region XGrid에 해당컬럼에 Focus (PostCall용) (PostSetFocusToItem)

        /// <summary> 
        /// XGrid에 해당컬럼에 Focus (PostCall용)
        /// </summary>
        /// <param name="object"> aObjs (**OrderVariables.Objects Type임** : Grid, Int Row, String ColName) </param>
        /// <returns> void </returns>
        public void PostSetFocusToItem(object aObjs)
        {
            try
            {
                Objects objects = (Objects)aObjs;
                ((XGrid)objects.obj1).Focus();
                ((XGrid)objects.obj1).SetFocusToItem(((int)objects.obj2), ((string)objects.obj3));
            }
            catch
            {
            }
        }

        #endregion

        //#region XSavePerformer

        //private class XSavePerformer : ISavePerformer
        //{
        //    private RES0102U00 parent;

        //    public XSavePerformer(RES0102U00 parent)
        //    {
        //        this.parent = parent;
        //    }

        //    public bool Execute(char callerID, RowDataItem item)
        //    {
        //        object t_chk = null;
        //        UpdateResult updateResult = null;

        //        item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        //        switch (callerID)
        //        {
        //            case '1':
        //                switch (item.RowState)
        //                {
        //                    case DataRowState.Added:

        //                        /* 중복체크*/
        //                        NuroRES0102U00CheckDoctorReq1Args checkDoctorRequest1 =
        //                            new NuroRES0102U00CheckDoctorReq1Args();
        //                        checkDoctorRequest1.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        checkDoctorRequest1.StartDate = item.BindVarList["f_start_date"].VarValue;
        //                        checkDoctorRequest1.HospCode = parent.mHospCode;

        //                        NuroRES0102U00CheckDoctorResult res =
        //                            CloudService.Instance
        //                                .Submit<NuroRES0102U00CheckDoctorResult, NuroRES0102U00CheckDoctorReq1Args>(
        //                                    checkDoctorRequest1);
        //                        if (res != null && res.Check != null && res.Check.Equals("Y"))
        //                        {
        //                            parent.mErrMsg = Resource.MSG025_0_MSG + item.BindVarList["f_start_date"].VarValue +
        //                                             Resource.MSG025_MSG;
        //                            return false;
        //                        }

        //                        /* 이전 데이타의 종료일 수정 김보현  */
        //                        NuroRES0102U00UpdateRES0102Req1Args updateRes0102Req1Args =
        //                            new NuroRES0102U00UpdateRES0102Req1Args();
        //                        updateRes0102Req1Args.StartDate = item.BindVarList["f_start_date"].VarValue;
        //                        updateRes0102Req1Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        updateRes0102Req1Args.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00UpdateRES0102Req1Args>(
        //                                updateRes0102Req1Args);

        //                        NuroRES0102U00DeleteRES0102Args deleteRes0102Args =
        //                            new NuroRES0102U00DeleteRES0102Args();
        //                        deleteRes0102Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        deleteRes0102Args.StartDate = item.BindVarList["f_start_date"].VarValue;
        //                        deleteRes0102Args.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00DeleteRES0102Args>(
        //                                deleteRes0102Args);

        //                        NuroRES0102U00InsertRES0102Args insertRes0102Args =
        //                            new NuroRES0102U00InsertRES0102Args();
        //                        insertRes0102Args.HospCode = parent.mHospCode;
        //                        insertRes0102Args.UserId = item.BindVarList["q_user_id"].VarValue;
        //                        insertRes0102Args.AvgTime = item.BindVarList["f_avg_time"].VarValue;
        //                        insertRes0102Args.JinryoBreakYn = item.BindVarList["f_jinryo_break_yn"].VarValue;
        //                        insertRes0102Args.AmStartHhmm1 = item.BindVarList["f_am_start_hhmm1"].VarValue;
        //                        insertRes0102Args.AmStartHhmm2 = item.BindVarList["f_am_start_hhmm2"].VarValue;
        //                        insertRes0102Args.AmStartHhmm3 = item.BindVarList["f_am_start_hhmm3"].VarValue;
        //                        insertRes0102Args.AmStartHhmm4 = item.BindVarList["f_am_start_hhmm4"].VarValue;
        //                        insertRes0102Args.AmStartHhmm5 = item.BindVarList["f_am_start_hhmm5"].VarValue;
        //                        insertRes0102Args.AmStartHhmm6 = item.BindVarList["f_am_start_hhmm6"].VarValue;
        //                        insertRes0102Args.AmStartHhmm7 = item.BindVarList["f_am_start_hhmm7"].VarValue;
        //                        insertRes0102Args.AmEndHhmm1 = item.BindVarList["f_am_end_hhmm1"].VarValue;
        //                        insertRes0102Args.AmEndHhmm2 = item.BindVarList["f_am_end_hhmm2"].VarValue;
        //                        insertRes0102Args.AmEndHhmm3 = item.BindVarList["f_am_end_hhmm3"].VarValue;
        //                        insertRes0102Args.AmEndHhmm4 = item.BindVarList["f_am_end_hhmm4"].VarValue;
        //                        insertRes0102Args.AmEndHhmm5 = item.BindVarList["f_am_end_hhmm5"].VarValue;
        //                        insertRes0102Args.AmEndHhmm6 = item.BindVarList["f_am_end_hhmm6"].VarValue;
        //                        insertRes0102Args.AmEndHhmm7 = item.BindVarList["f_am_end_hhmm7"].VarValue;
        //                        insertRes0102Args.PmStartHhmm1 = item.BindVarList["f_pm_start_hhmm1"].VarValue;
        //                        insertRes0102Args.PmStartHhmm2 = item.BindVarList["f_pm_start_hhmm2"].VarValue;
        //                        insertRes0102Args.PmStartHhmm3 = item.BindVarList["f_pm_start_hhmm3"].VarValue;
        //                        insertRes0102Args.PmStartHhmm4 = item.BindVarList["f_pm_start_hhmm4"].VarValue;
        //                        insertRes0102Args.PmStartHhmm5 = item.BindVarList["f_pm_start_hhmm5"].VarValue;
        //                        insertRes0102Args.PmStartHhmm6 = item.BindVarList["f_pm_start_hhmm6"].VarValue;
        //                        insertRes0102Args.PmStartHhmm7 = item.BindVarList["f_pm_start_hhmm7"].VarValue;
        //                        insertRes0102Args.PmEndHhmm1 = item.BindVarList["f_pm_end_hhmm1"].VarValue;
        //                        insertRes0102Args.PmEndHhmm2 = item.BindVarList["f_pm_end_hhmm2"].VarValue;
        //                        insertRes0102Args.PmEndHhmm3 = item.BindVarList["f_pm_end_hhmm3"].VarValue;
        //                        insertRes0102Args.PmEndHhmm4 = item.BindVarList["f_pm_end_hhmm4"].VarValue;
        //                        insertRes0102Args.PmEndHhmm5 = item.BindVarList["f_pm_end_hhmm5"].VarValue;
        //                        insertRes0102Args.PmEndHhmm6 = item.BindVarList["f_pm_end_hhmm6"].VarValue;
        //                        insertRes0102Args.PmEndHhmm7 = item.BindVarList["f_pm_end_hhmm7"].VarValue;
        //                        insertRes0102Args.AmGwaRoom1 = item.BindVarList["f_am_gwa_room1"].VarValue;
        //                        insertRes0102Args.AmGwaRoom2 = item.BindVarList["f_am_gwa_room2"].VarValue;
        //                        insertRes0102Args.AmGwaRoom3 = item.BindVarList["f_am_gwa_room3"].VarValue;
        //                        insertRes0102Args.AmGwaRoom4 = item.BindVarList["f_am_gwa_room4"].VarValue;
        //                        insertRes0102Args.AmGwaRoom5 = item.BindVarList["f_am_gwa_room5"].VarValue;
        //                        insertRes0102Args.AmGwaRoom6 = item.BindVarList["f_am_gwa_room6"].VarValue;
        //                        insertRes0102Args.AmGwaRoom7 = item.BindVarList["f_am_gwa_room7"].VarValue;
        //                        insertRes0102Args.PmGwaRoom1 = item.BindVarList["f_pm_gwa_room1"].VarValue;
        //                        insertRes0102Args.PmGwaRoom2 = item.BindVarList["f_pm_gwa_room2"].VarValue;
        //                        insertRes0102Args.PmGwaRoom3 = item.BindVarList["f_pm_gwa_room3"].VarValue;
        //                        insertRes0102Args.PmGwaRoom4 = item.BindVarList["f_pm_gwa_room4"].VarValue;
        //                        insertRes0102Args.PmGwaRoom5 = item.BindVarList["f_pm_gwa_room5"].VarValue;
        //                        insertRes0102Args.PmGwaRoom6 = item.BindVarList["f_pm_gwa_room6"].VarValue;
        //                        insertRes0102Args.PmGwaRoom7 = item.BindVarList["f_pm_gwa_room7"].VarValue;
        //                        insertRes0102Args.ResAmStartHhmm1 = item.BindVarList["f_res_am_start_hhmm1"].VarValue;
        //                        insertRes0102Args.ResAmStartHhmm2 = item.BindVarList["f_res_am_start_hhmm2"].VarValue;
        //                        insertRes0102Args.ResAmStartHhmm3 = item.BindVarList["f_res_am_start_hhmm3"].VarValue;
        //                        insertRes0102Args.ResAmStartHhmm4 = item.BindVarList["f_res_am_start_hhmm4"].VarValue;
        //                        insertRes0102Args.ResAmStartHhmm5 = item.BindVarList["f_res_am_start_hhmm5"].VarValue;
        //                        insertRes0102Args.ResAmStartHhmm6 = item.BindVarList["f_res_am_start_hhmm6"].VarValue;
        //                        insertRes0102Args.ResAmStartHhmm7 = item.BindVarList["f_res_am_start_hhmm7"].VarValue;
        //                        insertRes0102Args.ResAmEndHhmm1 = item.BindVarList["f_res_am_end_hhmm1"].VarValue;
        //                        insertRes0102Args.ResAmEndHhmm2 = item.BindVarList["f_res_am_end_hhmm2"].VarValue;
        //                        insertRes0102Args.ResAmEndHhmm3 = item.BindVarList["f_res_am_end_hhmm3"].VarValue;
        //                        insertRes0102Args.ResAmEndHhmm4 = item.BindVarList["f_res_am_end_hhmm4"].VarValue;
        //                        insertRes0102Args.ResAmEndHhmm5 = item.BindVarList["f_res_am_end_hhmm5"].VarValue;
        //                        insertRes0102Args.ResAmEndHhmm6 = item.BindVarList["f_res_am_end_hhmm6"].VarValue;
        //                        insertRes0102Args.ResAmEndHhmm7 = item.BindVarList["f_res_am_end_hhmm7"].VarValue;
        //                        insertRes0102Args.ResPmStartHhmm1 = item.BindVarList["f_res_pm_start_hhmm1"].VarValue;
        //                        insertRes0102Args.ResPmStartHhmm2 = item.BindVarList["f_res_pm_start_hhmm2"].VarValue;
        //                        insertRes0102Args.ResPmStartHhmm3 = item.BindVarList["f_res_pm_start_hhmm3"].VarValue;
        //                        insertRes0102Args.ResPmStartHhmm4 = item.BindVarList["f_res_pm_start_hhmm4"].VarValue;
        //                        insertRes0102Args.ResPmStartHhmm5 = item.BindVarList["f_res_pm_start_hhmm5"].VarValue;
        //                        insertRes0102Args.ResPmStartHhmm6 = item.BindVarList["f_res_pm_start_hhmm6"].VarValue;
        //                        insertRes0102Args.ResPmStartHhmm7 = item.BindVarList["f_res_pm_start_hhmm7"].VarValue;
        //                        insertRes0102Args.ResPmEndHhmm1 = item.BindVarList["f_res_pm_end_hhmm1"].VarValue;
        //                        insertRes0102Args.ResPmEndHhmm2 = item.BindVarList["f_res_pm_end_hhmm2"].VarValue;
        //                        insertRes0102Args.ResPmEndHhmm3 = item.BindVarList["f_res_pm_end_hhmm3"].VarValue;
        //                        insertRes0102Args.ResPmEndHhmm4 = item.BindVarList["f_res_pm_end_hhmm4"].VarValue;
        //                        insertRes0102Args.ResPmEndHhmm5 = item.BindVarList["f_res_pm_end_hhmm5"].VarValue;
        //                        insertRes0102Args.ResPmEndHhmm6 = item.BindVarList["f_res_pm_end_hhmm6"].VarValue;
        //                        insertRes0102Args.ResPmEndHhmm7 = item.BindVarList["f_res_pm_end_hhmm7"].VarValue;
        //                        insertRes0102Args.DocResLimit = item.BindVarList["f_doc_res_limit"].VarValue;
        //                        insertRes0102Args.EtcResLimit = item.BindVarList["f_etc_res_limit"].VarValue;
        //                        insertRes0102Args.EndDate = item.BindVarList["f_end_date"].VarValue;
        //                        insertRes0102Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        insertRes0102Args.StartDate = item.BindVarList["f_start_date"].VarValue;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00InsertRES0102Args>(
        //                                insertRes0102Args);
        //                        break;

        //                    case DataRowState.Modified:
        //                        NuroRES0102U00UpdateRES0102Req2Args updateRes0102Args =
        //                            new NuroRES0102U00UpdateRES0102Req2Args();
        //                        updateRes0102Args.HospCode = parent.mHospCode;
        //                        updateRes0102Args.UserId = item.BindVarList["q_user_id"].VarValue;
        //                        updateRes0102Args.AvgTime = item.BindVarList["f_avg_time"].VarValue;
        //                        updateRes0102Args.JinryoBreakYn = item.BindVarList["f_jinryo_break_yn"].VarValue;
        //                        updateRes0102Args.AmStartHhmm1 = item.BindVarList["f_am_start_hhmm1"].VarValue;
        //                        updateRes0102Args.AmStartHhmm2 = item.BindVarList["f_am_start_hhmm2"].VarValue;
        //                        updateRes0102Args.AmStartHhmm3 = item.BindVarList["f_am_start_hhmm3"].VarValue;
        //                        updateRes0102Args.AmStartHhmm4 = item.BindVarList["f_am_start_hhmm4"].VarValue;
        //                        updateRes0102Args.AmStartHhmm5 = item.BindVarList["f_am_start_hhmm5"].VarValue;
        //                        updateRes0102Args.AmStartHhmm6 = item.BindVarList["f_am_start_hhmm6"].VarValue;
        //                        updateRes0102Args.AmStartHhmm7 = item.BindVarList["f_am_start_hhmm7"].VarValue;
        //                        updateRes0102Args.AmEndHhmm1 = item.BindVarList["f_am_end_hhmm1"].VarValue;
        //                        updateRes0102Args.AmEndHhmm2 = item.BindVarList["f_am_end_hhmm2"].VarValue;
        //                        updateRes0102Args.AmEndHhmm3 = item.BindVarList["f_am_end_hhmm3"].VarValue;
        //                        updateRes0102Args.AmEndHhmm4 = item.BindVarList["f_am_end_hhmm4"].VarValue;
        //                        updateRes0102Args.AmEndHhmm5 = item.BindVarList["f_am_end_hhmm5"].VarValue;
        //                        updateRes0102Args.AmEndHhmm6 = item.BindVarList["f_am_end_hhmm6"].VarValue;
        //                        updateRes0102Args.AmEndHhmm7 = item.BindVarList["f_am_end_hhmm7"].VarValue;
        //                        updateRes0102Args.PmStartHhmm1 = item.BindVarList["f_pm_start_hhmm1"].VarValue;
        //                        updateRes0102Args.PmStartHhmm2 = item.BindVarList["f_pm_start_hhmm2"].VarValue;
        //                        updateRes0102Args.PmStartHhmm3 = item.BindVarList["f_pm_start_hhmm3"].VarValue;
        //                        updateRes0102Args.PmStartHhmm4 = item.BindVarList["f_pm_start_hhmm4"].VarValue;
        //                        updateRes0102Args.PmStartHhmm5 = item.BindVarList["f_pm_start_hhmm5"].VarValue;
        //                        updateRes0102Args.PmStartHhmm6 = item.BindVarList["f_pm_start_hhmm6"].VarValue;
        //                        updateRes0102Args.PmStartHhmm7 = item.BindVarList["f_pm_start_hhmm7"].VarValue;
        //                        updateRes0102Args.PmEndHhmm1 = item.BindVarList["f_pm_end_hhmm1"].VarValue;
        //                        updateRes0102Args.PmEndHhmm2 = item.BindVarList["f_pm_end_hhmm2"].VarValue;
        //                        updateRes0102Args.PmEndHhmm3 = item.BindVarList["f_pm_end_hhmm3"].VarValue;
        //                        updateRes0102Args.PmEndHhmm4 = item.BindVarList["f_pm_end_hhmm4"].VarValue;
        //                        updateRes0102Args.PmEndHhmm5 = item.BindVarList["f_pm_end_hhmm5"].VarValue;
        //                        updateRes0102Args.PmEndHhmm6 = item.BindVarList["f_pm_end_hhmm6"].VarValue;
        //                        updateRes0102Args.PmEndHhmm7 = item.BindVarList["f_pm_end_hhmm7"].VarValue;
        //                        updateRes0102Args.AmGwaRoom1 = item.BindVarList["f_am_gwa_room1"].VarValue;
        //                        updateRes0102Args.AmGwaRoom2 = item.BindVarList["f_am_gwa_room2"].VarValue;
        //                        updateRes0102Args.AmGwaRoom3 = item.BindVarList["f_am_gwa_room3"].VarValue;
        //                        updateRes0102Args.AmGwaRoom4 = item.BindVarList["f_am_gwa_room4"].VarValue;
        //                        updateRes0102Args.AmGwaRoom5 = item.BindVarList["f_am_gwa_room5"].VarValue;
        //                        updateRes0102Args.AmGwaRoom6 = item.BindVarList["f_am_gwa_room6"].VarValue;
        //                        updateRes0102Args.AmGwaRoom7 = item.BindVarList["f_am_gwa_room7"].VarValue;
        //                        updateRes0102Args.PmGwaRoom1 = item.BindVarList["f_pm_gwa_room1"].VarValue;
        //                        updateRes0102Args.PmGwaRoom2 = item.BindVarList["f_pm_gwa_room2"].VarValue;
        //                        updateRes0102Args.PmGwaRoom3 = item.BindVarList["f_pm_gwa_room3"].VarValue;
        //                        updateRes0102Args.PmGwaRoom4 = item.BindVarList["f_pm_gwa_room4"].VarValue;
        //                        updateRes0102Args.PmGwaRoom5 = item.BindVarList["f_pm_gwa_room5"].VarValue;
        //                        updateRes0102Args.PmGwaRoom6 = item.BindVarList["f_pm_gwa_room6"].VarValue;
        //                        updateRes0102Args.PmGwaRoom7 = item.BindVarList["f_pm_gwa_room7"].VarValue;
        //                        updateRes0102Args.ResAmStartHhmm1 = item.BindVarList["f_res_am_start_hhmm1"].VarValue;
        //                        updateRes0102Args.ResAmStartHhmm2 = item.BindVarList["f_res_am_start_hhmm2"].VarValue;
        //                        updateRes0102Args.ResAmStartHhmm3 = item.BindVarList["f_res_am_start_hhmm3"].VarValue;
        //                        updateRes0102Args.ResAmStartHhmm4 = item.BindVarList["f_res_am_start_hhmm4"].VarValue;
        //                        updateRes0102Args.ResAmStartHhmm5 = item.BindVarList["f_res_am_start_hhmm5"].VarValue;
        //                        updateRes0102Args.ResAmStartHhmm6 = item.BindVarList["f_res_am_start_hhmm6"].VarValue;
        //                        updateRes0102Args.ResAmStartHhmm7 = item.BindVarList["f_res_am_start_hhmm7"].VarValue;
        //                        updateRes0102Args.ResAmEndHhmm1 = item.BindVarList["f_res_am_end_hhmm1"].VarValue;
        //                        updateRes0102Args.ResAmEndHhmm2 = item.BindVarList["f_res_am_end_hhmm2"].VarValue;
        //                        updateRes0102Args.ResAmEndHhmm3 = item.BindVarList["f_res_am_end_hhmm3"].VarValue;
        //                        updateRes0102Args.ResAmEndHhmm4 = item.BindVarList["f_res_am_end_hhmm4"].VarValue;
        //                        updateRes0102Args.ResAmEndHhmm5 = item.BindVarList["f_res_am_end_hhmm5"].VarValue;
        //                        updateRes0102Args.ResAmEndHhmm6 = item.BindVarList["f_res_am_end_hhmm6"].VarValue;
        //                        updateRes0102Args.ResAmEndHhmm7 = item.BindVarList["f_res_am_end_hhmm7"].VarValue;
        //                        updateRes0102Args.ResPmStartHhmm1 = item.BindVarList["f_res_pm_start_hhmm1"].VarValue;
        //                        updateRes0102Args.ResPmStartHhmm2 = item.BindVarList["f_res_pm_start_hhmm2"].VarValue;
        //                        updateRes0102Args.ResPmStartHhmm3 = item.BindVarList["f_res_pm_start_hhmm3"].VarValue;
        //                        updateRes0102Args.ResPmStartHhmm4 = item.BindVarList["f_res_pm_start_hhmm4"].VarValue;
        //                        updateRes0102Args.ResPmStartHhmm5 = item.BindVarList["f_res_pm_start_hhmm5"].VarValue;
        //                        updateRes0102Args.ResPmStartHhmm6 = item.BindVarList["f_res_pm_start_hhmm6"].VarValue;
        //                        updateRes0102Args.ResPmStartHhmm7 = item.BindVarList["f_res_pm_start_hhmm7"].VarValue;
        //                        updateRes0102Args.ResPmEndHhmm1 = item.BindVarList["f_res_pm_end_hhmm1"].VarValue;
        //                        updateRes0102Args.ResPmEndHhmm2 = item.BindVarList["f_res_pm_end_hhmm2"].VarValue;
        //                        updateRes0102Args.ResPmEndHhmm3 = item.BindVarList["f_res_pm_end_hhmm3"].VarValue;
        //                        updateRes0102Args.ResPmEndHhmm4 = item.BindVarList["f_res_pm_end_hhmm4"].VarValue;
        //                        updateRes0102Args.ResPmEndHhmm5 = item.BindVarList["f_res_pm_end_hhmm5"].VarValue;
        //                        updateRes0102Args.ResPmEndHhmm6 = item.BindVarList["f_res_pm_end_hhmm6"].VarValue;
        //                        updateRes0102Args.ResPmEndHhmm7 = item.BindVarList["f_res_pm_end_hhmm7"].VarValue;
        //                        updateRes0102Args.DocResLimit = item.BindVarList["f_doc_res_limit"].VarValue;
        //                        updateRes0102Args.EtcResLimit = item.BindVarList["f_etc_res_limit"].VarValue;
        //                        updateRes0102Args.EndDate = item.BindVarList["f_end_date"].VarValue;
        //                        updateRes0102Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        updateRes0102Args.StartDate = item.BindVarList["f_start_date"].VarValue;

        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00UpdateRES0102Req2Args>(
        //                                updateRes0102Args);
        //                        break;

        //                    case DataRowState.Deleted:

        //                        NuroRES0102U00UpdateRES0102Req3Args updateRes0102Args3 =
        //                            new NuroRES0102U00UpdateRES0102Req3Args();
        //                        updateRes0102Args3.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        updateRes0102Args3.StartDate = item.BindVarList["f_start_date"].VarValue;
        //                        updateRes0102Args3.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00UpdateRES0102Req3Args>(
        //                                updateRes0102Args3);


        //                        NuroRES0102U00DeleteRES0102Req2Args deleteRes0102Args2 =
        //                            new NuroRES0102U00DeleteRES0102Req2Args();
        //                        deleteRes0102Args2.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        deleteRes0102Args2.StartDate = item.BindVarList["f_start_date"].VarValue;
        //                        deleteRes0102Args2.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00DeleteRES0102Req2Args>(
        //                                deleteRes0102Args2);
        //                        break;
        //                }

        //                break;

        //            case '2':
        //                switch (item.RowState)
        //                {
        //                    case DataRowState.Added:
        //                        /* 중복체크*/

        //                        NuroRES0102U00CheckDoctorReq2Args checkDoctorRequest2 =
        //                            new NuroRES0102U00CheckDoctorReq2Args();
        //                        checkDoctorRequest2.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        checkDoctorRequest2.StartDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        checkDoctorRequest2.HospCode = parent.mHospCode;

        //                        NuroRES0102U00CheckDoctorResult res =
        //                            CloudService.Instance
        //                                .Submit<NuroRES0102U00CheckDoctorResult, NuroRES0102U00CheckDoctorReq2Args>(
        //                                    checkDoctorRequest2);

        //                        if (res != null)
        //                            t_chk = res.Check;

        //                        if (!TypeCheck.IsNull(t_chk) && t_chk.ToString().Equals("Y"))
        //                        {
        //                            parent.mErrMsg = Resource.MSG026_0_MSG +
        //                                             item.BindVarList["f_jinryo_pre_date"].VarValue +
        //                                             Resource.MSG026_MSG;
        //                            return false;
        //                        }

        //                        NuroRES0102U00InsertRES0103Req1Args insertRes0103Req1Args =
        //                            new NuroRES0102U00InsertRES0103Req1Args();
        //                        insertRes0103Req1Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        insertRes0103Req1Args.UserId = item.BindVarList["q_user_id"].VarValue;
        //                        insertRes0103Req1Args.AmStartHhmm = item.BindVarList["f_am_start_hhmm"].VarValue;
        //                        insertRes0103Req1Args.PmStartHhmm = item.BindVarList["f_pm_start_hhmm"].VarValue;
        //                        insertRes0103Req1Args.Remark = item.BindVarList["f_remark"].VarValue;
        //                        insertRes0103Req1Args.AmEndHhmm = item.BindVarList["f_am_end_hhmm"].VarValue;
        //                        insertRes0103Req1Args.PmEndHhmm = item.BindVarList["f_pm_end_hhmm"].VarValue;
        //                        insertRes0103Req1Args.AmGwaRoom = item.BindVarList["f_am_gwa_room"].VarValue;
        //                        insertRes0103Req1Args.JinryoPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        insertRes0103Req1Args.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00InsertRES0103Req1Args>(
        //                                insertRes0103Req1Args);
        //                        break;

        //                    case DataRowState.Modified:

        //                        NuroRES0102U00UpdateRES0103Req1Args updateRes0103Req1Args =
        //                            new NuroRES0102U00UpdateRES0103Req1Args();
        //                        updateRes0103Req1Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        updateRes0103Req1Args.UserId = item.BindVarList["q_user_id"].VarValue;
        //                        updateRes0103Req1Args.AmStartHhmm = item.BindVarList["f_am_start_hhmm"].VarValue;
        //                        updateRes0103Req1Args.PmStartHhmm = item.BindVarList["f_pm_start_hhmm"].VarValue;
        //                        updateRes0103Req1Args.Remark = item.BindVarList["f_remark"].VarValue;
        //                        updateRes0103Req1Args.AmEndHhmm = item.BindVarList["f_am_end_hhmm"].VarValue;
        //                        updateRes0103Req1Args.PmEndHhmm = item.BindVarList["f_pm_end_hhmm"].VarValue;
        //                        updateRes0103Req1Args.AmGwaRoom = item.BindVarList["f_am_gwa_room"].VarValue;
        //                        updateRes0103Req1Args.JinryoPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        updateRes0103Req1Args.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00UpdateRES0103Req1Args>(
        //                                updateRes0103Req1Args);

        //                        break;

        //                    case DataRowState.Deleted:

        //                        NuroRES0102U00DeleteRES0103Req1Args deleteRes0103Req1Args =
        //                            new NuroRES0102U00DeleteRES0103Req1Args();
        //                        deleteRes0103Req1Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        deleteRes0103Req1Args.JinryoPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        deleteRes0103Req1Args.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00DeleteRES0103Req1Args>(
        //                                deleteRes0103Req1Args);
        //                        break;
        //                }

        //                break;

        //            case '3':
        //                switch (item.RowState)
        //                {
        //                    case DataRowState.Added:
        //                        /* 중복체크*/
        //                        NuroRES0102U00CheckDoctorReq2Args checkDoctorRequest2 =
        //                            new NuroRES0102U00CheckDoctorReq2Args();
        //                        checkDoctorRequest2.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        checkDoctorRequest2.StartDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        checkDoctorRequest2.HospCode = parent.mHospCode;

        //                        NuroRES0102U00CheckDoctorResult res =
        //                            CloudService.Instance
        //                                .Submit<NuroRES0102U00CheckDoctorResult, NuroRES0102U00CheckDoctorReq2Args>(
        //                                    checkDoctorRequest2);

        //                        if (res != null)
        //                            t_chk = res.Check;

        //                        if (!TypeCheck.IsNull(t_chk) && t_chk.ToString().Equals("Y"))
        //                        {
        //                            parent.mErrMsg = "[" + item.BindVarList["f_jinryo_pre_date"].VarValue +
        //                                             Resource.MSG026_MSG;
        //                            return false;
        //                        }


        //                        NuroRES0102U00InsertRES0103Req2Args insertRes0103Req2Args =
        //                            new NuroRES0102U00InsertRES0103Req2Args();

        //                        insertRes0103Req2Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        insertRes0103Req2Args.UserId = item.BindVarList["q_user_id"].VarValue;
        //                        insertRes0103Req2Args.ResAmStartHhmm = item.BindVarList["f_res_am_start_hhmm"].VarValue;
        //                        insertRes0103Req2Args.ResPmStartHhmm = item.BindVarList["f_res_pm_start_hhmm"].VarValue;
        //                        insertRes0103Req2Args.Remark = item.BindVarList["f_remark"].VarValue;
        //                        insertRes0103Req2Args.ResAmEndHhmm = item.BindVarList["f_res_am_end_hhmm"].VarValue;
        //                        insertRes0103Req2Args.ResPmEndHhmm = item.BindVarList["f_res_pm_end_hhmm"].VarValue;
        //                        insertRes0103Req2Args.JinryoPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        insertRes0103Req2Args.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00InsertRES0103Req2Args>(
        //                                insertRes0103Req2Args);
        //                        break;

        //                    case DataRowState.Modified:

        //                        NuroRES0102U00UpdateRES0103Req2Args updateRes0103Req2Args =
        //                            new NuroRES0102U00UpdateRES0103Req2Args();
        //                        updateRes0103Req2Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        updateRes0103Req2Args.UserId = item.BindVarList["q_user_id"].VarValue;
        //                        updateRes0103Req2Args.ResAmStartHhmm = item.BindVarList["f_res_am_start_hhmm"].VarValue;
        //                        updateRes0103Req2Args.ResAmEndHhmm = item.BindVarList["f_res_am_end_hhmm"].VarValue;
        //                        updateRes0103Req2Args.Remark = item.BindVarList["f_remark"].VarValue;
        //                        updateRes0103Req2Args.ResPmStartHhmm = item.BindVarList["f_res_pm_start_hhmm"].VarValue;
        //                        updateRes0103Req2Args.ResPmEndHhmm = item.BindVarList["f_res_pm_end_hhmm"].VarValue;
        //                        updateRes0103Req2Args.JinryoPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        updateRes0103Req2Args.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00UpdateRES0103Req2Args>(
        //                                updateRes0103Req2Args);
        //                        break;

        //                    case DataRowState.Deleted:

        //                        NuroRES0102U00DeleteRES0103Req2Args deleteRes0103Req2Args =
        //                            new NuroRES0102U00DeleteRES0103Req2Args();
        //                        deleteRes0103Req2Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        deleteRes0103Req2Args.JinryoPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        deleteRes0103Req2Args.HospCode = parent.mHospCode;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00DeleteRES0103Req2Args>(
        //                                deleteRes0103Req2Args);
        //                        break;
        //                }

        //                break;

        //            case '4':
        //                switch (item.RowState)
        //                {
        //                    case DataRowState.Added:

        //                        /* 중복체크 */
        //                        NuroRES0102U00CheckDoctorReq3Args checkDoctorRequest3 =
        //                            new NuroRES0102U00CheckDoctorReq3Args();
        //                        checkDoctorRequest3.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        checkDoctorRequest3.StartDate = item.BindVarList["f_start_date"].VarValue;

        //                        NuroRES0102U00CheckDoctorResult res =
        //                            CloudService.Instance
        //                                .Submit<NuroRES0102U00CheckDoctorResult, NuroRES0102U00CheckDoctorReq3Args>(
        //                                    checkDoctorRequest3);

        //                        if (res != null)
        //                            t_chk = res.Check;


        //                        if (!TypeCheck.IsNull(t_chk) && t_chk.ToString().Equals("Y"))
        //                        {
        //                            parent.mErrMsg = Resource.MSG027_0_MSG + item.BindVarList["f_start_date"].VarValue +
        //                                             Resource.MSG027_MSG;
        //                            return false;
        //                        }

        //                        NuroRES0102U00InsertRES0104Args insertRes0104Args =
        //                            new NuroRES0102U00InsertRES0104Args();
        //                        insertRes0104Args.UserId = item.BindVarList["q_user_id"].VarValue;
        //                        insertRes0104Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        insertRes0104Args.StartDate = item.BindVarList["f_start_date"].VarValue;
        //                        insertRes0104Args.EndDate = item.BindVarList["f_end_date"].VarValue;
        //                        insertRes0104Args.Sayu = item.BindVarList["f_sayu"].VarValue;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00InsertRES0104Args>(
        //                                insertRes0104Args);
        //                        break;

        //                    case DataRowState.Modified:

        //                        NuroRES0102U00UpdateRES0104Args updateRes0104Args =
        //                            new NuroRES0102U00UpdateRES0104Args();
        //                        updateRes0104Args.UserId = item.BindVarList["q_user_id"].VarValue;
        //                        updateRes0104Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        updateRes0104Args.StartDate = item.BindVarList["f_start_date"].VarValue;
        //                        updateRes0104Args.EndDate = item.BindVarList["f_end_date"].VarValue;
        //                        updateRes0104Args.Sayu = item.BindVarList["f_sayu"].VarValue;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00UpdateRES0104Args>(
        //                                updateRes0104Args);
        //                        break;

        //                    case DataRowState.Deleted:

        //                        NuroRES0102U00DeleteRES0104Args deleteRes0104Args =
        //                            new NuroRES0102U00DeleteRES0104Args();
        //                        deleteRes0104Args.Doctor = item.BindVarList["f_doctor"].VarValue;
        //                        deleteRes0104Args.StartDate = item.BindVarList["f_start_date"].VarValue;
        //                        updateResult =
        //                            CloudService.Instance.Submit<UpdateResult, NuroRES0102U00DeleteRES0104Args>(
        //                                deleteRes0104Args);
        //                        break;
        //                }

        //                break;
        //        }

        //        if (updateResult == null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return updateResult.Result;
        //        }

        //    }
        //}

        //#endregion

        private void xLabel60_Click(object sender, EventArgs e)
        {
            if (pnlList.Width == 0)
            {
                pnlList.Width = 200;
                pnlList.Dock = DockStyle.Left;
            }
            else
            {
                pnlList.Dock = DockStyle.None;
                pnlList.Width = 0;
            }
        }

        private void emkTime_DataValidating(object sender, DataValidatingEventArgs e)
        {
            XEditMask em = sender as XEditMask;
            XEditMask temp_em = null;

            string time1 = em.GetDataValue();
            string time2 = "";
            string time_name = "";
            string time_str = AM_END_TIME.ToString().Substring(0, 2) + ":" + AM_END_TIME.ToString().Substring(2, 2);

            if (time1 == "")
                return;

            if (em.Name.IndexOf("Am") > -1)
            {
                if (Convert.ToInt32(time1) > AM_END_TIME) //1300
                {
                    XMessageBox.Show(Resource.MSG008_MSG_1 + time_str + Resource.MSG008_MSG_2, Resource.MSG028_CAP,
                        MessageBoxIcon.Warning);
                    e.Cancel = true;
                }

                if (em.Name.IndexOf("start") > -1)
                {
                    time_name = em.Name.Replace("start", "end");

                    foreach (Control ctr in em.Parent.Controls)
                    {
                        if (ctr.Name == time_name)
                        {
                            temp_em = ctr as XEditMask;
                            time2 = temp_em.GetDataValue();
                            if (time2 != "")
                            {
                                if (Convert.ToInt32(time1) > Convert.ToInt32(time2))
                                {
                                    XMessageBox.Show(Resource.MSG029_MSG, Resource.MSG028_CAP, MessageBoxIcon.Warning);
                                    e.Cancel = true;
                                    return;
                                }
                            }
                        }
                    }
                }
                else if (em.Name.IndexOf("end") > -1)
                {
                    time_name = em.Name.Replace("end", "start");

                    foreach (Control ctr in em.Parent.Controls)
                    {
                        if (ctr.Name == time_name)
                        {
                            temp_em = ctr as XEditMask;
                            time2 = temp_em.GetDataValue();
                            if (time2 != "")
                            {
                                if (Convert.ToInt32(time1) < Convert.ToInt32(time2))
                                {
                                    XMessageBox.Show(Resource.MSG029_MSG, Resource.MSG028_CAP, MessageBoxIcon.Warning);
                                    e.Cancel = true;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            else if (em.Name.IndexOf("Pm") > -1)
            {
                if (Convert.ToInt32(time1) < AM_END_TIME) //1300
                {
                    XMessageBox.Show(Resource.MSG011_MSG_1 + time_str + Resource.MSG017_MSG_2, Resource.MSG028_CAP,
                        MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                if (em.Name.IndexOf("start") > -1)
                {
                    time_name = em.Name.Replace("start", "end");

                    foreach (Control ctr in em.Parent.Controls)
                    {
                        if (ctr.Name == time_name)
                        {
                            temp_em = ctr as XEditMask;
                            time2 = temp_em.GetDataValue();
                            if (time2 != "")
                            {
                                if (Convert.ToInt32(time1) > Convert.ToInt32(time2))
                                {
                                    XMessageBox.Show(Resource.MSG029_MSG, Resource.MSG028_CAP, MessageBoxIcon.Warning);
                                    e.Cancel = true;
                                    return;
                                }
                            }
                        }
                    }
                }
                else if (em.Name.IndexOf("end") > -1)
                {
                    time_name = em.Name.Replace("end", "start");

                    foreach (Control ctr in em.Parent.Controls)
                    {
                        if (ctr.Name == time_name)
                        {
                            temp_em = ctr as XEditMask;
                            time2 = temp_em.GetDataValue();
                            if (time2 != "")
                            {
                                if (Convert.ToInt32(time1) < Convert.ToInt32(time2))
                                {
                                    XMessageBox.Show(Resource.MSG029_MSG, Resource.MSG028_CAP, MessageBoxIcon.Warning);
                                    e.Cancel = true;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void fbxDoctor_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
                dbxDoctor_name.SetDataValue("");
        }

        private void RES0102U00_Closing(object sender, CancelEventArgs e)
        {
            if (!mIsSaveSuccess)
                e.Cancel = true;

            mIsSaveSuccess = true;
        }

        // 디폴트 시간으로 셋팅해주기
        private void btnMakeDefaultTime_Click(object sender, EventArgs e)
        {
            XPanel pan = null;

            if (rbtJinryo.Checked)
            {
                pan = pnlJinryo;
            }
            else
            {
                pan = pnlReser;
            }

            foreach (Control con in pan.Controls)
            {
                if (con.Name.IndexOf("emk") < 0)
                    continue;

                XEditMask emk = (XEditMask)con;
                emk.ResetData();
                string name = emk.Name.ToUpper();

                //일요일 제외
                if (name.IndexOf("hhmm1".ToUpper()) >= 0)
                    continue;

                if (name.IndexOf("am_start_hhmm".ToUpper()) >= 0)
                    emk.SetEditValue(AM_START_TIME.ToString().PadLeft(4, '0'));

                if (name.IndexOf("am_end_hhmm".ToUpper()) >= 0)
                    emk.SetEditValue(AM_END_TIME.ToString().PadLeft(4, '0'));

                //토요일 오후는 빼고
                if (name.IndexOf("hhmm7".ToUpper()) < 0)
                {
                    if (name.IndexOf("pm_start_hhmm".ToUpper()) >= 0)
                        emk.SetEditValue(PM_START_TIME.ToString().PadLeft(4, '0'));

                    if (name.IndexOf("pm_end_hhmm".ToUpper()) >= 0)
                        emk.SetEditValue(PM_END_TIME.ToString().PadLeft(4, '0'));
                }
                emk.AcceptData();
            }
        }

        // Connect cloud: get data for combo
        private void initializeComboListItem()
        {
            NuroRes0102u00InitCboListItemArgs args = new NuroRes0102u00InitCboListItemArgs();
            args.ComingDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            args.CodeType = "JUBSU_GUBUN";
            args.HospCode = mHospCode;
            cboListItemResult = CloudService.Instance.Submit<NuroRes0102u00InitCboListItemResult, NuroRes0102u00InitCboListItemArgs>(args);
        }

        private IList<object[]> createListDataForCombo(IList<ComboListItemInfo> lstComboDept)
        {
            IList<object[]> lstData = new List<object[]>();
            if (lstComboDept != null && lstComboDept.Count > 0)
            {
                foreach (ComboListItemInfo comboListItemInfo in lstComboDept)
                {
                    object[] obj = { comboListItemInfo.Code, comboListItemInfo.CodeName };
                    lstData.Add(obj);
                }
            }
            return lstData;
        }

        private NuroRES0102U00GetDataGridViewResult NuroRES0102U00GetDataGridView()
        {
            string doctor = cboDoctor.GetDataValue();
            string date = dpkApp_date.GetDataValue();
            if (String.IsNullOrEmpty(doctor))
            {
                return null;
            }
            NuroRES0102U00GetDataGridViewArgs args = new NuroRES0102U00GetDataGridViewArgs();
            args.Date = date;
            args.Doctor = doctor;
            args.HospCode = mHospCode;

            NuroRES0102U00GetDataGridViewResult result =
                CloudService.Instance.Submit<NuroRES0102U00GetDataGridViewResult, NuroRES0102U00GetDataGridViewArgs>(
                    args);

            return result;
        }

        private IList<object[]> CboAvgTimeExecuteQuery(BindVarCollection varList)
        {
            IList<object[]> lstObjectResult = new List<object[]>();

            if (cboListItemResult == null)
            {
                initializeComboListItem();
            }
            else
            {
                List<ComboListItemInfo> lstCboAvgTimeInfo = cboListItemResult.AvgTime;
                if (lstCboAvgTimeInfo != null && lstCboAvgTimeInfo.Count > 0)
                {
                    foreach (ComboListItemInfo time in lstCboAvgTimeInfo)
                    {
                        lstObjectResult.Add(new object[]
                        {
                            time.Code,
                            time.CodeName
                        });

                    }

                }
            }

            return lstObjectResult;
        }

        private IList<object[]> ChkHyujinExecuteQuery(BindVarCollection varList)
        {
            List<object[]> data = new List<object[]>();
            NuroRES0102U00ChkHyujinArgs args = new NuroRES0102U00ChkHyujinArgs();
            args.StartDate = varList["f_start_date"].VarValue;
            args.EndDate = varList["f_end_date"].VarValue;
            args.Doctor = varList["f_doctor"].VarValue;
            args.HospCode = mHospCode;

            NuroRES0102U00ChkHyujinResult res =
                CloudService.Instance.Submit<NuroRES0102U00ChkHyujinResult, NuroRES0102U00ChkHyujinArgs>(args);
            if (res != null)
            {
                data.Add(new object[]
                {
                    res.Check
                });
            }
            return data;
        }

        private IList<object[]> grdRES0103RExecuteQuery(BindVarCollection varList)
        {
            List<object[]> dataList = new List<object[]>();
            if (res0102U00GetDataGridViewResult == null)
            {
                return dataList;
            }
            IList<NuroRES0102U00GrdRES0103ResInfo> listItemInfos =
                res0102U00GetDataGridViewResult.DataGridRes0103ResInfo;
            if (listItemInfos == null || listItemInfos.Count == 0)
            {
                return dataList;
            }
            foreach (NuroRES0102U00GrdRES0103ResInfo resInfo in listItemInfos)
            {
                dataList.Add(new object[]
                {
                    resInfo.Doctor,
                    resInfo.JinryoPreDate,
                    resInfo.ResAmStartHhmm,
                    resInfo.ResAmEndHhmm,
                    resInfo.ResPmStartHhmm, 
                    resInfo.ResPmEndHhmm,
                    resInfo.Remark,
                    resInfo.AmGwaRoom,
                    resInfo.PmGwaRoom
                });
            }
            return dataList;
        }

        private IList<object[]> grdRES0103ExecuteQuery(BindVarCollection varlist)
        {
            List<object[]> dataList = new List<object[]>();
            if (res0102U00GetDataGridViewResult == null)
            {
                return dataList;
            }
            IList<NuroRES0102U00GrdRES0103Info> listItemInfos = res0102U00GetDataGridViewResult.DataGridRes0103Info;
            if (listItemInfos == null || listItemInfos.Count == 0)
            {
                return dataList;
            }
            foreach (NuroRES0102U00GrdRES0103Info item in listItemInfos)
            {
                dataList.Add(new object[]
                {
                    item.Doctor,
                    item.JinryoPreDate,
                    item.AmStartHhmm,
                    item.AmEndHhmm,
                    item.PmStartHhmm,
                    item.PmEndHhmm,
                    item.Remark,
                    item.AmGwaRoom,
                    item.PmGwaRoom
                });
            }
            return dataList;
        }

        private IList<object[]> grdRES0104ExecuteQuery(BindVarCollection varlist)
        {
            List<object[]> dataList = new List<object[]>();
            if (res0102U00GetDataGridViewResult == null)
            {
                return dataList;
            }
            IList<NuroRES0102U00GridDoctorInfo> listItemInfos = res0102U00GetDataGridViewResult.DataGridDoctorInfo;
            if (listItemInfos == null || listItemInfos.Count == 0)
            {
                return dataList;
            }
            foreach (NuroRES0102U00GridDoctorInfo item in listItemInfos)
            {
                dataList.Add(new object[]
                {
                    item.Doctor,
                    item.StartDate,
                    item.EndDate,
                    item.Sayu
                });
            }

            return dataList;
        }

        private IList<object[]> grdRES0102ExecuteQuery(BindVarCollection varList)
        {

            List<object[]> dataList = new List<object[]>();
            if (res0102U00GetDataGridViewResult == null)
            {
                return dataList;
            }

            IList<NuroRES0102U00GrdRES0102Info> listItemInfos = res0102U00GetDataGridViewResult.DataGridRes0102Info;
            if (listItemInfos == null || listItemInfos.Count == 0)
            {
                return dataList;
            }

            foreach (NuroRES0102U00GrdRES0102Info item in listItemInfos)
            {
                dataList.Add(new object[]
                {
                    item.Doctor,
                    item.Gwa,
                    item.StartDate,
                    item.AvgTime,
                    item.JinryoBreakYn,
                    item.AmStartHhmm1,
                    item.AmStartHhmm2,
                    item.AmStartHhmm3,
                    item.AmStartHhmm4,
                    item.AmStartHhmm5,
                    item.AmStartHhmm6,
                    item.AmStartHhmm7,
                    item.AmEndHhmm1,
                    item.AmEndHhmm2,
                    item.AmEndHhmm3,
                    item.AmEndHhmm4,
                    item.AmEndHhmm5,
                    item.AmEndHhmm6,
                    item.AmEndHhmm7,
                    item.PmStartHhmm1,
                    item.PmStartHhmm2,
                    item.PmStartHhmm3,
                    item.PmStartHhmm4,
                    item.PmStartHhmm5,
                    item.PmStartHhmm6,
                    item.PmStartHhmm7,
                    item.PmEndHhmm1,
                    item.PmEndHhmm2,
                    item.PmEndHhmm3,
                    item.PmEndHhmm4,
                    item.PmEndHhmm5,
                    item.PmEndHhmm6,
                    item.PmEndHhmm7,
                    item.AmGwaRoom1,
                    item.AmGwaRoom2,
                    item.AmGwaRoom3,
                    item.AmGwaRoom4,
                    item.AmGwaRoom5,
                    item.AmGwaRoom6,
                    item.AmGwaRoom7,
                    item.PmGwaRoom1,
                    item.PmGwaRoom2,
                    item.PmGwaRoom3,
                    item.PmGwaRoom4,
                    item.PmGwaRoom5,
                    item.PmGwaRoom6,
                    item.PmGwaRoom7,
                    item.ResAmStartHhmm1,
                    item.ResAmStartHhmm2,
                    item.ResAmStartHhmm3,
                    item.ResAmStartHhmm4,
                    item.ResAmStartHhmm5,
                    item.ResAmStartHhmm6,
                    item.ResAmStartHhmm7,
                    item.ResAmEndHhmm1,
                    item.ResAmEndHhmm2,
                    item.ResAmEndHhmm3,
                    item.ResAmEndHhmm4,
                    item.ResAmEndHhmm5,
                    item.ResAmEndHhmm6,
                    item.ResAmEndHhmm7,
                    item.ResPmStartHhmm1,
                    item.ResPmStartHhmm2,
                    item.ResPmStartHhmm3,
                    item.ResPmStartHhmm4,
                    item.ResPmStartHhmm5,
                    item.ResPmStartHhmm6,
                    item.ResPmStartHhmm7,
                    item.ResPmEndHhmm1,
                    item.ResPmEndHhmm2,
                    item.ResPmEndHhmm3,
                    item.ResPmEndHhmm4,
                    item.ResPmEndHhmm5,
                    item.ResPmEndHhmm6,
                    item.ResPmEndHhmm7,
                    item.DocResLimit,
                    item.EtcResLimit,
                    item.StartDate,
                    item.EndDate,
                    item.OutHospResLimit
                });
            }

            return dataList;
        }

        private List<NuroRES0102U00GrdRES0102Info> create_dataSaveGridRes0102()
        {
            List<NuroRES0102U00GrdRES0102Info> lstRes0102U00GrdRes0102Info = new List<NuroRES0102U00GrdRES0102Info>();
            for (int i = 0; i < this.grdRES0102.RowCount; i++)
            {
                if (this.grdRES0102.GetRowState(i) == DataRowState.Added || this.grdRES0102.GetRowState(i) == DataRowState.Modified)
                {
                    NuroRES0102U00GrdRES0102Info insertRes0102DataInfo = new NuroRES0102U00GrdRES0102Info();
                    insertRes0102DataInfo.AvgTime = this.grdRES0102.GetItemString(i, "avg_time");
                    insertRes0102DataInfo.JinryoBreakYn = this.grdRES0102.GetItemString(i, "jinryo_break_yn");
                    insertRes0102DataInfo.AmStartHhmm1 = this.grdRES0102.GetItemString(i, "am_start_hhmm1");
                    insertRes0102DataInfo.AmStartHhmm2 = this.grdRES0102.GetItemString(i, "am_start_hhmm2");
                    insertRes0102DataInfo.AmStartHhmm3 = this.grdRES0102.GetItemString(i, "am_start_hhmm3");
                    insertRes0102DataInfo.AmStartHhmm4 = this.grdRES0102.GetItemString(i, "am_start_hhmm4");
                    insertRes0102DataInfo.AmStartHhmm5 = this.grdRES0102.GetItemString(i, "am_start_hhmm5");
                    insertRes0102DataInfo.AmStartHhmm6 = this.grdRES0102.GetItemString(i, "am_start_hhmm6");
                    insertRes0102DataInfo.AmStartHhmm7 = this.grdRES0102.GetItemString(i, "am_start_hhmm7");
                    insertRes0102DataInfo.AmEndHhmm1 = this.grdRES0102.GetItemString(i, "am_end_hhmm1");
                    insertRes0102DataInfo.AmEndHhmm2 = this.grdRES0102.GetItemString(i, "am_end_hhmm2");
                    insertRes0102DataInfo.AmEndHhmm3 = this.grdRES0102.GetItemString(i, "am_end_hhmm3");
                    insertRes0102DataInfo.AmEndHhmm4 = this.grdRES0102.GetItemString(i, "am_end_hhmm4");
                    insertRes0102DataInfo.AmEndHhmm5 = this.grdRES0102.GetItemString(i, "am_end_hhmm5");
                    insertRes0102DataInfo.AmEndHhmm6 = this.grdRES0102.GetItemString(i, "am_end_hhmm6");
                    insertRes0102DataInfo.AmEndHhmm7 = this.grdRES0102.GetItemString(i, "am_end_hhmm7");
                    insertRes0102DataInfo.PmStartHhmm1 = this.grdRES0102.GetItemString(i, "pm_start_hhmm1");
                    insertRes0102DataInfo.PmStartHhmm2 = this.grdRES0102.GetItemString(i, "pm_start_hhmm2");
                    insertRes0102DataInfo.PmStartHhmm3 = this.grdRES0102.GetItemString(i, "pm_start_hhmm3");
                    insertRes0102DataInfo.PmStartHhmm4 = this.grdRES0102.GetItemString(i, "pm_start_hhmm4");
                    insertRes0102DataInfo.PmStartHhmm5 = this.grdRES0102.GetItemString(i, "pm_start_hhmm5");
                    insertRes0102DataInfo.PmStartHhmm6 = this.grdRES0102.GetItemString(i, "pm_start_hhmm6");
                    insertRes0102DataInfo.PmStartHhmm7 = this.grdRES0102.GetItemString(i, "pm_start_hhmm7");
                    insertRes0102DataInfo.PmEndHhmm1 = this.grdRES0102.GetItemString(i, "pm_end_hhmm1");
                    insertRes0102DataInfo.PmEndHhmm2 = this.grdRES0102.GetItemString(i, "pm_end_hhmm2");
                    insertRes0102DataInfo.PmEndHhmm3 = this.grdRES0102.GetItemString(i, "pm_end_hhmm3");
                    insertRes0102DataInfo.PmEndHhmm4 = this.grdRES0102.GetItemString(i, "pm_end_hhmm4");
                    insertRes0102DataInfo.PmEndHhmm5 = this.grdRES0102.GetItemString(i, "pm_end_hhmm5");
                    insertRes0102DataInfo.PmEndHhmm6 = this.grdRES0102.GetItemString(i, "pm_end_hhmm6");
                    insertRes0102DataInfo.PmEndHhmm7 = this.grdRES0102.GetItemString(i, "pm_end_hhmm7");
                    insertRes0102DataInfo.AmGwaRoom1 = this.grdRES0102.GetItemString(i, "am_gwa_room1");
                    insertRes0102DataInfo.AmGwaRoom2 = this.grdRES0102.GetItemString(i, "am_gwa_room2");
                    insertRes0102DataInfo.AmGwaRoom3 = this.grdRES0102.GetItemString(i, "am_gwa_room3");
                    insertRes0102DataInfo.AmGwaRoom4 = this.grdRES0102.GetItemString(i, "am_gwa_room4");
                    insertRes0102DataInfo.AmGwaRoom5 = this.grdRES0102.GetItemString(i, "am_gwa_room5");
                    insertRes0102DataInfo.AmGwaRoom6 = this.grdRES0102.GetItemString(i, "am_gwa_room6");
                    insertRes0102DataInfo.AmGwaRoom7 = this.grdRES0102.GetItemString(i, "am_gwa_room7");
                    insertRes0102DataInfo.PmGwaRoom1 = this.grdRES0102.GetItemString(i, "pm_gwa_room1");
                    insertRes0102DataInfo.PmGwaRoom2 = this.grdRES0102.GetItemString(i, "pm_gwa_room2");
                    insertRes0102DataInfo.PmGwaRoom3 = this.grdRES0102.GetItemString(i, "pm_gwa_room3");
                    insertRes0102DataInfo.PmGwaRoom4 = this.grdRES0102.GetItemString(i, "pm_gwa_room4");
                    insertRes0102DataInfo.PmGwaRoom5 = this.grdRES0102.GetItemString(i, "pm_gwa_room5");
                    insertRes0102DataInfo.PmGwaRoom6 = this.grdRES0102.GetItemString(i, "pm_gwa_room6");
                    insertRes0102DataInfo.PmGwaRoom7 = this.grdRES0102.GetItemString(i, "pm_gwa_room7");
                    insertRes0102DataInfo.ResAmStartHhmm1 = this.grdRES0102.GetItemString(i, "res_am_start_hhmm1");
                    insertRes0102DataInfo.ResAmStartHhmm2 = this.grdRES0102.GetItemString(i, "res_am_start_hhmm2");
                    insertRes0102DataInfo.ResAmStartHhmm3 = this.grdRES0102.GetItemString(i, "res_am_start_hhmm3");
                    insertRes0102DataInfo.ResAmStartHhmm4 = this.grdRES0102.GetItemString(i, "res_am_start_hhmm4");
                    insertRes0102DataInfo.ResAmStartHhmm5 = this.grdRES0102.GetItemString(i, "res_am_start_hhmm5");
                    insertRes0102DataInfo.ResAmStartHhmm6 = this.grdRES0102.GetItemString(i, "res_am_start_hhmm6");
                    insertRes0102DataInfo.ResAmStartHhmm7 = this.grdRES0102.GetItemString(i, "res_am_start_hhmm7");
                    insertRes0102DataInfo.ResAmEndHhmm1 = this.grdRES0102.GetItemString(i, "res_am_end_hhmm1");
                    insertRes0102DataInfo.ResAmEndHhmm2 = this.grdRES0102.GetItemString(i, "res_am_end_hhmm2");
                    insertRes0102DataInfo.ResAmEndHhmm3 = this.grdRES0102.GetItemString(i, "res_am_end_hhmm3");
                    insertRes0102DataInfo.ResAmEndHhmm4 = this.grdRES0102.GetItemString(i, "res_am_end_hhmm4");
                    insertRes0102DataInfo.ResAmEndHhmm5 = this.grdRES0102.GetItemString(i, "res_am_end_hhmm5");
                    insertRes0102DataInfo.ResAmEndHhmm6 = this.grdRES0102.GetItemString(i, "res_am_end_hhmm6");
                    insertRes0102DataInfo.ResAmEndHhmm7 = this.grdRES0102.GetItemString(i, "res_am_end_hhmm7");
                    insertRes0102DataInfo.ResPmStartHhmm1 = this.grdRES0102.GetItemString(i, "res_pm_start_hhmm1");
                    insertRes0102DataInfo.ResPmStartHhmm2 = this.grdRES0102.GetItemString(i, "res_pm_start_hhmm2");
                    insertRes0102DataInfo.ResPmStartHhmm3 = this.grdRES0102.GetItemString(i, "res_pm_start_hhmm3");
                    insertRes0102DataInfo.ResPmStartHhmm4 = this.grdRES0102.GetItemString(i, "res_pm_start_hhmm4");
                    insertRes0102DataInfo.ResPmStartHhmm5 = this.grdRES0102.GetItemString(i, "res_pm_start_hhmm5");
                    insertRes0102DataInfo.ResPmStartHhmm6 = this.grdRES0102.GetItemString(i, "res_pm_start_hhmm6");
                    insertRes0102DataInfo.ResPmStartHhmm7 = this.grdRES0102.GetItemString(i, "res_pm_start_hhmm7");
                    insertRes0102DataInfo.ResPmEndHhmm1 = this.grdRES0102.GetItemString(i, "res_pm_end_hhmm1");
                    insertRes0102DataInfo.ResPmEndHhmm2 = this.grdRES0102.GetItemString(i, "res_pm_end_hhmm2");
                    insertRes0102DataInfo.ResPmEndHhmm3 = this.grdRES0102.GetItemString(i, "res_pm_end_hhmm3");
                    insertRes0102DataInfo.ResPmEndHhmm4 = this.grdRES0102.GetItemString(i, "res_pm_end_hhmm4");
                    insertRes0102DataInfo.ResPmEndHhmm5 = this.grdRES0102.GetItemString(i, "res_pm_end_hhmm5");
                    insertRes0102DataInfo.ResPmEndHhmm6 = this.grdRES0102.GetItemString(i, "res_pm_end_hhmm6");
                    insertRes0102DataInfo.ResPmEndHhmm7 = this.grdRES0102.GetItemString(i, "res_pm_end_hhmm7");
                    insertRes0102DataInfo.DocResLimit = this.grdRES0102.GetItemString(i, "doc_res_limit");
                    insertRes0102DataInfo.EtcResLimit = this.grdRES0102.GetItemString(i, "etc_res_limit");
                    insertRes0102DataInfo.EndDate = this.grdRES0102.GetItemString(i, "end_date");
                    insertRes0102DataInfo.Doctor = this.grdRES0102.GetItemString(i, "doctor");                   
                    insertRes0102DataInfo.StartDate = this.grdRES0102.GetItemString(i, "start_date");
                    insertRes0102DataInfo.Gwa = this.grdRES0102.GetItemString(i, "gwa");
                    insertRes0102DataInfo.DataRowState = grdRES0102.GetRowState(i).ToString();
                    insertRes0102DataInfo.OutHospResLimit = grdRES0102.GetItemString(i, "out_hosp_res_limit");
                    lstRes0102U00GrdRes0102Info.Add(insertRes0102DataInfo);
                }
            }
            if (grdRES0102.DeletedRowTable != null && grdRES0102.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdRES0102.DeletedRowTable.Rows)
                {
                    NuroRES0102U00GrdRES0102Info insertRes0102DataInfo = new NuroRES0102U00GrdRES0102Info();
                    insertRes0102DataInfo.AvgTime = row["avg_time"].ToString();
                    insertRes0102DataInfo.JinryoBreakYn = row["jinryo_break_yn"].ToString();
                    insertRes0102DataInfo.AmStartHhmm1 = row["am_start_hhmm1"].ToString();
                    insertRes0102DataInfo.AmStartHhmm2 = row["am_start_hhmm2"].ToString();
                    insertRes0102DataInfo.AmStartHhmm3 = row["am_start_hhmm3"].ToString();
                    insertRes0102DataInfo.AmStartHhmm4 = row["am_start_hhmm4"].ToString();
                    insertRes0102DataInfo.AmStartHhmm5 = row["am_start_hhmm5"].ToString();
                    insertRes0102DataInfo.AmStartHhmm6 = row["am_start_hhmm6"].ToString();
                    insertRes0102DataInfo.AmStartHhmm7 = row["am_start_hhmm7"].ToString();
                    insertRes0102DataInfo.AmEndHhmm1 = row["am_end_hhmm1"].ToString();
                    insertRes0102DataInfo.AmEndHhmm2 = row["am_end_hhmm2"].ToString();
                    insertRes0102DataInfo.AmEndHhmm3 = row["am_end_hhmm3"].ToString();
                    insertRes0102DataInfo.AmEndHhmm4 = row["am_end_hhmm4"].ToString();
                    insertRes0102DataInfo.AmEndHhmm5 = row["am_end_hhmm5"].ToString();
                    insertRes0102DataInfo.AmEndHhmm6 = row["am_end_hhmm6"].ToString();
                    insertRes0102DataInfo.AmEndHhmm7 = row["am_end_hhmm7"].ToString();
                    insertRes0102DataInfo.PmStartHhmm1 = row["pm_start_hhmm1"].ToString();
                    insertRes0102DataInfo.PmStartHhmm2 = row["pm_start_hhmm2"].ToString();
                    insertRes0102DataInfo.PmStartHhmm3 = row["pm_start_hhmm3"].ToString();
                    insertRes0102DataInfo.PmStartHhmm4 = row["pm_start_hhmm4"].ToString();
                    insertRes0102DataInfo.PmStartHhmm5 = row["pm_start_hhmm5"].ToString();
                    insertRes0102DataInfo.PmStartHhmm6 = row["pm_start_hhmm6"].ToString();
                    insertRes0102DataInfo.PmStartHhmm7 = row["pm_start_hhmm7"].ToString();
                    insertRes0102DataInfo.PmEndHhmm1 = row["pm_end_hhmm1"].ToString();
                    insertRes0102DataInfo.PmEndHhmm2 = row["pm_end_hhmm2"].ToString();
                    insertRes0102DataInfo.PmEndHhmm3 = row["pm_end_hhmm3"].ToString();
                    insertRes0102DataInfo.PmEndHhmm4 = row["pm_end_hhmm4"].ToString();
                    insertRes0102DataInfo.PmEndHhmm5 = row["pm_end_hhmm5"].ToString();
                    insertRes0102DataInfo.PmEndHhmm6 = row["pm_end_hhmm6"].ToString();
                    insertRes0102DataInfo.PmEndHhmm7 = row["pm_end_hhmm7"].ToString();
                    insertRes0102DataInfo.AmGwaRoom1 = row["am_gwa_room1"].ToString();
                    insertRes0102DataInfo.AmGwaRoom2 = row["am_gwa_room2"].ToString();
                    insertRes0102DataInfo.AmGwaRoom3 = row["am_gwa_room3"].ToString();
                    insertRes0102DataInfo.AmGwaRoom4 = row["am_gwa_room4"].ToString();
                    insertRes0102DataInfo.AmGwaRoom5 = row["am_gwa_room5"].ToString();
                    insertRes0102DataInfo.AmGwaRoom6 = row["am_gwa_room6"].ToString();
                    insertRes0102DataInfo.AmGwaRoom7 = row["am_gwa_room7"].ToString();
                    insertRes0102DataInfo.PmGwaRoom1 = row["pm_gwa_room1"].ToString();
                    insertRes0102DataInfo.PmGwaRoom2 = row["pm_gwa_room2"].ToString();
                    insertRes0102DataInfo.PmGwaRoom3 = row["pm_gwa_room3"].ToString();
                    insertRes0102DataInfo.PmGwaRoom4 = row["pm_gwa_room4"].ToString();
                    insertRes0102DataInfo.PmGwaRoom5 = row["pm_gwa_room5"].ToString();
                    insertRes0102DataInfo.PmGwaRoom6 = row["pm_gwa_room6"].ToString();
                    insertRes0102DataInfo.PmGwaRoom7 = row["pm_gwa_room7"].ToString();
                    insertRes0102DataInfo.ResAmStartHhmm1 = row["res_am_start_hhmm1"].ToString();
                    insertRes0102DataInfo.ResAmStartHhmm2 = row["res_am_start_hhmm2"].ToString();
                    insertRes0102DataInfo.ResAmStartHhmm3 = row["res_am_start_hhmm3"].ToString();
                    insertRes0102DataInfo.ResAmStartHhmm4 = row["res_am_start_hhmm4"].ToString();
                    insertRes0102DataInfo.ResAmStartHhmm5 = row["res_am_start_hhmm5"].ToString();
                    insertRes0102DataInfo.ResAmStartHhmm6 = row["res_am_start_hhmm6"].ToString();
                    insertRes0102DataInfo.ResAmStartHhmm7 = row["res_am_start_hhmm7"].ToString();
                    insertRes0102DataInfo.ResAmEndHhmm1 = row["res_am_end_hhmm1"].ToString();
                    insertRes0102DataInfo.ResAmEndHhmm2 = row["res_am_end_hhmm2"].ToString();
                    insertRes0102DataInfo.ResAmEndHhmm3 = row["res_am_end_hhmm3"].ToString();
                    insertRes0102DataInfo.ResAmEndHhmm4 = row["res_am_end_hhmm4"].ToString();
                    insertRes0102DataInfo.ResAmEndHhmm5 = row["res_am_end_hhmm5"].ToString();
                    insertRes0102DataInfo.ResAmEndHhmm6 = row["res_am_end_hhmm6"].ToString();
                    insertRes0102DataInfo.ResAmEndHhmm7 = row["res_am_end_hhmm7"].ToString();
                    insertRes0102DataInfo.ResPmStartHhmm1 = row["res_pm_start_hhmm1"].ToString();
                    insertRes0102DataInfo.ResPmStartHhmm2 = row["res_pm_start_hhmm2"].ToString();
                    insertRes0102DataInfo.ResPmStartHhmm3 = row["res_pm_start_hhmm3"].ToString();
                    insertRes0102DataInfo.ResPmStartHhmm4 = row["res_pm_start_hhmm4"].ToString();
                    insertRes0102DataInfo.ResPmStartHhmm5 = row["res_pm_start_hhmm5"].ToString();
                    insertRes0102DataInfo.ResPmStartHhmm6 = row["res_pm_start_hhmm6"].ToString();
                    insertRes0102DataInfo.ResPmStartHhmm7 = row["res_pm_start_hhmm7"].ToString();
                    insertRes0102DataInfo.ResPmEndHhmm1 = row["res_pm_end_hhmm1"].ToString();
                    insertRes0102DataInfo.ResPmEndHhmm2 = row["res_pm_end_hhmm2"].ToString();
                    insertRes0102DataInfo.ResPmEndHhmm3 = row["res_pm_end_hhmm3"].ToString();
                    insertRes0102DataInfo.ResPmEndHhmm4 = row["res_pm_end_hhmm4"].ToString();
                    insertRes0102DataInfo.ResPmEndHhmm5 = row["res_pm_end_hhmm5"].ToString();
                    insertRes0102DataInfo.ResPmEndHhmm6 = row["res_pm_end_hhmm6"].ToString();
                    insertRes0102DataInfo.ResPmEndHhmm7 = row["res_pm_end_hhmm7"].ToString();
                    insertRes0102DataInfo.DocResLimit = row["doc_res_limit"].ToString();
                    insertRes0102DataInfo.EtcResLimit = row["etc_res_limit"].ToString();
                    insertRes0102DataInfo.EndDate = row["end_date"].ToString();
                    insertRes0102DataInfo.Doctor = row["doctor"].ToString();
                    insertRes0102DataInfo.StartDate = row["start_date"].ToString();
                    insertRes0102DataInfo.Gwa = row["gwa"].ToString();
                    insertRes0102DataInfo.DataRowState = DataRowState.Deleted.ToString();
                    insertRes0102DataInfo.OutHospResLimit = row["out_hosp_res_limit"].ToString();

                    lstRes0102U00GrdRes0102Info.Add(insertRes0102DataInfo);
                }

            }

            return lstRes0102U00GrdRes0102Info;
        }

        private List<NuroRES0102U00GrdRES0103Info> create_dataSaveGridRes0103()
        {
            List<NuroRES0102U00GrdRES0103Info> lstDataGrdRes0103Infos = new List<NuroRES0102U00GrdRES0103Info>();
            for (int i = 0; i < grdRES0103.RowCount; i++)
            {
                if (grdRES0103.GetRowState(i) == DataRowState.Added || grdRES0103.GetRowState(i) == DataRowState.Modified)
                {
                    NuroRES0102U00GrdRES0103Info grdRes0103Info = new NuroRES0102U00GrdRES0103Info();
                    grdRes0103Info.Doctor = grdRES0103.GetItemString(i, "doctor");
                    grdRes0103Info.AmStartHhmm = grdRES0103.GetItemString(i, "am_start_hhmm");
                    grdRes0103Info.PmStartHhmm = grdRES0103.GetItemString(i, "pm_start_hhmm");
                    grdRes0103Info.Remark = grdRES0103.GetItemString(i, "remark");
                    grdRes0103Info.AmEndHhmm = grdRES0103.GetItemString(i, "am_end_hhmm");
                    grdRes0103Info.PmEndHhmm = grdRES0103.GetItemString(i, "pm_end_hhmm");
                    grdRes0103Info.AmGwaRoom = grdRES0103.GetItemString(i, "am_gwa_room");
                    grdRes0103Info.JinryoPreDate = grdRES0103.GetItemString(i, "jinryo_pre_date");
                    grdRes0103Info.DataRowState = grdRES0103.GetRowState(i).ToString();

                    lstDataGrdRes0103Infos.Add(grdRes0103Info);
                }
            }
            if (grdRES0103.DeletedRowTable != null && grdRES0103.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdRES0103.DeletedRowTable.Rows)
                {
                    NuroRES0102U00GrdRES0103Info grdRes0103Info = new NuroRES0102U00GrdRES0103Info();
                    grdRes0103Info.Doctor = row["doctor"].ToString();
                    grdRes0103Info.AmStartHhmm = row["am_start_hhmm"].ToString();
                    grdRes0103Info.PmStartHhmm = row["pm_start_hhmm"].ToString();
                    grdRes0103Info.Remark = row["remark"].ToString();
                    grdRes0103Info.AmEndHhmm = row["am_end_hhmm"].ToString();
                    grdRes0103Info.PmEndHhmm = row["pm_end_hhmm"].ToString();
                    grdRes0103Info.AmGwaRoom = row["am_gwa_room"].ToString();
                    grdRes0103Info.JinryoPreDate = row["jinryo_pre_date"].ToString();
                    grdRes0103Info.DataRowState = DataRowState.Deleted.ToString();

                    lstDataGrdRes0103Infos.Add(grdRes0103Info);
                }

            }

            return lstDataGrdRes0103Infos;
        }

        private List<NuroRES0102U00GrdRES0103ResInfo> create_dataSaveGridRes0103Res()
        {
            List<NuroRES0102U00GrdRES0103ResInfo> listGrdRes0103ResInfos = new List<NuroRES0102U00GrdRES0103ResInfo>();
            for (int i = 0; i < grdRES0103R.RowCount; i++)
            {
                if (grdRES0103R.GetRowState(i) == DataRowState.Added || grdRES0103R.GetRowState(i) == DataRowState.Modified)
                {
                    NuroRES0102U00GrdRES0103ResInfo grdRes0103ResInfo = new NuroRES0102U00GrdRES0103ResInfo();
                    grdRes0103ResInfo.Doctor = grdRES0103R.GetItemString(i, "doctor");
                    grdRes0103ResInfo.ResAmStartHhmm = grdRES0103R.GetItemString(i, "res_am_start_hhmm");
                    grdRes0103ResInfo.ResPmStartHhmm = grdRES0103R.GetItemString(i, "res_pm_start_hhmm");
                    grdRes0103ResInfo.Remark = grdRES0103R.GetItemString(i, "remark");
                    grdRes0103ResInfo.ResAmEndHhmm = grdRES0103R.GetItemString(i, "res_am_end_hhmm");
                    grdRes0103ResInfo.ResPmEndHhmm = grdRES0103R.GetItemString(i, "res_pm_end_hhmm");
                    grdRes0103ResInfo.JinryoPreDate = grdRES0103R.GetItemString(i, "jinryo_pre_date");
                    grdRes0103ResInfo.DataRowState = grdRES0103R.GetRowState(i).ToString();

                    listGrdRes0103ResInfos.Add(grdRes0103ResInfo);
                }

            }

            if (grdRES0103R.DeletedRowTable != null && grdRES0103R.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdRES0103R.DeletedRowTable.Rows)
                {
                    NuroRES0102U00GrdRES0103ResInfo grdRes0103ResInfo = new NuroRES0102U00GrdRES0103ResInfo();
                    grdRes0103ResInfo.Doctor = row["doctor"].ToString();
                    grdRes0103ResInfo.ResAmStartHhmm = row["res_am_start_hhmm"].ToString();
                    grdRes0103ResInfo.ResPmStartHhmm = row["res_pm_start_hhmm"].ToString();
                    grdRes0103ResInfo.Remark = row["remark"].ToString();
                    grdRes0103ResInfo.ResAmEndHhmm = row["res_am_end_hhmm"].ToString();
                    grdRes0103ResInfo.ResPmEndHhmm = row["res_pm_end_hhmm"].ToString();
                    grdRes0103ResInfo.JinryoPreDate = row["jinryo_pre_date"].ToString();
                    grdRes0103ResInfo.DataRowState = DataRowState.Deleted.ToString();

                    listGrdRes0103ResInfos.Add(grdRes0103ResInfo);
                }
            }
            return listGrdRes0103ResInfos;
        }

        private List<NuroRES0102U00GridDoctorInfo> create_dataSaveGridDoctor()
        {
            List<NuroRES0102U00GridDoctorInfo> lstGridDoctorInfos = new List<NuroRES0102U00GridDoctorInfo>();
            for (int i = 0; i < grdRES0104.RowCount; i++)
            {
                if (grdRES0104.GetRowState(i) == DataRowState.Added || grdRES0104.GetRowState(i) == DataRowState.Modified)
                {
                    NuroRES0102U00GridDoctorInfo gridDoctorInfo = new NuroRES0102U00GridDoctorInfo();
                    gridDoctorInfo.Doctor = grdRES0104.GetItemString(i, "doctor");
                    gridDoctorInfo.StartDate = grdRES0104.GetItemString(i, "start_date");
                    gridDoctorInfo.EndDate = grdRES0104.GetItemString(i, "end_date");
                    gridDoctorInfo.Sayu = grdRES0104.GetItemString(i, "sayu");
                    gridDoctorInfo.DataRowState = grdRES0104.GetRowState(i).ToString();

                    lstGridDoctorInfos.Add(gridDoctorInfo);
                }
            }

            if (grdRES0104.DeletedRowTable != null && grdRES0104.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdRES0104.DeletedRowTable.Rows)
                {
                    NuroRES0102U00GridDoctorInfo gridDoctorInfo = new NuroRES0102U00GridDoctorInfo();
                    gridDoctorInfo.Doctor = row["doctor"].ToString();
                    gridDoctorInfo.StartDate = row["start_date"].ToString();
                    gridDoctorInfo.EndDate = row["end_date"].ToString();
                    gridDoctorInfo.Sayu = row["sayu"].ToString();
                    gridDoctorInfo.DataRowState = DataRowState.Deleted.ToString();

                    lstGridDoctorInfos.Add(gridDoctorInfo);
                }
            }
            return lstGridDoctorInfos;
        }

        private void xHospBox1_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox1.HospCode;

            xButtonList1.PerformClick(FunctionType.Query);
            CreateCombo();
        }

        private void xHospBox1_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = xHospBox1.HospCode;

                xButtonList1.PerformClick(FunctionType.Query);
                CreateCombo();
            }
        }
      
        #region Add new feature Med 7353
        
        #endregion

    }

    #region Objects Class(PostCall 메소드 사용용)

    // PostCall 메소드 사용시 Argument로 Object 하나만 넘길수 있다. 두개이상 Argument가 필요한 경우 아래의 구조체를 사용하자
    public class Objects
    {
        public object obj1;
        public object obj2;
        public object obj3;
        public object obj4;
        public object obj5;
        public object obj6;
        public object obj7;

        public Objects(object aObj1, object aObj2)
        {
            obj1 = aObj1;
            obj2 = aObj2;
            obj3 = null;
            obj4 = null;
            obj5 = null;
        }

        public Objects(object aObj1, object aObj2, object aObj3)
        {
            obj1 = aObj1;
            obj2 = aObj2;
            obj3 = aObj3;
            obj4 = null;
            obj5 = null;
        }

        public Objects(object aObj1, object aObj2, object aObj3, object aObj4)
        {
            obj1 = aObj1;
            obj2 = aObj2;
            obj3 = aObj3;
            obj4 = aObj4;
            obj5 = null;
        }

        public Objects(object aObj1, object aObj2, object aObj3, object aObj4, object aObj5)
        {
            obj1 = aObj1;
            obj2 = aObj2;
            obj3 = aObj3;
            obj4 = aObj4;
            obj5 = aObj5;
        }

        public Objects(object aObj1, object aObj2, object aObj3, object aObj4, object aObj5, object aObj6)
        {
            obj1 = aObj1;
            obj2 = aObj2;
            obj3 = aObj3;
            obj4 = aObj4;
            obj5 = aObj5;
            obj6 = aObj6;
        }

        public Objects(object aObj1, object aObj2, object aObj3, object aObj4, object aObj5, object aObj6, object aObj7)
        {
            obj1 = aObj1;
            obj2 = aObj2;
            obj3 = aObj3;
            obj4 = aObj4;
            obj5 = aObj5;
            obj6 = aObj6;
            obj7 = aObj7;
        }
    }

    #endregion
}