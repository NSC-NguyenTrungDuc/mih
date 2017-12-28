package nta.med.data.dao.medi.ocs.impl;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2015RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdSiksaInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL1Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdSiksaInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdOCS2015Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10OrderInfoCase2Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10OrderInfoCaseDfltInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAgrdOCS2015Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAProcDAOTInfo;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdOCS2015Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmDirectActinggrdOCS2015Info;
import nta.med.data.model.ihis.ocsi.RecoveryMaxMinInfo;

/**
 * @author dainguyen.
 */
public class Ocs2015RepositoryImpl implements Ocs2015RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORDERTRANSGrdSiksaInfo> getORDERTRANSGrdSiksaInfo(
			String hospCode, String sendYn, String bunho, Double pk1001,
			String actingDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.FKINP1001                                                                                                    ");
		sql.append("       , A.PKOCS2015                                                                                                    ");
		sql.append("       , A.BUNHO                                                                                                        ");
		sql.append("       , A.INPUT_GUBUN                                                                                                  ");
		sql.append("       , B.DIRECT_GUBUN                                                                                                 ");
		sql.append("       , C.NUR_GR_NAME                                                                                                  ");
		sql.append("       , B.DIRECT_CODE                                                                                                  ");
		sql.append("       , E.NUR_MD_NAME                                                                                                  ");
		sql.append("       , B.DIRECT_CONT1                                                                                                 ");
		sql.append("       , CONCAT(F.NUR_SO_NAME, '  ', G.NUR_SO_NAME)                                                                     ");
		sql.append("       , B.ORDER_DATE                                                                                                   ");
		sql.append("       , B.DRT_FROM_DATE                                                                                                ");
		sql.append("       , B.DRT_TO_DATE                                                                                                  ");
		sql.append("       , A.ACT_DATE                                                                                                     ");
		sql.append("       , A.PKOCS2015                                                                                                    ");
		sql.append("       ,'Y'                                                               ACTING_YN                                     ");
		sql.append("       ,:f_send_yn                                                        SELECT_YN                                     ");
		sql.append("       , CASE WHEN H.ACTING_DATE IS NULL THEN 'N' ELSE 'Y' END SEND_YN                                                  ");
		sql.append(" FROM    OCS2206 H RIGHT JOIN OCS2015 A ON  H.HOSP_CODE   = A.HOSP_CODE                                                 ");
		sql.append("         AND H.BUNHO = A.BUNHO AND H.FKINP1001 = A.FKINP1001 AND H.FKOCS2015_SEQ = A.PKOCS2015                          ");
		sql.append("      , NUR0110 C                                                                                                       ");
		sql.append("      , NUR0111 E                                                                                                       ");
		sql.append("      , NUR0112 F                                                                                                       ");
		sql.append("      , NUR0114 G RIGHT JOIN OCS2005 B ON  G.HOSP_CODE = B.HOSP_CODE                                                    ");
		sql.append("         AND G.NUR_GR_CODE = B.DIRECT_GUBUN AND G.NUR_MD_CODE = B.DIRECT_CODE AND G.NUR_SO_CODE = B.DIRECT_CONT2        ");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                                                                                     ");
		sql.append("   AND A.BUNHO       = :f_bunho                                                                                         ");
		sql.append("   AND A.FKINP1001   = :f_pk1001                                                                                        ");
		sql.append("   AND STR_TO_DATE(:f_acting_date, '%Y/%m/%d') = A.ACT_DATE                                                             ");
		sql.append("   AND B.HOSP_CODE   = A.HOSP_CODE                                                                                      ");
		sql.append("   AND B.BUNHO       = A.BUNHO                                                                                          ");
		sql.append("   AND B.FKINP1001   = A.FKINP1001                                                                                      ");
		sql.append("   AND B.ORDER_DATE  = A.ORDER_DATE                                                                                     ");
		sql.append("   AND B.INPUT_GUBUN = A.INPUT_GUBUN                                                                                    ");
		sql.append("   AND B.PK_SEQ = A.PK_SEQ                                                                                              ");
		sql.append("   AND B.DIRECT_GUBUN = '02'                                                                                            ");
		sql.append("   AND SUBSTR(B.DIRECT_CODE,4,1) != '4'                                                                                 ");
		sql.append("   AND SUBSTR(B.DIRECT_CODE,3,1) != '2'                                                                                 ");
		sql.append("   AND C.HOSP_CODE    = B.HOSP_CODE                                                                                     ");
		sql.append("   AND C.NUR_GR_CODE  = B.DIRECT_GUBUN                                                                                  ");
		sql.append("   AND E.HOSP_CODE    = C.HOSP_CODE                                                                                     ");
		sql.append("   AND E.NUR_GR_CODE  = C.NUR_GR_CODE                                                                                   ");
		sql.append("   AND E.NUR_MD_CODE  = B.DIRECT_CODE                                                                                   ");
		sql.append("   AND F.HOSP_CODE    = E.HOSP_CODE                                                                                     ");
		sql.append("   AND F.NUR_GR_CODE  = E.NUR_GR_CODE                                                                                   ");
		sql.append("   AND F.NUR_MD_CODE  = E.NUR_MD_CODE                                                                                   ");
		sql.append("   AND F.NUR_SO_CODE  = B.DIRECT_CONT1                                                                                  ");
		sql.append("   AND CASE WHEN H.ACTING_DATE IS NULL THEN 'N' ELSE 'Y' END = :f_send_yn                                               ");
		sql.append("   ORDER BY A.ORDER_DATE, A.PK_SEQ																						");
		  
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pk1001", pk1001);
		query.setParameter("f_acting_date", actingDate);
		List<ORDERTRANSGrdSiksaInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdSiksaInfo.class);
		return list;
	}

	@Override
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase1(
			String hospCode, String language, String ioGubun, String sendYn,
			String bunho, String actingDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT A.FKINP1001                                         FKINP1001                                                                                              ");
		sql.append("     , A.BUNHO                                             BUNHO                                                                                                            ");
		sql.append("     , E.SUNAME                                            SUNAME                                                                                                           ");
		sql.append("     , D.IPWON_DATE                                        IPWON_DATE                                                                                                       ");
		sql.append("     , D.IPWON_TIME                                        IPWON_TIME                                                                                                       ");
		sql.append("     , D.GWA                                               GWA                                                                                                              ");
		sql.append("     , D.DOCTOR                                            DOCTOR                                                                                                           ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME (D.GWA, D.IPWON_DATE,:f_hosp_code,:f_language )         GWA_NAME                                                                                ");
		sql.append("     , FN_BAS_LOAD_DOCTOR_NAME (D.DOCTOR, D.IPWON_DATE , :f_hosp_code)    DOCTOR_NAME                                                                                       ");
		sql.append("     , F.GUBUN                                                                                                                                                              ");
		sql.append("     , G.GUBUN_NAME                                       GUBUN_NAME                                                                                                        ");
		sql.append("     , IFNULL(G.GONGBI_YN,'Y')                               GONGBI_YN                                                                                                      ");
		sql.append("     , D.CHOJAE                                                                                                                                                             ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('CHOJAE', D.CHOJAE,:f_hosp_code,:f_language )         CHOJAE_NAME                                                                              ");
		sql.append("     , F.PKINP1002                                                                                                                                                          ");
		sql.append("     , CASE WHEN C.ACTING_DATE IS NULL THEN A.ACT_DATE                                                                                                                      ");
		sql.append("       ELSE C.ACTING_DATE                                                                                                                                                   ");
		sql.append("       END ACTING_DATE                                                                                                                                                      ");
		sql.append("     , ''                                                   ORDER_DATE                                                                                                      ");
		sql.append("     , F.GUBUN                                              GUBUN_OLD                                                                                                       ");
		sql.append("     , D.CHOJAE                                             CHOJAE_OLD                                                                                                      ");
		sql.append("     , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 1)   GONGBI_CODE1                                                     ");
		sql.append("     , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 2)   GONGBI_CODE2                                                     ");
		sql.append("     , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 3)   GONGBI_CODE3                                                     ");
		sql.append("     , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 4)   GONGBI_CODE4                                                     ");
		sql.append("    , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 1), ACTING_DATE, :f_language) GONGBI_CODE1_NAME             ");
		sql.append("    , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 2), ACTING_DATE, :f_language) GONGBI_CODE2_NAME             ");
		sql.append("    , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 3), ACTING_DATE, :f_language) GONGBI_CODE3_NAME             ");
		sql.append("    , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code, :f_io_gubun, :f_send_yn, A.FKINP1001, ACTING_DATE, 4), ACTING_DATE, :f_language) GONGBI_CODE4_NAME             ");
		sql.append("     , ''                                                    PKOUT                                                                                                          ");
		sql.append("     , ''                                                    SEND_DATE                                                                                                      ");
		sql.append("     , '1'                                                   SANJUNG_GUBUN                                                                                                  ");
		sql.append("      , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1',:f_hosp_code,:f_language )          SANJUNG_GUBUN_NAME                                                           ");
		sql.append("      ,CASE FN_OUT_LOAD_JUBSU_GUBUN_VALID(:f_hosp_code, A.BUNHO, F.GUBUN, ACTING_DATE) WHEN 'N' THEN '1' ELSE '0' END IF_VALID_YN                                           ");
		sql.append("       FROM OCS2015 A LEFT JOIN  OCS2206 C ON C.HOSP_CODE= A.HOSP_CODE AND C.FKINP1001 = A.FKINP1001                                                                        ");
		sql.append("                         AND C.FKOCS2015_SEQ = A.PKOCS2015                                                                                                                  ");
		sql.append("          , OCS2005 B                                                                                                                                                       ");
		sql.append("          , INP1001 D                                                                                                                                                       ");
		sql.append("          , OUT0101 E                                                                                                                                                       ");
		sql.append("          , INP1002 F                                                                                                                                                       ");
		sql.append("          , BAS0210 G                                                                                                                                                       ");
		sql.append("      WHERE A.HOSP_CODE  = :f_hosp_code                                                                                                                                     ");
		sql.append("        AND A.BUNHO  LIKE :f_bunho                                                                                                                                          ");
		sql.append("        AND STR_TO_DATE(:f_acting_date, '%Y/%m/%d') >= A.DRT_DATE                                                                                                           ");
		sql.append("        AND B.HOSP_CODE   = A.HOSP_CODE                                                                                                                                     ");
		sql.append("        AND B.BUNHO       = A.BUNHO                                                                                                                                         ");
		sql.append("        AND B.FKINP1001   = A.FKINP1001                                                                                                                                     ");
		sql.append("        AND B.ORDER_DATE  = A.ORDER_DATE                                                                                                                                    ");
		sql.append("        AND B.INPUT_GUBUN = A.INPUT_GUBUN                                                                                                                                   ");
		sql.append("        AND B.PK_SEQ = A.PK_SEQ                                                                                                                                             ");
		sql.append("        AND B.DIRECT_GUBUN = '02'                                                                                                                                           ");
		sql.append("        AND SUBSTR(B.DIRECT_CODE,4,1) != '4'                                                                                                                                ");
		sql.append("        AND SUBSTR(B.DIRECT_CODE,3,1) != '2'                                                                                                                                ");
		sql.append("        AND CASE WHEN C.ACTING_DATE IS NOT NULL THEN 'Y' ELSE 'N' END = :f_send_yn                                                                                          ");
		sql.append("        AND D.HOSP_CODE   = A.HOSP_CODE                                                                                                                                     ");
		sql.append("        AND D.BUNHO       = A.BUNHO                                                                                                                                         ");
		sql.append("        AND D.PKINP1001   = A.FKINP1001                                                                                                                                     ");
		sql.append("        AND E.HOSP_CODE   = A.HOSP_CODE                                                                                                                                     ");
		sql.append("        AND E.BUNHO       = A.BUNHO                                                                                                                                         ");
		sql.append("        AND F.HOSP_CODE   = A.HOSP_CODE                                                                                                                                     ");
		sql.append("        AND F.BUNHO       = A.BUNHO                                                                                                                                         ");
		sql.append("        AND F.FKINP1001   = A.FKINP1001                                                                                                                                     ");
		sql.append("        AND :f_hosp_code  = F.HOSP_CODE                                                                                                                                     ");
		sql.append("        AND G.GUBUN       = F.GUBUN     AND G.LANGUAGE = :f_language                                                                                                        ");
		sql.append("        AND D.IPWON_DATE BETWEEN G.START_DATE                                                                                                                               ");
		sql.append("                        AND IFNULL(G.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                                                           ");
		sql.append("        GROUP BY  A.FKINP1001                                                                                                                                               ");
		sql.append("                  , A.BUNHO                                                                                                                                                 ");
		sql.append("                  , E.SUNAME                                                                                                                                                ");
		sql.append("                  , D.IPWON_DATE                                                                                                                                            ");
		sql.append("                  , D.IPWON_TIME                                                                                                                                            ");
		sql.append("                  , D.GWA                                                                                                                                                   ");
		sql.append("                  , D.DOCTOR                                                                                                                                                ");
		sql.append("                  , F.GUBUN                                                                                                                                                 ");
		sql.append("                  , D.CHOJAE                                                                                                                                                ");
		sql.append("                  , F.PKINP1002                                                                                                                                             ");
		sql.append("                  , A.ORDER_DATE                                                                                                                                            ");
		sql.append("                  , A.ACT_DATE                                                                                                                                              ");
		sql.append("                  , C.ACTING_DATE                                                                                                                                           ");
		sql.append("                  , A.PKOCS2015                                                                                                                                             ");
		sql.append("                  , E.IF_VALID_YN                                                                                                                                           ");
		sql.append("                  , G.GUBUN_NAME                                                                                                                                            ");
		sql.append("                  , IFNULL(G.GONGBI_YN,'Y')                                                                                                                                 ");
		sql.append("       ORDER BY D.IPWON_DATE , ACTING_DATE DESC 																															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_bunho", bunho + "%");
		query.setParameter("f_acting_date", actingDate);
		
		List<ORDERTRANSGrdListInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdListInfo.class);
		return list;
	}

	@Override
	public List<INPORDERTRANSGrdSiksaInfo> getINPORDERTRANSGrdSiksaInfo(String hospCode, String bunho, String sendYn,
			Date firstDate, Date lastDate, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO                                            BUNHO                                        ");
		sql.append("    , A.FKINP1001                                        PKOCS                                          ");
		sql.append("    , A.FKINP1001                                        FKINP1001                                      ");
		sql.append("    , CONCAT(A.BUNHO , A.FKINP1001)                      GROUP_INP1001                                  ");
		sql.append("    , MAX(A.ORDER_DATE)                                  ORDER_DATE                                     ");
		sql.append("    , A.DRT_DATE                                         DRT_DATE                                       ");
		sql.append("    , MIN(CASE A.TIME_GUBUN WHEN '0' THEN CASE A.SIKSA_CODE WHEN '000'                                  ");
		sql.append("                                                       THEN (SELECT X.NUR_SO_NAME                       ");
		sql.append("                                                            FROM NUR0112 X                              ");
		sql.append("                                                           WHERE X.HOSP_CODE = :hosp_code               ");
		sql.append("                                                             AND X.NUR_GR_CODE = '03'                   ");
		sql.append("                                                             AND X.NUR_MD_CODE = '0301'                 ");
		sql.append("                                                             AND X.NUR_SO_CODE = '000')                 ");
		sql.append("                                                       WHEN '001'                                       ");
		sql.append("                                                       THEN (SELECT X.NUR_SO_NAME                       ");
		sql.append("                                                            FROM NUR0112 X                              ");
		sql.append("                                                           WHERE X.HOSP_CODE = :hosp_code               ");
		sql.append("                                                             AND X.NUR_GR_CODE = '03'                   ");
		sql.append("                                                             AND X.NUR_MD_CODE = '0301'                 ");
		sql.append("                                                             AND X.NUR_SO_CODE = '001')                 ");
		sql.append("                                                       WHEN '009'                                       ");
		sql.append("                                                       THEN (SELECT X.NUR_SO_NAME                       ");
		sql.append("                                                            FROM NUR0112 X                              ");
		sql.append("                                                           WHERE X.HOSP_CODE = :hosp_code               ");
		sql.append("                                                             AND X.NUR_GR_CODE = '03'                   ");
		sql.append("                                                             AND X.NUR_MD_CODE = '0301'                 ");
		sql.append("                                                             AND X.NUR_SO_CODE = '009')                 ");
		sql.append("                                                       END                                              ");
		sql.append("                                             END) TIME_GUBUN1                                           ");
		sql.append("    , MIN(CASE A.TIME_GUBUN WHEN '1' THEN CASE A.SIKSA_CODE WHEN '000'                                  ");
		sql.append("                                                       THEN (SELECT X.NUR_SO_NAME                       ");
		sql.append("                                                            FROM NUR0112 X                              ");
		sql.append("                                                           WHERE X.HOSP_CODE = :hosp_code               ");
		sql.append("                                                             AND X.NUR_GR_CODE = '03'                   ");
		sql.append("                                                             AND X.NUR_MD_CODE = '0301'                 ");
		sql.append("                                                             AND X.NUR_SO_CODE = '000')                 ");
		sql.append("                                                       WHEN '001'                                       ");
		sql.append("                                                       THEN (SELECT X.NUR_SO_NAME                       ");
		sql.append("                                                            FROM NUR0112 X                              ");
		sql.append("                                                           WHERE X.HOSP_CODE = :hosp_code               ");
		sql.append("                                                             AND X.NUR_GR_CODE = '03'                   ");
		sql.append("                                                             AND X.NUR_MD_CODE = '0301'                 ");
		sql.append("                                                             AND X.NUR_SO_CODE = '001')                 ");
		sql.append("                                                       WHEN '009'                                       ");
		sql.append("                                                       THEN (SELECT X.NUR_SO_NAME                       ");
		sql.append("                                                            FROM NUR0112 X                              ");
		sql.append("                                                           WHERE X.HOSP_CODE = :hosp_code               ");
		sql.append("                                                             AND X.NUR_GR_CODE = '03'                   ");
		sql.append("                                                             AND X.NUR_MD_CODE = '0301'                 ");
		sql.append("                                                             AND X.NUR_SO_CODE = '009')                 ");
		sql.append("                                                       END                                              ");
		sql.append("                                           END ) TIME_GUBUN2                                            ");
		sql.append("    , MIN(CASE A.TIME_GUBUN WHEN '2' THEN CASE A.SIKSA_CODE WHEN '000'                                  ");
		sql.append("                                                      THEN (SELECT X.NUR_SO_NAME                        ");
		sql.append("                                                            FROM NUR0112 X                              ");
		sql.append("                                                           WHERE X.HOSP_CODE = :hosp_code               ");
		sql.append("                                                             AND X.NUR_GR_CODE = '03'                   ");
		sql.append("                                                             AND X.NUR_MD_CODE = '0301'                 ");
		sql.append("                                                             AND X.NUR_SO_CODE = '000')                 ");
		sql.append("                                                       WHEN '001'                                       ");
		sql.append("                                                       THEN (SELECT X.NUR_SO_NAME                       ");
		sql.append("                                                            FROM NUR0112 X                              ");
		sql.append("                                                           WHERE X.HOSP_CODE = :hosp_code               ");
		sql.append("                                                             AND X.NUR_GR_CODE = '03'                   ");
		sql.append("                                                             AND X.NUR_MD_CODE = '0301'                 ");
		sql.append("                                                             AND X.NUR_SO_CODE = '001')                 ");
		sql.append("                                                       WHEN '009'                                       ");
		sql.append("                                                       THEN (SELECT X.NUR_SO_NAME                       ");
		sql.append("                                                            FROM NUR0112 X                              ");
		sql.append("                                                           WHERE X.HOSP_CODE = :hosp_code               ");
		sql.append("                                                             AND X.NUR_GR_CODE = '03'                   ");
		sql.append("                                                             AND X.NUR_MD_CODE = '0301'                 ");
		sql.append("                                                             AND X.NUR_SO_CODE = '009')                 ");
		sql.append("                                               END                                                      ");
		sql.append("                                            END) TIME_GUBUN3                                            ");
		sql.append("       , :f_send_yn                                SELECT_YN                                            ");
		sql.append("    FROM OCS2015 A                                                                                      ");
		sql.append("   WHERE A.HOSP_CODE = :hosp_code                                                                       ");
		sql.append("     AND A.BUNHO     = :bunho                                                                           ");
		sql.append("     AND A.DRT_DATE  BETWEEN :first_date AND :last_date                                                 ");
		sql.append("  GROUP BY A.BUNHO                                                                                      ");
		sql.append("         , A.FKINP1001                                                                                  ");
		sql.append("         , A.DRT_DATE                                                                                   ");
		sql.append("  ORDER BY A.DRT_DATE																					");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("first_date", firstDate);
		query.setParameter("last_date", lastDate);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		List<INPORDERTRANSGrdSiksaInfo> list = new JpaResultMapper().list(query, INPORDERTRANSGrdSiksaInfo.class);
		return list;
	}

	@Override
	public List<OCS6010U10OrderInfoCaseDfltInfo> getOCS6010U10OrderInfoCaseDfltInfo(String hospCode, String bunho,
			String fkinp1001, String inputGubun, String pkSeq, String actDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.ACT_DATE ACT_DATE																");
		sql.append("      , A.ACT_ID																		");
		sql.append("      , A.SURYANG																		");
		sql.append("      , CONCAT(SUBSTR(A.START_TIME, 1, 2), ':', SUBSTR(A.START_TIME, 3, 2)) START_TIME	");
		sql.append("      , A.END_DATE END_DATE																");
		sql.append("      , CONCAT(SUBSTR(A.END_TIME, 1, 2), ':', SUBSTR(A.END_TIME, 3, 2)) END_TIME		");
		sql.append("      , B.USER_NM ACT_USER																");
		sql.append("      , D.HANGMOG_NAME																	");
		sql.append("      , DATE_FORMAT(A.UPD_DATE, '%H:%i') ACT_TIME										");
		sql.append("      , ''																				");
		sql.append("   FROM OCS2015 A																		");
		sql.append("      JOIN ADM3200 B																	");
		sql.append("         ON  B.HOSP_CODE       = A.HOSP_CODE											");
		sql.append("         AND B.USER_ID         = A.ACT_ID												");
		sql.append("      LEFT JOIN OCS2016 C																");
		sql.append("         ON  C.HOSP_CODE    = A.HOSP_CODE												");
		sql.append("         AND C.FKOCS2015    = A.PKOCS2015												");
		sql.append("      LEFT JOIN OCS0103 D																");
		sql.append("         ON  D.HOSP_CODE    = C.HOSP_CODE												");
		sql.append("         AND D.HANGMOG_CODE = C.HANGMOG_CODE											");
		sql.append("  WHERE A.HOSP_CODE       = :f_hosp_code												");
		sql.append("    AND A.BUNHO           = :f_bunho													");
		sql.append("    AND A.FKINP1001       = :f_fkinp1001												");
		sql.append("    AND A.INPUT_GUBUN     = :f_input_gubun												");
		sql.append("    AND A.PK_SEQ          = :f_pk_seq													");
		sql.append("    AND A.ACT_DATE        = :f_act_date													");
		  
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", CommonUtils.parseDouble(pkSeq));
		query.setParameter("f_act_date", DateUtil.toDate(actDate, DateUtil.PATTERN_YYMMDD));
		List<OCS6010U10OrderInfoCaseDfltInfo> list = new JpaResultMapper().list(query, OCS6010U10OrderInfoCaseDfltInfo.class);
		return list;
	}

	@Override
	public List<OCS6010U10OrderInfoCaseDfltInfo> getOCS6010U10OrderInfoCase3Info(String hospCode, String bunho,
			String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.ACT_DATE ACT_DATE																");
		sql.append("      , A.ACT_ID																		");
		sql.append("      , A.SURYANG																		");
		sql.append("      , CONCAT(SUBSTR(A.START_TIME, 1, 2), ':', SUBSTR(A.START_TIME, 3, 2)) START_TIME	");
		sql.append("      , A.END_DATE END_DATE																");
		sql.append("      , CONCAT(SUBSTR(A.END_TIME, 1, 2), ':', SUBSTR(A.END_TIME, 3, 2)) END_TIME		");
		sql.append("      , B.USER_NM ACT_USER																");
		sql.append("      , D.HANGMOG_NAME																	");
		sql.append("      , ''																				");
		sql.append("      , (CONVERT(SUBSTRING(A.END_TIME, 1, 2), SIGNED INTEGER) 							");
		sql.append("       - CONVERT(SUBSTRING(A.START_TIME, 1, 2), SIGNED INTEGER)) * 60					");
		sql.append("       + (CONVERT(SUBSTRING(A.END_TIME, 3, 2), SIGNED INTEGER)							");
		sql.append("       - CONVERT(SUBSTRING(A.START_TIME, 3, 2), SIGNED INTEGER)) + 1 TOTAL_MINUTE		");
		sql.append("   FROM OCS2015 A																		");
		sql.append("      JOIN ADM3200 B																	");
		sql.append("         ON  B.HOSP_CODE    = A.HOSP_CODE												");
		sql.append("         AND B.USER_ID      = A.ACT_ID													");
		sql.append("      JOIN OCS2016 C																	");
		sql.append("         ON  C.FKOCS2015    = A.PKOCS2015												");
		sql.append("         AND C.HOSP_CODE    = A.HOSP_CODE												");
		sql.append("         AND C.BOM_YN       = 'P'														");
		sql.append("      JOIN OCS0103 D																	");
		sql.append("         ON  D.HOSP_CODE    = C.HOSP_CODE												");
		sql.append("         AND D.HANGMOG_CODE = C.HANGMOG_CODE											");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code													");
		sql.append("    AND A.BUNHO        = :f_bunho														");
		sql.append("    AND A.FKINP1001    = :f_fkinp1001													");
		sql.append("    AND A.ORDER_DATE   = :f_order_date													");
		sql.append("    AND A.INPUT_GUBUN  = :f_input_gubun													");
		sql.append("    AND A.PK_SEQ       = :f_pk_seq														");
		sql.append("    AND A.ACT_DATE     = :f_act_date													");
		  
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", CommonUtils.parseDouble(pkSeq));
		query.setParameter("f_act_date", DateUtil.toDate(actDate, DateUtil.PATTERN_YYMMDD));
		List<OCS6010U10OrderInfoCaseDfltInfo> list = new JpaResultMapper().list(query, OCS6010U10OrderInfoCaseDfltInfo.class);
		return list;
	}

	@Override
	public List<OCS6010U10OrderInfoCase2Info> getOCS6010U10OrderInfoCase2Info(String hospCode, String language,
			String bunho, String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.PKOCS2016    ,																	");
		sql.append("        B.FKOCS2015    ,																	");
		sql.append("        FN_BAS_TO_JAPAN_DATE_CONVERT(4, B.UPD_DATE, :f_hosp_code, :f_language) ACT_DATE,	");
		sql.append("        CASE B.TIME_GUBUN 																	");
		sql.append("         WHEN 0 THEN '1次' 																	");
		sql.append("         WHEN 1 THEN '2次' 																	");
		sql.append("         WHEN 2 THEN '3次' 																	");
		sql.append("         WHEN 3 THEN '4次' 																	");
		sql.append("         WHEN 4 THEN '5次' 																	");
		sql.append("         WHEN 5 THEN '6次' 																	");
		sql.append("         END TIME_GUBUN,																	");
		sql.append("        DATE_FORMAT(B.UPD_DATE, '%H:%i') ACT_TIME,											");
		sql.append("        CONCAT(B.SURYANG, '単位sc') SURYANG ,												");
		sql.append("        B.BLOOD_SUGAR,																		");
		sql.append("        CONCAT(IFNULL(B.SYS_ID, A.ACT_ID), ' / ', C.USER_NM) ACT_USER						");
		sql.append("   FROM OCS2015 A 																			");
		sql.append("      JOIN OCS2016 B 																		");
		sql.append("         ON  B.HOSP_CODE       = A.HOSP_CODE												");
		sql.append("         AND B.FKOCS2015       = A.PKOCS2015												");
		sql.append("      JOIN ADM3200 C																		");
		sql.append("         ON  C.HOSP_CODE       = A.HOSP_CODE												");
		sql.append("         AND C.USER_ID         = IFNULL(B.SYS_ID, A.ACT_ID)									");
		sql.append("  WHERE A.HOSP_CODE       = :f_hosp_code													");
		sql.append("    AND A.BUNHO           = :f_bunho														");
		sql.append("    AND A.FKINP1001       = :f_fkinp1001													");
		sql.append("    AND A.INPUT_GUBUN     = :f_input_gubun													");
		sql.append("    AND A.ORDER_DATE      = :f_order_date													");
		sql.append("    AND A.PK_SEQ          = :f_pk_seq 														");
		sql.append("    AND A.ACT_DATE        = :f_act_date 													");
		sql.append("  ORDER BY B.TIME_GUBUN																		");
		  
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", CommonUtils.parseDouble(pkSeq));
		query.setParameter("f_act_date", DateUtil.toDate(actDate, DateUtil.PATTERN_YYMMDD));
		List<OCS6010U10OrderInfoCase2Info> list = new JpaResultMapper().list(query, OCS6010U10OrderInfoCase2Info.class);
		return list;
	}
	
	@Override
	public Double getNextSeqOcs2015(String hospCode, String bunho, Double fkinp1001, Date orderDate, String inputGubun, Double pkSeq) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT IFNULL(MAX(SEQ), 0) + 1 SEQ		");
		sql.append("  FROM OCS2015								");
		sql.append("  WHERE HOSP_CODE   = :f_hosp_code			");
		sql.append("    AND BUNHO       = :f_bunho				");
		sql.append("    AND FKINP1001   = :f_fkinp1001			");
		sql.append("    AND ORDER_DATE  = :f_order_date			");
		sql.append("    AND INPUT_GUBUN = :f_input_gubun		");
		sql.append("    AND PK_SEQ      = :f_pk_seq				");
		sql.append("    AND DATE(ACT_DATE)    = DATE(SYSDATE())	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", pkSeq);
		
		List<Double> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? 1.0 : result.get(0);
	}

	@Override
	public List<OCS2005U00grdOCS2015Info> getOCS2005U00grdOCS2015Info(String hospCode, String pkSeq, String inputGubun,
			String fkinp1001, String bunho, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT A.PKOCS2015						");
		sql.append("	     , A.BUNHO							");
		sql.append("	     , A.ORDER_DATE						");
		sql.append("	     , A.ACT_DATE						");
		sql.append("	     , A.PK_SEQ							");
		sql.append("	     , A.ACT_ID 						");
		sql.append("	  FROM OCS2015 A						");
		sql.append("	  WHERE A.HOSP_CODE   = :f_hosp_code	");
		sql.append("	   AND A.PK_SEQ      = :f_pk_seq		");
		sql.append("	   AND A.INPUT_GUBUN = :f_input_gubun	");
		sql.append("	   AND A.FKINP1001   = :f_fkinp1001		");
		sql.append("	   AND A.BUNHO       = :f_bunho			");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pk_seq", CommonUtils.parseDouble(pkSeq));
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_bunho", bunho);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS2005U00grdOCS2015Info> lstResult = new JpaResultMapper().list(query, OCS2005U00grdOCS2015Info.class);
		return lstResult;
	}
	
	@Override
	public BigInteger countOcs2015InOCS6010U10(String hospCode, String bunho, Double fkinp1001, Date sourceOrderDate,
			String inputGubun, Double pk) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT COUNT(*)	                         ");
		sql.append("	FROM OCS2015 A	                         ");
		sql.append("	WHERE HOSP_CODE   = :f_hosp_code         ");
		sql.append("	  AND BUNHO       = :f_bunho			 ");
		sql.append("	  AND FKINP1001   = :f_fkinp1001		 ");
		sql.append("	  AND ORDER_DATE  = :f_source_order_date ");
		sql.append("	  AND ACT_DATE    IS NOT NULL			 ");
		sql.append("	  AND INPUT_GUBUN = :f_input_gubun		 ");
		sql.append("	  AND PK_SEQ      = :f_pk				 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_source_order_date", sourceOrderDate);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk", pk);
		
		List<BigInteger> list = query.getResultList();
		return list.get(0);
	}
	
	@Override
	public List<ComboListItemInfo> OCS2005U02getMinMaxDate(String hospCode, Double fkocs2005, String fromDate, String toDate){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT IFNULL(DATE_FORMAT(LEAST(IFNULL(MIN(STR_TO_DATE(:f_drt_from_date, '%Y/%m/%d')), MIN(B.DRT_DATE)),						");
		sql.append("                 IFNULL(MIN(B.DRT_DATE), MIN(STR_TO_DATE(:f_drt_from_date,'%Y/%m/%d')))),'%Y/%m/%d'),'') AS MIN_NUT_DATE			");
		sql.append("          , IFNULL(DATE_FORMAT(GREATEST(IFNULL(MAX(STR_TO_DATE(:f_drt_to_date,'%Y/%m/%d')),   MAX(B.DRT_DATE)),						");
		sql.append("                 IFNULL(MAX(B.DRT_DATE), MAX(STR_TO_DATE(:f_drt_to_date,'%Y/%m/%d')))),'%Y/%m/%d'),'')   AS MAX_NUT_DATE			");
		sql.append("       FROM OCS2015 B																												");
		sql.append("      WHERE B.HOSP_CODE = :f_hosp_code																								");
		sql.append("        AND B.FKOCS2005 = :f_pkocs2005																								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_drt_from_date", fromDate);
		query.setParameter("f_drt_to_date", toDate);
		query.setParameter("f_pkocs2005", fkocs2005);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS6010U10PopupTAgrdOCS2015Info> getOCS6010U10PopupTAgrdOCS2015Info(String hospCode, String bunho,
			String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate, Integer startNum,
			Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.PKOCS2015      ,                   ");
		sql.append("	       A.BUNHO          ,                   ");
		sql.append("	       A.FKINP1001      ,                   ");
		sql.append("	       A.ORDER_DATE     ,                   ");
		sql.append("	       A.INPUT_GUBUN    ,                   ");
		sql.append("	       A.PK_SEQ         ,                   ");
		sql.append("	       A.SEQ            ,                   ");
		sql.append("	       A.ACT_DATE       ,                   ");
		sql.append("	       A.ACT_ID         ,                   ");
		sql.append("	       A.ACT_RESULT_CODE,                   ");
		sql.append("	       A.ACT_RESULT_TEXT,                   ");
		sql.append("	       A.INPUT_ID       ,                   ");
		sql.append("	       A.INPUT_GWA      ,                   ");
		sql.append("	       A.INPUT_DOCTOR   ,                   ");
		sql.append("	       ''				                    ");
		sql.append("	  FROM OCS2015 A		                    ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code		");
		sql.append("	   AND A.BUNHO          = :f_bunho			");
		sql.append("	   AND A.FKINP1001      = :f_fkinp1001		");
		sql.append("	   AND A.ORDER_DATE     = :f_order_date		");
		sql.append("	   AND A.INPUT_GUBUN    = :f_input_gubun	");
		sql.append("	   AND A.PK_SEQ         = :f_pk_seq			");
		sql.append("	   AND A.ACT_DATE       = :f_act_date		");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", CommonUtils.parseDouble(pkSeq));
		query.setParameter("f_act_date", DateUtil.toDate(actDate, DateUtil.PATTERN_YYMMDD));
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS6010U10PopupTAgrdOCS2015Info> lstResult = new JpaResultMapper().list(query, OCS6010U10PopupTAgrdOCS2015Info.class);
		return lstResult;
	}

	@Override
	public List<RecoveryMaxMinInfo> getRecoveryMaxMinInfo(String hospCode, Double pkocs2005, Date drtFromDate, Date drtToDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT LEAST(IFNULL(MIN(:f_drt_from_date), MIN(B.DRT_DATE)), IFNULL(MIN(B.DRT_DATE), MIN(:f_drt_from_date)))  AS MIN_NUT_DATE	");
		sql.append("	     , GREATEST(IFNULL(MAX(:f_drt_to_date),   MAX(B.DRT_DATE)), IFNULL(MAX(B.DRT_DATE), MAX(:f_drt_to_date))) AS MAX_NUT_DATE	");
		sql.append("	FROM OCS2015 B																													");
		sql.append("	WHERE B.HOSP_CODE = :f_hosp_code																								");
		sql.append("	  AND B.FKOCS2005 = :f_pkocs2005																								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_pkocs2005", pkocs2005);
		query.setParameter("f_drt_from_date", drtFromDate);
		query.setParameter("f_drt_to_date", drtToDate);
		
		List<RecoveryMaxMinInfo> lstResult = new JpaResultMapper().list(query, RecoveryMaxMinInfo.class);
		return lstResult;
	}

	@Override
	public Double getOCS6010U10frmARActingSeqOCS2015(String hospCode, String bunho, String fkinp1001,
			String orderDate, String inputGubun, String pkSeq) {

		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(MAX(A.SEQ), 0) + 1 SEQ								");
		sql.append(" FROM OCS2015 A				     									");
		sql.append(" WHERE A.HOSP_CODE  		= :f_hosp_code				     		");
		sql.append("   AND A.BUNHO       	= :f_bunho				     				");
		sql.append("   AND A.FKINP1001   	= :f_fkinp1001				     			");
		sql.append("   AND A.ORDER_DATE  	= STR_TO_DATE(:f_order_date, '%Y/%m/%d')	");
		sql.append("   AND A.INPUT_GUBUN 	= :f_input_gubun				     		");
		sql.append("   AND A.PK_SEQ      	= :f_pk_seq				     				");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", pkSeq);
		
		List<Double> listResult = query.getResultList();
		return CollectionUtils.isEmpty(listResult) ? null : listResult.get(0);
	}

	@Override
	public List<OCS6010U10frmDirectActinggrdOCS2015Info> getOCS6010U10frmDirectActinggrdOCS2015Info(String hospCode,
			String bunho, String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate,
			Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BUNHO          ,                           ");
		sql.append("	       A.FKINP1001      ,                           ");
		sql.append("	       A.ORDER_DATE     ,                           ");
		sql.append("	       A.INPUT_GUBUN    ,                           ");
		sql.append("	       A.INPUT_ID       ,                           ");
		sql.append("	       A.PK_SEQ         ,                           ");
		sql.append("	       A.SEQ            ,                           ");
		sql.append("	       A.ACT_DATE       ,                           ");
		sql.append("	       A.ACT_ID         ,                           ");
		sql.append("	       B.USER_NM        ,                           ");
		sql.append("	       A.ACT_RESULT_CODE,                           ");
		sql.append("	       A.ACT_RESULT_TEXT,                           ");
		sql.append("	       A.PKOCS2015      ,                           ");
		sql.append("	       A.INPUT_GWA      ,                           ");
		sql.append("	       A.INPUT_DOCTOR   ,                           ");
		sql.append("	       DATE_FORMAT(A.UPD_DATE, 'H:%m') ACT_TIME,	");
		sql.append("	       ''											");
		sql.append("	  FROM OCS2015 A ,									");
		sql.append("	       ADM3200 B									");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code					");
		sql.append("	   AND B.HOSP_CODE   = A.HOSP_CODE					");
		sql.append("	   AND B.USER_ID     = A.ACT_ID						");
		sql.append("	   AND A.BUNHO       = :f_bunho						");
		sql.append("	   AND A.FKINP1001   = :f_fkinp1001					");
		sql.append("	   AND A.ORDER_DATE  = :f_order_date				");
		sql.append("	   AND A.INPUT_GUBUN = :f_input_gubun				");
		sql.append("	   AND A.PK_SEQ      = :f_pk_seq					");
		sql.append("	   AND A.ACT_DATE    = :f_act_date					");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", CommonUtils.parseDouble(fkinp1001));
		query.setParameter("f_order_date", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", CommonUtils.parseDouble(pkSeq));
		query.setParameter("f_act_date", DateUtil.toDate(actDate, DateUtil.PATTERN_YYMMDD));
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS6010U10frmDirectActinggrdOCS2015Info> lstResult = new JpaResultMapper().list(query, OCS6010U10frmDirectActinggrdOCS2015Info.class);
		return lstResult;
	}

	@Override
	public Double getNextSeqOcs2015Ext(String hospCode, String bunho, Double fkinp1001, Date orderDate,
			String inputGubun, Double pkSeq) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT IFNULL(MAX(SEQ), 0) + 1 SEQ		");
		sql.append("  FROM OCS2015								");
		sql.append("  WHERE HOSP_CODE   = :f_hosp_code			");
		sql.append("    AND BUNHO       = :f_bunho				");
		sql.append("    AND FKINP1001   = :f_fkinp1001			");
		sql.append("    AND ORDER_DATE  = :f_order_date			");
		sql.append("    AND INPUT_GUBUN = :f_input_gubun		");
		sql.append("    AND PK_SEQ      = :f_pk_seq				");
		sql.append("    LIMIT 1									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", pkSeq);
		
		List<Double> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? 1.0 : result.get(0);
	}

	@Override
	public OCS6010U10PopupTAProcDAOTInfo callPrOcsDirectActOrderTreat(String hospCode, String language, String bunho,
			String fkinp1001, String orderDate, String inputGubun, String pkocs2015, String actingDate, String userId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_DIRECT_ACT_ORDER_TREAT");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
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
	    query.setParameter("I_LANGUAGE", language);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_FKINP1001", CommonUtils.parseDouble(fkinp1001));
	    query.setParameter("I_ORDER_DATE", DateUtil.toDate(orderDate, DateUtil.PATTERN_YYMMDD));
	    query.setParameter("I_INPUT_GUBUN", inputGubun);
	    query.setParameter("I_PKOCS2015", CommonUtils.parseDouble(pkocs2015));
	    query.setParameter("I_ACTING_DATE", DateUtil.toDate(actingDate, DateUtil.PATTERN_YYMMDD));
	    query.setParameter("I_USER_ID", userId);
	    
		query.execute();
		OCS6010U10PopupTAProcDAOTInfo result = new OCS6010U10PopupTAProcDAOTInfo( (String)query.getOutputParameterValue("IO_MSG")                                           
		          ,(String)query.getOutputParameterValue("IO_FLAG")       );
		return result;
	}
	
	@Override
	public CommonProcResultInfo callPrOcsiIsJisiDateime(String hospCode, String iud, String gubun, String bunho,
			Double fkinp1001, Date fromDate, String fromTime, Date toDate, String toTime, String userId) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCSI_IS_JISI_DATETIME");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);      
	    query.registerStoredProcedureParameter("O_MSG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_IUD", iud);
	    query.setParameter("I_GUBUN", gubun);
	    query.setParameter("I_BUNHO", bunho);
	    query.setParameter("I_FKINP1001", fkinp1001);
	    query.setParameter("I_FROM_DATE", fromDate);
	    query.setParameter("I_FROM_TIME", fromTime);
	    query.setParameter("I_TO_DATE", toDate);
	    query.setParameter("I_TO_TIME", toTime);
	    query.setParameter("I_USER", userId);
	    
	    query.execute();
	    
		String err = (String)query.getOutputParameterValue("O_ERR");
		String msg = (String)query.getOutputParameterValue("O_MSG");
	    
		CommonProcResultInfo info = new CommonProcResultInfo();
		info.setStrResult1(err == null ? "" : err);
		info.setStrResult2(msg == null ? "" : msg);
		
		return info;
	}

	@Override
	public List<ComboListItemInfo> getOCS6010U10PopupIAbtnList(String hospCode, String bunho, String orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT				                           							");
		sql.append("		DISTINCT C.ORD_DANUI ORD_DANUI,				                        ");
		sql.append("		D.CODE_NAME ORD_DANUI_NAME				                            ");
		sql.append("	FROM				                           							");
		sql.append("		OCS2015 A 	JOIN 	OCS2006 B				                        ");
		sql.append("					ON		A.HOSP_CODE 	= B.HOSP_CODE				    ");
		sql.append("					AND 	A.BUNHO      	= B.BUNHO				        ");
		sql.append("					AND 	A.ORDER_DATE 	= B.ORDER_DATE				    ");
		sql.append("					AND 	A.PK_SEQ     	= B.PK_SEQ				        ");
		sql.append("					JOIN 	NUR0115 C				                        ");
		sql.append("					ON 		B.HOSP_CODE    	= C.HOSP_CODE				    ");
		sql.append("					AND 	B.DIRECT_GUBUN  = C.NUR_GR_CODE				    ");
		sql.append("					AND 	B.DIRECT_CODE  	= C.NUR_MD_CODE				    ");
		sql.append("					AND 	B.HANGMOG_CODE 	= C.HANGMOG_CODE				");
		sql.append("					JOIN 	OCS0132 D				                        ");
		sql.append("					ON 		C.HOSP_CODE 	= D.HOSP_CODE				    ");
		sql.append("					AND 	C.ORD_DANUI     = D.CODE				        ");
		sql.append("	WHERE				                           							");
		sql.append("		A.HOSP_CODE  		= :f_hosp_code				                    ");
		sql.append("		AND A.BUNHO      	= :f_bunho				                        ");
		sql.append("		AND A.ORDER_DATE 	>= STR_TO_DATE(:f_order_date, '%Y/%m/%d')		");
		sql.append("		AND (C.NUR_MD_CODE  = '2030' OR C.NUR_MD_CODE  = '2033')			");
		sql.append("		AND D.CODE_TYPE 	= 'ORD_DANUI'				                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}
	
	@Override
	public CommonProcResultInfo callPrOcsiMarumeIud(String hospCode, String iudGubun, double key) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCSI_MARUME_IUD");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_KEY", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", Integer.class, ParameterMode.INOUT);      
	    query.registerStoredProcedureParameter("O_ERR_MSG", String.class, ParameterMode.INOUT);
		
	    query.setParameter("I_HOSP_CODE", hospCode);
	    query.setParameter("I_IUD_GUBUN", iudGubun);
	    query.setParameter("I_KEY", key);
	    
	    query.execute();
	    Integer err = (Integer)query.getOutputParameterValue("O_ERR");
		String msg = (String)query.getOutputParameterValue("O_ERR_MSG");
	    
		CommonProcResultInfo info = new CommonProcResultInfo();
		info.setStrResult1(err == null ? "" : String.valueOf(err));
		info.setStrResult2(msg == null ? "" : msg);
		
		return info;
	}

	@Override
	public List<OCS6010U10PopupIAgrdOCS2015Info> getOCS6010U10PopupIAgrdOCS2015(String hospCode, String bunho,
			String fkinp1001, String orderDate, String inputGubun, String pkSeq, String actDate, String offset,
			String pageNumber) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT				                           					");
		sql.append("	    A.BUNHO,				                           			");
		sql.append("	    CAST(A.FKINP1001 AS CHAR),				                    ");
		sql.append("	    IFNULL(STR_TO_DATE(A.ORDER_DATE, '%Y/%m/%d'), ''),			");
		sql.append("	    A.INPUT_GUBUN,				                           		");
		sql.append("	    A.INPUT_ID,				                           			");
		sql.append("	    CAST(A.PK_SEQ AS CHAR),				                        ");
		sql.append("	    IFNULL(STR_TO_DATE(A.DRT_DATE, '%Y/%m/%d'), ''),			");
		sql.append("	    IFNULL(STR_TO_DATE(A.ACT_DATE, '%Y/%m/%d'), ''),			");
		sql.append("	    A.ACT_ID,				                           			");
		sql.append("	    IFNULL(A.ACT_RESULT_TEXT, ''),				                ");
		sql.append("	    C.USER_NM,				                           			");
		sql.append("	    DATE_FORMAT(A.ACT_DATE, 'HH24:MI'),				            ");
		sql.append("	    IFNULL(A.BLOOD_SUGAR, ''),				                    ");
		sql.append("	    A.TIME_GUBUN,				                           		");
		sql.append("	    CAST(A.PKOCS2015 AS CHAR)				                    ");
		sql.append("	FROM				                           					");
		sql.append("	  	OCS2015 A 	JOIN 	ADM3200 C				                ");
		sql.append("	            	ON 		A.HOSP_CODE	= C.HOSP_CODE				");
		sql.append("	            	AND 	A.ACT_ID    = C.USER_ID				    ");
		sql.append("	WHERE				                           					");
		sql.append("	  A.HOSP_CODE    	= :f_hosp_code				                ");
		sql.append("	  AND A.BUNHO       = :f_bunho				                    ");
		sql.append("	  AND A.FKINP1001   = :f_fkinp1001				                ");
		sql.append("	  AND A.ORDER_DATE  = STR_TO_DATE(:f_order_date, '%Y/%m/%d')	");
		sql.append("	  AND A.INPUT_GUBUN = :f_input_gubun				            ");
		sql.append("	  AND A.PK_SEQ      = :f_pk_seq 				                ");
		sql.append("	  AND A.ACT_DATE    = STR_TO_DATE(:f_act_date, '%Y/%m/%d')		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", pkSeq);
		query.setParameter("f_act_date", actDate);
		
		List<OCS6010U10PopupIAgrdOCS2015Info> listInfo = new JpaResultMapper().list(query, OCS6010U10PopupIAgrdOCS2015Info.class);
		return listInfo;
	}
	
	@Override
	public Double getNextSeqOcs2015InFrmDrugAting(String hospCode, String bunho, Double fkinp1001, Date orderDate, String inputGubun, Double pkSeq, Date actDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT IFNULL(MAX(SEQ), 0) + 1 SEQ		");
		sql.append("  FROM OCS2015								");
		sql.append("  WHERE HOSP_CODE   = :f_hosp_code			");
		sql.append("    AND BUNHO       = :f_bunho				");
		sql.append("    AND FKINP1001   = :f_fkinp1001			");
		sql.append("    AND ORDER_DATE  = :f_order_date			");
		sql.append("    AND INPUT_GUBUN = :f_input_gubun		");
		sql.append("    AND PK_SEQ      = :f_pk_seq				");
		sql.append("    AND ACT_DATE    = :f_act_date			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pk_seq", pkSeq);
		query.setParameter(":f_act_date", actDate);
		
		List<Double> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? 1.0 : result.get(0);
	}

	@Override
	public String getXOCS6010U10PopupO2ASavePerformer(String hospCode, String bunho, double fkinp1001,
			String inputGubun, double pkseq, Date actDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'X'											");
		sql.append("	FROM OCS2015 A										");
		sql.append("	JOIN ADM3200 B ON B.HOSP_CODE   = A.HOSP_CODE		");
		sql.append("	              AND B.USER_ID     = A.ACT_ID			");
		sql.append("	WHERE A.HOSP_CODE  = :f_hosp_code					");
		sql.append("	 AND A.BUNHO       = :f_bunho						");
		sql.append("	 AND A.FKINP1001   = :f_fkinp1001					");
		sql.append("	 AND A.INPUT_GUBUN = :f_input_gubun					");
		sql.append("	 AND A.PK_SEQ      = :f_pkseq						");
		sql.append("	 AND A.ACT_DATE    = :f_act_date					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_input_gubun", inputGubun);
		query.setParameter("f_pkseq", pkseq);
		query.setParameter("f_act_date", actDate);
		
		List<String> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? "" : result.get(0);
	}

	@Override
	public List<INPORDERTRANSSelectListSQL1Info> getINPORDERTRANSSelectListSQL1Info(String hospCode, String language,
			String bunho, String yyyyMm, Date yyyyMMddFirst, Date yyyyMMddLast) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  B.PKINP1001                                                 						PKINP1001			                              ");
		sql.append("	      , A.BUNHO                                                     						BUNHO 				                              ");
		sql.append("	      , C.SUNAME                                                    						SUNAME				                              ");
		sql.append("	      , B.IPWON_DATE                                                						IPWON_DATE			                              ");
		sql.append("	      , B.IPWON_TIME                                                						IPWON_TIME			                              ");
		sql.append("	      , B.GWA                                                       						GWA					                              ");
		sql.append("	      , F.ORG_DOCTOR                                                						DOCTOR				                              ");
		sql.append("	      , FN_BAS_LOAD_GWA_NAME(B.GWA, A.ORDER_DATE, :f_hosp_code, :f_language)               	GWA_NAME 			                              ");
		sql.append("	      , FN_BAS_LOAD_DOCTOR_NAME(CONCAT(B.GWA,F.ORG_DOCTOR), A.ORDER_DATE, :f_hosp_code) 	DOCTOR_NAME			                              ");
		sql.append("	      , MAX(FN_BAS_LOAD_GWA_NAME(D.TO_HO_DONG1, A.ORDER_DATE, :f_hosp_code, :f_language))   HO_DONG				                              ");
		sql.append("	      , MAX(D.TO_HO_CODE1)                                          						HO_CODE				                              ");
		sql.append("	      , MAX(STR_TO_DATE(FN_NUT_GET_IFS_PROC_DATE(A.HOSP_CODE, A.FKINP1001, A.BUNHO, :f_yyyymm), '%Y%m%d') )  SEND_DATE                        ");
		sql.append("	      /*, MAX(FN_OCSI_NUT_TRANSFER_CHK(A.BUNHO, A.FKINP1001))         						TRANS_YN Query IFS table*/						  ");
		sql.append("		  , '0'																					TRANS_YN										  ");
		sql.append("	FROM OCS2015 A										                                                                                          ");
		sql.append("	JOIN INP1001 B ON B.HOSP_CODE       = A.HOSP_CODE	                                                                                          ");
		sql.append("				  AND B.BUNHO           = A.BUNHO		                                                                                          ");
		sql.append("				  AND B.PKINP1001       = A.FKINP1001	                                                                                          ");
		sql.append("	JOIN OUT0101 C ON C.HOSP_CODE       = A.HOSP_CODE	                                                                                          ");
		sql.append("				  AND C.BUNHO           = A.BUNHO		                                                                                          ");
		sql.append("	JOIN /*VW_OCS_INP2004*/(							                                                                                          ");
		sql.append("		SELECT 	A.HOSP_CODE,							                                                                                          ");
		sql.append("	            A.BUNHO,								                                                                                          ");
		sql.append("				DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)	AS JAEWON_DATE,                                                                   ");
		sql.append("				B.TO_HO_DONG1,	                                                                                                                  ");
		sql.append("				B.TO_HO_CODE1	                                                                                                                  ");
		sql.append("		FROM 	VW_OCS_INP1001_01 A,                                                                                                              ");
		sql.append("				INP2004 B,	                                                                                                                      ");
		sql.append("				INP2004 BN,	                                                                                                                      ");
		sql.append("				(			                                                                                                                      ");
		sql.append("				  SELECT @rownr:=@rownr+1 AS ADD_DAY                                                                                              ");
		sql.append("					FROM INP1001, (SELECT @rownr:=-1) TMP                                                                                         ");
		sql.append("				) AA						                                                                                                      ");
		sql.append("		WHERE A.HOSP_CODE = :f_hosp_code	                                                                                                      ");
		sql.append("		AND   A.BUNHO 	  = :f_bunho		                                                                                                      ");
		sql.append("		AND AA.ADD_DAY <= DATEDIFF(IFNULL(A.TOIWON_DATE, CURRENT_DATE()), A.IPWON_DATE) + 31                                                      ");
		sql.append("		AND B.HOSP_CODE = A.HOSP_CODE                                                                                                             ");
		sql.append("		AND B.FKINP1001 = A.PKINP1001                                                                                                             ");
		sql.append("		AND IFNULL(B.CANCEL_YN,'N') = 'N'                                                                                                         ");
		sql.append("													                                                                                              ");
		sql.append("		AND B.START_DATE =(SELECT MAX(Z.START_DATE)	                                                                                              ");
		sql.append("		   FROM INP2004 Z							                                                                                              ");
		sql.append("		   WHERE     Z.HOSP_CODE = B.HOSP_CODE		                                                                                              ");
		sql.append("		   AND Z.FKINP1001 = B.FKINP1001			                                                                                              ");
		sql.append("		   AND IFNULL(Z.CANCEL_YN,'N') = 'N'		                                                                                              ");
		sql.append("		   AND Z.TO_NURSE_CONFIRM_DATE IS NOT NULL	                                                                                              ");
		sql.append("		   AND Z.START_DATE <=DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)                                                                     ");
		sql.append("		   AND (Z.END_DATE IS NULL																												  ");
		sql.append("		   OR Z.END_DATE >= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)))	                                                                  ");
		sql.append("		   																		                                                                  ");
		sql.append("		AND B.TRANS_CNT =(SELECT MAX(Z.TRANS_CNT)								                                                                  ");
		sql.append("		   FROM INP2004 Z														                                                                  ");
		sql.append("		   WHERE     Z.HOSP_CODE = B.HOSP_CODE									                                                                  ");
		sql.append("		   AND Z.BUNHO = B.BUNHO		                                                                                                          ");
		sql.append("		   AND Z.FKINP1001 = B.FKINP1001                                                                                                          ");
		sql.append("		   AND IFNULL(Z.CANCEL_YN,'N') = 'N'                                                                                                      ");
		sql.append("		   AND Z.TO_NURSE_CONFIRM_DATE IS NOT NULL                                                                                                ");
		sql.append("		   AND Z.START_DATE = B.START_DATE)	                                                                                                      ");
		sql.append("		AND BN.HOSP_CODE = A.HOSP_CODE		                                                                                                      ");
		sql.append("		AND BN.FKINP1001 = A.PKINP1001		                                                                                                      ");
		sql.append("		AND IFNULL(BN.CANCEL_YN,'N') = 'N'	                                                                                                      ");
		sql.append("											                                                                                                      ");
		sql.append("		AND BN.START_DATE =(SELECT MAX(Z.START_DATE)                                                                                              ");
		sql.append("		   FROM INP2004 Z							                                                                                              ");
		sql.append("		   WHERE     Z.HOSP_CODE = BN.HOSP_CODE		                                                                                              ");
		sql.append("		   AND Z.FKINP1001 = BN.FKINP1001			                                                                                              ");
		sql.append("		   AND IFNULL(Z.CANCEL_YN,'N') = 'N'		                                                                                              ");
		sql.append("		   AND Z.TO_NURSE_CONFIRM_DATE IS NOT NULL	                                                                                              ");
		sql.append("		   AND Z.START_DATE <= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)                                                                    ");
		sql.append("		   AND (Z.END_DATE IS NULL												                                                                  ");
		sql.append("		   OR Z.END_DATE >= DATE_ADD(A.IPWON_DATE, INTERVAL AA.ADD_DAY DAY)))	                                                                  ");
		sql.append("		   																		                                                                  ");
		sql.append("		AND BN.TRANS_CNT =(SELECT MIN(Z.TRANS_CNT)								                                                                  ");
		sql.append("		   FROM INP2004 Z														                                                                  ");
		sql.append("		   WHERE     Z.HOSP_CODE = BN.HOSP_CODE									                                                                  ");
		sql.append("		   AND Z.BUNHO = BN.BUNHO												                                                                  ");
		sql.append("		   AND Z.FKINP1001 = BN.FKINP1001	                                                                                                      ");
		sql.append("		   AND IFNULL(Z.CANCEL_YN,'N') = 'N'                                                                                                      ");
		sql.append("		   AND Z.TO_NURSE_CONFIRM_DATE IS NOT NULL                                                                                                ");
		sql.append("		   AND Z.START_DATE = BN.START_DATE)	                                                                                                  ");
		sql.append("	) D ON D.HOSP_CODE       = A.HOSP_CODE		                                                                                                  ");
		sql.append("						 AND D.BUNHO           = A.BUNHO                                                                                          ");
		sql.append("						 AND D.JAEWON_DATE     = A.DRT_DATE                                                                                       ");
		sql.append("	JOIN BAS0270 F ON F.HOSP_CODE       = B.HOSP_CODE	                                                                                          ");
		sql.append("				  AND F.DOCTOR          = B.DOCTOR		                                                                                          ");
		sql.append("	,(select @kcck_hosp_code \\:= :f_hosp_code) TMP		                                                                                          ");
		sql.append("	WHERE A.HOSP_CODE       = :f_hosp_code				                                                                                          ");
		sql.append("	  AND A.BUNHO           = :f_bunho					                                                                                          ");
		sql.append("	  AND A.DRT_DATE BETWEEN :f_yyyymmdd_first AND :f_yyyymmdd_last                                                                               ");
		sql.append("	GROUP BY   B.PKINP1001                                       			                                                                      ");
		sql.append("			 , A.BUNHO                                                                                                                            ");
		sql.append("			 , C.SUNAME                                                                                                                           ");
		sql.append("			 , B.IPWON_DATE                                             	                                                                      ");
		sql.append("			 , B.IPWON_TIME                                                                                                                       ");
		sql.append("			 , B.GWA                                                                                                                              ");
		sql.append("			 , F.ORG_DOCTOR                                                                                                                       ");
		sql.append("			 , FN_BAS_LOAD_GWA_NAME (B.GWA, A.ORDER_DATE, :f_hosp_code, :f_language)                                                              ");
		sql.append("			 , FN_BAS_LOAD_DOCTOR_NAME (CONCAT(B.GWA, F.ORG_DOCTOR), A.ORDER_DATE, :f_hosp_code)												  ");
		sql.append("			 , IF(B.TOIWON_DATE IS NULL, 'N', 'Y')																								  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_language", language);
		query.setParameter("f_yyyymm", yyyyMm);
		query.setParameter("f_yyyymmdd_first", yyyyMMddFirst);
		query.setParameter("f_yyyymmdd_last", yyyyMMddLast);
		
		List<INPORDERTRANSSelectListSQL1Info> listInfo = new JpaResultMapper().list(query, INPORDERTRANSSelectListSQL1Info.class);
		return listInfo;
	}
	
	
}
