package nta.med.data.dao.medi.bil.impl;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bil.Bil0101RepositoryCustom;
import nta.med.data.model.ihis.bill.BIL2016U01LoadPatientInfo;
import nta.med.data.model.ihis.bill.BIL2016U02PrintAmountInfo;
import nta.med.data.model.ihis.bill.LoadGridBIL2016U02Info;
import nta.med.data.model.ihis.bill.LoadGridBIL2016U02SumInfo;
import nta.med.data.model.ihis.bill.LoadGridPayHistoryBIL2016U02Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;

public class Bil0101RepositoryImpl implements Bil0101RepositoryCustom{
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<ComboListItemInfo> getTotalAmount(String hospCode, Date visitDate, Date toDate, String bunho, String patientName, String invoiceNo) {
		StringBuilder sql = new StringBuilder();
//		sql.append(" SELECT IFNULL(CAST((SUM(AMOUNT) - SUM(DISCOUNT)) AS CHAR) + 0, '0') REVENUE ");
		sql.append(" SELECT IFNULL(CAST((SUM(AMOUNT_PAID)) AS CHAR) + 0, '0') REVENUE ");
		sql.append(" ,CAST(COUNT(1) AS CHAR)  TOTAL_PATIENT                     ");
		sql.append(" FROM BIL0101                                  ");
		sql.append(" WHERE HOSP_CODE = :hosp_code                  ");
		sql.append(" AND ACTIVE_FLG = 1                            ");
		sql.append(" AND STATUS_FLG IN (2,3)                       ");
		if(visitDate != null && toDate != null){
			sql.append(" AND VISIT_DATE >= :visit_date              ");
			sql.append(" AND VISIT_DATE <= :to_date                ");
		}
		
		if(!StringUtils.isEmpty(bunho)){
			sql.append(" AND BUNHO = :bunho                        ");
		}
		if(!StringUtils.isEmpty(invoiceNo)){
			sql.append(" AND INVOICE_NO LIKE :invoice_no              ");
		}
		
		if(!StringUtils.isEmpty(patientName)){
			sql.append(" AND PATIENT_NM      LIKE :patientName	");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		if(visitDate != null && toDate != null){
			query.setParameter("visit_date", visitDate);
			query.setParameter("to_date", toDate);
		}
		
		if(!StringUtils.isEmpty(bunho)){
			query.setParameter("bunho", bunho);
		}
		if(!StringUtils.isEmpty(invoiceNo)){
			query.setParameter("invoice_no", "%" + invoiceNo + "%");
		}
		
		if(!StringUtils.isEmpty(patientName)){
			query.setParameter("patientName", "%" + patientName + "%");
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<BIL2016U01LoadPatientInfo> getPaidTabBIL2016U01LoadPatientInfo(String hospCode, Date visitDate, Date toDate, String bunho, String patientName, String invoiceNo) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT INVOICE_DATE,            		");
		sql.append(" 		INVOICE_NO,                     ");
		sql.append(" 		BUNHO,                          ");
		sql.append(" 		PATIENT_NM,                     ");
		sql.append(" 		PATIENT_ADDR,                   ");
		sql.append(" 		PATIENT_GENDER,                 ");
		sql.append(" 		VISIT_DATE,                     ");
		sql.append(" 		'',                             ");
		sql.append(" 		PATIENT_GRP_NM,                 ");
		sql.append(" 		PATIENT_DOB,                    ");
		sql.append(" 		FKOUT1001,                      ");
		sql.append("		PATIENT_TEL,					");
		sql.append("		PAID_NAME	,					");
		sql.append("		''	type_money,					");
		sql.append("		AMOUNT	,						");
		sql.append("		DISCOUNT	,					");
		sql.append("		AMOUNT_PAID	,					");
		sql.append("	AMOUNT - DISCOUNT - AMOUNT_PAID,    ");
		sql.append("		 PARENT_INVOICE_NO   ,          ");
		sql.append("		 STATUS_FLG 			        ");
		sql.append(" 		FROM BIL0101                    ");
		sql.append(" WHERE HOSP_CODE = :hosp_code    		");
		sql.append("   AND ACTIVE_FLG = 1              		");
		sql.append("   AND STATUS_FLG = 2              		");
		if(visitDate != null && toDate != null){
			sql.append(" AND VISIT_DATE >= :visit_date    ");
			sql.append(" AND VISIT_DATE <= :to_date       ");
		}
		
		if(!StringUtils.isEmpty(bunho)){
			sql.append(" AND BUNHO      = :bunho         ");
		}
		
		if(!StringUtils.isEmpty(invoiceNo)){
			sql.append(" AND INVOICE_NO LIKE :invoice_no     	");
		}
		
		if(!StringUtils.isEmpty(patientName)){
			sql.append(" AND PATIENT_NM      LIKE :patientName	");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		if(visitDate != null && toDate != null){
			query.setParameter("visit_date", visitDate);
			query.setParameter("to_date", toDate);
		}
		
		if(!StringUtils.isEmpty(bunho)){
			query.setParameter("bunho", bunho);
		}
		if(!StringUtils.isEmpty(invoiceNo)){
			query.setParameter("invoice_no", "%" + invoiceNo + "%");
		}

		if(!StringUtils.isEmpty(patientName)){
			query.setParameter("patientName", "%" + patientName + "%");
		}
		
		List<BIL2016U01LoadPatientInfo> list = new JpaResultMapper().list(query, BIL2016U01LoadPatientInfo.class);
		return list;
	}
	
	@Override
	public List<LoadGridBIL2016U02Info> getInvoiceDetailList(String hospCode, String invoiceNo, boolean isActive) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  B.HANGMOG_CODE,																	");
		sql.append("	        B.HANGMOG_NAME,																	");
		sql.append("	        B.UNIT,																			");
		sql.append("	        B.PRICE,																		");
		sql.append("	        B.QUANTITY,																		");
		sql.append("	        B.AMOUNT,																		");
		sql.append("	        B.INSURANCE_PAY,																");
		sql.append("	        B.PATIENT_PAY,																	");
		sql.append("	        B.DISCOUNT,																		");
		sql.append("	        B.DEPT_REQ_CD,																	");
		sql.append("	        B.DEPT_REQ_NM,																	");
		sql.append("	        B.DOCTOR_REQ,																	");
		sql.append("	        B.DOCTOR_REQ_NM,																");
		sql.append("	        B.DEPT_EXC_CD,																	");
		sql.append("	        B.DEPT_EXC_NM,																	");
		sql.append("	        B.DOCTOR_EXC,																	");
		sql.append("	        B.DOCTOR_EXC_NM,																");
		sql.append("	        B.ORDER_GRP,																	");
		sql.append("	        B.ORDER_GRP_NM,																	");
		sql.append("			IFNULL(DATE_FORMAT(B.ORDER_DATE, '%Y/%m/%d'), '')	AS ORDER_DATE,				");
		sql.append("			IFNULL(DATE_FORMAT(B.ACTING_DATE, '%Y/%m/%d'), '')	AS ACTING_DATE,				");
		sql.append("			IFNULL(A.PAYMENT_NM, ''),														");
		sql.append("			IFNULL(A.PAYMENT_CD, ''),														");
		sql.append("			IFNULL(A.PAID_NAME, ''),														");
		sql.append("			IFNULL(B.DISCOUNT_REASON, ''),													");
		sql.append("			B.FKOCS1003,																	");
		sql.append("			A.DISCOUNT										AS TOTAL_DISCOUNT,				");
		sql.append("			IFNULL(A.DISCOUNT_TYPE, '')						AS DISCOUNT_TYPE,				");
		sql.append("			IFNULL(A.DISCOUNT_COMMENT, '')					AS DISCOUNT_REASON_MASTER,		");
		sql.append("			IFNULL(A.REVERT_TYPE, ''),														");
		sql.append("			IFNULL(A.REVERT_COMMENT, '')	,												");
		sql.append("			A.AMOUNT_PAID					,												");
		sql.append("			A.AMOUNT_DEBT																	");
		sql.append("	FROM BIL0101 A																			");
		sql.append("	JOIN BIL0102 B ON A.HOSP_CODE = B.HOSP_CODE												");
		sql.append("	              AND A.PARENT_INVOICE_NO = B.INVOICE_NO											");
		sql.append("	WHERE A.INVOICE_NO = :f_invoice_no														");
		sql.append("	  AND A.HOSP_CODE = :f_hosp_code														");
		
		if(isActive){
			sql.append("	  AND A.ACTIVE_FLG = 1																");
			sql.append("	  AND B.ACTIVE_FLG = 1																");
		}
//		else {
//			sql.append("	  AND A.ACTIVE_FLG = 0																");
//			sql.append("	  AND B.ACTIVE_FLG = 0																");
//		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_invoice_no", invoiceNo);
		query.setParameter("f_hosp_code", hospCode);
		
		List<LoadGridBIL2016U02Info> listData = new JpaResultMapper().list(query,LoadGridBIL2016U02Info.class);
		return listData;
	}
	
	@Override
	public List<LoadGridBIL2016U02Info> getInvoiceUnPayDetailList(String hospCode, String language, String bunho, Double fkout1001, String bunhoType) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  A.HANGMOG_CODE,																													");
		sql.append("	        D.HANGMOG_NAME,																													");
		sql.append("	        IFNULL(E.CODE_NAME, ''),																										");
		sql.append("        CASE																																");
		sql.append("          WHEN :f_bunho_type = 'I' THEN B.PRICE1																							");
		sql.append("          WHEN :f_bunho_type = 'N' THEN B.PRICE2																							");
		sql.append("          WHEN :f_bunho_type = 'F' THEN B.PRICE3																							");
		sql.append("        END                                                                                                               AS PRICE,			");
		sql.append("        CAST(FN_DRG_WONYOI_TOT_SURYANG(A.NALSU, A.SURYANG, A.DV ,A.DV_TIME)  AS CHAR)			     AS QUANTITY,	                    	");
		sql.append("        CASE 																																");
		sql.append("          WHEN :f_bunho_type = 'I' THEN CAST(B.PRICE1*(FN_DRG_WONYOI_TOT_SURYANG(A.NALSU, A.SURYANG, A.DV ,A.DV_TIME)) AS decimal(15,2))	");
		sql.append("          WHEN :f_bunho_type = 'N' THEN CAST(B.PRICE2*(FN_DRG_WONYOI_TOT_SURYANG(A.NALSU, A.SURYANG, A.DV ,A.DV_TIME)) AS decimal(15,2))	");
		sql.append("          WHEN :f_bunho_type = 'F' THEN CAST(B.PRICE3*(FN_DRG_WONYOI_TOT_SURYANG(A.NALSU, A.SURYANG, A.DV ,A.DV_TIME)) AS decimal(15,2))	");
		sql.append("		  ELSE 0																															");
		sql.append("        END                                                                                                               AS AMOUNT,		");
		sql.append("        CASE WHEN :f_bunho_type = 'I' THEN CAST(B.PRICE1*(FN_DRG_WONYOI_TOT_SURYANG(A.NALSU, A.SURYANG, A.DV ,A.DV_TIME)) AS decimal(15,2)) ELSE 0 END AS INSURANCE_PAY,			");
		sql.append("        CASE 																																");
		sql.append("          WHEN :f_bunho_type = 'I' THEN CAST('0' AS decimal(15,2))																			");
		sql.append("          WHEN :f_bunho_type = 'N' THEN CAST(B.PRICE2*(FN_DRG_WONYOI_TOT_SURYANG(A.NALSU, A.SURYANG, A.DV ,A.DV_TIME)) AS decimal(15,2))	");
		sql.append("          WHEN :f_bunho_type = 'F' THEN CAST(B.PRICE3*(FN_DRG_WONYOI_TOT_SURYANG(A.NALSU, A.SURYANG, A.DV ,A.DV_TIME)) AS decimal(15,2))	");
		sql.append("		  ELSE 0																															");
		sql.append("        END                                                                                                               AS PATIENT_PAY,	");
		sql.append("        CAST('0' AS decimal(15,2))                 					                                                      AS DISCOUNT,		");
		sql.append("	        H.GWA	                                        											AS DEPT_REQ_CD,						");
		sql.append("	        H.GWA_NAME                                        											AS DEPT_REQ_NM,						");
		sql.append("	        I.DOCTOR                                     												AS DOCTOR_REQ_CD,					");
		sql.append("	        I.DOCTOR_NAME                                     											AS DOCTOR_REQ_NM,					");
		sql.append("	        H1.GWA		                                       											AS DEPT_EXC_CD,						");
		sql.append("	        H1.GWA_NAME                                       											AS DEPT_EXC_NM,						");
//		sql.append("	        IFNULL(I1.SABUN, '')	                        											AS DOCTOR_EXC_CD,					");
//		sql.append("	        IFNULL(I1.DOCTOR_NAME, '')                        											AS DOCTOR_EXC_NM,					");
		sql.append("	        IFNULL(I1.SABUN, A.ACT_DOCTOR)	                        											AS DOCTOR_EXC_CD,					");
		sql.append("	        IFNULL(I1.DOCTOR_NAME, N.USER_NM)                        											AS DOCTOR_EXC_NM,					");
		
		sql.append("	        IFNULL(E1.CODE, '')                          												AS ORDER_GRP_CD,					");
		sql.append("	        IFNULL(E1.CODE_NAME, '')                          											AS ORDER_GRP_NM,					");
		sql.append("			IFNULL(DATE_FORMAT(A.ORDER_DATE, '%Y/%m/%d'), '')											AS ORDER_DATE,						");
		sql.append("			IFNULL(DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d'), '')											AS ACTING_DATE,						");
		sql.append("			''																							AS PAYMENT_NM,						");
		sql.append("			''																							AS PAYMENT_CD,						");
		sql.append("			''																							AS PAID_NAME,						");
		sql.append("			''																							AS DISCOUNT_REASON,					");
		sql.append("	        A.PKOCS1003,																													");
		sql.append("	        CAST(0 AS decimal(15,2))																	AS TOTAL_DISCOUNT,					");
		sql.append("			''																							AS DISCOUNT_TYPE,					");
		sql.append("			''																							AS DISCOUNT_REASON_MASTER,			");
		sql.append("			''																							AS REVERT_TYPE,						");
		sql.append("			''																							AS REVERT_COMMENT	,				");
		sql.append("			CAST(0 AS decimal(15,2))																	AS amount_paid		,		    	");
		sql.append("			CAST(0 AS decimal(15,2))																	AS amount_debt				    	");
		sql.append("	FROM OCS1003 A																											");
		sql.append("	LEFT JOIN BIL0001 B ON B.HOSP_CODE = :f_hosp_code																		");
		sql.append("	              AND B.HANGMOG_CODE = A.HANGMOG_CODE																		");
		sql.append("	JOIN OUT1001 C ON C.HOSP_CODE = :f_hosp_code																			");
		sql.append("	              AND C.BUNHO = :f_bunho																					");
		sql.append("	              AND C.PKOUT1001 = :f_fkout1001																			");
		sql.append("	JOIN OCS0103 D ON D.HOSP_CODE = :f_hosp_code																			");
		sql.append("	              AND D.HANGMOG_CODE = A.HANGMOG_CODE																		");
		sql.append("	              AND A.ORDER_DATE BETWEEN D.START_DATE AND D.END_DATE														");
		sql.append("	LEFT JOIN OCS0132 E ON E.HOSP_CODE = :f_hosp_code																		");
		sql.append("	              AND E.LANGUAGE = :f_language																				");
		sql.append("	              AND E.CODE_TYPE = 'ORD_DANUI'																				");
		sql.append("	              AND E.CODE = A.ORD_DANUI																					");
		sql.append("	LEFT JOIN BAS0260 H ON H.HOSP_CODE = :f_hosp_code																		");
		sql.append("	                   AND H.LANGUAGE = :f_language																			");
		sql.append("	                   AND A.GWA = H.GWA																					");
		sql.append("	LEFT JOIN BAS0270 I ON I.HOSP_CODE = :f_hosp_code																		");
		sql.append("	                   AND A.DOCTOR = I.DOCTOR																				");
		sql.append("	LEFT JOIN BAS0260 H1 ON H1.HOSP_CODE = :f_hosp_code																		");
		sql.append("	                   AND H1.LANGUAGE = :f_language																		");
		sql.append("	                   AND A.ACT_BUSEO = H1.GWA																				");
		sql.append("	LEFT JOIN BAS0270 I1 ON I1.HOSP_CODE = :f_hosp_code																		");
		sql.append("	                   AND A.ACT_DOCTOR = I1.SABUN																			");
		sql.append("	LEFT JOIN OCS0132 E1 ON E1.HOSP_CODE = :f_hosp_code																		");
		sql.append("	                    AND E1.LANGUAGE = :f_language																		");
		sql.append("	                    AND E1.CODE_TYPE = 'ORDER_GUBUN'																	");
		sql.append("	                    AND E1.CODE = A.ORDER_GUBUN																			");
		sql.append("	LEFT JOIN ADM3200 N ON A.HOSP_CODE = N.HOSP_CODE AND A.ACT_DOCTOR = N.USER_ID											");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																						");
		sql.append("	  AND A.FKOUT1001 = :f_fkout1001																						");
		sql.append("	  AND A.BUNHO = :f_bunho																								");
		sql.append("	  AND (A.PAID_YN = 'N' OR A.PAID_YN IS NULL)																			");
		sql.append(" UNION	SELECT  A.CHOJAE,																														    ");          
		sql.append("	        C.CODE_NAME,																													        ");
		sql.append("	        CASE																																    ");
		sql.append("          WHEN :f_language = 'JA' THEN '回'																							                ");
		sql.append("          WHEN :f_language = 'VI' THEN 'lần'																							            ");
		sql.append("          WHEN :f_language = 'EN' THEN 'time'																							            ");
		sql.append("        END      ,																										                            ");
		sql.append("        CASE																																        ");
		sql.append("          WHEN :f_bunho_type = 'I' THEN B.PRICE1																							        ");
		sql.append("          WHEN :f_bunho_type = 'N' THEN B.PRICE2																							        ");
		sql.append("          WHEN :f_bunho_type = 'F' THEN B.PRICE3																							        ");
		sql.append("        END                                                                                          AS PRICE,			                            ");
		sql.append("        '1'			     AS QUANTITY,	                    	                                                                                    ");
		sql.append("        CASE 																																        ");
		sql.append("          WHEN :f_bunho_type = 'I' THEN CAST(B.PRICE1 AS decimal(15,2))	                                                                            ");
		sql.append("          WHEN :f_bunho_type = 'N' THEN CAST(B.PRICE2 AS decimal(15,2))	                                                                            ");
		sql.append("          WHEN :f_bunho_type = 'F' THEN CAST(B.PRICE3 AS decimal(15,2))	                                                                            ");
		sql.append("		  ELSE 0																															        ");
		sql.append("        END                                                                                                               AS AMOUNT,		        ");
		sql.append("        CASE WHEN :f_bunho_type = 'I' THEN CAST(B.PRICE1 AS decimal(15,2)) ELSE 0 END AS INSURANCE_PAY,                                             ");
		sql.append("        CASE 																																        ");
		sql.append("          WHEN :f_bunho_type = 'I' THEN CAST('0' AS decimal(15,2))																			        ");
		sql.append("          WHEN :f_bunho_type = 'N' THEN CAST(B.PRICE2 AS decimal(15,2))	                                                                            ");
		sql.append("          WHEN :f_bunho_type = 'F' THEN CAST(B.PRICE3 AS decimal(15,2))	                                                                            ");
		sql.append("		  ELSE 0																															        ");
		sql.append("        END                                                                                                               AS PATIENT_PAY,	        ");
		sql.append("        CAST('0' AS decimal(15,2))                 					                                                      AS DISCOUNT,		        ");
		sql.append(" 	        ' '	                                        											AS DEPT_REQ_CD,						            ");
		sql.append(" 	        ' '                                        											AS DEPT_REQ_NM,						                ");
		sql.append(" 	        ' '                                     												AS DOCTOR_REQ_CD,					            ");
		sql.append(" 	        ' '                                     											AS DOCTOR_REQ_NM,					                ");
		sql.append("	        ' '		                                       											AS DEPT_EXC_CD,						            ");
		sql.append("	        ' '                                      											AS DEPT_EXC_NM,						                ");
		sql.append("	        ' '	                        											AS DOCTOR_EXC_CD,					                            ");
		sql.append("	        ' '                      											AS DOCTOR_EXC_NM,					                                ");
		sql.append("	        ' '                         												AS ORDER_GRP_CD,					                        ");
		sql.append("	        CASE																																    ");
		sql.append("          		WHEN :f_language = 'JA' THEN '診'																							        ");
		sql.append("         		WHEN :f_language = 'VI' THEN 'Khám'																							        ");
		sql.append("     		    WHEN :f_language = 'EN' THEN 'Admission'																						    ");
		sql.append("       		END    ORDER_GRP_NM  ,																										            ");
		sql.append("			IFNULL(DATE_FORMAT(A.NAEWON_DATE, '%Y/%m/%d'), '')											AS ORDER_DATE,						        ");
		sql.append("			IFNULL(DATE_FORMAT(A.NAEWON_DATE, '%Y/%m/%d'), '')											AS ACTING_DATE,						        ");
		sql.append("			' '																							AS PAYMENT_NM,						        ");
		sql.append("			' '																							AS PAYMENT_CD,						        ");
		sql.append("			' '																							AS PAID_NAME,						        ");
		sql.append("			' '																							AS DISCOUNT_REASON,					        ");
//		sql.append("	        A.PKOUT1001,																													        ");
		sql.append("	        CAST(null as DECIMAL),																				    		        		        ");
		sql.append("	        CAST(0 AS decimal(15,2))																	AS TOTAL_DISCOUNT,					        ");
		sql.append("			' '																							AS DISCOUNT_TYPE,					        ");
		sql.append("			' '																							AS DISCOUNT_REASON_MASTER,			        ");
		sql.append("			' '																							AS REVERT_TYPE,						        ");
		sql.append("			' '																							AS REVERT_COMMENT	,				        ");
		sql.append("			CAST(0 AS decimal(15,2))																	AS amount_paid		,		     			");
		sql.append("			CAST(0 AS decimal(15,2))																	AS amount_debt				  			  	");
		sql.append("			FROM OUT1001 A LEFT JOIN BIL0001 B ON B.HOSP_CODE = A.HOSP_CODE    AND A.CHOJAE = B.HANGMOG_CODE                                        ");                                                     
		sql.append("				LEFT JOIN BAS0102 C ON A.HOSP_CODE = C.HOSP_CODE AND A.CHOJAE = C.CODE AND  C.LANGUAGE = :f_language  AND C.CODE_TYPE = 'CHOJAE'    ");                                                                                                            
		sql.append("			WHERE A.HOSP_CODE = :f_hosp_code                                                                                                        ");
		sql.append("		 AND A.PKOUT1001 = :f_fkout1001	                                                                                                            ");
		sql.append("      AND IFNULL(A.PAID_YN,'N') = 'N'																												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkout1001", fkout1001);
		query.setParameter("f_bunho_type", bunhoType);
		
		List<LoadGridBIL2016U02Info> listData = new JpaResultMapper().list(query,LoadGridBIL2016U02Info.class);
		return listData;
	}

	@Override
	public List<BIL2016U01LoadPatientInfo> getCancelTabBIL2016U01LoadPatientInfo(String hospCode, Date visitDate,
			Date toDate, String bunho, String patientName, String invoiceNo) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT INVOICE_DATE,            		");
		sql.append(" 		INVOICE_NO,                     ");
		sql.append(" 		BUNHO,                          ");
		sql.append(" 		PATIENT_NM,                     ");
		sql.append(" 		PATIENT_ADDR,                   ");
		sql.append(" 		PATIENT_GENDER,                 ");
		sql.append(" 		VISIT_DATE,                     ");
		sql.append(" 		'',                             ");
		sql.append(" 		PATIENT_GRP_NM,                 ");
		sql.append(" 		PATIENT_DOB,                    ");
		sql.append(" 		FKOUT1001,                      ");
		sql.append("		PATIENT_TEL,					");
		sql.append("		PAID_NAME	,					");
		sql.append("		''		type_money	,			");
		sql.append("		AMOUNT	,						");
		sql.append("		DISCOUNT	,					");
		sql.append("		AMOUNT_PAID	,					");
		sql.append("	    AMOUNT_DEBT ,                	");
		sql.append("	       PARENT_INVOICE_NO  ,         ");
		sql.append("	    STATUS_FLG                      ");
		sql.append(" 		FROM BIL0101                    ");
		sql.append(" WHERE HOSP_CODE = :hosp_code    		");
		sql.append("   AND ACTIVE_FLG = 0              		");
		
		if(visitDate != null && toDate != null){
			sql.append(" AND VISIT_DATE >= :visit_date    ");
			sql.append(" AND VISIT_DATE <= :to_date    ");
		}
		
		if(!StringUtils.isEmpty(bunho)){
			sql.append(" AND BUNHO      = :bunho         ");
		}
		
		if(!StringUtils.isEmpty(invoiceNo)){
			sql.append(" AND INVOICE_NO LIKE :invoice_no     	");
		}
		
		if(!StringUtils.isEmpty(patientName)){
			sql.append(" AND PATIENT_NM      LIKE :patientName	");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		if(visitDate != null && toDate != null){
			query.setParameter("visit_date", visitDate);
			query.setParameter("to_date", toDate);
		}
		
		if(!StringUtils.isEmpty(bunho)){
			query.setParameter("bunho", bunho);
		}
		if(!StringUtils.isEmpty(invoiceNo)){
			query.setParameter("invoice_no", "%" + invoiceNo + "%");
		}

		if(!StringUtils.isEmpty(patientName)){
			query.setParameter("patientName", "%" + patientName + "%");
		}
		
		List<BIL2016U01LoadPatientInfo> list = new JpaResultMapper().list(query, BIL2016U01LoadPatientInfo.class);
		return list;
	}

	@Override
	public List<BIL2016U01LoadPatientInfo> getUnCompletedTabBIL2016U01LoadPatientInfo(String hospCode, Date visitDate,
			Date toDate, String bunho, String patientName, String invoiceNo) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT INVOICE_DATE,            		");
		sql.append(" 		INVOICE_NO,                     ");
		sql.append(" 		BUNHO,                          ");
		sql.append(" 		PATIENT_NM,                     ");
		sql.append(" 		PATIENT_ADDR,                   ");
		sql.append(" 		PATIENT_GENDER,                 ");
		sql.append(" 		VISIT_DATE,                     ");
		sql.append(" 		'',                             ");
		sql.append(" 		PATIENT_GRP_NM,                 ");
		sql.append(" 		PATIENT_DOB,                    ");
//		sql.append(" 		cast(null as signed),           ");
		sql.append(" 		FKOUT1001,           			");
		sql.append("		PATIENT_TEL,					");
		sql.append("		PAID_NAME	,					");
		sql.append("		''	 type_money ,				");
		sql.append("		AMOUNT	,						");
		sql.append("		DISCOUNT	,					");
		sql.append("		AMOUNT_PAID	,					");
		sql.append("		AMOUNT_DEBT  ,               	");
		sql.append("		PARENT_INVOICE_NO ,             "); 
		sql.append("		STATUS_FLG                  	");
		sql.append(" 		FROM BIL0101                    ");
		sql.append(" WHERE HOSP_CODE = :hosp_code    		");
		sql.append("   AND ACTIVE_FLG = 1              		");
		if(visitDate != null && toDate != null){
			sql.append(" AND VISIT_DATE >= :visit_date    ");
			sql.append(" AND VISIT_DATE <= :to_date       ");
		}
		
		if(!StringUtils.isEmpty(bunho)){
			sql.append(" AND BUNHO      = :bunho         ");
		}
		
		if(!StringUtils.isEmpty(invoiceNo)){
			sql.append(" AND INVOICE_NO LIKE :invoice_no     	");
		}
		
		if(!StringUtils.isEmpty(patientName)){
			sql.append(" AND PATIENT_NM      LIKE :patientName	");
		}
		sql.append(" AND INVOICE_NO = PARENT_INVOICE_NO          ");
		sql.append(" AND AMOUNT_DEBT > 0                         ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		if(visitDate != null && toDate != null){
			query.setParameter("visit_date", visitDate);
			query.setParameter("to_date", toDate);
		}
		
		if(!StringUtils.isEmpty(bunho)){
			query.setParameter("bunho", bunho);
		}
		if(!StringUtils.isEmpty(invoiceNo)){
			query.setParameter("invoice_no", "%" + invoiceNo + "%");
		}

		if(!StringUtils.isEmpty(patientName)){
			query.setParameter("patientName", "%" + patientName + "%");
		}
		
		List<BIL2016U01LoadPatientInfo> list = new JpaResultMapper().list(query, BIL2016U01LoadPatientInfo.class);
		return list;
	}

