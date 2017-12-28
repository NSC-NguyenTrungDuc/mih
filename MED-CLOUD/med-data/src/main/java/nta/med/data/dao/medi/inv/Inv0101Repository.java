package nta.med.data.dao.medi.inv;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.inv.Inv0101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inv0101Repository extends JpaRepository<Inv0101, Long>, Inv0101RepositoryCustom {
	@Query("SELECT 'X' FROM Inv0101 WHERE codeType = :f_code_type AND language = :f_language")
	public String checkDRG0102U00GrdMasterGridColumnChanged(@Param("f_code_type") String codeType,
															@Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Inv0101 							"
			+ "SET updId = :f_user_id,				"
			+ " updDate = :f_sys_date,				"
			+ " codeTypeName  = :f_code_type_name   "
			+ "WHERE codeType = :f_code_type 		"
			+ " AND language = :f_language          ")
	public Integer updateDRG0102U00UpdateInv0101(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type") String codeType,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_language") String language);
	
	@Modifying
	@Query(" UPDATE Inv0101 						"
			+ "  SET updId = :updId,				"
			+ "   updDate = :updDate,				"
			+ "   codeTypeName  = :codeTypeName,    "
			+ "   adminGubun  = :adminGubun,   	    "
			+ "   remark  = :remark     			"
			+ "  WHERE codeType = :codeType 	    "
			+ "    AND language = :f_language       ")
	public Integer updateDRG0102U01UpdateInv0101(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("codeTypeName") String codeTypeName,
			@Param("adminGubun") String adminGubun,
			@Param("remark") String remark,
			@Param("codeType") String codeType,
			@Param("f_language") String language);
	
	@Modifying 
	@Query("DELETE Inv0101 WHERE codeType = :f_code_type AND language = :f_language")
	public Integer deleteDRG0102U00UpdateInv0101(@Param("f_code_type") String codeType, @Param("f_language") String language);
	
	@Query("SELECT a FROM Inv0101 a WHERE a.codeType like :codeType "
			+ "AND a.codeTypeName like :codeTypeName AND a.language = :f_language order by a.codeType")
	public List<Inv0101> getByHospCodeAndCodeTypeAndCodeTypeName(
			@Param("codeType") String codeType,
			@Param("codeTypeName") String codeTypeName,
			@Param("f_language") String language);
	
	
}

