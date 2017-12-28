package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0402;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0402Repository extends JpaRepository<Ocs0402, Long>, Ocs0402RepositoryCustom {
}

