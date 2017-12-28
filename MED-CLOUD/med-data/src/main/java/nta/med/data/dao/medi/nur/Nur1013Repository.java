package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1013;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1013Repository extends JpaRepository<Nur1013, Long>, Nur1013RepositoryCustom {
}

