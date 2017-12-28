package nta.med.data.dao.medi.res;

import java.util.Date;

import nta.med.core.domain.res.Res0104;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Res0104Repository extends JpaRepository<Res0104, Long>,
		Res0104RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Res0104 SET updId = :q_user_id, updDate = :f_upd_date, endDate = DATE_FORMAT(:f_end_date , '%Y/%m/%d') , sayu = :f_sayu "
			+ " WHERE hospCode = :f_hosp_code AND doctor = :f_doctor AND startDate = DATE_FORMAT(:f_start_date, '%Y/%m/%d') ")
	public Integer updateRES0104(@Param("q_user_id") String q_user_id,
			@Param("f_upd_date") Date f_upd_date,
			@Param("f_end_date") String f_end_date,
			@Param("f_sayu") String f_sayu,
			@Param("f_hosp_code") String f_hosp_code,
			@Param("f_doctor") String f_doctor,
			@Param("f_start_date") String f_start_date);
	

	@Modifying
	@Query("DELETE Res0104 WHERE hospCode = :f_hosp_code AND doctor = :f_doctor AND startDate = DATE_FORMAT(:f_start_date, '%Y/%m/%d') ")
	public Integer deleteRES0104(@Param("f_hosp_code") String f_hosp_code,
			@Param("f_doctor") String f_doctor,
			@Param("f_start_date") String f_start_date);
}
