package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur5024RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR5020U00grdWatchListInfo;

/**
 * @author dainguyen.
 */
public class Nur5024RepositoryImpl implements Nur5024RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR5020U00grdWatchListInfo> getNUR5020U00grdWatchListInfo(String hospCode, String language, String date, String hoDong, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.NUR_WRDT                                                                       ");
		sql.append("        , A.DETAIL_GUBUN                                                                   ");
		sql.append("        , FN_NUR_LOAD_CODE_NAME('WATCHLIST', A.DETAIL_GUBUN, A.HOSP_CODE, :f_language)     ");
		sql.append("        , A.GWA                                                                            ");
		sql.append("        , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NUR_WRDT, A.HOSP_CODE, :f_language)                ");
		sql.append("        , A.HO_DONG                                                                        ");
		sql.append("        , A.HO_CODE                                                                        ");
		sql.append("        , A.BUNHO                                                                          ");
		sql.append("        , FN_OUT_LOAD_SUNAME(A.BUNHO, A.HOSP_CODE)                                         ");
		sql.append("        , CAST(FN_OCS_LOAD_AGE(A.HOSP_CODE, A.BUNHO, SYSDATE()) AS CHAR)                   ");
		sql.append("        , B.SEX                                                                            ");
		sql.append("        , A.SANG                                                                           ");
		sql.append("        , A.COMMENT1                                                                       ");
		sql.append("        , A.COMMENT2                                                                       ");
		sql.append("        , A.COMMENT3                                                                       ");
		sql.append("        , '' DATA_ROW_STATE                                                                ");
		sql.append("     FROM NUR5024 A                                                                        ");
		sql.append("     JOIN OUT0101 B                                                                        ");
		sql.append("       ON B.HOSP_CODE = A.HOSP_CODE                                                        ");
		sql.append("      AND B.BUNHO     = A.BUNHO                                                            ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                       ");
		sql.append("      AND A.GUBUN     = '2'                                                                ");
		sql.append("      AND A.NUR_WRDT  = STR_TO_DATE(:f_date, '%Y/%m/%d')                                   ");
		sql.append("      AND A.HO_DONG   = :f_ho_dong                                                         ");
		sql.append("    ORDER BY HO_CODE, BUNHO                                                                ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset															   ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date);
		query.setParameter("f_language", language);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		List<NUR5020U00grdWatchListInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdWatchListInfo.class);
		return listInfo;
	}
}

