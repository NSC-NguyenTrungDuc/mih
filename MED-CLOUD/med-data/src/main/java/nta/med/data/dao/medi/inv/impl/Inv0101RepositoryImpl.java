package nta.med.data.dao.medi.inv.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inv.Inv0101RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.Drg0102U01GrdMasterItemInfo;
import nta.med.data.model.ihis.invs.INV0101U01GridMasterInfo;

/**
 * @author dainguyen.
 */
public class Inv0101RepositoryImpl implements Inv0101RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getDRG0102U00GrdMasterInfo(String codeType, String codeTypeName, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE_TYPE       CODE_TYPE        ,      ");
		sql.append("       A.CODE_TYPE_NAME  CODE_TYPE_NAME          ");
		sql.append("  FROM INV0101 A                                 ");
		sql.append(" WHERE A.CODE_TYPE      LIKE :f_code_type        ");
		sql.append("   AND A.CODE_TYPE_NAME LIKE :f_code_type_name   ");
		sql.append("   AND A.ADMIN_GUBUN    = 'USER'                 ");
		sql.append("   AND A.LANGUAGE = :f_language                  ");
		sql.append(" ORDER BY 1                                      ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%" + codeType + "%");
		query.setParameter("f_code_type_name", "%" + codeTypeName + "%");
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getINV0101U00GrdMasterInfo(String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE_TYPE       CODE_TYPE        ,      ");
		sql.append("       A.CODE_TYPE_NAME  CODE_TYPE_NAME          ");
		sql.append("  FROM INV0101 A                                 ");
		sql.append(" WHERE A.CODE_TYPE      LIKE :f_code_type        ");
		sql.append("   AND A.ADMIN_GUBUN    = 'USER'                 ");
		sql.append("   AND A.LANGUAGE = :f_language                  ");
		sql.append(" ORDER BY 1                                      ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%" + codeType + "%");
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<Drg0102U01GrdMasterItemInfo> getDrg0102U01GrdMasterListItem(String codeType, String codeTypeName, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE_TYPE       CODE_TYPE						");
	    sql.append("	    , A.CODE_TYPE_NAME  CODE_TYPE_NAME                  ");
	    sql.append("	    , A.ADMIN_GUBUN     ADMIN_GUBUN                     ");
	    sql.append("	    , A.REMARK          REMARK                          ");
		sql.append("	 FROM INV0101 A                                         ");
		sql.append("	WHERE A.CODE_TYPE      LIKE :f_code_type                ");
		sql.append("	  AND A.CODE_TYPE_NAME LIKE :f_code_type_name           ");
		sql.append("      AND A.LANGUAGE = :f_language                          ");
		sql.append("	ORDER BY 1                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%" + codeType + "%");
		query.setParameter("f_code_type_name", "%" + codeTypeName + "%");
		query.setParameter("f_language", language);
			
		List<Drg0102U01GrdMasterItemInfo> list = new JpaResultMapper().list(query, Drg0102U01GrdMasterItemInfo.class);
		return list;
	}
	
	@Override
	public List<INV0101U01GridMasterInfo> getGridMasterInfo(String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT IFNULL(A.CODE_TYPE,' ')    CODE_TYPE,     			");
	    sql.append("	       IFNULL(A.CODE_TYPE_NAME,' ') CODE_TYPE_NAME,         ");
	    sql.append("		   A.ADMIN_GUBUN  ADMIN_GUBUN                			");
	    sql.append("	FROM INV0101 A                                              ");
		sql.append("	WHERE   A.CODE_TYPE LIKE :f_code_type                       ");
		sql.append("      AND A.LANGUAGE = :f_language                              ");
		sql.append("	ORDER BY A.CODE_TYPE;                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%" + codeType + "%");
		query.setParameter("f_language", language);	
		List<INV0101U01GridMasterInfo> list = new JpaResultMapper().list(query, INV0101U01GridMasterInfo.class);
		return list;
	}
	
	@Override
	public boolean isExistedINV0101(String codeType, String language) {
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'  											");
		sql.append("	FROM INV0101 A                       	 	    		");
		sql.append("	WHERE A.CODE_TYPE     = :f_code_type   		    	    ");
		sql.append("      AND A.LANGUAGE = :f_language                          ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);	
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		
		return false;
	}	
}

