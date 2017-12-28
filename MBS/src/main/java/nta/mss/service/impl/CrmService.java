package nta.mss.service.impl;

import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.mss.repository.DepartmentRepository;
import nta.mss.repository.DoctorRepository;
import nta.mss.repository.HospitalRepository;
import nta.mss.service.ICrmService;

@Service
@Transactional
public class CrmService implements ICrmService {
	
	private Mapper mapper;
	private HospitalRepository hospitalRepository;
	private DoctorRepository doctorRepository;
	private DepartmentRepository departmentRepository;

    CrmService(){
    }
	/**
	 * Instantiates a new hospital service.
	 * 
	 * @param mapper
	 *            the mapper
	 * @param hospitalRepository
	 *            the hospital repository
	 */
	@Autowired
	public CrmService(Mapper mapper, HospitalRepository hospitalRepository,
			DoctorRepository doctorRepository, DepartmentRepository departmentRepository) {
		this.mapper = mapper;
		this.hospitalRepository = hospitalRepository;
		this.doctorRepository = doctorRepository;
		this.departmentRepository = departmentRepository;
	}
}
