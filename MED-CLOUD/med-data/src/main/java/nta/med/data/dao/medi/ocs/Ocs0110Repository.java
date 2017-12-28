package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0110;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0110Repository extends JpaRepository<Ocs0110, Long>, Ocs0110RepositoryCustom {
}

