package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6002Repository extends JpaRepository<Ocs6002, Long>, Ocs6002RepositoryCustom {
}
