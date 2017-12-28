package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2017;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2017Repository extends JpaRepository<Ocs2017, Long>, Ocs2017RepositoryCustom {
}

