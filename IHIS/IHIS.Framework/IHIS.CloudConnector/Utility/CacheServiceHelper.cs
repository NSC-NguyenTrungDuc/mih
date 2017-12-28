using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Phys;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Arguments.Nuri;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Caching;
using IHIS.Framework;

namespace IHIS.CloudConnector.Utility
{
    /// <summary>
    /// Manages memory cache by revision mechanism
    /// </summary>
    public static class CacheServiceHelper
    {
        /// <summary>
        /// Cacheable tables
        /// </summary>
        private const string BAS0102 = "BAS0102";
        private const string BAS0260 = "BAS0260";
        private const string BAS0271 = "BAS0271";
        private const string BAS0272 = "BAS0272";
        private const string DRG0120 = "DRG0120";
        private const string EMR_RECORD_HISTORY = "EMR_RECORD_HISTORY";
        private const string EMR_RECORD = "EMR_RECORD";
        private const string NUR0102 = "NUR0102";
        private const string OCS0101 = "OCS0101";
        private const string OCS0132 = "OCS0132";
        private const string OCS0133 = "OCS0133";
        private const string OCS0141 = "OCS0141";
        private const string SCH0109 = "SCH0109";
        private const string SCH0002 = "SCH0002";
        private const string XRT0102 = "XRT0102";
        private const string ADM1110 = "ADM1110";
        private const string ADM3100 = "ADM3100";
        private const string ADM0200 = "ADM0200";
        private const string ADMS_GROUP_SYSTEM = "ADMS_GROUP_SYSTEM";
        private const string BAS0230 = "BAS0230";
        private const string CPL0109 = "CPL0109";
        private const string ADM3200 = "ADM3200";
        private const string INV0102 = "INV0102";
        private const string CPL0108 = "CPL0108";
        private const string DRG0130 = "DRG0130";
        private const string INJ0102 = "INJ0102";
        private const string BAS0210 = "BAS0210";
        private const string OUT0102 = "OUT0102";
        private const string NUR0101 = "NUR0101";
        private const string XRT0122 = "XRT0122";
        private const string OCS0142 = "OCS0142";
        private const string OCS0103 = "OCS0103";
        private const string OCS0102 = "OCS0102";
        private const string XRT0001 = "XRT0001";
        /* MORE TABLES GO HERE */

        /// <summary>
        /// First time login need to cache all revision in memory
        /// </summary>
        public static string CACHE_REVISION_KEY = "CACHE_REVISION_KEY";

        /// <summary>
        /// Mapping Table - Request(s)
        /// </summary>
        private static Dictionary<string, List<string>> _tableToRequestDict = new Dictionary<string,List<string>>();

