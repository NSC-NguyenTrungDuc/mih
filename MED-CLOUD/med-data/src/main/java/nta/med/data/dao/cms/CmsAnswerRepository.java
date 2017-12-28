package nta.med.data.dao.cms;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.cms.CmsAnswer;

public interface CmsAnswerRepository extends JpaRepository<CmsAnswer, Long>, CmsAnswerRepositoryCustom{

	@Query("SELECT T FROM CmsAnswer T WHERE T.cmsQuestionId = :f_questionId AND T.activeFlg = 1 AND T.hospCode = :hospCode")
	public List<CmsAnswer> findByQuestionId(@Param("f_questionId") Long questionId, @Param("hospCode") String hospCode);

	@Query("SELECT T FROM CmsAnswer T WHERE T.cmsQuestionId in :questions AND T.activeFlg = 1 AND T.hospCode = :hospCode")
	public List<CmsAnswer> getListAnswerByQuestionIds(@Param("questions") List<Long> questions, @Param("hospCode") String hospCode);
}
