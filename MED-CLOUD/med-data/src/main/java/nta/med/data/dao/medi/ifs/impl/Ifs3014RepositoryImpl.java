package nta.med.data.dao.medi.ifs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.data.dao.medi.ifs.Ifs3014RepositoryCustom;

/**
 * @author dainguyen.
 */
public class Ifs3014RepositoryImpl implements Ifs3014RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<Double> getINPBATCHTRANSOrderTransInfo(String hospCode, String fkinp3010, String transGubun, String ifFlag) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT PKIFS3014						");
		sql.append("	  FROM IFS3014							");
		sql.append("	  WHERE HOSP_CODE = :f_hosp_code		");
		sql.append("	    AND FKINP3010 = :f_fkINP3010		");
		if (!"Y".equals(transGubun))
			sql.append("	    AND AND IF_FLAG = :f_ifFlag		");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkINP3010", fkinp3010);
		query.setParameter("f_ifFlag", ifFlag);
		
		@SuppressWarnings("unchecked")
		List<Double> list = query.getResultList();
		return list;
		
	}

	@Override
	public List<Double> getINPORDERTRANSSangTrans(String hospCode, Double fkinp3010, String transGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT PKIFS3014						");
		sql.append("	  FROM IFS3014							");
		sql.append("	  WHERE HOSP_CODE = :f_hosp_code		");
		sql.append("	    AND FKINP3010 = :f_fkINP3010		");
		if ("R".equals(transGubun) || "Y".equals(transGubun)){
			sql.append("	    AND  IF_FLAG = 10		");
		}else if("N".equals(transGubun)){
			sql.append("	    AND  IF_FLAG = 20		");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkINP3010", fkinp3010);
		
		List<Double> list = query.getResultList();
		return list;
	}
}

