package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect1ListItemInfo;
import nta.med.data.model.ihis.nuro.OUT1001P03GrdOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103Q00CreateOrderGubunInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U12MakeSangyongTabInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U18MakeJaeryoGubunTabListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0108U00CreateComboItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0131U00GrdOCS0132Info;
import nta.med.data.model.ihis.ocsa.OCS0221Q01DloOCS0221Info;
import nta.med.data.model.ihis.ocsa.Ocs0131U01Grd0132ListItemInfo;
import nta.med.data.model.ihis.ocsa.Ocs3003Q10GrdOrderListItemInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0221U00GrdOCS0221ListInfo;
import nta.med.data.model.ihis.ocsi.OCS1024U00xEditGridCell20Info;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GetChuciInfo;
import nta.med.data.model.ihis.phys.PHY0001U00GrdOCS0132Info;
import nta.med.data.model.ihis.phys.PHY0001U00GrdRehaSinryouryouCodeInfo;
import nta.med.data.model.ihis.system.CheckHideButtonInfo;
import nta.med.data.model.ihis.system.HILoadCodeNameInfo;
import nta.med.data.model.ihis.system.LoadOcs0132Info;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdPaListItemInfo;
/**
 * @author dainguyen.
 */
public interface Ocs0132RepositoryCustom {
	
	/**
	 * @param hospCode
	 * @param codeType
	 * @param valuePoint
	 * @return
	 */
	public List<OcsoOCS1003P01GetChuciInfo> getOcsoOCS1003P01GetChuciInfo(String hospCode, String codeType, String valuePoint);
	
	public List<ComboListItemInfo> getOcsoOCS1003P01GetGubunInfo(String hospCode, String code, String codeType, String language);
	
	public List<String> getOcsoOCS1003Q05CodeList(String language, String hospCode, String codeType);
	
	public List<ComboListItemInfo> getOCS0132ComboList(String hospCode,String language, String codeType);
	
	public List<String> getOCS0132CodeNameList(String hospCode,String language, String codeType, String code,boolean isOrder);
	
	public List<OcsaOCS0221U00GrdOCS0221ListInfo> getOcsaOCS0221U00GrdOCS0221List(String hospCode, String language, String memb);
	
	public List<ComboListItemInfo> getOcsaOCS0221U00CommonListItem(String language);
	
	public List<ComboListItemInfo> getInjsComboListItemInfo(String hospCode, String language, String codeType);
	
	public List<ComboListItemInfo> getPFE7001CboPartInfo(String hospCode, String language);
	
	public List<ComboListItemInfo> getXRT7001Q01CboPart(String hospCode,String language,String codeType);
		
	public List<ComboListItemInfo> getOCS0311U00CboPartBySetTable(String hospCode,String language,String currGroupID);

	public List<OCS0131U00GrdOCS0132Info> getOCS0131U00GrdOCS0132Info(String hospCode,String codeType);
	public List<ComboListItemInfo> getOCS1003Q05JusaComboBox(String hospCode, String codeType, String language, String code, String order);
	public List<OCS0108U00CreateComboItemInfo> getOCS0108U00CreateComboItemInfo(String hospCode,String language);
	public String getLoadColumnCodeNameInfoCaseCode(String hospCode,String language,String arg1,String arg2);
	public List<ComboListItemInfo> getComboDataSourceInfoByCodeType(String hospCode, String language, String codeType, boolean isAll);
	public List<ComboListItemInfo> getComboDataSourceInfoByCodeTypeOrOrderBy(String hospCode, String language, String codeType, boolean isOrder);
	public List<ComboListItemInfo> getComboDataSourceInfoCaseOrderGubunBas(String hospCode,String language);
	
	public List<ComboListItemInfo> getOCS0101U00ComboListItem(String hospCode, String codeType, String language);
	
	public List<ComboListItemInfo> getOCS0103U12CboInitGubunListItem(String hospCode,String language);
	
	public List<ComboListItemInfo> getOCS0103U12CboDvTimeListItemInfo(String hospCode, String code, String codeType, String language);
	
	public List<OCS0103U12MakeSangyongTabInfo> getOCS0103U12MakeSangyongTabListItem(String memb, String inputTab, String hospCode,String language);
	
	public List<OCS0103U12MakeSangyongTabInfo> getOCS0103U12MakeSangyongTabListItemElse(String memb, String hospCode,String language);

	public String getSubPartDoctor(String hospCode, String doctor, String subSystemId);
	
	public Date getFnDrgGetCycleOrdDate(String hospCode, Date ordDate, String hoDong);
	public List<ComboListItemInfo> getOCS0103U12FbxJusaComboListItemInfo(String hospCode,String language,String find,String agr1);
	
	public List<HILoadCodeNameInfo> getHILoadCodeNameInfo(String hospCode,String language,String orderGubun,
			String specimenCode,String jusa,String pay,String orderGubunBas,String bogyongCode,
			String jusaSpdGubun,String jundaPartOut,String judalPartInp,String ordDanui,String hangmogCode);
	public List<ComboListItemInfo> getOCS0103U10CboInputGubun(String hospCode,String language);
	public List<ComboListItemInfo> getOCS0103U10SearchConditionCbo(String hospCode,String language,String codeType,boolean isOrderBy);
	public List<ComboListItemInfo> getOCS0103U10SearchConditionCbo(String hospCode,String language,String codeType);

