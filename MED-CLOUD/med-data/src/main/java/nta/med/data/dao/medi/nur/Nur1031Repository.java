package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1031;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1031Repository extends JpaRepository<Nur1031, Long>, Nur1031RepositoryCustom {
}

