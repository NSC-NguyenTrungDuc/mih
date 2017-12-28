package nta.med.data.dao.medi.xrt.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.xrt.Xrt0101RepositoryCustom;
import nta.med.data.model.ihis.xrts.XRT0101U00GrdMcodeInfo;

/**
 * @author dainguyen.
 */
public class Xrt0101RepositoryImpl implements Xrt0101RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<XRT0101U00GrdMcodeInfo> getXRT0101U00GrdMCodeListItemInfo(String hospCode, String codeType, String language) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT IFNULL(CODE_TYPE     , ' ')  CODE_TYPE, IFNULL(CODE_TYPE_NAME, ' ')  CODE_TYPE_NAME FROM XRT0101    ");
		sql.append("  WHERE CODE_TYPE LIKE :f_code_type                                            ");
		sql.append("  AND ADMIN_GUBUN = 'USER' AND LANGUAGE = :f_language ORDER BY 1																		");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%"+codeType+"%");
		query.setParameter("f_language", language);
		List<XRT0101U00GrdMcodeInfo> listGrdMCode= new JpaResultMapper().list(query, XRT0101U00GrdMcodeInfo.class);
		return listGrdMCode;
	}
}

