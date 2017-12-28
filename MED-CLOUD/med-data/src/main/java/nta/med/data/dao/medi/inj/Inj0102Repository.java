package nta.med.data.dao.medi.inj;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.inj.Inj0102;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inj0102Repository extends JpaRepository<Inj0102, Long>, Inj0102RepositoryCustom {
	@Query("SELECT inj FROM Inj0102 inj WHERE inj.hospCode = :hospCode AND inj.codeType = :codeType AND inj.language = :f_language ORDER BY inj.code")
	public List<Inj0102> findByCodeType(@Param("hospCode") String hospCode, @Param("codeType") String codeType, @Param("f_language") String language);

	@Query("SELECT inj FROM Inj0102 inj WHERE inj.hospCode = :hospCode AND inj.codeType = :codeType AND inj.code = :code AND inj.language = :f_language ORDER BY inj.code")
	public List<Inj0102> findByCodeTypeAndCode(@Param("hospCode") String hospCode, @Param("codeType") String codeType, @Param("code") String code, @Param("f_language") String language);
	
	@Query("SELECT DISTINCT 'Y' FROM Inj0102 A WHERE A.hospCode = :f_hosp_code "
			+ "AND A.codeType = :f_code_type  AND A.code = :f_code AND A.language = :f_language")
	public String checkINJ0101U00GrdDetailGridColumnChanged(@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Inj0102 SET updId = :f_user_id, updDate = :f_sys_date, codeName = :f_code_name "
			+ " WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND code = :f_code AND language = :f_language")
	public Integer updateINJ0101U00UpdateINJ0102(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_name") String codeName,
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_language") String language);
	
	@Modifying
	@Query("DELETE Inj0102 A WHERE A.hospCode = :f_hosp_code AND A.codeType = :f_code_type AND A.code = :f_code AND A.language = :f_language")
	public Integer deleteINJ0101U00UpdateINJ0102(@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_language") String language);
	
	@Query(" SELECT codeName  FROM Inj0102 WHERE hospCode = :f_hosp_code  AND codeType LIKE 'BED%'  AND codeName = :f_code_name AND language = :f_language")
	public List<String> getINJ1001U01FormJusaBedLayPatientRequest(@Param("f_hosp_code") String hospCode,@Param("f_code_name") String codeName, @Param("f_language") String language);
	
	
	@Modifying
	@Query("	UPDATE Inj0102						"
			+"	SET updId = :q_user_id				"
			+"	, updDate = :f_sys_date				"
			+"	, codeName = :f_code_name			"
			+"	, remark = :f_remark				"
			+"	WHERE hospCode = :f_hosp_code 		"
			+"	AND codeType = :f_code_type			"
			+"	AND code = :f_code				    "
			+"  AND language = :f_language          ")
	public Integer updateINJ0101WhereHospCodeCodeTypeCode (
			@Param("q_user_id") String updId, 
			@Param("f_sys_date") Date updDate,
			@Param("f_code_name") String codeName,
			@Param("f_remark") String remark,
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_language") String language);
	
}

