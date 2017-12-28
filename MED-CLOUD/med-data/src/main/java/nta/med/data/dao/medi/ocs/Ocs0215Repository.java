package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0215;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0215Repository extends JpaRepository<Ocs0215, Long>, Ocs0215RepositoryCustom {
}

