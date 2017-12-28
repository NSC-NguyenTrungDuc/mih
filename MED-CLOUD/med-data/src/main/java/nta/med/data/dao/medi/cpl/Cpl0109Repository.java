package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.core.domain.cpl.Cpl0109;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0109Repository extends JpaRepository<Cpl0109, Long>, Cpl0109RepositoryCustom {
	@Modifying                                     
	@Query("	DELETE Cpl0109					"
			+"	WHERE codeType = :codeType      "
			+"	AND hospCode = :hospCode        "
			+"	AND code     = :code            "
			+ " AND language = :language ") 
		public Integer deleteCPL010108U00Cpl0109( 
				@Param("codeType") String codeType,
				@Param("hospCode") String hospCode,
				@Param("code") String code,
				@Param("language") String language);
	
	@Modifying                                     
	@Query("	UPDATE Cpl0109							"
			+"	SET updId            = :userId         "
			+"	  , updDate          = SYSDATE()       "
			+"	  , codeName         = :codeName       "
			+"	  , codeNameRe      = :codeNameRe    "
			+"	  , systemGubun      = 'CPL'           "
			+"	  , codeValue        = :codeValue      "
			+"	  , modifyFlg        = :modifyFlg      "
			+"	WHERE codeType       = :codeType       "
			+"	AND code              = :code           "
			+"	AND hospCode         = :hospCode  "
			+ " AND language = :language     ") 
		public Integer updateCPL010108U00Cpl0109( 
				@Param("userId") String userId,
				@Param("codeName") String codeName,
				@Param("codeNameRe") String codeNameRe,
				@Param("codeValue") String codeValue,
				@Param("modifyFlg") String modifyFlg,
				@Param("codeType") String codeType,
				@Param("code") String code,
				@Param("hospCode") String hospCode,
				@Param("language") String language);
	
	@Query("SELECT codeValue FROM Cpl0109 WHERE hospCode = :f_hosp_code AND language = :f_language AND codeType = :f_code_type AND code = :f_code")
	public String getCPL3020U02SetAutoConfirmChecked(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code);
	
	@Query("SELECT codeName FROM Cpl0109 WHERE hospCode = :f_hosp_code AND language = :f_language AND codeType = :f_code_type AND code = :f_code")
	public String getCPL3010U00VSVJundalGubun(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code);

	
//	@Query("SELECT 'Y' FROM (SELECT NULL FROM Cpl0109 WHERE hospCode = :hospCode AND codeType = '20' AND code = :f_code) A")
//	public String getCPL2010U00GetYValue(@Param("hospCode") String hospCode,@Param("f_code") String code);
	
	@Query(" SELECT 'X' FROM Cpl0109 WHERE hospCode = :f_hosp_code AND language = :f_language AND code  = :f_code AND codeType = :f_code_type")
	public List<String> getXByCodeAndCodeType(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,
			@Param("f_code") String code,@Param("f_code_type") String codeType);
	
	@Query(" SELECT 'X' FROM Cpl0109 WHERE hospCode = :f_hosp_code AND language = :f_language AND codeType = :f_code_type ")
	public List<String> getXByCodeType(@Param("f_hosp_code") String hospCode,@Param("f_language") String language,@Param("f_code_type") String codeType);
	
	@Modifying
	@Query(" DELETE Cpl0109 WHERE codeType = :codeType AND hospCode = :hospCode AND language = :language")
	public Integer deleteCpl0109ByCodeType(@Param("codeType") String codeType,@Param("hospCode") String hospCode,@Param("language") String language);
}

