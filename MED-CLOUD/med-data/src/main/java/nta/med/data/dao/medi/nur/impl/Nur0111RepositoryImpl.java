package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0111RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0111Info;

/**
 * @author dainguyen.
 */
public class Nur0111RepositoryImpl implements Nur0111RepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getOCS2005U02AutoMaSetCombo(String hospCode, String sikGubun){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT A.NUR_MD_CODE, A.NUR_MD_NAME												");
		sql.append("       FROM NUR0111 A 																	");
		sql.append("      WHERE A.HOSP_CODE    = :f_hosp_code												");
		sql.append("        AND A.NUR_GR_CODE  = '03'														");
		sql.append("        AND ((A.NUR_MD_CODE != '0301' 													");
		sql.append("           AND SUBSTR(A.NUR_MD_CODE, 3, 1) = :f_sik_gubun)								");
		sql.append("         OR A.NUR_MD_CODE  IN ('0305','0309'))											");
		sql.append("      ORDER BY A.SORT_KEY																");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		if(sikGubun == "" || sikGubun == null)
			sikGubun = "0";
		query.setParameter("f_sik_gubun", sikGubun);
		
		List<ComboListItemInfo> resultList = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return resultList;
	}

	@Override
	public String getSansoOrderCode(String hospCode, String directCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(D.CODE, '')								");
		sql.append("	FROM NUR0111 A											");
		sql.append("	JOIN NUR0115 B ON B.HOSP_CODE   = A.HOSP_CODE			");
		sql.append("	              AND B.NUR_MD_CODE = A.NUR_MD_CODE			");
		sql.append("	JOIN OCS0132 D ON D.HOSP_CODE = B.HOSP_CODE				");
		sql.append("	              AND D.CODE_TYPE = 'MARUME_ORDER'			");
		sql.append("	              AND D.GROUP_KEY = 'SH'					");
		sql.append("	              AND D.CODE      = B.HANGMOG_CODE			");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code						");
		sql.append("	  AND A.NUR_MD_CODE = :f_direct_code					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_direct_code", directCode);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public List<NUR0110U00GrdNUR0111Info> getNUR0110U00GrdNUR0111Info(String hospCode, String nurGrCode,
			Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NUR_GR_CODE                            ,    ");
		sql.append("	       A.NUR_MD_CODE                            ,    ");
		sql.append("	       TRIM(A.NUR_MD_NAME)                      ,    ");
		sql.append("	       IFNULL(CAST(A.SORT_KEY AS CHAR), '')     ,    ");
		sql.append("	       IFNULL(A.JISI_ORDER_GUBUN, '0')          ,    ");
		sql.append("	       IFNULL(A.MENT, '')                       ,    ");
		sql.append("	       A.VALD                                   ,    ");
		sql.append("	       A.JISI_GUBUN                             ,    ");
		sql.append("	       IFNULL(A.CNT_PERHOUR_YN, '')             ,    ");
		sql.append("	       IFNULL(A.CNT_PERDAY_YN, '')              ,    ");
		sql.append("	       IFNULL(A.ACT_DAY_YN, '')                 ,    ");
		sql.append("	       IFNULL(A.FRENCH_YN, '')                  ,    ");
		sql.append("	       IFNULL(A.ACT_DQ1_YN, '')                 ,    ");
		sql.append("	       IFNULL(A.ACT_DQ2_YN, '')                 ,    ");
		sql.append("	       IFNULL(A.ACT_DQ3_YN, '')                 ,    ");
		sql.append("	       IFNULL(A.ACT_DQ4_YN, '')                 ,    ");
		sql.append("	       IFNULL(A.ACT_TIME_YN, '')                ,    ");
		sql.append("	       IFNULL(A.DIRECT_CONT_YN, '')             ,    ");
		sql.append("	       IFNULL(A.ACTING_YN, '')                  ,    ");
		sql.append("	       IFNULL(A.WORKLIST_DISP_YN, '')           ,    ");
		sql.append("	       IFNULL(A.JISI_CONTINUE_YN, '')                ");
		sql.append("	  FROM NUR0111 A                                     ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code                  ");
		sql.append("	   AND A.NUR_GR_CODE = :f_nur_gr_code                ");
		sql.append("	 ORDER BY A.NUR_GR_CODE, A.NUR_MD_CODE               ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset					 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0110U00GrdNUR0111Info> lstResult = new JpaResultMapper().list(query, NUR0110U00GrdNUR0111Info.class);
		return lstResult;	
	}
	
	
}

