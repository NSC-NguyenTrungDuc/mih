package nta.med.data.dao.medi.ocs;

import java.math.BigDecimal;
import java.util.List;

import nta.med.data.model.ihis.ocso.OCS2016U00GrdQuestionInfo;

public interface Ocs0701RepositoryCustom {

	public List<OCS2016U00GrdQuestionInfo> getListOCS2016U00GrdQuestionInfo(String hospCode, String reqDoctor, String reqDate, String questionType, String gwa, String language);
	
	public String countToNotofication(String hospCode, String doctor, BigDecimal status);
	
}
