package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocsa.Ocs0204Q00GrdOcs0205ListItemInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00GrdOCS0205ListInfo;

/**
 * @author dainguyen.
 */
public interface Ocs0205RepositoryCustom {
	public List<OcsaOCS0204U00GrdOCS0205ListInfo> getOcsaOCS0204U00GrdOCS0205List(String hospCode, String fMemb, String sangGubun);
	
	public String getOcs0205Seq(String seqName);
	
	public List<Ocs0204Q00GrdOcs0205ListItemInfo> getOcs0204Q00GrdOcs0205ListItemInfo(String hospCode, String fMemb, String sangGubun, String sangNameInx);
}

