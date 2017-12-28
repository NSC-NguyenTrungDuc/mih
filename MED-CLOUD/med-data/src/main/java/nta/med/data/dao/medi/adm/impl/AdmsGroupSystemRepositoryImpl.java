package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.AdmsGroupSystemRepositoryCustom;
import nta.med.data.model.ihis.adma.ADMS2015U00GetSystemHospitalInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00SystemHospitalInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public class AdmsGroupSystemRepositoryImpl implements AdmsGroupSystemRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getADMS2015U01System(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SYSTEM_ID, B.SYS_NM                                         ");
		sql.append("  FROM ADMS_GROUP_SYSTEM A JOIN ADM0200 B ON A.SYSTEM_ID = B.SYS_ID AND A.GRP_ID = B.GRP_ID AND A.SELECT_FLG = 1 ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                    ");
		sql.append("   AND B.LANGUAGE = :f_language                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	
	public List<ADMS2015U00GetSystemHospitalInfo> getADMS2015U00GetSystemHospitalInfo(String hospitalCode, String admsGroupId, String language){
		StringBuffer sql = new StringBuffer();	
		sql.append("SELECT CAST(A.ADMS_GROUP_SYSTEM_ID AS CHAR) ADMS_GROUP_SYSTEM_ID,  ");
		sql.append("	       B.SYS_ID SYSTEM_ID,                                     "); 
		sql.append("	       CAST(A.SYSTEM_SEQ AS CHAR)  SYSTEM_SEQ,                 ");  
		sql.append("	       A.HOSP_CODE HOSP_CODE,                                  "); 
		sql.append("	       CAST(A.SELECT_FLG AS CHAR) SELECT_FLG ,                 ");  
		sql.append("	       B.SYS_NM                                                "); 
		sql.append("	FROM ADM0200 B LEFT JOIN ADMS_GROUP_SYSTEM A                   ");
		sql.append("  ON  A.GRP_ID  = B.GRP_ID                                         ");
		sql.append("  AND A.SYSTEM_ID = B.SYS_ID                                       ");
		sql.append("  AND A.HOSP_CODE = :hospital_code                                 ");
		sql.append("  WHERE                                                            ");
		sql.append("  B.LANGUAGE = :f_language                                         ");
		if (!StringUtils.isEmpty(admsGroupId)) {
			sql.append("	AND B.GRP_ID = :f_group_id                                    ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospital_code", hospitalCode);
		if (!StringUtils.isEmpty(admsGroupId)) {
			query.setParameter("f_group_id", admsGroupId);
		}
		query.setParameter("f_language", language);
		
		List<ADMS2015U00GetSystemHospitalInfo> list = new JpaResultMapper().list(query, ADMS2015U00GetSystemHospitalInfo.class);
		return list;
	}

	
	@Override
	public String getADMS2015U01SystemIdValidating(String hospCode, String language, String sysId){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT B.SYS_NM                                                       ");
		sql.append("  FROM ADMS_GROUP_SYSTEM A JOIN ADM0200 B ON A.SYSTEM_ID = B.SYS_ID   ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                     ");
		sql.append("   AND B.LANGUAGE = :f_language                                       ");
		sql.append("   AND B.SYS_ID = :f_sys_id                                           ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sys_id", sysId);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

}

