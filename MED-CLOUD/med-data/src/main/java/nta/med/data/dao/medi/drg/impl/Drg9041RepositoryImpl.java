package nta.med.data.dao.medi.drg.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.drg.Drg9041RepositoryCustom;
import nta.med.data.model.ihis.drgs.DRG9040U01LayPaCommentInfo;

/**
 * @author dainguyen.
 */
public class Drg9041RepositoryImpl implements Drg9041RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DRG9040U01LayPaCommentInfo> getDRG9040U01LayPaCommentInfo(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT ORDER_REMARK             ");
		sql.append("     , DRG_REMARK               ");
		sql.append("  FROM DRG9041                  ");
		sql.append(" WHERE BUNHO = :f_bunho         ");
		sql.append("   AND HOSP_CODE = :f_hosp_code ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hosp_code", hospCode);
		
		List<DRG9040U01LayPaCommentInfo> list = new JpaResultMapper().list(query, DRG9040U01LayPaCommentInfo.class);
		return list;
	}
}

