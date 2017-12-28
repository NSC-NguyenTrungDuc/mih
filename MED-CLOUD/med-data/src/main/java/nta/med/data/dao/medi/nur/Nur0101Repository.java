package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0101;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0101Repository extends JpaRepository<Nur0101, Long>, Nur0101RepositoryCustom {
	@Query("	SELECT DISTINCT 'Y'    "
			+"	FROM Nur0101                   "
			+"	WHERE codeType = :f_code_type   "
			+"	AND language = :f_language   ")
	public String getNUR0101U01ExecuteTDupCheck(
			@Param("f_code_type") String codeType,
			@Param("f_language") String language);
	
	@Modifying		
	@Query("	UPDATE Nur0101	"
			+ "	SET updId = :q_user_id,	"
			+ "	updDate = :f_sys_date,	"
			+ "	codeType = :f_code_type,	"
			+ "	codeTypeName = :f_code_type_name,	"
			+ "	adminGubun = :f_admin_gubun	"
			+ "	WHERE codeType = :f_code_type	"
			+ "	AND language = :f_language	")
	public Integer updateNUR0101U01Case1Modified (
			@Param("q_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type") String codeType,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_admin_gubun") String adminGubun,
			@Param("f_language") String language);
	
	@Modifying		
	@Query("	DELETE Nur0101	"
			+ "	WHERE codeType = :f_code_type	   "
			+ "	AND language = :f_language	")
	public Integer deleteNUR0101U01Case2Deleted (
			@Param("f_code_type") String codeType,
			@Param("f_language") String language);
	
	
	@Modifying		
	@Query("	UPDATE Nur0101	"
			+ "	SET updId = :q_user_id,	"
			+ "	updDate = :f_sys_date,	"
			+ "	codeType = :f_code_type,	"
			+ "	codeTypeName = :f_code_type_name	"
			+ "	WHERE codeType = :f_code_type	"
			+ "	AND language = :f_language	")
	public Integer updateNUR0101U00Case1Modified (
			@Param("q_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type") String codeType,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_language") String language);
	
	@Modifying		
	@Query("	DELETE Nur0101	"
			+ "	WHERE codeType = :f_code_type	   "
			+ "	AND language = :f_language	")
	public Integer deleteNUR0101U00Case2Deleted (
			@Param("f_code_type") String codeType,
			@Param("f_language") String language);
	
	@Query("SELECT T FROM Nur0101 T WHERE language = :f_language AND adminGubun = :f_admin_gubun ORDER BY codeType")
	public List<Nur0101> findByAdminGubun(@Param("f_language") String language, 
												  @Param("f_admin_gubun") String adminGubun);
	
}


