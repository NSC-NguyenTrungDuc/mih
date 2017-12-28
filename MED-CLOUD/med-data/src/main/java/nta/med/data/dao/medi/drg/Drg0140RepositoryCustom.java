package nta.med.data.dao.medi.drg;

import java.util.List;

import nta.med.data.model.ihis.ocsa.OCS0103U12LayDrugTreeInfo;
import nta.med.data.model.ihis.system.*;

/**
 * @author dainguyen.
 */
public interface Drg0140RepositoryCustom {
	
	public List<OCS0103U12LayDrugTreeInfo> getOCS0103U12LayDrugTreeListItem(String hospCode, String language);
}

