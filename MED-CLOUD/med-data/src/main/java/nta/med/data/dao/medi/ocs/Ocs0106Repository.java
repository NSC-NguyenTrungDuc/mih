package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0106;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0106Repository extends JpaRepository<Ocs0106, Long>, Ocs0106RepositoryCustom {
}

