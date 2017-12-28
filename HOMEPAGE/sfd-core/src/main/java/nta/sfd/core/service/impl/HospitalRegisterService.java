package nta.sfd.core.service.impl;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import nta.sfd.core.entity.HospitalRegister;
import nta.sfd.core.jpa.DataSources;
import nta.sfd.core.model.HospitalRegisterModel;
import nta.sfd.core.repository.main.HospitalRegisterRepository;
import nta.sfd.core.service.IHospitalRegisterService;

import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional(value = DataSources.MAIN)
public class HospitalRegisterService implements IHospitalRegisterService {
	
	private Mapper mapper;
	
	private HospitalRegisterRepository hospitalRegisterRepository;
	
	@Autowired
	public HospitalRegisterService(Mapper mapper, HospitalRegisterRepository hospitalRegisterRepository) {
		this.mapper = mapper;
		this.hospitalRegisterRepository = hospitalRegisterRepository;
	}
	
	@Override
	public List<HospitalRegisterModel> findByStatus(Integer status) {
		List<HospitalRegisterModel> result = new ArrayList<HospitalRegisterModel>();
		List<HospitalRegister> lstHospitalRegisters = this.hospitalRegisterRepository.findByStatus(status);
		for (HospitalRegister each : lstHospitalRegisters) {
			result.add(each.toModel(mapper));
		}
		return result;
	}
	
	@Override
	public HospitalRegisterModel findBySessionId(String sessionId) {
		HospitalRegister hospitalRegister = this.hospitalRegisterRepository.findBySessionId(sessionId);
		if (hospitalRegister == null) {
			return null;
		}
		return hospitalRegister.toModel(mapper);		
	}

	@Override
	public Integer maxHospitalRegisterId() {
		Integer num = this.hospitalRegisterRepository.maxHospitalRegisterId();
		return num;
	}

	@Override
	public void updateHospitalRegister(HospitalRegisterModel model) {
		HospitalRegister entity = model.toEntity(mapper);
		this.hospitalRegisterRepository.save(entity);
	}
	
	@Override
	public Boolean isUniqueEmail(String email, BigDecimal demoFlg){
		Integer count = this.hospitalRegisterRepository.countHospitalRegisterIdByEmail(email, demoFlg);
		return count == 0 ? true : false;
	}

	@Override
	public List<HospitalRegisterModel> findHospitalUseVpn() {
		List<HospitalRegisterModel> result = new ArrayList<HospitalRegisterModel>();
		List<HospitalRegister> lstHospitalRegisters = this.hospitalRegisterRepository.findHospitalUseVpn();
		for (HospitalRegister each : lstHospitalRegisters) {
			result.add(each.toModel(mapper));
		}
		return result;
	}
}
