package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.model.ihis.ocsa.Ocs0204Q00GrdOcs0204ListItemInfo;
import nta.med.data.dao.medi.ocs.Ocs0204RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00GrdOCS0204ListInfo;

/**
 * @author dainguyen.
 */
public class Ocs0204RepositoryImpl implements Ocs0204RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OcsaOCS0204U00GrdOCS0204ListInfo> getOcsaOCS0204U00GrdOCS0204List(String hospCode, String fMemb, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(A.MEMB           , ' ') MEMB           ,  ");
		sql.append("       IFNULL(A.SEQ            , 0  ) SEQ            ,  ");
		sql.append("       IFNULL(A.SANG_GUBUN     , ' ') SANG_GUBUN     ,  ");
		sql.append("       IFNULL(A.SANG_GUBUN_NAME, ' ') SANG_GUBUN_NAME   ");
		sql.append("  FROM OCS0204 A                                        ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                      ");
		sql.append("   AND A.MEMB       = :f_memb                           ");
		sql.append("   AND A.LANGUAGE   = :f_language                       ");
		sql.append("   AND A.MEMB_GUBUN = '1'                               ");
		sql.append(" ORDER BY 2                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", fMemb);
		query.setParameter("f_language", language);

		List<OcsaOCS0204U00GrdOCS0204ListInfo> list = new JpaResultMapper().list(query, OcsaOCS0204U00GrdOCS0204ListInfo.class);
		return list;
	}

	@Override
	public String getLoadColumnCodeNameSangGubunCase(String memb,
			String sangGubun, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SANG_GUBUN_NAME 			");
		sql.append("	 FROM OCS0204 A                     ");
		sql.append("	WHERE A.MEMB = :memb                ");
		sql.append("	  AND A.SANG_GUBUN = :sangGubun     ");
		sql.append("	  AND A.HOSP_CODE    = :hospCode    ");
		sql.append("      AND A.LANGUAGE   = :f_language    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("memb", memb);
		query.setParameter("sangGubun", sangGubun);
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	public List<Ocs0204Q00GrdOcs0204ListItemInfo> getOcs0204Q00GrdOcs0204ListItemInfo(String hospCode, String fMemb, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.MEMB , ' ') MEMB,	");
		sql.append("	IFNULL(A.SANG_GUBUN , ' ') SANG_GUBUN,	");
		sql.append("	IFNULL(A.SANG_GUBUN_NAME, ' ') SANG_GUBUN_NAME,	");
		sql.append("	A.SEQ	");
		sql.append("	FROM OCS0204 A	");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code	");
		sql.append("	  AND A.MEMB = :f_memb				");
		sql.append("      AND A.LANGUAGE   = :f_language    ");
		sql.append("	ORDER BY A.SEQ	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", fMemb);
		query.setParameter("f_language", language);

		List<Ocs0204Q00GrdOcs0204ListItemInfo> list = new JpaResultMapper().list(query, Ocs0204Q00GrdOcs0204ListItemInfo.class);
		return list;		
	}
}

