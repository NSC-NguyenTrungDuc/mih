package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0221;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0221Repository extends JpaRepository<Ocs0221, Long>, Ocs0221RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Ocs0221 SET updId = :f_user_id, updDate = :f_sys_date, categoryName = :f_category_name "
			+ "WHERE memb = :f_memb AND membGubun = '1' AND seq = :f_seq AND hospCode = :f_hosp_code")
	public Integer updateOcsaOCS0221U00UpdateOCS0221(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_category_name") String categoryName,
			@Param("f_memb") String memb,
			@Param("f_seq") Double seq,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query("DELETE Ocs0221 WHERE memb = :f_memb AND membGubun = '1' AND seq = :f_seq AND hospCode = :f_hosp_code")
	public Integer deleteOcsaOCS0221U00DeleteOCS0221(@Param("f_memb") String memb,
			@Param("f_seq") Double seq,
			@Param("f_hosp_code") String hospCode);
}

