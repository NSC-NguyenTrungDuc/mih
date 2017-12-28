package nta.med.data.dao.medi.bas.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0101RepositoryCustom;
import nta.med.data.model.ihis.adma.BAS0101U04GrdMasterInfo;
import nta.med.data.model.ihis.bass.BAS0101U00PrBasGridColumnChangedItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Bas0101RepositoryImpl implements Bas0101RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<ComboListItemInfo> listGrdMaster(String hospCode, String language, String codeType) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE, A.CODE_TYPE_NAME FROM BAS0101 A WHERE                         							                           ");
		sql.append("  A.CODE_TYPE LIKE CONCAT('%',IFNULL(:f_code_type,''), '%') AND A.ADMIN_GUBUN = 'USER' AND A.LANGUAGE = :language ORDER BY A.CODE_TYPE ");
		Query query =entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType);
		query.setParameter("language", language);
		List<ComboListItemInfo> listGrdMaster = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listGrdMaster;
	}
	
	@Override
	public BAS0101U00PrBasGridColumnChangedItemInfo callPrBasGridColumnChanged(String hospCode,String language, String masterCheck, String codeType, String colId) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OUT_CHECK_DUP_BAS0101");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_LANGUAGE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_MASTER_CHECK", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CODE_TYPE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_COL_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_DUP_YN", String.class, ParameterMode.OUT);
		query.registerStoredProcedureParameter("IO_ERROR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_LANGUAGE", language);
		query.setParameter("I_MASTER_CHECK", masterCheck);
		query.setParameter("I_CODE_TYPE", codeType);
		query.setParameter("I_COL_ID", colId);
		
		query.execute();
		BAS0101U00PrBasGridColumnChangedItemInfo info = new BAS0101U00PrBasGridColumnChangedItemInfo();
		info.setDupYn((String)query.getOutputParameterValue("O_DUP_YN"));
		info.setError((String)query.getOutputParameterValue("IO_ERROR"));
		return info;
	}
	
	@Override
	public List<ComboListItemInfo> getListBAS0001U00grdMaster(String hospCode, String language, String codeType) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE , A.CODE_TYPE_NAME                      ");
		sql.append("  FROM BAS0101 A                                            ");
		sql.append(" WHERE       A.CODE_TYPE LIKE  :f_code_type                  ");
		sql.append("  AND A.ADMIN_GUBUN = 'USER'                               ");
		sql.append("  AND A.LANGUAGE  = :language                              ");
		sql.append(" ORDER BY A.CODE_TYPE										");
		Query query =entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%" + codeType + "%");
		query.setParameter("language", language);
		
		List<ComboListItemInfo> listGrdMaster = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listGrdMaster;
	}
	
	@Override
	public String getBas0101U00TransactionAddedChk(String hospCode, String language, String codeType) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'								");
	    sql.append("	FROM BAS0101                            ");
	    sql.append("	WHERE CODE_TYPE = :f_code_type          ");
	    sql.append("    AND LANGUAGE = :language                ");
	    sql.append("	AND LIMIT 1                             ");
	    			
	    Query query =entityManager.createNativeQuery(sql.toString());
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		
		List<Object> list = query.getResultList();
		if(CollectionUtils.isEmpty(list) && list.get(0) != null){
			return list.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<BAS0101U04GrdMasterInfo> getBAS0101U04GrdMasterInfo(String hospCode, String language, String codeType, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE                   ");
		sql.append("      , A.CODE_TYPE_NAME              ");
		sql.append("      , A.ADMIN_GUBUN                 ");
		sql.append("  FROM BAS0101 A                      ");
		sql.append(" WHERE  A.CODE_TYPE LIKE :f_code_type  ");
		sql.append("   AND A.CODE_TYPE <> 'ZZ_DEBUG'      ");
		sql.append("   AND A.LANGUAGE = :language         ");
		sql.append(" ORDER BY A.CODE_TYPE                 ");
		sql.append(" LIMIT :startNum, :offset			  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%" + codeType + "%");
		query.setParameter("language", language);
		query.setParameter("startNum", startNum);
		query.setParameter("offset", offset);
		
		List<BAS0101U04GrdMasterInfo> listGrdMaster = new JpaResultMapper().list(query, BAS0101U04GrdMasterInfo.class);
		return listGrdMaster;
	}
	
	@Override
	public List<ComboListItemInfo> getListDRGOCSCHKLoadCbxCHK(String hospCode, String language) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT '','なし'                      					");
		sql.append("  FROM DUAL                                             ");
		sql.append(" UNION                  								");
		sql.append("  SELECT B.CODE , B.CODE_NAME                           ");
		sql.append("  FROM BAS0102 B                              			");
		sql.append(" 	 , BAS0101 A										");
		sql.append(" WHERE A.CODE_TYPE = 'SUBUL_CONV_CODE'                  ");
		sql.append("  AND B.HOSP_CODE = :f_hosp_code						");
		sql.append("  AND A.LANGUAGE  = :f_language							");
		sql.append("  AND A.LANGUAGE  = B.LANGUAGE							");
		sql.append("  AND B.CODE_TYPE = A.CODE_TYPE							");
		Query query =entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> listDRGOCSCHK = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listDRGOCSCHK;
	}
}

