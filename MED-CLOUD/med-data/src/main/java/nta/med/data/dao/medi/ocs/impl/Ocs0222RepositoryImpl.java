package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0222RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0221Q01GrdOCS0222Info;
import nta.med.data.model.ihis.ocsa.OcsaOCS0221U00GrdOCS0222ListInfo;

/**
 * @author dainguyen.
 */
public class Ocs0222RepositoryImpl implements Ocs0222RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OcsaOCS0221U00GrdOCS0222ListInfo> getOcsaOCS0221U00GrdOCS0222List(String hospCode, String memb, String seq){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT MEMB         ,                 ");
		sql.append("       SEQ          ,                 ");
		sql.append("       SERIAL       ,                 ");
		sql.append("       COMMENT_TITLE,                 ");
		sql.append("       COMMENT_TEXT                   ");
		sql.append("  FROM OCS0222                        ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code       ");
		sql.append("   AND SEQ       = :f_seq             ");
		sql.append("   AND MEMB      = :f_memb            ");
		sql.append(" ORDER BY SERIAL                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", memb);
		query.setParameter("f_seq", seq);
		
		List<OcsaOCS0221U00GrdOCS0222ListInfo> list = new JpaResultMapper().list(query, OcsaOCS0221U00GrdOCS0222ListInfo.class);
		return list;
	}
	
	public List<OCS0221Q01GrdOCS0222Info> getOCS0221Q01GrdOCS0222Info (String hospCode, String memb, String seq) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT MEMB         ,				");
		sql.append("	       SEQ          ,               ");
		sql.append("	       SERIAL       ,               ");
		sql.append("	       COMMENT_TITLE,               ");
		sql.append("	       COMMENT_TEXT                 ");
		sql.append("	  FROM OCS0222                      ");
		sql.append("	 WHERE HOSP_CODE = :f_hosp_code     ");
		sql.append("	   AND MEMB      = :f_memb          ");
		sql.append("	   AND SEQ       = :f_seq           ");
		sql.append("	UNION ALL                           ");
		sql.append("	SELECT :f_memb          MEMB,       ");
		sql.append("	       A.SEQ                ,       ");
		sql.append("	       A.SERIAL + 100 SERIAL,       ");
		sql.append("	       A.COMMENT_TITLE      ,       ");
		sql.append("	       A.COMMENT_TEXT               ");
		sql.append("	  FROM OCS0222 A                    ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code   ");
		sql.append("	   AND A.MEMB      = 'ADMIN'        ");
		sql.append("	   AND A.SEQ       = :f_seq         ");
		sql.append("	 ORDER BY 3                         ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", memb);
		query.setParameter("f_seq", seq);
		
		List<OCS0221Q01GrdOCS0222Info> list = new JpaResultMapper().list(query, OCS0221Q01GrdOCS0222Info.class);
		return list;
	}
}

