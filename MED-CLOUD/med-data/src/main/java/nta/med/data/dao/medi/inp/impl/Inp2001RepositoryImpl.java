

package nta.med.data.dao.medi.inp.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inp.Inp2001RepositoryCustom;
import nta.med.data.dao.medi.out.impl.Out0103RepositoryImpl;
import nta.med.data.model.ihis.inps.INP2001U02grdOcs1003Info;
import nta.med.data.model.ihis.inps.INP2001U02layNuGroupInfo;

/**
 * @author dainguyen.
 */
public class Inp2001RepositoryImpl implements Inp2001RepositoryCustom {
	
	private static final Log LOG = LogFactory.getLog(Out0103RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String callPrOutCreateInp2001Temp(String hospCode, Integer pkOcs, String userId) {
		
		LOG.info("[START] callPrOutCreateInp2001Temp pkOcs=" + pkOcs + ", hospCode=" + hospCode 
				+ ", userId=" + userId);
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OUT_CREATE_INP2001_TEMP");
		query.registerStoredProcedureParameter("I_FKOUT1003", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);       
		
		query.setParameter("I_FKOUT1003",pkOcs);
		query.setParameter("I_HOSP_CODE",hospCode);
		query.setParameter("I_USER_ID",userId);
		query.setParameter("O_ERR","");
		
		Boolean isValid = query.execute();
		String ioFlg = (String)query.getOutputParameterValue("O_ERR");
		return ioFlg;
	}

	@Override
	public List<INP2001U02layNuGroupInfo> getListINP2001U02layNuGroupInfo(String hospCode, String language,
			String bunho, String ipwonDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  Z.PKOUT1001																																			");
		sql.append("	       ,Z.GWA_NAME																																			");
		sql.append("	       ,DATE_FORMAT(Z.NAEWON_DATE, '%Y/%m/%d')																												");
		sql.append("	       ,Z.JUBSU_GUBUN																																		");
		sql.append("	  FROM (   																																					");
		sql.append("	        SELECT  A.PKOUT1001                                           								PKOUT1001  												");
		sql.append("	               ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE, :f_hosp_code, :f_language)            	GWA_NAME												");
		sql.append("	               ,A.NAEWON_DATE                                         								NAEWON_DATE												");
		sql.append("	               ,'J'                                                   								JUBSU_GUBUN												");
		sql.append("	        FROM OUT1001 A																																		");
		sql.append("	        JOIN OCS1003 B ON A.HOSP_CODE = B.HOSP_CODE																											");
		sql.append("	                    AND A.BUNHO     = B.BUNHO																												");
		sql.append("	                    AND A.PKOUT1001 = B.FKOUT1001																											");
		sql.append("	        WHERE A.HOSP_CODE = :f_hosp_code																													");
		sql.append("	          AND A.BUNHO     = :f_bunho																														");
		sql.append("	          AND A.NAEWON_DATE  BETWEEN  DATE_ADD(STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d'), INTERVAL -1 DAY) AND STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d')			");
		sql.append("	        UNION 																																				");
		sql.append("	        SELECT  MAX(A.PKOUT1001)																															");
		sql.append("	               ,FN_BAS_LOAD_GWA_NAME(MAX(A.GWA), MAX(A.NAEWON_DATE), :f_hosp_code, :f_language) GWA_NAME   													");
		sql.append("	               ,MAX(A.NAEWON_DATE)                                                              NAEWON_DATE													");
		sql.append("	               ,'R'                                                                             JUBSU_GUBUN													");
		sql.append("	        FROM OUT1001 A   																																	");
		sql.append("	        JOIN OCS1003 B ON A.HOSP_CODE = B.HOSP_CODE																											");
		sql.append("	                      AND A.PKOUT1001 = B.FKOUT1001																											");
		sql.append("	        WHERE A.HOSP_CODE     = :f_hosp_code																												");
		sql.append("	          AND  A.BUNHO        = :f_bunho																													");
		sql.append("	          AND  A.NAEWON_DATE  < DATE_ADD(STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d'), INTERVAL -1 DAY)															");
		sql.append("	          AND  B.RESER_DATE   >= STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d')																						");
		sql.append("	          AND  B.DC_YN ='N'																																	");
		sql.append("	          AND  B.NALSU > 0 ) Z																																");
		sql.append("	WHERE Z.PKOUT1001 IS NOT NULL																																");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		List<INP2001U02layNuGroupInfo> lstResult = new JpaResultMapper().list(query, INP2001U02layNuGroupInfo.class);
		return lstResult;
	}

	@Override
	public String getINP2001U02setIconCnt(String hospCode, String bunho, Double pkout1001, Date ipwonDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CAST(COUNT(*) AS CHAR)																							");
		sql.append("	FROM OUT1001 A   																										");
		sql.append("	JOIN OCS1003 B ON A.HOSP_CODE        = B.HOSP_CODE																		");
		sql.append("	              AND A.PKOUT1001        = B.FKOUT1001																		");
		sql.append("	              AND A.NAEWON_DATE      = B.ORDER_DATE																		");
		sql.append("	LEFT JOIN OCS0103 C ON B.HOSP_CODE    = C.HOSP_CODE																		");
		sql.append("	                   AND B.HANGMOG_CODE = C.HANGMOG_CODE																	");
		sql.append("	                   AND B.ORDER_DATE BETWEEN C.START_DATE AND IFNULL(C.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))	");
		sql.append("	LEFT JOIN OCS0132 D ON B.HOSP_CODE = D.HOSP_CODE																		");
		sql.append("	                   AND SUBSTR(B.ORDER_GUBUN, 2, 1) = D.CODE																");
		sql.append("	                   AND D.CODE_TYPE = 'ORDER_GUBUN_BAS' 																	");
		sql.append("	LEFT JOIN OCS0116 E ON B.HOSP_CODE = E.HOSP_CODE																		");
		sql.append("	                   AND B.SPECIMEN_CODE = E.SPECIMEN_CODE																");
		sql.append("	WHERE A.HOSP_CODE        = :f_hosp_code																					");
		sql.append("	  AND A.BUNHO            = :f_bunho																						");
		sql.append("	  AND A.PKOUT1001        = :f_pkout1001																					");
		sql.append("	  AND A.NAEWON_DATE      = :f_ipwon_date																				");
		sql.append("	  AND IFNULL(B.DISPLAY_YN , 'Y') = 'Y'																					");
		sql.append("	  AND IFNULL(B.DC_YN,'N')        = 'N'																					");
		sql.append("	  AND IFNULL(B.MUHYO,'N')        = 'N'																					");
		sql.append("	  AND IFNULL(B.IF_DATA_SEND_YN, 'N' ) = 'Y'																				");
		sql.append("	  AND IFNULL(B.SUNAB_YN, 'N')         = 'Y'																				");
		sql.append("	  AND B.NALSU >= 0     																									");
		sql.append("	ORDER BY B.SEQ																											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkout1001", pkout1001);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		List<String> lstResult = query.getResultList();
		return lstResult.get(0);
	}
	
	public List<INP2001U02grdOcs1003Info> getINP2001U02grdOcs1003Info(String hospCode, String jubsuGubun, String pkOut1001, String ipwonDate
			, String kaikeiYn, String bunho, String language, Integer startNum, Integer offset){

		StringBuilder sql = new StringBuilder();	
		
		if(jubsuGubun.equals("R")){	
			sql.append("   SELECT    A.PKOUT1001                                           PKOUT1001					");
			sql.append("           , B.PKOCS1003                                           PKOCS1003 					");
			sql.append("           , IFNULL(D.CODE_NAME, 'Etc')                            ORDER_GUBUN_NAME				");
			sql.append("           , B.HANGMOG_CODE                                        HANGMOG_CODE					");
			sql.append("           , C.HANGMOG_NAME                                        HANGMOG_NAME					");
			sql.append("           , CAST(B.SURYANG AS CHAR)                               SURYANG						");
			sql.append("           , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI, B.HOSP_CODE, :f_language)			");
			sql.append("                                                                   ORD_DANUI_NAME				");
			sql.append("           , B.DV_TIME                                             DV_TIME						");
			sql.append("           , CAST(B.DV AS CHAR)                                    DV							");
			sql.append("           , CAST(B.NALSU AS CHAR)                                 NALSU						");
			sql.append("           , IFNULL(E.SPECIMEN_NAME, '')                           SPECIMEN_NAME				");
			sql.append("           , 'N'                                                   SELECT_YN					");
			sql.append("           , SUBSTRING(B.ORDER_GUBUN, 2, 1)                        ORDER_GUBUN_BAS				");
			sql.append("           , IFNULL(B.SUNAB_YN, 'N')                               SUNAB_YN						");
			sql.append("       FROM OCS1003 B																			");
			sql.append("            JOIN OUT1001 A 																		");
			sql.append("   			  ON A.HOSP_CODE     	  = B.HOSP_CODE												");
			sql.append("      		 AND A.PKOUT1001     	  = B.FKOUT1001												");
			sql.append("      		 AND A.BUNHO         	  = :f_bunho												");
			sql.append("      		 AND A.PKOUT1001     	  = :f_pkout1001											");
			sql.append("      		 AND A.NAEWON_DATE   	  < DATE_ADD(STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d'), INTERVAL -1 DAY)");
			sql.append("    	LEFT JOIN OCS0103 C																		");
			sql.append("   			  ON C.HOSP_CODE     	  = B.HOSP_CODE												");
			sql.append("      		 AND C.HANGMOG_CODE  	  = B.HANGMOG_CODE											");
			sql.append("    	LEFT JOIN OCS0132 D																		");
			sql.append("   		  	  ON D.HOSP_CODE     	  = B.HOSP_CODE												");
			sql.append("      		 AND D.CODE_TYPE     	  = 'ORDER_GUBUN_BAS'										");
			sql.append("      		 AND D.CODE          	  = SUBSTRING(B.ORDER_GUBUN, 2, 1)							");
			sql.append("    	LEFT JOIN OCS0116 E																		");
			sql.append("   			  ON E.HOSP_CODE     	  = B.HOSP_CODE												");
			sql.append("      		 AND E.SPECIMEN_CODE 	  = B.SPECIMEN_CODE											");
			sql.append("       WHERE B.HOSP_CODE              = :f_hosp_code											");
			sql.append("         AND B.DC_YN                  = 'N'														");
			sql.append("         AND B.NALSU                  > 0														");
			sql.append("         AND B.RESER_DATE             >= :f_ipwon_date											");
			sql.append("         AND B.ORDER_DATE             BETWEEN C.START_DATE										");
			sql.append("                                          AND IFNULL(C.END_DATE, '9999/12/31')					");
			sql.append("       ORDER BY B.SEQ																			");
			
			if(startNum != null && offset !=null){
				sql.append(" LIMIT :startNum, :offset																	");
			}
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_language", language);
			query.setParameter("f_bunho", bunho);
			query.setParameter("f_pkout1001", pkOut1001);
			query.setParameter("f_ipwon_date", ipwonDate);
			
			if(startNum != null && offset !=null){
				query.setParameter("startNum", startNum);
				query.setParameter("offset", offset);
			}
			
			List<INP2001U02grdOcs1003Info> list = new JpaResultMapper().list(query, INP2001U02grdOcs1003Info.class);
			return list;
		
		}else{
			sql.append("   SELECT    A.PKOUT1001                                           PKOUT1001					");
			sql.append("           , B.PKOCS1003                                           PKOCS1003					");
			sql.append("           , IFNULL(D.CODE_NAME, 'Etc')                            ORDER_GUBUN_NAME				");
			sql.append("           , B.HANGMOG_CODE                                        HANGMOG_CODE					");
			sql.append("           , C.HANGMOG_NAME                                        HANGMOG_NAME					");
			sql.append("           , CAST(B.SURYANG AS CHAR)                               SURYANG						");
			sql.append("           , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI, B.HOSP_CODE, :f_language)			");
			sql.append("                                                                   ORD_DANUI_NAME				");
			sql.append("           , B.DV_TIME                                             DV_TIME						");
			sql.append("           , CAST(B.DV AS CHAR)                                    DV							");
			sql.append("           , CAST(B.NALSU AS CHAR)                                 NALSU						");
			sql.append("           , IFNULL(E.SPECIMEN_NAME, '')                           SPECIMEN_NAME				");
			sql.append("           , 'N'                                                   SELECT_YN					");
			sql.append("           , SUBSTRING(B.ORDER_GUBUN, 2, 1)                        ORDER_GUBUN_BAS				");
			sql.append("           , IFNULL(B.SUNAB_YN, 'N')                               SUNAB_YN						");
			sql.append("       FROM  OCS1003 B																			");
			sql.append("             JOIN OUT1001 A																		");
			sql.append("               ON A.HOSP_CODE       = B.HOSP_CODE												");
			sql.append("              AND A.BUNHO           = :f_bunho													");
			sql.append("              AND A.NAEWON_DATE     = B.ORDER_DATE												");
			sql.append("              AND A.PKOUT1001       = B.FKOUT1001												");
			sql.append("              AND A.PKOUT1001       = :f_pkout1001												");
			sql.append("              AND A.NAEWON_DATE     = :f_ipwon_date												");
			sql.append("        LEFT JOIN OCS0103 C																		");
			sql.append("               ON C.HOSP_CODE       = B.HOSP_CODE												");
			sql.append("              AND C.HANGMOG_CODE    = B.HANGMOG_CODE											");
			sql.append("        LEFT JOIN OCS0132 D																		");
			sql.append("               ON D.HOSP_CODE       = B.HOSP_CODE												");
			sql.append("              AND D.CODE_TYPE       = 'ORDER_GUBUN_BAS'											");
			sql.append("              AND D.CODE            = SUBSTRING(B.ORDER_GUBUN, 2, 1)							");
			sql.append("        LEFT JOIN OCS0116 E																		");
			sql.append("               ON E.HOSP_CODE       = B.HOSP_CODE												");
			sql.append("              AND E.SPECIMEN_CODE   = B.SPECIMEN_CODE											");
			sql.append("     WHERE B.HOSP_CODE              = :f_hosp_code												");
			sql.append("       AND B.NALSU                  >= 0														");
			sql.append("       AND IFNULL(B.DC_YN, 'N')     = 'N'														");
			sql.append("       AND IFNULL(B.DISPLAY_YN, 'Y')= 'Y'														");
			sql.append("       AND (																					");
			sql.append("              (IFNULL(B.INSTEAD_YN, 'N')   = 'N'												");
			sql.append("           AND IFNULL(B.MUHYO, 'N')        = 'N')												");
			sql.append("           OR  IFNULL(B.INSTEAD_YN, 'N')   = 'Y'												");
			sql.append("            )																					");
			sql.append("       AND IFNULL(B.IF_DATA_SEND_YN, 'N')  = :f_kaikei_yn										");
			sql.append("       AND IFNULL(B.SUNAB_YN, 'N')         = :f_kaikei_yn										");
			sql.append("       AND B.ORDER_DATE             BETWEEN C.START_DATE										");
			sql.append("                                    AND IFNULL(C.END_DATE, '9999/12/31')						");
			sql.append("     ORDER BY B.SEQ																				");			
			
			if(startNum != null && offset !=null){
				sql.append(" LIMIT :startNum, :offset																	");
			}
			
			Query query = entityManager.createNativeQuery(sql.toString());
			query.setParameter("f_hosp_code", hospCode);
			query.setParameter("f_language", language);
			query.setParameter("f_bunho", bunho);
			query.setParameter("f_pkout1001", pkOut1001);
			query.setParameter("f_ipwon_date", ipwonDate);
			query.setParameter("f_kaikei_yn", kaikeiYn);
			
			if(startNum != null && offset !=null){
				query.setParameter("startNum", startNum);
				query.setParameter("offset", offset);
			}
			
			List<INP2001U02grdOcs1003Info> list = new JpaResultMapper().list(query, INP2001U02grdOcs1003Info.class);
			return list;
		}
	}

	@Override
	public String callPrOcsTransOrder(String hospCode, String jobGubun, double pkInp1001, double pkOcs1003,
			String userId) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OCS_TRANS_ORDER");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JOB_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKINP1001", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PKOCS1003", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR", String.class, ParameterMode.INOUT);       
		
		query.setParameter("I_HOSP_CODE",hospCode);
		query.setParameter("I_JOB_GUBUN",jobGubun);
		query.setParameter("I_PKINP1001",pkInp1001);
		query.setParameter("I_PKOCS1003",pkOcs1003);
		query.setParameter("I_USER_ID",userId);
		query.setParameter("IO_ERR","");
		
		Boolean isValid = query.execute();
		String ioFlg = (String)query.getOutputParameterValue("IO_ERR");
		return ioFlg;
	}
	
}

