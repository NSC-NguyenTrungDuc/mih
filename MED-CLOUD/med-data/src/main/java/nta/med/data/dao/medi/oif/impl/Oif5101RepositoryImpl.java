package nta.med.data.dao.medi.oif.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.oif.Oif5101RepositoryCustom;
import nta.med.data.model.ihis.orca.ORCALibGetClaimDiagnosisInfo;

/**
 * @author dainguyen.
 */
public class Oif5101RepositoryImpl implements Oif5101RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORCALibGetClaimDiagnosisInfo> getORCALibGetClaimDiagnosisInfo(String hospCode, Double fkoif1101) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(A.UPD_DATE, '%Y/%m/%d') UPD_DATE,       ");
		sql.append("        A.PKOIF5101,                                        ");
		sql.append("        A.LICENSE,                                          ");
		sql.append("        A.GWA,                                              ");
		sql.append("        A.GWA_NAME,                                         ");
		sql.append("        A.CATEGORI_TD,                                      ");
		sql.append("        A.CATEGORI_NAME,                                    ");
		sql.append("        A.CODE,                                             ");
		sql.append("        A.SYSTEM,                                           ");
		sql.append("        A.CODE_NAME,                                        ");
		sql.append("        DATE_FORMAT(A.START_DATE,'%Y/%m/%d') START_DATE,    ");
		sql.append("        DATE_FORMAT(A.END_DATE,'%Y/%m/%d')  END_DATE,       ");
		sql.append("        A.OUT_COME    , UUID()  DOC_ID                      ");
		sql.append(" FROM OIF5101 A                                             ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                           ");
		sql.append("   AND A.FKOIF1101 = :f_fkoif1101                           ");
		sql.append(" ORDER BY A.PKOIF5101										");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkoif1101", fkoif1101);
		
		List<ORCALibGetClaimDiagnosisInfo> list = new JpaResultMapper().list(query, ORCALibGetClaimDiagnosisInfo.class);
		return list;
	}
}

