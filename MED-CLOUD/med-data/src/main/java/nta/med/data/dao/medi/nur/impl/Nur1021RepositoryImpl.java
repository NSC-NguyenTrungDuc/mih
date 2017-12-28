package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur1021RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR1020U00laySiksaInfo;

/**
 * @author dainguyen.
 */
public class Nur1021RepositoryImpl implements Nur1021RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<NUR1020U00laySiksaInfo> getNUR1020U00laySiksaInfo(String hospCode, String bunho, Double fkinp1001,
			String ymd) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT SUM(CASE A.NUT_GUBN WHEN 'T1' THEN NUT_VALUE ELSE 0 END) T1 ");
		sql.append("	, SUM(CASE A.NUT_GUBN WHEN 'T2' THEN NUT_VALUE ELSE 0 END) T2      ");
		sql.append("	, SUM(CASE A.NUT_GUBN WHEN 'T3' THEN NUT_VALUE ELSE 0 END) T3      ");
		sql.append("	, SUM(CASE A.NUT_GUBN WHEN 'T4' THEN NUT_VALUE ELSE 0 END) T4      ");
		sql.append("	, SUM(CASE A.NUT_GUBN WHEN 'T1' THEN NUT_VALUE2 ELSE 0 END) T5     ");
		sql.append("	, SUM(CASE A.NUT_GUBN WHEN 'T2' THEN NUT_VALUE2 ELSE 0 END) T6     ");
		sql.append("	, SUM(CASE A.NUT_GUBN WHEN 'T3' THEN NUT_VALUE2 ELSE 0 END) T7     ");
		sql.append("	, SUM(CASE A.NUT_GUBN WHEN 'T4' THEN NUT_VALUE2 ELSE 0 END) T8     ");
		sql.append("	FROM NUR1021 A                                                     ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                                   ");
		sql.append("	AND A.BUNHO = :f_bunho                                             ");
		sql.append("	AND A.FKINP1001 = :f_fkinp1001                                     ");
		sql.append("	AND A.YMD = STR_TO_DATE(:f_ymd,'%Y/%m/%d')                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		query.setParameter("f_ymd", ymd);
		
		List<NUR1020U00laySiksaInfo> listData = new JpaResultMapper().list(query, NUR1020U00laySiksaInfo.class);
		return listData;
	}
}
