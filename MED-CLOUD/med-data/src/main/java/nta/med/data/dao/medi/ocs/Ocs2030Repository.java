package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2030;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2030Repository extends JpaRepository<Ocs2030, Long>, Ocs2030RepositoryCustom {
}

