package nta.med.data.dao.medi.cpl.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl0108RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL0108U00InitGrdMasterListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0108U01GrdMasterItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl0108RepositoryImpl implements Cpl0108RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CPL0108U00InitGrdMasterListItemInfo> getListCPL0108U00GrdMaster(String hospCode, String language, String codeTypeName) {
		StringBuilder sql = new StringBuilder();
		
		 sql.append("	SELECT A.CODE_TYPE       CODE_TYPE        ,						");
		 sql.append("	      A.CODE_TYPE_NAME  CODE_TYPE_NAME                          ");
		 sql.append("	 FROM CPL0108 A                                                 ");
		 sql.append("	WHERE   A.CODE_TYPE_NAME LIKE CONCAT('%',:codeTypeName,'%')     ");
		 sql.append("	  AND A.ADMIN_GUBUN = 'USER' AND A.LANGUAGE = :language         ");
		 sql.append("	ORDER BY 1                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("codeTypeName", codeTypeName);
		query.setParameter("language", language);
		
		List<CPL0108U00InitGrdMasterListItemInfo> listResult = new JpaResultMapper().list(query, CPL0108U00InitGrdMasterListItemInfo.class);
		return listResult;
	}
	
	@Override
	public String getCheckItemGrdMaster(String hospCode, String language, String codeType) {
		StringBuilder sql = new StringBuilder();

		sql.append("	 SELECT 'X'							");
		sql.append("	 FROM CPL0108                      " );
		sql.append("	WHERE CODE_TYPE = :codeType     	");
		sql.append(" AND LANGUAGE = :language               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			 return result.get(0);
		}
		return null;
	}

	@Override
	public List<CPL0108U01GrdMasterItemInfo> getCPL0108U01grdMasterItemInfo(String hospCode, String language, String codeType, String codeTypeName) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE       CODE_TYPE        ,                    ");
		sql.append("        A.CODE_TYPE_NAME  CODE_TYPE_NAME,                       ");
		sql.append("        A.ADMIN_GUBUN     ADMIN_GUBUN                           ");
		sql.append("   FROM CPL0108 A                                               ");
		sql.append("  WHERE     A.CODE_TYPE      LIKE :f_code_type                  ");
		sql.append("    AND A.CODE_TYPE_NAME LIKE :f_code_type_name                 ");
		sql.append(" AND A.LANGUAGE = :language                                     ");
		sql.append(" ORDER BY 1														");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%"+codeType+"%");
		query.setParameter("f_code_type_name","%"+ codeTypeName+"%");
		query.setParameter("language", language);
		List<CPL0108U01GrdMasterItemInfo> listResult = new JpaResultMapper().list(query, CPL0108U01GrdMasterItemInfo.class);
		return listResult;
	}
}

