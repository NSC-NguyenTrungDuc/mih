package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.collections.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1010RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1010Q00fnLoadIlsuInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00layPatientInfo;
import nta.med.data.model.ihis.nuri.NUR1010U00grdNur1010Info;

/**
 * @author dainguyen.
 */
public class Nur1010RepositoryImpl implements Nur1010RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getNUR6011U01GetNurseInfoUser(String hospCode, Double fkinp1001, String jukyongDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT B.USER_NM                                                                                  ");
		sql.append("    FROM ADM3200 B                                                                                   ");
		sql.append("    JOIN NUR1010 A                                                                                   ");
		sql.append("      ON B.HOSP_CODE     = A.HOSP_CODE                                                               ");
		sql.append("     AND B.USER_ID       = A.DAMDANG_NURSE                                                           ");
		sql.append("   WHERE A.HOSP_CODE     = :f_hosp_code                                                              ");
		sql.append("     AND A.FKINP1001     = :f_fkinp1001                                                              ");
		sql.append("     AND A.JUKYONG_DATE  = ( SELECT MAX(C.JUKYONG_DATE)                                              ");
		sql.append("                               FROM NUR1010 C                                                        ");
		sql.append("                              WHERE C.HOSP_CODE = A.HOSP_CODE                                        ");
		sql.append("                                AND C.FKINP1001 = A.FKINP1001                                        ");
		sql.append("                                AND C.JUKYONG_DATE <= STR_TO_DATE(:f_jukyong_date, '%Y/%m/%d'))      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_jukyong_date", jukyongDate);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public List<NUR1010Q00layPatientInfo> getNUR1010Q00layPatientInfo(String hospCode, String language, String hoDong){
		StringBuilder sql = new StringBuilder();
		
		sql.append("    SELECT IFNULL(A.IPWON_RESER, 'B')                                IPWON_RESER                                                    ");
		sql.append("          , B.HO_CODE                                                HO_CODE                                                        ");
		sql.append("          , IFNULL(A.BUNHO, '')                                      BUNHO                                                          ");
		sql.append("          , IFNULL(A.SUNAME, '')                                     SUNAME                                                         ");
		sql.append("          , IFNULL(A.SUNAME2, '')                                    SUNAME2                                                        ");
		sql.append("          , IFNULL(A.SEX, '')                                        SEX                                                            ");
		sql.append("          , IFNULL(A.PKINP1001, 0 )                                  PKINP1001                                                      ");
		sql.append("          , B.BED_NO                                                 BED_NO                                                         ");
		sql.append("          , IFNULL(A.TEAM, '')                                       TEAM                                                           ");
		sql.append("          , CASE(IFNULL(FN_INP_LOAD_JOHAP_GUBUN(B.HOSP_CODE, A.GUBUN), '')) WHEN '9' THEN ''                                        ");
		sql.append("                 ELSE IFNULL(FN_INP_LOAD_JOHAP_GUBUN(B.HOSP_CODE, A.GUBUN), '') END JOHAP_GUBUN                                     ");
		sql.append("          , IFNULL(A.ORDER_STATUS, '')                               ORDER_STATUS                                                   ");
		sql.append("          , IFNULL(DATE_FORMAT(A.BIRTH, '%Y/%m/%d'), '')             BIRTH                                                          ");
		sql.append("          , IFNULL(A.SEX_AGE, '')                                    SEX_AGE                                                        ");
		sql.append("          , IFNULL(DATE_FORMAT(A.IPWON_DATE,'%Y/%m/%d'), '')         IPWON_DATE                                                     ");
		sql.append("          , CAST(IFNULL(A.JAEWON_NALSU, 0) AS CHAR)                  JAEWON_NALSU                                                   ");
		sql.append("          , IFNULL(A.GWA_NAME, '')                                   GWA_NAME                                                       ");
		sql.append("          , IFNULL(A.DOCTOR_NAME, '')                                DOCTOR_NAME                                                    ");
		sql.append("          , IFNULL(A.RESIDENT_NAME, '')                              RESIDENT_NAME                                                  ");
		sql.append("          , IFNULL(A.DAMDANG_NURSE, '')                              DAMDANG_NURSE                                                  ");
		sql.append("          , IFNULL(A.GANHODO, '')                                    GANHODO                                                        ");
		sql.append("          , IFNULL(A.LIFE_SELF_GRADE, '')                            LIFE_SELF_GRADE                                                ");
		sql.append("          , IFNULL(A.GUHO_GUBUN, '')                                 GUHO_GUBUN                                                     ");
		sql.append("          , IFNULL(A.OUT_SLEEP_YN, '')                               OUT_SLEEP_YN                                                   ");
		sql.append("          , IFNULL(A.TOIWON_RES_DATE, '')                            TOIWON_RES_DATE                                                ");
		sql.append("          , IFNULL(DATE_FORMAT(A.TOIWON_RES_TIME,'%Y/%m/%d'), '')    TOIWON_RES_TIME                                                ");
		sql.append("          , IFNULL(A.DOCTOR, '')                                     DOCTOR                                                         ");
		sql.append("          , IFNULL(A.GWA, '')                                        GWA                                                            ");
		sql.append("          , ''                                                       BUNMAN_YN                                                      ");
		sql.append("          , IFNULL(A.IPWON_RESER_INFO, '')                           IPWON_RESER_INFO                                               ");
		sql.append("          , IFNULL(A.IPWON_MOKJUK, '')                               IPWON_MOKJUK                                                   ");
		sql.append("          , CASE   WHEN IPWON_RESER = 'I'                                                                                           ");
		sql.append("                   THEN (CASE(A.TOIWON_RES_TIME) WHEN NULL THEN '02'                                                                ");
		sql.append("                                                ELSE '03' END)                                                                      ");
		sql.append("                   WHEN IPWON_RESER = 'R'                                                                                           ");
		sql.append("                   THEN (CASE(B.BED_STATUS) WHEN '04' THEN '04'                                                                     ");
		sql.append("                                                ELSE '01' END)                                                                      ");
		sql.append("                   ELSE B.BED_STATUS                                                                                                ");
		sql.append("          END                                                        BED_STATUS                                                     ");
		sql.append("          , IFNULL(A.IS_OUT,'')                                      IS_OUT                                                         ");
		sql.append("          , FN_INP_LOAD_PATIENT_INFO(B.HOSP_CODE, A.BUNHO, SYSDATE()) SECRET_YN                                                     ");
		sql.append("          , IFNULL(A.TOIWON_GOJI_YN, '')                             TOIWON_GOJI_YN                                                 ");
		sql.append("          , IFNULL(B.BED_LOCK_TEXT, '')                              BED_LOCK_TEXT                                                  ");
		sql.append("          , FN_NUR_LOAD_CONTINUE_JISI(C.HOSP_CODE, IFNULL(A.PKINP1001, 0), A.BUNHO, '4')                      INGONG_YN             ");
		sql.append("          , FN_NUR_LOAD_CONTINUE_JISI(C.HOSP_CODE, IFNULL(A.PKINP1001, 0), A.BUNHO, '3')                      STATUS_FLAG1          ");
		sql.append("          , CASE(FN_NUR_LOAD_CONTINUE_JISI(C.HOSP_CODE, IFNULL(A.PKINP1001, 0), A.BUNHO, '3')) WHEN 'N' THEN NULL ELSE '酸素' END   ");
		sql.append("                                                                     STATUS_FLAG1_NAME                                              ");
		sql.append("          , FN_NUR_LOAD_CONTINUE_JISI(C.HOSP_CODE, IFNULL(A.PKINP1001, 0), A.BUNHO, '9')                      STATUS_FLAG2          ");
		sql.append("          , CASE(FN_NUR_LOAD_CONTINUE_JISI(C.HOSP_CODE, IFNULL(A.PKINP1001, 0), A.BUNHO, '9')) WHEN 'N' THEN NULL ELSE '心電図' END ");
		sql.append("                                                                     STATUS_FLAG2_NAME                                              ");
		sql.append("          , A.STATUS_FLAG3                                    STATUS_FLAG3                                                          ");
		sql.append("          , CASE(IFNULL(A.STATUS_FLAG3, 'N')) WHEN 'N' THEN '' ELSE FN_NUR_LOAD_MANAGE_NAME(B.HOSP_CODE, '0022') END                ");
		sql.append("                                                                     STATUS_FLAG3_NAME                                              ");
		sql.append("          , A.STATUS_FLAG4                                    STATUS_FLAG4                                                          ");
		sql.append("          , CASE(IFNULL(A.STATUS_FLAG4, 'N')) WHEN 'N' THEN '' ELSE FN_NUR_LOAD_MANAGE_NAME(B.HOSP_CODE, '0023') END                ");
		sql.append("                                                                     STATUS_FLAG4_NAME                                              ");
		sql.append("          , A.STATUS_FLAG5                                    STATUS_FLAG5                                                          ");
		sql.append("          , CASE(IFNULL(A.STATUS_FLAG5, 'N')) WHEN 'N' THEN '' ELSE FN_NUR_LOAD_MANAGE_NAME(B.HOSP_CODE, '0024') END                ");
		sql.append("                                                                     STATUS_FLAG5_NAME                                              ");
		sql.append("          , ''                                                 CP_YN                                                                ");
		sql.append("          , FN_OCS_LOAD_JU_SANG_NAME(B.HOSP_CODE,A.BUNHO, A.PKINP1001)                           SANG_NAME                          ");
		sql.append("          , ''                                                       CODE                                                           ");
		sql.append("          , A.GWA_COLOR                                              GWA_COLOR                                                      ");
		sql.append("          , A.BEDSORE_YN                                             BEDSORE_YN                                                     ");
		sql.append("          , A.FALLING_YN                                             FALLING_YN                                                     ");
		sql.append("          , CASE(A.GAMYUM_NAME) WHEN '' THEN 'N' ELSE 'Y' END        GAMYUM_YN                                                      ");
		sql.append("          ,  A.GAMYUM_NAME                                           GAMYUM_NAME                                                    ");
		sql.append("          , A.IPWON_TODAY                                            IPWON_TODAY                                                    ");
		sql.append("          , A.KAIKEI_HODONG                                          KAIKEI_HODONG                                                  ");
		sql.append("          , A.KAIKEI_HOCODE                                          KAIKEI_HOCODE                                                  ");
		sql.append("          , DATE_FORMAT(A.NOT_YET_DRG_DATE, '%Y/%m/%d')              NOT_YET_DRG_DATE                                               ");
		sql.append("     FROM BAS0250 C                                                                                                                 ");
		sql.append("     JOIN BAS0253 B                                                                                                                 ");
		sql.append("       ON B.HOSP_CODE    = C.HOSP_CODE                                                                                              ");
		sql.append("      AND B.HO_DONG      = C.HO_DONG                                                                                                ");
		sql.append("      AND B.HO_CODE      = C.HO_CODE                                                                                                ");
		sql.append("      AND SYSDATE() BETWEEN B.FROM_BED_DATE AND IFNULL(B.TO_BED_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))                        ");
		sql.append("  LEFT JOIN                                                                                                                         ");
		sql.append("     (                                                                                                                              ");
		sql.append("            /*入院者*/                                                                                                              ");
		sql.append("        SELECT  A.HOSP_CODE                                                HOSP_CODE                                                ");
		sql.append("              , 'I'                                                         IPWON_RESER                                             ");
		sql.append("              , A.HO_CODE1                                                 HO_CODE1                                                 ");
		sql.append("              , A.BUNHO                                                    BUNHO                                                    ");
		sql.append("              , B.SUNAME                                                   SUNAME                                                   ");
		sql.append("              , B.SUNAME2                                                  SUNAME2                                                  ");
		sql.append("              , B.SEX                                                      SEX                                                      ");
		sql.append("              , A.PKINP1001                                                PKINP1001                                                ");
		sql.append("              , A.BED_NO                                                   BED_NO                                                   ");
		sql.append("              , A.TEAM                                                         TEAM                                                 ");
		sql.append("              , ''                                                        GUBUN                                                     ");
		sql.append("              , FN_OCSI_ORDER_STATUS_CHECK (A.HOSP_CODE, A.BUNHO, A.PKINP1001, CASE                                                 ");
		sql.append("                      WHEN DATE_FORMAT(SYSDATE(), '%H%i') > '1800'                                                                  ");
		sql.append("                      THEN DATE_ADD(CURRENT_DATE(), INTERVAL 1 DAY)                                                                 ");
		sql.append("                      ELSE CURRENT_DATE()                                                                                           ");
		sql.append("              END )                                             ORDER_STATUS                                                        ");
		sql.append("              , B.BIRTH                                                    BIRTH                                                    ");
		sql.append("              , CONCAT(B.SEX,'/',FN_BAS_LOAD_AGE(SYSDATE(), B.BIRTH, ''))     SEX_AGE                                               ");
		sql.append("              , A.IPWON_DATE                                               IPWON_DATE                                               ");
		sql.append("              , DATEDIFF(SYSDATE(), A.IPWON_DATE) + 1                   JAEWON_NALSU                                                ");
		sql.append("              , FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), A.HOSP_CODE, :f_language)                 GWA_NAME                           ");
		sql.append("              , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE(), A.HOSP_CODE)           DOCTOR_NAME                                     ");
		sql.append("              , FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, SYSDATE(), A.HOSP_CODE)         RESIDENT_NAME                                   ");
		sql.append("              , FN_NUR_LOAD_DAMDANG_NURSE(A.HOSP_CODE, A.PKINP1001, SYSDATE())      DAMDANG_NURSE                                   ");
		sql.append("              , FN_NUR_LOAD_GANHODO(A.HOSP_CODE, A.PKINP1001, SYSDATE())            GANHODO                                         ");
		sql.append("              , FN_NUR_LOAD_LIFESELFGRADE(A.HOSP_CODE, A.PKINP1001, SYSDATE() )     LIFE_SELF_GRADE                                 ");
		sql.append("              , FN_NUR_LOAD_GUHO_GUBUN(A.HOSP_CODE, A.PKINP1001, SYSDATE())         GUHO_GUBUN                                      ");
		sql.append("              , FN_NUR_LOAD_MANAGE_STATUS(A.HOSP_CODE, A.PKINP1001, SYSDATE(), '0022') STATUS_FLAG3                                 ");
		sql.append("              , FN_NUR_LOAD_MANAGE_STATUS(A.HOSP_CODE, A.PKINP1001, SYSDATE(), '0023') STATUS_FLAG4                                 ");
		sql.append("              , FN_NUR_LOAD_MANAGE_STATUS(A.HOSP_CODE, A.PKINP1001, SYSDATE(), '0024') STATUS_FLAG5                                 ");
		sql.append("              , FN_NUR_LOAD_OUT_SLEEP_YN(A.HOSP_CODE, A.PKINP1001, SYSDATE())       OUT_SLEEP_YN                                    ");
		sql.append("              , DATE_FORMAT(A.TOIWON_RES_DATE, '%Y/%m/%d')                                   TOIWON_RES_DATE                        ");
		sql.append("              , A.TOIWON_RES_TIME                                          TOIWON_RES_TIME                                          ");
		sql.append("              , A.DOCTOR                                                   DOCTOR                                                   ");
		sql.append("              , A.GWA                                                      GWA                                                      ");
		sql.append("              , ''                                                          BUNMAN_YN                                               ");
		sql.append("              , FN_INP_LOAD_RESER_INFO(A.HOSP_CODE,A.HO_DONG1, A.HO_CODE1, A.BED_NO)   IPWON_RESER_INFO                             ");
		sql.append("              , FN_BAS_LOAD_CODE_NAME('IPWON_MOKJUK', D.IPWON_MOKJUK,A.HOSP_CODE, :f_language)       IPWON_MOKJUK                   ");
		sql.append("              , A.TOIWON_GOJI_YN                                           TOIWON_GOJI_YN                                           ");
		sql.append("              , E.GWA_COLOR                                                GWA_COLOR                                                ");
		sql.append("              , FN_NUR_BEDSORE_CHECK(A.HOSP_CODE, A.PKINP1001, SYSDATE()) BEDSORE_YN                                                ");
		sql.append("              , FN_NUR_FALLING_CHECK(A.HOSP_CODE, A.PKINP1001, SYSDATE()) FALLING_YN                                                ");
		sql.append("              , FN_NUR_GAMYUM_NAME_CONCAT(A.HOSP_CODE, A.BUNHO, SYSDATE()) GAMYUM_NAME                                              ");
		sql.append("              , FN_IPWON_TODAY(A.HOSP_CODE, A.PKINP1001)                    IPWON_TODAY                                             ");
		sql.append("              , A.KAIKEI_HODONG                                             KAIKEI_HODONG                                           ");
		sql.append("              , A.KAIKEI_HOCODE                                             KAIKEI_HOCODE                                           ");
		sql.append("              , FN_NUR_IS_WOICHUL(A.HOSP_CODE, A.PKINP1001, DATE_FORMAT(SYSDATE(), '%Y%m%d%H%i'))        IS_OUT                     ");
		sql.append("              , FN_OCS_NOT_YET_DRG(A.HOSP_CODE, A.BUNHO, SYSDATE())          NOT_YET_DRG_DATE                                       ");
		sql.append("         FROM INP1001 A                                                                                                             ");
		sql.append("         JOIN OUT0101 B                                                                                                             ");
		sql.append("           ON B.HOSP_CODE          = A.HOSP_CODE                                                                                    ");
		sql.append("          AND B.BUNHO              = A.BUNHO                                                                                        ");
		sql.append("     LEFT JOIN NUR1001 C                                                                                                            ");
		sql.append("           ON C.HOSP_CODE          = A.HOSP_CODE                                                                                    ");
		sql.append("          AND C.FKINP1001          = A.PKINP1001                                                                                    ");
		sql.append("     LEFT JOIN INP1003 D                                                                                                            ");
		sql.append("           ON D.HOSP_CODE          = A.HOSP_CODE                                                                                    ");
		sql.append("          AND D.RESER_FKINP1001    = A.PKINP1001                                                                                    ");
		sql.append("          AND D.HO_DONG            = A.HO_DONG1                                                                                     ");
		sql.append("          AND D.HO_CODE            = A.HO_CODE1                                                                                     ");
		sql.append("          AND D.BED_NO             = A.BED_NO                                                                                       ");
		sql.append("         JOIN BAS0260 E                                                                                                             ");
		sql.append("           ON E.HOSP_CODE          = A.HOSP_CODE                                                                                    ");
		sql.append("          AND E.GWA                = A.GWA                                                                                          ");
		sql.append("          AND E.BUSEO_GUBUN        = '1'                                                                                            ");
		sql.append("        WHERE A.HOSP_CODE          = :f_hosp_code                                                                                   ");
		sql.append("          AND A.IPWON_DATE         BETWEEN E.START_DATE AND E.END_DATE                                                              ");
		sql.append("          AND A.IPWON_DATE         <= SYSDATE()                                                                                     ");
		sql.append("          AND A.HO_DONG1           = :f_ho_dong                                                                                     ");
		sql.append("          AND A.JAEWON_FLAG        = 'Y'                                                                                            ");
		sql.append("          AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN, 'N') END = 'N'                                            ");
		sql.append("          AND A.IPWON_TYPE IN ('0', '2')                                                                                            ");
		sql.append("          AND CASE(A.TOIWON_CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN,'N') END = 'N'                                      ");
		sql.append("                                                                                                                                    ");
		sql.append("     UNION ALL /*入院予約者*/                                                                                                        ");
		sql.append("            SELECT   A.HOSP_CODE                                                    HOSP_CODE                                       ");
		sql.append("                   , 'R'                                                            IPWON_RESER                                     ");
		sql.append("                   , A.HO_CODE                                                      HO_CODE                                         ");
		sql.append("                   , A.BUNHO                                                        BUNHO                                           ");
		sql.append("                   , B.SUNAME                                                       SUNAME                                          ");
		sql.append("                   , B.SUNAME2                                                      SUNAME2                                         ");
		sql.append("                   , B.SEX                                                          SEX                                             ");
		sql.append("                   , 0                                                              PKINP1001                                       ");
		sql.append("                   , A.BED_NO                                                       BED_NO                                          ");
		sql.append("                   , FN_NUR_LOAD_HO_TEAM(A.HOSP_CODE, A.HO_DONG, A.HO_CODE, NULL)   TEAM                                            ");
		sql.append("                   , ''                                                             GUBUN                                           ");
		sql.append("                   , ''                                                             ORDER_STATUS                                    ");
		sql.append("                   , B.BIRTH                                                        BIRTH                                           ");
		sql.append("                   , CONCAT(B.SEX,'/',FN_BAS_LOAD_AGE(SYSDATE(), B.BIRTH, '') )       SEX_AGE                                       ");
		sql.append("                   , A.RESER_DATE                                                   IPWON_DATE                                      ");
		sql.append("                   , 0                                                              JAEWON_NALSU                                    ");
		sql.append("                   , FN_BAS_LOAD_GWA_NAME(A.GWA, SYSDATE(), A.HOSP_CODE, :f_language)  GWA_NAME                                     ");
		sql.append("                   , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE(), A.HOSP_CODE)      DOCTOR_NAME                                     ");
		sql.append("                   , FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, SYSDATE(), A.HOSP_CODE)     RESIDENT_NAME                                  ");
		sql.append("                   , ''                                                             DAMDANG_NURSE                                   ");
		sql.append("                   , ''                                                             GANHODO                                         ");
		sql.append("                   , ''                                                             LIFE_SELF_GRADE                                 ");
		sql.append("                   , ''                                                             GUHO_GUBUN                                      ");
		sql.append("                   , ''                                                             STATUS_FLAG3                                    ");
		sql.append("                   , ''                                                             STATUS_FLAG4                                    ");
		sql.append("                   , ''                                                             STATUS_FLAG5                                    ");
		sql.append("                   , ''                                                             OUT_SLEEP_YN                                    ");
		sql.append("                   , ''                                                            TOIWON_RES_DATE                                  ");
		sql.append("                   , ''                                                             TOIWON_RES_TIME                                 ");
		sql.append("                   , A.DOCTOR                                                       DOCTOR                                          ");
		sql.append("                   , A.GWA                                                          GWA                                             ");
		sql.append("                   , ''                                                              BUNMAN_YN                                      ");
		sql.append("                   , FN_INP_LOAD_RESER_INFO(A.HOSP_CODE,A.HO_DONG, A.HO_CODE, A.BED_NO)         IPWON_RESER_INFO                    ");
		sql.append("                   , FN_BAS_LOAD_CODE_NAME('IPWON_MOKJUK', A.IPWON_MOKJUK,A.HOSP_CODE, :f_language) IPWON_MOKJUK                    ");
		sql.append("                   , ''                                                             TOIWON_GOJI_YN                                  ");
		sql.append("                   , ''                                                              GWA_COLOR                                      ");
		sql.append("                   , ''                                                              BEDSORE_YN                                     ");
		sql.append("                   , ''                                                              FALLING_YN                                     ");
		sql.append("                   , FN_NUR_GAMYUM_NAME_CONCAT(A.HOSP_CODE, A.BUNHO, SYSDATE())      GAMYUM_NAME                                    ");
		sql.append("                   , 'N'                                                             IPWON_TODAY                                    ");
		sql.append("                   , ''                                                              KAIKEI_HODONG                                  ");
		sql.append("                   , ''                                                              KAIKEI_HOCODE                                  ");
		sql.append("                   , 'N'                                                             IS_OUT                                         ");
		sql.append("                   , ''                                                            NOT_YET_DRG_DATE                                 ");
		sql.append("              FROM INP1003 A                                                                                                        ");
		sql.append("              JOIN OUT0101 B                                                                                                        ");
		sql.append("                ON B.HOSP_CODE      = A.HOSP_CODE                                                                                   ");
		sql.append("               AND B.BUNHO          = A.BUNHO                                                                                       ");
		sql.append("             WHERE A.HOSP_CODE      = :f_hosp_code                                                                                  ");
		sql.append("               AND A.HO_DONG        = :f_ho_dong                                                                                    ");
		sql.append("               AND A.RESER_DATE    >= SYSDATE()                                                                                     ");
		sql.append("               AND A.RESER_END_TYPE = '0'                                                                                           ");
		sql.append("               AND A.RESER_DATE     =                                                                                               ");
		sql.append("                   ( SELECT MIN(X.RESER_DATE)                                                                                       ");
		sql.append("                      FROM INP1003 X                                                                                                ");
		sql.append("                     WHERE X.HOSP_CODE   = A.HOSP_CODE                                                                              ");
		sql.append("                       AND X.HO_DONG     = A.HO_DONG                                                                                ");
		sql.append("                       AND X.HO_CODE     = A.HO_CODE                                                                                ");
		sql.append("                       AND X.BED_NO      = A.BED_NO                                                                                 ");
		sql.append("                       AND X.RESER_DATE >= SYSDATE()                                                                                ");
		sql.append("                   )                                                                                                                ");
		sql.append("               AND NOT EXISTS                                                                                                       ");
		sql.append("                   ( SELECT 'X'                                                                                                     ");
		sql.append("                      FROM VW_OCS_INP1001_01 X                                                                                      ");
		sql.append("                      ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                               ");
		sql.append("                     WHERE X.HOSP_CODE             = A.HOSP_CODE                                                                    ");
		sql.append("                       AND X.HO_DONG1              = A.HO_DONG                                                                      ");
		sql.append("                       AND X.HO_CODE1              = A.HO_CODE                                                                      ");
		sql.append("                       AND X.BED_NO                = A.BED_NO                                                                       ");
		sql.append("                       AND CASE(X.JAEWON_FLAG) WHEN '' THEN 'Y' ELSE IFNULL(X.JAEWON_FLAG, 'Y') END = 'Y'                           ");
		sql.append("                       AND CASE(X.CANCEL_YN) WHEN '' THEN 'Y' ELSE IFNULL(X.CANCEL_YN, 'N') END   = 'N'                             ");
		sql.append("                   )                                                                                                                ");
		sql.append("          ) A                                                                                                                       ");
		sql.append("       ON A.HO_CODE1     = B.HO_CODE                                                                                                ");
		sql.append("      AND A.BED_NO       = B.BED_NO                                                                                                 ");
		sql.append("    WHERE C.HOSP_CODE    = :f_hosp_code                                                                                             ");
		sql.append("      AND C.HO_DONG      = :f_ho_dong                                                                                               ");
		sql.append("      AND SYSDATE() BETWEEN C.START_DATE AND C.END_DATE                                                                             ");
		sql.append(" ORDER BY B.HO_CODE, B.BED_NO, A.BUNHO                                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUR1010Q00layPatientInfo> listInfo = new JpaResultMapper().list(query, NUR1010Q00layPatientInfo.class);
		return listInfo;		
	}
	
	@Override
	public List<NUR1010Q00fnLoadIlsuInfo> getNUR1010Q00fnLoadIlsuInfo(String hospCode, String hoDong){
		StringBuilder sql = new StringBuilder();
		
		sql.append("   SELECT CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '01', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          IPWON_TODAY            ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '01', :f_ho_dong,                           ");
		sql.append("               CURRENT_DATE),0)AS CHAR)                                        IPWON_NEXTDAY          ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '03', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          IPWON_NEXTNEXTDAY      ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '04', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          IN_TODAY               ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '05', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          IN_NEXTDAY             ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '06', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          IN_NEXTNEXTDAY         ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '07', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          TOIWON_TODAY           ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '08', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          TOIWON_NEXTDAY         ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '09', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          TOIWON_NEXTNEXTDAY     ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '10', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          OUT_TODAY              ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '11', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          OUT_NEXTDAY            ");
		sql.append("        , CAST(IFNULL(FN_INPS_LOAD_ILSU_ETC(:f_hosp_code, '12', :f_ho_dong,                           ");
		sql.append("               DATE_ADD(CURRENT_DATE(), INTERVAL -1 DAY)),0) AS CHAR)          OUT_NEXTNEXTDAY        ");
		sql.append("    FROM DUAL                                                                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		
		List<NUR1010Q00fnLoadIlsuInfo> listInfo = new JpaResultMapper().list(query, NUR1010Q00fnLoadIlsuInfo.class);
		return listInfo;		
	}
	
	@Override
	public List<NUR1010U00grdNur1010Info> getNUR1010U00grdNur1010Info(String hospCode, Double fkinp1001, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.BUNHO                             BUNHO,                        ");
		sql.append("          A.FKINP1001                         FKINP1001,                    ");
		sql.append("          A.DAMDANG_NURSE                     DAMDANG_NURSE,                ");
		sql.append("          B.USER_NM                           DAMDANG_NURSE_NAME,           ");
		sql.append("          DATE_FORMAT(A.JUKYONG_DATE, '%Y/%m/%d') JUKYONG_DATE,             ");
		sql.append("          '' DATA_ROW_STATE									                ");
		sql.append("     FROM NUR1010 A                                                         ");
		sql.append("     JOIN ADM3200 B                                                         ");
		sql.append("       ON B.HOSP_CODE      = A.HOSP_CODE                                    ");
		sql.append("      AND B.USER_GUBUN     = '2'                                            ");
		sql.append("      AND B.USER_ID        = A.DAMDANG_NURSE                                ");
		sql.append("      AND (B.USER_END_YMD  IS NULL OR B.USER_END_YMD >= SYSDATE())          ");
		sql.append("    WHERE A.HOSP_CODE      = :f_hosp_code                                   ");
		sql.append("      AND A.FKINP1001      = :f_fkinp1001                                   ");
		sql.append("    ORDER BY A.JUKYONG_DATE DESC                                            ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset											");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1010U00grdNur1010Info> listInfo = new JpaResultMapper().list(query, NUR1010U00grdNur1010Info.class);
		return listInfo;		
	}
	
	@Override
	public String getNUR1010U00grdNurCheck(String hospCode, String bunho, Double fkinp1001, String jukyongDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                              ");
		sql.append("     FROM NUR1010 A                                                        ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                   ");
		sql.append("      AND A.BUNHO         = :f_bunho                                       ");
		sql.append("      AND A.FKINP1001     = :f_fkinp1001                                   ");
		sql.append("      AND A.JUKYONG_DATE  = STR_TO_DATE(:f_jukyong_date, '%Y/%m/%d')       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_jukyong_date", jukyongDate);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
	
	@Override
	public String getNUR1010U00LoadUserName(String hospCode, String userId){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT FN_ADM_LOAD_USER_NAME(:f_user_id, :f_hosp_code) FROM DUAL    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
	
	@Override
	public String getNUR1001U00BasicQuery1(String hospCode, String jukyongDate, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CONCAT(FN_ADM_LOAD_USER_NM(A.HOSP_CODE, A.DAMDANG_NURSE, A.JUKYONG_DATE),'[',A.DAMDANG_NURSE,']') DAMDANG_NURSE  ");
		sql.append("     FROM NUR1010 A                                                                                                        ");
		sql.append("    WHERE A.HOSP_CODE    = :f_hosp_code                                                                                    ");
		sql.append("      AND A.FKINP1001    = :f_fkinp1001                                                                                    ");
		sql.append("      AND A.JUKYONG_DATE = (SELECT MAX(B.JUKYONG_DATE)                                                                     ");
		sql.append("                              FROM NUR1010 B                                                                               ");
		sql.append("                             WHERE B.HOSP_CODE = A.HOSP_CODE                                                               ");
		sql.append("                               AND B.FKINP1001 = A.FKINP1001                                                               ");
		sql.append("                               AND B.JUKYONG_DATE <= STR_TO_DATE(:f_jukyong_date,'%Y/%m/%d'))                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jukyong_date", jukyongDate);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			return result.get(0);
		}
		return "";
	}
}

