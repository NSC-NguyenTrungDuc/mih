package nta.med.data.dao.medi.ocs;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.ocs.Ocs0131;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0131Repository extends JpaRepository<Ocs0131, Long>, Ocs0131RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Ocs0131 SET updId = :f_user_id, updDate = :f_sys_date, codeTypeName = :f_code_type_name "
			+ ", ment = :f_ment, choiceUser = :f_choice_user WHERE codeType = :f_code_type AND language = :f_language")
	public Integer updateXSavePerformer(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_code_type_name") String codeTypeName,
			@Param("f_ment") String ment,
			@Param("f_choice_user") String choiceUser,
			@Param("f_code_type") String codeType,
			@Param("f_language") String language);
	
	@Modifying
	@Query("DELETE Ocs0131 WHERE codeType = :f_code_type AND language = :f_language")
	public Integer deleteXSavePerformer(@Param("f_code_type") String codeType, @Param("f_language") String language);
	
	@Query("Select a from Ocs0131 a where a.language = :f_language  order by a.codeType, a.codeTypeName ")
	public List<Ocs0131> getInfoOrderByCodeType(@Param("f_language") String language);
	
}

