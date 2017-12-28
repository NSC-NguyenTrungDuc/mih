package nta.med.data.dao.medi.bas.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.SysPropertySRepositoryCustom;
import nta.med.data.model.ihis.bass.LoadCbxLanguageInfo;

public class SysPropertySRepositoryImpl implements SysPropertySRepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<LoadCbxLanguageInfo> getCbxLanguageInfo(String propertyCode, String activeFlg){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	   SELECT A.PROPERTY_ID, 																				    ");    
		sql.append("              A.PROPERTY_CODE,	                                                                                ");
		sql.append("              A.PROPERTY_NAME,	                                                                                "); 
		sql.append("              A.PROPERTY_VALUE,  	                                                                            ");
		sql.append("              A.PROPERTY_TYPE,  	                                                                            ");
		sql.append("              A.MODULE_TYPE,  	                                                                                ");
		sql.append("              A.DEFAULT_FLG,		  	                                                                        ");
		sql.append("              A.SORT_NO,	  	                                                                                ");
		sql.append("              A.DESCRIPTION,	                                                                                ");
		sql.append("              A.LOCALE,	                                                                                        ");
		sql.append("              A.SYS_ID,	                                                                                        ");
		sql.append("              A.UPD_ID,		  	                                                                                ");
		sql.append("              A.CREATED,	  	                                                                                ");
		sql.append("              A.UPDATED,	                                                                                    ");
		sql.append("              A.ACTIVE_FLG	                                                                                    ");
		sql.append("	FROM SYS_PROPERTYS A                                                                                        ");
		sql.append("	WHERE A.PROPERTY_CODE    = :f_property_code                                                                 ");
		if (!StringUtils.isEmpty(activeFlg)) {
			sql.append("	  AND A.ACTIVE_FLG      = :f_active_flg                                                                 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_property_code", propertyCode);
		if (!StringUtils.isEmpty(activeFlg)) {
			query.setParameter("f_active_flg", activeFlg);
		}
		
		List<LoadCbxLanguageInfo> list = new JpaResultMapper().list(query, LoadCbxLanguageInfo.class);
		return list;
	}
}
