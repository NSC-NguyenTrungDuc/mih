package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0803RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0803U00grdOCS0803ItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * @author dainguyen.
 */
public class Ocs0803RepositoryImpl implements Ocs0803RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Ocs0803RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS0803U00grdOCS0803ItemInfo> getOCS0803U00grdOCS0803(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PAT_STATUS_GR  , A.PAT_STATUS_GR_NAME, A.MENT ,  A.SEQ           ");
		sql.append(" FROM OCS0803 A WHERE A.HOSP_CODE  = :f_hosp_code AND A.LANGUAGE = :f_language ORDER BY A.PAT_STATUS_GR ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<OCS0803U00grdOCS0803ItemInfo> list = new JpaResultMapper().list(query, OCS0803U00grdOCS0803ItemInfo.class);
		return list;
	}


	@Override
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.PAT_STATUS_GR, A.PAT_STATUS_GR_NAME       ");
		sql.append("   FROM OCS0803 A                                   ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                  ");
		sql.append("    AND A.LANGUAGE = :f_language                    ");
		sql.append("  ORDER BY A.PAT_STATUS_GR 							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
}

