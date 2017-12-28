package nta.med.data.dao.medi.xrt;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.xrts.XRT7001Q01LayRadioHistoryListItemInfo;

/**
 * @author dainguyen.
 */
public interface Xrt0202RepositoryCustom {
	public List<XRT7001Q01LayRadioHistoryListItemInfo> getXRT7001Q01LayRadioHistoryListItemInfo(String hospCode,String language,String bunho,String partCode);
	public List<XRT0201U00GrdRadioListItemInfo> getXRT0201U00GrdRadioListItemInfo(String hospCode,Date orderDate,String bunho,String inOutGubun);
	public void callPRXrtManagementXrt0202(String hospCode,String dataGubun,Double fkOcs,String userId,String inOutGubun);
}

