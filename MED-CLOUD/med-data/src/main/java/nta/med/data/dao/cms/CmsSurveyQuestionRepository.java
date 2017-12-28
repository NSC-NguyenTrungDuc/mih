package nta.med.data.dao.cms;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.cms.CmsSurveyQuestion;

public interface CmsSurveyQuestionRepository extends JpaRepository<CmsSurveyQuestion, Long>, CmsSurveyQuestionRepositoryCustom{
	

	List<CmsSurveyQuestion> findByCmsQuestionIdAndCmsSurveyQuestionGroupId(BigInteger CmsQuestionId, BigInteger CmsSurveyQuestionGroupId);
	
	@Modifying
	@Query(" UPDATE CmsSurveyQuestion SET activeFlg = 0 WHERE cmsSurveyQuestionGroupId = :groupId AND hospCode = :hospCode ")
	Integer updateActiveFlgByGroupId(@Param("groupId") BigInteger groupId, @Param("hospCode") String hospCode);

	@Query(" select T from CmsSurveyQuestion T where T.activeFlg = 1 AND T.cmsSurveyQuestionGroupId in :groupIds AND T.hospCode = :hospCode ")
	List<CmsSurveyQuestion> getListSurveyQuestionByQuestionGroupIds(@Param("groupIds") List<BigInteger> groupIds, @Param("hospCode") String hospCode);

}
