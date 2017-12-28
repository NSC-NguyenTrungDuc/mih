package nta.med.data.dao.medi.drg.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.drg.Drg0141RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0103U10DrugTreeInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Drg0141RepositoryImpl implements Drg0141RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Drg0141RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS0103U10DrugTreeInfo> listOCS0103U10DrugTreeInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT A.CODE             CODE                   " );
		sql.append("  , A.CODE_NAME        CODE_NAME                           " );
		sql.append("  , B.CODE1            CODE1                               " );
		sql.append("  , B.CODE_NAME1       CODE_NAME1                          " );
		sql.append(" FROM DRG0140 A, DRG0141 B , INV0110 C , OCS0103 D         " );
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                        " );
		sql.append("  AND A.CODE        = B.CODE                               " );
		sql.append("  AND A.LANGUAGE    = :f_language                          " );
		sql.append("  AND B.LANGUAGE    = :f_language                          " );
		sql.append("  AND B.HOSP_CODE   = A.HOSP_CODE                          " );
		sql.append("  AND B.CODE1       = C.SMALL_CODE                         " );
		sql.append("  AND C.HOSP_CODE   = B.HOSP_CODE                          " );
		sql.append("  AND C.JAERYO_CODE = D.HANGMOG_CODE                       " );
		sql.append("  AND D.HOSP_CODE   = C.HOSP_CODE                          " );
		sql.append("  AND D.ORDER_GUBUN IN ( 'C', 'D')                         " );
		sql.append("     UNION ALL                                         	   " );
		
		if(Language.ENGLISH.toString().toUpperCase().equals(language)){
			sql.append("    SELECT '999'              CODE                     " );
			sql.append(" , 'Others'           CODE_NAME                        " );
			sql.append(" , '999'              CODE1                            " );
			sql.append(" , 'Others'           CODE_NAME1                       " );
		} else if(Language.VIETNAMESE.toString().toUpperCase().equals(language)){
			sql.append("    SELECT '999'              CODE                     " );
			sql.append(" , 'Khác'           CODE_NAME                          " );
			sql.append(" , '999'              CODE1                            " );
			sql.append(" , 'Khác'           CODE_NAME1                         " );
		} else {
			sql.append("    SELECT '999'              CODE                     " );
			sql.append(" , 'その他'           CODE_NAME                          " );
			sql.append(" , '999'              CODE1                            " );
			sql.append(" , 'その他'           CODE_NAME1                         " );
		}
		
		sql.append("     ORDER BY 3												");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<OCS0103U10DrugTreeInfo> list = new JpaResultMapper().list(query, OCS0103U10DrugTreeInfo.class);
		return list;
	}
}

