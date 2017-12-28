package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import nta.mss.entity.Reservation;
import nta.mss.entity.VaccineChildHistory;
import nta.mss.info.ReservationInfo;
import nta.mss.info.VaccineChildHistoryInfo;
import nta.mss.model.ReservationModel;
import nta.mss.model.VaccineChildHistoryModel;
import nta.mss.repository.ReservationRepository;
import nta.mss.repository.VaccineChildHistoryRepository;
import nta.mss.repository.VaccineChildHistoryRepositoryCustom;
import nta.mss.service.IVaccineChildHistoryService;

import org.apache.commons.collections.CollectionUtils;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

/**
 * The Class VaccineChildHistoryService.
 */
@Service
@Transactional
public class VaccineChildHistoryService implements IVaccineChildHistoryService {

	/** The mapper. */
	private Mapper mapper;
	
	/** The vaccine child history repository. */
	private VaccineChildHistoryRepository vaccineChildHistoryRepository;
	
	private VaccineChildHistoryRepositoryCustom vaccineChildHistoryRepositoryCustom;
	
	private ReservationRepository reservationRepository;
	
	VaccineChildHistoryService() {
		
	}

	@Autowired
	public VaccineChildHistoryService(Mapper mapper,
			VaccineChildHistoryRepository vaccineChildHistoryRepository, VaccineChildHistoryRepositoryCustom vaccineChildHistoryRepositoryCustom, ReservationRepository reservationRepository) {
		this.mapper = mapper;
		this.vaccineChildHistoryRepository = vaccineChildHistoryRepository;
		this.vaccineChildHistoryRepositoryCustom = vaccineChildHistoryRepositoryCustom;
		this.reservationRepository = reservationRepository;
	}

	@Override
	public List<VaccineChildHistoryModel> findChildHistoryByChildId(Integer childId,
			Integer vaccineGroupId) throws Exception {
		List<VaccineChildHistoryModel> lsChildHistoryModel = new ArrayList<VaccineChildHistoryModel>();
		if (childId == null || vaccineGroupId == null) {
			return lsChildHistoryModel;
		}
		List<VaccineChildHistory> lstVaccineChildHistory = this.vaccineChildHistoryRepository.findByVaccineIdAndChildId(childId, vaccineGroupId);
		if (CollectionUtils.isNotEmpty(lstVaccineChildHistory)) {
			for (VaccineChildHistory childHistory : lstVaccineChildHistory) {
				lsChildHistoryModel.add(childHistory.toModel(mapper));
			}
		}
		return lsChildHistoryModel;
	}
	
	@Transactional
	public void save(VaccineChildHistoryModel childHistoryModel) throws Exception {
		this.vaccineChildHistoryRepository.save(childHistoryModel.toEntity(mapper));
	}

	@Override
	public VaccineChildHistoryModel findByReservationId(Integer reservationId)
			throws Exception {
		if (reservationId == null) {
			return null;
		} 
		VaccineChildHistory vaccineChildHistory = this.vaccineChildHistoryRepository.findByReservationId(reservationId);
		if (vaccineChildHistory != null) {
			return vaccineChildHistory.toModel(mapper);
		}
		return null;
	}
	
	public VaccineChildHistoryModel findByVaccineIdChildIdReservationId (Integer reservationId, Integer vaccineId, Integer childId) throws Exception {
		if (reservationId == null || vaccineId == null || childId == null) {
			return null;
		}
		VaccineChildHistory vaccineChildHistory = this.vaccineChildHistoryRepository.findByVaccineIdChildIdReservationId(reservationId, vaccineId, childId);
		if (vaccineChildHistory != null) {
			return vaccineChildHistory.toModel(mapper);
		}
		return null;
	}

	@Override
	public List<VaccineChildHistoryInfo> findVaccineChildHistoryInfoByChildId(
			Integer childId) throws Exception {
		List<VaccineChildHistoryInfo> lstVaccineChildHistoryInfo = this.vaccineChildHistoryRepositoryCustom.getListVaccineChildHistory(childId);
		return lstVaccineChildHistoryInfo;
	}

