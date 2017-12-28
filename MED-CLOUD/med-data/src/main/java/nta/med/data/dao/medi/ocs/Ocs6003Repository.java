package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6003Repository extends JpaRepository<Ocs6003, Long>, Ocs6003RepositoryCustom {
}

