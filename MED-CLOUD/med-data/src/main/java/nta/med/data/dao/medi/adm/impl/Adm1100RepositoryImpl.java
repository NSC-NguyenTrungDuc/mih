package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm1100RepositoryCustom;
import nta.med.data.model.ihis.adma.ADM201UGrdDicMasterListItemInfo;

/**
 * @author dainguyen.
 */
public class Adm1100RepositoryImpl implements Adm1100RepositoryCustom {
	private static Log LOG = LogFactory.getLog(Adm1100RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ADM201UGrdDicMasterListItemInfo> getADM201UGrdDicMasterListItemInfo(String colId, String colNm, Integer startNum, Integer endNum){
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 											    ");
		sql.append("	A.COL_ID,                                           ");
		sql.append("	A.COL_NM,                                           ");
		sql.append("	A.COL_TP,                                           ");
		sql.append("	A.COL_LEN,                                          ");
		sql.append("	A.COL_SCAL ,                                        ");
		sql.append("	A.CMMT                                              ");
		sql.append("	FROM ADM1100 A                                      ");
		sql.append("	WHERE A.COL_ID LIKE  :f_col_id                      ");
		sql.append("	AND A.COL_NM LIKE :f_col_nm                         ");		
		sql.append("  LIMIT :startNum, :endNum 	                            ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_col_id", "%" + colId + "%");
		query.setParameter("f_col_nm", "%" + colNm + "%");
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);	
		
		List<ADM201UGrdDicMasterListItemInfo> list = new JpaResultMapper().list(query,ADM201UGrdDicMasterListItemInfo.class);
		return list;
	}
	
}

