package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2016RepositoryCustom;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAgrdOCS2016Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupILgrdOCS2016Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdOCS2016Info;

/**
 * @author dainguyen.
 */
public class Ocs2016RepositoryImpl implements Ocs2016RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getOCS6010U10CreatePopupMenuYn(String hospCode, Double fkocs2003) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'													   ");
		sql.append("	FROM OCS2016 A												   ");
		sql.append("	JOIN OCS2015 B ON B.HOSP_CODE = A.HOSP_CODE                    ");
		sql.append("	              AND B.PKOCS2015 = A.FKOCS2015                    ");
		sql.append("	JOIN OCS2005 C ON C.HOSP_CODE = B.HOSP_CODE                    ");
		sql.append("	              AND C.PKOCS2005 = B.FKOCS2005                    ");
		sql.append("	JOIN NUR0111 D ON D.HOSP_CODE   = C.HOSP_CODE				   ");
		sql.append("	              AND D.NUR_GR_CODE = C.DIRECT_GUBUN			   ");
		sql.append("	              AND D.NUR_MD_CODE = C.DIRECT_CODE				   ");
		sql.append("	              AND D.JISI_ORDER_GUBUN IN ('1', '2', '3', '4')   ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code							   ");
		sql.append("	 AND A.FKOCS2003 = :f_fkocs2003							       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2003", fkocs2003);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}

	@Override
	public List<OCS6010U10PopupTAgrdOCS2016Info> getOCS6010U10PopupTAgrdOCS2016Info(String hospCode, String fkocs2015,
			Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.PKOCS2016      ,               ");
		sql.append("       A.FKOCS2015      ,               ");
		sql.append("       A.SEQ            ,               ");
		sql.append("       A.HANGMOG_CODE   ,               ");
		sql.append("       B.HANGMOG_NAME   ,               ");
		sql.append("       A.SURYANG        ,               ");
		sql.append("       A.NALSU          ,               ");
		sql.append("       A.ORD_DANUI      ,               ");
		sql.append("       A.BOGYONG_CODE   ,               ");
		sql.append("       A.JUSA_CODE      ,               ");
		sql.append("       A.JUSA_SPD_GUBUN ,               ");
		sql.append("       A.DV             ,               ");
		sql.append("       A.DV_TIME        ,               ");
		sql.append("       A.FKOCS2003      ,               ");
		sql.append("       A.BOM_YN         ,               ");
		sql.append("       A.BOM_SOURCE_KEY ,               ");
		sql.append("       ''				                ");
		sql.append("  FROM OCS2016 A		                ");
		sql.append("     , OCS0103 B		                ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code	");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE		");
		sql.append("   AND B.HANGMOG_CODE = A.HANGMOG_CODE	");
		sql.append("   AND A.FKOCS2015    = :f_fkocs2015");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2015", CommonUtils.parseDouble(fkocs2015));
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS6010U10PopupTAgrdOCS2016Info> lstResult = new JpaResultMapper().list(query, OCS6010U10PopupTAgrdOCS2016Info.class);
		return lstResult;
	}

	@Override
	public Double getMaxSeqOCS6010U10(String hospCode, String fkocs2015) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT IFNULL(MAX(SEQ), 0) + 1 AS SEQ	");
		sql.append("    FROM OCS2016						");
		sql.append("   WHERE HOSP_CODE = :f_hosp_code		");
		sql.append("     AND FKOCS2015 = :f_fkocs2015		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2015", CommonUtils.parseDouble(fkocs2015));
		
		List<Double> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? 1.0 : result.get(0);
	}

	@Override
	public String getOCS6010U10frmARActingSeqOCS2016(String hospCode, Double fkocs2015) {

		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT													");
		sql.append("	  	IFNULL(MAX(A.SEQ), 0) + 1 			AS SEQ   		");
		sql.append("	FROM													");
		sql.append("	  	OCS2016 A											");
		sql.append("	WHERE													");
		sql.append("	  	A.HOSP_CODE 	= :f_hosp_code						");
		sql.append("	  	AND A.FKOCS2015 = :f_fkocs2015						");


		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2015", fkocs2015);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS6010U10PopupILgrdOCS2016Info> getOCS6010U10PopupILgrdOCS2016Info(String hospCode, String bunho,
			String limit7) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.YMD													                ");
		sql.append("	     , IFNULL(A.TIME_GUBUN, '')               AS TIME_GUBUN		                ");
		sql.append("	     , A.PR_VALUE												                ");
		sql.append("	     , A.FKOCS2016												                ");
		sql.append("	     , B.SURYANG												                ");
		sql.append("	     , IFNULL(C.CODE_NAME, '')                AS CODE_NAME	                    ");
		sql.append("	     , IFNULL(D.USER_NM, '')                  AS USER_NM	                    ");
		sql.append("	     , IF(A.FKOCS2016 IS NULL, 'NUR', 'OCS')  AS KUBUN		                    ");
		sql.append("	FROM NUR1020 A												                    ");
		sql.append("	LEFT JOIN OCS2016 B ON B.HOSP_CODE = A.HOSP_CODE                                ");
		sql.append("	                   AND B.PKOCS2016 = A.FKOCS2016                                ");
		sql.append("	LEFT JOIN OCS0132 C ON C.HOSP_CODE = B.HOSP_CODE                                ");
		sql.append("	                   AND C.CODE_TYPE = 'ORD_DANUI'                                ");
		sql.append("	                   AND C.CODE      = B.ORD_DANUI                                ");
		sql.append("	LEFT JOIN ADM3200 D ON D.HOSP_CODE = A.HOSP_CODE                                ");
		sql.append("	                   AND D.USER_ID   = A.UPD_ID	                                ");
		sql.append("	WHERE A.HOSP_CODE    = :f_hosp_code				                                ");
		sql.append("	  AND A.BUNHO        = :f_bunho					                                ");
		sql.append("	  AND A.PR_GUBUN     = 'BS'						                                ");
		sql.append("	  AND A.PR_VALUE     > 0						                                ");
		sql.append("	 AND (   (:f_limit7 = 'Y' AND DATE_ADD(SYSDATE(), INTERVAL - 7 DAY) < A.YMD) 	");
		sql.append("	      OR (:f_limit7 = 'N')														");
		sql.append("	      )																			");
		sql.append("	ORDER BY A.YMD, A.TIME_GUBUN													");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_limit7", limit7);
		
		List<OCS6010U10PopupILgrdOCS2016Info> listInfo = new JpaResultMapper().list(query, OCS6010U10PopupILgrdOCS2016Info.class);
		return listInfo;
	}

	@Override
	public List<OCS6010U10PopupIAgrdOCS2016Info> getOCS6010U10PopupIAgrdOCS2016(String hospCode, String fkocs2015,
			String offset, String pageNumber) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																					");
		sql.append("	    CAST(A.FKOCS2015 AS CHAR),															");
		sql.append("	    CAST(A.PKOCS2016 AS CHAR),															");
		sql.append("	    A.HANGMOG_CODE,																		");
		sql.append("	    CAST(A.SURYANG AS CHAR),															");
		sql.append("	    IFNULL(A.BLOOD_SUGAR, ''),															");
		sql.append("	    @row \\:= @row as ROW_SUB_1,														");
		sql.append("	    @row \\:= @row + 1,																	");
		sql.append("	    DATE_FORMAT(IFNULL(A.UPD_DATE, SYSDATE()), 'HH24MI')  		ACT_TIME,				");
		sql.append("	    DATE_FORMAT(IFNULL(A.UPD_DATE, SYSDATE()), 'YYYYMMDD')  	YMD,					");
		sql.append("	    A.ORD_DANUI  ORD_DANUI,																");
		sql.append("	    FN_OCS_GET_ORD_DANUI_NAME(A.HOSP_CODE, A.ORD_DANUI) 		ORD_DANUI_NAME,			");
		sql.append("	    IFNULL(A.MUHYO, 'N')                            			MUHYO,					");
		sql.append("	    IFNULL(A.BROUGHT_DRG_YN, 'N')                          		BROUGHT_DRG_YN			");
		sql.append("	FROM																					");
		sql.append("	    OCS2016 A, (SELECT @row \\:= 0) r													");
		sql.append("	WHERE																					");
		sql.append("	  	A.HOSP_CODE 	= :f_hosp_code														");
		sql.append("	  	AND A.FKOCS2015 = :f_fkocs2015														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fkocs2015", fkocs2015);
		
		List<OCS6010U10PopupIAgrdOCS2016Info> listInfo = new JpaResultMapper().list(query, OCS6010U10PopupIAgrdOCS2016Info.class);
		return listInfo;
	}

	@Override
	public String getOrdDanui(String hospCode, String hangmogCode, Date orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_GET_ORD_DANUI(:hospCode, :hangmogCode, :orderDate) FROM DUAL ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("orderDate", orderDate);
		
		List<String> rs = query.getResultList();
		return CollectionUtils.isEmpty(rs) ? "" : rs.get(0);
	}

	@Override
	public String getOrdDanuiName(String hospCode, String ordDanui) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_GET_ORD_DANUI_NAME(:hospCode, :ordDanui) FROM DUAL ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("ordDanui", ordDanui);
		
		List<String> rs = query.getResultList();
		return CollectionUtils.isEmpty(rs) ? "" : rs.get(0);
	}
}

