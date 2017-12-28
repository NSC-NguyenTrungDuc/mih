package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6001Repository extends JpaRepository<Ocs6001, Long>, Ocs6001RepositoryCustom {
}

