package nta.med.data.dao.medi.cpl;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect1ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00LayJungboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00LayOrderListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00LayResultListTempListItemInfo;
import nta.med.data.model.ihis.cpls.CPL2010R00GetBarCodeInfo;
import nta.med.data.model.ihis.cpls.CPL2010R01LaySpecimenListItemInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01CHANGETIMEgrdSpecimenInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01grdPaInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01grdPaListInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01grdSpecimenInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01layBarcodeTempInfo;
import nta.med.data.model.ihis.cpls.CPL2010U01layBarcodeTempInfo2;
import nta.med.data.model.ihis.cpls.CPL2010U02grdSpecimenInfo;
import nta.med.data.model.ihis.cpls.CPL2010U02layBarcodeInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00GrdPartListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00LayBarCodeTemp2ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00LayBarCodeTempListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00LaySpecimenInfoListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U01MaxInfoListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00SelectFromStandardListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U00SelectInOutGubunListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02ExecuteSelectInOutGubunListItemInfo;
import nta.med.data.model.ihis.cpls.CPL7001Q01LayDailyReportInfo;
import nta.med.data.model.ihis.cpls.CPL7001Q02LayMonthlyReportInfo;
import nta.med.data.model.ihis.cpls.CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00FwkPaCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdOrderCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdPaCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdTubeCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdTubeCPL2010ListItemInfo2;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00LayChkNameCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00PrCplBunhoLoadMinCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.MultiResultViewSearchDataSigeyulInfo;
import nta.med.data.model.ihis.cpls.PrCplSpecimenInfoResultListItemInfo;
import nta.med.data.model.ihis.drgs.CPL2010U01grdTubeInfo;
import nta.med.data.model.ihis.ocso.OCSACT2GetPatientListCPLInfo;
/** * @author dainguyen.
 */
public interface Cpl2010RepositoryCustom {
	public List<CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo> getCPL2010U00ChangeTimeGrdSpecimenListItemInfo(String hospCode,String orderDate,
			String bunho,String gwa,String gubun,String doctor,String inOutGubun,String language);
	public List<CplsCPL2010U00FwkPaCPL2010ListItemInfo> getCPL2010U00FwkPaListItemInfo(String hospCode,String language,String orderDate,
			String jubsuYn,String bunho,String suname,String gwaName,String orderTime);
	public List<CplsCPL2010U00GrdOrderCPL2010ListItemInfo> getCplsCPL2010U00GrdOrderListItemInfo(String hospCode,String language,String bunho,
			String mijubsu,String reserYn,String fromDate,String toDate,String doctor,String emergencyYn);
	public List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo2> getCplsCPL2010U00GrdTubeListItemInfo(String hospCode,String language,String jubuDate,String jubsuTime,String bunho);
	public List<CplsCPL2010U00LayChkNameCPL2010ListItemInfo> getCplsCPL2010U00LayChkNameListItemInfo(String hospCode,String bunho,String reserDate);
	public String getCPL2010U00CheckInjCplOrder(String ioGubun,String bunho,Date orderDate,String hospCode);
	public List<CplsCPL2010U00GrdPaCPL2010ListItemInfo> getCplsCPL2010U00GrdPaCPL2010ListItemInfo(String hospCode,String language,String fromDate,String toDate,String bunho);
	public List<CplsCPL2010U00GrdPaCPL2010ListItemInfo> getCplsCPL2010U00GrdPaCPL2010ListItemInfo2(String hospCode,String language,String fromDate,String toDate,String bunho);
	public List<CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo> getCPL2010U00OrderCancelGrdOrder(String hospCode,String language,String bunho,Date orderDate);
	public List<CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo> getCPL2010U00PaqryGrdPaListItemInfo(String hospCode,String language,String orderDate,String jubsyYn,String bunho,String suname,String gwaName,String orderTime);
	public List<CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo> getCPL2010U00PaqryGrdPaListItemInfo2(String hospCode,String language,String orderDate,String jubsyYn,String bunho,String suname,String gwaName,String orderTime);
	public List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo> getCPL2010U00GrdTubeQueryStarting(String hospCode,String language,String orderDate,String orderTime,String bunho);
	public List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo2> getCPL2010U00GrdTubeQueryStarting2(String hospCode,String language,String orderDate,String orderTime,String bunho);
	public List<CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo> getCplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo(
			String hospCode,String orderDate,String bunho,String gwa,String gubun,String doctor,String inOutGubun);
	
