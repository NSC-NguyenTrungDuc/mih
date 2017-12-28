package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg9992;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg9992Repository extends JpaRepository<Drg9992, Long>, Drg9992RepositoryCustom {
}

