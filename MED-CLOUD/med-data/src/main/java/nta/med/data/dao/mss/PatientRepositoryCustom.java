package nta.med.data.dao.mss;

import java.math.BigInteger;
import java.util.List;

import nta.med.data.model.mss.PatientInfo;

public interface PatientRepositoryCustom {
	
	List<PatientInfo> findPatientInfoByProfileId(BigInteger profileId);
	
}
