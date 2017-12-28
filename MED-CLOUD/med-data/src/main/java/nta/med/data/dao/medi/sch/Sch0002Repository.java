package nta.med.data.dao.medi.sch;

import java.util.Date;

import nta.med.core.domain.sch.Sch0002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Sch0002Repository extends JpaRepository<Sch0002, Long>, Sch0002RepositoryCustom {
	
//	@Query(" SELECT jundalTable  FROM Sch0002 WHERE hospCode = :f_hosp_code AND hangmogCode = :f_hangmog_code LIMIT 1 ")
//		public String getjundalTable(@Param("f_hosp_code") String hospCode,
//				@Param("f_hangmog_code") String hangmogCode);
	
	@Modifying
	@Query("UPDATE Sch0002 SET updId = :f_user_id, updDate = :f_sys_date "
			+ " , hangmogName = :f_hangmog_name, gumsaTime = :f_gumsa_time "
			+ " WHERE hospCode = :f_hosp_code AND jundalTable  = :f_jundal_table "
			+ " AND jundalPart = :f_jundal_part AND hangmogCode  = :f_hangmog_code")
	public Integer updateXSavePerformerCase3(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_hangmog_name") String hangmogName,
			@Param("f_gumsa_time") Double gumsaTime,
			@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_hangmog_code") String hangmogCode);
	
	@Modifying
	@Query("DELETE Sch0002 WHERE hospCode = :f_hosp_code AND jundalTable  = :f_jundal_table "
			+ " AND jundalPart = :f_jundal_part AND hangmogCode  = :f_hangmog_code")
	public Integer deleteXSavePerformerCase3(@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_table") String jundalTable,
			@Param("f_jundal_part") String jundalPart,
			@Param("f_hangmog_code") String hangmogCode);
}

