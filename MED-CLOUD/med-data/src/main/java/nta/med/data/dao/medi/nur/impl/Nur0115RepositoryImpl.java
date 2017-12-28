package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0115RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR01152Info;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0115Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNUR01152Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNUR0115Info;

/**
 * @author dainguyen.
 */
public class Nur0115RepositoryImpl implements Nur0115RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getMsgInsulin(String hospCode, String directGubun, String hangmogCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT 'X'                            ");
		sql.append("   FROM NUR0115 A,                             ");
			sql.append("        OCS0103 B                          ");
		sql.append("  WHERE A.HOSP_CODE      = :f_hosp_code        ");
		sql.append("    AND A.NUR_GR_CODE    = :f_direct_gubun     ");
		sql.append("    AND A.NUR_MD_CODE    IN( '2033', '2030' )  ");
		sql.append("    AND A.HANGMOG_CODE   = :f_hangmog_code     ");
		sql.append("    AND IFNULL(A.NUR_SO_CODE, '%') LIKE '0'    ");
		sql.append("    AND B.HOSP_CODE      = A.HOSP_CODE     ");
		sql.append("    AND B.HANGMOG_CODE   = A.HANGMOG_CODE      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_direct_gubun", directGubun);
		query.setParameter("f_hangmog_code", hangmogCode);
		
		List<String> list = query.getResultList();
		if(list != null && list.size() > 0 ){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<OCS2005U00grdNUR0115Info> getOCS2005U00grdNUR0115Info(String hospCode, String language,
			String nurGrCode, String nurMdCode, String nurSoCode, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'N' SELECT_ORDER ,                                                                                                                                           ");
		sql.append("	       ''               ,                                                                                                                                           ");
		sql.append("	       C.SLIP_NAME      ,                                                                                                                                           ");
		sql.append("	       A.HANGMOG_CODE   ,                                                                                                                                           ");
		sql.append("	       B.HANGMOG_NAME   ,                                                                                                                                           ");
		sql.append("	       A.SURYANG        ,                                                                                                                                           ");
		sql.append("	       A.ORD_DANUI      ,                                                                                                                                           ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :f_language) ORD_DANUI_NAME ,																	");
		sql.append("	       A.DV             ,                                                                                                                                           ");
		sql.append("	       A.DV_TIME        ,                                                                                                                                           ");
		sql.append("	       A.NALSU          ,                                                                                                                                           ");
		sql.append("	       A.JUSA_CODE      ,                                                                                                                                           ");
		sql.append("	       FN_DRG_LOAD_BOGYONG_JUSA_NAME('A', A.JUSA_CODE, :f_hosp_code, :f_language)   JUSA_NAME ,																		");
		sql.append("	       A.JUSA_SPD_GUBUN ,                                                                                                                                           ");
		sql.append("	       A.BOGYONG_CODE   ,                                                                                                                                           ");
		sql.append("	       IF(C.SLIP_CODE = 'J01', CONCAT(A.BOGYONG_CODE, D.CODE_NAME), FN_DRG_LOAD_BOGYONG_JUSA_NAME('C', A.BOGYONG_CODE, :f_hosp_code, :f_language)) AS BOGYONG_NAME,	");
		sql.append("	       A.NUR_GR_CODE    ,                                                                                                                                           ");
		sql.append("	       A.NUR_MD_CODE    ,                                                                                                                                           ");
		sql.append("	       A.NUR_SO_CODE    ,                                                                                                                                           ");
		sql.append("	       A.SEQ            ,                                                                                                                                           ");
		sql.append("	       A.BOM_SOURCE_KEY ,                                                                                                                                           ");
		sql.append("	       IFNULL(A.BOM_YN, 'P') BOM_YN                    ,                                                                                                            ");
		sql.append("	       C.SLIP_CODE      ,								                                                                                                            ");
		sql.append("	       FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, DATE(SYSDATE()), :f_hosp_code) BULYONG_YN                                                                           ");
		sql.append("	  FROM NUR0115 A																		                                                                            ");
		sql.append("	       JOIN OCS0103 B																  	                                                                            ");
		sql.append("	         ON  A.HANGMOG_CODE   = B.HANGMOG_CODE											                                                                            ");
		sql.append("	         AND A.HOSP_CODE      = B.HOSP_CODE                                                                                                                         ");
		sql.append("	       JOIN OCS0102 C																	                                                                            ");                                                                 
		sql.append("	         ON  B.SLIP_CODE      = C.SLIP_CODE                                                                                                                         ");
		sql.append("	         AND B.HOSP_CODE      = C.HOSP_CODE                                                                                                                         ");
		sql.append("	       LEFT JOIN OCS0132 D															                                                                                ");
		sql.append("	         ON  A.JUSA_SPD_GUBUN = D.CODE         																														");
		sql.append("	         AND A.HOSP_CODE   = D.HOSP_CODE																															");
		sql.append("	         AND 'JUSA_SPD_GUBUN' = D.CODE_TYPE																															");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code																																	");
		sql.append("	   AND A.NUR_GR_CODE  = :f_nur_gr_code																																");
		sql.append("	   AND A.NUR_MD_CODE    = :f_nur_md_code																															");
		sql.append("	   AND IFNULL(A.NUR_SO_CODE, '%') LIKE IFNULL(:f_nur_so_code, '%')																									");
		sql.append("	   AND DATE(SYSDATE()) BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99991231', '%Y%m%d'))																");
		sql.append("	 ORDER BY A.NUR_SO_CODE, A.SEQ, A.HANGMOG_CODE																														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		query.setParameter("f_nur_so_code", nurSoCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS2005U00grdNUR0115Info> lstResult = new JpaResultMapper().list(query, OCS2005U00grdNUR0115Info.class);
		return lstResult;
	}

	@Override
	public List<OCS2005U00grdNUR01152Info> getOCS2005U00grdNUR01152Info(String hospCode, String language,
			String nurGrCode, String nurMdCode, String nurSoCode, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT 'N' SELECT_ORDER,                                                                           ");
		sql.append("	       ''               ,                                                                           ");
		sql.append("	       C.SLIP_NAME      ,                                                                           ");
		sql.append("	       A.HANGMOG_CODE   ,                                                                           ");
		sql.append("	       B.HANGMOG_NAME   ,                                                                           ");
		sql.append("	       A.SURYANG        ,                                                                           ");
		sql.append("	       A.ORD_DANUI      ,                                                                           ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :f_language) ORD_DANUI_NAME ,	");
		sql.append("	       A.NALSU          ,                                                                           ");
		sql.append("	       A.BOGYONG_CODE   ,                                                                           ");
		sql.append("	       FN_DRG_LOAD_BOGYONG_JUSA_NAME('C', A.BOGYONG_CODE, :f_hosp_code, :f_language) BOGYONG_NAME  ,");
		sql.append("	       A.NUR_GR_CODE    ,                                                                           ");
		sql.append("	       A.NUR_MD_CODE    ,                                                                           ");
		sql.append("	       A.NUR_SO_CODE    ,                                                                           ");
		sql.append("	       A.SEQ            ,                                                                           ");
		sql.append("	       A.BOM_SOURCE_KEY ,                                                                           ");
		sql.append("	       A.BOM_YN         ,                                                                           ");
		sql.append("	       C.SLIP_CODE      ,                                                                           ");
		sql.append("	       FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, DATE(SYSDATE()), :f_hosp_code) BULYONG_YN			");
		sql.append("	  FROM NUR0115 A								                                                    ");
		sql.append("	       JOIN OCS0103 B							                                                    ");
		sql.append("	          ON  A.HANGMOG_CODE   = B.HANGMOG_CODE	                                                    ");
		sql.append("	          AND A.HOSP_CODE      = B.HOSP_CODE	                                                    ");
		sql.append("	       JOIN OCS0102 C							                                                    ");
		sql.append("	          ON  B.SLIP_CODE      = C.SLIP_CODE	                                                    ");
		sql.append("	          AND B.HOSP_CODE      = C.HOSP_CODE	                                                    ");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code				                                                    ");                                                                 
		sql.append("	   AND A.NUR_MD_CODE    = :f_nur_md_code		                                                    ");
		sql.append("	   AND IFNULL(A.NUR_SO_CODE, '%') LIKE IFNULL(:f_nur_so_code, '%')									");
		sql.append("	   AND A.NUR_GR_CODE  = :f_nur_gr_code																");
		sql.append("	 ORDER BY A.NUR_SO_CODE, A.SEQ, A.HANGMOG_CODE														");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		query.setParameter("f_nur_so_code", nurSoCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS2005U00grdNUR01152Info> lstResult = new JpaResultMapper().list(query, OCS2005U00grdNUR01152Info.class);
		return lstResult;
	}

	@Override
	public List<ComboListItemInfo> getOCS2005U00layoutComboInfo(String hospCode, String nurGrCode, String nurMdCode,
			String nurSoCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HANGMOG_CODE ,																			");
		sql.append("	       B.HANGMOG_NAME 																			");
		sql.append("	  FROM NUR0115 A ,																				");
		sql.append("	       OCS0103 B																				");
		sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code															");
		sql.append("	   AND A.NUR_SO_CODE  = :f_nur_so_code															");
		sql.append("	   AND B.HANGMOG_CODE = A.HANGMOG_CODE															");
		sql.append("	   AND B.HOSP_CODE    = A.HOSP_CODE																");
		sql.append("	   AND A.NUR_GR_CODE  = :f_nur_gr_code															");
		sql.append("	   AND A.NUR_MD_CODE  = :f_nur_md_code															");
		sql.append("	   AND SYSDATE() BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99991231', '%Y%m%d'))	");
		sql.append("	   AND SYSDATE() BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99991231', '%Y%m%d'))	");
		sql.append("	 ORDER BY B.HANGMOG_NAME																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		query.setParameter("f_nur_so_code", nurSoCode);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}

	@Override
	public List<ComboListItemInfo> getOCS6010U10PopupIAxEditGridCell3(String hospCode, String nurGrCode, String nurMdCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT																												");
		sql.append("		A.HANGMOG_CODE,																									");
		sql.append("	    B.HANGMOG_NAME																									");
		sql.append("	FROM																												");
		sql.append("		NUR0115 A 	JOIN 	OCS0103 B																					");
		sql.append("					ON 		A.HOSP_CODE 	= B.HOSP_CODE																");
		sql.append("					AND 	A.HANGMOG_CODE 	= B.HANGMOG_CODE															");
		sql.append("	WHERE																												");
		sql.append("		A.HOSP_CODE    		= :f_hosp_code																				");
		sql.append("		AND A.NUR_GR_CODE  	= :f_nur_gr_code																			");
		sql.append("	  	AND A.NUR_MD_CODE  	= :f_nur_md_code																			");
		sql.append("	  	AND A.NUR_SO_CODE  	= '0'																						");
		sql.append("	  	  AND CURRENT_DATE() BETWEEN A.START_DATE AND IFNULL(A.END_DATE, STR_TO_DATE('99991231', '%Y%m%d'))				");
		sql.append("	  	  AND CURRENT_DATE() BETWEEN B.START_DATE AND IFNULL(B.END_DATE, STR_TO_DATE('99991231', '%Y%m%d'))				");
		sql.append("	ORDER BY																											");
		sql.append("		B.HANGMOG_NAME																									");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		
		List<ComboListItemInfo> listInfo = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listInfo;
	}

	@Override
	public List<NUR0110U00GrdNUR0115Info> getNUR0110U00GrdNUR0115Info(String hospCode, String language,
			String nurGrCode, String nurMdCode, String nurSoCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT ''               ,                                                                                                                                                     ");
		sql.append("	       C.SLIP_NAME      ,                                                                                                                                                     ");
		sql.append("	       A.HANGMOG_CODE   ,                                                                                                                                                     ");
		sql.append("	       B.HANGMOG_NAME   ,                                                                                                                                                     ");
		sql.append("	       A.SURYANG        ,                                                                                                                                                     ");
		sql.append("	       IFNULL(A.ORD_DANUI, '')      ,                                                                                                                                         ");
		sql.append("	       IFNULL(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :f_language), '') ORD_DANUI_NAME,                                                                 ");
		sql.append("	       A.DV             ,                                                                                                                                                     ");
		sql.append("	       IFNULL(A.DV_TIME, ''),                                                                                                                                                 ");
		sql.append("	       A.NALSU          ,                                                                                                                                                     ");
		sql.append("	       IFNULL(A.JUSA_CODE, '')      ,                                                                                                                                         ");
		sql.append("	       IFNULL(FN_DRG_LOAD_BOGYONG_JUSA_NAME('A', A.JUSA_CODE, :f_hosp_code, :f_language), '')   JUSA_NAME ,                                                                   ");
		sql.append("	       IFNULL(A.JUSA_SPD_GUBUN, '') ,                                                                                                                                         ");
		sql.append("	       IFNULL(A.BOGYONG_CODE, '')   ,                                                                                                                                         ");
		sql.append("	       IFNULL(IF(C.SLIP_CODE = 'J01', CONCAT(A.BOGYONG_CODE, D.CODE_NAME), FN_DRG_LOAD_BOGYONG_JUSA_NAME('C', A.BOGYONG_CODE, :f_hosp_code, :f_language)),'') AS BOGYONG_NAME,");
		sql.append("	       A.START_DATE     ,                                                                                                                                                     ");
		sql.append("	       A.END_DATE       ,                                                                                                                                                     ");
		sql.append("	       A.NUR_GR_CODE    ,                                                                                                                                                     ");
		sql.append("	       A.NUR_MD_CODE    ,                                                                                                                                                     ");
		sql.append("	       A.NUR_SO_CODE    ,                                                                                                                                                     ");
		sql.append("	       A.SEQ			      ,                                                                                                                                               ");
		sql.append("	       IFNULL(A.BOM_SOURCE_KEY, '') ,                                                                                                                                         ");
		sql.append("	       IFNULL(A.BOM_YN, '')			    ,                                                                                                                                     ");
		sql.append("	       IFNULL(C.SLIP_CODE, '')		  ,                                                                                                                                       ");
		sql.append("	       IFNULL(B.INPUT_CONTROL, '')                                                                                                                                            ");
		sql.append("	  FROM NUR0115 A                                                                                                                                                              ");
		sql.append("	  JOIN OCS0103 B ON B.HOSP_CODE      = A.HOSP_CODE                                                                                                                            ");
		sql.append("					AND B.HANGMOG_CODE   = A.HANGMOG_CODE                                                                                                                         ");
		sql.append("	  JOIN OCS0102 C ON C.HOSP_CODE      = B.HOSP_CODE                                                                                                                            ");
		sql.append("					AND C.SLIP_CODE      = B.SLIP_CODE                                                                                                                            ");
		sql.append("	  LEFT JOIN OCS0132 D ON D.HOSP_CODE = A.HOSP_CODE                                                                                                                            ");
		sql.append("						 AND D.CODE 	 = A.JUSA_SPD_GUBUN                                                                                                                       ");
		sql.append("						 AND D.CODE_TYPE = 'JUSA_SPD_GUBUN'                                                                                                                       ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code                                                                                                                                        ");
		sql.append("	   AND A.NUR_GR_CODE    = :f_nur_gr_code                                                                                                                                      ");
		sql.append("	   AND A.NUR_MD_CODE    = :f_nur_md_code                                                                                                                                      ");
		sql.append("	   AND IF(A.NUR_SO_CODE IS NULL OR A.NUR_SO_CODE = '', '%', A.NUR_SO_CODE) LIKE IF(:f_nur_so_code IS NULL OR :f_nur_so_code = '', '%', :f_nur_so_code)                        ");
		sql.append("	 ORDER BY A.NUR_SO_CODE, A.SEQ, A.HANGMOG_CODE                                                                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		query.setParameter("f_nur_so_code", nurSoCode);
		
		List<NUR0110U00GrdNUR0115Info> listInfo = new JpaResultMapper().list(query, NUR0110U00GrdNUR0115Info.class);
		return listInfo;
	}

	@Override
	public List<NUR0110U00GrdNUR01152Info> getNUR0110U00GrdNUR01152Info(String hospCode, String language,
			String nurGrCode, String nurMdCode, String nurSoCode, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT ''        		,                                                                                                                              ");
		sql.append("	       C.SLIP_NAME      ,                                                                                                                              ");
		sql.append("	       A.HANGMOG_CODE   ,                                                                                                                              ");
		sql.append("	       B.HANGMOG_NAME   ,                                                                                                                              ");
		sql.append("	       A.SURYANG        ,                                                                                                                              ");
		sql.append("	       A.ORD_DANUI      ,                                                                                                                              ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :f_language) ORD_DANUI_NAME,                                                      ");
		sql.append("	       A.NALSU          ,                                                                                                                              ");
		sql.append("	       IFNULL(A.BOGYONG_CODE, '')   ,                                                                                                                  ");
		sql.append("	       IFNULL(FN_CHT_LOAD_SUB_BUWI_NAME(A.BOGYONG_CODE, :f_hosp_code), '') BUWI_NAME,                                                                  ");
		sql.append("	       A.START_DATE     ,                                                                                                                              ");
		sql.append("	       A.END_DATE       ,                                                                                                                              ");
		sql.append("	       A.NUR_GR_CODE    ,                                                                                                                              ");
		sql.append("	       A.NUR_MD_CODE    ,                                                                                                                              ");
		sql.append("	       A.NUR_SO_CODE    ,                                                                                                                              ");
		sql.append("	       A.SEQ        	,                                                                                                                              ");
		sql.append("	       IFNULL(A.BOM_SOURCE_KEY, '') ,                                                                                                                  ");
		sql.append("	       A.BOM_YN			,                                                                                                                              ");
		sql.append("	       B.SLIP_CODE		,                                                                                                                              ");
		sql.append("	       B.INPUT_CONTROL                                                                                                                                 ");
		sql.append("	  FROM NUR0115 A                                                                                                                                       ");
		sql.append("	  JOIN OCS0103 B ON B.HOSP_CODE      = A.HOSP_CODE                                                                                                     ");
		sql.append("					AND B.HANGMOG_CODE   = A.HANGMOG_CODE                                                                                                  ");
		sql.append("	  JOIN OCS0102 C ON C.HOSP_CODE      = B.HOSP_CODE                                                                                                     ");
		sql.append("					AND C.SLIP_CODE      = B.SLIP_CODE                                                                                                     ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code                                                                                                                 ");
		sql.append("	   AND A.NUR_GR_CODE    = :f_nur_gr_code                                                                                                               ");
		sql.append("	   AND A.NUR_MD_CODE    = :f_nur_md_code                                                                                                               ");
		sql.append("	   AND IF(A.NUR_SO_CODE IS NULL OR A.NUR_SO_CODE = '', '%', A.NUR_SO_CODE) LIKE IF(:f_nur_so_code IS NULL OR :f_nur_so_code = '', '%', :f_nur_so_code) ");
		sql.append("	 ORDER BY A.NUR_SO_CODE, A.SEQ, A.HANGMOG_CODE                                                                                                         ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		query.setParameter("f_nur_so_code", nurSoCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0110U00GrdNUR01152Info> lstResult = new JpaResultMapper().list(query, NUR0110U00GrdNUR01152Info.class);
		return lstResult;
	}

	@Override
	public Double getNextSeqNur0115(String hospCode, String nurGrCode, String nurMdCode, String nurSoCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(MAX(SEQ), 0) + 1     ");
		sql.append("	FROM NUR0115                       ");
		sql.append("	WHERE HOSP_CODE   = :f_hosp_code   ");
		sql.append("	 AND NUR_GR_CODE = :f_nur_gr_code  ");
		sql.append("	 AND NUR_MD_CODE = :f_nur_md_code  ");
		sql.append("	 AND NUR_SO_CODE = :f_nur_so_code  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		query.setParameter("f_nur_so_code", nurSoCode);
		
		List<Double> rs = query.getResultList();
		return rs.get(0);
	}
	
	

}

