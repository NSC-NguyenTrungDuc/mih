package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0223RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0223U00GrdOCS0223Info;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Ocs0223RepositoryImpl implements Ocs0223RepositoryCustom {
private static final Log LOG = LogFactory.getLog(Ocs0223RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	public List<OCS0223U00GrdOCS0223Info> getOCS0223U00GrdOCS0223Info(String hospitalCode, String language,
			String jundalPart){
		StringBuilder sql = new StringBuilder();
		 sql.append("SELECT B.CODE JUNDAL_PART,                                       ");
		 sql.append("       B.CODE_NAME JUNDAL_PART_NAME,                             ");
		 sql.append("       A.SEQ,                                                    ");
		 sql.append("       A.SERIAL,                                                 ");
		 sql.append("       A.COMMENT_TITLE,                                          ");
		 sql.append("       A.COMMENT_TEXT                                            ");
		 sql.append("FROM  OCS0132 B                                                  ");
		 sql.append("    , OCS0223 A                                                  ");
		 sql.append("WHERE  A.HOSP_CODE = :hospitalCode                               ");
		 sql.append("  AND B.LANGUAGE = :language                                     ");
		 if (!StringUtils.isEmpty(jundalPart)) {
			 sql.append("  AND  A.JUNDAL_PART LIKE :jundal_part                           ");
		 }
		 sql.append("  AND  B.CODE_TYPE = 'OCS_ACT_SYSTEM'                            ");
		 sql.append("  AND  B.HOSP_CODE = A.HOSP_CODE                                 ");
		 sql.append("  AND  B.CODE      = A.JUNDAL_PART                               ");
		 sql.append("ORDER BY B.SORT_KEY, JUNDAL_PART_NAME, A.SERIAL, A.COMMENT_TITLE ");
		   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		if (!StringUtils.isEmpty(jundalPart)) {
			query.setParameter("jundal_part", "%" + jundalPart + "%");
		}
		List<OCS0223U00GrdOCS0223Info> list = new JpaResultMapper().list(query, OCS0223U00GrdOCS0223Info.class);
		
		return list;
	}
}


