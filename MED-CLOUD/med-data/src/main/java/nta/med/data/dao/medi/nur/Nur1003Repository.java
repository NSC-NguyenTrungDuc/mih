package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1003Repository extends JpaRepository<Nur1003, Long>, Nur1003RepositoryCustom {
}

