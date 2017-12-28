package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2011Repository extends JpaRepository<Ocs2011, Long>, Ocs2011RepositoryCustom {
}

