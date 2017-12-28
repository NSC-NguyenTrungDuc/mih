package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg0122;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg0122Repository extends JpaRepository<Drg0122, Long>, Drg0122RepositoryCustom {
}

