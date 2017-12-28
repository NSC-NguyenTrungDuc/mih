package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2014;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2014Repository extends JpaRepository<Ocs2014, Long>, Ocs2014RepositoryCustom {
}

