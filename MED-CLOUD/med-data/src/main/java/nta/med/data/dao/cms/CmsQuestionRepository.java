package nta.med.data.dao.cms;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.cms.CmsQuestion;

public interface CmsQuestionRepository extends JpaRepository<CmsQuestion, Long>, CmsQuestionRepositoryCustom {

	@Query("SELECT S FROM CmsQuestion S WHERE S.id =:groupQuestionId")
	List<CmsQuestion> findQuestionByQuestionGroupId(@Param("groupQuestionId") Long groupQuestionId);
}
