package nta.med.data.dao.medi.phy;

import java.util.List;

import nta.med.data.model.ihis.phys.Phy8002U01GrdPhy8003LisItemInfo;

/**
 * @author dainguyen.
 */
public interface Phy8003RepositoryCustom {
	
	public List<Phy8002U01GrdPhy8003LisItemInfo> getPhy8002U01GrdPhy8003LisItem(String hospCode, String kanjaNo, Double fkocs);
	
}