	public List<ComboListItemInfo> getOcsLibComboListItemInfo(String hospCode,String language,String codeType);
	
	public String callFnOcsBogyongColName(String orderGubunBas, String bogyongCode, String jusaSpdGubun, String hospCode, String language);
	
	public List<OCS0103U18MakeJaeryoGubunTabListItemInfo> getOCS0103U18InitializeScreenMakeJaeryoGubunTabListItem(String hospCode, String inputTab, String language);
	public List<ComboListItemInfo> getOCS0803U00CreateCombo(String hospCode,String language);
	public List<ComboListItemInfo> getComboOrdDanui(String hospCode,String language);
	public List<ComboListItemInfo> getComboDataSourceInfoCaseDvTime(String hospCode,String language);
	public List<ComboListItemInfo> getComboJusaSpdGubun(String hospCode,String language);
	
	
	
	
	public List<OCS0103Q00CreateOrderGubunInfo> getOCS0103Q00CreateOrderGubun(String hospCode, String inputTab);
	
	public List<Ocs0131U01Grd0132ListItemInfo> getOcs0131U01Grd0132ListItemInfo(String codeType, String hospCode, String language);
	public List<ComboListItemInfo> getCodeCodeNameListItemInfo(String hospCode, String find1, String language);
	public List<String> getGroupKeyFromVwOcsDummyOrderMaster(String code);
	public List<ComboListItemInfo> getCodeCodeNameWhereNURItemInfo (String hospCode,String language, String codeType, String groupKey,boolean isAll);
	
	public List<XRT0201U00GrdPaListItemInfo> getXRT0201U00GrdPaListItem(String hospCode, String language, String ioGubun, String actGubun,
			String jundalTableCode, String jundalPart, String bunho, Date fromDate, Date toDate);
	
	public List<LoadOcs0132Info> getLoadOcs0132Info(String hospCode,String language, String codeType, String code);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String language, String codeType, boolean isConcat);

	public List<PHY0001U00GrdOCS0132Info> getPHY0001U00GrdOCS0132Info(String hospCode, String language, String codeType);
	
	public List<PHY0001U00GrdRehaSinryouryouCodeInfo> getPHY0001U00GrdRehaSinryouryouCodeInfo(String hospCode, String language, String codeType);
	public List<ComboListItemInfo> getPhy8002U01GrdOTListItemInfo(String hospCode, String codeType, String groupKey, String language);
	public List<OCS0221Q01DloOCS0221Info> getOCS0221Q01DloOCS0221Info (String hospCode, String categoryGubun, String memb, String language);
	
	public List<Ocs3003Q10GrdOrderListItemInfo> getOcs3003Q10GrdOrderListItem(String hospCode, String language, Date naewonDate, String ioGubun,
			String orderGubun, String bunho, Double pkocskey, String jubsuNo, String gwa, String doctor) ;
	
	public List<Ocs3003Q10GrdOrderListItemInfo> getOcs3003Q10GrdOrderListItemUnion(String hospCode, String language, Date naewonDate, String ioGubun,
			String orderGubun, String bunho, Double pkocskey, String jubsuNo, String gwa, String doctor) ;
	
	public List<String> getOCS2015U06OrderTypeComboInfo(String hospCode, String codeType, String code, String language);
	
	public List<OUT1001P03GrdOrderInfo> getOUT1001P03GrdOrderInfo(String hospCode, String language,String ioGubun, String bunho, Double naewonKey, boolean isBefore);
	
	public List<CheckHideButtonInfo> getCheckHideButtonInfo(String hospCode, String codeType);
	public List<ComboListItemInfo> getCodeAndCodeNameByCodeType(String hospCode, String language, String codeType);
	
	public List<ComboListItemInfo> getComboListJusa(String hospCode, String argu1);
	public String callFnOcsLoadCodeName(String hospCode, String language, String codeType, String code);
	public List<OCS1024U00xEditGridCell20Info> getOCS1024U00xEditGridCell20Info(String hospCode, String language);
	public List<ComboListItemInfo> getOCS2003P01MakeInputGubunTabRequest(String hospCode, String language, String code, String codeType, boolean isAll);
	public List<ComboListItemInfo> getOCS2005U00fwkCombo(String hospCode, String language, String codeType, String codeName);
	public List<CPL0000Q00GetSigeyulDataSelect1ListItemInfo> getCPL0000Q00GetSigeyulDataSelect1ListItemInfo(String hospCode, String language);
	
	public List<ComboListItemInfo> getgetComboDataSourceInfoCaseOrderCaseHodong(String hospCode, String agr1, String language);
	public List<ComboListItemInfo> findCbxByCodeTypeTextSearch(String hospCode, String language, String codeType, String find1);
}

