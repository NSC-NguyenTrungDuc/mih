package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0128;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0128Repository extends JpaRepository<Ocs0128, Long>, Ocs0128RepositoryCustom {
}

