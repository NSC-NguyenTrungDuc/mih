package nta.mss.repository.impl;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.mss.repository.DepartmentScheduleRepositoryCustom;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.util.List;

/**
 * The Class DoctorScheduleRepositoryImpl. 
 *
 * @author MinhLS
 * @crtDate Sep 20, 2014
 */
public class DepartmentScheduleRepositoryImpl implements DepartmentScheduleRepositoryCustom {
	private static Logger LOG = LogManager.getLogger(DepartmentScheduleRepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public boolean generateDepartmentSchedule(Integer doctorId, Integer deptId, Integer kpiAvg, String currentDate) {
		String sql = "INSERT INTO department_schedule (dept_id, start_time, doctor_id, day, hospital_id, holiday_flg, end_time, apply_date, kpi, active_flg) "
				+ "SELECT dept_id, start_time, ?1, day, hospital_id, 0, end_time, ?2, ?3, 1 "
				+ "FROM department_schedule "
				+ "WHERE dept_id = ?4 "
				+ "GROUP BY dept_id, start_time, day, hospital_id, end_time";
		Query query = entityManager.createNativeQuery(sql);
		query.setParameter(1, doctorId);
		query.setParameter(2, currentDate);
		query.setParameter(3, kpiAvg);
		query.setParameter(4, deptId);
		Integer result = query.executeUpdate(); 
		LOG.debug("query: " + result);
		if (result == 0) return false;
		return true;
	}

	@Override
	public List<String> getFullTimeslotListByDepartment(Integer deptId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  CONCAT(d1.startTime, '_', d1.endTime) AS dsTime");
		sql.append(" FROM (");
		sql.append(" SELECT ds.start_time as startTime ,max(ds.end_time) as endTime");
		sql.append(" FROM department_schedule ds");
		sql.append(" WHERE ds.dept_id = :deptId");
		sql.append(" AND ds.active_flg = 1");
		sql.append(" GROUP BY ds.start_time");
		sql.append(" ) AS d1");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("deptId", deptId);
		System.out.print(query.getResultList());
		return query.getResultList();
	}
}
