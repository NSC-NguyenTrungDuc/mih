package nta.med.data.dao.medi.bas.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.bas.Bas0123;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.data.model.ihis.bass.BAS0123U00FwkZipCodeInfo;
import nta.med.data.model.ihis.bass.BAS0123U00GrdBAS0123Info;
import nta.med.data.model.ihis.system.BasManageZipCodeInfo;

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
@Repository("bas0123Repository")
public class Bas0123RepositoryImpl extends SimpleJpaRepository<Bas0123, Long> implements Bas0123Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Bas0123RepositoryImpl(EntityManager entityManager) {
		super(Bas0123.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Bas0123Repository", allEntries = true)
	public Bas0123 save(Bas0123 entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Bas0123Repository", allEntries = true)
	public List<Bas0123> save(List<Bas0123> entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Bas0123Repository", allEntries = true)
	@Override
	public void delete(Bas0123 entity) {
		super.delete(entity);
	}
	
	@Cacheable(value="Bas0123Repository")
	public List<Bas0123> getBAS0001U00ControlDataValidating(String zipCode){
		String sql = " SELECT A FROM Bas0123 A WHERE A.zipCode = :f_zip_code "; 
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_zip_code", zipCode);
		return query.getResultList();
	}
	
	@Cacheable(value="Bas0123Repository")
	public List<Bas0123> getFwkZipCode(String code, String find1){
		String sql ="SELECT a FROM Bas0123 a where a.zipCode like :code AND ( a.zipCode like :find1 OR a.zipName1 like :find1 "
				  + " OR a.zipName2 like :find1 OR a.zipName3 like :find1) ORDER BY 1 ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("code", code);
		query.setParameter("find1", find1);
		return query.getResultList();
	}
	
	@Cacheable(value="Bas0123Repository")
	public List<Bas0123> getBAS0123U00GrdBAS0123(String code){
		String sql = "SELECT a FROM Bas0123 a where a.zipCode like :code ORDER BY CONCAT(a.zipCode, a.zipName1, a.zipName2, a.zipName3)";
		Query query = entityManager.createQuery(sql);
		query.setParameter("code", code);
		return query.getResultList();
	}
	
	@Cacheable(value="Bas0123Repository")
	public List<Bas0123> getByZipCode(String code){
		String sql = "SELECT a FROM Bas0123 a where  a.zipCode = :code ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("code", code);
		return query.getResultList();
	}
	
	@Cacheable(value="Bas0123Repository")
	public String checkExistBas0123U00(String code, String zipName1,
			 String zipName2, String zipName3){
		String sql = " SELECT DISTINCT 'Y' FROM Bas0123 a where a.zipCode = :code "
				   + " AND a.zipName1 = :zipName1 AND  a.zipName2 = :zipName2 AND a.zipName3 = :zipName3 ";
		Query query= entityManager.createQuery(sql);
		query.setParameter("code", code);
		query.setParameter("zipName1", zipName1);
		query.setParameter("zipName2", zipName2);
		query.setParameter("zipName3", zipName3);
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}
	
	@CacheEvict(value="Bas0123Repository", allEntries = true)
	public Integer updateBas0123 (String updId, Date updDate, String zipName1 ,
			 String zipName2 , String zipName3 , String zipNameGana1 ,
			 String zipNameGana2 , String zipNameGana3 ,
			 String zipTonggye, String zipCode){
		String sqlQuery = "UPDATE Bas0123 SET updId = :updId, updDate = :updDate, zipName1 = :zipName1, "
				        + "zipName2 = :zipName2, zipName3 = :zipName3, zipNameGana1 = :zipNameGana1, "
				        + "zipNameGana2 =:zipNameGana2, zipNameGana3 =:zipNameGana3, zipTonggye = :zipTonggye "
				        + "WHERE zipCode = :zipCode ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("updId", updId);
		query.setParameter("updDate", updDate);
		query.setParameter("zipName1", zipName1 );
		query.setParameter("zipName2", zipName2 );
		query.setParameter("zipName3", zipName3 );
		query.setParameter("zipNameGana1", zipNameGana1 );
		query.setParameter("zipNameGana2", zipNameGana2 );
		query.setParameter("zipNameGana3", zipNameGana3 );
		query.setParameter("zipTonggye", zipTonggye);
		query.setParameter("zipCode", zipCode);
		return query.executeUpdate();
	}
	
	@CacheEvict(value="Bas0123Repository", allEntries = true)
	public Integer deleteBas0123(String zipCode){
		String sqlQuery = "DELETE FROM Bas0123 WHERE zipCode = :zipCode";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("zipCode", zipCode);
		return query.executeUpdate();
	}

	@Override
	@Cacheable(value="Bas0123Repository")
	public List<String> getNuroCboZipCodeInfo(String zipCode1, String zipCode2) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CONCAT(A.ZIP_NAME1 , A.ZIP_NAME2 , A.ZIP_NAME3) ");
		sql.append("FROM BAS0123 A                                         ");
		sql.append("WHERE A.ZIP_CODE = CONCAT(:zipCode1 , :zipCode2)   	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("zipCode1", zipCode1);
		query.setParameter("zipCode2", zipCode2);

		List<String> list = query.getResultList();
		return list;
	}

	@Override
	@Cacheable(value="Bas0123Repository")
	public List<BasManageZipCodeInfo> getBasManageZipCodeInfo(String condition, String address, String zip1, String zip2) {
		StringBuilder sql = new StringBuilder();

		sql.append("SELECT A.ZIP_CODE                                                                              ");
		sql.append("     , A.ZIP_NAME1                                                                             ");
		sql.append("     , A.ZIP_NAME2                                                                             ");
		sql.append("     , A.ZIP_NAME3                                                                             ");
		sql.append("     , A.ZIP_NAME_GANA1                                                                        ");
		sql.append("     , A.ZIP_NAME_GANA2                                                                        ");
		sql.append("     , A.ZIP_NAME_GANA3                                                                        ");
		sql.append("     , A.ZIP_CODE1                                                                             ");
		sql.append("     , A.ZIP_CODE2                                                                             ");
		sql.append("  FROM BAS0123 A                                                                               ");
		sql.append(" WHERE ((:condition = '2' AND CONCAT(A.ZIP_NAME1, A.ZIP_NAME2, A.ZIP_NAME3) LIKE :address)     ");
		sql.append("    OR (:condition = '1' AND(A.ZIP_CODE1 LIKE :zip1 AND A.ZIP_CODE2 LIKE :zip2)))              ");
		sql.append(" ORDER BY A.ZIP_CODE                                                                           ");
		sql.append(" limit 0,100                                                                                   "); 

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("condition", condition);
		query.setParameter("address", "%" + address + "%");
		query.setParameter("zip1", "%" + zip1 + "%");
		query.setParameter("zip2", "%" + zip2 + "%");

		List<BasManageZipCodeInfo> list = new JpaResultMapper().list(query,BasManageZipCodeInfo.class);
		return list;
	}

	@Override
	@Cacheable(value="Bas0123Repository")
	public String getBAS0110U00LayZipCode2Info(String zipCode1, String zipCode2) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CONCAT(A.ZIP_NAME1 , A.ZIP_NAME2 )  	");
		sql.append("	FROM BAS0123 A                              ");
		sql.append("	WHERE A.ZIP_CODE1 = :zipCode1                 ");
		sql.append("	AND A.ZIP_CODE2 = :zipCode2                ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("zipCode1", zipCode1);
		query.setParameter("zipCode2",zipCode2);
	
		List<Object> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.get(0) != null){
			return list.get(0).toString();
		}
		return null;
	}

	@Override
	@Cacheable(value="Bas0123Repository")
	public String getBAS0110U00GrdJohapGubunZipCode(String zipCode1, String zipCode2) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CONCAT(A.ZIP_NAME1 , A.ZIP_NAME2 , A.ZIP_NAME3)	 ZIP_NAME	");
		sql.append("	FROM BAS0123 A                                                      ");
		sql.append("	WHERE A.ZIP_CODE1 = :zipCode1                             	       ");
		sql.append("	  AND A.ZIP_CODE2 = :zipCode2                               	     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("zipCode1", zipCode1);
		query.setParameter("zipCode2",zipCode2);
		
		List<Object> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.get(0) != null){
			return list.get(0).toString();
		}
		return null;
	}
	
	@Override
	@Cacheable(value="Bas0123Repository")
	public List<BAS0123U00GrdBAS0123Info> getBAS0123U00GrdBAS0123Info(String zipCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.ZIP_CODE                                                        ");
		sql.append(" , A.ZIP_NAME1                                                           ");
		sql.append(" , A.ZIP_NAME2                                                           ");
		sql.append(" , A.ZIP_NAME3                                                           ");
		sql.append(" , A.ZIP_NAME_GANA1                                                      ");
		sql.append(" , A.ZIP_NAME_GANA2                                                      ");
		sql.append(" , A.ZIP_NAME_GANA3                                                      ");
		sql.append(" , A.ZIP_TONGGYE                                                         ");
		sql.append(" FROM BAS0123 A                                                          ");
		sql.append(" WHERE A.ZIP_CODE LIKE :f_zip_code                                       ");
		sql.append(" ORDER BY CONCAT(A.ZIP_CODE , A.ZIP_NAME1 , A.ZIP_NAME2 , A.ZIP_NAME3)   ");
		sql.append(" LIMIT 0,100                                                             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_zip_code", "%" + zipCode + "%");

		List<BAS0123U00GrdBAS0123Info> list = new JpaResultMapper().list(query, BAS0123U00GrdBAS0123Info.class);
		return list;
	}
	
	@Override
	@Cacheable(value="Bas0123Repository")
	public List<BAS0123U00FwkZipCodeInfo> getBAS0123U00FwkZipCodeInfo(String code, String find1){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.ZIP_CODE                   ");
		sql.append(" , A.ZIP_NAME1                      ");
		sql.append(" , A.ZIP_NAME2                      ");
		sql.append(" , A.ZIP_NAME3                      ");
		sql.append(" FROM BAS0123 A                     ");
		sql.append("WHERE A.ZIP_CODE LIKE :f_code        ");
		sql.append(" AND(A.ZIP_CODE LIKE :f_find1       ");
		sql.append(" OR A.ZIP_NAME1 LIKE :f_find1       ");
		sql.append(" OR A.ZIP_NAME2 LIKE :f_find1       ");
		sql.append(" OR A.ZIP_NAME3 LIKE :f_find1 )     ");
		sql.append(" ORDER BY 1                         ");
		sql.append(" LIMIT 0,100                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code", "%" + code + "%");
		query.setParameter("f_find1", "%" + find1 + "%");

		List<BAS0123U00FwkZipCodeInfo> list = new JpaResultMapper().list(query, BAS0123U00FwkZipCodeInfo.class);
		return list;
	}
	
	@Override
	@Cacheable(value="Bas0123Repository")
	public List<String> getZipNameByZipCode(String zipCode1, String zipCode2){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT concat(IFNULL(A.ZIP_NAME1,''),IFNULL(A.ZIP_NAME2,''),IFNULL(A.ZIP_NAME3,''))");
		sql.append("  FROM BAS0123 A");
		sql.append(" WHERE (A.ZIP_CODE1 LIKE :f_zip1 and A.ZIP_CODE2 LIKE :f_zip2)");

		sql.append(" ORDER BY A.ZIP_CODE");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_zip1", "%"+zipCode1+"%");
		query.setParameter("f_zip2", "%"+zipCode2+"%");

		return query.getResultList();
	}
}
