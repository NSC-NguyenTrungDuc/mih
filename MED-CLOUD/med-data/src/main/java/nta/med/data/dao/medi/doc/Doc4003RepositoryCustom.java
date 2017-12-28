package nta.med.data.dao.medi.doc;

import java.util.List;

import nta.med.data.model.ihis.ocsa.DOC4003U00GetHospInfo;
import nta.med.data.model.ihis.ocsa.DOC4003U00GrdDOC4003Info;

/**
 * @author dainguyen.
 */
public interface Doc4003RepositoryCustom {
	public List<DOC4003U00GrdDOC4003Info> getDOC4003U00GrdDOC4003Info(String hospCode, String bunho);
	
}

