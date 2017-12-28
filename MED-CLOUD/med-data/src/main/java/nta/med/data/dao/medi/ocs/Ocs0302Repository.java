package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0302;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0302Repository extends JpaRepository<Ocs0302, Long>, Ocs0302RepositoryCustom {
}

