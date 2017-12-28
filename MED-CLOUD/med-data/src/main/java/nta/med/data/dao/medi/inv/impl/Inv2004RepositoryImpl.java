package nta.med.data.dao.medi.inv.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inv.Inv2004RepositoryCustom;
import nta.med.data.model.ihis.invs.INV2003U00GrdINV2004Info;

public class Inv2004RepositoryImpl implements Inv2004RepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<INV2003U00GrdINV2004Info> getGridINV2004Info(String hospCode, Double fkinv2003, String language) {
		
			StringBuilder sql = new StringBuilder();
			sql.append("   SELECT A.PKINV2004           AS PKINV2004                             						    ");
			sql.append("   , A.FKINV2003                AS FKINV2003                             						    ");
			sql.append("   , A.JAERYO_CODE              AS JAERYO_CODE                           						    ");
			sql.append("   , B.JAERYO_NAME              AS JAERYO_NAME                           						    ");
			sql.append("   , A.CHULGO_QTY               AS CHULGO_QTY                            						    ");
			sql.append("   , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.SUBUL_DANUI, :f_hosp_code, :f_language) CHULGO_DANUI_NAME  ");
			sql.append("   , A.CHULGO_DANGA             AS CHULGO_DANGA                           							");
			sql.append("   , A.REMARK                   AS REMARK                                 							");
			sql.append("   FROM INV0110 B, INV2004 A                                              							");
			sql.append("   WHERE A.HOSP_CODE              = :f_hosp_code                          							");
			sql.append("   AND A.FKINV2003                = :f_fkinv2003                          							");
			sql.append("   AND B.HOSP_CODE                = A.HOSP_CODE                           							");
			sql.append("   AND B.JAERYO_CODE              = A.JAERYO_CODE                         							");
			sql.append("   ORDER BY B.JAERYO_NAME                                                 							");

			 
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_fkinv2003", fkinv2003);
			query.setParameter("f_language", language);
			
			List<INV2003U00GrdINV2004Info> listData = new JpaResultMapper().list(query, INV2003U00GrdINV2004Info.class);
			return listData;		
		}
}
