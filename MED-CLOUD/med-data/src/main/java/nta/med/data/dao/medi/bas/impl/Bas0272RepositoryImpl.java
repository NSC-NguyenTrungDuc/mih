package nta.med.data.dao.medi.bas.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0272RepositoryCustom;
import nta.med.data.model.ihis.bass.BAS0270GrdBAS0272Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.Date;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Bas0272RepositoryImpl implements Bas0272RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Bas0272RepositoryImpl.class);

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<BAS0270GrdBAS0272Info > getBAS0270GrdBAS0272Info (String hospCode, String language, Date doctorYmd, String doctor) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.DOCTOR,                                                                        ");
		sql.append("  A.DOCTOR_GWA,                                                                          ");
		sql.append("  FN_BAS_LOAD_GWA_NAME(A.DOCTOR_GWA, :doctor_ymd, :hospCode, :language), 				 ");
		sql.append("  A.MAIN_GWA_YN,                                                                         ");
		sql.append("  A.START_DATE ,                                                                         ");
		sql.append("  A.END_DATE ,                                                                           ");
		sql.append("  A.SABUN ,                                                                              ");
		sql.append("  IF(A.END_DATE <= SYSDATE(),'Y','N') END_YN                                             ");
		sql.append("  , A.OUT_DISCUSS_YN                                             						 ");
		sql.append("  , A.RESER_OUT_YN                                             							 ");
		sql.append("  FROM BAS0272 A                                                                         ");
		sql.append("  WHERE A.HOSP_CODE = :hospCode                                                          ");
		//if(!StringUtils.isEmpty(doctor)) {
			sql.append(" AND A.DOCTOR = :doctor                                                              ");
		//}
		sql.append(" ORDER BY A.DOCTOR_GWA, A.START_DATE DESC                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("doctor_ymd", doctorYmd);
		//if(!StringUtils.isEmpty(doctor)) {
			query.setParameter("doctor", doctor);
		//}

		List<BAS0270GrdBAS0272Info> list = new JpaResultMapper().list(query, BAS0270GrdBAS0272Info.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOFMakeGwaCombo(String hospCode,String language, String sabun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%', FN_ADM_MSG(4295, :f_language)                                                          ");
		sql.append("   UNION ALL                                                                                        ");
		sql.append("  SELECT A.DOCTOR_GWA, FN_BAS_LOAD_GWA_NAME(A.DOCTOR_GWA, SYSDATE(), :f_hosp_code, :f_language )    ");
		sql.append("    FROM BAS0272 A                                                                                  ");
		sql.append("   WHERE A.HOSP_CODE =:f_hosp_code                                                                  ");
		sql.append("     AND A.SABUN = :f_sabun                                                                         ");
		sql.append("     AND SYSDATE() BETWEEN A.START_DATE                                                             ");
		sql.append("                           AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))                ");
		sql.append("   ORDER BY 2, 1																					");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_sabun", sabun);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getComboDoctorGwa(String hospCode,String language, String memb) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%', FN_ADM_MSG(221, :f_language)                                                               ");
		sql.append("     UNION ALL                                                                                          ");
		sql.append("    SELECT A.DOCTOR_GWA, B.GWA_NAME                                                                     ");
		sql.append("      FROM BAS0272 A                                                                                    ");
		sql.append("         , BAS0260 B                                                                                    ");
		sql.append("     WHERE A.HOSP_CODE  = :f_hosp_code                                                                  ");
		sql.append("       AND A.SABUN      = :f_memb                                                                       ");
		sql.append("       AND B.LANGUAGE   = :f_language                                                                   ");
		sql.append("       AND B.HOSP_CODE  = A.HOSP_CODE                                                                   ");
		sql.append("       AND A.DOCTOR_GWA = B.GWA                                                                         ");
		sql.append("       AND SYSDATE() BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))     ");
		sql.append("       AND SYSDATE() BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))     ");
		sql.append("     ORDER BY 1																							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_memb", memb);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public Integer deleteBas0272Bas(String hospCode, String sabun, String doctorGwa, String startDate){
		    StringBuilder sql = new StringBuilder();	
			sql.append("  DELETE FROM BAS0272                           						"); 
			sql.append("  WHERE HOSP_CODE     = :f_hosp_code       								");
			sql.append("	   AND SABUN  	  = :f_sabun                  						"); 
		    sql.append("	   AND DATE_FORMAT(START_DATE, '%Y/%m/%d') = :f_start_date        	");
		    if (!StringUtils.isEmpty(doctorGwa)) {
		    	sql.append("	 AND DOCTOR_GWA  = :f_doctor_gwa      							"); 
			} else {
				sql.append("	 AND DOCTOR_GWA  IS NULL      									");
			}
		    
		    Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_sabun", sabun);
			query.setParameter("f_start_date", startDate);
			if (!StringUtils.isEmpty(doctorGwa)) {
				query.setParameter("f_doctor_gwa", doctorGwa);
			}
			return query.executeUpdate();
		}
	
}

