package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0402;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0402Repository extends JpaRepository<Nur0402, Long>, Nur0402RepositoryCustom {
	
	@Modifying
	@Query("DELETE Nur0402 WHERE hospCode = :hospCode AND nurPlanJin = :nurPlanJin")
	public Integer deleteByHospCodeNurPlanJin(@Param("hospCode") String hospCode,
			 								  @Param("nurPlanJin") String nurPlanJin);
	
}

