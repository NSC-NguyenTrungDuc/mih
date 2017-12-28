package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg2035;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg2035Repository extends JpaRepository<Drg2035, Long>, Drg2035RepositoryCustom {
}

