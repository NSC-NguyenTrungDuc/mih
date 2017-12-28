package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2018;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2018Repository extends JpaRepository<Ocs2018, Long>, Ocs2018RepositoryCustom {
}

