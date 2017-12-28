package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2044;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2044Repository extends JpaRepository<Ocs2044, Long>, Ocs2044RepositoryCustom {
}

