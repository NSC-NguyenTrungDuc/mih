package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.List;

import nta.mss.entity.VaccineHospital;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.model.VaccineHospitalModel;
import nta.mss.repository.VaccineHospitalRepository;
import nta.mss.service.IVaccineHospitalService;

import org.apache.commons.collections.CollectionUtils;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

/**
 * The Class VaccineHospitalService.
 */
@Service
@Transactional
public class VaccineHospitalService implements IVaccineHospitalService {

	/** The mapper. */
	private Mapper mapper;
	
	/** The vaccine hospital repository. */
	private VaccineHospitalRepository vaccineHospitalRepository;
	
	/**
	 * Instantiates a new vaccine hospital service.
	 */
	public VaccineHospitalService() {
		
	};
	
	/**
	 * Instantiates a new vaccine hospital service.
	 *
	 * @param vaccineHospitalRepository the vaccine hospital repository
	 */
	@Autowired
	public VaccineHospitalService(Mapper mapper,
			VaccineHospitalRepository vaccineHospitalRepository) {
		this.mapper = mapper;
		this.vaccineHospitalRepository = vaccineHospitalRepository;
	}

	@Override
	public List<VaccineHospitalModel> getVaccineHospital(Integer hospitalId) throws Exception {
		List<VaccineHospitalModel> lstVaccineHospitalModels = new ArrayList<VaccineHospitalModel>();
		List<VaccineHospital> lstVaccineHospital = this.vaccineHospitalRepository.getVaccineHospitalByHospitalId(hospitalId);
		if (CollectionUtils.isNotEmpty(lstVaccineHospital)) {
			for (VaccineHospital vaccineHospital : lstVaccineHospital) {
				VaccineHospitalModel vaccineHospitalModel = vaccineHospital.toModel(mapper);
				if (vaccineHospitalModel.getFromDate() != null) {
					vaccineHospitalModel.setStrFromDate(MssDateTimeUtil.convertTimestampToString(vaccineHospitalModel.getFromDate(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
				}
				if (vaccineHospital.getToDate() != null) {
					vaccineHospitalModel.setStrToDate(MssDateTimeUtil.convertTimestampToString(vaccineHospitalModel.getToDate(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
				}
				lstVaccineHospitalModels.add(vaccineHospitalModel);
			}
		}
		return lstVaccineHospitalModels;
	}

	@Override
	public VaccineHospitalModel findById(Integer VaccineHospitalId) throws Exception {
		VaccineHospital vaccineHospital = this.vaccineHospitalRepository.findOne(VaccineHospitalId);
		
		return vaccineHospital.toModel(mapper);
	}

	@Override
	public void saveVaccineHospital(VaccineHospitalModel vaccineHospitalModel) throws Exception {
		VaccineHospital vaccineHospital = vaccineHospitalModel.toEntity(mapper);
		this.vaccineHospitalRepository.save(vaccineHospital);
	}
	
	public void deleteVaccineHospital(VaccineHospitalModel vaccineHospitalModel) throws Exception {
		VaccineHospital vaccineHospital = vaccineHospitalModel.toEntity(mapper);
		vaccineHospital.setActiveFlg(ActiveFlag.INACTIVE.toInt());
		this.vaccineHospitalRepository.save(vaccineHospital);
	}

	@Override
	public VaccineHospitalModel findByHospitalIdVaccineId(
			Integer hospitalId, Integer vaccineId) throws Exception {
		if (hospitalId == null || vaccineId == null) {
			return null;
		}
		List<VaccineHospital> lstVaccineHospital = this.vaccineHospitalRepository.findByVaccineIdHospitalId(vaccineId, hospitalId);
//		VaccineHospital vaccineHospital = this.vaccineHospitalRepository.findByVaccineIdHospitalId(vaccineId, hospitalId);
		if (CollectionUtils.isEmpty(lstVaccineHospital)) {
			return null;
		}
		VaccineHospital vaccineHospital = lstVaccineHospital.get(0);
		return vaccineHospital.toModel(mapper);
	}

}
