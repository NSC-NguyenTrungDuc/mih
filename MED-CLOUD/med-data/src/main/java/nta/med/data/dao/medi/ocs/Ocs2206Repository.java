package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2206;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2206Repository extends JpaRepository<Ocs2206, Long>, Ocs2206RepositoryCustom {
}

