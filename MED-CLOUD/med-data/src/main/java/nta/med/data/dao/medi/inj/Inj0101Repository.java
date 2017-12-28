package nta.med.data.dao.medi.inj;

import java.util.Date;

import nta.med.core.domain.inj.Inj0101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inj0101Repository extends JpaRepository<Inj0101, Long>, Inj0101RepositoryCustom {
	
	@Query("SELECT DISTINCT 'Y' FROM Inj0101 A "
			+ "WHERE A.codeType = :f_code_type AND A.language = :f_language")
	public String checkINJ0101U00GrdMasterGridColumnChanged(@Param("f_code_type") String codeType, @Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Inj0101 SET updId = :f_user_id, updDate = :f_sys_date, codeTypeName = :f_code_type_name "
			+ "WHERE codeType = :f_code_type AND language = :f_language")
	public Integer updateINJ0101U00UpdateINJ0101(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_code_type") String codeType,
			@Param("f_language") String language);
	
	@Modifying
	@Query("DELETE Inj0101 A WHERE A.codeType = :f_code_type AND A.language = :f_language")
	public Integer deleteINJ0101U00UpdateINJ0101(@Param("f_code_type") String codeType, @Param("f_language") String language);
	
	@Modifying
	@Query("	UPDATE Inj0101							"
			+"	SET updId = :q_user_id					"
			+"	, updDate = :f_sys_date				    "
			+"	, codeTypeName = :f_code_type_name	    "
			+"	, adminGubun = :f_admin_gubun			"
			+"	, remark = :f_remark					"
			+"	WHERE codeType = :f_code_type  AND language = :f_language			")
	public Integer updateINJ0101WhereHospCodeCodeType (
			@Param("q_user_id") String updId, 
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_admin_gubun") String adminGubun,
			@Param("f_remark") String remark,
			@Param("f_code_type") String codeType,
			@Param("f_language") String language);

}

