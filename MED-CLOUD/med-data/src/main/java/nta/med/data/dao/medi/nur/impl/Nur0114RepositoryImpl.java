package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0114RepositoryCustom;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0114Info;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNUR0114Info;

/**
 * @author dainguyen.
 */
public class Nur0114RepositoryImpl implements Nur0114RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS2005U00grdNUR0114Info> getOCS2005U00grdNur0114Info(String hospCode, String nurGrCode,
			String nurMdCode, String vald, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT									");
		sql.append("		NUR_SO_CODE,						");
		sql.append("	  	NUR_SO_NAME							");
		sql.append("	FROM									");
		sql.append("		NUR0114								");
		sql.append("	WHERE									");
		sql.append("		HOSP_CODE   	= :f_hosp_code		");
		sql.append("	  	AND NUR_GR_CODE = :f_nur_gr_code	");
		sql.append("	  	AND NUR_MD_CODE = :f_nur_md_code	");
		sql.append("	  	AND VALD        = 'Y'				");
		sql.append("	ORDER BY								");
		sql.append("		IFNULL(SORT_KEY, NUR_SO_CODE)		");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<OCS2005U00grdNUR0114Info> listResult = new JpaResultMapper().list(query, OCS2005U00grdNUR0114Info.class);
		return listResult;
	}

	@Override
	public List<NUR0110U00GrdNUR0114Info> getNUR0110U00GrdNUR0114Info(String hospCode, String nurGrCode, String nurMdCode,
			Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NUR_GR_CODE,                        ");
		sql.append("	       A.NUR_MD_CODE,                        ");
		sql.append("	       A.NUR_SO_CODE,                        ");
		sql.append("	       TRIM(A.NUR_SO_NAME),                  ");
		sql.append("	       IFNULL(CAST(A.SORT_KEY AS CHAR), ''), ");
		sql.append("	       IFNULL(A.MENT, ''),                   ");
		sql.append("	       A.VALD                                ");
		sql.append("	  FROM NUR0114 A                             ");
		sql.append("	 WHERE A.HOSP_CODE   = :f_hosp_code          ");
		sql.append("	   AND A.NUR_GR_CODE = :f_nur_gr_code        ");
		sql.append("	   AND A.NUR_MD_CODE = :f_nur_md_code        ");
		
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset				");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_nur_gr_code", nurGrCode);
		query.setParameter("f_nur_md_code", nurMdCode);
		
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0110U00GrdNUR0114Info> listResult = new JpaResultMapper().list(query, NUR0110U00GrdNUR0114Info.class);
		return listResult;
	}
}

