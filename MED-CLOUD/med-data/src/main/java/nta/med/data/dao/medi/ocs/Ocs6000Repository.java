package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6000;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6000Repository extends JpaRepository<Ocs6000, Long>, Ocs6000RepositoryCustom {
}

