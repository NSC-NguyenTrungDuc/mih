package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0115RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0115Info;
import nta.med.data.model.ihis.system.PrOcsLoadJundalInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;


/**
 * @author dainguyen.
 */
public class Ocs0115RepositoryImpl implements Ocs0115RepositoryCustom {
	private static final Log LOGGER = LogFactory.getLog(Ocs0115RepositoryImpl.class);                   
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public PrOcsLoadJundalInfo callPrOcsLoadJundalInfo(String hospCode,
			String hangmogCode, String inputPart, String inputGwa,
			Date appDate, String jundalPartOut, String jundalPartInp,
			String jundalTableOut, String jundalTableInp, String movePart,
			String ioFlag, String msg) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_OCS_LOAD_JUNDAL_INFO");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE",String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE",String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_PART",String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GWA",String.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("I_APP_DATE",Date.class,ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_JUNDAL_PART_OUT",String.class,ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_PART_INP",String.class,ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_TABLE_OUT",String.class,ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_JUNDAL_TABLE_INP",String.class,ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MOVE_PART",String.class,ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG",String.class,ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_MSG",String.class,ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE",hospCode);
		query.setParameter("I_HANGMOG_CODE",hangmogCode);
		query.setParameter("I_INPUT_PART",inputPart);
		query.setParameter("I_INPUT_GWA",inputGwa);
		query.setParameter("I_APP_DATE",appDate);
		query.setParameter("IO_JUNDAL_PART_OUT",jundalPartOut);
		query.setParameter("IO_JUNDAL_PART_INP",jundalPartInp);
		query.setParameter("IO_JUNDAL_TABLE_OUT",jundalTableOut);
		query.setParameter("IO_JUNDAL_TABLE_INP",jundalTableInp);
		query.setParameter("IO_MOVE_PART",movePart);
		query.setParameter("IO_FLAG",ioFlag);
		query.setParameter("IO_MSG",msg);
		
		PrOcsLoadJundalInfo info = new PrOcsLoadJundalInfo();
		
		if(query.getOutputParameterValue("IO_JUNDAL_PART_OUT") != null){
			info.setIoJundalPartOut((String)query.getOutputParameterValue("IO_JUNDAL_PART_OUT"));
		}
		if(query.getOutputParameterValue("IO_JUNDAL_PART_INP") != null){
			info.setIoJundalPartInp((String)query.getOutputParameterValue("IO_JUNDAL_PART_INP"));
		}
		if(query.getOutputParameterValue("IO_JUNDAL_TABLE_OUT") != null){
			info.setIoJundalTableOut((String)query.getOutputParameterValue("IO_JUNDAL_TABLE_OUT"));
		}
		if(query.getOutputParameterValue("IO_JUNDAL_TABLE_INP") != null){
			info.setIoJundalTableInp((String)query.getOutputParameterValue("IO_JUNDAL_TABLE_INP"));
		}
		if(query.getOutputParameterValue("IO_MOVE_PART") != null){
			info.setIoMovePart((String)query.getOutputParameterValue("IO_MOVE_PART"));
		}
		if(query.getOutputParameterValue("IO_FLAG") != null){
			info.setIoFlag((String)query.getOutputParameterValue("IO_FLAG"));
		}
		if(query.getOutputParameterValue("IO_MSG") != null){
			info.setIoMsg((String)query.getOutputParameterValue("IO_MSG"));
		}
		
