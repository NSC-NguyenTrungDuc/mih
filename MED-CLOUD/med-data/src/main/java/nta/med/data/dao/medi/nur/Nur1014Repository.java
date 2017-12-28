package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1014;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1014Repository extends JpaRepository<Nur1014, Long>, Nur1014RepositoryCustom {
	@Modifying
	@Query("UPDATE Nur1014 SET updDate = SYSDATE(), updId = :f_user_id, inHopeDate = STR_TO_DATE(:f_in_hope_date, '%Y/%m/%d'), inHopeTime = :f_in_hope_time, "
			+ " trueDate = STR_TO_DATE(:f_true_date, '%Y/%m/%d'), trueTime = :f_true_time, nutStartDate = STR_TO_DATE(:f_nut_start_date, '%Y/%m/%d'), nutStartKini = :f_nut_start_kini, "
			+ " nutEndDate = STR_TO_DATE(:f_nut_end_date, '%Y/%m/%d'), nutEndKini = :f_nut_end_kini, outObject = :f_out_object, woichulWoibakGubun = :f_flag, "
			+ " nutEndYn = :f_nut_end_yn, destIshome = :f_dest_ishome, destAddr = :f_dest_addr, destTel = :f_dest_tel"
			+ " WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fkinp1001 = :f_fkinp1001 AND outDate = STR_TO_DATE(:f_out_date, '%Y/%m/%d') AND outTime = :f_out_time")
	public Integer updateNur1014U00grdNur1014(
			@Param("f_hosp_code") String hospCode,
			@Param("f_user_id") String userId,
			@Param("f_in_hope_date") String inHopeDate,
			@Param("f_in_hope_time") String inHopeTime,
			@Param("f_true_date") String trueDate,
			@Param("f_true_time") String trueTime,
			@Param("f_nut_start_date") String nutStartDate,
			@Param("f_nut_start_kini") String nutStartKini,
			@Param("f_nut_end_date") String nutEndDate,
			@Param("f_nut_end_kini") String nutEndKini,
			@Param("f_out_object") String outObject,
			@Param("f_flag") String flag,
			@Param("f_nut_end_yn") String nutEndYn,
			@Param("f_dest_ishome") String destIshome,
			@Param("f_dest_addr") String destAddr,
			@Param("f_dest_tel") String destTel,
			@Param("f_bunho") String bunho,
			@Param("f_fkinp1001") Double fkinp1001,
			@Param("f_out_date") String outDate,
			@Param("f_out_time") String outTime);
	
	
	@Modifying
	@Query("DELETE Nur1014 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fkinp1001 = :f_fkinp1001 AND outDate = STR_TO_DATE(:f_out_date, '%Y/%m/%d') AND outTime = :f_out_time")
	public Integer deleteNur1014U00grdNur1014(
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_fkinp1001") Double fkinp1001,
			@Param("f_out_date") String outDate,
			@Param("f_out_time") String outTime);
}

