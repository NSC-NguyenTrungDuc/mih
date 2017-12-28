package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0102;

import nta.med.data.dao.medi.CacheRepository;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */

public interface Ocs0102Repository extends Ocs0102RepositoryCustom, CacheRepository<Ocs0102> {

	public Integer updateOcs0101U00Ocs0102Modified(String updId, String slipName, String slipGubun, String slipCode, String hospCode, String language);

	public Integer deleteOcs0101U00Ocs0102Deleted(String slipGubun, String slipCode, String hospCode, String language);

}

