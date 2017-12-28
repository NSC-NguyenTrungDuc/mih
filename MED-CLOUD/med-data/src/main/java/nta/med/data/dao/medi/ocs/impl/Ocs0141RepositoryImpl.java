package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import nta.med.data.dao.medi.ocs.Ocs0141RepositoryCustom;
import nta.med.data.model.ihis.nuro.OcsLoadVisibleControlListItemInfo;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;

/**
 * @author dainguyen.
 */
public class Ocs0141RepositoryImpl implements Ocs0141RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<OcsLoadVisibleControlListItemInfo> getOcslibVisibleListItem(String inputTab) {
		StringBuilder sql = new StringBuilder();

		sql.append("	SELECT A.INPUT_TAB  input_tab  ,         					");             
		sql.append("	       A.COL_NAME    col_name   ,                           ");
		sql.append("	       A.VISIBLE_YN  visible_yn                             ");
		sql.append("	  FROM OCS0141 A                                            ");
		sql.append("	 WHERE  A.INPUT_TAB  LIKE CONCAT(TRIM(:inputTab),'%')       ");
		sql.append("	   ORDER BY A.INPUT_TAB, A.COL_NAME                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("inputTab", inputTab);
		List<OcsLoadVisibleControlListItemInfo> listResult = new JpaResultMapper().list(query, OcsLoadVisibleControlListItemInfo.class);
		return listResult;
	}
}

