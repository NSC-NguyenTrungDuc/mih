package nta.med.data.dao.emr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.emr.SysPropertyRepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.springframework.util.CollectionUtils;

public class SysPropertyRepositoryImpl implements SysPropertyRepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public ComboListItemInfo getPropertyValueInfo (String locale) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT PROPERTY_NAME,				");  //Subject email
		sql.append("	       PROPERTY_VALUE				");  //Content template email
		sql.append("	FROM SYS_PROPERTY                   ");
		sql.append("	WHERE PROPERTY_CODE = 'EMAIL_LOG'   ");
		sql.append("	  AND MODULE_TYPE = 'OCSO'          ");
		sql.append("	  AND LOCALE = :f_locale_server     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_locale_server", locale);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		if (!CollectionUtils.isEmpty(result) && result.get(0) != null) {
			return result.get(0);
		}
		return null;
	}
}
