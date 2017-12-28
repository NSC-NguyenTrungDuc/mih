package nta.med.data.dao.medi.oif;

import java.util.List;

import nta.med.data.model.ihis.orca.ORCALibGetClaimOrderInfo;

/**
 * @author dainguyen.
 */
public interface Oif4001RepositoryCustom {
	public List<ORCALibGetClaimOrderInfo> getORCALibGetClaimOrderInfo(String hospCode, Double fkoif1101);
}

