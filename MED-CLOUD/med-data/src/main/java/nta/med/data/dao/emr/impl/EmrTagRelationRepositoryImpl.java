package nta.med.data.dao.emr.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.collections.CollectionUtils;

import nta.med.data.dao.emr.EmrTagRelationRepositoryCustom;

public class EmrTagRelationRepositoryImpl implements EmrTagRelationRepositoryCustom{

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public boolean isExisted(String tagChild, String tagParent, String templateId, String hospCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'  											");
		sql.append("	FROM EMR_TAG_RELATION A                         	 	");
		sql.append("	WHERE A.TAG_CHILD             = :tagChild   			");
		sql.append("	AND A.TAG_PARENT              = :tagParent              ");
		sql.append("	AND A.EMR_TEMPLATE_ID         = :templateId             ");
		sql.append("	AND A.HOSP_CODE               = :hospCode               ");
		sql.append("	AND A.ACTIVE_FLG              = '1'                     ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("tagChild", tagChild);
		query.setParameter("tagParent", tagParent);
		query.setParameter("templateId", templateId);
		query.setParameter("hospCode", hospCode);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		return false;
	}
	

}
