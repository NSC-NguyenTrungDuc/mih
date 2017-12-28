package nta.med.data.dao.medi.sch;

import java.util.Date;

import nta.med.core.domain.sch.Sch3101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Sch3101Repository extends JpaRepository<Sch3101, Long>, Sch3101RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Sch3101 SET updId = :f_user_id, updDate = :f_sys_date "
			+ " , endTime = :f_end_time, inwon = :f_inwon, addInwon = :f_add_inwon "
			+ " WHERE hospCode = :f_hosp_code AND jundalTable = :f_jundal_table "
			+ " AND jundalPart = :f_jundal_part AND gumsaja = :f_gumsaja "
			+ " AND reserDate = :f_reser_date AND startTime = :f_start_time")
	public Integer updateXSavePerformerCase5(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_end_time") String endTime,
			@Param("f_inwon") Double inwon,
			@Param("f_add_inwon") Double addInwon,
			@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_gumsaja") String gumsaja,
			@Param("f_reser_date") Date reserDate,
			@Param("f_start_time") String startTime
			);
	
	@Modifying
	@Query("DELETE Sch3101 WHERE hospCode = :f_hosp_code AND jundalTable = :f_jundal_table "
			+ " AND jundalPart = :f_jundal_part AND gumsaja = :f_gumsaja "
			+ " AND reserDate = :f_reser_date AND startTime = :f_start_time")
	public Integer deleteXSavePerformerCase5(@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_gumsaja") String gumsaja,
			@Param("f_reser_date") Date reserDate,
			@Param("f_start_time") String startTime);
}

