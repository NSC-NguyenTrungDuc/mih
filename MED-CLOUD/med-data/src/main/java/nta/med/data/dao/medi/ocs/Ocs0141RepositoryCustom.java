package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.nuro.OcsLoadVisibleControlListItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0141RepositoryCustom {
	
	public List<OcsLoadVisibleControlListItemInfo> getOcslibVisibleListItem(String inputTab);
}

