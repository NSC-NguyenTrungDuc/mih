package nta.med.data.dao.medi.ocs;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import nta.med.core.domain.ocs.Ocs0103;
import nta.med.data.model.ihis.bass.ComBizGetFindWorkerInfo;
import nta.med.data.model.ihis.bill.BIL2016U00DetailServiceInfo;
import nta.med.data.model.ihis.bill.BIL2016U00ServiceInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DRG3010Q12AntibioticListgrdAntibioticListInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00SunalAndSubulInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U10GrdDrgOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U10GrdGeneralInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U10SetTabWonnaeDrgInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U11GrdSlipHangMogListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U11LoadSlipHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U12LoadDrgOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdSangyongOrderListInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdSearchOrderListInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdSpecimenListInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U13LaySpecimenTreeListInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U14GrdSlipHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U15GrdSlipHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U16GrdSangyongOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U16GrdSlipHangmogInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U17GrdSearchOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0108U00grdOCS0103ItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0113U00GrdOCS0103ListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0118U00GrdOCS0118Info;
import nta.med.data.model.ihis.ocsa.OCS0203U00GrdOcs0203P1Info;
import nta.med.data.model.ihis.ocsa.OCS0311Q00LayDownListQueryEndResInfo;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetHangmogGridFindListInfo;
import nta.med.data.model.ihis.ocsa.OCS0311U00laySetHangmogListInfo;
import nta.med.data.model.ihis.ocsa.Ocs0103Q00LoadOcs0103ListItemInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridReserOrderListInfo;
import nta.med.data.model.ihis.ocso.PrOcsLoadSubulSuryangInfo;
import nta.med.data.model.ihis.pfes.PFE7001Q01LayDailyReportInfo;
import nta.med.data.model.ihis.pfes.PFE7001Q02LayMonthlyReportInfo;
import nta.med.data.model.ihis.system.GetJundaTableResponseInfo;
import nta.med.data.model.ihis.system.LoadHangmogInfo;
import nta.med.data.model.ihis.system.OBGetJundaTable1Info;
import nta.med.data.model.ihis.system.OBLoadSearchOrderInfoDRGInfo;
import nta.med.data.model.ihis.system.OCS0103U12SetTabWonnaeDrugInfo;
import nta.med.data.model.ihis.xrts.XRT0000Q00LayOrderListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdJaeryoItemInfo;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdOrderItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0103RepositoryCustom {
	
	/**
	 * @param hospCode
	 * @param bunho
	 * @param naewonDate
	 * @return
	 */
	public List<OcsoOCS1003P01GridReserOrderListInfo> getOcsoOCS1003P01GridReserOrderList(String language, String hospCode, String bunho, String naewonDate);
	
	public List<PFE7001Q01LayDailyReportInfo> getPFE7001Q01LayDailyReportInfo(String hospCode, String language, String kensadate,
			String ioGubun, String partCode);
	
	public List<PFE7001Q02LayMonthlyReportInfo> getPFE7001Q02LayMonthlyReportInfo(String hospCode, String language, String fromDate
			,String toDate, String ioGubun, String partCode);
	public List<XRT0000Q00LayOrderListItemInfo> getXRT0000Q00LayOrderList(String hopsCode,String language,String bunho,String jubdalPar,String sort);
	public List<OCS0311U00grdSetHangmogGridFindListInfo> getOCS0311U00grdSetHangmogGridFindListInfo(String hospCode,String language,String hangmogCode);
	public List<OCS0311U00laySetHangmogListInfo> getOCS0311U00laySetHangmogListInfo(String hospCode,String code);
	
	public String getSCH3001U00VsvHangmogCode(String hospCode, String hangmogCode,boolean limit);
	
	public String getSCH3001U00GrdSCH0002ValidateGridColumnChanged(String hospCode, String hangmogCode);
	public String getLoadColumnCodeNameInfoCaseHangmogCode(String hospCode,String arg1,String arg2);
	public List<OCS0103U13LaySpecimenTreeListInfo> getOCS0103U13LaySpecimenTreeListInfo(String hospCode, String language, String user);
	public List<OCS0103U13GrdSearchOrderListInfo> getOCS0103U13GrdSearchOrderListInfo(String hospCode,String searchWord,String orderDate, String protocolId, Integer startNum, Integer offset, String language);
	public List<OCS0103U13GrdSpecimenListInfo> getOCS0103U13GrdSpecimenListInfo(String hospCode,String cqlCodeYn,
			String mode,String slipCode,String searchWord,String wonnaeDrg,Date orderDate,String inputTab,String user, String protocolId, Integer startNum, Integer offset);
	
	public String getOCS0101U00Grd0103CheckData(String hospCode, String value);
	
	public List<OCS0113U00GrdOCS0103ListItemInfo> getOCS0113U00GrdOcs0103ListItem(String hospCode, String slipCode, String hangmogName);
	
	public List<GetJundaTableResponseInfo> getOCSLibOrderBizGetJundaTableListItemInfo(String hospCode, String hangmongCode, String appDate, String ioeGubun, String JundalPart);
	public List<OCS0103U13GrdSangyongOrderListInfo> getGrdSangyongOrderListInfo(String hospCode, String user,
			String ioGubun, String orderGubun, Date orderDate, String searchWord, String wonaeDrgYn, String protocolId, Integer startNum, Integer endNum, String language);
	public List<OCS0103U16GrdSangyongOrderInfo> getOCS0103U16GrdSangyongOrderInfo(String hospCode,String language,String user,
			String codeYn,String ioGubun,Date orderDate,String searchWord,String wonaeDrgYn,String orderGubun, String protocolId);
	public List<OCS0103U16GrdSlipHangmogInfo> getOCS0103U16GrdSlipHangmogInfo(String hospCode,String language,String mode,String xrayCodeYn,
			String slipCode,Date orderDate,String inputTab,String xrayBuwi,String wonnaeDrgYn,String searchWord);
	public List<OCS0103U14GrdSlipHangmogInfo> getOCS0103U14GrdSlipHangmogInfo(String hospCode,String pfeCodeYn,String mode,String slipCode,
			String serachWord,String wonnaeDrgYn,Date orderDate,String inputTab,String user, String protocolId, Integer startNum, Integer endNum);
	
	public List<OCS0103U12LoadDrgOrderInfo> getOCS0103U12LoadDrgOrderListItem(String hospCode, String language, String mode, String code, String wonnaeDrgYn, Date orderDate,
			String searchWord, String protocolId, Integer startNum, Integer offset);
	
	public String callFnOcsCheckBreakPatStatus(String hospCode, String bunho, String hangmogCode);
	public LoadHangmogInfo callPrOcsLoadHangmogInfo(String hospCode,Date appDate,String inputPart,String inputGwa,String hangmogCode,String inputTab);
	public List<OCS0103U10GrdDrgOrderInfo> listOCS0103U10GrdDrgOrderInfo(String hospCode, String language,
			String mode, String code1, String wonnaeDrgYn, Date orderDate, String searchWord, String bunho, Integer startNum, Integer offset);
	public List<OCS0103U10GrdGeneralInfo> listOCS0103U10GrdGeneralInfo(String hospCode, String filter, String yakkijunCode, String orderDate, String hangmogCode, String language);
	
	public List<OCS0103U12SetTabWonnaeDrugInfo> getOCS0103U12SetTabWonnaeDrugListItem(String hospCode, String yakKijunCode, String orderDate, String hangmogCode);
	public List<OCS0103U10SetTabWonnaeDrgInfo> getOCS0103U10SetTabWonnaeDrgInfo(String hospCode, String yakKijunCode, String orderDate, String hangmogCode);
	public List<OCS0108U00grdOCS0103ItemInfo> getOCS0108U00grdOCS0103ItemInfo(String hospCode, String language, String hangmogNameInx, String slipCode);
	public List<OBLoadSearchOrderInfoDRGInfo> getOBLoadSearchOrderInfoDRGInfo(String hospCode, String language, String genericSearchYn,
			String searchWord, String gijunDate, String wonnaeDrgYn, String inputTab, String protocolId,Integer startNum, Integer offset);
	public List<OBGetJundaTable1Info> getOBGetJundaTable1Info(String hospCode, String hangmogCode, String ioeGubun, String jundalPart);
	
	public List<OCS0103U17GrdSearchOrderInfo> getOCS0103U17LoadHangwiOrder3ListItem(String hospCode, String codeYn,
			String mode, String slipCode, String searchWord, String wonnaeDrgYn, Date orderDate, String inputTab, String user, String protocolId, Integer pageNumber, Integer offset, String language);
	
	public String getOCS0103U17IsJundalTable(String hospCode, String hangmogCode, String ioGubun, String jundalTable);
	public String getHIGetGenericName(String hospCode,String hangmogCode);
	public String getHIGetHangmogName(String hospCode,String hangmogCode);
	public List<OCS0103U11GrdSlipHangMogListItemInfo> getOCS0103U11GrdSlipHangMog(String hospCode,String language,
			String slipCode,String searchWord,Date orderDate);
	
	public List<OCS0103U11LoadSlipHangmogInfo> getOCS0103U11LoadSlipHangmogListItem(String hospCode, String language, String slipCode, String searchWord, Date orderDate, String protocolId);
	
	public String fnOcsIsGeneralYn(String hospCode, String hangmogCode);
	
	public List<Ocs0103Q00LoadOcs0103ListItemInfo> getOcs0103Q00LoadOcs0103(String hospCode, String queryCode, String orderGubun, String childYn, String inputTab, Integer startNum, Integer offset, String language);
	public PrOcsLoadSubulSuryangInfo callPrOcsLoadSubulSuryang(String hospCode,String gubun,String hangmogCode,
			String orderDanui,Integer divide,String dvTime, Integer orderSuyang,Integer nalsu,Date appDate);
	public List<OCS0311Q00LayDownListQueryEndResInfo> getOCS0311Q00LayDownListQueryEndResInfo(String hospCode,String language,String convertHangmogCode);
	
	public List<XRT0201U00GrdOrderItemInfo> getXRT0201U00GrdOrderItem(String hospCode, String language, String ioGubun, String actGubun, String reserYn,
			Date orderDate, Date fromDate, Date toDate, String naewonKey, String emergency, String jundalTableCode, String jundalPart, String bunho, String doctor);
	
	public List<XRT0201U00GrdJaeryoItemInfo> getXRT0201U00GrdJaeryoItem(String bunho, String orderDate, String ioGubun, String jundalPart, Double fkocs, String hospCode, 
			String language);
	
	public List<ComBizGetFindWorkerInfo> getComBizGetFindWorkerCaseHangmogCode(String hospCode, String find, String arg1);
	
	public List<OCS0103U15GrdSlipHangmogInfo> getOCS0103U15GrdSlipHangmogInfo(String hospCode, String mode, String slipCode, String wonnaeDrgYn,
			Date orderDate, String inputTab, String searchWord, String protocolId, Integer startNum, Integer offset);
	
	public List<OCS0203U00GrdOcs0203P1Info> getOCS0203U00GrdOcs0203P1Info(String hospCode, String slipCode, String memb);
	
	public List<ComboListItemInfo> getOCS0118U00FwkOCS0103Info(String hospCode, String find1);
	
	public List<OCS0118U00GrdOCS0118Info> getOCS0118U00GrdOCS0118Info(String hospCode, String hangmogName);
	
	public String callPrAdmUpdateMasterSakura(String hospCode, String userId, String procGubun);
	
	public String callPrAdmUpdateMasterGd(String hospCode, String userId, String procGubun);
	
	public List<ComboListItemInfo> getClis2015U13TrialItemListInfo(String hospCode, String protocolId);
	public List<ComboListItemInfo> getClis2015U02TrialItemListInfo(String hospCode, Integer protocolId, Integer pageNumber, Integer offset);
	public OCS0103U00SunalAndSubulInfo callFnOcsLoadSunalAndSubulDanuiName(String hospCode, String language, String hangmogCode, Date hangmogStartDate);
	
	public List<OCS0103U10GrdDrgOrderInfo> listOCS0103U10GrdDrgOrderInfoCaseTrialFlg(String hospCode, String language, String mode, String code1,
			String wonnaeDrgYn, Date orderDate, String searchWord, String bunho); 
	
	public List<String> getClassCodeFromOrcaMappring(String hospCode, String sgCode);
	public List<String> findHangmogCodeExt(String hospCode, String bunho, BigDecimal fkout1001, String hangmogCode);
	public String callPrOcs0103U00UpdateMaster(String hospCode);
	public LoadHangmogInfo callPrOcsLoadHangmogInfoCommonYn(String hospCode,Date appDate,String inputPart,String inputGwa,String hangmogCode,String inputTab);

	public List<BIL2016U00ServiceInfo> getBIL2016U00ServiceInfo(String hospCode, String hangmogNameInx, String orderGubun, String codeType, String language, Integer pageNumber, Integer offset);
	
	public List<String> getCommonYnList(String hospCode, List<String> hangmog);

	public String loadJaeryoYn(String hospCode, String hangmogCode);
	public List<ComboListItemInfo> getOCS2005U00SetHangmogName(String hospCode, String hangmogCode);
	public String getOCS2005U00checkInputControl(String hospCode, String hangmogCode);

	public List<DRG3010Q12AntibioticListgrdAntibioticListInfo> getDRG3010Q12AntibioticListgrdAntibioticListInfo(String hospCode, String language);
} 

