package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0121;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0121Repository extends JpaRepository<Ocs0121, Long>, Ocs0121RepositoryCustom {
}

