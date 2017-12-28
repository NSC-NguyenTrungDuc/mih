package nta.med.data.dao.medi.inp.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inp.Inp3018RepositoryCustom;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdGongbiListInfo;

/**
 * @author dainguyen.
 */
public class Inp3018RepositoryImpl implements Inp3018RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORDERTRANSGrdGongbiListInfo> getORDERTRANSGrdGongbiListInfoCaseElseElse(String hospCode, Double pkout, String language) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.GONGBI_CODE                                                                                       ");
		sql.append("      , FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, SYSDATE(), :language)   GONGBI_NAME                          ");
		sql.append("      , C.LAST_CHECK_DATE                                                                                   ");
		sql.append("      , C.BUDAMJA_BUNHO                                                                                     ");
		sql.append("      , C.SUGUBJA_BUNHO                                                                                     ");
		sql.append("      , 'Y'    SELECT_YN                                                                                    ");
		sql.append("      , A.PRIORITY                                                                                          ");
		sql.append("      , IFNULL(C.IF_VALID_YN, 'Y')                                                                          ");
		sql.append("   FROM  INP3018 A RIGHT JOIN INP3010 B ON  A.HOSP_CODE  = B.HOSP_CODE AND A.FKINP3010 = B.PKINP3010        ");
		sql.append("        ,OUT0105 C                                                                                          ");
		sql.append("  WHERE B.HOSP_CODE      = :f_hosp_code                                                                     ");
		sql.append("    AND B.PKINP3010      = :f_pkout                                                                         ");
		sql.append("    AND C.HOSP_CODE      = B.HOSP_CODE                                                                      ");
		sql.append("    AND C.BUNHO          = B.BUNHO                                                                          ");
		sql.append("    AND C.GONGBI_CODE    = A.GONGBI_CODE                                                                    ");
		sql.append("    AND SYSDATE() BETWEEN C.START_DATE AND IFNULL(C.END_DATE, '9998/12/31')                                 ");
		sql.append("  ORDER BY A.GONGBI_CODE 																					");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkout", pkout);
		query.setParameter("language", language);
		
		List<ORDERTRANSGrdGongbiListInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdGongbiListInfo.class);
		return list;
	}
}

