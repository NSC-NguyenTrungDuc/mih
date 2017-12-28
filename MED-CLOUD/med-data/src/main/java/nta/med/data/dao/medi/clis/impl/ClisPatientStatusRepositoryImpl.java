package nta.med.data.dao.medi.clis.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import org.springframework.util.StringUtils;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.clis.ClisPatientStatusRepositoryCustom;
import nta.med.data.model.ihis.clis.CLIS2015U04GetPatientStatusListItemInfo;

public class ClisPatientStatusRepositoryImpl  implements ClisPatientStatusRepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CLIS2015U04GetPatientStatusListItemInfo> getCLIS2015U04GetPatientStatusListItemInfo(String protocolPatientId, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT ");
		sql.append("       CLIS_PATIENT_STATUS.PATIENT_STATUS_ID,																																										");
		sql.append("       CLIS_PATIENT_STATUS.DESCRIPTION,																																												");
		sql.append("       CLIS_PATIENT_STATUS.UPDATED,																																													");
		sql.append("       CLIS_PATIENT_STATUS.UPDATE_DATE,																																												");
		sql.append("       BAS0102.CODE_NAME,																																															");
		sql.append("       CLIS_PROTOCOL_STATUS.SORT_NO,																																												");
		sql.append("       CLIS_PATIENT_STATUS.SYS_ID,																																													");
		sql.append("       BAS0102.CODE,																							            																						");
		sql.append("       CLIS_PROTOCOL_PATIENT.PROTOCOL_PATIENT_ID																																									");
		sql.append("  	FROM CLIS_PROTOCOL_PATIENT          																																											");
		sql.append("    LEFT JOIN CLIS_PROTOCOL_STATUS on CLIS_PROTOCOL_PATIENT.CLIS_PROTOCOL_ID = CLIS_PROTOCOL_STATUS.CLIS_PROTOCOL_ID 	    																						");
		sql.append("    LEFT JOIN CLIS_PATIENT_STATUS on (CLIS_PROTOCOL_STATUS.CODE = CLIS_PATIENT_STATUS.CODE AND CLIS_PROTOCOL_PATIENT.PROTOCOL_PATIENT_ID = CLIS_PATIENT_STATUS.PROTOCOL_PATIENT_ID) 								");
		sql.append("    LEFT JOIN BAS0102 on CLIS_PROTOCOL_STATUS.CODE = BAS0102.CODE 													 																								");
		sql.append("  	WHERE 1 = 1                 																																													");
		sql.append("  	AND CLIS_PROTOCOL_PATIENT.ACTIVE_FLG = 1          																																								");
		sql.append(" 	AND BAS0102.CODE_TYPE = 'CLIS_STATUS' 																																											");
		if (!StringUtils.isEmpty(protocolPatientId)) {
			sql.append(" 	AND CLIS_PROTOCOL_PATIENT.PROTOCOL_PATIENT_ID = :f_protocol_patient_id 																																		");
		}
		if (!StringUtils.isEmpty(hospCode)) {
			sql.append(" 	AND BAS0102.HOSP_CODE = :f_hosp_code 																																										");
		}
		sql.append("  	ORDER BY CLIS_PROTOCOL_STATUS.SORT_NO ASC;       																																								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (!StringUtils.isEmpty(protocolPatientId)) {
			query.setParameter("f_protocol_patient_id", protocolPatientId);
		} 
		if (!StringUtils.isEmpty(hospCode)) {
			query.setParameter("f_hosp_code", hospCode);
		}

		List<CLIS2015U04GetPatientStatusListItemInfo> list = new JpaResultMapper().list(
				query, CLIS2015U04GetPatientStatusListItemInfo.class);
		return list;
	}

}
