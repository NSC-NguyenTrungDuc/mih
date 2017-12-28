package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg1000;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg1000Repository extends JpaRepository<Drg1000, Long>, Drg1000RepositoryCustom {
}

