package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1025;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1025Repository extends JpaRepository<Nur1025, Long>, Nur1025RepositoryCustom {
}

