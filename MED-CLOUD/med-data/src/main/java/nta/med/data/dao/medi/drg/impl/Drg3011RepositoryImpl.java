package nta.med.data.dao.medi.drg.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.drg.Drg3011RepositoryCustom;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint4Info;
import nta.med.data.model.ihis.drgs.DRG3010P99OrdPrnSerialInfo;

/**
 * @author dainguyen.
 */
public class Drg3011RepositoryImpl implements Drg3011RepositoryCustom {
private static final Log LOG = LogFactory.getLog(Drg3011RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<DRG3010P99OrdPrnSerialInfo> getDRG3010P99OrdPrnSerialInfo(String hospCode, String language, Double drgBunho, String serialText, String jubsuDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT DISTINCT																																	");
		sql.append("              A.BUNHO                                                                                 BUNHO												");
		sql.append("             ,CAST(A.DRG_BUNHO AS CHAR)                                                               DRG_BUNHO											");
		sql.append("             ,CAST(A.GROUP_SER AS CHAR)                                                               GROUP_SER											");
		sql.append("             ,DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d')                                                    JUBSU_DATE										");
		sql.append("             ,DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                                    ORDER_DATE										");
		sql.append("             ,A.JAERYO_CODE                                                                           JAERYO_CODE										");
		sql.append("             ,CAST(A.NALSU * CASE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)) WHEN 'Y' THEN A.DIVIDE ELSE 1 END AS CHAR)  NALSU					");
		sql.append("             ,A.DIVIDE                                                                                DIVIDE											");
		sql.append("             ,CAST(A.ORD_SURYANG AS CHAR)                                                             ORD_SURYANG										");
		sql.append("             ,CAST(CASE(A.BUNRYU1) WHEN '4' THEN A.ORD_SURYANG ELSE A.ORDER_SURYANG END AS CHAR)      ORDER_SURYANG										");
		sql.append("             ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, A.HOSP_CODE, :f_language)               ORDER_DANUI										");
		sql.append("             ,A.SUBUL_DANUI                                                                           SUBUL_DANUI										");
		sql.append("             ,A.BOGYONG_CODE                                                                          BOGYONG_CODE										");
		sql.append("             ,CONCAT(TRIM(B.BOGYONG_NAME), FN_DRG_LOAD_RP_TEXT('I', E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, A.HOSP_CODE),								");
		sql.append("               CASE(IFNULL(G.DV_1,0) + IFNULL(G.DV_2,0) + IFNULL(G.DV_3,0) + IFNULL(G.DV_4,0) + IFNULL(G.DV_5,0)) 										");
		sql.append("               WHEN 0 THEN '' ELSE CONCAT('(', LTRIM(CAST(IFNULL(G.DV_1,0) AS CHAR)), '-', LTRIM(CAST(IFNULL(G.DV_2,0) AS CHAR)), '-',					");
		sql.append("                   LTRIM(CAST(IFNULL(G.DV_3,0) AS CHAR)), '-', LTRIM(CAST(IFNULL(G.DV_4,0) AS CHAR)), '-',												");
		sql.append("                   LTRIM(CAST(IFNULL(G.DV_5,0) AS CHAR)), ')' ) END )                                 BOGYONG_NAME										");
		sql.append("             ,SUBSTR(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O', '1', A.HOSP_CODE, :f_language ),1,80)   CAUTION_NAME			");
		sql.append("             ,IFNULL(A.MIX_YN, '')                                                                    MIX_YN											");
		sql.append("             ,IFNULL(A.ATC_YN, '')                                                                    ATC_YN											");
		sql.append("             ,CAST(D.DV AS CHAR)                                                                      DV												");
		sql.append("             ,A.DV_TIME                                                                               DV_TIME											");
		sql.append("             ,IFNULL(D.DC_YN,'')                                                                      DC_YN												");
		sql.append("             ,IFNULL(D.BANNAB_YN,'')                                                                  BANNAB_YN											");
		sql.append("             ,D.SOURCE_FKOCS2003                                                                      SOURCE_FKOCS2003									");
		sql.append("             ,A.FKOCS2003                                                                             FKOCS2003											");
		sql.append("             ,DATE_FORMAT(CURRENT_DATE(),'%Y/%m/%d')                                                  SUNAB_DATE										");
		sql.append("             ,B.PATTERN                                                                               PATTERN											");
		sql.append("             ,F.HANGMOG_NAME                                                                          JAERYO_NAME										");
		sql.append("             ,'0'                                                                                     SUNAB_NALSU										");
		sql.append("             ,CASE(D.WONYOI_ORDER_YN) WHEN '' THEN 'N' ELSE IFNULL(D.WONYOI_ORDER_YN,'N')  END        WONYOI_YN											");
		sql.append("             ,IFNULL(CONCAT(F.HANGMOG_NAME, ' : ', TRIM(D.ORDER_REMARK)), '')                         ORDER_REMARK										");
		sql.append("             ,DATE_FORMAT(CURRENT_DATE(),'%Y/%m/%d')                                                  ACT_DATE											");
		sql.append("             ,CASE(C.MIX_YN_INP) WHEN '' THEN 'N' ELSE IFNULL(C.MIX_YN_INP, 'N') END                  UI_JUSA_YN										");
		sql.append("             ,CAST(A.SUBUL_SURYANG AS CHAR)                                                           SUBUL_SURYANG										");
		sql.append("             ,CONCAT('Rp.',LTRIM(LPAD(E.SERIAL_V, 2, '0')), CASE IFNULL(G.MIX_GROUP, '') WHEN '' THEN '' ELSE ' M' END)     SERIAL_V					");
		sql.append("             ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.JUBSU_DATE, A.HOSP_CODE, :f_language)                     GWA_NAME											");
		sql.append("             ,IFNULL(FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.JUBSU_DATE, A.HOSP_CODE),'')                 DOCTOR_NAME										");
		sql.append("             ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA, A.HOSP_CODE)                OTHER_GWA											");
		sql.append("             ,IFNULL(FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE, A.HOSP_CODE, :f_language),'')     HOPE_DATE											");
		sql.append("             ,G.POWDER_YN                                                                             POWDER_YN											");
		sql.append("             ,IFNULL(E.SERIAL_V, 1)                                                                   LINE												");
		sql.append("             ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, A.HOSP_CODE, :f_language)             ORD_DANUI2										");
		sql.append("             ,SUBSTR(TRIM(A.BUNRYU1),1,1)                                                             BUNRYU1											");
		sql.append("             ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'D'),1,20),'') HO_DONG								");
		sql.append("             ,IFNULL(SUBSTR(FN_DRG_HO_DONG(A.HOSP_CODE, :f_language, A.FKINP1001, CURRENT_DATE(), 'C'),1,20),'') HO_CODE								");
		sql.append("             ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, A.HOSP_CODE)                                      DONBOK											");
		sql.append("             ,''                                                                                      TUSUK												");
		sql.append("             ,CASE(G.TOIWON_DRG_YN) WHEN '1' THEN 'OT' ELSE G.MAGAM_GUBUN END                         MAGAM_GUBUN										");
		sql.append("             ,IFNULL(C.TEXT_COLOR, '')                                                                TEXT_COLOR										");
		sql.append("             ,IFNULL(C.CHANGGO1, '')                                                                  CHANGGO											");
		sql.append("             ,CONCAT('( ', DATE_FORMAT(CASE IFNULL(D.HOPE_DATE, '') 																					");
		sql.append("                    WHEN '' THEN D.ORDER_DATE ELSE D.HOPE_DATE END,'%m/%d'))                          FROM_ORDER_DATE									");
		sql.append("             ,CONCAT(DATE_FORMAT(DATE_ADD(CASE IFNULL(D.HOPE_DATE, '')																					");
		sql.append("                    WHEN '' THEN D.ORDER_DATE ELSE D.HOPE_DATE END, INTERVAL A.NALSU - 1 DAY), '%m/%d'), ' )')   TO_ORDER_DATE							");
		sql.append("             ,'A'                                                                                     DATA_GUBUN										");
		sql.append("             ,CASE(IFNULL(C.ACT_JAERYO_NAME, '')) WHEN '' THEN F.HANGMOG_NAME ELSE C.ACT_JAERYO_NAME END           HODONG_ORD_NAME						");
		sql.append("             ,(SELECT MAX(CASE(X.BANNAB_YN) WHEN '' THEN 'N' ELSE IFNULL(X.BANNAB_YN, 'N') END)															");
		sql.append("                 FROM DRG3010 X																															");
		sql.append("                 JOIN DRG3011 W																															");
		sql.append("                   ON W.HOSP_CODE        = X.HOSP_CODE																									");
		sql.append("                  AND W.JUBSU_DATE       = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																		");
		sql.append("                  AND W.DRG_BUNHO        = :f_drg_bunho																									");
		sql.append("                 JOIN DRG2035 Z																															");
		sql.append("                   ON Z.HOSP_CODE        = W.HOSP_CODE																									");
		sql.append("                  AND Z.JUBSU_DATE       = W.JUBSU_DATE																									");
		sql.append("                  AND Z.DRG_BUNHO        = W.DRG_BUNHO																									");
		sql.append("                  AND Z.FKOCS2003        = W.FKOCS2003																									");
		sql.append("                  AND Z.SERIAL_V         = :f_serial_text																								");
		sql.append("                 JOIN DRG2035 Y																															");
		sql.append("                   ON Y.HOSP_CODE        = X.HOSP_CODE																									");
		sql.append("                 AND Y.JUBSU_DATE        = Z.JUBSU_DATE																									");
		sql.append("                 AND Y.DRG_BUNHO         = Z.DRG_BUNHO																									");
		sql.append("                  AND Y.FKOCS2003        = X.FKOCS2003																									");
		sql.append("                 AND Y.SERIAL_V          = Z.SERIAL_V																									");
		sql.append("                WHERE X.HOSP_CODE        = :f_hosp_code																									");
		sql.append("                  )                                                     MAX_BANNAB_YN																	");
		sql.append("         FROM DRG3011 A																																	");
		sql.append("      LEFT JOIN DRG0120 B																																");
		sql.append("           ON B.HOSP_CODE        = A.HOSP_CODE																											");
		sql.append("          AND B.BOGYONG_CODE     = A.BOGYONG_CODE																										");
		sql.append("         JOIN INV0110 C																																	");
		sql.append("           ON C.HOSP_CODE        = A.HOSP_CODE																											");
		sql.append("          AND C.JAERYO_CODE      = A.JAERYO_CODE																										");
		sql.append("         JOIN OCS2003 D																																	");
		sql.append("           ON D.HOSP_CODE        = A.HOSP_CODE																											");
		sql.append("          AND D.PKOCS2003        = A.FKOCS2003																											");
		sql.append("         JOIN DRG2035 E																																	");
		sql.append("           ON E.HOSP_CODE        = A.HOSP_CODE																											");
		sql.append("          AND E.JUBSU_DATE       = A.JUBSU_DATE																											");
		sql.append("          AND E.DRG_BUNHO        = A.DRG_BUNHO																											");
		sql.append("          AND E.FKOCS2003        = A.FKOCS2003																											");
		sql.append("          AND E.SERIAL_V         = :f_serial_text																										");
		sql.append("         JOIN OCS0103 F																																	");
		sql.append("           ON F.HOSP_CODE        = D.HOSP_CODE																											");
		sql.append("          AND F.HANGMOG_CODE     = D.HANGMOG_CODE																										");
		sql.append("         JOIN DRG3010 G																																	");
		sql.append("           ON G.HOSP_CODE        = A.HOSP_CODE																											");
		sql.append("          AND G.FKOCS2003        = A.FKOCS2003																											");
		sql.append("        WHERE A.HOSP_CODE        = :f_hosp_code																											");
		sql.append("         AND A.JUBSU_DATE       = STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																				");
		sql.append("         AND A.DRG_BUNHO        = :f_drg_bunho																											");
		sql.append("        ORDER BY A.DRG_BUNHO,																															");
		sql.append("          CONCAT('Rp.',LTRIM(LPAD(E.SERIAL_V, 2, '0')), CASE IFNULL(G.MIX_GROUP, '') WHEN '' THEN '' ELSE ' M' END),									");
		sql.append("          A.FKOCS2003																																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_serial_text", serialText);
		
		List<DRG3010P99OrdPrnSerialInfo> listInfo = new JpaResultMapper().list(query, DRG3010P99OrdPrnSerialInfo.class);
		return listInfo;
	}

	@Override
	public List<DRG3010P10DsvOrderPrint4Info> getDRG3010P10DsvOrderPrint4Info(String hospCode, String language, String jubsuDate, String drgBunho, String serialText) {
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT																																							");
		sql.append("       DISTINCT A.BUNHO                                                                                                                     BUNHO,					");
		sql.append("       A.DRG_BUNHO                                                                                                                          DRG_BUNHO,				");
		sql.append("       A.GROUP_SER                                                                                                                          GROUP_SER,				");
		sql.append("       DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d')                                                                                                 JUBSU_DATE,				");
		sql.append("       DATE_FORMAT(G.HOPE_DATE,'%Y/%m/%d')                                                                                                  HOPE_DATE,				");
		sql.append("       DATE_FORMAT(A.ORDER_DATE,'%Y/%m/%d')                                                                                                 ORDER_DATE,				");
		sql.append("       A.JAERYO_CODE                                                                                                                        JAERYO_CODE,			");
		sql.append("       A.NALSU * CASE FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code) WHEN 'Y' THEN A.DIVIDE ELSE 1 END                                 NALSU,					");
		sql.append("       A.DIVIDE                                                                                                                             DIVIDE,					");
		sql.append("       A.ORD_SURYANG                                                                                                                        ORD_SURYANG,			");
		sql.append("       CASE A.BUNRYU1 WHEN '4' THEN A.ORD_SURYANG ELSE A.ORDER_SURYANG END                                                                  ORDER_SURYANG,			");
		sql.append("       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI, :f_hosp_code, :f_language)                                                           ORDER_DANUI,			");
		sql.append("       A.SUBUL_DANUI                                                                                                                        SUBUL_DANUI,			");
		sql.append("       A.BOGYONG_CODE                                                                                                                       BOGYONG_CODE,			");
		sql.append("       CONCAT(																																						");
		sql.append("     		TRIM(B.BOGYONG_NAME),																																	");
		sql.append("     		CASE (	IFNULL(G.DV_1,0) + IFNULL(G.DV_2,0) + IFNULL(G.DV_3,0) + 																						");
		sql.append("            		IFNULL(G.DV_4,0) + IFNULL(G.DV_5,0))																											");
		sql.append("     			WHEN 0																																				");
		sql.append("     			THEN ''																																				");
		sql.append("     			ELSE																																				");
		sql.append("     			 	CONCAT(																																			");
		sql.append("     					'(',																																		");
		sql.append("     					LTRIM(CAST(IFNULL(G.DV_1, 0) AS CHAR)),																										");
		sql.append("            			'-',																																		");
		sql.append("     					LTRIM(CAST(IFNULL(G.DV_2, 0) AS CHAR)),																										");
		sql.append("     					'-',																																		");
		sql.append("        				LTRIM(CAST(IFNULL(G.DV_3, 0) AS CHAR)),																										");
		sql.append("     					'-',																																		");
		sql.append("     					LTRIM(CAST(IFNULL(G.DV_4, 0) AS CHAR)),																										");
		sql.append("     					'-',																																		");
		sql.append("        				LTRIM(CAST(IFNULL(G.DV_5, 0) AS CHAR)),																										");
		sql.append("     					')'																																			");
		sql.append("     				)																																				");
		sql.append("     		END																																						");
		sql.append("     	)                                                  																					BOGYONG_NAME,			");
		sql.append("       SUBSTRING(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O', '1', :f_hosp_code, :f_language) , 1, 80)     			CAUTION_NAME,			");
		sql.append("       IFNULL(A.MIX_YN,'')                                                                                                                  MIX_YN,					");
		sql.append("       IFNULL(A.ATC_YN,'')                                                                                                                  ATC_YN,					");
		sql.append("       D.DV                                                                                                                                 DV,						");
		sql.append("       A.DV_TIME                                                                                                                            DV_TIME,				");
		sql.append("       IFNULL(D.DC_YN,'')                                                                                                                   DC_YN,					");
		sql.append("       IFNULL(D.BANNAB_YN,'')                                                                                                               BANNAB_YN,				");
		sql.append("       D.SOURCE_FKOCS2003                                                                                                                   SOURCE_FKOCS2003,		");
		sql.append("       A.FKOCS2003                                                                                                                          FKOCS2003,				");
		sql.append("       DATE_FORMAT(SWF_TruncDate(CURRENT_TIMESTAMP,'DD'),'%Y/%m/%d')                                                                        SUNAB_DATE,				");
		sql.append("       B.PATTERN                                                                                                                            PATTERN,				");
		sql.append("       F.HANGMOG_NAME                                                                                                                       JAERYO_NAME,			");
		sql.append("       0                                                                                                                                    SUNAB_NALSU,			");
		sql.append("       IFNULL(D.WONYOI_ORDER_YN, 'N')                                                                                                       WONYOI_YN,				");
		sql.append("       CONCAT(F.HANGMOG_NAME, ' : ', TRIM(D.ORDER_REMARK))                                                                                  ORDER_REMARK,			");
		sql.append("       DATE_FORMAT(SWF_TruncDate(CURRENT_TIMESTAMP,'DD'),'%Y/%m/%d')                                                                        ACT_DATE,				");
		sql.append("       IFNULL(C.MIX_YN_INP, 'N')                                                                                                            UI_JUSA_YN,				");
		sql.append("       A.SUBUL_SURYANG                                                                                                                      SUBUL_SURYANG,			");
		sql.append("       CONCAT('Rp.', LTRIM(LPAD(E.SERIAL_V, 2, '0')), CASE G.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END)    									SERIAL_V,				");
		sql.append("       FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_language)                                                                 GWA_NAME,				");
		sql.append("       FN_OCS_LOAD_ORDER_DOCTOR_NAME(:f_hosp_code, A.FKOCS2003)                                                                             DOCTOR_NAME,			");
		sql.append("       FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA, :f_hosp_code)                                                            OTHER_GWA,				");
		sql.append("       FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE, :f_hosp_code, :f_language)                                                            HOPE_DATE_2,			");
		sql.append("       G.POWDER_YN                                        										                                            POWDER_YN,				");
		sql.append("       IFNULL(E.SERIAL_V, 1)                                                                                                                LINE,					");
		sql.append("       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI, :f_hosp_code, :f_language)                                                         ORD_DANUI2,				");
		sql.append("       SUBSTRING(TRIM(A.BUNRYU1), 1, 1)                                                                                                     BUNRYU1,				");
		sql.append("       SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TruncDate(CURRENT_TIMESTAMP,'DD'), 'C'), 1, 20)               	HO_CODE,				");
		sql.append("       SUBSTRING(FN_DRG_HO_DONG(:f_hosp_code, :f_language, A.FKINP1001, SWF_TruncDate(CURRENT_TIMESTAMP,'DD'), 'D'), 1, 20)                 HO_DONG,				");
		sql.append("       FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code)                                                                                  DONBOK,					");
		sql.append("       ''                                                                                                                                   TUSUK,					");
		sql.append("       CASE G.TOIWON_DRG_YN WHEN '1' THEN 'OT' ELSE G.MAGAM_GUBUN END                                                                       MAGAM_GUBUN,			");
		sql.append("       IFNULL(C.TEXT_COLOR,'')                                                                                                              TEXT_COLOR,				");
		sql.append("       IFNULL(C.CHANGGO1,'')                                                                                                                CHANGGO,				");
		sql.append("       CONCAT('( ', DATE_FORMAT(G.HOPE_DATE, '%m/%d'))                                                  									FROM_ORDER_DATE,		");
		sql.append("       CONCAT(DATE_FORMAT(DATE_ADD(G.HOPE_DATE, INTERVAL A.NALSU - 1 DAY), '%m/%d'), ' )')                                   				TO_ORDER_DATE,			");
		sql.append("       'B'                                                                                    												DATA_GUBUN,				");
		sql.append("       IFNULL(C.ACT_JAERYO_NAME, F.HANGMOG_NAME)                                                  											HODONG_ORD_NAME,		");
		sql.append("       (																																							");
		sql.append("     		SELECT																																					");
		sql.append("     			MAX(IFNULL(X.BANNAB_YN,'N'))																														");
		sql.append("         	FROM																																					");
		sql.append("     			DRG3010 X JOIN DRG2035 Y																															");
		sql.append("     				ON X.HOSP_CODE  	= Y.HOSP_CODE																												");
		sql.append("             		AND Y.FKOCS2003  	= X.FKOCS2003																												");
		sql.append("         	WHERE																																					");
		sql.append("     			Y.HOSP_CODE  			= :f_hosp_code 																												");
		sql.append("                AND Y.JUBSU_DATE 		= E.JUBSU_DATE																												");
		sql.append("                AND Y.DRG_BUNHO  		= E.DRG_BUNHO																												");
		sql.append("                AND Y.SERIAL_V   		= E.SERIAL_V																												");
		sql.append("                AND Y.FKOCS2003  		= E.FKOCS2003																												");
		sql.append("     	)                                                     MAX_BANNAB_YN																							");
		sql.append("       FROM																																							");
		sql.append("         	DRG3011 A JOIN OCS2003 D																																");
		sql.append("           		ON D.HOSP_CODE        	= A.HOSP_CODE																												");
		sql.append("                AND D.PKOCS2003        	= A.FKOCS2003																												");
		sql.append("                JOIN DRG2035 E																																		");
		sql.append("                ON E.HOSP_CODE        	= A.HOSP_CODE																												");
		sql.append("                AND E.JUBSU_DATE       	= A.JUBSU_DATE																												");
		sql.append("                AND E.DRG_BUNHO        	= A.DRG_BUNHO																												");
		sql.append("                AND E.FKOCS2003        	= A.FKOCS2003																												");
		sql.append("                JOIN OCS0103 F																																		");
		sql.append("                ON F.HOSP_CODE        	= D.HOSP_CODE																												");
		sql.append("                AND F.HANGMOG_CODE     	= D.HANGMOG_CODE																											");
		sql.append("                JOIN DRG3010 G																																		");
		sql.append("                ON G.HOSP_CODE        	= A.HOSP_CODE																												");
		sql.append("                AND G.FKOCS2003        	= A.FKOCS2003																												");
		sql.append("                LEFT JOIN DRG0120 B																																	");
		sql.append("                ON B.HOSP_CODE     		= A.HOSP_CODE																												");
		sql.append("                AND B.BOGYONG_CODE  	= A.BOGYONG_CODE																											");
		sql.append("                LEFT JOIN INV0110 C																																	");
		sql.append("                ON C.HOSP_CODE     		= A.HOSP_CODE																												");
		sql.append("                AND C.JAERYO_CODE   	= A.JAERYO_CODE																												");
		sql.append("      WHERE																																							");
		sql.append("      	A.HOSP_CODE        				= :f_hosp_code																												");
		sql.append("        AND A.JUBSU_DATE       			= STR_TO_DATE(:f_jubsu_date, '%Y/%m/%d')																					");
		sql.append("        AND A.DRG_BUNHO        			= :f_drg_bunho																												");
		sql.append("        AND TRIM(D.ORDER_REMARK) 		IS NOT NULL																													");
		sql.append("        AND E.SERIAL_V         			= :f_serial_text																											");
		sql.append("        AND D.ORDER_DATE       			BETWEEN   F.START_DATE AND IFNULL(F.END_DATE, '9998/12/31')																	");
		sql.append("      ORDER BY																																						");
		sql.append("      	A.DRG_BUNHO, CONCAT('Rp.', LTRIM(LPAD(E.SERIAL_V, 2, '0'))), CASE G.MIX_GROUP WHEN NULL THEN '' ELSE ' M' END, A.FKOCS2003																																											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_drg_bunho", drgBunho);
		query.setParameter("f_serial_text", serialText);
		
		List<DRG3010P10DsvOrderPrint4Info> listInfo = new JpaResultMapper().list(query, DRG3010P10DsvOrderPrint4Info.class);
		return listInfo;
	}
}

