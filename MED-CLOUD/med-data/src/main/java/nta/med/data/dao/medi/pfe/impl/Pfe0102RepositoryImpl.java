package nta.med.data.dao.medi.pfe.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.pfe.Pfe0102RepositoryCustom;
import nta.med.data.model.ihis.endo.END1001U02GrdPurposeInfo;
import nta.med.data.model.ihis.pfes.PFE0101U00GrdDCodeInfo;
import nta.med.data.model.ihis.system.LayConstantInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Pfe0102RepositoryImpl implements Pfe0102RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Pfe0102RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<PFE0101U00GrdDCodeInfo> getPFE0101U00GrdDCodeInfo(String hospCode, String codeType, String code, String codeName, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE_TYPE , CODE , CODE_NAME    ");
		sql.append("      , CODE_NAME_RE, CODE_VALUE        ");
		sql.append("   FROM PFE0102                         ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code        ");
		sql.append("    AND CODE_TYPE = :f_code_type        ");
		sql.append("    AND CODE      LIKE :f_code          ");
		sql.append("    AND CODE_NAME LIKE :f_code_name     ");
		sql.append("    AND LANGUAGE = :f_language     		");
		sql.append("  ORDER BY CODE							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", "%" + code + "%");
		query.setParameter("f_code_name", "%" + codeName + "%");
		query.setParameter("f_language", language);
		List<PFE0101U00GrdDCodeInfo> list = new JpaResultMapper().list(query, PFE0101U00GrdDCodeInfo.class);
		return list;
	}

	@Override
	public List<LayConstantInfo> getOCSACTLayconstant(String hospCode,String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME, CODE_VALUE FROM PFE0102                             ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code AND CODE_TYPE = :f_code_type AND LANGUAGE = :f_language  ORDER BY CODE ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		List<LayConstantInfo> list = new JpaResultMapper().list(query, LayConstantInfo.class);
		return list;
	}

	@Override
	public List<END1001U02GrdPurposeInfo> getEND1001U02GrdPurposeInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'N'                                                                                            ");
		sql.append("     , A.CODE_NAME                                                                                     ");
		sql.append("  FROM PFE0102 A                                                                                       ");
		sql.append(" WHERE A.CODE_TYPE       = 'ENDO_PURPOSE'                                                              ");
		sql.append("   AND A.HOSP_CODE       = :f_hosp_code                                                                ");
		sql.append("   AND A.LANGUAGE       = :f_language                                                                  ");
		sql.append(" ORDER BY case FN_CPL_NUM_CHK(A.CODE_NAME_RE) WHEN 0 THEN CAST(A.CODE_NAME_RE AS SIGNED) ELSE 999 END  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<END1001U02GrdPurposeInfo> list = new JpaResultMapper().list(query, END1001U02GrdPurposeInfo.class);
		return list;
	}
}

