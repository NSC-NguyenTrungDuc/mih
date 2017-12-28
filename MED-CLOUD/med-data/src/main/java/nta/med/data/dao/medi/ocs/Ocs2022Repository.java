package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2022;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2022Repository extends JpaRepository<Ocs2022, Long>, Ocs2022RepositoryCustom {
}

