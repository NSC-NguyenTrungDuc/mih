package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0109;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0109Repository extends JpaRepository<Ocs0109, Long>, Ocs0109RepositoryCustom {
}

