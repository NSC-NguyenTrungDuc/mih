package nta.med.data.dao.medi.nur.impl;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.data.dao.medi.nur.Nur0402RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Nur0402RepositoryImpl implements Nur0402RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Integer deleteNUR0402InNUR0401U01(String hospCode, String code) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	DELETE FROM NUR0402                                             ");
		sql.append("	WHERE HOSP_CODE    = :f_hosp_code                               ");
		sql.append("	  AND NUR_PLAN_JIN IN (SELECT B.NUR_PLAN_JIN                    ");
		sql.append("	                          FROM NUR0401 B                        ");
		sql.append("	                         WHERE B.HOSP_CODE       = :f_hosp_code ");
		sql.append("	                           AND B.NUR_PLAN_BUNRYU = :f_code)     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		
		return query.executeUpdate();
	}
}

