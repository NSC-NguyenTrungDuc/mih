package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.collections.CollectionUtils;

import nta.med.data.dao.medi.nur.Nur1011RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Nur1011RepositoryImpl implements Nur1011RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getNUR6011U01GetNurseInfoGanhodo(String hospCode, Double fkinp1001, String jukyongDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.GANHODO                                                                                ");
		sql.append("    FROM NUR1011 A                                                                                 ");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code                                                             ");
		sql.append("     AND A.FKINP1001    = :f_fkinp1001                                                             ");
		sql.append("     AND A.JUKYONG_DATE = ( SELECT MAX(C.JUKYONG_DATE)                                             ");
		sql.append("                              FROM NUR1011 C                                                       ");
		sql.append("                             WHERE C.HOSP_CODE = A.HOSP_CODE                                       ");
		sql.append("                               AND C.FKINP1001 = A.FKINP1001                                       ");
		sql.append("                               AND C.JUKYONG_DATE <= STR_TO_DATE(:f_jukyong_date, '%Y/%m/%d'));    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_jukyong_date", jukyongDate);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
}

