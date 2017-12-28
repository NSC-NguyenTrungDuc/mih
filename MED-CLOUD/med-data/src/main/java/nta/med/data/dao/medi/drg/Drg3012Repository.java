package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg3012;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg3012Repository extends JpaRepository<Drg3012, Long>, Drg3012RepositoryCustom {
}

