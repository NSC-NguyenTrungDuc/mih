package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0150RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0150Q00GridOCS0150Info;

/**
 * @author dainguyen.
 */
public class Ocs0150RepositoryImpl implements Ocs0150RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS0150Q00GridOCS0150Info> getOCS0150Q00GridOCS0150Info(String hospCode, String language, String doctor, String gwa, String ioGubun, Date orderDate){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.DOCTOR                                              DOCTOR                                ");
		sql.append("        ,IF(A.DOCTOR = '%', FN_ADM_MSG('221',:f_language),                                          ");
		sql.append("               FN_ADM_LOAD_USER_NAME(A.DOCTOR, :f_hosp_code)) DOCTOR_NAME                           ");
		sql.append("        ,A.GWA                                                GWA                                   ");
		sql.append("        ,IF(A.GWA = '%', FN_ADM_MSG('221',:f_language),                                             ");
		sql.append("        FN_BAS_LOAD_GWA_NAME(A.GWA, :f_order_date, :f_hosp_code, :f_language))        GWA_NAME      ");                   
		sql.append("        ,A.IO_GUBUN                                           IO_GUBUN                              ");
		sql.append("        ,A.HOSP_CODE                                          HOSP_CODE                             ");
		sql.append("        ,IFNULL(A.DRG_PRT_YN, 'N')                            DRG_PRT_YN                            ");
		sql.append("        ,IFNULL(A.XRT_PRT_YN, 'N')                            XRT_PRT_YN                            ");
		sql.append("        ,IFNULL(A.RESER_PRT_YN, 'N')                          RESER_PRT_YN                          ");
		sql.append("        ,IFNULL(A.VITALSIGNS_POP_YN, 'N')                     VITALSIGNS_POP_YN                     ");
		sql.append("        ,IFNULL(A.ALLERGY_POP_YN, 'N')                        ALLERGY_POP_YN                        ");
		sql.append("        ,IFNULL(A.SPECIALWRITE_POP_YN, 'N')                   SPECIALWRITE_POP_YN                   ");
		sql.append("        ,IFNULL(A.EMR_POP_YN, 'N')                            EMR_POP_YN                            ");
		sql.append("        ,IFNULL(A.DO_ORDER_POP_YN, 'N')                       DO_ORDER_POP_YN                       ");
		sql.append("        ,IFNULL(A.SENTOU_SEARCH_YN, 'N')                      SENTOU_SEARCH_YN                      ");
		sql.append("        ,IFNULL(A.ORDER_LABEL_PRT_YN, 'N')                    ORDER_LABEL_PRT_YN                    ");
		sql.append("        ,IFNULL(A.GENERAL_DISP_YN,  'N')                      GENERAL_DISP_YN                       ");
		sql.append("        ,IFNULL(A.SAME_NAME_CHECK_YN,  'N')                   SAME_NAME_CHECK_YN                    ");
		sql.append("        ,IFNULL(A.CHECKING_DRUG_YN,  'N')                     CHECKING_DRUG_YN                      ");
		sql.append("        ,A.POTION_DRUG_YN                                          				    				");
		sql.append("        ,A.DISEASE_UNREGISTERED_YN                                         	 	    				");
		sql.append("        ,A.INFECTION_POP_YN                                           								");
		sql.append("   FROM OCS0150 A                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                ");
		sql.append("    AND A.DOCTOR   LIKE :f_doctor                                                                   ");
		sql.append("    AND A.GWA      LIKE :f_gwa                                                                      ");
		sql.append("    AND A.IO_GUBUN LIKE :f_io_gubun                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_order_date", orderDate);
		
		List<OCS0150Q00GridOCS0150Info> list = new JpaResultMapper().list(query, OCS0150Q00GridOCS0150Info.class);
		
		return list;
	}

	@Override
	public String getOcsOrderBizGetUserOptionInfo(String hospCode,String doctor, String gwa,String keyword, String gubun) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_USER_OPTION_INFO(:f_hosp_code,:f_doctor, :f_gwa, :f_keyword, :f_io_gubun) result ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_keyword", keyword);
		query.setParameter("f_io_gubun", gubun);
		List<String> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public String callFnOcsUserOptionInfo(String hospCode, String doctor,
			String gwa, String keyword, String ioGubun) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_OCS_USER_OPTION_INFO(:hospCode, :doctor, :gwa, :keyword, :ioGubun)");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("doctor", doctor);
		query.setParameter("gwa", gwa);
		query.setParameter("keyword", keyword);
		query.setParameter("ioGubun", ioGubun);
		
		List<String> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
}

