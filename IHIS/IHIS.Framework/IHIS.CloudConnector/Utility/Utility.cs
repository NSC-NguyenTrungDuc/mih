using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Drawing;
using System.Configuration;
using System.IO;
using IHIS.Framework;

namespace IHIS.CloudConnector.Utility
{
    /// <summary>
    /// Class Utility
    /// </summary>
    public class Utility
    {
        #region Constants

        /// <summary>
        /// VPN_ prefix
        /// </summary>
        private const string VPN = "VPN";

        #endregion

        #region Fields and Properties
        /// <summary>
        /// Escape strings
        /// </summary>
        private static char[] sqlEscapeChar = { '_', '%', '[', '*', '\\' };
        #endregion

        #region Constructor
        /// <summary>
        /// Utility
        /// </summary>
        public Utility()
        {
        }
        #endregion

        #region Methods

        #region ConvertToDataTable
        /// <summary>
        /// Convert a collection object to a datatable, column name formatted as underscore
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <history>
        /// Date created    Author      Ver
        /// 2015.04.08      AnhNV       1.0
        /// </history>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(Regex.Replace(prop.Name, "(?<=.)([A-Z])", "_$0", RegexOptions.Compiled).ToLower());
            }

            foreach (T item in items)
            {
                object[] values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        #endregion

        #region GetMacAddress
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }
        #endregion

