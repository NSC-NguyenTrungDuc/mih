package nta.med.data.dao.medi.bas.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0203RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0203U00GrdBAS0203Info;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.Date;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Bas0203RepositoryImpl implements Bas0203RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Bas0102RepositoryImpl.class);

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public String getBAS0203U00LayDupCheckRequest(String hospCode,
			String symyaGubun, String bunCode, String sgCode, Date jyDate,
			String fromTime) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y'                           ");
		sql.append("  FROM BAS0203                        ");
		sql.append(" WHERE HOSP_CODE   = :f_hosp_code     ");
		sql.append("   AND SYMYA_GUBUN = :f_symya_gubun   ");
		sql.append("   AND BUN_CODE    = :f_bun_code      ");
		sql.append("   AND SG_CODE     = :f_sg_code       ");
		sql.append("   AND JY_DATE     = :f_jy_date       ");
		sql.append("   AND FROM_TIME   = :f_from_time     ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_symya_gubun", symyaGubun);
		query.setParameter("f_bun_code", bunCode);
		query.setParameter("f_sg_code", sgCode);
		query.setParameter("f_jy_date", jyDate);
		query.setParameter("f_from_time", fromTime);
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<BAS0203U00GrdBAS0203Info> getBAS0203U00GrdBAS0203Info(
			String hospCode, String language, Date jyDate, String symyaGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JY_DATE                                                                                   ");
		sql.append("      , A.SYMYA_GUBUN                                                                               ");
		sql.append("      , B.CODE_NAME     SYMYA_GUBUN_NAME                                                            ");
		sql.append("      , A.BUN_CODE                                                                                  ");
		sql.append("      , FN_BAS_LOAD_BAS0230(:f_hosp_code, :f_language, A.BUN_CODE)                                  ");
		sql.append("      , A.SG_CODE                                                                                   ");
		sql.append("      ,case FN_BAS_LOAD_SG_NAME(:f_hosp_code, A.SG_CODE, A.JY_DATE) when NULL then 'All' end        ");
		sql.append("      , A.FROM_TIME                                                                                 ");
		sql.append("      , A.TO_TIME                                                                                   ");
		sql.append("      , A.YOIL_GUBUN                                                                                ");
		sql.append("      , A.FROM_MONTH                                                                                ");
		sql.append("      , A.TO_MONTH                                                                                  ");
		sql.append("      , A.JY_DATE          OLD_JY_DATE                                                              ");
		sql.append("      , A.SYMYA_GUBUN      OLD_SYMYA_GUBUN                                                          ");
		sql.append("      , A.BUN_CODE         OLD_BUN_CODE                                                             ");
		sql.append("      , A.SG_CODE          OLD_SG_CODE                                                              ");
		sql.append("      , A.FROM_TIME        OLD_FROM_TIME                                                            ");
		sql.append("      , A.TO_TIME          OLD_TO_TIME                                                              ");
		sql.append("      , A.YOIL_GUBUN       OLD_YOIL_GUBUN                                                           ");
		sql.append("      , A.FROM_MONTH       OLD_FROM_MONTH                                                           ");
		sql.append("      , A.TO_MONTH         OLD_TO_MONTH                                                             ");
		sql.append("      , CONCAT( DATE_FORMAT(A.JY_DATE, '%Y/%m/%d') , A.SYMYA_GUBUN                                  ");
		sql.append("        , A.BUN_CODE , A.SG_CODE , A.YOIL_GUBUN , LPAD(A.FROM_MONTH,10,'0')                         ");
		sql.append("        , LPAD(A.TO_MONTH,10,'0') , A.FROM_TIME , IFNULL(A.TO_TIME,'') )  CONT_KEY                  ");
		sql.append("   FROM BAS0102 B                                                                                   ");
		sql.append("      , BAS0203 A                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                  ");
		sql.append("    AND B.LANGUAGE  = :f_language                                                                   ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                   ");
		sql.append("    AND A.JY_DATE  = ( SELECT MAX(Z.JY_DATE)                                                        ");
		sql.append("                         FROM BAS0203 Z                                                             ");
		sql.append("                        WHERE Z.HOSP_CODE   = A.HOSP_CODE                                           ");
		sql.append("                          AND Z.SYMYA_GUBUN = A.SYMYA_GUBUN                                         ");
		sql.append("                          AND Z.BUN_CODE    = A.BUN_CODE                                            ");
		sql.append("                          AND Z.SG_CODE     = A.SG_CODE                                             ");
		sql.append("                          AND Z.FROM_MONTH  = A.FROM_MONTH                                          ");
		sql.append("                          AND Z.FROM_TIME   = A.FROM_TIME                                           ");
		sql.append("                          AND Z.JY_DATE    <= :f_jy_date )                                          ");
		sql.append("    AND A.SYMYA_GUBUN  LIKE  :f_symya_gubun                                                         ");
		sql.append("    AND B.CODE_TYPE = 'SYMYA_GUBUN'                                                                 ");
		sql.append("    AND B.CODE      = A.SYMYA_GUBUN                                                                 ");
		sql.append("  ORDER BY 22																						");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jy_date", jyDate);
		query.setParameter("f_symya_gubun", "%" + symyaGubun + "%");
		List<BAS0203U00GrdBAS0203Info> list = new JpaResultMapper().list(query, BAS0203U00GrdBAS0203Info.class);
		return list;
	}

}

