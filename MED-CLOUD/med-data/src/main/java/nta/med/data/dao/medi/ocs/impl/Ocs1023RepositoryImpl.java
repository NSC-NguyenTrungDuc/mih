package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs1023RepositoryCustom;
import nta.med.data.model.ihis.ocso.Ocs1023U00GrdOcs1023Info;
import nta.med.data.model.ihis.system.OBCheckRegularDrugInfo;

/**
 * @author dainguyen.
 */
public class Ocs1023RepositoryImpl implements Ocs1023RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<OBCheckRegularDrugInfo> getOBCheckRegularDrugInfo(String hospCode, String bunho, String gwa, String hangmog) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SURYANG, A.ORD_DANUI AS DANUI, A.DV, A.DV_TIME, A.JUSA, A.BOGYONG_CODE    ");
		sql.append("   FROM OCS1023 A                                                                   ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                                             ");
		sql.append("    AND A.BUNHO          = :f_aBunho                                                ");
		sql.append("    AND A.GWA            = :f_aGwa                                                  ");
		sql.append("    AND A.HANGMOG_CODE   = :f_aHangmog 	LIMIT 1		    							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aBunho", bunho);
		query.setParameter("f_aGwa", gwa);
		query.setParameter("f_aHangmog", hangmog);
		List<OBCheckRegularDrugInfo> listResult = new JpaResultMapper().list(query, OBCheckRegularDrugInfo.class);
		return listResult;
	}
	@Override
	public List<Ocs1023U00GrdOcs1023Info> getOcs1023U00GrdOcs1023Info(
			String hospCode, String language, String bunho, String genericYn,
			String gwa, String inputTab) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.BUNHO                                                     BUNHO             ,													");														
		sql.append("	       A.GWA                                                       GWA               ,                                                  ");                     
		sql.append("	       A.PKOCS1023                                                 PKOCS1023         ,                                                	");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        GROUP_SER         ,                                    ");                     
		sql.append("	       A.SEQ                                                       SEQ               ,                                                  ");                     
		sql.append("	       A.HANGMOG_CODE                                              HANGMOG_CODE      ,                                                  ");                     
		sql.append("	       CASE :f_generic_yn                                                                                                               ");                     
		sql.append("	       WHEN 'N' THEN B.HANGMOG_NAME                                                                                                     ");                     
		sql.append("	       ELSE IF(A.GENERAL_DISP_YN = 'Y', I.GENERIC_NAME, B.HANGMOG_NAME) END HANGMOG_NAME,                                               ");                     
		sql.append("	       A.SPECIMEN_CODE                                             SPECIMEN_CODE     ,                                                  ");                     
		sql.append("	       CASE SUBSTR(LTRIM(CAST(A.SURYANG AS CHAR)), 1, 1)                                                                                ");                     
		sql.append("	       WHEN '.' THEN CONCAT('0',LTRIM(CAST(A.SURYANG AS CHAR)))                                                                         ");                     
		sql.append("	       ELSE LTRIM(CAST(A.SURYANG AS CHAR)) END                     SURYANG           ,                                                  ");                     
		sql.append("	       A.ORD_DANUI                                                 ORD_DANUI         ,                                                  ");                     
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI,                                                                                  ");                     
		sql.append("	       :f_hosp_code, :language)                                    ORD_DANUI_NAME    ,                                                  ");                     
		sql.append("	       A.DV_TIME                                                   DV_TIME           ,                                                  ");                     
		sql.append("	       IFNULL(A.DV  , 0)                                           DV                ,                                                  ");                     
		sql.append("	       IFNULL(A.DV_1, 0)                                           DV_1              ,                                                  ");                     
		sql.append("	       IFNULL(A.DV_2, 0)                                           DV_2              ,                                                  ");                     
		sql.append("	       IFNULL(A.DV_3, 0)                                           DV_3              ,                                                  ");                     
		sql.append("	       IFNULL(A.DV_4, 0)                                           DV_4              ,                                                  ");                     
		sql.append("	       A.NALSU                                                     NALSU             ,                                                  ");                     
		sql.append("	       A.JUSA                                                      JUSA              ,                                                  ");                     
		sql.append("	       A.BOGYONG_CODE                                              BOGYONG_CODE      ,                                                  ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        EMERGENCY         ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        PAY               ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        FLUID_YN          ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        TPN_YN            ,                                    ");                     
		sql.append("	       A.ANTI_CANCER_YN                                            ANTI_CANCER_YN    ,                                                  ");                     
		sql.append("	       A.PORTABLE_YN                                               PORTABLE_YN       ,                                                  ");                     
		sql.append("	       A.POWDER_YN                                                 POWDER_YN         ,                                                  ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        SPECIAL_YN        ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        ACT_DOCTOR        ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        MUHYO             ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        SYMYA             ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        SPECIAL_RATE      ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        ACT_DOCTOR_NAME   ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        PRN_YN            ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        PREPARE_YN        ,                                    ");                     
		sql.append("	       A.ORDER_GUBUN                                               ORDER_GUBUN       ,                                                  ");                     
		sql.append("	       B.ORDER_GUBUN                                               ORDER_GUBUN_BAS   ,                                                  ");                     
		sql.append("	       IFNULL(FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN', A.ORDER_GUBUN,                                                                       ");                     
		sql.append("	       :f_hosp_code, :language), 'Etc')                           ORDER_GUBUN_NAME  ,                                                   ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        ORDER_REMARK      ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        NURSE_REMARK      ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        MIX_GROUP         ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        WONYOI_ORDER_YN   ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        WONNAE_SAYU_CODE  ,                                    ");                     
		sql.append("	       B.INPUT_CONTROL                                             INPUT_CONTROL     ,                                                  ");                     
		sql.append("	       B.SUGA_YN                                                   SUGA_YN           ,                                                  ");                     
		sql.append("	       B.JAERYO_YN                                                 JAERYO_YN         ,                                                  ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        SPECIAL_CHECK     ,                                    ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        PRIS_NAME         ,                                    ");                     
		sql.append("	       B.SLIP_CODE                                                 SLIP_CODE         ,                                                  ");                     
		sql.append("	       CASE IFNULL(B.EMERGENCY, 'Z')                                                                                                    ");                     
		sql.append("	       WHEN 'Y' THEN 'N'                                                                                                                ");                     
		sql.append("	       WHEN 'N' THEN 'N' ELSE 'Y' END                              EMERGENCY_CHECK   ,                                                  ");                     
		sql.append("	       B.SPECIMEN_YN                                               SPECIMEN_YN       ,                                                  ");                     
		sql.append("	       'N'                                                         MULTI_GUMSA_YN    ,                                                  ");                     
		sql.append("	       C.SPECIMEN_CR_YN                                            SPECIMEN_CR_YN    ,                                                  ");                     
		sql.append("	       C.SURYANG_CR_YN                                             SURYANG_CR_YN     ,                                                  ");                     
		sql.append("	       C.ORD_DANUI_CR_YN                                           ORD_DANUI_CR_YN   ,                                                  ");                     
		sql.append("	       'N'                                                         DV_TIME_CR_YN     ,                                                  ");                     
		sql.append("	       C.DV_CR_YN                                                  DV_CR_YN          ,                                                  ");                     
		sql.append("	       C.NALSU_CR_YN                                               NALSU_CR_YN       ,                                                  ");                     
		sql.append("	       C.JUSA_CR_YN                                                JUSA_CR_YN        ,                                                  ");                     
		sql.append("	       C.BOGYONG_CODE_CR_YN                                        BOGYONG_CODE_CR_YN,                                                  ");                     
		sql.append("	       C.TOIWON_DRG_CR_YN                                          TOIWON_DRG_CR_YN  ,                                                  ");                     
		sql.append("	       'N'                                                         TPN_CR_YN         ,                                                  ");                     
		sql.append("	       'N'                                                         ANTI_CANCER_CR_YN ,                                                  ");                     
		sql.append("	       'N'                                                         FLUID_CR_YN       ,                                                  ");                     
		sql.append("	       'N'                                                         PORTABLE_CR_YN    ,                                                  ");                     
		sql.append("	       'N'                                                         DONER_CR_YN       ,                                                  ");                     
		sql.append("	       C.AMT_CR_YN                                                 AMT_CR_YN         ,                                                  ");                     
		sql.append("	       FN_OCS_LOAD_SPECIMEN_NAME(:f_hosp_code,A.SPECIMEN_CODE)     SPECIMEN_NAME     ,                                                  ");                     
		sql.append("	       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA,                                                                                            ");                     
		sql.append("	       :f_hosp_code, :language)                                    JUSA_NAME         ,                                                  ");                     
		sql.append("	       CAST(NULL AS CHAR)                                                        PAY_NAME          ,                                    ");                     
		sql.append("	       FN_OCS_LOAD_BOGYONG_COL_NAME(:f_hosp_code, :language, B.ORDER_GUBUN,                                                             ");                     
		sql.append("	       A.BOGYONG_CODE)                                             BOGYONG_NAME      ,                                                  ");                     
		sql.append("	       D.BUN_CODE                                                  BUN_CODE          ,                                                  ");                     
		sql.append("	       B.LIMIT_SURYANG                                             LIMIT_SURYANG     ,                                                  ");                     
		sql.append("	       B.LIMIT_NALSU                                               LIMIT_NALSU       ,                                                  ");                     
		// get needed columns for function FN_OCS_BULYONG_CHECK_OUT
		sql.append("	       IFNULL(DATE_FORMAT(Z.BULYONG_YMD, '%Y/%m/%d'), '9998/12/31')  BULYONG_CHECK     ,                                                ");                     
		sql.append("	       A.INPUT_TAB                                                 INPUT_TAB         ,                                                  ");                     
		sql.append("	       IFNULL(A.DV_5, 0)                                           DV_5              ,                                                  ");                     
		sql.append("	       IFNULL(A.DV_6, 0)                                           DV_6              ,                                                  ");                     
		sql.append("	       IFNULL(A.DV_7, 0)                                           DV_7              ,                                                  ");                     
		sql.append("	       IFNULL(A.DV_8, 0)                                           DV_8              ,                                                  ");                     
		sql.append("	       IFNULL(A.GENERAL_DISP_YN, 'N')                              GENERAL_DISP_YN   ,                                                  ");                     
		sql.append("	       I.GENERIC_NAME                                                                                                                   "); 
		sql.append("	  FROM  OCS0103 B                                                                                                                       ");                              
		sql.append("	       LEFT JOIN ( SELECT A.SG_CODE                                                                                                   	");                              
		sql.append("	              , A.SG_NAME                                                                                                               ");                     
		sql.append("	              , A.BUN_CODE                                                                                                              ");                     
		sql.append("	              , A.HOSP_CODE                                                                                                             ");                     
		sql.append("	           FROM BAS0310 A                                                                                                               ");                     
		sql.append("	          WHERE A.HOSP_CODE = :f_hosp_code                                                                                              ");                     
		sql.append("	            AND A.SG_YMD = ( SELECT MAX(B.SG_YMD)                                                                                       ");                     
		sql.append("	                               FROM BAS0310 B                                                                                           ");                     
		sql.append("	                              WHERE B.HOSP_CODE = :f_hosp_code                                                                          ");                     
		sql.append("	                                AND B.SG_CODE   = A.SG_CODE                                                                             ");                     
		sql.append("	                                AND B.SG_YMD   <= SYSDATE())) D ON D.HOSP_CODE= :f_hosp_code AND D.SG_CODE = B.SG_CODE                  ");
		sql.append("		    LEFT JOIN ( SELECT X.SG_CODE                                                                                                    ");       
		sql.append("	                  , X.HOSP_CODE                                                                                                         ");      
		sql.append("	                  , X.BULYONG_YMD                                                                                                       ");      
		sql.append("	      			  FROM BAS0310 X                                                                                                        ");      
		sql.append("	      			  WHERE X.SG_YMD =(SELECT MAX(Y.SG_YMD)                                                                                 ");      
		sql.append("	                  FROM BAS0310 Y                                                                                                        ");      
		sql.append("	                  WHERE Y.SG_CODE = X.SG_CODE                                                                                           ");      
		sql.append("	                  AND Y.SG_YMD <= SYSDATE()) AND X.HOSP_CODE = :f_hosp_code) Z ON Z.HOSP_CODE = :f_hosp_code AND Z.SG_CODE = B.SG_CODE  ");      
		sql.append("	                  AND B.START_DATE =                                                                                                    ");      
		sql.append("	                   (SELECT MAX(Z.START_DATE)  FROM OCS0103 Z WHERE Z.HANGMOG_CODE = B.HANGMOG_CODE AND Z.START_DATE <= SYSDATE() )     	");       								
		sql.append("	       LEFT JOIN OCS0109 I ON I.HOSP_CODE = :f_hosp_code AND I.GENERIC_CODE = SUBSTR(B.YAK_KIJUN_CODE, 1, 9),                           ");                     
		sql.append("	       OCS0132 E,                                                                                                                       ");                     
		sql.append("	       OCS1023 A,                                                                                                                       ");                     
		sql.append("	       OCS0133 C                                                                                                                        ");                     
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code                                                                                                   ");                     
		sql.append("	   AND A.BUNHO         = :f_bunho                                                                                                       ");                     
		sql.append("	   AND A.GWA           = :f_gwa                                                                                                         ");                     
		sql.append("	   AND A.INPUT_TAB  LIKE :f_input_tab                                                                                                   ");                     
		sql.append("	   AND B.HOSP_CODE     = :f_hosp_code                                                                                                   ");                     
		sql.append("	   AND B.HANGMOG_CODE  = A.HANGMOG_CODE                                                                                                 ");                     
		sql.append("	   AND SYSDATE() BETWEEN B.START_DATE AND B.END_DATE                                                                                    ");                     
		sql.append("	   AND C.HOSP_CODE     = :f_hosp_code                                                                                                   ");                     
		sql.append("	   AND C.INPUT_CONTROL = B.INPUT_CONTROL                                                                                                ");                     
		sql.append("	   AND E.HOSP_CODE     = :f_hosp_code                                                                                                   ");                     
		sql.append("	   AND E.CODE          = A.ORDER_GUBUN                                                                                                  ");                     
		sql.append("	   AND E.CODE_TYPE     = 'ORDER_GUBUN'  AND E.LANGUAGE      = C.LANGUAGE                                                                ");                     
		sql.append("	   AND E.LANGUAGE      = :language                                                                                                      ");                     
		sql.append("	 ORDER BY E.SORT_KEY, A.SEQ																												");			          
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_input_tab", inputTab);
		query.setParameter("language", language);
		query.setParameter("f_generic_yn", genericYn);
		
		List<Ocs1023U00GrdOcs1023Info> list = new JpaResultMapper().list(query, Ocs1023U00GrdOcs1023Info.class);
		return list;
	}
	
	
	@Override
	public String callPrOcsMakeRegularOrder(String hospCode, String gubun, Double pkKey, String userId){
		String ioFlg = "";
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_MAKE_REGULAR_ORDER");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PK_KEY", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_PK_KEY", pkKey);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("IO_MSG", "");
		query.setParameter("IO_FLAG", "");
		query.execute();
		
		ioFlg = (String)query.getOutputParameterValue("IO_FLAG");
		return ioFlg;
	}
}


