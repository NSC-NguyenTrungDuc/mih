package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6012;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6012Repository extends JpaRepository<Ocs6012, Long>, Ocs6012RepositoryCustom {
}

