package nta.med.data.dao.medi.clis.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.clis.ClisProtocolPatientRepositoryCustom;
import nta.med.data.model.ihis.clis.CLIS2015U04GetPatientListItemInfo;
import nta.med.data.model.ihis.emr.EMRGetLatestWarningStatusInfo;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

public class ClisProtocolPatientRepositoryImpl  implements ClisProtocolPatientRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getXRT0201U00ToolTipInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		                                                                                                                          
		sql. append("	SELECT COUNT(A.CLIS_PROTOCOL_ID) AS NUM_PROTOCOL                                                          ");
		sql. append("	FROM CLIS_PROTOCOL_PATIENT A LEFT JOIN CLIS_PROTOCOL B ON A.CLIS_PROTOCOL_ID = B.CLIS_PROTOCOL_ID         ");                                                                                                       
		sql. append("	WHERE A.HOSP_CODE =:hospCode                                                                              ");  
		sql. append("	AND A.BUNHO = :patientCode                                                                                ");
		sql. append("	AND A.ACTIVE_FLG = 1                                                                                      ");
		sql. append("	AND B.ACTIVE_FLG = 1                                                                                      ");
		sql. append("	AND B.STATUS_FLG <> 1                                                                                     ");
		sql. append("	AND B.END_DATE <= SYSDATE()                                                                               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", bunho);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}

	@Override
	public String getYByBunho(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  'Y'                                            ");
		sql.append(" FROM   CLIS_PROTOCOL A, CLIS_PROTOCOL_PATIENT   B      ");
		sql.append(" WHERE                                                  ");
		sql.append(" B.HOSP_CODE = :f_hosp_code AND                         ");
		sql.append(" B.BUNHO = :f_bunho AND                                 ");
		sql.append(" A.STATUS_FLG = '02'									");                                
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return "N";// if not found result then return N
	}
	
	@Override
	public List<CLIS2015U04GetPatientListItemInfo> getCLIS2015U04GetPatientListItemInfo(
			String clisProtocolId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT ");
		sql.append("       CLIS_PROTOCOL_PATIENT.PROTOCOL_PATIENT_ID,						");
		sql.append("       CLIS_PROTOCOL_PATIENT.BUNHO,										");
		sql.append("       OUT0101.SUNAME,													");
		sql.append("       OUT0101.SUNAME2													");
		sql.append("  	FROM CLIS_PROTOCOL_PATIENT          								");
		sql.append("    LEFT JOIN OUT0101 ON OUT0101.BUNHO = CLIS_PROTOCOL_PATIENT.BUNHO 	");
		sql.append("  	WHERE 1 = 1                 										");
		sql.append("  	AND CLIS_PROTOCOL_PATIENT.ACTIVE_FLG = 1          					");
		if (!StringUtils.isEmpty(clisProtocolId)) {
			sql.append("   AND CLIS_PROTOCOL_PATIENT.CLIS_PROTOCOL_ID = :f_clis_protocol_id ");
		}
		sql.append("  	ORDER BY CLIS_PROTOCOL_PATIENT.PROTOCOL_PATIENT_ID ASC;       		");


		Query query = entityManager.createNativeQuery(sql.toString());
		if (!StringUtils.isEmpty(clisProtocolId)) {
			query.setParameter("f_clis_protocol_id", clisProtocolId);
		}

		List<CLIS2015U04GetPatientListItemInfo> list = new JpaResultMapper()
				.list(query, CLIS2015U04GetPatientListItemInfo.class);
		return list;
	}


	@Override
	public List<String> getYByBunhoAndClisProtocolId(String hospCode, String bunho, Integer clisProtocolId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y'                           ");
		sql.append(" FROM  CLIS_PROTOCOL_PATIENT          ");
		sql.append(" WHERE                                ");
		sql.append(" HOSP_CODE = :f_hosp_code  AND        ");
		sql.append(" BUNHO = :f_bunho  AND                ");
		sql.append(" CLIS_PROTOCOL_ID <> :f_protocol_id   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_protocol_id", clisProtocolId);
		
		List<String> result = query.getResultList();
		return result;
	}

	@Override
	public EMRGetLatestWarningStatusInfo getLatestWarningStatusInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 																			                   ");
		sql.append(" 	B.CLIS_PROTOCOL_ID, 														                       ");
		sql.append(" 	C.CODE, 																	                       ");
		sql.append(" 	E.CODE_NAME,																                       ");
		sql.append(" 	C.UPDATE_DATE AS UPDATED,					     					    	                       ");
		sql.append(" 	D.DISPLAY_FLG																                       ");
		sql.append(" FROM																			                       ");
		sql.append("     	CLIS_PROTOCOL_PATIENT A													                       ");
		sql.append("         		LEFT JOIN														                       ");
		sql.append("     	CLIS_PROTOCOL B ON A.CLIS_PROTOCOL_ID = B.CLIS_PROTOCOL_ID				                       ");
		sql.append(" 		LEFT JOIN																                       ");
		sql.append("     	CLIS_PATIENT_STATUS C ON C.PROTOCOL_PATIENT_ID = A.PROTOCOL_PATIENT_ID	                       ");
		sql.append(" 		LEFT JOIN																                       ");
		sql.append("     	CLIS_PROTOCOL_STATUS D ON B.CLIS_PROTOCOL_ID = D.CLIS_PROTOCOL_ID  AND C.CODE = D.CODE 	       ");
		sql.append(" 		LEFT JOIN																                       ");
		sql.append(" 	BAS0102 E ON C.CODE = E.CODE												                       ");
		sql.append(" WHERE																			                       ");
		sql.append(" 	A.HOSP_CODE = :hospCode									AND					                       ");
		sql.append(" 	A.ACTIVE_FLG = 1										AND					                       ");
		sql.append(" 	B.STATUS_FLG IN (02 , 03)								AND					                       ");
		sql.append(" 	B.END_DATE >= CURDATE()									AND					                       ");
		sql.append(" 	B.ACTIVE_FLG = 1										AND					                       ");
		sql.append(" 	C.ACTIVE_FLG = 1										AND					                       ");
		sql.append(" 	D.ACTIVE_FLG = 1										AND			                               ");
		sql.append("   C.UPDATE_DATE			IS NOT NULL                     AND                                        ");
		sql.append(" 	A.BUNHO = :bunho										AND					                       ");
		sql.append(" 	E.CODE_TYPE = 'CLIS_STATUS'								AND					                       ");
		sql.append(" 	E.HOSP_CODE = :hospCode									AND					                       ");
		sql.append("   D.DISPLAY_FLG = 'Y' ORDER BY C.UPDATE_DATE DESC , D.SORT_NO DESC LIMIT 1                            ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		List<EMRGetLatestWarningStatusInfo> result = new JpaResultMapper().list(query, EMRGetLatestWarningStatusInfo.class);
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}


}
