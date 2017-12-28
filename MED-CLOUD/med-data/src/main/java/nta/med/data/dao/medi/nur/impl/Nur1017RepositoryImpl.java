package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1017RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1017Info;
import nta.med.data.model.ihis.nuri.NUR1017U00GrdNUR1017ListItemInfo;
import nta.med.data.model.ihis.nuri.NuriNUR1017U00ManageInfectionInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Nur1017RepositoryImpl implements Nur1017RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Nur1017RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<NuriNUR1017U00ManageInfectionInfo> getNuriNUR1017U00ManageInfectionInfo(
			String hospCode, String bunho) {
	StringBuilder sql = new StringBuilder();
	
	sql.append("SELECT INFE_CODE                                         INFE_CODE	");
	sql.append("      ,BUNHO                                             BUNHO      ");
	sql.append("      ,START_DATE                                        START_DATE ");
	sql.append("      ,END_DATE                                          END_DATE   ");
	sql.append("      ,INFE_JAERYO                                       INFE_JAERYO");
	sql.append("      ,END_SAYU                                          END_SAYU   ");
	sql.append("      ,INPUT_TEXT                                        INPUT_TEXT ");
	sql.append("      ,'Y'                                                          ");
	sql.append("      ,PKNUR1017                                         PKNUR1017  ");
	sql.append("  FROM NUR1017                                                      ");
	sql.append(" WHERE HOSP_CODE = :hospCode                        	             ");
	sql.append("   AND BUNHO = :bunho                                         	    ");
	sql.append("   AND IFNULL(CANCEL_YN, 'N') = 'N'                                 ");
	sql.append(" ORDER BY START_DATE DESC                                           ");
	
	
	Query query = entityManager.createNativeQuery(sql.toString());
	query.setParameter("hospCode", hospCode);
	query.setParameter("bunho", bunho);
	List<NuriNUR1017U00ManageInfectionInfo> list =  new JpaResultMapper().list(query, NuriNUR1017U00ManageInfectionInfo.class);
	return list;
	}
	@Override
	public String getNuriNUR1017U00GetY(String hospCode, String infeCode,
			String bunho, String startDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT 'Y'														");
		sql.append(" FROM NUR1017                                                 "  );
		sql.append(" WHERE HOSP_CODE  = :hospCode                              "  );
		sql.append(" AND INFE_CODE  = :infeCode                                "  );
		sql.append(" AND BUNHO      = :bunho                                    "  );
		sql.append(" AND START_DATE = STR_TO_DATE(:startDate, '%Y/%m/%d')      "  );
		sql.append(" AND IFNULL(CANCEL_YN, 'N') = 'N'                             "  );
		sql.append(" AND INFE_CODE  <> '99'                                       "  );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("infeCode", infeCode);
		query.setParameter("bunho", bunho);
		query.setParameter("startDate", startDate);
		
		List<Object> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0).toString();
		}
		return null;
	}
	@Override
	public String getNuriNUR1017U00GetCodeName(String hospCode,
			String codeType, String infecode, String language) {
		StringBuilder sql = new StringBuilder();
		
	    sql.append("SELECT CODE_NAME					");
	    sql.append("   FROM NUR0102                     ");
	    sql.append("  WHERE HOSP_CODE = :hospCode    	");
	    sql.append("    AND CODE_TYPE = :codeType     	");
	    sql.append("    AND CODE      = :infecode    	");
	    sql.append("    AND LANGUAGE  = :language   	");
	    
	    Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("hospCode", hospCode);
	    query.setParameter("codeType", codeType);
	    query.setParameter("infecode", infecode);
	    query.setParameter("language", language);
	    
	    List<Object> listResult = query.getResultList();
	    if(listResult != null && !listResult.isEmpty()){
	    	return listResult.get(0).toString();
	    }
	    return null;
	}
	@Override
	public String callNuriPrNurInfeMapping(String hospCode, String bunho,
			String InfeCode, String tableId, String userId, String language,
			String oFlag) {
		LOGGER.info("[START] callNuriPrNurInfeMapping hospCode=" + hospCode + ", bunho=" + bunho + ", InfeCode=" 
			+ InfeCode + ", tableId=" + tableId + ", userId=" + userId + ", language=" + language + ", oFlag=" + oFlag );
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_NUR_INFE_MAPPING");
		query.registerStoredProcedureParameter("I_HOSPCODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INFE_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TABLE_ID", String.class, ParameterMode.IN);;
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSPCODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_INFE_CODE", InfeCode);
		query.setParameter("I_TABLE_ID", tableId);
		query.setParameter("I_USER_ID",userId );
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("O_FLAG", oFlag);
		
		Boolean isValid = query.execute();
		oFlag = (String)query.getOutputParameterValue("O_FLAG");
		return oFlag;

	}
	@Override
	public List<NUR1017U00GrdNUR1017ListItemInfo> getNUR1017U00GrdNUR1017ListItem(
			String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT INFE_CODE                                         INFE_CODE			");
		sql.append("	      ,BUNHO                                             BUNHO              ");
		sql.append("	      ,START_DATE                                        START_DATE         ");
		sql.append("	      ,END_DATE                                          END_DATE           ");
		sql.append("	      ,INFE_JAERYO                                       INFE_JAERYO        ");
		sql.append("	      ,END_SAYU                                          END_SAYU           ");
		sql.append("	      ,INPUT_TEXT                                        INPUT_TEXT         ");
		sql.append("	      ,'Y'                                                                  ");
		sql.append("	      ,PKNUR1017                                         PKNUR1017          ");
		sql.append("	      ,''                                                                   ");
		sql.append("	  FROM NUR1017                                                              ");
		sql.append("	 WHERE HOSP_CODE = :hospCode                                                ");
		sql.append("	   AND BUNHO = :bunho                                                       ");
		sql.append("	   AND IFNULL(CANCEL_YN, 'N') = 'N'                                         ");
		sql.append("	 ORDER BY START_DATE DESC                                                   ");
		
		 Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("hospCode", hospCode);
		 query.setParameter("bunho", bunho);
		 
		 List<NUR1017U00GrdNUR1017ListItemInfo> listResult = new JpaResultMapper().list(query, NUR1017U00GrdNUR1017ListItemInfo.class);
		 return listResult;
	}
	
	@Override
	public String getNUR1017U00LayValidationDupchk(String hospCode,
			String infeCode, String bunho, String startDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'															");
		sql.append("	FROM NUR1017                                                        ");
		sql.append("	WHERE HOSP_CODE  = :hospCode                                        ");
		sql.append("	AND INFE_CODE  = :infeCode                                          ");
		sql.append("	AND BUNHO      = :bunho                                             ");
		sql.append("	AND START_DATE = STR_TO_DATE(:startDate, '%Y/%m/%d')                ");
		sql.append("	AND IFNULL(CANCEL_YN, 'N') = 'N'                                    ");
		
		 Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("hospCode", hospCode);
		 query.setParameter("infeCode", infeCode);
		 query.setParameter("bunho", bunho);
		 query.setParameter("startDate", startDate);
		 
		 List<String> result = query.getResultList();
		 if(!CollectionUtils.isEmpty(result)){
			 return result.get(0);
		 }
		 return null;
	}
	
	@Override
	public String getNUR1017PatientInfection(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT COUNT(*)   						");
		sql.append(" 	  FROM NUR1017 						");
		sql.append(" 	  WHERE HOSP_CODE = :f_hosp_code 	");
		sql.append(" 	    AND BUNHO     = :f_bunho 		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) !=null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<NUR1001U00GrdNUR1017Info> getNUR1001U00GrdNUR1017Info(String hospCode, String language, String bunho, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("   SELECT  DATE_FORMAT(A.START_DATE, '%Y/%m/%d')                                                 START_DATE       ");
		sql.append("         , FN_NUR_LOAD_CODE_NAME('NUR1017_INFE_JAERYO', A.INFE_JAERYO, A.HOSP_CODE, :f_language) INFE_JAERYO      ");
		sql.append("         , FN_NUR_LOAD_CODE_NAME('INFE_CODE',A.INFE_CODE, A.HOSP_CODE, :f_language)              INFE_CODE        ");
		sql.append("         , ''                                                                                    DATA_ROW_STATE   ");
		sql.append("     FROM  NUR1017 A                                                                                              ");
		sql.append("    WHERE  A.HOSP_CODE = :f_hosp_code                                                                             ");
		sql.append("      AND  A.BUNHO     = :f_bunho                                                                                 ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																				  ");
		}
		
		 Query query = entityManager.createNativeQuery(sql.toString());
		 query.setParameter("f_hosp_code", hospCode);
		 query.setParameter("f_bunho", bunho);
		 query.setParameter("f_language", language);
		 
		 if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		 
		 List<NUR1001U00GrdNUR1017Info> listResult = new JpaResultMapper().list(query, NUR1001U00GrdNUR1017Info.class);
		 return listResult;
	}
}

