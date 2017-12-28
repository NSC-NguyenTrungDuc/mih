package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0101;

import nta.med.data.dao.medi.CacheRepository;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */

public interface Ocs0101Repository extends Ocs0101RepositoryCustom, CacheRepository<Ocs0101> {

	public Integer updateOcs0101U00Ocs0101Modified(
			 String updId,
			 String slipGubunName,
			 String slipGubun,
			 String language);

	public Integer deleteOcs0101U00Ocs0101Deleted(String slipGubun, String language);

}

