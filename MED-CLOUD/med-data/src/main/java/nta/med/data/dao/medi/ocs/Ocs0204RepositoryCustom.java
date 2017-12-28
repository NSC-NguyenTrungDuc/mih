package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.Ocs0204Q00GrdOcs0204ListItemInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00GrdOCS0204ListInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0204RepositoryCustom {
	
	public List<OcsaOCS0204U00GrdOCS0204ListInfo> getOcsaOCS0204U00GrdOCS0204List(String hospCode, String fMemb, String language);
	
	public String getLoadColumnCodeNameSangGubunCase(String memb, String sangGubun, String hospCode, String language);
	
	public List<Ocs0204Q00GrdOcs0204ListItemInfo> getOcs0204Q00GrdOcs0204ListItemInfo(String hospCode, String fMemb, String language);
}

