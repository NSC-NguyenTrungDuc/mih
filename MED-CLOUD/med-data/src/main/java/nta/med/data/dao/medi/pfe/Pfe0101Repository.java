package nta.med.data.dao.medi.pfe;

import java.util.Date;

import nta.med.core.domain.pfe.Pfe0101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Pfe0101Repository extends JpaRepository<Pfe0101, Long>, Pfe0101RepositoryCustom {
	@Query("SELECT 'Y' FROM Pfe0101 WHERE codeType = :f_code_type AND language = :f_language ")
	public String getPFE0101U00LayDupM(@Param("f_code_type") String codeType, @Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Pfe0101 SET updId = :f_user_id, updDate = :f_sys_date, codeTypeName = :f_code_type_name, "
			+ " adminGubun = :f_admin_gubun WHERE codeType = :f_code_type AND language = :f_language ")
	public Integer getUpdatePFE0101U01SaveLayout(
			@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_admin_gubun") String adminGubun,
			@Param("f_code_type") String codeType,
			@Param("f_language") String language);
	
	@Modifying
	@Query("DELETE Pfe0101 WHERE codeType = :f_code_type AND language = :f_language ")
	public Integer getDeletePFE0101U01SaveLayout(@Param("f_code_type") String codeType,@Param("f_language") String language);
			
}

