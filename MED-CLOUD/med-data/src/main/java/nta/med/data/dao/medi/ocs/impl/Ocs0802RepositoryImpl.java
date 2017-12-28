package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0802RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocso.OCS0801U00GrdOCS0802ListItemInfo;

import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Ocs0802RepositoryImpl implements Ocs0802RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getOCS0803U00GetFindWorker(String hospCode, String language, String patStatus) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PAT_STATUS_CODE, A.PAT_STATUS_CODE_NAME    FROM OCS0802 A                ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code AND A.LANGUAGE=:f_language                      ");
		sql.append(" AND A.PAT_STATUS  =  :f_pat_status ORDER BY IFNULL(A.SEQ, 99), A.PAT_STATUS_CODE  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_pat_status", patStatus);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public String getOCS0801U00GetCodeNameOcs0802(String hospCode, String code,
			String patStatus, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PAT_STATUS_CODE_NAME				");
		sql.append("	FROM OCS0802 A                              ");
		sql.append("	WHERE A.HOSP_CODE       = :f_hosp_code      ");
		sql.append("	AND A.PAT_STATUS_CODE = :f_code             ");
		sql.append("	AND A.PAT_STATUS      = :f_pat_status       ");
		sql.append("	AND A.LANGUAGE      = :language       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		query.setParameter("f_pat_status", patStatus);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if( !CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getOCS0801TransactionDupCheck(String hospCode,
			String language, String patStatus, String patStatusCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'										");
		sql.append("	 FROM OCS0802                                   ");
		sql.append("	WHERE PAT_STATUS      = :f_pat_status           ");
		sql.append("	  AND PAT_STATUS_CODE = :f_pat_status_code      ");
		sql.append("	  AND HOSP_CODE       = :f_hosp_code            ");
		sql.append("	  AND LANGUAGE  = :language                     ");
		sql.append("	  LIMIT 1                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_pat_status", patStatusCode);
		query.setParameter("f_pat_status_code", patStatusCode);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if( !CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS0801U00GrdOCS0802ListItemInfo> getOCS0801U00GrdOCS0802ListItem(
			String hospCode, String patStatus, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PAT_STATUS          ,																");
		sql.append("	       A.PAT_STATUS_CODE     ,                                                             " );
		sql.append("	       A.PAT_STATUS_CODE_NAME,                                                             " );
		sql.append("	       A.MENT                ,                                                             " );
		sql.append("	       A.SEQ                 ,                                                             " );
		sql.append("	       CONCAT(LTRIM(LPAD(IFNULL(A.SEQ, 99), 5,'0')),A.PAT_STATUS_CODE) CONT_KEY            " );
		sql.append("	  FROM OCS0802 A                                                                           " );
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code                                                         " );
		sql.append("	   AND A.PAT_STATUS = :f_pat_status                                                        " );
		sql.append("	   AND A.LANGUAGE = :language                                                              " );
		sql.append("	 ORDER BY IFNULL(A.SEQ, 99), A.PAT_STATUS_CODE                                             " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pat_status", patStatus);
		query.setParameter("language", language);
		
		List<OCS0801U00GrdOCS0802ListItemInfo> list = new JpaResultMapper().list(query, OCS0801U00GrdOCS0802ListItemInfo.class);
		return list;
	}
}

