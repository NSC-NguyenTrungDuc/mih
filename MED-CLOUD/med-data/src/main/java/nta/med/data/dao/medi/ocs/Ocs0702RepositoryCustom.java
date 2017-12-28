package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.ocso.OCS2016U00LoadDiscussionInfo;

public interface Ocs0702RepositoryCustom {

	public List<OCS2016U00LoadDiscussionInfo> getOCS2016U00LoadDiscussionInfo(Long groupQuestionId);
	
}
