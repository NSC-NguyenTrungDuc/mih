package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs1802;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs1802Repository extends JpaRepository<Ocs1802, Long>, Ocs1802RepositoryCustom {
}

