package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.mss.entity.Department;
import nta.mss.entity.Doctor;
import nta.mss.entity.Hospital;
import nta.mss.info.HospitalDto;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.model.DepartmentModel;
import nta.mss.model.DoctorModel;
import nta.mss.model.HospitalModel;
import nta.mss.repository.DepartmentRepository;
import nta.mss.repository.DoctorRepository;
import nta.mss.repository.HospitalRepository;
import nta.mss.service.IHospitalService;

/**
 * The Class HospitalService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Service
@Transactional
public class HospitalService implements IHospitalService {
	private Mapper mapper;
	private HospitalRepository hospitalRepository;
	private DoctorRepository doctorRepository;
	private DepartmentRepository departmentRepository;

    HospitalService(){
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
	public HospitalService(Mapper mapper, HospitalRepository hospitalRepository,
			DoctorRepository doctorRepository, DepartmentRepository departmentRepository) {
		this.mapper = mapper;
		this.hospitalRepository = hospitalRepository;
		this.doctorRepository = doctorRepository;
		this.departmentRepository = departmentRepository;
	}
	
	
	/**
	 * Find hospital by id.
	 * 
	 * @param hospitalId
	 *            the hospital id
	 * @return the hospital model
	 */
	public HospitalModel findHospitalById(Integer hospitalId) {
		Hospital hospital = this.hospitalRepository.findOne(hospitalId);
		return hospital.toModel(mapper);
	}

	/**
	 * find all hospital
	 * @return List<HospitalModel>
	 */
	public List<HospitalModel> findAllHospital() {
		List<Hospital> lstHospital = this.hospitalRepository
				.findHospitalByActiveFlg(ActiveFlag.ACTIVE.toInt());
		List<HospitalModel> lstHospitalModel = new ArrayList<HospitalModel>();
		for (Hospital hospital : lstHospital) {
			lstHospitalModel.add(hospital.toModel(mapper));
		}
		return lstHospitalModel;
	}

	/**
	 * @author linh.nguyen.trong
	 * 
	 * find all HospitalModel
	 * @return List<HospitalModel>
	 */
	@Override
	public HospitalModel findHospitalModelByHospitalId(Integer hospitalId) {
		
		HospitalModel hospitalModel = new HospitalModel();
		Hospital hospital = this.hospitalRepository
				.findHospital(hospitalId, ActiveFlag.ACTIVE.toInt());
		if(hospital != null){
			hospitalModel = hospital.toModel(mapper, "exclude-departments");
		}

		List<Department> lstDept = this.departmentRepository.findAllDepartmentInHospital(hospitalModel.getHospitalId());
		Map<Integer, List<DoctorModel>> mapDeptListDoctor = new HashMap<Integer, List<DoctorModel>>();
		for (Department department : lstDept) {
			Integer deptId = department.getDeptId();
			List<Doctor> lstDoctor = this.doctorRepository.findByDeptIdOrdered(deptId);
			List<DoctorModel> lstDoctorModel = new ArrayList<DoctorModel>();
			for (Doctor doctor : lstDoctor) {
				lstDoctorModel.add(doctor.toModel(mapper));
			}
			mapDeptListDoctor.put(deptId, lstDoctorModel);
		}

		List<DepartmentModel> lstDeptModel = new ArrayList<DepartmentModel>();
		for (Department department : lstDept) {
			lstDeptModel.add(department.toModel(mapper));
		}
		
		hospitalModel.setDepartments(lstDeptModel);
		hospitalModel.setMapDeptIdWithListDoctor(mapDeptListDoctor);

		return hospitalModel;
	}

	/**
	 * @author linh.nguyen.trong
	 * @since 30/07/2014
	 * 
	 * Delete hospital
	 */
	@Override
	public void deleteHospital(HospitalModel hospitalModel) throws Exception {
		Hospital hospital = hospitalModel.toEntity(mapper);
		hospital.setActiveFlg(ActiveFlag.INACTIVE.toInt());
		this.hospitalRepository.save(hospital);
	}
	
	@Override
	public HospitalModel findHospitalByHospitalCode(String hospitalCode) {
		List<Hospital> listHospital = this.hospitalRepository.findByHospitalCode(hospitalCode);
		if(CollectionUtils.isEmpty(listHospital)){
			return null;
		}
		Hospital hospital = listHospital.get(0);
		return hospital.toModel(mapper);
	}
	
	@Override
	public HospitalModel findHospital(Integer hospitalId) {
		HospitalModel hospitalModel = new HospitalModel();
		Hospital hospital = this.hospitalRepository
				.findHospital(hospitalId, ActiveFlag.ACTIVE.toInt());
		if(hospital != null){
			hospitalModel.setHospitalId(hospital.getHospitalId());
			hospitalModel.setHospitalCode(hospital.getHospitalCode());
			hospitalModel.setHospitalName(hospital.getHospitalName());
			hospitalModel.setHospitalNameFurigana(hospital.getHospitalNameFurigana());
			hospitalModel.setAddress(hospital.getAddress());
			hospitalModel.setEmail(hospital.getEmail());
			hospitalModel.setPhoneNumber(hospital.getPhoneNumber());
			hospitalModel.setHospitalIconPath(hospital.getHospitalIconPath());
		}
		return hospitalModel;
	}
	
	@Override
	public Integer updateHospital(HospitalModel hospitalModel) {
		Integer rowUpdated = this.hospitalRepository.updateHospitalInfo(hospitalModel);
		return rowUpdated;
	}
	@Override
	public HospitalDto getHospitalModelByHospitalCode(String hospitalCode) {
		List<HospitalDto> listHospital = this.hospitalRepository.getHospitalModelByHospitalCode(hospitalCode);
		if(CollectionUtils.isEmpty(listHospital)){
			return null;
		}
		return listHospital.get(0);
	}
	@Override
	public HospitalModel findHospitalByHospCodeAndLocate(String hospCode, String locale) {
		// TODO Auto-generated method stub
		HospitalModel hospitalModel = new HospitalModel();
		Hospital hospital = this.hospitalRepository.findHospitalByHospCodeAndLocate(hospCode, locale);
		if(hospital != null){
			hospitalModel.setHospitalId(hospital.getHospitalId());
			hospitalModel.setHospitalCode(hospital.getHospitalCode());
			hospitalModel.setHospitalName(hospital.getHospitalName());
			hospitalModel.setHospitalNameFurigana(hospital.getHospitalNameFurigana());
			hospitalModel.setAddress(hospital.getAddress());
			hospitalModel.setEmail(hospital.getEmail());
			hospitalModel.setPhoneNumber(hospital.getPhoneNumber());
			hospitalModel.setHospitalIconPath(hospital.getHospitalIconPath());
			hospitalModel.setIsUseMt(hospital.getIsUseMt());
			hospitalModel.setIsUseSms(hospital.getIsUseSms());
		}
		return hospitalModel;
	}
}
