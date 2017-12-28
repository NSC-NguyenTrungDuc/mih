package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0504;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0504Repository extends JpaRepository<Ocs0504, Long>, Ocs0504RepositoryCustom {
}

