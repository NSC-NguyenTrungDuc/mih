package nta.med.data.dao.medi.drg;

import java.util.List;

import nta.med.core.domain.drg.Drg9043;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg9043Repository extends JpaRepository<Drg9043, Long>, Drg9043RepositoryCustom {
	@Query("SELECT 'Y' FROM Drg9043 WHERE SYSDATE() "
			+ " BETWEEN CONCAT(DATE_FORMAT(startDate,'%Y/%m/%d'), startTime) AND CONCAT(DATE_FORMAT(endDate,'%Y/%m/%d'), endTime)"
			+ " AND cancelDate IS NULL AND hospCode = :hospCode ")
	public List<String> validateLock(@Param("hospCode") String hospCode);
}

