package nta.med.data.dao.medi.oif;

import java.util.List;

import nta.med.data.model.ihis.orca.ORCALibGetClaimInsuredInfo;

/**
 * @author dainguyen.
 */
public interface Oif2101RepositoryCustom {
	public List<ORCALibGetClaimInsuredInfo> getORCALibGetClaimInsuredInfo(String hospCode, Double fkoif1101);
}

