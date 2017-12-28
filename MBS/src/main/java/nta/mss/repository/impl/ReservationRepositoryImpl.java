package nta.mss.repository.impl;

import java.math.BigInteger;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;

import nta.kcck.info.KcckReservationInfo;
import nta.mss.entity.InsuranceHistory;
import nta.mss.entity.Reservation;
import nta.mss.info.ReminderReservationCheduleInfo;
import nta.mss.info.ReservationInfo;
import nta.mss.info.ReservationOnlineInfo;
import nta.mss.jpa.mapper.JpaResultMapper;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.model.ReservationModel;
import nta.mss.repository.ReservationRepositoryCustom;

/**
 * CustomReservationRepository.java
 *
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 *
 */
public class ReservationRepositoryImpl implements ReservationRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	/**
	 * Search by condition.
	 *
	 * @param reservationModel
	 *            the reservation model
	 * @return the list
	 */
	@Override
	@SuppressWarnings({ "unchecked" })
	public List<Reservation> searchByCondition(ReservationModel reservationModel) {
		Map<String, Object> params = new HashMap<String, Object>();
		StringBuilder sql = new StringBuilder("SELECT r FROM Reservation r WHERE r.activeFlg = 1");

		if (reservationModel != null) {
			if (StringUtils.isNotBlank(reservationModel.getEmail())) {
				sql.append(" AND lower(r.email) like :email");
				String email = reservationModel.getEmail().replaceAll("(^\\p{Z}+|\\p{Z}+$)", "");
				params.put("email", "%" + email.trim().toLowerCase() + "%");
			}
			if (StringUtils.isNotBlank(reservationModel.getPatientName())) {
				sql.append(" AND lower(r.patientName) like :patientName");
				String patientName = reservationModel.getPatientName().replaceAll("(^\\p{Z}+|\\p{Z}+$)", "");
				params.put("patientName", "%" + patientName.trim().toLowerCase() + "%");
			}
			if (StringUtils.isNotBlank(reservationModel.getNameFurigana())) {
				sql.append(" AND lower(r.nameFurigana) like :nameFurigana");
				String nameFurigane = reservationModel.getNameFurigana().replaceAll("(^\\p{Z}+|\\p{Z}+$)", "");
				params.put("nameFurigana", "%" + nameFurigane.trim().toLowerCase() + "%");
			}
			if (reservationModel.getHospitalId() != null && !reservationModel.getHospitalId().equals(-1)) {
				sql.append(" AND r.hospital.hospitalId = :hospitalId");
				params.put("hospitalId", reservationModel.getHospitalId());
			}
			if (reservationModel.getDeptId() != null && !reservationModel.getDeptId().equals(-1)) {
				sql.append(" AND r.department.deptId = :deptId");
				params.put("deptId", reservationModel.getDeptId());
			}
			if (StringUtils.isNotBlank(reservationModel.getReservationFromDate())) {
				sql.append(" AND r.reservationDate >= :fromDate");
				params.put("fromDate", reservationModel.getReservationFromDate());
			}
			if (StringUtils.isNotBlank(reservationModel.getReservationToDate())) {
				sql.append(" AND r.reservationDate <= :toDate");
				params.put("toDate", reservationModel.getReservationToDate());
			}
		}

		Query query = entityManager.createQuery(sql.toString());
		for (Map.Entry<String, Object> entry : params.entrySet()) {
			query.setParameter(entry.getKey(), entry.getValue());
		}
		return query.getResultList();
	}

	/**
	 * Update doctor reservation by id.
	 *
	 * @param reservationMap
	 *            the reservation map
	 * @return true, if successful
	 */
	@Override
	public boolean updateDoctorReservationById(Map<Integer, Integer> reservationMap) {
		Map<String, Object> params = new HashMap<String, Object>();
		StringBuilder sql = new StringBuilder(
				"UPDATE Reservation r SET r.doctor.doctorId = :doctorId WHERE r.reservationId = :reservationId");
		Query query = entityManager.createQuery(sql.toString());
		Integer entryKey;
		Integer entryValue;
		for (Entry<Integer, Integer> entryReservation : reservationMap.entrySet()) {
			entryKey = entryReservation.getKey();
			entryValue = entryReservation.getValue();
			params.put("doctorId", entryValue);
			params.put("reservationId", entryKey);
			for (Map.Entry<String, Object> entry : params.entrySet()) {
				query.setParameter(entry.getKey(), entry.getValue());
			}
			if (query.executeUpdate() == 0)
				return false;
		}
		return true;
	}

	/**
	 * Search info schedule mail history.
	 *
	 * @param deptId
	 *            the dept id
	 * @param fromDate
	 *            the from date
	 * @param toDate
	 *            the to date
	 * @return the list
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Object[]> searchInfoScheduleMailHistory(Integer deptId, Date fromDate, Date toDate) {
		Map<String, Object> params = new HashMap<String, Object>();
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT r.doctor.doctorId, r.doctor.name, r.reservationDate, r.reservationTime, r.patientName,");
		sql.append(" r.email, r.phoneNumber, m.readingFlg, m.sendingStatus, m.subject");
		sql.append(" FROM Reservation r inner join r.mailSendings m WHERE 1=1 ");
		if (deptId != -1) {
			sql.append(" AND r.department.deptId = :deptId");
			params.put("deptId", deptId);
		}
		if (fromDate != null) {
			sql.append(" AND m.created >= :fromDate");
			params.put("fromDate", fromDate);
		}
		if (toDate != null) {
			sql.append(" AND m.created <= :toDate");
			params.put("toDate", MssDateTimeUtil.getTimeEndDate(toDate));
		}

		sql.append(
				" AND r.reservationStatus IN (0, 1, 2, 3, 4, 5) AND r.activeFlg = 1 order by r.doctor.name, r.reservationTime");
		Query query = entityManager.createQuery(sql.toString());
		for (Map.Entry<String, Object> entry : params.entrySet()) {
			query.setParameter(entry.getKey(), entry.getValue());
		}
		return query.getResultList();
	}

	/**
	 * Update doctor for reservation.
	 *
	 * @param doctorId
	 *            the doctor id
	 * @param reservationId
	 *            the reservation id
	 */
	@Override
	public void updateDoctorForReservation(Integer doctorId, Integer reservationId) {
		Map<String, Object> params = new HashMap<String, Object>();
		params.put("doctorId", doctorId);
		params.put("reservationId", reservationId);
		StringBuilder sql = new StringBuilder(
				"UPDATE Reservation r SET r.doctor.doctorId = :doctorId WHERE r.reservationId = :reservationId");
		Query query = entityManager.createQuery(sql.toString());
		for (Map.Entry<String, Object> entry : params.entrySet()) {
			query.setParameter(entry.getKey(), entry.getValue());
		}

		query.executeUpdate();
	}

	@Override
	public List<ReservationInfo> searchReservationInfoByCondition(ReservationModel reservationModel) {
		Map<String, Object> params = new HashMap<String, Object>();
		// StringBuilder sql = new StringBuilder("SELECT r FROM Reservation r
		// WHERE r.activeFlg = 1");
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                                                    ");
		sql.append(" 	p.child_id AS bookingNewbornsChildId,                                  ");
		sql.append(" 	v.child_id AS childId,                                                 ");
		sql.append(" 	v.vaccine_child_id AS vaccineChildId,                                  ");
		sql.append(" 	v.injected_no AS injectedNo,                                     	   ");
		sql.append(" 	v.vaccine_id AS vaccineId,                                             ");
		sql.append(" 	r.reservation_id AS reservationId,                                     ");
		sql.append(" 	r.active_flg AS activeFlg,                                             ");
		sql.append(" 	r.dept_id AS deptId,                                                   ");
		sql.append(" 	r.dept_name AS deptName,                                               ");
		sql.append(" 	r.doctor_id AS doctorId,                                               ");
		sql.append(" 	r.email AS email,                                                      ");
		sql.append(" 	r.hospital_id AS hospitalId,                                           ");
		sql.append(" 	r.name_furigana AS nameFurigana,                                       ");
		sql.append(" 	r.patient_id AS patientId,                                             ");
		sql.append(" 	r.patient_name AS patientName,                                         ");
		sql.append(" 	r.phone_number AS phoneNumber,                                         ");
		sql.append(" 	r.reg_user AS regUser,                                                 ");
		sql.append(" 	r.reminder_time AS reminderTime,                                       ");
		sql.append(" 	r.reservation_code AS reservationCode,                                 ");
		sql.append(" 	r.reservation_date AS reservationDate,                                 ");
		sql.append(" 	r.reservation_status AS reservationStatus,                             ");
		sql.append(" 	r.reservation_time AS reservationTime,                                 ");
		sql.append(" 	p.card_number AS patientCode		                                  ");
		sql.append(" FROM                                                                      ");
		sql.append(" 	reservation r                                                          ");
		sql.append(" LEFT JOIN patient p ON r.patient_id = p.patient_id	and r.hospital_id = p.hospital_id					   ");
		sql.append(" LEFT JOIN vaccine_child_history v ON r.reservation_id = v.reservation_id  ");
		// sql.append(" AND v.active_flg = 1 ");
		sql.append(" WHERE r.active_flg = 1                                                    ");
		sql.append(" 	AND p.active_flg = 1                                                   ");
		if (reservationModel != null) {
			if (StringUtils.isNotBlank(reservationModel.getEmail())) {
				sql.append(" AND lower(r.email) like :email");
				String email = reservationModel.getEmail().replaceAll("(^\\p{Z}+|\\p{Z}+$)", "");
				params.put("email", "%" + email.trim().toLowerCase() + "%");
			}
			if (StringUtils.isNotBlank(reservationModel.getPatientName())) {
				sql.append(" AND lower(r.patient_name) like :patientName");
				String patientName = reservationModel.getPatientName().replaceAll("(^\\p{Z}+|\\p{Z}+$)", "");
				params.put("patientName", "%" + patientName.trim().toLowerCase() + "%");
			}
			if (StringUtils.isNotBlank(reservationModel.getNameFurigana())) {
				sql.append(" AND lower(r.name_furigana) like :nameFurigana");
				String nameFurigane = reservationModel.getNameFurigana().replaceAll("(^\\p{Z}+|\\p{Z}+$)", "");
				params.put("nameFurigana", "%" + nameFurigane.trim().toLowerCase() + "%");
			}
			if (reservationModel.getHospitalId() != null && !reservationModel.getHospitalId().equals(-1)) {
				sql.append(" AND r.hospital_id = :hospitalId");
				params.put("hospitalId", reservationModel.getHospitalId());
			}
			if (reservationModel.getDeptId() != null && !reservationModel.getDeptId().equals(-1)) {
				sql.append(" AND r.dept_id = :deptId");
				params.put("deptId", reservationModel.getDeptId());
			}
			if (StringUtils.isNotBlank(reservationModel.getReservationFromDate())) {
				sql.append(" AND r.reservation_date >= :fromDate");
				params.put("fromDate", reservationModel.getReservationFromDate());
			}
			if (StringUtils.isNotBlank(reservationModel.getReservationToDate())) {
				sql.append(" AND r.reservation_date <= :toDate");
				params.put("toDate", reservationModel.getReservationToDate());
			}
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		for (Map.Entry<String, Object> entry : params.entrySet()) {
			query.setParameter(entry.getKey(), entry.getValue());
		}
		List<ReservationInfo> list = new JpaResultMapper().list(query, ReservationInfo.class);
		return list;
	}

	/**
	 * Search reservation info by child id.
	 *
	 * @param childId
	 *            the child id
	 * @return the list
	 */
	public List<ReservationInfo> searchReservationInfoByChildId(Integer childId) {

		if (childId == null) {
			return null;
		}
		Map<String, Object> params = new HashMap<String, Object>();
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                                                  							");
		sql.append(" 	p.child_id AS bookingNewbornsChildId,                                							");
		sql.append(" 	v.child_id AS childId,                                               							");
		sql.append(" 	v.vaccine_child_id AS vaccineChildId,                                							");
		sql.append(" 	v.injected_no AS injectedNo,                                     	 							");
		sql.append(" 	v.vaccine_id AS vaccineId,                                           							");
		sql.append(" 	r.reservation_id AS reservationId,                                   							");
		sql.append(" 	r.active_flg AS activeFlg,                                           							");
		sql.append(" 	r.dept_id AS deptId,                                                 							");
		sql.append(" 	r.dept_name AS deptName,                                             							");
		sql.append(" 	r.doctor_id AS doctorId,                                             							");
		sql.append(" 	r.email AS email,                                                    							");
		sql.append(" 	r.hospital_id AS hospitalId,                                         							");
		sql.append(" 	r.name_furigana AS nameFurigana,                                     							");
		sql.append(" 	r.patient_id AS patientId,                                           							");
		sql.append(" 	r.patient_name AS patientName,                                       							");
		sql.append(" 	r.phone_number AS phoneNumber,                                       							");
		sql.append(" 	r.reg_user AS regUser,                                               							");
		sql.append(" 	r.reminder_time AS reminderTime,                                     							");
		sql.append(" 	r.reservation_code AS reservationCode,                               							");
		sql.append(" 	r.reservation_date AS reservationDate,                               							");
		sql.append(" 	r.reservation_status AS reservationStatus,                           							");
		sql.append(" 	r.reservation_time AS reservationTime,                               							");
		sql.append(" 	p.card_number AS patientCode		                                							 ");
		sql.append(" FROM                                                												  ");
		sql.append(" 	reservation r                                     													");
		sql.append(" LEFT JOIN patient p ON r.patient_id = p.patient_id and r.hospital_id = p.hospital_id  					");
		sql.append(" LEFT JOIN vaccine_child_history v ON r.reservation_id = v.reservation_id 						   ");
		sql.append(" LEFT JOIN user_child u ON u.child_id = p.child_id    												");
		sql.append(" WHERE r.active_flg = 1                               												");
		sql.append(" 	AND p.active_flg = 1                             												");
		sql.append(" 	AND r.reservation_status != 5                     												");
		sql.append(" 	AND p.child_id = :childId                         												");
		params.put("childId", childId);

		Query query = entityManager.createNativeQuery(sql.toString());
		for (Map.Entry<String, Object> entry : params.entrySet()) {
			query.setParameter(entry.getKey(), entry.getValue());
		}
		List<ReservationInfo> list = new JpaResultMapper().list(query, ReservationInfo.class);
		return list;
	}

	@Override
	public List<ReminderReservationCheduleInfo> getReminderReservationCcheduleInfo(String schedulerTiming,
			String serverTimeZone) {
		StringBuilder sql = new StringBuilder();
		sql.append(
				" 	SELECT                            							              										     	    						 					");
		sql.append(
				" 	a.patient_name,                                                             										 		 											");
		sql.append(
				" 	a.reminder_time,                                                            										 		 											");
		sql.append(
				" 	a.reservation_code,                                                         										 		 											");
		sql.append(
				" 	a.depart_code,                                                                										 		 											");
		sql.append(
				" 	a.dept_name,                                                                										 		 											");
		sql.append(
				" 	a.reservation_date,                                                         										 		 											");
		sql.append(
				" 	a.reservation_time,                                                         										 		 											");
		sql.append(
				" 	a.email,                                                          			  										 		 											");
		sql.append(
				" 	b.hospital_name,                                                          			  								 												  	");
		sql.append(
				" 	b.locale,                                                          			  								 		 													");
		sql.append(
				" 	a.hospital_id,                                                      			  										 												");
		sql.append(
				" 	b.email hospitalEmail,                                                      			  																				");
		sql.append(
				" 	a.phone_number,                                                      			  										 												");
		sql.append(
				" 	p.card_number                                                     			  										 													");
		sql.append(
				" 	FROM reservation a inner join hospital b                                       																							");
		sql.append(
				" 	 ON a.hospital_id = b.hospital_id                                                     																					");
		sql.append(
				"  	inner join patient p                                                     																								");
		sql.append(
				" 	 ON a.patient_id = p.patient_id                                                     																					");
		sql.append(
				" 	WHERE a.active_flg = '1'                                                      										 		 											");
		sql.append(
				" 	AND a.reservation_status = '1'                                               										 		 											");
		sql.append(
				" 	 AND CONVERT_TZ(STR_TO_DATE(CONCAT(a.reservation_date, a.reservation_time),'%Y%m%d%H%i'), CONCAT(IF(b.time_zone > 0, '+', '-'), b.time_zone, ':00'), :serverTimeZone) 	");
		sql.append(
				" 	 >= DATE_ADD(Now(), INTERVAL (a.reminder_time) MINUTE)                    	     																						");
		sql.append(
				" 	AND CONVERT_TZ(STR_TO_DATE(CONCAT(a.reservation_date, a.reservation_time),'%Y%m%d%H%i'), CONCAT(IF(b.time_zone > 0, '+', '-'), b.time_zone, ':00'), :serverTimeZone)  	");
		sql.append(
				" 	< Date_add(Now(), INTERVAL (a.reminder_time + :schedulerTiming/60000) MINUTE)																							");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("schedulerTiming", schedulerTiming);
		query.setParameter("serverTimeZone", serverTimeZone);

		List<ReminderReservationCheduleInfo> list = new JpaResultMapper().list(query,
				ReminderReservationCheduleInfo.class);
		return list;
	}

	@Override
	public KcckReservationInfo findKcckReservationBySessionId(String sessionId) {
		StringBuilder sql = new StringBuilder();
		sql.append(
				" SELECT                            							              										     	     	");
		sql.append(
				" 	r.reservation_id AS reservationId,                         							              					       	");
		sql.append(
				" 	r.hospital_id AS hospitalId,                            							              				 	     	");
		sql.append(
				" 	r.dept_id AS deptId,                            							              						   	     	");
		sql.append(
				" 	r.doctor_id AS doctorId,                            							    							   	     	");
		sql.append(
				" 	r.patient_id AS patientId,                            							    						     	     	");
		sql.append(
				" 	r.patient_name AS patientName,                            													     	     	");
		sql.append(
				" 	r.name_furigana AS nameFurigana,                            												     	     	");
		sql.append(
				" 	r.phone_number AS phoneNumber,                            													     	     	");
		sql.append(
				" 	r.email AS email,                            							          							     	     	");
		sql.append(
				" 	r.reservation_date AS reservationDate,                           				  							     	     	");
		sql.append(
				" 	r.reservation_time AS reservationTime,                            			      							     	     	");
		sql.append(
				" 	r.session_id AS sessionId,                           					          							     	     	");
		sql.append(
				" 	r.reservation_code AS reservationCode,             							      							     	     	");
		sql.append(
				" 	r.reminder_time AS reminderTime,             							      							     	  		   	");
		sql.append(
				" 	r.doctor_name AS doctorName,             							      							     	    		 	");
		sql.append(
				" 	r.doctor_code AS doctorCode,              							      							     	   				");
		sql.append(
				" 	r.dept_name AS deptName,             							      							     	     				");
		sql.append(
				" 	r.depart_code AS deptCode,        						      							     						     	");
		sql.append(
				" 	t.card_number AS patientCode,                 							              								     	");
		sql.append(
				" 	t.sex AS patientGender,                 							              								  		   	");
		sql.append(
				" 	t.dob AS patientBirthDay                 							              									     	");
		sql.append(
				" FROM reservation r, patient t    							              										     	     	");
		sql.append(
				" WHERE r.patient_id = t.patient_id and r.hospital_id = t.hospital_id						              						");
		sql.append(
				" AND session_id = :sessionId                           							              								    ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("sessionId", sessionId);
		List<KcckReservationInfo> list = new JpaResultMapper().list(query, KcckReservationInfo.class);
		if (CollectionUtils.isNotEmpty(list)) {
			return list.get(0);
		}
		return null;

	}

	@Override
	public List<KcckReservationInfo> findKcckReservationByPatientId(Integer patientId, Integer hospitalId,
			Integer limit) {
		StringBuilder sql = new StringBuilder();
		sql.append(
				"SELECT                            							              										    	   	");
		sql.append(
				"  	r.reservation_id AS reservationId,           					              									       	");
		sql.append(
				"  	r.hospital_id AS hospitalId,                 					              								 	     	");
		sql.append(
				"  	r.dept_id AS deptId,                         				              									   	     	");
		sql.append(
				"  	r.doctor_id AS doctorId,                     					              										    ");
		sql.append(
				"  	r.patient_id AS patientId,                   					              							     	     	");
		sql.append(
				"  	r.patient_name AS patientName,               					              							     	     	");
		sql.append(
				"  	r.name_furigana AS nameFurigana,             						           								     	    ");
		sql.append(
				"  	r.phone_number AS phoneNumber,               					     									     	     	");
		sql.append(
				"  	r.email AS email,                            				             									     	   	");
		sql.append(
				"  	r.reservation_date AS reservationDate,       			           										     	     	");
		sql.append(
				"  	r.reservation_time AS reservationTime,       		              										     	     	");
		sql.append(
				"  	r.session_id AS sessionId,                   			              										     	   	");
		sql.append(
				"  	r.reservation_code AS reservationCode,       			              										     	    ");
		sql.append(
				" 	r.reminder_time AS reminderTime,             							      							     	     	");
		sql.append(
				" 	r.doctor_name AS doctorName,      							      							     	     	");
		sql.append(
				" 	r.doctor_code AS doctorCode,       							      							     	     	");
		sql.append(
				" 	r.dept_name AS deptName,          							      							     	     	");
		sql.append(
				" 	r.depart_code AS deptCode,        						      							     					     	");
		sql.append(
				"  	p.card_number AS patientCode,                 					              									    	");
		sql.append(
				"	p.sex AS patientGender,    			              															    	");
		sql.append(
				" 	p.dob AS patientBirthDay      			              															    	");
		sql.append(
				" FROM reservation r   							              										     	     			");
		sql.append(
				" LEFT JOIN patient p ON r.patient_id = p.patient_id and r.hospital_id = p.hospital_id									              					  	");
		sql.append(
				" WHERE r.patient_id = :patientId							              										     	   	");
		sql.append(
				" AND   p.hospital_id = :hospitalId							              										     	   	");
		sql.append(
				" AND   r.reservation_status = 1							              										 	   	");
		sql.append(
				" 	ORDER BY r.created 	DESC				              										     	     				");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("patientId", patientId);
		query.setParameter("hospitalId", hospitalId);
		query.setMaxResults(limit);
		List<KcckReservationInfo> list = new JpaResultMapper().list(query, KcckReservationInfo.class);

		return list;

	}

	@Override
	public KcckReservationInfo findKcckReservationById(Integer reservationId) {
		StringBuilder sql = new StringBuilder();
		sql.append(
				" SELECT                            							              										     	     	");
		sql.append(
				" 	r.reservation_id AS reservationId,                         							              					       	");
		sql.append(
				" 	r.hospital_id AS hospitalId,                            							              				 	     	");
		sql.append(
				" 	r.dept_id AS deptId,                            							              						   	     	");
		sql.append(
				" 	r.doctor_id AS doctorId,                            							    							   	     	");
		sql.append(
				" 	r.patient_id AS patientId,                            							    						     	     	");
		sql.append(
				" 	r.patient_name AS patientName,                            													     	     	");
		sql.append(
				" 	r.name_furigana AS nameFurigana,                            												     	     	");
		sql.append(
				" 	r.phone_number AS phoneNumber,                            													     	     	");
		sql.append(
				" 	r.email AS email,                            							          							     	     	");
		sql.append(
				" 	r.reservation_date AS reservationDate,                           				  							     	     	");
		sql.append(
				" 	r.reservation_time AS reservationTime,                            			      							     	     	");
		sql.append(
				" 	r.session_id AS sessionId,                           					          							     	     	");
		sql.append(
				" 	r.reservation_code AS reservationCode,             							      							     	     	");
		sql.append(
				" 	r.reminder_time AS reminderTime,             							      								     	     	");
		sql.append(
				" 	r.doctor_name AS doctorName,    						      							         			    	     	");
		sql.append(
				" 	r.doctor_code AS doctorCode,    						      							         			    	     	");
		sql.append(
				" 	r.dept_name AS deptName,        						      							     						     	");
		sql.append(
				" 	r.depart_code AS deptCode,        						      							     						     	");
		sql.append(
				" 	p.card_number AS patientCode,                 							              								     	");
		sql.append(
				" 	p.sex AS patientGender,               							              								     	");
		sql.append(
				" 	p.dob AS patientBirthDay                 							    	          								     	");
		sql.append(
				" FROM reservation r, patient p    							              										     	     	");
		sql.append(
				" WHERE r.patient_id = p.patient_id 	and r.hospital_id = p.hospital_id						              										     	     	");
		sql.append(
				" AND r.reservation_id = :reservationId                           				            								    ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("reservationId", reservationId);
		List<KcckReservationInfo> list = new JpaResultMapper().list(query, KcckReservationInfo.class);
		if (CollectionUtils.isNotEmpty(list)) {
			return list.get(0);
		}
		return null;
	}

	/**
	 * Find by hospId and cardNumber
	 * 
	 * @author TungLT
	 * @param hospId
	 * @param cardNumber
	 * @param startIndex
	 * @param pageSize
	 * @return the list
	 */
	@Override
	public List<InsuranceHistory> findReservationByHospIdAndPatientId(Integer hospId, String cardNumber,
			Integer startIndex, Integer pageSize, String columnSort, String typeOrder) {

		// TODO Auto-generated method stub
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT '1' AS rowNum , ");
		sql.append(
				"CONCAT( DATE_FORMAT(r.reservation_Date, '%d/%m/%Y') ,'  ' , CONCAT(SUBSTRING(r.reservation_time,1,2),':', SUBSTRING(r.reservation_time,3,2))) AS reservationDateTime , ");
		sql.append("r.refer_Link AS referLink  ");
		sql.append("FROM reservation r, patient p ");
		sql.append("WHERE 1 = 1 ");
		sql.append(" AND p.hospital_id = r.hospital_id ");
		sql.append(" AND p.patient_id = r.patient_id ");
		sql.append("AND r.hospital_id = :hospId ");
		sql.append("AND p.card_Number = :cardNumber ");
		sql.append("AND r.refer_link is not null ");
		if (columnSort.equalsIgnoreCase("1")) {
			if (typeOrder.equalsIgnoreCase("asc"))
				sql.append(" ORDER BY r.reservation_Date asc ,r.reservation_time  asc ");
			else if(typeOrder.equalsIgnoreCase("desc"))
				sql.append(" ORDER BY r.reservation_Date desc,r.reservation_time desc ");
		}
		else if(columnSort.equalsIgnoreCase("2"))
		{
			if (typeOrder.equalsIgnoreCase("asc"))
				sql.append(" ORDER BY r.refer_Link,r.refer_Link  ");
			else if(typeOrder.equalsIgnoreCase("desc"))
				sql.append(" ORDER BY r.refer_Link,r.refer_Link desc ");			
		}
		else
		{
			sql.append(" ORDER BY r.reservation_id desc");
		}
		sql.append(" LIMIT :startIndex, :pageSize");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospId", hospId);
		query.setParameter("cardNumber", cardNumber);
		query.setParameter("startIndex", startIndex);
		query.setParameter("pageSize", pageSize);

		List<InsuranceHistory> list = new JpaResultMapper().list(query, InsuranceHistory.class);
		return list;
	}

	@Override
	public Integer getTotalRecordReservationByHospIdAndPatientId(Integer hospId, String cardNumber) {
		// TODO Auto-generated method stub
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT COUNT(r.reservation_id) ");
		sql.append("FROM reservation r, patient p ");
		sql.append("WHERE 1=1 ");
		sql.append(" AND p.hospital_id = r.hospital_id ");
		sql.append(" AND p.patient_id = r.patient_id ");
		sql.append("AND r.hospital_id = :hospId ");
		sql.append("AND p.card_Number = :cardNumber ");
		sql.append("AND r.refer_link is not null ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospId", hospId);
		query.setParameter("cardNumber", cardNumber);
		List<BigInteger> lstInjected = query.getResultList();
		if (CollectionUtils.isNotEmpty(lstInjected)) {
			return lstInjected.get(0).intValue();
		}
		return null;
	}

	@Override
	public List<ReservationOnlineInfo> findReservationInfoByReCodeHosId(Integer hospitalId,
			List<String> reservationCodes) {
		if (hospitalId == 0 || reservationCodes == null) {
			return null;
		}

		try {
			StringBuilder listReservationCode = new StringBuilder();
			if (reservationCodes != null && reservationCodes.size() > 0) {
				int index = 0;
				for (String parame : reservationCodes) {
					index += 1;
					if (index == reservationCodes.size())
						listReservationCode.append("'" + parame + "'");
					else
						listReservationCode.append("'" + parame + "', ");
				}
			}

			Map<String, Object> params = new HashMap<String, Object>();
			StringBuilder sql = new StringBuilder();
			sql.append(" SELECT                                                                     ");
			sql.append(" 	reservation_id,                                                         ");
			sql.append(" 	reservation_code,                                                       ");
			sql.append(" 	mt_calling_id,                                                          ");
			sql.append(" 	patient_id,                                     	                    ");
			sql.append(" 	hospital_id,                                                            ");
			sql.append(" 	dept_id,                                                                ");
			sql.append(" 	doctor_id                                                               ");
			sql.append(" FROM                                                					    ");
			sql.append(" 	reservation                                      					    ");
			sql.append(" WHERE active_flg = 1                               						");
			sql.append(" 	AND hospital_id = :hospitalId                             				");
			sql.append(" 	AND reservation_code  IN (" + listReservationCode + ")                  ");

			params.put("hospitalId", hospitalId);

			Query query = entityManager.createNativeQuery(sql.toString());
			for (Map.Entry<String, Object> entry : params.entrySet()) {
				query.setParameter(entry.getKey(), entry.getValue());
			}
			List<ReservationOnlineInfo> list = new JpaResultMapper().list(query, ReservationOnlineInfo.class);
			return list;
		} catch (Exception e) {
			e.printStackTrace();
		}

		return null;
	}
	public String getMtCallingIdByReservationId(Integer reservationId) {
		// TODO Auto-generated method stub
		String lstMtCallingId = null;
		try {
			StringBuilder sql = new StringBuilder();
			sql.append("SELECT mt_calling_id ");
			sql.append("FROM reservation r ");
			sql.append("WHERE reservation_id = :f_reservationId ");
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_reservationId", reservationId);		
			lstMtCallingId = (String)query.getSingleResult();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return lstMtCallingId;
	}

}
