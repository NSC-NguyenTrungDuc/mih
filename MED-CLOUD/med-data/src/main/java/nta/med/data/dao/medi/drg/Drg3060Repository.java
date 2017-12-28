package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg3060;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg3060Repository extends JpaRepository<Drg3060, Long>, Drg3060RepositoryCustom {
}

