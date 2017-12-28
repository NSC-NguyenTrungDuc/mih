package nta.mss.service.impl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.mss.model.HospitalTrackingModel;
import nta.mss.repository.HospitalTrackingRepository;
import nta.mss.service.IHospitalTrackingService;

@Service
@Transactional
public class HospitalTrackingService implements IHospitalTrackingService {
	
	@Autowired
	private HospitalTrackingRepository hospitalTrackingRepository;
	
	@Override
	public List<HospitalTrackingModel> getTrackingCodeByHospitalCode(Integer hospitalId) {
		
		List<HospitalTrackingModel> lst =  this.hospitalTrackingRepository.getTrackingCodeByPageCode(hospitalId);
		return lst;		
	
	}	

}
