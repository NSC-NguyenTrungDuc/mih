package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0604;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0604Repository extends JpaRepository<Ocs0604, Long>, Ocs0604RepositoryCustom {
}

