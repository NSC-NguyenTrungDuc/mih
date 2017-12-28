package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.core.domain.xrt.Xrt0101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt0101Repository extends JpaRepository<Xrt0101, Long>, Xrt0101RepositoryCustom {
	@Query(" SELECT DISTINCT 'Y' FROM Xrt0101 WHERE codeType = :f_code_type AND language = :f_language ")
	public String getYValueLayDupM(@Param("f_code_type") String codeType, @Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Xrt0101 SET updId  = :q_user_id, updDate   = SYSDATE(), codeTypeName  = :f_code_type_name "
			+ "WHERE codeType  = :f_code_type AND language = :f_language ")
	public Integer updateXrt0101XRT0101U00ExecuteCase1(@Param("q_user_id") String userId,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_code_type") String codeType, 
			@Param("f_language") String language);
	
	@Modifying
	@Query("DELETE Xrt0101 WHERE codeType = :f_code_type AND language = :f_language ")
	public Integer deleteXrt0101XRT0101U00ExecuteCase1(@Param("f_code_type") String codeType, 
			@Param("f_language") String language);
	
	@Query("SELECT xrt  FROM Xrt0101 xrt WHERE xrt.codeType LIKE :f_code_type AND xrt.language = :f_language ORDER BY xrt.codeType ")
	public List<Xrt0101> getXRT0101U01Object(@Param("f_code_type") String codeType,
			@Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Xrt0101 SET updId  = :q_user_id, updDate   = SYSDATE(), codeTypeName  = :f_code_type_name,adminGubun = :f_admin_gubun "
			+ "WHERE codeType  = :f_code_type AND language = :f_language ")
	public Integer updateXrt0101XRT0101U01ExecuteCase1(@Param("q_user_id") String userId,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_admin_gubun") String adminGubun,
			@Param("f_code_type") String codeType,
			@Param("f_language") String language);
}

