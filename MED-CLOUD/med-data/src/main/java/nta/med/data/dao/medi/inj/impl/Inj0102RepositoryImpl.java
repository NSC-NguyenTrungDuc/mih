package nta.med.data.dao.medi.inj.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inj.Inj0102RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.injs.INJ0101U00GrdDetailInfo;
import nta.med.data.model.ihis.injs.INJ0101U01GrdDetailItemInfo;

/**
 * @author dainguyen.
 */
public class Inj0102RepositoryImpl implements Inj0102RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<INJ0101U00GrdDetailInfo> getINJ0101U00GrdDetailInfo(String hospCode, String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT CODE_TYPE, CODE, CODE_NAME    ");
		sql.append("    FROM INJ0102                       ");
		sql.append("   WHERE HOSP_CODE = :f_hosp_code      ");
		sql.append("     AND CODE_TYPE = :f_code_type      ");
		sql.append("     AND LANGUAGE  = :f_language       ");
		sql.append("   ORDER BY CODE                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		List<INJ0101U00GrdDetailInfo> list = new JpaResultMapper().list(query, INJ0101U00GrdDetailInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getINJ1001U01MlayConstantInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME FROM INJ0102                              ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code AND CODE_TYPE = 'INJ_CONSTANT'    ");
		sql.append("     AND LANGUAGE  = :f_language       							  ");
		sql.append(" ORDER BY CODE													  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> getMLayConstant = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return getMLayConstant;
	}
	
	public List<INJ0101U01GrdDetailItemInfo> getInj0101U01GrdDetailListItemInfo (String hospCode, String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 						   ");
		sql.append("	CODE_TYPE                      ");
		sql.append("	,CODE                          ");
		sql.append("	,CODE_NAME                     ");
		sql.append("	,REMARK                        ");
		sql.append("	FROM INJ0102                   ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code ");
		sql.append("	AND CODE_TYPE = :f_code_type   ");
		sql.append("    AND LANGUAGE  = :f_language    ");
		sql.append("	ORDER BY CODE                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<INJ0101U01GrdDetailItemInfo> list = new JpaResultMapper().list(query, INJ0101U01GrdDetailItemInfo.class);
		return list;
	}
}

