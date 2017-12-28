package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur6012RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR6011U01PrintSetgrdPrintInfo;
import nta.med.data.model.ihis.nuri.NUR6011U01grdNur6012Info;
import nta.med.data.model.ihis.nuri.NUR6011U01layCalendarInfo;

/**
 * @author dainguyen.
 */
public class Nur6012RepositoryImpl implements Nur6012RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR6011U01grdNur6012Info> getNUR6011U01grdNur6012Info(String hospCode, String bunho, String fromDate, String bedsoreBuwi, String assessorDate,
						Integer startNum, Integer offset, boolean isCopy){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.BUNHO                                                                                                      BUNHO                       ");
		sql.append("        , DATE_FORMAT(A.FROM_DATE,'%Y/%m/%d')                                                                          FROM_DATE                   ");
		sql.append("        , A.BEDSORE_BUWI                                                                                               BEDSORE_BUWI                ");
		sql.append("        , DATE_FORMAT(A.ASSESSOR_DATE,'%Y/%m/%d')                                                                      ASSESSOR_DATE               ");
		sql.append("        , A.ASSESSOR                                                                                                   ASSESSOR                    ");
		sql.append("        , IFNULL(A.BEDSORE_DEEP,'')                                                                                    BEDSORE_DEEP                ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_DEPTH AS CHAR),'')                                                                     BEDSORE_DEPTH               ");
		sql.append("        , IFNULL(A.BEDSORE_COLOR,'')                                                                                   BEDSORE_COLOR               ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_SIZE1 AS CHAR),'')                                                                     BEDSORE_SIZE1               ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_SIZE_START1 AS CHAR),'')                                                               BEDSORE_SIZE_START1         ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_SIZE_FINISH1 AS CHAR),'')                                                              BEDSORE_SIZE_FINISH1        ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_POKET1 AS CHAR),'')                                                                    BEDSORE_POKET1              ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_POKET_START1 AS CHAR),'')                                                              BEDSORE_POKET_START1        ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_POKET_FINISH1 AS CHAR),'')                                                             BEDSORE_POKET_FINISH1       ");
		sql.append("        , IFNULL(A.BEDSORE_DEATH,'')                                                                                   BEDSORE_DEATH               ");
		sql.append("        , IFNULL(A.EXUDATION_VOLUME,'')                                                                                EXUDATION_VOLUME            ");
		sql.append("        , IFNULL(A.EXUDATION_STATE,'')                                                                                 EXUDATION_STATE             ");
		sql.append("        , IFNULL(A.EXUDATION_COLOR,'')                                                                                 EXUDATION_COLOR             ");
		sql.append("        , IFNULL(A.EXUDATION_SMELL,'')                                                                                 EXUDATION_SMELL             ");
		sql.append("        , IFNULL(A.BEDSORE_SKIN,'')                                                                                    BEDSORE_SKIN                ");
		sql.append("        , IFNULL(A.BEDSORE_INFE,'')                                                                                    BEDSORE_INFE                ");
		sql.append("        , IFNULL(A.BEDSORE_MOIST,'')                                                                                   BEDSORE_MOIST               ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_MOIST_RATE AS CHAR),'')                                                                BEDSORE_MOIST_RATE          ");
		sql.append("        , IFNULL(A.BEDSORE_GITA,'')                                                                                    BEDSORE_GITA                ");
		sql.append("        , IFNULL(A.BEDSORE_NUT,'')                                                                                     BEDSORE_NUT                 ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_HB AS CHAR),'')                                                                        BEDSORE_HB                  ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_ALB AS CHAR),'')                                                                       BEDSORE_ALB                 ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_FBS AS CHAR),'')                                                                       BEDSORE_FBS                 ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_ZN AS CHAR),'')                                                                        BEDSORE_ZN                  ");
		sql.append("        , IFNULL(DATE_FORMAT(FN_ADM_LOAD_USER_NM(A.HOSP_CODE, A.ASSESSOR, ASSESSOR_DATE), '%Y/%m/%d'),'')              ASSESSOR_ASSESSOR_DATE      ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_SIZE2 AS CHAR),'')                                                                     BEDSORE_SIZE2               ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_SIZE_START2 AS CHAR),'')                                                               BEDSORE_SIZE_START2         ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_SIZE_FINISH2 AS CHAR),'')                                                              BEDSORE_SIZE_FINISH2        ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_POKET2 AS CHAR),'')                                                                    BEDSORE_POKET2              ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_POKET_START2 AS CHAR),'')                                                              BEDSORE_POKET_START2        ");
		sql.append("        , IFNULL(CAST(A.BEDSORE_POKET_FINISH2 AS CHAR),'')                                                             BEDSORE_POKET_FINISH2       ");
		sql.append("        , IFNULL(CAST(FN_NUR_LOAD_WEIGHT(A.HOSP_CODE, A.BUNHO,STR_TO_DATE(:f_assessor_date, '%Y/%m/%d')) AS CHAR),'')  WEIGHT                      ");
		sql.append("        , IFNULL(A.END_YN,'')                                                                                          END_YN                      ");
		sql.append("        , IFNULL(A.EXUDATION_STATE1,'')                                                                                EXUDATION_STATE1            ");
		sql.append("        , IFNULL(A.EXUDATION_STATE2,'')                                                                                EXUDATION_STATE2            ");
		sql.append("        , IFNULL(A.BEDSORE_COLOR2,'')                                                                                  BEDSORE_COLOR2              ");
		sql.append("        , IFNULL(A.BEDSORE_COLOR3,'')                                                                                  BEDSORE_COLOR3              ");
		sql.append("        , IFNULL(A.BEDSORE_COLOR4,'')                                                                                  BEDSORE_COLOR4              ");
		sql.append("        , IFNULL(A.FIRST_SAYU,'')                                                                                      FIRST_SAYU                  ");
		sql.append("        , IFNULL(A.LAST_SAYU,'')                                                                                       LAST_SAYU                   ");
		sql.append("        , IFNULL(A.YOKCHANG_DEEP,'')                                                                                   YOKCHANG_DEEP               ");
		sql.append("        , IFNULL(A.SAMCHUL_YANG,'')                                                                                    SAMCHUL_YANG                ");
		sql.append("        , IFNULL(A.YOKCHANG_SIZE,'')                                                                                   YOKCHANG_SIZE               ");
		sql.append("        , IFNULL(CAST(A.YOKCHANG_SIZE_START AS CHAR),'')                                                               YOKCHANG_SIZE_START         ");
		sql.append("        , IFNULL(CAST(A.YOKCHANG_SIZE_END AS CHAR),'')                                                                 YOKCHANG_SIZE_END           ");
		sql.append("        , IFNULL(A.YOKCHANG_GAMYUM,'')                                                                                 YOKCHANG_GAMYUM             ");
		sql.append("        , IFNULL(A.YUKAJOJIK,'')                                                                                       YUKAJOJIK                   ");
		sql.append("        , IFNULL(A.GAESAJOJIK,'')                                                                                      GAESAJOJIK                  ");
		sql.append("        , IFNULL(A.POCKET_GUBUN,'')                                                                                    POCKET_GUBUN                ");
		sql.append("        , IFNULL(CAST(A.POCKET_SIZE_START AS CHAR),'')                                                                 POCKET_SIZE_START           ");
		sql.append("        , IFNULL(CAST(A.POCKET_SIZE_END AS CHAR),'')                                                                   POCKET_SIZE_END             ");
		sql.append("        , IFNULL(A.YOKCHANG_STAGE,'')                                                                                  YOKCHANG_STAGE              ");
		sql.append("        , IFNULL(CAST(A.TOTAL_COUNT AS CHAR),'')                                                                       TOTAL_COUNT                 ");
		sql.append("        , IFNULL(A.YUNGYANG_SIKSA_GUBUN,'')                                                                            YUNGYANG_SIKSA_GUBUN        ");
		sql.append("        , IFNULL(CAST(A.YUNGYANG_SIKSA_YANG AS CHAR),'')                                                               YUNGYANG_SIKSA_YANG         ");
		sql.append("        , IFNULL(CAST(A.YUNGYANG_SIKSA_PERCENT AS CHAR),'')                                                            YUNGYANG_SIKSA_PERCENT      ");
		sql.append("        , IFNULL(A.YUNGYANG_SUAEK_YN,'')                                                                               YUNGYANG_SUAEK_YN           ");
		sql.append("        , IFNULL(CAST(A.YUNGYANG_SUAEK_YANG AS CHAR),'')                                                               YUNGYANG_SUAEK_YANG         ");
		sql.append("        , IFNULL(A.CHUCHI_TEXT,'')                                                                                     CHUCHI_TEXT                 ");
		sql.append("        , IFNULL(CAST(A.YOKCHANG_HB AS CHAR),'')                                                                       YOKCHANG_HB                 ");
		sql.append("        , IFNULL(CAST(A.YOKCHANG_ALB AS CHAR),'')                                                                      YOKCHANG_ALB                ");
		sql.append("        , IFNULL(CAST(A.YOKCHANG_TP AS CHAR),'')                                                                       YOKCHANG_TP                 ");
		sql.append("        , IFNULL(CAST(FN_NUR_LOAD_WEIGHT(A.HOSP_CODE, A.BUNHO,STR_TO_DATE(:f_assessor_date, '%Y/%m/%d')) AS CHAR),'')  YOKCHANG_WEIGHT             ");
		sql.append("        , ''                                                                                                           DATA_ROW_STATE              ");
		sql.append("     FROM NUR6012 A                                                                                                                                ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                                                                                           ");
		sql.append("      AND A.BUNHO         = :f_bunho                                                                                                               ");
		sql.append("      AND A.FROM_DATE     = STR_TO_DATE(:f_from_date, '%Y/%m/%d')                                                                                  ");
		sql.append("      AND A.BEDSORE_BUWI  LIKE :f_bedsore_buwi                                                                                                     ");
		if(!isCopy){
			sql.append("  AND A.ASSESSOR_DATE = STR_TO_DATE(:f_assessor_date, '%Y/%m/%d')                                                                              ");
		}else{
			sql.append("  AND A.ASSESSOR_DATE = (SELECT MAX(Z.ASSESSOR_DATE)                                                 										   ");
			sql.append("   						 FROM NUR6012 Z                                                                										   ");
			sql.append("   						WHERE Z.HOSP_CODE     = A.HOSP_CODE                                            										   ");
			sql.append("   						  AND Z.BUNHO         = A.BUNHO                                               									   	   ");
			sql.append("   						  AND Z.FROM_DATE     = A.FROM_DATE                                         										   ");
			sql.append("   						  AND Z.BEDSORE_BUWI  = A.BEDSORE_BUWI                                      										   ");
			sql.append("   						  AND A.ASSESSOR_DATE <  STR_TO_DATE(:f_assessor_date, '%Y/%m/%d'))         										   ");
		}
		sql.append("    ORDER BY A.BUNHO, A.FROM_DATE                                                                                                                  ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																						  							");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_bedsore_buwi", bedsoreBuwi);
		query.setParameter("f_assessor_date", assessorDate);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR6011U01grdNur6012Info> list = new JpaResultMapper().list(query, NUR6011U01grdNur6012Info.class);
		return list;
	}
	
	@Override
	public List<NUR6011U01layCalendarInfo> getNUR6011U01layCalendarInfo(String hospCode, String bunho, String fromDate, String fromMonth, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.BUNHO                                            BUNHO                                ");
		sql.append("        , DATE_FORMAT(A.FROM_DATE,'%Y/%m/%d')                FROM_DATE                            ");
		sql.append("        , A.BEDSORE_BUWI                                     BEDSORE_BUWI                         ");
		sql.append("        , DATE_FORMAT(A.ASSESSOR_DATE,'%Y/%m/%d')            ASSESSOR_DATE                        ");
		sql.append("        , A.ASSESSOR                                         ASSESSOR                             ");
		sql.append("     FROM NUR6012 A                                                                               ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                              ");
		sql.append("      AND A.BUNHO     = :f_bunho                                                                  ");
		sql.append("      AND A.FROM_DATE = STR_TO_DATE(:f_from_date, '%Y/%m/%d')                                     ");
		sql.append("      AND A.ASSESSOR_DATE BETWEEN STR_TO_DATE(CONCAT(:f_from_month,'01'),'%Y%m%d')                ");
		sql.append("                              AND LAST_DAY(STR_TO_DATE(CONCAT(:f_from_month,'01'),'%Y%m%d'))      ");
		sql.append("    ORDER BY A.ASSESSOR_DATE, A.BEDSORE_BUWI                                                      ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_from_month", fromMonth);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR6011U01layCalendarInfo> list = new JpaResultMapper().list(query, NUR6011U01layCalendarInfo.class);
		return list;
	}
	
	@Override
	public String NUR6012CheckIsExist(String hospCode, String bunho, String fromDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                                       ");
		sql.append("     FROM DUAL                                                                                      ");
		sql.append("    WHERE EXISTS ( SELECT 'X'                                                                       ");
		sql.append("                     FROM NUR6012 A                                                                 ");
		sql.append("                    WHERE A.HOSP_CODE        = :f_hosp_code                                         ");
		sql.append("                      AND A.BUNHO            = :f_bunho                                             ");
		sql.append("                      AND A.FROM_DATE        = STR_TO_DATE(:f_from_date, '%Y/%m/%d')                ");
		sql.append("                      AND CASE(A.END_YN) WHEN '' THEN 'N' ELSE IFNULL(A.END_YN, 'N') END = 'Y')     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public List<NUR6011U01PrintSetgrdPrintInfo> getNUR6011U01PrintSetgrdPrintInfo(String hospCode, String language, String bunho, String fromDate, String buwi1, String buwi2,
			String buwi3, String buwi4, String buwi5, String buwi6, String assessorStartDate, String assessorEndDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.BUNHO                                                BUNHO                                      ");
		sql.append("        , B.SUNAME                                               NAME                                       ");
		sql.append("        , B.SUNAME2                                              NAME2                                      ");
		sql.append("        , FN_NUR_LOAD_CODE_NAME('SEX',B.SEX, A.HOSP_CODE, :f_language )  GENDER                             ");
		sql.append("        , DATE_FORMAT(B.BIRTH,'%Y/%m/%d')                        BIRTH                                      ");
		sql.append("        , CAST(FN_BAS_LOAD_AGE(A.ASSESSOR_DATE,B.BIRTH,'') AS CHAR)           AGE                           ");
		sql.append("        , FN_NUR_LOAD_CODE_NAME('BEDSORE_BUWI',A.BEDSORE_BUWI, A.HOSP_CODE, :f_language)   BUWI             ");
		sql.append("        , DATE_FORMAT(A.FROM_DATE,'%Y/%m/%d')                    FROM_DATE                                  ");
		sql.append("        , IFNULL(FN_ADM_LOAD_USER_NM(A.HOSP_CODE, A.ASSESSOR, A.ASSESSOR_DATE),'')    ASSESSOR              ");
		sql.append("        , DATE_FORMAT(A.ASSESSOR_DATE,'%Y/%m/%d')                ASSESSOR_DATE                              ");
		sql.append("        , IFNULL(A.YOKCHANG_DEEP,'')                             DEPTH                                      ");
		sql.append("        , IFNULL(A.SAMCHUL_YANG,'')                              EXUDATE                                    ");
		sql.append("        , IFNULL(A.YOKCHANG_SIZE,'')                             S_SIZE                                     ");
		sql.append("        , IFNULL(A.YOKCHANG_GAMYUM,'')                           INFECTION                                  ");
		sql.append("        , IFNULL(A.YUKAJOJIK,'')                                 GRANULATION                                ");
		sql.append("        , IFNULL(A.GAESAJOJIK,'')                                NECROTIC_TISSUE                            ");
		sql.append("        , IFNULL(A.POCKET_GUBUN,'')                              POCKET                                     ");
		sql.append("        , IFNULL(A.TOTAL_COUNT,'')                               TOTAL_COUNT                                ");
		sql.append("        , IFNULL(A.YOKCHANG_STAGE,'')                            STAGE                                      ");
		sql.append("        , IFNULL(A.YUNGYANG_SIKSA_GUBUN,'')                      YUNGYANG_SIKSA_GUBUN                       ");
		sql.append("        , IFNULL(A.YUNGYANG_SIKSA_YANG,'')                       YUNGYANG_SIKSA_YANG                        ");
		sql.append("        , IFNULL(A.YUNGYANG_SIKSA_PERCENT,'')                    YUNGYANG_SIKSA_PERCENT                     ");
		sql.append("        , IFNULL(A.YUNGYANG_SUAEK_YN,'')                         YUNGYANG_SUAEK_YN                          ");
		sql.append("        , IFNULL(A.YUNGYANG_SUAEK_YANG,'')                       YUNGYANG_SUAEK_YANG                        ");
		sql.append("        , IFNULL(A.CHUCHI_TEXT,'')                               CHUCHI_TEXT                                ");
		sql.append("        , IFNULL(A.YOKCHANG_HB,'')                               YOKCHANG_HB                                ");
		sql.append("        , IFNULL(A.YOKCHANG_ALB,'')                              YOKCHANG_ALB                               ");
		sql.append("        , IFNULL(A.YOKCHANG_TP,'')                               YOKCHANG_TP                                ");
		sql.append("        , CAST(FN_NUR_LOAD_WEIGHT(A.HOSP_CODE, A.BUNHO,A.ASSESSOR_DATE) AS CHAR) YOKCHANG_WEIGHT            ");
		sql.append("        , DATE_FORMAT(C.IPWON_DATE,'%Y/%m/%d')                   IPWON_DATE                                 ");
		sql.append("        , C.HO_DONG1                                             HO_DONG                                    ");
		sql.append("        , C.HO_CODE1                                             HO_CODE                                    ");
		sql.append("        , A.BEDSORE_BUWI                                         BEDSORE_BUWI                               ");
		sql.append("     FROM NUR6012 A                                                                                         ");
		sql.append("     JOIN OUT0101 B                                                                                         ");
		sql.append("       ON B.HOSP_CODE     = A.HOSP_CODE                                                                     ");
		sql.append("      AND B.BUNHO         = A.BUNHO                                                                         ");
		sql.append("     JOIN INP1001 C                                                                                         ");
		sql.append("       ON C.HOSP_CODE     = A.HOSP_CODE                                                                     ");
		sql.append("      AND C.BUNHO         = A.BUNHO                                                                         ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                                                    ");
		sql.append("      AND A.BUNHO         = :f_bunho                                                                        ");
		sql.append("      AND A.FROM_DATE     = STR_TO_DATE(:f_from_date, '%Y/%m/%d')                                           ");
		sql.append("      AND A.BEDSORE_BUWI  IN (:f_buwi1, :f_buwi2, :f_buwi3, :f_buwi4, :f_buwi5, :f_buwi6)                   ");
		sql.append("      AND A.ASSESSOR_DATE BETWEEN STR_TO_DATE(:f_assessor_start_date, '%Y/%m/%d')                           ");
		sql.append("                          AND STR_TO_DATE(:f_assessor_end_date, '%Y/%m/%d')                                 ");
		sql.append("      AND STR_TO_DATE(:f_assessor_end_date, '%Y/%m/%d') BETWEEN C.IPWON_DATE                                ");
		sql.append("                         AND IFNULL(C.TOIWON_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))                   ");
		sql.append("    ORDER BY A.BEDSORE_BUWI, A.FROM_DATE                                                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_buwi1", buwi1);
		query.setParameter("f_buwi2", buwi2);
		query.setParameter("f_buwi3", buwi3);
		query.setParameter("f_buwi4", buwi4);
		query.setParameter("f_buwi5", buwi5);
		query.setParameter("f_buwi6", buwi6);		
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_assessor_start_date", assessorStartDate);
		query.setParameter("f_assessor_end_date", assessorEndDate);
		
		List<NUR6011U01PrintSetgrdPrintInfo> list = new JpaResultMapper().list(query, NUR6011U01PrintSetgrdPrintInfo.class);
		return list;
		
	}
}

