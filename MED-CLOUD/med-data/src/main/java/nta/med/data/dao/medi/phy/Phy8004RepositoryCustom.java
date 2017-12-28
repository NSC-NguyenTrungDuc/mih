package nta.med.data.dao.medi.phy;

import java.util.List;

import nta.med.data.model.ihis.phys.Phy8002U01GrdPhy8004LisItemInfo;

/**
 * @author dainguyen.
 */
public interface Phy8004RepositoryCustom {
	
	public List<Phy8002U01GrdPhy8004LisItemInfo> getPhy8002U01GrdPhy8004LisItem(String hospCode, Double fkOcs);
}

