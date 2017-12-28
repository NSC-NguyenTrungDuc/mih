package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2023;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2023Repository extends JpaRepository<Ocs2023, Long>, Ocs2023RepositoryCustom {
}

