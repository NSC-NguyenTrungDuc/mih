package nta.med.data.dao.medi.ifs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ifs.Ifs0005RepositoryCustom;
import nta.med.data.model.ihis.bass.IFS0004U01grdDetailtListItemInfo;

/**
 * @author dainguyen.
 */
public class Ifs0005RepositoryImpl implements Ifs0005RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<IFS0004U01grdDetailtListItemInfo> getIfs0004U01grdDetailtListItem(
			String hospCode, String language, String curYmd, String nuGubun,
			String nuCode, String nuYmd) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT   A.NU_GUBUN																						");
		sql.append("	       , A.NU_CODE                                                                                      ");
		sql.append("	       , A.NU_YMD                                                                                       ");
		sql.append("	       , A.BUN_CODE                                                                                     ");
		sql.append("	       , IFNULL(AB.BUN_NAME, FN_ADM_MSG('221',:language))    AS BUN_NAME                                ");
		sql.append("	       , A.SG_CODE                                                                                      ");
		sql.append("	       , IFNULL(AC.SG_NAME, FN_ADM_MSG('221',:language))     AS SG_NAME                                 ");
		sql.append("	  FROM (SELECT A.*                                                                                      ");
		sql.append("	          FROM BAS0230  A                                                                               ");
		sql.append("	         WHERE A.HOSP_CODE        = :f_hosp_code AND A.LANGUAGE = :language                             ");
		sql.append("	           AND A.BUN_YMD        = (SELECT MAX(Z.BUN_YMD)                                                ");
		sql.append("	                                     FROM BAS0230     Z                                                 ");
		sql.append("	                                    WHERE Z.HOSP_CODE       = A.HOSP_CODE  AND Z.LANGUAGE = A.LANGUAGE  ");
		sql.append("	                                      AND Z.BUN_CODE        = A.BUN_CODE                                ");
		sql.append("	                                      AND Z.BUN_YMD         <= STR_TO_DATE(:f_cur_ymd, '%Y/%m/%d'))     ");
		sql.append("	       ) AB RIGHT JOIN IFS0005 A ON AB.BUN_CODE = A.BUN_CODE                                            ");
		sql.append("	     LEFT JOIN (SELECT A.*                                                                              ");
		sql.append("	          FROM BAS0310  A                                                                               ");
		sql.append("	         WHERE A.HOSP_CODE        = :f_hosp_code                                                        ");
		sql.append("	           AND A.SG_YMD         = (SELECT MAX(Z.SG_YMD)                                                 ");
		sql.append("	                                     FROM BAS0310     Z                                                 ");
		sql.append("	                                    WHERE Z.HOSP_CODE       = A.HOSP_CODE                               ");
		sql.append("	                                      AND Z.SG_CODE         = A.SG_CODE                                 ");
		sql.append("	                                      AND Z.SG_YMD          <= STR_TO_DATE(:f_cur_ymd, '%Y/%m/%d')      ");
		sql.append("	                                      AND (   Z.BULYONG_YMD IS NULL                                     ");
		sql.append("	                                           OR Z.BULYONG_YMD >= STR_TO_DATE(:f_cur_ymd, '%Y/%m/%d')      ");
		sql.append("	                                          ))                                                            ");
		sql.append("	       ) AC  ON AC.SG_CODE = A.SG_CODE                                                                  ");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code                                                                      ");
		sql.append("	   AND A.NU_GUBUN   = :f_nu_gubun                                                                       ");
		sql.append("	   AND A.NU_CODE    = :f_nu_code                                                                        ");
		sql.append("	   AND A.NU_YMD     = STR_TO_DATE(:f_nu_ymd, '%Y/%m/%d')                                                ");
		sql.append("	 ORDER BY A.HOSP_CODE, A.NU_GUBUN, A.NU_CODE, A.BUN_CODE, A.SG_CODE                                     ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_cur_ymd", curYmd);
		query.setParameter("f_nu_gubun", nuGubun);
		query.setParameter("f_nu_code", nuCode);
		query.setParameter("f_nu_ymd", nuYmd);
		
		List<IFS0004U01grdDetailtListItemInfo> list = new JpaResultMapper().list(query, IFS0004U01grdDetailtListItemInfo.class);
		return list;
	}
}

