package nta.med.data.dao.medi.sch;

import java.util.Date;

import nta.med.core.domain.sch.Sch3100;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Sch3100Repository extends JpaRepository<Sch3100, Long>, Sch3100RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Sch3100 SET updId = :f_user_id, updDate = :f_sys_date, reserYn = :f_reser_yn "
			+ " WHERE hospCode = :f_hosp_code AND jundalTable = :f_jundal_table "
			+ " AND jundalPart = :f_jundal_part AND gumsaja = :f_gumsaja  AND reserDate = :f_reser_date")
	public Integer updateXSavePerformerCase4(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_reser_yn") String reserYn,
			@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_gumsaja") String gumsaja,
			@Param("f_reser_date") Date reserDate);
	
	@Modifying
	@Query("DELETE Sch3100 WHERE hospCode = :f_hosp_code AND jundalTable = :f_jundal_table "
			+ " AND jundalPart = :f_jundal_part AND gumsaja = :f_gumsaja  AND reserDate = :f_reser_date")
	public Integer deleteXSavePerformerCase4(@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_gumsaja") String gumsaja,
			@Param("f_reser_date") Date reserDate);
}

