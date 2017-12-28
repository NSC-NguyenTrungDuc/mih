package nta.med.data.dao.medi.cpl.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl0891RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL3020U02RESULTMAPGrdIDListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02RESULTMAPGrdResultListItemInfo;
import nta.med.data.model.ihis.cpls.Cpl3020U02ResultMapGrdIdInfo;
import nta.med.data.model.ihis.cpls.Cpl3020U02ResultMapGrdRsltInfo;

/**
 * @author dainguyen.
 */
public class Cpl0891RepositoryImpl implements Cpl0891RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	public List<CPL3020U02RESULTMAPGrdIDListItemInfo> getCPL3020U02RESULTMAPGrdIDListItemInfo(String hospCode, String jangbiCode, String specimenSer,
			String fromDate, String toDate, String allYn){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                                                                           ");
		sql.append("       A.RESULT_DATE  RESULT_DATE                                                                         ");
		sql.append("     , A.PROC_TIME    PROC_TIME                                                                           ");
		sql.append("     , A.SAMPLE_ID    SAMPLE_ID                                                                           ");
		sql.append("     , A.SPECIMEN_SER SPECIMEN_SER                                                                        ");
		sql.append("     , A.PATIENT_ID   PATIENT_ID                                                                          ");
		sql.append("  FROM (SELECT X.*                                                                                        ");
		sql.append("          FROM CPL0891 X                                                                                  ");
		sql.append("         WHERE X.HOSP_CODE   = :f_hosp_code                                                               ");
		sql.append("           AND X.RESULT_CODE IN (SELECT DISTINCT Y.JANGBI_OUT_CODE                                        ");
		sql.append("                                   FROM CPL0101 Y                                                         ");
		sql.append("                                  WHERE Y.HOSP_CODE   = :f_hosp_code                                      ");
		sql.append("                                    AND Y.JANGBI_CODE = :f_jangbi_code                                    ");
		sql.append("                                    AND Y.HANGMOG_CODE IN (SELECT A.HANGMOG_CODE                          ");
		sql.append("                                                            FROM CPL3020 A                                ");
		sql.append("                                                           WHERE A.HOSP_CODE    = :f_hosp_code            ");
		sql.append("                                                             AND A.JANGBI_CODE  = :f_jangbi_code          ");
		sql.append("                                                             AND A.SPECIMEN_SER = :f_specimen_ser))       ");
		sql.append("       ) A                                                                                                ");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                                                                       ");
		sql.append("   AND A.JANGBI_CODE = :f_jangbi_code                                                                     ");
		sql.append("   AND A.RESULT_DATE BETWEEN STR_TO_DATE(:f_from_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_date,'%Y/%m/%d')  ");
		sql.append("   AND (                                                                                                  ");
		sql.append("         (:f_all_yn = 'Y')                                                                                ");
		sql.append("         OR                                                                                               ");
		sql.append("         (:f_all_yn = 'N' AND A.SPECIMEN_SER IS NULL)                                                     ");
		sql.append("       )                                                                                                  ");
		sql.append(" ORDER BY A.RESULT_DATE DESC, A.SAMPLE_ID                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_jangbi_code", jangbiCode);
		query.setParameter("f_specimen_ser", specimenSer);
		query.setParameter("f_all_yn", allYn);
		List<CPL3020U02RESULTMAPGrdIDListItemInfo> list = new JpaResultMapper().list(query, CPL3020U02RESULTMAPGrdIDListItemInfo.class);
		return list;
	}
	
	@Override
	public List<CPL3020U02RESULTMAPGrdResultListItemInfo> getCPL3020U02RESULTMAPGrdResultListItemInfo(String hospCode, String jangbiCode,
			String resultDate, String sampleId){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.RESULT_CODE                    RESULT_CODE                 ");  
		sql.append("     , B.HANGMOG_CODE                   HANGMOG_CODE                ");
		sql.append("     , B.GUMSA_NAME                     GUMSA_NAME                  ");
		sql.append("     , TRIM('0' FROM A.RESULT_VAL)      RESULT_VAL                  ");
		sql.append("  FROM CPL0101 B                                                    ");
		sql.append("     , CPL0891 A                                                    ");
		sql.append(" WHERE A.HOSP_CODE       = :f_hosp_code                             ");
		sql.append("   AND A.JANGBI_CODE     = :f_jangbi_code                           ");
		sql.append("   AND A.RESULT_DATE     = STR_TO_DATE(:f_result_date,'%Y/%m/%d')   ");
		sql.append("   AND A.SAMPLE_ID       = :f_sample_id                             ");
		sql.append("   AND B.HOSP_CODE       = A.HOSP_CODE                              ");
		sql.append("   AND B.JANGBI_CODE     = A.JANGBI_CODE                            ");
		sql.append("   AND B.JANGBI_OUT_CODE = A.RESULT_CODE                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jangbi_code", jangbiCode);
		query.setParameter("f_result_date", resultDate);
		query.setParameter("f_sample_id", sampleId);
		List<CPL3020U02RESULTMAPGrdResultListItemInfo> list = new JpaResultMapper().list(query, CPL3020U02RESULTMAPGrdResultListItemInfo.class);
		return list;
	}

	@Override
	public List<Cpl3020U02ResultMapGrdIdInfo> getCpl3020U02ResultMapGrdIdInfo(
			String hospCode, String jangbiCode, String specimentSer,
			Date fromDate, Date toDate, String allYn) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT 																								");
		sql.append("	       A.RESULT_DATE  RESULT_DATE                                                                               ");
		sql.append("	     , A.PROC_TIME    PROC_TIME                                                                                 ");
		sql.append("	     , A.SAMPLE_ID    SAMPLE_ID                                                                                 ");
		sql.append("	     , A.SPECIMEN_SER SPECIMEN_SER                                                                              ");
		sql.append("	     , A.PATIENT_ID   PATIENT_ID                                                                                ");
		sql.append("	  FROM (SELECT X.*                                                                                              ");
		sql.append("	          FROM CPL0891 X                                                                                        ");
		sql.append("	         WHERE X.HOSP_CODE   = :f_hosp_code                                                                     ");
		sql.append("	           AND X.RESULT_CODE IN (SELECT DISTINCT Y.JANGBI_OUT_CODE                                              ");
		sql.append("	                                   FROM CPL0101 Y                                                               ");
		sql.append("	                                  WHERE Y.HOSP_CODE   = :f_hosp_code                                            ");
		sql.append("	                                    AND Y.JANGBI_CODE = :f_jangbi_code                                          ");
		sql.append("	                                    AND Y.HANGMOG_CODE IN (SELECT A.HANGMOG_CODE                                ");
		sql.append("	                                                            FROM CPL3020 A                                      ");
		sql.append("	                                                           WHERE A.HOSP_CODE    = :f_hosp_code                  ");
		sql.append("	                                                             AND A.JANGBI_CODE  = :f_jangbi_code                ");
		sql.append("	                                                             AND A.SPECIMEN_SER = :f_specimen_ser)              ");
		sql.append("	                                  )                                                                             ");
		sql.append("	       ) A                                                                                                      ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                                                                             ");
		sql.append("	   AND A.JANGBI_CODE = :f_jangbi_code                                                                           ");
		sql.append("	   AND A.RESULT_DATE BETWEEN :f_from_date AND :f_to_date                                                        ");
		sql.append("	   AND (                                                                                                        ");
		sql.append("	         (:f_all_yn = 'Y')                                                                                      ");
		sql.append("	         OR                                                                                                     ");
		sql.append("	         (:f_all_yn = 'N' AND A.SPECIMEN_SER IS NULL)                                                           ");
		sql.append("	       )                                                                                                        ");
		sql.append("	 ORDER BY A.RESULT_DATE DESC, A.SAMPLE_ID                                                                       ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jangbi_code", jangbiCode);
		query.setParameter("f_specimen_ser", specimentSer);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		query.setParameter("f_all_yn", allYn);
		
		List<Cpl3020U02ResultMapGrdIdInfo> list = new JpaResultMapper().list(query, Cpl3020U02ResultMapGrdIdInfo.class);
		return list;
	}

	@Override
	public List<Cpl3020U02ResultMapGrdRsltInfo> getCpl3020U02ResultMapGrdRsltInfo(
			String hospCode, String jangbiCode,
			Date resultDate, String sampleId) {
		StringBuilder sql = new StringBuilder();
		sql.append(" 	SELECT A.RESULT_CODE     RESULT_CODE                             ");
		sql.append(" 	     , B.HANGMOG_CODE    HANGMOG_CODE                            ");
		sql.append(" 	     , B.GUMSA_NAME      GUMSA_NAME                              ");
		sql.append(" 	     , TRIM( LEADING '0' FROM A.RESULT_VAL)    RESULT_VAL        ");
		sql.append(" 	  FROM CPL0101 B                                                 ");
		sql.append(" 	     , CPL0891 A                                                 ");
		sql.append(" 	 WHERE A.HOSP_CODE       = :f_hosp_code                          ");
		sql.append(" 	   AND A.JANGBI_CODE     = :f_jangbi_code                        ");
		sql.append(" 	   AND A.RESULT_DATE     = :f_result_date                        ");
		sql.append(" 	   AND A.SAMPLE_ID       = :f_sample_id                          ");
		sql.append(" 	   AND B.HOSP_CODE       = A.HOSP_CODE                           ");
		sql.append(" 	   AND B.JANGBI_CODE     = A.JANGBI_CODE                         ");
		sql.append(" 	   AND B.JANGBI_OUT_CODE = A.RESULT_CODE                         ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jangbi_code", jangbiCode);
		query.setParameter("f_result_date", resultDate);
		query.setParameter("f_sample_id", sampleId);

		List<Cpl3020U02ResultMapGrdRsltInfo> list = new JpaResultMapper().list(query, Cpl3020U02ResultMapGrdRsltInfo.class);
		return list;
	}
	
	
}

