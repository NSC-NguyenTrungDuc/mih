package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg5001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg5001Repository extends JpaRepository<Drg5001, Long>, Drg5001RepositoryCustom {
}

