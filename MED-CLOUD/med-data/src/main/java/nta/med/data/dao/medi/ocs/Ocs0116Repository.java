package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0116;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */

public interface Ocs0116Repository extends Ocs0116RepositoryCustom, CacheRepository<Ocs0116> {

	public Integer UpdateCpl0108U00Ocs0116(
			String updId,
			String specimenName,
			String hospCode,
			String specimenCode,
			String specimenGubun);
	
}

