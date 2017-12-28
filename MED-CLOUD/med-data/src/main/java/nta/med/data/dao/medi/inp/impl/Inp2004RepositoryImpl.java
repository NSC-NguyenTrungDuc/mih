package nta.med.data.dao.medi.inp.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.lang3.StringUtils;
import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp2004RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INP2004Q00grdINP2004Info;
import nta.med.data.model.ihis.inps.INP2004Q01grdINP2004Info;
import nta.med.data.model.ihis.nuri.NUR1001R07grdInp2004Info;
import nta.med.data.model.ihis.nuri.NUR1010Q00layConfirmDataInfo;
import nta.med.data.model.ihis.nuri.NUR2004U00GetInitJunipInfo;
import nta.med.data.model.ihis.nuri.NUR2004U01GetConfirmDataInfo;
import nta.med.data.model.ihis.nuri.NUR2004U01grdInp2004Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdINP2004Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;

/**
 * @author dainguyen.
 */
public class Inp2004RepositoryImpl implements Inp2004RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORDERTRANSGrdINP2004Info> getORDERTRANSGrdINP2004Info(
			String hospCode, String bunho, String sendYn, String actingDate,
			String sunabdate, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO BUNHO                                                                                                                                               ");
		sql.append("     , FN_OUT_LOAD_SUNAME(A.BUNHO, :f_hosp_code) SUNAME                                                                                                             ");
		sql.append("     , B.IPWON_DATE IPWON_DATE                                                                                                                                      ");
		sql.append("     , A.START_DATE DATA_DATE                                                                                                                                       ");
		sql.append("     , A.FKINP1001  FKINP1001                                                                                                                                       ");
		sql.append("     , C.PKINP1002  PKINP1002                                                                                                                                       ");
		sql.append("     , A.FROM_GWA                                                                                                                                                   ");
		sql.append("     , A.TO_GWA                                                                                                                                                     ");
		sql.append("     , A.FROM_DOCTOR                                                                                                                                                ");
		sql.append("     , A.TO_DOCTOR                                                                                                                                                  ");
		sql.append("     , A.FROM_HO_DONG1                                                                                                                                              ");
		sql.append("     , A.TO_HO_DONG1                                                                                                                                                ");
		sql.append("     , A.FROM_HO_CODE1                                                                                                                                              ");
		sql.append("     , A.TO_HO_CODE1                                                                                                                                                ");
		sql.append("     , A.FROM_BED_NO                                                                                                                                                ");
		sql.append("     , A.TO_BED_NO                                                                                                                                                  ");
		sql.append("     , IFNULL(A.IF_DATA_SEND_YN, 'N') SEND_YN                                                                                                                       ");
		sql.append("     , ''                IF_FLAG                                                                                                                                    ");
		sql.append("  FROM INP2004 A, INP1001 B, INP1002 C                                                                                                                              ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                                   ");
		sql.append(" AND A.BUNHO  LIKE :f_bunho                                                                                                                                         ");
		sql.append(" AND IFNULL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn                                                                                                                   ");
		sql.append(" AND A.START_DATE = STR_TO_DATE(:f_acting_date, '%Y/%m/%d')                                                                                                         ");
		sql.append(" AND STR_TO_DATE(:f_sunab_date, '%Y/%m/%d') BETWEEN C.GUBUN_IPWON_DATE AND IFNULL(C.GUBUN_TOIWON_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))                       ");          
		sql.append(" AND A.FKINP1001 = :f_fkinp1001                                                                                                                                     ");
		sql.append(" AND A.TRANS_CNT != 1                                                                                                                                               ");
		sql.append(" AND B.HOSP_CODE = A.HOSP_CODE                                                                                                                                      ");
		sql.append(" AND B.BUNHO = A.BUNHO                                                                                                                                              ");
		sql.append(" AND B.PKINP1001 = A.FKINP1001                                                                                                                                      ");
		sql.append(" AND C.HOSP_CODE = A.HOSP_CODE                                                                                                                                      ");
		sql.append(" AND C.BUNHO     = A.BUNHO                                                                                                                                          ");
		sql.append(" AND C.FKINP1001 = A.FKINP1001                                                                                                                                      ");
		sql.append(" AND C.FKINP1001 = C.FKINP1001                                                                                                                                      ");
		sql.append(" AND ( A.FROM_GWA != A.TO_GWA                                                                                                                                       ");
		sql.append("    OR                                                                                                                                                              ");
		sql.append("    A.FROM_DOCTOR != A.TO_DOCTOR                                                                                                                                    ");
		sql.append("    OR                                                                                                                                                              ");
		sql.append("    A.FROM_HO_DONG1 != A.TO_HO_DONG1                                                                                                                                ");
		sql.append("    OR                                                                                                                                                              ");
		sql.append("    A.FROM_HO_CODE1 != A.TO_HO_CODE1                                                                                                                                ");
		sql.append("  )                                                                                                                                                                 ");
		sql.append("  AND IFNULL(IF_DATA_SEND_YN, 'N') = 'N'																															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho + "%");
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_acting_date", actingDate);
		query.setParameter("f_sunab_date", sunabdate);
		query.setParameter("f_fkinp1001", fkinp1001);
		List<ORDERTRANSGrdINP2004Info> list = new JpaResultMapper().list(query, ORDERTRANSGrdINP2004Info.class);
		return list;
	}

	@Override
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase3(
			String hospCode, String language, String ioGubun, String sendYn,
			String bunho, String actingDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT  A.FKINP1001                                  FKINP1001                                                                                            ");
		sql.append("  , A.BUNHO                                              BUNHO                                                                                                      ");
		sql.append("  , C.SUNAME                                             SUNAME                                                                                                     ");
		sql.append("  , B.IPWON_DATE                                         IPWON_DATE                                                                                                 ");
		sql.append("  , B.IPWON_TIME                                         IPWON_TIME                                                                                                 ");
		sql.append("  , B.GWA                                                GWA                                                                                                        ");
		sql.append("  , B.DOCTOR                                             DOCTOR                                                                                                     ");
		sql.append("  , FN_BAS_LOAD_GWA_NAME (B.GWA, B.IPWON_DATE,:f_hosp_code,:f_language )          GWA_NAME                                                                          ");
		sql.append("  , FN_BAS_LOAD_DOCTOR_NAME ( B.DOCTOR, B.IPWON_DATE, :f_hosp_code)    DOCTOR_NAME                                                                                  ");
		sql.append("  , D.GUBUN                                                                                                                                                         ");
		sql.append("  , E.GUBUN_NAME                                         GUBUN_NAME                                                                                                 ");
		sql.append("  , IFNULL(E.GONGBI_YN,'Y')                                 GONGBI_YN                                                                                               ");
		sql.append("  , B.CHOJAE                                                                                                                                                        ");
		sql.append("  , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE ,:f_hosp_code,:f_language)           CHOJAE_NAME                                                                       ");
		sql.append("  , D.PKINP1002                                                                                                                                                     ");
		sql.append("  , A.START_DATE                                         ACTING_DATE                                                                                                ");
		sql.append("  , A.START_DATE                                         ORDER_DATE                                                                                                 ");
		sql.append("  , D.GUBUN                                              GUBUN_OLD                                                                                                  ");
		sql.append("  , B.CHOJAE                                             CHOJAE_OLD                                                                                                 ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 1)   GONGBI_CODE1                                               ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 2)   GONGBI_CODE2                                               ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 3)   GONGBI_CODE3                                               ");
		sql.append("  , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 4)   GONGBI_CODE4                                               ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 1), A.START_DATE, :f_language) GONGBI_CODE1_NAME     ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 2), A.START_DATE, :f_language) GONGBI_CODE2_NAME     ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 3), A.START_DATE, :f_language) GONGBI_CODE3_NAME     ");
		sql.append("  , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, A.START_DATE, 4), A.START_DATE, :f_language) GONGBI_CODE4_NAME     ");
		sql.append("  , ''                                                   PKOUT                                                                                                      ");
		sql.append("  , A.IF_DATA_SEND_DATE                                  SEND_DATE                                                                                                  ");
		sql.append("  , '1'                                                  SANJUNG_GUBUN                                                                                              ");
		sql.append("  , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1' , :f_hosp_code,:f_language)          SANJUNG_GUBUN_NAME                                                      ");
		sql.append("  ,CASE FN_OUT_LOAD_JUBSU_GUBUN_VALID(:f_hosp_code, A.BUNHO, D.GUBUN, A.START_DATE) WHEN 'N' THEN '1' ELSE '0' END IF_VALID_YN                                      ");
		sql.append("   FROM INP2004 A                                                                                                                                                   ");
		sql.append("      , INP1001 B                                                                                                                                                   ");
		sql.append("      , OUT0101 C                                                                                                                                                   ");
		sql.append("      , INP1002 D                                                                                                                                                   ");
		sql.append("      , BAS0210 E                                                                                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                                                ");
		sql.append("    AND A.BUNHO  LIKE :f_bunho                                                                                                                                      ");
		sql.append("    AND IFNULL(A.IF_DATA_SEND_YN, 'N' ) = :f_send_yn                                                                                                                ");
		sql.append("    AND A.TRANS_CNT != 1                                                                                                                                            ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                                                                                   ");
		sql.append("    AND B.BUNHO     = A.BUNHO                                                                                                                                       ");
		sql.append("    AND B.PKINP1001 = A.FKINP1001                                                                                                                                   ");
		sql.append("    AND C.HOSP_CODE = A.HOSP_CODE                                                                                                                                   ");
		sql.append("    AND C.BUNHO     = A.BUNHO                                                                                                                                       ");
		sql.append("    AND D.HOSP_CODE = A.HOSP_CODE                                                                                                                                   ");
		sql.append("    AND D.BUNHO     = A.BUNHO                                                                                                                                       ");
		sql.append("    AND D.FKINP1001 = A.FKINP1001                                                                                                                                   ");
		sql.append("    AND STR_TO_DATE(:f_acting_date, '%Y/%m/%d') BETWEEN D.GUBUN_IPWON_DATE AND IFNULL(D.GUBUN_TOIWON_DATE,STR_TO_DATE('9998/12/31','%Y/%m/%d'))                     ");
		sql.append("    AND ( A.FROM_GWA != A.TO_GWA                                                                                                                                    ");
		sql.append("          OR                                                                                                                                                        ");
		sql.append("          A.FROM_DOCTOR != A.TO_DOCTOR                                                                                                                              ");
		sql.append("          OR                                                                                                                                                        ");
		sql.append("          A.FROM_HO_DONG1 != A.TO_HO_DONG1                                                                                                                          ");
		sql.append("          OR                                                                                                                                                        ");
		sql.append("          A.FROM_HO_CODE1 != A.TO_HO_CODE1                                                                                                                          ");
		sql.append("        )                                                                                                                                                           ");
		sql.append("     AND A.HOSP_CODE   = E.HOSP_CODE                                                                                                                                ");
		sql.append("     AND E.GUBUN       = D.GUBUN   AND E.LANGUAGE = :f_language                                                                                                     ");
		sql.append("     AND B.IPWON_DATE BETWEEN E.START_DATE                                                                                                                          ");
		sql.append("                       AND IFNULL(E.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                                                    ");
		sql.append("    ORDER BY B.IPWON_DATE, A.START_DATE DESC																														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hosp_code", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_bunho", bunho + "%");
		query.setParameter("f_acting_date", actingDate);
		List<ORDERTRANSGrdListInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdListInfo.class);
		return list;
	}

	@Override
	public List<INP2004Q01grdINP2004Info> getListINP2004Q01grdINP2004Info(String hospCode, Date fromDate, Date toDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT   A.FKINP1001																");
		sql.append("	       , A.BUNHO																	");
		sql.append("	       , C.SUNAME                                               SUNAME				");
		sql.append("	       , C.SEX                                                  SEX					");
		sql.append("	       , CAST(FN_BAS_LOAD_AGE(SYSDATE(), C.BIRTH, '') AS CHAR)  AGE					");
		sql.append("	       , IFNULL(DATE_FORMAT(C.BIRTH, '%Y/%m/%d'), '')           BIRTH				");
		sql.append("	       , IFNULL(DATE_FORMAT(A.START_DATE, '%Y/%m/%d'), '')      START_DATE			");
		sql.append("	       , A.FROM_HO_DONG1															");
		sql.append("	       , A.FROM_HO_CODE1															");
		sql.append("	       , IFNULL(A.FROM_BED_NO, '入院')                        						");
		sql.append("	       , A.TO_HO_DONG1																");
		sql.append("	       , A.TO_HO_CODE1																");
		sql.append("	       , A.TO_BED_NO																");
		sql.append("	       , IFNULL(DATE_FORMAT(B.IPWON_DATE, '%Y/%m/%d'), '')      IPWON_DATE			");
		sql.append("	       , IFNULL(DATE_FORMAT(B.TOIWON_DATE, '%Y/%m/%d'), '')     TOIWON_DATE			");
		sql.append("	FROM INP2004 A																		");
		sql.append("	JOIN INP1001 B ON A.HOSP_CODE = B.HOSP_CODE											");
		sql.append("	              AND A.FKINP1001 = B.PKINP1001											");
		sql.append("	JOIN OUT0101 C ON A.HOSP_CODE = C.HOSP_CODE											");
		sql.append("	              AND A.BUNHO     = C.BUNHO												");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code													");
		sql.append("	 AND																				");
		sql.append("	     (																				");
		sql.append("	            (																		");
		sql.append("	                   A.FROM_HO_DONG1 <> A.TO_HO_DONG1									");
		sql.append("	                OR A.FROM_HO_CODE1 <> A.TO_HO_CODE1									");
		sql.append("	                OR A.FROM_BED_NO   <> A.TO_BED_NO									");
		sql.append("	            )																		");
		sql.append("	         OR																			");
		sql.append("	            (																		");
		sql.append("	                   A.TRANS_CNT = 1													");
		sql.append("	            )																		");
		sql.append("	     )																				");
		sql.append("	 AND																				");
		sql.append("	     (																				");
		sql.append("	            A.START_DATE BETWEEN :f_from_date AND :f_to_date						");
		sql.append("	         OR B.TOIWON_DATE BETWEEN :f_from_date AND :f_to_date						");
		sql.append("	     )																				");
		sql.append("	  AND A.BUNHO NOT LIKE '09999%'														");
		sql.append("	ORDER BY A.TO_HO_DONG1, A.BUNHO, A.TRANS_CNT										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<INP2004Q01grdINP2004Info> lstResult = new JpaResultMapper().list(query, INP2004Q01grdINP2004Info.class);
		return lstResult;
	}

	@Override
	public List<INP2004Q00grdINP2004Info> getListINP2004Q00grdINP2004Info(String hospCode, String hoDong, String hoCode,
			String fromDate, String toDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT B.PKINP1001                                    PKINP1001											");
		sql.append("     , A.BUNHO                                          BUNHO												");
		sql.append("     , C.SUNAME                                         SUNAME												");
		sql.append("     , C.SEX                                            SEX													");
		sql.append("     , FN_BAS_LOAD_AGE( SYSDATE(), C.BIRTH, '')         AGE													");
		sql.append("     , C.BIRTH                                          BIRTH												");
		sql.append("     , A.TO_BED_NO                                      BED_NO												");
		sql.append("     , B.IPWON_DATE                                     IPWON_DATE											");
		sql.append("     , B.TOIWON_DATE                                    TOIWON_DATE											");
		sql.append("     , A.START_DATE                                     ORDER_DATE											");
		sql.append("  FROM INP2004 A JOIN OUT0101 C 																			");
		sql.append("                  ON  C.HOSP_CODE = A.HOSP_CODE																");
		sql.append("                  AND C.BUNHO     = A.BUNHO																	");
		sql.append("                 JOIN INP1001 B																				");
		sql.append("                  ON  B.HOSP_CODE = A.HOSP_CODE																");
		sql.append("                  AND B.PKINP1001 = A.FKINP1001																");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code																			");
		sql.append("     AND A.TO_HO_DONG1 = :f_ho_dong																			");
		sql.append("     AND A.TO_HO_CODE1 = :f_ho_code																			");
		sql.append("     AND A.START_DATE BETWEEN DATE_FORMAT(:f_from_date, '%Y/%m/%d') AND DATE_FORMAT(:f_to_date, '%Y/%m/%d')	");
		sql.append("     AND IFNULL(A.CANCEL_YN,'N') = 'N'																		");
		sql.append("     AND ( (A.TRANS_CNT  = 1)  OR   ( A.TRANS_CNT <> 1 AND A.TO_NURSE_CONFIRM_DATE IS NOT NULL) )			");
		sql.append("   ORDER BY A.START_DATE, B.IPWON_DATE																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_ho_code", hoCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<INP2004Q00grdINP2004Info> lstResult = new JpaResultMapper().list(query, INP2004Q00grdINP2004Info.class);
		return lstResult;
	}
	
	@Override
	public List<NUR2004U01grdInp2004Info> getNUR2004U01grdInp2004Info(String hospCode, String hoDong, String orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.FROMTO_GUBUN                                                                                                          ");
		sql.append("        , CASE(A.FROMTO_GUBUN) WHEN 'TO' THEN '' ELSE A.BUNHO END                                                                 ");
		sql.append("        , B.SUNAME                                                                                                                ");
		sql.append("        , A.START_DATE                                                                                                            ");
		sql.append("        , A.GWA                                                                                                                   ");
		sql.append("        , A.DOCTOR                                                                                                                ");
		sql.append("        , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, SYSDATE(), A.HOSP_CODE) DOCTOR_NAME                                                   ");
		sql.append("        , A.HO_DONG                                                                                                               ");
		sql.append("        , A.HO_CODE                                                                                                               ");
		sql.append("        , A.BED_NO                                                                                                                ");
		sql.append("        , A.KAIKEI_HODONG                                                                                                         ");
		sql.append("        , A.KAIKEI_HOCODE                                                                                                         ");
		sql.append("        , A.CONFIRM_ID                                                                                                            ");
		sql.append("        , A.FKINP1001                                                                                                             ");
		sql.append("        , A.TRANS_CNT                                                                                                             ");
		sql.append("        , ''                                                                                                                      ");
		sql.append("    FROM (SELECT 'FROM'                       FROMTO_GUBUN                                                                        ");
		sql.append("                , A.BUNHO                      BUNHO                                                                              ");
		sql.append("                , A.FROM_GWA                   GWA                                                                                ");
		sql.append("                , A.FROM_DOCTOR                DOCTOR                                                                             ");
		sql.append("                , A.FROM_HO_DONG1              HO_DONG                                                                            ");
		sql.append("                , A.FROM_HO_CODE1              HO_CODE                                                                            ");
		sql.append("                , IFNULL(A.FROM_BED_NO, '')    BED_NO                                                                             ");
		sql.append("                , A.FROM_KAIKEI_HODONG         KAIKEI_HODONG                                                                      ");
		sql.append("                , A.FROM_KAIKEI_HOCODE         KAIKEI_HOCODE                                                                      ");
		sql.append("                , FN_ADM_LOAD_USER_NAME(A.UPD_ID, A.HOSP_CODE)                           CONFIRM_ID                               ");
		sql.append("                , A.FKINP1001                  FKINP1001                                                                          ");
		sql.append("                , CAST(A.TRANS_CNT AS CHAR)    TRANS_CNT                                                                          ");
		sql.append("                , DATE_FORMAT(A.START_DATE, '%Y/%m/%d')  START_DATE                                                               ");
		sql.append("                , A.HOSP_CODE                  HOSP_CODE                                                                          ");
		sql.append("            FROM INP2004 A                                                                                                        ");
		sql.append("           WHERE A.HOSP_CODE   = :f_hosp_code                                                                                     ");
		sql.append("             AND A.TO_HO_DONG1 = :f_ho_dong                                                                                       ");
		sql.append("             AND A.START_DATE  BETWEEN DATE_ADD(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), INTERVAL  -1 DAY)                         ");
		sql.append("                                   AND STR_TO_DATE(:f_order_date, '%Y/%m/%d')                                                     ");
		sql.append("             AND (CASE (A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN,'N') END)  <> 'Y'                                   ");
		sql.append("             AND A.TRANS_GUBUN IN('02','04')                                                                                      ");
		sql.append("             AND (A.TO_NURSE_CONFIRM_ID IS NULL OR A.TO_NURSE_CONFIRM_ID = '')                                                    ");
		sql.append("           UNION ALL                                                                                                              ");
		sql.append("           SELECT 'TO'                          FROMTO_GUBUN                                                                      ");
		sql.append("                 , A.BUNHO                      BUNHO                                                                             ");
		sql.append("                 , A.TO_GWA                     GWA                                                                               ");
		sql.append("                 , A.TO_DOCTOR                  DOCTOR                                                                            ");
		sql.append("                 , A.TO_HO_DONG1                HO_DONG                                                                           ");
		sql.append("                 , A.TO_HO_CODE1                HO_CODE                                                                           ");
		sql.append("                 , IFNULL(A.FROM_BED_NO, '')    BED_NO                                                                            ");
		sql.append("                 , A.TO_KAIKEI_HODONG           KAIKEI_HODONG                                                                     ");
		sql.append("                 , A.TO_KAIKEI_HOCODE           KAIKEI_HOCODE                                                                     ");
		sql.append("                 , FN_ADM_LOAD_USER_NAME(A.TO_NURSE_CONFIRM_ID, A.HOSP_CODE )      CONFIRM_ID                                     ");
		sql.append("                 , A.FKINP1001                  FKINP1001                                                                         ");
		sql.append("                 , CAST(A.TRANS_CNT AS CHAR)    TRANS_CNT                                                                         ");
		sql.append("                 , DATE_FORMAT(A.START_DATE, '%Y/%m/%d')   START_DATE                                                             ");
		sql.append("                , A.HOSP_CODE                  HOSP_CODE                                                                          ");
		sql.append("              FROM INP2004 A                                                                                                      ");
		sql.append("             WHERE A.HOSP_CODE   = :f_hosp_code                                                                                   ");
		sql.append("              AND A.TO_HO_DONG1  = :f_ho_dong                                                                                     ");
		sql.append("               AND A.START_DATE  BETWEEN DATE_ADD(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), INTERVAL -1 DAY)                        ");
		sql.append("                                   AND STR_TO_DATE(:f_order_date, '%Y/%m/%d')                                                     ");
		sql.append("               AND CASE (A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN,'N') END <> 'Y'                                    ");
		sql.append("               AND A.TRANS_GUBUN IN('02','04')                                                                                    ");
		sql.append("               AND (A.TO_NURSE_CONFIRM_ID IS NULL OR A.TO_NURSE_CONFIRM_ID = '')) A                                               ");
		sql.append("     JOIN OUT0101 B                                                                                                               ");
		sql.append("       ON B.HOSP_CODE = A.HOSP_CODE                                                                                               ");
		sql.append("      AND B.BUNHO     = A.BUNHO                                                                                                   ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                                                              ");
		sql.append("    ORDER BY START_DATE, FKINP1001, TRANS_CNT, FROMTO_GUBUN                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_order_date", orderDate);
		
		List<NUR2004U01grdInp2004Info> lstResult = new JpaResultMapper().list(query, NUR2004U01grdInp2004Info.class);
		return lstResult;
	}
	
	@Override
	public Integer updateNur2004U01ConfirmTrans(String hospCode, String userId, Double transCnt, String bedNo, Double fkinp1001, Double iTransCnt){
		StringBuilder sql = new StringBuilder();
		sql.append("   UPDATE INP2004                                                     ");
		sql.append("     SET UPD_DATE  = SYSDATE()                                        ");
		sql.append("        ,UPD_ID    = :f_user_id                                       ");
		sql.append("        ,TRANS_CNT = :f_trans_cnt                                     ");
		sql.append("        ,TO_NURSE_CONFIRM_ID = :f_user_id                             ");
		sql.append("        ,TO_NURSE_CONFIRM_DATE = CURRENT_DATE()                       ");
		sql.append("        ,TO_NURSE_CONFIRM_TIME = DATE_FORMAT(SYSDATE(), '%H%i')       ");
		sql.append("        ,TO_BED_NO = :f_bed_no                                        ");
		sql.append("   WHERE HOSP_CODE = :f_hosp_code                                     ");
		sql.append("     AND FKINP1001 = :f_fkinp1001                                     ");
		sql.append("     AND TRANS_CNT = :f_i_trans_cnt                                   ");
		
		if(StringUtils.isEmpty(bedNo))
			bedNo ="";
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", userId);
		query.setParameter("f_trans_cnt", transCnt);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_i_trans_cnt", iTransCnt);
		return query.executeUpdate();
	}
	
	@Override
	public List<NUR2004U01GetConfirmDataInfo> getNUR2004U01GetConfirmDataInfo(String hospCode, Double fkinp1001, Double transCnt) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.FKINP1001                                                        ");
		sql.append("        , A.BUNHO                                                            ");
		sql.append("        , DATE_FORMAT(A.START_DATE, '%Y/%m/%d') START_DATE                   ");
		sql.append("        , A.TRANS_TIME                                                       ");
		sql.append("        , A.TO_GWA                                                           ");
		sql.append("        , A.TO_DOCTOR                                                        ");
		sql.append("        , A.TO_RESIDENT                                                      ");
		sql.append("        , IFNULL(A.TO_HO_CODE1, '')                                          ");
		sql.append("        , IFNULL(A.TO_HO_DONG1, '')                                          ");
		sql.append("        , IFNULL(A.TO_HO_CODE2, '')                                          ");
		sql.append("        , IFNULL(A.TO_HO_DONG2, '')                                          ");
		sql.append("        , IFNULL(A.TRANS_GUBUN, '')                                          ");
		sql.append("        , IFNULL(A.TO_BED_NO, '')                                            ");
		sql.append("        , IFNULL(A.TO_BED_NO2, '')                                           ");
		sql.append("        , IFNULL(A.FROM_HO_CODE1, '')                                        ");
		sql.append("        , IFNULL(A.FROM_HO_DONG1, '')                                        ");
		sql.append("        , IFNULL(A.FROM_BED_NO, '')                                          ");
		sql.append("        , IFNULL(A.TO_HO_GRADE1, '')                                         ");
		sql.append("        , IFNULL(A.TO_HO_GRADE2, '')                                         ");
		sql.append("        , A.TO_KAIKEI_HODONG                                                 ");
		sql.append("        , A.TO_KAIKEI_HOCODE                                                 ");
		sql.append("    FROM INP2004 A                                                           ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                          ");
		sql.append("     AND A.FKINP1001 = :f_fkinp1001                                          ");
		sql.append("     AND A.TRANS_CNT = :f_trans_cnt                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_trans_cnt", transCnt);
		
		List<NUR2004U01GetConfirmDataInfo> lstResult = new JpaResultMapper().list(query, NUR2004U01GetConfirmDataInfo.class);
		return lstResult;
	}
	
	@Override
	public String callProcInpUpadateJengwa(String hospCode, String iudGubun, String userId, Double pkinp1001, String inpwonType, String bunho, String orderDate,
			String transTime, String toHoCode1, String toHoDong1, String toHoGrade1, String toHoCode2, String toHoDong2, String toHoGrade2, String toBedNo){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_UPDATE_JENGWA");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IPWON_TYPE", String.class, ParameterMode.IN);           	
	    query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);      
	    query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);      
	    query.registerStoredProcedureParameter("I_TRANS_TIME", String.class, ParameterMode.IN);     
	    query.registerStoredProcedureParameter("I_TO_HO_CODE1", String.class, ParameterMode.IN);     
	    query.registerStoredProcedureParameter("I_TO_HO_DONG1", String.class, ParameterMode.IN);         
	    query.registerStoredProcedureParameter("I_TO_HO_GRADE1", String.class, ParameterMode.IN);    
	    query.registerStoredProcedureParameter("I_TO_HO_CODE2", String.class, ParameterMode.IN);           	
	    query.registerStoredProcedureParameter("I_TO_HO_DONG2", String.class, ParameterMode.IN);          	
	    query.registerStoredProcedureParameter("I_TO_HO_GRADE2", String.class, ParameterMode.IN);           	
	    query.registerStoredProcedureParameter("I_TO_BED_NO", String.class, ParameterMode.IN);        
	    query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT); 
	    
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_IUD_GUBUN", iudGubun);
	    query.setParameter("I_USER_ID", userId);
	    query.setParameter("I_PKINP1001", pkinp1001);
	    query.setParameter("I_IPWON_TYPE", inpwonType);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_ORDER_DATE", (DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD)));
	    query.setParameter("I_TRANS_TIME", transTime);
	    query.setParameter("I_TO_HO_CODE1", toHoCode1);
	    query.setParameter("I_TO_HO_DONG1", toHoDong1);
	    query.setParameter("I_TO_HO_GRADE1", toHoGrade1);
	    query.setParameter("I_TO_HO_CODE2", toHoCode2);
	    query.setParameter("I_TO_HO_DONG2", toHoDong2);
	    query.setParameter("I_TO_HO_GRADE2", toHoGrade2);
	    query.setParameter("I_TO_BED_NO", toBedNo);
	    
	    query.execute();
	    String result = (String)query.getOutputParameterValue("IO_ERR");
	    if(StringUtils.isEmpty(result))
	    	result = "";
	    
	    return result;
	}
	
	@Override
	public String callPrNurChangeGwaHodong(String hospCode, Double fkinp1001, String bunho, String orderDate, String userId){
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_NUR_CHANGE_GWAHODONG");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);           	
	    query.registerStoredProcedureParameter("IO_ERROR", String.class, ParameterMode.INOUT); 
	    
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_FKINP1001", fkinp1001);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_ORDER_DATE", (DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD)));
	    query.setParameter("I_USER_ID", userId);
	    
	    query.execute();
	    String result = (String)query.getOutputParameterValue("IO_ERROR");
	    if(StringUtils.isEmpty(result))
	    	result = "";
	    
	    return result;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR2004U01layCommon(String hospCode, Double fkinp1001){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(MAX(TRANS_CNT) AS CHAR)        MAX_TRANS_CNT,                   ");
		sql.append("          CAST(MAX(TRANS_CNT) + 1 AS CHAR)    NEW_TRANS_CNT                    ");
		sql.append("       FROM INP2004                                                            ");
		sql.append("      WHERE HOSP_CODE = :f_hosp_code                                           ");
		sql.append("        AND FKINP1001 = :f_fkinp1001                                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}

	@Override
	public List<NUR2004U00GetInitJunipInfo> getNUR2004U00GetInitJunip(String hospCode, String language, Double fkinp1001, String hoDong, String date) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																																					");
		sql.append("		A.TO_GWA,                                           								to_gwa,															");
		sql.append("	  	FN_BAS_LOAD_GWA_NAME(A.TO_GWA, A.START_DATE, :f_hosp_code, :f_language)       		gwa_name,														");
		sql.append("	  	A.TO_DOCTOR                                        									to_doctor,														");
		sql.append("	  	FN_BAS_LOAD_DOCTOR_NAME(A.TO_DOCTOR, A.START_DATE, :f_hosp_code) 					doctor_name,													");
		sql.append("	  	A.TO_HO_DONG1                                      									ho_dong,														");
		sql.append("	  	A.TO_HO_CODE1                                      									ho_code,														");
		sql.append("	  	A.TO_BED_NO                                        									to_bed_no,														");
		sql.append("	  	'Y'                                                 								unconfirm_yn													");
		sql.append("	FROM																																					");
		sql.append("		INP2004 A																																			");
		sql.append("	WHERE																																					");
		sql.append("	  	A.HOSP_CODE   								= :f_hosp_code																							");
		sql.append("	  	AND A.FKINP1001   							= :f_fkinp1001																							");
		sql.append("	  	AND A.TO_HO_DONG1 							= :f_ho_dong																							");
		sql.append("	  	AND A.CANCEL_YN  							!= 'Y'																									");
		sql.append("	  	AND A.TO_NURSE_CONFIRM_DATE 				IS NULL																									");
		sql.append("	  	AND IFNULL(STR_TO_DATE(:f_date, '%Y/%m/%d'), CURRENT_DATE()) 		BETWEEN A.START_DATE AND A.END_DATE												");
		sql.append("	ORDER BY																																				");
		sql.append("	  	A.TRANS_CNT DESC																																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date); 
		
		List<NUR2004U00GetInitJunipInfo> listInfo = new JpaResultMapper().list(query, NUR2004U00GetInitJunipInfo.class);
		return listInfo;
	}

	@SuppressWarnings("unchecked")
	@Override
	public String getNUR2004U00CancelCheck(String hospCode, String bunho, String fkinp1001, String transCnt) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT															");
		sql.append("		'Y'															");
		sql.append("	FROM															");
		sql.append("		DUAL														");
		sql.append("	WHERE															");
		sql.append("		EXISTS (SELECT 'X'											");
		sql.append("				FROM INP2004										");
		sql.append("				WHERE HOSP_CODE = :f_hosp_code						");
		sql.append("					AND BUNHO     = :f_bunho						");
		sql.append("					AND FKINP1001 = :f_fkinp1001					");
		sql.append("					AND TRANS_CNT = :f_trans_cnt					");
		sql.append("					AND TO_NURSE_CONFIRM_DATE IS NOT NULL			");
		sql.append("				)													");
		sql.append("																	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_trans_cnt", transCnt);
		
		List<String> listString = query.getResultList();
		return CollectionUtils.isEmpty(listString) ? "" : listString.get(0);
	}

	@SuppressWarnings("unchecked")
	@Override
	public String getNUR2004U00CheckAfterHograde(String hospCode, String bunho, Double fkinp1001, String date) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																							");
		sql.append("		'Y'																							");
		sql.append("	FROM																							");
		sql.append("		DUAL																						");
		sql.append("	WHERE																							");
		sql.append("		EXISTS(	SELECT 'X'																			");
		sql.append("				FROM INP2004																		");
		sql.append("				WHERE HOSP_CODE  = :f_hosp_code														");
		sql.append("					AND BUNHO      = :f_bunho														");
		sql.append("					AND FKINP1001  = :f_fkinp1001													");
		sql.append("					AND STR_TO_DATE(:f_date, '%Y/%m/%d') BETWEEN START_DATE AND END_DATE			");
		sql.append("					AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN) = 'N'				");
		sql.append("					AND TO_NURSE_CONFIRM_DATE IS NULL												");
		sql.append("				)																					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_date", date);
		
		List<String> listString = query.getResultList();
		return CollectionUtils.isEmpty(listString) ? "" : listString.get(0);
	}

	@SuppressWarnings("unchecked")
	@Override
	public String getNUR2004U00CheckBeforeUpdate(String hospCode, Double fkinp1001, Double transCnt, String toHoDong1,
			String toHoCode1, String toGwa, String toDoctor, String toBedNo) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																		");
		sql.append("		'Y'																		");
		sql.append("	FROM																		");
		sql.append("		DUAL																	");
		sql.append("	WHERE																		");
		sql.append("		EXISTS (SELECT 'X'														");
		sql.append("						FROM INP2004											");
		sql.append("						WHERE HOSP_CODE     		= :f_hosp_code				");
		sql.append("						AND FKINP1001     			= :f_fkinp1001				");
		sql.append("						AND TRANS_CNT     			= :f_trans_cnt				");
		sql.append("						AND IFNULL(CANCEL_YN,'N') 	= 'N'						");
		sql.append("						AND TO_NURSE_CONFIRM_DATE 	IS NULL						");
		sql.append("						AND TO_HO_DONG1   			= :f_to_ho_dong1			");
		sql.append("						AND TO_HO_CODE1   			= :f_to_ho_code1			");
		sql.append("						AND TO_GWA        			= TRIM(:f_to_gwa) 			");
		sql.append("						AND TO_DOCTOR     			= :f_to_doctor				");
		sql.append("						AND TO_BED_NO     			= :f_to_bed_no				");
		sql.append("						)														");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_trans_cnt", transCnt);
		query.setParameter("f_to_ho_dong1", toHoDong1);
		query.setParameter("f_to_ho_code1", toHoCode1);
		query.setParameter("f_to_gwa", toGwa);
		query.setParameter("f_to_doctor", toDoctor);
		query.setParameter("f_to_bed_no", toBedNo);

		List<String> listString = query.getResultList();
		return CollectionUtils.isEmpty(listString) ? "" : listString.get(0);
	}

	@SuppressWarnings("unchecked")
	@Override
	public String getNUR2004U00getTransCnt(String hospCode, String bunho, String fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT													");
		sql.append("		CAST((IFNULL(MAX(TRANS_CNT), 0) + 1) AS CHAR)		");
		sql.append("	FROM													");
		sql.append("		INP2004												");
		sql.append("	WHERE													");
		sql.append("		HOSP_CODE 		= :f_hosp_code						");
		sql.append("		AND BUNHO     	= :f_bunho							");
		sql.append("		AND FKINP1001 	= :f_fkinp1001						");
		sql.append("															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho); // 000000001
		query.setParameter("f_fkinp1001", fkinp1001); // 63
		
		List<String> listString = query.getResultList();
		return CollectionUtils.isEmpty(listString) ? "" : listString.get(0);
	}

	@Override
	public String getNUR2004U00getOldTransCnt(String hospCode, String bunho, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT														                  ");
		sql.append("		CAST(IFNULL(MAX(TRANS_CNT), 0) AS CHAR)					                  ");
		sql.append("	FROM														                  ");
		sql.append("		INP2004													                  ");
		sql.append("	WHERE														                  ");
		sql.append("		HOSP_CODE 					= :f_hosp_code				                  ");
		sql.append("		AND BUNHO     				= :f_bunho					                  ");
		sql.append("		AND FKINP1001 				= :f_fkinp1001				                  ");
		sql.append("		AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN) 	= 'N'	  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<String> listString = query.getResultList();
		return CollectionUtils.isEmpty(listString) ? "" : listString.get(0);
	}

	@Override
	public Integer updateNUR2004U00CancelUpdate(String userId, String cancelSayu, String hospCode, String bunho, String fkinp1001, String transCnt) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE											");
		sql.append("		INP2004										");
		sql.append("	SET												");
		sql.append("		UPD_DATE 		= SYSDATE(),				");
		sql.append("		UPD_ID  		= :q_user_id,				");
		sql.append("		CANCEL_YN 		= 'Y',						");
		sql.append("		CANCEL_SAYU 	= :f_cancel_sayu			");
		sql.append("	WHERE											");
		sql.append("		HOSP_CODE 		= :f_hosp_code				");
		sql.append("		AND BUNHO     	= :f_bunho					");
		sql.append("		AND FKINP1001 	= :f_fkinp1001				");
		sql.append("		AND TRANS_CNT 	= :f_trans_cnt				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("q_user_id", userId);
		query.setParameter("f_cancel_sayu", cancelSayu);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_trans_cnt", transCnt);
		
		return query.executeUpdate();
	}

	@Override
	public Integer updateNUR2004U00ProcessUpdate(String userId, String toGwa, String toHoDong1, String toHoCode1,
			String toHoGrade1, String toHoDong2, String toHoCode2, String toBedNo, String toBedNo2,
			String toKaikeiHodong, String toKaikeiHocode, String hospCode, Double fkinp1001, Double transCnt, String toDoctor) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE																	        ");
		sql.append("		INP2004																        ");
		sql.append("	SET																		        ");
		sql.append("		UPD_DATE                        = SYSDATE(),						        ");
		sql.append("		UPD_ID                          = :q_user_id,						        ");
		sql.append("		TO_GWA                          = TRIM(:f_to_gwa),					        ");
		sql.append("		TO_HO_DONG1                     = :f_to_ho_dong1,					        ");
		sql.append("		TO_HO_CODE1                     = :f_to_ho_code1,					        ");
		sql.append("		TO_HO_GRADE1                    = :f_to_ho_grade1,					        ");
		sql.append("		TO_HO_DONG2                     = :f_to_ho_dong2,					        ");
		sql.append("		TO_HO_CODE2                     = :f_to_ho_code2,					        ");
		sql.append("		TO_HO_GRADE2                    = :f_to_ho_grade1,					        ");
		sql.append("		TO_BED_NO                       = :f_to_bed_no,						        ");
		sql.append("		TO_BED_NO2                      = :f_to_bed_no2,					        ");
		sql.append("		TO_KAIKEI_HODONG 				= :f_to_kaikei_hodong,				        ");
		sql.append("		TO_KAIKEI_HOCODE 				= :f_to_kaikei_hocode				        ");
		sql.append("	WHERE																	        ");
		sql.append("		HOSP_CODE     					= :f_hosp_code						        ");
		sql.append("		AND FKINP1001  					= :f_fkinp1001						        ");
		sql.append("		AND TRANS_CNT     				= :f_trans_cnt						        ");
		sql.append("		AND IF(CANCEL_YN IS NULL OR CANCEL_YN = '', 'N', CANCEL_YN) 		= 'N'	");
		sql.append("		AND TO_NURSE_CONFIRM_DATE 		IS NULL								        ");
		sql.append("		AND TO_HO_DONG1                 = :f_to_ho_dong1					        ");
		sql.append("		AND TO_HO_CODE1                 = :f_to_ho_code1					        ");
		sql.append("		AND TO_GWA                      = TRIM(:f_to_gwa)					        ");
		sql.append("		AND TO_DOCTOR                   = :f_to_doctor						        ");
		sql.append("		AND TO_BED_NO                   = :f_to_bed_no						        ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("q_user_id", userId);
		query.setParameter("f_to_gwa", toGwa);
		query.setParameter("f_to_ho_dong1", toHoDong1);
		query.setParameter("f_to_ho_code1", toHoCode1);
		query.setParameter("f_to_ho_grade1", toHoGrade1);
		query.setParameter("f_to_ho_dong2", toHoDong2);
		query.setParameter("f_to_ho_code2", toHoCode2);
		query.setParameter("f_to_bed_no", toBedNo);
		query.setParameter("f_to_bed_no2", toBedNo2);
		query.setParameter("f_to_kaikei_hodong", toKaikeiHodong);
		query.setParameter("f_to_kaikei_hocode", toKaikeiHocode);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_trans_cnt", transCnt);
		query.setParameter("f_to_doctor", toDoctor);
		
		return query.executeUpdate();
	}
	

	@Override
	public Integer updateInp2004InNUR2004U00(String userId, Double transCnt, String bedNo, String hospCode,
			String bunho, Double fkinp1001, Double iTransCnt) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE INP2004                                                       ");
		sql.append("	SET UPD_DATE              = SYSDATE()                                ");
		sql.append("	   ,UPD_ID                = :f_user_id                               ");
		sql.append("	   ,TRANS_CNT             = :f_trans_cnt                             ");
		sql.append("	   ,TO_NURSE_CONFIRM_ID   = :f_user_id                               ");
		sql.append("	   ,TO_NURSE_CONFIRM_DATE = SYSDATE()                                ");
		sql.append("	   ,TO_NURSE_CONFIRM_TIME = DATE_FORMAT(SYSDATE(), '%H%i')           ");
		sql.append("	   ,TO_BED_NO             = IF(:f_bed_no = '', TO_BED_NO, :f_bed_no) ");
		sql.append("	WHERE HOSP_CODE           = :f_hosp_code                             ");
		sql.append("	AND BUNHO                 = :f_bunho                                 ");
		sql.append("	AND FKINP1001             = :f_fkinp1001                             ");
		sql.append("	AND TRANS_CNT             = :f_i_trans_cnt                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_trans_cnt", transCnt);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_i_trans_cnt", iTransCnt);
		
		return query.executeUpdate();
	}

	@Override
	public String getNUR2004U00dtpJukyong(String hospCode, Double fkinp1001, Date selectedDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CASE WHEN :f_selected_date < MAX(START_DATE) ");
		sql.append("	    OR :f_selected_date > CURRENT_DATE() THEN 'N'	");
		sql.append("	  ELSE 'Y'											");
		sql.append("	END													");
		sql.append("	FROM INP2004 A										");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code					");
		sql.append("	AND A.FKINP1001 = :f_fkinp1001						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_selected_date", selectedDate);
		
		List<String> listString = query.getResultList();
		return CollectionUtils.isEmpty(listString) ? "" : listString.get(0);
	}

	@Override
	public Integer updateInp2004NUR1010Q00ConfirmTrans(String hospCode, String userId, Double transCnt, String bedNo,
			Double fkinp1001, Double iTransCnt) {
		StringBuilder sql = new StringBuilder();
		sql.append("	UPDATE INP2004                                                                                                         ");
		sql.append("	 SET UPD_DATE              = SYSDATE()                                                                                 ");
		sql.append("	   , UPD_ID                = :f_user_id                                                                                ");
		sql.append("	   , TRANS_CNT             = :f_trans_cnt                                                                              ");
		sql.append("	   , TO_NURSE_CONFIRM_ID   = :f_user_id                                                                                ");
		sql.append("	   , TO_NURSE_CONFIRM_DATE = CURRENT_DATE()                                                                            ");
		sql.append("	   , TO_NURSE_CONFIRM_TIME = DATE_FORMAT(SYSDATE(), '%H%i')                                                            ");
		sql.append("	   , TO_BED_NO             = (CASE TRIM(:f_bed_no) WHEN NULL THEN TO_BED_NO WHEN '' THEN TO_BED_NO ELSE :f_bed_no END) ");
		sql.append("	WHERE HOSP_CODE            = :f_hosp_code                                                                              ");
		sql.append("	 AND FKINP1001             = :f_fkinp1001                                                                              ");
		sql.append("	 AND TRANS_CNT             = :f_i_trans_cnt                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_user_id", userId);
		query.setParameter("f_trans_cnt", transCnt);
		query.setParameter("f_bed_no", bedNo);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_i_trans_cnt", iTransCnt);
		
		return query.executeUpdate();
	}
	
	@Override
	public List<NUR1010Q00layConfirmDataInfo> getNUR1010Q00layConfirmDataInfo(String hospCode, Double fkinp1001, Double transCnt) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.FKINP1001                                                    ");
		sql.append("        , A.BUNHO                                                        ");
		sql.append("        , DATE_FORMAT(A.START_DATE,'%Y/%m/%d') ORDER_DATE                ");
		sql.append("        , A.TRANS_TIME                                                   ");
		sql.append("        , A.TO_GWA                                                       ");
		sql.append("        , A.TO_DOCTOR                                                    ");
		sql.append("        , A.TO_RESIDENT                                                  ");
		sql.append("        , A.TO_HO_CODE1                                                  ");
		sql.append("        , A.TO_HO_DONG1                                                  ");
		sql.append("        , A.TO_HO_CODE2                                                  ");
		sql.append("        , A.TO_HO_DONG2                                                  ");
		sql.append("        , A.TRANS_GUBUN                                                  ");
		sql.append("        , A.TO_BED_NO                                                    ");
		sql.append("        , A.TO_BED_NO2                                                   ");
		sql.append("        , A.FROM_HO_CODE1                                                ");
		sql.append("        , A.FROM_HO_DONG1                                                ");
		sql.append("        , A.FROM_BED_NO                                                  ");
		sql.append("        , A.TO_HO_GRADE1                                                 ");
		sql.append("        , A.TO_HO_GRADE2                                                 ");
		sql.append("        , A.TO_KAIKEI_HODONG                                             ");
		sql.append("        , A.TO_KAIKEI_HOCODE                                             ");
		sql.append("    FROM INP2004 A                                                       ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                      ");
		sql.append("     AND A.FKINP1001 = :f_fkinp1001                                      ");
		sql.append("     AND A.TRANS_CNT = :f_trans_cnt                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_trans_cnt", transCnt);
		
		List<NUR1010Q00layConfirmDataInfo> listInfo = new JpaResultMapper().list(query, NUR1010Q00layConfirmDataInfo.class);
		return listInfo;
	}
	
	@Override
	public String getNUR1010Q00SelectCount(String hospCode, String hoDong, String orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(COUNT(1) AS CHAR)                                                                    ");
		sql.append("     FROM INP2004 A                                                                                 ");
		sql.append("    WHERE A.HOSP_CODE  = :f_hosp_code                                                               ");
		sql.append("      AND A.START_DATE BETWEEN DATE_ADD(STR_TO_DATE(:f_order_date, '%Y/%m/%d'), INTERVAL -1 DAY)    ");
		sql.append("                            AND STR_TO_DATE(:f_order_date, '%Y/%m/%d')                              ");
		sql.append("      AND A.TO_HO_DONG1 = :f_ho_dong                                                                ");
		sql.append("      AND A.CANCEL_YN <> 'Y'                                                                        ");
		sql.append("      AND A.TRANS_GUBUN IN('02','04')                                                               ");
		sql.append("      AND (A.TO_NURSE_CONFIRM_DATE IS NULL                                                          ");
		sql.append("           OR A.TO_NURSE_CONFIRM_DATE = '')                                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_order_date", orderDate);
		
		List<String> listString = query.getResultList();
		if(!CollectionUtils.isEmpty(listString) && listString.size() > 0){
			return listString.get(0);
		}
		return "";
	}
	
	@Override
	public String checkNUR1010Q00MoveHosilCheck1(String hospCode, String bunho, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT 'Y'                                                                                             ");
		sql.append("     FROM DUAL                                                                                            ");
		sql.append("    WHERE EXISTS (SELECT 'X'                                                                              ");
		sql.append("                    FROM INP2004 A                                                                        ");
		sql.append("                   WHERE A.HOSP_CODE           = :f_hosp_code                                             ");
		sql.append("                     AND A.BUNHO               = :f_bunho                                                 ");
		sql.append("                     AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL (A.CANCEL_YN, 'N') END = 'N'      ");
		sql.append("                     AND A.FKINP1001           = :f_fkinp1001                                             ");
		sql.append("                     AND (A.TO_NURSE_CONFIRM_DATE IS NULL                                                 ");
		sql.append("                         OR A.TO_NURSE_CONFIRM_DATE = ''))                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<String> listString = query.getResultList();
		if(!CollectionUtils.isEmpty(listString) && listString.size() > 0){
			return listString.get(0);
		}
		return "";
	}
	
	@Override
	public String getNUR1010Q00MoveHosilCheck4(String hospCode, String bunho, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(IFNULL(MAX(A.TRANS_CNT),0) + 1 AS CHAR) MAX_CNT        ");
		sql.append("     FROM INP2004 A                                                   ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                  ");
		sql.append("      AND A.BUNHO     = :f_bunho                                      ");
		sql.append("      AND A.FKINP1001 = :f_fkinp1001                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<String> listString = query.getResultList();
		if(!CollectionUtils.isEmpty(listString) && listString.size() > 0){
			return listString.get(0);
		}
		return "";
	}
	
	@Override
	public String getNUR1010Q00ChangeHosilCheck4(String hospCode, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CAST(MAX(TRANS_CNT) + 1 AS CHAR) MAX_CNT        ");
		sql.append("     FROM INP2004                                         ");
		sql.append("    WHERE HOSP_CODE = :i_hosp_code                        ");
		sql.append("      AND FKINP1001 = :i_from_fkinp1001                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<String> listString = query.getResultList();
		if(!CollectionUtils.isEmpty(listString) && listString.size() > 0){
			return listString.get(0);
		}
		return "";
	}
	
	@Override
	public String callPrNurChangeHocode(String hospCode, Double fromFkinp1001, Double toFkinp1001,
			String fromBunho, String toBunho, String fromKaikeiChange, String toKaikeiChange, String fromTransCnt, String toTransCnt, String userId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_NUR_CHANGE_HOCODE");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_KAIKEI_CHANGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_KAIKEI_CHANGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_TRANS_CNT", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_TRANS_CNT", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);		
	    query.registerStoredProcedureParameter("IO_ERROR", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_FROM_FKINP1001", fromFkinp1001);
		query.setParameter("I_TO_FKINP1001", toFkinp1001);
		query.setParameter("I_FROM_BUNHO", fromBunho);
		query.setParameter("I_TO_BUNHO", toBunho);
		query.setParameter("I_FROM_KAIKEI_CHANGE", fromKaikeiChange);
		query.setParameter("I_TO_KAIKEI_CHANGE", toKaikeiChange);
		query.setParameter("I_FROM_TRANS_CNT", CommonUtils.parseDouble(fromTransCnt));
		query.setParameter("I_TO_TRANS_CNT", CommonUtils.parseDouble(toTransCnt));
		query.setParameter("I_USER_ID", userId);
		
		query.execute();
	    
		String err = (String)query.getOutputParameterValue("IO_ERROR");
		return err;
	}
	
	@Override
	public List<NUR1001R07grdInp2004Info> getNUR1001R07grdInp2004Info(String hospCode, String language, Double fkinp1001, String bunho, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.FKINP1001                                                        FKINP1001                           ");
		sql.append("        , DATE_FORMAT(A.START_DATE, '%Y/%m/%d')                                             ORDER_DATE           ");
		sql.append("        , FN_BAS_LOAD_GWA_NAME(A.FROM_GWA, A.START_DATE, A.HOSP_CODE, :f_language)          FROM_GWA             ");
		sql.append("        , FN_BAS_LOAD_GWA_NAME(A.TO_GWA, A.START_DATE, A.HOSP_CODE, :f_language)            TO_GWA               ");
		sql.append("        , FN_BAS_LOAD_DOCTOR_NAME(A.FROM_DOCTOR, A.START_DATE, A.HOSP_CODE)    FROM_DOCTOR                       ");
		sql.append("        , FN_BAS_LOAD_DOCTOR_NAME(A.TO_DOCTOR, A.START_DATE, A.HOSP_CODE)      TO_DOCTOR                         ");
		sql.append("        , FN_BAS_LOAD_HO_DONG_NAME(A.FROM_HO_DONG1, A.START_DATE, A.HOSP_CODE, :f_language) FROM_HO_DONG1        ");
		sql.append("        , FN_BAS_LOAD_HO_DONG_NAME(A.TO_HO_DONG1, A.START_DATE, A.HOSP_CODE, :f_language)   TO_HO_DONG1          ");
		sql.append("        , A.FROM_HO_CODE1                                                FROM_HO_CODE1                           ");
		sql.append("        , A.TO_HO_CODE1                                                  TO_HO_CODE1                             ");
		sql.append("        , CAST(A.TRANS_CNT AS CHAR)                                      TRANS_CNT                               ");
		sql.append("        , A.TRANS_TIME                                                   TRANS_TIME                              ");
		sql.append("        , A.FROM_BED_NO                                                  FROM_BED                                ");
		sql.append("        , A.TO_BED_NO                                                    TO_BED                                  ");
		sql.append("     FROM INP2004 A                                                                                              ");
		sql.append("    WHERE A.HOSP_CODE           = :f_hosp_code                                                                   ");
		sql.append("          AND A.BUNHO               = :f_bunho                                                                   ");
		sql.append("          AND A.FKINP1001           = :f_fkinp1001                                                               ");
		sql.append("      AND CASE(A.CANCEL_YN) WHEN '' THEN 'N' ELSE IFNULL(A.CANCEL_YN, 'N') END = 'N'                             ");
		sql.append("    ORDER BY TRANS_CNT DESC                                                                                      ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset																				 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_bunho", bunho);
		
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR1001R07grdInp2004Info> listInfo = new JpaResultMapper().list(query, NUR1001R07grdInp2004Info.class);
		return listInfo;
	}
	
}

