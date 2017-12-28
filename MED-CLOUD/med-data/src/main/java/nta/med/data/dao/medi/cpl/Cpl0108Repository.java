package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.core.domain.cpl.Cpl0108;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0108Repository extends JpaRepository<Cpl0108, Long>, Cpl0108RepositoryCustom {
	@Modifying                                     
	@Query("	UPDATE Cpl0108						"
			+"	SET updId          = :userId        " 
			+"	  , updDate        = SYSDATE()      " 
			+"	  , codeTypeName  = :codeTypeName   " 
			+"	 WHERE codeType    = :codeType AND language = :language     ")
		public Integer updateCPL0108U00(@Param("userId") String userId, 
				@Param("codeTypeName") String codeTypeName,
				@Param("codeType") String codeType,
				@Param("language") String language);

	@Modifying                                     
	@Query("	DELETE Cpl0108						"
			+"	WHERE codeType = :codeType    AND language = :language 	    ")
		public Integer deleteCPL0108U00(
				@Param("codeType") String codeType,
				@Param("language") String language);
	
	@Query(" SELECT 'X' FROM Cpl0108 WHERE codeType = :f_code_type AND language = :language ")
	public List<String> getXByCodeType(@Param("f_code_type") String codeType,
			@Param("language") String language);
	
	@Modifying
	@Query("UPDATE Cpl0108 SET updId  = :q_user_id, updDate = SYSDATE(), codeTypeName  = :f_code_type_name, adminGubun  = :f_admin_gubun "
			+ "WHERE codeType  = :f_code_type AND language = :language")
	public Integer updateCPL0108U01(@Param("q_user_id") String userId,@Param("f_code_type_name") String codeTypeName,
			@Param("f_admin_gubun") String adminGubun,@Param("f_code_type") String codeType,
			@Param("language") String language);
}

