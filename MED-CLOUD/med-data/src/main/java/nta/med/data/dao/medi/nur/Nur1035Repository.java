package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1035;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1035Repository extends JpaRepository<Nur1035, Long>, Nur1035RepositoryCustom {
	@Modifying
	@Query("UPDATE Nur1035 SET updDate = SYSDATE(), updId = :f_user_id, methodCode = :f_method_code, startDate = STR_TO_DATE(:f_start_date, '%Y/%m/%d'), "
			+ " endDate = STR_TO_DATE(:f_end_date, '%Y/%m/%d') WHERE hospCode = :f_hosp_code AND pknur1035 = :f_pknur1035")
	public Integer updateNUR1035U00grdNur1035(
			@Param("f_hosp_code") String hospCode,
			@Param("f_user_id") String userId,
			@Param("f_method_code") String methodCode,
			@Param("f_start_date") String startDate,
			@Param("f_end_date") String endDate,
			@Param("f_pknur1035") Double pknur1035);
	
	@Modifying
	@Query("DELETE Nur1035 WHERE hospCode = :f_hosp_code AND pknur1035 = :f_pknur1035")
	public Integer deleteNUR1035U00grdNur1035(
			@Param("f_hosp_code") String hospCode,
			@Param("f_pknur1035") Double pknur1035);
}

