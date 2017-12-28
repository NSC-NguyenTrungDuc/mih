package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2021;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2021Repository extends JpaRepository<Ocs2021, Long>, Ocs2021RepositoryCustom {
}

