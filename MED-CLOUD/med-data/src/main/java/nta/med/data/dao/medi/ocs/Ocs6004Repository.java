package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6004Repository extends JpaRepository<Ocs6004, Long>, Ocs6004RepositoryCustom {
}

