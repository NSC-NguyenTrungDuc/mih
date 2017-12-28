package nta.mss.repository;

import java.util.List;

import org.springframework.stereotype.Repository;

import nta.mss.info.HospitalDto;
import nta.mss.model.HospitalModel;
/**
 * 
 * @author DEV-HuanLT
 *
 */
@Repository
public interface HospitalRepositoryCustom {
	
	public Integer updateHospitalInfo(HospitalModel hospitalModel);
	
	public List<HospitalDto> getHospitalModelByHospitalCode(String hospitalCode);
}
