package nta.med.data.dao.cms;

import java.math.BigInteger;
import java.util.List;

import nta.med.core.domain.cms.CmsQuestion;
import nta.med.data.model.cms.CmsQuestionInfo;
import nta.med.data.model.cms.CmsSurveyQuestionInfo;

public interface CmsQuestionRepositoryCustom {

	public List<CmsQuestionInfo> getListCmsQuestion(String hospCode, String departmentCode, String questionType,
			String questionContent, Integer startIndex, Integer pageSize, String column, String dir, boolean isPaging);
	
	public boolean deleteQuestionList(List<Long> questionIdList, String hospCode);
	
	public int countRecord(String hospCode, String departmentCode, String questionType,
			String questionContent) ;
	

}
