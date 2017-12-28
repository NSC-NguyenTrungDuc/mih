package nta.med.data.dao.medi.doc.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.doc.Doc4003RepositoryCustom;
import nta.med.data.model.ihis.ocsa.DOC4003U00GrdDOC4003Info;

/**
 * @author dainguyen.
 */
public class Doc4003RepositoryImpl implements Doc4003RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	public List<DOC4003U00GrdDOC4003Info> getDOC4003U00GrdDOC4003Info(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SYS_DATE                                                           ");
		sql.append("     , A.SYS_ID                                                             ");
		sql.append("     , A.UPD_DATE                                                           ");
		sql.append("     , A.UPD_ID                                                             ");
		sql.append("     , A.HOSP_CODE                                                          ");
		sql.append("     , A.PKDOC4003                                                          ");
		sql.append("     , A.SEQ                                                                ");
		sql.append("     , DATE_FORMAT(A.CREATE_DATE, '%Y/%m/%d') CREATE_DATE                   ");
		sql.append("     , A.TO_HOSPITAL_INFO                                                   ");
		sql.append("     , A.TO_SINRYOUKA                                                       ");
		sql.append("     , A.TO_SINRYOUKA2                                                      ");
		sql.append("     , A.TO_DOCTOR                                                          ");
		sql.append("     , A.TO_DOCTOR2                                                         ");
		sql.append("     , A.DOCTOR                                                             ");
		sql.append("     , A.GWA                                                                ");
		sql.append("     , A.SUNAME                                                             ");
		sql.append("     , A.SEX                                                                ");
		sql.append("     , A.ZIP                                                                ");
		sql.append("     , A.ADDRESS                                                            ");
		sql.append("     , A.TEL                                                                ");
		sql.append("     , DATE_FORMAT(A.BIRTH, '%Y/%m/%d') BIRTH                               ");
		sql.append("     , A.JOB                                                                ");
		sql.append("     , A.DISEASE                                                            ");
		sql.append("     , A.CHECKUP_OPINION                                                    ");
		sql.append("     , A.PRESCRIPTION                                                       ");
		sql.append("     , A.BUNHO                                                              ");
		sql.append("     , CONCAT(SUBSTR(B.ZIP_CODE, 1, 3), '-', SUBSTR(B.ZIP_CODE, 4)) ZIP_CODE");
		sql.append("     , B.ADDRESS AS BADDRESS                                                ");
		sql.append("     , CONCAT('TEL:', IFNULL(B.TEL,''),' FAX:', IFNULL(B.FAX,''))           ");
		sql.append("     , B.YOYANG_NAME                                                        ");
		sql.append("  FROM DOC4003 A                                                            ");
		sql.append("     , BAS0001 B                                                            ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                           ");
		sql.append("   AND A.BUNHO     = :f_bunho                                               ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                            ");
		sql.append("   AND A.CREATE_DATE BETWEEN B.START_DATE                                   ");
		sql.append("                         AND B.END_DATE                                     ");
		sql.append(" ORDER BY A.SEQ DESC;                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<DOC4003U00GrdDOC4003Info> list = new JpaResultMapper().list(query, DOC4003U00GrdDOC4003Info.class);
		return list;
	}
	
	
}

