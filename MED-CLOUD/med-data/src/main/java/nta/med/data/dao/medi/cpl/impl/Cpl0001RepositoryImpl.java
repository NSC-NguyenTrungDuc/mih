package nta.med.data.dao.medi.cpl.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl0001RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0001U00GrdSlipInfo;

/**
 * @author dainguyen.
 */
public class Cpl0001RepositoryImpl implements Cpl0001RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getCPL0101U00FbxSlipCodeName(String hospCode, String code) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT SLIP_NAME FROM CPL0001 WHERE HOSP_CODE = :hospCode AND SLIP_CODE = :code ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getCPL0101U00FbxSlipCodeComboListItem(String hospCode, String find1, String find2, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT SLIP_CODE																");
		sql.append("	     , SLIP_NAME                                                                ");
		sql.append("	  FROM CPL0001                                                                  ");
		sql.append("	 WHERE HOSP_CODE = :hospCode                                                    ");
		sql.append("	   AND ((SLIP_CODE LIKE IF(:find1 IS NULL , '%',CONCAT('%',:find1,'%')))     	");
		sql.append("	    OR  (SLIP_NAME LIKE IF(:find2 IS NULL , '%',CONCAT('%',:find2,'%'))))    	");
		sql.append("	 ORDER BY SLIP_CODE;                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("find1", find1);
		query.setParameter("find2", find2);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<CPL0001U00GrdSlipInfo> getCPL0001U00GrdSlipInfo(String hospCode, String slipCode) {
		StringBuilder sql = new StringBuilder();            
		
		sql.append("	SELECT A.SLIP_CODE   					  ");
		sql.append("	         , A.SLIP_NAME                    ");
		sql.append("	         , A.SLIP_NAME_RE                 ");
		sql.append("	         , A.JUNDAL_GUBUN                 ");
		sql.append("	      FROM CPL0001 A                      ");
		sql.append("	     WHERE A.HOSP_CODE = :f_hosp_code     ");
		sql.append("	       AND A.SLIP_CODE LIKE :f_slip_code  ");
		sql.append("	     ORDER BY 1                           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_slip_code", "%" + slipCode + "%");
		
		List<CPL0001U00GrdSlipInfo> listResult = new JpaResultMapper().list(query, CPL0001U00GrdSlipInfo.class);
		return listResult;
	}

	@Override
	public String callPrCplBmlUploader(String hospCode, String language,
			String userId, String groupGubun, String parentCode,
			String hangmogCode, Integer serial, String gumsaNameRe,
			String gumsaName, String jlac10Code, String tubeName,
			String keepMeansName, String specimenCode, String specimentName,
			String danui, String menFromStandard, String menToStandard,
			String womenFromStandard, String womenToStandard, String sgCode1,
			String sgCode2, String specimentAmt, Date jukyongDate,
			String detailInfo, String hangmogMarkName, String emergency) {
		StoredProcedureQuery query = entityManager.createStoredProcedureQuery("PR_CPL_BML_UPLOADERS");
		
//		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GROUP_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PARENT_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SERIAL", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUMSA_NAME_RE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUMSA_NAME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JLAC10_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TUBE_NAME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_KEEP_MEANS_NAME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_NAME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DANUI", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MEN_FROM_STANDARD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MEN_TO_STANDARD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_WOMEN_FROM_STANDARD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_WOMEN_TO_STANDARD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SG_CODE1", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SG_CODE2", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_AMT", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_JUKYONG_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DETAIL_INFO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_MARK_NAME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("I_EMERGENCY", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR_CODE", String.class, ParameterMode.INOUT);
		
//		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_GROUP_GUBUN", groupGubun);
		query.setParameter("I_PARENT_CODE", parentCode);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_SERIAL", serial);
		query.setParameter("I_GUMSA_NAME_RE", gumsaNameRe);
		query.setParameter("I_GUMSA_NAME", gumsaName);
		query.setParameter("I_JLAC10_CODE", jlac10Code);
		query.setParameter("I_TUBE_NAME", tubeName);
		query.setParameter("I_KEEP_MEANS_NAME", keepMeansName);
		query.setParameter("I_SPECIMEN_CODE", specimenCode);
		query.setParameter("I_SPECIMEN_NAME", specimentName);
		query.setParameter("I_DANUI", danui);
		query.setParameter("I_MEN_FROM_STANDARD", menFromStandard);
		query.setParameter("I_MEN_TO_STANDARD", menToStandard);
		query.setParameter("I_WOMEN_FROM_STANDARD", womenFromStandard);
		query.setParameter("I_WOMEN_TO_STANDARD", womenToStandard);
		query.setParameter("I_SG_CODE1", sgCode1);
		query.setParameter("I_SG_CODE2", sgCode2);
		query.setParameter("I_SPECIMEN_AMT", specimentAmt);
		query.setParameter("I_JUKYONG_DATE", jukyongDate);
		query.setParameter("I_DETAIL_INFO", detailInfo);
		query.setParameter("I_HANGMOG_MARK_NAME", hangmogMarkName);
		query.setParameter("I_EMERGENCY", emergency);
		
		Boolean isValid = query.execute();
		String errCode = (String)query.getOutputParameterValue("O_ERR_CODE");
		return errCode;
	}
	
}

