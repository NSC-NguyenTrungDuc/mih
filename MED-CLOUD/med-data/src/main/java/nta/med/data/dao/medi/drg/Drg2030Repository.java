package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg2030;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg2030Repository extends JpaRepository<Drg2030, Long>, Drg2030RepositoryCustom {
}

