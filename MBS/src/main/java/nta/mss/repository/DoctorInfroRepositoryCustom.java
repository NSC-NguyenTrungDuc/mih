package nta.mss.repository;

import java.util.List;

/**
 * @author linh.nguyen.trong
 * 
 * The Class DoctorInfroRepositoryCustom.
 */
public interface DoctorInfroRepositoryCustom {
	public List<Object[]> findAllDoctorInfo(Integer hospitalId);
}
