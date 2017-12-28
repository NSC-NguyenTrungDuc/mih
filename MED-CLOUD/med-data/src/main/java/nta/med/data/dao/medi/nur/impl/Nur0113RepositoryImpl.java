package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0113RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0113Info;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdNUR0114Info;

/**
 * @author dainguyen.
 */
public class Nur0113RepositoryImpl implements Nur0113RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS6010U10PopupTAgrdNUR0114Info> getOCS6010U10PopupTAgrdNUR0114Info(String hospCode, String directGubun,
			String directCode, String vald) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT ''        AS  CHK ,				");
		sql.append("	      A.NUR_ACT_CODE    ,				");
		sql.append("	      A.NUR_ACT_NAME					");
		sql.append("	  FROM NUR0113 A						");
		sql.append("	  WHERE A.HOSP_CODE    = :f_hosp_code	");
		sql.append("	  AND A.NUR_GR_CODE  = :f_direct_gubun	");
		sql.append("	  AND A.NUR_MD_CODE  = :f_direct_code	");
		sql.append("	  AND A.VALD = :f_vald					");
		sql.append("	  ORDER BY A.SORT_KEY					");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_direct_gubun", directGubun);
		query.setParameter("f_direct_code", directCode);
		query.setParameter("f_vald", vald);
		
		List<OCS6010U10PopupTAgrdNUR0114Info> list = new JpaResultMapper().list(query, OCS6010U10PopupTAgrdNUR0114Info.class);
		return list;
	}

	@Override
	public List<OCS6010U10PopupTAgrdNUR0114Info> getOCS6010U10frmDirectActinggrdNUR0113Info(String hospCode, String directCode,
			String vald, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT ''        AS  CHK ,				");
		sql.append("	      A.NUR_ACT_CODE    ,				");
		sql.append("	      A.NUR_ACT_NAME					");
		sql.append("	  FROM NUR0113 A						");
		sql.append("	  WHERE A.HOSP_CODE    = :f_hosp_code	");
		sql.append("	  AND A.NUR_MD_CODE  = :f_direct_code	");
		sql.append("	  AND A.VALD = :f_vald					");
		sql.append("	  ORDER BY A.NUR_ACT_CODE				");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                        ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_direct_code", directCode);
		query.setParameter("f_vald", vald);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS6010U10PopupTAgrdNUR0114Info> list = new JpaResultMapper().list(query, OCS6010U10PopupTAgrdNUR0114Info.class);
		return list;
	}

	@Override
	public List<NUR0110U00GrdNUR0113Info> getNUR0110U00GrdNUR0113Info(String hospCode, String nurGrCode,
			String nurMdCode, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NUR_GR_CODE,                        ");
		sql.append("	       A.NUR_MD_CODE,                        ");
		sql.append("	       A.NUR_ACT_CODE,                       ");
		sql.append("	       TRIM(A.NUR_ACT_NAME),                 ");
		sql.append("	       IFNULL(CAST(A.SORT_KEY AS CHAR), ''), ");
		sql.append("	       IFNULL(A.MENT, ''),                   ");
		sql.append("	       A.VALD                                ");
		sql.append("	  FROM NUR0113 A                             ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code          ");
		sql.append("	   AND A.NUR_GR_CODE = :f_nur_gr_code        ");
		sql.append("	   AND A.NUR_MD_CODE = :f_nur_md_code        ");
		sql.append("	 ORDER BY LPAD(NUR_ACT_CODE, 3, '0')         ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset																					                        ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0110U00GrdNUR0113Info> list = new JpaResultMapper().list(query, NUR0110U00GrdNUR0113Info.class);
		return list;
	}
	
}