	public List<CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo> getCPL2010U00GrdSpecimenListItemInfo(String hospCode,String language,Date orderDate,String bunho,
			String gwa,String orderTime,String doctor,Date reserDate,Date jubsuDate,String jubsuTime,String jubsuja,Double groupSer,String RerverYn,String emergencyYn);
	public List<CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo> getCPL2010U00GrdSpecimenListItemInfo2(String hospCode,String language,Date orderDate,Double groupSer,
			String bunho,String gwa,String orderTime,String doctor,Date jubsuDate,String jubsuTime,String jubsuja,String reserYn,Date reserDate,String emergencyYn);
	public List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> getCplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo(String hospCode,String language,Date jubsuDate,String bunho);
	public List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> getCplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo2(String hospCode,String language,String specimenSer);
	public String callCPL2010U00PrCplMakeSpecimenSer(String hospCode,String language,Date orderDate,String bunho,String jubsuja,String jubsuFlag,String jubsuGubun,Date jubsuDate,String jubsuTime);
	public void callCPL2010U00PrSchUpdateActing(String hospCode, String iOGubun, Double fkocs1003, Date actingDate);
	public void callCPL2010U00PrOcsUpdateJubsu(String hospCode, String iOGubun, Integer fkocs1003, String jubsuBuseo, Date jubsuDate, String jubsuTime); 
	public String callCPL2010U00PrCplPartJubsu(String hospCode,String specimenSer,String jundalGunbun,Date partJubsuDate,String partJubsuTime,String partJubsuja,String userId);
	public CplsCPL2010U00PrCplBunhoLoadMinCPL2010ListItemInfo callCPL2010U00PrCplBunhoLoadMin(String hospCode,String language,String bunho);
	public List<CPL3010U01MaxInfoListItemInfo> getCPL3010U01MaxInfoListItemInfo(String hosCode,String fromPartJubsuDate,String toPartJubsuDate,String fromSeq,String toSeq);
	public List<CPL3010U01MaxInfoListItemInfo> getCPL3010U01MaxInfoListItemInfo2(String hospCode,String fromSpecimenSer,String toSpecimenSer);

	public List<CPL7001Q01LayDailyReportInfo> getCPL7001Q01LayDailyReportInfo(String hospCode, String language, String kensadate,
			String ioGubun, String uitakCode);
	
	public List<CPL7001Q02LayMonthlyReportInfo> getCPL7001Q02LayMonthlyReportInfo(String hospCode, String language, String fromDate,
			String toDate, String ioGubun, String uitakCode);
	
	public List<String> getCPL2010R01InitializeReserDateList(String hospCode, String hoDong, String fromDate, String toDate);
	
	public List<CPL2010R01LaySpecimenListItemInfo> getCPL2010R01LaySpecimenListItemInfo(String hospCode, String language, String hoDong, String reserDate);
	
	public List<CPL2010R00GetBarCodeInfo> getCPL2010R00GetBarCodeInfo(String hospCode, String language, String specimenSer);
	
	public List<CPL3010U00LaySpecimenInfoListItemInfo> getCPL3010U00LaySpecimenInfoListItemInfo(String hospCode, String language, String specimenSer);
	
	public List<CPL3010U00LayBarCodeTemp2ListItemInfo> getCPL3010U00LayBarCodeTemp2ListItemInfo(String hospCode, String language, String specimenSer);
	
	public List<CPL3010U00LayBarCodeTempListItemInfo> getCPL3010U00LayBarCodeTempListItemInfo(String hospCode, String language, String specimenSer);
	
	public List<CPL3010U00GrdPartListItemInfo> getCPL3010U00GrdPartListItemInfo(String hospCode, String language, String partJubsuDate);
	 
	public List<CPL3010U00GrdPartListItemInfo> getCPL3010U00QuerySpecimenBySer(String hospCode, String language, String specimenSer);
	
	public String getCPL3010U00GetYValue(String hospCode,String specimenSer, boolean isNull);
	
	public String callPrCplPartJubsuCancel(String userId, String specimenSer, Double fkcpl2010, String gubun, String hospCode,String ioFlag);
	
	public String checkSpecimenSerCPL3010U00Execute(String hospCode, String specimenSer);
	public List<CPL0000Q00LayJungboListItemInfo> getCPL0000Q00LayJungboListItemInfo(String hospCode, String language, String specimenSer, String hangmogCode, String specimenCode,
			String emegency);
	
	public List<CPL0000Q00LayOrderListItemInfo> getCPL0000Q00LayOrder(String hospCode, String language, String bunho);
	
	public List<CPL0000Q00LayOrderListItemInfo> getCPL0000Q00LayOrderResultList(String hospCode, String language, String bunho);
	
