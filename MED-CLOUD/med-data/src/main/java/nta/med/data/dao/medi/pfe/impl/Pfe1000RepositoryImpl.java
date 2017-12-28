package nta.med.data.dao.medi.pfe.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.pfe.Pfe1000RepositoryCustom;
import nta.med.data.model.ihis.endo.END1001U02DsvDwInfo;

/**
 * @author dainguyen.
 */
public class Pfe1000RepositoryImpl implements Pfe1000RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<END1001U02DsvDwInfo> getEND1001U02DsvDwInfo(String hospCode, Double fkocs) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PKPFE1000                                                         ");
		sql.append("     , A.C3                                                                 ");
		sql.append("     , A.FKOCS                                                              ");
		sql.append("     , A.BUNHO                                                              ");
		sql.append("     , A.HANGMOG_CODE                                                       ");
		sql.append("     , B.HANGMOG_NAME                                                       ");
		sql.append("     , A.RESIDENT_YN                                                        ");
		sql.append("  FROM OCS0103 B RIGHT JOIN PFE1000 A ON B.HANGMOG_CODE= A.HANGMOG_CODE     ");
		sql.append(" WHERE A.FKOCS           = :f_fkocs                                         ");
		sql.append("   AND A.HOSP_CODE       = :f_hosp_code										");
		sql.append("   AND B.HOSP_CODE       = :f_hosp_code										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs", fkocs);
		List<END1001U02DsvDwInfo> listResult = new JpaResultMapper().list(query, END1001U02DsvDwInfo.class);
		return listResult;
	}

	@Override
	public Double getMaxPKPFE1000ByHospCode(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(MAX(PKPFE1000),0) + 1 FROM PFE1000 WHERE HOSP_CODE = :f_hosp_code");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		List<Double> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
}

