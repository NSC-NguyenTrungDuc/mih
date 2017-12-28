package nta.med.data.dao.medi.out;

import java.util.List;

import nta.med.data.model.ihis.nuro.OUT0106U00PatientItemInfo;

/**
 * @author dainguyen.
 */
public interface Out0112RepositoryCustom {
	
	public List<OUT0106U00PatientItemInfo> getOUT0106U00PatientItemInfo(String hospCode, String find1, String naewonDate);
}

