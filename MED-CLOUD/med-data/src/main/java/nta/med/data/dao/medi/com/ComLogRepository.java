package nta.med.data.dao.medi.com;

import nta.med.core.domain.com.ComLog;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface ComLogRepository extends JpaRepository<ComLog, Long>, ComLogRepositoryCustom {
}

