package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0313;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0313Repository extends JpaRepository<Ocs0313, Long>, Ocs0313RepositoryCustom {
	@Modifying
	@Query("UPDATE Ocs0313 SET updId  = :q_user_id , updDate  = SYSDATE() , suryang = :f_suryang , danui  = :f_danui "
			+ "WHERE hospCode = :f_hosp_code  AND setPart  = :f_set_part AND hangmogCode  = :f_hangmog_code "
			+ "AND setCode  = :f_set_code  AND setHangmogCode  = :f_set_hangmog_code ")
	public Integer updateOcs0313OCS0311U00Execute(@Param("f_hosp_code") String hospCode,@Param("q_user_id") String userId,
			@Param("f_suryang") Double suryang,@Param("f_danui") String danui,@Param("f_set_part") String setPart,
			@Param("f_hangmog_code") String hangmogCode,@Param("f_set_code") String setCode,@Param("f_set_hangmog_code") String setHangmogCode);
	
	@Modifying
	@Query("DELETE Ocs0313 WHERE hospCode  = :f_hosp_code AND setPart   = :f_set_part "
			+ "AND hangmogCode = :f_hangmog_code AND setCode  = :f_set_code AND setHangmogCode = :f_set_hangmog_code")
	public Integer deleteOcs0313OCS0311U00Execute(@Param("f_hosp_code") String hospCode,@Param("f_set_part") String setPart,
			@Param("f_hangmog_code") String hangmogCode,@Param("f_set_code") String setCode,@Param("f_set_hangmog_code") String setHangmogCode);
	
	@Query(" SELECT 'Y' FROM Ocs0313 WHERE hospCode  = :f_hosp_code AND setPart = :f_set_part AND hangmogCode  = :f_hangmog_code "
			+ "AND setCode = :f_set_code AND setHangmogCode = :f_set_hangmog_code ")
	public String getOCS0311U00layDupSetHangmogRequest(@Param("f_hosp_code") String hospCode,@Param("f_set_part") String setPart,
			@Param("f_hangmog_code") String hangmogCode,@Param("f_set_code") String setCode,@Param("f_set_hangmog_code") String setHangmogCode);
}