	@Override
	public List<String> getLasteInvoiceBIL2016U02(String hospCode, String parentInvoiceNo) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT MAX(INVOICE_NO)	 LATEST_INVOICE                          ");
		sql.append(" FROM BIL0101 WHERE HOSP_CODE = :hosp_code                       ");
		sql.append(" AND ACTIVE_FLG = 1 AND PARENT_INVOICE_NO = :parent_invoice_no  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("parent_invoice_no", parentInvoiceNo);
		List<String> result = query.getResultList();
		return result;
	}

	@Override
	public List<LoadGridPayHistoryBIL2016U02Info> getLoadGridPayHistoryBIL2016U02Info(String hospCode, String parentInvoiceNo) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.INVOICE_NO ,                                      ");                                  
		sql.append(" B.INVOICE_DATE,                                            ");                                                                                                                     
		sql.append(" B.AMOUNT,                                                  ");                                                                                                                  
		sql.append(" B.DISCOUNT,                                                ");                                   
		sql.append(" B.AMOUNT_PAID,                                             ");   
		sql.append(" B.PARENT_INVOICE_NO,                                       ");   
		sql.append(" CASE WHEN B.ACTIVE_FLG = 0 THEN '0'                        ");                                   
		sql.append("  WHEN B.ACTIVE_FLG = 1 AND B.STATUS_FLG = 2 THEN '2'       ");
		sql.append("  WHEN B.ACTIVE_FLG = 1 AND B.STATUS_FLG = 3 THEN '3' END,  ");
		sql.append(" CASE WHEN B.PARENT_INVOICE_NO = B.INVOICE_NO               ");
		sql.append("             THEN B.AMOUNT - B.DISCOUNT - B.AMOUNT_PAID     ");
		sql.append("       ELSE       B.AMOUNT_DEBT END							");
		sql.append(" FROM  BIL0101 B                                            ");
		sql.append(" WHERE B.HOSP_CODE = :hosp_code                             ");                                   
		sql.append(" AND B.PARENT_INVOICE_NO = :parent_invoice_no               ");                                   
		sql.append(" ORDER BY B.INVOICE_DATE ASC								");									
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("parent_invoice_no", parentInvoiceNo);
		List<LoadGridPayHistoryBIL2016U02Info> list = new JpaResultMapper().list(query, LoadGridPayHistoryBIL2016U02Info.class);
		return list;
	}

	@Override
	public List<LoadGridBIL2016U02SumInfo> getLoadGridBIL2016U02SumInfoByParentInvoiceNo(String hospCode, String parentInvoiceNo) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.AMOUNT, CAST(0 AS decimal(15,2))) SUM_AMOUNT,                                             ");
		sql.append("         IFNULL(SUM(A.DISCOUNT), CAST(0 AS decimal(15,2))) SUM_DISCOUNT,                                      ");
		sql.append("         IFNULL(SUM(A.AMOUNT_PAID), CAST(0 AS decimal(15,2))),                                                ");
		sql.append("         IFNULL(A.AMOUNT_DEBT, CAST(0 AS decimal(15,2)))                                                      ");
		sql.append(" FROM BIL0101 A WHERE A.HOSP_CODE = :hosp_code                                                                ");
		sql.append(" AND A.PARENT_INVOICE_NO = :parent_invoice_no AND A.ACTIVE_FLG = 1                                            ");	
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("parent_invoice_no", parentInvoiceNo);
		List<LoadGridBIL2016U02SumInfo> list = new JpaResultMapper().list(query, LoadGridBIL2016U02SumInfo.class);
		return list;
	}

	@Override
	public List<LoadGridBIL2016U02SumInfo> getLoadGridBIL2016U02SumInfoByInvoiceNo(String hospCode, String invoiceNo) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.AMOUNT, CAST(0 AS decimal(15,2))) SUM_AMOUNT,                                             ");
		sql.append("         IFNULL(A.DISCOUNT, CAST(0 AS decimal(15,2))) SUM_DISCOUNT,                                           ");
		sql.append("         IFNULL(A.AMOUNT_PAID, CAST(0 AS decimal(15,2))),                                                     ");
		sql.append("         IFNULL(A.AMOUNT_DEBT, CAST(0 AS decimal(15,2)))                                                     ");
		sql.append(" FROM BIL0101 A WHERE A.HOSP_CODE = :hosp_code                                                                ");
		sql.append(" AND A.INVOICE_NO = :invoice_no AND A.ACTIVE_FLG = 1                                                          ");	
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("invoice_no", invoiceNo);
		List<LoadGridBIL2016U02SumInfo> list = new JpaResultMapper().list(query, LoadGridBIL2016U02SumInfo.class);
		return list;
	}

	@Override
	public BigDecimal getLasteDebtBIL2016U02(String hospCode, String parentInvoiceNo) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT AMOUNT_DEBT	 LATEST_INVOICE             ");          
		sql.append(" FROM BIL0101 WHERE HOSP_CODE = :hosp_code      ");              
		sql.append(" AND ACTIVE_FLG = 1                             ");
		sql.append("  AND PARENT_INVOICE_NO = :parent_invoice_no    ");
		sql.append(" ORDER BY CREATED DESC LIMIT 1					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("parent_invoice_no", parentInvoiceNo);
		List<BigDecimal> result = query.getResultList();
		return result.size() > 0 ? result.get(0) : null;
	}

	@Override
	public BIL2016U02PrintAmountInfo getBIL2016U02PrintMoneyInfo(String hospCode, String parentInvoiceNo, String invoiceNo) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.AMOUNT,                                                                               ");
		sql.append(" A.AMOUNT_PAID,                                                                                 ");
		sql.append(" A.AMOUNT_PAID                                                                                  ");
		sql.append(" + (SELECT IFNULL(SUM(AMOUNT_PAID), CAST(0 AS decimal(15, 2)))                                  ");
		sql.append(" FROM BIL0101                                                                                   ");
		sql.append(" WHERE ACTIVE_FLG = 1                                                                           ");
		sql.append(" AND HOSP_CODE = :hosp_code                                                                     ");
		sql.append(" AND PARENT_INVOICE_NO = :parent_invoice_no                                                     ");
		sql.append(" AND CREATED <                                                                                  ");
		sql.append(" (SELECT CREATED                                                                                ");
		sql.append(" FROM BIL0101                                                                                   ");
		sql.append(" WHERE HOSP_CODE = :hosp_code                                                                   ");
		sql.append(" AND INVOICE_NO = :invoice_no))                                                                 ");
		sql.append(" SUM_AMOUNT_PAID,                                                                               ");
		sql.append(" A.AMOUNT                                                                                       ");
		sql.append(" - A.AMOUNT_PAID                                                                                ");
		sql.append(" - (SELECT IFNULL(SUM(AMOUNT_PAID), CAST(0 AS decimal(15, 2)))                                  ");
		sql.append("         FROM BIL0101                                                                           ");
		sql.append("         WHERE ACTIVE_FLG = 1                                                                   ");
		sql.append("         AND HOSP_CODE = :hosp_code                                                             ");
		sql.append("         AND PARENT_INVOICE_NO = :parent_invoice_no                                             ");
		sql.append("         AND CREATED <                                                                          ");
		sql.append("         (SELECT CREATED                                                                        ");
		sql.append("         FROM BIL0101                                                                           ");
		sql.append("         WHERE HOSP_CODE = :hosp_code                                                           ");
		sql.append("         AND INVOICE_NO = :invoice_no))                                                         ");
		sql.append(" - (SELECT IFNULL(SUM(DISCOUNT), CAST(0 AS decimal(15, 2)))                                     ");
		sql.append("           FROM BIL0101                                                                         ");
		sql.append("           WHERE ACTIVE_FLG = 1                                                                 ");
		sql.append("           AND HOSP_CODE = :hosp_code                                                           ");
		sql.append("            AND PARENT_INVOICE_NO = :parent_invoice_no AND INVOICE_NO = PARENT_INVOICE_NO)      ");
		sql.append(" SUM_AMOUNT_DEBT                                                                                ");
		sql.append(" FROM BIL0101 A                                                                                 ");
		sql.append("  WHERE A.HOSP_CODE = :hosp_code                                                                ");
		sql.append("  AND A.INVOICE_NO = :invoice_no                                                                ");
		sql.append("  AND A.CREATED <=(SELECT B.CREATED                                                             ");
		sql.append("                    FROM BIL0101 B                                                              ");
		sql.append("                   WHERE B.HOSP_CODE = :hosp_code AND B.INVOICE_NO = :invoice_no)				");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("parent_invoice_no", parentInvoiceNo);
		query.setParameter("invoice_no", invoiceNo);
		List<BIL2016U02PrintAmountInfo> list = new JpaResultMapper().list(query, BIL2016U02PrintAmountInfo.class);
		return list.size() > 0 ? list.get(0) : null;
	}
	
}
