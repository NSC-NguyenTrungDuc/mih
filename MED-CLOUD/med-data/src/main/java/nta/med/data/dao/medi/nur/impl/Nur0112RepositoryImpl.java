package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0112RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0112Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNur0112Info;

/**
 * @author dainguyen.
 */
public class Nur0112RepositoryImpl implements Nur0112RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getOCS2005U02AutoMaSetCombo(String hospCode, String code){
		StringBuilder sql = new StringBuilder();
		
		sql.append("     SELECT C.CODE       CODE								");
		sql.append("          , C.CODE_NAME  CODE_NAME							");
		sql.append("       FROM (SELECT ' '   CODE								");
		sql.append("                  , ' '   CODE_NAME							");
		sql.append("                  , 0   SORT_KEY							");
		sql.append("               FROM DUAL									");
		sql.append("              UNION											");
		sql.append("             SELECT A.NUR_SO_CODE CODE						");
		sql.append("                  , A.NUR_SO_NAME CODE_NAME					");
		sql.append("                  , IFNULL(A.SORT_KEY, 1) SORT_KEY			");
		sql.append("               FROM NUR0112 A 								");
		sql.append("              WHERE A.HOSP_CODE   = :f_hosp_code			");
		sql.append("                AND A.NUR_MD_CODE = :f_code					");
		sql.append("                AND A.VALD        = 'Y'						");
		sql.append("              ORDER BY SORT_KEY) C							");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		
		List<ComboListItemInfo> resultList = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return resultList;
	}

	@Override
	public List<OCS2005U00grdNur0112Info> getOCS2005U00grdNur0112Info(String hospCode, String nurGrCode,
			String nurMdCode, String vald, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT NUR_SO_CODE                      ");
		sql.append("	     , NUR_SO_NAME                      ");
		sql.append("	     , NUR_GR_CODE                      ");
		sql.append("	     , NUR_MD_CODE                      ");
		sql.append("	  FROM NUR0112							");
		sql.append("	 WHERE HOSP_CODE   = :f_hosp_code		");
		sql.append("	   AND VALD        = :f_vald			");
		sql.append("	   AND NUR_GR_CODE = :f_nur_gr_code		");
		sql.append("	   AND NUR_MD_CODE = :f_nur_md_code		");
		sql.append("	 ORDER BY SORT_KEY						");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		query.setParameter("f_vald", vald);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS2005U00grdNur0112Info> lstResult = new JpaResultMapper().list(query, OCS2005U00grdNur0112Info.class);
		return lstResult;
	}
	
	@Override
	public String fnIsSikaCode(String hospCode, String cont1, String cont1D, String cont2, String cont2D, String cont3, String cont3D){
		StringBuilder sql = new StringBuilder();
		sql.append("     SELECT FN_OCS_IS_SIKSA_CODE(:f_hosp_code, :f_direct_cont1, :f_direct_cont1_d					");
		sql.append("                               , :f_direct_cont2, :f_direct_cont2_d									");
		sql.append("                               , :f_direct_cont3, :f_direct_cont3_d) FROM DUAL						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_direct_cont1", cont1);
		query.setParameter("f_direct_cont1_d", cont1D);
		query.setParameter("f_direct_cont2", cont2);
		query.setParameter("f_direct_cont2_d", cont2D);
		query.setParameter("f_direct_cont3", cont3);
		query.setParameter("f_direct_cont3_d", cont3D);
		List<String> results = query.getResultList();
		return CollectionUtils.isEmpty(results) ? "" : results.get(0);
	}

	@Override
	public List<NUR0110U00GrdNUR0112Info> getNUR0110U00GrdNUR0112Info(String hospCode, String nurGrCode,
			String nurMdCode, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NUR_GR_CODE,                        ");
		sql.append("	       A.NUR_MD_CODE,                        ");
		sql.append("	       A.NUR_SO_CODE,                        ");
		sql.append("	       TRIM(A.NUR_SO_NAME),                  ");
		sql.append("	       IFNULL(CAST(A.SORT_KEY AS CHAR), ''), ");
		sql.append("	       IFNULL(A.MENT, ''),                   ");
		sql.append("	       A.VALD                                ");
		sql.append("	  FROM NUR0112 A                             ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code          ");
		sql.append("	   AND A.NUR_GR_CODE = :f_nur_gr_code        ");
		sql.append("	   AND A.NUR_MD_CODE = :f_nur_md_code        ");
		sql.append("	 ORDER BY A.SORT_KEY                         ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset					 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0110U00GrdNUR0112Info> lstResult = new JpaResultMapper().list(query, NUR0110U00GrdNUR0112Info.class);
		return lstResult;
	}
}

