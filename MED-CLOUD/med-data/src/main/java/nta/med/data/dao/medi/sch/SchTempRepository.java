package nta.med.data.dao.medi.sch;

import nta.med.core.domain.sch.SchTemp;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface SchTempRepository extends JpaRepository<SchTemp, Long>, SchTempRepositoryCustom {
}

