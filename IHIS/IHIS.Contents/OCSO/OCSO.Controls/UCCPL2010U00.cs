#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.OCSO.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.OCSO
{
    /// <summary>
    /// CPL2010U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCCPL2010U00 : IHIS.Framework.XScreen
    {
        #region Fields & Properties

        private XPatientBox paBox = new XPatientBox();
        private XRadioButton rbxJubsu;
        private XRadioButton rbxMijubsu;
        private XDatePicker dtpOrderDate;
        private XDatePicker dtpOrderToDate;
        private XDisplayBox cbxActor;
        private string bunho;
        private string reserYn;
        private string emergencyYn;
        private string doctor;

        public string CbxActorText;
        public string CbxActorCode;

        public XRadioButton RbxJubsu
        {
            get { return rbxJubsu; }
            set { rbxJubsu = value; }
        }

        public XRadioButton RbxMijubsu
        {
            get { return rbxMijubsu; }
            set { rbxMijubsu = value; }
        }

        public XDatePicker DtpOrderDate
        {
            get { return dtpOrderDate; }
            set { dtpOrderDate = value; }
        }

        public XDatePicker DtpOrderToDate
        {
            get { return dtpOrderToDate; }
            set { dtpOrderToDate = value; }
        }

        public XDisplayBox CbxActor
        {
            get { return cbxActor; }
            set { cbxActor = value; }
        }

        public XMstGrid GrdOrder
        {
            get { return this.grdOrder; }
        }

        public XEditGrid GrdTube
        {
            get { return this.grdTube; }
        }

        public XMstGrid GrdSpecimen
        {
            get { return this.grdSpecimen; }
        }

        public string Bunho
        {
            get { return bunho; }
            set { bunho = value; }
        }

        public string ReserYn
        {
            get { return reserYn; }
            set { reserYn = value; }
        }

        public string EmergencyYn
        {
            get { return emergencyYn; }
            set { emergencyYn = value; }
        }

        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        #endregion

        //private String CACHE_ADM3200_FWKACTOR = "CPL2010U00.ADM3200.fwkActor";
        //private String CACHE_NUR0102_CBOTIME = "CPL2010U00.NUR0102.cboTime";
        //private String CACHE_ADM3200_CBXACTOR = "CPL2010U00.ADM3200.cbxActor";

        CPL2010U00SaveLayoutResult saveLayoutResult = new CPL2010U00SaveLayoutResult();

        //private bool firstOpen = true;
        public UCCPL2010U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            InitDataWindow();
            //Initialize cached data
            //fwkActor.ExecuteQuery = LoadDataFwkActor;
            //cboTime.ExecuteQuery = LoadDataCboTime;
            //cbxActor.ExecuteQuery = LoadDataCbxActor;

            ////Initialize ParamList
            //grdPaList.ParamList = new List<string>(new String[] { "f_hosp_code", "f_from_date", "f_to_date", "f_bunho" });
            grdOrder.ParamList = new List<string>(new String[] { "f_hosp_code", "f_from_date", "f_to_date", "f_bunho", "f_mijubsu", "f_reser_yn", "f_emergency_yn", "f_doctor" });
            grdTube.ParamList = new List<string>(new String[] { "f_hosp_code", "f_order_date", "f_order_time", "f_bunho" });
            grdSpecimen.ParamList = new List<string>(new String[]
            {
                "f_hosp_code", 	
                "f_order_date", 
                "f_bunho", 		
                "f_gwa", 			
                "f_order_time", 
                "f_doctor", 		
                "f_reser_date", 
                "f_jubsu_date", 
                "f_jubsu_time", 
                "f_jubsuja", 		
                "f_group_ser", 	
                "f_reser_yn", 		
                "f_emergency_yn"
                
            });
            mlayConstantInfo.ParamList = new List<string>(new String[] { "f_code_type" });
            layPrintName.ParamList = new List<string>(new String[] { "f_ip_addr" });
            layBarcodeTemp2.ParamList = new List<string>(new String[] { "f_hosp_code", "f_specimen_ser" });
            vsvPa.ParamList = new List<string>(new String[] { "f_bunho" });
            layChkNames.ParamList = new List<string>(new String[] { "f_bunho", "f_reser_date" });

            //Initialize control for Cloud service
            //grdPaList.ExecuteQuery = LoadDataGrdPaList;
            grdOrder.ExecuteQuery = LoadDataGrdOrder;
            grdTube.ExecuteQuery = LoadDataGrdTube;
            grdSpecimen.ExecuteQuery = LoadDataGrdSpecimen;
            mlayConstantInfo.ExecuteQuery = LoadDataMLayConstantInfo;
            layPrintName.ExecuteQuery = LoadDataLayPrintName;
            layBarcodeTemp2.ExecuteQuery = LoadDataLayBarcodetemp2;
            layBarcodeTemp.ExecuteQuery = LoadDataLayBarcodetemp;
            vsvPa.ExecuteQuery = LoadDataVsvPa;
            layChkNames.ExecuteQuery = LoadDataLayChkNames;

            //sub-task MED-9280
            string sysDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            //this.dtpOrderDate.SetDataValue(sysDate);
            //this.dtpOrderToDate.SetDataValue(sysDate);
            //cbxActor.SetDictDDLB();
            //cboTime.SetDictDDLB();
        }

        #region Load data from Cloud

        private List<object[]> LoadDataVsvPa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00VsvPaArgs args = new CPL2010U00VsvPaArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            CPL2010U00VsvPaResult result = CloudService.Instance.Submit<CPL2010U00VsvPaResult, CPL2010U00VsvPaArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.SuName
                });
            }
            return res;
        }



        private List<object[]> LoadDataLayChkNames(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00LayChkNamesArgs args = new CPL2010U00LayChkNamesArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.ReserDate = bc["f_reser_date"] != null ? bc["f_reser_date"].VarValue : "";
            CPL2010U00LayChkNamesResult result = CloudService.Instance.Submit<CPL2010U00LayChkNamesResult, CPL2010U00LayChkNamesArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00LayChkNameListItemInfo item in result.LayChkNamesList)
                {
                    object[] objects = 
				{ 
					item.Suname, 
					item.OrderDate1, 
					item.OrderDate2, 
					item.CodeName
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataLayBarcodetemp(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            List<CPL2010U00LayBarcodeTempListItemInfo> layList = saveLayoutResult.LayBarcodeTempList;
            if (layList != null && layList.Count > 0)
            {
                foreach (CPL2010U00LayBarcodeTempListItemInfo item in layList)
                {
                    object[] objects = 
				{ 
					item.JundalGubun, 
					item.JundalGubunName, 
					item.SpecimenCode, 
					item.SpecimenName, 
					item.TubeCode, 
					item.TubeName, 
					item.InOutGubun, 
					item.SpecimenSer, 
					item.Bunho, 
					item.Suname, 
					item.GwaName, 
					item.DangerYn, 
					item.SpecimenSerBa, 
					item.JangbiCode, 
					item.JangbiName, 
					item.GumsaNameRe, 
					item.TubeCount, 
					item.TubeMaxAmt, 
					item.TubeNumbering
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataLayBarcodetemp2(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00LayBarcodeTemp2Args args = new CPL2010U00LayBarcodeTemp2Args();
            args.SpecimentSer = bc["f_specimen_ser"] != null ? bc["f_specimen_ser"].VarValue : "";
            CPL2010U00LayBarcodeTemp2Result result = CloudService.Instance.Submit<CPL2010U00LayBarcodeTemp2Result, CPL2010U00LayBarcodeTemp2Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00LayBarcodeTempListItemInfo item in result.LayList)
                {
                    object[] objects = 
				{ 
					item.JundalGubun, 
					item.JundalGubunName, 
					item.SpecimenCode, 
					item.SpecimenName, 
					item.TubeCode, 
					item.TubeName, 
					item.InOutGubun, 
					item.SpecimenSer, 
					item.Bunho, 
					item.Suname, 
					item.GwaName, 
					item.DangerYn, 
					item.SpecimenSerBa, 
					item.JangbiCode, 
					item.JangbiName, 
					item.GumsaNameRe, 
					item.TubeCount, 
					item.TubeMaxAmt, 
					item.TubeNumbering
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataLayPrintName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00LayPrintNameArgs args = new CPL2010U00LayPrintNameArgs();
            args.IpAddress = bc["f_ip_addr"] != null ? bc["f_ip_addr"].VarValue : "";
            CPL2010U00LayPrintNameResult result = CloudService.Instance.Submit<CPL2010U00LayPrintNameResult, CPL2010U00LayPrintNameArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.PrintName
                });
            }
            return res;
        }



        private List<object[]> LoadDataMLayConstantInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00MlayConstantInfoArgs args = new CPL2010U00MlayConstantInfoArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            CPL2010U00MlayConstantInfoResult result = CloudService.Instance.Submit<CPL2010U00MlayConstantInfoResult, CPL2010U00MlayConstantInfoArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00MlayConstantInfoListItemInfo item in result.MLayConstantInfoList)
                {
                    object[] objects = 
				{ 
					item.Code, 
					item.CodeName, 
					item.CodeValue
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataGrdSpecimen(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            if (TypeCheck.IsNull(bc["f_bunho"].VarValue)) return res;

            CPL2010U00GrdSpecimenArgs args = new CPL2010U00GrdSpecimenArgs();
            args.MJubsuYn = this.rbxMijubsu.Checked ? "2" : "3";
            args.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            args.OrderTime = bc["f_order_time"] != null ? bc["f_order_time"].VarValue : "";
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.ReserDate = bc["f_reser_date"] != null ? bc["f_reser_date"].VarValue : "";
            args.JubsuDate = bc["f_jubsu_date"] != null ? bc["f_jubsu_date"].VarValue : "";
            args.JubsuTime = bc["f_jubsu_time"] != null ? bc["f_jubsu_time"].VarValue : "";
            args.Jubsuja = bc["f_jubsuja"] != null ? bc["f_jubsuja"].VarValue : "";
            args.GroupSer = bc["f_group_ser"] != null ? bc["f_group_ser"].VarValue : "";
            args.ReserYn = bc["f_reser_yn"] != null ? bc["f_reser_yn"].VarValue : "";
            args.EmergencyYn = bc["f_emergency_yn"] != null ? bc["f_emergency_yn"].VarValue : "";
            CPL2010U00GrdSpecimenResult result = CloudService.Instance.Submit<CPL2010U00GrdSpecimenResult, CPL2010U00GrdSpecimenArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00GrdSpecimenListItemInfo item in result.GrdSpecimenList)
                {
                    object[] objects = 
				{ 
					item.Pkcpl2010, 
					item.SunabYn, 
					item.JubsuFlag, 
					item.SlipName, 
					item.HangmogCode, 
					item.GumsaName, 
					item.SpecimenCode, 
					item.SpecimenName, 
					item.Emergency, 
					item.TubeCode, 
					item.TubeName, 
					item.SpecimenSer, 
					item.CommentJuCode, 
					item.Fkocs1003, 
					item.GroupGubun, 
					item.PartJubsuFlag, 
					item.GumJubsuFlag, 
					item.Dummy, 
					item.ModifyYn, 
					item.ModifyYn1, 
					item.JundalGubun, 
					item.JundalGubunName, 
					item.Jubsuja, 
					item.OrderDate, 
					item.Bunho, 
					item.JubsuDate, 
					item.JubsuTime, 
					item.OrderTime, 
					item.GroupHangmog, 
					item.SpcialName, 
					item.CanYn, 
					item.Barcode, 
					item.BarcodeName, 
					item.DocComment, 
					item.UitakCode, 
					item.MiddleResult, 
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataGrdTube(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            if (TypeCheck.IsNull(bc["f_bunho"].VarValue)) return res;

            CPL2010U00GrdTubeQueryStartingArgs args = new CPL2010U00GrdTubeQueryStartingArgs();
            args.RbxJubsuChecked = this.rbxJubsu.Checked;
            args.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            args.OrderTime = bc["f_order_time"] != null ? bc["f_order_time"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            CPL2010U00GrdTubeQueryStartingResult result = CloudService.Instance.Submit<CPL2010U00GrdTubeQueryStartingResult, CPL2010U00GrdTubeQueryStartingArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00GrdTubeListItemInfo item in result.GrdTubeList)
                {
                    object[] objects = 
				{ 
					item.TubeCode, 
					item.TubeName, 
					item.Cnt
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataGrdOrder(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            if (TypeCheck.IsNull(bc["f_bunho"].VarValue)) return res;

            CPL2010U00GrdOrderArgs args = new CPL2010U00GrdOrderArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.Mijubsu = bc["f_mijubsu"] != null ? bc["f_mijubsu"].VarValue : "";
            args.ReserYn = bc["f_reser_yn"] != null ? bc["f_reser_yn"].VarValue : "";
            args.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            args.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.EmergencyYn = bc["f_emergency_yn"] != null ? bc["f_emergency_yn"].VarValue : "";
            CPL2010U00GrdOrderResult result = CloudService.Instance.Submit<CPL2010U00GrdOrderResult, CPL2010U00GrdOrderArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00GrdOrderListItemInfo item in result.GrdOrderList)
                {
                    object[] objects = 
				{ 
					item.OrderDate, 
					item.OrderTime, 
					item.GwaName, 
					item.InOutGubun, 
					item.DoctorName, 
					item.JubsuDate, 
					item.JubsuTime, 
					item.AfterActYn, 
					item.Bunho, 
					item.Gwa, 
					item.Gubun, 
					item.Doctor, 
					item.ReserDate, 
					item.Jubsuja, 
					item.JubsujaName, 
					item.GroupSer,
                    item.IfDataSendYn
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataGrdPaList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00GrdPaListArgs args = new CPL2010U00GrdPaListArgs();
            args.RbxJubsuChecked = this.rbxJubsu.Checked;
            args.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            args.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            CPL2010U00GrdPaListResult result = CloudService.Instance.Submit<CPL2010U00GrdPaListResult, CPL2010U00GrdPaListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00GrdPaListItemInfo item in result.GrdPalistList)
                {
                    object[] objects = 
				{ 
                    item.TrialYn,
					item.Bunho, 
					item.Suname, 
					item.InOutGubun, 
					item.GwaName, 
					item.ReserYn, 
					item.Doctor, 
					item.DoctorName, 
					item.KijunDate, 
					item.EmergencyYn, 
					item.NaewonTime
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private IList<object[]> LoadDataCbxActor(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboADM3200CbxActorArgs args = new ComboADM3200CbxActorArgs();
            //ComboResult result = CacheService.Instance.Get<ComboADM3200CbxActorArgs, ComboResult>(CACHE_ADM3200_CBXACTOR,
            //    args, delegate(ComboResult cboResult)
            //    {
            //        return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
            //               cboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<ComboADM3200CbxActorArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
	                {
	                    info.Code,
	                    info.CodeName
	                });
                }
            }

            return dataList;
        }

        private IList<object[]> LoadDataCboTime(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboNUR0102CboTimeArgs args = new ComboNUR0102CboTimeArgs();
            //ComboResult result = CacheService.Instance.Get<ComboNUR0102CboTimeArgs, ComboResult>(CACHE_NUR0102_CBOTIME,
            //    args, delegate(ComboResult cboResult)
            //    {
            //        return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
            //               cboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<ComboNUR0102CboTimeArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
	                {
	                    info.Code,
	                    info.CodeName
	                });
                }
            }

            return dataList;
        }

        private IList<object[]> LoadDataFwkActor(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboADM3200FwkActorArgs args = new ComboADM3200FwkActorArgs();
            //ComboResult result = CacheService.Instance.Get<ComboADM3200FwkActorArgs, ComboResult>(CACHE_ADM3200_FWKACTOR,
            //    args, delegate(ComboResult cboResult)
            //    {
            //        return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
            //               cboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<ComboADM3200FwkActorArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
	                {
	                    info.Code,
	                    info.CodeName
	                });
                }
            }

            return dataList;
        }

        #endregion

        //private int mHeight = 110;

        #region vsvJubsuja_PreServiceCall
        private void vsvJubsuja_QueryStarting(object sender, CancelEventArgs e)
        {
            this.vsvJubsuja.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        #region Screen 변수

        private int QueryTime;
        private int TimeVal;

        // 自動照会使用可否フラグ
        private string useTimeChkYN = "Y";

        // 受付チェックボックス一括適用フラグ
        private string chkAllJubsuYN = "Y";


        // 患者有AlarmファイルPATH
        private string alarmFilePath_CPL = "";
        private string alarmFilePath_CPL_EM = "";
        private string useAlarmChkYN = "";

        #endregion

        #region OnLoad
        string mJubsu_yn = "";
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void PostLoad()
        {
            string btn_autoQuery_yn = null;
            string btn_autoAlarm_yn = null;

            // 注射画面コントロールデータ照会
            //            this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
            //                                                 FROM CPL0109
            //                                                WHERE HOSP_CODE = :f_hosp_code
            //                                                  AND CODE_TYPE = 'CPL_CONSTANT'
            //                                                ORDER BY CODE";

            this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            //tungtx
            this.mlayConstantInfo.SetBindVarValue("f_code_type", "CPL_CONSTANT");

            if (this.mlayConstantInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoQuery_yn")) btn_autoQuery_yn = this.mlayConstantInfo.GetItemString(i, "code_value");
                }

                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoAlarm_yn"))
                    {
                        btn_autoAlarm_yn = mlayConstantInfo.GetItemString(i, "code_value");

                        // AlarmファイルPATH取得
                        //                        this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                        //                                                 FROM CPL0109
                        //                                                WHERE HOSP_CODE = 'K01'
                        //                                                  AND CODE_TYPE = 'CPL_ALARM'
                        //                                                ORDER BY CODE";

                        this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        this.mlayConstantInfo.SetBindVarValue("f_code_type", "CPL_ALARM");

                        //query one more time
                        if (this.mlayConstantInfo.QueryLayout(true))
                        {
                            for (int k = 0; k < this.mlayConstantInfo.RowCount; k++)
                            {
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("CPL")) this.alarmFilePath_CPL = this.mlayConstantInfo.GetItemString(k, "code_value");
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("CPL_EM")) this.alarmFilePath_CPL_EM = this.mlayConstantInfo.GetItemString(k, "code_value");
                            }
                        }
                    }
                }
            }

            // 自動照会
            if (btn_autoQuery_yn.Equals("Y"))
            {
                this.useTimeChkYN = "Y";
                //this.btnUseTimeChk.ImageIndex = 1;

                //this.timer1.Start();
                //this.cboTime.Enabled = true;
            }
            else
            {
                this.useTimeChkYN = "N";
                //this.btnUseTimeChk.ImageIndex = 0;

                //this.cboTime.Enabled = false;
                //this.timer1.Stop();
            }

            // 患者有Alarm
            if (btn_autoAlarm_yn.Equals("Y"))
            {
                this.useAlarmChkYN = "Y";
                //this.btnUseAlarmChk.ImageIndex = 1;
            }
            else
            {
                this.useAlarmChkYN = "N";
                //this.btnUseAlarmChk.ImageIndex = 0;
            }

            // 実施者に 現在ログインしている IDを セットする｡
            //this.cbxActor.SetDataValue(UserInfo.UserID);
        }
        #endregion

        //private void SetVisibleStatusBar(bool aIsVisible)
        //{
        //    this.pnlStatus.Visible = aIsVisible;
        //}
        //private void InitStatusBar(int aMaxValue)
        //{
        //    this.pgbProgress.Minimum = 0;
        //    this.pgbProgress.Maximum = aMaxValue;
        //    this.lbStatus.Text = "";
        //}
        //private void SetStatusBar(int aCurrentValue)
        //{
        //    this.pgbProgress.Value = aCurrentValue;
        //    this.pgbProgress.Refresh();
        //    this.lbStatus.Text = aCurrentValue.ToString() + "/" + this.pgbProgress.Maximum.ToString();
        //    this.lbStatus.Refresh();
        //}
        #region 환자선택/입력 후 벨리데이션 타기 전

        private void vsvPa_QueryStarting(object sender, CancelEventArgs e)
        {
            this.vsvPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.vsvPa.SetBindVarValue("f_date", this.dtpOrderDate.GetDataValue());
            this.vsvPa.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }
        #endregion


        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            //if (info != null && !TypeCheck.IsNull(info.BunHo))
            //{
            //    if (this.rbxJubsu.Checked == true)
            //    {
            //        this.dtpOrderDate.SetEditValue(info.SuName);
            //        this.rbxMijubsu.Checked = true;
            //    }
            //    else
            //    {
            //        this.dtpOrderDate.SetEditValue(info.SuName);
            //        this.dtpOrderDate.AcceptData();
            //    }

            //    this.fbxBunho.ResetData();
            //    this.fbxBunho.SetEditValue(info.BunHo);
            //    this.fbxBunho.AcceptData();
            //}
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(paBox.BunHo))
            {
                return new XPatientInfo(paBox.BunHo, "", "", "", this.ScreenName);
            }
            return null;
        }
        #endregion


        #region 날짜 선택 벨리데이팅
        private void dtpOrderDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //this.grdOrder.Reset();
            //this.grdSpecimen.Reset();
            //this.grdTube.Reset();
            this.ClearInputControl();
            this.ClearXEditGrid();
            //this.grdPaList.QueryLayout(false);
            //this.grdOrder.QueryLayout(false);

            //if ( dlg != null )
            //    dlg.SetBlood(this.dtpOrderDate.GetDataValue(),rbxMijubsu.Checked ? "N" : "Y");

            //// 20070312 Add Start
            //this.layChkNames.QueryLayout(true);
            //// 20070312 Add End

        }
        #endregion

        #region 검체그리드 저장 바로 전 일어나는 일

        private void grdSpecimen_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if (e.RowState == DataRowState.Modified)
                this.grdSpecimen.SetItemValue(e.RowNumber, "jubsuja", this.cbxActor.GetDataValue());
        }
        #endregion

        #region 처방그리드의 셀페인팅
        private void grdOrder_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (this.grdOrder.GetItemString(e.RowNumber, "jubsu_date").Length > 0)
                e.BackColor = Color.White;
            else
                e.BackColor = XColor.XLabelGradientEndColor.Color;

            if (e.ColName == "hope_date")
                if ((this.grdOrder.GetItemString(e.RowNumber, "hope_date").Trim().Length != 0)
                    && (this.grdOrder.GetItemString(e.RowNumber, "order_date").Trim() != this.grdOrder.GetItemString(e.RowNumber, "hope_date").Trim()))
                    e.ForeColor = XColor.XCalendarFullHolidayTextColor.Color;

        }
        #endregion

        #region 검체그리드의 셀페인팅
        private void grdSpecimen_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            //// 至急オーダは「Color.MistyRose」セット
            //if (this.grdSpecimen.GetItemString(e.RowNumber, "can_yn") == "X")
            //{
            //    e.BackColor = Color.MistyRose;
            //}

            //// 緊急オーダは「Color.Pink」セット
            //if (this.grdSpecimen.GetItemString(e.RowNumber, "can_yn") == "Z")
            //{
            //    e.BackColor = Color.Pink;
            //}

            // 院内検査は「Color.LightSkyBlue」セット
            if (this.grdSpecimen.GetItemString(e.RowNumber, "uitak_code") == "00" && (e.ColName == "hangmog_code"))
            {
                e.BackColor = Color.LightSkyBlue;
            }
        }
        #endregion

        #region 바코드출력 클릭
        private void btnBarcode_Click(object sender, System.EventArgs e)
        {
            Cursor preCursor = Cursor.Current;

            try
            {
                // Change cursor to waiting status to avoid double click
                // https://sofiamedix.atlassian.net/browse/MED-9443
                Cursor.Current = Cursors.WaitCursor;

                if (rbxJubsu.Checked)
                {
                    DataRow[] dtRowData = this.grdSpecimen.LayoutTable.Select("print_yn =" + "'Y'");

                    if (dtRowData.Length <= 0)
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox1_Ko
                                                            : Resources.CPL_XMessageBox1_JP);
                        string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                        XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                        return;
                    }
                    SetPrintBacode();
                }
                else
                {
                    if (this.paBox.BunHo != "")
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox2_Ko
                                         : Resources.CPL_XMessageBox2_Jp);
                        string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                        XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
            finally
            {
                Cursor.Current = preCursor;
            }
        }
        #endregion

        private void OrderQueryLayout()
        {
            if (this.bunho != "")
            {
                this.grdOrder.QueryLayout(true);
                this.check_inj_cpl_order();
            }
            else
            {
                //this.grdPaList.QueryLayout(true);
            }
        }

        #region 버튼리스트 작업 수행 전
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    //this.grdOrder.QueryLayout(true);
                    this.OrderQueryLayout();

                    if (grdOrder.RowCount == 0)
                    {
                        //this.grdPaList.QueryLayout(false);
                    }

                    this.QueryTime = this.TimeVal;

                    break;

                case FunctionType.Update:
                    //if (dlg != null)
                    //{
                    //    dlg.TimerControl(false);
                    //}
                    //this.btnList.Enabled = false;
                    if (this.grdSpecimen.RowCount == 0)
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox3_Ko
                                     : Resources.CPL_XMessageBox3_Jp);
                        string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                        XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }
                    else
                    {
                        if (this.rbxMijubsu.Checked && this.cbxActor.Text.Length == 0)
                        {
                            string mMsg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox4_Ko
                                : Resources.CPL_XMessageBox4_Jp);
                            string mCap = NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP;
                            XMessageBox.Show(mMsg, mCap, MessageBoxIcon.Information);
                            //this.cbxActor.Focus();
                            e.IsBaseCall = false;
                            e.IsSuccess = false;
                            //this.btnList.Enabled = true;
                            return;
                        }

                        string order_date = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date").Replace("/", "").Replace("-", "");
                        string reser_date = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "reser_date").Replace("/", "").Replace("-", "");
                        string today = DateTime.Today.ToString("yyyyMMdd");
                        reser_date = TypeCheck.NVL(reser_date, today).ToString();

                        if (this.rbxMijubsu.Checked && reser_date != today)
                        {
                            string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox5_ko + grdOrder.GetItemString(grdOrder.CurrentRowNumber, "reser_date").Replace("-", "/") + Resources.CPL_XMessageBox6_Ko + DateTime.Today.ToString("yyyy/MM/dd").Replace("-", "/") + Resources.CPL_XMessageBox7_Ko
                                : Resources.CPL_XMessageBox8_Jp + grdOrder.GetItemString(grdOrder.CurrentRowNumber, "reser_date").Replace("-", "/") + Resources.CPL_XMessageBox9_Jp + DateTime.Today.ToString("yyyy/MM/dd").Replace("-", "/") + Resources.CPL_XMessageBox10_Jp);

                            //"該当オーダは当日オーダでも当日予約オーダでもありません。このまま保存しますか。");
                            string cap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko
                                : Resources.CPL_Caption2_JP);
                            if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo) != DialogResult.Yes)
                            {
                                e.IsBaseCall = false;
                                e.IsSuccess = false;
                                //this.btnList.Enabled = true;
                                return;
                            }
                        }
                        string flg = "";
                        if (this.rbxMijubsu.Checked)
                        {
                            flg = "Y";
                        }
                        else
                        {
                            flg = "N";
                        }
                        DataRow[] dtRow = this.grdSpecimen.LayoutTable.Select("jubsu_flag =" + "'" + flg + "'");
                        if (dtRow.Length < 1)
                        {
                            string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox3_Ko
                                         : Resources.CPL_XMessageBox3_Jp);
                            string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                            XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                            e.IsBaseCall = false;
                            e.IsSuccess = false;
                            //this.btnList.Enabled = true;
                            return;
                        }
                    }
                    e.IsBaseCall = false;
                    jubsu_cnt = 0;
                    cancel_cnt = 0;
                    t_jubsu_gubun = "";

                    Hashtable inputList = new Hashtable();
                    Hashtable outputList = new Hashtable();

                    //this.timer1.Stop();

                    //this.InitStatusBar(this.grdSpecimen.RowCount);
                    //this.SetVisibleStatusBar(true);
                    //this.SetStatusBar(0);

                    #region todo delete

                    //                    try
                    //                    {
                    //                        Service.BeginTransaction();

                    //                        if (this.grdSpecimen.SaveLayout())
                    //                        {
                    //                            e.IsSuccess = true;

                    //                            if (jubsu_cnt > 0)
                    //                            {
                    //                                inputList.Add("I_ORDER_DATE",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date"));
                    //                                inputList.Add("I_BUNHO", this.fbxBunho.GetDataValue());
                    //                                inputList.Add("I_JUBSUJA", this.cbxActor.GetDataValue());
                    //                                inputList.Add("I_JUBSU_FLAG", "Y");
                    //                                inputList.Add("I_JUBSU_GUBUN", t_jubsu_gubun); // null
                    //                                inputList.Add("I_JUBSU_DATE",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    //                                inputList.Add("I_JUBSU_TIME",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time"));

                    //                                //XMessageBox.Show("aaa");

                    //                                //채혈일은 dtpOrderDate이 아니라 sysdate가 들어감.
                    //                                if (Service.ExecuteProcedure("PR_CPL_MAKE_SPECIMEN_SER", inputList, outputList))
                    //                                {
                    //                                    if (outputList.Count > 0)
                    //                                    {
                    //                                        if (outputList["IO_FLAG"].ToString() == "N")
                    //                                        {
                    //                                            //mErrMsg = "患者情報がありません。オーダを確認してください。";
                    //                                            mErrMsg = Resources.XMessageBox11_Jp;
                    //                                            throw new Exception();
                    //                                        }
                    //                                    }
                    //                                }
                    //                                else
                    //                                {
                    //                                    throw new Exception();
                    //                                }
                    //                            }
                    //                            // 바코드 출력
                    //                            if (rbxMijubsu.Checked)
                    //                            {
                    //                                //바코드프린터명 가져오기
                    //                                this.layPrintName.QueryLayout();
                    //                                string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

                    //                                dwBarcode.Reset();
                    //                                layBarcode.Reset();
                    //                                this.layBarcodeTemp.SetBindVarValue("f_jubsu_date",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    //                                // jubsu_date 전역변수에 담아서 쿼리엔드에서도 사용해야함
                    //                                this.layBarcodeTemp.QueryLayout(true);

                    //                                if (layBarcode.RowCount > 0)
                    //                                {
                    //                                    #region

                    //                                    //채혈실의 뇨컵은 하나면된다
                    //                                    //										int nyo_cnt = 0;
                    //                                    //										string tube_code = "";
                    //                                    //										string jundal_gubun = "";
                    //                                    //										for (int i = this.layBarcode.RowCount-1; i >= 0 ; i-- )
                    //                                    //										{
                    //                                    //											jundal_gubun = this.layBarcode.GetItemString(i,"jundal_gubun");
                    //                                    //											tube_code = this.layBarcode.GetItemString(i,"tube_code");
                    //                                    //											if ( jundal_gubun != "14" ) //혈당부하 항목의 뇨는 그냥 바코드 뽑는다.
                    //                                    //											{
                    //                                    //												if ( tube_code == "18" )
                    //                                    //												{
                    //                                    //													nyo_cnt++;
                    //                                    //												}
                    //                                    //												if (nyo_cnt>1)
                    //                                    //												{
                    //                                    //													if ( tube_code == "18" )
                    //                                    //													{
                    //                                    //														this.layBarcode.DeleteRow(i);
                    //                                    //													}
                    //                                    //												}
                    //                                    //											}
                    //                                    //										}
                    //                                    //										this.layBarcode.AcceptData();
                    //                                    //
                    //                                    //										nyo_cnt = 0;
                    //                                    //										tube_code = "";
                    //                                    //										jundal_gubun = "";
                    //                                    //										for (int i = this.layBarcode.RowCount-1; i >= 0 ; i-- )
                    //                                    //										{
                    //                                    //											jundal_gubun = this.layBarcode.GetItemString(i,"jundal_gubun");
                    //                                    //											tube_code = this.layBarcode.GetItemString(i,"tube_code");
                    //                                    //											if ( jundal_gubun != "14" ) //혈당부하 항목의 뇨는 그냥 바코드 뽑는다.
                    //                                    //											{
                    //                                    //												if ( tube_code == "24" )
                    //                                    //												{
                    //                                    //													nyo_cnt++;
                    //                                    //												}
                    //                                    //												if (nyo_cnt>1)
                    //                                    //												{
                    //                                    //													if ( tube_code == "24" )
                    //                                    //													{
                    //                                    //														this.layBarcode.DeleteRow(i);
                    //                                    //													}
                    //                                    //												}
                    //                                    //											}
                    //                                    //										}
                    //                                    //this.layBarcode.AcceptData();

                    //                                    #endregion

                    //                                    //한껀씩 출력 보냄
                    //                                    //this.InitStatusBar(this.layBarcode.RowCount);
                    //                                    for (int j = 0; j < this.layBarcode.RowCount; j++)
                    //                                    {
                    //                                        //this.SetStatusBar(j);
                    //                                        dwBarcode.Reset();
                    //                                        layBarcodeOne.Reset();

                    //                                        int rowNum = layBarcodeOne.InsertRow(0);
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun",
                    //                                            this.layBarcode.GetItemString(j, "jundal_gubun"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name",
                    //                                            this.layBarcode.GetItemString(j, "jundal_gubun_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_code",
                    //                                            this.layBarcode.GetItemString(j, "specimen_code"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_name",
                    //                                            this.layBarcode.GetItemString(j, "specimen_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_code",
                    //                                            this.layBarcode.GetItemString(j, "tube_code"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_name",
                    //                                            this.layBarcode.GetItemString(j, "tube_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser",
                    //                                            this.layBarcode.GetItemString(j, "specimen_ser"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode.GetItemString(j, "bunho"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode.GetItemString(j, "suname"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "gwa_name",
                    //                                            this.layBarcode.GetItemString(j, "gwa_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "danger_yn",
                    //                                            this.layBarcode.GetItemString(j, "danger_yn"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba",
                    //                                            this.layBarcode.GetItemString(j, "specimen_ser_ba"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jangbi_code",
                    //                                            this.layBarcode.GetItemString(j, "jangbi_code"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jangbi_name",
                    //                                            this.layBarcode.GetItemString(j, "jangbi_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "in_out_gubun",
                    //                                            this.layBarcode.GetItemString(j, "in_out_gubun"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re",
                    //                                            this.layBarcode.GetItemString(j, "gumsa_name_re"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_max_amt",
                    //                                            this.layBarcode.GetItemString(j, "tube_max_amt"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_numbering",
                    //                                            this.layBarcode.GetItemString(j, "tube_numbering"));

                    //                                        dwBarcode.FillData(layBarcodeOne.LayoutTable);
                    //                                        dwBarcode.PrintProperties.PrinterName = printSetName;
                    //                                        dwBarcode.Print();

                    //                                        string strCMD = @"SELECT 'Y'
                    //                                                            FROM DUAL
                    //                                                           WHERE EXISTS (SELECT NULL
                    //                                                                           FROM CPL0109
                    //                                                                          WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                    //                                                                            AND CODE_TYPE = '20'
                    //                                                                            AND CODE ='" +
                    //                                                        this.layBarcodeOne.GetItemString(0, "specimen_code") + "')";

                    //                                        object retVal = Service.ExecuteScalar(strCMD);

                    //                                        if (TypeCheck.IsNull(retVal))
                    //                                        {

                    //                                            inputList.Clear();
                    //                                            outputList.Clear();

                    //                                            inputList.Add("I_SPECIMEN_SER", this.layBarcode.GetItemString(j, "specimen_ser"));
                    //                                            inputList.Add("I_JUNDAL_GUBUN", this.layBarcode.GetItemString(j, "jundal_gubun"));
                    //                                            inputList.Add("I_PART_JUBSU_DATE",
                    //                                                this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    //                                            inputList.Add("I_PART_JUBSU_TIME",
                    //                                                this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time"));
                    //                                            inputList.Add("I_PART_JUBSUJA", this.cbxActor.GetDataValue());
                    //                                            inputList.Add("I_USER_ID", this.cbxActor.GetDataValue());

                    //                                            if (!Service.ExecuteProcedure("PR_CPL_PART_JUBSU", inputList, outputList))
                    //                                            {
                    //                                                XMessageBox.Show(Resources.XMessageBox12 + Service.ErrFullMsg, Resources.caption4,
                    //                                                    MessageBoxIcon.Error);
                    //                                                throw new Exception();
                    //                                            }
                    //                                        }
                    //                                        //if (outputList.Count > 0)
                    //                                        //    flag = outputList[0].ToString();
                    //                                    }

                    //                                    //foreach (DataRow row in this.layBarcode.LayoutTable.Rows)
                    //                                    //{
                    //                                    //    dwBarcode.Reset();
                    //                                    //    layBarcodeOne.Reset();

                    //                                    //    layBarcodeOne.LayoutTable.ImportRow(row);

                    //                                    //    dwBarcode.FillData(layBarcodeOne.LayoutTable);
                    //                                    //    dwBarcode.PrintProperties.PrinterName = printSetName;
                    //                                    //    dwBarcode.Print();
                    //                                    //}
                    //                                }

                    //                            }

                    //                        }
                    //                        else
                    //                        {
                    //                            throw new Exception();
                    //                        }
                    //                        Service.CommitTransaction();
                    //                    }
                    //                    catch
                    //                    {
                    //                        Service.RollbackTransaction();
                    //                        e.IsSuccess = false;
                    //                        XMessageBox.Show(Resources.XMessageBox13 + mErrMsg, Resources.caption5, MessageBoxIcon.Error);
                    //                    }
                    //                    finally
                    //                    {
                    //                        if (this.useTimeChkYN.Equals("Y"))
                    //                        {
                    //                            this.timer1.Start();
                    //                        }
                    //                        //this.SetVisibleStatusBar(false);
                    //                        this.btnList.Enabled = true;

                    //                    }

                    #endregion

                    if (this.rbxJubsu.Checked == true)
                    {
                        foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                        {
                            // 会計未処理のみ
                            if (dtRow["if_data_send_yn"].ToString() == "Y")
                            {
                                XMessageBox.Show(Resources.CPL_XMessageBox2, "", MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    //save layout
                    try
                    {
                        e.IsSuccess = SaveGrdSpecimen();
                        if (e.IsSuccess == false)
                        {
                            XMessageBox.Show(Resources.CPL_XMessageBox13 + mErrMsg, Resources.CPL_caption5, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        //2015.10.07: modified due to MED-4594
                        if (ex.GetType().IsAssignableFrom(typeof(Sybase.DataWindow.MethodFailureException)))
                        {
                            //do nothing
                        }
                        else
                        {
                            e.IsSuccess = false;
                            XMessageBox.Show(Resources.CPL_XMessageBox13 + mErrMsg, Resources.CPL_caption5, MessageBoxIcon.Error);
                        }
                    }
                    finally
                    {
                        if (this.useTimeChkYN.Equals("Y"))
                        {
                            //this.timer1.Start();
                        }
                        //this.SetVisibleStatusBar(false);
                        //this.btnList.Enabled = true;

                    }

                    //if (dlg != null)
                    //{
                    //    dlg.TimerControl(true);
                    //}
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Cloud-service SaveLayout implementation

        private bool SaveGrdSpecimen()
        {

            //String msg = Resources.TEXT88;
            //String cap = Resources.TEXT99;

            //if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            //{
            //    return false;
            //}

            List<CPL2010U00GrdSpecimenListItemInfo> inputList = GetListFromGrdSpecimen();
            if (inputList.Count == 0)
            {
                return false;
            }

            CPL2010U00SaveLayoutArgs args = new CPL2010U00SaveLayoutArgs();
            args.InputList = inputList;
            args.Bunho = this.paBox.BunHo;
            args.BunhoPr1 = this.paBox.BunHo;
            args.JubsuDate = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date");
            args.JubsuDatePr1 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date");
            args.JubsuFlagPr1 = "Y";
            //args.JubsuGubunPr1 = "";
            args.JubsuTimePr1 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time");
            args.JubsujaPr1 = this.cbxActor.GetDataValue();
            //args.JundalGubunPr2 = "";
            args.OrderDatePr1 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date");
            args.PartJubsuDatePr2 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date");
            args.PartJubsuTimePr2 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time");
            args.PartJubsujaPr2 = this.cbxActor.GetDataValue();
            args.RbxMijubsuChecked = rbxMijubsu.Checked;
            //args.SpecimenSerPr2 = "";
            args.UserId = UserInfo.UserID;
            args.UserIdPr2 = this.cbxActor.GetDataValue();
            args.IpAddr = NetInfo.ClientIP.ToString();

            saveLayoutResult = CloudService.Instance.Submit<CPL2010U00SaveLayoutResult, CPL2010U00SaveLayoutArgs>(args);
            if (saveLayoutResult.ExecutionStatus == ExecutionStatus.Success)
            {
                if (saveLayoutResult.WholeResult)
                {
                    //after save
                    if (rbxMijubsu.Checked)
                    {
                        InitDataWindow();

                        dwBarcode.Reset();
                        layBarcode.Reset();

                        layBarcodeTemp.QueryLayout(false);
                        if (layBarcode.RowCount > 0)
                        {
                            for (int j = 0; j < this.layBarcode.RowCount; j++)
                            {
                                //this.SetStatusBar(j);
                                dwBarcode.Reset();
                                layBarcodeOne.Reset();

                                int rowNum = layBarcodeOne.InsertRow(0);
                                layBarcodeOne.SetItemValue(rowNum, "jundal_gubun",
                                    this.layBarcode.GetItemString(j, "jundal_gubun"));
                                layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name",
                                    this.layBarcode.GetItemString(j, "jundal_gubun_name"));
                                layBarcodeOne.SetItemValue(rowNum, "specimen_code",
                                    this.layBarcode.GetItemString(j, "specimen_code"));
                                layBarcodeOne.SetItemValue(rowNum, "specimen_name",
                                    this.layBarcode.GetItemString(j, "specimen_name"));
                                layBarcodeOne.SetItemValue(rowNum, "tube_code",
                                    this.layBarcode.GetItemString(j, "tube_code"));
                                layBarcodeOne.SetItemValue(rowNum, "tube_name",
                                    this.layBarcode.GetItemString(j, "tube_name"));
                                layBarcodeOne.SetItemValue(rowNum, "specimen_ser",
                                    this.layBarcode.GetItemString(j, "specimen_ser"));
                                layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode.GetItemString(j, "bunho"));
                                layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode.GetItemString(j, "suname"));
                                layBarcodeOne.SetItemValue(rowNum, "gwa_name",
                                    this.layBarcode.GetItemString(j, "gwa_name"));
                                layBarcodeOne.SetItemValue(rowNum, "danger_yn",
                                    this.layBarcode.GetItemString(j, "danger_yn"));
                                layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba",
                                    this.layBarcode.GetItemString(j, "specimen_ser_ba"));
                                layBarcodeOne.SetItemValue(rowNum, "jangbi_code",
                                    this.layBarcode.GetItemString(j, "jangbi_code"));
                                layBarcodeOne.SetItemValue(rowNum, "jangbi_name",
                                    this.layBarcode.GetItemString(j, "jangbi_name"));
                                layBarcodeOne.SetItemValue(rowNum, "in_out_gubun",
                                    this.layBarcode.GetItemString(j, "in_out_gubun"));
                                layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re",
                                    this.layBarcode.GetItemString(j, "gumsa_name_re"));
                                layBarcodeOne.SetItemValue(rowNum, "tube_max_amt",
                                    this.layBarcode.GetItemString(j, "tube_max_amt"));
                                layBarcodeOne.SetItemValue(rowNum, "tube_numbering",
                                    this.layBarcode.GetItemString(j, "tube_numbering"));

                                dwBarcode.FillData(layBarcodeOne.LayoutTable);
                                dwBarcode.PrintProperties.PrinterName = saveLayoutResult.PrintName;
                                dwBarcode.Print();
                            }
                        }
                    }
                }

                return saveLayoutResult.WholeResult;
            }
            return false;
        }

        private List<CPL2010U00GrdSpecimenListItemInfo> GetListFromGrdSpecimen()
        {
            List<CPL2010U00GrdSpecimenListItemInfo> dataList = new List<CPL2010U00GrdSpecimenListItemInfo>();
            for (int i = 0; i < grdSpecimen.RowCount; i++)
            {
                if (grdSpecimen.GetRowState(i) == DataRowState.Modified)
                {
                    //pre-save
                    this.grdSpecimen.SetItemValue(i, "jubsuja", this.cbxActor.GetDataValue());

                    CPL2010U00GrdSpecimenListItemInfo info = new CPL2010U00GrdSpecimenListItemInfo();
                    info.Pkcpl2010 = grdSpecimen.GetItemString(i, "pkcpl2010");
                    info.SunabYn = grdSpecimen.GetItemString(i, "sunab_yn");
                    info.JubsuFlag = grdSpecimen.GetItemString(i, "jubsu_flag");
                    info.SlipName = grdSpecimen.GetItemString(i, "slip_name");
                    info.HangmogCode = grdSpecimen.GetItemString(i, "hangmog_code");
                    info.GumsaName = grdSpecimen.GetItemString(i, "gumsa_name");
                    info.SpecimenCode = grdSpecimen.GetItemString(i, "specimen_code");
                    info.SpecimenName = grdSpecimen.GetItemString(i, "specimen_name");
                    info.Emergency = grdSpecimen.GetItemString(i, "emergency");
                    info.TubeCode = grdSpecimen.GetItemString(i, "tube_code");
                    info.TubeName = grdSpecimen.GetItemString(i, "tube_name");
                    info.SpecimenSer = grdSpecimen.GetItemString(i, "specimen_ser");
                    info.CommentJuCode = grdSpecimen.GetItemString(i, "comment_ju_code");
                    info.Fkocs1003 = grdSpecimen.GetItemString(i, "fkocs1003");
                    info.GroupGubun = grdSpecimen.GetItemString(i, "group_gubun");
                    info.PartJubsuFlag = grdSpecimen.GetItemString(i, "part_jubsu_flag");
                    info.GumJubsuFlag = grdSpecimen.GetItemString(i, "gum_jubsu_flag");
                    info.Dummy = grdSpecimen.GetItemString(i, "dummy");
                    info.ModifyYn = grdSpecimen.GetItemString(i, "modify_yn");
                    info.ModifyYn1 = grdSpecimen.GetItemString(i, "modify_yn_1");
                    info.JundalGubun = grdSpecimen.GetItemString(i, "jundal_gubun");
                    info.JundalGubunName = grdSpecimen.GetItemString(i, "jundal_gubun_name");
                    info.Jubsuja = grdSpecimen.GetItemString(i, "jubsuja");
                    info.OrderDate = grdSpecimen.GetItemString(i, "order_date");
                    info.Bunho = grdSpecimen.GetItemString(i, "bunho");
                    info.JubsuDate = grdSpecimen.GetItemString(i, "jubsu_date");
                    info.JubsuTime = grdSpecimen.GetItemString(i, "jubsu_time");
                    info.OrderTime = grdSpecimen.GetItemString(i, "order_time");
                    info.GroupHangmog = grdSpecimen.GetItemString(i, "group_hangmog");
                    info.SpcialName = grdSpecimen.GetItemString(i, "spcial_name");
                    info.CanYn = grdSpecimen.GetItemString(i, "can_yn");
                    info.Barcode = grdSpecimen.GetItemString(i, "barcode");
                    info.BarcodeName = grdSpecimen.GetItemString(i, "barcode_name");
                    info.DocComment = grdSpecimen.GetItemString(i, "comment");
                    info.UitakCode = grdSpecimen.GetItemString(i, "uitak_code");
                    info.MiddleResult = grdSpecimen.GetItemString(i, "middle_result");
                    info.RowState = DataRowState.Modified.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
        }

        #endregion

        #region Command

        //public override object Command(string command, CommonItemCollection commandParam)
        //{
        //    //switch (command)
        //    //{
        //    //    case "bunho":

        //    //        if (commandParam.Contains("bunho"))
        //    //        {
        //    //            fbxBunho.SetEditValue(commandParam["bunho"].ToString());
        //    //            fbxBunho.AcceptData();
        //    //        }

        //    //        break;
        //    //}

        //    //return base.Command(command, commandParam);
        //}


        #endregion

        #region 버튼리스트 작업 수행 후
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    if (e.IsSuccess == true)
                    {
                        //바코드 출력 후 오더 재조회(바코드 올 출력시 오더조회그리드의 current_row 를 참조하는 것이 이유)
                        //this.grdOrder.QueryLayout(false);
                        this.ClearInputControl();
                        this.ClearXEditGrid();
                        //this.grdPaList.QueryLayout(true);
                    }


                    //if (dlg != null)
                    //{
                    //    string blood = "N";

                    //    if (rbxJubsu.Checked == true)
                    //    {
                    //        blood = "Y";
                    //    }
                    //    dlg.SetBlood(this.dtpOrderDate.GetDataValue(), blood);
                    //}

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 시간변경클릭
        private void btnChangeTime_Click(object sender, System.EventArgs e)
        {
            if (this.paBox.BunHo != "")
            {
                /*********************
			    /  폼으로 보여줄 때 
			    /********************/
                if (this.grdSpecimen.RowCount > 0)
                {
                    CHANGETIME dlg = new CHANGETIME(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gwa"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gubun"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "doctor"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun"));
                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        this.grdSpecimen.QueryLayout(false);
                    }
                }
                else
                {
                    string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox15_Ko
                        : Resources.CPL_XMessageBox15_Jp);
                    string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                    XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region 미채혈 라디오 체크
        private void rbxMijubsu_CheckedChanged(object sender, System.EventArgs e)
        {

            //if (this.rbxMijubsu.Checked == true)
            //{
            //    this.rbxMijubsu.ImageIndex = 1;
            //    this.rbxJubsu.ImageIndex = 0;

            //    this.mJubsu_yn = "2";
            //    this.ClearInputControl();
            //    this.ClearXEditGrid();
            //    this.btnOrderCancel.Visible = false;
            //    this.btnBarcode.Visible = false;

            //    this.cbxActor.Enabled = true;
            //    this.cbxActor.SelectedIndex = 0;

            //    // 実施者に 現在ログインしている IDを セットする｡
            //    this.cbxActor.SetDataValue(UserInfo.UserID);

            //    this.xEditGridCell5.IsReadOnly = false;
            //    this.xEditGridCell61.IsReadOnly = false;

            //    this.rbxMijubsu.BackColor = Color.Pink;
            //    this.rbxJubsu.BackColor = Color.WhiteSmoke;
            //}
            //else
            //{
            //    this.rbxMijubsu.ImageIndex = 0;
            //    this.rbxJubsu.ImageIndex = 1;

            //    this.mJubsu_yn = "3";
            //    this.ClearInputControl();
            //    this.ClearXEditGrid();
            //    //this.btnOrderCancel.Visible = true;
            //    this.btnBarcode.Visible = true;

            //    this.cbxActor.Enabled = false;

            //    this.xEditGridCell5.IsReadOnly = true;
            //    this.xEditGridCell61.IsReadOnly = true;

            //    this.rbxMijubsu.BackColor = Color.WhiteSmoke;
            //    this.rbxJubsu.BackColor = Color.Pink;
            //}

            //// 一括受付ボタン初期化
            //this.reset_BtnChkAllJubsu();

            //this.grdPaList.QueryLayout(true);
        }
        #endregion

        #region 채혈 라디오 체크
        private void rbxJubsu_CheckedChanged(object sender, System.EventArgs e)
        {

            //if ( this.rbxJubsu.Checked == true )
            //{
            //    this.rbxMijubsu.ImageIndex = 1;
            //    this.rbxJubsu.ImageIndex = 0;

            //    this.mJubsu_yn = "3";
            //    this.ClearInputControl();
            //    this.ClearXEditGrid();
            //    this.grdOrder.QueryLayout(false);
            //    this.grdSpecimen.QueryLayout(false);
            //    this.lbTitle.Text = "採血患者照会";
            //    this.lbTitle.ForeColor = new XColor(Color.Crimson);
            //    this.grdPaList.QueryLayout(true);
            //    this.btnOrderCancel.Visible = true;
            //}
        }
        #endregion

        #region	grdSpecimen QueryStart/End
        private void grdSpecimen_QueryStarting(object sender, CancelEventArgs e)
        {
            grdSpecimen.Reset();

            //            if (this.mJubsu_yn == "1")// 채혈, 미채혈. 실제로 사용되지 않음... 왜있는거지....?
            //            {
            ////                this.grdSpecimen.QuerySQL = @"/* grd Specimen 1 */
            ////                                                SELECT A.PKCPL2010 
            ////                                                     , DECODE(A.SUNAB_DATE, NULL, 'N', 'Y')         SUNAB_YN
            ////                                                     , DECODE(A.JUBSU_DATE, NULL, 'N', 'Y')          JUBSU_FLAG
            ////                                                     , F.SLIP_NAME                                   
            ////                                                     , A.HANGMOG_CODE
            ////                                                     , C.GUMSA_NAME      
            ////                                                     , A.SPECIMEN_CODE   
            ////                                                     , B.CODE_NAME                       SPECIMEN_NAME
            ////                                                     , A.EMERGENCY
            ////                                                     , A.TUBE_CODE
            ////                                                     , NVL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME  
            ////                                                     , A.SPECIMEN_SER 
            ////                                                     , FN_CPL_SUB_COMMENT(A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)                 COMMENT_JU_CODE
            ////                                                     , A.FKOCS1003
            ////                                                     , NVL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN
            ////                                                     , DECODE(A.PART_JUBSU_DATE, NULL, 'N', 'Y')     PART_JUBSU_FLAG
            ////                                                     , DECODE(A.GUM_JUBSU_DATE, NULL, 'N', 'Y')      GUM_JUBSU_FLAG
            ////                                                     , A.DUMMY       
            ////                                                     , DECODE(C.GROUP_GUBUN,'03','Y','N')            MODIFY_YN
            ////                                                     , DECODE(A.HANGMOG_CODE,A.GROUP_HANGMOG,DECODE(C.GROUP_GUBUN,'02','N','Y'),'N')    MODIFY_YN_1
            ////                                                     , A.JUNDAL_GUBUN
            ////                                                     , A.JUBSUJA 
            ////                                                     , A.ORDER_DATE
            ////                                                     , A.BUNHO     
            ////                                                     , A.JUBSU_DATE
            ////                                                     , A.JUBSU_TIME
            ////                                                     , A.ORDER_TIME
            ////                                                     , A.GROUP_HANGMOG
            ////                                                     , C.SPCIAL_NAME
            ////                                                     --, DECODE(A.JUBSU_DATE, NULL, FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003), NULL) CAN_YN
            ////                                                     , FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) CAN_YN
            ////                                                     , C.BARCODE BARCODE
            ////                                                     , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE) BARCODE_NAME
            ////                                                     , FN_XRT_LOAD_COMMENT(A.FKOCS1003, A.FKOCS2003) DOC_COMMENT
            ////                                                     , C.UITAK_CODE
            ////                                                  FROM CPL0001 F, 
            ////                                                       CPL0109 D, 
            ////                                                       CPL0101 C, 
            ////                                                       CPL0109 B, 
            ////                                                       CPL2010 A
            ////                                                 WHERE A.HOSP_CODE                = :f_hosp_code
            ////                                                   AND B.HOSP_CODE(+)             = A.HOSP_CODE
            ////                                                   AND C.HOSP_CODE                = A.HOSP_CODE
            ////                                                   AND D.HOSP_CODE(+)             = A.HOSP_CODE
            ////                                                   AND F.HOSP_CODE(+)             = C.HOSP_CODE
            ////                                                   AND A.ORDER_DATE               = to_date(:f_order_date,'YYYY/MM/DD')
            ////                                                   AND A.BUNHO                    = :f_bunho
            ////                                                   AND A.GWA                      = :f_gwa
            ////                                                   AND NVL(A.ORDER_TIME,'0000')   = NVL(:f_order_time,'0000')
            ////                                                   AND NVL(A.GUBUN,'%')           LIKE :f_gubun||'%'
            ////                                                   AND A.DOCTOR                   = :f_doctor
            ////                                                   AND A.IN_OUT_GUBUN             = :f_in_out_gubun  
            ////                                                   AND (  ( :f_reser_date IS NOT NULL AND A.RESER_DATE = :f_reser_date )
            ////                                                       OR ( :f_reser_date IS NULL AND A.RESER_DATE IS NULL ) )         
            ////                                                   AND NVL(A.DC_YN,'N')           = 'N'
            ////                                                   --AND A.JUNDAL_GUBUN            <> '08' --BLOOD
            ////                                                   AND ( (A.AFTER_ACT_YN IS NULL) OR 
            ////                                                       (A.AFTER_ACT_YN =  'N' ) )
            ////                                                   AND B.CODE(+)                  = A.SPECIMEN_CODE
            ////                                                   AND B.CODE_TYPE(+)             = '04'
            ////                                                   AND C.HANGMOG_CODE             = A.HANGMOG_CODE
            ////                                                   AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE
            ////                                                   AND C.EMERGENCY                = A.EMERGENCY
            ////                                                   AND D.CODE(+)                  = A.TUBE_CODE
            ////                                                   AND D.CODE_TYPE(+)             = '02'
            ////                                                   AND F.SLIP_CODE(+)             = C.SLIP_CODE
            ////                                              ORDER BY C.UITAK_CODE,
            ////                                                       LPAD(A.GROUP_HANGMOG,10,'0'),
            ////                                                       DECODE(A.GROUP_HANGMOG, A.HANGMOG_CODE, 1, 2 ),
            ////                                                       LPAD(A.HANGMOG_CODE,10,'0'),
            ////                                                       A.TUBE_CODE,
            ////                                                       A.ORDER_TIME,
            ////                                                       A.JUNDAL_GUBUN,
            ////                                                       A.SPECIMEN_CODE,
            ////                                                       NVL(C.SERIAL,'9999999999')";
            //            }
            //            else if (this.mJubsu_yn == "2") //미채혈
            //            {
            //                this.grdSpecimen.QuerySQL = @"/* grd Specimen Before Jubsu */
            //                                                SELECT A.PKCPL2010 
            //                                                     , DECODE(A.SUNAB_DATE, NULL, 'N', 'Y')          SUNAB_YN
            //                                                     , DECODE(A.JUBSU_DATE, NULL, 'N', 'Y')        JUBSU_FLAG
            //                                                     --, 'Y'                                           JUBSU_FLAG
            //                                                     , F.SLIP_NAME                                   
            //                                                     , A.HANGMOG_CODE
            //                                                     , C.GUMSA_NAME      
            //                                                     , A.SPECIMEN_CODE   
            //                                                     , B.CODE_NAME                       SPECIMEN_NAME
            //                                                     , A.EMERGENCY
            //                                                     , A.TUBE_CODE
            //                                                     , NVL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME  
            //                                                     , A.SPECIMEN_SER 
            //                                                     , FN_CPL_SUB_COMMENT(A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)                 COMMENT_JU_CODE
            //                                                     , A.FKOCS1003
            //                                                     , NVL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN
            //                                                     , DECODE(A.PART_JUBSU_DATE, NULL, 'N', 'Y')     PART_JUBSU_FLAG
            //                                                     , DECODE(A.GUM_JUBSU_DATE, NULL, 'N', 'Y')      GUM_JUBSU_FLAG
            //                                                     , A.DUMMY       
            //                                                     , DECODE(C.GROUP_GUBUN,'03','Y','N')            MODIFY_YN
            //                                                     , DECODE(A.HANGMOG_CODE,A.GROUP_HANGMOG,DECODE(C.GROUP_GUBUN,'02','N','Y'),'N')    MODIFY_YN_1
            //                                                     , A.JUNDAL_GUBUN
            //                                                     , FN_CPL_LOAD_CODE_NAME('01',A.JUNDAL_GUBUN)    JUNDAL_GUBUN_NAME
            //                                                     , A.JUBSUJA
            //                                                     , A.ORDER_DATE
            //                                                     , A.BUNHO     
            //                                                     , A.JUBSU_DATE
            //                                                     , A.JUBSU_TIME
            //                                                     , A.ORDER_TIME
            //                                                     , A.GROUP_HANGMOG
            //                                                     , C.SPCIAL_NAME
            //                                                     --, DECODE(A.JUBSU_DATE, NULL, FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003), NULL) CAN_YN
            //                                                     , FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) CAN_YN
            //                                                     , C.BARCODE BARCODE
            //                                                     , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE) BARCODE_NAME
            //                                                     , FN_XRT_LOAD_COMMENT(A.FKOCS1003, A.FKOCS2003) DOC_COMMENT
            //                                                     , C.UITAK_CODE
            //                                                     , NVL(C.MIDDLE_RESULT, 'N')                              MIDDLE_RESULT
            //                                                  FROM CPL0001 F
            //                                                     , CPL0109 D
            //                                                     , CPL0101 C
            //                                                     , CPL0109 B
            //                                                     , OCS1003 O
            //                                                     , CPL2010 A
            //                                                 WHERE A.HOSP_CODE                = :f_hosp_code
            //                                                   AND B.HOSP_CODE(+)             = A.HOSP_CODE
            //                                                   AND C.HOSP_CODE                = A.HOSP_CODE
            //                                                   AND D.HOSP_CODE(+)             = A.HOSP_CODE
            //                                                   AND F.HOSP_CODE(+)             = C.HOSP_CODE
            //                                                   AND A.ORDER_DATE               = :f_order_date
            //                                                   --
            //                                                   AND A.GROUP_SER                = :f_group_ser
            //
            //                                                   AND A.BUNHO                    = :f_bunho
            //                                                   AND A.GWA                      = :f_gwa
            //                                                   AND NVL(A.ORDER_TIME,'0000')   = NVL(:f_order_time,'0000')
            //                                                   --AND NVL(A.GUBUN,'%')           LIKE :f_gubun||'%'
            //                                                   AND A.DOCTOR                   = :f_doctor
            //                                                   AND A.IN_OUT_GUBUN             = 'O'
            //                                                   AND A.JUBSU_DATE               IS NULL
            //                                                   AND (  ( :f_reser_yn = 'Y' AND A.RESER_DATE = :f_reser_date )
            //                                                       OR ( :f_reser_yn = 'N' AND A.RESER_DATE IS NULL ) )         
            //                                                   AND NVL(A.DC_YN,'N')           = 'N'
            //                                                   --AND A.JUNDAL_GUBUN            <> '08' --BLOOD
            //                                                   AND ( (A.AFTER_ACT_YN IS NULL) OR 
            //                                                       (A.AFTER_ACT_YN =  'N' ) )
            //                                                   AND B.CODE(+)                  = A.SPECIMEN_CODE
            //                                                   AND B.CODE_TYPE(+)             = '04'
            //                                                   AND C.HANGMOG_CODE             = A.HANGMOG_CODE
            //                                                   AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE
            //                                                   AND C.EMERGENCY                = A.EMERGENCY
            //                                                   AND D.CODE(+)                  = A.TUBE_CODE
            //                                                   AND D.CODE_TYPE(+)             = '02'
            //                                                   AND F.SLIP_CODE(+)             = C.SLIP_CODE
            //
            //                                                   AND O.HOSP_CODE                = A.HOSP_CODE
            //                                                   AND O.PKOCS1003                = A.FKOCS1003
            //                                                   AND (:f_emergency_yn = 'N' AND NVL(O.EMERGENCY, 'N') = 'N'
            //                                                     OR :f_emergency_yn = 'Y' AND NVL(O.EMERGENCY, 'N') = 'Y')
            //                                              ORDER BY C.UITAK_CODE,
            //                                                       LPAD(A.GROUP_HANGMOG,10,'0'),
            //                                                       DECODE(A.GROUP_HANGMOG, A.HANGMOG_CODE, 1, 2 ),
            //                                                       LPAD(A.HANGMOG_CODE,10,'0'),
            //                                                       A.TUBE_CODE,
            //                                                       A.ORDER_TIME,
            //                                                       A.JUNDAL_GUBUN,
            //                                                       A.SPECIMEN_CODE,
            //                                                       NVL(C.SERIAL,'9999999999')";
            //            }
            //            else //채혈
            //            {
            //                this.grdSpecimen.QuerySQL = @"/* grd Specimen After Jubsu */
            //                                                SELECT A.PKCPL2010 
            //                                                     , DECODE(A.SUNAB_DATE, NULL, 'N', 'Y')	         SUNAB_YN
            //                                                     , DECODE(A.JUBSU_DATE, NULL, 'N', 'Y')          JUBSU_FLAG
            //                                                     , F.SLIP_NAME                                   
            //                                                     , A.HANGMOG_CODE
            //                                                     , C.GUMSA_NAME	  
            //                                                     , A.SPECIMEN_CODE   
            //                                                     , B.CODE_NAME                       SPECIMEN_NAME
            //                                                     , A.EMERGENCY
            //                                                     , A.TUBE_CODE
            //                                                     , NVL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME  
            //                                                     , A.SPECIMEN_SER 
            //                                                     , FN_CPL_SUB_COMMENT(A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)                 COMMENT_JU_CODE
            //                                                     , A.FKOCS1003
            //                                                     , NVL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN
            //                                                     , DECODE(A.PART_JUBSU_DATE, NULL, 'N', 'Y')     PART_JUBSU_FLAG
            //                                                     , DECODE(A.GUM_JUBSU_DATE, NULL, 'N', 'Y')      GUM_JUBSU_FLAG
            //                                                     , A.DUMMY       
            //                                                     , DECODE(C.GROUP_GUBUN,'03','Y','N')            MODIFY_YN
            //                                                     , DECODE(A.HANGMOG_CODE,A.GROUP_HANGMOG,DECODE(C.GROUP_GUBUN,'02','N','Y'),'N')    MODIFY_YN_1
            //                                                     , A.JUNDAL_GUBUN
            //                                                     , FN_CPL_LOAD_CODE_NAME('01',A.JUNDAL_GUBUN)    JUNDAL_GUBUN_NAME
            //                                                     , A.JUBSUJA   
            //                                                     , A.ORDER_DATE
            //                                                     , A.BUNHO     
            //                                                     , A.JUBSU_DATE
            //                                                     , A.JUBSU_TIME
            //                                                     , A.ORDER_TIME
            //                                                     , A.GROUP_HANGMOG
            //                                                     , C.SPCIAL_NAME
            //                                                     --, DECODE(A.JUBSU_DATE, NULL, FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003), NULL) CAN_YN
            //                                                     , FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) CAN_YN
            //                                                     , C.BARCODE BARCODE
            //                                                     , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE) BARCODE_NAME
            //                                                     , FN_XRT_LOAD_COMMENT(A.FKOCS1003, A.FKOCS2003) DOC_COMMENT
            //                                                     , C.UITAK_CODE
            //                                                     , NVL(C.MIDDLE_RESULT, 'N')                              MIDDLE_RESULT
            //                                                  FROM CPL0001 F
            //                                                     , CPL0109 D
            //                                                     , CPL0101 C
            //                                                     , CPL0109 B
            //                                                     , OCS1003 O
            //                                                     , CPL2010 A
            //                                                 WHERE A.HOSP_CODE                = :f_hosp_code
            //                                                   AND B.HOSP_CODE(+)             = A.HOSP_CODE
            //                                                   AND C.HOSP_CODE                = A.HOSP_CODE
            //                                                   AND D.HOSP_CODE(+)             = A.HOSP_CODE
            //                                                   AND F.HOSP_CODE(+)             = C.HOSP_CODE
            //                                                   AND A.ORDER_DATE               = :f_order_date
            //                                                   --
            //                                                   AND A.GROUP_SER                = :f_group_ser
            //
            //                                                   AND A.BUNHO                    = :f_bunho
            //                                                   AND A.GWA                      = :f_gwa
            //                                                   AND NVL(A.ORDER_TIME,'0000')   = NVL(:f_order_time,'0000')
            //                                                   --AND NVL(A.GUBUN,'%')           LIKE :f_gubun||'%'
            //                                                   AND A.DOCTOR                   = :f_doctor
            //                                                   AND A.IN_OUT_GUBUN             = 'O'
            //                                                   AND A.JUBSU_DATE               = :f_jubsu_date
            //                                                   AND A.JUBSU_TIME               = :f_jubsu_time
            //                                                   AND A.JUBSUJA                  = :f_jubsuja
            //                                                   AND (  ( :f_reser_yn = 'Y' AND A.RESER_DATE = :f_reser_date )
            //                                                       OR ( :f_reser_yn = 'N' AND A.RESER_DATE IS NULL ) )   
            //                                                   AND NVL(A.DC_YN,'N')           = 'N'
            //                                                   AND ( (A.AFTER_ACT_YN IS NULL) OR 
            //                                                       (A.AFTER_ACT_YN =  'N' ) )
            //                                                   AND B.CODE(+)                  = A.SPECIMEN_CODE
            //                                                   AND B.CODE_TYPE(+)             = '04'
            //                                                   AND C.HANGMOG_CODE             = A.HANGMOG_CODE
            //                                                   AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE
            //                                                   AND C.EMERGENCY                = A.EMERGENCY
            //                                                   AND D.CODE(+)                  = A.TUBE_CODE
            //                                                   AND D.CODE_TYPE(+)             = '02'
            //                                                   AND F.SLIP_CODE(+)             = C.SLIP_CODE
            //
            //                                                   AND O.HOSP_CODE                = A.HOSP_CODE
            //                                                   AND O.PKOCS1003                = A.FKOCS1003
            //                                                   AND (:f_emergency_yn = 'N' AND NVL(O.EMERGENCY, 'N') = 'N'
            //                                                     OR :f_emergency_yn = 'Y' AND NVL(O.EMERGENCY, 'N') = 'Y')
            //                                              ORDER BY C.UITAK_CODE,
            //                                                       LPAD(A.GROUP_HANGMOG,10,'0'),
            //                                                       DECODE(A.GROUP_HANGMOG, A.HANGMOG_CODE, 1, 2 ),
            //                                                       LPAD(A.HANGMOG_CODE,10,'0'),
            //                                                       A.TUBE_CODE,
            //                                                       A.ORDER_TIME,
            //                                                       A.JUNDAL_GUBUN,
            //                                                       A.SPECIMEN_CODE,
            //                                                       NVL(C.SERIAL,'9999999999')";
            //            }
            this.grdSpecimen.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSpecimen.SetBindVarValue("f_order_date", this.grdOrder.GetItemValue(this.grdOrder.CurrentRowNumber, "order_date").ToString());
            this.grdSpecimen.SetBindVarValue("f_bunho", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"));
            this.grdSpecimen.SetBindVarValue("f_gwa", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gwa"));
            this.grdSpecimen.SetBindVarValue("f_order_time", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_time"));
            //this.grdSpecimen.SetBindVarValue("f_gubun", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gubun"));
            this.grdSpecimen.SetBindVarValue("f_doctor", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "doctor"));
            //this.grdSpecimen.SetBindVarValue("f_in_out_gubun", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun"));
            this.grdSpecimen.SetBindVarValue("f_reser_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "reser_date"));

            this.grdSpecimen.SetBindVarValue("f_jubsu_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
            this.grdSpecimen.SetBindVarValue("f_jubsu_time", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time"));
            this.grdSpecimen.SetBindVarValue("f_jubsuja", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsuja"));

            this.grdSpecimen.SetBindVarValue("f_group_ser", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "group_ser"));

            //this.grdSpecimen.SetBindVarValue("f_reser_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "reser_yn"));
            //this.grdSpecimen.SetBindVarValue("f_emergency_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "emergency_yn"));
            this.grdSpecimen.SetBindVarValue("f_reser_yn", this.reserYn);
            this.grdSpecimen.SetBindVarValue("f_emergency_yn", this.emergencyYn);
        }

        private void grdSpecimen_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.rbxMijubsu.Checked == true) this.MakeJubsu();

            this.setGrdHeaderImage(this.grdSpecimen);
        }

        #region 접수체크 메소드
        private void MakeJubsu()
        {
            for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            {
                this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
            }
        }
        #endregion

        private void ShowNyo()
        {
            try
            {
                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                {
                    if (this.grdSpecimen.GetItemString(i, "spcial_name") == "01")
                    {
                        string bunho = this.grdSpecimen.GetItemString(i, "bunho");
                        string order_date = this.grdSpecimen.GetItemString(i, "order_date");
                        string pkocskey = this.grdSpecimen.GetItemString(i, "fkocs1003");
                        string in_out_gubun = this.grdOrder.GetItemString(i, "in_out_gubun"); ;
                        string hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");

                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", bunho);
                        openParams.Add("order_date", order_date);
                        openParams.Add("pkocskey", pkocskey);
                        openParams.Add("in_out_gubun", in_out_gubun);
                        openParams.Add("hangmog_code", hangmog_code);

                        if (pkocskey.Trim().Length > 0)
                        {
                            XScreen.OpenScreenWithParam(this, "CPLS", "CPL1000U03", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                    }
                    else if (this.grdSpecimen.GetItemString(i, "spcial_name") == "03")
                    {
                        string bunho = this.grdSpecimen.GetItemString(i, "bunho");
                        string order_date = this.grdSpecimen.GetItemString(i, "order_date");
                        string pkocskey = this.grdSpecimen.GetItemString(i, "fkocs1003");
                        string in_out_gubun = this.grdOrder.GetItemString(i, "in_out_gubun"); ;
                        string hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");

                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", bunho);
                        openParams.Add("order_date", order_date);
                        openParams.Add("pkocskey", pkocskey);
                        openParams.Add("in_out_gubun", in_out_gubun);
                        openParams.Add("hangmog_code", hangmog_code);

                        if (pkocskey.Trim().Length > 0)
                        {
                            XScreen.OpenScreenWithParam(this, "CPLS", "CPL1000U00", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                    }
                    else if (this.grdSpecimen.GetItemString(i, "spcial_name") == "04")
                    {
                        string bunho = this.grdSpecimen.GetItemString(i, "bunho");
                        string order_date = this.grdSpecimen.GetItemString(i, "order_date");
                        string pkocskey = this.grdSpecimen.GetItemString(i, "fkocs1003");
                        string in_out_gubun = this.grdOrder.GetItemString(i, "in_out_gubun"); ;
                        string hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");

                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", bunho);
                        openParams.Add("order_date", order_date);
                        openParams.Add("pkocskey", pkocskey);
                        openParams.Add("in_out_gubun", in_out_gubun);
                        openParams.Add("hangmog_code", hangmog_code);

                        if (pkocskey.Trim().Length > 0)
                        {
                            XScreen.OpenScreenWithParam(this, "CPLS", "CPL1000U01", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                    }
                    else if (this.grdSpecimen.GetItemString(i, "spcial_name") == "05")
                    {
                        string bunho = this.grdSpecimen.GetItemString(i, "bunho");
                        string order_date = this.grdSpecimen.GetItemString(i, "order_date");
                        string pkocskey = this.grdSpecimen.GetItemString(i, "fkocs1003");
                        string in_out_gubun = this.grdOrder.GetItemString(i, "in_out_gubun"); ;
                        string hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");

                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", bunho);
                        openParams.Add("order_date", order_date);
                        openParams.Add("pkocskey", pkocskey);
                        openParams.Add("in_out_gubun", in_out_gubun);
                        openParams.Add("hangmog_code", hangmog_code);

                        if (pkocskey.Trim().Length > 0)
                        {
                            XScreen.OpenScreenWithParam(this, "CPLS", "CPL1000U02", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("Message[" + ex.Message + "]");
                //XMessageBox.Show("Source[" + ex.Source + "]");
                //XMessageBox.Show("StackTrace[" + ex.StackTrace + "]");
            }
        }
        #endregion

        #region fwkPa_QueryStarting
        private void fwkPa_QueryStarting(object sender, CancelEventArgs e)
        {
            //fwkPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //if (this.rbxJubsu.Checked == true)
            //    this.fwkPa.SetBindVarValue("jubsu_yn", "Y");
            //else
            //    this.fwkPa.SetBindVarValue("jubsu_yn", "N");

        }
        #endregion

        #region grdSpecimen_GridColumnProtectModify
        private void grdSpecimen_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "jubsu_flag")
            {
                string hangmog_code = this.grdSpecimen.GetItemString(e.RowNumber, "hangmog_code");
                string group_hangmog = this.grdSpecimen.GetItemString(e.RowNumber, "group_hangmog");
                string part_yn = this.grdSpecimen.GetItemString(e.RowNumber, "part_jubsu_flag");
                if (hangmog_code == group_hangmog)
                {
                    e.Protect = false;
                }
                else
                {
                    e.Protect = true;
                }

                //if ( part_yn == "Y" )
                //e.Protect = true;
            }
            else if (e.ColName == "print_yn")
            {
                if (this.rbxJubsu.Checked)
                    e.Protect = false;
                else if (this.rbxMijubsu.Checked)
                    e.Protect = true;
            }
        }
        #endregion

        #region 검체그리드 아이템체인지
        private void grdSpecimen_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            string middle_result = this.grdSpecimen.GetItemString(e.RowNumber, "middle_result");

            if (this.rbxJubsu.Checked == true)
            {
                // 検査時間の間をおいて検査する項目なので一緒にチェックされない様に
                if (middle_result != "Y")
                {
                    if (e.ColName == "jubsu_flag")
                    {
                        //string hangmog_code = this.grdSpecimen.GetItemString(e.RowNumber, "hangmog_code");
                        //string group_hangmog = this.grdSpecimen.GetItemString(e.RowNumber,"group_hangmog");
                        string specimen_ser = this.grdSpecimen.GetItemString(e.RowNumber, "specimen_ser");

                        for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                        {
                            //if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "fkocs1003") == fkocs1003))
                            if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "specimen_ser") == specimen_ser))
                            {
                                if (e.ChangeValue.ToString() == "Y")
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
                                }
                                else
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
                                }
                            }
                        }
                    }
                }

                if (e.ColName == "print_yn")
                {

                    for (int i = 0; i < grdTube.RowCount; i++)
                    {
                        if (grdSpecimen.GetItemString(grdSpecimen.CurrentRowNumber, "tube_name") == grdTube.GetItemString(i, "tube_name"))
                        {
                            grdTube.SetItemValue(i, "print_yn", e.ChangeValue);
                        }
                    }

                    //string specimen_ser = this.grdSpecimen.GetItemString(e.RowNumber, "specimen_ser");
                    //string tube_name = this.grdSpecimen.GetItemString(e.RowNumber, "tube_name");

                    //if (tube_name != "")
                    //{
                    //    for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                    //    {
                    //        if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "specimen_ser") == specimen_ser))
                    //        {
                    //            this.grdSpecimen.SetItemValue(i, "print_yn", e.ChangeValue.ToString());
                    //        }
                    //    }

                    //    for (int i = 0; i < this.grdTube.RowCount; i++)
                    //    {
                    //        if (grdTube.GetItemString(i, "tube_name") == tube_name)
                    //            grdTube.SetItemValue(i, "print_yn", e.ChangeValue.ToString());
                    //    }
                    //}
                }
            }

            if (this.rbxMijubsu.Checked == true)
            {
                if (e.ColName == "jubsu_flag")
                {
                    //string hangmog_code = this.grdSpecimen.GetItemString(e.RowNumber, "hangmog_code");
                    //string group_hangmog = this.grdSpecimen.GetItemString(e.RowNumber,"group_hangmog");
                    string uitak_code = this.grdSpecimen.GetItemString(e.RowNumber, "uitak_code");
                    string tube_code = this.grdSpecimen.GetItemString(e.RowNumber, "tube_code");

                    // 検査時間の間をおいて検査する項目なので一緒にチェックされない様に
                    if (middle_result != "Y")
                    {
                        for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                        {
                            //if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "fkocs1003") == fkocs1003))
                            if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "uitak_code") == uitak_code) && (this.grdSpecimen.GetItemString(i, "tube_code") == tube_code))
                            {
                                if (e.ChangeValue.ToString() == "Y")
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
                                }
                                else
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        private void fbxBunho_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ////환자번호 9자리로 변경
                //if (this.laySujinNo.QueryLayout())
                //{
                //    fbxBunho.SetDataValue(laySujinNo.GetItemValue("bunho"));
                //}
                //if (paBox.BunHo.GetDataValue().ToString() != "")
                //{
                //    fbxBunho.SetEditValue(IHIS.Framework.BizCodeHelper.GetStandardBunHo(fbxBunho.GetDataValue().ToString()));
                //    fbxBunho.AcceptData();
                //}
            }
        }

        #region 바코드 프린터 설정
        private void SetPrint()
        {
            this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

            if (printSetName == "")
            {
                this.printDialog1.Document = this.printDocument1;
            }
            else
            {
                this.printDialog1.PrinterSettings.PrinterName = printSetName;
            }

            DialogResult dr = this.printDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //Get the Copy times
                int nCopy = this.printDocument1.PrinterSettings.Copies;
                //Get the number of Start Page
                int sPage = this.printDocument1.PrinterSettings.FromPage;
                //Get the number of End Page
                int ePage = this.printDocument1.PrinterSettings.ToPage;
                //Get the printer name
                string PrinterName = this.printDialog1.PrinterSettings.PrinterName; //this.printDocument1.PrinterSettings.PrinterName;

                //                string cmdText1 = @" UPDATE ADM3300
                //                                       SET USER_ID         = :q_user_id
                //                                         , UP_TIME         = SYSDATE
                //                                         , B_PRINT_NAME    = :f_b_print_name
                //                                     WHERE HOSP_CODE       = :f_hosp_code 
                //                                       AND IP_ADDR         = :f_ip_addr";

                //                string cmdText2 = @"INSERT INTO ADM3300
                //                                          ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
                //                                            USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
                //                                        VALUES 
                //                                          ( :t_trm_id, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
                //                                            NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name)
                //                                        ";

                //                BindVarCollection bc = new BindVarCollection();
                //                bc.Add("q_user_id", UserInfo.UserID);
                //                bc.Add("f_b_print_name", PrinterName);
                //                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                //                bc.Add("f_ip_addr", NetInfo.ClientIP.ToString());

                //                if (!Service.ExecuteNonQuery(cmdText1, bc))
                //                {
                //                    if (Service.ErrFullMsg == "Execute Error(Data does not changed)")
                //                    {
                //                        cmdText1 = @"SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
                //                                       FROM ADM3300
                //                                      WHERE HOSP_CODE = :f_hosp_code  ";

                //                        object t_trm_id = Service.ExecuteScalar(cmdText1, bc);

                //                        if (!TypeCheck.IsNull(t_trm_id))
                //                        {
                //                            bc.Add("t_trm_id", t_trm_id.ToString());
                //                        }

                //                        if (!Service.ExecuteNonQuery(cmdText2, bc))
                //                        {
                //                            XMessageBox.Show(Service.ErrFullMsg);
                //                        }
                //                    }
                //                    else
                //                    {
                //                        XMessageBox.Show(Service.ErrFullMsg);
                //                    }
                //                }

                //                string cmdText = @" DECLARE 
                //    
                //                                        T_TRM_ID VARCHAR2(8) := ''; 
                //
                //                                    BEGIN
                //                                        UPDATE ADM3300
                //                                           SET USER_ID         = :q_user_id
                //                                             , UP_TIME         = SYSDATE
                //                                             , B_PRINT_NAME    = :f_b_print_name
                //                                         WHERE HOSP_CODE       = :f_hosp_code 
                //                                           AND IP_ADDR         = :f_ip_addr;
                //                                           
                //                                              
                //                                           IF SQL%NOTFOUND THEN       
                //                                             
                //                                             SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
                //                                               INTO T_TRM_ID
                //                                               FROM ADM3300
                //                                              WHERE HOSP_CODE = :f_hosp_code;
                //                                              
                //                                             INSERT INTO ADM3300
                //                                                  ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
                //                                                    USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
                //                                                VALUES 
                //                                                  ( T_TRM_ID, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
                //                                                    NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name);       
                //                                                    
                //                                           END IF; 
                //
                //                                    END;";

                //                BindVarCollection bc = new BindVarCollection();
                //                bc.Add("q_user_id", UserInfo.UserID);
                //                bc.Add("f_b_print_name", PrinterName);
                //                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                //                bc.Add("f_ip_addr", NetInfo.ClientIP.ToString());

                //tungtx
                CPL2010U00SetPrintArgs args = new CPL2010U00SetPrintArgs(UserInfo.UserID, PrinterName, NetInfo.ClientIP.ToString());
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, CPL2010U00SetPrintArgs>(args);

                //if (!Service.ExecuteNonQuery(cmdText, bc))
                if (result.ExecutionStatus != ExecutionStatus.Success)
                {
                    XMessageBox.Show(Resources.CPL_XMessageBox16 + Service.ErrFullMsg, Resources.CPL_Caption6, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnPrintSetup_Click(object sender, System.EventArgs e)
        {
            SetPrint();
        }
        #endregion

        #region 프린터 설정 과 바코드 출력
        private void SetPrintBacode()
        {
            //바코드프린터명 가져오기
            this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

            if (this.grdSpecimen.RowCount < 1) return;
            //MED 10094
            InitDataWindow();

            dwBarcode.Reset();
            layBarcode.Reset();

            ArrayList SpecimenSerArr = new ArrayList();
            //string pre_specimen_ser = "";

            for (int i = 0; i < grdSpecimen.RowCount; i++)
            {
                if (grdSpecimen.GetItemString(i, "print_yn") == "Y")
                {
                    //if ( pre_specimen_ser != grdSpecimen.GetItemString(i,"specimen_ser") )
                    //{
                    //    SpecimenSerArr.Add(grdSpecimen.GetItemString(i,"specimen_ser"));
                    //}
                    //pre_specimen_ser = grdSpecimen.GetItemString(i,"specimen_ser");
                    if (!SpecimenSerArr.Contains(grdSpecimen.GetItemString(i, "specimen_ser")))
                    {
                        SpecimenSerArr.Add(grdSpecimen.GetItemString(i, "specimen_ser"));
                    }
                }
            }

            if (SpecimenSerArr.Count > 0)
            {
                SpecimenSerArr.Sort();

                for (int i = 0; i < SpecimenSerArr.Count; i++)
                {
                    string specimen_ser = SpecimenSerArr[i].ToString();
                    this.layBarcodeTemp2.SetBindVarValue("f_specimen_ser", specimen_ser);
                    this.layBarcodeTemp2.QueryLayout(true);

                    if (layBarcode2.RowCount > 0)
                    {
                        //한껀씩 출력 보냄
                        foreach (DataRow row in this.layBarcode2.LayoutTable.Rows)
                        {
                            dwBarcode.Reset();
                            layBarcodeOne.Reset();
                            this.layBarcodeOne.LayoutTable.ImportRow(row);

                            dwBarcode.FillData(layBarcodeOne.LayoutTable);
                            dwBarcode.PrintProperties.PrinterName = printSetName;
                            try
                            {
                                dwBarcode.Print();

                            }
                            catch { }

                        }
                    }
                }
            }
            else
            {
                string specimen_ser = grdSpecimen.GetItemString(grdSpecimen.CurrentRowNumber, "specimen_ser");
                this.layBarcodeTemp2.SetBindVarValue("f_specimen_ser", specimen_ser);
                this.layBarcodeTemp2.QueryLayout(true);

                if (layBarcode2.RowCount > 0)
                {
                    //한껀씩 출력 보냄
                    foreach (DataRow row in this.layBarcode2.LayoutTable.Rows)
                    {
                        dwBarcode.Reset();
                        layBarcodeOne.Reset();
                        this.layBarcodeOne.LayoutTable.ImportRow(row);

                        dwBarcode.FillData(layBarcodeOne.LayoutTable);
                        dwBarcode.PrintProperties.PrinterName = printSetName;
                        try
                        {
                            dwBarcode.Print();
                        }
                        catch { }
                    }
                }
            }
        }
        #endregion

        private void grdSpecimen_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (this.grdSpecimen.RowCount > 0)
            {
                this.grdTube.QueryLayout(false);

                for (int i = 0; i < grdTube.RowCount; i++)
                {
                    for (int j = 0; j < grdSpecimen.RowCount; j++)
                    {
                        if (grdSpecimen.GetItemString(j, "tube_name") == grdTube.GetItemString(i, "tube_name"))
                        {
                            grdTube.SetItemValue(i, "print_yn", grdSpecimen.GetItemString(j, "print_yn"));
                        }
                    }
                    
                }
            }
        }

        public event RowFocusChangedEventHandler RowFocusHandler;

        private void grdOrder_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            string jubsuja = this.grdOrder.GetItemString(e.CurrentRow, "jubsuja_name");
            if (jubsuja.Equals(""))
                // 実施者に 現在ログインしている IDを セットする｡
                this.cbxActor.SetDataValue(UserInfo.UserID);
            else
            {
                // 採血者をセットする。
                this.cbxActor.Text = this.grdOrder.GetItemString(e.CurrentRow, "jubsuja_name");
                this.CbxActorText = this.grdOrder.GetItemString(e.CurrentRow, "jubsuja_name");
                this.CbxActorCode = this.grdOrder.GetItemString(e.CurrentRow, "jubsuja");
            }

            this.grdSpecimen.QueryLayout(false);

            if (this.RowFocusHandler != null)
            {
                this.RowFocusHandler(this, e);
            }
            //this.ShowNyo(); 파트접수에서 함
            //this.grdChamgo.QueryLayout(false);
        }

        #region 환자 파인드 창
        private void fbxBunho_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if(dlg == null)
            //{
            //    dlg = new PAQRY(dtpOrderDate.GetDataValue(), rbxMijubsu.Checked ? "N" : "Y" );
            //    dlg.Owner = this.ParentForm;
            //    Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            //    int X = screen.Right - dlg.Size.Width;
            //    int Y = screen.Bottom - dlg.Size.Height - mHeight;
            //    dlg.Location = new Point(X, Y);
            //    dlg.Show();
            //}
            //else
            //{
            //    dlg.Dispose();
            //    dlg = new PAQRY(dtpOrderDate.GetDataValue(), rbxMijubsu.Checked ? "N" : "Y" );
            //    dlg.Owner = this.ParentForm;
            //    Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            //    int X = screen.Right - dlg.Size.Width;
            //    int Y = screen.Bottom - dlg.Size.Height - mHeight;
            //    dlg.Location = new Point(X, Y);
            //    dlg.Show();
            //}

        }
        #endregion

        #region 바코드 프린트 관련 셋팅

        private void layPrintName_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPrintName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layPrintName.SetBindVarValue("f_ip_addr", NetInfo.ClientIP.ToString());
        }

        #endregion

        #region [一括受付ボタン関連]
        private void btnChkAllJubsu_Click(object sender, EventArgs e)
        {
            //if (this.chkAllJubsuYN.Equals("Y"))
            //{
            //    this.btnChkAllJubsu.ImageIndex = 1;
            //    this.chkAllJubsuYN = "N";

            //    string hangmog_code = string.Empty;
            //    string group_hangmog = string.Empty;
            //    string part_yn = string.Empty;

            //    for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            //    {
            //        hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");
            //        group_hangmog = this.grdSpecimen.GetItemString(i, "group_hangmog");
            //        part_yn = this.grdSpecimen.GetItemString(i, "part_jubsu_flag");

            //        this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
            //    }
            //    this.grdSpecimen.Refresh();
            //}
            //else
            //{
            //    this.btnChkAllJubsu.ImageIndex = 0;
            //    this.chkAllJubsuYN = "Y";

            //    for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            //        this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
            //    this.grdSpecimen.Refresh();
            //}
        }

        private void reset_BtnChkAllJubsu()
        {
            //this.btnChkAllJubsu.ImageIndex = 3;
            this.chkAllJubsuYN = "Y";
        }
        #endregion

        private bool groupPartYn(string aGroup_hangmog)
        {
            string group_hangmog = string.Empty;
            string part_yn = string.Empty;

            for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            {
                group_hangmog = this.grdSpecimen.GetItemString(i, "group_hangmog");
                part_yn = this.grdSpecimen.GetItemString(i, "part_jubsu_flag");
                if (group_hangmog == aGroup_hangmog)
                {
                    //그룹 항목중 하나라도 파트접수가 되면 취소 안됨
                    if (part_yn == "Y") return false;
                }
            }

            return true;
        }

        private void fbxBunho_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {

            //if (e.DataValue == "")
            //{
            //    this.paInfoBox.SetPatientID("");
            //    this.ClearInputControl();
            //    this.ClearXEditGrid();
            //    return;
            //}

            //string bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
            //this.fbxBunho.SetDataValue(bunho);

            //if (firstOpen)
            //{
            //    CPL2010U00OpenScreenCompositeSecond();
            //    firstOpen = false;
            //}
            //this.vsvPa.QueryLayout();

            ////if ((this.vsvPa.GetItemValue("suname").ToString() == "")&&(e.DataValue!=""))
            ////{
            ////    e.Cancel = true;
            ////    return;
            ////}



            ////this.LoadPationtInfoByBunho();

            //this.paInfoBox.SetPatientID(this.fbxBunho.GetDataValue());
            //this.dbxAddress.SetDataValue(this.paInfoBox.Address2);
            //this.dbxBirth.SetDataValue(this.paInfoBox.Birth);
            //this.dbxSexAge.SetDataValue(this.paInfoBox.Sex + "/" + this.paInfoBox.YearAge);
            //this.dbxSuname.SetDataValue(this.paInfoBox.SuName);
            //this.dbxSuname2.SetDataValue(this.paInfoBox.SuName2);
            //this.dbxTel.SetDataValue(this.paInfoBox.Tel);
            //// 20070312 Add Start
            //this.layChkNames.QueryLayout(true);
            //// 20070312 Add End
            

            ////#region 주사 유무 확인 2011.11.07 이흥도

            ////BindVarCollection bindVar = new BindVarCollection();

            ////string strCmd = @"SELECT FN_INJ_CPL_CHK_YN(:f_io_gubun, :f_bunho, :f_order_date, 'INJ') FROM DUAL";

            ////bindVar.Add("f_io_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
            ////bindVar.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
            //////bindVar.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
            ////bindVar.Add("f_order_date", this.dtpOrderDate.GetDataValue());
            ////object retVal = Service.ExecuteScalar(strCmd, bindVar);

            ////if (retVal != null)
            ////{
            ////    if (retVal.ToString() == "Y")
            ////    {
            ////        this.btnJusa.Visible = true;
            ////        this.pbxJusa.Visible = true;
            ////        btnJusa.Text = "注射有り";
            ////    }
            ////    else
            ////    {
            ////        this.btnJusa.Visible = false;
            ////        this.pbxJusa.Visible = false;
            ////        btnJusa.Text = "注射無し";
            ////    }
            ////}
            ////#endregion

            //// 患者リストから選択されている　患者のオーダ情報取得
            //this.grdOrder.QueryLayout(false);
            //this.check_inj_cpl_order();
        }

        #region 환자선택/입력 후 벨리데이션이 성공이면,
        private void LoadPationtInfoByBunho()
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(this.paBox.BunHo);

            if (Service.ExecuteProcedure("PR_CPL_BUNHO_LOAD_MIN", inputList, outputList))
            {
                if (outputList.Count > 0)
                {
                    this.layPa.SetItemValue("suname", outputList[0].ToString());
                    //this.layPa.SetItemValue("sujumin1", outputList[1].ToString());
                    //this.layPa.SetItemValue("sujumin2", outputList[2].ToString());
                    this.layPa.SetItemValue("sex", outputList[3].ToString());
                    this.layPa.SetItemValue("age", outputList[4].ToString());
                    this.layPa.SetItemValue("birth", outputList[5].ToString() == "" ? "" : DateTime.Parse(outputList[5].ToString()).ToShortDateString());
                    this.layPa.SetItemValue("address", outputList[6].ToString());
                    this.layPa.SetItemValue("ho_dong", outputList[7].ToString());
                    this.layPa.SetItemValue("ho_code", outputList[8].ToString());
                    this.layPa.SetItemValue("gwa", outputList[9].ToString());
                    this.layPa.SetItemValue("gwa_name", outputList[10].ToString());
                    this.layPa.SetItemValue("doctor", outputList[11].ToString());
                    this.layPa.SetItemValue("doctor_name", outputList[12].ToString());
                    this.layPa.SetItemValue("resident", outputList[13].ToString());
                    this.layPa.SetItemValue("resident_name", outputList[14].ToString());
                    this.layPa.SetItemValue("in_out_gubun", outputList[15].ToString());
                    this.layPa.SetItemValue("tel", outputList[16].ToString());
                    this.layPa.SetItemValue("jubsu_date", outputList[17].ToString() == "" ? "" : DateTime.Parse(outputList[17].ToString()).ToShortDateString());
                    this.layPa.SetItemValue("jubsu_time", outputList[18].ToString());
                    this.layPa.SetItemValue("jubsuja", outputList[19].ToString());
                    this.layPa.SetItemValue("part_jubsu_date", outputList[20].ToString() == "" ? "" : DateTime.Parse(outputList[20].ToString()).ToShortDateString());
                    this.layPa.SetItemValue("part_jubsu_time", outputList[21].ToString());
                    this.layPa.SetItemValue("part_jubsuja", outputList[22].ToString());
                    this.layPa.SetItemValue("tat1", outputList[23].ToString());
                    this.layPa.SetItemValue("tat2", outputList[24].ToString());
                    this.layPa.SetItemValue("pa_note", outputList[25].ToString());
                    this.layPa.SetItemValue("flag", outputList[26].ToString());
                    this.layPa.SetItemValue("sex_age", outputList[3].ToString() + " / " + outputList[4].ToString());
                }
            }
            /*
             *  PR_CPL_BUNHO_LOAD_MIN(:f_bunho          ,:o_suname         ,:o_sujumin1      , 
                                      :o_sujumin2       ,:o_sex            ,:o_age           ,
                                      :o_birth          ,:o_address        ,:o_ho_dong       ,
                                      :o_ho_code        ,:o_gwa            ,:o_gwa_name      ,
                                      :o_doctor         ,:o_doctor_name    ,:o_resident      ,
                                      :o_resident_name  ,:o_in_out_gubun   ,:o_tel           ,
                                      :o_jubsu_date     ,:o_jubsu_time     ,:o_jubsuja       ,
                                      :o_part_jubsu_date,:o_part_jubsu_time,:o_part_jubsuja  ,
                                      :o_tat1           ,:o_tat2           ,:o_pa_note       ,
                                      :o_flag           );
            */


        }
        #endregion

        private void check_inj_cpl_order()
        {
            #region 주사 유무 확인 2011.11.07 이흥도

            if (this.grdOrder.CurrentRowNumber < 0)
            {
                return;

            }
            //BindVarCollection bindVar = new BindVarCollection();
            //string strCmd = @"SELECT FN_INJ_CPL_CHK_YN(:f_io_gubun, :f_bunho, :f_order_date, 'INJ') FROM DUAL";

            //bindVar.Add("f_io_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
            //bindVar.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
            //bindVar.Add("f_order_date", this.dtpOrderDate.GetDataValue());
            //object retVal = Service.ExecuteScalar(strCmd, bindVar);

            CPL2010U00CheckInjCplOrderArgs args = new CPL2010U00CheckInjCplOrderArgs();
            args.Bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho");
            args.IoGubun = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun");
            args.OrderDate = this.dtpOrderDate.GetDataValue();
            CPL2010U00CheckInjCplOrderResult result =
                CloudService.Instance.Submit<CPL2010U00CheckInjCplOrderResult, CPL2010U00CheckInjCplOrderArgs>(args);

            //if (retVal != null)
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                //if (retVal.ToString() == "Y")
                if (result.FnInjCplChkYn == "Y")
                {
                    //this.btnJusa.Visible = true;
                    //this.pbxJusa.Visible = true;
                    //btnJusa.Text = Resources.btnJusaText1;
                }
                else
                {
                    //this.btnJusa.Visible = false;
                    //this.pbxJusa.Visible = false;
                    //btnJusa.Text = Resources.btnJusaText2;
                }
            }
            #endregion
        }

        #region 그리드 더블 클릭(인쇄 자동체크,언체크)
        private void grdSpecimen_DoubleClick(object sender, System.EventArgs e)
        {
            bool is_checked = false;

            if (this.grdSpecimen.CurrentColName != "print_yn")
                return;

            for (int i = 0; i < grdSpecimen.RowCount; i++)
            {
                if (grdSpecimen.GetItemString(i, "print_yn") == "Y")
                {
                    is_checked = true;
                    break;
                }
            }

            if (is_checked)
            {
                for (int i = 0; i < grdSpecimen.RowCount; i++)
                {
                    grdSpecimen.SetItemValue(i, "print_yn", "N");
                }
            }
            else
            {
                for (int i = 0; i < grdSpecimen.RowCount; i++)
                {
                    grdSpecimen.SetItemValue(i, "print_yn", "Y");
                }
            }
        }
        #endregion

        private void grdOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdChamgo.Reset();
            this.grdSpecimen.Reset();
            this.grdTube.Reset();
            this.grdOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOrder.SetBindVarValue("f_bunho", this.paBox.BunHo);
            //this.grdOrder.SetBindVarValue("f_mijubsu", this.mJubsu_yn);
            this.grdOrder.SetBindVarValue("f_mijubsu", this.rbxMijubsu.Checked ? "2" : "3");
            this.grdOrder.SetBindVarValue("f_from_date", this.dtpOrderDate.GetDataValue());
            this.grdOrder.SetBindVarValue("f_to_date", this.dtpOrderToDate.GetDataValue());
            this.grdOrder.SetBindVarValue("f_reser_yn", this.reserYn);
            this.grdOrder.SetBindVarValue("f_emergency_yn", this.emergencyYn);
            this.grdOrder.SetBindVarValue("f_doctor", this.doctor);
        }

        private void grdOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.rbxMijubsu.Checked)
            {
                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    this.grdOrder.SetItemValue(i, "jubsu_date", EnvironInfo.GetSysDate());
                    this.grdOrder.SetItemValue(i, "jubsu_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                }
            }

            //this.grdOrder.ResetUpdate();
        }

        private void layChkNames_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layChkNames.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layChkNames.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layChkNames.SetBindVarValue("f_reser_date", this.dtpOrderDate.GetDataValue());
        }

        private void layChkNames_QueryEnd(object sender, QueryEndEventArgs e)
        {
            string chkNames = "";

            for (int i = 0; i < layChkNames.RowCount; i++)
            {
                chkNames += "," + layChkNames.GetItemString(i, "chkname");
            }

            if (chkNames != "")
                chkNames = chkNames.Substring(1, chkNames.Length - 1);

            if (layChkNames.RowCount > 0)
            {
                if (layChkNames.GetItemString(0, "suname").Length > 0)
                {
                    string msg = (
                        Resources.CPL_XMessageBox17 + layChkNames.GetItemString(0, "suname") + Resources.CPL_layChkNames1 +
                        layChkNames.GetItemString(0, "order_date1") + ", " +
                        layChkNames.GetItemString(0, "order_date2") + Resources.CPL_layChkNames2 +
                        layChkNames.GetItemString(0, "chknames") + ")");
                    XMessageBox.Show(msg);
                }
            }

        }

        private void layBarcodeTemp_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBarcodeTemp.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layBarcodeTemp.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void layBarcodeTemp_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //tungtx
            //if (e.IsSuccess)
            //{
            this.layBarcode.Reset();
            int t_tube_count = 0;
            int rowNum = 0;

            for (int i = 0; i < layBarcodeTemp.RowCount; i++)
            {
                t_tube_count = layBarcodeTemp.GetItemInt(i, "tube_count");

                for (int j = 0; j < t_tube_count; j++)
                {
                    rowNum = this.layBarcode.InsertRow(j - 1);
                    //rowNum = this.layBarcode.InsertRow(0);

                    this.layBarcode.SetItemValue(rowNum, "jundal_gubun", this.layBarcodeTemp.GetItemString(i, "jundal_gubun"));
                    this.layBarcode.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcodeTemp.GetItemString(i, "jundal_gubun_name"));
                    this.layBarcode.SetItemValue(rowNum, "specimen_code", this.layBarcodeTemp.GetItemString(i, "specimen_code"));
                    this.layBarcode.SetItemValue(rowNum, "specimen_name", this.layBarcodeTemp.GetItemString(i, "specimen_name"));
                    this.layBarcode.SetItemValue(rowNum, "tube_code", this.layBarcodeTemp.GetItemString(i, "tube_code"));
                    this.layBarcode.SetItemValue(rowNum, "tube_name", this.layBarcodeTemp.GetItemString(i, "tube_name"));
                    this.layBarcode.SetItemValue(rowNum, "in_out_gubun", this.layBarcodeTemp.GetItemString(i, "in_out_gubun"));
                    this.layBarcode.SetItemValue(rowNum, "specimen_ser", this.layBarcodeTemp.GetItemString(i, "specimen_ser"));
                    this.layBarcode.SetItemValue(rowNum, "bunho", this.layBarcodeTemp.GetItemString(i, "bunho"));
                    this.layBarcode.SetItemValue(rowNum, "suname", this.layBarcodeTemp.GetItemString(i, "suname"));
                    this.layBarcode.SetItemValue(rowNum, "gwa_name", this.layBarcodeTemp.GetItemString(i, "gwa_name"));
                    this.layBarcode.SetItemValue(rowNum, "danger_yn", this.layBarcodeTemp.GetItemString(i, "danger_yn"));
                    this.layBarcode.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcodeTemp.GetItemString(i, "specimen_ser_ba"));
                    this.layBarcode.SetItemValue(rowNum, "jangbi_code", this.layBarcodeTemp.GetItemString(i, "jangbi_code"));
                    this.layBarcode.SetItemValue(rowNum, "jangbi_name", this.layBarcodeTemp.GetItemString(i, "jangbi_name"));
                    this.layBarcode.SetItemValue(rowNum, "gumsa_name_re", this.layBarcodeTemp.GetItemString(i, "gumsa_name_re"));
                    this.layBarcode.SetItemValue(rowNum, "tube_max_amt", this.layBarcodeTemp.GetItemString(i, "tube_max_amt"));
                    this.layBarcode.SetItemValue(rowNum, "tube_numbering", this.layBarcodeTemp.GetItemString(i, "tube_numbering"));
                }

            }

            //                string cmdText = @" UPDATE CPL2010
            //                                   SET DUMMY = NULL
            //                                 WHERE HOSP_CODE     = :f_hosp_code 
            //                                   AND JUBSU_DATE    = to_date(:f_jubsu_date,'YYYY/MM/DD')
            //                                   AND BUNHO         = :f_bunho
            //                                   AND DUMMY         = 'Y'";

            //                BindVarCollection bc = new BindVarCollection();
            //                bc.Add("f_hosp_code", EnvironInfo.HospCode);
            //                bc.Add("f_bunho", this.fbxBunho.GetDataValue());
            //                bc.Add("f_jubsu_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));

            //                Service.ExecuteNonQuery(cmdText, bc);
            //}
        }

        private void layBarcodeTemp2_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                this.layBarcode2.Reset();
                int t_tube_count = 0;
                int rowNum = 0;


                for (int i = 0; i < layBarcodeTemp2.RowCount; i++)
                {
                    t_tube_count = layBarcodeTemp2.GetItemInt(i, "tube_count");

                    for (int j = 0; j < t_tube_count; j++)
                    {
                        rowNum = this.layBarcode2.InsertRow(j - 1);
                        //rowNum = this.layBarcode2.InsertRow(0);

                        this.layBarcode2.SetItemValue(rowNum, "jundal_gubun", this.layBarcodeTemp2.GetItemString(i, "jundal_gubun"));
                        this.layBarcode2.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcodeTemp2.GetItemString(i, "jundal_gubun_name"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_code", this.layBarcodeTemp2.GetItemString(i, "specimen_code"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_name", this.layBarcodeTemp2.GetItemString(i, "specimen_name"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_code", this.layBarcodeTemp2.GetItemString(i, "tube_code"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_name", this.layBarcodeTemp2.GetItemString(i, "tube_name"));
                        this.layBarcode2.SetItemValue(rowNum, "in_out_gubun", this.layBarcodeTemp2.GetItemString(i, "in_out_gubun"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_ser", this.layBarcodeTemp2.GetItemString(i, "specimen_ser"));
                        this.layBarcode2.SetItemValue(rowNum, "bunho", this.layBarcodeTemp2.GetItemString(i, "bunho"));
                        this.layBarcode2.SetItemValue(rowNum, "suname", this.layBarcodeTemp2.GetItemString(i, "suname"));
                        this.layBarcode2.SetItemValue(rowNum, "gwa_name", this.layBarcodeTemp2.GetItemString(i, "gwa_name"));
                        this.layBarcode2.SetItemValue(rowNum, "danger_yn", this.layBarcodeTemp2.GetItemString(i, "danger_yn"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcodeTemp2.GetItemString(i, "specimen_ser_ba"));
                        this.layBarcode2.SetItemValue(rowNum, "jangbi_code", this.layBarcodeTemp2.GetItemString(i, "jangbi_code"));
                        this.layBarcode2.SetItemValue(rowNum, "jangbi_name", this.layBarcodeTemp2.GetItemString(i, "jangbi_name"));
                        this.layBarcode2.SetItemValue(rowNum, "gumsa_name_re", this.layBarcodeTemp2.GetItemString(i, "gumsa_name_re"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_max_amt", this.layBarcodeTemp2.GetItemString(i, "tube_max_amt"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_numbering", this.layBarcodeTemp2.GetItemString(i, "tube_numbering"));
                    }
                }
            }
        }

        private void layBarcodeTemp2_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBarcodeTemp2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdTube_QueryStarting(object sender, CancelEventArgs e)
        {

            //            if (rbxJubsu.Checked == true)
            //            {
            //                grdTube.QuerySQL = @"SELECT X.TUBE_CODE,
            //                                           X.TUBE_NAME,
            //                                           SUM(X.TUBE_COUNT)   CNT
            //                                      FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,
            //                                                        MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE))            TUBE_NAME,
            //                                                        FN_CPL_TUBE_COUNT(A.SPECIMEN_SER)               TUBE_COUNT,
            //                                                        A.HOSP_CODE 
            //                                                   FROM CPL0101 B,
            //                                                        CPL2010 A
            //                                                  WHERE A.HOSP_CODE     = :f_hosp_code
            //                                                    AND B.HOSP_CODE     = A.HOSP_CODE 
            //                                                    --AND A.JUBSU_DATE    = to_date(:f_jubsu_date,'YYYY/MM/DD')
            //                                                    --AND A.JUBSU_TIME    = :f_jubsu_time
            //                                                    AND A.ORDER_DATE    = to_date(:f_order_date,'YYYY/MM/DD')
            //                                                    AND A.ORDER_TIME    = :f_order_time
            //                                                    AND A.BUNHO         = :f_bunho
            //                                                    AND A.JUBSU_DATE    IS NOT NULL
            //                                                    AND B.HANGMOG_CODE  = A.HANGMOG_CODE
            //                                                    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
            //                                                    AND B.EMERGENCY     = A.EMERGENCY
            //                                                  GROUP BY A.HOSP_CODE,
            //                                                        --A.JUNDAL_GUBUN,
            //                                                        --A.SPECIMEN_CODE,
            //                                                        A.TUBE_CODE,
            //                                                        A.IN_OUT_GUBUN,
            //                                                        A.SPECIMEN_SER,
            //                                                        A.GWA,
            //                                                        A.BUNHO      ) X
            //                                     WHERE X.HOSP_CODE = :f_hosp_code
            //                                     GROUP BY X.TUBE_CODE, X.TUBE_NAME
            //                                     ORDER BY 1";

            //                //this.grdTube.SetBindVarValue("f_jubsu_date", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "jubsu_date"));
            //                //this.grdTube.SetBindVarValue("f_jubsu_time", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "jubsu_time"));
            //            }
            //            else if (rbxMijubsu.Checked == true)
            //            {
            //                grdTube.QuerySQL = @"SELECT X.TUBE_CODE,
            //                                           X.TUBE_NAME,
            //                                           SUM(X.TUBE_COUNT)   CNT
            //                                      FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,
            //                                                        MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE))            TUBE_NAME,
            //                                                        1                                                  TUBE_COUNT,
            //                                                        A.HOSP_CODE 
            //                                                   FROM CPL0101 B,
            //                                                        CPL2010 A
            //                                                  WHERE A.HOSP_CODE     = :f_hosp_code
            //                                                    AND B.HOSP_CODE     = A.HOSP_CODE 
            //                                                    AND A.ORDER_DATE    = to_date(:f_order_date,'YYYY/MM/DD')
            //                                                    AND A.ORDER_TIME    = :f_order_time
            //                                                    AND A.BUNHO         = :f_bunho
            //                                                    AND A.JUBSU_DATE    IS NULL
            //                                                    AND B.HANGMOG_CODE  = A.HANGMOG_CODE
            //                                                    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
            //                                                    AND B.EMERGENCY     = A.EMERGENCY
            //                                                  GROUP BY A.HOSP_CODE,
            //                                                        --A.JUNDAL_GUBUN,
            //                                                        --A.SPECIMEN_CODE,
            //                                                        A.TUBE_CODE,
            //                                                        A.IN_OUT_GUBUN,
            //                                                        --A.SPECIMEN_SER,
            //                                                        A.GWA,
            //                                                        A.BUNHO      ) X
            //                                     WHERE X.HOSP_CODE = :f_hosp_code
            //                                     GROUP BY X.TUBE_CODE, X.TUBE_NAME
            //                                     ORDER BY 1";
            //            }
            this.grdTube.SetBindVarValue("f_order_date", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "order_date"));
            this.grdTube.SetBindVarValue("f_order_time", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "order_time"));
            this.grdTube.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdTube.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        //private void grdChamgo_QueryStarting(object sender, CancelEventArgs e)
        //{
        //    this.grdChamgo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        //    this.grdChamgo.SetBindVarValue("f_order_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date"));
        //    this.grdChamgo.SetBindVarValue("f_order_time", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_time"));
        //    this.grdChamgo.SetBindVarValue("f_bunho",        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"));
        //    this.grdChamgo.SetBindVarValue("f_in_out_gubun", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun"));
        //    this.grdChamgo.SetBindVarValue("f_reser_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "reser_date"));
        //}

        #region XSavePerformer

        private int jubsu_cnt = 0;
        private int cancel_cnt = 0;
        private string t_jubsu_gubun = "";
        private string mErrMsg = "";
        //        private class XSavePerformer : IHIS.Framework.ISavePerformer
        //        {

        //            private CPL2010U00 parent = null;
        //            public XSavePerformer(CPL2010U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                string t_in_out_gubun = "";
        //                string t_fkocs = "";
        //                parent.mErrMsg = "";

        //                Hashtable inputList = new Hashtable();
        //                Hashtable outputList = new Hashtable();

        //                item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        //                switch (item.RowState)
        //                { 
        //                    case DataRowState.Modified:

        //                        cmdText = @"SELECT IN_OUT_GUBUN
        //                                         , DECODE(IN_OUT_GUBUN,'O',FKOCS1003,FKOCS2003) FKOCS
        //                                      FROM CPL2010
        //                                     WHERE HOSP_CODE = :f_hosp_code
        //                                       AND PKCPL2010 = :f_pkcpl2010";

        //                        DataTable dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

        //                        if (!TypeCheck.IsNull(dt))
        //                        {
        //                            t_in_out_gubun = dt.Rows[0]["in_out_gubun"].ToString();
        //                            t_fkocs = dt.Rows[0]["fkocs"].ToString();
        //                        }
        //                        else
        //                        {
        //                            parent.mErrMsg = Resources.mErrMsg + Service.ErrFullMsg;
        //                            return false;
        //                        }

        //                        // 受付チェックの場合、「DUMMY　= 'Y'」
        //                        if (item.BindVarList["f_jubsu_flag"].VarValue == "Y")
        //                        {
        //                            parent.jubsu_cnt++;

        //                            cmdText = @"UPDATE CPL2010
        //                                           SET UPD_ID    = :q_user_id
        //                                             , UPD_DATE  = SYSDATE
        //                                             , DUMMY     = 'Y'
        //                                         WHERE HOSP_CODE = :f_hosp_code
        //                                           AND PKCPL2010 = :f_pkcpl2010";

        //                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
        //                            {
        //                                if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
        //                                {
        //                                    parent.mErrMsg = Resources.mErrMsg + Service.ErrFullMsg;
        //                                    return false;
        //                                }
        //                            }
        //                        }
        //                        // 受付チェック取消の場合、「DUMMY　= 'N'」
        //                        else if (item.BindVarList["f_jubsu_flag"].VarValue == "N")
        //                        {
        //                            cmdText = @"  SELECT 'Y'
        //                                            FROM DUAL
        //                                           WHERE EXISTS ( SELECT 'X'
        //                                                            FROM CPL2010
        //                                                           WHERE HOSP_CODE = :f_hosp_code 
        //                                                             AND PKCPL2010 = :f_pkcpl2010
        //                                                             AND SPECIMEN_SER IS NOT NULL)";

        //                            object o_flag2 = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                            if (!TypeCheck.IsNull(o_flag2))
        //                            {
        //                                if (o_flag2.ToString() == "Y")
        //                                {
        //                                    parent.cancel_cnt++;

        //                                    cmdText = @"UPDATE CPL2010
        //                                                   SET UPD_ID    = :q_user_id
        //                                                     , UPD_DATE  = SYSDATE
        //                                                     , DUMMY     = 'N'
        //                                                 WHERE HOSP_CODE = :f_hosp_code 
        //                                                   AND PKCPL2010 = :f_pkcpl2010";

        //                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
        //                                    {
        //                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
        //                                        {
        //                                            parent.mErrMsg = Resources.mErrMsg + Service.ErrFullMsg;
        //                                            return false;
        //                                        }
        //                                    }

        //                                    inputList.Clear();

        //                                    inputList.Add("I_ORDER_DATE", item.BindVarList["f_order_date"].VarValue);
        //                                    inputList.Add("I_BUNHO", item.BindVarList["f_bunho"].VarValue);
        //                                    inputList.Add("I_JUBSUJA", UserInfo.UserID);
        //                                    inputList.Add("I_JUBSU_FLAG", "N");
        //                                    inputList.Add("I_JUBSU_GUBUN", parent.t_jubsu_gubun);// null
        //                                    inputList.Add("I_JUBSU_DATE", item.BindVarList["f_jubsu_date"].VarValue);
        //                                    inputList.Add("I_JUBSU_TIME", item.BindVarList["f_jubsu_time"].VarValue);

        //                                    if (!Service.ExecuteProcedure("PR_CPL_MAKE_SPECIMEN_SER", inputList, outputList))
        //                                    {
        //                                        parent.mErrMsg = Resources.mErrMsg4 + Service.ErrFullMsg;
        //                                        return false;
        //                                    }

        //                                    if (outputList.Count > 0)
        //                                    {
        //                                        if (outputList["IO_FLAG"].ToString() == "N")
        //                                        {
        //                                            parent.mErrMsg = Resources.mErrMsg2;
        //                                            return false;                                        
        //                                        }
        //                                    }

        //                                    cmdText = @"UPDATE CPL2010
        //                                                   SET UPD_ID    = :q_user_id
        //                                                     , UPD_DATE  = SYSDATE
        //                                                     , DUMMY     = NULL
        //                                                 WHERE HOSP_CODE = :f_hosp_code 
        //                                                   AND PKCPL2010 = :f_pkcpl2010";

        //                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
        //                                    {
        //                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
        //                                        {
        //                                            parent.mErrMsg = Resources.mErrMsg + Service.ErrFullMsg;
        //                                            return false;
        //                                        }
        //                                    }

        //                                    if (outputList["IO_FLAG"].ToString() == "N")
        //                                    {
        //                                        return true;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        break;
        //                }
        //                return true;
        //            }
        //        }
        #endregion

        private void grdSpecimen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (e.Button == MouseButtons.Left)
                {

                }
            }
        }

        private void grdTube_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            grdTube.ResetUpdate();
            if (e.ColName == "print_yn")
            {
                for (int i = 0; i < grdSpecimen.RowCount; i++)
                {
                    if (grdTube.GetItemString(grdTube.CurrentRowNumber, "tube_name") == grdSpecimen.GetItemString(i, "tube_name"))
                    {
                        grdSpecimen.SetItemValue(i, "print_yn", e.ChangeValue);
                    }
                }
            }
        }

        private void btnJusa_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
            {
                return;
            }
            IXScreen old_screen = FindScreen("INJS", "INJ1001U01");

            if (old_screen == null)
            {
                CommonItemCollection param = new CommonItemCollection();

                //param.Add("order_date", grdOrder.GetItemValue(grdOrder.CurrentRowNumber, "order_date"));
                param.Add("bunho", this.paBox.BunHo);
                param.Add("order_date", this.dtpOrderDate.GetDataValue());
                param.Add("jubsuja_id", this.cbxActor.GetDataValue());

                //param.Add("gwa", grdPaList.GetItemValue(grdPaList.CurrentRowNumber, "gwa"));
                //param.Add("doctor", grdPaList.GetItemValue(grdPaList.CurrentRowNumber, "doctor"));
                //param.Add("naewon_key", grdPaList.GetItemValue(grdPaList.CurrentRowNumber, "naewon_key"));

                XScreen.OpenScreenWithParam(this, "INJS", "INJ1001U01", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopLeft, param);

            }
            else
            {
                string bunho = this.paBox.BunHo;
                string order_date = this.dtpOrderDate.GetDataValue();
                old_screen.Activate();
                XPatientInfo paInfo = new XPatientInfo(bunho, order_date, "", "", "", PatientPKGubun.Out, this.ScreenName);
                XScreen.SendPatientInfo(paInfo);

            }

        }

        private void grdPaList_QueryStarting(object sender, CancelEventArgs e)
        {
            //            if (this.rbxJubsu.Checked == true)
            //            {
            //                this.grdPaList.QuerySQL = @"/* grd PaList After Jubsu */
            //                                            SELECT A.BUNHO
            //                                                 , MAX(B.SUNAME)
            //                                                 , MAX(A.IN_OUT_GUBUN)
            //                                                 , MAX(FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE)) GWA_NAME
            //                                                 --, MAX(FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003))   TODAY_YN
            //                                                 , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)   RESER_YN
            //                                                 , MAX(A.DOCTOR)
            //                                                 , A.DOCTOR_NAME
            //                                                 --, FN_REQUEST_GWA_NAME('O',A.BUNHO, A.GWA, A.ORDER_DATE)            REQUEST_NAME
            //                                                 , NVL(A.RESER_DATE, A.ORDER_DATE)                                   KIJUN_DATE
            //                                                 , NVL(C.EMERGENCY, 'N')                                             EMERGENCY_YN
            //                                              FROM OCS1003 C
            //                                                 , OUT0101 B
            //                                                 , CPL2010 A
            //                                             WHERE A.HOSP_CODE    = :f_hosp_code
            //                                               AND B.HOSP_CODE    = A.HOSP_CODE 
            //                                               --AND ((A.ORDER_DATE     = TO_DATE(:f_order_date) AND A.RESER_DATE IS NULL )
            //                                               -- OR  (A.RESER_DATE     = TO_DATE(:f_order_date) ))
            //                                               AND ((:f_bunho IS NULL AND NVL(A.RESER_DATE, A.ORDER_DATE) between TO_DATE(:f_from_date) and TO_DATE(:f_to_date))
            //                                                OR  (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))
            //                                               AND A.JUBSU_DATE IS NOT NULL
            //                                               AND A.IN_OUT_GUBUN   = 'O'
            //                                               AND B.BUNHO          = A.BUNHO
            //                                               AND C.HOSP_CODE      = A.HOSP_CODE
            //                                               AND C.PKOCS1003      = A.FKOCS1003
            //                                               AND EXISTS (SELECT 'X' 
            //                                                             FROM OUT1001 X 
            //                                                            WHERE X.HOSP_CODE   = A.HOSP_CODE
            //                                                              --AND X.NAEWON_DATE between TO_DATE(:f_from_date) and TO_DATE(:f_to_date)
            //                                                              AND X.NAEWON_DATE = NVL(A.RESER_DATE, A.ORDER_DATE)
            //                                                              AND X.BUNHO       = A.BUNHO
            //                                                              AND X.GWA         != '03')  -- 来院患者チェック
            //                                                GROUP BY A.BUNHO
            //                                                       , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)
            //                                                       , A.DOCTOR_NAME
            //                                                       , FN_REQUEST_GWA_NAME('O',A.BUNHO, A.GWA, A.ORDER_DATE)
            //                                                       , NVL(A.RESER_DATE, A.ORDER_DATE)
            //                                                       , NVL(C.EMERGENCY, 'N')
            //                                             ORDER BY MAX(A.JUBSU_DATE) DESC, MAX(A.JUBSU_TIME) DESC";
            //            }
            //            else
            //            {
            //                this.grdPaList.QuerySQL = @"/* grd PaList Before Jubsu */
            //                                            SELECT A.BUNHO
            //                                                 , MAX(B.SUNAME)
            //                                                 , MAX(A.IN_OUT_GUBUN)
            //                                                 , MAX(FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE)) GWA_NAME
            //                                                -- , MAX(FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003))   TODAY_YN
            //                                                 , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)   RESER_YN
            //                                                 , MAX(A.DOCTOR)
            //                                                 , A.DOCTOR_NAME
            //                                                -- , FN_REQUEST_GWA_NAME('O',A.BUNHO, A.GWA, A.ORDER_DATE)            REQUEST_NAME 
            //                                                 , NVL(A.RESER_DATE, A.ORDER_DATE)                                   KIJUN_DATE
            //                                                 , NVL(C.EMERGENCY, 'N')                                             EMERGENCY_YN
            //                                                -- , DECODE(FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE), 'Y'
            //                                                --           , MAX((SELECT X.JUBSU_TIME
            //                                                --                FROM OUT1001 X 
            //                                                --              WHERE X.HOSP_CODE = A.HOSP_CODE 
            //                                                --                AND X.BUNHO = A.BUNHO
            //                                                --                AND X.NAEWON_DATE = TRUNC(SYSDATE)
            //                                                --                AND X.NAEWON_YN = 'Y'))
            //                                                --           , MAX(A.ORDER_TIME))                                       NAEWON_TIME
            //                                                 , MAX(A.ORDER_TIME)                                       NAEWON_TIME
            //                                              FROM OCS1003 C
            //                                                 , OUT0101 B
            //                                                 , CPL2010 A
            //                                             WHERE A.HOSP_CODE    = :f_hosp_code
            //                                               AND B.HOSP_CODE    = A.HOSP_CODE 
            //                                               --AND ((A.ORDER_DATE     = TO_DATE(:f_order_date) AND A.RESER_DATE IS NULL )
            //                                               -- OR  (A.RESER_DATE     = TO_DATE(:f_order_date) ))
            //                                               AND ((:f_bunho IS NULL AND NVL(A.RESER_DATE, A.ORDER_DATE) between TO_DATE(:f_from_date) and TO_DATE(:f_to_date))
            //                                                OR  (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))
            //                                               AND A.JUBSU_DATE IS NULL
            //                                               AND A.IN_OUT_GUBUN   = 'O'
            //                                               AND B.BUNHO          = A.BUNHO
            //                                               AND C.HOSP_CODE      = A.HOSP_CODE
            //                                               AND C.PKOCS1003      = A.FKOCS1003
            //                                               AND EXISTS (SELECT 'X' 
            //                                                             FROM OUT1001 X 
            //                                                            WHERE X.HOSP_CODE = A.HOSP_CODE
            //                                                              --AND X.NAEWON_DATE between TO_DATE(:f_from_date) and TO_DATE(:f_to_date)
            //                                                              AND X.NAEWON_DATE = NVL(A.RESER_DATE, A.ORDER_DATE)
            //                                                              AND X.BUNHO = A.BUNHO
            //                                                              AND NVL(X.NAEWON_YN, 'N') != 'N'  
            //                                                              AND X.GWA   != '03')  -- 来院患者チェック
            //                                                GROUP BY A.BUNHO
            //                                                       , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)
            //                                                       , A.DOCTOR_NAME
            //                                                       , FN_REQUEST_GWA_NAME('O',A.BUNHO, A.GWA, A.ORDER_DATE)
            //                                                       , NVL(A.RESER_DATE, A.ORDER_DATE)
            //                                                       , NVL(C.EMERGENCY, 'N')
            //                                              ORDER BY NVL(A.RESER_DATE, A.ORDER_DATE) , NAEWON_TIME";
            //            }

            //this.grdPaList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdPaList.SetBindVarValue("f_from_date", this.dtpOrderDate.GetDataValue());
            //this.grdPaList.SetBindVarValue("f_to_date", this.dtpOrderToDate.GetDataValue());
            //this.grdPaList.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void grdPaList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            //this.setGrdBackColor(sender, e);
            ////trial patient
            //if (e.DataRow["trial"].ToString() == "Y")
            //{
            //    grdPaList[e.RowNumber + 1, 1].ToolTipText = Resources.SMS_TRIAL;
            //}
            //if (e.DataRow["trial"].ToString() == "N")
            //{
            //    grdPaList[e.RowNumber + 1, 1].ToolTipText = " ";
            //}
            
        }

        #region grid backColor setting
        private void setGrdBackColor(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.Name == "grdPaList")
            {
                if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
                    e.BackColor = (XColor.XMatrixColHeaderBackColor).Color;

                if (grid.GetItemString(e.RowNumber, "emergency_yn") == "Y")
                    e.BackColor = Color.Pink;
            }
        }
        #endregion

        private void grdPaList_DoubleClick(object sender, EventArgs e)
        {
            //if (this.grdPaList.CurrentRowNumber < 0)
            //    return;

            //this.fbxBunho.SetEditValue(this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "bunho"));
            //this.fbxBunho.AcceptData();

        }

        private void grdPaList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //this.setGrdHeaderImage(this.grdPaList);

            //this.QueryTime = TimeVal;

            //if (this.grdPaList.RowCount > 0)
            //{
            //    // 画面のALARMが活性の場合
            //    if (this.rbxMijubsu.Checked && this.useAlarmChkYN.Equals("Y"))
            //    {
            //        for (int i = 0; i < grdPaList.RowCount; i++)
            //        {
            //            // 予約患者の場合は音無
            //            if (this.grdPaList.GetItemString(i, "reser_yn").Equals("N")
            //                || this.grdPaList.GetItemString(i, "in_out_gubun").Equals("O"))
            //            {
            //                // 一般、緊急の音をセットする。
            //                if (this.grdPaList.GetItemString(i, "emergency_yn").Equals("Y")) this.playAlarm("CPL_EM");
            //                else this.playAlarm("CPL");
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    this.fbxBunho.SetEditValue("");
            //    this.fbxBunho.AcceptData();
            //}
        }

        #region 환자 그리드 이미지 셋팅
        private void setGrdHeaderImage(XEditGrid grid)
        {
            if (grid.Name == "grdPaList")
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    // 입원 예약환자.
                    if (grid.GetItemString(i, "reser_yn") == "Y")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + Resources.CPL_ToolTipText1;
                    }

                    // 緊急オーダ
                    if (grid.GetItemString(i, "emergency_yn") == "Y")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[4];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + Resources.CPL_ToolTipText2;
                    }
                }
            }

            if (grid.Name == "grdSpecimen")
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    ///*
                    // GRIDのHEADを2行にした場合、ROWのイメージは　「＊２」にセットする。　                 
                    // */

                    // 至急オーダ
                    if (grid.GetItemString(i, "can_yn") == "X")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + Resources.CPL_ToolTipText3;
                    }

                    // 緊急オーダ
                    if (grid.GetItemString(i, "can_yn") == "Z")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[4];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + Resources.CPL_ToolTipText2;
                    }
                }
            }
        }
        #endregion

        #region [playAlarm] 撮影区分別にAlarmを設定
        private void playAlarm(string part)
        {
            try
            {
                if (part.Equals("CPL"))
                    Kernel32.PlaySound(this.alarmFilePath_CPL, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else if (part.Equals("CPL_EM"))
                    Kernel32.PlaySound(this.alarmFilePath_CPL_EM, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else
                    IHIS.Framework.Kernel32.Nofify();
            }
            catch { }
        }
        #endregion

        private void ClearInputControl()
        {
            //foreach (object obj in this.pnlPaInfo.Controls)
            //{
            //    if (obj is XDisplayBox)
            //    {
            //        if (((XDisplayBox)obj).Name != "cbxActor")
            //        {
            //            ((XDisplayBox)obj).ResetData();
            //        }
            //    }
            //}
            //this.fbxBunho.ResetData();
            //this.btnJusa.Visible = false;
            //this.pbxJusa.Visible = false;
        }

        private void ClearXEditGrid()
        {
            this.grdOrder.Reset();
            this.grdSpecimen.Reset();
            this.grdTube.Reset();
        }

        private void CPL2010U00_Closing(object sender, CancelEventArgs e)
        {
            //this.timer1.Stop();
        }

        private void grdTube_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "print_yn")
            {
                if (this.rbxJubsu.Checked)
                    e.Protect = false;
                else if (this.rbxMijubsu.Checked)
                    e.Protect = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ORDERCANCEL dlg = new ORDERCANCEL(paBox.BunHo, dtpOrderDate.GetDataValue());

            dlg.ShowDialog();
            grdSpecimen.QueryLayout(false);
        }

        #region [timer1_Tick] 自動照会関連
        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.lbTime.Text = (this.QueryTime / 1000).ToString();
            //this.QueryTime = this.QueryTime - 1000;

            //if (QueryTime == 0)
            //{
            //    // 受付TABの場合、再照会
            //    if (this.rbxMijubsu.Checked) this.grdPaList.QueryLayout(true);
            //    else
            //        // 受付TABが選択される。
            //        this.rbxMijubsu.Checked = true;

            //    this.timer1.Stop();

            //    this.timer1.Start();

            //    this.QueryTime = TimeVal;
            //}
        }

        private void btnUseTimeChk_Click(object sender, EventArgs e)
        {
            // 自動照会使用可否 useTimeChkYN 

            if (this.useTimeChkYN.Equals("N"))
            {
                //this.btnUseTimeChk.ImageIndex = 1;
                this.useTimeChkYN = "Y";

                //this.timer1.Start();
                //this.cboTime.Enabled = true;
                //this.tbxTimer.SetDataValue("Y");
                //this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
                //this.txtTimeInterval.AcceptData();
            }
            else
            {
                //this.btnUseTimeChk.ImageIndex = 0;
                this.useTimeChkYN = "N";

                //this.cboTime.Enabled = false;
                //this.timer1.Stop();
            }
        }

        #region [btnUseAlarmChk_Click]
        private void btnUseAlarmChk_Click(object sender, EventArgs e)
        {
            // 自動照会使用可否 useTimeChkYN 

            if (this.useAlarmChkYN.Equals("N"))
            {
                //this.btnUseAlarmChk.ImageIndex = 1;
                this.useAlarmChkYN = "Y";
            }
            else
            {
                //this.btnUseAlarmChk.ImageIndex = 0;
                this.useAlarmChkYN = "N";
            }
        }
        #endregion

        private void setTimer()
        {
            //if (TypeCheck.IsInt(txtTimeInterval.Text))
            //{
            //    this.QueryTime = int.Parse(txtTimeInterval.GetDataValue());
            //    this.TimeVal = int.Parse(txtTimeInterval.GetDataValue());
            //}

            //this.QueryTime = this.TimeVal;

            //this.cboTime.SelectedIndex = 0;
            //this.timer1.Start();
            //this.cboTime.Enabled = true;
            //this.tbxTimer.SetDataValue("Y");
            //this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            //this.txtTimeInterval.AcceptData();
        }

        private void txtTimeInterval_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //if (TypeCheck.IsInt(e.DataValue))
            //{
            //    this.QueryTime = int.Parse(e.DataValue);
            //    this.TimeVal = int.Parse(e.DataValue);


            //    this.lbTime.Text = (this.QueryTime / 1000).ToString();

            //    if (this.tbxTimer.GetDataValue() == "Y")
            //    {
            //        this.timer1.Stop();
            //        this.timer1.Start();
            //    }
            //}
            //else
            //{
            //    PostCallHelper.PostCall(new PostMethod(PostTimerValidating));
            //}
        }

        private void PostTimerValidating()
        {
            //this.txtTimeInterval.SetDataValue(this.TimeVal.ToString());
        }

        private void cboTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.timer1.Stop();

            //this.tbxTimer.SetDataValue("Y");
            //this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            //this.txtTimeInterval.AcceptData();

            //this.timer1.Start();
        }
        #endregion

        private void grdPaList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //this.fbxBunho.SetEditValue(this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "bunho"));
            //this.fbxBunho.AcceptData();
        }

        private void paBox_Validated(object sender, EventArgs e)
        {
            //btnList.PerformClick(FunctionType.Query);
            //lbSuname.Text = paBox.SuName;

            //this.grdPaList.QueryLayout(false);
        }

        // Sub-task MED-9280
        private void CPL2010U00OpenScreenCompositeFirst()
        {

            CPL2010U00OpenScreenCompositeArgs compositeArgs = new CPL2010U00OpenScreenCompositeArgs();
            //5
            ComboADM3200CbxActorArgs comboAdm3200CbxActorArgs = new ComboADM3200CbxActorArgs();
            compositeArgs.CbxActor = comboAdm3200CbxActorArgs;
            //6
            FormEnvironInfoSysDateArgs formEnvironInfoSysDateArgs = new FormEnvironInfoSysDateArgs();
            compositeArgs.InfoSysDate.Add(formEnvironInfoSysDateArgs);
            //7
            CPL2010U00GrdPaListArgs cpl2010U00GrdPaListArgs = new CPL2010U00GrdPaListArgs();
            cpl2010U00GrdPaListArgs.RbxJubsuChecked = this.rbxJubsu.Checked;
            cpl2010U00GrdPaListArgs.FromDate = dtpOrderDate.GetDataValue();
            cpl2010U00GrdPaListArgs.ToDate = dtpOrderToDate.GetDataValue();
            cpl2010U00GrdPaListArgs.Bunho = paBox.BunHo;
            compositeArgs.PaList = cpl2010U00GrdPaListArgs;

            FormEnvironInfoSysDateTimeArgs formEnvironInfoSysDateTimeArgs = new FormEnvironInfoSysDateTimeArgs();
            compositeArgs.InfoSysDateTime.Add(formEnvironInfoSysDateTimeArgs);
            //15
            CPL2010U00MlayConstantInfoArgs cpl2010U00MlayConstantInfoArgs1 = new CPL2010U00MlayConstantInfoArgs();
            cpl2010U00MlayConstantInfoArgs1.CodeType = "CPL_CONSTANT";
            compositeArgs.ConstantInfo.Add(cpl2010U00MlayConstantInfoArgs1);
            CPL2010U00MlayConstantInfoArgs cpl2010U00MlayConstantInfoArgs2 = new CPL2010U00MlayConstantInfoArgs();
            cpl2010U00MlayConstantInfoArgs2.CodeType = "CPL_ALARM";
            compositeArgs.ConstantInfo.Add(cpl2010U00MlayConstantInfoArgs2);

            CPL2010U00OpenScreenCompositeResult res = CloudService.Instance.Submit<CPL2010U00OpenScreenCompositeResult, CPL2010U00OpenScreenCompositeArgs>(compositeArgs, false, CallbackCompositeFirst);
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackCompositeFirst(CPL2010U00OpenScreenCompositeArgs args, CPL2010U00OpenScreenCompositeResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();           
            cacheOne.Add(args.CbxActor, new KeyValuePair<int, object>(1, result.CbxActor));
            cacheOne.Add(args.InfoSysDate[0], new KeyValuePair<int, object>(3, result.InfoSysDate[0]));
            cacheOne.Add(args.PaList, new KeyValuePair<int, object>(1, result.PaList));            
            cacheOne.Add(args.InfoSysDateTime[0], new KeyValuePair<int, object>(1, result.InfoSysDateTime[0]));
            for (int i = 0; i < result.ConstantInfo.Count; i++)
            {
                cacheOne.Add(args.ConstantInfo[i], new KeyValuePair<int, object>(1, result.ConstantInfo[i]));
            }
            cacheData.Add(CachePolicy.ONCE, cacheOne);

            return cacheData;
        }

        private void CPL2010U00OpenScreenCompositeSecond()
        {

            CPL2010U00OpenScreenCompositeArgs compositeArgs = new CPL2010U00OpenScreenCompositeArgs();

            CPL2010U00VsvPaArgs cpl2010U00VsvPaArgs = new CPL2010U00VsvPaArgs();
            cpl2010U00VsvPaArgs.Bunho = paBox.BunHo;
            compositeArgs.VsvPa = cpl2010U00VsvPaArgs;

            XPaInfoBoxArgs paInfoBoxArgs = new XPaInfoBoxArgs(paBox.BunHo);
            compositeArgs.InfoBox = paInfoBoxArgs;

            CPL2010U00LayChkNamesArgs cpl2010U00LayChkNamesArgs = new CPL2010U00LayChkNamesArgs();
            cpl2010U00LayChkNamesArgs.Bunho = paBox.BunHo;
            cpl2010U00LayChkNamesArgs.ReserDate = dtpOrderDate.GetDataValue();
            compositeArgs.LayChkName = cpl2010U00LayChkNamesArgs;

            CPL2010U00GrdOrderArgs cpl2010U00GrdOrderArgs = new CPL2010U00GrdOrderArgs();
            cpl2010U00GrdOrderArgs.Bunho = paBox.BunHo;
            cpl2010U00GrdOrderArgs.Mijubsu = this.mJubsu_yn;
            cpl2010U00GrdOrderArgs.ReserYn = this.reserYn;
            cpl2010U00GrdOrderArgs.FromDate = dtpOrderDate.GetDataValue();
            cpl2010U00GrdOrderArgs.ToDate = dtpOrderToDate.GetDataValue();
            cpl2010U00GrdOrderArgs.Doctor = this.doctor;
            cpl2010U00GrdOrderArgs.EmergencyYn = this.emergencyYn;
            compositeArgs.GrdOrder = cpl2010U00GrdOrderArgs;
            

            CPL2010U00OpenScreenCompositeResult res = CloudService.Instance.Submit<CPL2010U00OpenScreenCompositeResult, CPL2010U00OpenScreenCompositeArgs>(compositeArgs, false, CallbackCompositeSecond);
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackCompositeSecond(CPL2010U00OpenScreenCompositeArgs args, CPL2010U00OpenScreenCompositeResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();

            cacheOne.Add(args.VsvPa, new KeyValuePair<int, object>(1, result.VsvPa));
            cacheOne.Add(args.InfoBox, new KeyValuePair<int, object>(1, result.InfoBox));
            cacheOne.Add(args.LayChkName, new KeyValuePair<int, object>(1, result.LayChkName));
            cacheOne.Add(args.GrdOrder, new KeyValuePair<int, object>(1, result.GrdOrder));

            cacheData.Add(CachePolicy.ONCE, cacheOne);

            return cacheData;
        }

        #region [btnOrderPrint_Click 患者のオーダ内訳を印刷]
        private void btnOrderPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdSpecimen.RowCount < 1) return;

                //if (this.rbxMijubsu.Checked)
                //{

                //MED 10094
                InitDataWindow();

                this.layOrderPrint.Reset();
                this.dwOrderPrint.Reset();

                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                {
                    this.layOrderPrint.InsertRow(i);
                    this.layOrderPrint.SetItemValue(i, "cnt", (i + 1).ToString());
                    this.layOrderPrint.SetItemValue(i, "order_date", this.grdSpecimen.GetItemString(i, "order_date"));
                    this.layOrderPrint.SetItemValue(i, "order_time", this.grdSpecimen.GetItemString(i, "order_time"));
                    this.layOrderPrint.SetItemValue(i, "bunho", this.paBox.BunHo);
                    this.layOrderPrint.SetItemValue(i, "suname", this.paBox.SuName);
                    this.layOrderPrint.SetItemValue(i, "suname2", this.paBox.SuName2);
                    this.layOrderPrint.SetItemValue(i, "hangmog_code", this.grdSpecimen.GetItemString(i, "hangmog_code"));
                    this.layOrderPrint.SetItemValue(i, "hangmog_name", this.grdSpecimen.GetItemString(i, "gumsa_name"));
                    this.layOrderPrint.SetItemValue(i, "tube_name", this.grdSpecimen.GetItemString(i, "tube_name"));
                }

                this.dwOrderPrint.Reset();
                ApplyMultilanguagePrintDW();
                this.dwOrderPrint.FillData(this.layOrderPrint.LayoutTable);
                this.dwOrderPrint.Refresh();
                this.dwOrderPrint.Print();
            }
            catch (Exception)
            {
                XMessageBox.Show("Print was called when no DataWindow object was attached.", string.Empty, MessageBoxIcon.Error);
            }

            //}
        }
        #endregion

        private void InitDataWindow()
        {
            //===https://sofiamedix.atlassian.net/browse/MED-9362
            this.dwBarcode.DataWindowObject = "";
            this.dwBarcode.DataWindowObject = Resources.CPL_dwBarcodeDataWindowObject;
            this.dwBarcode.LibraryList = Resources.CPL_dwBarcodeLibraryList;
            this.dwBarcode.Name = Resources.CPL_dwBarcodeName;
            //===https://sofiamedix.atlassian.net/browse/MED-9360
            this.dwOrderPrint.DataWindowObject = "";
            this.dwOrderPrint.DataWindowObject = Resources.CPL_dwOrderPrintDataWindowObject;
            this.dwOrderPrint.LibraryList = Resources.CPL_dwOrderPrintLibraryList;
            this.dwOrderPrint.Name = Resources.CPL_dwOrderPrintName;
        }
        public void ApplyMultilanguagePrintDW()
        {
            try
            {
                //dw_comment
                dwOrderPrint.Refresh();
                dwOrderPrint.Modify(string.Format("pkapl1000_t.text = '{0}'", Resources.DW_TXT_1));
                dwOrderPrint.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_2));
                dwOrderPrint.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_3));
                dwOrderPrint.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_4));
                dwOrderPrint.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_5));
                dwOrderPrint.Modify(string.Format("t_9.text = '{0}'", Resources.DW_TXT_6));
                dwOrderPrint.Modify(string.Format("t_10.text = '{0}'", Resources.DW_TXT_7));
                dwOrderPrint.Modify(string.Format("t_11.text = '{0}'", Resources.DW_TXT_8));
                dwOrderPrint.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_9));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Simple version

        public void OpenScreen()
        {
            try
            {
                this.paBox.SetPatientID(this.bunho);

                this.CPL2010U00OpenScreenCompositeFirst();

                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

                //this.ParentForm.Size = new System.Drawing.Size(this.Width, rc.Height - 105);

                //this.grdSpecimen.SavePerformer = new XSavePerformer(this);
                //this.SaveLayoutList.Add(grdSpecimen);

                //this.dtpOrderDate.SetDataValue((EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")));
                //this.dtpOrderToDate.SetDataValue((EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")));

                mJubsu_yn = "2";  // 미채혈 query

                //dlg = new PAQRY(dtpOrderDate.GetDataValue(), rbxMijubsu.Checked ? "N" : "Y" );

                if (this.OpenParam != null)
                {
                    if (this.OpenParam.Contains("order_date"))
                    {
                        //this.dtpOrderDate.SetEditValue(this.OpenParam["order_date"].ToString());
                        //this.dtpOrderDate.AcceptData();
                    }
                    if (this.OpenParam.Contains("bunho"))
                    {
                        //this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                        //this.fbxBunho.AcceptData();
                    }
                }
                //this.grdPaList.QueryLayout(true);
                // タイマー設定
                //this.setTimer();

                PostCallHelper.PostCall(new PostMethod(PostLoad));
                this.HandleButtonListClick(FunctionType.Query);
            }
            catch (Exception ex)
            {
                Service.StartWriteLog();
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);
                Service.EndWriteLog();
            }
            finally { }
        }

        public void HandleButtonListClick(FunctionType fType)
        {
            switch (fType)
            {
                case FunctionType.Query:
                    //e.IsBaseCall = false;
                    //this.grdOrder.QueryLayout(true);
                    this.OrderQueryLayout();

                    if (grdOrder.RowCount == 0)
                    {
                        //this.grdPaList.QueryLayout(false);
                    }

                    this.QueryTime = this.TimeVal;

                    break;

                case FunctionType.Process:
                    //if (dlg != null)
                    //{
                    //    dlg.TimerControl(false);
                    //}
                    //this.btnList.Enabled = false;
                    if (this.grdSpecimen.RowCount == 0)
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox3_Ko
                                     : Resources.CPL_XMessageBox3_Jp);
                        string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                        XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                        //e.IsBaseCall = false;
                        //e.IsSuccess = false;
                    }
                    else
                    {
                        if (this.rbxMijubsu.Checked && this.cbxActor.Text.Length == 0)
                        {
                            string mMsg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox4_Ko
                                : Resources.CPL_XMessageBox4_Jp);
                            string mCap = NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP;
                            XMessageBox.Show(mMsg, mCap, MessageBoxIcon.Information);
                            //this.cbxActor.Focus();
                            //e.IsBaseCall = false;
                            //e.IsSuccess = false;
                            //this.btnList.Enabled = true;
                            return;
                        }

                        string order_date = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date").Replace("/", "").Replace("-", "");
                        string reser_date = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "reser_date").Replace("/", "").Replace("-", "");
                        string today = DateTime.Today.ToString("yyyyMMdd");
                        reser_date = TypeCheck.NVL(reser_date, today).ToString();

                        if (this.rbxMijubsu.Checked && reser_date != today)
                        {
                            string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox5_ko + grdOrder.GetItemString(grdOrder.CurrentRowNumber, "reser_date").Replace("-", "/") + Resources.CPL_XMessageBox6_Ko + DateTime.Today.ToString("yyyy/MM/dd").Replace("-", "/") + Resources.CPL_XMessageBox7_Ko
                                : Resources.CPL_XMessageBox8_Jp + grdOrder.GetItemString(grdOrder.CurrentRowNumber, "reser_date").Replace("-", "/") + Resources.CPL_XMessageBox9_Jp + DateTime.Today.ToString("yyyy/MM/dd").Replace("-", "/") + Resources.CPL_XMessageBox10_Jp);

                            //"該当オーダは当日オーダでも当日予約オーダでもありません。このまま保存しますか。");
                            string cap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko
                                : Resources.CPL_Caption2_JP);
                            if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo) != DialogResult.Yes)
                            {
                                //e.IsBaseCall = false;
                                //e.IsSuccess = false;
                                //this.btnList.Enabled = true;
                                return;
                            }
                        }
                        string flg = "";
                        if (this.rbxMijubsu.Checked)
                        {
                            flg = "Y";
                        }
                        else
                        {
                            flg = "N";
                        }
                        DataRow[] dtRow = this.grdSpecimen.LayoutTable.Select("jubsu_flag =" + "'" + flg + "'");
                        if (dtRow.Length < 1)
                        {
                            string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox3_Ko
                                         : Resources.CPL_XMessageBox3_Jp);
                            string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                            XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                            //e.IsBaseCall = false;
                            //e.IsSuccess = false;
                            //this.btnList.Enabled = true;
                            return;
                        }
                    }
                    //e.IsBaseCall = false;
                    jubsu_cnt = 0;
                    cancel_cnt = 0;
                    t_jubsu_gubun = "";

                    Hashtable inputList = new Hashtable();
                    Hashtable outputList = new Hashtable();

                    //this.timer1.Stop();

                    //this.InitStatusBar(this.grdSpecimen.RowCount);
                    //this.SetVisibleStatusBar(true);
                    //this.SetStatusBar(0);

                    #region todo delete

                    //                    try
                    //                    {
                    //                        Service.BeginTransaction();

                    //                        if (this.grdSpecimen.SaveLayout())
                    //                        {
                    //                            e.IsSuccess = true;

                    //                            if (jubsu_cnt > 0)
                    //                            {
                    //                                inputList.Add("I_ORDER_DATE",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date"));
                    //                                inputList.Add("I_BUNHO", this.fbxBunho.GetDataValue());
                    //                                inputList.Add("I_JUBSUJA", this.cbxActor.GetDataValue());
                    //                                inputList.Add("I_JUBSU_FLAG", "Y");
                    //                                inputList.Add("I_JUBSU_GUBUN", t_jubsu_gubun); // null
                    //                                inputList.Add("I_JUBSU_DATE",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    //                                inputList.Add("I_JUBSU_TIME",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time"));

                    //                                //XMessageBox.Show("aaa");

                    //                                //채혈일은 dtpOrderDate이 아니라 sysdate가 들어감.
                    //                                if (Service.ExecuteProcedure("PR_CPL_MAKE_SPECIMEN_SER", inputList, outputList))
                    //                                {
                    //                                    if (outputList.Count > 0)
                    //                                    {
                    //                                        if (outputList["IO_FLAG"].ToString() == "N")
                    //                                        {
                    //                                            //mErrMsg = "患者情報がありません。オーダを確認してください。";
                    //                                            mErrMsg = Resources.XMessageBox11_Jp;
                    //                                            throw new Exception();
                    //                                        }
                    //                                    }
                    //                                }
                    //                                else
                    //                                {
                    //                                    throw new Exception();
                    //                                }
                    //                            }
                    //                            // 바코드 출력
                    //                            if (rbxMijubsu.Checked)
                    //                            {
                    //                                //바코드프린터명 가져오기
                    //                                this.layPrintName.QueryLayout();
                    //                                string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

                    //                                dwBarcode.Reset();
                    //                                layBarcode.Reset();
                    //                                this.layBarcodeTemp.SetBindVarValue("f_jubsu_date",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    //                                // jubsu_date 전역변수에 담아서 쿼리엔드에서도 사용해야함
                    //                                this.layBarcodeTemp.QueryLayout(true);

                    //                                if (layBarcode.RowCount > 0)
                    //                                {
                    //                                    #region

                    //                                    //채혈실의 뇨컵은 하나면된다
                    //                                    //										int nyo_cnt = 0;
                    //                                    //										string tube_code = "";
                    //                                    //										string jundal_gubun = "";
                    //                                    //										for (int i = this.layBarcode.RowCount-1; i >= 0 ; i-- )
                    //                                    //										{
                    //                                    //											jundal_gubun = this.layBarcode.GetItemString(i,"jundal_gubun");
                    //                                    //											tube_code = this.layBarcode.GetItemString(i,"tube_code");
                    //                                    //											if ( jundal_gubun != "14" ) //혈당부하 항목의 뇨는 그냥 바코드 뽑는다.
                    //                                    //											{
                    //                                    //												if ( tube_code == "18" )
                    //                                    //												{
                    //                                    //													nyo_cnt++;
                    //                                    //												}
                    //                                    //												if (nyo_cnt>1)
                    //                                    //												{
                    //                                    //													if ( tube_code == "18" )
                    //                                    //													{
                    //                                    //														this.layBarcode.DeleteRow(i);
                    //                                    //													}
                    //                                    //												}
                    //                                    //											}
                    //                                    //										}
                    //                                    //										this.layBarcode.AcceptData();
                    //                                    //
                    //                                    //										nyo_cnt = 0;
                    //                                    //										tube_code = "";
                    //                                    //										jundal_gubun = "";
                    //                                    //										for (int i = this.layBarcode.RowCount-1; i >= 0 ; i-- )
                    //                                    //										{
                    //                                    //											jundal_gubun = this.layBarcode.GetItemString(i,"jundal_gubun");
                    //                                    //											tube_code = this.layBarcode.GetItemString(i,"tube_code");
                    //                                    //											if ( jundal_gubun != "14" ) //혈당부하 항목의 뇨는 그냥 바코드 뽑는다.
                    //                                    //											{
                    //                                    //												if ( tube_code == "24" )
                    //                                    //												{
                    //                                    //													nyo_cnt++;
                    //                                    //												}
                    //                                    //												if (nyo_cnt>1)
                    //                                    //												{
                    //                                    //													if ( tube_code == "24" )
                    //                                    //													{
                    //                                    //														this.layBarcode.DeleteRow(i);
                    //                                    //													}
                    //                                    //												}
                    //                                    //											}
                    //                                    //										}
                    //                                    //this.layBarcode.AcceptData();

                    //                                    #endregion

                    //                                    //한껀씩 출력 보냄
                    //                                    //this.InitStatusBar(this.layBarcode.RowCount);
                    //                                    for (int j = 0; j < this.layBarcode.RowCount; j++)
                    //                                    {
                    //                                        //this.SetStatusBar(j);
                    //                                        dwBarcode.Reset();
                    //                                        layBarcodeOne.Reset();

                    //                                        int rowNum = layBarcodeOne.InsertRow(0);
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun",
                    //                                            this.layBarcode.GetItemString(j, "jundal_gubun"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name",
                    //                                            this.layBarcode.GetItemString(j, "jundal_gubun_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_code",
                    //                                            this.layBarcode.GetItemString(j, "specimen_code"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_name",
                    //                                            this.layBarcode.GetItemString(j, "specimen_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_code",
                    //                                            this.layBarcode.GetItemString(j, "tube_code"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_name",
                    //                                            this.layBarcode.GetItemString(j, "tube_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser",
                    //                                            this.layBarcode.GetItemString(j, "specimen_ser"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode.GetItemString(j, "bunho"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode.GetItemString(j, "suname"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "gwa_name",
                    //                                            this.layBarcode.GetItemString(j, "gwa_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "danger_yn",
                    //                                            this.layBarcode.GetItemString(j, "danger_yn"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba",
                    //                                            this.layBarcode.GetItemString(j, "specimen_ser_ba"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jangbi_code",
                    //                                            this.layBarcode.GetItemString(j, "jangbi_code"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jangbi_name",
                    //                                            this.layBarcode.GetItemString(j, "jangbi_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "in_out_gubun",
                    //                                            this.layBarcode.GetItemString(j, "in_out_gubun"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re",
                    //                                            this.layBarcode.GetItemString(j, "gumsa_name_re"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_max_amt",
                    //                                            this.layBarcode.GetItemString(j, "tube_max_amt"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_numbering",
                    //                                            this.layBarcode.GetItemString(j, "tube_numbering"));

                    //                                        dwBarcode.FillData(layBarcodeOne.LayoutTable);
                    //                                        dwBarcode.PrintProperties.PrinterName = printSetName;
                    //                                        dwBarcode.Print();

                    //                                        string strCMD = @"SELECT 'Y'
                    //                                                            FROM DUAL
                    //                                                           WHERE EXISTS (SELECT NULL
                    //                                                                           FROM CPL0109
                    //                                                                          WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                    //                                                                            AND CODE_TYPE = '20'
                    //                                                                            AND CODE ='" +
                    //                                                        this.layBarcodeOne.GetItemString(0, "specimen_code") + "')";

                    //                                        object retVal = Service.ExecuteScalar(strCMD);

                    //                                        if (TypeCheck.IsNull(retVal))
                    //                                        {

                    //                                            inputList.Clear();
                    //                                            outputList.Clear();

                    //                                            inputList.Add("I_SPECIMEN_SER", this.layBarcode.GetItemString(j, "specimen_ser"));
                    //                                            inputList.Add("I_JUNDAL_GUBUN", this.layBarcode.GetItemString(j, "jundal_gubun"));
                    //                                            inputList.Add("I_PART_JUBSU_DATE",
                    //                                                this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    //                                            inputList.Add("I_PART_JUBSU_TIME",
                    //                                                this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time"));
                    //                                            inputList.Add("I_PART_JUBSUJA", this.cbxActor.GetDataValue());
                    //                                            inputList.Add("I_USER_ID", this.cbxActor.GetDataValue());

                    //                                            if (!Service.ExecuteProcedure("PR_CPL_PART_JUBSU", inputList, outputList))
                    //                                            {
                    //                                                XMessageBox.Show(Resources.XMessageBox12 + Service.ErrFullMsg, Resources.caption4,
                    //                                                    MessageBoxIcon.Error);
                    //                                                throw new Exception();
                    //                                            }
                    //                                        }
                    //                                        //if (outputList.Count > 0)
                    //                                        //    flag = outputList[0].ToString();
                    //                                    }

                    //                                    //foreach (DataRow row in this.layBarcode.LayoutTable.Rows)
                    //                                    //{
                    //                                    //    dwBarcode.Reset();
                    //                                    //    layBarcodeOne.Reset();

                    //                                    //    layBarcodeOne.LayoutTable.ImportRow(row);

                    //                                    //    dwBarcode.FillData(layBarcodeOne.LayoutTable);
                    //                                    //    dwBarcode.PrintProperties.PrinterName = printSetName;
                    //                                    //    dwBarcode.Print();
                    //                                    //}
                    //                                }

                    //                            }

                    //                        }
                    //                        else
                    //                        {
                    //                            throw new Exception();
                    //                        }
                    //                        Service.CommitTransaction();
                    //                    }
                    //                    catch
                    //                    {
                    //                        Service.RollbackTransaction();
                    //                        e.IsSuccess = false;
                    //                        XMessageBox.Show(Resources.XMessageBox13 + mErrMsg, Resources.caption5, MessageBoxIcon.Error);
                    //                    }
                    //                    finally
                    //                    {
                    //                        if (this.useTimeChkYN.Equals("Y"))
                    //                        {
                    //                            this.timer1.Start();
                    //                        }
                    //                        //this.SetVisibleStatusBar(false);
                    //                        this.btnList.Enabled = true;

                    //                    }

                    #endregion

                    if (this.rbxJubsu.Checked == true)
                    {
                        foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                        {
                            // 会計未処理のみ
                            if (dtRow["if_data_send_yn"].ToString() == "Y")
                            {
                                XMessageBox.Show(Resources.CPL_XMessageBox2, "", MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    //save layout
                    try
                    {
                        bool success = SaveGrdSpecimen();
                        //e.IsSuccess = SaveGrdSpecimen();
                        if (/*e.IsSuccess*/success == false)
                        {
                            XMessageBox.Show(Resources.CPL_XMessageBox13 + mErrMsg, Resources.CPL_caption5, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        //2015.10.07: modified due to MED-4594
                        if (ex.GetType().IsAssignableFrom(typeof(Sybase.DataWindow.MethodFailureException)))
                        {
                            //do nothing
                        }
                        else
                        {
                            //e.IsSuccess = false;
                            XMessageBox.Show(Resources.CPL_XMessageBox13 + mErrMsg, Resources.CPL_caption5, MessageBoxIcon.Error);
                        }
                    }
                    finally
                    {
                        if (this.useTimeChkYN.Equals("Y"))
                        {
                            //this.timer1.Start();
                        }
                        //this.SetVisibleStatusBar(false);
                        //this.btnList.Enabled = true;

                    }

                    //if (dlg != null)
                    //{
                    //    dlg.TimerControl(true);
                    //}
                    break;
                default:
                    break;
            }
        }

        public void HandleBtnChangeTimeClick()
        {
            if (this.bunho != "")
            {
                /*********************
			    /  폼으로 보여줄 때 
			    /********************/
                if (this.grdSpecimen.RowCount > 0)
                {
                    CHANGETIME dlg = new CHANGETIME(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gwa"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gubun"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "doctor"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun"));
                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        this.grdSpecimen.QueryLayout(false);
                    }
                }
                else
                {
                    string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox15_Ko
                        : Resources.CPL_XMessageBox15_Jp);
                    string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                    XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                }
            }
        }

        public void HandleBtnPrintSetupClick()
        {
            SetPrint();
        }

        public void HandleBtnBarcodeClick()
        {
            Cursor preCursor = Cursor.Current;

            try
            {
                // Change cursor to waiting status to avoid double click
                // https://sofiamedix.atlassian.net/browse/MED-9443
                Cursor.Current = Cursors.WaitCursor;

                if (rbxJubsu.Checked)
                {
                    DataRow[] dtRowData = this.grdSpecimen.LayoutTable.Select("print_yn =" + "'Y'");

                    if (dtRowData.Length <= 0)
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox1_Ko
                                                            : Resources.CPL_XMessageBox1_JP);
                        string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                        XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                        return;
                    }
                    SetPrintBacode();
                }
                else
                {
                    if (this.paBox.BunHo != "")
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.CPL_XMessageBox2_Ko
                                         : Resources.CPL_XMessageBox2_Jp);
                        string mcap = (NetInfo.Language == LangMode.Ko ? Resources.CPL_Caption1_Ko : Resources.CPL_Caption2_JP);
                        XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
            finally
            {
                Cursor.Current = preCursor;
            }
        }

        public void HandleBtnCancelClick()
        {
            ORDERCANCEL dlg = new ORDERCANCEL(this.bunho, dtpOrderDate.GetDataValue());

            dlg.ShowDialog();
            grdSpecimen.QueryLayout(false);
        }

        public void HandleBtnChkAllJubsuClick()
        {
            if (this.chkAllJubsuYN.Equals("Y"))
            {
                //this.btnChkAllJubsu.ImageIndex = 1;
                this.chkAllJubsuYN = "N";

                string hangmog_code = string.Empty;
                string group_hangmog = string.Empty;
                string part_yn = string.Empty;

                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                {
                    hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");
                    group_hangmog = this.grdSpecimen.GetItemString(i, "group_hangmog");
                    part_yn = this.grdSpecimen.GetItemString(i, "part_jubsu_flag");

                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
                }
                this.grdSpecimen.Refresh();
            }
            else
            {
                //this.btnChkAllJubsu.ImageIndex = 0;
                this.chkAllJubsuYN = "Y";

                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
                this.grdSpecimen.Refresh();
            }
        }

        public void HandleBtnOrderPrintClick()
        {
            try
            {
                if (this.grdSpecimen.RowCount < 1) return;

                //if (this.rbxMijubsu.Checked)
                //{

                InitDataWindow();

                this.layOrderPrint.Reset();
                this.dwOrderPrint.Reset();

                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                {
                    this.layOrderPrint.InsertRow(i);
                    this.layOrderPrint.SetItemValue(i, "cnt", (i + 1).ToString());
                    this.layOrderPrint.SetItemValue(i, "order_date", this.grdSpecimen.GetItemString(i, "order_date"));
                    this.layOrderPrint.SetItemValue(i, "order_time", this.grdSpecimen.GetItemString(i, "order_time"));
                    this.layOrderPrint.SetItemValue(i, "bunho", this.bunho);
                    this.layOrderPrint.SetItemValue(i, "suname", this.paBox.SuName);
                    this.layOrderPrint.SetItemValue(i, "suname2", this.paBox.SuName2);
                    this.layOrderPrint.SetItemValue(i, "hangmog_code", this.grdSpecimen.GetItemString(i, "hangmog_code"));
                    this.layOrderPrint.SetItemValue(i, "hangmog_name", this.grdSpecimen.GetItemString(i, "gumsa_name"));
                    this.layOrderPrint.SetItemValue(i, "tube_name", this.grdSpecimen.GetItemString(i, "tube_name"));
                }

                this.dwOrderPrint.Reset();
                ApplyMultilanguagePrintDW();
                this.dwOrderPrint.FillData(this.layOrderPrint.LayoutTable);
                this.dwOrderPrint.Refresh();
                this.dwOrderPrint.Print();
            }
            catch (Exception)
            {
                XMessageBox.Show("Print was called when no DataWindow object was attached.", string.Empty, MessageBoxIcon.Error);
            }

            //}
        }
                
        #endregion
    }
}

