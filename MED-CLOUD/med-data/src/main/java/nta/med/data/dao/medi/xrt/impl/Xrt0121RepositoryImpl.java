package nta.med.data.dao.medi.xrt.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.xrt.Xrt0121;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.xrt.Xrt0121Repository;
import nta.med.data.model.ihis.xrts.XRT0122U00GrdMcodeInfo;

/**
 * @author dainguyen.
 */
@Repository("Xrt0121Repository")
public class Xrt0121RepositoryImpl extends SimpleJpaRepository<Xrt0121, Long> implements Xrt0121Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Xrt0121RepositoryImpl(EntityManager entityManager) {
		super(Xrt0121.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Xrt0121Repository", allEntries = true)
	public Xrt0121 save(Xrt0121 entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Xrt0121Repository", allEntries = true)
	public List<Xrt0121> save(List<Xrt0121> entities) {
		return super.save(entities);
	}
	
	
	@CacheEvict(value = "Xrt0121Repository", allEntries = true)
	@Override
	public void delete(Xrt0121 entity) {
		super.delete(entity);
	}
	
	
	@Override
	@Cacheable(value="Xrt0121Repository")
	public List<XRT0122U00GrdMcodeInfo> getInitializeItem(String hospCode,
			String buwibunryu, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT BUWI_BUNRYU, 																		");
		sql.append("	BUWI_BUNRYU_NAME                                                                            ");
		sql.append("	FROM XRT0121                                                                                ");
		sql.append("	WHERE                                                                                       ");
		sql.append("	 BUWI_BUNRYU LIKE :buwibunryu                                                               ");
		sql.append("	 AND LANGUAGE = :language                                                               	");
		sql.append("	ORDER BY 1                                                                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("buwibunryu", "%"+buwibunryu+"%");
		query.setParameter("language", language);
		
		List<XRT0122U00GrdMcodeInfo> listResult = new JpaResultMapper().list(query, XRT0122U00GrdMcodeInfo.class);
		return listResult;
	}

	@Override
	@Cacheable(value="Xrt0121Repository")
	public String getXRT0122U00LayDupM(String hospCode, String buwiBunryu, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'								");
		sql.append("	FROM XRT0121                            ");
		sql.append("	WHERE                                   ");
		sql.append("	 BUWI_BUNRYU = :buwiBunryu              ");
		sql.append("	 AND LANGUAGE = :language               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("buwiBunryu", buwiBunryu);
		query.setParameter("language", language);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}

	@Override
	@CacheEvict(value = "Xrt0121Repository", allEntries = true)
	public Integer updateXrt0121Transaction(String updId, String buwiBunryuName, String hospCode, String buwiBunryu, String language) {
		String sqlQuery = "UPDATE Xrt0121 SET updId = :updId  , updDate   = SYSDATE() , buwiBunryuName  = :buwiBunryuName  WHERE buwiBunryu  = :buwiBunryu AND language = :language ";
		Query query = entityManager.createQuery(sqlQuery.toString());
		query.setParameter("updId", updId);
		query.setParameter("buwiBunryuName", buwiBunryuName);
		query.setParameter("buwiBunryu", buwiBunryu);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
	
	@Override
	@CacheEvict(value = "Xrt0121Repository", allEntries = true)
	public Integer deleteXrt0121Transaction(String hospCode, String buwiBunryu, String language) {
		String sql = "DELETE FROM Xrt0121	WHERE  buwiBunryu     = :buwiBunryu AND language = :language ";
		Query query = entityManager.createQuery(sql.toString());
		query.setParameter("buwiBunryu", buwiBunryu);
		query.setParameter("language", language);
		return query.executeUpdate();
	}
}

