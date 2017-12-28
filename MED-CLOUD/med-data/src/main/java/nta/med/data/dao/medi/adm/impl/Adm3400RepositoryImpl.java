package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm3400RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public class Adm3400RepositoryImpl implements Adm3400RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getOCS2003U99IdBuseoRequest() {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT 							");
		sql.append("	       A.SYS_ID 							");
		sql.append("	     , A.USER_ID 							");
		sql.append("	  FROM ADM3400 A 							");
		sql.append("	 WHERE A.SYS_ID IN ('NURI') 				");
		sql.append("	   AND DATE(A.ENTR_TIME) = DATE(SYSDATE())	");
		sql.append("	 ORDER BY A.SYS_ID							");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
}

