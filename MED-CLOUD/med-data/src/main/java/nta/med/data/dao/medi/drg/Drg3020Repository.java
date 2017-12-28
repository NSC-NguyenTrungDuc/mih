package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg3020;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg3020Repository extends JpaRepository<Drg3020, Long>, Drg3020RepositoryCustom {
}

