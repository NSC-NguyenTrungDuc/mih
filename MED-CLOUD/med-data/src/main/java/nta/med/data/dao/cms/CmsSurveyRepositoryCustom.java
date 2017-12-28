package nta.med.data.dao.cms;

import java.math.BigInteger;

public interface CmsSurveyRepositoryCustom {
	
	public boolean deleteSurvey(BigInteger surveyId, String hospCode);
}
