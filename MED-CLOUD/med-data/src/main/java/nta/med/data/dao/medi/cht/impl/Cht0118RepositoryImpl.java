package nta.med.data.dao.medi.cht.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.cht.Cht0118;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cht.Cht0118Repository;
import nta.med.data.model.ihis.chts.CHT0117GrdCHT0118InitListItemInfo;
import nta.med.data.model.ihis.chts.CHT0117Q00GrdCHT0118Info;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
@Repository("cht0118Repository")
public class Cht0118RepositoryImpl extends SimpleJpaRepository<Cht0118, Long> implements Cht0118Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Cht0118RepositoryImpl(EntityManager entityManager) {
		super(Cht0118.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Cht0118Repository", allEntries = true)
	public Cht0118 save(Cht0118 entity) {
		return super.save(entity);
	}

	@CacheEvict(value = "Cht0118Repository", allEntries = true)
	public List<Cht0118> save(List<Cht0118> entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Cht0118Repository", allEntries = true)
	@Override
	public void delete(Cht0118 entity) {
		super.delete(entity);
	}
	
	@CacheEvict(value = "Cht0118Repository", allEntries = true)
	public Integer updateCHT0117TransactionalCht0118(
			Date endDateResult,
			String buwi,
			String subBuwi,
			Date endDate,
			String hospCode,
			String language){
		String sql = "	UPDATE Cht0118                        " 
					+"	   SET endDate  = :endDateResult      " 
					+"	 WHERE buwi     = :buwi               " 
					+"	 AND subBuwi    = :subBuwi            " 
					+"	 AND endDate    = :endDate            " 
					+"	 AND hospCode   = :hospCode  AND language = :language         ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("endDateResult", endDateResult);
		query.setParameter("buwi", buwi);
		query.setParameter("subBuwi", subBuwi);
		query.setParameter("endDate", endDate);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Cht0118Repository", allEntries = true)
	public Integer updateCHT0117TransactionalCht0118Modified(
			String updId,
			String subBuwiName,
			Double sortKey,
			String remark,
			Double nosaiJyRate,
			String buwi,
			String subBuwi,
			Date startDate,
			String hospCode,
			String language){
		String sql = "	UPDATE Cht0118                     "  
				+"	  SET updId         = :updId       " 
				+"	    , updDate       = SYSDATE()    " 
				+"	    , subBuwiName   = :subBuwiName " 
				+"	    , sortKey       = :sortKey     " 
				+"	    , remark        = :remark      " 
				+"	    , nosaiJyRate   = :nosaiJyRate " 
				+"	WHERE buwi          = :buwi        " 
				+"	  AND subBuwi       = :subBuwi   " 
				+"	  AND startDate     = :startDate   " 
				+"	  AND hospCode      = :hospCode  AND language = :language  ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("updId", updId);
		query.setParameter("subBuwiName", subBuwiName);
		query.setParameter("sortKey", sortKey);
		query.setParameter("remark", remark);
		query.setParameter("nosaiJyRate", nosaiJyRate);
		query.setParameter("buwi", buwi);
		query.setParameter("subBuwi", subBuwi);
		query.setParameter("startDate", startDate);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Cht0118Repository", allEntries = true)
	public Integer deleteCHT0117TransactionalCht0118Deleted(
			String buwi,
			String subBuwi,
			Date startDate,
			String hospCode,
			String language){
		String sql = "	DELETE FROM Cht0118                  " 
					+"	 WHERE buwi     = :buwi              " 
					+"	 AND subBuwi  	= :subBuwi           " 
					+"	 AND startDate  = :startDate         " 
					+"	 AND hospCode   = :hospCode    AND language = :language     ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("buwi", buwi);
		query.setParameter("subBuwi", subBuwi);
		query.setParameter("startDate", startDate);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@Override
	@Cacheable(value = "Cht0118Repository")
	public List<CHT0117GrdCHT0118InitListItemInfo> getCHT0117GrdCHT0118InitListItem(
			String hospCode, String language, String buwi, Date queryDate, Integer startNum, Integer endNum) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.START_DATE																				");
		sql.append("	     , A.END_DATE                                                                               ");
		sql.append("	     , A.BUWI                                                                                   ");
		sql.append("	     , A.SUB_BUWI                                                                               ");
		sql.append("	     , A.SUB_BUWI_NAME                                                                          ");
		sql.append("	     , A.SORT_KEY                                                                               ");
		sql.append("	     , A.REMARK                                                                                 ");
		sql.append("	     , CONCAT(A.SUB_BUWI , A.BUWI , DATE_FORMAT(A.START_DATE, '%Y/%m/%d'))  CONT_KEY            ");
		sql.append("	     , A.NOSAI_JY_RATE                                                                          ");
		sql.append("	     , ''			                                                                           ");
		sql.append("	  FROM CHT0118 A                                                                                ");
		sql.append("	 WHERE HOSP_CODE = :f_hosp_code  AND LANGUAGE = :language                                       ");
		sql.append("	   AND A.BUWI = :f_buwi                                                                         ");
		sql.append("	   AND :f_query_date BETWEEN A.START_DATE AND A.END_DATE                                        ");
		sql.append("	 ORDER BY CONT_KEY                                                                              ");
		sql.append("	 LIMIT :startNum, :endNum                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_buwi", buwi);
		query.setParameter("f_query_date", queryDate);
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);
		
		List<CHT0117GrdCHT0118InitListItemInfo> listResult = new JpaResultMapper().list(query, CHT0117GrdCHT0118InitListItemInfo.class);
		return listResult;
	}
	
	@Override
	@Cacheable(value = "Cht0118Repository")
	public String getCHT0117LayNextSubBuwiCd(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT LPAD(MAX(A.SUB_BUWI)+1,3,0) AS SUB_BUWI  ");
		sql.append("	FROM CHT0118 A                                  ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                ");
		sql.append("    AND A.LANGUAGE  = :language                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0)!= null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	@Cacheable(value = "Cht0118Repository")
	public String getCHT0117layCheckCht0118(String hospCode, String language,
			String buwi, String subBuwi, Date startDate) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'      						");                                        
		sql.append("	 FROM CHT0118                           ");
		sql.append("	WHERE BUWI        = :f_buwi             ");
		sql.append("	  AND SUB_BUWI    = :f_sub_buwi         ");
		sql.append("	  AND HOSP_CODE   = :hospCode           ");
		sql.append("      AND LANGUAGE    = :language           ");
		sql.append("	  AND START_DATE >= :f_start_date       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_buwi", buwi);
		query.setParameter("f_sub_buwi", subBuwi);
		query.setParameter("hospCode", hospCode);
		query.setParameter("f_start_date", startDate);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0)!= null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	@Cacheable(value = "Cht0118Repository")
	public List<CHT0117Q00GrdCHT0118Info> getCHT0117Q00GrdCHT0118Request(String hospCode, String language, String gubun, String buwi, String buwiName){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.BUWI              ,                                                    ");
		sql.append("       A.SUB_BUWI          ,                                                    ");
		sql.append("       A.SUB_BUWI_NAME     ,                                                    ");
		sql.append("       CONCAT(A.BUWI,TRIM(LPAD(A.SORT_KEY, 3, '0')),A.SUB_BUWI_NAME) CONT_KEY   ");
		sql.append("  FROM CHT0118 A                                                                ");
		sql.append(" WHERE :f_gubun        = '0'                                                    ");
		sql.append("   AND A.HOSP_CODE     = :hosp_code                                              ");
		sql.append("   AND A.LANGUAGE      = :language                                               ");
		sql.append("   AND A.BUWI          LIKE :f_buwi                                             ");
		sql.append("   AND A.SUB_BUWI_NAME LIKE :f_buwi_name                                        ");
		sql.append("   AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE                            ");
		sql.append("ORDER BY 4                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_buwi", buwi);
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_buwi_name", "%" + buwiName + "%");
		
		List<CHT0117Q00GrdCHT0118Info> listResult = new JpaResultMapper().list(query, CHT0117Q00GrdCHT0118Info.class);
		return listResult;
	}

	@Override
	public String getOCS2005U00BuwiName(String hospCode, String buwiCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.SUB_BUWI_NAME								");                                        
		sql.append("	  FROM CHT0118 A									");
		sql.append("	 WHERE A.HOSP_CODE     = :f_hosp_code				");
		sql.append("	   AND A.SUB_BUWI      = :f_buwi_code				");
		sql.append("	   AND SYSDATE() BETWEEN A.START_DATE AND A.END_DATE");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_buwi_code", buwiCode);
		query.setParameter("f_hosp_code", hospCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0)!= null){
			return result.get(0).toString();
		}
		return null;
	}
}

