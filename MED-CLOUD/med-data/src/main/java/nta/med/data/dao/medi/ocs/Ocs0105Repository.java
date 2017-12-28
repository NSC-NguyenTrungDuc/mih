package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0105;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0105Repository extends JpaRepository<Ocs0105, Long>, Ocs0105RepositoryCustom {
}

