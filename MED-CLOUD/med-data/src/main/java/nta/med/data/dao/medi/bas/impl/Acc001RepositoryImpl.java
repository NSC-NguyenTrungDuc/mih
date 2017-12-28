package nta.med.data.dao.medi.bas.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Acc001RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;

public class Acc001RepositoryImpl implements Acc001RepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getIfs0001U00AccountingSystemInfo(String find1, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE, NAME												");
		sql.append("	FROM ACC001	                                                    ");
		sql.append("	WHERE                                   						");
		sql.append("	(CODE LIKE :find1 OR NAME LIKE :find1)              			");
		sql.append("	AND LOCALE = :language                                          ");
		sql.append("	AND ACTIVE_FLG = 1                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("find1", "%" + find1 + "%");
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	

}
