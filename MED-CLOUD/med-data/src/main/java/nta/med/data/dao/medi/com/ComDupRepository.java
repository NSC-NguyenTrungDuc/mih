package nta.med.data.dao.medi.com;

import nta.med.core.domain.com.ComDup;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface ComDupRepository extends JpaRepository<ComDup, Long>, ComDupRepositoryCustom {
}

