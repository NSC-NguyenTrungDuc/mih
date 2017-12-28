package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0208RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0208Q01GrdOCS0208Info;
import nta.med.data.model.ihis.ocsa.OCS0208U00GrdOCS0208Info;
import nta.med.data.model.ihis.ocsa.OcsaOCS0208U00GrdOCS0208U00ListInfo;

/**
 * @author dainguyen.
 */
public class Ocs0208RepositoryImpl implements Ocs0208RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OcsaOCS0208U00GrdOCS0208U00ListInfo> getOcsaOCS0208U00GrdOCS0208U00List(String hospCode, String doctor, String bunryu1, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(A.DOCTOR      , ' ') DOCTOR                      ,              ");
		sql.append("       IFNULL(A.SEQ         , 0  ) SEQ                         ,              ");
		sql.append("       IFNULL(A.BOGYONG_CODE, ' ') BOGYONG_CODE                ,              ");
		sql.append("       FN_OCS_LOAD_BOGYONG_NAME(A.BOGYONG_CODE, :f_hosp_code) BOGYONG_NAME,   ");
		sql.append("       B.BUNRYU1                                                              ");
		sql.append("  FROM OCS0208 A,                                                             ");
		sql.append("       DRG0120 B                                                              ");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code                                         ");
		sql.append("   AND A.DOCTOR        = :f_doctor                                            ");
		sql.append("   AND :f_hosp_code     = B.HOSP_CODE                                          ");
		sql.append("   AND B.BOGYONG_CODE  = A.BOGYONG_CODE                                       ");
		sql.append("   AND B.BUNRYU1       = :f_bunryu1                                           ");
		sql.append("   AND B.LANGUAGE       = :f_language                                         ");
		sql.append(" ORDER BY 2                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_bunryu1", bunryu1);
		query.setParameter("f_language", language);
		
		List<OcsaOCS0208U00GrdOCS0208U00ListInfo> list = new JpaResultMapper().list(query, OcsaOCS0208U00GrdOCS0208U00ListInfo.class);
		return list;
	}
	
	@Override
	public List<String> getBogyongNameOcsaOCS0208U00CommonData(String hospCode, String doctor, String bogyongCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_LOAD_BOGYONG_NAME(A.BOGYONG_CODE, :f_hosp_code) BOGYONG_NAME  ");
		sql.append("   FROM OCS0208 A                                                           ");
		sql.append("  WHERE A.DOCTOR       = :f_doctor                                          ");
		sql.append("    AND A.BOGYONG_CODE = :f_code                                            ");
		sql.append("    AND A.HOSP_CODE    = :f_hosp_code                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_code", bogyongCode);
		
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public List<OCS0208U00GrdOCS0208Info> getOCS0208U00GrdOCS0208Info(String hospCode, String doctor, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '0'      GUBUN              ,                                                                                                                                                                                    ");
		sql.append("        A.BOGYONG_CODE              ,                                                                                                                                                                                    ");
		sql.append("        IFNULL(B.BANGHYANG, '11')      ,                                                                                                                                                                                 ");
		sql.append("        FN_OCS_LOAD_BOGYONG_NAME(A.BOGYONG_CODE,:f_hosp_code) BOGYONG_NAME,                                                                                                                                              ");
		sql.append("        IFNULL(B.DONBOG_YN, 'N')                    DONBOG_YN   ,                                                                                                                                                        ");
		sql.append("        B.BOGYONG_GUBUN,                                                                                                                                                                                                 ");
		sql.append("        A.SEQ,                                                                                                                                                                                                           ");
		sql.append("        'Y',                                                                                                                                                                                                             ");
		sql.append("        B.IO_GUBUN                                                                                                                                                                                                       ");
		sql.append("   FROM OCS0208 A,DRG0120 B                                                                                                                                                                                              ");
		sql.append("  WHERE A.HOSP_CODE                 = :f_hosp_code                                                                                                                                                                       ");
		sql.append("    AND (A.DOCTOR= :f_doctor OR A.DOCTOR IN (select USER_ID from ADM3200 where HOSP_CODE = :f_hosp_code and USER_GROUP='ADMIN'))                                                                                         ");
		sql.append("    AND :f_hosp_code                 = B.HOSP_CODE                                                                                                                                                                        ");
		sql.append("    AND B.BOGYONG_CODE              = A.BOGYONG_CODE                                                                                                                                                                     ");
		sql.append("    AND B.BUNRYU1                   = '1'  AND B.LANGUAGE = :f_language                                                                                                                                                 ");
		sql.append(" UNION                                                                                                                                                                                                                   ");
		sql.append(" SELECT '1'      GUBUN              ,                                                                                                                                                                                    ");
		sql.append("        A.BOGYONG_CODE              ,                                                                                                                                                                                    ");
		sql.append("        IFNULL(A.BANGHYANG, '11')      ,                                                                                                                                                                                 ");
		sql.append("        FN_OCS_LOAD_BOGYONG_NAME(A.BOGYONG_CODE,:f_hosp_code) BOGYONG_NAME,                                                                                                                                              ");
		sql.append("        IFNULL(A.DONBOG_YN, 'N')                    DONBOG_YN   ,                                                                                                                                                        ");
		sql.append("        A.BOGYONG_GUBUN,                                                                                                                                                                                                 ");
		sql.append("        A.SORY_KEY,                                                                                                                                                                                                      ");
		sql.append("        IFNULL(B.BOGYONG_CODE, 'N') USER_YN,                                                                                                                                                                             ");
		sql.append("        A.IO_GUBUN                                                                                                                                                                                                       ");
		sql.append("   FROM OCS0208 B RIGHT JOIN DRG0120 A ON  B.HOSP_CODE = :f_hosp_code  AND B.BOGYONG_CODE = A.BOGYONG_CODE AND A.LANGUAGE = :f_language 																				 ");
		sql.append("   AND (B.DOCTOR= :f_doctor OR B.DOCTOR In (select USER_ID from ADM3200 where HOSP_CODE = :f_hosp_code and USER_GROUP='ADMIN'))      	  	   																		     ");
		sql.append("  WHERE A.BUNRYU1         = '1'                                                                                                                                                                                          ");
		sql.append("    AND A.HOSP_CODE       = :f_hosp_code                                                                                                                                                                                 ");
		sql.append(" ORDER BY 1, 7, 2																														                                                                                 ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_language", language);
		List<OCS0208U00GrdOCS0208Info> list = new JpaResultMapper().list(query, OCS0208U00GrdOCS0208Info.class);
		return list;
	}

	@Override
	public List<OCS0208Q01GrdOCS0208Info> getOCS0208Q01GrdOCS0208Info(String hospCode, String doctor, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '0'      GUBUN                                       ,                      ");
		sql.append("        A.BOGYONG_CODE                                       ,                      ");
		sql.append("        FN_OCS_LOAD_BOGYONG_NAME(A.BOGYONG_CODE,:f_hosp_code) BOGYONG_NAME,         ");
		sql.append("        'Y',                                                                        ");
		sql.append("        B.BOGYONG_GUBUN,                                                            ");
		sql.append("        A.SEQ                                                                       ");
		sql.append("   FROM OCS0208 A,DRG0120 B                                                         ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                                             ");
		sql.append("    AND A.DOCTOR         = :f_doctor                                                ");
		sql.append("    AND B.BOGYONG_CODE   = A.BOGYONG_CODE                                           ");
		sql.append("    AND :f_hosp_code      = B.HOSP_CODE                                              ");
		sql.append("    AND B.BUNRYU1        = '6'    AND B.LANGUAGE = :f_language                     ");
		sql.append(" UNION                                                                              ");
		sql.append(" SELECT '1'      GUBUN                                       ,                      ");
		sql.append("        B.BOGYONG_CODE                                       ,                      ");
		sql.append("        FN_OCS_LOAD_BOGYONG_NAME(B.BOGYONG_CODE,:f_hosp_code) BOGYONG_NAME,         ");
		sql.append("        IFNULL(C.BOGYONG_CODE, 'N') USER_YN,                                        ");
		sql.append("        B.BOGYONG_GUBUN,                                                            ");
		sql.append("        B.SORY_KEY                                                                  ");
		sql.append("   FROM                                                                             ");
		sql.append("       OCS0208 C RIGHT JOIN DRG0120 B ON  C.HOSP_CODE = :f_hosp_code   AND B.LANGUAGE = :f_language               ");
		sql.append("       AND C.BOGYONG_CODE = B.BOGYONG_CODE  AND C.DOCTOR = :f_doctor                ");
		sql.append("  WHERE B.BUNRYU1         = '6'                                                     ");
		sql.append("    AND B.HOSP_CODE       = :f_hosp_code                                            ");
		sql.append(" ORDER BY 1, 6, 2																	");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_language", language);
		List<OCS0208Q01GrdOCS0208Info> list = new JpaResultMapper().list(query, OCS0208Q01GrdOCS0208Info.class);
		return list;
	}
}

