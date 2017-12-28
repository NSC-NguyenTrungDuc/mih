package nta.med.data.dao.medi.out;

import java.util.List;

import nta.med.data.model.ihis.nuro.OUT0106U00PatientCommentItemInfo;

/**
 * @author dainguyen.
 */
public interface Out0113RepositoryCustom {
	
	public List<OUT0106U00PatientCommentItemInfo> getOUT0106U00PatientCommentItemInfo(String hospCode, String bunho, String naewonDate);
}

