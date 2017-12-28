package nta.med.data.dao.medi.inv.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inv.Inv0102RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DRG3010P10PostLoadInfo;
import nta.med.data.model.ihis.drgs.Drg0102U01GrdDetailItemInfo;
import nta.med.data.model.ihis.drug.DRG0102U00GrdDetailInfo;
import nta.med.data.model.ihis.drug.DrugTripleListItemInfo;
import nta.med.data.model.ihis.invs.INV0101U01GridDetailInfo;
import nta.med.data.model.ihis.invs.LoadGrdDetailINV0101Info;
import nta.med.data.model.ihis.ocsa.OCS0208Q00LayTabGubunInfo;
import nta.med.data.model.ihis.system.LayConstantInfo;

/**
 * @author dainguyen.
 */
public class Inv0102RepositoryImpl implements Inv0102RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DRG0102U00GrdDetailInfo> getDRG0102U00GrdDetailInfo(String hospCode, String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT CODE_TYPE, CODE, CODE_NAME, CODE_VALUE ");
		sql.append("    FROM INV0102                                ");
		sql.append("   WHERE HOSP_CODE = :f_hosp_code               ");
		sql.append("     AND CODE_TYPE = :f_code_type               ");
		sql.append("     AND LANGUAGE  = :f_language                ");
		sql.append("  ORDER BY CODE                                 ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<DRG0102U00GrdDetailInfo> list = new JpaResultMapper().list(query, DRG0102U00GrdDetailInfo.class);
		return list;
	}
	
	@Override
	public List<DrugTripleListItemInfo> getTripleListItemInfo(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE                                        ");
		sql.append("     , A.CODE_NAME                                   ");
		sql.append("     , A.CODE_TYPE                                   ");
		sql.append("  FROM INV0102  A                                    ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                    ");
		sql.append("   AND A.CODE_TYPE IN ('35','UA','32','33','34')     ");
		sql.append("   AND A.CODE2 = 'A'                                 ");
		sql.append("   AND A.LANGUAGE  = :f_language                     ");
		sql.append(" ORDER BY A.HOSP_CODE, A.CODE_TYPE, A.CODE           ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<DrugTripleListItemInfo> list = new JpaResultMapper().list(query, DrugTripleListItemInfo.class);
		return list;
	}

	@Override
	public List<LayConstantInfo> getLayConstantInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME, CODE_VALUE     ");
		sql.append(" FROM INV0102                           ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code         ");
		sql.append(" AND CODE_TYPE = 'DRG_CONSTANT'         ");
		sql.append(" AND LANGUAGE  = :f_language            ");
		sql.append(" ORDER BY CODE							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<LayConstantInfo> list = new JpaResultMapper().list(query, LayConstantInfo.class);
		return list;
	}

	@Override
	public List<OCS0208Q00LayTabGubunInfo> getOCS0208Q00LayTabGubunInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME, CODE3      ");
		sql.append(" FROM INV0102                       ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code     ");
		sql.append(" AND CODE_TYPE = '35'               ");
		sql.append(" AND LANGUAGE  = :f_language        ");
		sql.append(" ORDER BY CODE						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<OCS0208Q00LayTabGubunInfo> list = new JpaResultMapper().list(query, OCS0208Q00LayTabGubunInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getComboListItemInfoOCS0208Q01GrdDrg0120(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME                     ");
		sql.append(" FROM INV0102                               ");
		sql.append(" WHERE HOSP_CODE=:f_hosp_code               ");
		sql.append(" AND CODE_TYPE = '32' AND CODE2     = 'A'   ");
		sql.append(" AND LANGUAGE  = :f_language                ");
		sql.append(" ORDER BY CODE								");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	@Override
	public List<ComboListItemInfo> getDRG0120U00ComboListItem(String hospCode,
			String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE									");
		sql.append("	     , A.CODE_NAME                              ");
		sql.append("	  FROM INV0102  A                               ");
		sql.append("	 WHERE A.HOSP_CODE       = :hospCode            ");
		sql.append("	   AND A.CODE_TYPE       = :f_code_type         ");
		sql.append("	   AND A.CODE2           = 'A'                  ");
		sql.append("       AND A.LANGUAGE        = :f_language          ");
		sql.append("	 ORDER BY A.HOSP_CODE, A.CODE_TYPE, A.CODE      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<Drg0102U01GrdDetailItemInfo> getDrg0102U01GrdDetailListItem(
			String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE_TYPE 									");			
		sql.append("	     , A.CODE                                       ");
		sql.append("	     , A.CODE2                                      ");
		sql.append("	     , A.CODE_NAME                                  ");
		sql.append("	     , A.CODE_VALUE                                 ");
		sql.append("	     , A.REMARK                                     ");
		sql.append("	  FROM INV0102 A                                    ");
		sql.append("	 WHERE A.HOSP_CODE         = :f_hosp_code           ");
		sql.append("	   AND A.CODE_TYPE         = :f_code_type           ");
		sql.append("       AND A.LANGUAGE  		   = :f_language            ");
		sql.append("	 ORDER BY A.HOSP_CODE, A.CODE_TYPE, A.CODE          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<Drg0102U01GrdDetailItemInfo> list = new JpaResultMapper().list(query, Drg0102U01GrdDetailItemInfo.class);
		return list;
	}

	@Override
	public String getDRG5100P01CheckActInfo(String hospCode, String codeType, 
			String code, String codeName, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE_VALUE                                 ");
		sql.append("	  FROM INV0102 A                                    ");
		sql.append("	 WHERE A.HOSP_CODE         = :f_hosp_code           ");
		sql.append("	   AND A.CODE_TYPE         = :f_code_type           ");
		sql.append("	   AND A.CODE         	   = :f_code     	        ");
		sql.append("	   AND A.CODE_NAME         = :f_code_name           ");
		sql.append("       AND A.LANGUAGE  		   = :f_language            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		query.setParameter("f_code_name", codeName);
		query.setParameter("f_language", language);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getINV4001U00LoadCodeName(String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.CODE                      ");
		sql.append("      , B.CODE_NAME                 ");
		sql.append("   FROM INV0102 B , INV0101 A       ");
		sql.append("  WHERE B.HOSP_CODE = :hosp_code    ");
		sql.append("    AND A.CODE_TYPE = :code_type   ");
		sql.append("    AND B.CODE_TYPE = A.CODE_TYPE   ");
		sql.append("    AND A.LANGUAGE  = :f_language   ");
		sql.append("    AND B.LANGUAGE  = A.LANGUAGE    ");
		sql.append("  ORDER BY B.SORT_KEY				");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("code_type", codeType);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<LoadGrdDetailINV0101Info> getGrdDetailINV0101Info(String hospCode, String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT CODE_TYPE, CODE, IFNULL(CODE_NAME, ''), IFNULL(SORT_KEY, ''), IFNULL(CODE2, ''), IFNULL(CODE3, ''), IFNULL(REMARK, '')		");
		sql.append("  FROM INV0102                                																						");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code               																						");
		sql.append("    AND CODE_TYPE = :f_code_type               																						");
		sql.append("    AND LANGUAGE  = :f_language               																						");
		sql.append("  ORDER BY SORT_KEY, 2, 3																											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<LoadGrdDetailINV0101Info> listData = new JpaResultMapper().list(query, LoadGrdDetailINV0101Info.class);
		return listData;		
	}
	
	@Override
	public List<INV0101U01GridDetailInfo> getGridDetailInfo(String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT IFNULL(A.CODE_TYPE,' ')    CODE_TYPE,     							");
		sql.append("	       IFNULL(A.CODE,' ') CODE,         									");
	    sql.append("	       IFNULL(A.CODE_NAME,' ') CODE_NAME,         							");
	    sql.append("		   A.SORT_KEY,                											");
	    sql.append("		   CONCAT(TRIM(IFNULL(A.CODE_TYPE,' ')),TRIM(IFNULL(A.CODE,' ')))       ");
	    sql.append("	FROM INV0102 A                                              				");
		sql.append("	WHERE   A.CODE_TYPE LIKE :f_code_type                       				");
		sql.append("	      AND   A.HOSP_CODE = :f_hosp_code                       				");
		sql.append("    	  AND A.LANGUAGE    = :f_language   									");
		sql.append("	ORDER BY A.SORT_KEY, A.CODE, A.CODE_NAME                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", "%" + codeType + "%");
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
			
		List<INV0101U01GridDetailInfo> list = new JpaResultMapper().list(query, INV0101U01GridDetailInfo.class);
		return list;
	}
	
	@Override
	public List<LayConstantInfo> getLayConstantInfo(String hospCode, String language, String codeType) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME, CODE_VALUE     ");
		sql.append(" FROM INV0102                           ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code         ");
		sql.append(" AND CODE_TYPE   = :f_code_type         ");
		sql.append(" AND LANGUAGE    = :f_language          ");
		sql.append(" ORDER BY CODE							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<LayConstantInfo> list = new JpaResultMapper().list(query, LayConstantInfo.class);
		return list;
	}

	@Override
	public List<DRG3010P10PostLoadInfo> getDRG3010P10PostLoadInfo(String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT											");
		sql.append("		CODE, CODE_NAME, CODE_VALUE					");
		sql.append("	FROM											");
		sql.append("		INV0102										");
		sql.append("	WHERE											");
		sql.append("		HOSP_CODE 		= :f_hosp_code				");
		sql.append("		AND CODE_TYPE 	= 'DRG_CONSTANT'			");
		sql.append("	ORDER BY										");
		sql.append("		CODE										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);

		List<DRG3010P10PostLoadInfo> listInfo = new JpaResultMapper().list(query, DRG3010P10PostLoadInfo.class);
		return listInfo;
	}
	
}

