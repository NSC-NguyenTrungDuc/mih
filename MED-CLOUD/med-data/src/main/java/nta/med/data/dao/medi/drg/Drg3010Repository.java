package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg3010;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg3010Repository extends JpaRepository<Drg3010, Long>, Drg3010RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Drg3010 SET reUseYn = :reUseYn WHERE hospCode = :hospCode AND fkocs2003 = :fkocs2003")
	public Integer updateReUseYnByHospCodeFkOcs2003(@Param("hospCode") String hospCode
			, @Param("fkocs2003") Double fkocs2003
			, @Param("reUseYn") String reUseYn);
	
}

