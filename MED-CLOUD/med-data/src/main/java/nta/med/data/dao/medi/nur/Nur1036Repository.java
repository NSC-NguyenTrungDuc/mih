package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur1036;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1036Repository extends JpaRepository<Nur1036, Long>, Nur1036RepositoryCustom {
	@Modifying
	@Query("UPDATE Nur1036 SET updDate = SYSDATE(), updId = :f_user_id, inputId = :f_input_id, dangerAct = :f_danger_act, changedSkin = :f_changed_skin, "
			+ " edema = :f_edema, numbness = :f_numbness, scratch = :f_scratch, tubeTrouble = :f_tube_trouble, petechia = :f_petechia, "
			+ " remark = :f_remark WHERE hospCode = :f_hosp_code AND fknur1035 = :f_fknur1035 AND checkDate = STR_TO_DATE(:f_check_date, '%Y/%m/%d') AND checkTime = :f_check_time ")
	public Integer updateNUR1035U00grdNur1036(
			@Param("f_hosp_code") String hospCode,
			@Param("f_user_id") String userId,
			@Param("f_input_id") String inputId,
			@Param("f_danger_act") String dangerAct,
			@Param("f_changed_skin") String changedSkin,
			@Param("f_edema") String edema,
			@Param("f_numbness") String numbness,
			@Param("f_scratch") String scratch,
			@Param("f_tube_trouble") String tubeTrouble,
			@Param("f_petechia") String petechia,
			@Param("f_remark") String remark,
			@Param("f_fknur1035") Double fknur1035,
			@Param("f_check_date") String checkDate,
			@Param("f_check_time") String checkTime);
	
	@Modifying
	@Query("DELETE Nur1036  WHERE hospCode = :f_hosp_code AND fknur1035 = :f_fknur1035 AND checkDate = STR_TO_DATE(:f_check_date, '%Y/%m/%d') AND checkTime = :f_check_time ")
	public Integer deleteNUR1035U00grdNur1036(
			@Param("f_hosp_code") String hospCode,
			@Param("f_fknur1035") Double fknur1035,
			@Param("f_check_date") String checkDate,
			@Param("f_check_time") String checkTime);
	
}

