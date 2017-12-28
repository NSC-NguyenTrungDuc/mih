package nta.med.data.dao.medi.cht.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.cht.Cht0117;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cht.Cht0117Repository;
import nta.med.data.model.ihis.chts.CHT0117GrdCHT0117InitListItemInfo;
import nta.med.data.model.ihis.chts.CHT0117Q00DloCHT0117Info;

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
@Repository("cht0117Repository")
public class Cht0117RepositoryImpl extends SimpleJpaRepository<Cht0117, Long> implements Cht0117Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Cht0117RepositoryImpl(EntityManager entityManager) {
		super(Cht0117.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Cht0117Repository", allEntries = true)
	public Cht0117 save(Cht0117 entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Cht0117Repository", allEntries = true)
	public List<Cht0117> save(List<Cht0117> entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Cht0117Repository", allEntries = true)
	@Override
	public void delete(Cht0117 entity) {
		super.delete(entity);
	}
	
	@CacheEvict(value = "Cht0117Repository", allEntries = true)
	public Integer updateCHT0117Transactional(
			Date endDateResult,
			String buwi,
			Date endDate,
			String hospCode,
			String language){
		String sql = "	UPDATE Cht0117                      " 
				+"	   SET endDate = :endDateResult     " 
				+"	 WHERE buwi     = :buwi             " 
				+"	   AND endDate = :endDate           " 
				+"	 AND hospCode = :hospCode      AND language = :language     ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("endDateResult", endDateResult);
		query.setParameter("buwi", buwi);
		query.setParameter("endDate", endDate);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Cht0117Repository", allEntries = true)
	public Integer updateCHT0117TransactionalModified(
			String updId,
			String buwiName,
			Double sortKey,
			String remark,
			String buwi,
			Date startDate,
			String hospCode,
			String language){
		String sql = "	UPDATE Cht0117                     "  
				+"	  SET updId         = :updId       " 
				+"	    , updDate       = SYSDATE()    " 
				+"	    , buwiName      = :buwiName    " 
				+"	    , sortKey       = :sortKey     " 
				+"	    , remark        = :remark     " 
				+"	WHERE buwi          = :buwi       " 
				+"	  AND startDate     = :startDate   " 
				+"	  AND hospCode      = :hospCode  AND language = :language  ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("updId", updId);
		query.setParameter("buwiName", buwiName);
		query.setParameter("sortKey", sortKey);
		query.setParameter("remark", remark);
		query.setParameter("buwi", buwi);
		query.setParameter("startDate", startDate);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		return query.executeUpdate();
	}

	@CacheEvict(value = "Cht0117Repository", allEntries = true)
	public Integer deleteCHT0117TransactionalDeleted(
			String buwi,
			Date startDate,
			String hospCode,
			String language){
		String sql = "	DELETE FROM Cht0117                  " 
				+"	 WHERE buwi        = :buwi           " 
				+"	 AND startDate  = :startDate         " 
				+"	 AND hospCode   = :hospCode  AND   language = :language     ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("buwi", buwi);
		query.setParameter("startDate", startDate);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@Override
	@Cacheable(value = "Cht0117Repository")
	public List<CHT0117GrdCHT0117InitListItemInfo> getCHT0117GrdCHT0117InitListItem(
			String hospCode, String language, Date queryDate, String searchWord, Integer startNum, Integer endNum) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.START_DATE																");
		sql.append("	     , A.END_DATE                                                               ");
		sql.append("	     , A.BUWI                                                                   ");
		sql.append("	     , A.BUWI_NAME                                                              ");
		sql.append("	     , A.SORT_KEY                                                               ");
		sql.append("	     , A.REMARK                                                                 ");
		sql.append("	     , CONCAT(A.BUWI , DATE_FORMAT(A.START_DATE, '%Y/%m/%d'))  CONT_KEY         ");
		sql.append("	  	 , ''                                                               		");
		sql.append("	  FROM CHT0117 A                                                                ");
		sql.append("	 WHERE HOSP_CODE = :f_hosp_code AND LANGUAGE = :language                        ");
		sql.append("	   AND :f_query_date BETWEEN A.START_DATE AND A.END_DATE                        ");
		sql.append("	   AND  CONCAT(A.BUWI , A.BUWI_NAME) LIKE :f_search_word            			");
		sql.append("	 ORDER BY CONT_KEY                                                              ");
		sql.append("	 LIMIT :startNum, :endNum                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_query_date", queryDate);
		query.setParameter("f_search_word","%"+ searchWord + "%");
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);
		
		List<CHT0117GrdCHT0117InitListItemInfo> list = new JpaResultMapper().list(query, CHT0117GrdCHT0117InitListItemInfo.class);
		return list;
	}
	
	@Override
	@Cacheable(value = "Cht0117Repository")
	public String getCHT0117grdCHT0117Check(String hospCode, String language, String buwi) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'              ");
		sql.append("	FROM CHT0117            ");
		sql.append("	WHERE BUWI = :f_buwi    ");
		sql.append(" AND HOSP_CODE = :hosp_code AND LANGUAGE = :language ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_buwi", buwi);
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	@Cacheable(value = "Cht0117Repository")
	public String getCHT0117TransactionalLayCheck(String buwi, Date startDate, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT 'Y'							");								 							
		sql.append("	FROM CHT0117						");	
		sql.append("	WHERE BUWI        = :f_buwi			");
		sql.append("	AND HOSP_CODE      = :hospCode		");
		sql.append("    AND LANGUAGE = :language            ");
		sql.append("	AND START_DATE >= :f_start_date		");
		sql.append("	LIMIT 1								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_buwi", buwi);
		query.setParameter("f_start_date", startDate);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	@Cacheable(value = "Cht0117Repository")
	public List<CHT0117Q00DloCHT0117Info> getCHT0117Q00DloCHT0117Info(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.START_DATE,                                    ");
		sql.append("       A.END_DATE  ,                                    ");
		sql.append("       A.BUWI      ,                                    ");
		sql.append("       A.BUWI_NAME                                      ");
		sql.append("  FROM CHT0117 A                                        ");
		sql.append(" WHERE SYSDATE() BETWEEN A.START_DATE AND A.END_DATE    ");
		sql.append(" AND HOSP_CODE  = :hospCode AND LANGUAGE = :language    ");
		sql.append(" ORDER BY A.SORT_KEY, A.BUWI_NAME                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		List<CHT0117Q00DloCHT0117Info> list = new JpaResultMapper().list(query, CHT0117Q00DloCHT0117Info.class);
		return list;
	}
}

