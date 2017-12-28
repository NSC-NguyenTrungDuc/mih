package nta.mss.service;

import java.util.List;

import nta.mss.model.HospitalTrackingModel;

public interface IHospitalTrackingService {
	
	public List<HospitalTrackingModel> getTrackingCodeByHospitalCode(Integer hospitalId);
	
}
