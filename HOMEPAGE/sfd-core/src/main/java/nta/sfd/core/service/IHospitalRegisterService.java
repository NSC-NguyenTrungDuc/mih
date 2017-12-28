package nta.sfd.core.service;

import java.math.BigDecimal;
import java.util.List;

import nta.sfd.core.model.HospitalRegisterModel;

public interface IHospitalRegisterService {
	List<HospitalRegisterModel> findByStatus(Integer status);
	
	List<HospitalRegisterModel> findHospitalUseVpn();
	
	HospitalRegisterModel findBySessionId(String sessionId);
	
	Integer maxHospitalRegisterId();
	
	void updateHospitalRegister(HospitalRegisterModel model);
	
	Boolean isUniqueEmail(String email, BigDecimal demoFlg);
}
