package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg5030;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg5030Repository extends JpaRepository<Drg5030, Long>, Drg5030RepositoryCustom {
}

