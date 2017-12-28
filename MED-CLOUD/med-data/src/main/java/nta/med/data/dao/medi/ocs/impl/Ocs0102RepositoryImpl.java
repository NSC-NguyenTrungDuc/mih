package nta.med.data.dao.medi.ocs.impl;

import nta.med.core.domain.ocs.Ocs0102;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0101U00GrdOcs0102ListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U11LaySlipCodeTreeListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U16SlipCodeTreeInfo;
import nta.med.data.model.ihis.system.OCS0103U12GrdGeneralInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import java.util.List;

/**
 * @author dainguyen.
 */
@Repository
public class Ocs0102RepositoryImpl extends SimpleJpaRepository<Ocs0102, Long>  implements Ocs0102Repository {
	@PersistenceContext
	private EntityManager entityManager;
	@Autowired
	public Ocs0102RepositoryImpl(EntityManager entityManager) {
		super(Ocs0102.class, entityManager);

	}
	@Override
	public List<OCS0101U00GrdOcs0102ListItemInfo> getOCS0101U00GrdOcso0102InitListItem(
			String hospCode, String slipGubun, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SLIP_GUBUN,																		");
		sql.append("	       A.SLIP_CODE,                                                                         ");
		sql.append("	       A.SLIP_NAME,                                                                         ");
		sql.append("	       IF( IFNULL(B.CNT, 0) = 0, 'N', 'Y') SPECIMEN_EXT,                                    ");
		sql.append("	       ''                                  												    ");
		sql.append("	  FROM (SELECT I.SLIP_CODE,                                                                 ");
		sql.append("	               :hospCode,                                                                 	");
		sql.append("	               COUNT(I.SLIP_CODE) CNT                                                       ");
		sql.append("	          FROM OCS0106 I                                                                    ");
		sql.append("	         GROUP BY I.SLIP_CODE, :hospCode) B                                              	");
		sql.append("	         RIGHT JOIN OCS0102 A ON  B.SLIP_CODE = A.SLIP_CODE  AND :hospCode = A.HOSP_CODE  	");
		sql.append("	 WHERE  A.SLIP_GUBUN   = :slipGubun                                                         ");
		sql.append("	   AND A.HOSP_CODE    = :hospCode                                                           ");
		sql.append("	   AND A.LANGUAGE    = :language                                                            ");
		sql.append("	 ORDER BY A.SLIP_CODE                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("slipGubun", slipGubun);
		query.setParameter("language", language);
		
		List<OCS0101U00GrdOcs0102ListItemInfo> list = new JpaResultMapper().list(query, OCS0101U00GrdOcs0102ListItemInfo.class);
		return list;
	}
	
	@Override
	@Cacheable(value = "Ocs0102Repository")
	public String getOCS0101U00Grd0102CheckData(String hospCode, String value, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'              			");
		sql.append("	  FROM OCS0102                      ");
		sql.append("	 WHERE SLIP_CODE = :value        	");
		sql.append("	   AND HOSP_CODE  = :hospCode    	");
		sql.append("	   AND LANGUAGE  = :language    	");
		sql.append("	   LIMIT 1                       	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("value", value);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS0103U16SlipCodeTreeInfo> getOCS0103U16SlipCodeTree(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT C.SLIP_CODE , C.SLIP_NAME, E.XRAY_BUWI , F.BUWI_NAME, 'Y'            XRAY_CODE_YN          ");
		sql.append("      , CONCAT(IFNULL(C.SLIP_CODE,'') , TRIM(LPAD(F.SORT_SEQ,7,'0'))) ORDERBYKEY                            ");
		sql.append("   FROM OCS0142 A  , OCS0103 B , OCS0102 C , OCS0101 D, XRT0001 E , XRT0122 F                               ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                                                                       ");
		sql.append("    AND A.INPUT_TAB    = '07'                                                                               ");
		sql.append("    AND A.MAIN_YN      = 'Y'                                                                                ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE                                                                        ");
		sql.append("    AND B.ORDER_GUBUN  = A.ORDER_GUBUN                                                                      ");
		sql.append("    AND C.HOSP_CODE    = B.HOSP_CODE                                                                        ");
		sql.append("    AND C.SLIP_CODE    = B.SLIP_CODE                                                                        ");
		sql.append("    AND D.SLIP_GUBUN   = C.SLIP_GUBUN                                                                       ");
		sql.append("    AND E.HOSP_CODE    = B.HOSP_CODE                                                                        ");
		sql.append("    AND E.XRAY_CODE    = B.HANGMOG_CODE                                                                     ");
		sql.append("    AND F.BUWI_CODE    = E.XRAY_BUWI                                                                        ");
		sql.append("    AND F.HOSP_CODE    = E.HOSP_CODE                                                                        ");
		sql.append("    AND F.LANGUAGE     = D.LANGUAGE                                                                        ");
		sql.append("    AND F.LANGUAGE     = :f_language                                                                        ");
		sql.append("  UNION ALL                                                                                                 ");
//		sql.append(" SELECT DISTINCT  D.SLIP_GUBUN , D.SLIP_GUBUN_NAME, C.SLIP_CODE, C.SLIP_NAME                                ");
//		sql.append("      , 'N'          XRAY_CODE_YN                                                                           ");
//		sql.append("      , CONCAT(IFNULL(D.SLIP_GUBUN,''),IFNULL(C.SLIP_CODE,''))    ORDERBYKEY                                ");
//		sql.append("   FROM OCS0142 A, OCS0103 B , OCS0102 C , OCS0101 D                                                        ");
//		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                                        ");
//		sql.append("    AND A.INPUT_TAB   = '07'                                                                                ");
//		sql.append("    AND A.MAIN_YN     = 'N'                                                                                 ");
//		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                                         ");
//		sql.append("    AND B.ORDER_GUBUN = A.ORDER_GUBUN                                                                       ");
//		sql.append("    AND C.HOSP_CODE   = B.HOSP_CODE                                                                         ");
//		sql.append("    AND C.SLIP_CODE   = B.SLIP_CODE                                                                         ");
//		sql.append("    AND D.SLIP_GUBUN  = C.SLIP_GUBUN                                                                        ");
//		sql.append("  ORDER BY 5 DESC , ORDERBYKEY																				");
		sql.append("  SELECT  DISTINCT                                                                                                          ");
		sql.append("        D.SLIP_GUBUN, D.SLIP_GUBUN_NAME, C.SLIP_CODE, C.SLIP_NAME, 'N' XRAY_CODE_YN,                                        ");
		sql.append("        CONCAT(IFNULL(D.SLIP_GUBUN, ''), IFNULL(C.SLIP_CODE, '')) ORDERBYKEY                                                ");
		sql.append(" FROM   OCS0102 C                                                                                                           ");
		sql.append("        inner join OCS0101 D on C.HOSP_CODE = :f_hosp_code and D.SLIP_GUBUN = C.SLIP_GUBUN AND D.LANGUAGE = C.LANGUAGE AND D.LANGUAGE = :f_language    ");
		sql.append("        inner join OCS0103 B on B.HOSP_CODE = C.HOSP_CODE and B.SLIP_CODE = C.SLIP_CODE                                     ");
		sql.append(" WHERE  C.HOSP_CODE = :f_hosp_code AND EXISTS                                                                               ");
		sql.append("          (     select 1                                                                                                    ");
		sql.append("              from   OCS0142 A                                                                                              ");
		sql.append("           where  A.INPUT_TAB = '07' AND A.MAIN_YN = 'N' AND A.HOSP_CODE = :f_hosp_code AND B.ORDER_GUBUN = A.ORDER_GUBUN)  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<OCS0103U16SlipCodeTreeInfo> list = new JpaResultMapper().list(query, OCS0103U16SlipCodeTreeInfo.class);
		return list;
	}
	@Override
	public List<OCS0103U12GrdGeneralInfo> getOCS0103U12GrdGeneralListItem(
			String hospCode, String filter, String yakKijunCode,
			String orderDate, String hangmogCode, Integer startNum, Integer offset, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT  A.SLIP_CODE																						");
		sql.append("	      , B.SLIP_NAME                                                                                     ");
		sql.append("	      , A.HANGMOG_CODE                                                                                  ");
		sql.append("	      , A.HANGMOG_NAME                                                                                  ");
		sql.append("	      , IFNULL(A.WONNAE_DRG_YN, 'N') WONNAE_DRG_YN                                                      ");
		sql.append("	   FROM OCS0102 B                                                                                       ");
		sql.append("	      , OCS0103 A                                                                                       ");
		sql.append("	  WHERE A.HOSP_CODE   = :hospCode                                                                       ");
		sql.append("	    AND SUBSTR(A.YAK_KIJUN_CODE, 1, :filter) = SUBSTR(:yakKijunCode, 1, :filter)                        ");
		sql.append("	    AND IFNULL(STR_TO_DATE(:orderDate, '%Y/%m/%d'), SYSDATE()) BETWEEN A.START_DATE AND A.END_DATE      ");
		sql.append("	    AND IFNULL(A.WONNAE_DRG_YN,'N') = 'Y'                                                               ");
		sql.append("	    AND A.ORDER_GUBUN = 'B'                                                                             ");
		sql.append("	    AND A.HANGMOG_CODE != :hangmogCode                                                                  ");
		sql.append("	    AND B.HOSP_CODE   = A.HOSP_CODE                                                                     ");
		sql.append("	    AND B.SLIP_CODE   = A.SLIP_CODE                                                                     ");
		sql.append("	    AND B.LANGUAGE   = :language                                                                     	");
		sql.append("     AND IFNULL(A.COMMON_YN, 'N') != 'Y'                                                                    ");
		sql.append("	  ORDER BY 1, 3                                                                                         ");
		sql.append("	  limit :startNum, :offset                                                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("filter", filter);
		query.setParameter("yakKijunCode", yakKijunCode);
		query.setParameter("orderDate", orderDate);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("startNum", startNum);
		query.setParameter("offset", offset);
		query.setParameter("language", language);
		
		 List<OCS0103U12GrdGeneralInfo> listResult = new JpaResultMapper().list(query, OCS0103U12GrdGeneralInfo.class);
		 return listResult;
	}

	@Override
	@Cacheable(value = "Ocs0102Repository")
	public String getLoadColumnCodeNameSlipCodeCase(String slipCode,
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.SLIP_NAME 					");
		sql.append("	 FROM OCS0102 A                     ");
		sql.append("	WHERE A.SLIP_CODE = :slipCode       ");
		sql.append("	  AND A.HOSP_CODE = :hospCode       ");
		sql.append("	  AND A.LANGUAGE = :language       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("slipCode", slipCode);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS0103U11LaySlipCodeTreeListItemInfo> getOCS0103U11LaySlipCodeTreeList(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                    ");
		sql.append("        D.SLIP_GUBUN                                                                ");
		sql.append("      , D.SLIP_GUBUN_NAME                                                           ");
		sql.append("      , C.SLIP_CODE                                                                 ");
		sql.append("      , C.SLIP_NAME                                                                 ");
		sql.append("      , CONCAT(IFNULL(D.SLIP_GUBUN,'') , IFNULL(C.SLIP_CODE,''))    ORDERBYKEY      ");
		sql.append("   FROM OCS0142 A                                                                   ");
		sql.append("      , OCS0103 B                                                                   ");
		sql.append("      , OCS0102 C                                                                   ");
		sql.append("      , OCS0101 D                                                                   ");
		sql.append("  WHERE A.HOSP_CODE   = :f_hosp_code                                                ");
		sql.append("    AND A.INPUT_TAB   = '10'                                                        ");
		sql.append("    AND A.MAIN_YN     = 'Y'                                                         ");
		sql.append("    AND B.HOSP_CODE   = A.HOSP_CODE                                                 ");
		sql.append("    AND B.ORDER_GUBUN = A.ORDER_GUBUN                                               ");
		sql.append("    AND C.HOSP_CODE   = B.HOSP_CODE                                                 ");
		sql.append("    AND C.SLIP_CODE   = B.SLIP_CODE                                                 ");
		sql.append("    AND D.SLIP_GUBUN  = C.SLIP_GUBUN                                                ");
		sql.append("    AND D.LANGUAGE  = C.LANGUAGE                                                	");
		sql.append("    AND D.LANGUAGE  = :f_language                                                	");
		sql.append("  ORDER BY 1 , ORDERBYKEY															");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		 List<OCS0103U11LaySlipCodeTreeListItemInfo> listResult = new JpaResultMapper().list(query, OCS0103U11LaySlipCodeTreeListItemInfo.class);
		 return listResult;
	}

	@Override
	@Cacheable(value = "Ocs0102Repository")
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String slipGubun, boolean isSlipGubun, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SLIP_CODE                         ");
		sql.append("      , A.SLIP_NAME                         ");
		sql.append("   FROM OCS0102 A                           ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code          ");
		sql.append("  AND  A.LANGUAGE = :language          	    ");
		if(isSlipGubun){
			sql.append("    AND A.SLIP_GUBUN LIKE :f_slip_gubun     ");
		}
		sql.append("  ORDER BY A.SLIP_CODE 						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		if(isSlipGubun){
			if(StringUtils.isEmpty(slipGubun)){
				slipGubun = "%";
			}
			query.setParameter("f_slip_gubun", slipGubun);
		}
		 List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		 return listResult;
	}

	@Override
	@CacheEvict(value = "Ocs0102Repository", allEntries = true)
	public Integer updateOcs0101U00Ocs0102Modified(String updId, String slipName,
												   String slipGubun, String slipCode, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
        sql.append(" UPDATE OCS0102					");
        sql.append(" SET UPD_ID = :updId ,			");
        sql.append(" UPD_DATE= SYSDATE(),			");
        sql.append(" SLIP_NAME = :slipName          ");
        sql.append(" WHERE SLIP_GUBUN  = :slipGubun ");
        sql.append(" AND SLIP_CODE = :slipCode      ");
        sql.append(" AND HOSP_CODE = :hospCode      ");
        sql.append(" AND LANGUAGE = :language       ");
		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("updId", updId);
		query.setParameter("slipName", slipName);
		query.setParameter("slipGubun", slipGubun);
		query.setParameter("slipCode", slipCode);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);

		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Ocs0102Repository", allEntries = true)
	public Integer deleteOcs0101U00Ocs0102Deleted(String slipGubun, String slipCode, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" DELETE FROM OCS0102             ");
		sql.append(" WHERE SLIP_GUBUN = :slipGubun   ");
		sql.append(" AND SLIP_CODE  = :slipCode      ");
		sql.append(" AND HOSP_CODE  = :hospCode      ");
		sql.append(" AND LANGUAGE = :language        ");

		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("slipGubun", slipGubun);
		query.setParameter("slipCode", slipCode);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		return query.executeUpdate();
	}

	@Override
	@CacheEvict(value = "Ocs0102Repository", allEntries = true)
	public Ocs0102 save(Ocs0102 ocs0102) {
		return super.save(ocs0102);
	}
	@CacheEvict(value = "Ocs0102Repository", allEntries = true)
	public void delete (Ocs0102 ocs0102)
	{
		 super.delete(ocs0102);
	}
	@Override
	@CacheEvict(value = "Ocs0102Repository", allEntries = true)
	public List<Ocs0102> save(List<Ocs0102> entities) {
		return super.save(entities);
	}
}

