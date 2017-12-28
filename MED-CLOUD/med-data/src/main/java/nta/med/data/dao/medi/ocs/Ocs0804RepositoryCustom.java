package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0803U00grdOCS0804ItemInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0804RepositoryCustom {
	public List<OCS0803U00grdOCS0804ItemInfo> getOCS0803U00grdOCS0804(String hospCode,String language,String patStatusGr);
	
}

