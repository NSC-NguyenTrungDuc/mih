package nta.med.data.dao.medi.out.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out0105RepositoryCustom;
import nta.med.data.model.ihis.emr.OCS2015U00GetDataInsPersonInfo;
import nta.med.data.model.ihis.inps.INP1001U01GrdInp1008Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdGongbiListInfo;
import nta.med.data.model.ihis.nuro.PublicInsurance;

/**
 * @author dainguyen.
 */
public class Out0105RepositoryImpl implements Out0105RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ORDERTRANSGrdGongbiListInfo> getORDERTRANSGrdGongbiListInfoCaseEqualOAndN(String hospCode, String bunho, String out1001, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GONGBI_CODE                                                                   ");
		sql.append("      , B.GONGBI_NAME                                                                   ");
		sql.append("      , A.LAST_CHECK_DATE                                                               ");
		sql.append("      , A.BUDAMJA_BUNHO                                                                 ");
		sql.append("      , A.SUGUBJA_BUNHO                                                                 ");
		sql.append("      ,CASE  B.GONGBI_CODE WHEN null THEN 'N' else 'Y' END SELECT_YN                    ");
		sql.append("      , C.PRIORITY                                                                      ");
		sql.append("      , IFNULL(A.IF_VALID_YN, 'Y')                                                      ");
		sql.append("   FROM  OUT0105 A LEFT JOIN OUT1002 C ON C.HOSP_CODE= A.HOSP_CODE                      ");
		sql.append("    AND C.BUNHO = A.BUNHO                                                               ");
		sql.append("    AND C.GONGBI_CODE = A.GONGBI_CODE                                                   ");
		sql.append("    AND C.FKOUT1001 = :f_out1001                                                        ");
		sql.append("        ,BAS0212 B                                                                      ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                                                 ");
		sql.append("    AND A.BUNHO          = :f_bunho                                                     ");
		sql.append("    AND SYSDATE()   BETWEEN A.START_DATE AND IFNULL(A.END_DATE, '9998/12/31')           ");
		sql.append("    AND B.HOSP_CODE      = A.HOSP_CODE AND B.LANGUAGE = :language                       ");
		sql.append("    AND B.GONGBI_CODE    = A.GONGBI_CODE                                                ");
		sql.append("    AND SYSDATE()   BETWEEN B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31')           ");
		sql.append("    ORDER BY SELECT_YN DESC, A.GONGBI_CODE												");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_out1001", out1001);
		query.setParameter("language", language);
		
		List<ORDERTRANSGrdGongbiListInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdGongbiListInfo.class);
		return list;
	}

	@Override
	public List<ORDERTRANSGrdGongbiListInfo> getORDERTRANSGrdGongbiListInfoCaseElseEqualN(String hospCode, String bunho, String out1001, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GONGBI_CODE                                                           ");
		sql.append("      , B.GONGBI_NAME                                                           ");
		sql.append("      , A.LAST_CHECK_DATE                                                       ");
		sql.append("      , A.BUDAMJA_BUNHO                                                         ");
		sql.append("      , A.SUGUBJA_BUNHO                                                         ");
		sql.append("      ,CASE B.GONGBI_CODE WHEN null THEN 'N' ELSE 'Y' END SELECT_YN             ");
		sql.append("      , C.PRIORITY                                                              ");
		sql.append("      , IFNULL(A.IF_VALID_YN, 'Y')                                              ");
		sql.append("   FROM  OUT0105 A LEFT JOIN INP1008 C ON C.HOSP_CODE = A.HOSP_CODE             ");
		sql.append("    AND C.BUNHO = A.BUNHO                                                       ");
		sql.append("    AND C.GONGBI_CODE = A.GONGBI_CODE                                           ");
		sql.append("    AND C.FKINP1002 = :f_pkinp1002                                              ");
		sql.append("        ,BAS0212 B                                                              ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code                                         ");
		sql.append("    AND A.BUNHO          = :f_bunho                                             ");
		sql.append("    AND SYSDATE()   BETWEEN A.START_DATE AND IFNULL(A.END_DATE, '9998/12/31')   ");
		sql.append("    AND B.HOSP_CODE      = A.HOSP_CODE  AND B.LANGUAGE = :language              ");
		sql.append("    AND B.GONGBI_CODE    = A.GONGBI_CODE                                        ");
		sql.append("    AND SYSDATE()   BETWEEN B.START_DATE AND IFNULL(B.END_DATE, '9998/12/31')   ");
		sql.append("  ORDER BY A.GONGBI_CODE														");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_out1001", out1001);
		query.setParameter("language", language);
		
		List<ORDERTRANSGrdGongbiListInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdGongbiListInfo.class);
		return list;
	}

	@Override
	public List<PublicInsurance> getPublicInsurance(String hospCode, String bunho, Double pkout1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.PRIORITY,										");
		sql.append("        IFNULL(C.GONGBI_CODE, ''),						");
		sql.append("        DATE_FORMAT(C.START_DATE, '%Y-%m-%d'),			");
		sql.append("        DATE_FORMAT(C.END_DATE, '%Y-%m-%d'),			");
		sql.append("        IFNULL(C.SUGUBJA_BUNHO, ''),					");
		sql.append("        IFNULL(C.BUDAMJA_BUNHO, '')						");
		sql.append(" FROM OUT1001 A 										");
		sql.append(" LEFT JOIN OUT1002 B ON B.FKOUT1001 = A.PKOUT1001       ");
		sql.append(" LEFT JOIN OUT0105 C ON C.GONGBI_CODE = B.GONGBI_CODE   ");
		sql.append(" WHERE A.HOSP_CODE = :hosp_code							");
		sql.append("   AND B.FKOUT1001 = :pkout1001							");
		sql.append("   AND A.BUNHO     = :bunho								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("pkout1001", pkout1001);
		query.setParameter("bunho", bunho);
		
		List<PublicInsurance> listResult = new JpaResultMapper().list(query, PublicInsurance.class);
		return listResult;
	}
	
	@Override
	public List<OCS2015U00GetDataInsPersonInfo> getOCS2015U00GetDataInsPersonInfo(String hospCode, String patientCode, String firstExaminationDate, String lastExaminationDate, String priority){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUDAMJA_BUNHO, A.SUGUBJA_BUNHO                                                      ");
		sql.append("    FROM     OUT0105 A                                                                       ");
		sql.append("  		JOIN OUT1002 B ON A.GONGBI_CODE = B.GONGBI_CODE AND A.HOSP_CODE = B.HOSP_CODE        ");
		sql.append("  		JOIN OUT1001 C ON B.FKOUT1001 = C.PKOUT1001                                          ");		
		sql.append("   WHERE A.BUNHO = :f_patient_code                                        					 ");
		sql.append("     AND A.HOSP_CODE    = :f_hosp_code                               						 ");
		sql.append("     AND B.PRIORITY     = :f_priority                                                        ");
		
		if (!StringUtils.isEmpty(firstExaminationDate) && !StringUtils.isEmpty(lastExaminationDate)) {
			sql.append("     AND C.NAEWON_DATE >= DATE_FORMAT(:f_first_examination_date,'%Y/%m/%d')                  ");
			sql.append("     AND C.NAEWON_DATE <= DATE_FORMAT(:f_last_examination_date,'%Y/%m/%d')                   ");
		}
		
		sql.append("  ORDER BY C.NAEWON_DATE ASC                                                       			 ");		
		sql.append("  LIMIT 1                                                       						     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_patient_code", patientCode);
		
		if (!StringUtils.isEmpty(firstExaminationDate) && !StringUtils.isEmpty(lastExaminationDate)) {
			query.setParameter("f_first_examination_date", firstExaminationDate);
			query.setParameter("f_last_examination_date", lastExaminationDate);
		}
		
		query.setParameter("f_priority", priority);
		                                                                        
		List<OCS2015U00GetDataInsPersonInfo> list = new JpaResultMapper().list(query, OCS2015U00GetDataInsPersonInfo.class);
		return list;
	}

	@Override
	public List<INP1001U01GrdInp1008Info> getINP1001U01GrdInp1008Info(String hospCode, String language, String bunho,
			String gubun, String fkinp1002, String gubunIpwonDate, String ipwonDate, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'N'																																");
		sql.append("	     , A.GONGBI_CODE																													");
		sql.append("	     , IFNULL(B.GONGBI_NAME, '')																										");
		sql.append("	     , :f_fkinp1002					AS FKINP1002																						");
		sql.append("	     , :f_bunho						AS BUNHO																							");
		sql.append("	     , :f_gubun						AS GUBUN																							");
		sql.append("	     , IFNULL(FN_BAS_LOAD_GUBUN_NAME(:f_gubun, STR_TO_DATE(:f_gubun_ipwon_date, '%Y/%m/%d'), :f_hosp_code), '')							");
		sql.append("	     , :f_gubun_ipwon_date			AS GUBUN_IPWON_DATE																					");
		sql.append("	FROM OUT0105 A																															");
		sql.append("	JOIN BAS0212 B ON A.GONGBI_CODE = B.GONGBI_CODE																							");
		sql.append("	              AND A.START_DATE BETWEEN B.START_DATE AND B.END_DATE																		");
		sql.append("	              AND B.LANGUAGE = :f_language																								");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																										");
		sql.append("	  AND A.BUNHO = :f_bunho																												");
		sql.append("	  AND IFNULL(STR_TO_DATE(:f_gubun_ipwon_date, '%Y/%m/%d'), STR_TO_DATE(:f_ipwon_date, '%Y/%m/%d')) BETWEEN A.START_DATE AND A.END_DATE	");
		sql.append("	ORDER BY A.GONGBI_CODE																													");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_fkinp1002", fkinp1002);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_gubun_ipwon_date", gubunIpwonDate);
		query.setParameter("f_ipwon_date", ipwonDate);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<INP1001U01GrdInp1008Info> lstResult = new JpaResultMapper().list(query, INP1001U01GrdInp1008Info.class);
		return lstResult;
	}
	
	@Override
	public String inp1001U01CheckIsExistCode(String hospCode, String bunho, String gongbiCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT 'Y'																					");
		sql.append("       FROM DUAL																				");
		sql.append("      WHERE EXISTS ( SELECT 'X'																	");
		sql.append("                       FROM OUT0105 A															");
		sql.append("                      WHERE A.HOSP_CODE          = :f_hosp_code									");
		sql.append("                        AND A.BUNHO              = :f_bunho										");
		sql.append("                        AND A.GONGBI_CODE        = :f_gongbi_code								");
		sql.append("                        AND SYSDATE()			  BETWEEN A.START_DATE							");
		sql.append("                                                     AND A.END_DATE)							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("f_hosp_code", hospCode);
	    query.setParameter("f_bunho", bunho);
	    query.setParameter("f_gongbi_code", gongbiCode);
	    List<String> result = query.getResultList();
	 	if(!result.isEmpty()){
	 		return result.get(0);
	    }
		return null; 
	}
	
}

