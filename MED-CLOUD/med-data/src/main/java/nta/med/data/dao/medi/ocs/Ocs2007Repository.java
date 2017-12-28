package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2007;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2007Repository extends JpaRepository<Ocs2007, Long>, Ocs2007RepositoryCustom {
}