	@Override
	public VaccineChildHistoryInfo getListVaccineChildHistoryById(
			Integer vaccineChildId) throws Exception {
		
		return this.vaccineChildHistoryRepositoryCustom.getListVaccineChildHistoryById(vaccineChildId);
	}

	@Override 
	public VaccineChildHistoryModel findById(Integer vaccinceChildId)
			throws Exception {
		VaccineChildHistory vaccineChildHistory = this.vaccineChildHistoryRepository.findOne(vaccinceChildId);
		return vaccineChildHistory.toModel(mapper);
	}

	@Override
	public List<VaccineChildHistoryModel> findByChildId(Integer childId)
			throws Exception {
		List<VaccineChildHistoryModel> lstChildHistoryModel = new ArrayList<VaccineChildHistoryModel>();
		List<VaccineChildHistory> lstChilVaccineChildHistories = this.vaccineChildHistoryRepository.findByChildId(childId);
		if (CollectionUtils.isNotEmpty(lstChilVaccineChildHistories)) {
			for (VaccineChildHistory vaccineChildHistory : lstChilVaccineChildHistories) {
				lstChildHistoryModel.add(vaccineChildHistory.toModel(mapper));
			}
		}
		return lstChildHistoryModel;
	}
	
	public ReservationModel findReservationById(Integer reservationId) {
		Reservation reservation = this.reservationRepository.findOne(reservationId);
		if (reservation != null) {
			return reservation.toModel(mapper);
		}
		return null;
	}
	
	public VaccineChildHistoryModel findByVaccineIdInjectedNo(Integer vaccineId, Integer childId, Integer injectedNo) throws Exception {
		List<VaccineChildHistory> vaccineChildHistorys = this.vaccineChildHistoryRepository.findByVaccineIdInjectedNo(vaccineId, childId, injectedNo);
		if (CollectionUtils.isNotEmpty(vaccineChildHistorys)) {
			return vaccineChildHistorys.get(0).toModel(mapper);
		}
		return null;
	}

	@Override
	public List<VaccineChildHistoryModel> findByUserIdChildId(Integer userId,
			Integer childId) throws Exception {
		List<VaccineChildHistoryModel> lstVaccineChildHistoryModel = new ArrayList<VaccineChildHistoryModel>();
		List<VaccineChildHistory> lstVaccineChildHistory = this.vaccineChildHistoryRepository.findByUserIdChildId(userId, childId);
		if (CollectionUtils.isNotEmpty(lstVaccineChildHistory)) {
			for (VaccineChildHistory vaccineChildHistory : lstVaccineChildHistory) {
				lstVaccineChildHistoryModel.add(vaccineChildHistory.toModel(mapper));
			}
		}
		return lstVaccineChildHistoryModel;
	}

	@Override
	public Integer getMaxInjectedNo(Integer vaccineId, Integer childId)
			throws Exception {
		return this.vaccineChildHistoryRepositoryCustom.getMaxInjectedNo(vaccineId, childId);
	}
	
	public List<VaccineChildHistoryModel> findByVaccineId(Integer vaccineId) throws Exception {
		List<VaccineChildHistoryModel> lstVaccineChildHistoryModel = new ArrayList<VaccineChildHistoryModel>();
		List<VaccineChildHistory> lstVaccineChildHistory = this.vaccineChildHistoryRepository.findByVaccineId(vaccineId);
		if (CollectionUtils.isNotEmpty(lstVaccineChildHistory)) {
			for (VaccineChildHistory vaccineChildHistory : lstVaccineChildHistory) {
				lstVaccineChildHistoryModel.add(vaccineChildHistory.toModel(mapper));
			}
		}
		return lstVaccineChildHistoryModel;
	}
	
	public List<ReservationInfo> findReservationInfoByChildId(Integer childId) throws Exception {
		return reservationRepository.searchReservationInfoByChildId(childId);
	}
 }
