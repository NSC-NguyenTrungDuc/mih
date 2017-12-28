package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocso.OCS0801U00GrdOCS0802ListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0802RepositoryCustom {
	public List<ComboListItemInfo> getOCS0803U00GetFindWorker(String hospCode,String language,String patStatus);
	
	public String getOCS0801U00GetCodeNameOcs0802(String hospCode, String code, String patStatus, String language);
	
	public String getOCS0801TransactionDupCheck(String hospCode, String language, String patStatus, String patStatusCode);
	
	public List<OCS0801U00GrdOCS0802ListItemInfo> getOCS0801U00GrdOCS0802ListItem(String hospCode, String patStatus, String language);
}

