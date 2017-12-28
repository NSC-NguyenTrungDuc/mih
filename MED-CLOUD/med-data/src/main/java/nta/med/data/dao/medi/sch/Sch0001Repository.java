package nta.med.data.dao.medi.sch;

import java.util.Date;

import nta.med.core.domain.sch.Sch0001;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Sch0001Repository extends JpaRepository<Sch0001, Long>, Sch0001RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Sch0001 SET updId = :f_user_id, updDate = :f_sys_date "
			+ " ,jundalPartName = :f_jundal_part_name, gwaGubun = :f_gwa_gubun "
			+ " ,gumsaTime = :f_gumsa_time WHERE hospCode = :f_hosp_code "
			+ " AND jundalTable = :f_jundal_table AND jundalPart = :f_jundal_part "
			+ " AND gumsaja = IFNULL(:f_gumsaja,'%')")
	public Integer updateSCH0001XSavePerformerCase1(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_jundal_part_name") String jundalPartName,
			@Param("f_gwa_gubun") String gwaGubun,
			@Param("f_gumsa_time") Double gumsaTime,
			@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_gumsaja") String gumsaja);
	
	@Modifying
	@Query("DELETE Sch0001 WHERE hospCode = :f_hosp_code "
			+ " AND jundalTable = :f_jundal_table AND jundalPart = :f_jundal_part "
			+ " AND gumsaja = IFNULL(:f_gumsaja,'%')")
	public Integer deleteSCH0001XSavePerformerCase1(@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_gumsaja") String gumsaja);
}

