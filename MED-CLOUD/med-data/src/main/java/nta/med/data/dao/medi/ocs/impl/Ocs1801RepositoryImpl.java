package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs1801RepositoryCustom;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdPaStatusInfo;

/**
 * @author dainguyen.
 */
public class Ocs1801RepositoryImpl implements Ocs1801RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<XRT1002U00GrdPaStatusInfo> getXRT1002U00GrdPaStatusInfo(String hospCode, String language, String bunho, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO                ,                                                                                                           									  ");
		sql.append("        A.PAT_STATUS           ,                                                                                                                                              ");
		sql.append("        B.PAT_STATUS_NAME      ,                                                                                                                                              ");
		sql.append("        A.PAT_STATUS_CODE      ,                                                                                                                                              ");
		sql.append("        C.PAT_STATUS_CODE_NAME ,                                                                                                                                              ");
		sql.append("        A.MENT                 ,                                                                                                                                              ");
		sql.append("        E.SEQ                  ,                                                                                                                                              ");
		sql.append("        E.INDISPENSABLE_YN     ,                                                                                                                                              ");
		sql.append("        CONCAT (LTRIM(LPAD(IFNULL(E.SEQ, 99), 5, '0')), A.PAT_STATUS) CONT_KEY                                                                                                ");
		sql.append("   FROM OCS1801 A                                                                                                                                                             ");
		sql.append("         INNER JOIN OCS0801 B ON B.PAT_STATUS = A.PAT_STATUS AND B.LANGUAGE = :language                                                                                       ");
		sql.append("         INNER JOIN OCS0804 E ON E.PAT_STATUS = A.PAT_STATUS    AND E.HOSP_CODE = :f_hosp_code                                                                                ");
		sql.append("         INNER JOIN OCS0103 D ON E.PAT_STATUS_GR      = D.PAT_STATUS_GR  AND D.HOSP_CODE = :f_hosp_code                                                                       ");
		sql.append("         LEFT JOIN OCS0802 C ON C.PAT_STATUS = A.PAT_STATUS AND C.PAT_STATUS_CODE = A.PAT_STATUS_CODE  AND C.LANGUAGE = :language AND C.HOSP_CODE = :f_hosp_code              ");
		sql.append("         LEFT JOIN OCS0802 F ON F.PAT_STATUS = B.PAT_STATUS AND F.PAT_STATUS_CODE = B.DEFAULT_PAT_STATUS_CODE  AND F.LANGUAGE = :language  AND F.HOSP_CODE = :f_hosp_code     ");
		sql.append("   WHERE A.HOSP_CODE          = :f_hosp_code                                                                                                                                  ");
		sql.append("    AND A.BUNHO              = :f_bunho                                                                                                                                       ");
		sql.append("    AND D.HANGMOG_CODE       = :f_hangmog_code                                                                                                                                ");
		sql.append(" UNION ALL                                                                                                                                                                    ");
		sql.append(" SELECT :f_bunho          BUNHO                          ,                                                                                                                    ");
		sql.append("        B.PAT_STATUS                                     ,                                                                                                                    ");
		sql.append("        C.PAT_STATUS_NAME                                ,                                                                                                                    ");
		sql.append("        IF(B.PAT_STATUS = '02' OR B.PAT_STATUS = '40',IF(E.SEX = 'M','01',NULL),NULL) PAT_STATUS_CODE     ,                                                                   ");
		sql.append("        NULL                         PAT_STATUS_CODE_NAME,                                                                                                                    ");
		sql.append("        B.MENT                                           ,                                                                                                                    ");
		sql.append("        B.SEQ                                            ,                                                                                                                    ");
		sql.append("        B.INDISPENSABLE_YN                               ,                                                                                                                    ");
		sql.append("        CONCAT(LTRIM(LPAD(IFNULL(B.SEQ, 99), 5,'0')),B.PAT_STATUS) CONT_KEY                                                                                                   ");
		sql.append("   FROM OUT0101 E, OCS0103 A                                                                                                                                                  ");
		sql.append("         INNER JOIN OCS0804 B ON B.PAT_STATUS_GR = A.PAT_STATUS_GR AND B.HOSP_CODE          = :f_hosp_code                                                                    ");
		sql.append("         INNER JOIN OCS0801 C ON C.PAT_STATUS = B.PAT_STATUS                                                                                                                  ");
		sql.append("         LEFT JOIN OCS0802 D ON D.PAT_STATUS = C.PAT_STATUS AND D.PAT_STATUS_CODE = C.DEFAULT_PAT_STATUS_CODE   AND D.LANGUAGE = :language AND D.HOSP_CODE   = :f_hosp_code   ");
		sql.append("  WHERE A.HOSP_CODE          = :f_hosp_code                                                                                                                                   ");
		sql.append("    AND C.LANGUAGE = :language                                                                                                                                                ");
		sql.append("    AND A.HANGMOG_CODE       = :f_hangmog_code                                                                                                                                ");
		sql.append("    AND NOT EXISTS ( SELECT 'X'                                                                                                                                               ");
		sql.append("                       FROM OCS1801 D                                                                                                                                         ");
		sql.append("                      WHERE D.PAT_STATUS = B.PAT_STATUS                                                                                                                       ");
		sql.append("                        AND D.BUNHO      = :f_bunho                                                                                                                           ");
		sql.append("                        )                                                                                                                                                     ");
		sql.append("    AND E.BUNHO              = :f_bunho                                                                                                                                       ");
		sql.append("    AND E.HOSP_CODE = :f_hosp_code                                                                                                                                            ");
		sql.append(" ORDER BY 9;                                                                                                                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		List<XRT1002U00GrdPaStatusInfo> list = new JpaResultMapper().list(query, XRT1002U00GrdPaStatusInfo.class);
		return list;
	}
	
	@Override
	public List<XRT1002U00GrdPaStatusInfo> getXRT1002U00PrintOrderByJudalPart(String hospCode, String language, String bunho, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT   DISTINCT                                                                                                                             ");
		sql.append("         A.BUNHO                ,                                                                                                             ");
		sql.append("         A.PAT_STATUS           ,                                                                                                             ");
		sql.append("         B.PAT_STATUS_NAME      ,                                                                                                             ");
		sql.append("         IFNULL(A.PAT_STATUS_CODE,B.DEFAULT_PAT_STATUS_CODE)      ,                                                                           ");
		sql.append("         IFNULL(C.PAT_STATUS_CODE_NAME,F.PAT_STATUS_CODE_NAME)    ,                                                                           ");
		sql.append("         A.MENT                 ,                                                                                                             ");
		sql.append("         E.SEQ                  ,                                                                                                             ");
		sql.append("         E.INDISPENSABLE_YN     ,                                                                                                             ");
		sql.append("         CONCAT(LTRIM(LPAD(IFNULL(E.SEQ, 99), 5, '0')),A.PAT_STATUS) CONT_KEY                                                                 ");
		sql.append("    FROM OCS1801 A                                                                                                                            ");
		sql.append("      INNER JOIN OCS0801 B ON  B.PAT_STATUS         = A.PAT_STATUS                                                                            ");
		sql.append("      INNER JOIN OCS0103 D ON D.HOSP_CODE = A.HOSP_CODE                                                                                       ");
		sql.append("      INNER JOIN OCS0804 E ON E.HOSP_CODE = A.HOSP_CODE AND E.PAT_STATUS = A.PAT_STATUS AND E.PAT_STATUS_GR = D.PAT_STATUS_GR                 ");
		sql.append("      LEFT JOIN OCS0802 C ON C.HOSP_CODE = A.HOSP_CODE  AND C.PAT_STATUS = A.PAT_STATUS AND C.PAT_STATUS_CODE = A.PAT_STATUS_CODE             ");
		sql.append("      LEFT JOIN OCS0802 F ON F.HOSP_CODE = B.HOSP_CODE AND F.PAT_STATUS = B.PAT_STATUS AND F.PAT_STATUS_CODE  = B.DEFAULT_PAT_STATUS_CODE     ");
		sql.append("   WHERE A.HOSP_CODE          = :f_hosp_code                                                                                                  ");
		sql.append("     AND A.BUNHO              = :f_bunho                                                                                                      ");
		sql.append("     AND B.LANGUAGE = :language                                                                                                               ");
		sql.append("     AND C.LANGUAGE = :language                                                                                                               ");
		sql.append("     AND F.LANGUAGE = :language                                                                                                               ");
		sql.append("     AND D.HANGMOG_CODE       IN (:hangmog_codes)                                                                                             ");
		sql.append("  UNION ALL                                                                                                                                   ");
		sql.append("  SELECT DISTINCT                                                                                                                             ");
		sql.append("         :f_bunho          BUNHO                          ,                                                                                   ");
		sql.append("         B.PAT_STATUS                                     ,                                                                                   ");
		sql.append("         C.PAT_STATUS_NAME                                ,                                                                                   ");
		sql.append("         C.DEFAULT_PAT_STATUS_CODE    PAT_STATUS_CODE     ,                                                                                   ");
		sql.append("         D.PAT_STATUS_CODE_NAME       PAT_STATUS_CODE_NAME,                                                                                   ");
		sql.append("         B.MENT                                           ,                                                                                   ");
		sql.append("         B.SEQ                                            ,                                                                                   ");
		sql.append("         B.INDISPENSABLE_YN                               ,                                                                                   ");
		sql.append("         CONCAT(LTRIM(LPAD(IFNULL(B.SEQ, 99), 5, '0')),B.PAT_STATUS) CONT_KEY                                                                 ");
		sql.append("    FROM OCS0103 A                                                                                                                            ");
		sql.append("         INNER JOIN OCS0804 B ON B.HOSP_CODE = A.HOSP_CODE AND B.PAT_STATUS_GR      = A.PAT_STATUS_GR                                         ");
		sql.append("         INNER JOIN OCS0801 C ON  C.PAT_STATUS = B.PAT_STATUS                                                                                 ");
		sql.append("         LEFT JOIN OCS0802 D ON D.HOSP_CODE = C.HOSP_CODE AND D.PAT_STATUS = C.PAT_STATUS AND D.PAT_STATUS_CODE = C.DEFAULT_PAT_STATUS_CODE   ");
		sql.append("   WHERE A.HOSP_CODE          = :f_hosp_code                                                                                                  ");
		sql.append("      AND C.LANGUAGE = :language                                                                                                              ");
		sql.append("     AND D.LANGUAGE = :language                                                                                                               ");
		sql.append("     AND A.HANGMOG_CODE       IN (:hangmog_codes)                                                                                             ");
		sql.append("     AND NOT EXISTS ( SELECT 'X'                                                                                                              ");
		sql.append("                        FROM OCS1801 D                                                                                                        ");
		sql.append("                       WHERE D.HOSP_CODE  = C.HOSP_CODE                                                                                       ");
		sql.append("                         AND D.BUNHO      = :f_bunho                                                                                          ");
		sql.append("                         AND D.PAT_STATUS = B.PAT_STATUS )                                                                                    ");
		sql.append("  ORDER BY 9                                                                                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		List<XRT1002U00GrdPaStatusInfo> list = new JpaResultMapper().list(query, XRT1002U00GrdPaStatusInfo.class);
		return list;
	}
}

