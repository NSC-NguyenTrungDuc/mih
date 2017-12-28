package nta.med.data.dao.medi.inv.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inv.Inv6002RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.invs.INV6002U00GrdINV6002LoadcbxActorInfo;

public class Inv6002RepositoryImpl implements Inv6002RepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<ComboListItemInfo> getINV6002U00GrdINV6002LoadcbxActorInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT B.CODE                             			    ");
		sql.append("      , B.CODE_NAME                             					");
		sql.append("   FROM INV0102 B                             						");
		sql.append("      , INV0101 A                             						");
		sql.append("  WHERE  A.CODE_TYPE = 'JAERYO_GUBUN' 	                            ");
		sql.append("    AND B.CODE_TYPE = A.CODE_TYPE      								");
		sql.append("    AND B.LANGUAGE = :f_language     								");
		sql.append("    AND B.LANGUAGE = A.LANGUAGE      								");
		sql.append(" AND B.HOSP_CODE = :hosp_code                                       ");
		sql.append("  ORDER BY                                                    		");
		sql.append("                    B.SORT_KEY                        				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<INV6002U00GrdINV6002LoadcbxActorInfo> getINV6002LoadcbxActorInfos(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.USER_ID									  							");
		sql.append("     , A.USER_NM    								       						");
		sql.append("  FROM ADM3200 A									     						");
		sql.append(" WHERE A.HOSP_CODE   = :hosp_code           		     						");
		sql.append("   AND A.USER_GROUP  = 'DRG'						                            ");
		sql.append("   AND IFNULL(A.USER_END_YMD, '9998/12/31') >= NOW()							");
		sql.append(" ORDER BY USER_ID IS NULL 								                		");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		
		List<INV6002U00GrdINV6002LoadcbxActorInfo> list = new JpaResultMapper().list(query, INV6002U00GrdINV6002LoadcbxActorInfo.class);
		return list;
	}
}
