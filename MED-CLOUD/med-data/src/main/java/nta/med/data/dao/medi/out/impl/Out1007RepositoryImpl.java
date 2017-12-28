package nta.med.data.dao.medi.out.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out1007RepositoryCustom;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdGongbiListInfo;

/**
 * @author dainguyen.
 */
public class Out1007RepositoryImpl implements Out1007RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORDERTRANSGrdGongbiListInfo> getORDERTRANSGrdGongbiListInfoCaseEqualOAndElse(String hospCode, String bunho, Double out1001, String language) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.GONGBI_CODE                                                           ");
		sql.append("       , FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, SYSDATE(), :language)   GONGBI_NAME        ");
		sql.append("       , C.LAST_CHECK_DATE                                                      ");
		sql.append("       , C.BUDAMJA_BUNHO                                                        ");
		sql.append("       , C.SUGUBJA_BUNHO                                                        ");
		sql.append("       , 'Y'                                                                    ");
		sql.append("       , A.PRIORITY                                                             ");
		sql.append("       , IFNULL(C.IF_VALID_YN, 'Y')                                             ");
		sql.append("    FROM  OUT1007 A RIGHT JOIN OUT1003 B ON A.FKOUT1003 = :f_out1001            ");
		sql.append("    AND A.FKOUT1003      = B.PKOUT1003 AND A.HOSP_CODE = :f_hosp_code           ");
		sql.append("         ,OUT0105 C                                                             ");
		sql.append("  WHERE  A.FKOUT1003      = B.PKOUT1003                                         ");
		sql.append("    AND B.BUNHO          = :f_bunho                                             ");
		sql.append("    AND B.BUNHO          = C.BUNHO                                              ");
		sql.append("    AND A.GONGBI_CODE    = C.GONGBI_CODE                                        ");
		sql.append("    AND SYSDATE() BETWEEN C.START_DATE AND IFNULL(C.END_DATE, '9998/12/31')     ");
		sql.append("    ORDER BY A.GONGBI_CODE														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_out1001", out1001);
		query.setParameter("language", language);
		
		List<ORDERTRANSGrdGongbiListInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdGongbiListInfo.class);
		return list;
	}
}

