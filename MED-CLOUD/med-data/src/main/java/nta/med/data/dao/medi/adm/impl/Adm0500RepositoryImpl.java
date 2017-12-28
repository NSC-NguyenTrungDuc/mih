package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm0500RepositoryCustom;
import nta.med.data.model.ihis.system.MdiFormMainMenuItemInfo;

/**
 * @author dainguyen.
 */
public class Adm0500RepositoryImpl implements Adm0500RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<MdiFormMainMenuItemInfo> getMdiFormMainMenuItemInfo(String sysId, String hospCode){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT PGM_SYS_ID, PGM_ID FROM ADM0500 WHERE SYS_ID = :f_system_id AND HOSP_CODE = :f_hospCode");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_system_id", sysId);
		query.setParameter("f_hospCode", hospCode);
		
		List<MdiFormMainMenuItemInfo> result = new JpaResultMapper().list(query, MdiFormMainMenuItemInfo.class);
		return result;
	}
}

