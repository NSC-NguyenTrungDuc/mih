package nta.med.data.dao.medi.bas.impl;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0501RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0501U00CareFormTemplateInfo;

public class Bas0501RepositoryImpl implements Bas0501RepositoryCustom{
private static Log LOG = LogFactory.getLog(Bas0501RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<BAS0501U00CareFormTemplateInfo> getBas0501CareFormTemplate(String hospCode, String tplCode, String langauge) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.TPL_NAME,                                                                  ");
		sql.append("       A.FORMAT_TYPE,                                                               ");
		sql.append("       A.INPUT_CONTENT,                                                             ");
		sql.append("       A.PRINT_CONTENT								                                ");
		sql.append("  FROM BAS0501 A                                                                    ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                        							");
		sql.append("   AND A.TPL_CODE   = :f_tlp_code                                         			");
		sql.append("   AND A.LANGUAGE   = :f_language                                         			");
		sql.append("   AND A.ACTIVE_FLG   = 1                                         					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_tlp_code", tplCode);
		query.setParameter("f_language", langauge);
		List<BAS0501U00CareFormTemplateInfo> bas0501 = new JpaResultMapper().list(query, BAS0501U00CareFormTemplateInfo.class);
		return bas0501;
	}

	@Override
	public String getOCS2015U00GetHtmlContent(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		 sql.append("SELECT PRINT_CONTENT                                                           ");
		 sql.append("FROM BAS0501                                                                   ");
		 sql.append("WHERE  HOSP_CODE = :f_hosp_code                            		            ");
		 sql.append("   AND ACTIVE_FLG = '1'                                                        ");
		 sql.append("   AND FORMAT_TYPE = 'HTML'                                                    ");
		 sql.append("   AND TPL_TYPE = 'EMR'                                                        ");
		 sql.append("   AND LANGUAGE = :f_language                                                  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<String> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
}
