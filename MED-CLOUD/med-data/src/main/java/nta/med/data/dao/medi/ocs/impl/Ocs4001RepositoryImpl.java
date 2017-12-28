package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.domain.ocs.Ocs4001;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs4001RepositoryCustom;
import nta.med.data.model.ihis.ocso.OCS4001U00LeftGrdViewInfo;

public class Ocs4001RepositoryImpl implements Ocs4001RepositoryCustom{
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS4001U00LeftGrdViewInfo> getOcs4001LeftGrdView(String hospCode, String tplCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT  A.ID                                                                  		");
		sql.append("       ,A.CREATE_DATE                                                             	");
		sql.append("       ,A.INPUT_CONTENT                                                             ");
		sql.append("       ,A.FORM_NAME                                                             	");
		sql.append("       ,A.INPUT_VALUE                                                             	");
		sql.append("       ,A.FORMAT_TYPE                                                             	");
		sql.append("       ,A.PRINT_CONTENT                                                             ");
		sql.append("       ,A.FORM_CODE                                                             	");
		sql.append("  FROM OCS4001 A                                                                    ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                        							");
		sql.append("   AND A.TPL_CODE   = :f_tlp_code                                         			");
//		if (!StringUtils.isEmpty(bunho))
			sql.append("   AND A.BUNHO   = :f_bunho                                         			");
		sql.append("   AND A.ACTIVE_FLG   = 1                                         					");
		sql.append("   ORDER BY A.ID desc                                         						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_tlp_code", tplCode);
//		if (!StringUtils.isEmpty(bunho))
			query.setParameter("f_bunho", bunho);
		List<OCS4001U00LeftGrdViewInfo> ocs4001 = new JpaResultMapper().list(query, OCS4001U00LeftGrdViewInfo.class);
		return ocs4001;
	}

	@Override
	public Ocs4001 getOcs4001InputContent(String id) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.FORMAT_TYPE,                                                               ");
		sql.append("       A.FORM_CODE,                                                             	");
		sql.append("       A.FORM_NAME,                                                             	");
		sql.append("       A.INPUT_CONTENT,                                                             ");
		sql.append("       A.INPUT_VALUE,                                                             	");
		sql.append("       A.PRINT_CONTENT                                                              ");
		sql.append("  FROM OCS4001 A                                                                    ");
		sql.append(" WHERE A.ID = :f_id                        											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_id", CommonUtils.parseLong(id));
		List<Ocs4001> ocs4001 = new JpaResultMapper().list(query, Ocs4001.class);
		return CollectionUtils.isEmpty(ocs4001) ? null : ocs4001.get(0);
	}

}
