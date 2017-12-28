package nta.med.data.dao.medi.bil.impl;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.logging.log4j.util.Strings;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bil.Bil0102RepositoryCustom;
import nta.med.data.model.ihis.bill.BIL2016R01GrdReportInfo;
import nta.med.data.model.ihis.bill.BIL2016R01GrdReportPaidDisCountInfo;

public class Bil0102RepositoryImpl  implements Bil0102RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<BIL2016R01GrdReportInfo> getGrdReportList(String hospCode, String language, Date fromDate, Date toDate,
			String assignDept, String assignDoctor, String exeDept, String exeDoctor, String serviceId, String personId,
			Integer startNum, Integer offset) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT   B.HANGMOG_CODE                                                                                         ");
		sql.append("			,B.HANGMOG_NAME																 	                        ");
		sql.append("			,E.GWA_NAME 																 	                        ");
		sql.append("			,D.USER_NM															 	                                ");
		sql.append("			,B.DEPT_REQ_NM																 	                        ");
		sql.append("			,B.DOCTOR_REQ_NM															 	                        ");
		sql.append("			,C.ACTING_DATE																 	                        ");
		sql.append("	        ,B.QUANTITY                                                            		 	                        ");
		sql.append("	        ,B.AMOUNT                                                             		 	                        ");
		sql.append("	        ,B.DISCOUNT                                                             		 	                    ");
		sql.append("	FROM BIL0101 A                 																					");
		sql.append("	INNER JOIN BIL0102 B ON A.INVOICE_NO = B.INVOICE_NO AND A.HOSP_CODE = B.HOSP_CODE                 				");
		sql.append("	LEFT JOIN OCS1003 C ON C.PKOCS1003 = B.FKOCS1003 AND C.HOSP_CODE = B.HOSP_CODE                 					");
		sql.append("	LEFT JOIN ADM3200 D ON D.HOSP_CODE = C.HOSP_CODE AND C.ACT_DOCTOR = D.USER_ID                 					");
		sql.append("	LEFT JOIN BAS0260 E ON E.HOSP_CODE = C.HOSP_CODE AND C.ACT_BUSEO = E.GWA  AND E.LANGUAGE = :f_language          ");
		sql.append("	WHERE A.ACTIVE_FLG = 1 AND B.ACTIVE_FLG = 1                                                                     ");
		sql.append("	   AND A.HOSP_CODE =:f_hosp_code                                                                     			");		
		
		if(fromDate != null) {
			sql.append("   AND A.INVOICE_DATE >= :f_from ");			
		}
		
		if(toDate != null) {
			sql.append("   AND A.INVOICE_DATE <= :f_to ");			
		}
		if(!"%".equals(assignDept) && !Strings.isEmpty(assignDept)){
			sql.append(" AND B.DEPT_REQ_CD =:f_assign_dept ");
		}
		if(!"%".equals(assignDoctor) && !Strings.isEmpty(assignDoctor)){
			sql.append(" AND B.DOCTOR_REQ =:f_assign_doctor ");
		}
		if(!"%".equals(exeDept) && !Strings.isEmpty(exeDept)){
			sql.append(" AND B.DEPT_EXC_CD =:f_exe_dept ");
		}
		if(!"%".equals(exeDoctor) && !Strings.isEmpty(exeDoctor)){
			sql.append(" AND B.DOCTOR_EXC =:f_exe_doctor  ");
		}
		if(!"%".equals(serviceId)){
			sql.append("	AND B.HANGMOG_NAME LIKE CONCAT( '%' , :f_service_id , '%')    ");
		}
		
		if (!"%".equals(personId)) {
			sql.append("	AND A.PATIENT_GRP = :f_person_id                                                                            ");
		}
		
		sql.append(" GROUP BY B.ID 																		    							");
		if (offset != null && offset != 0 && startNum != null ) {
			sql.append(" limit :startNum, :offset 																		    			");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (fromDate != null) {
			query.setParameter("f_from", fromDate);
		}
		if (toDate != null) {
			query.setParameter("f_to", toDate);
		}
		if(!"%".equals(assignDept) && !Strings.isEmpty(assignDept)){
			query.setParameter("f_assign_dept", assignDept);
		}
		if(!"%".equals(assignDoctor) && !Strings.isEmpty(assignDoctor)){
			query.setParameter("f_assign_doctor", assignDoctor);
		}
		if(!"%".equals(exeDept) && !Strings.isEmpty(exeDept)){
			query.setParameter("f_exe_dept", exeDept);
		}
		if(!"%".equals(exeDoctor) && !Strings.isEmpty(exeDoctor)){
			query.setParameter("f_exe_doctor", exeDoctor);
		}
		if (!"%".equals(serviceId)) {
			query.setParameter("f_service_id", serviceId);
		}
		if (!"%".equals(personId)) {
			query.setParameter("f_person_id", personId);
		}
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		if (offset != null && offset != 0 && startNum != null ) {
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
			List<BIL2016R01GrdReportInfo> list = new JpaResultMapper().list(query, BIL2016R01GrdReportInfo.class);

			return list;
		}

	@Override
	public List<BIL2016R01GrdReportPaidDisCountInfo> getBIL2016R01GrdReportPaidDisCountInfo(String hospCode, String language,
			Date fromDate, Date toDate, String assignDept, String assignDoctor, String exeDept, String exeDoctor,
			String serviceId, String personId, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
//		sql.append(" SELECT SUM(IF(A.INVOICE_NO = A.PARENT_INVOICE_NO, A.AMOUNT_PAID, CAST(0 AS decimal(15,2)))) AMOUNT_PAID,           ");
//		sql.append(" SUM(IF(A.INVOICE_NO = A.PARENT_INVOICE_NO,(A.DISCOUNT), CAST(0 AS decimal(15,2)))) DISCOUNT                        ");
		
		sql.append(" SELECT  SUM(AMOUNT_PAID) AMOUNT_PAID,                                                                              ");    																
		sql.append("     SUM(DISCOUNT) DISCOUNT                                                                                         ");
		sql.append("   FROM BIL0101                                                                                                     ");
		sql.append("   WHERE HOSP_CODE = :f_hosp_code                                                                                   ");
		sql.append("   AND ACTIVE_FLG = 1                                                                                               ");
		sql.append("   AND PARENT_INVOICE_NO IN (                                                                                       ");
		sql.append(" SELECT A.PARENT_INVOICE_NO       																	        	    ");
		sql.append("	FROM BIL0101 A                 																					");
		sql.append("	INNER JOIN BIL0102 B ON A.INVOICE_NO = B.INVOICE_NO AND A.HOSP_CODE = B.HOSP_CODE                 				");
		sql.append("	LEFT JOIN OCS1003 C ON C.PKOCS1003 = B.FKOCS1003 AND C.HOSP_CODE = B.HOSP_CODE                 					");
		sql.append("	LEFT JOIN ADM3200 D ON D.HOSP_CODE = C.HOSP_CODE AND C.ACT_DOCTOR = D.USER_ID                 					");
		sql.append("	LEFT JOIN BAS0260 E ON E.HOSP_CODE = C.HOSP_CODE AND C.ACT_BUSEO = E.GWA                 						");
		sql.append("	WHERE A.ACTIVE_FLG = 1 AND B.ACTIVE_FLG = 1                                                                     ");
		sql.append("	   AND A.HOSP_CODE =:f_hosp_code                                                                     			");		
		
		if(fromDate != null) {
			sql.append("   AND A.INVOICE_DATE >= :f_from ");			
		}
		
		if(toDate != null) {
			sql.append("   AND A.INVOICE_DATE <= :f_to ");			
		}
		if(!"%".equals(assignDept) && !Strings.isEmpty(assignDept)){
			sql.append(" AND B.DEPT_REQ_CD =:f_assign_dept ");
		}
		if(!"%".equals(assignDoctor) && !Strings.isEmpty(assignDoctor)){
			sql.append(" AND B.DOCTOR_REQ =:f_assign_doctor ");
		}
		if(!"%".equals(exeDept) && !Strings.isEmpty(exeDept)){
			sql.append(" AND B.DEPT_EXC_CD =:f_exe_dept ");
		}
		if(!"%".equals(exeDoctor) && !Strings.isEmpty(exeDoctor)){
			sql.append(" AND B.DOCTOR_EXC =:f_exe_doctor  ");
		}
		if(!"%".equals(serviceId)){
			sql.append("	AND B.HANGMOG_NAME LIKE CONCAT( '%' , :f_service_id , '%')    ");
		}
		
		if (!"%".equals(personId)) {
			sql.append("	AND A.PATIENT_GRP = :f_person_id                                                                            ");
		}
		
		sql.append(" GROUP BY  A.PARENT_INVOICE_NO 	)																	    	    	");
//		if (offset != null && offset != 0 && startNum != null ) {
//			sql.append(" limit :startNum, :offset 																		    			");
//		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (fromDate != null) {
			query.setParameter("f_from", fromDate);
		}
		if (toDate != null) {
			query.setParameter("f_to", toDate);
		}
		if(!"%".equals(assignDept) && !Strings.isEmpty(assignDept)){
			query.setParameter("f_assign_dept", assignDept);
		}
		if(!"%".equals(assignDoctor) && !Strings.isEmpty(assignDoctor)){
			query.setParameter("f_assign_doctor", assignDoctor);
		}
		if(!"%".equals(exeDept) && !Strings.isEmpty(exeDept)){
			query.setParameter("f_exe_dept", exeDept);
		}
		if(!"%".equals(exeDoctor) && !Strings.isEmpty(exeDoctor)){
			query.setParameter("f_exe_doctor", exeDoctor);
		}
		if (!"%".equals(serviceId)) {
			query.setParameter("f_service_id", serviceId);
		}
		if (!"%".equals(personId)) {
			query.setParameter("f_person_id", personId);
		}
		query.setParameter("f_hosp_code", hospCode);
		
//		if (offset != null && offset != 0 && startNum != null ) {
//			query.setParameter("startNum", startNum);
//			query.setParameter("offset", offset);
//		}
		List<BIL2016R01GrdReportPaidDisCountInfo> list = new JpaResultMapper().list(query, BIL2016R01GrdReportPaidDisCountInfo.class);
		return list;
	}
}