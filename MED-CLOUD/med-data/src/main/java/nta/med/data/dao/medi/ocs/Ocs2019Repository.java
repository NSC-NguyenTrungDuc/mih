package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2019;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2019Repository extends JpaRepository<Ocs2019, Long>, Ocs2019RepositoryCustom {
}

