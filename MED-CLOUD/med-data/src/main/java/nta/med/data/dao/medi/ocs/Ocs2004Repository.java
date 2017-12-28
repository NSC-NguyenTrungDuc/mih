package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2004Repository extends JpaRepository<Ocs2004, Long>, Ocs2004RepositoryCustom {
}

