package nta.med.data.dao.medi.phy;

import java.util.List;

import nta.med.data.model.ihis.phys.Phy8002U01GrdPhy8002LisItemInfo;

/**
 * @author dainguyen.
 */
public interface Phy8002RepositoryCustom {
	
	public Double getOCS0103U11GetFkOcs(String hospCode, Double pkocskey); 
	
	public List<Phy8002U01GrdPhy8002LisItemInfo> getPhy8002U01GrdPhy8002LisItem(String hospCode, Double fkOcs);
}

