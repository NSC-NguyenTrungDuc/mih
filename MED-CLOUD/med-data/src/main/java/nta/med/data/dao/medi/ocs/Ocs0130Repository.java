package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0101;
import nta.med.core.domain.ocs.Ocs0130;
import nta.med.data.dao.medi.CacheRepository;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0130Repository extends Ocs0130RepositoryCustom, CacheRepository<Ocs0130> {
}

