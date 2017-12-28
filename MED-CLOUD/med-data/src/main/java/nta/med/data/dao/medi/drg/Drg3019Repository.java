package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg3019;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg3019Repository extends JpaRepository<Drg3019, Long>, Drg3019RepositoryCustom {
}

