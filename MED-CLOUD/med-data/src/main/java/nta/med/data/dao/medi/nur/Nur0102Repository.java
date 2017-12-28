package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0102;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0102Repository extends JpaRepository<Nur0102, Long>, Nur0102RepositoryCustom {
	
	@Query("SELECT entity FROM Nur0102 entity WHERE entity.hospCode = :hospCode AND entity.codeType = :codeType AND language = :language ORDER BY entity.code, entity.sortKey")
	public List<Nur0102> findByCodeTypeLanguage(@Param("hospCode") String hospCode, @Param("codeType") String codeType, @Param("language") String language);
	
	@Query("	SELECT DISTINCT 'Y'				"
			+"	  FROM Nur0102					"
			+"	WHERE hospCode = :f_hosp_code 	"
			+"	  AND codeType = :f_code_type	"
			+"	  AND language = :f_language	")
	public String getNUR0101U01ExecuteTDupCheck(
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("f_language") String language);
	
	
	@Query("	SELECT DISTINCT 'Y'				"
			+"	FROM Nur0102					"
			+"	WHERE hospCode = :f_hosp_code 	"
			+"	AND codeType = :f_code_type		"
			+"	AND code = :f_code				"
			+"	AND language = :f_language		")
	public String getNUR0101U01WhereHospCodeCodeTypeCode (
			@Param("f_hosp_code") String hospCode,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_language") String language);
	
	@Modifying		
	@Query("	UPDATE Nur0102	"
			+ "	SET updId = :q_user_id,	"
			+ "	updDate = :f_sys_date,	"
			+ "	codeType = :f_code_type,	"
			+ "	code = :f_code,	"
			+ "	codeName = :f_code_name,	"
			+ "	sortKey = :f_sort_key	"
			+ "	WHERE hospCode = :f_hosp_code	"
			+ "	AND language = :f_language	"
			+ "	AND codeType = :f_code_type	"
			+ "	AND code = :f_code	")
	public Integer updateNUR0101U01WhereHospCodeCodeTypeCode (
			@Param("q_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_code_name") String codeName,
			@Param("f_sort_key") Double sortKey,
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language
			);

	@Modifying		
	@Query("	DELETE Nur0102	"
			+ "	WHERE hospCode = :f_hosp_code  "
			+ "	AND language = :f_language	"
			+ "	AND codeType = :f_code_type	   "
			+ "	AND code = :f_code			   ")
	public Integer deleteNUR0101U01Case2Deleted (
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code
			);
	
	@Modifying		
	@Query("	UPDATE Nur0102	"
			+ "	SET updId = :q_user_id,	"
			+ "	updDate = :f_sys_date,	"
			+ "	codeType = :f_code_type,	"
			+ "	code = :f_code,	"
			+ "	codeName = :f_code_name,	"
			+ "	sortKey = :f_sort_key,	"
			+ "	groupKey = :f_group_key,	"
			+ "	startDate = :f_start_date,	"
			+ "	endDate = :f_end_date,	"
			+ "	ment = :f_ment	"
			+ "	WHERE hospCode = :f_hosp_code	"
			+ "	AND language = :f_language	"
			+ "	AND codeType = :f_code_type	"
			+ "	AND code = :f_code	")
	public Integer updateNUR0101U00WhereHospCodeCodeTypeCode (
			@Param("q_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_code_name") String codeName,
			@Param("f_sort_key") Double sortKey,
			@Param("f_group_key") String groupKey,
			@Param("f_start_date") Date startDate,
			@Param("f_end_date") Date endDate,
			@Param("f_ment") String ment,
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language
			);
	
	@Modifying		
	@Query("	DELETE Nur0102	"
			+ "	WHERE hospCode = :f_hosp_code  "
			+ "	AND language = :f_language	"
			+ "	AND codeType = :f_code_type	   "
			+ "	AND code = :f_code			   ")
	public Integer deleteNUR0101U00Case2Deleted (
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code
			);
	
	@Query("SELECT T FROM Nur0102 T WHERE T.hospCode = :hospCode AND T.codeType = :codeType AND T.code = :code AND T.language = :language ")
	public List<Nur0102> findByCodeTypeCodeLanguage(@Param("hospCode") String hospCode
			, @Param("codeType") String codeType
			, @Param("code") 	 String code
			, @Param("language") String language);
	
	@Modifying		
	@Query("	UPDATE Nur0102	"
			+ "	SET updId = :q_user_id,	"
			+ "	updDate = :f_sys_date,	"
			+ "	codeName = :f_code_name,	"
			+ "	sortKey = :f_sort_key	"
			+ "	WHERE hospCode = :f_hosp_code	"
			+ "	AND language = :f_language	"
			+ "	AND codeType = :f_code_type	"
			+ "	AND code = :f_code	")
	public Integer updateByHospCodeCodeTypeCode (@Param("q_user_id") String updId,
												 @Param("f_sys_date") Date updDate,
												 @Param("f_code_type") String codeType,
												 @Param("f_code") String code,
												 @Param("f_code_name") String codeName,
												 @Param("f_sort_key") Double sortKey,
												 @Param("f_hosp_code") String hospCode,
												 @Param("f_language") String language);
}

