package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2020;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2020Repository extends JpaRepository<Ocs2020, Long>, Ocs2020RepositoryCustom {
}

