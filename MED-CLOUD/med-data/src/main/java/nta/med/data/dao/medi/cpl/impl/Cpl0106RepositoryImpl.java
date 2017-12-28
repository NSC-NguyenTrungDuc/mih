package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl0106RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL0106U00GrdListItemInfo;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Cpl0106RepositoryImpl implements Cpl0106RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CPL0106U00GrdListItemInfo> getCPL0106U00GrdListItemInfo(String hospCode, String language, String codeType,
			String hangmogCode, String specimenCode, String emergency, String groupGubun) {
		StringBuilder sql= new StringBuilder();
		sql.append("   SELECT A.GROUP_GUBUN                                      ");
		sql.append("        , A.HANGMOG_CODE                                     ");
		sql.append("        , A.SPECIMEN_CODE                                    ");
		sql.append("        , A.EMERGENCY                                        ");
		sql.append("        , A.SUB_HANGMOG_CODE                                 ");
		sql.append("        , A.SUB_SPECIMEN_CODE                                ");
		sql.append("        , C.CODE_NAME                        SPECIMEN_NAME   ");
		sql.append("        , A.SUB_EMERGENCY                                    ");
		sql.append("        , IFNULL(B.GUMSA_NAME_RE, B.GUMSA_NAME) GUMSA_NAME   ");
		sql.append("        , A.CONTINUE_YN                                      ");
		sql.append("        , B.GROUP_GUBUN  GROUP_GUBUN_B                       ");
		sql.append("        , D.SG_CODE                                          ");
		sql.append("   FROM  CPL0106 A                                           ");
		sql.append("   LEFT JOIN CPL0109 C                                       ");
		sql.append("     ON  A.HOSP_CODE = C.HOSP_CODE                           ");
		sql.append("     AND A.SUB_SPECIMEN_CODE = C.CODE                        ");
		sql.append("     AND C.CODE_TYPE = :code_type                            ");
		sql.append("   LEFT JOIN CPL0101 B ON A.HOSP_CODE = B.HOSP_CODE          ");
		sql.append("    AND A.SUB_HANGMOG_CODE       = B.HANGMOG_CODE            ");
		sql.append("    AND A.SUB_SPECIMEN_CODE      = B.SPECIMEN_CODE           ");
		sql.append("    AND A.SUB_EMERGENCY          = B.EMERGENCY               ");
		sql.append("   LEFT JOIN OCS0103 D                                       ");
		sql.append("    ON D.HOSP_CODE = B.HOSP_CODE                             ");
		sql.append("    AND D.HANGMOG_CODE = B.HANGMOG_CODE                      ");
		sql.append("  WHERE A.HOSP_CODE              = :hospCode                ");
		sql.append("    AND C.LANGUAGE = :language                               ");
		if (!StringUtils.isEmpty(hangmogCode)) {
			sql.append("  AND A.HANGMOG_CODE           = :hangmog_code             ");
		}
		if (!StringUtils.isEmpty(specimenCode)) {
			sql.append("  AND A.SPECIMEN_CODE          = :specimen_code            ");
		}
		if (!StringUtils.isEmpty(emergency)) {
			sql.append("  AND A.EMERGENCY              = :emergency                ");
		}
		if (!StringUtils.isEmpty(groupGubun)) {
			sql.append("  AND A.GROUP_GUBUN            = :group_gubun              ");
		}
		sql.append("ORDER BY A.SUB_HANGMOG_CODE                                ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("code_type", codeType);
		if (!StringUtils.isEmpty(hangmogCode)) {
			query.setParameter("hangmog_code", hangmogCode);
		}
		if (!StringUtils.isEmpty(specimenCode)) {
			query.setParameter("specimen_code", specimenCode);
		}
		if (!StringUtils.isEmpty(emergency)) {
			query.setParameter("emergency", emergency);
		}
		if (!StringUtils.isEmpty(groupGubun)) {
			query.setParameter("group_gubun", groupGubun);
		}
		List<CPL0106U00GrdListItemInfo> listGrdMaster= new JpaResultMapper().list(query, CPL0106U00GrdListItemInfo.class);
		return listGrdMaster;
	}

	@Override
	public String callFnCplLoadDupGrdHangmog(String hospCode,String newHanmogCode, String newSpecimenCode,String oldHanmogCode, String oldSpecimenCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT FN_CPL_LOAD_DUP_GRD_HANGMOG(:f_hosp_code,:f_new_hangmog_code,:f_new_specimen_code,:f_old_hangmog_code, :f_old_specimen_code) ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_new_hangmog_code", newHanmogCode);
		query.setParameter("f_new_specimen_code", newSpecimenCode);
		query.setParameter("f_old_hangmog_code", oldHanmogCode);
		query.setParameter("f_old_specimen_code", oldSpecimenCode);
		List<String> listResult =query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}

	@Override
	public boolean isExistedCpl0106(String hospCode, String hangmocCode, String specimenCode, String emergency,
			String subHanmogCode) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'  											");
		sql.append("	FROM CPL0106 A                         	 	    		");
		sql.append("	WHERE A.HOSP_CODE     = :f_hosp_code   		    		");
		sql.append("	AND A.HANGMOG_CODE     = :f_hangmog_code                ");
		sql.append("	AND A.SPECIMEN_CODE = :f_specimen_code        		    ");
		sql.append("	AND A.EMERGENCY = :f_emergency        		            ");
		sql.append("	AND A.SUB_HANGMOG_CODE = :f_sub_hangmog_code        	");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmocCode);
		query.setParameter("f_specimen_code", specimenCode);
		query.setParameter("f_emergency", emergency);
		query.setParameter("f_sub_hangmog_code", subHanmogCode);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}
	
}

