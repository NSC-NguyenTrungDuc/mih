package nta.med.data.dao.medi.oif;

import java.util.List;

import nta.med.data.model.ihis.orca.ORCALibGetClaimDiagnosisInfo;

/**
 * @author dainguyen.
 */
public interface Oif5101RepositoryCustom {
	public List<ORCALibGetClaimDiagnosisInfo> getORCALibGetClaimDiagnosisInfo(String hospCode, Double fkoif1101);
}

