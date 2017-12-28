package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0133U00grdOCS0133ItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U00setInputControlInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0133RepositoryCustom {
	public List<OCS0133U00grdOCS0133ItemInfo> getOCS0133U00grdOCS0133ItemInfo(String hospCode,String inputControl,String userInfo, String language); 
	public List<ComboListItemInfo> getOCS0101U00InputControlComboListItem(String hospCode, String language);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String language);
	public List<OCS2005U00setInputControlInfo> getOCS2005U00setInputControlInfo(String hospCode, String inputControl);
}

