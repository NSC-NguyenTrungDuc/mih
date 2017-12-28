package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs6010RepositoryCustom;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10LayQueryLayoutInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10LaySiksaJunpyoInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10LoadDetailDataInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupMAgrdOCS2016Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmARActingOCS2005Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmARActinggrdOCS2015Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmARActinggrdOCS2016Info;
import nta.med.data.model.ihis.system.FnInpLoadJaewonIlsuInfo;

/**
 * @author dainguyen.
 */
public class Ocs6010RepositoryImpl implements Ocs6010RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<FnInpLoadJaewonIlsuInfo> getFnInpLoadJaewonIlsuInfo(String hospCode, String bunho, Double naewonKey){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CP_CODE CP_CODE, A.APP_DATE APP_DATE   ");
		sql.append("  FROM OCS6010 A                                ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code               ");
		sql.append("   AND A.BUNHO = :f_bunho                       ");
		sql.append("   AND A.FKINP1001 = IFNULL(:f_naewon_key,0)    ");
		sql.append("   AND A.CP_YN     = 'Y'                        ");
		sql.append("   AND IFNULL(A.CP_END_YN, 'N') = 'N'           ");
		sql.append(" ORDER BY A.APP_DATE ASC, A.PKOCS6010 ASC       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_key", naewonKey);
		