        /// <summary>
        /// Get list of table which has different revision
        /// </summary>
        /// <param name="currentRevDict">Mapping table - revision</param>
        /// <param name="newRevDict">Mapping table - revision</param>
        /// <returns></returns>
        private static List<string> GetListExpiredCache(Dictionary<string, int> currentRevDict, Dictionary<string, int> newRevDict)
        {
            List<string> expiredCacheLst = new List<string>();

            try
            {
                foreach (string key in currentRevDict.Keys)
                {
                    if (!currentRevDict.ContainsKey(key) || !newRevDict.ContainsKey(key)) continue;

                    if (!currentRevDict[key].Equals(newRevDict[key]))
                    {
                        expiredCacheLst.Add(key);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.StartWriteLog();
                Logs.WriteLog("[GetListExpiredCache Exception message]: " + ex.Message);
                Logs.WriteLog("[GetListExpiredCache Exception stacktrace]: " + ex.StackTrace);
                Logs.EndWriteLog();
            }

            return expiredCacheLst;
        }

        /// <summary>
        /// Init cache
        /// </summary>
        private static void SetDictRequest()
        {
            List<string> lstData = new List<string>();

            try
            {
                // BAS0102
                lstData.Clear();
                lstData.Add(typeof(BASSFwkBuseoGubunArgs).Name);
                lstData.Add(typeof(CboDoctorGradeArgs).Name);
                lstData.Add(typeof(CboHospJinGubunArgs).Name);
                lstData.Add(typeof(CHTSCboSusikGubunArgs).Name);
                lstData.Add(typeof(CHTSXEditSusikGubunArgs).Name);
                lstData.Add(typeof(ComboAdminGubunArgs).Name);
                lstData.Add(typeof(ComboJubsuGubunArgs).Name);
                lstData.Add(typeof(ComboListByCodeTypeArgs).Name);
                lstData.Add(typeof(ComboListByCodeTypeArgs).Name);
                lstData.Add(typeof(ComboNaewonYnArgs).Name);
                lstData.Add(typeof(ComboSangEndSayuArgs).Name);
                lstData.Add(typeof(FwBizObjectXPaCommentLayCmmtGubunfwkArgs).Name);
                lstData.Add(typeof(InitializeComboListItemArgs).Name);
                lstData.Add(typeof(OCSACTCboIoGubunArgs).Name);
                lstData.Add(typeof(OUT0101Q01CboSexArgs).Name);
                lstData.Add(typeof(OUT0101U02ComboListArgs).Name);
                lstData.Add(typeof(PHY2001U04CboJubsuGubunArgs).Name);
                lstData.Add(typeof(PHY2001U04GrdCboJubsuGubunArgs).Name);
                if (!_tableToRequestDict.ContainsKey(BAS0102)) _tableToRequestDict.Add(BAS0102, lstData);

                // BAS0260
                lstData = new List<string>();
                lstData.Add(typeof(BuseoListArgs).Name);
                lstData.Add(typeof(ComboGwaArgs).Name);
                lstData.Add(typeof(CreateGwaComboArgs).Name);
                lstData.Add(typeof(InitializeComboListItemArgs).Name);
                lstData.Add(typeof(NuroMakeDeptComboArgs).Name);
                lstData.Add(typeof(NuroOUT1001U01GetDepartmentArgs).Name);
                lstData.Add(typeof(OcsaOCS0503U01CommonDataArgs).Name);
                lstData.Add(typeof(OUTSANGQ00LayoutGwaArgs).Name);
                lstData.Add(typeof(SCH0201Q12ComboListArgs).Name);
                lstData.Add(typeof(SchsSCH0201Q02JundalComboListArgs).Name);
                if (!_tableToRequestDict.ContainsKey(BAS0260)) _tableToRequestDict.Add(BAS0260, lstData);

                // BAS0271
                lstData = new List<string>();
                lstData.Add(typeof(LoadComboDataSourceArgs).Name);
                lstData.Add(typeof(OCS1003Q09LoadComboDataSourceArgs).Name);
                lstData.Add(typeof(OcsaOCS0503U01CommonDataArgs).Name);
                if (!_tableToRequestDict.ContainsKey(BAS0271)) _tableToRequestDict.Add(BAS0271, lstData);

                // BAS0272
                lstData = new List<string>();
                lstData.Add(typeof(LoadComboDataSourceArgs).Name);
                lstData.Add(typeof(OCS1003Q09LoadComboDataSourceArgs).Name);
                if (!_tableToRequestDict.ContainsKey(BAS0272)) _tableToRequestDict.Add(BAS0272, lstData);

                // DRG0120
                lstData = new List<string>();
                lstData.Add(typeof(OCS0103U00FindBoxCArgs).Name);
                if (!_tableToRequestDict.ContainsKey(DRG0120)) _tableToRequestDict.Add(DRG0120, lstData);

                // EMR_RECORD_HISTORY
                lstData = new List<string>();
                lstData.Add(typeof(OCS2015U40EmrMedicalRecordContentArgs).Name);
                if (!_tableToRequestDict.ContainsKey(EMR_RECORD_HISTORY)) _tableToRequestDict.Add(EMR_RECORD_HISTORY, lstData);

                // EMR_RECORD
                lstData = new List<string>();
                lstData.Add(typeof(OCS2015U40EmrMedicalRecordContentArgs).Name);
                if (!_tableToRequestDict.ContainsKey(EMR_RECORD)) _tableToRequestDict.Add(EMR_RECORD, lstData);

                // NUR0102
                lstData = new List<string>();
                lstData.Add(typeof(ComboNUR0102CboTimeArgs).Name);
                lstData.Add(typeof(InitializeComboListItemArgs).Name);
                lstData.Add(typeof(INJ1001U01CboTimeArgs).Name);
                lstData.Add(typeof(NUR1016U00GetComboListArgs).Name);
                lstData.Add(typeof(NUR1017U00GetComboListArgs).Name);
                lstData.Add(typeof(NuroComboTimeArgs).Name);
                lstData.Add(typeof(OCSACTCboTimeAndSystemArgs).Name);
                lstData.Add(typeof(INJ1001U01XEditGridCell88Args).Name);
                lstData.Add(typeof(INJ1001U01XEditGridCell89Args).Name);
                if (!_tableToRequestDict.ContainsKey(NUR0102)) _tableToRequestDict.Add(NUR0102, lstData);

                // OCS0101
                lstData = new List<string>();
                lstData.Add(typeof(OCS0103U00CboSlipGubunArgs).Name);
                lstData.Add(typeof(OCS0103U16SlipCodeTreeArgs).Name);
                if (!_tableToRequestDict.ContainsKey(OCS0101)) _tableToRequestDict.Add(OCS0101, lstData);

                // OCS0132
                lstData = new List<string>();
                lstData.Add(typeof(BASSCboInputGubunArgs).Name);
                lstData.Add(typeof(OFGetCboOrderGubunArgs).Name);
                lstData.Add(typeof(CboPartArgs).Name);
                lstData.Add(typeof(CboSearchConditionArgs).Name);
                lstData.Add(typeof(CheckHideButtonArgs).Name);
                lstData.Add(typeof(ComboDvArgs).Name);
                lstData.Add(typeof(ComboDvTimeArgs).Name);
                lstData.Add(typeof(ComboInputTabArgs).Name);
                lstData.Add(typeof(ComboJusaArgs).Name);
                lstData.Add(typeof(ComboJusaSpdGubunArgs).Name);
                lstData.Add(typeof(ComboNalsuArgs).Name);
                lstData.Add(typeof(ComboOrdDanuiArgs).Name);
                lstData.Add(typeof(ComboPayArgs).Name);
                lstData.Add(typeof(ComboPfesCboPartArgs).Name);
                lstData.Add(typeof(ComboPortableYnArgs).Name);
                lstData.Add(typeof(ComboSearchConditionArgs).Name);
                lstData.Add(typeof(ComboSuryangArgs).Name);
                lstData.Add(typeof(INJ1002U01LoadComboBoxArgs).Name);
                lstData.Add(typeof(LoadComboDataSourceArgs).Name);
                lstData.Add(typeof(OCS0103U00CboDvTimeArgs).Name);
                lstData.Add(typeof(OCS0103U00CboEmergencyArgs).Name);
                lstData.Add(typeof(OCS0103U00CboIfInputControlArgs).Name);
                lstData.Add(typeof(OCS0103U00CboOrderGubunArgs).Name);
                lstData.Add(typeof(OCS0103U00CboResultGubunArgs).Name);
                lstData.Add(typeof(OCS0103U00CboSubulConvertGubunArgs).Name);
                lstData.Add(typeof(OCS0103U00CboWonyoiOrderYnArgs).Name);
                lstData.Add(typeof(OCS0103U10CboInputGubunArgs).Name);
                lstData.Add(typeof(OCS0103U10SearchConditionCboArgs).Name);
                lstData.Add(typeof(OCS0103U12InitComboBoxArgs).Name);
                lstData.Add(typeof(OCS0103U13CboListArgs).Name);
                lstData.Add(typeof(OCS0132GetServerIpArgs).Name);
                lstData.Add(typeof(OCS1003P01MakeInputGubunTabArgs).Name);
                lstData.Add(typeof(OCS1003Q09LoadComboDataSourceArgs).Name);
                lstData.Add(typeof(OCSACTCboSystemArgs).Name);
                lstData.Add(typeof(OCSACTCboTimeAndSystemArgs).Name);
                lstData.Add(typeof(OcsEMRLoadComboInputTabArgs).Name);
                lstData.Add(typeof(PHY8002U00GrdGroupQueryArgs).Name);
                lstData.Add(typeof(PHY8002U00GrdQueryArgs).Name);
                lstData.Add(typeof(PHY8002U01CboDisUseADLArgs).Name);
                lstData.Add(typeof(PHY8002U01CboDisUseGasyouArgs).Name);
                lstData.Add(typeof(PHY8002U01CboDisUseKainyuArgs).Name);
                lstData.Add(typeof(PHY8002U01GetLayComboArgs).Name);
                if (!_tableToRequestDict.ContainsKey(OCS0132)) _tableToRequestDict.Add(OCS0132, lstData);

                // OCS0133
                lstData = new List<string>();
                lstData.Add(typeof(OCS0103U00CboInputControlArgs).Name);
                lstData.Add(typeof(OcsLoadInputAndVisibleControlArgs).Name);
                if (!_tableToRequestDict.ContainsKey(OCS0133)) _tableToRequestDict.Add(OCS0133, lstData);

                // OCS0141
                lstData = new List<string>();
                lstData.Add(typeof(OcsLoadInputAndVisibleControlArgs).Name);
                if (!_tableToRequestDict.ContainsKey(OCS0141)) _tableToRequestDict.Add(OCS0141, lstData);

                // SCH0109
                lstData = new List<string>();
                lstData.Add(typeof(ComboGumsaArgs).Name);
                lstData.Add(typeof(SCH0201Q12ComboListArgs).Name);
                lstData.Add(typeof(SCH3001U00GetCboGumsaArgs).Name);
                lstData.Add(typeof(SchsSCH0201Q01GumsaComboListArgs).Name);
                lstData.Add(typeof(SchsSCH0201Q04GetCboListArgs).Name);
                if (!_tableToRequestDict.ContainsKey(SCH0109)) _tableToRequestDict.Add(SCH0109, lstData);

                // SCH0002
                lstData = new List<string>();
                lstData.Add(typeof(SchsSCH0201Q01GumsaComboListArgs).Name);
                if (!_tableToRequestDict.ContainsKey(SCH0002)) _tableToRequestDict.Add(SCH0002, lstData);

                // XRT0102
                lstData = new List<string>();
                lstData.Add(typeof(CboBuwiBunryuArgs).Name);
                lstData.Add(typeof(CbxXrayGubunArgs).Name);
                lstData.Add(typeof(XRT0000Q00LayPacsInfoArgs).Name);
                lstData.Add(typeof(Xrt0122Q00LayComboArgs).Name);
                lstData.Add(typeof(XRT0123U00XEditGridCell3Args).Name);
                if (!_tableToRequestDict.ContainsKey(XRT0102)) _tableToRequestDict.Add(XRT0102, lstData);

                // ADM1110
                lstData = new List<string>();
                lstData.Add(typeof(ComboADM1110GetByColNameArgs).Name);
                if (!_tableToRequestDict.ContainsKey(ADM1110)) _tableToRequestDict.Add(ADM1110, lstData);

                // ADM3100
                lstData = new List<string>();
                lstData.Add(typeof(ComboUserGroupArgs).Name);
                if (!_tableToRequestDict.ContainsKey(ADM3100)) _tableToRequestDict.Add(ADM3100, lstData);

                // ADM0200
                lstData = new List<string>();
                lstData.Add(typeof(ADM102UFwkSysIdArgs).Name);
                lstData.Add(typeof(ADM106UFwkSysIdArgs).Name);
                if (!_tableToRequestDict.ContainsKey(ADM0200)) _tableToRequestDict.Add(ADM0200, lstData);

                // ADMS_GROUP_SYSTEM
                lstData = new List<string>();
                lstData.Add(typeof(ADM102UFwkSysIdArgs).Name);
                lstData.Add(typeof(ADM106UFwkSysIdArgs).Name);
                if (!_tableToRequestDict.ContainsKey(ADMS_GROUP_SYSTEM)) _tableToRequestDict.Add(ADMS_GROUP_SYSTEM, lstData);

                // BAS0230
                lstData = new List<string>();
                lstData.Add(typeof(ComboNuGroupArgs).Name);
                if (!_tableToRequestDict.ContainsKey(BAS0230)) _tableToRequestDict.Add(BAS0230, lstData);

                // CPL0109
                lstData = new List<string>();
                lstData.Add(typeof(ComboCplsUiTakArgs).Name);
                lstData.Add(typeof(ComboInOutGubunArgs).Name);
                lstData.Add(typeof(ComboResultFormArgs).Name);
                lstData.Add(typeof(ComboSpcialNameArgs).Name);
                lstData.Add(typeof(CPL3020U02CbxJangbiArgs).Name);
                lstData.Add(typeof(CPLMASTERUPLOADERCboMstTypeArgs).Name);
                if (!_tableToRequestDict.ContainsKey(CPL0109)) _tableToRequestDict.Add(CPL0109, lstData);

                // ADM3200
                lstData = new List<string>();
                lstData.Add(typeof(ComboADM3200CbxActorArgs).Name);
                lstData.Add(typeof(ComboADM3200FwkActorArgs).Name);
                if (!_tableToRequestDict.ContainsKey(ADM3200)) _tableToRequestDict.Add(ADM3200, lstData);

                // INV0102
                lstData = new List<string>();
                lstData.Add(typeof(DRG0120U00ComboListArgs).Name);
                lstData.Add(typeof(DrgsDRG5100P01ConstantInfoArgs).Name);
                lstData.Add(typeof(LayConstantInfoArgs).Name);
                if (!_tableToRequestDict.ContainsKey(INV0102)) _tableToRequestDict.Add(INV0102, lstData);

                // CPL0108
                lstData = new List<string>();
                lstData.Add(typeof(CPLMASTERUPLOADERCboMstTypeArgs).Name);
                if (!_tableToRequestDict.ContainsKey(CPL0108)) _tableToRequestDict.Add(CPL0108, lstData);

                // DRG0130
                lstData = new List<string>();
                lstData.Add(typeof(DRGOCSCHKGetCautionListArgs).Name);
                if (!_tableToRequestDict.ContainsKey(DRG0130)) _tableToRequestDict.Add(DRG0130, lstData);

                // INJ0102
                lstData = new List<string>();
                lstData.Add(typeof(INJ1001U01ComboListSortKeyArgs).Name);
                lstData.Add(typeof(INJ1001U01MlayConstantInfoArgs).Name);
                if (!_tableToRequestDict.ContainsKey(INJ0102)) _tableToRequestDict.Add(INJ0102, lstData);

                // BAS0210
                lstData = new List<string>();
                lstData.Add(typeof(NuroOUT1001U01GetTypeArgs).Name);
                if (!_tableToRequestDict.ContainsKey(BAS0210)) _tableToRequestDict.Add(BAS0210, lstData);

                // OUT0102
                lstData = new List<string>();
                lstData.Add(typeof(NuroOUT1001U01GetTypeArgs).Name);
                if (!_tableToRequestDict.ContainsKey(OUT0102)) _tableToRequestDict.Add(OUT0102, lstData);

                // NUR0101
                lstData = new List<string>();
                lstData.Add(typeof(ComboNur0101Args).Name);
                if (!_tableToRequestDict.ContainsKey(NUR0101)) _tableToRequestDict.Add(NUR0101, lstData);

                // XRT0122
                lstData = new List<string>();
                lstData.Add(typeof(OCS0103U16SlipCodeTreeArgs).Name);
                if (!_tableToRequestDict.ContainsKey(XRT0122)) _tableToRequestDict.Add(XRT0122, lstData);

                // OCS0142
                lstData = new List<string>();
                lstData.Add(typeof(OCS0103U16SlipCodeTreeArgs).Name);
                lstData.Add(typeof(OcsLoadInputTabArgs).Name);
                if (!_tableToRequestDict.ContainsKey(OCS0142)) _tableToRequestDict.Add(OCS0142, lstData);

                // OCS0103
                lstData = new List<string>();
                lstData.Add(typeof(OCS0103U16SlipCodeTreeArgs).Name);
                lstData.Add(typeof(HIGetHangmogNameArgs).Name);
                if (!_tableToRequestDict.ContainsKey(OCS0103)) _tableToRequestDict.Add(OCS0103, lstData);

                // OCS0102
                lstData = new List<string>();
                lstData.Add(typeof(OCS0103U16SlipCodeTreeArgs).Name);
                if (!_tableToRequestDict.ContainsKey(OCS0102)) _tableToRequestDict.Add(OCS0102, lstData);

                // XRT0001
                lstData = new List<string>();
                lstData.Add(typeof(OCS0103U16SlipCodeTreeArgs).Name);
                if (!_tableToRequestDict.ContainsKey(XRT0001)) _tableToRequestDict.Add(XRT0001, lstData);
            }
            catch (Exception ex)
            {
                Logs.StartWriteLog();
                Logs.WriteLog("[SetDictRequest Exception message]: " + ex.Message);
                Logs.WriteLog("[SetDictRequest Exception stacktrace]: " + ex.StackTrace);
                Logs.EndWriteLog();
            }
        }

        /// <summary>
        /// Removes all expired cache
        /// </summary>
        /// <param name="currRevDic">Current revision stored in memory</param>
        /// <param name="newRevDic">New revision gets from server</param>
        public static void RemoveExpiredCache(Dictionary<string, int> currRevDic, Dictionary<string, int> newRevDic)
        {
            try
            {
                // Init cache data
                SetDictRequest();

                // Gets lits of expired cache
                List<string> expiredKeyLst = GetListExpiredCache(currRevDic, newRevDic);

                foreach (string key in expiredKeyLst)
                {
                    if (!_tableToRequestDict.ContainsKey(key)) continue;

                    foreach (string typeName in _tableToRequestDict[key])
                    {
                        string cacheKey = string.Format("{0}-{1}", UserInfo.HospCode, typeName);
                        CacheService.Instance.Remove(cacheKey);
                        Logs.WriteLog("Removed cache key: " + key + " - " + cacheKey);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.StartWriteLog();
                Logs.WriteLog("[RemoveExpiredCache Exception message]: " + ex.Message);
                Logs.WriteLog("[RemoveExpiredCache Exception stacktrace]: " + ex.StackTrace);
                Logs.EndWriteLog();
            }
        }
    }
}
