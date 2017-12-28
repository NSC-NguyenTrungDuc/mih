package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1010;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1010Repository extends JpaRepository<Nur1010, Long>, Nur1010RepositoryCustom {
	@Modifying
	@Query("UPDATE Nur1010 SET updId = :f_user_id, updDate = SYSDATE(), damdangNurse = :f_damdang_nurse WHERE hospCode = :f_hosp_code " 
			+ "AND bunho = :f_bunho AND fkinp1001 = :f_fkinp1001 AND jukyongDate = STR_TO_DATE(:f_jukyong_date,'%Y/%m/%d')")
	public Integer nur1010U00SaveLayoutUpdate(
			@Param("f_hosp_code") String hospCode,
			@Param("f_user_id") String userId,
			@Param("f_damdang_nurse") String damdangNurse,
			@Param("f_fkinp1001") Double fkinp1001,
			@Param("f_bunho") String bunho,
			@Param("f_jukyong_date") String jukyongDate);
	
	@Modifying
	@Query("DELETE Nur1010  WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fkinp1001 = :f_fkinp1001 AND jukyongDate = STR_TO_DATE(:f_jukyong_date,'%Y/%m/%d')")
	public Integer nur1010U00SaveLayoutDelete(
			@Param("f_hosp_code") String hospCode,
			@Param("f_fkinp1001") Double fkinp1001,
			@Param("f_bunho") String bunho,
			@Param("f_jukyong_date") String jukyongDate);
}

