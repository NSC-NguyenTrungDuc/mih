package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2024;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2024Repository extends JpaRepository<Ocs2024, Long>, Ocs2024RepositoryCustom {
}