		List<FnInpLoadJaewonIlsuInfo> list = new JpaResultMapper().list(query, FnInpLoadJaewonIlsuInfo.class);
		return list;
	}

	@Override
	public String getOBIsCPPatientYn(String hospCode, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CASE SIGN(COUNT(A.FKINP1001)) WHEN 1 THEN 'Y' ELSE 'N' END	");
		sql.append("	FROM OCS6010 A														");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code									");
		sql.append("	  AND A.FKINP1001 = :f_fkinp1001									");
		sql.append("	  AND A.CP_YN     = 'Y'												");
		sql.append("	  AND IFNULL(A.CP_END_YN,'N') = 'N'									");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<String> listStr = query.getResultList();
		return CollectionUtils.isEmpty(listStr) ? "" : listStr.get(0);
	}

	@Override
	public List<OCS6010U10LayQueryLayoutInfo> getOCS6010U10LayQueryLayoutInfo(String hospCode, String language,
			String bunho, Double fkInp1001, Date orderDate, String queryGubun, String inputDoctor, String inputGubun) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.FKINP1001                                                                                                             IN_OUT_KEY				");
		sql.append("	     , A.PKOCS2003                                                                                                             PKOCSKEY					");
		sql.append("	     , A.BUNHO                                                                                                                 BUNHO					");
		sql.append("	     , DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d')                                                                                   ORDER_DATE				");
		sql.append("	     , E.GWA                                                                                                                   GWA						");
		sql.append("	     , A.DOCTOR                                                                                                                DOCTOR					");
		sql.append("	     , A.DOCTOR                                                                                                                RESIDENT					");
		sql.append("	     , E.IPWON_TYPE                                                                                                            NAEWON_TYPE				");
		sql.append("	     , ''                                                                                                                      JUBSU_NO					");
		sql.append("	     , A.INPUT_ID                                                                                                              INPUT_ID					");
		sql.append("	     , A.INPUT_PART                                                                                                            INPUT_PART				");
		sql.append("	     , A.INPUT_GWA                                                                                                             INPUT_GWA				");
		sql.append("	     , A.INPUT_DOCTOR                                                                                                          INPUT_DOCTOR				");
		sql.append("	     , A.INPUT_GUBUN                                                                                                           INPUT_GUBUN				");
		sql.append("	     , IFNULL(FN_OCS_LOAD_CODE_NAME('INPUT_GUBUN', A.INPUT_GUBUN, :f_hosp_code, :f_language), '')                              INPUT_GUBUN_NAME			");
		sql.append("	     , A.GROUP_SER                                                                                                             GROUP_SER                ");
		sql.append("	     , A.INPUT_TAB                                                                                                             INPUT_TAB                ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_CODE_NAME('INPUT_TAB', A.INPUT_TAB, :f_hosp_code, :f_language), '')                                  INPUT_TAB_NAME			");
		sql.append("	     , A.ORDER_GUBUN                                                                                                           ORDER_GUBUN				");
		sql.append("	     , IFNULL(FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN', A.ORDER_GUBUN, :f_hosp_code, :f_language), '')                              ORDER_GUBUN_NAME			");
		sql.append("	     , B.GROUP_YN                                                                                                              GROUP_YN					");
		sql.append("	     , A.SEQ                                                                                                                   SEQ						");
		sql.append("	     , A.SLIP_CODE                                                                                                             SLIP_CODE                ");
		sql.append("	     , A.HANGMOG_CODE                                                                                                          HANGMOG_CODE             ");
		sql.append("	     , B.HANGMOG_NAME                                                                                                          HANGMOG_NAME             ");
		sql.append("	     , A.SPECIMEN_CODE                                                                                                         SPECIMEN_CODE            ");
		sql.append("	     , C.SPECIMEN_NAME                                                                                                         SPECIMEN_NAME            ");
		sql.append("	     , A.SURYANG                                                                                                               SURYANG					");
		sql.append("	     , A.SURYANG                                                                                                               SUNAB_SURYANG            ");
		sql.append("	     , A.SUBUL_SURYANG                                                                                                         SUBUL_SURYANG            ");
		sql.append("	     , IFNULL(A.ORD_DANUI, '')																								   ORD_DANUI	            ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :f_language), '')                                  ORD_DANUI_NAME			");
		sql.append("	     , A.DV_TIME                                                                                                               DV_TIME					");
		sql.append("	     , A.DV                                                                                                                    DV	                    ");
		sql.append("	     , A.DV_1                                                                                                                  DV_1	                    ");
		sql.append("	     , A.DV_2                                                                                                                  DV_2	                    ");
		sql.append("	     , A.DV_3                                                                                                                  DV_3	                    ");
		sql.append("	     , A.DV_4                                                                                                                  DV_4	                    ");
		sql.append("	     , A.NALSU                                                                                                                 NALSU                    ");
		sql.append("	     , ''                                                                                                                      SUNAB_NALSU              ");
		sql.append("	     , IFNULL(A.JUSA, '')                                                                                                      JUSA                     ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA, :f_hosp_code, :f_language), '')                                            JUSA_NAME                ");
		sql.append("	     , IFNULL(A.JUSA_SPD_GUBUN, '')                                                                                            JUSA_SPD_GUBUN			");
		sql.append("	     , IFNULL(A.BOGYONG_CODE, '')                                                                                              BOGYONG_CODE				");
		sql.append("	     , CASE WHEN B.INPUT_CONTROL = 'A' THEN IFNULL(FN_CHT_LOAD_CHT0117_NAME (A.BOGYONG_CODE ), '')														");
		sql.append("	            ELSE IFNULL(FN_DRG_LOAD_BOGYONG_NAME(A.BOGYONG_CODE, :f_hosp_code), '')																		");
		sql.append("	       END                                                                                                                     BOGYONG_NAME             ");
		sql.append("	     , A.EMERGENCY                                                                                                             EMERGENCY                ");
		sql.append("	     , A.JAERYO_JUNDAL_YN                                                                                                      JAERYO_JUNDAL_YN         ");
		sql.append("	     , A.JUNDAL_TABLE                                                                                                          JUNDAL_TABLE             ");
		sql.append("	     , A.JUNDAL_PART                                                                                                           JUNDAL_PART              ");
		sql.append("	     , A.MOVE_PART                                                                                                             MOVE_PART				");
		sql.append("	     , A.PORTABLE_YN                                                                                                           PORTABLE_YN1		        ");
		sql.append("	     , A.POWDER_YN                                                                                                             POWDER_YN		        ");
		sql.append("	     , A.HUBAL_CHANGE_YN                                                                                                       HUBAL_CHANGE_YN	        ");
		sql.append("	     , A.PHARMACY                                                                                                              PHARMACY			        ");
		sql.append("	     , A.DRG_PACK_YN                                                                                                           DRG_PACK_YN		        ");
		sql.append("	     , A.MUHYO                                                                                                                 MUHYO					");
		sql.append("	     , ''                                                                                                                      PRN_YN					");
		sql.append("	     , ''                                                                                                                      TOIWON_DRG_YN	        ");
		sql.append("	     , ''                                                                                                                      PRN_NURSE		        ");
		sql.append("	     , ''                                                                                                                      APPEND_YN		        ");
		sql.append("	     , IFNULL(A.ORDER_REMARK, '')                                                                                              ORDER_REMARK		        ");
		sql.append("	     , IFNULL(A.NURSE_REMARK, '')                                                                                              NURSE_REMARK		        ");
		sql.append("	     , ''                                                                                                                      COMMENTS			        ");
		sql.append("	     , IFNULL(A.MIX_GROUP, '')                                                                                                 MIX_GROUP		        ");
		sql.append("	     , A.AMT                                                                                                                   AMT				        ");
		sql.append("	     , A.PAY                                                                                                                   PAY				        ");
		sql.append("	     , A.WONYOI_ORDER_YN                                                                                                       WONYOI_ORDER_YN			");
		sql.append("	     , 'N'                                                                                                                     DANGIL_GUMSA_ORDER_YN	");
		sql.append("	     , 'N'                                                                                                                     DANGIL_GUMSA_RESULT_YN	");
		sql.append("	     , A.BOM_OCCUR_YN                                                                                                          BOM_OCCUR_YN				");
		sql.append("	     , A.BOM_SOURCE_KEY                                                                                                        BOM_SOURCE_KEY			");
		sql.append("	     , A.DISPLAY_YN                                                                                                            DISPLAY_YN	            ");
		sql.append("	     , IF(A.SUNAB_DATE IS NULL, 'N', 'Y')                                                                                      SUNAB_YN		            ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.SUNAB_DATE, '%Y/%m/%d'), '')                                                                       SUNAB_DATE	            ");
		sql.append("	     , ''                                                                                                                      SUNAB_TIME	            ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.HOPE_DATE, '%Y/%m/%d'), '')                                                                        HOPE_DATE	            ");
		sql.append("	     , IFNULL(A.HOPE_TIME, '')                                                                                                 HOPE_TIME	            ");
		sql.append("	     , IFNULL(A.NURSE_CONFIRM_USER, '')                                                                                        NURSE_CONFIRM_USER       ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.NURSE_CONFIRM_DATE, '%Y/%m/%d'), '')                                                               NURSE_CONFIRM_DATE       ");
		sql.append("	     , IFNULL(A.NURSE_CONFIRM_TIME, '')                                                                                        NURSE_CONFIRM_TIME       ");
		sql.append("	     , ''                                                                                                                      NURSE_PICKUP_USER        ");
		sql.append("	     , ''                                                                                                                      NURSE_PICKUP_DATE        ");
		sql.append("	     , ''                                                                                                                      NURSE_PICKUP_TIME        ");
		sql.append("	     , ''                                                                                                                      NURSE_HOLD_USER          ");
		sql.append("	     , ''                                                                                                                      NURSE_HOLD_DATE          ");
		sql.append("	     , ''                                                                                                                      NURSE_HOLD_TIME          ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d'), '')                                                                       RESER_DATE               ");
		sql.append("	     , IFNULL(A.RESER_TIME, '')                                                                                                RESER_TIME               ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d'), '')                                                                       JUBSU_DATE               ");
		sql.append("	     , IFNULL(A.JUBSU_TIME, '')                                                                                                JUBSU_TIME               ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d'), '')                                                                      ACTING_DATE              ");
		sql.append("	     , IFNULL(A.ACTING_TIME, '')                                                                                               ACTING_TIME              ");
 		sql.append("	     , A.ACTING_DAY                                                                                                            ACTING_DAY 	            ");
		sql.append("	     , IFNULL(DATE_FORMAT(A.RESULT_DATE , '%Y/%m/%d'), '')                                                                     RESULT_DATE	            ");
		sql.append("	     , IFNULL(A.DC_GUBUN, '')                                                                                                  DC_GUBUN		            ");
		sql.append("	     , IFNULL(A.DC_YN, '')                                                                                                     DC_YN		            ");
		sql.append("	     , A.BANNAB_YN                                                                                                             BANNAB_YN		        ");
		sql.append("	     , A.BANNAB_CONFIRM                                                                                                        BANNAB_CONFIRM	        ");
		sql.append("	     , A.SOURCE_FKOCS2003                                                                                                      SOURCE_ORD_KEY	        ");
		sql.append("	     , IFNULL(A.OCS_FLAG, '')                                                                                                  OCS_FLAG			        ");
		sql.append("	     , A.SG_CODE                                                                                                               SG_CODE			        ");
		sql.append("	     , A.SG_YMD                                                                                                                SG_YMD			        ");
		sql.append("	     , IFNULL(A.IO_GUBUN, '')                                                                                                  IO_GUBUN			        ");
		sql.append("	     , 'N'                                                                                                                     AFTER_ACT_YN		        ");
		sql.append("	     , IFNULL(A.BICHI_YN, '')                                                                                                  BICHI_YN			        ");
		sql.append("	     , IFNULL(A.DRG_BUNHO, '')                                                                                                 DRG_BUNHO		        ");
		sql.append("	     , IFNULL(A.SUB_SUSUL, '')																								   SUB_SUSUL		        ");
		sql.append("	     , A.PRINT_YN                                                                                                              PRINT_YN			        ");
		sql.append("	     , IFNULL(A.CHISIK, '')																									   CHISIK			        ");
		sql.append("	     , A.TEL_YN                                                                                                                TEL_YN			        ");
		sql.append("	     , B.ORDER_GUBUN                                                                                                           ORDER_GUBUN_BAS	        ");
		sql.append("	     , B.INPUT_CONTROL                                                                                                         INPUT_CONTROL	        ");
		sql.append("	     , B.SUGA_YN                                                                                                               SUGA_YN			        ");
		sql.append("	     , B.JAERYO_YN                                                                                                             JAERYO_YN		        ");
		sql.append("	     , IF(B.WONYOI_ORDER_YN = 'Z', 'Y', 'N')                                                                                   WONYOI_CHECK				");
		sql.append("	     , IF(B.EMERGENCY = 'Z', 'Y', 'N')                                                                                         EMERGENCY_CHECK	        ");
		sql.append("	     , B.SPECIMEN_YN                                                                                                           SPECIMEN_CHECK	        ");
		sql.append("	     , A.PORTABLE_YN                                                                                                           PORTABLE_YN2		        ");
		sql.append("	     , CASE WHEN B.END_DATE IS NULL THEN 'N'																											");
		sql.append("	            WHEN B.END_DATE = STR_TO_DATE('99981231','%Y%m%d') THEN 'N'																					");
		sql.append("	            ELSE 'Y'																																	");
		sql.append("	       END                                                                                                                     BULYONG_CHECK	        ");
		sql.append("	     , IF(A.SUNAB_DATE IS NULL, 'N', 'Y')                                                                                      SUNAB_CHECK		        ");
		sql.append("	     , CASE SIGN(A.NALSU) WHEN 1 THEN 'N' WHEN 0 THEN 'N' ELSE 'Y' END                                                         DC_CHECK			        ");
		sql.append("	     , A.DC_GUBUN                                                                                                              DC_GUBUN_CHECK	        ");
		sql.append("	     , IF(A.NURSE_PICKUP_DATE IS NULL, 'N', 'Y')                                                                               CONFIRM_CHECK	        ");
		sql.append("	     , IF(A.RESER_DATE IS NULL, 'N', 'Y')                                                                                      RESER_YN_CHECK	        ");
		sql.append("	   , IF(A.CHISIK IS NULL, 'N', 'Y')                                                                                            CHISIK_YN		        ");
		sql.append("	     , A.NDAY_YN                                                                                                               NDAY_YN			        ");
		sql.append("	     , FN_OCS_LOAD_JAERYO_JUNDAL_YN (:f_hosp_code, 'O', A.INPUT_PART, A.HANGMOG_CODE) DEFAULT_JAERYO_JUNDAL_YN											");
		sql.append("	     , ( CASE WHEN A.ORDER_GUBUN NOT IN ('A', 'B', 'C', 'D') OR																							");
		sql.append("	                    A.WONYOI_ORDER_YN = 'Z'                   OR																						");
		sql.append("	                    A.WONYOI_ORDER_YN = 'Y'																												");
		sql.append("	               THEN 'N'																																	");
		sql.append("	               ELSE 'Y' END )                                                                                                  DEFAULT_WONYOI_YN	    ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT, '')                                                                                          SPECIFIC_COMMENT		    ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_NAME, '')                                                                                     SPECIFIC_COMMENT_NAME    ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_SYS_ID, '')                                                                                   SPECIFIC_COMMENT_SYS_ID  ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_PGM_ID, '')                                                                                   SPECIFIC_COMMENT_PGM_ID  ");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_NOT_NULL, '')                                                                                 SPECIFIC_COMMENT_NOT_NULL");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_TABLE_ID, '')                                                                                 SPECIFIC_COMMENT_TABLE_ID");
		sql.append("	     , IFNULL(D.SPECIFIC_COMMENT_COL_ID, '')                                                                                   SPECIFIC_COMMENT_COL_ID  ");
		sql.append("	     , FN_DRG_LOAD_DONBOK_YN (A.BOGYONG_CODE, :f_hosp_code) DONBOG_YN																					");
		sql.append("	     , FN_OCS_LOAD_CODE_NAME ('ORDER_GUBUN_BAS', SUBSTRING(A.ORDER_GUBUN, 2, 1), :f_hosp_code, :f_language)                    ORDER_GUBUN_BAS_NAME		");
		sql.append("	     , IFNULL(A.ACT_DOCTOR, '')                                                                                                ACT_DOCTOR				");
		sql.append("	     , IFNULL(A.ACT_BUSEO, '')                                                                                                 ACT_BUSEO				");
		sql.append("	     , IFNULL(A.ACT_GWA, '')                                                                                                   ACT_GWA					");
		sql.append("	     , 'N'                                                                                                                     HOME_CARE_YN				");
		sql.append("	     , A.REGULAR_YN                                                                                                            REGULAR_YN				");
		sql.append("	     , A.SORT_FKOCSKEY                                                                                                         SORT_FKOCSKEY			");
		sql.append("	     , CASE WHEN IF(A.BOM_SOURCE_KEY IS NULL,FN_OCS_LOAD_CHILD_GUBUN(:f_hosp_code, 'I',A.PKOCS2003),'3') != '3' THEN 'N'								");
		sql.append("	            ELSE 'Y'																																	");
		sql.append("	       END                                                                                                                     CHILD_YN					");
		sql.append("	     , B.IF_INPUT_CONTROL                                                                                                      IF_INPUT_CONTROL			");
		sql.append("	     , IF(A.BOM_SOURCE_KEY IS NULL,FN_OCS_LOAD_CHILD_GUBUN(:f_hosp_code, 'I',A.PKOCS2003),'3')                                 CHILD_GUBUN				");
		sql.append("	     , F.SLIP_NAME                                                                                                             SLIP_NAME				");
		sql.append("	     , A.NDAY_OCCUR_YN                                                                                                         NDAY_OCCUR_YN	        ");
		sql.append("	     , A.PKOCS2003                                                                                                             ORG_KEY			        ");
		sql.append("	     , A.BOM_SOURCE_KEY                                                                                                        PARENT_KEY		        ");
		sql.append("	     , G.BUN_CODE                                                                                                              BUN_CODE			        ");
		sql.append("	     , IFNULL(B.WONNAE_DRG_YN, '')                                                                                             WONNAE_DRG_YN	        ");
		sql.append("	     , IFNULL(H.TOIJANG_YN, 'N')                                                                                               HUBAL_CHANGE_CHECK		");
		sql.append("	     , IFNULL(H.CHK3, 'N')                                                                                                     DRG_PACK_CHECK           ");
		sql.append("	     , IFNULL(H.CHK2, 'N')                                                                                                     PHARMACY_CHECK           ");
		sql.append("	     , IFNULL(H.CHK1, 'N')                                                                                                     POWDER_CHECK             ");
		sql.append("	     , IFNULL(FN_OCS_LOAD_ORDER_SORT_KEY ( 'I', A.PKOCS2003, :f_hosp_code), '')                                                ORDER_BY_KEY             ");
		sql.append("	  FROM OCS2003 A																																		");
		sql.append("	  JOIN OCS0103 B ON B.HOSP_CODE     = A.HOSP_CODE																										");
		sql.append("	                AND B.HANGMOG_CODE  = A.HANGMOG_CODE																									");
		sql.append("	                AND A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE	                                                                                ");
		sql.append("	  LEFT JOIN OCS0116 C ON A.HOSP_CODE      = C.HOSP_CODE					                                                                                ");
		sql.append("	                     AND A.SPECIMEN_CODE  = C.SPECIMEN_CODE				                                                                                ");
		sql.append("	  LEFT JOIN OCS0170 D ON D.HOSP_CODE        = A.HOSP_CODE				                                                                                ");
		sql.append("	                     AND D.SPECIFIC_COMMENT = B.SPECIFIC_COMMENT		                                                                                ");
		sql.append("	  JOIN VW_OCS_INP1001_RES E ON E.HOSP_CODE = A.HOSP_CODE				                                                                                ");
		sql.append("	                           AND E.PKINP1001 = A.FKINP1001				                                                                                ");
		sql.append("	  LEFT JOIN OCS0102 F ON F.HOSP_CODE  = A.HOSP_CODE						                                                                                ");
		sql.append("	                     AND F.SLIP_CODE  = A.SLIP_CODE						                                                                                ");
		sql.append("	  LEFT JOIN ( SELECT  Y.SG_CODE                                                                                                                         ");
		sql.append("	                    , Y.SG_NAME                                                                                                                         ");
		sql.append("	                    , Y.BUN_CODE                           	 																							");
		sql.append("	              FROM BAS0310 Y							                                                                                                ");
		sql.append("	              WHERE Y.HOSP_CODE = :f_hosp_code			                                                                                                ");
		sql.append("	                AND Y.SG_YMD = ( SELECT MAX(Z.SG_YMD)	                                                                                                ");
		sql.append("	                                   FROM BAS0310 Z		                                                                                                ");
		sql.append("	                                  WHERE Z.HOSP_CODE  = Y.HOSP_CODE                                                                                      ");
		sql.append("	                                    AND Z.SG_CODE    = Y.SG_CODE                                                                                        ");
		sql.append("	                                    AND Z.SG_YMD <= CURRENT_DATE )                                                                                      ");
		sql.append("	  ) G ON G.SG_CODE  = B.SG_CODE																															");
		sql.append("	  LEFT JOIN INV0110 H ON H.HOSP_CODE    = A.HOSP_CODE	                                                                                                ");
		sql.append("	                     AND H.JAERYO_CODE  = A.HANGMOG_CODE                                                                                                ");
		sql.append("	  ,(select @kcck_hosp_code\\:=:f_hosp_code) TMP			                                                                                                ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code					                                                                                                ");
		sql.append("	   AND A.BUNHO          = :f_bunho						                                                                                                ");
		sql.append("	   AND A.FKINP1001      = :f_fkinp1001					                                                                                                ");
		sql.append("	   AND (  												                                                                                                ");
		sql.append("	         ( A.INPUT_TAB      = '01'																														");
		sql.append("	           AND :f_order_date BETWEEN A.ORDER_DATE AND DATE_ADD(A.ORDER_DATE, INTERVAL ABS(A.NALSU)-1 DAY))												");
		sql.append("	         OR																																				");
		sql.append("	         ( A.INPUT_TAB     != '01'																														");
		sql.append("	           AND A.ORDER_DATE     = :f_order_date )																										");
		sql.append("	       )																																				");
		sql.append("	   AND (																																				");
		sql.append("	         ( :f_query_gubun = 'D'		                                                                                                                    ");
		sql.append("	           AND						                                                                                                                    ");
		sql.append("	           A.INPUT_GUBUN LIKE 'D%'	                                                                                                                    ");
		sql.append("	           AND																								                                            ");
		sql.append("	           A.INPUT_DOCTOR = :f_input_doctor )																                                            ");
		sql.append("	         OR																									                                            ");
		sql.append("	         ( :f_query_gubun != 'D'																			                                            ");
		sql.append("	           AND																								                                            ");
		sql.append("	           ( A.INPUT_GUBUN = :f_input_gubun OR A.INPUT_GUBUN LIKE 'D%') )									                                            ");
		sql.append("	       )																									                                            ");
		sql.append("	   AND IFNULL(A.DISPLAY_YN, 'Y') = 'Y'																		                                            ");
		sql.append("	 ORDER BY ORDER_BY_KEY																						                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkInp1001);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_query_gubun", queryGubun);
		query.setParameter("f_input_doctor", inputDoctor);
		query.setParameter("f_input_gubun", inputGubun);
		
		List<OCS6010U10LayQueryLayoutInfo> result = new JpaResultMapper().list(query, OCS6010U10LayQueryLayoutInfo.class);
		return result;
	}

	@Override
	public List<OCS6010U10LaySiksaJunpyoInfo> getOCS6010U10LaySiksaJunpyoInfo(String hospCode, String language,
			String bunho, Date fromDate, Date orderDate, Double fkinp1001, String inputGubun, Double pkSeq) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BUNHO                                                                                          BUNHO                                                                 ,");
		sql.append("	     A.FKINP1001                                                                                        FKINP1001                                                             ,");
		sql.append("	       C.SUNAME                                                                                         SUNAME                                                                ,");
		sql.append("	    IFNULL(C.SUNAME2, '')                                                                               SUNAME2                                                               ,");
		sql.append("	       C.BIRTH                                                                                          BIRTH                                                                 ,");
		sql.append("	       FN_BAS_LOAD_AGE(:f_order_date, C.BIRTH, 'XXX')                                                   AGE                                                                   ,");
		sql.append("	       IFNULL(FN_BAS_LOAD_CODE_NAME('SEX', C.SEX, :f_hosp_code, :f_language), '')                       SEX                                                                   ,");
		sql.append("	       F.HEIGHT                                                                                         HEIGHT                                                                ,");
		sql.append("	       F.WEIGHT                                                                                         WEIGHT                                                                ,");
		sql.append("	       B.GWA                                                                                            GWA                                                                   ,");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(B.GWA, IFNULL(A.ORDER_DATE, A.DRT_FROM_DATE), :f_hosp_code, :f_language)    GWA_NAME                                                              ,");
		sql.append("	       B.DOCTOR                                                                                         DOCTOR                                                                ,");
		sql.append("	       IFNULL(B.HO_DONG1, '')                                                                           HO_DONG                                                               ,");
		sql.append("	       IFNULL(E.GWA_NAME, '')                                                                           HO_DONG_NAME                                                          ,");
		sql.append("	       IFNULL(B.HO_CODE1, '')                                                                           HO_CODE                                                               ,");
		sql.append("	       IFNULL(D.NUR_MD_NAME, '')                                                                        SIK_GUBUN                                                             ,");
		sql.append("	       IFNULL(H.NUR_SO_NAME, '')                                                                        SIKSAGUBUN                                                            ,");
		sql.append("	       A.DRT_FROM_DATE                                                                                  DRT_FROM_DATE                                                         ,");
		sql.append("	       IF(A.DRT_TO_DATE IS NULL, '継続', DATE_FORMAT(A.DRT_TO_DATE, '%Y/%m/%d'))                         DRT_TO_DATE   														  ,");
		sql.append("	       DATE_FORMAT(:f_from_date, '%Y/%m/%d')															ORDER_DATE                                                            ,");
		sql.append("	       IFNULL(CONCAT(G.PRE_MODIFIER_NAME, SANG_NAME, POST_MODIFIER_NAME), '')                           SANG_NAME                                                             ,");
		sql.append("	       IFNULL(A.DIRECT_CODE, '')                                                                        DIRECT_CODE                                                            ");
		sql.append("	FROM OCS2005 A											                                                                                                                       ");
		sql.append("	JOIN INP1001 B ON B.HOSP_CODE   = A.HOSP_CODE			                                                                                                                       ");
		sql.append("	              AND B.BUNHO       = A.BUNHO				                                                                                                                       ");
		sql.append("	              AND B.PKINP1001   = A.FKINP1001			                                                                                                                       ");
		sql.append("	JOIN OUT0101 C ON C.HOSP_CODE   = A.HOSP_CODE			                                                                                                                       ");
		sql.append("	              AND C.BUNHO       = A.BUNHO				                                                                                                                       ");
		sql.append("	JOIN NUR0111 D ON D.HOSP_CODE   = A.HOSP_CODE			                                                                                                                       ");
		sql.append("	              AND D.NUR_GR_CODE = A.DIRECT_GUBUN		                                                                                                                       ");
		sql.append("	              AND D.NUR_MD_CODE = A.DIRECT_CODE			                                                                                                                       ");
		sql.append("	JOIN BAS0260 E ON E.HOSP_CODE   = B.HOSP_CODE			                                                                                                                       ");
		sql.append("	              AND E.GWA         = B.HO_DONG1			                                                                                                                       ");
		sql.append("	LEFT JOIN ( SELECT A.HEIGHT, A.WEIGHT, A.BUNHO											                                                                                       ");
		sql.append("	            FROM NUR7001 A																                                                                                       ");
		sql.append("	            WHERE A.HOSP_CODE = :f_hosp_code											                                                                                       ");
		sql.append("	              AND A.BUNHO = :f_bunho													                                                                                       ");
		sql.append("	              AND CONCAT(DATE_FORMAT(A.MEASURE_DATE, '%Y%m%d'), A.MEASURE_TIME) = ( SELECT MAX(CONCAT(DATE_FORMAT(B.MEASURE_DATE, '%Y%m%d'), B.MEASURE_TIME))				   ");
		sql.append("	                                                                                    FROM NUR7001 B																			   ");
		sql.append("	                                                                                    WHERE B.HOSP_CODE = A.HOSP_CODE															   ");
		sql.append("	                                                                                      AND B.BUNHO     = A.BUNHO )															   ");
		sql.append("	) F ON F.BUNHO = A.BUNHO							                                                                                                                           ");
		sql.append("	LEFT JOIN OUTSANG G ON G.HOSP_CODE  = B.HOSP_CODE	                                                                                                                           ");
		sql.append("	                   AND G.BUNHO      = B.BUNHO		                                                                                                                           ");
		sql.append("	                   AND G.GWA        = B.GWA			                                                                                                                           ");
		sql.append("	                   AND G.JU_SANG_YN = 'Y'			                                                                                                                           ");
		sql.append("	JOIN NUR0112 H ON H.HOSP_CODE   = A.HOSP_CODE	                                                                                                                           	   ");
		sql.append("	              AND H.NUR_GR_CODE = A.DIRECT_GUBUN	                                                                                                                           ");
		sql.append("	              AND H.NUR_MD_CODE = A.DIRECT_CODE		                                                                                                                           ");
		sql.append("	              AND H.NUR_SO_CODE = A.DIRECT_CONT1	                                                                                                                           ");
		sql.append("	              AND H.NUR_GR_CODE = D.NUR_GR_CODE		                                                                                                                           ");
		sql.append("	              AND H.NUR_MD_CODE = D.NUR_MD_CODE		                                                                                                                           ");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code	                                                                                                                                           ");
		sql.append("	  AND A.BUNHO       = :f_bunho		                                                                                                                                           ");
		sql.append("	  AND A.FKINP1001   = :f_fkinp1001	                                                                                                                                           ");
		sql.append("	  AND :f_from_date BETWEEN IFNULL(A.DRT_FROM_DATE, A.ORDER_DATE)                                                                                                               ");
		sql.append("	                              AND IF(A.DRT_FROM_DATE IS NULL, A.ORDER_DATE, IFNULL(A.DRT_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d')))                                          ");
		sql.append("	  AND A.INPUT_GUBUN = :f_input_gubun                                                                                                                                           ");
		sql.append("	  AND A.PK_SEQ      = :f_pk_seq                                                                                                                                                ");
		sql.append("	  AND :f_from_date BETWEEN E.START_DATE AND E.END_DATE                                                                                                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", pkSeq);
		
		List<OCS6010U10LaySiksaJunpyoInfo> lstResult = new JpaResultMapper().list(query, OCS6010U10LaySiksaJunpyoInfo.class);
		return lstResult;
	}

	@Override
	public String getOCS6010U10GetCheckValue(String hospCode, String code) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT															");
		sql.append("		FN_OCS_CHECK_CAN_CONFIRM_INP(:f_hosp_code, :f_code)			");
		sql.append("	FROM                                                            ");
		sql.append("		DUAL                                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public String getOCS6010U10GetCheckModifyPlan(String hospCode, String modifyDate, String fkocs6010) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT                                                                  			");
		sql.append("		CASE                                                                 			");
		sql.append("			SIGN(DATEDIFF(STR_TO_DATE(:f_modify_date, '%Y/%m/%d'), APP_DATE))           ");
		sql.append("		WHEN                                                                  			");
		sql.append("			-1                                                                  		");
		sql.append("		THEN                                                                  			");
		sql.append("			'N'                                                                  		");
		sql.append("		ELSE                                                                  			");
		sql.append("			'Y'                                                                  		");
		sql.append("		END 															DATA       		");
		sql.append("	FROM                                                                  				");
		sql.append("		OCS6010                                                                  		");
		sql.append("	WHERE                                                                  				");
		sql.append("		HOSP_CODE 			= :f_hosp_code                                         		");
		sql.append("		AND PKOCS6010 		= :f_fkocs6010												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_modify_date", modifyDate);
		query.setParameter("f_fkocs6010", fkocs6010);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS6010U10LoadDetailDataInfo> getOCS6010U10LoadDetailDataInfo(String hospCode, String language,
			String bunho, Double fkinp1001, Date fromDate, Date toDate, String allSiji, String emergencyTreat,
			String insteadOrderDisplayYn, String fB, String fC, String fD, String fH, String fG, String fM, String fF,
			String fO, String fN, String fE, String fL, String fK, String fI, String fZ, String commentYn, String remarkYn) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BUNHO             ,                                                  ");
		sql.append("	       A.FKINP1001         ,                                                  ");
		sql.append("	       A.FKOCS6010         ,                                                  ");
		sql.append("	       IFNULL(A.CP_NAME,'')   ,                                               ");
		sql.append("	       IFNULL(DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d'), '')	 ORDER_DATE ,	  ");
		sql.append("	       IFNULL(DATE_FORMAT(A.ORDER_END_DATE, '%Y/%m/%d'), '') ORDER_END_DATE,  ");
		sql.append("	       A.INPUT_GUBUN       ,                                                  ");
		sql.append("	       A.INPUT_GUBUN_NAME  ,                                                  ");
		sql.append("	       A.ORDER_GUBUN       ,                                                  ");
		sql.append("	       A.ORDER_GUBUN_ORI   ,                                                  ");
		sql.append("	       A.ORDER_GUBUN_NAME  ,                                                  ");
		sql.append("	       A.HANGMOG_CODE      ,                                                  ");
		sql.append("	       A.HANGMOG_NAME      ,                                                  ");
		sql.append("	       A.SURYANG           ,                                                  ");
		sql.append("	       A.NALSU             ,                                                  ");
		sql.append("	       IF(:f_comment_yn = 'Y', IFNULL(A.DETAIL,''), '') 		DETAIL      , ");
		sql.append("	       IF(:f_remark_yn  = 'Y', IFNULL(A.ORDER_REMARK,''), '') 	ORDER_REMARK, ");
		sql.append("	       IFNULL(A.NURSE_REMARK, '')      , 									  ");
		sql.append("	       A.TEL_YN            ,                                                  ");
		sql.append("	       A.EMERGENCY         ,                                                  ");
		sql.append("	       ifnull(A.JUSA_NAME, '')         JUSA_NAME,							  ");
		sql.append("	       A.BOGYONG_NAME      ,                                                  ");
		sql.append("	       A.JAEWONIL          ,                                                  ");
		sql.append("	       A.PK                ,                                                  ");
		sql.append("	       A.GROUP_SER         ,                                                  ");
		sql.append("	       IFNULL(A.MIX_GROUP, '')         ,                                      ");
		sql.append("	       A.TABLE_ID          ,                                                  ");
		sql.append("	       A.CONFIRM_YN        ,                                                  ");
		sql.append("	       A.ACTING_YN         ,                                                  ");
		sql.append("	       A.CAN_PLAN_CHANGE_YN,                                                  ");
		sql.append("	       A.CAN_CONFIRM_YN    ,                                                  ");
		sql.append("	       A.CAN_ACTING_YN     ,                                                  ");
		sql.append("	       A.CAN_PLAN_APP_YN   ,                                                  ");
		sql.append("	       A.INPUT_NAME        ,                                                  ");
		sql.append("	       A.INPUT_SEQ         ,                                                  ");
		sql.append("	       A.ORDER_END_YN      ,                                                  ");
		sql.append("	       A.CONFIRM_NAME      ,                                                  ");
		sql.append("	       A.DETAIL_ACT_YN     ,                                                  ");
		sql.append("	       A.BULYONG_CHECK     ,                                                  ");
		sql.append("	       A.NURSE_HOLD_USER   ,                                                  ");
		sql.append("	       IFNULL(A.INPUT_GWA,'')         ,                                       ");
		sql.append("	       IFNULL(A.INPUT_DOCTOR,'')      ,                                       ");
		sql.append("	       ifnull(A.RESER_DATE, '')       RESER_DATE,							  ");
		sql.append("	       A.ACTING_DATE       ,                                                  ");
		sql.append("	       A.JUNDAL_TABLE      ,                                                  ");
		sql.append("	       A.JUNDAL_PART       ,                                                  ");
		sql.append("	       A.OCS_FLAG          ,                                                  ");
		sql.append("	       DATE_FORMAT(A.SOURCE_ORDER_DATE, '%Y/%m/%d') 	SOURCE_ORDER_DATE,    ");
		sql.append("	       A.CONTINUE_YN       ,                                                  ");
		sql.append("	       A.JISI_ORDER_GUBUN  ,                                                  ");
		sql.append("	       A.DIRECT_CONT       ,                                                  ");
		sql.append("	       A.PKOCS2005         ,                                                  ");
		sql.append("	       A.PKOCS6015         ,                                                  ");
		sql.append("	       A.INPUT_ID          ,                                                  ");
		sql.append("	       A.DV                ,                                                  ");
		sql.append("	       ifnull(A.CHECK_ACTING, '')     CHECK_ACTING,							  ");
		sql.append("	       IFNULL(A.DIFF,'')              ,                                       ");
		sql.append("	       IFNULL(A.NURSE_ACT_USER,'')    ,                                       ");
		sql.append("	       A.NURSE_ACT_DATE				  ,                                       ");
		sql.append("	       IFNULL(A.NURSE_ACT_TIME,'')    ,                                       ");
		sql.append("	       IFNULL(A.MEDI_ACT_CHK,'')      ,                                       ");
		sql.append("	       IFNULL(A.BROUGHT_DRG_YN,'')    ,                                       ");
		sql.append("	       A.FKOCS1003					  ,                                       ");
		sql.append("	       IFNULL(A.DRT_FROM_DATETIME,'') ,                                       ");
		sql.append("	       IFNULL(A.DRT_TO_DATETIME,'')   ,                                       ");
		sql.append("	       IFNULL(A.JISI_GUBUN,'')												  ");
		sql.append("	 FROM ( 																	  ");
		sql.append("		SELECT A.BUNHO                                                                           BUNHO             ,                                                                                          ");
		sql.append("			  A.FKINP1001                                                                        FKINP1001         ,                                                                                          ");
		sql.append("			  0                                                                                  FKOCS6010         ,                                                                                          ");
		sql.append("			  NULL                                                                               CP_NAME           ,                                                                                          ");
		sql.append("			  F.HOLI_DAY                                                                         ORDER_DATE        ,                                                                                          ");
		sql.append("			  CASE WHEN IF(A.DRT_FROM_DATE IS NULL, A.ORDER_DATE, IFNULL(A.DRT_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d'))) >= STR_TO_DATE(:f_to_date, '%Y/%m/%d') THEN  STR_TO_DATE(:f_to_date, '%Y/%m/%d')  ");
		sql.append("			  ELSE IF(A.DRT_FROM_DATE IS NULL, A.ORDER_DATE, IFNULL(A.DRT_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d')))                                                                                        ");
		sql.append("			  END                                                                                ORDER_END_DATE    ,                                                                                          ");
		sql.append("			  A.INPUT_GUBUN                                                                      INPUT_GUBUN       ,                                                                                          ");
		sql.append("			  E.CODE_NAME                                                                        INPUT_GUBUN_NAME  ,                                                                                          ");
		sql.append("			  A.DIRECT_GUBUN                                                                     ORDER_GUBUN       ,                                                                                          ");
		sql.append("			  A.DIRECT_GUBUN                                                                     ORDER_GUBUN_ORI   ,                                                                                          ");
		sql.append("			  B.NUR_GR_NAME                                                                      ORDER_GUBUN_NAME  ,                                                                                          ");
		sql.append("			  A.DIRECT_CODE                                                                      HANGMOG_CODE      ,                                                                                          ");
		sql.append("			  C.NUR_MD_NAME                                                                      HANGMOG_NAME      ,                                                                                          ");
		sql.append("			  1                                                                                  SURYANG           ,                                                                                          ");
		sql.append("			  1                                                                                  NALSU             ,                                                                                          ");
		sql.append("			  TRIM(A.DIRECT_TEXT)		                                                         DETAIL            ,                                                                                          ");
		sql.append("			  FN_OCSI_LOAD_DIRECT_ACT_RESULT(:f_hosp_code, A.BUNHO, A.FKINP1001, F.HOLI_DAY, A.INPUT_GUBUN, A.PK_SEQ, A.ORDER_DATE)      																	  ");
		sql.append("																								 ORDER_REMARK      ,                                                                                          ");
		sql.append("			  NULL                                                                               NURSE_REMARK      ,                                                                                          ");
		sql.append("			  'N'                                                                                TEL_YN            ,                                                                                          ");
		sql.append("			  'N'                                                                                EMERGENCY         ,                                                                                          ");
		sql.append("			  ' '                                                                                JUSA_NAME         ,                                                                                          ");
		sql.append("			  ' '                                                                                BOGYONG_NAME      ,                                                                                          ");
		sql.append("			  0                                                                                  JAEWONIL          ,                                                                                          ");
		sql.append("			  A.PK_SEQ                                                                           PK                ,                                                                                          ");
		sql.append("			  '1'                                                                                GROUP_SER         ,                                                                                          ");
		sql.append("			  NULL                                                                               MIX_GROUP         ,                                                                                          ");
		sql.append("			  'OCS2005'                                                                          TABLE_ID          ,                                                                                          ");
		sql.append("			  IF(A.NURSE_PICKUP_DATE IS NULL, 'N', 'Y')                                          CONFIRM_YN        ,                                                                                          ");
		sql.append("			  IF(C.ACTING_YN = 'Y', IF( FN_OCSI_LOAD_DIRECT_ACT_ID(A.BUNHO, A.FKINP1001, A.ORDER_DATE, A.INPUT_GUBUN, F.HOLI_DAY, A.PK_SEQ) IS NULL, 'N', 'Y'), 'Y')                                          ");
		sql.append("																								 ACTING_YN ,		                                                                                          ");
		sql.append("			  'N'                                                                                CAN_PLAN_CHANGE_YN,                                                                                          ");
		sql.append("			  ( CASE WHEN SUBSTR(A.INPUT_GUBUN, 1, 1) IN ('D') THEN 'Y'												                                                                                          ");
		sql.append("				  ELSE 'N' END )                                                                 CAN_CONFIRM_YN    ,                                                                                          ");
		sql.append("			  IF(C.ACTING_YN = 'Y', 'Y', 'N')                                                    CAN_ACTING_YN     ,                                                                                          ");
		sql.append("			  'N'                                                                                CAN_PLAN_APP_YN   ,                                                                                          ");
		sql.append("			  IFNULL(FN_ADM_USER_NM(:f_hosp_code,A.INPUT_ID), '')                                INPUT_NAME        ,                                                                                          ");
		sql.append("			  IFNULL(E.SORT_KEY, 99)                                                             INPUT_SEQ         ,                                                                                          ");
		sql.append("			  'N'                                                                                ORDER_END_YN      ,                                                                                          ");
		sql.append("			  IFNULL(FN_ADM_LOAD_USER_NM(:f_hosp_code, A.NURSE_PICKUP_USER, A.NURSE_PICKUP_DATE), '')     			                                                                                          ");
		sql.append("																								 CONFIRM_NAME      ,                                                                                          ");
		sql.append("			  'N'                                                                                DETAIL_ACT_YN     ,                                                                                          ");
		sql.append("			  'N'                                                                                BULYONG_CHECK     ,                                                                                          ");
		sql.append("			  ' '                                                                                NURSE_HOLD_USER   ,                                                                                          ");
		sql.append("			  A.INPUT_GWA                                                                        INPUT_GWA         ,                                                                                          ");
		sql.append("			  A.INPUT_DOCTOR                                                                     INPUT_DOCTOR      ,                                                                                          ");
		sql.append("			  NULL                                                                               RESER_DATE        ,                                                                                          ");
		sql.append("			  F.HOLI_DAY                                                                          ACTING_DATE      ,                                                                                          ");
		sql.append("			  ' '                                                                                JUNDAL_TABLE      ,                                                                                          ");
		sql.append("			  ' '                                                                                JUNDAL_PART       ,                                                                                          ");
		sql.append("			  '0'                                                                                OCS_FLAG          ,                                                                                          ");
		sql.append("			  A.ORDER_DATE                                                                       SOURCE_ORDER_DATE ,                                                                                          ");
		sql.append("			  A.CONTINUE_YN                                                                      CONTINUE_YN       ,                                                                                          ");
		sql.append("			  CONCAT('0',A.DIRECT_GUBUN,A.DIRECT_CODE,DATE_FORMAT(A.ORDER_DATE, '%Y%m%d'),A.INPUT_GUBUN,DATE_FORMAT(A.DRT_FROM_DATE, '%Y%m%d'),A.DRT_FROM_TIME) 											  ");
		sql.append("			  CONT_KEY,																														                                                                  ");
		sql.append("			  C.JISI_ORDER_GUBUN                                                                  JISI_ORDER_GUBUN ,                                                                                          ");
		sql.append("			  A.DIRECT_CONT1                                                                      DIRECT_CONT      ,                                                                                          ");
		sql.append("			  A.PKOCS2005                                                                         PKOCS2005        ,                                                                                          ");
		sql.append("			  IFNULL(A.FKOCS6015, 0)                                                              PKOCS6015        ,                                                                                          ");
		sql.append("			  A.INPUT_ID                                                                          INPUT_ID         ,                                                                                          ");
		sql.append("			  0                                                                                   DV               ,                                                                                          ");
		sql.append("			  'N'                                                                                 CHECK_ACTING     ,                                                                                          ");
		sql.append("			  NULL                                                                                DIFF             ,                                                                                          ");
		sql.append("			  NULL                                                                                NURSE_ACT_USER   ,                                                                                          ");
		sql.append("			  NULL                                                                                NURSE_ACT_DATE   ,                                                                                          ");
		sql.append("			  NULL                                                                                NURSE_ACT_TIME   ,                                                                                          ");
		sql.append("			  NULL                                                                                MEDI_ACT_CHK     ,                                                                                          ");
		sql.append("			  NULL                                                                                BROUGHT_DRG_YN   ,                                                                                          ");
		sql.append("			  NULL                                                                                FKOCS1003        ,                                                                                          ");
		sql.append("			  CONCAT(DATE_FORMAT(A.DRT_FROM_DATE, '%Y%m%d'), A.DRT_FROM_TIME)                     DRT_FROM_DATETIME,																						  ");
		sql.append("			  CASE WHEN A.CONTINUE_YN = 'Y' THEN '999812312359'																																				  ");
		sql.append("				WHEN A.CONTINUE_YN = 'N' AND (A.DRT_TO_DATE IS NULL OR A.DRT_TO_TIME IS NULL) THEN CONCAT(DATE_FORMAT(F.HOLI_DAY, '%Y%m%d'), '2359')														  ");
		sql.append("				ELSE CONCAT(DATE_FORMAT(A.DRT_TO_DATE, '%Y%m%d'), A.DRT_TO_TIME)  END             DRT_TO_DATETIME  ,																						  ");
		sql.append("			  IFNULL(C.JISI_GUBUN, 'ALL')                                                         JISI_GUBUN																								  ");
		sql.append("		FROM OCS2005 A																																														  ");
		sql.append("		JOIN NUR0110 B ON B.HOSP_CODE      = A.HOSP_CODE	                                                                                                                                                  ");
		sql.append("			   AND B.NUR_GR_CODE    = A.DIRECT_GUBUN		                                                                                                                                                  ");
		sql.append("		JOIN NUR0111 C ON C.HOSP_CODE      = A.HOSP_CODE	                                                                                                                                                  ");
		sql.append("			   AND C.NUR_GR_CODE    = A.DIRECT_GUBUN		                                                                                                                                                  ");
		sql.append("			   AND C.NUR_MD_CODE    = A.DIRECT_CODE			                                                                                                                                                  ");
		sql.append("		JOIN OCS0132 E ON E.HOSP_CODE      = A.HOSP_CODE	                                                                                                                                                  ");
		sql.append("			   AND E.CODE_TYPE      = 'INPUT_GUBUN'			                                                                                                                                                  ");
		sql.append("			   AND E.CODE           = A.INPUT_GUBUN			                                                                                                                                                  ");
		sql.append("		JOIN RES0101 F ON F.HOLI_DAY BETWEEN IFNULL(A.DRT_FROM_DATE, A.ORDER_DATE) AND IF(A.DRT_FROM_DATE IS NULL, A.ORDER_DATE, IFNULL(A.DRT_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d')))                    ");
		sql.append("			   AND F.HOLI_DAY BETWEEN :f_from_date AND :f_to_date	                                                                                                                                          ");
		sql.append("		WHERE A.HOSP_CODE = :f_hosp_code							                                                                                                                                          ");
		sql.append("		AND :f_allsiji = 'Y'										                                                                                                                                          ");
		sql.append("		AND (														                                                                                                                                          ");
		sql.append("			 (:f_emergency_treat = 'N' AND A.INPUT_GUBUN <> 'DN')	                                                                                                                                          ");
		sql.append("		 OR  (:f_emergency_treat = 'Y' )							                                                                                                                                          ");
		sql.append("		)															                                                                                                                                          ");
		sql.append("		AND A.BUNHO          = :f_bunho								                                                                                                                                          ");
		sql.append("		AND A.FKINP1001      = :f_fkinp1001							                                                                                                                                          ");
		sql.append("		AND (:f_from_date BETWEEN IFNULL(A.DRT_FROM_DATE, A.ORDER_DATE)                                                                                                                                       ");
		sql.append("						AND IF(A.DRT_FROM_DATE IS NULL, A.ORDER_DATE, IFNULL(A.DRT_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d')))                                                                               ");
		sql.append("		OR IFNULL(A.DRT_FROM_DATE, A.ORDER_DATE) >= :f_from_date )																																			  ");
		sql.append("		AND A.DIRECT_GUBUN   != '03'			                                                                                                                                                              ");
		sql.append("												                                                                                                                                                              ");
		
