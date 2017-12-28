package nta.med.data.dao.cms;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.cms.CmsSurvey;

public interface CmsSurveyRepository extends JpaRepository<CmsSurvey, Long>, CmsSurveyRepositoryCustom{
	
	@Query(" SELECT S FROM CmsSurvey S WHERE S.id =:id AND S.hospCode = :hospCode AND S.activeFlg = 1 ")
	public CmsSurvey getSurveyById(@Param("id") Long id, @Param("hospCode") String hospCode);
	
	@Query(" SELECT S FROM CmsSurvey S WHERE S.departmentCode = :departmentCode AND S.defaultFlg = 1 AND S.hospCode = :hospCode")
	public List<CmsSurvey> findByDepartmentCode(@Param("departmentCode") String departmentCode, @Param("hospCode") String  hospCode);
	@Modifying
	@Query("UPDATE CmsSurvey SET defaultFlg = 1 WHERE id = :f_survey_id AND departmentCode = :departmentCode AND hospCode = :hospCode ")
	public Integer setActiveSurvey(@Param("f_survey_id") Long id, @Param("departmentCode") String departmentCode, @Param("hospCode") String  hospCode);
	@Modifying
	@Query("UPDATE CmsSurvey SET defaultFlg = 0 WHERE id <> :f_survey_id AND departmentCode = :departmentCode AND defaultFlg = 1 AND hospCode = :hospCode ")
	public Integer deActiveSurvey(@Param("f_survey_id") Long id, @Param("departmentCode") String departmentCode, @Param("hospCode") String  hospCode);
}
