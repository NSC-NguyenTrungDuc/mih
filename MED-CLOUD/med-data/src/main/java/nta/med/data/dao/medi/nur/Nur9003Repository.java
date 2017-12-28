package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur9003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur9003Repository extends JpaRepository<Nur9003, Long>, Nur9003RepositoryCustom {
}