		return info;
	}

	
	@Override
	public List<ComboListItemInfo> getFindWorkerJundalHangmog(String hospCode, String language, String argu1, String argu2, String caseCondition){
		String gwa = "";
		String gwaName = "";
		if(caseCondition.equalsIgnoreCase("jundal_part_inp_hangmog")){
			gwa = "JUNDAL_PART_INP";
			gwaName = "JUNDAL_PART_INP";
		}else if(caseCondition.equalsIgnoreCase("jundal_table_inp_hangmog")){
			gwa = "JUNDAL_TABLE_INP";
			gwaName = "JUNDAL_TABLE_INP";
		}else if(caseCondition.equalsIgnoreCase("jundal_table_out_hangmog")){
			gwa = "JUNDAL_PART_OUT";
			gwaName = "JUNDAL_TABLE_OUT";
		}else if(caseCondition.equalsIgnoreCase("jundal_part_out_hangmog")){
			gwa = "JUNDAL_PART_OUT";
			gwaName = "JUNDAL_PART_OUT";
		}else if(caseCondition.equalsIgnoreCase("move_part_hangmog")){
			gwa = "JUNDAL_PART_INP";
			gwaName = "MOVE_PART";
		}
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT Z.GWA GWA, Z.GWA_NAME GWA_NAME                                                                                   ");
		sql.append("  FROM (SELECT A."+ gwa  +" GWA, 	                                                                        ");
		sql.append("  FN_BAS_LOAD_GWA_NAME(A."+ gwaName  +" , STR_TO_DATE(IFNULL(TRIM(:f_argu2),DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d'),:f_hosp_code, :f_language) GWA_NAME  ");      
		sql.append("                                   ");
		sql.append("          FROM OCS0115 A                                                                                                ");
		sql.append("             , OCS0103 B                                                                                                ");
		sql.append("         WHERE                                                                                                          ");
		sql.append("               B.HOSP_CODE    = :f_hosp_code                                                                            ");
		sql.append("           AND B.HANGMOG_CODE = :f_argu1                                                                                ");
		sql.append("           AND B.START_DATE   <= STR_TO_DATE(IFNULL(TRIM(:f_argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')    ");
		sql.append("           AND B.END_DATE     >= STR_TO_DATE(IFNULL(TRIM(:f_argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')    ");      
		sql.append("           AND A.HOSP_CODE    = B.HOSP_CODE                                                                             ");
		sql.append("           AND A.HANGMOG_CODE = B.HANGMOG_CODE                                                                          ");
		sql.append("           AND A.HANGMOG_START_DATE   = B.START_DATE                                                                    ");
		sql.append("           AND A.START_DATE   <= STR_TO_DATE(IFNULL(TRIM(:f_argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')    ");
		sql.append("           AND A.END_DATE     >= STR_TO_DATE(IFNULL(TRIM(:f_argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')    ");
		sql.append("         UNION                                                                                                          ");
		sql.append("        SELECT A.GWA GWA, A.GWA_NAME GWA_NAME                                                                           ");
		sql.append("          FROM VW_BAS_GWA A                                                                                             ");
		sql.append("         WHERE A.HOSP_CODE  = :f_hosp_code                                                                              ");
		sql.append("           AND A.GWA        = 'HOM'                                                                                     ");
		sql.append("           AND A.LANGUAGE   = :f_language                                                                               ");
		sql.append("           AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:f_argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')      ");
		sql.append("           AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:f_argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')      ");
		sql.append("       ) Z                                                                                                              ");
		sql.append(" ORDER BY IF(Z.GWA = 'HOM', '~~~~~~~~~~', Z.GWA)                                                                        ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_argu1", argu1);
		query.setParameter("f_argu2", argu2);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public String getLoadColumnCodeNameJundalPartOutHangmogCase(String argu1,
			String argu2, String argu3,String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT Z.GWA_NAME GWA_NAME 																																					");
		sql.append("	FROM (SELECT A.JUNDAL_PART_OUT GWA,                                                                                                                                        	");
		sql.append("		 FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_OUT, STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d'), :hospCode, :language) GWA_NAME  	       ");
		sql.append("	        FROM OCS0115 A                                                                                                                                                     	");
		sql.append("	       WHERE A.HANGMOG_CODE    = :argu1                                                                                                                                    	");
		sql.append("	         AND A.JUNDAL_PART_OUT = :argu3                                                                                                                                    	");
		sql.append("	         AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')                                                            	");
		sql.append("	         AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')                                                            	");
		sql.append("	         AND A.HOSP_CODE = :hospCode                                                                                                                                       	");
		sql.append("	       UNION                                                                                                                                                               	");
		sql.append("	      SELECT A.GWA GWA, A.GWA_NAME GWA_NAME                                                                                                                                	");
		sql.append("	        FROM VW_BAS_GWA A                                                                                                                                                  	");
		sql.append("	       WHERE A.HOSP_CODE = :hospCode                                                                                                                                       	");
		sql.append("	         AND A.GWA = 'HOM'                                                                                                                                                 	");
		sql.append("	         AND A.GWA = :argu3                                                                                                                                               	");
		sql.append("	         AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')                                                  	        ");
		sql.append("	         AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d') ) Z                                             	            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("argu1", argu1);
		query.setParameter("argu2", argu2);
		query.setParameter("argu3", argu3);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getLoadColumnCodeNameJundalPartInpHangmogCase(String argu1,
			String argu2, String argu3, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT Z.GWA_NAME GWA_NAME 																																					");
		sql.append("	FROM (SELECT A.JUNDAL_PART_OUT GWA,                                                                                                                                        	");
		sql.append("		 FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_INP, STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d'), :hospCode, :language) GWA_NAME  	       ");
		sql.append("	        FROM OCS0115 A                                                                                                                                                     	");
		sql.append("	       WHERE A.HANGMOG_CODE    = :argu1                                                                                                                                    	");
		sql.append("	         AND A.JUNDAL_PART_OUT = :argu3                                                                                                                                    	");
		sql.append("	         AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')                                                            	");
		sql.append("	         AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')                                                            	");
		sql.append("	         AND A.HOSP_CODE = :hospCode                                                                                                                                       	");
		sql.append("	       UNION                                                                                                                                                               	");
		sql.append("	      SELECT A.GWA GWA, A.GWA_NAME GWA_NAME                                                                                                                                	");
		sql.append("	        FROM VW_BAS_GWA A                                                                                                                                                  	");
		sql.append("	       WHERE A.HOSP_CODE = :hospCode                                                                                                                                       	");
		sql.append("	         AND A.GWA = 'HOM'                                                                                                                                                 	");
		sql.append("	         AND A.GWA = :argu3                                                                                                                                               	");
		sql.append("	         AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')                                                  	        ");
		sql.append("	         AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:argu2) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d') ) Z                                             	            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("argu1", argu1);
		query.setParameter("argu2", argu2);
		query.setParameter("argu3", argu3);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}


	@Override
	public List<OCS0103U00GrdOCS0115Info> getOCS0103U00GrdOCS0115Info(String hospCode, String language, String hangmocCode,String hangmogStartDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.HANGMOG_CODE                                                                                         ");
		sql.append("       , A.INPUT_GWA                                                                                            ");
		sql.append("       , A.INPUT_PART                                                                                           ");
		sql.append("       ,case A.INPUT_PART when '*' then FN_ADM_MSG('221',:f_language)                                           ");
		sql.append("       else FN_BAS_LOAD_GWA_NAME ( A.INPUT_PART, SYSDATE(),:f_hosp_code,:f_language ) end GWA_NAME              ");
		sql.append("       , A.JUNDAL_TABLE_OUT                                                                                     ");
		sql.append("       , A.JUNDAL_PART_OUT                                                                                      ");
		sql.append("       , A.MOVE_PART                                                                                            ");
		sql.append("       , A.JUNDAL_TABLE_INP                                                                                     ");
		sql.append("       , A.JUNDAL_PART_INP                                                                                      ");
		sql.append("       , FN_BAS_LOAD_GWA_NAME ( A.JUNDAL_PART_OUT, SYSDATE(),:f_hosp_code,:f_language )   GWA_NAME_OUT          ");
		sql.append("       , FN_BAS_LOAD_GWA_NAME ( A.JUNDAL_PART_INP, SYSDATE(),:f_hosp_code,:f_language )   GWA_NAME_INP          ");
		sql.append("       , FN_BAS_LOAD_GWA_NAME ( A.MOVE_PART, SYSDATE(),:f_hosp_code,:f_language )         MOVE_PART_NAME        ");
		sql.append("       , A.START_DATE                                                                                           ");
		sql.append("       , A.END_DATE                                                                                             ");
		sql.append("       , A.HOSP_CODE                                                                                            ");
		sql.append("       , A.HANGMOG_START_DATE                                                                                   ");
		sql.append("    FROM OCS0115 A                                                                                              ");
		sql.append("   WHERE A.HOSP_CODE    = :f_hosp_code                                                                          ");
		sql.append("     AND A.HANGMOG_CODE = :f_aHangmogCode                                                                       ");
		sql.append("     AND A.HANGMOG_START_DATE = STR_TO_DATE(:f_aHangmogStartDate,'%Y/%m/%d')                                    ");
		sql.append("   ORDER BY A.HANGMOG_CODE																						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_aHangmogCode", hangmocCode);
		query.setParameter("f_aHangmogStartDate", hangmogStartDate);
		List<OCS0103U00GrdOCS0115Info> listResult = new JpaResultMapper().list(query, OCS0103U00GrdOCS0115Info.class);
		return listResult;
	}


	@Override
	public String getPhy8002U01BtnPrintGetGwaNameSinryouka(String hospCode, String gwa) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	  SELECT A.GWA_NAME 										");
		sql.append("	   FROM VW_BAS_GWA A                                        ");
		sql.append("	  WHERE A.HOSP_CODE =  :hospCode                            ");
		sql.append("	    AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE       ");
		sql.append("	   AND A.GWA = :gwa                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("gwa", gwa);
		 
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
}

