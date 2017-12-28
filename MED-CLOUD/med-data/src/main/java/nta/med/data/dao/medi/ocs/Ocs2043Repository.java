package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2043;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2043Repository extends JpaRepository<Ocs2043, Long>, Ocs2043RepositoryCustom {
}

