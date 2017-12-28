package nta.med.data.dao.medi.oif;

import java.util.List;

import nta.med.data.model.ihis.orca.ORCALibAcquisitionInfo;
import nta.med.data.model.ihis.orca.ORCALibGetClaimPatientInfo;

/**
 * @author dainguyen.
 */
public interface Oif1101RepositoryCustom {
	public List<ORCALibGetClaimPatientInfo> getORCALibGetClaimPatientInfo(String hospCode, Double fkoif1101);
	public List<ORCALibAcquisitionInfo> getORCALibAcquisitionInfo(String hospCode, Double fkoif1101);
}

