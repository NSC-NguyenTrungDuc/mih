package nta.med.data.dao.medi.sch.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.sch.Sch0108;
import nta.med.data.dao.medi.sch.Sch0108Repository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
@Repository("sch0108Repository")
public class Sch0108RepositoryImpl extends SimpleJpaRepository<Sch0108, Long> implements Sch0108Repository {
	@PersistenceContext
	EntityManager entityManager;
	
	@Autowired
	public Sch0108RepositoryImpl(EntityManager entityManager) {
		super(Sch0108.class, entityManager);
	}
	
	@Override
	@Cacheable(value="Sch0108Repository")
	public List<Sch0108> getSCH0109U00GrdMasterInfo(String hospCode,
			String codeType, String codeTypeName, String language) {
		String sqlQuery = " SELECT A FROM Sch0108 A WHERE A.codeType LIKE :codeType "
					    + " AND IFNULL(A.codeTypeName, '%') LIKE :codeTypeName AND A.adminGubun = 'USER' AND A.language = :f_language ORDER BY A.codeType";
		Query query= entityManager.createQuery(sqlQuery);
		//query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType); 
		query.setParameter("codeTypeName", codeTypeName);
		query.setParameter("f_language", language);
		List<Sch0108> list = query.getResultList();
		return list;
	}
	@Override
	@Cacheable(value="Sch0108Repository")
	public List<Sch0108> getSCH0109U01GrdMasterInfo(String hospCode,
			String codeType,String codeTypeName, String language) {
		String sqlQuery = " SELECT A FROM Sch0108 A WHERE A.codeType LIKE :codeType " 
						+ " AND IFNULL(A.codeTypeName, '%') LIKE :codeTypeName AND A.language = :f_language ORDER BY A.codeType";
		Query query= entityManager.createQuery(sqlQuery);
		//query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType); 
		query.setParameter("codeTypeName", codeTypeName);
		query.setParameter("f_language", language);
		List<Sch0108> list = query.getResultList();
		return list;
	}
	
	@Override
	@Cacheable(value="Sch0108Repository")
	public String getSCH0109U00LayDupM(String hospCode,
			String codeType, String language) {
		String sqlQuery = "SELECT DISTINCT 'Y' FROM Sch0108 WHERE codeType = :codeType AND language = :f_language ";
		Query query= entityManager.createQuery(sqlQuery);
	//	query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType); 
		query.setParameter("f_language", language);
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}
	
	@Override
	@CacheEvict(value = "Sch0108Repository", allEntries = true)
	public Integer updateSCH0108XSavePerformer(String updId,
			Date updDate, String codeTypeName,
			String hospCode, String codeType, String language) {
		String sqlQuery = " UPDATE Sch0108 SET updId = :updId, updDate = :updDate, codeTypeName  = :codeTypeName "			
						+ " WHERE codeType = :codeType AND language = :f_language ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("updId", updId);
		query.setParameter("updDate", updDate); 
		query.setParameter("codeTypeName", codeTypeName);
		query.setParameter("codeType", codeType);
		query.setParameter("f_language", language);
		return query.executeUpdate();
	}
	
	@Override
	@CacheEvict(value = "Sch0108Repository", allEntries = true)
	public Integer updateSCH0109U01Execute(String updId,
			Date updDate, String codeTypeName,
			String adminGubun, String remark,
			String hospCode, String codeType, String language) {
		String sqlQuery = "	UPDATE Sch0108 SET updId = :updId, updDate = :updDate, codeTypeName  = :codeTypeName, "
						+ "	adminGubun = :adminGubun, remark =:remark "			
						+ "	WHERE codeType = :codeType AND language = :f_language ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("updId", updId);
		query.setParameter("updDate", updDate); 
		query.setParameter("codeTypeName", codeTypeName);
		query.setParameter("adminGubun", adminGubun); 
		query.setParameter("remark", remark);
		//query.setParameter("hospCode", hospCode); 
		query.setParameter("codeType", codeType);
		query.setParameter("f_language", language);
		return query.executeUpdate();
	}
	
	@Override
	@CacheEvict(value = "Sch0108Repository", allEntries = true)
	public Integer deleteSCH0108XSavePerformer(String hospCode,
			String codeType, String language) {
		String sqlQuery = "DELETE Sch0108 WHERE codeType = :codeType AND language = :f_language ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("codeType", codeType);
		query.setParameter("f_language", language);
		return query.executeUpdate();
	}
	
	@Override
	public Sch0108 save(Sch0108 entity) {
		return super.save(entity);
	}
	
	@Override
	public List<Sch0108> save(List<Sch0108> entities) {
		return super.save(entities);
	}
}

