package nta.med.data.dao.medi.bas.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0260SRepositoryCustom;
import nta.med.data.model.ihis.bass.LoadGrdBAS0260U01Info;


public class Bas0260SRepositoryImpl implements Bas0260SRepositoryCustom {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<LoadGrdBAS0260U01Info> getBas0260SListGetDepartment(String language, String buseoName, String gwaName, String activeFlg, String hospCode, String buseoGubun){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	   SELECT A.ID, 																						    ");    
		sql.append("              A.BUSEO_CODE,	                                                                                    ");
		sql.append("              A.BUSEO_NAME,	                                                                                    "); 
		sql.append("              A.BUSEO_NAME2,  	                                                                                ");
		sql.append("              A.BUSEO_GUBUN,  	                                                                                ");
		sql.append("              A.PARENT_BUSEO,  	                                                                                ");
		sql.append("              A.GWA,		  	                                                                                ");
		sql.append("              A.GWA_NAME,	  	                                                                                ");
		sql.append("              A.GWA_NAME2,	                                                                                    ");
		sql.append("              A.GWA_GUBUN,	                                                                                    ");
		sql.append("              A.PARENT_GWA,	                                                                                    ");
		sql.append("              A.NOTE,		  	                                                                                ");
		sql.append("              A.LANGUAGE,	  	                                                                                ");
		sql.append("              A.ACTIVE_FLG	                                                                                    ");
		sql.append("	FROM BAS0260S A                                                                                             ");
		sql.append("	     INNER JOIN BAS0102 B  ON A.BUSEO_GUBUN = B.CODE                                                        ");
		sql.append("	WHERE 1 = 1                                                                                                 ");
		if (!StringUtils.isEmpty(buseoGubun)) {
			sql.append("	  AND A.BUSEO_GUBUN    LIKE :f_buseo_gubun                                                              ");
		}
		
		if (!StringUtils.isEmpty(buseoName)) {
			sql.append("	  AND A.BUSEO_NAME    LIKE :f_buseo_name                                                                ");
		}
		
		if (!StringUtils.isEmpty(language)) {
			sql.append("	  AND A.LANGUAGE      = :f_language                                                                     ");
			sql.append("	  AND B.LANGUAGE      = :f_language                                                                     ");
		}
		if (!StringUtils.isEmpty(gwaName)) {
			sql.append("	  AND A.GWA_NAME      LIKE :f_gwa_name                                                                  ");
		}
		
		sql.append("	  AND A.ACTIVE_FLG    = '1'                                                                       			");
		sql.append("	  AND B.HOSP_CODE     = :f_hosp_code                                                                        ");
		sql.append("	  AND B.CODE_TYPE     = 'BUSEO_GUBUN'                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if (!StringUtils.isEmpty(language)) {
			query.setParameter("f_language", language);
		}
		if (!StringUtils.isEmpty(buseoName)) {
			query.setParameter("f_buseo_name", "%" + buseoName + "%");
		}
		if (!StringUtils.isEmpty(gwaName)) {
			query.setParameter("f_gwa_name", "%" + gwaName + "%");
		}
		
		/*if (!StringUtils.isEmpty(activeFlg)) {
			query.setParameter("f_active_flg", activeFlg);
		}*/
		
		query.setParameter("f_hosp_code", hospCode);
		if (!StringUtils.isEmpty(buseoGubun)) {
			query.setParameter("f_buseo_gubun", buseoGubun);
		}
		
		List<LoadGrdBAS0260U01Info> list = new JpaResultMapper().list(query, LoadGrdBAS0260U01Info.class);
		return list;
	}
	
	@Override
	public boolean isExistedBAS0260S(String buseoCode, String gwa, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'  									");
		sql.append("	FROM BAS0260S A                         	 	");
		sql.append("	WHERE A.BUSEO_CODE     = :f_buseo_code   		");
		sql.append("	AND A.GWA              = :f_gwa                 ");
		sql.append("	AND A.LANGUAGE         = :f_language            ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_buseo_code", buseoCode);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_language", language);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}
	
}


 