        #region CreateServicesMap
        public static Dictionary<string, string> CreateServicesMap()
        {
            Dictionary<string, string> servicesMap = new Dictionary<string, string>();
            //NUR2016U02 
            servicesMap.Add("NUR2016U02NuroPatientListRequest", "nuro");
            servicesMap.Add("NUR2016U02TranferRequest", "nuro");
            // //NUR2016U03

            //BIL0102U00
            servicesMap.Add("BIL0102U00GetHospInfoRequest", "nuro");
            servicesMap.Add("BIL0102U00GetPatientEmailRequest", "nuro");
            servicesMap.Add("BIL0102U00GetMailTemplateRequest", "nuro");
            servicesMap.Add("BIL0102U00GetExaminationInfoRequest", "nuro");
            servicesMap.Add("BIL0102U00SendEmailPatientRequest", "nuro");
            servicesMap.Add("BIL0102U00PrintTemplateRequest", "bill");
            servicesMap.Add("NUR2016U03TranferRequest", "nuro");
            servicesMap.Add("BIL0102U00DataReportRequest", "bill");

            servicesMap.Add("BIL0102U00GetMailTemplateOldRequest", "nuro");
            servicesMap.Add("BIL0102U00SendEmailPatientOldRequest", "nuro");
            // NUR2015U01 Start
            servicesMap.Add("NUR2015U01GrdOrderRequest", "nuro");
            servicesMap.Add("NUR2015U01EmrRecordUpdateRequest", "nuro");
            
            // ORDERTRANS Start
            servicesMap.Add("ORDERTRANSGrdHokenRequest", "nuro");
            servicesMap.Add("ORDERTRANSGrdINP2004Request", "nuro");
            servicesMap.Add("ORDERTRANSGrdSiksaRequest", "nuro");
            servicesMap.Add("ORDERTRANSGrdOutSangRequest", "nuro");
            servicesMap.Add("ORDERTRANSGrdWoichulRequest", "nuro");
            servicesMap.Add("ORDERTRANSLayOut0101Request", "nuro");
            servicesMap.Add("ORDERTRANSGrdCommentsRequest", "nuro");
            servicesMap.Add("ORDERTRANSFwkFindRequest", "nuro");
            servicesMap.Add("ORDERTRANSLayCommonRequest", "nuro");
            servicesMap.Add("ORDERTRANSPrIfsSiksaInputTestRequest", "nuro");
            servicesMap.Add("ORDERTRANSSangSendAllRequest", "nuro");
            servicesMap.Add("ORDERTRANSGrdEditRequest", "nuro");
            servicesMap.Add("ORDERTRANSGrdListRequest", "nuro");
            servicesMap.Add("ORDERTRANSAccountForcedEndRequest", "nuro");
            servicesMap.Add("ORDERTRANSAccountCompleteRequest", "nuro");
            servicesMap.Add("ORDERTRANSGrdListNonSendYnRequest", "nuro");
            servicesMap.Add("ORDERTRANSGrdGongbiListRequest", "nuro");
            servicesMap.Add("ORDERTRANSExecPrOutCheckOrderEndRequest", "nuro");
            servicesMap.Add("ORDERTRANSGrdEditIGubunRequest", "nuro");
            servicesMap.Add("ORDERTRANOcs1003UpdateRequest", "nuro");
            servicesMap.Add("ORDERTRANOrderTransRequest", "nuro");
            servicesMap.Add("ORDERTRANPRMakeIFS1004Request", "nuro");
            servicesMap.Add("ORDERTRANSangTransRequest", "nuro");
            servicesMap.Add("NUROAccountForcedEndRequest", "nuro");
            servicesMap.Add("ORDERTRANInsertOcsTempRequest", "nuro");
            servicesMap.Add("ORDERTRANProcessRequiRequest", "nuro");
            servicesMap.Add("NuroORDERTRANSUpdateOCS1003Request", "nuro");
            servicesMap.Add("OcsLoadInputAndVisibleControlRequest", "nuro");
            servicesMap.Add("OUT0101U02PatientExportRequest", "nuro");
            servicesMap.Add("ORDERTRANSAPITransferOrdersRequest", "nuro");
            // ORDERTRANS End

            servicesMap.Add("OFGetCboOrderGubunRequest", "system");
            servicesMap.Add("CheckNewMstDataRequest", "system");
            servicesMap.Add("OCS2015U00GetPatientInfoRequest", "emr");
            servicesMap.Add("OCS2015U00GetUserOptionsRequest", "emr");
            servicesMap.Add("OCS2016U02CheckLoadExpandRequest", "emr");
            servicesMap.Add("OCS2015U00GetDataPrintEmrMedicalRequest", "emr");
            servicesMap.Add("OCS2015U00GetHtmlContentRequest", "emr");
            servicesMap.Add("RES1001U00PrIFSMakeYoyakuRequest", "nuro");
            servicesMap.Add("CheckHideButtonRequest", "system");
            servicesMap.Add("CFFormUnevenPrescribeLayDRG0120Request", "system");
            servicesMap.Add("CFFormIlgwalChangeCboNalsuRequest", "system");
            servicesMap.Add("CFFormGetSelectHopeDateCboNalsuRequest", "system");
            servicesMap.Add("OUT0101U02GetPatientCodeRequest", "nuro");
            servicesMap.Add("MdiFormOpenMainScreenRequest", "system");
            servicesMap.Add("CheckAdminUserRequest", "adma");
            servicesMap.Add("MainFormGetSysInfoRequest", "system");
            servicesMap.Add("MainFormGetMsgSystemRequest", "system");
            servicesMap.Add("LoginRequest", "system");
            servicesMap.Add("AdmLoginOnBehalfOfRequest", "system");
            servicesMap.Add("FwUserInfoChangePswRequest", "system");
            servicesMap.Add("MainMenuRequest", "system");
            servicesMap.Add("GetPatientByCodeRequest", "system");
            servicesMap.Add("FindPatientFromRequest", "system");
            servicesMap.Add("BasManageZipCodeRequest", "system");
            servicesMap.Add("XPaInfoBoxRequest", "system");
            servicesMap.Add("DetailPaInfoFormGridInsureRequest", "system");
            servicesMap.Add("DetailPaInfoFormGridVisitListRequest", "system");
            servicesMap.Add("DetailPaInfoFormGridCommentRequest", "system");
            servicesMap.Add("BuseoListRequest", "system");
            servicesMap.Add("UserNameListRequest", "system");
            servicesMap.Add("UserInfoCheckUserSubDoctorRequest", "system");
            servicesMap.Add("UserInfoSetSystemUserToRegistryRequest", "system");
            servicesMap.Add("FormGwaListRequest", "system");
            servicesMap.Add("UserInfoCheckUserSubRequest", "system");
            servicesMap.Add("CheckUserDoctorLoginRequest", "system");
            servicesMap.Add("CheckUserLoginRequest", "system");
            servicesMap.Add("MdiFormSystemMenuRequest", "system");
            servicesMap.Add("MdiFormMainMenuRequest", "system");
            servicesMap.Add("PrOcsLoadHangmogInfoRequest", "system");
            servicesMap.Add("OcsoGetNotApproveOrderCntRequest", "system");
            servicesMap.Add("IsOrderDataChangedEnabledRequest", "system");
            servicesMap.Add("GetJundaPartAndTableRequest", "system");
            servicesMap.Add("SpeciFicCommentInputYnRequest", "system");
            servicesMap.Add("InsteadModifiedCheckRequest", "system");
            servicesMap.Add("FnCplLoadDupGrdHangmogRequest", "system");
            servicesMap.Add("GetDefaultOrdDanui1Request", "system");
            servicesMap.Add("GetDefaultOrdDanui2Request", "system");
            servicesMap.Add("PrOcsInterfaceInsertRequest", "system");
            servicesMap.Add("LoadColumnCodeNameRequest", "system");
            servicesMap.Add("LoadSearchOrder1Request", "system");
            servicesMap.Add("OcsoGetNaewonYNRequest", "system");
            servicesMap.Add("OcsoLoadCht0110Request", "system");
            servicesMap.Add("IsResultToConsultRequest", "system");
            servicesMap.Add("PrOcsLoadNaewonInfoRequest", "system");
            servicesMap.Add("LoadPatientNaewonListRequest", "system");
            servicesMap.Add("LoadSearchOrder2Request", "system");
            servicesMap.Add("GetJundaTableRequest", "system");
            servicesMap.Add("GetMainGwaDoctorCodeRequest", "system");
            servicesMap.Add("SaveOfenUsedHangmogRequest", "system");
            servicesMap.Add("IsToiwonGojiYNandEndOrderRequest", "system");
            servicesMap.Add("HIOcsCheckJundalPartLoadJaeryoJundalRequest", "system");
            servicesMap.Add("CheckPatientStatusRequest", "system");
            servicesMap.Add("DupCheckCPLOrder1Request", "system");
            servicesMap.Add("DupCheckInputInpOrderRequest", "system");
            servicesMap.Add("OCS0103U12GrdGeneralRequest", "system");
            servicesMap.Add("OCS0103U12SetTabWonnaeDrugRequest", "system");
            servicesMap.Add("GetJundaTable1Request", "system");
            servicesMap.Add("GetBogyongInfo3Request", "system");
            servicesMap.Add("GetApproveFlagsRequest", "system");
            servicesMap.Add("OcsoProcHQNInterfaceRequest", "system");
            servicesMap.Add("GetFindWorkerRequest", "system");
            servicesMap.Add("ExistAllergyDataRequest", "system");
            servicesMap.Add("GetOutJinryoCommentCntRequest", "system");
            servicesMap.Add("OpenAllergyInfoRequest", "system");
            servicesMap.Add("NoConfirmConsultRequest", "system");
            servicesMap.Add("LoadPatientSpecificCommentRequest", "system");
            servicesMap.Add("KensaReserRequest", "system");
            servicesMap.Add("GetOutTaGwaJinryoCntRequest", "system");
            servicesMap.Add("IpwonReserStatusRequest", "system");
            servicesMap.Add("AbleInsteadOrderRequest", "system");
            servicesMap.Add("GetOrderCountRequest", "system");
            servicesMap.Add("GetOrderKeyRequest", "system");
            servicesMap.Add("DupCheckInputOutOrderRequest", "system");
            servicesMap.Add("LoadComboDataSourceRequest", "system");
            servicesMap.Add("AdmMessageCallRequest", "system");
            servicesMap.Add("UdpHelperSendMsgToID2Request", "system");
            servicesMap.Add("ComboDvTimeRequest", "system");
            servicesMap.Add("ComboSuryangRequest", "system");
            servicesMap.Add("ComboDvRequest", "system");
            servicesMap.Add("ComboNalsuRequest", "system");
            servicesMap.Add("OcsOrderBizGetUserOptionRequest", "system");
            servicesMap.Add("LoadConsultEndYNRequest", "system");
            servicesMap.Add("OBCheckRegularDrugRequest", "system");
            servicesMap.Add("OBCheckSpecialDrugForPatientRequest", "system");
            servicesMap.Add("OBGetBogyongByDvRequest", "system");
            servicesMap.Add("OBLoadSearchOrderInfoDRGRequest", "system");
            servicesMap.Add("OBGetBogyongInfo2Request", "system");
            servicesMap.Add("OBGetBogyongInfo1Request", "system");
            servicesMap.Add("OBGetJundaTable1Request", "system");
            servicesMap.Add("OBLoadSimsaCommentRequest", "system");
            servicesMap.Add("LoadOftenUsedRequest", "system");
            servicesMap.Add("IsJaewonPatientRequest", "system");
            servicesMap.Add("LoadOcs0131Request", "system");
            servicesMap.Add("LoadOcs0132Request", "system");
            servicesMap.Add("GetNextGroupSerRequest", "system");
            servicesMap.Add("PrOcsConvertHangmogCodeRequest", "system");
            servicesMap.Add("FnDrgGetCycleOrdDateRequest", "system");
            servicesMap.Add("GetMsgInsulinRequest", "system");
            servicesMap.Add("HILoadCodeNameRequest", "system");
            servicesMap.Add("HIOcsBogyongRequest", "system");
            servicesMap.Add("HIOcsSpecificCommentRequest", "system");
            servicesMap.Add("CheckHangSangInfoRequest", "system");
            servicesMap.Add("HIGetGenericNameRequest", "system");
            servicesMap.Add("HIGetHangmogNameRequest", "system");
            servicesMap.Add("PrOcsLoadBunhoInfoRequest", "system");
            servicesMap.Add("PrOcsLoadIpwonReserInfoRequest", "system");
            servicesMap.Add("FnInpLoadJaewonIlsuRequest", "system");
            servicesMap.Add("PrOcsLoadIpwonInfoRequest", "system");
            servicesMap.Add("ComboGwaRequest", "system");
            servicesMap.Add("ComboGumsaRequest", "system");
            servicesMap.Add("FormScreenListRequest", "system");
            servicesMap.Add("FormEnvironInfoMessageRequest", "system");
            servicesMap.Add("FormEnvironInfoSysDateRequest", "system");
            servicesMap.Add("FormEnvironInfoSysDateTimeRequest", "system");
            servicesMap.Add("MenuViewFormRequest", "system");
            servicesMap.Add("FormUserInfoUnRegisterSystemUserRequest", "system");
            servicesMap.Add("LayConstantInfoRequest", "system");
            servicesMap.Add("ComboSearchConditionRequest", "system");
            servicesMap.Add("ComboPortableYnRequest", "system");
            servicesMap.Add("ComboPayRequest", "system");
            servicesMap.Add("ComboJusaRequest", "system");
            servicesMap.Add("ComboOrdDanuiRequest", "system");
            servicesMap.Add("ComboJusaSpdGubunRequest", "system");
            servicesMap.Add("ComboNaewonYnRequest", "system");
            servicesMap.Add("ComboJubsuGubunRequest", "system");
            servicesMap.Add("OFMakeUserComboRequest", "system");
            servicesMap.Add("OFMakeGwaComboRequest", "system");
            servicesMap.Add("OFUpdateDataRequest", "system");
            servicesMap.Add("OFFormSetMakeFormLoadRequest", "system");
            servicesMap.Add("ComboDoctorGwaRequest", "system");
            servicesMap.Add("ComboSangEndSayuRequest", "system");
            servicesMap.Add("CbxXrayGubunRequest", "system");
            servicesMap.Add("CboPartRequest", "system");
            servicesMap.Add("CboBuwiBunryuRequest", "system");
            servicesMap.Add("ComboCplsUiTakRequest", "system");
            servicesMap.Add("ComboPfesCboPartRequest", "system");
            servicesMap.Add("OCS0132GetServerIpRequest", "system");
            servicesMap.Add("XMstGridDeleteRowRequest", "system");
            servicesMap.Add("GetPatientInfoRequest", "system");
            servicesMap.Add("ComboInputTabRequest", "system");
            servicesMap.Add("OBFnOcsIsGeneralYnRequest", "system");
            servicesMap.Add("ComboBarCodeRequest", "system");
            servicesMap.Add("ComboInOutGubunRequest", "system");
            servicesMap.Add("ComboResultFormRequest", "system");
            servicesMap.Add("ComboSpcialNameRequest", "system");
            servicesMap.Add("ComboHoDongRequest", "system");
            servicesMap.Add("ComboADM1110GetByColNameRequest", "system");
            servicesMap.Add("ComboADM3200FwkActorRequest", "system");
            servicesMap.Add("ComboNUR0102CboTimeRequest", "system");
            servicesMap.Add("ComboADM3200CbxActorRequest", "system");
            servicesMap.Add("FwPaCommentGrdCmmtFwkRequest", "system");
            servicesMap.Add("FwBizObjectXPaCommentLayCmmtGubunfwkRequest", "system");
            servicesMap.Add("CboHospJinGubunRequest", "system");
            servicesMap.Add("BASSFwkBuseoGubunRequest", "system");
            servicesMap.Add("BASSCboInputGubunRequest", "system");
            servicesMap.Add("CHTSXEditSusikGubunRequest", "system");
            servicesMap.Add("CHTSCboSusikGubunRequest", "system");
            servicesMap.Add("OCS0103U00FindBoxCRequest", "system");
            servicesMap.Add("OCS0103U00FindBoxDRequest", "system");
            servicesMap.Add("OCS0103U00CboResultGubunRequest", "system");
            servicesMap.Add("OCS0103U00CboIfInputControlRequest", "system");
            servicesMap.Add("OCS0103U00CboEmergencyRequest", "system");
            servicesMap.Add("OCS0103U00CboSubulConvertGubunRequest", "system");
            servicesMap.Add("OCS0103U00CboWonyoiOrderYnRequest", "system");
            servicesMap.Add("OCS0103U00CboDvTimeRequest", "system");
            servicesMap.Add("OCS0103U00CboInputControlRequest", "system");
            servicesMap.Add("OCS0103U00CboOrderGubunRequest", "system");
            servicesMap.Add("OCS0103U00CboSlipGubunRequest", "system");
            servicesMap.Add("ComboUserGroupRequest", "system");
            servicesMap.Add("CboDoctorGradeRequest", "system");
            servicesMap.Add("ComboNuGroupRequest", "system");
            servicesMap.Add("ADM106UFwkSysIdRequest", "system");
            servicesMap.Add("ComboAdminGubunRequest", "system");
            servicesMap.Add("ADM102UFwkSysIdRequest", "system");
            servicesMap.Add("ComboNur0101Request", "system");
            servicesMap.Add("CreateGwaComboRequest", "system");
            servicesMap.Add("Xrt0122Q00LayComboRequest", "system");
            servicesMap.Add("BAS0110Q00LayJohapGubunRequest", "system");
            servicesMap.Add("PHY2001U04CboJubsuGubunRequest", "system");
            servicesMap.Add("PHY2001U04GrdCboJubsuGubunRequest", "system");
            servicesMap.Add("PHY8002U01CboDisUseKaizenRequest", "system");
            servicesMap.Add("PHY8002U01CboDisUseKainyuRequest", "system");
            servicesMap.Add("PHY8002U01CboDisUseADLRequest", "system");
            servicesMap.Add("PHY8002U01CboDisUseGasyouRequest", "system");
            servicesMap.Add("PHY8002U01GetLayComboRequest", "system");
            servicesMap.Add("NUR2001U04CboGwaRequest", "system");
            servicesMap.Add("ReservedCommentDloOCS0221Request", "system");
            servicesMap.Add("ReservedCommentGrdOCS0222Request", "system");
            servicesMap.Add("FwXHospCodeBoxLoadAllRequest", "system");
            servicesMap.Add("FwXHospCodeBoxLoadByHospCodeRequest", "system");
            servicesMap.Add("FwXHospCodeBoxGetGrdHospCodeRequest", "system");
            servicesMap.Add("AdmLoginFormCheckLoginUserRequest", "system");
            servicesMap.Add("MainFormGetSuperAdminMenuItemRequest", "system");
            servicesMap.Add("MainFormGetAdminMenuItemRequest", "system");
            servicesMap.Add("UpdateMasterDataRequest", "system");
            servicesMap.Add("AdmLoginFormLockUserRequest", "system");
            servicesMap.Add("XRT0000Q00GetModalityCodeRequest", "xrts");
            servicesMap.Add("XRT0000Q00InitializeRequest", "xrts");
            servicesMap.Add("XRT0000Q00LayPacsInfoRequest", "xrts");
            servicesMap.Add("XRT7001Q01LayRadioHistoryRequest", "xrts");
            servicesMap.Add("XRT9001R01Lay9001RRequest", "xrts");
            servicesMap.Add("XRT9001R03Lay9003RRequest", "xrts");
            servicesMap.Add("XRT0101U00GrdMcodeRequest", "xrts");
            servicesMap.Add("XRT0101U00GrdDcodeRequest", "xrts");
            servicesMap.Add("XRT0101U00LayDupDRequest", "xrts");
            servicesMap.Add("XRT0101U00LayDupMRequest", "xrts");
            servicesMap.Add("XRT0101U00SaveLayoutRequest", "xrts");
            servicesMap.Add("XRT0001U00GrdRadioListRequest", "xrts");
            servicesMap.Add("XRT0001U00GrdXRTRequest", "xrts");
            servicesMap.Add("XRT0001U00LayDupRequest", "xrts");
            servicesMap.Add("XRT0001U00FbxDataValidatingRequest", "xrts");
            servicesMap.Add("XRT0001U00MakeFindWorkerRequest", "xrts");
            servicesMap.Add("XRT0001U00SaveLayoutRequest", "xrts");
            servicesMap.Add("XRT0123U00GrdDCodeRequest", "xrts");
            servicesMap.Add("XRT0123U00grdMCodeRequest", "xrts");
            servicesMap.Add("XRT0123U00XEditGridCell3Request", "xrts");
            servicesMap.Add("XRT0123U00LayDupDRequest", "xrts");
            servicesMap.Add("XRT0123U00SaveLayoutRequest", "xrts");
            servicesMap.Add("XRT0122U00GrdMcodeRequest", "xrts");
            servicesMap.Add("XRT0122U00GrdDcodeRequest", "xrts");
            servicesMap.Add("XRT0122U00LayDupMRequest", "xrts");
            servicesMap.Add("XRT0122U00LayDupDRequest", "xrts");
            servicesMap.Add("XRT0122U00SaveLayoutRequest", "xrts");
            servicesMap.Add("XRT0201U00LoadScreenRequest", "xrts");
            servicesMap.Add("XRT0201U00GrdPaListRequest", "xrts");
            servicesMap.Add("XRT0201U00GrdOrderRequest", "xrts");
            servicesMap.Add("XRT0201U00GrdOrderRowFocusChangedRequest", "xrts");
            servicesMap.Add("XRT0201U00LayPacsRequest", "xrts");
            servicesMap.Add("XRT0201U00DataSendYnRequest", "xrts");
            servicesMap.Add("XRT0201U00FwkOrdDanuiRequest", "xrts");
            servicesMap.Add("XRT0201U00FwkOrdDanuiNameRequest", "xrts");
            servicesMap.Add("XRT0201U00NaewonDateRequest", "xrts");
            servicesMap.Add("XRT0201U00MentRequest", "xrts");
            servicesMap.Add("XRT0201U00GrdJaeryoColumnChangedRequest", "xrts");
            servicesMap.Add("XRT0201U00FwkActorRequest", "xrts");
            servicesMap.Add("XRT0201U00OcsCommonRequest", "xrts");
            servicesMap.Add("XRT0201U00CheckNaewonYnRequest", "xrts");
            servicesMap.Add("XRT0201U00GrdRadioListRequest", "xrts");
            servicesMap.Add("XRT0201U00RadioSaveLayoutRequest", "xrts");
            servicesMap.Add("XRT0201U00LayConstantRequest", "xrts");
            servicesMap.Add("XRT0201U00SaveLayoutRequest", "xrts");
            servicesMap.Add("XRT1002U00DsvLDOCS0801Request", "xrts");
            servicesMap.Add("XRT1002U00DsvRequestDataRequest", "xrts");
            servicesMap.Add("XRT1002U00DsvSideEffectRequest", "xrts");
            servicesMap.Add("XRT1002U00GrdComment3Request", "xrts");
            servicesMap.Add("XRT1002U00GrdPaStatusRequest", "xrts");
            servicesMap.Add("XRT1002U00LayCPLRequest", "xrts");
            servicesMap.Add("XRT1002U00LayOrderByJundalPartRequest", "xrts");
            servicesMap.Add("XRT1002U00LayOrderDateRequest", "xrts");
            servicesMap.Add("XRT1002U00LayPrintDateRequest", "xrts");
            servicesMap.Add("XRT1002U00LayPrintOrderRequest", "xrts");
            servicesMap.Add("XRT1002U00LayXRT0123Request", "xrts");
            servicesMap.Add("XRT1002U00BtnDeleteClickRequest", "xrts");
            servicesMap.Add("XRT1002U00PrintOrderByJudalPartRequest", "xrts");
            servicesMap.Add("XRT1002U00UpdateRequest", "xrts");
            servicesMap.Add("XRT1002U00GrdComment2Request", "xrts");
            servicesMap.Add("XRT1002U00GrdComment1Request", "xrts");
            servicesMap.Add("XRT1002U00GrdXrayMethodRequest", "xrts");
            servicesMap.Add("XRT1002U00DsvBuhaGubunRequest", "xrts");
            servicesMap.Add("XRT1002U00DsvXrayGubunRequest", "xrts");
            servicesMap.Add("XRT0101U01LayDupMRequest", "xrts");
            servicesMap.Add("XRT0101U01SaveLayoutRequest", "xrts");
            servicesMap.Add("XRT0101U01GrdDcodeRequest", "xrts");
            servicesMap.Add("XRT0101U01GrdMcodeRequest", "xrts");
            servicesMap.Add("XRT0101U01LayDupDRequest", "xrts");
            servicesMap.Add("Xrt0122Q00GrdDCodeRequest", "xrts");
            servicesMap.Add("Xrt0122Q00LayDupDRequest", "xrts");
            servicesMap.Add("Xrt0122Q00GrdMCodeRequest", "xrts");
            servicesMap.Add("Xrt0122Q00LayDupMRequest", "xrts");
            servicesMap.Add("Xrt0122Q00LayCodeNameRequest", "xrts");
            servicesMap.Add("XRT0201U00ToolTipRequest", "xrts");
            servicesMap.Add("XRT0201U00LoadLinkRequest", "xrts");

            //[START] [DRG5100P01] - Publish out-patient prescription
            servicesMap.Add("DRG5100P01GetDiseaseRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01OrderListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01AntiDataListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01AutoJubsuListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01LabelListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01NebokLabelListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01PaidOrderListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01PaidJubsuListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01OrderOrderListRequest", "drgs");
            servicesMap.Add("OpenScreenDRG5100P01CompositeRequest", "drgs"); 

            servicesMap.Add("DrgsDRG5100P01ConstantInfoRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01MakeBongtuOutRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01CheckDsvBoRyuRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01GetTimerRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01CheckJubsuRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01MinFKOCS1003Request", "drgs");
            servicesMap.Add("DrgsDRG5100P01LoadChebangPrintRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01LoadMakayJungboRequest", "drgs");

            servicesMap.Add("DrgsDRG5100P01DrgwonneaOWnCurListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01WnSerialQryListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01SetNumberRowInsertRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01GetBogyongNameRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01OrderJungboListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01SetBarDrgBunhoRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01JungboListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01CommentNumberRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01FkocListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01MaxSeqRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01InsertDataIntoDrgActRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01UpdateFkdrg4010InDRG2010Request", "drgs");
            servicesMap.Add("DrgsDRG5100P01UpdateDrgPackYNInDRG2010Request", "drgs");
            servicesMap.Add("DrgsDRG5100P01UpdatePowderYNRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01LayAntiDataListRequest", "drgs");

            servicesMap.Add("DrgsDRG5100P01DrgProcMainRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01DrgMasterInsertRequest", "drgs");
            servicesMap.Add("DRG5100P01CheckActRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01PrintNameRequest", "drgs");

            
            //[END] [DRG5100P01] - Publish out-patient prescription

            //[START] [DRG0130U00]
            servicesMap.Add("DrgsDRG0130U00GrdDrg0130Request", "drgs");
            servicesMap.Add("DrgsDRG0130U00CautionCodeRequest", "drgs");
            servicesMap.Add("DRG0130U00SaveLayoutRequest", "drgs");

            //[END] [DRG0130U00]

            //[START] [DRG0140U00] - Manage efficacy
            //_servicesMap.Add("DRG0140U00MasterDetailGridRequest", "drgs");
            //_servicesMap.Add("DRG0140U00ChangeRequest", "drgs");

            servicesMap.Add("DRG0140U00GrdMasterRequest", "drgs");
            servicesMap.Add("DRG0140U00GrdDetailRequest", "drgs");
            servicesMap.Add("DRG0140U00GrdMasterColumnChangedRequest", "drgs");
            servicesMap.Add("DRG0140U00GrdDetailColumnChangedRequest", "drgs");
            servicesMap.Add("DRG0140U00SaveLayoutRequest", "drgs");
            //[END] [DRG0140U00] - Manage efficacy

            //[START] [DRG0201U00] - Used drugs for Outpatient
            servicesMap.Add("DRG0201U00CboGridRequest", "drgs");
            //_servicesMap.Add("DRG0201U00GridPaidRequest", "drgs");
            //_servicesMap.Add("DRG0201U00DetailServerCallRequest", "drgs");
            servicesMap.Add("DRG0201U00ValidatePrintAdmMediRequest", "drgs");

            servicesMap.Add("DRG0201U00ProcAtcInterfaceRequest", "drgs");
            servicesMap.Add("DRG0201U00GetPatientIdRequest", "drgs");
            servicesMap.Add("DRG0201U00PrDrgUpdateChulgoRequest", "drgs");
            servicesMap.Add("DRG0201U00BarCodeRequest", "drgs");

            //client define
            servicesMap.Add("DRG0201U00GrdOrderListRequest", "drgs");
            servicesMap.Add("DRG0201U00GrdPaidRequest", "drgs");
            servicesMap.Add("DRG0201U00GrdOrderTbxBarCodeRequest", "drgs");
            servicesMap.Add("DRG0201U00GrdOrderDetailServerCallRequest", "drgs");
            servicesMap.Add("DRG0201U00LockChkRequest", "drgs");
            servicesMap.Add("DRG0201U00PrintAdmMediCheckDrgRequest", "drgs");
            servicesMap.Add("DRG0201U00PrintAdmMediCheckInjRequest", "drgs");
            servicesMap.Add("DRG0201U00TxtDrgBunhoDataValidatingKeyPressRequest", "drgs");
            servicesMap.Add("DRG0201U00CbxActorRequest", "drgs");

            //[END] [DRG0140U01] - Used drugs for Outpatient

            //[START] DrgsDRG5100P01 NEW
            servicesMap.Add("DRG0201U00ActChkRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01GridPaidListRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01ProcAtcInterfaceRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01DsvOrderJungboRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01LayBongtuRequest", "drgs");
            servicesMap.Add("DrgsDRG5100P01DsvOrderPrintRequest", "drgs");
            //[END] DrgsDRG5100P01 NEW
            //[START] DRG9001R01
            servicesMap.Add("DRG9001R01Lay9001Request", "drgs");
            //[END] DRG9001R01

            //[START] DRG9001R02
            servicesMap.Add("DRG9001R02Lay9001Request", "drgs");
            //[END] DRG9001R02

            // [START] DRG0102U01
            servicesMap.Add("DRG0102U01GrdMasterRequest", "drgs");
            servicesMap.Add("DRG0102U01GrdDetailRequest", "drgs");
            servicesMap.Add("DRG0102U01GrdMasterCheckRequest", "drgs");
            servicesMap.Add("DRG0102U01GrdDetailCheckRequest", "drgs");
            servicesMap.Add("DRG0102U01SaveLayoutRequest", "drgs");
            //[END] DRG0102U01

            //[START] DRG9040U01
            servicesMap.Add("DRG9040U01GrdJUSAOrderListRequest", "drgs");
            servicesMap.Add("DRG9040U01GrdOrderRequest", "drgs");
            servicesMap.Add("DRG9040U01GrdOrderListRequest", "drgs");
            servicesMap.Add("DRG9040U01GrdOrderListOutRequest", "drgs");
            servicesMap.Add("DRG9040U01GrdOrderOutRequest", "drgs");
            servicesMap.Add("DRG9040U01SaveLayoutRequest", "drgs");
            servicesMap.Add("DRG9040U01LayPaCommentRequest", "drgs");
            //[END] DRG9040U01



            //[START] DRGOCSCHK
            servicesMap.Add("DRGOCSCHKGrdOcsChkRequest", "drug");
            servicesMap.Add("DRGOCSCHKPreSmallCodeDataValidatingRequest", "drug");
            servicesMap.Add("DRGOCSCHKCautionCodeDataValidatingRequest", "drug");
            servicesMap.Add("DRGOCSCHKSmallCodeDataValidatingRequest", "drug");
            servicesMap.Add("DRGOCSCHKGetCautionListRequest", "drug");
            //	_servicesMap.Add("DRGOCSCHKSUpdateInv0110Request", "drug");
            servicesMap.Add("DRGOCSCHKSaveLayoutRequest", "drug");
            servicesMap.Add("DRGOCSCHKgrdOCS0108Request", "drug");
            servicesMap.Add("DRGOCSCHKGrdOcsChkFullRequest", "drug");
            servicesMap.Add("DRGOCSCHKSaveGrdOcs0108Request", "drug");
            servicesMap.Add("DRGOCSCHKSaveGrdOcsChkRequest", "drug");
            servicesMap.Add("DRGOCSCHKLoadCbxCHKRequest", "drug");

            //[END] DRGOCSCHK

            //[START] DRG0102U00
            //	_servicesMap.Add("DRG0102U00GrdRequest", "drug");
            servicesMap.Add("DRG0102U00GrdMasterGridColumnChangedRequest", "drug");
            servicesMap.Add("DRG0102U00GrdDetailGridColumnChangedRequest", "drug");
            //	_servicesMap.Add("DRG0102U00UpdateInv0102Request", "drug");
            servicesMap.Add("DRG0102U00UpdateInv0101Request", "drug");

            // Re-define
            servicesMap.Add("DRG0102U00GrdMasterRequest", "drug");
            servicesMap.Add("DRG0102U00GrdDetailRequest", "drug");
            servicesMap.Add("DRG0102U00GrdDetailSaveLayoutRequest", "drug");

            //[END] DRG0102U00

            //[START] DRG0120U00
            // Re-define
            servicesMap.Add("DRG0120U00ComboListRequest", "drug");
            servicesMap.Add("DRG0120U00GrdDrg0120Request", "drug");
            servicesMap.Add("DRG0120U00GrdDrg0120Item1Request", "drug");
            servicesMap.Add("DRG0120U00GrdNaebogRequest", "drug");
            servicesMap.Add("DRG0120U00GrdYoiyongRequest", "drug");
            servicesMap.Add("DRG0120U00SaveLayoutRequest", "drug");

            //[END] DRG0120U00

            servicesMap.Add("OCS2015U06EmrRecordRequest", "emr");
            servicesMap.Add("OCS2015U06EmrTagRequest", "emr");
            servicesMap.Add("OCS2015U06EmrTemplateTypeRequest", "emr");
            servicesMap.Add("OCS2015U06EmrTemplateRequest", "emr");
            servicesMap.Add("OCS2015U06OrderTypeComboRequest", "emr");

            servicesMap.Add("OCS2015U07EmrRecordInsertRequest", "emr");
            servicesMap.Add("OCS2015U06EmrRecordUpdateMetaRequest", "emr");
            servicesMap.Add("OCS2015U30EmrTagGetTagRequest", "emr");
            servicesMap.Add("OCS2015U30EmrTagSaveLayoutRequest", "emr");

            servicesMap.Add("OCS2015U31EmrTagGetTagRequest", "emr");
            servicesMap.Add("OCS2015U31EmrTemplateRequest", "emr");
            servicesMap.Add("OCS2015U31EmrTemplateTypeRequest", "emr");
            servicesMap.Add("OCS2015U31EmrTemplateSaveLayoutRequest", "emr");
            servicesMap.Add("OCS2015U31EmrTagGetTemplateTagsRequest", "emr");
            servicesMap.Add("OCS2015U31GetADM3200UserRequest", "emr");
            servicesMap.Add("OCS2015U31GetEmrTemplateRequest", "emr");
            servicesMap.Add("OCS2015U31GetTemplateTagsRequest", "emr");
            servicesMap.Add("OCS2015U31SaveLayoutRequest", "emr");
            servicesMap.Add("OCS2015U00GetOrderByPkoutRequest", "emr");

            servicesMap.Add("OCS2015U40EmrHistoryMedicalRecordRequest", "emr");
            servicesMap.Add("OCS2015U40EmrMedicalRecordContentRequest", "emr");
            servicesMap.Add("OCS2015U00GetInfoEPortViewerRequest", "emr");
            servicesMap.Add("OCS2015U00GetDataPrescriptionRequest", "emr");

            // [START] OCS2015U44
            servicesMap.Add("OCS2015U44EmrHistoricRecordUpdateRequest", "emr");
            servicesMap.Add("OCS2015U00EmrRecordUnlockRequest", "emr");
            servicesMap.Add("OCS2015U00EmrRecordLockRequest", "emr");
            servicesMap.Add("OCS2015U00EmrGetTimeoutSpanRequest", "emr");
            //[END] OCS2015U44
            // [START] OCS2015U00 REPORT
            servicesMap.Add("OCS2015U00GetDoctorPatientReportRequest", "emr");
            //[END] OCS2015U00
            //[START] OCS2015U00
            servicesMap.Add("OcsEmrPatientReceptionHistoryListRequest", "emr");
            servicesMap.Add("OCS2015U00EmrGetNoticeEditTimeRequest", "emr");
            servicesMap.Add("OCS2015U00SelectEmrRecordByPkout1001Request", "emr");
            servicesMap.Add("OCS2015U00LoadPatientMedicalRecordRequest", "emr");
            servicesMap.Add("OcsEmrHistoryClinicReferRequest", "emr");
            servicesMap.Add("OCS2015U00GetDiscussNotifyRequest", "emr");

            servicesMap.Add("OCS2015U00GetLinkMISRequest", "emr");

            servicesMap.Add("OCS2015U31LoadComboDepartRequest", "emr");
            servicesMap.Add("OCS2015U31LoadComboDoctorRequest", "emr");
            servicesMap.Add("OCS2015U31LoadGridDepartAndDoctorRequest", "emr");
            servicesMap.Add("CheckHospUseMovieTalkRequest", "emr");

            //[END] OCS2015U00

            // -----[START] OCS2015U04 ---------
            servicesMap.Add("OCS2015U04LoadBookmarkByPk0ut1001Request", "emr");
            servicesMap.Add("OCS2015U04EmrRecordLoadBookmarkContentRequest", "emr");
            servicesMap.Add("OCS2015U04LoadExaminationRequest", "emr");
            servicesMap.Add("OCS2015U04EditBookmarkRequest", "emr");
            servicesMap.Add("OCS2015U04EditBookmarkByPkout1001Request", "emr");
            servicesMap.Add("OCS2015U04DeleteBookmarkRequest", "emr");
            servicesMap.Add("OCS2015U04AddBookmarkRequest", "emr");
            // -----[END] OCS2015U04 ---------

            //-----[START] OCS2015U09 ---------
            servicesMap.Add("OCS2015U09EmrRecordUpdateRequest", "emr");
            servicesMap.Add("OCS2015U09GetTemplateComboBoxRequest", "emr");
            servicesMap.Add("OCS2015U09GetRootTagsForContextRequest", "emr");
            servicesMap.Add("OCS2015U09GetNodeTagsForContextRequest", "emr");
            //-----[END] OCS2015U09 ---------

            // -----[START] OCS2015U07 ---------
            servicesMap.Add("OCS2015U07GetChildTagOfParentRequest", "emr");
            // -----[END] OCS2015U07 ---------
            //-----[END] OCS2015U03 ---------
            servicesMap.Add("OCS2015U03OrderGubunRequest", "emr");
            servicesMap.Add("EMRDisplayBookmarkHistoryRequest", "emr");
            servicesMap.Add("OCS2015U00EmrBackTimeRimindRequest", "emr");
            servicesMap.Add("OCS2015U00EmrDownloadFileRimindRequest", "emr");
            //-----[END] OCS2015U03 ---------

            //[START] LOAD PATIENT INFECTION
            servicesMap.Add("LoadPatientInfectionRequest", "emr");
            //[END]

            //[START] [INJ1001U01] - Receive at injection dept.
            servicesMap.Add("INJ1001U01CompositeLoadDataRequest", "injs");
            servicesMap.Add("INJ1001U01CompositeFirstRequest", "injs");
            servicesMap.Add("INJ1001U01CompositeSecondRequest", "injs");
            servicesMap.Add("InjsINJ1001U01ActorListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01DetailListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01MasterListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01InfectionListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01ScheduleRequest", "injs");
            servicesMap.Add("InjsINJ1001U01LabelNewListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01ReserDateListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01TempListRequest", "injs");
            servicesMap.Add("INJ0102ComboListRequest", "injs");
            servicesMap.Add("INJ1001U01ComboListSortKeyRequest", "injs");
            servicesMap.Add("InjsINJ1001U01CplOrderStatusRequest", "injs");
            servicesMap.Add("InjsINJ1001U01PrintNameListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01ChkbStateRequest", "injs");
            servicesMap.Add("InjsINJ1001U01SettingPrintRequest", "injs");
            servicesMap.Add("INJ0102CodeNameListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01OrderDateListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01UpdateRequest", "injs");
            servicesMap.Add("INJ1001U01LayCommonRequest", "injs");
            servicesMap.Add("INJ1001FormJusaBedLayPatientListRequest", "injs");
            servicesMap.Add("INJ1001U01FormJusaBedLayHosilListRequest", "injs");
            servicesMap.Add("INJ1001U01FormJusaBedLayPatientRequest", "injs");
            servicesMap.Add("INJ1001U01GrdOCS1003Request", "injs");
            servicesMap.Add("INJ1001U01CboTimeRequest", "injs");
            servicesMap.Add("INJ1001U01XEditGridCell88Request", "injs");
            servicesMap.Add("INJ1001U01XEditGridCell89Request", "injs");
            servicesMap.Add("INJ1001U01MlayConstantInfoRequest", "injs");
            servicesMap.Add("INJ1001FormJusaBedLayGroupedRequest", "injs");
            servicesMap.Add("InjsINJ1001U01CommentListRequest", "injs");
            servicesMap.Add("InjsINJ1001U01AllergyListRequest", "injs");
            servicesMap.Add("INJ1001U01Grouped2Request", "injs");


            servicesMap.Add("INJ1001U01GrdSangRequest", "injs");
            servicesMap.Add("INJ1001U01GroupedRequest", "injs");
            //_servicesMap.Add("INJ1001U01GridDetailSaveLayoutRequest", "injs");
            servicesMap.Add("INJ1001U01SaveLayoutRequest", "injs");

            //[END] [INJ1001U01] - Receive at injection dept.

            //[START] INJ1002R01
            servicesMap.Add("INJ1002R01LayQuery1Request", "injs");
            servicesMap.Add("INJ1002R01LayQuery2Request", "injs");
            //[END] INJ1002R01

            //[START] INJ1002U01
            servicesMap.Add("INJ1002U01InitializeRequest", "injs");
            //[END] INJ1002U01

            //[START] INJ0101U00
            servicesMap.Add("INJ0101U00GrdMasterRequest", "injs");
            servicesMap.Add("INJ0101U00GrdDetailRequest", "injs");
            servicesMap.Add("INJ0101U00GrdMasterGridColumnChangedRequest", "injs");
            servicesMap.Add("INJ0101U00GrdDetailGridColumnChangedRequest", "injs");
            servicesMap.Add("INJ0101U00UpdateINJ0101Request", "injs");
            servicesMap.Add("INJ0101U00GrdDetailSaveLayoutRequest", "injs");

            //		INJ0101U00UpdateINJ0102Request		
            //[END] INJ0101U00

            //[START] INJ1002U01 - NEW
            servicesMap.Add("INJ1002U01GrdOrderRequest", "injs");
            servicesMap.Add("INJ1002U01LayReserDateRequest", "injs");
            servicesMap.Add("INJ1002U01SaveLayoutRequest", "injs");
            servicesMap.Add("INJ1002U01LoadComboBoxRequest", "injs");
            //[END] INJ1002U01 - NEW

            //[START] INJ0101U01
            servicesMap.Add("INJ0101U01GrdMasterRequest", "injs");
            servicesMap.Add("INJ0101U01GrdDetailRequest", "injs");
            servicesMap.Add("INJ0101U01GrdMasterCheckRequest", "injs");
            servicesMap.Add("INJ0101U01GrdDetailCheckRequest", "injs");
            servicesMap.Add("INJ0101U01SaveLayoutRequest", "injs");
            //[START] INJ0101U01


            servicesMap.Add("NuriNUR1016U00ValidationDuplicateCheckResponse", "nuri");
            servicesMap.Add("NuriNUR1016U00InsertNur1016Request", "nuri");
            servicesMap.Add("NuriNUR1016U00UpdateNur1016Request", "nuri");
            servicesMap.Add("NuriNUR1016U00UpdateCancelStatusRequest", "nuri");
            servicesMap.Add("NuriNUR1016U00ManageAllergyListRequest", "nuri");
            servicesMap.Add("NuriNUR1016U00NurAlegyMappingRequest", "nuri");

            //[START] NUR7001U00 - Measure Physical condition
            servicesMap.Add("NuriNUR7001U00GetMaxSeqInNUR7001Request", "nuri");
            servicesMap.Add("NuriNUR7001U00MeasurePhysicalConditionRequest", "nuri");
            servicesMap.Add("NuriNUR7001U00SaveLayoutRequest", "nuri");

            //[END] NUR7001U00 - Measure Physical condition

            //[START] NUR1017U00 - Manage infection
            servicesMap.Add("NuriNUR1017U00ManageInfectionRequest", "nuri");
            servicesMap.Add("NuriNUR1017U00GetYRequest", "nuri");
            servicesMap.Add("NuriNUR1017U00GetCodeNameRequest", "nuri");
            servicesMap.Add("NuriNUR1017U00InsertManageInfectionRequest", "nuri");
            servicesMap.Add("NuriNUR1017U00UpdateManageInfectionRequest", "nuri");
            servicesMap.Add("NuriNUR1017U00DeleteManageInfectionRequest", "nuri");
            servicesMap.Add("NuriNUR1017U00InfeMappingRequest", "nuri");
            servicesMap.Add("NUR1017U00GrdNUR1017Request", "nuri");
            servicesMap.Add("NUR1017U00GetComboListRequest", "nuri");
            servicesMap.Add("NUR1017U00LayValidationDupchkRequest", "nuri");
            servicesMap.Add("NUR1017U00SaveLayoutRequest", "nuri");
            //[END] NUR1017U00 - Manage infection

            //[START] NUR1016U00
            servicesMap.Add("NUR1016U00SelectNextValRequest", "nuri");
            servicesMap.Add("NUR1016U00GetComboListRequest", "nuri");
            servicesMap.Add("NUR1016U00GrdNUR1016Request", "nuri");
            servicesMap.Add("NUR1016U00PrNurAlergyMappingRequest", "nuri");
            servicesMap.Add("NuriNUR1016U00ValidationDuplicateCheckRequest", "nuri");
            //[END] NUR1016U00

            //[START] NUR0101U01
            servicesMap.Add("NUR0101U01GrdDetailGridColumnChangedRequest", "nuri");
            servicesMap.Add("NUR0101U01CheckDetailDBRequest", "nuri");
            servicesMap.Add("NUR0101U01GrdMasterGridColumnChangedRequest", "nuri");
            servicesMap.Add("NUR0101U01GrdDetailRequest", "nuri");
            servicesMap.Add("NUR0101U01GrdMasterRequest", "nuri");
            servicesMap.Add("NUR0101U01SaveLayoutRequest", "nuri");
            //		NUR0101U01SaveLayoutRequest
            //[END] NUR0101U01

            servicesMap.Add("NuroMakeDeptComboRequest", "nuro");
            servicesMap.Add("NuroOutOrderStatusRequest", "nuro");
            servicesMap.Add("NuroComboTimeRequest", "nuro");
            servicesMap.Add("NuroCboZipCodeRequest", "nuro");
            servicesMap.Add("NuroManagePatientRequest", "nuro");
            servicesMap.Add("NuroSearchPatientInfoRequest", "nuro");
            servicesMap.Add("ComboListByCodeTypeRequest", "nuro");
            servicesMap.Add("NuroPatientInsuranceListRequest", "nuro");
            servicesMap.Add("NuroManagePatientUpdateRequest", "nuro");

            //[START] NUR2001U04
            servicesMap.Add("NuroPatientListRequest", "nuro");
            servicesMap.Add("NuroNUR2001U04DepartmentListRequest", "nuro");
            servicesMap.Add("NuroNUR2001U04ComingStatusRequest", "nuro");
            servicesMap.Add("NuroNUR2001U04ExistingKeyStatusRequest", "nuro");
            servicesMap.Add("NuroNUR2001U04DoctorNameRequest", "nuro");
            servicesMap.Add("NuroNUR2001U04ForeignKeyRequest", "nuro");
            servicesMap.Add("NuroNUR2001U04ComingStatusUpdateRequest", "nuro");
            servicesMap.Add("NuroNUR2001U04PatientInfoUpdateRequest", "nuro");
            servicesMap.Add("NuroProcOcsoDoctorChange2Request", "nuro");
            servicesMap.Add("NuroNUR2001U04TransPatientInfoRequest", "nuro");
            servicesMap.Add("InitializeComboListItemRequest", "nuro");
            servicesMap.Add("NUR2001U04CboDoctorRequest", "nuro");
            //[END] NUR2001U04



            //[START] NUR1001R98 - Inspection order form
            servicesMap.Add("NuroCheckBookingRequest", "nuro");
            servicesMap.Add("NuroInspectionOrderRequest", "nuro");
            // Remove NuroInspectionOrderCmtTextRequest
            //        _servicesMap.Add("NuroInspectionOrderCmtTextRequest", "nuro");
            servicesMap.Add("NuroInspectionOrderGetInfoTextRequest", "nuro");
            servicesMap.Add("NuroInspectionOrderGetReserMoveNameRequest", "nuro");
            servicesMap.Add("NuroInspectionOrderGetTelRequest", "nuro");
            servicesMap.Add("NuroInspectionOrderGetMaxCodeNameRequest", "nuro");
            servicesMap.Add("NuroNUR1001R98PageCountRequest", "nuro");
            //test group
            servicesMap.Add("NUR1001R98LayReserInfoQueryEndRequest", "nuro");
            //[END] NUR1001R98 - Inspection order form

            //[START] NuroOUT1101Q01
            servicesMap.Add("NuroOUT1101Q01FwkDoctorRequest", "nuro");
            servicesMap.Add("NuroOUT1101Q01GridInfoRequest", "nuro");
            servicesMap.Add("NuroOUT1101Q01PrintNameInfoRequest", "nuro");
            servicesMap.Add("JapanDateInfoRequest", "nuro");
            servicesMap.Add("NuroOUT1101Q01DoctorNameInfoRequest", "nuro");
            //[END] NuroOUT1101Q01

            //[START] OUT1001U01 - Register receipting out-paitent
            servicesMap.Add("NuroPatientDetailListRequest", "nuro");
            servicesMap.Add("NuroPatientCommentListRequest", "nuro");
            servicesMap.Add("NuroPatientReceptionHistoryListRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01LayLastCheckDateRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01LayGongbiCodeRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01BarCodeInfoRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01GetGroupKeyRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01CheckDoctorRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01LoadOUT0105Request", "nuro");
            servicesMap.Add("NuroOUT1001U01GetDbMaxJubsuNoRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01CheckNaewonYnRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01CheckYRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01DeleteJubsuDataRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01LoadDoctorJinryoTimeRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01LoadCheckChojaeJpnRequest", "nuro");
            servicesMap.Add("NuroPatientGridViewRequest", "nuro");
            servicesMap.Add("UpdateJubsuDataRequest", "nuro");
            servicesMap.Add("OUT1001U01GetGubunRequest", "nuro");

            //[END] OUT1001U01 - Register receipting out-paitent NuroOUT1001U01LoadDoctorJinryoTimeRequest

            //[START] RES1001U00 - Manage exam order
            servicesMap.Add("RES1001U00CheckDuplicateRequest", "nuro");
            servicesMap.Add("RES1001U00CheckJinryoYnRequest", "nuro");
            servicesMap.Add("RES1001U00CheckUsingOrcaRequest", "nuro");
            servicesMap.Add("RES1001U00FbxHospCodeLinkRequest", "nuro");
            servicesMap.Add("RES1001U00FbxHospCodeLinkDataValidatingRequest", "nuro");
            servicesMap.Add("RES1001R00PrintBookingRequest", "nuro");
            servicesMap.Add("RES1001U00MapingCodeRequest", "nuro");
            servicesMap.Add("NuroRES1001U00UserNameRequest", "nuro");
            servicesMap.Add("NuroRES1001U00DepartmentListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00DoctorExamStatusRequest", "nuro");
            servicesMap.Add("NuroRES1001U00DoctorReservationStatusListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReservationScheduleCondition1ListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReservationScheduleCondition2ListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00AverageTimeListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReservationScheduleListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00TypeRequest", "nuro");
            servicesMap.Add("NuroRES1001U00DoctorNameRequest", "nuro");
            servicesMap.Add("NuroRES1001U00CheckingReservationRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReceptionNumberRequest", "nuro");
            servicesMap.Add("NuroRES1001U00CheckingPatientExistenceRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReservationOut0123UpdateRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReservationOut0123InsertRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReservationOut1001InsertRequest", "nuro");
            servicesMap.Add("NuroRES1001U00CheckingHangmogCodeRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReservationOut1001UpdateRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReservationOut0123DeleteRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReservationOut1001DeleteRequest", "nuro");
            servicesMap.Add("NuroRES1001U00DoctorReservationDateListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReseredDataListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00ReserListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00DoctorReserListRequest", "nuro");
            servicesMap.Add("NuroRES1001U00PRDoctorScheduleNewRequest", "nuro");
            servicesMap.Add("RES1001U00ReservationScheduleListGroupedRequest", "nuro");
            servicesMap.Add("RES1001U00FrmModifyReserGrdRES1001Request", "nuro");
            servicesMap.Add("RES1001U00FrmModifyReserCboReserGubunRequest", "nuro");
            //_servicesMap.Add("RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest", "nuro");
            servicesMap.Add("RES1001U00SaveLayoutItemRequest", "nuro");
            servicesMap.Add("RES1001U00SaveLayoutRequest", "nuro");
            servicesMap.Add("RES1001U00FrmModifySaveLayoutRequest", "nuro");
            servicesMap.Add("RES1001U01BookingClinicReferRequest", "nuro");

            //[END] RES1001U00 - Manage exam order

            //[START] NuroOUT0101U02
            servicesMap.Add("OUT0101U02ChangePWDRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GridCommentRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GridBoheomRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GridGongbiListRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GridPatientRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GetInsuranceRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GetBirthDayRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GetTypeRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GetInsurance2Request", "nuro");
            servicesMap.Add("NuroOUT0101U02GetTypeNameRequest", "nuro");
            servicesMap.Add("NuroNuroOUT0101U02GetGaeinRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GetInsuranceNameRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GetJohapRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02CheckExistsXRequest", "nuro");
            servicesMap.Add("OUT0101U02SaveGridRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02CheckExistsYRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02UpdatePatientRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GetYRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02InsertBoheomRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02UpdateBoheomRequest", "nuro");

            servicesMap.Add("NuroOUT0101U02InsertGongbiListRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02UpdateGongbiListRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02DeleteGongbiRequest", "nuro");

            servicesMap.Add("NuroOUT0101U02DeleteBoheomRequest", "nuro");
            servicesMap.Add("NuroOUT0101U02GongbiListGetYRequest", "nuro");
            servicesMap.Add("OUT0101U02ComboListRequest", "nuro");
            servicesMap.Add("OUT0101U02GridViewRequest", "nuro");
            servicesMap.Add("OUT0101U02CheckAndInsertPatientRequest", "nuro");
            servicesMap.Add("OUT0101U02CheckAndUpdatePatientRequest", "nuro");
            servicesMap.Add("OUT0101U02GetAndInsertBoheomRequest", "nuro");
            servicesMap.Add("OUT0101U02GetAndUpdateBoheomRequest", "nuro");
            servicesMap.Add("OUT0101U02GetAndInsertGongbiListRequest", "nuro");
            servicesMap.Add("OUT0101U02GetHospitalInfoRequest", "nuro");
            servicesMap.Add("OUT0101U02ImportPatientRequest", "nuro");

            //
            //[END] NuroOUT0101U02

            //[START] NuroRES0102U00GrdRES0103
            servicesMap.Add("NuroRES0102U00GrdRES0102Request", "nuro");
            servicesMap.Add("NuroRES0102U00GrdRES0103Request", "nuro");
            servicesMap.Add("NuroRES0102U00CboDoctorRequest", "nuro");
            servicesMap.Add("NuroRES0102U00CboGwaRoomRequest", "nuro");
            servicesMap.Add("NuroRES0102U00ChkHyujinRequest", "nuro");
            servicesMap.Add("NuroRES0102U00CboGwaRequest", "nuro");
            servicesMap.Add("CboAvgTimeRequest", "nuro");
            servicesMap.Add("NuroRES0102U00GridDoctorRequest", "nuro");
            servicesMap.Add("NuroRES0102U00GetDoctorByJinryoDateRequest", "nuro");
            servicesMap.Add("NuroRES0102U00GetDoctorByStarDateRequest", "nuro");
            servicesMap.Add("NuroRES0102U00GetDoctorInBetweenDateRequest", "nuro");
            servicesMap.Add("NuroRES0102U00CheckDoctorReq1Request", "nuro");
            servicesMap.Add("NuroRES0102U00CheckDoctorReq2Request", "nuro");
            servicesMap.Add("NuroRES0102U00CheckDoctorReq3Request", "nuro");

            servicesMap.Add("NuroRES0102U00InsertRES0104Request", "nuro");
            servicesMap.Add("NuroRES0102U00UpdateRES0104Request", "nuro");
            servicesMap.Add("NuroRES0102U00DeleteRES0104Request", "nuro");
            servicesMap.Add("NuroRES0102U00InsertRES0103Req1Request", "nuro");
            servicesMap.Add("NuroRES0102U00InsertRES0103Req2Request", "nuro");
            servicesMap.Add("NuroRES0102U00DeleteRES0103Req1Request", "nuro");
            servicesMap.Add("NuroRES0102U00DeleteRES0103Req2Request", "nuro");
            servicesMap.Add("NuroRES0102U00DeleteRES0102Request", "nuro");
            servicesMap.Add("NuroRES0102U00UpdateRES0102Req1Request", "nuro");
            servicesMap.Add("NuroRES0102U00UpdateRES0102Req3Request", "nuro");
            servicesMap.Add("NuroRES0102U00InsertRES0102Request", "nuro");
            servicesMap.Add("NuroRES0102U00UpdateRES0103Req1Request", "nuro");
            servicesMap.Add("NuroRES0102U00UpdateRES0103Req2Request", "nuro");
            servicesMap.Add("NuroRES0102U00UpdateRES0102Req2Request", "nuro");
            servicesMap.Add("NuroRES0102U00DeleteRES0102Req2Request", "nuro");

            servicesMap.Add("NuroRES0102U00GetDataGridViewRequest", "nuro");
            servicesMap.Add("NuroRES0102U00SaveScheduleRequest", "nuro");
            servicesMap.Add("NuroRes0102u00InitCboListItemRequest", "nuro");
            //[END] NuroRES0102U00GrdRES0103

            //[START] OUT1001U01
            servicesMap.Add("NuroOUT1001U01CheckY2Request", "nuro");
            servicesMap.Add("NuroOUT1001U01CheckY3Request", "nuro");
            servicesMap.Add("NuroOUT1001U01GetOut1001SeqRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01InsertJubsuRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01InsertTableOUT1002Request", "nuro");
            servicesMap.Add("NuroOUT1001U01GetGubunNameRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01UpdateTableOUT1001Request", "nuro");
            servicesMap.Add("NuroOUT1001U01DeleteInTableOUT1002Request", "nuro");
            servicesMap.Add("NuroOUT1001U01GetDepartmentRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01GetDoctorRequest", "nuro");
            servicesMap.Add("NuroOUT1001U01GetTypeRequest", "nuro");
            servicesMap.Add("NuroOut1001U01CheckDoctorScheduleRequest", "nuro");
            //[END] OUT1001U01

            //[START] NUR1001R00
            servicesMap.Add("NuroNUR1001R00GetGwaDoctorTempListRequest", "nuro");
            servicesMap.Add("NuroNUR1001R00GetTempListRequest", "nuro");

            //[END] NUR1001R00

            //[START] OUT1001P01
            servicesMap.Add("OUT1001P01GrdOUT1001Request", "nuro");
            servicesMap.Add("OUT1001P01PrOutChangeGwaDoctorRequest", "nuro");
            servicesMap.Add("OUT1001P01FindboxValidatingRequest", "nuro");
            //[END] OUT1001P01

            //[START] NURO LIB
            servicesMap.Add("NUR2001U04SavebtnActionRequest", "nuro");            
            servicesMap.Add("NUR2001U04SaveLayoutRequest", "nuro");
            servicesMap.Add("NuroGetLastGubunRequest", "nuro");
            servicesMap.Add("NuroGetRecentlyDoctorRequest", "nuro");
            servicesMap.Add("NuroGetGubunNameRequest", "nuro");
            servicesMap.Add("NuroGetGwaNameBAS0260Request", "nuro");
            servicesMap.Add("NuroGetDoctorNameBAS0270Request", "nuro");
            servicesMap.Add("NuroChkGetBunhoBySujinRequest", "nuro");
            servicesMap.Add("NuroChkGetGongbiYNRequest", "nuro");
            servicesMap.Add("NuroLoadTableReserYNRequest", "nuro");
            servicesMap.Add("NuroGetZipNameRequest", "nuro");
            servicesMap.Add("NuroChkGetWonyoiYnRequest", "nuro");
            //[END] NURO LIB

            //[START] OCS.lib
            servicesMap.Add("LoadSearchCommonOrderRequest", "system");
            servicesMap.Add("OcsLoadInputControlRequest", "nuro");
            servicesMap.Add("OcsLoadVisibleControlRequest", "nuro");
            servicesMap.Add("OcsLoadInputTabRequest", "nuro");
            servicesMap.Add("OcsOrderBizLoadComboDataSourceRequest", "nuro");
            servicesMap.Add("OFMakeTreeViewRequest", "system");
            servicesMap.Add("OBCheckInventoryRequest", "system");
            //[END] OCS.lib

            // OCS1003P01
            servicesMap.Add("OCS1003P01GrdPatientRequest", "nuro");
            servicesMap.Add("OCS1003P01MakeInputGubunTabRequest", "nuro");
            // OCS1003P01
            //[START] OUT0101Q01
            servicesMap.Add("OUT0101Q01GrdPatientListRequest", "nuro");
            servicesMap.Add("OUT0101Q01CboSexRequest", "nuro");
            //[END] OUT0101Q01
            // START OUT0106U00
            servicesMap.Add("OUT0106U00GridListRequest", "nuro");
            servicesMap.Add("OUT0106U00PatientListRequest", "nuro");
            servicesMap.Add("OUT0106U00PatientInfoNameRequest", "nuro");
            servicesMap.Add("OUT0106U00SaveCommentsRequest", "nuro");
            // END OUT0106U00

            servicesMap.Add("OUT0101U04SaveLayoutRequest", "nuro");
            servicesMap.Add("OUT0101U04TxtZipCode2DataValidatingRequest", "nuro");


            // [START] NUT0001U00
            servicesMap.Add("NUT0001U00LoadDoctorGwaRequest", "nuts");
            servicesMap.Add("NUT0001U00InitializeScreenRequest", "nuts");
            servicesMap.Add("NUT0001U00Grd0002Request", "nuts");
            servicesMap.Add("NUT0001U00SaveLayoutRequest", "nuts");
            servicesMap.Add("NUT0001U00LoadDoctorNameRequest", "nuts");
            servicesMap.Add("NUT0001U00GetNaewonKeyRequest", "nuts");
            // [END] NUT0001U00

            //[START] OCS1003P01
            servicesMap.Add("OCSAOCS0270Q00CboDoctorGradeRequest", "ocsa");
            servicesMap.Add("OCSAOCS0270Q00GridBAS0270Request", "ocsa");
            //[END] OCS1003P01

            //[START] [SERVER][OCS0503Q01] - Refer examination request by patient
            servicesMap.Add("OcsaOCS0503Q01ListDataRequest", "ocsa");
            //[END] [SERVER][OCS0503Q01] - Refer examination request by patient

            //[START] [SERVER][OCS0503U01] - Reply exam request
            servicesMap.Add("OcsaOCS0503U01GrdOCS0503ListRequest", "ocsa");
            servicesMap.Add("OcsaOCS0503U01CommonDataRequest", "ocsa");
            servicesMap.Add("OCS0503U01SaveLayoutRequest", "ocsa");
            //[END] [SERVER][OCS0503U01] - Reply exam request

            //[START] OCS0503Q00
            servicesMap.Add("OCS0503Q00LoadConsultInfoRequest", "ocsa");
            servicesMap.Add("OCS0503Q00FilteringTheInformationRequest", "ocsa");
            servicesMap.Add("OCS0503Q00DepartmentNameRequest", "ocsa");
            servicesMap.Add("OCS0503Q00DoctorNameRequest", "ocsa");
            servicesMap.Add("OCS0503Q00FdwCommonGwaRequest", "ocsa");
            servicesMap.Add("OCS0503Q00FdwCommonDoctorRequest", "ocsa");
            //[END] OCS0503Q00

            //[START] OCS0221U00
            servicesMap.Add("OcsaOCS0221U00GrdOCS0222ListRequest", "ocsa");
            servicesMap.Add("OcsaOCS0221U00CommonDataRequest", "ocsa");
            servicesMap.Add("OcsaOCS0221U00SeqRequest", "ocsa");

            servicesMap.Add("OcsaOCS0221U00SaveLayoutRequest", "ocsa");
            //[END] OCS0221U00

            //[START] OCS0204U00
            servicesMap.Add("OcsaOCS0204U00GrdOCS0204ListRequest", "ocsa");
            servicesMap.Add("OcsaOCS0204U00GrdOCS0205ListRequest", "ocsa");

            servicesMap.Add("OcsaOCS0204U00SangGubunNameRequest", "ocsa");
            servicesMap.Add("OcsaOCS0204U00SangNameRequest", "ocsa");
            servicesMap.Add("OcsaOCS0204U00GwaRequest", "ocsa");
            servicesMap.Add("OcsaOCS0204U00SaveLayoutRequest", "ocsa");
            servicesMap.Add("OcsaOCS0204U00FindWorkerListRequest", "ocsa");

            //[END] OCS0204U00

            //[START] OCS0150U00
            servicesMap.Add("OcsaOCS0150U00ListUserRequest", "ocsa");
            servicesMap.Add("OcsaOCS0150U00DepartmentListRequest", "ocsa");
            servicesMap.Add("OcsaOCS0150U00InsertIntoOCS0150Request", "ocsa");
            servicesMap.Add("OcsaOCS0150U00UpdateOCS0150Request", "ocsa");
            servicesMap.Add("OcsaOCS0150U00DeleteOCS0150Request", "ocsa");
            //[END] OCS0150U00

            //[START] OCS0208U00
            servicesMap.Add("OcsaOCS0208U00CommonDataRequest", "ocsa");
            servicesMap.Add("OcsaOCS0208U00LoadBogyongNameFromOcsRequest", "ocsa");
            servicesMap.Add("OcsaOCS0208U00LoadBogyongNameFromDrgRequest", "ocsa");
            servicesMap.Add("OcsaOCS0208U00SaveLayoutRequest", "ocsa");
            //[END] OCS0208U00


            //[START] OCS0304U00
            servicesMap.Add("OCS0304U00GrdOCS0304Request", "ocsa");
            servicesMap.Add("OCS0304U00GrdOCS0305Request", "ocsa");
            servicesMap.Add("OCS0304U00GrdOCS0306Request", "ocsa");
            //	    _servicesMap.Add("OCS0304U00SaveLayoutRequest", "ocsa");
            servicesMap.Add("OcsaOCS0304U00GetDoctorYaksokOpenIdRequest", "ocsa");
            servicesMap.Add("OcsaOCS0304U00GetYaksokDirectNameRequest", "ocsa");
            servicesMap.Add("OCS0304U00GrdOCS0304SaveLayoutRequest", "ocsa");
            servicesMap.Add("OCS0304U00GrdOCS0305SaveLayoutRequest", "ocsa");
            servicesMap.Add("OCS0304U00GrdOCS0306SaveLayoutRequest", "ocsa");
            //[END] OCS0304U00 

            //[START] [OCS0301U00] - Manage order set for user
            servicesMap.Add("OCS0301U00CboDoctorGwaRequest", "ocsa");
            servicesMap.Add("OCS0301U00MembCRUDRequest", "ocsa");
            servicesMap.Add("OCS0301U00FwkUserRequest", "ocsa");
            servicesMap.Add("OCS0301U00GrdOCS0300Request", "ocsa");
            servicesMap.Add("OCS0301U00GrdOCS0301Request", "ocsa");
            servicesMap.Add("OCS0301U00SeqRequest", "ocsa");
            servicesMap.Add("OCS0301U00LayQueryLayoutRequest", "ocsa");
            //[END] [OCS0301U00] - Manage order set for user

            //[START] OCS0503U00
            servicesMap.Add("OcsaOCS0503U00LoadOutSangRequest", "ocsa");
            servicesMap.Add("OCS0503U00CreateTimeComboRequest", "ocsa");
            servicesMap.Add("OCS0503U00CheckInpPatientRequest", "ocsa");
            servicesMap.Add("OCS0503U00ValidationCheckRequest", "ocsa");
            servicesMap.Add("OCS0503U00GetCodeNameRequest", "ocsa");
            servicesMap.Add("OCS0503U00gridOSC0503ListRequest", "ocsa");
            servicesMap.Add("OCS0503U00SaveLayoutRequest", "ocsa");
            servicesMap.Add("OCS0503U00CommonRequest", "ocsa");
            servicesMap.Add("OCS0503U00GetFindWorkerRequest", "ocsa");
            //[END] OCS0503U00

            //[START] OCS0311U00
            servicesMap.Add("OCS0311U00FwkDanuiRequest", "ocsa");
            servicesMap.Add("OCS0311U00LayDanuiRequest", "ocsa");
            servicesMap.Add("OCS0311U00LayHangmogCodeRequest", "ocsa");
            //	_servicesMap.Add("OCS0311U00InitializeRequest", "ocsa");
            servicesMap.Add("OCS0311U00CboPartBySetTableRequest", "ocsa");
            servicesMap.Add("OCS0311U00grdSetHangmogGridFindRequest", "ocsa");
            servicesMap.Add("OCS0311U00SaveLayoutRequest", "ocsa");
            servicesMap.Add("OCS0311U00grdHangmogCodeRequest", "ocsa");
            servicesMap.Add("OCS0311U00grdSetCodeListRequest", "ocsa");
            servicesMap.Add("OCS0311U00grdSetHangmogRequest", "ocsa");
            servicesMap.Add("OCS0311U00layDupHangmogCodeRequest", "ocsa");
            servicesMap.Add("OCS0311U00layDupSetCodeRequest", "ocsa");
            servicesMap.Add("OCS0311U00layDupSetHangmogRequest", "ocsa");
            servicesMap.Add("OCS0311U00laySetHangmogRequest", "ocsa");
            //[END] OCS0311U00
            //[START] OCS0131U00
            servicesMap.Add("OCS0131U00GetFwkCodeRequest", "ocsa");
            servicesMap.Add("OCS0131U00GrdOCS0131Request", "ocsa");
            servicesMap.Add("OCS0131U00GrdOCS0132Request", "ocsa");
            servicesMap.Add("OCS0131U00XSavePerformerRequest", "ocsa");
            //[END] OCS0131U00
            //[START] OCS0133U00
            servicesMap.Add("OCS0133U00ExecuteRequest", "ocsa");
            servicesMap.Add("OCS0133U00grdOCS0133ItemRequest", "ocsa");
            //[END] OCS0133U00

            //[START] OCS0108U00
            servicesMap.Add("OCS0108U00CreateComboRequest", "ocsa");
            servicesMap.Add("OCS0108U00ExecuteRequest", "ocsa");
            servicesMap.Add("OCS0108U00grdOCS0103Request", "ocsa");
            servicesMap.Add("OCS0108U00grdOCS0108Request", "ocsa");
            servicesMap.Add("OCS0108U00laySlipRequest", "ocsa");
            //[END] OCS0108U00

            //[START] OCS0103U13
            servicesMap.Add("OCS0103U13CboListRequest", "ocsa");
            servicesMap.Add("OCS0103U13FnAdmConvertKanaFullRequest", "ocsa");
            servicesMap.Add("OCS0103U13LaySpecimenTreeListRequest", "ocsa");
            servicesMap.Add("OCS0103U13FormLoadRequest", "ocsa");
            servicesMap.Add("OCS0103U13GrdSpecimenListRequest", "ocsa");
            servicesMap.Add("OCS0103U13GrdSearchOrderListRequest", "ocsa");
            servicesMap.Add("OCS0103U13GrdSangyongOrderListRequest", "ocsa");
            servicesMap.Add("OCS0103U13PrOcsApplyNdayOrderRequest", "ocsa");
            servicesMap.Add("OCS0103U13GrdOrderListRequest", "ocsa");
            servicesMap.Add("OCS0103U13SaveLayoutRequest", "ocsa");
            
            servicesMap.Add("OCS0103U13OpenScreenRequest", "ocsa");

            //[END] OCS0103U13

            //[START] [OCS0101U00] - Manage order slip
            servicesMap.Add("OCS0101U00GrdOcs0101InitRequest", "ocsa");
            servicesMap.Add("OCS0101U00GrdOcs0102InitRequest", "ocsa");
            servicesMap.Add("OCS0101U00GrdOcs0106Request", "ocsa");
            servicesMap.Add("OCS0101U00LayComboRequest", "ocsa");
            servicesMap.Add("OCS0101U00Grd0101CheckDataRequest", "ocsa");
            servicesMap.Add("OCS0101U00Grd0102CheckDataRequest", "ocsa");
            servicesMap.Add("OCS0101PreDeleteOcs0102CheckRequest", "ocsa");
            servicesMap.Add("OCS0101U00TransactionalRequest", "ocsa");
            //[END] [OCS0101U00] - Manage order slip

            //[START] [OCS0113U00] - Manage liquid specimen code by order code
            servicesMap.Add("OCS0113U00LaySlipInfoRequest", "ocsa");
            servicesMap.Add("OCS0113U00GrdOCS0113Request", "ocsa");
            servicesMap.Add("OCS0113U00GrdOCS0103Request", "ocsa");
            servicesMap.Add("OCS0113U00GetCodeNameRequest", "ocsa");
            servicesMap.Add("OCS0113U00GetFindWorkerRequest", "ocsa");
            servicesMap.Add("OCS0113U00TransactionalRequest", "ocsa");
            // [START] [OCS0113U00] - Manage liquid specimen code by order code

            //[START] OCS0103U12 
            servicesMap.Add("OCS0103U12InitComboBoxRequest", "ocsa");
            servicesMap.Add("OCS0103U12ScreenOpenRequest", "ocsa");
            servicesMap.Add("OCS0103U12MakeSangyongTabRequest", "ocsa");
            servicesMap.Add("OCS0103U12InitializeScreenRequest", "ocsa");
            servicesMap.Add("OCS0103U12LoadColumnNameRequest", "ocsa");
            servicesMap.Add("OCS0103U12GrdSangyongOrderRequest", "ocsa");
            servicesMap.Add("OCS0103U12IsUpdateCheckSelectRequest", "ocsa");
            servicesMap.Add("OCS0103U12IsUpdateCheckInsertRequest", "ocsa");
            servicesMap.Add("OCS0103U12ProtectGroupControlRequest", "ocsa");
            servicesMap.Add("OCS0103U12FbxJusaFindClickRequest", "ocsa");
            servicesMap.Add("OCS0103U12GridColumnProtectModifyRequest", "ocsa");

            servicesMap.Add("OCS0103U12LoadDrgOrderRequest", "ocsa");
            servicesMap.Add("OCS0103U12LayDrugTreeRequest", "ocsa");
            servicesMap.Add("OCS0103U12SetSameOrderDateGroupSerRequest", "ocsa");

            servicesMap.Add("OCS0103U12SaveLayoutRequest", "ocsa");
            //[END] OCS0103U12

            //[START] OCS0223U00
            servicesMap.Add("OCS0223U00GrdOCS0223Request", "ocsa");
            servicesMap.Add("OCS0223U00CboSystemRequest", "ocsa");
            servicesMap.Add("OCS0223U00ExecutionRequest", "ocsa");
            //[END] OCS0223U00

            // [START] OCS0103U16
            servicesMap.Add("OCS0103U16GrdSangyongOrderRequest", "ocsa");
            servicesMap.Add("OCS0103U16SlipCodeTreeRequest", "ocsa");
            servicesMap.Add("OCS0103U16GrdSlipHangmogRequest", "ocsa");
            servicesMap.Add("OCS0103U16ScreenOpenRequest", "ocsa");

            // [END] OCS0103U16
            //[START] OCS0103U14
            servicesMap.Add("OCS0103U14GrdSlipHangmogRequest", "ocsa");
            servicesMap.Add("OCS0103U14LaySlipCodeTreeRequest", "ocsa");
            servicesMap.Add("OCS0103U14FormLoadRequest", "ocsa");
            servicesMap.Add("OCS0103U14FirstOpenScreenRequest", "ocsa");


            //[END] OCS0103U14
            //[START] OCS0103U10
            servicesMap.Add("OCS0103U10CboInputGubunRequest", "ocsa");
            servicesMap.Add("OCS0103U10GrdDrgOrderRequest", "ocsa");
            servicesMap.Add("OCS0103U10GrdGeneralRequest", "ocsa");
            servicesMap.Add("OCS0103U10DrugTreeRequest", "ocsa");
            servicesMap.Add("OCS0103U10FormLoadRequest", "ocsa");
            servicesMap.Add("OCS0103U10SetTabWonnaeDrgRequest", "ocsa");
            servicesMap.Add("OCS0103U10SaveLayoutRequest", "ocsa");
            servicesMap.Add("OCS0103U10SearchConditionCboRequest", "ocsa");

            //[END] OCS0103U10

            //[START] OCS0103U17
            servicesMap.Add("CboSearchConditionRequest", "ocsa");
            servicesMap.Add("OCS0103U17LayHangwiGubunRequest", "ocsa");
            servicesMap.Add("OCS0103U17LoadHangwiOrder3Request", "ocsa");
            servicesMap.Add("OCS0103U17MakeJaeryoGubunTabRequest", "ocsa");
            servicesMap.Add("OCS0103U17LoadJaeryoOrderRequest", "ocsa");
            servicesMap.Add("OCS0103U17IsJundalTableRequest", "ocsa");
            servicesMap.Add("OCS0103U17ScreenOpenRequest", "ocsa");
            //[END] OCS0103U17

            //[START] OCS0103U18
            servicesMap.Add("OCS0103U18GrdOrderRequest", "ocsa");
            servicesMap.Add("OCS0103U18InitializeScreenRequest", "ocsa");
            //[END] OCS0103U18

            //[START] OCS0803U00
            servicesMap.Add("OCS0803U00grdOCS0804Request", "ocsa");
            servicesMap.Add("OCS0803U00grdOCS0803Request", "ocsa");
            servicesMap.Add("OCS0803U00CreateComboRequest", "ocsa");
            servicesMap.Add("OCS0803U00GetCodeNameRequest", "ocsa");
            servicesMap.Add("OCS0803U00GetFindWorkerRequest", "ocsa");
            servicesMap.Add("OCS0803U00ExecuteRequest", "ocsa");
            //[END] OCS0803U00

            //[START] OCS0301Q09
            servicesMap.Add("OCS0301Q09GrdOCS0301Request", "ocsa");
            servicesMap.Add("OCS0301Q09GrdOCS0303Request", "ocsa");
            servicesMap.Add("OCS0301Q09RbtMembCheckedChangedRequest", "ocsa");
            servicesMap.Add("OCS0301Q09IsDoctorRequest", "ocsa");
            servicesMap.Add("OCS0301Q09SetUserCheckBoxRequest", "ocsa");
            servicesMap.Add("OCS0301Q09CheckExistsYasokCodeRequest", "ocsa");
            servicesMap.Add("OCS0301Q09TxtYaksokCodeDataValidatingRequest", "ocsa");

            //[END] OCS0301Q09
            //[END] OCS0103U11
            servicesMap.Add("OCS0103U11InitializeScreenRequest", "ocsa");
            servicesMap.Add("OCS0103U11GrdSlipHangMogRequest", "ocsa");
            servicesMap.Add("OCS0103U11LaySlipCodeTreeRequest", "ocsa");
            servicesMap.Add("OCS0103U11LoadSlipHangmogRequest", "ocsa");
            servicesMap.Add("OCS0103U11GetFkocsRequest", "ocsa");
            //[END] OCS0103U11


            //[START] OCSAPPROVE
            servicesMap.Add("OCSAPPROVEGrdOrderRequest", "ocsa");
            servicesMap.Add("OCSAPPROVEGrdPatientListRequest", "ocsa");
            servicesMap.Add("OCSAPPROVEInitScreenRequest", "ocsa");
            servicesMap.Add("OCSAPPROVESaveLayoutRequest", "ocsa");
            //[END] OCSAPPROVE


            //[START] OCS0801U00
            servicesMap.Add("OCS0801U00GrdOCS0801Request", "ocsa");
            servicesMap.Add("OCS0801U00GetCodeNameRequest", "ocsa");
            servicesMap.Add("OCS0801U00TransactionalRequest", "ocsa");
            servicesMap.Add("OCS0801U00GrdOCS0802Request", "ocsa");
            //[END] OCS0801U00

            //[START] OCS0150Q00
            servicesMap.Add("OCS0150Q00GridOCS0150Request", "ocsa");
            servicesMap.Add("OCS0150Q00SaveLayoutForGridOCS0150Request", "ocsa");
            servicesMap.Add("OCS0150Q00FindboxMembRequest", "ocsa");
            //[END] OCS0150Q00
            //[START] OCS0208U00
            servicesMap.Add("OCS0208Q00GrdOCS0208Request", "ocsa");
            servicesMap.Add("OCS0208Q00CommonDataRequest", "ocsa");
            //[END] OCS0208U00

            //[START] OCS0208Q01
            servicesMap.Add("OCS0208Q01GrdChiryoGubunRequest", "ocsa");
            servicesMap.Add("OCS0208Q01GrdDrg0120Request", "ocsa");
            servicesMap.Add("OCS0208Q01GrdOCS0208Request", "ocsa");
            //[START] OCS0208Q01

            //[START] OCS0103Q00
            servicesMap.Add("Ocs0103Q00GrdHangMogRequest", "ocsa");
            servicesMap.Add("Ocs0103Q00LoadOcs0103Request", "ocsa");
            servicesMap.Add("OCS0103Q00CreateOrderGubunRequest", "ocsa");
            servicesMap.Add("OCS0103Q00LoadKatakanaFullRequest", "ocsa");
            servicesMap.Add("OCS0103Q00CheckHangmogNameInxRequest", "ocsa");
            //[END] OCS0103Q00

            //[START]OCS0311Q00
            servicesMap.Add("OCS0311Q00LayDownListRequest", "ocsa");
            servicesMap.Add("OCS0311Q00LayRootListRequest", "ocsa");
            servicesMap.Add("OCS0311Q00LaySetRequest", "ocsa");
            servicesMap.Add("OCS0311Q00CboSetPartRequest", "ocsa");
            servicesMap.Add("OCS0311Q00LayDownListQueryEndRequest", "ocsa");
            //[END]OCS0311Q00

            //[START] OCS0103U19
            servicesMap.Add("OCS0103U19InitializeScreenRequest", "ocsa");
            servicesMap.Add("OCS0103U19GetFkOcsRequest", "ocsa");
            servicesMap.Add("OCS0103U19GrdSearchOrderRequest", "ocsa");
            servicesMap.Add("OCS0103U19GrdJaeryoOrderRequest", "ocsa");
            //[END] OCS0103U19


            //[START] OCS0103U00
            servicesMap.Add("OCS0103U00GrdOCS0103Request", "ocsa");
            servicesMap.Add("OCS0103U00GrdOCS0108Request", "ocsa");
            servicesMap.Add("OCS0103U00GrdOCS0113Request", "ocsa");
            servicesMap.Add("OCS0103U00GrdOCS0115Request", "ocsa");
            servicesMap.Add("OCS0103U00GrdOCS0115ColChangedJundalPartRequest", "ocsa");
            servicesMap.Add("OCS0103U00GrdOCS0115ColChangedJundalPartOutRequest", "ocsa");
            servicesMap.Add("OCS0103U00GrdOCS0115ColChangedJundalPartInpRequest", "ocsa");
            servicesMap.Add("OCS0103U00GrdOCS0115ColChangedMovePartRequest", "ocsa");
            servicesMap.Add("OCS0103U00GrdOCS0113ColChangedRequest", "ocsa");
            servicesMap.Add("OCS0103U00FindBoxDataValidatingRequest", "ocsa");
            servicesMap.Add("OCS0103U00LayCommonSgCodeRequest", "ocsa");
            servicesMap.Add("OCS0103U00LayCommonJaeryoCodeRequest", "ocsa");
            servicesMap.Add("OCS0103U00LoadKanaFullRequest", "ocsa");
            servicesMap.Add("OCS0103U00GetJundalTableRequest", "ocsa");
            servicesMap.Add("OCS0103U00SaveLayoutRequest", "ocsa");
            servicesMap.Add("OCS0103U00FwkCommonRequest", "ocsa");
            servicesMap.Add("OCS0103U00GridColumnChangedRequest", "ocsa");
            servicesMap.Add("OCS0103U00CheckAdminUserRequest", "ocsa");
            servicesMap.Add("OCS0103U00GetCommonYnRequest", "ocsa");
            //[END] OCS0103U00

            //[START] OCS0131U01
            servicesMap.Add("Ocs0131U01Grd0131Request", "ocsa");
            servicesMap.Add("Ocs0131U01Grd0132Request", "ocsa");
            servicesMap.Add("Ocs0131U01SaveLayoutRequest", "ocsa");
            //[END] OCS0131U01

            //[START] OCS0204Q00
            servicesMap.Add("OCS0204Q00GrdOCS0205Request", "ocsa");
            servicesMap.Add("OCS0204Q00LayOCS0204Request", "ocsa");
            servicesMap.Add("OCS0204Q00CreateDoctorComboRequest", "ocsa");
            servicesMap.Add("OCS0204Q00GetOcsUserNameRequest", "ocsa");
            servicesMap.Add("OCS0204Q00CreateDoctorCombo1Request", "ocsa");
            //[END] OCS0204Q00

            //[START] OCS0103U15
            servicesMap.Add("OCS0103U15LaySlipCodeTreeRequest", "ocsa");
            servicesMap.Add("OCS0103U15GrdSlipHangmogRequest", "ocsa");
            //[END] OCS0103U15

            //[START] OCS0221Q01
            servicesMap.Add("OCS0221Q01DloOCS0221Request", "ocsa");
            servicesMap.Add("OCS0221Q01GrdOCS0222Request", "ocsa");
            //[END] OCS0221Q01

            // [START] OCS3003Q10
            servicesMap.Add("OCS3003Q10GrdOrderDateRequest", "ocsa");
            servicesMap.Add("OCS3003Q10GrdOrderRequest", "ocsa");
            servicesMap.Add("OCS3003Q10GrdSangRequest", "ocsa");
            //		_servicesMap.Add("OCS3003Q10TabOrderGubunWorkTp4Request", "ocsa");
            //		_servicesMap.Add("OCS3003Q10TabOrderGubunWorkTp5Request", "ocsa");

            // [END] OCS3003Q10

            //[START] OCS0203U00
            servicesMap.Add("OCS0203U00GrdOcs0203P1Request", "ocsa");
            servicesMap.Add("OCS0203U00LayOCS0212Request", "ocsa");
            servicesMap.Add("OCS0203U00LaySlipRequest", "ocsa");
            servicesMap.Add("OCS0203U00LoadAllMembRequest", "ocsa");
            servicesMap.Add("OCS0203U00GetOCSCOMUserIDRequest", "ocsa");
            servicesMap.Add("OCS0203U00SaveLayoutRequest", "ocsa");
            servicesMap.Add("OCS0203U00LoadGwaRequest", "ocsa");
            servicesMap.Add("OCS0203U00GetOCSCOMUserNameRequest", "ocsa");
            //[END] OCS0203U00


            //[START] OCS1003P01

            servicesMap.Add("OcsoOCS1003P01GridReserOrderListRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01GridPatientListRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01GridOutSangRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01GetChuciRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01BasLoadGwaNameRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01CheckXRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01UpdateJubsuRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01LayJinryoGwaRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01UpdateDoctorRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01CheckYRequest", "ocso");

            servicesMap.Add("OcsoOCS1003P01OutOrderEndTempRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01LayoutQueryRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01UpdateDcYnRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01InsertOutSangRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01InsertDataOCS1003Request", "ocso");
            servicesMap.Add("OcsoOCS1003P01UpdateDataOCS1003Request", "ocso");
            servicesMap.Add("OcsoOCS1003P01UpdateOutSangRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01CheckDataSendYnRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01DeleteFromOutsangRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01DeleteFromOCS1003Request", "ocso");
            servicesMap.Add("OcsoOCS1003P01GetOcsKeySeqRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01GetMaxOcs1003SeqRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01GetGwoFromOutsangRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01GetPkSeq1Request", "ocso");
            servicesMap.Add("OcsoOCS1003P01GetPkSeq2Request", "ocso");
            servicesMap.Add("OcsoOCS1003P01CheckUsedSangRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01CheckFkOcsRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01GetGubunRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01CheckIsSameNameYnRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01SangDupCheckRequest", "ocso");

            servicesMap.Add("OCS0132ComboListRequest", "ocso");
            servicesMap.Add("OCS1003P01SaveLayOutRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01BtnListQueryRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01LayPatRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01GetGroupKeyRequest", "ocso");

            servicesMap.Add("OCS1003P01ChangeUserRequest", "ocso");
            servicesMap.Add("OCS1003P01SettingVisibleByUserRequest", "ocso");
            servicesMap.Add("OcsoOCS1003P01GrdOutSangSaveLayoutRequest", "ocso");
            servicesMap.Add("OcsOCS1003P01CheckHangSangInfoRequest", "ocso");
            servicesMap.Add("OCS1003P01GetUserOptionAndOrderCountRequest", "ocso");
            servicesMap.Add("OCS1003P01OpenAllergyInforRequest", "ocso");
            servicesMap.Add("OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultRequest", "ocso");
            servicesMap.Add("OCS1003P01CheckPatientEtcRequest", "ocso");
            //[END] OCS1003P01

            //[START] OCS1003Q05
            servicesMap.Add("OcsoOCS1003Q05DiseaseListRequest", "ocso");
            servicesMap.Add("OcsoOCS1003Q05ScheduleRequest", "ocso");
            servicesMap.Add("OcsoOCS1003Q05OrderListRequest", "ocso");
            servicesMap.Add("OcsoOCS1003Q05CodeListRequest", "ocso");
            servicesMap.Add("OcsoOCS1003Q05ComboListRequest", "ocso");
            servicesMap.Add("OcsoOCS1003Q05GrdRowFocusChangedRequest", "ocso");
            //[END] OCS1003Q05

            //[START][SERVER][OUTSANGU00] - Manage injuries and diseases by patient
            servicesMap.Add("OUTSANGU00InitializeRequest", "ocso");
            servicesMap.Add("OUTSANGU00getCodeNameRequest", "ocso");
            servicesMap.Add("OUTSANGU00getFindWorkerRequest", "ocso");
            servicesMap.Add("OUTSANGU00createGwaDataRequest", "ocso");
            servicesMap.Add("OUTSANGU00TransactionRequest", "ocso");
            servicesMap.Add("OUTSANGU00GrdOCS0301Request", "ocso");

            // NEW
            servicesMap.Add("OUTSANGU00findBoxToGwaRequest", "ocso");
            servicesMap.Add("OUTSANGU00findBoxToDoctorRequest", "ocso");
            servicesMap.Add("OUTSANGU00GetGwaNameRequest", "ocso");
            servicesMap.Add("OUTSANGU00GetDoctorNameRequest", "ocso");
            servicesMap.Add("OUTSANGU00GridOutSangSaveLayoutRequest", "ocso");
            //[END][SERVER][OUTSANGU00] - Manage injuries and diseases by patient

            //[START] OCS1003Q02
            servicesMap.Add("OCS1003Q02GridOUT1001Request", "ocso");
            servicesMap.Add("OCS1003GrdOUT1001RowFocusChangedRequest", "ocso");
            //[END] OCS1003Q02

            //[START] OCS1003Q09
            servicesMap.Add("OCS1003Q09GridOCS1003AndSangRequest", "ocso");
            servicesMap.Add("OCS1003Q09GridOCS1003Request", "ocso");
            servicesMap.Add("OCS1003Q09GridOUT1001Request", "ocso");
            servicesMap.Add("OCS1003Q09LoadComboDataSourceRequest", "ocso");
            servicesMap.Add("OCS1003Q09CheckOrdDanuiRequest", "ocso");
            servicesMap.Add("OCS1003DloCheckLayoutRequest", "ocso");
            //[END]OCS1003Q09

            //[START]OCS1003R00----
            servicesMap.Add("OCS1003R00FormLoadRequest", "ocso");
            //[END]OCS1003R00------

            //[START]OCSACT------
            servicesMap.Add("OCSACTGroupedPatientAndOrderRequest", "ocso");
            servicesMap.Add("OCSACTCompositeFirstRequest", "ocso");
            servicesMap.Add("OCSACTCompositeSecondRequest", "ocso");
            servicesMap.Add("OCSACTDefaultJearyoRequest", "ocso");
            servicesMap.Add("OCSACTGrdSangByungRequest", "ocso");
            servicesMap.Add("OCSACTGrdPaListRequest", "ocso");
            servicesMap.Add("OCSACTBtnReportViewerClickRequest", "ocso");
            servicesMap.Add("OCSACTBtnReserViewerClickRequest", "ocso");
            servicesMap.Add("OCSACTGrdOrderGridColumnProtectModifyRequest", "ocso");
            servicesMap.Add("OCSACTGrdJaeryoGridColumnProtectModifyRequest", "ocso");
            servicesMap.Add("OCSACTCommandRequest", "ocso");
            servicesMap.Add("OCSACTTempOrderRequest", "ocso");
            servicesMap.Add("OCSACTLayconstantAlarmRequest", "ocso");
            servicesMap.Add("OCSACTLayconstantConstRequest", "ocso");
            servicesMap.Add("OCSACTCboSystemRequest", "ocso");
            servicesMap.Add("OCSACTCboIoGubunRequest", "ocso");
            servicesMap.Add("FwEMRHelperExecuteEMRRequest", "ocso");
            servicesMap.Add("OCSACTUpdateRequest", "ocso");
            servicesMap.Add("OCSACTBtnEMRClickRequest", "ocso");
            servicesMap.Add("OCSACTGrdJaeryoGridColumnChangedRequest", "ocso");
            servicesMap.Add("OCSACTGrdOrderGridColumnChangedRequest", "ocso");
            servicesMap.Add("OCSACTCheckNaewonYnRequest", "ocso");
            servicesMap.Add("OCSACTGetFindWorkerRequest", "ocso");

            servicesMap.Add("OCSACTGrdJearyoRequest", "ocso");
            servicesMap.Add("OCSACTCboSystemSelectedIndexChangedRequest", "ocso");
            servicesMap.Add("OCSACTGrdOrderRequest", "ocso");
            servicesMap.Add("OCSACTProcEkgInterfaceRequest", "ocso");
            servicesMap.Add("OCSACTGrdRowFocusChangedRequest", "ocso");
            servicesMap.Add("OCSACTChangeOrderCodeGrdOrderListRequest", "ocso");
            servicesMap.Add("OCSACTCboTimeAndSystemRequest", "ocso");
            //[END]OCSACT----

            //[START] OCS1023U00
            servicesMap.Add("OCS1023U00GrdOCS1023Request", "ocso");
            servicesMap.Add("OCS1023U00SaveLayoutRequest", "ocso");
            // [END] OCS1023U00

            //[START] OUTSANGQ00
            servicesMap.Add("OUTSANGQ00IsEnableSangCodeRequest", "ocso");
            servicesMap.Add("OUTSANGQ00LayoutGwaRequest", "ocso");
            servicesMap.Add("OUTSANGQ00GrdOutSangRequest", "ocso");
            //		OUTSANGQ00GrdOutSangRequest
            //[END] OUTSANGQ00

            //[START] OCS4001U00
            servicesMap.Add("OCS4001U00Request", "ocso");
            servicesMap.Add("OCS4001U00SaveRequest", "ocso");            
            //[END] OCS4001U00

            //[START]PFE0101U00
            servicesMap.Add("PFE0101U00GrdMCodeRequest", "pfes");
            servicesMap.Add("PFE0101U00GrdDCodeRequest", "pfes");
            servicesMap.Add("PFE0101U00LayDupDRequest", "pfes");
            servicesMap.Add("PFE0101U00LayDupMRequest", "pfes");
            servicesMap.Add("PFE0101U00LayUserNameRequest", "pfes");
            servicesMap.Add("PFE0101U00GrdDcodeColumnChangedRequest", "pfes");
            servicesMap.Add("PFE0101U00SaveLayoutRequest", "pfes");

            //[END]PFE0101U00

            //[START] PFE7001Q01
            servicesMap.Add("PFE7001Q01LayDailyReportRequest", "pfes");
            servicesMap.Add("PFE7001Q02LayMonthlyReportRequest", "pfes");
            //[END] PFE7001Q01

            //[START] PFE0101U01
            servicesMap.Add("PFE0101U01GrdDCodeRequest", "pfes");
            servicesMap.Add("PFE0101U01GrdMCodeRequest", "pfes");
            servicesMap.Add("PFE0101U01LayDupDRequest", "pfes");
            servicesMap.Add("PFE0101U01LayDupMRequest", "pfes");
            servicesMap.Add("PFE0101U01LayUserNameRequest", "pfes");
            servicesMap.Add("PFE0101U01SaveLayoutRequest", "pfes");
            //[END] PFE0101U01


            //-----[START] [PHY8002U00]

            servicesMap.Add("PHY8002U00GrdQueryRequest", "phys");
            servicesMap.Add("PHY8002U00GrdGroupQueryRequest", "phys");
            servicesMap.Add("PHY8002U00GrdPHYRequest", "phys");
            servicesMap.Add("PHY8002U00PrintRequest", "phys");
            servicesMap.Add("PHY8002U00SaveLayoutRequest", "phys");
            servicesMap.Add("PHY8002U00InsertInitValueRequest", "phys");
            //-----[END] [PHY8002U00]

            //-----[START] [PHY0001U00]
            servicesMap.Add("PHY0001U00GrdRehaSinryouryouCodeRequest", "phys");
            servicesMap.Add("PHY0001U00GrdOCS0132Request", "phys");
            servicesMap.Add("PHY0001U00SaveLayoutRequest", "phys");
            //-----[END] [PHY0001U00]

            //-----[START] [PHY2001U04]
            servicesMap.Add("PHY2001U04GrdExcelRequest", "phys");
            servicesMap.Add("PHY2001U04GrdInpRequest", "phys");
            servicesMap.Add("PHY2001U04GrdListRequest", "phys");
            servicesMap.Add("PHY2001U04GrdOutRequest", "phys");
            servicesMap.Add("PHY2001U04GrdOut1001Request", "phys");
            servicesMap.Add("PHY2001U04GrdPaCntRequest", "phys");
            servicesMap.Add("PHY2001U04LayDoctorNameRequest", "phys");
            servicesMap.Add("PHY2001U04GrdPatientListRequest", "phys");
            servicesMap.Add("PHY2001U04CboGwaRequest", "phys");
            servicesMap.Add("PHY2001U04SetSinryouryouAutoRequest", "phys");
            servicesMap.Add("PHY2001U04FnOutCheckNaewonYnRequest", "phys");
            servicesMap.Add("PHY2001U04GrdPatientListItemValueChangingRequest", "phys");
            servicesMap.Add("PHY2001U04BtnDeleteGetDataTableRequest", "phys");
            servicesMap.Add("PHY2001U04PrRehAddRehasinryouryouRequest", "phys");
            servicesMap.Add("PHY2001U04BtnDeleteExistYnRequest", "phys");
            servicesMap.Add("PHY2001U04BtnDeleteRequest", "phys");
            servicesMap.Add("PHY2001U04BtnJinryouEndClickUpdateOut1001Request", "phys");
            servicesMap.Add("PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Request", "phys");
            servicesMap.Add("PHY2001U04SaveLayoutRequest", "phys");
            servicesMap.Add("PHY2001U04LayNUR7001Request", "phys");
            servicesMap.Add("PHY2001U04PrOutMakeAutoJubsuRequest", "phys");
            servicesMap.Add("PHY2001U04FnPhyDupJubsuGubunRequest", "phys");
            servicesMap.Add("PHY2001U04RefreshCounterRequest", "phys");
            servicesMap.Add("PHY2001U04InsertVitalRequest", "phys");
            servicesMap.Add("PHY2001U04GetNewOrderFormOUTRequest", "phys");
            servicesMap.Add("PHY2001U04GetNewOrderFormINPRequest", "phys");
            servicesMap.Add("PHY2001U04GetServerIPRequest", "phys");
            servicesMap.Add("PHY2001U04JubsuFormCboGwaRequest", "phys");
            servicesMap.Add("PHY2001U04CboDoctorRequest", "phys");
            servicesMap.Add("PHY2001U04GrdOCS0132Request", "phys");
            servicesMap.Add("PHY2001U04CreateAutoJubsuRequest", "phys");

            //-----[END] [PHY2001U04]

            //-----[START] PHY8002U01
            servicesMap.Add("PHY8002U01GrdPHY8002Request", "phys");
            servicesMap.Add("PHY8002U01GrdPHY8003Request", "phys");
            servicesMap.Add("PHY8002U01GrdPHY8004Request", "phys");
            servicesMap.Add("PHY8002U01MultiGrdRequest", "phys");
            servicesMap.Add("PHY8002U01PHY1000U00ScreenOpenRequest", "phys");
            servicesMap.Add("PHY8002U01BtnPrintGetGwaNameRequest", "phys");
            servicesMap.Add("PHY8002U01BtnPrintGetDataWindowRequest", "phys");
            servicesMap.Add("PHY8002U01GetLayJissekiDataRequest", "phys");
            servicesMap.Add("PHY8002U01GetPhy8002SeqRequest", "phys");
            servicesMap.Add("PHY8002U01SaveLayoutRequest", "phys");
            servicesMap.Add("PHY8002U01GetScan001SeqRequest", "phys");
            servicesMap.Add("PHY8002U01LoadFnInpRequest", "phys");

            //-----[END] PHY8002U01


            //[START] - [SERVER][SCH0201Q01] - Inspection order list (Part)
            servicesMap.Add("SchsSCH0201Q01SCH0109ComboListRequest", "schs");
            servicesMap.Add("SchsSCH0201Q01SCH0001ComboListRequest", "schs");
            servicesMap.Add("SchsSCH0201Q01ExitsJundalTableRequest", "schs");
            servicesMap.Add("SchsSCH0201Q01ReserListRequest", "schs");
            servicesMap.Add("SchsSCH0201Q01GumsaComboListRequest", "schs");
            servicesMap.Add("SchsSCH0201Q01ReserListCboRequest", "schs");
            //[END] - [SERVER][SCH0201Q01] - Inspection order list (Part)

            //[START] - [SERVER][SCH0201Q02] - Inspection order list (Department)
            servicesMap.Add("SchsSCH0201Q02ReserList02Request", "schs");
            servicesMap.Add("SchsSCH0201Q02ReserList03Request", "schs");
            servicesMap.Add("SchsSCH0201Q02JundalComboListRequest", "schs");
            //[END] - [SERVER][SCH0201Q02] - Inspection order list (Department)

            //[START] - [SERVER][SCH0201Q04] - Refer order status by month
            servicesMap.Add("SchsSCH0201Q04PrartListRequest", "schs");
            servicesMap.Add("SchsSCH0201Q04GetMonthReserListInfoRequest", "schs");
            servicesMap.Add("SchsSCH0201Q04ReserTimeListRequest", "schs");
            servicesMap.Add("SchsSCH0201Q04PrSchTimeListRequest", "schs");
            servicesMap.Add("SchsSCH0201Q04GetCalReserRequest", "schs");
            servicesMap.Add("SchsSCH0201Q04GetFormLoadRequest", "schs");
            servicesMap.Add("SchsSCH0201Q04GetCboListRequest", "schs");
            //[END] - [SERVER][SCH0201Q04] - Refer order status by month

            //[START] - [SERVER][SCH0201Q12] - Outpatient inspection order list
            servicesMap.Add("SCH0201Q12ComboListRequest", "schs");
            servicesMap.Add("SCH0201Q12FwkDoctorListRequest", "schs");
            servicesMap.Add("SCH0201Q12GrdListRequest", "schs");
            servicesMap.Add("SCH0201Q12FindBoxRequest", "schs");
            servicesMap.Add("SCH0201Q12UpdateReserDataRequest", "schs");
            servicesMap.Add("SCH0201Q12UpdateKensaYnRequest", "schs");
            //[END] - [SERVER][SCH0201Q12] - Outpatient inspection order list

            //[START] [SERVER][SCH0201U99] - Manage inspection order
            servicesMap.Add("Schs0201U99CheckORCAEnvInfoRequest", "schs");
            servicesMap.Add("Schs0201U99BookingLabRequest", "schs");
            servicesMap.Add("Schs0201U99CheckReserRequest", "schs");
            servicesMap.Add("Schs0201U99CheckInsertRequest", "schs");
            servicesMap.Add("SchsSCH0201U99CommonDataRequest", "schs");
            servicesMap.Add("SchsSCH0201U99GrdOrderListRequest", "schs");
            servicesMap.Add("SchsSCH0201U99GrdTimeListRequest", "schs");
            servicesMap.Add("SchsSCH0201U99DateScheduleListRequest", "schs");
            servicesMap.Add("SchsSCH0201U99ReserListRequest", "schs");
            servicesMap.Add("SchsSCH0201U99ReserTimeChkRequest", "schs");
            servicesMap.Add("SchsSCH0201U99LayoutTimeListRequest", "schs");
            servicesMap.Add("SchsSCH0201U99LayoutCommonListRequest", "schs");
            servicesMap.Add("SchsSCH0201U99GetGwaNameRequest", "schs");
            servicesMap.Add("SchsSCH0201U99GetJundalPartNameRequest  ", "schs");
            servicesMap.Add("SchsSCH0201U99ExecIUDRequest", "schs");
            servicesMap.Add("SchsSCH0201U99ExecTimeListRequest", "schs");
            servicesMap.Add("SchsSCH0201U99ExecEtcInsertRequest", "schs");
            servicesMap.Add("SchsSCH0201U99DeleteSCH0201Request", "schs");

            servicesMap.Add("SchsSCH0201U99ComboGumsaPartRequest", "schs");
            //[END] [SERVER][SCH0201U99] - Manage inspection order

            //[START] SCH0109U00
            servicesMap.Add("SCH0109U00GrdDetailRequest", "schs");
            servicesMap.Add("SCH0109U00LayDupDRequest", "schs");
            servicesMap.Add("SCH0109U00GrdMasterRequest", "schs");
            servicesMap.Add("SCH0109U00LayDupMRequest", "schs");
            servicesMap.Add("SCH0109U00XSavePerformerRequest", "schs");
            //[END] SCH0109U00

            //[START] SCH0201Q05
            servicesMap.Add("SCH0201Q05LayReserListRequest", "schs");
            //[END] SCH0201Q05

            //[START] SCH3001U00
            servicesMap.Add("SCH3001U00GrdJukyongDateRequest", "schs");
            servicesMap.Add("SCH3001U00GrdSCH0001Request", "schs");
            servicesMap.Add("SCH3001U00GrdSCH0002Request", "schs");
            servicesMap.Add("SCH3001U00GrdSCH3000Request", "schs");
            servicesMap.Add("SCH3001U00GrdSCH3100Request", "schs");
            servicesMap.Add("SCH3001U00GrdSCH3101Request", "schs");
            servicesMap.Add("SCH3001U00GetCboGumsaRequest", "schs");
            servicesMap.Add("SCH3001U00VsvHangmogCodeRequest", "schs");
            servicesMap.Add("SCH3001U00VsvUserNameRequest", "schs");
            servicesMap.Add("SCH3001U00GrdSCH0002ValidateGridColumnChangedRequest", "schs");

            servicesMap.Add("SCH3001U00DeleteSelectedYoilRequest", "schs");
            servicesMap.Add("SCH3001U00XSavePerformerCase1Request", "schs");
            servicesMap.Add("SCH3001U00XSavePerformerCase2Request", "schs");
            servicesMap.Add("SCH3001U00XSavePerformerCase3Request", "schs");
            servicesMap.Add("SCH3001U00XSavePerformerCase4Request", "schs");
            servicesMap.Add("SCH3001U00XSavePerformerCase5Request", "schs");
            servicesMap.Add("SCH3001U00XSavePerformerCase6Request", "schs");
            servicesMap.Add("SCH3001U00XSavePerformerCase7Request", "schs");

            servicesMap.Add("SCH3001U00GrdSCH0001RowFocusChangedRequest", "schs");
            servicesMap.Add("SCH3001U00LoadDataForGridRequestInCaseDeleteRequest", "schs");
            servicesMap.Add("SCH3001U00LayDupOCS0103Request", "schs");
            servicesMap.Add("SCH3001U00BtnMake2SaveLayoutRequest", "schs");
            servicesMap.Add("SCH3001U00BtnBtnListUpdateRequest", "schs");
            //[END] SCH3001U00

            //[START] SCH0109U01
            servicesMap.Add("SCH0109U01GrdMasterRequest", "schs");
            servicesMap.Add("SCH0109U01LayDupDRequest", "schs");
            servicesMap.Add("SCH0109U01GrdDetailRequest", "schs");
            servicesMap.Add("SCH0109U01LayDupMRequest", "schs");
            servicesMap.Add("SCH0109U01SaveLayoutRequest", "schs");

            //[END] SCH0109U01

            //[START] SCH0201U10
            servicesMap.Add("SCH0201U10GrdOrderListRequest", "schs");
            servicesMap.Add("SCH0201U10LayReserInfoRequest", "schs");
            servicesMap.Add("SCH0201U10LayReserInfoQueryEndRequest", "schs");
            servicesMap.Add("SCH0201U10GrdReserListRequest", "schs");

            //[START] SCH0201U10



            //[START] ADM103U
            servicesMap.Add("ADM103UgrdUserGrpRequest", "adma");
            servicesMap.Add("ADM103LaySysListGrpRequest", "adma");
            servicesMap.Add("ADM103RegSystemFormSaveLayoutRequest", "adma");
            servicesMap.Add("ADM103SaveLayoutRequest", "adma");
            servicesMap.Add("ADM103LayLoginSysListRequest", "adma");
            //Added
            servicesMap.Add("ADM103UGetFwkHospitalRequest", "adma");
            servicesMap.Add("ADM103UValidateFwkHospitalRequest", "adma");
            //[END] ADM103U

            //[START] ADM104U
            servicesMap.Add("ADM104UFwkBuseoCodeRequest", "adma");
            servicesMap.Add("ADM104UGridUserRequest", "adma");
            servicesMap.Add("ADM104UFindBoxRequest", "adma");
            servicesMap.Add("ADM104UGridUserSaveLayoutRequest", "adma");
            //[END] ADM104U

            //[START] ADM101U
            servicesMap.Add("ADM101UGetGrpNmRequest", "adma");
            servicesMap.Add("ADM101UGrdGroupRequest", "adma");
            servicesMap.Add("ADM101UGrdSystemRequest", "adma");
            servicesMap.Add("ADM101USaveLayoutRequest", "adma");
            //[END] ADM101U

            //[START] ADM107U
            servicesMap.Add("Adm107ULayDownListRequest", "adma");
            servicesMap.Add("Adm107ULayRootListRequest", "adma");
            servicesMap.Add("Adm107UFbxSysIDDataValidatingRequest", "adma");
            servicesMap.Add("Adm107UFbxIDDataValidatingRequest", "adma");
            servicesMap.Add("Adm107USaveLayoutRequest", "adma");
            //new 
            servicesMap.Add("Adm107UFwkUserIdRequest", "adma");
            servicesMap.Add("ADM107UFwkSysIdRequest", "adma");
            servicesMap.Add("Adm107UFbxHospCodeDataValidatingRequest", "adma");

            //[END] ADM107U

            // [START] ADM106U
            servicesMap.Add("ADM106UFwkPgmIDRequest", "adma");
            servicesMap.Add("ADM106UMakeQueryListItemRequest", "adma");
            servicesMap.Add("ADM106UGetPgmNameRequest", "adma");
            servicesMap.Add("ADM106UGetSysNameRequest", "adma");
            servicesMap.Add("ADM106USaveLayoutRequest", "adma");
            // [END] ADM106U

            // [START] ADM108U
            servicesMap.Add("ADM108UGrdListRequest", "adma");
            servicesMap.Add("ADM108UFwkPgmIDRequest", "adma");
            servicesMap.Add("ADM108ULaySysListRequest", "adma");
            servicesMap.Add("ADM108UTvwSystemListRequest", "adma");
            servicesMap.Add("ADM108USaveLayoutRequest", "adma");
            //[END] ADM108U

            // [START] ADM102U
            servicesMap.Add("ADM102UGrdListRequest", "adma");
            servicesMap.Add("ADM102UGetSysNmRequest", "adma");
            servicesMap.Add("ADM102USaveLayoutRequest", "adma");
            // [END] ADM102U

            //[START] ADM501U
            servicesMap.Add("ADM501UKoreaListRequest", "adma");
            servicesMap.Add("ADM501UJapanListRequest", "adma");
            servicesMap.Add("ADM501USpeakListRequest", "adma");
            servicesMap.Add("ADM501UJapanEmptyListRequest", "adma");
            servicesMap.Add("ADM501USaveLayoutRequest", "adma");
            //[END] ADM501U

            //[START] ADM201U
            servicesMap.Add("ADM201UGrdDicDetailRequest", "adma");
            servicesMap.Add("ADM201UGrdDicMasterRequest", "adma");
            servicesMap.Add("ADM201USaveLayoutRequest", "adma");
            //[END] ADM201U

            //[START] ADM401U
            servicesMap.Add("ADM401UGrdSysRequest", "adma");
            servicesMap.Add("ADM401UGrdGrpRequest", "adma");
            servicesMap.Add("ADM401UAsmRequest", "adma");
            servicesMap.Add("ADM401UUpdateRequest", "adma");
            servicesMap.Add("ADM401UInsertRequest", "adma");
            //[END] ADM401U

            //[START] ADMS2015U01
            servicesMap.Add("ADMS2015U01GetSystemRequest", "adma");
            servicesMap.Add("ADMS2015U01SystemIdValidatingRequest", "adma");
            servicesMap.Add("ADMS2015U01LoadUpperMenuRequest", "adma");
            servicesMap.Add("ADMS2015U01LoadMenuItemRequest", "adma");
            servicesMap.Add("ADMS2015U01SettingMenuRequest", "adma");
            //[END] ADMS2015U01

            //[START] StartForm
            servicesMap.Add("ADMSStartFormLoginRequest", "adma");
            //[END] StartForm

            //[START] ADMS2015U00
            servicesMap.Add("ADMS2015U00GetGroupListRequest", "adma");
            servicesMap.Add("ADMS2015U00GetSystemListRequest", "adma");
            servicesMap.Add("ADMS2015U00LoadGroupSystemHospitalRequest", "adma");
            servicesMap.Add("ADMS2015U00GetSystemHospitalRequest", "adma");
            servicesMap.Add("ADMS2015U00CreateGroupHospitalRequest", "adma");
            //[END] ADMS2015U00



            //----[START] BAS0101U00 ------
            servicesMap.Add("BAS0101U00ExecuteRequest", "bass");
            servicesMap.Add("BAS0101U00grdDetailRequest", "bass");
            servicesMap.Add("BAS0101U00grdMasterRequest", "bass");
            servicesMap.Add("BAS0101U00PrBasGridColumnChangedRequest", "bass");
            // ----[END]   BAS0101U00 ------
            // [START] [BAS0270U00] - Manage doctor code
            servicesMap.Add("BAS0270U00FwkDoctorRequest", "bass");
            servicesMap.Add("BAS0270U00FwkDoctorGradeRequest", "bass");
            servicesMap.Add("BAS0270U00FwkGwaRequest", "bass");
            servicesMap.Add("BAS0270U00GrdBAS0271Request", "bass");
            servicesMap.Add("BAS0270U00GrdBAS0272Request", "bass");
            servicesMap.Add("BAS0270U00LayDoctorNameRequest", "bass");
            servicesMap.Add("BAS0270U00LayDoctorGradeRequest", "bass");
            servicesMap.Add("BAS0270U00LayGwaRequest", "bass");
            servicesMap.Add("BAS0270U00LayDupCheckRequest", "bass");
            servicesMap.Add("BAS0270U00ExecuteRequest", "bass");
            // [END] [BAS0270U00] - Manage doctor code

            // [START] [BAS0001U00] - Mannage hospital information
            servicesMap.Add("BAS0001U00ControlDataValidatingRequest", "bass");
            servicesMap.Add("BAS0001U00FbxDodobuHyeunFindClickRequest", "bass");
            servicesMap.Add("BAS0001U00FbxDodobuHyeunDataValidatingRequest", "bass");
            servicesMap.Add("BAS0001U00grdDetailRequest", "bass");
            servicesMap.Add("BAS0001U00grdMasterRequest", "bass");
            servicesMap.Add("BAS0001U00ExecuteRequest", "bass");
            servicesMap.Add("BAS0001U00GrdBAS0001Request", "bass");
            servicesMap.Add("BAS0001U00CboHospJinGubunRequest", "bass");
            // [END] [BAS0001U00] - Mannage hospital information

            // [START] [BAS0123U00] - Manage Zip code
            servicesMap.Add("BAS0123U00FwkZipCodeRequest", "bass");
            servicesMap.Add("BAS0123U00GrdBAS0123Request", "bass");
            servicesMap.Add("BAS0123U00LayTonggyeCodeRequest", "bass");
            servicesMap.Add("BAS0123U00LayZipCodeRequest", "bass");
            servicesMap.Add("BAS0123U00SaveLayoutRequest", "bass");
            // [END] [BAS0123U00] - Manage Zip code

            // [START] [BAS0210U00] - 
            servicesMap.Add("BAS0210U00layDupCheckRequest", "bass");
            servicesMap.Add("BAS0210U00DupCheckRequest", "bass");
            servicesMap.Add("BAS0210U00grdBAS0210GridColumnChangedRequest", "bass");
            servicesMap.Add("BAS0210U00fbxDataValidatingRequest", "bass");
            servicesMap.Add("BAS0210U00SaveLayoutRequest", "bass");
            servicesMap.Add("BAS0210U00fwkCommonRequest", "bass");
            servicesMap.Add("BAS0210U00grdBAS0210Request", "bass");
            // [END] [BAS0210U00] -

            //[START]BAS0230U00-
            servicesMap.Add("BAS0230U00GrdBas0230Request", "bass");
            servicesMap.Add("BAS0230U00GrdBas0230SaveLayoutRequest", "bass");
            //[END]BAS0230U00-

            // [START] - [BAS0260U00] - Manage dept code
            servicesMap.Add("Bas0260U00grdBuseoInitRequest", "bass");
            servicesMap.Add("Bas0260U00LayDupCheckRequest", "bass");
            servicesMap.Add("Bas0260U00TransactionalRequest", "bass");
            servicesMap.Add("Bas0260U00fwkBuseoGubunRequest", "bass");
            servicesMap.Add("Bas0260U00xEditGridCell19Request", "bass");
            servicesMap.Add("Bass0260U00DepartmentRequest", "bass");
            // [END] - [BAS0260U00] - Manage dept code

            // [START] - [BAS0260U01] - Manage dept code
            servicesMap.Add("LoadGrdBAS0260U01Request", "bass");
            servicesMap.Add("LoadCbxLanguageRequest", "bass");
            servicesMap.Add("SaveGrdBas0260U01Request", "bass");
            servicesMap.Add("Bas0260U01LoadDepartmentTypeRequest", "bass");
            // [END] - [BAS0260U01] - Manage dept code

            //[START] [BAS0110U00] - Manage Insurers number
            servicesMap.Add("BAS0110U00FwkCommonRequest", "bass");
            servicesMap.Add("BAS0110U00GrdJohapRequest", "bass");
            servicesMap.Add("BAS0110U00getCodeNameRequest", "bass");
            servicesMap.Add("BAS0110U00LayZipCode2Request", "bass");
            servicesMap.Add("BAS0110U00GrdJohapGubunRequest", "bass");
            servicesMap.Add("BAS0110U00LayDupCheckRequest", "bass");
            servicesMap.Add("BAS0110U00TransactionalRequest", "bass");
            // [END] [BAS0110U00] - Manage Insurers number

            // [START]IFS003U03
            servicesMap.Add("IFS003U03TransactionalRequest", "bass");
            // [END]IFS003U03

            //[START] BAS0310U00
            servicesMap.Add("BAS0310U00layGroupGubunCheckRequest", "bass");
            servicesMap.Add("BAS0310U00PostLoadRequest", "bass");
            servicesMap.Add("BAS0310U00MakeFindWorker2Request", "bass");
            servicesMap.Add("BAS0310U00MakeFindWorker3Request", "bass");
            servicesMap.Add("BAS0310U00MakeFindWorker4Request", "bass");
            servicesMap.Add("BAS0310U00MakeFindWorker5Request", "bass");
            servicesMap.Add("BAS0310U00MakeFindWorkerFbxMarumeGubunRequest", "bass");
            servicesMap.Add("BAS0310U00FbxBunCodeDataValidatingRequest", "bass");
            servicesMap.Add("BAS0310U00GrdListRequest", "bass");
            servicesMap.Add("BAS0310U00TransactionalRequest", "bass");
            //[END] BAS0310U00

            //[START] IFS0001U00
            servicesMap.Add("IFS0001U00GrdMasterRequest", "bass");
            servicesMap.Add("IFS0001U00GrdDetailRequest", "bass");
            servicesMap.Add("IFS0001U00PrCheckDupRequest", "bass");
            servicesMap.Add("IFS0001U00SaveLayoutRequest", "bass");
            servicesMap.Add("IFS0001U00FindBoxInitRequest", "bass");
            servicesMap.Add("IFS0001U00FindBoxRequest", "bass");
            servicesMap.Add("IFS0001U00FindBoxValidateRequest", "bass");
            //[END] IFS0001U00

            //[START] BAS0311Q01
            servicesMap.Add("BAS0311Q01GrdBAS0311Request", "bass");
            //[END] BAS0311Q01

            //[START] BAS0101U04
            servicesMap.Add("BAS0101U04GrdDetailRequest", "bass");
            servicesMap.Add("BAS0101U04GrdMasterRequest", "bass");
            servicesMap.Add("BAS0101U04SaveLayoutRequest", "bass");
            servicesMap.Add("BAS0101U04GrdMasterGridColumnChangedRequest", "bass");
            //[END] BAS0101U04

            //[START] IFS0003U01
            servicesMap.Add("IFS0003U01FwkCommonRequest", "bass");
            servicesMap.Add("IFS0003U01GrdIFS0003Request", "bass");
            servicesMap.Add("IFS0003U01LayDupCheckRequest", "bass");
            servicesMap.Add("IFS0003U01FbxSearchGubunDataValidatingRequest", "bass");
            servicesMap.Add("IFS0003U01GrdIFS0003GridFindClickRequest", "bass");
            servicesMap.Add("IFS0003U01GrdIFS0003GridColumnChangedRequest", "bass");
            servicesMap.Add("IFS0003U01SaveLayoutRequest", "bass");
            //[START] IFS0003U01

            // [START] IFS0003U00
            servicesMap.Add("IFS0003U00LayDupCheckRequest", "bass");
            servicesMap.Add("IFS0003U00FbxSearchGubunRequest", "bass");
            servicesMap.Add("IFS0003U00GridColumnChangeRequest", "bass");
            servicesMap.Add("IFS0003U00GrdIFS0003Request", "bass");
            servicesMap.Add("IFS0003U00GridFindClickRequest", "bass");
            servicesMap.Add("IFS0003U00SaveLayoutRequest", "bass");
            // [END] IFS0003U00

            // [START] IFS0004U01
            servicesMap.Add("IFS0004U01TransactionalRequest", "bass");
            servicesMap.Add("IFS0004U01grdDetailtRequest", "bass");
            servicesMap.Add("IFS0004U01grdMasterRequest", "bass");
            //[END] IFS0004U01

            // [START] COMBIZ
            servicesMap.Add("ComBizLoadIFS0001InfoRequest", "bass");
            servicesMap.Add("ComBizLoadIFS0002InfoRequest", "bass");
            servicesMap.Add("ComBizGetFindWorkerRequest", "bass");
            servicesMap.Add("ComBizLoadColumnCodeNameRequest", "bass");
            servicesMap.Add("ComBizLoadComboDataSourceRequest", "bass");
            // [END] COMBIZ

            //[START] BAS0110Q00
            servicesMap.Add("BAS0110Q00GrdBAS0110Request", "bass");
            //[END] BAS0110Q00

            //[START] BAS0203U00
            servicesMap.Add("BAS0203U00FwkBunCodeRequest", "bass");
            servicesMap.Add("BAS0203U00FwkSymyaGubunRequest", "bass");
            servicesMap.Add("BAS0203U00GrdBAS0203Request", "bass");
            servicesMap.Add("BAS0203U00LayDupCheckRequest", "bass");
            servicesMap.Add("BAS0203U00LaySgCodeRequest", "bass");
            servicesMap.Add("BAS0203U00CboYoilGubunRequest", "bass");
            servicesMap.Add("BAS0203U00LaySymyaGubunRequest", "bass");
            servicesMap.Add("BAS0203U00LayBunCodeRequest", "bass");
            servicesMap.Add("BAS0203U00SaveLayoutRequest", "bass");
            //[START] BAS0203U00



            //[START] CHT0110U00
            servicesMap.Add("CHT0110U00GetCodeNameRequest", "chts");
            servicesMap.Add("CHT0110U00ExecuteRequest", "chts");
            servicesMap.Add("CHT0110U00grdCHT0110Request", "chts");
            //[END] CHT0110U00

            //[START] [CHT0115Q01] - Register
            servicesMap.Add("CHT0115Q01grdCHT0115Request", "chts");
            servicesMap.Add("CHT0115Q01TransactionalRequest", "chts");

            //[END] [CHT0115Q01] - Register

            //[START] [CHT0117] Manage position code [treatment-surgery]
            servicesMap.Add("CHT0117GrdCHT0117InitRequest", "chts");
            servicesMap.Add("CHT0117GrdCHT0118InitRequest", "chts");
            servicesMap.Add("CHT0117LayNextSubBuwiCdRequest", "chts");
            servicesMap.Add("CHT0117grdCHT0117CheckRequest", "chts");
            servicesMap.Add("CHT0117TransactionalRequest", "chts");
            //[END] [CHT0117]Manage position code [treatment-surgery]

            //[START] [CHT0110Q01]
            servicesMap.Add("CHT0110Q01GrdCHT0110MListRequest", "chts");
            //[END] [CHT0110Q01]
            //[START] [CHT0115Q00]
            servicesMap.Add("CHT0115Q00GrdScPostRequest", "chts");
            servicesMap.Add("CHT0115Q00GrdScPreRequest", "chts");
            servicesMap.Add("CHT0115Q00SusikCodeRequest", "chts");
            servicesMap.Add("CHT0115Q00LayoutCommonRequest", "chts");
            //[END] [CHT0115Q00]

            //[START] CHT0117Q00
            servicesMap.Add("CHT0117Q00DloCHT0117Request", "chts");
            servicesMap.Add("CHT0117Q00GrdCHT0118Request", "chts");
            //[END] CHT0117Q00

            //[START] CHT0113Q00
            servicesMap.Add("CHT0113Q00GrdCHT0113Request", "chts");
            //[END] CHT0113Q00


            //[START][CPL0108U00] - [Manage type codes]
            servicesMap.Add("CPL0108U00GrdDetailRequest", "cpls");
            servicesMap.Add("CPL0108U00GrdMasterRequest", "cpls");
            servicesMap.Add("CPL0108U00CheckItemGrdMasterRequest", "cpls");
            servicesMap.Add("CPL0108U00CheckItemGrdDetailRequest", "cpls");
            servicesMap.Add("CPL0108U00SaveLayoutRequest", "cpls");
            //[END][CPL0108U00] - [Manage type codes]
            // --- [START] CPL0104U00 ---
            servicesMap.Add("CPL0104U00GrdDetailRequest", "cpls");
            servicesMap.Add("CPL0104U00GrdMasterRequest", "cpls");
            servicesMap.Add("CPL0104U00SaveLayoutRequest", "cpls");
            // --- [END] CPL0104U00---

            #region bug MED-8941 on CPL0000Q00 screen
            servicesMap.Add("CPL0000Q00GetSigeyulDataSelect1Request", "cpls");
            servicesMap.Add("CPL0000Q00GrdOrderListRequest", "cpls");
            servicesMap.Add("CPL0000Q00GrdResRequest", "cpls");
            servicesMap.Add("CPL0000Q00UpdateOCS5010Request", "cpls");
            #endregion

            // --- [START] CPL2010U00---
            servicesMap.Add("CPL2010U00ChangeTimeUpdateCPL2010Request", "cpls");
            servicesMap.Add("CPL2010U00MlayConstantInfoRequest", "cpls");
            servicesMap.Add("CPL2010U00LayPrintNameRequest", "cpls");
            servicesMap.Add("CPL2010U00LayBarcodeTemp2Request", "cpls");
            servicesMap.Add("CPL2010U00GrdOrderRequest", "cpls");
            servicesMap.Add("CPL2010U00OrderCancelGetYNRequest", "cpls");
            servicesMap.Add("CPL2010U00CheckInjCplOrderRequest", "cpls");
            servicesMap.Add("CPL2010U00ExecuteGetYValueRequest", "cpls");
            servicesMap.Add("CPL2010U00GrdPaListRequest", "cpls");
            servicesMap.Add("CPL2010U00OrderCancelGrdOrderRequest", "cpls");
            servicesMap.Add("CPL2010U00PaqryGrdPaRequest", "cpls");
            servicesMap.Add("CPL2010U00GrdTubeQueryStartingRequest", "cpls");
            servicesMap.Add("CPL2010U00GrdSpecimenRequest", "cpls");
            servicesMap.Add("CPL2010U00ChangeTimeGrdSpecimenRequest", "cpls");
            servicesMap.Add("CPL2010U00SetPrintRequest", "cpls");
            servicesMap.Add("CPL2010U00SaveLayoutRequest", "cpls");
            servicesMap.Add("CPL2010U00OrderCancelExecuteRequest", "cpls");
            servicesMap.Add("CPL2010U00VsvPaRequest", "cpls");
            servicesMap.Add("CPL2010U00LayChkNamesRequest", "cpls");
            servicesMap.Add("CPL2010U00CheckSpecimenDupRequest", "cpls");
            // --- [END] CPL2010U00---

            //[START][CPL0106U00] - [Manage group code]
            servicesMap.Add("CPL0106U00FwkGumsaRequest", "cpls");
            servicesMap.Add("CPL0106U00GrdCodeRequest", "cpls");
            servicesMap.Add("CPL0106U00GrdGroupRequest", "cpls");
            servicesMap.Add("CPL0106U00SaveLayoutRequest", "cpls");
            servicesMap.Add("CPL0106U00GridColumnChangeRequest", "cpls");
            //[END][CPL0106U00] - [Manage group code]
            //[START] CPL7001Q01
            servicesMap.Add("CPL7001CboUitakRequest", "cpls");
            servicesMap.Add("CPL7001Q01LayDailyReportRequest", "cpls");
            //[END] CPL7001Q01
            //[START] CPL7001Q02
            servicesMap.Add("CPL7001Q02LayMonthlyReportRequest", "cpls");
            //[END] CPL7001Q02

            //[START] CPL2010R01
            servicesMap.Add("CPL2010R01LayReserDateRequest", "cpls");
            servicesMap.Add("CPL2010R01LaySpecimenListRequest", "cpls");
            //[END] CPL2010R01

            //[START] CPL2010R00
            servicesMap.Add("CPL2010R00GetBarCodeRequest", "cpls");
            //[END] CPL2010R00

            //[START] CPL3010U00
            servicesMap.Add("CPL3010U00BtnUrineClickRequest", "cpls");
            servicesMap.Add("CPL3010U00QuerySpecimenBySerRequest", "cpls");
            servicesMap.Add("CPL3010U00GetYValueRequest", "cpls");
            servicesMap.Add("CPL3010U00QueryLaySpecimenReadUpdateRequest", "cpls");
            servicesMap.Add("CPL3010U00QueryLaySpecimenReadSelectJundalGubunRequest", "cpls");
            servicesMap.Add("CPL3010U00GetZValueRequest", "cpls");
            servicesMap.Add("CPL3010U00ExecuteRequest", "cpls");
            //new define
            servicesMap.Add("CPL3010U00QueryLaySpecimenReadRequest", "cpls");
            servicesMap.Add("CPL3010U00SaveLayoutRequest", "cpls");
            servicesMap.Add("CPL3010U00SaveLayUrineRequest", "cpls");

            servicesMap.Add("CPL3010U00DsvUrineRequest", "cpls");
            servicesMap.Add("CPL3010U00GrdGumRequest", "cpls");
            servicesMap.Add("CPL3010U00GrdPartRequest", "cpls");
            servicesMap.Add("CPL3010U00LayBarCodeTempRequest", "cpls");
            servicesMap.Add("CPL3010U00LayBarCodeTemp2Request", "cpls");
            servicesMap.Add("CPL3010U00LaySpecimenReadRequest", "cpls");
            servicesMap.Add("CPL3010U00LaySpecimenRequest", "cpls");
            servicesMap.Add("CPL3010U00VSVJubsujaRequest", "cpls");
            servicesMap.Add("CPL3010U00VSVJundalGubunRequest", "cpls");
            servicesMap.Add("CPL3010U00GetPrintNameRequest", "cpls");
            //[END] CPL3010U00

            //[START] CPL3020U00
            servicesMap.Add("CPL3020U00PrCplSpecimenInfoResultRequest", "cpls");
            servicesMap.Add("CPL3020U00PrOcsoChkResultMsgRequest", "cpls");
            servicesMap.Add("CPL3020U00PrOcsUpdateResultRequest", "cpls");
            servicesMap.Add("CPL3020U00Execute2ProceduresCheckRequest", "cpls");
            servicesMap.Add("CPL3020U00GetSpecimenInfoRequest", "cpls");
            servicesMap.Add("CPL3020U00ExecuteUpdateConfirmYNRequest", "cpls");
            servicesMap.Add("CPL3020U00SelectInOutGubunRequest", "cpls");
            servicesMap.Add("CPL3020U00ExecuteUpdateCplResultRequest", "cpls");
            servicesMap.Add("CPL3020U00PrCplCalInsertBaseResultRequest", "cpls");
            servicesMap.Add("CPL3020U00SelectFromStandardRequest", "cpls");
            servicesMap.Add("CPL3020U00ExecuteGetYValueRequest", "cpls");
            servicesMap.Add("CPL3020U00ExecuteUpdateCpl2090Request", "cpls");
            servicesMap.Add("CPL3020U00ExecuteInsertCpl2090Request", "cpls");
            servicesMap.Add("CPL3020U00FwkResultGetYRequest", "cpls");
            servicesMap.Add("CPL3020U00FwkResultInputSQLRequest", "cpls");
            servicesMap.Add("CPL3020U00LayCommonRequest", "cpls");
            servicesMap.Add("CPL3020U00ResultUpdateUpdateCPL3020Request", "cpls");
            //new
            servicesMap.Add("CPL3020U00GrdResultRequest", "cpls");
            servicesMap.Add("CPL3020U00GrdPaRequest", "cpls");
            servicesMap.Add("CPL3020U00FwkJundalGubunRequest", "cpls");
            servicesMap.Add("CPL3020U00FwkNoteGubunRequest", "cpls");
            servicesMap.Add("CPL3020U00GrdPaRowFocusChangedRequest", "cpls");
            servicesMap.Add("CPL3020U00SavePerformerRequest", "cpls");
            servicesMap.Add("CPL3020U00VsvNoteRequest", "cpls");
            //[END] CPL3020U00

            //----------[START] CPLCPL3010U01
            servicesMap.Add("CPL3010U01IsWriteFileSelectCodeValueRequest", "cpls");
            servicesMap.Add("CPL3010U01IsWriteFileUpdateNoParamRequest", "cpls");
            servicesMap.Add("CPL3010U01IsWriteFileSelectOrUpdateRequest", "cpls");
            servicesMap.Add("CPL3010U01SearchMaxInfoRequest", "cpls");
            //new define
            servicesMap.Add("CPL3010U01GrdHangmogRequest", "cpls");
            servicesMap.Add("CPL3010U01GrdResultRequest", "cpls");
            servicesMap.Add("CPL3010U01LaySpecimenRequest", "cpls");
            servicesMap.Add("CPL3010U01LayPrint2Request", "cpls");
            servicesMap.Add("CPL3010U01GrdPaRequest", "cpls");
            servicesMap.Add("CPL3010U01PrePrintRequest", "cpls");
            servicesMap.Add("CPL3010U01IsFileWriteRequest", "cpls");
            servicesMap.Add("CPL3010U01PrCplInsertCpl9000Request", "cpls");
            servicesMap.Add("CPL3010U01SaveLayoutRequest", "cpls");
            servicesMap.Add("CPL3010U01CodeValueRequest", "cpls");
            servicesMap.Add("CPL3010U01ExportFileRequest", "cpls");
            servicesMap.Add("CPL3010U01GetCboCompanyRequest", "cpls");

            //----------[END ] CPLCPL3010U01
            //[START] CPL0000Q00
            servicesMap.Add("CPL0000Q00LayJungboRequest", "cpls");
            servicesMap.Add("CPL0000Q00LaySigeyulTempRequest", "cpls");
            servicesMap.Add("CPL0000Q00LaySubHangmogRequest", "cpls");
            //		_servicesMap.Add("CPL0000Q00InitializeRequest", "cpls");
            servicesMap.Add("CPL0000Q00ScreenOpenUpdateRequest", "cpls");
            servicesMap.Add("CPL0000Q00LayOrderRequest", "cpls");
            servicesMap.Add("CPL0000Q00LayOrderResultListQueryRequest", "cpls");
            servicesMap.Add("CPL0000Q00LayOrderJubsuListQueryRequest", "cpls");
            servicesMap.Add("CPL0000Q00FrmGraphGetSigeyulRequest", "cpls");
            servicesMap.Add("CPL0000Q00GetSigeyulDataSelect2Request", "cpls");
            servicesMap.Add("CPL0000Q00ResultListQuerySelect1Request", "cpls");
            servicesMap.Add("CPL0000Q00ResultListQuerySelect2Request", "cpls");
            servicesMap.Add("CPL0000Q00InsertCPLTEMPRequest", "cpls");
            servicesMap.Add("CPL0000Q00DeleteAndSelectRequest", "cpls");
            servicesMap.Add("CPL0000Q00LayResultListTempRequest", "cpls");
            servicesMap.Add("CPL0000Q00FrmSigeyulDelCplTempRequest", "cpls");

            //[END] CPL0000Q00

            //[START] CPL3020U02
            //		_servicesMap.Add("CPL3020U02InitializeRequest", "cpls");
            servicesMap.Add("CPL3020U02ImportFileRequest", "cpls");
            servicesMap.Add("CPL3020U02SetAutoConfirmCheckedRequest", "cpls");
            servicesMap.Add("CPL3020U02GetSpecimenInfoSelectRequest", "cpls");
            servicesMap.Add("CPL3020U02ExecuteConfirmYNUpdateRequest", "cpls");
            servicesMap.Add("CPL3020U02ExecuteSelectInOutGubunRequest", "cpls");
            servicesMap.Add("CPL3020U02ExecuteCase1FinalUpdateCPL3020Request", "cpls");
            servicesMap.Add("CPL3020U02ExecuteCase2Request", "cpls");
            servicesMap.Add("CPL3020U02FwkResultQueryStartingRequest", "cpls");
            servicesMap.Add("CPL3020U02RESULTMAPInitializeRequest", "cpls");
            servicesMap.Add("CPL3020U02ExecuteCplResulUpdateRequest", "cpls");
            servicesMap.Add("CPL3020U02RESULTMAPPrCplResultMatchProcRequest", "cpls");
            servicesMap.Add("CPL3020U02SetDataIFS7203Request", "cpls");
            servicesMap.Add("CPL3020U02SetDataIFS7204Request", "cpls");
            //new
            servicesMap.Add("CPL3020U02ResultMapGrdIDRequest", "cpls");
            servicesMap.Add("CPL3020U02ResultMapGrdRsltRequest", "cpls");
            servicesMap.Add("CPL3020U02PrCplResultMatchProcRequest", "cpls");
            //[END] CPL3020U02	

            //[START] CPL0101U00
            servicesMap.Add("CPL0101U00GridMasterSaveLayoutRequest", "cpls");
            servicesMap.Add("CPL0101U00InitRequest", "cpls");
            servicesMap.Add("CPL0101U00MakeValSerViceRequest", "cpls");
            servicesMap.Add("CPL0101U00MakeFindWorkerRequest", "cpls");
            servicesMap.Add("CPL0101U00CheckHangMogCopyRequest", "cpls");
            servicesMap.Add("CPL0101U00PrCplCopyCPL0101Request", "cpls");
            //[END] CPL0101U00

            //[START] CPLFINDLIB
            servicesMap.Add("CPLFINDLIBGrdFindRequest", "cpls");
            //[END] CPLFINDLIB


            //[START] CPL3020U02-NEW
            servicesMap.Add("CPL3020U02CbxJangbiRequest", "cpls");
            servicesMap.Add("CPL3020U02GrdPaRequest", "cpls");
            servicesMap.Add("CPL3020U02GrdResultRequest", "cpls");
            servicesMap.Add("CPL3020U02AutoConfirmCheckedRequest", "cpls");
            servicesMap.Add("CPL3020U02SaveRequest", "cpls");
            //[END] CPL3020U02-NEW

            //[START] MultiResultView
            servicesMap.Add("MultiResultViewLayPaInfoRequest", "cpls");
            servicesMap.Add("MultiResultViewGrdSigeyul1Request", "cpls");
            servicesMap.Add("MultiResultViewGrdSigeyul2Request", "cpls");
            servicesMap.Add("MultiResultViewGetJubsuSigeyulRequest", "cpls");
            servicesMap.Add("MultiResultViewGetPreJubsuSigeyulRequest", "cpls");
            //[END] MultiResultView

            //[START] CPL0108U01
            servicesMap.Add("CPL0108U01LayDupMRequest", "cpls");
            servicesMap.Add("CPL0108U01LayDupDRequest", "cpls");
            servicesMap.Add("CPL0108U01GrdMasterRequest", "cpls");
            servicesMap.Add("CPL0108U01GrdDetailRequest", "cpls");
            servicesMap.Add("CPL0108U01SaveLayoutRequest", "cpls");
            servicesMap.Add("NUR2001U04CheckExistMedicalRecordRequest", "emr");
            servicesMap.Add("OCS2015U00GetMaxSizeRequest", "emr");
            servicesMap.Add("EMRSetDataForTvExamHistRequest", "emr");
            servicesMap.Add("OCS2015U21ControlDataValidatingRequest", "emr");
            servicesMap.Add("PatientInfoLoadPatientNaewonListRequest", "system");
            //[START] CPL0108U01

            // [START] END1000U02
            servicesMap.Add("END1001U02DsvDwRequest", "endo");
            servicesMap.Add("END1001U02DsvLDOCS0801Request", "endo");
            servicesMap.Add("END1001U02GrdComment3Request", "endo");
            servicesMap.Add("END1001U02GrdPaStatusRequest", "endo");
            servicesMap.Add("END1001U02GrdPurposeRequest", "endo");
            servicesMap.Add("END1001U02LayOrderDateRequest", "endo");
            servicesMap.Add("END1001U02UpdateMerGrdRequest", "endo");
            servicesMap.Add("END1001U02LoadCommentsRequest", "endo");
            servicesMap.Add("END1001U02BtnQueryRequest", "endo");
            servicesMap.Add("END1001U02OnLoadRequest", "endo");
            servicesMap.Add("END1001U02DsvGumsaNameRequest", "endo");
            servicesMap.Add("END1001U02GrdComment2Request", "endo");
            servicesMap.Add("END1001U02GrdComment1Request", "endo");
            // [END] END1000U02

            // Updated
            servicesMap.Add("OCS0103U00LoadAllComboRequest", "ocsa");
            servicesMap.Add("BAS0311U00GridListRequest", "bass");
            servicesMap.Add("BAS0311U00BilLoadRequest", "bass");
            // Start OUT1001R01
            servicesMap.Add("OUT1001R01GrdListRequest", "nuro");
            servicesMap.Add("OUT1001R01LayOut0101Request", "nuro");
            // End OUT1001R01

            servicesMap.Add("BAS0111U00GrdBas0111Request", "bass");
            servicesMap.Add("BAS0111U00GrdMasterRequest", "bass");
            servicesMap.Add("BAS0111U00LayGetJohapRequest", "bass");
            servicesMap.Add("BAS0111U00VzvJohapRequest", "bass");
            servicesMap.Add("BAS0111U00VzvZipCodeRequest", "bass");
            servicesMap.Add("BAS0111U00SaveLayoutRequest","bass");

            // Start OUT1001P03
            servicesMap.Add("OUT1001P03PaBeforeBoxRequest", "nuro");
            servicesMap.Add("OUT1001P03GrdAfterJubsuRequest", "nuro");
            servicesMap.Add("OUT1001P03GrdAfterOrderRequest", "nuro");
            servicesMap.Add("OUT1001P03GrdBeforeJubsuRequest", "nuro");
            servicesMap.Add("OUT1001P03GrdBeforeOrderRequest", "nuro");
            servicesMap.Add("OUT1001P03ProcessRequest", "nuro");
            servicesMap.Add("OUT1001P03BunhoListRequest", "nuro");
            //End OUT1001P03

            // Start BAS0310P01
            servicesMap.Add("BAS0310P01GrdDrugMasterRequest", "bass");
            servicesMap.Add("BAS0310P01GrdGenDrgMapRequest", "bass");
            servicesMap.Add("BAS0310P01GrdGenDrgMasterRequest", "bass");
            servicesMap.Add("BAS0310P01GrdJinryoMasterRequest", "bass");
            servicesMap.Add("BAS0310P01GrdJojeMasterRequest", "bass");
            servicesMap.Add("BAS0310P01GrdSangMasterRequest", "bass");
            servicesMap.Add("BAS0310P01GrdSusikMasterRequest", "bass");
            servicesMap.Add("BAS0310P01GrdTokuteiMasterRequest", "bass");
            servicesMap.Add("BAS0310P01GrdYjCodeRequest", "bass");
            servicesMap.Add("BAS0310P01GrdSaveLayRequest", "bass");
            servicesMap.Add("BAS0310P01ProcessRequest", "bass");
            servicesMap.Add("BAS0310P01GrdDrgSakuraRequest", "bass");
            //End BAS0310P01

            //Start OCS0118U00
            servicesMap.Add("OCS0118U00GrdSaveLayoutRequest", "ocsa");
            servicesMap.Add("OCS0118U00GrdOCS0118Request", "ocsa");
            servicesMap.Add("OCS0118U00CheckHangmogCodeRequest", "ocsa");
            servicesMap.Add("OCS0118U00FwkOCS0103Request", "ocsa");


            //Start CPLBMLUPLOADER
            servicesMap.Add("CPLBMLUPLOADERExcelInsertRequest", "cpls");
            servicesMap.Add("CPLBMLUPLOADERSavelayoutRequest", "cpls");
            //END CPLBMLUPLOADER
            //End OCS0118U00

            // DOC4003U00
            servicesMap.Add("DOC4003U00GrdDOC4003Request", "ocsa");
            servicesMap.Add("DOC4003U00GetHospRequest", "ocsa");
            servicesMap.Add("DOC4003U00GetNextValRequest", "ocsa");
            servicesMap.Add("DOC4003U00SaveLayoutRequest", "ocsa");

            //Start OCS1003R02
            servicesMap.Add("OCS1003R02LayR02QueryStartingRequest", "ocso");
            servicesMap.Add("OCS1003R02LayR03QueryStartingRequest", "ocso");
            //End OCS1003R02

            //Start CPL0001U00
            servicesMap.Add("CPL0001U00GrdSlipRequest", "cpls");
            servicesMap.Add("CPL0001U00GrdSaveRequest", "cpls");
            servicesMap.Add("CPL0001U00GrdChangeRequest", "cpls");
            servicesMap.Add("CPL0001U00GrdComboRequest", "cpls");
            servicesMap.Add("CPL0001U00CboJundalRequest", "cpls");

            //End CPL0001U00
            //Start Bas0212U00
            servicesMap.Add("BAS0212U00ComboListItemRequest", "bass");
            servicesMap.Add("BAS0212U00ListItemRequest", "bass");
            servicesMap.Add("BAS0212U00GrdItemRequest", "bass");
            servicesMap.Add("BAS0212U00TransactionalRequest", "bass");
            servicesMap.Add("BAS0212U00LaydupCheckRequest", "bass");
            servicesMap.Add("BAS0212U00fwkGongbiCodeRequest", "bass");
            //End Bas0212U00

            //Start CLIS2015U02
            servicesMap.Add("CLIS2015U02GrdProtocolRequest", "clis");
            servicesMap.Add("CLIS2015U02GrdStatusRequest", "clis");
            servicesMap.Add("CLIS2015U02CboStatusRequest", "clis");
            servicesMap.Add("CLIS2015U02SaveLayoutRequest", "clis");
            servicesMap.Add("CLIS2015U02GrdTrialDrgRequest", "clis");
            //End CLIS2015U02

            //Start CLIS2015U09
            servicesMap.Add("CLIS2015U09GrdRequest", "clis");
            servicesMap.Add("CLIS2015U09SaveRequest", "clis");
            servicesMap.Add("CLIS2015U09CheckSmoCodeRequest", "clis");
            servicesMap.Add("CLIS2015U09PrefectureCodeRequest", "clis");
            servicesMap.Add("CLIS2015U09GetCodeNameRequest", "clis");
            servicesMap.Add("CLIS2015U09CheckSmoCodeOnDeleteRequest", "clis");
            //End CLIS2015U09

            // CLIS2015U03 START
            servicesMap.Add("CLIS2015U03ProtocolListRequest", "clis");
            servicesMap.Add("CLIS2015U03PatientListRequest", "clis");
            servicesMap.Add("CLIS2015U03SearchPatientRequest", "clis");
            servicesMap.Add("CLIS2015U03CheckPatientRequest", "clis");
            servicesMap.Add("CLIS2015U03SaveLayoutRequest", "clis");
            servicesMap.Add("CLIS2015U03PatientListDataValidatingRequest", "clis");
            // CLIS2015U03 END

            servicesMap.Add("OCS0103U00GetProtocolRequest", "ocsa");
            servicesMap.Add("OCS0103U00GetNameProtocolRequest", "ocsa");
            servicesMap.Add("EMRGetLatestWarningStatusRequest", "emr");
            servicesMap.Add("CLIS2015U04GetPatientListItemRequest", "clis");           
            servicesMap.Add("CLIS2015U04GetPatientStatusListItemRequest", "clis");          
            servicesMap.Add("CLIS2015U04GetProtocolItemRequest", "clis");
            servicesMap.Add("CLIS2015U04GetProtocolListByPatientItemRequest", "clis");
            servicesMap.Add("CLIS2015U04UpdateStatusPatientItemRequest", "clis");
            servicesMap.Add("CLIS2015U13TrialItemListRequest", "clis");
            servicesMap.Add("ADM104UClisComboRequest", "adma");
            servicesMap.Add("CPLMASTERUPLOADERCboMstTypeRequest", "system");
            servicesMap.Add("CPLMASTERUPLOADERPRCplBmlUploaderRequest", "cpls");
            servicesMap.Add("CPLMASTERUPLOADERProcessRequest", "cpls");
            servicesMap.Add("CPLMASTERUPLOADERProcessUploadIFRequest", "cpls");

            // HOTCODEMASTER
            servicesMap.Add("HOTCODEMASTERGetGrdListRequest", "bass");
            servicesMap.Add("HOTCODEMASTERSaveLayoutRequest", "bass");
            servicesMap.Add("HOTCODEMASTERSaveOCS0103Request", "bass");

            // SYSTEM
            servicesMap.Add("ChangeSystemUserRequest", "system");
            servicesMap.Add("OcsEMRLoadComboInputTabRequest", "system");
            servicesMap.Add("FormSelectHospCodeRequest", "system");
            servicesMap.Add("GetPatientInsRequest", "system");

            // ORCA
            servicesMap.Add("ORCATransferOrdersRequest", "orca");
            servicesMap.Add("ORDERTRANSGrdListSendYnRequest", "nuro");
            servicesMap.Add("ORCALibGetClaimPatientRequest", "orca");
            servicesMap.Add("ORCALibAcquisitionRequest", "orca");
            servicesMap.Add("ORCALibGetClaimInsuredRequest", "orca");
            servicesMap.Add("ORCALibGetClaimOrderRequest", "orca");
            servicesMap.Add("ORCALibGetClaimDiagnosisRequest", "orca");
            servicesMap.Add("ORCALibGetClaimInfoRequest", "orca");
            //BAS2015U00 START
            servicesMap.Add("BAS2015U00MasterDataRequest", "bass");
            //BAS2015U00 END

            //KINKI
            servicesMap.Add("SyncDrugCheckingCacheRequest", "system");
            servicesMap.Add("SyncDosageAddtionCacheRequest", "system");
            servicesMap.Add("SyncDrugDosageCacheRequest", "system");
            servicesMap.Add("SyncDosageNormalCacheRequest", "system");
            servicesMap.Add("SyncDosageStandardCacheRequest", "system");
            servicesMap.Add("SyncGenericNameCacheRequest", "system");
            servicesMap.Add("SyncInteractionCacheRequest", "system");
            servicesMap.Add("SyncKinkiDiseaseCacheRequest", "system");
            servicesMap.Add("SyncKinkiMessageCacheRequest", "system");
            servicesMap.Add("SyncKinkiCacheRequest", "system");

            // ORCA/MISA
            servicesMap.Add("OrderTransMisaRequest", "nuro");
            servicesMap.Add("ORDERTRANSMisaGetHangmogRequest", "nuro");
            servicesMap.Add("ORDERTRANSMisaTranferRequest", "nuro");

            // NUR2016Q00
            servicesMap.Add("NUR2016Q00GrdHospListRequest", "nuro");
            servicesMap.Add("NUR2016Q00GrdPatientListRequest", "nuro");
            servicesMap.Add("NUR2016Q00LinkPatientRequest", "nuro");
            servicesMap.Add("NUR2016Q00CreateTempIDRequest", "nuro");
            servicesMap.Add("GetORCAEnvRequest", "system");
            servicesMap.Add("NUR2016CheckExitsEMRLinkRequest", "nuro");
            servicesMap.Add("NUR2016DeleteEMRLinkRequest", "nuro");
            servicesMap.Add("NUR2016PublishEMRLinkRequest", "nuro");

            // NUR2016U02
            servicesMap.Add("NUR2016U02GrdListRequest", "nuro");
            servicesMap.Add("NUR2016U02DeleteLinkPatientRequest", "nuro");

            // OUT2016U00
            servicesMap.Add("OUT2016U00PatientLinkingRequest", "ocso");
            servicesMap.Add("OUT2016U00UpdatePatientLinkingRequest", "ocso");

            // SCH0201U99
            servicesMap.Add("SCH0201U99BookingDetailRequest", "schs");

            servicesMap.Add("OCS2016U00GrdQuestionRequest", "ocso");
            servicesMap.Add("OCS2016U00AddQuestionRequest", "ocso");
            servicesMap.Add("OCS2016U00UpdateQuestionRequest", "ocso");
            servicesMap.Add("OCS2016U00UpdateReplyRequest", "ocso");
            servicesMap.Add("OCS2016U00LoadDiscussionRequest", "ocso");
            servicesMap.Add("OCS2016GetLinkingDepartmentRequest", "ocso");
            servicesMap.Add("OCS2016GetUserDepartmentRequest", "ocso");
            servicesMap.Add("SCH0201U99GetListBookingRequest", "schs");
            servicesMap.Add("OCS2016U00QuestionSaveLayoutRequest", "ocso");
            servicesMap.Add("PatientLinkingFwkDoctorRequest", "ocso");
            servicesMap.Add("OCS2016U00GetShardingHospitalRequest", "ocso");

            // ADM2016U00
            servicesMap.Add("ADM2016U00GrdLoadDrgRequest", "adma");
            servicesMap.Add("ADM2016U00NameTypeRequest", "adma");
            servicesMap.Add("HOTCODEMASTERSaveRequest", "adma");

            servicesMap.Add("LoadHangmogInfoCompositeFirstRequest", "system");
            servicesMap.Add("LoadHangmogInfoCompositeSecondRequest", "system");
            servicesMap.Add("OpenScreenU18CompositeRequest", "ocsa");
            servicesMap.Add("SettingDiscussRequest", "emr");
            servicesMap.Add("LoadEmrCompositeFirstRequest", "emr");
            servicesMap.Add("LoadEmrCompositeSecondRequest", "emr"); 
            servicesMap.Add("SaveEmrCompositeFirstRequest", "emr");
            servicesMap.Add("SaveEmrCompositeSecondRequest", "emr");
            servicesMap.Add("SaveEmrCompositeThirdRequest", "emr"); 
            servicesMap.Add("CPL2010U00OpenScreenCompositeRequest", "cpls");
            servicesMap.Add("GetEnablePostApproveRequest", "system"); 

            // OCSACT2
            servicesMap.Add("OCSACT2GetPatientListOCSRequest", "ocso");
            servicesMap.Add("OCSACT2GetPatientListINJRequest", "ocso");
            servicesMap.Add("OCSACT2GetPatientListCPLRequest", "ocso");
            servicesMap.Add("OCSACT2GetComboUserRequest", "ocso");
            servicesMap.Add("OCSACT2GetGrdPaListRequest", "ocso");
            servicesMap.Add("OCSACT2GetPatientExpandRequest", "emr");
            servicesMap.Add("OCSACT2CompositeRequest", "ocso");
            servicesMap.Add("OCSACT2CompositeSecondRequest", "emr");

            //BIL2016U01
            servicesMap.Add("BIL2016U01LoadPatientRequest", "bill");
            servicesMap.Add("LoadComboBIL2016U02Request", "bill");
            servicesMap.Add("LoadGridBIL2016U02Request", "bill");
            servicesMap.Add("SaveBIL2016U02Request", "bill");
            servicesMap.Add("LoadComboBIL2016U02RevertTypeRequest", "bill");
            servicesMap.Add("GetDataComboInvoiceBIL2016U02Request", "bill");
            servicesMap.Add("LoadGridPayHistoryBIL2016U02Request", "bill");
            servicesMap.Add("CheckLasteInvoiceBIL2016U02Request", "bill");
            servicesMap.Add("PrintDataComboInvoiceRequest", "bill");

            //BIL2016R01
            servicesMap.Add("BIL2016R01CboAllRequest", "bill");
            servicesMap.Add("BIL2016R01CboAssignDoctorRequest", "bill");
            servicesMap.Add("BIL2016R01CboExeDoctorRequest", "bill");
            servicesMap.Add("BIL2016R01GrdReportRequest", "bill");
            servicesMap.Add("BIL2016R01FbxServiceRequest", "bill");
            servicesMap.Add("BIL2016R01FbxServiceValidatingRequest", "bill");
            servicesMap.Add("BIL2016R01FbxPersonRequest", "bill");
            servicesMap.Add("BIL2016R01FbxPersonValidatingRequest", "bill");
            servicesMap.Add("BIL2016R01CboExeDeptRequest", "bill");
            servicesMap.Add("BIL2016R01FbxExeDoctorRequest", "bill");

            //BIL2016U00
            servicesMap.Add("BIL2016U00CboGroupTypeRequest", "bill");
            servicesMap.Add("BIL2016U00GrdMasterRequest", "bill");
            servicesMap.Add("BIL2016U00SaveGrdMasterRequest", "bill");
            servicesMap.Add("BIL2016U00FindBoxGroupRequest", "bill");
            servicesMap.Add("BIL2016U00FindBoxServiceRequest", "bill");
            servicesMap.Add("BIL2016U00DetailServiceRequest", "bill");

            //INV0101U00
            servicesMap.Add("CheckDuplicateDataINV0101Request", "invs");
            servicesMap.Add("LoadComboINV0101Request", "invs");
            servicesMap.Add("LoadGrdDetailINV0101Request", "invs");
            servicesMap.Add("LoadGrdMasterINV0101Request", "invs");
            servicesMap.Add("SaveLayoutINV0101Request", "invs");
            
            ///INV6002U00
            servicesMap.Add("INV6002U00GrdINV6002BeforeRequest", "invs");
            servicesMap.Add("INV6002U00GrdINV6002AfterRequest", "invs");
            servicesMap.Add("INV6002U00GrdINV6002ExcuteRequest", "invs");
            servicesMap.Add("INV6002U00GrdINV6002LoadcbxActorRequest", "invs");
            servicesMap.Add("INV6002U00GrdINV6002LoadCbxJaeryoGubunRequest", "invs");
            servicesMap.Add("INV6002U00GrdINV6002Request", "invs");

            // INV4001U00
            servicesMap.Add("INV4001U00Grd4001Request", "invs");
            servicesMap.Add("INV4001U00Grd4002Request", "invs");
            servicesMap.Add("INV4001U00DrugUserRequest", "invs");
            servicesMap.Add("INV4001U00LoadCodeNameRequest", "invs");
            servicesMap.Add("INV4001SaveLayoutRequest", "invs");
            servicesMap.Add("INV4001LoadBuseoRequest", "invs");
            servicesMap.Add("INV4001NextSeqRequest", "invs");
            servicesMap.Add("INV4001U00ExportCSVRequest", "invs");
            servicesMap.Add("INV4001U00Grd4001GenImportCodeRequest", "invs");

            // INV0110Q00
            servicesMap.Add("LoadINV0110Q00Request", "invs");

            // INV6000U00
            servicesMap.Add("INV6000U00UserLstRequest", "invs");
            servicesMap.Add("INV6000U00GrdINV6001Request", "invs");
            servicesMap.Add("INV6000U00LayINV6000Request", "invs");
            servicesMap.Add("INV6000U00LaySummaryDetailRequest", "invs");
            servicesMap.Add("INV6000U00LaySummaryMasterRequest", "invs");
            servicesMap.Add("INV6000U00SaveLayoutRequest", "invs");
            servicesMap.Add("INV6000U00ExportCSVRequest", "invs");
            //INV0101U01
            servicesMap.Add("INV0101U01GridMasterRequest", "invs");
            servicesMap.Add("INV0101U01GridDetailRequest", "invs");
            servicesMap.Add("CheckData0101U01Request", "invs");
            servicesMap.Add("SaveLayoutINV0101U01Request", "invs");
            servicesMap.Add("INV0101U01LoadComboRequest", "invs");
            //INV2003U00
            servicesMap.Add("INV2003U00GrdINV2004Request", "invs");
            servicesMap.Add("INV2003U00GrdINV2003Request", "invs");
            servicesMap.Add("INV2003U00CbxBuseoRequest", "invs");
            servicesMap.Add("INV2003U00CbxActorRequest", "invs");
            servicesMap.Add("INV2003U00SaveLayoutRequest", "invs");
            servicesMap.Add("INV2003U00GetCbxChulgoTypeRequest", "invs");
            servicesMap.Add("GetPkINV2003Request", "invs");
            servicesMap.Add("INV2003U00ExportCSVRequest", "invs");

            //ADMS2016U00
            servicesMap.Add("Adms2016U00GetMaintainanceSettingRequest", "adma");
            servicesMap.Add("Adms2016U00SaveMaintainanceSettingRequest", "adma");

            //ADM104Q
            servicesMap.Add("ADM104QGetPatientRequest", "adma");


            //2015U21
            servicesMap.Add("OCS2015U21GrdPatientRequest", "emr");
            servicesMap.Add("OCS2015U21GrdPatientCheckOrderRequest", "emr");

            //BIL0103U00
            servicesMap.Add("BIL0103U00LoadGridRequest", "nuro");
            servicesMap.Add("BIL0103U00SaveGridRequest", "nuro");

            return servicesMap;
        }
        #endregion

