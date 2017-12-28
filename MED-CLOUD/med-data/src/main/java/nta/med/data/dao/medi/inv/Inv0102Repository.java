package nta.med.data.dao.medi.inv;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.inv.Inv0102;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inv0102Repository extends JpaRepository<Inv0102, Long>, Inv0102RepositoryCustom {
	@Query("SELECT inv FROM Inv0102 inv WHERE inv.hospCode = :hospCode AND inv.codeType = :codeType AND inv.language = :f_language ORDER BY code ")
	public List<Inv0102> findByCodeType(@Param("hospCode") String hospCode, @Param("codeType") String codeType, @Param("f_language") String language);
	
	@Query("SELECT 'X' FROM Inv0102 WHERE code = :f_code AND codeType = :f_code_type AND language = :f_language")
	public String checkDRG0102U00GrdDetailGridColumnChanged(@Param("f_code") String code
			, @Param("f_code_type") String codeType, @Param("f_language") String language);
	
	@Query("SELECT 'X' FROM Inv0102 WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND language = :f_language")
	public String checkDRG0102U00CheckExitToDelete(@Param("f_hosp_code") String hospCode
			, @Param("f_code_type") String codeType, @Param("f_language") String language);
	
	@Query("SELECT 'X' FROM Inv0102 WHERE hospCode = :f_hosp_code AND codeType = :f_code_type AND code = :f_code AND language = :f_language")
	public String checkDrg0102U01GrdDetail(@Param("f_hosp_code") String hospCode
			, @Param("f_code_type") String codeType,  @Param("f_code") String code, @Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Inv0102 SET updId = :f_user_id, updDate = :f_sys_date, codeName = :f_code_name, codeValue = :f_code_value "
			+ "WHERE codeType = :f_code_type AND code = :f_code AND hospCode = :f_hosp_code AND language = :f_language")
	public Integer updateDRG0102U00UpdateInv0102(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_name") String codeName,
			@Param("f_code_value") String codeValue,
			@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language);
	
	@Modifying
	@Query(" UPDATE Inv0102                "
		+ "   SET updId = :updId,          "
		 + "   updDate  = :updDate,        "
		 + "   code2 	= :code2,          "
		 + "   codeName = :codeName,       "
		 + "   codeValue = :codeValue,      "
		 + "   remark    = :remark         "
		 + "   WHERE codeType = :codeType  "
		 + "   AND code = :code             "
		 + "   AND hospCode = :hospCode    "
		 + "   AND language = :f_language  ")
	public Integer updateDRG0102U01UpdateInv0102(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("code2") String code2,
			@Param("codeName") String codeName,
			@Param("codeValue") String codeValue,
			@Param("remark") String remark,
			@Param("codeType") String codeType,
			@Param("code") String code,
			@Param("hospCode") String hospCode,
			@Param("f_language") String language);

	@Modifying
	@Query(" UPDATE Inv0102                "
		+ "   SET updId = :updId,          "
		 + "   updDate  = :updDate,        "
		 + "   codeName = :codeName,	   "
		 + "   sortKey  = :sortKey		   "
		 + "   WHERE codeType = :codeType  "
		 + "   AND code = :code            "
		 + "   AND hospCode = :hospCode    "
		 + "   AND language = :f_language  ")
	public Integer updateInv0101U00UpdateInv0102(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("codeName") String codeName,
			@Param("sortKey") Double sortKey,
			@Param("codeType") String codeType,
			@Param("code") String code,
			@Param("hospCode") String hospCode,
			@Param("f_language") String language);
	
	@Modifying 
	@Query("DELETE Inv0102 WHERE codeType = :f_code_type AND hospCode = :f_hosp_code AND language = :f_language")
	public Integer deleteDRG0102U00UpdateInv0101(
			@Param("f_code_type") String codeType,
			@Param("f_hosp_code") String hospCode, 
			@Param("f_language") String language);
	
	@Modifying 
	@Query("DELETE Inv0102 WHERE codeType = :f_code_type AND code = :f_code AND hospCode = :f_hosp_code AND language = :f_language")
	public Integer deleteDRG0102U00UpdateInv0102(@Param("f_code_type") String codeType,
			@Param("f_code") String code,
			@Param("f_hosp_code") String hospCode,
			@Param("f_language") String language);
	
	@Query("select a from Inv0102 a where a.hospCode = :hospCode and a.codeType = :codeType  AND language = :f_language order by a.hospCode, a.codeType, a.code")
	public List<Inv0102> getByHospCodeAndCodeType(@Param("hospCode") String hospCode, 
			@Param("codeType") String codeType,
			@Param("f_language") String language);
	
	@Query("SELECT codeName FROM Inv0102 WHERE hospCode = :hospCode AND language = :language AND code = :f_code AND codeType = :f_code_type")
	public List<String> getCodeNameByCodeAndCodeType(@Param("hospCode") String hospCode
			,@Param("language") String language
			,@Param("f_code") String code
			, @Param("f_code_type") String codeType);
	
}

