package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import nta.mss.entity.Vaccine;
import nta.mss.info.BookingVaccineBackendInfo;
import nta.mss.info.ReminderBookingVaccineInfo;
import nta.mss.info.VaccineCdUsingInfo;
import nta.mss.info.VaccineDetailInfo;
import nta.mss.info.VaccineInfo;
import nta.mss.info.VaccineReportInfo;
import nta.mss.model.VaccineModel;
import nta.mss.repository.VaccineRepository;
import nta.mss.repository.VaccineRepositoryCustom;
import nta.mss.service.IVaccineService;

import org.apache.commons.collections.CollectionUtils;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * The Class VaccineSerivce.
 */
@Service 
public class VaccineService implements IVaccineService {

	/** The mapper. */
	private Mapper mapper;
	
	/** The vaccine repository. */
	private VaccineRepository vaccineRepository;
	
	/** The vaccine repository custom. */
	private VaccineRepositoryCustom vaccineRepositoryCustom;
	
	/**
	 * Instantiates a new vaccine serivce.
	 */
	public VaccineService() {
		
	}

	/**
	 * Instantiates a new vaccine serivce.
	 *
	 * @param mapper the mapper
	 * @param vaccineRepository the vaccine repository
	 */
	@Autowired	
	public VaccineService(Mapper mapper, VaccineRepository vaccineRepository, VaccineRepositoryCustom vaccineRepositoryCustom) {
		this.mapper = mapper;
		this.vaccineRepository = vaccineRepository;
		this.vaccineRepositoryCustom = vaccineRepositoryCustom;
	}

	@Override
	public VaccineModel findById(Integer vaccineId) {
		if (vaccineId == null) {
			return null;
		}
		
		Vaccine vaccine = this.vaccineRepository.findOne(vaccineId);
		if (vaccine != null) {
			return vaccine.toModel(mapper);
		}
		return null;
	}
	
	@Override
	public List<VaccineDetailInfo> getAllVaccineList(Integer childId, String hospitalCode) {
		List<VaccineDetailInfo> result = new ArrayList<>();
		result = this.vaccineRepositoryCustom.getAllVaccineList(childId, hospitalCode);
		return result;
	}
	
	@Override
	public List<VaccineDetailInfo> getVaccineBookingHistoryList(Integer childId, String hospitalCode) {
		List<VaccineDetailInfo> result = new ArrayList<>();
		result = this.vaccineRepositoryCustom.getVaccineHistoryList(childId, true, hospitalCode);
		return result;
	}
	
	@Override
	public List<VaccineDetailInfo> getVaccineUserHistoryList(Integer childId, String hospitalCode) {
		List<VaccineDetailInfo> result = new ArrayList<>();
		result = this.vaccineRepositoryCustom.getVaccineHistoryList(childId, false, hospitalCode);
		return result;
	}
	
	@Override
	public List<String> getAllHistoryVaccineList(List<VaccineDetailInfo> bookingHistoryList, List<VaccineDetailInfo> userHistoryList) {
		List<String> fullHistoryList = new ArrayList<String>();
		for (VaccineDetailInfo vaccineInfo : bookingHistoryList) {
			fullHistoryList.add(vaccineInfo.getVaccineId() + "_" + vaccineInfo.getInjectedNo());
		}
		for (VaccineDetailInfo vaccineInfo : userHistoryList) {
			fullHistoryList.add(vaccineInfo.getVaccineId() + "_" + vaccineInfo.getInjectedNo());
		}
		return fullHistoryList;
	}
	
	@Override
	public Map<String, VaccineCdUsingInfo> getVaccineCdUsingMap(Integer childId, String hospitalCode) {
		List<VaccineCdUsingInfo> list = this.vaccineRepositoryCustom.getVaccineCdUsingList(childId, hospitalCode);
		Map<String, VaccineCdUsingInfo> result = new HashMap<String, VaccineCdUsingInfo>();
		for (VaccineCdUsingInfo item : list) {
			result.put(item.getVaccineCd(), item);
		}
		return result;
	}
	
	@Override
	public List<ReminderBookingVaccineInfo> getReminderBookingVaccineInfo() {
		List<ReminderBookingVaccineInfo> result = new ArrayList<>();
		result = this.vaccineRepositoryCustom.getReminderBookingVaccineInfo();
		return result;
	}

	@Override
	public List<VaccineModel> findVaccineByActiveFlg(Integer activeFlg)
			throws Exception {
		List<VaccineModel> listVaccineModel = new ArrayList<VaccineModel>();
		List<Vaccine> listVaccine = this.vaccineRepository.findVaccineByActiveFlg(activeFlg);
		if (CollectionUtils.isNotEmpty(listVaccine)) {
			for (Vaccine vaccine : listVaccine) {
				listVaccineModel.add(vaccine.toModel(mapper));
			}
		}
		return listVaccineModel;
	}
	
	@Override
	public Map<VaccineReportInfo, VaccineReportInfo> getVaccineReportMap (Date fromDate, Date toDate, String hospitalCode){
		List<VaccineReportInfo> listVaccineReport = this.vaccineRepositoryCustom.getVaccineReport(fromDate, toDate, hospitalCode);
		Map<VaccineReportInfo, VaccineReportInfo> resultMap = new LinkedHashMap<VaccineReportInfo, VaccineReportInfo>();
		for (VaccineReportInfo vaccineReportInfo : listVaccineReport) {
			resultMap.put(vaccineReportInfo, vaccineReportInfo);
		}
		return resultMap;
	}

	@Override
	public List<VaccineModel> findVaccineByHospitalCode(String hospitalCode)
			throws Exception {
		List<VaccineModel> listVaccineModel = new ArrayList<VaccineModel>();
		List<Vaccine> listVaccine = this.vaccineRepository.findVaccineByHospitalCode(hospitalCode);
		if (CollectionUtils.isNotEmpty(listVaccine)) {
			for (Vaccine vaccine : listVaccine) {
				listVaccineModel.add(vaccine.toModel(mapper));
			}
		}
		return listVaccineModel;
	}
	
	@Override
	public List<BookingVaccineBackendInfo> getInformationVaccine(Integer vaccineId, Integer childId) throws Exception {
		List<BookingVaccineBackendInfo> lstInfoVaccine = this.vaccineRepositoryCustom.getInformationVaccine(vaccineId, childId);
		return lstInfoVaccine;
	}	
	
	@Override
	public List<VaccineInfo> getVaccineInfoList(String hospitalId, String locale) {
		List<VaccineInfo> vaccineInfoList = this.vaccineRepositoryCustom.getVaccineInfoList(null, hospitalId, locale);
		return vaccineInfoList;
	}
	
	@SuppressWarnings("null")
	@Override
	public VaccineInfo getVaccineInfoById (Integer vaccineId, String hospitalCode) {
		List<VaccineInfo> vaccineInfoList = this.vaccineRepositoryCustom.getVaccineInfoList(vaccineId, hospitalCode, null);
		VaccineInfo vaccineInfo = null;
		if (vaccineInfoList != null || vaccineInfoList.size() != 0) {
			vaccineInfo = vaccineInfoList.get(0);
		}
		return vaccineInfo;
	}
}
