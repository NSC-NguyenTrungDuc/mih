package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2035;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2035Repository extends JpaRepository<Ocs2035, Long>, Ocs2035RepositoryCustom {
}

