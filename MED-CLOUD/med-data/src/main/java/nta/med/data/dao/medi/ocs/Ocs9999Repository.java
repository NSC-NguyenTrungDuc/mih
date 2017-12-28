package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs9999;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs9999Repository extends JpaRepository<Ocs9999, Long>, Ocs9999RepositoryCustom {
}

