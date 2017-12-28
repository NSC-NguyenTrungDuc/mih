package nta.med.data.dao.cms;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.cms.CmsSurveyQuestionGroup;

public interface CmsSurveyQuestionGroupRepository extends JpaRepository<CmsSurveyQuestionGroup, Long>, CmsSurveyQuestionGroupRepositoryCustom{

	@Query("SELECT T FROM CmsSurveyQuestionGroup T WHERE T.hospCode = :hospCode AND T.cmsSurveyId = :f_cmsSurveyId AND T.activeFlg = 1")
	public List<CmsSurveyQuestionGroup> findBySurveyIdAndHospCode(@Param("f_cmsSurveyId") BigInteger cmsSurveyId, @Param("hospCode") String hospCode);
}
