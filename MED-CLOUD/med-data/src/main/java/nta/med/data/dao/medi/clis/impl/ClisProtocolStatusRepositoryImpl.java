package nta.med.data.dao.medi.clis.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.clis.ClisProtocolStatusRepositoryCustom;
import nta.med.data.model.ihis.clis.CLIS2015U02GrdStatusInfo;

public class ClisProtocolStatusRepositoryImpl implements ClisProtocolStatusRepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CLIS2015U02GrdStatusInfo> getCLIS2015U02GrdStatusInfo(Integer clisProtocolId, String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CLIS_PROTOCOL_ID,                                                                              ");
		sql.append("       A.CLIS_PROTOCOL_STATUS_ID STATUS_ID,                                                             ");
		sql.append("       A.CODE STATUS_CODE,                                                                              ");
		sql.append("       B.CODE_NAME STATUS_NAME,                                                                         ");
		sql.append("       A.SORT_NO,														                                ");
		sql.append("       A.DISPLAY_FLG                                                                                    ");
		sql.append("  FROM BAS0102 B LEFT JOIN CLIS_PROTOCOL_STATUS A ON A.CODE = B.CODE AND B.CODE_TYPE = 'CLIS_STATUS'    ");
		sql.append(" WHERE A.ACTIVE_FLG = 1                                                                                 ");
		sql.append("   AND A.CLIS_PROTOCOL_ID = :f_clis_protocol_id                                                         ");
		sql.append("   AND B.HOSP_CODE = :hospCode				                                                            ");
		sql.append("   AND B.LANGUAGE = :language				                                                            ");
		sql.append("   ORDER BY SORT_NO                                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_clis_protocol_id", clisProtocolId);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);

		List<CLIS2015U02GrdStatusInfo> list = new JpaResultMapper().list(query, CLIS2015U02GrdStatusInfo.class);
		return list;
	}
}
