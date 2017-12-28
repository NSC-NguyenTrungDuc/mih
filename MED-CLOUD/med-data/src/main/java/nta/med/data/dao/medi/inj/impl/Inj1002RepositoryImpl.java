package nta.med.data.dao.medi.inj.impl;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inj.Inj1002RepositoryCustom;
import nta.med.data.model.ihis.injs.INJ1002R01LayQueryListItemInfo;
import nta.med.data.model.ihis.injs.INJ1002U01GrdOrderListItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01DetailListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Inj1002RepositoryImpl implements Inj1002RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Inj1002RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<InjsINJ1001U01DetailListItemInfo> getInjsINJ1001U01DetailListItemInfo(String hospitalCode, String language, String bunho, String gwa, String doctor, String reserDate, String actingDate, String actingFlg){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT B.GROUP_SER,                                                                                                                           ");
		sql.append("B.PKINJ1002,                                                                                                                                  ");
		sql.append("B.FKINJ1001,                                                                                                                                  ");
		sql.append("A.FKOCS1003,                                                                                                                                  ");
		sql.append("D.HANGMOG_NAME,                                                                                                                               ");
		sql.append("B.SEQ,                                                                                                                                        ");
		sql.append("B.TONGGYE_CODE,                                                                                                                               ");
		sql.append("B.MAGAM_DATE,                                                                                                                                 ");
		sql.append("B.MAGAM_JANGSO,                                                                                                                               ");
		sql.append("B.MAGAM_SER,                                                                                                                                  ");
		sql.append("DATE_FORMAT(B.RESER_DATE, '%Y/%m/%d'),                                                                                                        ");
		sql.append("B.RESER_TIME,                                                                                                                                 ");
		sql.append("DATE_FORMAT(B.JUBSU_DATE, '%Y/%m/%d'),                                                                                                        ");
		sql.append("B.HANGMOG_CODE,                                                                                                                               ");
		sql.append("B.JUSA_BUUI,                                                                                                                                  ");
		sql.append("B.ACTING_JANGSO,                                                                                                                              ");
		sql.append("DATE_FORMAT(B.ACTING_DATE, '%Y/%m/%d'),                                                                                                       ");
		sql.append("B.ACTING_TIME,                                                                                                                                ");
		sql.append("B.COMPANY_CODE,                                                                                                                               ");
		sql.append("B.LOT_NO,                                                                                                                                     ");
		sql.append("B.CHASU_CODE,                                                                                                                                 ");
		sql.append("B.PW_RESULT,                                                                                                                                  ");
		sql.append("B.CS_RESULT,                                                                                                                                  ");
		sql.append("B.AST,                                                                                                                                        ");
		sql.append("IFNULL(B.ACTING_FLAG,'N') ACTING_FLAG,                                                                                                        ");
		sql.append("DATE_FORMAT(B.SUNAB_DATE, '%Y/%m/%d'),                                                                                                        ");
		sql.append("B.SUNAB_SURYANG,                                                                                                                              ");
		sql.append("B.FKOUT1001 FKOUT1001 ,                                                                                                                       ");
		sql.append("IF(E.BUNRYU2 = '05','1',CASE IFNULL(F.ANTI_CANCER_YN,'N') WHEN 'X' THEN '1' WHEN 'Y' THEN '2' ELSE '0' END) CANCER_YN,                        ");
		sql.append("A.BUNHO BUNHO,                                                                                                                                ");
		sql.append("F.ORDER_REMARK REMARK_CHK,                                                                                                                    ");
		sql.append("B.DC_YN ,                                                                                                                                     ");
		sql.append("B.JUSA_TONG_CNT,                                                                                                                              ");
		sql.append("B.OTHER_BUSEO_YN,                                                                                                                             ");
		sql.append("B.JUJONGJA,                                                                                                                                   ");
		sql.append("FN_ADM_LOAD_USER_NAME(B.JUJONGJA, :hospitalCode) JUJONGJA_NAME,                                                                               ");
		sql.append("FN_INJ_YEBANG_CHK(B.HANGMOG_CODE, :hospitalCode) YEBANG_JUJONG_CHK,                                                                           ");
		sql.append("FN_INJ_LOAD_BANNAB_ACTDAY(A.FKOCS1003, B.RESER_DATE, :hospitalCode) ACTDAY_CHK,                                                               ");
		sql.append("B.GWA,                                                                                                                                        ");
		sql.append("IFNULL(F.BANNAB_YN,'N') BANNAB_YN,                                                                                                            ");
		sql.append("FN_INJ_SKIN_JUSA_CHK(B.HANGMOG_CODE, :hospitalCode) SKIN_YN,                                                                                  ");
		sql.append("DATE_FORMAT(A.CHUNGGU_DATE, '%Y/%m/%d') CHUNGGU_DATE,                                                                                         ");
		sql.append("DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d') ORDER_DATE ,                                                                                            ");
		sql.append("A.DOCTOR DOCTOR ,                                                                                                                             ");
		sql.append("FN_OCS_LOAD_CODE_NAME('ORD_DANUI', F.ORD_DANUI, :hospitalCode, :language) DANUI_NAME ,                                                        ");
		sql.append("IF(F.HOPE_DATE is NULL,'N','Y') HOPE_DATE_YN,                                                                                                 ");
		sql.append("CONCAT(IFNULL(F.BOGYONG_CODE,''), FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(F.JUSA_SPD_GUBUN,'0'), :hospitalCode, :language)) BOGYONG_CODE, ");
		sql.append("F.SURYANG ,                                                                                                                                   ");
		sql.append("F.DV ,                                                                                                                                        ");
		sql.append("IF(F.DV_TIME = '#', '/', F.DV_TIME),                                                                                                          ");
		sql.append("F.SLIP_CODE ,                                                                                                                                 ");
		sql.append("B.JUSA_YN ,                                                                                                                                   ");
		sql.append("B.MIX_GROUP ,                                                                                                                                 ");
		sql.append("IFNULL(B.ACTING_FLAG,'N') OLD_ACTING_FLAG ,                                                                                                   ");
		sql.append("B.SILSI_REMARK ,                                                                                                                              ");
		sql.append("F.HOPE_DATE ,                                                                                                                                 ");
		sql.append("F.ORDER_GUBUN ,                                                                                                                               ");
		sql.append("FN_OCS_LOAD_CODE_NAME('JUSA', B.TONGGYE_CODE, :hospitalCode, :language) TONGGYE_CODE_NAME,                                                    ");
		sql.append("CONCAT(IFNULL(DATE_FORMAT(B.RESER_DATE, '%Y/%m/%d'),''), IFNULL(DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d'),''),                                    ");
		sql.append("LPAD(B.GROUP_SER,6,'0'), IFNULL(B.MIX_GROUP, ''), LPAD(B.SEQ,3,'0'),LPAD(B.PKINJ1002,10,'0')) KEY1                                            ");
		sql.append("FROM                                                                                                                                          ");
		sql.append("INV0110 E                                                                                                                                     ");
		sql.append("RIGHT JOIN  OCS0103 D ON E.HOSP_CODE = D.HOSP_CODE AND E.JAERYO_CODE = D.JAERYO_CODE                                                          ");
		sql.append("INNER JOIN INJ1002 B ON D.HOSP_CODE = B.HOSP_CODE AND D.HANGMOG_CODE = B.HANGMOG_CODE                                                         ");
		sql.append("INNER JOIN INJ1001 A ON A.HOSP_CODE = B.HOSP_CODE AND B.FKINJ1001 = A.PKINJ1001 AND A.NALSU > 0                                               ");
		sql.append("INNER JOIN OCS1003 F ON F.PKOCS1003 = A.FKOCS1003 AND F.HOSP_CODE = B.HOSP_CODE AND IFNULL(F.WONYOI_ORDER_YN,'N') != 'Y'                      ");
		sql.append("WHERE B.HOSP_CODE = :hospitalCode                                                                                                             ");
		if (!StringUtils.isEmpty(bunho)) {
			sql.append("AND A.BUNHO = :f_bunho                                                                                                                        ");
		}
		if (!StringUtils.isEmpty(gwa)) {
			sql.append("AND A.GWA = :f_gwa                                                                                                            			  ");
		}
		if (!StringUtils.isEmpty(doctor)) {
			sql.append("AND A.DOCTOR = :f_doctor				                                                                                                      ");
		}
		if (!StringUtils.isEmpty(reserDate)) {
			sql.append("AND B.RESER_DATE = STR_TO_DATE(:f_reser_date, '%Y/%m/%d')                                                                                                              ");
			sql.append("AND STR_TO_DATE(:f_reser_date, '%Y/%m/%d') BETWEEN D.START_DATE AND D.END_DATE                                                                ");
		}
		if (!StringUtils.isEmpty(actingDate)) {
			sql.append("AND IFNULL(B.ACTING_DATE, STR_TO_DATE(DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), '%Y/%m/%d')) = IFNULL(:f_acting_date, STR_TO_DATE(DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), '%Y/%m/%d'))                        ");
		}
		if (!StringUtils.isEmpty(actingFlg)) {
			sql.append("AND IFNULL(B.ACTING_FLAG,'N') = :f_acting_flag                                                                                                ");
		}
		sql.append("ORDER BY B.GWA, A.DOCTOR, B.GROUP_SER, B.MIX_GROUP, B.HANGMOG_CODE;                                                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(bunho)) {
			query.setParameter("f_bunho", bunho);
		}
		if (!StringUtils.isEmpty(gwa)) {
			query.setParameter("f_gwa", gwa);
		}
		if (!StringUtils.isEmpty(doctor)) {
			query.setParameter("f_doctor", doctor);
		}
		if(!StringUtils.isEmpty(reserDate)) {
			query.setParameter("f_reser_date", reserDate);
		}
		if(!StringUtils.isEmpty(actingDate)) {
			query.setParameter("f_acting_date", actingDate);
		}
		if(!StringUtils.isEmpty(actingFlg)) {
			query.setParameter("f_acting_flag", actingFlg);
		}
		
		List<InjsINJ1001U01DetailListItemInfo > list = new JpaResultMapper().list(query, InjsINJ1001U01DetailListItemInfo.class);
		return list;
	}
	
	@Override
	public List<Timestamp> getInjsINJ1001U01ReserDateList(String hospitalCode, String bunho, String doctor, Date reserDate, String actingFlg){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                                                   ");
		sql.append("       B.RESER_DATE                                                                                                               ");
		sql.append("  FROM INJ1001 A                                                                                                                  ");
		sql.append("     , INJ1002 B                                                                                                                  ");
		sql.append(" WHERE A.HOSP_CODE = :hospitalCode                                                                                                ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                                                                                  ");
		sql.append("   AND B.FKINJ1001 = A.PKINJ1001                                                                                                  ");
		if (!StringUtils.isEmpty(bunho)) {
			sql.append("   AND A.BUNHO     = :bunho                                                                                                       ");
		}
		if (!StringUtils.isEmpty(doctor)) {
			sql.append("AND A.DOCTOR = :doctor	  				                                                                                          ");
		}
		if (reserDate != null && !StringUtils.isEmpty(actingFlg)) {
			sql.append("   AND ((('N' = :acting_flag) AND (B.RESER_DATE > :reser_date)) OR (('Y' = :acting_flag) AND (B.ACTING_DATE > :reser_date)))      ");
		}
		if (!StringUtils.isEmpty(actingFlg)) {
			sql.append("   AND IFNULL(B.ACTING_FLAG,'N') = :acting_flag                                                                                   ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if(!StringUtils.isEmpty(bunho)) {
			query.setParameter("bunho", bunho);
		}
		if (!StringUtils.isEmpty(doctor)) {
			query.setParameter("doctor", doctor);
		}
		if(reserDate != null) {
			query.setParameter("reser_date", reserDate);
		}
		if(!StringUtils.isEmpty(actingFlg)) {
			query.setParameter("acting_flag", actingFlg);
		}
		
		List<Timestamp > list = query.getResultList();
		return list;
	}


	
	
	@Override
	public List<Double> getFkocs1003(String hospCode, String pkinj1002) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT B.FKOCS1003 FKOCS1003							");
		sql.append("	 FROM INJ1001 B,                                        ");
		sql.append("	      INJ1002 A                                         ");
		sql.append("	WHERE A.HOSP_CODE               = :hospCode          ");
		sql.append("	  AND B.HOSP_CODE               = A.HOSP_CODE           ");
		sql.append("	  AND A.PKINJ1002               = :pkinj1002          ");
		sql.append("	  AND B.PKINJ1001               = A.FKINJ1001           ");
		sql.append("	  AND IFNULL(A.ACTING_FLAG, 'N')   = 'N';               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("pkinj1002",CommonUtils.parseDouble(pkinj1002));
		List<Double> result = new ArrayList<Double>();
		
		if(query.getResultList() != null){
			 result = query.getResultList();
		}	
		return result;
	
	}
	
	@Override
	public List<INJ1002R01LayQueryListItemInfo> INJ1002R01LayQuery1(String hospCode, String language, String fromDate, String toDate){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT B.GWA                                                                     GWA             ");
		sql.append("        , FN_BAS_LOAD_GWA_NAME(B.GWA, A.ACTING_DATE,:f_hosp_code,:f_language)       BUSEO_NAME      ");
		sql.append("        , DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d')                                    ACTING_DATE     ");
		sql.append("        , A.HANGMOG_CODE                                                            HANGMOG_CODE    ");
		sql.append("        , D.HANGMOG_NAME                                                            HANGMOG_NAME    ");
		sql.append("        , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI,:f_hosp_code,:f_language)  ORD_DANUI       ");
		sql.append("        , COUNT(1)                                                                  INWON_CNT       ");
		sql.append("        , SUM(A.SUNAB_SURYANG)                                                      SUBUL_SURYANG   ");
		sql.append("     FROM INJ1002 A LEFT OUTER JOIN OCS0103 D ON A.HANGMOG_CODE = D.HANGMOG_CODE                    ");
		sql.append("                                              AND D.HOSP_CODE = A.HOSP_CODE                         ");
		sql.append("                               JOIN INJ1001 B ON A.FKINJ1001 = B.PKINJ1001                          ");
		sql.append("                                              AND B.HOSP_CODE = A.HOSP_CODE                         ");
		sql.append("    WHERE A.HOSP_CODE      = :f_hosp_code                                                           ");
		sql.append("      AND IFNULL(A.DC_YN,'N') =  'N'                                                                ");
		sql.append("      AND A.ACTING_DATE   IS NOT NULL                                                               ");
		sql.append("      AND A.ACTING_DATE    >=  STR_TO_DATE(:f_from_date, '%Y/%m/%d')                                ");
		sql.append("      AND A.ACTING_DATE    <=  STR_TO_DATE(:f_to_date  , '%Y/%m/%d')                                ");
		sql.append("    GROUP BY B.GWA                                                                                  ");
		sql.append("        , A.ACTING_DATE                                                                             ");
		sql.append("        , A.HANGMOG_CODE                                                                            ");
		sql.append("        , D.HANGMOG_NAME                                                                            ");
		sql.append("        , D.ORD_DANUI                                                                               ");
		sql.append("    ORDER BY 1, 3, 4                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<INJ1002R01LayQueryListItemInfo > list = new JpaResultMapper().list(query, INJ1002R01LayQueryListItemInfo.class);
		return list;
	}
	
	@Override
	public List<INJ1002R01LayQueryListItemInfo> INJ1002R01LayQuery2(String hospCode, String language, String fromDate, String toDate){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT B.GWA                                                                        GWA            ");
		sql.append("       , FN_BAS_LOAD_GWA_NAME(B.GWA, A.RESER_DATE,:f_hosp_code,:f_language)           BUSEO_NAME     ");
		sql.append("       , DATE_FORMAT(SYSDATE(), '%Y/%m/%d')                                           ACTING_DATE    ");
		sql.append("       , A.HANGMOG_CODE                                                               HANGMOG_CODE   ");
		sql.append("       , D.HANGMOG_NAME                                                               HANGMOG_NAME   ");
		sql.append("       , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI,:f_hosp_code,:f_language)     ORD_DANUI      ");
		sql.append("       , COUNT(1)                                                                     INWON_CNT      ");
		sql.append("       , SUM(A.SUNAB_SURYANG)                                                         SUBUL_SURYANG  ");
		sql.append("    FROM INJ1002 A LEFT OUTER JOIN OCS0103 D ON A.HANGMOG_CODE =  D.HANGMOG_CODE                     ");
		sql.append("                                            AND D.HOSP_CODE = A.HOSP_CODE                            ");
		sql.append("                             JOIN INJ1001 B ON B.HOSP_CODE = A.HOSP_CODE                             ");
		sql.append("                                            AND A.FKINJ1001 =  B.PKINJ1001                           ");
		sql.append("   WHERE A.HOSP_CODE      = :f_hosp_code                                                             ");
		sql.append("     AND IFNULL(A.DC_YN,'N') =  'N'                                                                  ");
		sql.append("     AND A.ACTING_DATE   IS NOT NULL                                                                 ");
		sql.append("     AND A.ACTING_DATE    >=  STR_TO_DATE(:f_from_date, '%Y/%m/%d')                                  ");
		sql.append("     AND A.ACTING_DATE    <=  STR_TO_DATE(:f_to_date  , '%Y/%m/%d')                                  ");
		sql.append("   GROUP BY B.GWA                                                                                    ");
		sql.append("       , BUSEO_NAME                                                                                  ");
		sql.append("       , A.HANGMOG_CODE                                                                              ");
		sql.append("       , D.HANGMOG_NAME                                                                              ");
		sql.append("       , D.ORD_DANUI                                                                                 ");
		sql.append("   ORDER BY 1, 3, 4                                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<INJ1002R01LayQueryListItemInfo > list = new JpaResultMapper().list(query, INJ1002R01LayQueryListItemInfo.class);
		return list;
	}
	
	@Override
	public List<INJ1002U01GrdOrderListItemInfo> getINJ1002U01Initialize(String hospCode, String language, String bunho, String reserDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT F.GROUP_SER                                                                                                                                        ");
		sql.append("     , A.PKINJ1002                                                                                                                                        ");
		sql.append("     , A.FKINJ1001                                                                                                                                        ");
		sql.append("     , E.FKOCS1003                                                                                                                                        ");
		sql.append("     , C.HANGMOG_NAME                                                                                                                                     ");
		sql.append("     , A.SEQ                                                                                                                                              ");
		sql.append("     , A.TONGGYE_CODE                                                                                                                                     ");
		sql.append("     , A.MAGAM_DATE                                                                                                                                       ");
		sql.append("     , A.MAGAM_JANGSO                                                                                                                                     ");
		sql.append("     , A.MAGAM_SER                                                                                                                                        ");
		sql.append("     , DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d')                                                                                                              ");
		sql.append("     , A.RESER_TIME                                                                                                                                       ");
		sql.append("     , DATE_FORMAT(A.JUBSU_DATE, '%Y/%m/%d')                                                                                                              ");
		sql.append("     , A.HANGMOG_CODE                                                                                                                                     ");
		sql.append("     , A.JUSA_BUUI                                                                                                                                        ");
		sql.append("     , A.ACTING_JANGSO                                                                                                                                    ");
		sql.append("     , DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d')                                                                                                             ");
		sql.append("     , A.ACTING_TIME                                                                                                                                      ");
		sql.append("     , A.COMPANY_CODE                                                                                                                                     ");
		sql.append("     , A.LOT_NO                                                                                                                                           ");
		sql.append("     , A.CHASU_CODE                                                                                                                                       ");
		sql.append("     , A.PW_RESULT                                                                                                                                        ");
		sql.append("     , A.CS_RESULT                                                                                                                                        ");
		sql.append("     , A.AST                                                                                                                                              ");
		sql.append("     , IFNULL(A.ACTING_FLAG,'N')  ACTING_FLAG                                                                                                             ");
		sql.append("     , A.SUNAB_SURYANG                                                                                                                                    ");
		sql.append("     , DATE_FORMAT(A.SUNAB_DATE, '%Y/%m/%d')                                                                                                              ");
		sql.append("     , A.FKOUT1001  FKOUT1001                                                                                                                             ");
		sql.append("     , IF(D.BUNRYU2 = '05', '1', CASE(IFNULL(F.ANTI_CANCER_YN,'N')) WHEN 'X' THEN '1' WHEN 'Y' THEN '2' ELSE '0' END) CANCER_YN                           ");
		sql.append("     , E.BUNHO      BUNHO                                                                                                                                 ");
		sql.append("     , F.ORDER_REMARK    REMARK_CHK                                                                                                                       ");
		sql.append("     , A.DC_YN                                                                                                                                            ");
		sql.append("     , A.JUSA_TONG_CNT                                                                                                                                    ");
		sql.append("     , A.OTHER_BUSEO_YN                                                                                                                                   ");
		sql.append("     , A.JUJONGJA                                                                                                                                         ");
		sql.append("     , FN_ADM_LOAD_USER_NAME(A.JUJONGJA,:f_hosp_code) JUJONGJA_NAME                                                                                       ");
		sql.append("     , FN_INJ_YEBANG_CHK(A.HANGMOG_CODE,:f_hosp_code) YEBANG_JUJONG_CHK                                                                                   ");
		sql.append("     , FN_INJ_LOAD_BANNAB_ACTDAY(E.FKOCS1003, A.RESER_DATE,:f_hosp_code) ACTDAY_CHK                                                                       ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.RESER_DATE,:f_hosp_code,:f_language)                                                                                 ");
		sql.append("     , IFNULL(F.BANNAB_YN,'N') BANNAB_YN                                                                                                                  ");
		sql.append("     , FN_INJ_SKIN_JUSA_CHK(A.HANGMOG_CODE,:f_hosp_code) SKIN_YN                                                                                          ");
		sql.append("     , DATE_FORMAT(E.CHUNGGU_DATE, '%Y/%m/%d') CHUNGGU_DATE                                                                                               ");
		sql.append("     , DATE_FORMAT(E.ORDER_DATE, '%Y/%m/%d')   ORDER_DATE                                                                                                 ");
		sql.append("     , FN_BAS_LOAD_DOCTOR_NAME(E.DOCTOR, A.RESER_DATE,:f_hosp_code)       DOCTOR                                                                          ");
		sql.append("     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',F.ORD_DANUI,:f_hosp_code,:f_language)    ORD_DANUI                                                               ");
		sql.append("     , IF(F.HOPE_DATE IS NULL,'N','Y')     HOPE_DATE_YN                                                                                                   ");
		sql.append("     , CONCAT(F.BOGYONG_CODE , FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',IFNULL(F.JUSA_SPD_GUBUN,'0'),:f_hosp_code,:f_language))    BOGYONG_CODE             ");
		sql.append("     , F.SURYANG                                                                                                                                          ");
		sql.append("     , F.DV                                                                                                                                               ");
		sql.append("     , IF(F.DV_TIME = '#', '/', F.DV_TIME)                                                                                                                ");
		sql.append("     , F.SLIP_CODE                                                                                                                                        ");
		sql.append("     , F.ORDER_DATE F_ORDER_DATE                                                                                                                                      ");
		sql.append("     , A.MIX_GROUP                                                                                                                                        ");
		sql.append("     , F.HOPE_DATE                                                                                                                                        ");
		sql.append("     , F.ORDER_GUBUN                                                                                                                                      ");
		sql.append("  FROM OCS1003 F                                                                                                                                          ");
		sql.append("     , INJ1001 E                                                                                                                                          ");
		sql.append("     , INJ1002 A                                                                                                                                          ");
		sql.append("     , OCS0103 C LEFT OUTER JOIN INV0110 D ON D.HOSP_CODE = C.HOSP_CODE                                                                                   ");
		sql.append("                                           AND D.JAERYO_CODE = C.JAERYO_CODE                                                                              ");
		sql.append(" WHERE A.HOSP_CODE      = :f_hosp_code                                                                                                                    ");
		sql.append("   AND C.HOSP_CODE      = A.HOSP_CODE                                                                                                                     ");
		sql.append("   AND E.HOSP_CODE      = A.HOSP_CODE                                                                                                                     ");
		sql.append("   AND F.HOSP_CODE      = A.HOSP_CODE                                                                                                                     ");
		sql.append("   AND E.BUNHO          = :f_bunho                                                                                                                        ");
		sql.append("   AND E.NALSU          > 0                                                                                                                               ");
		sql.append("   AND IFNULL(E.DC_YN,'N') = 'N'                                                                                                                          ");
		sql.append("   AND A.FKINJ1001      = E.PKINJ1001                                                                                                                     ");
		sql.append("   AND A.RESER_DATE     = STR_TO_DATE(:f_reser_date, '%Y/%m/%d')                                                                                          ");
		sql.append("   AND STR_TO_DATE(:f_reser_date, '%Y/%m/%d') BETWEEN C.START_DATE AND C.END_DATE                                                                         ");
		sql.append("   AND C.HANGMOG_CODE   = A.HANGMOG_CODE                                                                                                                  ");
		sql.append("   AND F.PKOCS1003      = E.FKOCS1003                                                                                                                     ");
		sql.append("   AND IFNULL(F.WONYOI_ORDER_YN,'N') != 'Y'                                                                                                               ");
		sql.append("   AND IFNULL(A.ACTING_FLAG,'N') = 'N'                                                                                                                    ");
		sql.append(" ORDER BY E.GWA, E.DOCTOR, F.GROUP_SER , A.MIX_GROUP, A.HANGMOG_CODE                                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_reser_date", reserDate);
		
		List<INJ1002U01GrdOrderListItemInfo> list = new JpaResultMapper().list(query, INJ1002U01GrdOrderListItemInfo.class);
		return list;
	}
	
	@Override
	public List<String> getINJ1002U01InitializeReserDate(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DATE_FORMAT(B.RESER_DATE,'%Y/%m/%d') RESER_DATE           ");
		sql.append("  FROM INJ1002 B,                                                ");
		sql.append("       INJ1001 A                                                 ");
		sql.append(" WHERE A.HOSP_CODE      = :f_hosp_code                           ");
		sql.append("   AND B.HOSP_CODE      = A.HOSP_CODE                            ");
		sql.append("   AND A.BUNHO          = :f_bunho                               ");
		sql.append("   AND IFNULL(A.DC_YN,'N') = 'N'                                 ");
		sql.append("   AND A.NALSU          > 0                                      ");
		sql.append("   AND B.FKINJ1001      = A.PKINJ1001                            ");
		sql.append("   AND IFNULL(B.ACTING_FLAG, 'N') = 'N'                          ");
		sql.append(" GROUP BY B.RESER_DATE                                           ");
		sql.append(" ORDER BY 1                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		return list;
	}
}

