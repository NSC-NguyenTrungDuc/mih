package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0140;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0140Repository extends JpaRepository<Ocs0140, Long>, Ocs0140RepositoryCustom {
}