	public List<CPL0000Q00LayOrderListItemInfo> getCPL0000Q00LayOrderJubsuList(String hospCode, String language, String bunho);
	
	public List<CPL0000Q00GetSigeyulDataSelect1ListItemInfo> getCPL0000Q00FrmGraphGetSigeyul(String hospCode, String bunho,String baseDate, String userId, String conditionValue);
	
	public List<CPL0000Q00LayResultListTempListItemInfo> getCPL0000Q00LayResultListTemp1(String hospCode, String language, String bunho, 
			String orderDate, String jundalGubun, String gwa, String doctor);
	
	public List<CPL0000Q00LayResultListTempListItemInfo> getCPL0000Q00LayResultListTemp2(String hospCode, String language, String bunho,
			String resultDate, String jundalGubun);
	
	public List<CPL0000Q00LayResultListTempListItemInfo> getCPL0000Q00LayResultListTemp3(String hospCode, String language, String bunho,
			String jubsuDate, String jundalGubun);
	
	public List<CPL3020U02ExecuteSelectInOutGubunListItemInfo> getCPL3020U02ExecuteSelectInOutGubunListItemInfo(String hospCode,String inOutGubun, Double pkcpl2010);

	public List<CPL3020U00SelectFromStandardListItemInfo> getCPL3020U00SelectFromStandard(String hospCode, Double pkcpl3020);
	
	public List<CPL3020U00SelectInOutGubunListItemInfo> getCPL3020U00SelectInOutGubun(String hospCode, String fkcpl2010);

	public PrCplSpecimenInfoResultListItemInfo prCplSpecimenInfoResult(String hospCode, String specimenSer);
	
	public List<MultiResultViewSearchDataSigeyulInfo> getMultiResultViewSearchSigeyulInfo1(String hospCode, String bunho, String userId, String gubun, String baseDate);
	public List<MultiResultViewSearchDataSigeyulInfo> getMultiResultViewSearchSigeyulInfo2(String hospCode, String bunho, String userId, String gubun, String baseDate);
	public List<OCSACT2GetPatientListCPLInfo> getOCSACT2GetPatientListCPLInfo(String hospCode,String language, String fromDate, String toDate,String bunho);
	public List<OCSACT2GetPatientListCPLInfo> getOCSACT2GetPatientListCPLInfo2(String hospCode,String language, String fromDate, String toDate, String bunho);
	
	public List<CPL2010U01CHANGETIMEgrdSpecimenInfo> getCPL2010U01CHANGETIMEgrdSpecimenInfo(String hospCode, String orderDate, String bunho, String gwa, String doctor);
	public List<CPL2010U02grdSpecimenInfo> getCPL2010U02grdSpecimenInfo(String hospCode, String language, String jubsuYn, String bunho, String fromDate, String toDate, String hoDong, Integer startNum, Integer offset);
	public List<CPL2010U01grdPaInfo> getCPL2010U01grdPaInfo(String hospCode, String language, String bunho, String reserYn, String fromDate, String toDate, String doctor, String emergencyYn, Integer startNum, Integer offset, boolean rbxmijubsu);
	public List<CPL2010U01grdPaListInfo> getCPL2010U01grdPaListInfo(String hospCode, String language, String reserYn, String fromDate, String toDate, String hoDong, Integer startNum, Integer offset, boolean rbxmijubsu);
	public List<CPL2010U01grdSpecimenInfo> getCPL2010U01grdSpecimenInfo(String hospCode, String language, String orderDate, String bunho, String gwa, String orderTime, String doctor, String reserYn, String reserDate, String jubsuDate, String jubsuTime, String groupSer, String emergencyYn, Integer startNum, Integer offset, boolean rbxmijubsu);
	public List<CPL2010U01grdTubeInfo> getCPL2010U01grdTubeInfo(String hospCode, String language, String sqlIndex, String jubsuDate, String jubsuTime, String bunho, Date reserDate, String reserYn);
	public List<CPL2010U01layBarcodeTempInfo> getCPL2010U01layBarcodeTempInfo(String hospCode, String language, Date jubsuDate, String bunho);
	public List<CPL2010U01layBarcodeTempInfo2> getCPL2010U01layBarcodeTempInfo2(String hospCode, String language, String specimenSer);
	public List<CPL2010U01grdTubeInfo> getXCPL2010U01grdTubeInfo(String hospCode, String language, String jubsuDate, String jubsuTime, String bunho, Date reserDate, String reserYn);
	public List<CPL2010U02layBarcodeInfo> getCPL2010U02layBarcodeInfo(String hospCode, String language, String specimenSer);
	
}


