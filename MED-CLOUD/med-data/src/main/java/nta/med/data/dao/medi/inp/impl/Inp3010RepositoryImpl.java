package nta.med.data.dao.medi.inp.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inp.Inp3010RepositoryCustom;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListNonSendYnInfo;

/**
 * @author dainguyen.
 */
public class Inp3010RepositoryImpl implements Inp3010RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<ORDERTRANSGrdListInfo> getORDERTRANSGrdListInfoCase0ElseElse(
			String hospCode, String language, String ioGubun, String sendYn, String bunho) {
		StringBuilder sql= new StringBuilder();
		sql.append("  SELECT DISTINCT  A.PKINP3010                                                                                                                                                      ");
		sql.append("     , A.BUNHO                                                   BUNHO                                                                                                              ");
		sql.append("     , C.SUNAME                                                  SUNAME                                                                                                             ");
		sql.append("     , B.IPWON_DATE                                              IPWON_DATE                                                                                                         ");
		sql.append("     , B.IPWON_TIME                                              IPWON_TIME                                                                                                         ");
		sql.append("     , A.GWA                                                     GWA                                                                                                                ");
		sql.append("     , A.DOCTOR                                                  DOCTOR                                                                                                             ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME (A.GWA, A.ACTING_DATE,:f_hosp_code,:f_language)               GWA_NAME                                                                                  ");
		sql.append("     , FN_BAS_LOAD_DOCTOR_NAME (A.DOCTOR, A.ACTING_DATE, :f_hosp_code)         DOCTOR_NAME                                                                                          ");
		sql.append("     , D.GUBUN                                                   GUBUN                                                                                                              ");
		sql.append("     , E.GUBUN_NAME                                              GUBUN_NAME                                                                                                         ");
		sql.append("     , IFNULL(E.GONGBI_YN,'Y')                                      GONGBI_YN                                                                                                       ");
		sql.append("     , B.CHOJAE                                                                                                                                                                     ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('CHOJAE', B.CHOJAE , :f_hosp_code,:f_language)                CHOJAE_NAME                                                                              ");
		sql.append("     , D.PKINP1002                                                                                                                                                                  ");
		sql.append("     , A.ACTING_DATE                                             ACTING_DATE                                                                                                        ");
		sql.append("     , A.ACTING_DATE                                             ORDER_DATE                                                                                                         ");
		sql.append("     , D.GUBUN                                                   GUBUN_OLD                                                                                                          ");
		sql.append("     , B.CHOJAE                                                  CHOJAE_OLD                                                                                                         ");
		sql.append("     , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 1)   GONGBI_CODE1                                                            ");
		sql.append("     , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 2)   GONGBI_CODE2                                                            ");
		sql.append("     , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 3)   GONGBI_CODE3                                                            ");
		sql.append("     , FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 4)   GONGBI_CODE4                                                            ");
		sql.append("     , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 1), A.ACTING_DATE, :f_language) GONGBI_CODE1_NAME                 ");
		sql.append("     , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 2), A.ACTING_DATE, :f_language) GONGBI_CODE2_NAME                 ");
		sql.append("     , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 3), A.ACTING_DATE, :f_language) GONGBI_CODE3_NAME                 ");
		sql.append("     , FN_BAS_LOAD_GONGBI_NAME(FN_OUT_LOAD_JUBSU_GONGBI_CODE(:f_hosp_code,:f_io_gubun, :f_send_yn, A.PKINP3010, A.ACTING_DATE, 4), A.ACTING_DATE, :f_language) GONGBI_CODE4_NAME                 ");
		sql.append("     , A.PKINP3010                                               PKOUT                                                                                                              ");
		sql.append("     , ''                                                        SEND_DATE                                                                                                          ");
		sql.append("     , '1'                                                       SANJUNG_GUBUN                                                                                                      ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('JINCHAL_SANJUNG_GUBUN', '1', :f_hosp_code,:f_language )      SANJUNG_GUBUN_NAME                                                                       ");
		sql.append("     , '0'                                                         IF_VALID_YN                                                                                                      ");
		sql.append("      FROM INP3010 A                                                                                                                                                                ");
		sql.append("         , INP1001 B                                                                                                                                                                ");
		sql.append("         , OUT0101 C                                                                                                                                                                ");
		sql.append("         , INP1002 D                                                                                                                                                                ");
		sql.append("         , BAS0210 E                                                                                                                                                                ");
		sql.append("     WHERE A.HOSP_CODE   = :f_hosp_code                                                                                                                                             ");
		sql.append("       AND A.BUNHO       = :f_bunho                                                                                                                                                 ");
		sql.append("       AND B.HOSP_CODE   = A.HOSP_CODE                                                                                                                                              ");
		sql.append("       AND B.BUNHO       = A.BUNHO                                                                                                                                                  ");
		sql.append("       AND B.PKINP1001   = A.FKINP1001                                                                                                                                              ");
		sql.append("       AND C.HOSP_CODE   = A.HOSP_CODE                                                                                                                                              ");
		sql.append("       AND C.BUNHO       = A.BUNHO                                                                                                                                                  ");
		sql.append("       AND D.HOSP_CODE   = A.HOSP_CODE                                                                                                                                              ");
		sql.append("       AND D.BUNHO       = A.BUNHO                                                                                                                                                  ");
		sql.append("       AND D.FKINP1001   = A.FKINP1001                                                                                                                                              ");
		sql.append("       AND E.GUBUN       = D.GUBUN   AND E.LANGUAGE = :f_language                                                                                                                   ");
		sql.append("       AND B.IPWON_DATE BETWEEN E.START_DATE                                                                                                                                        ");
		sql.append("                         AND IFNULL(E.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                                                                                                  ");
		sql.append("   ORDER BY A.ACTING_DATE DESC																																						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_send_yn", sendYn);
		query.setParameter("f_bunho", bunho);
		List<ORDERTRANSGrdListInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdListInfo.class);
		return list;
	}
}