        #region CreateTimeOutSpecial
        /// <summary>
        /// CreateTimeOutSpecial
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, long> CreateTimeOutSpecial()
        {
            Dictionary<string, long> timeoutSpecial = new Dictionary<string, long>();

            timeoutSpecial.Add("BAS0310P01ProcessRequest", 10000000000);
            timeoutSpecial.Add("BAS0310P01GrdSaveLayRequest", 10000000000);
            timeoutSpecial.Add("CPLMASTERUPLOADERPRCplBmlUploaderRequest", 20000000000);
            timeoutSpecial.Add("HOTCODEMASTERSaveLayoutRequest", 10000000000);
            timeoutSpecial.Add("HOTCODEMASTERSaveOCS0103Request", 10000000000);
            timeoutSpecial.Add("BAS2015U00MasterDataRequest", 6000000000);
            timeoutSpecial.Add("UpdateMasterDataRequest", 3000000000);
            // https://sofiamedix.atlassian.net/browse/MED-13067
            timeoutSpecial.Add("OUT0101U02ImportPatientRequest", 10000000000);
            timeoutSpecial.Add("OCS2015U00EmrBackTimeRimindRequest", 50000000000);
            // https://sofiamedix.atlassian.net/browse/MED-16286
            timeoutSpecial.Add("CPLMASTERUPLOADERProcessUploadIFRequest", 50000000000);
            timeoutSpecial.Add("CPLMASTERUPLOADERProcessRequest", 50000000000);

            return timeoutSpecial;
        }
        #endregion

