package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur5023RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR5020U00grdWoiInfo;

/**
 * @author dainguyen.
 */
public class Nur5023RepositoryImpl implements Nur5023RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<NUR5020U00grdWoiInfo> getNUR5020U00grdWoiInfoMode2(String hospCode, String language, String date, String hoDong, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT  CAST(PKNUR5023 AS CHAR)                                                                                             ");
		sql.append("         , NUR_WRDT                                                                                                            ");
		sql.append("         , HO_DONG                                                                                                             ");
		sql.append("         , DETAIL_GUBUN                                                                                                        ");
		sql.append("         , FN_NUR_LOAD_CODE_NAME('WOICHUL_WOPIBAK_GUBUN', DETAIL_GUBUN, HOSP_CODE, :f_language) GUBUN_NAME                     ");
		sql.append("         , BUNHO                                                                                                               ");
		sql.append("         , FN_OUT_LOAD_SUNAME(BUNHO, HOSP_CODE)    SUNAME                                                                      ");
		sql.append("         , HO_CODE                                                                                                             ");
		sql.append("         , DATE_FORMAT(DATE1, '%Y/%m/%d')                                                                                      ");
		sql.append("         , TIME1                                                                                                               ");
		sql.append("         , DATE_FORMAT(DATE2, '%Y/%m/%d')                                                                                      ");
		sql.append("         , TIME2                                                                                                               ");
		sql.append("         , BIGO                                                                                                                ");
		sql.append("         , FN_BAS_TO_JAPAN_DATE_CONVERT('1', DATE1) JAPAN_DATE1                                                                ");
		sql.append("         , FN_BAS_TO_JAPAN_DATE_CONVERT('1', DATE2) JAPAN_DATE2                                                                ");
		sql.append("         , '' DATA_ROW_STATE                                                                                                   ");
		sql.append("      FROM NUR5023                                                                                                             ");
		sql.append("     WHERE HOSP_CODE = :f_hosp_code                                                                                            ");
		sql.append("       AND HO_DONG   = :f_ho_dong                                                                                              ");
		sql.append("       AND NUR_WRDT  = STR_TO_DATE(:f_date, '%Y/%m/%d')                                                                        ");
		sql.append("       AND GUBUN     = '1'                                                                                                     ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset												  ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ho_dong", hoDong);
		query.setParameter("f_date", date);
		query.setParameter("f_language", language);

		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}
		
		List<NUR5020U00grdWoiInfo> listInfo = new JpaResultMapper().list(query, NUR5020U00grdWoiInfo.class);
		return listInfo;
		
	}
}

