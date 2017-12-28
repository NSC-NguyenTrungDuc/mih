package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0605;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0605Repository extends JpaRepository<Ocs0605, Long>, Ocs0605RepositoryCustom {
}

