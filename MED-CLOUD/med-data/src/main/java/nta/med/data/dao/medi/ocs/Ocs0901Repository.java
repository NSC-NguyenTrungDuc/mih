package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0901;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0901Repository extends JpaRepository<Ocs0901, Long>, Ocs0901RepositoryCustom {
}

