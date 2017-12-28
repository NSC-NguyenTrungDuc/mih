package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6006;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6006Repository extends JpaRepository<Ocs6006, Long>, Ocs6006RepositoryCustom {
}

