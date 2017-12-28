package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0312;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0312Repository extends JpaRepository<Ocs0312, Long>, Ocs0312RepositoryCustom {
	@Modifying
	@Query(" UPDATE Ocs0312 SET updId = :q_user_id, updDate  = SYSDATE() , setCodeName = :f_set_code_name, comments = :f_comments "
			+ "WHERE hospCode = :f_hosp_code AND setPart = :f_set_part AND hangmogCode = :f_hangmog_code AND setCode  = :f_set_code ")
	public Integer updateOcs0312OCS0311U00Execute(@Param("f_hosp_code") String hospCode,@Param("q_user_id") String userId,@Param("f_set_code_name") String setCodeName,
			@Param("f_comments") String comments,@Param("f_set_part") String setPart,@Param("f_hangmog_code") String hangmogCode,@Param("f_set_code") String setCode);
	@Modifying
	@Query("DELETE Ocs0312 WHERE hospCode = :f_hosp_code  AND setPart = :f_set_part AND hangmogCode = :f_hangmog_code AND setCode   = :f_set_code")
	public Integer deleteOcs0312OCS0311U00Execute(@Param("f_hosp_code") String hospCode,@Param("f_set_part") String setPart,
			@Param("f_hangmog_code") String hangmogCode,@Param("f_set_code") String setCode);
	
	@Query(" SELECT 'Y' FROM Ocs0312 WHERE hospCode = :f_hosp_code AND setPart = :f_set_part AND hangmogCode = :f_hangmog_code AND setCode = :f_set_code ")
	public String getOCS0311U00layDupSetCode(@Param("f_hosp_code") String hospCode,@Param("f_set_part") String setPart,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_set_code") String setCode);
}

