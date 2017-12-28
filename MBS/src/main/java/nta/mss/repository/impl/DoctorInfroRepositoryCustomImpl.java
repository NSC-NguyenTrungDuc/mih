package nta.mss.repository.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.mss.repository.DoctorInfroRepositoryCustom;

import org.springframework.stereotype.Service;

/**
 * @author linh.nguyen.trong
 * 
 * The Class DoctorInfroRepositoryCustomImpl.
 */
@Service
public class DoctorInfroRepositoryCustomImpl implements DoctorInfroRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<Object[]> findAllDoctorInfo(Integer hospitalId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" select h.hospital_code, h.hospital_name, dept.dept_code,");
		sql.append(" dept.dept_name, dept.dept_type, dept.display_order,");
		sql.append(" d.name, d.order_priority, d.junior_flg, d.kpi_avg");
		sql.append(" FROM hospital h, department dept, doctor d");
		sql.append(" WHERE h.hospital_id = dept.hospital_id and dept.dept_id = d.dept_id and d.active_flg = 1 and h.hospital_id = :hospitalId");
		sql.append(" ORDER BY h.hospital_code, dept.dept_code, dept.dept_name, d.name asc");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalId", hospitalId);
		return query.getResultList();
	}
	
}
