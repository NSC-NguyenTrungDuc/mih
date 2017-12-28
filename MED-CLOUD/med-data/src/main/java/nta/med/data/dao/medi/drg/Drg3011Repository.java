package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg3011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg3011Repository extends JpaRepository<Drg3011, Long>, Drg3011RepositoryCustom {
}

