package nta.med.data.dao.medi.xrt.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.xrt.Xrt1001RepositoryCustom;
import nta.med.data.model.ihis.xrts.XRT1002U00DsvSideEffectInfo;

/**
 * @author dainguyen.
 */
public class Xrt1001RepositoryImpl implements Xrt1001RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<XRT1002U00DsvSideEffectInfo> getXRT1002U00DsvSideEffectInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.FKXRT0201                                          ");
		sql.append("     , D.XRAY_DATE                                          ");
		sql.append("     , B.XRAY_NAME                                          ");
		sql.append("     , C.JAERYO_NAME                                        ");
		sql.append("     , A.REMARK                                             ");
		sql.append("     , A.SIDE_EFFECT1                                       ");
		sql.append("     , A.SIDE_EFFECT2                                       ");
		sql.append("     , A.SIDE_EFFECT3                                       ");
		sql.append("     , A.SIDE_EFFECT4                                       ");
		sql.append("     , A.SIDE_EFFECT5                                       ");
		sql.append("     , A.SIDE_EFFECT6                                       ");
		sql.append("     , A.SIDE_EFFECT7                                       ");
		sql.append("     , A.SIDE_EFFECT_TEXT                                   ");
		sql.append("  FROM XRT0201 D                                            ");
		sql.append("     , INV0110 C                                            ");
		sql.append("     , XRT0001 B                                            ");
		sql.append("     , XRT1001 A                                            ");
		sql.append("  WHERE A.HOSP_CODE       = :hosp_code                      ");
		sql.append("   AND A.BUNHO           = :bunho                           ");
		sql.append("   AND B.XRAY_CODE       = A.HANGMOG_CODE                   ");
		sql.append("   AND C.JAERYO_CODE     = A.JAERYO_CODE                    ");
		sql.append("   AND A.FKXRT0201       = D.PKXRT0201                      ");
		sql.append(" ORDER BY CONCAT(D.XRAY_DATE, IFNULL(D.XRAY_TIME,'X')) DESC ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		List<XRT1002U00DsvSideEffectInfo> list = new JpaResultMapper().list(query, XRT1002U00DsvSideEffectInfo.class);
		return list;
	}
}

