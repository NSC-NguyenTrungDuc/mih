package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0501;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0501Repository extends JpaRepository<Ocs0501, Long>, Ocs0501RepositoryCustom {
}

