package nta.med.data.dao.medi.inj.impl;

import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.model.ihis.injs.INJ0000Q00layOrderInfo;
import nta.med.data.dao.medi.inj.Inj1001RepositoryCustom;
import nta.med.data.model.ihis.injs.INJ0000Q00layActDateInfo;
import nta.med.data.model.ihis.injs.INJ0000Q00layActingInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01MasterListItemInfo;
import nta.med.data.model.ihis.ocso.OCSACT2GetPatientListINJInfo;
import nta.med.data.model.ihis.phys.PHY2001U04GrdListInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Inj1001RepositoryImpl implements Inj1001RepositoryCustom {
private static final Log LOG = LogFactory.getLog(Inj1001RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<InjsINJ1001U01MasterListItemInfo> getInjsINJ1001U01MasterListItemInfo(String hospitalCode, String gwa, String reserDate, String actingFlg){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IF(A.RESER_DATE = C.ORDER_DATE, '1', '2') RESER_GUBUN                                                     ");                                         
		sql.append("  , B.BUNHO BUNHO                                                                                                ");                                         
		sql.append("  , SUBSTR(FN_OUT_LOAD_SUNAME(B.BUNHO, :hospitalCode), 1,20) SUNAME                                              ");                                         
		sql.append("  , DATE_FORMAT(B.ORDER_DATE,'%Y/%m/%d') ORDER_DATE                                                              ");                                         
		sql.append("  , DATE_FORMAT(A.RESER_DATE,'%Y/%m/%d') RESER_DATE                                                              ");                                         
		sql.append("  , IFNULL(P.NUMBER_PROTOCOL, 0) 	 NUMBER_PROTOCOL                                                             ");                                         
		sql.append("  FROM INJ1002 A                                                                                                 ");                                           
		sql.append("  INNER JOIN INJ1001 B  ON B.HOSP_CODE = A.HOSP_CODE                                                             ");
		sql.append("  INNER JOIN  OCS1003 C ON C.HOSP_CODE = A.HOSP_CODE                                                             ");                                                                   
		sql.append(" LEFT JOIN (select COUNT(cpp.CLIS_PROTOCOL_ID) NUMBER_PROTOCOL, cpp.BUNHO from CLIS_PROTOCOL_PATIENT cpp         ");                                         
		sql.append("		 INNER JOIN CLIS_PROTOCOL	cp	ON cpp.CLIS_PROTOCOL_ID = cp.CLIS_PROTOCOL_ID                            ");                                         
		sql.append("		 AND cpp.HOSP_CODE = :hospitalCode										AND				                 ");                                         
		sql.append("		cpp.ACTIVE_FLG = 1										AND		                                         ");                                         
		sql.append("		cp.ACTIVE_FLG = 1										AND		                                         ");                                         
		sql.append("		cp.STATUS_FLG <> 1										AND		                                         ");                                         
		sql.append("		cp.END_DATE >= SYSDATE() GROUP BY cpp.BUNHO ) P ON B.BUNHO = P.BUNHO	                                 ");                                         
		sql.append("  WHERE A.HOSP_CODE = :hospitalCode                                                                              ");
		if(!StringUtils.isEmpty(actingFlg) && "N".equals(actingFlg) && !StringUtils.isEmpty(reserDate)){
			sql.append("  AND STR_TO_DATE(DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d'), '%Y/%m/%d') = STR_TO_DATE(:f_reser_date,'%Y/%m/%d') ");
		}
		if(!StringUtils.isEmpty(actingFlg) && "Y".equals(actingFlg) && !StringUtils.isEmpty(reserDate)){
			sql.append("  AND STR_TO_DATE(DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d'), '%Y/%m/%d') = STR_TO_DATE(:f_reser_date,'%Y/%m/%d') ");
		}
		if(!StringUtils.isEmpty(actingFlg)) {                                                                                       
			sql.append("  AND IFNULL(A.ACTING_FLAG, 'N') = :f_acting_flag                                                            ");
		}                                                                                                                           
		sql.append("  AND B.PKINJ1001 = A.FKINJ1001                                                                                  ");
		if (!StringUtils.isEmpty(gwa)) {                                                                                            
			sql.append("  AND IF(:f_gwa = 'IR', 'IR', B.GWA) = :f_gwa                                                                ");
		}                                                                                                                           
		sql.append("  AND C.PKOCS1003 = B.FKOCS1003                                                                                  ");
		sql.append("  AND C.SLIP_CODE <> 'M04'                                                                                       ");
		sql.append("  GROUP BY                                                                                                       ");
		sql.append("  B.BUNHO                                                                                                        ");
		sql.append("  , IF(A.RESER_DATE = C.ORDER_DATE, '1', '2')                                                                    ");
		sql.append("  , B.ORDER_DATE                                                                                                 ");
		sql.append("  , A.RESER_DATE                                                                                                 ");
		sql.append("  , FN_OUT_LOAD_SUNAME(B.BUNHO, :hospitalCode)                                                                   ");
		sql.append("  ORDER BY 1, 2                                                                                                  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(gwa)) {
			query.setParameter("f_gwa", gwa);
		}
		if(!StringUtils.isEmpty(reserDate) && !StringUtils.isEmpty(actingFlg) && (
				"N".equals(actingFlg) || "Y".equals(actingFlg))) {
			query.setParameter("f_reser_date", reserDate);
		}
		if(!StringUtils.isEmpty(actingFlg)) {
			query.setParameter("f_acting_flag", actingFlg);
		}
		
		List<InjsINJ1001U01MasterListItemInfo> list = new JpaResultMapper().list(query, InjsINJ1001U01MasterListItemInfo.class);
		return list;
	}
	
	@Override
	public List<Timestamp> getInjsINJ1001U01OrderDateList(String hospitalCode, String pkinj1002){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(B.ORDER_DATE, SYSDATE()) ORDER_DATE ");
		sql.append("FROM INJ1002 A, INJ1001 B                         ");
		sql.append("WHERE A.HOSP_CODE  = :hospitalCode                ");
		sql.append("        AND B.HOSP_CODE  = A.HOSP_CODE            ");
		if (!StringUtils.isEmpty(pkinj1002)) {
			sql.append("        AND A.PKINJ1002  = :pkinj1002             ");
		}
		sql.append("        AND A.FKINJ1001  = B.PKINJ1001;           ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		if (!StringUtils.isEmpty(pkinj1002)) {
			query.setParameter("pkinj1002", pkinj1002);
		}
		
		List<Timestamp> list = query.getResultList();
		return list;
	}

	@Override
	public List<PHY2001U04GrdListInfo> getPHY2001U04GrdListInfo(
			String hospCode, String language, String bunho, String statFlg,
			Date naewonDate, String gwa, String doctor, String gubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT                                                                                                                                                 ");
		sql.append("       KIZYUN_DATE                                                                                                                                      ");
		sql.append("     , GWA                                                                                                                                              ");
		sql.append("     , GWA_NAME                                                                                                                                         ");
		sql.append("     , DOCTOR                                                                                                                                           ");
		sql.append("     , DOCTOR_NAME                                                                                                                                      ");
		sql.append("     , HANGMOG_CODE                                                                                                                                     ");
		sql.append("     , HANGMOG_NAME                                                                                                                                     ");
		sql.append("     , JUNDAL_PART                                                                                                                                      ");
		sql.append("     , JUNDAL_PART_NAME                                                                                                                                 ");
		sql.append("     , RESER_TIME                                                                                                                                       ");
		sql.append("     , RESER_YN                                                                                                                                         ");
		sql.append("     , ACT_YN                                                                                                                                           ");
		sql.append("  FROM(                                                                                                                                                 ");
		sql.append("         SELECT A.ORDER_DATE  KIZYUN_DATE                                                                                                               ");
		sql.append("              , A.GWA                                                                                                                                   ");
		sql.append("              , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE, :f_hosp_code, :f_langauge) GWA_NAME                                                           ");
		sql.append("              , A.DOCTOR                                                                                                                                ");
		sql.append("              , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, :f_hosp_code) DOCTOR_NAME                                                               ");
		sql.append("              , A.HANGMOG_CODE                                                                                                                          ");
		sql.append("              , B.HANGMOG_NAME                                                                                                                          ");
		sql.append("              , A.JUNDAL_PART                                                                                                                           ");
		sql.append("              , C.BUSEO_NAME  JUNDAL_PART_NAME                                                                                                          ");
		sql.append("              , A.RESER_TIME                                                                                                                            ");
		sql.append("              , 'A' RESER_YN                                                                                                                            ");
		sql.append("              ,case A.OCS_FLAG when '1' then 'N' when '2' then 'N' else 'Y' end ACT_YN                                                                  ");
		sql.append("           FROM OCS1003 A                                                                                                                               ");
		sql.append("              , OCS0103 B                                                                                                                               ");
		sql.append("              , BAS0260 C                                                                                                                               ");
		sql.append("          WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                           ");
		sql.append("            AND A.BUNHO        = :f_bunho                                                                                                               ");
		sql.append("            AND (:f_stat_flg   = 'P' AND A.ORDER_DATE < :f_naewon_date AND A.OCS_FLAG = '1'                                                             ");
		sql.append("              OR :f_stat_flg   = 'C' AND A.ORDER_DATE = :f_naewon_date                                                                                  ");
		sql.append("              OR :f_stat_flg   = 'F' AND A.ORDER_DATE > :f_naewon_date)                                                                                 ");
		sql.append("            AND A.GWA          LIKE IFNULL(:f_gwa, '%')                                                                                                 ");
		sql.append("            AND A.DOCTOR       LIKE IFNULL(:f_doctor, '%')                                                                                              ");
		sql.append("            AND A.HOPE_DATE    IS NULL                                                                                                                  ");
		sql.append("            AND A.OCS_FLAG     <> '2'                                                                                                                   ");
		sql.append("            AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                            ");
		sql.append("            AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                                         ");
		sql.append("            AND B.SLIP_CODE NOT LIKE 'I%'                                                                                                               ");
		sql.append("            AND :f_naewon_date BETWEEN B.START_DATE AND B.END_DATE                                                                                      ");
		sql.append("            AND C.HOSP_CODE    = A.HOSP_CODE                                                                                                            ");
		sql.append("            AND C.GWA          = A.JUNDAL_PART                                                                                                          ");
		sql.append("            AND :f_naewon_date BETWEEN C.START_DATE AND C.END_DATE                                                                                      ");
		sql.append("            AND C.LANGUAGE = :f_langauge                                                                                                                ");
		sql.append("      UNION ALL                                                                                                                                         ");
		sql.append("         SELECT A.RESER_DATE  KIZYUN_DATE                                                                                                               ");
		sql.append("              , A.GWA                                                                                                                                   ");
		sql.append("              , FN_BAS_LOAD_GWA_NAME(A.GWA, A.INPUT_DATE, :f_hosp_code, :f_langauge) GWA_NAME                                                           ");
		sql.append("              , A.DOCTOR                                                                                                                                ");
		sql.append("              , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code) DOCTOR_NAME                                                                ");
		sql.append("              , A.HANGMOG_CODE                                                                                                                          ");
		sql.append("              , B.HANGMOG_NAME                                                                                                                          ");
		sql.append("              , A.JUNDAL_PART                                                                                                                           ");
		sql.append("              , C.JUNDAL_PART_NAME                                                                                                                      ");
		sql.append("              , A.RESER_TIME                                                                                                                            ");
		sql.append("              , case A.RESER_DATE when NULL then 'N' else 'Y' end RESER_YN                                                                              ");
		sql.append("              , case A.ACTING_DATE when NULL then 'N' else 'Y' end ACT_YN                                                                               ");
		sql.append("           FROM SCH0201 A                                                                                                                               ");
		sql.append("              , OCS0103 B                                                                                                                               ");
		sql.append("              , SCH0001 C                                                                                                                               ");
		sql.append("          WHERE :f_gubun = 'Y'                                                                                                                          ");
		sql.append("            AND A.HOSP_CODE    = :f_hosp_code                                                                                                           ");
		sql.append("            AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                            ");
		sql.append("            AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                                                                         ");
		sql.append("            AND :f_naewon_date BETWEEN B.START_DATE AND B.END_DATE                                                                                      ");
		sql.append("            AND A.BUNHO        = :f_bunho                                                                                                               ");
		sql.append("            AND (:f_stat_flg  = 'P' AND A.RESER_DATE < :f_naewon_date AND (case A.ACTING_DATE when NULL then 'N' else 'Y' end) = 'N'                    ");
		sql.append("              OR :f_stat_flg  = 'C' AND A.RESER_DATE = :f_naewon_date                                                                                   ");
		sql.append("              OR :f_stat_flg  = 'F' AND A.RESER_DATE > :f_naewon_date)                                                                                  ");
		sql.append("            AND A.GWA          LIKE IFNULL(:f_gwa, '%')                                                                                                 ");
		sql.append("            AND A.DOCTOR       LIKE IFNULL(:f_doctor, '%')                                                                                              ");
		sql.append("            AND IFNULL(A.CANCEL_YN, 'N') = 'N'                                                                                                          ");
		sql.append("            AND C.HOSP_CODE    = A.HOSP_CODE                                                                                                            ");
		sql.append("            AND C.JUNDAL_TABLE = A.JUNDAL_TABLE                                                                                                         ");
		sql.append("            AND C.JUNDAL_PART  = A.JUNDAL_PART                                                                                                          ");
		sql.append("                                                                                                                                                        ");
		sql.append("         UNION ALL                                                                                                                                      ");
		sql.append("         SELECT A.ACTING_DATE                                         KIZYUN_DATE                                                                       ");
		sql.append("              , A.GWA                                                  GWA                                                                              ");
		sql.append("              , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ACTING_DATE, :f_hosp_code, :f_langauge)         GWA_NAME                                                  ");
		sql.append("              , A.DOCTOR                                            DOCTOR                                                                              ");
		sql.append("              , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE, :f_hosp_code)  DOCTOR_NAME                                                              ");
		sql.append("              , A.HANGMOG_CODE                                        HANGMOG_CODE                                                                      ");
		sql.append("              , B.HANGMOG_NAME                                     HANGMOG_NAME                                                                         ");
		sql.append("              , A.JUNDAL_PART                                          JUNDAL_PART                                                                      ");
		sql.append("              , 'リハビリ'                                        JUNDAL_PART_NAME                                                                          ");
		sql.append("              , A.ACTING_TIME                                           RESER_TIME                                                                      ");
		sql.append("              , 'N'                                               RESER_YN                                                                              ");
		sql.append("              , 'Y'                                              ACT_YN                                                                                 ");
		sql.append("           FROM OCS1003 A                                                                                                                               ");
		sql.append("              , OCS0103 B                                                                                                                               ");
		sql.append("          WHERE :f_gubun = 'J'                                                                                                                          ");
		sql.append("            AND A.HOSP_CODE    = :f_hosp_code                                                                                                           ");
		sql.append("            AND A.BUNHO        = :f_bunho                                                                                                               ");
		sql.append("            AND A.ACTING_DATE  = :f_naewon_date                                                                                                         ");
		sql.append("            AND A.JUNDAL_PART  LIKE 'REH'                                                                                                               ");
		sql.append("            AND B.HOSP_CODE      = A.HOSP_CODE                                                                                                          ");
		sql.append("            AND B.HANGMOG_CODE   = A.HANGMOG_CODE                                                                                                       ");
		sql.append("            AND A.ACTING_DATE BETWEEN B.START_DATE AND B.END_DATE                                                                                       ");
		sql.append("                                                                                                                                                        ");
		sql.append("      UNION ALL                                                                                                                                         ");
		sql.append("         SELECT B.RESER_DATE KIZYUN_DATE                                                                                                                ");
		sql.append("              , A.GWA GWA                                                                                                                               ");
		sql.append("              , FN_BAS_LOAD_GWA_NAME(A.GWA, B.RESER_DATE, :f_hosp_code, :f_langauge) GWA_NAME                                                           ");
		sql.append("              , A.DOCTOR DOCTOR                                                                                                                         ");
		sql.append("              , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, B.RESER_DATE,:f_hosp_code) DOCTOR_NAME                                                                ");
		sql.append("              , B.HANGMOG_CODE HANGMOG_CODE                                                                                                             ");
		sql.append("              , C.HANGMOG_NAME HANGMOG_NAME                                                                                                             ");
		sql.append("              , A.JUNDAL_PART                                                                                                                           ");
		sql.append("              , D.BUSEO_NAME JUNDAL_PART_NAME                                                                                                           ");
		sql.append("              , B.RESER_TIME                                                                                                                            ");
		sql.append("              , case B.RESER_DATE when NULL then 'N' else 'Y' end RESER_YN                                                                              ");
		sql.append("              , case B.ACTING_DATE when NULL then 'N' else 'Y' end ACT_YN                                                                               ");
		sql.append("           FROM BAS0260 D                                                                                                                               ");
		sql.append("              , OCS0103 C                                                                                                                               ");
		sql.append("              , INJ1002 B                                                                                                                               ");
		sql.append("              , INJ1001 A                                                                                                                               ");
		sql.append("          WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                           ");
		sql.append("            AND A.BUNHO        = :f_bunho                                                                                                               ");
		sql.append("            AND A.GWA          LIKE IFNULL(:f_gwa, '%')                                                                                                 ");
		sql.append("            AND A.DOCTOR       LIKE IFNULL(:f_doctor, '%')                                                                                              ");
		sql.append("            AND B.HOSP_CODE    = A.HOSP_CODE                                                                                                            ");
		sql.append("            AND B.FKINJ1001    = A.PKINJ1001                                                                                                            ");
		sql.append("            AND (:f_stat_flg  = 'P' AND B.RESER_DATE < :f_naewon_date AND (case B.ACTING_DATE when NULL then 'N' else 'Y' end)  = 'N'                   ");
		sql.append("              OR :f_stat_flg  = 'C' AND A.ORDER_DATE <> B.RESER_DATE AND B.RESER_DATE = :f_naewon_date                                                  ");
		sql.append("              OR :f_stat_flg  = 'F' AND B.RESER_DATE > :f_naewon_date)                                                                                  ");
		sql.append("            AND IFNULL(B.DC_YN, 'N') = 'N'                                                                                                              ");
		sql.append("            AND C.HOSP_CODE    = B.HOSP_CODE                                                                                                            ");
		sql.append("            AND C.HANGMOG_CODE = B.HANGMOG_CODE                                                                                                         ");
		sql.append("            AND :f_naewon_date BETWEEN C.START_DATE AND C.END_DATE                                                                                      ");
		sql.append("            AND D.HOSP_CODE    = A.HOSP_CODE                                                                                                            ");
		sql.append("            AND D.GWA          = A.JUNDAL_PART                                                                                                          ");
		sql.append("            AND :f_naewon_date BETWEEN D.START_DATE AND D.END_DATE                                                                                      ");
		sql.append("            AND D.LANGUAGE = :f_langauge                                                                                                                ");
		sql.append("     ) AA                                                                                                                                               ");
		sql.append(" ORDER BY AA.KIZYUN_DATE, AA.RESER_TIME IS NULL, AA.RESER_YN																							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_langauge", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_stat_flg", statFlg);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_gwa", gwa);
		if(StringUtils.isEmpty(doctor)){
			doctor = null;
		}
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_gubun", gubun);
		
		List<PHY2001U04GrdListInfo> list = new JpaResultMapper().list(query, PHY2001U04GrdListInfo.class);
		return list;
	}

	@Override
	public List<Timestamp> getSCH0201U10GrdReser(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                        ");
		sql.append("        RESER_DATE                                      ");
		sql.append("   FROM SCH0201                                         ");
		sql.append("  WHERE HOSP_CODE  = :f_hosp_code                       ");
		sql.append("    AND BUNHO      = :f_bunho                           ");
		sql.append("    AND IFNULL(CANCEL_YN,'N')  = 'N'                    ");
		sql.append("    AND IFNULL(RESER_YN ,'N')  = 'Y'                    ");
		sql.append("    AND RESER_DATE >= SYSDATE()                         ");
		sql.append("    AND IFNULL(CANCEL_YN,'N') = 'N'                     ");
		sql.append("    AND ACTING_DATE IS NULL                             ");
		sql.append("  UNION                                                 ");
		sql.append(" SELECT DISTINCT                                        ");
		sql.append("        NAEWON_DATE                                     ");
		sql.append("   FROM OUT1001                                         ");
		sql.append("  WHERE HOSP_CODE          = :f_hosp_code               ");
		sql.append("    AND BUNHO              = :f_bunho                   ");
		sql.append("    AND IFNULL(RESER_YN ,'N') = 'Y'                     ");
		sql.append("    AND IFNULL(NAEWON_YN,'N') = 'N'                     ");
		sql.append("    AND NAEWON_DATE       >= SYSDATE()                  ");
		sql.append("  UNION                                                 ");
		sql.append(" SELECT DISTINCT                                        ");
		sql.append("        B.RESER_DATE   RESER_DATE                       ");
		sql.append("   FROM INJ1001 A                                       ");
		sql.append("      , INJ1002 B                                       ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                 ");
		sql.append("    AND B.HOSP_CODE      = A.HOSP_CODE                  ");
		sql.append("    AND A.BUNHO          = :f_bunho                     ");
		sql.append("    AND A.PKINJ1001      = B.FKINJ1001                  ");
		sql.append("    AND B.RESER_DATE    >= SYSDATE()                    ");
		sql.append("    AND IFNULL(B.DC_YN,'N') = 'N'                       ");
		sql.append("    AND B.ACTING_DATE IS NULL                           ");
		sql.append("  ORDER BY 1											");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		List<Timestamp> list = query.getResultList();
		return list;
	}

	@Override
	public List<OCSACT2GetPatientListINJInfo> getOCSACT2GetPatientListINJInfo(String hospitalCode, String language, String gwa, String reserDate, String actingFlg) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(P.NUMBER_PROTOCOL, 0) 	 NUMBER_PROTOCOL                                                         "); 
		sql.append("  , IF(A.RESER_DATE = C.ORDER_DATE, '1', '2') RESER_GUBUN                                                        ");                                         
		sql.append("  , B.BUNHO BUNHO                                                                                                ");                                         
		sql.append("  , SUBSTR(FN_OUT_LOAD_SUNAME(B.BUNHO, :hospitalCode), 1,20) SUNAME                                              "); 
		sql.append("  , C.JUNDAL_TABLE                                      JUNDAL_TABLE                                             ");
		sql.append("  , DATE_FORMAT(B.ORDER_DATE,'%Y/%m/%d') ORDER_DATE                                                              ");                                         
		sql.append("  , DATE_FORMAT(A.RESER_DATE,'%Y/%m/%d') RESER_DATE                                                              ");                                         
		sql.append("  , C.GWA                                      GWA                                                               "); 
		sql.append("  , FN_BAS_LOAD_GWA_NAME(C.GWA, C.SYS_DATE, :hospitalCode, :f_language)           GWA_NAME                       ");
		sql.append("  , C.DOCTOR                                      DOCTOR                                                         ");
		sql.append("  , FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR, C.SYS_DATE, :hospitalCode)  DOCTOR_NAME                                    ");
		sql.append("  , C.PKOCS1003         PKOCS1003                                                                                ");
		sql.append("  , C.FKOUT1001         PKOUT1001                                                                                ");
		sql.append("  , FN_OUT_LOAD_SUNAME2(B.BUNHO,:hospitalCode)     SUNAME2                                                       ");
		sql.append("  FROM INJ1002 A                                                                                                 ");                                           
		sql.append("  INNER JOIN INJ1001 B  ON B.HOSP_CODE = A.HOSP_CODE                                                             ");
		sql.append("  INNER JOIN  OCS1003 C ON C.HOSP_CODE = A.HOSP_CODE AND C.JUNDAL_TABLE = 'DRG' AND C.JUNDAL_PART = 'IR'         ");                                                                   
		sql.append(" LEFT JOIN (select COUNT(cpp.CLIS_PROTOCOL_ID) NUMBER_PROTOCOL, cpp.BUNHO from CLIS_PROTOCOL_PATIENT cpp         ");                                         
		sql.append("		 INNER JOIN CLIS_PROTOCOL	cp	ON cpp.CLIS_PROTOCOL_ID = cp.CLIS_PROTOCOL_ID                            ");                                         
		sql.append("		 AND cpp.HOSP_CODE = :hospitalCode										AND				                 ");                                         
		sql.append("		cpp.ACTIVE_FLG = 1										AND		                                         ");                                         
		sql.append("		cp.ACTIVE_FLG = 1										AND		                                         ");                                         
		sql.append("		cp.STATUS_FLG <> 1										AND		                                         ");                                         
		sql.append("		cp.END_DATE >= SYSDATE() GROUP BY cpp.BUNHO ) P ON B.BUNHO = P.BUNHO	                                 ");                                         
		sql.append("  WHERE A.HOSP_CODE = :hospitalCode                                                                              ");
		if(!StringUtils.isEmpty(actingFlg) && "N".equals(actingFlg) && !StringUtils.isEmpty(reserDate)){
			sql.append("  AND STR_TO_DATE(DATE_FORMAT(A.RESER_DATE, '%Y/%m/%d'), '%Y/%m/%d') = STR_TO_DATE(:f_reser_date,'%Y/%m/%d') ");
		}
		if(!StringUtils.isEmpty(actingFlg) && "Y".equals(actingFlg) && !StringUtils.isEmpty(reserDate)){
			sql.append("  AND STR_TO_DATE(DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d'), '%Y/%m/%d') = STR_TO_DATE(:f_reser_date,'%Y/%m/%d') ");
		}
		if(!StringUtils.isEmpty(actingFlg)) {                                                                                       
			sql.append("  AND IFNULL(A.ACTING_FLAG, 'N') = :f_acting_flag                                                            ");
		}                                                                                                                           
		sql.append("  AND B.PKINJ1001 = A.FKINJ1001                                                                                  ");
		if (!StringUtils.isEmpty(gwa)) {                                                                                            
			sql.append("  AND IF(:f_gwa = 'IR', 'IR', B.GWA) = :f_gwa                                                                ");
		}                                                                                                                           
		sql.append("  AND C.PKOCS1003 = B.FKOCS1003                                                                                  ");
		sql.append("  AND C.SLIP_CODE <> 'M04'                                                                                       ");
		sql.append("  GROUP BY                                                                                                       ");
		sql.append("  B.BUNHO                                                                                                        ");
		sql.append("  , IF(A.RESER_DATE = C.ORDER_DATE, '1', '2')                                                                    ");
		sql.append("  , B.ORDER_DATE                                                                                                 ");
		sql.append("  , A.RESER_DATE                                                                                                 ");
		sql.append("  , FN_OUT_LOAD_SUNAME(B.BUNHO, :hospitalCode)                                                                   ");
		sql.append("  ORDER BY 1, 2                                                                                                  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospitalCode", hospitalCode);
		query.setParameter("f_language", language);
		if (!StringUtils.isEmpty(gwa)) {
			query.setParameter("f_gwa", gwa);
		}
		if(!StringUtils.isEmpty(reserDate) && !StringUtils.isEmpty(actingFlg) && ("N".equals(actingFlg) || "Y".equals(actingFlg))) {
			query.setParameter("f_reser_date", reserDate);
		}
		if(!StringUtils.isEmpty(actingFlg)) {
			query.setParameter("f_acting_flag", actingFlg);
		}
		
		List<OCSACT2GetPatientListINJInfo> list = new JpaResultMapper().list(query, OCSACT2GetPatientListINJInfo.class);
		return list;
	}

	@Override
	public List<INJ0000Q00layActDateInfo> getINJ0000Q00layActDateInfo(String hospCode, String language, String bunho,
			String messageGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT 'INJ'                                             JUNDAL_TABLE					");
		sql.append("       ,'%'                                               JUNDAL_PART    				");
		sql.append("       ,A.BUNHO                                           BUNHO							");
		sql.append("       ,A.ORDER_DATE                                      ORDER_DATE          			");
		sql.append("       ,'O'                                               IN_OUT_GUBUN          		");
		sql.append("       ,FN_BAS_LOAD_GWA_NAME(A.GWA, DATE(A.ORDER_DATE),:f_hosp_code,:f_language)  GWA	");
		sql.append("       ,A.DOCTOR                                          DOCTOR						");
		sql.append("       ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)   DOCTOR_NAME		");
		sql.append("       ,C.RESER_DATE                                      RESER_DATE					");
		sql.append("       , ''                                               COMMENTS						");
		sql.append("       ,A.JUBSU_DATE                                      JUBSU_DATE					");
		sql.append("       ,C.ACTING_DATE                                     ACT_DATE  					");
		sql.append("       ,A.PKINJ1001                                       PKINJ1001 					");
		sql.append("       ,FN_DRG_HANGMOG_NAME(:f_hosp_code,C.HANGMOG_CODE)               HANGMOG_NAME		");
		sql.append("   FROM INJ1001 A, 																		");
		sql.append("        INJ1002 C																		");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code													");
		sql.append("    AND C.HOSP_CODE   = A.HOSP_CODE														");
		sql.append("    AND C.FKINJ1001   = A.PKINJ1001														");
		sql.append("    AND A.BUNHO       = :f_bunho														");
		sql.append("    AND :f_message_gubun = '0'															");
		sql.append("  ORDER BY 9 DESC, 4 DESC																");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_message_gubun", messageGubun);
		
		List<INJ0000Q00layActDateInfo> listResult = new JpaResultMapper().list(query, INJ0000Q00layActDateInfo.class);
		return listResult;
	}

	@Override
	public List<INJ0000Q00layActingInfo> getINJ0000Q00layActingInfo(String hospCode, String language, String bunho,
			String messageGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT FN_BAS_LOAD_GWA_NAME(A.GWA, DATE(SYSDATE()),:f_hosp_code,:f_language)	");
		sql.append("       ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE(),:f_hosp_code)				");
		sql.append("       ,B.ACTING_DATE															");
		sql.append("       ,B.HANGMOG_CODE															");
		sql.append("       ,FN_DRG_HANGMOG_NAME(:f_hosp_code,B.HANGMOG_CODE),A.BUNHO				");
		sql.append("   FROM INJ1001 A ,  INJ1002 B													");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code											");
		sql.append("    AND B.HOSP_CODE      = A.HOSP_CODE											");
		sql.append("    AND A.PKINJ1001      = B.FKINJ1001											");
		sql.append("    AND B.ACTING_DATE    = :f_act_date											");
		sql.append("    AND A.BUNHO          = :f_bunho												");
		sql.append("    AND :f_message_gubun = '0'    												");
		sql.append("  ORDER BY 3 DESC																");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_message_gubun", messageGubun);
		
		List<INJ0000Q00layActingInfo> listResult = new JpaResultMapper().list(query, INJ0000Q00layActingInfo.class);
		return listResult;
	}

	@Override
	public List<INJ0000Q00layOrderInfo> getINJ0000Q00layOrderInfo(String hospCode, String language, String bunho,
			String gubun, String messageGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT 'INJ'                                             JUNDAL_TABLE					");
		sql.append("       ,'%'                                               JUNDAL_PART    				");
		sql.append("       ,A.BUNHO                                           BUNHO							");
		sql.append("       ,A.ORDER_DATE                                      ORDER_DATE          			");
		sql.append("       ,'O'                                               IN_OUT_GUBUN          		");
		sql.append("       ,FN_BAS_LOAD_GWA_NAME(A.GWA, DATE(A.ORDER_DATE),:f_hosp_code,:f_language)  GWA	");
		sql.append("       ,A.DOCTOR                                          DOCTOR						");
		sql.append("       ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)   DOCTOR_NAME		");
		sql.append("       ,C.RESER_DATE                                      RESER_DATE					");
		sql.append("       ,A.JUBSU_DATE                                      JUBSU_DATE					");
		sql.append("       ,C.ACTING_DATE                                     ACT_DATE  					");
		sql.append("       ,A.PKINJ1001                                       PKINJ1001 					");
		sql.append("       ,FN_DRG_HANGMOG_NAME(:f_hosp_code,C.HANGMOG_CODE)               HANGMOG_NAME		");
		sql.append("   FROM INJ1001 A, INJ1002 C															");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code													");
		sql.append("    AND C.HOSP_CODE   = A.HOSP_CODE														");
		sql.append("    AND C.FKINJ1001   = A.PKINJ1001														");
		sql.append("    AND A.BUNHO       = :f_bunho														");
		sql.append("    AND ((:f_gubun = '1' AND A.ACT_DATE IS NOT NULL )		                            ");
		sql.append("      OR (:f_gubun = '3' AND A.ACT_DATE IS NOT NULL )		                            ");
		sql.append("      OR (:f_gubun = '2' AND A.ACT_DATE IS NULL)         	                            ");
		sql.append("      OR (:f_gubun = '%' AND '%' = '%'))					                            ");
		sql.append("    AND :f_message_gubun = '0'								                            ");
		sql.append("  ORDER BY C.RESER_DATE, A.ORDER_DATE, C.HANGMOG_CODE		                            ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_message_gubun", messageGubun);
		
		List<INJ0000Q00layOrderInfo> listResult = new JpaResultMapper().list(query, INJ0000Q00layOrderInfo.class);
		return listResult;
	}

	@Override
	public List<INJ0000Q00layActDateInfo> getINJ0000Q00layOrderListInfo(String hospCode, String language, String bunho,
			String gubun, String messageGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT 'INJ'                                             JUNDAL_TABLE								");
		sql.append("       ,'%'                                               JUNDAL_PART    							");
		sql.append("       ,A.BUNHO                                           BUNHO										");
		sql.append("       ,A.ORDER_DATE                                      ORDER_DATE          						");
		sql.append("       ,'O'                                               IN_OUT_GUBUN          					");
		sql.append("       ,FN_BAS_LOAD_GWA_NAME(A.GWA, DATE(A.ORDER_DATE),:f_hosp_code,:f_language)  GWA				");
		sql.append("       ,A.DOCTOR                                          DOCTOR									");
		sql.append("       ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE,:f_hosp_code)   DOCTOR_NAME					");
		sql.append("       ,C.RESER_DATE                                      RESER_DATE								");
		sql.append("       ,C.SILSI_REMARK                                    COMMENTS	                                ");
		sql.append("       ,A.JUBSU_DATE                                      JUBSU_DATE                                ");
		sql.append("       ,C.ACTING_DATE                                     ACT_DATE                                  ");
		sql.append("       ,A.PKINJ1001                                       PKINJ1001                                 ");
		sql.append("       ,FN_DRG_HANGMOG_NAME(:f_hosp_code,C.HANGMOG_CODE)               HANGMOG_NAME					");
		sql.append("   FROM INJ1001 A                                                                                   ");
		sql.append("      , INJ1002 C                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                ");
		sql.append("    AND C.HOSP_CODE   = A.HOSP_CODE																	");
		sql.append("    AND A.BUNHO       = :f_bunho																	");
		sql.append("    AND C.FKINJ1001   = A.PKINJ1001   																");
		sql.append("    AND ((:f_gubun = '1' AND A.ACT_DATE IS NOT NULL )												");
		sql.append("      OR (:f_gubun = '3' AND A.ACT_DATE IS NOT NULL ) 												");
		sql.append("      OR (:f_gubun = '2' AND A.ACT_DATE IS NULL)         											");
		sql.append("      OR (:f_gubun = '%' AND '%' = '%'))															");
		sql.append("    AND :f_message_gubun = '0'																		");
		sql.append("    AND C.SILSI_REMARK IS NOT NULL																	");
		sql.append("  ORDER BY C.ACTING_DATE DESC, C.RESER_DATE DESC, A.ORDER_DATE DESC, C.GROUP_SER, C.MIX_GROUP, C.SEQ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_message_gubun", messageGubun);
		
		List<INJ0000Q00layActDateInfo> listResult = new JpaResultMapper().list(query, INJ0000Q00layActDateInfo.class);
		return listResult;
	}

}

