package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.Query;

import org.apache.commons.codec.language.bm.Languages;
import org.dozer.Mapper;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.mss.entity.Doctor;
import nta.mss.entity.Hospital;
import nta.mss.entity.MovieTalkHistory;
import nta.mss.entity.MtHistory;
import nta.mss.entity.Patient;
import nta.mss.entity.Reservation;
import nta.mss.model.MtHistoryModel;
import nta.mss.repository.MovieTalkRepository;
import nta.mss.service.IMovieTalkService;

/**
 * 
 * @author TungLT
 * MovieTalkService
 */

@Service
@Transactional
public class MovieTalkService implements IMovieTalkService{
	
	private MovieTalkRepository movietalkRepository;
	private EntityManager entityManager;
    public MovieTalkService() {
		// TODO Auto-generated constructor stub
	}
    
    @Autowired
    public MovieTalkService(Mapper mapper,MovieTalkRepository movietalkRepository)
    {
    	this.movietalkRepository = movietalkRepository;
    	
    }
	
    
	@Override
	public List<MovieTalkHistory> getListMovieTalkHistory(Integer hospId, String cardNumber, Integer startIndex,
			Integer pageSize,String columnSort, String typeOrder) {
		// TODO Auto-generated method stub
		List<MovieTalkHistory> result = new ArrayList<>();
		result = movietalkRepository.getListMovieTalkHistory(hospId, cardNumber, startIndex, pageSize,columnSort,typeOrder);
		return result;
	}
	
	@Override
	public Integer getTotalRecordMovieTalkHistoryByHospIdAndPatientId(Integer hospId, String cardNumber) {
		// TODO Auto-generated method stub
		Integer result = movietalkRepository.getTotalRecordMovieTalkHistoryByHospIdAndPatientId(hospId, cardNumber);
		return result;
	}
	

	@Override
	public Integer deleteRecordMovieTalkHistoryById(Integer mtHistoryId) {
		// TODO Auto-generated method stub
		Integer result = movietalkRepository.deleteRecordMovieTalkHistoryById(mtHistoryId);
		return result;
	}

	@Override
	public boolean insertRecordMovieTalkHistoryById(MtHistoryModel mtHistoryModel) {		
		MtHistory mtHistory = new MtHistory();
		try {			
		
			Doctor doctor = new Doctor();
			doctor.setDoctorId(mtHistoryModel.getDoctorId());
			Date date = new Date();
			mtHistory.setCreated(date);
			mtHistory.setUpdated(date);		
			mtHistory.setDoctor(doctor);	
			
			Hospital hospital = new Hospital();
			hospital.setHospitalId(mtHistoryModel.getHospitalId());
			
			Patient patient = new Patient();
			patient.setPatientId(mtHistoryModel.getPatientId());
			
			Reservation reservation = new Reservation();
			reservation.setReservationId(mtHistoryModel.getReservationId());
			
			mtHistory.setPatient(patient);
			mtHistory.setHospital(hospital);
			mtHistory.setReservation(reservation);
			mtHistory.setReservationDate(mtHistoryModel.getReservationDate());
			mtHistory.setReservationTime(mtHistoryModel.getReservationTime());
			mtHistory.setDuration(mtHistoryModel.getDuration());
			mtHistory.setMtHistoryUrl(mtHistoryModel.getMtHistoryUrl());
			mtHistory.setActiveFlag(1);
			
			movietalkRepository.save(mtHistory);
			
			
			return  true;
		} catch (Exception e) {
			return false;
		}	
	}
	
	
}
