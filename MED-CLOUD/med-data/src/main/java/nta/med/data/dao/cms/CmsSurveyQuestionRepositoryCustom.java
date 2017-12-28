package nta.med.data.dao.cms;

import java.math.BigInteger;
import java.util.List;

import nta.med.data.model.cms.CmsSurveyQuestionInfo;

public interface CmsSurveyQuestionRepositoryCustom {
	public List<CmsSurveyQuestionInfo> getQuestionInfo(BigInteger questionGroupId);
}
