package nta.med.data.dao.medi.nur.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1014RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdWoiChulInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL1Info;
import nta.med.data.model.ihis.nuri.NUR1014U00grdNur1014Info;
import nta.med.data.model.ihis.nuri.NUR5020U00grdWoiInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdWoichulInfo;

/**
 * @author dainguyen.
 */
public class Nur1014RepositoryImpl implements Nur1014RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORDERTRANSGrdWoichulInfo> getORDERTRANSGrdWoichulInfo(
			String hospCode, String language, String sendYn, String bunho,
			Double pk1001, String orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.FKINP1001                                                       FKINP1001                                             ");
		sql.append("       ,A.OUT_DATE                                                        PKINP1001                                             ");
		sql.append("       ,A.BUNHO                                                           BUNHO                                                 ");
		sql.append("       ,A.OUT_DATE                                                        OUT_DATE                                              ");
		sql.append("       ,A.OUT_TIME                                                        OUT_TIME                                              ");
		sql.append("       ,A.IN_HOPE_DATE                                                    IN_HOPE_DATE                                          ");
		sql.append("       ,A.IN_HOPE_TIME                                                    IN_HOPE_TIME                                          ");
		sql.append("       ,A.IN_TRUE_DATE                                                    IN_TRUE_DATE                                          ");
		sql.append("       ,A.IN_TRUE_TIME                                                    IN_TRUE_TIME                                          ");
		sql.append("       ,FN_NUR_LOAD_CODE_NAME('OUT_OBJECT', A.OUT_OBJECT, :f_hosp_code, :f_language)                 OUT_OBJECT_TEXT            ");
		sql.append("       ,A.OUT_DATE                                                        START_DATE                                            ");
		sql.append("       ,IFNULL(A.SUNAB_IN_DATE, A.IN_TRUE_DATE)                              END_DATE                                           ");
		sql.append("       ,'Y'                                                               ACTING_YN                                             ");
		sql.append("       ,:f_send_yn                                                        SELECT_YN                                             ");
		sql.append("       , A.IF_DATA_SEND_YN                                                SEND_YN                                               ");
		sql.append("       , 0                                                                SEQ                                                   ");
		sql.append("   FROM NUR1014 A                                                                                                               ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                              ");
		sql.append("    AND A.BUNHO     = :f_bunho                                                                                                  ");
		sql.append("    AND A.FKINP1001 = :f_pk1001                                                                                                 ");
		sql.append("    AND STR_TO_DATE(:f_order_date, '%Y/%m/%d') BETWEEN  A.OUT_DATE and IFNULL(A.IN_HOPE_DATE,'9998/12/31')                      ");
		sql.append("    AND A.WOICHUL_WOIBAK_GUBUN = '02'                                                                                           ");
		sql.append("    AND IFNULL(A.IF_DATA_SEND_YN, 'N') = :f_send_yn                                                                             ");
		sql.append("    AND A.IN_TRUE_DATE IS NOT NULL                                                                                              ");
		sql.append("  ORDER BY A.OUT_DATE,A.OUT_TIME DESC																							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pk1001", pk1001);
		query.setParameter("f_order_date", orderDate);
		List<ORDERTRANSGrdWoichulInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdWoichulInfo.class);
		return list;
	}

	@Override
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase2(
			String hospCode, String language, String ioGubun, String sendYn, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT A.FKINP1001                                   FKINP1001                                                                                        ");
		sql.append("  , A.BUNHO                                              BUNHO                                                                                                  ");
		sql.append("  , C.SUNAME                                             SUNAME                                                                                                 ");
		sql.append("  , B.IPWON_DATE                                         IPWON_DATE                                                                                             ");
		sql.append("  , B.IPWON_TIME                                         IPWON_TIME                                                                                             ");
		sql.append("  , B.GWA                                                GWA                                                                                                    ");
		sql.append("  , B.DOCTOR                                             DOCTOR                                                                                                 ");
		sql.append("  , FN_BAS_LOAD_GWA_NAME (B.GWA, B.IPWON_DATE, :f_hosp_code,:f_language )          GWA_NAME                                                                     ");
		sql.append("  , FN_BAS_LOAD_DOCTOR_NAME ( B.DOCTOR, B.IPWON_DATE , :f_hosp_code)    DOCTOR_NAME                                                                             ");
		sql.append("  , D.GUBUN                                                                                                                                                     ");
		sql.append("  , E.GUBUN_NAME                                         GUBUN_NAME                                                                                             ");
		sql.append("  , IFNULL(E.GONGBI_YN,'Y')                                 GONGBI_YN                                                                                           ");
		sql.append("  , B.CHOJAE                                                                                                                                                    ");
		sql.append("  , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE ,:f_hosp_code,:f_language)           CHOJAE_NAME                                                                   ");
		sql.append("  , D.PKINP1002                                                                                                                                                 ");
		sql.append("  , A.OUT_DATE                                           ACTING_DATE                                                                                            ");
		sql.append("  , A.OUT_DATE                                           ORDER_DATE                                                                                             ");
		sql.append("  , D.GUBUN                                              GUBUN_OLD                                                                                              ");
		sql.append("  , B.CHOJAE                                             CHOJAE_OLD                                                                                             ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 1)   GONGBI_CODE1                                             ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 2)   GONGBI_CODE2                                             ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 3)   GONGBI_CODE3                                             ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 4)   GONGBI_CODE4                                             ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 1), A.OUT_DATE, :f_language) GONGBI_CODE1_NAME     ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 2), A.OUT_DATE, :f_language) GONGBI_CODE2_NAME     ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 3), A.OUT_DATE, :f_language) GONGBI_CODE3_NAME     ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.OUT_DATE, 4), A.OUT_DATE, :f_language) GONGBI_CODE4_NAME     ");
		sql.append("  , A.FKINP1001                                          PKOUT                                                                                                  ");
		sql.append("  , A.IF_DATA_SEND_DATE                                  SEND_DATE                                                                                              ");
		sql.append("  , '1'                                                  SANJUNG_GUBUN                                                                                          ");
		sql.append("  , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1',:f_hosp_code,:f_language )          SANJUNG_GUBUN_NAME                                                   ");
		sql.append("  ,CASE FN_OUT_LOAD_JUBSU_GUBUN_VALID(:f_hosp_code, A.BUNHO, D.GUBUN, A.OUT_DATE) WHEN 'N' THEN '1' ELSE '0' END IF_VALID_YN                                    ");
		sql.append("  FROM NUR1014 A                                                                                                                                                ");
		sql.append("   , INP1001 B                                                                                                                                                  ");
		sql.append("   , OUT0101 C                                                                                                                                                  ");
		sql.append("   , INP1002 D                                                                                                                                                  ");
		sql.append("   , BAS0210 E                                                                                                                                                  ");
		sql.append("    WHERE A.HOSP_CODE  = :f_hosp_code                                                                                                                           ");
		sql.append("    AND A.BUNHO  LIKE :f_bunho                                                                                                                                  ");
		sql.append("    AND A.WOICHUL_WOIBAK_GUBUN       = '02'                                                                                                                     ");
		sql.append("    AND IFNULL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn                                                                                                            ");
		sql.append("    AND A.IN_TRUE_DATE IS NOT NULL                                                                                                                              ");
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                                                                                             ");
		sql.append("    AND B.BUNHO       = A.BUNHO                                                                                                                                 ");
		sql.append("    AND B.PKINP1001   = A.FKINP1001                                                                                                                             ");
		sql.append("    AND C.HOSP_CODE   = A.HOSP_CODE                                                                                                                             ");
		sql.append("    AND C.BUNHO       = A.BUNHO                                                                                                                                 ");
		sql.append("    AND D.HOSP_CODE   = A.HOSP_CODE                                                                                                                             ");
		sql.append("    AND D.BUNHO       = A.BUNHO                                                                                                                                 ");
		sql.append("    AND D.FKINP1001   = A.FKINP1001                                                                                                                             ");
		sql.append("    AND E.GUBUN       = D.GUBUN   AND E.LANGUAGE = :f_language                                                                                                  ");
		sql.append("    AND B.IPWON_DATE BETWEEN E.START_DATE                                                                                                                       ");
		sql.append("                      AND IFNULL(E.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                                                 ");
		sql.append("    ORDER BY B.IPWON_DATE 																																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_bunho", bunho + "%");
		List<ORDERTRANSGrdListInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdListInfo.class);
		return list;
	}

	@Override
	public List<INPORDERTRANSGrdWoiChulInfo> getINPORDERTRANSGrdWoiChulInfo(String hospCode, String language,
			String sendYn, String bunho, Date firstDate, Date lastDate, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.FKINP1001                                                       FKINP1001                                     ");
		sql.append("          ,A.OUT_DATE                                                        FKINP1001_2                                ");
		sql.append("          ,A.BUNHO                                                           BUNHO                                      ");
		sql.append("          ,A.OUT_DATE                                                        OUT_DATE                                   ");
		sql.append("          ,A.OUT_TIME                                                        OUT_TIME                                   ");
		sql.append("          ,A.IN_HOPE_DATE                                                    IN_HOPE_DATE                               ");
		sql.append("          ,A.IN_HOPE_TIME                                                    IN_HOPE_TIME                               ");
		sql.append("          ,A.IN_TRUE_DATE                                                    IN_TRUE_DATE                               ");
		sql.append("          ,A.IN_TRUE_TIME                                                    IN_TRUE_TIME                               ");
		sql.append("          ,FN_NUR_LOAD_CODE_NAME('OUT_OBJECT', A.OUT_OBJECT, :f_hosp_code, :f_language)           OUT_OBJECT_TEXT       ");
		sql.append("          ,A.OUT_DATE                                                        START_DATE                                 ");
		sql.append("          ,IFNULL(A.SUNAB_IN_DATE, A.IN_TRUE_DATE)                              END_DATE                                ");
		sql.append("          ,'Y'                                                               ACTING_YN                                  ");
		sql.append("          ,:f_send_yn                                                        SELECT_YN                                  ");
		sql.append("          , A.IF_DATA_SEND_YN                                                SEND_YN                                    ");
		sql.append("          , 0                                                                SEQ                                        ");
		sql.append("      FROM NUR1014 A                                                                                                    ");
		sql.append("     WHERE A.HOSP_CODE = :f_hosp_code                                                                                   ");
		sql.append("       AND A.BUNHO     = :f_bunho                                                                                       ");
		sql.append("       AND A.OUT_DATE BETWEEN :first_date AND :last_date                                                                ");
		sql.append("       AND A.WOICHUL_WOIBAK_GUBUN = '02'                                                                                ");
		sql.append("       AND A.IN_TRUE_DATE IS NOT NULL                                                                                   ");
		sql.append("     ORDER BY A.OUT_DATE,A.OUT_TIME DESC																				");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_bunho", bunho);
		query.setParameter("first_date", firstDate);
		query.setParameter("last_date", lastDate);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		List<INPORDERTRANSGrdWoiChulInfo> list = new JpaResultMapper().list(query, INPORDERTRANSGrdWoiChulInfo.class);
		return list;
	}

	@Override
	public List<INPORDERTRANSSelectListSQL1Info> getINPORDERTRANSSelectListSQL2(String hospCode, String language,
			String bunho, Date firstDate, Date lastDate, String fnNutYyyymm) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT B.PKINP1001                                                    FKINP1001                                           ");
		sql.append("   , A.BUNHO                                                               BUNHO                                                    ");
		sql.append("   , C.SUNAME                                                              SUNAME                                                   ");
		sql.append("   , B.IPWON_DATE                                                          IPWON_DATE                                               ");
		sql.append("   , B.IPWON_TIME                                                          IPWON_TIME                                               ");
		sql.append("   , B.GWA                                                                 GWA                                                      ");
		sql.append("   , F.ORG_DOCTOR                                                          DOCTOR                                                   ");
		sql.append("   , FN_BAS_LOAD_GWA_NAME (B.GWA, A.OUT_DATE, :hosp_code, :language )      GWA_NAME                                                 ");
		sql.append("   , FN_BAS_LOAD_DOCTOR_NAME (CONCAT(B.GWA,F.ORG_DOCTOR), A.OUT_DATE, :hosp_code)             DOCTOR_NAME                           ");
		sql.append("   , MAX(FN_BAS_LOAD_GWA_NAME(D.TO_HO_DONG1, A.OUT_DATE,:hosp_code, :language))                  HO_DONG                            ");
		sql.append("   , MAX(D.TO_HO_CODE1)                                                    HO_CODE                                                  ");
		sql.append("   , MAX(STR_TO_DATE(FN_NUT_GET_IFS_PROC_DATE(A.HOSP_CODE, A.FKINP1001, A.BUNHO, :f_yyyymm, :hosp_code), '%Y%m%d') )  SEND_DATE     ");
		sql.append("   , MAX(FN_OCSI_GAIHAKU_TRANSFER_CHK(:hosp_code, A.BUNHO, A.FKINP1001))               TRANS_YN                                     ");
		sql.append("   FROM NUR1014 A                                                                                                                   ");
		sql.append("         , INP1001 B                                                                                                                ");
		sql.append("         , OUT0101 C                                                                                                                ");
		sql.append("         , VW_OCS_INP2004 D                                                                                                         ");
		sql.append("         , BAS0270 F                                                                                                                ");
		sql.append("   WHERE A.HOSP_CODE      = :hosp_code                                                                                              ");
		sql.append("   AND A.BUNHO       LIKE :bunho                                                                                                    ");
		sql.append("   AND A.OUT_DATE BETWEEN :first_date AND :last_date                                                                                ");
		sql.append("   AND A.WOICHUL_WOIBAK_GUBUN       = '02'                                                                                          ");
		sql.append("   AND A.IN_TRUE_DATE IS NOT NULL                                                                                                   ");
		sql.append("   AND B.HOSP_CODE       = A.HOSP_CODE                                                                                              ");
		sql.append("   AND B.BUNHO           = A.BUNHO                                                                                                  ");
		sql.append("   AND B.PKINP1001       = A.FKINP1001                                                                                              ");
		sql.append("   AND C.HOSP_CODE       = A.HOSP_CODE                                                                                              ");
		sql.append("   AND C.BUNHO           = A.BUNHO                                                                                                  ");
		sql.append("   AND D.HOSP_CODE       = A.HOSP_CODE                                                                                              ");
		sql.append("   AND D.BUNHO           = A.BUNHO                                                                                                  ");
		sql.append("   AND D.JAEWON_DATE     = A.OUT_DATE                                                                                               ");
		sql.append("   AND F.HOSP_CODE       = B.HOSP_CODE                                                                                              ");
		sql.append("   AND F.DOCTOR          = B.DOCTOR                                                                                                 ");
		sql.append("     GROUP BY B.PKINP1001                                                                                                           ");
		sql.append("            , A.BUNHO                                                                                                               ");
		sql.append("            , C.SUNAME                                                                                                              ");
		sql.append("            , B.IPWON_DATE                                                                                                          ");
		sql.append("            , B.IPWON_TIME                                                                                                          ");
		sql.append("            , B.GWA                                                                                                                 ");
		sql.append("            , F.ORG_DOCTOR                                                                                                          ");
		sql.append("            , FN_BAS_LOAD_GWA_NAME (B.GWA, A.OUT_DATE,:hosp_code, :language )                                                       ");
		sql.append("            , FN_BAS_LOAD_DOCTOR_NAME (CONCAT(B.GWA,F.ORG_DOCTOR), A.OUT_DATE, :hosp_code)                                          ");
		sql.append("            , CASE B.TOIWON_DATE WHEN NULL THEN 'N' ELSE 'Y' END																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_yyyymm", fnNutYyyymm);
		query.setParameter("bunho", bunho);
		query.setParameter("first_date", firstDate);
		query.setParameter("last_date", lastDate);
		List<INPORDERTRANSSelectListSQL1Info> list = new JpaResultMapper().list(query, INPORDERTRANSSelectListSQL1Info.class);
		return list;
	}
	
	@Override
	public List<NUR1014U00grdNur1014Info> getNUR1014U00grdNur1014Info(String hospCode, String bunho, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.BUNHO                         BUNHO                                   ");
		sql.append("         ,A.FKINP1001                 FKINP1001                                   ");
		sql.append("         ,DATE_FORMAT(A.OUT_DATE, '%Y/%m/%d')                   OUT_DATE          ");
		sql.append("         ,A.OUT_TIME                  OUT_TIME                                    ");
		sql.append("         ,DATE_FORMAT(A.IN_HOPE_DATE, '%Y/%m/%d')         IN_HOPE_DATE            ");
		sql.append("         ,A.IN_HOPE_TIME         IN_HOPE_TIME                                     ");
		sql.append("         ,DATE_FORMAT(A.IN_TRUE_DATE, '%Y/%m/%d')         IN_TRUE_DATE            ");
		sql.append("         ,A.IN_TRUE_TIME         IN_TRUE_TIME                                     ");
		sql.append("         ,DATE_FORMAT(A.NUT_START_DATE,'%Y/%m/%d') NUT_START_DATE                 ");
		sql.append("         ,A.NUT_START_KINI NUT_START_KINI                                         ");
		sql.append("         ,DATE_FORMAT(A.NUT_END_DATE, '%Y/%m/%d')   NUT_END_DATE                  ");
		sql.append("         ,A.NUT_END_KINI   NUT_END_KINI                                           ");
		sql.append("         ,A.OUT_OBJECT                                                            ");
		sql.append("         ,A.WOICHUL_WOIBAK_GUBUN                                                  ");
		sql.append("         ,A.NUT_END_YN                                                            ");
		sql.append("         ,A.DEST_ISHOME                                                           ");
		sql.append("         ,A.DEST_ADDR                                                             ");
		sql.append("         ,A.DEST_TEL                                                              ");
		sql.append("         ,'' FLAG                                                              	  ");
		sql.append("         ,'' DATA_ROW_STATE                                                       ");
		sql.append("     FROM NUR1014 A                                                               ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                              ");
		sql.append("      AND A.BUNHO     = :f_bunho                                                  ");
		sql.append("    ORDER BY A.OUT_DATE DESC                                                      ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset												  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1014U00grdNur1014Info> list = new JpaResultMapper().list(query, NUR1014U00grdNur1014Info.class);
		return list;
	}
	
	@Override
	public String getNUR1014U00ValidationCheck(String hospCode, String bunho, String outDate, String outTime, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                                                                             ");
		sql.append("    FROM DUAL                                                                                                                             ");
		sql.append("    WHERE EXISTS (SELECT 'X'                                                                                                              ");
		sql.append("                    FROM NUR1014                                                                                                          ");
		sql.append("                   WHERE HOSP_CODE = :f_hosp_code                                                                                         ");
		sql.append("                     AND BUNHO     = :f_bunho                                                                                             ");
		sql.append("                     AND FKINP1001 = :f_fkinp1001                                                                                         ");
		sql.append("                     AND STR_TO_DATE(:f_out_date_time, '%Y/%m/%d %H%i')                                                                   ");
		sql.append("                         BETWEEN STR_TO_DATE(CONCAT(DATE_FORMAT(OUT_DATE, '%Y/%m/%d'),' ',OUT_TIME), '%Y/%m/%d %H%i')                     ");
		sql.append("                         AND     IFNULL(STR_TO_DATE(CONCAT(DATE_FORMAT(IN_TRUE_DATE, '%Y/%m/%d'), ' ', IN_TRUE_TIME), '%Y/%m/%d %H%i'),   ");
		sql.append("                                 STR_TO_DATE(CONCAT(DATE_FORMAT(IN_HOPE_DATE, '%Y/%m/%d'), ' ',IN_HOPE_TIME), '%Y/%m/%d %H%i')))          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_out_date_time", outDate + " " + outTime);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list) && list.size() > 0){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public ComboListItemInfo callPrInpJaewonRangeCheck(String hospCode, Double fkinp1001, String startDate, String startTime,
			String endDate, String endTime){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_JAEWON_RANGE_CHECK");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_START_DATE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_START_TIME", String.class, ParameterMode.IN);		
		query.registerStoredProcedureParameter("I_END_DATE", String.class, ParameterMode.IN);           	
	    query.registerStoredProcedureParameter("I_END_TIME", String.class, ParameterMode.IN); 
	    
	    query.registerStoredProcedureParameter("O_FLAG", String.class, ParameterMode.OUT);      
	    query.registerStoredProcedureParameter("O_MSG", String.class, ParameterMode.OUT); 
	    
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_FKINP1001", fkinp1001);
		query.setParameter("I_START_DATE", startDate);
		query.setParameter("I_START_TIME", startTime);
		query.setParameter("I_END_DATE", endDate);
		query.setParameter("I_END_TIME", endTime);
		query.execute();
		ComboListItemInfo result = new ComboListItemInfo( (String)query.getOutputParameterValue("O_FLAG")                                                 
		          ,(String)query.getOutputParameterValue("O_MSG")                                           
		          );
		return result;
	}
	
	@Override
	public List<NUR5020U00grdWoiInfo> getNUR5020U00grdWoiInfo(String hospCode, String hoDong, String date, String language, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT '' PKNUR5023                                                                                                         ");
		sql.append("          , :f_date NUR_WRDT                                                                                                   ");
		sql.append("          , :f_ho_dong   HO_DONG                                                                                               ");
		sql.append("          , A.WOICHUL_WOIBAK_GUBUN                                                   DETAIL_GUBUN                              ");
		sql.append("          , FN_NUR_LOAD_CODE_NAME('WOICHUL_WOPIBAK_GUBUN', A.WOICHUL_WOIBAK_GUBUN, A.HOSP_CODE, :f_language)   GUBUN_NAME      ");
		sql.append("          , A.BUNHO                                                                  BUNHO                                     ");
		sql.append("          , FN_OUT_LOAD_SUNAME(A.BUNHO, A.HOSP_CODE)                                              SUNAME                       ");
		sql.append("          , FN_INP_LOAD_HO_CODE_HISTORY(A.HOSP_CODE, A.BUNHO, STR_TO_DATE(:f_date, '%Y/%m/%d'))   HO_CODE                      ");
		sql.append("          , DATE_FORMAT(A.OUT_DATE, '%Y/%m/md')                                     DATE1                                      ");
		sql.append("          , A.OUT_TIME                                                               TIME1                                     ");
		sql.append("          , DATE_FORMAT(IFNULL(A.IN_TRUE_DATE, A.IN_HOPE_DATE), '%Y/%m/%d')          DATE2                                     ");
		sql.append("          , IFNULL(A.IN_TRUE_TIME, A.IN_HOPE_TIME)                                      TIME2                                  ");
		sql.append("          , ''                                                                       BIGO                                      ");
		sql.append("          , ''                                                                       JAPAN_DATE1                               ");
		sql.append("          , ''                                                                       JAPAN_DATE2                               ");
		sql.append("          , ''                                                                       DATA_ROW_STATE                            ");
		sql.append("       FROM NUR1014 A                                                                                                          ");
		sql.append("       JOIN INP1001 B                                                                                                          ");
		sql.append("         ON B.HOSP_CODE = A.HOSP_CODE                                                                                          ");
		sql.append("        AND B.PKINP1001 = A.FKINP1001                                                                                          ");
		sql.append("        AND B.JAEWON_FLAG = 'Y'                                                                                                ");
		sql.append("      WHERE A.HOSP_CODE = :f_hosp_code                                                                                         ");
		sql.append("        AND STR_TO_DATE(:f_date, '%Y/%m/%d') BETWEEN A.OUT_DATE                                                                ");
		sql.append("                           AND IFNULL(A.IN_HOPE_DATE, IFNULL(A.IN_TRUE_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d')))           ");
		sql.append("        AND CASE(B.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(B.CANCEL_YN, 'N') END = 'N'                                         ");
		sql.append("        AND B.KAIKEI_HODONG  = :f_ho_dong                                                                                      ");
		sql.append("        AND B.IPWON_TYPE IN ('0', '1')                                                                                         ");
		sql.append("        ORDER BY A.WOICHUL_WOIBAK_GUBUN, OUT_DATE, OUT_TIME                                                                    ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset												  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_language", language);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR5020U00grdWoiInfo> list = new JpaResultMapper().list(query, NUR5020U00grdWoiInfo.class);
		return list;
	}
}

