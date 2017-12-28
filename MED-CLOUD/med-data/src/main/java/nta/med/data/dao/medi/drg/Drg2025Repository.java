package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg2025;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg2025Repository extends JpaRepository<Drg2025, Long>, Drg2025RepositoryCustom {
}

