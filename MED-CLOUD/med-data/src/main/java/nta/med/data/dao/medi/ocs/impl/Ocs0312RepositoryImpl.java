package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0312RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetCodeListInfo;

/**
 * @author dainguyen.
 */
public class Ocs0312RepositoryImpl implements Ocs0312RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS0311U00grdSetCodeListInfo> getOCS0311U00grdSetCodeListInfo(String hospCode, String setPart, String hangmogCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.SET_PART, A.HANGMOG_CODE, A.SET_CODE, A.COMMENTS, A.SET_CODE_NAME   ");
		sql.append(" FROM OCS0312 A WHERE A.HOSP_CODE = :f_hosp_code AND A.SET_PART = :f_set_part ");
		sql.append(" AND A.HANGMOG_CODE = :f_hangmog_code ORDER BY A.SET_CODE                     ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_set_part", setPart);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<OCS0311U00grdSetCodeListInfo> listSetCode= new JpaResultMapper().list(query, OCS0311U00grdSetCodeListInfo.class);
		return listSetCode;
	}

	
}

