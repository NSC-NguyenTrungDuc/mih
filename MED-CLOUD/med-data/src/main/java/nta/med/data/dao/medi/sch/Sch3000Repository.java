package nta.med.data.dao.medi.sch;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.sch.Sch3000;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Sch3000Repository extends JpaRepository<Sch3000, Long>, Sch3000RepositoryCustom {
	
	@Modifying
	@Query("DELETE Sch3000 WHERE hospCode = :f_hosp_code AND jukyongDate = :f_jukyong_date "
			+ " AND jundalTable = :f_jundal_table AND jundalPart = :f_jundal_part "
			+ " AND yoilGubun IN :f_yoil_gubun AND gumsaja = IFNULL(:f_gumsaja,'%')")
	public Integer deleteSelectedYoil(@Param("f_hosp_code") String hospCode,
			@Param("f_jukyong_date") Date jukyongDate,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_yoil_gubun") List<String> yoilGubun,
			@Param("f_gumsaja") String gumsaja);
	
	@Modifying
	@Query("UPDATE Sch3000 SET updId = :f_user_id, updDate = :f_sys_date, endTime = :f_end_time "
			+ " ,inwon = :f_inwon, addInwon = :f_add_inwon, outHospCodeSlot =:f_out_hosp_code_slot  WHERE hospCode = :f_hosp_code "
			+ " AND jukyongDate = :f_jukyong_date AND jundalTable = :f_jundal_table AND jundalPart = :f_jundal_part "
			+ " AND gumsaja = IFNULL(:f_gumsaja,'%') AND yoilGubun IN :f_yoil_gubun AND startTime = :f_start_time") 
	public Integer updateXSavePerformerCase2(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_end_time") String endTime,
			@Param("f_inwon") Double inwon,
			@Param("f_add_inwon") Double addInwon,
			@Param("f_hosp_code") String hospCode,
			@Param("f_jukyong_date") Date jukyongDate,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_yoil_gubun") List<String> yoilGubun,
			@Param("f_gumsaja") String gumsaja,
			@Param("f_start_time") String startTime,
			@Param("f_out_hosp_code_slot") Double outHospCodeSlot);
			
	
	@Modifying
	@Query("UPDATE Sch3000 SET updId = :f_user_id, updDate = :f_sys_date, endTime = :f_end_time "
			+ " ,inwon = :f_inwon, addInwon = :f_add_inwon  WHERE hospCode = :f_hosp_code "
			+ " AND jukyongDate = :f_jukyong_date AND jundalTable = :f_jundal_table AND jundalPart = :f_jundal_part "
			+ " AND gumsaja = IFNULL(:f_gumsaja,'%') AND yoilGubun IN :f_yoil_gubun AND startTime = :f_start_time") 
	public Integer updateXSavePerformerCase2_1(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_end_time") String endTime,
			@Param("f_inwon") Double inwon,
			@Param("f_add_inwon") Double addInwon,
			@Param("f_hosp_code") String hospCode,
			@Param("f_jukyong_date") Date jukyongDate,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_yoil_gubun") List<String> yoilGubun,
			@Param("f_gumsaja") String gumsaja,
			@Param("f_start_time") String startTime);
	@Modifying
	@Query("DELETE Sch3000 WHERE hospCode = :f_hosp_code AND jukyongDate = :f_jukyong_date "
			+ " AND jundalTable = :f_jundal_table AND jundalPart = :f_jundal_part "
			+ " AND gumsaja = IFNULL(:f_gumsaja,'%') AND yoilGubun IN :f_yoil_gubun AND startTime = :f_start_time AND outHospCodeSlot=:f_out_hosp_code_slot" )
	public Integer deleteXSavePerformerCase2(@Param("f_hosp_code") String hospCode,
			@Param("f_jukyong_date") Date jukyongDate,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_yoil_gubun") List<String> yoilGubun,
			@Param("f_gumsaja") String gumsaja,
			@Param("f_start_time") String startTime,
			@Param("f_out_hosp_code_slot") Double outHospCodeSlot);
	
	
	@Modifying
	@Query("DELETE Sch3000 WHERE hospCode = :f_hosp_code AND jukyongDate = :f_jukyong_date "
			+ " AND jundalTable = :f_jundal_table AND jundalPart = :f_jundal_part "
			+ " AND gumsaja = IFNULL(:f_gumsaja,'%') AND yoilGubun IN :f_yoil_gubun AND startTime = :f_start_time" )
	public Integer deleteXSavePerformerCase2_1(@Param("f_hosp_code") String hospCode,
			@Param("f_jukyong_date") Date jukyongDate,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_yoil_gubun") List<String> yoilGubun,
			@Param("f_gumsaja") String gumsaja,
			@Param("f_start_time") String startTime);	
	
	
	
	@Modifying
	@Query("UPDATE Sch3000 SET updId = :f_user_id, updDate = :f_sys_date, jukyongDate = :f_jukyong_date "
			+ " WHERE hospCode = :f_hosp_code AND jukyongDate = :f_old_jukyong_date "
			+ " AND jundalTable = :f_jundal_table AND jundalPart = :f_jundal_part AND gumsaja = IFNULL(:f_gumsaja,'%')")
	public Integer updateXSavePerformerCase6(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_jukyong_date") Date jukyongDate,
			@Param("f_hosp_code") String hospCode,
			@Param("f_old_jukyong_date") Date oldJukyongDate,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_gumsaja") String gumsaja
			);
	
	@Modifying
	@Query("DELETE Sch3000 WHERE hospCode = :f_hosp_code AND jukyongDate = :f_old_jukyong_date "
			+ " AND jundalTable = :f_jundal_table AND jundalPart = :f_jundal_part AND gumsaja = IFNULL(:f_gumsaja,'%')")
	public Integer deleteXSavePerformerCase6(@Param("f_hosp_code") String hospCode,
			@Param("f_old_jukyong_date") Date oldJukyongDate,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_gumsaja") String gumsaja);
}

