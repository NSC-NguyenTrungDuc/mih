package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0222;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0222Repository extends JpaRepository<Ocs0222, Long>, Ocs0222RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Ocs0222 SET updId = :f_user_id, updDate = :f_sys_date, commentTitle = :f_comment_title, commentText = :f_comment_text "
			+ "WHERE memb = :f_memb AND membGubun = '1' AND seq = :f_seq AND serial = :f_serial AND hospCode = :f_hosp_code")
	public Integer updateOcsaOCS0221U00UpdateOCS0222(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_comment_title") String commentTitle,
			@Param("f_comment_text") String commentText,
			@Param("f_memb") String memb,
			@Param("f_seq") Double seq,
			@Param("f_serial") Double serial,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query("DELETE Ocs0222 WHERE memb = :f_memb AND membGubun = '1' AND seq = :f_seq AND serial = :f_serial AND hospCode = :f_hosp_code")
	public Integer deleteOcsaOCS0221U00DeleteOCS0222(@Param("f_memb") String memb,
			@Param("f_seq") Double seq,
			@Param("f_serial") Double serial,
			@Param("f_hosp_code") String hospCode);
	
	@Query("SELECT IFNULL(MAX(serial), 0) + 1 FROM Ocs0222 WHERE memb = :f_memb "
			+ "AND membGubun = '1' AND seq = :f_seq AND hospCode  = :f_hosp_code")
	public Double getMaxSerialOcsaOCS0221U00InsertIntoOCS0222(@Param("f_memb") String memb,
			@Param("f_seq") Double seq,
			@Param("f_hosp_code") String hospCode);
}