        #region EscapeSQLString
        /// <summary>
        /// EscapeSQLString
        /// </summary>
        /// <param name="paramStr"></param>
        /// <returns></returns>
        public static string EscapeSQLString(string paramStr)
        {
            if (paramStr == null) { return null; }
            StringBuilder buf = new StringBuilder();
            foreach (char c in paramStr)
            {
                foreach (char escapeChar in sqlEscapeChar)
                {
                    if (c == escapeChar)
                    {
                        buf.Append('[');
                        buf.Append(c);
                        buf.Append(']');
                        goto FOUND_ESCAPE_CHAR;
                    }
                }
                buf.Append(c);
            FOUND_ESCAPE_CHAR: ;
            }
            return buf.ToString();
        }
        #endregion

        public static string CreateMd5Hash(string input, bool upperCase)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString(upperCase ? "X2" : "x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Create a random string based on a specific size
        /// </summary>
        /// <param name="size">Length of random string</param>
        /// <returns></returns>
        public static string RandomString(int size)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                int number = rand.Next(48, 87);
                if (number >= 58 && number <= 64)
                {
                    i--;
                }
                else
                {
                    c = Convert.ToChar(Convert.ToInt32(number));
                    sb.Append(c);
                }
            }
            return sb.ToString().ToLower();
        }

        /// <summary>
        /// Configuration for clinics which using VPN or not
        /// </summary>
        /// <param name="key"></param>
        /// <param name="useVPN"></param>
        /// <returns></returns>
        public static string GetConfig(string key, bool useVPN)
        {
            string config = string.Empty;

            try
            {
                if (useVPN)
                {
                    key = VPN + key;
                }

                config = ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }

            return config;
        }

        #endregion
    }

    [Serializable]
    public class AttemptTime
    {
        public List<UserAttemptTime> LstAttempt = new List<UserAttemptTime>();

        public void SetAttemptTime(string userId, int attemptTime)
        {
            for (int i = 0; i < LstAttempt.Count; i++)
            {
                if (LstAttempt[i].UserId.Equals(userId))
                {
                    LstAttempt[i].AttemptTimes = attemptTime;
                }
            }
        }
        public void SetAttemptChangePass(string userId, int attemptChangePass)
        {
            for (int i = 0; i < LstAttempt.Count; i++)
            {
                if (LstAttempt[i].UserId.Equals(userId))
                {
                    LstAttempt[i].AttemptChangePass = attemptChangePass;
                }
            }
        }
        public void SetLockedTime(string userId, DateTime lockedTime)
        {
            for (int i = 0; i < LstAttempt.Count; i++)
            {
                if (LstAttempt[i].UserId.Equals(userId))
                {
                    LstAttempt[i].LockedTime = lockedTime;
                }
            }
        }

        public DateTime GetLockedTime(string userId)
        {
            for (int i = 0; i < LstAttempt.Count; i++)
            {
                if (LstAttempt[i].UserId.Equals(userId))
                {
                    return LstAttempt[i].LockedTime;
                }
            }
            return DateTime.MinValue;
        }

        public bool ContainsUser(string userId)
        {
            for (int i = 0; i < LstAttempt.Count; i++)
            {
                if (LstAttempt[i].UserId.Equals(userId))
                {
                    return true;
                }
            }
            return false;
        }

        public int GetAttemptTime(string userId)
        {
            for (int i = 0; i < LstAttempt.Count; i++)
            {
                if (LstAttempt[i].UserId.Equals(userId))
                {
                    return LstAttempt[i].AttemptTimes;
                }
            }
            return 0;
        }

        public int GetAttemptChangePass(string userId)
        {
            for (int i = 0; i < LstAttempt.Count; i++)
            {
                if (LstAttempt[i].UserId.Equals(userId))
                {
                    return LstAttempt[i].AttemptChangePass;
                }
            }
            return 0;
        }
    }
    [Serializable]
    public class UserAttemptTime
    {
        public string UserId;
        public int AttemptTimes;
        //2015.12.23 added by TungTx
        public DateTime LockedTime;
        public int AttemptChangePass;
    }

    [Serializable]
    public class CustomLayout
    {
        public List<UserCustomLayout> lstLayout = new List<UserCustomLayout>();

        public void SetMainLocation(string userId, string hospCode, Point location)
        {
            for (int i = 0; i < lstLayout.Count; i++)
            {
                if (lstLayout[i].UserId.Equals(userId) && lstLayout[i].HospCode.Equals(hospCode))
                {
                    lstLayout[i].MainLocation = location;
                }
            }
        }

        public void SetMainWidth(string userId, string hospCode, int width)
        {
            for (int i = 0; i < lstLayout.Count; i++)
            {
                if (lstLayout[i].UserId.Equals(userId) && lstLayout[i].HospCode.Equals(hospCode))
                {
                    lstLayout[i].MainWidth = width;
                }
            }
        }

        public void SetMainHeight(string userId, string hospCode, int height)
        {
            for (int i = 0; i < lstLayout.Count; i++)
            {
                if (lstLayout[i].UserId.Equals(userId) && lstLayout[i].HospCode.Equals(hospCode))
                {
                    lstLayout[i].MainHeight = height;
                }
            }
        }

        public int GetMainWidth(string userId, string hospCode)
        {
            for (int i = 0; i < lstLayout.Count; i++)
            {
                if (lstLayout[i].UserId.Equals(userId) && lstLayout[i].HospCode.Equals(hospCode))
                {
                    return lstLayout[i].MainWidth;
                }
            }
            return 0;
        }

        public int GetMainHeight(string userId, string hospCode)
        {
            for (int i = 0; i < lstLayout.Count; i++)
            {
                if (lstLayout[i].UserId.Equals(userId) && lstLayout[i].HospCode.Equals(hospCode))
                {
                    return lstLayout[i].MainHeight;
                }
            }
            return 0;
        }

        public Point GetMainLocation(string userId, string hospCode)
        {
            for (int i = 0; i < lstLayout.Count; i++)
            {
                if (lstLayout[i].UserId.Equals(userId) && lstLayout[i].HospCode.Equals(hospCode))
                {
                    return lstLayout[i].MainLocation;
                }
            }
            return new Point(0, 0);
        }

        public bool ContainsUser(string userId, string hospCode)
        {
            for (int i = 0; i < lstLayout.Count; i++)
            {
                if (lstLayout[i].UserId.Equals(userId) && lstLayout[i].HospCode.Equals(hospCode))
                {
                    return true;
                }
            }
            return false;
        }
    }

    [Serializable]
    public class UserCustomLayout
    {
        public string UserId;
        public string HospCode;
        public Point MainLocation;
        public int MainWidth;
        public int MainHeight;
    }
}
