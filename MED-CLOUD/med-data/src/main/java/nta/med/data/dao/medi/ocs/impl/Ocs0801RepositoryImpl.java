package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0801RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.endo.END1001U02DsvLDOCS0801Info;
import nta.med.data.model.ihis.ocsa.OCS0801U00GrdOCS0801ListItemInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00DsvLDOCS0801Info;

import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Ocs0801RepositoryImpl implements Ocs0801RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getOCS0803U00GetFindWorker(String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PAT_STATUS, A.PAT_STATUS_NAME     FROM OCS0801 A          ");
		sql.append(" WHERE A.LANGUAGE =:f_language                                      ");
		sql.append(" ORDER BY A.PAT_STATUS												");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	
	@Override
	public List<OCS0801U00GrdOCS0801ListItemInfo> getOCS0801U00GrdOCS0801ListItem(String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.PAT_STATUS,       			");
		sql.append("	A.PAT_STATUS_NAME,                  ");
		sql.append("	A.MENT,                             ");
		sql.append("	A.SEQ,                              ");
		sql.append("	''	                                ");
		sql.append("	FROM OCS0801 A                      ");
		sql.append("	WHERE A.LANGUAGE  = :language       ");
		sql.append("	ORDER BY A.PAT_STATUS               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		List<OCS0801U00GrdOCS0801ListItemInfo> list = new JpaResultMapper().list(query, OCS0801U00GrdOCS0801ListItemInfo.class);
		return list;
	}

	@Override
	public String getOCS0801getCodeNameOcs0801(String code,String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.PAT_STATUS_NAME			 ");
		sql.append("	FROM OCS0801 A   					 ");
		sql.append("	WHERE A.LANGUAGE  = :language        ");
		sql.append("	AND A.PAT_STATUS = :f_code    	     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("f_code", code);
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getOCS0801TransactionDupCheck(String patStatus, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'							");
		sql.append("	 FROM OCS0801                       ");
		sql.append("	WHERE PAT_STATUS = :f_pat_status    ");
		sql.append("	  AND LANGUAGE = :language          ");
		sql.append("	  LIMIT 1                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("f_pat_status", patStatus);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<XRT1002U00DsvLDOCS0801Info> getXRT1002U00DsvLDOCS0801Info (String hospCode, String language, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.PAT_STATUS           ,                   ");
		sql.append("       A.PAT_STATUS_NAME      ,                   ");
		sql.append("       B.PAT_STATUS_CODE      ,                   ");
		sql.append("       B.PAT_STATUS_CODE_NAME ,                   ");
		sql.append("       C.INDISPENSABLE_YN                         ");
		sql.append("  FROM OCS0103 D,                                 ");
		sql.append("       OCS0804 C,                                 ");
		sql.append("       OCS0802 B,                                 ");
		sql.append("       OCS0801 A                                  ");
		sql.append(" WHERE D.HOSP_CODE          = :f_hosp_code        ");
		sql.append("   AND D.HANGMOG_CODE       = :f_hangmog_code     ");
		sql.append("   AND A.LANGUAGE = :language                     ");
		sql.append("   AND B.LANGUAGE = :language                     ");
		sql.append("   AND C.PAT_STATUS_GR      = D.PAT_STATUS_GR     ");
		sql.append("   AND C.HOSP_CODE          = D.HOSP_CODE         ");
		sql.append("   AND B.PAT_STATUS         = C.PAT_STATUS        ");
		sql.append("   AND B.HOSP_CODE          = D.HOSP_CODE         ");
		sql.append("   AND A.PAT_STATUS         = B.PAT_STATUS        ");
		sql.append(" ORDER BY A.PAT_STATUS, B.SEQ, B.PAT_STATUS_CODE  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		List<XRT1002U00DsvLDOCS0801Info> list = new JpaResultMapper().list(query, XRT1002U00DsvLDOCS0801Info.class);
		return list;
	}


	@Override
	public List<END1001U02DsvLDOCS0801Info> getEND1001U02DsvLDOCS0801Info(
			String hospCode, String language, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PAT_STATUS                                ");
		sql.append("     , A.PAT_STATUS_NAME                            ");
		sql.append("     , B.PAT_STATUS_CODE                            ");
		sql.append("     , B.PAT_STATUS_CODE_NAME                       ");
		sql.append("     , C.INDISPENSABLE_YN                           ");
		sql.append("  FROM OCS0103 D,                                   ");
		sql.append("       OCS0804 C,                                   ");
		sql.append("       OCS0802 B,                                   ");
		sql.append("       OCS0801 A                                    ");
		sql.append(" WHERE D.HANGMOG_CODE       = :f_hangmog_code       ");
		sql.append("   AND C.PAT_STATUS_GR      = D.PAT_STATUS_GR       ");
		sql.append("   AND B.PAT_STATUS         = C.PAT_STATUS          ");
		sql.append("   AND B.LANGUAGE           = :f_language           ");
		sql.append("   AND A.LANGUAGE           = :f_language           ");
		sql.append("   AND A.PAT_STATUS         = B.PAT_STATUS          ");
		sql.append("   AND D.HOSP_CODE          = :f_hosp_code			");
		sql.append("   AND B.HOSP_CODE          = :f_hosp_code			");
		sql.append("   AND C.HOSP_CODE          = :f_hosp_code			");
		   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		List<END1001U02DsvLDOCS0801Info> list = new JpaResultMapper().list(query, END1001U02DsvLDOCS0801Info.class);
		return list;
	}
}

