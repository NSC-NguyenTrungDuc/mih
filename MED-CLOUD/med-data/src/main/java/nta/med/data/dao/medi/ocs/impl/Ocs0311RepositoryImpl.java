package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;


import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0311RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0311Q00LayRootListInfo;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdHangmogCodeListInfo;

/**
 * @author dainguyen.
 */
public class Ocs0311RepositoryImpl implements Ocs0311RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS0311U00grdHangmogCodeListInfo> getOCS0311U00grdHangmogCodeListInfo(String hospCode, String language, String setPart) {
		StringBuilder sql= new StringBuilder();
		sql.append(" ( SELECT A.SET_PART, A.HANGMOG_CODE                                                                                                                                ");
		sql.append("      , case A.HANGMOG_CODE                                                                                                                                         ");
		sql.append("      when 'PART_ALL' then CONCAT(IFNULL(FN_OCS_LOAD_CODE_NAME('SET_PART',A.SET_PART,:f_hosp_code,:f_language),''),IFNULL(FN_ADM_MSG(4111,:f_language),''))         ");
		sql.append("      else B.HANGMOG_NAME end                                                                                                                                       ");
		sql.append("   FROM OCS0103 B RIGHT JOIN OCS0311 A ON B.HOSP_CODE = A.HOSP_CODE AND B.HANGMOG_CODE = A.HANGMOG_CODE                                                             ");
		sql.append("  WHERE A.HOSP_CODE       = :f_hosp_code AND A.SET_PART        = :f_set_part )                                                                                      ");
		sql.append("  UNION ALL                                                                                                                                                         ");
		sql.append(" ( SELECT :f_set_part , 'PART_ALL'                                                                                                                                  ");
		sql.append("      , CONCAT(IFNULL(FN_OCS_LOAD_CODE_NAME('SET_PART',:f_set_part,:f_hosp_code,:f_language),''),IFNULL(FN_ADM_MSG(4111,:f_language),''))                           ");
		sql.append("   FROM DUAL                                                                                                                                                        ");
		sql.append("  WHERE NOT EXISTS ( SELECT 'X' FROM OCS0311 Z WHERE Z.HOSP_CODE = :f_hosp_code AND Z.SET_PART = :f_set_part AND Z.HANGMOG_CODE = 'PART_ALL' ))                     ");
		sql.append(" ORDER BY 2																																							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_set_part", setPart);
		List<OCS0311U00grdHangmogCodeListInfo> listGrdHangmogCode= new JpaResultMapper().list(query, OCS0311U00grdHangmogCodeListInfo.class);
		return listGrdHangmogCode;
	}

	@Override
	public List<OCS0311Q00LayRootListInfo> getOCS0311Q00LayRootListInfo(
			String hospCode, String language, String setPart, String hangmogCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.SET_PART                                                                                                                              ");
		sql.append("      , A.HANGMOG_CODE                                                                                                                          ");
		sql.append("      ,case A.HANGMOG_CODE when 'PART_ALL'                                                                                                      ");
		sql.append("      then CONCAT(IFNULL(FN_OCS_LOAD_CODE_NAME('SET_PART',A.SET_PART,:f_hosp_code,:f_language),''),IFNULL(FN_ADM_MSG(4111,:f_language),''))     ");
		sql.append("      else B.HANGMOG_NAME end                                                                                                                   ");
		sql.append("   FROM OCS0103 B RIGHT JOIN OCS0311 A ON B.HOSP_CODE  = A.HOSP_CODE AND B.HANGMOG_CODE = A.HANGMOG_CODE                                        ");
		sql.append("  WHERE A.HOSP_CODE       = :f_hosp_code                                                                                                        ");
		sql.append("    AND A.SET_PART        = :f_set_part                                                                                                         ");
		sql.append("    AND A.HANGMOG_CODE    LIKE :f_hangmog_code                                                                                                  ");
		sql.append("  UNION                                                                                                                                         ");
		sql.append(" SELECT A.SET_PART                                                                                                                              ");
		sql.append("      , A.HANGMOG_CODE                                                                                                                          ");
		sql.append("      ,case A.HANGMOG_CODE when 'PART_ALL'                                                                                                      ");
		sql.append("      then CONCAT(IFNULL(FN_OCS_LOAD_CODE_NAME('SET_PART',A.SET_PART,:f_hosp_code,:f_language),''),IFNULL(FN_ADM_MSG(4111,:f_language),''))     ");
		sql.append("      else B.HANGMOG_NAME end                                                                                                                   ");
		sql.append("   FROM OCS0103 B RIGHT JOIN  OCS0311 A ON B.HOSP_CODE = A.HOSP_CODE AND B.HANGMOG_CODE = A.HANGMOG_CODE                                        ");
		sql.append("  WHERE A.HOSP_CODE       = :f_hosp_code                                                                                                        ");
		sql.append("    AND A.SET_PART        = :f_set_part                                                                                                         ");
		sql.append("    AND A.HANGMOG_CODE    = 'PART_ALL'                                                                                                          ");
		sql.append(" ORDER BY 2																																		");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_set_part", setPart);
		query.setParameter("f_hangmog_code", hangmogCode+"%");
		List<OCS0311Q00LayRootListInfo> list= new JpaResultMapper().list(query, OCS0311Q00LayRootListInfo.class);
		return list;
	}
}

