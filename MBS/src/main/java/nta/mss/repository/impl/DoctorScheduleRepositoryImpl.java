package nta.mss.repository.impl;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.mss.repository.DoctorScheduleRepositoryCustom;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

/**
 * The Class DoctorScheduleRepositoryImpl. 
 *
 * @author MinhLS
 * @crtDate Sep 20, 2014
 */
public class DoctorScheduleRepositoryImpl implements DoctorScheduleRepositoryCustom {
	private static Logger LOG = LogManager.getLogger(DoctorScheduleRepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public boolean copyDoctorSchedule(Integer copyDoctorId, Integer doctorId, String currentDate) {
		String sql = "INSERT INTO doctor_schedule (check_date, start_time, hospital_id, dept_id, kpi, end_time, active_flg, doctor_id) "
					+ "SELECT check_date, start_time, hospital_id, dept_id, kpi, end_time, active_flg, ?1 "
					+ "FROM doctor_schedule "
					+ "WHERE doctor_id = ?2 and check_date >= ?3";
		Query query = entityManager.createNativeQuery(sql);
		query.setParameter(1, doctorId);
		query.setParameter(2, copyDoctorId);
		query.setParameter(3, currentDate);
		Integer result = query.executeUpdate(); 
		LOG.debug("query: " + result);
		if (result == 0) return false;
		return true;
	}
}
