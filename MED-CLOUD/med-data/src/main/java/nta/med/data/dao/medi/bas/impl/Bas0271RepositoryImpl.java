package nta.med.data.dao.medi.bas.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0271RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0270GrdBAS0271Info;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Bas0271RepositoryImpl implements Bas0271RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Bas0271RepositoryImpl.class);

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<BAS0270GrdBAS0271Info > getBAS0270GrdBAS0271Info (String hospCode, String language, String doctorYmd, String doctorName) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.DOCTOR,                                                                              ");
		sql.append(" A.DOCTOR_NAME,                                                                               ");
		sql.append(" A.DOCTOR_GRADE,                                                                              ");
		sql.append(" FN_BAS_LOAD_CODE_NAME('DOCTOR_GRADE',A.DOCTOR_GRADE, :hospCode, :language) DOCTOR_GRADE_NAME,");
		sql.append(" A.START_DATE ,                                                                               ");
		sql.append(" A.JUBSU_YN,                                                                                  ");
		sql.append(" A.RESER_YN,                                                                                  ");
		sql.append(" A.END_DATE,                                                                                  ");
		sql.append(" A.OCS_STATUS ,                                                                               ");
		sql.append(" A.LICENSE_BUNHO,                                                                             ");
		sql.append(" A.SABUN,                                                                                     ");
		sql.append(" A.DOCTOR_SIGN,                                                                               ");
		sql.append(" A.CP_DOCTOR_YN,                                                                              ");
		sql.append(" A.DOCTOR_NAME2,                                                                              ");
		sql.append(" A.MAYAK_LICENSE,                                                                             ");
		sql.append(" A.TONGGYE_DOCTOR,                                                                            ");
		sql.append(" A.COMMON_DOCTOR_YN,                                                                          ");
		sql.append(" '' BUTTON ,                                                                                  ");
		sql.append(" A.DOCTOR_COLOR                                                                               ");
		sql.append(" FROM BAS0271 A                                                                               ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                                                ");
		if(!StringUtils.isEmpty(doctorYmd)) {
			sql.append(" AND STR_TO_DATE(:doctorYmd, '%Y/%m/%d') BETWEEN STR_TO_DATE(DATE_FORMAT(A.START_DATE, '%Y/%m/%d'), '%Y/%m/%d') AND A.END_DATE                  ");
		}
		sql.append(" AND ( A.DOCTOR_NAME LIKE :doctor_name			                                              ");
		sql.append(" OR IFNULL(A.DOCTOR_NAME2, ' ') LIKE :doctor_name)		                                      ");
		sql.append(" ORDER BY A.DOCTOR, A.DOCTOR_GRADE                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(doctorYmd)) {
			query.setParameter("doctorYmd", doctorYmd);
		}
		query.setParameter("doctor_name", doctorName + "%");

		List<BAS0270GrdBAS0271Info> list = new JpaResultMapper().list(query, BAS0270GrdBAS0271Info.class);
		return list;
	}
}

