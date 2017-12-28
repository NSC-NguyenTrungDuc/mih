package nta.med.data.dao.medi.pfe.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.pfe.Pfe0101RepositoryCustom;
import nta.med.data.model.ihis.adma.PFE0101U01GrdMcodeInfo;
import nta.med.data.model.ihis.pfes.PFE0101U00GrdMCodeInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Pfe0101RepositoryImpl implements Pfe0101RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Pfe0101RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<PFE0101U00GrdMCodeInfo> getPFE0101U00GrdMCodeInfo(String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(CODE_TYPE     , ' ')  CODE_TYPE              ");
		sql.append("      , IFNULL(CODE_TYPE_NAME, ' ')  CODE_TYPE_NAME         ");
		sql.append("   FROM PFE0101                                             ");
		sql.append("    WHERE CODE_TYPE LIKE :f_code_type                       ");
		sql.append("    AND LANGUAGE = :f_language                              ");
		sql.append("    AND ADMIN_GUBUN = 'USER'                                ");
		sql.append("  ORDER BY 1												");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%"+codeType+"%");
		query.setParameter("f_language", language);
		List<PFE0101U00GrdMCodeInfo> list = new JpaResultMapper().list(query, PFE0101U00GrdMCodeInfo.class);
		return list;
	}
	
	@Override
	public List<PFE0101U01GrdMcodeInfo> getPFE0101U01GrdMcodeInfo(String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(CODE_TYPE, ' ')       CODE_TYPE        ");
		sql.append("     , IFNULL(CODE_TYPE_NAME, ' ')  CODE_TYPE_NAME   ");
		sql.append("     , ADMIN_GUBUN                  ADMIN_GUBUN      ");
		sql.append("  FROM PFE0101                                       ");
		sql.append("   WHERE CODE_TYPE LIKE :f_code_type                 ");
		sql.append("    AND LANGUAGE = :f_language                       ");
		sql.append(" ORDER BY 1                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%"+codeType+"%");
		query.setParameter("f_language", language);
		List<PFE0101U01GrdMcodeInfo> list = new JpaResultMapper().list(query, PFE0101U01GrdMcodeInfo.class);
		return list;
	}
}

