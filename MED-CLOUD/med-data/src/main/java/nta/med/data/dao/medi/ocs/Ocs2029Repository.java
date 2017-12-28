package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2029;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2029Repository extends JpaRepository<Ocs2029, Long>, Ocs2029RepositoryCustom {
}

