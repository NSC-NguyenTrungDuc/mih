package nta.med.data.dao.medi.pfe;

import java.util.Date;

import nta.med.core.domain.pfe.Pfe0102;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Pfe0102Repository extends JpaRepository<Pfe0102, Long>, Pfe0102RepositoryCustom {
	@Query(" SELECT 'Y' FROM Pfe0102  WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND code  = :f_code AND language = :f_language ")
	public String getPFE0101U00LayDupDRequest(@Param("f_hosp_code") String hospCode,@Param("f_code_type") String codeType,
			@Param("f_code") String code,@Param("f_language") String language);
	
	@Modifying
    @Query("DELETE Pfe0102  WHERE hospCode = :f_hosp_code  AND codeType = :f_code_type AND code = :f_code AND language = :f_language ")
	public Integer getDeletePFE0101U00SaveLayout(@Param("f_hosp_code") String hospCode,@Param("f_code_type") String codeType,
			@Param("f_code") String code,@Param("f_language") String language);
	
	@Modifying
    @Query("DELETE Pfe0102  WHERE hospCode = :f_hosp_code  AND codeType = :f_code_type AND language = :f_language ")
	public Integer getDeletePFE0101U01SaveLayout(@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,@Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Pfe0102 SET updId  = :q_user_id , updDate = :f_sys_date, "
			+ "codeName = :f_code_name , codeNameRe   = :f_code_name_re, "
			+ " codeValue   = :f_code_value "
			+ "WHERE hospCode = :f_hosp_code AND codeType  = :f_code_type AND code = :f_code AND language = :f_language ")
	public Integer getUpdatePFE0101U00SaveLayout(@Param("f_hosp_code") String hospCode,@Param("q_user_id") String userId,@Param("f_sys_date") Date sysDate,
			@Param("f_code_name") String codeName,@Param("f_code_name_re") String codeNameRe,@Param("f_code_value") String codeValue,
			@Param("f_code_type") String codeType,@Param("f_code") String code,@Param("f_language") String language);
}

