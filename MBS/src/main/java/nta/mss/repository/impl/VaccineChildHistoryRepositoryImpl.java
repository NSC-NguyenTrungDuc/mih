package nta.mss.repository.impl;

import java.math.BigInteger;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.mss.info.VaccineChildHistoryInfo;
import nta.mss.jpa.mapper.JpaResultMapper;
import nta.mss.repository.VaccineChildHistoryRepositoryCustom;

import org.apache.commons.collections.CollectionUtils;

/**
 * The Class VaccineChildHistoryImpl.
 */
public class VaccineChildHistoryRepositoryImpl implements VaccineChildHistoryRepositoryCustom {
	
	/** The entity manager. */
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<VaccineChildHistoryInfo> getListVaccineChildHistory(
			Integer childId) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT                                        ");
		sql.append("	a.vaccine_child_id,                       ");
		sql.append("	a.child_id,                               ");
		sql.append("	a.reservation_id,                         ");
		sql.append("	a.vaccine_id,                             ");
		sql.append("	a.hospital_name,                          ");
		sql.append("	a.injected_date,                          ");
		sql.append("	a.injected_no,                         ");
		sql.append("	a.active_flg,                             ");
		sql.append("	b.vaccine_group_id,                       ");
		sql.append("	d.child_name,                             ");
		sql.append("	c.vaccine_name                            ");
		sql.append("FROM                                          ");
		sql.append("	vaccine_child_history a,                  ");
		sql.append("	vaccine_group b,                          ");
		sql.append("	vaccine c,                                ");
		sql.append("	user_child d                              ");
		sql.append("WHERE                                         ");
		sql.append("	a.vaccine_id = c.vaccine_id               ");
		sql.append("AND b.vaccine_group_id = c.vaccine_group_id   ");
		sql.append("AND a.child_id = d.child_id                   ");
		sql.append("AND a.child_id = :childId                     ");
		sql.append("AND a.active_flg = 1                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("childId", childId);
		
		List<VaccineChildHistoryInfo> lstVaccineChildHistory = new JpaResultMapper().list(query, VaccineChildHistoryInfo.class);
		return lstVaccineChildHistory;
	}

	@Override
	public VaccineChildHistoryInfo getListVaccineChildHistoryById(
			Integer vaccineChildId) throws Exception {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT                                        ");
		sql.append("	a.vaccine_child_id,                       ");
		sql.append("	a.child_id,                               ");
		sql.append("	a.reservation_id,                         ");
		sql.append("	a.vaccine_id,                             ");
		sql.append("	a.hospital_name,                          ");
		sql.append("	a.injected_date,                          ");
		sql.append("	a.injected_no,           	              ");
		sql.append("	a.active_flg,                             ");
		sql.append("	b.vaccine_group_id,                       ");
		sql.append("	d.child_name,                             ");
		sql.append("	c.vaccine_name                            ");
		sql.append("FROM                                          ");
		sql.append("	vaccine_child_history a,                  ");
		sql.append("	vaccine_group b,                          ");
		sql.append("	vaccine c,                                ");
		sql.append("	user_child d                              ");
		sql.append("WHERE                                         ");
		sql.append("	a.vaccine_id = c.vaccine_id               ");
		sql.append("AND b.vaccine_group_id = c.vaccine_group_id   ");
		sql.append("AND a.child_id = d.child_id                   ");
		sql.append("AND a.vaccine_child_id = :vaccineChildId      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("vaccineChildId", vaccineChildId);
		
		List<VaccineChildHistoryInfo> lstVaccineChildHistory = new JpaResultMapper().list(query, VaccineChildHistoryInfo.class);
		if (CollectionUtils.isNotEmpty(lstVaccineChildHistory)) {
			return lstVaccineChildHistory.get(0);
		}
		return null;
	}

	@SuppressWarnings("unchecked")
	public Integer getMaxInjectedNo(Integer vaccineId, Integer childId) throws Exception {
		if (vaccineId == null || childId == null) {
			return null;
		}
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                          ");
		sql.append(" 	IFNULL(MAX(injected_no), 0) AS maxInjectedNo ");
		sql.append(" FROM                                            ");
		sql.append(" 	vaccine_child_history                        ");
		sql.append(" WHERE                                           ");
		sql.append(" 	child_id = :childId                          ");
		sql.append(" AND vaccine_id = :vaccineId                     ");
		sql.append(" AND active_flg = 1                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("childId", childId);
		query.setParameter("vaccineId", vaccineId);
		List<BigInteger> lstInjected = query.getResultList();
		if (CollectionUtils.isNotEmpty(lstInjected)) {
			return lstInjected.get(0).intValue();
		}
		return null;
		
	}
}
