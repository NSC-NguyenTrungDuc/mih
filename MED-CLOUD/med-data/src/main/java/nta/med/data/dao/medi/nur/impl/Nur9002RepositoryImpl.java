package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.data.dao.medi.nur.Nur9002RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Nur9002RepositoryImpl implements Nur9002RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<String> getNUR1020Q00layFlagInfo(String hospCode, String bunho, String startDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT DISTINCT DATEDIFF(STR_TO_DATE(INPUT_DATE, '%Y/%m/%d'), STR_TO_DATE(:f_start_date, '%Y/%m/%d')) NUM                            ");
		sql.append("	  FROM NUR9002                                                                                                                        ");
		sql.append("	 WHERE HOSP_CODE  = :f_hosp_code                                                                                                      ");
		sql.append("	   AND BUNHO      = :f_bunho                                                                                                          ");
		sql.append("	   AND INPUT_DATE BETWEEN DATE_ADD(STR_TO_DATE(:f_start_date, '%Y/%m/%d'), INTERVAL -6 DAY) AND STR_TO_DATE(:f_start_date,'%Y/%m/%d') ");
		sql.append("	   AND IN_OUT_GUBUN = 'I'                                                                                                             ");
		sql.append("	 ORDER BY 1                                                                                                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_start_date", startDate);
		
		List<String> rs = query.getResultList();
		return rs;
	}

	@Override
	public String callFnNurMergeRemark(String hospCode, String bunho, String iDate) {
		String sql = "SELECT FN_NUR_MERGE_REMARK(:f_hosp_code, :f_bunho, :f_date) FROM DUAL ";
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_date", iDate);
		
		List<String> rs = query.getResultList();
		return CollectionUtils.isEmpty(rs) ? "" : rs.get(0);
	}
}
