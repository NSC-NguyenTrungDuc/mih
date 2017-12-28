package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs9000;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs9000Repository extends JpaRepository<Ocs9000, Long>, Ocs9000RepositoryCustom {
}

