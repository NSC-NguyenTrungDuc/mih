package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0203;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0203Repository extends JpaRepository<Ocs0203, Long>, Ocs0203RepositoryCustom {
}

