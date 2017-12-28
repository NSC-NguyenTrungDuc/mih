package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0804RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0803U00grdOCS0804ItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Ocs0804RepositoryImpl implements Ocs0804RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Ocs0804RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS0803U00grdOCS0804ItemInfo> getOCS0803U00grdOCS0804(String hospCode, String language, String patStatusGr) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PAT_STATUS_GR        ,                                                                           " );
		sql.append("        A.PAT_STATUS           ,                                                                           " );
		sql.append("        B.PAT_STATUS_NAME      ,                                                                           " );
		sql.append("        A.INDISPENSABLE_YN     ,                                                                           " );
		sql.append("        A.BREAK_PAT_STATUS_CODE,                                                                           " );
		sql.append("        C.PAT_STATUS_CODE_NAME ,                                                                           " );
		sql.append("        A.MENT                 ,                                                                           " );
		sql.append("        A.SEQ                                                                                              " );
		sql.append("   FROM OCS0802 C RIGHT JOIN  OCS0804 A ON C.HOSP_CODE = A.HOSP_CODE AND C.PAT_STATUS = A.PAT_STATUS       " );
		sql.append("   AND C.PAT_STATUS_CODE= A.BREAK_PAT_STATUS_CODE AND C.LANGUAGE =:f_language,                             " );
		sql.append("        OCS0801 B                                                                                          " );
		sql.append("  WHERE A.HOSP_CODE          = :f_hosp_code                                                                " );
		sql.append("    AND A.PAT_STATUS_GR      = :f_pat_status_gr                                                            " );
		sql.append("    AND B.PAT_STATUS         = A.PAT_STATUS                                                                " );
		sql.append("    AND B.LANGUAGE = :f_language                                                                           " );
		sql.append("  ORDER BY IFNULL(A.SEQ, 99), A.PAT_STATUS																	");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_pat_status_gr", patStatusGr);
		List<OCS0803U00grdOCS0804ItemInfo> list = new JpaResultMapper().list(query, OCS0803U00grdOCS0804ItemInfo.class);
		return list;
	}

}

