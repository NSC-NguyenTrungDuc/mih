package nta.med.data.dao.medi.clis.impl;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.clis.ClisProtocolRepositoryCustom;
import nta.med.data.model.ihis.clis.CLIS2015U02GrdProtocolInfo;
import nta.med.data.model.ihis.clis.CLIS2015U03ProtocolListInfo;
import nta.med.data.model.ihis.clis.CLIS2015U04GetPatientListItemInfo;
import nta.med.data.model.ihis.clis.CLIS2015U04GetPatientStatusListItemInfo;
import nta.med.data.model.ihis.clis.CLIS2015U04GetProtocolItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;




import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

public class ClisProtocolRepositoryImpl implements ClisProtocolRepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<CLIS2015U02GrdProtocolInfo> getCLIS2015U02GrdProtocolInfo(String hospCode, Integer clisSmoId, String bunho, String protocolCode,
			String protocolName, String status, Date startDate, Date endDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CLIS_PROTOCOL_ID,	                                                                                ");															
		sql.append("       A.PROTOCOL_CODE,											                                            ");
		sql.append("       A.PROTOCOL_NAME,											                                            ");
		sql.append("       A.START_DATE,											                                            ");
		sql.append("       A.END_DATE,												                                            ");
		sql.append("       A.STATUS_FLG,											                                            ");
		sql.append("       A.DESCRIPTION,                                                                                       ");
		sql.append("       A.RESOURCE                                                                                           ");
		sql.append("  FROM CLIS_PROTOCOL A                                                                                      ");
		if(!StringUtils.isEmpty(bunho)){
			sql.append("  JOIN CLIS_PROTOCOL_PATIENT B ON A.CLIS_PROTOCOL_ID = B.CLIS_PROTOCOL_ID AND A.HOSP_CODE = B.HOSP_CODE     ");
		}
		sql.append(" WHERE A.ACTIVE_FLG = 1                                                                                     ");
		sql.append("   AND A.HOSP_CODE = :f_hosp_code                                                                           ");
		if(!StringUtils.isEmpty(bunho)){
			sql.append("   AND B.ACTIVE_FLG = 1                                                                                     ");
			sql.append("   AND B.BUNHO =:f_bunho                                                                                    ");
		}else{
			sql.append("   AND A.CLIS_SMO_ID = :f_clis_smo_id                                                                       ");
		}
		if(!StringUtils.isEmpty(protocolCode)){
			sql.append("   AND A.PROTOCOL_CODE LIKE :f_protocol_code                                                                ");
		}
		if(!StringUtils.isEmpty(protocolName)){
			sql.append("   AND A.PROTOCOL_NAME LIKE :f_protocol_name                                                                ");
		}
		if(!StringUtils.isEmpty(status)){
			sql.append("   AND A.STATUS_FLG LIKE :f_status                                                                             ");	
		}
		sql.append("   AND A.START_DATE BETWEEN IFNULL(:f_start_date, STR_TO_DATE('0001/01/01', '%Y/%m/%d'))                    ");
		sql.append("                        AND IFNULL(:f_end_date, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))                      ");
		sql.append(" ORDER BY CLIS_PROTOCOL_ID ASC                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(!StringUtils.isEmpty(bunho)){
			query.setParameter("f_bunho", bunho);
		}else{
			query.setParameter("f_clis_smo_id", clisSmoId);
		}
		if(!StringUtils.isEmpty(protocolCode)){
			query.setParameter("f_protocol_code", protocolCode);
		}
		if(!StringUtils.isEmpty(protocolName)){
			query.setParameter("f_protocol_name", protocolName);
		}
		if(!StringUtils.isEmpty(status)){
			query.setParameter("f_status", status);
		}
		query.setParameter("f_start_date", startDate);
		query.setParameter("f_end_date", endDate);
		
		List<CLIS2015U02GrdProtocolInfo> list = new JpaResultMapper().list(query,CLIS2015U02GrdProtocolInfo.class);
		return list;
	}

	@Override
	public List<CLIS2015U03ProtocolListInfo> getCLIS2015U03ProtocolListInfo(String hospCode, String userId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                         ");
		sql.append(" A.CLIS_PROTOCOL_ID,                            ");    
		sql.append(" A.PROTOCOL_CODE,       						");    
		sql.append(" A.PROTOCOL_NAME                                ");     
		sql.append(" FROM CLIS_PROTOCOL A, ADM3200 B, CLIS_SMO C    ");   
		sql.append(" WHERE C.CLIS_SMO_ID = A.CLIS_SMO_ID            ");
		sql.append(" AND C.CLIS_SMO_ID = B.CLIS_SMO_ID              ");
		sql.append(" AND B.USER_ID = :f_user_id                     ");
		sql.append(" AND A.ACTIVE_FLG = 1                           ");
		sql.append(" AND C.ACTIVE_FLG = 1                           ");
		sql.append(" AND A.STATUS_FLG = '02'                        ");
		sql.append(" AND A.HOSP_CODE = :f_hosp_code                 ");
		sql.append(" AND B.HOSP_CODE = :f_hosp_code                 ");
		sql.append(" AND C.HOSP_CODE = :f_hosp_code                 ");
		sql.append(" ORDER BY PROTOCOL_CODE 						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		
		List<CLIS2015U03ProtocolListInfo> result = new JpaResultMapper().list(query, CLIS2015U03ProtocolListInfo.class);
		return result;
	}

	
	
	@Override
	public List<CLIS2015U04GetProtocolItemInfo> getCLIS2015U04ProtocolListItemInfo(Integer clisSmoId) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CLIS_PROTOCOL_ID,	");
		sql.append("       PROTOCOL_CODE,			");
		sql.append("       PROTOCOL_NAME,			");
		sql.append("       START_DATE,				");
		sql.append("       END_DATE					");
		sql.append("  	FROM CLIS_PROTOCOL          ");
		sql.append("  	WHERE 1 = 1                 ");
		sql.append("  	AND ACTIVE_FLG = 1          ");
		if (!StringUtils.isEmpty(clisSmoId)) {
			sql.append("   AND  CLIS_SMO_ID = :f_clis_smo_id ");
		}
		sql.append("  	ORDER BY CLIS_PROTOCOL_ID ASC;       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (!StringUtils.isEmpty(clisSmoId)) {
			query.setParameter("f_clis_smo_id", clisSmoId);
		}

		List<CLIS2015U04GetProtocolItemInfo> list = new JpaResultMapper().list(
				query, CLIS2015U04GetProtocolItemInfo.class);
		return list;
	}
	
	@Override
	public List<CLIS2015U04GetProtocolItemInfo> getCLIS2015U04GetProtocolListByPatientItem (String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																				");
		sql.append("       CLIS_PROTOCOL.CLIS_PROTOCOL_ID,													");
		sql.append("       CLIS_PROTOCOL.PROTOCOL_CODE,														");
		sql.append("       CLIS_PROTOCOL.PROTOCOL_NAME,														");
		sql.append("       CLIS_PROTOCOL.START_DATE,														");
		sql.append("       CLIS_PROTOCOL.END_DATE															");
		sql.append("  	FROM CLIS_PROTOCOL, CLIS_PROTOCOL_PATIENT          									");
		sql.append("  	WHERE 1 = 1                 														");
		sql.append("	AND CLIS_PROTOCOL.CLIS_PROTOCOL_ID = CLIS_PROTOCOL_PATIENT.CLIS_PROTOCOL_ID 		");
		sql.append("  	AND CLIS_PROTOCOL_PATIENT.ACTIVE_FLG = 1         									");
		sql.append("  	AND CLIS_PROTOCOL.ACTIVE_FLG = 1         											");
		if (!StringUtils.isEmpty(bunho)) {
			sql.append("   AND  CLIS_PROTOCOL_PATIENT.BUNHO = :f_bunho 										");
		}
		sql.append("  	ORDER BY CLIS_PROTOCOL.CLIS_PROTOCOL_ID asc      									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (!StringUtils.isEmpty(bunho)) {
			query.setParameter("f_bunho", bunho);
		}

		List<CLIS2015U04GetProtocolItemInfo> list = new JpaResultMapper().list(
				query, CLIS2015U04GetProtocolItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U00GetProtocolInfo(
			String hospCode, String protoCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT  PROTOCOL_CODE           	  ");                                                    
		sql.append("	        , PROTOCOL_NAME               ");                                       
		sql.append("	FROM   CLIS_PROTOCOL                  ");                                       
		sql.append("	WHERE HOSP_CODE = :hospCode           ");                                               
		sql.append("	AND STATUS_FLG IN (0, 2)              ");                                               
		sql.append("	AND ACTIVE_FLG = 1           		  ");                                               
		sql.append("	AND PROTOCOL_CODE LIKE :protoCode     ");                              
		sql.append("	ORDER BY PROTOCOL_CODE				  ");                              
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("protoCode", "%"+protoCode+"%");
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	@Override
	public CLIS2015U03ProtocolListInfo getOCS0103U00GetNameProtocolInfo(
			String hospCode, String protoCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT  CLIS_PROTOCOL_ID           	  ");                                                    
		sql.append("	    , PROTOCOL_CODE                   ");                                       
		sql.append("	    , PROTOCOL_NAME                   ");                                       
		sql.append("	FROM   CLIS_PROTOCOL                  ");                                       
		sql.append("	WHERE HOSP_CODE = :hospCode           ");                                               
		sql.append("	AND PROTOCOL_CODE = :protoCode     	  ");                              
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("protoCode",protoCode);
		
		List<CLIS2015U03ProtocolListInfo> list = new JpaResultMapper().list(query, CLIS2015U03ProtocolListInfo.class);
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public BigInteger getClis2015U09CheckSmoCodeOnDelete(String hospCode,
			String clisSmoId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT COUNT(A.CLIS_PROTOCOL_ID)   		 ");
		sql.append("	FROM CLIS_PROTOCOL  A,                   ");
		sql.append("			CLIS_SMO B                       ");                                                                                
		sql.append("	WHERE A.HOSP_CODE = :hospCode            ");
		sql.append("	AND A.HOSP_CODE = B.HOSP_CODE            ");
		sql.append("	AND A.CLIS_SMO_ID = B.CLIS_SMO_ID        ");
		sql.append("	AND A.CLIS_SMO_ID = :clisSmoId           ");                                                                                  
                      
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("clisSmoId",clisSmoId);
		
		List<BigInteger> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}


}
