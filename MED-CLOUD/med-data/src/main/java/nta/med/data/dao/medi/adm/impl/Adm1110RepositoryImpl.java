package nta.med.data.dao.medi.adm.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm1110RepositoryCustom;
import nta.med.data.model.ihis.adma.ADM201UGrdDicDetailOderListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Adm1110RepositoryImpl implements Adm1110RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Adm1110RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	public List<ADM201UGrdDicDetailOderListItemInfo> getADM201UGrdDicDetailOderListItemInfo (String colId, Integer startNum, Integer endNum, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 												 ");
		sql.append("	A.COL_ID,                                            ");
		sql.append("	A.CODE,                                              ");
		sql.append("	A.CODE_NM                                            ");
		sql.append("	FROM ADM1110 A                                       ");
		sql.append("	WHERE A.COL_ID = :f_col_id ORDER BY A.COL_ID, A.CODE ");
		sql.append(" AND A.LANGUAGE = :language                              ");
		sql.append("      LIMIT :startNum, :endNum 			        		 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_col_id", colId);
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);
		query.setParameter("language", language);
		List<ADM201UGrdDicDetailOderListItemInfo> list = new JpaResultMapper().list(query,ADM201UGrdDicDetailOderListItemInfo.class);
		return list;	
	}

	@Override
	public List<ComboListItemInfo> getComboUserGubun(boolean isAll, String language, String colId) {
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append(" SELECT '%', FN_ADM_MSG(221,:language)			                          ");
			sql.append(" UNION                                                                    ");
		}
		sql.append(" SELECT CODE, CODE_NM FROM ADM1110 WHERE COL_ID = :colId AND LANGUAGE = :language ORDER BY 1 "); 
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("colId", colId);
		query.setParameter("language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}
	
	
}

