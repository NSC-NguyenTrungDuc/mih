package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0803U00grdOCS0803ItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0803RepositoryCustom {
	public List<OCS0803U00grdOCS0803ItemInfo> getOCS0803U00grdOCS0803(String hospCode, String language);
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String language);
}

