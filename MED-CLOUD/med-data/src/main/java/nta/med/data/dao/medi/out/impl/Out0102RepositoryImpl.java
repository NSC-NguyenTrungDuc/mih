package nta.med.data.dao.medi.out.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out0102RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.InsuranceProviderInfo;
import nta.med.data.model.ihis.inps.INP1001U01FwkGubunInfo;
import nta.med.data.model.ihis.nuro.CompanyInsurance;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetTypeInfo;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdHokenInfo;
import nta.med.data.model.ihis.system.DetailPaInfoFormGridInsureInfo;

/**
 * @author dainguyen.
 */
public class Out0102RepositoryImpl implements Out0102RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DetailPaInfoFormGridInsureInfo> getDetailPaInfoFormGridInsure(String hospCode, String patientCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.START_DATE                                                                                                       ");
		sql.append("       ,FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, DATE_FORMAT(SYSDATE(),'%Y/%m/%d'), :hospCode)  GUBUN_NAME                          ");
		sql.append("       ,A.END_DATE                                                                                                         ");
		sql.append("       ,CONCAT(A.JOHAP,' ', IFNULL(B.JOHAP_NAME,' ')) JOHAP_NAME                                                           ");
		sql.append("       ,A.GAEIN                                                                                                            ");
		sql.append("       ,A.GAEIN_NO                                                                                                         ");
		sql.append("       ,A.LAST_CHECK_DATE                                                                                                  ");
		sql.append(" FROM  BAS0110 B LEFT OUTER JOIN OUT0102 A                                                                                 ");
		sql.append("    ON B.JOHAP = A.JOHAP   AND B.LANGUAGE = :language                                                                      ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                                                                             ");
		sql.append("   AND A.BUNHO = :patientCode                                                                                              ");
		sql.append("   AND IFNULL(DATE_FORMAT(A.END_DATE, '%Y/%m/%d'), DATE_FORMAT(SYSDATE(),'%Y/%m/%d')) >= DATE_FORMAT(SYSDATE(),'%Y/%m/%d') ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("language", language);

		List<DetailPaInfoFormGridInsureInfo> list = new JpaResultMapper().list(query, DetailPaInfoFormGridInsureInfo.class);

		return list;
	}
	
	@Override
	public String getJohapByHospCodeAndBunho(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT JOHAP 																												");
		sql.append(" FROM OUT0102 A																												");
		sql.append(" WHERE A.HOSP_CODE = :hospCode																								");
		sql.append("   AND A.BUNHO = :bunho																										");
		sql.append("   AND IFNULL(DATE_FORMAT(A.END_DATE, '%Y/%m/%d'), DATE_FORMAT(SYSDATE(),'%Y/%m/%d')) >= DATE_FORMAT(SYSDATE(),'%Y/%m/%d')	");
		sql.append("   AND IFNULL(DATE_FORMAT(A.START_DATE, '%Y/%m/%d'), DATE_FORMAT(SYSDATE(),'%Y/%m/%d')) <= DATE_FORMAT(SYSDATE(),'%Y/%m/%d')");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		
		List<String> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		
		return null;
	}
	
	@Override
	public List<NuroOUT1001U01GetTypeInfo> getNuroOUT1001U01GetTypeInfo(String hospCode, String bunho, String naewonDate, String find1, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.GUBUN                                                                 ");
		sql.append("     , B.GUBUN_NAME                                                            ");
		sql.append("     , DATE_FORMAT(A.LAST_CHECK_DATE, '%Y/%m/%d')                              ");
		sql.append("     , IFNULL(B.GONGBI_YN, 'N') GONGBI_YN                                      ");
		sql.append("  FROM BAS0210 B                                                               ");
		sql.append("     , OUT0102 A                                                               ");
		sql.append(" WHERE A.HOSP_CODE    = :hospCode                                              ");
		sql.append("   AND A.BUNHO        = :bunho                                                 ");
		sql.append("   AND IFNULL(:naewonDate, SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE      ");
		sql.append("   AND B.GUBUN        = A.GUBUN  AND B.LANGUAGE = :language                    ");
		sql.append("   AND IFNULL(:naewonDate, SYSDATE()) BETWEEN B.START_DATE AND B.END_DATE      ");
		sql.append("   AND B.GUBUN_NAME   LIKE :find1                                              ");
		sql.append("   AND A.START_DATE = (SELECT MAX(AA.START_DATE) START_DATE                    ");
		sql.append("                         FROM OUT0102 AA                                       ");
		sql.append("                        WHERE AA.HOSP_CODE = A.HOSP_CODE                       ");
		sql.append("                          AND AA.GUBUN = A.GUBUN                               ");
		sql.append("                          AND AA.BUNHO = A.BUNHO)                              ");
		sql.append("ORDER BY A.GUBUN DESC                                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("naewonDate", naewonDate);
		query.setParameter("find1", find1 + "%");
		query.setParameter("language", language);

		List<NuroOUT1001U01GetTypeInfo> list = new JpaResultMapper().list(query, NuroOUT1001U01GetTypeInfo.class);

		return list;
	}
	
	@Override
	public String getNuroOUT0101U02GetY(String hospCode, String bunho,
			String gubun1, Date startDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT 'Y'					");
		sql.append(" FROM OUT0102                       ");
		sql.append(" WHERE HOSP_CODE  = :hospCode    ");
		sql.append("   AND BUNHO      = :bunho        ");
		sql.append("   AND GUBUN      = :gubun1       ");
		sql.append("   AND START_DATE = :startDate   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("gubun1", gubun1);
		query.setParameter("startDate", startDate);
		
		List<String> listResult = query.getResultList();
		if(listResult != null && !listResult.isEmpty()){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public List<ORDERTRANSGrdHokenInfo> getORDERTRANSGrdHokenInfo(String hospCode, String actingDate, String gubun, String bunho, String sendYn) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GUBUN                                                                                                                                                     ");
		sql.append("        ,FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, :f_acting_date, :f_hosp_code)  GUBUN_NAME                                                                                  ");
		sql.append("        ,A.START_DATE                                                                                                                                               ");
		sql.append("        ,IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31', '%Y/%m/%d'))                                                                                                  ");
		sql.append("        , CASE A.JOHAP WHEN '9999' THEN null ELSE A.JOHAP END                                                                                                       ");
		sql.append("        ,CASE WHEN A.GUBUN = :f_gubun THEN 'Y' ELSE 'N' END SELECT_YN                                                                                               ");
		sql.append("    FROM OUT0102 A                                                                                                                                                  ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                                 ");
		sql.append("     AND A.BUNHO     = :f_bunho                                                                                                                                     ");
		sql.append("     AND (                                                                                                                                                          ");
		sql.append("          (:f_send_yn != 'Y'                                                                                                                                        ");
		sql.append("           AND A.GUBUN LIKE '%')                                                                                                                                    ");
		sql.append("          OR                                                                                                                                                        ");
		sql.append("          (:f_send_yn = 'Y'                                                                                                                                         ");
		sql.append("           AND A.GUBUN = :f_gubun)                                                                                                                                  ");
		sql.append("         )                                                                                                                                                          ");
		sql.append("     AND A.START_DATE = (SELECT MAX(Z.START_DATE)                                                                                                                   ");
		sql.append("                           FROM OUT0102 Z                                                                                                                           ");
		sql.append("                          WHERE Z.HOSP_CODE  = A.HOSP_CODE                                                                                                          ");
		sql.append("                            AND Z.BUNHO      = A.BUNHO                                                                                                              ");
		sql.append("                                              AND Z.GUBUN      = A.GUBUN                                                                                            ");
		sql.append("                            AND STR_TO_DATE(:f_acting_date, '%Y/%m/%d') BETWEEN Z.START_DATE AND IFNULL(Z.END_DATE, STR_TO_DATE('99981231', '%Y%m%d'))              ");
		sql.append("                      )                                                                                                                                             ");
		sql.append("    ORDER BY  SELECT_YN DESC,  A.GUBUN																																");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_acting_date", actingDate);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_send_yn", sendYn);
		List<ORDERTRANSGrdHokenInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdHokenInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getORDERTRANSFwkFind(String hospCode,
			String bunho, String actingDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GUBUN                                                                                                                                             ");
		sql.append("    , FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, :f_acting_date, :f_hosp_code)  GUBUN_NAME                                                                             ");
		sql.append("      FROM OUT0102 A                                                                                                                                        ");
		sql.append("     WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                       ");
		sql.append("       AND A.BUNHO     = :f_bunho                                                                                                                           ");
		sql.append("       AND A.START_DATE = (SELECT MAX(Z.START_DATE)                                                                                                         ");
		sql.append("                               FROM OUT0102 Z                                                                                                               ");
		sql.append("                               WHERE Z.HOSP_CODE   = A.HOSP_CODE                                                                                            ");
		sql.append("                               AND Z.BUNHO = A.BUNHO                                                                                                        ");
		sql.append("                                 AND Z.GUBUN = A.GUBUN                                                                                                      ");
		sql.append("                               AND STR_TO_DATE(:f_acting_date, '%Y/%m/%d') BETWEEN Z.START_DATE AND IFNULL(Z.END_DATE, STR_TO_DATE('99981231', '%Y%m%d')))  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_acting_date", actingDate);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<CompanyInsurance> getCompanyInsurance(String hospCode, String bunho, Double pkout1001) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IF(N.GUBUN IS NULL OR N.GUBUN = '', 'XX', N.GUBUN),					");
		sql.append("        IF(N.JOHAP IS NULL OR N.JOHAP = '', '', N.JOHAP),				");
		sql.append("        DATE_FORMAT(IFNULL(N.START_DATE, SYSDATE()), '%Y-%m-%d'),			");
		sql.append("        IFNULL(DATE_FORMAT(N.END_DATE, '%Y/%m/%d'), '9999-12-31'),			");
		sql.append("        IFNULL(N.GAEIN, ''),												");
		sql.append("        IFNULL(N.GAEIN_NO, ''),												");
		sql.append("        IFNULL(N.BON_GA_GUBUN, '')											");
		sql.append(" FROM OUT0102 N  															");
		sql.append(" JOIN OUT1001 M ON N.BUNHO = M.BUNHO 										");
		sql.append("               AND N.HOSP_CODE = M.HOSP_CODE 								");
		sql.append("               AND N.GUBUN = M.GUBUN      									");
		sql.append("               AND M.PKOUT1001 = :pkout1001 								");
		sql.append(" WHERE N.BUNHO = :bunho                                                     ");
		sql.append("   AND N.HOSP_CODE = :hosp_code                                             ");
		sql.append("   AND SYSDATE() BETWEEN N.START_DATE AND N.END_DATE");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("pkout1001", pkout1001);
		query.setParameter("bunho", bunho);
		
		List<CompanyInsurance> listResult = new JpaResultMapper().list(query, CompanyInsurance.class);
		return listResult;
	}
	
	@Override
	public List<InsuranceProviderInfo> getOCS2015U00GetDataInsProviderInfo(String hospCode, String patientCode, String firstExaminationDate, String lastExaminationDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.JOHAP,																			");
		sql.append("        A.GAEIN,																			");
		sql.append("        A.GAEIN_NO,																			");
		sql.append("        A.END_DATE,																			");
		sql.append("        A.PINAME,																			");
		sql.append("        A.CHUIDUK_DATE,																		");
		sql.append("        B.JOHAP_NAME																		");
		sql.append(" FROM OUT0102 A  																			");
		sql.append(" JOIN BAS0110 B ON A.JOHAP = B.JOHAP 														");
		sql.append(" JOIN OUT1001 C ON C.GUBUN = A.GUBUN AND C.BUNHO = A.BUNHO AND C.HOSP_CODE = A.HOSP_CODE	");
		sql.append("   WHERE A.BUNHO = :f_patient_code                                          				");
		sql.append("     AND A.HOSP_CODE    = :f_hosp_code                               	    				");
		
		if (!StringUtils.isEmpty(firstExaminationDate) && !StringUtils.isEmpty(lastExaminationDate)) {
			sql.append("     AND C.NAEWON_DATE >= DATE_FORMAT(:f_first_examination_date,'%Y/%m/%d') 			");
			sql.append("     AND C.NAEWON_DATE <= DATE_FORMAT(:f_last_examination_date,'%Y/%m/%d')  			");
		}
		
		sql.append("  ORDER BY A.END_DATE DESC                                              					");		
		sql.append("  LIMIT 1                                                       		    				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_patient_code", patientCode);
		if (!StringUtils.isEmpty(firstExaminationDate) && !StringUtils.isEmpty(lastExaminationDate)) {
			query.setParameter("f_first_examination_date", firstExaminationDate);
			query.setParameter("f_last_examination_date", lastExaminationDate);
		}
		
		List<InsuranceProviderInfo> listResult = new JpaResultMapper().list(query, InsuranceProviderInfo.class);
		return listResult;
	}

	@Override
	public List<INP1001U01FwkGubunInfo> getINP1001U01FwkGubunInfo(String hospCode, String language, String bunho,
			String naewonDate, String find1) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.GUBUN																																	");
		sql.append("	     , IFNULL(B.GUBUN_NAME, '')																													");
		sql.append("	     , DATE_FORMAT(SYSDATE(), '%Y/%m/%d')																										");
		sql.append("	     , IFNULL(B.GONGBI_YN, 'N') GONGBI_YN																										");
		sql.append("	     , IFNULL(B.JOHAP_GUBUN, '')																												");
		sql.append("	     , IFNULL(FN_BAS_LOAD_JOHAP_NAME(A.GUBUN, B.JOHAP_GUBUN,IFNULL(STR_TO_DATE(:f_naewon_date, '%Y/%m/%d'), CURRENT_DATE()), :f_language), '')	");
		sql.append("	FROM OUT0102 A 																																	");
		sql.append("	JOIN BAS0210 B ON A.GUBUN = B.GUBUN																												");
		sql.append("	              AND B.LANGUAGE = :f_language																										");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code																												");
		sql.append("	 AND A.BUNHO = :f_bunho																															");
		sql.append("	 AND IFNULL(STR_TO_DATE(:f_naewon_date, '%Y/%m/%d'), CURRENT_DATE()) BETWEEN A.START_DATE AND A.END_DATE										");
		sql.append("	 AND IFNULL(STR_TO_DATE(:f_naewon_date, '%Y/%m/%d'), CURRENT_DATE()) BETWEEN B.START_DATE AND B.END_DATE 										");
		sql.append("	 AND B.GUBUN_NAME LIKE :f_find1																													");
		sql.append("	ORDER BY A.GUBUN DESC																															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_find1", find1 + "%");
		
		List<INP1001U01FwkGubunInfo> listResult = new JpaResultMapper().list(query, INP1001U01FwkGubunInfo.class);
		return listResult;
	}
}

