package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg9001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg9001Repository extends JpaRepository<Drg9001, Long>, Drg9001RepositoryCustom {
}

