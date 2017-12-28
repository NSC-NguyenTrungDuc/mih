package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0201;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0201Repository extends JpaRepository<Ocs0201, Long>, Ocs0201RepositoryCustom {
}