//		sql.append("		/*										                                                                                                                                                              ");
//		sql.append("		UNION ALL								                                                                                                                                                              ");
//		sql.append("												                                                                                                                                                              ");
//		sql.append("		SELECT  A.BUNHO                                                                    BUNHO             ,                                                                                                ");
//		sql.append("				A.FKINP1001                                                                FKINP1001         ,                                                                                                ");
//		sql.append("				0                                                                          FKOCS6010         ,                                                                                                ");
//		sql.append("				NULL                                                                       CP_NAME           ,                                                                                                ");
//		sql.append("				F.HOLI_DAY                                                                 ORDER_DATE        ,                                                                                                ");
//		sql.append("				CASE WHEN IF(A.DRT_FROM_DATE IS NULL, A.ORDER_DATE, IFNULL(A.DRT_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d'))) >= STR_TO_DATE(:f_to_date, '%Y/%m/%d') THEN  STR_TO_DATE(:f_to_date, '%Y/%m/%d')");
//		sql.append("				ELSE IF(A.DRT_FROM_DATE IS NULL, A.ORDER_DATE, IFNULL(A.DRT_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d')))                                                                                      ");
//		sql.append("				END                                                                        ORDER_END_DATE    ,                                                                                                ");
//		sql.append("				A.INPUT_GUBUN                                                              INPUT_GUBUN       ,                                                                                                ");
//		sql.append("				E.CODE_NAME                                                                INPUT_GUBUN_NAME  ,                                                                                                ");
//		sql.append("				A.DIRECT_GUBUN                                                             ORDER_GUBUN       ,                                                                                                ");
//		sql.append("				A.DIRECT_GUBUN                                                             ORDER_GUBUN_ORI   ,                                                                                                ");
//		sql.append("				B.NUR_GR_NAME                                                              ORDER_GUBUN_NAME  ,                                                                                                ");
//		sql.append("				A.DIRECT_CONT1                                                             HANGMOG_CODE      ,                                                                                                ");
//		sql.append("				CONCAT(CASE A.BLD_GUBUN WHEN 1 THEN '朝' WHEN 2 THEN '昼' ELSE '夕' END,': [',A.SIK_JUSIK_NAME,'] [',A.SIK_BUSIK_NAME,'] ') 																	  ");
//		sql.append("																						   HANGMOG_NAME      ,                                                                                                ");
//		sql.append("				1                                                                          SURYANG           ,                                                                                                ");
//		sql.append("				1                                                                          NALSU             ,                                                                                                ");
//		sql.append("				''                                                                         DETAIL            ,                                                                                                ");
//		sql.append("				IF( A.KUMJISIK = '', '', REPLACE(A.KUMJISIK, CHR(10), CONCAT(CHR(10), '             '))) 	                                                                                                  ");
//		sql.append("																						   ORDER_REMARK      ,                                                                                                ");
//		sql.append("				NULL                                                                       NURSE_REMARK      ,                                                                                                ");
//		sql.append("				'N'                                                                        TEL_YN            ,                                                                                                ");
//		sql.append("				'N'                                                                        EMERGENCY         ,                                                                                                ");
//		sql.append("				' '                                                                        JUSA_NAME         ,                                                                                                ");
//		sql.append("				' '                                                                        BOGYONG_NAME      ,                                                                                                ");
//		sql.append("				0                                                                          JAEWONIL          ,                                                                                                ");
//		sql.append("				A.PK_SEQ                                                                   PK                ,                                                                                                ");
//		sql.append("				'1'                                                                        GROUP_SER         ,                                                                                                ");
//		sql.append("				NULL                                                                       MIX_GROUP         ,                                                                                                ");
//		sql.append("				'OCS2005'                                                                  TABLE_ID          ,                                                                                                ");
//		sql.append("				'N'                                                                        CONFIRM_YN        ,                                                                                                ");
//		sql.append("				'Y'                                                                        ACTING_YN         ,                                                                                                ");
//		sql.append("				'N'                                                                        CAN_PLAN_CHANGE_YN,                                                                                                ");
//		sql.append("				'N'                                                                        CAN_CONFIRM_YN    ,                                                                                                ");
//		sql.append("				IF(C.ACTING_YN = 'Y', 'Y', 'N')                                            CAN_ACTING_YN     ,																								  ");
//		sql.append("				'N'                                                                        CAN_PLAN_APP_YN   ,                                                                                                ");
//		sql.append("				IFNULL(FN_ADM_USER_NM(:f_hosp_code, A.INPUT_ID), '')                       INPUT_NAME        ,                                                                                                ");
//		sql.append("				IFNULL(E.SORT_KEY, 99)                                                     INPUT_SEQ         ,                                                                                                ");
//		sql.append("				'N'                                                                        ORDER_END_YN      ,                                                                                                ");
//		sql.append("				NULL                                                                       CONFIRM_NAME      ,                                                                                                ");
//		sql.append("				'N'                                                                        DETAIL_ACT_YN     ,                                                                                                ");
//		sql.append("				'N'                                                                        BULYONG_CHECK     ,                                                                                                ");
//		sql.append("				' '                                                                        NURSE_HOLD_USER   ,                                                                                                ");
//		sql.append("				A.INPUT_GWA                                                                INPUT_GWA         ,                                                                                                ");
//		sql.append("				A.INPUT_DOCTOR                                                             INPUT_DOCTOR      ,                                                                                                ");
//		sql.append("				NULL                                                                       RESER_DATE        ,                                                                                                ");
//		sql.append("				F.HOLI_DAY                                                                 ACTING_DATE       ,                                                                                                ");
//		sql.append("				' '                                                                        JUNDAL_TABLE      ,                                                                                                ");
//		sql.append("				' '                                                                        JUNDAL_PART       ,                                                                                                ");
//		sql.append("				'0'                                                                        OCS_FLAG          ,                                                                                                ");
//		sql.append("				A.ORDER_DATE                                                               SOURCE_ORDER_DATE ,                                                                                                ");
//		sql.append("				A.CONTINUE_YN                                                              CONTINUE_YN       ,                                                                                                ");
//		sql.append("				CONCAT('0',A.DIRECT_GUBUN,'000',A.BLD_GUBUN,DATE_FORMAT(A.ORDER_DATE,'%Y%m%d'),E.SORT_KEY,A.INPUT_GUBUN)	                                                                                  ");
//		sql.append("																							CONT_KEY		  ,                                                                                               ");
//		sql.append("				C.JISI_ORDER_GUBUN                                                          JISI_ORDER_GUBUN  ,                                                                                               ");
//		sql.append("				A.DIRECT_CONT1                                                              DIRECT_CONT       ,                                                                                               ");
//		sql.append("				A.PKOCS2005                                                                 PKOCS2005         ,                                                                                               ");
//		sql.append("				0                                                                           PKOCS6015         ,                                                                                               ");
//		sql.append("				A.INPUT_ID   																INPUT_ID          ,                                                                                               ");
//		sql.append("				0 																			DV                ,                                                                                               ");
//		sql.append("				'N'                                                                         CHECK_ACTING      ,                                                                                               ");
//		sql.append("				NULL                                                                        DIFF              ,                                                                                               ");
//		sql.append("				NULL                                                                        NURSE_ACT_ID      ,                                                                                               ");
//		sql.append("				NULL                                                                        NURSE_ACT_DATE    ,                                                                                               ");
//		sql.append("				NULL                                                                        NURSE_ACT_TIME    ,                                                                                               ");
//		sql.append("				NULL                                                                        MEDI_ACT_CHK      ,                                                                                               ");
//		sql.append("				NULL                                                                        BROUGHT_DRG_YN    ,                                                                                               ");
//		sql.append("				NULL                                                                        FKOCS1003         ,                                                                                               ");
//		sql.append("				NULL                                                                        DRT_FROM_DATETIME ,                                                                                               ");
//		sql.append("				NULL                                                                        DRT_TO_DATETIME   ,                                                                                               ");
//		sql.append("				IFNULL(C.JISI_GUBUN, 'ALL') 												JISI_GUBUN        																								  ");
//		sql.append("		FROM  VW_OCS_OCS2005_NUT A,																																											  ");
//		sql.append("		  NUR0110 B,                                                                                                                                                                                          ");
//		sql.append("		  NUR0111 C,                                                                                                                                                                                          ");
//		sql.append("		  OCS0132 E,                                                                                                                                                                                          ");
//		sql.append("		  RES0101 F                                                                                                                                                                                           ");
//		sql.append("		WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                                                                   ");
//		sql.append("		AND :f_allsiji       = 'Y'			                                                                                                                                                                  ");
//		sql.append("		AND A.BUNHO          = :f_bunho		                                                                                                                                                                  ");
//		sql.append("		AND A.FKINP1001      = :f_fkinp1001	                                                                                                                                                                  ");
//		sql.append("		AND A.NUT_DATE       BETWEEN :f_from_date AND :f_to_date                                                                                                                                              ");
//		sql.append("		AND F.HOLI_DAY = A.NUT_DATE                     		                                                                                                                                              ");
//		sql.append("		AND F.HOSP_CODE      = A.HOSP_CODE						                                                                                                                                              ");
//		sql.append("		AND F.HOLI_DAY       BETWEEN :f_from_date AND :f_to_date                                                                                                                                              ");
//		sql.append("		AND B.HOSP_CODE      = A.HOSP_CODE		                                                                                                                                                              ");
//		sql.append("		AND B.NUR_GR_CODE    = A.DIRECT_GUBUN	                                                                                                                                                              ");
//		sql.append("		AND C.HOSP_CODE      = A.HOSP_CODE		                                                                                                                                                              ");
//		sql.append("		AND C.NUR_GR_CODE    = A.DIRECT_GUBUN	                                                                                                                                                              ");
//		sql.append("		AND C.NUR_MD_CODE    = A.DIRECT_CODE	                                                                                                                                                              ");
//		sql.append("		AND E.HOSP_CODE      = A.HOSP_CODE		                                                                                                                                                              ");
//		sql.append("		AND E.CODE_TYPE      = 'INPUT_GUBUN'	                                                                                                                                                              ");
//		sql.append("		AND E.CODE           = A.INPUT_GUBUN	                                                                                                                                                              ");
//		sql.append("		AND A.DIRECT_GUBUN   = '03'				                                                                                                                                                              ");
//		sql.append("		*/										                                                                                                                                                              ");
		
		sql.append("		UNION ALL																																															  	  ");
		sql.append("		SELECT  	A.BUNHO                                                                    BUNHO             ,                                                                                                ");
		sql.append("		    		A.FKINP1001                                                                FKINP1001         ,                                                                                                ");
		sql.append("		    		0                                                                          FKOCS6010         ,                                                                                                ");
		sql.append("		    		NULL                                                                       CP_NAME           ,                                                                                                ");
		sql.append("		    		F.HOLI_DAY                                                                 ORDER_DATE        ,                                                                                                ");
		sql.append("		    		CASE WHEN IF(A.DRT_FROM_DATE IS NULL, A.ORDER_DATE, IFNULL(A.DRT_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d'))) >= STR_TO_DATE(:f_to_date, '%Y/%m/%d') THEN  STR_TO_DATE(:f_to_date, '%Y/%m/%d')");
		sql.append("		    		ELSE IF(A.DRT_FROM_DATE IS NULL, A.ORDER_DATE, IFNULL(A.DRT_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d')))                                                                                      ");
		sql.append("		    		END                                                                        ORDER_END_DATE    ,                                                                                                ");
		sql.append("		    		A.INPUT_GUBUN                                                              INPUT_GUBUN       ,                                                                                                ");
		sql.append("		    		E.CODE_NAME                                                                INPUT_GUBUN_NAME  ,                                                                                                ");
		sql.append("		    		A.DIRECT_GUBUN                                                             ORDER_GUBUN       ,                                                                                                ");
		sql.append("		    		A.DIRECT_GUBUN                                                             ORDER_GUBUN_ORI   ,                                                                                                ");
		sql.append("		    		B.NUR_GR_NAME                                                              ORDER_GUBUN_NAME  ,                                                                                                ");
		sql.append("		    		A.DIRECT_CONT1                                                             HANGMOG_CODE      ,                                                                                                ");
		sql.append("		    		CONCAT(CASE A.BLD_GUBUN WHEN 1 THEN '朝' WHEN 2 THEN '昼' ELSE '夕' END,': [',A.SIK_JUSIK_NAME,'] [',A.SIK_BUSIK_NAME,'] ') 																	  ");
		sql.append("		    																				   HANGMOG_NAME      ,                                                                                                ");
		sql.append("		    		1                                                                          SURYANG           ,                                                                                                ");
		sql.append("		    		1                                                                          NALSU             ,                                                                                                ");
		sql.append("		    		''                                                                         DETAIL            ,                                                                                                ");
		sql.append("		    		IF( A.KUMJISIK = '', '', REPLACE(A.KUMJISIK, CHAR(10), CONCAT(CHAR(10), '             '))) 	                                                                                                  ");
		sql.append("		    																				   ORDER_REMARK      ,                                                                                                ");
		sql.append("		    		NULL                                                                       NURSE_REMARK      ,                                                                                                ");
		sql.append("		    		'N'                                                                        TEL_YN            ,                                                                                                ");
		sql.append("		    		'N'                                                                        EMERGENCY         ,                                                                                                ");
		sql.append("		    		' '                                                                        JUSA_NAME         ,                                                                                                ");
		sql.append("		    		' '                                                                        BOGYONG_NAME      ,                                                                                                ");
		sql.append("		    		0                                                                          JAEWONIL          ,                                                                                                ");
		sql.append("		    		A.PK_SEQ                                                                   PK                ,                                                                                                ");
		sql.append("		    		'1'                                                                        GROUP_SER         ,                                                                                                ");
		sql.append("		    		NULL                                                                       MIX_GROUP         ,                                                                                                ");
		sql.append("		    		'OCS2005'                                                                  TABLE_ID          ,                                                                                                ");
		sql.append("		    		'N'                                                                        CONFIRM_YN        ,                                                                                                ");
		sql.append("		    		'Y'                                                                        ACTING_YN         ,                                                                                                ");
		sql.append("		    		'N'                                                                        CAN_PLAN_CHANGE_YN,                                                                                                ");
		sql.append("		    		'N'                                                                        CAN_CONFIRM_YN    ,                                                                                                ");
		sql.append("		    		IF(C.ACTING_YN = 'Y', 'Y', 'N')                                            CAN_ACTING_YN     ,																								  ");
		sql.append("		    		'N'                                                                        CAN_PLAN_APP_YN   ,                                                                                                ");
		sql.append("		    		IFNULL(FN_ADM_USER_NM(:f_hosp_code, A.INPUT_ID), '')                       INPUT_NAME        ,                                                                                                ");
		sql.append("		    		IFNULL(E.SORT_KEY, 99)                                                     INPUT_SEQ         ,                                                                                                ");
		sql.append("		    		'N'                                                                        ORDER_END_YN      ,                                                                                                ");
		sql.append("		    		NULL                                                                       CONFIRM_NAME      ,                                                                                                ");
		sql.append("		    		'N'                                                                        DETAIL_ACT_YN     ,                                                                                                ");
		sql.append("		    		'N'                                                                        BULYONG_CHECK     ,                                                                                                ");
		sql.append("		    		' '                                                                        NURSE_HOLD_USER   ,                                                                                                ");
		sql.append("		    		A.INPUT_GWA                                                                INPUT_GWA         ,                                                                                                ");
		sql.append("		    		A.INPUT_DOCTOR                                                             INPUT_DOCTOR      ,                                                                                                ");
		sql.append("		    		NULL                                                                       RESER_DATE        ,                                                                                                ");
		sql.append("		    		F.HOLI_DAY                                                                 ACTING_DATE       ,                                                                                                ");
		sql.append("		    		' '                                                                        JUNDAL_TABLE      ,                                                                                                ");
		sql.append("		    		' '                                                                        JUNDAL_PART       ,                                                                                                ");
		sql.append("		    		'0'                                                                        OCS_FLAG          ,                                                                                                ");
		sql.append("		    		A.ORDER_DATE                                                               SOURCE_ORDER_DATE ,                                                                                                ");
		sql.append("		    		A.CONTINUE_YN                                                              CONTINUE_YN       ,                                                                                                ");
		sql.append("		    		CONCAT('0',A.DIRECT_GUBUN,'000',A.BLD_GUBUN,DATE_FORMAT(A.ORDER_DATE,'%Y%m%d'),E.SORT_KEY,A.INPUT_GUBUN)	                                                                                  ");
		sql.append("		    																					CONT_KEY		  ,                                                                                               ");
		sql.append("		    		C.JISI_ORDER_GUBUN                                                          JISI_ORDER_GUBUN  ,                                                                                               ");
		sql.append("		    		A.DIRECT_CONT1                                                              DIRECT_CONT       ,                                                                                               ");
		sql.append("		    		A.PKOCS2005                                                                 PKOCS2005         ,                                                                                               ");
		sql.append("		    		0                                                                           PKOCS6015         ,                                                                                               ");
		sql.append("		    		A.INPUT_ID   																INPUT_ID          ,                                                                                               ");
		sql.append("		    		0 																			DV                ,                                                                                               ");
		sql.append("		    		'N'                                                                         CHECK_ACTING      ,                                                                                               ");
		sql.append("		    		NULL                                                                        DIFF              ,                                                                                               ");
		sql.append("		    		NULL                                                                        NURSE_ACT_ID      ,                                                                                               ");
		sql.append("		    		NULL                                                                        NURSE_ACT_DATE    ,                                                                                               ");
		sql.append("		    		NULL                                                                        NURSE_ACT_TIME    ,                                                                                               ");
		sql.append("		    		NULL                                                                        MEDI_ACT_CHK      ,                                                                                               ");
		sql.append("		    		NULL                                                                        BROUGHT_DRG_YN    ,                                                                                               ");
		sql.append("		    		NULL                                                                        FKOCS1003         ,                                                                                               ");
		sql.append("		    		NULL                                                                        DRT_FROM_DATETIME ,                                                                                               ");
		sql.append("		    		NULL                                                                        DRT_TO_DATETIME   ,                                                                                               ");
		sql.append("		    		IFNULL(C.JISI_GUBUN, 'ALL') 												JISI_GUBUN        																								  ");
		sql.append("		FROM  (						                                                                                                                                                                              ");
		sql.append("		  SELECT  B.HOSP_CODE,		                                                                                                                                                                              ");
		sql.append("		      		B.PKOCS2005,	                                                                                                                                                                              ");
		sql.append("		      		B.BUNHO,		                                                                                                                                                                              ");
		sql.append("		      		B.FKINP1001,	                                                                                                                                                                              ");
		sql.append("		      		B.ORDER_DATE,	                                                                                                                                                                              ");
		sql.append("		      		B.INPUT_GUBUN,	                                                                                                                                                                              ");
		sql.append("		      		B.INPUT_ID,		                                                                                                                                                                              ");
		sql.append("		      		B.PK_SEQ,		                                                                                                                                                                              ");
		sql.append("		      		B.DIRECT_GUBUN,		                                                                                                                                                                          ");
		sql.append("		      		B.DRT_FROM_DATE,	                                                                                                                                                                          ");
		sql.append("		      		B.DRT_TO_DATE,		                                                                                                                                                                          ");
		sql.append("		      		B.CONTINUE_YN,		                                                                                                                                                                          ");
		sql.append("		      		DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)  AS NUT_DATE,	                                                                                                                              ");
		sql.append("		      		B.BLD_GUBUN,				                                                                                                                                                                  ");
		sql.append("		      		B.DIRECT_CODE,				                                                                                                                                                                  ");
		sql.append("		      		B.DIRECT_CONT1,												                                                                                                                                  ");
		sql.append("		      		N2.NUR_SO_NAME                                  AS SIK_JUSIK_NAME,	                                                                                                                          ");
		sql.append("		      		N3.NUR_SO_NAME                                  AS SIK_BUSIK_NAME,	                                                                                                                          ");
		sql.append("		      		B.KUMJISIK,			                                                                                                                                                                          ");
		sql.append("		      		B.INPUT_GWA,		                                                                                                                                                                          ");
		sql.append("		      		B.INPUT_DOCTOR		                                                                                                                                                                          ");
		sql.append("		  FROM INP1001 A                                                                                                                                                                                          ");
		sql.append("		  JOIN OCS2005 B ON B.HOSP_CODE     = A.HOSP_CODE                                                                                                                                                         ");
		sql.append("		            		AND B.BUNHO         = A.BUNHO                                                                                                                                                         ");
		sql.append("		            		AND B.FKINP1001     = A.PKINP1001                                                                                                                                                     ");
		sql.append("		            		AND B.DIRECT_GUBUN  = '03'                                                                                                                                                            ");
		sql.append("		                AND B.DRT_FROM_DATE >= A.IPWON_DATE                                                                                                                                                       ");
		sql.append("		  JOIN INP2004 C ON C.HOSP_CODE     = A.HOSP_CODE                                                                                                                                                         ");
		sql.append("		            		AND C.BUNHO         = A.BUNHO                                                                                                                                                         ");
		sql.append("		            		AND C.FKINP1001     = A.PKINP1001                                                                                                                                                     ");
		sql.append("		  LEFT JOIN NUR0112 N0 ON N0.HOSP_CODE    = B.HOSP_CODE                                                                                                                                                   ");
		sql.append("		                  		AND N0.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                              ");
		sql.append("		                  		AND N0.NUR_MD_CODE  = B.DIRECT_CODE                                                                                                                                               ");
		sql.append("		                  		AND N0.NUR_SO_CODE  = B.DIRECT_CODE_D                                                                                                                                             ");
		sql.append("		  LEFT JOIN NUR0112 N1 ON N1.HOSP_CODE    = B.HOSP_CODE                                                                                                                                                   ");
		sql.append("		                  		AND N1.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                              ");
		sql.append("		                  		AND N1.NUR_MD_CODE  = B.DIRECT_CONT1                                                                                                                                              ");
		sql.append("		                  		AND N1.NUR_SO_CODE  = B.DIRECT_CONT1_D                                                                                                                                            ");
		sql.append("		  LEFT JOIN NUR0112 N2 ON N2.HOSP_CODE    = B.HOSP_CODE		                                                                                                                                              ");
		sql.append("		                  		AND N2.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                              ");
		sql.append("		                  		AND N2.NUR_MD_CODE  = B.DIRECT_CONT2                                                                                                                                              ");
		sql.append("		                  		AND N2.NUR_SO_CODE  = B.DIRECT_CONT2_D                                                                                                                                            ");
		sql.append("		  LEFT JOIN NUR0112 N3 ON N3.HOSP_CODE    = B.HOSP_CODE																																					  ");
		sql.append("		                  		AND N3.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                              ");
		sql.append("		                  		AND N3.NUR_MD_CODE  = B.DIRECT_CONT3                                                                                                                                              ");
		sql.append("		                  		AND N3.NUR_SO_CODE  = B.DIRECT_CONT3_D                                                                                                                                            ");
		sql.append("		  LEFT JOIN NUR0112 N4 ON N4.HOSP_CODE    = B.HOSP_CODE                                                                                                                                                   ");
		sql.append("		                  		AND N4.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                                                                              ");
		sql.append("		                  		AND N4.NUR_MD_CODE  = '0305'  		                                                                                                                                              ");
		sql.append("		                  		AND N4.NUR_SO_CODE  = B.NOMIMONO	                                                                                                                                              ");
		sql.append("		  ,(										                                                                                                                                                              ");
		sql.append("		    SELECT @rownr\\:=@rownr+1 AS ADD_DAY		                                                                                                                                                              ");
		sql.append("		  	FROM INP1001, (SELECT @rownr\\:=-1) TMP	                                                                                                                                                              ");
		sql.append("		  ) AA										                                                                                                                                                              ");
		sql.append("		  WHERE A.HOSP_CODE   = :f_hosp_code		                                                                                                                                                              ");
		sql.append("		    AND A.BUNHO       = :f_bunho    		                                                                                                                                                              ");
		sql.append("		    AND A.PKINP1001   = :f_fkinp1001		                                                                                                                                                              ");
		sql.append("		  	AND B.DRT_FROM_DATE =	                                                                                                                                                                              ");
		sql.append("		  		   IFNULL(			                                                                                                                                                                              ");
		sql.append("		  			  (SELECT MAX(Z.DRT_FROM_DATE)	                                                                                                                                                              ");
		sql.append("		  				 FROM OCS2005 Z								                                                                                                                                              ");
		sql.append("		  				 WHERE Z.HOSP_CODE      = B.HOSP_CODE		                                                                                                                                              ");
		sql.append("		  					 AND Z.FKINP1001      = B.FKINP1001		                                                                                                                                              ");
		sql.append("		  					 AND Z.DIRECT_CODE    = B.DIRECT_CODE	                                                                                                                                              ");
		sql.append("		  					 AND Z.BUNHO          = B.BUNHO			                                                                                                                                              ");
		sql.append("		  					 AND Z.BLD_GUBUN      = B.BLD_GUBUN		                                                                                                                                              ");
		sql.append("		  					 AND Z.DRT_FROM_DATE  <= DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)		                                                                                                          ");
		sql.append("		  					 AND (Z.DRT_TO_DATE IS NULL													                                                                                                          ");
		sql.append("		  						   OR Z.DRT_TO_DATE >= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY))),                                                                                                         ");
		sql.append("		  			  (SELECT MAX(Z.DRT_FROM_DATE)														                                                                                                          ");
		sql.append("		  				 FROM OCS2005 Z							                                                                                                                                                  ");
		sql.append("		  				 WHERE Z.HOSP_CODE      = B.HOSP_CODE	                                                                                                                                                  ");
		sql.append("		  					 AND Z.FKINP1001      = B.FKINP1001	                                                                                                                                                  ");
		sql.append("		  					 AND Z.DIRECT_CODE    = B.DIRECT_CODE                                                                                                                                                 ");
		sql.append("		  					 AND Z.BUNHO          = B.BUNHO		                                                                                                                                                  ");
		sql.append("		  					 AND Z.BLD_GUBUN      = B.BLD_GUBUN                                                                                                                                                   ");
		sql.append("		  					 AND Z.DRT_FROM_DATE  <= DATE_ADD(A.IPWON_DATE,INTERVAL AA.ADD_DAY DAY)                                                                                                               ");
		sql.append("		  					 AND Z.DRT_TO_DATE =				                                                                                                                                                  ");
		sql.append("		  							 (SELECT MAX(X.DRT_TO_DATE)	                                                                                                                                                  ");
		sql.append("		  								FROM OCS2005 X			                                                                                                                                                  ");
		sql.append("		  							   WHERE X.HOSP_CODE      = Z.HOSP_CODE                                                                                                                                       ");
		sql.append("		  									 AND X.DIRECT_CODE    = Z.DIRECT_CODE                                                                                                                                 ");
		sql.append("		  									 AND X.BUNHO          = Z.BUNHO		                                                                                                                                  ");
		sql.append("		  									 AND X.BLD_GUBUN      = Z.BLD_GUBUN	                                                                                                                                  ");
		sql.append("		  									 AND X.DRT_FROM_DATE  <=DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY))))                                                                                            ");
		sql.append("		  	AND C.START_DATE =				                                                                                                                                                                      ");
		sql.append("		  		   (SELECT MAX(Z.START_DATE)                                                                                                                                                                      ");
		sql.append("		  			  FROM INP2004 Z		                                                                                                                                                                      ");
		sql.append("		  			  WHERE Z.HOSP_CODE   = C.HOSP_CODE                                                                                                                                                           ");
		sql.append("		  				  AND Z.BUNHO       = C.BUNHO                                                                                                                                                             ");
		sql.append("		  				  AND Z.FKINP1001   = C.FKINP1001                                                                                                                                                         ");
		sql.append("		  				  AND Z.START_DATE  <= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY))                                                                                                                   ");
		sql.append("		  	AND C.TRANS_CNT =				                                                                                                                                                                      ");
		sql.append("		  		   (SELECT MAX(Z.TRANS_CNT)	                                                                                                                                                                      ");
		sql.append("		  			  FROM INP2004 Z					                                                                                                                                                          ");
		sql.append("		  			  WHERE Z.HOSP_CODE   = C.HOSP_CODE                                                                                                                                                           ");
		sql.append("		  				  AND Z.BUNHO       = C.BUNHO                                                                                                                                                             ");
		sql.append("		  				  AND Z.FKINP1001   = C.FKINP1001                                                                                                                                                         ");
		sql.append("		  				  AND Z.START_DATE  = C.START_DATE)                                                                                                                                                       ");
		sql.append("		  	AND AA.ADD_DAY <= (DATEDIFF(IFNULL(A.TOIWON_DATE, CURRENT_DATE), A.IPWON_DATE) + IF(A.TOIWON_DATE IS NULL, 31, 0))                                                                                    ");
		sql.append("		    ORDER BY 1, BLD_GUBUN, ADD_DAY                                                                                                                                                                        ");
		sql.append("		  )       A,                                                                                                                                                                                              ");
		sql.append("		  NUR0110 B,                                                                                                                                                                                              ");
		sql.append("		  NUR0111 C,                                                                                                                                                                                              ");
		sql.append("		  OCS0132 E,                                                                                                                                                                                              ");
		sql.append("		  RES0101 F                                                                                                                                                                                               ");
		sql.append("		WHERE :f_allsiji      = 'Y'	                                                                                                                                                                              ");
		sql.append("		AND A.NUT_DATE        BETWEEN :f_from_date AND :f_to_date                                                                                                                                                 ");
		sql.append("		AND F.HOLI_DAY        = A.NUT_DATE                     		                                                                                                                                              ");
		sql.append("		AND F.HOLI_DAY        BETWEEN :f_from_date AND :f_to_date                                                                                                                                                 ");
		sql.append("		AND B.HOSP_CODE       = A.HOSP_CODE		                                                                                                                                                                  ");
		sql.append("		AND B.NUR_GR_CODE     = A.DIRECT_GUBUN	                                                                                                                                                                  ");
		sql.append("		AND C.HOSP_CODE       = A.HOSP_CODE		                                                                                                                                                                  ");
		sql.append("		AND C.NUR_GR_CODE     = A.DIRECT_GUBUN	                                                                                                                                                                  ");
		sql.append("		AND C.NUR_MD_CODE     = A.DIRECT_CODE	                                                                                                                                                                  ");
		sql.append("		AND E.HOSP_CODE       = A.HOSP_CODE		                                                                                                                                                                  ");
		sql.append("		AND E.CODE_TYPE       = 'INPUT_GUBUN'	                                                                                                                                                                  ");
		sql.append("		AND E.CODE            = A.INPUT_GUBUN	                                                                                                                                                                  ");
		sql.append("		AND A.DIRECT_GUBUN    = '03'				                                                                                                                                                              ");

		sql.append("																																																			       ");
		sql.append("		UNION ALL																                                                                                                                                   ");
		sql.append("																				                                                                                                                                   ");
		sql.append("		 SELECT  A.BUNHO                                       BUNHO             ,                                                                                                                                 ");
		sql.append("				 A.FKINP1001                                   FKINP1001         ,                                                                                                                                 ");
		sql.append("				 B.FKOCS6010                                   FKOCS6010         ,                                                                                                                                 ");
		sql.append("				 NULL                                          CP_NAME           ,                                                                                                                                 ");
		sql.append("				 F.HOLI_DAY                                    ORDER_DATE        ,                                                                                                                                 ");
		sql.append("				 IFNULL(B.PLAN_TO_DATE, STR_TO_DATE('99991231', '%Y%m%d'))		                                                                                                                                   ");
		sql.append("															   ORDER_END_DATE    ,                                                                                                                                 ");
		sql.append("				 B.INPUT_GUBUN                                 INPUT_GUBUN       ,                                                                                                                                 ");
		sql.append("				 E.CODE_NAME                                   INPUT_GUBUN_NAME  ,                                                                                                                                 ");
		sql.append("				 B.DIRECT_GUBUN                                ORDER_GUBUN       ,                                                                                                                                 ");
		sql.append("				 B.DIRECT_GUBUN                                ORDER_GUBUN_ORI   ,                                                                                                                                 ");
		sql.append("				 C.NUR_GR_NAME                                 ORDER_GUBUN_NAME  ,                                                                                                                                 ");
		sql.append("				 B.DIRECT_CODE                                 HANGMOG_CODE      ,                                                                                                                                 ");
		sql.append("				 D.NUR_MD_NAME                                 HANGMOG_NAME      ,                                                                                                                                 ");
		sql.append("				 1                                             SURYANG           ,                                                                                                                                 ");
		sql.append("				 1                                             NALSU             ,                                                                                                                                 ");
		sql.append("				 TRIM(B.DIRECT_TEXT)                           DETAIL            ,                                                                                                                                 ");
		sql.append("				 NULL                                          ORDER_REMARK      ,                                                                                                                                 ");
		sql.append("				 NULL                                          NURSE_REMARK      ,                                                                                                                                 ");
		sql.append("				 'N'                                           TEL_YN            ,                                                                                                                                 ");
		sql.append("				 'N'                                           EMERGENCY         ,                                                                                                                                 ");
		sql.append("				 ' '                                           JUSA_NAME         ,                                                                                                                                 ");
		sql.append("				 ' '                                           BOGYONG_NAME      ,                                                                                                                                 ");
		sql.append("				 B.JAEWONIL                                    JAEWONIL          ,                                                                                                                                 ");
		sql.append("				 B.PK_SEQ                                      PK                ,                                                                                                                                 ");
		sql.append("				 '1'                                           GROUP_SER         ,                                                                                                                                 ");
		sql.append("				 NULL                                          MIX_GROUP         ,                                                                                                                                 ");
		sql.append("				 'OCS6015'                                     TABLE_ID          ,                                                                                                                                 ");
		sql.append("				 'N'                                           CONFIRM_YN        ,                                                                                                                                 ");
		sql.append("				 IF(D.ACTING_YN = 'Y', IF(FN_OCSI_LOAD_OCS6015_ACT_ID(:f_hosp_code, B.PKOCS6015, F.HOLI_DAY) IS NULL, 'N', 'Y'), 'Y')	                                                                           ");
		sql.append("																					 ACTING_YN         ,								                                                                           ");
		sql.append("				 IF(SIGN(DATEDIFF(B.PLAN_FROM_DATE, IFNULL(B.PLAN_TO_DATE, STR_TO_DATE('99991231', '%Y%m%d')))) = -1 , 'N', 'Y')		                                                                           ");
		sql.append("																					 CAN_PLAN_CHANGE_YN,								                                                                           ");
		sql.append("				 'N'                                           CAN_CONFIRM_YN    ,                                                                                                                                 ");
		sql.append("				 IF(D.ACTING_YN = 'Y', 'Y', 'N')               CAN_ACTING_YN     ,                                                                                                                                 ");
		sql.append("				 'N'                                           CAN_PLAN_APP_YN   ,                                                                                                                                 ");
		sql.append("				 IFNULL(FN_ADM_USER_NM(:f_hosp_code, B.INPUT_ID), '')                                                                                                                                              ");
		sql.append("															   INPUT_NAME        ,                                                                                                                                 ");
		sql.append("				 IFNULL(E.SORT_KEY, 99)                        INPUT_SEQ         ,                                                                                                                                 ");
		sql.append("				 'N'                                           ORDER_END_YN      ,                                                                                                                                 ");
		sql.append("				 NULL                                          CONFIRM_NAME      ,                                                                                                                                 ");
		sql.append("				 'N'                                           DETAIL_ACT_YN     ,                                                                                                                                 ");
		sql.append("				 'N'                                           BULYONG_CHECK     ,                                                                                                                                 ");
		sql.append("				 ' '                                           NURSE_HOLD_USER   ,                                                                                                                                 ");
		sql.append("				 ' '                                           INPUT_GWA         ,                                                                                                                                 ");
		sql.append("				 ' '                                           INPUT_DOCTOR      ,                                                                                                                                 ");
		sql.append("				 NULL                                          RESER_DATE        ,                                                                                                                                 ");
		sql.append("				 NULL                                          ACTING_DATE       ,                                                                                                                                 ");
		sql.append("				 ' '                                           JUNDAL_TABLE      ,                                                                                                                                 ");
		sql.append("				 ' '                                           JUNDAL_PART       ,                                                                                                                                 ");
		sql.append("				 '0'                                           OCS_FLAG          ,                                                                                                                                 ");
		sql.append("				 B.PLAN_FROM_DATE                              SOURCE_ORDER_DATE ,                                                                                                                                 ");
		sql.append("				 B.CONTINUE_YN                                 CONTINUE_YN       ,                                                                                                                                 ");
		sql.append("				 CONCAT('0',B.DIRECT_GUBUN,B.DIRECT_CODE,DATE_FORMAT(B.PLAN_FROM_DATE, '%Y%m%d'),E.SORT_KEY,B.INPUT_GUBUN)                                                                                         ");
		sql.append("															   CONT_KEY				                                                                                                                               ");
		sql.append("			   , D.JISI_ORDER_GUBUN                            JISI_ORDER_GUBUN		                                                                                                                               ");
		sql.append("			   , B.DIRECT_DETAIL                               DIRECT_CONT			                                                                                                                               ");
		sql.append("			   , 0                                             PKOCS2005			                                                                                                                               ");
		sql.append("			   , B.PKOCS6015                                   PKOCS6015			                                                                                                                               ");
		sql.append("			   , B.INPUT_ID                                    INPUT_ID				                                                                                                                               ");
		sql.append("			   , 0                                             DV					                                                                                                                               ");
		sql.append("			   , 'N'                                           CHECK_ACTING		                                                                                                                                   ");
		sql.append("			   , NULL                                          DIFF				                                                                                                                                   ");
		sql.append("			   , NULL                                          NURSE_ACT_ID		                                                                                                                                   ");
		sql.append("			   , NULL                                          NURSE_ACT_DATE	                                                                                                                                   ");
		sql.append("			   , NULL                                          NURSE_ACT_TIME	                                                                                                                                   ");
		sql.append("			   , NULL                                          MEDI_ACT_CHK		                                                                                                                                   ");
		sql.append("			   , NULL                                          BROUGHT_DRG_YN	                                                                                                                                   ");
		sql.append("			   , NULL                                          FKOCS1003		                                                                                                                                   ");
		sql.append("			   , NULL                                          DRT_FROM_DATETIME                                                                                                                                   ");
		sql.append("			   , NULL                                          DRT_TO_DATETIME	                                                                                                                                   ");
		sql.append("			   , IFNULL(D.JISI_GUBUN, 'ALL')                   JISI_GUBUN		                                                                                                                                   ");
		sql.append("		FROM OCS6010 A																																													           ");
		sql.append("		JOIN OCS6015 B ON B.HOSP_CODE        = A.HOSP_CODE                                                                                                                                                         ");
		sql.append("					AND B.FKOCS6010          = A.PKOCS6010                                                                                                                                                         ");
		sql.append("					AND B.PLAN_FROM_DATE     <= :f_to_date                                                                                                                                                         ");
		sql.append("					AND IFNULL(B.PLAN_TO_DATE, STR_TO_DATE('99991231', '%Y%m%d'))                                                                                                                                  ");
		sql.append("										   >= IF(SIGN(DATEDIFF(STR_TO_DATE(:f_from_date, '%Y/%m/%d'), DATE(SYSDATE()))) = 1, STR_TO_DATE(:f_from_date, '%Y/%m/%d'), DATE(SYSDATE()))						       ");
		sql.append("		JOIN NUR0110 C ON C.HOSP_CODE        = B.HOSP_CODE                                                                                                                                                         ");
		sql.append("					AND C.NUR_GR_CODE        = B.DIRECT_GUBUN	                                                                                                                                                   ");
		sql.append("		JOIN NUR0111 D ON D.HOSP_CODE        = B.HOSP_CODE		                                                                                                                                                   ");
		sql.append("					AND D.NUR_GR_CODE        = B.DIRECT_GUBUN	                                                                                                                                                   ");
		sql.append("					AND D.NUR_MD_CODE        = B.DIRECT_CODE	                                                                                                                                                   ");
		sql.append("		JOIN OCS0132 E ON E.HOSP_CODE        = B.HOSP_CODE		                                                                                                                                                   ");
		sql.append("					AND E.CODE_TYPE          = 'INPUT_GUBUN'	                                                                                                                                                   ");
		sql.append("					AND E.CODE               = B.INPUT_GUBUN	                                                                                                                                                   ");
		sql.append("		JOIN RES0101 F ON F.HOLI_DAY BETWEEN IFNULL(B.PLAN_FROM_DATE, DATE(SYSDATE()))													                                                                           ");
		sql.append("					  AND IF(B.PLAN_FROM_DATE IS NULL, DATE(SYSDATE()), IFNULL(B.PLAN_TO_DATE, STR_TO_DATE('99981231', '%Y%m%d')))		                                                                           ");
		sql.append("					  AND F.HOLI_DAY BETWEEN :f_from_date AND :f_to_date																                                                                           ");
		sql.append("		WHERE A.HOSP_CODE          = :f_hosp_code																						                                                                           ");
		sql.append("		AND :f_allsiji           = 'Y'																									                                                                           ");
		sql.append("		AND A.BUNHO              = :f_bunho																								                                                                           ");
		sql.append("		AND A.FKINP1001          = :f_fkinp1001																							                                                                           ");
		sql.append("		AND IFNULL(A.CP_END_YN, 'N') = 'N'																								                                                                           ");
		sql.append("		AND NOT EXISTS( SELECT 'X'																										                                                                           ");
		sql.append("							  FROM OCS2005						                                                                                                                                                   ");
		sql.append("							  WHERE HOSP_CODE  = A.HOSP_CODE	                                                                                                                                                   ");
		sql.append("							   AND BUNHO      = A.BUNHO			                                                                                                                                                   ");
		sql.append("							   AND FKINP1001  = A.FKINP1001		                                                                                                                                                   ");
		sql.append("							   AND ORDER_DATE = F.HOLI_DAY		                                                                                                                                                   ");
		sql.append("							   AND FKOCS6015  = B.PKOCS6015 )	                                                                                                                                                   ");
		sql.append("							   									                                                                                                                                                   ");
		sql.append("		UNION ALL												                                                                                                                                                   ");
		sql.append("																                                                                                                                                                   ");
		sql.append("		SELECT A.BUNHO                                                                                     BUNHO             ,                                                                                     ");
		sql.append("			   A.FKINP1001                                                                                 FKINP1001         ,                                                                                     ");
		sql.append("			   0                                                                                           FKOCS6010         ,                                                                                     ");
		sql.append("			   NULL                                                                                        CP_NAME           ,                                                                                     ");
		sql.append("			 (CASE WHEN SUBSTRING(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')                                                                                                                                               ");
		sql.append("				 THEN IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)))                                                                                                               ");
		sql.append("				 WHEN SUBSTRING(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')                                                                                                                                            ");
		sql.append("				 THEN I.HOLI_DAY                                                                                                                                                                                   ");
		sql.append("				 WHEN A.INPUT_TAB = '10' AND A.JUNDAL_PART = 'REH'                                                                                                                                                 ");
		sql.append("				 THEN A.ACTING_DATE                                                                                                                                                                                ");
		sql.append("				 ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))                                                                                                                                      ");
		sql.append("			 END )                                                                                         ORDER_DATE        ,                                                                                     ");
		sql.append("			 (CASE WHEN SUBSTRING(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')                                                                                                                                               ");
		sql.append("				 THEN IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)))                                                                                                               ");
		sql.append("				 WHEN A.INPUT_GUBUN = 'D7'                                                                                                                                                                         ");
		sql.append("				 THEN DATE_ADD(IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)),INTERVAL A.NALSU DAY)																								       ");
		sql.append("				 WHEN SUBSTRING(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')                                                                                                                                            ");
		sql.append("				 THEN I.HOLI_DAY                                                                                                                                                                                   ");
		sql.append("				 WHEN A.INPUT_TAB = '10' AND A.JUNDAL_PART = 'REH'                                                                                                                                                 ");
		sql.append("				 THEN A.ACTING_DATE                                                                                                                                                                                ");
		sql.append("				 ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))                                                                                                                                      ");
		sql.append("			 END )                                                                                         ORDER_END_DATE    ,                                                                                     ");
		sql.append("			 A.INPUT_GUBUN                                                                                 INPUT_GUBUN       ,                                                                                     ");
		sql.append("			 E.CODE_NAME                                                                                   INPUT_GUBUN_NAME  ,                                                                                     ");
		sql.append("			 SUBSTRING(A.ORDER_GUBUN, 2, 1)                                                                ORDER_GUBUN       ,                                                                                     ");
		sql.append("			 A.ORDER_GUBUN                                                                                 ORDER_GUBUN_ORI   ,                                                                                     ");
		sql.append("			 FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTRING(A.ORDER_GUBUN, 2, 1), :f_hosp_code, :f_language)                                                                                                   ");
		sql.append("																										   ORDER_GUBUN_NAME  ,                                                                                     ");
		sql.append("			 A.HANGMOG_CODE                                  											   HANGMOG_CODE      ,                                                                                     ");
		sql.append("			 CONCAT(                                                                                                                                                                                               ");
		sql.append("			   IF(A.FKOCS1003 IS NULL , '' , '[転]')                                                                                                                                                               ");
		sql.append("			  ,IF(A.BROUGHT_DRG_YN = 'Y' , '[持]', '')                                                                                                                                                             ");
		sql.append("			  , CASE A.BANNAB_YN WHEN 'Y' THEN CONCAT('[',TRIM(FN_ADM_MSG(3142, :f_language)),']') ELSE CASE SIGN(A.NALSU) WHEN -1 THEN CONCAT('[',TRIM(FN_ADM_MSG(3154, :f_language)),']') ELSE CASE A.DC_GUBUN WHEN 'Y' THEN CONCAT('[',TRIM(FN_ADM_MSG(3239, :f_language)),']') ELSE '' END END END	");
		sql.append("			  ,( CASE WHEN IFNULL(A.PORTABLE_YN, 'N') = 'N' THEN ''                                                                                                                                                                                 ");
		sql.append("				  ELSE FN_OCS_LOAD_CODE_NAME('PORTABLE_YN', A.PORTABLE_YN, :f_hosp_code, :f_language) END )                                                                                                                                         ");
		sql.append("			  ,( CASE WHEN C.ORDER_GUBUN IN ('A', 'B', 'C', 'D')                                                                                                                                                                                    ");
		sql.append("				  THEN CONCAT(IFNULL(FN_DRG_SPEC_NAME(C.HANGMOG_CODE, :f_hosp_code), ''),C.HANGMOG_NAME)                                                                                                                                            ");
		sql.append("				  ELSE C.HANGMOG_NAME  END )                                                                                                                                                                                                        ");
		sql.append("			 )                                                                                             HANGMOG_NAME      ,                                                                                                                      ");
		sql.append("			 A.SURYANG                                                                                     SURYANG           ,                                                                                                                      ");
		sql.append("			 A.NALSU                                                                                       NALSU             ,                                                                                                                      ");
		sql.append("			 CONCAT(                                                                                                                                                                                                                                ");
		sql.append("			   (CASE WHEN C.INPUT_CONTROL = '1' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                                                                                      ");
		sql.append("				WHEN C.INPUT_CONTROL = 'C' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                                                                                           ");
		sql.append("				WHEN C.INPUT_CONTROL = 'D' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                                                                                           ");
		sql.append("				WHEN C.INPUT_CONTROL = '2' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                                                                                           ");
		sql.append("				WHEN C.INPUT_CONTROL = '3' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                                                                                           ");
		sql.append("				WHEN C.INPUT_CONTROL = '6' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                                                                                           ");
		sql.append("				WHEN C.INPUT_CONTROL = '7' THEN CASE SUBSTRING(LTRIM(A.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(A.SURYANG)) ELSE LTRIM(A.SURYANG) END                                                                                           ");
		sql.append("				ELSE '' END),                                                                                                                                                                                                                       ");
		sql.append("			   (CASE WHEN C.ORDER_GUBUN    = 'K' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN C.INPUT_CONTROL       = '1' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN C.INPUT_CONTROL       = 'C' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN C.INPUT_CONTROL       = 'D' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN C.INPUT_CONTROL       = '2' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN C.INPUT_CONTROL       = '3' AND IFNULL(D.BUN_CODE,'XX') = 'T2' THEN FN_ADM_MSG(3185,:f_language)                                                                                                                               ");
		sql.append("				WHEN C.INPUT_CONTROL       = '3' THEN FN_ADM_MSG(3182,:f_language)                                                                                                                                                                  ");
		sql.append("				WHEN C.INPUT_CONTROL       = '6'                                                                                                                                                                                                    ");
		sql.append("				THEN CASE FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI,:f_hosp_code,:f_language) WHEN '' THEN FN_ADM_MSG(3186,:f_language) ELSE FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI,:f_hosp_code,:f_language) END                   		");
		sql.append("				WHEN C.INPUT_CONTROL       = '7'                                                                                                                                                                                                    ");
		sql.append("				THEN CASE FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI) WHEN '' THEN FN_ADM_MSG(3186,:f_language) ELSE FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI,:f_hosp_code,:f_language) END                                              	");
		sql.append("				ELSE '' END),                                                                                                                                                                                                                       ");
		sql.append("			   (CASE WHEN C.INPUT_CONTROL = '1' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME, :f_hosp_code, :f_language)                                                                                                                         ");
		sql.append("					 WHEN C.INPUT_CONTROL = '2' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME, :f_hosp_code, :f_language)                                                                                                                         ");
		sql.append("					 ELSE '' END ),                                                                                                                                                                                                                 ");
		sql.append("			   (CASE WHEN C.INPUT_CONTROL = '1' THEN CAST(A.DV AS CHAR)                                                                                                                                                                             ");
		sql.append("					 WHEN C.INPUT_CONTROL = '2' THEN CAST(A.DV AS CHAR)                                                                                                                                                                             ");
		sql.append("					 ELSE '' END ),                                                                                                                                                                                                                 ");
		sql.append("			   (CASE WHEN C.INPUT_CONTROL = '3' AND A.NALSU > 0 THEN CONCAT('*', A.NALSU, '分')                                                                                                                                                     ");
		sql.append("					 ELSE '' END ),                                                                                                                                                                                                                 ");
		sql.append("				   FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)                                                                                                                                        ");
		sql.append("			 )                                                                                             DETAIL            ,                                                                                                                      ");
		sql.append("			 TRIM(A.ORDER_REMARK)                                                                          ORDER_REMARK      ,                                                                                                                      ");
		sql.append("			 TRIM(A.NURSE_REMARK)                                                                          NURSE_REMARK      ,                                                                                                                      ");
		sql.append("			 A.TEL_YN                                                                                      TEL_YN            ,                                                                                                                      ");
		sql.append("			 A.EMERGENCY                                                                                   EMERGENCY         ,                                                                                                                      ");
		sql.append("			 FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA, :f_hosp_code, :f_language)                              JUSA_NAME         ,                                                                                                                      ");
		sql.append("			 (CASE WHEN IFNULL(A.SPECIMEN_CODE, '*') <> '*' AND A.BOGYONG_CODE IS NULL                                                                                                                                                              ");
		sql.append("				 THEN FN_OCS_LOAD_SPECIMEN_NAME(:f_hosp_code,A.SPECIMEN_CODE)                                                                                                                                                                       ");
		sql.append("				 WHEN IFNULL(A.SPECIMEN_CODE, '*') <> '*' AND A.BOGYONG_CODE IS NOT NULL                                                                                                                                                            ");
		sql.append("				 THEN CONCAT(FN_OCS_LOAD_SPECIMEN_NAME(:f_hosp_code,A.SPECIMEN_CODE),' ',FN_OCS_BOGYONG_COL_NAME(C.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN, :f_hosp_code, :f_language))                                                       ");
		sql.append("				 ELSE FN_OCS_BOGYONG_COL_NAME(C.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN, :f_hosp_code, :f_language) END )                                                                                                                     ");
		sql.append("																										   BOGYONG_NAME      ,                                                                                                                      ");
		sql.append("			 0                                                                                             JAEWONIL          ,                                                                                                                      ");
		sql.append("			 A.PKOCS2003                                                                                   PK                ,                                                                                                                      ");
		sql.append("			 CAST(A.GROUP_SER AS CHAR)                                                                     GROUP_SER         ,                                                                                                                      ");
		sql.append("			 A.MIX_GROUP                                                                                   MIX_GROUP         ,                                                                                                                      ");
		sql.append("			 'OCS2003'                                                                                     TABLE_ID          ,                                                                                                                      ");
		sql.append("			 ( CASE WHEN A.NURSE_PICKUP_DATE IS NULL                                                                                                                                                                                                ");
		sql.append("				   AND A.ORDER_GUBUN NOT LIKE 'D%'                                                                                                                                                                                                  ");
		sql.append("				   AND A.ORDER_GUBUN NOT LIKE 'N%'                                                                                                                                                                                                  ");
		sql.append("				  THEN 'N'                                                                                                                                                                                                                          ");
		sql.append("				  ELSE 'Y' END )                                                                              CONFIRM_YN        ,                                                                                                                   ");
		sql.append("			 CASE A.OCS_FLAG WHEN '3' THEN 'Y' WHEN '4' THEN 'Y' ELSE 'N' END                               ACTING_YN         ,                                                                                                                     ");
		sql.append("			 'N'                                                                                           CAN_PLAN_CHANGE_YN,                                                                                                                      ");
		sql.append("			 ( CASE WHEN SUBSTRING(A.INPUT_GUBUN, 1, 1) IN ('D', 'N') THEN 'Y'                                                                                                                                                                      ");
		sql.append("				  ELSE 'N' END )                                                                           CAN_CONFIRM_YN    ,                                                                                                                      ");
		sql.append("			 'N'                                                                                           CAN_ACTING_YN     ,                                                                                                                      ");
		sql.append("			 'N'                                                                                           CAN_PLAN_APP_YN   ,                                                                                                                      ");
		sql.append("			 CONCAT(DATE_FORMAT(A.ORDER_DATE, '%m/%d'),' ',FN_ADM_LOAD_USER_NM(:f_hosp_code, A.INPUT_ID, A.ORDER_DATE))                                                                                                                             ");
		sql.append("																										   INPUT_NAME        ,                                                                                                                      ");
		sql.append("			 IFNULL(E.SORT_KEY, 99)                                                                        INPUT_SEQ         ,                                                                                                                      ");
		sql.append("			 IFNULL(F.ORDER_END_YN  , 'N')                                                                 ORDER_END_YN      ,                                                                                                                      ");
		sql.append("			 (CASE WHEN IFNULL(H.USER_GUBUN, '3') = '2' THEN  FN_ADM_LOAD_USER_NM(:f_hosp_code, H.USER_ID, A.ORDER_DATE)                                                                                                                            ");
		sql.append("				 ELSE '' END )                                                                             CONFIRM_NAME      ,                                                                                                                      ");
		sql.append("			 (CASE WHEN SUBSTRING(A.ORDER_GUBUN, 2, 1) IN ('A', 'B' )                                                                                                                                                                               ");
		sql.append("					 THEN FN_OCS_CHECK_DETAIL_ACTING(A.PKOCS2003)                                                                                                                                                                                   ");
		sql.append("					 ELSE 'N' END)                         												   DETAIL_ACT_YN    ,                                                                                                                       ");
		sql.append("			 (CASE WHEN FN_OCS_BULYONG_CHECK(:f_hosp_code, A.HANGMOG_CODE, A.ORDER_DATE) = 'Y'                                                                                                                                                      ");
		sql.append("					  AND A.ACTING_DATE IS NULL                                                                                                                                                                                                     ");
		sql.append("					 THEN 'Y'                                                                                                                                                                                                                       ");
		sql.append("					 ELSE 'N' END)                       												   BULYONG_CHECK     ,                                                                                                                      ");
		sql.append("			 IFNULL(FN_ADM_LOAD_USER_NM(:f_hosp_code, A.NURSE_HOLD_USER, A.ORDER_DATE), '')                                                                                                                                                         ");
		sql.append("																										   NURSE_HOLD_USER   ,                                                                                                                      ");
		sql.append("			 A.INPUT_GWA                                                                                   INPUT_GWA         ,                                                                                                                      ");
		sql.append("			 A.INPUT_DOCTOR                                                                                INPUT_DOCTOR      ,                                                                                                                      ");
		sql.append("			 (CASE WHEN SUBSTRING(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')                                                                                                                                                                                ");
		sql.append("				 THEN DATE_FORMAT(FN_SCH_LOAD_RESER_DATE('I', A.PKOCS2003, :f_hosp_code), '%Y/%m/%d %H:%m')                                                                                                                                         ");
		sql.append("				 ELSE DATE_FORMAT(IFNULL(A.RESER_DATE, A.HOPE_DATE), '%Y/%m/%d') END )                                                                                                                                                              ");
		sql.append("																										   RESER_DATE        ,                                                                                                                      ");
		sql.append("			 A.ACTING_DATE                                                                                 ACTING_DATE       ,                                                                                                                      ");
		sql.append("			 A.JUNDAL_TABLE                                                                                JUNDAL_TABLE      ,                                                                                                                      ");
		sql.append("			 A.JUNDAL_PART                                                                                 JUNDAL_PART       ,                                                                                                                      ");
		sql.append("			 A.OCS_FLAG                                                                                    OCS_FLAG          ,                                                                                                                      ");
		sql.append("			 A.ORDER_DATE                                                                                  SOURCE_ORDER_DATE ,                                                                                                                      ");
		sql.append("			 'N'                                                                                           continue_yn       ,                                                                                                                      ");
		sql.append("			 CONCAT('1',SUBSTRING(A.ORDER_GUBUN, 2, 1),DATE_FORMAT(IFNULL(A.RESER_DATE, I.HOLI_DAY), '%Y%m%d'),'0000000000',LPAD(E.SORT_KEY, 2,'0'),LPAD(A.GROUP_SER, 3, '0'),IFNULL(A.MIX_GROUP, '  '),LPAD(A.SEQ, 4, '0'))                        ");
		sql.append("																										   CONT_KEY           ,                                                                                                                     ");
		sql.append("			 ''                                                                                            JISI_ORDER_GUBUN   ,                                                                                                                     ");
		sql.append("			 ''                                                                                            DIRECT_CONT        ,                                                                                                                     ");
		sql.append("			 0                                                                                             PKOCS2005          ,                                                                                                                     ");
		sql.append("			 0                                                                                             PKOCS6015          ,                                                                                                                     ");
		sql.append("			 A.INPUT_ID                                                                                    INPUT_ID           ,                                                                                                                     ");
		sql.append("			 A.DV                                                                                          DV                 ,																														");
		sql.append("			 CASE WHEN SUBSTRING(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')                                                                                                                                                                            ");
		sql.append("				  THEN FN_OCS_CHECK_DETAIL_MAX_ACTING(A.HOSP_CODE, A.PKOCS2003, IFNULL(A.HOPE_DATE, A.ORDER_DATE))                                                                                                                                  ");
		sql.append("				ELSE 'N'                                                                                                                                                                                                                            ");
		sql.append("			 END                                         												                         CHECK_ACTING       ,                                                                                               ");
		sql.append("			 DATEDIFF(I.HOLI_DAY, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))) + 1 			       AS DIFF  		      ,                                                                                                             ");
		sql.append("			 A.NURSE_ACT_USER                                                                              NURSE_ACT_USER     ,                                                                                                                     ");
		sql.append("			 A.NURSE_ACT_DATE                                                                              NURSE_ACT_DATE     ,                                                                                                                     ");
		sql.append("			 A.NURSE_ACT_TIME                                                                              NURSE_ACT_TIME     ,                                                                                                                     ");
		sql.append("			 FN_MEDICINE_ACTING_CHECK(A.HOSP_CODE, A.PKOCS2003, I.HOLI_DAY)                                MEDI_ACT_CHK       ,                                                                                                                     ");
		sql.append("			 IFNULL(BROUGHT_DRG_YN, 'N')                                                                   BROUGHT_DRG_YN     ,                                                                                                                     ");
		sql.append("			 FKOCS1003                                                                                     FKOCS1003          ,                                                                                                                     ");
		sql.append("			 NULL                                                                                          DRT_FROM_DATETIME  ,                                                                                                                     ");
		sql.append("			 NULL                                                                                          DRT_TO_DATETIME    ,                                                                                                                     ");
		sql.append("			 'ALL'                                                                                         JISI_GUBUN                                                                                                                               ");
		sql.append("		FROM OCS2003 A																																																								");
		sql.append("		LEFT JOIN OCS2004 B ON B.HOSP_CODE    = A.HOSP_CODE                                                                                                                                                                                         ");
		sql.append("						   AND B.BUNHO        = A.BUNHO                                                                                                                                                                                             ");
		sql.append("						   AND B.FKINP1001    = A.FKINP1001                                                                                                                                                                                         ");
		sql.append("						   AND B.ORDER_DATE   = A.ORDER_DATE								                                                                                                                                                        ");
		sql.append("						   AND B.INPUT_GUBUN  = A.INPUT_GUBUN								                                                                                                                                                        ");
		sql.append("		JOIN OCS0103 C ON C.HOSP_CODE         = A.HOSP_CODE                                                                                                                                                                                         ");
		sql.append("					  AND C.HANGMOG_CODE      = A.HANGMOG_CODE                                                                                                                                                                                      ");
		sql.append("					  AND DATE(A.ORDER_DATE) BETWEEN DATE(C.START_DATE) AND DATE(C.END_DATE)																																						");
		sql.append("		LEFT JOIN ( SELECT *                                                                                                                                                                                                                        ");
		sql.append("					  FROM BAS0310 A                                                                                                                                                                                                                ");
		sql.append("					  WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                                                                                              ");
		sql.append("					   AND A.SG_YMD    = (SELECT MAX(C.SG_YMD)                                                                                                                                                                                      ");
		sql.append("													  FROM BAS0310 C                                                                                                                                                                                ");
		sql.append("													WHERE C.HOSP_CODE = A.HOSP_CODE                                                                                                                                                                 ");
		sql.append("														AND C.SG_CODE   = A.SG_CODE)                                                                                                                                                                ");
		sql.append("		) D ON D.HOSP_CODE  = C.HOSP_CODE                                                                                                                                                                                                    		");
		sql.append("		   AND D.SG_CODE    = C.SG_CODE                                                                                                                                                                                                             ");
		sql.append("		JOIN OCS0132 E ON E.HOSP_CODE = A.HOSP_CODE                                                                                                                                                                                                 ");
		sql.append("					  AND E.CODE_TYPE = 'INPUT_GUBUN'                                                                                                                                                                                               ");
		sql.append("					  AND E.CODE      = A.INPUT_GUBUN			                                                                                                                                                                                    ");
		sql.append("		LEFT JOIN OCS6013 F ON F.HOSP_CODE      = A.HOSP_CODE                                                                                                                                                                                       ");
		sql.append("						   AND F.ref_FKOCS2003  = A.PKOCS2003	                                                                                                                                                                                    ");
		sql.append("		LEFT JOIN DRG3010 G ON G.HOSP_CODE  = A.HOSP_CODE                                                                                                                                                                                           ");
		sql.append("						   AND G.FKOCS2003  = A.PKOCS2003		                                                                                                                                                                                    ");
		sql.append("		LEFT JOIN ADM3200 H ON H.HOSP_CODE  = A.HOSP_CODE                                                                                                                                                                                           ");
		sql.append("						   AND H.USER_ID    = A.NURSE_PICKUP_USER			                                                                                                                                                                        ");
		sql.append("		JOIN RES0101 I ON I.HOLI_DAY        <= :f_to_date                                                                                                                                                                                           ");
		sql.append("					  AND I.HOLI_DAY BETWEEN :f_from_date AND :f_to_date	                                                                                                                                                                        ");
		sql.append("		WHERE A.HOSP_CODE          = :f_hosp_code       					                                                                                                                                                                        ");
		sql.append("		AND A.BUNHO                = :f_bunho                                                                                                                                                                                                       ");
		sql.append("		AND A.FKINP1001            = :f_fkinp1001                                                                                                                                                                                                   ");
		sql.append("																																																													");
		sql.append("		AND (      (   (IF(A.INSTEAD_YN IS NULL OR A.INSTEAD_YN = '', 'N', A.INSTEAD_YN) = 'N')                                                                                                                                                                                        ");
		sql.append("				   OR (IF(A.POSTAPPROVE_YN IS NULL OR A.POSTAPPROVE_YN = '', 'N', A.POSTAPPROVE_YN) = 'Y')                                                                                                                                                                                         ");
		sql.append("				  )                                                                                                                                                                                                                                 ");
		sql.append("			   OR (   (IF(A.INSTEAD_YN IS NULL OR A.INSTEAD_YN = '', 'N', A.INSTEAD_YN) = 'Y' AND :f_instead_order_display_yn = 'Y')                                                                                                                                                  ");
		sql.append("				   OR (IF(A.APPROVE_YN IS NULL OR A.APPROVE_YN = '', 'N', A.APPROVE_YN) = 'Y' AND :f_instead_order_display_yn = 'N')                                                                                                                                                  ");
		sql.append("				  )                                                                                                                                                                                                                                 ");
		sql.append("		   )                                                                                                                                                                                                                                        ");
		sql.append("		AND ( (CASE WHEN SUBSTRING(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')                                                                                                                                                                               ");
		sql.append("				   THEN IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)))                                                                                                                                              ");
		sql.append("				   WHEN A.INPUT_TAB = '10'                                                                                                                                                                                                          ");
		sql.append("				   THEN IFNULL(A.ACTING_DATE, A.ORDER_DATE)												                                                                                                                                            ");
		sql.append("				   ELSE IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)) END ) >= :f_from_date	                                                                                                                                            ");
		sql.append("		   																								                                                                                                                                            ");
		sql.append("		  OR (CASE WHEN SUBSTRING(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D', 'Z')							                                                                                                                                            ");
		sql.append("				   THEN IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE)) END ) >= A.ORDER_DATE)	                                                                                                                                            ");
		sql.append("		AND IF(A.NDAY_YN IS NULL OR A.NDAY_YN = '', 'N', A.NDAY_YN) = 'N'																                                                                                                                                            ");
		sql.append("		AND IF(A.PRN_YN IS NULL OR A.PRN_YN = '','N', A.PRN_YN)      = 'N'                                                                                                                                                                                                         ");
		sql.append("		AND ( IF(A.DC_YN IS NULL OR A.DC_YN = '', 'N', A.DC_YN) = 'N' OR ( IF(A.DC_YN IS NULL OR A.DC_YN = '','N', A.DC_YN) = 'Y' AND IF( A.BANNAB_YN IS NULL OR A.BANNAB_YN = '', 'N', A.BANNAB_YN) = 'N' ) )                                                                                                                                ");
		sql.append("		AND (                                                                                                                                                                                                                                       ");
		sql.append("				  (IFNULL(:f_c, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'C')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_d, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'D')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_b, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'B')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_h, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'H')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_g, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'G')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_m, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'M')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_f, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'F')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_o, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'O')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_n, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'N')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_e, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'E')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_l, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'L')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_k, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'K')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_i, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'I')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_z, 'N') = 'Y' AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'Z')                                                                                                                                                                ");
		sql.append("		   )                                                                                                                                                                                            											");
		sql.append("		AND(                                                                                                                                                                                                                                        ");
		sql.append("			  (     C.ORDER_GUBUN != 'D'                                                                                                                                                                                                            ");
		sql.append("				AND A.INPUT_TAB   != '10'                                                                                                                                                                                                           ");
		sql.append("				AND A.INPUT_TAB   != '01'                                                                                                                                                                                                           ");
		sql.append("				AND A.INPUT_TAB   != '03'                                                                                                                                                                                                           ");
		sql.append("				AND ( (I.HOLI_DAY BETWEEN IFNULL(A.ACTING_DATE, IFNULL(IFNULL(A.HOPE_DATE, A.ORDER_DATE), CURRENT_DATE()))                                                                                                                          ");
		sql.append("									  AND DATE_ADD(IFNULL(A.ACTING_DATE, IFNULL(IFNULL(A.HOPE_DATE, A.ORDER_DATE), CURRENT_DATE())), INTERVAL (ABS(IF(C.INPUT_CONTROL = '3', 1, A.NALSU)) - 1) DAY)	                                                ");
		sql.append("					   AND IF(C.INPUT_CONTROL = '3', 1, A.NALSU) > 0 )																																                                                ");
		sql.append("				 																																													                                                ");
		sql.append("					   OR(    I.HOLI_DAY BETWEEN DATE_FORMAT(FN_OCSI_LOAD_BANNAB_FROM_DATE(:f_hosp_code, A.SOURCE_FKOCS2003), '%Y/%m/%d')                                                                                                                         ");
		sql.append("											 AND DATE_FORMAT(FN_OCSI_LOAD_BANNAB_TO_DATE(:f_hosp_code, A.SOURCE_FKOCS2003),   '%Y/%m/%d')                                                                                                                         ");
		sql.append("						   AND A.NALSU < 0) )                                                                                                                                                                                                       ");
		sql.append("			  )                                                                                                                                                                                                                                     ");
		sql.append("		  OR (      C.ORDER_GUBUN != 'D'                                                                                                                                                                                                            ");
		sql.append("			   AND  A.INPUT_TAB   != '10'                                                                                                                                                                                                           ");
		sql.append("			   AND (   A.INPUT_TAB = '01'                                                                                                                                                                         									");
		sql.append("					OR A.INPUT_TAB = '03')                                                                                                                                                                                                          ");
		sql.append("			   AND ( (I.HOLI_DAY BETWEEN IFNULL(IFNULL(A.HOPE_DATE, A.ORDER_DATE), CURRENT_DATE())                                                                                                                                                  ");
		sql.append("									 AND DATE_ADD(IFNULL(IFNULL(A.HOPE_DATE, A.ORDER_DATE), CURRENT_DATE()), INTERVAL (ABS(IF(C.INPUT_CONTROL = '3', 1, A.NALSU)) - 1) DAY)																			");
		sql.append("					  AND IF(C.INPUT_CONTROL = '3', 1, A.NALSU) > 0 )                                                                                                                                                                            	");
		sql.append("					  OR(     I.HOLI_DAY BETWEEN DATE_FORMAT(FN_OCSI_LOAD_BANNAB_FROM_DATE(:f_hosp_code, A.SOURCE_FKOCS2003), '%Y/%m/%d')                                                                                                                         ");
		sql.append("											 AND DATE_FORMAT(FN_OCSI_LOAD_BANNAB_TO_DATE(:f_hosp_code, A.SOURCE_FKOCS2003),   '%Y/%m/%d')                                                                                                                         ");
		sql.append("						  AND A.NALSU < 0 ) )                                                                                                                                                                                                       ");
		sql.append("			 )                                                                                                                                                                                                                                      ");
		sql.append("		  OR (    C.ORDER_GUBUN = 'D'                                                                                                                                                                                                               ");
		sql.append("			  AND ( ( I.HOLI_DAY BETWEEN IFNULL(IFNULL(A.HOPE_DATE, A.ORDER_DATE), CURRENT_DATE())                                                                                                                                                  ");
		sql.append("									 AND DATE_ADD(IFNULL(IFNULL(A.HOPE_DATE, A.ORDER_DATE), CURRENT_DATE()), INTERVAL (A.DV -1) DAY)																												");
		sql.append("					  AND A.NALSU > 0)                                                                                                                                                                                                              ");
		sql.append("					  OR (    I.HOLI_DAY BETWEEN DATE_FORMAT(FN_OCSI_LOAD_BANNAB_FROM_DATE(:f_hosp_code, A.SOURCE_FKOCS2003), '%Y/%m/%d')                                                                                                                         ");
		sql.append("											 AND DATE_FORMAT(FN_OCSI_LOAD_BANNAB_TO_DATE(:f_hosp_code, A.SOURCE_FKOCS2003),   '%Y/%m/%d')                                                                                                                         ");
		sql.append("						   AND A.NALSU < 0 ) )                                                                                                                                                                                                      ");
		sql.append("			  )                                                                                                                                                                                                                                     ");
		sql.append("		   OR (    A.INPUT_TAB = '10'                                                                                                                                                                                                               ");
		sql.append("			   AND I.HOLI_DAY  = IFNULL(A.ACTING_DATE, A.ORDER_DATE)                                                                                                                                                                                ");
		sql.append("			  )                                                                                                                                                                                                                                     ");
		sql.append("		  )                                                                                                                                                                                                                                         ");
		sql.append("																																																													");
		sql.append("		AND ((A.INPUT_GUBUN != 'D7') OR (A.INPUT_GUBUN = 'D7' AND I.HOLI_DAY = IFNULL(A.RESER_DATE, IFNULL(A.HOPE_DATE, A.ORDER_DATE))))                                                                                                            ");
		sql.append("		AND NOT EXISTS ( SELECT 'X'                                                                                                                                                                                                                 ");
		sql.append("						 FROM OCS0132 J                                                                                                                                                                                                             ");
		sql.append("						WHERE J.HOSP_CODE  = A.HOSP_CODE                                                                                                                                                                                            ");
		sql.append("						  AND J.CODE_TYPE  = 'MARUME_ORDER'                                                                                                                                                                                         ");
		sql.append("						  AND J.CODE       = A.HANGMOG_CODE                                                                                                                                                                                         ");
		sql.append("						  AND A.DISPLAY_YN = 'N')                                                                                                                                                                                                   ");
		sql.append("							                                                                                                                                                                                                                        ");
		sql.append("		UNION ALL			                                                                                                                                                                                                                        ");
		sql.append("							                                                                                                                                                                                                                        ");
		sql.append("		SELECT A.BUNHO                                       BUNHO             ,                                                                                                                                                                    ");
		sql.append("			   A.FKINP1001                                   FKINP1001         ,                                                                                                                                                                    ");
		sql.append("			   B.FKOCS6010                                   FKOCS6010         ,                                                                                                                                                                    ");
		sql.append("			   NULL                                          CP_NAME           ,                                                                                                                                                                    ");
		sql.append("			   B.PLAN_ORDER_DATE                             ORDER_DATE        ,                                                                                                                                                                    ");
		sql.append("			   B.PLAN_ORDER_DATE                             ORDER_END_DATE    ,                                                                                                                                                                    ");
		sql.append("			   B.INPUT_GUBUN                                 INPUT_GUBUN       ,                                                                                                                                                                    ");
		sql.append("			   F.CODE_NAME                                   INPUT_GUBUN_NAME  ,                                                                                                                                                                    ");
		sql.append("			   SUBSTRING(B.ORDER_GUBUN, 2, 1)                ORDER_GUBUN       ,                                                                                                                                                                    ");
		sql.append("			   B.ORDER_GUBUN                                 ORDER_GUBUN_ORI   ,                                                                                                                                                                    ");
		sql.append("			   FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTRING(B.ORDER_GUBUN, 2, 1), :f_hosp_code, :f_language)                                                                                                                                  ");
		sql.append("																					 ORDER_GUBUN_NAME  ,                                                                                                                                            ");
		sql.append("			   B.HANGMOG_CODE                                HANGMOG_CODE      ,                    	                                                                                                                                            ");
		sql.append("			   CONCAT(																					                                                                                                                                            ");
		sql.append("				 ( CASE WHEN IFNULL(B.PORTABLE_YN, 'N') = 'N' THEN ''										                                                                                                                                        ");
		sql.append("					  ELSE FN_OCS_LOAD_CODE_NAME('PORTABLE_YN', B.PORTABLE_YN, :f_hosp_code, :f_language) END ),                                                                                                                                    ");
		sql.append("				 IF(B.PRN_YN = 'Y', '[PRN]', ''),																                                                                                                                                    ");
		sql.append("				 ( CASE WHEN D.ORDER_GUBUN IN ('A', 'B', 'C', 'D')												                                                                                                                                    ");
		sql.append("					  THEN CONCAT(IFNULL(FN_DRG_SPEC_NAME(D.HANGMOG_CODE,:f_hosp_code), ''),D.HANGMOG_NAME)		                                                                                                                                    ");
		sql.append("					  ELSE D.HANGMOG_NAME  END )																                                                                                                                                    ");
		sql.append("			   )                                             HANGMOG_NAME      ,                                                                                                                                                                    ");
		sql.append("			   B.SURYANG                                     SURYANG           ,                                                                                                                                                                    ");
		sql.append("			   B.NALSU                                       NALSU             ,                                                                                                                                                                    ");
		sql.append("			   CONCAT(																																																								");
		sql.append("			   (CASE WHEN D.INPUT_CONTROL = '1' THEN CASE SUBSTRING(LTRIM(B.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(B.SURYANG)) ELSE LTRIM(B.SURYANG) END                                                                                      ");
		sql.append("				WHEN D.INPUT_CONTROL = 'C' THEN CASE SUBSTRING(LTRIM(B.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(B.SURYANG)) ELSE LTRIM(B.SURYANG) END                                                                                           ");
		sql.append("				WHEN D.INPUT_CONTROL = 'D' THEN CASE SUBSTRING(LTRIM(B.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(B.SURYANG)) ELSE LTRIM(B.SURYANG) END                                                                                           ");
		sql.append("				WHEN D.INPUT_CONTROL = '2' THEN CASE SUBSTRING(LTRIM(B.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(B.SURYANG)) ELSE LTRIM(B.SURYANG) END                                                                                           ");
		sql.append("				WHEN D.INPUT_CONTROL = '3' THEN CASE SUBSTRING(LTRIM(B.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(B.SURYANG)) ELSE LTRIM(B.SURYANG) END                                                                                           ");
		sql.append("				WHEN D.INPUT_CONTROL = '6' THEN CASE SUBSTRING(LTRIM(B.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(B.SURYANG)) ELSE LTRIM(B.SURYANG) END                                                                                           ");
		sql.append("				WHEN D.INPUT_CONTROL = '7' THEN CASE SUBSTRING(LTRIM(B.SURYANG),1,1) WHEN '.' THEN CONCAT('0',LTRIM(B.SURYANG)) ELSE LTRIM(B.SURYANG) END                                                                                           ");
		sql.append("				ELSE '' END),																							                                                                                                                            ");
		sql.append("			   (CASE WHEN D.ORDER_GUBUN    = 'K' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN D.INPUT_CONTROL       = '1' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN D.INPUT_CONTROL       = 'C' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN D.INPUT_CONTROL       = 'D' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN D.INPUT_CONTROL       = '2' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.ORD_DANUI,:f_hosp_code,:f_language)                                                                                                                       ");
		sql.append("				WHEN D.INPUT_CONTROL       = '3' AND IFNULL(E.BUN_CODE,'XX') = 'T2'	                                                                                                                                                                ");
		sql.append("				THEN FN_ADM_MSG(3185,:f_language)									                                                                                                                                                                ");
		sql.append("				WHEN D.INPUT_CONTROL       = '3' THEN FN_ADM_MSG(3182,:f_language)	                                                                                                                                                                ");
		sql.append("				WHEN D.INPUT_CONTROL       = '6'																																											                        ");
		sql.append("				THEN CASE FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.ORD_DANUI,:f_hosp_code,:f_language) WHEN '' THEN FN_ADM_MSG(3186,:f_language) ELSE FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.ORD_DANUI,:f_hosp_code,:f_language) END                        ");
		sql.append("				WHEN D.INPUT_CONTROL       = '7'																																											                        ");
		sql.append("				THEN CASE FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.ORD_DANUI,:f_hosp_code,:f_language) WHEN '' THEN FN_ADM_MSG(3186,:f_language) ELSE FN_OCS_LOAD_CODE_NAME('ORD_DANUI',B.ORD_DANUI,:f_hosp_code,:f_language) END                        ");
		sql.append("				ELSE '' END																									                                                                                                                        ");
		sql.append("			   ),																											                                                                                                                        ");
		sql.append("			   (CASE WHEN D.INPUT_CONTROL = '1' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', B.DV_TIME, :f_hosp_code, :f_language)	                                                                                                                        ");
		sql.append("					 WHEN D.INPUT_CONTROL = '2' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', B.DV_TIME, :f_hosp_code, :f_language)	                                                                                                                        ");
		sql.append("					 ELSE '' END ),																							                                                                                                                        ");
		sql.append("			   (CASE WHEN D.INPUT_CONTROL = '1' THEN CAST(B.DV AS CHAR)														                                                                                                                        ");
		sql.append("					 WHEN D.INPUT_CONTROL = '2' THEN CAST(B.DV AS CHAR)														                                                                                                                        ");
		sql.append("					 ELSE '' END ),																							                                                                                                                        ");
		sql.append("			   (CASE WHEN D.INPUT_CONTROL = '1' THEN CONCAT('  ',IF(B.NALSU = 1, '', CONCAT(CAST(B.NALSU AS CHAR),FN_ADM_MSG(3184,:f_language))))	                                                                                                ");
		sql.append("					 WHEN D.INPUT_CONTROL = '2' THEN CONCAT('  ',IF(B.NALSU = 1, '', CONCAT(CAST(B.NALSU AS CHAR),FN_ADM_MSG(3184,:f_language))))	                                                                                                ");
		sql.append("					 WHEN D.INPUT_CONTROL = '3' THEN CONCAT('  ',CAST(B.NALSU AS CHAR),FN_ADM_MSG(3183,:f_language))								                                                                                                ");
		sql.append("					 WHEN D.INPUT_CONTROL = '7' THEN CONCAT('  ',IF(B.NALSU = 1, '', CONCAT(CAST(B.NALSU AS CHAR),FN_ADM_MSG(3184,:f_language))))	                                                                                                ");
		sql.append("					 WHEN D.INPUT_CONTROL = '8' THEN CONCAT('  ',IF(B.NALSU = 1, '', CONCAT(CAST(B.NALSU AS CHAR),FN_ADM_MSG(3184,:f_language))))	                                                                                                ");
		sql.append("						 ELSE '' END),																																                                                                                ");
		sql.append("				   FN_OCS_LOAD_DV_NAME(B.DV, B.DV_1, B.DV_2, B.DV_3, B.DV_4, B.DV_5, B.DV_6, B.DV_7, B.DV_8)																																		");
		sql.append("				 )										     DETAIL            ,                                                                                                                                                                    ");
		sql.append("			   TRIM(B.ORDER_REMARK)                          ORDER_REMARK      ,                                                                                                                                                                    ");
		sql.append("			   TRIM(B.NURSE_REMARK)                          NURSE_REMARK      ,                                                                                                                                                                    ");
		sql.append("			   'N'                                           TEL_YN            ,                                                                                                                                                                    ");
		sql.append("			   B.EMERGENCY                                   EMERGENCY         ,                                                                                                                                                                    ");
		sql.append("			   FN_OCS_LOAD_CODE_NAME('JUSA', B.JUSA, :f_hosp_code, :f_language)                                                                                                                                                                     ");
		sql.append("															 JUSA_NAME         ,		                                                                                                                                                            ");
		sql.append("			   (CASE WHEN IFNULL(B.SPECIMEN_CODE, '*') <> '*' AND B.BOGYONG_CODE IS NULL                                                                                                                                                            ");
		sql.append("					 THEN FN_OCS_LOAD_SPECIMEN_NAME(:f_hosp_code,B.SPECIMEN_CODE)				                                                                                                                                                    ");
		sql.append("					 WHEN IFNULL(B.SPECIMEN_CODE, '*') <> '*' AND B.BOGYONG_CODE IS NOT NULL	                                                                                                                                                    ");
		sql.append("					 THEN CONCAT(FN_OCS_LOAD_SPECIMEN_NAME(:f_hosp_code,B.SPECIMEN_CODE),' ',FN_OCS_BOGYONG_COL_NAME(D.ORDER_GUBUN, B.BOGYONG_CODE, B.JUSA_SPD_GUBUN, :f_hosp_code,:f_language))                                                    ");
		sql.append("					 ELSE FN_OCS_BOGYONG_COL_NAME(D.ORDER_GUBUN, B.BOGYONG_CODE, B.JUSA_SPD_GUBUN,:f_hosp_code,:f_language) END )																													");
		sql.append("															 BOGYONG_NAME      ,                                                                                                                                                                    ");
		sql.append("			   B.JAEWONIL                                    JAEWONIL          ,                                                                                                                                                                    ");
		sql.append("			   B.PKOCS6013                                   PK                ,                                                                                                                                                                    ");
		sql.append("			   CAST(B.GROUP_SER AS CHAR)                     GROUP_SER         ,                                                                                                                                                                    ");
		sql.append("			   B.MIX_GROUP                                   MIX_GROUP         ,                                                                                                                                                                    ");
		sql.append("			   'OCS6013'                                     TABLE_ID          ,                                                                                                                                                                    ");
		sql.append("			   'N'                                           CONFIRM_YN        ,                                                                                                                                                                    ");
		sql.append("			   'N'                                           ACTING_YN         ,                                                                                                                                                                    ");
		sql.append("			   'N'                                           CAN_PLAN_CHANGE_YN,                                                                                                                                                                    ");
		sql.append("			   'N'                                           CAN_CONFIRM_YN    ,                       	                                                                                                                                            ");
		sql.append("			   'N'                                           CAN_ACTING_YN     ,                       	                                                                                                                                            ");
		sql.append("			   ( CASE WHEN FN_OCS_BULYONG_CHECK(:f_hosp_code,B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  <> 'Y'	                                                                                                                                            ");
		sql.append("					  THEN 'Y'																			                                                                                                                                            ");
		sql.append("					  WHEN FN_OCS_BULYONG_CHECK(:f_hosp_code,B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  = 'Y'	                                                                                                                                            ");
		sql.append("					   AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', B.HANGMOG_CODE, A.BUNHO, B.PLAN_ORDER_DATE, :f_hosp_code) <> B.HANGMOG_CODE	                                                                                                    ");
		sql.append("					  THEN 'Y'																													                                                                                                    ");
		sql.append("					  ELSE 'N' END )                             CAN_PLAN_APP_YN   ,															                                                                                                    ");
		sql.append("			   CONCAT(DATE_FORMAT(B.PLAN_ORDER_DATE, '%Y/%m/%d'),' ',FN_ADM_LOAD_USER_NM(:f_hosp_code, B.INPUT_DOCTOR, B.PLAN_ORDER_DATE))		                                                                                                    ");
		sql.append("															 INPUT_NAME        ,                                                                                                                                                                    ");
		sql.append("			   IFNULL(F.SORT_KEY, 99)                        INPUT_SEQ         ,                                                                                                                                                                    ");
		sql.append("			   B.ORDER_END_YN                                ORDER_END_YN      ,                                                                                                                                                                    ");
		sql.append("			   NULL                                          CONFIRM_NAME      ,                                                                                                                                                                    ");
		sql.append("			   'N'                                           DETAIL_ACT_YN     ,                                                                                                                                                                    ");
		sql.append("			   ( CASE WHEN FN_OCS_BULYONG_CHECK(:f_hosp_code,B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  <> 'Y'	                                                                                                                                            ");
		sql.append("					  THEN 'N'																			                                                                                                                                            ");
		sql.append("					  WHEN FN_OCS_BULYONG_CHECK(:f_hosp_code,B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  = 'Y'	                                                                                                                                            ");
		sql.append("					   AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', B.HANGMOG_CODE, A.BUNHO, B.PLAN_ORDER_DATE, :f_hosp_code) <> B.HANGMOG_CODE                                                                                                        ");
		sql.append("					  THEN 'Z'														                                                                                                                                                                ");
		sql.append("					  ELSE 'Y' END )                             BULYONG_CHECK     ,                                                                                                                                                                ");
		sql.append("			   IFNULL(FN_ADM_LOAD_USER_NM(:f_hosp_code, B.NURSE_HOLD_USER, B.PLAN_ORDER_DATE), '')                                                                                                                                                  ");
		sql.append("																					 NURSE_HOLD_USER   ,                                                                                                                                            ");
		sql.append("			   ' '                                           INPUT_GWA         ,                                                                                                                                                                    ");
		sql.append("			   ' '                                           INPUT_DOCTOR      ,                                                                                                                                                                    ");
		sql.append("			   NULL                                          RESER_DATE        ,                                                                                                                                                                    ");
		sql.append("			   NULL                                          ACTING_DATE       ,                                                                                                                                                                    ");
		sql.append("			   B.JUNDAL_TABLE                                JUNDAL_TABLE      ,                                                                                                                                                                    ");
		sql.append("			   B.JUNDAL_PART                                 JUNDAL_PART       ,                                                                                                                                                                    ");
		sql.append("			   ( CASE WHEN B.ref_FKOCS2003 IS NOT NULL					                                                                                                                                                                            ");
		sql.append("					 THEN '3'											                                                                                                                                                                            ");
		sql.append("					 ELSE '0' END )                          OCS_FLAG          ,                                                                                                                                                                    ");
		sql.append("			   B.PLAN_ORDER_DATE                             SOURCE_ORDER_DATE  ,                                                                                                                                                                   ");
		sql.append("			   'N'                                           continue_yn       ,                                                                                                                                                                    ");
		sql.append("			   CONCAT('1',SUBSTRING(B.ORDER_GUBUN, 2, 1),DATE_FORMAT(B.PLAN_ORDER_DATE , '%Y%m%d'),LPAD(B.FKOCS6010, 10, '0'),LPAD(F.SORT_KEY, 2, '0'),LPAD(B.GROUP_SER, 3, '0'),IFNULL(B.MIX_GROUP, '  '),LPAD(B.SEQ, 4, '0'))						");
		sql.append("															 CONT_KEY			                                                                                                                                                                    ");
		sql.append("			 , ''                                            JISI_ORDER_GUBUN	                                                                                                                                                                    ");
		sql.append("			 , ''                                            DIRECT_CONT		                                                                                                                                                                    ");
		sql.append("			 , 0                                             PKOCS2005			                                                                                                                                                                    ");
		sql.append("			 , 0                                             PKOCS6015			                                                                                                                                                                    ");
		sql.append("			 , B.INPUT_ID                                    INPUT_ID			                                                                                                                                                                    ");
		sql.append("			 , 0                                             DV					                                                                                                                                                                    ");
		sql.append("			 , 'N'                                           CHECK_ACTING		                                                                                                                                                                    ");
		sql.append("			 , NULL                                          DIFF				                                                                                                                                                                    ");
		sql.append("			 , NULL                                          NURSE_ACT_USER                                                                                                                                                                         ");
		sql.append("			 , NULL                                          NURSE_ACT_DATE                                                                                                                                                                         ");
		sql.append("			 , NULL                                          NURSE_ACT_TIME                                                                                                                                                                         ");
		sql.append("			 , NULL                                          MEDI_ACT_CHK			                                                                                                                                                                ");
		sql.append("			 , NULL                                          BROUGHT_DRG_YN			                                                                                                                                                                ");
		sql.append("			 , NULL                                          FKOCS1003     			                                                                                                                                                                ");
		sql.append("			 , NULL                                          DRT_FROM_DATETIME		                                                                                                                                                                ");
		sql.append("			 , NULL                                          DRT_TO_DATETIME                                                                                                                                                                        ");
		sql.append("			 , 'ALL'                                         JISI_GUBUN				                                                                                                                                                                ");
		sql.append("		FROM OCS6010 A																                                                                                                                                                                ");
		sql.append("		JOIN OCS6013 B ON B.HOSP_CODE             = A.HOSP_CODE                                                                                                                                                                                     ");
		sql.append("					  AND B.FKOCS6010             = A.PKOCS6010                                                                                                                                                                                     ");
		sql.append("		LEFT JOIN OCS6014 C ON C.HOSP_CODE        = B.HOSP_CODE                                                                                                                                                                                     ");
		sql.append("						   AND C.FKOCS6010        = B.FKOCS6010                                                                                                                                                                                     ");
		sql.append("						   AND C.JAEWONIL         = B.JAEWONIL                                                                                                                                                                                      ");
		sql.append("						   AND C.PLAN_ORDER_DATE  = B.PLAN_ORDER_DATE	                                                                                                                                                                            ");
		sql.append("						   AND C.INPUT_GUBUN      = B.INPUT_GUBUN		                                                                                                                                                                            ");
		sql.append("		JOIN OCS0103 D ON D.HOSP_CODE             = B.HOSP_CODE			                                                                                                                                                                            ");
		sql.append("					  AND D.HANGMOG_CODE          = B.HANGMOG_CODE		                                                                                                                                                                            ");
		sql.append("					  AND DATE(B.PLAN_ORDER_DATE) BETWEEN DATE(D.START_DATE) AND DATE(D.END_DATE)                                                                                                                                                   ");
		sql.append("		LEFT JOIN BAS0310 E ON E.HOSP_CODE        = D.HOSP_CODE                                                                                                                                                                                     ");
		sql.append("						   AND E.SG_CODE          = D.SG_CODE	                                                                                                                                                                                    ");
		sql.append("		JOIN OCS0132 F ON F.HOSP_CODE             = B.HOSP_CODE	                                                                                                                                                                                    ");
		sql.append("					  AND F.CODE_TYPE             = 'INPUT_GUBUN'                                                                                                                                                                                   ");
		sql.append("					  AND F.CODE                  = B.INPUT_GUBUN                                                                                                                                                                                   ");
		sql.append("		WHERE A.HOSP_CODE          = :f_hosp_code	                                                                                                                                                                                                ");
		sql.append("		  AND A.BUNHO              = :f_bunho		                                                                                                                                                                                                ");
		sql.append("		  AND A.FKINP1001          = :f_fkinp1001	                                                                                                                                                                                                ");
		sql.append("		  AND IFNULL(A.CP_END_YN, 'N') = 'N'		                                                                                                                                                                                                ");
		sql.append("		  AND B.PLAN_ORDER_DATE   >= :f_from_date	                                                                                                                                                                                                ");
		sql.append("		  AND B.PLAN_ORDER_DATE   <= :f_to_date		                                                                                                                                                                                                ");
		sql.append("		  AND IFNULL(B.FKOCS2003, 0)  = 0			                                                                                                                                                                                                ");
		sql.append("		  AND IFNULL(B.PRN_YN,'N')    = 'N'			                                                                                                                                                                                                ");
		sql.append("		  AND (										                                                                                                                                                                                                ");
		sql.append("				  (IFNULL(:f_c, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'C')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_d, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'D')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_b, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'B')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_h, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'H')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_g, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'G')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_m, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'M')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_f, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'F')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_o, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'O')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_n, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'N')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_e, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'E')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_l, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'L')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_k, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'K')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_i, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'I')                                                                                                                                                                ");
		sql.append("			   OR (IFNULL(:f_z, 'N') = 'Y' AND SUBSTRING(B.ORDER_GUBUN, 2, 1) = 'Z')                                                                                                                                                                ");
		sql.append("			 )	                                                                                                                                                                                                                                    ");
		sql.append("	) A			                                                                                                                                                                                                                                    ");
		sql.append("	WHERE A.ORDER_DATE BETWEEN :f_from_date AND :f_to_date                                                                                                                                                                                          ");
		sql.append("	ORDER BY A.CONT_KEY									                                                                                                                                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_allsiji", allSiji);
		query.setParameter("f_emergency_treat", emergencyTreat);
		query.setParameter("f_instead_order_display_yn", insteadOrderDisplayYn);
		
		query.setParameter("f_b", StringUtils.isEmpty(fB) ? null : fB);
		query.setParameter("f_c", StringUtils.isEmpty(fC) ? null : fC);
		query.setParameter("f_d", StringUtils.isEmpty(fD) ? null : fD);
		query.setParameter("f_h", StringUtils.isEmpty(fH) ? null : fH);
		query.setParameter("f_g", StringUtils.isEmpty(fG) ? null : fG);
		query.setParameter("f_m", StringUtils.isEmpty(fM) ? null : fM);
		query.setParameter("f_f", StringUtils.isEmpty(fF) ? null : fF);
		query.setParameter("f_o", StringUtils.isEmpty(fO) ? null : fO);
		query.setParameter("f_n", StringUtils.isEmpty(fN) ? null : fN);
		query.setParameter("f_e", StringUtils.isEmpty(fE) ? null : fE);
		query.setParameter("f_l", StringUtils.isEmpty(fL) ? null : fL);
		query.setParameter("f_k", StringUtils.isEmpty(fK) ? null : fK);
		query.setParameter("f_i", StringUtils.isEmpty(fI) ? null : fI);
		query.setParameter("f_z", StringUtils.isEmpty(fZ) ? null : fZ);
		
		query.setParameter("f_comment_yn", commentYn);
		query.setParameter("f_remark_yn", remarkYn);
		
		List<OCS6010U10LoadDetailDataInfo> lstResult = new JpaResultMapper().list(query, OCS6010U10LoadDetailDataInfo.class);
		return lstResult;
	}

	@Override
	public CommonProcResultInfo callPrOcsPlanDirectConvert(String hospCode, Double pkOcs6015, Date appDate, String userId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_PLAN_DIRECT_CONVERT");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS6015", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_APP_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_PKOCS2005", Integer.class, ParameterMode.INOUT);          		
	    query.registerStoredProcedureParameter("IO_PK_SEQ", Integer.class, ParameterMode.INOUT);         		
	    query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_PKOCS6015", pkOcs6015);
		query.setParameter("I_APP_DATE", appDate);
		query.setParameter("I_USER_ID", userId);
		
	    query.execute();
	    Integer pkocs2005 = (Integer)query.getOutputParameterValue("IO_PKOCS2005");
	    Integer pkseq = (Integer)query.getOutputParameterValue("IO_PK_SEQ");
	    String err = (String)query.getOutputParameterValue("IO_PK_SEQ");
	    
	    CommonProcResultInfo info = new CommonProcResultInfo();
	    info.setStrResult1(pkocs2005 == null ? "" : String.valueOf(pkocs2005));
	    info.setStrResult2(pkseq == null ? "" : String.valueOf(pkseq));
	    info.setStrResult3(err == null ? "" : err);
	    
		return info;
	}

	@Override
	public CommonProcResultInfo callPrOcsApplyPlanOrderGroup(String hospCode, String bunho, Double fkinp1001,
			Double fkocs6010, Date planDate, String inputGubun, String orderGubun, String groupSer, String userId) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_APPLY_PLAN_ORDER_GROUP");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS6010", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PLAN_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GROUP_SER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);         		
	    query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_FKINP1001", fkinp1001);
	    query.setParameter("I_FKOCS6010", fkocs6010);
	    query.setParameter("I_PLAN_DATE", planDate);
	    query.setParameter("I_INPUT_GUBUN", inputGubun);
	    query.setParameter("I_ORDER_GUBUN", orderGubun);
	    query.setParameter("I_GROUP_SER", groupSer);
	    query.setParameter("I_USER_ID", userId);
	    
	    query.execute();
	    
	    String ioMsg = (String)query.getOutputParameterValue("IO_MSG");
	    String ioFlag = (String)query.getOutputParameterValue("IO_FLAG");
	    
	    CommonProcResultInfo info = new CommonProcResultInfo();
	    info.setStrResult1(ioMsg == null ? "" : ioMsg);
	    info.setStrResult2(ioFlag == null ? "" : ioFlag);
	    
	    return info;
	}

	@Override
	public String callPrOcsPrnCancelProc(String hospCode, double pkocs2003) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_PRN_CANCEL_PROC");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS2003", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.INOUT);  
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_PKOCS2003", pkocs2003);
		
	    query.execute();
	    String oFlag = (String)query.getOutputParameterValue("O_FLAG");
	    
		return oFlag == null ? "" : oFlag;
	}

	@Override
	public CommonProcResultInfo callPrOcsCreatePlanJaewonil(String hospCode, Double fkocs6010, Date planOrderDate,
			String userId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_CREATE_PLAN_JAEWONIL");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKOCS6010", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PLAN_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_JAEWONIL", Integer.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_FKOCS6010", fkocs6010);
	    query.setParameter("I_PLAN_ORDER_DATE", planOrderDate);
	    query.setParameter("I_USER_ID", userId);
		
	    if(!query.execute()){
	    	return null;
	    }
	    
	    Integer jaewonil = (Integer)query.getOutputParameterValue("IO_JAEWONIL");
	    String ioFlag = (String)query.getOutputParameterValue("IO_FLAG");
	    
	    CommonProcResultInfo info = new CommonProcResultInfo();
	    info.setStrResult1(jaewonil == null ? "" : String.valueOf(jaewonil));
	    info.setStrResult2(ioFlag == null ? "" : ioFlag);
	    
		return info;
	}

	@Override
	public List<OCS6010U10frmARActingOCS2005Info> getOCS6010U10frmARActingOCS2005Info(String hospCode, Double fkocs2005,
			Date orderDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  B.HANGMOG_CODE 								                                    ");
		sql.append("	      , B.SURYANG									                                    ");
		sql.append("	      , IFNULL(B.BOM_YN, '')															");
		sql.append("	      , B.BOM_SOURCE_KEY							                                    ");
		sql.append("	      , C.HANGMOG_NAME								                                    ");
		sql.append("	      , B.FKOCS2005									                                    ");
		sql.append("	      , A.ORDER_DATE								                                    ");
		sql.append("	      , A.DRT_FROM_DATE								                                    ");
		sql.append("	      , A.DRT_TO_DATE								                                    ");
		sql.append("	FROM OCS2005 A										                                    ");
		sql.append("	JOIN OCS2006 B ON B.HOSP_CODE = A.HOSP_CODE			                                    ");
		sql.append("	              AND B.FKOCS2005 = A.PKOCS2005			                                    ");
		sql.append("	JOIN OCS0103 C ON C.HOSP_CODE     = B.HOSP_CODE		                                    ");
		sql.append("	              AND C.HANGMOG_CODE  = B.HANGMOG_CODE	                                    ");
		sql.append("	WHERE A.HOSP_CODE      = :f_hosp_code				                                    ");
		sql.append("	 AND A.PKOCS2005      = :f_fkocs2005				                                    ");
		sql.append("	 AND :f_order_date BETWEEN C.START_DATE 			                                    ");
		sql.append("	                       AND IFNULL(C.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2005", fkocs2005);
		query.setParameter("f_order_date", orderDate);
		
		List<OCS6010U10frmARActingOCS2005Info> lstResult = new JpaResultMapper().list(query, OCS6010U10frmARActingOCS2005Info.class);
		return lstResult;
	}

	@Override
	public List<OCS6010U10frmARActinggrdOCS2015Info> getOCS6010U10frmARActinggrdOCS2015Info(String hospCode,
			String bunho, double fkinp1001, double fkocs2005, String limit7, String kijunDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BUNHO      ,                                                                                                     ");
		sql.append("	       A.FKINP1001  ,                                                                                                     ");
		sql.append("	       A.ORDER_DATE ,                                                                                                     ");
		sql.append("	       A.INPUT_GUBUN,                                                                                                     ");
		sql.append("	       A.INPUT_ID   ,                                                                                                     ");
		sql.append("	       A.PK_SEQ     ,                                                                                                     ");
		sql.append("	       A.SEQ        ,                                                                                                     ");
		sql.append("	       A.PKOCS2015  ,                                                                                                     ");
		sql.append("	       A.ACT_DATE   ,                                                                                                     ");
		sql.append("	       IFNULL(A.ACT_ID, '')       ACT_ID    ,                                                                             ");
		sql.append("	       A.DV         ,                                                                                                     ");
		sql.append("	       A.CHANGE_QTY ,                                                                                                     ");
		sql.append("	       A.FIO2       ,                                                                                                     ");
		sql.append("	       A.SURYANG    ,                                                                                                     ");
		sql.append("	       IFNULL(A.START_TIME, '')   START_TIME,                                                                             ");
		sql.append("	       A.END_DATE   ,						                                                                              ");
		sql.append("	       IFNULL(A.END_TIME, '')     END_TIME  ,                                                                             ");
		sql.append("	       IFNULL(B.USER_NM, '')      USER_NM   ,                                                                             ");
		sql.append("	       IFNULL(A.INPUT_GWA, '')    INPUT_GWA ,                                                                             ");
		sql.append("	       IFNULL(A.INPUT_DOCTOR, '') INPUT_DOCTOR                                                                            ");
		sql.append("	FROM OCS2015 A										                                                                      ");
		sql.append("	LEFT JOIN ADM3200 B ON B.HOSP_CODE  = A.HOSP_CODE	                                                                      ");
		sql.append("	                   AND B.USER_ID    = A.ACT_ID		                                                                      ");
		sql.append("	WHERE A.HOSP_CODE  = :f_hosp_code					                                                                      ");
		sql.append("	 AND A.BUNHO       = :f_bunho	                                                                                          ");
		sql.append("	 AND A.FKINP1001   = :f_fkinp1001                                                                                         ");
		sql.append("	 AND A.FKOCS2005   = :f_fkocs2005                                                                                         ");
		sql.append("	 AND (  (:f_limit7 = 'N')							                                                                      ");
		sql.append("	     OR (:f_limit7 = 'Y' AND A.ACT_DATE    > DATE_ADD(STR_TO_DATE(:f_kijun_date, '%Y/%m/%d'),INTERVAL - 7 DAY))			  ");
		sql.append("	     OR (A.END_DATE IS NULL OR A.END_TIME IS NULL)	                                                                      ");
		sql.append("	     )												                                                                      ");
		sql.append("	ORDER BY A.ACT_DATE, A.START_TIME, A.END_DATE, A.END_TIME                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_fkocs2005", fkocs2005);
		query.setParameter("f_limit7", limit7);
		query.setParameter("f_kijun_date", kijunDate);
		
		List<OCS6010U10frmARActinggrdOCS2015Info> lstResult = new JpaResultMapper().list(query, OCS6010U10frmARActinggrdOCS2015Info.class);
		return lstResult;
	}

	@Override
	public List<OCS6010U10frmARActinggrdOCS2016Info> getOCS6010U10frmARActinggrdOCS2016Info(String hospCode,
			double fkocs2015) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.FKOCS2015                                  ,");
		sql.append("	       A.PKOCS2016                                  ,");
		sql.append("	       A.SEQ                                        ,");
		sql.append("	       A.HANGMOG_CODE                               ,");
		sql.append("	       A.SURYANG                                    ,");
		sql.append("	       A.NALSU                                      ,");
		sql.append("	       IFNULL(A.ORD_DANUI, '')      ORD_DANUI		,");
		sql.append("	       IFNULL(A.BOGYONG_CODE, '')   BOGYONG_CODE    ,");
		sql.append("	       IFNULL(A.JUSA_CODE, '')      JUSA_CODE       ,");
		sql.append("	       IFNULL(A.JUSA_SPD_GUBUN, '') JUSA_SPD_GUBUN  ,");
		sql.append("	       A.DV             							,");
		sql.append("	       IFNULL(A.DV_TIME, '')        DV_TIME			,");
		sql.append("	       A.BOM_SOURCE_KEY								,");
		sql.append("	       IFNULL(A.BOM_YN, '')         BOM_YN  		,");
		sql.append("	       B.HANGMOG_NAME   							 ");
		sql.append("	FROM OCS2016  A										 ");
		sql.append("	JOIN OCS0103  B ON A.HOSP_CODE    = B.HOSP_CODE		 ");
		sql.append("	               AND A.HANGMOG_CODE = B.HANGMOG_CODE	 ");
		sql.append("	WHERE A.HOSP_CODE    = :f_hosp_code 				 ");
		sql.append("	  AND A.FKOCS2015    = :f_fkocs2015					 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2015", fkocs2015);
		
		List<OCS6010U10frmARActinggrdOCS2016Info> lstResult = new JpaResultMapper().list(query, OCS6010U10frmARActinggrdOCS2016Info.class);
		return lstResult;
	}

	@Override
	public List<OCS6010U10PopupMAgrdOCS2016Info> getOCS6010U10PopupMAgrdOCS2016Info(String hospCode,
			double fkocs2015) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.FKOCS2015                                  ,");
		sql.append("	       A.PKOCS2016                                  ,");
		sql.append("	       A.SEQ                                        ,");
		sql.append("	       A.HANGMOG_CODE                               ,");
		sql.append("	       A.SURYANG                                    ,");
		sql.append("	       A.NALSU                                      ,");
		sql.append("	       IFNULL(A.ORD_DANUI, '')      ORD_DANUI		,");
		sql.append("	       IFNULL(A.BOGYONG_CODE, '')   BOGYONG_CODE    ,");
		sql.append("	       IFNULL(A.JUSA_CODE, '')      JUSA_CODE       ,");
		sql.append("	       IFNULL(A.JUSA_SPD_GUBUN, '') JUSA_SPD_GUBUN  ,");
		sql.append("	       A.DV             							,");
		sql.append("	       IFNULL(A.DV_TIME, '')        DV_TIME			,");
		sql.append("	       A.BOM_SOURCE_KEY								,");
		sql.append("	       IFNULL(A.BOM_YN, '')         BOM_YN  		,");
		sql.append("	       B.HANGMOG_NAME   							,");
		sql.append("	       A.FKOCS2003									 ");
		sql.append("	FROM OCS2016  A										 ");
		sql.append("	JOIN OCS0103  B ON A.HOSP_CODE    = B.HOSP_CODE		 ");
		sql.append("	               AND A.HANGMOG_CODE = B.HANGMOG_CODE	 ");
		sql.append("	WHERE A.HOSP_CODE    = :f_hosp_code 				 ");
		sql.append("	  AND A.FKOCS2015    = :f_fkocs2015					 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2015", fkocs2015);
		
		List<OCS6010U10PopupMAgrdOCS2016Info> lstResult = new JpaResultMapper().list(query, OCS6010U10PopupMAgrdOCS2016Info.class);
		return lstResult;
	}

	@Override
	public String getOCS6010U10PopupMPDGetCheckModifyPlandate(String hospCode, double fkocs6010, String modifyDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CASE SIGN(DATEDIFF(STR_TO_DATE(:f_modify_date,'%Y/%m/%d'), APP_DATE)) WHEN -1 THEN 'N' ELSE 'Y' END	");
		sql.append("	FROM OCS6010																								");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code																				");
		sql.append("	AND PKOCS6010 = :f_fkocs6010																				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs6010", fkocs6010);
		query.setParameter("f_modify_date", modifyDate);
		
		List<String> listStr = query.getResultList();
		return CollectionUtils.isEmpty(listStr) ? "" : listStr.get(0);
	}

	@Override
	public CommonProcResultInfo callPrOcsDirectActOrder(String hospCode, String bunho, Double fkinp1001, Date orderDate,
			String inputGubun, Double pkocs2015, Date actingDate, String userId) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DIRECT_ACT_ORDER");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS2015", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_FKINP1001", fkinp1001);
	    query.setParameter("I_ORDER_DATE", orderDate);
	    query.setParameter("I_INPUT_GUBUN", inputGubun);
	    query.setParameter("I_PKOCS2015", pkocs2015);
	    query.setParameter("I_ACTING_DATE", actingDate);
	    query.setParameter("I_USER_ID", userId);
	    
	    query.execute();
	    
	    String msg = (String)query.getOutputParameterValue("IO_MSG");
	    String flag = (String)query.getOutputParameterValue("IO_FLAG");
	    
	    CommonProcResultInfo info = new CommonProcResultInfo();
	    info.setStrResult1(msg == null ? "" : msg);
	    info.setStrResult2(flag == null ? "" : flag); 
	    return info;
	}

	@Override
	public CommonProcResultInfo callPrOcsDirectActAr(String hospCode, String bunho, Double fkinp1001, Date orderDate,
			String inputGubun, Double pkseq, Date actingDate, Double seq, String fromTime, String toTime, String userId,
			Double pkocs2015) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DIRECT_ACT_AR");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKSEQ", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SEQ", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS2015", Double.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_FKINP1001", fkinp1001);
	    query.setParameter("I_ORDER_DATE", orderDate);
	    query.setParameter("I_INPUT_GUBUN", inputGubun);
	    query.setParameter("I_PKSEQ", pkseq);
	    query.setParameter("I_ACTING_DATE", actingDate);
	    query.setParameter("I_SEQ", seq);
	    query.setParameter("I_FROM_TIME", fromTime);
	    query.setParameter("I_TO_TIME", toTime);
	    query.setParameter("I_USER_ID", userId);
	    query.setParameter("I_PKOCS2015", pkocs2015);
	    
	    query.execute();
	    
	    String msg = (String)query.getOutputParameterValue("IO_MSG");
	    String flag = (String)query.getOutputParameterValue("IO_FLAG");
	    
	    CommonProcResultInfo info = new CommonProcResultInfo();
	    info.setStrResult1(msg == null ? "" : msg);
	    info.setStrResult2(flag == null ? "" : flag); 
	    return info;
	}

	@Override
	public CommonProcResultInfo callPrOcsDirectActingO2(String hospCode, String bunho, double fkinp1001, Date orderDate,
			String inputGubun, double pkseq, Date actingDate, double seq, String fromTime, String toTime, String userId,
			double suryang, double pkocs2015) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DIRECT_ACTING_O2");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKSEQ", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SEQ", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SURYANG", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS2015", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_FKINP1001", fkinp1001);
	    query.setParameter("I_ORDER_DATE", orderDate);
	    query.setParameter("I_INPUT_GUBUN", inputGubun);
	    query.setParameter("I_PKSEQ", pkseq);
	    query.setParameter("I_ACTING_DATE", actingDate);
	    query.setParameter("I_SEQ", seq);
	    query.setParameter("I_FROM_TIME", fromTime);
	    query.setParameter("I_TO_TIME", toTime);
	    query.setParameter("I_USER_ID", userId);
	    query.setParameter("I_SURYANG", suryang);
	    query.setParameter("I_PKOCS2015", pkocs2015);
	    
	    query.execute();
	    String msg = (String)query.getOutputParameterValue("IO_MSG");
	    String flag = (String)query.getOutputParameterValue("IO_FLAG");
	    
	    CommonProcResultInfo info = new CommonProcResultInfo();
	    info.setStrResult1(msg == null ? "" : msg);
	    info.setStrResult2(flag == null ? "" : flag); 
	    return info;
	}

	@Override
	public CommonProcResultInfo callPrOcsDirectActMoniter(String hospCode, String bunho, double fkinp1001,
			Date orderDate, String inputGubun, double pkseq, Date actingDate, double seq, String fromTime,
			String toTime, String userId, double pkocs2015) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DIRECT_ACT_MONITER");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_INPUT_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKSEQ", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SEQ", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS2015", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_MSG", String.class, ParameterMode.INOUT);           	
	    query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_FKINP1001", fkinp1001);
	    query.setParameter("I_ORDER_DATE", orderDate);
	    query.setParameter("I_INPUT_GUBUN", inputGubun);
	    query.setParameter("I_PKSEQ", pkseq);
	    query.setParameter("I_ACTING_DATE", actingDate);
	    query.setParameter("I_SEQ", seq);
	    query.setParameter("I_FROM_TIME", fromTime);
	    query.setParameter("I_TO_TIME", toTime);
	    query.setParameter("I_USER_ID", userId);
	    query.setParameter("I_PKOCS2015", pkocs2015);
	    
	    query.execute();
	    String msg = (String)query.getOutputParameterValue("IO_MSG");
	    String flag = (String)query.getOutputParameterValue("IO_FLAG");
	    
	    CommonProcResultInfo info = new CommonProcResultInfo();
	    info.setStrResult1(msg == null ? "" : msg);
	    info.setStrResult2(flag == null ? "" : flag); 
	    return info;
	}
	
}


