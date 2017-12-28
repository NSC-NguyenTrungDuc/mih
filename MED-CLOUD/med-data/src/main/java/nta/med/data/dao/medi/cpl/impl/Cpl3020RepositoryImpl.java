package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl3020RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect2ListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00LaySubHangmogListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U00GrdGumListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3010U01GrdHangmogInfo;
import nta.med.data.model.ihis.cpls.CPL3010U01GrdResultInfo;
import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl3020RepositoryImpl implements Cpl3020RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	
	@Override
	public List<CPL3010U01GrdHangmogInfo> getCPL3010U01GrdHangmogListItemInfo(String hospCpde,String language, String requestKey) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT 'O2'                                                RECODE_GUBUN                                                       " );
		sql.append(" , 'SAN   '                                            CENTER_CODE                                                             " );
		sql.append(" ,CONCAT(IFNULL(DATE_FORMAT(A.PART_JUBSU_DATE,'%y%m%d'),''),IFNULL(A.PART_JUBSU_TIME,''),IFNULL(A.BUNHO,'')) REQUEST_KEY     " );
		sql.append(" , '        '                                          HOSPITAL_CODE                                                           " );
		sql.append(" , B.HANGMOG_CODE                                      HANGMOG_CODE                                                            " );
		sql.append(" , C.JANGBI_OUT_CODE                                   SAN_CODE                                                                " );
		sql.append(" , SUBSTR(C.JANGBI_OUT_CODE,5,2)                       SPECIMEN_CODE                                                           " );
		sql.append("                                                                                                                               " );
		sql.append(" ,case  FN_CPL_SPECIMEN_PRN_YN(:f_hosp_code,A.IN_OUT_GUBUN, A.FKOCS1003, A.FKOCS2003) when 'X' then 'Y' else 'N' end EMERGENCY " );
		sql.append(" , ' '                                                                                                                         " );
		sql.append(" , B.SPECIMEN_SER                                                                                                              " );
		sql.append(" , C.JUNDAL_GUBUN_NAME                                                                                                         " );
		sql.append(" , C.GUMSA_NAME                                                                                                                " );
		sql.append(" , FN_CPL_CODE_NAME('04',C.SPECIMEN_CODE,:f_hosp_code,:f_language)              SPECIMEN_NAME                                  " );
		sql.append("  FROM CPL0101 C,                                                                                                              " );
		sql.append(" CPL3020 B,                                                                                                                    " );
		sql.append(" CPL2010 A                                                                                                                     " );
		sql.append(" WHERE A.HOSP_CODE             = :f_hosp_code                                                                                  " );
		sql.append("   AND A.PART_JUBSU_DATE       = STR_TO_DATE(CONCAT('20',IFNULL(SUBSTR(:f_request_key,1,6),'')),'%Y%m%d')                      " );
		sql.append("   AND A.PART_JUBSU_TIME       = SUBSTR(:f_request_key,7,4)                                                                    " );
		sql.append("   AND A.BUNHO                 = SUBSTR(:f_request_key,11)                                                                     " );
		sql.append("   AND A.PART_JUBSU_DATE      IS NOT NULL                                                                                      " );
		sql.append("   AND B.HOSP_CODE             = A.HOSP_CODE                                                                                   " );
		sql.append("   AND B.FKCPL2010             = A.PKCPL2010                                                                                   " );
		sql.append("   AND B.SPECIMEN_SER          = A.SPECIMEN_SER                                                                                " );
		sql.append("   AND C.HOSP_CODE             = B.HOSP_CODE                                                                                   " );
		sql.append("   AND C.HANGMOG_CODE          = B.HANGMOG_CODE                                                                                " );
		sql.append("   AND C.SPECIMEN_CODE         = B.SPECIMEN_CODE                                                                               " );
		sql.append("   AND C.EMERGENCY             = B.EMERGENCY                                                                                   " );
		sql.append("   AND IFNULL(C.CHUBANG_YN,'Y')   = 'Y'                                                                                        " );
		sql.append("   AND C.UITAK_CODE            = '01'                                                                                          " );
		sql.append("   AND C.JANGBI_OUT_CODE      IS NOT NULL                                                                                      " );
		sql.append("                                                                                                                               " );
		sql.append(" ORDER BY B.SPECIMEN_SER,B.PKCPL3020																							");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCpde);
		query.setParameter("f_language", language);
		query.setParameter("f_request_key", requestKey);
		List<CPL3010U01GrdHangmogInfo> listGrd= new JpaResultMapper().list(query, CPL3010U01GrdHangmogInfo.class);
		return listGrd;
	}
	@Override
	public List<CPL3010U01GrdResultInfo> getCPL3010U01GrdResultListItemInfo(String hospCode, String language, String requestKey) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                          "  );
		sql.append("  'O2'                                                RECODE_GUBUN                                        "  );
		sql.append(" , 'BML   '                                            CENTER_CODE                                        "  );
		sql.append(" , :f_request_key                                                                                         "  );
		sql.append(" , A.HANGMOG_CODE                                      HANGMOG_CODE                                       "  );
		sql.append(" , C.JANGBI_OUT_CODE                                   SRL_CODE                                           "  );
		sql.append(" , C.SPECIMEN_CODE                                     SPECIMEN_CODE                                      "  );
		sql.append(" , C.EMERGENCY                                         EMERGENCY                                          "  );
		sql.append(" , ' '                                                                                                    "  );
		sql.append(" , A.SPECIMEN_SER                                                                                         "  );
		sql.append(" , C.JUNDAL_GUBUN_NAME                                                                                    "  );
		sql.append(" , A.LAB_NO                                                                                               "  );
		sql.append(" , A.CPL_RESULT                                                                                           "  );
		sql.append(" , A.STANDARD_YN                                                                                          "  );
		sql.append(" , A.COMMENTS                                                                                             "  );
		sql.append(" , IFNULL(A.VITROS,'N')                                                                                   "  );
		sql.append(" , A.RESULT_YN                                                                                            "  );
		sql.append(" , C.GUMSA_NAME                                                                                           "  );
		sql.append(" , FN_CPL_CODE_NAME('04',C.SPECIMEN_CODE,:f_hosp_code,:language)          SPECIMEN_NAME                   "  );
		sql.append("  FROM CPL0101 C,                                                                                         "  );
		sql.append(" CPL3020 A,                                                                                               "  );
		sql.append(" CPL2010 B                                                                                                "  );
		sql.append(" WHERE B.HOSP_CODE             = :f_hosp_code                                                             "  );
		sql.append(" AND B.JUBSU_DATE            = STR_TO_DATE(CONCAT('20',IFNULL(SUBSTR(:f_request_key,1,6),'')),'%Y%m%d') "    );
		sql.append(" AND B.JUBSU_TIME            = SUBSTR(:f_request_key,7,4)                                                 "  );
		sql.append(" AND B.BUNHO                 = SUBSTR(:f_request_key,11)                                                  "  );
		sql.append(" AND A.HOSP_CODE             = B.HOSP_CODE                                                                "  );
		sql.append(" AND A.FKCPL2010             = B.PKCPL2010                                                                "  );
		sql.append(" AND C.HOSP_CODE             = A.HOSP_CODE                                                                "  );
		sql.append(" AND C.HANGMOG_CODE          = A.HANGMOG_CODE                                                             "  );
		sql.append(" AND C.SPECIMEN_CODE         = A.SPECIMEN_CODE                                                            "  );
		sql.append(" AND C.EMERGENCY             = A.EMERGENCY                                                                "  );
		sql.append(" AND C.UITAK_CODE            = 'BML'                                                                      "  );
		sql.append(" ORDER BY A.LAB_NO, A.HANGMOG_CODE																			");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_request_key", requestKey);
		List<CPL3010U01GrdResultInfo> listGrdResult= new JpaResultMapper().list(query, CPL3010U01GrdResultInfo.class);
		return listGrdResult;
	}

	
	@Override
	public List<CPL3010U00GrdGumListItemInfo> getCPL3010U00GrdGumListItemInfo(String hospCode, String language, String specimenSer){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT  :f_specimen_ser ,                                                                         ");
		sql.append("        A.FKCPL2010                                                                FKCPL2010,     ");
		sql.append("        B.GUMSA_NAME                                                               GUMSA_NAME,    ");
		sql.append("        FN_CPL_CODE_NAME('07',A.JANGBI_CODE,:f_hosp_code,:f_language)              JANGBI_NAME,   ");
		sql.append("        A.CPL_RESULT                                                               CPL_RESULT,    ");
		sql.append("        C.CODE_NAME                                                                SPECIMEN_NAME, ");
		sql.append("        A.HANGMOG_CODE                                                             HANGMOG_CODE,  ");
		sql.append("        ' '                                                                        PART_JUBSUJA,  ");
		sql.append("        'Y'                                                                        SUB_JUBSU_YN,  ");
		sql.append("        B.SPCIAL_NAME                                                              SPCIAL_NAME,   ");
		sql.append("        ' '                                                                        FKOCS,         ");
		sql.append("        A.CONFIRM_YN                                                                              ");
		sql.append("   FROM                                                                                           ");
		sql.append("        CPL0101 B,                                                                                ");
		sql.append("        CPL3010 D,                                                                                ");
		sql.append("        CPL3020 A LEFT OUTER JOIN CPL0109 C  ON C.CODE       = A.SPECIMEN_CODE                    ");
		sql.append("    AND C.CODE_TYPE  = '04' AND C.HOSP_CODE  = A.HOSP_CODE                                        ");
		sql.append("  WHERE A.HOSP_CODE     = :f_hosp_code                                                            ");
		sql.append("    AND B.HOSP_CODE     = A.HOSP_CODE                                                             ");
		sql.append("    AND D.HOSP_CODE     = A.HOSP_CODE                                                             ");
		sql.append("    AND D.SPECIMEN_SER  = :f_specimen_ser                                                         ");
		sql.append("    AND A.SPECIMEN_SER  = D.SPECIMEN_SER                                                          ");
		sql.append("    AND A.LAB_NO        = D.LAB_NO                                                                ");
		sql.append("    AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                          ");
		sql.append("    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE                                                         ");
		sql.append("    AND B.EMERGENCY     = A.EMERGENCY                                                             ");
		sql.append("  ORDER BY A.PKCPL3020                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<CPL3010U00GrdGumListItemInfo> list = new JpaResultMapper().list(query, CPL3010U00GrdGumListItemInfo.class);
		return list;
	}
	
	
	@Override
	public List<CPL0000Q00LaySubHangmogListItemInfo> getCPL0000Q00LaySubHangmogListItemInfo(String hospCode, String bunho, String hangmogCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CONCAT(IF(B.HANGMOG_CODE = B.SOURCE_GUMSA,'','  ') , C.GUMSA_NAME)    GUMSA_NAME,  ");
		sql.append("       B.RESULT_DATE                                                         RESULT_DATE, ");
		sql.append("       B.CPL_RESULT                                                          CPL_RESULT   ");
		sql.append("  FROM CPL0101 C,                                                                         ");
		sql.append("       CPL3020 B,                                                                         ");
		sql.append("       CPL2010 A                                                                          ");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                                                     ");
		sql.append("   AND B.HOSP_CODE     = A.HOSP_CODE                                                      ");
		sql.append("   AND C.HOSP_CODE     = A.HOSP_CODE                                                      ");
		sql.append("   AND A.BUNHO         = :f_bunho                                                         ");
		sql.append("   AND B.HANGMOG_CODE  = :f_hangmog_code                                                  ");
		sql.append("   AND B.CONFIRM_DATE  IS NOT NULL                                                        ");
		sql.append("   AND B.FKCPL2010     = A.PKCPL2010                                                      ");
		sql.append("   AND C.HANGMOG_CODE  = B.HANGMOG_CODE                                                   ");
		sql.append("   AND C.SPECIMEN_CODE = B.SPECIMEN_CODE                                                  ");
		sql.append("   AND C.EMERGENCY     = B.EMERGENCY                                                      ");
		sql.append(" ORDER BY B.RESULT_DATE DESC                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		List<CPL0000Q00LaySubHangmogListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00LaySubHangmogListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL0000Q00GetSigeyulDataSelect2ListItemInfo> getCPL0000Q00GetSigeyulDataSelect2(String hospCode, String bunho, String hangmogCode,
			String jubsuDate, String jubsuTime){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT B.CPL_RESULT       CPL_RESULT                                                                                                   ");
		sql.append("     , B.STANDARD_YN      STANDARD_YN                                                                                                  ");
		sql.append("     , C.GUMSA_NAME       GUMSA_NAME                                                                                                   ");
		sql.append("     , FN_CPL_STANDARD_FROM_TO_LOAD ('1', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY, A.SEX, A.AGE, :f_hosp_code) FROM_STANDARD      ");
		sql.append("     , FN_CPL_STANDARD_FROM_TO_LOAD ('2', B.HANGMOG_CODE, B.SPECIMEN_CODE, B.EMERGENCY, A.SEX, A.AGE, :f_hosp_code) TO_STANDARD        ");
		sql.append("  FROM CPL0101 C,                                                                                                                      ");
		sql.append("       CPL3020 B,                                                                                                                      ");
		sql.append("       CPL2010 A                                                                                                                       ");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                                                                                                  ");
		sql.append("   AND B.HOSP_CODE     = A.HOSP_CODE                                                                                                   ");
		sql.append("   AND C.HOSP_CODE     = A.HOSP_CODE                                                                                                   ");
		sql.append("   AND A.BUNHO         = :f_bunho                                                                                                      ");
		sql.append("   AND B.FKCPL2010     = A.PKCPL2010                                                                                                   ");
		sql.append("   AND B.HANGMOG_CODE  = :f_hangmog_code                                                                                               ");
		sql.append("   AND A.PART_JUBSU_DATE   = STR_TO_DATE(:f_jubsu_date,'%Y/%m/%d')                                                                     ");
		sql.append("   AND SUBSTR(A.PART_JUBSU_TIME,1,3) = :f_jubsu_time                                                                                   ");
		sql.append("   AND C.HANGMOG_CODE  = B.HANGMOG_CODE                                                                                                ");
		sql.append("   AND C.SPECIMEN_CODE = B.SPECIMEN_CODE                                                                                               ");
		sql.append("   AND C.EMERGENCY     = B.EMERGENCY                                                                                                   ");
		                                                                                                                                                   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_jubsu_time", jubsuTime);
		
		List<CPL0000Q00GetSigeyulDataSelect2ListItemInfo> list = new JpaResultMapper().list(query, CPL0000Q00GetSigeyulDataSelect2ListItemInfo.class);
		return list;
	}
	@Override
	public String callPrCplResultMatchProc(String proc_gubun, String hospCode,
			String specimenSer, String hangmogCode, String resultVal,
			String jangbiCode, String resultDate, String sampleId,
			String resultCode,String ioFlag) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL_RESULT_MATCH_PROC");
		
		query.registerStoredProcedureParameter("I_PROC_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_SER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESULT_VAL", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JANGBI_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESULT_DATE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SAMPLE_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESULT_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_PROC_GUBUN", proc_gubun);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SPECIMEN_SER", specimenSer);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_JANGBI_CODE", jangbiCode);
		query.setParameter("I_RESULT_VAL", resultVal);
		query.setParameter("I_RESULT_DATE", resultDate);
		query.setParameter("I_SAMPLE_ID", sampleId);
		query.setParameter("I_RESULT_CODE", resultCode);
		query.setParameter("IO_FLAG", ioFlag);
		
		
		String flag = (String)query.getOutputParameterValue("IO_FLAG");
		return flag;
	}
	@Override
	public Integer updateCPL3010U01(String hospCode, String language,
			String cplResult, String standartYn, String comment1,
			String comment2, String userId, String requestKey, String bmlCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" UPDATE CPL3020                                                                                       ");
		sql.append("    SET CPL_RESULT    = :f_cpl_result                                                                 ");
		sql.append("      , STANDARD_YN   = :f_standard_yn                                                                ");
		sql.append("      , COMMENTS      = CONCAT(FN_CPL_CODE_NAME('S_COM1',:f_comments1,:f_hosp_code,:f_language),      ");
		sql.append("      ' ',FN_CPL_CODE_NAME('S_COM1',:f_comments2,:f_hosp_code,:f_language))                           ");
		sql.append("      , VITROS        = 'Y'                                                                           ");
		sql.append("      , UPD_DATE      = SYSDATE()                                                                     ");
		sql.append("      , USER_ID       = :f_user_id                                                                    ");
		sql.append("      , RESULT_DATE   = SYSDATE()                                                                     ");
		sql.append("      , RESULT_TIME   = DATE_FORMAT(SYSDATE(),'%k%i')                                                 ");
		sql.append("      , CONFIRM_DATE  = SYSDATE()                                                                     ");
		sql.append("      , CONFIRM_YN    = 'Y'                                                                           ");
		sql.append("      , RESULT_YN     = 'Y'                                                                           ");
		sql.append("      , DISPLAY_YN    = 'Y'                                                                           ");
		sql.append("  WHERE HOSP_CODE     = :f_hosp_code                                                                  ");
		sql.append("    AND SPECIMEN_SER  = SUBSTR(:f_request_key,3)                                                      ");
		sql.append("    AND HANGMOG_CODE  = :f_bml_code																	  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_cpl_result", cplResult);
		query.setParameter("f_standard_yn", standartYn);
		query.setParameter("f_comments1", comment1);
		query.setParameter("f_comments2", comment2);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_request_key", requestKey);
		query.setParameter("f_bml_code", bmlCode);
		 return query.executeUpdate();
	}
	
	@Override
	public void callPrCplAutoConfirmUpdate(String hospCode, String specimenSer, String gumsaja, String confirmYn){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL_AUTO_CONFIRM_UPDATE");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_SER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUMSAJA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CONFIRM_YN", String.class, ParameterMode.IN);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_SPECIMEN_SER", specimenSer);
		query.setParameter("I_GUMSAJA", gumsaja);
		query.setParameter("I_CONFIRM_YN", confirmYn);
		
		query.execute();
	}
	
	@Override
	public List<TripleListItemInfo> getNUR6011U01GetGumsa(String hospCode, String language, String date, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT IFNULL(FN_CPL_HANGMOG_RESULT_4(:f_hosp_code, :f_bunho,                                              ");
		sql.append("                 FN_NUR_LOAD_CODE_NAME('NUR6011_GUMSA','HB', :f_hosp_code, :f_language),                      ");
		sql.append("                 STR_TO_DATE(:f_date, '%Y/%m/%d')),'')                                     HB_RESULT          ");
		sql.append("        , IFNULL(FN_CPL_HANGMOG_RESULT_4(:f_hosp_code, :f_bunho,                                              ");
		sql.append("                 FN_NUR_LOAD_CODE_NAME('NUR6011_GUMSA','ALB', :f_hosp_code, :f_language),                     ");
		sql.append("                 STR_TO_DATE(:f_date, '%Y/%m/%d')),'')                                     ALB_RESULT         ");
		sql.append("        , IFNULL(FN_CPL_HANGMOG_RESULT_4(:f_hosp_code, :f_bunho,                                              ");
		sql.append("                 FN_NUR_LOAD_CODE_NAME('NUR6011_GUMSA','TP', :f_hosp_code, :f_language),                      ");
		sql.append("                 STR_TO_DATE(:f_date, '%Y/%m/%d')),'')                                     TP_RESULT          ");
		sql.append("     FROM DUAL                                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		query.setParameter("f_date", date);
		
		List<TripleListItemInfo> list = new JpaResultMapper().list(query, TripleListItemInfo.class);
		return list;
		
	}
	
}

