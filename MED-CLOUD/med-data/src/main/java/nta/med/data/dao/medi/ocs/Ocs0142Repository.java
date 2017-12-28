package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0142;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0142Repository extends JpaRepository<Ocs0142, Long>, Ocs0142RepositoryCustom {
}

