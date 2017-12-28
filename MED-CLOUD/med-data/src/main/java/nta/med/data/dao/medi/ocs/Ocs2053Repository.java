package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2053;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2053Repository extends JpaRepository<Ocs2053, Long>, Ocs2053RepositoryCustom {
}

