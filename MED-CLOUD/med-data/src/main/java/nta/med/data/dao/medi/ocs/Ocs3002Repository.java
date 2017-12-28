package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs3002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs3002Repository extends JpaRepository<Ocs3002, Long>, Ocs3002RepositoryCustom {
}

