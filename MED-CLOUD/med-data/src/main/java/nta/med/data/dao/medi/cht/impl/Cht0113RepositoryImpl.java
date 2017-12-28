package nta.med.data.dao.medi.cht.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.cht.Cht0113;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cht.Cht0113Repository;
import nta.med.data.model.ihis.chts.CHT0113Q00GrdCHT0113Info;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository("cht0113Repository")
public class Cht0113RepositoryImpl extends SimpleJpaRepository<Cht0113, Long> implements Cht0113Repository {
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Cht0113RepositoryImpl(EntityManager entityManager) {
		super(Cht0113.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Cht0113Repository", allEntries = true)
	public Cht0113 save(Cht0113 entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Cht0113Repository", allEntries = true)
	public List<Cht0113> save(List<Cht0113> entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Cht0113Repository", allEntries = true)
	@Override
	public void delete(Cht0113 entity) {
		super.delete(entity);
	}
	
	@Cacheable(value = "Cht0113Repository")
	public List<CHT0113Q00GrdCHT0113Info> getCHT0113Q00GrdCHT0113Info (String disabilityName, String date) {
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT A.DISABILITY_CODE,																		");
		sql.append("	       A.DISABILITY_NAME,                                                                       ");
		sql.append("	       A.DISABILITY_KANA_NAME,                                                                  ");
		sql.append("	       A.START_DATE,                                                                            ");
		sql.append("	       A.END_DATE,                                                                              ");
		sql.append("	       A.DELETE_YN,                                                                             ");
		sql.append("	       A.PKCHT0113,                                                                             ");
		sql.append("	       'N'                                                                                      ");
		sql.append("	  FROM CHT0113  A                                                                               ");
		sql.append("	 WHERE A.DISABILITY_NAME LIKE :f_disability_name                                                ");
		sql.append("	   AND IFNULL(:f_date, DATE_FORMAT(SYSDATE(),'%Y/%m/%d')) BETWEEN A.START_DATE AND A.END_DATE   ");
		sql.append("	ORDER BY A.SORT_KEY                                                                             ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_date", date);
		query.setParameter("f_disability_name", "%" + disabilityName + "%");
			
		List<CHT0113Q00GrdCHT0113Info> list = new JpaResultMapper().list(query, CHT0113Q00GrdCHT0113Info.class);
		return list;
	}
	
}

