package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0601;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0601Repository extends JpaRepository<Ocs0601, Long>, Ocs0601RepositoryCustom {
}
